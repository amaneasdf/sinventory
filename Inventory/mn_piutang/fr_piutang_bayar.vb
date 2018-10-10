Public Class fr_piutang_bayar
    Private _popUpPos As String = ""

    Private Sub loadData(kode As String)
        readcommd("SELECT p_bayar_sales, salesman_nama, p_bayar_tanggal_bayar, p_bayar_reg_date, p_bayar_reg_alias, p_bayar_upd_date, p_bayar_upd_alias FROM data_piutang_bayar LEFT JOIN data_salesman_master ON salesman_kode=p_bayar_sales WHERE p_bayar_bukti='" & kode & "'")
        If rd.HasRows Then
            in_no_bukti.Text = kode
            in_sales.Text = rd.Item("p_bayar_sales")
            in_sales_n.Text = rd.Item("salesman_nama")
            date_tgl_trans.Value = rd.Item("p_bayar_tanggal_bayar")
            txtRegAlias.Text = rd.Item("p_bayar_reg_alias")
            txtRegdate.Text = rd.Item("p_bayar_reg_date")
            txtUpdAlias.Text = rd.Item("p_bayar_upd_alias")
            Try
                txtUpdDate.Text = rd.Item("p_bayar_upd_date")
            Catch ex As Exception
                txtUpdDate.Text = "0000/00/00 00:00:00"
            End Try
        End If
        rd.Close()

        loadListedBayar(kode)
    End Sub

    Private Sub loadListedBayar(kode As String)
        Dim dt As New DataTable
        Dim q As String = "SELECT piutang_custo, piutang_custo_n, p_trans_kode_piutang, p_trans_jen_bayar, p_trans_nilaibayar, " _
                          & "p_trans_bank, p_trans_nobg, p_trans_tglbg " _
                          & "FROM data_piutang_bayar_trans LEFT JOIN selectpiutangawal ON p_trans_kode_piutang=piutang_faktur " _
                          & "WHERE p_trans_status <> 9 AND p_trans_bukti='{0}'"
        dt = getDataTablefromDB(String.Format(q, kode))
        With dgv_bayar.Rows
            For Each rows As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("bayar_custo").Value = rows.ItemArray(0)
                    .Cells("bayar_custo_n").Value = rows.ItemArray(1)
                    .Cells("bayar_faktur").Value = rows.ItemArray(2)
                    .Cells("bayar_kodebayar").Value = rows.ItemArray(3)
                    .Cells("bayar_kredit").Value = rows.ItemArray(4)
                    .Cells("bayar_bank").Value = rows.ItemArray(5)
                    .Cells("bayar_bgno").Value = rows.ItemArray(6)
                    .Cells("bayar_bgtgl").Value = rows.ItemArray(7)
                End With
            Next
        End With
        dt.Dispose()
        in_total.Text = commaThousand(countTotal)
    End Sub

    Private Sub setSales(kode As String)

    End Sub

    Private Sub setFaktur(kode As String)

    End Sub

    'ADD INPUT FROM TEXTBOX TO DGV
    Private Sub textToDGV()
        If in_custo.Text = "" Then
            in_custo_n.Focus()
            Exit Sub
        End If
        If in_faktur.Text = "" Then
            in_faktur.Focus()
            Exit Sub
        End If
        If cb_bayar.SelectedValue = Nothing Then
            cb_bayar.Focus()
            Exit Sub
        End If
        If in_kredit.Value = 0 Then
            in_kredit.Focus()
            Exit Sub
        End If

        dgv_bayar.Rows.Add(in_custo.Text, in_custo_n.Text, in_faktur.Text, cb_bayar.SelectedValue, in_bank.Text, in_bg_no.Text, in_kredit.Value, date_bg_tgl.Value.ToShortDateString)
        clearInput()
        in_total.Text = commaThousand(countTotal)
    End Sub

    'LOAD SELECTED DGV ROW TO TEXTBOX INPUT
    Private Sub dgvToText()
        Dim idx As Integer = 0
        With dgv_bayar.SelectedRows.Item(0)
            in_custo.Text = .Cells("bayar_custo").Value
            in_custo_n.Text = .Cells("bayar_custo_n").Value
            in_faktur.Text = .Cells("bayar_faktur").Value
            cb_bayar.SelectedValue = .Cells("bayar_kodebayar").Value
            in_kredit.Value = .Cells("bayar_kredit").Value
            in_bank.Text = .Cells("bayar_bank").Value
            in_bg_no.Text = .Cells("bayar_bgno").Value
            date_bg_tgl.Value = CDate(.Cells("bayar_bgtgl").Value)
            idx = .Index
        End With
        dgv_bayar.Rows.RemoveAt(idx)
        in_total.Text = commaThousand(countTotal)
    End Sub

    Private Function countTotal() As Double
        Dim res As Double = 0

        For Each row As DataGridViewRow In dgv_bayar.Rows
            res += row.Cells("bayar_kredit").Value
        Next

        Return res
    End Function

    'SAVE THE DATA
    Private Sub saveData()
        If in_sales.Text = "" Then
            MessageBox.Show("Sales belum di input")
            in_sales_n.Focus()
            Exit Sub
        End If
        If dgv_bayar.RowCount = 0 Then
            MessageBox.Show("Pembayaran belum di input")
            in_custo_n.Focus()
            Exit Sub
        End If

        op_con()
        If MessageBox.Show("Simpan data transaksi penjualan?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'GENERATE KODE
            If in_no_bukti.Text = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT COUNT(p_bayar_bukti) FROM data_piutang_bayar WHERE SUBSTRING(p_bayar_bukti,3,8)='" & date_tgl_trans.Value.ToString("yyyyMMdd") & "' AND p_bayar_bukti LIKE 'PP%'")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()
                in_no_bukti.Text = "PP" & date_tgl_trans.Value.ToString("yyyyMMdd") & no.ToString("D4")
            ElseIf in_no_bukti.Text <> Nothing And LCase(bt_simpanperkiraan.Text) = "simpan pembayaran" Then
                If checkdata("data_piutang_bayar", "'" & in_no_bukti.Text & "'", "p_bayar_bukti") = True Then
                    If MessageBox.Show("Transaksi sudah pernah di inputkan, Update data?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                End If
            End If

            Dim querycheck As Boolean = False
            Dim data1, data2, data3 As String()
            Dim queryArr As New List(Of String)
            Dim q1 As String = "INSERT INTO data_piutang_bayar SET p_bayar_bukti='{0}',{1},{2} ON DUPLICATE KEY UPDATE {1},{3}"
            Dim q2 As String = "INSERT INTO data_piutang_bayar_trans SET p_trans_bukti='{0}',{1},{2} ON DUPLICATE KEY UPDATE {1}"
            Dim q3 As String = "INSERT INTO data_jurnal_line SET {0},{1} ON DUPLICATE KEY UPDATE {0},{2}"

            'INPUT HEADER
            data1 = {
                "p_bayar_tanggal_bayar='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                "p_bayar_sales='" & in_sales.Text & "'",
                "p_bayar_status='1'"
                }
            data2 = {
                "p_bayar_reg_date=NOW()",
                "p_bayar_reg_alias='" & loggeduser.user_id & "'"
                }
            data3 = {
                "p_bayar_upd_date=NOW()",
                "p_bayar_upd_alias='" & loggeduser.user_id & "'"
                }
            queryArr.Add(String.Format(q1, in_no_bukti.Text, String.Join(",", data1), String.Join(",", data2), String.Join(",", data3)))

            Dim i As Integer = 0
            Dim qdelbayar As String = "UPDATE data_piutang_bayar_trans SET p_trans_status=9 WHERE p_trans_bukti='{0}'"
            queryArr.Add(String.Format(qdelbayar, in_no_bukti.Text))
            For Each rows As DataGridViewRow In dgv_bayar.Rows
                'INPUT PAYMENT
                data1 = {
                    "p_trans_kode_piutang='" & rows.Cells("bayar_faktur").Value & "'",
                    "p_trans_jen_bayar='" & rows.Cells("bayar_kodebayar").Value & "'",
                    "p_trans_bank='" & rows.Cells("bayar_bank").Value & "'",
                    "p_trans_nobg='" & rows.Cells("bayar_bgno").Value & "'",
                    "p_trans_nilaibayar='" & rows.Cells("bayar_kredit").Value.ToString.Replace(",", ".") & "'",
                    "p_trans_tglbg='" & CDate(rows.Cells("bayar_bgtgl").Value).ToString("yyyy-MM-dd") & "'"
                    }
                data2 = {
                    "p_trans_reg_date=NOW()",
                    "p_trans_reg_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add(String.Format(q2, in_no_bukti.Text, String.Join(",", data1), String.Join(",", data2)))

                If rows.Cells("bayar_kodebayar").Value = "BG" Then
                    'TODO : INSERT INTO DATA BG
                    Dim qbg As String = "INSERT INTO data_giro SET giro_no='{0}',{1} ON DUPLICATE KEY UPDATE {1}"
                    data2 = {
                        "giro_tglbg='" & CDate(rows.Cells("bayar_bgtgl").Value).ToString("yyyy-MM-dd") & "'",
                        "giro_bank='" & rows.Cells("bayar_bank").Value & "'",
                        "giro_nilai=" & rows.Cells("bayar_kredit").Value.ToString.Replace(",", "."),
                        "giro_ref='" & in_no_bukti.Text & "'",
                        "giro_type='IN'",
                        "giro_status=1",
                        "giro_reg_date=NOW()",
                        "giro_reg_alias='" & loggeduser.user_id & "'"
                        }
                    queryArr.Add(String.Format(qbg, rows.Cells("bayar_bgno").Value, String.Join(",", data2)))
                End If
                i += 1
            Next
            'queryArr.Add("DELETE FROM data_piutang_bayar_trans WHERE p_trans_bukti='" & in_no_bukti.Text & "' AND p_trans_index>" & i)

            querycheck = startTrans(queryArr)

            Me.Cursor = Cursors.Default

            If querycheck = False Then
                Exit Sub
            Else
                'TODO : WRITE LOG ACTIVITY
                MessageBox.Show("Data tersimpan")
                doRefreshTab({pgpiutangbayar, pgpiutangawal})
                'frmhutangbayar.in_cari.Clear()
                'populateDGVUserCon("piutangbayar", "", frmpiutangbayar.dgv_list)
                Me.Close()
            End If
        End If
    End Sub

    'OPEN FULL WINDOWS SEARCH
    Private Sub searchData(tipe As String)
        Dim q As String = ""
        Using search As New fr_search_dialog

        End Using
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing, Optional param2 As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Dim autoco As New AutoCompleteStringCollection
        Select Case tipe
            Case "sales"
                q = "SELECT salesman_kode as 'Kode', salesman_nama as 'Salesman' FROM data_salesman_master " _
                    & "WHERE salesman_status<>9 AND salesman_nama LIKE '{0}%'"
                dt = getDataTablefromDB(String.Format(q, param))
            Case "custo"
                q = "SELECT customer_kode as 'Kode', customer_nama as 'Customer' FROM data_customer_master " _
                    & "WHERE customer_status<>9 AND customer_nama LIKE '{0}%'"
                dt = getDataTablefromDB(String.Format(q, param))
            Case "faktur"
                q = "SELECT piutang_faktur as 'Kode Faktur', piutang_sisa as 'Sisa Piutang', piutang_jt as 'Jatuh Tempo' " _
                    & "FROM selectpiutangawal WHERE piutang_sisa <> 0 AND piutang_custo='{1}' AND piutang_faktur LIKE '{0}%'"
                consoleWriteLine(String.Format(q, param, param2))
                dt = getDataTablefromDB(String.Format(q, param, param2))
            Case Else
                Exit Sub
        End Select

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 135
            .Columns(1).Width = 200
            If tipe = "faktur" Then
                .Columns(2).Width = 175
                .Columns(1).DefaultCellStyle = dgvstyle_currency
            End If
        End With
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case _popUpPos
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    in_sales_n.Focus()
                Case "custo"
                    in_custo.Text = .Cells(0).Value
                    in_custo_n.Text = .Cells(1).Value
                    in_custo_n.Focus()
                Case "faktur"
                    in_faktur.Text = .Cells(0).Value
                    in_kredit.Value = .Cells(1).Value
                    'AND OTHER STUFF
                    cb_bayar.Focus()
                Case Else
                    Exit Sub
            End Select

        End With
        popPnl_barang.Visible = False
    End Sub

    Private Sub clearInput()
        Dim txt As TextBox() = {in_custo, in_custo_n, in_faktur, in_bank, in_bg_no}
        For Each x As TextBox In txt
            x.Clear()
        Next
        in_kredit.Value = 0
        cb_bayar.SelectedIndex = 0
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

    '------------- load
    Private Sub fr_hutang_bayar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_bayar
            .DataSource = jenisBayar("piutang")
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With
        With cb_source

        End With
        With date_tgl_trans
            .Value = DateSerial(selectedperiode.Year, selectedperiode.Month, date_tgl_trans.Value.Day)
            .MaxDate = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)
            .MinDate = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
        End With

        bayar_kredit.DefaultCellStyle = dgvstyle_currency

        If in_no_bukti.Text <> Nothing Then
            loadData(in_no_bukti.Text)
        End If
    End Sub

    '------------ save
    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click
        saveData()
    End Sub

    'UI
    Private Sub in_sales_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter
        popPnl_barang.Location = New Point(in_sales_n.Left, in_sales_n.Top + in_sales_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        _popUpPos = "sales"
        loadDataBRGPopup("sales", in_sales_n.Text)
    End Sub

    Private Sub in_sales_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
            If Trim(in_sales_n.Text) <> Nothing Then
                'setBarang(in_barang_nm.Text)
            End If
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
                With dgv_listbarang.SelectedRows.Item(0)
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                End With
            End If
            keyshortenter(date_tgl_trans, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("sales", in_sales_n.Text)
        End If
    End Sub

    Private Sub in_sales_n_TextChanged(sender As Object, e As EventArgs) Handles in_sales_n.TextChanged
        If in_sales_n.Text = "" Then
            'DO THING
            in_sales.Clear()
        End If
    End Sub

    Private Sub in_custo_n_Enter(sender As Object, e As EventArgs) Handles in_custo_n.Enter
        popPnl_barang.Location = New Point(in_custo_n.Left, in_custo_n.Top + in_custo_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        _popUpPos = "custo"
        loadDataBRGPopup("custo", in_custo_n.Text)
    End Sub

    Private Sub in_custo_n_Leave(sender As Object, e As EventArgs) Handles in_custo_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
            If Trim(in_custo_n.Text) <> Nothing Then
                'setBarang(in_barang_nm.Text)
            End If
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
                With dgv_listbarang.SelectedRows.Item(0)
                    in_custo.Text = .Cells(0).Value
                    in_custo_n.Text = .Cells(1).Value
                End With
            End If
            keyshortenter(in_faktur, e)
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
            in_faktur.Clear()
            'AND OTHER THINGS
        End If
    End Sub

    Private Sub in_faktur_Enter(sender As Object, e As EventArgs) Handles in_faktur.Enter
        popPnl_barang.Location = New Point(in_faktur.Left, in_faktur.Top + in_faktur.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        _popUpPos = "faktur"
        loadDataBRGPopup("faktur", in_faktur.Text, in_custo.Text)
    End Sub

    Private Sub in_faktur_Leave(sender As Object, e As EventArgs) Handles in_faktur.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
            If Trim(in_faktur.Text) <> Nothing Then
                'setBarang(in_barang_nm.Text)
            End If
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
                With dgv_listbarang.SelectedRows.Item(0)
                    in_faktur.Text = .Cells(0).Value
                    in_kredit.Value = .Cells(1).Value
                    'AND OTHER STUFF
                End With
            End If
            keyshortenter(cb_bayar, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("faktur", in_faktur.Text, in_custo.Text)
        End If
    End Sub

    Private Sub in_faktur_TextChanged(sender As Object, e As EventArgs) Handles in_faktur.TextChanged
        If in_faktur.Text = "" Then

        End If
    End Sub

    '----------------POPUP PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_sales_n.Focused Or in_custo_n.Focused Or in_faktur.Focused Then
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
            Select Case _popUpPos
                Case "sales"
                    x = in_sales_n
                Case "custo"
                    x = in_custo_n
                Case "faktur"
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

    '------------- cb prevent input
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_bayar.KeyPress
        e.Handled = True
    End Sub

    '------------- numeric
    Private Sub in_debet_Enter(sender As Object, e As EventArgs) Handles in_kredit.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_debet_Leave(sender As Object, e As EventArgs) Handles in_kredit.Leave
        numericLostFocus(sender)
    End Sub

    '-------------- OTHER
    Private Sub cb_bayar_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_bayar.KeyUp
        keyshortenter(in_kredit, e)
    End Sub

    Private Sub in_bank_KeyUp(sender As Object, e As KeyEventArgs) Handles in_bank.KeyUp
        keyshortenter(in_bg_no, e)
    End Sub

    Private Sub in_bg_no_KeyUp(sender As Object, e As KeyEventArgs) Handles in_bg_no.KeyUp
        keyshortenter(date_bg_tgl, e)
    End Sub

    Private Sub in_kredit_KeyUp(sender As Object, e As KeyEventArgs) Handles in_kredit.KeyUp
        keyshortenter(in_bank, e)
    End Sub

    Private Sub date_bg_tgl_KeyUp(sender As Object, e As KeyEventArgs) Handles date_bg_tgl.KeyUp
        keyshortenter(bt_tbbayar, e)
    End Sub

    Private Sub bt_tbbayar_Click(sender As Object, e As EventArgs) Handles bt_tbbayar.Click
        textToDGV()
    End Sub

    Private Sub date_tgl_trans_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_trans.KeyDown
        keyshortenter(in_custo, e)
    End Sub

    Private Sub in_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles in_custo.KeyDown
        keyshortenter(in_custo_n, e)
    End Sub

    Private Sub dgv_bayar_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_bayar.CellDoubleClick
        If e.RowIndex > -1 Then
            dgvToText()
        End If
    End Sub
End Class