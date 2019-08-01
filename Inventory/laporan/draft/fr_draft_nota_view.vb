Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_draft_nota_view
    Public kodedraft As String = ""

    Private Sub filldatatabel(query As String, dt As DataTable)
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    Dim data_adpt As New MySqlDataAdapter(query, x.Connection)
                    data_adpt.Fill(dt)
                    data_adpt.Dispose()
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                    logError(ex, True)
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End Using
    End Sub

    Private Sub fr_draft_barang_view_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "viewDraft('" & kodedraft & "','header')"
        Dim query2 As String = "viewDraft('" & kodedraft & "','notadetail')"

        ds_transaksi.dt_rekap_barang_detail.Clear()
        ds_transaksi.dt_rekap_barang.Clear()
        filldatatabel(query, ds_transaksi.dt_rekap_barang)
        filldatatabel(query2, ds_transaksi.dt_rekap_nota_detail)
        Dim parUserId As New ReportParameter("parUserId", loggeduser.user_id)
        With Me.rv_draft_barang
            .LocalReport.SetParameters(New ReportParameter() {parUserId})
            .RefreshReport()
            .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            .ZoomMode = 2
            .ZoomPercent = 100
        End With
    End Sub

    Private Sub rv_draft_barang_PrintingBegin(sender As Object, e As ReportPrintEventArgs) Handles rv_draft_barang.PrintingBegin
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = "UPDATE data_draft_faktur SET draft_printstatus_nota='Y' WHERE draft_kode='{0}' AND draft_status<9"
                Try
                    x.ExecCommand(String.Format(q, kodedraft))
                    DoRefreshTab_v2({pgdraftrekap})
                Catch ex As Exception
                    logError(ex, True)
                End Try
            End If
        End Using
    End Sub
End Class