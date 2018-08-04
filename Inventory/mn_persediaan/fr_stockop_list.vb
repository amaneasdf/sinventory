Public Class fr_stockop_list
    Public tabpagename As TabPage
    Private rowindex As Integer = 0
    Private rowindexlist As Integer = 0
    Private rowindexbarang As Integer = 0
    Private statusop As String = 0

    Public Sub setpage(page As TabPage)
        tabpagename = page
        Console.WriteLine("pg" & page.Name.ToString)
        Console.WriteLine("pgset" & tabpagename.Name.ToString)
    End Sub

    Private Sub loadData(kode As String)
        readcommd("SELECT * FROM data_barang_stok_opname WHERE faktur_bukti='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = rd.Item("faktur_bukti")
            date_tgl_beli.Value = rd.Item("faktur_tanggal")
            date_tgl_beli_r.Text = date_tgl_beli.Value.ToLongDateString
            cb_gudang.SelectedValue = rd.Item("faktur_gudang")
            in_gudang_r.Text = cb_gudang.Text
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

        If statusop = 1 Then
            mn_edit.Enabled = True
            mn_proses.Enabled = True
        Else
            mn_edit.Enabled = False
            mn_proses.Enabled = False
        End If
    End Sub

    Private Sub loadDataBrg(kode As String)
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

    Public Sub loadCBGudang()
        With cb_gudang
            .DataSource = getDataTablefromDB("SELECT gudang_kode, gudang_nama FROM data_barang_gudang")
            .DisplayMember = "gudang_nama"
            .ValueMember = "gudang_kode"
            .SelectedIndex = -1
        End With

    End Sub

    Private Sub setBarang(kode As String)
        readcommd("SELECT barang_nama, barang_satuan_kecil, stock_sisa FROM data_stok_awal INNER JOIN data_barang_master ON barang_kode=stock_barang WHERE stock_gudang='" & cb_gudang.SelectedValue & "' AND stock_barang='" & kode & "'")
        If rd.HasRows Then
            in_barang.Text = kode
            in_barang_nm.Text = rd.Item("barang_nama")
            in_qty1.Text = rd.Item("stock_sisa")
            in_sat1.Text = rd.Item("barang_satuan_kecil")
            in_sat2.Text = in_sat1.Text
        End If
        rd.Close()
    End Sub

    Private Sub loadDataBRGPopup()
        With dgv_listbarang
            .DataSource = getDataTablefromDB("SELECT barang_kode, barang_nama FROM data_stok_awal INNER JOIN data_barang_master ON stock_barang=barang_kode WHERE barang_kode LIKE'%" & in_barang.Text & "%' AND stock_gudang='" & cb_gudang.SelectedValue & "' LIMIT 100")
        End With
    End Sub

    Private Sub searchData(param As String)
        If mn_save.Enabled = True Then
            If MessageBox.Show("Batalkan Perubahan?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            Else
                mn_save.Enabled = False
            End If
        End If
        clearAll()
        disableAllSwitch(True)
        mn_tambah.Text = "Baru"
        mn_tambah.Enabled = True
        mn_edit.Text = "Edit"
        mn_edit.Enabled = True
        populateDGVUserCon("stockop", param, frmstockop.dgv_list)
    End Sub

    Private Sub listToDetail()
        If mn_save.Enabled = True Then
            If MessageBox.Show("Batalkan Perubahan?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            Else
                mn_save.Enabled = True
            End If
        End If
        clearAll()
        disableAllSwitch(True)
        dgv_barang.Rows.Clear()
        Try
            Me.Cursor = Cursors.AppStarting
            loadData(dgv_list.Rows(rowindex).Cells("kode").Value)
            loadDataBrg(in_kode.Text)
        Catch ex As Exception
            Dim text As String = "Tidak dapat menampilkan data" & Environment.NewLine & ex.Message
            MessageBox.Show(text)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub textToDGV()
        If in_barang_nm.Text = Nothing Then
            in_barang.Focus()
            Exit Sub
        End If
        If in_qty2.Value = 0 Then
            in_qty2.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim check As Boolean = False
        If dgv_barang.RowCount > 0 Then
            For Each rows As DataGridViewRow In dgv_barang.Rows
                If rows.Cells("kode").Value = in_barang.Text Then
                    If MessageBox.Show("Barang yang sama sudah diinputkan ke dalam list, tambahkan qty pada barang tersebut?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        rows.Cells("qty_fis").Value += in_qty2.Value
                        rows.Cells("qty_sel").Value = rows.Cells("qty_fis").Value - rows.Cells("qty_sys").Value
                        Me.Cursor = Cursors.Default
                        clearInputBarang()
                        check = True
                        Exit For
                    Else
                        check = True
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If

        If check = False Then
            With dgv_barang.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("kode").Value = in_barang.Text
                    .Cells("nama").Value = in_barang_nm.Text
                    .Cells("qty_sys").Value = CDbl(in_qty1.Text)
                    .Cells("sat_sys").Value = in_sat1.Text
                    .Cells("qty_fis").Value = in_qty2.Value
                    .Cells("sat_fis").Value = in_sat2.Text
                    .Cells("qty_sel").Value = in_qty2.Value - CDbl(in_qty1.Text)
                    .Cells("ket").Value = in_ket_brg.Text
                End With
            End With
            clearInputBarang()
        End If

        Me.Cursor = Cursors.Default

        in_barang.Focus()
    End Sub

    Private Sub dgvToTxt()
        With dgv_barang.Rows(rowindexbarang)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty1.Text = .Cells("qty_sys").Value
            in_sat1.Text = .Cells("sat_sys").Value
            in_qty2.Value = .Cells("qty_fis").Value
            in_sat2.Text = .Cells("sat_fis").Value
            in_ket_brg.Text = .Cells("ket").Value
        End With
        in_barang.Focus()
    End Sub

    Private Sub saveData()
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

        Me.Cursor = Cursors.WaitCursor

        Dim querycheck As String = False
        Dim queryArr As New List(Of String)
        Dim datafaktur As String()
        Dim dataBrg As String()

        op_con()
        If mn_tambah.Text = "Batal" Then
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
                readcommd("SELECT SUBSTRING(faktur_bukti,4)+1 as a FROM data_barang_stok_opname WHERE faktur_bukti LIKE 'OPN%' AND SUBSTRING(faktur_bukti,4,8)='" & date_tgl_beli.Value.ToString("yyyyMMdd"))
                If rd.HasRows Then
                    x = rd.Item(0)
                Else
                    x = date_tgl_beli.Value.ToString("yyyyMMdd") & "001"
                End If
                rd.Close()
                Dim fakturkode As String = "OPN" & x.ToString
                in_kode.Text = fakturkode
            End If

            datafaktur = {
                "faktur_bukti='" & in_kode.Text & "'",
                "faktur_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_gudang='" & cb_gudang.SelectedValue & "'",
                "faktur_status='1'",
                "faktur_reg_date=NOW()",
                "faktur_reg_alias='" & loggeduser.user_id & "'"
                }

            'INSERT
            queryArr.Add("INSERT INTO data_barang_stok_opname SET " & String.Join(",", datafaktur))

        ElseIf mn_edit.Text = "Batal Edit" Then
            datafaktur = {
                "faktur_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_gudang='" & cb_gudang.SelectedValue & "'",
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
                "trans_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "trans_barang='" & rows.Cells(0).Value & "'",
                "trans_qty_sys=" & rows.Cells("qty_sys").Value,
                "trans_qty_fisik=" & rows.Cells("qty_fis").Value,
                "trans_satuan='" & rows.Cells("sat_sys").Value & "'",
                "trans_keterangan='" & rows.Cells("ket").Value & "'",
                "trans_reg_date=NOW()",
                "trans_reg_alias='" & loggeduser.user_id & "'"
                }

            queryArr.Add("INSERT INTO data_barang_stok_opname_trans SET " & String.Join(",", dataBrg))

            'TODO: UPDATE STOCK
            'TODO: WRITE LOG

        Next

        querycheck = startTrans(queryArr)

        Me.Cursor = Cursors.Default

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmstockop.in_cari.Clear()
            populateDGVUserCon("stockop", "", frmstockop.dgv_list)
            mn_edit.Enabled = True
            mn_tambah.Enabled = True
            mn_proses.Enabled = True
            mn_edit.Text = "Edit"
            mn_tambah.Text = "Tambah"
            disableAllSwitch(True)
            mn_save.Enabled = False
        End If
    End Sub


    Private Sub clearTextBarang()
        For Each x As NumericUpDown In {in_qty2}
            x.Value = 0
        Next
        For Each x As TextBox In {in_barang_nm, in_sat1, in_sat2, in_ket_brg, in_qty1}
            x.Clear()
        Next
    End Sub

    Private Sub clearInputBarang()
        clearTextBarang()
        in_barang.Clear()
    End Sub

    Private Sub clearAll()
        For Each x As TextBox In {in_kode, in_barang, in_barang_nm, in_sat1, in_sat2, txtRegAlias, txtRegdate, txtUpdAlias, txtUpdDate, in_gudang_r, date_tgl_beli_r, in_ket_brg, in_qty1}
            x.Clear()
        Next
        For Each x As NumericUpDown In {in_qty2}
            x.Value = 0
        Next
        date_tgl_beli.Value = selectedperiode
        dgv_barang.Rows.Clear()
        cb_gudang.SelectedIndex = -1
    End Sub

    Private Sub disableAllSwitch(switch As Boolean)
        For Each x As TextBox In {in_barang, in_ket_brg}
            x.ReadOnly = switch
        Next
        For Each x As NumericUpDown In {in_qty2}
            x.ReadOnly = switch
        Next
        For Each x As Button In {bt_tbbarang, bt_gudang_list}
            If switch = True Then
                x.Enabled = False
            Else
                x.Enabled = True
            End If
        Next
        If switch = True Then
            cb_gudang.Visible = False
            date_tgl_beli.Visible = False
            dgv_barang.Enabled = False
        Else
            cb_gudang.Visible = True
            date_tgl_beli.Visible = True
            dgv_barang.Enabled = True
        End If
        in_gudang_r.Visible = switch
        date_tgl_beli_r.Visible = switch

        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub

    '----------------- close
    Private Sub bt_close_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_close_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        clearAll()
        disableAllSwitch(True)
        mn_save.Enabled = False
        mn_tambah.Text = "Baru"
        mn_tambah.Enabled = True
        mn_edit.Text = "Edit"
        mn_edit.Enabled = True
        main.tabcontrol.TabPages.Remove(tabpagename)
        rowindex = 0
    End Sub

    '----------------- menu
    Private Sub mn_tambah_Click(sender As Object, e As EventArgs) Handles mn_tambah.Click
        'loadCBGudang()

        If mn_tambah.Text = "Baru" Then
            clearAll()
            disableAllSwitch(False)
            mn_save.Enabled = True
            mn_edit.Enabled = False
            cb_gudang.Focus()
            mn_tambah.Text = "Batal"
        Else
            If MessageBox.Show("Batalkan Perubahan?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            Else
                clearAll()
                disableAllSwitch(True)
                mn_save.Enabled = False
                mn_edit.Enabled = True
                mn_tambah.Text = "Baru"
            End If
        End If
    End Sub

    Private Sub mn_edit_Click(sender As Object, e As EventArgs) Handles mn_edit.Click
        If mn_edit.Text = "Edit" And in_kode.Text <> Nothing Then
            in_kode.Text = dgv_list.Rows(rowindex).Cells("kode").Value
            Try
                loadData(in_kode.Text)
                dgv_barang.Rows.Clear()
                loadDataBrg(in_kode.Text)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            disableAllSwitch(False)
            cb_gudang.Focus()
            sender.Text = "Batal Edit"
            mn_tambah.Enabled = False
            mn_save.Enabled = True
        ElseIf mn_edit.Text = "Batal Edit" Then
            If MessageBox.Show("Batalkan Perubahan?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            Else
                disableAllSwitch(True)
                loadData(in_kode.Text)
                dgv_barang.Rows.Clear()
                loadDataBrg(in_kode.Text)
                mn_edit.Text = "Edit"
                mn_tambah.Enabled = True
                mn_save.Enabled = False
            End If
        End If
    End Sub

    Private Sub mn_hapus_Click(sender As Object, e As EventArgs) Handles mn_hapus.Click
        MessageBox.Show("Under Construction")
    End Sub

    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        If MessageBox.Show("Simpan Data?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        Else
            saveData()
        End If
    End Sub

    Private Sub mn_proses_Click(sender As Object, e As EventArgs) Handles mn_proses.Click
        If in_kode.Text <> Nothing And statusop <> 2 Then
            If MessageBox.Show("Proses Stock Opname No." & in_kode.Text & "?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                Dim querycheck As Boolean = False
                Dim queryArr As New List(Of String)
                queryArr.Add("UPDATE data_barang_stok_opname SET faktur_status=2, faktur_tgl_proses=CURDATE(), faktur_upd_alias='" & loggeduser.user_id & "', faktur_upd_date=NOW() WHERE faktur_bukti='" & in_kode.Text & "'")
                For Each rows As DataGridViewRow In dgv_barang.Rows
                    Dim kodestock As String
                    kodestock = cb_gudang.SelectedValue & "-" & rows.Cells("kode").Value & "-" & date_tgl_beli.Value.ToString("yyMM")
                    queryArr.Add("UPDATE data_stok_awal SET stock_fisik=" & rows.Cells("qty_fis").Value & " WHERE stock_kode='" & kodestock & "'")

                    'TODO : WRITE LOG
                Next

                op_con()
                querycheck = startTrans(queryArr)

                If querycheck = False Then
                    MessageBox.Show("Data tidak dapat tersimpan")
                    Exit Sub
                Else
                    MessageBox.Show("Data tersimpan")
                    statusop = 1
                    frmstockop.in_cari.Clear()
                    populateDGVUserCon("stockop", "", frmstockop.dgv_list)
                    mn_edit.Enabled = False
                    mn_proses.Enabled = False
                    mn_edit.Text = "Edit"
                    mn_tambah.Text = "Tambah"
                    disableAllSwitch(True)
                    mn_save.Enabled = False
                    mn_tambah.Enabled = True
                End If

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub mn_refresh_Click(sender As Object, e As EventArgs) Handles mn_refresh.Click
        in_cari.Clear()
        searchData("")
    End Sub

    Private Sub mn_cari_Click(sender As Object, e As EventArgs) Handles mn_cari.Click
        in_cari.Focus()
    End Sub

    'cari
    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            searchData(in_cari.Text)
        End If
    End Sub

    'dgv list
    Private Sub dgv_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellClick
        If e.RowIndex >= 0 Then
            rowindex = e.RowIndex
            listToDetail()
        End If
    End Sub

    Private Sub dgv_list_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.RowEnter
        If e.RowIndex >= 0 Then
            rowindex = e.RowIndex
        End If
    End Sub

    Private Sub dgv_list_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_list.KeyDown
        If e.KeyCode = Keys.Enter And rowindex >= 0 Then
            listToDetail()
        End If
    End Sub

    'input
    Private Sub date_tgl_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyDown
        keyshortenter(cb_gudang, e)
    End Sub

    Private Sub cb_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_gudang.KeyDown
        If e.KeyCode = Keys.Enter Then
            keyshortenter(in_barang, e)
        ElseIf e.KeyCode = Keys.F1 Then
            bt_gudang_list.PerformClick()
        End If
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
            in_barang.Focus()
        End Using
    End Sub

    '---------------pop up list barang & input barang
    Private Sub in_barang_Enter(sender As Object, e As EventArgs) Handles in_barang_nm.Enter, in_barang.Enter
        If mn_save.Enabled = True Then
            popPnl_barang.Location = New Point(in_barang.Left, in_barang.Top + in_barang.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
                loadDataBRGPopup()
            End If
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
        If e.RowIndex >= 0 Then
            rowindexlist = e.RowIndex
            in_barang.Text = dgv_listbarang.Rows(rowindexlist).Cells("brg_kode").Value
            setBarang(in_barang.Text)
            in_qty2.Focus()
        End If
    End Sub

    Private Sub dgv_listbarang_Cellenter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellEnter
        If e.RowIndex >= 0 Then
            rowindexlist = e.RowIndex
        End If
    End Sub

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            in_barang.Text = dgv_listbarang.Rows(rowindexlist).Cells(0).Value
            setBarang(in_barang.Text)
            in_qty2.Focus()
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.keyChar) Then
            in_barang.Text += e.KeyChar
            e.Handled = True
            in_barang.Focus()
        End If
    End Sub

    Private Sub in_barang_TextChanged(sender As Object, e As EventArgs) Handles in_barang.TextChanged
        If in_barang.Text = "" Then
            clearTextBarang()
        End If
        If popPnl_barang.Visible = True Then
            loadDataBRGPopup()
        End If
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        clearTextBarang()
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    If Trim(in_barang.Text) <> Nothing Then
                        .in_cari.Text = in_barang.Text
                    End If
                    .returnkode = in_barang.Text
                    .query = "SELECT barang_nama as nama, barang_kode as kode, gudang_nama as gudang FROM data_barang_master INNER JOIN data_stok_awal on stock_barang=barang_kode INNER JOIN data_barang_gudang ON stock_gudang=gudang_kode WHERE stock_gudang='" & cb_gudang.SelectedValue & "'"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%' OR gudang LIKE '%{0}%'"
                    .type = "barangmutasi"
                    .ShowDialog()
                    in_barang.Text = .returnkode
                    in_barang.Focus()
                End With
            End Using
            in_qty1.Focus()
            Exit Sub
        ElseIf e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                rowindexlist = 0
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True Then
                rowindexlist = 0
                dgv_listbarang.Focus()
            Else
                keyshortenter(in_qty2, e)
            End If
        End If
    End Sub

    Private Sub linkLbl_searchbarang_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLbl_searchbarang.LinkClicked
        popPnl_barang.Visible = False
        Using search As New fr_search_dialog
            With search
                If Trim(in_barang.Text) <> Nothing Then
                    .in_cari.Text = in_barang.Text
                End If
                .returnkode = in_barang.Text
                .query = "SELECT barang_nama as nama, barang_kode as kode, gudang_nama as gudang FROM data_barang_master INNER JOIN data_stok_awal on stock_barang=barang_kode INNER JOIN data_barang_gudang ON stock_gudang=gudang_kode WHERE stock_gudang='" & cb_gudang.SelectedValue & "'"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%' OR gudang LIKE '%{0}%'"
                .type = "barangmutasi"
                .ShowDialog()
                in_barang.Text = .returnkode
            End With
        End Using
        If Trim(in_barang.Text) <> Nothing Then
            setBarang(Trim(in_barang.Text))
        End If
        in_qty2.Focus()
        Exit Sub
    End Sub

    'numeric input
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty2.Enter
        Console.WriteLine(sender.Name & sender.Value)
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty2.Leave
        numericLostFocus(sender)
    End Sub

    Private Sub in_qty2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty2.KeyDown
        keyshortenter(in_ket_brg, e)
    End Sub

    Private Sub in_ket_brg_KeyDown(sender As Object, e As KeyEventArgs) Handles in_ket_brg.KeyDown
        keyshortenter(bt_tbbarang, e)
    End Sub

    'dgv barang
    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        textToDGV()
    End Sub

    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        If e.RowIndex >= 0 Then
            rowindexbarang = e.RowIndex
            dgvToTxt()
            dgv_barang.Rows.RemoveAt(rowindexbarang)
        End If
    End Sub
End Class
