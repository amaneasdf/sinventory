Public Class fr_akun_confirmdialog
    Public RetVal As New KeyValuePair(Of Boolean, String)
    Private pass_switch As Boolean = True

    Public Function checkUser(uid As String, pass As String) As Integer
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB connection is empty")
        End If

        Dim rval As Boolean = False
        Dim q As String = "SELECT user_validasi_akun FROM data_pengguna_alias WHERE user_alias='{0}' AND user_pwd='{1}' AND user_status=1"

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Try
                    Using rdx = x.ReadCommand(String.Format(q, uid, computeHash(pass)), CommandBehavior.SingleResult)
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            Return rdx.Item(0)
                        Else
                            Return -1
                        End If
                    End Using
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Terjadi kesalahan saat melakukan validasi." & Environment.NewLine & ex.Message,
                                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return 9
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return 9
            End If
        End Using
    End Function

    Public Sub do_loaddialog()
        Me.Text = lbl_title.Text
        in_pass.UseSystemPasswordChar = pass_switch
        ShowDialog()
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
        If MessageBox.Show("Batalkan?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            RetVal = New KeyValuePair(Of Boolean, String)(False, "CANCEL")
            Me.Close()
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbeli.PerformClick()
    End Sub

    'UI : TEXTBOX
    Private Sub in_user_KeyDown(sender As Object, e As KeyEventArgs) Handles in_user.KeyDown
        keyshortenter(in_pass, e)
    End Sub

    Private Sub in_pass_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pass.KeyDown
        keyshortenter(bt_simpanbeli, e)
    End Sub

    'UI : BUTTON
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

    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        If String.IsNullOrWhiteSpace(in_user.Text) Then
            MessageBox.Show("Username belum di input.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_user.Focus() : Exit Sub
        End If
        If String.IsNullOrWhiteSpace(in_pass.Text) Then
            MessageBox.Show("Password belum di input.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_pass.Focus() : Exit Sub
        End If

        Dim i As Integer = checkUser(in_user.Text, in_pass.Text)
        If i = 1 Then
            RetVal = New KeyValuePair(Of Boolean, String)(True, in_user.Text)
            Me.Close()
        Else
            Dim _msg As String = "User salah atau tidak dapat melakukan konfirmasi"
            If i = 9 Then
                Exit Sub
            ElseIf i = -1 Then
                _msg = "Username/password salah."
            Else
                _msg = "User " & in_user.Text & " tidak dapat melakukan konfirmasi/validasi."
            End If
            MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            in_user.Focus()
        End If

    End Sub
End Class