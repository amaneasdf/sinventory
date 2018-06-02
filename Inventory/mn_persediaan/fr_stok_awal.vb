Public Class fr_stok_awal

    Public Sub setGudang(kode As String)
        op_con()
        readcommd("SELECT gudang_nama FROM data_barang_gudang WHERE gudang_kode='" & kode & "'")
        If rd.HasRows Then
            lbl_gudang.Text = rd.Item("gudang_nama")
        End If
        rd.Close()
    End Sub

    Public Sub setBarang(kode As String)
        op_con()
        readcommd("SELECT barang_nama FROM data_barang_master WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            lbl_barang.Text = rd.Item("barang_nama")
        End If
        rd.Close()
    End Sub

    Private Sub numericGotFocus(sender As NumericUpDown)
        If sender.Value = 0 Then
            sender.ResetText()
        End If
    End Sub

    Private Sub numericLostFocus(x As NumericUpDown)
        x.Controls.Item(1).Text = x.Value
    End Sub

    Private Sub keyshortenter(nextcontrol As Control, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nextcontrol.Focus()
        End If
    End Sub

    Private Sub fr_stok_awal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If in_barang.Text = "" Then
            lbl_barang.Text = ""
            lbl_gudang.Text = ""
        End If
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
            commnd("INSERT INTO log_stock SET log_reg=NOW(), log_user='" & loggeduser.user_id & "', log_barang='" & in_barang.Text & "', log_gudang='" & in_gudang.Text & "', log_tanggal=NOW(), log_ip='" & loggeduser.user_ip & "', log_komputer='" & loggeduser.user_host & "', log_mac='" & loggeduser.user_mac & "', log_nama='SETUP AWAL STOK'")
            frmstok.in_cari.Clear()
            populateDGVUserCon("stok", "", frmstok.dgv_list)
            Me.Close()
        End If
    End Sub

    Private Sub bt_batalbarang_Click(sender As Object, e As EventArgs) Handles bt_batalbarang.Click
        Me.Close()
    End Sub

    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        lbl_gudang.Text = ""
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    .query = "SELECT gudang_kode as kode, gudang_nama as nama FROM data_barang_gudang"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "gudang"
                    .ShowDialog()
                    in_gudang.Text = .returnkode
                End With
            End Using
            in_barang.Focus()
            Exit Sub
        End If
        keyshortenter(in_barang, e)
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        lbl_barang.Text = ""
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    .query = "SELECT barang_nama as nama, barang_kode as kode, barang_harga_beli as hargabeli, barang_harga_jual as hargajual FROM data_barang_master"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "barang"
                    .ShowDialog()
                    in_barang.Text = .returnkode
                End With
            End Using
            in_stok_awal.Focus()
            Exit Sub
        End If
        keyshortenter(in_stok_awal, e)
    End Sub

    Private Sub in_stok_awal_Enter(sender As Object, e As EventArgs) Handles in_stok_awal.Enter, in_hpp.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_stok_awal_Leave(sender As Object, e As EventArgs) Handles in_stok_awal.Leave, in_hpp.Leave
        numericLostFocus(sender)
    End Sub

    Private Sub in_gudang_Leave(sender As Object, e As EventArgs) Handles in_gudang.Leave
        setGudang(in_gudang.Text)
    End Sub

    Private Sub in_barang_Leave(sender As Object, e As EventArgs) Handles in_barang.Leave
        setBarang(in_barang.Text)
    End Sub

    Private Sub in_stok_awal_KeyDown(sender As Object, e As KeyEventArgs) Handles in_stok_awal.KeyDown
        keyshortenter(in_hpp, e)
    End Sub

    Private Sub in_hpp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_hpp.KeyDown
        keyshortenter(bt_simpanbarang, e)
    End Sub
End Class