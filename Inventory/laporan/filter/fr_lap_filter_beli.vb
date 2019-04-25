﻿Public Class fr_lap_filter_beli
    Private popupstate As String = "supplier"
    Private lapwintext As String = ""
    Public laptype As String
    Public jenis_sw As Boolean = True
    Public supplier_sw As Boolean = True
    Public barang_sw As Boolean = False

    Private Sub prcessSW()
        'If supplier_sw = False Then
        lbl_supplier.Visible = supplier_sw
        in_supplier.Visible = supplier_sw
        in_supplier_n.Visible = supplier_sw
        'End If
        'If jenis_sw = False Then
        lbl_jenis.Visible = jenis_sw
        cb_jenis.Visible = jenis_sw
        'End If
        'If barang_sw = False Then
        lbl_barang.Visible = barang_sw
        in_barang.Visible = barang_sw
        in_barang_n.Visible = barang_sw
        'End If

        Me.Text = lapwintext
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "supplier"
                q = "SELECT supplier_kode AS 'Kode', supplier_nama AS 'Nama' FROM data_supplier_master " _
                    & "WHERE supplier_status=1 AND (supplier_nama LIKE '%{0}%' OR supplier_kode LIKE '%{0}%')"
            Case "barang"
                If in_supplier.Text <> Nothing Then
                    q = "SELECT barang_kode as 'Kode', barang_nama as 'Nama' FROM data_barang_master " _
                        & "WHERE barang_status=1 AND barang_supplier='" & in_supplier.Text & "' AND (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%')"
                Else
                    q = "SELECT barang_kode as 'Kode', barang_nama as 'Nama' FROM data_barang_master " _
                        & "WHERE barang_status=1 AND (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%')"
                End If
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
                Case "supplier"
                    in_supplier.Text = .Cells(0).Value
                    in_supplier_n.Text = .Cells(1).Value
                    If barang_sw = True Then in_barang.Focus() Else bt_simpanbeli.Focus()
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
        Dim _tglawal As String = date_tglawal.Value.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = date_tglakhir.Value.ToString("yyyy-MM-dd")
        Select Case tipe
            Case "lapBeliNota"
                q = "SELECT * FROM( " _
                    & "SELECT supplier_kode as lap_supplier, supplier_nama as lap_supplier_n, faktur_kode as lap_faktur, " _
                    & "faktur_tanggal_trans as lap_tgl,if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah) as lap_brutto, " _
                    & "faktur_disc as lap_diskon, faktur_ppn as lap_ppn, faktur_netto as lap_jumlah, 'BELI' as lap_jenis " _
                    & "FROM data_pembelian_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND faktur_ppn_jenis IN ({2}) " _
                    & "UNION " _
                    & "SELECT supplier_kode, supplier_nama, faktur_kode_bukti, faktur_tanggal_trans, " _
                    & "if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah), faktur_jumlah-faktur_netto, " _
                    & "faktur_ppn, faktur_netto, 'RETUR' " _
                    & "FROM data_pembelian_retur_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND faktur_ppn_jenis IN ({2}) " _
                    & ") beli {3}"
                q = String.Format(q, _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}")

            Case "lapBeliTgl"
                q = "SELECT * FROM ( " _
                    & "SELECT faktur_tanggal_trans as lap_tgl,SUM(if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah)) as lap_brutto, " _
                    & "SUM(faktur_disc) as lap_diskon, SUM(faktur_ppn) as lap_ppn, SUM(faktur_netto) as lap_jumlah, 'BELI' as lap_jenis " _
                    & "FROM data_pembelian_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND faktur_ppn_jenis IN ({2}) " _
                    & "GROUP BY faktur_tanggal_trans ORDER BY lap_tgl" _
                    & "UNION " _
                    & "SELECT faktur_tanggal_trans, SUM(if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah)), 0, " _
                    & "SUM(faktur_ppn) as lap_ppn, SUM(faktur_netto) as lap_jumlah, 'RETUR' " _
                    & "FROM data_pembelian_retur_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND faktur_ppn_jenis IN ({2}) " _
                    & "GROUP BY faktur_tanggal_trans ORDER BY lap_tgl " _
                    & ") beli {3}"
                q = String.Format(q, _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}")

            Case "lapBeliSupplier"
                q = "SELECT * FROM( " _
                    & "SELECT supplier_kode as lap_supplier, supplier_nama as lap_supplier_n, faktur_kode as lap_faktur, " _
                    & "if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah) as lap_brutto, " _
                    & "faktur_disc as lap_diskon, faktur_ppn as lap_ppn, faktur_netto as lap_jumlah, 'BELI' as lap_jenis " _
                    & "FROM data_pembelian_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND faktur_ppn_jenis IN ({2}) " _
                    & "UNION " _
                    & "SELECT supplier_kode, supplier_nama, faktur_kode_bukti, " _
                    & "if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah),faktur_jumlah-IF(faktur_ppn_jenis<>0,faktur_netto,faktur_netto-faktur_ppn), " _
                    & "faktur_ppn, faktur_netto, 'RETUR' " _
                    & "FROM data_pembelian_retur_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND faktur_ppn_jenis IN ({2}) " _
                    & ") beli {3}"
                q = String.Format(q, _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}")

            Case "lapBeliTglNota"
                q = "SELECT lap_tgl, lap_faktur,lap_supplier, lap_supplier_n,lap_brutto,lap_diskon,lap_ppn,lap_jumlah,lap_jenis FROM( " _
                    & "SELECT supplier_kode as lap_supplier, supplier_nama as lap_supplier_n, faktur_kode as lap_faktur, " _
                    & "faktur_tanggal_trans as lap_tgl,if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah) as lap_brutto, " _
                    & "faktur_disc as lap_diskon, faktur_ppn as lap_ppn, faktur_netto as lap_jumlah,  'BELI' as lap_jenis " _
                    & "FROM data_pembelian_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND faktur_ppn_jenis IN ({2}) " _
                    & "UNION " _
                    & "SELECT supplier_kode, supplier_nama, faktur_kode_bukti, faktur_tanggal_trans, " _
                    & "if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah),faktur_jumlah-IF(faktur_ppn_jenis<>0,faktur_netto,faktur_netto-faktur_ppn), " _
                    & "faktur_ppn, faktur_netto, 'RETUR' " _
                    & "FROM data_pembelian_retur_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND faktur_ppn_jenis IN ({2}) " _
                    & ") beli {3} ORDER BY lap_tgl"
                q = String.Format(q, _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}")

            Case "lapBeliSupplierNota"
                q = "SELECT * FROM( " _
                    & "SELECT supplier_kode as lap_supplier, supplier_nama as lap_supplier_n, faktur_kode as lap_faktur, " _
                    & "faktur_tanggal_trans as lap_tgl,if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah) as lap_brutto, " _
                    & "faktur_disc as lap_diskon, faktur_ppn as lap_ppn, faktur_netto as lap_jumlah,  'BELI' as lap_jenis " _
                    & "FROM data_pembelian_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND faktur_ppn_jenis IN ({2}) " _
                    & "UNION " _
                    & "SELECT supplier_kode, supplier_nama, faktur_kode_bukti, faktur_tanggal_trans, " _
                    & "if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah),faktur_jumlah-IF(faktur_ppn_jenis<>0,faktur_netto,faktur_netto-faktur_ppn), " _
                    & "faktur_ppn, faktur_netto, 'RETUR' " _
                    & "FROM data_pembelian_retur_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND faktur_ppn_jenis IN ({2}) " _
                    & ") beli {3} ORDER BY lap_tgl"
                q = String.Format(q, _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}")

            Case "lapBeliSupplierBarang"
                q = "SELECT dlap_supplier,dlap_supplier_n, dlap_barang, dlap_barang_n, dlap_qty, dlap_qty_n,dlap_harga_beli, dlap_total_diskon, " _
                    & "TRUNCATE(dlap_ppn,2) dlap_ppn, dlap_jumlah, dlap_jenis FROM( " _
                    & "SELECT supplier_kode as dlap_supplier, supplier_nama as dlap_supplier_n, " _
                    & "trans_barang as dlap_barang, barang_nama as dlap_barang_n," _
                    & "SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)) as dlap_qty, " _
                    & "getQTYdetail(trans_barang, SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)), 2) as dlap_qty_n, " _
                    & "SUM(@subtot:=trans_qty*trans_harga_beli) as dlap_harga_beli, SUM(trans_qty*trans_harga_beli-trans_jumlah) as dlap_total_diskon, " _
                    & "SUM(@ppn:=(CASE faktur_ppn_jenis WHEN 1 THEN @subtot*(1-(10/11)) WHEN 0 THEN @subtot*0.1 ELSE 0 END)) dlap_ppn, " _
                    & "SUM(trans_jumlah)+SUM(IF(faktur_ppn_jenis<>1,@ppn,0)) as dlap_jumlah, 'BELI' as dlap_jenis " _
                    & "FROM data_pembelian_trans LEFT JOIN data_pembelian_faktur ON trans_faktur=faktur_kode AND faktur_status=1 " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                    & "JOIN (SELECT @subtot:=0, @ppn:=0) para " _
                    & "WHERE trans_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND faktur_ppn_jenis IN ({2}) " _
                    & "GROUP BY supplier_kode, trans_barang " _
                    & "UNION " _
                    & "SELECT supplier_kode,supplier_nama, trans_barang, barang_nama, " _
                    & "	SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)), " _
                    & "	getQTYdetail(trans_barang, SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)), 2), " _
                    & "	IFNULL(SUM(@subtot:=trans_qty*trans_harga_retur),0) as dlap_harga_beli, " _
                    & " SUM(@disc:=@subtot*(trans_diskon/100)) as dlap_total_diskon, " _
                    & " SUM(@ppn:=(CASE faktur_ppn_jenis WHEN 1 THEN @subtot*(1-(10/11)) WHEN 0 THEN @subtot*1/10 ELSE 0 END)) dlap_ppn, " _
                    & "	SUM(@subtot-@disc+IF(faktur_ppn_jenis<>1,@ppn,0)) as dlap_jumlah, 'RETUR' as dlap_jenis " _
                    & "FROM data_pembelian_retur_trans LEFT JOIN data_pembelian_retur_faktur ON faktur_kode_bukti=trans_faktur AND faktur_status=1 " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                    & "JOIN (SELECT @subtot:=0, @ppn:=0) para " _
                    & "WHERE trans_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND faktur_ppn_jenis IN ({2}) " _
                    & "GROUP BY supplier_kode,trans_barang" _
                    & ") beli {3} ORDER BY dlap_jenis, dlap_supplier, dlap_barang"
                q = String.Format(q, _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}")

            Case "lapBeliTglBarang"
                q = "SELECT dlap_supplier,dlap_barang,dlap_barang_n,dlap_qty, dlap_qty_n,dlap_harga_beli, dlap_total_diskon, " _
                    & "TRUNCATE(dlap_ppn,2) dlap_ppn, dlap_jumlah, dlap_jenis FROM( " _
                    & "SELECT DATE_FORMAT(faktur_tanggal_trans,'%d-%m-%Y') as dlap_supplier, '' as dlap_supplier_n, " _
                    & "trans_barang as dlap_barang, barang_nama as dlap_barang_n," _
                    & "SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)) as dlap_qty, " _
                    & "getQTYdetail(trans_barang, SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)), 2) as dlap_qty_n, " _
                    & "SUM(@subtot:=trans_qty*trans_harga_beli) as dlap_harga_beli, SUM(trans_qty*trans_harga_beli-trans_jumlah) as dlap_total_diskon, " _
                    & "SUM(@ppn:=(CASE faktur_ppn_jenis WHEN 1 THEN @subtot*(1-(10/11)) WHEN 0 THEN @subtot*0.1 ELSE 0 END)) dlap_ppn, " _
                    & "SUM(trans_jumlah)+SUM(IF(faktur_ppn_jenis<>1,@ppn,0)) as dlap_jumlah, 'BELI' as dlap_jenis " _
                    & "FROM data_pembelian_trans LEFT JOIN data_pembelian_faktur ON trans_faktur=faktur_kode AND faktur_status=1 " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                    & "WHERE trans_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND faktur_ppn_jenis IN ({2}) " _
                    & "GROUP BY faktur_tanggal_trans, trans_barang " _
                    & "UNION " _
                    & "SELECT DATE_FORMAT(faktur_tanggal_trans,'%d-%m-%Y'),'', trans_barang, barang_nama, " _
                    & "	SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)), " _
                    & "	getQTYdetail(trans_barang, SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)), 2), " _
                    & "	IFNULL(SUM(@subtot:=trans_qty*trans_harga_retur),0) as dlap_harga_beli, " _
                    & " SUM(@disc:=@subtot*(trans_diskon/100)) as dlap_total_diskon, " _
                    & " SUM(@ppn:=(CASE faktur_ppn_jenis WHEN 1 THEN @subtot*(1-(10/11)) WHEN 0 THEN @subtot*1/10 ELSE 0 END)) dlap_ppn, " _
                    & "	SUM(@subtot-@disc+IF(faktur_ppn_jenis<>1,@ppn,0)) as dlap_jumlah, 'RETUR' as dlap_jenis " _
                    & "FROM data_pembelian_retur_trans LEFT JOIN data_pembelian_retur_faktur ON faktur_kode_bukti=trans_faktur AND faktur_status=1 " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                    & "WHERE trans_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND faktur_ppn_jenis IN ({2}) " _
                    & "GROUP BY faktur_tanggal_trans,trans_barang" _
                    & ") beli {3} ORDER BY dlap_barang_n"
                q = String.Format(q, _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}")

            Case "lapBeliTglNotaBarang"
                q = "SELECT faktur_kode dlap_faktur, faktur_tanggal_trans dlap_tgl,supplier_kode dlap_supplier, supplier_nama dlap_supplier_n, " _
                    & "barang_kode dlap_barang, barang_nama dlap_barang_n, trans_qty as dlap_qty, trans_satuan dlap_qty_n, trans_harga_beli as dlap_harga_beli, " _
                    & "trans_disc1 dlap_disc1, trans_disc2 dlap_disc2, trans_disc3 dlap_disc3, trans_disc_rupiah dlap_disc_rp, " _
                    & "(trans_qty*trans_harga_beli-trans_jumlah) as dlap_total_diskon, trans_jumlah as dlap_jumlah, " _
                    & "@ppn := ROUND((CASE faktur_ppn_jenis WHEN 0 THEN trans_jumlah * 0.1 WHEN 1 THEN trans_jumlah * (1 - 10 / 11) ELSE 0 END),2) dlap_ppn, " _
                    & "(CASE faktur_ppn_jenis WHEN 0 THEN 'NON-PPN' WHEN 1 THEN 'INCLUDED' WHEN 2 THEN 'EXCLUDED' ELSE 'ERROR' END) dlap_ppn_type " _
                    & "FROM data_pembelian_trans " _
                    & "LEFT JOIN data_pembelian_faktur ON trans_faktur=faktur_kode AND faktur_status=1 " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                    & "WHERE trans_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND faktur_ppn_jenis IN ({2}) {3}"
                q = String.Format(q, _tglawal, _tglakhir, cb_pajak.SelectedValue, "{0}")
            Case Else
                Return Nothing
                Exit Function
        End Select

        Select Case tipe
            Case "lapBeliSupplierNota", "lapBeliTglNota", "lapBeliSupplier", "lapBeliTgl", "lapBeliNota"
                qwh += "WHERE lap_jenis IN (" & cb_jenis.SelectedValue & ") "
                If in_supplier.Text <> Nothing Then
                    qwh += "AND lap_supplier='" & in_supplier.Text & "' "
                End If
            Case "lapBeliSupplierBarang", "lapBeliTglBarang"
                qwh += "WHERE dlap_jenis IN (" & cb_jenis.SelectedValue & ") "
                If in_supplier.Text <> Nothing Then
                    qwh += "AND dlap_supplier='" & in_supplier.Text & "' "
                End If
                If in_barang.Text <> Nothing Then
                    qwh += "AND dlap_barang='" & in_barang.Text & "' "
                End If
            Case Else
                If in_supplier.Text <> Nothing Then
                    qwh += "AND faktur_supplier='" & in_supplier.Text & "' "
                End If
                If in_barang.Text <> Nothing Then
                    qwh += "AND trans_barang='" & in_barang.Text & "' "
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
        Dim _outputdir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Inventory\"
        Dim _filename As String = "dataexport" & Today.ToString("yyyyMMdd")
        Dim _respond As Boolean = False
        Dim _svdialog As New SaveFileDialog
        Dim _title As String = ""
        Dim _tglawal As String = date_tglawal.Value.ToString("dd-MM-yyyy")
        Dim _tglakhir As String = date_tglakhir.Value.ToString("dd-MM-yyyy")
        Dim _datefile As String = "(" & date_tglawal.Value.ToString("yyyyMMdd") & "-" & date_tglakhir.Value.ToString("yyyyMMdd") & ")-" & Today.ToString("yyyyMMdd")

        MyBase.Cursor = Cursors.AppStarting

        Select Case type
            Case "lapBeliNota"
                _colheader.AddRange({"Kode Supplier", "Nama Supplier", "Faktur", "Tgl. Transaksi", "Brutto", "Diskon", "PPn", "Jumlah", "Jenis"})
                _title = "LAPORAN PEMBELIAN PER NOTA " & _tglawal & " s.d. " & _tglakhir
                _filename = "BeliNota" & _datefile & ".xlsx"

            Case "lapBeliTgl"
                _colheader.AddRange({"Tgl. Transaksi", "Brutto", "Diskon", "PPn", "Jumlah", "Jenis"})
                _title = "LAPORAN PEMBELIAN PER TANGGAL " & _tglawal & " s.d. " & _tglakhir
                _filename = "BeliTanggal" & _datefile & ".xlsx"

            Case "lapBeliSupplier"
                _colheader.AddRange({"Kode Supplier", "Nama Supplier", "Faktur", "Tgl. Transaksi", "Brutto", "Diskon", "PPn", "Jumlah", "Jenis"})
                _title = "LAPORAN PEMBELIAN PER SUPPLIER " & _tglawal & " s.d. " & _tglakhir
                _filename = "BeliSupplier" & _datefile & ".xlsx"

            Case "lapBeliTglNota"
                _colheader.AddRange({"Tgl. Transaksi", "No.Faktur", "Kode Supplier", "Nama Supplier", "Brutto", "Diskon", "PPn", "Jumlah", "Jenis"})
                _title = "LAPORAN PEMBELIAN PER TANGGAL PER NOTA " & _tglawal & " s.d. " & _tglakhir
                _filename = "BeliTanggalNota" & _datefile & ".xlsx"

            Case "lapBeliSupplierNota"
                _colheader.AddRange({"Kode Supplier", "Nama Supplier", "Faktur", "Tgl. Transaksi", "Brutto", "Diskon", "PPn", "Jumlah", "Jenis"})
                _title = "LAPORAN PEMBELIAN PER SUPPLIER PER NOTA " & _tglawal & " s.d. " & _tglakhir
                _filename = "BeliSupplierNota" & _datefile & ".xlsx"

            Case "lapBeliSupplierBarang"
                _colheader.AddRange({"Kode Supplier", "Nama Supplier", "Kode Barang", "Nama Barang", "Qty", "Konversi", "Subtotal", "Diskon", "PPn", "Jumlah", "Jenis"})
                _title = "LAPORAN PEMBELIAN PER SUPPLIER PER BARANG " & _tglawal & " s.d. " & _tglakhir
                _filename = "BeliSupplierBarang" & _datefile & ".xlsx"

            Case "lapBeliTglBarang"
                _colheader.AddRange({"Tgl.Transaksi", "Kode Barang", "Nama Barang", "Qty", "Konversi", "Subtotal", "Diskon", "PPn", "Jumlah", "Jenis"})
                _title = "LAPORAN PEMBELIAN PER TANGGAL PER BARANG " & _tglawal & " s.d. " & _tglakhir
                _filename = "BeliTanggalBarang" & _datefile & ".xlsx"

            Case "lapBeliTglNotaBarang"
                _colheader.AddRange({"No.Faktur", "Tgl.Transaksi", "Kode Supplier", "Nama Supplier", "Kode Barang", "Nama Barang", "Qty", "Satuan",
                                     "Harga Beli", "Disc1", "Disc2", "Disc3", "Disc Rp.", "Total Diskon", "Total", "PPn", "PPn Type"})
                _title = "LAPORAN PEMBELIAN DISTRIBUTOR PER TANGGAL " & _tglawal & " s.d. " & _tglakhir
                _filename = "BeliTanggalBarang" & _datefile & ".xlsx"

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

        prcessSW()
        Show(main)
    End Sub

    'LOAD LAPORAN
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        Dim x As New fr_lap_beli_nota_view With {
                    .inlap_type = laptype,
                    .Text = lapwintext,
                    .inquery = createQuery(laptype),
                    .intglawal = date_tglawal.Value.ToString("dd/MM/yyyy"),
                    .intglakhir = date_tglakhir.Value.ToString("dd/MM/yyyy")
                }
        x.do_load()
        x.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_exportxl.Click
        exportData(laptype)
    End Sub

    'UI
    '------------- POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_supplier_n.Focused Or in_barang_n.Focused Then
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
                    x = in_supplier_n
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

    '------------- INPUT
    Private Sub date_tglawal_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglawal.KeyUp
        keyshortenter(date_tglakhir, e)
    End Sub

    Private Sub date_tglawal_ValueChanged(sender As Object, e As EventArgs) Handles date_tglawal.ValueChanged
        date_tglakhir.MinDate = date_tglawal.Value
    End Sub

    Private Sub date_tglakhir_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglakhir.KeyUp
        keyshortenter(IIf(jenis_sw = False, in_supplier_n, cb_jenis), e)
    End Sub

    Private Sub date_tglakhir_ValueChanged(sender As Object, e As EventArgs) Handles date_tglakhir.ValueChanged
        date_tglawal.MaxDate = date_tglakhir.Value
    End Sub

    Private Sub cb_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_jenis.KeyPress
        If e.KeyChar <> ControlChars.CrLf Then
            e.Handled = True
        End If
    End Sub

    Private Sub cb_jenis_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_jenis.KeyUp
        keyshortenter(IIf(supplier_sw = False, bt_simpanbeli, in_supplier_n), e)
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        keyshortenter(in_supplier_n, e)
    End Sub

    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_supplier_n.Enter
        popPnl_barang.Location = New Point(in_supplier_n.Left, in_supplier_n.Top + in_supplier_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "supplier"
        loadDataBRGPopup("supplier", in_supplier_n.Text)
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_supplier_n.Leave, in_barang_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyUp, in_barang_n.KeyUp
        Dim _nxtcontrol As Object
        Dim _kdcontrol As Object
        Select Case sender.Name.ToString
            Case "in_supplier_n"
                _nxtcontrol = IIf(barang_sw = True, in_barang_n, bt_simpanbeli)
                _kdcontrol = in_supplier
            Case "in_barang_n"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = in_barang
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

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        keyshortenter(in_barang_n, e)
    End Sub

    Private Sub in_barang_n_Enter(sender As Object, e As EventArgs) Handles in_barang_n.Enter
        popPnl_barang.Location = New Point(in_barang_n.Left, in_barang_n.Top + in_barang_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "barang"
        loadDataBRGPopup("barang", in_barang_n.Text)
    End Sub

    Private Sub fr_hutang_bayar_Click(sender As Object, e As EventArgs) Handles MyBase.Click, pnl_content.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub
End Class