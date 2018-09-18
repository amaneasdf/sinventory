Module mdlLogging
    'CONSOLE WRITING
    Public Sub consoleWriteLine(text As String)
        If log_switch.log_c_w = True Then
            Console.WriteLine(text)
        End If
    End Sub

    'LOG LOGIN
    Public Sub logUser()
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
            With loggeduser
                commnd("INSERT INTO log_login SET log_tanggal = NOW(), log_reg = CURDATE(), log_user = '" & .user_id & "', log_nama = '" & .user_nama & "', log_ip = '" & .user_ip & "', log_komputer = '" & .user_host & "', log_mac = '" & .user_mac & "', log_versi = '" & .user_ver & "'")
            End With
        Catch ex As Exception
            consoleWriteLine(ex.Message)
        End Try
    End Sub
End Module
