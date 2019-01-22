Public Class fr_user_password
    Private switchold As Boolean = True
    Private switchnew As Boolean = True
    '------------drag form
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, lbl_title.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, lbl_title.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, lbl_title.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick, lbl_title.DoubleClick
        CenterToScreen()
    End Sub

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_bataluser.Click
        Me.Close()
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Tutup Form?", "Kas", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_bataluser.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

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
        Dim queryArr As New List(Of String)
        Dim querycheck As Boolean = False
        Dim q As String = ""

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

        If MessageBox.Show("Simpan password baru?", "Ubah Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If checkdata("data_pengguna_alias", "'" & in_userid.Text & "' AND user_pwd='" & computeHash(in_passold.Text) & "'", "user_alias") = False Then
                MessageBox.Show("Password lama salah")
                Exit Sub
            End If

            q = "UPDATE data_pengguna_alias SET user_pwd='{0}', user_status=1 WHERE user_alias = '{0}'"
            queryArr.Add(String.Format(q, computeHash(in_passnew.Text), in_userid.Text))

            q = "INSERT INTO system_pwdchange_log(log_alias1,log_alias2,log_ip,log_tanggal) VALUE({0})"
            Dim data As String() = {"'" & in_userid.Text & "'", "'" & loggeduser.user_id & "'", "'" & loggeduser.user_ip & "'", "NOW()"}
            queryArr.Add(String.Format(q, String.Join(",", data)))

            querycheck = startTrans(queryArr)
        Else
            Exit Sub
        End If

        If querycheck = False Then
            MessageBox.Show("Password baru gagal tersimpan", "Ubah Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            MessageBox.Show("Password baru tersimpan", "Ubah Password")
            Me.Close()
        End If
    End Sub

    Private Sub in_passold_KeyDown(sender As Object, e As KeyEventArgs) Handles in_passold.KeyDown
        keyshortenter(in_passnew, e)
    End Sub

    Private Sub in_passnew_KeyDown(sender As Object, e As KeyEventArgs) Handles in_passnew.KeyDown
        keyshortenter(bt_simpanuser, e)
    End Sub
End Class