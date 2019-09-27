Public Class fr_sales_detail
    Private slsStatus As String = "1"
    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
    End Enum

    'Protected Overrides Sub WndProc(ByRef m As Message)
    '    Const WM_NCLBUTTONDOWN As Integer = 161
    '    Const WM_SYSCOMMAND As Integer = 274
    '    Const HTCAPTION As Integer = 2
    '    Const SC_MOVE As Integer = 61456

    '    If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32 = SC_MOVE) Then
    '        Exit Sub
    '    End If

    '    If (m.Msg = WM_NCLBUTTONDOWN) AndAlso (m.WParam.ToInt32 = HTCAPTION) Then
    '        Exit Sub
    '    End If

    '    MyBase.WndProc(m)
    'End Sub

    'SETUP FORM
    Private Sub SetUpForm(KodeSales As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Data Salesman : P01616"
        formstate = FormSet

        With cb_jenis
            .DataSource = jenis("jenis_sales")
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        If Not FormSet = InputState.Insert Then
            Me.Text += KodeSales : Me.lbl_title.Text += " : " & KodeSales
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            loadDataSales(KodeSales)
            If Not {0, 1}.Contains(slsStatus) Then AllowEdit = False
        End If

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        in_kode.ReadOnly = IIf(formstate = InputState.Insert, False, True)
        For Each txt As TextBox In {in_alamatsales, in_namasales, in_telpsales, in_faxsales, in_nik, in_bank_an, in_bank_nama, in_bank_rek, in_email}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        bt_simpancusto.Enabled = AllowInput
        bt_simpancusto.Text = IIf(formstate = InputState.Insert, "Simpan", "Update")
        mn_deact.Enabled = IIf(formstate = InputState.Insert, False, AllowInput)
        mn_deact.Text = IIf(slsStatus = 1, "Deactivate", "Activate")
        mn_save.Enabled = AllowInput
        mn_set.Enabled = IIf(main.listkodemenu.Contains("mn0934") And formstate <> InputState.Insert, AllowInput, False)
        mn_del.Enabled = IIf(formstate = InputState.Insert, False, AllowInput)
    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        SetUpForm(Nothing, InputState.Insert, AllowInput)
        Me.Show()
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, AllowEdit As Boolean)
        SetUpForm(NoFaktur, InputState.Edit, AllowEdit)
        Me.Show()
    End Sub

    Private Sub loadDataSales(kode As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Dim q As String = "SELECT salesman_nama, IFNULL(salesman_alamat, '') salesman_alamat, salesman_jenis, " _
                          & "IFNULL(salesman_hp, '') hp, IFNULL(salesman_fax, '') fax, IFNULL(salesman_email, '') email, IFNULL(salesman_nik, '') nik, " _
                          & "IFNULL(salesman_bank_nama, '') bank_nama, IFNULL(salesman_bank_rekening,'') bank_rek, IFNULL(salesman_bank_atasnama, '') bank_na, " _
                          & "salesman_status, " _
                          & "IFNULL(salesman_reg_alias,'') salesman_reg_alias, DATE_FORMAT(salesman_reg_date,'%d/%m/%Y %H:%i:%S') salesman_reg_date, " _
                          & "IFNULL(salesman_upd_alias,'') salesman_upd_alias, IFNULL(DATE_FORMAT(salesman_upd_date,'%d/%m/%Y %H:%i:%S'),'') salesman_upd_date " _
                          & "FROM data_salesman_master WHERE salesman_kode='{0}'"
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
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
                        slsStatus = rdx.Item("salesman_status")

                        txtRegAlias.Text = rdx.Item("salesman_reg_alias")
                        txtRegdate.Text = rdx.Item("salesman_reg_date")
                        txtUpdDate.Text = rdx.Item("salesman_upd_date")
                        txtUpdAlias.Text = rdx.Item("salesman_upd_alias")
                    End If
                End Using
            End If
            setStatus()
        End Using
    End Sub

    Private Sub setStatus()
        Select Case slsStatus
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
        'If MessageBox.Show("Tutup Form?", "Detail Salesman", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
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

    Private Sub fr_jual_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_batalcusto.PerformClick()
        End If
    End Sub

    'MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        Me.Cursor = Cursors.WaitCursor
        bt_simpancusto.PerformClick()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mn_deact_Click(sender As Object, e As EventArgs) Handles mn_deact.Click
        Dim _sts As Integer = slsStatus
        Select Case mn_deact.Text
            Case "Deactivate" : _sts = 0
            Case "Activate" : _sts = 1
            Case Else : Exit Sub
        End Select
        UpdateStatusData(_sts)
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click
        If loggeduser.validasi_master Then
            'KONFIRMASI USER ID

            'DELETE

            MessageBox.Show("Maaf fungsi ini masih dalam perbaikan/maintenance atau belum tersedia.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub mn_set_Click(sender As Object, e As EventArgs) Handles mn_set.Click
        Dim det As New fr_sales_set_det
        det.DoLoad(in_kode.Text, loggeduser.allowedit_master)
    End Sub

    'SAVE
    Private Sub bt_simpansales_Click(sender As Object, e As EventArgs) Handles bt_simpancusto.Click
        If String.IsNullOrWhiteSpace(in_namasales.Text) Then
            MessageBox.Show("Nama belum di input.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            in_namasales.Focus() : Exit Sub
        End If
        If cb_jenis.SelectedIndex < 0 Then
            MessageBox.Show("Jenis salesman belum diinput.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            cb_jenis.Focus() : Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim _resMsg As DialogResult = Windows.Forms.DialogResult.Yes
        If formstate <> InputState.Insert Then _resMsg = MessageBox.Show("Simpan perubahan data sales?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _resMsg = Windows.Forms.DialogResult.Yes Then saveData()
        Me.Cursor = Cursors.Default
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

    Private Sub in_npwpsupplier_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_telpsales.KeyPress, in_faxsales.KeyPress, in_bank_rek.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "-" Then
                e.Handled = True
            End If
        End If
    End Sub

    'UI : input
    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(in_namasales, e)
    End Sub

    Private Sub in_namasales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_namasales.KeyDown
        keyshortenter(cb_jenis, e)
    End Sub

    Private Sub cb_jenis_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_jenis.KeyDown
        keyshortenter(in_alamatsales, e)
    End Sub

    Private Sub in_telpsales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_telpsales.KeyDown
        keyshortenter(in_faxsales, e)
    End Sub

    Private Sub in_faxsales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_faxsales.KeyDown
        keyshortenter(in_email, e)
    End Sub

    Private Sub date_kerja_KeyDown(sender As Object, e As KeyEventArgs) Handles in_email.KeyDown
        keyshortenter(in_nik, e)
    End Sub

    Private Sub in_nik_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nik.KeyDown
        keyshortenter(in_bank_rek, e)
    End Sub

    Private Sub in_bank_nama_KeyDown(sender As Object, e As KeyEventArgs) Handles in_bank_nama.KeyDown
        keyshortenter(in_bank_rek, e)
    End Sub

    Private Sub in_bank_rek_KeyDown(sender As Object, e As KeyEventArgs) Handles in_bank_rek.KeyDown
        keyshortenter(in_bank_an, e)
    End Sub

    Private Sub in_bank_an_KeyDown(sender As Object, e As KeyEventArgs) Handles in_bank_an.KeyDown
        keyshortenter(bt_simpancusto, e)
    End Sub
End Class