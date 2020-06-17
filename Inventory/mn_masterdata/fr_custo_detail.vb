Public Class fr_custo_detail
    Private cstStatus As String = "1"
    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
    End Enum

    'STYLE
    Private m_aeroEnabled As Boolean = False
    Private Const CS_DROPSHADOW As Int32 = &H20000
    Private Const WM_NCPAINT As Int32 = 133
    Private Const WM_ACTIVATEAPP As Int32 = 28

    Private Const WM_NCHITTEST As Int32 = &H84
    Private Const HTCLIENT As Int32 = &H1
    Private Const HTCAPTION As Int32 = &H2

    'DROP SHADOW
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            m_aeroEnabled = CheckAeroEnabled()

            Dim parameters As CreateParams = MyBase.CreateParams
            If Not m_aeroEnabled Then parameters.ClassStyle += CS_DROPSHADOW
            Return parameters
        End Get
    End Property

    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case WM_NCPAINT
                If m_aeroEnabled Then
                    Dim v = 2
                    DwmSetWindowAttribute(Me.Handle, 2, v, 4)
                    Dim margins As New Margins With {
                        .bottomHeight = 1,
                        .leftWidth = 0,
                        .rightWidth = 0,
                        .topHeight = 0
                        }
                    DwmExtendFrameIntoClientArea(Me.Handle, margins)
                End If
        End Select
        MyBase.WndProc(m)
        If (m.Msg = WM_NCHITTEST AndAlso m.Result.ToInt32 = HTCLIENT) Then m.Result = HTCAPTION
    End Sub

    'SETUP FORM
    Private Sub SetUpForm(KodeGudang As String, FormSet As InputState, AllowEdit As Boolean)
        formstate = FormSet : Me.Opacity = 0

        For Each cbo As ComboBox In {cb_tipe, cb_area, cb_penjualan}
            Dim _type As String = "" : Dim _idx As Integer = 0
            Select Case cbo.Name
                Case cb_tipe.Name : _type = "jenis_custo"
                Case cb_area.Name : _type = "areacusto"
                Case cb_penjualan.Name : _type = "priority_custo"
                Case Else : GoTo NextCbo
            End Select

            cbo.DataSource = jenis(_type)
            cbo.ValueMember = "Value"
            cbo.DisplayMember = "Text"
            cbo.SelectedIndex = _idx
            AddHandler cbo.KeyPress, AddressOf cb_tipe_KeyPress
NextCbo:
        Next
        AddHandler cb_area.SelectionChangeCommitted, AddressOf cb_area_SelectionChangeCommitted

        If Not FormSet = InputState.Insert Then
            Dim _resp = loadDataCusto(KodeGudang)
            If Not _resp.Key Then
                MessageBox.Show(_resp.Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
            End If
        End If

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        If formstate = InputState.Edit Or Not AllowInput Then
            in_kode.ReadOnly = True : in_kode.BackColor = Color.Gainsboro
            bt_simpancusto.Text = "Update"
        Else
            in_kode.ReadOnly = False
        End If
        For Each txt As TextBox In {in_nama_custo, in_telpcusto, in_faxcusto, in_cpcusto, in_alamat_custo, in_alamat_blok, in_alamat_no, in_alamat_rt,
                                    in_alamat_rw, in_alamat_kelurahan, in_alamat_kecamatan, in_alamat_kabupaten, in_alamat_provinsi, in_alamat_pasar, in_kodepos,
                                    in_nik, in_npwp, in_pajak_nama, in_pajak_alamat, in_pajak_jabatan}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        For Each cbx As Control In {cb_area, cb_tipe, cb_penjualan, in_term, in_piutang, date_tgl_pkp}
            cbx.Enabled = AllowInput
        Next

        bt_simpancusto.Enabled = AllowInput
        tstrip_simpan.Enabled = AllowInput
        tstrip_status.Enabled = If(formstate = InputState.Insert, False, AllowInput)
        tstrip_printqr.Enabled = If(formstate = InputState.Insert, False, True)
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

    Private Sub fr_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 100
    End Sub

    'GET DATA
    Private Function loadDataCusto(kode As String) As KeyValuePair(Of Boolean, String)
        Dim q As String = ""
        If MainConnData.IsEmpty Then Return New KeyValuePair(Of Boolean, String)(False, "Main DBConfig is empty.")

        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    q = "CALL getDataMasterHeader('{0}','CUSTO')"
                    Using rdx = x.ReadCommand(String.Format(q, kode))
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            in_kode.Text = kode
                            in_nama_custo.Text = rdx.Item("customer_nama")
                            cstStatus = rdx.Item("customer_status")
                            cb_tipe.SelectedValue = rdx.Item("customer_jenis")

                            'ALAMAT CUSTOMER
                            cb_area.SelectedValue = rdx.Item("customer_area")
                            in_alamat_custo.Text = rdx.Item("customer_alamat")
                            in_alamat_blok.Text = rdx.Item("alamat_blok")
                            in_alamat_no.Text = rdx.Item("alamat_nomor")
                            in_alamat_rt.Text = rdx.Item("alamat_rt")
                            in_alamat_rw.Text = rdx.Item("alamat_rw")
                            in_alamat_kelurahan.Text = rdx.Item("alamat_kel")
                            in_alamat_kecamatan.Text = rdx.Item("alamat_kec")
                            in_alamat_kabupaten.Text = rdx.Item("alamat_kab")
                            in_alamat_pasar.Text = rdx.Item("alamat_pasar")
                            in_alamat_provinsi.Text = rdx.Item("alamat_provinsi")
                            in_kodepos.Text = rdx.Item("customer_kodepos")

                            in_telpcusto.Text = rdx.Item("customer_telpon")
                            in_faxcusto.Text = rdx.Item("customer_fax")
                            in_cpcusto.Text = rdx.Item("customer_cp")

                            in_nik.Text = rdx.Item("customer_nik")
                            in_npwp.Text = rdx.Item("customer_npwp")
                            date_tgl_pkp.Value = rdx.Item("customer_tanggal_pkp")
                            in_pajak_nama.Text = rdx.Item("pajak_nama")
                            in_pajak_jabatan.Text = rdx.Item("pajak_jabatan")
                            in_pajak_alamat.Text = rdx.Item("pajak_alamat")

                            in_piutang.Value = rdx.Item("customer_max_piutang")
                            in_term.Value = rdx.Item("customer_term")
                            cb_penjualan.SelectedValue = rdx.Item("customer_priority")
                            in_ket.Text = rdx.Item("customer_keterangan")

                            txtRegdate.Text = rdx.Item("customer_reg_date")
                            txtRegAlias.Text = rdx.Item("customer_reg_alias")
                            txtUpdDate.Text = rdx.Item("customer_upd_date")
                            txtUpdAlias.Text = rdx.Item("customer_upd_alias")
                        End If
                    End Using
                Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat terhubung ke database.")
                End If
            End Using
            Select Case cstStatus
                Case 0 : in_status.Text = "Non-Aktif"
                Case 1 : in_status.Text = "Aktif"
                Case 9 : in_status.Text = "Delete"
                Case Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Status data tidak sesuai.")
            End Select

            Return New KeyValuePair(Of Boolean, String)(True, "OK")
        Catch ex As Exception
            LogError(ex)
            Return New KeyValuePair(Of Boolean, String)(False, "Terjadi kesalahan saat melakukan pengambilan data." & Environment.NewLine & ex.Message)
        End Try
    End Function

    'GET QR
    Private Sub loadDataQRLabel()
        Dim dt As New DataTable
        Dim qr As Bitmap = createQR(in_kode.Text, 250, 4)
        Dim _ms As New System.IO.MemoryStream

        If qr Is Nothing Then
            Exit Sub
        End If

        qr.Save(_ms, System.Drawing.Imaging.ImageFormat.Bmp)

        dt.Columns.Add("cust_kode", GetType(String))
        dt.Columns.Add("cust_qr", GetType(Byte()))
        dt.Columns.Add("cust_nama", GetType(String))

        dt.Rows.Add(in_kode.Text, _ms.ToArray, in_nama_custo.Text)

        Dim x As New fr_lap_master
        x.setVar("m_custo_qr", dt)
        x.do_load()
    End Sub

    'SAVE DATA
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
            "Customer_kriteria_harga_jual=(SELECT jenis_def_jual FROM data_customer_jenis WHERE jenis_kode = customer_jenis)",
            "customer_term='" & in_term.Value & "'",
            "customer_priority='" & cb_penjualan.SelectedValue & "'",
            "customer_keterangan=TRIM(BOTH '\r\n' FROM '" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "')",
            "customer_status='" & cstStatus & "'"
            }

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                If formstate = InputState.Insert Then
                    If String.IsNullOrWhiteSpace(in_kode.Text) Then
                        Dim i As Integer = 0 : Dim format As String = "D6"
                        q = "SELECT IFNULL(MAX(SUBSTRING(customer_kode, 3)), 0) FROM data_customer_master " _
                            & "WHERE customer_kode LIKE 'CT%' AND SUBSTRING(customer_kode,3) REGEXP '^[0-9]+$'"
                        Try
                            i = CInt(x.ExecScalar(q))
                            format = IIf(i + 1 > 999999, "D" & (i + 1).ToString.Length, "D6")
                            in_kode.Text = "CT" & (i + 1).ToString(format)
                        Catch ex As Exception
                            MessageBox.Show("Terjadi kesalahan dalam melakukan proses penyimpanan data." & Environment.NewLine & ex.Message,
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            LogError(ex, True) : Exit Sub
                        End Try
                    Else
                        Dim i As Integer = 0
                        q = "SELECT COUNT(customer_kode) FROM data_customer_master WHERE customer_kode='{0}'"
                        Try
                            i = Integer.Parse(x.ExecScalar(String.Format(q, in_kode.Text)))
                        Catch ex As Exception
                            MessageBox.Show("Terjadi kesalahan dalam melakukan proses penyimpanan data." & Environment.NewLine & ex.Message,
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            LogError(ex, True) : Exit Sub
                        End Try
                        If i <> 0 Then
                            MessageBox.Show("Kode customer " & in_kode.Text & " sudah pernah di inputkan ke database.",
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            in_kode.Focus() : Exit Sub
                        End If
                    End If

                    q = "INSERT INTO data_customer_master SET customer_kode='{0}',{1},customer_reg_date=NOW(),customer_reg_alias='{2}'"
                Else
                    q = "UPDATE data_customer_master SET {1}, customer_upd_date=NOW(), customer_upd_alias='{2}' WHERE customer_kode='{0}'"
                End If

                querycheck = x.TransactCommand(New List(Of String) From {String.Format(q, Trim(in_kode.Text), String.Join(",", data1), loggeduser.User_ID)})
                If querycheck Then
                    MessageBox.Show("Data customer tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pgcusto}) : Me.Close()
                Else
                    MessageBox.Show("Data customer tidak dapat tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'UI : FORM / DRAG
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles pnl_header.MouseDown, lbl_title.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles pnl_header.MouseMove, lbl_title.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles pnl_header.MouseUp, lbl_title.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles pnl_header.DoubleClick, lbl_title.DoubleClick
        CenterToScreen()
    End Sub

    'UI : FORM
    Private Sub fr_supplier_detail_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_batalcusto.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            bt_simpancusto.PerformClick()
        End If
    End Sub

    'UI : BUTTON
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalcusto.Click
        bt_cl.PerformClick()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_menu.Click
        Dim _x As Integer = sender.Location.X
        Dim _y As Integer = sender.Location.Y + sender.Height
        ctx_main.Show(pnl_header, _x, _y)
    End Sub

    Private Sub bt_simpancusto_Click(sender As Object, e As EventArgs) Handles bt_simpancusto.Click
        If Trim(in_nama_custo.Text) = Nothing Then
            MessageBox.Show("Nama Customer belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_nama_custo.Focus() : Exit Sub
        End If

        If cb_tipe.SelectedValue = Nothing Then
            MessageBox.Show("Tipe Customer belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cb_tipe.Focus() : Exit Sub
        End If

        'If cb_area.SelectedValue = Nothing Or Trim(in_alamat_kabupaten.Text) = Nothing Then
        '    MessageBox.Show("Area/Kabupaten belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cb_tipe.Focus() : Exit Sub
        'End If
        If Not String.IsNullOrWhiteSpace(in_npwp.Text) Then
            If Not in_npwp.Text Like "##.###.###.#-###.###" Then
                MessageBox.Show("Format NPWP yang diinput tidak sesuai.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                in_npwp.Focus() : Exit Sub
            End If
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

    'UI : numeric
    Private Sub in_piutang_Enter(sender As Object, e As EventArgs) Handles in_term.Enter, in_piutang.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_piutang_Leave(sender As Object, e As EventArgs) Handles in_term.Leave, in_piutang.Leave
        numericLostFocus(sender)
    End Sub

    'UI : COMBOBOX
    Private Sub cb_tipe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_tipe.KeyPress, cb_area.KeyPress
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    Private Sub cb_area_SelectionChangeCommitted(sender As Object, e As EventArgs)
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

    'UI : TEXTBOX INPUT
    Private Sub in_telpsales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_nik.KeyPress, in_alamat_no.KeyPress, in_alamat_rt.KeyPress, in_alamat_rw.KeyPress, in_kodepos.KeyPress
        e.Handled = Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar)
    End Sub

    Private Sub in_npwpsupplier_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_telpcusto.KeyPress, in_faxcusto.KeyPress
        e.Handled = Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso Not {"-", "(", ")"}.Contains(e.KeyChar)
    End Sub

    Private Sub in_npwp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_npwp.KeyPress
        e.Handled = Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "-" AndAlso e.KeyChar <> "."
    End Sub

    'UI : CONTEXT MENU
    Private Sub tstrip_simpan_Click(sender As Object, e As EventArgs) Handles tstrip_simpan.Click
        bt_simpancusto.PerformClick()
    End Sub

    Private Sub tsrtip_close_Click(sender As Object, e As EventArgs) Handles tsrtip_close.Click
        bt_cl.PerformClick()
    End Sub

    Private Sub tstrip_activate_Click(sender As Object, e As EventArgs) Handles tstrip_activate.Click
        If cstStatus = 1 Then
            MessageBox.Show("Status data salesman sudah aktif.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub

    Private Sub tstrip_inactivate_Click(sender As Object, e As EventArgs) Handles tstrip_inactivate.Click
        If cstStatus = 0 Then
            MessageBox.Show("Status data salesman sudah nonaktif.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub tstrip_delete_Click(sender As Object, e As EventArgs) Handles tstrip_delete.Click

    End Sub

    Private Sub tstrip_printqr_Click(sender As Object, e As EventArgs) Handles tstrip_printqr.Click
        If Not String.IsNullOrWhiteSpace(in_kode.Text) Then loadDataQRLabel()
    End Sub
End Class