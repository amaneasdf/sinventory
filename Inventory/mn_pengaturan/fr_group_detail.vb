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
        mn_actdeact.Enabled = AllowInput
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

        dbSelect("SELECT menu_kode FROM kode_menu WHERE menu_status=1 AND menu_group = '" & in_kode.Text & "' ORDER BY menu_kode ASC ")

        Do While rd.Read
            fd = False
            MenuKode = rd.Item("menu_kode").ToString
            For Each item As TreeNode In tv_menu.Nodes
                If treeCK(item, MenuKode) = True Then Exit For
                If MenuKode.Length > 4 Then
                    For Each ChildNode As TreeNode In item.Nodes
                        fd = treeCK(ChildNode, MenuKode)
                        If fd = True Then
                            Exit For
                        End If
                        If MenuKode.Length > 6 Then
                            For Each Child2 As TreeNode In ChildNode.Nodes
                                fd = treeCK(Child2, MenuKode)
                                If fd = True Then
                                    Exit For
                                End If
                            Next
                        End If
                        If fd = True Then
                            Exit For
                        End If
                    Next
                End If
                If fd = True Then
                    Exit For
                End If
            Next
            'consoleWriteLine(MenuKode & IIf(fd = True, "sss", "nnnn"))
        Loop
        rd.Close()
    End Sub

    'menutree
    Private Sub populateTree()
        op_con()

        Dim ParentNode As New TreeNode
        Dim ChildNode, ChildNode2 As New TreeNode
        Dim MenuKode, MenuLabel As String

        tv_menu.Nodes.Clear()
        dbSelect("SELECT menu_kode, menu_label FROM data_menu_master WHERE menu_status=1 ORDER BY menu_kode")

        Do While rd.Read
            MenuKode = rd.Item("menu_kode").ToString
            MenuLabel = Mid(MenuKode, 3, 20) & ". " & rd.Item("menu_label").ToString
            Console.WriteLine(rd.Item("menu_kode").ToString)
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

        rd.Close()
        tv_menu.ExpandAll()
    End Sub

    Private Function treeCK(nodes As TreeNode, menukode As String) As Boolean
        Dim fd As Boolean = False
        Dim NodesName As String = "mn" & SplitText(nodes.Text, ".", 0)
        'consoleWriteLine(Child2Name & ";" & MenuKode)
        If NodesName = menukode Then
            nodes.Checked = True
            fd = True
        End If

        Return fd
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

    Private Sub treeviewAllCheckSwitch(state As Boolean)
        For Each item As TreeNode In tv_menu.Nodes
            item.Checked = state
            For Each ChildNode As TreeNode In item.Nodes
                ChildNode.Checked = state
                For Each Child2 As TreeNode In ChildNode.Nodes
                    Child2.Checked = state
                Next
            Next
        Next
    End Sub

    'SAVE
    Private Function processtreeview() As Boolean
        Dim q As String = ""
        Dim data As String()
        Dim queryCheck As Boolean = False
        Dim queryArr As New List(Of String)
        Dim listview As New ListView

        op_con()
        Me.Cursor = Cursors.WaitCursor
        '======================================================================================================================
        q = "UPDATE kode_menu SET menu_status=9 WHERE menu_group='{0}'"
        queryArr.Add(String.Format(q, in_kode.Text))
        'commnd("DELETE FROM kode_menu WHERE menu_group = '" & in_kode.Text & "'")
        '======================================================================================================================

        '======================================================================================================================
        For Each item As TreeNode In tv_menu.Nodes
            Dim MenuKode As String = "mn" & SplitText(item.Text, ".", 0)
            Dim MenuNama As String = SplitText(item.Text, ".", 1)
            'Parent Node
            If item.Checked = True Then
                Dim ls As New ListViewItem()
                ls.SubItems.Add(MenuKode)
                ls.SubItems.Add(MenuNama)
                listview.Items.Add(ls)
                'ChildNode - 1
                For Each ChildNode As TreeNode In item.Nodes
                    Dim ChildKode As String = "mn" & SplitText(ChildNode.Text, ".", 0)
                    Dim ChildNama As String = SplitText(ChildNode.Text, ".", 1)
                    If ChildNode.Checked = True Then
                        Dim lsChild As New ListViewItem()
                        lsChild.SubItems.Add(ChildKode)
                        lsChild.SubItems.Add("     " & ChildNama)
                        listview.Items.Add(lsChild)
                    End If
                    'ChildNode - 2
                    For Each Child2 As TreeNode In ChildNode.Nodes
                        Dim Child2Kode As String = "mn" & SplitText(Child2.Text, ".", 0)
                        Dim Child2Nama As String = SplitText(Child2.Text, ".", 1)
                        If Child2.Checked = True Then
                            Dim lsChild2 As New ListViewItem()
                            lsChild2.SubItems.Add(Child2Kode)
                            lsChild2.SubItems.Add("     " & Child2Nama)
                            listview.Items.Add(lsChild2)
                        End If
                    Next
                Next
            End If
        Next

        For i = 0 To listview.Items.Count - 1
            Dim ItemKode As String = listview.Items(i).SubItems(1).Text
            Dim ItemLabel As String = Trim(listview.Items(i).SubItems(2).Text)

            consoleWriteLine(ItemKode)

            data = {
                "menu_kode='" & ItemKode & "'",
                "menu_status='1'"
                }
            q = "INSERT INTO kode_menu SET menu_group='{0}',{1},menu_reg_date=NOW(),menu_reg_alias='{2}' " _
                & "ON DUPLICATE KEY UPDATE {1},menu_upd_date=NOW(),menu_upd_alias='{2}'"
            queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", data), loggeduser.user_id))
            'commnd("INSERT INTO kode_menu SET  menu_kode = '" & ItemKode & "', menu_group = '" & in_kode.Text & "', " _
            '        & "menu_label = '" & ItemLabel & "', menu_set = 1, menu_parent = '" & sLeft(ItemKode, 4) & "', " _
            '        & "menu_reg_date = NOW(), menu_reg_ip = '" & loggeduser.user_ip & "', menu_reg_alias = '" & loggeduser.user_id & "'")
        Next
        '======================================================================================================================

        '==========================================================================================================================
        'BEGIN TRANSACTION
        queryCheck = startTrans(queryArr)
        '==========================================================================================================================
        Me.Cursor = Cursors.Default

        Return queryCheck
    End Function

    Private Sub saveData()
        Dim q As String = ""
        Dim data As String()
        Dim queryCheck As Boolean = False
        Dim queryArr As New List(Of String)

        Me.Cursor = Cursors.WaitCursor
        data = {
            "group_nama='" & in_nama_group.Text & "'",
            "group_keterangan='" & mysqlQueryFriendlyStringFeed(in_ket_group.Text) & "'",
            "group_status='" & usrstatus & "'"
            }

        op_con()
        If bt_simpan_group.Text = "Simpan" Then
            readcommd("SELECT IFNULL(MAX(group_kode), '0') as Kode FROM data_pengguna_group")
            If rd.HasRows Then
                in_kode.Text = Val(rd.Item("Kode")) + 1
            End If
            rd.Close()

            q = "INSERT INTO data_pengguna_group SET group_kode='{0}',{1},group_reg_date=NOW(),group_reg_alias='{2}'"
        ElseIf bt_simpan_group.Text = "Update" Then
            q = "UPDATE data_pengguna_group SET {1},group_upd_date=NOW(),group_upd_alias='{2}' WHERE group_kode='{0}'"
        End If
        queryCheck = commnd(String.Format(q, in_kode.Text, String.Join(",", data), loggeduser.user_id))
        If queryCheck <> False Then
            queryCheck = processtreeview()
        End If

        Me.Cursor = Cursors.Default

        If queryCheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Exit Sub
        Else
            MessageBox.Show("Data telah disimpan")
            doRefreshTab({pguser, pggroup})
            Me.Close()
        End If
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
        If MessageBox.Show("Tutup Form?", "Data User Group", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'e.Cancel = True
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


    'LOAD
    Private Sub fr_group_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'populateTree()

        'If bt_simpan_group.Text = "Update" Then
        '    treeviewCheck()
        '    getGroupData(in_kode.Text)
        '    'mn_actdeact.Enabled = True
        'End If
    End Sub

    'SAVE
    Private Sub bt_simpan_group_Click(sender As Object, e As EventArgs) Handles bt_simpan_group.Click
        Dim querycheck As Boolean = False

        If Trim(in_nama_group.Text) = "" Then
            MessageBox.Show("Nama group belum diisi!")
            in_nama_group.Focus()
            Exit Sub
        End If

        If Trim(in_ket_group.Text) = "" Then
            MessageBox.Show("Keterangan belum diisi!")
            in_ket_group.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan data user group?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    'UI
    Private Sub in_nama_group_KeyUp(sender As Object, e As KeyEventArgs) Handles in_nama_group.KeyUp
        keyshortenter(in_ket_group, e)
    End Sub

    Private Sub bt_tv_checkall_group_Click(sender As Object, e As EventArgs) Handles bt_tv_reset.Click
        treeviewAllCheckSwitch(False)
    End Sub

    Private Sub bt_tv_checkall_group_Click_1(sender As Object, e As EventArgs) Handles bt_tv_checkall_group.Click
        treeviewAllCheckSwitch(True)
    End Sub
End Class