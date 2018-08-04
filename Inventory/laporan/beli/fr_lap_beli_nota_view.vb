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
        Dim parTglAkhir As New ReportParameter("parTglAkhir", "31-12-2100")
        Dim parTglAwal As New ReportParameter("parTglAwal", "01-01-1990")
        Dim repdatasource, repdatasource1, repdatasource2 As New ReportDataSource

        With Me.rv_beli_nota
            With .LocalReport
                Select Case lap_type
                    Case "lapBeliNota"
                        repdatasource.Name = "ds_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota
                        inquery = "SELECT * FROM selectBeliNota ORDER BY lap_faktur"
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_nota.rdlc"
                    Case "lapBeliSupplier"
                        repdatasource.Name = "ds_lap_supplier"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota
                        inquery = "SELECT lap_supplier_n,SUM(lap_brutto) as lap_brutto, SUM(lap_diskon) as lap_diskon, SUM(lap_ppn) as lap_ppn, SUM(lap_jumlah) as lap_jumlah FROM selectBeliNota GROUP BY lap_supplier ORDER BY lap_supplier"
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_supplier.rdlc"
                    Case "lapBeliTgl"
                        repdatasource.Name = "ds_lap_tgl"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota
                        inquery = "SELECT lap_tgl, SUM(lap_brutto) as lap_brutto, SUM(lap_diskon) as lap_diskon, SUM(lap_ppn) as lap_ppn, SUM(lap_jumlah) as lap_jumlah FROM selectBeliNota GROUP BY lap_tgl"
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_tgl.rdlc"
                    Case "lapBeliSupplierBarang"
                        repdatasource.Name = "ds_beli_detail"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota_detail
                        inquery = "SELECT * FROM selectBeliNotaWithDetail ORDER BY dlap_supplier, dlap_barang, dlap_tgl"
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_supplierbarang.rdlc"
                    Case "lapBeliSupplierNota"
                        repdatasource.Name = "ds_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota
                        inquery = "SELECT * FROM selectBeliNota ORDER BY lap_tgl"
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_suppliernota.rdlc"
                    Case "lapBeliTglNota"
                        repdatasource.Name = "ds_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota
                        inquery = "SELECT * FROM selectBeliNota ORDER BY lap_tgl"
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_tglnota.rdlc"
                    Case "lapBeliTglBarang"
                        repdatasource.Name = "ds_beli_detail"
                        repdatasource.Value = ds_transaksi.dt_lap_beli_nota_detail
                        inquery = "SELECT * FROM selectBeliNotaWithDetail ORDER BY dlap_tgl, dlap_supplier, dlap_barang"
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_beli_tglbarang.rdlc"
                    Case "lapBeliSupplierNotaBarang"
                        'repdatasource.Name = ""
                        'repdatasource.Value = ds_transaksi.dt_lap_beli_nota_detail
                        'inquery = "SELECT * FROM selectBeliNotaWithDetail ORDER BY dlap_supplier, dlap_tgl"
                        '.DataSources.Add(repdatasource)
                        '.ReportEmbeddedResource = "Inventory.lap_beli_suppliernotabarang.rdlc"
                    Case "lapBeliTglNotaBarang"
                        'repdatasource.Name = ""
                        'repdatasource.Value = ds_transaksi.dt_lap_beli_nota_detail
                        'inquery = "SELECT * FROM selectBeliNotaWithDetail ORDER BY dlap_tgl"
                        '.DataSources.Add(repdatasource)
                        '.ReportEmbeddedResource = "Inventory.lap_beli_tglnotabarang.rdlc"
                    Case "lapBeliRetur"

                    Case "lapJualNota"
                        repdatasource.Name = "ds_jual_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota
                        inquery = "SELECT * FROM selectJualNota ORDER BY lap_faktur"
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_nota.rdlc"
                    Case "lapJualCusto"
                        repdatasource.Name = "ds_jual_custo"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota
                        inquery = "SELECT lap_custo_n, SUM(lap_brutto) as lap_brutto, SUM(lap_diskon) as lap_diskon, SUM(lap_ppn) as lap_ppn, SUM(lap_jumlah) as lap_jumlah FROM selectJualNota GROUP BY lap_custo"
                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_custo.rdlc"
                    Case "lapJualSales"
                        repdatasource.Name = "ds_jual_custo"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota

                        inquery = "SELECT lap_sales_n, SUM(lap_brutto) as lap_brutto, SUM(lap_diskon) as lap_diskon, SUM(lap_ppn) as lap_ppn, SUM(lap_jumlah) as lap_jumlah FROM selectJualNota GROUP BY lap_sales"

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_sales.rdlc"
                    Case "lapJualTgl"
                        repdatasource.Name = "ds_jual_tgl"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota

                        inquery = "SELECT lap_tgl, SUM(lap_brutto) as lap_brutto, SUM(lap_diskon) as lap_diskon, SUM(lap_ppn) as lap_ppn, SUM(lap_jumlah) as lap_jumlah FROM selectJualNota GROUP BY lap_tgl"

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_tgl.rdlc"
                    Case "lapJualSupplier"
                        Dim parLabelJudul As New ReportParameter("parLabelJudul", "Penjualan Per Supplier")
                        Dim parJudulKolom1 As New ReportParameter("parJudulKolom1", "SUPPLIER")

                        repdatasource.Name = "ds_jual_custo"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota

                        inquery = "SELECT IFNULL(supplier_kode,'-') as lap_custo, IFNULL(supplier_nama,'-') as lap_custo_n, SUM(dlap_brutto) as lap_brutto, SUM(dlap_brutto-dlap_jumlah) as lap_diskon, SUM(dlap_jumlah) as lap_jumlah FROM selectJualNotaWithDetail LEFT JOIN data_barang_master ON barang_kode=dlap_barang LEFT JOIN data_supplier_master ON supplier_kode=barang_supplier GROUP BY supplier_kode"

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_custo.rdlc"
                        .SetParameters(New ReportParameter() {parLabelJudul, parJudulKolom1})
                    Case "lapJualTipe"
                        Dim parLabelJudul As New ReportParameter("parLabelJudul", "Penjualan Per Tipe")
                        Dim parJudulKolom1 As New ReportParameter("parJudulKolom1", "TIPE CUSTOMER")

                        repdatasource.Name = "ds_jual_custo"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota

                        inquery = "SELECT jenis_nama as lap_custo_n, SUM(lap_brutto) as lap_brutto, SUM(lap_diskon) as lap_diskon, SUM(lap_ppn) as lap_ppn, SUM(lap_jumlah) as lap_jumlah FROM selectJualNota LEFT JOIN `data_customer_master` ON customer_kode=lap_custo LEFT JOIN `data_customer_jenis` ON customer_jenis = jenis_kode GROUP BY jenis_kode"

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_custo.rdlc"
                        .SetParameters(New ReportParameter() {parLabelJudul, parJudulKolom1})
                    Case "lapJualBarang"
                        Dim parLabelJudul As New ReportParameter("parLabelJudul", "Penjualan Per Barang")
                        Dim parJudulKolom1 As New ReportParameter("parJudulKolom1", "BARANG")

                        repdatasource.Name = "ds_jual_custo"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota

                        inquery = "SELECT IFNULL(barang_kode,'-') as lap_custo, IFNULL(barang_nama,'-') as lap_custo_n, SUM(dlap_brutto) as lap_brutto, SUM(dlap_brutto-dlap_jumlah) as lap_diskon, SUM(dlap_jumlah) as lap_jumlah FROM selectJualNotaWithDetail LEFT JOIN data_barang_master ON barang_kode=dlap_barang GROUP BY barang_kode ORDER BY barang_kode"

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_custo.rdlc"

                    Case "lapJualCustoNota"
                        Dim parLabelJudul As New ReportParameter("parLabelJudul", "Penjualan Per Custo Per Nota")

                        repdatasource.Name = "ds_jual_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota

                        inquery = "SELECT * FROM selectJualNota ORDER BY lap_custo, lap_faktur"

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_custonota.rdlc"
                        .SetParameters(New ReportParameter() {parLabelJudul})

                    Case "lapJualSalesNota"
                        Dim parLabelJudul As New ReportParameter("parLabelJudul", "Penjualan Per Sales Per Nota")

                        repdatasource.Name = "ds_jual_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota

                        inquery = "SELECT lap_sales as lap_custo, lap_sales_n as lap_custo_n, lap_faktur, lap_tgl, lap_brutto, lap_diskon, lap_ppn, lap_jumlah FROM selectJualNota ORDER BY lap_sales, lap_faktur"

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_custonota.rdlc"
                        .SetParameters(New ReportParameter() {parLabelJudul})

                    Case "lapJualTanggalNota"
                        Dim parLabelJudul As New ReportParameter("parLabelJudul", "Penjualan Per Tanggal Per Nota")

                        repdatasource.Name = "ds_jual_nota"
                        repdatasource.Value = ds_transaksi.dt_lap_jual_nota

                        inquery = "SELECT * FROM selectJualNota ORDER BY lap_tgl, lap_faktur"

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.lap_jual_tglnota.rdlc"
                        .SetParameters(New ReportParameter() {parLabelJudul})

                    Case Else
                        Exit Sub
                End Select
                Select Case lap_type
                    Case "lapBeliNota", "lapBeliSupplier", "lapBeliTgl", "lapBeliSupplierNota", "lapBeliTglNota"
                        With ds_transaksi
                            .dt_lap_beli_nota.Clear()
                            filldatatabel(inquery, .dt_lap_beli_nota)
                        End With
                    Case "lapBeliSupplierBarang", "lapTglBarang"
                        With ds_transaksi
                            .dt_lap_beli_nota_detail.Clear()
                            filldatatabel(inquery, .dt_lap_beli_nota_detail)
                        End With
                    Case "lapJualNota", "lapJualTgl", "lapJualCusto", "lapJualBarang", "lapJualSupplier", "lapJualTipe", "lapJualSales", "lapJualCustoNota", "lapJualSalesNota", "lapJualTanggalNota"
                        With ds_transaksi
                            .dt_lap_jual_nota.Clear()
                            filldatatabel(inquery, .dt_lap_jual_nota)
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

    Private Sub fr_lap_beli_nota_view_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'repViewerSelector("lapBeliTgl")
        repViewerSelector(inlap_type)

    End Sub
End Class