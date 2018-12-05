Module mdlParamKodeVar
    Public Structure userdata
        'general info
        Dim user_id As String
        Dim user_nama As String
        Dim saleskode As String

        'computer info
        Dim user_ip As String
        Dim user_mac As String
        Dim user_host As String

        'level and access info
        Dim user_lev As String
        Dim allowedit_transact As Boolean
        Dim allowedit_master As Boolean
        Dim allowedit_akun As Boolean
        Dim validasi_trans As Boolean
        Dim validasi_master As Boolean
        Dim validasi_akun As Boolean

        Dim admin_pc As Boolean
        Dim admin_andro As Boolean

        'app ver info
        Dim user_ver As String
    End Structure

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
    End Structure

    Public Structure dblogwrite
        Dim log_login As Boolean
        Dim log_stock As Boolean
        Dim log_trans As Boolean
        Dim log_act As Boolean
        Dim log_c_w As Boolean
    End Structure

    Public usernull As New userdata
    'Public userdev As New userdata With {.user_id = "dev", .user_ip = "0.0.0.0"}

    Public selectperiode As New periode
    Public currentperiode As New periode
    Public tglHariIni As Date = System.DateTime.Today

    'tgl
    Public sekarang As Date = System.DateTime.Now
    Public selectedperiode As Date = DateSerial(tglHariIni.Year, tglHariIni.Month, 1)

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

    'jenisbarang
    Public Function jenisBarang() As DataTable
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT jenis_nama as Text, jenis_kode as Value FROM data_barang_jenis")
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
                dt = getDataTablefromDB("SELECT satuan_kode as Text, satuan_kode as Value FROM ref_satuan")

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
                dt.Rows.Add("Approve", "1")
                dt.Rows.Add("Tolak", "2")

            Case "areacustokab"
                q = "SELECT ref_kab_id as 'Value', ref_kab_nama as 'Text FROM ref_area_kabupaten WHERE ref_kab_status=1"
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

    'jeniscusto
    Public Function jenisCusto() As DataTable
        Dim dt As New DataTable

        'dt.Columns.Add("Text", GetType(String))
        'dt.Columns.Add("Value", GetType(String))
        'dt.Rows.Add("Ritel", "1")
        'dt.Rows.Add("Grosir", "2")
        'dt.Rows.Add("Modern", "3")
        'dt.Rows.Add("Horeka", "4")
        dt = getDataTablefromDB("SELECT CONCAT(UCASE(LEFT(jenis_nama,1)),SUBSTRING(jenis_nama,2)) as Text, jenis_kode as `Value` FROM data_customer_jenis")
        Console.WriteLine(dt.Rows.Count)

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
            Case "gol11"
                dt.Rows.Add("Kas", "1101")
                dt.Rows.Add("Bank", "1102")
                dt.Rows.Add("Simpanan Berharga", "1103")
                dt.Rows.Add("Piutang Dagang", "1104")
                dt.Rows.Add("Piutang Karyawan", "1105")
                dt.Rows.Add("Piutang Lain-Lain", "1106")
                dt.Rows.Add("Piutang Giro", "1107")
                dt.Rows.Add("Stok Barang", "1108")
                'dt = getDataTablefromDB("SELECT perk_gol_kode as 'Value', perk_gol_nama as 'Text' " _
                '                        & "FROM ref_gol_perkiraan WHERE perk_gol_kode LIKE '11%' AND perk_gol_status=1")
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
        dt.Rows.Add("Excluded", "0")
        dt.Rows.Add("Non-PPn", "2")

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
                'dt.Rows.Add("Titipan", "TITIP")
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

    'statuspajakbarang
    Public Function statusBarangPajak() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(Integer))
        dt.Rows.Add("PPn 10% Included", 1)
        dt.Rows.Add("PPn 10% Excluded", 2)
        'dt.Rows.Add("PPnBM", 2)
        dt.Rows.Add("Non Pajak", 0)

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
    Public pgjurnalmemorial = New TabPage() With {.Name = "pgjurnalmemorial"}
    Public pgkartustok = New TabPage() With {.Name = "pgkartustok"}
    Public pgtutupbuku = New TabPage() With {.Name = "pgtutupbuku"}
    Public pglap = New TabPage() With {.Name = "pglap"}
    Public pguser = New TabPage() With {.Name = "pguser"}
    Public pggroup = New TabPage() With {.Name = "pggroup"}
    Public pgref = New TabPage() With {.Name = "pgref"}
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
    Public frmrekap As New fr_draft_rekap With {.Dock = DockStyle.Fill}
    'Public frmtagihan As New fr_draft_tagihan With {.Dock = DockStyle.Fill}
    Public frmtagihan As New fr_draft_tagih With {.Dock = DockStyle.Fill}
    Public frmstok As New fr_list With {.Dock = DockStyle.Fill}
    Public frmmutasigudang As New fr_stok_mutasi_list With {.Dock = DockStyle.Fill}
    Public frmmutasistok As New fr_stok_mutasibarang_list With {.Dock = DockStyle.Fill}
    Public frmstockop As New fr_stockop_list With {.Dock = DockStyle.Fill}
    Public frmhutangawal As New fr_list With {.Dock = DockStyle.Fill}
    Public frmhutangbayar As New fr_list With {.Dock = DockStyle.Fill}
    Public frmhutangbgo As New fr_list With {.Dock = DockStyle.Fill}
    Public frmpiutangawal As New fr_list With {.Dock = DockStyle.Fill}
    Public frmpiutangbayar As New fr_list With {.Dock = DockStyle.Fill}
    Public frmpiutangbgcair As New fr_list With {.Dock = DockStyle.Fill}
    Public frmpiutangbgTolak As New fr_list With {.Dock = DockStyle.Fill}
    Public frmkas As New fr_list With {.Dock = DockStyle.Fill}
    Public frmjurnalumum As New fr_list With {.Dock = DockStyle.Fill}
    Public frmjurnalmemorial As New fr_list With {.Dock = DockStyle.Fill}
    Public frmlap As New fr_lap_stok With {.Dock = DockStyle.Fill}
    Public frmkartustok As New fr_urut_kartustok With {.Dock = DockStyle.Fill}
    Public frmtutupbuku As New fr_tutup_buku With {.Dock = DockStyle.Fill}
    Public frmuser As New fr_list With {.Dock = DockStyle.Fill}
    Public frmgroup As New fr_list With {.Dock = DockStyle.Fill}
    Public frmref As New fr_data_referensi With {.Dock = DockStyle.Fill}
    Public frmjenisbarang As New fr_jenis_barang
    Public frmsatuanbarang As New fr_jenis_barang

    'dgv currency style
    Public dgvstyle_currency As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
        .Format = "N2",
        .FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
        .NullValue = "-",
        .Alignment = DataGridViewContentAlignment.MiddleRight
    }

    'dgv currency style
    Public dgvstyle_commathousand As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
        .Format = "N0",
        .FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
        .NullValue = "-",
        .Alignment = DataGridViewContentAlignment.MiddleRight
    }

    'dgv currency style
    Public dgvstyle_multiline As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
        .WrapMode = DataGridViewTriState.True
    }

    'dgv percentage style
    Public dgvstyle_percentage As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
        .Format = "p2",
        .FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
        .NullValue = "-"
    }

    '-----------dev purpose
    Public log_switch As New dblogwrite With {
        .log_login = True,
        .log_stock = False,
        .log_trans = False,
        .log_act = False,
        .log_c_w = True
    }
End Module
