Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_lap_stok
    Private Sub filldatatabel(query As String, dt As DataTable)
        op_con()
        Try
            Dim data_adpt As New MySqlDataAdapter(query, getConn)
            data_adpt.Fill(dt)
            data_adpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try
        cl_con()
    End Sub

    Private Sub bt_viewrep_Click(sender As Object, e As EventArgs) Handles bt_viewrep.Click
        Dim query As String = "viewStock('" & selectedperiode.ToString("yyyy-MM-dd") & "')"
        ds_stock.dt_persediaan.Clear()
        Dim parUserId As New ReportParameter("parUserId", loggeduser.user_id)
        filldatatabel(query, ds_stock.dt_persediaan)
        With Me.rv_stock
            .LocalReport.SetParameters(New ReportParameter() {parUserId})
            .RefreshReport()
            .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            .ZoomMode = 2
            .ZoomPercent = 100
        End With
    End Sub

    Private Sub fr_lap_stok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        date_tgl_awal.Value = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
        date_tgl_akhir.Value = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, -1)
    End Sub
End Class
