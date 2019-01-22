Module mdl_login
    Public loggeduser As userdata
    Private salahlogin As Integer = 3
    Private Enum ckUserRes
        Valid
        Invalid
        Used
        Undefined
    End Enum

    Private Function checkuser(id As String, pass As String) As ckUserRes
        Dim q As String = ""
        Dim _retval As ckUserRes = ckUserRes.Undefined
        Dim _logState As String = ""
        Dim _ip, _host, _mac As String
        Dim _sesid As String = ""

        op_con()
        Try
            q = "SELECT user_login_status FROM data_pengguna_alias WHERE user_alias='{0}' AND user_pwd='{1}' AND user_status<>9 AND user_pc=1"
            readcommd(String.Format(q, id, computeHash(pass)))
            If rd.HasRows Then
                _logState = rd.Item(0)
                _retval = IIf(_logState = 1, ckUserRes.Used, ckUserRes.Valid)
            Else
                _retval = ckUserRes.Invalid
            End If
            rd.Close()

            q = "SELECT log_ip, log_komputer, log_mac FROM system_login_log WHERE log_user='{0}' AND log_status=0 " _
                & "ORDER BY log_tanggal DESC LIMIT 1"
            'If _logState = 1 Then
            '    readcommd(String.Format(q, id))
            '    If rd.HasRows Then

            '    End If
            'End If
        Catch ex As Exception
            logError(ex, True)
        Finally
            Try
                If rd.IsClosed = False Then
                    rd.Close()
                End If
            Catch ex As Exception
                logError(ex, True)
                _retval = ckUserRes.Undefined
            End Try
        End Try

        Return _retval
        'Return checkdata("data_pengguna_alias", "'" & id & "' AND user_pwd='" & computeHash(pass) & "' AND user_status <> 9 AND user_pc=1", "user_alias")
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
        Dim q As String = ""
        op_con()
        q = "UPDATE data_pengguna_alias SET user_login_terakhir=NOW(), user_login_last_session='{0}', user_login_status='1' WHERE user_alias='{1}'"
        commnd(String.Format(q, loggeduser.user_session, loggeduser.user_id))
    End Sub

    Public Function do_login(id As String, pass As String) As String
        Dim _retval As String = 0
        Dim q As String = ""
        Dim _ckUser As ckUserRes = checkuser(id, pass)

        op_con()
        If _ckUser = ckUserRes.Invalid Then
            MessageBox.Show("Username/Password yang dimasukan salah", "Login " & Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            salahlogin -= 1
            If salahlogin = 0 Then
                MessageBox.Show("Anda telah 3x salah login, aplikasi akan ditutup!", "Login " & Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'set user status to blocked
                Return 9
                Exit Function
            Else
                Return 0
                Exit Function
            End If
        ElseIf _ckUser = ckUserRes.Undefined Then
            MessageBox.Show("Error : Terjadi kesalahan saat mengambil data user.", "Login " & Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
            Exit Function
            'ElseIf _ckUser = ckUserRes.Used Then
            '    'ret user being used on other device or not logged out correctly info msg
        Else
            'cek ststus user -> setup, aktif, nonaktif/block
            q = "SELECT user_nama, user_group,user_allowedit_master, user_allowedit_trans, user_allowedit_akun, user_validasi_master, " _
                & "user_validasi_trans, user_validasi_akun, user_admin_pc, user_status " _
                & "FROM data_pengguna_alias WHERE user_alias='{0}'"
            readcommd(String.Format(q, id))
            If rd.HasRows Then
                Dim user_stat As String = rd.Item("user_status")
                If user_stat <> "1" Then
                    If user_stat = "2" Then
                        'open set pass form
                        MessageBox.Show("Password Akun anda baru saja direset, Harap ganti password anda")
                    Else
                        MessageBox.Show("Akun anda terblokir, Aplikasi akan ditutup")
                        rd.Close()
                        Return 9
                        Exit Function
                    End If
                End If
                With loggeduser
                    .user_id = id
                    .user_nama = rd.Item("user_nama")
                    .user_lev = rd.Item("user_group")
                    .allowedit_transact = IIf(rd.Item("user_allowedit_trans") = 1, True, False)
                    .allowedit_master = IIf(rd.Item("user_allowedit_master") = 1, True, False)
                    .allowedit_akun = IIf(rd.Item("user_allowedit_akun") = 1, True, False)
                    .validasi_master = IIf(rd.Item("user_validasi_master") = 1, True, False)
                    .validasi_trans = IIf(rd.Item("user_validasi_trans") = 1, True, False)
                    .validasi_akun = IIf(rd.Item("user_validasi_akun") = 1, True, False)
                    .admin_pc = IIf(rd.Item("user_admin_pc") = 1, True, False)
                    .user_host = System.Net.Dns.GetHostName()
                    .user_ip = GetIPv4Address()
                    .user_mac = GetMac(.user_ip)
                    .user_ver = Application.ProductVersion
                End With

            End If
            rd.Close()

            If loggeduser.user_id <> Nothing Then
                logUser("login")
                updateUserLogin()
            End If

            salahlogin = 3
            Return 1
        End If
    End Function

    Public Function resetUser(uid As String) As Boolean
        Dim _retval As Boolean = False
        Dim _qresult As Boolean = False
        Dim q As String = ""

        op_con()
        Try
            q = "UPDATE data_pengguna_alias SET user_password ='{1}', user_exp_date=DATE_ADD(CURDATE(),INTERVAL 3 MONTH), user_status=2 " _
                & " WHERE user_alias = '{0}'"
            _qresult = commnd(String.Format(q, uid, computeHash("123456")))

            If _qresult = True Then
                q = "SELECT user_status FROM data_pengguna_alias WHERE user_alias='{0}'"
                readcommd(String.Format(q, uid))
                If rd.HasRows Then
                    _qresult = IIf(rd.Item(0) = 2, True, False)
                Else
                    _qresult = False
                End If
            End If

            _retval = _qresult
        Catch ex As Exception
            logError(ex, True)
            _retval = False
        End Try

        Return _retval
    End Function
End Module
