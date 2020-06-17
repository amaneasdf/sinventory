Public Class fr_login
    Private pass_switch As Boolean = True
    Private tglkom As Date = System.DateTime.Today
    Private _tmer_ckLock As New Timer With {.Interval = 7500}
    Public AppClosing As Boolean = True

    'STYLE
    Private m_aeroEnabled As Boolean = False
    Private Const CS_DROPSHADOW As Int32 = &H20000
    Private Const WM_NCPAINT As Int32 = 133
    Private Const WM_ACTIVATEAPP As Int32 = 28

    Private Const WM_NCHITTEST As Int32 = &H84
    Private Const HTCLIENT As Int32 = &H1
    Private Const HTCAPTION As Int32 = &H2

    'DROP SHADOW
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            m_aeroEnabled = CheckAeroEnabled()

            Dim parameters As CreateParams = MyBase.CreateParams
            If Not m_aeroEnabled Then parameters.ClassStyle += CS_DROPSHADOW
            Return parameters
        End Get
    End Property

    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case WM_NCPAINT
                If m_aeroEnabled Then
                    Dim v = 2
                    DwmSetWindowAttribute(Me.Handle, 2, v, 4)
                    Dim margins As New Margins With {
                        .bottomHeight = 1,
                        .leftWidth = 0,
                        .rightWidth = 0,
                        .topHeight = 0
                        }
                    DwmExtendFrameIntoClientArea(Me.Handle, margins)
                End If
        End Select
        MyBase.WndProc(m)
        If (m.Msg = WM_NCHITTEST AndAlso m.Result.ToInt32 = HTCLIENT) Then m.Result = HTCAPTION
    End Sub

    'LOAD FORM
    Public Sub do_load()
        Try
            'SET FROM
            lbl_judul.Text = Application.ProductName
            lbl_subtitle.Text = My.Application.Info.Description
            in_pass.UseSystemPasswordChar = True

            Me.Text = "Login" & Application.ProductName
            Me.Opacity = 0

            'CHECK APPLICATION/SYSTEM STATUS
            Dim _respMsg As String = ""
            If CheckAppVer(_respMsg) Then
                If CheckAppLock(_respMsg) Then GoTo ShowMsgBox
                Me.Show()
            Else
ShowMsgBox:
                If Not String.IsNullOrWhiteSpace(_respMsg) Then MessageBox.Show(_respMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                main.isForcedClose = True : Application.Exit()
            End If
        Catch ex As Exception
            logError(ex)
            main.isForcedClose = True : Application.Exit()
        End Try
    End Sub

    Private Sub fr_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 100
    End Sub

    'CHECK VERSION AND SYSTEM STATUS
    'VERSION CHECK
    Private Function CheckAppVer(ByRef Msg As String) As Boolean
        Try
            Dim _LatestVer, _URL, _Crit As String
            _LatestVer = GetSettingFromDB("AppVersion").ToString
            _URL = GetSettingFromDB("UpdateURL").ToString
            _Crit = GetSettingFromDB("UpdateCritical").ToString

            If String.IsNullOrWhiteSpace(_LatestVer) Then Throw New ArgumentNullException("_LatesVer", "Parameter versi aplikasi pada database kosong")

            If _LatestVer > Application.ProductVersion Then
                Dim _rsp = MessageBox.Show("Versi terbaru " & Application.ProductName & " telah tersedia di " & _URL & "." _
                                           & Environment.NewLine & "Silahkan download versi terbaru terlebih dahulu.",
                                           Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                If _rsp = Windows.Forms.DialogResult.OK Then
                    If String.IsNullOrWhiteSpace(_URL) Then Throw New ArgumentNullException("_URL", "Parameter URL update aplikasi pada database kosong")

                    NavigateWebURL(_URL)
                    Return False
                Else
                    If UCase(_Crit) <> "FALSE" Then
                        Msg = "Demi kelancaran penggunaan program ini, harap melakukan update terlebih dahulu."
                        Return False
                    Else
                        Msg = "" : Return True
                    End If
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            LogError(ex) : Msg = "Terjadi kesalahan saat melakukan pengecekan versi." & Environment.NewLine & ex.Message
            Return False
        End Try
    End Function

    'CHECK SYSTEM LOCK STATUS
    Private Function CheckAppLock(ByRef LockMsg As String) As Boolean
        Dim _syslock = GetSettingFromDB("SystemLock").ToString
        Dim _sysmsg = GetSettingFromDB("SystemLockMsg").ToString
        If _syslock = "TRUE" Then
            LockMsg = _sysmsg : Return True
        Else
            Return False
        End If
    End Function

    'LOGIN PROCEDURE
    Private Structure LoginResult
        Dim Result As Boolean
        Dim Msg As String
        Dim MsgIcon As MessageBoxIcon
    End Structure

    Private Function DoLogin(UserAlias As String, Pwd As String) As LoginResult
        'CHECK USER
        Dim _Msg As String = "" : Dim _UserID As String = ""
        Dim _i As Integer = CheckUser(UserAlias, Pwd, _Msg, _UserID)
        Select Case _i
            Case 1 'IF OK
                loggeduser.User_Alias = UserAlias : Dim _ck = LogLogin(loggeduser)
                Return New LoginResult With {.Result = _ck.Key, .Msg = _ck.Value, .MsgIcon = If(Not _ck.Key, MessageBoxIcon.Warning, MessageBoxIcon.None)}
            Case 0, 2
                'IF NOT FOUND OR USERNAME/PASS INVALID. 0 = NOT FOUND; 2 = INVALID
                Return New LoginResult With {.Result = False, .Msg = _Msg, .MsgIcon = MessageBoxIcon.Error}
            Case 10
                'IF ERROR OCCURED IN LOGIN PROCESS
                Return New LoginResult With {.Result = False,
                                             .Msg = "Terjadi kesalahan saat melakukan pengecekan data user." & Environment.NewLine & _Msg,
                                             .MsgIcon = MessageBoxIcon.Error}
            Case Else
                'IF RETURN DOESNT MEET CATEGORIES
                LogError(New Exception("User checking function returning different integer from determined categories. (" & _i & ")"))
                Return New LoginResult With {.Result = False, .Msg = "Terjadi kesalahan saat melakukan pengecekan data user.", .MsgIcon = MessageBoxIcon.Error}
        End Select
    End Function

    'LOAD/SHOW MAIN WINDOW
    Private Sub OpenMainWindow()
        _tmer_ckLock.Stop()
        If LoggedUser.IsEmpty Then
            MessageBox.Show("Tidak dapat mengambil data user.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            main.isForcedClose = True
            Application.Exit()
        Else
            With main
                .Do_LoadControl()
                .Visible = True
                .Opacity = 100
            End With
            AppClosing = False
            Me.Close()
        End If
    End Sub

    'DRAG FORM
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles pnl_main.MouseDown, lbl_judul.MouseDown, lbl_subtitle.MouseDown, pbx_logo.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles pnl_main.MouseMove, lbl_judul.MouseMove, lbl_subtitle.MouseMove, pbx_logo.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles pnl_main.MouseUp, lbl_judul.MouseUp, lbl_subtitle.MouseUp, pbx_logo.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub pnl_DoubleClick(sender As Object, e As EventArgs) Handles pnl_main.DoubleClick, lbl_judul.DoubleClick, lbl_subtitle.DoubleClick, pbx_logo.DoubleClick
        CenterToScreen()
    End Sub

    'UI : CLOSE
    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_close.PerformClick()
    End Sub

    Private Sub bt_mnz_Click(sender As Object, e As EventArgs) Handles bt_mnz.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_close.Click
        main.isForcedClose = True
        Me.Close()
    End Sub

    Private Sub fr_login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If AppClosing Then
            'main.isForcedClose = True
            Application.Exit()
        End If
    End Sub

    'UI : BUTTON
    Private Async Sub bt_login_Click(sender As Object, e As EventArgs) Handles bt_login.Click
        'CHECK INPUT DATA
        For Each x As TextBox In {in_user, in_pass}
            Dim Msg As String = "Masukkan {0} terlebih dahulu."
            Select Case x.Name
                Case in_user.Name : Msg = String.Format(Msg, "UserID")
                Case in_pass.Name : Msg = String.Format(Msg, "Password")
                Case Else : Exit Sub
            End Select

            If String.IsNullOrWhiteSpace(x.Text) Then
                MessageBox.Show(Msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                x.Focus() : Exit Sub
            End If
        Next

        'CHECK APPLICATION/SYSTEM STATUS
        Dim _msg As String = ""
        If CheckAppLock(_msg) Then
            MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            in_user.Focus() : Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim _ctr() As Control = {in_user, in_pass, bt_login, bt_switch}
        For Each ctr As Control In _ctr : ctr.Enabled = False : Next
        Dim _ck = Await Task.Run(Function() DoLogin(in_user.Text, in_pass.Text))
        If _ck.Result Then
            OpenMainWindow()
        Else
            MessageBox.Show(_ck.Msg, Me.Text, MessageBoxButtons.OK, _ck.MsgIcon)
        End If
        For Each ctr As Control In _ctr : ctr.Enabled = True : Next
        Me.Cursor = Cursors.Default
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
    Private Sub in_user_KeyDown(sender As Object, e As KeyEventArgs) Handles in_user.KeyDown, in_pass.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim txt As TextBox = Nothing
            Select Case sender.Name
                Case in_user.Name : txt = in_pass
                Case in_pass.Name : txt = in_user
                Case Else : Exit Sub
            End Select

            e.SuppressKeyPress = True
            If String.IsNullOrWhiteSpace(txt.Text) Then
                txt.Focus()
            Else
                bt_login.PerformClick()
            End If
        End If
    End Sub
End Class