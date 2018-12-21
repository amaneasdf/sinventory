Public Class fr_kas_detail
    Private rowindex As Integer = 0
    Private rowindexlist As Integer = 0
    Private popupstate As String
    Private tjlstatus As String = 1
    Private clstate As Boolean = False

    Private Sub loadData(kode As String)
        Dim q As String = "SELECT kas_kode, kas_tgl, kas_jenis, kas_bank,perk_nama_akun,kas_nobg,kas_status, " _
                          & "kas_sales, salesman_nama, kas_reg_date,kas_reg_alias, kas_upd_date, kas_upd_alias " _
                          & "FROM data_kas_faktur LEFT JOIN data_salesman_master ON kas_sales=salesman_kode " _
                          & "LEFT JOIN data_perkiraan ON perk_kode=kas_bank " _
                          & "WHERE kas_kode='{0}'"
        op_con()

        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            in_no_bukti.Text = rd.Item("kas_kode")
            date_tgl_trans.Value = rd.Item("kas_tgl")
            in_bank.Text = rd.Item("kas_bank")
            in_bank_n.Text = rd.Item("perk_nama_akun")
            cb_jenis.SelectedValue = rd.Item("kas_jenis")
            in_bg.Text = rd.Item("kas_nobg")
            in_sales.Text = rd.Item("kas_sales")
            in_sales_n.Text = rd.Item("salesman_nama")
            tjlstatus = rd.Item("kas_status")
            txtRegAlias.Text = rd.Item("kas_reg_alias")
            txtRegdate.Text = rd.Item("kas_reg_date")
            txtUpdAlias.Text = rd.Item("kas_upd_alias")
            Try
                txtUpdDate.Text = rd.Item("kas_upd_date")
            Catch ex As Exception
                consoleWriteLine(ex.Message)
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
        End If
        rd.Close()

        'setBank(in_bank.Text)
        'setSales(in_sales.Text)
        loadKas(kode)
        setStatus()
    End Sub

    'SET STATUS
    Private Sub setStatus()
        Select Case tjlStatus
            Case 0
                in_status.Text = "Non-Aktif"
            Case 1
                in_status.Text = "Aktif"
            Case 9
                in_status.Text = "Delete"
            Case Else
                in_status.Text = "ERROR"
        End Select
    End Sub

    'LOAD TABLE
    Private Sub loadKas(kode As String)
        Dim dt As New DataTable
        Dim q As String = "SELECT k_trans_rek, perk_nama_akun, k_trans_debet, k_trans_kredit, k_trans_ket " _
                            & "FROM data_kas_trans LEFT JOIN data_perkiraan ON k_trans_rek=perk_kode " _
                            & "WHERE k_trans_faktur='{0}'"

        dt = getDataTablefromDB(String.Format(q, kode))

        For Each rows As DataRow In dt.Rows
            dgv_kas.Rows.Add(rows.ItemArray(0), rows.ItemArray(1), rows.ItemArray(2), rows.ItemArray(3), rows.ItemArray(4))
        Next
        dt.Dispose()
        countDK()
    End Sub

    Private Sub loadDataBRGPopup(Optional param As String = "")
        Dim q As String = ""
        With dgv_listbarang
            Select Case popupstate
                Case "bank"
                    q = "SELECT perk_kode as 'Kode', perk_nama_akun as 'Nama' FROM data_perkiraan " _
                        & "WHERE perk_status=1 AND perk_parent IN('1101','1102') AND perk_nama_akun LIKE '{0}%'"
                    .DataSource = getDataTablefromDB(String.Format(q, param))
                    .Columns(1).Width = 150
                Case "sales"
                    q = "SELECT salesman_kode AS 'Kode',salesman_nama AS 'Nama' FROM data_salesman_master " _
                        & "WHERE salesman_status=1 AND salesman_nama LIKE '{0}%' LIMIT 100"
                    .DataSource = getDataTablefromDB(String.Format(q, param))
                    .Columns(1).Width = 175
                Case "rek"
                    q = "SELECT perk_kode as 'Kode', perk_nama_akun as 'Nama' FROM data_perkiraan " _
                        & "WHERE perk_status=1 AND perk_nama_akun LIKE '{0}%' AND perk_kode<>'" & in_bank.Text & "' LIMIT 100"
                    .DataSource = getDataTablefromDB(String.Format(q, param))
                    .Columns(1).Width = 200
            End Select
        End With
    End Sub

    'OPEN SEARCH WINDOW
    Private Sub doSearch()

    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "bank"
                    in_bank.Text = .Cells(0).Value
                    in_bank_n.Text = .Cells(1).Value
                    cb_jenis.Focus()
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    in_rek_n.Focus()
                Case "rek"
                    in_rek.Text = .Cells(0).Value
                    in_rek_n.Text = .Cells(1).Value
                    in_debet.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
    End Sub

    'DGV
    Private Sub textToDgv()
        If Trim(in_rek.Text) = Nothing Then
            in_rek_n.Focus()
            Exit Sub
        End If

        If in_debet.Value = 0 And in_kredit.Value = 0 Then
            in_debet.Focus()
            Exit Sub
        End If
        If in_debet.Value <> 0 And in_kredit.Value <> 0 Then
            in_debet.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.AppStarting

        With dgv_kas.Rows
            Dim x As Integer = .Add
            With .Item(x)
                .Cells("kas_rek").Value = in_rek.Text
                .Cells("kas_rek_n").Value = in_rek_n.Text
                .Cells("kas_kredit").Value = in_kredit.Value
                .Cells("kas_debet").Value = in_debet.Value
                .Cells("kas_ket").Value = in_ket.Text
            End With
        End With
        clear("kas")
        countDK()
    End Sub

    Private Sub dgvToText()
        Dim _idx As Integer = 0
        With dgv_kas.SelectedRows.Item(0)
            in_rek.Text = .Cells("kas_rek").Value
            in_rek_n.Text = .Cells("kas_rek_n").Value
            in_kredit.Value = .Cells("kas_kredit").Value
            in_debet.Value = .Cells("kas_debet").Value
            in_ket.Text = .Cells("kas_ket").Value

            _idx = .Index
        End With

        dgv_kas.Rows.RemoveAt(_idx)
        countDK()
    End Sub

    Private Sub countDK()
        Dim _deb As Integer = 0
        Dim _kre As Integer = 0
        For Each rows As DataGridViewRow In dgv_kas.Rows
            _deb += rows.Cells("kas_debet").Value
            _kre += rows.Cells("kas_kredit").Value
        Next

        in_kredit_tot.Text = commaThousand(_kre)
        in_debet_tot.Text = commaThousand(_deb)
    End Sub

    'CLEAR INPUT
    Private Sub clear(tipe As String)
        Select Case tipe
            Case "kas"
                For Each x As TextBox In {in_rek, in_rek_n, in_ket}
                    x.Clear()
                Next
                For Each x As NumericUpDown In {in_debet, in_kredit}
                    x.Value = 0
                Next
            Case "header"
                For Each x As TextBox In {in_bank, in_bank_n, in_bg, in_sales, in_sales_n, in_no_bukti, txtRegAlias, txtRegdate, txtUpdAlias, txtUpdDate}
                    x.Clear()
                Next
                With date_tgl_trans
                    .Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
                    .MaxDate = selectperiode.tglakhir
                    .MinDate = selectperiode.tglawal
                End With
            Case "dgv"
                dgv_kas.Rows.Clear()
                For Each x As TextBox In {in_debet_tot, in_kredit_tot}
                    x.Clear()
                Next
            Case Else
                Exit Sub
        End Select
    End Sub

    '------------------ SAVE
    Private Sub saveData()
        Dim q As String = ""
        Dim data1 As String()
        Dim queryArr As New List(Of String)
        Dim querycheck As Boolean = False

        op_con()

        Me.Cursor = Cursors.WaitCursor

        '==========================================================================================================================
        'INPUT HEAD
        data1 = {
            "kas_tgl='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
            "kas_bank='" & in_bank.Text & "'",
            "kas_jenis='" & cb_jenis.SelectedValue & "'",
            "kas_nobg='" & in_bg.Text & "'",
            "kas_sales='" & in_sales.Text & "'",
            "kas_status='" & tjlstatus & "'"
            }
        If bt_simpanperkiraan.Text = "Simpan" Then
            'GENERATE KODE
            If in_no_bukti.Text = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT COUNT(kas_kode) FROM data_kas_faktur WHERE SUBSTRING(kas_kode,3,8)='" & date_tgl_trans.Value.ToString("yyyyMMdd") & "' AND kas_kode LIKE 'KS%'")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()
                in_no_bukti.Text = "KS" & date_tgl_trans.Value.ToString("yyyyMMdd") & no.ToString("D3")
            ElseIf in_no_bukti.Text <> Nothing And bt_simpanperkiraan.Text <> "Update" Then
                If checkdata("data_kas_faktur", "'" & in_no_bukti.Text & "'", "kas_kode") = True Then
                    MessageBox.Show("Kode " & in_no_bukti.Text & " sudah Pernah diinput", "Kas", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    Exit Sub
                End If
            End If

            q = "INSERT INTO data_kas_faktur SET kas_kode='{0}',{1},kas_reg_date=NOW(),kas_reg_alias='{2}'"
        Else
            q = "UPDATE data_kas_faktur SET {1},kas_upd_date=NOW(),kas_upd_alias='{2}' WHERE kas_kode='{0}'"
        End If
        queryArr.Add(String.Format(q, in_no_bukti.Text, String.Join(",", data1), loggeduser.user_id))
        '==========================================================================================================================

        '==========================================================================================================================
        'INSERT DATA KAS

        '==========================================================================================================================
        q = "UPDATE data_kas_trans SET k_trans_status=9 WHERE k_trans_faktur='{0}'"
        queryArr.Add(String.Format(q, in_no_bukti.Text))
        '==========================================================================================================================

        '==========================================================================================================================
        q = "INSERT data_kas_trans SET k_trans_faktur='{0}',{1} ON DUPLICATE KEY UPDATE {1}"
        For Each rows As DataGridViewRow In dgv_kas.Rows
            data1 = {
                "k_trans_rek='" & rows.Cells("kas_rek").Value & "'",
                "k_trans_debet=" & rows.Cells("kas_debet").Value.ToString.Replace(",", "."),
                "k_trans_kredit=" & rows.Cells("kas_kredit").Value.ToString.Replace(",", "."),
                "k_trans_ket='" & rows.Cells("kas_ket").Value & "'",
                "k_trans_status='" & tjlstatus & "'"
                }
            queryArr.Add(String.Format(q, in_no_bukti.Text, String.Join(",", data1)))
        Next
        '==========================================================================================================================

        '==========================================================================================================================
        'INPUT JURNAL
        '----------HEAD
        q = "INSERT INTO data_jurnal_line SET line_kode='{0}', line_type='KAS',{1},line_reg_date=NOW(),line_reg_alias='{2}' " _
            & "ON DUPLICATE KEY UPDATE {1},line_upd_date=NOW(),line_upd_alias='{2}'"
        data1 = {
            "line_ref='" & in_bank.Text & "'",
            "line_ref_type='AKUN'",
            "line_tanggal='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
            "line_status='" & tjlstatus & "'"
            }
        queryArr.Add(String.Format(q, in_no_bukti.Text, String.Join(",", data1), loggeduser.user_id))
        '==========================================================================================================================

        '==========================================================================================================================
        'BEGIN TRANSACT
        querycheck = startTrans(queryArr)
        '==========================================================================================================================

        Me.Cursor = Cursors.Default

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmkas.in_cari.Clear()
            populateDGVUserCon("kas", "", frmkas.dgv_list)
            Me.Close()
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
        If MessageBox.Show("Tutup Form?", "Kas", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            clstate = False
            Me.Close()
        Else
            clstate = True
        End If
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = clstate
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

    Private Sub fr_pesan_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            Else
                bt_batalperkiraan.PerformClick()
            End If
        End If
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
    Private Sub in_debet_Enter(sender As Object, e As EventArgs) Handles in_kredit.Enter, in_debet.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_debet_Leave(sender As Object, e As EventArgs) Handles in_kredit.Leave, in_debet.Leave
        numericLostFocus(sender)
    End Sub

    '------------- cb prevent input
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_jenis.KeyPress
        If e.KeyChar <> ControlChars.NewLine Then
            e.Handled = True
        End If
    End Sub

    '-------------- POPUP SEARCH
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_bank_n.Focused = True Or in_sales_n.Focused = True Or in_rek_n.Focused = True Then
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

    Private Sub dgv_listbarang_Cellenter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellEnter
        If e.RowIndex >= 0 Then
            rowindexlist = e.RowIndex
        End If
    End Sub

    Private Sub dgv_listbarang_KeyDown_1(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            'consoleWriteLine("fuck")
            e.SuppressKeyPress = True
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
                Case "bank"
                    x = in_bank_n
                Case "sales"
                    x = in_sales_n
                Case "rek"
                    x = in_rek_n
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


    '------------- load
    Private Sub fr_kas_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_jenis
            .DataSource = jenisBayar("kas")
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With
        For Each x As DataGridViewColumn In {kas_debet, kas_kredit}
            x.DefaultCellStyle = dgvstyle_currency
        Next
        With date_tgl_trans
            .Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
            .MaxDate = selectperiode.tglakhir
            .MinDate = selectperiode.tglawal
        End With

        in_bank.Focus()

        If in_no_bukti.Text <> Nothing Then
            loadData(in_no_bukti.Text)
        End If
    End Sub

    '------------- save
    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click
        If Trim(in_bank.Text) = Nothing Then
            MessageBox.Show("Bank belum di input")
            in_bank_n.Focus()
            Exit Sub
        End If
        If cb_jenis.SelectedValue = Nothing Then
            MessageBox.Show("Jenis belum di input")
            cb_jenis.Focus()
            Exit Sub
        End If
        If Trim(in_sales.Text) = Nothing Then
            MessageBox.Show("Salesman belum di input")
            in_sales_n.Focus()
            Exit Sub
        End If
        If dgv_kas.Rows.Count = 0 Then
            MessageBox.Show("Data kas belum di input")
            in_rek_n.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan data kas?", "Kas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    '------------ input
    '------------- BANK
    Private Sub in_bank_KeyUP(sender As Object, e As KeyEventArgs) Handles in_bank.KeyUp
        keyshortenter(in_bank_n, e)
    End Sub

    Private Sub in_bank_n_Enter(sender As Object, e As EventArgs) Handles in_bank_n.Enter
        popPnl_barang.Location = New Point(in_bank_n.Left, in_bank_n.Top + in_bank_n.Height)
        popupstate = "bank"
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        loadDataBRGPopup(in_bank_n.Text)
    End Sub

    Private Sub in_bank_KeyDown(sender As Object, e As KeyEventArgs) Handles in_bank_n.KeyUp, in_sales_n.KeyUp, in_rek_n.KeyUp
        Dim _nxtcntrol As Control = Nothing
        Dim _kdcntrol As Control = Nothing
        Select Case sender.Name.ToString
            Case "in_bank_n"
                _nxtcntrol = cb_jenis
                _kdcntrol = in_bank
            Case "in_sales_n"
                _nxtcntrol = in_rek_n
                _kdcntrol = in_sales
            Case "in_rek_n"
                _nxtcntrol = in_kredit
                _kdcntrol = in_rek
            Case Else
                Exit Sub
        End Select

        If sender.Text = "" And IsNothing(_kdcntrol) = False Then
            _kdcntrol.Text = ""
        End If

        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(_nxtcntrol, e)
        Else
            If e.KeyCode <> Keys.Escape Then
                If popPnl_barang.Visible = False And sender.Enabled = True And sender.ReadOnly = False Then
                    popPnl_barang.Visible = True
                End If
                loadDataBRGPopup(sender.Text)
            End If
        End If
    End Sub

    Private Sub in_bank_n_TextChanged(sender As Object, e As EventArgs) Handles in_bank_n.TextChanged
        If in_bank_n.Text = "" Then
            in_bank.Clear()
        End If
    End Sub

    Private Sub in_bank_Leave(sender As Object, e As EventArgs) Handles in_bank_n.Leave, in_sales_n.Leave, in_rek_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    '-------- CB JENIS
    Private Sub cb_jenis_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_jenis.KeyDown
        keyshortenter(in_bg, e)
    End Sub

    Private Sub in_bg_KeyDown(sender As Object, e As KeyEventArgs) Handles in_bg.KeyDown
        keyshortenter(in_sales_n, e)
    End Sub

    '----------- SALES
    Private Sub in_sales_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales.KeyUp
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_sales_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter
        popPnl_barang.Location = New Point(in_sales_n.Left, in_sales_n.Top + in_sales_n.Height)
        popupstate = "sales"
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        loadDataBRGPopup(in_sales_n.Text)
    End Sub

    Private Sub in_sales_n_TextChanged(sender As Object, e As EventArgs) Handles in_sales_n.TextChanged
        If in_sales_n.Text = "" Then
            in_sales.Clear()
        End If
    End Sub

    '------------- input kas
    Private Sub in_rek_KeyUp(sender As Object, e As KeyEventArgs) Handles in_rek.KeyUp
        keyshortenter(in_rek_n, e)
    End Sub

    Private Sub in_rek_n_Enter(sender As Object, e As EventArgs) Handles in_rek_n.Enter
        popPnl_barang.Location = New Point(in_rek_n.Left, in_rek_n.Top + in_rek_n.Height)
        popupstate = "rek"
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        loadDataBRGPopup()
    End Sub

    Private Sub in_rek_n_TextChanged(sender As Object, e As EventArgs) Handles in_rek_n.TextChanged
        If in_rek_n.Text = "" Then
            in_rek.Clear()
        End If
    End Sub

    Private Sub in_debet_KeyDown(sender As Object, e As KeyEventArgs) Handles in_debet.KeyDown
        keyshortenter(in_kredit, e)
    End Sub

    Private Sub in_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kredit.KeyDown
        keyshortenter(in_ket, e)
    End Sub

    Private Sub in_ket_KeyDown(sender As Object, e As KeyEventArgs) Handles in_ket.KeyDown
        keyshortenter(bt_tbkas, e)
    End Sub

    Private Sub bt_tbkas_Click(sender As Object, e As EventArgs) Handles bt_tbkas.Click
        textToDgv()
    End Sub

    Private Sub dgv_kas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_kas.CellDoubleClick
        If e.RowIndex >= 0 Then
            rowindex = e.RowIndex
            If bt_simpanperkiraan.Enabled = True Then
                dgvToText()
            End If
        End If
    End Sub

    Private Sub fr_kas_detail_Click(sender As Object, e As EventArgs) Handles MyBase.Click, Panel1.Click, Panel2.Click, lbl_title.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub
End Class