﻿Public Class fr_stok_mutasi
    Private rowindex As Integer = 0
    Private isisat_t As Integer = 0
    Private isisat_b As Integer = 0

    Private Sub loadDataMutasi(kode As String)
        readcommd("SELECT * FROM data_barang_stok_mutasi WHERE faktur_kode='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = rd.Item("faktur_kode")
            date_tgl_beli.Value = rd.Item("faktur_tanggal")
            in_gudang.Text = rd.Item("faktur_gudang_awal")
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
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_qty_besar, trans_satuan_besar, trans_qty_tengah, trans_satuan_tengah, trans_qty_kecil, trans_satuan_kecil, trans_qty_tot FROM data_barang_mutasi_trans INNER JOIN data_barang_master ON barang_kode=trans_barang WHERE trans_faktur='" & kode & "'")
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
        readcommd("SELECT barang_nama, barang_satuan_besar_jumlah, barang_satuan_tengah_jumlah, barang_satuan_besar, barang_satuan_tengah, barang_satuan_kecil FROM data_barang_stok INNER JOIN data_barang_master ON barang_kode=stock_barang WHERE stock_gudang='" & gudang & "' AND stock_barang='" & kode & "'")
        If rd.HasRows Then
            in_gudang2.Text = kode
            lbl_barang.Text = rd.Item("barang_nama")
            lbl_sat_besar.Text = rd.Item("barang_satuan_besar")
            lbl_sat_tengah.Text = rd.Item("barang_satuan_tengah")
            lbl_sat_kecil.Text = rd.Item("barang_satuan_kecil")
            isisat_b = rd.Item("barang_satuan_besar_jumlah")
            isisat_t = rd.Item("barang_satuan_tengah_jumlah")
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
        If Trim(in_kode.Text) = "" Then
            MessageBox.Show("No.Bukti belum di input")
            in_kode.Focus()
            Exit Sub
        End If
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

        If bt_simpanreturbeli.Text = "Simpan" Then
            'generate kode
            readcommd("SELECT COUNT(faktur_tanggal) FROM data_barang_stok_mutasi WHERE faktur_tanggal_trans='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'")
            Dim x As Integer = rd.Item(0)
            x += 1
            rd.Close()
            Dim fakturkode As String = date_tgl_beli.Value.ToString("yyyyMMdd") & x.ToString("D4")
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
                "faktur_gudang_tujuan='" & in_gudang2.Text & ,
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
        Next

        querycheck = startTrans(queryArr)

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            'frmpembelian.in_cari.Clear()
            'populateDGVUserCon("beli", "", frmpembelian.dgv_list)
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
        keyshortenter(in_gudang2, e)
    End Sub

    Private Sub in_gudang2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang2.KeyDown
        keyshortenter(in_barang, e)
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
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
End Class