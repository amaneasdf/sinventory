Public Class fr_list
    Public tabpagename As TabPage
    Private rowindex As Integer = 0
    Public edit_sw As Boolean = True
    Public add_sw As Boolean = True
    Public del_sw As Boolean = True
    Public export_sw As Boolean = True
    Public print_sw As Boolean = False
    Public search_sw As Boolean = True
    Public cancel_sw As Boolean = False
    Public bayar_sw As Boolean = False

    Public Sub setpage(page As TabPage)
        tabpagename = page
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
        Console.WriteLine(tabpagename.Name.ToString)
        Me.Cursor = Cursors.AppStarting
        Select Case tabpagename.Name.ToString
            Case "pgbarang"
                populateDGVUserCon("barang", "", frmbarang.dgv_list)
            Case "pgsupplier"
                populateDGVUserCon("supplier", "", frmsupplier.dgv_list)
            Case "pggudang"
                populateDGVUserCon("gudang", "", frmgudang.dgv_list)
            Case "pgsales"
                populateDGVUserCon("sales", "", frmsales.dgv_list)
            Case "pgcusto"
                populateDGVUserCon("custo", "", frmcusto.dgv_list)
            Case "pgbgtangan"
                populateDGVUserCon("giro", "", frmbgditangan.dgv_list)
            Case "pgperkiraan"
                populateDGVUserCon("perkiraan", "", frmperkiraan.dgv_list)
            Case "pgawalneraca"
                populateDGVUserCon("neracaawal", "", frmawalneraca.dgv_list)
            Case "pgpembelian"
                populateDGVUserCon("beli", "", frmpembelian.dgv_list)
            Case "pgreturbeli"
                populateDGVUserCon("returbeli", "", frmreturbeli.dgv_list)
            Case "pgpenjualan"
                populateDGVUserCon("jual", "", frmpenjualan.dgv_list)
            Case "pgreturjual"
                populateDGVUserCon("returjual", "", frmreturjual.dgv_list)
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
                populateDGVUserCon("hutangbayar", "", frmhutangbayar.dgv_list)
            Case "pghutangbgo"
                populateDGVUserCon("hutangbgo", "", frmhutangbgo.dgv_list)
            Case "pgpiutangawal"
                populateDGVUserCon("piutangawal", "", frmpiutangawal.dgv_list)
            Case "pgpiutangbayar"
                populateDGVUserCon("piutangbayar", "", frmpiutangbayar.dgv_list)
            Case "pgpiutangbgcair"
                populateDGVUserCon("piutangbgcair", "", frmpiutangbgcair.dgv_list)
            Case "pgpiutangbgtolak"
                populateDGVUserCon("piutangbgtolak", "", frmpiutangbgTolak.dgv_list)
            Case "pgkas"
                populateDGVUserCon("kas", "", frmkas.dgv_list)
            Case "pgjurnalumum"
                populateDGVUserCon("jurnalumum", "", frmjurnalumum.dgv_list)
                lbl_judul.Text = "List Jurnal Umum Periode " & selectedperiode.ToString("MMM yyyy")
            Case "pgjurnalmemorial"
                populateDGVUserCon("jurnalmemorial", "", frmjurnalmemorial.dgv_list)
                'Case "pgjenisbarang"
                '    populateDGVUserCon("jenisbarang", "", frmjenisbarang.dgv_list)
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
                Case "pgpenjualan"
                    Dim jd As New fr_jual_detail
                    jd.Show(main)
                Case "pgreturjual"
                    Dim x As New fr_jual_retur_detail
                    x.Show(main)
                Case "pgstok"
                    Dim x As fr_stok_awal
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
            If dgv_list.RowCount > 0 Then
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
                            .Text += dgv_list.Rows(rowindex).Cells(1).Value
                            .in_kode.Text = dgv_list.Rows(rowindex).Cells(0).Value
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
                                .Text += dgv_list.Rows(rowindex).Cells(4).Value
                                .in_kode.Text = dgv_list.Rows(rowindex).Cells(0).Value
                                .ShowDialog()
                            End With
                        End Using
                    Case "pgpembelian"
                        Dim detail As New fr_beli_detail
                        With detail
                            .bt_simpanbeli.Text = "Update"
                            .Text += dgv_list.Rows(rowindex).Cells(0).Value
                            .in_faktur.Text = dgv_list.Rows(rowindex).Cells(0).Value
                            .Show(main)
                            .do_load()
                        End With
                    Case "pgreturbeli"
                        Dim detail As New fr_beli_retur_detail
                        With detail
                            .bt_simpanreturbeli.Text = "Update"
                            .Text += dgv_list.Rows(rowindex).Cells(0).Value
                            .in_no_bukti.Text = dgv_list.Rows(rowindex).Cells(0).Value
                            .Show(main)
                        End With
                    Case "pgpenjualan"
                        Dim detail As New fr_jual_detail
                        With detail
                            .bt_simpanjual.Text = "Update"
                            .Text += dgv_list.Rows(rowindex).Cells(1).Value
                            .in_faktur.Text = dgv_list.Rows(rowindex).Cells(1).Value
                            .Show(main)
                        End With
                    Case "pgreturjual"
                        Dim detail As New fr_jual_retur_detail
                        With detail
                            .bt_simpanreturbeli.Text = "Update"
                            .Text += dgv_list.Rows(rowindex).Cells(0).Value
                            .in_no_bukti.Text = dgv_list.Rows(rowindex).Cells(0).Value
                            .Show(main)
                        End With
                    Case "pghutangawal"
                        Using detail As New fr_hutang_awal
                            With detail
                                .bt_batalreturbeli.Text = "OK"
                                .in_faktur.Text = dgv_list.Rows(rowindex).Cells(0).Value
                                .ShowDialog(main)
                            End With
                        End Using
                    Case "pghutangbayar"
                        Dim detail As New fr_hutang_bayar
                        With detail
                            .bt_simpanperkiraan.Text = "Update"
                            .Text += dgv_list.Rows(rowindex).Cells("bukti").Value
                            .in_no_bukti.Text = dgv_list.Rows(rowindex).Cells("bukti").Value
                            .Show(main)
                            .do_load()
                        End With
                    Case "pghutangbgo"
                        Dim detail As New fr_giro
                        With detail
                            .Text = "Detail Giro : " & dgv_list.Rows(rowindex).Cells(0).Value
                            .Show()
                            .do_load("OUT", dgv_list.Rows(rowindex).Cells(0).Value)
                        End With
                    Case "pgpiutangawal"
                        Using detail As New fr_piutang_awal
                            With detail
                                .bt_batalreturbeli.Text = "OK"
                                .in_faktur.Text = dgv_list.Rows(rowindex).Cells("faktur").Value
                                .ShowDialog(main)
                            End With
                        End Using
                    Case "pgpiutangbayar"
                        Dim detail As New fr_piutang_bayar
                        With detail
                            .bt_simpanperkiraan.Text = "Update"
                            .Text += dgv_list.Rows(rowindex).Cells(0).Value
                            .in_no_bukti.Text = dgv_list.Rows(rowindex).Cells(0).Value
                            .Show(main)
                        End With
                    Case "pgpiutangbgcair"
                        Dim detail As New fr_giro
                        With detail
                            .Text = "Detail Giro : " & dgv_list.Rows(rowindex).Cells(0).Value
                            .Show()
                            .do_load("IN", dgv_list.Rows(rowindex).Cells(0).Value)
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
                                .in_no_bukti.Text = dgv_list.Rows(rowindex).Cells(1).Value
                                .ShowDialog(main)
                            End With
                        End Using
                    Case "pgjurnalumum"
                        Using detail As New fr_jurnal_u_det
                            With detail

                                .ShowDialog(main)
                            End With
                        End Using
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
                                .Text += dgv_list.Rows(rowindex).Cells(1).Value
                                .in_kode.Text = dgv_list.Rows(rowindex).Cells(0).Value
                                .in_nama_group.Text = dgv_list.Rows(rowindex).Cells(1).Value
                                .in_ket_group.Text = dgv_list.Rows(rowindex).Cells(2).Value
                                .ShowDialog()
                            End With
                        End Using
                    Case "pguser"
                        Using detail As New fr_user_detail
                            With detail
                                .bt_simpanuser.Text = "Update"
                                .Text += dgv_list.Rows(rowindex).Cells(1).Value
                                .in_kode.Text = dgv_list.Rows(rowindex).Cells(0).Value
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
                Me.Cursor = Cursors.AppStarting
                Console.WriteLine(tabpagename.Name.ToString)

                Dim x As String = LCase(tabpagename.Name.ToString)
                Select Case x
                    Case "pgbarang"

                End Select
            End If
        End If
    End Sub

    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            rowindex = 0
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
        'menu bar
        mn_add.Visible = add_sw
        mn_edit.Visible = edit_sw
        mn_del.Visible = del_sw
        mn_export.Visible = False
        mn_print.Visible = print_sw
        mn_bataljual.Visible = cancel_sw
        mn_bayar.Visible = bayar_sw
    End Sub

    '---------------- CLOSE
    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        main.tabcontrol.TabPages.Remove(tabpagename)
        rowindex = 0
    End Sub

    '---------------- DGV ITEM LIST
    Private Sub dgv_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellClick
        rowindex = e.RowIndex
    End Sub

    Private Sub dgv_list_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_list.ColumnHeaderMouseClick
        dgv_list.ClearSelection()
        rowindex = 0
    End Sub

    Private Sub dgv_list_ColumnHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_list.ColumnHeaderMouseDoubleClick
        dgv_list.ClearSelection()
        rowindex = 0
    End Sub

    Private Sub dgv_list_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                rowindex = e.RowIndex
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

    Private Sub mn_print_Click(sender As Object, e As EventArgs) Handles mn_print.Click
        printItem()
    End Sub

    Private Sub mn_exportExcel_Click(sender As Object, e As EventArgs) Handles mn_exportExcel.Click
        exportItem()
    End Sub

    Private Sub mn_bataljual_Click(sender As Object, e As EventArgs) Handles mn_bataljual.Click
        'UPDATE STATUS FAKTUR TO '2'
        'CEK TRANSAKSI->sudah dibayar/diretur
        'IF YES -> stop
        'IF NO -> UPDATE
        If cancel_sw = True Then
            With dgv_list.SelectedRows
                Dim chkdt As Boolean = False
                Dim chkdt2 As Boolean = False
                Dim kodefaktur As String = .Item(0).Cells(1).Value
                Dim custo_n As String = .Item(0).Cells(5).Value
                Dim queryArr As New List(Of String)
                Dim querychk As Boolean = False

                op_con()
                chkdt = checkdata("data_piutang_bayar_trans", "'" & kodefaktur & "' AND p_trans_status<>9", "p_trans_kode_piutang")
                chkdt2 = checkdata("data_piutang_retur", "'" & kodefaktur & "' AND p_retur_status<>9", "p_retur_faktur")

                Dim q As String = "UPDATE data_penjualan_faktur SET faktur_status=2 WHERE faktur_kode='{0}'"
                If .Count > 0 And (chkdt = False And chkdt2 = False) Then
                    Dim msg As String = "Batalkan penjualan {0} untuk customer {1}?"
                    If MessageBox.Show(String.Format(msg, kodefaktur, custo_n), "Batal Jual/Kirim", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        op_con()
                        queryArr.Add(String.Format(q, kodefaktur))

                        q = "UPDATE data_piutang_awal SET piutang_status=9, piutang_upd_date=NOW(),piutang_upd_alias='{1}' WHERE piutang_faktur='{0}'"
                        queryArr.Add(String.Format(q, kodefaktur, loggeduser.user_id))

                        q = "UPDATE data_jurnal_line SET line_status='9',line_reg_date=NOW(),line_reg_alias='{1}' WHERE line_kode='{0}'"
                        queryArr.Add(String.Format(q, kodefaktur, loggeduser.user_id))

                        q = "UPDATE data_stok_kartustock SET trans_status='9',trans_upd_date=NOW(),trans_upd_alias='{1}' WHERE trans_faktur='{0}' " _
                            & "AND trans_jenis='po'"
                        queryArr.Add(String.Format(q, kodefaktur, loggeduser.user_id))

                        querychk = startTrans(queryArr)
                        If querychk = True Then
                            .Item(0).Cells(2).Value = "BATAL"
                        Else
                            MessageBox.Show("ERROR", "Batal Jual/Kirim", MessageBoxButtons.OK)
                        End If
                    End If
                ElseIf .Count > 0 And (chkdt = True And chkdt2 = True) Then
                    Dim msg As String = "Penjualan {0} untuk customer {1} sudah pernah dilakukan transaksi pembayaran/retur penjualan"
                    MessageBox.Show(String.Format(msg, kodefaktur, custo_n), "Batal Jual/Kirim", MessageBoxButtons.OK)
                End If

            End With
        End If
    End Sub
End Class
