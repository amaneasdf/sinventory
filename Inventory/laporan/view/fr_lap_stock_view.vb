Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_lap_stock_view
    Public inlap_type As String = ""
    Private inquery As String = ""
    Private header As String = ""
    Public periode As Date = selectedperiode

    Public Sub setVar(tipe As String, queryLap As String, headerLap As String)
        inlap_type = tipe
        inquery = queryLap
        header = headerLap
    End Sub

    Private Sub filldatatabel(query As String, dt As DataTable)
        op_con()
        Try
            Dim data_adpt As New MySqlDataAdapter(query, getConn)
            data_adpt.Fill(dt)
            DataGridView1.DataSource = dt
            data_adpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try
        cl_con()
    End Sub

    Private Sub repViewerSelector(lap_type As String)
        Dim parUserId As New ReportParameter("parUserId", loggeduser.user_id)
        Dim parPeriode As New ReportParameter("parPeriode", header)
        Dim repdatasource, repdatasource1, repdatasource2 As New ReportDataSource
        Dim dt As DataTable

        With Me.rv_beli_nota
            With .LocalReport
                Select Case lap_type
                    Case "lapKartuStok"
                        dt = ds_stock.dt_kartustok
                        repdatasource.Name = "ds_kartu_stok"
                        repdatasource.Value = ds_stock.dt_kartustok

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_stok_kartustok.rdlc"

                    Case "lapKartuPersediaan", "lapKartuPersediaanGudang"
                        dt = ds_stock.dt_kartupersediaan
                        repdatasource.Name = "ds_kartu_stok"
                        repdatasource.Value = ds_stock.dt_kartupersediaan

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = IIf(lap_type = "lapKartuPersediaan",
                                                      "Inventory.lap_stok_kartupersediaan.rdlc",
                                                      "Inventory.lap_stok_kartupersediaan_gudang.rdlc"
                                                      )

                    Case "lapPersediaan"
                        dt = ds_stock.dt_persediaan
                        repdatasource.Name = "ds_lap_stock"
                        repdatasource.Value = ds_stock.dt_persediaan

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_stok_persedianbrg.rdlc"

                    Case "lapStok"
                        dt = ds_stock.dt_persediaan
                        repdatasource.Name = "ds_lap_stock"
                        repdatasource.Value = ds_stock.dt_persediaan

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_stok_stok.rdlc"

                    Case "lapStokSupplier"
                        dt = ds_stock.dt_persediaan_supplier
                        repdatasource.Name = "ds_lap_stock"
                        repdatasource.Value = ds_stock.dt_persediaan_supplier

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_stok_supplier.rdlc"

                    Case "lapStokMutasi"
                        dt = ds_stock.dt_persediaan_detail
                        repdatasource.Name = "ds_stok_mutasi"
                        repdatasource.Value = ds_stock.dt_persediaan_detail

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_stok_mutasistok.rdlc"

                    Case "lapPersediaanMutasi"
                        dt = ds_stock.dt_persediaan_detail
                        repdatasource.Name = "ds_stok_mutasi"
                        repdatasource.Value = ds_stock.dt_persediaan_detail

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_stok_mutasipersediaan.rdlc"
                    Case Else
                        Exit Sub
                End Select

                dt.Clear()
                filldatatabel(inquery, dt)

                .SetParameters(New ReportParameter() {parUserId, parPeriode})
            End With
            .RefreshReport()
            .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            .ZoomMode = 2
            .ZoomPercent = 100
        End With
    End Sub


    Private Sub fr_lap_beli_nota_view_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repViewerSelector(inlap_type)
    End Sub
End Class