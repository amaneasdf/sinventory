Public Class fr_user_detail
    Private usrstatus As String = "1"
    Private _popUpPos As String = "sales"


    Private Sub loadDatauser(kode As String)
        Dim url As String = Nothing
        Dim q As String = "SELECT user_id,user_alias, user_nama, user_group, user_sales, user_sales_kode, salesman_nama," _
                          & "(CASE " _
                          & " WHEN salesman_jenis=1 THEN 'Sales TO' " _
                          & " WHEN salesman_jenis=2 THEN 'Sales Kanvas' " _
                          & " ELSE 'ERROR' END) AS salesman_jenis, user_validasi_master, user_validasi_trans, user_gambar, user_email, " _
                          & "user_allowedit_master, user_allowedit_trans, IF(user_login_status=1,'ON','OFF') as user_login_status, " _
                          & "user_login_terakhir, user_status, user_reg_date, user_reg_alias, user_upd_date, user_upd_alias " _
                          & "FROM data_pengguna_alias LEFT JOIN data_salesman_master ON salesman_kode=user_sales_kode " _
                          & "WHERE user_alias='{0}'"

        op_con()
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            'general
            in_kode.Text = rd.Item("user_id")
            in_userid.Text = rd.Item("user_alias")
            in_pass.Text = "***********************"
            in_pass.UseSystemPasswordChar = True
            in_karyawan_nama.Text = rd.Item("user_nama")
            in_email.Text = rd.Item("user_email")
            'level
            in_group_kode.Text = rd.Item("user_group")
            cb_group.SelectedValue = rd.Item("user_group")
            'privilege
            If rd.Item("user_validasi_master") = 1 Then
                ck_valid_master.CheckState = CheckState.Checked
            End If
            If rd.Item("user_validasi_trans") = 1 Then
                ck_valid_trans.CheckState = CheckState.Checked
            End If
            If rd.Item("user_allowedit_trans") = 1 Then
                ck_edit_trans.CheckState = CheckState.Checked
            End If
            If rd.Item("user_allowedit_master") = 1 Then
                ck_edit_master.CheckState = CheckState.Checked
            End If
            'sales
            If rd.Item("user_sales") = 1 Then
                ckSalesSW(rd.Item("user_sales"))
                in_sales.Text = rd.Item("user_sales_kode")
                in_sales_n.Text = rd.Item("salesman_nama")
                in_sales_t.Text = rd.Item("salesman_jenis")
            End If
            'status
            usrstatus = rd.Item("user_status")
            in_login_status.Text = rd.Item("user_login_status")
            Try
                txtLastLogin.Text = rd.Item("user_login_terakhir")
            Catch ex As Exception
                txtLastLogin.Text = "00/00/0000 00:00:00"
            End Try
            'usrimg
            url = IIf(IsDBNull(rd.Item("user_gambar")) = False, rd.Item("user_gambar"), Nothing)
            'db
            txtRegdate.Text = rd.Item("user_reg_date")
            txtRegAlias.Text = rd.Item("user_reg_alias")
            Try
                txtUpdDate.Text = rd.Item("user_upd_date")
            Catch ex As Exception
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("user_upd_alias")
            'txtExpDate.Text = rd.Item("user_exp_date")
        End If

        rd.Close()
        setStatus()
        'If url <> Nothing Then
        '    pb_usrimg.Image = streamImgUrl(url)
        'End If
    End Sub

    Private Sub setStatus()
        Select Case usrstatus
            Case 0
                in_status.Text = "Non-Aktif"
                mn_actdeact.Text = "Activate"
            Case 1
                in_status.Text = "Aktif"
                mn_actdeact.Text = "Deactivate"
            Case 9
                in_status.Text = "Delete"
                mn_actdeact.Enabled = False
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub ckSalesSW(swch As String)
        Dim tx As TextBox() = {in_sales, in_sales_n, in_sales_t}
        If swch = "1" Then
            ck_sales.CheckState = CheckState.Checked
            For Each x As TextBox In tx
                x.Enabled = True
            Next
        Else
            ck_sales.CheckState = CheckState.Unchecked
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

    '------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanuser.PerformClick()
    End Sub

    Private Sub mn_actdeact_Click(sender As Object, e As EventArgs) Handles mn_actdeact.Click
        If mn_actdeact.Text = "Deactivate" Then
            usrstatus = 0
            setStatus()
        Else
            usrstatus = 1
            setStatus()
        End If
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click
        'delData()
    End Sub

    Private Sub mn_reset_Click(sender As Object, e As EventArgs) Handles mn_reset.Click
        Dim q As String = "UPDATE data_pengguna_alias SET user_password = MD5('123456'), " _
                          & "user_upd_date=NOW(), user_upd_alias='{1}' WHERE user_alias = '{0}'"
        Dim queryCheck As Boolean = False

        If MsgBox("Apakah yakin akan mereset password user ini?", MsgBoxStyle.YesNo, "Data User") = MsgBoxResult.Yes Then
            queryCheck = commnd(String.Format(q, in_userid.Text, loggeduser.user_id))

            If queryCheck = True Then
                MsgBox("Password telah reset, password defaultnya: 123456 ", MsgBoxStyle.Information, Application.ProductName)
                Me.Close()
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
            "user_group='" & in_group_kode.Text & "'",
            "user_validasi_master='" & IIf(ck_valid_master.Checked = True, 1, 0) & "'",
            "user_validasi_trans='" & IIf(ck_valid_trans.Checked = True, 1, 0) & "'",
            "user_allowedit_master='" & IIf(ck_edit_master.Checked = True, 1, 0) & "'",
            "user_allowedit_trans='" & IIf(ck_edit_trans.Checked = True, 1, 0) & "'",
            "user_status='" & usrstatus & "'",
            "user_sales='" & IIf(ck_sales.Checked = True, 1, 0) & "'",
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

    'LOAD
    Private Sub do_load()

    End Sub

    Private Sub fr_user_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        op_con()
        With cb_group
            .DataSource = getDataTablefromDB("select group_kode, group_nama from data_pengguna_group")
            .DisplayMember = "group_nama"
            .ValueMember = "group_kode"
            .SelectedIndex = -1
        End With

        If bt_simpanuser.Text = "Update" Then
            For Each txt As TextBox In {in_userid, in_pass}
                With txt
                    .ReadOnly = True
                    .BackColor = Color.Gainsboro
                End With
            Next
            loadDatauser(in_kode.Text)
            mn_actdeact.Enabled = True
            mn_reset.Enabled = True
        End If
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

        If in_group_kode.Text = Nothing Then
            MessageBox.Show("Group user belum di pilih")
            cb_group.Focus()
            Exit Sub
        End If

        If ck_sales.CheckState = CheckState.Checked And (in_sales.Text = Nothing Or UCase(in_sales_t.Text) = "ERROR") Then
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
    Private Sub ck_sales_CheckStateChanged(sender As Object, e As EventArgs) Handles ck_sales.CheckStateChanged
        If ck_sales.CheckState = CheckState.Checked Then
            ckSalesSW(1)
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