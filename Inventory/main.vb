﻿Public Class main
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
            Case "neracaawal"
                createTabPage(pgawalneraca, type, frmawalneraca, "Data Neraca Awal")
            Case "beli"
                createTabPage(pgpembelian, type, frmpembelian, "Daftar Pembelian")
            Case "returbeli"
                createTabPage(pgreturbeli, type, frmreturbeli, "Retur Pembelian")
            Case "jual"
                createTabPage(pgpenjualan, type, frmpenjualan, "Daftar Penjualan")
            Case "returjual"
                createTabPage(pgreturjual, type, frmreturjual, "Retur Penjualan")
            Case "draftrekap"
                If tabcontrol.Contains(pgdraftrekap) Then
                    tabcontrol.SelectedTab = pgdraftrekap
                Else
                    With pgdraftrekap
                        .Text = "Rekap penjualan"
                        tabcontrol.TabPages.Add(pgdraftrekap)
                        setList(type)
                        .Controls.Add(frmrekap)
                        .Show()
                        Console.WriteLine(.Name.ToString)
                        tabcontrol.SelectedTab = pgdraftrekap
                    End With
                End If
            Case "drafttagihan"
                If tabcontrol.Contains(pgdrafttagihan) Then
                    tabcontrol.SelectedTab = pgdrafttagihan
                Else
                    With pgdrafttagihan
                        .Text = "Rekap Tagihan"
                        tabcontrol.TabPages.Add(pgdrafttagihan)
                        setList(type)
                        .Controls.Add(frmtagihan)
                        .Show()
                        Console.WriteLine(.Name.ToString)
                        tabcontrol.SelectedTab = pgdrafttagihan
                    End With
                End If
            Case "stok"
                createTabPage(pgstok, type, frmstok, "Stok Barang")
            Case "mutasigudang"
                'createTabPage(pgmutasigudang, type, frmmutasigudang, )
                If tabcontrol.Contains(pgmutasigudang) Then
                    tabcontrol.SelectedTab = pgmutasigudang
                Else
                    With pgmutasigudang
                        .Text = "Mutasi Gudang"
                        tabcontrol.TabPages.Add(pgmutasigudang)
                        setList(type)
                        .Controls.Add(frmmutasigudang)
                        .Show()
                        Console.WriteLine(.Name.ToString)
                        tabcontrol.SelectedTab = pgmutasigudang
                    End With
                End If
            Case "mutasistok"
                'createTabPage(pgmutasistok, type, frmmutasistok, "Mutasi Barang")
                If tabcontrol.Contains(pgmutasistok) Then
                    tabcontrol.SelectedTab = pgmutasistok
                Else
                    With pgmutasistok
                        .Text = "Mutasi Barang"
                        tabcontrol.TabPages.Add(pgmutasistok)
                        setList(type)
                        .Controls.Add(frmmutasistok)
                        .Show()
                        Console.WriteLine(.Name.ToString)
                        tabcontrol.SelectedTab = pgmutasistok
                    End With
                End If
            Case "stockop"
                'createTabPage(pgstockop, type, frmstockop, "Stok Opname")
                If tabcontrol.Contains(pgstockop) Then
                    tabcontrol.SelectedTab = pgstockop
                Else
                    With pgstockop
                        .Text = "Stock Opname"
                        tabcontrol.TabPages.Add(pgstockop)
                        setList(type)
                        .Controls.Add(frmstockop)
                        .Show()
                        Console.WriteLine(.Name.ToString)
                        tabcontrol.SelectedTab = pgstockop
                    End With
                End If
            Case "lap"
                If tabcontrol.Contains(pglap) Then
                    tabcontrol.SelectedTab = pglap
                Else
                    With pglap
                        .Text = "Stock Opname"
                        tabcontrol.TabPages.Add(pglap)
                        setList(type)
                        .Controls.Add(frmlap)
                        .Show()
                        Console.WriteLine(.Name.ToString)
                        tabcontrol.SelectedTab = pglap
                    End With
                End If
            Case "hutangawal"
                createTabPage(pghutangawal, type, frmhutangawal, "Hutang")
            Case "hutangbayar"
                createTabPage(pghutangbayar, type, frmhutangbayar, "Pembayaran Hutang")
            Case "hutangbgo"
                createTabPage(pghutangbgo, type, frmhutangbgo, "BG Out Cair")
            Case "piutangawal"
                createTabPage(pgpiutangawal, type, frmpiutangawal, "Piutang")
            Case "piutangbayar"
                createTabPage(pgpiutangbayar, type, frmpiutangbayar, "Pembayaran Piutang")
            Case "piutangbgcair"
                createTabPage(pgpiutangbgcair, type, frmpiutangbgcair, "BG Cair")
            Case "piutangbgtolak"
                createTabPage(pgpiutangbgtolak, type, frmpiutangbgTolak, "BG Tolak")
            Case "kas"
                createTabPage(pgkas, type, frmkas, "Kas/Bank")
            Case "jurnalumum"
                createTabPage(pgjurnalumum, type, frmjurnalumum, "Jurnal Umum")
            Case "jurnalmemorial"
                createTabPage(pgjurnalmemorial, type, frmjurnalmemorial, "Jurnal Memorial")
                'Case "jenisbarang"
                '    createTabPage(pgjenisbarang, type, frmjenisbarang, "Ref. Jenis Barang")
            Case "kartustok"
                If tabcontrol.Contains(pgkartustok) Then
                    tabcontrol.SelectedTab = pgkartustok
                Else
                    With pgkartustok
                        .Text = "Urut Trans.Stok"
                        tabcontrol.TabPages.Add(pgkartustok)
                        setList(type)
                        .Controls.Add(frmkartustok)
                        .Show()
                        Console.WriteLine(.Name.ToString)
                        tabcontrol.SelectedTab = pgkartustok
                    End With
                End If
            Case "group"
                createTabPage(pggroup, type, frmgroup, "Daftar Group User Level")
            Case "user"
                createTabPage(pguser, type, frmuser, "Daftar User")
        End Select
    End Sub

    Private Sub createTabPage(tbpg As TabPage, type As String, frm As Object, text As String)
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
                'frm.dgv_list.Focus()
            End With
        End If
    End Sub

    Sub MenuAkses()
        'Dim group As String()
        'Dim _gr As String
        'Dim i As Integer = 0
        'Dim q As String = "SELECT menu_kode, menu_label FROM data_menu_master LEFT JOIN data_menu_group ON menu_kode=m_group_menu AND m_group_status=1 " _
        '                  & "WHERE menu_status=1 AND m_group_kode IN ({0}) GROUP BY menu_kode ORDER BY menu_kode ASC"

        'group = Split(loggeduser.user_lev, ":")

        'For Each s As String In group
        '    consoleWriteLine(s & "," & group(i))
        '    group(i) = "'" & s & "'"
        '    consoleWriteLine(group(i))
        '    i += 1
        'Next

        '_gr = String.Join(",", group)
        'consoleWriteLine(_gr & Environment.NewLine & String.Format(q, _gr))
        ''dbSelect(String.Format(q,_gr))

        Dim q As String = "SELECT data_menu_master.menu_kode, data_menu_master.menu_label " _
                          & "FROM kode_menu INNER JOIN data_menu_master ON data_menu_master.menu_kode= kode_menu.menu_kode AND kode_menu.menu_status=1 " _
                          & "WHERE menu_group='{0}' AND data_menu_master.menu_status=1 ORDER BY kode_menu.menu_kode ASC;"
        dbSelect(String.Format(q, loggeduser.user_lev))
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
            If rd.Item("menu_kode") = "mn0801" Then
                bt_setperiode.Visible = True
            End If
        Loop

        rd.Close()
        Me.Controls.Add(MainMenu)
    End Sub

    Private Sub MenuItemClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mnName As String = DirectCast(sender, ToolStripItem).Name
        Dim mnChld As Boolean = DirectCast(sender, ToolStripMenuItem).HasDropDownItems
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
            Case "mn020202"
                Console.WriteLine("click trans retur jual")
                openTab("returjual")
            Case "mn020203"
                Console.WriteLine("click draft tagihan")
                openTab("drafttagihan")
            Case "mn020204"
                Console.WriteLine("click draft rekap nota/barang")
                openTab("draftrekap")
            Case "mn0301"
                Console.WriteLine("click stok awal")
                openTab("stok")
            Case "mn0302"
                Console.WriteLine("click mutasi gudang")
                openTab("mutasigudang")
            Case "mn0303"
                Console.WriteLine("click mutasi barang")
                openTab("mutasistok")
            Case "mn0304"
                Console.WriteLine("click stock op")
                openTab("stockop")
            Case "mn0401"
                Console.WriteLine("click hutang awal")
                openTab("hutangawal")
            Case "mn0402"
                Console.WriteLine("click hutang bayar")
                openTab("hutangbayar")
            Case "mn0403"
                Console.WriteLine("click hutang bgo")
                openTab("hutangbgo")
            Case "mn0501"
                Console.WriteLine("click piutang awal")
                openTab("piutangawal")
            Case "mn0502"
                Console.WriteLine("click piutang bayar")
                openTab("piutangbayar")
            Case "mn0503"
                Console.WriteLine("click piutang bgcair")
                openTab("piutangbgcair")
            Case "mn0504"
                Console.WriteLine("click piutang bgtolak")
                openTab("piutangbgtolak")
            Case "mn0601"
                Console.WriteLine("click kas")
                openTab("kas")
            Case "mn0602"
                Console.WriteLine("click jurnal umum")
                openTab("jurnalumum")
            Case "mn0603"
                Console.WriteLine("click jurnal memorial")
                openTab("jurnalmemorial")
            Case "mn0801"
                Console.WriteLine("click set periode")
                fr_set_periode.ShowDialog()
            Case "mn070301"
                Using x As New fr_lap_filter_beli
                    With x
                        .do_load("transbeli", "Laporan Pembelian Per Nota", "lapBeliNota")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070302"
                Using x As New fr_lap_filter_beli
                    With x
                        .do_load("transbeli", "Laporan Pembelian Per Supplier", "lapBeliSupplier")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070303"
                Using x As New fr_lap_filter_beli
                    With x
                        .supplier_sw = False
                        .do_load("transbeli", "Laporan Pembelian Per Tanggal", "lapBeliTgl")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070304"
                Using x As New fr_lap_filter_beli
                    With x
                        .barang_sw = True
                        .do_load("transbeli", "Laporan Pembelian Per Supplier Per Barang", "lapBeliSupplierBarang")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070305"
                Using x As New fr_lap_filter_beli
                    With x
                        .barang_sw = True
                        .do_load("transbeli", "Laporan Pembelian Per Tanggal Per Barang", "lapBeliTglBarang")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070306"
                Using x As New fr_lap_filter_beli
                    With x
                        .do_load("transbeli", "Laporan Pembelian Per Supplier Per Nota", "lapBeliSupplierNota")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070307"
                Using x As New fr_lap_filter_beli
                    With x
                        .do_load("transbeli", "Laporan Pembelian Per Tanggal Per Nota", "lapBeliTglNota")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070310"
                Using x As New fr_lap_filter_beli
                    With x
                        .jenis_sw = False
                        .barang_sw = True
                        .do_load("transbeli", "Laporan Pembelian Per Tanggal Per Nota Per Barang", "lapBeliTglNotaBarang")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070401"
                Using x As New fr_lap_filter_jual
                    With x
                        .do_load("transjual", "Laporan Penjualan Per Nota", "lapJualNota")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070402"
                Using x As New fr_lap_filter_jual
                    With x
                        .do_load("transjual", "Laporan Penjualan Per Customer", "lapJualCusto")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070403"
                Using x As New fr_lap_filter_jual
                    With x
                        .do_load("transjual", "Laporan Penjualan Per Supplier", "lapJualSupplier")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070404"
                Using x As New fr_lap_filter_jual
                    With x
                        .do_load("transjual", "Laporan Penjualan Per Tipe Customer", "lapJualTipe")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070407"
                Using x As New fr_lap_filter_jual
                    With x
                        .do_load("transjual", "Laporan Penjualan Per Salesman", "lapJualSales")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070408"
                Using x As New fr_lap_filter_jual
                    With x
                        .do_load("transjual", "Laporan Penjualan Per Tanggal", "lapJualTgl")
                        .ShowDialog()
                    End With
                End Using
                'Case "mn070409"
                '    'Dim x As New fr_lap_beli_nota_view With {
                '    '    .inlap_type = "lapJualBarang",
                '    '    .Text = "Laporan Penjualan Per Barang"
                '    '    }
                '    'x.Show()
                '    'x.do_load()
            Case "mn070411"
                Using x As New fr_lap_filter_jual
                    With x
                        .do_load("transjual", "Laporan Penjualan Per Customer Per Nota", "lapJualCustoNota")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070412"
                Using x As New fr_lap_filter_jual
                    With x
                        .do_load("transjual", "Laporan Penjualan Per Salesman Per Nota", "lapJualSalesNota")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070413"
                Using x As New fr_lap_filter_jual
                    With x
                        .do_load("transjual", "Laporan Penjualan Per Tanggal Per Nota", "lapJualTanggalNota")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070417"
                Using x As New fr_lap_filter_jual
                    With x
                        .do_load("transjual", "Laporan Penjualan Per Barang Per Supplier", "lapJualBarangSupplier")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070419"
                Using x As New fr_lap_filter_jual
                    With x
                        .do_load("transjual", "Laporan Penjualan Per Barang Per Sales", "lapJualBarangSales")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070420"
                Using x As New fr_lap_filter_jual
                    With x
                        .do_load("transjual", "Laporan Distribusi Per Sales", "lapJualSalesCustoBarang")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070506"
                Using x As New fr_lap_filter_stok
                    With x
                        .do_load("Kartu Stok", "lapKartuStok")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070507"
                Using x As New fr_lap_filter_stok
                    With x
                        .do_load("Laporan Persediaan", "lapPersediaan")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070511"
                Using x As New fr_lap_filter_stok
                    With x
                        .do_load("Laporan Stok", "lapStok")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070512"
                Using x As New fr_lap_filter_stok
                    With x
                        .supplier_sw = True
                        .do_load("Laporan Stok Per Supplier", "lapStokSupplier")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070513"
                Using x As New fr_lap_filter_stok
                    With x
                        .do_load("Laporan Mutasi Stok", "lapStokMutasi")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070514"
                Using x As New fr_lap_filter_stok
                    With x
                        .do_load("Laporan Mutasi Persediaan", "lapPersediaanMutasi")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070602"
                Using x As New fr_lap_filter_hutang
                    With x
                        .do_load("Laporan Piutang Titipan Per Supplier", "h_titipsupplier")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070603"
                Using x As New fr_lap_filter_hutang
                    With x
                        .do_load("Laporan Hutang Per Nota", "h_nota")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070604"
                Using x As New fr_lap_filter_hutang
                    With x
                        .do_load("Kartu Hutang", "h_kartuhutang")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070605"
                Using x As New fr_lap_filter_hutang
                    With x
                        .do_load("Laporan Pembayaran Hutang Per Nota", "h_bayarnota")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070705"
                Using x As New fr_lap_filter_piutang
                    With x
                        .do_load("Laporan Piutang Per Salesman Per Nota", "p_salesnota")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070706"
                Using x As New fr_lap_filter_piutang
                    With x
                        .do_load("Laporan Piutang Per Salesman Lengkap", "p_saleslengkap2")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070707"
                Using x As New fr_lap_filter_piutang
                    With x
                        .do_load("Laporan Bayar Piutang Per Salesman dan Tanggal", "p_salesbayartanggal")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070712"
                Using x As New fr_lap_filter_piutang
                    With x
                        .do_load("Laporan Piutang Global Per Sales", "p_salesglobal")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070714"
                Using x As New fr_lap_filter_piutang
                    With x
                        .do_load("Kartu Piutang", "p_kartupiutang")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070715"
                Using x As New fr_lap_filter_piutang
                    With x
                        .do_load("Kartu Piutang Per Salesman", "p_kartupiutangsales")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070717"
                Using x As New fr_lap_filter_piutang
                    With x
                        .do_load("Laporan Detail Pembayaran Piutang", "p_bayarnota")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070801"
                Using x As New fr_lap_filter_keuangan
                    With x
                        .do_load("Laporan Biaya Per Salesman", "k_biayasales")
                        .ShowDialog()
                    End With
                End Using
            Case "mn070802"
                Using x As New fr_lap_filter_keuangan
                    With x
                        .do_load("Laporan Biaya Per Salesman Global", "k_biayasales_global")
                        .ShowDialog()
                    End With
                End Using
            Case "mn0813"
                Console.WriteLine("click kartustok")
                openTab("kartustok")
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
                With frmjenisbarang
                    If .Visible = True Then
                        .Focus()
                    Else
                        .setfor = "jenisbarang"
                        .Text += " Jenis Barang"
                        .Show(Me)
                    End If
                End With

                '    openTab("jenisbarang")
            Case "mn0932"
                Console.WriteLine("click satuan barang")
                With frmsatuanbarang
                    If .Visible = True Then
                        .Focus()
                    Else
                        .setfor = "satuan"
                        .Text += " Satuan"
                        .Show(Me)
                    End If
                End With
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
                If mnChld = False Then
                    MessageBox.Show("Under Construction")
                End If
        End Select
    End Sub

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
        Dim x As cnction = loadCon("Catra")

        Me.Cursor = Cursors.AppStarting
        'setConn("localhost", "db-inventory", "root", "root")

        setConn(x.host, x.db, x.uid, x.pass)
        op_con()

        If getConn.State <> 1 Then
            Application.Exit()
            Exit Sub
        End If

        fr_login.Show()

        selectperiode = getPeriode()
        currentperiode = selectperiode

        Me.Cursor = Cursors.Default
        strip_host.Text = x.host
        strip_periode.Text = "Periode Data : " & selectperiode.tglawal.ToShortDateString & " s.d. " & selectperiode.tglakhir.ToShortDateString

        bt_setperiode.Text = "Set Periode"
        bt_setperiode.Enabled = False

        'Dim infpnl As New fr_infopanel With {.Dock = DockStyle.Fill}
        'pnl_main.Controls.Add(infpnl)

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

    Private Sub main_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        'If Not tabcontrol.SelectedTab Is TabPage1 Then
        '    If e.KeyCode = Keys.Escape Then
        '        Console.Write(tabcontrol.SelectedTab.Name)
        '        keyshortcut("close", tabcontrol.SelectedTab.Name.ToString)
        '    End If
        '    If e.KeyCode = Keys.F2 Then
        '        Console.WriteLine(tabcontrol.SelectedTab.Name)
        '        keyshortcut("edit", tabcontrol.SelectedTab.Name.ToString)
        '    End If
        '    If e.KeyCode = Keys.F1 Then
        '        Console.WriteLine(tabcontrol.SelectedTab.Name)
        '        keyshortcut("tambah", tabcontrol.SelectedTab.Name.ToString)
        '    End If
        '    If e.KeyCode = Keys.F3 Then
        '        Console.WriteLine(tabcontrol.SelectedTab.Name)
        '        keyshortcut("hapus", tabcontrol.SelectedTab.Name.ToString)
        '    End If
        '    If e.KeyCode = Keys.F5 Then
        '        Console.WriteLine(tabcontrol.SelectedTab.Name)
        '        keyshortcut("refresh", tabcontrol.SelectedTab.Name.ToString)
        '    End If
        '    If e.KeyCode = Keys.F AndAlso e.Control = True Then
        '        Console.WriteLine(tabcontrol.SelectedTab.Name)
        '        keyshortcut("cari", tabcontrol.SelectedTab.Name.ToString)
        '    End If
        'End If
    End Sub

    'SET PERIODE BT
    Private Sub bt_setperiode_Click(sender As Object, e As EventArgs) Handles bt_setperiode.Click
        setperiode(cal_front.SelectionStart)
    End Sub

    Private Sub cal_front_DateChanged(sender As Object, e As DateRangeEventArgs) Handles cal_front.DateChanged
        bt_setperiode.Text = "Set Periode to " & cal_front.SelectionStart.ToString("MMMM yyyy")
    End Sub
End Class
