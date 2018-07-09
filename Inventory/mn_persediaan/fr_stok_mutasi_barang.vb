Public Class fr_stok_mutasi_barang
    Private rowindex As Integer = 0

    Private Sub loadDataFaktur(kode As String)
        readcommd("SELECT * FROM data_barang_mutasi WHERE faktur_kode ='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = rd.Item("faktur_kode")
            date_tgl_beli.Value = rd.Item("faktur_tanggal")
            in_gudang.Text = rd.Item("faktur_gudang")
            in_keterangan.Text = rd.Item("faktur_ket")
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

        setGudang(in_gudang.Text, lbl_gudang1)
        loadDataBarang(kode)
    End Sub

    Private Sub loadDataBarang(kode As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang_asal, a.barang_nama, trans_qty_asal, trans_sat_asal, trans_barang_tujuan, b.barang_nama, trans_qty_tujuan, trans_sat_tujuan FROM data_barang_mutasi_trans INNER JOIN data_barang_master a ON a.barang_kode=trans_barang_asal INNER JOIN data_barang_master b ON b.barang_kode=trans_barang_tujuan WHERE trans_faktur='" & kode & "'")
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
                End With
            Next
        End With
    End Sub

    Private Sub setBarangTujuan(kode As String, gudang As String)
        readcommd("SELECT barang_nama, barang_satuan_kecil FROM data_barang_stok INNER JOIN data_barang_master ON barang_kode=stock_barang WHERE stock_gudang='" & gudang & "' AND stock_barang='" & kode & "'")
        If rd.HasRows Then
            in_barang2.Text = kode
            lbl_barang2.Text = rd.Item("barang_nama")
            lbl_sat2.Text = rd.Item("barang_satuan_kecil")
            in_qty2.Value = in_qty.Value
        End If
        rd.Close()
    End Sub

    Private Sub setBarang(kode As String)
        readcommd("SELECT barang_nama, barang_satuan_kecil FROM data_barang_master WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            in_barang.Text = kode
            lbl_barang.Text = rd.Item("barang_nama")
            lbl_sat.Text = rd.Item("barang_satuan_kecil")
        End If
        rd.Close()
    End Sub

    Private Sub setGudang(kode As String, labelgudang As Label)
        op_con()
        readcommd("SELECT gudang_nama FROM data_barang_gudang WHERE gudang_kode='" & kode & "'")
        If rd.HasRows Then
            labelgudang.Text = rd.Item("gudang_nama")
        End If
        rd.Close()
    End Sub

    Private Sub txtToDGV()
        If Trim(lbl_barang.Text) = Nothing Then
            in_barang.Focus()
            Exit Sub
        End If
        If Trim(lbl_barang2.Text) = Nothing Then
            in_barang2.Focus()
            Exit Sub
        End If
        'If qtytot > maxqty Then
        '    MessageBox.Show("QTY lebih besar daripada persediaan (stok: " & maxqty & ")")
        '    in_qty.Focus()
        '    Exit Sub
        'End If

        With dgv_barang.Rows
            Dim x As Integer = .Add
            With .Item(x)
                .Cells("kode").Value = in_barang.Text
                .Cells("nama").Value = lbl_barang.Text
                .Cells("qty_a").Value = in_qty.Value
                .Cells("sat_a").Value = lbl_sat.Text
                .Cells("kode_b").Value = in_barang2.Text
                .Cells("nama_b").Value = lbl_barang2.Text
                .Cells("qty_b").Value = in_qty2.Value
                .Cells("sat_b").Value = lbl_sat2.Text
            End With
        End With

        clearBarang()
        in_barang.Focus()
    End Sub

    Private Sub dgvToTxt()
        With dgv_barang.Rows(rowindex)
            in_barang.Text = .Cells("kode").Value
            lbl_barang.Text = .Cells("nama").Value
            in_qty.Value = .Cells("qty_a").Value
            lbl_sat.Text = .Cells("sat_a").Value
            in_barang2.Text = .Cells("kode_b").Value
            lbl_barang2.Text = .Cells("nama_b").Value
            in_qty2.Value = .Cells("qty_b").Value
            lbl_sat2.Text = .Cells("sat_b").Value
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

    Private Sub clearlabel(x As Label())
        For Each lbl As Label In x
            lbl.Text = ""
        Next
    End Sub

    Private Sub clearBarang()
        in_barang.Clear()
        in_barang2.Clear()
        in_qty.Value = 0
        in_qty2.Value = 0
        clearlabel({lbl_barang, lbl_barang2, lbl_sat, lbl_sat2})
    End Sub

    Private Sub clearForm()
        in_kode.Clear()
        in_gudang.Clear()
        in_keterangan.Clear()
        clearlabel({lbl_gudang1})
    End Sub

    '------------drag form
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, lbl_title.MouseDown, Panel2.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, lbl_title.MouseMove, Panel2.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, lbl_title.MouseUp, Panel2.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick, lbl_title.DoubleClick, Panel2.DoubleClick
        CenterToScreen()
    End Sub

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalreturbeli.Click
        If MessageBox.Show("Tutup Form?", "Mutasi Gudang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalreturbeli.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '------------- load
    Private Sub fr_stok_mutasi_barang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearlabel({lbl_barang, lbl_barang2, lbl_gudang1, lbl_sat, lbl_sat2})

        op_con()
        If bt_simpanreturbeli.Text = "Update" Then
            loadDataFaktur(in_kode.Text)

        End If
    End Sub

    Private Sub bt_simpanreturbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanreturbeli.Click
        If Trim(in_gudang.Text) = "" Then
            MessageBox.Show("Gudang belum di input")
            in_gudang.Focus()
            Exit Sub
        End If
        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum di input")
            in_barang.Focus()
            Exit Sub
        End If

        Dim querycheck As Boolean = False
        Dim queryArr As New List(Of String)
        Dim datafaktur As String()
        Dim dataBrg As String()

        Me.Cursor = Cursors.WaitCursor

        op_con()
        If bt_simpanreturbeli.Text = "Simpan" Then
            'generate kode
            readcommd("SELECT COUNT(faktur_tanggal) FROM data_barang_mutasi WHERE faktur_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'")
            Dim x As Integer = rd.Item(0)
            x += 1
            rd.Close()
            Dim fakturkode As String = "MB" & date_tgl_beli.Value.ToString("yyyyMMdd") & x.ToString("D4")
            in_kode.Text = fakturkode

            datafaktur = {
                "faktur_kode='" & in_kode.Text & "'",
                "faktur_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_gudang='" & in_gudang.Text & "'",
                "faktur_ket='" & in_keterangan.Text & "'",
                "faktur_reg_date=NOW()",
                "faktur_reg_alias='" & loggeduser.user_id & "'"
                }

            'INSERT
            queryArr.Add("INSERT INTO data_barang_mutasi SET " & String.Join(",", datafaktur))
        ElseIf bt_simpanreturbeli.Text = "Update" Then
            datafaktur = {
                "faktur_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_gudang='" & in_gudang.Text & "'",
                "faktur_ket='" & in_keterangan.Text & "'",
                "faktur_upd_date=NOW()",
                "faktur_upd_alias='" & loggeduser.user_id & "'"
                }

            'UPDATE
            queryArr.Add("UPDATE data_barang_mutasi SET " & String.Join(",", datafaktur) & " WHERE faktur_kode='" & in_kode.Text & "'")

            'DELETE data trans/barang
            queryArr.Add("DELETE FROM data_barang_mutasi_trans WHERE trans_faktur='" & in_kode.Text & "'")
        End If

        'INSERT/re-INSERT data trans/barang
        For Each rows As DataGridViewRow In dgv_barang.Rows
            dataBrg = {
                "trans_faktur='" & in_kode.Text & "'",
                "trans_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "trans_barang_asal='" & rows.Cells(0).Value & "'",
                "trans_qty_asal=" & rows.Cells("qty_a").Value,
                "trans_sat_asal='" & rows.Cells("sat_b").Value & "'",
                "trans_barang_tujuan='" & rows.Cells("kode_b").Value & "'",
                "trans_qty_tujuan=" & rows.Cells("qty_a").Value,
                "trans_sat_tujuan='" & rows.Cells("sat_b").Value & "'",
                "trans_reg_date=NOW()",
                "trans_reg_alias='" & loggeduser.user_id & "'"
                }

            queryArr.Add("INSERT INTO data_barang_mutasi_trans SET " & String.Join(",", dataBrg))

            'update stok
            'TODO UPDATE stok beli -> must recognize whether is added or substracted when trans update
            Dim selisih As Integer = rows.Cells("qty_b").Value

            If bt_simpanreturbeli.Text = "Update" Then
                'select original qty from trans_beli
                readcommd("SELECT IFNULL(trans_qty_tujuan,0) as a FROM data_barang_mutasi_trans WHERE trans_barang_tujuan='" & rows.Cells("kode_b").Value & "' AND trans_faktur='" & in_kode.Text & "'")
                'count the diff
                selisih = rows.Cells("qty_b").Value - rd.Item("a")
                rd.Close()
            End If

            queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_in=IFNULL(stock_in,0)+({2}) WHERE stock_gudang='{0}' AND stock_barang='{1}'", in_gudang.Text, rows.Cells("kode_b").Value, selisih))
            queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_sisa=countQTYSisaSTock('{0}','{1}') WHERE stock_barang='{0}' AND stock_gudang='{1}'", rows.Cells("kode_b").Value, in_gudang.Text))
            'log
            queryArr.Add(String.Format("INSERT INTO log_stock SET log_reg=NOW(), log_user='{0}', log_barang='{1}', log_gudang='{2}', log_tanggal=NOW(), log_ip='{3}', log_komputer='{4}', log_mac='{5}', log_nama='MUTASI BARANG {6}'", loggeduser.user_id, rows.Cells("kode_b").Value, in_gudang.Text, loggeduser.user_ip, loggeduser.user_host, loggeduser.user_mac, in_kode))
        Next

        querycheck = startTrans(queryArr)

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("Data tersimpan")
            frmmutasistok.in_cari.Clear()
            populateDGVUserCon("mutasistok", "", frmmutasistok.dgv_list)
            Me.Close()
        End If
    End Sub

    Private Sub date_tgl_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyDown
        keyshortenter(in_gudang, e)
    End Sub

    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        lbl_gudang1.Text = ""
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    .query = "SELECT gudang_kode as kode, gudang_nama as nama FROM data_barang_gudang"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "gudang"
                    .ShowDialog()
                    in_gudang.Text = .returnkode
                End With
            End Using
            in_keterangan.Focus()
            Exit Sub
        End If
        keyshortenter(in_keterangan, e)
    End Sub

    Private Sub in_keterangan_KeyDown(sender As Object, e As KeyEventArgs) Handles in_keterangan.KeyDown
        keyshortenter(in_barang, e)
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        clearlabel({lbl_barang, lbl_sat})
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    'kolom stok barang
                    .query = "SELECT barang_nama as nama, barang_kode as kode, gudang_nama as gudang FROM data_barang_master LEFT JOIN data_barang_stok on stock_barang=barang_kode LEFT JOIN data_barang_gudang ON stock_gudang=gudang_kode"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "barangmutasi"
                    .ShowDialog()
                    in_barang.Text = .returnkode
                End With
            End Using
            in_qty.Focus()
        End If
        keyshortenter(in_qty, e)
    End Sub

    Private Sub in_qty_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
        keyshortenter(in_barang2, e)
    End Sub

    Private Sub in_barang2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang2.KeyDown
        clearlabel({lbl_barang2, lbl_sat2})
        If e.KeyCode = Keys.F1 AndAlso Trim(in_gudang.Text) <> "" Then
            Using search As New fr_search_dialog
                With search
                    'kolom stok barang
                    .query = "SELECT barang_nama as nama, barang_kode as kode, gudang_nama as gudang FROM data_barang_master INNER JOIN data_barang_stok on stock_barang=barang_kode INNER JOIN data_barang_gudang ON stock_gudang=gudang_kode WHERE stock_gudang='" & in_gudang.Text & "'"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "barangmutasi"
                    .ShowDialog()
                    in_barang2.Text = .returnkode
                End With
            End Using
            in_qty2.Focus()
        End If
        keyshortenter(in_qty2, e)
    End Sub

    Private Sub in_qty2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty2.KeyDown
        If e.KeyCode = Keys.Enter AndAlso (lbl_barang.Text <> "" And lbl_barang2.Text <> "") Then
            txtToDGV()
        End If
    End Sub

    Private Sub in_gudang_Leave(sender As Object, e As EventArgs) Handles in_gudang.Leave
        If Trim(in_gudang.Text) <> "" Then setGudang(in_gudang.Text, lbl_gudang1)
    End Sub

    Private Sub in_barang_Leave(sender As Object, e As EventArgs) Handles in_barang.Leave
        If Trim(in_barang.Text) <> "" Then setBarang(in_barang.Text)
    End Sub

    Private Sub in_barang2_Leave(sender As Object, e As EventArgs) Handles in_barang2.Leave
        If Trim(in_barang2.Text) <> "" AndAlso lbl_gudang1.Text <> "" Then setBarangTujuan(in_barang2.Text, in_gudang.Text)
    End Sub

    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        rowindex = e.RowIndex
        dgvToTxt()
        dgv_barang.Rows.RemoveAt(rowindex)
    End Sub

    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty2.Enter, in_qty.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty2.Leave, in_qty.Leave
        numericLostFocus(sender)
    End Sub
End Class