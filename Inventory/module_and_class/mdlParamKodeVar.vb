﻿Module mdlParamKodeVar
    Private _LimitPerPage As Integer = 2000
    Private _LastPrinter As String = String.Empty

    Public Structure cnction
        Dim host As String
        Dim uid As String
        Dim pass As String
        Dim db As String
    End Structure

    Public Structure periode
        Dim id As String
        Dim tglawal As Date
        Dim tglakhir As Date
        Dim closed As Boolean

        'Public Function SetPeriode() As Task
        '    Return SetPeriode(Now())
        'End Function

        'Public Async Function SetPeriode(SelectedDate As Date) As Task
        '    Dim q As String = ""
        '    Dim periode As KeyValuePair(Of String, Boolean) = Await GetPeriode(SelectedDate)
        '    If IsNothing(periode.Key) And IsNothing(periode.Value) Then
        '        Throw New Exception("Periode data not available")
        '    End If
        '    id = periode.Value : closed = periode.Key
        '    Using x = MainConnection
        '        Await x.OpenAsync() : If x.Connection.State = ConnectionState.Open Then
        '            Using rdx As MySql.Data.MySqlClient.MySqlDataReader = Await x.ReadCommandAsync(String.Format(q, id), CommandBehavior.SingleRow)
        '                Dim red = Await rdx.ReadAsync : If red And rdx.HasRows Then : tglawal = rdx.Item(0) : tglakhir = rdx.Item(1) : End If
        '            End Using
        '        End If
        '    End Using
        'End Function

        'Public Async Function GetPeriode(DateSelected As Date) As Task(Of KeyValuePair(Of String, Boolean))
        '    Dim q As String = ""
        '    Dim retval As New KeyValuePair(Of String, Boolean)
        '    Using x As MySqlThing = MainConnection
        '        If Not IsNothing(x) Then
        '            Try
        '                Await x.OpenAsync
        '                If x.Connection.State = ConnectionState.Open Then
        '                    Using rdx As MySql.Data.MySqlClient.MySqlDataReader = Await x.ReadCommandAsync(String.Format(q, DateSelected.ToString("yyyy-MM-dd")))
        '                        Dim red = Await rdx.ReadAsync
        '                        If red And rdx.HasRows Then

        '                        End If
        '                    End Using
        '                End If
        '            Catch ex As Exception

        '            End Try
        '        End If
        '    End Using
        '    Return retval
        'End Function
    End Structure

    Public Structure dblogwrite
        Dim log_login As Boolean
        Dim log_valid As Boolean
        Dim log_c_w As Boolean
    End Structure

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

    Public usernull As New UserData
    'Public userdev As New userdata With {.user_id = "dev", .user_ip = "0.0.0.0"}

    Public MainConnection As New MySqlThing

    Public selectperiode As New periode
    Public currentperiode As New periode
    Public selectmonth As Integer = Today.Month
    Public selectyear As Integer = Today.Year

    'pajak increment
    Public Const ppn As Double = 0.1
    Public Const ppnbm As Double = 0.2

    'jenisreferensi
    Public Function jenisRef() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Rows.Add("Kategori Barang", "katbarang")
        dt.Rows.Add("Jenis Barang", "jenisbarang")
        dt.Rows.Add("Satuan", "satuan")
        dt.Rows.Add("Jenis Customer", "custo")
        Return dt
    End Function

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

    'jenisbarang
    Public Function jenisBarang() As DataTable
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT jenis_nama as Text, jenis_kode as Value FROM data_barang_jenis WHERE jenis_status=1")
        'dt.Columns.Add("Text", GetType(String))
        'dt.Columns.Add("Value", GetType(String))
        'dt.Rows.Add("Stok", "STOK")
        'dt.Rows.Add("Non Stok", "NONSTOK")
        'dt.Rows.Add("Bonus", "BONUS")
        Return dt
    End Function

    'jenissatuan
    Public Function jenis(tipe As String) As DataTable
        Dim dt As New DataTable
        Dim q As String = ""
        Select Case tipe
            Case "satuan"
                dt = getDataTablefromDB("SELECT satuan_kode as Text, satuan_kode as Value FROM ref_satuan where satuan_status=1 ORDER BY satuan_kode")
            Case "satuan_plus"
                dt = getDataTablefromDB("SELECT satuan_kode Value, CONCAT(satuan_nama,' (',satuan_kode,')') Text FROM ref_satuan " _
                                        & "WHERE satuan_status=1 ORDER BY satuan_nama")
            Case "kat_barang"
                dt = getDataTablefromDB("SELECT kategori_kode Value, kategori_nama Text FROM ref_barang_kategori WHERE kategori_status=1 ORDER BY kategori_kode")
            Case "pajak_barang"
                dt.Columns.Add("Text", GetType(String))
                dt.Columns.Add("Value", GetType(String))
                dt.Rows.Add("Pajak (PPn)", "1")
                dt.Rows.Add("Non-Pajak", "0")

            Case "jenis_custo"
                dt = getDataTablefromDB("SELECT CONCAT(UCASE(LEFT(jenis_nama,1)),SUBSTRING(jenis_nama,2)) as Text, jenis_kode as `Value` FROM data_customer_jenis")
            Case "priority_custo"
                dt.Columns.Add("Text", GetType(String))
                dt.Columns.Add("Value", GetType(String))
                dt.Rows.Add("One Bill", "0")
                dt.Rows.Add("Priority", "1")

            Case "bayar_pajak"
                q = "SELECT ref_text Text, ref_kode Value FROM ref_jenis WHERE ref_status=1 AND ref_type='ppn_trans2'"
                dt = getDataTablefromDB(q)

            Case "bayar_pajak2"
                q = "SELECT CONCAT('Kateg. ', ref_text) Text, ref_kode Value FROM ref_jenis WHERE ref_status=1 AND ref_type='ppn_trans2'"
                dt = getDataTablefromDB(q)

            Case "term"
                dt.Columns.Add("Text", GetType(String))
                dt.Columns.Add("Value", GetType(String))
                dt.Rows.Add("Cash", "0")
                dt.Rows.Add("Tempo", "1")

            Case "transbeli"
                dt.Columns.Add("Text", GetType(String))
                dt.Columns.Add("Value", GetType(String))
                dt.Rows.Add("Pembelian", "'BELI'")
                dt.Rows.Add("Retur Pembelian", "'RETUR'")
                dt.Rows.Add("Beli & Retur Beli", "'BELI','RETUR'")

            Case "transjual"
                dt.Columns.Add("Text", GetType(String))
                dt.Columns.Add("Value", GetType(String))
                dt.Rows.Add("Penjualan", "'JUAL'")
                dt.Rows.Add("Retur Penjualan", "'RETUR'")
                dt.Rows.Add("Jual & Retur Jual", "'JUAL','RETUR'")

            Case "trans_pajak"
                dt.Columns.Add("Text", GetType(String))
                dt.Columns.Add("Value", GetType(String))
                dt.Rows.Add("Kategori A", "0")
                dt.Rows.Add("Kategori B", "1,2")
                dt.Rows.Add("Kategori C", "0,1,2")
            Case "trans_pajak2"
                dt.Columns.Add("Text", GetType(String))
                dt.Columns.Add("Value", GetType(String))
                dt.Rows.Add("Kategori A", "0")
                dt.Rows.Add("Kategori B", "1")
                dt.Rows.Add("Kategori C", "0,1")

            Case "periode"
                dt = getDataTablefromDB("SELECT tutupbk_id as 'Value', " _
                                        & "CONCAT(DATE_FORMAT(tutupbk_periode_tglawal,'%d-%m-%Y'),' s.d. ',DATE_FORMAT(tutupbk_periode_tglakhir,'%d-%m-%Y')) as 'Text' " _
                                        & "FROM data_tutup_buku WHERE tutupbk_status=1 AND tutupbk_id<>0")

            Case "bayarhutang"
                dt.Columns.Add("Text", GetType(String))
                dt.Columns.Add("Value", GetType(String))
                dt.Rows.Add("Semua", "ALL")
                dt.Rows.Add("Tunai", "TUNAI")
                dt.Rows.Add("Giro", "BG")
                dt.Rows.Add("TransferBank", "TRANSFER")
                dt.Rows.Add("ReturPembelian", "RETUR")
                dt.Rows.Add("PiutangSupplier", "PIUTSUPL")

            Case "bayarpiutang"
                dt.Columns.Add("Text", GetType(String))
                dt.Columns.Add("Value", GetType(String))
                dt.Rows.Add("Semua", "ALL")
                dt.Rows.Add("Tunai", "TUNAI")
                dt.Rows.Add("Giro", "BG")
                dt.Rows.Add("TransferBank", "TRANSFER")
                dt.Rows.Add("ReturPenjualan", "RETUR")
                dt.Rows.Add("Titipan", "PIUTSUPL")
                dt.Rows.Add("BG Ditolak", "BGTOLAK")

            Case "validasi"
                dt.Columns.Add("Text", GetType(String))
                dt.Columns.Add("Value", GetType(String))
                dt.Rows.Add("Pending", "0")
                dt.Rows.Add("Approve", "1")
                dt.Rows.Add("Tolak", "2")

            Case "areacustokab"
                q = "SELECT ref_kab_id as 'Value', ref_kab_nama as 'Text' FROM ref_area_kabupaten WHERE ref_kab_status=1"
                dt = getDataTablefromDB(q)

            Case "areacusto"
                q = "SELECT c_area_id as 'Value',c_area_nama as 'Text' FROM data_customer_area WHERE c_area_status=1"
                dt = getDataTablefromDB(q)

            Case Else
                dt = Nothing
        End Select
        Return dt
    End Function

    'jenis sales
    Public Function jenisSales() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Rows.Add("Sales TO", "1")
        dt.Rows.Add("Sales Kanvas", "2")

        Return dt
    End Function

    'jenisdiskon
    Public Function jenisDiskon() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Rows.Add("Normal", "1")
        dt.Rows.Add("Outlet", "2")

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

        Select Case tipe
            Case "jenis"
                dt.Columns.Add("Text", GetType(String))
                dt.Columns.Add("Value", GetType(String))

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
            Case "gol"
                dt = getDataTablefromDB("SELECT perk_gol_kode as 'Value', perk_gol_nama as 'Text' " _
                                        & "FROM data_perkiraan_gol WHERE perk_gol_kodejen='" & kodegol & "' AND perk_gol_status=1 ORDER by perk_gol_nama")
        End Select

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

    'jenisPPn
    Public Function jenisPPN() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Rows.Add("Include", "1")
        dt.Rows.Add("Excluded", "2")
        dt.Rows.Add("Non-PPn", "0")

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
    Public pguser = New TabPage() With {.Name = "pguser"}
    Public pggroup = New TabPage() With {.Name = "pggroup"}
    Public pgref = New TabPage() With {.Name = "pgref"}
    Public pgsalesbarang = New TabPage() With {.Name = "pgsalesbarang"}
    'Public pgjenisbarang = New TabPage() With {.Name = "pgjenisbarang"}
    'Public pgsatuanbarang = New TabPage() With {.Name = "pgsatuanbarang"}

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
    'Public frmrekap As New fr_draft_rekap With {.Dock = DockStyle.Fill}
    'Public frmtagihan As New fr_draft_tagih With {.Dock = DockStyle.Fill}
    Public frmrekap As New fr_draft_list With {.Dock = DockStyle.Fill}
    Public frmtagihan As New fr_draft_list With {.Dock = DockStyle.Fill}
    Public frmstok As New fr_list With {.Dock = DockStyle.Fill}
    'Public frmmutasigudang As New fr_stok_mutasi_list With {.Dock = DockStyle.Fill}
    'Public frmmutasistok As New fr_stok_mutasibarang_list With {.Dock = DockStyle.Fill}
    'Public frmstockop As New fr_stockop_list With {.Dock = DockStyle.Fill}
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
    Public frmexportEfak As New fr_export_efaktur With {.Dock = DockStyle.Fill}
    Public frmuser As New fr_list With {.Dock = DockStyle.Fill}
    Public frmgroup As New fr_list With {.Dock = DockStyle.Fill}
    Public frmref As New fr_data_referensi With {.Dock = DockStyle.Fill}
    Public frmsalesbarang As New uc_sales_barang With {.Dock = DockStyle.Fill}
    Public frmjenisbarang As New fr_jenis_barang
    Public frmsatuanbarang As New fr_jenis_barang

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
