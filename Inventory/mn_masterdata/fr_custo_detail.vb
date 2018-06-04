Public Class fr_custo_detail

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

    Private Sub loadDataCusto(kode As String)
        'Dim kodesales As String
        readcommd("SELECT * FROM data_customer_master where customer_kode='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = kode
            'kodesales =rd.Item("customer_salesman")
            in_kode_sales.Text = rd.Item("customer_salesman")
            in_nama_custo.Text = rd.Item("customer_nama")
            in_status_kode.Text = rd.Item("customer_status")
            cb_status.SelectedValue = in_status_kode.Text
            in_tipe_kode.Text = rd.Item("customer_jenis")
            cb_tipe.SelectedValue = in_tipe_kode.Text
            in_alamat_custo.Text = rd.Item("customer_alamat")
            in_alamat_blok.Text = rd.Item("customer_alamat_blok")
            in_alamat_no.Text = rd.Item("customer_alamat_nomor")
            in_alamat_rt.Text = rd.Item("customer_alamat_rt")
            in_alamat_rw.Text = rd.Item("customer_alamat_rw")
            in_alamat_kelurahan.Text = rd.Item("customer_alamat_kelurahan")
            in_alamat_kecamatan.Text = rd.Item("customer_kecamatan")
            in_alamat_kabupaten.Text = rd.Item("customer_kabupaten")
            in_alamat_pasar.Text = rd.Item("customer_pasar")
            in_alamat_provinsi.Text = rd.Item("customer_provinsi")
            in_kodepos.Text = rd.Item("customer_kodepos")
            in_telpcusto.Text = rd.Item("customer_telpon")
            in_faxcusto.Text = rd.Item("customer_fax")
            in_cpcusto.Text = rd.Item("customer_cp")
            in_nik.Text = rd.Item("customer_nik")
            in_npwp.Text = rd.Item("customer_npwp")
            date_tgl_pkp.Value = rd.Item("customer_tanggal_pkp")
            in_pajak_nama.Text = rd.Item("customer_pajak_nama")
            in_pajak_jabatan.Text = rd.Item("customer_pajak_jabatan")
            in_pajak_alamat.Text = rd.Item("customer_pajak_alamat")
            in_kunjungan_hr.Text = rd.Item("customer_kunjungan_hari")
            in_piutang.Value = rd.Item("customer_max_piutang")
            in_kode_diskon.Text = rd.Item("Customer_kriteria_discount")
            cb_diskon.SelectedValue = in_kode_diskon.Text
            in_kode_harga.Text = rd.Item("Customer_kriteria_harga_jual")
            cb_harga.SelectedValue = in_kode_harga.Text
            in_term.Value = rd.Item("customer_term")
            txtRegdate.Text = rd.Item("customer_reg_date")
            txtRegAlias.Text = rd.Item("customer_reg_alias")
            Try
                txtUpdDate.Text = rd.Item("customer_upd_date")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("customer_upd_alias")
        End If
        rd.Close()
        setNamaSales(in_kode_sales.Text)
    End Sub

    Private Sub setNamaSales(kode As String)
        op_con()
        Try
            readcommd("SELECT salesman_nama FROM data_salesman_master WHERE salesman_kode='" & kode & "'")
            If rd.HasRows Then
                lbl_sales.Text = rd.Item("salesman_nama")
            Else
                lbl_sales.Text = ""
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

    Private Sub fr_custo_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_status
            .DataSource = statusCusto()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With

        With cb_tipe
            .DataSource = jenisCusto()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With

        With cb_diskon
            .DataSource = jenisDiskon()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With

        With cb_harga
            .DataSource = jenisHargaJual()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With

        lbl_sales.Text = ""

        op_con()
        If bt_simpancusto.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadDataCusto(.Text)
            End With
        End If
    End Sub

    Private Sub bt_simpansupplier_Click(sender As Object, e As EventArgs) Handles bt_simpancusto.Click
        Dim data As String()
        'Dim dataCol As String()
        Dim querycheck As Boolean = False

        If bt_simpancusto.Text = "Simpan" Then
            If Trim(in_kode.Text) = Nothing Then
                MessageBox.Show("Kode Customer belum di input")
                in_kode.Focus()
                Exit Sub
            End If

            If Trim(in_kode_sales.Text) = Nothing Then
                MessageBox.Show("Kode Sales belum di input")
                in_kode_sales.Focus()
                Exit Sub
            End If
        End If

        If Trim(in_nama_custo.Text) = Nothing Then
            MessageBox.Show("Nama Customer belum di input")
            in_nama_custo.Focus()
            Exit Sub
        End If

        If Trim(in_status_kode.Text) = Nothing Then
            MessageBox.Show("Status Customer belum di input")
            cb_status.Focus()
            Exit Sub
        End If

        If Trim(in_tipe_kode.Text) = Nothing Then
            MessageBox.Show("Tipe Customer belum di input")
            cb_tipe.Focus()
            Exit Sub
        End If

        op_con()
        If bt_simpancusto.Text = "Simpan" Then
            If checkdata("data_customer_master", "'" & in_kode.Text & "'", "customer_kode") Then
                MessageBox.Show("Kode Customer " & in_kode.Text & " sudah ada")
                in_kode.Focus()
                Exit Sub
            End If

            data = {
                "customer_kode='" & in_kode.Text & "'",
                "customer_jenis='" & in_tipe_kode.Text & "'",
                "customer_salesman='" & in_kode_sales.Text & "'",
                "customer_nama='" & in_nama_custo.Text & "'",
                "customer_alamat='" & in_alamat_custo.Text & "'",
                "customer_alamat_blok='" & in_alamat_blok.Text & "'",
                "customer_alamat_nomor='" & in_alamat_no.Text & "'",
                "customer_alamat_rt='" & in_alamat_rt.Text & "'",
                "customer_alamat_rw='" & in_alamat_rw.Text & "'",
                "customer_alamat_kelurahan='" & in_alamat_kelurahan.Text & "'",
                "customer_kecamatan='" & in_alamat_kecamatan.Text & "'",
                "customer_kabupaten='" & in_alamat_kabupaten.Text & "'",
                "customer_pasar='" & in_alamat_pasar.Text & "'",
                "customer_provinsi='" & in_alamat_provinsi.Text & "'",
                "customer_kodepos='" & in_kodepos.Text & "'",
                "customer_telpon='" & in_telpcusto.Text & "'",
                "customer_fax='" & in_faxcusto.Text & "'",
                "customer_cp='" & in_cpcusto.Text & "'",
                "customer_nik='" & in_nik.Text & "'",
                "customer_npwp='" & in_npwp.Text & "'",
                "customer_tanggal_pkp='" & date_tgl_pkp.Value.ToString("yyyy-MM-dd") & "'",
                "customer_pajak_nama='" & in_pajak_nama.Text & "'",
                "customer_pajak_jabatan='" & in_pajak_jabatan.Text & "'",
                "customer_pajak_alamat='" & in_pajak_alamat.Text & "'",
                "customer_kunjungan_hari='" & in_kunjungan_hr.Text & "'",
                "customer_max_piutang='" & in_piutang.Value & "'",
                "Customer_kriteria_discount='" & in_kode_diskon.Text & "'",
                "Customer_kriteria_harga_jual='" & in_kode_harga.Text & "'",
                "customer_term='" & in_term.Value & "'",
                "customer_status='" & in_status_kode.Text & "'",
                "customer_reg_date=NOW()",
                "customer_reg_alias='" & loggeduser.user_id & "'"
                }
            'querycheck = commnd("INSERT INTO data_customer_master(" & String.Join(",", dataCol) & ") VALUES(" & String.Join(",", data) & ")")
            querycheck = commnd("INSERT INTO data_customer_master SET " & String.Join(",", data) & "")
        ElseIf bt_simpancusto.Text = "Update" Then
            data = {
                "customer_jenis='" & in_tipe_kode.Text & "'",
                "customer_salesman='" & in_kode_sales.Text & "'",
                "customer_nama='" & in_nama_custo.Text & "'",
                "customer_alamat='" & in_alamat_custo.Text & "'",
                "customer_alamat_blok='" & in_alamat_blok.Text & "'",
                "customer_alamat_nomor='" & in_alamat_no.Text & "'",
                "customer_alamat_rt='" & in_alamat_rt.Text & "'",
                "customer_alamat_rw='" & in_alamat_rw.Text & "'",
                "customer_alamat_kelurahan='" & in_alamat_kelurahan.Text & "'",
                "customer_kecamatan='" & in_alamat_kecamatan.Text & "'",
                "customer_kabupaten='" & in_alamat_kabupaten.Text & "'",
                "customer_pasar='" & in_alamat_pasar.Text & "'",
                "customer_provinsi='" & in_alamat_provinsi.Text & "'",
                "customer_kodepos='" & in_kodepos.Text & "'",
                "customer_telpon='" & in_telpcusto.Text & "'",
                "customer_fax='" & in_faxcusto.Text & "'",
                "customer_cp='" & in_cpcusto.Text & "'",
                "customer_nik='" & in_nik.Text & "'",
                "customer_npwp='" & in_npwp.Text & "'",
                "customer_tanggal_pkp='" & date_tgl_pkp.Value.ToString("yyyy-MM-dd") & "'",
                "customer_pajak_nama='" & in_pajak_nama.Text & "'",
                "customer_pajak_jabatan='" & in_pajak_jabatan.Text & "'",
                "customer_pajak_alamat='" & in_pajak_alamat.Text & "'",
                "customer_kunjungan_hari='" & in_kunjungan_hr.Text & "'",
                "customer_max_piutang='" & in_piutang.Text & "'",
                "Customer_kriteria_discount='" & in_kode_diskon.Text & "'",
                "Customer_kriteria_harga_jual='" & in_kode_harga.Text & "'",
                "customer_term='" & in_term.Value & "'",
                "customer_status='" & in_status_kode.Text & "'",
                "customer_upd_date=NOW()",
                "customer_upd_alias='" & loggeduser.user_id & "'"
                }
            querycheck = commnd("UPDATE data_customer_master SET " & String.Join(",", data) & " WHERE customer_kode='" & in_kode.Text & "'")
        End If

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmcusto.in_cari.Clear()
            populateDGVUserCon("custo", "", frmcusto.dgv_list)
            Me.Close()
        End If
    End Sub

    Private Sub bt_batalsupplier_Click(sender As Object, e As EventArgs) Handles bt_batalcusto.Click
        Me.Close()
    End Sub

    Private Sub cb_status_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_status.SelectionChangeCommitted
        in_status_kode.Text = cb_status.SelectedValue
        cb_tipe.DroppedDown = True
        cb_tipe.Focus()
    End Sub

    Private Sub cb_tipe_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_tipe.SelectionChangeCommitted
        in_tipe_kode.Text = cb_tipe.SelectedValue
        Try
            readcommd("SELECT hargajual_kode FROM `data_customer_hargajual` INNER JOIN data_customer_jenis ON hargajual_kode=jenis_def_jual WHERE jenis_kode='" & in_tipe_kode.Text & "'")
            Console.WriteLine(rd.Item("hargajual_kode"))
            If rd.HasRows Then
                in_kode_harga.Text = rd.Item("hargajual_kode")
                cb_harga.SelectedValue = in_kode_harga.Text
                cb_diskon.SelectedIndex = 0
                in_kode_diskon.Text = cb_diskon.SelectedValue
            End If
            rd.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        in_telpcusto.Focus()
    End Sub

    Private Sub cb_diskon_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_diskon.SelectionChangeCommitted
        in_kode_diskon.Text = cb_diskon.SelectedValue
        cb_harga.DroppedDown = True
        cb_harga.Focus()
    End Sub

    Private Sub cb_harga_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_harga.SelectionChangeCommitted
        in_kode_harga.Text = cb_harga.SelectedValue
        in_term.Focus()
    End Sub

    Private Sub in_term_Enter(sender As Object, e As EventArgs) Handles in_piutang.Enter, in_term.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_term_Leave(sender As Object, e As EventArgs) Handles in_term.Leave, in_piutang.Leave
        numericLostFocus(sender)
    End Sub

    Private Sub fr_custo_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_batalcusto.PerformClick()
        End If
    End Sub

    Private Sub in_kode_sales_Leave(sender As Object, e As EventArgs) Handles in_kode_sales.Leave
        setNamaSales(in_kode_sales.Text)
    End Sub

    Private Sub in_kode_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode_sales.KeyDown
        lbl_sales.Text = ""
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    .query = "SELECT salesman_kode as kode, salesman_nama as nama FROM data_salesman_master;"
                    .paramquery = "kode LIKE '%{0}%' OR nama LIKE '%{0}%'"
                    .type = "sales"
                    .ShowDialog()
                    in_kode_sales.Text = .returnkode
                End With
            End Using
            in_nama_custo.Focus()
            Exit Sub
        End If
        keyshortenter(in_nama_custo, e)
    End Sub

    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(in_kode_sales, e)
    End Sub

    Private Sub in_nama_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nama_custo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            cb_status.DroppedDown = True
            cb_status.Focus()
        End If
    End Sub

    Private Sub in_telpcusto_KeyDown(sender As Object, e As KeyEventArgs) Handles in_telpcusto.KeyDown
        keyshortenter(in_faxcusto, e)
    End Sub

    Private Sub in_faxcusto_KeyDown(sender As Object, e As KeyEventArgs) Handles in_faxcusto.KeyDown
        keyshortenter(in_cpcusto, e)
    End Sub

    Private Sub in_cpcusto_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cpcusto.KeyDown
        keyshortenter(in_alamat_custo, e)
    End Sub

    Private Sub in_alamat_blok_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_blok.KeyDown
        keyshortenter(in_alamat_no, e)
    End Sub

    Private Sub in_alamat_no_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_no.KeyDown
        keyshortenter(in_alamat_rt, e)
    End Sub

    Private Sub in_alamat_rt_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_rt.KeyDown
        keyshortenter(in_alamat_rw, e)
    End Sub

    Private Sub in_alamat_rw_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_rw.KeyDown
        keyshortenter(in_alamat_kelurahan, e)
    End Sub

    Private Sub in_alamat_kelurahan_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_kelurahan.KeyDown
        keyshortenter(in_alamat_kecamatan, e)
    End Sub

    Private Sub in_alamat_kecamatan_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_kecamatan.KeyDown
        keyshortenter(in_alamat_kabupaten, e)
    End Sub

    Private Sub in_alamat_kabupaten_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_kabupaten.KeyDown
        keyshortenter(in_alamat_pasar, e)
    End Sub

    Private Sub in_alamat_pasar_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_pasar.KeyDown
        keyshortenter(in_alamat_provinsi, e)
    End Sub

    Private Sub in_alamat_provinsi_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_provinsi.KeyDown
        keyshortenter(in_kodepos, e)
    End Sub

    Private Sub in_kodepos_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kodepos.KeyDown
        keyshortenter(in_nik, e)
    End Sub

    Private Sub in_nik_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nik.KeyDown
        keyshortenter(in_npwp, e)
    End Sub

    Private Sub in_npwp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_npwp.KeyDown
        keyshortenter(date_tgl_pkp, e)
    End Sub

    Private Sub date_tgl_pkp_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_pkp.KeyDown
        keyshortenter(in_pajak_nama, e)
    End Sub

    Private Sub in_pajak_nama_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pajak_nama.KeyDown
        keyshortenter(in_pajak_jabatan, e)
    End Sub

    Private Sub in_pajak_jabatan_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pajak_jabatan.KeyDown
        keyshortenter(in_pajak_alamat, e)
    End Sub

    Private Sub in_kunjungan_hr_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kunjungan_hr.KeyDown
        keyshortenter(in_kunjungan_pola, e)
    End Sub

    Private Sub in_kunjungan_pola_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kunjungan_pola.KeyDown
        keyshortenter(in_piutang, e)
    End Sub

    Private Sub in_piutang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_piutang.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            cb_diskon.DroppedDown = True
            cb_diskon.Focus()
        End If
    End Sub

    Private Sub in_term_KeyDown(sender As Object, e As KeyEventArgs) Handles in_term.KeyDown
        keyshortenter(bt_simpancusto, e)
    End Sub
End Class