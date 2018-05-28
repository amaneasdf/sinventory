Public Class fr_stok_mutasi_barang
    Private rowindex As Integer = 0

    Private Sub loadDataFaktur(kode As String)
        readcommd("SELECT * FROM data_barang_mutasi WHERE ='" & kode & "'")
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
            in_barang.Text = kode
            lbl_barang.Text = rd.Item("barang_nama")
            lbl_sat.Text = rd.Item("barang_satuan_kecil")
        End If
        rd.Close()
    End Sub

    Private Sub setBarang(kode As String, gudang As String)
        readcommd("SELECT barang_nama, barang_satuan_kecil FROM data_barang_stok WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            in_barang2.Text = kode
            lbl_barang2.Text = rd.Item("barang_nama")
            lbl_sat2.Text = rd.Item("barang_satuan_kecil")
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

        'clearBarang()
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

    Private Sub fr_stok_mutasi_barang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearlabel({lbl_barang, lbl_barang2, lbl_gudang1, lbl_sat, lbl_sat2})

        op_con()
        If bt_simpanreturbeli.Text = "Update" Then
            loadDataFaktur(in_kode.Text)

        End If
    End Sub

    Private Sub bt_simpanreturbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanreturbeli.Click


        'Me.Close()
    End Sub

    Private Sub bt_batalreturbeli_Click(sender As Object, e As EventArgs) Handles bt_batalreturbeli.Click
        Me.Close()
    End Sub
End Class