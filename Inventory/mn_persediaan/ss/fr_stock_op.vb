Public Class fr_stock_op
    Private rowindex As Integer = 0
    Private statusop As String = "0"

    '-----------------------note
    'delete -> not yet
    'proses -> unfinished, - log stock, -log who prced it
    'print -> not yet

    Private Sub loadDataFaktur(kode As String)
        readcommd("SELECT * FROM data_barang_stok_opname WHERE faktur_bukti='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = rd.Item("faktur_bukti")
            date_tgl_trans.Value = rd.Item("faktur_tanggal")
            cb_gudang.SelectedValue = rd.Item("faktur_gudang")
            in_ket.Text = rd.Item("faktur_ket")
            statusop = rd.Item("faktur_status")
            txtRegAlias.Text = rd.Item("faktur_reg_alias")
            txtRegdate.Text = rd.Item("faktur_reg_date")
            Try
                txtUpdDate.Text = rd.Item("faktur_upd_date")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("faktur_upd_alias")
        End If
        rd.Close()
    End Sub

    Private Sub loadDatabarang(kode As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_qty_sys, trans_satuan, trans_qty_fisik, trans_keterangan FROM data_barang_stok_opname_trans INNER JOIN data_barang_master ON barang_kode=trans_barang WHERE trans_faktur='" & kode & "'")
        With dgv_barang.Rows
            For Each x As DataRow In dt.Rows
                Dim y As Integer = .Add
                With .Item(y)
                    .Cells("kode").Value = x.ItemArray(0)
                    .Cells("nama").Value = x.ItemArray(1)
                    .Cells("qty_sys").Value = x.ItemArray(2)
                    .Cells("sat_sys").Value = x.ItemArray(3)
                    .Cells("qty_fis").Value = x.ItemArray(4)
                    .Cells("sat_fis").Value = x.ItemArray(3)
                    .Cells("qty_sel").Value = x.ItemArray(4) - x.ItemArray(2)
                    .Cells("ket").Value = x.ItemArray(5)
                End With
            Next
        End With
    End Sub

    Private Sub loadDataBRGPopup()
        With dgv_listbarang
            .DataSource = getDataTablefromDB("SELECT barang_kode, barang_nama, stock_sisa FROM data_barang_stok INNER JOIN data_barang_master ON stock_barang=barang_kode WHERE barang_kode LIKE'%" & in_barang.Text & "%' AND stock_gudang='" & cb_gudang.SelectedValue & "' LIMIT 100")
        End With
    End Sub

    Private Sub setBarang(kode As String)
        readcommd("SELECT barang_nama, barang_satuan_kecil, stock_sisa FROM data_barang_stok INNER JOIN data_barang_master ON barang_kode=stock_barang WHERE stock_gudang='" & cb_gudang.SelectedValue & "' AND stock_barang='" & kode & "'")
        If rd.HasRows Then
            in_barang.Text = kode
            in_barang_nm.Text = rd.Item("barang_nama")
            in_qty_sys.Text = rd.Item("stock_sisa")
            in_satuan.Text = rd.Item("barang_satuan_kecil")
            in_satuan2.Text = in_satuan.Text
        End If
        rd.Close()
    End Sub

    Private Sub setFor(status As String)
        Select Case statusop
            Case "0"
                bt_simpanreturbeli.Text = "Simpan"
            Case "1"
                bt_simpanreturbeli.Text = "Update"
                in_status_kode.Text = "Active"
                in_kode.ReadOnly = True
            Case "2"
                bt_simpanreturbeli.Visible = False
                bt_batalreturbeli.Text = "OK"
                in_status_kode.Text = "Done"
                mn_delete.Visible = False
                mn_save.Visible = False
                mn_proses.Visible = False
                in_gudang_ro.Location = New Point(cb_gudang.Location)
                in_gudang_ro.Text = cb_gudang.Text
                in_gudang_ro.Visible = True
                cb_gudang.Visible = False
                bt_gudang_list.Visible = False
                date_tgl_trans.Enabled = False
                in_ket.ReadOnly = True
                For Each x As TextBox In {in_barang, in_barang_nm, in_ket_brg, in_satuan, in_satuan2, in_qty_sys}
                    x.Visible = False
                Next
                in_qty.Visible = False
                bt_tbbarang.Visible = False
                dgv_barang.Height = 247
        End Select
    End Sub

    Private Sub txtToDGV()
        If Trim(in_barang_nm.Text) = Nothing Then
            in_barang.Focus()
            Exit Sub
        End If
        If in_qty.Value = 0 Then
            in_qty.Focus()
            Exit Sub
        End If

        With dgv_barang.Rows
            Dim x As Integer = .Add
            With .Item(x)
                .Cells("kode").Value = in_barang.Text
                .Cells("nama").Value = in_barang_nm.Text
                .Cells("qty_sys").Value = CDbl(in_qty_sys.Text)
                .Cells("sat_sys").Value = in_satuan.Text
                .Cells("qty_fis").Value = in_qty.Value
                .Cells("sat_fis").Value = in_satuan2.Text
                .Cells("qty_sel").Value = in_qty.Value - CDbl(in_qty_sys.Text)
                .Cells("ket").Value = in_ket_brg.Text
            End With
        End With

        clearBarang()
        in_barang.Focus()
    End Sub

    Private Sub dgvToTxt()
        With dgv_barang.Rows(rowindex)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty_sys.Text = .Cells("qty_sys").Value
            in_satuan.Text = .Cells("sat_sys").Value
            in_satuan2.Text = in_satuan.Text
            in_qty.Value = .Cells("qty_fis").Value
            in_ket_brg.Text = .Cells("ket").Value
        End With
        in_barang.Focus()
    End Sub

    Private Sub numericGotFocus(sender As NumericUpDown)
        If sender.Value = 0 Then
            sender.ResetText()
        End If
    End Sub

    Private Sub numericLostFocus(x As NumericUpDown)
        x.Controls.Item(1).Text = x.Value
    End Sub

    Private Sub keyshortenter(nextcontrol As Control, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nextcontrol.Focus()
        End If
    End Sub

    Private Sub clearBarang()
        For Each x As TextBox In {in_barang, in_barang_nm, in_qty_sys, in_satuan, in_satuan2, in_ket_brg}
            x.Clear()
        Next
        in_qty.Value = 0
    End Sub

    Private Sub clearForm()
        in_kode.Clear()
        in_ket.Clear()
        cb_gudang.SelectedIndex = -1
    End Sub

    Private Sub fr_stock_op_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        in_kode.Focus()
        'mn_delete.Visible = True

        With cb_gudang
            .DataSource = getDataTablefromDB("SELECT gudang_kode, gudang_nama FROM data_barang_gudang")
            .DisplayMember = "gudang_nama"
            .ValueMember = "gudang_kode"
            .SelectedIndex = -1
        End With

        If bt_simpanreturbeli.Text <> "Simpan" Then
            With in_kode
                .ReadOnly = True
                loadDataFaktur(.Text)
                loadDatabarang(.Text)
            End With
        End If

        'set form based on status
        setFor(statusop)
    End Sub

    '---------------numeric
    Private Sub numericenter(sender As Object, e As EventArgs) Handles in_qty.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub numericleave(sender As Object, e As EventArgs) Handles in_qty.Leave
        numericLostFocus(sender)
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
    '----------------CL bt
    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalreturbeli.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '--------------------------- save
    Private Sub bt_simpanreturbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanreturbeli.Click
        'proses -------------->
        'cek input data
        'ask confir
        'cek insert or update
        '-------- insert
        'insert data faktur, data barang
        '-------- update
        'update data faktur, delete data barang, re insert data barang

        'If Trim(in_kode.Text) = "" Then
        '    MessageBox.Show("No. Bukti belum di input")
        '    in_kode.Focus()
        '    Exit Sub
        'End If
        If cb_gudang.SelectedValue = Nothing Then
            MessageBox.Show("Gudang belum di input")
            cb_gudang.Focus()
            Exit Sub
        End If
        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum di input")
            in_barang.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.AppStarting

        Dim querycheck As String = False
        Dim queryArr As New List(Of String)
        Dim datafaktur As String()
        Dim dataBrg As String()

        If bt_simpanreturbeli.Text <> "OK" And MessageBox.Show("Simpan?", Application.ProductName, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            op_con()
            If bt_simpanreturbeli.Text = "Simpan" Then
                If Trim(in_kode.Text) <> Nothing Then
                    'TODO check no_bukti
                    If checkdata("data_barang_stok_opname", "'" & in_kode.Text & "'", "faktur_bukti") = True Then
                        MessageBox.Show("No.Bukti " & in_kode.Text & " sudah ada!")
                        in_kode.Select()
                        Exit Sub
                    End If
                Else
                    'TODO generate kode
                    Dim x As String
                    readcommd("SELECT SUBSTRING(faktur_bukti,3)+1 as a FROM data_barang_stok_opname WHERE faktur_bukti LIKE 'OP%' AND faktur_tanggal=CURDATE()")
                    If rd.HasRows Then
                        x = rd.Item(0)
                    Else
                        x = Today.ToString("yyyyMMdd") & "001"
                    End If
                    rd.Close()
                    Dim fakturkode As String = "OP" & x.ToString
                    in_kode.Text = fakturkode
                End If

                datafaktur = {
                    "faktur_bukti='" & in_kode.Text & "'",
                    "faktur_tanggal='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_gudang='" & cb_gudang.SelectedValue & "'",
                    "faktur_ket='" & in_ket.Text & "'",
                    "faktur_status='1'",
                    "faktur_reg_date=NOW()",
                    "faktur_reg_alias='" & loggeduser.user_id & "'"
                    }

                'INSERT
                queryArr.Add("INSERT INTO data_barang_stok_opname SET " & String.Join(",", datafaktur))

            ElseIf bt_simpanreturbeli.Text = "Update" Then
                datafaktur = {
                    "faktur_tanggal='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_gudang='" & cb_gudang.SelectedValue & "'",
                    "faktur_ket='" & in_ket.Text & "'",
                    "faktur_upd_date=NOW()",
                    "faktur_upd_alias='" & loggeduser.user_id & "'"
                    }

                'UPDATE
                queryArr.Add("UPDATE data_barang_stok_opname SET " & String.Join(",", datafaktur) & " WHERE faktur_bukti='" & in_kode.Text & "'")

                'DELETE data trans/barang
                queryArr.Add("DELETE FROM data_barang_stok_opname_trans WHERE trans_faktur='" & in_kode.Text & "'")
            End If

            'INSERT/re-INSERT data trans/barang
            For Each rows As DataGridViewRow In dgv_barang.Rows
                dataBrg = {
                    "trans_faktur='" & in_kode.Text & "'",
                    "trans_tanggal='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                    "trans_barang='" & rows.Cells(0).Value & "'",
                    "trans_qty_sys=" & rows.Cells("qty_sys").Value,
                    "trans_qty_fisik=" & rows.Cells("qty_fis").Value,
                    "trans_satuan='" & rows.Cells("sat_sys").Value & "'",
                    "trans_keterangan='" & rows.Cells("ket").Value & "'",
                    "trans_reg_date=NOW()",
                    "trans_reg_alias='" & loggeduser.user_id & "'"
                    }

                queryArr.Add("INSERT INTO data_barang_stok_opname_trans SET " & String.Join(",", dataBrg))

                ''update stok
                ''TODO UPDATE stok beli -> must recognize whether is added or substracted when trans update
                'Dim selisih As Integer = rows.Cells("qty_fis").Value

                'If bt_simpanreturbeli.Text = "Update" Then
                '    'select original qty from trans_beli
                '    readcommd("SELECT IFNULL(trans_qty_fisik,0) as a FROM data_barang_stok_opname_trans WHERE trans_barang='" & rows.Cells(0).Value & "' AND trans_faktur='" & in_kode.Text & "'")
                '    'count the diff
                '    selisih = rows.Cells("qty_fis").Value - rd.Item("a")
                '    rd.Close()
                'End If

                'queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_fisik=IFNULL(stock_fisik,0)+({2}) WHERE stock_gudang='{0}' AND stock_barang='{1}'", cb_gudang.SelectedValue, rows.Cells(0).Value, selisih))

                'queryArr.Add(String.Format("INSERT data_barang_stok SET stock_barang='{0}', stock_gudang='{1}', stock_awal={2}, stock_reg_date=NOW(), stock_reg_alias='{3}'", rows.Cells(0).Value, in_gudang.Text, selisih, loggeduser.user_id))

                'queryArr.Add(String.Format("INSERT INTO log_stock SET , log_ket='SYSTEM OPNAME'"))
            Next

            querycheck = startTrans(queryArr)

            Me.Cursor = Cursors.Default

            If querycheck = False Then
                MessageBox.Show("Data tidak dapat tersimpan")
                Me.Cursor = Cursors.Default
                Exit Sub
            Else
                MessageBox.Show("Data tersimpan")
                Try
                    loadDataFaktur(in_kode.Text)
                Catch ex As Exception
                    statusop = "1"
                End Try
                setFor(statusop)
                frmstockop.in_cari.Clear()
                populateDGVUserCon("stockop", "", frmstockop.dgv_list)
                'Me.Close()
            End If
        End If
    End Sub

    '-------------- bt button
    Private Sub bt_batalreturbeli_Click(sender As Object, e As EventArgs) Handles bt_batalreturbeli.Click
        If MessageBox.Show("Tutup Form?", "Stock Opname", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    '----------------- input
    Private Sub cb_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_gudang.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_gudang_list.PerformClick()
        End If
        keyshortenter(in_ket, e)
    End Sub

    Private Sub bt_gudang_list_Click(sender As Object, e As EventArgs) Handles bt_gudang_list.Click
        Using search As New fr_search_dialog
            With search
                If cb_gudang.Text <> Nothing Then
                    .in_cari.Text = cb_gudang.Text
                End If
                If cb_gudang.SelectedValue <> Nothing Then
                    .returnkode = cb_gudang.SelectedValue
                End If
                .query = "SELECT gudang_kode as kode, gudang_nama as nama FROM data_barang_gudang"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "gudang"
                .ShowDialog()
                cb_gudang.SelectedValue = .returnkode
            End With
        End Using
        in_ket.Focus()
    End Sub

    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(date_tgl_trans, e)
    End Sub

    Private Sub date_tgl_trans_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_trans.KeyDown
        keyshortenter(cb_gudang, e)
    End Sub

    '-------------- input barang
    '---------------pop up list barang
    Private Sub in_barang_Enter(sender As Object, e As EventArgs) Handles in_barang_nm.Enter, in_barang.Enter
        popPnl_barang.Location = New Point(in_barang.Left, in_barang.Top + in_barang.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
            loadDataBRGPopup()
        End If
    End Sub

    Private Sub in_barang_Leave(sender As Object, e As EventArgs) Handles in_barang_nm.Leave, in_barang.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If

        If Trim(in_barang.Text) <> Nothing Then
            setBarang(in_barang.Text)
        End If
    End Sub

    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_barang.Focused = True Or in_barang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub dgv_listbarang_CellContentDBLClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellDoubleClick
        in_barang.Text = dgv_listbarang.Rows(e.RowIndex).Cells("brg_kode").Value
        setBarang(in_barang.Text)
        in_qty.Focus()
    End Sub

    Private Sub in_barang_TextChanged(sender As Object, e As EventArgs) Handles in_barang.TextChanged
        If in_barang.Text = "" Then
            For Each x As TextBox In {in_barang_nm, in_qty_sys, in_satuan, in_satuan2}
                x.Clear()
            Next
        End If
        If popPnl_barang.Visible = True Then
            loadDataBRGPopup()
        End If
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        For Each x As TextBox In {in_barang_nm, in_qty_sys, in_satuan, in_satuan2}
            x.Clear()
        Next
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    If Trim(in_barang.Text) <> Nothing Then
                        .in_cari.Text = in_barang.Text
                    End If
                    .returnkode = in_barang.Text
                    .query = "SELECT barang_nama as nama, barang_kode as kode, gudang_nama as gudang FROM data_barang_master INNER JOIN data_barang_stok on stock_barang=barang_kode INNER JOIN data_barang_gudang ON stock_gudang=gudang_kode WHERE stock_gudang='" & cb_gudang.SelectedValue & "'"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%' OR gudang LIKE '%{0}%'"
                    .type = "barangmutasi"
                    .ShowDialog()
                    in_barang.Text = .returnkode
                    in_barang.Focus()
                End With
            End Using
            in_qty.Focus()
            Exit Sub
        End If
        keyshortenter(in_qty, e)
    End Sub

    Private Sub linkLbl_searchbarang_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLbl_searchbarang.LinkClicked
        popPnl_barang.Visible = False
        Using search As New fr_search_dialog
            With search
                If Trim(in_barang.Text) <> Nothing Then
                    .in_cari.Text = in_barang.Text
                End If
                .returnkode = in_barang.Text
                .query = "SELECT barang_nama as nama, barang_kode as kode, gudang_nama as gudang FROM data_barang_master INNER JOIN data_barang_stok on stock_barang=barang_kode INNER JOIN data_barang_gudang ON stock_gudang=gudang_kode WHERE stock_gudang='" & cb_gudang.SelectedValue & "'"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%' OR gudang LIKE '%{0}%'"
                .type = "barangmutasi"
                .ShowDialog()
                in_barang.Text = .returnkode
            End With
        End Using
        If Trim(in_barang.Text) <> Nothing Then
            setBarang(Trim(in_barang.Text))
        End If
        in_qty.Focus()
        Exit Sub
    End Sub

    Private Sub in_qty_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
        keyshortenter(in_ket, e)
    End Sub

    Private Sub in_ket_brg_KeyDown(sender As Object, e As KeyEventArgs) Handles in_ket_brg.KeyDown
        keyshortenter(bt_tbbarang, e)
    End Sub

    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        txtToDGV()
    End Sub

    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        If statusop <> "2" Then
            If e.RowIndex < 0 Then
                rowindex = 0
            Else
                rowindex = e.RowIndex
                dgvToTxt()
                dgv_barang.Rows.RemoveAt(rowindex)
            End If
        End If
    End Sub

    'menu bar
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanreturbeli.PerformClick()
    End Sub

    Private Sub mn_delete_Click(sender As Object, e As EventArgs) Handles mn_delete.Click
        'If MessageBox.Show("Hapus Opname " & in_kode.Text & "?", "Stock Opname", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        '    Dim querycheck As Boolean = False
        '    Dim queryArr As New List(Of String)

        '    op_con()
        '    queryArr.Add("UPDATE data_barang_stok_opname SET faktur_status='9' WHERE faktur_bukti='" & in_kode.Text & "'")
        '    queryArr.Add("DELETE FROM data_barang_stok_opname_trans WHERE trans_faktur='" & in_kode.Text & "'")
        '    'write log(?)

        '    querycheck = startTrans(queryArr)

        '    If querycheck = True Then
        '        MessageBox.Show("Data berhasil dihapus")
        '    Else
        '        MessageBox.Show("Data tidak dapat dihapus")
        '    End If
        'End If
    End Sub

    Private Sub mn_print_Click(sender As Object, e As EventArgs) Handles mn_print.Click

    End Sub

    Private Sub mn_proses_Click(sender As Object, e As EventArgs) Handles mn_proses.Click
        'proses -------------->
        'ask confir, if yes next
        'create log/history stok
        'update existing stock
        'update data op
        'create activity log

        If MessageBox.Show("Proses Opname Ref." & in_kode.Text & "?", "Stock Opname", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim querycheck As Boolean = False
            Dim queryArr As New List(Of String)
            Dim dataBrg As String()

            Me.Cursor = Cursors.WaitCursor

            queryArr.Add("UPDATE data_barang_stok_opname SET faktur_status='2', faktur_upd_date=NOW(), faktur_upd_alias='" & loggeduser.user_id & "' WHERE faktur_bukti='" & in_kode.Text & "'")

            For Each rows As DataGridViewRow In dgv_barang.Rows
                ''write log stok
                'queryArr.Add("createLogStock('" & rows.Cells(0).Value & "','" & cb_gudang.SelectedValue & "')")

                'update stok
                dataBrg = {
                    "stock_awal='" & rows.Cells("qty_fis").Value & "'",
                    "stock_sisa='" & rows.Cells("qty_fis").Value & "'",
                    "stock_beli='0'",
                    "stock_jual='0'",
                    "stock_retur_beli='0'",
                    "stock_retur_jual='0'",
                    "stock_in='0'",
                    "stock_out='0'",
                    "stock_fisik='0'",
                    "stock_tgl=NOW()"
                    }
                queryArr.Add("UPDATE data_barang_stok SET " & String.Join(",", dataBrg) & " WHERE stock_barang='" & rows.Cells(0).Value & "' AND stock_gudang='" & cb_gudang.SelectedValue & "'")

                ''log(?)
                'queryArr.Add("INSERT INTO log_stock SET log_reg=NOW(), log_user='" & loggeduser.user_id & "', log_barang='" & rows.Cells(0).Value & "', log_gudang='" & cb_gudang.SelectedValue & "', log_tanggal=NOW(), log_ip='" & loggeduser.user_ip & "', log_komputer='" & loggeduser.user_host & "', log_mac='" & loggeduser.user_mac & "', log_nama='OPNAME " & in_kode.Text & "'")
            Next

            op_con()
            querycheck = startTrans(queryArr)
            Me.Cursor = Cursors.Default

            If querycheck = True Then
                Try
                    loadDataFaktur(in_kode.Text)
                Catch ex As Exception
                    statusop = "2"
                End Try
                setFor(statusop)
                MessageBox.Show("Opname berhasil diproses")
            End If
        End If
    End Sub

    Private Sub bt_proses_Click(sender As Object, e As EventArgs)
        'confirm opname
        'ask verification?
        'UPDATE stok -> stok awal, tgl, reset qty[0]
        'UPDATE stockop -> tgl_proses, by_who
        'write log -> barang, gudang, tgl, act => opn, by, ip, host, mac, ket

        Dim querycheck As Boolean = False
        Dim queryArr As New List(Of String)
        'Dim dataBrg As String()

        Me.Cursor = Cursors.WaitCursor

        queryArr.Add("UPDATE data_barang_stok_opname SET faktur_status='2', faktur_upd_date=NOW(), faktur_upd_alias='" & loggeduser.user_id & "' WHERE faktur_bukti='" & in_kode.Text & "'")
        For Each rows As DataGridViewRow In dgv_barang.Rows
            queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_fisik=IFNULL(stock_fisik,0)+({2}) WHERE stock_gudang='{0}' AND stock_barang='{1}'", cb_gudang.SelectedValue, rows.Cells(0).Value, rows.Cells("qty_fis").Value))

            commnd("INSERT INTO log_stock SET log_reg=NOW(), log_user='" & loggeduser.user_id & "', log_barang='" & rows.Cells(0).Value & "', log_gudang='" & cb_gudang.SelectedValue & "', log_tanggal=NOW(), log_ip='" & loggeduser.user_ip & "', log_komputer='" & loggeduser.user_host & "', log_mac='" & loggeduser.user_mac & "', log_nama='OPNAME " & in_kode.Text & "'")
            '
        Next

        querycheck = startTrans(queryArr)

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("Data tersimpan")
            frmstockop.in_cari.Clear()
            populateDGVUserCon("stockop", "", frmstockop.dgv_list)
            Me.Close()
        End If
    End Sub
End Class