Public Class fr_beli_detail
    Private indexrow As Integer = 0

    Private Sub loadDataBeliFaktur(faktur As String)
        readcommd("SELECT * FROM data_pembelian_faktur WHERE faktur_kode='" & faktur & "'")
        If rd.HasRows Then
            in_faktur.Text = faktur
            in_suratjalan.Text = rd.Item("faktur_surat_jalan")
            in_pajak.Text = rd.Item("faktur_pajak_no")
            date_tgl_beli.Value = rd.Item("faktur_tanggal_trans")
            date_tgl_pajak.Value = rd.Item("faktur_pajak_tanggal")
            in_gudang.Text = rd.Item("faktur_gudang")
            in_supplier.Text = rd.Item("faktur_supplier")
            in_term.Value = rd.Item("faktur_term")
            Console.WriteLine("rd" & rd.Item("faktur_jumlah") & "nett" & rd.Item("faktur_netto"))
            in_jumlah.Text = commaThousand(rd.Item("faktur_jumlah"))
            in_discount.Maximum = rd.Item("faktur_jumlah")
            in_discount.Value = rd.Item("faktur_disc")
            in_total.Text = commaThousand(rd.Item("faktur_total"))
            in_ppn_persen.Value = rd.Item("faktur_ppn_persen")
            cb_ppn_jenis.SelectedValue = rd.Item("faktur_ppn_jenis")
            in_netto.Text = commaThousand(rd.Item("faktur_netto"))
            'Console.WriteLine(rd.Item("faktur_netto"))
            in_klaim.Value = CDbl(rd.Item("faktur_klaim"))
            in_total_netto.Text = commaThousand(rd.Item("faktur_total_netto"))
            in_status_kode.Text = rd.Item("faktur_status")
            cb_status.SelectedValue = in_status_kode.Text
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
        setSupplier(in_supplier.Text)
    End Sub

    Private Sub loadDatabeliBarang(faktur As String)
        'dgv_barang.DataSource = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_beli, trans_qty, trans_satuan, trans_disc1,trans_disc2,trans_disc3,trans_disc_rupiah, trans_jumlah FROM data_pembelian_trans INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & faktur & "'")
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_beli, trans_qty, trans_satuan, trans_disc1,trans_disc2,trans_disc3,trans_disc_rupiah, trans_jumlah FROM data_pembelian_trans INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & faktur & "'")
        With dgv_barang.Rows
            For Each row As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("kode").Value = row.ItemArray(0)
                    .Cells("nama").Value = row.ItemArray(1)
                    .Cells("qty").Value = row.ItemArray(3)
                    .Cells("sat").Value = row.ItemArray(4)
                    .Cells("harga").Value = row.ItemArray(2)
                    .Cells("disc1").Value = row.ItemArray(5)
                    .Cells("disc2").Value = row.ItemArray(6)
                    .Cells("disc3").Value = row.ItemArray(7)
                    .Cells("discrp").Value = row.ItemArray(8)
                    .Cells("jml").Value = row.ItemArray(9)
                End With
            Next
        End With
    End Sub

    Private Sub setGudang(kode As String)
        op_con()
        readcommd("SELECT gudang_nama FROM data_barang_gudang WHERE gudang_kode='" & kode & "'")
        If rd.HasRows Then
            lbl_gudang.Text = rd.Item("gudang_nama")
        End If
        rd.Close()
    End Sub

    Private Sub setSupplier(kode As String)
        op_con()
        readcommd("SELECT supplier_nama FROM data_supplier_master WHERE supplier_kode='" & kode & "'")
        If rd.HasRows Then
            lbl_supplier.Text = rd.Item("supplier_nama")
        End If
        rd.Close()
    End Sub

    Private Sub setBarang(kode As String)
        op_con()
        readcommd("SELECT barang_nama, barang_satuan_besar, barang_harga_beli, barang_harga_beli_d1, barang_harga_beli_d2, barang_harga_beli_d3 FROM data_barang_master WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            lbl_barang.Text = rd.Item("barang_nama")
            lbl_sat.Text = rd.Item("barang_satuan_besar")
            in_harga_beli.Text = rd.Item("barang_harga_beli")
            in_disc1.Value = rd.Item("barang_harga_beli_d1")
            in_disc2.Value = rd.Item("barang_harga_beli_d2")
            in_disc2.Value = rd.Item("barang_harga_beli_d3")
        End If
        rd.Close()
    End Sub

    Private Sub addRowBarang()
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
                .Cells("qty").Value = in_qty.Value
                .Cells("sat").Value = lbl_sat.Text
                .Cells("harga").Value = in_harga_beli.Text
                .Cells("disc1").Value = in_disc1.Value
                .Cells("disc2").Value = in_disc2.Value
                .Cells("disc3").Value = in_disc3.Value
                .Cells("discrp").Value = in_discrp.Value
                .Cells("jml").Value = biayaperitem()
            End With
        End With

        'in_jumlah.Text = jumlahbiaya()
        countbiaya()
        clearInputBarang()
        in_barang.Focus()
    End Sub

    Private Sub dgvTotxt()
        With dgv_barang.Rows(indexrow)
            in_barang.Text = .Cells("kode").Value
            lbl_barang.Text = .Cells("nama").Value
            in_qty.Value = .Cells("qty").Value
            lbl_sat.Text = .Cells("sat").Value
            in_harga_beli.Text = .Cells("harga").Value
            in_disc1.Value = .Cells("disc1").Value
            in_disc2.Value = .Cells("disc2").Value
            in_disc3.Value = .Cells("disc3").Value
            in_discrp.Value = .Cells("discrp").Value
        End With
        in_barang.Focus()
    End Sub

    Private Function biayaperitem() As Double
        Dim x As Double = 0
        Dim y As Double = CDbl(in_harga_beli.Text)
        x = in_qty.Value * y
        x = x - (x * in_disc1.Value / 100)
        Return x
    End Function

    Private Sub countbiaya()
        Dim x As Double = jumlahbiaya()
        Dim y As Double = x - CDbl(in_discount.Value)
        Dim z As Double = y
        If cb_ppn_jenis.SelectedValue = 0 Then
            z += x * in_ppn_persen.Value / 100
        End If
        Dim aa As Double = z - CDbl(in_klaim.Value)
        Dim cc As Globalization.CultureInfo = Globalization.CultureInfo.GetCultureInfo("id-ID")
        in_jumlah.Text = x.ToString("N2", cc)
        in_discount.Maximum = x
        in_total.Text = y.ToString("N2", cc)
        in_netto.Text = z.ToString("N2", cc)
        in_klaim.Maximum = z
        in_total_netto.Text = aa.ToString("N2", cc)
        'Dim st As String = aa.ToString("C2", cc)
        Console.WriteLine("ss" & aa)
        'Console.WriteLine(st)
        Console.WriteLine(removeCommaThousand(in_total_netto.Text))
    End Sub

    Private Function jumlahbiaya() As Double
        Dim x As Double = 0

        For Each rows As DataGridViewRow In dgv_barang.Rows
            Console.WriteLine(rows.Cells("jml").Value)
            x += rows.Cells(9).Value
        Next
        Console.WriteLine(x)
        Return x
    End Function

    Private Sub numericGotFocus(x As NumericUpDown)
        If x.Value = 0 Then
            x.ResetText()
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

    Private Sub clearTextBarang()
        lbl_barang.Text = ""
        lbl_sat.Text = ""
        in_harga_beli.Clear()
    End Sub

    Private Sub clearInputBarang()
        clearTextBarang()
        in_barang.Clear()
        in_qty.Value = 0
        in_disc1.Value = 0
        in_disc2.Value = 0
        in_disc3.Value = 0
        in_discrp.Value = 0
    End Sub

    Private Sub fr_beli_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_barang.Text = ""
        lbl_gudang.Text = ""
        lbl_supplier.Text = ""
        lbl_sat.Text = ""

        With cb_status
            .DataSource = statusBarang()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
        With cb_ppn_jenis
            .DataSource = jenisPPN()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        With dgv_barang
            For Each x As DataGridViewColumn In {harga, discrp, jml}
                x.DefaultCellStyle = dgvstyle_currency
            Next
            'For Each y As DataGridViewColumn In {disc1, disc2, disc3}
            '    y.DefaultCellStyle = dgvstyle_percentage
            'Next
        End With

        If bt_simpanbeli.Text = "Update" Then
            GroupBox4.Visible = True
            loadDatabeliBarang(in_faktur.Text)
            loadDataBeliFaktur(in_faktur.Text)

        End If
    End Sub

    Private Sub date_tgl_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = False
            'SendKeys.Send("{Right}")
            in_pajak.Focus()
        End If
    End Sub

    Private Sub date_tgl_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_pajak.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = False
            'SendKeys.Send("{Right}")
            in_suratjalan.Focus()
        End If
    End Sub

    Private Sub in_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pajak.KeyDown
        keyshortenter(date_tgl_pajak, e)
    End Sub

    Private Sub in_suratjalan_KeyDown(sender As Object, e As KeyEventArgs) Handles in_suratjalan.KeyDown
        keyshortenter(in_gudang, e)
    End Sub

    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        lbl_gudang.Text = ""

        keyshortenter(in_supplier, e)
    End Sub

    Private Sub in_gudang_Leave(sender As Object, e As EventArgs) Handles in_gudang.Leave
        setGudang(in_gudang.Text)
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        lbl_supplier.Text = ""

        keyshortenter(in_term, e)
    End Sub

    Private Sub in_supplier_Leave(sender As Object, e As EventArgs) Handles in_supplier.Leave
        setSupplier(in_supplier.Text)
    End Sub

    Private Sub in_term_KeyDown(sender As Object, e As KeyEventArgs) Handles in_term.KeyDown
        keyshortenter(in_barang, e)
    End Sub

    Private Sub in_barang_Leave(sender As Object, e As EventArgs) Handles in_barang.Leave
        setBarang(in_barang.Text)
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        clearTextBarang()

        keyshortenter(in_qty, e)
    End Sub

    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        If lbl_supplier.Text = "" Then
            MessageBox.Show("Supplier belum di input")
            in_supplier.Focus()
            Exit Sub
        End If
        If lbl_gudang.Text = "" Then
            MessageBox.Show("Gudang belum di input")
            in_gudang.Focus()
            Exit Sub
        End If
        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum di input")
            in_barang.Focus()
            Exit Sub
        End If

        Dim dataBrg As String()
        Dim dataFak As String()
        Dim querycheck As Boolean = False

        op_con()
        If bt_simpanbeli.Text = "Simpan" Then
            'TODO generate kode
            readcommd("SELECT COUNT(faktur_tanggal_trans) FROM data_pembelian_faktur WHERE faktur_tanggal_trans='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'")
            Dim x As Integer = rd.Item(0)
            x += 1
            rd.Close()
            Dim fakturkode As String = date_tgl_beli.Value.ToString("yyyyMMdd") & x.ToString("D4")
            in_faktur.Text = fakturkode

            dataFak = {
                "faktur_kode='" & in_faktur.Text & "'",
                "faktur_tanggal_trans='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_pajak_no='" & in_pajak.Text & "'",
                "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_surat_jalan='" & in_suratjalan.Text & "'",
                "faktur_gudang='" & in_gudang.Text & "'",
                "faktur_supplier='" & in_supplier.Text & "'",
                "faktur_term='" & in_term.Value & "'",
                "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text) & "'",
                "faktur_disc='" & in_discount.Value & "'",
                "faktur_total='" & removeCommaThousand(in_total.Text) & "'",
                "faktur_ppn_persen='" & in_ppn_persen.Value & "'",
                "faktur_ppn_jenis='" & cb_ppn_jenis.SelectedValue & "'",
                "faktur_netto='" & removeCommaThousand(in_netto.Text) & "'",
                "faktur_klaim='" & in_klaim.Value & "'",
                "faktur_total_netto='" & removeCommaThousand(in_total_netto.Text) & "'",
                "faktur_status=1",
                "faktur_reg_date=NOW()",
                "faktur_reg_alias='" & loggeduser.user_id & "'"
                }
            querycheck = commnd("INSERT INTO data_pembelian_faktur SET " & String.Join(",", dataFak))

        ElseIf bt_simpanbeli.Text = "Update" Then
            'TODO update?
            dataFak = {
                "faktur_tanggal_trans='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_pajak_no='" & in_pajak.Text & "'",
                "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_surat_jalan='" & in_suratjalan.Text & "'",
                "faktur_gudang='" & in_gudang.Text & "'",
                "faktur_supplier='" & in_supplier.Text & "'",
                "faktur_term='" & in_term.Value & "'",
                "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text) & "'",
                "faktur_disc='" & in_discount.Value & "'",
                "faktur_total='" & removeCommaThousand(in_total.Text) & "'",
                "faktur_ppn_persen='" & in_ppn_persen.Value & "'",
                "faktur_ppn_jenis='" & cb_ppn_jenis.SelectedValue & "'",
                "faktur_netto='" & removeCommaThousand(in_netto.Text) & "'",
                "faktur_klaim='" & in_klaim.Value & "'",
                "faktur_total_netto='" & removeCommaThousand(in_total_netto.Text) & "'",
                "faktur_status='" & in_status_kode.Text & "'",
                "faktur_upd_date=NOW()",
                "faktur_upd_alias='" & loggeduser.user_id & "'"
                }
            'TODO update faktur
            querycheck = commnd("UPDATE data_pembelian_faktur SET " & String.Join(",", dataFak) & " WHERE faktur_kode='" & in_faktur.Text & "'")

            'TODO delete trans
            querycheck = commnd("DELETE FROM data_pembelian_trans WHERE trans_faktur='" & in_faktur.Text & "'")
        End If

        'TODO insert / re-insert data trans
        For Each rows As DataGridViewRow In dgv_barang.Rows
            dataBrg = {
                "trans_faktur='" & in_faktur.Text & "'",
                "trans_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "trans_barang='" & rows.Cells(0).Value & "'",
                "trans_harga_beli='" & rows.Cells("harga").Value & "'",
                "trans_qty='" & rows.Cells("qty").Value & "'",
                "trans_satuan='" & rows.Cells("sat").Value & "'",
                "trans_disc1='" & rows.Cells("disc1").Value & "'",
                "trans_disc2='" & rows.Cells("disc2").Value & "'",
                "trans_disc3='" & rows.Cells("disc3").Value & "'",
                "trans_disc_rupiah='" & rows.Cells("discrp").Value & "'",
                "trans_jumlah='" & rows.Cells("jml").Value & "'",
                "trans_reg_date=NOW()",
                "trans_reg_alias='" & loggeduser.user_id & "'"
                }
            querycheck = commnd("INSERT INTO data_pembelian_trans SET " & String.Join(",", dataBrg))
        Next

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmpembelian.in_cari.Clear()
            populateDGVUserCon("beli", "", frmpembelian.dgv_list)
            Me.Dispose()
        End If
    End Sub

    Private Sub fr_beli_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_batalbeli.PerformClick()
        End If
    End Sub

    Private Sub bt_batalbeli_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        Me.Dispose()
    End Sub

    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_disc1.Enter, in_disc2.Enter, in_disc3.Enter, in_discrp.Enter, in_discount.Enter, in_ppn_persen.Enter, in_klaim.Enter, in_term.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_disc1.Leave, in_disc2.Leave, in_disc3.Leave, in_discrp.Leave, in_discount.Leave, in_ppn_persen.Leave, in_klaim.Leave, in_term.Leave
        numericLostFocus(sender)
    End Sub

    Private Sub in_qty_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
        keyshortenter(in_disc1, e)
    End Sub

    Private Sub in_disc1_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc1.KeyDown
        keyshortenter(in_disc2, e)
    End Sub

    Private Sub in_disc2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc2.KeyDown
        keyshortenter(in_disc3, e)
    End Sub

    Private Sub in_disc3_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc3.KeyDown
        keyshortenter(in_discrp, e)
    End Sub

    Private Sub in_discrp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_discrp.KeyDown
        If e.KeyCode = Keys.Enter Then
            addRowBarang()
            in_barang.Focus()
        End If
    End Sub

    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        indexrow = e.RowIndex
        dgvTotxt()
        dgv_barang.Rows.RemoveAt(e.RowIndex)
    End Sub

    Private Sub dgv_barang_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv_barang.RowsRemoved
        countbiaya()
    End Sub

    Private Sub in_discount_ValueChanged(sender As Object, e As EventArgs) Handles in_discount.Leave, in_ppn_persen.Leave, in_klaim.Leave
        countbiaya()
    End Sub

    Private Sub in_discount_KeyDown(sender As Object, e As KeyEventArgs) Handles in_discount.KeyUp
        keyshortenter(in_ppn_persen, e)
    End Sub

    Private Sub in_ppn_persen_KeyDown(sender As Object, e As KeyEventArgs) Handles in_ppn_persen.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = False
            cb_ppn_jenis.Focus()
            cb_ppn_jenis.DroppedDown = True
        End If
    End Sub

    Private Sub cb_ppn_jenis_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_ppn_jenis.SelectionChangeCommitted
        countbiaya()
        in_klaim.Focus()
    End Sub

    Private Sub in_klaim_KeyDown(sender As Object, e As KeyEventArgs) Handles in_klaim.KeyDown
        keyshortenter(bt_simpanbeli, e)
    End Sub

    Private Sub cb_status_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_status.SelectionChangeCommitted
        in_status_kode.Text = cb_status.SelectedValue
    End Sub
End Class