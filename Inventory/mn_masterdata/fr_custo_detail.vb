Public Class fr_custo_detail
    Private gdstatus As Integer = 1
    Private act As String = "INSERT"

    Private Sub loadDataCusto(kode As String)
        'Dim kodesales As String
        readcommd("SELECT * FROM data_customer_master where customer_kode='" & kode & "' ORDER BY customer_version DESC LIMIT 1")
        If rd.HasRows Then
            in_kode.Text = kode
            in_nama_custo.Text = rd.Item("customer_nama")
            gdstatus = rd.Item("customer_status")
            cb_tipe.SelectedValue = rd.Item("customer_jenis")
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
            cb_diskon.SelectedValue = rd.Item("Customer_kriteria_discount")
            cb_harga.SelectedValue = rd.Item("Customer_kriteria_harga_jual")
            in_term.Value = rd.Item("customer_term")
        End If
        rd.Close()

        Dim q As String = "SELECT " _
                              & "reg.customer_reg_date,reg.customer_reg_alias, " _
                              & "upd.customer_reg_date as customer_upd_date, " _
                              & "upd.customerg_reg_alias as customer_upd_alias " _
                          & "FROM (SELECT " _
                              & "customer_kode, customer_reg_date,customer_reg_alias, customer_version " _
                              & "FROM data_customer_master WHERE customer_kode='{0}' ORDER BY customer_version ASC LIMIT 1 " _
                          & ") reg LEFT JOIN (SELECT " _
                              & "customer_kode, customer_reg_date,customer_reg_alias, customer_version " _
                              & "FROM data_customer_master WHERE customer_kode='{0}' ORDER BY customer_version DESC LIMIT 1 " _
                          & ") upd ON reg.customer_kode=upd.customer_kode"
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            txtRegdate.Text = rd.Item("customer_reg_date")
            txtRegAlias.Text = rd.Item("customer_reg_alias")
            txtUpdDate.Text = rd.Item("customer_upd_date")
            txtUpdAlias.Text = rd.Item("customer_upd_alias")
        End If
        rd.Close()
    End Sub

    Private Function setStatus(statcode As Integer) As String
        Dim x As String = "A"
        Select Case statcode
            Case 1
                x = "Aktif"
            Case 2
                x = "NonAktif"
            Case 9
                x = "Delete"
            Case Else
                x = "Err"
        End Select
        Return x
    End Function

    Private Sub writeLogAct(kode As String)
        Dim ver, dataid As String
        Dim q As String = "SELECT CONCAT_WS('/',customer_id,customer_kode,customer_version), customer_version FROM data_customer_master WHERE customer_kode ='" & kode & "' ORDER BY customer_version DESC LIMIT 1"

        readcommd(q)
        If rd.HasRows Then
            ver = rd.Item("customer_version")
            dataid = rd.Item(0)
        Else
            ver = "-1"
            dataid = "err"
        End If
        rd.Close()

        If ver = "0" Then
            act = "INSERT"
        ElseIf CInt(ver) > 0 And gdstatus <> 9 Then
            act = "UPDATE"
        ElseIf CInt(ver) < 0 Then
            act = "ERR"
        End If
        Console.Write(act & "-" & dataid)

        createLogAct(act, "data_customer_master", dataid)
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

    '----------------close
    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Tutup Form?", "Data Customer", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalcusto.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '------------------ numeric
    Private Sub in_piutang_Enter(sender As Object, e As EventArgs) Handles in_term.Enter, in_piutang.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_piutang_Leave(sender As Object, e As EventArgs) Handles in_term.Leave, in_piutang.Leave
        numericLostFocus(sender)
    End Sub

    '----------------- cb disable input
    Private Sub cb_tipe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_tipe.KeyPress, cb_harga.KeyPress, cb_diskon.KeyPress
        e.Handled = True
    End Sub

    '---------- load
    Private Sub fr_custo_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_tipe
            .DataSource = jenisCusto()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        With cb_diskon
            .DataSource = jenisDiskon()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        With cb_harga
            .DataSource = jenisHargaJual()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        op_con()
        in_status_kode.Text = setStatus(gdstatus)

        If bt_simpancusto.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadDataCusto(.Text)
            End With
        End If

        in_nama_custo.Focus()
    End Sub

    Private Sub bt_simpansupplier_Click(sender As Object, e As EventArgs) Handles bt_simpancusto.Click
        Dim data, dataCol As String()
        Dim querycheck As Boolean = False
        Dim query As String = "INSERT INTO data_customer_master({0}) SELECT {1} FROM data_customer_master WHERE customer_kode={2}"

        'DONE : TODO : (?) : GENERATE KODE GUDANG -> PREVENT DUPLICATE AND ACCIDENTALY OVERWRITE EXISTING DATA
        'TODO : (?) : ADD REFFERRAL CODE INPUT
        If Trim(in_nama_custo.Text) = Nothing Then
            MessageBox.Show("Nama Customer belum di input")
            in_nama_custo.Focus()
            Exit Sub
        End If

        If cb_tipe.SelectedValue = Nothing Then
            MessageBox.Show("Tipe Customer belum di input")
            cb_tipe.Focus()
            Exit Sub
        End If

        op_con()
        If MessageBox.Show("Simpan Data Customer?", "Data Customer", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'WITH DATA-VERSION-ING  & USER ACT LOG
            If Trim(in_kode.Text) = Nothing Then
                Dim x As Integer = 0
                readcommd("SELECT SUBSTR(customer_kode,3,5) FROM data_customer_master GROUP BY customer_kode ORDER BY customer_kode DESC LIMIT 1")
                If rd.HasRows Then
                    x = CInt(rd.Item(0)) + 1
                Else
                    x = 1
                End If
                rd.Close()
                in_kode.Text = "CT" & x.ToString("D5")
            End If

            dataCol = {
                "customer_kode", "customer_jenis", "customer_nama", "customer_alamat",
                "customer_alamat_blok", "customer_alamat_nomor", "customer_alamat_rt", "customer_alamat_rw",
                "customer_alamat_kelurahan", "customer_kecamatan", "customer_kabupaten", "customer_pasar",
                "customer_provinsi", "customer_kodepos", "customer_telpon", "customer_fax", "customer_cp",
                "customer_nik", "customer_npwp", "customer_tanggal_pkp", "customer_pajak_nama", "customer_pajak_jabatan",
                "customer_pajak_alamat", "customer_kunjungan_hari", "customer_max_piutang", "Customer_kriteria_discount",
                "Customer_kriteria_harga_jual", "customer_term", "customer_status", "customer_reg_date", "customer_reg_alias",
                "customer_version"
                }

            data = {
                "'" & in_kode.Text & "'",
                "'" & cb_tipe.SelectedValue & "'",
                "'" & in_nama_custo.Text & "'",
                "'" & in_alamat_custo.Text & "'",
                "'" & in_alamat_blok.Text & "'",
                "'" & in_alamat_no.Text & "'",
                "'" & in_alamat_rt.Text & "'",
                "'" & in_alamat_rw.Text & "'",
                "'" & in_alamat_kelurahan.Text & "'",
                "'" & in_alamat_kecamatan.Text & "'",
                "'" & in_alamat_kabupaten.Text & "'",
                "'" & in_alamat_pasar.Text & "'",
                "'" & in_alamat_provinsi.Text & "'",
                "'" & in_kodepos.Text & "'",
                "'" & in_telpcusto.Text & "'",
                "'" & in_faxcusto.Text & "'",
                "'" & in_cpcusto.Text & "'",
                "'" & in_nik.Text & "'",
                "'" & in_npwp.Text & "'",
                "'" & date_tgl_pkp.Value.ToString("yyyy-MM-dd") & "'",
                "'" & in_pajak_nama.Text & "'",
                "'" & in_pajak_jabatan.Text & "'",
                "'" & in_pajak_alamat.Text & "'",
                "'" & in_kunjungan_hr.Text & "'",
                "'" & in_piutang.Value & "'",
                "'" & cb_diskon.SelectedValue & "'",
                "'" & cb_harga.SelectedValue & "'",
                "'" & in_term.Value & "'",
                "'" & gdstatus & "'",
                "NOW()",
                "'" & loggeduser.user_id & "'",
                "MAX(customer_version) + 1"
                }
            Dim q As String = String.Format(query, String.Join(",", dataCol), String.Join(",", data), "'" & in_kode.Text & "'")
            Console.WriteLine(q)
            querycheck = commnd(q)

            If querycheck = False Then
                Exit Sub
            Else
                'TODO : WRITE LOG
                writeLogAct(in_kode.Text)
                MessageBox.Show("Data tersimpan")
                frmcusto.in_cari.Clear()
                populateDGVUserCon("custo", "", frmcusto.dgv_list)
                Me.Close()
            End If
        End If
    End Sub

    '----------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpancusto.PerformClick()
    End Sub

    Private Sub mn_status_switch_Click(sender As Object, e As EventArgs) Handles mn_status_switch.Click
        Select Case gdstatus
            Case 1
                gdstatus = 2
            Case 2
                gdstatus = 1
            Case 9
                gdstatus = 1
                act = "UPDATE"
            Case Else
                Exit Sub
        End Select
        in_status_kode.Text = setStatus(gdstatus)
    End Sub

    Private Sub mn_status_del_Click(sender As Object, e As EventArgs) Handles mn_status_del.Click
        If MessageBox.Show("Hapus Data Customer?", "Data Customer", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            gdstatus = 9
            in_status_kode.Text = setStatus(gdstatus)
            act = "DELETE"
        End If
    End Sub

    '----------------- input
    Private Sub in_nama_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nama_custo.KeyDown
        keyshortenter(cb_tipe, e)
    End Sub

    Private Sub cb_tipe_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_tipe.KeyDown
        keyshortenter(in_alamat_custo, e)
    End Sub

    Private Sub cb_tipe_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_tipe.SelectionChangeCommitted
        Try
            readcommd("SELECT hargajual_kode FROM `data_customer_hargajual` INNER JOIN data_customer_jenis ON hargajual_kode=jenis_def_jual WHERE jenis_kode='" & cb_tipe.SelectedValue & "'")
            Console.WriteLine(rd.Item("hargajual_kode"))
            If rd.HasRows Then
                cb_harga.SelectedValue = rd.Item("hargajual_kode")
                cb_diskon.SelectedIndex = 0
            End If
            rd.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        'in_alamat_custo.Focus()
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
        keyshortenter(in_telpcusto, e)
    End Sub

    Private Sub in_kodepos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_kodepos.KeyPress, in_telpcusto.KeyPress, in_faxcusto.KeyPress, in_nik.KeyPress, in_npwp.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub in_telpcusto_KeyDown(sender As Object, e As KeyEventArgs) Handles in_telpcusto.KeyDown
        keyshortenter(in_faxcusto, e)
    End Sub

    Private Sub in_faxcusto_KeyDown(sender As Object, e As KeyEventArgs) Handles in_faxcusto.KeyDown
        keyshortenter(in_cpcusto, e)
    End Sub

    Private Sub in_cpcusto_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cpcusto.KeyDown
        keyshortenter(in_kunjungan_hr, e)
    End Sub

    Private Sub in_kunjungan_hr_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kunjungan_hr.KeyDown
        keyshortenter(in_kunjungan_pola, e)
    End Sub

    Private Sub in_kunjungan_pola_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kunjungan_pola.KeyDown
        keyshortenter(in_piutang, e)
    End Sub

    Private Sub in_piutang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_piutang.KeyDown
        keyshortenter(cb_diskon, e)
    End Sub

    Private Sub cb_diskon_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_diskon.KeyDown
        keyshortenter(cb_harga, e)
    End Sub

    Private Sub cb_harga_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_harga.KeyDown
        keyshortenter(in_term, e)
    End Sub

    Private Sub in_term_KeyDown(sender As Object, e As KeyEventArgs) Handles in_term.KeyDown
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
End Class