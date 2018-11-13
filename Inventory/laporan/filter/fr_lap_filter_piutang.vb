Public Class fr_lap_filter_piutang
    Private popupstate As String = "supplier"
    Private lapwintext As String = ""
    Public laptype As String
    Public bayar_sw As Boolean = False
    Public custo_sw As Boolean = True
    Public sales_sw As Boolean = True
    Public faktur_sw As Boolean = False
    Public tgltrans_sw As Boolean = True
    Public periode_sw As Boolean = False

    Private Sub prcessSW()
        lbl_sales.Visible = sales_sw
        in_sales.Visible = sales_sw
        in_sales_n.Visible = sales_sw

        lbl_custo.Visible = custo_sw
        in_custo.Visible = custo_sw
        in_custo_n.Visible = custo_sw

        lbl_bayar.Visible = bayar_sw
        cb_bayar.Visible = bayar_sw

        lbl_faktur.Visible = faktur_sw
        in_faktur.Visible = faktur_sw

        lbl_tgl.Visible = tgltrans_sw
        lbl_tgl2.Visible = tgltrans_sw
        date_tglawal.Visible = tgltrans_sw
        date_tglakhir.Visible = tgltrans_sw

        cb_periode.Visible = periode_sw
        lbl_periode.Visible = periode_sw

        Me.Text = lapwintext
    End Sub

    Private Sub formSW(tipe As String)
        Select Case LCase(tipe)
            Case "p_salesnota", "p_saleslengkap2"
                bayar_sw = False
                faktur_sw = False
                prcessSW()

                date_tglawal.MinDate = selectperiode.tglawal

            Case "p_salesbayartanggal"
                bayar_sw = False
                faktur_sw = False
                periode_sw = False
                custo_sw = False
                prcessSW()

                date_tglawal.MinDate = selectperiode.tglawal
                lbl_bayar.Location = New Point(lbl_custo.Left, lbl_custo.Top)
                cb_bayar.Location = New Point(in_custo.Top, in_custo.Top)

            Case "p_kartupiutang"
                bayar_sw = False
                faktur_sw = False
                sales_sw = False
                prcessSW()

                date_tglawal.Enabled = False

            Case "p_kartupiutangsales"
                bayar_sw = False
                faktur_sw = False
                prcessSW()

                date_tglawal.Enabled = False

            Case "p_bayarnota"
                periode_sw = False
                faktur_sw = True
                bayar_sw = True
                prcessSW()

                date_tglawal.Enabled = False

            Case "p_salesglobal"
                periode_sw = False
                custo_sw = False
                bayar_sw = False
                prcessSW()

                date_tglawal.Enabled = False

        End Select
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "sales"
                q = "SELECT salesman_kode AS 'Kode', salesman_nama AS 'Nama' FROM data_salesman_master WHERE salesman_status=1 AND salesman_nama LIKE '{0}%'"
            Case "custo"
                q = "SELECT customer_kode AS 'Kode', customer_nama AS 'Nama' FROM data_customer_Master WHERE customer_status=1 AND customer_nama LIKE '{0}%'"
            Case "faktur"
                q = "SELECT piutang_faktur as 'Kode Faktur', salesman_kode as 'Kode Sales', salesman_nama as 'Salesman', customer_kode as 'Kode Custo', " _
                    & "customer_nama as 'Customer' FROM data_piutang_awal LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode AND faktur_status=1" _
                    & "LEFT JOIN data_salesman_master ON salesman_kode=faktur_sales " _
                    & "LEFT JOIN data_customer_master ON customer_kode=faktur_customer " _
                    & "WHERE piutang_status=1 AND piutang_faktur LIKE '{0}%' {1}"

                Dim qwh As String = ""
                If in_sales.Text <> Nothing Then
                    qwh += "AND faktur_sales='" & in_sales.Text & "' "
                End If
                If in_custo.Text <> Nothing Then
                    qwh += "AND faktur_custo='" & in_custo.Text & "' "
                End If
                q = String.Format(q, "{0}", qwh)
            Case Else
                Exit Sub
        End Select
        consoleWriteLine(String.Format(q, param))
        dt = getDataTablefromDB(String.Format(q, param))

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 135
            .Columns(1).Width = 200
        End With
    End Sub

    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    'If faktur_sw = True Then in_faktur.Focus() Else bt_simpanbeli.Focus()
                Case "custo"
                    in_custo.Text = .Cells(0).Value
                    in_custo_n.Text = .Cells(1).Value

                Case "faktur"
                    in_faktur.Text = .Cells(0).Value
                    in_sales.Text = .Cells(1).Value
                    in_sales_n.Text = .Cells(2).Value
                    in_custo.Text = .Cells(3).Value
                    in_custo_n.Text = .Cells(4).Value
                    'bt_simpanbeli.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        popPnl_barang.Visible = False
    End Sub

    Private Function createQuery(tipe As String) As String
        Dim q As String = ""
        Dim qwh As String = ""
        Dim qreturn As String = ""
        Select Case LCase(tipe)
            Case "p_salesnota"
                'BASED periode,sales,custo;OPT saldo_sisa
                q = "SELECT salesman_kode as psn_sales,salesman_nama as psn_sales_n, customer_kode as psn_custo, customer_nama as psn_sales_n, " _
                    & "ADDDATE(faktur_tanggal_trans,faktur_term) as psn_jt, " _
                    & "piutang_faktur as psn_faktur, if(faktur_tanggal_trans<'{0}',piutang_awal,0) as psn_saldoawal, " _
                    & "if(faktur_tanggal_trans>='{0}',piutang_awal,0) as psn_penjualan, IFNULL(p_trans_nilaibayar,0) as psn_bayar, " _
                    & "IFNULL(p_retur_total,0) as psn_retur, piutang_awal-IFNULL(p_trans_nilaibayar,0)-IFNULL(p_retur_total,0) as psn_sisa " _
                    & "FROM data_piutang_awal " _
                    & "LEFT JOIN ( " _
                    & "SELECT SUM(IFNULL(p_retur_total,0)) as p_retur_total, p_retur_faktur " _
                    & "FROM data_piutang_retur " _
                    & "LEFT JOIN data_penjualan_retur_faktur ON p_retur_bukti_retur=faktur_kode_bukti " _
                    & "WHERE faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND p_retur_status=1 " _
                    & "GROUP BY p_retur_faktur " _
                    & ") retur ON p_retur_faktur=piutang_faktur " _
                    & "LEFT JOIN ( " _
                    & "SELECT SUM(IFNULL(p_trans_nilaibayar,0)) as p_trans_nilaibayar, p_trans_kode_piutang " _
                    & "FROM data_piutang_bayar_trans " _
                    & "LEFT JOIN data_piutang_bayar ON p_trans_bukti=p_bayar_bukti " _
                    & "AND p_bayar_tanggal_bayar BETWEEN '{0}' AND '{1}' AND p_bayar_status=1 " _
                    & "WHERE p_trans_status=1 GROUP BY p_trans_kode_piutang " _
                    & ") bayar ON p_trans_kode_piutang=piutang_faktur " _
                    & "LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode AND faktur_status=1 " _
                    & "LEFT JOIN data_customer_master ON customer_kode=faktur_customer " _
                    & "LEFT JOIN data_salesman_master ON salesman_kode=faktur_sales " _
                    & "WHERE piutang_status=1 {2} " _
                    & "ORDER BY psn_jt, psn_faktur"
                q = String.Format(q, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

                qwh += "AND piutang_idperiode='" & cb_periode.SelectedValue & "' "

                If in_sales.Text <> Nothing Then
                    qwh += "AND faktur_sales='" & in_sales.Text & "' "
                End If
                If in_custo.Text <> Nothing Then
                    qwh += "AND faktur_customer='" & in_custo.Text & "' "
                End If

            Case "p_saleslengkap2"
                q = "SELECT salesman_kode as psl2_sales,salesman_nama as psl2_sales_n, customer_kode as psl2_custo, customer_nama as psl2_sales_n, " _
                    & "faktur_netto+faktur_disc_rupiah as psl2_brutto, faktur_disc_rupiah+faktur_bayar as psl2_potongan, faktur_tanggal_trans as pls2_tgl, " _
                    & "piutang_faktur as psl2_faktur, if(faktur_tanggal_trans<'{0}',piutang_awal,0) as psl2_saldoawal, " _
                    & "if(faktur_tanggal_trans>='{0}',piutang_awal,0) as psl2_penjualan, IFNULL(p_trans_nilaibayar,0) as psl2_bayar, " _
                    & "IFNULL(p_retur_total,0) as psl2_retur, piutang_awal-IFNULL(p_trans_nilaibayar,0)-IFNULL(p_retur_total,0) as psl2_sisa " _
                    & "FROM data_piutang_awal " _
                    & "LEFT JOIN ( " _
                    & "SELECT SUM(IFNULL(p_retur_total,0)) as p_retur_total, p_retur_faktur " _
                    & "FROM data_piutang_retur " _
                    & "LEFT JOIN data_penjualan_retur_faktur ON p_retur_bukti_retur=faktur_kode_bukti " _
                    & "WHERE faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND p_retur_status=1 " _
                    & "GROUP BY p_retur_faktur " _
                    & ") retur ON p_retur_faktur=piutang_faktur " _
                    & "LEFT JOIN ( " _
                    & "SELECT SUM(IFNULL(p_trans_nilaibayar,0)) as p_trans_nilaibayar, p_trans_kode_piutang " _
                    & "FROM data_piutang_bayar_trans " _
                    & "LEFT JOIN data_piutang_bayar ON p_trans_bukti=p_bayar_bukti " _
                    & "AND p_bayar_tanggal_bayar BETWEEN '{0}' AND '{1}' AND p_bayar_status=1 " _
                    & "WHERE p_trans_status=1 GROUP BY p_trans_kode_piutang " _
                    & ") bayar ON p_trans_kode_piutang=piutang_faktur " _
                    & "LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode AND faktur_status=1 " _
                    & "LEFT JOIN data_customer_master ON customer_kode=faktur_customer " _
                    & "LEFT JOIN data_salesman_master ON salesman_kode=faktur_sales " _
                    & "WHERE piutang_status=1 {2} " _
                    & "ORDER BY salesman_nama, customer_nama, faktur_tanggal_trans"
                q = String.Format(q, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

                qwh += "AND piutang_idperiode='" & cb_periode.SelectedValue & "' "

                If in_sales.Text <> Nothing Then
                    qwh += "AND faktur_sales='" & in_sales.Text & "' "
                End If
                If in_custo.Text <> Nothing Then
                    qwh += "AND faktur_customer='" & in_custo.Text & "' "
                End If

            Case "p_salesbayartanggal"
                'BASED sales,jenisbayar, tgl ;OPT 
                q = "SELECT p_bayar_sales as psb_sales, salesman_nama as psb_sales_n, p_bayar_tanggal_bayar as psb_tgl, " _
                    & "sum(p_trans_nilaibayar) as psb_total, p_bayar_jenisbayar as psb_jenisbayar, p_trans_kode_piutang as psb_faktur " _
                    & "FROM data_piutang_bayar LEFT JOIN data_piutang_bayar_trans ON p_bayar_bukti=p_trans_bukti AND p_trans_status=1 " _
                    & "LEFT JOIN data_salesman_master ON p_bayar_sales=salesman_kode " _
                    & "WHERE p_bayar_tanggal_bayar BETWEEN '{0}' AND '{1}' {2} " _
                    & "GROUP BY p_bayar_tanggal_bayar, p_bayar_sales,p_trans_kode_piutang, p_bayar_jenisbayar"
                q = String.Format(q, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

                If in_sales.Text <> Nothing Then
                    qwh += "AND p_bayar_sales='" & in_sales.Text & "' "
                End If
                If cb_bayar.SelectedValue <> "ALL" Then
                    qwh += "AND p_bayar_jenisbayar='" & cb_bayar.SelectedValue & "' "
                End If

            Case "p_kartupiutang"
                'BASED periode,custo;OPT 
                q = "SELECT customer_kode as pk_custo,customer_nama as pk_custo_n, customer_kabupaten as pk_custo_k,tgl as pk_tgl, bukti as pk_no_bukti, " _
                    & "ket as pk_ket, if(jenis='awal',0,debet) as pk_debet,kredit as pk_kredit, " _
                    & "TRUNCATE(if(@change_supplier=customer_nama,(@csum := @csum + (debet-kredit)),(@csum:=(debet-kredit))),2) as pk_saldo, " _
                    & "@change_supplier:=customer_nama " _
                    & "FROM (" _
                    & "SELECT faktur_customer as custo, '{1}' as tgl, '' as bukti, 'SALDO AWAL' as ket, " _
                    & "SUM(IF(faktur_tanggal_trans<'{2}',piutang_awal,0)) as debet, " _
                    & "0 as kredit, 'awal' as jenis, faktur_reg_date as reg_date " _
                    & "FROM data_piutang_awal LEFT JOIN data_penjualan_faktur ON faktur_status=1 AND faktur_kode=piutang_faktur " _
                    & "WHERE piutang_status =1 AND piutang_idperiode={0} GROUP BY faktur_customer " _
                    & "UNION " _
                    & "SELECT faktur_customer as custo,faktur_tanggal_trans as tgl, piutang_faktur as bukti, 'PENJUALAN' as ket, " _
                    & "piutang_awal as debet, 0 as kredit, 'piutang', faktur_reg_date " _
                    & "FROM data_piutang_awal LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode " _
                    & "WHERE piutang_status = 1 AND faktur_tanggal_trans BETWEEN '{2}' AND '{3}' " _
                    & "UNION " _
                    & "SELECT faktur_custo as custo,faktur_tanggal_trans as tgl, faktur_kode_bukti as bukti, 'RETUR PENJUALAN' as ket, " _
                    & "0 as debet, p_retur_total as kredit, 'retur', faktur_reg_date " _
                    & "FROM data_piutang_retur LEFT JOIN data_penjualan_retur_faktur ON p_retur_bukti_retur=faktur_kode_bukti " _
                    & "WHERE p_retur_status = 1 AND faktur_tanggal_trans BETWEEN '{2}' AND '{3}' " _
                    & "UNION " _
                    & "SELECT faktur_customer as custo, p_bayar_tanggal_bayar as tgl, p_bayar_bukti as bukti, " _
                    & "CONCAT('PEMBAYARAN ', p_trans_kode_piutang) as ket,0 as debet,  SUM(p_trans_nilaibayar) as kredit, 'bayar', p_bayar_reg_date " _
                    & "FROM data_piutang_bayar LEFT JOIN data_piutang_bayar_trans ON p_trans_bukti=p_bayar_bukti AND p_trans_status =1 " _
                    & "LEFT JOIN data_penjualan_faktur ON p_trans_kode_piutang=faktur_kode " _
                    & "WHERE p_bayar_status = 1 AND p_bayar_tanggal_bayar BETWEEN '{2}' AND '{3}' " _
                    & "GROUP BY p_bayar_bukti,custo " _
                    & "ORDER BY custo, tgl ASC, reg_date ASC, FIELD(jenis,'awal','piutang','retur','bayar') " _
                    & ") piutang JOIN (SELECT @csum:=0, @change_supplier:='') para " _
                    & "LEFT JOIN data_customer_master ON customer_kode=custo " _
                    & "{4} "
                q = String.Format(q, cb_periode.SelectedValue, date_tglawal.Value.AddDays(-1).ToString("yyyy-MM-dd"), date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

                If in_custo.Text <> Nothing Then
                    qwh += "WHERE customer_kode='" & in_custo.Text & "' "
                End If

            Case "p_kartupiutangsales"
                'BASED periode,custo,sales;OPT 
                q = "SELECT customer_kode as pk_custo,customer_nama as pk_custo_n, customer_kabupaten as pk_custo_k,tgl as pk_tgl, bukti as pk_no_bukti, " _
                    & "salesman_kode as pk_sales, salesman_nama as pk_sales_n, " _
                    & "ket as pk_ket, if(jenis='awal',0,debet) as pk_debet,kredit as pk_kredit, " _
                    & "TRUNCATE(if(@change_supplier=customer_nama,(@csum := @csum + (debet-kredit)),(@csum:=(debet-kredit))),2) as pk_saldo, " _
                    & "@change_supplier:=customer_nama " _
                    & "FROM (" _
                    & "SELECT faktur_customer as custo, faktur_sales as sales, '{1}' as tgl, '' as bukti, 'SALDO AWAL' as ket, " _
                    & "SUM(IF(faktur_tanggal_trans<'{2}',piutang_awal,0)) as debet, " _
                    & "0 as kredit, 'awal' as jenis, faktur_reg_date as reg_date " _
                    & "FROM data_piutang_awal LEFT JOIN data_penjualan_faktur ON faktur_status=1 AND faktur_kode=piutang_faktur " _
                    & "WHERE piutang_status =1 AND piutang_idperiode={0} GROUP BY faktur_customer, faktur_sales " _
                    & "UNION " _
                    & "SELECT faktur_customer as custo, faktur_sales as sales,faktur_tanggal_trans as tgl, piutang_faktur as bukti, 'PENJUALAN' as ket, " _
                    & "piutang_awal as debet, 0 as kredit, 'piutang', faktur_reg_date " _
                    & "FROM data_piutang_awal LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode " _
                    & "WHERE piutang_status = 1 AND faktur_tanggal_trans BETWEEN '{2}' AND '{3}' " _
                    & "UNION " _
                    & "SELECT faktur_custo as custo, faktur_sales as sales ,faktur_tanggal_trans as tgl, faktur_kode_bukti as bukti, 'RETUR PENJUALAN' as ket, " _
                    & "0 as debet, p_retur_total as kredit, 'retur', faktur_reg_date " _
                    & "FROM data_piutang_retur LEFT JOIN data_penjualan_retur_faktur ON p_retur_bukti_retur=faktur_kode_bukti " _
                    & "WHERE p_retur_status = 1 AND faktur_tanggal_trans BETWEEN '{2}' AND '{3}' " _
                    & "UNION " _
                    & "SELECT faktur_customer as custo, faktur_sales as sales, p_bayar_tanggal_bayar as tgl, p_bayar_bukti as bukti, " _
                    & "CONCAT('PEMBAYARAN ', p_trans_kode_piutang) as ket,0 as debet,  SUM(p_trans_nilaibayar) as kredit, 'bayar', p_bayar_reg_date " _
                    & "FROM data_piutang_bayar LEFT JOIN data_piutang_bayar_trans ON p_trans_bukti=p_bayar_bukti AND p_trans_status =1 " _
                    & "LEFT JOIN data_penjualan_faktur ON p_trans_kode_piutang=faktur_kode " _
                    & "WHERE p_bayar_status = 1 AND p_bayar_tanggal_bayar BETWEEN '{2}' AND '{3}' " _
                    & "GROUP BY p_bayar_bukti,custo " _
                    & "ORDER BY sales, custo, tgl ASC, reg_date ASC, FIELD(jenis,'awal','piutang','retur','bayar') " _
                    & ") piutang JOIN (SELECT @csum:=0, @change_supplier:='') para " _
                    & "LEFT JOIN data_customer_master ON customer_kode=custo " _
                    & "LEFT JOIN data_salesman_master ON salesman_kode=sales " _
                    & "{4} "
                q = String.Format(q, cb_periode.SelectedValue, date_tglawal.Value.AddDays(-1).ToString("yyyy-MM-dd"), date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

                Dim whr As New List(Of String)
                If in_custo.Text <> Nothing Or in_sales.Text <> Nothing Then
                    qwh += "WHERE {0}"
                End If
                If in_custo.Text <> Nothing Then
                    whr.Add("customer_kode='" & in_custo.Text & "'")
                End If
                If in_sales.Text <> Nothing Then
                    whr.Add("salesman_kode='" & in_sales.Text & "'")
                End If

                qwh = String.Format(qwh, String.Join(" AND ", whr))

            Case "p_bayarnota"
                'BASED periode,custo,sales ;OPT 
                q = "SELECT * FROM( " _
                    & "SELECT salesman_kode as pbd_sales, salesman_nama as pbd_sales_n,customer_kode as pbd_custo, customer_nama as pdb_custo_n, " _
                    & "piutang_faktur as pbd_faktur, if(@faktur<>piutang_faktur,@ct:=0,@ct:=@ct+1) as count, " _
                    & " faktur_tanggal_trans as pbd_tanggal, " _
                    & "	(CASE WHEN @ct=0 THEN if(faktur_tanggal_trans<'{1}',@sisa:=piutang_awal,0) " _
                    & "		ELSE TRUNCATE(@sisa,2) END) as pbd_saldoawal, " _
                    & "	(CASE WHEN @ct=0 THEN if(faktur_tanggal_trans>='{1}',@sisa:=piutang_awal,0) " _
                    & "		ELSE 0 END) as pbd_jual, " _
                    & "	if(jenis='retur',p_trans_nilaibayar,0) as pbd_retur, if(jenis='bayar',p_trans_nilaibayar,0) as pbd_bayar, " _
                    & "	TRUNCATE(@sisa:= @sisa-p_trans_nilaibayar,2) as pbd_sisa, " _
                    & "	ket as pbd_ket,p_trans_tgl as pbd_tglbayar, DATEDIFF(faktur_tanggal_trans,p_trans_tgl) as pbd_hari,@faktur:=piutang_faktur " _
                    & "FROM ( " _
                    & "SELECT p_trans_kode_piutang, p_trans_nilaibayar, p_bayar_tanggal_bayar as p_trans_tgl, " _
                    & "	CONCAT(p_bayar_bukti,':',p_bayar_jenisbayar) as ket, 'bayar' as jenis, p_bayar_reg_date as reg_date " _
                    & "FROM data_piutang_bayar LEFT JOIN data_piutang_bayar_trans ON p_trans_status=1 AND p_trans_bukti=p_bayar_bukti " _
                    & "WHERE p_bayar_status=1 AND p_bayar_tanggal_bayar BETWEEN '{1}' AND '{2}' " _
                    & "UNION " _
                    & "SELECT p_retur_faktur, p_retur_total, faktur_tanggal_trans, " _
                    & "	CONCAT(faktur_kode_bukti, ':RETUR'), 'retur' as jenis, p_retur_reg_date " _
                    & "FROM data_piutang_retur LEFT JOIN data_penjualan_retur_faktur ON p_retur_bukti_retur=faktur_kode_bukti AND faktur_status=1 " _
                    & "WHERE p_retur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' " _
                    & "ORDER BY p_trans_tgl,reg_date " _
                    & ")transaksi " _
                    & "LEFT JOIN data_piutang_awal ON piutang_faktur=p_trans_kode_piutang AND piutang_status=1 AND piutang_idperiode={0} " _
                    & "LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode AND faktur_status=1 " _
                    & "LEFT JOIN data_customer_master ON customer_kode=faktur_customer " _
                    & "LEFT JOIN data_salesman_master ON salesman_kode=faktur_sales " _
                    & "JOIN (SELECT @ct:=0, @sisa:=0, @faktur:='') para " _
                    & "ORDER BY salesman_nama,customer_nama,piutang_faktur, p_trans_tgl,reg_date,count" _
                    & ") hhh {3}"
                q = String.Format(q, cb_periode.SelectedValue, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

                Dim whr As New List(Of String)
                If in_custo.Text <> Nothing Or in_sales.Text <> Nothing Or in_faktur.Text <> Nothing Or cb_bayar.SelectedValue <> "ALL" Then
                    qwh += "WHERE {0}"
                End If
                If in_custo.Text <> Nothing Then
                    whr.Add("pbd_custo='" & in_custo.Text & "'")
                End If
                If in_sales.Text <> Nothing Then
                    whr.Add("pbd_sales='" & in_sales.Text & "'")
                End If
                If in_faktur.Text <> Nothing Then
                    whr.Add("pbd_faktur='" & in_faktur.Text & "'")
                End If
                If cb_bayar.SelectedValue <> "ALL" Then
                    whr.Add("SUBSTRING_INDEX(ket,':',-1)='" & cb_bayar.SelectedValue & "'")
                End If

                qwh = String.Format(qwh, String.Join(" AND ", whr))

            Case "p_salesglobal"
                'BASED periode,sales ;OPT _>FUK
                q = "SELECT salesman_kode as psg, salesman_nama as psg_sales_n, COUNT(piutang_faktur)+COUNT(IF(faktur_netto-faktur_bayar<>0,faktur_kode,NULL)) as psg_jlFak, " _
                    & "SUM(if(faktur_tanggal_trans<'{0}',piutang_awal,0)) as psg_saldoawal, " _
                    & "SUM(if(faktur_tanggal_trans>='{0}',piutang_awal,0)) as psg_penjualan, " _
                    & "SUM(IFNULL(p_trans_nilaibayar,0)) as psg_bayar, SUM(IFNULL(p_retur_total,0)) as psg_retur, " _
                    & "SUM(piutang_awal)-SUM(IFNULL(p_trans_nilaibayar,0))-SUM(IFNULL(p_retur_total,0)) as psg_sisa, " _
                    & "COUNT(IF(faktur_bayar<>0,faktur_kode,NULL)) as psg_jlFakT, SUM(faktur_bayar) as psg_tunai " _
                    & "FROM data_piutang_awal " _
                    & "LEFT JOIN (" _
                    & "SELECT SUM(IFNULL(p_retur_total,0)) as p_retur_total, p_retur_faktur " _
                    & "FROM data_piutang_retur " _
                    & "LEFT JOIN data_penjualan_retur_faktur ON p_retur_bukti_retur=faktur_kode_bukti " _
                    & "WHERE p_retur_tanggal < '{1}' AND p_retur_status=1 " _
                    & "GROUP BY p_retur_faktur " _
                    & ") retur ON p_retur_faktur=piutang_faktur " _
                    & "LEFT JOIN (" _
                    & "SELECT SUM(IFNULL(p_trans_nilaibayar,0)) as p_trans_nilaibayar, p_trans_kode_piutang " _
                    & "FROM data_piutang_bayar_trans " _
                    & "LEFT JOIN data_piutang_bayar ON p_trans_bukti=p_bayar_bukti " _
                    & "AND p_bayar_tanggal_bayar < '{1}' AND p_bayar_status=1 " _
                    & "WHERE p_trans_status=1 GROUP BY p_trans_kode_piutang " _
                    & ") bayar ON p_trans_kode_piutang=piutang_faktur " _
                    & "LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode " _
                    & "LEFT JOIN data_salesman_master ON faktur_sales=salesman_kode " _
                    & "WHERE piutang_status=1 AND faktur_status=1 AND faktur_tanggal_trans<'{1}' {2}" _
                    & "GROUP BY salesman_kode "
                q = String.Format(q, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

                If in_sales.Text <> Nothing Then
                    qwh += "AND faktur_sales='" & in_sales.Text & "' "
                End If
        End Select

        qreturn = String.Format(q, qwh)
        consoleWriteLine(qreturn)

        Return qreturn
    End Function

    'DRAG FORM
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, lbl_title.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, lbl_title.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, lbl_title.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick, lbl_title.DoubleClick
        CenterToScreen()
    End Sub

    'CLOSE
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbeli.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    'LOAD
    Private Sub fr_lap_filter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub do_load(judulLap As String, tipeLap As String)
        laptype = tipeLap
        lapwintext = judulLap

        With cb_periode
            .DataSource = jenis("periode")
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedValue = selectperiode.id
        End With
        With cb_bayar
            .DataSource = jenis("bayarpiutang")
            .DisplayMember = "Text"
            .ValueMember = "Value"
        End With
        date_tglawal.Value = selectperiode.tglawal
        date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)

        lbl_periodedata.Text = main.strip_periode.Text
        formSW(tipeLap)
        'prcessSW()
    End Sub

    Private Sub fr_lap_filter_hutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'LOAD LAPORAN
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        Dim x As New fr_view_piutang With {
                    .Text = lapwintext
                }
        x.setVar(laptype, createQuery(laptype), date_tglawal.Value.ToString("dd/MM/yyyy") & " S.d " & date_tglakhir.Value.ToString("dd/MM/yyyy"))
        x.do_load()
        x.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_exportxl.Click

    End Sub

    'UI
    Private Sub fr_hutang_bayar_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub

    '------------- POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_sales_n.Focused Or in_faktur.Focused Or in_custo_n.Focused Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub dgv_listbarang_CellContentDBLClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellDoubleClick
        If e.RowIndex >= 0 Then
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            Dim x As TextBox
            Select Case popupstate
                Case "sales"
                    x = in_sales_n
                Case "custo"
                    x = in_custo_n
                Case "faktur"
                    x = in_faktur
                Case Else
                    x = Nothing
                    x.Dispose()
                    Exit Sub
            End Select
            x.Text += e.KeyChar
            e.Handled = True
            x.Focus()
            x.Select(x.TextLength, x.TextLength)
        End If
    End Sub

    Private Sub cb_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_periode.KeyPress, cb_bayar.KeyPress
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    Private Sub date_tglawal_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglawal.KeyUp
        keyshortenter(date_tglakhir, e)
    End Sub

    Private Sub date_tglawal_ValueChanged(sender As Object, e As EventArgs) Handles date_tglawal.ValueChanged
        date_tglakhir.MinDate = date_tglawal.Value
    End Sub

    Private Sub date_tglakhir_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglakhir.KeyUp
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub date_tglakhir_ValueChanged(sender As Object, e As EventArgs) Handles date_tglakhir.ValueChanged
        date_tglawal.MaxDate = date_tglakhir.Value
    End Sub

    Private Sub cb_periode_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_periode.SelectionChangeCommitted
        'readcommd("SELECT tutupbk_periode_tglawal, tutupbk_periode_tglakhir FROM data_tutup_buku WHERE tutupbk_status=1 AND tutupbk_id='" & cb_periode.SelectedValue & "'")
        'If rd.HasRows Then
        '    'date_tglawal.MaxDate = rd.Item(1)
        '    'date_tglawal.MinDate = rd.Item(0)
        '    'date_tglakhir.MaxDate = rd.Item(1)
        '    'date_tglakhir.MinDate = rd.Item(0)
        '    date_tglawal.Value = rd.Item(0)
        '    date_tglakhir.Value = rd.Item(1)
        'End If
        'rd.Close()

        'date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales.KeyDown
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter
        popPnl_barang.Location = New Point(in_sales_n.Left, in_sales_n.Top + in_sales_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "sales"
        loadDataBRGPopup("sales", in_sales_n.Text)
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(bt_simpanbeli, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("sales", in_sales_n.Text)
        End If
    End Sub

    Private Sub in_supplier_n_TextChanged(sender As Object, e As EventArgs) Handles in_sales_n.TextChanged
        If in_sales_n.Text = "" Then
            in_sales.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub in_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles in_custo.KeyDown
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_custo_n_Enter(sender As Object, e As EventArgs) Handles in_custo_n.Enter
        popPnl_barang.Location = New Point(in_custo_n.Left, in_custo_n.Top + in_custo_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "custo"
        loadDataBRGPopup("custo", in_custo_n.Text)
    End Sub

    Private Sub in_custo_n_Leave(sender As Object, e As EventArgs) Handles in_custo_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_custo_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_custo_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(bt_simpanbeli, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("custo", in_custo_n.Text)
        End If
    End Sub

    Private Sub in_custo_n_TextChanged(sender As Object, e As EventArgs) Handles in_custo_n.TextChanged
        If in_custo_n.Text = "" Then
            in_custo.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub in_faktur_Enter(sender As Object, e As EventArgs) Handles in_faktur.Enter
        popPnl_barang.Location = New Point(in_faktur.Left, in_faktur.Top + in_faktur.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "faktur"
        loadDataBRGPopup("faktur", in_faktur.Text)
    End Sub

    Private Sub in_faktur_Leave(sender As Object, e As EventArgs) Handles in_faktur.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_faktur_KeyUp(sender As Object, e As KeyEventArgs) Handles in_faktur.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(bt_simpanbeli, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("faktur", in_faktur.Text)
        End If
    End Sub

    Private Sub in_faktur_TextChanged(sender As Object, e As EventArgs) Handles in_faktur.TextChanged

    End Sub
End Class