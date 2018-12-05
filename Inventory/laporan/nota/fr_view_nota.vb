Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_view_nota
    Private inlap_type As String = ""
    Private inquery As String = ""
    Private innofaktur As String = ""

    Public Sub setVar(laptipe As String, nofaktur As String, query As String)
        inlap_type = laptipe
        inquery = query
        innofaktur = nofaktur
    End Sub

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
        Dim parNoFaktur As New ReportParameter("parNoFaktur", innofaktur)
        Dim repdatasource, repdatasource1, repdatasource2 As New ReportDataSource

        With Me.rv_nota
            With .LocalReport
                Dim tglfak As String = "1/1/1900"
                Dim sup As String = "no"
                Dim cus_n As String = "nope"
                Dim sup_al As String = "nononono"
                Dim term As Integer = 0
                Dim ppn, disk, jml, netto As Double
                Select Case inlap_type
                    Case "beli"

                        op_con()
                        Try
                            readcommd("SELECT DATE_FORMAT(faktur_tanggal_trans,'%d/%m/%Y'),faktur_term, supplier_nama, " _
                                      & "supplier_alamat, faktur_jumlah,faktur_disc, faktur_netto " _
                                      & "FROM data_pembelian_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                                      & "WHERE faktur_kode='" & innofaktur & "'")
                            If rd.HasRows Then
                                tglfak = rd.Item(0)
                                term = rd.Item(1)
                                sup = rd.Item(2)
                                sup_al = rd.Item(3)
                                jml = rd.Item(4)
                                disk = rd.Item(5)
                                netto = rd.Item(6)
                            End If
                            rd.Close()
                        Catch ex As Exception
                            logError(ex)
                            consoleWriteLine(ex.Message)
                        End Try
                        Dim parTglFaktur As New ReportParameter("parTglFaktur", tglfak)
                        Dim parTerm As New ReportParameter("parTerm", term)
                        Dim parSupplier As New ReportParameter("parSupplier", "A.N. " & sup)
                        Dim parSupplierAl As New ReportParameter("parSupplierAl", sup_al)
                        Dim parJml As New ReportParameter("parJml", jml)
                        Dim parDiskon As New ReportParameter("parDiskon", disk)
                        Dim parNetto As New ReportParameter("parNetto", netto)

                        repdatasource.Name = "ds_nota_beli"
                        repdatasource.Value = ds_transaksi.dt_nota_beli

                        inquery = "SELECT trans_barang as beli_barang ,barang_nama as beli_brg_n , " _
                            & "CONCAT(CAST(trans_qty AS CHAR),' ',trans_satuan) as beli_qty , trans_harga_beli as beli_harga, " _
                            & "trans_disc1 as beli_disc1,trans_disc2 as beli_disc2, trans_disc3 as beli_disc3, trans_disc_rupiah as beli_discrp, " _
                            & "trans_harga_beli*trans_qty - trans_jumlah as beli_disctot, trans_jumlah as beli_jml " _
                            & "FROM data_pembelian_trans LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                            & "WHERE trans_faktur='" & innofaktur & "' AND trans_status=1"

                        consoleWriteLine(inquery)

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.nota_beli.rdlc"
                        .SetParameters(New ReportParameter() {parSupplier, parSupplierAl, parTerm, parTglFaktur, parJml, parDiskon, parNetto})
                        With ds_transaksi
                            .dt_lap_beli_nota.Clear()
                            filldatatabel(inquery, .dt_nota_beli)
                        End With

                    Case "returbeli"
                        op_con()
                        Try
                            readcommd("SELECT DATE_FORMAT(faktur_tanggal_trans,'%d/%m/%Y'), supplier_nama, " _
                                      & "supplier_alamat, faktur_jumlah, faktur_ppn, faktur_netto " _
                                      & "FROM data_pembelian_retur_faktur " _
                                      & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                                      & "WHERE faktur_kode_bukti='" & innofaktur & "'")
                            If rd.HasRows Then
                                tglfak = rd.Item(0)
                                sup = rd.Item(1)
                                sup_al = rd.Item(2)
                                jml = rd.Item(3)
                                ppn = rd.Item(4)
                                netto = rd.Item(5)
                                disk = jml - netto
                            End If
                            rd.Close()
                        Catch ex As Exception
                            consoleWriteLine(ex.Message)
                        End Try

                        Dim parTglFaktur As New ReportParameter("parTglFaktur", tglfak)
                        Dim parSupplier As New ReportParameter("parSupplier", "A.N. " & sup)
                        Dim parSupplierAl As New ReportParameter("parSupplierAl", sup_al)
                        Dim parJml As New ReportParameter("parJml", jml)
                        Dim parDiskon As New ReportParameter("parDiskon", disk)
                        Dim parPPN As New ReportParameter("parPPN", ppn)
                        Dim parNetto As New ReportParameter("parNetto", netto)

                        repdatasource.Name = "ds_nota_beli"
                        repdatasource.Value = ds_transaksi.dt_nota_beli

                        inquery = "SELECT trans_barang as beli_barang ,barang_nama as beli_brg_n, " _
                            & "CONCAT(CAST(trans_qty AS CHAR),' ',trans_satuan) as beli_qty , trans_harga_retur as beli_harga, trans_diskon as beli_disc1, " _
                            & "@subt:=trans_harga_retur*trans_qty as subtotal, @dsk:=@subt*(trans_diskon/100) as beli_disctot, @subt-@dsk as beli_jml " _
                            & "FROM data_pembelian_retur_trans LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                            & "WHERE trans_faktur='" & innofaktur & "' AND trans_status=1"

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.nota_returbeli.rdlc"
                        .SetParameters(New ReportParameter() {parSupplier, parSupplierAl, parTglFaktur, parJml, parNetto})
                        With ds_transaksi
                            .dt_nota_beli.Clear()
                            filldatatabel(inquery, .dt_nota_beli)
                        End With

                    Case "jual"
                        op_con()
                        Dim sales As String = Nothing
                        Dim inputuser As String = Nothing
                        Try
                            readcommd("SELECT DATE_FORMAT(faktur_tanggal_trans,'%d/%m/%Y'),faktur_term, customer_nama, " _
                                      & "customer_alamat, salesman_nama, if(faktur_upd_alias='',faktur_reg_alias,faktur_upd_alias), " _
                                      & "faktur_disc_rupiah, faktur_netto " _
                                      & "FROM data_penjualan_faktur LEFT JOIN data_customer_master ON customer_kode=faktur_customer " _
                                      & "LEFT JOIN data_salesman_master ON faktur_sales=salesman_kode " _
                                      & "WHERE faktur_kode='" & innofaktur & "'")
                            If rd.HasRows Then
                                tglfak = rd.Item(0)
                                term = rd.Item(1)
                                sup = rd.Item(2)
                                sup_al = rd.Item(3)
                                sales = rd.Item(4)
                                inputuser = rd.Item(5)
                                disk = rd.Item(6)
                                netto = rd.Item(7)
                            End If
                            rd.Close()
                        Catch ex As Exception
                            logError(ex)
                            consoleWriteLine(ex.Message)
                        End Try
                        Dim parTglFaktur As New ReportParameter("parTglFaktur", tglfak)
                        Dim parTerm As New ReportParameter("parTerm", CDate(tglfak).AddDays(term).ToString("dd/MM/yyyy"))
                        Dim parSales As New ReportParameter("parSales", If(sales = Nothing, "NONNONONONO", sales))
                        Dim parCusto As New ReportParameter("parSupplier", sup)
                        Dim parCustoAl As New ReportParameter("parSupplierAl", sup_al)
                        parUserId = New ReportParameter("parUserId", If(inputuser = Nothing, "NOPE", inputuser))
                        Dim parDiskon As New ReportParameter("parDiskon", disk)
                        Dim parNetto As New ReportParameter("parNetto", netto)

                        repdatasource.Name = "ds_nota_jual"
                        repdatasource.Value = ds_transaksi.dt_nota_jual


                        inquery = "SELECT trans_barang as jual_barang ,barang_nama as jual_barang_n, " _
                            & "CONCAT(CAST(trans_qty AS CHAR),' ',trans_satuan) as Jual_qty , trans_harga_jual as jual_harga, " _
                            & "trans_jumlah as jual_jml, trans_disc_rupiah as jual_discrp, trans_disc1 as jual_d1, " _
                            & "trans_disc2 as jual_d2, trans_disc3 as jual_d3, trans_disc4 as jual_d4, " _
                            & "trans_disc5 as jual_d5, trans_qty*trans_harga_jual-trans_jumlah as jual_disctot " _
                            & "FROM data_penjualan_trans LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                            & "WHERE trans_faktur='" & innofaktur & "' AND trans_status<>9"

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.nota_jual.rdlc"
                        .SetParameters(New ReportParameter() {parCusto, parCustoAl, parTerm, parTglFaktur, parSales, parDiskon, parNetto})

                        With ds_transaksi
                            .dt_nota_jual.Clear()
                            filldatatabel(inquery, .dt_nota_jual)
                        End With

                    Case "returjual"
                        op_con()
                        Try
                            readcommd("SELECT DATE_FORMAT(faktur_tanggal_trans,'%d/%m/%Y'), customer_nama, " _
                                      & "customer_alamat, faktur_jumlah, faktur_ppn_persen, faktur_netto " _
                                      & "FROM data_penjualan_retur_faktur " _
                                      & "LEFT JOIN data_customer_master ON customer_kode=faktur_custo " _
                                      & "WHERE faktur_kode_bukti='" & innofaktur & "'")
                            If rd.HasRows Then
                                tglfak = rd.Item(0)
                                sup = rd.Item(1)
                                sup_al = rd.Item(2)
                                jml = rd.Item(3)
                                ppn = rd.Item(4)
                                netto = rd.Item(5)
                            End If
                            rd.Close()
                        Catch ex As Exception
                            consoleWriteLine(ex.Message)
                        End Try
                        Dim parTglFaktur As New ReportParameter("parTglFaktur", tglfak)
                        Dim parSupplier As New ReportParameter("parSupplier", "A.N. " & sup)
                        Dim parSupplierAl As New ReportParameter("parSupplierAl", sup_al)
                        Dim parJml As New ReportParameter("parJml", jml)
                        Dim parPPN As New ReportParameter("parPPN", ppn)
                        Dim parNetto As New ReportParameter("parNetto", netto)
                        Dim parTitle As New ReportParameter("parTitle", "NOTA RETUR")

                        repdatasource.Name = "ds_nota_beli"
                        repdatasource.Value = ds_transaksi.dt_nota_beli

                        inquery = "SELECT trans_barang as beli_barang ,barang_nama as beli_brg_n, " _
                            & "CONCAT(CAST(trans_qty AS CHAR),' ',trans_satuan) as beli_qty , trans_harga_retur as beli_harga, trans_diskon as beli_disc1, " _
                            & "@subt:=trans_harga_retur*trans_qty as subtotal, @dsk:=@subt*(trans_diskon/100) as beli_disctot, @subt-@dsk as beli_jml " _
                            & "FROM data_penjualan_retur_trans LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                            & "WHERE trans_faktur='" & innofaktur & "'"

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.nota_returbeli.rdlc"
                        .SetParameters(New ReportParameter() {parSupplier, parSupplierAl, parTglFaktur, parJml, parPPN, parNetto, parTitle})
                        With ds_transaksi
                            .dt_nota_beli.Clear()
                            filldatatabel(inquery, .dt_nota_beli)
                        End With
                    Case Else
                        Exit Sub
                End Select
                .SetParameters(New ReportParameter() {parUserId, parNoFaktur})
            End With
            .RefreshReport()
            .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            .ZoomMode = 2
            .ZoomPercent = 100
        End With
    End Sub

    Public Sub do_load()

    End Sub

    Private Sub fr_view_nota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.AppStarting
        repViewerSelector(inlap_type)
        Me.Cursor = Cursors.Default
    End Sub
End Class