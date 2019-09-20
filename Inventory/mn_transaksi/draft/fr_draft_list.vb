Public Class fr_draft_list
    Public tabpagename As TabPage

    Private MaxPageData As Integer = 1
    Private SelectedPageData As Integer = 1
    Private SelectedDate1 As Date = Today
    Private SelectedDate2 As Date = Today
    Private SearchString As String = ""

    Private tblstatus As String = ""
    Private _limit As Integer = LimitDataPerPage

    'KEYSHORTCUT
    Protected Overrides Function ProcessKeyPreview(ByRef m As Message) As Boolean
        If m.Msg = &H100 Or m.Msg = &H101 Then  'WM_KEYDOWN / WM_KEYUP
            Dim key As Keys = m.WParam
            If key = Keys.F5 Then
                PerformRefresh() : Return True
            ElseIf key = Keys.N And My.Computer.Keyboard.CtrlKeyDown Then
                AddData() : Return True
            ElseIf key = Keys.F And My.Computer.Keyboard.CtrlKeyDown Then
                in_cari.Focus() : Return True
            ElseIf key = Keys.O And My.Computer.Keyboard.CtrlKeyDown Then
                If dgv_list.SelectedRows.Count > 0 Then
                    EditData(dgv_list.SelectedRows.Item(0).Cells(0).Value) : Return True
                End If
            End If
        End If

        Return MyBase.ProcessKeyPreview(m)
    End Function

    'SETUP PAGE CONTROL
    Public Sub SetPage(page As TabPage)
        tabpagename = page
        MenuSw() : setDatePicker()
        SetDataGrid(DataTypeSelector() & "_list")
        LoadDataGrid("", 1, date_tglawal.Value, date_tglakhir.Value)
        SplitContainer1.SplitterDistance = SplitContainer1.Width * 0.5
    End Sub

    'SETUP DATE PICKER
    Private Sub setDatePicker()
        RemoveHandler date_tglawal.ValueChanged, AddressOf date_tglawal_ValueChanged
        RemoveHandler date_tglakhir.ValueChanged, AddressOf date_tglakhir_ValueChanged
        date_tglawal.MaxDate = selectperiode.tglakhir
        date_tglakhir.MinDate = selectperiode.tglawal
        date_tglawal.Value = DateSerial(selectperiode.tglawal.Year, selectperiode.tglawal.Month, selectperiode.tglawal.Day)
        If selectperiode.tglakhir < Today Then
            date_tglakhir.Value = DateSerial(selectperiode.tglakhir.Year, selectperiode.tglakhir.Month + 1, 0)
        Else
            date_tglakhir.Value = DateSerial(Today.Year, Today.Month + 1, 0)
        End If
        AddHandler date_tglawal.ValueChanged, AddressOf date_tglawal_ValueChanged
        AddHandler date_tglakhir.ValueChanged, AddressOf date_tglakhir_ValueChanged
        date_tglawal.MinDate = selectperiode.tglawal
        date_tglakhir.MaxDate = selectperiode.tglakhir
        SelectedDate1 = date_tglawal.Value : SelectedDate2 = date_tglakhir.Value
    End Sub

    Private Sub MenuSw()
        Dim _EditText = IIf(loggeduser.allowedit_transact Or Not selectperiode.closed, "Edit Data", "Tampilkan Data")
        Dim _enableTrans = IIf(selectperiode.closed, False, True)

        Select Case DataTypeSelector()
            Case "rekap"
                mn_print1.Text = "Print Rekap Barang"
                mn_print2.Text = "Print Rekap Nota"
            Case "tagihan"
                mn_print1.Text = "Print Tagihan"
                mn_print2.Visible = False
        End Select

        mn_delete.Enabled = _enableTrans
        mn_tambah.Enabled = _enableTrans
        mn_edit.Text = _EditText
    End Sub

    Private Function DataTypeSelector() As String
        Select Case tabpagename.Name
            Case "pgdraftrekap"
                Return "rekap"
            Case "pgdrafttagihan"
                Return "tagihan"
            Case Else
                Return String.Empty
        End Select
    End Function

    Private Sub SetDataGrid(DgvType As String)
        Dim x As DataGridViewColumn()

        Dim x_filler = New DataGridViewColumn
        x_filler = dgvcol_templ_id.Clone()
        x_filler.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Select Case LCase(DgvType)
            Case "rekap_list", "tagihan_list"
                setDoubleBuffered(dgv_list, True)
                dgv_list.Columns.Clear()
                dgv_list.AutoGenerateColumns = False

                Dim list_id = New DataGridViewColumn
                Dim list_tgl = New DataGridViewColumn
                Dim list_sales = New DataGridViewColumn
                Dim list_tot_nota = New DataGridViewColumn
                Dim list_tot_item = New DataGridViewColumn
                Dim list_status = New DataGridViewColumn
                Dim list_gudang = New DataGridViewColumn
                list_id = dgvcol_templ_id.Clone()
                list_tgl = dgvcol_templ_status.Clone()
                list_sales = dgvcol_templ_id.Clone()
                list_tot_item = dgvcol_templ_id.Clone()
                list_tot_nota = dgvcol_templ_id.Clone()
                list_status = dgvcol_templ_status.Clone()
                list_gudang = dgvcol_templ_id.Clone()

                list_id.Name = "list_id" : list_id.HeaderText = "Kode Draft" : list_id.DataPropertyName = "kode"
                list_tgl.Name = "list_tgl" : list_tgl.HeaderText = "Tgl. Draft" : list_tgl.DataPropertyName = "tanggal"
                list_sales.Name = "list_sales" : list_sales.HeaderText = "Salesman" : list_sales.DataPropertyName = "sales_n"
                list_tot_item.Name = "list_tot_item" : list_tot_item.HeaderText = "Jml." & IIf(DgvType = "rekap_list", "Item", "Tagihan")
                list_tot_item.DataPropertyName = "tot_item"
                list_tot_nota.Name = "list_tot_nota" : list_tot_nota.HeaderText = "Jml.Nota" : list_tot_nota.DataPropertyName = "tot_faktur"
                list_status.Name = "list_status" : list_status.HeaderText = "Printed" : list_status.DataPropertyName = "print"
                list_gudang.Name = "list_gudang" : list_gudang.HeaderText = "Gudang" : list_gudang.DataPropertyName = "gudang_n"

                list_id.Width = 100
                list_sales.Width = 130
                list_tot_item.Width = IIf(DgvType = "rekap_list", 75, 100)
                list_gudang.Width = list_sales.Width
                list_tot_nota.Width = list_tot_item.Width

                list_tgl.DefaultCellStyle = dgvstyle_date
                list_tot_nota.DefaultCellStyle = dgvstyle_commathousand
                list_tot_item.DefaultCellStyle = IIf(DgvType = "rekap_list", dgvstyle_commathousand, dgvstyle_currency)

                If DgvType = "rekap_list" Then
                    x = {list_id, list_tgl, list_sales, list_gudang, list_tot_nota, list_tot_item, list_status, x_filler}
                Else
                    x = {list_id, list_tgl, list_sales, list_tot_nota, list_tot_item, list_status, x_filler}
                End If

                For i = 0 To x.Count - 1
                    x(i).DisplayIndex = i
                Next

                dgv_list.Columns.AddRange(x)

            Case "rekap_detail", "tagihan_detail"
                setDoubleBuffered(dgv_detail, True)
                dgv_detail.Columns.Clear()
                dgv_detail.AutoGenerateColumns = False

                Dim detail_faktur = New DataGridViewColumn
                Dim detail_custo = New DataGridViewColumn
                Dim detail_custo_n = New DataGridViewColumn
                Dim detail_custo_al = New DataGridViewColumn
                Dim detail_nilai = New DataGridViewColumn
                Dim detail_sales = New DataGridViewColumn
                detail_faktur = dgvcol_templ_id.Clone()
                detail_custo = dgvcol_templ_id.Clone()
                detail_custo_n = dgvcol_templ_id.Clone()
                detail_custo_al = dgvcol_templ_id.Clone()
                detail_nilai = dgvcol_templ_status.Clone()
                detail_sales = dgvcol_templ_id.Clone()

                detail_faktur.Name = "detail_faktur" : detail_faktur.HeaderText = "No.Faktur" : detail_faktur.DataPropertyName = "faktur"
                detail_custo.Name = "detail_custo" : detail_custo.HeaderText = "Kode Customer" : detail_custo.DataPropertyName = "custo"
                detail_custo_n.Name = "detail_custo_n" : detail_custo_n.HeaderText = "Nama Customer" : detail_custo_n.DataPropertyName = "custo_n"
                detail_custo_al.Name = "detail_custo_al" : detail_custo_al.HeaderText = "Alamat" : detail_custo_al.DataPropertyName = "custo_al"
                detail_nilai.Name = "detail_nilai" : detail_nilai.HeaderText = IIf(DgvType = "rekap_detail", "Netto", "Sisa Piutang") : detail_nilai.DataPropertyName = "nilai"
                detail_sales.Name = "detail_sales" : detail_sales.HeaderText = "Salesman" : detail_sales.DataPropertyName = "sales"

                detail_faktur.Width = 100
                detail_custo_n.Width = 130
                detail_custo_al.Width = 170
                detail_custo.Width = detail_faktur.Width
                detail_nilai.Width = detail_faktur.Width
                detail_sales.Width = detail_custo_n.Width

                detail_nilai.DefaultCellStyle = dgvstyle_currency

                x = {detail_faktur, detail_custo, detail_custo_n, detail_custo_al, detail_nilai, detail_sales, x_filler}

                For i = 0 To x.Count - 1
                    x(i).DisplayIndex = i
                Next

                dgv_detail.Columns.AddRange(x)

            Case "rekap_detail2"
                setDoubleBuffered(dgv_detail2, True)
                dgv_detail2.Columns.Clear()
                dgv_detail2.AutoGenerateColumns = False

                Dim brg_id = New DataGridViewColumn
                Dim brg_nama = New DataGridViewColumn
                Dim brg_qty = New DataGridViewColumn
                Dim brg_subtot = New DataGridViewColumn
                Dim brg_disc = New DataGridViewColumn
                Dim brg_total = New DataGridViewColumn
                brg_id = dgvcol_templ_status.Clone()
                brg_nama = dgvcol_templ_id.Clone()
                brg_qty = dgvcol_templ_status.Clone()
                brg_subtot = dgvcol_templ_id.Clone()
                brg_disc = dgvcol_templ_id.Clone()
                brg_total = dgvcol_templ_id.Clone()

                brg_id.Name = "brg_id" : brg_id.HeaderText = "Kode Brg." : brg_id.DataPropertyName = "barang"
                brg_nama.Name = "brg_nama" : brg_nama.HeaderText = "Nama Brg." : brg_nama.DataPropertyName = "barang_n"
                brg_qty.Name = "brg_qty" : brg_qty.HeaderText = "Qty" : brg_qty.DataPropertyName = "qty"
                brg_subtot.Name = "brg_subtot" : brg_subtot.HeaderText = "Subtotal" : brg_subtot.DataPropertyName = "subtot"
                brg_disc.Name = "brg_disc" : brg_disc.HeaderText = "Diskon" : brg_disc.DataPropertyName = "diskon"
                brg_total.Name = "brg_total" : brg_total.HeaderText = "Total" : brg_total.DataPropertyName = "total"

                brg_nama.Width = 120
                For Each y As DataGridViewColumn In {brg_subtot, brg_disc, brg_total}
                    y.Width = 100
                    y.DefaultCellStyle = dgvstyle_currency
                Next

                x = {brg_id, brg_nama, brg_qty, brg_subtot, brg_disc, brg_total, x_filler}
                For i = 0 To x.Count - 1
                    x(i).DisplayIndex = i
                Next

                dgv_detail2.Columns.AddRange(x)

            Case "tagihan_detail2"
                setDoubleBuffered(dgv_detail2, True)
                dgv_detail2.Columns.Clear()
                dgv_detail2.AutoGenerateColumns = False

                Dim tgh_tgl = New DataGridViewColumn
                Dim tgh_ket = New DataGridViewColumn
                Dim tgh_deb = New DataGridViewColumn
                Dim tgh_kre = New DataGridViewColumn
                Dim tgh_sal = New DataGridViewColumn
                Dim tgh_val = New DataGridViewColumn
                tgh_tgl = dgvcol_templ_id.Clone()
                tgh_ket = dgvcol_templ_id.Clone()
                tgh_deb = dgvcol_templ_id.Clone()
                tgh_kre = dgvcol_templ_id.Clone()
                tgh_sal = dgvcol_templ_id.Clone()
                tgh_val = dgvcol_templ_id.Clone()

                tgh_tgl.Name = "tgh_tgl" : tgh_tgl.HeaderText = "Tanggal" : tgh_tgl.DataPropertyName = "piutang_tgl"
                tgh_ket.Name = "tgh_ket" : tgh_ket.HeaderText = "Keterangan" : tgh_ket.DataPropertyName = "piutang_ket"
                tgh_deb.Name = "tgh_deb" : tgh_deb.HeaderText = "Debet" : tgh_deb.DataPropertyName = "piutang_debet"
                tgh_kre.Name = "tgh_kre" : tgh_kre.HeaderText = "Kredit" : tgh_kre.DataPropertyName = "piutang_kredit"
                tgh_sal.Name = "tgh_sal" : tgh_sal.HeaderText = "Saldo" : tgh_sal.DataPropertyName = "piutang_saldo"
                tgh_val.Name = "tgh_val" : tgh_val.HeaderText = "Tagihan" : tgh_val.DataPropertyName = "piutang_tagihan"

                For Each col As DataGridViewColumn In {tgh_deb, tgh_kre, tgh_sal, tgh_val}
                    col.Width = 100
                    col.DefaultCellStyle = dgvstyle_currency
                Next
                tgh_tgl.Width = tgh_deb.Width : tgh_tgl.DefaultCellStyle = dgvstyle_date
                tgh_ket.Width = 200

                x = {tgh_tgl, tgh_ket, tgh_deb, tgh_kre, tgh_sal, tgh_val, x_filler}
                For i = 0 To x.Count - 1
                    x(i).DisplayIndex = i
                Next

                dgv_detail2.Columns.AddRange(x)
            Case Else
                    Exit Sub
        End Select
    End Sub

    'LOAD DATA
    Private Async Sub LoadDataGrid(Param As String, Page As Integer, StartDate As Date, EndDate As Date)
        Dim dt As New DataTable
        Dim _typedata As String = ""
        Dim _limitdata As Integer = _limit
        Dim DataCount As Integer = 0
        Dim PageInfo As String = "{0}-{1} dari {2} data."
        Dim _startdate As Date = IIf(StartDate = #12:00:00 AM#, selectperiode.tglawal, StartDate)
        Dim _enddate As Date = IIf(EndDate = #12:00:00 AM#, selectperiode.tglakhir, EndDate)

        setDoubleBuffered(Me.dgv_list, True)
        _typedata = "draft" & DataTypeSelector()

        Dim done As Boolean = False
        Dim _switchCtrl() As Control = {bt_search, bt_cl, date_tglakhir, date_tglawal, bt_page_first, bt_page_last, bt_page_next, bt_page_prev}
        Try
            RemoveHandler dgv_list.CellClick, AddressOf dgv_list_CellClick
            RemoveHandler dgv_list.RowEnter, AddressOf dgv_list_CellClick
            Me.Cursor = Cursors.WaitCursor : dgv_list.Cursor = Cursors.WaitCursor
            For Each ctr As Control In _switchCtrl
                ctr.Enabled = False
            Next
            mnstrip_main.Enabled = False

            dgv_list.DataSource = New DataTable
            lbl_pageinfo.Text = String.Format(PageInfo, 0, 0, 0) & " - LOADING . . ."

            Dim _datalist = Await Task.Run(Function() GetDataLIstForListTemplate(_typedata, Param, Page, _limitdata, _startdate, _enddate))
            Dim _datacount = Await Task.Run(Function() GetDataCount(_typedata, Param, _startdate, _enddate))

            If _datalist.Key = True And _datacount.Key = True Then
                dgv_list.DataSource = _datalist.Value
                DataCount = _datacount.Value

                MaxPageData = CInt(Math.Ceiling(DataCount / _limitdata))
                SelectedPageData = Page
                PageInfo = String.Format(PageInfo,
                                         If(dgv_list.RowCount > 0, 1, 0) + (_limitdata * Page) - _limitdata,
                                         dgv_list.RowCount + (_limitdata * Page) - _limitdata,
                                         DataCount
                                         )
                lbl_pageinfo.Text = PageInfo
            Else
                MaxPageData = 1
                SelectedPageData = 1
                lbl_pageinfo.Text = String.Format(PageInfo, 0, 0, 0)
            End If

            in_page.Text = SelectedPageData
            done = True
        Catch ex As Exception
            logError(ex, True)
            MessageBox.Show("Terjadi kesalahan saat pengambilan data " & Environment.NewLine & ex.Message,
                            lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            done = True
        Finally
            If done Then
                Me.Cursor = Cursors.Default : dgv_list.Cursor = Cursors.Default
                For Each ctr As Control In _switchCtrl
                    ctr.Enabled = True
                Next
                mnstrip_main.Enabled = True
            End If
            AddHandler dgv_list.CellClick, AddressOf dgv_list_CellClick
            AddHandler dgv_list.RowEnter, AddressOf dgv_list_CellClick
        End Try
    End Sub

    Public Sub PerformRefresh()
        Me.Cursor = Cursors.WaitCursor

        MenuSw() : setDatePicker()
        in_cari.Clear() : SearchString = ""
        SelectedDate1 = date_tglawal.Value : SelectedDate2 = date_tglakhir.Value
        LoadDataGrid("", 1, date_tglawal.Value, date_tglakhir.Value)
        dgv_detail.Rows.Clear() : dgv_detail.Columns.Clear()
        dgv_detail2.Rows.Clear() : dgv_detail2.Columns.Clear()
        dgv_list.ClearSelection()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub AddData()
        If selectperiode.closed Then Exit Sub
        Select Case DataTypeSelector()
            Case "rekap"
                Dim detail As New fr_draft_rekap_det
                detail.DoLoadNew()
            Case "tagihan"
                Dim detail As New fr_draft_tagihan_det
                detail.DoLoadNew()
        End Select
    End Sub

    Private Sub EditData(IdDraft As String)
        Select Case DataTypeSelector()
            Case "rekap"
                Dim detail As New fr_draft_rekap_det
                If selectperiode.closed Then
                    detail.DoLoadView(IdDraft)
                Else
                    detail.DoLoadEdit(IdDraft, True)
                End If
            Case "tagihan"
                Dim detail As New fr_draft_tagihan_det
                If selectperiode.closed Then
                    detail.DoLoadView(IdDraft)
                Else
                    detail.DoLoadEdit(IdDraft, True)
                End If
        End Select
    End Sub

    Private Sub DeleteData(IdDraft As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Me.Cursor = Cursors.WaitCursor

        Dim q As String = ""
        Dim qArr As New List(Of String)

        If MessageBox.Show("Hapus draft?", lbl_title.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Select Case DataTypeSelector()
                Case "rekap"
                    q = "UPDATE data_draft_faktur SET draft_status=9, draft_upd_date=NOW(), draft_upd_alias='{1}' WHERE draft_kode='{0}'"
                    qArr.Add(String.Format(q, IdDraft, loggeduser.user_id))
                    q = "UPDATE data_draft_sales SET sales_status=9 WHERE sales_draft='{0}'"
                    qArr.Add(String.Format(q, IdDraft))
                    q = "UPDATE data_draft_nota SET nota_status=9 WHERE nota_draft='{0}'"
                    qArr.Add(String.Format(q, IdDraft))
                Case "tagihan"
                    q = "UPDATE data_tagihan_faktur SET draft_status=9, draft_upd_date=NOW(), draft_upd_alias='{1}' WHERE draft_kode='{0}'"
                    qArr.Add(String.Format(q, IdDraft, loggeduser.user_id))
                    q = "UPDATE data_tagihan_nota SET nota_status=9 WHERE nota_draft='{0}'"
                    qArr.Add(String.Format(q, IdDraft))
            End Select


            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim _ck = x.TransactCommand(qArr)
                    If Not _ck Then
                        MessageBox.Show("Draft gagal terhapus. Terjadi kesalahan saat melakukan penghapusan.", lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        MessageBox.Show("Draft telah dihapus.", lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        PerformRefresh()
                    End If
                Else
                    MessageBox.Show("Tidak dapat terhubung ke database.", lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PrintData(PrintType As String, IdDraft As String)
        Me.Cursor = Cursors.WaitCursor
        Select Case PrintType
            Case "rekapbarang"
                Using draftbarang As New fr_draft_barang_view
                    draftbarang.kodedraft = IdDraft
                    draftbarang.ShowDialog()
                End Using
            Case "rekapnota"
                Using draftbarang As New fr_draft_nota_view
                    draftbarang.kodedraft = IdDraft
                    draftbarang.ShowDialog()
                End Using
            Case "tagihan"
                Using drafttagihan As New fr_draft_tagihan_view
                    drafttagihan.SetDraft(IdDraft)
                End Using
        End Select
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SearchData(Optional Page As Integer = 1)
        Me.Cursor = Cursors.WaitCursor
        SearchString = in_cari.Text
        SelectedDate1 = date_tglawal.Value : SelectedDate2 = date_tglakhir.Value
        LoadDataGrid(in_cari.Text, Page, date_tglawal.Value, date_tglakhir.Value)
        dgv_list.Focus()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadTableTrans(DetailType As String, IdTrans As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If

        Dim q As String = LoadTableTransQuery(DataTypeSelector() & DetailType)
        If String.IsNullOrWhiteSpace(q) Then Exit Sub

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Using dtx = x.GetDataTable(String.Format(q, IdTrans))
                    For Each row As DataRow In dtx.Rows
                        Select Case DetailType
                            Case "faktur"
                                Dim i = dgv_detail.Rows.Add
                                For y = 0 To dtx.Columns.Count - 1
                                    dgv_detail.Rows.Item(i).Cells(y).Value = row.ItemArray(y)
                                Next
                            Case "barang", "barang2", "piutang"
                                Dim i = dgv_detail2.Rows.Add
                                For y = 0 To dtx.Columns.Count - 1
                                    dgv_detail2.Rows.Item(i).Cells(y).Value = row.ItemArray(y)
                                Next
                        End Select
                        
                    Next
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke server", lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Function LoadTableTransQuery(DataType As String) As String
        Dim _retval As String = ""

        Select Case DataType
            Case "rekapfaktur"
                _retval = "CALL viewDraft('{0}', 'faktur')"
            Case "tagihanfaktur"
                _retval = "CALL viewTagihan('{0}', 'faktur')"
            Case "rekapbarang"
                _retval = "CALL viewDraft('{0}', 'barang')"
            Case "rekapbarang2"
                _retval = "SELECT trans_barang barang, GetMasterNama('barang', trans_barang) barang_n, CONCAT_WS(' ', trans_qty, trans_satuan) qty, " _
                        & "trans_harga_jual*trans_qty subtot, @disc := CountTotalDiskonJualItem(" _
                        & " (trans_harga_jual*trans_qty), (trans_disc_rupiah*trans_qty), trans_disc1, trans_disc2, trans_disc3, trans_disc4,trans_disc5) diskon, " _
                        & "(trans_harga_jual*trans_qty)-ROUND(@disc,2) total " _
                        & "FROM data_penjualan_trans WHERE trans_faktur='{0}' AND trans_status=1"
            Case "tagihanpiutang"
                _retval = String.Format("SELECT piutang_tgl, piutang_ket, piutang_debet, piutang_kredit, " _
                        & "@saldo:=@saldo+(piutang_debet-piutang_kredit) piutang_saldo, piutang_tagihan " _
                        & "FROM( " _
                        & " SELECT 'awal' piutang_tipe, '{1:yyyy-MM-dd}' piutang_tgl, 'SALDO AWAL' piutang_ket, " _
                        & "  GetPiutangSaldoAwal('piutang', '{0}', '{1:yyyy-MM-dd}') piutang_debet, 0 piutang_kredit, 0 piutang_tagihan " _
                        & " UNION " _
                        & " SELECT 'tagih', draft_tanggal, CONCAT('Tagihan ', draft_kode), 0, 0, nota_tagihan " _
                        & " FROM data_tagihan_nota " _
                        & " LEFT JOIN data_tagihan_faktur ON draft_kode=nota_draft AND draft_status<9 " _
                        & " WHERE nota_status=1 AND nota_faktur='{0}' " _
                        & " UNION " _
                        & " SELECT p_trans_jenis, p_trans_tgl, CONCAT(UCASE(p_trans_jenis), ' ', p_trans_faktur), " _
                        & " IF(p_trans_nilai>0, p_trans_nilai, 0), IF(p_trans_nilai<0, p_trans_nilai*-1, 0), 0 " _
                        & " FROM data_piutang_trans " _
                        & " WHERE p_trans_status=1 AND p_trans_kode_piutang='{0}' AND p_trans_tgl BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' " _
                        & " ORDER BY FIELD(piutang_tipe,'awal','migrasi','jual','tagih','bayar','cair','tolak'), piutang_tgl " _
                        & ")history " _
                        & "JOIN (SELECT @saldo:=0) param " _
                        & "WHERE piutang_debet+piutang_kredit+piutang_tagihan<>0", "{0}", selectperiode.tglawal, selectperiode.tglakhir)
        End Select

        Return _retval
    End Function

    Private Sub ShowDetail(DetailType As String, IdTrans As String)
        Me.Cursor = Cursors.AppStarting
        Try
            Dim _ddd As String = ""
            Select Case DetailType
                Case "faktur" : _ddd = "_detail"
                Case "barang", "barang2", "piutang" : _ddd = "_detail2"
                Case Else
                    GoTo EndSub
            End Select
            SetDataGrid(DataTypeSelector() & _ddd)
            LoadTableTrans(DetailType, IdTrans)
            Select Case DetailType
                Case "faktur" : dgv_detail.ClearSelection()
                Case "barang", "barang2", "piutang" : dgv_detail2.ClearSelection()
            End Select
        Catch ex As Exception
            logError(ex, True)
            Dim text = "Tidak dapat menampilkan data" & Environment.NewLine & ex.Message
            MessageBox.Show(text, lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
EndSub:
        Me.Cursor = Cursors.Default
    End Sub

    'UI : CLOSE
    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        dgv_detail.Rows.Clear() : dgv_detail.Columns.Clear()
        dgv_detail2.Rows.Clear() : dgv_detail2.Columns.Clear()
        main.tabcontrol.TabPages.Remove(tabpagename)
    End Sub

    'UI : FLUID
    Private Sub SplitContainer1_SizeChanged(sender As Object, e As EventArgs) Handles SplitContainer1.SizeChanged
        SplitContainer1.SplitterDistance = SplitContainer1.Width * 0.5
    End Sub

    'UI : DGV ITEM LIST
    Private Sub dgv_list_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                EditData(dgv_list.Rows(e.RowIndex).Cells(0).Value)
            End If
        Catch ex As Exception
            logError(ex, False)
        End Try
    End Sub

    Private Sub dgv_list_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_list.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            If dgv_list.SelectedRows.Count > 0 And dgv_list.RowCount > 0 Then
                EditData(dgv_list.SelectedRows.Item(0).Cells(0).Value)
            End If
        End If
    End Sub

    Private Sub dgv_list_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If dgv_list.RowCount > 0 And dgv_list.SelectedRows.Count > 0 And e.RowIndex >= 0 Then
            ShowDetail("faktur", dgv_list.SelectedRows.Item(0).Cells(0).Value)
            dgv_detail.ClearSelection()
            If DataTypeSelector() = "rekap" Then
                ShowDetail("barang", dgv_list.SelectedRows.Item(0).Cells(0).Value)
                dgv_detail2.ClearSelection()
            End If
        End If
    End Sub

    'UI : DGV ITEM DETAIL
    Private Sub dgv_detail_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_detail.CellClick, dgv_detail.RowEnter
        If dgv_detail.RowCount > 0 And dgv_detail.SelectedRows.Count > 0 And e.RowIndex >= 0 Then
            Dim _type As String = ""
            Select Case DataTypeSelector()
                Case "rekap" : _type = "barang2"
                Case "tagihan" : _type = "piutang"
            End Select
            ShowDetail(_type, dgv_detail.SelectedRows.Item(0).Cells(0).Value)
            dgv_detail2.ClearSelection()
        End If
    End Sub

    'UI : MENU
    Private Sub mn_tambah_Click(sender As Object, e As EventArgs) Handles mn_tambah.Click
        AddData()
    End Sub

    Private Sub mn_edit_Click(sender As Object, e As EventArgs) Handles mn_edit.Click
        If dgv_list.RowCount > 0 And dgv_list.SelectedRows.Count > 0 Then
            EditData(dgv_list.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    Private Sub mn_hapus_Click(sender As Object, e As EventArgs) Handles mn_delete.Click
        If dgv_list.RowCount > 0 And dgv_list.SelectedRows.Count > 0 Then
            DeleteData(dgv_list.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    Private Sub mn_refresh_Click(sender As Object, e As EventArgs) Handles mn_refresh.Click
        PerformRefresh()
    End Sub

    Private Sub mn_print1_Click(sender As Object, e As EventArgs) Handles mn_print1.Click
        If dgv_list.RowCount > 0 And dgv_list.SelectedRows.Count > 0 Then
            Dim _ddd As String = ""
            Select Case DataTypeSelector()
                Case "rekap" : _ddd = "barang"

            End Select
            PrintData(DataTypeSelector() & _ddd, dgv_list.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    Private Sub mn_print2_Click(sender As Object, e As EventArgs) Handles mn_print2.Click
        If dgv_list.RowCount > 0 And dgv_list.SelectedRows.Count > 0 Then
            PrintData(DataTypeSelector() & "nota", dgv_list.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    'UI : BUTTON
    Private Sub bt_search_Click(sender As Object, e As EventArgs) Handles bt_search.Click
        SearchData()
    End Sub

    Private Sub bt_page_prev_Click(sender As Object, e As EventArgs) Handles bt_page_prev.Click, bt_page_first.Click
        If String.IsNullOrWhiteSpace(in_page.Text) Then Exit Sub
        in_cari.Text = SearchString
        date_tglawal.Value = SelectedDate1 : date_tglakhir.Value = SelectedDate2

        Me.Cursor = Cursors.WaitCursor
        If SelectedPageData = 1 Then
            in_page.Text = SelectedPageData
        ElseIf SelectedPageData > 1 And sender.Name = "bt_page_prev" Then
            SearchData(SelectedPageData - 1)
        Else
            SearchData(1)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_page_next_Click(sender As Object, e As EventArgs) Handles bt_page_next.Click, bt_page_last.Click
        If String.IsNullOrWhiteSpace(in_page.Text) Then Exit Sub
        in_cari.Text = SearchString
        date_tglawal.Value = SelectedDate1 : date_tglakhir.Value = SelectedDate2

        Me.Cursor = Cursors.WaitCursor
        If SelectedPageData = MaxPageData Then
            in_page.Text = SelectedPageData
        ElseIf SelectedPageData < MaxPageData And sender.Name = "bt_page_next" Then
            SearchData(SelectedPageData + 1)
        Else
            SearchData(MaxPageData)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    'UI : TEXTBOX
    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.Cursor = Cursors.WaitCursor : bt_search.PerformClick() : Me.Cursor = Cursors.Default
        End If
    End Sub

    'UI : DATE PICKER
    Private Sub date_tglawal_ValueChanged(sender As Object, e As EventArgs) Handles date_tglawal.ValueChanged
        date_tglakhir.MinDate = date_tglawal.Value
    End Sub

    Private Sub date_tglakhir_ValueChanged(sender As Object, e As EventArgs) Handles date_tglakhir.ValueChanged
        date_tglawal.MaxDate = date_tglakhir.Value
    End Sub
End Class
