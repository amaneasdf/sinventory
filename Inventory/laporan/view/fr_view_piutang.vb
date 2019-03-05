Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_view_piutang
    Private inlap_type As String = ""
    Private inquery As String = ""
    Private inheadpar As String = ""

    Public Sub setVar(laptipe As String, query As String, Optional headerparam1 As String = "...")
        inlap_type = laptipe
        inquery = query
        inheadpar = headerparam1
    End Sub

    Private Sub filldatatabel(query As String, dt As DataTable)
        op_con()
        Try
            Dim data_adpt As New MySqlDataAdapter(query, getConn)
            data_adpt.Fill(dt)
            data_adpt.Dispose()
        Catch ex As Exception
            consoleWriteLine(ex.Message)
            logError(ex)
            'MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try
        'cl_con()
        'DataGridView1.DataSource = dt
    End Sub

    Private Sub repViewerSelector(lap_type As String)
        Dim parUserId As New ReportParameter("parUserId", loggeduser.user_id)
        Dim parPeriode As New ReportParameter("parPeriode", inheadpar)
        Dim repdatasource, repdatasource1 As New ReportDataSource

        With Me.rv_nota
            With .LocalReport
                
                Select Case inlap_type
                    Case "p_salesnota"
                        repdatasource.Name = "ds_piutang_salesnota"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_sales_nota

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.piutang_salesnota.rdlc"

                        With ds_hutangpiutang
                            .dt_piutang_sales_nota.Clear()
                            filldatatabel(inquery, .dt_piutang_sales_nota)
                        End With
                    Case "p_saleslengkap2"
                        repdatasource.Name = "ds_piutang_salesl2"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_sales_lengkap2

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.piutang_saleslengkap2.rdlc"
                        With ds_hutangpiutang
                            .dt_piutang_sales_lengkap2.Clear()
                            filldatatabel(inquery, .dt_piutang_sales_lengkap2)
                        End With
                    Case "p_salesbayartanggal"
                        repdatasource.Name = "ds_piutang_salesbayar"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_sales_bayar

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.piutang_salesbayartanggal.rdlc"
                        With ds_hutangpiutang
                            .dt_piutang_sales_bayar.Clear()
                            filldatatabel(inquery, .dt_piutang_sales_bayar)
                        End With

                    Case "p_titipancusto"
                        repdatasource.Name = "ds_hutang_piutangsupplier"
                        repdatasource.Value = ds_hutangpiutang.dt_hutang_piutangsupplier

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.piutang_titipcusto.rdlc"
                        With ds_hutangpiutang
                            .dt_hutang_piutangsupplier.Clear()
                            filldatatabel(inquery, .dt_hutang_piutangsupplier)
                        End With

                    Case "p_kartupiutang"
                        repdatasource.Name = "ds_piutang_kartupiutang"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_kartu

                        Dim parTitleLaporan As New ReportParameter("parTitleLaporan", "Kartu Piutang")

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.piutang_kartupiutang.rdlc"
                        .SetParameters(New ReportParameter() {parTitleLaporan})

                        consoleWriteLine(inquery)

                        With ds_hutangpiutang
                            .dt_piutang_kartu.Clear()
                            filldatatabel(inquery, .dt_piutang_kartu)
                            consoleWriteLine(.dt_piutang_kartu.Rows.Count)
                        End With

                    Case "p_kartupiutangsales"
                        repdatasource.Name = "ds_piutang_kartupiutang"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_kartu

                        Dim parTitleLaporan As New ReportParameter("parTitleLaporan", "Kartu Piutang Per Sales")
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.piutang_kartupiutang.rdlc"
                        .SetParameters(New ReportParameter() {parTitleLaporan})

                        With ds_hutangpiutang
                            .dt_piutang_kartu.Clear()
                            filldatatabel(inquery, .dt_piutang_kartu)
                            consoleWriteLine(.dt_piutang_kartu.Rows.Count)
                        End With

                    Case "p_bayarnota"
                        repdatasource.Name = "ds_piutang_bayardetail"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_bayardetail

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.piutang_detailbayar.rdlc"

                        With ds_hutangpiutang
                            .dt_piutang_bayardetail.Clear()
                            filldatatabel(inquery, .dt_piutang_bayardetail)
                            consoleWriteLine(.dt_piutang_bayardetail.Rows.Count)
                        End With

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
            .RefreshReport()
            .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            .ZoomMode = 2
            .ZoomPercent = 100
        End With
    End Sub

    Public Sub do_load()
        repViewerSelector(inlap_type)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fr_view_nota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'repViewerSelector(inlap_type)
        Me.Cursor = Cursors.AppStarting

    End Sub
End Class