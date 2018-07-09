Public Class fr_custo_detail

    'Private Sub cb_tipe_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_tipe.SelectionChangeCommitted
    '    Try
    '        readcommd("SELECT hargajual_kode FROM `data_customer_hargajual` INNER JOIN data_customer_jenis ON hargajual_kode=jenis_def_jual WHERE jenis_kode='" & cb_tipe.SelectedValue & "'")
    '        Console.WriteLine(rd.Item("hargajual_kode"))
    '        If rd.HasRows Then
    '            cb_harga.SelectedValue = rd.Item("hargajual_kode")
    '            cb_diskon.SelectedIndex = 0
    '        End If
    '        rd.Close()
    '    Catch ex As Exception
    '        Console.WriteLine(ex.Message)
    '    End Try
    '    in_telpcusto.Focus()
    'End Sub

    Private Sub loadDataCusto(kode As String)
        'Dim kodesales As String
        readcommd("SELECT * FROM data_customer_master where customer_kode='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = kode
            'kodesales =rd.Item("customer_salesman")
            in_kode_sales.Text = rd.Item("customer_salesman")
            cb_sales.SelectedValue = in_kode_sales.Text
            in_nama_custo.Text = rd.Item("customer_nama")
            cb_status.SelectedValue = rd.Item("customer_status")
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
    End Sub

    'Private Sub setNamaSales(kode As String)
    '    op_con()
    '    Try
    '        readcommd("SELECT salesman_nama FROM data_salesman_master WHERE salesman_kode='" & kode & "'")
    '        If rd.HasRows Then
    '            cb_sales.SelectedValue = rd.Item("salesman_nama")
    '        Else
    '            lbl_sales.Text = ""
    '        End If
    '        rd.Close()
    '    Catch ex As Exception
    '        Console.WriteLine(ex.Message)
    '    End Try
    'End Sub

    '------------drag form
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick
        CenterToScreen()
    End Sub

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalcusto.Click
        Me.Close()
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
    Private Sub cb_tipe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_tipe.KeyPress, cb_status.KeyPress, cb_harga.KeyPress, cb_diskon.KeyPress
        e.Handled = True
    End Sub

    '---------- load
    Private Sub fr_custo_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_status
            .DataSource = statusCusto()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

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

        With cb_sales
            .DataSource = getDataTablefromDB("SELECT salesman_kode, salesman_nama FROM data_salesman_master")
            .DisplayMember = "salesman_nama"
            .ValueMember = "salesman_kode"
            .SelectedIndex = -1
        End With

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


        If Trim(in_kode.Text) = Nothing And bt_simpancusto.Text = "Simpan" Then
            MessageBox.Show("Kode Customer belum di input")
            in_kode.Focus()
            Exit Sub
        End If
        If Trim(in_kode_sales.Text) = Nothing Then
            MessageBox.Show("Sales belum di input")
            in_kode_sales.Focus()
            Exit Sub
        End If

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
        If bt_simpancusto.Text = "Simpan" Then
            If checkdata("data_customer_master", "'" & in_kode.Text & "'", "customer_kode") Then
                MessageBox.Show("Kode Customer " & in_kode.Text & " sudah ada")
                in_kode.Focus()
                Exit Sub
            End If

            data = {
                "customer_kode='" & in_kode.Text & "'",
                "customer_jenis='" & cb_tipe.SelectedValue & "'",
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
                "Customer_kriteria_discount='" & cb_diskon.SelectedValue & "'",
                "Customer_kriteria_harga_jual='" & cb_harga.SelectedValue & "'",
                "customer_term='" & in_term.Value & "'",
                "customer_status='" & cb_status.SelectedValue & "'",
                "customer_reg_date=NOW()",
                "customer_reg_alias='" & loggeduser.user_id & "'"
                }
            'querycheck = commnd("INSERT INTO data_customer_master(" & String.Join(",", dataCol) & ") VALUES(" & String.Join(",", data) & ")")
            querycheck = commnd("INSERT INTO data_customer_master SET " & String.Join(",", data) & "")
        ElseIf bt_simpancusto.Text = "Update" Then
            data = {
                "customer_jenis='" & cb_tipe.SelectedValue & "'",
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
                "Customer_kriteria_discount='" & cb_diskon.SelectedValue & "'",
                "Customer_kriteria_harga_jual='" & cb_harga.SelectedValue & "'",
                "customer_term='" & in_term.Value & "'",
                "customer_status='" & cb_status.SelectedValue & "'",
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

    '----------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpancusto.PerformClick()
    End Sub

    Private Sub mn_cancelorder_Click(sender As Object, e As EventArgs) Handles mn_deact.Click
        If mn_deact.Text = "Deactivate" Then
            cb_status.SelectedValue = "2"
            mn_deact.Text = "Activate"
        ElseIf mn_deact.Text = "Activate" Then
            cb_status.SelectedValue = "1"
            mn_deact.Text = "Deactivate"
        End If
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click

    End Sub

    '----------------- input
    Private Sub in_kode_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode_sales.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_sales.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(in_nama_custo, e)
        End If
    End Sub

    Private Sub in_kode_sales_Leave(sender As Object, e As EventArgs) Handles in_kode_sales.Leave
        If Trim(in_kode_sales.Text) <> Nothing Then
            cb_sales.SelectedValue = in_kode_sales.Text
        End If
    End Sub

    Private Sub cb_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sales.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_sales.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(in_nama_custo, e)
        End If
    End Sub

    Private Sub cb_sales_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_sales.SelectionChangeCommitted
        in_kode_sales.Text = cb_sales.SelectedValue
    End Sub

    Private Sub bt_sales_Click(sender As Object, e As EventArgs) Handles bt_sales.Click
        Using search As New fr_search_dialog
            With search
                .query = "SELECT salesman_nama as nama, salesman_kode as kode FROM data_salesman_master"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "sales"
                If Trim(in_kode_sales.Text) <> Nothing Then
                    .returnkode = Trim(in_kode_sales.Text)
                    .in_cari.Text = Trim(in_kode_sales.Text)
                End If
                If Trim(cb_sales.Text) <> Nothing Then
                    .in_cari.Text = Trim(cb_sales.Text)
                End If
                .ShowDialog()
                cb_sales.SelectedValue = .returnkode
                in_kode_sales.Text = .returnkode
            End With
            in_nama_custo.Focus()
        End Using
    End Sub

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