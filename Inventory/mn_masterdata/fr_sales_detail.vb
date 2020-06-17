Public Class fr_sales_detail
    Private slsStatus As String = "1"
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
    Private Sub SetUpForm(KodeSales As String, FormSet As InputState, AllowEdit As Boolean)
        formstate = FormSet : Me.Opacity = 0

        With cb_jenis
            .DataSource = jenis("jenis_sales")
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        If Not FormSet = InputState.Insert Then
            Dim _resp = loadDataSales(KodeSales)
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
        If Not main.listkodemenu.Contains("mn0934") Or Not AllowInput Or formstate = InputState.Insert Then
            tstrip_setupsales.Visible = False
            ToolStripSeparator4.Visible = False
        End If
        For Each txt As TextBox In {in_alamatsales, in_namasales, in_telpsales, in_faxsales, in_nik, in_bank_an, in_bank_nama, in_bank_rek, in_email}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        bt_simpancusto.Enabled = AllowInput
        tstrip_simpan.Enabled = AllowInput
        tstrip_status.Enabled = IIf(formstate = InputState.Insert, False, AllowInput)
    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        SetUpForm(Nothing, InputState.Insert, AllowInput)
        Me.Show()
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, AllowEdit As Boolean)
        SetUpForm(NoFaktur, InputState.Edit, AllowEdit)
        Me.Show()
    End Sub

    Private Sub fr_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 100
    End Sub

    'LOAD DATA
    Private Function loadDataSales(kode As String) As KeyValuePair(Of Boolean, String)
        Dim q As String = ""
        If MainConnData.IsEmpty Then Return New KeyValuePair(Of Boolean, String)(False, "Main DBConfig is empty.")

        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    q = "CALL getDataMasterHeader('{0}','SALES')"
                    Using rdx = x.ReadCommand(String.Format(q, kode))
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            in_kode.Text = kode
                            in_namasales.Text = rdx.Item("salesman_nama")
                            in_alamatsales.Text = rdx.Item("salesman_alamat")
                            cb_jenis.SelectedValue = rdx.Item("salesman_jenis")
                            in_telpsales.Text = rdx.Item("hp")
                            in_faxsales.Text = rdx.Item("fax")
                            in_email.Text = rdx.Item("email")
                            in_nik.Text = rdx.Item("nik")

                            in_bank_nama.Text = rdx.Item("bank_nama")
                            in_bank_rek.Text = rdx.Item("bank_rek")
                            in_bank_an.Text = rdx.Item("bank_na")
                            in_ket.Text = rdx.Item("keterangan")
                            slsStatus = rdx.Item("salesman_status")

                            txtRegAlias.Text = rdx.Item("salesman_reg_alias")
                            txtRegdate.Text = rdx.Item("salesman_reg_date")
                            txtUpdDate.Text = rdx.Item("salesman_upd_date")
                            txtUpdAlias.Text = rdx.Item("salesman_upd_alias")
                        End If
                    End Using
                Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat terhubung ke database.")
                End If
            End Using
            Select Case slsStatus
                Case 0 : in_status.Text = "Non-Aktif"
                Case 1 : in_status.Text = "Aktif"
                Case 9 : in_status.Text = "Delete"
                Case Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Status data ")
            End Select

            Return New KeyValuePair(Of Boolean, String)(True, "OK")
        Catch ex As Exception
            LogError(ex)
            Return New KeyValuePair(Of Boolean, String)(False, "Terjadi kesalahan saat melakukan pengambilan data." & Environment.NewLine & ex.Message)
        End Try
    End Function

    'SAVE DATA
    Private Sub saveData()
        Dim data1 As String()
        Dim querycheck As Boolean = False
        Dim q As String = ""


        data1 = {
            "salesman_nama='" & in_namasales.Text.Replace("'", "`") & "'",
            "salesman_alamat='" & in_alamatsales.Text.Replace("'", "`") & "'",
            "salesman_jenis='" & cb_jenis.SelectedValue & "'",
            "salesman_hp='" & in_telpsales.Text & "'",
            "salesman_fax='" & in_faxsales.Text & "'",
            "salesman_email='" & in_email.Text & "'",
            "salesman_nik='" & in_nik.Text & "'",
            "salesman_bank_nama='" & in_bank_nama.Text.Replace("'", "`") & "'",
            "salesman_bank_rekening='" & in_bank_rek.Text & "'",
            "salesman_bank_atasnama='" & in_bank_an.Text & "'",
            "salesman_keterangan='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
            "salesman_status=" & slsStatus
        }

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                If formstate = InputState.Insert Then
                    If Trim(in_kode.Text) = Nothing Then
                        'GENERATE CODE
                        Dim no As Integer = 0 : Dim format As String = "D3"
                        q = "SELECT IFNULL(MAX(SUBSTR(salesman_kode,4)),0) FROM data_salesman_master " _
                            & "WHERE LEFT(salesman_kode,2)='P{0}' AND SUBSTR(salesman_kode,4) REGEXP '^[0-9]+$'"
                        no = Integer.Parse(x.ExecScalar(String.Format(q, cb_jenis.SelectedValue.ToString("D2"))))
                        If no + 1 > 999 Then format = "D" & (no + 1).ToString.Length
                        in_kode.Text = "P" & CInt(cb_jenis.SelectedValue).ToString("D2") & (no + 1).ToString(format)

                    Else
                        'CHECK INPUTED CODE
                        q = "SELECT COUNT(salesman_id) FROM data_salesman_master WHERE salesman_kode='{0}'"
                        If Integer.Parse(x.ExecScalar(String.Format(q, Trim(in_kode.Text)))) > 0 Then
                            MessageBox.Show("Kode yang dimasukan sudah pernah diinputkan ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If

                    q = "INSERT INTO data_salesman_master SET salesman_kode='{0}',{1},salesman_reg_date=NOW(),salesman_reg_alias='{2}'"
                ElseIf bt_simpancusto.Text = "Update" Then
                    q = "UPDATE data_salesman_master SET {1}, salesman_upd_date=NOW(),salesman_upd_alias='{2}' WHERE salesman_kode='{0}'"
                End If

                querycheck = x.TransactCommand(New List(Of String) From {String.Format(q, Trim(in_kode.Text), String.Join(",", data1), loggeduser.user_id)})

                If querycheck = False Then
                    MessageBox.Show("Data sales tidak dapat tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Data sales tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pgsales}) : Me.Close()
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Sub UpdateStatusData(StatCode As Integer)
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                'validasi edit
                Dim q As String = ""
                q = "UPDATE data_salesman_master SET salesman_status={1}, salesman_upd_date=NOW(), salesman_upd_alias='{2}' WHERE salesman_kode='{0}'"
                Dim _ck = x.TransactCommand(New List(Of String) From {String.Format(q, in_kode.Text, StatCode, loggeduser.user_id)})
                If _ck Then
                    MessageBox.Show("Status data salesman telah di ubah.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    loadDataSales(in_kode.Text) : ControlSwitch(True)
                    DoRefreshTab_v2({pgsales})
                Else
                    MessageBox.Show("Perubahan status data gagal.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub bt_simpansales_Click(sender As Object, e As EventArgs) Handles bt_simpancusto.Click
        If String.IsNullOrWhiteSpace(in_namasales.Text) Then
            MessageBox.Show("Nama belum di input.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            in_namasales.Focus() : Exit Sub
        End If
        If cb_jenis.SelectedIndex < 0 Then
            MessageBox.Show("Jenis salesman belum diinput.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            cb_jenis.Focus() : Exit Sub
        End If
        If Not String.IsNullOrWhiteSpace(in_email.Text) Then
            If Not IsValidEmail(in_email.Text) Then
                MessageBox.Show("Format alamat email yang dimasukan tidak sesuai.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                in_email.Focus() : Exit Sub
            End If
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim _resMsg As DialogResult = Windows.Forms.DialogResult.Yes
        If formstate <> InputState.Insert Then _resMsg = MessageBox.Show("Simpan perubahan data sales?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _resMsg = Windows.Forms.DialogResult.Yes Then saveData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_menu.Click
        Dim _x As Integer = sender.Location.X
        Dim _y As Integer = sender.Location.Y + sender.Height
        ctx_main.Show(pnl_header, _x, _y)
    End Sub

    'UI : COMBOBOX
    Private Sub cb_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_jenis.KeyPress
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    'UI : txtbox numeric
    Private Sub in_telpsales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_nik.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub in_npwpsupplier_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_telpsales.KeyPress, in_faxsales.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "-" Then
                e.Handled = True
            End If
        End If
    End Sub

    'UI : CONTEXT MENU
    Private Sub tstrip_simpan_Click(sender As Object, e As EventArgs) Handles tstrip_simpan.Click
        bt_simpancusto.PerformClick()
    End Sub

    Private Sub tsrtip_close_Click(sender As Object, e As EventArgs) Handles tsrtip_close.Click
        bt_cl.PerformClick()
    End Sub

    Private Sub tstrip_activate_Click(sender As Object, e As EventArgs) Handles tstrip_activate.Click
        If slsStatus = 1 Then
            MessageBox.Show("Status data salesman sudah aktif.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub

    Private Sub tstrip_inactivate_Click(sender As Object, e As EventArgs) Handles tstrip_inactivate.Click
        If slsStatus = 0 Then
            MessageBox.Show("Status data salesman sudah nonaktif.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub tstrip_delete_Click(sender As Object, e As EventArgs) Handles tstrip_delete.Click

    End Sub

    Private Sub tstrip_setupsales_Click(sender As Object, e As EventArgs) Handles tstrip_setupsales.Click
        Dim fr As New fr_sales_set_det
        fr.DoLoad(in_kode.Text, True)
    End Sub
End Class