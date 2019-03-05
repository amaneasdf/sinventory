Public Class fr_list_temp
    Public tabpagename As TabPage
    Private rowindex As Integer = 0

    Public Sub setpage(page As TabPage)
        tabpagename = page
        Console.WriteLine("pg" & page.Name.ToString)
        Console.WriteLine("pgset" & tabpagename.Name.ToString)
    End Sub

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

    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_close.Click
        main.tabcontrol.TabPages.Remove(tabpagename)
        rowindex = 0
    End Sub

    Private Sub bt_tambah_Click(sender As Object, e As EventArgs) Handles bt_tambah.Click
        Console.WriteLine(tabpagename.Name.ToString)
        Me.Cursor = Cursors.AppStarting
        Select Case tabpagename.Name.ToString
            Case "pgbarang"
                fr_barang_detail.ShowDialog()
            Case "pgsupplier"
                fr_supplier_detail.ShowDialog()
            Case "pggudang"
                fr_gudang_detail.ShowDialog()
            Case "pgsales"
                fr_sales_detail.ShowDialog()
            Case "pgcusto"
                fr_custo_detail.ShowDialog()
            Case "pgbank"
                fr_bank_detail.ShowDialog()
            Case "pgbgtangan"
                fr_giro_detail.ShowDialog()
            Case "pgperkiraan"
                fr_perkiraan_detail.ShowDialog(main)
            Case "pgawalneraca"
                fr_neracaawal_detail.ShowDialog()
            Case "pgpembelian"
                fr_beli_detail.Show(main)
            Case "pgreturbeli"
                fr_beli_retur_detail.Show(main)
            Case "pgpenjualan"
                fr_jual_detail.Show(main)
            Case "pgreturjual"
                fr_jual_retur_detail.Show(main)
            Case "pgstok"
                fr_stok_awal.ShowDialog(main)
            Case "pgmutasigudang"
                fr_stok_mutasi.ShowDialog(main)
            Case "pgmutasistok"
                fr_stok_mutasi_barang.ShowDialog(main)
            Case "pgstockop"
                fr_stock_op.ShowDialog(main)
            Case "pghutangbayar"
                'Dim xa As New fr_h_bayar
                'xa.Show()
                fr_hutang_bayar.ShowDialog(main)
            Case "pgpiutangbayar"
                fr_piutang_bayar.ShowDialog(main)
            Case "pgpiutangbgtolak"
                fr_bg_tolak.ShowDialog(main)
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
    End Sub

    Private Sub bt_edit_Click(sender As Object, e As EventArgs) Handles bt_edit.Click
        If dgv_list.RowCount > 0 Then
            Me.Cursor = Cursors.AppStarting
            Console.WriteLine(tabpagename.Name.ToString)
            Select Case tabpagename.Name.ToString
                Case "pgbarang"
                    Using detail As New fr_barang_detail
                        With detail
                            .bt_simpancusto.Text = "Update"
                            .in_kode.Text = dgv_list.Rows(rowindex).Cells(0).Value
                            .ShowDialog()
                        End With
                    End Using
                Case "pgsupplier"
                    Using detail As New fr_supplier_detail
                        With detail
                            .bt_simpansupplier.Text = "Update"
                            .Text += dgv_list.Rows(rowindex).Cells(1).Value
                            .in_kode.Text = dgv_list.Rows(rowindex).Cells(0).Value
                            .ShowDialog()
                        End With
                    End Using
                Case "pggudang"
                    Using detail As New fr_gudang_detail
                        With detail
                            .bt_simpangudang.Text = "Update"
                            .Text += dgv_list.Rows(rowindex).Cells(1).Value
                            .in_kode.Text = dgv_list.Rows(rowindex).Cells(0).Value
                            .ShowDialog()
                        End With
                    End Using
                Case "pgsales"
                    Using detail As New fr_sales_detail
                        With detail
                            .bt_simpansales.Text = "Update"
                            .Text += dgv_list.Rows(rowindex).Cells(1).Value
                            .in_kode.Text = dgv_list.Rows(rowindex).Cells(0).Value
                            .ShowDialog()
                        End With
                    End Using
                Case "pgcusto"
                    Using detail As New fr_custo_detail
                        With detail
                            .bt_simpancusto.Text = "Update"
                            .Text += dgv_list.Rows(rowindex).Cells(1).Value
                            .in_kode.Text = dgv_list.Rows(rowindex).Cells(0).Value
                            .ShowDialog()
                        End With
                    End Using
                Case "pgbgtangan"
                    Using detail As New fr_giro_detail
                        With detail
                            .bt_simpangiro.Text = "Update"
                            .Text += dgv_list.Rows(rowindex).Cells(1).Value
                            .in_kode.Text = dgv_list.Rows(rowindex).Cells(0).Value
                            .ShowDialog()
                        End With
                    End Using
                Case "pgperkiraan"
                    Using detail As New fr_perkiraan_detail
                        With detail
                            .bt_simpanperkiraan.Text = "Update"
                            .Text += dgv_list.Rows(rowindex).Cells(2).Value
                            .in_kode.Text = dgv_list.Rows(rowindex).Cells(0).Value
                            .ShowDialog()
                        End With
                    End Using
                Case "pgawalneraca"
                    Using detail As New fr_neracaawal_detail
                        With detail
                            .bt_simpanmigrasi.Text = "Update"
                            .Text += dgv_list.Rows(rowindex).Cells(2).Value
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
                    End With
                Case "pgreturbeli"
                    Dim detail As New fr_beli_retur_detail
                    With detail
                        .bt_simpanreturbeli.Visible = False
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
                        .bt_simpanreturbeli.Visible = False
                        .Text += dgv_list.Rows(rowindex).Cells(0).Value
                        .in_no_bukti.Text = dgv_list.Rows(rowindex).Cells(0).Value
                        .Show(main)
                    End With
                Case "pgmutasigudang"
                    Dim detail As New fr_stok_mutasi
                    With detail
                        .bt_simpanreturbeli.Text = "Update"
                        .Text += dgv_list.Rows(rowindex).Cells(0).Value
                        .in_kode.Text = dgv_list.Rows(rowindex).Cells(0).Value
                        .Show(main)
                    End With
                Case "pgmutasistok"
                    Dim detail As New fr_stok_mutasi_barang
                    With detail
                        .bt_simpanreturbeli.Text = "Update"
                        .Text += dgv_list.Rows(rowindex).Cells(0).Value
                        .in_kode.Text = dgv_list.Rows(rowindex).Cells(0).Value
                        .Show(main)
                    End With
                Case "pgstockop"
                    Dim detail As New fr_stock_op
                    With detail
                        .bt_simpanreturbeli.Text = "Update"
                        .in_kode.Text = dgv_list.Rows(rowindex).Cells(0).Value
                        .Show(main)
                    End With
                Case "pghutangawal"
                    Using detail As New fr_hutang_awal
                        With detail
                            .in_faktur.Text = dgv_list.Rows(rowindex).Cells(0).Value
                            .ShowDialog(main)
                        End With
                    End Using
                Case "pghutangbayar"
                    Using detail As New fr_hutang_bayar
                        With detail
                            .bt_simpanperkiraan.Text = "Update"
                            .in_no_bukti.Text = dgv_list.Rows(rowindex).Cells("bukti").Value
                            .ShowDialog(main)
                        End With
                    End Using
                Case "pgpiutangawal"
                    Using detail As New fr_piutang_awal
                        With detail
                            .in_faktur.Text = dgv_list.Rows(rowindex).Cells("faktur").Value
                            .ShowDialog(main)
                        End With
                    End Using
                Case "pgpiutangbayar"
                        Using detail As New fr_piutang_bayar
                            With detail
                                .bt_simpanperkiraan.Text = "Update"

                                .ShowDialog(main)
                            End With
                        End Using
                Case "pgpiutangbgtolak"
                        Using detail As New fr_bg_tolak
                            With detail
                                .bt_simpanperkiraan.Text = "Update"

                                .ShowDialog(main)
                            End With
                        End Using
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
                                .ShowDialog()
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
    End Sub

    Private Sub bt_hapus_Click(sender As Object, e As EventArgs) Handles bt_hapus.Click
        MessageBox.Show("Under Construction")
    End Sub

    Private Sub bt_refresh_Click(sender As Object, e As EventArgs) Handles bt_refresh.Click
        performRefresh()
    End Sub

    Private Sub dgv_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellClick
        rowindex = e.RowIndex
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
                bt_edit.PerformClick()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub dgv_list_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_list.KeyDown
        If e.KeyCode = Keys.Enter And dgv_list.RowCount <> 0 Then
            'keyshortcut("edit", tabpagename.Name.ToString)
        End If
    End Sub

    Private Sub SplitContainer1_KeyDown(sender As Object, e As KeyEventArgs) Handles SplitContainer1.KeyDown
        If e.KeyCode = Keys.Enter AndAlso in_cari.Focused = False Then
            'keyshortcut("edit", tabpagename.Name.ToString)
        End If
    End Sub

    Private Sub dgv_list_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellContentClick

    End Sub

    Private Sub bt_close_MouseEnter(sender As Object, e As EventArgs) Handles bt_close.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_close_MouseLeave(sender As Object, e As EventArgs) Handles bt_close.MouseLeave
        lbl_close.Visible = False
    End Sub
End Class
