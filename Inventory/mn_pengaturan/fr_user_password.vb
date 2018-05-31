Public Class fr_user_password
    Private switchold As Boolean = True
    Private switchnew As Boolean = True

    Private Sub fr_user_password_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        in_passnew.UseSystemPasswordChar = True
        in_passold.UseSystemPasswordChar = True
        in_userid.Text = loggeduser.user_id
        in_passold.Focus()
    End Sub

    Private Sub keyshortenter(nextcontrol As Control, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nextcontrol.Focus()
        End If
    End Sub

    Private Sub bt_switch_oldpass_Click(sender As Object, e As EventArgs) Handles bt_switch_oldpass.Click
        With bt_switch_oldpass
            If switchold = True Then
                .BackgroundImage = Global.Inventory.My.Resources.Resources.hide_password
                switchold = False
                in_passold.UseSystemPasswordChar = False
            Else
                .BackgroundImage = Global.Inventory.My.Resources.Resources.show_password
                switchold = True
                in_passold.UseSystemPasswordChar = True
            End If
        End With
    End Sub

    Private Sub bt_switch_newpass_Click(sender As Object, e As EventArgs) Handles bt_switch_newpass.Click
        With bt_switch_newpass
            If switchnew = True Then
                .BackgroundImage = Global.Inventory.My.Resources.Resources.hide_password
                switchnew = False
                in_passnew.UseSystemPasswordChar = False
            Else
                .BackgroundImage = Global.Inventory.My.Resources.Resources.show_password
                switchnew = True
                in_passnew.UseSystemPasswordChar = True
            End If
        End With
    End Sub

    Private Sub bt_simpanuser_Click(sender As Object, e As EventArgs) Handles bt_simpanuser.Click
        Dim querycheck As Boolean = False
        If in_passold.Text = Nothing Then
            MessageBox.Show("Password lama belum di input")
            in_passold.Focus()
            Exit Sub
        End If
        If in_passnew.Text = Nothing Then
            MessageBox.Show("Password baru belum di input")
            in_passnew.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan password baru?", "Ubah Password", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If checkdata("data_pengguna_alias", "'" & in_userid.Text & "' AND user_pwd=MD5('" & in_passold.Text & "')", "user_alias") = False Then
                MessageBox.Show("Password lama salah")
                Exit Sub
            End If

            querycheck = commnd("UPDATE data_pengguna_alias SET user_pwd=MD5('" & in_passnew.Text & "'), user_exp_date=DATE_ADD(CURDATE(),INTERVAL 3 MONTH) WHERE user_alias = '" & in_userid.Text & "'")
        Else
            Exit Sub
        End If
       
        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Password baru tersimpan")
            Me.Dispose()
        End If
    End Sub

    Private Sub bt_bataluser_Click(sender As Object, e As EventArgs) Handles bt_bataluser.Click
        Me.Dispose()
    End Sub

    Private Sub in_passold_KeyDown(sender As Object, e As KeyEventArgs) Handles in_passold.KeyDown
        keyshortenter(in_passnew, e)
    End Sub

    Private Sub in_passnew_KeyDown(sender As Object, e As KeyEventArgs) Handles in_passnew.KeyDown
        keyshortenter(bt_simpanuser, e)
    End Sub
End Class