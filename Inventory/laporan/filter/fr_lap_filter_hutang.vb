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
        Dim _tglawal As String = date_tglawal.Value.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = date_tglakhir.Value.ToString("yyyy-MM-dd")
        Select Case LCase(tipe)
            Case "h_nota"
                'BASED periode,supplier;OPT saldo_sisa
                q = "SELECT supplier_kode as hn_supplier,supplier_nama as hn_supplier_n, ADDDATE(faktur_tanggal_trans,faktur_term) as hn_jt, " _
                    & "h_trans_kode_hutang as hn_faktur, hutang_awal as hn_saldoawal, hutang_hutang as hn_beli, " _
                    & "(hutang_bayar*-1)-hutang_tolak as hn_bayar, hutang_retur*-1 as hn_retur, " _
                    & "hutang_awal+hutang_hutang+hutang_retur+hutang_bayar+hutang_tolak as hn_sisa " _
                    & "FROM ( " _
                    & " SELECT h_trans_kode_hutang,hutang_tgl, hutang_supplier, " _
                    & "  SUM(if(h_trans_jenis='awal',h_trans_nilai,0)) hutang_awal, " _
                    & "  SUM(if(h_trans_jenis='beli',h_trans_nilai,0)) hutang_hutang, " _
                    & "  SUM(if(h_trans_jenis='retur',h_trans_nilai,0)) hutang_retur, " _
                    & "  SUM(if(h_trans_jenis='bayar',h_trans_nilai,0)) hutang_bayar, " _
                    & "  SUM(if(h_trans_jenis='tolak',h_trans_nilai,0)) hutang_tolak, " _
                    & "  MAX(h_trans_tgl) hutang_tglakhir " _
                    & " FROM data_hutang_trans " _
                    & " RIGHT JOIN data_hutang_awal ON h_trans_kode_hutang=hutang_faktur AND hutang_status=1 " _
                    & " WHERE h_trans_status = 1 And h_trans_periode ='{2}' " _
                    & " GROUP BY h_trans_kode_hutang " _
                    & ")hutang " _
                    & "LEFT JOIN data_pembelian_faktur ON faktur_kode=h_trans_kode_hutang " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=hutang_supplier " _
                    & "WHERE hutang_tgl BETWEEN '{0}' AND '{1}' {3}" _
                    & "ORDER BY supplier_nama, faktur_tanggal_trans"
                q = String.Format(q, _tglawal, _tglakhir, selectperiode.id, "{0}")

                'qwh += "AND hutang_idperiode='" & cb_periode.SelectedValue & "' "

                If in_supplier.Text <> Nothing Then
                    qwh += "AND faktur_supplier='" & in_supplier.Text & "' "
                End If

            Case "h_titipsupplier"
                'BASED supplier, tgl_akhir;OPT saldo_Sisa
                q = "SELECT titipan.*, supplier_nama as hps_supplier_n, " _
                    & "TRUNCATE(if(@change_supplier=supplier_nama,(@csum := @csum + (hps_debet-hps_kredit)),(@csum:=(hps_debet-hps_kredit))),2) as hps_sisa, " _
                    & "CONCAT_WS(' : ',h_titip_faktur, UCASE(h_titip_tipe)) hps_bukti, " _
                    & "@change_supplier:=supplier_nama " _
                    & "FROM(" _
                    & " SELECT h_titip_id,h_titip_ref hps_supplier,h_titip_tgl hps_tanggal, " _
                    & "  IF(h_titip_nilai>0,h_titip_nilai,0) as hps_debet, IF(h_titip_nilai<0,h_titip_nilai*-1,0) as hps_kredit, " _
                    & "  h_titip_faktur, h_titip_tipe " _
                    & " FROM data_hutang_titip WHERE h_titip_idperiode='{0}' AND h_titip_status=1 " _
                    & " ORDER BY h_titip_ref, h_titip_tgl, h_titip_id " _
                    & ") titipan " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=hps_supplier " _
                    & "JOIN (SELECT @csum := 0, @change_supplier:='') para " _
                    & "WHERE hps_tanggal<='{1}' {2}"
                q = String.Format(q, cb_periode.SelectedValue, _tglakhir, "{0}")

                If in_supplier.Text <> Nothing Then
                    qwh += "AND supplier_kode='" & in_supplier.Text & "' "
                End If

            Case "h_kartuhutang"
                'BASED periode,supplier;OPT 
                q = "SELECT hhh.*, supplier_nama as pk_custo_n, supplier_alamat as pk_custo_k, " _
                    & "TRUNCATE(if(@change_supplier=supplier_nama,(@csum := @csum + (pk_debet-pk_kredit)),(@csum:=(pk_debet-pk_kredit))),2) as pk_saldo, " _
                    & "@change_supplier:=supplier_nama " _
                    & "FROM( " _
                    & " SELECT 0 h_trans_id,'' h_trans_kode_hutang,hutang_supplier pk_custo,h_trans_tgl pk_tgl," _
                    & "  '' pk_no_bukti,'SALDO AWAL' pk_ket,SUM(if(h_trans_jenis='awal',h_trans_nilai,0)) pk_debet,0 pk_kredit " _
                    & " FROM data_hutang_trans  " _
                    & " RIGHT JOIN data_hutang_awal ON h_trans_kode_hutang=hutang_faktur AND hutang_status=1 " _
                    & " WHERE h_trans_status = 1 And h_trans_periode ='{0}' AND h_trans_jenis='awal' " _
                    & " GROUP BY hutang_supplier " _
                    & " UNION " _
                    & " SELECT h_trans_id,h_trans_kode_hutang,hutang_supplier,h_trans_tgl,h_trans_faktur, " _
                    & "  (CASE h_trans_jenis " _
                    & "     WHEN 'beli' THEN 'PENJUALAN' " _
                    & "     WHEN 'retur' THEN 'RETUR PENJUALAN' " _
                    & "     WHEN 'bayar' THEN CONCAT_WS(' ','PEMBAYARAN',h_trans_kode_hutang,h_trans_giro) " _
                    & "     WHEN 'tolak' THEN CONCAT('TOLAK ',h_trans_faktur) " _
                    & "     WHEN 'cair' THEN CONCAT('PENCAIRAN ',h_trans_giro) " _
                    & "     ELSE 'ERROR' " _
                    & "  END) ket,if(h_trans_nilai>0,h_trans_nilai,0) debet, " _
                    & "  if(h_trans_nilai<0,h_trans_nilai*-1,0) kredit " _
                    & " FROM data_hutang_trans " _
                    & " RIGHT JOIN data_hutang_awal ON h_trans_kode_hutang=hutang_faktur AND hutang_status=1 " _
                    & " WHERE h_trans_status = 1 And h_trans_periode ='{0}' AND h_trans_jenis <> 'awal' " _
                    & " ORDER BY pk_custo,pk_tgl,h_trans_id " _
                    & ")hhh " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=pk_custo " _
                    & "JOIN (SELECT @change_supplier:='',@csum:=0) para " _
                    & "WHERE pk_tgl BETWEEN '{1}' AND '{2}' {3}"
                q = String.Format(q, cb_periode.SelectedValue, _tglawal, _tglakhir, "{0}")

                If in_supplier.Text <> Nothing Then
                    qwh += "AND supplier_kode='" & in_supplier.Text & "' "
                End If

            Case "h_bayarnota"
                q = "SELECT h_trans_kode_hutang hbd_faktur,hutang_supplier hbd_supplier,supplier_nama hbd_supplier_n, " _
                    & "faktur_tanggal_trans hbd_tanggal, h_trans_tgl hbd_tglbayar, hutang_awal hbd_saldoawal, hutang_retur * -1 hbd_retur, hutang_bayar * -1 hbd_bayar," _
                    & "hutang_tolak hbd_beli,hutang_sisa hbd_sisa, ket hbd_ket, hbd_hari " _
                    & "FROM( " _
                    & "SELECT h_trans_kode_hutang,hutang_supplier,h_trans_tgl,faktur_tanggal_trans," _
                    & " if(@faktur<>h_trans_kode_hutang,@ct:=0,@ct:=@ct+1) as count," _
                    & " h_trans_jenis," _
                    & " if(@ct=0,@sisa:=if(h_trans_jenis='awal',h_trans_nilai,0),TRUNCATE(@sisa,2)) hutang_awal," _
                    & " if(h_trans_jenis='beli',h_trans_nilai,0) hutang_hutang," _
                    & " if(h_trans_jenis='retur',h_trans_nilai,0) hutang_retur," _
                    & " if(h_trans_jenis='bayar',h_trans_nilai,0) hutang_bayar," _
                    & " if(h_trans_jenis='tolak',h_trans_nilai,0) hutang_tolak," _
                    & " TRUNCATE(@sisa:=@sisa+h_trans_nilai,2) hutang_sisa," _
                    & " IF(h_trans_jenis NOT IN('awal','jual')," _
                    & " CONCAT(h_trans_faktur,':',(CASE " _
                    & "     WHEN h_trans_jenis='bayar' THEN h_bayar_jenis_bayar " _
                    & "     WHEN h_trans_jenis='retur' THEN 'RETUR' " _
                    & "     WHEN h_trans_jenis='tolak' THEN 'BGTOLAK' " _
                    & "     WHEN h_trans_jenis='cair' THEN 'BGCAIR' " _
                    & "     Else '-' END)),'-')	ket,DATEDIFF(h_trans_tgl,faktur_tanggal_trans) as hbd_hari, " _
                    & " @faktur:=h_trans_kode_hutang " _
                    & "FROM data_hutang_trans " _
                    & "RIGHT JOIN data_hutang_awal ON h_trans_kode_hutang=hutang_faktur AND hutang_status=1 " _
                    & "LEFT JOIN data_pembelian_faktur ON faktur_kode=h_trans_kode_hutang AND faktur_status=1 " _
                    & "LEFT JOIN data_hutang_bayar ON h_trans_faktur=h_bayar_bukti " _
                    & "JOIN(SELECT @sisa:=0,@faktur:='') para " _
                    & "WHERE h_trans_status = 1 And h_trans_periode = '{0}'" _
                    & ")hhh " _
                    & "LEFT JOIN data_supplier_master ON hutang_supplier=supplier_kode " _
                    & "WHERE h_trans_jenis NOT IN ('awal','beli') {1}"
                'q = String.Format(q, cb_periode.SelectedValue, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")
                q = String.Format(q, cb_periode.SelectedValue, "{0}")


                Dim whr As New List(Of String)
                Dim op As Boolean = False

                qwh += "AND h_trans_tgl BETWEEN '" & _tglawal & "' AND '" & _tglakhir & "' {0}{1}"
                If in_supplier.Text <> Nothing Or in_faktur.Text <> Nothing Or cb_bayar.SelectedValue <> "ALL" Then
                    op = True
                End If
                If in_supplier.Text <> Nothing Then
                    whr.Add("piutang_custo='" & in_supplier.Text & "'")
                End If
                If in_faktur.Text <> Nothing Then
                    whr.Add("h_trans_kode_hutang='" & in_faktur.Text & "'")
                End If
                If cb_bayar.SelectedValue <> "ALL" Then
                    whr.Add("SUBSTRING_INDEX(ket,':',-1)='" & cb_bayar.SelectedValue & "'")
                End If

                qwh = String.Format(qwh, IIf(op, "AND ", ""), String.Join(" AND ", whr))

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

    'EXPORT
    Private Sub exportData(type As String)
        Dim q As String = createQuery(type)
        Dim _dt As New DataTable
        Dim _colheader As New List(Of String)
        Dim _outputdir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Inventory\"
        Dim _filename As String = "dataexport" & Today.ToString("yyyyMMdd")
        Dim _respond As Boolean = False
        Dim _svdialog As New SaveFileDialog
        Dim _title As String = ""

        MyBase.Cursor = Cursors.AppStarting

        Select Case type
            Case "h_nota"
                _colheader.AddRange({"Kode Supplier", "Nama Supplier", "Tgl.Jatuh Tempo", "Faktur", "Saldo Awal", "Pembayaran", "Retur", "Sisa"})
                _title = "LAPORAN HUTANG SUPPLIER PER NOTA"
                _filename = "SupplierNota" & Today.ToString("yyyyMMdd") & ".xlsx"
            Case "h_titipsupplier"
                _colheader.AddRange({"Kode Supplier", "Nama Supplier", "No.Bukti Transaksi", "Tanggal", "Jenis", "Debet", "Kredit"})
                q = "SELECT hps_supplier, hps_supplier_n,h_titip_faktur, hps_tanggal,UCASE(h_titip_tipe),hps_debet, hps_kredit FROM (" & q & ") datatabl"
                _title = "LAPORAN PIUTANG TITIPAN PER SUPPLIER"
                _filename = "PiutangSupplier" & Today.ToString("yyyyMMdd") & ".xlsx"
            Case "h_kartuhutang"
                _colheader.AddRange({"Kode Supplier", "Nama Supplier", "Tgl. Transaksi", "No.Bukti Transaksi", "Keterangan", "Debit", "Kredit", "Saldo"})
                _title = "KARTU HUTANG PER SUPPLIER"
                _filename = "KartuHutang" & Today.ToString("yyyyMMdd") & ".xlsx"
                q = "SELECT pk_custo, pk_custo_n, pk_tgl, pk_no_bukti, pk_ket, pk_debet, pk_kredit, pk_saldo FROM (" & q & ") kartuhutang"

            Case "h_bayarnota"
                _colheader.AddRange({"No.Faktur Pembelian", "Kode Supplier", "Nama Supplier", "Tgl.Pembelian", "Tgl.Pembayaran", "Saldo Awal", "Retur",
                                     "Pembayaran", "Bayar Ditolak", "Keterangan", "Range Hari"})
                _title = "LAPORAN HISTORI PEMBAYARAN HUTANG"
                _filename = "PembayaranHutang" & Today.ToString("yyyyMMdd") & ".xlsx"

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
            .DataSource = jenis("bayarhutang")
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
        Dim x As New fr_lap_hutang With {
                    .Text = lapwintext
                }
        x.setVar(laptype, createQuery(laptype), date_tglawal.Value.ToString("dd/MM/yyyy") & " S.d " & date_tglakhir.Value.ToString("dd/MM/yyyy"))
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

    '------------- INPUT UI
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

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyUp, in_faktur.KeyUp
        Dim _nxtcontrol As Object
        Dim _kdcontrol As Object
        Select Case sender.Name.ToString
            Case "in_supplier_n"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = in_supplier
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
End Class