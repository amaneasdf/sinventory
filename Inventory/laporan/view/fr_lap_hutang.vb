Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_lap_hutang
    Private inlap_type As String = ""
    Private inquery As String = ""
    Private inheadpar As String = ""

    Public Sub setVar(laptipe As String, query As String, Optional headerparam1 As String = "...")
        inlap_type = LCase(laptipe)
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

        'DataGridView1.DataSource = dt
    End Sub

    Private Sub repViewerSelector(lap_type As String)
        Dim parUserId As New ReportParameter("parUserId", loggeduser.user_id)
        Dim parPeriode As New ReportParameter("parPeriode", inheadpar)
        Dim repdatasource, repdatasource1 As New ReportDataSource

        With Me.rv_nota
            With .LocalReport

                Select Case inlap_type
                    Case "h_nota"
                        repdatasource.Name = "ds_hutang_nota"
                        repdatasource.Value = ds_hutangpiutang.dt_hutang_nota

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.hutang_nota.rdlc"

                        With ds_hutangpiutang
                            .dt_hutang_nota.Clear()
                            filldatatabel(inquery, .dt_hutang_nota)
                        End With
                    Case "h_titipsupplier"
                        repdatasource.Name = "ds_hutang_piutangsupplier"
                        repdatasource.Value = ds_hutangpiutang.dt_hutang_piutangsupplier

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.hutang_titipsupplier.rdlc"
                        With ds_hutangpiutang
                            .dt_hutang_piutangsupplier.Clear()
                            filldatatabel(inquery, .dt_hutang_piutangsupplier)
                        End With

                    Case "h_kartuhutang"
                        repdatasource.Name = "ds_piutang_kartupiutang"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_kartu

                        Dim parTitleLaporan As New ReportParameter("parTitleLaporan", "Kartu Hutang")

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.piutang_kartupiutang.rdlc"
                        .SetParameters(New ReportParameter() {parTitleLaporan})

                        consoleWriteLine(inquery)

                        With ds_hutangpiutang
                            .dt_piutang_kartu.Clear()
                            filldatatabel(inquery, .dt_piutang_kartu)
                            consoleWriteLine(.dt_piutang_kartu.Rows.Count)
                        End With

                    Case "h_bayarnota"
                        repdatasource.Name = "ds_hutang_bayardetail"
                        repdatasource.Value = ds_hutangpiutang.dt_hutang_bayardetail

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.hutang_detailbayar.rdlc"

                        consoleWriteLine(inquery)

                        With ds_hutangpiutang
                            .dt_hutang_bayardetail.Clear()
                            filldatatabel(inquery, .dt_hutang_bayardetail)
                            consoleWriteLine(.dt_hutang_bayardetail.Rows.Count)
                        End With

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
        Me.Cursor = Cursors.AppStarting
    End Sub
End Class