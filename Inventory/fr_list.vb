﻿Public Class fr_list
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

    Public Sub setpage(page As TabPage)
        tabpagename = page
        setMenuSw()
        consoleWriteLine("pg" & page.Name.ToString)
        consoleWriteLine("pgset" & tabpagename.Name.ToString)
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
            ElseIf key = Keys.Delete And My.Computer.Keyboard.CtrlKeyDown Then

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
        consoleWriteLine(tabpagename.Name.ToString)
        Dim frm As fr_list
        Me.Cursor = Cursors.AppStarting
        Select Case tabpagename.Name.ToString
            Case "pgbarang"
                frm = frmbarang
                populateDGVUserCon("barang", "", frm.dgv_list)
            Case "pgsupplier"
                frm = frmsupplier
                populateDGVUserCon("supplier", "", frm.dgv_list)
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
                populateDGVUserCon("hutangawal", "", frmhutangawal.dgv_list)
            Case "pghutangbayar"
                frm = frmhutangbayar
                populateDGVUserCon("hutangbayar", "", frm.dgv_list)
            Case "pghutangbgo"
                populateDGVUserCon("hutangbgo", "", frmhutangbgo.dgv_list)
            Case "pgpiutangawal"
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
                populateDGVUserCon("user", "", frmuser.dgv_list)
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
        End Select
        'mn_edit.Text = "Edit Data"
        setMenuSw()
    End Sub

    Private Sub setMenuSw()
        'menu bar
        mn_add.Visible = add_sw
        mn_edit.Visible = edit_sw
        mn_del.Visible = del_sw
        mn_export.Visible = export_sw
        mn_print.Visible = print_sw
        mn_bataljual.Visible = cancel_sw
        mn_bayar.Visible = bayar_sw
        mn_validasi.Visible = valid_sw
    End Sub

    Private Sub addItem()
        If add_sw = True Then
            Console.WriteLine(tabpagename.Name.ToString)
            Me.Cursor = Cursors.AppStarting
            Select Case tabpagename.Name.ToString
                Case "pgbarang"
                    Dim x As New fr_barang_detail
                    x.Show()
                Case "pgsupplier"
                    Dim x As New fr_supplier_detail
                    x.Show()
                Case "pggudang"
                    Dim x As New fr_gudang_detail
                    x.Show()
                Case "pgsales"
                    Dim x As New fr_sales_detail
                    x.Show()
                Case "pgcusto"
                    Dim x As New fr_custo_detail
                    x.Show()
                Case "pgbank"
                    fr_bank_detail.ShowDialog()
                Case "pgbgtangan"
                    fr_giro_detail.ShowDialog()
                Case "pgperkiraan"
                    Dim x As New fr_perkiraan_detail
                    x.Show()
                Case "pgawalneraca"
                    fr_neracaawal_detail.ShowDialog()
                Case "pgpembelian"
                    Dim bd As New fr_beli_detail
                    bd.Show(main)
                    bd.do_load()
                Case "pgreturbeli"
                    Dim rb As New fr_beli_retur_detail
                    rb.Show(main)
                Case "pgpesanjual"
                    Dim rb As New fr_pesan_detail
                    rb.Show(main)
                    rb.doLoad(loggeduser.saleskode)
                Case "pgpenjualan"
                    Dim jd As New fr_jual_detail
                    jd.Show(main)
                Case "pgreturjual"
                    Dim x As New fr_jual_retur_detail
                    x.Show(main)
                Case "pgstok"
                    Dim x As New fr_stok_awal
                    x.ShowDialog(main)
                    'Case "pgmutasigudang"
                    '    fr_stok_mutasi.ShowDialog(main)
                    'Case "pgmutasistok"
                    '    fr_stok_mutasi_barang.ShowDialog(main)
                    'Case "pgstockop"
                    '    fr_stock_op.ShowDialog(main)
                Case "pghutangbayar"
                    'Dim xa As New fr_h_bayar
                    'xa.Show()
                    Dim frhb As New fr_hutang_bayar
                    frhb.Show(main)
                    frhb.do_load()
                Case "pgpiutangbayar"
                    Dim frpb As New fr_piutang_bayar
                    frpb.Show(main)
                Case "pgpiutangbgtolak"
                    'fr_bg_tolak.ShowDialog(main)
                Case "pgkas"
                    fr_kas_detail.ShowDialog(main)
                Case "pgjurnalmemorial"
                    fr_jurnal_mem.ShowDialog(main)
                Case "pggroup"
                    fr_group_detail.ShowDialog(main)
                Case "pguser"
                    fr_user_detail.ShowDialog(main)
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
                        With detail
                            .bt_simpanbarang.Text = "Update"
                            .Text += dgv_list.SelectedRows.Item(0).Cells(1).Value
                            .in_kode.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .Show()
                        End With

                    Case "pgsupplier"
                        Dim detail As New fr_supplier_detail
                        With detail
                            .bt_simpansupplier.Text = "Update"
                            .Text += dgv_list.SelectedRows.Item(0).Cells(1).Value
                            .in_kode.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .Show()
                        End With

                    Case "pggudang"
                        Dim detail As New fr_gudang_detail
                        With detail
                            .bt_simpangudang.Text = "Update"
                            .Text += dgv_list.SelectedRows.Item(0).Cells(1).Value
                            .in_kode.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .Show()
                        End With
                    Case "pgsales"
                        Dim detail As New fr_sales_detail
                        With detail
                            .bt_simpansales.Text = "Update"
                            .Text += dgv_list.SelectedRows.Item(0).Cells(1).Value
                            .in_kode.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .Show()
                        End With
                    Case "pgcusto"
                        Dim detail As New fr_custo_detail
                        With detail
                            .bt_simpancusto.Text = "Update"
                            .Text += dgv_list.SelectedRows.Item(0).Cells(1).Value
                            .in_kode.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .Show()
                        End With
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
                        With detail
                            .bt_simpanbeli.Text = "Update"
                            .Text += dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .in_faktur.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .Show(main)
                            .do_load()
                        End With
                    Case "pgreturbeli"
                        Dim detail As New fr_beli_retur_detail
                        With detail
                            .bt_simpanreturbeli.Text = "Update"
                            .Text += dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .in_no_bukti.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .Show(main)
                        End With
                    Case "pgpesanjual"
                        Dim detail As New fr_pesan_detail
                        With detail
                            .bt_simpanjual.Text = "Update"
                            .Text += "#" & dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .in_faktur.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .Show(main)
                            .doLoad()
                        End With
                    Case "pgpenjualan"
                        Dim detail As New fr_jual_detail
                        With detail
                            .bt_simpanjual.Text = "Update"
                            .Text += dgv_list.SelectedRows.Item(0).Cells(1).Value
                            .in_faktur.Text = dgv_list.SelectedRows.Item(0).Cells(1).Value
                            .Show(main)
                        End With
                    Case "pgreturjual"
                        Dim detail As New fr_jual_retur_detail
                        With detail
                            .bt_simpanreturbeli.Text = "Update"
                            .Text += dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .in_no_bukti.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .Show(main)
                        End With
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
                        With detail
                            .bt_simpanperkiraan.Text = "Update"
                            .Text += dgv_list.SelectedRows.Item(0).Cells("bukti").Value
                            .in_no_bukti.Text = dgv_list.SelectedRows.Item(0).Cells("bukti").Value
                            .Show(main)
                            .do_load()
                        End With
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
                        With detail
                            .bt_simpanperkiraan.Text = "Update"
                            .Text += dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .in_no_bukti.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .Show(main)
                        End With
                    Case "pgpiutangbgcair"
                        Dim detail As New fr_giro
                        With detail
                            .Text = "Detail Giro : " & dgv_list.SelectedRows.Item(0).Cells(0).Value
                            .Show()
                            .do_load("IN", dgv_list.SelectedRows.Item(0).Cells(0).Value)
                        End With
                    Case "pgpiutangbgtolak"
                        'Using detail As New fr_bg_tolak
                        '    With detail
                        '        .bt_simpanperkiraan.Text = "Update"

                        '        .ShowDialog(main)
                        '    End With
                        'End Using
                    Case "pgkas"
                        Using detail As New fr_kas_detail
                            With detail
                                .bt_simpanperkiraan.Text = "Update"
                                .in_no_bukti.Text = dgv_list.SelectedRows.Item(0).Cells(1).Value
                                .ShowDialog(main)
                            End With
                        End Using
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
                        Using detail As New fr_group_detail
                            With detail
                                .bt_simpan_group.Text = "Update"
                                .Text += dgv_list.SelectedRows.Item(0).Cells(1).Value
                                .in_kode.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                                .in_nama_group.Text = dgv_list.SelectedRows.Item(0).Cells(1).Value
                                .in_ket_group.Text = dgv_list.SelectedRows.Item(0).Cells(2).Value
                                .ShowDialog()
                            End With
                        End Using
                    Case "pguser"
                        Using detail As New fr_user_detail
                            With detail
                                .bt_simpanuser.Text = "Update"
                                .Text += dgv_list.SelectedRows.Item(0).Cells(1).Value
                                .in_kode.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                                .ShowDialog(main)
                            End With
                        End Using
                        'Case "pgjenisbarang"
                        '    Using detail As New fr_jenis_barang
                        '        With detail
                        '            .setfor = "jenisbarang"
                        '            .bt_simpan_jenis.Text = "Update"
                        '            .Text += dgv_list.Rows(rowindex).Cells(1).Value
                        '            .in_kode.Text = dgv_list.Rows(rowindex).Cells(0).Value
                        '            .ShowDialog()
                        '        End With
                        '    End Using
                    Case Else
                        MessageBox.Show("Under Construction")
                End Select
                Me.Cursor = Cursors.Default
            Else
                MessageBox.Show("Data tidak ada")
            End If
        End If
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
                                kode = dgv_list.SelectedRows.Item(0).Cells(1).Value
                            Case "pgreturjual"
                                tipe = "returjual"
                                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                            Case Else
                                tipe = Nothing
                                kode = Nothing
                                Me.Cursor = Cursors.Default
                                Exit Sub
                        End Select
                        Using nota As New fr_view_nota
                            With nota
                                .setVar(tipe, kode, "")
                                .ShowDialog()
                            End With
                        End Using
                End Select
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub exportItem()
        If export_sw = True Then
            If dgv_list.RowCount > 0 Then
                MyBase.Cursor = Cursors.AppStarting

                Dim x As String = LCase(tabpagename.Name.ToString)
                Dim q As String = ""
                Dim _colheader As New List(Of String)
                Dim _dt As New DataTable
                Dim _outputdir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\SIMInvent\"
                Dim _filename As String = "dataexport" & Today.ToString("yyyyMMdd")
                Dim _respond As Boolean = False
                Dim _svdialog As New SaveFileDialog

                _svdialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
                _svdialog.FilterIndex = 1
                _svdialog.RestoreDirectory = True
                If _svdialog.ShowDialog = DialogResult.OK Then
                    If _svdialog.FileName <> Nothing Then
                        _outputdir = IO.Path.GetDirectoryName(_svdialog.FileName)
                        _filename = Strings.Replace(_svdialog.FileName, _outputdir, "")
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If

                Select Case x
                    Case "pgbarang"
                        q = "SELECT @cval:=@cval+1 'No.',barang_kode 'Kode Barang', barang_nama 'Nama Barang', barang_supplier 'Kode Supplier', " _
                            & "supplier_nama 'Nama Supplier',jenis_nama 'Jenis Barang', IFNULL(kategori_nama,'') 'Kategori Barang', barang_satuan_kecil 'Satuan Kecil', " _
                            & "barang_satuan_tengah 'Satuan Tengah',barang_satuan_tengah_jumlah 'Vol.Sat.Tengah', barang_satuan_besar 'Satuan Besar', " _
                            & "barang_satuan_besar_jumlah 'Vol.Sat.Besar', barang_harga_beli 'Harga Beli', barang_harga_beli_d1 'Beli D1', " _
                            & "barang_harga_beli_d2 'Beli D2', barang_harga_beli_d3 'Beli D3', barang_harga_beli_klaim 'Beli Klaim', " _
                            & "barang_harga_jual 'Harga Jual', barang_harga_jual_d1 'Jual D1', barang_harga_jual_d2 'Jual D2', barang_harga_jual_d3 'Jual D3', " _
                            & "barang_harga_jual_d4 'Jual D4', barang_harga_jual_d5 'Jual D5', barang_harga_jual_discount 'Jual Disc.Rp', " _
                            & "barang_harga_jual_mt 'Jual MT', barang_harga_jual_horeka 'Jual Horeka', barang_harga_jual_rita 'Jual Retail', " _
                            & "getHPPAVG(barang_kode,CURDATE(),'" & currentperiode.id & "') 'HPP Barang', " _
                            & "(CASE barang_status WHEN 1 THEN 'Aktif' WHEN 0 THEN 'Non-Aktif' ELSE 'Error' END) 'Status Barang' " _
                            & "FROM data_barang_master " _
                            & "LEFT JOIN data_supplier_master ON barang_supplier=supplier_kode " _
                            & "LEFT JOIN data_barang_jenis ON barang_jenis=jenis_kode " _
                            & "LEFT JOIN data_barang_kategori ON barang_kategori=kategori_kode " _
                            & "JOIN(SELECT @cval:=0) para " _
                            & "WHERE barang_status<>9"

                    Case "pgsupplier"
                        q = "SELECT supplier_kode 'Kode Supplier', supplier_nama 'Nama Supplier', supplier_alamat 'Alamat Supplier', " _
                            & "supplier_telpon1 'Nomor Telp.', supplier_telpon2 'Nomor Telp. Alt.', supplier_fax 'Fax', supplier_cp 'Contact Person', " _
                            & "supplier_email 'Alamat email', supplier_npwp 'NPWP', supplier_rek_bank 'No. Rekening 1', supplier_rek_bg 'No.Rekening 2', " _
                            & "supplier_term 'Defaut Term', supplier_keterangan 'Keterangan', " _
                            & "(CASE supplier_status WHEN 1 THEN 'Aktif' WHEN 0 THEN 'Non-Aktif' ELSE 'Error' END) 'Status' " _
                            & "FROM data_supplier_master WHERE supplier_status<>9"

                    Case "pggudang"
                        q = "SELECT gudang_kode 'Kode Gudang', gudang_nama 'Nama Gudang', gudang_alamat 'Alamat', gudang_ket 'Keterangan', " _
                            & "(CASE gudang_status WHEN 1 THEN 'Aktif' WHEN 0 THEN 'Non-Aktif' ELSE 'Error' END) 'Status' " _
                            & "FROM data_barang_gudang WHERE gudang_status<>9"

                    Case "pgsales"
                        q = "SELECT salesman_kode 'Kode Salesman', salesman_nama 'Nama Salesman', salesman_alamat 'Alamat', salesman_tanggal_masuk 'Tanggal Masuk', " _
                            & "(CASE salesman_jenis WHEN 1 THEN 'Sales TO' WHEN 2 THEN 'Sales Kanvas' ELSE '-' END) 'Jenis Sales', " _
                            & "salesman_lahir_tanggal 'Tanggal Lahir', salesman_lahir_kota 'Kota Kelahiran', salesman_hp 'Nomor Telp.', salesman_fax 'Nomor Fax.', " _
                            & "salesman_bank_rekening 'Rekening Bank', salesman_bank_nama 'Nama Bank', salesman_bank_atasnama 'A.N. Rekening', " _
                            & "(CASE salesman_status WHEN 1 THEN 'Aktif' WHEN 0 THEN 'Non-Aktif' ELSE 'Error' END) 'Status' " _
                            & "FROM data_salesman_master WHERE salesman_status<>9"

                    Case "pgcusto"
                        q = "SELECT customer_kode 'Kode Customer', customer_nama 'Nama Customer', customer_area 'Kode Area', jenis_nama 'Jenis Customer', " _
                            & "customer_telpon 'Nomor Telp.', customer_fax 'Nomor Fax.', customer_cp 'Contact Person', " _
                            & "customer_alamat 'Alamat', customer_alamat_blok 'Blok', customer_alamat_nomor 'Nomor', customer_alamat_rt 'RT', " _
                            & "customer_alamat_rw 'RW', customer_alamat_kelurahan 'Kelurahan', customer_kecamatan 'Kecamatan', customer_kabupaten 'Kabupaten', " _
                            & "customer_pasar 'Pasar', customer_provinsi 'Provinsi', customer_kodepos 'Kode Pos', customer_nik 'NIK', customer_npwp 'NPWP', " _
                            & "customer_tanggal_pkp 'Tanggal PKP', customer_pajak_nama 'Nama Pajak', customer_pajak_jabatan 'Jabatan Pajak', " _
                            & "customer_pajak_alamat 'Alamat Pajak', customer_max_piutang 'Plafon Piutang', customer_term 'Default Term.', " _
                            & "(CASE customer_status WHEN 1 THEN 'Aktif' WHEN 0 THEN 'Non-Aktif' ELSE 'Error' END) 'Status' " _
                            & "FROM data_customer_master " _
                            & "LEFT JOIN data_customer_jenis ON jenis_kode=customer_jenis " _
                            & "WHERE customer_status<>9"

                    Case "pgbgtangan"
                        q = "SELECT giro_no 'No. BG', DATE_FORMAT(giro_tglterima,'%d/%m/%Y') 'Tgl Terima', DATE_FORMAT(giro_tglefektif,'%d/%m/%Y') 'Tgl. Efektif', " _
                            & "giro_nilai 'Jumlah', giro_bank 'Bank', giro_ref 'Faktur Pembayaran', " _
                            & "customer_kode 'Kode Customer',customer_nama 'Nama Customer',salesman_kode 'Kode Sales',salesman_nama 'Nama Salesman', " _
                            & "(CASE giro_status_pencairan WHEN 0 THEN 'Aktif' WHEN 1 THEN 'Cair' WHEN 2 THEN 'Tolak' ELSE 'Error' END) 'Status Giro', " _
                            & "IF(giro_status_pencairan=1,DATE_FORMAT(giro_tgl_tolakcair,'%d/%m/%Y'),'-') 'Tanggal Pencairan', " _
                            & "IFNULL(perk_nama_akun,'-') 'Akun Pencairan' " _
                            & "FROM data_giro " _
                            & "LEFT JOIN data_perkiraan ON giro_akun_pencairan=perk_kode " _
                            & "LEFT JOIN data_salesman_master ON salesman_kode=giro_ref3 " _
                            & "LEFT JOIN data_customer_master ON customer_kode=giro_ref2 " _
                            & "WHERE giro_status=1 AND giro_type='IN'"

                    Case "pgperkiraan"
                        q = "SELECT perk_kode as 'Kode Perkiraan',perk_nama_akun 'Nama Perkiraan', perk_gol_nama 'Nama Akun Parent', perk_parent 'Kode Parent', " _
                            & "(CASE perk_d_or_k WHEN 'D' THEN 'Debit' WHEN 'K' THEN 'Kredit' ELSE '-' END) 'Posisi', " _
                            & "(CASE LEFT(perk_kode,1) WHEN 1 THEN 'Aktiva' WHEN 2 THEN 'Pasiva' WHEN 3 THEN 'Pendapatan' WHEN 4 THEN 'Biaya' ELSE '-' END) 'Jenis', " _
                            & "(CASE perk_status WHEN 1 THEN 'Aktif' WHEN 0 THEN 'Non-Aktif' ELSE 'Error' END) 'Status' " _
                            & "FROM data_perkiraan " _
                            & "LEFT JOIN data_perkiraan_gol ON perk_parent=perk_gol_kode " _
                            & "WHERE perk_status<>9"

                    Case "pgpembelian"
                        q = "SELECT faktur_kode 'No.Faktur', DATE_FORMAT(faktur_tanggal_trans,'%Y-%m-%d') 'Tgl.Transaksi', faktur_pajak_no 'No.Pajak', " _
                            & "DATE_FORMAT(faktur_pajak_tanggal,'%Y-%m-%d') 'Tgl.Pajak/Invoice', " _
                            & "supplier_nama 'Supplier', faktur_term 'Term', gudang_nama 'Gudang', trans_barang 'Kode Barang', barang_nama 'Nama Barang', " _
                            & "trans_harga_beli 'Harga Beli', CONCAT(trans_qty,' ',trans_satuan) 'Qty', trans_harga_beli*trans_qty 'Subtotal',trans_disc1 'Disc1', " _
                            & "trans_disc2 'Disc2',trans_disc3 'Disc3',trans_disc_rupiah 'Disc Rp.', trans_jumlah 'Jumlah', " _
                            & "TRUNCATE(IF(faktur_ppn_jenis=1,trans_jumlah*(1-(10/11)),0),0) 'PPn'," _
                            & "(CASE faktur_status WHEN 0 THEN 'Non-Aktif' WHEN 1 THEN 'Aktif' WHEN 2 THEN 'Batal' ELSE 'Error' END) 'Status' " _
                            & "FROM data_pembelian_faktur " _
                            & "LEFT JOIN data_pembelian_trans ON faktur_kode=trans_faktur AND trans_status=1 " _
                            & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                            & "LEFT JOIN data_supplier_master ON faktur_supplier=supplier_kode " _
                            & "LEFT JOIN data_barang_gudang ON faktur_gudang=gudang_kode " _
                            & "WHERE faktur_status<>9 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                            & "ORDER BY faktur_kode, faktur_tanggal_trans,trans_barang"
                        q = String.Format(q, selectperiode.tglawal.ToString("yyyy-MM-dd"), selectperiode.tglakhir.ToString("yyyy-MM-dd"))

                    Case "pgreturbeli"
                        q = "SELECT faktur_kode_bukti 'No.Faktur', DATE_FORMAT(faktur_tanggal_trans,'%Y-%m-%d') 'Tgl.Transaksi', faktur_kode_exfaktur 'No.Ex.Faktur', " _
                            & "faktur_pajak_no 'No.Pajak', DATE_FORMAT(faktur_pajak_tanggal,'%Y-%m-%d') 'Tgl.Pajak/Invoice', supplier_nama 'Nama Supplier', " _
                            & "(CASE faktur_jen_bayar WHEN 1 THEN 'Potong Nota' WHEN 2 THEN 'Tunai' WHEN 3 THEN 'Titip' ELSE 'Error' END) 'Jenis Bayar', " _
                            & "faktur_kode_faktur 'Nota Pembelian', gudang_nama 'Nama Gudang', trans_barang 'Kode Barang', barang_nama 'Nama Barang', " _
                            & "trans_harga_retur 'Harga Retur', CONCAT(trans_qty,' ',trans_satuan) 'Qty', trans_harga_retur*trans_qty 'Subtotal', " _
                            & "trans_diskon 'Potongan/Disk.', @jml:=TRUNCATE(trans_harga_retur*(1-(trans_diskon/100)),0) 'Jumlah', " _
                            & "TRUNCATE(IF(faktur_ppn_jenis=1,@jml*(1-(10/11)),0),0) 'PPn(Incl.)', " _
                            & "(CASE faktur_status WHEN 0 THEN 'Non-Aktif' WHEN 1 THEN 'Aktif' WHEN 2 THEN 'Batal' ELSE 'Error' END) 'Status' " _
                            & "FROM data_pembelian_retur_faktur " _
                            & "LEFT JOIN data_pembelian_retur_trans ON faktur_kode_bukti=trans_faktur AND trans_status=1 " _
                            & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                            & "LEFT JOIN data_supplier_master ON faktur_supplier=supplier_kode " _
                            & "LEFT JOIN data_barang_gudang ON faktur_gudang=gudang_kode " _
                            & "WHERE faktur_status<>9 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                            & "ORDER BY faktur_kode_bukti, faktur_tanggal_trans,trans_barang"
                        q = String.Format(q, selectperiode.tglawal.ToString("yyyy-MM-dd"), selectperiode.tglakhir.ToString("yyyy-MM-dd"))

                    Case "pgpenjualan"
                        q = "SELECT faktur_kode 'No.Faktur',DATE_FORMAT(faktur_tanggal_trans,'%Y-%m-%d') 'Tgl.Transaksi', faktur_pajak_no 'No.Pajak', " _
                            & "DATE_FORMAT(faktur_pajak_tanggal,'%Y-%m-%d') 'Tgl.Pajak/Invoice', customer_nama 'Nama Customer', salesman_nama 'Nama Salesman', " _
                            & "faktur_term 'Term', faktur_surat_jalan 'No.Surat Jalan', gudang_nama 'Nama Gudang', trans_barang 'Kode Barang', barang_nama 'Nama Barang'," _
                            & "trans_harga_jual 'Harga Jual',CONCAT(trans_qty,' ',trans_satuan) 'Qty', @subtot:=trans_qty*trans_harga_jual 'Subtotal', " _
                            & "trans_disc1 'Disc1',trans_disc2 'Disc2',trans_disc3 'Disc3',trans_disc4 'Disc4',trans_disc5 'Disc5',trans_disc_rupiah 'Disc Rp.', " _
                            & "trans_jumlah 'Jumlah',TRUNCATE(IF(faktur_ppn_jenis=1,trans_jumlah*(1-(10/11)),0),0) 'PPn'," _
                            & "(CASE faktur_status WHEN 0 THEN 'Non-Aktif' WHEN 1 THEN 'Aktif' WHEN 2 THEN 'Batal' ELSE 'Error' END) 'Status' " _
                            & "FROM data_penjualan_faktur " _
                            & "LEFT JOIN data_penjualan_trans ON faktur_kode=trans_faktur AND trans_status=1 " _
                            & "LEFT JOIN data_customer_master ON faktur_customer=customer_kode " _
                            & "LEFT JOIN data_salesman_master ON faktur_sales=salesman_kode " _
                            & "LEFT JOIN data_barang_master ON trans_barang=barang_kode " _
                            & "LEFT JOIN data_barang_gudang ON gudang_kode=faktur_gudang " _
                            & "WHERE faktur_status<>9 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                            & "ORDER BY faktur_kode, faktur_tanggal_trans,trans_barang"
                        q = String.Format(q, selectperiode.tglawal.ToString("yyyy-MM-dd"), selectperiode.tglakhir.ToString("yyyy-MM-dd"))

                    Case "pgreturjual"
                        q = "SELECT faktur_kode_bukti 'No.Faktur', DATE_FORMAT(faktur_tanggal_trans,'%Y-%m-%d') 'Tgl.Transaksi', faktur_kode_exfaktur 'No.Ex.Faktur', " _
                            & "faktur_pajak_no 'No.Pajak', DATE_FORMAT(faktur_pajak_tanggal,'%Y-%m-%d') 'Tgl.Pajak/Invoice', customer_nama 'Nama Customer', " _
                            & "salesman_nama 'Nama Salesman', (CASE faktur_jen_bayar WHEN 1 THEN 'Potong Nota' WHEN 2 THEN 'Tunai' WHEN 3 THEN 'Titip' ELSE 'Error' END) 'Jenis Bayar', " _
                            & "faktur_kode_faktur 'Nota Penjualan', gudang_nama 'Nama Gudang', trans_barang 'Kode Barang', barang_nama 'Nama Barang', " _
                            & "trans_harga_retur 'Harga Retur', CONCAT(trans_qty,' ',trans_satuan) 'Qty', trans_harga_retur*trans_qty 'Subtotal', " _
                            & "trans_diskon 'Potongan/Disk.', @jml:=TRUNCATE(trans_harga_retur*(1-(trans_diskon/100)),0) 'Jumlah', " _
                            & "TRUNCATE(IF(faktur_ppn_jenis=1,@jml*(1-(10/11)),0),0) 'PPn(Incl.)', " _
                            & "(CASE faktur_status WHEN 0 THEN 'Non-Aktif' WHEN 1 THEN 'Aktif' WHEN 2 THEN 'Batal' ELSE 'Error' END) 'Status' " _
                            & "FROM data_penjualan_retur_faktur " _
                            & "LEFT JOIN data_penjualan_retur_trans ON trans_faktur=faktur_kode_bukti AND trans_status=1 " _
                            & "LEFT JOIN data_customer_master ON faktur_custo=customer_kode " _
                            & "LEFT JOIN data_salesman_master ON faktur_sales=salesman_kode " _
                            & "LEFT JOIN data_barang_master ON trans_barang=barang_kode " _
                            & "LEFT JOIN data_barang_gudang ON gudang_kode=faktur_gudang " _
                            & "WHERE faktur_status<>9 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                            & "ORDER BY faktur_kode_bukti, faktur_tanggal_trans,trans_barang"
                        q = String.Format(q, selectperiode.tglawal.ToString("yyyy-MM-dd"), selectperiode.tglakhir.ToString("yyyy-MM-dd"))

                    Case Else
                        Exit Sub
                End Select

                _dt = getDataTablefromDB(q)
                For Each col As DataColumn In _dt.Columns
                    _colheader.Add(col.ColumnName)
                Next

                If exportXlsx(_colheader, _dt, _outputdir, _filename) = True Then
                    MessageBox.Show("Export sukses")
                    If System.IO.File.Exists(_svdialog.FileName) = True Then
                        Process.Start(_svdialog.FileName)
                    End If
                Else
                    MessageBox.Show("Export gagal")
                End If

                MyBase.Cursor = Cursors.Default
            End If
        End If
    End Sub

    'UNFINISHED complicated DEACT PROCEDURE
    Private Sub deactItem()
        If del_sw = True Then
            Dim tabpage As String = tabpagename.Name.ToString
            Dim _allowdel As Boolean = False
            Dim _valstate As String = ""
            Select Case tabpage
                Case "pgbarang", "pgsupplier", "pgsales", "pgcusto", "pggudang"
                    _allowdel = loggeduser.validasi_master
                    _valstate = "master"
                Case "pgpenjualan", "pgreturjual", "pgpembelian", "pgreturbeli"
                    _allowdel = loggeduser.validasi_trans
                    _valstate = "trans"
                Case "pgkas"
                    _allowdel = loggeduser.validasi_akun
                    _valstate = "akun"
            End Select

            If _allowdel = False Then
                MessageBox.Show("Anda tidak dapat menghapus data")
                Exit Sub
                'Else
                '    Dim _procdel As Boolean = False
                '    Using validfr As New fr_stockopconfirm_dialog

                '    End Using

                '    If _procdel = False Then
                '        MessageBox.Show("Penghapusan data dibatalkan")
                '        Exit Sub
                '    End If
            End If

            With dgv_list
                If .Rows.Count > 0 And .SelectedRows.Count > 0 Then
                    Dim q As String = ""
                    Dim qcheck As String = ""
                    Dim ckdata As Boolean = True
                    Dim msg As String = "Hapus"
                    Dim kode As String = ""
                    Dim queryCk As Boolean = False
                    Dim _state As String = "1"

                    op_con()
                    consoleWriteLine(tabpagename.Name.ToString)
                    Me.Cursor = Cursors.AppStarting
                    Select Case tabpagename.Name.ToString
                        Case "pgbarang"
                            kode = .SelectedRows.Item(0).Cells(0).Value
                            ckdata = checkdata("data_stok_awal", "'" & kode & "' AND stock_status=1", "stock_barang")
                            qcheck = "SELECT barang_status FROM data_barang_master WHERE barang_kode='" & kode & "'"
                            readcommd(qcheck)
                            If rd.HasRows Then
                                _state = rd.Item(0)
                            End If
                            rd.Close()

                            q = "UPDATE data_barang_master SET barang_status='" & IIf(_state = 1, 0, 1) & "', barang_upd_date=NOW(),  " _
                                & "barang_upd_alias='" & loggeduser.user_id & "' WHERE barang_kode='" & kode & "'"

                        Case "pgsupplier"
                            kode = .SelectedRows.Item(0).Cells(0).Value
                            ckdata = False
                            qcheck = "SELECT supplier_status FROM data_supplier_master WHERE supplier_kode='" & kode & "'"
                            readcommd(qcheck)
                            If rd.HasRows Then
                                _state = rd.Item(0)
                            End If
                            rd.Close()

                            q = "UPDATE data_supplier_master SET supplier_status='{0}', supplier_upd_date=NOW(), supplier_upd_alias='{1}' WHERE supplier_kode='{2}'"
                            q = String.Format(q, IIf(_state = 1, 0, 1), loggeduser.user_id, kode)

                        Case "pggudang"
                            kode = .SelectedRows.Item(0).Cells(0).Value
                            ckdata = False
                            qcheck = "SELECT gudang_status FROM data_barang_gudang WHERE gudang_kode='" & kode & "'"
                            readcommd(qcheck)
                            If rd.HasRows Then
                                _state = rd.Item(0)
                            End If
                            rd.Close()

                            q = "UPDATE data_barang_gudang SET gudang_status='" & IIf(_state = 1, 0, 1) & "', gudang_upd_date=NOW(), " _
                                & "gudang_upd_alias='" & loggeduser.user_id & "' WHERE gudang_kode='" & kode & "'"

                        Case "pgcusto"
                            kode = .SelectedRows.Item(0).Cells(0).Value
                            ckdata = False
                            qcheck = "SELECT customer_status FROM data_customer_master WHERE customer_kode='" & kode & "'"
                            readcommd(qcheck)
                            If rd.HasRows Then
                                _state = rd.Item(0)
                            End If
                            rd.Close()

                            q = "UPDATE data_customer_master SET customer_status=0, customer_upd_date=NOW(), customer_upd_alias='" & loggeduser.user_id & "' " _
                                & "WHERE customer_kode='" & kode & "'"

                        Case "pgsales"
                            kode = .SelectedRows.Item(0).Cells(0).Value
                            ckdata = False
                            qcheck = "SELECT salesman_status FROM data_salesman_master WHERE salesman_kode='" & kode & "'"
                            readcommd(qcheck)
                            If rd.HasRows Then
                                _state = rd.Item(0)
                            End If
                            rd.Close()

                            q = "UPDATE data_salesman_master SET salesman_status='{0}', salesman_upd_date=NOW(), salesman_upd_alias='{1}' WHERE salesman_kode='{2}'"
                            q = String.Format(q, IIf(_state = 1, 0, 1), loggeduser.user_id, kode)

                        Case "pgstok"
                            kode = .SelectedRows.Item(0).Cells(0).Value
                    End Select

                    If ckdata = False Then
                        op_con()
                        queryCk = commnd(q)
                        If queryCk = True Then
                            MessageBox.Show("Perubahan tersimpan", "De/Aktivasi Data")
                            performRefresh()
                        Else
                            MessageBox.Show("Perubahan tidak dapat tersimpan", "De/Aktivasi Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Status data tidak dapat diubah", "De/Aktivasi Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("Data tidak ada")
                End If

                Me.Cursor = Cursors.Default
            End With
        End If
    End Sub

    Private Sub cancelItem()
        Dim _tbpg As String = tabpagename.Name.ToString
        Dim ckdata As Boolean = False
        Dim _dataState As Boolean = True
        Dim q As String = ""
        Dim kode As String = ""
        Dim queryCk As Boolean = False

        op_con()
        Select Case _tbpg
            Case "pgpembelian"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                ckdata = checkdata("data_hutang_trans", "'" & kode & "' AND h_trans_status<>9 AND h_trans_jenis NOT IN ('awal','beli')", "h_trans_kode_hutang")
                q = "UPDATE data_pembelian_faktur SET faktur_status=2, faktur_upd_date=NOW(), faktur_upd_alias='{1}' WHERE faktur_kode='{0}'; " _
                    & "CALL transPembelianFin('{0}','{1}');"
                q = String.Format(q, kode, loggeduser.user_id)

                readcommd("SELECT faktur_status FROM data_pembelian_faktur WHERE faktur_kode='" & kode & "'")
                If rd.HasRows Then
                    _dataState = IIf(rd.Item(0) = 0 Or rd.Item(0) = 1, True, False)
                End If
                rd.Close()

            Case "pgreturbeli"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                'ckdata = checkdata("data_hutang_trans", "'" & kode & "' AND h_trans_status AND h_trans_jenis='retur'", "h_trans_kode_hutang")
                q = "UPDATE data_pembelian_retur_faktur SET faktur_status=2, faktur_upd_date=NOW(), faktur_upd_alias='{1}' WHERE faktur_kode_bukti='{0}'; " _
                    & "CALL transReturBeli('{0}','{1}');"
                q = String.Format(q, kode, loggeduser.user_id)

                readcommd("SELECT faktur_status FROM data_pembelian_retur_faktur WHERE faktur_kode_bukti='" & kode & "'")
                If rd.HasRows Then
                    _dataState = IIf(rd.Item(0) = 0 Or rd.Item(0) = 1, True, False)
                End If
                rd.Close()

            Case "pgpenjualan"
                kode = dgv_list.SelectedRows.Item(0).Cells(1).Value
                ckdata = checkdata("data_piutang_trans", "'" & kode & "' AND p_trans_status<>9 AND p_trans_jenis NOT IN ('awal','jual')", "p_trans_kode_piutang")
                q = "UPDATE data_penjualan_faktur SET faktur_status=2, faktur_upd_date=NOW(),faktur_upd_alias='{1}' WHERE faktur_kode='{0}'"
                q = String.Format(q, kode, loggeduser.user_id)

                readcommd("SELECT faktur_status FROM data_penjualan_faktur WHERE faktur_kode='" & kode & "'")
                If rd.HasRows Then
                    _dataState = IIf(rd.Item(0) = 0 Or rd.Item(0) = 1, True, False)
                End If
                rd.Close()

            Case "pgreturjual"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value

                q = "UPDATE data_penjualan_retur_faktur SET faktur_status=2, faktur_upd_date=NOW(), faktur_upd_alias='{1}' WHERE faktur_kode_bukti='{0}'; " _
                    & "CALL transReturJualFin('{0}','{1}');"
                q = String.Format(q, kode, loggeduser.user_id)

                readcommd("SELECT faktur_status FROM data_penjualan_retur_faktur WHERE faktur_kode_bukti='" & kode & "'")
                If rd.HasRows Then
                    _dataState = IIf(rd.Item(0) = 0 Or rd.Item(0) = 1, True, False)
                End If
                rd.Close()

            Case "pghutangbayar"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                readcommd("SELECT giro_status_pencairan FROM data_giro WHERE giro_ref='" & kode & "' AND giro_status=1")
                If rd.HasRows Then
                    ckdata = IIf(rd.Item(0) = 0, False, True)
                End If
                rd.Close()

                q = "UPDATE data_hutang_bayar SET h_bayar_status=2, h_bayar_upd_alias='{1}', h_bayar_upd_date=NOW() WHERE h_bayar_bukti='{0}'; " _
                    & "CALL transBayarHutangFin('{0}','{1}');"
                q = String.Format(q, kode, loggeduser.user_id)

                readcommd("SELECT h_bayar_status FROM data_hutang_bayar WHERE h_bayar_bukti='" & kode & "'")
                If rd.HasRows Then
                    _dataState = IIf(rd.Item(0) = 0 Or rd.Item(0) = 1, True, False)
                End If
                rd.Close()

            Case "pgpiutangbayar"
                kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
                readcommd("SELECT giro_status_pencairan FROM data_giro WHERE giro_ref='" & kode & "' AND giro_status=1")
                If rd.HasRows Then
                    ckdata = IIf(rd.Item(0) = 0, False, True)
                End If
                rd.Close()

                q = "UPDATE data_piutang_bayar SET p_bayar_status=2, p_bayar_upd_date=NOW(), p_bayar_upd_alias='{1}' WHERE p_bayar_bukti='{0}'; " _
                    & "CALL transBayarPiutangFin('{0}','{1}');"
                q = String.Format(q, kode, loggeduser.user_id)

                readcommd("SELECT p_bayar_status FROM data_piutang_bayar WHERE p_bayar_bukti='" & kode & "'")
                If rd.HasRows Then
                    _dataState = IIf(rd.Item(0) = 0 Or rd.Item(0) = 1, True, False)
                End If
                rd.Close()

            Case Else
                Exit Sub
        End Select

        If _dataState = True Then
            If MessageBox.Show("Batalkan transaksi?", "Pembatalan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If ckdata = False Then
                    queryCk = commnd(q)
                    If queryCk = True Then
                        MessageBox.Show("Transaksi dibatalkan.")
                        performRefresh()
                    Else
                        MessageBox.Show("Error. Pembatalan transaksi gagal")
                    End If
                Else
                    MessageBox.Show("Transaksi tidak dapat dibatalkan.")
                End If
            End If
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
            consoleWriteLine(ex.Message)
        End Try
    End Sub

    Private Sub dgv_list_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_list.KeyDown
        If e.KeyCode = Keys.Enter Then
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

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click
        deactItem()
    End Sub

    Private Sub mn_print_Click(sender As Object, e As EventArgs) Handles mn_print.Click
        printItem()
    End Sub

    Private Sub mn_exportExcel_Click(sender As Object, e As EventArgs) Handles mn_exportExcel.Click
        exportItem()
    End Sub

    Private Sub mn_bataljual_Click(sender As Object, e As EventArgs) Handles mn_bataljual.Click
        If cancel_sw = True And dgv_list.Rows.Count > 0 Then
            cancelItem()
        ElseIf dgv_list.Rows.Count = 0 Then
            MessageBox.Show("Data tidak ada")
        End If
    End Sub

    Private Sub mn_validasi_Click(sender As Object, e As EventArgs) Handles mn_validasi.Click
        If valid_sw = True Then
            Select Case tabpagename.Name.ToString
                Case "pgpesanjual"
                    Dim detail As New fr_pesan_detail
                    With detail
                        .bt_simpanjual.Text = "Update"
                        .lbl_title.Text = "Form Validasi Order Pembelian"
                        .Text += "#" & dgv_list.SelectedRows.Item(0).Cells(0).Value
                        .in_faktur.Text = dgv_list.SelectedRows.Item(0).Cells(0).Value
                        .Show(main)
                        .doLoad(, "valid")
                    End With
                Case "pgpiutangbayar"

                Case Else
                    Exit Sub
            End Select

        End If
    End Sub
End Class
