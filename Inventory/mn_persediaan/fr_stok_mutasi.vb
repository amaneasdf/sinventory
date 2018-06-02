Public Class fr_stok_mutasi
    Private rowindex As Integer = 0
    Private isisat_t As Integer = 0
    Private isisat_b As Integer = 0
    Private maxqty As Integer = 0

    Private Sub loadDataMutasi(kode As String)
        readcommd("SELECT * FROM data_barang_stok_mutasi WHERE faktur_kode='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = rd.Item("faktur_kode")
            date_tgl_beli.Value = rd.Item("faktur_tanggal")
            in_gudang.Text = rd.Item("faktur_gudang_asal")
            in_gudang2.Text = rd.Item("faktur_gudang_tujuan")
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
        setGudang(in_gudang2.Text, lbl_gudang2)
        loadDataMutasiBarang(kode)
    End Sub

    Private Sub loadDataMutasiBarang(kode As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_qty_besar, trans_satuan_besar, trans_qty_tengah, trans_satuan_tengah, trans_qty_kecil, trans_satuan_kecil, trans_qty_tot FROM data_barang_stok_mutasi_trans INNER JOIN data_barang_master ON barang_kode=trans_barang WHERE trans_faktur='" & kode & "'")
        With dgv_barang.Rows
            For Each x As DataRow In dt.Rows
                Dim y As Integer = .Add
                With .Item(y)
                    .Cells("kode").Value = x.ItemArray(0)
                    .Cells("nama").Value = x.ItemArray(1)
                    .Cells("qty_b").Value = x.ItemArray(2)
                    .Cells("sat_b").Value = x.ItemArray(3)
                    .Cells("qty_t").Value = x.ItemArray(4)
                    .Cells("sat_t").Value = x.ItemArray(5)
                    .Cells("qty_k").Value = x.ItemArray(6)
                    .Cells("sat_k").Value = x.ItemArray(7)
                    .Cells("qty_tot").Value = x.ItemArray(8)
                End With
            Next
        End With
    End Sub

    Private Sub setDataBarangGudang(kode As String, gudang As String)
        readcommd("SELECT barang_nama, barang_satuan_besar_jumlah, barang_satuan_tengah_jumlah, barang_satuan_besar, barang_satuan_tengah, barang_satuan_kecil, stock_sisa FROM data_barang_stok INNER JOIN data_barang_master ON barang_kode=stock_barang WHERE stock_gudang='" & gudang & "' AND stock_barang='" & kode & "'")
        If rd.HasRows Then
            in_barang.Text = kode
            lbl_barang.Text = rd.Item("barang_nama")
            lbl_sat_besar.Text = rd.Item("barang_satuan_besar")
            lbl_sat_tengah.Text = rd.Item("barang_satuan_tengah")
            lbl_sat_kecil.Text = rd.Item("barang_satuan_kecil")
            isisat_b = rd.Item("barang_satuan_besar_jumlah")
            isisat_t = rd.Item("barang_satuan_tengah_jumlah")
            maxqty = rd.Item("stock_sisa")
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
        Dim qtytot As Integer = countTotQTY(in_qty_b.Value, in_qty_t.Value, in_qty_k.Value)
        If Trim(lbl_barang.Text) = Nothing Then
            in_barang.Focus()
            Exit Sub
        End If
        If qtytot = 0 Then
            in_qty_b.Focus()
            Exit Sub
        End If
        If qtytot > maxqty Then
            MessageBox.Show("QTY lebih besar daripada persediaan (stok: " & maxqty & ")")
            in_qty_b.Focus()
            Exit Sub
        End If

        With dgv_barang.Rows
            Dim x As Integer = .Add
            With .Item(x)
                .Cells("kode").Value = in_barang.Text
                .Cells("nama").Value = lbl_barang.Text
                .Cells("qty_b").Value = in_qty_b.Value
                .Cells("sat_b").Value = lbl_sat_besar.Text
                .Cells("qty_t").Value = in_qty_t.Value
                .Cells("sat_t").Value = lbl_sat_tengah.Text
                .Cells("qty_k").Value = in_qty_k.Value
                .Cells("sat_k").Value = lbl_sat_kecil.Text
                .Cells("qty_tot").Value = qtytot
            End With
        End With

        clearBarang()
        in_barang.Focus()
    End Sub

    Private Sub dgvToTxt()
        With dgv_barang.Rows(rowindex)
            in_barang.Text = .Cells("kode").Value
            lbl_barang.Text = .Cells("nama").Value
            in_qty_b.Value = .Cells("qty_b").Value
            lbl_sat_besar.Text = .Cells("sat_b").Value
            in_qty_t.Value = .Cells("qty_t").Value
            lbl_sat_tengah.Text = .Cells("sat_t").Value
            in_qty_k.Value = .Cells("qty_k").Value
            lbl_sat_kecil.Text = .Cells("sat_k").Value
        End With
        in_barang.Focus()
    End Sub

    Private Function countTotQTY(b As Integer, t As Integer, k As Integer) As Integer
        Dim x As Integer = 0

        x = ((b * isisat_b) * isisat_t) + (t * isisat_t) + k

        Return x
    End Function

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
        'Dim x As Label() = {lbl_barang, lbl_gudang1, lbl_gudang2, lbl_sat_besar, lbl_sat_kecil, lbl_sat_tengah}
        For Each lbl As Label In x
            lbl.Text = ""
        Next
    End Sub

    Private Sub clearBarang()
        in_barang.Clear()
        in_qty_b.Value = 0
        in_qty_t.Value = 0
        in_qty_k.Value = 0
        clearlabel({lbl_barang, lbl_sat_besar, lbl_sat_tengah, lbl_sat_kecil})
    End Sub

    Private Sub clearForm()
        in_kode.Clear()
        in_gudang.Clear()
        in_gudang2.Clear()
        clearlabel({lbl_gudang1, lbl_gudang2})
    End Sub

    Private Sub fr_stok_mutasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearlabel({lbl_barang, lbl_gudang1, lbl_gudang2, lbl_sat_besar, lbl_sat_kecil, lbl_sat_tengah})

        op_con()
        If bt_simpanreturbeli.Text = "Update" Then
            loadDataMutasi(in_kode.Text)
            'ElseIf bt_simpanreturbeli.Text = "Simpan" Then
            '    GroupBox2.Visible = False
        End If
    End Sub

    Private Sub bt_simpanreturbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanreturbeli.Click
        'If Trim(in_kode.Text) = "" Then
        '    MessageBox.Show("No.Bukti belum di input")
        '    in_kode.Focus()
        '    Exit Sub
        'End If
        If Trim(in_gudang.Text) = "" Then
            MessageBox.Show("Gudang asal belum di input")
            in_gudang.Focus()
            Exit Sub
        End If
        If Trim(in_gudang2.Text) = "" Then
            MessageBox.Show("Gudang tujuan belum di input")
            in_gudang2.Focus()
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

        Me.Cursor = Cursors.WaitCursor

        op_con()
        If bt_simpanreturbeli.Text = "Simpan" Then
            'generate kode
            readcommd("SELECT COUNT(faktur_tanggal) FROM data_barang_stok_mutasi WHERE faktur_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'")
            Dim x As Integer = rd.Item(0)
            x += 1
            rd.Close()
            Dim fakturkode As String = "MG" & date_tgl_beli.Value.ToString("yyyyMMdd") & x.ToString("D4")
            in_kode.Text = fakturkode

            datafaktur = {
                "faktur_kode='" & in_kode.Text & "'",
                "faktur_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_gudang_asal='" & in_gudang.Text & "'",
                "faktur_gudang_tujuan='" & in_gudang2.Text & "'",
                "faktur_reg_date=NOW()",
                "faktur_reg_alias='" & loggeduser.user_id & "'"
                }

            'INSERT
            queryArr.Add("INSERT INTO data_barang_stok_mutasi SET " & String.Join(",", datafaktur))

        ElseIf bt_simpanreturbeli.Text = "Update" Then
            datafaktur = {
                "faktur_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_gudang_asal='" & in_gudang.Text & "'",
                "faktur_gudang_tujuan='" & in_gudang2.Text & "'",
                "faktur_upd_date=NOW()",
                "faktur_upd_alias='" & loggeduser.user_id & "'"
                }

            'UPDATE
            queryArr.Add("UPDATE data_barang_stok_mutasi SET " & String.Join(",", datafaktur) & " WHERE faktur_kode='" & in_kode.Text & "'")

            'DELETE data trans/barang
            queryArr.Add("DELETE FROM data_barang_stok_mutasi_trans WHERE trans_faktur='" & in_kode.Text & "'")
        End If

        'INSERT/re-INSERT data trans/barang
        For Each rows As DataGridViewRow In dgv_barang.Rows
            dataBrg = {
                "trans_faktur='" & in_kode.Text & "'",
                "trans_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "trans_barang='" & rows.Cells(0).Value & "'",
                "trans_qty_besar=" & rows.Cells("qty_b").Value,
                "trans_qty_tengah=" & rows.Cells("qty_t").Value,
                "trans_qty_kecil=" & rows.Cells("qty_k").Value,
                "trans_qty_tot=" & rows.Cells("qty_tot").Value,
                "trans_satuan_besar='" & rows.Cells("sat_b").Value & "'",
                "trans_satuan_tengah='" & rows.Cells("sat_t").Value & "'",
                "trans_satuan_kecil='" & rows.Cells("sat_k").Value & "'",
                "trans_reg_date=NOW()",
                "trans_reg_alias='" & loggeduser.user_id & "'"
                }

            queryArr.Add("INSERT INTO data_barang_stok_mutasi_trans SET " & String.Join(",", dataBrg))

            'update stok

            If checkdata("data_barang_stok", "'" & rows.Cells(0).Value & "' AND stock_gudang='" & in_gudang2.Text & "'", "stock_barang") = False Then
                queryArr.Add("INSERT INTO data_barang_stok SET stock_barang='" & rows.Cells(0).Value & "', stock_gudang='" & in_gudang2.Text & "', stock_reg_date=NOW(), stock_reg_alias='" & loggeduser.user_id & "'")
                'log
                queryArr.Add("INSERT INTO log_stock SET log_reg=NOW(), log_user='" & loggeduser.user_id & "', log_barang='" & rows.Cells(0).Value & "', log_gudang='" & in_gudang2.Text & "', log_tanggal=NOW(), log_ip='" & loggeduser.user_ip & "', log_komputer='" & loggeduser.user_host & "', log_mac='" & loggeduser.user_mac & "', log_ket='SYSTEM', log_nama='SETUP AWAL STOK'")
            End If

            'TODO UPDATE stok beli -> must recognize whether is added or substracted when trans update
            Dim selisih As Integer = rows.Cells("qty_tot").Value

            If bt_simpanreturbeli.Text = "Update" Then
                'select original qty from trans_beli
                readcommd("SELECT IFNULL(trans_qty_tot,0) as a FROM data_barang_stok_mutasi_trans WHERE trans_barang='" & rows.Cells(0).Value & "' AND trans_faktur='" & in_kode.Text & "'")
                'count the diff
                selisih = rows.Cells("qty_tot").Value - rd.Item("a")
                rd.Close()
            End If

            queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_out=IFNULL(stock_out,0)+({2}) WHERE stock_gudang='{0}' AND stock_barang='{1}'", in_gudang.Text, rows.Cells(0).Value, selisih))
            queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_in=IFNULL(stock_in,0)+({2}) WHERE stock_gudang='{0}' AND stock_barang='{1}'", in_gudang2.Text, rows.Cells(0).Value, selisih))
            queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_sisa=countQTYSisaSTock('{0}','{1}') WHERE stock_barang='{0}' AND stock_gudang='{1}'", rows.Cells(0).Value, in_gudang.Text))
            queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_sisa=countQTYSisaSTock('{0}','{1}') WHERE stock_barang='{0}' AND stock_gudang='{1}'", rows.Cells(0).Value, in_gudang2.Text))

            'log -> setelah persetujuan? pindah?
            queryArr.Add(String.Format("INSERT INTO log_stock SET log_reg=NOW(), log_user='{0}', log_barang='{1}', log_gudang='{2}', log_tanggal=NOW(), log_ip='{3}', log_komputer='{4}', log_mac='{5}', log_nama='MUTASIGUDANG {6} OUT', log_ket='FR GDG {7}'", loggeduser.user_id, rows.Cells(0).Value, in_gudang.Text, loggeduser.user_ip, loggeduser.user_host, loggeduser.user_mac, in_kode.Text, in_gudang2.Text))
            queryArr.Add(String.Format("INSERT INTO log_stock SET log_reg=NOW(), log_user='{0}', log_barang='{1}', log_gudang='{2}', log_tanggal=NOW(), log_ip='{3}', log_komputer='{4}', log_mac='{5}', log_nama='MUTASIGUDANG {6} IN', log_ket='FR GDG {7}'", loggeduser.user_id, rows.Cells(0).Value, in_gudang2.Text, loggeduser.user_ip, loggeduser.user_host, loggeduser.user_mac, in_kode.Text, in_gudang.Text))
        Next

        querycheck = startTrans(queryArr)

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("Data tersimpan")
            frmmutasigudang.in_cari.Clear()
            populateDGVUserCon("mutasigudang", "", frmmutasigudang.dgv_list)
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
                    .query = "SELECT gudang_kode as kode, gudang_nama as nama FROM data_barang_gudang WHERE gudang_kode<>'" & in_gudang2.Text & "'"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "gudang"
                    .ShowDialog()
                    in_gudang.Text = .returnkode
                End With
            End Using
            in_gudang2.Focus()
            Exit Sub
        End If
        keyshortenter(in_gudang2, e)
    End Sub

    Private Sub in_gudang2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang2.KeyDown
        lbl_gudang2.Text = ""
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    .query = "SELECT gudang_kode as kode, gudang_nama as nama FROM data_barang_gudang WHERE gudang_kode<>'" & in_gudang.Text & "'"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "gudang"
                    .ShowDialog()
                    in_gudang2.Text = .returnkode
                End With
            End Using
            in_barang.Focus()
            Exit Sub
        End If
        keyshortenter(in_barang, e)
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        lbl_barang.Text = ""
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
            in_qty_b.Focus()
            Exit Sub
        End If
        keyshortenter(in_qty_b, e)
    End Sub

    Private Sub in_qty_b_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty_b.KeyDown
        keyshortenter(in_qty_t, e)
    End Sub

    Private Sub in_qty_t_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty_t.KeyDown
        keyshortenter(in_qty_k, e)
    End Sub

    Private Sub in_qty_k_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty_k.KeyDown
        If e.KeyCode = Keys.Enter And lbl_barang.Text <> "" Then
            txtToDGV()
        End If
    End Sub

    Private Sub in_gudang_Leave(sender As Object, e As EventArgs) Handles in_gudang.Leave
        setGudang(in_gudang.Text, lbl_gudang1)
    End Sub

    Private Sub in_gudang2_Leave(sender As Object, e As EventArgs) Handles in_gudang2.Leave
        setGudang(in_gudang2.Text, lbl_gudang2)
    End Sub

    Private Sub in_barang_Leave(sender As Object, e As EventArgs) Handles in_barang.Leave
        If Trim(in_barang.Text) <> "" Then
            setDataBarangGudang(in_barang.Text, in_gudang.Text)
        End If
    End Sub

    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        rowindex = e.RowIndex
        dgvToTxt()
        dgv_barang.Rows.RemoveAt(rowindex)
    End Sub

    Private Sub in_qty_b_Enter(sender As Object, e As EventArgs) Handles in_qty_t.Enter, in_qty_k.Enter, in_qty_b.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_b_Leave(sender As Object, e As EventArgs) Handles in_qty_t.Leave, in_qty_k.Leave, in_qty_b.Leave
        numericLostFocus(sender)
    End Sub
End Class