﻿Public Class fr_lap_filter_jual
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
        ElseIf sales_sw = "ON" Or sales_sw = "SUPPLIER" Then
            lbl_sales.Visible = True
            in_sales.Visible = True
            in_sales_n.Visible = True
            If sales_sw = "SUPPLIER" Then
                lbl_sales.Text = "Supplier"
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

            Case "lapJualCusto"
                jenis_sw = False
                barang_sw = False
                sales_sw = "OFF"
                prcessSW()

                lbl_custo.Location = lbl_jenis.Location
                in_custo.Location = cb_jenis.Location
                in_custo_n.Location = New Point(in_custo_n.Left, cb_jenis.Top)

            Case "lapJualTgl"
                jenis_sw = False
                custo_sw = False
                barang_sw = False
                sales_sw = "OFF"
                prcessSW()

                Me.Size = New Point(591, 189)

            Case "lapJualSales"
                barang_sw = False
                custo_sw = False
                sales_sw = "ON"
                prcessSW()

            Case "lapJualSalesNota"
                barang_sw = False
                custo_sw = False
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
                Case "supplier", "sales"
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
                              & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' " _
                              & " UNION " _
                              & " SELECT salesman_kode, salesman_nama, customer_kode, customer_nama, faktur_kode_bukti, faktur_tanggal_trans," _
                              & "  if(faktur_ppn_jenis='1', faktur_jumlah-faktur_ppn_persen,faktur_jumlah) as brutto," _
                              & "  0, faktur_ppn_persen, faktur_netto, 'RETUR' as jenis " _
                              & " FROM data_penjualan_retur_faktur LEFT JOIN data_customer_master ON faktur_custo=customer_kode " _
                              & " LEFT JOIN data_salesman_master ON salesman_kode=faktur_sales " _
                              & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' " _
                              & ") jual {3} {4}"

        Dim qtk As String = "SELECT {0} FROM (" _
                            & " SELECT customer_kode as lap_custo, customer_nama as lap_custo_n, faktur_kode as lap_faktur, " _
                            & "  faktur_tanggal_trans as lap_tanggal, 0 as lap_tunai," _
                            & "  if(faktur_ppn_jenis='1', faktur_jumlah-faktur_ppn_persen,faktur_jumlah) as lap_kredit, " _
                            & "  faktur_disc_rupiah as lap_diskon, faktur_ppn_persen as lap_ppn, faktur_netto as lap_jumlah, 'JUAL' as lap_jenis " _
                            & " FROM data_penjualan_faktur LEFT JOIN data_customer_master ON faktur_customer=customer_kode " _
                            & " WHERE faktur_status=1 AND faktur_term<>0 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' " _
                            & " UNION " _
                            & " SELECT customer_kode, customer_nama, faktur_kode, faktur_tanggal_trans, " _
                            & "  if(faktur_ppn_jenis='1', faktur_jumlah-faktur_ppn_persen,faktur_jumlah) as tunai, 0 as kredit, " _
                            & "  faktur_disc_rupiah, faktur_ppn_persen, faktur_netto, 'JUAL' as jenis " _
                            & " FROM data_penjualan_faktur LEFT JOIN data_customer_master ON faktur_customer=customer_kode " _
                            & " WHERE faktur_status=1 AND faktur_term=0 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' " _
                            & ") jual {3} {4}"
        Dim qbarang As String = "SELECT {0} FROM (" _
                                & " SELECT faktur_sales, faktur_customer,trans_barang, faktur_kode, faktur_tanggal_trans, " _
                                & "  @subtot:=trans_harga_jual*trans_qty as subtot, " _
                                & "  TRUNCATE(@ppn:=IF(faktur_ppn_jenis='1',@subtot*(1-(10/11)),0),2) as ppn, " _
                                & "  0 as tunai, TRUNCATE(@subtot-@ppn,2) as kredit, " _
                                & "  @subtot-trans_jumlah as diskon, trans_jumlah as netto,'JUAL' as jenis " _
                                & " FROM data_penjualan_faktur LEFT JOIN data_penjualan_trans ON faktur_kode=trans_faktur AND trans_status=1 " _
                                & " WHERE faktur_status=1 AND faktur_term<>0 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' " _
                                & " UNION " _
                                & " SELECT faktur_sales, faktur_customer,trans_barang, faktur_kode, faktur_tanggal_trans, " _
                                & "  @subtot:=trans_harga_jual*trans_qty as subtot, " _
                                & "  TRUNCATE(@ppn:=IF(faktur_ppn_jenis='1',@subtot*(1-(10/11)),0),2) as ppn, " _
                                & "  TRUNCATE(@subtot-@ppn,2) as tunai, 0 as kredit, " _
                                & "  @subtot-trans_jumlah as diskon, trans_jumlah as netto,'JUAL' as jenis " _
                                & " FROM data_penjualan_faktur LEFT JOIN data_penjualan_trans ON faktur_kode=trans_faktur AND trans_status=1 " _
                                & " WHERE faktur_status=1 AND faktur_term=0 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' " _
                                & " UNION " _
                                & " SELECT faktur_sales, faktur_custo,trans_barang, faktur_kode_bukti, faktur_tanggal_trans, " _
                                & "  @subtot:=trans_harga_retur*trans_qty as subtot, " _
                                & "  TRUNCATE(@ppn:=IF(faktur_ppn_jenis='1',@subtot*(1-(10/11)),0),2) as ppn, " _
                                & "  0 as tunai, TRUNCATE(@subtot-@ppn,2) as kredit, @diskon:=@subtot*(trans_diskon/100) as diskon, " _
                                & "  @subtot-@diskon as netto, 'RETUR' as jenis " _
                                & " FROM data_penjualan_retur_faktur " _
                                & " LEFT JOIN data_penjualan_retur_trans ON faktur_kode_bukti=trans_faktur AND trans_status=1 " _
                                & " WHERE faktur_status=1 AND faktur_jen_bayar<>2 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' " _
                                & " UNION " _
                                & " SELECT faktur_sales, faktur_custo,trans_barang, faktur_kode_bukti, faktur_tanggal_trans, " _
                                & "  @subtot:=trans_harga_retur*trans_qty as subtot, " _
                                & "  TRUNCATE(@ppn:=IF(faktur_ppn_jenis='1',@subtot*(1-(10/11)),0),2) as ppn, " _
                                & "  0 as tunai, TRUNCATE(@subtot-@ppn,2) as kredit, @diskon:=@subtot*(trans_diskon/100) as diskon, " _
                                & "  @subtot-@diskon as netto, 'RETUR' as jenis " _
                                & " FROM data_penjualan_retur_faktur " _
                                & " LEFT JOIN data_penjualan_retur_trans ON faktur_kode_bukti=trans_faktur AND trans_status=1 " _
                                & " WHERE faktur_status=1 AND faktur_jen_bayar=2 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' " _
                                & ") jual {3} {4}"


        Select Case tipe
            Case "lapJualNota"
                q = String.Format(qnota, "*", date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}", "")

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
                    "lap_custo_n",
                    "SUM(lap_tunai) as lap_tunai",
                    "SUM(lap_kredit) as lap_brutto",
                    "SUM(lap_diskon) as lap_diskon",
                    "SUM(lap_ppn) as lap_ppn",
                    "SUM(lap_jumlah) as lap_jumlah"
                    }
                q = String.Format(qtk, String.Join(",", qcolselect), date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"),
                                  "{0}", "GROUP BY lap_custo")

                If in_custo.Text <> Nothing Then
                    qwh += "WHERE lap_custo='" & in_custo.Text & "'"
                End If

            Case "lapJualSales"
                qcolselect = {
                    "lap_sales",
                    "lap_sales_n",
                    "SUM(lap_brutto) as lap_brutto",
                    "SUM(lap_diskon) as lap_diskon",
                    "SUM(lap_ppn) as lap_ppn",
                    "SUM(lap_jumlah) as lap_jumlah",
                    "lap_jenis"
                    }
                q = String.Format(qnota, String.Join(",", qcolselect), date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"),
                                  "{0}", "GROUP BY lap_sales,lap_jenis")

                If in_sales.Text <> Nothing Then
                    qwh += "WHERE lap_sales='" & in_sales.Text & "'"
                End If

            Case "lapJualTgl"
                qcolselect = {
                    "lap_tanggal",
                    "SUM(lap_tunai) as lap_tunai",
                    "SUM(lap_kredit) as lap_brutto",
                    "SUM(lap_diskon) as lap_diskon",
                    "SUM(lap_ppn) as lap_ppn",
                    "SUM(lap_jumlah) as lap_jumlah",
                    "lap_jenis"
                    }
                q = String.Format(qtk, String.Join(",", qcolselect), date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"),
                                  "{0}", "GROUP BY lap_tanggal,lap_jenis")

            Case "lapJualSupplier"
                qcolselect = {
                    "jenis as lap_jenis",
                    "supplier_nama as lap_custo_n",
                    "SUM(tunai) as lap_tunai",
                    "SUM(kredit) as lap_brutto",
                    "SUM(diskon) as lap_diskon",
                    "SUM(ppn) as lap_ppn",
                    "SUM(netto) as lap_jumlah"
                    }
                q = String.Format(qbarang, String.Join(",", qcolselect), date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"),
                                  "LEFT JOIN data_barang_master ON trans_barang=barang_kode LEFT JOIN data_supplier_master ON supplier_kode=barang_supplier {0}",
                                  "GROUP BY barang_supplier,jenis ORDER BY jenis,supplier_nama")

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
                    "jenis_nama as lap_custo_n",
                    "SUM(lap_tunai) as lap_tunai",
                    "SUM(lap_kredit) as lap_kredit",
                    "SUM(lap_diskon) as lap_diskon",
                    "SUM(lap_ppn) as lap_ppn",
                    "SUM(lap_jumlah) as lap_jumlah",
                    "lap_jenis"
                    }
                q = String.Format(qnota, String.Join(",", qcolselect), date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"),
                                  "LEFT JOIN data_customer_master ON lap_custo=customer_kode LEFT JOIN data_customer_jenis ON customer_jenis=jenis_kode {0}",
                                  "GROUP BY jenis_kode,lap_jenis")

            Case "lapJualBarang"
                qcolselect = {
                    }
            Case "lapJualSalesNota"
                q = String.Format(qnota, "*", date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}", "")

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

        formSW(tipeLap)
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
                    x = in_sales_n
                Case "sales"
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
        popupstate = IIf(sales_sw = "SUPPLIER", "supplier", "sales")
        loadDataBRGPopup(popupstate, in_sales_n.Text)
    End Sub

    Private Sub in_sales_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_sales_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp
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
            loadDataBRGPopup(IIf(sales_sw = "SUPPLIER", "supplier", "sales"), in_sales_n.Text)
        End If
    End Sub

    Private Sub in_sales_n_TextChanged(sender As Object, e As EventArgs) Handles in_sales_n.TextChanged
        If in_sales_n.Text = "" Then
            in_sales.Clear()
            'AND OTHER STUFF
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


    Private Sub fr_hutang_bayar_Click(sender As Object, e As EventArgs) Handles MyBase.Click, Panel1.Click, Panel3.Click, lbl_title.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub
End Class