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

        cb_periode.Visible = False
        lbl_periode.Visible = False

        Me.Text = lapwintext
    End Sub

    Private Sub formSW(tipe As String)
        Select Case LCase(tipe)
            Case "p_salesnota", "p_saleslengkap2", "p_kartupiutangsales"
                bayar_sw = False
                faktur_sw = False

            Case "p_salesbayartanggal"
                bayar_sw = False
                faktur_sw = False
                periode_sw = False
                custo_sw = False

                'date_tglawal.MinDate = selectperiode.tglawal
                lbl_bayar.Location = New Point(lbl_custo.Left, lbl_custo.Top)
                cb_bayar.Location = New Point(in_custo.Top, in_custo.Top)

            Case "p_kartupiutang", "p_titipancusto"
                bayar_sw = False
                faktur_sw = False
                sales_sw = False

            Case "p_salesglobal"
                custo_sw = False
                bayar_sw = False

            Case "p_bayarnota"
                faktur_sw = True
                bayar_sw = True

        End Select

        Select Case LCase(tipe)
            Case "p_kartupiutangsales", "p_kartupiutang"
                date_tglawal.Enabled = False
        End Select

        prcessSW()
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "sales"
                q = "SELECT salesman_kode AS 'Kode', salesman_nama AS 'Nama' FROM data_salesman_master " _
                    & "WHERE salesman_status=1 AND (salesman_nama LIKE '%{0}%' OR salesman_kode LIKE '%{0}%') LIMIT 250"
            Case "custo"
                q = "SELECT customer_kode AS 'Kode', customer_nama AS 'Nama' FROM data_customer_master " _
                    & "WHERE customer_status=1 AND (customer_nama LIKE '%{0}%' OR customer_kode LIKE '%{0}% ') LIMIT 250"
            Case "faktur"
                q = "SELECT piutang_faktur as 'Kode Faktur', salesman_kode as 'Kode Sales', salesman_nama as 'Salesman', " _
                    & "customer_kode as 'Kode Custo', customer_nama as 'Customer' " _
                    & "FROM data_piutang_awal " _
                    & "LEFT JOIN data_salesman_master ON salesman_kode=piutang_sales " _
                    & "LEFT JOIN data_customer_master ON customer_kode=piutang_custo " _
                    & "WHERE piutang_status=1 AND piutang_faktur LIKE '%{0}%' {1} LIMIT 250"

                Dim qwh As String = ""
                If in_sales.Text <> Nothing Then
                    qwh += "AND piutang_sales='" & in_sales.Text & "' "
                End If
                If in_custo.Text <> Nothing Then
                    qwh += "AND piutang_custo='" & in_custo.Text & "' "
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
        Dim _tglawal As String = date_tglawal.Value.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = date_tglakhir.Value.ToString("yyyy-MM-dd")
        Select Case LCase(tipe)
            Case "p_over2bulan"

            Case "p_salesnota" 'SEMUA PIUTANG YG DI PEGANG SALES(YG BELUM LUNAS)
                'BASED periode,sales,custo;OPT saldo_sisa
                q = "SELECT salesman_kode as psn_sales,salesman_nama as psn_sales_n, customer_kode as psn_custo, customer_nama as psn_custo_n, " _
                    & "p_trans_kode_piutang as psn_faktur, piutang_tgl, piutang_jt as psn_jt, " _
                    & "piutang_awal as psn_saldoawal, piutang_piutang as psn_penjualan, (piutang_bayar*-1)-piutang_tolak as psn_bayar, " _
                    & "piutang_retur*-1 as psn_retur, piutang_awal+piutang_piutang+piutang_retur+piutang_bayar+piutang_tolak as psn_sisa, " _
                    & "piutang_giro psn_giro " _
                    & "FROM ( " _
                    & " SELECT p_trans_kode_piutang,piutang_custo,piutang_sales,piutang_tgl,piutang_jt, " _
                    & "  SUM(if(p_trans_jenis IN ('awal','migrasi') OR p_trans_tgl<'{0}',p_trans_nilai,0)) piutang_awal, " _
                    & "  SUM(if(p_trans_jenis='jual' AND p_trans_tgl>='{0}',p_trans_nilai,0)) piutang_piutang, " _
                    & "  SUM(if(p_trans_jenis='retur' AND p_trans_tgl>='{0}',p_trans_nilai,0)) piutang_retur, " _
                    & "  SUM(if(p_trans_jenis='bayar' AND p_trans_tgl>='{0}',p_trans_nilai,0)) piutang_bayar, " _
                    & "  SUM(if(p_trans_jenis='tolak' AND p_trans_tgl>='{0}',p_trans_nilai,0)) piutang_tolak, " _
                    & "  SUM(p_trans_nilai_giro) piutang_giro " _
                    & "  piutang_tgl_lunas " _
                    & " FROM data_piutang_trans " _
                    & " RIGHT JOIN data_piutang_awal ON p_trans_kode_piutang=piutang_faktur AND piutang_status=1 " _
                    & " WHERE p_trans_status = 1 AND p_trans_tgl<='{1}' AND p_trans_periode='{2}' AND piutang_pajak IN({3}) " _
                    & " GROUP BY p_trans_kode_piutang HAVING SUM(p_trans_nilai)>0 AND SUM(p_trans_nilai_giro)>0 " _
                    & ")piutang " _
                    & "LEFT JOIN data_customer_master ON customer_kode=piutang_custo " _
                    & "LEFT JOIN data_salesman_master ON salesman_kode=piutang_sales " _
                    & "{4} " _
                    & "ORDER BY psn_jt, psn_faktur"
                q = String.Format(q, _tglawal, _tglakhir, selectperiode.id, cb_pajak.SelectedValue, "{0}")

                Dim whr As New List(Of String)
                If in_custo.Text <> Nothing Or in_sales.Text <> Nothing Then
                    qwh += "WHERE {0}"
                End If
                If in_sales.Text <> Nothing Then
                    whr.Add("piutang_sales='" & in_sales.Text & "'")
                End If
                If in_custo.Text <> Nothing Then
                    whr.Add("piutang_custo='" & in_custo.Text & "'")
                End If
                qwh = String.Format(qwh, String.Join(" AND ", whr))

            Case "p_saleslengkap2" 'PIUTANG YG DI PEGANG SALES BERDASARKAN PENJUALAN DALAM KURUN WAKTU TERTENTU (+YG SUDAH LUNAS)
                q = "SELECT salesman_kode as psl2_sales,salesman_nama as psl2_sales_n, customer_kode as psl2_custo, customer_nama as psl2_custo_n, " _
                    & "p_trans_kode_piutang as psl2_faktur, piutang_tgl as psl2_tgl, " _
                    & "faktur_netto+faktur_disc_rupiah as psl2_brutto, faktur_disc_rupiah+faktur_bayar as psl2_potongan, " _
                    & "IF(piutang_awal=0,piutang_piutang,piutang_awal) as psl2_penjualan, piutang_retur*-1 as psl2_retur, " _
                    & "(piutang_bayar*-1)-piutang_tolak as psl2_bayar, " _
                    & "piutang_awal+piutang_piutang+piutang_retur+piutang_bayar+piutang_tolak as psl2_sisa " _
                    & "FROM(" _
                    & " SELECT p_trans_kode_piutang,piutang_custo,piutang_sales,piutang_tgl," _
                    & "  SUM(if(p_trans_jenis IN ('awal','migrasi'),p_trans_nilai,0)) piutang_awal, " _
                    & "  SUM(if(p_trans_jenis='jual',p_trans_nilai,0)) piutang_piutang, " _
                    & "  SUM(if(p_trans_jenis='retur',p_trans_nilai,0)) piutang_retur, " _
                    & "  SUM(if(p_trans_jenis='bayar',p_trans_nilai,0)) piutang_bayar, " _
                    & "  SUM(if(p_trans_jenis='tolak',p_trans_nilai,0)) piutang_tolak, " _
                    & "  MAX(p_trans_tgl) piutang_tglakhir " _
                    & " FROM data_piutang_trans " _
                    & " RIGHT JOIN data_piutang_awal ON p_trans_kode_piutang=piutang_faktur AND piutang_status=1 " _
                    & " WHERE p_trans_status = 1 And p_trans_periode ='{2}' AND piutang_pajak IN({3}) " _
                    & " GROUP BY p_trans_kode_piutang " _
                    & ")piutang " _
                    & "LEFT JOIN data_penjualan_faktur ON faktur_kode=p_trans_kode_piutang AND faktur_status=1 " _
                    & "LEFT JOIN data_customer_master ON customer_kode=piutang_custo " _
                    & "LEFT JOIN data_salesman_master ON salesman_kode=piutang_sales " _
                    & "WHERE faktur_tanggal_trans BETWEEN '{0}' AND '{1}' {4} " _
                    & "ORDER BY customer_nama, faktur_tanggal_trans"
                q = String.Format(q, _tglawal, _tglakhir, selectperiode.id, cb_pajak.SelectedValue, "{0}")

                If in_sales.Text <> Nothing Then
                    qwh += "AND faktur_sales='" & in_sales.Text & "' "
                End If
                If in_custo.Text <> Nothing Then
                    qwh += "AND faktur_customer='" & in_custo.Text & "' "
                End If

            Case "p_salesbayartanggal"
                'BASED sales,jenisbayar, tgl ;OPT 
                q = "SELECT p_bayar_tanggal_bayar as psb_tgl, p_bayar_sales as psb_sales, salesman_nama as psb_sales_n, " _
                    & "p_bayar_bukti psb_bukti, p_trans_kode_piutang as psb_faktur, p_bayar_jenisbayar as psb_jenisbayar, sum(p_trans_nilaibayar) as psb_total, " _
                    & "ref_text psb_status " _
                    & "FROM data_piutang_bayar LEFT JOIN data_piutang_bayar_trans ON p_bayar_bukti=p_trans_bukti AND p_trans_status=1 " _
                    & "LEFT JOIN data_salesman_master ON p_bayar_sales=salesman_kode " _
                    & "LEFT JOIN ref_jenis ON p_bayar_status=ref_kode AND ref_status=1 AND ref_type='status_trans'" _
                    & "WHERE p_bayar_status <> 9 AND p_bayar_tanggal_bayar BETWEEN '{0}' AND '{1}' AND p_bayar_pajak IN({2}) {3} " _
                    & "GROUP BY p_bayar_tanggal_bayar, p_bayar_sales,p_trans_kode_piutang, p_bayar_jenisbayar"
                q = String.Format(q, _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}")

                If in_sales.Text <> Nothing Then
                    qwh += "AND p_bayar_sales='" & in_sales.Text & "' "
                End If
                If cb_bayar.SelectedValue <> "ALL" Then
                    qwh += "AND p_bayar_jenisbayar='" & cb_bayar.SelectedValue & "' "
                End If

            Case "p_kartupiutang"
                'BASED periode,custo;OPT 
                q = "SELECT hhh.*, customer_nama pk_custo_n, customer_kabupaten pk_custo_k," _
                    & "ROUND(if(@change_supplier=customer_nama,(@csum := @csum + (pk_kredit-pk_debet)),(@csum:=(pk_kredit-pk_debet))),2) pk_saldo, " _
                    & "@change_supplier:=customer_nama " _
                    & "FROM( " _
                    & " SELECT 0 p_trans_id,'' p_trans_kode_piutang,piutang_custo pk_custo,p_trans_tgl pk_tgl," _
                    & "  '' pk_no_bukti,'SALDO AWAL' pk_ket,0 pk_debet,SUM(p_trans_nilai) pk_kredit " _
                    & " FROM data_piutang_trans  " _
                    & " RIGHT JOIN data_piutang_awal ON p_trans_kode_piutang=piutang_faktur AND piutang_status=1 " _
                    & " WHERE p_trans_status = 1 And p_trans_periode ='{0}' AND p_trans_jenis IN ('awal','migrasi') AND piutang_pajak IN ({3}) " _
                    & " GROUP BY piutang_custo " _
                    & " UNION " _
                    & " SELECT p_trans_id,p_trans_kode_piutang,piutang_custo,p_trans_tgl,p_trans_faktur, " _
                    & "  (CASE p_trans_jenis " _
                    & "     WHEN 'jual' THEN 'PENJUALAN' " _
                    & "     WHEN 'retur' THEN 'RETUR PENJUALAN' " _
                    & "     WHEN 'bayar' THEN CONCAT('PEMBAYARAN ',p_trans_faktur) " _
                    & "     WHEN 'tolak' THEN CONCAT('TOLAK ',p_trans_faktur) " _
                    & "     WHEN 'cair' THEN CONCAT('PENCAIRAN BG ',p_trans_faktur) " _
                    & "     ELSE 'ERROR' " _
                    & "  END) ket,if(p_trans_nilai<0,p_trans_nilai*-1,0) debet, " _
                    & "  if(p_trans_nilai>0,p_trans_nilai,0) kredit " _
                    & " FROM data_piutang_trans " _
                    & " RIGHT JOIN data_piutang_awal ON p_trans_kode_piutang=piutang_faktur AND piutang_status=1 " _
                    & " WHERE p_trans_status = 1 And p_trans_periode ='{0}' AND p_trans_jenis NOT IN ('awal','migrasi') AND piutang_pajak IN({3}) " _
                    & " ORDER BY pk_custo,pk_tgl,p_trans_id " _
                    & ")hhh " _
                    & "LEFT JOIN data_customer_master ON customer_kode=pk_custo " _
                    & "JOIN (SELECT @change_supplier:='',@csum:=0) para " _
                    & "WHERE pk_tgl BETWEEN '{1}' AND '{2}' {4}"
                q = String.Format(q, cb_periode.SelectedValue, _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}")

                If in_custo.Text <> Nothing Then
                    qwh += "AND customer_kode='" & in_custo.Text & "' "
                End If

            Case "p_kartupiutangsales"
                'BASED periode,custo,sales;OPT 
                q = "SELECT hhh.*, customer_nama pk_custo_n, customer_kabupaten pk_custo_k,salesman_nama pk_sales_n," _
                    & "ROUND(if(@change_supplier=customer_nama,(@csum := @csum + (pk_kredit-pk_debet)),(@csum:=(pk_kredit-pk_debet))),2) pk_saldo, " _
                    & "@change_supplier:=customer_nama " _
                    & "FROM( " _
                    & " SELECT 0 p_trans_id,'' p_trans_kode_piutang,piutang_custo pk_custo,piutang_sales pk_sales,p_trans_tgl pk_tgl," _
                    & "  '' pk_no_bukti,'SALDO AWAL' pk_ket,0 pk_debet,SUM(p_trans_nilai) pk_kredit " _
                    & " FROM data_piutang_trans  " _
                    & " RIGHT JOIN data_piutang_awal ON p_trans_kode_piutang=piutang_faktur AND piutang_status=1 " _
                    & " WHERE p_trans_status = 1 And p_trans_periode ='{0}' AND p_trans_jenis IN ('awal','migrasi') AND piutang_pajak IN ({3}) " _
                    & " GROUP BY piutang_custo,piutang_sales " _
                    & " UNION " _
                    & " SELECT p_trans_id,p_trans_kode_piutang,piutang_custo,piutang_sales,p_trans_tgl,p_trans_faktur, " _
                    & "  (CASE p_trans_jenis " _
                    & "     WHEN 'jual' THEN 'PENJUALAN' " _
                    & "     WHEN 'retur' THEN 'RETUR PENJUALAN' " _
                    & "     WHEN 'bayar' THEN CONCAT('PEMBAYARAN ',p_trans_faktur) " _
                    & "     WHEN 'tolak' THEN CONCAT('TOLAK ',p_trans_faktur) " _
                    & "     WHEN 'cair' THEN CONCAT('PENCAIRAN BG ',p_trans_faktur) " _
                    & "     ELSE 'ERROR' " _
                    & "  END) ket,if(p_trans_nilai<0,p_trans_nilai*-1,0) debet, " _
                    & "  if(p_trans_nilai>0,p_trans_nilai,0) kredit " _
                    & " FROM data_piutang_trans " _
                    & " RIGHT JOIN data_piutang_awal ON p_trans_kode_piutang=piutang_faktur AND piutang_status=1 " _
                    & " WHERE p_trans_status = 1 And p_trans_periode ='{0}' AND p_trans_jenis NOT IN ('awal','migrasi') AND piutang_pajak IN({3}) " _
                    & " ORDER BY pk_custo,pk_sales,pk_tgl,p_trans_id " _
                    & ")hhh " _
                    & "LEFT JOIN data_salesman_master ON salesman_kode=pk_sales " _
                    & "LEFT JOIN data_customer_master ON customer_kode=pk_custo " _
                    & "JOIN (SELECT @change_supplier:='',@csum:=0) para " _
                    & "WHERE pk_tgl BETWEEN '{1}' AND '{2}' {4}"
                q = String.Format(q, cb_periode.SelectedValue, _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}")

                Dim whr As New List(Of String)
                If in_custo.Text <> Nothing Or in_sales.Text <> Nothing Then
                    qwh += "AND {0}"
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
                q = "SELECT p_trans_tgl pbd_tglbayar,piutang_custo pbd_custo,customer_nama pdb_custo_n,piutang_sales pbd_sales,salesman_nama pbd_sales_n," _
                    & " p_trans_kode_piutang pbd_faktur,piutang_tgl pbd_tanggal, piutang_awal pbd_saldoawal, piutang_retur * -1 pbd_retur, " _
                    & " piutang_bayar * -1 pbd_bayar,piutang_tolak pbd_jual,piutang_sisa pbd_sisa, ket pbd_ket, pbd_hari " _
                    & "FROM( " _
                    & "SELECT p_trans_id, p_trans_kode_piutang,piutang_custo,piutang_sales,p_trans_tgl,piutang_tgl," _
                    & " if(@faktur<>p_trans_kode_piutang,@ct:=0,@ct:=@ct+1) as count," _
                    & " p_trans_jenis," _
                    & " if(@ct=0,@sisa:=if(p_trans_jenis IN ('awal','migrasi'),p_trans_nilai,0), ROUND(@sisa,2)) piutang_awal," _
                    & " if(p_trans_jenis='jual',p_trans_nilai,0) piutang_piutang," _
                    & " if(p_trans_jenis='retur',p_trans_nilai,0) piutang_retur," _
                    & " if(p_trans_jenis='bayar',p_trans_nilai,0) piutang_bayar," _
                    & " if(p_trans_jenis='tolak',p_trans_nilai,0) piutang_tolak," _
                    & " ROUND(@sisa:=@sisa+p_trans_nilai,2) piutang_sisa," _
                    & " IF(p_trans_jenis NOT IN('awal','jual','migrasi')," _
                    & " CONCAT(p_trans_faktur,':',(CASE " _
                    & "     WHEN p_trans_jenis='bayar' THEN p_bayar_jenisbayar " _
                    & "     WHEN p_trans_jenis='retur' THEN 'RETUR' " _
                    & "     WHEN p_trans_jenis='tolak' THEN 'BGTOLAK' " _
                    & "     WHEN p_trans_jenis='cair' THEN 'BGCAIR' " _
                    & "     Else '-' END)),'-')	ket,DATEDIFF(p_trans_tgl,piutang_tgl) as pbd_hari, " _
                    & " @faktur:=p_trans_kode_piutang " _
                    & "FROM data_piutang_awal " _
                    & "LEFT JOIN data_piutang_trans ON p_trans_kode_piutang=piutang_faktur AND p_trans_status=1 " _
                    & "LEFT JOIN data_piutang_bayar ON p_trans_faktur=p_bayar_bukti " _
                    & "JOIN(SELECT @sisa:=0,@faktur:='') para " _
                    & "WHERE piutang_status = 1 AND p_trans_periode = '{0}' AND piutang_pajak IN({1}) " _
                    & "ORDER BY p_trans_kode_piutang,p_trans_tgl,p_trans_id " _
                    & ")hhh " _
                    & "LEFT JOIN data_customer_master ON piutang_custo=customer_kode " _
                    & "LEFT JOIN data_salesman_master ON piutang_sales=salesman_kode " _
                    & "WHERE p_trans_jenis NOT IN ('awal','jual','migrasi') {2}"

                q = String.Format(q, cb_periode.SelectedValue, cb_pajak.SelectedValue, "{0}")

                Dim whr As New List(Of String)
                Dim op As Boolean = False

                qwh += "AND p_trans_tgl BETWEEN '" & _tglawal & "' AND '" & _tglakhir & "' {0}{1}"
                If in_custo.Text <> Nothing Or in_sales.Text <> Nothing Or in_faktur.Text <> Nothing Or cb_bayar.SelectedValue <> "ALL" Then
                    op = True
                End If
                If in_custo.Text <> Nothing Then
                    whr.Add("piutang_custo='" & in_custo.Text & "'")
                End If
                If in_sales.Text <> Nothing Then
                    whr.Add("piutang_sales='" & in_sales.Text & "'")
                End If
                If in_faktur.Text <> Nothing Then
                    whr.Add("p_trans_kode_piutang='" & in_faktur.Text & "'")
                End If
                If cb_bayar.SelectedValue <> "ALL" Then
                    whr.Add("SUBSTRING_INDEX(ket,':',-1)='" & cb_bayar.SelectedValue & "'")
                End If

                qwh = String.Format(qwh, IIf(op, "AND ", ""), String.Join(" AND ", whr))

            Case "p_salesglobal"
                'BASED periode,sales ;OPT _>FUK
                q = "SELECT salesman_kode as psg, salesman_nama as psg_sales_n, COUNT(p_trans_kode_piutang) as psg_jlFak, " _
                    & "SUM(piutang_awal) as psg_saldoawal, SUM(piutang_piutang) as psg_penjualan, " _
                    & "SUM(piutang_bayar+piutang_tolak) * -1 as psg_bayar, SUM(piutang_retur*-1) as psg_retur, " _
                    & "SUM(piutang_awal+piutang_piutang+piutang_retur+piutang_bayar+piutang_tolak) as psg_sisa, " _
                    & "COUNT(DISTINCT IF(jenis='tunai',p_trans_kode_piutang,NULL)) as psg_jlFakT, SUM(piutang_tunai) as psg_tunai " _
                    & "FROM ( " _
                    & " SELECT p_trans_kode_piutang,piutang_custo,piutang_sales,piutang_tgl,piutang_jt, " _
                    & "  SUM(if(p_trans_jenis IN ('awal','migrasi') OR p_trans_tgl<'{0}',p_trans_nilai,0)) piutang_awal, " _
                    & "  SUM(if(p_trans_jenis='jual' AND p_trans_tgl>='{0}',p_trans_nilai,0)) piutang_piutang, " _
                    & "  SUM(if(p_trans_jenis='retur' AND p_trans_tgl>='{0}',p_trans_nilai,0)) piutang_retur, " _
                    & "  SUM(if(p_trans_jenis='bayar' AND p_trans_tgl>='{0}',p_trans_nilai,0)) piutang_bayar, " _
                    & "  SUM(if(p_trans_jenis='tolak' AND p_trans_tgl>='{0}',p_trans_nilai,0)) piutang_tolak, " _
                    & "  SUM(p_trans_nilai_giro) piutang_giro, 0 piutang_tunai, " _
                    & "  piutang_tgl_lunas, 'piutang' jenis " _
                    & " FROM data_piutang_trans " _
                    & " RIGHT JOIN data_piutang_awal ON p_trans_kode_piutang=piutang_faktur AND piutang_status=1 " _
                    & " WHERE p_trans_status = 1 AND p_trans_tgl<='{1}' AND p_trans_periode='{2}' AND piutang_pajak IN({3}) " _
                    & " GROUP BY p_trans_kode_piutang HAVING SUM(p_trans_nilai)>0 AND SUM(p_trans_nilai_giro)>=0 " _
                    & " UNION " _
                    & " SELECT faktur_kode, faktur_customer, faktur_sales, faktur_tanggal_trans, ADDDATE(faktur_tanggal_trans,faktur_term), " _
                    & "  0,0,0,0,0,0, SUM(faktur_bayar), NULL, 'tunai' " _
                    & " FROM data_penjualan_faktur " _
                    & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND IF(faktur_ppn_jenis=0,0,1) IN ({2}) AND faktur_term=0" _
                    & ")piutang " _
                    & "LEFT JOIN data_salesman_master ON piutang_sales=salesman_kode " _
                    & "{4} " _
                    & "GROUP BY piutang_sales "
                q = String.Format(q, _tglawal, _tglakhir, selectperiode.id, cb_pajak.SelectedValue, "{0}")

                If in_sales.Text <> Nothing Then
                    qwh += "WHERE faktur_sales='" & in_sales.Text & "' "
                End If

            Case "p_titipancusto"
                'BASED supplier, tgl_akhir;OPT saldo_Sisa
                q = "SELECT titipan.*, customer_nama as hps_supplier_n, " _
                    & "ROUND(if(@change_supplier=customer_nama,(@csum := @csum + (hps_debet-hps_kredit)),(@csum:=(hps_debet-hps_kredit))),2) as hps_sisa, " _
                    & "CONCAT_WS(' : ',p_titip_faktur, UCASE(p_titip_tipe)) hps_bukti, " _
                    & "@change_supplier:=customer_nama " _
                    & "FROM(" _
                    & " SELECT p_titip_id,p_titip_ref hps_supplier,p_titip_tgl hps_tanggal, " _
                    & "  IF(p_titip_nilai>0,p_titip_nilai,0) as hps_debet, IF(p_titip_nilai<0,p_titip_nilai*-1,0) as hps_kredit, " _
                    & "  p_titip_faktur, p_titip_tipe " _
                    & " FROM data_piutang_titip WHERE p_titip_idperiode='{0}' AND p_titip_status=1 " _
                    & " ORDER BY p_titip_ref, p_titip_tgl, p_titip_id " _
                    & ") titipan " _
                    & "LEFT JOIN data_customer_master ON customer_kode=hps_supplier " _
                    & "JOIN (SELECT @csum := 0, @change_supplier:='') para " _
                    & "WHERE hps_tanggal<='{1}' {2}"
                q = String.Format(q, cb_periode.SelectedValue, _tglakhir, "{0}")

                If in_custo.Text <> Nothing Then
                    qwh += "AND customer_kode='" & in_custo.Text & "' "
                End If
        End Select

        qreturn = String.Format(q, qwh)
        consoleWriteLine(qreturn)

        Return qreturn
    End Function

    Private Sub exportData(type As String)
        Dim q As String = createQuery(type)
        Dim _dt As New DataTable
        Dim _colheader As New List(Of String)
        Dim _outputdir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\SIMInvent\"
        Dim _filename As String = "dataexport" & Today.ToString("yyyyMMdd")
        Dim _respond As Boolean = False
        Dim _svdialog As New SaveFileDialog
        Dim _title As String = ""

        MyBase.Cursor = Cursors.WaitCursor

        Select Case type
            Case "p_salesnota"
                _colheader.AddRange({"Kode Salesman", "Nama Salesman", "Kode Customer", "Nama Customer", "Faktur", "Tgl.Transaksi", "Tgl.Jatuh Tempo", "Saldo Awal",
                                     "Penjualan", "Retur", "Pembayaran", "Sisa"})
                _title = "LAPORAN PIUTANG PER SALESMAN PER NOTA"
                _filename = "PiutangSalesNota" & Today.ToString("yyyyMMdd") & ".xlsx"

            Case "p_saleslengkap2"
                _colheader.AddRange({"Kode Salesman", "Nama Salesman", "Kode Customer", "Nama Customer", "Faktur", "Tgl.Faktur",
                                     "Brutto", "Potongan", "Piutang", "Retur", "Pembayaran", "Sisa"})
                _title = "LAPORAN PIUTANG PER SALESMAN PER PENJUALAN"
                _filename = "PiutangSales" & Today.ToString("yyyyMMdd") & ".xlsx"

            Case "p_salesbayartanggal"
                _colheader.AddRange({"Tgl.Transaksi", "Kode Salesman", "Nama Salesman", "No.Bukti", "Faktur", "Jenis Pembayaran", "Jumlah"})
                _title = "LAPORAN BAYAR PIUTANG PER SALESMAN & TANGGAL"
                _filename = "PiutangPembayaranSalesTanggal" & Today.ToString("yyyyMMdd") & ".xlsx"

            Case "p_kartupiutang"
                _colheader.AddRange({"Kode Customer", "Nama Customer", "Tgl. Transaksi", "No.Bukti Transaksi", "Keterangan", "Debit", "Kredit", "Saldo"})
                _title = "KARTU PIUTANG PER CUSTOMER"
                _filename = "KartuPiutang" & Today.ToString("yyyyMMdd") & ".xlsx"
                q = "SELECT pk_custo, pk_custo_n, pk_tgl, pk_no_bukti, pk_ket, pk_debet, pk_kredit, pk_saldo FROM (" & q & ") kartuhutang"

            Case "p_kartupiutangsales"
                _colheader.AddRange({"Kode Salesman", "Nama Salesman", "Kode Customer", "Nama Customer", "Tgl. Transaksi", "No.Bukti Transaksi",
                                     "Keterangan", "Debit", "Kredit", "Saldo"})
                _title = "KARTU PIUTANG PER SALESMAN"
                _filename = "KartuPiutangSales" & Today.ToString("yyyyMMdd") & ".xlsx"
                q = "SELECT pk_sales, pk_sales_n, pk_custo, pk_custo_n, pk_tgl, pk_no_bukti, pk_ket, pk_debet, pk_kredit, pk_saldo FROM (" & q & ") kartuhutang"

            Case "p_bayarnota"
                _colheader.AddRange({"Tgl.Pembayaran", "Kode Customer", "Nama Customer", "Kode Salesman", "Nama Salesman", "No.Faktur Pembelian", "Tgl.Pembelian",
                                      "Saldo Awal", "Retur", "Pembayaran", "Bayar Ditolak", "Sisa", "Keterangan", "Range Hari"})
                _title = "LAPORAN HISTORI PEMBAYARAN PIUTANG"
                _filename = "PembayaranHutang" & Today.ToString("yyyyMMdd") & ".xlsx"

            Case "p_salesglobal"
                _colheader.AddRange({"Kode Salesman", "Nama Salesman", "Jml. Faktur", "Saldo Awal", "Penjualan", "Retur", "Pembayaran", "Sisa", "Jml.Faktur Tunai", "Tunai"})
                _title = "LAPORAN PIUTANG GLOBAL PER SALESMAN"
                _filename = "PiutangGlobalSales" & Today.ToString("yyyyMMdd") & ".xlsx"

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

        With cb_pajak
            .DataSource = jenis("trans_pajak2")
            .DisplayMember = "Text"
            .ValueMember = "Value"
        End With

        date_tglawal.Value = selectperiode.tglawal
        date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        date_tglawal.MinDate = selectperiode.tglawal
        date_tglakhir.MaxDate = selectperiode.tglakhir

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
        Dim _periode As String = ""
        Dim _tglawal As Date = date_tglawal.Value
        Dim _tglakhir As Date = date_tglakhir.Value

        If _tglawal.ToString("MMyyyy") = _tglakhir.ToString("MMyyyy") And _tglawal.Day = 1 And _tglakhir = DateSerial(_tglakhir.Year, _tglakhir.Month + 1, 0) Then
            _periode = _tglawal.ToString("MMMM yyyy")
        Else
            _periode = date_tglawal.Value.ToString("dd/MM/yyyy") & " S.d " & date_tglakhir.Value.ToString("dd/MM/yyyy")
        End If

        x.setVar(laptype, createQuery(laptype), _periode)
        x.do_load()
        x.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_exportxl.Click
        exportData(laptype)
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

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyUp
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

    Private Sub dgv_listbarang_KeyDown_1(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            'consoleWriteLine("fuck")
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub cb_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_periode.KeyPress, cb_bayar.KeyPress
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    '------------- INPUT
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

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales.KeyUp
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

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave, in_custo_n.Leave, in_faktur.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp, in_custo_n.KeyUp, in_faktur.KeyUp
        Dim _nxtcontrol As Object
        Dim _kdcontrol As Object
        Select Case sender.Name.ToString
            Case "in_sales_n"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = in_sales
            Case "in_custo_n"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = in_custo
            Case "in_faktur"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = Nothing
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

    Private Sub in_faktur_Enter(sender As Object, e As EventArgs) Handles in_faktur.Enter
        popPnl_barang.Location = New Point(in_faktur.Left, in_faktur.Top + in_faktur.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "faktur"
        loadDataBRGPopup("faktur", in_faktur.Text)
    End Sub
End Class