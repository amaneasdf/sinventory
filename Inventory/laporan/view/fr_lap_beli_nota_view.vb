﻿Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_lap_beli_nota_view
    Public inlap_type As String = ""
    Public inquery As String = ""
    Public intglawal As String = "-"
    Public intglakhir As String = "-"

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
        Dim parTglAkhir As New ReportParameter("parTglAkhir", intglakhir)
        Dim parTglAwal As New ReportParameter("parTglAwal", intglawal)
        Dim repdatasource, repdatasource1, repdatasource2 As New ReportDataSource

        With Me.rv_beli_nota
            With .LocalReport
                Select Case lap_type
                    Case "lapBeliNota"
                        repdatasource.Name = "ds_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_nota.rdlc"

                    Case "lapBeliSupplier"
                        repdatasource.Name = "ds_lap_tgl"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_supplier.rdlc"

                    Case "lapBeliTgl"
                        repdatasource.Name = "ds_lap_tgl"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_tgl.rdlc"

                    Case "lapBeliSupplierBarang"
                        repdatasource.Name = "ds_beli_detail"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota_detail

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_supplierbarang.rdlc"

                    Case "lapBeliTglBarang"
                        Dim parLabelTitle As New ReportParameter("parLabelTitle", "Pembelian Per Tanggal Per Barang")

                        repdatasource.Name = "ds_beli_detail"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota_detail

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_supplierbarang.rdlc"
                        .SetParameters(New ReportParameter() {parLabelTitle})

                    Case "lapBeliSupplierNota"
                        repdatasource.Name = "ds_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_suppliernota.rdlc"

                    Case "lapBeliTglNota"
                        repdatasource.Name = "ds_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_tglnota.rdlc"

                    Case "lapBeliSupplierNotaBarang"
                        'repdatasource.Name = ""
                        'repdatasource.Value = ds_transaksi.dt_lap_beli_nota_detail
                        'inquery = "SELECT * FROM selectBeliNotaWithDetail ORDER BY dlap_supplier, dlap_tgl"
                        '.DataSources.Add(repdatasource)
                        '.ReportEmbeddedResource = "Inventory.lap_beli_suppliernotabarang.rdlc"

                    Case "lapBeliTglNotaBarang"
                        repdatasource.Name = "ds_nota_brg"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota_detail

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_tglnotabrg.rdlc"

                    Case "lapBeliRetur"

                    Case "lapJualNota"
                        repdatasource.Name = "ds_jual_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_nota.rdlc"

                    Case "lapJualCusto"
                        repdatasource.Name = "ds_jual_custo"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_custo.rdlc"

                    Case "lapJualSales"
                        repdatasource.Name = "ds_jual_custo"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_sales.rdlc"

                    Case "lapJualTgl"
                        repdatasource.Name = "ds_jual_tgl"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_tgl.rdlc"

                    Case "lapJualSupplier"
                        Dim parLabelJudul As New ReportParameter("parLabelJudul", "Penjualan Per Supplier")
                        Dim parJudulKolom1 As New ReportParameter("parJudulKolom1", "SUPPLIER")

                        repdatasource.Name = "ds_jual_custo"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_custo.rdlc"
                        .SetParameters(New ReportParameter() {parLabelJudul, parJudulKolom1})

                    Case "lapJualTipe"
                        Dim parLabelJudul As New ReportParameter("parLabelJudul", "Penjualan Per Tipe")
                        Dim parJudulKolom1 As New ReportParameter("parJudulKolom1", "TIPE CUSTOMER")

                        repdatasource.Name = "ds_jual_custo"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_custo.rdlc"
                        .SetParameters(New ReportParameter() {parLabelJudul, parJudulKolom1})

                        'Case "lapJualBarang"
                        '    Dim parLabelJudul As New ReportParameter("parLabelJudul", "Penjualan Per Barang")
                        '    Dim parJudulKolom1 As New ReportParameter("parJudulKolom1", "BARANG")

                        '    repdatasource.Name = "ds_jual_custo"
                        '    repdatasource.Value = ds_transaksi.dt_lap_jual_nota

                        '    inquery = "SELECT IFNULL(barang_kode,'-') as lap_custo, IFNULL(barang_nama,'-') as lap_custo_n, SUM(dlap_brutto) as lap_brutto, SUM(dlap_brutto-dlap_jumlah) as lap_diskon, SUM(dlap_jumlah) as lap_jumlah FROM selectJualNotaWithDetail LEFT JOIN data_barang_master ON barang_kode=dlap_barang GROUP BY barang_kode ORDER BY barang_kode"

                        '    .DataSources.Add(repdatasource)
                        '    .ReportEmbeddedResource = "Inventory.lap_jual_custo.rdlc"

                    Case "lapJualCustoNota"
                        Dim parLabelJudul As New ReportParameter("parLabelJudul", "Penjualan Per Customer Per Nota")

                        repdatasource.Name = "ds_jual_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_custonota.rdlc"
                        .SetParameters(New ReportParameter() {parLabelJudul})

                    Case "lapJualSalesNota"
                        Dim parLabelJudul As New ReportParameter("parLabelJudul", "Penjualan Per Sales Per Nota")

                        repdatasource.Name = "ds_jual_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_salesnota.rdlc"
                        .SetParameters(New ReportParameter() {parLabelJudul})

                    Case "lapJualTanggalNota"
                        Dim parLabelJudul As New ReportParameter("parLabelJudul", "Penjualan Per Tanggal Per Nota")

                        repdatasource.Name = "ds_jual_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_tglnota.rdlc"
                        .SetParameters(New ReportParameter() {parLabelJudul})

                    Case "lapJualBarangSupplier"
                        repdatasource.Name = "ds_jual_brg"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_barang

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_brgsupplier.rdlc"

                    Case "lapJualBarangSales"
                        Dim parLabelJudul As New ReportParameter("parLabelJudul", "Penjualan Per Barang Per Salesman")

                        repdatasource.Name = "ds_jual_brg"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_barang

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_brgsupplier.rdlc"

                    Case "lapJualSalesCustoBarang"
                        repdatasource.Name = "ds_lap_custo"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_custo_detail

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_custobrg.rdlc"

                    Case Else
                        Exit Sub
                End Select

                Select Case lap_type
                    Case "lapBeliNota", "lapBeliSupplier", "lapBeliTgl", "lapBeliSupplierNota", "lapBeliTglNota"
                        With ds_transaksi
                            .dt_lap_beli_nota.Clear()
                            filldatatabel(inquery, .dt_lap_beli_nota)
                        End With
                    Case "lapBeliSupplierBarang", "lapBeliTglBarang", "lapBeliTglNotaBarang"
                        With ds_transaksi
                            .dt_lap_beli_nota_detail.Clear()
                            filldatatabel(inquery, .dt_lap_beli_nota_detail)
                            DataGridView1.DataSource = .dt_lap_beli_nota_detail
                        End With
                    Case "lapJualNota", "lapJualTgl", "lapJualCusto", "lapJualBarang", "lapJualSupplier", "lapJualTipe", "lapJualSales", "lapJualCustoNota", "lapJualSalesNota", "lapJualTanggalNota"
                        With ds_transaksi
                            .dt_lap_jual_nota.Clear()
                            filldatatabel(inquery, .dt_lap_jual_nota)
                        End With
                    Case "lapJualBarangSupplier", "lapJualBarangSales"
                        With ds_transaksi
                            .dt_lap_jual_barang.Clear()
                            filldatatabel(inquery, .dt_lap_jual_barang)
                        End With
                    Case "lapJualSalesCustoBarang"
                        With ds_transaksi
                            .dt_lap_jual_custo_detail.Clear()
                            filldatatabel(inquery, .dt_lap_jual_custo_detail)
                        End With
                    Case Else
                        Exit Sub
                End Select

                .SetParameters(New ReportParameter() {parUserId, parTglAwal, parTglAkhir})
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

    Private Sub fr_lap_beli_nota_view_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'repViewerSelector("lapBeliTgl")
        Me.Cursor = Cursors.AppStarting

    End Sub
End Class