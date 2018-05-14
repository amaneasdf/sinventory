Public Class fr_jual_retur_detail
    Dim rowindex As Integer

    Private Sub loadDataRetur(kode As String)
        readcommd("SELECT * FROM data_penjualan_retur_faktur WHERE faktur_kode_bukti='" & kode & "'")
        If rd.HasRows Then
            in_no_bukti.Text = kode
            in_pajak.Text = rd.Item("faktur_pajak_no")
            date_tgl_trans.Value = rd.Item("faktur_tanggal_trans")
            date_tgl_pajak.Value = rd.Item("faktur_pajak_tanggal")
            in_no_faktur.Text = rd.Item("faktur_kode_faktur")
            in_no_faktur_ex.Text = rd.Item("faktur_kode_exfaktur")
            in_suratjalan.Text = rd.Item("faktur_surat_jalan")
            in_sales.Text = rd.Item("faktur_sales")
            in_gudang.Text = rd.Item("faktur_gudang")
            in_jumlah.Text = commaThousand(rd.Item("faktur_jumlah"))
            in_ppn_persen.Value = rd.Item("faktur_ppn_persen")
            cb_ppn_jenis.SelectedValue = rd.Item("faktur_ppn_jenis")
            in_netto.Text = commaThousand(rd.Item("faktur_netto"))
            in_status_kode.Text = rd.Item("faktur_status")
            cb_status.SelectedValue = in_status_kode.Text
            txtRegAlias.Text = rd.Item("faktur_reg_alias")
            txtRegdate.Text = rd.Item("faktur_reg_date")
        End If
        rd.Close()
        'setGudang(in_gudang.Text)
        'setSupplier(in_supplier.Text)
        'setReadOnly()
    End Sub

    Private Sub loadDataReturBrg(kode As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_retur, trans_qty, trans_satuan, trans_jumlah FROM data_pembelian_retur_trans INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & kode & "'")
        With dgv_barang.Rows
            For Each rows As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("kode").Value = rows.ItemArray(0)
                    .Cells("nama").Value = rows.ItemArray(1)
                    .Cells("harga").Value = rows.ItemArray(2)
                    .Cells("qty").Value = rows.ItemArray(3)
                    .Cells("sat").Value = rows.ItemArray(4)
                    .Cells("jml").Value = rows.ItemArray(5)
                End With
            Next
        End With
        dt.Dispose()
    End Sub


    Private Sub fr_jual_retur_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_gudang.Text = ""
        lbl_barang.Text = ""
        lbl_sales.Text = ""
        lbl_custo.Text = ""

        With cb_status
            .DataSource = statusBarang()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
    End Sub
End Class