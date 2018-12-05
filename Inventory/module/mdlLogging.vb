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
        With loggeduser
            consoleWriteLine(.user_id)
            consoleWriteLine(.user_host)
            consoleWriteLine(.user_ip)
            consoleWriteLine(.user_nama)
            consoleWriteLine(.user_ver)
            consoleWriteLine(.user_mac)
        End With
        Try
            Select Case LCase(tipe)
                Case "login"
                    q = "INSERT INTO log_login SET {0}"
                    With loggeduser
                        commnd("INSERT INTO log_login SET log_tanggal = NOW(), log_reg = CURDATE(), log_user = '" & .user_id & "', log_nama = '" & .user_nama & "', log_ip = '" & .user_ip & "', log_komputer = '" & .user_host & "', log_mac = '" & .user_mac & "', log_versi = '" & .user_ver & "'")
                    End With
                Case Else
                    Exit Sub
            End Select

        Catch ex As Exception
            consoleWriteLine(ex.Message)
        End Try
    End Sub

    Public Sub logError(ex As Exception)
        Dim er As New List(Of String)
        Dim st As New StackTrace
        st = New StackTrace(ex, True)
        er.Add(String.Format("ERR:{0}:{1}{5}--{2}:{3}:{4}", Date.Now.ToString("yyyyMMdd-hhmmss"), ex.Message, st.GetFrame(st.FrameCount - 1).GetMethod, st.GetFrame(st.FrameCount - 1).GetFileLineNumber, ex.TargetSite.ToString, Environment.NewLine))
        errLog(er)
        MessageBox.Show("Error has been occured" & Environment.NewLine & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
End Module
