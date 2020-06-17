Public Class main
    Public MainMenu As New MenuStrip
    Public listkodemenu As New List(Of String)
    Public isForcedClose As Boolean = False

    'SCREENLOCK
    Private _LS As Object
    Private _InactivityTimer As New Timer
    Private _InactiveMinutes As Integer = 0
    Public _ScreenLocked As Boolean = False

    'FIRST LOAD
    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _login As New fr_login
        lbl_app.Text = Application.ProductName
        Me.Text = Application.ProductName & " : v." & Application.ProductVersion
        Me.Visible = False

        Me.Cursor = Cursors.AppStarting
        If SetConnection() = True Then _login.do_load()
        Me.Cursor = Cursors.Default
    End Sub

    'SETUP CONECTION
    Private Function SetConnection() As Boolean
        Dim _retval As Boolean = False
        Dim _ConnCfgName As String = ""
#If DEBUG Then
        _ConnCfgName = "CatraDev"
#Else
        _ConnCfgName = "network"
#End If
        MainConnData = LoadDataConnection(_ConnCfgName, "")
        consoleWriteLine("Connecting to " & _ConnCfgName)

        If MainConnData.IsEmpty Then
            MessageBox.Show("Terjadi kesalahan saat melakukan konfigurasi koneksi. Konfigurasi koneksi database kosong." & _
                            Environment.NewLine & "Aplikasi akan ditutup", "Error Config",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            isForcedClose = True : _retval = False
            Application.Exit()
        Else
            MainConnection = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
            setConn(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
            MainConnection.Open()
            If MainConnection.ConnectionState <> ConnectionState.Open Then
                MessageBox.Show("Terjadi kesalahan saat melakukan konfigurasi koneksi, aplikasi tidak dapat terhubung ke server." & _
                                Environment.NewLine & "Aplikasi akan ditutup", "Error Config", MessageBoxButtons.OK, MessageBoxIcon.Error)
                isForcedClose = True : _retval = False
                Application.Exit()
            Else
                strip_host.Text = "Server/Host : " & MainConnection.Host
                _retval = True
            End If
        End If

        Return _retval
    End Function

    'CONTROL LOAD / AFTER LOGIN
    Public Sub Do_LoadControl()
        'INFO STRIP
        strip_user.Text = "User : " & loggeduser.User_Alias
        'strip_nama.Text = LoggedUser.GetNama()


        loadInfoPanel()

        'TIMER FOR INACTIVITY
        'Application.AddMessageFilter(Me)
        'AddHandler _InactivityTimer.Tick, AddressOf InactivityTimer_Tick
        '_InactivityTimer.Interval = ScreenLockTimer 'Per Minute(s)
        '_InactivityTimer.Start()

        MenuAkses()
    End Sub

    'CLOSING APPLICATION
    Private Sub main_closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If isForcedClose = False Then
            Dim msg = MessageBox.Show("Tutup Aplikasi?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If msg = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            Else
                Try
                    If Not loggeduser.IsEmpty Then logOut(False)
                Catch ex As Exception
                    LogError(ex, False)
                End Try
            End If
        End If
    End Sub

    'LOGOUT
    Public Sub LogOut(Optional showLoginForm As Boolean = True)
        'UPDATE LOGIN DATA
        Using x = MainConnection
            x.Open() : If x.Connection.State = ConnectionState.Open Then
                Dim q = "UPDATE system_login_log SET log_status=1, log_end=NOW() WHERE log_session='{0}'"
                x.ExecCommand(String.Format(q, loggeduser.User_Session))

                q = "UPDATE data_pengguna_alias SET user_login_status = 0 where user_alias='{0}'"
                x.ExecCommand(String.Format(q, loggeduser.User_Alias))
            End If
        End Using
        loggeduser = New UserData

        If showLoginForm = True Then
            Dim _login As New fr_login
            Me.Opacity = 0 : Me.Visible = False

            'CLEAR/RESET ALL CONTROL
            MainMenu.Items.Clear()
            tabcontrol.TabPages.Clear() : tabcontrol.TabPages.Add(TabPage1)
            If Me.Controls.Contains(MainMenu) Then Me.Controls.Remove(MainMenu)
            pnl_main.Controls.Clear()

            _login.do_load()
        End If
    End Sub

    Public Sub openTab(type As String)
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
            Case "pesanan"
                createTabPage(pgpesanjual, type, frmpesanjual, "Order Penjualan")
            Case "jual"
                createTabPage(pgpenjualan, type, frmpenjualan, "Daftar Penjualan")
            Case "returjual"
                createTabPage(pgreturjual, type, frmreturjual, "Retur Penjualan")
            Case "draftrekap"
                createTabPage(pgdraftrekap, type, frmrekap, "Draft Rekap Penjualan")
            Case "drafttagihan"
                createTabPage(pgdrafttagihan, type, frmtagihan, "Draft Tagihan")
            Case "stok"
                createTabPage(pgstok, type, frmstok, "Stok Barang")
            Case "mutasigudang"
                createTabPage(pgmutasigudang, type, frmmutasigudang, "Mutasi Gudang")
            Case "mutasistok"
                createTabPage(pgmutasistok, type, frmmutasistok, "Mutasi Barang")
            Case "stockop"
                createTabPage(pgstockop, type, frmstockop, "Stok Opname")
            Case "hutangawal"
                createTabPage(pghutangawal, type, frmhutangawal, "Hutang")
            Case "hutangbayar"
                createTabPage(pghutangbayar, type, frmhutangbayar, "Pembayaran Hutang")
            Case "hutangbgo"
                createTabPage(pghutangbgo, type, frmhutangbgo, "Hutang Giro")
            Case "piutangawal"
                createTabPage(pgpiutangawal, type, frmpiutangawal, "Piutang")
            Case "piutangbayar"
                createTabPage(pgpiutangbayar, type, frmpiutangbayar, "Pembayaran Piutang")
            Case "piutangbgcair"
                createTabPage(pgpiutangbgcair, type, frmpiutangbgcair, "Piutang Giro")
            Case "piutangbgtolak"
                createTabPage(pgpiutangbgtolak, type, frmpiutangbgTolak, "BG Tolak")
            Case "kas"
                createTabPage(pgkas, type, frmkas, "Entry Kas/Bank")
            Case "jurnalumum"
                createTabPage(pgjurnalumum, type, frmjurnalumum, "Jurnal Umum")
            Case "jurnalsesuai"
                createTabPage(pgjurnalsesuai, type, frmjurnalsesuai, "Jurnal Penyesuaian")
            Case "ref"
                createTabPage(pgref, type, frmref, "Referensi")
            Case "setbarangsales"
                createTabPage(pgsalesbarang, type, frmsalesbarang, "Set Gudang/Barang Sales")
            Case "kartustok"
                If tabcontrol.Contains(pgkartustok) Then
                    tabcontrol.SelectedTab = pgkartustok
                Else
                    With pgkartustok
                        .Text = "Urut Trans.Stok"
                        tabcontrol.TabPages.Add(pgkartustok)
                        setList(type)
                        .Controls.Add(frmkartustok)
                        tabcontrol.SelectedTab = pgkartustok
                    End With
                End If
            Case "exportEfak"
                createTabPage(pgexportEFak, type, frmexportEfak, "Export E-Faktur")
            Case "exportEfakSupplier"
                createTabPage(pgexportEFak_sup, type, frmexportEfak_sup, "Export E-Faktur Supplier")
            Case "tutupbuku"
                createTabPage(pgtutupbuku, type, frmtutupbuku, "Closing Periode")
            Case "group"
                createTabPage(pggroup, type, frmgroup, "Daftar Group User Level")
            Case "user"
                createTabPage(pguser, type, frmuser, "Daftar User")
        End Select
    End Sub

    Private Sub createTabPage(tbpg As TabPage, type As String, frm As Object, text As String)
        If tabcontrol.Contains(tbpg) Then
            tabcontrol.SelectedTab = tbpg
            DoRefreshTab_v2({tbpg})
        Else
            With tbpg
                .Text = text
                tabcontrol.TabPages.Add(tbpg)
                setList(type)
                .Controls.Add(frm)
                tabcontrol.SelectedTab = tbpg
            End With
        End If
    End Sub

    Private Sub MenuAkses()
        Dim ParentMenu As New ToolStripMenuItem
        Dim MenuLabel, MenuKode As String
        Dim q As String = "SELECT data_menu_master.menu_kode, data_menu_master.menu_label " _
                          & "FROM kode_menu INNER JOIN data_menu_master ON data_menu_master.menu_kode= kode_menu.menu_kode AND kode_menu.menu_status=1 " _
                          & "WHERE menu_group='{0}' AND data_menu_master.menu_status<>9 ORDER BY data_menu_master.menu_kode ASC;"

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Using rdx = x.ReadCommand(String.Format(q, loggeduser.GetGroup))
                    Dim PrevMenuLvl As Integer = 0
                    Dim PrevMenu, PrevParentMenu As New ToolStripMenuItem

                    Do While rdx.Read
                        MenuKode = rdx.Item("menu_kode")
                        MenuLabel = rdx.Item("menu_label")
                        'KodeMenu.Add(MenuName)

                        Dim MenuLevel = MenuKode.Length - (2 + MenuKode.Length / 2)

                        Dim MenuItem As New ToolStripMenuItem(MenuLabel) With {.Name = MenuKode}
                        If MenuLevel = 0 Then
                            MainMenu.Items.Add(MenuItem)
                        Else
                            If PrevMenuLvl < MenuLevel Then
                                PrevParentMenu = ParentMenu
                                ParentMenu = PrevMenu
                            ElseIf PrevMenuLvl > MenuLevel Then
                                ParentMenu = PrevParentMenu
                            End If
                            If MenuLabel <> "-" Then
                                ParentMenu.DropDownItems.Add(MenuItem)
                                AddHandler MenuItem.Click, AddressOf MenuItemClicked
                            Else
                                ParentMenu.DropDownItems.Add(New ToolStripSeparator)
                            End If
                        End If

                        PrevMenu = MenuItem
                        PrevMenuLvl = MenuLevel
                    Loop
                End Using

                Me.Controls.Add(MainMenu)
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Sub MenuItemClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mnName As String = DirectCast(sender, ToolStripItem).Name
        Dim mnLabel As String = DirectCast(sender, ToolStripItem).Text
        Dim mnChld As Boolean = DirectCast(sender, ToolStripMenuItem).HasDropDownItems

        Me.Cursor = Cursors.WaitCursor

        Select Case mnName
            'DATA MASTER
            Case "mn0101" : openTab("barang")
            Case "mn0102" : openTab("supplier")
            Case "mn0103" : openTab("gudang")
            Case "mn0104" : openTab("sales")
            Case "mn0105" : openTab("custo")
                'Case "mn0106" : openTab("bank")
                'Case "mn0107" : openTab("giro")
            Case "mn0108" : openTab("perkiraan")
                'Case "mn0109" : openTab("neracaawal")

                'DATA TRANSAKSI
            Case "mn020101" : openTab("beli")
            Case "mn020102" : openTab("returbeli")
            Case "mn020201" : openTab("jual")
            Case "mn020202" : openTab("returjual")
            Case "mn020203" : openTab("drafttagihan")
            Case "mn020204" : openTab("draftrekap")
            Case "mn020206" : openTab("pesanan")

                'DATA STOK/TRANSAKSI STOK
            Case "mn0301" : openTab("stok")
            Case "mn0302" : openTab("mutasigudang")
            Case "mn0303" : openTab("mutasistok")
            Case "mn0304" : openTab("stockop")

                'DATA TRANSAKSI HUTANG
            Case "mn0401" : openTab("hutangawal")
            Case "mn0402" : openTab("hutangbayar")
            Case "mn0403" : openTab("hutangbgo")

                'DATA TRANSAKSI PIUTANG
            Case "mn0501" : openTab("piutangawal")
            Case "mn0502" : openTab("piutangbayar")
            Case "mn0503" : openTab("piutangbgcair")

                'DATA AKUNTANSI/KEUANGAN
            Case "mn0601" : openTab("kas")
            Case "mn0602" : openTab("jurnalumum")
            Case "mn0603" : openTab("jurnalsesuai")

            Case "mn0801" : MessageBox.Show("Maaf fungsi ini masih dalam perbaikan/maintenance", mnLabel, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'fr_set_periode.ShowDialog()
            Case "mn0803" 'MessageBox.Show("Maaf fungsi ini masih dalam perbaikan/maintenance", mnLabel, MessageBoxButtons.OK, MessageBoxIcon.Information)
                openTab("tutupbuku")
            Case "mn070205" : Dim x As New fr_QR_custo : x.do_load() : x.Show() '-> QRCODE CUSTOMER

                'LAPORAN PEMBELIAN -> NEED TO BE FIXED
            Case "mn070301" : Dim x As New fr_lap_filter_beli : x.do_load("Laporan Pembelian Per Nota", "lapBeliNota")
            Case "mn070302" : Dim x As New fr_lap_filter_beli : x.do_load("Laporan Pembelian Per Supplier", "lapBeliSupplier")
            Case "mn070303" : Dim x As New fr_lap_filter_beli : x.do_load("Laporan Pembelian Per Tanggal", "lapBeliTgl")
            Case "mn070304" : Dim x As New fr_lap_filter_beli : x.do_load("Laporan Pembelian Barang Per Supplier", "lapBeliSupplierBarang")
            Case "mn070305" : Dim x As New fr_lap_filter_beli : x.do_load("Laporan Pembelian Barang Per Tanggal", "lapBeliTglBarang")
            Case "mn070306" : Dim x As New fr_lap_filter_beli : x.do_load("Laporan Nota Pembelian Per Supplier", "lapBeliSupplierNota")
            Case "mn070307" : Dim x As New fr_lap_filter_beli : x.do_load("Laporan Nota Pembelian Per Tanggal", "lapBeliTglNota")
            Case "mn070310" : Dim x As New fr_lap_filter_beli : x.do_load("Laporan Pembelian Distributor Per Tanggal", "lapBeliTglNotaBarang")
                'Case "mn070311" : Dim x As New fr_lap_filter_beli : x.do_load("Laporan Pembelian Distributor Per Supplier", "lapBeliSupplierNotaBarang")

                'LAPORAN PENJUALAN
            Case "mn070401" : Dim x As New fr_lap_filter_jual : x.do_load("Laporan Penjualan Per Nota", "lapJualNota")
            Case "mn070402" : Dim x As New fr_lap_filter_jual : x.do_load("Laporan Penjualan Per Customer", "lapJualCusto")
            Case "mn070403" : Dim x As New fr_lap_filter_jual : x.do_load("Laporan Penjualan Per Supplier", "lapJualSupplier")
            Case "mn070404" : Dim x As New fr_lap_filter_jual : x.do_load("Laporan Penjualan Per Tipe Customer", "lapJualTipe")
            Case "mn070407" : Dim x As New fr_lap_filter_jual : x.do_load("Laporan Penjualan Per Salesman", "lapJualSales")
            Case "mn070408" : Dim x As New fr_lap_filter_jual : x.do_load("Laporan Penjualan Per Tanggal", "lapJualTgl")
            Case "mn070411" : Dim x As New fr_lap_filter_jual : x.do_load("Laporan Nota Penjualan Per Customer", "lapJualCustoNota")
            Case "mn070412" : Dim x As New fr_lap_filter_jual : x.do_load("Laporan Nota Penjualan Per Salesman", "lapJualSalesNota")
            Case "mn070413" : Dim x As New fr_lap_filter_jual : x.do_load("Laporan Nota Penjualan Per Tanggal", "lapJualTanggalNota")
            Case "mn070417" : Dim x As New fr_lap_filter_jual : x.do_load("Laporan Penjualan Barang Per Supplier", "lapJualBarangSupplier")
            Case "mn070419" : Dim x As New fr_lap_filter_jual : x.do_load("Laporan Penjualan Barang Per Sales", "lapJualBarangSales")
            Case "mn070420" : Dim x As New fr_lap_filter_jual : x.do_load("Laporan Distribusi Per Sales", "lapJualSalesCustoBarang")
                'Case "mn070422" : Dim x As New fr_lap_filter_jual : x.do_load("Laporan Klaim Penjualan", "lapJualKlaim")

                'LAPORAN PERSEDIAAN/STOK
            Case "mn070501" : Dim x As New fr_lap_filter_stok : x.do_load("Laporan Stok Barang", "lapStok")
            Case "mn070502" : Dim x As New fr_lap_filter_stok : x.do_load("Laporan Stok Per Supplier", "lapStokSupplier")
            Case "mn070503" : Dim x As New fr_lap_filter_stok : x.do_load("Laporan Persediaan Barang", "lapPersediaan")
            Case "mn070504" : Dim x As New fr_lap_filter_stok : x.do_load("Laporan Mutasi Stok", "lapStokMutasi")
            Case "mn070505" : Dim x As New fr_lap_filter_stok : x.do_load("Laporan Mutasi Persediaan", "lapPersediaanMutasi")
            Case "mn070511" : Dim x As New fr_lap_filter_stok : x.do_load("Kartu Stok Barang", "lapKartuStok")
            Case "mn070512" : Dim x As New fr_lap_filter_stok : x.do_load("Kartu Persediaan Barang", "lapKartuPersediaan")
                'Case "mn070516" : Dim x As New fr_lap_filter_stok : x.do_load("Laporan Mutasi Barang", "lapMtsBarang")
                'Case "mn070517" : Dim x As New fr_lap_filter_stok : x.do_load("Laporan Mutasi Antar Gudang", "lapMtsGudang")
                'Case "mn070518" : Dim x As New fr_lap_filter_stok : x.do_load("Laporan Stok Opname", "lapOpname")

                'LAPORAN HUTANG  
            Case "mn070601" : Dim x As New fr_lap_filter_hutang : x.do_load("Laporan Nota Hutang", "h_nota")
            Case "mn070602" : Dim x As New fr_lap_filter_hutang : x.do_load("Laporan Hutang Pembelian", "h_notabeli")
            Case "mn070603" : Dim x As New fr_lap_filter_hutang : x.do_load("Laporan Detail Pembayaran Hutang", "h_bayarnota")
            Case "mn070606" : Dim x As New fr_lap_filter_hutang : x.do_load("Kartu Hutang", "h_kartuhutang")
            Case "mn070611" : Dim x As New fr_lap_filter_hutang : x.do_load("Piutang Titipan Supplier", "h_titipsupplier")
            Case "mn070612" : Dim x As New fr_lap_filter_hutang : x.do_load("Detail Piutang Titipan Supplier", "h_titipsupplier_det")
                ' Case "mn070621" : Dim x As New fr_lap_filter_hutang : x.do_load("Laporan Bilyet Giro Keluar", "h_giroout")

                'LAPORAN PIUTANG
            Case "mn070705" : Dim x As New fr_lap_filter_piutang : x.do_load("Laporan Nota Piutang Per Salesman", "p_salesnota")
            Case "mn070706" : Dim x As New fr_lap_filter_piutang : x.do_load("Laporan Piutang Penjualan Per Salesman", "p_saleslengkap2")
            Case "mn070707" : Dim x As New fr_lap_filter_piutang : x.do_load("Laporan Pembayaran Piutang Per Salesman", "p_salesbayartanggal")
            Case "mn070708" : Dim x As New fr_lap_filter_piutang : x.do_load("Laporan Detail Pembayaran Piutang", "p_bayarnota")
            Case "mn070709" : Dim x As New fr_lap_filter_piutang : x.do_load("Laporan Piutang Global Per Sales", "p_salesglobal")
            Case "mn070714" : Dim x As New fr_lap_filter_piutang : x.do_load("Kartu Piutang", "p_kartupiutang")
            Case "mn070715" : Dim x As New fr_lap_filter_piutang : x.do_load("Kartu Piutang Per Salesman", "p_kartupiutangsales")
            Case "mn070721" : Dim x As New fr_lap_filter_piutang : x.do_load("Hutang Titipan Customer", "p_titipancusto")
            Case "mn070722" : Dim x As New fr_lap_filter_piutang : x.do_load("Detail Hutang Titipan Customer", "p_titipancusto_det")
                ' Case "mn070731" : Dim x As New fr_lap_filter_piutang : x.do_load("Laporan Bilyet Giro Diterima", "p_giroin")

                'LAPORAN KEUANGAN
            Case "mn070801" : Dim x As New fr_lap_filter_keuangan : x.do_load("Laporan Biaya Per Salesman", "k_biayasales")
            Case "mn070802" : Dim x As New fr_lap_filter_keuangan : x.do_load("Laporan Biaya Per Salesman Global", "k_biayasales_global")
            Case "mn070804" : Dim x As New fr_lap_filter_keuangan : x.do_load("Jurnal Umum", "k_jurnalumum")
            Case "mn070805" : Dim x As New fr_lap_filter_keuangan : x.do_load("Buku Besar", "k_bukubesar")
            Case "mn070806" : Dim x As New fr_lap_filter_keuangan : x.do_load("Jurnal Penyesuaian", "k_jurnalsesuai")
            Case "mn070807" : Dim x As New fr_lap_filter_keuangan : x.do_load("Neraca Lajur", "k_neracalajur")
            Case "mn070808" : Dim x As New fr_lap_filter_keuangan : x.do_load("Laba Rugi", "k_labarugi")
            Case "mn070809" : Dim x As New fr_lap_filter_keuangan : x.do_load("Jurnal Penutup", "k_jurnaltutup")
            Case "mn070810" : Dim x As New fr_lap_filter_keuangan : x.do_load("Neraca", "k_neraca")
            Case "mn070812" : Dim x As New fr_lap_filter_keuangan : x.do_load("Daftar Perkiraan", "k_daftarperk")

                'OLAH DATA
                'Case "mn0813" : openTab("kartustok")
            Case "mn0822" : Dim x As New fr_importjual : x.Show()
            Case "mn0831" : openTab("exportEfak")
            Case "mn0832" : openTab("exportEfakSupplier")

                'SETTING
            Case "mn0901" : Using x As New fr_user_password : x.ShowDialog() : End Using
            Case "mn0911" : Dim x As New fr_setup_menu : x.Show()
            Case "mn0921" : openTab("user")
            Case "mn0922" : openTab("group")
            Case "mn0923" : resetPassUser(loggeduser.User_Alias)

                'SETTING REFERENSI
            Case "mn0932" : openTab("ref")
            Case "mn0934" : openTab("setbarangsales")
                'Case "mn0935" : openTab("setpromobrg")

                'LOGOUT/EXIT
            Case "mn0941" : logOut(True)
            Case "mn0942" : Application.Exit()
            Case Else
                If mnChld = False Then
                    MessageBox.Show("Maaf fungsi ini masih dalam perbaikan/maintenance atau belum tersedia.", mnLabel, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
        End Select

        Me.Cursor = Cursors.Default
    End Sub

    'MAIN TAB INFO PANEL -> NEED TO BE FIXED
    Public Sub loadInfoPanel()
        Dim infpnl As New fr_infopanel With {.Dock = DockStyle.Fill}
        With infpnl
            '.giro_sw = listkodemenu.Contains("mn0503")
            '.pesan_sw = listkodemenu.Contains("mn020206")
            '.piutang_sw = listkodemenu.Contains("mn0501")
            '.piutang_sw_bayar = listkodemenu.Contains("mn0502")
            '.hutang_sw = listkodemenu.Contains("mn0401")
            '.hutang_sw_bayar = listkodemenu.Contains("mn0402")
            '.user_sw = listkodemenu.Contains("mn0921")
            .giro_sw = False
            .pesan_sw = False
            .piutang_sw = False
            .piutang_sw_bayar = False
            .hutang_sw = False
            .hutang_sw_bayar = False
            .user_sw = False
            .bt_refreshPnl.Visible = False
        End With
        pnl_main.Controls.Add(infpnl)
    End Sub


    'VVV DOESNT MATTER VVV
    Private Sub main_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If loggeduser.user_id = "dev" Then
            If e.KeyCode = Keys.E And e.Control = True And e.Shift = True Then
                Dim _inputstring As String = ""
                _inputstring = InputBox("input text", "encrypt")
                InputBox("cyphertext", "result", encryptString(_inputstring))
            ElseIf e.KeyCode = Keys.D And e.Control = True And e.Shift = True Then
                Dim _inputstring As String = ""
                _inputstring = InputBox("input text", "decrypt")
                InputBox("cyphertext", "result", decryptString(_inputstring))
            End If

        End If
    End Sub

    'SET PERIODE BT
    Private Sub bt_periode_main_Click(sender As Object, e As EventArgs) Handles bt_periode_main.Click
        Dim _selectdate As Date = cal_front.SelectionStart
        Dim _selectedperiode As periode = getPeriode(Nothing, _selectdate)

        If _selectedperiode.id <> selectperiode.id Then
            'Dim textsa As String = "Ubah periode data ke periode '{0}' s.d. '{1}'?"

            'If MessageBox.Show(String.Format(textsa, _selectedperiode.tglawal.ToShortDateString, _selectedperiode.tglakhir.ToShortDateString),
            '                   "Set Periode", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            '    'op_con()
            '    'setperiode(_selectdate, True)
            'Else
            '    Exit Sub
            'End If
        End If
    End Sub

End Class
