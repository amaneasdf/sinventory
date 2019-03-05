﻿Public Class fr_user_detail
    Private usrstatus As String = "1"
    Private _popUpPos As String = "sales"
    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(KodeUser As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Detail User : xxxxxxxxx"

        formstate = FormSet

        With cb_group
            .DataSource = getDataTablefromDB("SELECT group_kode, group_nama FROM data_pengguna_group WHERE group_status <> 9")
            .DisplayMember = "group_nama"
            .ValueMember = "group_kode"
            .SelectedIndex = -1
        End With

        ControlSwitch(AllowEdit)

        If Not FormSet = InputState.Insert Then
            Me.Text += KodeUser
            Me.lbl_title.Text += " : " & KodeUser
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            loadDatauser(KodeUser)
            For Each txt As TextBox In {in_userid, in_pass}
                txt.ReadOnly = True
                txt.BackColor = Color.Gainsboro
            Next
            mn_reset.Enabled = IIf(loggeduser.user_id <> in_userid.Text, AllowEdit, True)
            bt_simpanuser.Text = "Update"
        End If

        'ck_pc_CheckStateChanged(Nothing, Nothing)
        'ck_sales_CheckStateChanged(Nothing, Nothing)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        For Each txt As TextBox In {in_email, in_telp, in_karyawan_nama, in_sales_n, in_userid, in_pass}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        For Each ckbx As CheckBox In {ck_pc, ck_sales, ck_adminandro, ck_edit_akun, ck_edit_master, ck_edit_trans, ck_valid_akun, ck_valid_master,
                                      ck_valid_trans, ck_admin_pc}
            ckbx.Enabled = AllowInput
        Next
        cb_group.Enabled = AllowInput
        bt_simpanuser.Enabled = AllowInput
        mn_actdeact.Enabled = AllowInput
        mn_save.Enabled = AllowInput
    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        SetUpForm(Nothing, InputState.Insert, AllowInput)
        Me.Show()
        in_userid.Focus()
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, AllowEdit As Boolean)
        SetUpForm(NoFaktur, InputState.Edit, AllowEdit)
        Me.Show()
        in_email.Focus()
    End Sub

    'LOAD DATA
    Private Sub loadDatauser(kode As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim url As String = Nothing
        Dim q As String = "SELECT user_id,user_alias, user_nama, user_group, user_sales, user_sales_kode, salesman_nama, user_telp," _
                          & "(CASE " _
                          & " WHEN salesman_jenis=1 THEN 'Sales TO' " _
                          & " WHEN salesman_jenis=2 THEN 'Sales Kanvas' " _
                          & " ELSE 'ERROR' END) AS salesman_jenis,user_pc,user_validasi_master, user_validasi_trans, user_gambar, user_email, " _
                          & "user_allowedit_master, user_allowedit_trans, IF(user_login_status=1,'ON','OFF') as user_login_status, " _
                          & "user_allowedit_akun, user_validasi_akun, user_admin_pc, " _
                          & "DATE_FORMAT(user_login_terakhir,'%d/%m/%Y %H:%i:%S') user_login_terakhir, user_status, " _
                          & "DATE_FORMAT(user_reg_date,'%d/%m/%Y %H:%i:%S') user_reg_date, IFNULL(user_reg_alias,'') user_reg_alias, " _
                          & "DATE_FORMAT(user_upd_date,'%d/%m/%Y %H:%i:%S') user_upd_date, IFNULL(user_upd_alias,'') user_upd_alias " _
                          & "FROM data_pengguna_alias LEFT JOIN data_salesman_master ON salesman_kode=user_sales_kode " _
                          & "WHERE user_alias='{0}'"

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Using rdx = x.ReadCommand(String.Format(q, kode))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        'general
                        in_kode.Text = rdx.Item("user_id")
                        in_userid.Text = rdx.Item("user_alias")
                        in_pass.Text = "***********************"
                        in_pass.UseSystemPasswordChar = True
                        in_karyawan_nama.Text = rdx.Item("user_nama")
                        in_email.Text = rdx.Item("user_email")
                        in_telp.Text = rdx.Item("user_telp")
                        'PC
                        If rdx.Item("user_pc") = 1 Then
                            ckPCSW(rdx.Item("user_pc"))
                            'level
                            in_group_kode.Text = rdx.Item("user_group")
                            cb_group.SelectedValue = rdx.Item("user_group")
                            'privilege
                            If rdx.Item("user_validasi_master") = 1 Then ck_valid_master.CheckState = CheckState.Checked
                            If rdx.Item("user_validasi_trans") = 1 Then ck_valid_trans.CheckState = CheckState.Checked
                            If rdx.Item("user_validasi_akun") = 1 Then ck_valid_akun.CheckState = CheckState.Checked
                            If rdx.Item("user_allowedit_trans") = 1 Then ck_edit_trans.CheckState = CheckState.Checked
                            If rdx.Item("user_allowedit_master") = 1 Then ck_edit_master.CheckState = CheckState.Checked
                            If rdx.Item("user_allowedit_akun") = 1 Then ck_edit_akun.CheckState = CheckState.Checked
                            If rdx.Item("user_admin_pc") = 1 Then ck_admin_pc.CheckState = CheckState.Checked
                        End If
                        'sales
                        If {1, 2}.Contains(rdx.Item("user_sales")) Then
                            ckSalesSW(1)
                            If rdx.Item("user_sales") = 1 Then
                                ck_sales.CheckState = CheckState.Checked
                            Else
                                ck_adminandro.CheckState = CheckState.Checked
                            End If
                            in_sales.Text = rdx.Item("user_sales_kode")
                            in_sales_n.Text = rdx.Item("salesman_nama")
                            in_sales_t.Text = rdx.Item("salesman_jenis")
                        End If
                        'status
                        usrstatus = rdx.Item("user_status")
                        in_login_status.Text = rdx.Item("user_login_status")
                        txtLastLogin.Text = rdx.Item("user_login_terakhir")
                        'usrimg
                        url = IIf(IsDBNull(rdx.Item("user_gambar")) = False, rdx.Item("user_gambar"), Nothing)
                        'db
                        txtRegdate.Text = rdx.Item("user_reg_date")
                        txtRegAlias.Text = rdx.Item("user_reg_alias")
                        txtUpdDate.Text = rdx.Item("user_upd_date")
                        txtUpdAlias.Text = rdx.Item("user_upd_alias")
                    End If
                End Using
                setStatus()
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Detail User", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End Using
    End Sub

    Private Sub setStatus()
        Select Case usrstatus
            Case 0
                in_status.Text = "Non-Aktif"
                mn_actdeact.Text = "Activate"
            Case 1, 2
                in_status.Text = "Aktif"
                mn_actdeact.Text = "Deactivate"
            Case 9
                in_status.Text = "Delete"
                mn_actdeact.Enabled = False
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub ckPCSW(swch As String)
        Dim ckPriv As CheckBox() = {ck_edit_akun, ck_edit_master, ck_edit_trans, ck_valid_akun, ck_valid_master, ck_valid_trans}
        If swch = "1" Then
            ck_pc.CheckState = CheckState.Checked
            For Each ck As CheckBox In ckPriv
                ck.Enabled = True
            Next
            cb_group.Enabled = True
            ck_admin_pc.Enabled = True
        Else
            ck_pc.CheckState = CheckState.Unchecked
            For Each ck As CheckBox In ckPriv
                ck.CheckState = CheckState.Unchecked
                ck.Enabled = False
            Next
            in_group_kode.Clear()
            cb_group.SelectedIndex = -1
            cb_group.Enabled = False
            ck_admin_pc.CheckState = CheckState.Unchecked
            ck_admin_pc.Enabled = False
        End If
    End Sub

    Private Sub ckSalesSW(swch As String)
        Dim tx As TextBox() = {in_sales, in_sales_n, in_sales_t}
        If swch = "1" Then
            'ck_sales.CheckState = CheckState.Checked
            For Each x As TextBox In tx
                x.Enabled = True
                x.BackColor = Color.White
            Next
        Else
            'ck_sales.CheckState = CheckState.Unchecked
            For Each x As TextBox In tx
                x.Clear()
                x.Enabled = False
            Next
        End If
    End Sub

    'OPEN FULL WINDOWS SEARCH
    Private Sub searchData(tipe As String)
        Dim q As String = ""
        Using search As New fr_search_dialog

        End Using
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Dim autoco As New AutoCompleteStringCollection
        Select Case tipe
            Case "sales"
                q = "SELECT salesman_kode as 'Kode', salesman_nama as 'Salesman', (CASE " _
                    & " WHEN salesman_jenis=1 THEN 'Sales TO' " _
                    & " WHEN salesman_jenis=2 THEN 'Sales Kanvas' " _
                    & " ELSE 'ERROR' END) AS 'Jenis' FROM data_salesman_master " _
                    & "WHERE salesman_status<>9 AND salesman_nama LIKE '{0}%'"
                dt = getDataTablefromDB(String.Format(q, param))
            Case Else
                Exit Sub
        End Select

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 135
            .Columns(1).Width = 200
        End With
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case _popUpPos
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    in_sales_t.Text = .Cells(2).Value
                    If Trim(in_karyawan_nama.Text) = Nothing Then
                        in_karyawan_nama.Text = in_sales_n.Text
                    End If
                    in_sales_n.Focus()
                Case Else
                    Exit Sub
            End Select

        End With
        popPnl_barang.Visible = False
    End Sub

    '------------drag form
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel2.MouseDown, lbl_title.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove, lbl_title.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel2.MouseUp, lbl_title.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel2.DoubleClick, lbl_title.DoubleClick
        CenterToScreen()
    End Sub

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_bataluser.Click
        If MessageBox.Show("Tutup Form?", "Data User", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'e.Cancel = True
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_bataluser.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub fr_beli_retur_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            Else
                bt_bataluser.PerformClick()
            End If
        End If
    End Sub
    '------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanuser.PerformClick()
    End Sub

    Private Sub mn_actdeact_Click(sender As Object, e As EventArgs) Handles mn_actdeact.Click
        If MessageBox.Show("Ubah status user?", "Data User", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If mn_actdeact.Text = "Deactivate" Then
                usrstatus = 0
                setStatus()
            Else
                usrstatus = 1
                setStatus()
            End If
        End If
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click
        'delData()
    End Sub

    Private Sub mn_reset_Click(sender As Object, e As EventArgs) Handles mn_reset.Click
        Dim q As String = ""
        Dim queryArr As New List(Of String)
        Dim queryCheck As Boolean = False

        op_con()
        If MsgBox("Apakah yakin akan mereset password user ini?", MsgBoxStyle.YesNo, "Data User") = MsgBoxResult.Yes Then
            q = "UPDATE data_pengguna_alias SET user_pwd = MD5('123456'), user_status=2, user_upd_date=NOW(), user_upd_alias='{1}' WHERE user_alias = '{0}'"
            queryArr.Add(String.Format(q, in_userid.Text, loggeduser.user_id))

            q = "INSERT INTO system_pwdchange_log(log_alias1,log_alias2,log_ip,log_tanggal) VALUE({0})"
            Dim data As String() = {"'" & in_userid.Text & "'", "'" & loggeduser.user_id & "'", "'" & loggeduser.user_ip & "'", "NOW()"}
            queryArr.Add(String.Format(q, String.Join(",", data)))

            queryCheck = startTrans(queryArr, False)


            If queryCheck = True Then
                MessageBox.Show("Password telah direset, password defaultnya: 123456 ", "Data User", MessageBoxButtons.OK)
                Me.Close()
            Else
                MessageBox.Show("Telah terjadi kesalahan. Password gagal direset.", "Data User", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            Exit Sub
        End If
    End Sub

    'SAVE
    Private Sub saveData()
        Dim q As String = ""
        Dim data As String()
        Dim querycheck As Boolean = False

        data = {
            "user_nama='" & in_karyawan_nama.Text & "'",
            "user_email='" & in_email.Text & "'",
            "user_telp='" & in_telp.Text & "'",
            "user_pc='" & IIf(ck_pc.Checked = True, 1, 0) & "'",
            "user_group='" & in_group_kode.Text & "'",
            "user_validasi_master='" & IIf(ck_valid_master.Checked = True, 1, 0) & "'",
            "user_validasi_trans='" & IIf(ck_valid_trans.Checked = True, 1, 0) & "'",
            "user_validasi_akun='" & IIf(ck_valid_akun.Checked = True, 1, 0) & "'",
            "user_allowedit_master='" & IIf(ck_edit_master.Checked = True, 1, 0) & "'",
            "user_allowedit_trans='" & IIf(ck_edit_trans.Checked = True, 1, 0) & "'",
            "user_allowedit_akun='" & IIf(ck_edit_akun.Checked = True, 1, 0) & "'",
            "user_admin_pc='" & IIf(ck_admin_pc.Checked = True, 1, 0) & "'",
            "user_status='" & usrstatus & "'",
            "user_sales='" & IIf(ck_sales.Checked = True, 1, IIf(ck_adminandro.Checked = True, 2, 0)) & "'",
            "user_sales_kode='" & in_sales.Text & "'"
            }

        If bt_simpanuser.Text = "Simpan" Then
            If checkdata("data_pengguna_alias", "'" & in_userid.Text & "'", "user_alias") = True Then
                MessageBox.Show("Username sudah ada")
                in_userid.Focus()
                Exit Sub
            End If

            Dim pass As String = in_pass.Text
            q = "INSERT INTO data_pengguna_alias SET user_alias='{0}', user_pwd=MD5('" & pass & "'),{1},user_reg_date=NOW(),user_reg_alias='{2}'"
        ElseIf bt_simpanuser.Text = "Update" Then
            q = "UPDATE data_pengguna_alias SET {1},user_upd_alias='{2}', user_upd_date=NOW() WHERE user_alias='{0}'"
        End If

        querycheck = commnd(String.Format(q, in_userid.Text, String.Join(",", data), loggeduser.user_id))

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            doRefreshTab({pguser})
            Me.Close()
        End If
    End Sub

    'DELETE
    Private Sub delData()

    End Sub

    'SAVE
    Private Sub bt_simpanuser_Click(sender As Object, e As EventArgs) Handles bt_simpanuser.Click
        If in_kode.Text = Nothing Then
            If in_userid.Text = Nothing Then
                MessageBox.Show("UserID belum di input")
                in_userid.Focus()
                Exit Sub
            End If

            If in_pass.Text = Nothing Then
                MessageBox.Show("Password belum di input")
                in_pass.Focus()
                Exit Sub
            End If
        End If

        If ck_pc.CheckState = CheckState.Checked And in_group_kode.Text = Nothing Then
            MessageBox.Show("Group user belum di pilih")
            cb_group.Focus()
            Exit Sub
        End If

        If (ck_sales.CheckState = CheckState.Checked Or ck_adminandro.CheckState = CheckState.Checked) And (in_sales.Text = Nothing Or UCase(in_sales_t.Text) = "ERROR") Then
            MessageBox.Show("Salesman belum di input")
            in_sales_n.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan data user?", "Data User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    'UI
    '------------- POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_sales_n.Focused Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub dgv_listbarang_CellContentDBLClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellDoubleClick
        If e.RowIndex >= 0 Then
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            Dim x As TextBox
            Select Case _popUpPos
                Case "sales"
                    x = in_sales_n
                Case Else
                    x = Nothing
                    x.Dispose()
                    Exit Sub
            End Select
            x.Text += e.KeyChar
            e.Handled = True
            x.Focus()
            x.Select(x.TextLength, x.TextLength)
        End If
    End Sub

    'Other
    Private Sub in_userid_KeyUp(sender As Object, e As KeyEventArgs) Handles in_userid.KeyUp
        keyshortenter(in_pass, e)
    End Sub

    Private Sub in_pass_KeyUp(sender As Object, e As KeyEventArgs) Handles in_pass.KeyUp
        keyshortenter(in_karyawan_nama, e)
    End Sub

    Private Sub in_karyawan_nama_KeyUp(sender As Object, e As KeyEventArgs) Handles in_karyawan_nama.KeyUp
        keyshortenter(cb_group, e)
    End Sub

    'PC
    Private Sub ck_pc_CheckStateChanged(sender As Object, e As EventArgs) Handles ck_pc.CheckStateChanged
        If ck_pc.CheckState = CheckState.Checked Then
            ckPCSW(1)
        Else
            ckPCSW(0)
        End If
    End Sub

    Private Sub cb_group_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_group.KeyPress
        If e.KeyChar <> ControlChars.Cr Then
            e.Handled = True
        End If
    End Sub

    Private Sub cb_group_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_group.KeyUp
        keyshortenter(bt_simpanuser, e)
    End Sub

    Private Sub cb_group_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_group.SelectionChangeCommitted
        in_group_kode.Text = cb_group.SelectedValue
    End Sub

    Private Sub in_sales_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales.KeyUp
        keyshortenter(in_sales_n, e)
    End Sub

    'Sales
    Private Sub ck_sales_CheckStateChanged(sender As Object, e As EventArgs) Handles ck_sales.CheckStateChanged, ck_adminandro.CheckStateChanged
        If sender.CheckState = CheckState.Checked Then
            Dim _prevslskd As String = in_sales.Text
            Dim _prevslsnm As String = in_sales_n.Text
            Dim _prevslstp As String = in_sales_t.Text
            Dim move As Boolean = False
            If sender.Name.ToString = "ck_sales" And ck_adminandro.CheckState = CheckState.Checked Then
                ck_adminandro.CheckState = CheckState.Unchecked
                move = True
            ElseIf sender.Name.ToString = "ck_adminandro" And ck_sales.CheckState = CheckState.Checked Then
                ck_sales.CheckState = CheckState.Unchecked
                move = True
            End If
            ckSalesSW(1)
            If move = True Then
                in_sales.Text = _prevslskd
                in_sales_n.Text = _prevslsnm
                in_sales_t.Text = _prevslstp
            End If
        Else
            ckSalesSW(0)
        End If
    End Sub

    Private Sub in_sales_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter
        If in_sales_n.Enabled = True Then
            popPnl_barang.Location = New Point(in_sales_n.Left, in_sales_n.Top + in_sales_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            _popUpPos = "sales"
            loadDataBRGPopup("sales", in_sales_n.Text)
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(bt_simpanuser, e)
        Else
            If in_sales_n.Enabled = True Then
                If popPnl_barang.Visible = False Then
                    popPnl_barang.Visible = True
                End If
                loadDataBRGPopup("sales", in_sales_n.Text)
            End If
        End If
    End Sub

    Private Sub in_supplier_n_TextChanged(sender As Object, e As EventArgs) Handles in_sales_n.TextChanged
        If in_sales_n.Text = "" Then
            in_sales_n.Clear()
            in_sales_t.Clear()
        End If
    End Sub
End Class