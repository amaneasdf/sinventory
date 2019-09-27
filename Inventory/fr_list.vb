Public Class fr_list
    Public tabpagename As TabPage

    Private MaxPageData As Integer = 1
    Private SelectedPageData As Integer = 1
    Private SelectedDate1 As Date = Today
    Private SelectedDate2 As Date = Today
    Private SearchParam As String = String.Empty

    Public date_sw As Boolean = True
    Public search_sw As Boolean = True
    Public add_sw As Boolean = True
    Public edit_sw As Boolean = True
    Public deact_sw As Boolean = False
    Public cancel_sw As Boolean = False
    Public delete_sw As Boolean = False
    Public export_sw As Boolean = False
    Public print_sw As Boolean = False
    Public bayar_sw As Boolean = False
    Public valid_sw As Boolean = False
    Public entry_sw As Boolean = False

    'KEYSHORTCUT
    Protected Overrides Function ProcessKeyPreview(ByRef m As Message) As Boolean
        If m.Msg = &H100 Or m.Msg = &H101 Then  'WM_KEYDOWN / WM_KEYUP
            Dim key As Keys = m.WParam
            If key = Keys.F5 Then
                Me.PerformRefresh()
                Return True
            ElseIf key = Keys.N And My.Computer.Keyboard.CtrlKeyDown Then
                If add_sw Then addItem()
                Return True
            ElseIf key = Keys.F And My.Computer.Keyboard.CtrlKeyDown Then
                in_cari.Focus()
                Return True
            ElseIf key = Keys.O And My.Computer.Keyboard.CtrlKeyDown Then
                If edit_sw Then editItem()
                Return True
            ElseIf key = Keys.P And My.Computer.Keyboard.CtrlKeyDown Then
                If print_sw Then printItem()
                Return True
            End If
        End If

        Return MyBase.ProcessKeyPreview(m)
    End Function

    'SETUP TABPAGE CONTROL
    Public Sub setpage(page As TabPage)
        tabpagename = page : Me.Text = page.Text

        ControlSet() : setMenuSw()
        in_cari.Clear() : SearchParam = String.Empty
        If date_sw Then
            setDatePicker()
            LoadDataGrid("", 1, date_tglawal.Value, date_tglakhir.Value)
        Else
            LoadDataGrid("", 1)
        End If
    End Sub

    'SETUP DATE PICKER
    Private Sub setDatePicker()
        RemoveHandler date_tglawal.ValueChanged, AddressOf date_tglawal_ValueChanged
        RemoveHandler date_tglakhir.ValueChanged, AddressOf date_tglakhir_ValueChanged
        'date_tglawal.MaxDate = selectperiode.tglakhir
        'date_tglakhir.MinDate = selectperiode.tglawal
        If selectperiode.tglakhir < Today Then
            date_tglawal.Value = DateSerial(selectperiode.tglakhir.Year, selectperiode.tglakhir.Month, 1)
            date_tglakhir.Value = DateSerial(selectperiode.tglakhir.Year, selectperiode.tglakhir.Month + 1, 0)
        Else
            date_tglawal.Value = DateSerial(Today.Year, Today.Month, 1)
            date_tglakhir.Value = DateSerial(Today.Year, Today.Month + 1, 0)
        End If
        AddHandler date_tglawal.ValueChanged, AddressOf date_tglawal_ValueChanged
        AddHandler date_tglakhir.ValueChanged, AddressOf date_tglakhir_ValueChanged
        'date_tglawal.MinDate = selectperiode.tglawal
        'date_tglakhir.MaxDate = selectperiode.tglakhir
        date_tglawal.MinDate = DataListStartDate
        date_tglakhir.MaxDate = DataListEndDate
        date_tglawal.MaxDate = date_tglakhir.Value : date_tglakhir.MinDate = date_tglawal.Value
        SelectedDate1 = date_tglawal.Value : SelectedDate2 = date_tglakhir.Value
    End Sub

    'PERFORM REFRESH DATALIST - TODO SIMPLIFIED IT
    Public Sub PerformRefresh()
        If date_sw Then setDatePicker()
        If search_sw Then : in_cari.Clear() : SearchParam = String.Empty : End If

        If date_sw Then
            LoadDataGrid("", 1, date_tglawal.Value, date_tglakhir.Value)
        Else
            LoadDataGrid("", 1)
        End If

        ControlSet() : setMenuSw()
    End Sub

    'SET CONTROL/MENU SWITCH
    Private Sub ControlSet()
        Dim _datamaster() As String = {"pgsupplier", "pgbarang", "pggudang", "pgsales", "pgcusto", "pgperkiraan", "pguser", "pggroup"}
        Dim _datatrans() As String = {"pgpembelian", "pgreturbeli", "pgpenjualan", "pgreturjual", "pgpesanjual", "pghutangbayar", "pgpiutangbayar"}
        Dim _datahpawal() As String = {"pghutangawal", "pgpiutangawal"}
        Dim _datajurnal() As String = {"pgjurnalumum", "pgjurnalsesuai"}
        Dim _datagiro() As String = {"pgpiutangbgcair", "pghutangbgo"}

        If _datamaster.Contains(tabpagename.Name) Then
            deact_sw = True : date_sw = False
            export_sw = IIf({"pguser", "pggroup"}.Contains(tabpagename.Name), False, True)

        ElseIf _datatrans.Contains(tabpagename.Name) Then
            add_sw = IIf(selectperiode.closed = True, False, True)
            cancel_sw = IIf(selectperiode.closed = False, loggeduser.validasi_trans, False)
            export_sw = True
            print_sw = IIf({"pghutangbayar", "pgpiutangbayar"}.Contains(tabpagename.Name), False, True)
            If tabpagename.Name = "pgpesanjual" Then
                valid_sw = IIf(Not selectperiode.closed, loggeduser.validasi_trans, False)
                delete_sw = IIf(Not selectperiode.closed, loggeduser.validasi_trans, False)
            End If
            mn_edit.Text = IIf(selectperiode.closed = True, "Tampilkan Detail", "Edit Data")

        ElseIf _datahpawal.Contains(tabpagename.Name) Then
            Dim _kdMn As String = ""
            Select Case tabpagename.Name
                Case "pghutangawal" : _kdMn = "mn0402"
                Case "pgpiutangawal" : _kdMn = "mn0502"
                Case Else : Exit Sub
            End Select

            add_sw = False
            bayar_sw = IIf(selectperiode.closed, False, main.listkodemenu.Contains(_kdMn))
            'cancel_sw = IIf(selectperiode.closed = True, False, True)
            mn_edit.Text = "Tampilkan Detail"

        ElseIf _datagiro.Contains(tabpagename.Name) Then
            add_sw = False
            mn_edit.Text = IIf(selectperiode.closed = True, "Tampilkan Detail", "Edit Data")

        ElseIf tabpagename.Name = "pgperkiraan" Then
            add_sw = False : edit_sw = False ': export_sw = True
            date_sw = False

        ElseIf tabpagename.Name = "pgstok" Then
            add_sw = IIf(selectperiode.closed, False, True)
            edit_sw = IIf(selectperiode.closed, False, True)
            date_sw = False

        ElseIf tabpagename.Name = "pgkas" Then
            add_sw = IIf(selectperiode.closed = True, False, True)
            cancel_sw = IIf(selectperiode.closed = True, False, loggeduser.validasi_akun)
            mn_edit.Text = IIf(selectperiode.closed = True, "Tampilkan Detail", "Edit Data")

        ElseIf _datajurnal.Contains(tabpagename.Name) Then
            add_sw = False : entry_sw = True
            mn_edit.Text = "Lihat Detail"

        ElseIf tabpagename.Name = "pgtutupbuku" Then
            add_sw = False : date_sw = False
            deact_sw = True : delete_sw = True
            mn_edit.Text = "Lihat Detail"
            mn_deact.Text = "Reopen"
            mn_delete.Text = "Delete Closing"

        ElseIf tabpagename.Name = "pgadjstock" Then
            edit_sw = False
            delete_sw = IIf(selectperiode.closed, False, True)

        End If
    End Sub

    'SET MENULIST
    Private Sub setMenuSw()
        'Dim mn_NewData As New ToolStripMenuItem("Tambah++", Global.Inventory.My.Resources.Resources.toolbar_add_icon)
        ''NEW DATA MENU ITEM
        'If add_sw Then
        '    mnstrip_main.Items.Add(mn_NewData)
        '    AddHandler mn_NewData.Click, AddressOf mn_save_Click
        'Else
        '    If mnstrip_main.Items.Contains(mn_NewData) Then
        '        mnstrip_main.Items.Remove(mn_NewData)
        '        RemoveHandler mn_NewData.Click, AddressOf mn_save_Click
        '    End If
        'End If

        ''EDIT DATA MENU ITEM
        'If edit_sw Then

        'End If

        'menu bar
        mn_add.Visible = add_sw
        mn_edit.Visible = edit_sw
        mn_cari.Visible = search_sw
        mn_deact.Visible = deact_sw
        mn_export.Visible = export_sw
        mn_print.Visible = print_sw
        mn_bataljual.Visible = cancel_sw
        mn_cancelbatal.Visible = cancel_sw
        mn_bayar.Visible = bayar_sw
        mn_validasi.Visible = valid_sw
        mn_delete.Visible = delete_sw
        mn_addentry.Visible = entry_sw
        mn_delentry.Visible = entry_sw

        If Not date_sw Then
            in_cari.Location = date_tglawal.Location
            bt_search.Location = New Point(in_cari.Left + in_cari.Width - 1, in_cari.Top)
        Else
            in_cari.Location = New Point(386, 9)
            bt_search.Location = New Point(633, 9)
        End If
        date_tglakhir.Visible = date_sw : date_tglawal.Visible = date_sw
        lbl_date.Visible = date_sw
    End Sub

    'LOAD DATALIST
    Private Async Sub LoadDataGrid(Param As String, Page As Integer, Optional StartDate As Date = Nothing, Optional EndDate As Date = Nothing)
        Dim dt As New DataTable
        Dim _typedata As String = ""
        Dim _limitdata As Integer = 2000
        Dim DataCount As Integer = 0
        Dim PageInfo As String = "{0}-{1} dari {2} data."
        Dim _startdate As Date = IIf(StartDate = #12:00:00 AM#, selectperiode.tglawal, StartDate)
        Dim _enddate As Date = IIf(EndDate = #12:00:00 AM#, selectperiode.tglakhir, EndDate)

        setDoubleBuffered(Me.dgv_list, True)
        Select Case tabpagename.Name.ToString
            Case "pgsupplier" : _typedata = "supplier"
            Case "pgbarang" : _typedata = "barang"
            Case "pggudang" : _typedata = "gudang"
            Case "pgsales" : _typedata = "sales"
            Case "pgcusto" : _typedata = "custo"
            Case "pgperkiraan" : _typedata = "perkiraan"
            Case "pgpembelian" : _typedata = "beli"
            Case "pgreturbeli" : _typedata = "rbeli"
            Case "pgpesanjual" : _typedata = "pesanan"
            Case "pgpenjualan" : _typedata = "jual"
            Case "pgreturjual" : _typedata = "rjual"
            Case "pgstok" : _typedata = "stok" : _limitdata = 500
            Case "pgmutasigudang" : _typedata = "mutasigudang"
            Case "pgmutasistok" : _typedata = "mutasibarang"
            Case "pgstockop" : _typedata = "stockop"
            Case "pghutangawal" : _typedata = "hutangawal"
            Case "pghutangbayar" : _typedata = "hutangbayar"
            Case "pghutangbgo" : _typedata = "bgo"
            Case "pgpiutangawal" : _typedata = "piutangawal"
            Case "pgpiutangbayar" : _typedata = "piutangbayar"
            Case "pgpiutangbgcair" : _typedata = "bgi"
            Case "pgkas" : _typedata = "kas"
            Case "pgjurnalumum" : _typedata = "jurnalumum" : _limitdata = 250
            Case "pgjurnalsesuai" : _typedata = "jurnalsesuai" : _limitdata = 250
            Case "pgtutupbuku" : _typedata = "closing"
            Case "pggroup" : _typedata = "group"
            Case "pguser" : _typedata = "user"
            Case Else : Exit Sub
        End Select

        'GETTING DATA FROM DATA BASE (ASYNC/BACKGROUND THREAD)
        Dim done As Boolean = False
        Dim _switchCtrl() As Control = {bt_search, bt_cl, date_tglakhir, date_tglawal, bt_page_first, bt_page_last, bt_page_next, bt_page_prev}
        Try
            Me.Cursor = Cursors.WaitCursor : dgv_list.Cursor = Cursors.WaitCursor
            For Each ctr As Control In _switchCtrl : ctr.Enabled = False : Next
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
                            lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            done = True
        Finally
            If done Then
                Me.Cursor = Cursors.Default : dgv_list.Cursor = Cursors.Default
                For Each ctr As Control In _switchCtrl : ctr.Enabled = True : Next
                mnstrip_main.Enabled = True
            End If
        End Try
    End Sub

    Private Sub addItem()
        If add_sw = True Then
            Me.Cursor = Cursors.AppStarting

            Select Case tabpagename.Name.ToString
                Case "pgbarang" : Dim brg As New fr_barang_detail : brg.doLoadNew()
                Case "pgsupplier" : Dim spl As New fr_supplier_detail : spl.doLoadNew()
                Case "pggudang" : Dim x As New fr_gudang_detail : x.doLoadNew()
                Case "pgsales" : Dim x As New fr_sales_detail : x.doLoadNew()
                Case "pgcusto" : Dim x As New fr_custo_detail : x.doLoadNew()
                    'Case "pgperkiraan" : Dim x As New fr_perkiraan_detail : x.doLoadNew()
                Case "pgawalneraca" : fr_neracaawal_detail.ShowDialog()
                Case "pgpembelian" : Dim bd As New fr_beli_detail : bd.doLoadNew()
                Case "pgreturbeli" : Dim rb As New fr_beli_retur_detail : rb.doLoadNew()
                Case "pgpesanjual" : Dim rb As New fr_pesan_detail : rb.doLoadNew()
                Case "pgpenjualan" : Dim jd As New fr_jual_detail : jd.doLoadNew()
                Case "pgreturjual" : Dim rj As New fr_jual_retur_detail : rj.doLoadNew()
                Case "pgstok" : Dim st As New fr_stok_awal : st.doLoadNew()
                Case "pghutangbayar" : Dim frhb As New fr_hutang_bayar : frhb.doLoadNew()
                Case "pgpiutangbayar" : Dim frpb As New fr_piutang_bayar : frpb.doLoadNew()
                Case "pgkas" : Dim frkas As New fr_kas_detail : frkas.doLoadNew()
                    'Case "pgjurnalumum"
                    'Case "pgtutupbuku"
                Case "pggroup" : Dim frgrp As New fr_group_detail : frgrp.doLoadNew(loggeduser.admin_pc)
                Case "pguser" : Dim frusr As New fr_user_detail : frusr.doLoadNew(loggeduser.admin_pc)
                Case Else
                    MessageBox.Show("Maaf, fungsi tersebut masih dalam maintenance/pembuatan.", "Under Construction", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub editItem()
        If edit_sw = True Then
            Dim _isClosed As Boolean = False

            If dgv_list.RowCount > 0 And dgv_list.SelectedRows.Count > 0 Then
                Me.Cursor = Cursors.AppStarting
                consoleWriteLine(tabpagename.Name.ToString)
                Select Case tabpagename.Name.ToString
                    Case "pgbarang"
                        Dim detail As New fr_barang_detail
                        detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_master)

                    Case "pgsupplier"
                        Dim detail As New fr_supplier_detail
                        detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_master)

                    Case "pggudang"
                        Dim detail As New fr_gudang_detail
                        detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_master)

                    Case "pgsales"
                        Dim detail As New fr_sales_detail
                        detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_master)

                    Case "pgcusto"
                        Dim detail As New fr_custo_detail
                        detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_master)

                        'Case "pgperkiraan"
                        '    Dim detail As New fr_perkiraan_detail
                        '    detail.doLoadView(dgv_list.selectedRows.Item(0).Cells(0).Value)

                    Case "pgpembelian"
                        Dim detail As New fr_beli_detail
                        'If selectperiode.closed Then
                        '    detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        'Else
                        detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
                        'End If

                    Case "pgreturbeli"
                        Dim detail As New fr_beli_retur_detail
                        'If selectperiode.closed Then
                        '    detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        'Else
                        detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
                        'End If

                    Case "pgpesanjual"
                        Dim detail As New fr_pesan_detail
                        'If selectperiode.closed Then
                        '    detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        'Else
                        detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
                        'End If

                    Case "pgpenjualan"
                        Dim detail As New fr_jual_detail
                        'If selectperiode.closed Then
                        '    detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        'Else
                        detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
                        'End If

                    Case "pgreturjual"
                        Dim detail As New fr_jual_retur_detail
                        'If selectperiode.closed Then
                        '    detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        'Else
                        detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
                        'End If

                    Case "pgstok"
                        'Dim detail As New fr_stok_awal
                        'If selectperiode.closed Then
                        '    detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        'Else
                        '    detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
                        'End If

                    Case "pghutangawal"
                        Dim detail As New fr_hutang_awal
                        detail.DoLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)

                    Case "pghutangbayar"
                        Dim detail As New fr_hutang_bayar
                        If selectperiode.closed Then
                            detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        Else
                            detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
                        End If

                    Case "pghutangbgo"
                        Dim detail As New fr_giro
                        With detail
                            .Text = "Detail Giro : " & dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .do_load("OUT", dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        End With

                    Case "pgpiutangawal"
                        Dim detail As New fr_piutang_awal
                        detail.DoLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)

                    Case "pgpiutangbayar"
                        Dim detail As New fr_piutang_bayar
                        If selectperiode.closed Then
                            detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        Else
                            detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
                        End If

                    Case "pgpiutangbgcair"
                        Dim detail As New fr_giro
                        With detail
                            .Text = "Detail Giro : " & dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .do_load("IN", dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        End With

                    Case "pgkas"
                        Dim detail As New fr_kas_detail
                        If selectperiode.closed Then
                            detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(1).Value)
                        Else
                            detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(1).Value, loggeduser.allowedit_transact)
                        End If

                    Case "pgjurnalumum"
                        Dim detail As New fr_jurnal_u_det
                        detail.doLoad(dgv_list.SelectedRows.Item(0).Cells(0).Value)

                    Case "pgjurnalsesuai"
                        Dim detail As New fr_jurnal_p_entry
                        If selectperiode.closed Then
                            detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        Else
                            detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_akun)
                        End If

                    Case "pgtutupbuku"
                        Dim detail As New fr_closing
                        detail.DoLoadDialog(dgv_list.SelectedRows.Item(0).Cells(0).Value)

                        'Case "pgadjstock"

                    Case "pggroup"
                        Dim detail As New fr_group_detail
                        detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.admin_pc)

                    Case "pguser"
                        Dim detail As New fr_user_detail
                        detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.admin_pc)
                    Case Else
                        MessageBox.Show("Maaf, fungsi tersebut masih dalam maintenance/pembuatan.", "Under Construction", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select
                Me.Cursor = Cursors.Default
            Else
                MessageBox.Show("Data tidak tersedia")
            End If
        End If
    End Sub

    Private Sub bayarItem()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        If selectperiode.closed Then Exit Sub

        Dim _kode As String = ""
        Dim q As String = ""
        Dim ck As Boolean = False

        Select Case tabpagename.Name.ToString
            Case "pgpiutangawal"
                Dim x As New fr_piutang_bayar
                _kode = dgv_list.SelectedRows.Item(0).Cells(0).Value

                Using dd = MainConnection
                    dd.Open() : If dd.ConnectionState = ConnectionState.Open Then
                        q = "SELECT piutang_status_lunas, piutang_status_approve FROM data_piutang_awal WHERE piutang_faktur='{0}'"
                        Using rdx = dd.ReadCommand(String.Format(q, _kode))
                            Dim red = rdx.Read
                            If red And rdx.HasRows Then
                                If rdx.Item(0) = 1 Then
                                    MessageBox.Show("Piutang " & _kode & " sudah lunas.", "Pembayaran Piutang", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Sub
                                ElseIf rdx.Item(1) = 1 Then
                                    MessageBox.Show("Terdapat pembayaran yg belum diproses untuk piutang " & _kode & ". Harap cek kembali data transaksi pembayaran.",
                                                    "Pembayaran Piutang", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Exit Sub
                                End If
                            Else
                                MessageBox.Show("Data piutang tidak dapat ditemukan.", "Pembayaran Piutang", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End Using
                        q = "SELECT GetPiutangSaldoAwal('piutang', '{0}', ADDDATE(CURDATE(),1))"
                        Dim _valPiutang As Decimal = CDec(dd.ExecScalar(String.Format(q, _kode)))
                        q = "SELECT  GetPiutangSaldoAwal('giro', '{0}', ADDDATE(CURDATE(),1))"
                        Dim _valGiro As Decimal = CDec(dd.ExecScalar(String.Format(q, _kode)))
                        If _valPiutang = 0 Then
                            If _valGiro = 0 Then
                                MessageBox.Show("Piutang " & _kode & " sudah lunas.", "Pembayaran Piutang", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            Else
                                Dim _c = MessageBox.Show("Terdapat giro yg belum dicairkan untuk piutang tsb." & Environment.NewLine & "Lanjutkan proses pembayaran?",
                                                         "Pembayaran Piutang", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                If _c = DialogResult.No Then Exit Sub
                            End If
                        End If

                        x.doLoadNew()
                        q = "SELECT piutang_custo, customer_nama, piutang_sales, salesman_nama, GetPiutangSaldoAwal('titipan', '{0}', ADDDATE(CURDATE(),1)), " _
                            & "GetPiutangSaldoAwal('piutang', '{0}', ADDDATE(CURDATE(),1)), piutang_awal, piutang_jt,piutang_pajak " _
                            & "FROM data_piutang_awal " _
                            & "LEFT JOIN data_customer_master ON piutang_custo=customer_kode " _
                            & "LEFT JOIN data_salesman_master ON salesman_kode=piutang_sales " _
                            & "WHERE piutang_faktur='{0}'"
                        Using rdx = dd.ReadCommand(String.Format(q, _kode))
                            Dim red = rdx.Read
                            If red And rdx.HasRows Then
                                x.cb_pajak.SelectedValue = rdx.Item("piutang_pajak")
                                x.in_custo.Text = rdx.Item(0)
                                x.in_custo_n.Text = rdx.Item(1)
                                x.in_sales.Text = rdx.Item(2)
                                x.in_sales_n.Text = rdx.Item(3)
                                x.in_saldotitipan.Text = commaThousand(rdx.Item(4))

                                x.in_faktur.Text = _kode
                                x.in_tgl_jtfaktur.Text = CDate(rdx.Item(7)).ToString("dd/MM/yyyy")
                                x.in_sisafaktur.Text = commaThousand(rdx.Item(5))
                                x._totalhutang = rdx.Item(6)
                            Else
                                MessageBox.Show("Data piutang tidak dapat ditemukan.", "Pembayaran Piutang", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End Using
                    Else
                        MessageBox.Show("Tidak dapat terhubung ke database.", "Pembayaran Piutang", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using

            Case "pghutangawal"
                Dim x As New fr_hutang_bayar
                _kode = dgv_list.SelectedRows.Item(0).Cells(0).Value

                Using dd = MainConnection
                    dd.Open() : If dd.ConnectionState = ConnectionState.Open Then
                        Try
                            q = "SELECT hutang_status_lunas FROM data_hutang_awal WHERE hutang_faktur='{0}'"
                            Dim _ck = CInt(dd.ExecScalar(String.Format(q, _kode)))
                            If _ck = 1 Then
                                MessageBox.Show("Piutang " & _kode & " sudah lunas.", "Pembayaran Piutang", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If
                            q = "SELECT GetHutangSaldoAwal('hutang', '{0}', ADDDATE(CURDATE(),1))"
                            Dim _valHutang As Decimal = CDec(dd.ExecScalar(String.Format(q, _kode)))
                            q = "SELECT  GetHutangSaldoAwal('giro', '{0}', ADDDATE(CURDATE(),1))"
                            Dim _valGiro As Decimal = CDec(dd.ExecScalar(String.Format(q, _kode)))
                            If _valHutang = 0 Then
                                If _valGiro = 0 Then
                                    MessageBox.Show("Hutang " & _kode & " sudah lunas.", "Pembayaran Hutang", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Exit Sub
                                Else
                                    Dim _c = MessageBox.Show("Terdapat giro yg belum dicairkan untuk hutang tsb." & Environment.NewLine & "Lanjutkan proses pembayaran?",
                                                             "Pembayaran Hutang", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    If _c = DialogResult.No Then Exit Sub
                                End If
                            End If
                        Catch ex As Exception
                            logError(ex, True)
                            MessageBox.Show("Terjadi kesalahan saat mengambil data hutang.", "Pembayaran Hutang", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try

                        x.doLoadNew()
                        q = "SELECT hutang_supplier, supplier_nama, GetHutangSaldoAwal('titipan', '{0}', ADDDATE(CURDATE(),1)), " _
                            & " GetHutangSaldoAwal('hutang', '{0}', ADDDATE(CURDATE(),1)), hutang_awal, hutang_tgl_jt, hutang_pajak " _
                            & "FROM data_hutang_awal " _
                            & "LEFT JOIN data_supplier_master ON hutang_supplier=supplier_kode " _
                            & "WHERE hutang_faktur='{0}'"
                        Using rdx = dd.ReadCommand(String.Format(q, _kode))
                            Dim red = rdx.Read
                            If red And rdx.HasRows Then
                                x.cb_pajak.SelectedValue = rdx.Item("hutang_pajak")
                                x.in_supplier.Text = rdx.Item(0)
                                x.in_supplier_n.Text = rdx.Item(1)
                                x.in_saldotitipan.Text = commaThousand(rdx.Item(2))

                                x.in_faktur.Text = _kode
                                x.in_tgl_jtfaktur.Text = CDate(rdx.Item(5)).ToString("dd/MM/yyyy")
                                x.in_sisafaktur.Text = commaThousand(rdx.Item(3))
                                x._totalhutang = rdx.Item(4)
                            Else
                                MessageBox.Show("Data piutang tidak dapat ditemukan.", "Pembayaran Piutang", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End Using
                    Else
                        MessageBox.Show("Tidak dapat terhubung ke database.", "Pembayaran Piutang", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            Case Else
                Exit Sub
        End Select

    End Sub

    Private Sub printItem()
        If print_sw = True Then
            If dgv_list.RowCount > 0 Then
                Me.Cursor = Cursors.AppStarting
                consoleWriteLine(tabpagename.Name.ToString)
                Dim x As String = LCase(tabpagename.Name.ToString)

                Me.Cursor = Cursors.WaitCursor
                Dim tipe, kode As String
                Select Case x
                    Case "pgpembelian", "pgreturbeli", "pgpenjualan", "pgreturjual"
                        Select Case x
                            Case "pgpembelian"
                                tipe = "beli"
                                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            Case "pgreturbeli"
                                tipe = "returbeli"
                                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            Case "pgpenjualan"
                                tipe = "jual"
                                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            Case "pgreturjual"
                                tipe = "returjual"
                                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            Case Else
                                tipe = Nothing
                                kode = Nothing
                                Me.Cursor = Cursors.Default
                                Exit Sub
                        End Select
                        Using nota As New fr_nota_dialog
                            nota.do_load(tipe, kode)
                        End Using
                End Select
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    'EXPORT DATA TO EXCEL FILE
    Private Sub exportItem(ParamString As String)
        If export_sw = True Then
            Dim _q As String = ""
            Dim _qwh, _qorder, _qjoin As String

            If Not String.IsNullOrWhiteSpace(ParamString) Then
                ParamString = mysqlQueryFriendlyStringFeed(ParamString)
                ParamString = Trim(ParamString).Replace(" ", ".+").Replace("(", "[(]").Replace(")", "[)]")
            End If

            Select Case tabpagename.Name
                Case "pgbarang"
                    _q = "SELECT barang_kode, barang_nama, barang_supplier, GetMasterNama('supplier',barang_supplier), jenis_nama, kategori_nama, " _
                        & "pajak.ref_text, barang_satuan_besar, barang_satuan_besar_jumlah, barang_satuan_tengah, barang_satuan_tengah_jumlah, " _
                        & "barang_satuan_kecil, barang_harga_beli, barang_harga_jual, barang_harga_jual_mt, barang_harga_jual_horeka, barang_harga_jual_rita, " _
                        & "state.ref_text FROM data_barang_master"
                    _qjoin = " LEFT JOIN data_barang_jenis ON jenis_kode=barang_jenis " _
                            & "LEFT JOIN ref_barang_kategori ON kategori_kode=IFNULL(IF(barang_kategori='',NULL,barang_kategori),'000') " _
                            & "LEFT JOIN ref_jenis state ON state.ref_kode=barang_status AND state.ref_status=1 AND state.ref_type='status_master' " _
                            & "LEFT JOIN ref_jenis pajak ON pajak.ref_kode=barang_pajak AND pajak.ref_status=1 AND pajak.ref_type='barang_pajak'"
                    _qorder = " ORDER BY barang_kode"
                    _qwh = " WHERE barang_status IN (0,1)"
                    If Not String.IsNullOrWhiteSpace(ParamString) Then
                        _qwh += String.Join("'" & ParamString & "'", {" AND(barang_kode REGEXP ", " OR barang_nama REGEXP ",
                                                                      " OR jenis_nama REGEXP ", " OR kategori_nama REGEXP ",
                                                                      " OR barang_supplier REGEXP ", " OR GetMasterNama('supplier',barang_supplier) REGEXP ",
                                                                      " OR state.ref_text REGEXP ", " OR pajak.ref_text REGEXP ", ")"})
                    End If

                Case "pgsupplier"
                    _q = "SELECT supplier_kode, supplier_nama, supplier_alamat, supplier_telpon1, supplier_telpon2, supplier_fax, supplier_email, supplier_cp, " _
                        & "supplier_npwp, state.ref_text FROM data_supplier_master"
                    _qjoin = " LEFT JOIN ref_jenis state ON state.ref_kode=supplier_status AND state.ref_status=1 AND state.ref_type='status_master'"
                    _qorder = " ORDER BY supplier_kode"
                    _qwh = " WHERE supplier_status IN (0,1)"
                    If Not String.IsNullOrWhiteSpace(ParamString) Then
                        _qwh += String.Join("'" & ParamString & "'", {" AND(supplier_kode REGEXP ", " OR supplier_nama REGEXP ",
                                                                      " OR supplier_alamat REGEXP ", " OR supplier_cp REGEXP ",
                                                                      " OR state.ref_text REGEXP ", ")"})
                    End If

                Case "pggudang"
                    _q = "SELECT gudang_kode, gudang_nama, gudang_alamat, gudang_ket, state.ref_text FROM data_barang_gudang"
                    _qjoin = " LEFT JOIN ref_jenis state ON state.ref_kode=gudang_status AND state.ref_status=1 AND state.ref_type='status_master'"
                    _qorder = " ORDER BY gudang_kode"
                    _qwh = " WHERE gudang_status IN (0,1)"
                    If Not String.IsNullOrWhiteSpace(ParamString) Then
                        _qwh += String.Join("'" & ParamString & "'", {" AND(gudang_kode REGEXP ", " OR gudang_nama REGEXP ",
                                                                      " OR gudang_alamat REGEXP "," OR state.ref_text REGEXP ", ")"})
                    End If

                Case "pgsales"
                    _q = "SELECT salesman_kode, salesman_nama, jenis.ref_text, salesman_alamat, salesman_hp, salesman_fax, salesman_email, salesman_nik, " _
                        & "CONCAT_WS('-', salesman_bank_rekening, salesman_bank_nama) salesman_rek, salesman_bank_atasnama, state.ref_text " _
                        & "FROM data_salesman_master"
                    _qjoin = " LEFT JOIN ref_jenis jenis ON jenis.ref_kode=salesman_jenis AND jenis.ref_status=1 AND jenis.ref_type='sales_jenis' " _
                            & "LEFT JOIN ref_jenis state ON state.ref_kode=salesman_status AND state.ref_status=1 AND state.ref_type='status_master'"
                    _qorder = " ORDER BY salesman_kode"
                    _qwh = " WHERE salesman_status IN (0,1)"
                    If Not String.IsNullOrWhiteSpace(ParamString) Then
                        _qwh += String.Join("'" & ParamString & "'", {" AND(salesman_kode REGEXP ", " OR salesman_nama REGEXP ", " OR salesman_alamat REGEXP ",
                                                                      " OR state.ref_text REGEXP ", " OR jenis.ref_text REGEXP ", ")"})
                    End If

                Case "pgcusto"
                    _q = "SELECT customer_kode, customer_nama, CONCAT(UCASE(LEFT(jenis_nama,1)),SUBSTRING(jenis_nama,2)), " _
                        & "TRIM(BOTH ' Blok  No.000 RT.000/000' FROM (CONCAT(REPLACE(REPLACE(customer_alamat,CHAR(13),' '),CHAR(10),' '), " _
                        & " ' Blok ',IFNULL(customer_alamat_blok,''), ' No.',LPAD(customer_alamat_nomor,3,0), " _
                        & " ' RT.',LPAD(customer_alamat_rt,3,0), '/',LPAD(customer_alamat_rw,3,0)))) customer_alamat, " _
                        & "customer_kecamatan, customer_kabupaten, customer_pasar, customer_provinsi, customer_kodepos, customer_telpon, customer_fax, customer_cp, " _
                        & "customer_npwp, customer_pajak_nama, customer_pajak_jabatan, customer_pajak_alamat, state.ref_text " _
                        & "FROM data_customer_master"
                    _qjoin = " LEFT JOIN data_customer_jenis ON customer_jenis=jenis_kode " _
                            & "LEFT JOIN ref_jenis state ON state.ref_kode=customer_status AND state.ref_status=1 AND state.ref_type='status_master'"
                    _qorder = " ORDER BY customer_kode"
                    _qwh = " WHERE customer_status IN (0,1)"
                    If Not String.IsNullOrWhiteSpace(ParamString) Then
                        _qwh += String.Join("'" & ParamString & "'", {" AND(customer_kode REGEXP ", " OR customer_nama REGEXP ", " OR customer_alamat REGEXP ",
                                                                      " OR customer_kecamatan REGEXP ", " OR customer_kabupaten REGEXP ", " OR customer_pasar REGEXP ",
                                                                      " OR jenis_nama REGEXP ", " OR state.ref_text REGEXP ", ")"})
                    End If

                Case Else : Exit Sub
            End Select
            _q += _qjoin + _qwh + _qorder
            exportToExcel(_q)
        End If
    End Sub

    Private Sub exportItemTrans(ParamString As String)
        If export_sw Then
            Dim _q As String = ""
            Dim _qwh, _qorder, _qjoin As String

            If Not String.IsNullOrWhiteSpace(ParamString) Then
                ParamString = mysqlQueryFriendlyStringFeed(ParamString)
                ParamString = Trim(ParamString).Replace(" ", ".+").Replace("(", "[(]").Replace(")", "[)]")
            End If

            Select Case tabpagename.Name
                Case "pgpembelian"
                    _q = "SELECT faktur_kode, faktur_tanggal_trans, faktur_supplier, GetMasterNama('supplier',faktur_supplier) faktur_supplier_n, " _
                        & "faktur_gudang, GetMasterNama('gudang',faktur_gudang) faktur_gudang_n, faktur_term, ppn.ref_text jenispajak, " _
                        & "trans_barang, GetMasterNama('barang',trans_barang) trans_barang_n, trans_harga_beli, trans_qty, trans_satuan, trans_satuan_type, " _
                        & "@td:=ROUND(CountTotalDiskonJualItem(@hb:=trans_harga_beli*trans_qty, trans_disc_rupiah*trans_qty, " _
                        & " trans_disc1, trans_disc2, trans_disc3, 0, 0),2) trans_disctot, ROUND(@hjb - @td,2) trans_netto, " _
                        & "trans_disc1, trans_disc2, trans_disc3, trans_disc_rupiah, trans_state.ref_text " _
                        & "FROM( " _
                        & " SELECT faktur_kode, faktur_tanggal_trans, faktur_supplier, faktur_gudang, faktur_term, faktur_ppn_jenis, faktur_status " _
                        & " FROM data_pembelian_faktur WHERE faktur_status IN (0,1,2) AND faktur_tanggal_trans BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}'{2}" _
                        & ") data_beli "
                    If Not String.IsNullOrWhiteSpace(ParamString) Then
                        _qwh = String.Join("'" & ParamString & "'", {"WHERE (faktur_kode REGEXP ", " OR DATE_FORMAT(faktur_tanggal_trans,'%d/%m/%Y') REGEXP ",
                                                                     " OR faktur_supplier REGEXP ", " OR GetMasterNama('supplier',faktur_supplier) REGEXP ",
                                                                     " OR faktur_gudang REGEXP ", " OR GetMasterNama('gudang',faktur_gudang) REGEXP ",
                                                                     " OR ppn.ref_text REGEXP ", " OR trans_state.ref_text REGEXP ", ")"})
                    Else
                        _qwh = ""
                    End If
                    _qorder = " ORDER BY faktur_tanggal_trans, faktur_kode "
                    _qjoin = " LEFT JOIN data_pembelian_trans ON faktur_kode=trans_faktur AND trans_status=1 " _
                            & "LEFT JOIN ref_jenis ppn ON faktur_ppn_jenis=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans' " _
                            & "LEFT JOIN ref_jenis trans_state ON faktur_status=trans_state.ref_kode AND trans_state.ref_status=1 AND trans_state.ref_type='status_trans'"
                    _q = String.Format(_q, SelectedDate1, SelectedDate2, _qorder) + _qjoin + _qwh

                Case "pgreturbeli"
                    _q = "SELECT faktur_kode_bukti, faktur_tanggal_trans, faktur_supplier, GetMasterNama('supplier',faktur_supplier) faktur_supplier_n, " _
                         & "faktur_gudang, GetMasterNama('gudang',faktur_gudang) faktur_gudang_n, " _
                         & "ppn.ref_text jenispajak, bayar.ref_text jenisbayar, faktur_kode_faktur, faktur_kode_exfaktur, " _
                         & "trans_barang, GetMasterNama('barang',trans_barang) trans_barang_n, " _
                         & "trans_harga_retur, trans_qty, trans_satuan, trans_satuan_type, trans_diskon, " _
                         & "@td:=ROUND((@hr:=trans_harga_retur*trans_qty)*(trans_diskon/100) ,2) trans_disctot, @hr-@td trans_subtot, trans_state.ref_text " _
                         & "FROM( " _
                         & " SELECT faktur_kode_bukti, faktur_tanggal_trans, faktur_supplier, faktur_gudang, faktur_kode_faktur, " _
                         & "  faktur_kode_exfaktur, faktur_jen_bayar, faktur_ppn_jenis, faktur_status " _
                         & " FROM data_pembelian_retur_faktur WHERE faktur_status IN (0,1,2) AND faktur_tanggal_trans BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}'{2}" _
                         & ") data_retur "
                    If Not String.IsNullOrWhiteSpace(ParamString) Then
                        _qwh = String.Join("'" & ParamString & "'", {"WHERE (faktur_kode_bukti REGEXP ",
                                                                     " OR DATE_FORMAT(faktur_tanggal_trans,'%d/%m/%Y') REGEXP ",
                                                                     " OR faktur_supplier REGEXP ", " OR GetMasterNama('supplier',faktur_supplier) REGEXP ",
                                                                     " OR faktur_gudang REGEXP ", " OR GetMasterNama('gudang',faktur_gudang) REGEXP ",
                                                                     " OR ppn.ref_text REGEXP ", " OR trans_state.ref_text REGEXP ",
                                                                     " OR bayar.ref_text REGEXP ", " OR faktur_kode_faktur REGEXP ", ")"})
                    Else
                        _qwh = ""
                    End If
                    _qorder = " ORDER BY faktur_tanggal_trans, faktur_kode_bukti "
                    _qjoin = " LEFT JOIN data_pembelian_retur_trans ON faktur_kode_bukti=trans_faktur AND trans_status=1 " _
                            & "LEFT JOIN ref_jenis ppn ON faktur_ppn_jenis=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans' " _
                            & "LEFT JOIN ref_jenis bayar ON faktur_jen_bayar=bayar.ref_kode AND bayar.ref_status=1 AND bayar.ref_type='bayar_retur' " _
                            & "LEFT JOIN ref_jenis trans_state ON faktur_status=trans_state.ref_kode AND trans_state.ref_status=1 AND trans_state.ref_type='status_trans'"
                    _q = String.Format(_q, SelectedDate1, SelectedDate2, _qorder) + _qjoin + _qwh


                Case "pgpenjualan"
                    _q = "SELECT faktur_kode, faktur_tanggal_trans, faktur_sales, GetMasterNama('sales',faktur_sales) faktur_sales_n, " _
                        & "faktur_customer, GetMasterNama('custo',faktur_customer) faktur_custo_n, " _
                        & "faktur_gudang, GetMasterNama('gudang',faktur_gudang) faktur_gudang_n, faktur_term, ppn.ref_text jenispajak, " _
                        & "trans_barang, GetMasterNama('barang',trans_barang) trans_barang_n, trans_harga_jual, trans_qty, trans_satuan, trans_satuan_type, " _
                        & "@td:=ROUND(CountTotalDiskonJualItem(@hj:=trans_harga_jual*trans_qty, trans_disc_rupiah*trans_qty, " _
                        & " trans_disc1, trans_disc2, trans_disc3, trans_disc4, trans_disc5),2) trans_disctot, ROUND(@hj - @td,2) trans_netto, " _
                        & "trans_disc1, trans_disc2, trans_disc3, trans_disc4, trans_disc5, trans_disc_rupiah, trans_state.ref_text " _
                        & "FROM( " _
                        & " SELECT faktur_kode, faktur_tanggal_trans, faktur_sales, faktur_customer, faktur_gudang, faktur_term, faktur_ppn_jenis, faktur_status " _
                        & " FROM data_penjualan_faktur WHERE faktur_tanggal_trans BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}' AND faktur_status<9{2}" _
                        & ") data_jual "
                    If Not String.IsNullOrWhiteSpace(ParamString) Then
                        _qwh = String.Join("'" & ParamString & "'", {"WHERE (faktur_kode REGEXP ", " OR DATE_FORMAT(faktur_tanggal_trans,'%d/%m/%Y') REGEXP ",
                                                                     " OR faktur_customer REGEXP ", " OR GetMasterNama('custo',faktur_customer) REGEXP ",
                                                                     " OR faktur_sales REGEXP ", " OR GetMasterNama('sales',faktur_sales) REGEXP ",
                                                                     " OR faktur_gudang REGEXP ", " OR GetMasterNama('gudang',faktur_gudang) REGEXP ",
                                                                     " OR ppn.ref_text REGEXP ", " OR trans_state.ref_text REGEXP ", ")"})
                    Else
                        _qwh = ""
                    End If
                    _qorder = " ORDER BY faktur_tanggal_trans, faktur_kode "
                    _qjoin = " LEFT JOIN data_penjualan_trans ON faktur_kode=trans_faktur AND trans_status=1 " _
                            & "LEFT JOIN ref_jenis ppn ON faktur_ppn_jenis=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans' " _
                            & "LEFT JOIN ref_jenis trans_state ON faktur_status=trans_state.ref_kode AND trans_state.ref_status=1 AND trans_state.ref_type='status_trans'"
                    _q = String.Format(_q, SelectedDate1, SelectedDate2, _qorder) + _qjoin + _qwh

                Case "pgreturjual"
                    _q = "SELECT faktur_kode_bukti, faktur_tanggal_trans, faktur_sales, GetMasterNama('sales',faktur_sales) faktur_sales_n, " _
                        & "faktur_custo, GetMasterNama('custo',faktur_custo) faktur_custo_n, " _
                        & "faktur_gudang, GetMasterNama('gudang',faktur_gudang) faktur_gudang_n, " _
                        & "ppn.ref_text jenispajak, bayar.ref_text jenisbayar, faktur_kode_faktur, faktur_kode_exfaktur, " _
                        & "trans_barang, GetMasterNama('barang',trans_barang) trans_barang_n, " _
                        & "trans_harga_retur, trans_qty, trans_satuan, trans_satuan_type, trans_diskon, " _
                        & "@td:=ROUND((@hr:=trans_harga_retur*trans_qty)*(trans_diskon/100) ,2) trans_disctot, @hr-@td trans_subtot, trans_state.ref_text " _
                        & "FROM( " _
                        & " SELECT faktur_kode_bukti, faktur_tanggal_trans, faktur_sales, faktur_custo, faktur_gudang, faktur_kode_faktur, " _
                        & "  faktur_kode_exfaktur, faktur_jen_bayar, faktur_ppn_jenis, faktur_status " _
                        & " FROM data_penjualan_retur_faktur WHERE faktur_status IN (0,1,2) AND faktur_tanggal_trans BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}'{2}" _
                        & ") data_retur "
                    If Not String.IsNullOrWhiteSpace(ParamString) Then
                        _qwh = String.Join("'" & ParamString & "'", {"WHERE (faktur_kode_bukti REGEXP ",
                                                                     " OR DATE_FORMAT(faktur_tanggal_trans,'%d/%m/%Y') REGEXP ",
                                                                     " OR faktur_custo REGEXP ", " OR GetMasterNama('custo',faktur_custo) REGEXP ",
                                                                     " OR faktur_sales REGEXP ", " OR GetMasterNama('sales',faktur_sales) REGEXP ",
                                                                     " OR faktur_gudang REGEXP ", " OR GetMasterNama('gudang',faktur_gudang) REGEXP ",
                                                                     " OR ppn.ref_text REGEXP ", " OR trans_state.ref_text REGEXP ",
                                                                     " OR bayar.ref_text REGEXP ", " OR faktur_kode_faktur REGEXP ", ")"})
                    Else
                        _qwh = ""
                    End If
                    _qorder = " ORDER BY faktur_tanggal_trans, faktur_kode_bukti "
                    _qjoin = " LEFT JOIN data_penjualan_retur_trans ON faktur_kode_bukti=trans_faktur AND trans_status=1 " _
                            & "LEFT JOIN ref_jenis ppn ON faktur_ppn_jenis=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans' " _
                            & "LEFT JOIN ref_jenis bayar ON faktur_jen_bayar=bayar.ref_kode AND bayar.ref_status=1 AND bayar.ref_type='bayar_retur' " _
                            & "LEFT JOIN ref_jenis trans_state ON faktur_status=trans_state.ref_kode AND trans_state.ref_status=1 AND trans_state.ref_type='status_trans'"
                    _q = String.Format(_q, SelectedDate1, SelectedDate2, _qorder) + _qjoin + _qwh

                Case "pghutangbayar"
                    _q = "SELECT h_bayar_bukti, h_bayar_tgl_bayar, h_bayar_supplier, GetMasterNama('supplier',h_bayar_supplier) h_bayar_supplier_n, " _
                        & "IFNULL(ppn.ref_text,'ERROR') jenispajak, h_bayar_jenis_bayar, h_bayar_akun, perk_nama_akun, h_bayar_giro_no, " _
                        & "IF(IFNULL(h_bayar_giro_no,'')='', NULL, h_bayar_tgl_jt) h_bayar_giro_tgl, h_trans_faktur, h_trans_sisa, h_trans_nilaibayar, " _
                        & "IFNULL(trans_state.ref_text,'ERROR') status " _
                        & "FROM( " _
                        & " SELECT h_bayar_bukti, h_bayar_tgl_bayar, h_bayar_supplier, h_bayar_pajak, h_bayar_jenis_bayar, " _
                        & "  h_bayar_akun, h_bayar_giro_no, h_bayar_tgl_jt, h_bayar_status " _
                        & " FROM data_hutang_bayar WHERE h_bayar_status IN (0,1,2) AND h_bayar_tgl_bayar BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}' " _
                        & ") data_bayar "
                    If Not String.IsNullOrWhiteSpace(ParamString) Then
                        _qwh = String.Join("'" & ParamString & "'", {"WHERE (h_bayar_bukti REGEXP ",
                                                                     " OR DATE_FORMAT(h_bayar_tgl_bayar,'%d/%m/%Y') REGEXP ",
                                                                     " OR h_bayar_supplier REGEXP ", " OR GetMasterNama('supplier',h_bayar_supplier) REGEXP ",
                                                                     " OR h_bayar_jenis_bayar REGEXP ", " OR ppn.ref_text REGEXP ",
                                                                     " OR trans_state.ref_text REGEXP ", ")"})
                    Else
                        _qwh = ""
                    End If
                    _qorder = " ORDER BY h_bayar_tgl_bayar, h_bayar_bukti"
                    _qjoin = " LEFT JOIN data_hutang_bayar_trans ON h_bayar_bukti=h_trans_bukti AND h_trans_status=1 " _
                            & "LEFT JOIN data_perkiraan ON perk_kode=h_bayar_akun " _
                            & "LEFT JOIN ref_jenis ppn ON h_bayar_pajak=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans2' " _
                            & "LEFT JOIN ref_jenis trans_state ON h_bayar_status=trans_state.ref_kode AND trans_state.ref_status=1 AND trans_state.ref_type='status_trans'"
                    _q = String.Format(_q, SelectedDate1, SelectedDate2, _qorder) + _qjoin + _qwh + _qorder

                Case "pgpiutangbayar"
                    _q = "SELECT p_bayar_bukti, p_bayar_tanggal_bayar, p_bayar_sales, GetMasterNama('sales',p_bayar_sales) p_bayar_sales_n, " _
                        & "p_bayar_custo, GetMasterNama('custo',p_bayar_custo) p_bayar_custo_n, IFNULL(ppn.ref_text,'ERROR') jenispajak, p_bayar_jenisbayar, " _
                        & "p_bayar_akun, perk_nama_akun, p_bayar_giro_no, p_bayar_giro_bank, " _
                        & "IF(IFNULL(p_bayar_giro_no,'')='', NULL, p_bayar_tanggal_jt) p_bayar_giro_tgl, " _
                        & "p_trans_kode_piutang, p_trans_sisa, p_trans_nilaibayar, IFNULL(trans_state.ref_text,'ERROR') status " _
                        & "FROM( " _
                        & " SELECT p_bayar_bukti, p_bayar_tanggal_bayar, p_bayar_sales, p_bayar_custo, p_bayar_pajak, p_bayar_jenisbayar, p_bayar_akun, " _
                        & "  p_bayar_giro_no, p_bayar_giro_bank, p_bayar_tanggal_jt, p_bayar_status " _
                        & " FROM data_piutang_bayar WHERE p_bayar_status IN (0,1,2) AND p_bayar_tanggal_bayar BETWEEN '{0:yyyy-MM_dd}' AND '{1:yyyy-MM-dd}' " _
                        & ") data_bayar "
                    If Not String.IsNullOrWhiteSpace(ParamString) Then
                        _qwh = String.Join("'" & ParamString & "'", {"WHERE (p_bayar_bukti REGEXP ",
                                                                     " OR DATE_FORMAT(p_bayar_tanggal_bayar,'%d/%m/%Y') REGEXP ",
                                                                     " OR p_bayar_sales REGEXP ", " OR GetMasterNama('sales',p_bayar_sales) REGEXP ",
                                                                     " OR p_bayar_custo REGEXP ", " OR GetMasterNama('custo',p_bayar_custo) REGEXP ",
                                                                     " OR p_bayar_jenisbayar REGEXP ", " OR ppn.ref_text REGEXP ",
                                                                     " OR trans_state.ref_text REGEXP ", ")"})
                    Else
                        _qwh = ""
                    End If
                    _qorder = " ORDER BY p_bayar_tanggal_bayar, p_bayar_bukti"
                    _qjoin = " LEFT JOIN data_piutang_bayar_trans ON p_bayar_bukti=p_trans_bukti AND p_trans_status=1 " _
                            & "LEFT JOIN data_perkiraan ON perk_kode=p_bayar_akun " _
                            & "LEFT JOIN ref_jenis ppn ON p_bayar_pajak=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans2' " _
                            & "LEFT JOIN ref_jenis trans_state ON p_bayar_status=trans_state.ref_kode AND trans_state.ref_status=1 AND trans_state.ref_type='status_trans'"
                    _q = String.Format(_q, SelectedDate1, SelectedDate2, _qorder) + _qjoin + _qwh + _qorder

                Case Else : Exit Sub
            End Select

            exportToExcel(_q)
        End If
    End Sub

    Private Sub exportToExcel(SqlQuery As String)
        Dim _dt As New List(Of DataTable)
        Dim _title As New List(Of String)
        Dim _subtitle As New List(Of String())
        Dim _colHeader As New List(Of String)
        Dim _outputdir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\SIMInvent\"
        Dim _periode As String = ""
        Dim _ck As Boolean = False

        If date_sw Then
            Dim _tglawal As Date = date_tglawal.Value : Dim _tglakhir As Date = date_tglakhir.Value
            If _tglawal.ToString("MMyyyy") = _tglakhir.ToString("MMyyyy") AndAlso _tglawal.Day = 1 _
                AndAlso _tglakhir.Day = DateSerial(_tglakhir.Year, _tglakhir.Month + 1, 0).Day Then
                _periode = UCase(_tglawal.ToString("MMMM yyyy"))
            Else
                _periode = _tglawal.ToString("dd/MM/yyyy") & " S.d " & _tglakhir.ToString("dd/MM/yyyy")
            End If
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Using dtx = x.GetDataTable(SqlQuery)
                    Select Case tabpagename.Name
                        Case "pgbarang"
                            _colHeader.AddRange({"Kode", "NamaBarang", "KodeSupplier", "NamaSupplier", "Jenis", "Kategori", "Pajak", "SatBesar", "IsiBesar",
                                                 "SatTengah", "IsiTengah", "SatKecil", "HargaBeli", "HargaJual", "HargaJualMT", "HargaJualHoreka",
                                                 "HargaJualRita", "Status"})
                            _title.AddRange({"DATA MASTER BARANG"})
                            _dt.Add(dtx)

                        Case "pgsupplier"
                            _colHeader.AddRange({"Kode", "NamaSupplier", "Alamat", "NoTelp1", "NoTelp2", "NoFax", "Email", "ContactPerson", "NPWP", "Status"})
                            _title.AddRange({"DATA MASTER SUPPLIER"})
                            _dt.Add(dtx)

                        Case "pggudang"
                            _colHeader.AddRange({"Kode", "NamaGudang", "Alamat", "Ket", "Status"})
                            _title.AddRange({"DATA MASTER GUDANG"})
                            _dt.Add(dtx)

                        Case "pgsales"
                            _colHeader.AddRange({"Kode", "NamaSalesman", "Jenis", "Alamat", "NoTelp", "NoFax", "Email", "NIK", "NoRek", "A.N.Rek", "Status"})
                            _title.AddRange({"DATA MASTER SALESMAN"})
                            _dt.Add(dtx)

                        Case "pgcusto"
                            _colHeader.AddRange({"Kode", "NamaCustomer", "Jenis", "Alamat", "Kecamatan", "Kabupaten", "Pasar", "Provinsi", "KodePos",
                                                 "NoTelp", "NoFax", "NIK", "NPWP", "NamaPajak", "Jabatan", "AlamatPajak", "Status"})
                            _title.AddRange({"DATA MASTER CUSTOMER"})
                            _dt.Add(dtx)

                        Case "pgpembelian"
                            _colHeader.AddRange({"KodeFaktur", "Tgl", "KodeSupplier", "NamaSupplier", "KodeGudang", "NamaGudang", "Term", "JenisPajak",
                                                 "KodeBarang", "NamaBarang", "HargaBeli", "Qty", "SatuanBeli", "JenisSatuan", "JumlahDiskon", "JumlahBeliNetto",
                                                 "Disc1", "Disc2", "Disc3", "DiscRp", "Status"})
                            _title.AddRange({"DATA PEMBELIAN", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "pgreturbeli"
                            _colHeader.AddRange({"KodeBukti", "Tgl", "KodeSupplier", "NamaSupplier", "KodeGudang", "NamaGudang", "JenisPajak", "JenisBayar",
                                                 "KodeFaktur", "KodeExFaktur", "KodeBarang", "NamaBarang", "HargaRetur", "Qty", "SatuanJual", "JenisSatuan",
                                                 "Diskon", "JumlahDiskon", "JumlahReturNetto", "Status"})
                            _title.AddRange({"DATA RETUR PEMBELIAN", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "pgpenjualan"
                            _colHeader.AddRange({"KodeFaktur", "Tgl", "KodeSalesman", "Salesman", "KodeCustomer", "NamaCustomer", "KodeGudang", "NamaGudang", "Term",
                                                 "JenisPajak", "KodeBarang", "NamaBarang", "Hargajual", "Qty", "SatuanJual", "JenisSatuan",
                                                 "JumlahDiskon", "JumlahJualNetto", "Disc1", "Disc2", "Disc3", "Disc4", "Disc5", "DiscRp", "Status"})
                            _title.AddRange({"DATA PENJUALAN", "PERIODE " & _periode})
                            _dt.Add(dtx)
                        Case "pgreturjual"
                            _colHeader.AddRange({"KodeBukti", "Tgl", "KodeSalesman", "NamaSalesman", "KodeCustomer", "NamaCustomer", "KodeGudang", "NamaGudang",
                                                 "JenisPajak", "JenisBayar", "KodeFaktur", "KodeExFaktur", "KodeBarang", "NamaBarang", "HargaRetur",
                                                 "Qty", "SatuanJual", "JenisSatuan", "Diskon", "JumlahDiskon", "JumlahReturNetto", "Status"})
                            _title.AddRange({"DATA RETUR PENJUALAN", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "pghutangbayar"
                            _colHeader.AddRange({"KodeBukti", "Tgl", "KodeSupplier", "NamaSupplier", "Kat", "JenisBayar", "KodeAkun", "NamaAkun",
                                                 "NoGiro", "TanggalGiro", "KodeFaktur/Hutang", "SisaHutang", "NilaiBayar", "Status"})
                            _title.AddRange({"DATA PEMBAYARAN HUTANG", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "pgpiutangbayar"
                            _colHeader.AddRange({"KodeBukti", "Tgl", "KodeSales", "NamaSales", "KodeCustomer", "NamaCustomer", "Kat",
                                                 "JenisBayar", "KodeAkun", "NamaAkun", "NoGiro", "BankGiro", "TanggalGiro",
                                                 "KodeFaktur/Piutang", "SisaPiutang", "NilaiBayar", "Status"})
                            _title.AddRange({"DATA PEMBAYARAN PIUTANG", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case Else : Exit Sub
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

    'UNFINISHED complicated DEACT PROCEDURE
    ''' <summary>
    ''' De/Active data master
    ''' </summary>
    ''' <remarks>Unfinished, net more test and fix, also optimization</remarks>
    Private Sub deactItem()
        If deact_sw = True Then
            If MainConnection.Connection Is Nothing Then
                Throw New NullReferenceException("Main DB Connection is empty")
            End If

            If MessageBox.Show("Ubah status data?", "De/Aktivasi Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If

            Dim tabpage As String = tabpagename.Name.ToString
            Dim kode As String = ""
            Dim ket As String = ""
            Dim _dataState As String = "0"
            Dim ckdata As Boolean = False
            Dim q As String = ""
            Dim qck As String = ""
            Dim _msg As String = ""
            Dim refreshtab() As TabPage

            Select Case tabpage
                Case "pgbarang"
                    kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                    qck = "SELECT barang_kode, barang_status status FROM data_barang_master WHERE barang_kode='{0}' AND barang_status IN (0,1)"
                    q = "UPDATE data_barang_master SET barang_status='{1}', barang_keterangan=TRIM(BOTH '\r\n' FROM CONCAT(barang_keterangan,'\r\n','{3}')), " _
                        & "barang_upd_date=NOW(), barang_upd_alias='{2}' WHERE barang_kode='{0}'"
                    refreshtab = {pgbarang}

                Case "pggudang"
                    kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                    qck = "SELECT gudang_kode, gudang_status status FROM data_barang_gudang WHERE gudang_kode='{0}' AND gudang_status IN (0,1)"
                    q = "UPDATE data_barang_gudang SET gudang_status='{1}', gudang_ket=TRIM(BOTH '\r\n' FROM CONCAT(gudang_ket,'\r\n','{3}')), " _
                        & "gudang_upd_date=NOW(), gudang_upd_alias='{2}' WHERE gudang_kode='{0}'"
                    refreshtab = {pggudang}

                Case "pgsupplier"
                    kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                    qck = "SELECT supplier_kode, supplier_status status FROM data_supplier_master WHERE supplier_kode='{0}' AND supplier_status IN (0,1)"
                    q = "UPDATE data_supplier_master SET supplier_status='{1}', supplier_keterangan=TRIM(BOTH '\r\n' FROM CONCAT(supplier_keterangan,'\r\n','{3}')), " _
                        & "supplier_upd_date=NOW(), supplier_upd_alias='{2}' WHERE supplier_kode='{0}'"
                    refreshtab = {pgsupplier}

                Case "pgcusto"
                    kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                    qck = "SELECT customer_kode, customer_status status FROM data_customer_master WHERE customer_kode='{0}' AND customer_status IN (0,1)"
                    q = "UPDATE data_customer_master SET customer_status='{1}', customer_keterangan=TRIM(BOTH '\r\n' FROM CONCAT(customer_keterangan,'\r\n','{3}')), " _
                        & "customer_upd_date=NOW(), customer_upd_alias='{2}' WHERE customer_kode='{0}'"
                    refreshtab = {pgcusto}

                Case "pgsales"
                    kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                    qck = "SELECT salesman_kode, salesman_status status FROM data_salesman_master WHERE salesman_kode='{0}' AND salesman_status IN (0,1)"
                    q = "UPDATE data_salesman_master SET salesman_status='{1}', salesman_keterangan=TRIM(BOTH '\r\n' FROM CONCAT(salesman_keterangan,'\r\n','{3}')), " _
                        & "salesman_upd_date=NOW(), salesman_upd_alias='{2}' WHERE salesman_kode='{0}'"
                    refreshtab = {pgsales}

                Case "pguser"
                    kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                    qck = "SELECT user_alias, IF(user_status IN (1,2),1,0) status FROM data_pengguna_alias WHERE user_alias='{0}' AND user_status IN (0,1,2)"
                    q = "UPDATE data_pengguna_alias SET user_status='{1}',user_upd_date=NOW(),user_upd_alias='{2}' WHERE user_alias='{0}'"
                    refreshtab = {pguser}

                Case "pggroup"
                    kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                    qck = "SELECT group_kode, group_status status FROM data_pengguna_group WHERE group_kode='{0}' AND group_status<>9"
                    q = "UPDATE data_pengguna_group SET group_status='{1}', group_upd_date=NOW(), group_upd_alias='{2}' WHERE group_kode='{0}'"
                    refreshtab = {pggroup}

                Case Else
                    Exit Sub
            End Select

            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Using rdx = x.ReadCommand(String.Format(qck, kode), CommandBehavior.SingleRow)
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            _dataState = rdx.Item("status") : ckdata = True
                        Else
                            ckdata = False : _msg = "Data tidak di temukan"
                        End If
                    End Using
                Else
                    ckdata = False
                    _msg = "Tidak dapat terhubung ke database."
                End If

                If ckdata Then
                    Select Case tabpage
                        Case "pgbarang", "pggudang", "pgsales", "pgsupplier", "pgcusto"
                            ckdata = MasterConfirmValid(ket)
                        Case "pguser", "pggroup"
                            ckdata = loggeduser.admin_pc : ket = Nothing
                            'MessageBox.Show("x", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Select
                    If Not ckdata Then Exit Sub

                    ckdata = x.ExecCommand(String.Format(q, kode, IIf(_dataState = 1, 0, 1), loggeduser.user_id, ket))
                    If ckdata Then
                        MessageBox.Show("Perubahan status tersimpan")
                        DoRefreshTab_v2(refreshtab)
                    Else
                        _msg = "Terjadi kesalahan saat melakukan proses update"
                        MessageBox.Show("Perubahan status data tidak dapat dilakukan." & Environment.NewLine & _msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Perubahan status tidak dapat dilakukan." & Environment.NewLine & _msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End If
    End Sub

    'CHANGE TRANSACTION DATA STATUS
    Private Sub cancelTransaction()
        Dim _Qmsg, _Smsg, _Fmsg, _resMsg As String
        Dim _newSt As Integer = 2
        Dim kode As String = ""
        Dim _res As Boolean = False
        Dim ckdata As Boolean = False
        _resMsg = ""
        Select Case tabpagename.Name
            Case "pgpesanjual"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Batalkan transaksi order penjualan?"
                _Fmsg = "Pembatalan order penjualan tidak dapat dilakukan."
                _Smsg = " order penjualan #" & kode & " berhasil dibatalkan."
                ckdata = CheckCancelPesanan(kode, _resMsg)
            Case "pgpembelian"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Batalkan transaksi pembelian?"
                _Fmsg = "Pembatalan transaksi pembelian tidak dapat dilakukan."
                _Smsg = "Transaksi pembelian " & kode & " berhasil dibatalkan."
                ckdata = CheckCancelPembelian(kode, _resMsg)
            Case "pgreturbeli"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Batalkan transaksi retur pembelian?"
                _Fmsg = "Pembatalan transaksi retur pembelian tidak dapat dilakukan."
                _Smsg = "Transaksi retur pembelian " & kode & " berhasil dibatalkan."
                ckdata = CheckCancelRetur(kode, "beli", _resMsg)
            Case "pgpenjualan"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Batalkan transaksi penjualan?"
                _Fmsg = "Pembatalan transaksi penjualan tidak dapat dilakukan."
                _Smsg = "Transaksi penjualan " & kode & " berhasil dibatalkan."
                ckdata = CheckCancelPenjualan(kode, _resMsg)
            Case "pgreturjual"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Batalkan transaksi retur penjualan?"
                _Fmsg = "Pembatalan transaksi retur penjualan tidak dapat dilakukan."
                _Smsg = "Transaksi retur pembelian " & kode & " berhasil dibatalkan."
                ckdata = CheckCancelRetur(kode, "jual", _resMsg)
            Case "pghutangbayar"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Batalkan transaksi pembayaran hutang?"
                _Fmsg = "Pembatalan transaksi pembayaran hutang tidak dapat dilakukan."
                _Smsg = "Transaksi pembayaran hutang " & kode & " berhasil dibatalkan."
                ckdata = CheckCancelBayar(kode, "hutang", _resMsg)
            Case "pgpiutangbayar"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Batalkan transaksi pembayaran piutang?"
                _Fmsg = "Pembatalan transaksi pembayaran piutang tidak dapat dilakukan."
                _Smsg = "Transaksi pembayaran piutang " & kode & " berhasil dibatalkan."
                ckdata = CheckCancelBayar(kode, "piutang", _resMsg)
            Case "pgkas"
                kode = dgv_list.SelectedRows.Item(0).Cells(1).Value
                _Qmsg = "Batalkan transaksi kas?"
                _Fmsg = "Pembatalan transaksi kas tidak dapat dilakukan."
                _Smsg = "Transaksi kas " & kode & " berhasil dibatalkan."
                ckdata = CheckCancelKas(kode, _resMsg)

            Case Else : Exit Sub
        End Select

        If Not ckdata Then
            If Not String.IsNullOrWhiteSpace(_resMsg) Then _Fmsg += Environment.NewLine & _resMsg
            MessageBox.Show(_Fmsg, lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If MessageBox.Show(_Qmsg, lbl_judul.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
        _res = changeTransactionStatus(kode, _newSt, _resMsg)
        If _res Then
            MessageBox.Show(_Smsg, lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            _Fmsg += Environment.NewLine & _resMsg
            MessageBox.Show(_Fmsg, lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub uncancelTransaction()
        Dim _Qmsg, _Smsg, _Fmsg, _resMsg As String
        Dim _newSt As Integer = 0
        Dim kode As String = ""
        Dim _oldstatus As Integer = 0
        Dim _res As Boolean = False
        _resMsg = ""
        Select Case tabpagename.Name
            Case "pgpesanjual"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Cancel pembatalan order penjualan?"
                _Fmsg = "Cancel pembatalan order penjualan tidak dapat dilakukan."
                _oldstatus = getTransStatus(kode, "pesanan", _resMsg)
                _newSt = 0
            Case "pgpembelian"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Cancel pembatalan transaksi pembelian?"
                _Fmsg = "Cancel pembatalan transaksi pembelian tidak dapat dilakukan."
                _oldstatus = getTransStatus(kode, "pembelian", _resMsg)
                _newSt = 1
            Case "pgreturbeli"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Cancel pembatalan transaksi retur pembelian?"
                _Fmsg = "Cancel pembatalan transaksi retur pembelian tidak dapat dilakukan."
                _oldstatus = getTransStatus(kode, "returbeli", _resMsg)
                _newSt = 1
            Case "pgpenjualan"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Cancel pembatalan transaksi penjualan?"
                _Fmsg = "Cancel pembatalan transaksi penjualan tidak dapat dilakukan."
                _oldstatus = getTransStatus(kode, "penjualan", _resMsg)
                _newSt = 1
            Case "pgreturjual"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Cancel pembatalan transaksi retur penjualan?"
                _Fmsg = "Cancel pembatalan transaksi retur penjualan tidak dapat dilakukan."
                _oldstatus = getTransStatus(kode, "returjual", _resMsg)
                _newSt = 1
            Case "pghutangbayar"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Cancel pembatalan pembayaran hutang?"
                _Fmsg = "Cancel pembatalan pembayaran hutang tidak dapat dilakukan."
                _oldstatus = getTransStatus(kode, "hutangbayar", _resMsg)
                _newSt = 1
            Case "pgpiutangbayar"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Cancel pembatalan pembayaran piutang?"
                _Fmsg = "Cancel pembatalan pembayaran piutang tidak dapat dilakukan."
                _oldstatus = getTransStatus(kode, "piutangbayar", _resMsg)
                _newSt = 0
            Case "pgkas"
                kode = dgv_list.SelectedRows.Item(0).Cells(1).Value
                _Qmsg = "Cancel pembatalan pembayaran kas?"
                _Fmsg = "Cancel pembatalan pembayaran kas tidak dapat dilakukan."
                _oldstatus = getTransStatus(kode, "kas", _resMsg)
                _newSt = 1

            Case Else : Exit Sub
        End Select

        If _oldstatus <> 2 Then
            If Not String.IsNullOrWhiteSpace(_resMsg) Then _Fmsg += Environment.NewLine & _resMsg
            MessageBox.Show(_Fmsg, lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If MessageBox.Show(_Qmsg, lbl_judul.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        _Smsg = "Cancel pembatalan berhasil."
        _res = changeTransactionStatus(kode, _newSt, _resMsg)
        If _res Then
            MessageBox.Show(_Smsg, lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            _Fmsg += Environment.NewLine & _resMsg
            MessageBox.Show(_Fmsg, lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub deleteTransaction()
        Dim _Qmsg, _Smsg, _Fmsg, _resMsg As String
        Dim kode As String = ""
        Dim _oldstatus As Integer = 0
        Dim _res As Boolean = False
        _resMsg = ""
        Select tabpagename.Name
            Case "pgpesanjual"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Hapus transaksi order penjualan?"
                _Fmsg = "Penghapusan order penjualan tidak dapat dilakukan."
                _Smsg = "Order penjualan #" & kode & " berhasil dihapus."
                _oldstatus = getTransStatus(kode, "pesanan", _resMsg)
                _res = CheckCancelPesanan(kode, _resMsg)
            Case "pgpembelian"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Hapus transaksi pembelian?"
                _Fmsg = "Penghapusan transaksi pembelian tidak dapat dilakukan."
                _Smsg = "Transaksi pembelian " & kode & " berhasil dihapus."
                _oldstatus = getTransStatus(kode, "pembelian", _resMsg)
                _res = CheckCancelPembelian(kode, _resMsg)
            Case "pgpenjualan"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                _Qmsg = "Hapus transaksi penjualan?"
                _Fmsg = "Penghapusan transaksi penjualan tidak dapat dilakukan."
                _Smsg = "Transaksi penjualan " & kode & " berhasil dihapus."
                _oldstatus = getTransStatus(kode, "penjualan", _resMsg)
                _res = CheckCancelPenjualan(kode, _resMsg)

            Case Else : Exit Sub
        End Select

        If MessageBox.Show(_Qmsg, lbl_judul.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        If _oldstatus = 2 Then
            _res = True
        ElseIf {0, 1}.Contains(_oldstatus) Then
            If Not _res Then
                If Not String.IsNullOrWhiteSpace(_resMsg) Then _Fmsg += Environment.NewLine & _resMsg
                MessageBox.Show(_Fmsg, lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Else
            _Fmsg += Environment.NewLine & "Kode status taransaksi tidak sesuai."
            MessageBox.Show(_Fmsg, lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If _res Then _res = changeTransactionStatus(kode, 9, _resMsg)
        If _res Then
            MessageBox.Show(_Smsg, lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            _Fmsg += Environment.NewLine & _resMsg
            MessageBox.Show(_Fmsg, lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    'PERUBAHAN STATUS DATA TRANSAKSI (NOT DATA ACTIVATION PROCEDURE)
    Private Function changeTransactionStatus(KodeFaktur As String, NewStatus As Integer, ByRef ReturnMsg As String) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If

        Dim _tbpg As String = tabpagename.Name
        Dim ValidUid As String = ""
        Dim queryArr As New List(Of String)
        Dim queryCk As Boolean = False
        Dim _msg As String = ""
        Dim refreshtab() As TabPage

        Select Case _tbpg
            Case "pgpesanjual"
                queryArr.Add("UPDATE data_penjualan_order_faktur SET j_order_status={2}, j_order_upd_date=NOW(), j_order_upd_alias='{1}' WHERE j_order_kode='{0}'")
                If NewStatus = 9 Then
                    queryArr.Add("UPDATE data_penjualan_order_trans SET j_order_trans_status=9 WHERE j_order_trans_faktur='{0}' AND j_order_trans_status=1")
                End If
                refreshtab = {pgpesanjual}

            Case "pgpembelian"
                queryArr.Add("UPDATE data_pembelian_faktur SET faktur_status={2}, faktur_upd_date=NOW(), faktur_upd_alias='{1}' WHERE faktur_kode='{0}'")
                If NewStatus = 9 Then queryArr.Add("UPDATE data_pembelian_faktur SET trans_status=9 WHERE trans_faktur='{0}' AND trans_status=1")
                queryArr.Add("CALL transPembelianFin('{0}','{1}')")
                refreshtab = {pgpembelian, pgstok, pghutangawal}

            Case "pgreturbeli"
                queryArr.Add("UPDATE data_pembelian_retur_faktur SET faktur_status={2}, faktur_upd_date=NOW(), faktur_upd_alias='{1}' WHERE faktur_kode_bukti='{0}'")
                If NewStatus = 9 Then queryArr.Add("UPDATE data_pembelian_retur_trans SET trans_status=9 WHERE trans_faktur='{0}' AND trans_status=1")
                queryArr.Add("CALL transReturBeliFin('{0}','{1}')")
                refreshtab = {pgreturbeli, pgstok}

            Case "pgpenjualan"
                queryArr.Add("UPDATE data_penjualan_faktur SET faktur_status={2}, faktur_upd_date=NOW(), faktur_upd_alias='{1}' WHERE faktur_kode='{0}'")
                If NewStatus = 9 Then queryArr.Add("UPDATE data_penjualan_faktur SET trans_status=9 WHERE trans_faktur='{0}' AND trans_status=1")
                refreshtab = {pgpenjualan, pgstok, pgpiutangawal}

            Case "pgreturjual"
                queryArr.Add("UPDATE data_penjualan_retur_faktur SET faktur_status={2}, faktur_upd_date=NOW(), faktur_upd_alias='{1}' WHERE faktur_kode_bukti='{0}'")
                If NewStatus = 9 Then queryArr.Add("UPDATE data_penjualan_retur_trans SET trans_status=9 WHERE trans_faktur='{0}' AND trans_status=1")
                queryArr.Add("CALL transReturJualFin('{0}','{1}')")
                refreshtab = {pgreturbeli, pgstok}

            Case "pghutangbayar"
                queryArr.Add("UPDATE data_hutang_bayar SET h_bayar_status={2}, h_bayar_upd_alias='{1}', h_bayar_upd_date=NOW() WHERE h_bayar_bukti='{0}'")
                If NewStatus = 9 Then queryArr.Add("UPDATE data_hutang_bayar_trans SET h_trans_status=9 WHERE h_trans_bukti='{0}' AND h_trans_status=1")
                queryArr.Add("CALL transBayarHutangFin('{0}','{1}')")
                refreshtab = {pghutangawal, pghutangbayar}

            Case "pgpiutangbayar"
                queryArr.Add("UPDATE data_piutang_bayar SET p_bayar_status={2}, p_bayar_upd_alias='{1}', p_bayar_upd_date=NOW() WHERE p_bayar_bukti='{0}'")
                queryArr.Add("CALL transBayarPiutangFin('{0}','{1}')")
                refreshtab = {pgpiutangawal, pgpiutangbayar}

            Case "pgkas"
                queryArr.Add("UPDATE data_kas_faktur SET kas_status={2}, kas_upd_date=NOW(), kas_upd_alias='{1}' WHERE kas_kode='{0}'")
                If {2, 9}.Contains(NewStatus) Then
                    queryArr.Add("UPDATE data_jurnal_line SET line_status=9, line_upd_date=NOW(), line_upd_alias='{1}' " _
                                 & "WHERE line_kode='{0}' AND line_type='KAS' AND lins_status = 1")
                End If
                refreshtab = {pgkas}
            Case Else
                ReturnMsg = "Function doesnt exist for that data." : Return False
                Exit Function
        End Select

        'If ckdata Then
        If {"pgkas"}.Contains(_tbpg) Then
            If Not AkunConfirmValid(ValidUid) Then Return False
        Else
            If Not TransConfirmValid(ValidUid) Then Return False
        End If

        Dim _qArr As New List(Of String)
        For Each _str As String In queryArr
            _qArr.Add(String.Format(_str, KodeFaktur, ValidUid, NewStatus))
        Next

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                queryCk = x.TransactCommand(_qArr)
                If queryCk Then
                    DoRefreshTab_v2(refreshtab) : Return True
                Else
                    ReturnMsg = "Terjadi kesalahan saat melakukan proses perubahan status transaksi." : Return False
                End If
            Else
                ReturnMsg = "Tidak dapat terhubung ke database." : Return False
            End If
        End Using
        'Else
        'ReturnMsg = _msg : Return False
        'End If
    End Function

    'SEPUTAR JURNAL UMUM/PENYESUAIAN
    Private Sub EntryJurnal()
        If entry_sw And Not selectperiode.closed Then
            'VALIDASI USER AKUN
            Select Case tabpagename.Name
                Case "pgjurnalumum" : Dim x As New fr_jurnal_u_entry : x.doLoadNew()
                Case "pgjurnalsesuai" : Dim x As New fr_jurnal_p_entry : x.doLoadNew()
                Case Else : Exit Sub
            End Select
        End If
    End Sub

    Private Sub DeleteEntry(IdJurnal As Integer)
        If entry_sw Then
            'VALIDASI ENTRY
            Dim _allowdelete As Boolean = False
            Dim _q As String = "" : Dim _qArr As New List(Of String)
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    _q = "SELECT line_type FROM data_jurnal_line WHERE line_id='{0}'"
                    Try
                        _allowdelete = IIf(sLeft(x.ExecScalar(String.Format(_q, IdJurnal)), 6) = "ENTRY1", True, False)
                    Catch ex As Exception
                        MessageBox.Show("", lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                Else
                    MessageBox.Show("Tidak dapat terhubung ke database.", lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End Using

            'VALIDASI USER AKUN
            If Not _allowdelete Then Exit Sub
            Dim _idValid As Integer = 0 : Dim ValidUid As String = ""
            If Not AkunConfirmValid(ValidUid) Then Exit Sub
            LogValidTrans(ValidUid, loggeduser, "JU.ENTRY", "DELETE", IdJurnal, _idValid)

            'UPDATE STATUS ENTRY
            If _allowdelete Then
                _q = "UPDATE data_jurnal_line SET line_status=9, line_upd_date=NOW(), line_upd_alias='{1}' WHERE line_id={0}"
                _qArr.Add(String.Format(_q, IdJurnal, loggeduser.user_id))

                Using x = MainConnection
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        Dim _ck = x.TransactCommand(_qArr)
                        If _ck Then
                            MessageBox.Show("Entry jurnal berhasil dihapus.", lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.PerformRefresh()
                        Else
                            MessageBox.Show("Terjadi kesalahan dalam penghapusan entry jurnal.", lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Tidak dapat terhubung ke database.", lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using
            End If
        End If
    End Sub

    '---------------- LOAD
    Private Sub fr_list_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'only triggered at 1st time loaded to tabpage
        setMenuSw()
    End Sub

    '---------------- CLOSE
    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        main.tabcontrol.TabPages.Remove(tabpagename)
    End Sub

    '---------------- DGV ITEM LIST
    Private Sub dgv_list_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_list.ColumnHeaderMouseClick
        dgv_list.ClearSelection()
    End Sub

    Private Sub dgv_list_ColumnHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_list.ColumnHeaderMouseDoubleClick
        dgv_list.ClearSelection()
    End Sub

    Private Sub dgv_list_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                editItem()
            End If
        Catch ex As Exception
            logError(ex, False)
            consoleWriteLine(ex.Message)
        End Try
    End Sub

    Private Sub dgv_list_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_list.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            editItem()
        End If
    End Sub

    '------------------ MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_add.Click
        addItem()
    End Sub

    Private Sub mn_deact_Click(sender As Object, e As EventArgs) Handles mn_edit.Click
        editItem()
    End Sub

    Private Sub mn_cari_Click(sender As Object, e As EventArgs) Handles mn_cari.Click
        in_cari.Focus()
    End Sub

    Private Sub mn_refresh_Click(sender As Object, e As EventArgs) Handles mn_refresh.Click
        PerformRefresh()
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_deact.Click
        If deact_sw = True And dgv_list.RowCount > 0 Then
            deactItem()
        ElseIf dgv_list.Rows.Count = 0 Then
            MessageBox.Show("Data tidak ada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub mn_print_Click(sender As Object, e As EventArgs) Handles mn_print.Click
        If print_sw = True And dgv_list.RowCount > 0 Then
            printItem()
        ElseIf dgv_list.Rows.Count = 0 Then
            MessageBox.Show("Data tidak ada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub mn_exportExcel_Click(sender As Object, e As EventArgs) Handles mn_exportExcel.Click
        If export_sw = True Then
            Me.Cursor = Cursors.WaitCursor
            Dim _tr = {"pgpenjualan", "pgreturjual", "pgpembelian", "pgreturbeli", "pghutangbayar", "pgpiutangbayar"}
            Dim _mst = {"pgsupplier", "pgbarang", "pggudang", "pgsales", "pgcusto"}
            If _tr.Contains(tabpagename.Name) Then
                exportItemTrans(SearchParam)
            ElseIf _mst.Contains(tabpagename.Name) Then
                exportItem(SearchParam)
            End If
            Me.Cursor = Cursors.Default
        ElseIf dgv_list.Rows.Count = 0 Then
            MessageBox.Show("Data tidak ada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub mn_bataljual_Click(sender As Object, e As EventArgs) Handles mn_bataljual.Click
        If cancel_sw = True And dgv_list.Rows.Count > 0 Then
            cancelTransaction()
        ElseIf dgv_list.Rows.Count = 0 Then
            MessageBox.Show("Data tidak ada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub mn_delete_Click(sender As Object, e As EventArgs) Handles mn_delete.Click
        If delete_sw And dgv_list.Rows.Count > 0 Then
            deleteTransaction()
        ElseIf dgv_list.Rows.Count = 0 Then
            MessageBox.Show("Data tidak ada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub mn_cancelbatal_Click(sender As Object, e As EventArgs) Handles mn_cancelbatal.Click
        If cancel_sw And dgv_list.Rows.Count > 0 Then
            uncancelTransaction()
        ElseIf dgv_list.Rows.Count = 0 Then
            MessageBox.Show("Data tidak ada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub mn_validasi_Click(sender As Object, e As EventArgs) Handles mn_validasi.Click
        If valid_sw = True Then
            Select Case tabpagename.Name.ToString
                Case "pgpesanjual"
                    Dim detail As New fr_pesan_detail
                    detail.doLoadValid(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                Case Else
                    Exit Sub
            End Select

        End If
    End Sub

    Private Sub mn_bayar_Click(sender As Object, e As EventArgs) Handles mn_bayar.Click
        If bayar_sw = True And dgv_list.RowCount > 0 Then
            bayarItem()
        ElseIf dgv_list.RowCount = 0 Then
            MessageBox.Show("Data tidak ada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub mn_addentry_Click(sender As Object, e As EventArgs) Handles mn_addentry.Click
        If entry_sw = True Then
            EntryJurnal()
        End If
    End Sub

    Private Sub mn_delentry_Click(sender As Object, e As EventArgs) Handles mn_delentry.Click
        If entry_sw = True And dgv_list.RowCount > 0 Then
            DeleteEntry(dgv_list.SelectedRows.Item(0).Cells(0).Value)
        ElseIf dgv_list.RowCount = 0 Then
            MessageBox.Show("Data tidak ada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    'UI : BUTTON
    Private Sub bt_search_Click(sender As Object, e As EventArgs) Handles bt_search.Click
        'Me.Cursor = Cursors.WaitCursor
        SearchParam = in_cari.Text
        If date_sw Then
            SelectedDate1 = date_tglawal.Value : SelectedDate2 = date_tglakhir.Value
            LoadDataGrid(in_cari.Text, 1, date_tglawal.Value, date_tglakhir.Value)
        Else
            LoadDataGrid(in_cari.Text, 1)
        End If
        dgv_list.Focus()
        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_page_prev_Click(sender As Object, e As EventArgs) Handles bt_page_prev.Click, bt_page_first.Click
        If String.IsNullOrWhiteSpace(in_page.Text) Then Exit Sub
        Dim _page As Integer = 0

        Me.Cursor = Cursors.WaitCursor
        If SelectedPageData = 1 Then
            in_page.Text = SelectedPageData : GoTo EndSub
        ElseIf SelectedPageData > 1 And sender.Name = "bt_page_prev" Then
            _page = SelectedPageData - 1
        Else
            _page = 1
        End If

        in_cari.Text = SearchParam
        If date_sw Then
            date_tglawal.Value = SelectedDate1 : date_tglakhir.Value = SelectedDate2
            LoadDataGrid(in_cari.Text, _page, date_tglawal.Value, date_tglakhir.Value)
        Else
            LoadDataGrid(in_cari.Text, _page)
        End If
EndSub:
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_page_next_Click(sender As Object, e As EventArgs) Handles bt_page_next.Click, bt_page_last.Click
        If String.IsNullOrWhiteSpace(in_page.Text) Then Exit Sub
        Dim _page As Integer = 0

        Me.Cursor = Cursors.WaitCursor
        If SelectedPageData = MaxPageData Then
            in_page.Text = SelectedPageData : GoTo EndSub
        ElseIf SelectedPageData < MaxPageData And sender.Name = "bt_page_next" Then
            _page = SelectedPageData + 1
        Else
            _page = MaxPageData
        End If

        in_cari.Text = SearchParam
        If date_sw Then
            date_tglawal.Value = SelectedDate1 : date_tglakhir.Value = SelectedDate2
            LoadDataGrid(in_cari.Text, _page, date_tglawal.Value, date_tglakhir.Value)
        Else
            LoadDataGrid(in_cari.Text, _page)
        End If
EndSub:
        Me.Cursor = Cursors.Default
    End Sub

    'UI : TEXTBOX
    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            bt_search.PerformClick()
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
