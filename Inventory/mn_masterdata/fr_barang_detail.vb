Public Class fr_barang_detail

    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_NCLBUTTONDOWN As Integer = 161
        Const WM_SYSCOMMAND As Integer = 274
        Const HTCAPTION As Integer = 2
        Const SC_MOVE As Integer = 61456

        If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32 = SC_MOVE) Then
            Exit Sub
        End If

        If (m.Msg = WM_NCLBUTTONDOWN) AndAlso (m.WParam.ToInt32 = HTCAPTION) Then
            Exit Sub
        End If

        MyBase.WndProc(m)
    End Sub

    Private Sub loadDataBarang(kode As String)
        readcommd("SELECT * FROM data_barang_master WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = kode
            in_nama.Text = rd.Item("barang_nama")
            in_supplier.Text = rd.Item("barang_supplier")
            in_kode_jenis.Text = rd.Item("barang_jenis")
            cb_jenis.SelectedValue = in_kode_jenis.Text
            cb_sat_kecil.SelectedValue = rd.Item("barang_satuan_kecil")
            cb_sat_tengah.SelectedValue = rd.Item("barang_satuan_tengah")
            cb_sat_besar.SelectedValue = rd.Item("barang_satuan_besar")
            in_isi_tengah.Text = rd.Item("barang_satuan_tengah_jumlah")
            in_isi_besar.Text = rd.Item("barang_satuan_besar_jumlah")
            in_ket.Text = rd.Item("barang_keterangan")
            in_stok_awal.Value = rd.Item("barang_stok_awal")
            in_stok_aktif.Value = rd.Item("barang_stok_minimal")
            in_stok_berat.Value = rd.Item("barang_berat")
            in_harga_beli.Value = rd.Item("barang_harga_beli")
            in_harga_jual.Value = rd.Item("barang_harga_jual")
            in_harga_mt.Value = rd.Item("barang_harga_jual_mt")
            in_harga_horeka.Value = rd.Item("barang_harga_jual_horeka")
            in_harga_rita.Value = rd.Item("barang_harga_jual_rita")
            in_harga_disc.Value = rd.Item("barang_harga_jual_discount")
            in_beli_d1.Value = rd.Item("Barang_harga_beli_d1")
            in_beli_d2.value = rd.Item("Barang_harga_beli_d2")
            in_beli_d3.value = rd.Item("Barang_harga_beli_d3")
            in_beli_klaim.value = rd.Item("Barang_harga_beli_klaim")
            in_jual_d1.Value = rd.Item("barang_harga_jual_d1")
            in_jual_d2.value = rd.Item("barang_harga_jual_d2")
            in_jual_d3.value = rd.Item("barang_harga_jual_d3")
            in_jual_d4.value = rd.Item("barang_harga_jual_d4")
            in_jual_d5.value = rd.Item("barang_harga_jual_d5")
            txtRegAlias.Text = rd.Item("barang_reg_alias")
            txtRegdate.Text = rd.Item("barang_reg_date")
            in_kode_status.Text = rd.Item("barang_status")
            cb_status.SelectedValue = in_kode_status.Text
            in_kode_pajak.Text = rd.Item("barang_status_pajak")
            cb_pajak.SelectedValue = in_kode_pajak.Text
            Try
                txtUpdDate.Text = rd.Item("barang_upd_date")
            Catch ex As Exception
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("barang_upd_alias")
        End If
        rd.Close()
        getSupplier(in_supplier.Text)
    End Sub

    Private Sub getSupplier(kode As String)
        op_con()
        Try
            readcommd("SELECT supplier_nama FROM data_supplier_master WHERE supplier_kode='" & kode & "'")
            If rd.HasRows Then
                lbl_supplier.Text = rd.Item("supplier_nama")
            Else
                lbl_supplier.Text = ""
            End If
            rd.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
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
            .SelectedIndex = -1
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
            .SelectedIndex = -1
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
        lbl_supplier.Text = ""

        op_con()
        If bt_simpanbarang.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadDataBarang(.Text)
            End With
        End If
    End Sub

    Private Sub cb_jenis_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_jenis.SelectionChangeCommitted
        in_kode_jenis.Text = cb_jenis.SelectedValue
        With cb_sat_kecil
            .DroppedDown = True
            .Focus()
        End With
    End Sub

    Private Sub cb_sat_kecil_TextChanged(sender As Object, e As EventArgs) Handles cb_sat_kecil.SelectionChangeCommitted
        lbl_satuan1.Text = cb_sat_kecil.SelectedValue
        With cb_sat_tengah
            .DroppedDown = True
            .Focus()
        End With
    End Sub

    Private Sub cb_sat_tengah_TextChanged(sender As Object, e As EventArgs) Handles cb_sat_tengah.SelectionChangeCommitted
        lbl_satuan2.Text = cb_sat_tengah.SelectedValue
        in_isi_tengah.Focus()
    End Sub

    Private Sub cb_sat_besar_TextChanged(sender As Object, e As EventArgs) Handles cb_sat_besar.SelectionChangeCommitted
        lbl_satuan4.Text = lbl_satuan3.Text = cb_sat_besar.SelectedValue
        in_isi_besar.Focus()
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
        If Trim(in_kode_status.Text) = Nothing Then
            MessageBox.Show("Status belum di input")
            cb_status.Focus()
            Exit Sub
        End If

        data = {
            "barang_kode='" & in_kode.Text & "'",
            "barang_nama='" & in_nama.Text & "'",
            "barang_supplier='" & in_supplier.Text & "'",
            "barang_jenis='" & in_kode_jenis.Text & "'",
            "barang_satuan_kecil='" & cb_sat_kecil.SelectedValue & "'",
            "barang_satuan_tengah='" & cb_sat_tengah.SelectedValue & "'",
            "barang_satuan_tengah_jumlah='" & in_isi_tengah.Text & "'",
            "barang_satuan_besar='" & cb_sat_besar.SelectedValue & "'",
            "barang_satuan_besar_jumlah='" & in_isi_besar.Text & "'",
            "barang_keterangan='" & in_ket.Text & "'",
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
            "barang_stok_awal='" & in_stok_awal.Value & "'",
            "barang_stok_minimal='" & in_stok_aktif.Value & "'",
            "barang_berat='" & in_stok_berat.Value & "'",
            "barang_status='" & in_kode_status.Text & "'",
            "barang_status_pajak='" & in_kode_pajak.Text & "'"
            }

        op_con()
        If bt_simpanbarang.Text = "Simpan" Then
            If checkdata("data_barang_master", "'" & in_kode.Text & "'", "barang_kode") Then
                MessageBox.Show("Kode Barang " & in_kode.Text & " sudah ada")
                in_kode.Focus()
                Exit Sub
            End If

            querycheck = commnd("INSERT INTO data_barang_master SET " & String.Join(",", data) & ",barang_reg_date=NOW(), barang_reg_alias='" & loggeduser.user_id & "'")

            'TODO set stok awal?

        ElseIf bt_simpanbarang.Text = "Update" Then
            data = data.Skip(1).ToArray

            querycheck = commnd("UPDATE data_barang_master SET " & String.Join(",", data) & ",barang_upd_date=NOW(), barang_upd_alias='" & loggeduser.user_id & "' WHERE barang_kode='" & in_kode.Text & "'")
        End If

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmbank.in_cari.Clear()
            populateDGVUserCon("barang", "", frmbarang.dgv_list)
            Me.Dispose()
        End If
    End Sub

    Private Sub cb_status_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_status.SelectionChangeCommitted
        in_kode_status.Text = cb_status.SelectedValue
        With cb_pajak
            .DroppedDown = True
            .Focus()
        End With
    End Sub

    Private Sub cb_pajak_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_pajak.SelectionChangeCommitted
        in_kode_pajak.Text = cb_pajak.SelectedValue
        in_harga_beli.Focus()
    End Sub

    Private Sub bt_batalbarang_Click(sender As Object, e As EventArgs) Handles bt_batalbarang.Click
        Me.Dispose()
    End Sub

    Private Sub fr_barang_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_batalbarang.PerformClick()
        End If
    End Sub

    Private Sub in_supplier_Leave(sender As Object, e As EventArgs) Handles in_supplier.Leave
        getSupplier(in_supplier.Text)
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        lbl_supplier.Text = ""
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = False
            cb_jenis.DroppedDown = True
            cb_jenis.Focus()
        End If
    End Sub

    Private Sub in_stok_berat_Enter(sender As Object, e As EventArgs) Handles in_stok_berat.Enter, in_stok_awal.Enter, in_stok_aktif.Enter, in_jual_d5.Enter, in_jual_d4.Enter, in_jual_d3.Enter, in_jual_d2.Enter, in_jual_d1.Enter, in_harga_rita.Enter, in_harga_mt.Enter, in_harga_jual.Enter, in_harga_horeka.Enter, in_harga_disc.Enter, in_harga_beli.Enter, in_beli_klaim.Enter, in_beli_d3.Enter, in_beli_d2.Enter, in_beli_d1.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_stok_berat_Leave(sender As Object, e As EventArgs) Handles in_stok_berat.Leave, in_stok_awal.Leave, in_stok_aktif.Leave, in_jual_d5.Leave, in_jual_d4.Leave, in_jual_d3.Leave, in_jual_d2.Leave, in_jual_d1.Leave, in_harga_rita.Leave, in_harga_mt.Leave, in_harga_jual.Leave, in_harga_horeka.Leave, in_harga_disc.Leave, in_harga_beli.Leave, in_beli_klaim.Leave, in_beli_d3.Leave, in_beli_d2.Leave, in_beli_d1.Leave
        numericLostFocus(sender)
    End Sub

    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(in_nama, e)
    End Sub

    Private Sub in_nama_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nama.KeyDown
        keyshortenter(in_supplier,e)
    End Sub

    Private Sub in_isi_tengah_KeyDown(sender As Object, e As KeyEventArgs) Handles in_isi_tengah.KeyDown
        If e.KeyCode = Keys.Enter Then
            With cb_sat_besar
                .DroppedDown = True
                .Focus()
            End With
        End If
    End Sub

    Private Sub in_isi_besar_KeyDown(sender As Object, e As KeyEventArgs) Handles in_isi_besar.KeyDown
        keyshortenter(in_stok_awal, e)
    End Sub

    Private Sub in_stok_awal_KeyDown(sender As Object, e As KeyEventArgs) Handles in_stok_awal.KeyDown
        keyshortenter(in_stok_aktif, e)
    End Sub

    Private Sub in_stok_aktif_KeyDown(sender As Object, e As KeyEventArgs) Handles in_stok_aktif.KeyDown
        keyshortenter(in_stok_berat, e)
    End Sub

    Private Sub in_stok_berat_KeyDown(sender As Object, e As KeyEventArgs) Handles in_stok_berat.KeyDown
        If e.KeyCode = Keys.Enter Then
            With cb_status
                .DroppedDown = True
                .Focus()
            End With
        End If
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
        keyshortenter(in_harga_disc, e)
    End Sub

    Private Sub in_harga_disc_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_disc.KeyDown
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