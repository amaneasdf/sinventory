Public Class fr_stok_mutasi_list
    Public tabpagename As TabPage
    Private rowindex As Integer = 0
    Private tblstatus As String = ""

    Public Sub setpage(page As TabPage)
        tabpagename = page
    End Sub

    'REFRESH PAGE
    Public Sub performRefresh()
        in_cari.Clear()
        searchData("")
        in_countdata.Text = dgv_list.Rows.Count

        If selectperiode.closed = True Then
            mn_tambah.Enabled = False
            mn_hapus.Enabled = False
        End If
    End Sub

    'LOAD DATA
    Private Sub loadData(kode As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB connection is empty")
        End If
        Dim q As String = ""
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT faktur_kode, faktur_tanggal, faktur_gudang_asal, a.gudang_nama as gudang_asal, faktur_gudang_tujuan, " _
                    & "pajak.ref_text faktur_kat, b.gudang_nama as gudang_tujuan, faktur_status " _
                    & "FROM data_barang_stok_mutasi LEFT JOIN data_barang_gudang a ON faktur_gudang_asal=a.gudang_kode " _
                    & "LEFT JOIN data_barang_gudang b ON faktur_gudang_tujuan=b.gudang_kode " _
                    & "LEFT JOIN ref_jenis pajak ON faktur_pajak=pajak.ref_kode AND pajak.ref_status=1 AND pajak.ref_type='ppn_trans2'" _
                    & "WHERE faktur_kode='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, kode), CommandBehavior.SingleRow)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_kode.Text = rdx.Item("faktur_kode")
                        date_tgl_beli_r.Text = CDate(rdx.Item("faktur_tanggal")).ToLongDateString
                        in_kat.Text = rdx.Item("faktur_kat")
                        in_gudang.Text = rdx.Item("faktur_gudang_asal")
                        in_gudang_n.Text = rdx.Item("gudang_asal")
                        in_gudang2.Text = rdx.Item("faktur_gudang_tujuan")
                        in_gudang2_n.Text = rdx.Item("gudang_tujuan")
                        tblstatus = rdx.Item("faktur_status")
                    End If
                End Using
                q = "SELECT trans_barang, barang_nama, trans_qty_besar, barang_satuan_besar, trans_qty_tengah, " _
                    & "barang_satuan_tengah, trans_qty_kecil, barang_satuan_kecil, trans_qty_tot,trans_hpp " _
                    & "FROM data_barang_stok_mutasi_trans LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                    & "WHERE trans_faktur='{0}' AND trans_status=1"
                Using dt = x.GetDataTable(String.Format(q, kode))
                    With dgv_barang.Rows
                        For Each row As DataRow In dt.Rows
                            Dim i = .Add
                            .Item(i).Cells("kode").Value = row.ItemArray(0)
                            .Item(i).Cells("nama").Value = row.ItemArray(1)
                            .Item(i).Cells("qty_b").Value = row.ItemArray(2)
                            .Item(i).Cells("sat_b").Value = row.ItemArray(3)
                            .Item(i).Cells("qty_t").Value = row.ItemArray(4)
                            .Item(i).Cells("sat_t").Value = row.ItemArray(5)
                            .Item(i).Cells("qty_k").Value = row.ItemArray(6)
                            .Item(i).Cells("sat_k").Value = row.ItemArray(7)
                            .Item(i).Cells("qty_tot").Value = row.ItemArray(8)
                            .Item(i).Cells("hpp_brg").Value = row.ItemArray(9)
                        Next
                    End With
                End Using
                'SET STATUS
                Select Case tblstatus
                    Case 0 : in_status.Text = "Pending"
                    Case 1 : in_status.Text = "Aktif"
                    Case 2 : in_status.Text = "Batal"
                    Case 8 : in_status.Text = "On-Edit/NOT IMPLEMENTED!"
                    Case 9 : in_status.Text = "Delete"
                    Case Else : Exit Sub
                End Select
                setStatus()
            Else
                MessageBox.Show("Tidak dapat terhubung ke server", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Sub setStatus()
        Select Case tblstatus
            Case 0, 1
                mn_hapus.Enabled = If(selectperiode.closed = False, True, False)
                mn_print.Enabled = If(tblstatus = 1, True, False)
            Case 2, 9
                mn_hapus.Enabled = False
                mn_print.Enabled = False
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub searchData(param As String)
        clearPreview()
        populateDGVUserCon("mutasigudang", param, frmmutasigudang.dgv_list)
    End Sub

    Private Sub listToDetail()
        Try
            Me.Cursor = Cursors.AppStarting
            dgv_barang.Rows.Clear()
            loadData(dgv_list.Rows(rowindex).Cells("kode").Value)
        Catch ex As Exception
            Dim text As String = "Tidak dapat menampilkan data" & Environment.NewLine & ex.Message
            MessageBox.Show(text)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    'CANCEL TRANSACTION
    Private Sub cancelData(NoFaktur)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim queryCk As Boolean = False
        Dim queryArr As New List(Of String)
        Dim q As String = ""
        Dim _confrm As Boolean = False
        Dim _ket As String = ""

        If TransConfirmValid(_ket) Then
            q = "UPDATE data_barang_stok_mutasi SET faktur_status=2, faktur_ket =TRIM(BOTH '\r\n' FROM CONCAT(faktur_ket,'\r\n','{2}')), " _
                & "faktur_upd_date =NOW(), faktur_upd_alias='{1}' WHERE faktur_kode='{0}'"
            queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id, _ket))

            q = "CALL transMutasiStokFin('{0}','{1}')"
            queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id))

            Using x = MainConnection
                x.Open()
                If x.ConnectionState = ConnectionState.Open Then
                    queryCk = x.TransactCommand(queryArr)
                End If
            End Using

            If queryCk Then
                MessageBox.Show("Transaksi mutasi dibatalkan.", "Mutasi Stok", MessageBoxButtons.OK, MessageBoxIcon.Information)
                performRefresh()
            Else
                MessageBox.Show("Error. Transaksi gagal dibatalkan.", "Mutasi Stok", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub clearPreview()
        For Each x As TextBox In {in_kode, in_gudang_n, in_gudang, in_gudang2, in_gudang2_n, date_tgl_beli_r, in_kat}
            x.Clear()
        Next

        dgv_barang.Rows.Clear()
    End Sub

    'UI : CLOSE
    Private Sub bt_close_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_close_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        clearPreview()
        main.tabcontrol.TabPages.Remove(tabpagename)
        rowindex = 0
    End Sub

    'UI : MENU
    Private Sub mn_tambah_Click(sender As Object, e As EventArgs) Handles mn_tambah.Click
        Dim detail As New fr_stok_mutasi
        detail.doLoadNew()
    End Sub

    Private Sub mn_edit_Click(sender As Object, e As EventArgs) Handles mn_edit.Click
        Dim detail As New fr_stok_mutasi
        If selectperiode.closed = False Then
            If in_kode.Text <> Nothing Then
                detail.doLoadEdit(in_kode.Text, loggeduser.allowedit_transact)
            Else
                detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
            End If
        End If
    End Sub

    Private Sub mn_hapus_Click(sender As Object, e As EventArgs) Handles mn_hapus.Click
        Dim _kode As String = ""
        If in_kode.Text <> Nothing And {0, 1}.Contains(tblstatus) Then
            _kode = in_kode.Text
            If MessageBox.Show("Batalkan Transaksi mutasi stok?", "Mutasi Antar Gudang", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                cancelData(_kode)
            End If
        End If
    End Sub

    Private Sub mn_refresh_Click(sender As Object, e As EventArgs) Handles mn_refresh.Click
        performRefresh()
    End Sub

    Private Sub mn_cari_Click(sender As Object, e As EventArgs) Handles mn_cari.Click
        in_cari.Focus()
    End Sub

    'cari
    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            searchData(in_cari.Text)
        End If
    End Sub

    'UI : DGV LIST
    Private Sub dgv_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellClick
        If e.RowIndex >= 0 Then
            listToDetail()
        End If
    End Sub

    Private Sub dgv_list_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_list.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim detail As New fr_stok_mutasi
            If selectperiode.closed = False Then
                detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
            Else
                detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
            End If
        End If
    End Sub

    Private Sub dgv_list_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgv_list.RowsAdded
        in_countdata.Text = dgv_list.Rows.Count
    End Sub

    Private Sub dgv_list_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellDoubleClick
        Dim detail As New fr_stok_mutasi
        If selectperiode.closed = False Then
            detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
        Else
            detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub
End Class
