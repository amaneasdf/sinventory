Public Class fr_group_detail
    Private usrstatus As String = "1"
    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(KodeUser As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Data User Group : xxxxxxxxx"

        formstate = FormSet
        populateTree()
        StartPosition = FormStartPosition.CenterScreen

        If Not FormSet = InputState.Insert Then
            Me.Text += KodeUser
            Me.lbl_title.Text += " : " & KodeUser
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            getGroupData(KodeUser)
            treeviewCheck()
            bt_simpan_group.Text = "Update"
        End If

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        For Each txt As TextBox In {in_kode, in_ket_group, in_nama_group}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next

        tv_menu.Enabled = AllowInput
        bt_simpan_group.Enabled = AllowInput
        bt_tv_reset.Enabled = AllowInput
        bt_tv_checkall_group.Enabled = AllowInput
        mn_actdeact.Enabled = IIf(formstate = InputState.Insert, False, AllowInput)
        mn_save.Enabled = AllowInput
    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        SetUpForm(Nothing, InputState.Insert, AllowInput)
        Me.Show()
        in_nama_group.Focus()
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, AllowEdit As Boolean)
        SetUpForm(NoFaktur, InputState.Edit, AllowEdit)
        Me.Show()
        in_nama_group.Focus()
    End Sub

    'LOAD DATA
    Private Sub getGroupData(kode As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim q As String = "SELECT group_kode, group_nama, group_keterangan, group_status, " _
                          & "DATE_FORMAT(group_reg_date,'%d/%m/%Y %H:%i') group_reg_date, IFNULL(group_reg_alias,'') group_reg_alias, " _
                          & "DATE_FORMAT(group_upd_date,'%d/%m/%Y %H:%i') group_upd_date, IFNULL(group_upd_alias,'') group_upd_alias " _
                          & "FROM data_pengguna_group WHERE group_kode='{0}'"
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Using rdx = x.ReadCommand(String.Format(q, kode))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_kode.Text = rdx.Item("group_kode")
                        in_nama_group.Text = rdx.Item("group_nama")
                        in_ket_group.Text = rdx.Item("group_keterangan")
                        usrstatus = rdx.Item("group_status")

                        txtRegAlias.Text = rdx.Item("group_reg_alias")
                        txtRegdate.Text = rdx.Item("group_reg_date")
                        txtUpdDate.Text = rdx.Item("group_upd_date")
                        txtUpdAlias.Text = rdx.Item("group_upd_alias")
                    End If
                End Using
                setStatus()
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Detail Group User", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End Using
    End Sub

    Private Sub treeviewCheck()
        Dim fd As Boolean = False
        Dim MenuKode As String

        RemoveHandler tv_menu.AfterCheck, AddressOf tv_menu_AfterCheck
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = "SELECT menu_kode FROM kode_menu WHERE menu_status=1 AND menu_group='{0}' ORDER BY menu_kode ASC"
                Using rdx = x.ReadCommand(String.Format(q, in_kode.Text))
                    Dim _start = Now
                    Do While rdx.Read
                        MenuKode = rdx.Item("menu_kode").ToString
                        'CheckMenuKode(MenuKode, tv_menu.Nodes)
                        For Each item As TreeNode In tv_menu.Nodes
                            If treeCK(item, MenuKode) = True Then Exit For
                            If MenuKode.Length > 4 Then
                                For Each ChildNode As TreeNode In item.Nodes
                                    If treeCK(ChildNode, MenuKode) Then GoTo NextMenuCode
                                    If MenuKode.Length > 6 Then
                                        For Each Child2 As TreeNode In ChildNode.Nodes
                                            If treeCK(Child2, MenuKode) Then GoTo NextMenuCode
                                        Next
                                    End If
                                Next
                            End If
                        Next
NextMenuCode:
                    Loop
                    consoleWriteLine(DateDiff(DateInterval.Second, _start, Now))
                End Using
            End If
        End Using
        AddHandler tv_menu.AfterCheck, AddressOf tv_menu_AfterCheck
    End Sub

    'menutree
    Private Sub populateTree()
        Dim ParentNode As New TreeNode
        Dim ChildNode, ChildNode2 As New TreeNode
        Dim MenuKode, MenuLabel As String

        tv_menu.Nodes.Clear()
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Using rdx = x.ReadCommand("SELECT menu_kode, menu_label FROM data_menu_master WHERE menu_status=1 ORDER BY menu_kode")
                    Do While rdx.Read
                        MenuKode = rdx.Item("menu_kode").ToString
                        MenuLabel = Mid(MenuKode, 3, 20) & ". " & rdx.Item("menu_label").ToString
                        consoleWriteLine(rdx.Item("menu_kode").ToString)
                        If Len(MenuKode) = 4 Then
                            Dim node1 As New TreeNode(MenuLabel)
                            ParentNode = node1
                            tv_menu.Nodes.Add(ParentNode)
                        End If
                        If Len(MenuKode) = 6 Then
                            Dim node2 As New TreeNode(MenuLabel)
                            ChildNode = node2
                            ParentNode.Nodes.Add(ChildNode)
                        End If
                        If Len(MenuKode) = 8 Then
                            Dim node3 As New TreeNode(MenuLabel)
                            ChildNode2 = node3
                            ChildNode.Nodes.Add(ChildNode2)
                        End If
                    Loop
                End Using
                tv_menu.ExpandAll()
            Else
                MessageBox.Show("Data menu tidak dapat diambil. Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Function CheckMenuKode(MenuKode As String, Nodes As TreeNodeCollection, Optional KodeLength As Integer = 4) As Boolean
        For Each item As TreeNode In Nodes
            consoleWriteLine("mn" & SplitText(item.Text, ".", 0) & ":" & MenuKode)
            If treeCK(item, MenuKode) Then Return True
            If MenuKode.Length > KodeLength Then
                If CheckMenuKode(MenuKode, item.Nodes, KodeLength + 2) Then Return True
            End If
        Next
        Return False
    End Function

    Private Function treeCK(nodes As TreeNode, menukode As String) As Boolean
        Dim NodesName As String = "mn" & SplitText(nodes.Text, ".", 0)
        If NodesName = menukode Then
            nodes.Checked = True : Return True
        Else
            Return False
        End If
    End Function

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

    Private Sub treeviewAllCheckSwitch(TreeNodes As TreeNodeCollection, CheckState As Boolean)
        For Each item As TreeNode In TreeNodes
            item.Checked = CheckState
            treeviewAllCheckSwitch(item.Nodes, CheckState)
        Next
    End Sub

    'SAVE
    Private Sub saveData()
        Dim q As String = ""
        Dim queryCheck As Boolean = False
        Dim queryArr As New List(Of String)
        Dim _listcode As New List(Of String)

        Me.Cursor = Cursors.WaitCursor
        Dim dh = {"group_nama='" & in_nama_group.Text & "'",
                  "group_keterangan='" & mysqlQueryFriendlyStringFeed(in_ket_group.Text) & "'",
                  "group_status=" & usrstatus
                 }

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                'SAVE HEADER
                If formstate = InputState.Insert Then
                    Dim i As Integer = 0
                    q = "SELECT IFNULL(MAX(group_kode),0) FROM data_pengguna_group WHERE group_kode REGEXP '^[0-9]+$'"
                    i = Integer.Parse(x.ExecScalar(q))
                    in_kode.Text = i + 1

                    q = "INSERT INTO data_pengguna_group SET group_kode={0}, {1},group_reg_date=NOW(),group_reg_alias='{2}'"
                Else
                    q = "UPDATE data_pengguna_group SET {1},group_upd_date=NOW(),group_upd_alias='{2}' WHERE group_kode={0}"
                End If
                queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", dh), loggeduser.user_id))

                'SAVE SELECTED MENU
                q = "UPDATE kode_menu SET menu_status=9 WHERE menu_group='{0}' AND menu_status<>9"
                queryArr.Add(String.Format(q, in_kode.Text))

                For Each item As TreeNode In tv_menu.Nodes
                    'Parent Node
                    If item.Checked = True Then
                        _listcode.Add(item.Text)
                        'ChildNode - 1
                        For Each ChildNode As TreeNode In item.Nodes
                            If ChildNode.Checked = True Then _listcode.Add(ChildNode.Text)
                            'ChildNode - 2
                            For Each Child2 As TreeNode In ChildNode.Nodes
                                If Child2.Checked = True Then _listcode.Add(Child2.Text)
                            Next
                        Next
                    End If
                Next

                For Each _strcode As String In _listcode
                    _strcode = "mn" & SplitText(_strcode, ".", 0)
                    Dim dm = {"menu_kode='" & _strcode & "'",
                              "menu_status='1'"
                             }
                    q = "INSERT INTO kode_menu SET menu_group='{0}',{1},menu_reg_date=NOW(),menu_reg_alias='{2}' " _
                        & "ON DUPLICATE KEY UPDATE {1},menu_upd_date=NOW(),menu_upd_alias='{2}'"
                    queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", dm), loggeduser.user_id))
                Next

                'BEGIN TRANSACTION
                queryCheck = x.TransactCommand(queryArr)

                If queryCheck Then
                    MessageBox.Show("Data user group tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pggroup, pguser}) : Me.Close()
                Else
                    MessageBox.Show("Data user group tidak dapat tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Sub ChangeDataStatus(NewStatus As Integer)
        Dim q As String = ""
        Dim queryCheck As Boolean = False
        Dim queryArr As New List(Of String)

        q = "UPDATE data_pengguna_group SET group_status={1}, group_upd_date=NOW(),group_upd_alias='{2}' WHERE group_kode={0}"
        queryArr.Add(String.Format(q, in_kode.Text, NewStatus, loggeduser.user_id))
        If NewStatus = 9 Then
            q = "UPDATE kode_menu SET menu_status=9 WHERE menu_group='{0}' AND menu_status<>9"
            queryArr.Add(String.Format(q, in_kode.Text))
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                queryCheck = x.TransactCommand(queryArr)
                If queryCheck Then
                    MessageBox.Show("Status data user group tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pggroup, pguser})
                    usrstatus = NewStatus : setStatus()
                Else
                    MessageBox.Show("Status data user group tidak dapat tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batal_group.Click
        'If MessageBox.Show("Tutup Form?", "Data User Group", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        Me.Close()
        'End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batal_group.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpan_group.PerformClick()
    End Sub

    Private Sub mn_actdeact_Click(sender As Object, e As EventArgs) Handles mn_actdeact.Click
        Dim _newstatus As Integer = usrstatus : Dim _msg As String = ""
        If mn_actdeact.Text = "Deactivate" Then
            _newstatus = 0 : _msg = "Nonaktifkan user group?"
        Else
            _newstatus = 1 : _msg = "Aktifkan user group?"
        End If
        If MessageBox.Show(_msg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            ChangeDataStatus(_newstatus)
        End If
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click
        'delData()
    End Sub

    'SAVE
    Private Sub bt_simpan_group_Click(sender As Object, e As EventArgs) Handles bt_simpan_group.Click
        If Trim(in_nama_group.Text) = "" Then
            MessageBox.Show("Nama group belum diisi!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_nama_group.Focus() : Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim _resMsg As DialogResult = Windows.Forms.DialogResult.Yes
        If formstate <> InputState.Insert Then _resMsg = MessageBox.Show("Simpan perubahan data user group?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _resMsg = Windows.Forms.DialogResult.Yes Then
            Dim _confirm As Boolean = True
            If formstate = InputState.Edit Then
                'Dim xx As New fr_tutupconfirm_dialog
                'xx.lbl_title.Text = "Konfirm"
            End If
            If _confirm Then saveData()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    'UI
    Private Sub in_nama_group_KeyUp(sender As Object, e As KeyEventArgs) Handles in_nama_group.KeyUp
        keyshortenter(in_ket_group, e)
    End Sub

    Private Sub in_alamat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_ket_group.KeyPress
        If e.KeyChar = Convert.ToChar(1) Then
            DirectCast(sender, TextBox).SelectAll()
            e.Handled = True
        End If
    End Sub

    Private Sub bt_tv_checkall_group_Click(sender As Object, e As EventArgs) Handles bt_tv_reset.Click, bt_tv_checkall_group.Click
        RemoveHandler tv_menu.AfterCheck, AddressOf tv_menu_AfterCheck
        Dim _checked As Boolean = False
        If sender.Name = "bt_tv_checkall_group" Then _checked = True
        treeviewAllCheckSwitch(tv_menu.Nodes, _checked)
        AddHandler tv_menu.AfterCheck, AddressOf tv_menu_AfterCheck
    End Sub

    Private Sub tv_menu_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tv_menu.AfterCheck
        RemoveHandler tv_menu.AfterCheck, AddressOf tv_menu_AfterCheck

        Dim _checked = e.Node.Checked
        CheckAllChildNodes(e.Node)

        Dim parentNode As TreeNode = e.Node.Parent
        While parentNode Is Nothing = False
            Dim _checkedchild As Boolean = _checked
            If Not _checked Then IsSomeChildChecked(parentNode, _checkedchild)
            parentNode.Checked = _checkedchild
            parentNode = parentNode.Parent
        End While

        AddHandler tv_menu.AfterCheck, AddressOf tv_menu_AfterCheck
    End Sub
End Class