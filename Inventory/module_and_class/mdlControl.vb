Imports System.Reflection

Module mdlControl
    '----------gudang_list dgv col----------
    Private gudang_kode = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode Gudang",
        .Name = "kode",
        .ReadOnly = True
    }
    Private gudang_status = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "status",
        .HeaderText = "Status",
        .Name = "status",
        .ReadOnly = True
    }

    '----------retur_beli_list dgv col-------------------
    Private retur_beli_gudang = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "gudang",
        .HeaderText = "Gudang",
        .Name = "gudang",
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private retur_beli_jml = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "jumlah",
        .HeaderText = "Jumlah",
        .Name = "jumlah",
        .DefaultCellStyle = dgvstyle_currency,
        .MinimumWidth = 200,
        .ReadOnly = True
    }

    '----------jual_list dgv col------------------- 
    Private jual_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tanggal",
        .HeaderText = "Tanggal",
        .Name = "tanggal",
        .ReadOnly = True
    }

    '----------retur_jual_list dgv col-------------------
    Private retur_jual_bukti = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "bukti",
        .HeaderText = "No. Bukti",
        .Name = "bukti",
        .ReadOnly = True
    }
    Private retur_jual_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tanggal",
        .HeaderText = "Tanggal",
        .Name = "tanggal",
        .ReadOnly = True
    }
    Private retur_jual_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
       .DataPropertyName = "faktur",
       .HeaderText = "No. Faktur",
       .Name = "faktur",
       .ReadOnly = True
    }
    Private retur_jual_sales = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "sales",
        .HeaderText = "Salesman",
        .Name = "sales",
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private retur_jual_custo = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "custo",
        .HeaderText = "Customer",
        .Name = "custo",
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private retur_jual_jml = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "jumlah",
        .HeaderText = "Jumlah",
        .Name = "jumlah",
        .DefaultCellStyle = dgvstyle_currency,
        .MinimumWidth = 200,
        .ReadOnly = True
    }

    '----------stok_list dgv col-------------------
    Private stok_id = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "ID",
        .Name = "kode",
        .Width = 40,
        .Visible = False,
        .ReadOnly = True
    }
    Private stok_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "stock_tanggal",
        .HeaderText = "Tanggal",
        .Name = "tanggal",
        .ReadOnly = True,
        .Width = 75
    }
    Private stok_gudang = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "gudang_nama",
        .HeaderText = "Gudang",
        .Name = "gudang",
        .Width = 200,
        .ReadOnly = True
    }
    Private stok_barang = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "barang_nama",
        .HeaderText = "Barang",
        .Name = "barang",
        .Width = 200,
        .ReadOnly = True
    }
    Private stok_hpp = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "stock_hpp",
        .HeaderText = "HPP",
        .Name = "hpp",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_awal = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "stock_awal",
        .HeaderText = "Stok Awal",
        .Name = "awal",
        .Width = 75,
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_beli = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "stock_beli",
        .HeaderText = "Beli",
        .Name = "beli",
        .Width = 75,
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_jual = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "stock_jual",
        .HeaderText = "Jual",
        .Name = "jual",
        .Width = 75,
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_rbeli = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "stock_rbeli",
        .HeaderText = "Retur Beli",
        .Name = "rjual",
        .Width = 75,
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_rjual = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "stock_rjual",
        .HeaderText = "Retur Jual",
        .Name = "jual",
        .Width = 75,
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_in = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "stock_min",
        .HeaderText = "Masuk",
        .Name = "in",
        .Width = 75,
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_out = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
            .DataPropertyName = "stock_mout",
            .HeaderText = "Keluar",
            .Name = "out",
            .Width = 75,
            .ReadOnly = True,
            .DefaultCellStyle = dgvstyle_commathousand
        }
    Private stok_total = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
            .DataPropertyName = "stock_sisa",
            .HeaderText = "Sisa",
            .Name = "total",
            .Width = 75,
            .ReadOnly = True,
            .DefaultCellStyle = dgvstyle_commathousand
        }
    Private stok_opname = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "stock_stockop",
        .HeaderText = "Opname Fisik",
        .Name = "op",
        .Width = 75,
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }

    '----------hutang_bayar dgv col-------------------
    Private hutang_jenis = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "jenisbayar",
        .HeaderText = "Jenis Bayar",
        .Name = "jenisbayar",
        .Width = 75,
        .ReadOnly = True
    }

    '----------user_list dgv col------------------------------
    Private user_id = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "userid",
        .HeaderText = "UserID",
        .Name = "userid",
        .ReadOnly = True,
        .Width = 100
    }

    Public Sub setList(type As String)
        Select Case type
            Case "barang"
                setListcode(pgbarang, type, frmbarang, "Daftar Barang")
            Case "supplier"
                setListcode(pgsupplier, type, frmsupplier, "Daftar Supplier")
            Case "gudang"
                setListcode(pggudang, type, frmgudang, "Daftar Gudang")
            Case "sales"
                setListcode(pgsales, type, frmsales, "Daftar Salesman")
            Case "custo"
                setListcode(pgcusto, type, frmcusto, "Daftar Customer")
            Case "bank"
                setListcode(pgbank, type, frmbank, "Daftar Bank")
            Case "giro"
                setListcode(pgbgtangan, type, frmbgditangan, "Daftar BG Di Tangan")
            Case "perkiraan"
                setListcode(pgperkiraan, type, frmperkiraan, "Daftar Perkiraan")
            Case "neracaawal"
                setListcode(pgawalneraca, type, frmawalneraca, "Daftar Neraca Awal / Migrasi")
            Case "beli"
                setListcode(pgpembelian, type, frmpembelian, "Daftar Data Pembelian")
            Case "returbeli"
                setListcode(pgreturbeli, type, frmreturbeli, "Daftar Data Retur Pembelian")
            Case "jual"
                setListcode(pgpenjualan, type, frmpenjualan, "Daftar Data Penjualan")
            Case "returjual"
                setListcode(pgreturjual, type, frmreturjual, "Daftar Data Retur Penjualan")
            Case "pesanan"
                setListcode(pgpesanjual, type, frmpesanjual, "Daftar Order Penjualan")
            Case "draftrekap" : frmrekap.SetPage(pgdraftrekap)
            Case "drafttagihan" : frmtagihan.SetPage(pgdrafttagihan)
            Case "stok"
                setListcode(pgstok, type, frmstok, "Daftar Stok Barang")
            Case "mutasigudang" : frmmutasigudang.SetPage(pgmutasigudang)
            Case "mutasistok" : frmmutasistok.SetPage(pgmutasistok)
            Case "stockop" : frmstockop.SetPage(pgstockop)
            Case "hutangawal"
                setListcode(pghutangawal, type, frmhutangawal, "Daftar Hutang")
            Case "hutangbayar"
                setListcode(pghutangbayar, type, frmhutangbayar, "Daftar Pembayaran Hutang")
            Case "hutangbgo"
                setListcode(pghutangbgo, type, frmhutangbgo, "Daftar BG Keluar")
            Case "piutangawal"
                setListcode(pgpiutangawal, type, frmpiutangawal, "Daftar Piutang")
            Case "piutangbayar"
                setListcode(pgpiutangbayar, type, frmpiutangbayar, "Daftar Pembayaran Piutang")
            Case "piutangbgcair"
                setListcode(pgpiutangbgcair, type, frmpiutangbgcair, "Daftar BG Masuk")
            Case "piutangbgtolak"
                setListcode(pgpiutangbgtolak, type, frmpiutangbgTolak, "Daftar BG Tolak")
            Case "kas"
                setListcode(pgkas, type, frmkas, "Kas Keluar/Masuk")
            Case "jurnalumum"
                setListcode(pgjurnalumum, type, frmjurnalumum, "List Jurnal Umum")
            Case "jurnalsesuai"
                setListcode(pgjurnalsesuai, type, frmjurnalsesuai, "List Jurnal Penyesuaian")
            Case "kartustok"
                With frmkartustok
                    setDoubleBuffered(.dgv_barang, True)
                    .setpage(pgkartustok)
                End With
            Case "tutupbuku"
                setListcode(pgtutupbuku, type, frmtutupbuku, "Daftar Closing Periode")
            Case "exportEfak" : frmexportEfak.setpage(pgexportEFak)
            Case "ref"
                frmref.PerformRefresh() : frmref.SetPage(pgref)
            Case "setbarangsales"
                frmsalesbarang.PerformRefresh() : frmsalesbarang.SetPage(pgsalesbarang)
            Case "group"
                setListcode(pggroup, type, frmgroup, "Daftar Group User Level")
            Case "user"
                setListcode(pguser, type, frmuser, "Daftar User")
                'Case "jenisbarang"
                '    setListcodetemp(pgjenisbarang, type, frmjenisbarang, "Referensi/Daftar Jenis Barang")
                'Case "satuanbarang"
                '    setListcodetemp(pgsatuanbarang, type, frmsatuanbarang, "Referensi/Daftar Satuan Barang")
        End Select
    End Sub

    Public Sub setListcode(tbpg As Object, type As String, frm As fr_list, text As String)
        frm.dgv_list.Columns.Clear()
        setDoubleBuffered(frm.dgv_list, True)
        setTabPageControl(type)
        frm.lbl_judul.Text = text
        frm.setpage(tbpg)
    End Sub

    Public Sub setDoubleBuffered(dgv As DataGridView, x As Boolean)
        Dim type As Type = dgv.[GetType]()
        Dim PI As PropertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        PI.SetValue(dgv, True, Nothing)
        consoleWriteLine(dgv.Name & " " & "DoubleBuffered:" & x.ToString)
    End Sub

    Private Sub setTabPageControl(type As String)
        Dim x_filler = New DataGridViewColumn
        x_filler = dgvcol_templ_id.Clone()
        x_filler.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Select Case type
            'LIST DATA BARANG
            Case "barang"
                With frmbarang
                    .export_sw = True : .date_sw = False

                    Dim barang_kode = New DataGridViewColumn : barang_kode = dgvcol_templ_id.Clone()
                    Dim barang_nama = New DataGridViewColumn : barang_nama = dgvcol_templ_status.Clone()
                    Dim barang_jenis = New DataGridViewColumn : barang_jenis = dgvcol_templ_status.Clone()
                    Dim barang_kat = New DataGridViewColumn : barang_kat = dgvcol_templ_status.Clone()
                    Dim barang_pajak = New DataGridViewColumn : barang_pajak = dgvcol_templ_status.Clone()
                    Dim barang_status = New DataGridViewColumn : barang_status = dgvcol_templ_status.Clone()
                    Dim barang_sup_id = New DataGridViewColumn : barang_sup_id = dgvcol_templ_status.Clone()
                    Dim barang_sup = New DataGridViewColumn : barang_sup = dgvcol_templ_status.Clone()
                    Dim barang_sat_k = New DataGridViewColumn : barang_sat_k = dgvcol_templ_status.Clone()
                    Dim barang_sat_t = New DataGridViewColumn : barang_sat_t = dgvcol_templ_status.Clone()
                    Dim barang_sat_b = New DataGridViewColumn : barang_sat_b = dgvcol_templ_status.Clone()
                    Dim barang_hrg_b = New DataGridViewColumn : barang_hrg_b = dgvcol_templ_numeric.Clone()
                    Dim barang_hrg_j = New DataGridViewColumn : barang_hrg_j = dgvcol_templ_numeric.Clone()
                    Dim barang_hrg_mt = New DataGridViewColumn : barang_hrg_mt = dgvcol_templ_numeric.Clone()
                    Dim barang_hrg_hr = New DataGridViewColumn : barang_hrg_hr = dgvcol_templ_numeric.Clone()
                    Dim barang_hrg_rt = New DataGridViewColumn : barang_hrg_rt = dgvcol_templ_numeric.Clone()
                    Dim barang_it = New DataGridViewColumn : barang_it = dgvcol_templ_status.Clone()
                    Dim barang_et = New DataGridViewColumn : barang_et = dgvcol_templ_status.Clone()
                    Dim barang_userid = New DataGridViewColumn : barang_userid = dgvcol_templ_status.Clone()

                    barang_kode.Name = "barang_kode" : barang_kode.DataPropertyName = "kode" : barang_kode.HeaderText = "Kode Barang"
                    barang_nama.Name = "barang_nama" : barang_nama.DataPropertyName = "nama" : barang_nama.HeaderText = "Nama Barang"
                    barang_jenis.Name = "barang_jenis" : barang_jenis.DataPropertyName = "jenis" : barang_jenis.HeaderText = "Jenis"
                    barang_kat.Name = "barang_kat" : barang_kat.DataPropertyName = "kategori" : barang_kat.HeaderText = "Kategori"
                    barang_pajak.Name = "barang_pajak" : barang_pajak.DataPropertyName = "barang_pajak" : barang_pajak.HeaderText = "Kat. 2"
                    barang_status.Name = "barang_status" : barang_status.DataPropertyName = "status" : barang_status.HeaderText = "Status"
                    barang_sup_id.Name = "barang_sup_id" : barang_sup_id.DataPropertyName = "kodesupplier" : barang_sup_id.HeaderText = "Supplier"
                    barang_sup.Name = "barang_sup" : barang_sup.DataPropertyName = "supplier" : barang_sup.HeaderText = "Nama Supplier"
                    barang_sat_k.Name = "barang_sat_k" : barang_sat_k.DataPropertyName = "satuankecil" : barang_sat_k.HeaderText = "Satuan Kecil"
                    barang_sat_t.Name = "barang_sat_t" : barang_sat_t.DataPropertyName = "satuantengah" : barang_sat_t.HeaderText = "Satuan Tengah"
                    barang_sat_b.Name = "barang_sat_b" : barang_sat_b.DataPropertyName = "satuanbesar" : barang_sat_b.HeaderText = "Satuan Besar"
                    barang_hrg_b.Name = "barang_hrg_b" : barang_hrg_b.DataPropertyName = "hargabeli" : barang_hrg_b.HeaderText = "Harga Beli"
                    barang_hrg_j.Name = "barang_hrg_j" : barang_hrg_j.DataPropertyName = "hargajual" : barang_hrg_j.HeaderText = "Harga Jual"
                    barang_hrg_mt.Name = "barang_hrg_mt" : barang_hrg_mt.DataPropertyName = "hargamt" : barang_hrg_mt.HeaderText = "Harga MT"
                    barang_hrg_hr.Name = "barang_hrg_hr" : barang_hrg_hr.DataPropertyName = "hargahoreka" : barang_hrg_hr.HeaderText = "Harga Horeka"
                    barang_hrg_rt.Name = "barang_hrg_rt" : barang_hrg_rt.DataPropertyName = "hargarita" : barang_hrg_rt.HeaderText = "Harga Rita"
                    barang_it.Name = "barang_it" : barang_it.DataPropertyName = "barangit" : barang_it.HeaderText = "IT"
                    barang_et.Name = "barang_et" : barang_et.DataPropertyName = "baranget" : barang_et.HeaderText = "ET"
                    barang_userid.Name = "barang_userid" : barang_userid.DataPropertyName = "userid" : barang_userid.HeaderText = "UserID"

                    barang_kode.Width = 100 : barang_nama.Width = 225 : barang_sup.Width = 200
                    For Each x As DataGridViewColumn In {barang_sat_b, barang_sat_k, barang_sat_t}
                        x.Width = 100
                    Next
                    For Each x As DataGridViewColumn In {barang_hrg_b, barang_hrg_j, barang_hrg_mt, barang_hrg_hr, barang_hrg_rt}
                        x.Width = 100 : x.DefaultCellStyle = dgvstyle_currency
                    Next
                    For Each x As DataGridViewColumn In {barang_et, barang_it}
                        x.Width = 100 : x.DefaultCellStyle = dgvstyle_datetime
                    Next

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {barang_kode, barang_nama, barang_jenis, barang_kat, barang_pajak, barang_status, barang_sup_id,
                                                         barang_sup, barang_sat_k, barang_sat_t, barang_sat_b, barang_hrg_b, barang_hrg_j,
                                                         barang_hrg_mt, barang_hrg_hr, barang_hrg_rt, barang_it, barang_et, barang_userid}
                        For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

                'LIST DATA SUPPLIER
            Case "supplier"
                With frmsupplier
                    .export_sw = True : .date_sw = False

                    Dim supplier_kode = New DataGridViewColumn : supplier_kode = dgvcol_templ_status.Clone()
                    Dim supplier_nama = New DataGridViewColumn : supplier_nama = dgvcol_templ_status.Clone()
                    Dim supplier_alamat = New DataGridViewColumn : supplier_alamat = dgvcol_templ_alamat.Clone()
                    Dim supplier_telp = New DataGridViewColumn : supplier_telp = dgvcol_templ_status.Clone()
                    Dim supplier_fax = New DataGridViewColumn : supplier_fax = dgvcol_templ_status.Clone()
                    Dim supplier_cp = New DataGridViewColumn : supplier_cp = dgvcol_templ_status.Clone()
                    Dim supplier_it = New DataGridViewColumn : supplier_it = dgvcol_templ_status.Clone()
                    Dim supplier_et = New DataGridViewColumn : supplier_et = dgvcol_templ_status.Clone()
                    Dim supplier_userid = New DataGridViewColumn : supplier_userid = dgvcol_templ_status.Clone()
                    Dim supplier_status = New DataGridViewColumn : supplier_status = dgvcol_templ_status.Clone()

                    supplier_kode.Name = "supplier_kode" : supplier_kode.DataPropertyName = "kode" : supplier_kode.HeaderText = "Kode Supplier"
                    supplier_nama.Name = "supplier_nama" : supplier_nama.DataPropertyName = "nama" : supplier_nama.HeaderText = "Nama Supplier"
                    supplier_alamat.Name = "supplier_alamat" : supplier_alamat.DataPropertyName = "alamat" : supplier_alamat.HeaderText = "Alamat"
                    supplier_telp.Name = "supplier_telp" : supplier_telp.DataPropertyName = "telp" : supplier_telp.HeaderText = "Telp."
                    supplier_fax.Name = "supplier_fax" : supplier_fax.DataPropertyName = "fax" : supplier_fax.HeaderText = "Fax."
                    supplier_cp.Name = "supplier_cp" : supplier_cp.DataPropertyName = "cp" : supplier_cp.HeaderText = "CP."
                    supplier_it.Name = "supplier_it" : supplier_it.DataPropertyName = "supplierit" : supplier_it.HeaderText = "IT"
                    supplier_et.Name = "supplier_et" : supplier_et.DataPropertyName = "supplieret" : supplier_et.HeaderText = "ET"
                    supplier_userid.Name = "supplier_userid" : supplier_userid.DataPropertyName = "userid" : supplier_userid.HeaderText = "UserID"
                    supplier_status.Name = "supplier_status" : supplier_status.DataPropertyName = "status" : supplier_status.HeaderText = "Status"

                    supplier_kode.Width = 100 : supplier_nama.Width = 225 : supplier_alamat.Width = 250
                    For Each x As DataGridViewColumn In {supplier_it, supplier_et}
                        x.Width = 100 : x.DefaultCellStyle = dgvstyle_datetime
                    Next
                    For Each x As DataGridViewColumn In {supplier_telp, supplier_fax, supplier_cp, supplier_userid}
                        x.Width = 100
                    Next

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {supplier_kode, supplier_nama, supplier_alamat, supplier_telp, supplier_fax, supplier_cp,
                                                         supplier_status, supplier_it, supplier_et, supplier_userid, x_filler}
                        For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

                'LIST DATA GUDANG
            Case "gudang"
                With frmgudang
                    .export_sw = True : .date_sw = False

                    Dim gudang_kode = New DataGridViewColumn : gudang_kode = dgvcol_templ_status.Clone()
                    Dim gudang_nama = New DataGridViewColumn : gudang_nama = dgvcol_templ_status.Clone()
                    Dim gudang_alamat = New DataGridViewColumn : gudang_alamat = dgvcol_templ_alamat.Clone()
                    Dim gudang_userid = New DataGridViewColumn : gudang_userid = dgvcol_templ_status.Clone()
                    Dim gudang_it = New DataGridViewColumn : gudang_it = dgvcol_templ_status.Clone()
                    Dim gudang_et = New DataGridViewColumn : gudang_et = dgvcol_templ_status.Clone()
                    Dim gudang_status = New DataGridViewColumn : gudang_status = dgvcol_templ_status.Clone()

                    gudang_kode.Name = "gudang_kode" : gudang_kode.DataPropertyName = "kode" : gudang_kode.HeaderText = "Kode Gudang"
                    gudang_nama.Name = "gudang_nama" : gudang_nama.DataPropertyName = "nama" : gudang_nama.HeaderText = "Nama Gudang"
                    gudang_alamat.Name = "gudang_alamat" : gudang_alamat.DataPropertyName = "alamat" : gudang_alamat.HeaderText = "Alamat"
                    gudang_userid.Name = "gudang_userid" : gudang_userid.DataPropertyName = "userid" : gudang_userid.HeaderText = "UserID"
                    gudang_it.Name = "gudang_it" : gudang_it.DataPropertyName = "gudangit" : gudang_it.HeaderText = "IT"
                    gudang_et.Name = "gudang_et" : gudang_et.DataPropertyName = "gudanget" : gudang_et.HeaderText = "ET"
                    gudang_status.Name = "gudang_status" : gudang_status.DataPropertyName = "status" : gudang_status.HeaderText = "Status"

                    gudang_kode.Width = 100 : gudang_nama.Width = 225 : gudang_alamat.Width = 250
                    For Each x As DataGridViewColumn In {gudang_it, gudang_et}
                        x.Width = 100 : x.DefaultCellStyle = dgvstyle_datetime
                    Next
                    gudang_userid.Width = 100

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {gudang_kode, gudang_nama, gudang_alamat, gudang_status, gudang_it, gudang_et, gudang_userid, x_filler}
                        For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

                'LIST DATA SALESMAN
            Case "sales"
                With frmsales
                    .export_sw = True

                    Dim sales_kode = New DataGridViewColumn : sales_kode = dgvcol_templ_status.Clone()
                    Dim sales_nama = New DataGridViewColumn : sales_nama = dgvcol_templ_status.Clone()
                    Dim sales_jenis = New DataGridViewColumn : sales_jenis = dgvcol_templ_status.Clone()
                    Dim sales_alamat = New DataGridViewColumn : sales_alamat = dgvcol_templ_alamat.Clone()
                    Dim sales_telp = New DataGridViewColumn : sales_telp = dgvcol_templ_status.Clone()
                    Dim sales_status = New DataGridViewColumn : sales_status = dgvcol_templ_status.Clone()
                    Dim sales_userid = New DataGridViewColumn : sales_userid = dgvcol_templ_status.Clone()
                    Dim sales_it = New DataGridViewColumn : sales_it = dgvcol_templ_status.Clone()
                    Dim sales_et = New DataGridViewColumn : sales_et = dgvcol_templ_status.Clone()

                    sales_kode.Name = "sales_kode" : sales_kode.DataPropertyName = "kode" : sales_kode.HeaderText = "Kode Sales"
                    sales_nama.Name = "sales_nama" : sales_nama.DataPropertyName = "nama" : sales_nama.HeaderText = "Nama Salesman"
                    sales_jenis.Name = "sales_jenis" : sales_jenis.DataPropertyName = "jenis" : sales_jenis.HeaderText = "Jenis"
                    sales_alamat.Name = "sales_alamat" : sales_alamat.DataPropertyName = "alamat" : sales_alamat.HeaderText = "Alamat"
                    sales_telp.Name = "sales_telp" : sales_telp.DataPropertyName = "telp" : sales_telp.HeaderText = "Telp."
                    sales_status.Name = "sales_status" : sales_status.DataPropertyName = "status" : sales_status.HeaderText = "Status"
                    sales_userid.Name = "sales_userid" : sales_userid.DataPropertyName = "userid" : sales_userid.HeaderText = "UserID"
                    sales_it.Name = "sales_it" : sales_it.DataPropertyName = "salesit" : sales_it.HeaderText = "IT"
                    sales_et.Name = "sales_et" : sales_et.DataPropertyName = "saleset" : sales_et.HeaderText = "ET"

                    sales_kode.Width = 100 : sales_nama.Width = 225 : sales_alamat.Width = 250
                    For Each x As DataGridViewColumn In {sales_it, sales_et}
                        x.Width = 100 : x.DefaultCellStyle = dgvstyle_datetime
                    Next
                    sales_userid.Width = 100 : sales_telp.Width = 100

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {sales_kode, sales_nama, sales_jenis, sales_status, sales_alamat, sales_telp,
                                                         sales_it, sales_et, sales_userid, x_filler}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

                'LIST DATA CUSTOMER
            Case "custo"
                With frmcusto
                    Dim custo_kode = New DataGridViewColumn : custo_kode = dgvcol_templ_status.Clone()
                    Dim custo_nama = New DataGridViewColumn : custo_nama = dgvcol_templ_status.Clone()
                    Dim custo_type = New DataGridViewColumn : custo_type = dgvcol_templ_status.Clone()
                    Dim custo_alamat = New DataGridViewColumn : custo_alamat = dgvcol_templ_alamat.Clone()
                    Dim custo_alamat_kec = New DataGridViewColumn : custo_alamat_kec = dgvcol_templ_status.Clone()
                    Dim custo_alamat_kab = New DataGridViewColumn : custo_alamat_kab = dgvcol_templ_status.Clone()
                    Dim custo_alamat_psr = New DataGridViewColumn : custo_alamat_psr = dgvcol_templ_status.Clone()
                    Dim custo_telp = New DataGridViewColumn : custo_telp = dgvcol_templ_status.Clone()
                    Dim custo_fax = New DataGridViewColumn : custo_fax = dgvcol_templ_status.Clone()
                    Dim custo_status = New DataGridViewColumn : custo_status = dgvcol_templ_status.Clone()
                    Dim custo_userid = New DataGridViewColumn : custo_userid = dgvcol_templ_status.Clone()
                    Dim custo_it = New DataGridViewColumn : custo_it = dgvcol_templ_status.Clone()
                    Dim custo_et = New DataGridViewColumn : custo_et = dgvcol_templ_status.Clone()

                    custo_kode.Name = "custo_kode" : custo_kode.DataPropertyName = "kode" : custo_kode.HeaderText = "Kode Customer"
                    custo_nama.Name = "custo_nama" : custo_nama.DataPropertyName = "nama" : custo_nama.HeaderText = "Nama Customer"
                    custo_type.Name = "custo_type" : custo_type.DataPropertyName = "tipe" : custo_type.HeaderText = "Tipe"
                    custo_alamat.Name = "custo_alamat" : custo_alamat.DataPropertyName = "alamat" : custo_alamat.HeaderText = "Alamat"
                    custo_alamat_kec.Name = "custo_alamat_kec" : custo_alamat_kec.DataPropertyName = "kec" : custo_alamat_kec.HeaderText = "Kecamatan"
                    custo_alamat_kab.Name = "custo_alamat_kab" : custo_alamat_kab.DataPropertyName = "kab" : custo_alamat_kab.HeaderText = "Kabupaten"
                    custo_alamat_psr.Name = "custo_alamat_psr" : custo_alamat_psr.DataPropertyName = "pasar" : custo_alamat_psr.HeaderText = "Pasar"
                    custo_telp.Name = "custo_telp" : custo_telp.DataPropertyName = "telp" : custo_telp.HeaderText = "Telp."
                    custo_fax.Name = "custo_fax" : custo_fax.DataPropertyName = "fax" : custo_fax.HeaderText = "Fax."
                    custo_status.Name = "custo_status" : custo_status.DataPropertyName = "status" : custo_status.HeaderText = "Status"
                    .Name = "custo_userid" : custo_userid.DataPropertyName = "userid" : custo_userid.HeaderText = "UserID"
                    custo_it.Name = "custo_it" : custo_it.DataPropertyName = "custoit" : custo_it.HeaderText = "IT"
                    custo_et.Name = "custo_et" : custo_et.DataPropertyName = "custoet" : custo_et.HeaderText = "ET"

                    custo_kode.Width = 100 : custo_nama.Width = 225 : custo_alamat.Width = 250
                    For Each x As DataGridViewColumn In {custo_it, custo_et}
                        x.Width = 100 : x.DefaultCellStyle = dgvstyle_datetime
                    Next
                    For Each x As DataGridViewColumn In {custo_alamat_kec, custo_alamat_kab, custo_alamat_psr, custo_telp, custo_fax, custo_userid}
                        x.Width = 100
                    Next

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {custo_kode, custo_nama, custo_type, custo_status, custo_alamat, custo_alamat_kec, custo_alamat_kab,
                                                         custo_alamat_psr, custo_telp, custo_fax, custo_it, custo_et, custo_userid, x_filler}
                        For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

                'TAB LIST AKUN PERKIRAAN
            Case "perkiraan"
                With frmperkiraan
                    With .dgv_list
                        Dim perk_kode = New DataGridViewColumn : perk_kode = dgvcol_templ_id.Clone()
                        Dim perk_nama = New DataGridViewColumn : perk_nama = dgvcol_templ_status.Clone()
                        Dim perk_jenis = New DataGridViewColumn : perk_jenis = dgvcol_templ_status.Clone()
                        Dim perk_gol = New DataGridViewColumn : perk_gol = dgvcol_templ_status.Clone()
                        Dim perk_pos = New DataGridViewColumn : perk_pos = dgvcol_templ_id.Clone()
                        Dim perk_awal = New DataGridViewColumn : perk_awal = dgvcol_templ_numeric.Clone()
                        Dim perk_saldo = New DataGridViewColumn : perk_saldo = dgvcol_templ_numeric.Clone()
                        Dim perk_ket = New DataGridViewColumn : perk_ket = dgvcol_templ_status.Clone()
                        Dim perk_userid = New DataGridViewColumn : perk_userid = dgvcol_templ_status.Clone()
                        Dim perk_status = New DataGridViewColumn : perk_status = dgvcol_templ_status.Clone()

                        perk_kode.DataPropertyName = "perk_kode" : perk_kode.Name = "perk_kode" : perk_kode.HeaderText = "Kode Akun"
                        perk_nama.DataPropertyName = "perk_nama" : perk_nama.Name = "perk_nama" : perk_nama.HeaderText = "Nama Akun"
                        perk_jenis.DataPropertyName = "perk_jenis" : perk_nama.Name = "perk_jenis" : perk_jenis.HeaderText = "Kategori"
                        perk_gol.DataPropertyName = "perk_gol" : perk_gol.Name = "perk_gol" : perk_gol.HeaderText = "Sub. Kateg."
                        perk_pos.DataPropertyName = "perk_pos" : perk_pos.Name = "perk_pos" : perk_pos.HeaderText = "Pos."
                        perk_awal.DataPropertyName = "perk_saldoawal" : perk_awal.Name = "perk_awal" : perk_awal.HeaderText = "Saldo Awal"
                        perk_saldo.DataPropertyName = "perk_saldo" : perk_saldo.Name = "perk_saldo" : perk_saldo.HeaderText = "Saldo Berjalan"
                        perk_ket.DataPropertyName = "perk_ket" : perk_ket.Name = "perk_ket" : perk_ket.HeaderText = "Keterangan"
                        perk_userid.DataPropertyName = "perk_userid" : perk_userid.Name = "perk_userid" : perk_userid.HeaderText = "Input By"
                        perk_status.DataPropertyName = "status" : perk_status.Name = "perk_userid" : perk_status.HeaderText = "Status"

                        perk_nama.Width = 200 : perk_ket.Width = perk_nama.Width
                        perk_gol.Width = 120
                        perk_saldo.DefaultCellStyle = dgvstyle_commathousand
                        perk_awal.DefaultCellStyle = dgvstyle_commathousand

                        Dim x As DataGridViewColumn() = {perk_kode, perk_jenis, perk_gol, perk_nama, perk_pos, perk_status,
                                                         perk_awal, perk_saldo, perk_ket, perk_userid, x_filler}
                        For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

                'DATA LIST TRANSAKSI PEMBELIAN
            Case "beli"
                Dim beli_faktur = New DataGridViewColumn : beli_faktur = dgvcol_templ_status.Clone()
                Dim beli_tgl = New DataGridViewColumn : beli_tgl = dgvcol_templ_status.Clone()
                Dim beli_tglinvoice = New DataGridViewColumn : beli_tglinvoice = dgvcol_templ_status.Clone()
                Dim beli_status = New DataGridViewColumn : beli_status = dgvcol_templ_status.Clone()
                Dim beli_kat = New DataGridViewColumn : beli_kat = dgvcol_templ_id.Clone()
                Dim beli_supplier = New DataGridViewColumn : beli_supplier = dgvcol_templ_status.Clone()
                Dim beli_term = New DataGridViewColumn : beli_term = dgvcol_templ_id.Clone()
                Dim beli_noppn = New DataGridViewColumn : beli_noppn = dgvcol_templ_status.Clone()
                Dim beli_gudang = New DataGridViewColumn : beli_gudang = dgvcol_templ_status.Clone()
                Dim beli_netto = New DataGridViewColumn : beli_netto = dgvcol_templ_status.Clone()
                Dim beli_klaim = New DataGridViewColumn : beli_klaim = dgvcol_templ_status.Clone()
                Dim beli_total = New DataGridViewColumn : beli_total = dgvcol_templ_status.Clone()
                Dim beli_user = New DataGridViewColumn : beli_user = dgvcol_templ_status.Clone()
                Dim beli_it = New DataGridViewColumn : beli_it = dgvcol_templ_status.Clone()
                Dim beli_et = New DataGridViewColumn : beli_et = dgvcol_templ_status.Clone()

                beli_faktur.Name = "beli_faktur" : beli_faktur.DataPropertyName = "faktur" : beli_faktur.HeaderText = "No.Faktur"
                beli_tgl.Name = "beli_tgl" : beli_tgl.DataPropertyName = "tanggal" : beli_tgl.HeaderText = "Tanggal"
                beli_tglinvoice.Name = "beli_tglinvoice" : beli_tglinvoice.DataPropertyName = "tanggalinvoice" : beli_tglinvoice.HeaderText = "Tgl.Invoice/Pajak"
                beli_status.Name = "beli_status" : beli_status.DataPropertyName = "status" : beli_status.HeaderText = "Status"
                beli_term.Name = "beli_term" : beli_term.DataPropertyName = "term" : beli_term.HeaderText = "Term"
                beli_supplier.Name = "beli_supplier" : beli_supplier.DataPropertyName = "supplier" : beli_supplier.HeaderText = "Supplier"
                beli_kat.Name = "beli_kat" : beli_kat.DataPropertyName = "jenispajak" : beli_kat.HeaderText = "Kat."
                beli_noppn.Name = "beli_noppn" : beli_noppn.DataPropertyName = "pajak" : beli_noppn.HeaderText = "No.Pajak"
                beli_gudang.Name = "beli_gudang" : beli_gudang.DataPropertyName = "gudang" : beli_gudang.HeaderText = "Gudang"
                beli_netto.Name = "beli_netto" : beli_netto.DataPropertyName = "netto" : beli_netto.HeaderText = "Netto"
                beli_klaim.Name = "beli_klaim" : beli_klaim.DataPropertyName = "klaim" : beli_klaim.HeaderText = "Klaim"
                beli_total.Name = "beli_total" : beli_total.DataPropertyName = "total" : beli_total.HeaderText = "Sisa"
                beli_user.Name = "beli_user" : beli_user.DataPropertyName = "userid" : beli_user.HeaderText = "UserID"
                beli_it.Name = "beli_it" : beli_it.DataPropertyName = "regdate" : beli_it.HeaderText = "InputDate"
                beli_et.Name = "beli_et" : beli_et.DataPropertyName = "upddate" : beli_et.HeaderText = "LastUpdate"

                beli_faktur.Width = 120
                For Each col As DataGridViewColumn In {beli_supplier, beli_gudang, beli_noppn}
                    col.Width = 150
                Next
                beli_tgl.DefaultCellStyle = dgvstyle_date : beli_tglinvoice.DefaultCellStyle = dgvstyle_date
                For Each col As DataGridViewColumn In {beli_netto, beli_klaim, beli_total}
                    col.Width = 120 : col.DefaultCellStyle = dgvstyle_currency
                Next
                For Each col As DataGridViewColumn In {beli_it, beli_et}
                    col.Width = 100 : col.DefaultCellStyle = dgvstyle_datetime
                Next

                With frmpembelian
                    Dim x As DataGridViewColumn() = {beli_faktur, beli_tgl, beli_tglinvoice, beli_status, beli_kat, beli_supplier, beli_gudang, beli_noppn,
                                                     beli_netto, beli_klaim, beli_total, beli_term, beli_it, beli_et, beli_user}
                    For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)
                End With

                'DATA LIST TRANSAKSI RETUR PEMBELIAN
            Case "returbeli"
                With frmreturbeli
                    Dim retur_faktur = New DataGridViewColumn : retur_faktur = dgvcol_templ_status.Clone()
                    Dim retur_tgl = New DataGridViewColumn : retur_tgl = dgvcol_templ_status.Clone()
                    Dim retur_status = New DataGridViewColumn : retur_status = dgvcol_templ_status.Clone()
                    Dim retur_kat = New DataGridViewColumn : retur_kat = dgvcol_templ_id.Clone()
                    Dim retur_supplier = New DataGridViewColumn : retur_supplier = dgvcol_templ_status.Clone()
                    Dim retur_gudang = New DataGridViewColumn : retur_gudang = dgvcol_templ_status.Clone()
                    Dim retur_jnsbayar = New DataGridViewColumn : retur_jnsbayar = dgvcol_templ_status.Clone()
                    Dim retur_nota = New DataGridViewColumn : retur_nota = dgvcol_templ_status.Clone()
                    Dim retur_netto = New DataGridViewColumn : retur_netto = dgvcol_templ_status.Clone()
                    Dim retur_user = New DataGridViewColumn : retur_user = dgvcol_templ_status.Clone()
                    Dim retur_it = New DataGridViewColumn : retur_it = dgvcol_templ_status.Clone()
                    Dim retur_et = New DataGridViewColumn : retur_et = dgvcol_templ_status.Clone()

                    retur_faktur.Name = "retur_faktur" : retur_faktur.DataPropertyName = "bukti" : retur_faktur.HeaderText = "No.Faktur"
                    retur_tgl.Name = "retur_tgl" : retur_tgl.DataPropertyName = "tanggal" : retur_tgl.HeaderText = "Tanggal"
                    retur_kat.Name = "retur_kat" : retur_kat.DataPropertyName = "jenispajak" : retur_kat.HeaderText = "Kat."
                    retur_status.Name = "retur_status" : retur_status.DataPropertyName = "status" : retur_status.HeaderText = "Status"
                    retur_supplier.Name = "retur_supplier" : retur_supplier.DataPropertyName = "supplier" : retur_supplier.HeaderText = "Supplier"
                    retur_jnsbayar.Name = "retur_jnsbayar" : retur_jnsbayar.DataPropertyName = "jenisbayar" : retur_jnsbayar.HeaderText = "Jenis Bayar"
                    retur_nota.Name = "retur_nota" : retur_nota.DataPropertyName = "faktur" : retur_nota.HeaderText = "Faktur Penjualan"
                    retur_gudang.Name = "retur_gudang" : retur_gudang.DataPropertyName = "gudang" : retur_gudang.HeaderText = "Gudang"
                    retur_netto.Name = "retur_netto" : retur_netto.DataPropertyName = "jumlah" : retur_netto.HeaderText = "Jumlah"
                    retur_user.Name = "retur_user" : retur_user.DataPropertyName = "userid" : retur_user.HeaderText = "UserID"
                    retur_it.Name = "retur_it" : retur_it.DataPropertyName = "regdate" : retur_it.HeaderText = "InputDate"
                    retur_et.Name = "retur_et" : retur_et.DataPropertyName = "upddate" : retur_et.HeaderText = "LastUpdate"

                    retur_faktur.Width = 150 : retur_nota.Width = 150
                    For Each col As DataGridViewColumn In {retur_supplier, retur_gudang}
                        col.Width = 175
                    Next
                    retur_tgl.DefaultCellStyle = dgvstyle_date : retur_tgl.Width = 100
                    retur_netto.Width = 120 : retur_netto.DefaultCellStyle = dgvstyle_currency
                    For Each col As DataGridViewColumn In {retur_it, retur_et}
                        col.Width = 100 : col.DefaultCellStyle = dgvstyle_datetime
                    Next

                    Dim x As DataGridViewColumn() = {retur_faktur, retur_tgl, retur_kat, retur_status, retur_supplier, retur_gudang, retur_jnsbayar,
                                                     retur_nota, retur_netto, retur_user, retur_it, retur_et}
                    For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)

                End With

                'DATA LIST ORDER PENJUALAN
            Case "pesanan"
                With frmpesanjual
                    Dim pesan_kode = New DataGridViewColumn : pesan_kode = dgvcol_templ_status.Clone()
                    Dim pesan_tgl = New DataGridViewColumn : pesan_tgl = dgvcol_templ_status.Clone()
                    Dim pesan_term = New DataGridViewColumn : pesan_term = dgvcol_templ_status.Clone()
                    Dim pesan_custo = New DataGridViewColumn : pesan_custo = dgvcol_templ_status.Clone()
                    Dim pesan_sales = New DataGridViewColumn : pesan_sales = dgvcol_templ_status.Clone()
                    Dim pesan_total = New DataGridViewColumn : pesan_total = dgvcol_templ_status.Clone()
                    Dim pesan_validstate = New DataGridViewColumn : pesan_validstate = dgvcol_templ_status.Clone()
                    Dim pesan_faktur = New DataGridViewColumn : pesan_faktur = dgvcol_templ_status.Clone()
                    Dim pesan_validdate = New DataGridViewColumn : pesan_validdate = dgvcol_templ_status.Clone()
                    Dim pesan_validuser = New DataGridViewColumn : pesan_validuser = dgvcol_templ_status.Clone()
                    Dim pesan_user = New DataGridViewColumn : pesan_user = dgvcol_templ_status.Clone()
                    Dim pesan_it = New DataGridViewColumn : pesan_it = dgvcol_templ_status.Clone()
                    Dim pesan_et = New DataGridViewColumn : pesan_et = dgvcol_templ_status.Clone()
                    Dim pesan_andro = New DataGridViewColumn : pesan_andro = dgvcol_templ_id.Clone()

                    pesan_kode.Name = "pesan_kode" : pesan_kode.DataPropertyName = "kode" : pesan_kode.HeaderText = "No.Order"
                    pesan_tgl.Name = "pesan_tgl" : pesan_tgl.DataPropertyName = "tanggal" : pesan_tgl.HeaderText = "Tanggal"
                    pesan_term.Name = "pesan_term" : pesan_term.DataPropertyName = "term" : pesan_term.HeaderText = "Bayar"
                    pesan_custo.Name = "pesan_custo" : pesan_custo.DataPropertyName = "custo" : pesan_custo.HeaderText = "Customer"
                    pesan_sales.Name = "pesan_sales" : pesan_sales.DataPropertyName = "sales" : pesan_sales.HeaderText = "Salesman"
                    pesan_total.Name = "pesan_total" : pesan_total.DataPropertyName = "total" : pesan_total.HeaderText = "Sisa"
                    pesan_validstate.Name = "pesan_validstate" : pesan_validstate.DataPropertyName = "status" : pesan_validstate.HeaderText = "Status"
                    pesan_faktur.Name = "pesan_faktur" : pesan_faktur.DataPropertyName = "faktur" : pesan_faktur.HeaderText = "No.Faktur Jual"
                    pesan_validdate.Name = "pesan_validdate" : pesan_validdate.DataPropertyName = "valid_date" : pesan_validdate.HeaderText = "Tgl. Valid"
                    pesan_validuser.Name = "pesan_validuser" : pesan_validuser.DataPropertyName = "valid_alias" : pesan_validuser.HeaderText = "ValidBy."
                    pesan_user.Name = "pesan_user" : pesan_user.DataPropertyName = "userid" : pesan_user.HeaderText = "UserID"
                    pesan_it.Name = "pesan_it" : pesan_it.DataPropertyName = "regdate" : pesan_it.HeaderText = "InputDate"
                    pesan_et.Name = "pesan_et" : pesan_et.DataPropertyName = "upddate" : pesan_et.HeaderText = "LastUpdate"
                    pesan_andro.Name = "pesan_andro" : pesan_andro.DataPropertyName = "input_source" : pesan_andro.HeaderText = "InputFrom"

                    pesan_custo.Width = 150 : pesan_sales.Width = 120
                    pesan_total.Width = 100 : pesan_total.DefaultCellStyle = dgvstyle_currency
                    pesan_faktur.Width = 100
                    pesan_tgl.Width = 100 : pesan_tgl.DefaultCellStyle = dgvstyle_date
                    pesan_andro.Width = 100
                    For Each col As DataGridViewColumn In {pesan_it, pesan_et, pesan_validdate}
                        col.Width = 100 : col.DefaultCellStyle = dgvstyle_datetime
                    Next

                    Dim x As DataGridViewColumn() = {pesan_kode, pesan_tgl, pesan_sales, pesan_custo, pesan_total, pesan_term, pesan_validstate,
                                                     pesan_faktur, pesan_validdate, pesan_validuser, pesan_user, pesan_it, pesan_et, pesan_andro}
                    For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)
                End With

                'DATA LIST TRANSAKSI PENJUALAN
            Case "jual"
                With frmpenjualan
                    Dim jual_faktur = New DataGridViewColumn : jual_faktur = dgvcol_templ_status.Clone()
                    Dim jual_tgl = New DataGridViewColumn : jual_tgl = dgvcol_templ_status.Clone()
                    Dim jual_status = New DataGridViewColumn : jual_status = dgvcol_templ_status.Clone()
                    Dim jual_cetak = New DataGridViewColumn : jual_cetak = dgvcol_templ_status.Clone()
                    Dim jual_term = New DataGridViewColumn : jual_term = dgvcol_templ_id.Clone()
                    Dim jual_custo = New DataGridViewColumn : jual_custo = dgvcol_templ_status.Clone()
                    Dim jual_sales = New DataGridViewColumn : jual_sales = dgvcol_templ_status.Clone()
                    Dim jual_kat = New DataGridViewColumn : jual_kat = dgvcol_templ_id.Clone()
                    Dim jual_noppn = New DataGridViewColumn : jual_noppn = dgvcol_templ_status.Clone()
                    Dim jual_gudang = New DataGridViewColumn : jual_gudang = dgvcol_templ_status.Clone()
                    Dim jual_netto = New DataGridViewColumn : jual_netto = dgvcol_templ_status.Clone()
                    Dim jual_bayar = New DataGridViewColumn : jual_bayar = dgvcol_templ_status.Clone()
                    Dim jual_total = New DataGridViewColumn : jual_total = dgvcol_templ_status.Clone()
                    Dim jual_user = New DataGridViewColumn : jual_user = dgvcol_templ_status.Clone()
                    Dim jual_it = New DataGridViewColumn : jual_it = dgvcol_templ_status.Clone()
                    Dim jual_et = New DataGridViewColumn : jual_et = dgvcol_templ_status.Clone()

                    jual_faktur.Name = "jual_faktur" : jual_faktur.DataPropertyName = "faktur" : jual_faktur.HeaderText = "No.Faktur"
                    jual_tgl.Name = "jual_tgl" : jual_tgl.DataPropertyName = "tanggal" : jual_tgl.HeaderText = "Tanggal"
                    jual_status.Name = "jual_status" : jual_status.DataPropertyName = "status" : jual_status.HeaderText = "Status"
                    jual_cetak.Name = "jual_cetak" : jual_cetak.DataPropertyName = "statuscetak" : jual_cetak.HeaderText = "Cetakan"
                    jual_term.Name = "jual_term" : jual_term.DataPropertyName = "term" : jual_term.HeaderText = "Term"
                    jual_custo.Name = "jual_custo" : jual_custo.DataPropertyName = "custo" : jual_custo.HeaderText = "Customer"
                    jual_sales.Name = "jual_sales" : jual_sales.DataPropertyName = "sales" : jual_sales.HeaderText = "Salesman"
                    jual_kat.Name = "jual_kat" : jual_kat.DataPropertyName = "jenispajak" : jual_kat.HeaderText = "Kat."
                    jual_noppn.Name = "jual_noppn" : jual_noppn.DataPropertyName = "pajak" : jual_noppn.HeaderText = "No.Pajak"
                    jual_gudang.Name = "jual_gudang" : jual_gudang.DataPropertyName = "gudang" : jual_gudang.HeaderText = "Gudang"
                    jual_netto.Name = "jual_netto" : jual_netto.DataPropertyName = "netto" : jual_netto.HeaderText = "Netto"
                    jual_bayar.Name = "jual_bayar" : jual_bayar.DataPropertyName = "klaim" : jual_bayar.HeaderText = "Bayar/Tunai"
                    jual_total.Name = "jual_total" : jual_total.DataPropertyName = "total" : jual_total.HeaderText = "Sisa"
                    jual_user.Name = "jual_user" : jual_user.DataPropertyName = "userid" : jual_user.HeaderText = "UserID"
                    jual_it.Name = "jual_it" : jual_it.DataPropertyName = "regdate" : jual_it.HeaderText = "InputDate"
                    jual_et.Name = "jual_et" : jual_et.DataPropertyName = "upddate" : jual_et.HeaderText = "LastUpdate"

                    jual_faktur.Width = 100
                    For Each col As DataGridViewColumn In {jual_custo, jual_sales, jual_gudang, jual_noppn}
                        col.Width = 150
                    Next
                    jual_tgl.DefaultCellStyle = dgvstyle_date
                    For Each col As DataGridViewColumn In {jual_netto, jual_bayar, jual_total}
                        col.Width = 120 : col.DefaultCellStyle = dgvstyle_currency
                    Next
                    For Each col As DataGridViewColumn In {jual_it, jual_et}
                        col.Width = 100 : col.DefaultCellStyle = dgvstyle_datetime
                    Next

                    Dim x As DataGridViewColumn() = {jual_faktur, jual_tgl, jual_status, jual_cetak, jual_term, jual_custo, jual_sales, jual_kat, jual_noppn,
                                                    jual_gudang, jual_netto, jual_bayar, jual_total, jual_user, jual_it, jual_et}
                    For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)
                End With

            Case "returjual"
                With frmreturjual
                    Dim retur_jual_gudang = New DataGridViewColumn
                    Dim retur_jual_user = New DataGridViewColumn
                    Dim retur_jual_jml = New DataGridViewColumn
                    Dim retur_jnsbyr = New DataGridViewColumn
                    Dim retur_status = New DataGridViewColumn
                    Dim retur_jenpajak = New DataGridViewColumn
                    Dim retur_it = New DataGridViewColumn
                    Dim retur_et = New DataGridViewColumn
                    retur_jual_gudang = retur_beli_gudang.Clone()
                    retur_jual_user = user_id.Clone()
                    retur_jual_jml = retur_beli_jml.Clone()
                    retur_jnsbyr = hutang_jenis.Clone()
                    retur_status = gudang_status.Clone()
                    retur_jenpajak = gudang_status.Clone()
                    retur_it = jual_tgl.Clone()
                    retur_et = jual_tgl.Clone()

                    retur_jenpajak.Width = 50
                    retur_jenpajak.Name = "jenpajak"
                    retur_jenpajak.HeaderText = "Kat."
                    retur_jenpajak.DataPropertyName = "jenispajak"
                    retur_it.HeaderText = "InputDate"
                    retur_et.HeaderText = "LastEditDate"
                    retur_it.Name = "retur_it"
                    retur_et.Name = "retur_et"
                    retur_it.DataPropertyName = "regdate"
                    retur_et.DataPropertyName = "upddate"

                    Dim x As DataGridViewColumn() = {retur_jual_bukti, retur_jnsbyr, retur_jenpajak, retur_jual_faktur, retur_status, retur_jual_tgl, retur_jual_sales,
                                                     retur_jual_custo, retur_jual_gudang, retur_jual_jml, retur_it, retur_et, retur_jual_user}
                    For i = 0 To x.Count - 1
                        x(i).DisplayIndex = i
                    Next

                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)
                End With

            Case "stok"
                With frmstok
                    Dim stok_status = New DataGridViewColumn
                    Dim stok_sisaop = New DataGridViewColumn
                    Dim stok_kode = New DataGridViewColumn
                    stok_status = gudang_status.Clone()
                    stok_kode = gudang_kode.Clone()
                    stok_sisaop = stok_total.Clone()
                    stok_status.DataPropertyName = "stock_status"
                    stok_sisaop.DataPropertyName = "stock_sisastockop"
                    stok_sisaop.Name = "sisaop"
                    stok_status.Width = 50

                    stok_kode.Visible = False
                    stok_kode.DataPropertyName = "stock_kode"

                    With .dgv_list()
                        Dim x As DataGridViewColumn() = {stok_kode, stok_tgl, stok_status, stok_gudang, stok_barang, stok_hpp, stok_awal, stok_beli,
                                                         stok_jual, stok_rbeli, stok_rjual, stok_in, stok_out, stok_total, stok_opname, stok_sisaop}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

                'Case "mutasigudang"
                '    With frmmutasigudang
                '        With .dgv_list
                '           dim whatever
                '            Dim x As DataGridViewColumn() = {}
                '            For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                '            .AutoGenerateColumns = False
                '            .Columns.AddRange(x)
                '        End With
                '    End With

                'Case "mutasistok"
                '    With frmmutasistok
                '        With .dgv_list
                '           dim whatever
                '            Dim x As DataGridViewColumn() = {}
                '            For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                '            .AutoGenerateColumns = False
                '            .Columns.AddRange(x)
                '        End With
                '    End With

                'Case "stockop"
                '    With frmstockop
                '        With .dgv_list
                '           dim whatever

                '            Dim x As DataGridViewColumn() = {}
                '            For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                '            .AutoGenerateColumns = False
                '            .Columns.AddRange(x)
                '        End With
                '    End With

                'TAB LIST HUTANG
            Case "hutangawal"
                With frmhutangawal
                    Dim hutang_faktur = New DataGridViewColumn() : hutang_faktur = dgvcol_templ_id.Clone()
                    Dim hutang_pajak = New DataGridViewColumn : hutang_pajak = dgvcol_templ_id.Clone()
                    Dim hutang_tgl = New DataGridViewColumn() : hutang_tgl = dgvcol_templ_status.Clone()
                    Dim hutang_jt = New DataGridViewColumn() : hutang_jt = dgvcol_templ_status.Clone()
                    Dim hutang_supplier = New DataGridViewColumn() : hutang_supplier = dgvcol_templ_status.Clone()
                    Dim hutang_status = New DataGridViewColumn() : hutang_status = dgvcol_templ_status.Clone()
                    Dim hutang_tgl_lunas = New DataGridViewColumn : hutang_tgl_lunas = dgvcol_templ_status.Clone()
                    Dim hutang_term = New DataGridViewColumn() : hutang_term = dgvcol_templ_id.Clone()
                    Dim hutang_awal = New DataGridViewColumn() : hutang_awal = dgvcol_templ_numeric.Clone()
                    Dim hutang_beli = New DataGridViewColumn : hutang_beli = dgvcol_templ_numeric.Clone()
                    Dim hutang_retur = New DataGridViewColumn : hutang_retur = dgvcol_templ_numeric.Clone()
                    Dim hutang_bayar = New DataGridViewColumn : hutang_bayar = dgvcol_templ_numeric.Clone()
                    Dim hutang_tolak = New DataGridViewColumn : hutang_tolak = dgvcol_templ_numeric.Clone()
                    Dim hutang_sisa = New DataGridViewColumn : hutang_sisa = dgvcol_templ_numeric.Clone()
                    Dim hutang_giro_awal = New DataGridViewColumn : hutang_giro_awal = dgvcol_templ_numeric.Clone()
                    Dim hutang_giro_saldo = New DataGridViewColumn : hutang_giro_saldo = dgvcol_templ_numeric.Clone()

                    hutang_faktur.Name = "hutang_faktur" : hutang_faktur.DataPropertyName = "hutang_faktur" : hutang_faktur.HeaderText = "Kode Hutang"
                    hutang_pajak.Name = "hutang_pajak" : hutang_pajak.DataPropertyName = "hutang_kat" : hutang_pajak.HeaderText = "Kat."
                    hutang_tgl.Name = "hutang_tgl" : hutang_tgl.DataPropertyName = "hutang_tgl" : hutang_tgl.HeaderText = "Tanggal Hutang"
                    hutang_jt.Name = "hutang_jt" : hutang_jt.DataPropertyName = "hutang_jt" : hutang_jt.HeaderText = "Jatuh Tempo"
                    hutang_supplier.Name = "hutang_supplier" : hutang_supplier.DataPropertyName = "hutang_supplier" : hutang_supplier.HeaderText = "Nama Supplier"
                    hutang_status.Name = "hutang_status" : hutang_status.DataPropertyName = "hutang_status" : hutang_status.HeaderText = "Status"
                    hutang_tgl_lunas.Name = "hutang_tgl_lunas" : hutang_tgl_lunas.DataPropertyName = "hutang_lunas" : hutang_tgl_lunas.HeaderText = "Tgl. Lunas"
                    hutang_term.Name = "hutang_term" : hutang_term.DataPropertyName = "hutang_term" : hutang_term.HeaderText = "Term."
                    hutang_awal.Name = "hutang_awal" : hutang_awal.DataPropertyName = "hutang_awal" : hutang_awal.HeaderText = "hutang Awal"
                    hutang_beli.Name = "hutang_beli" : hutang_beli.DataPropertyName = "hutang_hutang" : hutang_beli.HeaderText = "Pembelian"
                    hutang_retur.Name = "hutang_retur" : hutang_retur.DataPropertyName = "hutang_retur" : hutang_retur.HeaderText = "Retur"
                    hutang_bayar.Name = "hutang_bayar" : hutang_bayar.DataPropertyName = "hutang_bayar" : hutang_bayar.HeaderText = "Bayar"
                    hutang_sisa.Name = "hutang_sisa" : hutang_sisa.DataPropertyName = "hutang_sisa" : hutang_sisa.HeaderText = "Sisa"
                    hutang_giro_awal.Name = "hutang_giro_awal" : hutang_giro_awal.DataPropertyName = "hutang_giro_awal" : hutang_giro_awal.HeaderText = "Hutang Giro"
                    hutang_giro_saldo.Name = "hutang_giro_saldo" : hutang_giro_saldo.DataPropertyName = "hutang_giro" : hutang_giro_saldo.HeaderText = "Saldo Giro"

                    For Each col As DataGridViewColumn In {hutang_awal, hutang_beli, hutang_retur, hutang_bayar, hutang_tolak, hutang_sisa,
                                                           hutang_giro_awal, hutang_giro_saldo}
                        col.Width = 100
                        col.DefaultCellStyle = dgvstyle_currency
                    Next
                    For Each col As DataGridViewColumn In {hutang_jt, hutang_tgl, hutang_tgl_lunas}
                        col.Width = 110
                        col.DefaultCellStyle = dgvstyle_date
                    Next
                    hutang_supplier.Width = 200
                    hutang_faktur.Width = 100

                    Dim x As DataGridViewColumn() = {hutang_faktur, hutang_pajak, hutang_tgl, hutang_jt, hutang_supplier, hutang_term,
                                                     hutang_status, hutang_awal, hutang_beli, hutang_retur, hutang_bayar, hutang_sisa,
                                                     hutang_giro_awal, hutang_giro_saldo, hutang_tgl_lunas}
                    For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)

                End With

                'TAB LIST PEMBAYARAN HUTANG
            Case "hutangbayar"
                With frmhutangbayar
                    Dim hutang_bukti = New DataGridViewColumn() : hutang_bukti = dgvcol_templ_status.Clone()
                    Dim hutang_tgl = New DataGridViewColumn() : hutang_tgl = dgvcol_templ_status.Clone()
                    Dim hutang_jenpajak = New DataGridViewColumn() : hutang_jenpajak = dgvcol_templ_id.Clone()
                    Dim hutang_supplier = New DataGridViewColumn() : hutang_supplier = dgvcol_templ_status.Clone()
                    Dim hutang_jenis = New DataGridViewColumn() : hutang_jenis = dgvcol_templ_status.Clone()
                    Dim hutang_debet = New DataGridViewColumn() : hutang_debet = dgvcol_templ_status.Clone()
                    Dim hutang_status = New DataGridViewColumn() : hutang_status = dgvcol_templ_status.Clone()
                    Dim hutang_user = New DataGridViewColumn() : hutang_user = dgvcol_templ_status.Clone()
                    Dim hutang_it = New DataGridViewColumn : hutang_it = dgvcol_templ_status.Clone()
                    Dim hutang_et = New DataGridViewColumn : hutang_et = dgvcol_templ_status.Clone()

                    hutang_bukti.Name = "hutang_bukti" : hutang_bukti.DataPropertyName = "bayar_bukti" : hutang_bukti.HeaderText = "No. Faktur"
                    hutang_tgl.Name = "hutang_tgl" : hutang_tgl.DataPropertyName = "bayar_tgl" : hutang_tgl.HeaderText = "Tanggal Bayar"
                    hutang_jenpajak.Name = "hutang_jenpajak" : hutang_jenpajak.DataPropertyName = "bayar_kat" : hutang_jenpajak.HeaderText = "Kat."
                    hutang_supplier.Name = "hutang_supplier" : hutang_supplier.DataPropertyName = "bayar_supplier" : hutang_supplier.HeaderText = "Supplier"
                    hutang_jenis.Name = "hutang_jenis" : hutang_jenis.DataPropertyName = "bayar_jenis" : hutang_jenis.HeaderText = "Jenis Bayar"
                    hutang_debet.Name = "hutang_debet" : hutang_debet.DataPropertyName = "bayar_nilai" : hutang_debet.HeaderText = "Jumlah Bayar"
                    hutang_status.Name = "hutang_status" : hutang_status.DataPropertyName = "bayar_status" : hutang_status.HeaderText = "Status"
                    hutang_user.Name = "hutang_user" : hutang_user.DataPropertyName = "bayar_user" : hutang_user.HeaderText = "UserID"
                    hutang_it.Name = "hutang_it" : hutang_it.DataPropertyName = "regdate" : hutang_it.HeaderText = "InputDate"
                    hutang_et.Name = "hutang_et" : hutang_et.DataPropertyName = "upddate" : hutang_et.HeaderText = "LastUpdate"

                    hutang_bukti.Width = 100
                    hutang_debet.Width = 120 : hutang_debet.DefaultCellStyle = dgvstyle_currency
                    hutang_supplier.Width = 200
                    hutang_tgl.Width = 110 : hutang_tgl.DefaultCellStyle = dgvstyle_date
                    For Each col As DataGridViewColumn In {hutang_it, hutang_et}
                        col.Width = 100 : col.DefaultCellStyle = dgvstyle_datetime
                    Next

                    Dim x As DataGridViewColumn() = {hutang_bukti, hutang_tgl, hutang_jenpajak, hutang_supplier, hutang_debet, hutang_jenis, hutang_status,
                                                     hutang_it, hutang_et, hutang_user, x_filler}
                    For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)
                End With

                'TAB LIST BG KELUAR
            Case "hutangbgo"
                With frmhutangbgo
                    Dim hutangbgo_kode = New DataGridViewColumn() : hutangbgo_kode = dgvcol_templ_status.Clone()
                    Dim hutangbgo_tgl = New DataGridViewColumn() : hutangbgo_tgl = dgvcol_templ_status.Clone()
                    Dim hutangbgo_bank = New DataGridViewColumn() : hutangbgo_bank = dgvcol_templ_status.Clone()
                    Dim hutangbgo_supplier = New DataGridViewColumn() : hutangbgo_supplier = dgvcol_templ_status.Clone()
                    Dim hutangbgo_jml = New DataGridViewColumn() : hutangbgo_jml = dgvcol_templ_numeric.Clone()
                    Dim hutangbgo_tglbgo = New DataGridViewColumn() : hutangbgo_tglbgo = dgvcol_templ_status.Clone()
                    Dim hutangbgo_ref = New DataGridViewColumn() : hutangbgo_ref = dgvcol_templ_status.Clone()
                    Dim hutangbgo_status = New DataGridViewColumn() : hutangbgo_status = dgvcol_templ_status.Clone()
                    Dim hutangbgo_tglcair = New DataGridViewColumn() : hutangbgo_tglcair = dgvcol_templ_status.Clone()
                    Dim hutangbgo_tgltolak = New DataGridViewColumn() : hutangbgo_tgltolak = dgvcol_templ_status.Clone()
                    Dim hutangbgo_usercair = New DataGridViewColumn() : hutangbgo_usercair = dgvcol_templ_status.Clone()

                    hutangbgo_kode.Name = "hutangbgo_kode" : hutangbgo_kode.DataPropertyName = "giro_no" : hutangbgo_kode.HeaderText = "Nomor Giro"
                    hutangbgo_tgl.Name = "hutangbgo_tgl" : hutangbgo_tgl.DataPropertyName = "giro_tglterima" : hutangbgo_tgl.HeaderText = "Tanggal Terima"
                    hutangbgo_bank.Name = "hutangbgo_bank" : hutangbgo_bank.DataPropertyName = "giro_bank_n" : hutangbgo_bank.HeaderText = "Bank"
                    hutangbgo_supplier.Name = "hutangbgo_supplier" : hutangbgo_supplier.DataPropertyName = "giro_supplier" : hutangbgo_supplier.HeaderText = "Supplier"
                    hutangbgo_jml.Name = "hutangbgo_jml" : hutangbgo_jml.DataPropertyName = "giro_nilai" : hutangbgo_jml.HeaderText = "Jumlah"
                    hutangbgo_tglbgo.Name = "hutangbgo_tglbgo" : hutangbgo_tglbgo.DataPropertyName = "giro_tglefektif" : hutangbgo_tglbgo.HeaderText = "Tanggal BG"
                    hutangbgo_ref.Name = "hutangbgo_ref" : hutangbgo_ref.DataPropertyName = "giro_ref" : hutangbgo_ref.HeaderText = "Faktur Bayar"
                    hutangbgo_status.Name = "hutangbgo_status" : hutangbgo_status.DataPropertyName = "giro_status" : hutangbgo_status.HeaderText = "Status"
                    hutangbgo_tglcair.Name = "hutangbgo_tglcair" : hutangbgo_tglcair.DataPropertyName = "giro_tglcair" : hutangbgo_tglcair.HeaderText = "Tanggal Cair"
                    hutangbgo_tgltolak.Name = "hutangbgo_tgltolak" : hutangbgo_tgltolak.DataPropertyName = "giro_tgltolak" : hutangbgo_tgltolak.HeaderText = "Tanggal Tolak"
                    hutangbgo_usercair.Name = "hutangbgo_usercair" : hutangbgo_usercair.DataPropertyName = "giro_usercair" : hutangbgo_usercair.HeaderText = "UserID"

                    hutangbgo_kode.Width = 100
                    hutangbgo_jml.Width = 120 : hutangbgo_jml.DefaultCellStyle = dgvstyle_currency
                    For Each x As DataGridViewColumn In {hutangbgo_tgl, hutangbgo_tglbgo, hutangbgo_tglcair, hutangbgo_tgltolak}
                        x.Width = 110
                        x.DefaultCellStyle = dgvstyle_date
                    Next
                    hutangbgo_bank.Width = 175 : hutangbgo_supplier.Width = 175
                    hutangbgo_ref.Width = 100

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {hutangbgo_kode, hutangbgo_tgl, hutangbgo_bank, hutangbgo_supplier, hutangbgo_tglbgo, hutangbgo_jml,
                                                         hutangbgo_status, hutangbgo_ref, hutangbgo_tglcair, hutangbgo_tgltolak, hutangbgo_usercair, x_filler}
                        For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

                'TAB LIST PIUTANG
            Case "piutangawal"
                With frmpiutangawal
                    Dim piutang_faktur = New DataGridViewColumn() : piutang_faktur = dgvcol_templ_id.Clone()
                    Dim piutang_pajak = New DataGridViewColumn : piutang_pajak = dgvcol_templ_id.Clone()
                    Dim piutang_tgl = New DataGridViewColumn() : piutang_tgl = dgvcol_templ_status.Clone()
                    Dim piutang_jt = New DataGridViewColumn() : piutang_jt = dgvcol_templ_status.Clone()
                    Dim piutang_custo = New DataGridViewColumn() : piutang_custo = dgvcol_templ_status.Clone()
                    Dim piutang_sales = New DataGridViewColumn() : piutang_sales = dgvcol_templ_status.Clone()
                    Dim piutang_status = New DataGridViewColumn() : piutang_status = dgvcol_templ_status.Clone()
                    Dim piutang_tgl_lunas = New DataGridViewColumn : piutang_tgl_lunas = dgvcol_templ_status.Clone()
                    Dim piutang_term = New DataGridViewColumn() : piutang_term = dgvcol_templ_id.Clone()
                    Dim piutang_awal = New DataGridViewColumn() : piutang_awal = dgvcol_templ_numeric.Clone()
                    Dim piutang_jual = New DataGridViewColumn : piutang_jual = dgvcol_templ_numeric.Clone()
                    Dim piutang_retur = New DataGridViewColumn : piutang_retur = dgvcol_templ_numeric.Clone()
                    Dim piutang_bayar = New DataGridViewColumn : piutang_bayar = dgvcol_templ_numeric.Clone()
                    Dim piutang_tolak = New DataGridViewColumn : piutang_tolak = dgvcol_templ_numeric.Clone()
                    Dim piutang_sisa = New DataGridViewColumn : piutang_sisa = dgvcol_templ_numeric.Clone()
                    Dim piutang_giro_awal = New DataGridViewColumn : piutang_giro_awal = dgvcol_templ_numeric.Clone()
                    Dim piutang_giro_saldo = New DataGridViewColumn : piutang_giro_saldo = dgvcol_templ_numeric.Clone()

                    piutang_faktur.Name = "piutang_faktur" : piutang_faktur.DataPropertyName = "piutang_faktur" : piutang_faktur.HeaderText = "Kode Piutang"
                    piutang_pajak.Name = "piutang_pajak" : piutang_pajak.DataPropertyName = "piutang_kat" : piutang_pajak.HeaderText = "Kat."
                    piutang_tgl.Name = "piutang_tgl" : piutang_tgl.DataPropertyName = "piutang_tgl" : piutang_tgl.HeaderText = "Tanggal Piutang"
                    piutang_jt.Name = "piutang_jt" : piutang_jt.DataPropertyName = "piutang_jt" : piutang_jt.HeaderText = "Jatuh Tempo"
                    piutang_custo.Name = "piutang_custo" : piutang_custo.DataPropertyName = "piutang_custo" : piutang_custo.HeaderText = "Nama Customer"
                    piutang_sales.Name = "piutang_sales" : piutang_sales.DataPropertyName = "piutang_sales" : piutang_sales.HeaderText = "Nama Salesman"
                    piutang_status.Name = "piutang_status" : piutang_status.DataPropertyName = "piutang_status" : piutang_status.HeaderText = "Status"
                    piutang_tgl_lunas.Name = "piutang_tgl_lunas" : piutang_tgl_lunas.DataPropertyName = "piutang_lunas" : piutang_tgl_lunas.HeaderText = "Tgl. Lunas"
                    piutang_term.Name = "piutang_term" : piutang_term.DataPropertyName = "piutang_term" : piutang_term.HeaderText = "Term."
                    piutang_awal.Name = "piutang_awal" : piutang_awal.DataPropertyName = "piutang_awal" : piutang_awal.HeaderText = "Piutang Awal"
                    piutang_jual.Name = "piutang_jual" : piutang_jual.DataPropertyName = "piutang_piutang" : piutang_jual.HeaderText = "Penjualan"
                    piutang_retur.Name = "piutang_retur" : piutang_retur.DataPropertyName = "piutang_retur" : piutang_retur.HeaderText = "Retur"
                    piutang_bayar.Name = "piutang_bayar" : piutang_bayar.DataPropertyName = "piutang_bayar" : piutang_bayar.HeaderText = "Bayar"
                    piutang_sisa.Name = "piutang_sisa" : piutang_sisa.DataPropertyName = "piutang_sisa" : piutang_sisa.HeaderText = "Sisa"
                    piutang_giro_awal.Name = "piutang_giro_awal" : piutang_giro_awal.DataPropertyName = "piutang_giro_awal" : piutang_giro_awal.HeaderText = "Piutang Giro"
                    piutang_giro_saldo.Name = "piutang_giro_saldo" : piutang_giro_saldo.DataPropertyName = "piutang_giro" : piutang_giro_saldo.HeaderText = "Saldo Giro"

                    For Each col As DataGridViewColumn In {piutang_awal, piutang_jual, piutang_retur, piutang_bayar, piutang_tolak, piutang_sisa,
                                                           piutang_giro_awal, piutang_giro_saldo}
                        col.Width = 100
                        col.DefaultCellStyle = dgvstyle_currency
                    Next
                    For Each col As DataGridViewColumn In {piutang_jt, piutang_tgl, piutang_tgl_lunas}
                        col.Width = 110
                        col.DefaultCellStyle = dgvstyle_date
                    Next
                    piutang_custo.Width = 200 : piutang_sales.Width = 100
                    piutang_faktur.Width = 100

                    Dim x As DataGridViewColumn() = {piutang_faktur, piutang_pajak, piutang_tgl, piutang_jt, piutang_custo, piutang_sales, piutang_term,
                                                     piutang_status, piutang_awal, piutang_jual, piutang_retur, piutang_bayar, piutang_sisa,
                                                     piutang_giro_awal, piutang_giro_saldo, piutang_tgl_lunas}
                    For i = 0 To x.Count - 1
                        x(i).DisplayIndex = i
                    Next

                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)
                End With

                'TAB LIST PEMBAYARAN PIUTANG
            Case "piutangbayar"
                With frmpiutangbayar
                    Dim piutang_bukti = New DataGridViewColumn() : piutang_bukti = dgvcol_templ_status.Clone()
                    Dim piutang_tgl = New DataGridViewColumn() : piutang_tgl = dgvcol_templ_status.Clone()
                    Dim piutang_jenpajak = New DataGridViewColumn() : piutang_jenpajak = dgvcol_templ_id.Clone()
                    Dim piutang_sales = New DataGridViewColumn() : piutang_sales = dgvcol_templ_status.Clone()
                    Dim piutang_custo = New DataGridViewColumn() : piutang_custo = dgvcol_templ_status.Clone()
                    Dim piutang_jenis = New DataGridViewColumn() : piutang_jenis = dgvcol_templ_status.Clone()
                    Dim piutang_debet = New DataGridViewColumn() : piutang_debet = dgvcol_templ_status.Clone()
                    Dim piutang_status = New DataGridViewColumn() : piutang_status = dgvcol_templ_status.Clone()
                    Dim piutang_andro = New DataGridViewColumn() : piutang_andro = dgvcol_templ_status.Clone()
                    Dim piutang_user = New DataGridViewColumn() : piutang_user = dgvcol_templ_status.Clone()
                    Dim piutang_it = New DataGridViewColumn : piutang_it = dgvcol_templ_status.Clone()
                    Dim piutang_et = New DataGridViewColumn : piutang_et = dgvcol_templ_status.Clone()

                    piutang_bukti.Name = "piutang_bukti" : piutang_bukti.DataPropertyName = "bukti" : piutang_bukti.HeaderText = "No. Faktur"
                    piutang_tgl.Name = "piutang_tgl" : piutang_tgl.DataPropertyName = "tanggal" : piutang_tgl.HeaderText = "Tanggal Bayar"
                    piutang_jenpajak.Name = "piutang_jenpajak" : piutang_jenpajak.DataPropertyName = "bayar_kat" : piutang_jenpajak.HeaderText = "Kat."
                    piutang_sales.Name = "piutang_sales" : piutang_sales.DataPropertyName = "sales" : piutang_sales.HeaderText = "Salesman"
                    piutang_custo.Name = "piutang_custo" : piutang_custo.DataPropertyName = "custo" : piutang_custo.HeaderText = "Customer"
                    piutang_jenis.Name = "piutang_jenis" : piutang_jenis.DataPropertyName = "jenisbayar" : piutang_jenis.HeaderText = "Jenis Bayar"
                    piutang_debet.Name = "piutang_debet" : piutang_debet.DataPropertyName = "debet" : piutang_debet.HeaderText = "Jumlah Bayar"
                    piutang_status.Name = "piutang_status" : piutang_status.DataPropertyName = "status" : piutang_status.HeaderText = "Status"
                    piutang_andro.Name = "piutang_andro" : piutang_andro.DataPropertyName = "input_source" : piutang_andro.HeaderText = "Input"
                    piutang_user.Name = "piutang_user" : piutang_user.DataPropertyName = "userid" : piutang_user.HeaderText = "UserID"
                    piutang_it.Name = "piutang_it" : piutang_it.DataPropertyName = "regdate" : piutang_it.HeaderText = "InputDate"
                    piutang_et.Name = "piutang_et" : piutang_et.DataPropertyName = "upddate" : piutang_et.HeaderText = "LastUpdate"

                    piutang_bukti.Width = 100
                    piutang_debet.Width = 120 : piutang_debet.DefaultCellStyle = dgvstyle_currency
                    piutang_sales.Width = 120 : piutang_custo.Width = 200
                    piutang_tgl.Width = 110 : piutang_tgl.DefaultCellStyle = dgvstyle_date
                    For Each col As DataGridViewColumn In {piutang_it, piutang_et}
                        col.Width = 100 : col.DefaultCellStyle = dgvstyle_datetime
                    Next

                    Dim x As DataGridViewColumn() = {piutang_bukti, piutang_tgl, piutang_jenpajak, piutang_custo, piutang_sales, piutang_debet, piutang_jenis,
                                                     piutang_status, piutang_andro, piutang_it, piutang_et, piutang_user, x_filler}
                    For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)
                End With

                'TAB LIST BG DITERIMA
            Case "piutangbgcair"
                With frmpiutangbgcair
                    Dim bg_no = New DataGridViewColumn() : bg_no = dgvcol_templ_status.Clone()
                    Dim bg_tgl = New DataGridViewColumn() : bg_tgl = dgvcol_templ_status.Clone()
                    Dim bg_bank = New DataGridViewColumn() : bg_bank = dgvcol_templ_status.Clone()
                    Dim bg_custo = New DataGridViewColumn() : bg_custo = dgvcol_templ_status.Clone()
                    Dim bg_sales = New DataGridViewColumn() : bg_sales = dgvcol_templ_status.Clone()
                    Dim bg_tglbg = New DataGridViewColumn() : bg_tglbg = dgvcol_templ_status.Clone()
                    Dim bg_jml = New DataGridViewColumn() : bg_jml = dgvcol_templ_numeric.Clone()
                    Dim bg_ref = New DataGridViewColumn() : bg_ref = dgvcol_templ_status.Clone()
                    Dim bg_status = New DataGridViewColumn() : bg_status = dgvcol_templ_status.Clone()
                    Dim bg_tglcair = New DataGridViewColumn() : bg_tglcair = dgvcol_templ_status.Clone()
                    Dim bg_akuncair = New DataGridViewColumn() : bg_akuncair = dgvcol_templ_status.Clone()
                    Dim bg_tgltolak = New DataGridViewColumn() : bg_tgltolak = dgvcol_templ_status.Clone()
                    Dim bg_userid = New DataGridViewColumn() : bg_userid = dgvcol_templ_status.Clone()

                    bg_no.Name = "bg_no" : bg_no.DataPropertyName = "giro_no" : bg_no.HeaderText = "Nomor Giro"
                    bg_tgl.Name = "bg_tgl" : bg_tgl.DataPropertyName = "giro_tglterima" : bg_tgl.HeaderText = "Tanggal Terima"
                    bg_bank.Name = "bg_bank" : bg_bank.DataPropertyName = "giro_bank" : bg_bank.HeaderText = "Bank"
                    bg_custo.Name = "bg_custo" : bg_custo.DataPropertyName = "giro_custo" : bg_custo.HeaderText = "Customer"
                    bg_sales.Name = "bg_sales" : bg_sales.DataPropertyName = "giro_sales" : bg_sales.HeaderText = "Salesman"
                    bg_jml.Name = "bg_tglbg" : bg_jml.DataPropertyName = "giro_nilai" : bg_jml.HeaderText = "Jumlah"
                    bg_tglbg.Name = "bg_tglbg" : bg_tglbg.DataPropertyName = "giro_tglefektif" : bg_tglbg.HeaderText = "Tanggal BG"
                    bg_ref.Name = "bg_ref" : bg_ref.DataPropertyName = "giro_ref" : bg_ref.HeaderText = "Faktur Bayar"
                    bg_status.Name = "bg_status" : bg_status.DataPropertyName = "giro_status" : bg_status.HeaderText = "Status"
                    bg_tglcair.Name = "bg_tglcair" : bg_tglcair.DataPropertyName = "giro_tglcair" : bg_tglcair.HeaderText = "Tanggal Cair"
                    bg_akuncair.Name = "bg_akuncair" : bg_akuncair.DataPropertyName = "giro_akuncair_n" : bg_akuncair.HeaderText = "Di Cairkan ke.."
                    bg_tgltolak.Name = "bg_tgltolak" : bg_tgltolak.DataPropertyName = "giro_tgltolak" : bg_tgltolak.HeaderText = "Tanggal Tolak"
                    bg_userid.Name = "bg_userid" : bg_userid.DataPropertyName = "giro_usercair" : bg_userid.HeaderText = "UserID"

                    bg_no.Width = 100
                    bg_jml.Width = 120 : bg_jml.DefaultCellStyle = dgvstyle_currency
                    For Each x As DataGridViewColumn In {bg_tgl, bg_tglbg, bg_tglcair, bg_tgltolak}
                        x.Width = 110
                        x.DefaultCellStyle = dgvstyle_date
                    Next
                    bg_bank.Width = 150 : bg_sales.Width = 120 : bg_custo.Width = 175
                    bg_akuncair.Width = 125
                    bg_ref.Width = 100

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {bg_no, bg_tgl, bg_bank, bg_custo, bg_sales, bg_tglbg, bg_jml, bg_status, bg_ref,
                                                         bg_tglcair, bg_akuncair, bg_tgltolak, bg_userid, x_filler}
                        For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

                'LIST DATA KAS
            Case "kas"
                With frmkas
                    Dim kas_bank = New DataGridViewColumn : kas_bank = dgvcol_templ_status.Clone()
                    Dim kas_bukti = New DataGridViewColumn : kas_bukti = dgvcol_templ_status.Clone()
                    Dim kas_jenis = New DataGridViewColumn : kas_jenis = dgvcol_templ_status.Clone()
                    Dim kas_tgl = New DataGridViewColumn : kas_tgl = dgvcol_templ_status.Clone()
                    Dim kas_sales = New DataGridViewColumn : kas_sales = dgvcol_templ_status.Clone()
                    Dim kas_debet = New DataGridViewColumn : kas_debet = dgvcol_templ_status.Clone()
                    Dim kas_kredit = New DataGridViewColumn : kas_kredit = dgvcol_templ_status.Clone()
                    Dim kas_user = New DataGridViewColumn : kas_user = dgvcol_templ_status.Clone()
                    Dim kas_status = New DataGridViewColumn : kas_status = dgvcol_templ_status.Clone()

                    kas_bank.Name = "kas_bank" : kas_bank.DataPropertyName = "bank" : kas_bank.HeaderText = "Bank"
                    kas_bukti.Name = "kas_bukti" : kas_bukti.DataPropertyName = "bukti" : kas_bukti.HeaderText = "Kode Bukti"
                    kas_jenis.Name = "kas_jenis" : kas_jenis.DataPropertyName = "jenisbayar" : kas_jenis.HeaderText = "Jenis"
                    kas_tgl.Name = "kas_tgl" : kas_tgl.DataPropertyName = "tanggal" : kas_tgl.HeaderText = "Tanggal"
                    kas_sales.Name = "kas_sales" : kas_sales.DataPropertyName = "sales" : kas_sales.HeaderText = "Salesman"
                    kas_debet.Name = "kas_debet" : kas_debet.DataPropertyName = "debet" : kas_debet.HeaderText = "Debet"
                    kas_kredit.Name = "kas_kredit" : kas_kredit.DataPropertyName = "kredit" : kas_kredit.HeaderText = "Kredit"
                    kas_user.Name = "kas_user" : kas_user.DataPropertyName = "userid" : kas_user.HeaderText = "UserID"
                    kas_status.Name = "kas_status" : kas_status.DataPropertyName = "status" : kas_status.HeaderText = "Status"

                    kas_bank.Width = 150 : kas_bukti.Width = 150 : kas_sales.Width = 120
                    kas_tgl.Width = 100 : kas_tgl.DefaultCellStyle = dgvstyle_date
                    For Each fuk As DataGridViewColumn In {kas_debet, kas_kredit}
                        fuk.Width = 120 : fuk.DefaultCellStyle = dgvstyle_currency
                    Next
                    kas_user.Width = 100

                    Dim x As DataGridViewColumn() = {kas_bank, kas_bukti, kas_jenis, kas_tgl, kas_sales, kas_debet, kas_kredit, kas_user, kas_status, x_filler}
                    For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)

                End With

                'LIST DATA JURNAL UMUM
            Case "jurnalumum"
                With frmjurnalumum
                    Dim jurnal_u_id = New DataGridViewColumn : jurnal_u_id = dgvcol_templ_id.Clone()
                    Dim jurnal_u_jenpajak = New DataGridViewColumn : jurnal_u_jenpajak = dgvcol_templ_id.Clone()
                    Dim jurnal_u_tgl = New DataGridViewColumn : jurnal_u_tgl = dgvcol_templ_status.Clone()
                    Dim jurnal_u_bukti = New DataGridViewColumn : jurnal_u_bukti = dgvcol_templ_status.Clone()
                    Dim jurnal_u_jenis = New DataGridViewColumn : jurnal_u_jenis = dgvcol_templ_status.Clone()
                    Dim jurnal_u_kredit = New DataGridViewColumn : jurnal_u_kredit = dgvcol_templ_status.Clone()
                    Dim jurnal_u_debet = New DataGridViewColumn : jurnal_u_debet = dgvcol_templ_status.Clone()
                    Dim jurnal_u_ref = New DataGridViewColumn : jurnal_u_ref = dgvcol_templ_status.Clone()

                    jurnal_u_id.Name = "jurnal_u_id" : jurnal_u_id.DataPropertyName = "ju_id" : jurnal_u_id.HeaderText = "ID"
                    jurnal_u_jenpajak.Name = "jurnal_u_jenpajak" : jurnal_u_jenpajak.DataPropertyName = "jenispajak" : jurnal_u_jenpajak.HeaderText = "Kat."
                    jurnal_u_tgl.Name = "jurnal_u_tgl" : jurnal_u_tgl.DataPropertyName = "ju_tgl" : jurnal_u_tgl.HeaderText = "Tanggal"
                    jurnal_u_bukti.Name = "jurnal_u_bukti" : jurnal_u_bukti.DataPropertyName = "ju_kode" : jurnal_u_bukti.HeaderText = "Kode Transaksi"
                    jurnal_u_jenis.Name = "jurnal_u_jenis" : jurnal_u_jenis.DataPropertyName = "ju_type" : jurnal_u_jenis.HeaderText = "Jenis"
                    jurnal_u_kredit.Name = "jurnal_u_kredit" : jurnal_u_kredit.DataPropertyName = "kredit" : jurnal_u_kredit.HeaderText = "Kredit"
                    jurnal_u_debet.Name = "jurnal_u_debet" : jurnal_u_debet.DataPropertyName = "debet" : jurnal_u_debet.HeaderText = "Debet"
                    jurnal_u_ref.Name = "jurnal_u_ref" : jurnal_u_ref.DataPropertyName = "ju_ref" : jurnal_u_ref.HeaderText = "Keterangan"

                    jurnal_u_tgl.DefaultCellStyle = dgvstyle_date : jurnal_u_tgl.Width = 100
                    jurnal_u_ref.Width = 350 : jurnal_u_bukti.Width = 150
                    For Each x As DataGridViewColumn In {jurnal_u_debet, jurnal_u_kredit}
                        x.Width = 150 : x.DefaultCellStyle = dgvstyle_currency
                    Next

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {jurnal_u_id, jurnal_u_jenpajak, jurnal_u_tgl, jurnal_u_bukti, jurnal_u_jenis,
                                                          jurnal_u_debet, jurnal_u_kredit, jurnal_u_ref, x_filler}
                        For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

                'LIST DATA JURNAL PENYESUAIAN
            Case "jurnalsesuai"
                With frmjurnalsesuai
                    Dim jurnal_p_id = New DataGridViewColumn : jurnal_p_id = dgvcol_templ_id.Clone()
                    Dim jurnal_p_jenpajak = New DataGridViewColumn : jurnal_p_jenpajak = dgvcol_templ_id.Clone()
                    Dim jurnal_p_tgl = New DataGridViewColumn : jurnal_p_tgl = dgvcol_templ_status.Clone()
                    Dim jurnal_p_bukti = New DataGridViewColumn : jurnal_p_bukti = dgvcol_templ_status.Clone()
                    Dim jurnal_p_kredit = New DataGridViewColumn : jurnal_p_kredit = dgvcol_templ_status.Clone()
                    Dim jurnal_p_debet = New DataGridViewColumn : jurnal_p_debet = dgvcol_templ_status.Clone()
                    Dim jurnal_p_ref = New DataGridViewColumn : jurnal_p_ref = dgvcol_templ_status.Clone()

                    jurnal_p_id.Name = "jurnal_p_id" : jurnal_p_id.DataPropertyName = "jp_id" : jurnal_p_id.HeaderText = "ID"
                    jurnal_p_jenpajak.Name = "jurnal_p_jenpajak" : jurnal_p_jenpajak.DataPropertyName = "jenispajak" : jurnal_p_jenpajak.HeaderText = "Kat."
                    jurnal_p_tgl.Name = "jurnal_p_tgl" : jurnal_p_tgl.DataPropertyName = "jp_tgl" : jurnal_p_tgl.HeaderText = "Tanggal"
                    jurnal_p_bukti.Name = "jurnal_p_bukti" : jurnal_p_bukti.DataPropertyName = "jp_kode" : jurnal_p_bukti.HeaderText = "Kode Transaksi"
                    jurnal_p_kredit.Name = "jurnal_p_kredit" : jurnal_p_kredit.DataPropertyName = "kredit" : jurnal_p_kredit.HeaderText = "Kredit"
                    jurnal_p_debet.Name = "jurnal_p_debet" : jurnal_p_debet.DataPropertyName = "debet" : jurnal_p_debet.HeaderText = "Debet"
                    jurnal_p_ref.Name = "jurnal_p_ref" : jurnal_p_ref.DataPropertyName = "jp_ref" : jurnal_p_ref.HeaderText = "Keterangan"

                    jurnal_p_tgl.DefaultCellStyle = dgvstyle_date : jurnal_p_tgl.Width = 100
                    jurnal_p_ref.Width = 350 : jurnal_p_bukti.Width = 150
                    For Each x As DataGridViewColumn In {jurnal_p_debet, jurnal_p_kredit}
                        x.Width = 150 : x.DefaultCellStyle = dgvstyle_currency
                    Next

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {jurnal_p_id, jurnal_p_jenpajak, jurnal_p_tgl, jurnal_p_bukti,
                                                         jurnal_p_debet, jurnal_p_kredit, jurnal_p_ref, x_filler}
                        For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

                'LIST DATA CLOSING
            Case "tutupbuku"
                With frmtutupbuku
                    Dim cl_id = New DataGridViewColumn : cl_id = dgvcol_templ_id.Clone()
                    Dim cl_tgl = New DataGridViewColumn : cl_tgl = dgvcol_templ_status.Clone()
                    Dim cl_tglawal = New DataGridViewColumn : cl_tglawal = dgvcol_templ_status.Clone()
                    Dim cl_tglakhir = New DataGridViewColumn : cl_tglakhir = dgvcol_templ_status.Clone()
                    Dim cl_userid = New DataGridViewColumn : cl_userid = dgvcol_templ_status.Clone()
                    Dim cl_validid = New DataGridViewColumn : cl_validid = dgvcol_templ_status.Clone()
                    Dim cl_status = New DataGridViewColumn : cl_status = dgvcol_templ_status.Clone()

                    cl_id.Name = "cl_id" : cl_id.DataPropertyName = "cl_id" : cl_id.HeaderText = "ID"
                    cl_tgl.Name = "cl_tgl" : cl_tgl.DataPropertyName = "cl_tgl" : cl_tgl.HeaderText = "Tgl. Closing"
                    cl_tglawal.Name = "cl_tglawal" : cl_tglawal.DataPropertyName = "cl_tglawal" : cl_tglawal.HeaderText = "StartDate"
                    cl_tglakhir.Name = "cl_tglakhir" : cl_tglakhir.DataPropertyName = "cl_tglakhir" : cl_tglakhir.HeaderText = "EndDate"
                    cl_userid.Name = "cl_userid" : cl_userid.DataPropertyName = "cl_userid" : cl_userid.HeaderText = "ClosedBy"
                    cl_validid.Name = "cl_validid" : cl_validid.DataPropertyName = "cl_validid" : cl_validid.HeaderText = "ValidBy"
                    cl_status.Name = "cl_status" : cl_status.DataPropertyName = "cl_status" : cl_status.HeaderText = "Status"

                    For Each col As DataGridViewColumn In {cl_tgl, cl_tglawal, cl_tglakhir}
                        col.Width = 150 : col.DefaultCellStyle = dgvstyle_date
                    Next
                    cl_userid.Width = 100 : cl_validid.Width = 100
                    With .dgv_list
                        Dim x As DataGridViewColumn() = {cl_id, cl_status, cl_tgl, cl_tglawal, cl_tglakhir, cl_validid, cl_userid, x_filler}
                        For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

                'LIST DATA STOCK ADJUSTMENT
            Case "adjstock"
                With frmadjstock
                    Dim adj_id = New DataGridViewColumn : adj_id = dgvcol_templ_id.Clone()
                    Dim adj_kode = New DataGridViewColumn : adj_kode = dgvcol_templ_status.Clone()
                    Dim adj_tgl = New DataGridViewColumn : adj_tgl = dgvcol_templ_status.Clone()
                    Dim adj_brg = New DataGridViewColumn : adj_brg = dgvcol_templ_status.Clone()
                    Dim adj_gdg = New DataGridViewColumn : adj_gdg = dgvcol_templ_status.Clone()
                    Dim adj_qty = New DataGridViewColumn : adj_qty = dgvcol_templ_status.Clone()
                    Dim adj_val = New DataGridViewColumn : adj_val = dgvcol_templ_status.Clone()
                    Dim adj_user = New DataGridViewColumn : adj_user = dgvcol_templ_status.Clone()

                    adj_id.Name = "adj_id" : adj_id.DataPropertyName = "adj_id" : adj_id.HeaderText = "ID" : adj_id.Visible = False
                    adj_kode.Name = "adj_kode" : adj_kode.DataPropertyName = "adj_kode" : adj_kode.HeaderText = "Kode Adjusment"
                    adj_tgl.Name = "adj_tgl" : adj_tgl.DataPropertyName = "adj_tgl" : adj_tgl.HeaderText = "Tanggal"
                    adj_brg.Name = "adj_brg" : adj_brg.DataPropertyName = "adj_brg" : adj_brg.HeaderText = "Barang"
                    adj_gdg.Name = "adj_gdg" : adj_gdg.DataPropertyName = "adj_gdg" : adj_gdg.HeaderText = "Gudang"
                    adj_qty.Name = "adj_qty" : adj_qty.DataPropertyName = "adj_qty" : adj_qty.HeaderText = "Qty Adjust"
                    adj_val.Name = "adj_val" : adj_val.DataPropertyName = "adj_val" : adj_val.HeaderText = "Nilai Adjust"
                    adj_user.Name = "adj_user" : adj_user.DataPropertyName = "adj_user" : adj_user.HeaderText = "UserID"

                    adj_kode.Width = 120 : adj_brg.Width = 150 : adj_gdg.Width = 150
                    adj_tgl.DefaultCellStyle = dgvstyle_date : adj_tgl.Width = 120
                    adj_val.DefaultCellStyle = dgvstyle_currency : adj_val.Width = 100
                    adj_qty.DefaultCellStyle = dgvstyle_commathousand

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {adj_id, adj_kode, adj_brg, adj_gdg, adj_tgl, adj_qty, adj_val, adj_user, x_filler}
                        For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With

                End With

                'LIST DATA USER GROUP
            Case "group"
                With frmgroup
                    Dim group_kode = New DataGridViewColumn : group_kode = dgvcol_templ_status.Clone()
                    Dim group_nama = New DataGridViewColumn : group_nama = dgvcol_templ_status.Clone()
                    Dim group_menu = New DataGridViewColumn : group_menu = dgvcol_templ_status.Clone()
                    Dim group_ket = New DataGridViewColumn : group_ket = dgvcol_templ_status.Clone()
                    Dim group_status = New DataGridViewColumn : group_status = dgvcol_templ_status.Clone()
                    Dim group_it = New DataGridViewColumn : group_it = dgvcol_templ_status.Clone()
                    Dim group_et = New DataGridViewColumn : group_et = dgvcol_templ_status.Clone()
                    Dim group_userid = New DataGridViewColumn : group_userid = dgvcol_templ_status.Clone()

                    group_kode.Name = "group_kode" : group_kode.DataPropertyName = "kode" : group_kode.HeaderText = "Kode Group"
                    group_nama.Name = "group_nama" : group_nama.DataPropertyName = "nama" : group_nama.HeaderText = "Nama Group"
                    group_menu.Name = "group_menu" : group_menu.DataPropertyName = "jml" : group_menu.HeaderText = "Jml.Menu"
                    group_ket.Name = "group_ket" : group_ket.DataPropertyName = "ket" : group_ket.HeaderText = "Keterangan"
                    group_status.Name = "group_status" : group_status.DataPropertyName = "status" : group_status.HeaderText = "Status"
                    group_it.Name = "group_it" : group_it.DataPropertyName = "groupit" : group_it.HeaderText = "IT"
                    group_et.Name = "group_et" : group_et.DataPropertyName = "groupet" : group_et.HeaderText = "ET"
                    group_userid.Name = "group_userid" : group_userid.DataPropertyName = "userid" : group_userid.HeaderText = "UserID"

                    group_nama.Width = 120 : group_ket.Width = 225
                    group_menu.DefaultCellStyle = dgvstyle_commathousand
                    group_userid.Width = 100
                    For Each x As DataGridViewColumn In {group_et, group_it}
                        x.Width = 100 : x.DefaultCellStyle = dgvstyle_datetime
                    Next

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {group_kode, group_nama, group_menu, group_ket, group_status, group_it, group_et, group_userid, x_filler}
                        For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

                'LIST DATA USER
            Case "user"
                With frmuser
                    Dim user_id = New DataGridViewColumn : user_id = dgvcol_templ_status.Clone()
                    Dim user_nama = New DataGridViewColumn : user_nama = dgvcol_templ_status.Clone()
                    Dim user_status = New DataGridViewColumn : user_status = dgvcol_templ_status.Clone()
                    Dim user_group = New DataGridViewColumn : user_group = dgvcol_templ_status.Clone()
                    Dim user_logstat = New DataGridViewColumn : user_logstat = dgvcol_templ_id.Clone()
                    Dim user_lastlogin = New DataGridViewColumn : user_lastlogin = dgvcol_templ_status.Clone()
                    Dim user_android = New DataGridViewColumn : user_android = dgvcol_templ_status.Clone()
                    Dim user_sales = New DataGridViewColumn : user_sales = dgvcol_templ_status.Clone()

                    user_id.Name = "user_id" : user_id.DataPropertyName = "userid" : user_id.HeaderText = "Username"
                    user_nama.Name = "user_nama" : user_nama.DataPropertyName = "nama" : user_nama.HeaderText = "Nama User"
                    user_status.Name = "user_status" : user_status.DataPropertyName = "status" : user_status.HeaderText = "Status"
                    user_group.Name = "user_group" : user_group.DataPropertyName = "groupnama" : user_group.HeaderText = "Group User"
                    user_logstat.Name = "user_logstat" : user_logstat.DataPropertyName = "loginstat" : user_logstat.HeaderText = "Login"
                    user_lastlogin.Name = "user_lastlogin" : user_lastlogin.DataPropertyName = "lastlogin" : user_lastlogin.HeaderText = "Login Terakhir"
                    user_android.Name = "user_android" : user_android.DataPropertyName = "androsales" : user_android.HeaderText = "Akses Android"
                    user_sales.Name = "user_sales" : user_sales.DataPropertyName = "sales" : user_sales.HeaderText = "Salesman"

                    For Each col As DataGridViewColumn In {user_id, user_nama, user_sales}
                        col.Width = 150
                    Next
                    For Each col As DataGridViewColumn In {user_android, user_lastlogin, user_group}
                        col.Width = 100
                    Next
                    user_lastlogin.DefaultCellStyle = dgvstyle_datetime

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {user_id, user_nama, user_status, user_group, user_logstat, user_lastlogin, user_android, user_sales, x_filler}
                        For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With
            Case Else
                Exit Sub
        End Select
    End Sub

    ''' <summary>Getting datatable for listview/gridview data from database using asyncronous procedure.</summary>
    ''' <param name="TypeData">A <see cref="String"/> of type of data requested</param>
    ''' <param name="ParamValue"><see cref="String"/> search parameter/condition. Using REGEXP format with some exception.</param>
    ''' <param name="PageNum"></param>
    ''' <param name="LimitPerPage">Maximum row every page.</param>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <returns><see cref="DataTable"/> of requested data and a <see cref="Boolean"/> key as task complete parameter.</returns>
    Public Async Function GetDataLIstForListTemplate(TypeData As String, ParamValue As String, PageNum As Integer, Optional LimitPerPage As Integer = 2000, Optional StartDate As Date = Nothing, Optional EndDate As Date = Nothing) As Task(Of KeyValuePair(Of Boolean, DataTable))
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim _startdate As Date = IIf(StartDate = #12:00:00 AM#, selectperiode.tglawal, StartDate)
        Dim _enddate As Date = IIf(EndDate = #12:00:00 AM#, selectperiode.tglakhir, EndDate)

        Dim _retval As New DataTable : Dim _retBool As Boolean = False
        Dim q As String = ""

        TypeData = LCase(TypeData)
        ParamValue = mysqlQueryFriendlyStringFeed(ParamValue)
        If Not String.IsNullOrWhiteSpace(ParamValue) Then ParamValue = Trim(ParamValue).Replace(" ", ".+").Replace("(", "[(]").Replace(")", "[)]")

        Select Case TypeData
            Case "supplier", "barang", "sales", "gudang", "custo", "group", "user", "salessetting", "closing"
                q = "CALL GetDataList_Master('{0}','{1}','{2}','{3}')"
                q = String.Format(q, TypeData, Trim(ParamValue), PageNum, LimitPerPage)
            Case "pesanan", "jual", "rjual", "beli", "rbeli"
                q = "CALL GetDataList_Trans('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}','{3}','{4}','{5}')"
                q = String.Format(q, TypeData, _startdate, _enddate, Trim(ParamValue), PageNum, LimitPerPage)
            Case "draftrekap", "drafttagihan"
                q = "CALL GetDataList_Draft('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}','{3}','{4}','{5}')"
                q = String.Format(q, TypeData, _startdate, _enddate, Trim(ParamValue), PageNum, LimitPerPage)
            Case "stok"
                q = "CALL GetDataList_Stok('{0}','{1}','{2}','{3}')"
                q = String.Format(q, selectperiode.id, Trim(ParamValue), PageNum, LimitPerPage)
            Case "mutasistok", "mutasigudang", "mutasiopname", "adjustment"
                q = "CALL GetDataList_MutasiStok('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}','{3}','{4}','{5}')"
                q = String.Format(q, TypeData, _startdate, _enddate, Trim(ParamValue), PageNum, LimitPerPage)
            Case "hutangawal", "hutangbayar", "bgo"
                q = "CALL GetDataList_Hutang('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}','{3}','{4}','{5}')"
                q = String.Format(q, TypeData, _startdate, _enddate, Trim(ParamValue), PageNum, LimitPerPage)
            Case "piutangawal", "piutangbayar", "bgi"
                q = "CALL GetDataList_Piutang('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}','{3}','{4}','{5}')"
                q = String.Format(q, TypeData, _startdate, _enddate, Trim(ParamValue), PageNum, LimitPerPage)
            Case "kas", "jurnalumum", "perkiraan", "jurnalsesuai"
                q = "CALL GetDataList_Akuntan('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}','{3}','{4}','{5}')"
                q = String.Format(q, TypeData, _startdate, _enddate, Trim(ParamValue), PageNum, LimitPerPage)
            Case Else
                Return Nothing : Exit Function
        End Select

        Using x As New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                consoleWriteLine(q)
                _retval = Await Task.Run(Function() x.GetDataTable(q))
                _retBool = True
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing : Exit Function
            End If
        End Using

        Return New KeyValuePair(Of Boolean, DataTable)(_retBool, _retval)
    End Function

    ''' <summary>Getting datacount for listview/gridview paging system from database using asyncronous procedure. 
    ''' Used as compliment for <see cref="GetDataLIstForListTemplate"/> function.</summary>
    ''' <param name="TypeData">A <see cref="String"/> of data type requested</param>
    ''' <param name="ParamValue"><see cref="String"/> of search parameter.</param>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <returns><see cref="Integer"/> value of requested data and a <see cref="Boolean"/> key as task complete parameter.</returns>
    Public Async Function GetDataCount(TypeData As String, Optional ParamValue As String = "",
                                 Optional StartDate As Date = Nothing, Optional EndDate As Date = Nothing) As Task(Of KeyValuePair(Of Boolean, Integer))
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Dim _retval As Integer = 0 : Dim _retBool As Boolean = False
        Dim q As String = ""

        Dim _startdate As Date = IIf(StartDate = #12:00:00 AM#, selectperiode.tglawal, StartDate)
        Dim _enddate As Date = IIf(EndDate = #12:00:00 AM#, selectperiode.tglakhir, EndDate)

        TypeData = LCase(TypeData)
        ParamValue = mysqlQueryFriendlyStringFeed(ParamValue)
        If Not String.IsNullOrWhiteSpace(ParamValue) Then ParamValue = Trim(ParamValue).Replace(" ", ".+").Replace("(", "[(]").Replace(")", "[)]")

        Select Case TypeData
            Case "barang", "gudang", "supplier", "sales", "custo", "group", "user", "salessetting", "closing"
                q = "SELECT GetDataCount_Master('{0}','{1}')"
                q = String.Format(q, TypeData, ParamValue)
            Case "pesanan", "jual", "rjual", "beli", "rbeli"
                q = "SELECT GetDataCount_Trans('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}','{3}')"
                q = String.Format(q, TypeData, _startdate, _enddate, ParamValue)
            Case "draftrekap", "drafttagihan"
                q = "SELECT GetDataCount_Draft('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}','{3}')"
                q = String.Format(q, TypeData, _startdate, _enddate, Trim(ParamValue))
            Case "stok"
                q = "SELECT GetDataCount_Stok('{0}','{1}')"
                q = String.Format(q, selectperiode.id, ParamValue)
            Case "mutasistok", "mutasigudang", "mutasiopname", "adjustment"
                q = "SELECT GetDataCount_MutasiStok('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}','{3}')"
                q = String.Format(q, TypeData, _startdate, _enddate, ParamValue)
            Case "hutangawal", "hutangbayar", "bgo"
                q = "SELECT GetDataCount_Hutang('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}','{3}')"
                q = String.Format(q, TypeData, _startdate, _enddate, ParamValue)
            Case "piutangawal", "piutangbayar", "bgi"
                q = "SELECT GetDataCount_Piutang('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}','{3}')"
                q = String.Format(q, TypeData, _startdate, _enddate, ParamValue)
            Case "kas", "jurnalumum", "perkiraan", "jurnalsesuai"
                q = "SELECT GetDataCount_Akuntan('{0}','{1:yyyy-MM-dd}','{2:yyyy-MM-dd}','{3}')"
                q = String.Format(q, TypeData, _startdate, _enddate, ParamValue)
            Case Else
                Return New KeyValuePair(Of Boolean, Integer)(True, 0)
        End Select

        Using x As New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                _retval = CInt(Await Task.Run(Function() x.ExecScalar(q)))
                _retBool = True
            End If
        End Using

        Return New KeyValuePair(Of Boolean, Integer)(_retBool, _retval)
    End Function
End Module
