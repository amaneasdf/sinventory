Module mdlLogging
    'CONSOLE WRITING
    Public Sub consoleWriteLine(text As String)
        If log_switch.log_c_w = True Then
            Console.WriteLine(text)
        End If
    End Sub

    'LOG LOGIN
    Public Sub logUser(tipe As String)
        Dim q As String = ""

        If log_switch.log_login = False Then
            Exit Sub
        End If

        op_con()
        Select Case LCase(tipe)
            Case "login"
                Dim datauser() As String = {"NOW()", "'" & loggeduser.user_id & "'", "'" & loggeduser.user_ip & "'", "'" & loggeduser.user_host & "'",
                                            "'" & loggeduser.user_mac & "'", "'" & loggeduser.user_ver & "'"}

                q = "UPDATE system_login_log SET log_status=1 WHERE log_user='{0}' AND log_status=0"
                commnd(String.Format(q, loggeduser.user_id))

                q = "INSERT INTO system_login_log(log_tanggal,log_user,log_ip,log_komputer,log_mac,log_versi) VALUE({0})"
                commnd(String.Format(q, String.Join(",", datauser)))

                q = "SELECT MAX(log_id) FROM system_login_log WHERE log_user='{0}' AND log_status=0"
                readcommd(String.Format(q, loggeduser.user_id))
                If rd.HasRows Then
                    loggeduser.user_session = rd.Item(0)
                End If
                rd.Close()

            Case Else
                Exit Sub
        End Select
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

        'INNER_EXCEPTION
        If IsNothing(_ie) = False Then
            _stringtemp = "ERR_IE:{0}--{1}"
            er.Add(String.Format(_stringtemp, _ie.Message, _ie.TargetSite))
            _stringtemp = "--IE_ST_TRACE:{0}{1}"
            er.Add(String.Format(_stringtemp, Environment.NewLine, encryptString(_ie.StackTrace)))
        End If

        errLog(er)

        If skipMsg = False Then
            MessageBox.Show("Error has been occured" & Environment.NewLine & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Module
