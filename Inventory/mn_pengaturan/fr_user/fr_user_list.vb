Public Class fr_user_list
    Private dgv_rowindex As Integer = 0

    Public Sub addcolDGV_user()

    End Sub

    Public Sub populateDGV_User(param As String)
        Dim dat_bind As New BindingSource
        dat_bind.DataSource = getDataTablefromDB("call getUser")
        dat_bind.Filter = "userid like '%" & param & "%' or nama like '%" & param & "%'"
        With dgv_user
            .RowHeadersWidth = 20
            .DataSource = dat_bind
        End With
    End Sub

    Private Sub in_caribarang_TextChanged(sender As Object, e As KeyEventArgs) Handles in_cari_user.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = False
            If in_cari_user.Text = Nothing Then
                populateDGV_User("")
            Else
                populateDGV_User(in_cari_user.Text)
            End If
        End If
    End Sub

    Private Sub bt_tambah_user_Click(sender As Object, e As EventArgs) Handles bt_tambah_user.Click
        With fr_user_detail
            .bt_simpanuser.Text = "Simpan"
            .bt_reset_user.Enabled = False
            .ShowDialog()
        End With
    End Sub

    Private Sub bt_edit_user_Click(sender As Object, e As EventArgs) Handles bt_edit_user.Click
        Dim usr_det As New fr_user_detail
        With usr_det
            .Text = .Text & dgv_user.Rows(dgv_rowindex).Cells(1).Value
            .bt_simpanuser.Text = "Update"
            .in_kode.Text = dgv_user.Rows(dgv_rowindex).Cells(0).Value
            .ShowDialog()
        End With
    End Sub

    Private Sub dgv_user_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_user.CellClick
        dgv_rowindex = e.RowIndex
    End Sub

    Private Sub bt_refreshbarang_Click(sender As Object, e As EventArgs) Handles bt_refreshbarang.Click
        populateDGV_User("")
    End Sub

    Private Sub bt_closebarang_Click(sender As Object, e As EventArgs) Handles bt_closebarang.Click
        main.tabcontrol.TabPages.Remove(pguser)
    End Sub
End Class
