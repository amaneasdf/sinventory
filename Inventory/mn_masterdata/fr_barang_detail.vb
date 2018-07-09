Public Class fr_barang_detail

    '---------------------note
    'diskon, not yet
    'pajak, unfinished -> berdasarkan supplier, keluarin pajak atau tidak
    'periode -> 1 bulan/perbulan

    Private Sub loadDataBarang(kode As String)
        readcommd("SELECT * FROM data_barang_master WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            'tab 1
            'basic
            in_kode.Text = kode
            in_nama.Text = rd.Item("barang_nama")
            Try
                cb_jenis.SelectedValue = rd.Item("barang_jenis")
            Catch ex As Exception
                cb_jenis.SelectedValue = 0
            End Try
            '-------- kategori

            'harga
            in_harga_beli.Value = rd.Item("barang_harga_beli")
            in_harga_jual.Value = rd.Item("barang_harga_jual")
            in_harga_mt.Value = rd.Item("barang_harga_jual_mt")
            in_harga_horeka.Value = rd.Item("barang_harga_jual_horeka")
            in_harga_rita.Value = rd.Item("barang_harga_jual_rita")
            in_harga_disc.Value = rd.Item("barang_harga_jual_discount")

            'satuan
            cb_sat_kecil.Text = rd.Item("barang_satuan_kecil")
            cb_sat_tengah.Text = rd.Item("barang_satuan_tengah")
            cb_sat_besar.Text = rd.Item("barang_satuan_besar")
            in_isi_tengah.Value = rd.Item("barang_satuan_tengah_jumlah")
            in_isi_besar.Value = rd.Item("barang_satuan_besar_jumlah")

            'tab 2
            'pajak
            in_kode_pajak.Text = rd.Item("barang_status_pajak")
            cb_pajak.SelectedValue = in_kode_pajak.Text
            'load pajak increment -> if thy wanted more flexibility

            'harga2 otomatis ->event handler VVV
            'disk
            in_beli_d1.Value = rd.Item("Barang_harga_beli_d1")
            in_beli_d2.Value = rd.Item("Barang_harga_beli_d2")
            in_beli_d3.Value = rd.Item("Barang_harga_beli_d3")
            in_beli_klaim.Value = rd.Item("Barang_harga_beli_klaim")
            in_jual_d1.Value = rd.Item("barang_harga_jual_d1")
            in_jual_d2.Value = rd.Item("barang_harga_jual_d2")
            in_jual_d3.Value = rd.Item("barang_harga_jual_d3")
            in_jual_d4.Value = rd.Item("barang_harga_jual_d4")
            in_jual_d5.Value = rd.Item("barang_harga_jual_d5")

            'supplier
            in_supplier.Text = rd.Item("barang_supplier")

            'other
            in_stok_aktif.Value = rd.Item("barang_stok_minimal")
            in_stok_berat.Value = rd.Item("barang_berat")
            in_kode_status.Text = rd.Item("barang_status")
            cb_status.SelectedValue = in_kode_status.Text

            'user
            txtRegAlias.Text = rd.Item("barang_reg_alias")
            txtRegdate.Text = rd.Item("barang_reg_date")
            Try
                txtUpdDate.Text = rd.Item("barang_upd_date")
            Catch ex As Exception
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("barang_upd_alias")
        End If
        rd.Close()

        'satuan
        lbl_satuan1.Text = cb_sat_kecil.Text
        lbl_satuan2.Text = cb_sat_tengah.Text

        'daftar inventory/stock
        dgv_inv.DataSource = getDataTablefromDB("SELECT gudang_nama, stock_sisa FROM `data_barang_stok` INNER JOIN data_barang_gudang ON gudang_kode=stock_gudang WHERE stock_barang='" & kode & "';")
    End Sub

    Private Sub getSupplier(kode As String)
        op_con()
        Try
            readcommd("SELECT supplier_nama FROM data_supplier_master WHERE supplier_kode='" & kode & "'")
            If rd.HasRows Then
                'in_namasupplier.Text = rd.Item("supplier_nama")
                'in_alamatsupplier.Text = rd.Item("supplier_alamat")
                'in_telpsupplier.Text = rd.Item("supplier_telpon1")
                'in_emailsupplier.Text = rd.Item("supplier_email")
                in_suppliernama.Text = rd.Item("supplier_nama")
            Else
                'For Each x As TextBox In {in_namasupplier, in_alamatsupplier, in_telpsupplier, in_emailsupplier}
                '    x.Clear()
                'Next
                in_suppliernama.Clear()
            End If
            rd.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub getSum(kode As String, tglawal As Date, tglakhir As Date)
        Dim _tglawal As String = tglawal.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = tglakhir.ToString("yyyy-MM-dd")

        op_con()
        dgv_su.DataSource = getDataTablefromDB("getSUMTransProdPerMonth('" & kode & "','" & _tglawal & "','" & _tglakhir & "')")
    End Sub

    Private Sub getHisStock(kode As String, gudang As String, tglawal As Date, tglakhir As Date)
        Dim _tglawal As String = tglawal.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = tglakhir.ToString("yyyy-MM-dd")

        op_con()
        dgv_his_st.DataSource = getDataTablefromDB("getProductStockMovement('" & gudang & "','" & kode & "','" & tglawal.ToString("yyyy-MM-dd") & "','" & tglakhir.ToString("yyyy-MM-dd") & "')")
        dgv_his_st.Sort(dgv_his_st.Columns("his_tanggal"), System.ComponentModel.ListSortDirection.Descending)
    End Sub

    Private Function loadCBGudang(kode As String) As DataTable
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT DISTINCT gudang_kode,CONCAT(gudang_kode,' : ',gudang_nama) as gudang_nama FROM data_barang_stok INNER JOIN data_barang_gudang ON gudang_kode=stock_gudang WHERE stock_barang='" & kode & "'")
        dt.Rows.Add({"all", "All"})
        Return dt
    End Function

    Private Sub countPPn(output As String())
        If output.Contains("all") Then
            output = {
                "beli", "jual", "mt", "horeka", "rita"
                }
        End If

        If cb_pajak.SelectedValue <> "0" Then
            If output.Contains("beli") Then
                in_ppn_in.Text = commaThousand(ppn * in_harga_beli.Value)
            End If

            If output.Contains("jual") Then
                in_ppn_out.Text = commaThousand(ppn * in_harga_jual.Value)
            End If

            If output.Contains("mt") Then
                in_ppn_mt.Text = commaThousand(ppn * in_harga_mt.Value)
            End If

            If output.Contains("horeka") Then
                in_ppn_horeka.Text = commaThousand(ppn * in_harga_horeka.Value)
            End If

            If output.Contains("rita") Then
                in_ppn_rita.Text = commaThousand(ppn * in_harga_rita.Value)
            End If

            If cb_pajak.SelectedValue = "2" Then
                If output.Contains("jual") Then
                    in_ppnbm_out.Text = commaThousand(ppnbm * in_harga_jual.Value)
                End If

                If output.Contains("mt") Then
                    in_ppnbm_mt.Text = commaThousand(ppnbm * in_harga_mt.Value)
                End If

                If output.Contains("horeka") Then
                    in_ppnbm_horeka.Text = commaThousand(ppnbm * in_harga_horeka.Value)
                End If

                If output.Contains("rita") Then
                    in_ppnbm_rita.Text = commaThousand(ppnbm * in_harga_rita.Value)
                End If
            End If
        End If
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

    Private Sub fr_barang_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_status
            .DataSource = statusBarang()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With
        With cb_pajak
            .DataSource = statusBarangPajak()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
        With cb_jenis
            .DataSource = jenisBarang()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With
        Dim cbsat As ComboBox() = {cb_sat_besar, cb_sat_kecil, cb_sat_tengah}
        For Each x As ComboBox In cbsat
            With x
                .DataSource = jenisSatuan()
                .DisplayMember = "Text"
                .ValueMember = "Value"
                .SelectedIndex = -1
            End With
        Next

        For Each x As DataGridViewColumn In {su_avgprice, su_avgsale, su_totalprice, su_totalsale}
            x.DefaultCellStyle = dgvstyle_currency
        Next

        dt_akhir.MaxDate = Date.Today
        dt_awal.MaxDate = Date.Today

        op_con()
        If bt_simpanbarang.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadDataBarang(.Text)
            End With

            With cb_kodegd
                .DataSource = loadCBGudang(in_kode.Text)
                .DisplayMember = "gudang_nama"
                .ValueMember = "gudang_kode"
                .SelectedIndex = .Items.Count - 1
            End With

            'ppn
            countPPn({"all"})

            getSum(in_kode.Text, dt_awal.Value, dt_akhir.Value)
            getHisStock(in_kode.Text, "all", dt_awal_st.Value, dt_akhir_st.Value)

            'data supplier
            getSupplier(in_supplier.Text)
        End If
    End Sub

    Private Sub cb_jenis_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_jenis.SelectionChangeCommitted
        cb_kategori.Focus()
    End Sub

    Private Sub cb_kategori_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_kategori.SelectionChangeCommitted
        cb_sat_kecil.Focus()
    End Sub

    Private Sub cb_jenis_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_jenis.KeyDown
        keyshortenter(cb_kategori, e)
    End Sub

    Private Sub cb_kategori_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_kategori.KeyDown
        keyshortenter(cb_sat_kecil, e)
    End Sub

    Private Sub cb_sat_kecil_TextChanged(sender As Object, e As EventArgs) Handles cb_sat_kecil.SelectionChangeCommitted
        cb_sat_tengah.Focus()
        lbl_satuan1.Text = cb_sat_kecil.SelectedValue
    End Sub

    Private Sub cb_sat_kecil_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat_kecil.KeyDown
        'keyshortenter(cb_sat_tengah, e)
        If e.KeyCode = Keys.Enter Then
            lbl_satuan1.Text = cb_sat_kecil.Text
            cb_sat_tengah.Focus()
        End If
    End Sub

    Private Sub cb_sat_tengah_TextChanged(sender As Object, e As EventArgs) Handles cb_sat_tengah.SelectionChangeCommitted
        in_isi_tengah.Focus()
        lbl_satuan2.Text = cb_sat_tengah.SelectedValue
    End Sub

    Private Sub cb_sat_tengah_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat_tengah.KeyDown
        'keyshortenter(in_isi_tengah, e)
        If e.KeyCode = Keys.Enter Then
            lbl_satuan2.Text = cb_sat_tengah.Text
            in_isi_tengah.Focus()
        End If
    End Sub

    Private Sub cb_sat_besar_TextChanged(sender As Object, e As EventArgs) Handles cb_sat_besar.SelectionChangeCommitted
        in_isi_besar.Focus()
    End Sub

    Private Sub cb_sat_besar_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat_besar.KeyDown
        keyshortenter(in_isi_besar, e)
    End Sub

    Private Sub bt_simpanbarang_Click(sender As Object, e As EventArgs) Handles bt_simpanbarang.Click
        Dim data As String()
        Dim querycheck As Boolean = False
        If Trim(in_kode.Text) = Nothing Then
            MessageBox.Show("Kode belum di input")
            in_kode.Focus()
            Exit Sub
        End If
        If Trim(in_nama.Text) = Nothing Then
            MessageBox.Show("Nama belum di input")
            in_nama.Focus()
            Exit Sub
        End If
        If cb_jenis.SelectedValue = Nothing Then
            MessageBox.Show("Jenis barang belum di input")
            cb_jenis.DroppedDown = True
            cb_jenis.Focus()
            Exit Sub
        End If

        'If Trim(in_kode_status.Text) = Nothing Then
        '    MessageBox.Show("Status belum di input")
        '    cb_status.Focus()
        '    Exit Sub
        'End If

        data = {
            "barang_kode='" & in_kode.Text & "'",
            "barang_nama='" & in_nama.Text & "'",
            "barang_supplier='" & in_supplier.Text & "'",
            "barang_jenis='" & cb_jenis.SelectedValue & "'",
            "barang_satuan_kecil='" & cb_sat_kecil.Text & "'",
            "barang_satuan_tengah='" & cb_sat_tengah.Text & "'",
            "barang_satuan_tengah_jumlah='" & in_isi_tengah.Value & "'",
            "barang_satuan_besar='" & cb_sat_besar.Text & "'",
            "barang_satuan_besar_jumlah='" & in_isi_besar.Value & "'",
            "barang_harga_beli='" & in_harga_beli.Value & "'",
            "barang_harga_jual='" & in_harga_jual.Value & "'",
            "barang_harga_beli_d1='" & in_beli_d1.Value & "'",
            "barang_harga_beli_d2='" & in_beli_d2.Value & "'",
            "barang_harga_beli_d3='" & in_beli_d3.Value & "'",
            "barang_harga_beli_klaim='" & in_beli_klaim.Value & "'",
            "barang_harga_jual_mt='" & in_harga_mt.Value & "'",
            "barang_harga_jual_rita='" & in_harga_rita.Value & "'",
            "barang_harga_jual_horeka='" & in_harga_horeka.Value & "'",
            "barang_harga_jual_discount='" & in_harga_disc.Value & "'",
            "barang_harga_jual_d1='" & in_jual_d1.Value & "'",
            "barang_harga_jual_d2='" & in_jual_d2.Value & "'",
            "barang_harga_jual_d3='" & in_jual_d3.Value & "'",
            "barang_harga_jual_d4='" & in_jual_d4.Value & "'",
            "barang_harga_jual_d5='" & in_jual_d5.Value & "'",
            "barang_stok_minimal='" & in_stok_aktif.Value & "'",
            "barang_berat='" & in_stok_berat.Value & "'",
            "barang_status='" & in_kode_status.Text & "'",
            "barang_status_pajak='" & in_kode_pajak.Text & "'"
            }

        Me.Cursor = Cursors.WaitCursor
        op_con()
        If bt_simpanbarang.Text = "Simpan" Then
            cb_status.SelectedIndex = 0
            in_kode_status.Text = "1"

            If checkdata("data_barang_master", "'" & in_kode.Text & "'", "barang_kode") Then
                MessageBox.Show("Kode Barang " & in_kode.Text & " sudah ada")
                in_kode.Focus()
                Exit Sub
            End If

            querycheck = commnd("INSERT INTO data_barang_master SET " & String.Join(",", data) & ",barang_reg_date=NOW(), barang_reg_alias='" & loggeduser.user_id & "'")

        ElseIf bt_simpanbarang.Text = "Update" Then
            data = data.Skip(1).ToArray

            querycheck = commnd("UPDATE data_barang_master SET " & String.Join(",", data) & ",barang_upd_date=NOW(), barang_upd_alias='" & loggeduser.user_id & "' WHERE barang_kode='" & in_kode.Text & "'")
        End If

        Me.Cursor = Cursors.Default

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            'createLogAct("BARANG " & in_kode.Text)
            frmbank.in_cari.Clear()
            populateDGVUserCon("barang", "", frmbarang.dgv_list)
            'Me.Close()
            bt_simpanbarang.Text = "Update"
        End If
    End Sub

    Private Sub bt_batalbarang_Click(sender As Object, e As EventArgs) Handles bt_batalbarang.Click
        If MessageBox.Show("Tutup Form?", "Data Barang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    '-------------------------- Close Button
    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbarang.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '------------------------- supplier
    Private Sub in_supplier_Leave(sender As Object, e As EventArgs) Handles in_supplier.Leave
        getSupplier(in_supplier.Text)
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_supplier_list.PerformClick()
        Else
            keyshortenter(in_kode, e)
        End If
    End Sub

    Private Sub bt_supplier_list_Click(sender As Object, e As EventArgs) Handles bt_supplier_list.Click
        Using search As New fr_search_dialog
            With search
                .query = "SELECT supplier_kode as kode, supplier_nama as nama FROM data_supplier_master"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "supplier"
                If Trim(in_supplier.Text) <> Nothing Then
                    .returnkode = in_supplier.Text
                    .in_cari.Text = in_supplier.Text
                    .bt_search.PerformClick()
                End If
                .ShowDialog()
                in_supplier.Text = .returnkode
            End With
        End Using
        in_kode.Focus()
        Exit Sub
    End Sub

    '------------------------ basic
    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(in_nama, e)
    End Sub

    Private Sub in_nama_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nama.KeyDown
        keyshortenter(cb_jenis, e)
    End Sub

    Private Sub in_isi_tengah_KeyDown(sender As Object, e As KeyEventArgs) Handles in_isi_tengah.KeyDown
        keyshortenter(cb_sat_besar, e)
    End Sub

    Private Sub in_isi_besar_KeyDown(sender As Object, e As KeyEventArgs) Handles in_isi_besar.KeyDown
        keyshortenter(in_harga_beli, e)
    End Sub

    '---------------------------- numeric
    Private Sub in_stok_berat_Enter(sender As Object, e As EventArgs) Handles in_stok_berat.Enter, in_stok_aktif.Enter, in_jual_d5.Enter, in_jual_d4.Enter, in_jual_d3.Enter, in_jual_d2.Enter, in_jual_d1.Enter, in_isi_tengah.Enter, in_isi_besar.Enter, in_harga_rita2.Enter, in_harga_rita.Enter, in_harga_mt2.Enter, in_harga_mt.Enter, in_harga_jual2.Enter, in_harga_jual.Enter, in_harga_horeka2.Enter, in_harga_horeka.Enter, in_harga_disc.Enter, in_harga_beli2.Enter, in_harga_beli.Enter, in_beli_klaim.Enter, in_beli_d3.Enter, in_beli_d2.Enter, in_beli_d1.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_stok_berat_Leave(sender As Object, e As EventArgs) Handles in_stok_berat.Leave, in_stok_aktif.Leave, in_jual_d5.Leave, in_jual_d4.Leave, in_jual_d3.Leave, in_jual_d2.Leave, in_jual_d1.Leave, in_isi_tengah.Leave, in_isi_besar.Leave, in_harga_rita2.Leave, in_harga_mt2.Leave, in_harga_jual2.Leave, in_harga_horeka2.Leave, in_harga_disc.Leave, in_harga_beli2.Leave, in_beli_klaim.Leave, in_beli_d3.Leave, in_beli_d2.Leave, in_beli_d1.Leave, in_harga_rita.Leave, in_harga_mt.Leave, in_harga_jual.Leave, in_harga_horeka.Leave, in_harga_beli.Leave
        numericLostFocus(sender)
    End Sub

    '------------------------- price key down
    Private Sub in_harga_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_beli.KeyDown
        keyshortenter(in_harga_jual, e)
    End Sub

    Private Sub in_harga_jual_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_jual.KeyDown
        keyshortenter(in_harga_mt, e)
    End Sub

    Private Sub in_harga_mt_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_mt.KeyDown
        keyshortenter(in_harga_horeka, e)
    End Sub

    Private Sub in_harga_horeka_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_horeka.KeyDown, in_harga_beli.KeyDown
        keyshortenter(in_harga_rita, e)
    End Sub

    Private Sub in_harga_rita_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_rita.KeyDown
        If e.KeyCode = Keys.Enter Then
            With cb_sat_kecil
                .DroppedDown = True
                .Focus()
            End With
        End If
    End Sub

    Private Sub link_price_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_price.LinkClicked
        tab_prod.SelectedTab = TabPage2
    End Sub

    Private Sub dgv_inv_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgv_inv.RowsAdded
        Dim x As Integer = 0
        For Each rows As DataGridViewRow In dgv_inv.Rows
            x += rows.Cells("inv_qty").Value
        Next
        lbl_totalstock.Text = x
    End Sub

    Private Sub cb_status_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_status.KeyPress, cb_jenis.KeyPress, cb_kategori.KeyPress, cb_pajak.KeyPress
        e.Handled = True
    End Sub

    '-------------------------- Price Value Change
    Private Sub in_harga_beli_ValueChanged(sender As Object, e As EventArgs) Handles in_harga_beli.ValueChanged
        in_harga_beli2.Value = in_harga_beli.Value
        countPPn({"beli"})
    End Sub

    Private Sub in_harga_beli2_ValueChanged(sender As Object, e As EventArgs) Handles in_harga_beli2.ValueChanged
        in_harga_beli.Value = in_harga_beli2.Value
        countPPn({"beli"})
    End Sub

    Private Sub in_harga_jual_ValueChanged(sender As Object, e As EventArgs) Handles in_harga_jual.ValueChanged
        in_harga_jual2.Value = in_harga_jual.Value
        countPPn({"jual"})
    End Sub

    Private Sub in_harga_jual2_ValueChanged(sender As Object, e As EventArgs) Handles in_harga_jual2.ValueChanged
        in_harga_jual.Value = in_harga_jual2.Value
        countPPn({"jual"})
    End Sub

    Private Sub in_harga_mt_ValueChanged(sender As Object, e As EventArgs) Handles in_harga_mt.ValueChanged
        in_harga_mt2.Value = in_harga_mt.Value
        countPPn({"mt"})
    End Sub

    Private Sub in_harga_mt2_ValueChanged(sender As Object, e As EventArgs) Handles in_harga_mt2.ValueChanged
        in_harga_mt.Value = in_harga_mt2.Value
        countPPn({"mt"})
    End Sub

    Private Sub in_harga_horeka_ValueChanged(sender As Object, e As EventArgs) Handles in_harga_horeka.ValueChanged
        in_harga_horeka2.Value = in_harga_horeka.Value
        countPPn({"horeka"})
    End Sub

    Private Sub in_harga_horeka2_ValueChanged(sender As Object, e As EventArgs) Handles in_harga_horeka2.ValueChanged
        in_harga_horeka.Value = in_harga_horeka2.Value
        countPPn({"horeka"})
    End Sub

    Private Sub in_harga_rita_ValueChanged(sender As Object, e As EventArgs) Handles in_harga_rita.ValueChanged
        in_harga_rita2.Value = in_harga_rita.Value
        countPPn({"rita"})
    End Sub

    Private Sub in_harga_rita2_ValueChanged(sender As Object, e As EventArgs) Handles in_harga_rita2.ValueChanged
        in_harga_rita.Value = in_harga_rita2.Value
        countPPn({"rita"})
    End Sub

    '---------------------- tabpage price
    Private Sub cb_pajak_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_pajak.SelectionChangeCommitted
        in_kode_pajak.Text = cb_pajak.SelectedValue
        in_harga_beli2.Focus()
    End Sub

    Private Sub cb_pajak_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_pajak.SelectedIndexChanged
        For Each x As TextBox In {in_ppn_in, in_ppn_out, in_ppn_mt, in_ppn_rita, in_ppn_horeka, in_ppnbm_horeka, in_ppnbm_mt, in_ppnbm_out, in_ppnbm_rita}
            x.Text = "0,00"
        Next
        countPPn({"all"})
    End Sub

    Private Sub cb_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_pajak.KeyDown
        keyshortenter(in_harga_beli2, e)
    End Sub

    Private Sub in_harga_beli2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_beli2.KeyDown
        keyshortenter(in_beli_d1, e)
    End Sub

    Private Sub in_beli_d1_KeyDown(sender As Object, e As KeyEventArgs) Handles in_beli_d1.KeyDown
        keyshortenter(in_beli_d2, e)
    End Sub

    Private Sub in_beli_d2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_beli_d2.KeyDown
        keyshortenter(in_beli_d3, e)
    End Sub

    Private Sub in_beli_d3_KeyDown(sender As Object, e As KeyEventArgs) Handles in_beli_d3.KeyDown
        keyshortenter(in_beli_klaim, e)
    End Sub

    Private Sub in_beli_klaim_KeyDown(sender As Object, e As KeyEventArgs) Handles in_beli_klaim.KeyDown
        keyshortenter(in_harga_jual2, e)
    End Sub

    Private Sub in_harga_jual2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_jual2.KeyDown
        keyshortenter(in_harga_mt2, e)
    End Sub

    Private Sub in_jual_d1_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jual_d1.KeyDown
        keyshortenter(in_jual_d2, e)
    End Sub

    Private Sub in_jual_d2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jual_d2.KeyDown
        keyshortenter(in_jual_d3, e)
    End Sub

    Private Sub in_jual_d3_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jual_d3.KeyDown
        keyshortenter(in_jual_d4, e)
    End Sub

    Private Sub in_jual_d4_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jual_d4.KeyDown
        keyshortenter(in_jual_d5, e)
    End Sub

    Private Sub in_jual_d5_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jual_d5.KeyDown
        keyshortenter(bt_simpanbarang, e)
    End Sub

    '------------------ tab page sum sale
    Private Sub bt_su_view_Click(sender As Object, e As EventArgs) Handles bt_su_view.Click
        getSum(in_kode.Text, dt_awal.Value, dt_akhir.Value)
    End Sub

    Private Sub dt_awal_ValueChanged(sender As Object, e As EventArgs) Handles dt_awal.ValueChanged
        dt_akhir.MinDate = dt_awal.Value
    End Sub

    Private Sub dt_akhir_ValueChanged(sender As Object, e As EventArgs) Handles dt_akhir.ValueChanged
        dt_awal.MaxDate = dt_akhir.Value
    End Sub

    '------------------ tab page stock history
    Private Sub bt_view_st_Click(sender As Object, e As EventArgs) Handles bt_view_st.Click
        getHisStock(in_kode.Text, cb_kodegd.SelectedValue, dt_awal_st.Value, dt_akhir_st.Value)
    End Sub

    Private Sub dt_awal_st_ValueChanged(sender As Object, e As EventArgs) Handles dt_awal_st.ValueChanged
        dt_akhir_st.MinDate = dt_awal_st.Value
    End Sub

    Private Sub dt_akhir_st_ValueChanged(sender As Object, e As EventArgs) Handles dt_akhir_st.ValueChanged
        dt_awal_st.MaxDate = dt_akhir_st.Value
    End Sub
End Class