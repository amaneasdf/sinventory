Module mdlLogging
    'CONSOLE WRITING
    Public Sub consoleWriteLine(text As String)
        If log_switch.log_c_w = True Then
            Console.WriteLine(text)
        End If
    End Sub

    'LOG LOGIN
    Public Async Function logUser(tipe As String) As Task
        Dim q As String = ""

        If log_switch.log_login = False Then Exit Function

        Select Case LCase(tipe)
            Case "login"
                Dim datauser() As String = {"CURDATE()", "NOW()", "'" & loggeduser.user_id & "'", "'" & loggeduser.user_ip & "'", "'" & loggeduser.user_host & "'",
                                            "'" & loggeduser.user_mac & "'", "'" & loggeduser.user_ver & "'"}
                Using x As MySqlThing = MainConnection
                    Dim _tsk As Task = x.OpenAsync()

                    If _tsk.IsFaulted Then
                        Throw New Exception("Terjadi kesalahan saat melakukan prosedur log user", _tsk.Exception)
                    ElseIf _tsk.IsCompleted And x.Connection.State = ConnectionState.Open Then
                        q = "UPDATE system_login_log SET log_status=2 WHERE log_user='{0}' AND log_komputer='{1}' AND log_status=0"
                        Await x.ExecCommandAsync(String.Format(q, loggeduser.user_id, loggeduser.user_host))
                        q = "INSERT INTO system_login_log(log_tanggal, log_time, log_user,log_ip,log_komputer,log_mac,log_versi) VALUE({0})"
                        If Await x.ExecCommandAsync(String.Format(q, String.Join(",", datauser))) > 0 Then
                            q = "SELECT MAX(log_id) FROM system_login_log WHERE log_user='{0}' AND log_status=0"
                            Using rdx As MySql.Data.MySqlClient.MySqlDataReader = Await x.ReadCommandAsync(String.Format(q, loggeduser.user_id))
                                consoleWriteLine(String.Format(q, loggeduser.user_id))
                                If Await rdx.ReadAsync Then If rdx.HasRows Then loggeduser.user_session = rdx.Item(0)
                            End Using
                        End If
                    End If
                End Using
            Case Else
                Exit Function
        End Select
    End Function

    'LOG VALIDASI
    Public Sub LogValidTrans(UserValid As String, LoggedUser As String, TransType As String, InputType As String, IDTrans As String, Optional ByRef ReturnID As Integer = 0)
        Dim q As String = ""
        'If log_switch.log_valid = False Then Exit Function
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                q = "INSERT INTO system_valid_log() VALUE()"

            Else

            End If
        End Using
    End Sub

    'LOG ERROR
    Public Sub logError(ex As Exception, Optional skipMsg As Boolean = False)
        Dim er As New List(Of String)
        Dim _ie As Exception = ex.InnerException
        Dim _stringtemp As String = ""
        Dim _date As String = Date.Now.ToString("yyyyMMdd-hhmmss")

        'EXCEPTION
        _stringtemp = "ERR:{0}:{1}--{2}"
        er.Add(String.Format(_stringtemp, _date, ex.Message, ex.TargetSite))
        _stringtemp = "--ST_TRACE:{0}{1}"
        er.Add(String.Format(_stringtemp, Environment.NewLine, encryptString(ex.StackTrace)))
        consoleWriteLine(er.Item(0))

        'INNER_EXCEPTION
        If IsNothing(_ie) = False Then
            _stringtemp = "ERR_IE:{0}--{1}"
            er.Add(String.Format(_stringtemp, _ie.Message, _ie.TargetSite))
            _stringtemp = "--IE_ST_TRACE:{0}{1}"
            er.Add(String.Format(_stringtemp, Environment.NewLine, encryptString(_ie.StackTrace)))
            consoleWriteLine(er.Item(2))
        End If

        errLog(er)

        If skipMsg = False Then
            MessageBox.Show("Error has been occured" & Environment.NewLine & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Module
