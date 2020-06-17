Public Class fr_gudang_detail
    Private gdgStatus As String = "1"
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
        Me.Opacity = 0 : formstate = FormSet

        If Not FormSet = InputState.Insert Then
            Dim _resp = loadDataGudang(KodeGudang)
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
            If formstate = InputState.Edit Then bt_simpancusto.Text = "Update"
        Else
            in_kode.ReadOnly = False
        End If

        For Each txt As TextBox In {in_namagudang, in_alamatgudang, in_ket}
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
    Private Function loadDataGudang(kode As String) As KeyValuePair(Of Boolean, String)
        Dim q As String = ""
        If MainConnData.IsEmpty Then Return New KeyValuePair(Of Boolean, String)(False, "Main DBConfig is empty.")

        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    q = "CALL getDataMasterHeader('{0}','GUDANG')"
                    Using rdx = x.ReadCommand(String.Format(q, kode), CommandBehavior.SingleRow)
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            in_kode.Text = kode
                            in_namagudang.Text = rdx.Item("gudang_nama")
                            in_alamatgudang.Text = rdx.Item("gudang_alamat")
                            in_ket.Text = rdx.Item("gudang_ket")
                            gdgStatus = rdx.Item("gudang_status")

                            txtRegdate.Text = rdx.Item("gudang_reg_date")
                            txtRegAlias.Text = rdx.Item("gudang_reg_alias")
                            txtUpdDate.Text = rdx.Item("gudang_upd_date")
                            txtUpdAlias.Text = rdx.Item("gudang_upd_alias")
                        End If
                    End Using
                    Select Case gdgStatus
                        Case 0 : in_status.Text = "Non-Aktif"
                        Case 1 : in_status.Text = "Aktif"
                        Case 9 : in_status.Text = "Delete"
                        Case Else
                            Return New KeyValuePair(Of Boolean, String)(False, "Status data ")
                    End Select

                    Return New KeyValuePair(Of Boolean, String)(True, "OK")
                Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat terhubung ke database.")
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            Return New KeyValuePair(Of Boolean, String)(False, "Terjadi kesalahan saat melakukan pengambilan data." & Environment.NewLine & ex.Message)
        End Try
    End Function

    'SAVE DATA
    Private Sub saveData()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim data1 As String()
        Dim q As String = ""

        Me.Cursor = Cursors.WaitCursor
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                data1 = {
                    "gudang_nama='" & in_namagudang.Text.Replace("'", "`") & "'",
                    "gudang_alamat='" & in_alamatgudang.Text.Replace("'", "`") & "'",
                    "gudang_ket='" & in_ket.Text.Replace("'", "`") & "'",
                    "gudang_status='" & gdgStatus & "'"
                }

                If formstate = InputState.Insert Then
                    'GENERATE CODE
                    If String.IsNullOrWhiteSpace(in_kode.Text) Then
                        Dim i As Integer = 0
                        q = "SELECT IFNULL(MAX(SUBSTRING(gudang_kode,3)),0) FROM data_barang_gudang " _
                            & "WHERE LEFT(gudang_kode,2)='GD' AND SUBSTRING(gudang_kode,3) REGEXP '^[0-9]+$'"
                        Try
                            i = CInt(x.ExecScalar(q))
                        Catch ex As Exception
                            logError(ex, False)
                            MessageBox.Show("Terjadikesalahan saat melakukan proses penyimpanan data." & Environment.NewLine & ex.Message,
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            GoTo EndSub
                        End Try
                        Dim _format As String = IIf(i + 1 > 999, "D" & (i + 1).ToString.Length, "D3")
                        in_kode.Text = "GD" & (i + 1).ToString(_format)
                    Else
                        q = "SELECT COUNT(gudang_kode) FROM data_barang_gudang WHERE gudang_kode='{0}'"
                        If CInt(x.ExecScalar(String.Format(q, in_kode.Text))) <> 0 Then
                            MessageBox.Show("Kode " & in_kode.Text & " sudah pernah diinputkan ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            GoTo EndSub
                        End If
                    End If
                    q = "INSERT INTO data_barang_gudang SET gudang_kode='{0}',{1},gudang_reg_date=NOW(), gudang_reg_alias='{2}'"
                Else
                    q = "UPDATE data_barang_gudang SET {1},gudang_upd_date=NOW(), gudang_upd_alias='{2}' WHERE gudang_kode='{0}'"
                End If

                Try
                    x.ExecCommand(String.Format(q, in_kode.Text, String.Join(",", data1), loggeduser.user_id))
                    MessageBox.Show("Data gudang tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Data gudang tidak dapat tersimpan." & Environment.NewLine & ex.Message,
                                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GoTo EndSub
                End Try

                DoRefreshTab_v2({pggudang})
                Me.Close()
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

EndSub:
        Me.Cursor = Cursors.Default
    End Sub

    'UI : FORM/DRAG FORM
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

    Private Sub bt_simpangudang_Click(sender As Object, e As EventArgs) Handles bt_simpancusto.Click
        If in_namagudang.Text = Nothing Then
            MessageBox.Show("Nama gudang belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_namagudang.Focus() : Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim _askRes As DialogResult = Windows.Forms.DialogResult.Yes
        If Not formstate = InputState.Insert Then _askRes = MessageBox.Show("Simpan perubahan data?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _askRes = Windows.Forms.DialogResult.Yes Then saveData()
        Me.Cursor = Cursors.Default
    End Sub

    'UI : CONTEXT MENU
    Private Sub tstrip_simpan_Click(sender As Object, e As EventArgs) Handles tstrip_simpan.Click
        bt_simpancusto.PerformClick()
    End Sub

    Private Sub tsrtip_close_Click(sender As Object, e As EventArgs) Handles tsrtip_close.Click
        bt_cl.PerformClick()
    End Sub

    Private Sub tstrip_activate_Click(sender As Object, e As EventArgs) Handles tstrip_activate.Click
        If gdgStatus = 1 Then
            MessageBox.Show("Status data gudang sudah aktif.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub

    Private Sub tstrip_inactivate_Click(sender As Object, e As EventArgs) Handles tstrip_inactivate.Click
        If gdgStatus = 0 Then
            MessageBox.Show("Status data gudang sudah nonaktif.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub tstrip_delete_Click(sender As Object, e As EventArgs) Handles tstrip_delete.Click

    End Sub
End Class