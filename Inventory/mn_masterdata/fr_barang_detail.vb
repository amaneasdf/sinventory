Public Class fr_barang_detail

    Private Sub loadData(kode As String)
        readcommd("SELECT * FROM data_barang_master WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            'Basic
            in_supplier.Text = rd.Item("barang_supplier")
            in_kode.Text = kode
            in_nama.Text = rd.Item("barang_nama")
            Try
                cb_jenis.SelectedValue = rd.Item("barang_jenis")
            Catch ex As Exception
                cb_jenis.SelectedValue = 0
            End Try
            Try
                cb_kategori.SelectedValue = rd.Item("barang_kategori")
            Catch ex As Exception
                'cb_kategori.SelectedIndex = 0
            End Try
            'satuan
            cb_sat_kecil.Text = rd.Item("barang_satuan_kecil")
            cb_sat_tengah.Text = rd.Item("barang_satuan_tengah")
            cb_sat_besar.Text = rd.Item("barang_satuan_besar")
            in_isi_tengah.Value = rd.Item("barang_satuan_tengah_jumlah")
            in_isi_besar.Value = rd.Item("barang_satuan_besar_jumlah")
            'harga
            in_harga_beli.Value = rd.Item("barang_harga_beli")
            in_harga_jual.Value = rd.Item("barang_harga_jual")
            in_harga_mt.Value = rd.Item("barang_harga_jual_mt")
            in_harga_horeka.Value = rd.Item("barang_harga_jual_horeka")
            in_harga_rita.Value = rd.Item("barang_harga_jual_rita")
            in_harga_disc.Value = rd.Item("barang_harga_jual_discount")
            in_beli_d1.Value = rd.Item("Barang_harga_beli_d1")
            in_beli_d2.Value = rd.Item("Barang_harga_beli_d2")
            in_beli_d3.Value = rd.Item("Barang_harga_beli_d3")
            in_beli_klaim.Value = rd.Item("Barang_harga_beli_klaim")
            in_jual_d1.Value = rd.Item("barang_harga_jual_d1")
            in_jual_d2.Value = rd.Item("barang_harga_jual_d2")
            in_jual_d3.Value = rd.Item("barang_harga_jual_d3")
            in_jual_d4.Value = rd.Item("barang_harga_jual_d4")
            in_jual_d5.Value = rd.Item("barang_harga_jual_d5")
            'other
            cb_status.SelectedValue = rd.Item("barang_status")
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

    End Sub

    Private Sub getSupplier(kode As String)
        op_con()
        readcommd("SELECT supplier_nama FROM data_supplier_master WHERE supplier_kode='" & kode & "'")
        If rd.HasRows Then
            in_suppliernama.Text = rd.Item("supplier_nama")
        Else
            in_suppliernama.Clear()
        End If
        rd.Close()
    End Sub

    Private Function loadCBGudang(kode As String) As DataTable
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT DISTINCT gudang_kode,CONCAT(gudang_kode,' : ',gudang_nama) as gudang_nama FROM data_barang_stok INNER JOIN data_barang_gudang ON gudang_kode=stock_gudang WHERE stock_barang='" & kode & "'")
        dt.Rows.Add({"all", "All"})
        Return dt
    End Function

    Private Sub getHisStock(kode As String, gudang As String, tglawal As Date, tglakhir As Date)
        Dim _tglawal As String = tglawal.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = tglakhir.ToString("yyyy-MM-dd")

        op_con()
        dgv_his_st.DataSource = getDataTablefromDB("getProductStockMovement('" & gudang & "','" & kode & "','" & tglawal.ToString("yyyy-MM-dd") & "','" & tglakhir.ToString("yyyy-MM-dd") & "')")
        dgv_his_st.Sort(dgv_his_st.Columns("his_tanggal"), System.ComponentModel.ListSortDirection.Descending)
    End Sub

    '------------drag form
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, lbl_title.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, lbl_title.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, lbl_title.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick, lbl_title.DoubleClick
        CenterToScreen()
    End Sub

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbarang.Click
        Me.Close()
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Tutup Form?", "Data Barang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbarang.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '---------------------------- numeric
    Private Sub in_stok_berat_Enter(sender As Object, e As EventArgs) Handles in_isi_tengah.Enter, in_isi_besar.Enter, in_harga_rita.Enter, in_harga_mt.Enter, in_harga_jual.Enter, in_harga_horeka.Enter, in_harga_beli.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_stok_berat_Leave(sender As Object, e As EventArgs) Handles in_isi_tengah.Leave, in_isi_besar.Leave, in_harga_rita.Leave, in_harga_mt.Leave, in_harga_jual.Leave, in_harga_horeka.Leave, in_harga_beli.Leave
        numericLostFocus(sender)
    End Sub

    '------------------- load
    Private Sub fr_barang_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_status
            .DataSource = statusBarang()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
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

        dt_akhir_st.MaxDate = Date.Today
        dt_awal_st.MaxDate = Date.Today

        op_con()
        If bt_simpanbarang.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadData(.Text)
            End With

            With cb_kodegd
                .DataSource = loadCBGudang(in_kode.Text)
                .DisplayMember = "gudang_nama"
                .ValueMember = "gudang_kode"
                .SelectedIndex = .Items.Count - 1
            End With

            'data supplier
            getSupplier(in_supplier.Text)

            'getHisStock(in_kode.Text, "all", dt_awal_st.Value, dt_akhir_st.Value)
        End If
    End Sub

    'save
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
            "barang_status='" & cb_status.SelectedValue & "'"
            }

        Me.Cursor = Cursors.WaitCursor
        op_con()
        If bt_simpanbarang.Text = "Simpan" Then
            cb_status.SelectedIndex = 0

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

    'input
    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_supplier_list.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(in_kode, e)
        End If
    End Sub

    Private Sub in_supplierLeave(sender As Object, e As EventArgs) Handles in_supplier.Leave
        in_supplier.Text = Trim(in_supplier.Text)
        If in_supplier.Text <> Nothing Then
            getSupplier(in_supplier.Text)
        Else
            in_suppliernama.Clear()
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
                    '.bt_search.PerformClick()
                End If
                .ShowDialog()
                in_supplier.Text = .returnkode
            End With
            getSupplier(in_supplier.Text)
        End Using
    End Sub

    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(in_nama, e)
    End Sub

    Private Sub in_nama_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nama.KeyDown
        keyshortenter(cb_jenis, e)
    End Sub

    Private Sub cb_jenis_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_jenis.KeyDown
        keyshortenter(cb_kategori, e)
    End Sub

    Private Sub cb_kategori_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_kategori.KeyDown
        keyshortenter(cb_sat_kecil, e)
    End Sub

    Private Sub cb_sat_kecil_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat_kecil.KeyDown
        keyshortenter(cb_sat_tengah, e)
    End Sub

    Private Sub cb_sat_tengah_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat_tengah.KeyDown
        keyshortenter(in_isi_tengah, e)
    End Sub

    Private Sub in_isi_tengah_KeyDown(sender As Object, e As KeyEventArgs) Handles in_isi_tengah.KeyDown
        keyshortenter(cb_sat_besar, e)
    End Sub

    Private Sub cb_sat_besar_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat_besar.KeyDown
        keyshortenter(in_isi_besar, e)
    End Sub

    Private Sub in_isi_besar_KeyDown(sender As Object, e As KeyEventArgs) Handles in_isi_besar.KeyDown
        keyshortenter(in_harga_beli, e)
    End Sub

    Private Sub cb_sat_kecil_Leave(sender As Object, e As EventArgs) Handles cb_sat_kecil.Leave
        lbl_satuan1.Text = cb_sat_kecil.Text
    End Sub

    Private Sub cb_sat_tengah_Leave(sender As Object, e As EventArgs) Handles cb_sat_tengah.Leave
        lbl_satuan2.Text = cb_sat_tengah.Text
    End Sub

    Private Sub in_harga_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_beli.KeyDown
        keyshortenter(in_harga_jual, e)
    End Sub

    Private Sub in_harga_jual_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_jual.KeyDown
        keyshortenter(in_harga_mt, e)
    End Sub

    Private Sub in_harga_mt_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_mt.KeyDown
        keyshortenter(in_harga_horeka, e)
    End Sub

    Private Sub in_harga_horeka_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_horeka.KeyDown
        keyshortenter(in_harga_rita, e)
    End Sub

    Private Sub in_harga_rita_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_rita.KeyDown
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
        keyshortenter(in_harga_disc, e)
    End Sub

    Private Sub in_harga_disc_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_disc.KeyDown
        keyshortenter(in_jual_d1, e)
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
End Class