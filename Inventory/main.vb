Public Class main
    Private MainMenu As New MenuStrip
    Private ParentMenu, ChildMenu, ChildMenu2 As ToolStripMenuItem
    Private MenuKode, MenuLabel, MenuText As String

    Private Sub openTab(type As String)
        Select Case type
            Case "barang"
                createTabPage(pgbarang, type, frmbarang, "Data Master Barang")
            Case "supplier"
                createTabPage(pgsupplier, type, frmsupplier, "Data Master Supplier")
            Case "gudang"
                createTabPage(pggudang, type, frmgudang, "Data Master Gudang")
            Case "sales"
                createTabPage(pgsales, type, frmsales, "Data Master Salesman")
            Case "custo"
                createTabPage(pgcusto, type, frmcusto, "Data Master Customer")
            Case "bank"
                createTabPage(pgbank, type, frmbank, "Data Master Bank")
            Case "giro"
                createTabPage(pgbgtangan, type, frmbgditangan, "Data Giro In")
            Case "perkiraan"
                createTabPage(pgperkiraan, type, frmperkiraan, "Data Master Perkiraan")
            Case "beli"
                createTabPage(pgpembelian, type, frmpembelian, "Daftar Pembelian")
            Case "returbeli"
                createTabPage(pgreturbeli, type, frmreturbeli, "Retur Pembelian")
            Case "jual"
                createTabPage(pgpenjualan, type, frmpenjualan, "Daftar Penjualan")
            Case "jenisbarang"
                createTabPage(pgjenisbarang, type, frmjenisbarang, "Ref. Jenis Barang")
            Case "group"
                createTabPage(pggroup, type, frmgroup, "Daftar Group User Level")
            Case "user"
                createTabPage(pguser, type, frmuser, "Daftar User")
        End Select
    End Sub

    Private Sub createTabPage(tbpg As TabPage, type As String, frm As fr_list_temp, text As String)
        If tabcontrol.Contains(tbpg) Then
            tabcontrol.SelectedTab = tbpg
        Else
            With tbpg
                .Text = text
                tabcontrol.TabPages.Add(tbpg)
                setList(type)
                .Controls.Add(frm)
                .Show()
                Console.WriteLine(.Name.ToString)
                tabcontrol.SelectedTab = tbpg
            End With
        End If
    End Sub

    Sub MenuAkses()

        'dbSelect("SELECT * FROM kode_menu WHERE menu_group = '" & loggeduser.user_lev & "' ORDER BY menu_kode ASC ")
        dbSelect("SELECT data_menu_master.menu_kode, data_menu_master.menu_label FROM kode_menu INNER JOIN data_menu_master ON data_menu_master.menu_kode= kode_menu.menu_kode WHERE menu_group='" & loggeduser.user_lev & "' ORDER BY kode_menu.menu_kode ASC;")
        Do While rd.Read
            MenuKode = rd.Item("menu_kode")
            MenuLabel = rd.Item("menu_label").ToString
            MenuText = Mid(MenuKode, 3, 20) & ". " & MenuLabel
            If Len(MenuKode) = 4 Then
                Dim MenuItem As New ToolStripMenuItem(MenuLabel)
                ParentMenu = MenuItem
            End If
            If Len(MenuKode) = 6 Then
                If MenuLabel <> "-" Then
                    Dim MenuItem As New ToolStripMenuItem(MenuText)
                    ChildMenu = MenuItem
                    ChildMenu.Name = MenuKode
                    ParentMenu.DropDownItems.Add(ChildMenu)
                    AddHandler ChildMenu.Click, AddressOf MenuItemClicked
                Else
                    ParentMenu.DropDownItems.Add(New ToolStripSeparator)
                End If
            End If
            If Len(MenuKode) = 8 Then
                If MenuLabel <> "-" Then
                    Dim MenuItem As New ToolStripMenuItem(MenuText)
                    ChildMenu2 = MenuItem
                    ChildMenu2.Name = MenuKode
                    ChildMenu.DropDownItems.Add(ChildMenu2)
                    AddHandler ChildMenu2.Click, AddressOf MenuItemClicked
                Else
                    ChildMenu.DropDownItems.Add(New ToolStripSeparator)
                End If
            End If
            MainMenu.Items.Add(ParentMenu)
            MainMenu.BackColor = Color.Orange
        Loop

        rd.Close()
        Me.Controls.Add(MainMenu)

    End Sub

    Private Sub MenuItemClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mnName As String = DirectCast(sender, ToolStripItem).Name
        Console.WriteLine(mnName)
        Select Case mnName
            Case "mn0101"
                Console.WriteLine("click master barang")
                openTab("barang")
            Case "mn0102"
                Console.WriteLine("click master supplier")
                openTab("supplier")
            Case "mn0103"
                Console.WriteLine("click master gudang")
                openTab("gudang")
            Case "mn0104"
                Console.WriteLine("click master sales")
                openTab("sales")
            Case "mn0105"
                Console.WriteLine("click master custo")
                openTab("custo")
            Case "mn0106"
                Console.WriteLine("click master bank")
                openTab("bank")
            Case "mn0107"
                Console.WriteLine("click master giro")
                openTab("giro")
            Case "mn0108"
                Console.WriteLine("click master perkiraan")
                openTab("perkiraan")
            Case "mn0109"
                Console.WriteLine("click master neraca awal")
                openTab("neracaawal")
            Case "mn020101"
                Console.WriteLine("click trans beli")
                openTab("beli")
            Case "mn020102"
                Console.WriteLine("click trans retur beli")
                openTab("returbeli")
            Case "mn020201"
                Console.WriteLine("click trans jual")
                openTab("jual")
            Case "mn0901"
                Console.WriteLine("click ganti pass")
                fr_user_password.ShowDialog()
            Case "mn0911"
                Console.WriteLine("click set menu")
                fr_setup_menu.ShowDialog()
            Case "mn0921"
                Console.WriteLine("click daftar user")
                openTab("user")
            Case "mn0922"
                Console.WriteLine("click daftar level")
                openTab("group")
            Case "mn0923"
                MessageBox.Show("Under Construction")
                'If MsgBox("Apakah yakin akan mereset user ini?", MsgBoxStyle.YesNo, Application.ProductName) = MsgBoxResult.Yes Then
                '    commnd("UPDATE data_pengguna_alias SET user_password = Password('123456'), user_exp_date=DATE_ADD(CURDATE(),INTERVAL 3 MONTH) WHERE user_alias = '" & loggeduser.user_id & "'")
                '    MsgBox("Password telah reset, password defaultnya: 123456 ", MsgBoxStyle.Information, Application.ProductName)
                '    Me.Dispose()
                'Else
                '    Exit Sub
                'End If
            Case "mn0931"
                Console.WriteLine("click jenis barang")
                openTab("jenisbarang")
            Case "mn0941"
                Console.WriteLine("click logout")
                commnd("UPDATE data_pengguna_alias SET user_login_status = 0 where user_alias='" & loggeduser.user_id & "'")
                loggeduser = usernull
                Console.WriteLine(loggeduser.user_id)
                Me.MainMenu.Items.Clear()
                Me.tabcontrol.TabPages.Clear()
                Me.tabcontrol.TabPages.Add(TabPage1)
                Me.Controls.Remove(MainMenu)
                fr_login.ShowDialog()
                'MenuAkses()
            Case "mn0942"
                Application.Exit()
            Case Else
                MessageBox.Show("Under Construction")
        End Select
    End Sub

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
        setConn("localhost", "db-inventory", "root", "root")
        op_con()
        fr_login.Show()
        'MenuAkses()
        'test var
        'insertData("ii", {"1", "2"}, {"3", "4"})
    End Sub

    Private Sub main_closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If loggeduser.user_id <> Nothing Then
            Dim msg = MessageBox.Show("Apakah yakin akan menutup program ini?", Application.ProductName, MessageBoxButtons.YesNo)
            If msg = Windows.Forms.DialogResult.Yes Then
                commnd("UPDATE data_pengguna_alias SET user_login_status = 0 where user_alias='" & loggeduser.user_id & "'")
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub main_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Not tabcontrol.SelectedTab Is TabPage1 Then
            If e.KeyCode = Keys.Escape Then
                tabcontrol.SelectedTab.Dispose()
            End If
            If e.KeyCode = Keys.F2 Or e.KeyCode = Keys.Enter Then
                Console.WriteLine(tabcontrol.SelectedTab.Name)
                keyshortcut("edit", tabcontrol.SelectedTab.Name.ToString)
            End If
            If e.KeyCode = Keys.F1 Then
                Console.WriteLine(tabcontrol.SelectedTab.Name)
                keyshortcut("tambah", tabcontrol.SelectedTab.Name.ToString)
            End If
            If e.KeyCode = Keys.F3 Then
                Console.WriteLine(tabcontrol.SelectedTab.Name)
                keyshortcut("hapus", tabcontrol.SelectedTab.Name.ToString)
            End If
            If e.KeyCode = Keys.F5 Then
                Console.WriteLine(tabcontrol.SelectedTab.Name)
                keyshortcut("refresh", tabcontrol.SelectedTab.Name.ToString)
            End If
            If e.KeyCode = Keys.F AndAlso e.Control = True Then
                Console.WriteLine(tabcontrol.SelectedTab.Name)
                keyshortcut("cari", tabcontrol.SelectedTab.Name.ToString)
            End If
        End If
    End Sub
End Class
