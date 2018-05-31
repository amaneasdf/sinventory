Module mdl_login
    Public loggeduser As userdata
    Private salahlogin As Integer = 3

    Public Function checkuser(id As String, pass As String) As Boolean
        Return checkdata("data_pengguna_alias","'" & id & "' AND user_pwd=MD5('" & pass & "')", "user_alias")
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

    Private Sub logUser()
        op_con()
        With loggeduser
            Console.WriteLine(.user_id)
            Console.WriteLine(.user_host)
            Console.WriteLine(.user_ip)
            Console.WriteLine(.user_nama)
            Console.WriteLine(.user_ver)
            Console.WriteLine(.user_mac)
        End With

        With loggeduser
            commnd("INSERT INTO log_login SET log_tanggal = NOW(), log_reg = CURDATE(), log_user = '" & .user_id & "', log_nama = '" & .user_nama & "', log_ip = '" & .user_ip & "', log_komputer = '" & .user_host & "', log_mac = '" & .user_mac & "', log_versi = '" & .user_ver & "'")
        End With

    End Sub

    Private Sub updateUserLogin()
        op_con()
        commnd("UPDATE data_pengguna_alias SET user_login_terakhir=NOW(), user_login_device='" & loggeduser.user_host & ":" & loggeduser.user_ip & "', user_login_status='1' WHERE user_alias='" & loggeduser.user_id & "'")
    End Sub

    Public Sub do_login(id As String, pass As String)
        op_con()
        If checkuser(id, pass) = False Then
            MessageBox.Show("Username atau Password ada yang salah !")
            salahlogin -= 1
            If salahlogin = 0 Then
                MessageBox.Show("Anda telah 3x salah login, aplikasi akan ditutup!")
                Application.Exit()
            Else
                Exit Sub
            End If
        Else
            readcommd("select user_group,user_nama,user_exp_date from data_pengguna_alias where user_alias='" & id & "'")

            Dim cek As Integer = cekuserexpired(rd.Item("user_exp_date"))
            If cek = 1 Then
                MessageBox.Show("Password anda expired, Aplikasi akan ditutup")
                Application.Exit()
            ElseIf cek = 2 Then
                MessageBox.Show("Password anda 7 hari lagi expired")
            End If
            With loggeduser
                .user_id = id
                .user_lev = rd.Item("user_group")
                .user_nama = rd.Item("user_nama")
                .user_host = System.Net.Dns.GetHostName()
                .user_ip = GetIPv4Address()
                .user_mac = GetMac(.user_ip)
                .user_ver = "0.0.1"
            End With
            rd.Close()
            logUser()
            updateUserLogin()
            main.strip_user.Text = loggeduser.user_id.ToString
            main.strip_tgl.Text = System.DateTime.Today.ToString("dd MMMM yyyy")
            main.Visible = True
            main.MenuAkses()
            fr_login.clearLogin()
            fr_login.Dispose()
        End If
    End Sub

End Module
