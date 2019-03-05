Public Class fr_lap_filter_jual
    Private popupstate As String = "supplier"
    Private lapwintext As String = ""
    Public laptype As String
    Public jenis_sw As Boolean = True
    Public custo_sw As Boolean = True
    Public sales_sw As String = "OFF"
    Public barang_sw As Boolean = False

    Private Sub prcessSW()
        'Custo
        lbl_custo.Visible = custo_sw
        in_custo.Visible = custo_sw
        in_custo_n.Visible = custo_sw

        'Barang
        lbl_barang.Visible = barang_sw
        in_barang.Visible = barang_sw
        in_barang_n.Visible = barang_sw

        'SALES
        If sales_sw = "OFF" Then
            lbl_sales.Visible = False
            in_sales.Visible = False
            in_sales_n.Visible = False
        ElseIf sales_sw = "ON" Or sales_sw = "SUPPLIER" Or sales_sw = "JENISCUSTO" Then
            lbl_sales.Visible = True
            in_sales.Visible = True
            in_sales_n.Visible = True
            If sales_sw = "SUPPLIER" Then
                lbl_sales.Text = "Supplier"
            ElseIf sales_sw = "JENISCUSTO" Then
                lbl_sales.Text = "Jenis"
            End If
        End If
        'JENIS
        lbl_jenis.Visible = jenis_sw
        cb_jenis.Visible = jenis_sw
        'End If

        Me.Text = lapwintext
    End Sub

    Private Sub formSW(tipe As String)
        Select Case tipe
            Case "lapJualNota"
                barang_sw = False
                sales_sw = "OFF"
                prcessSW()

            Case "lapJualCusto", "lapJualCustoNota"
                barang_sw = False
                sales_sw = "OFF"
                prcessSW()

                lbl_custo.Location = lbl_sales.Location
                in_custo.Location = in_sales.Location
                in_custo_n.Location = in_sales_n.Location

            Case "lapJualTgl", "lapJualTanggalNota"
                custo_sw = False
                barang_sw = False
                sales_sw = "OFF"
                prcessSW()

                Me.Size = New Point(591, 189)

            Case "lapJualTipe"
                custo_sw = False
                barang_sw = False
                sales_sw = "JENISCUSTO"
                prcessSW()

            Case "lapJualSales"
                barang_sw = False
                custo_sw = False
                sales_sw = "ON"
                prcessSW()

            Case "lapJualSupplier"
                barang_sw = False
                custo_sw = False
                sales_sw = "SUPPLIER"
                prcessSW()

            Case "lapJualSalesNota"
                barang_sw = False
                custo_sw = False
                sales_sw = "ON"
                prcessSW()

            Case "lapJualBarangSupplier"
                barang_sw = False
                jenis_sw = False
                custo_sw = False
                sales_sw = "SUPPLIER"
                prcessSW()

            Case "lapJualBarangSales"
                barang_sw = False
                jenis_sw = False
                custo_sw = False
                sales_sw = "ON"
                prcessSW()

            Case "lapJualSalesCustoBarang"
                barang_sw = False
                jenis_sw = False
                sales_sw = "ON"
                prcessSW()

        End Select
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "sales"
                q = "SELECT salesman_kode as 'Kode', salesman_nama AS 'Nama' FROM data_salesman_master WHERE salesman_status=1 AND salesman_nama LIKE '{0}%'"
            Case "custo"
                q = "SELECT customer_kode as 'Kode', customer_nama AS 'Nama' FROM data_customer_master WHERE customer_status=1 AND customer_nama LIKE '{0}%'"
            Case "jenis"
                q = "SELECT jenis_kode as 'Kode', CONCAT(UCASE(LEFT(jenis_nama,1)),SUBSTRING(jenis_nama,2)) AS 'Nama Jenis' " _
                    & "FROM data_customer_jenis WHERE jenis_status=1 AND jenis_nama LIKE '{0}%'"
            Case "supplier"
                q = "SELECT supplier_kode AS 'Kode', supplier_nama AS 'Nama' FROM data_supplier_master WHERE supplier_status=1 AND supplier_nama LIKE '{0}%'"
            Case "barang"
                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama' FROM data_barang_master WHERE barang_status=1 AND barang_nama LIKE '{0}%'"
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
                Case "supplier", "sales", "jenis"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    bt_simpanbeli.Focus()
                Case "custo"
                    in_custo.Text = .Cells(0).Value
                    in_custo_n.Text = .Cells(1).Value
                    bt_simpanbeli.Focus()
                Case "barang"
                    in_barang.Text = .Cells(0).Value
                    in_barang_n.Text = .Cells(1).Value
                    bt_simpanbeli.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
    End Sub

    Private Function createQuery(tipe As String) As String
        Dim q As String = ""
        Dim qwh As String = ""
        Dim qreturn As String = ""
        Dim qcolselect As String()

        Dim qnota As String = "SELECT {0} FROM (" _
                              & " SELECT salesman_kode as lap_sales, salesman_nama as lap_sales_n ,customer_kode as lap_custo, customer_nama as lap_custo_n, " _
                              & "  faktur_kode as lap_faktur, faktur_tanggal_trans as lap_tanggal," _
                              & "  if(faktur_ppn_jenis='1', faktur_jumlah-faktur_ppn_persen,faktur_jumlah) as lap_brutto, " _
                              & "  faktur_disc_rupiah as lap_diskon, faktur_ppn_persen as lap_ppn, faktur_netto as lap_jumlah, 'JUAL' as lap_jenis " _
                              & "  FROM data_penjualan_faktur LEFT JOIN data_customer_master ON faktur_customer=customer_kode " _
                              & "  LEFT JOIN data_salesman_master ON salesman_kode=faktur_sales " _
                              & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' AND faktur_ppn_jenis IN ({3}) " _
                              & " UNION " _
                              & " SELECT salesman_kode, salesman_nama, customer_kode, customer_nama, faktur_kode_bukti, faktur_tanggal_trans," _
                              & "  if(faktur_ppn_jenis='1', faktur_jumlah-faktur_ppn_persen,faktur_jumlah) as brutto," _
                              & "  faktur_jumlah-faktur_netto, faktur_ppn_persen, faktur_netto, 'RETUR' as jenis " _
                              & " FROM data_penjualan_retur_faktur LEFT JOIN data_customer_master ON faktur_custo=customer_kode " _
                              & " LEFT JOIN data_salesman_master ON salesman_kode=faktur_sales " _
                              & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' AND faktur_ppn_jenis IN ({3}) " _
                              & ") jual {4} {5}"

        Dim qtk As String = "SELECT {0} FROM (" _
                            & " SELECT customer_kode as lap_custo, customer_nama as lap_custo_n, faktur_kode as lap_faktur, " _
                            & "  faktur_sales lap_sales, salesman_nama lap_sales_n, faktur_tanggal_trans as lap_tanggal, " _
                            & "  IF(faktur_term=0,if(faktur_ppn_jenis='1', faktur_jumlah-faktur_ppn_persen,faktur_jumlah),0) as lap_tunai," _
                            & "  IF(faktur_term<>0,if(faktur_ppn_jenis='1', faktur_jumlah-faktur_ppn_persen,faktur_jumlah),0) as lap_kredit, " _
                            & "  faktur_disc_rupiah as lap_diskon, faktur_ppn_persen as lap_ppn, faktur_netto as lap_jumlah, 'JUAL' as lap_jenis " _
                            & " FROM data_penjualan_faktur LEFT JOIN data_customer_master ON faktur_customer=customer_kode " _
                            & " LEFT JOIN data_salesman_master ON faktur_sales=salesman_kode " _
                            & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' AND faktur_ppn_jenis IN ({3}) " _
                            & " UNION " _
                            & " SELECT faktur_custo, customer_nama, faktur_kode_bukti, faktur_sales, salesman_nama, faktur_tanggal_trans, " _
                            & "  IF(faktur_jen_bayar=2,if(faktur_ppn_jenis='1', faktur_jumlah-faktur_ppn_persen,faktur_jumlah),0) lap_tunai, " _
                            & "  IF(faktur_jen_bayar<>2,if(faktur_ppn_jenis='1', faktur_jumlah-faktur_ppn_persen,faktur_jumlah),0) lap_kredit, " _
                            & "  faktur_jumlah-faktur_netto, faktur_ppn_persen, faktur_netto, 'RETUR' as jenis " _
                            & " FROM data_penjualan_retur_faktur LEFT JOIN data_customer_master ON faktur_custo=customer_kode " _
                            & " LEFT JOIN data_salesman_master ON faktur_sales=salesman_kode " _
                            & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' AND faktur_ppn_jenis IN ({3}) " _
                            & ") jual {4} {5}"

        Dim qbarang As String = "SELECT {0} FROM (" _
                                & " SELECT faktur_sales, faktur_customer,trans_barang, faktur_kode, faktur_tanggal_trans, " _
                                & "  @subtot:=trans_harga_jual*trans_qty as subtot, " _
                                & "  TRUNCATE(@ppn:=IF(faktur_ppn_jenis='1',@subtot*(1-(10/11)),0),2) as ppn, " _
                                & "  IF(faktur_term=0,TRUNCATE(@subtot-@ppn,2),0) as tunai, IF(faktur_term<>0,TRUNCATE(@subtot-@ppn,2),0) as kredit, " _
                                & "  @subtot-trans_jumlah as diskon, trans_jumlah as netto,'JUAL' as jenis " _
                                & " FROM data_penjualan_faktur LEFT JOIN data_penjualan_trans ON faktur_kode=trans_faktur AND trans_status=1 " _
                                & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' AND faktur_ppn_jenis IN ({3}) " _
                                & " UNION " _
                                & " SELECT faktur_sales, faktur_custo,trans_barang, faktur_kode_bukti, faktur_tanggal_trans, " _
                                & "  @subtot:=trans_harga_retur*trans_qty as subtot, " _
                                & "  TRUNCATE(@ppn:=IF(faktur_ppn_jenis='1',@subtot*(1-(10/11)),0),2) as ppn, " _
                                & "  IF(faktur_jen_bayar=2,TRUNCATE(@subtot-@ppn,2),0) as tunai, IF(faktur_jen_bayar<>2,TRUNCATE(@subtot-@ppn,2),0) as kredit, " _
                                & "  @diskon:=@subtot*(trans_diskon/100) as diskon, " _
                                & "  @subtot-@diskon as netto, 'RETUR' as jenis " _
                                & " FROM data_penjualan_retur_faktur " _
                                & " LEFT JOIN data_penjualan_retur_trans ON faktur_kode_bukti=trans_faktur AND trans_status=1 " _
                                & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' AND faktur_ppn_jenis IN ({3}) " _
                                & ") jual {4} {5}"

        Dim qtransbrg As String = "SELECT {0},barang_kode as dlap_barang,barang_nama as dlap_barang_n," _
                                  & "getQTYdetail(barang_kode,IFNULL(SUM(if(jenis='JUAL',qtyjual,NULL)),0),2) as dlap_qty_jual, " _
                                  & "IFNULL(SUM(if(jenis='JUAL',totalnilai,NULL)),0) as dlap_nilai_jual," _
                                  & "getQTYdetail(barang_kode,IFNULL(SUM(if(jenis='RETUR',qtyjual,NULL)),0),2) as dlap_qty_retur," _
                                  & "IFNULL(SUM(if(jenis='RETUR',totalnilai,NULL)),0) as dlap_nilai_retur," _
                                  & "getQTYdetail(barang_kode,IFNULL(SUM(if(jenis='JUAL',qtyjual,qtyjual*-1)),0),2) as dlap_qty_tot," _
                                  & "IFNULL(SUM(if(jenis='JUAL',totalnilai,totalnilai*-1)),0) as dlap_nilai_tot " _
                                  & "FROM( " _
                                  & " SELECT faktur_sales, trans_barang," _
                                  & "  countQTYItem(trans_barang, trans_qty, trans_satuan_type) as qtyjual, " _
                                  & "  @subtot:=(trans_harga_jual*trans_qty) as subtot,@subtot-trans_jumlah as diskon, trans_jumlah as totalnilai," _
                                  & "  'JUAL' as jenis " _
                                  & " FROM data_penjualan_faktur LEFT JOIN data_penjualan_trans ON trans_status=1 AND trans_faktur=faktur_kode " _
                                  & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' AND faktur_ppn_jenis IN ({3}) " _
                                  & " UNION " _
                                  & " SELECT faktur_sales, trans_barang," _
                                  & "  countQTYItem(trans_barang, trans_qty, trans_satuan_type) as qtyretur," _
                                  & "  @subtot:=trans_harga_retur*trans_qty as subtot,@diskon:=@subtot*(trans_diskon/100) as diskon, " _
                                  & "  @subtot-@diskon as totalnilai, 'RETUR' " _
                                  & " FROM data_penjualan_retur_faktur " _
                                  & " LEFT JOIN data_penjualan_retur_trans ON faktur_kode_bukti=trans_faktur AND trans_status=1 " _
                                  & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' AND faktur_ppn_jenis IN ({3}) " _
                                  & ") trans LEFT JOIN data_barang_master ON trans_barang=barang_kode " _
                                  & "{4} {5}"

        Dim qdist As String = "SELECT {0} salesman_kode lap_sales,salesman_nama lap_sales_n, customer_kode lap_custo, customer_nama lap_custo_n,  " _
                              & "CONCAT(REPLACE(REPLACE(customer_alamat,CHAR(13),' '),CHAR(10),' '),' Blok ',IFNULL(customer_alamat_blok,'0'), " _
                              & "' No.',LPAD(customer_alamat_nomor,3,0),' RT. ',LPAD(customer_alamat_rt,3,0),' RW. ',LPAD(customer_alamat_rw,3,0)) lap_custo_al, " _
                              & "customer_kecamatan lap_custo_kec, customer_kabupaten lap_custo_kab, " _
                              & "CONCAT(UCASE(LEFT(jenis_nama,1)),SUBSTRING(jenis_nama,2)) lap_custo_jn, faktur_kode as lap_faktur, " _
                              & "faktur_tanggal_trans lap_tgl, barang_kode lap_barang, barang_nama lap_barang_n, trans_harga_jual lap_harga_jual, " _
                              & "trans_qty lap_qty, trans_satuan lap_sat, trans_harga_jual*trans_qty lap_subtotal, trans_disc1 lap_disc1, trans_disc2 lap_disc2, " _
                              & " trans_disc3 lap_disc3,trans_disc4 lap_disc4, trans_disc5 lap_disc5, trans_disc_rupiah lap_discrp, " _
                              & "(trans_harga_jual*trans_qty)-trans_jumlah as lap_disc_tot, trans_jumlah as lap_jml " _
                              & "FROM data_penjualan_faktur " _
                              & "LEFT join data_penjualan_trans ON faktur_kode=trans_faktur AND trans_status=1 " _
                              & "LEFT JOIN data_salesman_master ON salesman_kode=faktur_sales " _
                              & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                              & "LEFT JOIN data_customer_master ON faktur_customer=customer_kode " _
                              & "LEFT JOIN data_customer_jenis ON jenis_kode=Customer_jenis " _
                              & "WHERE faktur_tanggal_trans BETWEEN '{1}' AND '{2}' AND faktur_status=1 AND faktur_ppn_jenis IN ({3}) {4} {5}"
        Dim qPesanan As String = "SELECT {0} FROM ( " _
                                 & "SELECT j_order_kode pesan_id,j_order_tanggal_trans pesan_tgl_trans, j_order_sales pesan_sales, salesman_nama pesan_sales_n, " _
                                 & "j_order_customer pesan_custo, customer_nama pesan_custo_n, IF(j_order_term=0,'TUNAI','TEMPO') pesan_jenis_bayar, " _
                                 & "j_order_trans_barang pesan_barang, barang_nama pesan_barang_n"

        Dim _tglawal As String = date_tglawal.Value.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = date_tglakhir.Value.ToString("yyyy-MM-dd")

        Select Case tipe
            Case "lapJualPesan"
                qcolselect = {"pesan_id", "pesan_tgl_trans", "pesan_sales", "pesan_sales_n", "pesan_custo", "pesan_custo_n", "pesan_jenis_bayar", "pesan_total",
                             "pesan_status", "pesan_val_user", "pesan_val_tgl", "pesan_fak_jual"}

                q = qPesanan
                Dim whr As New List(Of String)
                If in_sales.Text <> Nothing Or in_custo.Text <> Nothing Then
                    qwh += "AND {0}"
                End If
                If in_sales.Text <> Nothing Then
                    whr.Add("j_order_sales='" & in_sales.Text & "'")
                End If
                If in_custo.Text <> Nothing Then
                    whr.Add("j_order_custo='" & in_custo.Text & "'")
                End If

                qwh = String.Format(qwh, String.Join(" AND ", whr))

            Case "lapJualPesanBarang"

                q = qPesanan
                Dim whr As New List(Of String)
                If in_sales.Text <> Nothing Or in_custo.Text <> Nothing Or in_barang.Text <> Nothing Then
                    qwh += "WHERE {0}"
                End If
                If in_sales.Text <> Nothing Then
                    whr.Add("pesan_sales='" & in_sales.Text & "'")
                End If
                If in_custo.Text <> Nothing Then
                    whr.Add("pesan_custo='" & in_custo.Text & "'")
                End If
                If in_barang.Text <> Nothing Then
                    whr.Add("pesan_barang='" & in_barang.Text & "'")
                End If

                qwh = String.Format(qwh, String.Join(" AND ", whr))

            Case "lapJualNota"
                qcolselect = {
                    "lap_custo", "lap_custo_n", "lap_faktur", "lap_tanggal", "lap_sales", "lap_sales_n",
                    "lap_brutto", "lap_diskon", "lap_ppn",
                    "lap_jumlah", "lap_jenis"
                    }

                q = String.Format(qnota, String.Join(",", qcolselect), _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}", "")

                Dim whr As New List(Of String)
                If cb_jenis.SelectedValue <> Nothing Or in_custo.Text <> Nothing Then
                    qwh += "WHERE {0}"
                End If
                If cb_jenis.SelectedValue <> Nothing Then
                    whr.Add("lap_jenis IN (" & cb_jenis.SelectedValue & ")")
                End If
                If in_custo.Text <> Nothing Then
                    whr.Add("lap_custo='" & in_custo.Text & "'")
                End If

                qwh = String.Format(qwh, String.Join(" AND ", whr))

            Case "lapJualCusto"
                qcolselect = {
                    "lap_custo", "lap_custo_n",
                    "SUM(lap_tunai) as lap_tunai",
                    "SUM(lap_kredit) as lap_brutto",
                    "SUM(lap_diskon) as lap_diskon",
                    "SUM(lap_ppn) as lap_ppn",
                    "SUM(lap_jumlah) as lap_jumlah",
                    "lap_jenis"
                    }
                q = String.Format(qtk, String.Join(",", qcolselect), _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}", "GROUP BY lap_custo, lap_jenis")

                Dim whr As New List(Of String)
                If cb_jenis.SelectedValue <> Nothing Or in_custo.Text <> Nothing Then
                    qwh += "WHERE {0}"
                End If
                If cb_jenis.SelectedValue <> Nothing Then
                    whr.Add("lap_jenis IN (" & cb_jenis.SelectedValue & ")")
                End If
                If in_custo.Text <> Nothing Then
                    whr.Add("lap_custo='" & in_custo.Text & "'")
                End If

                qwh = String.Format(qwh, String.Join(" AND ", whr))

            Case "lapJualSales"
                qcolselect = {
                    "lap_sales", "lap_sales_n",
                    "SUM(lap_brutto) as lap_brutto",
                    "SUM(lap_diskon) as lap_diskon",
                    "SUM(lap_ppn) as lap_ppn",
                    "SUM(lap_jumlah) as lap_jumlah",
                    "lap_jenis"
                    }
                q = String.Format(qnota, String.Join(",", qcolselect), _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}", "GROUP BY lap_sales,lap_jenis")

                Dim whr As New List(Of String)
                If cb_jenis.SelectedValue <> Nothing Or in_sales.Text <> Nothing Then
                    qwh += "WHERE {0}"
                End If
                If cb_jenis.SelectedValue <> Nothing Then
                    whr.Add("lap_jenis IN (" & cb_jenis.SelectedValue & ")")
                End If
                If in_sales.Text <> Nothing Then
                    whr.Add("lap_sales='" & in_custo.Text & "'")
                End If

                qwh = String.Format(qwh, String.Join(" AND ", whr))

            Case "lapJualTgl"
                qcolselect = {
                    "DATE_FORMAT(lap_tanggal,'%Y-%m-%d') lap_tanggal",
                    "SUM(lap_tunai) as lap_tunai",
                    "SUM(lap_kredit) as lap_brutto",
                    "SUM(lap_diskon) as lap_diskon",
                    "SUM(lap_ppn) as lap_ppn",
                    "SUM(lap_jumlah) as lap_jumlah",
                    "lap_jenis"
                    }
                q = String.Format(qtk, String.Join(",", qcolselect), _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}", "GROUP BY lap_tanggal,lap_jenis")

                If cb_jenis.SelectedValue <> Nothing Then
                    qwh += "WHERE lap_jenis IN (" & cb_jenis.SelectedValue & ")"
                End If

            Case "lapJualSupplier"
                qcolselect = {
                    "supplier_kode lap_custo",
                    "supplier_nama as lap_custo_n",
                    "SUM(tunai) as lap_tunai",
                    "SUM(kredit) as lap_brutto",
                    "SUM(diskon) as lap_diskon",
                    "SUM(ppn) as lap_ppn",
                    "SUM(netto) as lap_jumlah",
                    "jenis as lap_jenis"
                    }
                q = String.Format(qbarang, String.Join(",", qcolselect), _tglawal, _tglakhir, cb_pajak.SelectedValue,
                                  "LEFT JOIN data_barang_master ON trans_barang=barang_kode LEFT JOIN data_supplier_master ON supplier_kode=barang_supplier {0}",
                                  "GROUP BY barang_supplier,jenis ORDER BY jenis,supplier_kode")

                Dim whr As New List(Of String)
                If cb_jenis.SelectedValue <> Nothing Or in_sales.Text <> Nothing Then
                    qwh += "WHERE {0}"
                End If
                If cb_jenis.SelectedValue <> Nothing Then
                    whr.Add("jenis IN (" & cb_jenis.SelectedValue & ")")
                End If
                If in_sales.Text <> Nothing Then
                    whr.Add("barang_supplier='" & in_sales.Text & "'")
                End If

                qwh = String.Format(qwh, String.Join(" AND ", whr))

            Case "lapJualTipe"
                qcolselect = {
                    "CONCAT(UCASE(LEFT(jenis_nama,1)),SUBSTRING(jenis_nama,2)) as lap_custo_n",
                    "SUM(lap_tunai) as lap_tunai",
                    "SUM(lap_kredit) as lap_brutto",
                    "SUM(lap_diskon) as lap_diskon",
                    "SUM(lap_ppn) as lap_ppn",
                    "SUM(lap_jumlah) as lap_jumlah",
                    "lap_jenis"
                    }
                q = String.Format(qtk, String.Join(",", qcolselect), _tglawal, _tglakhir, cb_pajak.SelectedValue,
                                  "LEFT JOIN data_customer_master ON lap_custo=customer_kode LEFT JOIN data_customer_jenis ON customer_jenis=jenis_kode {0}",
                                  "GROUP BY jenis_kode,lap_jenis")

                Dim whr As New List(Of String)
                If cb_jenis.SelectedValue <> Nothing Or in_sales.Text <> Nothing Then
                    qwh += "WHERE {0}"
                End If
                If cb_jenis.SelectedValue <> Nothing Then
                    whr.Add("lap_jenis IN (" & cb_jenis.SelectedValue & ")")
                End If
                If in_sales.Text <> Nothing Then
                    whr.Add("jenis_kode='" & in_sales.Text & "'")
                End If

                qwh = String.Format(qwh, String.Join(" AND ", whr))

            Case "lapJualCustoNota"
                qcolselect = {
                     "lap_custo", "lap_custo_n", "lap_faktur", "lap_tanggal", "lap_sales", "lap_sales_n",
                     "lap_brutto", "lap_diskon", "lap_ppn", "lap_jumlah", "lap_jenis"
                     }

                q = String.Format(qnota, String.Join(",", qcolselect), _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}", "")

                Dim whr As New List(Of String)
                If cb_jenis.SelectedValue <> Nothing Or in_custo.Text <> Nothing Then
                    qwh += "WHERE {0}"
                End If
                If cb_jenis.SelectedValue <> Nothing Then
                    whr.Add("lap_jenis IN (" & cb_jenis.SelectedValue & ")")
                End If
                If in_custo.Text <> Nothing Then
                    whr.Add("lap_custo='" & in_custo.Text & "'")
                End If

                qwh = String.Format(qwh, String.Join(" AND ", whr))

            Case "lapJualSalesNota"
                qcolselect = {
                    "lap_sales", "lap_sales_n", "lap_faktur", "lap_tanggal", "lap_custo", "lap_custo_n",
                    "lap_brutto", "lap_diskon", "lap_ppn", "lap_jumlah", "lap_jenis"
                    }
                q = String.Format(qnota, String.Join(",", qcolselect), _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}", "")

                Dim whr As New List(Of String)
                If cb_jenis.SelectedValue <> Nothing Or in_sales.Text <> Nothing Then
                    qwh += "WHERE {0}"
                End If
                If cb_jenis.SelectedValue <> Nothing Then
                    whr.Add("lap_jenis IN (" & cb_jenis.SelectedValue & ")")
                End If
                If in_sales.Text <> Nothing Then
                    whr.Add("lap_sales='" & in_sales.Text & "'")
                End If

                qwh = String.Format(qwh, String.Join(" AND ", whr))

            Case "lapJualTanggalNota"
                qcolselect = {
                   "lap_tanggal",
                   "lap_faktur",
                   "SUM(lap_tunai) as lap_tunai",
                   "SUM(lap_kredit) as lap_brutto",
                   "SUM(lap_diskon) as lap_diskon",
                   "SUM(lap_ppn) as lap_ppn",
                   "SUM(lap_jumlah) as lap_jumlah",
                   "lap_jenis"
                   }
                q = String.Format(qtk, String.Join(",", qcolselect), _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}", "GROUP BY lap_tanggal,lap_faktur")

                If cb_jenis.SelectedValue <> Nothing Then
                    qwh += "WHERE lap_jenis IN (" & cb_jenis.SelectedValue & ")"
                End If

            Case "lapJualBarangSupplier"
                qcolselect = {
                    "supplier_kode as dlap_supplier",
                    "supplier_nama as dlap_supplier_n"
                    }

                q = String.Format(qtransbrg, String.Join(",", qcolselect), _tglawal, _tglakhir, cb_pajak.SelectedValue,
                                  "LEFT JOIN data_supplier_master ON supplier_kode=barang_supplier {0}", "GROUP BY barang_supplier,barang_kode")

                If in_sales.Text <> Nothing Then
                    qwh = "WHERE barang_supplier='" & in_sales.Text & "'"
                End If

            Case "lapJualBarangSales"
                qcolselect = {
                    "salesman_kode as dlap_supplier",
                    "salesman_nama as dlap_supplier_n"
                    }

                q = String.Format(qtransbrg, String.Join(",", qcolselect), _tglawal, _tglakhir, cb_pajak.SelectedValue,
                                  "LEFT JOIN data_salesman_master ON salesman_kode=faktur_sales {0}", "GROUP BY faktur_sales,barang_kode")

                If in_sales.Text <> Nothing Then
                    qwh = "WHERE salesman_kode='" & in_sales.Text & "'"
                End If

            Case "lapJualSalesCustoBarang"
                q = String.Format(qdist, "", _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}", "")

                If in_sales.Text <> Nothing Then
                    qwh += "AND faktur_sales='" & in_sales.Text & "' "
                End If
                If in_custo.Text <> Nothing Then
                    qwh += "AND faktur_customer='" & in_custo.Text & "' "
                End If
        End Select


        qreturn = String.Format(q, qwh)
        consoleWriteLine(qreturn)

        Return qreturn
    End Function

    Private Sub exportData(tipe As String)
        Dim q As String = createQuery(tipe)
        Dim _dt As New DataTable
        Dim _colheader As New List(Of String)
        Dim _outputdir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Inventory\"
        Dim _filename As String = "dataexport" & Today.ToString("yyyyMMdd")
        Dim _respond As Boolean = False
        Dim _svdialog As New SaveFileDialog
        Dim _title As String = ""
        Dim _tglawal As String = date_tglawal.Value.ToString("dd-MM-yyyy")
        Dim _tglakhir As String = date_tglakhir.Value.ToString("dd-MM-yyyy")
        Dim _datefile As String = "(" & date_tglawal.Value.ToString("yyyyMMdd") & "-" & date_tglakhir.Value.ToString("yyyyMMdd") & ")-" & Today.ToString("yyyyMMdd")



        MyBase.Cursor = Cursors.AppStarting

        Select Case tipe
            Case "lapJualNota"
                _colheader.AddRange({"KODE CUSTOMER", "NAMA CUSTOMER", "NO.FAKTUR", "TGL TRANSAKSI", "KODE SALES", "NAMA SALESMAN", "BRUTTO", "DISKON",
                                     "PPN", "JUMLAH", "JENIS"})
                _title = "LAPORAN PENJUALAN PER NOTA " & _tglawal & " s.d. " & _tglakhir
                _filename = "JualNota" & _datefile & ".xlsx"
            Case "lapJualCusto"
                _colheader.AddRange({"KODE CUSTOMER", "NAMA CUSTOMER", "TUNAI", "KREDIT", "DISKON", "PPN", "JUMLAH", "JENIS"})
                _title = "LAPORAN PENJUALAN PER CUSTOMER " & _tglawal & " s.d. " & _tglakhir
                _filename = "JualCustomer" & _datefile & ".xlsx"
            Case "lapJualSales"
                _colheader.AddRange({"KODE SALES", "NAMA SALESMAN", "BRUTTO", "DISKON", "PPN", "JUMLAH", "JENIS"})
                _title = "LAPORAN PENJUALAN PER SALESMAN " & _tglawal & " s.d. " & _tglakhir
                _filename = "JualSalesman" & _datefile & ".xlsx"
            Case "lapJualTgl"
                _colheader.AddRange({"TGL TRANSAKSI", "TUNAI", "KREDIT", "DISKON", "PPN", "JUMLAH", "JENIS"})
                _title = "LAPORAN PENJUALAN PER TANGGAL " & _tglawal & " s.d. " & _tglakhir
                _filename = "JualTanggal" & _datefile & ".xlsx"
            Case "lapJualSupplier"
                _colheader.AddRange({"KODE SUPPLIER", "NAMA SUPPLIER", "TUNAI", "KREDIT", "DISKON", "PPN", "JUMLAH", "JENIS"})
                _title = "LAPORAN PENJUALAN PER SUPPLIER " & _tglawal & " s.d. " & _tglakhir
                _filename = "JualSupplier" & _datefile & ".xlsx"
            Case "lapJualTipe"
                _colheader.AddRange({"TIPE CUSTOMER", "TUNAI", "KREDIT", "DISKON", "PPN", "JUMLAH", "JENIS"})
                _title = "LAPORAN PENJUALAN PER TIPE CUSTOMER " & _tglawal & " s.d. " & _tglakhir
                _filename = "JualTipeCusto" & _datefile & ".xlsx"
            Case "lapJualCustoNota"
                _colheader.AddRange({"KODE CUSTOMER", "NAMA CUSTOMER", "NO.FAKTUR", "TGL TRANSAKSI", "KODE SALES", "NAMA SALESMAN", "BRUTTO", "DISKON",
                                     "PPN", "JUMLAH", "JENIS"})
                _title = "LAPORAN PENJUALAN PER CUSTOMER PER NOTA " & _tglawal & " s.d. " & _tglakhir
                _filename = "JualCustomerNota" & _datefile & ".xlsx"
            Case "lapJualSalesNota"
                _colheader.AddRange({"KODE SALES", "NAMA SALESMAN", "NO.FAKTUR", "TGL TRANSAKSI", "KODE CUSTOMER", "NAMA CUSTOMER", "BRUTTO", "DISKON",
                                     "PPN", "JUMLAH", "JENIS"})
                _title = "LAPORAN PENJUALAN PER SALESMAN PER NOTA " & _tglawal & " s.d. " & _tglakhir
                _filename = "JualSalesNota" & _datefile & ".xlsx"
            Case "lapJualTanggalNota"
                _colheader.AddRange({"TGL.TRANSAKSI", "NO.FAKTUR", "TUNAI", "KREDIT", "DISKON", "PPN", "JUMLAH", "JENIS"})
                _title = "LAPORAN PENJUALAN PER TANGGAL PER NOTA " & _tglawal & " s.d. " & _tglakhir
                _filename = "JualSalesNota" & _datefile & ".xlsx"
            Case "lapJualBarangSupplier"
                _colheader.AddRange({"KODE SUPPLIER", "NAMA SUPPLIER", "KODE BARANG", "NAMA BARANG", "QTY PENJUALAN", "NILAI PENJUALAN", "QTY RETUR", "NILAI RETUR",
                                     "QTY JUAL TOTAL", "NILAI JUAL TOTAL"})
                _title = "LAPORAN PENJUALAN PER SUPPLIER PER BARANG " & _tglawal & " s.d. " & _tglakhir
                _filename = "JualSupplierBrg" & _datefile & ".xlsx"
            Case "lapJualBarangSales"
                _colheader.AddRange({"KODE SALESMAN", "NAMA SALESMAN", "KODE BARANG", "NAMA BARANG", "QTY PENJUALAN", "NILAI PENJUALAN", "QTY RETUR", "NILAI RETUR",
                         "QTY JUAL TOTAL", "NILAI JUAL TOTAL"})
                _title = "LAPORAN PENJUALAN PER SALESMAN PER BARANG " & _tglawal & " s.d. " & _tglakhir
                _filename = "JualSalesBrg" & _datefile & ".xlsx"
            Case "lapJualSalesCustoBarang"
                _colheader.AddRange({"KODE SALESMAN", "NAMA SALESMAN", "KODE CUSTOMER", "NAMA CUSTOMER", "ALAMAT CUSTOMER", "KECAMATAN", "KABUPATEN", "JENIS", "NO.FAKTUR",
                                     "TGL.TRANSAKSI", "KODE BARANG", "NAMA BARANG", "HARGA JUAL", "QTY", "SATUAN", "SUBTOTAL", "DISC1", "DISC2", "DISC3", "DISC4",
                                     "DISC5", "DISCRP", "TOTAL DISKON", "TOTAL"})
                _title = "LAPORAN PENJUALAN DISTRIBUTOR PER SALESMAN " & _tglawal & " s.d. " & _tglakhir
                _filename = "JualDistSalesBrg" & _datefile & ".xlsx"

            Case Else
                Exit Sub
        End Select

        _svdialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        _svdialog.FilterIndex = 1
        _svdialog.FileName = _svdialog.InitialDirectory & _filename
        _svdialog.RestoreDirectory = True
        If _svdialog.ShowDialog = DialogResult.OK Then
            If _svdialog.FileName <> Nothing Then
                _outputdir = IO.Path.GetDirectoryName(_svdialog.FileName)
                _filename = Strings.Replace(_svdialog.FileName, _outputdir, "")
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If

        _dt = getDataTablefromDB(q)

        If exportXlsx(_colheader, _dt, _outputdir, _filename, _title) = True Then
            MessageBox.Show("Export sukses")
            If System.IO.File.Exists(_svdialog.FileName) = True Then
                Process.Start(_svdialog.FileName)
            End If
        Else
            MessageBox.Show("Export gagal")
        End If

        MyBase.Cursor = Cursors.Default

    End Sub

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

    Private Sub fr_lap_filter_jual_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim _dialogres As Windows.Forms.DialogResult = MessageBox.Show("Tutup Form?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _dialogres = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
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

    Private Sub fr_pesan_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            Else
                bt_batalbeli.PerformClick()
            End If
        End If
    End Sub

    'LOAD
    Private Sub fr_lap_filter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub do_load(jenisTrans As String, judulLap As String, tipeLap As String)
        laptype = tipeLap
        lapwintext = judulLap

        With cb_jenis
            .DataSource = jenis(jenisTrans)
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 2
        End With

        With cb_pajak
            .DataSource = jenis("trans_pajak")
            .DisplayMember = "Text"
            .ValueMember = "Value"
        End With

        date_tglawal.Value = selectperiode.tglawal
        date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)

        formSW(tipeLap)
    End Sub

    'LOAD LAPORAN
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        Cursor = Cursors.WaitCursor
        Dim x As New fr_lap_beli_nota_view With {
                    .inlap_type = laptype,
                    .Text = lapwintext,
                    .inquery = createQuery(laptype),
                    .intglawal = date_tglawal.Value.ToString("dd/MM/yyyy"),
                    .intglakhir = date_tglakhir.Value.ToString("dd/MM/yyyy")
                }
        x.do_load()
        x.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_exportxl.Click
        exportData(laptype)
    End Sub

    'UI
    '------------- POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_sales_n.Focused Or in_custo_n.Focused Or in_barang_n.Focused Then
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

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyUp
        If e.KeyCode = Keys.Enter Then
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_KeyDown_1(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            'consoleWriteLine("fuck")
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            Dim x As TextBox
            Select Case popupstate
                Case "supplier"
                    x = in_sales_n
                Case "sales"
                    x = in_sales_n
                Case "jenis"
                    x = in_sales_n
                Case "custo"
                    x = in_custo_n
                Case "barang"
                    x = in_barang_n
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

    '-------------- INPUT
    Private Sub date_tglawal_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglawal.KeyUp
        keyshortenter(date_tglakhir, e)
    End Sub

    Private Sub date_tglawal_ValueChanged(sender As Object, e As EventArgs) Handles date_tglawal.ValueChanged
        date_tglakhir.MinDate = date_tglawal.Value
    End Sub

    Private Sub date_tglakhir_ValueChanged(sender As Object, e As EventArgs) Handles date_tglakhir.ValueChanged
        date_tglawal.MaxDate = date_tglakhir.Value
    End Sub

    Private Sub cb_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_jenis.KeyPress
        If e.KeyChar <> ControlChars.CrLf Then
            e.Handled = True
        End If
    End Sub

    Private Sub in_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales.KeyDown
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_sales_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter
        popPnl_barang.Location = New Point(in_sales_n.Left, in_sales_n.Top + in_sales_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If

        If sales_sw = "SUPPLIER" Then
            popupstate = "supplier"
        ElseIf sales_sw = "JENISCUSTO" Then
            popupstate = "jenis"
        Else
            popupstate = "sales"
        End If

        loadDataBRGPopup(popupstate, in_sales_n.Text)
    End Sub

    Private Sub in_sales_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave, in_custo_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_sales_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp, in_custo_n.KeyUp
        Dim _nxtcontrol As Object
        Dim _kdcontrol As Object
        Select Case sender.Name.ToString
            Case "in_sales_n"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = in_sales
            Case "in_custo_n"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = in_custo
            Case Else
                Exit Sub
        End Select

        If sender.Text = "" And IsNothing(_kdcontrol) = False Then
            _kdcontrol.Text = ""
        End If

        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(_nxtcontrol, e)
        Else
            If e.KeyCode <> Keys.Escape Then
                If popPnl_barang.Visible = False Then
                    popPnl_barang.Visible = True
                End If
                loadDataBRGPopup(popupstate, sender.Text)
            End If
        End If
    End Sub

    Private Sub in_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles in_custo.KeyDown
        keyshortenter(in_custo_n, e)
    End Sub

    Private Sub in_custo_n_Enter(sender As Object, e As EventArgs) Handles in_custo_n.Enter
        popPnl_barang.Location = New Point(in_custo_n.Left, in_custo_n.Top + in_custo_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "custo"
        loadDataBRGPopup(popupstate, in_custo_n.Text)
    End Sub

    Private Sub fr_hutang_bayar_Click(sender As Object, e As EventArgs) Handles MyBase.Click, Panel1.Click, Panel3.Click, lbl_title.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub
End Class