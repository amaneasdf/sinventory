Public Class fr_stok_mutasibarang_list
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
            Throw New NullReferenceException("Main DB Connection is empty")
        End If
        Dim q As String = ""
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT faktur_kode, faktur_tanggal, pajak.ref_text faktur_kat, faktur_gudang, gudang_nama, faktur_status " _
                    & "FROM data_barang_mutasi " _
                    & "LEFT JOIN data_barang_gudang ON gudang_kode=faktur_gudang " _
                    & "LEFT JOIN ref_jenis pajak ON faktur_pajak=pajak.ref_kode AND pajak.ref_status=1 AND pajak.ref_type='ppn_trans2'" _
                    & "WHERE faktur_kode ='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, kode))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_kode.Text = rdx.Item("faktur_kode")
                        in_kat.Text = rdx.Item("faktur_kat")
                        date_tgl_beli_r.Text = CDate(rdx.Item("faktur_tanggal")).ToLongDateString
                        in_gudang.Text = rdx.Item("faktur_gudang")
                        in_gudang_n.Text = rdx.Item("gudang_nama")
                        tblstatus = rdx.Item("faktur_status")
                    End If
                End Using
                q = "SELECT trans_barang_asal, a.barang_nama, trans_qty_asal, trans_sat_asal,trans_hpp_asal, " _
                    & "trans_barang_tujuan, b.barang_nama, trans_qty_tujuan, trans_sat_tujuan,trans_hpp_tujuan  " _
                    & "FROM data_barang_mutasi_trans " _
                    & "LEFT JOIN data_barang_master a ON a.barang_kode=trans_barang_asal " _
                    & "LEFT JOIN data_barang_master b ON b.barang_kode=trans_barang_tujuan " _
                    & "WHERE trans_faktur='{0}' AND trans_status=1"
                Using dt = x.GetDataTable(String.Format(q, kode))
                    With dgv_barang.Rows
                        For Each row As DataRow In dt.Rows
                            Dim i = .Add
                            .Item(i).Cells("kode").Value = row.ItemArray(0)
                            .Item(i).Cells("nama").Value = row.ItemArray(1)
                            .Item(i).Cells("qty_a").Value = row.ItemArray(2)
                            .Item(i).Cells("sat_a").Value = row.ItemArray(3)
                            .Item(i).Cells("hpp").Value = row.ItemArray(4)
                            .Item(i).Cells("kode_b").Value = row.ItemArray(5)
                            .Item(i).Cells("nama_b").Value = row.ItemArray(6)
                            .Item(i).Cells("qty_b").Value = row.ItemArray(7)
                            .Item(i).Cells("sat_b").Value = row.ItemArray(8)
                            .Item(i).Cells("hpp_b").Value = row.ItemArray(9)
                        Next
                    End With
                End Using
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

    'SEARCH
    Private Sub searchData(param As String)
        clearPreview()
        populateDGVUserCon("mutasistok", param, frmmutasistok.dgv_list)
    End Sub

    'LOAD DATA TO FORM + SETUP
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

    'CANCEL DATA
    Private Sub cancelData()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim queryCk As Boolean = False
        Dim queryArr As New List(Of String)
        Dim q As String = ""
        Dim _confrm As Boolean = False
        Dim _ket As String = ""

        If TransConfirmValid(_ket) Then
            Using x = MainConnection
                x.Open()
                If x.ConnectionState = ConnectionState.Open Then
                    q = "UPDATE data_barang_mutasi SET faktur_status=2, faktur_ket=TRIM(BOTH '\r\n' FROM CONCAT(faktur_ket,'\r\n','{2}')), " _
                        & "faktur_upd_date =NOW(), faktur_upd_alias='{1}' WHERE faktur_kode='{0}'"
                    queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id, mysqlQueryFriendlyStringFeed(_ket)))

                    q = "CALL transMutasiBarangFin('{0}','{1}')"
                    queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id))

                    queryCk = x.TransactCommand(queryArr)
                End If

                If queryCk Then
                    MessageBox.Show("Transaksi mutasi dibatalkan.", "Mutasi Barang", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    performRefresh()
                Else
                    MessageBox.Show("Error. Transaksi gagal dibatalkan", "Mutasi Barang", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End If
    End Sub

    Private Sub clearPreview()
        For Each x As TextBox In {in_kode, in_kat, in_gudang, in_gudang_n, in_status, date_tgl_beli_r}
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
        Dim detail As New fr_stok_mutasi_barang
        detail.doLoadNew()
    End Sub

    Private Sub mn_edit_Click(sender As Object, e As EventArgs) Handles mn_edit.Click
        Dim detail As New fr_stok_mutasi_barang
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
            If MessageBox.Show("Batalkan Transaksi mutasi?", "Mutasi Stok", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                cancelData()
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

    Private Sub dgv_list_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_list.KeyUp
        If e.KeyCode = Keys.Enter And rowindex >= 0 Then
            Dim detail As New fr_stok_mutasi_barang
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
        Dim detail As New fr_stok_mutasi_barang
        If selectperiode.closed = False Then
            detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
        Else
            detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub
End Class
