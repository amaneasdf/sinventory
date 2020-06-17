Public Class fr_supplier_detail
    Private supStatus As String = 1
    Private olddata As String = ""
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
    Private Sub SetUpForm(KodeBarang As String, FormSet As InputState, AllowEdit As Boolean)
        Me.Opacity = 0
        formstate = FormSet

        If Not FormSet = InputState.Insert Then
            Dim _resp = loadDataSupplier(KodeBarang)
            If Not _resp.Key Then
                MessageBox.Show(_resp.Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
            End If
            in_kode.ReadOnly = True : in_kode.BackColor = Color.Gainsboro
            bt_simpancusto.Text = "Update"
        End If

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        For Each txt As TextBox In {in_namasupplier, in_alamatsupplier, in_telp1supplier, in_telp2supplier, in_faxsupplier, in_cp, in_emailsupplier,
                                    in_npwpsupplier, in_rek_bank, in_rek_giro, in_ket}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        For Each numx As NumericUpDown In {in_term}
            numx.Enabled = AllowInput
        Next

        bt_simpancusto.Enabled = AllowInput
        tstrip_activate.Enabled = AllowInput
        tstrip_status.Visible = IIf(formstate = InputState.Insert, False, AllowInput)
    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        SetUpForm(Nothing, InputState.Insert, AllowInput)
        Me.Show()
        in_namasupplier.Focus()
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, AllowEdit As Boolean)
        SetUpForm(NoFaktur, InputState.Edit, AllowEdit)
        Me.Show()
        in_namasupplier.Focus()
    End Sub

    Private Sub fr_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 100
    End Sub

    'LOAD DATA
    Private Function loadDataSupplier(kode As String) As KeyValuePair(Of Boolean, String)
        Dim q As String = ""
        If MainConnData.IsEmpty Then Return New KeyValuePair(Of Boolean, String)(False, "Main DBConfig is empty.")

        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    q = "CALL getDataMasterHeader('{0}','SUPPLIER')"
                    Using rdx = x.ReadCommand(String.Format(q, kode))
                        Dim red = rdx.Read
                        in_kode.Text = kode
                        in_namasupplier.Text = rdx.Item("supplier_nama")
                        in_alamatsupplier.Text = rdx.Item("supplier_alamat")
                        in_telp1supplier.Text = rdx.Item("supplier_telpon1")
                        in_telp2supplier.Text = rdx.Item("supplier_telpon2")
                        in_faxsupplier.Text = rdx.Item("supplier_fax")
                        in_cp.Text = rdx.Item("supplier_cp")
                        in_emailsupplier.Text = rdx.Item("supplier_email")

                        in_npwpsupplier.Text = rdx.Item("supplier_npwp")
                        in_rek_bank.Text = rdx.Item("supplier_rek_bank")
                        in_rek_giro.Text = rdx.Item("supplier_rek_bg")
                        in_ket.Text = rdx.Item("supplier_keterangan")
                        in_term.Text = rdx.Item("supplier_term")
                        supStatus = rdx.Item("supplier_status")

                        txtRegAlias.Text = rdx.Item("supplier_reg_alias")
                        txtRegdate.Text = rdx.Item("supplier_reg_date")
                        txtUpdDate.Text = rdx.Item("supplier_upd_date")
                        txtUpdAlias.Text = rdx.Item("supplier_upd_alias")
                    End Using
                Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat terhubung ke database.")
                End If
            End Using
            Select Case supStatus
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
    Private Sub SaveData()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Dim q As String = ""
        Dim data1 As String()
        data1 = {
               "supplier_nama='" & mysqlQueryFriendlyStringFeed(in_namasupplier.Text) & "'",
               "supplier_alamat='" & mysqlQueryFriendlyStringFeed(in_alamatsupplier.Text) & "'",
               "supplier_telpon1='" & in_telp1supplier.Text & "'",
               "supplier_telpon2='" & in_telp2supplier.Text & "'",
               "supplier_fax='" & in_faxsupplier.Text & "'",
               "supplier_cp='" & mysqlQueryFriendlyStringFeed(in_cp.Text) & "'",
               "supplier_email='" & in_emailsupplier.Text & "'",
               "supplier_npwp='" & in_npwpsupplier.Text & "'",
               "supplier_rek_bg='" & in_rek_giro.Text & "'",
               "supplier_rek_bank='" & in_rek_bank.Text & "'",
               "supplier_term=" & in_term.Value,
               "supplier_keterangan='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
               "supplier_status='" & supStatus & "'"
               }

        Me.Cursor = Cursors.WaitCursor
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                If formstate = InputState.Insert Then
                    'GENERATE CODE
                    If String.IsNullOrWhiteSpace(in_kode.Text) Then
                        Dim i As Integer = 0
                        q = "SELECT IFNULL(MAX(SUBSTRING(supplier_kode,2)),0) FROM data_supplier_master " _
                            & "WHERE LEFT(supplier_kode,1)='S' AND SUBSTRING(supplier_kode,2) REGEXP '^[0-9]+$'"
                        Try
                            i = CInt(x.ExecScalar(q))
                        Catch ex As Exception
                            logError(ex, True)
                            MessageBox.Show("Terjadikesalahan saat melakukan proses penyimpanan data." & Environment.NewLine & ex.Message,
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            GoTo EndSub
                        End Try
                        Dim _format As String = IIf(i + 1 > 999, "D" & (i + 1).ToString.Length, "D3")
                        in_kode.Text = "S" & (i + 1).ToString(_format)
                    Else
                        q = "SELECT COUNT(supplier_kode) FROM data_supplier_master WHERE supplier_kode='{0}'"
                        If CInt(x.ExecScalar(String.Format(q, in_kode.Text))) <> 0 Then
                            MessageBox.Show("Kode " & in_kode.Text & " sudah pernah diinputkan ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            GoTo EndSub
                        End If
                    End If

                    q = "INSERT INTO data_supplier_master SET supplier_kode='{0}',{1},supplier_reg_date=NOW(), supplier_reg_alias='{2}'"
                Else
                    q = "UPDATE data_supplier_master SET {1},supplier_upd_date=NOW(), supplier_upd_alias='{2}' WHERE supplier_kode='{0}'"
                End If

                Try
                    x.ExecCommand(String.Format(q, in_kode.Text, String.Join(",", data1), loggeduser.user_id))
                    MessageBox.Show("Data supplier tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Data supplier tidak dapat tersimpan." & Environment.NewLine & ex.Message,
                                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GoTo EndSub
                End Try

                DoRefreshTab_v2({pgsupplier})
                Me.Close()
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

EndSub:
        Me.Cursor = Cursors.Default
    End Sub

    'CHANGE DATA STATUS
    'Private Function ChangeDataStatus() As KeyValuePair(Of String, String)

    'End Function

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
    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.Close()
    End Sub

    Private Sub bt_simpansupplier_Click(sender As Object, e As EventArgs) Handles bt_simpancusto.Click
        'CHECK INPUT
        If in_namasupplier.Text = Nothing Then
            MessageBox.Show("Nama supplier belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_namasupplier.Focus() : Exit Sub
        End If
        If Not String.IsNullOrWhiteSpace(in_emailsupplier.Text) Then
            If Not IsValidEmail(in_emailsupplier.Text) Then
                MessageBox.Show("Format alamat email yang dimasukan tidak sesuai.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                in_emailsupplier.Focus() : Exit Sub
            End If
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim _askres As DialogResult = Windows.Forms.DialogResult.Yes
        If formstate <> InputState.Insert Then _askres = MessageBox.Show("Simpan perubahan data?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _askres = Windows.Forms.DialogResult.Yes Then SaveData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalcusto.Click
        bt_cl.PerformClick()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_menu.Click
        Dim _x As Integer = sender.Location.X
        Dim _y As Integer = sender.Location.Y + sender.Height
        ctx_main.Show(pnl_header, _x, _y)
    End Sub

    'UI : NUMERIC INPUT
    Private Sub in_term_Enter(sender As Object, e As EventArgs) Handles in_term.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_term_Leave(sender As Object, e As EventArgs) Handles in_term.Leave
        numericLostFocus(sender)
    End Sub

    'UI : CONTEXT MENU
    Private Sub tstrip_simpan_Click(sender As Object, e As EventArgs) Handles tstrip_simpan.Click
        bt_simpancusto.PerformClick()
    End Sub

    Private Sub tsrtip_close_Click(sender As Object, e As EventArgs) Handles tsrtip_close.Click
        bt_cl.PerformClick()
    End Sub

    Private Sub tstrip_activate_Click(sender As Object, e As EventArgs) Handles tstrip_activate.Click
        If supStatus = 1 Then
            MessageBox.Show("Status data supplier sudah aktif.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub

    Private Sub tstrip_inactivate_Click(sender As Object, e As EventArgs) Handles tstrip_inactivate.Click
        If supStatus = 0 Then
            MessageBox.Show("Status data supplier sudah nonaktif.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub tstrip_delete_Click(sender As Object, e As EventArgs) Handles tstrip_delete.Click

    End Sub
End Class