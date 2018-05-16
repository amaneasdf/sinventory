Public Class fr_login

    Private tglkom As Date = System.DateTime.Today

    Public Sub clearLogin()
        in_pass.Clear()
        in_user.Clear()
    End Sub

    Private Sub fr_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_judul.Text = Application.ProductName
        loggeduser = usernull
        in_pass.UseSystemPasswordChar = True
        op_con()
        readcommd("SELECT CURDATE() AS tanggal")
        out_tglserver.Text = Format(rd.Item("Tanggal"), "dd MMMM yyyy")
        rd.Close()
        out_tglkomp.Text = tglkom.ToString("dd MMMM yyyy", Globalization.CultureInfo.CreateSpecificCulture("id-ID"))
    End Sub

    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_close.Click
        Application.Exit()
    End Sub

    Private Sub bt_login_Click(sender As Object, e As EventArgs) Handles bt_login.Click
        If in_user.Text = Nothing Then
            MessageBox.Show("Masukkan UserID")
            in_user.Focus()
            Exit Sub
        End If

        If in_pass.Text = Nothing Then
            MessageBox.Show("Masukkan Password")
            in_pass.Focus()
            Exit Sub
        End If

        do_login(in_user.Text, in_pass.Text)
    End Sub

    Private Sub in_user_KeyDown(sender As Object, e As KeyEventArgs) Handles in_user.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            in_pass.Focus()
        End If
    End Sub

    Private Sub in_pass_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pass.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            bt_login.PerformClick()
        End If
    End Sub
End Class