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
    Private SearchStr As String = ""
    Public SupplierBased As Boolean = False
    Private SupplierCode As String = ""

    Public Sub setpage(page As TabPage)
        tabpagename = page
        PerformRefresh()
    End Sub

    Public Sub PerformRefresh()
        Dim _id = in_id.Text
        Dim _sw As Boolean = False
        SearchStr = ""
        For Each ctr_sup As Control In {lbl_supplier, in_supplier}
            ctr_sup.Visible = SupplierBased
        Next
        For Each txt As TextBox In {in_id, in_page, in_cari, in_fak, in_dpp, in_ppn, in_supplier, in_ket}
            txt.Clear()
        Next
        For Each datepick As DateTimePicker In {date_periode, date_tgl}
            datepick.Value = Today
        Next
        If Not String.IsNullOrWhiteSpace(_id) Then
            Me.Cursor = Cursors.WaitCursor
            LoadHeader(_id) : LoadDataGrid(_id)
            _sw = True
            Me.Cursor = Cursors.Default
        Else
            dgv_faktur.DataSource = Nothing
        End If
        InputControlSwitch(_sw)
    End Sub

    Private Sub InputControlSwitch(SwEnable As Boolean)
        date_periode.Enabled = SwEnable
        in_ket.Enabled = SwEnable
        in_cari.Enabled = SwEnable
        For Each bt As Button In {bt_simpanbeli, bt_samamasapajak, bt_urutnopajak, bt_savetemplate, bt_deletetemplate, bt_export, bt_export_other, bt_search}
            bt.Enabled = SwEnable
        Next
    End Sub

    'LOAD HEADER
    Private Sub LoadHeader(IdExport As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim q As String = ""

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                'LOAD HEADER
                q = "SELECT efak_tgl, efak_periode, efak_supplierbased, IFNULL(efak_suppliercode,''), IFNULL(efak_ket, '') FROM data_penjualan_efak WHERE efak_id='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, IdExport), CommandBehavior.SingleRow)
                    Dim red = rdx.Read()
                    If red = rdx.HasRows Then
                        in_id.Text = IdExport
                        date_tgl.Value = rdx.Item(0)
                        date_periode.Value = rdx.Item(1)
                        If rdx.Item(2) = 1 Then SupplierCode = rdx.Item(3)
                        in_ket.Text = rdx.Item(4)
                    End If
                End Using

                If SupplierBased Then
                    'LOAD NAMA SUPPLIER
                    q = "SELECT GetMasterNama('supplier', '{0}')"
                    in_supplier.Text = x.ExecScalar(String.Format(q, SupplierCode))
                End If

                'LOAD JUMLAH FAKTUR
                q = "SELECT COUNT(e_list_kodefaktur) FROM data_penjualan_efak_list WHERE e_list_status=1 AND e_list_templateid='{0}'"
                Dim _datacount As Integer = CInt(x.ExecScalar(String.Format(q, IdExport)))
                MaxPageData = CInt(Math.Ceiling(_datacount / 2000))
                in_fak.Text = _datacount.ToString("N0")
                consoleWriteLine(MaxPageData)

                'LOAD TOTAL DPP & PPN
                q = "SELECT TRUNCATE(SUM(ROUND(e_list_det_jumlah*(CASE e_list_jenispajak WHEN 1 THEN (10/11) ELSE 1 END),2)),0) faktur_dpp, " _
                    & "TRUNCATE(SUM(ROUND(e_list_det_jumlah*(CASE e_list_jenispajak WHEN 1 THEN (1-(10/11)) WHEN 2 THEN 0.1 ELSE 0 END),2)),0) faktur_ppn " _
                    & "FROM data_penjualan_efak_list " _
                    & "LEFT JOIN data_penjualan_efak_list_detail ON e_list_det_idlist= e_list_id AND e_list_det_status=1 " _
                    & "WHERE e_list_templateid='{0}' AND e_list_status=1"
                Using rdx = x.ReadCommand(String.Format(q, IdExport))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        Try
                            in_dpp.Text = Decimal.Parse(rdx.Item(0)).ToString("N0")
                            in_ppn.Text = Decimal.Parse(rdx.Item(1)).ToString("N0")
                        Catch ex As Exception
                            logError(ex, False)
                            MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data." & Environment.NewLine & ex.Message,
                                            lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            in_dpp.Text = 0 : in_ppn.Text = 0
                        End Try
                    End If
                End Using
            End If
        End Using
    End Sub

    'LOAD DATAGRID
    Private Sub LoadDataGrid(IdExport As String, Optional PgNumber As Integer = 1, Optional ParamStr As String = "")
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim q As String = ""
        Dim _qwh As String = ""
        Dim col = New List(Of String) From {"e_list_selectstate", "e_list_kodefaktur", "faktur_tanggal_trans", "e_list_kodepajak", "e_list_tglpajak",
                                            "GetMasterNama('custo', faktur_customer) faktur_customer", "GetMasterNama('custonpwp', faktur_customer) faktur_npwp",
                                            "ROUND((CASE e_list_jenispajak WHEN 1 THEN SUM(e_list_det_jumlah)*(10/11) ELSE SUM(e_list_det_jumlah) END),2) faktur_dpp",
                                            "ROUND((CASE e_list_jenispajak WHEN 1 THEN SUM(e_list_det_jumlah)*(1-(10/11)) WHEN 2 THEN SUM(e_list_det_jumlah)*0.1 ELSE 0 END),2) faktur_ppn"}
        Dim _limit As Integer = (PgNumber * 2000) - 2000

        SetupDatagridProp()

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                q = "UPDATE data_penjualan_efak_list LEFT JOIN data_penjualan_faktur ON faktur_kode=e_list_kodefaktur " _
                    & "SET e_list_status=IF(faktur_status<>1,9,1) WHERE e_list_templateid='{0}' AND e_list_status=1"
                x.ExecCommand(String.Format(q, IdExport))

                q = "SELECT {0} FROM data_penjualan_efak_list " _
                    & "LEFT JOIN data_penjualan_efak_list_detail ON e_list_det_idlist= e_list_id AND e_list_det_status=1 " _
                    & "LEFT JOIN data_penjualan_faktur ON e_list_kodefaktur=faktur_kode " _
                    & "WHERE e_list_templateid='{1}' AND e_list_status=1 AND faktur_status=1 {3} GROUP BY e_list_kodefaktur " _
                    & "ORDER BY e_list_tglpajak, faktur_tanggal_trans, e_list_kodefaktur LIMIT {2},2000"
                SearchStr = ParamStr
                If Not String.IsNullOrWhiteSpace(ParamStr) Then
                    ParamStr = mysqlQueryFriendlyStringFeed(ParamStr)
                    ParamStr = Trim(ParamStr).Replace(" ", ".+").Replace("(", "[(]").Replace(")", "[)]")
                    _qwh = String.Join("'" & ParamStr & "'", {" AND(e_list_kodefaktur REGEXP ", " OR GetMasterNama('custo', faktur_customer) REGEXP ",
                                                              " OR e_list_kodepajak REGEXP ", " OR GetMasterNama('custonpwp', faktur_customer) REGEXP ",
                                                              ")"})
                End If

                Using dtx = x.GetDataTable(String.Format(q, String.Join(",", col), IdExport, _limit, _qwh))
                    setDoubleBuffered(dgv_faktur, True)
                    dgv_faktur.AutoGenerateColumns = False
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

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Try
                    q = "UPDATE data_penjualan_efak SET efak_periode='{1:yyyy-MM-01}' WHERE efak_id={0}"
                    x.ExecCommand(String.Format(q, IdExport, periode))

                    q = "UPDATE data_penjualan_efak_list SET e_list_tglpajak = GetEFakDateByPeriode(e_list_kodefaktur, {1}, {2}) " _
                        & "WHERE e_list_templateid='{0}' AND e_list_selectstate=1 AND DATE_FORMAT(e_list_tglpajak,'%m%Y')!='{3}' AND e_list_status=1"
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
                Return False : Exit Function
            End If

            q = "SELECT e_list_kodefaktur FROM data_penjualan_efak_list " _
                & "WHERE e_list_templateid='{0}' AND e_list_selectstate=1 AND e_list_status=1 " _
                & "ORDER BY e_list_tglpajak, e_list_kodepajak, e_list_kodefaktur"
            Using rdx = x.ReadCommand(String.Format(q, IdExport))
                While rdx.Read
                    _FakturList.Add(rdx.Item(0))
                End While
            End Using

            If _FakturList.Count > 0 Then
                If FileType = "xlsx" Then
                    Return exportXlsx("efak", Filename, IdExport, _FakturList)
                ElseIf FileType = "xls" Then
                    Return exportFakeXLS(Filename, IdExport, _FakturList)
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

    'CREATE MYSQL QUERY FOR EXPORTING DATA
    Private Function createQuery(type As String, FakturKode As String, IdExport As String) As String
        Dim q As String = ""

        Select Case type
            Case "exportFK"
                q = "CALL EFak_GetDataFK('{0}', '{1}')" : q = String.Format(q, FakturKode, IdExport)

            Case "exportLT"
                q = String.Empty

            Case "exportOF"
                If Not String.IsNullOrWhiteSpace(FakturKode) Then q = "CALL EFak_GetDataOF_v2('{1}', '{0}')" : q = String.Format(q, FakturKode, IdExport)
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
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    For Each kode As String In kode_faktur
                        contain.Add(x.GetDataTable(createQuery("exportFK", kode, IdExport)).ToCsv(False, vbCrLf, fielddelimiter))
                        contain.Add(x.GetDataTable(createQuery("exportOF", kode, IdExport)).ToCsv(False, vbCrLf, fielddelimiter))
                    Next
                Else
                    MessageBox.Show("Tidak dapat terhubung ke database.", "Export E Faktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False : Exit Function
                End If
            End Using

            System.IO.File.WriteAllText(fileLoc, String.Join(rowdelimiter, contain))
            Return System.IO.File.Exists(fileLoc)
        Catch ex As Exception
            logError(ex, True)
            MessageBox.Show("ERROR. Terjadi kesalahan saat melakukan export" & vbCrLf & ex.Message, "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    'EXPORT XLS A.K.A CSV FILE WITH XLS FILE TYPE
    Private Function exportFakeXLS(fileLoc As String, IdExport As String, kode_faktur As List(Of String), Optional fielddelimiter As String = ";",
                           Optional rowdelimiter As String = ControlChars.NewLine) As Boolean
        Dim _retsuc As Boolean = False
        Dim contain As New List(Of String)

        Try
            contain.Add(String.Join(fielddelimiter, colheadr_FK))
            contain.Add(String.Join(fielddelimiter, colheadr_LT))
            contain.Add(String.Join(fielddelimiter, colheadr_OF))
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    For Each kode As String In kode_faktur
                        contain.Add(x.GetDataTable(createQuery("exportFK", kode, IdExport)).ToCsv(False, vbCrLf, fielddelimiter))
                        contain.Add(x.GetDataTable(createQuery("exportOF", kode, IdExport)).ToCsv(False, vbCrLf, fielddelimiter))
                    Next
                Else
                    MessageBox.Show("Tidak dapat terhubung ke database.", "Export E Faktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False : Exit Function
                End If
            End Using

            System.IO.File.WriteAllText(fileLoc, String.Join(rowdelimiter, contain))
            Return System.IO.File.Exists(fileLoc)
        Catch ex As Exception
            logError(ex, True)
            MessageBox.Show("ERROR. Terjadi kesalahan saat melakukan export" & vbCrLf & ex.Message, "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


    'EXPORT XLSX
    Private Function exportXlsx(ExportType As String, fileloc As String, IdExport As String, kode_faktur As List(Of String),
                                Optional filename As String = Nothing) As Boolean
        Dim _retsuc As Boolean = False
        Dim contain As New List(Of String)
        Dim dt_fk As New DataTable
        Dim dt_of As New DataTable
        ExportType = LCase(ExportType)
        If Not {"efak", "jualefak", "jualmaster"}.Contains(ExportType) Then
            MessageBox.Show("Tipe Export tidak sesuai.", "Export EFaktur XLXS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If filename = Nothing Then
            filename = Strings.Replace(Strings.Replace(fileloc, System.IO.Path.GetDirectoryName(fileloc), ""), ".xlsx", "")
            If filename = "" Then
                If ExportType = "efak" Then
                    filename = "Export EFaktur "
                ElseIf ExportType = "jualefak" Then
                    filename = "Export Data Penjualan - Efaktur "
                ElseIf ExportType = "jualmaster" Then
                    filename = "Export Data Master Penjualan - Efaktur "
                End If
                filename += date_periode.Value.ToString("MMMM yyyy")
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
                Using x = MainConnection
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        For Each kode As String In kode_faktur
                            If ExportType = "efak" Then
                                dt_fk = x.GetDataTable(createQuery("exportFK", kode, IdExport))
                                dt_of = x.GetDataTable(createQuery("exportOF", kode, IdExport))
                                For i = 0 To dt_fk.Columns.Count - 1
                                    wrksht.Cells(rows, i + 1).Value = dt_fk.Rows(0).ItemArray(i)
                                Next
                                rows += 1
                            Else
                                dt_of = x.GetDataTable(createQuery(IIf(ExportType = "jualefak", "exportJualEfak", "exportJualMaster"), kode, IdExport))
                            End If
                            For Each objkrows As DataRow In dt_of.Rows
                                For i = 0 To dt_of.Columns.Count - 1
                                    wrksht.Cells(rows, i + 1).Value = objkrows.ItemArray(i)
                                Next
                                rows += 1
                            Next
                        Next
                    Else
                        MessageBox.Show("Tidak dapat terhubung ke database.", "Export E Faktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False : Exit Function
                    End If
                End Using
                xls.SaveAs(New FileInfo(fileloc & filename & ".xlsx"))

                Return System.IO.File.Exists(fileloc & filename & ".xlsx")
            End Using
        Catch ex As Exception
            logError(ex, True)
            MessageBox.Show("ERROR. Terjadi kesalahan saat melakukan export" & vbCrLf & ex.Message, "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function exportDataPenjualan(Filename As String, ExportType As String, IdExport As String, Periode As Date, ByRef _OutputDir As String) As Boolean
        Try
            Dim q As String = ""
            Dim _ColHeader As New List(Of String)
            Dim _Title As New List(Of String)

            ExportType = LCase(ExportType)

            If Not {"efak", "master"}.Contains(ExportType) Then Throw New Exception("Kode jenis export tidak sesuai.")

            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    q = "CALL EFak_GetDataJual('{0}', {1})"
                    q = String.Format(q, ExportType, IdExport)

                    _ColHeader.AddRange({"KodeFaktur", "Tgl", "JenisPajak", "Tgl.Pajak", "NomorPajak",
                                             "KodeSalesman", "Salesman", "KodeCustomer", "NamaCustomer", "KodeGudang", "NamaGudang",
                                             "KodeBarang", "NamaBarang", "Qty", "SatuanJual", "Hargajual", "Subtotal", "JumlahDiskon", "JumlahJual",
                                             "DPP", "PPN", "Status"})
                    If ExportType = "efak" Then
                        _Title.AddRange({"DATA PENJUALAN EXPORT EFAKTUR ", "PERIODE " & UCase(Periode.ToString("MMMM yyyy"))})
                    Else
                        _Title.AddRange({"DATA MASTER PENJUALAN EXPORT EFAKTUR ", "PERIODE " & UCase(Periode.ToString("MMMM yyyy"))})
                    End If

                    Return ExportExcel(_ColHeader, New List(Of DataTable) From {x.GetDataTable(q)}, _Title, Filename, "xlsx", _OutputDir)
                Else
                    MessageBox.Show("Tidak dapat terhubung ke database.", "Export Efaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End Using
        Catch ex As Exception
            logError(ex, True)
            MessageBox.Show("ERROR. Terjadi kesalahan saat melakukan export" & vbCrLf & ex.Message, "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
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

    'UI : CLOSE
    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        in_id.Clear()
        Me.PerformRefresh()
        main.tabcontrol.TabPages.Remove(tabpagename)
    End Sub

    'UI : BUTTON
    Private Sub bt_loadtemplate_Click(sender As Object, e As EventArgs) Handles bt_loadtemplate.Click
        Using x As New fr_search_export
            Dim _ret As String = ""
            If SupplierBased Then
                x.DoLoadDialog_Supplier()
            Else
                x.DoLoadDialog()
            End If
            _ret = x.ReturnId

            Me.Cursor = Cursors.WaitCursor
            If Not String.IsNullOrWhiteSpace(_ret) Then
                LoadHeader(_ret) : LoadDataGrid(_ret)
                InputControlSwitch(True)
            End If
            Me.Cursor = Cursors.Default
        End Using
    End Sub

    Private Sub bt_createtemplate_Click(sender As Object, e As EventArgs) Handles bt_createtemplate.Click
        Using x As New fr_newexport
            Dim _ret As String = ""
            If SupplierBased Then
                x.DoLoadDialog_supplier()
            Else
                x.DoLoadDialog()
            End If
            _ret = x.ReturnId
            Me.Cursor = Cursors.WaitCursor
            If Not String.IsNullOrWhiteSpace(_ret) Then
                LoadHeader(_ret) : LoadDataGrid(_ret)
                InputControlSwitch(True)
            End If
            Me.Cursor = Cursors.Default
        End Using
    End Sub

    Private Sub bt_refresh_Click(sender As Object, e As EventArgs) Handles bt_refresh.Click
        Me.PerformRefresh()
    End Sub

    Private Sub bt_savetemplate_Click(sender As Object, e As EventArgs) Handles bt_savetemplate.Click
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim q As String = ""

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                q = "UPDATE data_penjualan_efak SET efak_tgl='{1}', efak_periode='{2}', efak_ket='{3}' WHERE efak_id='{0}'"
                q = String.Format(q, in_id.Text, date_tgl.Value.ToString("yyyy-MM-dd"), date_periode.Value.ToString("yyyy-MM-01"),
                                  mysqlQueryFriendlyStringFeed(in_ket.Text))
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
        Dim _resMsg As DialogResult = DialogResult.No

        If String.IsNullOrWhiteSpace(in_id.Text) Then Exit Sub
        _resMsg = MessageBox.Show("Hapus data export efaktur?", lbl_judul.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _resMsg = DialogResult.No Then Exit Sub

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                q = "UPDATE data_penjualan_efak SET efak_status=9, efak_removed=NOW(), efak_removed_by='{1}' WHERE efak_id='{0}'"
                If x.TransactCommand(New List(Of String) From {String.Format(q, in_id.Text, loggeduser.user_id)}) Then
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
            If SupplierBased Then
                x.DoLoadDialog(in_id.Text, SupplierCode)
            Else
                x.DoLoadDialog(in_id.Text)
            End If
            If x.ReturnValue Then LoadDataGrid(in_id.Text)
        End Using
    End Sub

    Private Sub bt_urutnopajak_Click(sender As Object, e As EventArgs) Handles bt_urutnopajak.Click
        If String.IsNullOrWhiteSpace(in_id.Text) Then Exit Sub

        Dim KodePajak As String = ""
        Dim TicketQty As Integer = 0
        Me.Cursor = Cursors.WaitCursor
        Using x = New fr_urutnofaktur
            x.DoLoadDialog(in_id.Text)
            If x.ReturnValue Then
                LoadDataGrid(in_id.Text, in_page.Text)
            End If
        End Using
        Me.Cursor = Cursors.Default
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

        _svdialog.Filter = "CSV files (*.csv)|*.csv|Excel files (*.xlsx)|*.xlsx|Excel 97-2003 files (*.xls)|*.xls|All files (*.*)|*.*"
        _svdialog.FilterIndex = 1
        _svdialog.AddExtension = True
        _svdialog.RestoreDirectory = True
        _svdialog.DefaultExt = ".csv"
        _svdialog.FileName = _svdialog.FileName & "EXPORT EFAKTUR " & UCase(date_periode.Value.ToString("MMMM yyyy"))
        If _svdialog.ShowDialog = DialogResult.OK Then
            If _svdialog.FileName <> Nothing Then
                Select Case _svdialog.FilterIndex
                    Case 1 : _seltype = "csv"
                    Case 2 : _seltype = "xlsx"
                    Case 3 : _seltype = "xls"
                    Case Else : _seltype = "csv"
                End Select
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
                MessageBox.Show(String.Format("Export berhasil EFaktur {0} berhasil!", UCase(date_periode.Value.ToString("MMMM yyyy"))),
                                              "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Process.Start(_svdialog.FileName)
            Else
                MessageBox.Show("File export tidak dapat ditemukan", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Export gagal", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_export_other_Click(sender As Object, e As EventArgs) Handles bt_export_other.Click
        Dim _x As Integer = bt_export_other.Location.X - (ctxMn_export.Width - sender.Width)
        Dim _y As Integer = bt_export_other.Location.Y + bt_export_other.Height
        consoleWriteLine(_x & ":" & _y)
        ctxMn_export.Show(pnl_container, _x, _y)
    End Sub

    Private Sub bt_search_Click(sender As Object, e As EventArgs) Handles bt_search.Click
        If Not String.IsNullOrWhiteSpace(in_id.Text) Then
            Me.Cursor = Cursors.WaitCursor
            SearchStr = in_cari.Text
            LoadDataGrid(in_id.Text, 1, SearchStr)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub bt_page_prev_Click(sender As Object, e As EventArgs) Handles bt_page_prev.Click, bt_page_first.Click
        If String.IsNullOrWhiteSpace(in_id.Text) Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        in_cari.Text = SearchStr
        If SelectedPageData = 1 Then
            in_page.Text = SelectedPageData
        ElseIf SelectedPageData > 1 And sender.Name = "bt_page_prev" Then
            LoadDataGrid(in_id.Text, SelectedPageData - 1, SearchStr)
        Else
            LoadDataGrid(in_id.Text, 1, SearchStr)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_page_next_Click(sender As Object, e As EventArgs) Handles bt_page_next.Click, bt_page_last.Click
        If String.IsNullOrWhiteSpace(in_id.Text) Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        in_cari.Text = SearchStr
        If SelectedPageData = MaxPageData Then
            in_page.Text = SelectedPageData
        ElseIf SelectedPageData < MaxPageData And sender.Name = "bt_page_next" Then
            LoadDataGrid(in_id.Text, SelectedPageData + 1, SearchStr)
        Else
            LoadDataGrid(in_id.Text, MaxPageData, SearchStr)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    'UI : DGV CHECKBOX
    Private Sub dgv_faktur_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_faktur.CellValueChanged
        If e.ColumnIndex = 0 And e.RowIndex > -1 Then
            If MainConnection.Connection Is Nothing Then
                Throw New NullReferenceException("Main Connection is empty")
            End If

            Dim _state As Boolean = IIf(dgv_faktur.Rows(e.RowIndex).Cells(0).Value = 1, True, False)

            Dim q As String = "UPDATE data_penjualan_efak_list SET e_list_selectstate='{1}' WHERE e_list_kodefaktur='{2}' AND e_list_templateid='{0}'"
            q = String.Format(q, in_id.Text, dgv_faktur.Rows(e.RowIndex).Cells(0).Value, dgv_faktur.Rows(e.RowIndex).Cells(1).Value)

            Using x = MainConnection
                x.Open()
                If x.ConnectionState = ConnectionState.Open Then x.ExecCommand(q)
            End Using
        End If
    End Sub

    Private Sub dgv_faktur_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_faktur.CellMouseUp
        If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
            dgv_faktur.EndEdit()
        End If
    End Sub

    Private Sub dgv_faktur_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_faktur.CellDoubleClick
        If e.RowIndex <> -1 Then
            Dim _kode As String = dgv_faktur.SelectedRows.Item(0).Cells(1).Value
            Dim _det As New fr_efak_detail
            Me.Cursor = Cursors.WaitCursor
            _det.doLoadView(_kode, in_id.Text)
            Me.Cursor = Cursors.Default
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

    Private Sub dgv_faktur_Scroll(sender As Object, e As ScrollEventArgs) Handles dgv_faktur.Scroll
        ctxMn_dgv.Close()
    End Sub

    'UI : CONTEXT MENU
    Private Sub mn_viewdetail_Click(sender As Object, e As EventArgs) Handles mn_viewdetail.Click
        If dgv_faktur.SelectedRows.Count > 0 Then
            Dim _kode As String = dgv_faktur.SelectedRows.Item(0).Cells(1).Value
            Dim _det As New fr_efak_detail
            Me.Cursor = Cursors.WaitCursor
            _det.doLoadView(_kode, in_id.Text)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub mn_editdetail_Click(sender As Object, e As EventArgs) Handles mn_editdetail.Click
        If dgv_faktur.SelectedRows.Count > 0 Then
            Dim _kode As String = dgv_faktur.SelectedRows.Item(0).Cells(1).Value
            Dim _det As New fr_efak_detail
            Me.Cursor = Cursors.WaitCursor
            _det.doLoadEdit(_kode, in_id.Text, loggeduser.admin_pc)
            Me.Cursor = Cursors.Default
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
                    dgv_faktur.Rows(idx - 1).Selected = True
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Terjadi kesalahan saat melakukan proses penghapusan data." & Environment.NewLine & ex.Message,
                                    "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub mn_export_efak_Click(sender As Object, e As EventArgs) Handles mn_export_efak.Click
        If Not String.IsNullOrWhiteSpace(in_id.Text) Then bt_export.PerformClick()
    End Sub

    Private Sub mn_export_jual_Click(sender As Object, e As EventArgs) Handles mn_export_jual.Click, mn_exportjual_master.Click
        If String.IsNullOrWhiteSpace(in_id.Text) Then Exit Sub

        Dim _svdialog As New SaveFileDialog
        Dim _OutputDir As String = ""
        Dim _ExportType As String = ""

        _svdialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        _svdialog.FilterIndex = 1
        _svdialog.AddExtension = True
        _svdialog.RestoreDirectory = True
        _svdialog.DefaultExt = ".xlsx"
        If sender.Name = "mn_export_jual" Then
            _ExportType = "efak"
            _svdialog.FileName = _svdialog.FileName & "EXPORT DATA PENJUALAN - EFAKTUR " & UCase(date_periode.Value.ToString("MMMM yyyy"))
        Else
            _ExportType = "master"
            _svdialog.FileName = _svdialog.FileName & "EXPORT DATA MASTER PENJUALAN - EFAKTUR " & UCase(date_periode.Value.ToString("MMMM yyyy"))
        End If
        If _svdialog.ShowDialog = DialogResult.OK Then
            If _svdialog.FileName <> Nothing Then
                Me.Cursor = Cursors.WaitCursor
                If exportDataPenjualan(_svdialog.FileName, _ExportType, in_id.Text, date_periode.Value, _OutputDir) Then
                    If System.IO.File.Exists(_OutputDir) = True Then
                        MessageBox.Show("Export Data Sukses", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Process.Start(_OutputDir)
                    Else
                        MessageBox.Show("File tidak dapat ditemukan", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Export data gagal.", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    'UI : TEXTBOX
    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If Not String.IsNullOrWhiteSpace(in_id.Text) Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True : bt_search.PerformClick()
            End If
        End If
    End Sub
End Class
