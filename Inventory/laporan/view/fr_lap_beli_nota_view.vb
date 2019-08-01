Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_lap_beli_nota_view
    Public inlap_type As String = ""
    Public inquery As String = ""
    Public intglawal As String = "-"
    Public intglakhir As String = "-"

    Private Sub filldatatabel(query As String, dt As DataTable)
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    Dim data_adpt As New MySqlDataAdapter(query, x.Connection)
                    consoleWriteLine(query)
                    data_adpt.Fill(dt)
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
        Dim parTglAkhir As New ReportParameter("parTglAkhir", intglakhir)
        Dim parTglAwal As New ReportParameter("parTglAwal", intglawal)
        Dim repdatasource, repdatasource1, repdatasource2 As New ReportDataSource

        With Me.rv_beli_nota
            With .LocalReport
                Select Case lap_type
                    Case "lapBeliNota"
                        repdatasource.Name = "ds_nota"
                        repdatasource.Value = ds_transaksi.dt_beli_nota

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_nota_v2.rdlc"

                        ds_transaksi.dt_beli_nota.Clear()
                        filldatatabel(inquery, ds_transaksi.dt_beli_nota)

                    Case "lapBeliSupplier", "lapBeliTgl"
                        repdatasource.Name = "ds_lap_tgl"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota

                        .DataSources.Add(repdatasource)
                        If lap_type = "lapBeliTgl" Then
                            .ReportEmbeddedResource = "Inventory.lap_beli_tgl.rdlc"
                        ElseIf lap_type = "lapBeliSupplier" Then
                            .ReportEmbeddedResource = "Inventory.lap_beli_supplier.rdlc"
                        End If

                        ds_transaksi.dt_lap_beli_nota.Clear()
                        filldatatabel(inquery, ds_transaksi.dt_lap_beli_nota)

                    Case "lapBeliTglBarang", "lapBeliSupplierBarang"
                        Dim parLabelJudul As New ReportParameter()

                        repdatasource.Name = "ds_beli_detail"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota_detail

                        .DataSources.Add(repdatasource)
                        If lap_type = "lapBeliTglBarang" Then
                            parLabelJudul = New ReportParameter("parLabelTitle", "Laporan Pembelian Barang Per Tanggal")
                            .ReportEmbeddedResource = "Inventory.lap_beli_tglbarang.rdlc"
                        ElseIf lap_type = "lapBeliSupplierBarang" Then
                            parLabelJudul = New ReportParameter("parLabelTitle", "Laporan Pembelian Barang Per Supplier")
                            .ReportEmbeddedResource = "Inventory.lap_beli_supplierbarang.rdlc"
                        End If
                        .SetParameters(New ReportParameter() {parLabelJudul})

                        ds_transaksi.dt_jual_nota.Clear()
                        filldatatabel(inquery, ds_transaksi.dt_lap_jual_nota)

                    Case "lapBeliSupplierNota", "lapBeliTglNota"
                        repdatasource.Name = "ds_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota

                        .DataSources.Add(repdatasource)
                        If lap_type = "lapBeliSupplierNota" Then
                            .ReportEmbeddedResource = "Inventory.lap_beli_suppliernota.rdlc"
                        ElseIf lap_type = "lapBeliTglNota" Then
                            .ReportEmbeddedResource = "Inventory.lap_beli_tglnota.rdlc"
                        End If

                        ds_transaksi.dt_lap_beli_nota.Clear()
                        filldatatabel(inquery, ds_transaksi.dt_lap_beli_nota)

                    Case "lapBeliTglNotaBarang", "lapBeliSupplierNotaBarang"
                        repdatasource.Name = "ds_nota_brg"
                        repdatasource.Value = ds_transaksi.dt_lap_dist_beli

                        .DataSources.Add(repdatasource)
                        If lap_type = "lapBeliTglNotaBarang" Then
                            .ReportEmbeddedResource = "Inventory.lap_beli_tglnotabrg.rdlc"
                        ElseIf lap_type = "lapBeliSupplierNotaBarang" Then
                            .ReportEmbeddedResource = "Inventory.lap_beli_suppliernotabrg.rdlc"
                        End If

                        ds_transaksi.dt_lap_dist_beli.Clear()
                        filldatatabel(inquery, ds_transaksi.dt_lap_dist_beli)

                    Case "lapJualNota"
                        repdatasource.Name = "ds_jual_nota"
                        repdatasource.Value = ds_transaksi.dt_jual_nota
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_nota_v2.rdlc"

                        ds_transaksi.dt_jual_nota.Clear()
                        filldatatabel(inquery, ds_transaksi.dt_jual_nota)

                    Case "lapJualCusto", "lapJualSales", "lapJualTgl", "lapJualTipe", "lapJualSupplier"
                        repdatasource.Name = "ds_jual_custo"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota

                        .DataSources.Add(repdatasource)
                        If lap_type = "lapJualCusto" Then
                            .ReportEmbeddedResource = "Inventory.lap_jual_custo.rdlc"
                            .SetParameters(New ReportParameter() {
                                                    New ReportParameter("parLabelJudul", "Laporan Penjualan Per Customer"),
                                                    New ReportParameter("parJudulKolom1", "CUSTOMER")
                                                    })
                        ElseIf lap_type = "lapJualSales" Then
                            .ReportEmbeddedResource = "Inventory.lap_jual_sales.rdlc"
                        ElseIf lap_type = "lapJualTgl" Then
                            .ReportEmbeddedResource = "Inventory.lap_jual_tgl.rdlc"
                        ElseIf lap_type = "lapJualTipe" Then
                            .ReportEmbeddedResource = "Inventory.lap_jual_custo.rdlc"
                            .SetParameters(New ReportParameter() {
                                                    New ReportParameter("parLabelJudul", "Laporan Penjualan Per Tipe Customer"),
                                                    New ReportParameter("parJudulKolom1", "TIPE CUSTOMER")
                                                    })
                        ElseIf lap_type = "lapJualSupplier" Then
                            .ReportEmbeddedResource = "Inventory.lap_jual_custo.rdlc"
                            .SetParameters(New ReportParameter() {
                                                    New ReportParameter("parLabelJudul", "Laporan Penjualan Per Supplier"),
                                                    New ReportParameter("parJudulKolom1", "SUPPLIER")
                                                    })
                        End If

                        ds_transaksi.dt_jual_nota.Clear()
                        filldatatabel(inquery, ds_transaksi.dt_lap_jual_nota)

                    Case "lapJualTanggalNota", "lapJualSalesNota", "lapJualCustoNota"
                        Dim parLabelJudul As New ReportParameter()

                        repdatasource.Name = "ds_jual_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota

                        .DataSources.Add(repdatasource)
                        If lap_type = "lapJualTanggalNota" Then
                            parLabelJudul = New ReportParameter("parLabelJudul", "Laporan Nota Penjualan Per Tanggal")
                            .ReportEmbeddedResource = "Inventory.lap_jual_tglnota.rdlc"
                        ElseIf lap_type = "lapJualSalesNota" Then
                            parLabelJudul = New ReportParameter("parLabelJudul", "Laporan Nota Penjualan Per Salesman")
                            .ReportEmbeddedResource = "Inventory.lap_jual_salesnota.rdlc"
                        ElseIf lap_type = "lapJualCustoNota" Then
                            parLabelJudul = New ReportParameter("parLabelJudul", "Laporan Nota Penjualan Per Customer")
                            .ReportEmbeddedResource = "Inventory.lap_jual_custonota.rdlc"
                        End If
                        .SetParameters(New ReportParameter() {parLabelJudul})

                        ds_transaksi.dt_lap_jual_nota.Clear()
                        filldatatabel(inquery, ds_transaksi.dt_lap_jual_nota)


                    Case "lapJualBarangSupplier", "lapJualBarangSales"
                        Dim parLabelJudul As New ReportParameter()

                        repdatasource.Name = "ds_jual_brg"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_barang

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_brgsupplier.rdlc"

                        If lap_type = "lapJualBarangSupplier" Then
                            parLabelJudul = New ReportParameter("parLabelJudul", "Laporan Penjualan Barang Per Supplier")
                        ElseIf lap_type = "lapJualBarangSales" Then
                            parLabelJudul = New ReportParameter("parLabelJudul", "Laporan Penjualan Barang Per Salesman")
                        ElseIf lap_type = "lapJualBarangCusto" Then
                            parLabelJudul = New ReportParameter("parLabelJudul", "Laporan Penjualan Barang Per Customer")
                        ElseIf lap_type = "lapJualBarangTanggal" Then
                            parLabelJudul = New ReportParameter("parLabelJudul", "Laporan Penjualan Barang Per Tanggal")
                        End If
                        .SetParameters(New ReportParameter() {parLabelJudul})

                        ds_transaksi.dt_lap_jual_barang.Clear()
                        filldatatabel(inquery, ds_transaksi.dt_lap_jual_barang)

                    Case "lapJualSalesCustoBarang"
                        repdatasource.Name = "ds_lap_custo"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_custo_detail

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_custobrg.rdlc"

                        ds_transaksi.dt_lap_jual_custo_detail.Clear()
                        filldatatabel(inquery, ds_transaksi.dt_lap_jual_custo_detail)

                    Case Else
                        Exit Sub
                End Select

                .SetParameters(New ReportParameter() {parUserId, parTglAwal, parTglAkhir})
            End With
        End With

    End Sub

    Private Sub fr_lap_beli_nota_view_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        repViewerSelector(inlap_type)
        With rv_beli_nota
            .RefreshReport()
            .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            .ZoomMode = 2
            .ZoomPercent = 100
        End With
        Me.Cursor = Cursors.Default
    End Sub
End Class
