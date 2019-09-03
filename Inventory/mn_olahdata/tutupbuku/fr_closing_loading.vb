Public Class fr_closing_loading
    Public ReturnValue As Boolean = False
    Private _IdClosing As Integer = 0
    Private _ValidUid As String = ""

    'Private Async Function AwaitTask() As Task(Of Boolean)
    '    Using x = MainConnection
    '        x.Open() : If x.ConnectionState = ConnectionState.Open Then
    '            Dim _q As String = ""
    '            Try
    '                _q = "CALL Closing_RevaluateHPPTransaksi_date('{0:yyyy-MM-dd}', '{1}')"
    '                Await x.ExecCommandAsync(String.Format(_q, DateSerial(2019, 3, 4), loggeduser.user_id))

    '                Return True
    '            Catch ex As Exception
    '                logError(ex, False)
    '                consoleWriteLine(ex.Message)
    '                Return False
    '            End Try
    '        Else
    '            Return False
    '        End If
    '    End Using
    'End Function

    'Private Async Sub fr_closing_loading_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    '    Dim x = AwaitTask()
    '    Await x
    '    If x.IsCompleted Then
    '        If x.Result Then Me.Close()
    '    End If
    'End Sub
End Class