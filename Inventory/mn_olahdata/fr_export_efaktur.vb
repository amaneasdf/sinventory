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


    Public Sub setpage(page As TabPage)
        tabpagename = page
        consoleWriteLine("pg" & page.Name.ToString)
        consoleWriteLine("pgset" & tabpagename.Name.ToString)
    End Sub

    Public Sub performRefresh()

    End Sub

    Private Function createQuery(type As String, Optional fk_kode As String = Nothing) As String
        Dim q As String = ""
        Dim col As New List(Of String)
        Dim _tglawal As String = date_tglawal.Value.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = date_tglakhir.Value.ToString("yyyy-MM-dd")
        Dim _qwhr As String = ""
        Dim whr As New List(Of String)


        Select Case type
            Case "dgv"
                col.AddRange({"0 faktur_select", "faktur_kode", "faktur_tanggal_trans", "faktur_pajak_tanggal", "faktur_pajak_no ", "customer_nama",
                              "ROUND((CASE faktur_ppn_jenis WHEN 1 THEN faktur_netto*(10/11) ELSE faktur_netto END),2) faktur_dpp",
                              "ROUND((CASE faktur_ppn_jenis WHEN 1 THEN faktur_netto*(1-(10/11)) WHEN 2 THEN faktur_netto*0.1 ELSE 0 END),2) faktur_ppn"})

                q = "SELECT {0} FROM data_penjualan_faktur " _
                    & "LEFT JOIN data_customer_master ON customer_kode=faktur_customer " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' {3}"

                _qwhr = ""

                q = String.Format(q, String.Join(",", col), _tglawal, _tglakhir, _qwhr)
            Case "exportFK"
                Dim kodefaktur As New List(Of String)
                q = "CALL EFak_GetDataFK('{0}')"

                q = String.Format(q, fk_kode)

            Case "exportOF"
                If fk_kode <> Nothing Then
                    q = "CALL EFak_GetDataOF('{0}')"
                    q = String.Format(q, fk_kode)
                End If
        End Select
        Return q
    End Function

    'GET FAKTUR
    Public Sub loadFaktur(Optional keepSelected As Boolean = False)
        'If keepSelected = True Then
        '    cacheSelectedFak()
        'End If

        dgv_faktur.AutoGenerateColumns = False
        For Each xa As DataGridViewColumn In {faktur_dpp, faktur_ppn}
            xa.DefaultCellStyle = dgvstyle_currency
        Next
        dgv_faktur.DataSource = getDataTablefromDB(createQuery("dgv"))
        dgv_faktur.Columns(0).ReadOnly = False

        'If keepSelected = True Then

        'End If

        'If ck_faktur_all.CheckState = CheckState.Checked Then
        '    For Each rows As DataGridViewRow In dgv_faktur.Rows
        '        rows.Cells(0).Value = 1
        '    Next
        'Else
        '    For Each rows As DataGridViewRow In dgv_faktur.Rows
        '        rows.Cells(0).Value = 0
        '    Next
        ck_faktur_all.CheckState = CheckState.Unchecked
        'End If
    End Sub

    Private Sub cacheSelectedFak()
        cacheSelectFakTemp.Clear()
        For Each rows As DataGridViewRow In dgv_faktur.Rows
            If rows.Cells(0).Value = 1 Then
                cacheSelectFakTemp.Add(rows.Cells(0).Value)
            End If
        Next
    End Sub

    'EXPORT
    Private Function exportData(fileLoc As String, filetype As String, Optional fielddelimiter As String = ";",
                                Optional rowdelimiter As String = ControlChars.NewLine) As Boolean
        Dim dt_faktur As New DataTable
        Dim dt_objek As New DataTable
        Dim _retsuc As Boolean = False
        Dim kode_faktur As New List(Of String)
        For Each rows As DataGridViewRow In dgv_faktur.Rows
            If rows.Cells(0).Value = 1 Then
                kode_faktur.Add(rows.Cells(1).Value)
            End If
        Next

        filetype = LCase(filetype)


        Select Case filetype
            Case "xlsx"
                _retsuc = exportXlsx(fileLoc, kode_faktur)
            Case "csv"
                _retsuc = exportCSV(fileLoc, kode_faktur)
            Case Else
                _retsuc = False
        End Select

        Return _retsuc
    End Function

    'EXPORT CSV
    Private Function exportCSV(fileLoc As String, kode_faktur As List(Of String), Optional fielddelimiter As String = ";",
                               Optional rowdelimiter As String = ControlChars.NewLine) As Boolean
        Dim _retsuc As Boolean = False
        Dim contain As New List(Of String)

        Try
            contain.Add(String.Join(fielddelimiter, colheadr_FK))
            contain.Add(String.Join(fielddelimiter, colheadr_LT))
            contain.Add(String.Join(fielddelimiter, colheadr_OF))
            For Each kode As String In kode_faktur
                contain.Add(getDataTablefromDB(createQuery("exportFK", kode), True).ToCsv(False, vbCrLf, fielddelimiter))
                contain.Add(getDataTablefromDB(createQuery("exportOF", kode), True).ToCsv(False, vbCrLf, fielddelimiter))
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
    Private Function exportXlsx(fileloc As String, kode_faktur As List(Of String), Optional filename As String = Nothing) As Boolean
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
                    dt_fk = getDataTablefromDB(createQuery("exportFK", kode), True)
                    dt_of = getDataTablefromDB(createQuery("exportOF", kode), True)
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

    'CHANGE TAX DATE
    Private Sub changeTaxDate(periode As Date)
        Dim q As String = ""
        Dim _tglawal As String = periode.ToString("yyyy-MM-01")
        Dim _tglakhir As String = DateSerial(periode.Year, periode.Month + 1, 0).ToString("yyyy-MM-01")
        Dim queryArr As New List(Of String)
        Dim qCk As Boolean = False
        Dim listkode As New List(Of String)

        Me.Cursor = Cursors.WaitCursor

        q = "UPDATE data_penjualan_faktur SET faktur_pajak_tanggal='{0}' WHERE faktur_kode='{1}'"
        For Each rows As DataGridViewRow In dgv_faktur.Rows
            If rows.Cells(0).Value = 1 Then
                Dim _setdate As Date = Today
                Dim month As Integer = CDate(rows.Cells("faktur_tgl_pajak").Value).Month
                Dim year As Integer = CDate(rows.Cells("faktur_tgl_pajak").Value).Year
                If month < periode.Month And year = periode.Year Then
                    _setdate = DateSerial(periode.Year, periode.Month, 1)
                ElseIf month > periode.Month And year = periode.Month Then
                    _setdate = DateSerial(periode.Year, periode.Month + 1, 0)
                ElseIf month > periode.Month And year < periode.Month Then
                    _setdate = DateSerial(periode.Year, periode.Month, 1)
                Else
                    _setdate = Nothing
                End If
                If Not IsNothing(_setdate) Then
                    queryArr.Add(String.Format(q, _setdate.ToString("'yyyy-MM-dd'"), rows.Cells(1).Value))
                    listkode.Add(rows.Cells(1).Value)
                End If
            End If
        Next

        qCk = startTrans(queryArr)

        If qCk = True Then
            MessageBox.Show("Periode Pajak berhasil di ubah.", "Export EFaktur")
            date_tglawal.Value = DateSerial(periode.Year, periode.Month, 1)
            date_tglakhir.Value = DateSerial(periode.Year, periode.Month + 1, 0)
            loadFaktur()
            ck_faktur_all.CheckState = CheckState.Checked
        End If

        Me.Cursor = Cursors.Default
    End Sub

    'INSERT NO PAJAK
    Private Sub insertNoPajak(startstring As String, FakCount As Integer)
        Dim kodepajak As String()
        Dim kodetrans As String = ""
        Dim tahun As String = ""
        Dim nourut As Integer = 0
        Dim nourut2 As Integer = 0

        kodepajak = startstring.Split("-")
        kodetrans = SplitText(kodepajak(0), ".", 0)
        tahun = SplitText(kodepajak(1), ".", 0)
        nourut = SplitText(kodepajak(1), ".", 1)
        nourut2 = SplitText(kodepajak(0), ".", 1)

        Dim q As String = "UPDATE data_penjualan_faktur SET faktur_pajak_no='{0}' WHERE faktur_kode='{1}'"
        Dim queryArr As New List(Of String)

        Dim i As Integer = 0
        For Each rows As DataGridViewRow In dgv_faktur.Rows
            If rows.Cells(0).Value = 1 Then
                Dim _kodeinput As String = ""

                _kodeinput = kodetrans & "." & nourut2.ToString.PadLeft(3, "0") & "-" & tahun & "." & nourut.ToString.PadLeft(8, "0")

                queryArr.Add(String.Format(q, _kodeinput, rows.Cells(1).Value))
                rows.Cells(4).Value = _kodeinput
                i += 1

                If i = FakCount Then
                    Exit For
                Else
                    nourut += 1
                    If nourut > 99999999 Then
                        nourut = 0
                        nourut2 += 1
                    End If
                End If
            End If
        Next

        op_con()
        startTrans(queryArr)
    End Sub

    'REMOVE NO PAJAK
    Private Sub kosongNoPajak(Optional listKode As List(Of String) = Nothing)
        Dim q As String = " UPDATE data_penjualan_faktur SET faktur_pajak_no='' WHERE faktur_kode IN ({0})"
        'Dim qCk As Boolean = False
        Dim qCk As Integer = 0

        If IsNothing(listKode) Then
            listKode = New List(Of String)
            For Each rows As DataGridViewRow In dgv_faktur.Rows
                If rows.Cells(0).Value = 0 Then
                    listKode.Add(rows.Cells(1).Value)
                    'rows.Cells(4).Value = ""
                End If
            Next
        End If

        Dim _inlistkode As New List(Of String)
        For i = 0 To listKode.Count - 1
            _inlistkode.Add("'" & listKode(i) & "'")
        Next

        Using x = MainConnection : x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                qCk = x.ExecCommand(String.Format(q, String.Join(",", _inlistkode)))
            End If
        End Using
        'qCk = commnd(String.Format(q, String.Join(",", _inlistkode)))

        If qCk > 0 Then
            For Each rows As DataGridViewRow In dgv_faktur.Rows
                If listKode.Contains(rows.Cells(1).Value) Then
                    rows.Cells(4).Value = ""
                End If
            Next
            MessageBox.Show("No.Pajak berhasil dikosongkan", "Export EFaktur", MessageBoxButtons.OK)
        Else
            MessageBox.Show("No.Pajak gagal dikosongkan", "Export EFaktur", MessageBoxButtons.OK)
        End If
    End Sub

    'CLOSE
    Private Sub bt_close_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_close_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        main.tabcontrol.TabPages.Remove(tabpagename)
    End Sub

    'BUTTON
    Private Sub bt_export_Click(sender As Object, e As EventArgs) Handles bt_export.Click
        Dim _respond As Boolean = False
        Dim _svdialog As New SaveFileDialog
        Dim _outputdir As String = ""
        Dim _filename As String = ""
        Dim _seltype As String = "csv"

        _svdialog.Filter = "CSV files (*.csv)|*.csv|Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        _svdialog.FilterIndex = 1
        _svdialog.RestoreDirectory = True
        _svdialog.DefaultExt = ".csv"
        _svdialog.FileName = _svdialog.FileName & "EXPORT EFAKTUR"
        If _svdialog.ShowDialog = DialogResult.OK Then
            If _svdialog.FileName <> Nothing Then
                _outputdir = IO.Path.GetDirectoryName(_svdialog.FileName)
                _filename = Strings.Replace(_svdialog.FileName, _outputdir, "")
                _seltype = IIf(_svdialog.FilterIndex = 2, "xlsx", "csv")
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If

        If exportData(_svdialog.FileNames(0).ToString, _seltype) = True Then
            If System.IO.File.Exists(_svdialog.FileName) = True Then
                MessageBox.Show("Export berhasil!")
                Process.Start(_svdialog.FileName)
            Else
                MessageBox.Show("File export tidak dapat ditemukan", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Export gagal", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        loadFaktur()
    End Sub

    Private Sub bt_urutnopajak_Click(sender As Object, e As EventArgs) Handles bt_urutnopajak.Click
        If String.IsNullOrWhiteSpace(in_nopajak.Text) Then
            MessageBox.Show("Masukan No. Pajak awal terlebih dulu", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            If Not in_nopajak.Text Like "###.###-##.########" Then
                MessageBox.Show("Format No. Pajak tidak sesuai", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If

        Dim _tempnopajak As String = ""
        Dim _tempjmlpajak As Integer = 0
        Dim _msgRes As DialogResult = MessageBox.Show("Urutkan No. Pajak Transaksi yang dipilih?", "Export EFaktur", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _tempjmlpajak = 0 Then
            For Each x As DataGridViewRow In dgv_faktur.Rows
                If x.Cells(0).Value = 1 Then
                    _tempjmlpajak += 1
                End If
            Next
        End If

        If in_jmlpajak.Value < _tempjmlpajak Then
            _msgRes = MessageBox.Show("Jumlah Transaksi yang dipilih lebih banyak dibandingkan jumlah nomor faktur." & Environment.NewLine _
                                      & "Lanjutkan proses?", "Export EFaktur", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If _msgRes = DialogResult.No Then
                Exit Sub
            End If
        End If

        _tempnopajak = in_nopajak.Text

        If _tempnopajak <> "" Then
            insertNoPajak(_tempnopajak, _tempjmlpajak)
        End If
    End Sub

    Private Sub bt_kosongnopajak_Click(sender As Object, e As EventArgs) Handles bt_kosongnopajak.Click
        Dim _msgRes As DialogResult = MessageBox.Show("Kosongkan No. Pajak dari Transaksi yang tidak dipilih?", "Export EFaktur", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If _msgRes = DialogResult.Yes Then
            kosongNoPajak()
        End If
    End Sub

    Private Sub bt_samamasapajak_Click(sender As Object, e As EventArgs) Handles bt_samamasapajak.Click
        Dim _msgText As String = "Samakan periode pajak untuk transaksi yang dipilih?" & Environment.NewLine _
                                 & "Tgl pajak ransaksi sebelum dan sesudah periode terpilih akan di update ke awal dan akhir periode terpilih"
        Dim _msgRes As DialogResult = MessageBox.Show(_msgText, "Export EFaktur", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If _msgRes = DialogResult.Yes Then
            changeTaxDate(dt_periodeselect.Value)
        End If
    End Sub

    'UI : NUMERIC
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_jmlpajak.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_jmlpajak.Enter
        numericLostFocus(sender, "N0")
    End Sub

    'UI : DGV CHECKBOX
    Private Sub ck_faktur_all_CheckStateChanged(sender As Object, e As EventArgs) Handles ck_faktur_all.CheckedChanged
        If ck_faktur_all.CheckState = CheckState.Checked Then
            For Each rows As DataGridViewRow In dgv_faktur.Rows
                rows.Cells(0).Value = 1
            Next
        ElseIf ck_faktur_all.CheckState = CheckState.Unchecked Then
            For Each rows As DataGridViewRow In dgv_faktur.Rows
                rows.Cells(0).Value = 0
            Next
        End If
    End Sub

    Private Sub dgv_faktur_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_faktur.CellValueChanged
        If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
            Dim count As Integer = 0
            For Each rows As DataGridViewRow In dgv_faktur.Rows
                If rows.Cells(0).Value = 1 Then
                    count += 1
                End If
            Next

            If count = 0 Then
                ck_faktur_all.CheckState = CheckState.Unchecked
            ElseIf count > 0 And dgv_faktur.Rows.Count > count Then
                ck_faktur_all.CheckState = CheckState.Indeterminate
            ElseIf count > 0 And count = dgv_faktur.Rows.Count Then
                ck_faktur_all.CheckState = CheckState.Checked
            End If
        End If
    End Sub

    Private Sub dgv_faktur_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_faktur.CellMouseUp
        If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
            dgv_faktur.EndEdit()
        End If
    End Sub

    'UI : CHECKBOX
    Private Sub ck_period_CheckedChanged(sender As Object, e As EventArgs) Handles ck_period.CheckedChanged
        If ck_period.CheckState = CheckState.Checked Then
            bt_samamasapajak.Enabled = True
            dt_periodeselect.Enabled = True
        Else
            bt_samamasapajak.Enabled = False
            dt_periodeselect.Enabled = False
        End If
    End Sub
End Class
