Public Class fr_kas_detail
    Private rowindex As Integer = 0
    Private rowindexlist As Integer = 0
    Private popupstate As String
    Private tjlstatus As String = 1
    Private clstate As Boolean = False

    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
        View
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(NoFaktur As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Kas Masuk/Keluar : ks20190810902"

        formstate = FormSet

        With cb_jenis
            .DataSource = jenisBayar("kas")
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With
        With date_tgl_trans
            .Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
            .MaxDate = selectperiode.tglakhir
            .MinDate = selectperiode.tglawal
        End With
        For Each x As DataGridViewColumn In {kas_debet, kas_kredit}
            x.DefaultCellStyle = dgvstyle_currency
        Next

        If Not FormSet = InputState.Insert Then
            Me.Text += NoFaktur
            Me.lbl_title.Text += " : " & NoFaktur
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            loadData(NoFaktur)
            If Not {0, 1}.Contains(tjlstatus) Then AllowEdit = False
            in_no_bukti.ReadOnly = True
            mn_print.Enabled = IIf(tjlstatus = 1, True, False)
            mn_cancel.Enabled = IIf({0, 1}.Contains(tjlstatus), True, False)
            bt_simpanperkiraan.Text = "Update"
        End If

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        For Each txt As TextBox In {in_sales_n, in_bank_n, in_bg}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        For Each cbx As ComboBox In {cb_jenis}
            cbx.Enabled = AllowInput
        Next
        For Each ctr As Control In {in_rek_n, in_kredit, in_debet, in_ket, bt_tbkas}
            ctr.Visible = AllowInput
        Next
        For Each dtpick As DateTimePicker In {date_tgl_trans}
            dtpick.Enabled = AllowInput
        Next

        bt_simpanperkiraan.Enabled = AllowInput
        mn_save.Enabled = AllowInput

        If AllowInput Then
            dgv_kas.Location = New Point(10, 221) : dgv_kas.Height = 146
            AddHandler dgv_kas.CellDoubleClick, AddressOf dgv_kas_CellDoubleClick
        Else
            dgv_kas.Location = New Point(8, 181) : dgv_kas.Height = 186
            RemoveHandler dgv_kas.CellDoubleClick, AddressOf dgv_kas_CellDoubleClick
        End If
    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        SetUpForm(Nothing, InputState.Insert, AllowInput)
        Me.Show()
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, AllowEdit As Boolean)
        SetUpForm(NoFaktur, InputState.Edit, AllowEdit)
        Me.Show()
    End Sub

    Public Sub doLoadView(NoFaktur As String)
        SetUpForm(NoFaktur, InputState.View, Nothing)
        Me.Show()
    End Sub

    'LOAD DATA
    Private Sub loadData(kode As String)
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT kas_kode, kas_tgl, kas_jenis, kas_bank,perk_nama_akun, IFNULL(kas_nobg,'') kas_nobg, kas_status, " _
                    & "kas_sales, IFNULL(salesman_nama,'') salesman_nama, " _
                    & "DATE_FORMAT(kas_reg_date, '%d/%m/%Y %H:%i:%S') kas_reg_date, IFNULL(kas_reg_alias,'') kas_reg_alias, " _
                    & "IFNULL(DATE_FORMAT(kas_upd_date, '%d/%m/%Y %H:%i:%S'),'') kas_upd_date, IFNULL(kas_upd_alias,'') kas_upd_alias " _
                    & "FROM data_kas_faktur LEFT JOIN data_salesman_master ON kas_sales=salesman_kode " _
                    & "LEFT JOIN data_perkiraan ON perk_kode=kas_bank " _
                    & "WHERE kas_kode='{0}'"

                Using rdx = x.ReadCommand(String.Format(q, kode))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_no_bukti.Text = rdx.Item("kas_kode")
                        date_tgl_trans.Value = rdx.Item("kas_tgl")
                        in_bank.Text = rdx.Item("kas_bank")
                        in_bank_n.Text = rdx.Item("perk_nama_akun")
                        cb_jenis.SelectedValue = rdx.Item("kas_jenis")
                        in_bg.Text = rdx.Item("kas_nobg")
                        in_sales.Text = rdx.Item("kas_sales")
                        in_sales_n.Text = rdx.Item("salesman_nama")
                        tjlstatus = rdx.Item("kas_status")
                        txtRegAlias.Text = rdx.Item("kas_reg_alias")
                        txtRegdate.Text = rdx.Item("kas_reg_date")
                        txtUpdAlias.Text = rdx.Item("kas_upd_alias")
                        txtUpdDate.Text = rdx.Item("kas_upd_date")
                    End If
                End Using
                q = "SELECT k_trans_rek, perk_nama_akun, k_trans_debet, k_trans_kredit, k_trans_ket " _
                    & "FROM data_kas_trans LEFT JOIN data_perkiraan ON k_trans_rek=perk_kode " _
                    & "WHERE k_trans_faktur='{0}' AND k_trans_status=1"
                Using dt = x.GetDataTable(String.Format(q, kode))
                    For Each rows As DataRow In dt.Rows
                        dgv_kas.Rows.Add(rows.ItemArray(0), rows.ItemArray(1), rows.ItemArray(2), rows.ItemArray(3), rows.ItemArray(4))
                    Next
                End Using
                countDK()
                Select Case tjlstatus
                    Case 0 : in_status.Text = "Pending"
                    Case 1 : in_status.Text = "Aktif"
                    Case 2 : in_status.Text = "Batal"
                    Case 8 : in_status.Text = "On-Edit/NOT IMPLEMENTED!"
                    Case 9 : in_status.Text = "Delete"
                    Case Else : Exit Sub
                End Select
            Else
                MessageBox.Show("Tidak dapat terhubung ke server", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End Using
    End Sub

    'LOAD SEARCH POPPUP
    Private Sub loadDataBRGPopup(Optional param As String = "")
        Dim q As String = ""
        With dgv_listbarang
            Select Case popupstate
                Case "bank"
                    q = "SELECT perk_kode as 'Kode', perk_nama_akun as 'Nama' FROM data_perkiraan " _
                        & "WHERE perk_status=1 AND perk_parent IN('1101','1102') AND (perk_nama_akun LIKE '%{0}%' OR perk_kode LIKE '%{0}%')"
                    .DataSource = getDataTablefromDB(String.Format(q, param))
                    .Columns(1).Width = 150
                Case "sales"
                    q = "SELECT salesman_kode AS 'Kode',salesman_nama AS 'Nama' FROM data_salesman_master " _
                        & "WHERE salesman_status=1 AND (salesman_nama LIKE '%{0}%' OR salesman_kode LIKE '%{0}%') LIMIT 100"
                    .DataSource = getDataTablefromDB(String.Format(q, param))
                    .Columns(1).Width = 175
                Case "rek"
                    q = "SELECT perk_kode as 'Kode', perk_nama_akun as 'Nama' FROM data_perkiraan " _
                        & "WHERE perk_status=1 AND (perk_nama_akun LIKE '%{0}%' OR perk_kode LIKE '%{0}%') AND perk_kode<>'" & in_bank.Text & "' LIMIT 100"
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
    Private Function saveData() As Boolean
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
                    MessageBox.Show("Kode " & in_no_bukti.Text & " sudah pernah diinput. Silahkan ganti kode transaksi", "Kas",
                                    MessageBoxButtons.OK, MessageBoxIcon.Question)
                    Return False
                    Exit Function
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
                "k_trans_debet=" & Decimal.Parse(rows.Cells("kas_debet").Value).ToString.Replace(",", "."),
                "k_trans_kredit=" & Decimal.Parse(rows.Cells("kas_kredit").Value).ToString.Replace(",", "."),
                "k_trans_ket='" & rows.Cells("kas_ket").Value & "'",
                "k_trans_status='" & IIf(tjlstatus = 9, 9, 1) & "'"
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
            "line_status='" & IIf(tjlstatus = 1, 1, 9) & "'"
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
            Return False
            Exit Function
        Else
            MessageBox.Show("Data tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            DoRefreshTab_v2({pgkas})
            Return True
            Me.Close()
        End If
    End Function

    '------------------ CANCEL
    Private Function cancelData() As Boolean
        Dim _retval As Boolean = False
        Dim q As String = ""
        Dim queryArr As New List(Of String)

        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If

        Using x As New fr_tutupconfirm_dialog
            x.lbl_title.Text = "Konfirmasi Kas"
            x.doLoadValid()
            _retval = x.returnval.Key
        End Using

        If _retval Then
            q = "UPDATE data_kas_faktur SET kas_status=2, kas_upd_date=NOW(), kas_upd_alias='{1}' WHERE kas_kode='{0}'"
            queryArr.Add(String.Format(q, in_no_bukti.Text, loggeduser.user_id))

            q = "UPDATE data_jurnal_line SET line_status=9, line_upd_date=NOW(), line_upd_alias='{1}' WHERE line_kode='{0}' AND line_type='KAS'"
            queryArr.Add(String.Format(q, in_no_bukti.Text, loggeduser.user_id))

            Using x = MainConnection
                x.Open()
                If x.ConnectionState = ConnectionState.Open Then
                    _retval = x.TransactCommand(queryArr)

                    If Not _retval Then
                        MessageBox.Show("Pembatalan transaksi gagal.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    _retval = False
                    MessageBox.Show("Pembatalan transaksi gagal. Tidak dapat terhubung ke server.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End If
        Return _retval
    End Function

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

    'UI : CLOSE
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalperkiraan.Click
        Me.Close()
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

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

    Private Sub mn_proses_Click(sender As Object, e As EventArgs) Handles mn_proses.Click

    End Sub

    Private Sub mn_cancel_Click(sender As Object, e As EventArgs) Handles mn_cancel.Click
        If MessageBox.Show("Batalkan transaksi kas?", "Batalkan Kas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim res = cancelData()

            If res Then
                MessageBox.Show("Transaksi kas dibatalkan", "Batal Kas", MessageBoxButtons.OK)
                doRefreshTab({pgkas})
                Me.Close()
            End If
        End If
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
        dgv_kas.ClearSelection()
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
        If dgv_kas.Rows.Count = 0 Then
            MessageBox.Show("Data kas belum di input")
            in_rek_n.Focus()
            Exit Sub
        End If

        Dim _askRes As DialogResult = Windows.Forms.DialogResult.Yes
        If formstate <> InputState.Insert Then _askRes = MessageBox.Show("Simpan data kas?", "Kas", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _askRes = Windows.Forms.DialogResult.Yes Then saveData()
    End Sub

    '------------ input
    Private Sub date_tgl_trans_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_trans.KeyDown
        keyshortenter(in_bank_n, e)
    End Sub

    '------------- BANK
    Private Sub in_bank_KeyUP(sender As Object, e As KeyEventArgs) Handles in_bank.KeyUp
        keyshortenter(in_bank_n, e)
    End Sub

    Private Sub in_bank_n_Enter(sender As Object, e As EventArgs) Handles in_bank_n.Enter
        If sender.ReadOnly = False And sender.Enabled = True Then
            popPnl_barang.Location = New Point(in_bank_n.Left, in_bank_n.Top + in_bank_n.Height)
            If popPnl_barang.Visible = False Then popPnl_barang.Visible = True
            popupstate = "bank"
            loadDataBRGPopup(sender.Text)
        End If
    End Sub

    Private Sub in_bank_KeyDown(sender As Object, e As KeyEventArgs) Handles in_bank_n.KeyDown, in_sales_n.KeyDown, in_rek_n.KeyDown
        Dim _nxtctrl As Control = Nothing
        Dim _kdcntrl As Control = Nothing

        Select Case sender.Name.ToString
            Case "in_bank_n"
                _nxtctrl = cb_jenis : _kdcntrl = in_bank
            Case "in_sales_n"
                _nxtctrl = in_rek_n : _kdcntrl = in_sales
            Case "in_rek_n"
                _nxtctrl = in_debet : _kdcntrl = in_rek
            Case Else
                Exit Sub
        End Select

        If sender.Text = "" And IsNothing(_kdcntrl) = False Then
            _kdcntrl.Text = ""
        End If

        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then dgv_listbarang.Focus()

        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then setPopUpResult()
            keyshortenter(_nxtctrl, e)
        Else
            If e.KeyCode <> Keys.Escape And sender.Readonly = False Then
                Dim x() As Keys = {Keys.Tab, Keys.CapsLock, Keys.End, Keys.Home, Keys.PageUp, Keys.PageDown}
                If Not x.Contains(e.KeyCode) And Not e.Shift And Not e.Control And Not e.Alt Then
                    If Not IsNothing(_kdcntrl) Then _kdcntrl.Text = ""
                End If
                If popPnl_barang.Visible = False Then popPnl_barang.Visible = True
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
        If sender.ReadOnly = False And sender.Enabled = True Then
            popPnl_barang.Location = New Point(in_sales_n.Left, in_sales_n.Top + in_sales_n.Height)
            popupstate = "sales"
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup(in_sales_n.Text)
        End If
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
        If sender.ReadOnly = False And sender.Enabled = True Then
            popPnl_barang.Location = New Point(in_rek_n.Left, in_rek_n.Top + in_rek_n.Height)
            popupstate = "rek"
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup()
        End If
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

    Private Sub dgv_kas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
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