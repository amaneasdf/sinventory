Public Class fr_tutupconfirm_dialog
    Private tipe As String = "IN"
    Public returnval As Boolean = False
    Private pass_switch As Boolean = True

    Public Function checkUser(uid As String, pass As String) As Boolean
        Dim rval As Boolean = False
        Dim q As String = "SELECT user_validasi_akun FROM data_pengguna_alias " _
                          & " WHERE user_alias='{0}' AND user_pwd=MD5('{1}') AND user_status=1"
        op_con()
        Try
            'q = "SELECT checkUser('{0}','{1}')"
            readcommd(String.Format(q, uid, pass))
            If rd.HasRows Then
                If rd.Item(0) = 1 Then
                    rval = True
                End If
            End If
            rd.Close()
        Catch ex As Exception
            logError(ex)
        End Try

        Return rval
    End Function

    Public Sub do_load(tipetrans As String)
        tipe = UCase(tipetrans)

        in_pass.UseSystemPasswordChar = True
        'If tipe = "IN" Then
        '    lbl_cair.Visible = True
        '    cb_akun.Visible = True
        'Else
        '    lbl_cair.Visible = False
        '    cb_akun.Visible = False
        'End If

        'loadCBAkun("BG")
    End Sub

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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        If MessageBox.Show("Batalkan?", "Konfirmasi Tutup Buku", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            returnval = False
            Me.Close()
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbeli.PerformClick()
    End Sub

    'UI
    Private Sub in_user_KeyDown(sender As Object, e As KeyEventArgs) Handles in_user.KeyDown
        keyshortenter(IIf(in_pass.Text = "", in_pass, bt_simpanbeli), e)
    End Sub

    Private Sub in_pass_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pass.KeyDown
        keyshortenter(IIf(in_user.Text = "", in_user, bt_simpanbeli), e)
    End Sub

    Private Sub bt_switch_Click(sender As Object, e As EventArgs) Handles bt_switch.Click
        With bt_switch
            If pass_switch = True Then
                .BackgroundImage = Global.Inventory.My.Resources.Resources.hide_password
                pass_switch = False
                in_pass.UseSystemPasswordChar = False
            Else
                .BackgroundImage = Global.Inventory.My.Resources.Resources.show_password
                pass_switch = True
                in_pass.UseSystemPasswordChar = True
            End If
        End With
        in_pass.Focus()
    End Sub

    'BUTTON
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        If in_user.Text = "" Then
            MessageBox.Show("Username belum di input")
            in_user.Focus()
            Exit Sub
        End If
        If in_pass.Text = "" Then
            MessageBox.Show("Password belum di input")
            in_pass.Focus()
            Exit Sub
        End If
        If checkUser(in_user.Text, in_pass.Text) = False Then
            MessageBox.Show("User salah atau tidak dapat melakukan penutupan")
            in_user.Focus()
            Exit Sub
        End If

        returnval = True
        Me.Close()
    End Sub

    Private Sub fr_tutupconfirm_dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        in_pass.UseSystemPasswordChar = True
    End Sub
End Class