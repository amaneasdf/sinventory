Module mdlParamKodeVar
    Public Structure userdata
        Dim user_id As String
        Dim user_nama As String
        Dim user_ip As String
        Dim user_mac As String
        Dim user_host As String
        Dim user_lev As String
        Dim user_ver As String
    End Structure

    Public Structure cnction
        Dim host As String
        Dim uid As String
        Dim pass As String
        Dim db As String
    End Structure

    Public Structure dblogwrite
        Dim log_login As Boolean
        Dim log_stock As Boolean
        Dim log_trans As Boolean
        Dim log_act As Boolean
    End Structure

    Public usernull As New userdata
    'Public userdev As New userdata With {.user_id = "dev", .user_ip = "0.0.0.0"}

    'tgl
    Public tglHariIni As Date = System.DateTime.Today
    Public sekarang As Date = System.DateTime.Now

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
        'dt = getDataTablefromDB("SELECT jenis_nama as Text, jenis_kode as Value FROM data_barang_jenis")
        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Rows.Add("Stok", "1")
        dt.Rows.Add("Non Stok", "0")
        Return dt
    End Function

    'jenissatuan
    Public Function jenisSatuan() As DataTable
        Dim dt As New DataTable
        'dt = getDataTablefromDB("SELECT satuan_nama as Text, satuan_kode as Value FROM ref_satuan")
        dt = getDataTablefromDB("SELECT satuan_kode as Text, satuan_kode as Value FROM ref_satuan")
        Return dt
    End Function

    'jenissatuanbesarbarang
    Public Function jenisSatuanBesarBrg() As DataTable
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT DISTINCT barang_satuan_besar as Text FROM data_barang_master")
        Return dt
    End Function

    'jenis sales
    Public Function jenisSales() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Rows.Add("Sales TO", "TO")
        dt.Rows.Add("Sales Kanvas", "Kanvas")

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
    Public Function jenisPerkiraan() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Rows.Add("Judul", "0")
        dt.Rows.Add("AKTIVA", "1")

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
        dt.Rows.Add("Pajak", "1")
        dt.Rows.Add("Non Pajak", "0")

        Return dt
    End Function

    'jenisJurnal
    Public Function jenisJurnal() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Rows.Add("Jurnal", "1")
        dt.Rows.Add("Non Jurnal", "0")

        Return dt
    End Function

    'jenisBayarRetur
    Public Function jenisBayarRetur() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Rows.Add("Potong Nota", "1")
        dt.Rows.Add("Tunai", "0")

        Return dt
    End Function

    'jenisJual -> gak guna, cuma untuk otomatisasi no.faktur
    Public Function jenisJual() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Rows.Add("Otomatis", "1")
        dt.Rows.Add("Manual", "0")

        Return dt
    End Function

    'statususer
    Public Function statusUser() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(Integer))
        'dt.Rows.Add("Setup", 0)
        dt.Rows.Add("Aktif", 1)
        dt.Rows.Add("Blokir", 2)
        dt.Rows.Add("Delete", 9)

        Return dt
    End Function

    'statusgudang
    Public Function statusGudang() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(Integer))
        dt.Rows.Add("Aktif", 1)
        dt.Rows.Add("Non Aktif", 2)
        dt.Rows.Add("Delete", 9)

        Return dt
    End Function

    'statusbarang
    Public Function statusBarang() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(Integer))
        dt.Rows.Add("Aktif", 1)
        dt.Rows.Add("Non Aktif", 2)
        dt.Rows.Add("Delete", 9)

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

    'statussales
    Public Function statusSales() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(Integer))
        dt.Rows.Add("Aktif", 1)
        dt.Rows.Add("Non Aktif", 2)
        dt.Rows.Add("Delete", 9)

        Return dt
    End Function

    'statussupplier
    Public Function statusSupplier() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(Integer))
        dt.Rows.Add("Aktif", 1)
        dt.Rows.Add("Non Aktif", 2)
        dt.Rows.Add("Delete", 9)

        Return dt
    End Function

    'statuscusto
    Public Function statusCusto() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(Integer))
        dt.Rows.Add("Aktif", 1)
        dt.Rows.Add("Non Aktif", 2)
        dt.Rows.Add("Delete", 9)

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
    Public pguser = New TabPage() With {.Name = "pguser"}
    Public pggroup = New TabPage() With {.Name = "pggroup"}
    'Public pgjenisbarang = New TabPage() With {.Name = "pgjenisbarang"}
    'Public pgsatuanbarang = New TabPage() With {.Name = "pgsatuanbarang"}

    'user con list
    Public frmbarang As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmsupplier As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmsales As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmgudang As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmcusto As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmbank As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmbgditangan As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmperkiraan As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmawalneraca As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmpembelian As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmreturbeli As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmpenjualan As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmreturjual As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmstok As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmmutasigudang As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmmutasistok As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmstockop As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmhutangawal As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmhutangbayar As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmhutangbgo As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmpiutangawal As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmpiutangbayar As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmpiutangbgcair As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmpiutangbgTolak As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmkas As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmjurnalumum As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmjurnalmemorial As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmuser As New fr_list_temp With {.Dock = DockStyle.Fill}
    Public frmgroup As New fr_list_temp With {.Dock = DockStyle.Fill}
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

    'dgv percentage style
    Public dgvstyle_percentage As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle() With {
        .Format = "p2",
        .FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
        .NullValue = "-"
    }

    '-----------dev purpose
    Public log_switch As New dblogwrite With {
        .log_login = False,
        .log_stock = False,
        .log_trans = False,
        .log_act = False
    }
End Module
