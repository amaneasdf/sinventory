Public Class fr_beli_retur_detail
    Dim rowindex As Integer

    Private Sub loadDataRetur(kode As String)
        readcommd("SELECT * FROM data_pembelian_retur_faktur WHERE faktur_kode_bukti='" & kode & "'")
        If rd.HasRows Then
            in_no_bukti.Text = kode
            in_pajak.Text = rd.Item("faktur_pajak_no")
            date_tgl_trans.Value = rd.Item("faktur_tanggal_trans")
            date_tgl_pajak.Value = rd.Item("faktur_pajak_tanggal")
            in_no_faktur.Text = rd.Item("faktur_kode_faktur")
            in_no_faktur_ex.Text = rd.Item("faktur_kode_exfaktur")
            in_suratjalan.Text = rd.Item("faktur_surat_jalan")
            in_supplier.Text = rd.Item("faktur_supplier")
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
        setGudang(in_gudang.Text)
        setSupplier(in_supplier.Text)
        setReadOnly()
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

    Private Sub loadDataFaktur(kode As String)
        op_con()
        readcommd("SELECT faktur_gudang, faktur_supplier FROM data_pembelian_faktur WHERE faktur_kode='" & in_no_faktur.Text & "'")
        If rd.HasRows Then
            in_gudang.Text = rd.Item("faktur_gudang")
            in_supplier.Text = rd.Item("faktur_supplier")
        End If
        rd.Close()
        setGudang(in_gudang.Text)
        setSupplier(in_supplier.Text)
    End Sub

    Private Sub loadSatuanBrg(kode As String)
        op_con()
        readcommd("SELECT barang_satuan_kecil, barang_satuan_tengah, barang_satuan_besar FROM data_barang_master WHERE barang_kode='" & kode & "'")
        cb_sat.Items.Add(rd.Item("barang_satuan_kecil"))
        cb_sat.Items.Add(rd.Item("barang_satuan_tengah"))
        cb_sat.Items.Add(rd.Item("barang_satuan_besar"))
        rd.Close()
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
        Dim satuan As String = ""
        readcommd("SELECT barang_nama, trans_harga_beli, trans_qty, trans_satuan FROM data_pembelian_trans INNER JOIN data_barang_master ON barang_kode=trans_barang WHERE trans_faktur='" & in_no_faktur.Text & "' AND trans_barang='" & kode & "'")
        If rd.HasRows Then
            lbl_barang.Text = rd.Item("barang_nama")
            satuan = rd.Item("trans_satuan")
            in_harga_retur.Value = rd.Item("trans_harga_beli")
            in_qty.Maximum = rd.Item("trans_qty")
        End If
        rd.Close()
        loadSatuanBrg(kode)
        cb_sat.SelectedText = satuan
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
                .Cells("sat").Value = cb_sat.SelectedItem
                .Cells("harga").Value = in_harga_retur.Value
                .Cells("jml").Value = biayaPerItem()
            End With
        End With

        countBiaya()
        clearInputBarang()
        in_barang.Clear()
        in_barang.Focus()
    End Sub

    Private Sub dgvToTxt()
        With dgv_barang.Rows(rowindex)
            loadSatuanBrg(.Cells("kode").Value)
            in_barang.Text = .Cells("kode").Value
            lbl_barang.Text = .Cells("nama").Value
            in_qty.Value = .Cells("qty").Value
            cb_sat.SelectedItem = .Cells("sat").Value
            in_harga_retur.Text = .Cells("harga").Value
        End With
    End Sub

    Private Function biayaPerItem() As Double
        Dim x As Double = 0
        Dim y As Double = CDbl(in_harga_retur.Value)
        x = in_qty.Value * y

        Return x
    End Function

    Private Function jumlahBiayaPerItem() As Double
        Dim x As Double = 0
        For Each rows As DataGridViewRow In dgv_barang.Rows
            Console.WriteLine(rows.Cells("jml").Value)
            x += rows.Cells("jml").Value
        Next
        Return x
    End Function

    Private Sub countBiaya()
        Dim x As Double = jumlahBiayaPerItem()
        Dim z As Double = x
        If cb_ppn_jenis.SelectedValue = 0 Then
            z += x * in_ppn_persen.Value / 100
        End If
        Dim cc As Globalization.CultureInfo = Globalization.CultureInfo.GetCultureInfo("id-ID")
        in_jumlah.Text = x.ToString("N2", cc)
        in_netto.Text = z.ToString("N2", cc)
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

    Private Sub clearInputBarang()
        lbl_barang.Text = ""
        cb_sat.Items.Clear()
        in_harga_retur.Value = 0
        'in_barang.Clear()
        in_qty.Value = 0
        in_qty.Maximum = 99999
    End Sub

    Private Sub setReadOnly()
        Dim txt As TextBox() = {
            in_no_bukti, in_no_faktur, in_no_faktur_ex, in_pajak, in_gudang, in_supplier, in_suratjalan, in_barang
            }
        For Each x As TextBox In txt
            x.ReadOnly = True
        Next

        in_ppn_persen.Enabled = False
        cb_ppn_jenis.Enabled = False
    End Sub

    Private Sub clearDataFaktur()
        lbl_gudang.Text = ""
        lbl_supplier.Text = ""
        in_gudang.Clear()
        in_supplier.Clear()
    End Sub

    Private Sub fr_beli_retur_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_gudang.Text = ""
        lbl_supplier.Text = ""
        lbl_barang.Text = ""
        cb_sat.SelectedIndex = -1

        With cb_ppn_jenis
            .DataSource = jenisPPN()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
        With cb_status
            .DataSource = statusBarang()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
        With cb_bayar_jenis

        End With

        op_con()
        If bt_simpanreturbeli.Text = "OK" Then
            loadDataRetur(in_no_bukti.Text)
            loadDataReturBrg(in_no_bukti.Text)
            GroupBox4.Visible = True

        End If
    End Sub

    Private Sub bt_simpanjual_Click(sender As Object, e As EventArgs) Handles bt_simpanreturbeli.Click
        If Trim(in_no_bukti.Text) = "" Then
            MessageBox.Show("No.Bukti belum di input")
            in_no_bukti.Focus()
            Exit Sub
        End If
        If Trim(in_no_faktur.Text) = "" Then
            MessageBox.Show("No.Faktur belum di input")
            in_no_faktur.Focus()
            Exit Sub
        End If
        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum di input")
            in_barang.Focus()
            Exit Sub
        End If

        Dim querycheck As Boolean = False
        Dim dataFak As String()
        Dim dataBrg As String()
        Dim queryArr As New List(Of String)

        op_con()
        If bt_simpanreturbeli.Text = "Simpan" Then
            'TODO check no_bukti
            If checkdata("data_pembelian_retur_faktur", "'" & in_no_bukti.Text & "'", "faktur_kode_bukti") = True Then
                MessageBox.Show("No.Bukti " & in_no_bukti.Text & " sudah ada!")
                in_no_bukti.Select()
                Exit Sub
            End If

            dataFak = {
                "faktur_kode_bukti='" & in_no_bukti.Text & "'",
                "faktur_tanggal_trans='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_pajak_no='" & in_pajak.Text & "'",
                "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_gudang='" & in_gudang.Text & "'",
                "faktur_supplier='" & in_supplier.Text & "'",
                "faktur_kode_faktur='" & in_no_faktur.Text & "'",
                "faktur_kode_exfaktur='" & in_no_faktur_ex.Text & "'",
                "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text) & "'",
                "faktur_ppn_persen='" & in_ppn_persen.Value & "'",
                "faktur_ppn_jenis='" & cb_ppn_jenis.SelectedValue & "'",
                "faktur_netto='" & removeCommaThousand(in_netto.Text) & "'",
                "faktur_status=1",
                "faktur_reg_date=NOW()",
                "faktur_reg_alias='" & loggeduser.user_id & "'"
                }
            'TODO insert faktur
            'querycheck = commnd("INSERT INTO data_pembelian_retur_faktur SET " & String.Join(",", dataFak))
            queryArr.Add("INSERT INTO data_pembelian_retur_faktur SET " & String.Join(",", dataFak))

            For Each rows As DataGridViewRow In dgv_barang.Rows
                dataBrg = {
                "trans_faktur='" & in_no_bukti.Text & "'",
                "trans_tanggal='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                "trans_barang='" & rows.Cells(0).Value & "'",
                "trans_harga_retur='" & rows.Cells("harga").Value & "'",
                "trans_qty='" & rows.Cells("qty").Value & "'",
                "trans_satuan='" & rows.Cells("sat").Value & "'",
                "trans_jumlah='" & rows.Cells("jml").Value & "'",
                "trans_reg_date=NOW()",
                "trans_reg_alias='" & loggeduser.user_id & "'"
                }
                'TODO insert brg
                'querycheck = commnd("INSERT INTO data_pembelian_retur_trans SET " & String.Join(",", dataBrg))
                queryArr.Add("INSERT INTO data_pembelian_retur_trans SET " & String.Join(",", dataBrg))

                'TODO Update stok
                queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_return_beli=getSUMReturBeliPerGudang('{0}','{1}') +(countQTYJual('{0}','{2}','{3}')) WHERE stock_barang='{0}' AND stock_gudang='{1}'", rows.Cells(0).Value, in_gudang.Text, rows.Cells("qty").Value, rows.Cells("sat").Value))

            Next
        Else
            Me.Close()
        End If

        'begin transaction
        querycheck = startTrans(queryArr)

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmpembelian.in_cari.Clear()
            populateDGVUserCon("returbeli", "", frmreturbeli.dgv_list)
            Me.Close()
        End If
    End Sub

    Private Sub bt_bataljual_Click(sender As Object, e As EventArgs) Handles bt_batalreturbeli.Click
        Me.Close()
    End Sub

    Private Sub in_no_bukti_KeyDown(sender As Object, e As KeyEventArgs) Handles in_no_bukti.KeyDown
        keyshortenter(date_tgl_trans, e)
    End Sub

    Private Sub date_tgl_trans_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_trans.KeyDown
        keyshortenter(in_no_faktur, e)
    End Sub

    Private Sub in_no_faktur_KeyDown(sender As Object, e As KeyEventArgs) Handles in_no_faktur.KeyDown
        clearDataFaktur()
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    .query = "SELECT faktur_kode as kode, faktur_tanggal_trans as tgl, supplier_nama as supplier, gudang_nama as gudang FROM data_pembelian_faktur INNER JOIN data_supplier_master ON supplier_kode=faktur_supplier INNER JOIN data_barang_gudang ON gudang_kode=faktur_gudang ORDEr BY kode DESC"
                    .paramquery = "supplier LIKE'%{0}%' OR kode LIKE '%{0}%' OR gudang LIKE '%{0}%'"
                    .type = "beli"
                    .ShowDialog()
                    in_no_faktur.Text = .returnkode
                    in_gudang.ReadOnly = True
                    in_supplier.ReadOnly = True
                End With
            End Using
            in_no_faktur_ex.Focus()
            Exit Sub
        End If
        keyshortenter(in_no_faktur_ex, e)
    End Sub

    Private Sub in_no_faktur_Leave(sender As Object, e As EventArgs) Handles in_no_faktur.Leave
        loadDataFaktur(in_no_faktur.Text)
    End Sub

    Private Sub in_no_faktur_ex_KeyDown(sender As Object, e As KeyEventArgs) Handles in_no_faktur_ex.KeyDown
        keyshortenter(in_pajak, e)
    End Sub

    Private Sub in_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pajak.KeyDown
        keyshortenter(date_tgl_pajak, e)
    End Sub

    Private Sub date_tgl_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_pajak.KeyDown
        keyshortenter(in_suratjalan, e)
    End Sub

    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        lbl_gudang.Text = ""
        keyshortenter(in_supplier, e)
    End Sub

    Private Sub in_gudang_Leave(sender As Object, e As EventArgs) Handles in_gudang.Leave
        setGudang(in_gudang.Text)
    End Sub

    Private Sub in_suratjalan_KeyDown(sender As Object, e As KeyEventArgs) Handles in_suratjalan.KeyDown
        keyshortenter(in_gudang, e)
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        lbl_supplier.Text = ""
        'If e.KeyCode = Keys.Enter Then
        '    cb_je.DroppedDown = True
        '    cb_sat.Focus()
        'End If
        keyshortenter(in_barang, e)
    End Sub

    Private Sub in_supplier_Leave(sender As Object, e As EventArgs) Handles in_supplier.Leave
        setSupplier(in_supplier.Text)
    End Sub

    Private Sub cb_bayar_jenis_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_bayar_jenis.SelectionChangeCommitted
        in_barang.Focus()
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        clearInputBarang()
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    .query = "SELECT barang_nama as nama, barang_kode as kode, trans_qty as qty FROM data_pembelian_trans INNER JOIN data_barang_master ON barang_kode=trans_barang WHERE trans_faktur='" & in_no_faktur.Text & "'"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "barangfaktur"
                    .ShowDialog()
                    in_barang.Text = .returnkode
                End With
            End Using
            in_qty.Focus()
            Exit Sub

        ElseIf e.KeyCode = Keys.Enter Then
            'e.SuppressKeyPress = False
            'cb_sat.DroppedDown = True
            'cb_sat.Focus()
            keyshortenter(in_qty, e)
        End If
    End Sub

    Private Sub in_barang_Leave(sender As Object, e As EventArgs) Handles in_barang.Leave
        If in_no_faktur.Text <> "" And Trim(in_barang.Text) <> "" Then
            setBarang(in_barang.Text)
        End If
    End Sub

    Private Sub cb_sat_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_sat.SelectionChangeCommitted
        in_harga_retur.Focus()
    End Sub

    Private Sub in_qty_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = False
            cb_sat.DroppedDown = True
            cb_sat.Focus()
        End If
    End Sub

    Private Sub in_harga_retur_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_retur.KeyDown
        If e.KeyCode = Keys.Enter Then
            If bt_simpanreturbeli.Text = "Simpan" Then
                addRowBarang()
            End If
            in_barang.Focus()
        End If
    End Sub

    Private Sub in_ppn_persen_KeyDown(sender As Object, e As KeyEventArgs) Handles in_ppn_persen.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = False
            cb_ppn_jenis.Focus()
            cb_ppn_jenis.DroppedDown = True
        End If
    End Sub

    Private Sub in_ppn_persen_Leave(sender As Object, e As EventArgs) Handles in_ppn_persen.Leave
        countBiaya()
    End Sub

    Private Sub cb_ppn_jenis_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_ppn_jenis.SelectionChangeCommitted
        countbiaya()
        bt_simpanreturbeli.Focus()
    End Sub

    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_ppn_persen.Enter, in_harga_retur.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_ppn_persen.Leave, in_harga_retur.Leave
        numericLostFocus(sender)
    End Sub

    Private Sub cb_status_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_status.SelectionChangeCommitted
        in_status_kode.Text = cb_status.SelectedValue
    End Sub

    Private Sub fr_beli_retur_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_batalreturbeli.PerformClick()
        End If
    End Sub

    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        rowindex = e.RowIndex
        dgvToTxt()
        If bt_simpanreturbeli.Text = "Simpan" Then
            dgv_barang.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub
End Class