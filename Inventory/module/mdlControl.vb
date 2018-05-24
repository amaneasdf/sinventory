Imports System.Reflection

Module mdlControl
    '----------barang_list dgv col----------
    Private barang_kode = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode Barang",
        .Name = "kode",
        .ReadOnly = True
    }
    Private barang_nama = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Nama Barang",
        .Name = "nama",
        .ReadOnly = True,
        .MinimumWidth = 200
    }
    Private barang_kode_supplier = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kodesupplier",
        .HeaderText = "Kode Supplier",
        .Name = "kodesup",
        .ReadOnly = True
    }
    Private barang_jenis = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "jenis",
        .HeaderText = "Jenis",
        .Name = "jenis",
        .ReadOnly = True
    }
    Private barang_satuan_kecil = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "satuankecil",
        .HeaderText = "Satuan Kecil",
        .Name = "sat_kecil",
        .ReadOnly = True
    }
    Private barang_satuan_tengah = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "satuantengah",
        .HeaderText = "Satuan Tengah",
        .Name = "sat_tengah",
        .ReadOnly = True,
        .Width = 110
    }
    Private barang_satuan_tengah_isi = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "satuantengahisi",
        .HeaderText = "Isi Tengah",
        .Name = "isi_tengah",
        .ReadOnly = True
    }
    Private barang_satuan_besar = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "satuanbesar",
        .HeaderText = "Satuan Besar",
        .Name = "sat_besar",
        .ReadOnly = True
    }
    Private barang_satuan_besar_isi = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "satuanbesarisi",
        .HeaderText = "Isi Besar",
        .Name = "isi_besar",
        .ReadOnly = True
    }
    Private barang_harga_beli = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "hargabeli",
        .HeaderText = "Harga Beli",
        .Name = "harga_beli",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_currency,
        .MinimumWidth = 100
    }
    Private barang_harga_jual = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "hargajual",
        .HeaderText = "Harga Jual",
        .Name = "harga_jual",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_currency,
        .MinimumWidth = 100
    }
    Private barang_jenis_pajak = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "jenispajak",
        .HeaderText = "Jenis Pajak",
        .Name = "jenispajak",
        .ReadOnly = True
    }

    '----------supplier_list dgv col---------
    Private supplier_kode = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode Supplier",
        .Name = "kode",
        .ReadOnly = True
    }
    Private supplier_nama = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Nama Supplier",
        .Name = "nama",
        .ReadOnly = True,
        .MinimumWidth = 250
    }
    Private supplier_alamat = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "alamat",
        .HeaderText = "Alamat",
        .Name = "alamat",
        .ReadOnly = True,
        .MinimumWidth = 500
    }
    Private supplier_telp = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "telp",
        .HeaderText = "Telp",
        .Name = "telp",
        .ReadOnly = True,
        .MinimumWidth = 150
    }
    Private supplier_fax = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "fax",
        .HeaderText = "Fax",
        .Name = "fax",
        .ReadOnly = True,
        .MinimumWidth = 150
    }
    Private supplier_cp = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "cp",
        .HeaderText = "Contact Person",
        .Name = "cp",
        .ReadOnly = True,
        .MinimumWidth = 250
    }
    Private supplier_term = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "term",
        .HeaderText = "Term",
        .Name = "term",
        .ReadOnly = True
    }
    Private supplier_npwp = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "npwp",
        .HeaderText = "NPWP",
        .Name = "npwp",
        .ReadOnly = True,
        .MinimumWidth = 100
    }

    '----------gudang_list dgv col----------
    Private gudang_kode = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode Gudang",
        .Name = "kode",
        .ReadOnly = True
    }
    Private gudang_nama = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Nama Gudang",
        .Name = "nama",
        .ReadOnly = True,
        .MinimumWidth = 250
    }
    Private gudang_alamat = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "alamat",
        .HeaderText = "Alamat",
        .Name = "alamat",
        .ReadOnly = True,
        .MinimumWidth = 500
    }
    Private gudang_status = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "status",
        .HeaderText = "Status",
        .Name = "status",
        .ReadOnly = True
    }

    '----------sales_list dgv col----------
    Private sales_kode = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode",
        .Name = "kode",
        .ReadOnly = True
    }
    Private sales_nama = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Nama Salesman",
        .Name = "nama",
        .ReadOnly = True,
        .MinimumWidth = 250
    }
    Private sales_alamat = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "alamat",
        .HeaderText = "Alamat",
        .Name = "alamat",
        .ReadOnly = True,
        .MinimumWidth = 500
    }
    Private sales_telp = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "telp",
        .HeaderText = "Telp",
        .Name = "telp",
        .ReadOnly = True,
        .MinimumWidth = 200
    }
    Private sales_target = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "target",
        .HeaderText = "Target",
        .Name = "target",
        .ReadOnly = True,
        .MinimumWidth = 150,
        .DefaultCellStyle = dgvstyle_currency
    }
    Private sales_tglmasuk = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tglmasuk",
        .HeaderText = "Tanggal Masuk",
        .Name = "tglmasuk",
        .ReadOnly = True,
        .MinimumWidth = 175
    }
    Private sales_status = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "status",
        .HeaderText = "Status",
        .Name = "status",
        .ReadOnly = True
    }

    '----------customer_list dgv col-----------------
    Private custo_kode = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode",
        .Name = "kode",
        .ReadOnly = True
    }
    Private custo_nama = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Nama Customer",
        .Name = "nama",
        .ReadOnly = True,
        .MinimumWidth = 250
    }
    Private custo_type = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tipe",
        .HeaderText = "Tipe",
        .Name = "tipe",
        .ReadOnly = True
    }
    Private custo_status = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "status",
        .HeaderText = "Aktif",
        .Name = "status",
        .ReadOnly = True
    }
    Private custo_alamat = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
       .DataPropertyName = "alamat",
       .HeaderText = "Alamat",
       .Name = "alamat",
       .ReadOnly = True,
       .MinimumWidth = 300
    }
    Private custo_alamat_kec = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
       .DataPropertyName = "kec",
       .HeaderText = "Kecamatan",
       .Name = "kec",
       .ReadOnly = True
    }
    Private custo_alamat_kab = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
       .DataPropertyName = "kab",
       .HeaderText = "Kabupaten",
       .Name = "kab",
       .ReadOnly = True
    }
    Private custo_alamat_pasar = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
       .DataPropertyName = "pasar",
       .HeaderText = "Pasar",
       .Name = "pasar",
       .ReadOnly = True
    }
    Private custo_telp = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "telp",
        .HeaderText = "Telp",
        .Name = "telp",
        .ReadOnly = True,
        .MinimumWidth = 100
    }
    Private custo_fax = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "fax",
        .HeaderText = "Fax",
        .Name = "fax",
        .ReadOnly = True,
        .MinimumWidth = 100
    }
    Private custo_term = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "term",
        .HeaderText = "Term",
        .Name = "term",
        .ReadOnly = True
    }
    Private custo_npwp = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "npwp",
        .HeaderText = "NPWP",
        .Name = "npwp",
        .ReadOnly = True,
        .MinimumWidth = 100
    }
    Private custo_nik = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nik",
        .HeaderText = "NIK",
        .Name = "nik",
        .ReadOnly = True,
        .MinimumWidth = 100
    }

    '----------bank_list dgv col-----------------
    Private bank_kode = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode",
        .Name = "kode",
        .ReadOnly = True
    }

    '----------giro_list dgv col-----------------
    Private giro_kode = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode",
        .Name = "kode",
        .ReadOnly = True
    }
    Private giro_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tgl",
        .HeaderText = "Tanggal",
        .Name = "tgl",
        .ReadOnly = True,
        .MinimumWidth = 175
    }
    Private giro_sales = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "sales",
        .HeaderText = "Sales",
        .Name = "sales",
        .ReadOnly = True,
        .MinimumWidth = 150
    }
    Private giro_custo = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "custo",
        .HeaderText = "Customer",
        .Name = "custo",
        .ReadOnly = True,
        .MinimumWidth = 150
    }
    Private giro_nobg = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nobg",
        .HeaderText = "No. BG",
        .Name = "nobg",
        .ReadOnly = True,
        .MinimumWidth = 175
    }
    Private giro_bank = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "bank",
        .HeaderText = "Bank",
        .Name = "bank",
        .ReadOnly = True
    }
    Private giro_jml = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "jml",
        .HeaderText = "Jumlah",
        .Name = "jml",
        .ReadOnly = True,
        .MinimumWidth = 200,
        .DefaultCellStyle = dgvstyle_currency
    }
    Private giro_tgl_bg = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tglbg",
        .HeaderText = "Tanggal BG",
        .Name = "tglbg",
        .ReadOnly = True,
        .MinimumWidth = 175
    }

    '----------perkiraan_list dgv col----------------------
    Private perkiraan_kode = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode",
        .Name = "kode",
        .ReadOnly = True
    }
    Private perkiraan_parent = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "parent",
        .HeaderText = "Parent",
        .Name = "parent",
        .ReadOnly = True
    }
    Private perkiraan_nama = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Nama Perkiraan",
        .Name = "nama",
        .ReadOnly = True,
        .MinimumWidth = 250
    }
    Private perkiraan_posisi = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "posisi",
        .HeaderText = "Posisi D/K",
        .Name = "posisi",
        .ReadOnly = True
    }
    Private perkiraan_ket = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "ket",
        .HeaderText = "Keterangan",
        .Name = "ket",
        .ReadOnly = True,
        .MinimumWidth = 500
    }

    '----------neracaawal_list dgv col----------------------
    Private neracaawal_kode = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
       .DataPropertyName = "kode",
       .HeaderText = "Kode",
       .Name = "kode",
       .ReadOnly = True
   }
    Private neracaawal_parent = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "parent",
        .HeaderText = "Parent",
        .Name = "parent",
        .ReadOnly = True
    }
    Private neracaawal_nama = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Nama Perkiraan",
        .Name = "nama",
        .ReadOnly = True,
        .MinimumWidth = 250
    }
    Private neracaawal_posisi = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "posisi",
        .HeaderText = "Posisi D/K",
        .Name = "posisi",
        .ReadOnly = True
    }
    Private neracaawal_saldo = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "saldo",
        .HeaderText = "Saldo",
        .Name = "saldo",
        .ReadOnly = True,
        .MinimumWidth = 200,
        .DefaultCellStyle = dgvstyle_currency
    }
    Private neracaawal_ket = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "ket",
        .HeaderText = "Keterangan",
        .Name = "ket",
        .ReadOnly = True,
        .MinimumWidth = 500
    }

    '----------beli_list dgv col-------------------
    Private beli_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "faktur",
        .HeaderText = "No. Faktur",
        .Name = "faktur",
        .ReadOnly = True
    }
    Private beli_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tanggal",
        .HeaderText = "Tanggal",
        .Name = "tanggal",
        .ReadOnly = True
    }
    Private beli_gudang = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "gudang",
        .HeaderText = "Gudang",
        .Name = "gudang",
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private beli_supplier = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "supplier",
        .HeaderText = "Supplier",
        .Name = "supplier",
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private beli_pajak = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "pajak",
        .HeaderText = "Faktur Pajak",
        .Name = "pajak",
        .ReadOnly = True
    }
    Private beli_netto = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "netto",
        .HeaderText = "Netto",
        .Name = "netto",
        .DefaultCellStyle = dgvstyle_currency,
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private beli_klaim = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "klaim",
        .HeaderText = "Klaim",
        .Name = "klaim",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_currency
    }
    Private beli_total = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "total",
        .HeaderText = "Sisa Klaim",
        .Name = "total",
        .DefaultCellStyle = dgvstyle_currency,
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private beli_term = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "term",
        .HeaderText = "Term",
        .Name = "term",
        .ReadOnly = True
    }

    '----------retur_beli_list dgv col-------------------
    Private retur_beli_bukti = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "bukti",
        .HeaderText = "No. Bukti",
        .Name = "bukti",
        .ReadOnly = True
    }
    Private retur_beli_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tanggal",
        .HeaderText = "Tanggal",
        .Name = "tanggal",
        .ReadOnly = True
    }
    Private retur_beli_gudang = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "gudang",
        .HeaderText = "Gudang",
        .Name = "gudang",
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private retur_beli_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
       .DataPropertyName = "faktur",
       .HeaderText = "No. Faktur",
       .Name = "faktur",
       .ReadOnly = True
   }
    Private retur_beli_supplier = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "supplier",
        .HeaderText = "Supplier",
        .Name = "supplier",
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
    Private jual_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "faktur",
        .HeaderText = "No. Faktur",
        .Name = "faktur",
        .ReadOnly = True
    }
    Private jual_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tanggal",
        .HeaderText = "Tanggal",
        .Name = "tanggal",
        .ReadOnly = True
    }
    Private jual_gudang = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "gudang",
        .HeaderText = "Gudang",
        .Name = "gudang",
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private jual_custo = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "custo",
        .HeaderText = "Customer",
        .Name = "custo",
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private jual_sales = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "sales",
        .HeaderText = "Salesman",
        .Name = "sales",
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private jual_pajak = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "pajak",
        .HeaderText = "Faktur Pajak",
        .Name = "pajak",
        .ReadOnly = True
    }
    Private jual_netto = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "netto",
        .HeaderText = "Netto",
        .Name = "netto",
        .DefaultCellStyle = dgvstyle_currency,
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private jual_klaim = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "klaim",
        .HeaderText = "Klaim",
        .Name = "klaim",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_currency
    }
    Private jual_total = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "total",
        .HeaderText = "Sisa Klaim",
        .Name = "total",
        .DefaultCellStyle = dgvstyle_currency,
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private jual_term = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "term",
        .HeaderText = "Term",
        .Name = "term",
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
    Private retur_jual_gudang = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "gudang",
        .HeaderText = "Gudang",
        .Name = "gudang",
        .MinimumWidth = 200,
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
        .ReadOnly = True
    }
    Private stok_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tanggal",
        .HeaderText = "Tanggal",
        .Name = "tanggal",
        .ReadOnly = True
    }
    Private stok_gudang = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "gudang",
        .HeaderText = "Gudang",
        .Name = "gudang",
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private stok_barang = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "barang",
        .HeaderText = "Barang",
        .Name = "barang",
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private stok_hpp = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "hpp",
        .HeaderText = "HPP",
        .Name = "hpp",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_currency
    }
    Private stok_awal = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "awal",
        .HeaderText = "Stok Awal",
        .Name = "awal",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_beli = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "beli",
        .HeaderText = "Beli",
        .Name = "beli",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_jual = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "jual",
        .HeaderText = "Jual",
        .Name = "jual",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_rbeli = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "rbeli",
        .HeaderText = "Retur jual",
        .Name = "rjual",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_rjual = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "rjual",
        .HeaderText = "Retur Jual",
        .Name = "jual",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_in = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "masuk",
        .HeaderText = "Masuk",
        .Name = "in",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_out = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "keluar",
        .HeaderText = "Keluar",
        .Name = "out",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_total = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "total",
        .HeaderText = "Sisa",
        .Name = "total",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_opname = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "op",
        .HeaderText = "Opname Fisik",
        .Name = "op",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_commathousand
    }
    Private stok_status = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "status",
        .HeaderText = "Status",
        .Name = "status",
        .ReadOnly = True
    }

    '----------stok_mutasi dgv col-------------------
    Private mutasi_id = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "No. Bukti",
        .Name = "kode",
        .ReadOnly = True
    }
    Private mutasi_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tanggal",
        .HeaderText = "Tanggal",
        .Name = "tanggal",
        .ReadOnly = True
    }
    Private mutasi_gudang_asal = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "gudang",
        .HeaderText = "Gudang Asal",
        .Name = "gudang",
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private mutasi_gudang_tujuan = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "gudang2",
        .HeaderText = "Gudang Tujuan",
        .Name = "gudang2",
        .MinimumWidth = 200,
        .ReadOnly = True
    }


    '----------group_list dgv col----------------------
    Private group_kode = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode Group",
        .Name = "kode",
        .ReadOnly = True
    }
    Private group_nama = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Nama Group",
        .Name = "nama", .ReadOnly = True,
        .MinimumWidth = 250
    }
    Private group_jmlmenu = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "jml",
        .HeaderText = "Jumlah Menu",
        .Name = "jml",
        .ReadOnly = True
    }
    Private group_ket = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "ket",
        .HeaderText = "Keterangan",
        .Name = "ket",
        .ReadOnly = True,
        .MinimumWidth = 500
    }

    '----------user_list dgv col------------------------------
    Private user_kode = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode User",
        .Name = "kode",
        .ReadOnly = True
    }
    Private user_id = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "userid",
        .HeaderText = "UserID",
        .Name = "userid",
        .ReadOnly = True,
        .MinimumWidth = 170
    }
    Private user_nama = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Nama User",
        .Name = "nama",
        .ReadOnly = True,
        .MinimumWidth = 250
    }
    Private user_group = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "groupkode",
        .HeaderText = "Group Kode",
        .Name = "groupkode",
        .ReadOnly = True,
        .Visible = False
    }
    Private user_group_nama = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "groupnama",
        .HeaderText = "Nama Group",
        .Name = "groupnama",
        .ReadOnly = True,
        .MinimumWidth = 200
    }
    Private user_status = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "status",
        .HeaderText = "Status user",
        .Name = "userstatus",
        .ReadOnly = True,
        .Visible = False
    }
    Private user_logstat = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "loginstat",
        .HeaderText = "Login Status",
        .Name = "loginstats",
        .ReadOnly = True
    }

    '----------jenisbarang_list dgv col------------
    Private jenisbarang_kode = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode Jenis",
        .Name = "kode",
        .ReadOnly = True
    }
    Private jenisbarang_nama = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Jenis",
        .Name = "nama",
        .ReadOnly = True,
        .MinimumWidth = 200
    }
    Private jenisbarang_ket = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "ket",
        .HeaderText = "Keterangan",
        .Name = "ket",
        .ReadOnly = True,
        .MinimumWidth = 500
    }

    '----------satuanbarang_list dgv col------------
    Private satuanbarang_kode = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode Satuan",
        .Name = "kode",
        .ReadOnly = True
    }
    Private satuanbarang_nama = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Nama",
        .Name = "nama",
        .ReadOnly = True,
        .MinimumWidth = 200
    }
    Private satuanbarang_ket = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "ket",
        .HeaderText = "Keterangan",
        .Name = "ket",
        .ReadOnly = True,
        .MinimumWidth = 500
    }

    Public Sub setList(type As String)
        Select Case type
            Case "barang"
                setListcodetemp(pgbarang, type, frmbarang, "Daftar Barang")
            Case "supplier"
                setListcodetemp(pgsupplier, type, frmsupplier, "Daftar Supplier")
            Case "gudang"
                setListcodetemp(pggudang, type, frmgudang, "Daftar Gudang")
            Case "sales"
                setListcodetemp(pgsales, type, frmsales, "Daftar Salesman")
            Case "custo"
                setListcodetemp(pgcusto, type, frmcusto, "Daftar Customer")
            Case "bank"
                setListcodetemp(pgbank, type, frmbank, "Daftar Bank")
            Case "giro"
                setListcodetemp(pgbgtangan, type, frmbgditangan, "Daftar BG Di Tangan")
            Case "perkiraan"
                setListcodetemp(pgperkiraan, type, frmperkiraan, "Daftar Perkiraan")
            Case "neracawal"
                setListcodetemp(pgawalneraca, type, frmawalneraca, "Daftar Neraca Awal / Migrasi")
            Case "beli"
                setListcodetemp(pgpembelian, type, frmpembelian, "Daftar Data Pembelian")
            Case "returbeli"
                setListcodetemp(pgreturbeli, type, frmreturbeli, "Daftar Data Retur Pembelian")
            Case "jual"
                setListcodetemp(pgpenjualan, type, frmpenjualan, "Daftar Data Penjualan")
            Case "returjual"
                setListcodetemp(pgreturjual, type, frmreturjual, "Daftar Data Retur Penjualan")
            Case "stok"
                setListcodetemp(pgstok, type, frmstok, "Daftar Stok Barang")
            Case "mutasigurang"
                setListcodetemp(pgmutasigudang, type, frmmutasigudang, "Daftar Mutasi Antar Gudang")
            Case "group"
                setListcodetemp(pggroup, type, frmgroup, "Daftar Group User Level")
            Case "user"
                setListcodetemp(pguser, type, frmuser, "Daftar User")
                'Case "jenisbarang"
                '    setListcodetemp(pgjenisbarang, type, frmjenisbarang, "Referensi/Daftar Jenis Barang")
                'Case "satuanbarang"
                '    setListcodetemp(pgsatuanbarang, type, frmsatuanbarang, "Referensi/Daftar Satuan Barang")
        End Select
    End Sub

    Public Sub setListcodetemp(tbpg As Object, type As String, frm As fr_list_temp, text As String)
        frm.dgv_list.Columns.Clear()
        setDoubleBuffered(frm.dgv_list, True)
        addColtoDGV(type)
        populateDGVUserCon(type, "", frm.dgv_list)
        Console.WriteLine(tbpg.Name.ToString & "listcode")
        With frm
            .bt_export.Visible = False
            .lbl_judul.Text = text
            .setpage(tbpg)
        End With
    End Sub

    Private Sub setDoubleBuffered(dgv As DataGridView, x As Boolean)
        Dim type As Type = dgv.[GetType]()
        Dim PI As PropertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        PI.SetValue(dgv, True, Nothing)
        Console.WriteLine("SET")
    End Sub

    Private Sub addColtoDGV(type As String)
        Select Case type
            Case "barang"
                With frmbarang.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {barang_kode, barang_nama, barang_jenis, barang_kode_supplier, barang_satuan_kecil, barang_satuan_tengah, barang_satuan_tengah_isi, barang_satuan_besar, barang_satuan_besar_isi, barang_harga_beli, barang_harga_jual, barang_jenis_pajak})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "supplier"
                With frmsupplier.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {supplier_kode, supplier_nama, supplier_alamat, supplier_telp, supplier_fax, supplier_cp, supplier_term, supplier_npwp})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "gudang"
                With frmgudang.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {gudang_kode, gudang_nama, gudang_alamat, gudang_status})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "sales"
                With frmsales.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {sales_kode, sales_nama, sales_alamat, sales_telp, sales_target, sales_tglmasuk, sales_status})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "custo"
                With frmcusto.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {custo_kode, custo_nama, custo_type, custo_status, custo_alamat, custo_alamat_kec, custo_alamat_kab, custo_alamat_pasar, custo_telp, custo_fax, custo_term, custo_npwp, custo_nik})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "bank"
                With frmbgditangan.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {bank_kode})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "giro"
                With frmbgditangan.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {giro_kode, giro_nobg, giro_tgl, giro_sales, giro_custo, giro_jml, giro_bank, giro_tgl_bg})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "perkiraan"
                With frmperkiraan.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {perkiraan_kode, perkiraan_parent, perkiraan_nama, perkiraan_posisi, perkiraan_ket})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "neracaawal"
                With frmperkiraan.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {neracaawal_kode, neracaawal_parent, neracaawal_nama, neracaawal_posisi, neracaawal_saldo, neracaawal_ket})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "beli"
                With frmpembelian.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {beli_faktur, beli_tgl, beli_supplier, beli_gudang, beli_pajak, beli_netto, beli_klaim, beli_total, beli_term})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "returbeli"
                With frmreturbeli.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {retur_beli_bukti, retur_beli_faktur, retur_beli_tgl, retur_beli_supplier, retur_beli_gudang, retur_beli_jml})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "jual"
                With frmpenjualan.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {jual_faktur, jual_tgl, jual_custo, jual_sales, jual_gudang, jual_pajak, jual_netto, jual_klaim, jual_total, jual_term})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "returjual"
                With frmreturjual.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {retur_jual_bukti, retur_jual_faktur, retur_jual_tgl, retur_jual_sales, retur_jual_custo, retur_beli_gudang, retur_beli_jml})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "stok"
                With frmstok.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {stok_id, stok_gudang, stok_barang, stok_hpp, stok_awal, stok_beli, stok_jual, stok_rbeli, stok_rjual, stok_in, stok_out, stok_total, stok_opname})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "mutasigudang"
                With frmmutasigudang.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {mutasi_id, mutasi_tgl, mutasi_gudang_asal, mutasi_gudang_tujuan})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "group"
                With frmgroup.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {group_kode, group_nama, group_jmlmenu, group_ket})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "user"
                With frmuser.dgv_list
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {user_kode, user_id, user_nama, user_group, user_group_nama, user_logstat, user_status})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
                'Case "jenisbarang"
                '    With frmjenisbarang.dgv_list
                '        .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {jenisbarang_kode, jenisbarang_nama, jenisbarang_ket})
                '        For i = 0 To .Columns.Count - 1
                '            .Columns(i).DisplayIndex = i
                '        Next
                '    End With
                'Case "satuanbarang"
                '    With frmsatuanbarang.dgv_list
                '        .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {satuanbarang_kode, satuanbarang_nama, satuanbarang_ket})
                '        For i = 0 To .Columns.Count - 1
                '            .Columns(i).DisplayIndex = i
                '        Next
                '    End With
            Case Else
                Exit Sub
        End Select
    End Sub

    Public Sub populateDGVUserCon(type As String, param As String, dgv As DataGridView)
        Dim bs As New BindingSource
        Select Case type
            Case "barang"
                bs.DataSource = getDataTablefromDB("getBarang")
                Console.WriteLine("bs" & bs.Count.ToString)
                bs.Filter = "nama LIKE '%" & param & "%' OR kode LIKE '%" & param & "%' OR kodesupplier LIKE '%" & param & "%'"
            Case "gudang"
                bs.DataSource = getDataTablefromDB("getGudang")
                Console.WriteLine("bs" & bs.Count.ToString)
                bs.Filter = "nama LIKE '%" & param & "%' OR kode LIKE '%" & param & "%'"
            Case "supplier"
                bs = populateDGVUserConTemp("getSupplier", "nama LIKE '%" & param & "%' OR kode LIKE '%" & param & "%'")
            Case "sales"
                bs = populateDGVUserConTemp("getSales", "nama LIKE '%" & param & "%' OR kode LIKE '%" & param & "%'")
            Case "custo"
                bs = populateDGVUserConTemp("getCusto", "nama LIKE '%" & param & "%' OR kode LIKE '%" & param & "%'")
            Case "giro"
                bs = populateDGVUserConTemp("getGiro", "sales LIKE '%" & param & "%' OR custo LIKE '%" & param & "%' OR nobg LIKE '%" & param & "%'")
            Case "perkiraan"
                bs = populateDGVUserConTemp("getPerkiraan", "kode LIKE '%" & param & "%' OR nama LIKE '%" & param & "%'")
            Case "neracaawal"
                bs = populateDGVUserConTemp("getNeracaAwal", "kode LIKE '%" & param & "%' OR nama LIKE '%" & param & "%'")
            Case "beli"
                bs = populateDGVUserConTemp("getBeli", "faktur LIKE '%" & param & "%' OR supplier LIKE '%" & param & "%'")
            Case "returbeli"
                bs = populateDGVUserConTemp("getReturBeli", "faktur LIKE '%" & param & "%' OR supplier LIKE '%" & param & "%' OR bukti LIKE '%" & param & "%'")
            Case "jual"
                bs = populateDGVUserConTemp("getJual", "faktur LIKE '%" & param & "%' OR sales LIKE '%" & param & "%' OR custo LIKE '%" & param & "%'")
            Case "returjual"
                bs = populateDGVUserConTemp("getReturJual", "faktur LIKE '%" & param & "%' OR sales LIKE '%" & param & "%' OR custo LIKE '%" & param & "%' OR bukti LIKE '%" & param & "%'")
            Case "stok"
                bs = populateDGVUserConTemp("getStok", "gudang LIKE '%" & param & "%' OR barang LIKE '%" & param & "%'")
            Case "mutasigudang"
                bs = populateDGVUserConTemp("getMutasi", "gudang LIKE '%" & param & "%' OR kode LIKE '%" & param & "%' OR gudang2 LIKE '%" & param & "%'")
            Case "group"
                bs = populateDGVUserConTemp("getUserGroup", "nama LIKE '%" & param & "%'")
            Case "user"
                bs = populateDGVUserConTemp("getUser", "nama LIKE '%" & param & "%' or userid LIKE '%" & param & "%'")
                'Case "jenisbarang"
                '    bs = populateDGVUserConTemp("getJenisBarang", "nama LIKE '%" & param & "%'")
                'Case "satuanbarang"
                '    bs = populateDGVUserConTemp("getSatuanBarang", "nama LIKE '%" & param & "%' OR kode LIKE '%" & param & "%'")
            Case Else
                Exit Sub
        End Select
        With dgv
            .RowHeadersWidth = 20
            .DataSource = bs
            Console.WriteLine("dgv" & .RowCount)
        End With
    End Sub

    Private Function populateDGVUserConTemp(query As String, paramQuery As String) As BindingSource
        Dim bs As New BindingSource
        bs.DataSource = getDataTablefromDB(query)
        Console.WriteLine("bs" & bs.Count.ToString)
        bs.Filter = paramQuery
        Return bs
    End Function

    Public Sub keyshortcut(tipe As String, tabpage As String)
        Console.WriteLine(tipe & tabpage)
        Dim frm As fr_list_temp

        Select Case tabpage
            Case "pgbarang"
                frm = frmbarang
            Case "pgsupplier"
                frm = frmsupplier
            Case "pggudang"
                frm = frmgudang
            Case "pgsales"
                frm = frmsales
            Case "pgcusto"
                frm = frmcusto
            Case "pgbank"
                frm = frmbank
            Case "pgbgtangan"
                frm = frmbgditangan
            Case "pgperkiraan"
                frm = frmperkiraan
            Case "pgawalneraca"
                frm = frmawalneraca
            Case "pgpembelian"
                frm = frmpembelian
            Case "pgreturbeli"
                frm = frmreturbeli
            Case "pgpenjualan"
                frm = frmpenjualan
            Case "pgreturjual"
                frm = frmreturjual
            Case "pgstok"
                frm = frmstok
            Case "pgstok"
                frm = frmmutasigudang
                'Case "pgjenisbarang"
                '    frm = frmjenisbarang
                'Case "pgsatuanbarang"
                '    frm = frmsatuanbarang
            Case "pguser"
                frm = frmuser
            Case "pggroup"
                frm = frmgroup
            Case Else
                Exit Sub
        End Select

        Select Case tipe
            Case "cari"
                keyshortCari(frm)
            Case "tambah"
                keyshortTambah(frm)
            Case "edit"
                keyshortEdit(frm)
            Case "hapus"
                keyshortHapus(frm)
            Case "refresh"
                keyshortRefresh(frm)
            Case "close"
                keyshortClose(frm)
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub keyshortCari(frm As fr_list_temp)
        frm.in_cari.Focus()
    End Sub

    Private Sub keyshortTambah(frm As fr_list_temp)
        frm.bt_tambah.PerformClick()
    End Sub

    Private Sub keyshortEdit(frm As fr_list_temp)
        frm.bt_edit.PerformClick()
    End Sub

    Private Sub keyshortHapus(frm As fr_list_temp)
        frm.bt_hapus.PerformClick()
    End Sub

    Private Sub keyshortRefresh(frm As fr_list_temp)
        frm.bt_refresh.PerformClick()
    End Sub

    Private Sub keyshortClose(frm As fr_list_temp)
        frm.bt_close.PerformClick()
    End Sub
End Module
