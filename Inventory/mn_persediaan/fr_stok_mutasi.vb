Public Class fr_stok_mutasi
    Private rowindex As Integer = 0
    Private isisat_t As Integer = 0
    Private isisat_b As Integer = 0

    Private Sub loadDataMutasi(kode As String)

        loadDataMutasiBarang(kode)
    End Sub

    Private Sub loadDataMutasiBarang(kode As String)

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
        Dim dataArr As String()
        Dim data As String() = {
            "'" & in_kode.Text & "'",
            "'" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
            "'" & in_gudang.Text & "'",
            "'" & in_gudang2.Text & "'"
            }

        If bt_simpanreturbeli.Text = "Simpan" Then

        ElseIf bt_simpanreturbeli.Text = "Update" Then

        End If

    End Sub

    Private Sub bt_batalreturbeli_Click(sender As Object, e As EventArgs) Handles bt_batalreturbeli.Click
        Me.Close()
    End Sub
End Class