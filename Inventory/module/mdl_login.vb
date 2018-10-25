Module mdl_login
    Public loggeduser As userdata
    Private salahlogin As Integer = 3

    Public Function checkuser(id As String, pass As String) As Boolean
        Return checkdata("data_pengguna_alias", "'" & id & "' AND user_pwd=MD5('" & pass & "') AND user_status <> 9", "user_alias")
    End Function

    Private Function cekuserexpired(tglExpUser As Date) As Integer
        Dim expired As Integer = 1
        'set tgl expired
        Dim tglexpired As Date = tglExpUser
        'cek expired
        If DateTime.Compare(tglexpired, System.DateTime.Today) < 0 Then
            expired = 1
        ElseIf DateTime.Compare(tglexpired, System.DateTime.Today.AddDays(-7)) = 0 Then
            expired = 2
        Else
            expired = 0
        End If

        Return expired
    End Function

    Private Sub updateUserLogin()
        op_con()
        commnd("UPDATE data_pengguna_alias SET user_login_terakhir=NOW(), user_login_device='" & loggeduser.user_host & ":" & loggeduser.user_ip & "', user_login_status='1' WHERE user_alias='" & loggeduser.user_id & "'")
    End Sub

    Public Sub do_login(id As String, pass As String)
        Dim q As String = ""

        op_con()
        If checkuser(id, pass) = False Then
            MessageBox.Show("Username atau Password salah !")
            salahlogin -= 1
            If salahlogin = 0 Then
                MessageBox.Show("Anda telah 3x salah login, aplikasi akan ditutup!")
                'set user status to blocked
                Application.Exit()
            Else
                Exit Sub
            End If
        Else
            'cek ststus user -> setup, aktif, nonaktif/block
            readcommd("SELECT user_status FROM data_pengguna_alias WHERE user_alias='" & id & "'")
            Dim user_stat As String = rd.Item("user_status")
            rd.Close()
            If user_stat <> "1" Then
                If user_stat = "2" Then
                    'open set pass form
                Else
                    MessageBox.Show("Akun anda terblokir, Aplikasi akan ditutup")
                    Application.Exit()
                End If
            End If

            q = "SELECT user_nama, user_group,user_allowedit_master, user_allowedit_trans, user_validasi_master, " _
                & "user_validasi_trans FROM data_pengguna_alias WHERE user_alias='{0}'"
            readcommd(String.Format(q, id))

            'Dim cek As Integer = cekuserexpired(rd.Item("user_exp_date"))
            'If cek = 1 Then
            '    MessageBox.Show("Password anda expired, Aplikasi akan ditutup")
            '    Application.Exit()
            'ElseIf cek = 2 Then
            '    MessageBox.Show("Password anda 7 hari lagi expired")
            'End If

            With loggeduser
                .user_id = id
                .user_nama = rd.Item("user_nama")
                .user_lev = rd.Item("user_group")
                .allowedit_master = IIf(rd.Item("user_allowedit_master") = 1, True, False)
                .allowedit_transact = IIf(rd.Item("user_allowedit_trans") = 1, True, False)
                .validasi_master = IIf(rd.Item("user_validasi_master") = 1, True, False)
                .validasi_trans = IIf(rd.Item("user_validasi_trans") = 1, True, False)
                .user_host = System.Net.Dns.GetHostName()
                .user_ip = GetIPv4Address()
                .user_mac = GetMac(.user_ip)
                .user_ver = "0.0.1"
            End With
            rd.Close()

            logUser("login")
            updateUserLogin()

            main.strip_user.Text = loggeduser.user_id.ToString
            main.strip_tgl.Text = System.DateTime.Today.ToString("dd MMMM yyyy")
            main.Visible = True
            main.Opacity = 100
            main.MenuAkses()
            fr_login.clearLogin()
            fr_login.Close()
        End If
    End Sub

End Module
