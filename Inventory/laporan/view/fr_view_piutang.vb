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

                        'inquery = "SELECT salesman_nama as psn_sales_n, faktur_customer as psn_custo, customer_nama as psn_custo_n, " _
                        '        & "ADDDATE(faktur_tanggal_trans,faktur_term) as psn_jt, " _
                        '        & "piutang_faktur as psn_faktur, if(faktur_tanggal_trans<'{0}',piutang_awal,0) as psn_saldoawal, " _
                        '        & "if(faktur_tanggal_trans>='{0}',piutang_awal,0) as psn_penjualan, IFNULL(p_trans_nilaibayar,0) as psn_bayar, " _
                        '        & "IFNULL(p_retur_total,0) as psn_retur, piutang_awal-IFNULL(p_trans_nilaibayar,0)-IFNULL(p_retur_total,0) as psn_sisa " _
                        '        & "FROM data_piutang_awal " _
                        '        & "LEFT JOIN (" _
                        '        & "SELECT SUM(IFNULL(p_retur_total,0)) as p_retur_total, p_retur_faktur " _
                        '        & "FROM data_piutang_retur " _
                        '        & "LEFT JOIN data_penjualan_retur_faktur ON p_retur_bukti_retur=faktur_kode_bukti " _
                        '        & "WHERE p_retur_tanggal < '{1}' AND p_retur_status=1 " _
                        '        & "GROUP BY p_retur_faktur" _
                        '        & ") retur ON p_retur_faktur=piutang_faktur " _
                        '        & "LEFT JOIN (" _
                        '        & "SELECT SUM(IFNULL(p_trans_nilaibayar,0)) as p_trans_nilaibayar, p_trans_kode_piutang " _
                        '        & "FROM data_piutang_bayar_trans " _
                        '        & "LEFT JOIN data_piutang_bayar ON p_trans_bukti=p_bayar_bukti " _
                        '        & "AND p_bayar_tanggal_bayar < '{1}' AND p_bayar_status=1 " _
                        '        & "WHERE p_trans_status=1 GROUP BY p_trans_kode_piutang " _
                        '        & ") bayar ON p_trans_kode_piutang=piutang_faktur " _
                        '        & "LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode " _
                        '        & "LEFT JOIN data_salesman_master ON faktur_sales=salesman_kode " _
                        '        & "LEFT JOIN data_customer_master ON faktur_customer=customer_kode " _
                        '        & "WHERE piutang_status=1 AND faktur_tanggal_trans<'{1}' " _
                        '        & "ORDER BY psn_jt, psn_faktur"

                        'inquery = String.Format(inquery, DateSerial(selectedperiode.Year, selectedperiode.Month, 1), DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0))

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.piutang_salesnota.rdlc"

                        With ds_hutangpiutang
                            .dt_piutang_sales_nota.Clear()
                            filldatatabel(inquery, .dt_piutang_sales_nota)
                        End With
                    Case "p_saleslengkap2"
                        repdatasource.Name = "ds_piutang_salesl2"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_sales_lengkap2

                        'inquery = "SELECT salesman_nama as psl2_sales_n, faktur_customer as psl2_custo, customer_nama as psl2_custo_n, " _
                        '    & "faktur_tanggal_trans as psl2_tgl, faktur_kode as psl2_faktur, " _
                        '    & "faktur_netto+faktur_disc_rupiah as psl2_brutto, faktur_disc_rupiah as psl2_potongan, " _
                        '    & "if(faktur_tanggal_trans<'{0}',faktur_netto,0) as psl2_piutang, " _
                        '    & "if(faktur_tanggal_trans>='{0}',faktur_netto,0) as psl2_penjualan, " _
                        '    & "IFNULL(faktur_bayar,0)+IFNULL(p_trans_nilaibayar,0) as psl2_bayar, IFNULL(p_retur_total,0) as psl2_retur, " _
                        '    & "faktur_netto-(IFNULL(faktur_bayar,0)+IFNULL(p_trans_nilaibayar,0)+IFNULL(p_retur_total,0)) as psl2_sisa " _
                        '    & "FROM data_piutang_awal " _
                        '    & "LEFT JOIN ( " _
                        '    & "SELECT SUM(IFNULL(p_retur_total,0)) as p_retur_total, p_retur_faktur " _
                        '    & "FROM data_piutang_retur " _
                        '    & "LEFT JOIN data_penjualan_retur_faktur ON p_retur_bukti_retur=faktur_kode_bukti " _
                        '    & "WHERE p_retur_tanggal < '{1}' AND p_retur_status=1 " _
                        '    & "GROUP BY p_retur_faktur " _
                        '    & ") retur ON p_retur_faktur=piutang_faktur " _
                        '    & "LEFT JOIN ( " _
                        '    & "SELECT SUM(IFNULL(p_trans_nilaibayar,0)) as p_trans_nilaibayar, p_trans_kode_piutang " _
                        '    & "FROM data_piutang_bayar_trans " _
                        '    & "LEFT JOIN data_piutang_bayar ON p_trans_bukti=p_bayar_bukti " _
                        '    & "AND p_bayar_tanggal_bayar < '{1}' AND p_bayar_status=1 " _
                        '    & "WHERE p_trans_status=1 GROUP BY p_trans_kode_piutang " _
                        '    & ") bayar ON p_trans_kode_piutang=piutang_faktur " _
                        '    & "LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode " _
                        '    & "LEFT JOIN data_salesman_master ON faktur_sales=salesman_kode " _
                        '    & "LEFT JOIN data_customer_master ON faktur_customer=customer_kode " _
                        '    & "WHERE piutang_status=1 AND faktur_tanggal_trans BETWEEN '{2}' AND '{3}' " _
                        '    & "ORDER BY salesman_nama, customer_nama, faktur_tanggal_trans"

                        'Dim tglawal As Date = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
                        'Dim tglakhir As Date = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)

                        'inquery = String.Format(inquery, DateSerial(selectedperiode.Year, selectedperiode.Month, 1).ToString("yyyy-MM-dd"), tglakhir.AddDays(1).ToString("yyyy-MM-dd"), tglawal.ToString("yyyy-MM-dd"), tglakhir.ToString("yyyy-MM-dd"))

                        'consoleWriteLine(inquery)

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.piutang_saleslengkap2.rdlc"
                        With ds_hutangpiutang
                            .dt_piutang_sales_lengkap2.Clear()
                            filldatatabel(inquery, .dt_piutang_sales_lengkap2)
                        End With
                    Case "p_salesbayartanggal"
                        repdatasource.Name = "ds_piutang_salesbayar"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_sales_bayar

                        'inquery = "SELECT p_bayar_sales as psb_sales, salesman_nama as psb_sales_n, p_bayar_tanggal_bayar as psb_tgl, " _
                        '    & "sum(p_trans_nilaibayar) as psb_total, p_bayar_jenisbayar as psb_jenisbayar" _
                        '    & "FROM data_piutang_bayar LEFT JOIN data_piutang_bayar_trans ON p_bayar_bukti=p_trans_bukti AND p_trans_status=1 " _
                        '    & "LEFT JOIN data_salesman_master ON p_bayar_sales=salesman_kode " _
                        '    & "WHERE p_bayar_tanggal_bayar BETWEEN '{0}' AND '{1}' " _
                        '    & "GROUP BY p_bayar_tanggal_bayar, p_bayar_sales, p_bayar_jenisbayar"

                        'Dim tglawal As Date = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
                        'Dim tglakhir As Date = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)

                        'inquery = String.Format(inquery, tglawal.ToString("yyyy-MM-dd"), tglakhir.ToString("yyyy-MM-dd"))

                        .DataSources.Add(repdatasource)
                        .ReportEmbeddedResource = "Inventory.piutang_salesbayartanggal.rdlc"
                        With ds_hutangpiutang
                            .dt_piutang_sales_bayar.Clear()
                            filldatatabel(inquery, .dt_piutang_sales_bayar)
                        End With

                    Case "p_kartupiutang"
                        repdatasource.Name = "ds_piutang_kartupiutang"
                        repdatasource.Value = ds_hutangpiutang.dt_piutang_kartu

                        Dim parTitleLaporan As New ReportParameter("parTitleLaporan", "Kartu Piutang")

                        'inquery = "SELECT customer_kode as pk_custo,customer_nama as pk_custo_n, customer_kabupaten as pk_custo_k,tgl as pk_tgl, bukti as pk_no_bukti, " _
                        '    & "ket as pk_ket, if(jenis='awal',0,debet) as pk_debet,kredit as pk_kredit, " _
                        '    & "TRUNCATE(if(@change_custo=customer_nama,(@csum := @csum + (debet-kredit)),(@csum:=(debet-kredit))),2) as pk_saldo, " _
                        '    & "@change_custo:=customer_nama " _
                        '    & "FROM (" _
                        '    & "SELECT faktur_customer as custo, faktur_sales as sales, '{0}' as tgl, '' as bukti, 'SALDO AWAL {1}' as ket, " _
                        '    & "IFNULL(SUM(piutang_awal),0)-IFNULL(SUM(p_retur_total),0)-IFNULL(SUM(p_trans_nilaibayar),0) as debet, " _
                        '    & "0 as kredit, 'awal' as jenis " _
                        '    & "FROM data_piutang_awal LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode " _
                        '    & "LEFT JOIN (" _
                        '    & "SELECT SUM(p_retur_total) as p_retur_total, p_retur_faktur " _
                        '    & "FROM data_piutang_retur " _
                        '    & "LEFT JOIN data_penjualan_retur_faktur ON p_retur_bukti_retur=faktur_kode_bukti " _
                        '    & "WHERE p_retur_tanggal < '{2}' AND p_retur_status=1 " _
                        '    & "GROUP BY p_retur_faktur " _
                        '    & ") retur ON p_retur_faktur=piutang_faktur " _
                        '    & "LEFT JOIN (" _
                        '    & "SELECT SUM(p_trans_nilaibayar) as p_trans_nilaibayar, p_trans_kode_piutang " _
                        '    & "FROM data_piutang_bayar_trans " _
                        '    & "LEFT JOIN data_piutang_bayar ON p_trans_bukti=p_bayar_bukti AND p_bayar_tanggal_bayar < '{2}' AND p_bayar_status=1 " _
                        '    & "WHERE p_trans_status=1 GROUP BY p_trans_kode_piutang " _
                        '    & ") bayar ON p_trans_kode_piutang=piutang_faktur " _
                        '    & "WHERE piutang_status = 1 AND faktur_tanggal_trans < '{2}' " _
                        '    & "GROUP BY custo " _
                        '    & "UNION " _
                        '    & "SELECT faktur_customer as custo, faktur_sales as sales, faktur_tanggal_trans as tgl, piutang_faktur as bukti, " _
                        '    & "'PENJUALAN' as ket, piutang_awal as debet, 0 as kredit, 'piutang' " _
                        '    & "FROM data_piutang_awal LEFT JOIN data_penjualan_faktur ON  piutang_faktur=faktur_kode " _
                        '    & "WHERE piutang_status = 1 AND faktur_tanggal_trans BETWEEN  '{2}' AND '{3}' " _
                        '    & "UNION " _
                        '    & "SELECT faktur_custo as custo, faktur_sales as sales, faktur_tanggal_trans as tgl, faktur_kode_bukti as bukti, " _
                        '    & "'RETUR PENJUALAN' as ket,0 as debet, p_retur_total as kredit, 'retur' " _
                        '    & "FROM data_piutang_retur LEFT JOIN data_penjualan_retur_faktur ON p_retur_bukti_retur=faktur_kode_bukti " _
                        '    & "WHERE p_retur_status = 1 AND faktur_tanggal_trans BETWEEN '{2}' AND '{3}' " _
                        '    & "UNION " _
                        '    & "SELECT faktur_customer as custo, faktur_sales as sales,p_bayar_tanggal_bayar as tgl, p_bayar_bukti as bukti, " _
                        '    & "CONCAT('PEMBAYARAN ', p_trans_kode_piutang) as ket, 0 as debet, SUM(p_trans_nilaibayar) as kredit, 'bayar' " _
                        '    & "FROM data_piutang_bayar LEFT JOIN data_piutang_bayar_trans ON p_trans_bukti=p_bayar_bukti AND p_trans_status =1 " _
                        '    & "LEFT JOIN data_penjualan_faktur ON p_trans_kode_piutang=faktur_kode " _
                        '    & "WHERE p_bayar_status = 1 AND p_bayar_tanggal_bayar BETWEEN '{2}' AND '{3}' " _
                        '    & "GROUP BY p_bayar_bukti,custo, sales " _
                        '    & "ORDER BY custo, sales, tgl " _
                        '    & ") piutang JOIN (SELECT @csum:=0, @change_custo:='no') para " _
                        '    & "LEFT JOIN data_customer_master ON customer_kode=custo " _
                        '    & "ORDER BY customer_nama,tgl,FIELD(jenis,'awal','piutang','retur','bayar')"

                        'Dim tglawal As Date = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
                        'Dim tglakhir As Date = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)

                        'inquery = String.Format(inquery, tglawal.AddDays(-1).ToString("yyyy-MM-dd"), selectedperiode.ToString("MMMM yyyy"), tglawal.ToString("yyyy-MM-dd"), tglakhir.ToString("yyyy-MM-dd"))

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

                        'inquery = "SELECT customer_kode as pk_custo,customer_nama as pk_custo_n, customer_kabupaten as pk_custo_k,tgl as pk_tgl, bukti as pk_no_bukti, " _
                        '    & "ket as pk_ket, if(jenis='awal',0,debet) as pk_debet,kredit as pk_kredit, salesman_kode as pk_sales, salesman_nama as pk_sales_n, " _
                        '    & "TRUNCATE(if(@change_custo=customer_nama,(@csum := @csum + (debet-kredit)),(@csum:=(debet-kredit))),2) as pk_saldo, " _
                        '    & "@change_custo:=customer_nama " _
                        '    & "FROM (" _
                        '    & "SELECT faktur_customer as custo, faktur_sales as sales, '{0}' as tgl, '' as bukti, 'SALDO AWAL {1}' as ket, " _
                        '    & "IFNULL(SUM(piutang_awal),0)-IFNULL(SUM(p_retur_total),0)-IFNULL(SUM(p_trans_nilaibayar),0) as debet, " _
                        '    & "0 as kredit, 'awal' as jenis " _
                        '    & "FROM data_piutang_awal LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode " _
                        '    & "LEFT JOIN (" _
                        '    & "SELECT SUM(p_retur_total) as p_retur_total, p_retur_faktur " _
                        '    & "FROM data_piutang_retur " _
                        '    & "LEFT JOIN data_penjualan_retur_faktur ON p_retur_bukti_retur=faktur_kode_bukti " _
                        '    & "WHERE p_retur_tanggal < '{2}' AND p_retur_status=1 " _
                        '    & "GROUP BY p_retur_faktur " _
                        '    & ") retur ON p_retur_faktur=piutang_faktur " _
                        '    & "LEFT JOIN (" _
                        '    & "SELECT SUM(p_trans_nilaibayar) as p_trans_nilaibayar, p_trans_kode_piutang " _
                        '    & "FROM data_piutang_bayar_trans " _
                        '    & "LEFT JOIN data_piutang_bayar ON p_trans_bukti=p_bayar_bukti AND p_bayar_tanggal_bayar < '{2}' AND p_bayar_status=1 " _
                        '    & "WHERE p_trans_status=1 GROUP BY p_trans_kode_piutang " _
                        '    & ") bayar ON p_trans_kode_piutang=piutang_faktur " _
                        '    & "WHERE piutang_status = 1 AND faktur_tanggal_trans < '{2}' " _
                        '    & "GROUP BY custo " _
                        '    & "UNION " _
                        '    & "SELECT faktur_customer as custo, faktur_sales as sales, faktur_tanggal_trans as tgl, piutang_faktur as bukti, " _
                        '    & "'PENJUALAN' as ket, piutang_awal as debet, 0 as kredit, 'piutang' " _
                        '    & "FROM data_piutang_awal LEFT JOIN data_penjualan_faktur ON  piutang_faktur=faktur_kode " _
                        '    & "WHERE piutang_status = 1 AND faktur_tanggal_trans BETWEEN  '{2}' AND '{3}' " _
                        '    & "UNION " _
                        '    & "SELECT faktur_custo as custo, faktur_sales as sales, faktur_tanggal_trans as tgl, faktur_kode_bukti as bukti, " _
                        '    & "'RETUR PENJUALAN' as ket,0 as debet, p_retur_total as kredit, 'retur' " _
                        '    & "FROM data_piutang_retur LEFT JOIN data_penjualan_retur_faktur ON p_retur_bukti_retur=faktur_kode_bukti " _
                        '    & "WHERE p_retur_status = 1 AND faktur_tanggal_trans BETWEEN '{2}' AND '{3}' " _
                        '    & "UNION " _
                        '    & "SELECT faktur_customer as custo, faktur_sales as sales,p_bayar_tanggal_bayar as tgl, p_bayar_bukti as bukti, " _
                        '    & "CONCAT('PEMBAYARAN ', p_trans_kode_piutang) as ket, 0 as debet, SUM(p_trans_nilaibayar) as kredit, 'bayar' " _
                        '    & "FROM data_piutang_bayar LEFT JOIN data_piutang_bayar_trans ON p_trans_bukti=p_bayar_bukti AND p_trans_status =1 " _
                        '    & "LEFT JOIN data_penjualan_faktur ON p_trans_kode_piutang=faktur_kode " _
                        '    & "WHERE p_bayar_status = 1 AND p_bayar_tanggal_bayar BETWEEN '{2}' AND '{3}' " _
                        '    & "GROUP BY p_bayar_bukti,custo, sales " _
                        '    & "ORDER BY custo, sales, tgl " _
                        '    & ") piutang JOIN (SELECT @csum:=0, @change_custo:='no') para " _
                        '    & "LEFT JOIN data_customer_master ON customer_kode=custo " _
                        '    & "LEFT JOIN data_salesman_master ON salesman_kode=sales " _
                        '    & "ORDER BY customer_nama,tgl,FIELD(jenis,'awal','piutang','retur','bayar')"

                        'Dim tglawal As Date = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
                        'Dim tglakhir As Date = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)

                        'inquery = String.Format(inquery, tglawal.AddDays(-1).ToString("yyyy-MM-dd"), selectedperiode.ToString("MMMM yyyy"), tglawal.ToString("yyyy-MM-dd"), tglakhir.ToString("yyyy-MM-dd"))

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

                        'inquery = "SELECT salesman_kode as psg, salesman_nama as psg_sales_n, COUNT(faktur_kode) as psg_jlFak, " _
                        '    & "SUM(if(faktur_tanggal_trans<'{0}',piutang_awal,0)) as psg_saldoawal, " _
                        '    & "SUM(if(faktur_tanggal_trans>='{0}',piutang_awal,0)) as psg_penjualan, " _
                        '    & "SUM(IFNULL(p_trans_nilaibayar,0)) as psg_bayar, SUM(IFNULL(p_retur_total,0)) as psg_retur, " _
                        '    & "SUM(piutang_awal)-SUM(IFNULL(p_trans_nilaibayar,0))-SUM(IFNULL(p_retur_total,0)) as psg_sisa, " _
                        '    & "COUNT(IF(faktur_bayar<>0,faktur_kode,NULL)) as psg_jlFakT, SUM(faktur_bayar) as psg_tunai " _
                        '    & "FROM data_piutang_awal " _
                        '    & "LEFT JOIN (" _
                        '    & "SELECT SUM(IFNULL(p_retur_total,0)) as p_retur_total, p_retur_faktur " _
                        '    & "FROM data_piutang_retur " _
                        '    & "LEFT JOIN data_penjualan_retur_faktur ON p_retur_bukti_retur=faktur_kode_bukti " _
                        '    & "WHERE p_retur_tanggal < '{1}' AND p_retur_status=1 " _
                        '    & "GROUP BY p_retur_faktur " _
                        '    & ") retur ON p_retur_faktur=piutang_faktur " _
                        '    & "LEFT JOIN (" _
                        '    & "SELECT SUM(IFNULL(p_trans_nilaibayar,0)) as p_trans_nilaibayar, p_trans_kode_piutang " _
                        '    & "FROM data_piutang_bayar_trans " _
                        '    & "LEFT JOIN data_piutang_bayar ON p_trans_bukti=p_bayar_bukti " _
                        '    & "AND p_bayar_tanggal_bayar < '{1}' AND p_bayar_status=1 " _
                        '    & "WHERE p_trans_status=1 GROUP BY p_trans_kode_piutang " _
                        '    & ") bayar ON p_trans_kode_piutang=piutang_faktur " _
                        '    & "LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode " _
                        '    & "LEFT JOIN data_salesman_master ON faktur_sales=salesman_kode " _
                        '    & "WHERE piutang_status=1 AND faktur_status=1 AND faktur_tanggal_trans<'{1}' " _
                        '    & "GROUP BY salesman_kode "

                        'Dim tglawal As Date = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
                        'Dim tglakhir As Date = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)

                        'inquery = String.Format(inquery, tglawal.ToString("yyyy-MM-dd"), tglakhir.AddDays(1).ToString("yyyy-MM-dd"))

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