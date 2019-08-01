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

    'PERFORM REFRESH DATALIST - TODO SIMPLIFIED IT
    Public Sub PerformRefresh()
        Me.Cursor = Cursors.WaitCursor
        If date_sw Then setDatePicker()
        If search_sw Then : in_cari.Clear() : SearchParam = String.Empty : End If

        If date_sw Then
            LoadDataGrid("", 1, date_tglawal.Value, date_tglakhir.Value)
        Else
            LoadDataGrid("", 1)
        End If

        ControlSet() : setMenuSw()
EndSub:
        Me.Cursor = Cursors.Default
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
            print_sw = IIf({"pghutangbayar", "pgpiutangbayar"}.Contains(tabpagename.Name), False, True)
            If tabpagename.Name = "pgpesanjual" Then valid_sw = IIf(selectperiode.closed = False, loggeduser.validasi_trans, False)

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
            cancel_sw = IIf(selectperiode.closed = True, False, True)
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
    Private Sub LoadDataGrid(Param As String, Page As Integer, Optional StartDate As Date = Nothing, Optional EndDate As Date = Nothing)
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
            Case "pgtutupbuku" : Exit Sub
            Case "pggroup" : _typedata = "group"
            Case "pguser" : _typedata = "user"
            Case Else : Exit Sub
        End Select

        dgv_list.DataSource = GetDataLIstForListTemplate(_typedata, Param, Page, _limitdata, _startdate, _enddate)
        DataCount = GetDataCount(_typedata, Param, _startdate, _enddate)
        MaxPageData = CInt(Math.Ceiling(DataCount / _limitdata))
        SelectedPageData = Page
        in_page.Text = SelectedPageData
        PageInfo = String.Format(PageInfo,
                                 If(dgv_list.RowCount > 0, 1, 0) + (_limitdata * Page) - _limitdata,
                                 dgv_list.RowCount + (_limitdata * Page) - _limitdata,
                                 DataCount
                                 )
        lbl_pageinfo.Text = PageInfo
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
                        If selectperiode.closed Then
                            detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        Else
                            detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
                        End If

                    Case "pgreturbeli"
                        Dim detail As New fr_beli_retur_detail
                        If selectperiode.closed Then
                            detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        Else
                            detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
                        End If

                    Case "pgpesanjual"
                        Dim detail As New fr_pesan_detail
                        If selectperiode.closed Then
                            detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        Else
                            detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
                        End If

                    Case "pgpenjualan"
                        Dim detail As New fr_jual_detail
                        If selectperiode.closed Then
                            detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        Else
                            detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
                        End If

                    Case "pgreturjual"
                        Dim detail As New fr_jual_retur_detail
                        If selectperiode.closed Then
                            detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        Else
                            detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
                        End If

                    Case "pgstok"
                        Dim detail As New fr_stok_awal
                        If selectperiode.closed Then
                            detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        Else
                            detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
                        End If

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
                            .Show()
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
                            .Show()
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

                        'Case "pgtutupbuku"

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

    Private Sub exportItem()
        If export_sw = True Then
            If dgv_list.RowCount > 0 Then
                'DEV : THE ONE THAT THE CODE IS ALREADY DONE
                Dim avaliableData() As String = {"pggudang", "pgbarang", "pgsales", "pgcusto", "pgsupplier"}
                If Not avaliableData.Contains(tabpagename.Name.ToString) Then Exit Sub

                'EXPORT PROCEDURE
                If MainConnection.Connection Is Nothing Then
                    Throw New NullReferenceException("Main DB Connection is empty")
                End If

                Dim _tabpage As String = LCase(tabpagename.Name.ToString)
                Dim q As String = ""
                Dim _columnHeader As New List(Of String)
                Dim _dtList As New List(Of DataTable)
                Dim _dataTitle As New List(Of String)
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

                MyBase.Cursor = Cursors.WaitCursor
                Using x = MainConnection
                    x.Open()
                    If x.ConnectionState = ConnectionState.Open Then
                        Dim _dtCount As Integer = 1
                        Dim _qCount As String = ""
                        Dim _qGetData As String = ""

                        Select Case _tabpage
                            Case "pggudang"
                                _qCount = "SELECT COUNT(gudang_kode) FROM data_barang_gudang WHERE gudang_status IN (0,1)"
                                _qGetData = "SELECT gudang_kode, gudang_nama, gudang_alamat, gudang_ket, state.ref_text " _
                                    & "FROM data_barang_gudang " _
                                    & "LEFT JOIN ref_jenis state ON state.ref_kode=gudang_status AND state.ref_status=1 AND state.ref_type='status_master' " _
                                    & "WHERE gudang_status IN (0,1) LIMIT {0},2000"
                                _columnHeader.AddRange({"Kode", "Nama Gudang", "Keterangan", "Status"})
                                _dataTitle.AddRange({"List Gudang"})
                            Case "pgbarang"
                                _qCount = "SELECT COUNT(barang_kode) FROM data_barang_master WHERE barang_status IN (0,1)"
                                _qGetData = "SELECT barang_kode, barang_nama, barang_supplier, GetMasterNama('supplier',barang_supplier), jenis_nama, kategori_nama, " _
                                    & "pajak.ref_text, state.ref_text, barang_satuan_kecil, barang_satuan_tengah, barang_satuan_tengah_jumlah, barang_satuan_besar, " _
                                    & "barang_satuan_besar_jumlah, barang_harga_beli, barang_harga_beli_d1, barang_harga_beli_d2, barang_harga_beli_d3, " _
                                    & "barang_harga_jual_horeka, barang_harga_jual_rita, barang_harga_jual_d1, barang_harga_jual_d2, barang_harga_jual_d3, " _
                                    & "barang_harga_jual, barang_harga_jual_mt, barang_harga_jual_d4, barang_harga_jual_d5, barang_harga_jual_discount " _
                                    & "FROM data_barang_master " _
                                    & "LEFT JOIN data_barang_jenis ON jenis_kode=barang_jenis " _
                                    & "LEFT JOIN ref_barang_kategori ON kategori_kode=barang_kategori " _
                                    & "LEFT JOIN ref_jenis state ON state.ref_kode=barang_status AND state.ref_status=1 AND state.ref_type='status_master' " _
                                    & "LEFT JOIN ref_jenis pajak ON pajak.ref_kode=barang_pajak AND pajak.ref_status=1 AND pajak.ref_type='barang_pajak' " _
                                    & "WHERE barang_status IN (0,1) LIMIT {0},2000"
                                _columnHeader.AddRange({"Kode", "Nama Barang", "Kode Supplier", "Nama Supplier", "Jenis", "Kategori", "Pajak", "Status", "Satuan Kecil",
                                                        "Satuan Tengah", "Isi Tengah", "Satuan Besar", "Isi Besar", "Harga Beli", "Beli Disc1", "Beli Disc2", "Beli Disc3",
                                                        "Harga Jual", "Harga Jual MT", "Harga Jual Horeka", "Harga Jual Rita", "Jual Disc1", "Jual Disc2", "Jual Disc3",
                                                        "Jual Disc4", "Jual Disc5", "Jual Disc Rp."})
                                _dataTitle.AddRange({"List Barang"})
                            Case "pgsales"
                                _qCount = "SELECT COUNT(salesman_kode) FROM data_salesman_master WHERE salesman_status IN (0,1)"
                                _qGetData = "SELECT salesman_kode, salesman_nama, jenis.ref_text salesman_jenis, state.ref_text salesman_status, salesman_alamat, " _
                                    & "salesman_nik, salesman_hp, salesman_fax, salesman_tanggal_masuk, salesman_lahir_tanggal, salesman_lahir_kota, salesman_target, " _
                                    & "CONCAT_WS('-', salesman_bank_rekening, salesman_bank_nama) salesman_rek, salesman_bank_atasnama " _
                                    & "FROM data_salesman_master " _
                                    & "LEFT JOIN ref_jenis jenis ON jenis.ref_kode=salesman_jenis AND jenis.ref_status=1 AND jenis.ref_type='sales_jenis' " _
                                    & "LEFT JOIN ref_jenis state ON state.ref_kode=salesman_status AND state.ref_status=1 AND state.ref_type='status_master' " _
                                    & "WHERE salesman_status IN (0,1) LIMIT {0},2000"
                                _columnHeader.AddRange({"Kode", "Nama Salesman", "Jenis", "Status", "Alamat", "NIK", "No.Telp", "No.Fax", "Tgl.Masuk", "Tgl.Lahir",
                                                        "Kota Lahir", "Target", "No.Rekening", "A.N. Rekening"})
                                _dataTitle.AddRange({"List Salesman"})
                            Case "pgsupplier"
                                _qCount = "SELECT COUNT(supplier_kode) FROM data_supplier_master WHERE supplier_status IN (0,1)"
                                _qGetData = "SELECT supplier_kode, supplier_nama, supplier_alamat, supplier_telpon1, supplier_telpon2, supplier_fax, " _
                                    & "supplier_email, supplier_cp, supplier_npwp, state.ref_text " _
                                    & "FROM data_supplier_master " _
                                    & "LEFT JOIN ref_jenis state ON state.ref_kode=supplier_status AND state.ref_status=1 AND state.ref_type='status_master' " _
                                    & "WHERE supplier_status IN (0,1) LIMIT {0},2000"
                                _columnHeader.AddRange({"Kode", "Nama Supplier", "Alamat", "No.Telp1", "No.Telp2", "No.Fax", "Email", "Contact Person", "NPWP", "Status"})
                                _dataTitle.AddRange({"List Supplier"})

                            Case "pgcusto"
                                _qCount = "SELECT COUNT(customer_kode) FROM data_customer_master WHERE customer_status IN (0,1)"
                                _qGetData = "SELECT customer_kode, customer_nama, CONCAT(UCASE(LEFT(jenis_nama,1)),SUBSTRING(jenis_nama,2)), " _
                                    & "customer_telpon, customer_fax, customer_cp, " _
                                    & "TRIM(BOTH ' Blok  No.000 RT. 000 RW. 000' FROM (CONCAT(REPLACE(REPLACE(customer_alamat,CHAR(13),' '),CHAR(10),' '), " _
                                    & " ' Blok ',IFNULL(customer_alamat_blok,'0'), " _
                                    & " ' No.',LPAD(customer_alamat_nomor,3,0), " _
                                    & " ' RT. ',LPAD(customer_alamat_rt,3,0), " _
                                    & " ' RW. ',LPAD(customer_alamat_rw,3,0)))) customer_alamat, customer_kecamatan, customer_kabupaten, customer_pasar, " _
                                    & "customer_provinsi, customer_kodepos, customer_nik, customer_npwp, customer_pajak_nama, customer_pajak_jabatan, " _
                                    & "customer_pajak_alamat, state.ref_text " _
                                    & "FROM data_customer_master " _
                                    & "LEFT JOIN data_customer_jenis ON customer_jenis=jenis_kode " _
                                    & "LEFT JOIN ref_jenis state ON state.ref_kode=customer_status AND state.ref_status=1 AND state.ref_type='status_master' " _
                                    & "WHERE customer_status IN (0,1) LIMIT {0},2000"
                                _columnHeader.AddRange({"Kode", "Nama Customer", "Jenis", "No.Telepon", "No.Fax", "Contact Person", "Alamat Customer", "Kecamatan",
                                                        "Kabupaten", "Pasar", "Provinsi", "Kode Pos", "NIK", "NPWP", "Nama NPWP", "Jabatan", "Alamat", "Status"})
                                _dataTitle.AddRange({"List Customer"})

                                'Case "pgpembelian"
                                '    _qCount = "SELECT faktur_kode, jenis.ref_text, faktur_tanggal_trans, faktur_pajak_no, faktur_pajak_tanggal, faktur_surat_jalan"
                            Case Else
                                Exit Sub
                        End Select

                        Using rdx = x.ReadCommand(_qCount, CommandBehavior.SingleRow)
                            Dim red = rdx.Read
                            If red And rdx.HasRows Then
                                _dtCount = IIf(rdx.Item(0) <= 2000, 1, Math.Ceiling(rdx.Item(0) / 2000))
                            End If
                        End Using

                        For i = 1 To _dtCount
                            Using dtx = x.GetDataTable(String.Format(_qGetData, (i * 2000) - 2000))
                                dtx.TableName = "export_" & i
                                _dtList.Add(dtx)
                            End Using
                        Next

                        Dim _fileLoc As String = _fileDir
                        If ExportExcel(_columnHeader, _dtList, _dataTitle, _fileDir, _fileExt, _fileLoc) Then
                            If System.IO.File.Exists(_fileLoc) = True Then
                                MessageBox.Show("Export Data Sukses", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Process.Start(_fileLoc)
                            End If
                        Else
                            MessageBox.Show("Export Tidak Berhasil", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Export data gagal. Tidak dapat terhubung ke database.", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
                MyBase.Cursor = Cursors.Default

            End If
        End If
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
                x.Open()
                If x.ConnectionState = ConnectionState.Open Then
                    Using rdx = x.ReadCommand(String.Format(qck, kode), CommandBehavior.SingleRow)
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            _dataState = rdx.Item("status")
                            ckdata = True
                        Else
                            ckdata = False
                            _msg = "Data tidak di temukan"
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

    Private Sub cancelItem()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If

        Dim _tbpg As String = tabpagename.Name.ToString
        Dim ckdata As Boolean = False
        Dim kode As String = ""
        Dim ket As String = ""
        Dim q As String = ""
        Dim queryArr As New List(Of String)
        Dim queryCk As Boolean = False
        Dim _msg As String = ""
        Dim refreshtab() As TabPage

        If MessageBox.Show("Batalkan transaksi?", "Pembatalan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Select Case _tbpg
            Case "pgpesanjual"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                ckdata = CheckCancelPesanan(kode, _msg)
                If ckdata Then
                    ckdata = TransConfirmValid(ket)
                    If Not ckdata Then : Exit Sub : End If
                End If
                q = "UPDATE data_penjualan_order_faktur SET j_order_status=2, j_order_upd_date=NOW(), j_order_upd_alias='{1}', " _
                    & " j_order_catatan=TRIM(BOTH '\r\n' FROM CONCAT(j_order_catatan,'\r\n','{2}')) WHERE j_order_kode='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id, ket))

                refreshtab = {pgpesanjual}

            Case "pgpembelian", "pghutangawal"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                If _tbpg = "pgpembelian" Then
                    ckdata = CheckCancelPembelian(kode, _msg)
                ElseIf _tbpg = "pghutangawal" Then
                    Dim tgl = CDate(dgv_list.SelectedRows.Item(0).Cells(1).Value)

                    If tgl < currentperiode.tglawal Then
                        ckdata = False
                        _msg = "Transaksi sebelum tanggal periode aktif/saat ini tidak dapat diubah."
                    ElseIf tgl >= currentperiode.tglawal And currentperiode.closed = True Then
                        ckdata = False
                        _msg = "Status periode aktif/saat ini sudah ditutup, tidak dapat melakukan perubahan data."
                    Else
                        ckdata = CheckCancelPembelian(kode, _msg)
                    End If
                End If

                If ckdata Then
                    ckdata = TransConfirmValid(ket)
                    If Not ckdata Then : Exit Sub : End If
                End If

                q = "UPDATE data_pembelian_faktur SET faktur_status=2, faktur_ket=TRIM(BOTH '\r\n' FROM CONCAT(faktur_ket,'\r\n','{2}')), faktur_upd_date=NOW(), faktur_upd_alias='{1}' " _
                    & "WHERE faktur_kode='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id, ket))
                q = "CALL transPembelianFin('{0}','{1}')"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id))

                refreshtab = {pgpembelian, pgstok, pghutangawal}

            Case "pgreturbeli"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                ckdata = CheckCancelRetur(kode, "beli", _msg)

                If ckdata Then
                    ckdata = TransConfirmValid(ket)
                    If Not ckdata Then : Exit Sub : End If
                End If

                q = "UPDATE data_pembelian_retur_faktur SET faktur_status=2, faktur_sebab=TRIM(BOTH '\r\n' FROM CONCAT(faktur_sebab,'\r\n','{2}')), faktur_upd_date=NOW(), " _
                    & "faktur_upd_alias='{1}' WHERE faktur_kode_bukti='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id, ket))
                q = "CALL transReturBeliFin('{0}','{1}')"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id))

                refreshtab = {pgreturbeli, pgstok}

            Case "pgpenjualan", "pgpiutangawal"
                If _tbpg = "pgpenjualan" Then
                    kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                    ckdata = CheckCancelPenjualan(kode, _msg)
                ElseIf _tbpg = "pgpiutangawal" Then
                    Dim tgl = CDate(dgv_list.SelectedRows.Item(0).Cells(1).Value)
                    kode = dgv_list.SelectedRows.Item(0).Cells(0).Value

                    If tgl < currentperiode.tglawal Then
                        ckdata = False
                        _msg = "Transaksi sebelum tanggal periode aktif/saat ini tidak dapat diubah."
                    ElseIf tgl >= currentperiode.tglawal And currentperiode.closed = True Then
                        ckdata = False
                        _msg = "Status periode aktif/saat ini sudah ditutup, tidak dapat melakukan perubahan data."
                    Else
                        ckdata = CheckCancelPenjualan(kode, _msg)
                    End If
                End If

                If ckdata Then
                    ckdata = TransConfirmValid(ket)
                    If Not ckdata Then : Exit Sub : End If
                End If

                q = "UPDATE data_penjualan_faktur SET faktur_status=2, faktur_catatan=TRIM(BOTH '\r\n' FROM CONCAT(faktur_catatan,'\r\n','{2}')), faktur_upd_date=NOW(), " _
                    & "faktur_upd_alias='{1}' WHERE faktur_kode='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id, ket))
                refreshtab = {pgpenjualan, pgstok, pgpiutangawal}

            Case "pgreturjual"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                ckdata = CheckCancelRetur(kode, "jual", _msg)

                If ckdata Then
                    ckdata = TransConfirmValid(ket)
                    If Not ckdata Then : Exit Sub : End If
                End If

                q = "UPDATE data_penjualan_retur_faktur SET faktur_status=2, faktur_sebab=TRIM(BOTH '\r\n' FROM CONCAT(faktur_sebab,'\r\n','{2}')), faktur_upd_date=NOW(), " _
                    & "faktur_upd_alias='{1}' WHERE faktur_kode_bukti='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id, ket))
                q = "CALL transReturJualFin('{0}','{1}')"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id))

                refreshtab = {pgreturbeli, pgstok}

            Case "pghutangbayar"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                ckdata = CheckCancelBayar(kode, "hutang", _msg)

                If ckdata Then
                    ckdata = TransConfirmValid(ket)
                    If Not ckdata Then : Exit Sub : End If
                End If

                q = "UPDATE data_hutang_bayar SET h_bayar_status=2, h_bayar_ket=TRIM(BOTH '\r\n' FROM CONCAT(h_bayar_ket,'\r\n','{2}')), h_bayar_upd_alias='{1}', " _
                    & "h_bayar_upd_date=NOW() WHERE h_bayar_bukti='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id, ket))
                q = "CALL transBayarHutangFin('{0}','{1}')"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id))

                refreshtab = {pghutangawal, pghutangbayar}

            Case "pgpiutangbayar"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                ckdata = CheckCancelBayar(kode, "piutang", _msg)

                If ckdata Then
                    ckdata = TransConfirmValid(ket)
                    If Not ckdata Then : Exit Sub : End If
                End If

                q = "UPDATE data_piutang_bayar SET p_bayar_status=2, p_bayar_ket=TRIM(BOTH '\r\n' FROM CONCAT(p_bayar_ket,'\r\n','{2}')), p_bayar_upd_alias='{1}', " _
                    & "p_bayar_upd_date=NOW() WHERE p_bayar_bukti='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id, ket))
                q = "CALL transBayarPiutangFin('{0}','{1}')"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id))

                refreshtab = {pgpiutangawal, pgpiutangbayar}

            Case "pgkas"
                kode = dgv_list.SelectedRows.Item(0).Cells(1).Value
                ckdata = CheckCancelKas(kode, _msg)

                If ckdata Then
                    Using x As New fr_tutupconfirm_dialog
                        x.lbl_title.Text = "Konfirmasi Kas"
                        x.in_user.Text = loggeduser.user_id
                        x.in_user.ReadOnly = True
                        x.do_loaddialog()
                        ckdata = x.returnval
                    End Using
                    If Not ckdata Then : Exit Sub : End If
                End If

                q = "UPDATE data_kas_faktur SET kas_status=2, kas_upd_date=NOW(), kas_upd_alias='{1}' WHERE kas_kode='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id))
                q = "UPDATE data_jurnal_line SET line_status=9, line_upd_date=NOW(), line_upd_alias='{1}' WHERE line_kode='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id))

                refreshtab = {pgkas}
            Case Else
                Exit Sub
        End Select

        If ckdata Then
            Using x = MainConnection
                x.Open()
                If x.ConnectionState = ConnectionState.Open Then
                    queryCk = x.TransactCommand(queryArr)
                    If queryCk Then
                        MessageBox.Show("Transaksi dibatalkan.")
                        DoRefreshTab_v2(refreshtab)
                    Else
                        _msg = "Terjadi kesalahan saat melakukan proses pembatalan"
                        MessageBox.Show("Transaksi tidak dapat dibatalkan." & Environment.NewLine & _msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    _msg = "Tidak dapat terhubung ke database"
                    MessageBox.Show("Transaksi tidak dapat dibatalkan." & Environment.NewLine & _msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Else
            MessageBox.Show("Transaksi tidak dapat dibatalkan." & Environment.NewLine & _msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    'PERUBAHAN STATUS DATA TRANSAKSI (NOT DATA ACTIVATION PROCEDURE)
    Private Sub changeStateTrans(TransState As Integer)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If

        Dim _tbpg As String = tabpagename.Name.ToString
        Dim ckdata As Boolean = False
        Dim kode As String = ""
        Dim ket As String = ""
        Dim q As String = ""
        Dim queryArr As New List(Of String)
        Dim queryCk As Boolean = False
        Dim _msg As String = ""
        Dim refreshtab() As TabPage
        Dim _MsgboxText As String = ""
        Dim _MsgboxTitle As String = ""

        If TransState = 1 Or TransState = 0 Then
            _MsgboxText = "Batalkan pembatalan transaksi?" : _MsgboxTitle = "Cancel Pembatalan"
        ElseIf TransState = 2 Then
            _MsgboxText = "Batalkan transaksi?" : _MsgboxTitle = "Pembatalan Transaksi"
        ElseIf TransState = 9 Then
            _MsgboxText = "Hapus transaksi?" : _MsgboxTitle = "Hapus Transaksi"
        Else
            Exit Sub
        End If

        If MessageBox.Show(_MsgboxText, _MsgboxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Select Case _tbpg
            Case "pgpesanjual"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                ckdata = IIf({0, 1}.Contains(TransState), True, CheckCancelPesanan(kode, _msg))
                If ckdata Then
                    ckdata = TransConfirmValid(ket)
                    If Not ckdata Then : Exit Sub : End If
                End If
                q = "UPDATE data_penjualan_order_faktur SET j_order_status={3}, j_order_upd_date=NOW(), j_order_upd_alias='{1}', " _
                    & " j_order_catatan=TRIM(BOTH '\r\n' FROM CONCAT(j_order_catatan,'\r\n','{2}')) WHERE j_order_kode='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id, ket, TransState))

                refreshtab = {pgpesanjual}

            Case "pgpembelian", "pghutangawal"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                If _tbpg = "pgpembelian" Then
                    ckdata = IIf({0, 1}.Contains(TransState), True, IIf(getTransStatus(kode, "pembelian", _msg) = 2 And TransState = 9, True, CheckCancelPembelian(kode, _msg)))
                ElseIf _tbpg = "pghutangawal" Then
                    Dim tgl = CDate(dgv_list.SelectedRows.Item(0).Cells(1).Value)

                    If tgl < currentperiode.tglawal Then
                        ckdata = False
                        _msg = "Transaksi sebelum tanggal periode aktif/saat ini tidak dapat diubah."
                    ElseIf tgl >= currentperiode.tglawal And currentperiode.closed = True Then
                        ckdata = False
                        _msg = "Status periode aktif/saat ini sudah ditutup, tidak dapat melakukan perubahan data."
                    Else
                        ckdata = IIf({0, 1}.Contains(TransState), True, CheckCancelPembelian(kode, _msg))
                    End If
                End If

                If ckdata Then
                    ckdata = TransConfirmValid(ket)
                    If Not ckdata Then : Exit Sub : End If
                End If

                q = "UPDATE data_pembelian_faktur SET faktur_status={3}, faktur_ket=TRIM(BOTH '\r\n' FROM CONCAT(faktur_ket,'\r\n','{2}')), faktur_upd_date=NOW(), " _
                    & "faktur_upd_alias='{1}' WHERE faktur_kode='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id, ket, TransState))
                If TransState = 9 Then
                    q = "UPDATE data_pembelian_faktur SET trans_status=9 WHERE trans_faktur='{0}'"
                    queryArr.Add(String.Format(q, kode))
                End If
                q = "CALL transPembelianFin('{0}','{1}')"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id))

                refreshtab = {pgpembelian, pgstok, pghutangawal}

            Case "pgpenjualan", "pgpiutangawal"
                If _tbpg = "pgpenjualan" Then
                    Dim _status As Integer = getTransStatus(kode, "penjualan", _msg)
                    kode = dgv_list.SelectedRows.Item(0).Cells(0).Value

                    ckdata = IIf({0, 1}.Contains(TransState), True, IIf(_status = 2 And TransState = 9, True, CheckCancelPenjualan(kode, _msg)))
                ElseIf _tbpg = "pgpiutangawal" Then
                    Dim tgl = CDate(dgv_list.SelectedRows.Item(0).Cells(1).Value)
                    kode = dgv_list.SelectedRows.Item(0).Cells(0).Value

                    If tgl < currentperiode.tglawal Then
                        ckdata = False
                        _msg = "Transaksi sebelum tanggal periode aktif/saat ini tidak dapat diubah."
                    ElseIf tgl >= currentperiode.tglawal And tgl <= currentperiode.tglakhir And currentperiode.closed = True Then
                        ckdata = False
                        _msg = "Status periode aktif/saat ini sudah ditutup, tidak dapat melakukan perubahan data."
                    Else
                        ckdata = IIf({0, 1}.Contains(TransState), True, CheckCancelPenjualan(kode, _msg))
                    End If
                End If

                If ckdata Then
                    ckdata = TransConfirmValid(ket)
                    If Not ckdata Then : Exit Sub : End If
                End If

                q = "UPDATE data_penjualan_faktur SET faktur_status={3}, faktur_catatan=TRIM(BOTH '\r\n' FROM CONCAT(faktur_catatan,'\r\n','{2}')), " _
                    & "faktur_upd_date=NOW(), faktur_upd_alias='{1}' WHERE faktur_kode='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id, ket, TransState))
                If TransState = 9 Then
                    q = "UPDATE data_penjualan_trans SET trans_status=9 WHERE trans_faktur='{0}'"
                    queryArr.Add(String.Format(q, kode))
                End If
                refreshtab = {pgpenjualan, pgstok, pgpiutangawal}

            Case "pgreturbeli"
                Dim _status As Integer = getTransStatus(kode, "returbeli", _msg)
                If _status = 9 And _msg <> Nothing Then ckdata = False

                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                If ckdata Then ckdata = IIf({0, 1}.Contains(TransState), True, IIf(_status = 2 And TransState = 9, True, CheckCancelRetur(kode, "beli", _msg)))

                If ckdata Then
                    ckdata = TransConfirmValid(ket)
                    If Not ckdata Then : Exit Sub : End If
                End If

                q = "UPDATE data_pembelian_retur_faktur SET faktur_status={3}, faktur_sebab=TRIM(BOTH '\r\n' FROM CONCAT(faktur_sebab,'\r\n','{2}')), " _
                    & "faktur_upd_date=NOW(), faktur_upd_alias='{1}' WHERE faktur_kode_bukti='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id, ket, TransState))
                If TransState = 9 Then
                    q = "UPDATE data_pembelian_retur_trans SET trans_status=9 WHERE trans_faktur='{0}'"
                    queryArr.Add(String.Format(q, kode))
                End If
                q = "CALL transReturBeliFin('{0}','{1}')"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id))

                refreshtab = {pgreturbeli, pgstok}

            Case "pgreturjual"
                Dim _status As Integer = getTransStatus(kode, "returbeli", _msg)
                If _status = 9 And _msg <> Nothing Then ckdata = False

                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                If ckdata Then ckdata = IIf({0, 1}.Contains(TransState), True, IIf(_status = 2 And TransState = 9, True, CheckCancelRetur(kode, "jual", _msg)))

                If ckdata Then
                    ckdata = TransConfirmValid(ket)
                    If Not ckdata Then : Exit Sub : End If
                End If

                q = "UPDATE data_penjualan_retur_faktur SET faktur_status={3}, faktur_sebab=TRIM(BOTH '\r\n' FROM CONCAT(faktur_sebab,'\r\n','{2}')), " _
                    & "faktur_upd_date=NOW(), faktur_upd_alias='{1}' WHERE faktur_kode_bukti='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id, ket, TransState))
                If TransState = 9 Then
                    q = "UPDATE data_penjualan_retur_trans SET trans_status=9 WHERE trans_faktur='{0}'"
                    queryArr.Add(String.Format(q, kode))
                End If
                q = "CALL transReturJualFin('{0}','{1}')"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id))

                refreshtab = {pgreturbeli, pgstok}

                'Case "pgadjstock"
                '    kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                '    'ask verification (stock trans validation priv)
                '    'query bulider
                '    refreshtab = {pgadjstock, pgstok}


            Case Else
                Exit Sub
        End Select

        'PROCEED
        Dim _failmsg As String = ""
        Dim _succmsg As String = ""
        If TransState = 1 Or TransState = 0 Then
            _failmsg = "Cancel pembatalan gagal." : _succmsg = "Cancel pembatalan berhasil"
        ElseIf TransState = 2 Then
            _failmsg = "Pembatalan transaksi gagal." : _succmsg = "Pembatalan transaksi berhasil."
        ElseIf TransState = 9 Then
            _failmsg = "Transaksi tidak dapat dihapus." : _succmsg = "Transaksi berhasil dihapus."
        Else
            Exit Sub
        End If

        If ckdata Then
            Using x = MainConnection
                x.Open()
                If x.ConnectionState = ConnectionState.Open Then
                    queryCk = x.TransactCommand(queryArr)
                    If queryCk Then
                        MessageBox.Show(_succmsg, _MsgboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DoRefreshTab_v2(refreshtab)
                    Else
                        _msg = "Terjadi kesalahan saat melakukan proses."
                        MessageBox.Show(_failmsg & Environment.NewLine & _msg, _MsgboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    _msg = "Tidak dapat terhubung ke database"
                    MessageBox.Show(_failmsg & Environment.NewLine & _msg, _MsgboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Else
            MessageBox.Show(_failmsg & Environment.NewLine & _msg, _MsgboxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function changeStateTrans_beli(IdFaktur As String, TransState As Integer) As Boolean
        Dim q As String = ""
        Dim qArr As New List(Of String)
        Dim _oldState As Integer = 1
        Dim _msgText, _msgTitle As String

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                If tabpagename.Name = "pgpembelian" Then
                    q = "SELECT faktur_status FROM data_pembelian WHERE faktur_kode='{0}' ORDER BY faktur_id DESC LIMIT 1"
                ElseIf tabpagename.Name = "pgreturbeli" Then
                    q = "SELECT faktur_status FROM data_pembelian_retur_faktur WHERE faktur_kode_bukti='{0}' ORDER BY faktur_id DESC LIMIT 1"
                ElseIf tabpagename.Name = "pghutangawal" Then
                    'cek tgl hutang, status lunas, pembayaran
                    q = "SELECT hutang_tanggal, hutang_status_lunas, FROM data_hutang_awal WHERE hutang_faktur='{0}'"
                    q = "SELECT faktur_status FROM data_pembelian WHERE faktur_kode='{0}' ORDER BY faktur_id DESC LIMIT 1"
                Else
                    Return False : Exit Function
                End If
                If Integer.TryParse(x.ExecScalar(String.Format(q, IdFaktur)), _oldState) Then

                Else

                    Return False : Exit Function
                End If

                Select Case TransState
                    Case 1

                        _msgText ="Cancel pembatalan transaksi?" : _msgTitle = "Cancel Pembatalan"
                    Case 2

                        _msgText = "Batalkan Transaksi?" : _msgTitle = "Pembatalan Transaksi"
                    Case 9

                        _msgText = "Hapus Transaksi?" : _msgTitle = "Hapus Transaksi"
                    Case Else
                        Return False : Exit Function
                End Select

                Return True
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Using
    End Function

    Private Function changeStateTrans_jual(IdFaktur As String, TransState As Integer) As Boolean

        Return False
    End Function

    Private Function changeStateTrans_hutang(IdFaktur As String, TransState As Integer) As Boolean

        Return False
    End Function

    Private Function changeStateTrans_piutang(IdFaktur As String, TransState As Integer) As Boolean

        Return False
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
            Dim _v As Boolean = False : Dim _idValid As Integer = 0
            Using _validDialog As New fr_akun_confirmdialog
                _validDialog.do_loaddialog()
                _v = _validDialog.RetVal.Key
                If _v Then : LogValidTrans(_validDialog.RetVal.Value, loggeduser.user_id, "JU.ENTRY", "DELETE", IdJurnal, _idValid)
                Else : Exit Sub
                End If
            End Using

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

    'SEPUTAR DATA PENUTUPAN
    Private Sub ReopenAccPeriode(IdPeriode As String)
        If deact_sw Then
            Dim _q As String = "" : Dim _qArr As New List(Of String)
            Dim _ck As Boolean = False
            Dim _resMsg As DialogResult = DialogResult.No
            _resMsg = MessageBox.Show("", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If _resMsg = DialogResult.Yes Then
                Using _valid As New fr_akun_confirmdialog
                    _valid.do_loaddialog()
                    If _valid.RetVal.Key = False Then Exit Sub
                    'logvalidasi
                End Using
                _q = ""

                Using x = MainConnection
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        _ck = x.TransactCommand(_qArr)
                        If _ck Then
                            MessageBox.Show("")

                        Else

                        End If
                    Else

                    End If
                End Using
            End If
        End If
    End Sub

    Private Sub OpenAccReport(ReportType As String, IdPeriode As String)

    End Sub

    Private Sub DeleteClosing(IdPeriode As String)
        If delete_sw Then
            If IdPeriode = currentperiode.id Then
                MessageBox.Show("Cannot delete current active periode.", "Delete Closing", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
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
        If export_sw = True And dgv_list.RowCount > 0 Then
            exportItem()
        ElseIf dgv_list.Rows.Count = 0 Then
            MessageBox.Show("Data tidak ada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub mn_bataljual_Click(sender As Object, e As EventArgs) Handles mn_bataljual.Click
        If cancel_sw = True And dgv_list.Rows.Count > 0 Then
            cancelItem()
        ElseIf dgv_list.Rows.Count = 0 Then
            MessageBox.Show("Data tidak ada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub mn_delete_Click(sender As Object, e As EventArgs) Handles mn_delete.Click
        If delete_sw And dgv_list.Rows.Count > 0 Then
            changeStateTrans(9)
        ElseIf dgv_list.Rows.Count = 0 Then
            MessageBox.Show("Data tidak ada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub mn_cancelbatal_Click(sender As Object, e As EventArgs) Handles mn_cancelbatal.Click
        If cancel_sw And dgv_list.Rows.Count > 0 Then
            Dim kode As String = ""
            Dim _jenis As String = ""
            Dim _status As Integer = 0
            Dim _msg As String = Nothing

            Select Case tabpagename.Name.ToString
                Case "pgpesanjual", "pgpiutangbayar"
                    kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                    If tabpagename.Name.ToString = "pgpesanjual" Then
                        _jenis = "pesanan"
                    Else
                        _jenis = "piutangbayar"
                    End If
                    _status = 0
                Case "pgpenjualan", "pgpembelian", "pgreturjual", "pgreturbeli", "pghutangbayar"
                    kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                    Select Case tabpagename.Name.ToString
                        Case "pgpenjualan" : _jenis = "penjualan"
                        Case "pgpembelian" : _jenis = "pembelian"
                        Case "pgreturjual" : _jenis = "returjual"
                        Case "pgreturbeli" : _jenis = "returbeli"
                        Case "pghutangbayar" : _jenis = "hutangbayar"
                    End Select
                    _status = 1
                Case Else
                    Exit Sub
            End Select

            Dim _oldstatus As Integer = getTransStatus(kode, _jenis, _msg)
            If _msg <> Nothing Then : MessageBox.Show(_msg, "Cancel Pembatalan", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub : End If
            If _oldstatus = 2 Then changeStateTrans(_status)
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
        Me.Cursor = Cursors.WaitCursor
        SearchParam = in_cari.Text
        If date_sw Then
            SelectedDate1 = date_tglawal.Value : SelectedDate2 = date_tglakhir.Value
            LoadDataGrid(in_cari.Text, 1, date_tglawal.Value, date_tglakhir.Value)
        Else
            LoadDataGrid(in_cari.Text, 1)
        End If
        dgv_list.Focus()
        Me.Cursor = Cursors.Default
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
            date_tglawal.Value = SelectedDate1 : date_tglakhir.Value = date_tglakhir.Value
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
            date_tglawal.Value = SelectedDate1 : date_tglakhir.Value = date_tglakhir.Value
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
