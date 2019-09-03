Public Class fr_custo_detail
    Private cstStatus As String = "1"
    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(KodeGudang As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Data Customer : rb201908"

        formstate = FormSet

        With cb_tipe
            .DataSource = jenis("jenis_custo")
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

        With cb_area
            .DataSource = jenis("areacusto")
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With

        With cb_penjualan
            .DataSource = jenis("priority_custo")
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With

        If Not FormSet = InputState.Insert Then
            Me.Text += KodeGudang
            Me.lbl_title.Text += " : " & KodeGudang
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            loadDataCusto(KodeGudang)
            If Not {0, 1}.Contains(cstStatus) Then AllowEdit = False
            in_kode.ReadOnly = IIf(formstate = InputState.Insert, False, True)
            bt_simpancusto.Text = "Update"
        End If

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        For Each txt As TextBox In {in_kode, in_nama_custo, in_telpcusto, in_faxcusto, in_cpcusto, in_alamat_custo, in_alamat_blok, in_alamat_no, in_alamat_rt,
                                    in_alamat_rw, in_alamat_kelurahan, in_alamat_kecamatan, in_alamat_kabupaten, in_alamat_provinsi, in_alamat_pasar, in_kodepos,
                                    in_nik, in_npwp, in_pajak_nama, in_pajak_alamat, in_pajak_jabatan}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        For Each cbx As ComboBox In {cb_area, cb_diskon, cb_harga, cb_tipe}
            cbx.Enabled = AllowInput
        Next
        For Each nmx As NumericUpDown In {in_term, in_piutang}
            nmx.Enabled = AllowInput
        Next

        date_tgl_pkp.Enabled = AllowInput
        bt_simpancusto.Enabled = AllowInput
        mn_deact.Enabled = AllowInput
        mn_save.Enabled = AllowInput
    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        SetUpForm(Nothing, InputState.Insert, AllowInput)
        Me.Show()
        in_nama_custo.Focus()
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, AllowEdit As Boolean)
        SetUpForm(NoFaktur, InputState.Edit, AllowEdit)
        Me.Show()
        in_nama_custo.Focus()
    End Sub

    'GET DATA
    Private Sub loadDataCusto(kode As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim q As String = "SELECT customer_nama, customer_status, customer_jenis, customer_area, customer_alamat, customer_alamat_blok, customer_alamat_nomor,  " _
                          & "customer_alamat_rt,customer_alamat_rw,customer_alamat_kelurahan,customer_kecamatan,customer_kabupaten,customer_pasar,customer_provinsi, " _
                          & "customer_telpon,customer_fax,customer_cp,customer_nik,customer_npwp,customer_kodepos, " _
                          & "IF(MONTH(customer_tanggal_pkp)=0,CURDATE(),customer_tanggal_pkp) customer_tanggal_pkp ,customer_pajak_nama,customer_pajak_jabatan, " _
                          & "customer_pajak_alamat,customer_max_piutang, customer_priority, Customer_kriteria_discount,Customer_kriteria_harga_jual,customer_term, " _
                          & "IFNULL(customer_keterangan,'') customer_keterangan, " _
                          & "IFNULL(customer_reg_alias,'') customer_reg_alias, IFNULL(DATE_FORMAT(customer_reg_date,'%d/%m/%Y %H:%i:%S'),'') customer_reg_date, " _
                          & "IFNULL(customer_upd_alias,'') customer_upd_alias, IFNULL(DATE_FORMAT(customer_upd_date,'%d/%m/%Y %H:%i:%S'),'') customer_upd_date " _
                          & "FROM data_customer_master WHERE customer_kode='{0}'"
        On Error Resume Next
        'FUCK YOU
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Using rdx = x.ReadCommand(String.Format(q, kode))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_kode.Text = kode
                        in_nama_custo.Text = rdx.Item("customer_nama")
                        cstStatus = rdx.Item("customer_status")
                        cb_tipe.SelectedValue = rdx.Item("customer_jenis")
                        cb_area.SelectedValue = rdx.Item("customer_area")
                        in_alamat_custo.Text = rdx.Item("customer_alamat")
                        in_alamat_blok.Text = rdx.Item("customer_alamat_blok")
                        in_alamat_no.Text = rdx.Item("customer_alamat_nomor")
                        in_alamat_rt.Text = rdx.Item("customer_alamat_rt")
                        in_alamat_rw.Text = rdx.Item("customer_alamat_rw")
                        in_alamat_kelurahan.Text = rdx.Item("customer_alamat_kelurahan")
                        in_alamat_kecamatan.Text = rdx.Item("customer_kecamatan")
                        in_alamat_kabupaten.Text = rdx.Item("customer_kabupaten")
                        in_alamat_pasar.Text = rdx.Item("customer_pasar")
                        in_alamat_provinsi.Text = rdx.Item("customer_provinsi")
                        in_kodepos.Text = rdx.Item("customer_kodepos")
                        in_telpcusto.Text = rdx.Item("customer_telpon")
                        in_faxcusto.Text = rdx.Item("customer_fax")
                        in_cpcusto.Text = rdx.Item("customer_cp")
                        in_nik.Text = rdx.Item("customer_nik")
                        in_npwp.Text = rdx.Item("customer_npwp")
                        date_tgl_pkp.Value = rdx.Item("customer_tanggal_pkp")
                        in_pajak_nama.Text = rdx.Item("customer_pajak_nama")
                        in_pajak_jabatan.Text = rdx.Item("customer_pajak_jabatan")
                        in_pajak_alamat.Text = rdx.Item("customer_pajak_alamat")
                        in_piutang.Value = rdx.Item("customer_max_piutang")
                        cb_diskon.SelectedValue = rdx.Item("Customer_kriteria_discount")
                        cb_harga.SelectedValue = rdx.Item("Customer_kriteria_harga_jual")
                        in_term.Value = rdx.Item("customer_term")
                        cb_penjualan.SelectedValue = rdx.Item("customer_priority")
                        in_ket.Text = rdx.Item("customer_keterangan")
                        txtRegdate.Text = rdx.Item("customer_reg_date")
                        txtRegAlias.Text = rdx.Item("customer_reg_alias")
                        txtUpdDate.Text = rdx.Item("customer_upd_date")
                        txtUpdAlias.Text = rdx.Item("customer_upd_alias")
                    End If
                End Using
                setStatus()
            End If
        End Using
    End Sub

    'GET QR
    Private Sub loadDataQRLabel()
        Dim dt As New DataTable
        Dim qr As Bitmap = createQR(in_kode.Text, 250, 4)
        Dim _ms As New System.IO.MemoryStream

        If qr Is Nothing Then
            Exit Sub
        End If

        qr.Save(_ms, System.Drawing.Imaging.ImageFormat.Bmp)

        'op_con()
        'q = "UPDATE data_customer_master SET customer_qr='{0}' WHERE customer_kode='{1}'"
        'commnd(String.Format(q, _ms.GetBuffer, in_kode.Text))

        dt.Columns.Add("cust_kode", GetType(String))
        dt.Columns.Add("cust_qr", GetType(Byte()))
        dt.Columns.Add("cust_nama", GetType(String))

        dt.Rows.Add(in_kode.Text, _ms.ToArray, in_nama_custo.Text)

        Dim x As New fr_lap_master
        x.setVar("m_custo_qr", dt)
        x.do_load()
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

        If loggeduser.allowedit_master = False Then
            bt_simpancusto.Visible = False
            bt_batalcusto.Text = "OK"

            For Each cb As ComboBox In {cb_area, cb_tipe, cb_diskon, cb_harga}
                cb.Enabled = False
            Next
            For Each x As TextBox In {in_nama_custo, in_alamat_custo, in_alamat_blok, in_alamat_kabupaten, in_alamat_kecamatan, in_alamat_kelurahan,
                                      in_alamat_no, in_alamat_pasar, in_alamat_provinsi, in_alamat_rt, in_alamat_rw, in_cpcusto, in_faxcusto, in_telpcusto}
                x.ReadOnly = True
            Next

            mn_save.Enabled = False
            mn_deact.Enabled = False
            mn_del.Enabled = False
        End If
    End Sub

    'SAVE DATA
    'Generate Kode
    Private Function createKode(namakusto As String) As String
        Dim ret As String = ""
        Dim acceptedChars() As Char = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ".ToCharArray
        Dim chrGet As Boolean = False
        Dim str As String = ""
        Dim split As String()
        Dim q As String = "SELECT RIGHT(customer_kode,2) as ss FROM data_customer_master " _
                          & "WHERE customer_kode LIKE '{0}%' AND RIGHT(customer_kode,2) REGEXP '^[0-9]+$' " _
                          & "ORDER BY ss DESC LIMIT 1"


        str = (From ch As Char In namakusto Select ch Where acceptedChars.Contains(ch)).ToArray
        split = str.Split(" ")

        Dim i As Integer = 0
        acceptedChars = "BCDFGHJKLMNPQRSTVWXYZ"
        For Each sa As String In split
            sa = sa.ToUpper
            'If sa = "PT" Then
            '    split(i) = "-"
            'End If
            If sa.Length >= 3 Then
                ret = Strings.Left(sa, 3)
                chrGet = True
                Exit For
            End If
            i += 1
        Next

        If chrGet = False Then
            str = Strings.Join(split, "").ToUpper
            'str = Strings.Replace(str, "-", "")
            ret = Strings.Left(str, 3)
        End If

        ret += cb_area.SelectedValue

        Dim kd As Integer = 0
        op_con()
        readcommd(String.Format(q, ret))
        If rd.HasRows Then
            kd = CInt(rd.Item(0))
        End If
        rd.Close()

        kd += 1

        ret += kd.ToString("N2")

        consoleWriteLine(ret)
        Return ret
    End Function

    'Save
    Private Sub saveData()
        Dim data1 As String()
        Dim querycheck As Boolean = False
        Dim q As String

        Me.Cursor = Cursors.WaitCursor

        data1 = {
            "customer_jenis='" & cb_tipe.SelectedValue & "'",
            "customer_area='" & cb_area.SelectedValue & "'",
            "customer_nama='" & in_nama_custo.Text & "'",
            "customer_alamat='" & mysqlQueryFriendlyStringFeed(in_alamat_custo.Text) & "'",
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
            "customer_priority='" & cb_penjualan.SelectedValue & "'",
            "customer_keterangan=TRIM(BOTH '\r\n' FROM '" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "')",
            "customer_status='" & cstStatus & "'"
            }

        op_con()
        If bt_simpancusto.Text = "Simpan" Then
            'GENNERATE CODE
            If Trim(in_kode.Text) = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT RIGHT(customer_kode,6) as ss FROM data_customer_master WHERE customer_kode LIKE 'CT%' " _
                          & "AND RIGHT(customer_kode,6) REGEXP '^[0-9]+$' ORDER BY ss DESC LIMIT 1")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()

                in_kode.Text = "CT" & no.ToString("D6")
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
        Else
            Exit Sub
        End If

        querycheck = commnd(String.Format(q, Trim(in_kode.Text), String.Join(",", data1), loggeduser.user_id))


        Me.Cursor = Cursors.Default

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data customer tersimpan")
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
        'If MessageBox.Show("Tutup Form?", "Customer", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        Me.Close()
        'End If
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
        If loggeduser.validasi_master Then
            If MessageBox.Show("Ubah status customer?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim _ket As String = ""
                Dim ckuser = MasterConfirmValid(_ket)

                If Not ckuser Then
                    Exit Sub
                End If

                in_ket.Text += IIf(String.IsNullOrWhiteSpace(in_ket.Text), "", Environment.NewLine) & _ket

                If mn_deact.Text = "Deactivate" Then
                    cstStatus = "0"
                ElseIf mn_deact.Text = "Activate" Then
                    cstStatus = "1"
                End If
                setStatus()
                saveData()
            End If
        Else
            MessageBox.Show("Anda tidak dapat mengubah status customer", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click
        'brgStatus = 9
        'UPDATE STATUS TO 9
        'setStatus()
    End Sub

    Private Sub mn_cetakQr_Click(sender As Object, e As EventArgs) Handles mn_cetakQr.Click
        If in_kode.Text <> "" Then
            loadDataQRLabel()
        End If
    End Sub

    'SAVE
    Private Sub bt_simpancusto_Click(sender As Object, e As EventArgs) Handles bt_simpancusto.Click
        If Trim(in_nama_custo.Text) = Nothing Then
            MessageBox.Show("Nama Customer belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_nama_custo.Focus() : Exit Sub
        End If

        If cb_tipe.SelectedValue = Nothing Then
            MessageBox.Show("Tipe Customer belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cb_tipe.Focus() : Exit Sub
        End If

        If cb_area.SelectedValue = Nothing Or Trim(in_alamat_kabupaten.Text) = Nothing Then
            MessageBox.Show("Area/Kabupaten belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cb_tipe.Focus() : Exit Sub
        End If

        Dim _resMsg As DialogResult = Windows.Forms.DialogResult.Yes
        If Not formstate = InputState.Insert Then _resMsg = MessageBox.Show("Simpan perubahan data customer?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _resMsg = Windows.Forms.DialogResult.Yes Then
            If formstate = InputState.Edit Then
                If Not MasterConfirmValid("") Then Exit Sub
            End If
            saveData()
        End If
    End Sub

    'UI :  numeric
    Private Sub in_piutang_Enter(sender As Object, e As EventArgs) Handles in_term.Enter, in_piutang.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_piutang_Leave(sender As Object, e As EventArgs) Handles in_term.Leave, in_piutang.Leave
        numericLostFocus(sender)
    End Sub

    '----------------- cb disable input
    Private Sub cb_tipe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_tipe.KeyPress, cb_diskon.KeyPress, cb_area.KeyPress
        If e.KeyChar <> ControlChars.Cr Then
            e.Handled = True
        End If
    End Sub

    '------------------ txtbox numeric
    Private Sub in_telpsales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_nik.KeyPress, in_alamat_no.KeyPress, in_alamat_rt.KeyPress, in_alamat_rw.KeyPress, in_kodepos.KeyPress
        e.Handled = Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar)
    End Sub

    Private Sub in_npwpsupplier_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_telpcusto.KeyPress, in_faxcusto.KeyPress
        e.Handled = Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "-"
    End Sub

    Private Sub in_npwp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_npwp.KeyPress
        e.Handled = Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "-" AndAlso e.KeyChar <> "."
    End Sub

    '----INPUT
    Private Sub in_kode_KeyUp(sender As Object, e As KeyEventArgs) Handles in_kode.KeyUp
        keyshortenter(in_nama_custo, e)
    End Sub

    Private Sub in_nama_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nama_custo.KeyUp
        keyshortenter(cb_tipe, e)
    End Sub

    Private Sub cb_tipe_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_tipe.KeyUp
        keyshortenter(cb_area, e)
    End Sub

    Private Sub cb_tipe_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_tipe.SelectionChangeCommitted
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Dim q = "SELECT jenis_def_jual FROM data_customer_jenis WHERE jenis_kode='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, cb_tipe.SelectedValue))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        cb_harga.SelectedValue = rdx.Item(0)
                    End If
                End Using
            End If
        End Using
    End Sub

    Private Sub cb_area_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_area.SelectionChangeCommitted
        Dim q As String = ""
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT IFNULL(ref_kab_nama,''), IFNULL(c_area_nama,'') FROM data_customer_area " _
                    & "LEFT JOIN ref_area_kabupaten ON ref_kab_id=c_area_kode_kab AND ref_kab_status=1 " _
                    & "WHERE c_area_id='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, cb_area.SelectedValue))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_alamat_kabupaten.Text = rdx.Item(0)
                        in_alamat_kecamatan.Text = rdx.Item(1)
                    ElseIf Not red Then
                        MessageBox.Show("Terjadi kesalahan saat melakukan penggambilan data area.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Sub cb_area_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_area.KeyUp
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