Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_lap_stock_view
    Public inlap_type As String = ""
    Public inquery As String = ""
    Public periode As Date = selectedperiode

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

    Private Sub repViewerSelector(lap_type As String)
        Dim parUserId As New ReportParameter("parUserId", loggeduser.user_id)
        Dim parPeriode As New ReportParameter("parPeriode", periode.ToString("MMMM yyyy"))
        Dim repdatasource, repdatasource1, repdatasource2 As New ReportDataSource

        With Me.rv_beli_nota
            With .LocalReport
                Select Case lap_type
                    Case "lapKartuStok"
                        repdatasource.Name = "ds_kartu_stok"
                        repdatasource.Value = ds_stock.dt_kartustok
                        inquery = "SELECT * FROM selectKartuStok " _
                            & "WHERE kartu_periode='" & periode.ToString("yyyy-MM") & "'"
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_stok_kartustok.rdlc"
                    Case "lapPersediaan"
                        repdatasource.Name = "ds_lap_stock"
                        repdatasource.Value = ds_stock.dt_persediaan
                        inquery = "SELECT stock_gudang, stock_gudang_n, stock_barang, stock_barang_n, stock_qty, " _
                            & "getQTYdetail(stock_barang,stock_qty,'1') as stock_qty_n,stock_hpp FROM selectPersediaan " _
                            & "WHERE stock_periode='" & periode.ToString("yyyy-MM") & "'"
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_stok_persedianbrg.rdlc"
                    Case "lapStok"
                        repdatasource.Name = "ds_lap_stock"
                        repdatasource.Value = ds_stock.dt_persediaan
                        inquery = "SELECT stock_gudang, stock_gudang_n, stock_barang, stock_barang_n, stock_qty, " _
                            & "getQTYdetail(stock_barang,stock_qty,'1') as stock_qty_n FROM selectPersediaan " _
                            & "WHERE stock_periode='" & periode.ToString("yyyy-MM") & "'"
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_stok_stok.rdlc"
                    Case "lapStokSupplier"
                        repdatasource.Name = "ds_lap_stock"
                        repdatasource.Value = ds_stock.dt_persediaan_supplier
                        inquery = "SELECT stock_gudang, stock_gudang_n, stock_barang, stock_barang_n, stock_qty, " _
                            & "getQTYdetail(stock_barang,stock_qty,'1') as stock_qty_n, stock_hpp, stock_supplier, " _
                            & "stock_supplier_n FROM selectPersediaan " _
                            & "WHERE stock_periode='" & periode.ToString("yyyy-MM") & "'"
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_stok_supplier.rdlc"
                    Case "lapStokMutasi"
                        repdatasource.Name = "ds_stok_mutasi"
                        repdatasource.Value = ds_stock.dt_persediaan_detail
                        inquery = "SELECT * FROM selectPersediaanDetail " _
                            & "WHERE persediaan_periode='" & periode.ToString("yyyy-MM") & "'"
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_stok_mutasistok.rdlc"
                    Case "lapPersediaanMutasi"
                        repdatasource.Name = "ds_stok_mutasi"
                        repdatasource.Value = ds_stock.dt_persediaan_detail
                        inquery = "SELECT * FROM selectPersediaanDetail " _
                            & "WHERE persediaan_periode='" & periode.ToString("yyyy-MM") & "'"
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_stok_mutasipersediaan.rdlc"
                    Case Else
                        Exit Sub
                End Select

                Select Case lap_type
                    Case "lapKartuStok"
                        With ds_stock
                            .dt_kartustok.Clear()
                            filldatatabel(inquery, .dt_kartustok)
                        End With
                    Case "lapPersediaan", "lapStok"
                        With ds_stock
                            .dt_persediaan.Clear()
                            filldatatabel(inquery, .dt_persediaan)
                        End With
                    Case "lapStokSupplier"
                        With ds_stock
                            .dt_persediaan_supplier.Clear()
                            filldatatabel(inquery, .dt_persediaan_supplier)
                        End With
                    Case "lapStokMutasi", "lapPersediaanMutasi"
                        With ds_stock
                            .dt_persediaan_detail.Clear()
                            filldatatabel(inquery, .dt_persediaan_detail)
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

    Private Sub fr_lap_beli_nota_view_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repViewerSelector(inlap_type)
    End Sub
End Class