Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_view_piutang
    Private inlap_type As String = ""
    Private inquery As String = ""
    Private inheadpar As String = ""

    'FILL VARIABLE VALUE/CONSTUCTOR
    Public Sub setVar(laptipe As String, query As String, Optional headerparam1 As String = "...")
        inlap_type = laptipe
        inquery = query
        inheadpar = headerparam1
    End Sub

    'FILL TEMP DATA TABLE
    Private Sub filldatatabel(query As String, dt As DataTable)
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    Dim data_adpt As New MySqlDataAdapter(query, x.Connection)
                    data_adpt.SelectCommand.CommandTimeout = 360
                    consoleWriteLine(query)
                    data_adpt.Fill(dt)
                    consoleWriteLine(dt.Rows.Count)
                    data_adpt.Dispose()
                Catch ex As Exception
                    MessageBox.Show(String.Format("Error: {0}", ex.Message))
                    logError(ex, True) : Me.Close()
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End Using
    End Sub

    Private Sub repViewerSelector(lap_type As String)
        Dim parUserId As New ReportParameter("parUserId", loggeduser.user_id)
        Dim parPeriode As New ReportParameter("parPeriode", inheadpar)
        Dim repdatasource, repdatasource1 As New ReportDataSource

        With Me.rv_nota
            With .LocalReport
                
                Select Case inlap_type
                    Case "h_nota"
                        repdatasource.Name = "ds_nota"
                        repdatasource.Value = ds_hutangpiutang.dt_hutang_nota

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.hutang_nota.rdlc"

                        ds_hutangpiutang.dt_hutang_nota.Clear()
                        filldatatabel(inquery, ds_hutangpiutang.dt_hutang_nota)

                    Case "p_salesnota"
                        repdatasource.Name = "ds_piutang_salesnota"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_sales_nota

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.piutang_salesnota.rdlc"

                        ds_hutangpiutang.dt_piutang_sales_nota.Clear()
                        filldatatabel(inquery, ds_hutangpiutang.dt_piutang_sales_nota)

                    Case "p_saleslengkap2", "h_notabeli"
                        repdatasource.Name = "ds_nota"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_sales_lengkap2

                        .DataSources.Add(repdatasource)
                        If LCase(lap_type) = "p_saleslengkap2" Then
                            .ReportEmbeddedResource = "Inventory.piutang_saleslengkap2.rdlc"
                        Else
                            .ReportEmbeddedResource = "Inventory.hutang_notabeli.rdlc"
                        End If

                        ds_hutangpiutang.dt_piutang_sales_lengkap2.Clear()
                        filldatatabel(inquery, ds_hutangpiutang.dt_piutang_sales_lengkap2)

                    Case "p_salesbayartanggal"
                        repdatasource.Name = "ds_piutang_salesbayar"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_sales_bayar

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.piutang_salesbayartanggal.rdlc"

                        ds_hutangpiutang.dt_piutang_sales_bayar.Clear()
                        filldatatabel(inquery, ds_hutangpiutang.dt_piutang_sales_bayar)

                    Case "p_titipancusto", "p_titipancusto_det", "h_titipsupplier", "h_titipsupplier_det"
                        repdatasource.Name = "ds_titipan"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_titip

                        .DataSources.Add(repdatasource)
                        If inlap_type = "p_titipancusto" Then
                            .ReportEmbeddedResource = "Inventory.piutang_titipcusto.rdlc"
                        ElseIf LCase(inlap_type) = "p_titipancusto_det" Then
                            .ReportEmbeddedResource = "Inventory.piutang_titipcusto_det.rdlc"
                        ElseIf LCase(inlap_type) = "h_titipsupplier" Then
                            .ReportEmbeddedResource = "Inventory.hutang_titipsupplier.rdlc"
                        Else
                            .ReportEmbeddedResource = "Inventory.hutang_titipsupplier_det.rdlc"
                        End If

                        ds_hutangpiutang.dt_piutang_titip.Clear()
                        filldatatabel(inquery, ds_hutangpiutang.dt_piutang_titip)

                    Case "p_kartupiutang", "p_kartupiutangsales", "h_kartuhutang"
                        Dim parTitleLaporan As New ReportParameter()

                        repdatasource.Name = "ds_piutang_kartupiutang"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_kartu

                        .DataSources.Add(repdatasource)
                        If inlap_type = "p_kartupiutang" Then
                            .ReportEmbeddedResource = "Inventory.piutang_kartupiutang.rdlc"
                            parTitleLaporan = New ReportParameter("parTitleLaporan", "Kartu Piutang")
                        ElseIf inlap_type = "p_kartupiutangsales" Then
                            .ReportEmbeddedResource = "Inventory.piutang_kartupiutangsales.rdlc"
                            parTitleLaporan = New ReportParameter("parTitleLaporan", "Kartu Piutang Per Sales")
                        Else
                            .ReportEmbeddedResource = "Inventory.hutang_kartuhutang.rdlc"
                            parTitleLaporan = New ReportParameter("parTitleLaporan", "Kartu Hutang")
                        End If
                        .SetParameters(New ReportParameter() {parTitleLaporan})

                        ds_hutangpiutang.dt_piutang_kartu.Clear()
                        filldatatabel(inquery, ds_hutangpiutang.dt_piutang_kartu)

                    Case "p_bayarnota", "h_bayarnota"
                        repdatasource.Name = "ds_piutang_bayardetail"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_bayardetail

                        .DataSources.Add(repdatasource)
                        If inlap_type = "p_bayarnota" Then
                            .ReportEmbeddedResource = "Inventory.piutang_detailbayar.rdlc"
                        Else
                            .ReportEmbeddedResource = "Inventory.hutang_detailbayar.rdlc"
                        End If

                        ds_hutangpiutang.dt_piutang_bayardetail.Clear()
                        filldatatabel(inquery, ds_hutangpiutang.dt_piutang_bayardetail)

                    Case "p_salesglobal"
                        repdatasource.Name = "ds_piutang_salesglobal"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_salesglobal

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.piutang_salesglobal.rdlc"

                        With ds_hutangpiutang
                            .dt_piutang_salesglobal.Clear()
                            filldatatabel(inquery, .dt_piutang_salesglobal)
                            consoleWriteLine(.dt_piutang_salesglobal.Rows.Count)
                        End With

                    Case "p_salesover2"
                        repdatasource.Name = "ds_piutang_sales"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_salesglobal

                        inquery = ""

                        Exit Sub
                    Case Else
                        Exit Sub
                End Select
                .SetParameters(New ReportParameter() {parUserId, parPeriode})
            End With
        End With
    End Sub

    Private Sub fr_view_nota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        repViewerSelector(inlap_type)
        With rv_nota
            .RefreshReport()
            .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            .ZoomMode = 2
            .ZoomPercent = 100
        End With
        Me.Cursor = Cursors.Default
    End Sub
End Class