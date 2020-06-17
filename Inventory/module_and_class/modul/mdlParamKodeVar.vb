Imports System.IO
Imports System.Environment
Module mdlParamKodeVar
    'DATA LIST VARIABLE
    Private _LimitPerPage As Integer = 2000
    Private _ListStartDate As Date = Today
    Private _ListEndDate As Date = Today
    Private _TransStartPeriode As Date = Today

    'REPORT VARIABLE
    Private _LastPrinter As String = String.Empty

    'DIRECTORY VARIABEL
    Private _DocumentDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & Application.ProductName & "\"
    Private _TemporaryDirectory As String = ""

    'STRUCTURE FOR MARGINS
    Public Structure Margins
        Public leftWidth As Integer
        Public rightWidth As Integer
        Public topHeight As Integer
        Public bottomHeight As Integer
    End Structure

    'STRUCTURE FOR DATA CONNECTION
    Public Structure ConnectionData
        Public host As String
        Public port As Integer
        Public db As String
        Public uid As String
        Public pass As String

        Public ReadOnly Property IsEmpty As Boolean
            Get
                Dim _isEmpty As Boolean = False
                For Each _str As String In {host, db, uid}
                    If String.IsNullOrWhiteSpace(_str) Then
                        _isEmpty = True : Exit For
                    End If
                Next
                Return _isEmpty
            End Get
        End Property
    End Structure

    Public Structure periode
        Dim id As String
        Dim tglawal As Date
        Dim tglakhir As Date
        Dim closed As Boolean

    End Structure

    Public Structure dblogwrite
        Dim log_login As Boolean
        Dim log_valid As Boolean
        Dim log_c_w As Boolean
    End Structure

    'MYSQL CONNECTION SETTING
    Public MainConnection As New MySqlThing
    Public MainConnData As New ConnectionData

    'DATA LIST PROPERTY
    Public ReadOnly Property LimitDataPerPage As Integer
        Get
            Try
                _LimitPerPage = getSetting("App").Keys("LimitPerPage").Value
                Return _LimitPerPage
            Catch ex As Exception
                logError(ex, True)
                Return 1000
            End Try
        End Get
    End Property
    Public ReadOnly Property DataListStartDate As Date
        Get
            Try
                If MainConnData.IsEmpty Then Throw New Exception("Main database connection setting hasnt been set.")
                Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        Dim q As String = "SELECT IFNULL(MIN(tutupbk_periode_tglawal), CURDATE()) FROM data_tutup_buku WHERE tutupbk_status = 1"
                        _ListStartDate = Date.Parse(x.ExecScalar(q))
                    End If
                End Using
                Return _ListStartDate
            Catch ex As Exception
                logError(ex, True)
                Return _ListStartDate
            End Try
        End Get
    End Property
    Public ReadOnly Property DataListEndDate As Date
        Get
            Try
                If MainConnData.IsEmpty Then Throw New Exception("Main database connection setting hasnt been set.")
                Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        Dim q As String = "SELECT IFNULL(MAX(tutupbk_periode_tglakhir), CURDATE()) FROM data_tutup_buku WHERE tutupbk_status = 1"
                        _ListEndDate = Date.Parse(x.ExecScalar(q))
                    End If
                End Using
                Return _ListEndDate
            Catch ex As Exception
                logError(ex, True)
                Return _ListEndDate
            End Try
        End Get
    End Property
    Public ReadOnly Property TransStartDate As Date
        Get
            Try
                If MainConnData.IsEmpty Then Throw New Exception("Main database connection setting hasnt been set.")
                Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        Dim q As String = "SELECT IFNULL(MIN(tutupbk_periode_tglawal), CURDATE()) FROM data_tutup_buku " _
                                          & "WHERE tutupbk_status = 1 AND tutupbk_closed=0"
                        _TransStartPeriode = Date.Parse(x.ExecScalar(q))
                    End If
                End Using
                Return _TransStartPeriode
            Catch ex As Exception
                logError(ex, True)
                Return _TransStartPeriode
            End Try
        End Get
    End Property

    Public Property LastUsedPrinter As String
        Set(value As String)
            Try
                InsertConfigIniKey("App", "LastUsedPrinter", value)
            Catch ex As Exception
                logError(ex, True)
                consoleWriteLine(ex.Message)
            End Try
        End Set
        Get
            Dim x = New Printing.PrintDocument
            Try
                _LastPrinter = getSetting("App").Keys("LastUsedPrinter").Value
                If String.IsNullOrEmpty(_LastPrinter) Then
                    _LastPrinter = x.PrinterSettings.PrinterName
                End If
                Return _LastPrinter
            Catch ex As Exception
                logError(ex, True)
                consoleWriteLine(ex.Message)
                Return x.PrinterSettings.PrinterName
            End Try
        End Get
    End Property

    'USER DATA
    Public loggeduser As New UserData
    Public usernull As New UserData
    'Public userdev As New userdata With {.user_id = "dev", .user_ip = "0.0.0.0"}

    'DIRECTORY
    Public ReadOnly Property AppDir_Document As String
        Get
            Dim _folder As String = Path.Combine(GetFolderPath(SpecialFolder.MyDocuments), Application.ProductName)
            consoleWriteLine(_folder)
            If Not Directory.Exists(_folder) Then Directory.CreateDirectory(_folder)
            _DocumentDirectory = _folder : Return _DocumentDirectory
        End Get
    End Property
    Public ReadOnly Property AppDir_Temporary As String
        Get
            If String.IsNullOrWhiteSpace(_TemporaryDirectory) Then
                _TemporaryDirectory = Path.Combine(Path.GetTempPath, Guid.NewGuid.ToString)
                Do While Directory.Exists(_TemporaryDirectory) Or File.Exists(_TemporaryDirectory)
                    _TemporaryDirectory = Path.Combine(Path.GetTempPath, Guid.NewGuid.ToString)
                Loop
            End If
            If Not Directory.Exists(_TemporaryDirectory) Then Directory.CreateDirectory(_TemporaryDirectory)
            Return _TemporaryDirectory
        End Get
    End Property

    Public selectperiode As New periode
    Public currentperiode As New periode
    Public selectmonth As Integer = Today.Month
    Public selectyear As Integer = Today.Year

    'pajak increment
    Public Const ppn As Double = 0.1
    Public Const ppnbm As Double = 0.2

    'JENISIMPORT
    Public Function jenisImport() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Rows.Add("Data Supplier", "master_supplier")
        dt.Rows.Add("Data Barang", "master_barang")
        dt.Rows.Add("Data Gudang", "master_gudang")
        dt.Rows.Add("Data Salesman", "master_sales")
        dt.Rows.Add("Data Customer", "master_customer")
        dt.Rows.Add("Jenis Customer", "master_custojenis")
        'dt.Rows.Add("Data Pembelian", "trans_beli")

        Return dt
    End Function

    'DATATABLE FOR COMBOBOX
    Public Function jenis(tipe As String) As DataTable
        Dim dt As New DataTable : Dim q As String = ""
        Dim _getTable() As String = {"satuan", "satuan_plus", "jenis_barang", "kat_barang", "jenis_custo", "hargajual_custo", "areacustokab", "areacusto",
                                     "bayar_pajak", "bayar_pajak2", "jenis_ppn", "periode", "jenis_sales"}
        Dim _setTable() As String = {"pajak_barang", "priority_custo", "custo_diskon", "term", "transbeli", "transjual", "trans_pajak", "trans_pajak2",
                                     "bayarhutang", "bayarpiutang", "validasi"}

        tipe = LCase(tipe)

        If _getTable.Contains(tipe) Then
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Select Case tipe
                        'DATA BARANG
                        Case "satuan"
                            q = "SELECT satuan_nama as Text, satuan_kode as Value FROM ref_satuan where satuan_status=1 ORDER BY satuan_kode"
                        Case "satuan_plus"
                            q = "SELECT satuan_kode Value, CONCAT(satuan_nama,' (',satuan_kode,')') Text FROM ref_satuan WHERE satuan_status=1 ORDER BY satuan_nama"
                        Case "jenis_barang"
                            q = "SELECT jenis_nama as Text, jenis_kode as Value FROM data_barang_jenis WHERE jenis_status=1"
                        Case "kat_barang"
                            q = "SELECT kategori_kode Value, kategori_nama Text FROM ref_barang_kategori WHERE kategori_status=1 ORDER BY kategori_kode"

                            'DATA CUSTOMER
                        Case "jenis_custo"
                            q = "SELECT CONCAT(UCASE(LEFT(jenis_nama,1)),SUBSTRING(jenis_nama,2)) Text, jenis_kode Value FROM data_customer_jenis WHERE jenis_status=1"
                        Case "hargajual_custo"
                            q = "SELECT hargajual_nama Text, hargajual_kode Value FROM data_customer_hargajual WHERE hargajual_status=1"
                        Case "areacustokab"
                            q = "SELECT ref_kab_id as 'Value', ref_kab_nama as 'Text' FROM ref_area_kabupaten WHERE ref_kab_status=1"
                        Case "areacusto"
                            q = "SELECT c_area_id as 'Value',c_area_nama as 'Text' FROM data_customer_area WHERE c_area_status=1"

                            'DATA SALES
                        Case "jenis_sales"
                            q = "SELECT CONCAT('Sales ', ref_text) Text, ref_kode Value FROM ref_jenis WHERE ref_status=1 AND ref_type='sales_jenis'"

                            'DATA PAJAK
                        Case "bayar_pajak"
                            q = "SELECT ref_text Text, ref_kode Value FROM ref_jenis WHERE ref_status=1 AND ref_type='ppn_trans2'"
                        Case "bayar_pajak2"
                            q = "SELECT CONCAT('Kateg. ', ref_text) Text, ref_kode Value FROM ref_jenis WHERE ref_status=1 AND ref_type='ppn_trans2'"
                        Case "jenis_ppn"
                            q = "SELECT ref_text Text, ref_kode Value FROM ref_jenis WHERE ref_status=1 AND ref_type='ppn_trans3'"

                            'DATA TRANSAKSI & LAPORAN
                        Case "periode"
                            q = "SELECT tutupbk_id as 'Value', " _
                                & "CONCAT(DATE_FORMAT(tutupbk_periode_tglawal,'%d-%m-%Y'),' s.d. ',DATE_FORMAT(tutupbk_periode_tglakhir,'%d-%m-%Y')) as 'Text' " _
                                & "FROM data_tutup_buku WHERE tutupbk_status=1 AND tutupbk_id<>0"

                        Case Else : GoTo HardCodedRef
                    End Select

                    dt = x.GetDataTable(q)
                Else

                End If
            End Using
        ElseIf _setTable.Contains(tipe) Then
HardCodedRef:
            dt.Columns.Add("Text", GetType(String))
            dt.Columns.Add("Value", GetType(String))

            Select Case tipe
                'DATA BARANG
                Case "pajak_barang"
                    dt.Rows.Add("Pajak (PPn)", "1")
                    dt.Rows.Add("Non-Pajak", "0")

                    'DATA CUSTOMER
                Case "priority_custo"
                    dt.Rows.Add("One Bill", "0")
                    dt.Rows.Add("Priority", "1")
                Case "custo_diskon"
                    dt.Rows.Add("Normal", "1")
                    dt.Rows.Add("Outlet", "2")

                    'DATA TRANSAKSI & LAPORAN
                Case "term"
                    dt.Rows.Add("Cash", "0")
                    dt.Rows.Add("Tempo", "1")
                Case "transbeli"
                    dt.Rows.Add("Pembelian", "'BELI'")
                    dt.Rows.Add("Retur Pembelian", "'RETUR'")
                    dt.Rows.Add("Beli & Retur Beli", "'BELI','RETUR'")
                Case "transjual"
                    dt.Rows.Add("Penjualan", "'JUAL'")
                    dt.Rows.Add("Retur Penjualan", "'RETUR'")
                    dt.Rows.Add("Jual & Retur Jual", "'JUAL','RETUR'")
                Case "trans_pajak"
                    dt.Rows.Add("Kategori A", "0")
                    dt.Rows.Add("Kategori B", "1,2")
                    dt.Rows.Add("Kategori C", "0,1,2")
                Case "trans_pajak2"
                    dt.Rows.Add("Kategori A", "0")
                    dt.Rows.Add("Kategori B", "1")
                    dt.Rows.Add("Kategori C", "0,1")
                Case "bayarhutang"
                    dt.Rows.Add("Semua", "ALL")
                    dt.Rows.Add("Tunai", "TUNAI")
                    dt.Rows.Add("Giro", "BG")
                    dt.Rows.Add("TransferBank", "TRANSFER")
                    dt.Rows.Add("ReturPembelian", "RETUR")
                    dt.Rows.Add("PiutangSupplier", "PIUTSUPL")
                Case "bayarpiutang"
                    dt.Rows.Add("Semua", "ALL")
                    dt.Rows.Add("Tunai", "TUNAI")
                    dt.Rows.Add("Giro", "BG")
                    dt.Rows.Add("TransferBank", "TRANSFER")
                    dt.Rows.Add("ReturPenjualan", "RETUR")
                    dt.Rows.Add("Titipan", "PIUTSUPL")
                    dt.Rows.Add("BG Ditolak", "BGTOLAK")
                Case "validasi"
                    dt.Rows.Add("Pending", "0")
                    dt.Rows.Add("Approve", "1")
                    dt.Rows.Add("Tolak", "2")
            End Select
        End If

        Return dt
    End Function

    'jenishargajual
    Public Function jenisHargaJual() As DataTable
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT hargajual_nama as Text, hargajual_kode as Value FROM data_customer_hargajual")
        Return dt
    End Function

    'jenisperkiraan
    Public Function jenisPerkiraan(tipe As String, Optional kodegol As String = "00") As DataTable
        Dim dt As New DataTable
        Dim _getTable() As String = {"gol", "akun"}
        Dim _setTable() As String = {"jenis"}

        tipe = LCase(tipe)

        If _getTable.Contains(tipe) Then
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim q As String = ""
                    Select Case tipe
                        Case "gol"
                            q = "SELECT perk_gol_kode as 'Value', perk_gol_nama as 'Text' FROM data_perkiraan_gol " _
                                & "WHERE perk_gol_kodejen='{0}' AND perk_gol_status=1 ORDER by perk_gol_nama"
                            q = String.Format(q, kodegol)
                        Case "akun"
                            q = "SELECT perk_kode as 'Value',perk_nama_akun as 'Text' FROM data_perkiraan WHERE perk_status=1 AND perk_parent='{0}'"
                            q = String.Format(q, kodegol)
                    End Select

                    dt = x.GetDataTable(q)
                Else

                End If
            End Using
        ElseIf _setTable.Contains(tipe) Then
            dt.Columns.Add("Text", GetType(String))
            dt.Columns.Add("Value", GetType(String))

            Select Case tipe
                Case "jenis"
                    dt.Rows.Add("Aktiva Lancar", "11")
                    dt.Rows.Add("Aktiva Tetap", "12")
                    dt.Rows.Add("Aktiva Lain-lain", "13")
                    dt.Rows.Add("Pasiva Lancar", "21")
                    dt.Rows.Add("Modal", "22")
                    dt.Rows.Add("Pendapatan", "31")
                    dt.Rows.Add("Pendapatan Lain-Lain", "32")
                    dt.Rows.Add("Biaya Penjualan", "41")
                    dt.Rows.Add("Biaya Operasional", "42")
                    dt.Rows.Add("Biaya Lain-Lain", "43")
                    dt.Rows.Add("Biaya Klaim", "44")
            End Select
        End If

        Return dt
    End Function

    'jenisdeb
    Public Function jenisDeb() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Rows.Add("Debet", "D")
        dt.Rows.Add("Kredit", "K")

        Return dt
    End Function

    'jenisBayar
    Public Function jenisBayar(tipe As String) As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))

        Select Case tipe
            Case "retur"
                dt.Rows.Add("Potong Nota", "1")
                dt.Rows.Add("Tunai", "2")
                dt.Rows.Add("Titip", "3")
            Case "hutang", "piutang"
                dt.Rows.Add("Tunai", "TUNAI")
                dt.Rows.Add("Giro", "BG")
                dt.Rows.Add("TransferBank", "TRANSFER")
                dt.Rows.Add("PiutangSupl", "PIUTSUPL")
                'dt.Rows.Add("PotongHarga", "PTGHARGA")
                'dt.Rows.Add("Pendapatan", "PENDAPTN")
            Case "source"
                'SELECT WHERE AKUN is Kas / Bank
                'dt = getDataTablefromDB("SELECT akun_kode as 'Value', CONCAT(akun_kode, '-', akun_nama) FROM data_akun WHERE ...")
            Case "kas"
                dt.Rows.Add("Tunai", "TUNAI")
                dt.Rows.Add("Transfer", "TRANSFER")
        End Select
        Return dt
    End Function

    'tabpage list
    Public pgbarang = New TabPage() With {.Name = "pgbarang"}
    Public pgsupplier = New TabPage() With {.Name = "pgsupplier"}
    Public pggudang = New TabPage() With {.Name = "pggudang"}
    Public pgsales = New TabPage() With {.Name = "pgsales"}
    Public pgcusto = New TabPage() With {.Name = "pgcusto"}
    Public pgbank = New TabPage() With {.Name = "pgbank"}
    Public pgbgtangan As TabPage = New TabPage() With {.Name = "pgbgtangan"}
    Public pgperkiraan = New TabPage() With {.Name = "pgperkiraan"}
    Public pgawalneraca = New TabPage() With {.Name = "pgawalneraca"}
    Public pgpembelian = New TabPage() With {.Name = "pgpembelian"}
    Public pgreturbeli = New TabPage() With {.Name = "pgreturbeli"}
    Public pgpenjualan = New TabPage() With {.Name = "pgpenjualan"}
    Public pgreturjual = New TabPage() With {.Name = "pgreturjual"}
    Public pgpesanjual = New TabPage() With {.Name = "pgpesanjual"}
    Public pgdraftrekap = New TabPage() With {.Name = "pgdraftrekap"}
    Public pgdrafttagihan = New TabPage() With {.Name = "pgdrafttagihan"}
    Public pgstok = New TabPage() With {.Name = "pgstok"}
    Public pgmutasigudang = New TabPage() With {.Name = "pgmutasigudang"}
    Public pgmutasistok = New TabPage() With {.Name = "pgmutasistok"}
    Public pgstockop = New TabPage() With {.Name = "pgstockop"}
    Public pghutangawal = New TabPage() With {.Name = "pghutangawal"}
    Public pghutangbayar = New TabPage() With {.Name = "pghutangbayar"}
    Public pghutangbgo = New TabPage() With {.Name = "pghutangbgo"}
    Public pgpiutangawal = New TabPage() With {.Name = "pgpiutangawal"}
    Public pgpiutangbayar = New TabPage() With {.Name = "pgpiutangbayar"}
    Public pgpiutangbgcair = New TabPage() With {.Name = "pgpiutangbgcair"}
    Public pgpiutangbgtolak = New TabPage() With {.Name = "pgpiutangbgtolak"}
    Public pgkas = New TabPage() With {.Name = "pgkas"}
    Public pgjurnalumum = New TabPage() With {.Name = "pgjurnalumum"}
    Public pgjurnalsesuai = New TabPage() With {.Name = "pgjurnalsesuai"}
    Public pgkartustok = New TabPage() With {.Name = "pgkartustok"}
    Public pgadjstock = New TabPage() With {.Name = "pgadjstock"}
    Public pgtutupbuku = New TabPage() With {.Name = "pgtutupbuku"}
    Public pglap = New TabPage() With {.Name = "pglap"}
    Public pgexportEFak = New TabPage() With {.Name = "pgexportEFak", .AutoScroll = True}
    Public pgexportEFak_sup = New TabPage() With {.Name = "pgexportEFak_sup", .AutoScroll = True}
    Public pguser = New TabPage() With {.Name = "pguser"}
    Public pggroup = New TabPage() With {.Name = "pggroup"}
    Public pgref = New TabPage() With {.Name = "pgref"}
    Public pgsalesbarang = New TabPage() With {.Name = "pgsalesbarang"}

    'user con list
    Public frmbarang As New fr_list With {.Dock = DockStyle.Fill}
    Public frmsupplier As New fr_list With {.Dock = DockStyle.Fill}
    Public frmsales As New fr_list With {.Dock = DockStyle.Fill}
    Public frmgudang As New fr_list With {.Dock = DockStyle.Fill}
    Public frmcusto As New fr_list With {.Dock = DockStyle.Fill}
    Public frmbank As New fr_list With {.Dock = DockStyle.Fill}
    Public frmbgditangan As New fr_list With {.Dock = DockStyle.Fill}
    Public frmperkiraan As New fr_list With {.Dock = DockStyle.Fill}
    Public frmawalneraca As New fr_list With {.Dock = DockStyle.Fill}
    Public frmpembelian As New fr_list With {.Dock = DockStyle.Fill}
    Public frmreturbeli As New fr_list With {.Dock = DockStyle.Fill}
    Public frmpenjualan As New fr_list With {.Dock = DockStyle.Fill}
    Public frmreturjual As New fr_list With {.Dock = DockStyle.Fill}
    Public frmpesanjual As New fr_list With {.Dock = DockStyle.Fill}
    Public frmrekap As New fr_draft_list With {.Dock = DockStyle.Fill}
    Public frmtagihan As New fr_draft_list With {.Dock = DockStyle.Fill}
    Public frmstok As New fr_list With {.Dock = DockStyle.Fill}
    Public frmmutasigudang As New fr_stock_mutasibrg_list With {.Dock = DockStyle.Fill}
    Public frmmutasistok As New fr_stock_mutasibrg_list With {.Dock = DockStyle.Fill}
    Public frmstockop As New fr_stock_mutasibrg_list With {.Dock = DockStyle.Fill}
    Public frmhutangawal As New fr_list With {.Dock = DockStyle.Fill}
    Public frmhutangbayar As New fr_list With {.Dock = DockStyle.Fill}
    Public frmhutangbgo As New fr_list With {.Dock = DockStyle.Fill}
    Public frmpiutangawal As New fr_list With {.Dock = DockStyle.Fill}
    Public frmpiutangbayar As New fr_list With {.Dock = DockStyle.Fill}
    Public frmpiutangbgcair As New fr_list With {.Dock = DockStyle.Fill}
    Public frmpiutangbgTolak As New fr_list With {.Dock = DockStyle.Fill}
    Public frmkas As New fr_list With {.Dock = DockStyle.Fill}
    Public frmjurnalumum As New fr_list With {.Dock = DockStyle.Fill}
    Public frmjurnalsesuai As New fr_list With {.Dock = DockStyle.Fill}
    Public frmkartustok As New fr_urut_kartustok With {.Dock = DockStyle.Fill}
    Public frmadjstock As New fr_list With {.Dock = DockStyle.Fill}
    Public frmtutupbuku As New fr_list With {.Dock = DockStyle.Fill}
    Public frmexportEfak As New fr_export_efaktur With {.Dock = DockStyle.Fill, .SupplierBased = False}
    Public frmexportEfak_sup As New fr_export_efaktur With {.Dock = DockStyle.Fill, .SupplierBased = True}
    Public frmuser As New fr_list With {.Dock = DockStyle.Fill}
    Public frmgroup As New fr_list With {.Dock = DockStyle.Fill}
    Public frmref As New fr_data_referensi With {.Dock = DockStyle.Fill}
    Public frmsalesbarang As New fr_setsales_list With {.Dock = DockStyle.Fill}

    'DATAGRID COLUMNS LIST
    Public dgvcol_temp_ck = New DataGridViewCheckBoxColumn With {
        .ReadOnly = False,
        .Width = 50,
        .FalseValue = 0,
        .TrueValue = 1,
        .IndeterminateValue = 0
        }
    Public dgvcol_temp_cb = New DataGridViewComboBoxColumn With {
        .ReadOnly = False,
        .Width = 100,
        .DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        }
    Public dgvcol_templ_id = New DataGridViewTextBoxColumn With {
        .ReadOnly = True,
        .MinimumWidth = 25,
        .Width = 50
        }
    Public dgvcol_templ_status = New DataGridViewTextBoxColumn With {
        .ReadOnly = True,
        .MinimumWidth = 25,
        .Width = 75
        }
    Public dgvcol_templ_alamat = New DataGridViewTextBoxColumn With {
        .ReadOnly = True,
        .MinimumWidth = 25,
        .Width = 200,
        .DefaultCellStyle = dgvstyle_multiline
        }
    Public dgvcol_templ_numeric = New DataGridViewTextBoxColumn With {
        .ReadOnly = True,
        .MinimumWidth = 25,
        .DefaultCellStyle = dgvstyle_commathousand
        }

    'DATAGRID CELLSTYLE LIST
    Public dgvstyle_commathousand As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
        .Format = "N0",
        .FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
        .NullValue = "-",
        .Alignment = DataGridViewContentAlignment.MiddleRight
    }
    Public dgvstyle_currency As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
        .Format = "N2",
        .FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
        .NullValue = "-",
        .Alignment = DataGridViewContentAlignment.MiddleRight
    }

    Public dgvstyle_multiline As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
        .WrapMode = DataGridViewTriState.True
    }

    Public dgvstyle_date As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
        .Format = "dd/MM/yyyy",
        .FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
        .NullValue = "-"
    }
    Public dgvstyle_time As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
        .Format = "HH:mm:ss",
        .FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
        .NullValue = "-"
    }
    Public dgvstyle_datetime As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
       .Format = "dd/MM/yyyy hh:mm:ss",
       .FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
       .NullValue = "-"
   }


    '-----------dev purpose
    Public log_switch As New dblogwrite With {
        .log_login = True,
        .log_c_w = True
    }
End Module
