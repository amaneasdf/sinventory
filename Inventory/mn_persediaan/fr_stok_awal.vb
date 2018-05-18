Public Class fr_stok_awal

    Private Sub setGudang(kode As String)
        op_con()
        readcommd("SELECT gudang_nama FROM data_barang_gudang WHERE gudang_kode='" & kode & "'")
        If rd.HasRows Then
            lbl_gudang.Text = rd.Item("gudang_nama")
        End If
        rd.Close()
    End Sub


    Private Sub setBarang(kode As String)
        op_con()
        readcommd("SELECT barang_nama FROM data_barang_master WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            lbl_barang.Text = rd.Item("barang_nama")
        End If
        rd.Close()
    End Sub


    Private Sub fr_stok_awal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_barang.Text = ""
        lbl_gudang.Text = ""
    End Sub

    Private Sub bt_simpanbarang_Click(sender As Object, e As EventArgs) Handles bt_simpanbarang.Click
        Dim querycheck As Boolean = True
        Dim data As String()

        If lbl_gudang.Text = "" Then
            MessageBox.Show("Gudang belum di input")
            in_gudang.Focus()
            Exit Sub
        End If
        If lbl_barang.Text = "" Then
            MessageBox.Show("Barang belum di input")
            in_barang.Focus()
            Exit Sub
        End If

        data = {
            "stok_tanggal=TODAY()",
            "stock_gudang='" & in_gudang.Text & "'",
            "stock_barang='" & in_barang.Text & "'",
            "stock_awal=" & in_stok_awal.Value,
            "stock_hpp='" & in_hpp.Value & "'",
            "stock_reg_date=NOW()",
            "stock_reg_alias='" & loggeduser.user_id & "'"
            }

        If checkdata("data_barang_stok", "'" & in_barang.Text & "' AND stock_gudang='" & in_gudang.Text & "'", "stock_barang") = True Then
            MessageBox.Show("Stok sudah ada")
            in_gudang.Focus()
            Exit Sub
        End If

        querycheck = commnd("INSERT INTO data_barang_stok SET " & String.Join(",", data))

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmpembelian.in_cari.Clear()
            populateDGVUserCon("beli", "", frmpembelian.dgv_list)
            Me.Dispose()
        End If
    End Sub

    Private Sub bt_batalbarang_Click(sender As Object, e As EventArgs) Handles bt_batalbarang.Click
        Me.Close()
    End Sub
End Class