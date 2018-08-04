Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_draft_nota_view
    Public kodedraft As String = ""

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
End Class