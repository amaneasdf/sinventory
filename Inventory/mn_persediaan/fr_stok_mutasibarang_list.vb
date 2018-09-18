﻿Public Class fr_stok_mutasibarang_list
    Public tabpagename As TabPage
    Private rowindex As Integer = 0
    Private rowindexlist As Integer = 0
    Private rowindexbarang As Integer = 0
    Private isisat_t As Integer = 0
    Private isisat_b As Integer = 0

    Public Sub setpage(page As TabPage)
        tabpagename = page
        Console.WriteLine("pg" & page.Name.ToString)
        Console.WriteLine("pgset" & tabpagename.Name.ToString)
    End Sub

    Public Sub performRefresh()
        in_cari.Clear()
        searchData("")
        in_countdata.Text = dgv_list.Rows.Count
    End Sub

    Private Sub loadData(kode As String)
        readcommd("SELECT * FROM data_barang_mutasi WHERE faktur_kode ='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = rd.Item("faktur_kode")
            date_tgl_beli.Value = rd.Item("faktur_tanggal")
            date_tgl_beli_r.Text = date_tgl_beli.Value.ToLongDateString
            cb_gudang.SelectedValue = rd.Item("faktur_gudang")
            in_gudang_r.Text = cb_gudang.Text
            in_ket.Text = rd.Item("faktur_ket")
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

    Private Sub loadBrg(kode As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang_asal, a.barang_nama, trans_qty_asal, trans_sat_asal, trans_barang_tujuan, b.barang_nama, trans_qty_tujuan, trans_sat_tujuan, trans_hpp FROM data_barang_mutasi_trans INNER JOIN data_barang_master a ON a.barang_kode=trans_barang_asal INNER JOIN data_barang_master b ON b.barang_kode=trans_barang_tujuan WHERE trans_faktur='" & kode & "'")
        With dgv_barang.Rows
            For Each x As DataRow In dt.Rows
                Dim y As Integer = .Add
                With .Item(y)
                    .Cells("kode").Value = x.ItemArray(0)
                    .Cells("nama").Value = x.ItemArray(1)
                    .Cells("qty_a").Value = x.ItemArray(2)
                    .Cells("sat_a").Value = x.ItemArray(3)
                    .Cells("kode_b").Value = x.ItemArray(4)
                    .Cells("nama_b").Value = x.ItemArray(5)
                    .Cells("qty_b").Value = x.ItemArray(6)
                    .Cells("sat_b").Value = x.ItemArray(7)
                    .Cells("hpp").Value = x.ItemArray(8)
                End With
            Next
        End With
    End Sub

    Public Sub loadCbGudang()
        With cb_gudang
            .DataSource = getDataTablefromDB("SELECT gudang_kode, gudang_nama FROM data_barang_gudang")
            .DisplayMember = "gudang_nama"
            .ValueMember = "gudang_kode"
            .SelectedIndex = -1
        End With
        dgv_barang.Columns("hpp").DefaultCellStyle = dgvstyle_currency
    End Sub

    Private Sub setBarang(type As String, Optional kode As String = Nothing, Optional nama As String = Nothing)
        op_con()
        If kode = Nothing Then
            readcommd("SELECT barang_kode FROM data_barang_master WHERE barang_nama LIKE '" & nama & "%' LIMIT 1")
            If rd.HasRows Then
                kode = rd.Item(0)
                rd.Close()
            Else
                rd.Close()
                Exit Sub
            End If
        End If

        readcommd("SELECT barang_kode, barang_nama, barang_satuan_kecil, getHPP(barang_kode) as hpp FROM data_barang_master WHERE barang_kode='" & kode & "' LIMIT 1")
        If rd.HasRows Then
            Select Case type
                Case "asal"
                    in_barang.Text = rd.Item("barang_kode")
                    in_barang_nm.Text = rd.Item("barang_nama")
                    in_sat1.Text = rd.Item("barang_satuan_kecil")
                Case "tujuan"
                    in_barang2.Text = rd.Item("barang_kode")
                    in_barang_nm2.Text = rd.Item("barang_nama")
                    in_sat2.Text = rd.Item("barang_satuan_kecil")
                    in_hpp.Text = commaThousand(rd.Item("hpp"))
                Case Else
                    Exit Select
            End Select
        End If
        rd.Close()
    End Sub

    Private Sub loadDataBRGPopup(type As String)
        Dim q As String = "SELECT barang_kode, barang_nama FROM data_barang_master INNER JOIN data_stok_awal ON barang_kode=stock_barang WHERE (barang_nama LIKE '{0}%' AND stock_gudang='{1}'{2}) AND stock_periode='" & selectedperiode.ToString("yyyy-MM") & "' GROUP BY barang_kode LIMIT 100"
        With dgv_listbarang
            Select Case type
                Case "asal"
                    .DataSource = getDataTablefromDB(String.Format(q, in_barang_nm.Text, cb_gudang.SelectedValue, ""))
                Case "tujuan"
                    .DataSource = getDataTablefromDB(String.Format(q, in_barang_nm2.Text, cb_gudang.SelectedValue, " AND barang_kode <> '" & in_barang.Text & "'"))
            End Select
        End With
    End Sub

    Private Sub searchData(param As String)
        If mn_save.Enabled = True Then
            If MessageBox.Show("Batalkan Perubahan?", "Mutasi Barang", MessageBoxButtons.YesNo) = DialogResult.No Then
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
        populateDGVUserCon("mutasistok", param, frmmutasistok.dgv_list)
    End Sub

    Private Sub listToDetail()
        If mn_save.Enabled = True Then
            If MessageBox.Show("Batalkan Perubahan?", "Mutasi Barang", MessageBoxButtons.YesNo) = DialogResult.No Then
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
            loadBrg(in_kode.Text)
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
        If in_qty1.Value = 0 Then
            in_qty1.Focus()
            Exit Sub
        End If
        If in_barang_nm2.Text = Nothing Then
            in_barang2.Focus()
            Exit Sub
        End If
        If in_qty2.Value = 0 Then
            in_qty2.Focus()
            Exit Sub
        End If
        If in_barang_nm.Text = in_barang_nm2.Text Then
            MessageBox.Show("Barang asal dan tujuan sama")
            in_barang.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim check As Boolean = False
        If dgv_barang.RowCount > 0 Then
            For Each rows As DataGridViewRow In dgv_barang.Rows
                If rows.Cells("kode").Value = in_barang.Text And rows.Cells("kode_b").Value = in_barang2.Text Then
                    If MessageBox.Show("Barang yang sama sudah diinputkan ke dalam list, tambahkan qty pada barang tersebut?", "Mutasi Barang", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        rows.Cells("qty_a").Value += in_qty1.Value
                        rows.Cells("qty_b").Value += in_qty2.Value
                        Me.Cursor = Cursors.Default
                        check = True
                        Exit For
                    Else
                        Me.Cursor = Cursors.Default
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
                    .Cells("qty_a").Value = in_qty1.Value
                    .Cells("sat_a").Value = in_sat1.Text
                    .Cells("kode_b").Value = in_barang2.Text
                    .Cells("nama_b").Value = in_barang_nm2.Text
                    .Cells("qty_b").Value = in_qty2.Value
                    .Cells("sat_b").Value = in_sat2.Text
                    .Cells("hpp").Value = removeCommaThousand(in_hpp.Text)
                End With
            End With
        End If

        Me.Cursor = Cursors.Default

        clearInputBarang()
        in_barang.Focus()
    End Sub


    Private Sub dgvToTxt(rowindex As Integer)
        With dgv_barang.Rows(rowindex)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty1.Value = .Cells("qty_a").Value
            in_sat1.Text = .Cells("sat_a").Value
            in_barang2.Text = .Cells("kode_b").Value
            in_barang_nm2.Text = .Cells("nama_b").Value
            in_qty2.Value = .Cells("qty_b").Value
            in_sat2.Text = .Cells("sat_b").Value
            in_hpp.Text = .Cells("hpp").Value
        End With
        in_barang.Focus()
    End Sub

    Private Sub saveData()
        If cb_gudang.SelectedValue = Nothing Then
            MessageBox.Show("Gudang asal belum dimasukkan")
            cb_gudang.Focus()
            Exit Sub
        End If
        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum dimasukkan")
            in_barang.Focus()
            Exit Sub
        End If

        Dim querycheck As String = False
        Dim queryArr As New List(Of String)
        Dim datafaktur, dataBrg As String()
        Dim data, data2 As String()
        Dim q1 As String = "INSERT INTO data_barang_mutasi SET faktur_kode='{0}',{1},{2} ON DUPLICATE KEY UPDATE {1},{3}"
        Dim q2 As String = "INSERT INTO data_barang_mutasi_trans SET trans_faktur='{0}',{1} ON DUPLICATE KEY UPDATE {1}"
        Dim q3 As String = "DELETE FROM data_barang_mutasi_trans WHERE trans_faktur='{0}' AND trans_barang_asal NOT IN({1}) AND trans_barang_tujuan NOT IN({2})"

        Me.Cursor = Cursors.WaitCursor

        op_con()
        'GENERATE KODE
        If in_kode.Text = Nothing Then
            Dim x As Integer = 1
            readcommd("SELECT RIGHT(faktur_kode,4) FROM data_barang_mutasi WHERE SUBSTRING(faktur_kode,3,8)='" & date_tgl_beli.Value.ToString("yyyyMMdd") & "' AND faktur_kode LIKE 'MB%' ORDER BY faktur_kode DESC LIMIT 1")
            If rd.HasRows Then
                x = CInt(rd.Item(0)) + 1
            End If
            rd.Close()
            in_kode.Text = "MB" & date_tgl_beli.Value.ToString("yyyyMMdd") & x.ToString("D4")
        End If

        datafaktur = {
               "faktur_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
               "faktur_gudang='" & cb_gudang.SelectedValue & "'",
               "faktur_ket='" & in_ket.Text & "'"
               }
        data = {
            "faktur_reg_date=NOW()",
            "faktur_reg_alias='" & loggeduser.user_id & "'"
            }
        data2 = {
            "faktur_upd_date=NOW()",
            "faktur_upd_alias='" & loggeduser.user_id & "'"
            }

        'INSERT HEADER
        queryArr.Add(String.Format(q1, in_kode.Text, String.Join(",", datafaktur), String.Join(",", data), String.Join(",", data2)))

        'INSERT BARANG
        Dim x_asal, x_tujuan As New List(Of String)
        Dim qty_asal, qty_tujuan As New List(Of Integer)
        For Each rows As DataGridViewRow In dgv_barang.Rows
            data = {
                "trans_barang_asal='" & rows.Cells(0).Value & "'",
                "trans_qty_asal=" & rows.Cells("qty_a").Value,
                "trans_sat_asal='" & rows.Cells("sat_b").Value & "'",
                "trans_barang_tujuan='" & rows.Cells("kode_b").Value & "'",
                "trans_qty_tujuan=" & rows.Cells("qty_b").Value,
                "trans_sat_tujuan='" & rows.Cells("sat_b").Value & "'",
                "trans_hpp=getHPP('" & rows.Cells("kode_b").Value & "')"
                }

            queryArr.Add(String.Format(q2, in_kode.Text, String.Join(",", data)))
            x_asal.Add("'" & rows.Cells(0).Value & "'")
            qty_asal.Add(rows.Cells("qty_a").Value)
            x_tujuan.Add("'" & rows.Cells("kode_b").Value & "'")
            qty_tujuan.Add(rows.Cells("qty_b").Value)
        Next
        queryArr.Add(String.Format(q3, in_kode.Text, String.Join(",", x_asal), String.Join(",", x_tujuan)))

        'TODO:WRITE KARTU STOCK
        Dim q4 As String = "SELECT stock_kode FROM data_stok_awal WHERE stock_gudang='{0}' AND stock_barang={1} AND stock_periode='{2}'"
        Dim q5 As String = "INSERT INTO data_stok_kartustok({0}) SELECT {1} FROM data_stok_kartustok WHERE trans_stock='{2}' ON DUPLICATE KEY UPDATE {3}"
        Dim q6 As String = "DELETE FROM data_stok_kartustok WHERE trans_faktur='{0}' AND trans_stock NOT IN({1})"
        Dim x_kodestok = New List(Of String)
        data = {
            "trans_stock", "trans_index", "trans_jenis", "trans_faktur",
            "trans_ket", "trans_qty", "trans_reg_alias", "trans_reg_date"
            }
        Dim i As Integer = 0
        For Each asal As String In x_asal
            Dim x As String
            readcommd(String.Format(q4, cb_gudang.SelectedValue, asal, date_tgl_beli.Value.ToString("yyyy-MM")))
            If rd.HasRows Then
                x = rd.Item(0)
            End If
            rd.Close()

            If x <> Nothing Then
                data2 = {
                    "'" & x & "'",
                    "MAX(trans_index)+1",
                    "'mb'",
                    "'" & in_kode.Text & "'",
                    "'MUTASI " & Replace(asal, "'", "") & " -> " & Replace(x_tujuan.Item(i), "'", "") & "'",
                    qty_asal.Item(i) * -1,
                    "'" & loggeduser.user_id & "'",
                    "NOW()"
                    }
                dataBrg = {
                    "trans_qty=" & qty_asal.Item(i) * -1,
                    "trans_upd_date=NOW()",
                    "trans_upd_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add(String.Format(q5, String.Join(",", data), String.Join(",", data2), x, String.Join(",", dataBrg)))
            End If
            x_kodestok.Add("'" & x & "'")
            i += 1
        Next
        i = 0
        For Each tujuan As String In x_tujuan
            Dim x As String
            readcommd(String.Format(q4, cb_gudang.SelectedValue, tujuan, date_tgl_beli.Value.ToString("yyyy-MM")))
            If rd.HasRows Then
                x = rd.Item(0)
            End If
            rd.Close()

            If x <> Nothing Then
                data2 = {
                    "'" & x & "'",
                    "MAX(trans_index)+1",
                    "'mb'",
                    "'" & in_kode.Text & "'",
                    "'MUTASI " & Replace(x_asal.Item(i), "'", "") & " -> " & Replace(tujuan, "'", "") & "'",
                    qty_tujuan.Item(i),
                    "'" & loggeduser.user_id & "'",
                    "NOW()"
                    }
                dataBrg = {
                    "trans_qty=" & qty_tujuan.Item(i),
                    "trans_upd_date=NOW()",
                    "trans_upd_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add(String.Format(q5, String.Join(",", data), String.Join(",", data2), x, String.Join(",", dataBrg)))
            End If
            x_kodestok.Add("'" & x & "'")
            i += 1
        Next
        'TODO : DELETE REMOVED ITEM FROM KARTU STOK
        queryArr.Add(String.Format(q6, in_kode.Text, String.Join(",", x_kodestok)))

        querycheck = startTrans(queryArr)

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            'TODO:WRITE LOG

            Me.Cursor = Cursors.Default
            MessageBox.Show("Data tersimpan")
            frmmutasistok.in_cari.Clear()
            populateDGVUserCon("mutasistok", "", frmmutasistok.dgv_list)
            mn_edit.Enabled = True
            mn_tambah.Enabled = True
            mn_edit.Text = "Edit"
            mn_tambah.Text = "Tambah"
            disableAllSwitch(True)
            mn_save.Enabled = False
        End If
    End Sub

    Private Sub clearTextBarang(type As String)
        Select Case type
            Case "asal"
                in_qty1.Value = 0
                For Each x As TextBox In {in_barang, in_sat1, in_sat2, in_hpp}
                    x.Clear()
                Next
            Case "tujuan"
                in_qty2.Value = 0
                For Each x As TextBox In {in_barang2, in_sat2, in_hpp}
                    x.Clear()
                Next
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub clearInputBarang()
        clearTextBarang("asal")
        clearTextBarang("tujuan")
        in_barang_nm.Clear()
        in_barang_nm2.Clear()
    End Sub

    Private Sub clearAll()
        For Each x As TextBox In {in_kode, in_barang, in_barang_nm, in_barang2, in_barang_nm2, in_ket, in_sat1, in_sat2, in_hpp, txtRegAlias, txtRegdate, txtUpdAlias, txtUpdDate, in_gudang_r, date_tgl_beli_r}
            x.Clear()
        Next
        For Each x As NumericUpDown In {in_qty1, in_qty2}
            x.Value = 0
        Next
        date_tgl_beli.Value = DateSerial(selectedperiode.Year, selectedperiode.Month, Today.Day)
        dgv_barang.Rows.Clear()
        cb_gudang.SelectedIndex = -1
    End Sub

    Private Sub disableAllSwitch(switch As Boolean)
        For Each x As TextBox In {in_barang, in_barang2, in_ket}
            x.ReadOnly = switch
        Next
        For Each x As NumericUpDown In {in_qty1, in_qty2}
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
            If MessageBox.Show("Batalkan Perubahan?", "Mutasi Barang", MessageBoxButtons.YesNo) = DialogResult.No Then
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
                loadBrg(in_kode.Text)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            disableAllSwitch(False)
            cb_gudang.Focus()
            sender.Text = "Batal Edit"
            mn_tambah.Enabled = False
            mn_save.Enabled = True
        ElseIf mn_edit.Text = "Batal Edit" Then
            If MessageBox.Show("Batalkan Perubahan?", "Mutasi Barang", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            Else
                disableAllSwitch(True)
                loadData(in_kode.Text)
                dgv_barang.Rows.Clear()
                loadBrg(in_kode.Text)
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
        If MessageBox.Show("Simpan Data?", "Mutasi Barang", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        Else
            saveData()
        End If
    End Sub

    Private Sub mn_refresh_Click(sender As Object, e As EventArgs) Handles mn_refresh.Click
        performRefresh()
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
            keyshortenter(in_ket, e)
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
            in_ket.Focus()
        End Using
    End Sub

    Private Sub in_ket_KeyDown(sender As Object, e As KeyEventArgs) Handles in_ket.KeyDown
        keyshortenter(in_barang_nm, e)
    End Sub

    '---------------pop up list barang & input barang
    Private Sub in_barang_Enter(sender As Object, e As EventArgs) Handles in_barang_nm.Enter
        If mn_save.Enabled = True Then
            popPnl_barang.Location = New Point(in_barang_nm.Left, in_barang_nm.Top + in_barang_nm.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
                loadDataBRGPopup("asal")
            End If
        End If
    End Sub

    Private Sub in_barang2_Enter(sender As Object, e As EventArgs) Handles in_barang_nm2.Enter
        If mn_save.Enabled = True Then
            popPnl_barang.Location = New Point(in_barang_nm2.Left, in_barang_nm2.Top + in_barang_nm2.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
                loadDataBRGPopup("tujuan")
            End If
        End If
    End Sub

    Private Sub in_barang_Leave(sender As Object, e As EventArgs) Handles in_barang_nm.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
            If Trim(in_barang_nm.Text) <> Nothing Then
                setBarang("asal", , in_barang_nm.Text)
            End If
        Else
            popPnl_barang.Visible = True
        End If

    End Sub

    Private Sub in_barang2_Leave(sender As Object, e As EventArgs) Handles in_barang_nm2.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
            If Trim(in_barang_nm2.Text) <> Nothing Then
                setBarang("tujuan", , in_barang_nm2.Text)
            End If
        Else
            popPnl_barang.Visible = True
        End If

    End Sub
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_barang_nm.Focused = True Or in_barang_nm2.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub dgv_listbarang_CellContentDBLClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellDoubleClick
        If e.RowIndex >= 0 Then
            rowindexlist = e.RowIndex
            If popPnl_barang.Location = New Point(in_barang_nm.Left, in_barang_nm.Top + in_barang_nm.Height) Then
                in_barang.Text = dgv_listbarang.Rows(rowindexlist).Cells("brg_kode").Value
                setBarang("asal", in_barang.Text)
                in_qty1.Focus()
            ElseIf popPnl_barang.Location = New Point(in_barang_nm2.Left, in_barang_nm2.Top + in_barang_nm2.Height) Then
                in_barang2.Text = dgv_listbarang.Rows(rowindexlist).Cells("brg_kode").Value
                setBarang("tujuan", in_barang2.Text)
                in_qty2.Focus()
            End If
        End If
    End Sub

    Private Sub dgv_listbarang_Cellenter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellEnter
        If e.RowIndex >= 0 Then
            rowindexlist = e.RowIndex
        End If
    End Sub

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            If popPnl_barang.Location = New Point(in_barang_nm.Left, in_barang_nm.Top + in_barang_nm.Height) Then
                in_barang.Text = dgv_listbarang.Rows(rowindexlist).Cells("brg_kode").Value
                setBarang("asal", in_barang.Text)
                in_qty1.Focus()
            ElseIf popPnl_barang.Location = New Point(in_barang_nm2.Left, in_barang_nm2.Top + in_barang_nm2.Height) Then
                in_barang2.Text = dgv_listbarang.Rows(rowindexlist).Cells("brg_kode").Value
                setBarang("tujuan", in_barang2.Text)
                in_qty2.Focus()
            End If
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.keyChar) Then
            e.Handled = True
            If popPnl_barang.Location = New Point(in_barang_nm.Left, in_barang_nm.Top + in_barang_nm.Height) Then
                in_barang_nm.Text += e.KeyChar
                in_barang_nm.Focus()
            ElseIf popPnl_barang.Location = New Point(in_barang_nm2.Left, in_barang_nm2.Top + in_barang_nm2.Height) Then
                in_barang_nm2.Text += e.KeyChar
                in_barang_nm2.Focus()
            End If
        End If
    End Sub

    Private Sub in_barang_TextChanged(sender As Object, e As EventArgs) Handles in_barang_nm.TextChanged
        If in_barang_nm.Text = "" Then
            clearTextBarang("asal")
        End If
    End Sub

    Private Sub in_barang2_TextChanged(sender As Object, e As EventArgs) Handles in_barang_nm2.TextChanged
        If in_barang_nm2.Text = "" Then
            clearTextBarang("tujuan")
        End If
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang_nm.KeyDown
        clearTextBarang("asal")
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    If Trim(in_barang_nm.Text) <> Nothing Then
                        .in_cari.Text = in_barang_nm.Text
                    End If
                    .returnkode = in_barang.Text
                    .query = "SELECT barang_nama as nama, barang_kode as kode, barang_harga_beli as hargabeli, barang_harga_jual as hargajual FROM data_barang_master LEFT JOIN data_stok_awal ON barang_kode=stock_kode WHERE stock_gudang='" & cb_gudang.SelectedValue & "' AND stock_periode='" & selectedperiode.ToString("yyyy-MM") & "' GROUP BY stock_barang"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "barang"
                    .ShowDialog()
                    in_barang.Text = .returnkode
                    setBarang("asal", in_barang.Text)
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
                keyshortenter(in_qty1, e)
            End If
        End If
    End Sub

    Private Sub in_barang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_barang_nm.KeyUp
        If popPnl_barang.Visible = True Then
            loadDataBRGPopup("asal")
        End If
    End Sub

    Private Sub in_barang2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang_nm2.KeyDown
        clearTextBarang("tujuan")
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    If Trim(in_barang_nm2.Text) <> Nothing Then
                        .in_cari.Text = in_barang_nm2.Text
                    End If
                    .returnkode = in_barang2.Text
                    .query = "SELECT barang_nama as nama, barang_kode as kode, barang_harga_beli as hargabeli, barang_harga_jual as hargajual FROM data_barang_master LEFT JOIN data_stok_awal ON barang_kode=stock_kode WHERE stock_gudang='" & cb_gudang.SelectedValue & "' AND stock_periode='" & selectedperiode.ToString("yyyy-MM") & "' GROUP BY stock_barang"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "barang"
                    .ShowDialog()
                    in_barang2.Text = .returnkode
                    setBarang("tujuan", in_barang.Text)
                End With
            End Using
            in_qty2.Focus()
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

    Private Sub in_barang2_KeyUp(sender As Object, e As KeyEventArgs) Handles in_barang_nm2.KeyUp
        If popPnl_barang.Visible = True Then
            loadDataBRGPopup("tujuan")
        End If
    End Sub

    Private Sub linkLbl_searchbarang_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLbl_searchbarang.LinkClicked
        popPnl_barang.Visible = False
        Using search As New fr_search_dialog
            With search
                .query = "SELECT barang_nama as nama, barang_kode as kode, barang_harga_beli as hargabeli, barang_harga_jual as hargajual FROM data_barang_master LEFT JOIN data_stok_awal ON barang_kode=stock_kode WHERE stock_gudang='" & cb_gudang.SelectedValue & "' AND stock_periode='" & selectedperiode.ToString("yyyy-MM") & "' GROUP BY stock_barang"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "barang"
                If popPnl_barang.Location = New Point(in_barang.Left, in_barang.Top + in_barang.Height) Then
                    If Trim(in_barang_nm.Text) <> Nothing Then
                        .in_cari.Text = in_barang_nm.Text
                    End If
                    .returnkode = in_barang.Text
                    .ShowDialog()
                    in_barang.Text = .returnkode
                ElseIf popPnl_barang.Location = New Point(in_barang2.Left, in_barang2.Top + in_barang2.Height) Then
                    If Trim(in_barang_nm2.Text) <> Nothing Then
                        .in_cari.Text = in_barang_nm2.Text
                    End If
                    .returnkode = in_barang2.Text
                    .ShowDialog()
                    in_barang2.Text = .returnkode
                End If
            End With
        End Using
        If popPnl_barang.Location = New Point(in_barang.Left, in_barang.Top + in_barang.Height) Then
            If Trim(in_barang.Text) <> Nothing Then
                setBarang("asal", Trim(in_barang.Text))
            End If
            in_qty1.Focus()
        ElseIf popPnl_barang.Location = New Point(in_barang2.Left, in_barang2.Top + in_barang2.Height) Then
            If Trim(in_barang2.Text) <> Nothing Then
                setBarang("tujuan", Trim(in_barang2.Text))
            End If
            in_qty2.Focus()
        End If
        Exit Sub
    End Sub

    'numeric input
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty1.Enter, in_qty2.Enter
        Console.WriteLine(sender.Name & sender.Value)
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty1.Leave, in_qty2.Leave
        numericLostFocus(sender)
    End Sub

    'input qty
    Private Sub in_qty1_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty1.KeyDown
        keyshortenter(in_barang_nm2, e)
    End Sub

    Private Sub in_qty2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty2.KeyDown
        keyshortenter(bt_tbbarang, e)
    End Sub

    'dgv barang
    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        textToDGV()
    End Sub

    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        If e.RowIndex >= 0 Then
            rowindexbarang = e.RowIndex
            dgvToTxt(rowindexbarang)
            dgv_barang.Rows.RemoveAt(rowindexbarang)
        End If
    End Sub

    Private Sub dgv_list_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgv_list.RowsAdded
        in_countdata.Text = dgv_list.Rows.Count
    End Sub
End Class
