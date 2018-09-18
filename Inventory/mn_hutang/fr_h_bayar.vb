Public Class fr_h_bayar
    Private popupstate As String = ""
    Private selectedsup As String = ""
    Private indexrowlist As Integer = 0
    Private indexrowfaktur As Integer = 0
    Private indexrowbayar As Integer = 0

    Private Sub loadDataHutang(kode As String)
        op_con()
        readcommd("SELECT hutang_faktur,hutang_supplier_n,ADDDATE(hutang_tgl,hutang_term) as hutang_jt, hutang_sisa FROM selectHutangAwal WHERE hutang_faktur='" & kode & "'")
        If rd.HasRows Then
            in_faktur.Text = rd.Item("hutang_faktur")
            in_supplier_n.Text = rd.Item("hutang_supplier_n")
            in_tgl_jt.Text = CDate(rd.Item("hutang_jt")).ToLongDateString
            in_sisa_hutang.Text = commaThousand(rd.Item("hutang_sisa"))
        End If
        rd.Close()

        loadListedBayar(kode)
    End Sub

    Private Sub loadListedBayar(kode As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT h_bayar_id, h_bayar_bukti, h_bayar_tgl, h_bayar_jenis, h_bayar_bg_no, h_bayar_bg_tgl, h_bayar_bank, h_bayar_kredit FROM data_hutang_bayar_test WHERE h_bayar_faktur='" & kode & "' AND h_bayar_status<>9")
        With dgv_bayar.Rows
            For Each rows As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("bayar_no_bukti").Value = rows.ItemArray(1)
                    .Cells("bayar_id").Value = rows.ItemArray(0)
                    .Cells("bayar_tgl").Value = rows.ItemArray(2)
                    .Cells("bayar_kodebayar").Value = rows.ItemArray(3)
                    .Cells("bayar_bgno").Value = rows.ItemArray(4)
                    .Cells("bayar_bank").Value = rows.ItemArray(6)
                    .Cells("bayar_kredit").Value = rows.ItemArray(7)
                    .Cells("bayar_bgtgl").Value = rows.ItemArray(5)
                End With
            Next
        End With
        dt.Dispose()
    End Sub

    Private Sub search()
        Using x As New fr_search_dialog
            With x
                If in_faktur.Text <> Nothing Then
                    .in_cari.Text = in_faktur.Text
                    .returnkode = in_faktur.Text
                End If
                .query = "SELECT hutang_faktur as kode, hutang_supplier_n as supplier, hutang_tgl as tanggal, hutang_sisa as SaldoHutang,ADDDATE(hutang_tgl,hutang_term) as 'Tgl.JatuhTempo' FROM selectHutangAwal"
                .paramquery = "supplier LIKE'{0}%' OR kode LIKE '{0}%'"
                .type = "hutangfaktur"
                .ShowDialog()
                in_faktur.Text = .returnkode
                loadDataHutang(in_faktur.Text)
            End With
        End Using
    End Sub

    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        setDoubleBuffered(Me.dgv_listbarang, True)
        Dim q As String
        With dgv_listbarang
            .DataSource = Nothing
            Select Case tipe
                Case "faktur"
                    q = "SELECT hutang_faktur as Faktur,hutang_supplier_n as 'Supplier', hutang_sisa as 'Saldo Hutang' FROM selectHutangAwal WHERE hutang_sisa<>0 AND hutang_faktur LIKE '" & param & "%' LIMIT 100"
                Case Else
                    Exit Sub
            End Select
            .DataSource = getDataTablefromDB(q)
            If tipe = "faktur" Then
                .Columns(1).DefaultCellStyle = dgvstyle_currency
                .Columns(1).Width = 150
            End If
            popupstate = tipe
        End With
    End Sub

    Private Sub textToDGV()
        op_con()
        If MessageBox.Show("Simpan data transaksi pembayaran hutang?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor

            'GENERATE KODE
            If in_no_bukti.Text = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT COUNT(h_bayar_bukti) FROM data_hutang_bayar_test WHERE SUBSTRING(h_bayar_bukti,3,8)='" & date_tgl_trans.Value.ToString("yyyyMMdd") & "' AND h_bayar_bukti LIKE 'PH%'")
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
            Dim q1 As String = "INSERT INTO data_hutang_bayar_test SET h_bayar_faktur='{0}',h_bayar_bukti='{1}',{2},{3} ON DUPLICATE KEY UPDATE {2},{4}"

            data1 = {
                "h_bayar_tgl='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                "h_bayar_jenis='" & cb_bayar.SelectedValue & "'",
                "h_bayar_bg_no='" & in_bg_no.Text & "'",
                "h_bayar_bg_tgl='" & date_bg_tgl.Value.ToString("yyyy-MM-dd") & "'",
                "h_bayar_bank='" & cb_bank.Text & "'",
                "h_bayar_kredit=" & in_kredit.Value
                }
            data2 = {
                "h_bayar_reg_alias='" & loggeduser.user_id & "'",
                "h_bayar_reg_date=NOW()"
                }
            data3 = {
                "h_bayar_upd_alias='" & loggeduser.user_id & "'",
                "h_bayar_upd_date=NOW()"
            }
            queryArr.Add(String.Format(q1, in_faktur.Text, in_no_bukti.Text, String.Join(",", data1), String.Join(",", data2), String.Join(",", data3)))

            querycheck = startTrans(queryArr)

            If querycheck = True Then
                dgv_bayar.Rows.Add(in_id_bayar.Text, in_no_bukti.Text, date_tgl_trans.Value.ToShortDateString, cb_bayar.SelectedValue, in_bg_no.Text, cb_bank.Text, in_kredit.Value, date_bg_tgl.Value.ToShortDateString)
                clearInput("bayar")
                in_sisa_hutang.Text = commaThousand(removeCommaThousand(in_sisa_hutang.Text) - countKredit())
            Else
                Exit Sub
            End If

        End If

    End Sub

    Private Sub dgvToText()
        With dgv_bayar.Rows(indexrowbayar)
            Try
                op_con()
                Dim q As String = "SELECT * FROM data_hutang_bayar_test WHERE h_bayar_faktur='" & in_faktur.Text & "' AND h_bayar_id='{0}'"
                If .Cells("bayar_id").Value <> Nothing Then
                    readcommd(String.Format(q, .Cells("bayar_id").Value))
                    If rd.HasRows Then
                        in_id_bayar.Text = rd.Item("h_bayar_id")
                        in_no_bukti.Text = rd.Item("h_bayar_bukti")
                        date_tgl_trans.Value = rd.Item("h_bayar_tgl")
                        cb_bayar.SelectedValue = rd.Item("h_bayar_jenis")
                        in_bg_no.Text = rd.Item("h_bayar_bg_no")
                        cb_bank.SelectedItem = rd.Item("h_bayar_bank")
                        in_kredit.Value = rd.Item("h_bayar_kredit")
                        date_bg_tgl.Value = rd.Item("h_bayar_bg_tgl")
                    End If
                    rd.Close()

                End If
            Catch ex As Exception
                consoleWriteLine(ex.Message)
            Finally
                in_no_bukti.Text = .Cells("bayar_no_bukti").Value
                date_tgl_trans.Value = .Cells("bayar_tgl").Value
                in_id_bayar.Text = .Cells("bayar_id").Value
                cb_bayar.SelectedValue = .Cells("bayar_kodebayar").Value
                in_bg_no.Text = .Cells("bayar_bgno").Value
                cb_bank.SelectedItem = .Cells("bayar_bank").Value
                in_kredit.Value = .Cells("bayar_kredit").Value
                date_bg_tgl.Value = .Cells("bayar_bgtgl").Value

            End Try
        End With
        'dgv_bayar.Rows.RemoveAt(indexrowbayar)
    End Sub

    Private Sub delBayar()
        Dim q1 As String = "UPDATE data_hutang_bayar_test SET h_bayar_status=9 WHERE h_bayar_no_bukti='{0}' AND h_bayar_id='{1}'"

        If in_id_bayar.Text = Nothing Then
            clearInput("bayar")
        Else
            commnd(String.Format(q1, in_no_bukti.Text, in_id_bayar.Text))
        End If

    End Sub

    Private Function countKredit()
        Dim _totalKre As Integer = 0
        For Each rows As DataGridViewRow In dgv_bayar.Rows
            _totalKre += rows.Cells("bayar_kredit").Value
        Next
        Return _totalKre
    End Function

    Private Sub clearInput(tipe As String)
        Dim txt As TextBox()
        Select Case tipe
            Case "faktur"
                txt = {in_faktur, in_supplier_n, in_sisa_hutang, in_tgl_jt}
            Case "bayar"
                txt = {in_no_bukti, in_bg_no, in_id_bayar, txtRegAlias, txtRegdate, txtUpdAlias, txtUpdDate}
                in_kredit.Value = 0
                date_bg_tgl.Value = DateSerial(selectedperiode.Year, selectedperiode.Month, date_tgl_trans.Value.Day)
                With date_tgl_trans
                    .Value = DateSerial(selectedperiode.Year, selectedperiode.Month, date_tgl_trans.Value.Day)
                    .MaxDate = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)
                    .MinDate = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
                End With
            Case "all"
                txt = {in_faktur, in_supplier_n, in_tgl_jt, in_sisa_hutang, in_no_bukti, in_bg_no, in_id_bayar, txtRegAlias, txtRegdate, txtUpdAlias, txtUpdDate}
                For Each dgv As DataGridView In {dgv_bayar, dgv_listbarang}
                    dgv.Rows.Clear()
                Next
                For Each nu As NumericUpDown In {in_kredit}
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
        For Each x As TextBox In txt
            x.Clear()
        Next
    End Sub

    Private Sub bayarSwitch(sw As Boolean)
        If sw = True Then
            in_no_bukti.ReadOnly = sw
            in_kredit.Enabled = False

        End If
    End Sub

    'Private Sub saveBayar()
    '    op_con()
    '    If MessageBox.Show("Simpan data transaksi pembayaran hutang?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '        Me.Cursor = Cursors.WaitCursor

    '        'GENERATE KODE
    '        If in_no_bukti.Text = Nothing Then
    '            Dim no As Integer = 1
    '            readcommd("SELECT COUNT(h_bayar_bukti) FROM data_hutang_bayar WHERE SUBSTRING(h_bayar_bukti,3,8)='" & date_tgl_trans.Value.ToString("yyyyMMdd") & "' AND h_bayar_bukti LIKE 'PH%'")
    '            If rd.HasRows Then
    '                no = CInt(rd.Item(0)) + 1
    '            End If
    '            rd.Close()
    '            in_no_bukti.Text = "PH" & date_tgl_trans.Value.ToString("yyyyMMdd") & no.ToString("D4")
    '        ElseIf in_no_bukti.Text <> Nothing Then
    '            If checkdata("data_hutang_bayar", "'" & in_no_bukti.Text & "'", "h_bayar_bukti") = True Then
    '                If MessageBox.Show("Update data?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
    '                    Exit Sub
    '                End If
    '            End If
    '        End If

    '        Dim querycheck As Boolean = False
    '        Dim data1, data2, data3 As String()
    '        Dim queryArr As New List(Of String)
    '        Dim q1 As String = "INSERT INTO data_hutang_bayar SET h_bayar_bukti='{0}',{1},{2} ON DUPLICATE KEY UPDATE {1},{3}"
    '        Dim q2 As String = "INSERT INTO data_hutang_bayar_faktur SET h_faktur_bukti='{0}',{1} ON DUPLICATE KEY UPDATE {1}"
    '        Dim q3 As String = "INSERT INTO data_hutang_bayar_trans SET h_trans_bukti='{0}',{1} ON DUPLICATE KEY UPDATE {1}"

    '        'INPUT HEADER
    '        data1 = {
    '            "h_bayar_tgl='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
    '            "h_bayar_debet=" & removeCommaThousand(in_total_deb.Text),
    '            "h_bayar_kredit=" & removeCommaThousand(in_total_kre.Text)
    '            }
    '        data2 = {
    '            "h_bayar_reg_date=NOW()",
    '            "h_bayar_reg_alias='" & loggeduser.user_id & "'"
    '            }
    '        data3 = {
    '            "h_bayar_upd_date=NOW()",
    '            "h_bayar_upd_alias='" & loggeduser.user_id & "'"
    '            }
    '        queryArr.Add(String.Format(q1, in_no_bukti.Text, String.Join(",", data1), String.Join(",", data2), String.Join(",", data3)))

    '        'INPUT FAKTUR
    '        Dim qdelfaktur As String = "DELETE FROM data_hutang_bayar_faktur WHERE h_faktur_bukti='{0}' AND h_faktur_faktur NOT IN({1})"
    '        Dim qdelbayar As String = "DELETE FROM data_hutang_bayar_trans WHERE h_trans_bukti='{0}' AND h_trans_jenisbayar NOT IN({1})"
    '        Dim faktur As New List(Of String)
    '        For Each rows As DataGridViewRow In dgv_faktur.Rows
    '            data1 = {
    '                "h_faktur_faktur='" & rows.Cells("faktur_kode").Value & "'",
    '                "h_faktur_debet='" & rows.Cells("faktur_debet").Value & "'"
    '                }
    '            queryArr.Add(String.Format(q2, in_no_bukti.Text, String.Join(",", data1)))
    '            faktur.Add("'" & rows.Cells("faktur_kode").Value & "'")
    '        Next
    '        'REMOVE DELETED FAKTUR
    '        queryArr.Add(String.Format(qdelfaktur, in_no_bukti.Text, String.Join(",", faktur)))

    '        'INPUT BAYAR
    '        faktur.Clear()
    '        For Each rows As DataGridViewRow In dgv_bayar.Rows
    '            data1 = {
    '                "h_trans_jenis_bayar='" & rows.Cells("bayar_kodebayar").Value & "'",
    '                "h_trans_nobg='" & rows.Cells("bayar_bgno").Value & "'",
    '                "h_trans_bank='" & rows.Cells("bayar_bank").Value & "'",
    '                "h_trans_kredit=" & rows.Cells("bayar_kredit").Value,
    '                "h_trans_tglbg='" & CDate(rows.Cells("bayar_bgtgl").Value).ToString("yyyy-MM-dd") & "'"
    '                }
    '            queryArr.Add(String.Format(q3, in_no_bukti.Text, String.Join(",", data1)))
    '            faktur.Add("'" & rows.Cells("bayar_kodebayar").Value & "'")
    '        Next


    '        'BEGIN TRANSACTION
    '        querycheck = startTrans(queryArr)
    '        Me.Cursor = Cursors.Default

    '        If querycheck = False Then
    '            Exit Sub
    '        Else
    '            'TODO : WRITE LOG ACTIVITY
    '            MessageBox.Show("Data tersimpan")
    '            frmhutangbayar.in_cari.Clear()
    '            populateDGVUserCon("hutangbayar", "", frmhutangbayar.dgv_list)
    '            Me.Close()
    '        End If
    '    End If
    'End Sub

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
        If MessageBox.Show("Tutup Form?", "Pembayaran Hutang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
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
    Private Sub mn_edit_Click(sender As Object, e As EventArgs) Handles mn_edit.Click
        bt_tbbayar.PerformClick()
    End Sub

    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_tbbayar.PerformClick()
    End Sub

    Private Sub mn_delete_Click(sender As Object, e As EventArgs) Handles mn_delete.Click

    End Sub

    Private Sub mn_proses_Click(sender As Object, e As EventArgs) Handles mn_proses.Click

    End Sub

    '------------- numeric
    Private Sub in_debet_Enter(sender As Object, e As EventArgs) Handles in_kredit.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_debet_Leave(sender As Object, e As EventArgs) Handles in_kredit.Leave
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
                Case "faktur"
                    in_faktur.Text = dgv_listbarang.Rows(indexrowlist).Cells(0).Value
                    loadDataHutang(in_faktur.Text)
                    cb_bayar.Focus()
                Case Else
                    Exit Sub
            End Select
        End If
    End Sub

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            Select Case popupstate
                Case "faktur"
                    in_faktur.Text = dgv_listbarang.Rows(indexrowlist).Cells(0).Value
                    loadDataHutang(in_faktur.Text)
                    cb_bayar.Focus()
                Case Else
                    Exit Sub
            End Select
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            e.Handled = True
            Select Case popupstate
                Case "faktur"
                    in_faktur.Text += e.KeyChar
                    in_faktur.Focus()
                Case Else
                    Exit Sub
            End Select
        End If
    End Sub

    Private Sub linkLbl_searchbarang_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLbl_searchbarang.LinkClicked
        search()
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

        For Each x As DataGridViewColumn In {bayar_kredit}
            x.DefaultCellStyle = dgvstyle_commathousand
        Next

        lbl_title.Focus()

        If in_faktur.Text <> Nothing Then
            loadDataHutang(in_faktur.Text)
            cb_bayar.Focus()
        End If
    End Sub

    '------------ save
    Private Sub save_Click(sender As Object, e As EventArgs) Handles bt_tbbayar.Click
        If cb_bayar.Text = Nothing Then

            Exit Sub
        End If
        If in_kredit.Value = 0 Then

            Exit Sub
        End If
        If cb_bayar.SelectedValue = "BG" Then
            If in_bg_no.Text = Nothing Then

                Exit Sub
            End If
            If cb_bank.Text = Nothing Then

                Exit Sub
            End If
        ElseIf cb_bayar.SelectedValue = "" Then

        End If

        textToDGV()
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
                loadDataHutang(in_faktur.Text)
            End If
        Else
            popPnl_barang.Visible = True
        End If

    End Sub

    Private Sub in_faktur_TextChanged(sender As Object, e As EventArgs) Handles in_faktur.TextChanged
        If in_faktur.Text = "" Then
            clearInput("faktur")
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
                keyshortenter(cb_bayar, e)
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            search()
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

    '---------------------- DGV Bayar
    Private Sub dgv_bayar_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_bayar.CellEnter
        If e.RowIndex > -1 Then
            indexrowbayar = e.RowIndex
            'dgvToText()
        End If
    End Sub
End Class