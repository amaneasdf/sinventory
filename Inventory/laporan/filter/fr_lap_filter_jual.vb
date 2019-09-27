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
                sales_sw = "ON"

            Case "lapJualCusto", "lapJualCustoNota"
                lbl_custo.Location = lbl_sales.Location
                in_custo.Location = in_sales.Location
                in_custo_n.Location = in_sales_n.Location

            Case "lapJualTgl", "lapJualTanggalNota"
                custo_sw = False

                Me.Size = New Point(591, 189)

            Case "lapJualTipe"
                custo_sw = False
                sales_sw = "JENISCUSTO"

            Case "lapJualSales", "lapJualSalesNota"
                custo_sw = False
                sales_sw = "ON"

            Case "lapJualSupplier"
                custo_sw = False
                sales_sw = "SUPPLIER"

            Case "lapJualBarangSupplier", "lapJualBarangSales", "lapJualBarangCusto"
                jenis_sw = False : custo_sw = False : barang_sw = True
                If tipe = "lapJualBarangSupplier" Then
                    sales_sw = "SUPPLIER"
                ElseIf tipe = "lapJualBarangCusto" Then
                    sales_sw = "CUSTO"
                ElseIf tipe = "lapJualBarangSales" Then
                    sales_sw = "ON"
                End If
                lbl_barang.Location = lbl_custo.Location
                in_barang.Location = in_custo.Location : in_barang_n.Location = in_custo_n.Location

            Case "lapJualSalesCustoBarang"
                jenis_sw = False
                sales_sw = "ON"

        End Select

        prcessSW()
    End Sub

    'LOAD
    Public Sub do_load(judulLap As String, tipeLap As String)
        laptype = tipeLap : lapwintext = judulLap
        lbl_title.Text = judulLap : Me.Text = judulLap

        With cb_jenis
            .DataSource = jenis("transjual")
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
        'date_tglawal.MinDate = selectperiode.tglawal
        'date_tglakhir.MaxDate = selectperiode.tglakhir

        formSW(tipeLap)
        Me.ShowDialog(main)
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "sales"
                q = "SELECT salesman_kode as 'Kode', salesman_nama AS 'Nama' FROM data_salesman_master " _
                    & "WHERE salesman_status=1 AND (salesman_nama LIKE '%{0}%' OR salesman_kode LIKE '%{0}%') LIMIT 250"
            Case "custo", "custo2"
                q = "SELECT customer_kode as 'Kode', customer_nama AS 'Nama' FROM data_customer_master " _
                    & "WHERE customer_status=1 AND (customer_nama LIKE '%{0}%' OR customer_kode LIKE '%{0}%') LIMIT 250"
            Case "jenis"
                q = "SELECT jenis_kode as 'Kode', CONCAT(UCASE(LEFT(jenis_nama,1)),SUBSTRING(jenis_nama,2)) AS 'Nama Jenis' " _
                    & "FROM data_customer_jenis WHERE jenis_status=1 AND (jenis_nama LIKE '%{0}%' OR jenis_kode LIKE '%{0}%') LIMIT 250"
            Case "supplier"
                q = "SELECT supplier_kode AS 'Kode', supplier_nama AS 'Nama' FROM data_supplier_master " _
                    & "WHERE supplier_status=1 AND (supplier_nama LIKE '%{0}%' OR supplier_kode LIKE '%{0}%') LIMIT 250"
            Case "barang"
                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama' FROM data_barang_master " _
                    & "WHERE barang_status=1 AND (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%') LIMIT 250"
            Case Else
                Exit Sub
        End Select

        dt = getDataTablefromDB(String.Format(q, param))

        dgv_listbarang.DataSource = dt
        If dgv_listbarang.ColumnCount >= 2 Then
            dgv_listbarang.Columns(0).Width = 100
            dgv_listbarang.Columns(1).Width = 200
        End If
    End Sub

    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "supplier", "sales", "jenis", "custo2"
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

    'CREATE MYSQL QUERY
    Private Function createQuery(tipe As String) As String
        Dim q As String = ""
        Dim qwh As String = ""
        Dim qreturn As String = ""

        'TODO : MOVE MYSQL QUERY TO MYSQL STORED PROCEDURE (?)
        Dim _tglawal As String = date_tglawal.Value.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = date_tglakhir.Value.ToString("yyyy-MM-dd")

        Select Case tipe

            Case "lapJualNota", "lapJualTgl", "lapJualSales", "lapJualCusto", "lapJualTipe", "lapJualCustoNota", "lapJualSalesNota", "lapJualTanggalNota"
                Dim _whrArr As New List(Of String)
                Dim _tipe As String = ""

                If Not String.IsNullOrWhiteSpace(in_sales.Text) Then
                    If tipe = "lapJualTipe" Then
                        _whrArr.Add(String.Format("jenis_kode='{0}'", in_sales.Text))
                    Else
                        _whrArr.Add(String.Format("faktur_sales='{0}'", in_sales.Text))
                    End If
                End If
                If Not String.IsNullOrWhiteSpace(in_custo.Text) Then _whrArr.Add(String.Format("faktur_customer='{0}'", in_custo.Text))
                If Not cb_jenis.SelectedValue = Nothing Then _whrArr.Add(String.Format("jenis IN({0})", cb_jenis.SelectedValue))

                If {"lapJualCustoNota", "lapJualSalesNota"}.Contains(tipe) Then : _tipe = "nota"
                ElseIf tipe = "lapJualTanggalNota" Then : _tipe = "tanggalnota"
                ElseIf tipe = "lapJualNota" Then : _tipe = "notav2"
                ElseIf tipe = "lapJualTgl" Then : _tipe = "tanggal"
                ElseIf tipe = "lapJualSales" Then : _tipe = "sales"
                ElseIf tipe = "lapJualCusto" Then : _tipe = "custo"
                ElseIf tipe = "lapJualTipe" Then : _tipe = "tipe"
                Else : Return String.Empty : Exit Function
                End If

                Return CreateQueryJualNota("report", _tipe, date_tglawal.Value, date_tglakhir.Value, cb_pajak.SelectedValue, _whrArr)
                Exit Function

            Case "lapJualSupplier"
                q = "SELECT barang_supplier lap_custo, GetMasterNama('supplier', barang_supplier) lap_custo_n, jenis lap_jenis, " _
                    & " SUM(IF(faktur_jenis_bayar!='TUNAI',faktur_brutto,0)) lap_brutto, " _
                    & " SUM(IF(faktur_jenis_bayar='TUNAI',faktur_brutto,0)) lap_tunai, " _
                    & " SUM(faktur_diskon) lap_diskon, SUM(faktur_ppn) lap_ppn, SUM(faktur_netto) lap_jumlah " _
                    & "FROM( " _
                    & " SELECT 'JUAL' jenis, faktur_kode, trans_barang faktur_barang, " _
                    & "  IF(faktur_term=0, 'TUNAI', 'TEMPO') faktur_jenis_bayar, " _
                    & "  ROUND((trans_harga_jual*trans_qty)*IF(faktur_ppn_jenis=1, 10/11, 1),2) faktur_brutto, " _
                    & "  ROUND(CountTotalDiskonJualItemByID(trans_id)*IF(faktur_ppn_jenis=1, 10/11, 1),2) faktur_diskon, " _
                    & "  ROUND((CASE faktur_ppn_jenis " _
                    & "         WHEN 1 THEN (trans_harga_jual*trans_qty)*(1-(10/11))-CountTotalDiskonJualItemByID(trans_id)*(1-(10/11)) " _
                    & "         WHEN 2 THEN ((trans_harga_jual*trans_qty)-CountTotalDiskonJualItemByID(trans_id))*0.1 " _
                    & "         ELSE 0 END),2) faktur_ppn, " _
                    & "  ROUND(trans_jumlah*IF(faktur_ppn_jenis=2, 1.1, 1),2) faktur_netto " _
                    & " FROM data_penjualan_faktur " _
                    & " LEFT JOIN data_penjualan_trans ON faktur_kode=trans_faktur AND trans_status=1 " _
                    & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}' AND faktur_ppn_jenis IN ({2}) " _
                    & " UNION " _
                    & " SELECT 'RETUR', faktur_kode_bukti, trans_barang, ref_text, " _
                    & "  ROUND((trans_harga_retur*trans_qty)*IF(faktur_ppn_jenis=1, 10/11, 1),2) faktur_brutto, " _
                    & "  ROUND(((trans_harga_retur*trans_qty)*(trans_diskon/100))*IF(faktur_ppn_jenis=1, 10/11, 1),2) faktur_diskon, " _
                    & "  ROUND((CASE faktur_ppn_jenis " _
                    & "         WHEN 1 THEN (trans_harga_retur*trans_qty)*(1-(10/11))-(trans_harga_retur*trans_qty)*(trans_diskon/100)*(1-(10/11)) " _
                    & "         WHEN 2 THEN (trans_harga_retur*trans_qty)*(1-(trans_diskon/100)) * 0.1 " _
                    & "         ELSE 0 END),2) faktur_ppn, " _
                    & "  ROUND((trans_harga_retur*trans_qty)*(1-(trans_diskon/100))*IF(faktur_ppn_jenis=2,1.1,1),2) faktur_netto " _
                    & " FROM data_penjualan_retur_faktur " _
                    & " LEFT JOIN data_penjualan_retur_trans ON faktur_kode_bukti=trans_faktur AND trans_status=1 " _
                    & " LEFT JOIN ref_jenis ON ref_status=1 AND ref_type='bayar_retur' AND ref_kode=faktur_jen_bayar " _
                    & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}' AND faktur_ppn_jenis IN ({2}) " _
                    & ")penjualan {3}"

                Dim whr As New List(Of String)
                If cb_jenis.SelectedValue <> Nothing Then
                    whr.Add("jenis IN (" & cb_jenis.SelectedValue & ")")
                End If
                If in_sales.Text <> Nothing Then
                    whr.Add("barang_supplier='" & in_sales.Text & "'")
                End If
                If whr.Count > 0 Then qwh = " WHERE " + String.Join(" AND ", whr)

                Return String.Format(q, date_tglawal.Value, date_tglakhir.Value, cb_pajak.SelectedValue,
                                     "LEFT JOIN data_barang_master ON faktur_barang=barang_kode " + qwh + " GROUP BY barang_supplier, jenis")
                Exit Function

            Case "lapJualBarangSupplier", "lapJualBarangSales"
                Dim _whrArr As New List(Of String)
                Dim _tipe As String = ""

                If Not String.IsNullOrWhiteSpace(in_sales.Text) Then
                    If tipe = "lapJualBarangSales" Then
                        _whrArr.Add(String.Format("faktur_sales='{0}'", in_sales.Text))
                    ElseIf {"lapJualBarangSupplier"}.Contains(tipe) Then
                        _whrArr.Add(String.Format("barang_supplier='{0}'", in_sales.Text))
                    ElseIf tipe = "lapJualBarangCusto" Then
                        _whrArr.Add(String.Format("faktur_customer='{0}'", in_sales.Text))
                    End If
                End If
                If Not String.IsNullOrWhiteSpace(in_barang.Text) Then
                    _whrArr.Add(String.Format("trans_barang='{0}'", in_barang.Text))
                End If

                If tipe = "lapJualBarangSupplier" Then : _tipe = "supplier"
                ElseIf tipe = "lapJualBarangSales" Then : _tipe = "sales"
                ElseIf tipe = "lapJualBarangCusto" Then : _tipe = "custo"
                Else : Return String.Empty : Exit Function
                End If

                Return CreateQueryJualBarang("report", _tipe, date_tglawal.Value, date_tglakhir.Value, cb_pajak.SelectedValue, _whrArr)
                Exit Function

            Case "lapJualSalesCustoBarang"
                Dim whr As New List(Of String)
                Dim _colselect As New List(Of String)
                Dim _qjoin, _qwh, _qorder As String

                q = "SELECT {0} FROM(" _
                    & " SELECT faktur_kode, faktur_tanggal_trans, faktur_customer, faktur_sales, faktur_gudang, faktur_ppn_jenis, " _
                    & "  trans_barang, trans_harga_jual, trans_qty, trans_satuan, trans_disc_rupiah, trans_disc1, " _
                    & "  trans_disc2, trans_disc3, trans_disc4, trans_disc5 " _
                    & " FROM data_penjualan_faktur " _
                    & " LEFT JOIN data_penjualan_trans ON faktur_kode=trans_faktur AND trans_status=1 " _
                    & " WHERE faktur_tanggal_trans BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' AND faktur_status=1 AND faktur_ppn_jenis IN ({3}) {4} " _
                    & ")penjualan {5}"

                _colselect.AddRange({"faktur_kode lap_faktur", "faktur_tanggal_trans lap_tgl", "ref_text lap_kat",
                                     "faktur_sales lap_sales", "salesman_nama lap_sales_n",
                                     "faktur_customer lap_custo", "GetMasterNama('custo', faktur_customer) lap_custo_n",
                                     "GetMasterNama('custoalamat', faktur_customer) lap_custo_al",
                                     "GetMasterNama('custokec', faktur_customer) lap_custo_kec",
                                     "GetMasterNama('custokab', faktur_customer) lap_custo_kab",
                                     "GetMasterNama('custojenis', faktur_customer) lap_custo_jn",
                                     "faktur_gudang lap_gudang", "gudang_nama lap_gudang_n",
                                     "trans_barang lap_barang", "barang_nama lap_barang_n",
                                     "trans_harga_jual lap_harga_jual", "trans_qty lap_qty", "trans_satuan lap_sat",
                                     "@subtotal:=trans_harga_jual*trans_qty lap_subtotal", "trans_disc_rupiah lap_discrp",
                                     "trans_disc1 lap_disc1", "trans_disc2 lap_disc2", "trans_disc3 lap_disc3",
                                     "trans_disc4 lap_disc4", "trans_disc5 lap_disc5",
                                     "@discrp:=trans_disc_rupiah*trans_qty lap_discrp_n",
                                     "@disc1:=ROUND(IF(trans_disc1=0, 0, (@subtotal-@discrp) * (trans_disc1/100)),2) lap_disc1_n",
                                     "@disc2:=ROUND(IF(trans_disc2=0, 0, (@subtotal-(@discrp+@disc1)) * (trans_disc2/100)),2) lap_disc2_n",
                                     "@disc3:=ROUND(IF(trans_disc3=0, 0, (@subtotal-(@discrp+@disc1+@disc2)) * (trans_disc3/100)),2) lap_disc3_n",
                                     "@disc4:=ROUND(IF(trans_disc4=0, 0, (@subtotal-(@discrp+@disc1+@disc2+@disc3)) * (trans_disc4/100)),2) lap_disc4_n",
                                     "@disc5:=ROUND(IF(trans_disc5=0, 0, (@subtotal-(@discrp+@disc1+@disc2+@disc3+@disc4)) * (trans_disc5/100)),2) lap_disc5_n",
                                     "ROUND(@discrp+@disc1+@disc2+@disc3+@disc4+@disc5,2) lap_disc_tot",
                                     "(trans_harga_jual*trans_qty)-ROUND(@discrp+@disc1+@disc2+@disc3+@disc4+@disc5,2) lap_jml"})

                If Not String.IsNullOrWhiteSpace(in_sales.Text) Then whr.Add("faktur_sales='" & in_sales.Text & "'")
                If Not String.IsNullOrWhiteSpace(in_custo.Text) Then whr.Add("faktur_customer='" & in_custo.Text & "'")
                If Not String.IsNullOrWhiteSpace(in_barang.Text) Then whr.Add("trans_barang='" & in_barang.Text & "'")

                _qjoin = " LEFT JOIN data_salesman_master ON salesman_kode=faktur_sales " _
                        & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                        & "LEFT JOIN data_barang_gudang ON gudang_kode=faktur_gudang " _
                        & "LEFT JOIN ref_jenis ON ref_status=1 AND ref_type='ppn_trans' AND ref_kode=faktur_ppn_jenis"
                _qwh = IIf(whr.Count > 0, "AND " & String.Join(" AND ", whr), "")
                _qorder = " ORDER BY faktur_tanggal_trans, faktur_kode"

                Return String.Format(q, String.Join(",", _colselect), date_tglawal.Value, date_tglakhir.Value, cb_pajak.SelectedValue, _qwh, _qjoin + _qorder)
            Case Else
                Return String.Empty
        End Select
    End Function

    Private Function CreateQueryJualBarang(TipeOut As String, Grouping As String, StartDate As Date, EndDate As Date,
                                           KategoriPajak As String, Conditional As List(Of String)) As String
        If StartDate = Nothing Or EndDate = Nothing Then
            Throw New ArgumentNullException
        ElseIf StartDate > EndDate Then
            Throw New ArgumentException("StartDate Value cannot be bigger than EndDate value")
        End If

        Dim _q As String = ""
        Dim _selectCol As New List(Of String)
        Dim _ppnType As String = ""
        Dim _qjoin As String = "" : Dim _qwhr As String = "" : Dim _qorder As String = ""

        _q = "SELECT {0} FROM(" _
            & " SELECT 'JUAL' jenis, faktur_kode, faktur_sales, faktur_customer, trans_barang, faktur_ppn_jenis, faktur_term," _
            & "  IF(faktur_term=0, 'TUNAI', 'TEMPO') faktur_jenis_bayar, " _
            & "  countQTYItem(trans_barang, trans_qty, trans_satuan_type) qtybrg, " _
            & "  @subtot:=(trans_harga_jual*trans_qty) subtot, @subtot-trans_jumlah diskon, trans_jumlah totalnilai " _
            & " FROM data_penjualan_faktur LEFT JOIN data_penjualan_trans ON faktur_kode=trans_faktur AND trans_status=1 " _
            & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' AND faktur_ppn_jenis IN ({3}) " _
            & " UNION " _
            & " SELECT 'RETUR', faktur_kode_bukti, faktur_sales, faktur_custo, trans_barang, faktur_ppn_jenis, NULL faktur_term, ref_text, " _
            & "  countQTYItem(trans_barang, trans_qty, trans_satuan_type) qtybrg, " _
            & "  @subtot:=(trans_harga_retur*trans_qty) subtot, @diskon:=@subtot*(trans_diskon/100) diskon, @subtot-@diskon totalnilai " _
            & " FROM data_penjualan_retur_faktur LEFT JOIN data_penjualan_retur_trans ON faktur_kode_bukti=trans_faktur AND trans_status=1 " _
            & " LEFT JOIN ref_jenis ON ref_status=1 AND ref_type='bayar_retur' AND ref_kode=faktur_jen_bayar " _
            & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' AND faktur_ppn_jenis IN ({3}) " _
            & ")penjualan {4}"

        If Not Conditional.Count = 0 Then
            _qwhr = " WHERE " & String.Join(" AND ", Conditional)
        End If

        If Not {"report", "excel"}.Contains(LCase(TipeOut)) Then
            Return String.Empty : Exit Function
        End If

        Select Case LCase(Grouping)
            Case "sales"
                _selectCol.AddRange({"faktur_sales dlap_supplier",
                                     "GetMasterNama('sales', faktur_sales) dlap_supplier_n",
                                     "trans_barang dlap_barang",
                                     "GetMasterNama('barang', trans_barang) dlap_barang_n"
                                    })
                _qorder = " GROUP BY faktur_sales, trans_barang"

            Case "supplier"
                _selectCol.AddRange({"barang_supplier dlap_supplier",
                                     "GetMasterNama('supplier', barang_supplier) dlap_supplier_n",
                                     "trans_barang dlap_barang",
                                     "barang_nama dlap_barang_n"
                                    })
                _qjoin = " LEFT JOIN data_barang_master ON trans_barang=barang_kode"
                _qorder = " GROUP BY barang_supplier, trans_barang"

            Case "custo"
                _selectCol.AddRange({"faktur_custo dlap_supplier",
                                     "GetMasterNama('custo', faktur_custo) dlap_supplier_n",
                                     "trans_barang dlap_barang",
                                     "GetMasterNama('barang', trans_barang) dlap_barang_n"
                                     })
                _qorder = " GROUP BY faktur_custo, trans_barang"

            Case Else
                Return String.Empty : Exit Function
        End Select

        _selectCol.AddRange({"getQTYdetail(trans_barang,IFNULL(SUM(if(jenis='JUAL',qtybrg,NULL)),0),2) dlap_qty_jual",
                              "IFNULL(SUM(if(jenis='JUAL',totalnilai,NULL)),0) dlap_nilai_jual",
                              "getQTYdetail(trans_barang,IFNULL(SUM(if(jenis='RETUR',qtybrg,NULL)),0),2) dlap_qty_retur",
                              "IFNULL(SUM(if(jenis='RETUR',totalnilai,NULL)),0) dlap_nilai_retur",
                              "getQTYdetail(trans_barang,IFNULL(SUM(if(jenis='JUAL',qtybrg,qtybrg*-1)),0),2) dlap_qty_tot",
                              "IFNULL(SUM(if(jenis='JUAL',totalnilai,totalnilai*-1)),0) dlap_nilai_tot"
                            })


        Return String.Format(_q, String.Join(",", _selectCol), StartDate, EndDate, KategoriPajak, _qjoin + _qwhr + _qorder)
    End Function

    Private Function CreateQueryJualNota(TipeOut As String, Grouping As String, StartDate As Date, EndDate As Date,
                                          KategoriPajak As String, Conditional As List(Of String)) As String
        If StartDate = Nothing Or EndDate = Nothing Then
            Throw New ArgumentNullException
        ElseIf StartDate > EndDate Then
            Throw New ArgumentException("StartDate Value cannot be bigger than EndDate value")
        End If

        Dim _q As String = ""
        Dim _selectCol As New List(Of String)
        Dim _ppnType As String = ""
        Dim _qjoin As String = "" : Dim _qwhr As String = "" : Dim _qorder As String = ""

        _q = "SELECT {0} FROM(" _
            & " SELECT 'JUAL' jenis, faktur_kode, faktur_sales, faktur_customer, faktur_tanggal_trans, faktur_term, faktur_ppn_jenis, " _
            & "  IF(faktur_term=0, 'TUNAI', 'TEMPO') faktur_jenis_bayar, " _
            & "  ROUND(IF(faktur_ppn_jenis=1, faktur_jumlah*(10/11), faktur_jumlah),2) faktur_brutto, " _
            & "  ROUND(IF(faktur_ppn_jenis=1, faktur_disc_rupiah*(10/11), faktur_disc_rupiah),2) faktur_diskon, " _
            & "  ROUND(IF(faktur_ppn_jenis=1, faktur_jumlah*(1-(10/11))-faktur_disc_rupiah*(1-(10/11)), faktur_ppn_persen),2) faktur_ppn, " _
            & "  faktur_netto, faktur_bayar " _
            & " FROM data_penjualan_faktur " _
            & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' AND faktur_ppn_jenis IN ({3}) " _
            & " UNION " _
            & " SELECT 'RETUR', faktur_kode_bukti, faktur_sales, faktur_custo, faktur_tanggal_trans, NULL faktur_term, faktur_ppn_jenis, ref_text, " _
            & "  ROUND(IF(faktur_ppn_jenis=1, faktur_jumlah*(10/11),faktur_jumlah),2) faktur_brutto, " _
            & "  ROUND(IF(faktur_ppn_jenis=1, (faktur_jumlah-faktur_netto)*(10/11), faktur_jumlah-(faktur_netto-faktur_ppn_persen)),2) faktur_diskon, " _
            & "  ROUND(IF(faktur_ppn_jenis=1, faktur_jumlah*(1-(10/11))-(faktur_jumlah-faktur_netto)*(1-(10/11)), faktur_ppn_persen),2) faktur_ppn, " _
            & "  faktur_netto , NULL faktur_bayar " _
            & " FROM data_penjualan_retur_faktur " _
            & " LEFT JOIN ref_jenis ON ref_status=1 AND ref_type='bayar_retur' AND ref_kode=faktur_jen_bayar " _
            & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' AND faktur_ppn_jenis IN ({3}) " _
            & ")penjualan {4}"

        If Not Conditional.Count = 0 Then
            _qwhr = " WHERE " & String.Join(" AND ", Conditional)
        End If

        If Not {"report", "excel"}.Contains(LCase(TipeOut)) Then
            Return String.Empty : Exit Function
        End If

        Select Case LCase(Grouping)
            Case "nota"
                _selectCol.AddRange({"faktur_kode lap_faktur",
                                     "faktur_tanggal_trans lap_tanggal",
                                     "jenis lap_jenis",
                                     "ppn.ref_text lap_kat",
                                     "faktur_customer lap_custo",
                                     "GetMasterNama('custo', faktur_customer) lap_custo_n",
                                     "faktur_sales lap_sales",
                                     "GetMasterNama('sales', faktur_sales) lap_sales_n",
                                     "IF(faktur_jenis_bayar!='TUNAI',faktur_brutto,0) lap_brutto",
                                     "IF(faktur_jenis_bayar='TUNAI',faktur_brutto,0) lap_tunai",
                                     "faktur_diskon lap_diskon",
                                     "faktur_ppn lap_ppn",
                                     "faktur_netto lap_jumlah"
                                    })
                _qjoin = " LEFT JOIN ref_jenis ppn ON faktur_ppn_jenis=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans'"
                _qorder = "ORDER BY faktur_tanggal_trans, faktur_kode"

            Case "notav2"
                _selectCol.AddRange({"jenis jual_jenis",
                                     "faktur_kode jual_kode",
                                     "faktur_tanggal_trans jual_tgl",
                                     "ppn.ref_text lap_kat",
                                     "faktur_sales jual_sales",
                                     "GetMasterNama('sales', faktur_sales) jual_sales_n",
                                     "faktur_customer jual_custo",
                                     "GetMasterNama('custo', faktur_customer) jual_custo_n",
                                     "faktur_term jual_term",
                                     "faktur_jenis_bayar jual_jenisbayar",
                                     "faktur_brutto jual_brutto",
                                     "faktur_diskon jual_diskon",
                                     "faktur_ppn jual_ppn",
                                     "faktur_netto jual_netto",
                                     "faktur_bayar jual_bayar"
                                    })
                _qjoin = " LEFT JOIN ref_jenis ppn ON faktur_ppn_jenis=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans'"
                _qorder = "ORDER BY faktur_tanggal_trans, faktur_kode"

            Case "sales", "custo", "tanggal", "tipe", "tanggalnota"
                If LCase(Grouping) = "sales" Then
                    _selectCol.AddRange({"faktur_sales lap_sales",
                                         "GetMasterNama('sales', faktur_sales) lap_sales_n"
                                        })
                    _qorder = " GROUP BY faktur_sales, jenis"

                ElseIf LCase(Grouping) = "custo" Then
                    _selectCol.AddRange({"faktur_customer lap_custo",
                                         "GetMasterNama('custo', faktur_customer) lap_custo_n"
                                        })
                    _qorder = " GROUP BY faktur_customer, jenis"

                ElseIf LCase(Grouping) = "tanggal" Then
                    _selectCol.AddRange({"faktur_tanggal_trans lap_tanggal"})
                    _qorder = " GROUP BY faktur_tanggal_trans, jenis"

                ElseIf LCase(Grouping) = "tipe" Then
                    _selectCol.AddRange({"jenis_kode lap_custo",
                                         "jenis_nama lap_custo_n"
                                        })
                    _qjoin = " LEFT JOIN data_customer_jenis ON jenis_kode=GetMasterNama('custojeniskd', faktur_customer)"
                    _qorder = " GROUP BY jenis_kode, jenis"

                ElseIf LCase(Grouping) = "tanggalnota" Then
                    _selectCol.AddRange({"faktur_tanggal_trans lap_tanggal",
                                         "faktur_kode lap_faktur",
                                         "faktur_customer lap_custo",
                                         "GetMasterNama('custo', faktur_customer) lap_custo_n",
                                         "ppn.ref_text lap_kat"
                                         })
                    _qjoin = " LEFT JOIN ref_jenis ppn ON faktur_ppn_jenis=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans'"
                    _qorder = " GROUP BY jenis, faktur_tanggal_trans, faktur_kode"
                End If
                _selectCol.AddRange({"jenis lap_jenis",
                                     "SUM(IF(faktur_jenis_bayar!='TUNAI',faktur_brutto,0)) lap_brutto",
                                     "SUM(IF(faktur_jenis_bayar='TUNAI',faktur_brutto,0)) lap_tunai",
                                     "SUM(faktur_diskon) lap_diskon",
                                     "SUM(faktur_ppn) lap_ppn",
                                     "SUM(faktur_netto) lap_jumlah"
                                    })

            Case Else : Return String.Empty : Exit Function
        End Select

        Return String.Format(_q, String.Join(",", _selectCol), StartDate, EndDate, KategoriPajak, _qjoin + _qwhr + _qorder)
    End Function

    'EXPORT EXCEL
    Private Sub ExportLaporan(LapType As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim q As String = createQuery(LapType)
        Dim _dt As New List(Of DataTable)
        Dim _title As New List(Of String)
        Dim _subtitle As New List(Of String())
        Dim _colHeader As New List(Of String)
        Dim _outputdir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\SIMInvent\"
        Dim _periode As String = "" : Dim _tglawal As Date = date_tglawal.Value : Dim _tglakhir As Date = date_tglakhir.Value
        Dim _ck As Boolean = False

        If _tglawal.ToString("MMyyyy") = _tglakhir.ToString("MMyyyy") AndAlso _tglawal.Day = 1 _
            AndAlso _tglakhir.Day = DateSerial(_tglakhir.Year, _tglakhir.Month + 1, 0).Day Then
            _periode = UCase(_tglawal.ToString("MMMM yyyy"))
        ElseIf _tglawal = _tglakhir Then
            _periode = UCase(_tglawal.ToString("dd MMMM yyyy"))
        Else
            _periode = _tglawal.ToString("dd/MM/yyyy") & " S.d " & _tglakhir.ToString("dd/MM/yyyy")
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Using dtx = x.GetDataTable(q)
                    If dtx.Rows.Count = 0 Then
                        MessageBox.Show("Jumlah data 0, tidak dapat mengexport data.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    Select Case LapType
                        Case "lapJualNota"
                            _colHeader.AddRange({"JENISTRANS.", "NO.FAKTUR", "TANGGAL", "KAT.", "KD.SALES", "NAMASALESMAN", "KD.CUSTO", "NAMACUSTOMER",
                                                 "JEN.BAYAR", "TERM.", "BRUTTO", "DISKON", "PPN", "JUMLAH", "BAYAR/TUNAI"})
                            _title.AddRange({"LAPORAN NOTA PENJUALAN", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "lapJualCusto", "lapJualSales", "lapJualTgl", "lapJualSupplier", "lapJualTipe"
                            Dim fk_title As String = ""
                            If LapType = "lapJualCusto" Then
                                _colHeader.AddRange({"KD.CUSTO", "NAMACUSTOMER"}) : fk_title = "CUSTOMER"
                            ElseIf LapType = "lapJualSales" Then
                                _colHeader.AddRange({"KD.SALES", "NAMASALESMAN"}) : fk_title = "SALESMAN"
                            ElseIf LapType = "lapJualSupplier" Then
                                _colHeader.AddRange({"KD.SUPPLIER", "NAMASUPPLIER"}) : fk_title = "SUPPLIER"
                            ElseIf LapType = "lapJualTipe" Then
                                _colHeader.AddRange({"KD.TIPE", "NAMATIPE"}) : fk_title = "TIPE CUSTOMER"
                            Else
                                _colHeader.Add("TANGGAL") : fk_title = "TANGGAL"
                            End If
                            _colHeader.AddRange({"JENIS", "KREDIT", "TUNAI", "DISKON", "PPN", "JUMLAH"})
                            _title.AddRange({"LAPORAN PENJUALAN PER " & fk_title, "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "lapJualTanggalNota"
                            _colHeader.AddRange({"TANGGAL", "NO.FAKTUR", "KD.CUSTO", "NAMACUSTOMER", "KAT.", "JENIS", "KREDIT", "TUNAI", "DISKON", "PPN", "JUMLAH"})
                            _title.AddRange({"LAPORAN NOTA PENJUALAN PER TANGGAL", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "lapJualSalesNota", "lapJualCustoNota"
                            Dim fk_title As String = ""
                            Dim _col() As String = {"lap_faktur", "lap_tanggal", "lap_jenis", "lap_kat", "lap_custo", "lap_custo_n",
                                                    "lap_tunai", "lap_brutto", "lap_diskon", "lap_ppn", "lap_jumlah"}
                            If LapType = "lapJualSalesNota" Then
                                fk_title = "SALESMAN"
                                Dim _headlist = New DataView(dtx).ToTable(True, {"lap_sales", "lap_sales_n"}).Select("", "lap_sales ASC")
                                For Each row As DataRow In _headlist
                                    _subtitle.Add({fk_title, row.ItemArray(0), row.ItemArray(1)})
                                    Dim _expression = String.Format("lap_sales='{0}'", row.ItemArray(0))
                                    _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, _col))
                                Next
                            Else
                                fk_title = "CUSTOMER" : _dt.Add(New DataView(dtx).ToTable(False, _col))
                            End If

                            _colHeader.AddRange({"NO.FAKTUR", "TANGGAL", "JENIS", "KAT.", "KD.CUSTOMER", "NAMACUSTOMER", "TUNAI", "BRUTTO", "DISKON", "PPN", "JUMLAH"})
                            _title.AddRange({"LAPORAN NOTA PENJUALAN PER " & fk_title, "PERIODE " & _periode})

                        Case "lapJualBarangSupplier", "lapJualBarangSales"
                            Dim fk_title As String = ""
                            If LapType = "lapJualBarangSupplier" Then
                                fk_title = "SUPPLIER"
                            Else
                                fk_title = "SALES"
                            End If

                            _colHeader.AddRange({"KD.BARANG", "NAMABARANG", "QTYJUAL", "NILAIJUAL", "QTYRETUR", "NILAIRETUR", "QTYTOTAL", "NILAITOTAL"})
                            _title.AddRange({"LAPORAN PENJUALAN BARANG PER " & fk_title, "PERIODE " & _periode})
                            Dim _headlist = New DataView(dtx).ToTable(True, {"dlap_supplier", "dlap_supplier_n"}).Select("", "dlap_supplier ASC")
                            For Each row As DataRow In _headlist
                                _subtitle.Add({fk_title, row.ItemArray(0), row.ItemArray(1)})
                                Dim _expression = String.Format("dlap_supplier = '{0}'", row.ItemArray(0))
                                _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, {"dlap_barang", "dlap_barang_n", "dlap_qty_jual", "dlap_nilai_jual", "dlap_qty_retur", "dlap_nilai_retur", "dlap_qty_tot", "dlap_nilai_tot"}))
                            Next

                        Case "lapJualSalesCustoBarang"
                            _colHeader.AddRange({"NO.FAKTUR", "TANGGAL", "KAT.", "KD.CUSTO", "NAMACUSTOMER", "KOTA", "TIPE", "KD.GUDANG", "NAMAGUDANG",
                                                 "KD.BRG", "NAMA BARANG", "HARGAJUAL", "QTY", "SATUAN", "TOT.DISKON", "TOTALJUAL", "DISCRP", "TOT.DISCRP",
                                                 "DISC1", "TOT.DISC1", "DISC2", "TOT.DISC2", "DISC3", "TOT.DISC3", "DISC4", "TOT.DISC4", "DISC5", "TOT.DISC5"})
                            _title.AddRange({"LAPORAN DISTRIBUSI PENJUALAN PER SALESMAN", "PERIODE " & _periode})
                            Dim _saleslist = New DataView(dtx).ToTable(True, {"lap_sales", "lap_sales_n"}).Select("", "lap_sales ASC")
                            For Each row As DataRow In _saleslist
                                _subtitle.Add({"SALES", row.ItemArray(0), row.ItemArray(1)})
                                Dim _expression = String.Format("lap_sales = '{0}'", row.ItemArray(0))
                                _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, {"lap_faktur", "lap_tgl", "lap_kat", "lap_custo", "lap_custo_n", "lap_custo_kab", "lap_custo_jn", "lap_gudang", "lap_gudang_n", "lap_barang", "lap_barang_n", "lap_harga_jual", "lap_qty", "lap_sat", "lap_disc_tot", "lap_jml", "lap_discrp", "lap_discrp_n", "lap_disc1", "lap_disc1_n", "lap_disc2", "lap_disc2_n", "lap_disc3", "lap_disc3_n", "lap_disc4", "lap_disc4_n", "lap_disc5", "lap_disc5_n"}))
                            Next
                        Case Else : Exit Sub
                    End Select

                    Using dd As New SaveFileDialog
                        dd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
                        dd.FilterIndex = 1
                        dd.FileName = dd.InitialDirectory
                        dd.RestoreDirectory = True : dd.AddExtension = True
                        If dd.ShowDialog = DialogResult.OK Then
                            If dd.FileName <> Nothing Then
                                Dim fk = dd.FileName.Split(".")
                                Dim _fileExt As String = IIf(dd.FilterIndex = 1, "xlsx", fk(fk.Count - 1))

                                Me.Cursor = Cursors.WaitCursor
                                If ExportExcel(_colHeader, _dt, _title, dd.FileName, _fileExt, _outputdir, _subtitle) Then
                                    If System.IO.File.Exists(_outputdir) = True Then
                                        MessageBox.Show("Export Data Sukses", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Process.Start(_outputdir)
                                    Else
                                        MessageBox.Show("File tidak dapat ditemukan", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                End If
                                Me.Cursor = Cursors.Default
                            End If
                        End If
                    End Using
                End Using
            Else

            End If
        End Using
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
        'Dim _dialogres As Windows.Forms.DialogResult = MessageBox.Show("Tutup Form?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'If _dialogres = Windows.Forms.DialogResult.No Then
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbeli.PerformClick()
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
        x.ShowDialog(Me)
        Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_exportxl.Click
        Me.Cursor = Cursors.WaitCursor
        ExportLaporan(laptype)
        Me.Cursor = Cursors.Default
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
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
            Dim x As TextBox
            Select Case popupstate
                Case "supplier", "sales", "jenis", "custo2"
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
            x.Focus() : x.Select(x.TextLength, x.TextLength)
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

    Private Sub in_sales_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter, in_barang_n.Enter
        popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If

        Select Case sender.Name
            Case "in_sales_n"
                Select Case UCase(sales_sw)
                    Case "SUPPLIER" : popupstate = "supplier"
                    Case "CUSTO" : popupstate = "custo2"
                    Case "JENISCUSTO" : popupstate = "jenis"
                    Case Else : popupstate = "sales"
                End Select
            Case "in_barang_n"
                popupstate = "barang"
            Case Else : Exit Sub
        End Select

        loadDataBRGPopup(popupstate, sender.Text)
    End Sub

    Private Sub in_sales_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave, in_custo_n.Leave, in_barang_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_sales_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyDown, in_custo_n.KeyDown, in_barang_n.KeyDown
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
    End Sub

    Private Sub in_sales_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp, in_custo_n.KeyUp, in_barang_n.KeyUp
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