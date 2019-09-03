Public Class fr_jualconfirm_dialog
    Public returnval As New KeyValuePair(Of Boolean, String)
    Private pass_switch As Boolean = True
    Private formstate As ValidType = ValidType.Validation

    Private Enum ValidType
        Validation
        UserConfirm
    End Enum

    'LOAD DIALOG
    Private Sub LoadForm(formstate As ValidType)
        Me.formstate = formstate
        Me.Text = Me.lbl_title.Text
        in_pass.UseSystemPasswordChar = pass_switch
        in_user.ReadOnly = IIf(formstate = ValidType.Validation, False, True)
    End Sub

    Public Sub doLoadValid()
        Me.Text = "Validasi Transaki"
        LoadForm(ValidType.Validation)
        Me.ShowDialog()
    End Sub

    Public Sub doLoadConfirm(Uid As String)
        Me.Text = "Konfirmasi Transaksi"
        LoadForm(ValidType.UserConfirm)
        in_user.Text = Uid
        Me.ShowDialog()
    End Sub

    'USER DATA VALID
    Public Function checkUser(uid As String, pass As String) As Boolean
        Dim q As String = ""
        Select Case formstate
            Case ValidType.Validation
                q = "SELECT user_validasi_trans FROM data_pengguna_alias " _
                    & "WHERE user_alias='{0}' AND user_pwd='{1}' AND user_status=1"
            Case ValidType.UserConfirm
                q = "SELECT COUNT(user_alias) FROM data_pengguna_alias " _
                    & "WHERE user_alias='{0}' AND user_pwd='{1}' AND user_status=1"
            Case Else
                Return False : Exit Function
        End Select
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    Dim i As Integer = 0
                    Dim f = x.ExecScalar(String.Format(q, uid, computeHash(pass)))
                    If Not IsNothing(f) Then i = Integer.Parse(f)
                    If i = 1 Then
                        Return True
                    ElseIf i > 1 And formstate = ValidType.UserConfirm Then
                        MessageBox.Show("Terjadi kesalahan saat melakukan validasi data user." & Environment.NewLine & "Error duplicated entry",
                                   Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        errLog(New List(Of String) From {Now.ToString("yyyy-MM-dd hh:mm:ss"), "----- DUPLICATE ENTRY:data_pengguna", "----- " & uid})
                        Return False
                    Else
                        Dim _msg As String = ""
                        If i = 0 And formstate = ValidType.Validation Then
                            _msg = "User tidak ditemukan/tidak dapat melakukan validasi transaksi."
                        Else
                            _msg = "Username/Password salah. User tidak dapat ditemukan."
                        End If
                        MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return False
                    End If
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Terjadi kesalahan saat melakukan validasi data user." & Environment.NewLine & ex.Message,
                                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Using
    End Function

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
            returnval = New KeyValuePair(Of Boolean, String)(False, String.Empty)
            Me.Close()
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbeli.PerformClick()
    End Sub

    'UI : TEXTBOX
    Private Sub in_user_KeyDown(sender As Object, e As KeyEventArgs) Handles in_user.KeyDown
        keyshortenter(IIf(in_pass.Text = "", in_pass, bt_simpanbeli), e)
    End Sub

    Private Sub in_pass_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pass.KeyDown
        keyshortenter(IIf(in_user.Text = "", in_user, bt_simpanbeli), e)
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
        If in_user.Text = "" Then
            MessageBox.Show("Username belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_user.Focus()
            Exit Sub
        End If
        If in_pass.Text = "" Then
            MessageBox.Show("Password belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_pass.Focus()
            Exit Sub
        End If
        If checkUser(in_user.Text, in_pass.Text) Then
            returnval = New KeyValuePair(Of Boolean, String)(True, in_user.Text)
            Me.Close()
        End If
    End Sub
End Class