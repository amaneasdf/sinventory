Public Class fr_stock_mutasibrg_list
    Public tabpagename As TabPage

    Private MaxPageData As Integer = 1
    Private SelectedPageData As Integer = 1
    Private SearchString As String = ""
    Private SelectedDate1 As Date = Today
    Private SelectedDate2 As Date = Today

    Private tblstatus As String = ""
    Private _limit As Integer = LimitDataPerPage

    'KEYSHORTCUT
    Protected Overrides Function ProcessKeyPreview(ByRef m As Message) As Boolean
        If m.Msg = &H100 Or m.Msg = &H101 Then  'WM_KEYDOWN / WM_KEYUP
            Dim key As Keys = m.WParam
            If key = Keys.F5 Then
                performRefresh()
                Return True
            ElseIf key = Keys.N And My.Computer.Keyboard.CtrlKeyDown Then
                AddData() : Return True
            ElseIf key = Keys.F And My.Computer.Keyboard.CtrlKeyDown Then
                in_cari.Focus() : Return True
            ElseIf key = Keys.O And My.Computer.Keyboard.CtrlKeyDown Then
                If dgv_list.SelectedRows.Count > 0 Then
                    EditData(dgv_list.SelectedRows.Item(0).Cells(0).Value) : Return True
                End If
                'ElseIf key = Keys.P And My.Computer.Keyboard.CtrlKeyDown Then
                '    printItem()
                '    Return True
            End If
        End If

        Return MyBase.ProcessKeyPreview(m)
    End Function

    'SETUP PAGE CONTROL
    Public Sub SetPage(page As TabPage)
        tabpagename = page
        MenuSw() : setDatePicker()
        in_cari.Clear() : SearchString = String.Empty
        SetDataGrid(DataTypeSelector() & "_list")
        LoadDataGrid("", 1, date_tglawal.Value, date_tglakhir.Value)
    End Sub

    'SETUP DATE PICKER
    Private Sub setDatePicker()
        RemoveHandler date_tglawal.ValueChanged, AddressOf date_tglawal_ValueChanged
        RemoveHandler date_tglakhir.ValueChanged, AddressOf date_tglakhir_ValueChanged
        date_tglawal.MaxDate = selectperiode.tglakhir
        date_tglakhir.MinDate = selectperiode.tglawal
        If selectperiode.tglakhir < Today Then
            date_tglawal.Value = DateSerial(selectperiode.tglakhir.Year, selectperiode.tglakhir.Month, 1)
            date_tglakhir.Value = DateSerial(selectperiode.tglakhir.Year, selectperiode.tglakhir.Month + 1, 0)
        Else
            date_tglawal.Value = DateSerial(Today.Year, Today.Month, 1)
            date_tglakhir.Value = DateSerial(Today.Year, Today.Month + 1, 0)
        End If
        AddHandler date_tglawal.ValueChanged, AddressOf date_tglawal_ValueChanged
        AddHandler date_tglakhir.ValueChanged, AddressOf date_tglakhir_ValueChanged
        date_tglawal.MinDate = selectperiode.tglawal
        date_tglakhir.MaxDate = selectperiode.tglakhir
        SelectedDate1 = date_tglawal.Value : SelectedDate2 = date_tglakhir.Value
    End Sub

    'SETUP MENU
    Private Sub MenuSw()
        Dim _EditText = IIf(loggeduser.allowedit_transact Or Not selectperiode.closed, "Edit Data", "Tampilkan Data")
        Dim _enableTrans = IIf(selectperiode.closed, False, True)

        mn_uncancel.Visible = False
        mn_print.Visible = False

        mn_tambah.Enabled = _enableTrans
        mn_edit.Text = _EditText
    End Sub

    Private Function DataTypeSelector() As String
        Select Case tabpagename.Name
            Case "pgmutasistok"
                Return "stok"
            Case "pgmutasigudang"
                Return "gudang"
            Case "pgstockop"
                Return "opname"
            Case Else
                Return String.Empty
        End Select
    End Function

    'SETUP DATAGRID COLUMNS
    Private Sub SetDataGrid(DgvType As String)
        Dim x As DataGridViewColumn()

        Dim x_filler = New DataGridViewColumn
        x_filler = dgvcol_templ_id.Clone()
        x_filler.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Select Case LCase(DgvType)
            Case "stok_list", "gudang_list"
                setDoubleBuffered(dgv_list, True)
                dgv_list.Columns.Clear()
                dgv_list.AutoGenerateColumns = False

                Dim mutasis_user = New DataGridViewColumn()
                Dim mutasis_id = New DataGridViewColumn()
                Dim mutasis_tgl = New DataGridViewColumn()
                Dim mutasis_gudang = New DataGridViewColumn()
                Dim mutasis_gudang2 = New DataGridViewColumn
                Dim mutasis_jenpajak = New DataGridViewColumn
                Dim mutasis_et = New DataGridViewColumn()
                Dim mutasis_it = New DataGridViewColumn()
                Dim mutasis_status = New DataGridViewColumn()
                mutasis_user = dgvcol_templ_status.Clone()
                mutasis_id = dgvcol_templ_id.Clone()
                mutasis_tgl = dgvcol_templ_id.Clone()
                mutasis_gudang = dgvcol_templ_id.Clone()
                mutasis_gudang2 = dgvcol_templ_id.Clone()
                mutasis_et = dgvcol_templ_id.Clone()
                mutasis_it = dgvcol_templ_id.Clone()
                mutasis_status = dgvcol_templ_status.Clone()
                mutasis_jenpajak = dgvcol_templ_id.Clone()

                mutasis_id.Name = "mutasis_id" : mutasis_id.HeaderText = "Kode Mutasi" : mutasis_id.DataPropertyName = "kode"
                mutasis_tgl.Name = "mutasis_tgl" : mutasis_tgl.HeaderText = "Tanggal Mutasi" : mutasis_tgl.DataPropertyName = "tanggal"
                mutasis_gudang.Name = "mutasis_gudang" : mutasis_gudang.HeaderText = "Gudang" & IIf(DgvType = "gudang_list", " Asal", "") : mutasis_gudang.DataPropertyName = "gudang"
                mutasis_gudang2.Name = "mutasis_gudang2" : mutasis_gudang2.HeaderText = "Gudang Tujuan" : mutasis_gudang2.DataPropertyName = "gudang2"
                mutasis_jenpajak.Name = "jenpajak" : mutasis_jenpajak.HeaderText = "Kat." : mutasis_jenpajak.DataPropertyName = "jenispajak"
                mutasis_status.Name = "mutasis_status" : mutasis_status.HeaderText = "Status" : mutasis_status.DataPropertyName = "status"
                mutasis_it.Name = "mutasis_it" : mutasis_it.HeaderText = "InputDate" : mutasis_it.DataPropertyName = "regdate"
                mutasis_et.Name = "mutasis_et" : mutasis_et.HeaderText = "LastEditDate" : mutasis_et.DataPropertyName = "upddate"
                mutasis_user.Name = "mutasis_user" : mutasis_user.HeaderText = "UserID" : mutasis_user.DataPropertyName = "userid"

                mutasis_id.Width = 100
                mutasis_gudang.Width = 120
                mutasis_tgl.Width = mutasis_id.Width
                mutasis_et.Width = mutasis_gudang.Width : mutasis_it.Width = mutasis_gudang.Width
                mutasis_gudang2.Width = mutasis_gudang.Width

                mutasis_tgl.DefaultCellStyle = dgvstyle_date
                mutasis_it.DefaultCellStyle = dgvstyle_datetime
                mutasis_et.DefaultCellStyle = dgvstyle_datetime

                If DgvType = "stok_list" Then
                    x = {mutasis_id, mutasis_jenpajak, mutasis_tgl, mutasis_gudang, mutasis_status, mutasis_it, mutasis_et, mutasis_user, x_filler}
                Else
                    x = {mutasis_id, mutasis_jenpajak, mutasis_tgl, mutasis_gudang, mutasis_gudang2, mutasis_status, mutasis_it, mutasis_et, mutasis_user, x_filler}
                End If

                For i = 0 To x.Count - 1
                    x(i).DisplayIndex = i
                Next

                dgv_list.Columns.AddRange(x)

            Case "stok_detail", "gudang_detail"
                dgv_barang.Columns.Clear()
                setDoubleBuffered(dgv_barang, True)

                Dim brg_asal = New DataGridViewColumn
                Dim brg_asal_n = New DataGridViewColumn
                Dim brg_tujuan = New DataGridViewColumn
                Dim brg_tujuan_n = New DataGridViewColumn
                Dim brg_qty = New DataGridViewColumn
                Dim brg_sat = New DataGridViewColumn
                Dim brg_qty2 = New DataGridViewColumn
                Dim brg_sat2 = New DataGridViewColumn
                Dim brg_qty3 = New DataGridViewColumn
                Dim brg_sat3 = New DataGridViewColumn
                Dim brg_qty_tot = New DataGridViewColumn
                Dim brg_hpp = New DataGridViewColumn

                brg_asal = dgvcol_templ_id.Clone()
                brg_asal_n = dgvcol_templ_id.Clone()
                brg_tujuan = dgvcol_templ_id.Clone()
                brg_tujuan_n = dgvcol_templ_id.Clone()
                brg_qty = dgvcol_templ_id.Clone()
                brg_sat = dgvcol_templ_id.Clone()
                brg_qty2 = dgvcol_templ_id.Clone()
                brg_sat2 = dgvcol_templ_id.Clone()
                brg_qty3 = dgvcol_templ_id.Clone()
                brg_sat3 = dgvcol_templ_id.Clone()
                brg_qty_tot = dgvcol_templ_id.Clone()
                brg_hpp = dgvcol_templ_id.Clone()

                brg_asal.Name = "brg_asal" : brg_asal.HeaderText = IIf(DgvType = "stok_detail", "Barang Asal", "Kode Barang") : brg_asal.DataPropertyName = "barang1"
                brg_asal_n.Name = "brg_asal_n" : brg_asal_n.HeaderText = "Nama Barang" : brg_asal_n.DataPropertyName = "barang1_n"
                brg_tujuan.Name = "brg_tujuan" : brg_tujuan.HeaderText = "Barang Tujuan" : brg_tujuan.DataPropertyName = "barang2"
                brg_tujuan_n.Name = "brg_tujuan_n" : brg_tujuan_n.HeaderText = "Nama Barang" : brg_tujuan_n.DataPropertyName = "barang2_n"
                brg_qty.Name = "brg_qty" : brg_qty.HeaderText = IIf(DgvType = "stok_detail", "QTY Asal", "QTY.B.") : brg_qty.DataPropertyName = "trans_qty1"
                brg_sat.Name = "brg_sat" : brg_sat.HeaderText = IIf(DgvType = "stok_detail", "Satuan Asal", "QTY.B.") : brg_sat.DataPropertyName = "trans_sat1"
                brg_qty2.Name = "brg_qty2" : brg_qty2.HeaderText = IIf(DgvType = "stok_detail", "QTY Tujuan", "QTY.T.") : brg_qty2.DataPropertyName = "trans_qty2"
                brg_sat2.Name = "brg_sat2" : brg_sat2.HeaderText = IIf(DgvType = "stok_detail", "Satuan Tujuan", "Sat.T.") : brg_sat2.DataPropertyName = "trans_sat2"
                brg_qty3.Name = "brg_qty3" : brg_qty3.HeaderText = "QTY.K." : brg_qty3.DataPropertyName = "trans_qty3"
                brg_sat3.Name = "brg_sat3" : brg_sat3.HeaderText = "Sat.K." : brg_sat3.DataPropertyName = "trans_sat3"
                brg_qty_tot.Name = "brg_qty_tot" : brg_qty_tot.HeaderText = "Qty Total" : brg_qty_tot.DataPropertyName = "trans_qty_tot"
                brg_hpp.Name = "brg_hpp" : brg_hpp.HeaderText = "HPP" : brg_hpp.DataPropertyName = "trans_hpp"

                brg_asal.Width = 100
                brg_tujuan.Width = brg_asal.Width
                brg_asal_n.Width = 175
                brg_tujuan_n.Width = brg_asal_n.Width

                If DgvType = "stok_detail" Then
                    x = {brg_asal, brg_asal_n, brg_qty, brg_sat, brg_tujuan, brg_tujuan_n, brg_qty2, brg_sat2, brg_hpp, x_filler}
                Else
                    x = {brg_asal, brg_asal_n, brg_qty, brg_sat, brg_qty2, brg_sat2, brg_qty3, brg_sat3, brg_qty_tot, brg_hpp, x_filler}
                End If

                For i = 0 To x.Count - 1
                    x(i).DisplayIndex = i
                Next

                dgv_barang.Columns.AddRange(x)

            Case "opname_list"
                setDoubleBuffered(dgv_list, True)
                dgv_list.Columns.Clear()
                dgv_list.AutoGenerateColumns = False

                Dim op_id = New DataGridViewColumn
                Dim op_tgl = New DataGridViewColumn
                Dim op_gudang = New DataGridViewColumn
                Dim op_jenpajak = New DataGridViewColumn
                Dim op_status = New DataGridViewColumn
                Dim op_proses = New DataGridViewColumn
                Dim op_user = New DataGridViewColumn
                Dim op_user2 = New DataGridViewColumn
                Dim op_it = New DataGridViewColumn
                Dim op_et = New DataGridViewColumn

                op_id = dgvcol_templ_id.Clone()
                op_tgl = dgvcol_templ_id.Clone()
                op_gudang = dgvcol_templ_id.Clone()
                op_jenpajak = dgvcol_templ_id.Clone()
                op_status = dgvcol_templ_status.Clone()
                op_proses = dgvcol_templ_id.Clone()
                op_user = dgvcol_templ_status.Clone()
                op_user2 = dgvcol_templ_status.Clone()
                op_it = dgvcol_templ_id.Clone()
                op_et = dgvcol_templ_id.Clone()

                op_id.Name = "op_id" : op_id.HeaderText = "Kode Opname" : op_id.DataPropertyName = "kode"
                op_tgl.Name = "op_tgl" : op_tgl.HeaderText = "Tanggal" : op_tgl.DataPropertyName = "tanggal"
                op_jenpajak.Name = "op_jenpajak" : op_jenpajak.HeaderText = "Kat." : op_jenpajak.DataPropertyName = "jenpajak"
                op_gudang.Name = "op_gudang" : op_gudang.HeaderText = "Gudang" : op_gudang.DataPropertyName = "gudang"
                op_status.Name = "op_status" : op_status.HeaderText = "Status" : op_status.DataPropertyName = "status"
                op_it.Name = "op_it" : op_it.HeaderText = "InputDate" : op_it.DataPropertyName = "regdate"
                op_et.Name = "op_et" : op_et.HeaderText = "LastEditDate" : op_et.DataPropertyName = "upddate"
                op_user.Name = "op_user" : op_user.HeaderText = "UserID" : op_user.DataPropertyName = "userid"
                op_proses.Name = "op_proses" : op_proses.HeaderText = "Apv.Date" : op_proses.DataPropertyName = "tglproses"
                op_user2.Name = "op_user2" : op_user2.HeaderText = "UserID" : op_user2.DataPropertyName = "userproses"

                op_id.Width = 100
                op_gudang.Width = 120
                op_tgl.Width = op_id.Width
                op_et.Width = op_gudang.Width : op_it.Width = op_gudang.Width : op_proses.Width = op_gudang.Width

                op_tgl.DefaultCellStyle = dgvstyle_date
                op_it.DefaultCellStyle = dgvstyle_datetime
                op_et.DefaultCellStyle = dgvstyle_datetime
                op_proses.DefaultCellStyle = dgvstyle_datetime

                x = {op_id, op_gudang, op_jenpajak, op_tgl, op_status, op_it, op_et, op_user, op_proses, op_user2, x_filler}

                For i = 0 To x.Count - 1
                    x(i).DisplayIndex = i
                Next

                dgv_list.Columns.AddRange(x)

            Case "opname_detail"
                dgv_barang.Columns.Clear()
                setDoubleBuffered(dgv_barang, True)

                Dim op_brg = New DataGridViewColumn
                Dim op_brg_n = New DataGridViewColumn
                Dim op_qty_sys = New DataGridViewColumn
                Dim op_qty_sys_k = New DataGridViewColumn
                Dim op_qty_k = New DataGridViewColumn
                Dim op_sat_k = New DataGridViewColumn
                Dim op_qty_t = New DataGridViewColumn
                Dim op_sat_t = New DataGridViewColumn
                Dim op_qty_b = New DataGridViewColumn
                Dim op_sat_b = New DataGridViewColumn
                Dim op_qty_tot = New DataGridViewColumn
                Dim op_hpp = New DataGridViewColumn
                Dim op_hpp_sys = New DataGridViewColumn

                op_brg = dgvcol_templ_id.Clone()
                op_brg_n = dgvcol_templ_id.Clone()
                op_qty_sys = dgvcol_templ_status.Clone()
                op_qty_sys_k = dgvcol_templ_status.Clone()
                op_qty_k = dgvcol_templ_id.Clone()
                op_sat_k = dgvcol_templ_id.Clone()
                op_qty_t = dgvcol_templ_id.Clone()
                op_sat_t = dgvcol_templ_id.Clone()
                op_qty_b = dgvcol_templ_id.Clone()
                op_sat_b = dgvcol_templ_id.Clone()
                op_qty_tot = dgvcol_templ_id.Clone()
                op_hpp = dgvcol_templ_status.Clone()
                op_hpp_sys = dgvcol_templ_status.Clone()

                op_brg.Name = "op_brg" : op_brg.HeaderText = "Kode Barang" : op_brg.DataPropertyName = "barang"
                op_brg_n.Name = "op_brg_n" : op_brg_n.HeaderText = "Nama Barang" : op_brg_n.DataPropertyName = "barang_n"
                op_qty_sys.Name = "op_qty_sys" : op_qty_sys.HeaderText = "QTY Sys.Det." : op_qty_sys.DataPropertyName = "qty_sys_n"
                op_qty_sys_k.Name = "op_qty_sys_k" : op_qty_sys_k.HeaderText = "QTY Sys." : op_qty_sys_k.DataPropertyName = "qty_sys"
                op_qty_k.Name = "op_qty_k" : op_qty_k.HeaderText = "QTY K." : op_qty_k.DataPropertyName = "qty_k"
                op_sat_k.Name = "op_sat_k" : op_sat_k.HeaderText = "Sat.K." : op_sat_k.DataPropertyName = "sat_k"
                op_qty_b.Name = "op_qty_b" : op_qty_b.HeaderText = "QTY B." : op_qty_b.DataPropertyName = "qty_b"
                op_sat_b.Name = "op_sat_b" : op_sat_b.HeaderText = "Sat.B." : op_sat_b.DataPropertyName = "sat_b"
                op_qty_t.Name = "op_qty_t" : op_qty_t.HeaderText = "QTY T." : op_qty_t.DataPropertyName = "qty_t"
                op_sat_t.Name = "op_sat_t" : op_sat_t.HeaderText = "Sat.T." : op_sat_t.DataPropertyName = "sat_t"
                op_qty_tot.Name = "op_qty_tot" : op_qty_tot.HeaderText = "QTY Tot." : op_qty_tot.DataPropertyName = "qtytot"
                op_hpp.Name = "op_hpp" : op_hpp.HeaderText = "HPP Fis." : op_hpp.DataPropertyName = "hpp_fis"
                op_hpp_sys.Name = "op_hpp_sys" : op_hpp_sys.HeaderText = "HPP Sys." : op_hpp_sys.DataPropertyName = "hpp_sys"

                op_brg.Width = 100
                op_brg_n.Width = 160
                op_qty_sys.Width = 140

                op_hpp.DefaultCellStyle = dgvstyle_currency
                op_hpp_sys.DefaultCellStyle = dgvstyle_currency
                For Each _col As DataGridViewColumn In {op_qty_b, op_qty_t, op_qty_t, op_qty_tot}
                    _col.DefaultCellStyle = dgvstyle_commathousand
                Next

                x = {op_brg, op_brg_n, op_qty_sys_k, op_qty_sys, op_qty_b, op_sat_b, op_qty_t, op_sat_t, op_qty_k, op_sat_k, op_qty_tot, op_hpp_sys, op_hpp, x_filler}

                For i = 0 To x.Count - 1
                    x(i).DisplayIndex = i
                Next

                dgv_barang.Columns.AddRange(x)
            Case Else
                Exit Sub
        End Select

    End Sub

    'LOAD LIST DATA
    Private Async Sub LoadDataGrid(Param As String, Page As Integer, StartDate As Date, EndDate As Date)
        Dim dt As New DataTable
        Dim _typedata As String = ""
        Dim _limitdata As Integer = _limit
        Dim DataCount As Integer = 0
        Dim PageInfo As String = "{0}-{1} dari {2} data."
        Dim _startdate As Date = IIf(StartDate = #12:00:00 AM#, selectperiode.tglawal, StartDate)
        Dim _enddate As Date = IIf(EndDate = #12:00:00 AM#, selectperiode.tglakhir, EndDate)

        setDoubleBuffered(Me.dgv_list, True)
        _typedata = "mutasi" & DataTypeSelector()

        Dim done As Boolean = False
        Try
            Me.Cursor = Cursors.WaitCursor : dgv_list.Cursor = Cursors.WaitCursor
            For Each ctr As Control In {bt_search, bt_cl, date_tglakhir, date_tglawal, bt_page_first, bt_page_last, bt_page_next, bt_page_prev}
                ctr.Enabled = False
            Next
            mnstrip_main.Enabled = False

            dgv_list.DataSource = New DataTable
            lbl_pageinfo.Text = String.Format(PageInfo, 0, 0, 0) & " - LOADING . . ."

            Dim _datalist = Await Task.Run(Function() GetDataLIstForListTemplate(_typedata, Param, Page, _limitdata, _startdate, _enddate))
            Dim _datacount = Await Task.Run(Function() GetDataCount(_typedata, Param, _startdate, _enddate))

            If _datalist.Key And _datacount.Key Then
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
                For Each ctr As Control In {bt_search, bt_cl, date_tglakhir, date_tglawal, bt_page_first, bt_page_last, bt_page_next, bt_page_prev}
                    ctr.Enabled = True
                Next
                mnstrip_main.Enabled = True
            End If
        End Try
    End Sub

    Public Sub PerformRefresh()
        Me.Cursor = Cursors.WaitCursor

        MenuSw() : setDatePicker()
        in_cari.Clear() : SearchString = ""
        LoadDataGrid("", 1, date_tglawal.Value, date_tglakhir.Value)
        dgv_barang.Rows.Clear()
        dgv_barang.Columns.Clear()

        Me.Cursor = Cursors.Default
    End Sub

    'DATA MANIPULATION/CRUD FORM
    Private Sub AddData()
        If selectperiode.closed Then Exit Sub

        Select Case DataTypeSelector()
            Case "stok" : Dim detail As New fr_stok_mutasi_barang : detail.doLoadNew()
            Case "gudang" : Dim detail As New fr_stok_mutasi : detail.doLoadNew()
            Case "opname" : Dim detail As New fr_stock_op : detail.doLoadNew()
        End Select
    End Sub

    Private Sub EditData(IdTrans As String)
        Select Case DataTypeSelector()
            Case "stok"
                Dim detail As New fr_stok_mutasi_barang
                If selectperiode.closed Then
                    detail.doLoadView(IdTrans)
                Else
                    detail.doLoadEdit(IdTrans, loggeduser.allowedit_transact)
                End If
            Case "gudang"
                Dim detail As New fr_stok_mutasi
                If selectperiode.closed Then
                    detail.doLoadView(IdTrans)
                Else
                    detail.doLoadEdit(IdTrans, loggeduser.allowedit_transact)
                End If
            Case "opname"
                Dim detail As New fr_stock_op
                If selectperiode.closed Then
                    detail.doLoadView(IdTrans)
                Else
                    detail.doLoadEdit(IdTrans, loggeduser.allowedit_transact)
                End If
        End Select
    End Sub

    Private Sub CancelData(IdTrans As String)
        Me.Cursor = Cursors.WaitCursor
        If selectperiode.closed Or Not loggeduser.validasi_trans Then Exit Sub

        Dim q As String = ""
        Dim _status As Integer = 0
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    Select Case DataTypeSelector()
                        Case "stok"
                            q = "SELECT faktur_status FROM data_barang_mutasi WHERE faktur_kode='{0}' AND faktur_status<9"
                        Case "gudang"
                            q = "SELECT faktur_status FROM data_barang_stok_mutasi WHERE faktur_kode='{0}' AND faktur_status<9"
                        Case "opname"
                            q = "SELECT faktur_status FROM data_stok_opname WHERE faktur_bukti='{0}' AND faktur_status<9"
                        Case Else
                            GoTo EndSub
                    End Select
                    _status = CInt(x.ExecScalar(String.Format(q, IdTrans)))

                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data." & Environment.NewLine & ex.Message,
                                    lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GoTo EndSub
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                GoTo EndSub
            End If
        End Using

        If Not {0, 1}.Contains(_status) Then GoTo EndSub

        ChangeDataState(IdTrans, 2)

EndSub:
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub UnCancelData(IdTrans As String)
        Me.Cursor = Cursors.WaitCursor
        If selectperiode.closed Or Not loggeduser.validasi_trans Then Exit Sub

        Dim q As String = ""
        Dim _status As Integer = 0
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    Select Case DataTypeSelector()
                        Case "stok"
                            q = "SELECT faktur_status FROM data_barang_mutasi WHERE faktur_kode='{0}' AND faktur_status<9 ORDER BY faktur_id DESC LIMIT 1"
                        Case "gudang"
                            q = "SELECT faktur_status FROM data_barang_stok_mutasi WHERE faktur_kode='{0}' AND faktur_status<9 ORDER BY faktur_id DESC LIMIT 1"
                        Case "opname"
                            q = "SELECT faktur_bukti FROM data_stok_opname WHERE faktur_bukti='{0}' AND faktur_status<9 ORDER BY faktur_id DESC LIMIT 1"
                    End Select
                    _status = CInt(x.ExecScalar(String.Format(q, IdTrans)))
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data." & Environment.NewLine & ex.Message,
                                    lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GoTo EndSub
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                GoTo EndSub
            End If
        End Using

        If Not _status = 2 Then GoTo EndSub
        ChangeDataState(IdTrans, IIf(DataTypeSelector() = "opname", 0, 1))

EndSub:
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DeleteData(IdTrans As String)
        If selectperiode.closed Or Not loggeduser.validasi_trans Then Exit Sub
        ChangeDataState(IdTrans, 9)
    End Sub

    Private Sub ChangeDataState(IdTrans As String, DataState As Integer)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim MsgList As New List(Of String)
        Dim _trans, _act As String
        Select Case DataState
            Case 0
                If Not DataTypeSelector() = "opname" Then Exit Sub
                MsgList.AddRange({"Cancel pembatalan opname?", "Transaksi opname berhasil diaktifkan kembali.",
                                  "Cancel pembatalan transaksi gagal. Terjadi kesalahan saat melakukan proses."})
                _act = "CANCEL_BATAL"
            Case 1
                If DataTypeSelector() = "opname" Then Exit Sub
                MsgList.AddRange({"Cancel pembatalan transaksi mutasi?", "Transaksi mutasi berhasil diaktifkan kembali.",
                                  "Cancel pembatalan transaksi gagal. Terjadi kesalahan saat melakukan proses."})
                _act = "CANCEL_BATAL"
            Case 2
                MsgList.AddRange({"Batalkan transaksi mutasi?", "Transaksi berhasil dibatalkan.", "Pembatalan transaksi gagal. Terjadi kesalahan saat melakukan proses."})
                _act = "BATAL_TRANS"
            Case 9
                MsgList.AddRange({"Hapus transaksi mutasi?", "Transaksi berhasil dihapus.", "Transaksi tidak dapat dihapus. Terjadi kesalahan saat melakukan proses."})
                _act = "DELETE_TRANS"
            Case Else : Exit Sub
        End Select

        If MessageBox.Show(MsgList.Item(0), lbl_title.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim _ket As String = ""
            If TransConfirmValid(_ket) Then
                Dim q As String = ""
                Dim qArr As New List(Of String)
                Dim qCk As Boolean = False

                Using x = MainConnection
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        Select Case DataTypeSelector()
                            Case "stok"
                                _trans = "MUTASI_BARANG"
                                q = "UPDATE data_barang_mutasi SET faktur_status={3}, faktur_ket=TRIM(BOTH '\r\n' FROM CONCAT(faktur_ket,'\r\n','{2}')), " _
                                    & "faktur_upd_date =NOW(), faktur_upd_alias='{1}' WHERE faktur_kode='{0}' AND faktur_status<9"
                                qArr.Add(String.Format(q, IdTrans, loggeduser.user_id, _ket, DataState))
                                If DataState = 9 Then
                                    q = "UPDATE data_barang_mutasi_trans SET trans_status=9 WHERE trans_faktur='{0}'"
                                    qArr.Add(String.Format(q, IdTrans))
                                End If
                                q = "CALL transMutasiBarangFin('{0}','{1}')"
                                qArr.Add(String.Format(q, IdTrans, loggeduser.user_id))

                            Case "gudang"
                                _trans = "MUTASI_GUDANG"
                                q = "UPDATE data_barang_stok_mutasi SET faktur_status={3}, faktur_ket=TRIM(BOTH '\r\n' FROM CONCAT(faktur_ket,'\r\n','{2}')), " _
                                    & "faktur_upd_date =NOW(), faktur_upd_alias='{1}' WHERE faktur_kode='{0}' AND faktur_status<9"
                                qArr.Add(String.Format(q, IdTrans, loggeduser.user_id, _ket, DataState))
                                If DataState = 9 Then
                                    q = "UPDATE data_barang_stok_mutasi_trans SET trans_status=9 WHERE trans_faktur='{0}'"
                                    qArr.Add(String.Format(q, IdTrans))
                                End If
                                q = "CALL transMutasiStokFin('{0}','{1}')"
                                qArr.Add(String.Format(q, IdTrans, loggeduser.user_id))

                            Case "opname"
                                _trans = "STOCK_OPNAME"
                                q = "UPDATE data_stok_opname SET faktur_status={3}, faktur_ket=TRIM(BOTH '\r\n' FROM CONCAT(faktur_ket,'\r\n','{2}')), " _
                                    & "faktur_proc_date =NOW(), faktur_proc_alias='{1}' WHERE faktur_bukti='{0}' AND faktur_status<9"
                                qArr.Add(String.Format(q, IdTrans, loggeduser.user_id, _ket, DataState))
                                If DataState = 9 Then
                                    q = "UPDATE data_stok_opname_trans SET faktur_status=9 WHERE trans_faktur='{0}'"
                                    qArr.Add(String.Format(q, IdTrans))
                                End If
                                q = "CALL transMutasiOpnameFin('{0}','{1}')"
                                qArr.Add(String.Format(q, IdTrans, loggeduser.user_id))

                            Case Else
                                Exit Sub
                        End Select

                        'INSERT LOG KONFIRMASI ACT
                        q = "INSERT INTO system_log_confirm(cnf_user, cnf_trans, cnf_trans_id, cnf_trans_act) VALUE ('{0}','{1}'.'{2}','{3}')"
                        'qArr.Add(String.Format(q, loggeduser.user_id, _trans, IdTrans, _act))

                        qCk = x.TransactCommand(qArr)

                        If qCk Then
                            MessageBox.Show(MsgList.Item(1), lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            PerformRefresh()
                        Else
                            MessageBox.Show(MsgList.Item(2), lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Tidak dapat terhubung ke database.", lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End If
        End If
    End Sub

    Private Sub ExportData()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If

        Dim q As String = ""
        Dim _dtList As New List(Of DataTable)
        Dim _colheader As New List(Of String)
        Dim _title As New List(Of String)
        Dim _fileDir As String = ""
        Dim _fileExt As String = "xlsx"

        Using SaveDialog As New SaveFileDialog
            SaveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
            SaveDialog.FilterIndex = 1
            SaveDialog.RestoreDirectory = True
            SaveDialog.AddExtension = True
            If SaveDialog.ShowDialog = DialogResult.OK Then
                _fileDir = SaveDialog.FileName
                If SaveDialog.FilterIndex = 1 Then
                    _fileExt = "xlsx"
                Else
                    _fileExt = ""
                End If
            Else
                Exit Sub
            End If
        End Using

        Select Case DataTypeSelector()
            Case "stok"
                q = "SELECT faktur_kode, faktur_tanggal, IFNULL(pajak.ref_text,'ERROR') kat, faktur_gudang, gudang_nama, trans_barang_asal, " _
                    & "GetMasterNama('barang', trans_barang_asal), trans_qty_asal, trans_sat_asal, trans_barang_tujuan, GetMasterNama('barang', trans_barang_tujuan), " _
                    & "trans_qty_tujuan, trans_sat_tujuan, trans_hpp_tujuan, IFNULL(state.ref_text,'ERROR') status FROM data_barang_mutasi " _
                    & "LEFT JOIN data_barang_mutasi_trans ON faktur_kode=trans_faktur AND trans_status=1 " _
                    & "LEFT JOIN data_barang_gudang ON faktur_gudang=gudang_kode " _
                    & "LEFT JOIN ref_jenis pajak ON faktur_pajak=pajak.ref_kode AND pajak.ref_status=1 AND pajak.ref_type='ppn_trans2' " _
                    & "LEFT JOIN ref_jenis state ON faktur_status=state.ref_kode AND state.ref_status=1 AND state.ref_type='status_trans' " _
                    & "WHERE faktur_status<9 AND faktur_tanggal BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}'"
                q = String.Format(q, selectperiode.tglawal, selectperiode.tglakhir)

                _colheader.AddRange({"ID", "Tanggal", "Kategori", "KodeGudang", "NamaGudang", "KodeBarangA", "NamaBarang", "Qty", "Satuan",
                                     "KodeBarangT", "NamaBarang", "Qty", "Satuan", "HPP", "Status"})

                _title.AddRange({"Data Mutasi Barang", String.Format("Periode {0:dd MMMM yyy} s.d. {1:dd MMMM yyyy}", selectperiode.tglawal, selectperiode.tglakhir)})

            Case "gudang"
                q = "SELECT faktur_kode, faktur_tanggal, IFNULL(pajak.ref_text,'ERROR') kat, faktur_gudang_asal, GetMasterNama('gudang', faktur_gudang_asal), " _
                    & "faktur_gudang_tujuan, GetMasterNama('gudang', faktur_gudang_tujuan), trans_barang, GetMasterNama('barang', trans_barang), " _
                    & "trans_qty_besar, trans_satuan_besar, trans_qty_tengah, trans_satuan_tengah, trans_qty_kecil, trans_satuan_kecil, " _
                    & "IFNULL(state.ref_text,'ERROR') status  FROM data_barang_stok_mutasi " _
                    & "LEFT JOIN data_barang_stok_mutasi_trans ON faktur_kode=trans_faktur AND faktur_status=1 " _
                    & "LEFT JOIN ref_jenis pajak ON faktur_pajak=pajak.ref_kode AND pajak.ref_status=1 AND pajak.ref_type='ppn_trans2' " _
                    & "LEFT JOIN ref_jenis state ON faktur_status=state.ref_kode AND state.ref_status=1 AND state.ref_type='status_trans' " _
                    & "WHERE faktur_status<9 AND faktur_tanggal BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}'"
                q = String.Format(q, selectperiode.tglawal, selectperiode.tglakhir)

                _colheader.AddRange({"ID", "Tanggal", "Kategori", "GudangA", "Nama Gudang", "GudangT", "Nama Gudang", "KodeBarang", "NamaBarang", "Qty1", "Sat1",
                                     "QTY2", "Sat2", "QTY3", "Sat3", "Status"})

                _title.AddRange({"Data Mutasi Stok Antar Gudang", String.Format("Periode {0:dd MMMM yyy} s.d. {1:dd MMMM yyyy}", selectperiode.tglawal, selectperiode.tglakhir)})

            Case "opname"
                q = "SELECT faktur_bukti, faktur_tanggal, IFNULL(pajak.ref_text,'ERROR') kat, faktur_gudang, gudang_nama, trans_barang, " _
                    & "GetMasterNama('barang', trans_barang), getQTYDetail(trans_barang,trans_qty_sys,1), trans_hpp, trans_qty_b_fis , trans_sat_b_fis, " _
                    & "trans_qty_t_fis, trans_sat_t_fis, trans_qty_k_fis, trans_satuan, trans_hpp_fisik, IFNULL(state.ref_text,'ERROR') status " _
                    & "FROM data_stok_opname " _
                    & "LEFT JOIN data_stok_opname_trans ON trans_faktur=faktur_bukti AND trans_status=1" _
                    & "LEFT JOIN data_barang_master ON trans_barang=barang_kode " _
                    & "LEFT JOIN ref_jenis pajak ON faktur_pajak=pajak.ref_kode AND pajak.ref_status=1 AND pajak.ref_type='ppn_trans2' " _
                    & "LEFT JOIN ref_jenis state ON faktur_status=state.ref_kode AND state.ref_status=1 AND state.ref_type='pesan_status' " _
                    & "WHERE faktur_status<9 AND faktur_tanggal BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}'"
                q = String.Format(q, selectperiode.tglawal, selectperiode.tglakhir)

                _colheader.AddRange({"KodeOpname", "Tanggal", "Kategori", "KodeGudang", "Nama Gudang", "KodeBarang", "NamaBarang", "Qty Sys.", "HPP Sys.",
                                     "Qty Fis.B", "Sat.Fis.B", "Qty Fis.T.", "Sat.Fis.T", "Qty Fis.K", "Sat.Fis.K", "HPP Fis.", "Status"})

                _title.AddRange({"Data Opname Stok Gudang", String.Format("Periode {0:dd MMMM yyy} s.d. {1:dd MMMM yyyy}", selectperiode.tglawal, selectperiode.tglakhir)})

            Case Else
                Exit Sub
        End Select

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Using dtx = x.GetDataTable(q) : _dtList.Add(dtx) : End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke server", lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End Using

        Dim _fileRes As String = _fileDir
        If ExportExcel(_colheader, _dtList, _title, _fileDir, _fileExt, _fileRes) Then
            If System.IO.File.Exists(_fileRes) = True Then
                MessageBox.Show("Export Data Sukses", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Process.Start(_fileRes)
            Else
                MessageBox.Show("Export dokumen tidak dapat ditemukan", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Export Tidak Berhasil", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ExportData(ParamString As String)
        Dim _q As String = ""
        Dim _qwh, _qorder, _qjoin As String

        Select Case tabpagename.Name
            Case "pgmutasigudang"
                _q = "SELECT faktur_kode, faktur_tanggal, IFNULL(ppn.ref_text,'ERROR') jenispajak, " _
                    & "faktur_gudang_asal, GetMasterNama('gudang',faktur_gudang_asal), faktur_gudang_tujuan, GetMasterNama('gudang',faktur_gudang_tujuan), " _
                    & "trans_barang, GetMasterNama('barang',trans_barang), trans_qty_besar, trans_satuan_besar, trans_qty_tengah, trans_satuan_tengah, " _
                    & "trans_qty_kecil, trans_satuan_kecil, trans_qty_tot, trans_hpp, status.ref_text " _
                    & "FROM data_barang_stok_mutasi "
                _qjoin = " LEFT JOIN data_barang_stok_mutasi_trans ON trans_faktur=faktur_kode AND trans_status=1 " _
                        & "LEFT JOIN ref_jenis ppn ON faktur_pajak=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans2' " _
                        & "LEFT JOIN ref_jenis status ON faktur_status=status.ref_kode AND status.ref_status=1 AND status.ref_type='status_trans'"
                _qorder = " ORDER BY faktur_tanggal, faktur_kode"
                _qwh = String.Format(" WHERE faktur_status IN (0,1,2) faktur_tanggal BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}'", SelectedDate1, SelectedDate2)
                If Not String.IsNullOrWhiteSpace(ParamString) Then
                    _qwh = String.Join("'" & ParamString & "'", {"AND (faktur_kode REGEXP ",
                                                                 " OR DATE_FORMAT(faktur_tanggal,'%d/%m/%Y') REGEXP ",
                                                                 " OR faktur_gudang_asal REGEXP ", " OR GetMasterNama('gudang',faktur_gudang_asal) REGEXP ",
                                                                 " OR faktur_gudang_tujuan REGEXP ", " OR GetMasterNama('gudang',faktur_gudang_tujuan) REGEXP ",
                                                                 " OR trans_barang REGEXP ", " OR GetMasterNama('barang',trans_barang) REGEXP ",
                                                                 " OR status.ref_text REGEXP ", " OR ppn.ref_text REGEXP ", ")"})
                Else
                    _qwh = ""
                End If

                _q += _qjoin + _qwh + _qorder

            Case "pgmutasistok"
                _q = "SELECT faktur_kode, faktur_tanggal, IFNULL(ppn.ref_text,'ERROR') jenispajak, " _
                    & "faktur_gudang, GetMasterNama('gudang',faktur_gudang), trans_barang_asal, GetMasterNama('barang',trans_barang_asal), " _
                    & "CONCAT_WS(' ', trans_qty_asal, trans_sat_asal), trans_qty_asal*trans_hpp_asal, " _
                    & "trans_barang_tujuan, GetMasterNama('barang',trans_barang_tujuan), CONCAT_WS(' ', trans_qty_tujuan, trans_sat_tujuan), " _
                    & "trans_qty_tujuan*trans_hpp_tujuan, status.ref_text " _
                    & "FROM data_barang_mutasi "
                _qjoin = " LEFT JOIN data_barang_mutasi_trans ON trans_faktur=faktur_kode AND trans_status=1 " _
                        & "LEFT JOIN ref_jenis ppn ON faktur_pajak=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans2' " _
                        & "LEFT JOIN ref_jenis status ON faktur_status=status.ref_kode AND status.ref_status=1 AND status.ref_type='status_trans'"
                _qorder = " ORDER BY faktur_tanggal, faktur_kode"
                _qwh = String.Format(" WHERE faktur_status IN (0,1,2) faktur_tanggal BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}'", SelectedDate1, SelectedDate2)
                If Not String.IsNullOrWhiteSpace(ParamString) Then
                    _qwh = String.Join("'" & ParamString & "'", {"AND (faktur_kode REGEXP ",
                                                                 " OR DATE_FORMAT(faktur_tanggal,'%d/%m/%Y') REGEXP ",
                                                                 " OR faktur_gudang REGEXP ", " OR GetMasterNama('gudang',faktur_gudang) REGEXP ",
                                                                 " OR trans_barang_asal REGEXP ", " OR GetMasterNama('barang',trans_barang_asal) REGEXP ",
                                                                 " OR trans_barang_tujuan REGEXP ", " OR GetMasterNama('barang',trans_barang_tujuan) REGEXP ",
                                                                 " OR status.ref_text REGEXP ", " OR ppn.ref_text REGEXP ", ")"})
                Else
                    _qwh = ""
                End If

                _q += _qjoin + _qwh + _qorder

            Case "pgstockop"
                _q = "SELECT faktur_bukti, faktur_tanggal, faktur_gudang, GetMasterNama('gudang',faktur_gudang), IFNULL(ppn.ref_text,'ERROR') jenispajak, " _
                    & "trans_barang, GetMasterNama('barang',trans_barang), getQTYdetail(trans_barang, trans_qty_sys, 1), trans_qty_sys*trans_hpp, " _
                    & "CONCAT_WS('.',CONCAT(trans_qty_b_fis,' ',trans_sat_b_fis), " _
                    & "              CONCAT(trans_qty_t_fis,' ',trans_sat_t_fis), " _
                    & "              CONCAT(trans_qty_k_fis,' ',trans_satuan)), trans_qty_fisik*trans_hpp_fisik, status.ref_text, " _
                    & "@valid:=IF(faktur_status NOT IN (1,2), NULL, faktur_proc_alias), IF(@valid IS NULL, NULL, faktur_proc_date) " _
                    & "FROM data_stok_opname "
                _qjoin = " LEFT JOIN data_stok_opname_trans ON faktur_bukti=trans_faktur AND trans_status=1 " _
                        & "LEFT JOIN ref_jenis ppn ON faktur_pajak=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans2' " _
                        & "LEFT JOIN ref_jenis status ON faktur_status=status.ref_kode AND status.ref_status=1 AND status.ref_type='status_trans'"
                _qorder = " ORDER BY faktur_tanggal, faktur_bukti"
                _qwh = String.Format(" WHERE faktur_status IN (0,1,2) faktur_tanggal BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}'", SelectedDate1, SelectedDate2)
                If Not String.IsNullOrWhiteSpace(ParamString) Then
                    _qwh = String.Join("'" & ParamString & "'", {"AND (faktur_bukti REGEXP ",
                                                                 " OR DATE_FORMAT(faktur_tanggal,'%d/%m/%Y') REGEXP ",
                                                                 " OR faktur_gudang REGEXP ", " OR GetMasterNama('gudang',faktur_gudang) REGEXP ",
                                                                 " OR trans_barang REGEXP ", " OR GetMasterNama('barang',trans_barang) REGEXP ",
                                                                 " OR status.ref_text REGEXP ", " OR ppn.ref_text REGEXP ", ")"})
                Else
                    _qwh = ""
                End If

                _q += _qjoin + _qwh + _qorder
            Case Else : Exit Sub
        End Select

        exportToExcel(_q)
    End Sub

    Private Sub exportToExcel(SqlQuery As String)
        Dim _dt As New List(Of DataTable)
        Dim _title As New List(Of String)
        Dim _subtitle As New List(Of String())
        Dim _colHeader As New List(Of String)
        Dim _outputdir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\SIMInvent\"
        Dim _periode As String = ""
        Dim _ck As Boolean = False

        Dim _tglawal As Date = date_tglawal.Value : Dim _tglakhir As Date = date_tglakhir.Value
        If _tglawal.ToString("MMyyyy") = _tglakhir.ToString("MMyyyy") AndAlso _tglawal.Day = 1 _
            AndAlso _tglakhir.Day = DateSerial(_tglakhir.Year, _tglakhir.Month + 1, 0).Day Then
            _periode = UCase(_tglawal.ToString("MMMM yyyy"))
        Else
            _periode = _tglawal.ToString("dd/MM/yyyy") & " S.d " & _tglakhir.ToString("dd/MM/yyyy")
        End If


        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Using dtx = x.GetDataTable(SqlQuery)
                    Select Case tabpagename.Name
                        Case "pgmutasigudang"
                            _colHeader.AddRange({"KodeMutasi", "Tgl", "Kat", "GudangAsal", "NamaGudangAsal", "GudangTujuan", "NamaGudangTujuan",
                                                 "KodeBarang", "NamaBarang", "QtyB", "SatB", "QtyT", "SatT", "QtyK", "SatK", "QtyTot", "HPP", "Status"})
                            _title.AddRange({"DATA MUTASI BARANG ANTAR GUDANG", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "pgmutasistok"
                            _colHeader.AddRange({"KodeMutasi", "Tgl", "Kat", "KodeGudang", "NamaGudang", "KodeBrgAsal", "NamaBrgAsal", "QtyA", "NilaiA",
                                                 "KodeBrgTujuan", "NamaBrgTujuan", "QtyT", "NilaiT", "Status"})
                            _title.AddRange({"DATA MUTASI BARANG", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "pgstockop"
                            _colHeader.AddRange({"KodeOpname", "Tgl", "KodeGudang", "NamaGudang", "Kat", "KodeBarang", "NamaBarang", "QtySys", "NilaiSys",
                                                 "QtyFisik", "NilaiFisik", "Status", "UserValid", "ValidDate"})
                            _title.AddRange({"DATA STOCK OPNAME", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case Else
                            Exit Sub
                    End Select

                    Using dd As New SaveFileDialog
                        dd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
                        dd.FilterIndex = 1
                        dd.FileName = dd.InitialDirectory
                        dd.RestoreDirectory = True : dd.AddExtension = True
                        If dd.ShowDialog = DialogResult.OK Then
                            If dd.FileName <> Nothing Then
                                Dim fk = dd.FileName.Split(".")
                                Dim _fileExt As String = IIf(dd.FilterIndex = 1, "xlsx", fk(fk.Count - 1))

                                Me.Cursor = Cursors.WaitCursor
                                If ExportExcel(_colHeader, _dt, _title, dd.FileName, _fileExt, _outputdir, _subtitle) Then
                                    If System.IO.File.Exists(_outputdir) = True Then
                                        MessageBox.Show("Export Data Sukses", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Process.Start(_outputdir)
                                    Else
                                        MessageBox.Show("File tidak dapat ditemukan", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                End If
                                Me.Cursor = Cursors.Default
                            End If
                        End If
                    End Using
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke data base.", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End Using
    End Sub

    'SEARCH
    Private Sub SearchData(Optional Page As Integer = 1)
        Me.Cursor = Cursors.WaitCursor
        SearchString = in_cari.Text
        SelectedDate1 = date_tglawal.Value : SelectedDate2 = date_tglakhir.Value
        LoadDataGrid(in_cari.Text, Page, date_tglawal.Value, date_tglakhir.Value)
        dgv_list.Focus()
        Me.Cursor = Cursors.Default
    End Sub

    'LOAD DETAIL INFORMATION
    Private Sub LoadTableTrans(IdTrans As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If

        Dim q As String = LoadTableTransQuery(DataTypeSelector())

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Using dtx = x.GetDataTable(String.Format(q, IdTrans))
                    For Each row As DataRow In dtx.Rows
                        With dgv_barang.Rows
                            Dim i = .Add
                            For y = 0 To dtx.Columns.Count - 1
                                .Item(i).Cells(y).Value = row.ItemArray(y)
                            Next
                        End With
                    Next
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke server", lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Function LoadTableTransQuery(TypeData As String) As String
        Dim q As String = ""

        Select Case TypeData
            Case "stok"
                q = "SELECT trans_barang_asal barang1, a.barang_nama barang1_n, trans_qty_asal trans_qty1, trans_sat_asal trans_sat1, " _
                    & "trans_barang_tujuan barang2, b.barang_nama barang2_n, trans_qty_tujuan trans_qty2, trans_sat_tujuan trans_sat2, trans_hpp_tujuan trans_hpp " _
                    & "FROM data_barang_mutasi_trans " _
                    & "LEFT JOIN data_barang_master a ON a.barang_kode=trans_barang_asal " _
                    & "LEFT JOIN data_barang_master b ON b.barang_kode=trans_barang_tujuan " _
                    & "WHERE trans_faktur='{0}' AND trans_status=1"

            Case "gudang"
                q = "SELECT trans_barang barang1, barang_nama barang1_n, trans_qty_besar trans_qty1, trans_satuan_besar trans_sat1, trans_qty_tengah trans_qty2, " _
                    & "trans_satuan_tengah trans_sat2, trans_qty_kecil trans_qty3, trans_satuan_kecil trans_sat3, trans_qty_tot, trans_hpp " _
                    & "FROM data_barang_stok_mutasi_trans " _
                    & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                    & "WHERE trans_faktur='{0}' AND trans_status=1"

            Case "opname"
                q = "SELECT trans_barang barang, barang_nama barang_n, CONCAT(trans_qty_sys, ' ', trans_satuan) qty_sys," _
                    & "getQTYDetail(trans_barang,trans_qty_sys,1) qty_sys_n, trans_qty_b_fis qty_b, trans_sat_b_fis sat_b, trans_qty_t_fis qty_t, trans_sat_t_fis sat_t," _
                    & "trans_qty_k_fis qty_k, trans_satuan sat_k, trans_qty_fisik qty_tot, trans_hpp hpp_sys, trans_hpp_fisik hpp_fis " _
                    & "FROM data_stok_opname_trans LEFT JOIN data_barang_master ON trans_barang=barang_kode " _
                    & "WHERE trans_status=1 AND trans_faktur='{0}'"

        End Select

        Return q
    End Function

    Private Sub ShowDetail(IdTrans As String)
        Try
            Me.Cursor = Cursors.AppStarting
            SetDataGrid(DataTypeSelector() & "_detail")
            LoadTableTrans(dgv_list.SelectedRows.Item(0).Cells(0).Value)
            dgv_barang.ClearSelection()
        Catch ex As Exception
            logError(ex, True)
            Dim text = "Tidak dapat menampilkan data" & Environment.NewLine & ex.Message
            MessageBox.Show(text, lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    'UI : CLOSE
    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        dgv_barang.Rows.Clear() : dgv_barang.Columns.Clear()
        main.tabcontrol.TabPages.Remove(tabpagename)
    End Sub

    'UI : DGV ITEM LIST
    Private Sub dgv_list_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_list.ColumnHeaderMouseClick
        dgv_list.ClearSelection()
    End Sub

    Private Sub dgv_list_ColumnHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_list.ColumnHeaderMouseDoubleClick
        dgv_list.ClearSelection()
    End Sub

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

    Private Sub dgv_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellClick
        If dgv_list.RowCount > 0 And dgv_list.SelectedRows.Count > 0 And e.RowIndex >= 0 Then
            ShowDetail(dgv_list.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    Private Sub dgv_list_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.RowEnter
        If dgv_list.RowCount > 0 And dgv_list.SelectedRows.Count > 0 And e.RowIndex >= 0 Then
            ShowDetail(dgv_list.SelectedRows.Item(0).Cells(0).Value)
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

    Private Sub mn_hapus_Click(sender As Object, e As EventArgs) Handles mn_cancel.Click
        If dgv_list.RowCount > 0 And dgv_list.SelectedRows.Count > 0 Then
            CancelData(dgv_list.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    Private Sub mn_refresh_Click(sender As Object, e As EventArgs) Handles mn_refresh.Click
        PerformRefresh()
    End Sub

    Private Sub mn_exportExcel_Click(sender As Object, e As EventArgs) Handles mn_exportExcel.Click
        Me.Cursor = Cursors.WaitCursor : ExportData(SearchString) : Me.Cursor = Cursors.Default
    End Sub

    Private Sub mn_uncancel_Click(sender As Object, e As EventArgs) Handles mn_uncancel.Click
        If dgv_list.RowCount > 0 And dgv_list.SelectedRows.Count > 0 Then
            UnCancelData(dgv_barang.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    Private Sub mn_delete_Click(sender As Object, e As EventArgs) Handles mn_delete.Click
        If dgv_list.RowCount > 0 And dgv_list.SelectedRows.Count > 0 Then
            DeleteData(dgv_list.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    Private Sub mn_search_Click(sender As Object, e As EventArgs) Handles mn_search.Click
        in_cari.Focus()
    End Sub

    'UI : BUTTON
    Private Sub bt_search_Click(sender As Object, e As EventArgs) Handles bt_search.Click
        SearchData()
    End Sub

    Private Sub bt_page_prev_Click(sender As Object, e As EventArgs) Handles bt_page_prev.Click, bt_page_first.Click
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
