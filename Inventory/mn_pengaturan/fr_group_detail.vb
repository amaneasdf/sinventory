Public Class fr_group_detail

    Private Sub populateTree()
        op_con()

        Dim ParentNode As New TreeNode
        Dim ChildNode, ChildNode2 As New TreeNode
        Dim MenuKode, MenuLabel As String

        tv_menu.Nodes.Clear()
        dbSelect("SELECT menu_kode, menu_label FROM data_menu_master ORDER BY menu_kode")

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

    Private Sub treeviewCheck()
        dbSelect("SELECT menu_kode FROM kode_menu WHERE menu_set = 1 AND menu_group = '" & in_kode.Text & "' ORDER BY menu_kode ASC ")

        Do While rd.Read
            For Each item As TreeNode In tv_menu.Nodes
                Dim NodeName As String = "mn" & SplitText(item.Text, ".", 0)
                Dim MenuKode As String = rd.Item("menu_kode").ToString
                If NodeName = MenuKode Then item.Checked = True
                For Each ChildNode As TreeNode In item.Nodes
                    Dim ChildName As String = "mn" & SplitText(ChildNode.Text, ".", 0)
                    If ChildName = MenuKode Then ChildNode.Checked = True
                    For Each Child2 As TreeNode In ChildNode.Nodes
                        Dim Child2Name As String = "mn" & SplitText(ChildNode.Text, ".", 0)
                        If Child2Name = MenuKode Then Child2.Checked = True
                    Next
                Next
            Next
        Loop
        rd.Close()
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

    Private Sub processtreeview()
        op_con()
        commnd("DELETE FROM kode_menu WHERE menu_group = '" & in_kode.Text & "'")

        Dim listview As New ListView
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
            commnd("INSERT INTO kode_menu SET  menu_kode = '" & ItemKode & "', menu_group = '" & in_kode.Text & _
                    "', menu_label = '" & ItemLabel & "', menu_set = 1, menu_parent = '" & sLeft(ItemKode, 4) & "', menu_reg_date = NOW(), menu_reg_ip = '" & loggeduser.user_ip & "', menu_reg_alias = '" & loggeduser.user_id & "'")
        Next
    End Sub

    Private Sub getGroupData(kode As String)
        op_con()
        readcommd("SELECT * FROM data_pengguna_group WHERE group_kode='" & kode & "'")
        If rd.HasRows Then
            txtRegIP.Text = rd.Item("group_reg_ip")
            txtRegAlias.Text = rd.Item("group_reg_alias")
            txtRegdate.Text = rd.Item("group_reg_date")
            Try
                txtUpdDate.Text = rd.Item("group_upd_date")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdIp.Text = rd.Item("group_upd_ip")
            txtUpdAlias.Text = rd.Item("group_upd_alias")
        End If
        rd.Close()
    End Sub

    Private Sub bt_bataluser_Click(sender As Object, e As EventArgs) Handles bt_batal_group.Click
        Me.Close()
    End Sub

    Private Sub fr_group_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populateTree()
        If bt_simpan_group.Text = "Update" Then
            treeviewCheck()
            getGroupData(in_kode.Text)
        End If
    End Sub

    Private Sub bt_tv_checkall_group_Click(sender As Object, e As EventArgs) Handles bt_tv_reset.Click
        treeviewAllCheckSwitch(False)
    End Sub

    Private Sub bt_tv_checkall_group_Click_1(sender As Object, e As EventArgs) Handles bt_tv_checkall_group.Click
        treeviewAllCheckSwitch(True)
    End Sub

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

        op_con()
        If bt_simpan_group.Text = "Simpan" Then
            readcommd("SELECT IFNULL(MAX(group_kode), '0') as Kode FROM data_pengguna_group")
            If rd.HasRows Then
                in_kode.Text = Val(rd.Item("Kode")) + 1
            End If
            rd.Close()

            querycheck = commnd("INSERT INTO data_pengguna_group VALUES('" & in_kode.Text & "', '" & in_nama_group.Text & "', 1, '', '" & in_ket_group.Text & "', now(), '" & loggeduser.user_ip & "', '" & loggeduser.user_id & "', '','','')")

        ElseIf bt_simpan_group.Text = "Update" Then
            querycheck = commnd("UPDATE data_pengguna_group SET group_nama = '" & in_nama_group.Text & "', group_keterangan = '" & in_ket_group.Text & "', group_upd_date = now(), group_upd_ip = '" & loggeduser.user_ip & "', group_upd_alias = '" & loggeduser.user_id & "' WHERE group_kode = '" & in_kode.Text & "'")

        End If

        Me.Cursor = Cursors.WaitCursor

        If querycheck = False Then
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            processtreeview()

            Me.Cursor = Cursors.Default
            MessageBox.Show("Data telah disimpan")

            populateDGVUserCon("group", "", frmgroup.dgv_list)
            frmgroup.in_cari.Clear()

            Me.Close()
        End If
    End Sub
End Class