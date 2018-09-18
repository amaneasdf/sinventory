Public Class fr_kas_detail
    Private rowindex As Integer = 0
    Private rowindexlist As Integer = 0
    Private popupstate As String

    Private Sub loadData(kode As String)
        op_con()

        readcommd("SELECT * FROM data_kas_faktur WHERE kas_kode='" & kode & "'")
        If rd.HasRows Then
            in_no_bukti.Text = rd.Item("kas_kode")
            date_tgl_trans.Value = rd.Item("kas_tgl")
            in_bank.Text = rd.Item("kas_bank")
            cb_jenis.SelectedValue = rd.Item("kas_jenis")
            in_bg.Text = rd.Item("kas_nobg")
            in_sales.Text = rd.Item("kas_sales")
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

        setBank(in_bank.Text)
        setSales(in_sales.Text)
        loadKas(kode)
    End Sub

    Private Sub loadKas(kode As String)
        Dim dt As New DataTable

        dt = getDataTablefromDB("SELECT k_trans_rek, perk_nama_akun, k_trans_debet, k_trans_kredit, k_trans_ket " _
                                & "FROM data_kas_trans LEFT JOIN setup_perkiraan ON k_trans_rek=CONCAT(perk_kode_jenis,perk_golongan,perk_sub_gol,perk_kd_akun) " _
                                & "WHERE k_trans_faktur='" & kode & "'")

        For Each rows As DataRow In dt.Rows
            dgv_kas.Rows.Add(rows.ItemArray(0), rows.ItemArray(1), rows.ItemArray(2), rows.ItemArray(3), rows.ItemArray(4))
        Next
        dt.Dispose()
    End Sub

    Private Sub setBank(kode As String, Optional param As String = Nothing)
        op_con()

        If kode = Nothing And param <> Nothing Then
            readcommd("SELECT CONCAT(perk_kode_jenis,perk_golongan, perk_sub_gol,perk_kd_akun) FROM setup_perkitaan WHERE perk_nama_akun LIKE '" & param & "%' LIMIT 1")
            If rd.HasRows Then
                kode = rd.Item(0)
            End If
            rd.Close()
        End If

        If kode <> Nothing Then
            readcommd("SELECT CONCAT(perk_kode_jenis,perk_golongan, perk_sub_gol,perk_kd_akun), perk_nama_akun FROM setup_perkiraan WHERE CONCAT(perk_kode_jenis,perk_golongan, perk_sub_gol,perk_kd_akun)='" & kode & "'")
            If rd.HasRows Then
                in_bank.Text = rd.Item(0)
                in_bank_n.Text = rd.Item(1)
            End If
            rd.Close()
        End If
    End Sub

    Private Sub setSales(kode As String, Optional param As String = Nothing)
        op_con()

        If kode = Nothing And param <> Nothing Then
            readcommd("SELECT salesman_kode FROM data_salesman_master WHERE salesman_nama LIKE '" & param & "%' LIMIT 1")
            If rd.HasRows Then
                kode = rd.Item("salesman_kode")
            End If
            rd.Close()
        End If

        If kode <> Nothing Then
            readcommd("SELECT salesman_kode, salesman_nama FROM data_salesman_master WHERE salesman_kode='" & kode & "'")
            If rd.HasRows Then
                in_sales.Text = rd.Item("salesman_kode")
                in_sales_n.Text = rd.Item("salesman_nama")
            End If
            rd.Close()
        End If
    End Sub

    Private Sub setRek(kode As String, Optional param As String = Nothing)
        op_con()

        If kode = Nothing And param <> Nothing Then
            readcommd("SELECT CONCAT(perk_kode_jenis,perk_golongan, perk_sub_gol,perk_kd_akun) FROM setup_perkiraan WHERE perk_nama_akun LIKE '" & param & "%' LIMIT 1")
            If rd.HasRows Then
                kode = rd.Item(0)
            End If
            rd.Close()
        End If

        If kode <> Nothing Then
            readcommd("SELECT CONCAT(perk_kode_jenis,perk_golongan, perk_sub_gol,perk_kd_akun), perk_nama_akun FROM setup_perkiraan WHERE CONCAT(perk_kode_jenis,perk_golongan, perk_sub_gol,perk_kd_akun)='" & kode & "'")
            If rd.HasRows Then
                in_rek.Text = rd.Item(0)
                in_rek_n.Text = rd.Item(1)
            End If
            rd.Close()
        End If
    End Sub

    Private Sub loadDataBRGPopup()
        With dgv_listbarang
            Select Case popupstate
                Case "bank"
                    .DataSource = getDataTablefromDB("SELECT CONCAT(perk_kode_jenis,perk_golongan, perk_sub_gol,perk_kd_akun) AS 'Kode', " _
                                                & "perk_nama_akun AS 'Nama' FROM setup_perkiraan " _
                                                & "WHERE perk_nama_akun LIKE '" & in_bank_n.Text & "%' AND " _
                                                & "CONCAT(perk_kode_jenis,perk_golongan,perk_sub_gol) IN ('1101','1102') LIMIT 100")
                    .Columns(1).Width = 150
                Case "sales"
                    .DataSource = getDataTablefromDB("SELECT salesman_kode AS 'Kode', salesman_nama AS 'Nama' FROM data_salesman_master WHERE salesman_nama LIKE '" & in_sales_n.Text & "%' LIMIT 100")
                    .Columns(1).Width = 175
                Case "rek"
                    .DataSource = getDataTablefromDB("SELECT CONCAT(perk_kode_jenis,perk_golongan, perk_sub_gol,perk_kd_akun) AS 'Kode', " _
                                                     & "perk_nama_akun AS 'Rekening' FROM setup_perkiraan " _
                                                     & "WHERE perk_nama_akun LIKE '" & in_rek_n.Text & "%' LIMIT 100")
                    .Columns(1).Width = 200
            End Select
        End With
    End Sub

    Private Sub search(tipe As String)
        Using search As New fr_search_dialog
            With search
                Select Case tipe
                    Case "bank"
                        If Trim(in_bank_n.Text) <> Nothing Then
                            .in_cari.Text = Trim(in_bank_n.Text)
                        End If
                        .returnkode = Trim(in_bank.Text)
                        .query = "SELECT bank_kode AS 'Kode', bank_nama AS 'Nama' FROM data_bank_master"
                        .paramquery = "Kode LIKE '{0}%' OR Nama LIKE '{0}%'"
                        .type = "bank"
                        .ShowDialog()
                        in_bank.Text = .returnkode
                        setBank(in_bank.Text)
                    Case "sales"
                        If Trim(in_sales_n.Text) <> Nothing Then
                            .in_cari.Text = Trim(in_sales_n.Text)
                        End If
                        .returnkode = Trim(in_sales.Text)
                        .query = "SELECT salesman_kode AS kode, salesman_nama AS nama FROM data_bank_master"
                        .paramquery = "kode LIKE '{0}%' OR nama LIKE '{0}%'"
                        .type = "sales"
                        .ShowDialog()
                        in_sales.Text = .returnkode
                        setSales(in_sales.Text)
                    Case "rek"
                        If Trim(in_rek_n.Text) <> Nothing Then
                            .in_cari.Text = Trim(in_rek_n.Text)
                        End If
                        .returnkode = Trim(in_rek.Text)
                        .query = "SELECT CONCAT(perk_kode_jenis,perk_golongan,perk_sub_gol,perk_kd_akun) AS 'Kode', perk_nama_akun AS 'Nama' FROM setup_perkiraan"
                        .paramquery = "Kode LIKE '{0}%' OR Nama LIKE '{0}%'"
                        .type = "perkiraan"
                        .ShowDialog()
                        in_bank.Text = .returnkode
                        setBank(in_bank.Text)
                End Select
            End With
        End Using
    End Sub

    Private Sub textToDgv()
        If Trim(in_rek.Text) = Nothing Then
            in_rek_n.Focus()
            Exit Sub
        End If

        If in_debet.Value = 0 And in_kredit.Value = 0 Then
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
                    .Value = DateSerial(selectedperiode.Year, selectedperiode.Month, Today.Day)
                    .MinDate = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
                    .MaxDate = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)
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
        op_con()

        Me.Cursor = Cursors.WaitCursor

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
                If MessageBox.Show(in_no_bukti.Text & " Sudah Pernah diinput, Update data kas " & in_no_bukti.Text & "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If
        End If

        Dim data1, data2, data3 As String()
        Dim queryArr As New List(Of String)
        Dim querycheck As Boolean = False
        Dim q1 As String = "INSERT INTO data_kas_faktur SET kas_kode='{0}',{1},{2} ON DUPLICATE KEY UPDATE {1},{3}"
        Dim q2 As String = "INSERT INTO data_kas_trans SET k_trans_faktur='{0}',{1} ON DUPLICATE KEY UPDATE {1}"

        'INSERT DATA HEADER
        data1 = {
            "kas_tgl='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
            "kas_bank='" & in_bank.Text & "'",
            "kas_jenis='" & cb_jenis.SelectedValue & "'",
            "kas_nobg='" & in_bg.Text & "'",
            "kas_sales='" & in_sales.Text & "'"
            }
        data2 = {
            "kas_reg_date=NOW()",
            "kas_reg_alias='" & loggeduser.user_id & "'"
        }
        data3 = {
            "kas_upd_date=NOW()",
            "kas_upd_alias='" & loggeduser.user_id & "'"
        }
        queryArr.Add(String.Format(q1, in_no_bukti.Text, String.Join(",", data1), String.Join(",", data2), String.Join(",", data3)))

        'INSERT DATA KAS
        Dim y As New List(Of String)
        Dim qdel As String = "DELETE FROM data_kas_trans WHERE k_trans_rek NOT IN({0})"
        For Each rows As DataGridViewRow In dgv_kas.Rows
            data1 = {
                "k_trans_rek='" & rows.Cells("kas_rek").Value & "'",
                "k_trans_debet=" & rows.Cells("kas_debet").Value,
                "k_trans_kredit=" & rows.Cells("kas_kredit").Value,
                "k_trans_ket='" & rows.Cells("kas_ket").Value & "'"
                }
            queryArr.Add(String.Format(q2, in_no_bukti.Text, String.Join(",", data1)))
            y.Add("'" & rows.Cells("kas_rek").Value & "'")
        Next
        'DEL REMOVED ITEM

        'TODO : ? : CREATE LEDGER

        '--------------------------------------------------------------------------------------------------------------
        'BEGIN TRANSACT
        querycheck = startTrans(queryArr)

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
    Private Sub in_debet_Enter(sender As Object, e As EventArgs) Handles in_kredit.Enter, in_debet.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_debet_Leave(sender As Object, e As EventArgs) Handles in_kredit.Leave, in_debet.Leave
        numericLostFocus(sender)
    End Sub

    '------------- cb prevent input
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_jenis.KeyPress
        e.Handled = True
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
            rowindexlist = e.RowIndex
            Dim _kode As String = dgv_listbarang.Rows(rowindexlist).Cells(0).Value
            Select Case popupstate
                Case "bank"
                    in_bank.Text = _kode
                    setBank(_kode)
                    cb_jenis.Focus()
                Case "sales"
                    in_sales.Text = _kode
                    setSales(_kode)
                    in_rek_n.Focus()
                Case "rek"
                    in_rek.Text = _kode
                    setRek(_kode)
                    in_debet.Focus()
                Case Else
                    Exit Sub
            End Select
        End If
    End Sub

    Private Sub dgv_listbarang_Cellenter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellEnter
        If e.RowIndex >= 0 Then
            rowindexlist = e.RowIndex
        End If
    End Sub

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If dgv_listbarang.Rows.Count > 0 Then
            If e.KeyCode = Keys.Enter Then
                Dim _kode As String = dgv_listbarang.Rows(rowindexlist).Cells(0).Value
                Select Case popupstate
                    Case "bank"
                        in_bank.Text = _kode
                        setBank(_kode)
                        cb_jenis.Focus()
                    Case "sales"
                        in_sales.Text = _kode
                        setSales(_kode)
                        in_rek_n.Focus()
                    Case "rek"
                        in_rek.Text = _kode
                        setRek(_kode)
                        in_debet.Focus()
                    Case Else
                        Exit Sub
                End Select
            End If
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
            .Value = DateSerial(selectedperiode.Year, selectedperiode.Month, Today.Day)
            .MinDate = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
            .MaxDate = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)
        End With

        in_bank.Focus()

        If in_no_bukti.Text <> Nothing Then
            loadData(in_no_bukti.Text)
        End If
    End Sub

    '------------- save
    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click
        'If Trim(in_bank.Text) = Nothing Then
        '    MessageBox.Show("Bank belum di input")
        '    in_bank_n.Focus()
        '    Exit Sub
        'End If
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

        If MessageBox.Show("Simpan data kas?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    '------------ input
    '------------- BANK
    Private Sub in_bank_Enter(sender As Object, e As EventArgs) Handles in_bank_n.Enter
        popPnl_barang.Location = New Point(in_bank_n.Left, in_bank_n.Top + in_bank_n.Height)
        popupstate = "bank"
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        loadDataBRGPopup()
    End Sub

    Private Sub in_bank_KeyDown(sender As Object, e As KeyEventArgs) Handles in_bank_n.KeyDown
        If e.KeyCode = Keys.F1 Then
            search("bank")
        ElseIf e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            'If popPnl_barang.Visible = True Then
            '    dgv_listbarang.Focus()
            'Else
            setBank(Nothing, Trim(in_bank_n.Text))
            keyshortenter(cb_jenis, e)
            'End If
        End If
    End Sub

    Private Sub in_bank_KeyUp(sender As Object, e As KeyEventArgs) Handles in_bank_n.KeyUp
        If popPnl_barang.Visible = True Then
            loadDataBRGPopup()
        End If
    End Sub

    Private Sub in_bank_n_TextChanged(sender As Object, e As EventArgs) Handles in_bank_n.TextChanged
        If in_bank_n.Text = "" Then
            in_bank.Clear()
        End If
    End Sub

    Private Sub in_bank_Leave(sender As Object, e As EventArgs) Handles in_bank_n.Leave
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
    Private Sub in_sales_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter
        popPnl_barang.Location = New Point(in_sales_n.Left, in_sales_n.Top + in_sales_n.Height)
        popupstate = "sales"
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        loadDataBRGPopup()
    End Sub

    Private Sub in_sales_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp
        If popPnl_barang.Visible = True Then
            loadDataBRGPopup()
        End If
    End Sub

    Private Sub in_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyDown
        If e.KeyCode = Keys.F1 Then
            search("sales")
        ElseIf e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            setSales(Nothing, Trim(in_sales_n.Text))
            keyshortenter(in_rek_n, e)
        End If
    End Sub

    Private Sub in_sales_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
            If Trim(in_sales_n.Text) <> Nothing Then
                setSales(Nothing, in_sales_n.Text)
            End If
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    '------------- input kas
    Private Sub in_rek_n_Enter(sender As Object, e As EventArgs) Handles in_rek_n.Enter
        popPnl_barang.Location = New Point(in_rek_n.Left, in_rek_n.Top + in_rek_n.Height)
        popupstate = "rek"
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        loadDataBRGPopup()
    End Sub

    Private Sub in_rek_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_rek_n.KeyUp
        If popPnl_barang.Visible = True Then
            loadDataBRGPopup()
        End If
    End Sub

    Private Sub in_rek_KeyDown(sender As Object, e As KeyEventArgs) Handles in_rek_n.KeyDown
        If e.KeyCode = Keys.F1 Then
            search("rek")
        ElseIf e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            setRek(Nothing, in_rek_n.Text)
            keyshortenter(in_debet, e)
        End If
    End Sub

    Private Sub in_rek_Leave(sender As Object, e As EventArgs) Handles in_rek_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
            If Trim(in_rek_n.Text) <> Nothing Then
                setRek(Nothing, in_rek_n.Text)
            End If
        Else
            popPnl_barang.Visible = True
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
            If bt_simpanperkiraan.Text = "Simpan" Then
                dgvToText()
            End If
        End If
    End Sub
End Class