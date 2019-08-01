Public Class fr_gudang_detail
    Private gdgStatus As String = "1"
    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(KodeGudang As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Data Gudang : rb201908"

        formstate = FormSet

        If Not FormSet = InputState.Insert Then
            Me.Text += KodeGudang
            Me.lbl_title.Text += " : " & KodeGudang
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            loadDataGudang(KodeGudang)
            If Not {0, 1}.Contains(gdgStatus) Then AllowEdit = False
            in_kode.ReadOnly = IIf(formstate = InputState.Insert, False, True)
            bt_simpancusto.Text = "Update"
        End If

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        For Each txt As TextBox In {in_namagudang, in_alamatgudang, in_ket}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next

        bt_simpancusto.Enabled = AllowInput
        mn_deact.Enabled = IIf(formstate = InputState.Insert, False, AllowInput)
        mn_del.Enabled = IIf(formstate = InputState.Insert, False, False)
        mn_save.Enabled = AllowInput
    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        SetUpForm(Nothing, InputState.Insert, AllowInput)
        Me.Show()
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, AllowEdit As Boolean)
        SetUpForm(NoFaktur, InputState.Edit, AllowEdit)
        Me.Show()
    End Sub

    'LOAD DATA
    Private Sub loadDataGudang(kode As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim q As String = "SELECT gudang_nama,gudang_alamat,gudang_ket, gudang_status, IFNULL(gudang_reg_alias,'') gudang_reg_alias, " _
                          & "DATE_FORMAT(IFNULL(gudang_reg_date,'00/00/0000 00:00:00'),'%d/%m/%Y %H:%i:%S') gudang_reg_date, IFNULL(gudang_upd_alias,'') gudang_upd_alias, " _
                          & "DATE_FORMAT(IFNULL(gudang_upd_date,'00/00/0000 00:00:00'),'%d/%m/%Y %H:%i:%S') gudang_upd_date " _
                          & "FROM data_barang_gudang WHERE gudang_kode='{0}'"
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Using rdx = x.ReadCommand(String.Format(q, kode), CommandBehavior.SingleRow)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_kode.Text = kode
                        in_namagudang.Text = rdx.Item("gudang_nama")
                        in_alamatgudang.Text = rdx.Item("gudang_alamat")
                        gdgStatus = rdx.Item("gudang_status")
                        in_ket.Text = rdx.Item("gudang_ket")
                        txtRegdate.Text = rdx.Item("gudang_reg_date")
                        txtRegAlias.Text = rdx.Item("gudang_reg_alias")
                        txtUpdDate.Text = rdx.Item("gudang_upd_date")
                        txtUpdAlias.Text = rdx.Item("gudang_upd_alias")
                    End If
                End Using
                setStatus()
            End If
        End Using
    End Sub

    Private Sub setStatus()
        Select Case gdgStatus
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
        'If MessageBox.Show("Tutup Form?", "Gudang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
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

    Private Sub fr_gudang_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_batalcusto.PerformClick()
        End If
    End Sub

    'MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpancusto.PerformClick()
    End Sub

    Private Sub mn_deact_Click(sender As Object, e As EventArgs) Handles mn_deact.Click
        Dim ckdata = MasterConfirmValid(in_ket.Text)
        If Not ckdata Then Exit Sub

        If mn_deact.Text = "Deactivate" Then
            gdgStatus = "0"
        ElseIf mn_deact.Text = "Activate" Then
            gdgStatus = "1"
        End If
        setStatus() : bt_simpancusto.PerformClick()
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click
        'brgStatus = 9
        'UPDATE STATUS TO 9
        'setStatus()
    End Sub

    'SAVE
    Private Sub bt_simpangudang_Click(sender As Object, e As EventArgs) Handles bt_simpancusto.Click
        If in_namagudang.Text = Nothing Then
            MessageBox.Show("Nama gudang belum di input")
            in_namagudang.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim _askRes As DialogResult = Windows.Forms.DialogResult.Yes
        If Not formstate = InputState.Insert Then _askRes = MessageBox.Show("Simpan perubahan data?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _askRes = Windows.Forms.DialogResult.Yes Then saveData()
        Me.Cursor = Cursors.Default
    End Sub

    'UI
    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(in_namagudang, e)
    End Sub

    Private Sub in_namagudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_namagudang.KeyDown
        keyshortenter(in_alamatgudang, e)
    End Sub
End Class