Imports OfficeOpenXml
Imports System.IO

Public Class fr_export_efaktur
    Private tabpagename As TabPage
    Private colheadr_FK As String() = {"FK", "KD_JENIS_TRANSAKSI", "FG_PENGGANTI", "NOMOR_FAKTUR", "MASA_PAJAK", "TAHUN_PAJAK", "TANGGAL_FAKTUR", "NPWP", "NAMA",
                                      "ALAMAT_LENGKAP", "JUMLAH_DPP", "JUMLAH_PPN", "JUMLAH_PPNBM", "ID_KETERANGAN_TAMBAHAN", "FG_UANG_MUKA", "UANG_MUKA_DPP",
                                       "UANG_MUKA_PPN", "UANG_MUKA_PPNBM", "REFERENSI"}
    Private colheadr_LT As String() = {"LT", "NPWP", "NAMA", "JALAN", "BLOK", "NOMOR", "RT", "RW", "KECAMATAN", "KELURAHAN", "KABUPATEN",
                                        "PROPINSI", "KODE_POS", "NOMOR_TELEPON"}
    Private colheadr_OF As String() = {"OF", "KODE_OBJEK", "NAMA", "HARGA_SATUAN", "JUMLAH_BARANG", "HARGA_TOTAL", "DISKON", "DPP", "PPN", "TARIF_PPNBM", "PPNBM"}
    Private cacheSelectFakTemp As New List(Of String)
    Private cacheFaktur As New List(Of DataTable)
    Private SelectedPageData As Integer = 1
    Private MaxPageData As Integer = 1


    Public Sub setpage(page As TabPage)
        tabpagename = page
        consoleWriteLine("pg" & page.Name.ToString)
        consoleWriteLine("pgset" & tabpagename.Name.ToString)
    End Sub

    Public Sub performRefresh()
        For Each txt As TextBox In {in_id, in_page}
            txt.Clear()
        Next
        For Each datepick As DateTimePicker In {date_periode, date_tgl}
            datepick.Value = Today
        Next
        dgv_faktur.DataSource.Rows.Clear()
    End Sub

    'LOAD HEADER
    Private Sub LoadHeader(IdExport As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim q As String = ""

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT efak_tgl, efak_periode FROM data_penjualan_efak WHERE efak_id='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, IdExport), CommandBehavior.SingleRow)
                    Dim red = rdx.Read()
                    If red = rdx.HasRows Then
                        in_id.Text = IdExport
                        date_tgl.Value = rdx.Item(0)
                        date_periode.Value = rdx.Item(1)
                    End If
                End Using
                q = "SELECT COUNT(e_list_kodefaktur) FROM data_penjualan_efak_list WHERE e_list_status=1 AND e_list_templateid='{0}'"
                MaxPageData = CInt(Math.Ceiling(CInt(x.ExecScalar(String.Format(q, IdExport))) / 2000))
                consoleWriteLine(MaxPageData)
            End If
        End Using
    End Sub

    'LOAD DATAGRID
    Private Sub LoadDataGrid(IdExport As String, Optional PgNumber As Integer = 1)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim q As String = ""
        Dim col = New List(Of String) From {"e_list_selectstate", "e_list_kodefaktur", "faktur_tanggal_trans", "e_list_kodepajak", "e_list_tglpajak",
                                            "GetMasterNama('custo', faktur_customer) faktur_customer", "GetMasterNama('custonpwp', faktur_customer) faktur_npwp",
                                            "ROUND((CASE faktur_ppn_jenis WHEN 1 THEN faktur_netto*(10/11) ELSE faktur_netto END),2) faktur_dpp",
                                            "ROUND((CASE faktur_ppn_jenis WHEN 1 THEN faktur_netto*(1-(10/11)) WHEN 2 THEN faktur_netto*0.1 ELSE 0 END),2) faktur_ppn"}
        Dim _limit As Integer = (PgNumber * 2000) - 2000

        SetupDatagridProp()

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "UPDATE data_penjualan_efak_list LEFT JOIN data_penjualan_faktur ON faktur_kode=e_list_kodefaktur " _
                    & "SET e_list_status=IF(faktur_status<>1,9,1) WHERE e_list_templateid='{0}' AND e_list_status=1"
                x.ExecCommand(String.Format(q, IdExport))

                q = "SELECT {0} FROM data_penjualan_efak_list LEFT JOIN data_penjualan_faktur ON e_list_kodefaktur=faktur_kode " _
                    & "WHERE e_list_templateid='{1}' AND e_list_status=1 LIMIT {2},2000"
                Using dtx = x.GetDataTable(String.Format(q, String.Join(",", col), IdExport, _limit))
                    setDoubleBuffered(dgv_faktur, True)
                    dgv_faktur.DataSource = dtx
                    dgv_faktur.Columns(0).ReadOnly = False
                    in_page.Text = PgNumber
                    SelectedPageData = PgNumber
                End Using
            End If
        End Using
    End Sub

    'SET DATAGRID
    Private Sub SetupDatagridProp()
        For Each colx As DataGridViewColumn In {faktur_tgl_pajak, faktur_tgl_trans}
            colx.DefaultCellStyle = dgvstyle_date
        Next
        For Each colx As DataGridViewColumn In {faktur_dpp, faktur_ppn}
            colx.DefaultCellStyle = dgvstyle_currency
        Next
    End Sub

    'CHANGE TAX DATE
    Private Sub changeTaxDate(IdExport As String, periode As Date)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim q As String = ""

        Me.Cursor = Cursors.WaitCursor

        q = "UPDATE data_penjualan_efak_list SET e_list_tglpajak = GetEFakDateByPeriode(e_list_kodefaktur, {1}, {2}) " _
            & "WHERE e_list_templateid='{0}' AND e_list_selectstate=1 AND DATE_FORMAT(e_list_tglpajak,'%m%Y')!='{3}' AND e_list_status=1"

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Try
                    Dim i = x.ExecCommand(String.Format(q, IdExport, periode.Month, periode.Year, periode.ToString("MMyyyy")))
                    MessageBox.Show("Tanggal pajak " & i & " faktur telah disesuaikan.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadDataGrid(IdExport, in_page.Text)
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Terjadi kesalahan saat melakukan perubahan data." & Environment.NewLine & ex.Message,
                                    "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

        Me.Cursor = Cursors.Default
    End Sub

    'REMOVE NO PAJAK
    Private Sub KosongNoPajak(IdExport As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim q As String = " UPDATE data_penjualan_efak_list SET e_list_kodepajak='' WHERE e_list_templateid='{0}'"
        q = String.Format(q, IdExport)

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                x.ExecCommand(q)
                MessageBox.Show("Nomor pajak telah dikosongkan.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                LoadDataGrid(in_id.Text, in_page.Text)
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'EXPORT EFAKTUR
    Private Function ExportDataEfak(Filename As String, FileType As String, IdExport As String) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim q As String = ""
        Dim _FakturList As New List(Of String)

        Using x = MainConnection
            x.Open()
            If Not x.ConnectionState = ConnectionState.Open Then
                'Message
                Return False : Exit Function
            End If

            q = "SELECT e_list_kodefaktur FROM data_penjualan_efak_list WHERE e_list_templateid='{0}' AND e_list_selectstate=1 AND e_list_status=1"
            Using rdx = x.ReadCommand(String.Format(q, IdExport))
                While rdx.Read
                    _FakturList.Add(rdx.Item(0))
                End While
            End Using

            If _FakturList.Count > 0 Then
                If FileType = "xlsx" Then
                    Return exportXlsx(Filename, IdExport, _FakturList)
                ElseIf FileType = "csv" Then
                    Return exportCSV(Filename, IdExport, _FakturList)
                Else
                    Return False
                End If
            Else
                MessageBox.Show("no output for those date range", "Export Efaktur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End Using

    End Function

    Private Function createQuery(type As String, FakturKode As String, IdExport As String) As String
        Dim q As String = ""
        Dim col As New List(Of String)

        Select Case type
            Case "exportFK"
                q = "CALL EFak_GetDataFK('{0}', '{1}')" : q = String.Format(q, FakturKode, IdExport)

            Case "exportOF"
                If FakturKode <> Nothing Then
                    q = "CALL EFak_GetDataOF('{0}')" : q = String.Format(q, FakturKode)
                End If
        End Select
        Return q
    End Function

    'EXPORT CSV
    Private Function exportCSV(fileLoc As String, IdExport As String, kode_faktur As List(Of String), Optional fielddelimiter As String = ";",
                               Optional rowdelimiter As String = ControlChars.NewLine) As Boolean
        Dim _retsuc As Boolean = False
        Dim contain As New List(Of String)

        Try
            contain.Add(String.Join(fielddelimiter, colheadr_FK))
            contain.Add(String.Join(fielddelimiter, colheadr_LT))
            contain.Add(String.Join(fielddelimiter, colheadr_OF))
            For Each kode As String In kode_faktur
                contain.Add(getDataTablefromDB(createQuery("exportFK", kode, IdExport), True).ToCsv(False, vbCrLf, fielddelimiter))
                contain.Add(getDataTablefromDB(createQuery("exportOF", kode, IdExport), True).ToCsv(False, vbCrLf, fielddelimiter))
            Next

            System.IO.File.WriteAllText(fileLoc, String.Join(rowdelimiter, contain))
            consoleWriteLine(fileLoc)
            _retsuc = System.IO.File.Exists(fileLoc)
        Catch ex As Exception
            logError(ex, True)
            MessageBox.Show("ERROR. Terjadi kesalahan saat melakukan export" & vbCrLf & ex.Message, "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _retsuc = False
        End Try

        Return _retsuc
    End Function

    'EXPORT XLSX
    Private Function exportXlsx(fileloc As String, IdExport As String, kode_faktur As List(Of String), Optional filename As String = Nothing) As Boolean
        Dim _retsuc As Boolean = False
        Dim contain As New List(Of String)
        Dim dt_fk As New DataTable
        Dim dt_of As New DataTable

        If filename = Nothing Then
            filename = Strings.Replace(Strings.Replace(fileloc, System.IO.Path.GetDirectoryName(fileloc), ""), ".xlsx", "")
            If filename = "" Then
                filename = "Export EFaktur " & Today.ToShortDateString
            End If
        End If
        fileloc = System.IO.Path.GetDirectoryName(fileloc)

        Try
            Using xls As New ExcelPackage
                Dim wrksht As ExcelWorksheet = xls.Workbook.Worksheets.Add(filename)
                Dim rows As Integer = 1

                For Each colhead As String() In {colheadr_FK, colheadr_LT, colheadr_OF}
                    Dim col As Integer = 1
                    For Each colnm As String In colhead
                        wrksht.Cells(rows, col).Value = colnm
                        col += 1
                    Next
                    rows += 1
                Next
                For Each kode As String In kode_faktur
                    dt_fk = getDataTablefromDB(createQuery("exportFK", kode, IdExport), True)
                    dt_of = getDataTablefromDB(createQuery("exportOF", kode, IdExport), True)
                    wrksht.Cells(rows, 1, rows, dt_fk.Columns.Count).Value = dt_fk.Rows(0).ItemArray()
                    rows += 1
                    For Each objkrows As DataRow In dt_of.Rows
                        For i = 0 To dt_of.Columns.Count - 1
                            wrksht.Cells(rows, i + 1).Value = objkrows.ItemArray(i)
                        Next
                        rows += 1
                    Next
                Next

                xls.SaveAs(New FileInfo(fileloc & filename & ".xlsx"))

                _retsuc = System.IO.File.Exists(fileloc)
            End Using
        Catch ex As Exception
            logError(ex, True)
            MessageBox.Show("ERROR. Terjadi kesalahan saat melakukan export" & vbCrLf & ex.Message, "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            _retsuc = False
        End Try

        Return _retsuc
    End Function

    'UPDATE EXPORT DATE/BY
    Private Sub ExportUpdLastExport(IdExport As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim q As String = "UPDATE data_penjualan_efak SET efak_lastexport=NOW(), efak_lastexport_by='{1}' WHERE efak_id='{0}'"

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                x.ExecCommand(String.Format(q, IdExport, loggeduser.user_id))
            End If
        End Using
    End Sub

    'CLOSE
    Private Sub bt_close_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_close_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.performRefresh()
        main.tabcontrol.TabPages.Remove(tabpagename)
    End Sub

    'UI : BUTTON
    Private Sub bt_loadtemplate_Click(sender As Object, e As EventArgs) Handles bt_loadtemplate.Click
        Using x As New fr_search_export
            Dim _ret As String = ""
            x.DoLoadDialog()
            _ret = x.ReturnId

            If Not String.IsNullOrWhiteSpace(_ret) Then
                LoadHeader(_ret)
                LoadDataGrid(_ret)
            End If
        End Using
    End Sub

    Private Sub bt_createtemplate_Click(sender As Object, e As EventArgs) Handles bt_createtemplate.Click
        Using x As New fr_newexport
            Dim _ret As String = ""
            x.DoLoadDialog()
            _ret = x.ReturnId

            If Not String.IsNullOrWhiteSpace(_ret) Then
                LoadHeader(_ret)
                LoadDataGrid(_ret)
            End If
        End Using
    End Sub

    Private Sub bt_refresh_Click(sender As Object, e As EventArgs) Handles bt_refresh.Click
        Me.performRefresh()
    End Sub

    Private Sub bt_savetemplate_Click(sender As Object, e As EventArgs) Handles bt_savetemplate.Click
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim q As String = ""

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "UPDATE data_penjualan_efak SET efak_tgl='{1}', efak_periode='{2}' WHERE efak_id='{0}'"
                q = String.Format(q, in_id.Text, date_tgl.Value.ToString("yyyy-MM-dd"), date_periode.Value.ToString("yyyy-MM-01"))
                If x.TransactCommand(New List(Of String) From {q}) Then
                    MessageBox.Show("Data Export tersimpan.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Data Export gagal tersimpan.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Sub bt_deletetemplate_Click(sender As Object, e As EventArgs) Handles bt_deletetemplate.Click
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim q As String = ""

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "UPDATE data_penjualan_efak SET efak_status=9 WHERE efak_id='{0}'"
                If x.TransactCommand(New List(Of String) From {String.Format(q, in_id.Text)}) Then
                    MessageBox.Show("Data Export telah dihapus.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    performRefresh()
                Else
                    MessageBox.Show("Data Export gagal dihapus.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        If String.IsNullOrWhiteSpace(in_id.Text) Then Exit Sub

        Using x = New fr_exportaddfaktur
            x.DoLoadDialog(in_id.Text)
            If x.ReturnValue Then LoadDataGrid(in_id.Text)
        End Using
    End Sub

    Private Sub bt_urutnopajak_Click(sender As Object, e As EventArgs) Handles bt_urutnopajak.Click
        If String.IsNullOrWhiteSpace(in_id.Text) Then Exit Sub

        Dim KodePajak As String = ""
        Dim TicketQty As Integer = 0

        Using x = New fr_urutnofaktur
            x.DoLoadDialog(in_id.Text)
            If x.ReturnValue Then
                LoadDataGrid(in_id.Text, in_page.Text)
            End If
        End Using
    End Sub

    Private Sub bt_kosongnopajak_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(in_id.Text) Then Exit Sub
        Dim _msgRes As DialogResult = MessageBox.Show("Kosongkan nomor pajak faktur-faktur di data export?", "Export EFaktur",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If _msgRes = DialogResult.Yes Then
            KosongNoPajak(in_id.Text)
        End If
    End Sub

    Private Sub bt_samamasapajak_Click(sender As Object, e As EventArgs) Handles bt_samamasapajak.Click
        If String.IsNullOrWhiteSpace(in_id.Text) Then Exit Sub
        Dim _msgText As String = "Samakan periode pajak untuk faktur yang dipilih? (" & date_periode.Value.ToString("MMMM yyyy") & ")" & Environment.NewLine _
                                 & "Tgl pajak faktur sebelum dan sesudah periode terpilih akan di update ke awal dan akhir periode terpilih"
        Dim _msgRes As DialogResult = MessageBox.Show(_msgText, "Export EFaktur", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If _msgRes = DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            changeTaxDate(in_id.Text, date_periode.Value)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub bt_export_Click(sender As Object, e As EventArgs) Handles bt_export.Click
        If String.IsNullOrWhiteSpace(in_id.Text) Then Exit Sub

        Dim _svdialog As New SaveFileDialog
        Dim _seltype As String = "csv"

        _svdialog.Filter = "CSV files (*.csv)|*.csv|Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        _svdialog.FilterIndex = 1
        _svdialog.RestoreDirectory = True
        _svdialog.DefaultExt = ".csv"
        _svdialog.FileName = _svdialog.FileName & "EXPORT EFAKTUR"
        If _svdialog.ShowDialog = DialogResult.OK Then
            If _svdialog.FileName <> Nothing Then
                _seltype = IIf(_svdialog.FilterIndex = 2, "xlsx", "csv")
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        If ExportDataEfak(_svdialog.FileName, _seltype, in_id.Text) Then
            If System.IO.File.Exists(_svdialog.FileName) = True Then
                Try
                    ExportUpdLastExport(in_id.Text)
                Catch ex As Exception
                    logError(ex, True)
                End Try
                MessageBox.Show("Export berhasil!")
                Process.Start(_svdialog.FileName)
            Else
                MessageBox.Show("File export tidak dapat ditemukan", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Export gagal", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_page_first_Click(sender As Object, e As EventArgs) Handles bt_page_first.Click
        If String.IsNullOrWhiteSpace(in_id.Text) Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        If SelectedPageData = 1 Then
            in_page.Text = SelectedPageData
        ElseIf SelectedPageData < 1 Then
            SelectedPageData = 1 : LoadDataGrid(in_id.Text, 1)
        Else
            LoadDataGrid(in_id.Text, 1)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_page_prev_Click(sender As Object, e As EventArgs) Handles bt_page_prev.Click
        If String.IsNullOrWhiteSpace(in_id.Text) Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        If SelectedPageData = 1 Then
            in_page.Text = SelectedPageData
        ElseIf SelectedPageData < 1 Then
            SelectedPageData = 1 : LoadDataGrid(in_id.Text, 1)
        ElseIf SelectedPageData > 1 Then
            LoadDataGrid(in_id.Text, SelectedPageData - 1)
        Else
            LoadDataGrid(in_id.Text, 1)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_page_next_Click(sender As Object, e As EventArgs) Handles bt_page_next.Click
        If String.IsNullOrWhiteSpace(in_id.Text) Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        If SelectedPageData = MaxPageData Then
            in_page.Text = SelectedPageData
        ElseIf SelectedPageData > MaxPageData Then
            SelectedPageData = MaxPageData : LoadDataGrid(in_id.Text, MaxPageData)
        ElseIf SelectedPageData < MaxPageData Then
            LoadDataGrid(in_id.Text, SelectedPageData + 1)
        Else
            LoadDataGrid(in_id.Text, MaxPageData)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_page_last_Click(sender As Object, e As EventArgs) Handles bt_page_last.Click
        If String.IsNullOrWhiteSpace(in_id.Text) Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        If SelectedPageData = MaxPageData Then
            in_page.Text = SelectedPageData
        ElseIf SelectedPageData > MaxPageData Then
            SelectedPageData = MaxPageData : LoadDataGrid(in_id.Text, MaxPageData)
        Else
            LoadDataGrid(in_id.Text, MaxPageData)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    'UI : DGV CHECKBOX
    Private Sub dgv_faktur_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_faktur.CellValueChanged
        If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
            If MainConnection.Connection Is Nothing Then
                Throw New NullReferenceException("Main Connection is empty")
            End If

            Dim _state As Boolean = IIf(dgv_faktur.Rows(e.RowIndex).Cells(0).Value = 1, True, False)

            'If _state Then
            Dim q As String = "UPDATE data_penjualan_efak_list SET e_list_selectstate='{1}' WHERE e_list_kodefaktur='{2}' AND e_list_templateid='{0}'"
            q = String.Format(q, in_id.Text, dgv_faktur.Rows(e.RowIndex).Cells(0).Value, dgv_faktur.Rows(e.RowIndex).Cells(1).Value)

            Using x = MainConnection
                x.Open()
                If x.ConnectionState = ConnectionState.Open Then
                    x.ExecCommand(q)
                End If
            End Using
            'End If
            '    Dim q As String = ""
            '    Dim qck As Boolean = False
            '    Dim _kode As String = dgv_faktur.Rows(e.RowIndex).Cells(1).Value
            '    Dim _value As Integer = 0

            '    If _state Then
            '        Dim _tglpajak As String = CDate(dgv_faktur.Rows(e.RowIndex).Cells(3).Value).ToString("yyyy-MM-dd")
            '        Dim _kodepajak As String = dgv_faktur.Rows(e.RowIndex).Cells(4).Value
            '        Dim _data() As String = {
            '            "'" & _kode & "'",
            '            "'" & _tglpajak & "'",
            '            "'" & _kodepajak & "'",
            '            "'" & loggeduser.user_id & "'"
            '            }
            '        q = "INSERT INTO temp_export_efak(efak_faktur, efak_tanggal, efak_nopajak, efak_user) " _
            '            & "VALUE({0}) ON DUPLICATE KEY UPDATE efak_status=1"
            '        q = String.Format(q, String.Join(",", _data))
            '    Else
            '        q = "UPDATE temp_export_efak SET efak_status=0 WHERE efak_faktur='{0}' AND efak_user='{1}'"
            '        q = String.Format(q, _kode, loggeduser.user_id)
            '    End If

            '    Using x = MainConnection
            '        x.Open()
            '        If x.ConnectionState = ConnectionState.Open Then
            '            Dim i = x.ExecCommand(q)
            '            If i >= 0 Then
            '                qck = True
            '            End If

            '            If Not qck Then
            '                MessageBox.Show("Terjadi kesalahan")
            '                dgv_faktur.Rows(e.RowIndex).Cells(0).Value = IIf(_state = 1, 0, 1)
            '            End If
            '        End If
            '    End Using
        End If
    End Sub

    Private Sub dgv_faktur_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_faktur.CellMouseUp
        If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
            dgv_faktur.EndEdit()
        End If
    End Sub

    Private Sub dgv_faktur_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_faktur.CellDoubleClick
        If e.RowIndex <> -1 Then
            Dim _kode As String = dgv_faktur.Rows(e.RowIndex).Cells(1).Value
            Dim _view As New fr_jual_detail

            _view.doLoadView(_kode)
        End If
    End Sub

    Private Sub dgv_faktur_MouseClick(sender As Object, e As MouseEventArgs) Handles dgv_faktur.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If dgv_faktur.RowCount > 0 Then
                dgv_faktur.ClearSelection()
                dgv_faktur.Rows(dgv_faktur.HitTest(e.Location.X, e.Location.Y).RowIndex).Selected = True
                ctxMn_dgv.Show(dgv_faktur, e.Location)
            End If
        End If
    End Sub

    'UI : CONTEXT MENU
    Private Sub mn_viewdetail_Click(sender As Object, e As EventArgs) Handles mn_viewdetail.Click
        If dgv_faktur.SelectedRows.Count > 0 Then
            Dim _kode As String = dgv_faktur.SelectedRows.Item(0).Cells(1).Value
            Dim _view As New fr_jual_detail

            _view.doLoadView(_kode)
        End If
    End Sub

    Private Sub mn_removefaktur_Click(sender As Object, e As EventArgs) Handles mn_removefaktur.Click
        If String.IsNullOrWhiteSpace(in_id.Text) Then Exit Sub

        If MessageBox.Show("Hapus faktur dari data export?", "Export EFaktur", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Exit Sub

        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim _kode As String = dgv_faktur.SelectedRows.Item(0).Cells(1).Value
        Dim idx As Integer = dgv_faktur.SelectedRows.Item(0).Index
        Dim q As String = ""

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Try
                    q = "UPDATE data_penjualan_efak_list SET e_list_status=9 WHERE e_list_kodefaktur='{0}' AND e_list_templateid='{1}'"
                    q = String.Format(q, _kode, in_id.Text)
                    x.ExecCommand(q)
                    LoadDataGrid(in_id.Text)
                    dgv_faktur.ClearSelection()
                    dgv_faktur.Rows(idx).Selected = True
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Terjadi kesalahan saat melakukan proses penghapusan data." & Environment.NewLine & ex.Message,
                                    "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub
End Class
