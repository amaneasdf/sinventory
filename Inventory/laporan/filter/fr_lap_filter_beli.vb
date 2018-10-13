Public Class fr_lap_filter_beli
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
                q = "SELECT supplier_kode AS 'Kode', supplier_nama AS 'Nama' FROM data_supplier_master WHERE supplier_status=1 AND supplier_nama LIKE '{0}%'"
            Case "barang"
                If in_supplier.Text <> Nothing Then
                    q = "SELECT barang_kode as 'Kode', barang_nama as 'Nama' FROM data_barang_master WHERE barang_status=1 AND barang_supplier='" & in_supplier.Text & "' AND barang_nama LIKE '{0}%'"
                Else
                    q = "SELECT barang_kode as 'Kode', barang_nama as 'Nama' FROM data_barang_master WHERE barang_status=1 AND barang_nama LIKE '{0}%'"
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
        Select Case tipe
            Case "lapBeliNota"
                q = "SELECT * FROM( " _
                    & "SELECT supplier_kode as lap_supplier, supplier_nama as lap_supplier_n, faktur_kode as lap_faktur, " _
                    & "faktur_tanggal_trans as lap_tgl,if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah) as lap_brutto, " _
                    & "faktur_disc as lap_diskon, faktur_ppn as lap_ppn, faktur_netto as lap_jumlah, 'BELI' as lap_jenis " _
                    & "FROM data_pembelian_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                    & "UNION " _
                    & "SELECT supplier_kode, supplier_nama, faktur_kode_bukti, faktur_tanggal_trans, " _
                    & "if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah), 0, " _
                    & "faktur_ppn, faktur_netto, 'RETUR' " _
                    & "FROM data_pembelian_retur_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                    & ") beli {2}"
                q = String.Format(q, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

            Case "lapBeliTgl"
                q = "SELECT * FROM ( " _
                    & "SELECT faktur_tanggal_trans as lap_tgl,SUM(if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah)) as lap_brutto, " _
                    & "SUM(faktur_disc) as lap_diskon, SUM(faktur_ppn) as lap_ppn, SUM(faktur_netto) as lap_jumlah, 'BELI' as lap_jenis " _
                    & "FROM data_pembelian_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' GROUP BY faktur_tanggal_trans " _
                    & "UNION " _
                    & "SELECT faktur_tanggal_trans, SUM(if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah)), 0, " _
                    & "SUM(faktur_ppn) as lap_ppn, SUM(faktur_netto) as lap_jumlah, 'RETUR' " _
                    & "FROM data_pembelian_retur_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' GROUP BY faktur_tanggal_trans " _
                    & "ORDER BY lap_tgl " _
                    & ") beli {2}"
                q = String.Format(q, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

            Case "lapBeliSupplier"
                q = "SELECT * FROM( " _
                    & "SELECT supplier_kode as lap_supplier, supplier_nama as lap_supplier_n, faktur_kode as lap_faktur, " _
                    & "if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah) as lap_brutto, " _
                    & "faktur_disc as lap_diskon, faktur_ppn as lap_ppn, faktur_netto as lap_jumlah, 'BELI' as lap_jenis " _
                    & "FROM data_pembelian_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                    & "UNION " _
                    & "SELECT supplier_kode, supplier_nama, faktur_kode_bukti, " _
                    & "if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah), 0, " _
                    & "faktur_ppn, faktur_netto, 'RETUR' " _
                    & "FROM data_pembelian_retur_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                    & ") beli {2}"
                q = String.Format(q, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

            Case "lapBeliTglNota"
                q = "SELECT * FROM( " _
                    & "SELECT supplier_kode as lap_supplier, supplier_nama as lap_supplier_n, faktur_kode as lap_faktur, " _
                    & "faktur_tanggal_trans as lap_tgl,if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah) as lap_brutto, " _
                    & "faktur_disc as lap_diskon, faktur_ppn as lap_ppn, faktur_netto as lap_jumlah,  'BELI' as lap_jenis " _
                    & "FROM data_pembelian_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                    & "UNION " _
                    & "SELECT supplier_kode, supplier_nama, faktur_kode_bukti, faktur_tanggal_trans, " _
                    & "if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah), 0, " _
                    & "faktur_ppn, faktur_netto, 'RETUR' " _
                    & "FROM data_pembelian_retur_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                    & ") beli {2} ORDER BY lap_tgl"
                q = String.Format(q, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

            Case "lapBeliSupplierNota"
                q = "SELECT * FROM( " _
                    & "SELECT supplier_kode as lap_supplier, supplier_nama as lap_supplier_n, faktur_kode as lap_faktur, " _
                    & "faktur_tanggal_trans as lap_tgl,if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah) as lap_brutto, " _
                    & "faktur_disc as lap_diskon, faktur_ppn as lap_ppn, faktur_netto as lap_jumlah,  'BELI' as lap_jenis " _
                    & "FROM data_pembelian_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                    & "UNION " _
                    & "SELECT supplier_kode, supplier_nama, faktur_kode_bukti, faktur_tanggal_trans, " _
                    & "if(faktur_ppn_jenis='1',faktur_jumlah-faktur_ppn,faktur_jumlah), 0, " _
                    & "faktur_ppn, faktur_netto, 'RETUR' " _
                    & "FROM data_pembelian_retur_faktur LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                    & ") beli {2} ORDER BY lap_tgl"
                q = String.Format(q, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

            Case "lapBeliSupplierBarang"
                q = "SELECT * FROM( " _
                    & "SELECT supplier_kode as dlap_supplier, supplier_nama as dlap_supplier_n, " _
                    & "trans_barang as dlap_barang, barang_nama as dlap_barang_n," _
                    & "SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)) as dlap_qty, " _
                    & "getQTYdetail(trans_barang, SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)), 2) as dlap_qty_n, " _
                    & "SUM(trans_qty*trans_harga_beli) as dlap_harga_beli, SUM(trans_qty*trans_harga_beli-trans_jumlah) as dlap_total_diskon, " _
                    & "SUM(trans_jumlah) as dlap_jumlah, 'BELI' as dlap_jenis " _
                    & "FROM data_pembelian_trans LEFT JOIN data_pembelian_faktur ON trans_faktur=faktur_kode AND faktur_status=1 " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                    & "WHERE trans_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                    & "GROUP BY supplier_kode, trans_barang " _
                    & "UNION " _
                    & "SELECT supplier_kode,supplier_nama, trans_barang, barang_nama, " _
                    & "	SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)), " _
                    & "	getQTYdetail(trans_barang, SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)), 2), " _
                    & "	SUM(trans_qty*trans_harga_retur) as dlap_harga_beli, 0 as dlap_total_diskon, " _
                    & "	SUM(trans_qty*trans_harga_retur) as dlap_jumlah, 'RETUR' as dlap_jenis " _
                    & "FROM data_pembelian_retur_trans LEFT JOIN data_pembelian_retur_faktur ON faktur_kode_bukti=trans_faktur AND faktur_status=1 " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                    & "WHERE trans_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                    & "GROUP BY supplier_kode,trans_barang" _
                    & ") beli {2} ORDER BY dlap_barang_n"
                q = String.Format(q, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

            Case "lapBeliTglBarang"
                q = "SELECT * FROM( " _
                    & "SELECT DATE_FORMAT(faktur_tanggal_trans,'%d-%m-%Y') as dlap_supplier, '' as dlap_supplier_n, " _
                    & "trans_barang as dlap_barang, barang_nama as dlap_barang_n," _
                    & "SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)) as dlap_qty, " _
                    & "getQTYdetail(trans_barang, SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)), 2) as dlap_qty_n, " _
                    & "SUM(trans_qty*trans_harga_beli) as dlap_harga_beli, SUM(trans_qty*trans_harga_beli-trans_jumlah) as dlap_total_diskon, " _
                    & "SUM(trans_jumlah) as dlap_jumlah, 'BELI' as dlap_jenis " _
                    & "FROM data_pembelian_trans LEFT JOIN data_pembelian_faktur ON trans_faktur=faktur_kode AND faktur_status=1 " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                    & "WHERE trans_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                    & "GROUP BY supplier_kode, trans_barang " _
                    & "UNION " _
                    & "SELECT DATE_FORMAT(faktur_tanggal_trans,'%d-%m-%Y'),'', trans_barang, barang_nama, " _
                    & "	SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)), " _
                    & "	getQTYdetail(trans_barang, SUM(countQTYItem(trans_barang, trans_qty, trans_satuan_type)), 2), " _
                    & "	SUM(trans_qty*trans_harga_retur) as dlap_harga_beli, 0 as dlap_total_diskon, " _
                    & "	SUM(trans_qty*trans_harga_retur) as dlap_jumlah, 'RETUR' as dlap_jenis " _
                    & "FROM data_pembelian_retur_trans LEFT JOIN data_pembelian_retur_faktur ON faktur_kode_bukti=trans_faktur AND faktur_status=1 " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                    & "WHERE trans_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' " _
                    & "GROUP BY supplier_kode,trans_barang" _
                    & ") beli {2} ORDER BY dlap_barang_n"
                q = String.Format(q, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

            Case "lapBeliTglNotaBarang"
                q = "SELECT faktur_tanggal_trans as dlap_tgl, supplier_nama dlap_supplier_n, barang_nama as dlap_barang_n," _
                    & "faktur_kode as dlap_faktur, CONCAT(trans_qty, ' ', trans_satuan) as dlap_qty, trans_harga_beli as dlap_harga_beli, " _
                    & "TRUNCATE(((trans_qty*trans_harga_beli-trans_jumlah)/(trans_qty*trans_harga_beli))*100,2) as dlap_total_diskon, " _
                    & "trans_jumlah as dlap_jumlah " _
                    & "FROM data_pembelian_trans LEFT JOIN data_pembelian_faktur ON trans_faktur=faktur_kode AND faktur_status=1 " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                    & "WHERE trans_status=1 AND faktur_tanggal_trans BETWEEN '{0}' AND '{1}' {2}"
                q = String.Format(q, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")
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

    Public Sub do_load(jenisTrans As String, judulLap As String, tipeLap As String)
        laptype = tipeLap
        lapwintext = judulLap

        With cb_jenis
            .DataSource = jenis(jenisTrans)
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 2
        End With

        date_tglawal.Value = selectperiode.tglawal
        date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)

        prcessSW()
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

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            setPopUpResult()
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

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_supplier_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(IIf(barang_sw = True, in_barang_n, bt_simpanbeli), e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("supplier", in_supplier_n.Text)
        End If
    End Sub

    Private Sub in_supplier_n_TextChanged(sender As Object, e As EventArgs) Handles in_supplier_n.TextChanged
        If in_supplier_n.Text = "" Then
            in_supplier.Clear()
            'AND OTHER STUFF
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

    Private Sub in_barang_n_Leave(sender As Object, e As EventArgs) Handles in_barang_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_barang_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_barang_n.KeyUp
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
            loadDataBRGPopup("barang", in_barang_n.Text)
        End If
    End Sub

    Private Sub in_barang_n_TextChanged(sender As Object, e As EventArgs) Handles in_barang_n.TextChanged
        If in_barang_n.Text = "" Then
            in_barang.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub fr_hutang_bayar_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub
End Class