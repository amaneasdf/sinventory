Public Class fr_setup_menu

    Private Sub populateDGV_menu()
        op_con()
        With dgv_menu
            .DataSource = getDataTablefromDB("SELECT menu_id, menu_kode, menu_label FROM data_menu_master ORDER BY menu_kode ASC")
        End With
    End Sub

    Private Sub clearText()
        in_id.Clear()
        in_menu_kode.Clear()
        in_menu_nama.Clear()
        in_menu_parent.Clear()
    End Sub

    Private Sub fr_setup_menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        op_con()
        populateDGV_menu()
    End Sub

    Private Sub bt_tambah_menu_Click(sender As Object, e As EventArgs) Handles bt_tambah_menu.Click
        Dim querycheck As Boolean = False

        If in_menu_kode.Text = Nothing Then
            MessageBox.Show("Kode menu belum di input")
            in_menu_kode.Focus()
            Exit Sub
        End If

        If in_menu_nama.Text = Nothing Then
            MessageBox.Show("Nama belum di input")
            in_menu_nama.Focus()
            Exit Sub
        End If

        If in_id.Text = Nothing Then
            For Each row As DataGridViewRow In dgv_menu.Rows
                If in_menu_kode.Text = row.Cells(1).Value Then
                    MessageBox.Show("Kode menu sudah ada")
                    in_menu_kode.Focus()
                    Exit Sub
                End If
            Next

            op_con()
            querycheck = commnd("INSERT INTO data_menu_master(menu_kode,menu_parent,menu_label) VALUES('" & in_menu_kode.Text & "','" & in_menu_parent.Text & "','" & in_menu_nama.Text & "')")

        ElseIf in_menu_kode.Text <> Nothing And bt_tambah_menu.Text = "Update" Then
            op_con()
            querycheck = commnd("UPDATE data_menu_master SET menu_kode='" & in_menu_kode.Text & "', menu_parent='" & in_menu_parent.Text & "', menu_label='" & in_menu_nama.Text & "' WHERE menu_id='" & in_id.Text & "'")
            bt_tambah_menu.Text = "Simpan"
        End If

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            populateDGV_menu()
            clearText()
            bt_hapus_menu.Enabled = False
        End If
    End Sub

    Private Sub bt_keluar_Click(sender As Object, e As EventArgs) Handles bt_keluar_menu.Click
        Me.Close()
    End Sub

    Private Sub bt_hapus_menu_Click(sender As Object, e As EventArgs) Handles bt_hapus_menu.Click
        MessageBox.Show("Under Construction")
    End Sub

    Private Sub in_menu_kode_TextChanged(sender As Object, e As EventArgs) Handles in_menu_kode.TextChanged
        If in_menu_kode.Text <> Nothing Then
            in_menu_parent.Text = sLeft(in_menu_kode.Text, 4)
        End If
    End Sub

    Private Sub dgv_menu_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_menu.CellDoubleClick
        On Error Resume Next
        With dgv_menu.Rows(e.RowIndex)
            in_id.Text = .Cells(0).Value
            in_menu_kode.Text = .Cells(1).Value
            in_menu_nama.Text = .Cells(2).Value
        End With
        bt_tambah_menu.Text = "Update"
        bt_hapus_menu.Enabled = True
        in_menu_kode.Focus()
    End Sub

    Private Sub bt_batal_Click(sender As Object, e As EventArgs) Handles bt_batal.Click
        clearText()
        bt_hapus_menu.Enabled = False
        bt_tambah_menu.Text = "Tambah"
        in_menu_kode.Focus()
    End Sub
End Class