Module mdlLogging
    'CONSOLE WRITING
    Public Sub consoleWriteLine(text As String)
        If log_switch.log_c_w Then Console.WriteLine(text)
    End Sub


    'LOG VALIDASI
    Public Sub LogValidTrans(UserValid As String,
                             LoggedUser As UserData,
                             TransType As String, InputType As String,
                             IDTrans As String,
                             Optional ByRef ReturnID As Integer = 0)
        Dim q As String = ""
        'If log_switch.log_valid = False Then Exit Sub
        Try
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim _val() = {LoggedUser.User_Alias, LoggedUser.User_Session, UserValid, TransType, InputType, IDTrans}
                    For i = 0 To _val.Length - 1
                        _val(i) = "'" & _val(i) & "'"
                    Next

                    q = "SELECT Log_Validasi({0})" : q = String.Format(q, String.Join(",", _val))

                    'ReturnID = Integer.Parse(x.ExecScalar(q))
                Else
                    Throw New Exception("Cannot connect to database.")
                End If
            End Using
        Catch ex As Exception
            ReturnID = -1 :
            LogError(ex)
        End Try
    End Sub

    'LOG ERROR
    Public Sub LogError(ex As Exception, SkipMsg As Boolean)
        LogError(ex)
    End Sub

    Public Sub LogError(ex As Exception)
        Dim _ErrorListStr As New List(Of String)
        Dim _Exe As Exception = ex
        Dim _filename As String = "LOG_ERROR" & Today.ToString("yyyyMMdd") & ".log"
        Dim _ct As Integer = 0

        While Not IsNothing(_Exe)
            If _ct = 0 Then
                _ErrorListStr.Add(String.Format("{0:yyyyMMdd-hhmmss}:ERROR:{1}", Now, _Exe.Message))
            Else
                _ErrorListStr.Add(String.Format("IE_{0}:{1}", _ct, _Exe.Message))
            End If
            _ErrorListStr.Add(String.Format("--{0}:{1}", _Exe.GetType, _Exe.TargetSite))
            _ErrorListStr.Add(String.Format("--ST_TRACE:{0}", _Exe.StackTrace))

            If IsNothing(_Exe.InnerException) Then
                Exit While
            Else
                _Exe = _Exe.InnerException : _ct += 1
            End If
        End While

        'WRITE LOG FILE
        CreateTextFile(AppDir_Document & "log\", _filename, _ErrorListStr, True)
        'INSERT LOG TO DB
        'HERE
    End Sub
End Module
