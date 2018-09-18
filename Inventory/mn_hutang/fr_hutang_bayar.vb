Public Class fr_hutang_bayar
    Private popupstate As String = ""
    Private selectedsup As String = ""
    Private indexrowlist As Integer = 0
    Private indexrowfaktur As Integer = 0
    Private indexrowbayar As Integer = 0

    Private Sub loadData(kode As String)
        op_con()
        readcommd("SELECT h_bayar_bukti, h_bayar_supplier, supplier_nama, h_bayar_debet, h_bayar_kredit, h_bayar_debet-h_bayar_kredit as selisih, h_bayar_reg_alias,h_bayar_reg_date,h_bayar_upd_alias,h_bayar_upd_date FROM data_hutang_bayar LEFT JOIN data_supplier_master ON supplier_kode=h_bayar_supplier WHERE h_bayar_bukti='" & kode & "'")
        If rd.HasRows Then
            in_no_bukti.Text = rd.Item("h_bayar_bukti")
            in_supplier.Text = rd.Item("h_bayar_supplier")
            in_supplier_n.Text = rd.Item("supplier_nama")
            in_total_deb.Text = commaThousand(rd.Item("h_bayar_debet"))
            in_total_kre.Text = commaThousand(rd.Item("h_bayar_kredit"))
            in_total_sel.Text = commaThousand(rd.Item("selisih"))
            txtRegAlias.Text = rd.Item("h_bayar_reg_alias")
            txtRegdate.Text = rd.Item("h_bayar_reg_date")
            txtUpdAlias.Text = rd.Item("h_bayar_upd_alias")
            Try
                txtUpdDate.Text = rd.Item("h_bayar_upd_date")
            Catch ex As Exception
                txtUpdDate.Text = "0000/00/00 00:00:00"
            End Try
        End If
        rd.Close()

        selectedsup = in_supplier.Text
        loadListedFaktur(kode)
        loadListedBayar(kode)
        in_supplier.Focus()
    End Sub

    Private Sub loadListedFaktur(kode As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT h_faktur_faktur, h_faktur_debet FROM data_hutang_bayar_faktur WHERE h_faktur_bukti='" & kode & "'")
        With dgv_faktur.Rows
            For Each rows As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("faktur_kode").Value = rows.ItemArray(0)
                    .Cells("faktur_debet").Value = rows.ItemArray(1)
                End With
            Next
        End With
        dt.Dispose()
    End Sub

    Private Sub loadListedBayar(kode As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT h_trans_jenis_bayar, h_trans_nobg, h_trans_bank, h_trans_kredit,h_trans_tglbg FROM data_hutang_bayar_trans WHERE h_trans_bukti='" & kode & "'")
        With dgv_bayar.Rows
            For Each rows As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("bayar_kodebayar").Value = rows.ItemArray(0)
                    .Cells("bayar_bgno").Value = rows.ItemArray(1)
                    .Cells("bayar_bank").Value = rows.ItemArray(2)
                    .Cells("bayar_debet").Value = 0
                    .Cells("bayar_kredit").Value = rows.ItemArray(3)
                    .Cells("bayar_bgtgl").Value = rows.ItemArray(4)
                End With
            Next
        End With
        dt.Dispose()
    End Sub

    Private Sub search(tipe As String)
        Using x As New fr_search_dialog
            With x
                Select Case tipe
                    Case "faktur"
                        If in_faktur.Text <> Nothing Then
                            .in_cari.Text = in_faktur.Text
                            .returnkode = in_faktur.Text
                        End If
                        .query = "SELECT hutang_faktur as kode, hutang_supplier_n as supplier, hutang_tgl as tanggal, hutang_sisa as SaldoHutang,ADDDATE(hutang_tgl,hutang_term) as 'Tgl.JatuhTempo' FROM selectHutangAwal WHERE hutang_supplier='" & in_supplier.Text & "'"
                        .paramquery = "supplier LIKE'{0}%' OR kode LIKE '{0}%'"
                        .type = "hutangfaktur"
                        .ShowDialog()
                        in_faktur.Text = .returnkode
                        setFaktur(in_faktur.Text)
                    Case "supplier"
                        If in_supplier_n.Text <> Nothing Then
                            .in_cari.Text = in_supplier_n.Text
                        End If
                        If in_supplier.Text <> Nothing Then
                            .returnkode = in_supplier.Text
                        End If
                        .query = "SELECT supplier_kode as kode, supplier_nama as nama FROM data_supplier_master"
                        .paramquery = "nama LIKE'{0}%' OR kode LIKE '{0}%'"
                        .type = "supplier"
                        .ShowDialog()
                        in_supplier.Text = .returnkode
                        setSupplier(in_supplier.Text)
                    Case Else
                        Exit Sub
                End Select
            End With
        End Using
    End Sub

    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        setDoubleBuffered(Me.dgv_listbarang, True)
        Dim q As String
        With dgv_listbarang
            .DataSource = Nothing
            Select Case tipe
                Case "supplier"
                    q = "SELECT supplier_kode as Kode, supplier_nama as Nama FROM data_supplier_master WHERE supplier_nama LIKE '" & param & "%' LIMIT 100"
                Case "faktur"
                    q = "SELECT hutang_faktur as Faktur,hutang_sisa as 'Saldo Hutang' FROM selectHutangAwal WHERE hutang_supplier='" & in_supplier.Text & "' AND hutang_sisa<>0 AND hutang_faktur LIKE '" & param & "%'"
                Case Else
                    Exit Sub
            End Select
            .DataSource = getDataTablefromDB(q)
            If tipe = "faktur" Then
                .Columns(1).DefaultCellStyle = dgvstyle_currency
            End If
            popupstate = tipe
        End With
    End Sub

    Private Sub setSupplier(kode As String)
        If kode <> Nothing Then
            Dim q As String = "SELECT supplier_kode, supplier_nama FROM data_supplier_master WHERE supplier_kode='" & kode & "'"
            op_con()
            readcommd(q)
            If rd.HasRows Then
                in_supplier.Text = rd.Item("supplier_kode")
                in_supplier_n.Text = rd.Item("supplier_nama")
            End If
            rd.Close()
        End If

        If dgv_faktur.Rows.Count > 0 And (in_supplier.Text <> selectedsup) Then
            Dim x As DialogResult = MessageBox.Show("Supplier tidak sama dengan faktur yg diinput, ganti supplier?", "Bayar Hutang", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If x = Windows.Forms.DialogResult.Yes Then
                dgv_faktur.Rows.Clear()
            ElseIf x = Windows.Forms.DialogResult.No Then
                setSupplier(selectedsup)
            End If
        End If
    End Sub

    Private Sub setFaktur(kode As String)
        If kode <> Nothing Then
            Dim q As String = "SELECT hutang_faktur, hutang_sisa FROM selectHutangAwal WHERE hutang_faktur='" & kode & "'"
            op_con()
            readcommd(q)
            If rd.HasRows Then
                in_faktur.Text = rd.Item("hutang_faktur")
                in_sisa_hutang.Text = commaThousand(rd.Item("hutang_sisa"))
                in_faktur_debet.Maximum = rd.Item("hutang_sisa")
                in_faktur_debet.Value = rd.Item("hutang_sisa")
            End If
            rd.Close()
        End If
    End Sub

    Private Sub textToDGV(tipe As String)
        Select Case tipe
            Case "faktur"
                For Each rows As DataGridViewRow In dgv_faktur.Rows
                    If rows.Cells("faktur_kode").Value = in_faktur.Text Then
                        Exit Sub
                    End If
                Next

                dgv_faktur.Rows.Add(in_faktur.Text, in_faktur_debet.Value)
                clearInput(tipe)
                selectedsup = in_supplier.Text
            Case "bayar"
                dgv_bayar.Rows.Add(cb_bayar.SelectedValue, in_bg_no.Text, cb_bank.Text, in_debet.Text, in_kredit.Value, date_bg_tgl.Value.ToShortDateString)
                clearInput(tipe)
            Case Else
                Exit Select
        End Select
        countSelisih()
    End Sub

    Private Sub dgvToText(tipe As String)
        Select Case tipe
            Case "faktur"
                With dgv_faktur.Rows(indexrowfaktur)
                    in_faktur.Text = .Cells("faktur_kode").Value
                    setFaktur(in_faktur.Text)
                    in_faktur_debet.Value = .Cells("faktur_debet").Value
                End With
                dgv_faktur.Rows.RemoveAt(indexrowfaktur)
            Case "bayar"
                With dgv_bayar.Rows(indexrowbayar)
                    cb_bayar.SelectedValue = .Cells("bayar_kodebayar").Value
                    in_bg_no.Text = .Cells("bayar_bgno").Value
                    cb_bank.SelectedItem = .Cells("bayar_bank").Value
                    in_debet.Text = .Cells("bayar_debet").Value
                    in_kredit.Value = .Cells("bayar_kredit").Value
                    date_bg_tgl.Value = .Cells("bayar_bgtgl").Value
                End With
                dgv_bayar.Rows.RemoveAt(indexrowbayar)
            Case Else
                Exit Select
        End Select
        countSelisih()
    End Sub

    Private Sub countSelisih()
        Dim totaldebet As Integer = 0
        Dim totalkredit As Integer = 0
        Dim selisih As Integer = 0

        For Each rows As DataGridViewRow In dgv_faktur.Rows
            totaldebet += rows.Cells("faktur_debet").Value
        Next
        For Each rows As DataGridViewRow In dgv_bayar.Rows
            totalkredit += rows.Cells("bayar_kredit").Value
        Next

        in_total_deb.Text = commaThousand(totaldebet)
        in_total_kre.Text = commaThousand(totalkredit)
        in_total_sel.Text = commaThousand(totaldebet - totalkredit)
    End Sub

    Private Sub clearInput(tipe As String)
        Select Case tipe
            Case "faktur"
                in_faktur.Clear()
                in_sisa_hutang.Clear()
                in_faktur_debet.Value = 0
                in_faktur_debet.Maximum = 999999999999
            Case "bayar"
                For Each x As TextBox In {in_bg_no, in_debet}
                    x.Clear()
                Next
                in_kredit.Value = 0
                date_bg_tgl.Value = DateSerial(selectedperiode.Year, selectedperiode.Month, date_tgl_trans.Value.Day)
            Case "all"
                For Each x As TextBox In {in_faktur, in_supplier, in_supplier_n, in_sisa_hutang, in_no_bukti, in_bg_no, in_debet, in_total_deb, in_total_kre, in_total_sel, txtRegAlias, txtRegdate, txtUpdAlias, txtUpdDate}
                    x.Clear()
                Next
                For Each dgv As DataGridView In {dgv_bayar, dgv_faktur, dgv_listbarang}
                    dgv.Rows.Clear()
                Next
                For Each nu As NumericUpDown In {in_faktur_debet, in_kredit}
                    nu.Value = 0
                    nu.Maximum = 999999999999
                Next
                With date_tgl_trans
                    .Value = DateSerial(selectedperiode.Year, selectedperiode.Month, date_tgl_trans.Value.Day)
                    .MaxDate = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)
                    .MinDate = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
                End With
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub saveBayar()
        op_con()
        If MessageBox.Show("Simpan data transaksi pembayaran hutang?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor

            'GENERATE KODE
            If in_no_bukti.Text = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT COUNT(h_bayar_bukti) FROM data_hutang_bayar WHERE SUBSTRING(h_bayar_bukti,3,8)='" & date_tgl_trans.Value.ToString("yyyyMMdd") & "' AND h_bayar_bukti LIKE 'PH%'")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()
                in_no_bukti.Text = "PH" & date_tgl_trans.Value.ToString("yyyyMMdd") & no.ToString("D4")
            ElseIf in_no_bukti.Text <> Nothing Then
                If checkdata("data_hutang_bayar", "'" & in_no_bukti.Text & "'", "h_bayar_bukti") = True Then
                    If MessageBox.Show("Update data?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                End If
            End If

            Dim querycheck As Boolean = False
            Dim data1, data2, data3 As String()
            Dim queryArr As New List(Of String)
            Dim q1 As String = "INSERT INTO data_hutang_bayar SET h_bayar_bukti='{0}',{1},{2} ON DUPLICATE KEY UPDATE {1},{3}"
            Dim q2 As String = "INSERT INTO data_hutang_bayar_faktur SET h_faktur_bukti='{0}',{1} ON DUPLICATE KEY UPDATE {1}"
            Dim q3 As String = "INSERT INTO data_hutang_bayar_trans SET h_trans_bukti='{0}',{1} ON DUPLICATE KEY UPDATE {1}"

            'INPUT HEADER
            data1 = {
                "h_bayar_tgl='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                "h_bayar_supplier='" & in_supplier.Text & "'",
                "h_bayar_debet=" & removeCommaThousand(in_total_deb.Text),
                "h_bayar_kredit=" & removeCommaThousand(in_total_kre.Text)
                }
            data2 = {
                "h_bayar_reg_date=NOW()",
                "h_bayar_reg_alias='" & loggeduser.user_id & "'"
                }
            data3 = {
                "h_bayar_upd_date=NOW()",
                "h_bayar_upd_alias='" & loggeduser.user_id & "'"
                }
            queryArr.Add(String.Format(q1, in_no_bukti.Text, String.Join(",", data1), String.Join(",", data2), String.Join(",", data3)))

            'INPUT FAKTUR
            Dim qdelfaktur As String = "DELETE FROM data_hutang_bayar_faktur WHERE h_faktur_bukti='{0}' AND h_faktur_faktur NOT IN({1})"
            Dim qdelbayar As String = "DELETE FROM data_hutang_bayar_trans WHERE h_trans_bukti='{0}' AND h_trans_jenisbayar NOT IN({1})"
            Dim faktur As New List(Of String)
            For Each rows As DataGridViewRow In dgv_faktur.Rows
                data1 = {
                    "h_faktur_faktur='" & rows.Cells("faktur_kode").Value & "'",
                    "h_faktur_debet='" & rows.Cells("faktur_debet").Value & "'"
                    }
                queryArr.Add(String.Format(q2, in_no_bukti.Text, String.Join(",", data1)))
                faktur.Add("'" & rows.Cells("faktur_kode").Value & "'")
            Next
            'REMOVE DELETED FAKTUR
            queryArr.Add(String.Format(qdelfaktur, in_no_bukti.Text, String.Join(",", faktur)))

            'INPUT BAYAR
            faktur.Clear()
            For Each rows As DataGridViewRow In dgv_bayar.Rows
                data1 = {
                    "h_trans_jenis_bayar='" & rows.Cells("bayar_kodebayar").Value & "'",
                    "h_trans_nobg='" & rows.Cells("bayar_bgno").Value & "'",
                    "h_trans_bank='" & rows.Cells("bayar_bank").Value & "'",
                    "h_trans_kredit=" & rows.Cells("bayar_kredit").Value,
                    "h_trans_tglbg='" & CDate(rows.Cells("bayar_bgtgl").Value).ToString("yyyy-MM-dd") & "'"
                    }
                queryArr.Add(String.Format(q3, in_no_bukti.Text, String.Join(",", data1)))
                faktur.Add("'" & rows.Cells("bayar_kodebayar").Value & "'")
            Next


            'BEGIN TRANSACTION
            querycheck = startTrans(queryArr)
            Me.Cursor = Cursors.Default

            If querycheck = False Then
                Exit Sub
            Else
                'TODO : WRITE LOG ACTIVITY
                MessageBox.Show("Data tersimpan")
                frmhutangbayar.in_cari.Clear()
                populateDGVUserCon("hutangbayar", "", frmhutangbayar.dgv_list)
                Me.Close()
            End If
        End If
    End Sub

    '------------drag form
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

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalperkiraan.Click
        Me.Close()
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Tutup Form?", "Kas", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalperkiraan.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanperkiraan.PerformClick()
    End Sub

    Private Sub mn_delete_Click(sender As Object, e As EventArgs) Handles mn_delete.Click

    End Sub

    Private Sub mn_proses_Click(sender As Object, e As EventArgs) Handles mn_proses.Click

    End Sub

    '------------- numeric
    Private Sub in_debet_Enter(sender As Object, e As EventArgs) Handles in_kredit.Enter, in_faktur_debet.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_debet_Leave(sender As Object, e As EventArgs) Handles in_kredit.Leave, in_faktur_debet.Leave
        numericLostFocus(sender)
    End Sub

    '------------- cb prevent input
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_bayar.KeyPress
        e.Handled = True
    End Sub

    '---------- PopUp Search
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_supplier_n.Focused = True Or in_faktur.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub dgv_listbarang_Cellenter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellEnter
        If e.RowIndex >= 0 Then
            indexrowlist = e.RowIndex
        End If
    End Sub

    Private Sub dgv_listbarang_CellContentDBLClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellDoubleClick
        If e.RowIndex >= 0 Then
            indexrowlist = e.RowIndex
            Select Case popupstate
                Case "supplier"
                    in_supplier.Text = dgv_listbarang.Rows(indexrowlist).Cells(0).Value
                    setSupplier(in_supplier.Text)
                    in_faktur.Focus()
                Case "faktur"
                    in_faktur.Text = dgv_listbarang.Rows(indexrowlist).Cells(0).Value
                    setFaktur(in_faktur.Text)
                    in_faktur_debet.Focus()
                Case Else
                    Exit Sub
            End Select
        End If
    End Sub

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            Select Case popupstate
                Case "supplier"
                    in_supplier.Text = dgv_listbarang.Rows(indexrowlist).Cells(0).Value
                    setSupplier(in_supplier.Text)
                    in_faktur.Focus()
                Case "faktur"
                    in_faktur.Text = dgv_listbarang.Rows(indexrowlist).Cells(0).Value
                    setFaktur(in_faktur.Text)
                    in_faktur_debet.Focus()
                Case Else
                    Exit Sub
            End Select
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            e.Handled = True
            Select Case popupstate
                Case "supplier"
                    in_supplier_n.Text += e.KeyChar
                    in_supplier_n.Focus()
                Case "faktur"
                    in_faktur.Text += e.KeyChar
                    in_faktur.Focus()
                Case Else
                    Exit Sub
            End Select
        End If
    End Sub

    Private Sub linkLbl_searchbarang_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLbl_searchbarang.LinkClicked
        search(popupstate)
    End Sub

    '------------- load
    Private Sub fr_hutang_bayar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_bayar
            .DataSource = jenisBayar("hutang")
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With

        With date_tgl_trans
            .Value = DateSerial(selectedperiode.Year, selectedperiode.Month, date_tgl_trans.Value.Day)
            .MaxDate = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)
            .MinDate = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
        End With

        For Each x As DataGridViewColumn In {faktur_debet, bayar_kredit, bayar_debet}
            x.DefaultCellStyle = dgvstyle_commathousand
        Next

        lbl_title.Focus()

        If in_no_bukti.Text <> Nothing Then
            loadData(in_no_bukti.Text)
        End If
    End Sub

    '------------ save
    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click
        If in_supplier.Text = Nothing Then
            MessageBox.Show("Supplier belum di input")
            in_supplier.Focus()
            Exit Sub
        End If
        If dgv_faktur.Rows.Count = 0 Then
            MessageBox.Show("Faktur belum di input")
            in_faktur.Focus()
            Exit Sub
        End If
        If dgv_faktur.Rows.Count = 0 Then

            cb_bayar.Focus()
            Exit Sub
        End If

        If commaThousand(in_total_sel.Text) <> 0 Then
            If MessageBox.Show("Selisih", "bayar hutang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                Exit Sub

            End If
        End If

        saveBayar()
    End Sub

    '----------- Input Supplier
    '---------------pop up list Supplier
    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_supplier_n.Enter
        popPnl_barang.Location = New Point(in_supplier_n.Left, in_supplier_n.Top + in_supplier_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
            loadDataBRGPopup("supplier", in_supplier_n.Text)
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_supplier_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
            If Trim(in_supplier_n.Text) <> Nothing Then
                setSupplier(in_supplier_n.Text)
            End If
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_TextChanged(sender As Object, e As EventArgs) Handles in_supplier_n.TextChanged
        If in_supplier_n.Text = "" Then
            in_supplier.Clear()
        End If
    End Sub

    Private Sub in_supplier_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyUp
        If popPnl_barang.Visible = True Then
            loadDataBRGPopup("supplier", in_supplier_n.Text)
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyDown
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            Else
                keyshortenter(in_faktur, e)
            End If
        End If
    End Sub

    '----------- Input Faktur
    '---------------pop up list faktur
    Private Sub in_faktur_Enter(sender As Object, e As EventArgs) Handles in_faktur.Enter
        popPnl_barang.Location = New Point(in_faktur.Left, in_faktur.Top + in_faktur.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
            loadDataBRGPopup("faktur", in_faktur.Text)
        End If
    End Sub

    Private Sub in_faktur_Leave(sender As Object, e As EventArgs) Handles in_faktur.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
            If Trim(in_faktur.Text) <> Nothing Then
                setSupplier(in_faktur.Text)
            End If
        Else
            popPnl_barang.Visible = True
        End If

    End Sub

    Private Sub in_faktur_TextChanged(sender As Object, e As EventArgs) Handles in_faktur.TextChanged
        If in_faktur.Text = "" Then
            in_sisa_hutang.Clear()
            in_faktur_debet.Value = 0
        End If
    End Sub

    Private Sub in_faktur_KeyDown(sender As Object, e As KeyEventArgs) Handles in_faktur.KeyUp
        If popPnl_barang.Visible = True Then
            loadDataBRGPopup("faktur", in_faktur.Text)
        End If
    End Sub

    Private Sub in_faktur_KeyUp(sender As Object, e As KeyEventArgs) Handles in_faktur.KeyDown
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            Else
                keyshortenter(in_faktur_debet, e)
            End If
        End If
    End Sub

    Private Sub in_faktur_debet_KeyDown(sender As Object, e As KeyEventArgs) Handles in_faktur_debet.KeyDown
        keyshortenter(bt_faktur_add, e)
    End Sub

    '---------------------- bt Faktur
    Private Sub bt_faktur_add_Click(sender As Object, e As EventArgs) Handles bt_faktur_add.Click
        in_faktur.Text = Trim(in_faktur.Text)
        If in_faktur.Text = Nothing Then
            MessageBox.Show("Input/Pilih faktur yang akan dibayar terlebih dahulu.", "Pembayaran Hutang", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If in_faktur_debet.Value = 0 Then
            MessageBox.Show("Input nominal yang akan dibayar terlebih dahulu.", "Pembayaran Hutang", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        textToDGV("faktur")
    End Sub

    '---------------------- DGV Faktur
    Private Sub dgv_faktur_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_faktur.CellEnter
        If e.RowIndex > -1 Then
            indexrowfaktur = e.RowIndex
        End If
    End Sub

    Private Sub dgv_faktur_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_faktur.CellDoubleClick
        If e.RowIndex > -1 Then
            indexrowfaktur = e.RowIndex
            dgvToText("faktur")
        End If
    End Sub

    '----------- Input Bayar
    Private Sub cb_bayar_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_bayar.KeyDown
        keyshortenter(in_bg_no, e)
    End Sub

    Private Sub in_bg_no_KeyDown(sender As Object, e As KeyEventArgs) Handles in_bg_no.KeyDown
        keyshortenter(cb_bank, e)
    End Sub

    Private Sub cb_bank_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_bank.KeyDown
        keyshortenter(in_kredit, e)
    End Sub

    Private Sub in_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kredit.KeyDown
        keyshortenter(date_bg_tgl, e)
    End Sub

    Private Sub date_bg_tgl_KeyDown(sender As Object, e As KeyEventArgs) Handles date_bg_tgl.KeyDown
        keyshortenter(bt_tbbayar, e)
    End Sub

    Private Sub bt_tbbayar_Click(sender As Object, e As EventArgs) Handles bt_tbbayar.Click
        textToDGV("bayar")
    End Sub

    '---------------------- DGV Bayar
    Private Sub dgv_bayar_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_bayar.CellEnter
        If e.RowIndex > -1 Then
            indexrowbayar = e.RowIndex
        End If
    End Sub

    Private Sub dgv_bayar_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_bayar.CellDoubleClick
        If e.RowIndex > -1 Then
            indexrowbayar = e.RowIndex
            dgvToText("bayar")
        End If
    End Sub
End Class