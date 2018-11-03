Public Class fr_custo_detail
    Private cstStatus As String = "1"

    Private Sub loadDataCusto(kode As String)
        op_con()
        readcommd("SELECT * FROM data_customer_master WHERE customer_kode='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = kode
            in_nama_custo.Text = rd.Item("customer_nama")
            cstStatus = rd.Item("customer_status")
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
        setStatus()
    End Sub

    'SET STATUS
    Private Sub setStatus()
        Select Case cstStatus
            Case 0
                mn_deact.Text = "Activate"
                in_status.Text = "Non-Aktif"
            Case 1
                mn_deact.Text = "Deactivate"
                in_status.Text = "Aktif"
            Case 9
                mn_deact.Enabled = False
                in_status.Text = "Delete"
            Case Else
                Exit Sub
        End Select
    End Sub

    'SAVE DATA
    Private Sub saveData()
        Dim data1 As String()
        Dim querycheck As Boolean = False
        Dim q As String

        Me.Cursor = Cursors.WaitCursor

        data1 = {
            "customer_jenis='" & cb_tipe.SelectedValue & "'",
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
            "customer_max_piutang='" & in_piutang.Value & "'",
            "Customer_kriteria_discount='" & cb_diskon.SelectedValue & "'",
            "Customer_kriteria_harga_jual='" & cb_harga.SelectedValue & "'",
            "customer_term='" & in_term.Value & "'",
            "customer_status='" & cstStatus & "'"
            }

        op_con()
        If bt_simpancusto.Text = "Simpan" Then
            'GENNERATE CODE
            If Trim(in_kode.Text) = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT RIGHT(customer_kode,7) as ss FROM data_customer_master WHERE customer_kode LIKE 'CT%' " _
                          & "AND RIGHT(customer_kode,7) REGEXP '^[0-9]+$' ORDER BY ss DESC LIMIT 1")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()

                in_kode.Text = "CT" & no.ToString("D7")
            Else
                in_kode.Text = Trim(in_kode.Text)
                If checkdata("data_customer_master", "'" & in_kode.Text & "'", "customer_kode") Then
                    MessageBox.Show("Customer dg Kode " & in_kode.Text & " sudah ada")
                    in_kode.Focus()
                    Exit Sub
                End If
            End If

            q = "INSERT INTO data_customer_master SET customer_kode='{0}',{1},customer_reg_date=NOW(),customer_reg_alias='{2}'"
        ElseIf bt_simpancusto.Text = "Update" Then
            q = "UPDATE data_customer_master SET {1}, customer_upd_date=NOW(), customer_upd_alias='{2}' WHERE customer_kode='{0}'"
        End If
        querycheck = commnd(String.Format(q, Trim(in_kode.Text), String.Join(",", data1), loggeduser.user_id))


        Me.Cursor = Cursors.Default

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data customer tersimpan")
            'frmcusto.in_cari.Clear()
            'populateDGVUserCon("custo", "", frmcusto.dgv_list)
            doRefreshTab({pgcusto})
            Me.Close()
        End If
    End Sub

    'DRAG FORM
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

    'CLOSE
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalcusto.Click
        If MessageBox.Show("Tutup Form?", "Customer", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
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

    'MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpancusto.PerformClick()
    End Sub

    Private Sub mn_deact_Click(sender As Object, e As EventArgs) Handles mn_deact.Click
        If mn_deact.Text = "Deactivate" Then
            cstStatus = "0"
        ElseIf mn_deact.Text = "Activate" Then
            cstStatus = "1"
        End If
        setStatus()
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click
        'brgStatus = 9
        'UPDATE STATUS TO 9
        'setStatus()
    End Sub

    'LOAD
    Private Sub fr_custo_detail_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        setStatus()

        op_con()
        If bt_simpancusto.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadDataCusto(.Text)
            End With
        End If
    End Sub

    'SAVE
    Private Sub bt_simpancusto_Click(sender As Object, e As EventArgs) Handles bt_simpancusto.Click
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

        If MessageBox.Show("Simpan data customer?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    'UI
    '------------------ numeric
    Private Sub in_piutang_Enter(sender As Object, e As EventArgs) Handles in_term.Enter, in_piutang.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_piutang_Leave(sender As Object, e As EventArgs) Handles in_term.Leave, in_piutang.Leave
        numericLostFocus(sender)
    End Sub

    '----------------- cb disable input
    Private Sub cb_tipe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_tipe.KeyPress, cb_diskon.KeyPress, cb_diskon.KeyPress
        If e.KeyChar <> ControlChars.Cr Then
            e.Handled = True
        End If
    End Sub

    '------------------ txtbox numeric
    Private Sub in_telpsales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_nik.KeyPress, in_alamat_no.KeyPress, in_alamat_rt.KeyPress, in_alamat_rw.KeyPress, in_kodepos.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub in_npwpsupplier_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_telpcusto.KeyPress, in_faxcusto.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "-" Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub in_npwp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_npwp.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "-" AndAlso e.KeyChar <> "." Then
                e.Handled = True
            End If
        End If
    End Sub

    '----INPUT
    Private Sub in_kode_KeyUp(sender As Object, e As KeyEventArgs) Handles in_kode.KeyUp
        keyshortenter(in_nama_custo, e)
    End Sub

    Private Sub in_nama_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nama_custo.KeyUp
        keyshortenter(cb_tipe, e)
    End Sub

    Private Sub cb_tipe_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_tipe.KeyUp
        keyshortenter(in_telpcusto, e)
    End Sub

    Private Sub in_telpcusto_KeyDown(sender As Object, e As KeyEventArgs) Handles in_telpcusto.KeyUp
        keyshortenter(in_faxcusto, e)
    End Sub

    Private Sub in_faxcusto_KeyDown(sender As Object, e As KeyEventArgs) Handles in_faxcusto.KeyUp
        keyshortenter(in_cpcusto, e)
    End Sub

    Private Sub in_cpcusto_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cpcusto.KeyUp
        keyshortenter(in_alamat_custo, e)
    End Sub

    Private Sub in_alamat_blok_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_blok.KeyUp
        keyshortenter(in_alamat_no, e)
    End Sub

    Private Sub in_alamat_no_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_no.KeyUp
        keyshortenter(in_alamat_rt, e)
    End Sub

    Private Sub in_alamat_rt_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_rt.KeyUp
        keyshortenter(in_alamat_rw, e)
    End Sub

    Private Sub in_alamat_rw_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_rw.KeyUp
        keyshortenter(in_alamat_kelurahan, e)
    End Sub

    Private Sub in_alamat_kelurahan_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_kelurahan.KeyUp
        keyshortenter(in_alamat_kecamatan, e)
    End Sub

    Private Sub in_alamat_kecamatan_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_kecamatan.KeyUp
        keyshortenter(in_alamat_kabupaten, e)
    End Sub

    Private Sub in_alamat_kabupaten_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_kabupaten.KeyUp
        keyshortenter(in_alamat_pasar, e)
    End Sub

    Private Sub in_alamat_pasar_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_pasar.KeyUp
        keyshortenter(in_alamat_provinsi, e)
    End Sub

    Private Sub in_alamat_provinsi_KeyDown(sender As Object, e As KeyEventArgs) Handles in_alamat_provinsi.KeyUp
        keyshortenter(in_kodepos, e)
    End Sub

    Private Sub in_kodepos_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kodepos.KeyUp
        keyshortenter(in_piutang, e)
    End Sub

    Private Sub in_piutang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_piutang.KeyUp
        keyshortenter(cb_diskon, e)
    End Sub

    Private Sub cb_diskon_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_diskon.KeyUp
        keyshortenter(cb_harga, e)
    End Sub

    Private Sub cb_harga_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_harga.KeyUp
        keyshortenter(in_term, e)
    End Sub

    Private Sub in_term_KeyDown(sender As Object, e As KeyEventArgs) Handles in_term.KeyUp
        keyshortenter(in_nik, e)
    End Sub

    Private Sub in_nik_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nik.KeyUp
        keyshortenter(in_npwp, e)
    End Sub

    Private Sub in_npwp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_npwp.KeyUp
        keyshortenter(date_tgl_pkp, e)
    End Sub

    Private Sub date_tgl_pkp_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_pkp.KeyUp
        keyshortenter(in_pajak_nama, e)
    End Sub

    Private Sub in_pajak_nama_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pajak_nama.KeyUp
        keyshortenter(in_pajak_jabatan, e)
    End Sub

    Private Sub in_pajak_jabatan_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pajak_jabatan.KeyUp
        keyshortenter(in_pajak_alamat, e)
    End Sub
End Class