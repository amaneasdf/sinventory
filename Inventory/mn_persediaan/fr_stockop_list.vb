Public Class fr_stockop_list
    Public tabpagename As TabPage
    Private rowindex As Integer = 0
    Private rowindexlist As Integer = 0
    Private rowindexbarang As Integer = 0
    Private tblStatus As String = 0
    Private popupstate As String = "gudang"

    Public Sub setpage(page As TabPage)
        tabpagename = page
        Console.WriteLine("pg" & page.Name.ToString)
        Console.WriteLine("pgset" & tabpagename.Name.ToString)
    End Sub

    Public Sub performRefresh()
        in_cari.Clear()
        searchData("")
        in_countdata.Text = dgv_list.Rows.Count
        With date_tgl_beli
            .MinDate = selectperiode.tglawal
            .MaxDate = selectperiode.tglakhir
            If selectperiode.tglakhir >= Today Then
                .Value = Today
            Else
                .Value = selectperiode.tglakhir
            End If
        End With
    End Sub

    Private Sub loadData(kode As String)
        Dim q As String = "SELECT faktur_bukti, faktur_tanggal, faktur_gudang, gudang_nama, faktur_status, faktur_reg_alias, faktur_reg_date, " _
                         & "faktur_upd_date, faktur_upd_alias FROM data_stok_opname LEFT JOIN data_barang_gudang ON gudang_kode=faktur_gudang " _
                         & "WHERE faktur_bukti='{0}'"
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            in_kode.Text = rd.Item("faktur_bukti")
            date_tgl_beli.Value = rd.Item("faktur_tanggal")
            date_tgl_beli_r.Text = date_tgl_beli.Value.ToLongDateString
            in_gudang.Text = rd.Item("faktur_gudang")
            in_gudang_n.Text = rd.Item("gudang_nama")
            tblStatus = rd.Item("faktur_status")
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

        If tblStatus = 1 Then
            mn_edit.Enabled = True
            mn_proses.Enabled = True
        Else
            mn_edit.Enabled = False
            mn_proses.Enabled = False
        End If
    End Sub

    Private Sub loadDataBrg(kode As String)
        Dim dt As New DataTable
        Dim q As String = "SELECT trans_barang, barang_nama, trans_qty_sys, trans_satuan, trans_qty_fisik, trans_keterangan " _
                          & "FROM data_stok_opname_trans LEFT JOIN data_barang_master ON trans_barang=barang_kode " _
                          & "WHERE trans_status=1 AND trans_faktur='{0}'"
        dt = getDataTablefromDB(String.Format(q, kode))
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

    Private Sub setStatus()
        Select Case tblStatus
            Case 0
                'in_status.Text = "Non-Aktif"
            Case 1
                'in_status.Text = "Aktif"
            Case 9
                'in_status.Text = "Delete"
            Case Else
                Exit Sub
        End Select
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Dim autoco As New AutoCompleteStringCollection
        Select Case tipe
            Case "barang"
                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama', getSisaStock('{0}',barang_kode,'{1}') as 'SisaStok', " _
                    & "getHPP(barang_kode) as 'HPP', barang_satuan_kecil " _
                    & "FROM data_stok_awal LEFT JOIN data_barang_master ON stock_barang=barang_kode " _
                    & "WHERE stock_periode='{0}' AND stock_gudang='{1}' " _
                    & "AND barang_nama LIKE '{2}%'"
                q = String.Format(q, selectperiode.id, in_gudang.Text, "{0}")
            Case "gudang"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang WHERE gudang_status=1 " _
                    & "AND gudang_nama LIKE '{0}%'"
            Case Else
                Exit Sub
        End Select

        dt = getDataTablefromDB(String.Format(q, param))

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 135
            .Columns(1).Width = 200
            If tipe = "barang" Then
                .Columns(2).DefaultCellStyle = dgvstyle_commathousand
                .Columns(3).DefaultCellStyle = dgvstyle_currency
                .Columns(4).Visible = False
            End If
        End With
    End Sub

    'OPEN SEARCH WINDOW
    Private Sub doSearch()

    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "barang"
                    in_barang.Text = .Cells(0).Value
                    in_barang_nm.Text = .Cells(1).Value
                    in_qty1.Text = commaThousand(.Cells(2).Value)
                    in_sat1.Text = .Cells(4).Value
                    in_sat2.Text = in_sat1.Text
                    in_qty2.Focus()
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    in_barang.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
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

        in_gudang_n.ReadOnly = True
        Me.Cursor = Cursors.Default

        in_barang.Focus()
    End Sub

    Private Sub dgvToTxt()
        With dgv_barang.SelectedRows.Item(0)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty1.Text = .Cells("qty_sys").Value
            in_sat1.Text = .Cells("sat_sys").Value
            in_qty2.Value = .Cells("qty_fis").Value
            in_sat2.Text = .Cells("sat_fis").Value
            in_ket_brg.Text = .Cells("ket").Value
        End With
        in_barang.Focus()
        If dgv_barang.RowCount = 0 Then
            in_gudang_n.ReadOnly = False
        Else
            in_gudang_n.ReadOnly = True
        End If
    End Sub

    Private Sub saveData()
        Dim querycheck As String = False
        Dim queryArr As New List(Of String)
        Dim datafaktur, dataBrg As String()
        Dim data, data2 As String()
        Dim q As String = ""
        Dim q2 As String = "INSERT INTO data_stok_opname_trans SET trans_faktur='{0}',{1} ON DUPLICATE KEY UPDATE {1}"
        Dim q3 As String = "DELETE FROM data_stok_opname_trans WHERE trans_faktur='{0}' AND trans_barang NOT IN({1})"

        Me.Cursor = Cursors.WaitCursor

        op_con()
        'GENERATE KODE
        If in_kode.Text = Nothing Then
            Dim st As Integer = 1
            readcommd("SELECT RIGHT(faktur_bukti,3) FROM data_stok_opname WHERE SUBSTRING(faktur_bukti,3,8)='" & date_tgl_beli.Value.ToString("yyyyMMdd") & "' " _
                       & "AND faktur_bukti LIKE 'OP%' ORDER BY faktur_bukti DESC LIMIT 1")
            If rd.HasRows Then
                st = CInt(rd.Item(0)) + 1
            End If
            rd.Close()
            in_kode.Text = "OP" & date_tgl_beli.Value.ToString("yyyyMMdd") & st.ToString("D3")
        ElseIf in_kode.Text <> Nothing And mn_tambah.Text = "Batal" Then
            If checkdata("data_stok_opname", "'" & in_kode.Text & "'", "faktur_bukti") = True Then
                MessageBox.Show("Nomor faktur " & in_kode.Text & " sudah pernah diinputkan", "Stok Opname", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                in_kode.Focus()
                Exit Sub
                'If MessageBox.Show("Update data faktur " & in_faktur.Text & "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                '    Exit Sub
                'End If
            End If
        End If


        '==========================================================================================================================
        'INSERT HEADER
        datafaktur = {
                "faktur_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_gudang='" & in_gudang.Text & "'",
                "faktur_status='1'"
                }
        q = "INSERT INTO data_stok_opname SET faktur_bukti='{0}',{1},faktur_reg_date=NOW(), faktur_reg_alias='{2}' " _
            & "ON DUPLICATE KEY UPDATE {1},faktur_upd_date=NOW(),faktur_upd_alias='{2}'"
        queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", datafaktur), loggeduser.user_id))
        '==========================================================================================================================

        '==========================================================================================================================
        'INSERT BARANG
        Dim x As New List(Of String)
        Dim qty As New List(Of Integer)

        '==========================================================================================================================
        q = "UPDATE data_stok_opname_trans SET trans_status=9 WHERE trans_faktur='{0}'"
        queryArr.Add(String.Format(q, in_kode.Text))

        q = "UPDATE data_stok_kartustok SET trans_status=9 WHERE trans_faktur='{0}'"
        queryArr.Add(String.Format(q, in_kode.Text))
        '==========================================================================================================================

        '==========================================================================================================================
        For Each rows As DataGridViewRow In dgv_barang.Rows
            dataBrg = {
                "trans_barang='" & rows.Cells(0).Value & "'",
                "trans_qty_sys=" & rows.Cells("qty_sys").Value,
                "trans_qty_fisik=" & rows.Cells("qty_fis").Value,
                "trans_satuan='" & rows.Cells("sat_sys").Value & "'",
                "trans_keterangan='" & rows.Cells("ket").Value & "'",
                "trans_status=1"
                }
            q = "INSERT INTO data_stok_opname_trans SET trans_faktur='{0}',{1} ON DUPLICATE KEY UPDATE {1}"
            queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", dataBrg)))

            x.Add("'" & rows.Cells(0).Value & "'")
            qty.Add(rows.Cells("qty_fis").Value - rows.Cells("qty_sys").Value)
        Next
        '==========================================================================================================================

        '==========================================================================================================================
        'TODO : WRITE KARTU STOCK
        Dim q5 As String = "INSERT INTO data_stok_kartustok({0}) SELECT {1} FROM data_stok_kartustok WHERE trans_stock='{2}' ON DUPLICATE KEY UPDATE {3}"
        Dim x_kodestok = New List(Of String)
        data = {
            "trans_stock", "trans_index", "trans_jenis", "trans_faktur", "trans_tgl",
            "trans_ket", "trans_qty", "trans_reg_alias", "trans_reg_date", "trans_status"
            }
        Dim i As Integer = 0
        For Each brg As String In x
            Dim kd As String = in_gudang.Text & "-" & Replace(brg, "'", "") & "-" & selectperiode.id

            data2 = {
                     "'" & kd & "'",
                     "MAX(trans_index)+1",
                     "'op'",
                     "'" & in_kode.Text & "'",
                     "'" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                     "'STOK OPNAME " & in_gudang_n.Text & "'",
                     qty.Item(i),
                     "'" & loggeduser.user_id & "'",
                     "NOW()",
                     "1"
                     }
            dataBrg = {
                "trans_tgl='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "trans_qty=" & qty.Item(i),
                "trans_upd_date=NOW()",
                "trans_upd_alias='" & loggeduser.user_id & "'",
                "trans_status=1"
                }
            queryArr.Add(String.Format(q5, String.Join(",", data), String.Join(",", data2), kd, String.Join(",", dataBrg)))

            x_kodestok.Add("'" & kd & "'")
            i += 1
        Next
        '==========================================================================================================================
        '==========================================================================================================================


        '==========================================================================================================================
        'BEGIN TRANSACTION
        querycheck = startTrans(queryArr)
        '==========================================================================================================================

        Me.Cursor = Cursors.Default

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Exit Sub
        Else
            'TODO: WRITE LOG AKTIVITAS

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
        'For Each x As NumericUpDown In {in_qty2}
        '    x.Value = 0
        'Next
        For Each x As TextBox In {in_barang, in_sat1, in_sat2, in_ket_brg, in_qty1}
            x.Clear()
        Next
    End Sub

    Private Sub clearInputBarang()
        clearTextBarang()
        in_barang_nm.Clear()
        in_qty2.Value = 0
    End Sub

    Private Sub clearAll()
        For Each x As TextBox In {in_kode, in_barang, in_barang_nm, in_sat1, in_sat2, txtRegAlias, txtRegdate, txtUpdAlias, txtUpdDate,
                                  in_gudang, in_gudang_n, date_tgl_beli_r, in_ket_brg, in_qty1}
            x.Clear()
        Next
        For Each x As NumericUpDown In {in_qty2}
            x.Value = 0
        Next
        If selectperiode.tglakhir >= Today Then
            date_tgl_beli.Value = Today
        Else
            date_tgl_beli.Value = selectperiode.tglakhir
        End If
        dgv_barang.Rows.Clear()
    End Sub

    Private Sub disableAllSwitch(switch As Boolean)
        For Each x As TextBox In {in_barang_nm, in_ket_brg, in_gudang_n}
            x.ReadOnly = switch
        Next
        For Each x As NumericUpDown In {in_qty2}
            x.ReadOnly = switch
        Next
        For Each x As Button In {bt_tbbarang}
            If switch = True Then
                x.Enabled = False
            Else
                x.Enabled = True
            End If
        Next
        If switch = True Then
            date_tgl_beli.Visible = False
            dgv_barang.Enabled = False
        Else
            date_tgl_beli.Visible = True
            dgv_barang.Enabled = True
        End If

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
            in_gudang.Focus()
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
            in_gudang.Focus()
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
        If in_gudang.Text = Nothing Then
            MessageBox.Show("Gudang belum di input")
            in_gudang_n.Focus()
            Exit Sub
        End If
        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum di input")
            in_barang.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan Data?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            saveData()
        End If
    End Sub

    Private Sub mn_proses_Click(sender As Object, e As EventArgs) Handles mn_proses.Click
        'If in_kode.Text <> Nothing And statusop <> 2 Then
        '    If MessageBox.Show("Proses Stock Opname No." & in_kode.Text & "?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.Yes Then
        '        Me.Cursor = Cursors.WaitCursor
        '        Dim querycheck As Boolean = False
        '        Dim queryArr As New List(Of String)
        '        queryArr.Add("UPDATE data_barang_stok_opname SET faktur_status=2, faktur_tgl_proses=CURDATE(), faktur_upd_alias='" & loggeduser.user_id & "', faktur_upd_date=NOW() WHERE faktur_bukti='" & in_kode.Text & "'")
        '        For Each rows As DataGridViewRow In dgv_barang.Rows
        '            Dim kodestock As String
        '            kodestock = cb_gudang.SelectedValue & "-" & rows.Cells("kode").Value & "-" & date_tgl_beli.Value.ToString("yyMM")
        '            queryArr.Add("UPDATE data_stok_awal SET stock_fisik=" & rows.Cells("qty_fis").Value & " WHERE stock_kode='" & kodestock & "'")

        '            'TODO : WRITE LOG
        '        Next

        '        op_con()
        '        querycheck = startTrans(queryArr)

        '        If querycheck = False Then
        '            MessageBox.Show("Data tidak dapat tersimpan")
        '            Exit Sub
        '        Else
        '            MessageBox.Show("Data tersimpan")
        '            statusop = 1
        '            frmstockop.in_cari.Clear()
        '            populateDGVUserCon("stockop", "", frmstockop.dgv_list)
        '            mn_edit.Enabled = False
        '            mn_proses.Enabled = False
        '            mn_edit.Text = "Edit"
        '            mn_tambah.Text = "Tambah"
        '            disableAllSwitch(True)
        '            mn_save.Enabled = False
        '            mn_tambah.Enabled = True
        '        End If

        '        Me.Cursor = Cursors.Default
        '    End If
        'End If
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
    'numeric input
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty2.Enter
        Console.WriteLine(sender.Name & sender.Value)
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty2.Leave
        numericLostFocus(sender, "N0")
    End Sub

    'HEADR
    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(date_tgl_beli, e)
    End Sub

    Private Sub date_tgl_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyDown
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub date_tgl_beli_ValueChanged(sender As Object, e As EventArgs) Handles date_tgl_beli.ValueChanged
        date_tgl_beli_r.Text = date_tgl_beli.Value.ToLongDateString
    End Sub

    '------------- POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_gudang_n.Focused Or in_barang_nm.Focused Then
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
                Case "gudang"
                    x = in_gudang_n
                Case "barang"
                    x = in_barang_nm
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

    'gudang awal
    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_gudang_n_Enter(sender As Object, e As EventArgs) Handles in_gudang_n.Enter
        If mn_save.Enabled = True Then
            popPnl_barang.Location = New Point(in_gudang_n.Left, in_gudang_n.Top + in_gudang_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            popupstate = "gudang"
            loadDataBRGPopup("gudang", in_gudang_n.Text)
        End If
    End Sub

    Private Sub in_gudang_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(in_barang_nm, e)
        Else
            If popPnl_barang.Visible = False And in_gudang_n.ReadOnly = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("gudang", in_gudang_n.Text)
        End If
    End Sub

    Private Sub in_gudang_n_TextChanged(sender As Object, e As EventArgs) Handles in_gudang_n.TextChanged
        If in_gudang_n.Text = "" Then
            in_gudang.Clear()
            clearInputBarang()
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_gudang_n.Leave, in_barang_nm.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    '---------------input barang
    Private Sub in_barang_Enter(sender As Object, e As EventArgs) Handles in_barang_nm.Enter
        If mn_save.Enabled = True Then
            popPnl_barang.Location = New Point(in_barang_nm.Left, in_barang_nm.Top + in_barang_nm.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
                popupstate = "barang"
                loadDataBRGPopup("barang", in_barang_nm.Text)
            End If
        End If
    End Sub

    Private Sub in_barang_nm_KeyUp(sender As Object, e As KeyEventArgs) Handles in_barang_nm.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(in_qty2, e)
        Else
            If popPnl_barang.Visible = False And in_barang_nm.ReadOnly = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("barang", in_barang_nm.Text)
        End If
    End Sub

    Private Sub in_barang_nm_TextChanged(sender As Object, e As EventArgs) Handles in_barang_nm.TextChanged
        If in_barang_nm.Text = "" Then
            clearTextBarang()
        End If
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

    Private Sub fr_stok_mutasi_list_Click(sender As Object, e As EventArgs) Handles Me.Click, SplitContainer1.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub
End Class
