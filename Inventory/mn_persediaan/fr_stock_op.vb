Public Class fr_stock_op
    Private rowindex As Integer = 0

    Private Sub loadDataFaktur(kode As String)
        readcommd("SELECT * FROM data_barang_stok_opname WHERE faktur_bukti='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = rd.Item("faktur_bukti")
            date_tgl_beli.Value = rd.Item("faktur_tanggal")
            in_gudang.Text = rd.Item("faktur_gudang")
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

        setGudang(in_gudang.Text)
        loadDatabarang(kode)
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

    Private Sub setGudang(kode As String)
        op_con()
        readcommd("SELECT gudang_nama FROM data_barang_gudang WHERE gudang_kode='" & kode & "'")
        If rd.HasRows Then
            lbl_gudang1.Text = rd.Item("gudang_nama")
            in_kode.ReadOnly = True
        End If
        rd.Close()
    End Sub

    Private Sub setBarang(kode As String)
        readcommd("SELECT barang_nama, barang_satuan_kecil, stock_sisa FROM data_barang_stok INNER JOIN data_barang_master ON barang_kode=stock_barang WHERE stock_gudang='" & in_gudang.Text & "' AND stock_barang='" & kode & "'")
        If rd.HasRows Then
            in_barang.Text = kode
            lbl_barang.Text = rd.Item("barang_nama")
            in_qty_sys.Text = rd.Item("stock_sisa")
            lbl_sat.Text = rd.Item("barang_satuan_kecil")
            lbl_sat2.Text = lbl_sat.Text
        End If
        rd.Close()
    End Sub

    Private Sub txtToDGV()
        If Trim(lbl_barang.Text) = Nothing Then
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
                .Cells("nama").Value = lbl_barang.Text
                .Cells("qty_sys").Value = CDbl(in_qty_sys.Text)
                .Cells("sat_sys").Value = lbl_sat.Text
                .Cells("qty_fis").Value = in_qty.Value
                .Cells("sat_fis").Value = lbl_sat2.Text
                .Cells("qty_sel").Value = in_qty.Value - CDbl(in_qty_sys.Text)
                .Cells("ket").Value = in_ket.Text
            End With
        End With

        clearBarang()
        in_barang.Focus()
    End Sub

    Private Sub dgvToTxt()
        With dgv_barang.Rows(rowindex)
            in_barang.Text = .Cells("kode").Value
            lbl_barang.Text = .Cells("nama").Value
            in_qty_sys.Text = .Cells("qty_sys").Value
            lbl_sat.Text = .Cells("sat_sys").Value
            lbl_sat2.Text = lbl_sat.Text
            in_qty.Value = .Cells("qty_fis").Value
            in_ket.Text = .Cells("ket").Value
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
        in_qty.Value = 0
        in_qty_sys.Clear()
        in_ket.Clear()
        clearlabel({lbl_barang, lbl_sat, lbl_sat2})
    End Sub

    Private Sub clearForm()
        in_kode.Clear()
        in_gudang.Clear()
        clearlabel({lbl_gudang1})
    End Sub

    Private Sub fr_stock_op_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearlabel({lbl_barang, lbl_gudang1, lbl_sat, lbl_sat2})

        If bt_simpanreturbeli.Text = "Update" Then
            loadDataFaktur(in_kode.Text)
        End If
    End Sub

    Private Sub bt_simpanreturbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanreturbeli.Click
        If Trim(in_kode.Text) = "" Then
            MessageBox.Show("No. Bukti belum di input")
            in_kode.Focus()
            Exit Sub
        End If
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

        Dim querycheck As String = False
        Dim queryArr As New List(Of String)
        Dim datafaktur As String()
        Dim dataBrg As String()

        op_con()
        If bt_simpanreturbeli.Text = "Simpan" Then
            datafaktur = {
                "faktur_bukti='" & in_kode.Text & "'",
                "faktur_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_gudang='" & in_gudang.Text & "'",
                "faktur_reg_date=NOW()",
                "faktur_reg_alias='" & loggeduser.user_id & "'"
                }

            'INSERT
            queryArr.Add("INSERT INTO data_barang_stok_opname SET " & String.Join(",", datafaktur))

        ElseIf bt_simpanreturbeli.Text = "Update" Then
            datafaktur = {
                "faktur_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_gudang='" & in_gudang.Text & "'",
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

            'update stok
            'TODO UPDATE stok beli -> must recognize whether is added or substracted when trans update
            Dim selisih As Integer = rows.Cells("qty_fis").Value

            If bt_simpanreturbeli.Text = "Update" Then
                'select original qty from trans_beli
                readcommd("SELECT IFNULL(trans_qty_fisik,0) as a FROM data_barang_stok_opname_trans WHERE trans_barang='" & rows.Cells(0).Value & "' AND trans_faktur='" & in_kode.Text & "'")
                'count the diff
                selisih = rows.Cells("qty_fis").Value - rd.Item("a")
                rd.Close()
            End If

            queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_fisik=IFNULL(stock_fisik,0)+({2}) WHERE stock_gudang='{0}' AND stock_barang='{1}'", in_gudang.Text, rows.Cells(0).Value, selisih))
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

    Private Sub bt_batalreturbeli_Click(sender As Object, e As EventArgs) Handles bt_batalreturbeli.Click
        Me.Close()
    End Sub

    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(date_tgl_beli, e)
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
            in_barang.Focus()
            Exit Sub
        End If
        keyshortenter(in_barang, e)
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        clearlabel({lbl_barang, lbl_sat, lbl_sat2})
        in_qty_sys.Clear()
        If e.KeyCode = Keys.F1 AndAlso lbl_gudang1.Text <> "" Then
            Using search As New fr_search_dialog
                With search
                    'kolom stok barang
                    .query = "SELECT barang_nama as nama, barang_kode as kode, gudang_nama as gudang FROM data_barang_master INNER JOIN data_barang_stok on stock_barang=barang_kode INNER JOIN data_barang_gudang ON stock_gudang=gudang_kode WHERE stock_gudang='" & in_gudang.Text & "'"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%' OR gudang LIKE '%{0}%'"
                    .type = "barangmutasi"
                    .ShowDialog()
                    in_barang.Text = .returnkode
                End With
            End Using
            in_qty.Focus()
            Exit Sub
        End If
        keyshortenter(in_qty, e)
    End Sub

    Private Sub in_qty_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
        keyshortenter(in_ket, e)
    End Sub

    Private Sub in_ket_KeyDown(sender As Object, e As KeyEventArgs) Handles in_ket.KeyDown
        If e.KeyCode = Keys.Enter AndAlso lbl_barang.Text <> "" Then
            txtToDGV()
        End If
    End Sub

    Private Sub in_gudang_Leave(sender As Object, e As EventArgs) Handles in_gudang.Leave
        If Trim(in_gudang.Text) <> "" Then
            setGudang(in_gudang.Text)
        End If
    End Sub

    Private Sub in_barang_Leave(sender As Object, e As EventArgs) Handles in_barang.Leave
        If Trim(in_barang.Text) <> "" Then
            setBarang(in_barang.Text)
        End If
    End Sub

    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        rowindex = e.RowIndex
        dgvToTxt()
        dgv_barang.Rows.RemoveAt(rowindex)
    End Sub

    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave
        numericLostFocus(sender)
    End Sub

    Private Sub bt_proses_Click(sender As Object, e As EventArgs) Handles bt_proses.Click
        'confirm opname
        'ask verification?
        'UPDATE stok -> stok awal, tgl, reset qty[0]
        'UPDATE stockop -> tgl_proses, by_who
        'write log -> barang, gudang, tgl, act => opn, by, ip, host, mac, ket

        'For Each rows As DataGridViewRow In dgv_barang.Rows
        '    commnd("INSERT INTO log_stock SET log_reg=NOW(), log_user='" & loggeduser.user_id & "', log_barang='" & rows.Cells(0).Value & "', log_gudang='" & in_gudang.Text & "', log_tanggal=NOW(), log_ip='" & loggeduser.user_ip & "', log_komputer='" & loggeduser.user_host & "', log_mac='" & loggeduser.user_mac & "', log_nama='OPNAME " & in_kode.Text & "'")
        'Next
    End Sub
End Class