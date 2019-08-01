Module mdl_login
    Public loggeduser As New UserData
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
        'Dim _ip, _host, _mac As String
        Dim _sesid As String = ""

        Try
            Using x As MySqlThing = MainConnection
                x.Open()
                q = "SELECT user_login_status FROM data_pengguna_alias WHERE user_alias='{0}' AND user_pwd='{1}' AND user_status<>9 AND user_pc=1"
                Using rdx As MySql.Data.MySqlClient.MySqlDataReader = x.ReadCommand(String.Format(q, id, computeHash(pass)), CommandBehavior.SingleRow)
                    rdx.Read()
                    If rdx.HasRows Then
                        _logState = rdx.Item(0)
                        _retval = IIf(_logState = 1, ckUserRes.Used, ckUserRes.Valid)
                    Else
                        _retval = ckUserRes.Invalid
                    End If
                End Using
                q = "SELECT log_ip, log_komputer, log_mac FROM system_login_log WHERE log_user='{0}' AND log_status=0 " _
                    & "ORDER BY log_tanggal DESC LIMIT 1"

            End Using
        Catch ex As Exception
            logError(ex, True)
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

    Public Async Function updateUserLogin() As task
        Dim q As String = ""
        Using x As MySqlThing = MainConnection
            Dim _tsk As Task = x.OpenAsync()
            Await _tsk
            If _tsk.IsFaulted Then
                Throw New Exception("Terjadi kesalahan saat melakukan pengiriman data login user", _tsk.Exception)
            ElseIf _tsk.IsCompleted And x.Connection.State = ConnectionState.Open Then
                q = "UPDATE data_pengguna_alias SET user_login_terakhir=NOW(), user_login_last_session='{0}', user_login_status='1' WHERE user_alias='{1}'"
                Dim r = Await x.ExecCommandAsync(String.Format(q, loggeduser.user_session, loggeduser.user_id))
                'If r <= 0 Then
                '    Throw New Exception("Data login user tidak tersimpan")
                'End If
            End If
        End Using
    End Function

    Public Function do_login(id As String, pass As String) As String
        Dim _retval As String = 0
        Dim q As String = ""
        Dim _ckUser As ckUserRes = checkuser(id, pass)

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
            Using x As MySqlThing = MainConnection
                x.Open()
                q = "SELECT user_nama, user_group,user_allowedit_master, user_allowedit_trans, user_allowedit_akun, user_validasi_master, " _
                    & "user_validasi_trans, user_validasi_akun, user_admin_pc, user_status " _
                    & "FROM data_pengguna_alias WHERE user_alias='{0}'"
                Using rdx As MySql.Data.MySqlClient.MySqlDataReader = x.ReadCommand(String.Format(q, id), CommandBehavior.SingleRow)
                    rdx.Read()
                    If rdx.HasRows Then
                        'cek ststus user -> setup, aktif, nonaktif/block
                        Dim user_stat As String = rdx.Item("user_status")
                        If user_stat = "0" Then
                            MessageBox.Show("Password Akun anda baru saja direset, Harap ganti password anda")
                        ElseIf user_stat <> "1" Then
                            MessageBox.Show("Akun anda terblokir, Aplikasi akan ditutup")
                            Return 9
                            Exit Function
                        End If
                        With loggeduser
                            .user_id = id
                            .user_nama = rdx.Item("user_nama")
                            .user_lev = rdx.Item("user_group")
                            .allowedit_transact = IIf(rdx.Item("user_allowedit_trans") = 1, True, False)
                            .allowedit_master = IIf(rdx.Item("user_allowedit_master") = 1, True, False)
                            .allowedit_akun = IIf(rdx.Item("user_allowedit_akun") = 1, True, False)
                            .validasi_master = IIf(rdx.Item("user_validasi_master") = 1, True, False)
                            .validasi_trans = IIf(rdx.Item("user_validasi_trans") = 1, True, False)
                            .validasi_akun = IIf(rdx.Item("user_validasi_akun") = 1, True, False)
                            .admin_pc = IIf(rdx.Item("user_admin_pc") = 1, True, False)
                        End With
                    End If
                End Using
            End Using
        End If

        salahlogin = 3
        Return 1
    End Function

    Public Function resetPassUser(uid As String) As Boolean
        Dim qArr As New List(Of String)
        Dim q As String = ""
        Dim qCk As Boolean = False

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                If MsgBox("Apakah yakin akan mereset password user anda?", MsgBoxStyle.YesNo, "Reset Password") = MsgBoxResult.Yes Then
                    q = "UPDATE data_pengguna_alias SET user_pwd = '{2}', user_status=0, user_upd_date=NOW(), user_upd_alias='{1}' WHERE user_alias = '{0}'"
                    qArr.Add(String.Format(q, uid, loggeduser.user_id, computeHash("123456")))

                    q = "INSERT INTO system_pwdchange_log(log_alias1, log_alias2, log_ip, log_mac, log_session, log_tanggal, log_time) VALUE({0})"
                    Dim _d = {"'" & uid & "'", "'" & loggeduser.user_id & "'",
                              "'" & loggeduser.user_ip & "'", "'" & loggeduser.user_mac & "'",
                              "'" & loggeduser.user_session & "'", "CURDATE()", "NOW()"}
                    qArr.Add(String.Format(q, String.Join(",", _d)))

                    qCk = x.TransactCommand(qArr)
                    If qCk Then
                        MessageBox.Show("Password telah direset, password defaultnya: 123456 ", "Data User", MessageBoxButtons.OK)
                    Else
                        MessageBox.Show("Telah terjadi kesalahan. Password gagal direset.", "Data User", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    Return qCk
                Else
                    Return False
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Using
    End Function

    Public Function getDataUser(ByVal uid As String, Optional ByRef Msg As String = "") As UserData
        Dim xx As New UserData With {.user_id = uid}
        Dim q As String = ""
        q = "SELECT user_nama, user_group,user_allowedit_master, user_allowedit_trans, user_allowedit_akun, user_validasi_master, " _
            & "user_validasi_trans, user_validasi_akun, user_admin_pc, user_status " _
            & "FROM data_pengguna_alias WHERE user_alias='{0}'"

        Return xx
    End Function
End Module
