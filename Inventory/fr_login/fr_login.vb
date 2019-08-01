Public Class fr_login
    Private pass_switch As Boolean = True
    Private tglkom As Date = System.DateTime.Today
    Private _tmer_ckLock As New Timer With {.Interval = 7500}
    Public AppClosing As Boolean = True

    Private Async Function call_login() As Task
        Dim loginstate As String = do_login(in_user.Text, in_pass.Text)
        If loginstate = 1 Then
            If loggeduser.user_id <> Nothing Then
                Try
                    Await logUser("login")
                    Await updateUserLogin()
                    openMain()
                Catch ex As Exception
                    logError(ex)
                    main.isForcedClose = True
                    Application.Exit()
                End Try
            End If
        ElseIf loginstate = 9 Then
            main.isForcedClose = True
            Application.Exit()
        Else
            Exit Function
        End If
    End Function

    Private Sub openMain()
        _tmer_ckLock.Stop()
        If loggeduser.user_id = Nothing Then
            MessageBox.Show("Tidak dapat mengambil data user.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            main.isForcedClose = True
            Application.Exit()
        Else
            With main
                .strip_user.Text = loggeduser.user_id.ToString
                .strip_tgl.Text = System.DateTime.Today.ToString("dd MMMM yyyy")
                .MenuAkses()
                .loadInfoPanel()
                setperiode(Today, False)
                currentperiode = selectperiode
                .Visible = True
                .Opacity = 100
            End With
            AppClosing = False
            Me.Close()
        End If
    End Sub

    Private Async Function ckDBLock() As Task(Of KeyValuePair(Of Boolean, String))
        Dim q As String = "SELECT var_value FROM system_var WHERE var_name='sysLock'; " _
                          & "SELECT IFNULL(var_value,'Ditutup') FROM system_var WHERE var_name='sysLockMessage'"
        Dim _sysLock As Boolean = False
        Dim _msg As String = ""

        Try
            Using x As MySqlThing = MainConnection
                Await x.OpenAsync()
                If x.Connection.State = ConnectionState.Open Then
                    Using rdx As MySql.Data.MySqlClient.MySqlDataReader = Await x.ReadCommandAsync(q)
                        rdx.Read()
                        If rdx.HasRows Then
                            _sysLock = IIf(rdx.Item(0) = 1, True, False)
                            If _sysLock Then
                                If rdx.NextResult() And rdx.Read() Then _msg = rdx.Item(0)
                            End If
                        Else
                            _sysLock = Nothing
                            _msg = "Terjadi kesalahan saat melakukan konfigurasi sistem." & Environment.NewLine & "Applikasi akan ditutup."
                        End If
                    End Using
                End If
            End Using
        Catch ex As Exception
            logError(ex, True)
            _sysLock = Nothing
            _msg = "Error : Terjadi kesalahan saat melakukan konfigurasi sistem. " & ex.Message & Environment.NewLine & "Applikasi akan ditutup."
        End Try

        Return New KeyValuePair(Of Boolean, String)(_sysLock, _msg)
    End Function

    Public Function getServerDate() As Date
        Dim _retval As Date = Today
        Dim q As String = "SELECT CURDATE()"
        Dim x As MySqlThing = MainConnection

        x.Open()
        Try
            Using rdx As MySql.Data.MySqlClient.MySqlDataReader = x.ReadCommand(q, CommandBehavior.SingleResult)
                rdx.Read() : If rdx.HasRows Then _retval = CDate(rdx.Item(0)) : rdx.Close()
            End Using
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
        _tmer_ckLock.Stop()

        _tmer_ckLock_Tick(Nothing, Nothing)
        AddHandler _tmer_ckLock.Tick, AddressOf _tmer_ckLock_Tick
        _tmer_ckLock.Start()
    End Sub

    'UI : CLOSE
    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_close.PerformClick()
    End Sub

    Private Sub bt_mnz_Click(sender As Object, e As EventArgs) Handles bt_mnz.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub fr_login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'If Not SkipCloseDialog Then
        '    If MessageBox.Show("Tutup Aplikasi?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
        '        e.Cancel = True
        '    Else
        If AppClosing Then
            main.isForcedClose = True
            Application.Exit()
        End If
        '    End If
        'End If
    End Sub

    'UI : BUTTON
    Private Async Sub bt_login_Click(sender As Object, e As EventArgs) Handles bt_login.Click
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

        Await call_login()
    End Sub

    Private Sub bt_switch_Click(sender As Object, e As EventArgs) Handles bt_switch.Click
        With bt_switch
            If pass_switch = True Then
                .BackgroundImage = Global.Inventory.My.Resources.Resources.hide_password
                pass_switch = False
                in_pass.UseSystemPasswordChar = False
                hssssss.SetToolTip(bt_switch, "Hide Password")
            Else
                .BackgroundImage = Global.Inventory.My.Resources.Resources.show_password
                pass_switch = True
                in_pass.UseSystemPasswordChar = True
                hssssss.SetToolTip(bt_switch, "Show Password")
            End If
        End With
        in_pass.Focus()
    End Sub

    'UI : INPUT
    Private Async Sub in_user_KeyDown(sender As Object, e As KeyEventArgs) Handles in_user.KeyDown
        If e.KeyCode = Keys.Enter Then
            If in_pass.Text = Nothing Then
                If e.KeyCode = Keys.Enter Then
                    e.SuppressKeyPress = True
                    in_pass.Focus()
                End If
            Else
                Await call_login()
            End If
        End If
    End Sub

    Private Async Sub in_pass_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pass.KeyDown
        If e.KeyCode = Keys.Enter Then
            If in_user.Text = Nothing Then
                If e.KeyCode = Keys.Enter Then
                    e.SuppressKeyPress = True
                    in_user.Focus()
                End If
            Else
                Await call_login()
            End If
        End If
    End Sub

    'UI : OTHER
    Private Async Sub _tmer_ckLock_Tick(sender As Object, e As EventArgs)
        _tmer_ckLock.Stop()
        Dim x = Await ckDBLock()
        If (x.Key = True Or x.Key = Nothing) And x.Key <> False Then
            MessageBox.Show(x.Value, Me.Text, MessageBoxButtons.OK, IIf(x.Key = True, MessageBoxIcon.Warning, MessageBoxIcon.Error))
            main.isForcedClose = True
            Application.Exit()
        Else
            _tmer_ckLock.Start()
        End If
    End Sub
End Class