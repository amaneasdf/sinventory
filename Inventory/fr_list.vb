Public Class fr_list
    Public tabpagename As TabPage
    'Private rowindex As Integer = 0
    Public edit_sw As Boolean = True
    Public add_sw As Boolean = True
    Public del_sw As Boolean = True
    Public export_sw As Boolean = False
    Public print_sw As Boolean = False
    Public search_sw As Boolean = True
    Public cancel_sw As Boolean = False
    Public bayar_sw As Boolean = False
    Public valid_sw As Boolean = False
    Public delete_sw As Boolean = False

    Public Sub setpage(page As TabPage)
        tabpagename = page
        Me.Text = page.Text
        setMenuSw()
    End Sub

    'KEYSHORTCUT
    Protected Overrides Function ProcessKeyPreview(ByRef m As Message) As Boolean
        If m.Msg = &H100 Or m.Msg = &H101 Then  'WM_KEYDOWN / WM_KEYUP
            Dim key As Keys = m.WParam
            If key = Keys.F5 Then
                performRefresh()
                Return True
            ElseIf key = Keys.N And My.Computer.Keyboard.CtrlKeyDown Then
                addItem()
                Return True
            ElseIf key = Keys.F And My.Computer.Keyboard.CtrlKeyDown Then
                in_cari.Focus()
                Return True
            ElseIf key = Keys.O And My.Computer.Keyboard.CtrlKeyDown Then
                editItem()
                Return True
            ElseIf key = Keys.P And My.Computer.Keyboard.CtrlKeyDown Then
                printItem()
                Return True
            End If
        End If

        Return MyBase.ProcessKeyPreview(m)
    End Function

    Public Sub performRefresh()
        Dim _editmenutxt As String = "Edit Data"
        Dim frm As fr_list
        Me.Cursor = Cursors.AppStarting
        Select Case tabpagename.Name.ToString
            Case "pgbarang"
                frm = frmbarang
                populateDGVUserCon("barang", "", frm.dgv_list)
            Case "pgsupplier"
                frm = frmsupplier
                populateDGVUserCon("supplier", "", Me.dgv_list)
            Case "pggudang"
                frm = frmgudang
                populateDGVUserCon("gudang", "", frm.dgv_list)
            Case "pgsales"
                frm = frmsales
                populateDGVUserCon("sales", "", frm.dgv_list)
            Case "pgcusto"
                frm = frmcusto
                populateDGVUserCon("custo", "", frm.dgv_list)
            Case "pgbgtangan"
                frm = frmbgditangan
                populateDGVUserCon("giro", "", frm.dgv_list)
            Case "pgperkiraan"
                frm = frmperkiraan
                populateDGVUserCon("perkiraan", "", frm.dgv_list)
            Case "pgawalneraca"
                populateDGVUserCon("neracaawal", "", frmawalneraca.dgv_list)
            Case "pgpembelian"
                frm = frmpembelian
                populateDGVUserCon("beli", "", frm.dgv_list)
            Case "pgreturbeli"
                frm = frmreturbeli
                populateDGVUserCon("returbeli", "", frm.dgv_list)
            Case "pgpesanjual"
                frm = frmpesanjual
                populateDGVUserCon("pesanan", "", frm.dgv_list)
            Case "pgpenjualan"
                frm = frmpenjualan
                populateDGVUserCon("jual", "", frm.dgv_list)
            Case "pgreturjual"
                frm = frmreturjual
                populateDGVUserCon("returjual", "", frm.dgv_list)
            Case "pgstok"
                populateDGVUserCon("stok", "", frmstok.dgv_list)
            Case "pgmutasigudang"
                populateDGVUserCon("mutasigudang", "", frmmutasigudang.dgv_list)
            Case "pgmutasistok"
                populateDGVUserCon("mutasistok", "", frmmutasistok.dgv_list)
            Case "pgstockop"
                populateDGVUserCon("stockop", "", frmstockop.dgv_list)
            Case "pghutangawal"
                frm = frmhutangawal
                populateDGVUserCon("hutangawal", "", frmhutangawal.dgv_list)
            Case "pghutangbayar"
                frm = frmhutangbayar
                populateDGVUserCon("hutangbayar", "", frm.dgv_list)
            Case "pghutangbgo"
                populateDGVUserCon("hutangbgo", "", frmhutangbgo.dgv_list)
            Case "pgpiutangawal"
                frm = frmpiutangawal
                populateDGVUserCon("piutangawal", "", frmpiutangawal.dgv_list)
            Case "pgpiutangbayar"
                frm = frmpiutangbayar
                populateDGVUserCon("piutangbayar", "", frm.dgv_list)
            Case "pgpiutangbgcair"
                populateDGVUserCon("piutangbgcair", "", frmpiutangbgcair.dgv_list)
            Case "pgpiutangbgtolak"
                populateDGVUserCon("piutangbgtolak", "", frmpiutangbgTolak.dgv_list)
            Case "pgkas"
                populateDGVUserCon("kas", "", frmkas.dgv_list)
            Case "pgjurnalumum"
                populateDGVUserCon("jurnalumum", "", frmjurnalumum.dgv_list)
                lbl_judul.Text = "List Jurnal Umum"
            Case "pgjurnalmemorial"
                populateDGVUserCon("jurnalmemorial", "", frmjurnalmemorial.dgv_list)
            Case "pggroup"
                populateDGVUserCon("group", "", frmgroup.dgv_list)
            Case "pguser"
                populateDGVUserCon("user", "", Me.dgv_list)
            Case Else
                Exit Sub
        End Select
        Me.Cursor = Cursors.Default
        in_cari.Clear()
        in_countdata.Text = dgv_list.RowCount


        Select Case tabpagename.Name.ToString
            Case "pgpesanjual"
                With frm
                    .valid_sw = IIf(selectperiode.closed = False, loggeduser.validasi_trans, False)
                    .del_sw = False
                    .add_sw = IIf(selectperiode.closed = True, False, True)
                    .mn_edit.Text = IIf(selectperiode.closed = True, "Tampilkan Detail", "Edit Data")
                End With
            Case "pgpembelian", "pgreturbeli", "pgpenjualan", "pgreturjual", "pghutangbayar"
                With frm
                    .print_sw = True
                    .add_sw = IIf(selectperiode.closed = True, False, True)
                    .cancel_sw = IIf(selectperiode.closed = False, loggeduser.allowedit_transact, False)
                    .del_sw = False
                    .mn_edit.Text = IIf(selectperiode.closed = True, "Tampilkan Detail", "Edit Data")
                End With
            Case "pghutangawal", "pgpiutangawal"
                Dim _kdMn As String = ""

                If tabpagename.Name.ToString = "pghutangawal" Then
                    _kdMn = "mn0402"
                Else
                    _kdMn = "mn0502"
                End If

                With frm
                    .add_sw = False
                    .bayar_sw = IIf(selectperiode.closed = True, False, IIf(main.listkodemenu.Contains(_kdMn), True, False))
                    .del_sw = False
                    .cancel_sw = IIf(selectperiode.closed = True, False, True)
                    .mn_edit.Text = "Tampilkan Detail"
                    .bayar_sw = False
                End With
        End Select
        'mn_edit.Text = "Edit Data"
        setMenuSw()
    End Sub

    Private Sub setMenuSw()
        'menu bar
        mn_add.Visible = add_sw
        mn_edit.Visible = edit_sw
        mn_deact.Visible = del_sw
        mn_export.Visible = export_sw
        mn_print.Visible = print_sw
        mn_bataljual.Visible = cancel_sw
        mn_cancelbatal.Visible = cancel_sw
        mn_bayar.Visible = bayar_sw
        mn_validasi.Visible = valid_sw
        mn_delete.Visible = delete_sw
    End Sub

    Private Sub addItem()
        If add_sw = True Then
            Console.WriteLine(tabpagename.Name.ToString)
            Me.Cursor = Cursors.AppStarting
            Select Case tabpagename.Name.ToString
                Case "pgbarang" : Dim brg As New fr_barang_detail : brg.doLoadNew()
                Case "pgsupplier" : Dim spl As New fr_supplier_detail : spl.doLoadNew()
                Case "pggudang" : Dim x As New fr_gudang_detail : x.doLoadNew()
                Case "pgsales" : Dim x As New fr_sales_detail : x.doLoadNew()
                Case "pgcusto" : Dim x As New fr_custo_detail : x.doLoadNew()
                Case "pgbank"
                    fr_bank_detail.ShowDialog()
                Case "pgbgtangan"
                    fr_giro_detail.ShowDialog()
                Case "pgperkiraan"
                    Dim x As New fr_perkiraan_detail
                    x.Show()
                Case "pgawalneraca"
                    fr_neracaawal_detail.ShowDialog()
                Case "pgpembelian" : Dim bd As New fr_beli_detail : bd.doLoadNew()
                    'bd.Show(main)
                    'bd.do_load()
                Case "pgreturbeli" : Dim rb As New fr_beli_retur_detail : rb.doLoadNew()
                Case "pgpesanjual" : Dim rb As New fr_pesan_detail : rb.doLoadNew()
                Case "pgpenjualan" : Dim jd As New fr_jual_detail : jd.doLoadNew()
                Case "pgreturjual" : Dim rj As New fr_jual_retur_detail : rj.doLoadNew()
                Case "pgstok"
                    Dim x As New fr_stok_awal
                    x.ShowDialog(main)
                    'Case "pgmutasigudang"
                    '    fr_stok_mutasi.ShowDialog(main)
                    'Case "pgmutasistok"
                    '    fr_stok_mutasi_barang.ShowDialog(main)
                    'Case "pgstockop"
                    '    fr_stock_op.ShowDialog(main)
                Case "pghutangbayar" : Dim frhb As New fr_hutang_bayar : frhb.doLoadNew()
                Case "pgpiutangbayar" : Dim frpb As New fr_piutang_bayar : frpb.doLoadNew()
                    'Case "pgpiutangbgtolak"
                    'fr_bg_tolak.ShowDialog(main)
                Case "pgkas" : Dim frkas As New fr_kas_detail : frkas.doLoadNew()
                    'Case "pgjurnalumum"

                    'Case "pgjurnalmemorial"
                    '    fr_jurnal_mem.ShowDialog(main)
                Case "pggroup" : Dim frgrp As New fr_group_detail : frgrp.doLoadNew(loggeduser.admin_pc)
                Case "pguser" : Dim frusr As New fr_user_detail : frusr.doLoadNew(loggeduser.admin_pc)
                    'Case "pgjenisbarang"
                    '    fr_jenis_barang.setfor = "jenisbarang"
                    '    fr_jenis_barang.ShowDialog()
                Case Else
                    MessageBox.Show("Under Construction")
            End Select
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub editItem()
        If edit_sw = True Then
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

                    Case "pgbgtangan"
                        Dim detail As New fr_giro_detail
                        With detail
                            .bt_simpangiro.Text = "Update"
                            .Text += dgv_list.SelectedRows.Item(0).Cells(1).Value
                            .in_kode.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .Show()
                        End With
                    Case "pgperkiraan"
                        Dim detail As New fr_perkiraan_detail
                        With detail
                            .bt_simpanperkiraan.Text = "Update"
                            .Text += dgv_list.SelectedRows.Item(0).Cells(2).Value
                            .in_kode.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .Show()
                        End With
                    Case "pgawalneraca"
                        Using detail As New fr_neracaawal_detail
                            With detail
                                .bt_simpanmigrasi.Text = "Update"
                                .Text += dgv_list.SelectedRows.Item(0).Cells(4).Value
                                .in_kode.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                                .ShowDialog()
                            End With
                        End Using
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
                        Using detail As New fr_hutang_awal
                            With detail
                                .bt_batalreturbeli.Text = "OK"
                                .in_faktur.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                                .ShowDialog(main)
                            End With
                        End Using
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
                        Using detail As New fr_piutang_awal
                            With detail
                                .bt_batalreturbeli.Text = "OK"
                                .in_faktur.Text = dgv_list.SelectedRows.Item(0).Cells("faktur").Value
                                .ShowDialog(main)
                            End With
                        End Using
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
                        'Case "pgpiutangbgtolak"
                        'Using detail As New fr_bg_tolak
                        '    With detail
                        '        .bt_simpanperkiraan.Text = "Update"

                        '        .ShowDialog(main)
                        '    End With
                        'End Using
                    Case "pgkas"
                        Dim detail As New fr_kas_detail
                        If selectperiode.closed Then
                            detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(1).Value)
                        Else
                            detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(1).Value, loggeduser.allowedit_transact)
                        End If

                    Case "pgjurnalumum"
                        Dim detail As New fr_jurnal_u_det
                        Dim row As DataGridViewRow = dgv_list.SelectedRows.Item(0)
                        Dim kode As String = dgv_list.SelectedRows.Item(0).Cells(0).Value
                        With detail
                            .doLoad(kode, row.Cells(6).Value)
                            .in_kode.Text = kode
                            .Text += "#" & kode & " - " & row.Cells(2).Value
                            .Show(main)
                        End With
                    Case "pgjurnalmemorial"
                        Using detail As New fr_jurnal_mem
                            With detail
                                .bt_simpanperkiraan.Text = "Update"

                                .ShowDialog(main)
                            End With
                        End Using
                    Case "pggroup"
                        Dim detail As New fr_group_detail
                        detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.admin_pc)
                    Case "pguser"
                        Dim detail As New fr_user_detail
                        detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.admin_pc)
                    Case Else
                        MessageBox.Show("Under Construction")
                End Select
                Me.Cursor = Cursors.Default
            Else
                MessageBox.Show("Data tidak tersedia")
            End If
        End If
    End Sub

    Private Sub bayarItem()
        Dim _kode As String = ""
        Dim q As String = ""
        Dim ck As Boolean = False

        op_con()
        Select Case tabpagename.Name.ToString
            Case "pgpiutangawal"
                Dim x As New fr_piutang_bayar
                _kode = dgv_list.SelectedRows.Item(0).Cells(0).Value

                q = "SELECT piutang_status_lunas, piutang_status_approve, SUM(p_trans_nilai), SUM(p_trans_nilai_giro) FROM data_piutang_awal " _
                    & "LEFT JOIN data_piutang_trans ON piutang_faktur=p_trans_kode_piutang AND p_trans_periode='{1}'" _
                    & "WHERE piutang_faktur='{0}' GROUP BY piutang_faktur"
                readcommd(String.Format(q, _kode, selectperiode.id))
                If rd.HasRows Then
                    If rd.Item(0) = 1 Or (rd.Item(2) = 0 And rd.Item(3) = 0) Then
                        ck = False
                        MessageBox.Show("Piutang " & _kode & "sudah lunas.", "Pembayaran Piutang", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf rd.Item(1) = 1 Then
                        ck = False
                        MessageBox.Show("Terdapat pembayaran yg belum diproses untuk piutang " & _kode & ". Harap cek kembali data transaksi pembayaran piutang.",
                                        "Pembayaran Piutang", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        ck = True
                    End If
                Else
                    ck = False
                    MessageBox.Show("Data piutang " & _kode & "tidak dapat ditemukan.", "Pembayaran Piutang", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                rd.Close()
                If ck = False Then
                    Exit Sub
                End If

                With x
                    .doLoadNew()
                    q = "SELECT piutang_custo, customer_nama, piutang_sales, salesman_nama, getSisaTitipan('piutang','{1}',piutang_custo), " _
                        & "getSisaPiutang(piutang_faktur,'{1}'), piutang_awal, piutang_jt,piutang_pajak " _
                        & "FROM data_piutang_awal " _
                        & "LEFT JOIN data_customer_master ON piutang_custo=customer_kode " _
                        & "LEFT JOIN data_salesman_master ON salesman_kode=piutang_sales " _
                        & "WHERE piutang_faktur='{0}'"
                    readcommd(String.Format(q, _kode, selectperiode.id))
                    If rd.HasRows Then
                        .cb_pajak.SelectedValue = rd.Item("piutang_pajak")
                        .in_custo.Text = rd.Item(0)
                        .in_custo_n.Text = rd.Item(1)
                        .in_sales.Text = rd.Item(2)
                        .in_sales_n.Text = rd.Item(3)
                        .in_saldotitipan.Text = commaThousand(rd.Item(4))

                        .in_faktur.Text = _kode
                        .in_tgl_jtfaktur.Text = CDate(rd.Item(7)).ToString("dd/MM/yyyy")
                        .in_sisafaktur.Text = commaThousand(rd.Item(5))
                        ._totalhutang = rd.Item(6)
                    End If
                    rd.Close()

                End With
            Case "pghutangawal"
                Dim x As New fr_hutang_bayar
                _kode = dgv_list.SelectedRows.Item(0).Cells(0).Value

                q = "SELECT SUM(h_trans_nilai),SUM(h_trans_nilai_giro) FROM data_hutang_trans " _
                    & "WHERE h_trans_periode='{1}' AND h_trans_kode_hutang='{0}' GROUP BY h_trans_kode_hutang"
                readcommd(String.Format(q, _kode, selectperiode.id))
                If rd.HasRows Then
                    If rd.Item(0) = 0 And rd.Item(1) = 0 Then
                        ck = False
                        MessageBox.Show("Hutang " & _kode & "sudah lunas.", "Pembayaran Hutang", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf rd.Item(1) > 0 Then
                        Dim msgRes As DialogResult = MessageBox.Show("Terdapat BG untuk hutang " & _kode & " yang belum tercairkan. Lanjutkan proses pembayaran?",
                                                                     "Pembayaran Hutang", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If msgRes = DialogResult.Yes Then
                            ck = True
                        Else
                            ck = False
                        End If
                    Else
                        ck = True
                    End If
                Else
                    ck = False
                    MessageBox.Show("Data hutang " & _kode & "tidak dapat ditemukan.", "Pembayaran Hutang", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                rd.Close()
                If ck = False Then
                    Exit Sub
                End If

                With x
                    .doLoadNew()
                    q = "SELECT hutang_supplier, supplier_nama,getSisaTitipan('hutang','{1}',hutang_supplier), getSisaHutang(hutang_faktur,'{1}'),hutang_awal, " _
                        & "hutang_tgl_jt, hutang_pajak " _
                        & "FROM data_hutang_awal " _
                        & "LEFT JOIN data_supplier_master ON hutang_supplier=supplier_kode " _
                        & "WHERE hutang_faktur='{0}'"
                    readcommd(String.Format(q, _kode, selectperiode.id))
                    If rd.HasRows Then
                        .cb_pajak.SelectedValue = rd.Item("hutang_pajak")
                        .in_supplier.Text = rd.Item(0)
                        .in_supplier_n.Text = rd.Item(1)
                        .in_saldotitipan.Text = commaThousand(rd.Item(2))

                        .in_faktur.Text = _kode
                        .in_tgl_jtfaktur.Text = CDate(rd.Item(5)).ToString("dd/MM/yyyy")
                        .in_sisafaktur.Text = commaThousand(rd.Item(3))
                        ._totalhutang = rd.Item(4)
                    End If
                    rd.Close()

                End With
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
    Private Sub deactItem()
        If del_sw = True Then
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
                        doRefreshTab(refreshtab)
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
                        doRefreshTab(refreshtab)
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

                q = "UPDATE data_penjualan_faktur SET faktur_status={3}, faktur_catatan=TRIM(BOTH '\r\n' FROM CONCAT(faktur_catatan,'\r\n','{2}')), faktur_upd_date=NOW(), " _
                    & "faktur_upd_alias='{1}' WHERE faktur_kode='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id, ket, TransState))
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

                q = "UPDATE data_pembelian_retur_faktur SET faktur_status={3}, faktur_sebab=TRIM(BOTH '\r\n' FROM CONCAT(faktur_sebab,'\r\n','{2}')), faktur_upd_date=NOW(), " _
                    & "faktur_upd_alias='{1}' WHERE faktur_kode_bukti='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id, ket, TransState))
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

                q = "UPDATE data_penjualan_retur_faktur SET faktur_status={3}, faktur_sebab=TRIM(BOTH '\r\n' FROM CONCAT(faktur_sebab,'\r\n','{2}')), faktur_upd_date=NOW(), " _
                    & "faktur_upd_alias='{1}' WHERE faktur_kode_bukti='{0}'"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id, ket, TransState))
                q = "CALL transReturJualFin('{0}','{1}')"
                queryArr.Add(String.Format(q, kode, loggeduser.user_id))

                refreshtab = {pgreturbeli, pgstok}

            Case Else
                Exit Sub
        End Select

        'PROCEED
        Dim _failmsg As String = ""
        Dim _succmsg As String = ""
        If TransState = 1 Or TransState = 0 Then
            _failmsg = "Pembatalan gagal." : _succmsg = "Pembatalan Berhasil"
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
                        doRefreshTab(refreshtab)
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

    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            'rowindex = 0
            Console.WriteLine(tabpagename.Name.ToString)
            Select Case tabpagename.Name.ToString
                Case "pgbarang"
                    populateDGVUserCon("barang", in_cari.Text, frmbarang.dgv_list)
                Case "pgsupplier"
                    populateDGVUserCon("supplier", in_cari.Text, frmsupplier.dgv_list)
                Case "pggudang"
                    populateDGVUserCon("gudang", in_cari.Text, frmgudang.dgv_list)
                Case "pgsales"
                    populateDGVUserCon("sales", in_cari.Text, frmsales.dgv_list)
                Case "pgcusto"
                    populateDGVUserCon("custo", in_cari.Text, frmcusto.dgv_list)
                Case "pgbgtangan"
                    populateDGVUserCon("giro", in_cari.Text, frmbgditangan.dgv_list)
                Case "pgperkiraan"
                    populateDGVUserCon("perkiraan", in_cari.Text, frmperkiraan.dgv_list)
                Case "pgawalneraca"
                    populateDGVUserCon("neracaawal", in_cari.Text, frmawalneraca.dgv_list)
                Case "pgpembelian"
                    populateDGVUserCon("beli", in_cari.Text, frmpembelian.dgv_list)
                Case "pgreturbeli"
                    populateDGVUserCon("returbeli", in_cari.Text, frmreturbeli.dgv_list)
                Case "pgpesanjual"
                    populateDGVUserCon("pesanan", in_cari.Text, frmpesanjual.dgv_list)
                Case "pgpenjualan"
                    populateDGVUserCon("jual", in_cari.Text, frmpenjualan.dgv_list)
                Case "pgreturjual"
                    populateDGVUserCon("returjual", in_cari.Text, frmreturjual.dgv_list)
                Case "pgstok"
                    populateDGVUserCon("stok", in_cari.Text, frmstok.dgv_list)
                Case "pgmutasigudang"
                    populateDGVUserCon("mutasigudang", in_cari.Text, frmmutasigudang.dgv_list)
                Case "pgmutasistok"
                    populateDGVUserCon("mutasistok", in_cari.Text, frmmutasistok.dgv_list)
                Case "pgstockop"
                    populateDGVUserCon("stockop", in_cari.Text, frmstockop.dgv_list)
                Case "pghutangawal"
                    populateDGVUserCon("hutangawal", in_cari.Text, frmhutangawal.dgv_list)
                Case "pghutangbayar"
                    populateDGVUserCon("hutangbayar", in_cari.Text, frmhutangbayar.dgv_list)
                Case "pghutangbgo"
                    populateDGVUserCon("hutangbgo", in_cari.Text, frmhutangbgo.dgv_list)
                Case "pgpiutangawal"
                    populateDGVUserCon("piutangawal", in_cari.Text, frmpiutangawal.dgv_list)
                Case "pgpiutangbayar"
                    populateDGVUserCon("piutangbayar", in_cari.Text, frmpiutangbayar.dgv_list)
                Case "pgpiutangbgcair"
                    populateDGVUserCon("piutangbgcair", in_cari.Text, frmpiutangbgcair.dgv_list)
                Case "pgpiutangbgtolak"
                    populateDGVUserCon("piutangbgtolak", in_cari.Text, frmpiutangbgTolak.dgv_list)
                Case "pgkas"
                    populateDGVUserCon("kas", in_cari.Text, frmkas.dgv_list)
                Case "pgjurnalumum"
                    populateDGVUserCon("jurnalumum", in_cari.Text, frmjurnalumum.dgv_list)
                Case "pgjurnalmemorial"
                    populateDGVUserCon("jurnalmemorial", in_cari.Text, frmjurnalmemorial.dgv_list)
                    'Case "pgjenisbarang"
                    '    populateDGVUserCon("jenisbarang", in_cari.Text, frmjenisbarang.dgv_list)
                Case "pggroup"
                    populateDGVUserCon("group", in_cari.Text, frmgroup.dgv_list)
                Case "pguser"
                    populateDGVUserCon("user", in_cari.Text, frmuser.dgv_list)
            End Select
            dgv_list.Focus()
        End If
        in_countdata.Text = dgv_list.RowCount
    End Sub

    '---------------- LOAD
    Private Sub fr_list_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setMenuSw()
    End Sub

    '---------------- CLOSE
    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        main.tabcontrol.TabPages.Remove(tabpagename)
        'rowindex = 0
    End Sub

    '---------------- DGV ITEM LIST
    Private Sub dgv_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellClick
        'rowindex = e.RowIndex
    End Sub

    Private Sub dgv_list_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_list.ColumnHeaderMouseClick
        dgv_list.ClearSelection()
        'rowindex = 0
    End Sub

    Private Sub dgv_list_ColumnHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_list.ColumnHeaderMouseDoubleClick
        dgv_list.ClearSelection()
        'rowindex = 0
    End Sub

    Private Sub dgv_list_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                'rowindex = e.RowIndex
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
        performRefresh()
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_deact.Click
        If del_sw = True And dgv_list.RowCount > 0 Then
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
                    'With detail
                    '    .bt_simpanjual.Text = "Update"
                    '    .lbl_title.Text = "Form Validasi Order Pembelian"
                    '    .Text += "#" & dgv_list.SelectedRows.Item(0).Cells(0).Value
                    '    .in_faktur.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                    '    .Show(main)
                    '    .doLoad(, "valid")
                    'End With
                    'Case "pgpiutangbayar"

                    'Case Else
                    '    Exit Sub
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
End Class
