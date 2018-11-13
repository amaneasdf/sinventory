Public Class fr_lap_filter_hutang
    Private popupstate As String = "supplier"
    Private lapwintext As String = ""
    Public laptype As String
    Public bayar_sw As Boolean = False
    Public supplier_sw As Boolean = True
    Public faktur_sw As Boolean = False
    Public tgltrans_sw As Boolean = True
    Public periode_sw As Boolean = False

    Private Sub prcessSW()
        'If supplier_sw = False Then
        lbl_supplier.Visible = supplier_sw
        in_supplier.Visible = supplier_sw
        in_supplier_n.Visible = supplier_sw
        'End If
        'If jenis_sw = False Then
        lbl_bayar.Visible = bayar_sw
        cb_bayar.Visible = bayar_sw
        'End If
        'If barang_sw = False Then
        lbl_faktur.Visible = faktur_sw
        in_faktur.Visible = faktur_sw
        'End If
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
            Case "h_nota"
                bayar_sw = False
                faktur_sw = False
                prcessSW()

                date_tglawal.MinDate = selectperiode.tglawal

            Case "h_titipsupplier"
                bayar_sw = False
                faktur_sw = False
                periode_sw = False
                prcessSW()

                date_tglawal.Visible = False
                date_tglakhir.Location = New Point(date_tglawal.Left, date_tglawal.Top)
                lbl_tgl.Text = "S.d. Tanggal"
                lbl_tgl2.Visible = False

            Case "h_kartuhutang"
                bayar_sw = False
                faktur_sw = False
                prcessSW()

                date_tglawal.Enabled = False

            Case "h_bayarnota"
                periode_sw = False
                faktur_sw = True
                bayar_sw = True
                prcessSW()

                date_tglawal.Enabled = False
        End Select
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "supplier"
                q = "SELECT supplier_kode AS 'Kode', supplier_nama AS 'Nama' FROM data_supplier_master WHERE supplier_status=1 AND supplier_nama LIKE '{0}%'"
            Case "faktur"
                If in_supplier.Text <> Nothing Then
                    q = "SELECT hutang_faktur as 'Kode Faktur', supplier_kode as 'Kode Supplier', supplier_nama AS 'Supplier' " _
                        & "FROM data_hutang_awal LEFT JOIN data_pembelian_faktur ON hutang_faktur=faktur_kode AND faktur_status=1 " _
                        & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                        & "WHERE hutang_status=1 AND faktur_supplier='" & in_supplier.Text & "' AND hutang_faktur LIKE '{0}%'"
                Else
                    q = "SELECT hutang_faktur as 'Kode Faktur', supplier_kode as 'Kode Supplier', supplier_nama AS 'Supplier' " _
                        & "FROM data_hutang_awal LEFT JOIN data_pembelian_faktur ON hutang_faktur=faktur_kode AND faktur_status=1 " _
                        & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                        & "WHERE hutang_status=1 AND hutang_faktur LIKE '{0}%'"
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
                    'If faktur_sw = True Then in_faktur.Focus() Else bt_simpanbeli.Focus()
                Case "faktur"
                    in_faktur.Text = .Cells(0).Value
                    in_supplier.Text = .Cells(1).Value
                    in_supplier_n.Text = .Cells(2).Value
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
            Case "h_nota"
                'BASED periode,supplier;OPT saldo_sisa
                q = "SELECT supplier_kode as hn_supplier,supplier_nama as hn_supplier_n, ADDDATE(faktur_tanggal_trans,faktur_term) as hn_jt, " _
                    & "hutang_faktur as hn_faktur, if(faktur_tanggal_trans<'{0}',hutang_awal,0) as hn_saldoawal, " _
                    & "if(faktur_tanggal_trans>='{0}',hutang_awal,0) as hn_beli, IFNULL(h_trans_nilaibayar,0) as hn_bayar, " _
                    & "IFNULL(h_retur_total,0) as hn_retur, hutang_awal-IFNULL(h_trans_nilaibayar,0)-IFNULL(h_retur_total,0) as hn_sisa " _
                    & "FROM data_hutang_awal " _
                    & "LEFT JOIN (" _
                    & "SELECT SUM(IFNULL(h_retur_total,0)) as h_retur_total, h_retur_faktur " _
                    & "FROM data_hutang_retur " _
                    & "LEFT JOIN data_pembelian_retur_faktur ON h_retur_bukti_retur=faktur_kode_bukti " _
                    & "WHERE faktur_tanggal_trans BETWEEN '{0}' AND '{1}' AND h_retur_status=1 " _
                    & "GROUP BY h_retur_faktur" _
                    & ") retur ON h_retur_faktur=hutang_faktur " _
                    & "LEFT JOIN (" _
                    & "SELECT SUM(IFNULL(h_trans_nilaibayar,0)) as h_trans_nilaibayar, h_trans_faktur " _
                    & "FROM data_hutang_bayar_trans " _
                    & "LEFT JOIN data_hutang_bayar ON h_trans_bukti=h_bayar_bukti " _
                    & "AND h_bayar_tgl_bayar BETWEEN '{0}' AND '{1}' AND h_bayar_status=1 " _
                    & "WHERE h_trans_status=1 GROUP BY h_trans_faktur " _
                    & ") bayar ON h_trans_faktur=hutang_faktur " _
                    & "LEFT JOIN data_pembelian_faktur ON hutang_faktur=faktur_kode " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "WHERE hutang_status=1 {2}" _
                    & "ORDER BY supplier_nama, faktur_tanggal_trans"
                q = String.Format(q, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

                qwh += "AND hutang_idperiode='" & cb_periode.SelectedValue & "' "

                If in_supplier.Text <> Nothing Then
                    qwh += "AND faktur_supplier='" & in_supplier.Text & "' "
                End If

            Case "h_titipsupplier"
                'BASED supplier, tgl_akhir;OPT saldo_Sisa
                q = "SELECT faktur_supplier as hps_supplier, supplier_nama as hps_supplier_n, faktur_kode_bukti as hps_bukti, " _
                    & "faktur_tanggal_trans as hps_tanggal, debet as hps_debet, kredit as hps_kredit, " _
                    & "TRUNCATE(if(@change_supplier=supplier_nama,(@csum := @csum + (debet-kredit)),(@csum:=(debet-kredit))),2) as hps_sisa, " _
                    & "@change_supplier:=supplier_nama " _
                    & "FROM(" _
                    & "SELECT faktur_supplier, faktur_kode_bukti, faktur_tanggal_trans, IFNULL(faktur_netto,0) as debet, 0 as kredit " _
                    & "FROM data_pembelian_retur_faktur " _
                    & "WHERE faktur_status=1 AND faktur_jen_bayar='3' AND faktur_tanggal_trans<'{0}' " _
                    & "UNION " _
                    & "SELECT h_bayar_supplier, h_bayar_bukti, h_bayar_tgl_bayar,0, SUM(IFNULL(h_trans_nilaibayar,0)) as kredit " _
                    & "FROM data_hutang_bayar_trans " _
                    & "LEFT JOIN data_hutang_bayar ON h_trans_bukti=h_bayar_bukti " _
                    & "AND h_bayar_tgl_bayar < '{0}' AND h_bayar_status=1 " _
                    & "WHERE h_trans_status=1 AND h_trans_jenis_bayar='PIUTSUPL' GROUP BY h_bayar_bukti " _
                    & ") titipan " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                    & "JOIN (SELECT @csum := 0, @change_supplier:='') para " _
                    & "{1} ORDER BY supplier_nama, faktur_tanggal_trans"
                q = String.Format(q, date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

                If in_supplier.Text <> Nothing Then
                    qwh += "WHERE supplier_kode='" & in_supplier.Text & "' "
                End If

            Case "h_kartuhutang"
                'BASED periode,supplier;OPT 
                q = "SELECT supplier_kode as pk_custo,supplier_nama as pk_custo_n, supplier_alamat as pk_custo_k,tgl as pk_tgl, bukti as pk_no_bukti, " _
                    & "ket as pk_ket, debet as pk_debet,if(jenis='awal',0,kredit) as pk_kredit, " _
                    & "TRUNCATE(if(@change_supplier=supplier_nama,(@csum := @csum + (kredit-debet)),(@csum:=(kredit-debet))),2) as pk_saldo, " _
                    & "@change_supplier:=supplier_nama " _
                    & "FROM (" _
                    & "SELECT faktur_supplier as supplier, '{1}' as tgl, '' as bukti, 'SALDO AWAL' as ket, 0 as debet, " _
                    & "SUM(IF(faktur_tanggal_trans<'{2}',hutang_awal,0)) as kredit, 'awal' as jenis, faktur_reg_date as reg_date " _
                    & "FROM data_hutang_awal LEFT JOIN data_pembelian_faktur ON faktur_status=1 AND faktur_kode=hutang_faktur " _
                    & "WHERE hutang_status =1 AND hutang_idperiode={0} GROUP BY faktur_supplier " _
                    & "UNION " _
                    & "SELECT faktur_supplier as supplier,faktur_tanggal_trans as tgl, hutang_faktur as bukti, 'PEMBELIAN' as ket, " _
                    & "0 as debet, hutang_awal as kredit, 'hutang', faktur_reg_date " _
                    & "FROM data_hutang_awal LEFT JOIN data_pembelian_faktur ON hutang_faktur=faktur_kode " _
                    & "WHERE hutang_status = 1 AND faktur_tanggal_trans BETWEEN '{2}' AND '{3}' " _
                    & "UNION " _
                    & "SELECT faktur_supplier as supplier,faktur_tanggal_trans as tgl, faktur_kode_bukti as bukti, 'RETUR PEMBELIAN' as ket, " _
                    & "h_retur_total as debet, 0 as kredit, 'retur', faktur_reg_date " _
                    & "FROM data_hutang_retur LEFT JOIN data_pembelian_retur_faktur ON h_retur_bukti_retur=faktur_kode_bukti " _
                    & "WHERE h_retur_status = 1 AND faktur_tanggal_trans BETWEEN '{2}' AND '{3}' " _
                    & "UNION " _
                    & "SELECT faktur_supplier as supplier, h_bayar_tgl_bayar as tgl, h_bayar_bukti as bukti, " _
                    & "CONCAT('PEMBAYARAN ', h_trans_faktur) as ket, SUM(h_trans_nilaibayar) as debet, 0 as kredit, 'bayar', h_bayar_reg_date " _
                    & "FROM data_hutang_bayar LEFT JOIN data_hutang_bayar_trans ON h_trans_bukti=h_bayar_bukti AND h_trans_status =1 " _
                    & "LEFT JOIN data_pembelian_faktur ON h_trans_faktur=faktur_kode " _
                    & "WHERE h_bayar_status = 1 AND h_bayar_tgl_bayar BETWEEN '{2}' AND '{3}' " _
                    & "GROUP BY h_bayar_bukti,supplier " _
                    & ") hutang JOIN (SELECT @csum:=0, @change_supplier:='') para " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=supplier " _
                    & "{4} " _
                    & "ORDER BY supplier, tgl ASC, reg_date ASC, FIELD(jenis,'awal','hutang','retur','bayar') "
                q = String.Format(q, cb_periode.SelectedValue, date_tglawal.Value.AddDays(-1).ToString("yyyy-MM-dd"), date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

                If in_supplier.Text <> Nothing Then
                    qwh += "WHERE supplier_kode='" & in_supplier.Text & "' "
                End If
            Case "h_bayarnota"
                q = "SELECT * FROM( " _
                    & "SELECT supplier_nama as hbd_supplier_n, hutang_faktur as hbd_faktur,if(@faktur<>hutang_faktur,@ct:=0,@ct:=1) as count, " _
                    & "faktur_tanggal_trans as hbd_tanggal, " _
                    & "	(CASE WHEN @ct=0 THEN if(faktur_tanggal_trans<'{1}',@sisa:=hutang_awal,0) " _
                    & "		ELSE TRUNCATE(@sisa,2) END) as hbd_saldoawal, " _
                    & "	(CASE WHEN @ct=0 THEN if(faktur_tanggal_trans>='{1}',@sisa:=hutang_awal,0) " _
                    & "		ELSE 0 END) as hbd_beli, " _
                    & "	if(jenis='retur',h_trans_nilaibayar,0) as hbd_retur, if(jenis='bayar',h_trans_nilaibayar,0) as hbd_bayar, " _
                    & "	TRUNCATE(@sisa:= @sisa-h_trans_nilaibayar,2) as hbd_sisa, " _
                    & "	ket as hbd_ket,h_trans_tgl as hbd_tglbayar,DATEDIFF(h_trans_tgl,faktur_tanggal_trans) as hbd_hari,@faktur:=hutang_faktur " _
                    & "FROM ( " _
                    & "SELECT h_trans_faktur, h_trans_nilaibayar, h_bayar_tgl_bayar as h_trans_tgl, " _
                    & "	CONCAT(h_bayar_bukti,':',h_bayar_jenis_bayar) as ket, 'bayar' as jenis, h_bayar_reg_date as reg_date " _
                    & "FROM data_hutang_bayar LEFT JOIN data_hutang_bayar_trans ON h_trans_status=1 AND h_trans_bukti=h_bayar_bukti " _
                    & "WHERE h_bayar_status=1 AND h_bayar_tgl_bayar BETWEEN '{1}' AND '{2}' " _
                    & "UNION " _
                    & "SELECT h_retur_faktur, h_retur_total, faktur_tanggal_trans, " _
                    & "	CONCAT(faktur_kode_bukti, ':RETUR'), 'retur' as jenis, h_retur_reg_date " _
                    & "FROM data_hutang_retur LEFT JOIN data_pembelian_retur_faktur ON h_retur_bukti_retur=faktur_kode_bukti AND faktur_status=1 " _
                    & "WHERE h_retur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' " _
                    & "ORDER BY h_trans_tgl,reg_date " _
                    & ")transaksi " _
                    & "LEFT JOIN data_hutang_awal ON hutang_faktur=h_trans_faktur AND hutang_status=1 AND hutang_idperiode={0} " _
                    & "LEFT JOIN data_pembelian_faktur ON hutang_faktur=faktur_kode AND faktur_status=1 " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode= faktur_supplier " _
                    & "JOIN (SELECT @ct:=0, @sisa:=0, @faktur:='') para " _
                    & "ORDER BY supplier_nama,hutang_faktur, h_trans_tgl,count" _
                    & ") hhh {3}"
                q = String.Format(q, cb_periode.SelectedValue, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

                'FUK
                'If in_faktur.Text <> Nothing Then
                '    qwh += "WHERE hutang_faktur='" & in_faktur.Text & "' "
                '    If cb_bayar.SelectedValue <> "ALL" Then
                '        qwh += "AND SUBSTRING_INDEX(ket,':',-1)='" & cb_bayar.SelectedValue & "' "
                '    End If
                'Else
                '    If cb_bayar.SelectedValue <> "ALL" Then
                '        qwh += "WHERE SUBSTRING_INDEX(ket,':',-1)='" & cb_bayar.SelectedValue & "' "
                '    End If
                'End If
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
            .DataSource = jenis("bayarhutang")
            .DisplayMember = "Text"
            .ValueMember = "Value"
        End With
        date_tglawal.Value = selectperiode.tglawal
        date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)

        formSW(tipeLap)
        'prcessSW()
    End Sub

    Private Sub fr_lap_filter_hutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'LOAD LAPORAN
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        Dim x As New fr_lap_hutang With {
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
        If Not in_supplier_n.Focused Or in_faktur.Focused Then
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
        keyshortenter(in_supplier_n, e)
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
            keyshortenter(bt_simpanbeli, e)
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