Module mdlAccount
    Public Function creatGenLed(tipe As String, kode As String, tgl As Date) As Boolean
        Dim res As Boolean = False

        Return res
    End Function

    Private Function inputLine(kode As String, tipeTrans As String)
        Dim q As String = "INSERT INTO data_jurnal_line SET line_trans='{0}',{1},{2} ON DUPLICATE KEY UPDATE {1},{2}"
        Dim data1 As String()
        Dim ret As Boolean = False

        Try
            tipeTrans = UCase(tipeTrans)
            Select Case tipeTrans
                Case "BELI"

                Case Else
                    ret = False
            End Select
        Catch ex As Exception
            consoleWriteLine(ex.Message)
            ret = False
        End Try

        Return ret
    End Function

    Private Sub inputJurnal(kode As String, jumlahPerk As Integer, listPerk As List(Of String), listDebet As List(Of String), listKredit As List(Of String), userid As String)


    End Sub
End Module
