Public Class fr_login
    Private pass_switch As Boolean = True
    Private tglkom As Date = System.DateTime.Today
    Private _tmer_ckLock As New Timer With {.Interval = 7500}

    Private Sub call_login()
        Dim loginstate As String = do_login(in_user.Text, in_pass.Text)
        If loginstate = 1 Then
            openMain()
        ElseIf loginstate = 9 Then
            Application.Exit()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub openMain()
        With main
            .strip_user.Text = loggeduser.user_id.ToString
            .strip_tgl.Text = System.DateTime.Today.ToString("dd MMMM yyyy")
            .MenuAkses()
            .loadInfoPanel()
            .Visible = True
            .Opacity = 100
        End With
        Me.Close()
    End Sub

    Public Sub clearLogin()
        in_pass.Clear()
        in_user.Clear()
    End Sub

    Private Sub ckDBLock()
        Dim q As String = "SELECT var_value FROM system_var WHERE var_name='sysLock'"
        Dim _sysLock As Boolean = False

        op_con()
        Try
            readcommd(q)
            If rd.HasRows Then
                _sysLock = IIf(rd.Item(0) = 1, True, False)
                rd.Close()
            Else
                MessageBox.Show("Terjadi kesalahan saat melakukan konfigurasi sistem." & Environment.NewLine & "Applikasi akan ditutup.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                rd.Close()
                Application.Exit()
                Exit Sub
            End If
            If _sysLock = True Then
                q = "SELECT IFNULL(var_value,'Ditutup') FROM system_var WHERE var_name='sysLockMessage'"
                readcommd(q)
                If rd.HasRows Then
                    MessageBox.Show(rd.Item(0), "Status System", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                rd.Close()
            End If
            bt_login.Enabled = IIf(_sysLock = True, False, True)
        Catch ex As Exception
            logError(ex, True)
            MessageBox.Show("Error. Terjadi kesalahan saat melakukan konfigurasi sistem.", "Login " & Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    Public Function getServerDate() As Date
        Dim _retval As Date = Today
        Dim q As String = "SELECT CURDATE()"

        op_con()
        Try
            readcommd(q)
            If rd.HasRows Then
                _retval = CDate(rd.Item(0))
            End If
            rd.Close()
        Catch ex As Exception
            logError(ex, True)
            MessageBox.Show("Error. Terjadi kesalahan saat melakukan koneksi ke server", "Login " & Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            _retval = Nothing
        End Try

        Return _retval
    End Function

    'DRAG FORM
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, lbl_judul.MouseDown, Label1.MouseDown, Label2.MouseDown, Label3.MouseDown, Label4.MouseDown, pbx_logo.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, lbl_judul.MouseMove, Label1.MouseMove, Label2.MouseMove, Label3.MouseMove, Label4.MouseMove, pbx_logo.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, lbl_judul.MouseUp, Label1.MouseUp, Label2.MouseUp, Label3.MouseUp, Label4.MouseUp, pbx_logo.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles MyBase.DoubleClick, lbl_judul.DoubleClick
        CenterToScreen()
    End Sub

    'LOAD

    Private Sub fr_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_judul.Text = "Login " & Application.ProductName
        loggeduser = usernull
        in_pass.UseSystemPasswordChar = True
        out_tglserver.Text = getServerDate.ToString("dd MMMM yyyy", Globalization.CultureInfo.CreateSpecificCulture("id-ID"))
        out_tglkomp.Text = tglkom.ToString("dd MMMM yyyy", Globalization.CultureInfo.CreateSpecificCulture("id-ID"))

        ckDBLock()

        AddHandler _tmer_ckLock.Tick, AddressOf _tmer_ckLock_Tick
        _tmer_ckLock.Start()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_close.PerformClick()
    End Sub

    Private Sub bt_mnz_Click(sender As Object, e As EventArgs) Handles bt_mnz.Click
        Me.WindowState = FormWindowState.Minimized
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

        call_login()
    End Sub

    Private Sub in_user_KeyDown(sender As Object, e As KeyEventArgs) Handles in_user.KeyDown
        If e.KeyCode = Keys.Enter Then
            If in_pass.Text = Nothing Then
                If e.KeyCode = Keys.Enter Then
                    e.SuppressKeyPress = True
                    in_pass.Focus()
                End If
            Else
                call_login()
            End If
        End If
    End Sub

    Private Sub in_pass_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pass.KeyDown
        If e.KeyCode = Keys.Enter Then
            If in_user.Text = Nothing Then
                If e.KeyCode = Keys.Enter Then
                    e.SuppressKeyPress = True
                    in_user.Focus()
                End If
            Else
                call_login()
            End If
        End If
    End Sub

    Private Sub bt_switch_Click(sender As Object, e As EventArgs) Handles bt_switch.Click
        With bt_switch
            If pass_switch = True Then
                .BackgroundImage = Global.Inventory.My.Resources.Resources.hide_password
                pass_switch = False
                in_pass.UseSystemPasswordChar = False
                ToolTip_login.SetToolTip(bt_switch, "Hide Password")
            Else
                .BackgroundImage = Global.Inventory.My.Resources.Resources.show_password
                pass_switch = True
                in_pass.UseSystemPasswordChar = True
                ToolTip_login.SetToolTip(bt_switch, "Show Password")
            End If
        End With
        in_pass.Focus()
    End Sub

    Private Sub _tmer_ckLock_Tick(sender As Object, e As EventArgs)
        ckDBLock()
    End Sub
End Class