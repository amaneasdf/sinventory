﻿Imports System.Reflection

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
        .Width = 200
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
        .ValueType = GetType(System.String),
        .Width = 110
    }
    Private barang_satuan_besar = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "satuanbesar",
        .HeaderText = "Satuan Besar",
        .Name = "sat_besar",
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
    Private barang_harga_mt = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "hargamt",
        .HeaderText = "Harga MT",
        .Name = "barang_harga_mt",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_currency,
        .MinimumWidth = 100
    }
    Private barang_harga_horeka = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "hargahoreka",
        .HeaderText = "Harga Horeka",
        .Name = "barang_harga_horeka",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_currency,
        .MinimumWidth = 100
    }
    Private barang_harga_rita = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "hargarita",
        .HeaderText = "Harga Rita",
        .Name = "barang_harga_rita",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_currency,
        .MinimumWidth = 100
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
        .MinimumWidth = 200
    }
    Private supplier_alamat = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "alamat",
        .HeaderText = "Alamat",
        .Name = "alamat",
        .DefaultCellStyle = dgvstyle_multiline,
        .ReadOnly = True,
        .MinimumWidth = 250
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
        .ReadOnly = True,
        .Width = 50
    }
    Private supplier_npwp = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "npwp",
        .HeaderText = "NPWP",
        .Name = "npwp",
        .ReadOnly = True,
        .MinimumWidth = 200
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
        .HeaderText = "Tanggal Terima",
        .Name = "tgl",
        .ReadOnly = True,
        .Width = 100
    }
    Private giro_sales = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "sales",
        .HeaderText = "Sales",
        .Name = "sales",
        .ReadOnly = True,
        .MinimumWidth = 175
    }
    Private giro_custo = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "custo",
        .HeaderText = "Customer",
        .Name = "custo",
        .ReadOnly = True,
        .MinimumWidth = 175
    }
    Private giro_nobg = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nobg",
        .HeaderText = "No. BG",
        .Name = "nobg",
        .ReadOnly = True,
        .Width = 100
    }
    Private giro_bank = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "bank",
        .HeaderText = "Bank",
        .Name = "bank",
        .ReadOnly = True,
        .Width = 225
    }
    Private giro_jml = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "jml",
        .HeaderText = "Jumlah",
        .Name = "jml",
        .ReadOnly = True,
        .Width = 120,
        .DefaultCellStyle = dgvstyle_currency
    }
    Private giro_tgl_bg = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tglbg",
        .HeaderText = "Tanggal BG",
        .Name = "tglbg",
        .ReadOnly = True,
        .MinimumWidth = 100
    }

    '----------perkiraan_list dgv col----------------------
    Private perkiraan_kode = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode",
        .Name = "kode",
        .ReadOnly = True
    }
    Private perkiraan_jenis = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "jenis",
        .HeaderText = "Jenis",
        .Name = "jenis",
        .ReadOnly = True
    }
    Private perkiraan_gol = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "gol",
        .HeaderText = "Golongan",
        .Name = "gol",
        .ReadOnly = True
    }
    Private perkiraan_subgol = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "subgol",
        .HeaderText = "Sub Golongan",
        .Name = "subgol",
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
        .Width = 75,
        .ReadOnly = True
    }
    Private perkiraan_awal = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "saldo_awal",
        .HeaderText = "Saldo Awal Periode",
        .Name = "saldoawal",
        .ReadOnly = True,
        .Width = 125,
        .DefaultCellStyle = dgvstyle_currency
    }

    '----------neracaawal_list dgv col----------------------
    Private neraca_awal = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "neracaawal",
        .HeaderText = "Saldo Awal",
        .Name = "neraca_awal",
        .ReadOnly = True,
        .MinimumWidth = 150,
        .DefaultCellStyle = dgvstyle_currency
    }
    Private neraca_mem_debet = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "neracamemdebet",
        .HeaderText = "Memorial Debet",
        .Name = "neraca_mem_debet",
        .ReadOnly = True,
        .MinimumWidth = 150,
        .DefaultCellStyle = dgvstyle_currency
    }
    Private neraca_mem_kredit = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "neracamemkredit",
        .HeaderText = "Memorial Kredit",
        .Name = "neraca_mem_kredit",
        .ReadOnly = True,
        .MinimumWidth = 150,
        .DefaultCellStyle = dgvstyle_currency
    }
    Private neraca_sesuai_kredit = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "neracaseskredit",
        .HeaderText = "Penyesuaian Kredit",
        .Name = "neraca_sesuai_kredit",
        .ReadOnly = True,
        .MinimumWidth = 150,
        .DefaultCellStyle = dgvstyle_currency
    }
    Private neraca_sesuai_debet = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "neracasesdebet",
        .HeaderText = "Penyesuaian Debet",
        .Name = "neraca_sesuai_kredit",
        .ReadOnly = True,
        .MinimumWidth = 150,
        .DefaultCellStyle = dgvstyle_currency
    }
    Private neraca_akhir_kredit = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "neracaakhirkredit",
        .HeaderText = "Saldo Akhir Kredit",
        .Name = "neraca_akhir_kredit",
        .ReadOnly = True,
        .MinimumWidth = 150,
        .DefaultCellStyle = dgvstyle_currency
    }
    Private neraca_akhir_debet = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "neracaakhirdebet",
        .HeaderText = "Saldo Akhir Debet",
        .Name = "neraca_akhir_kredit",
        .ReadOnly = True,
        .MinimumWidth = 150,
        .DefaultCellStyle = dgvstyle_currency
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
        .DefaultCellStyle = dgvstyle_date,
        .Name = "tanggal",
        .ReadOnly = True,
        .Width = 100
    }
    Private beli_gudang = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "gudang",
        .HeaderText = "Gudang",
        .Name = "gudang",
        .MinimumWidth = 150,
        .ReadOnly = True
    }
    Private beli_supplier = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "supplier",
        .HeaderText = "Supplier",
        .Name = "supplier",
        .Width = 230,
        .ReadOnly = True
    }
    Private beli_pajak = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "pajak",
        .HeaderText = "Faktur Pajak",
        .Name = "pajak",
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private beli_netto = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "netto",
        .HeaderText = "Netto",
        .Name = "netto",
        .DefaultCellStyle = dgvstyle_currency,
        .MinimumWidth = 120,
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
        .MinimumWidth = 120,
        .ReadOnly = True
    }
    Private beli_term = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "term",
        .HeaderText = "Term",
        .Name = "term",
        .ReadOnly = True,
        .Width = 50
    }

    '----------retur_beli_list dgv col-------------------
    Private retur_beli_bukti = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "bukti",
        .HeaderText = "No. Bukti",
        .Name = "bukti",
        .ReadOnly = True,
        .Width = 150
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
    Private jual_pkp = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "pkp",
        .HeaderText = "PKP",
        .Name = "pkp",
        .Width = 35,
        .ReadOnly = True
    }
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
        .MinimumWidth = 175,
        .ReadOnly = True
    }
    Private jual_custo = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "custo",
        .HeaderText = "Customer",
        .Name = "custo",
        .MinimumWidth = 175,
        .ReadOnly = True
    }
    Private jual_sales = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "sales",
        .HeaderText = "Salesman",
        .Name = "sales",
        .MinimumWidth = 175,
        .ReadOnly = True
    }
    Private jual_pajak = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "pajak",
        .HeaderText = "Faktur Pajak",
        .Name = "pajak",
        .MinimumWidth = 175,
        .ReadOnly = True
    }
    Private jual_netto = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "netto",
        .HeaderText = "Netto",
        .Name = "netto",
        .DefaultCellStyle = dgvstyle_currency,
        .MinimumWidth = 120,
        .ReadOnly = True
    }
    Private jual_klaim = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "klaim",
        .HeaderText = "Bayar",
        .Name = "klaim",
        .ReadOnly = True,
        .DefaultCellStyle = dgvstyle_currency
    }
    Private jual_total = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "total",
        .HeaderText = "Sisa",
        .Name = "total",
        .DefaultCellStyle = dgvstyle_currency,
        .MinimumWidth = 120,
        .ReadOnly = True
    }
    Private jual_term = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "term",
        .HeaderText = "Term",
        .Name = "term",
        .Width = 35,
        .ReadOnly = True
    }
    Private jual_batal = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "batal",
        .HeaderText = "BatalKirim",
        .Name = "batal",
        .Width = 35,
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

    '----------gudang_mutasi dgv col-------------------
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

    '----------stok_mutasi dgv col-------------------
    Private mutasi_gudang = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "gudang",
        .HeaderText = "Gudang",
        .Name = "gudang",
        .MinimumWidth = 200,
        .ReadOnly = True
    }
    Private mutasi_regby = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "regby",
        .HeaderText = "RegBy",
        .Name = "regby",
        .ReadOnly = True
    }
    Private mutasi_proses = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tglproses",
        .HeaderText = "Proses",
        .Name = "tgtproses",
        .ReadOnly = True
    }

    '----------hutang_awal dgv col-------------------
    Private hutang_awal = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "hutang_awal",
        .HeaderText = "Hutang Awal",
        .Name = "hutang_awal",
        .MinimumWidth = 125,
        .DefaultCellStyle = dgvstyle_currency,
        .ReadOnly = True
        }
    Private hutang_hutang = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "hutang_hutang",
        .HeaderText = "Hutang",
        .Name = "hutang_hutang",
        .MinimumWidth = 125,
        .DefaultCellStyle = dgvstyle_currency,
        .ReadOnly = True
    }
    Private hutang_retur = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "hutang_retur",
        .HeaderText = "Retur",
        .Name = "hutang_retur",
        .MinimumWidth = 125,
        .DefaultCellStyle = dgvstyle_currency,
        .ReadOnly = True
    }
    Private hutang_bayar = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "hutang_bayar",
        .HeaderText = "Bayar",
        .Name = "hutang_bayar",
        .MinimumWidth = 125,
        .DefaultCellStyle = dgvstyle_currency,
        .ReadOnly = True
        }
    Private hutang_sisa = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "hutang_sisa",
        .HeaderText = "Sisa",
        .Name = "hutang_sisa",
        .MinimumWidth = 125,
        .DefaultCellStyle = dgvstyle_currency,
        .ReadOnly = True
        }

    '----------hutang_bayar dgv col-------------------
    Private hutang_debet = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "debet",
        .HeaderText = "Total Pembayaran",
        .Name = "debet",
        .MinimumWidth = 125,
        .DefaultCellStyle = dgvstyle_currency,
        .ReadOnly = True
    }
    Private hutang_kredit = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
            .DataPropertyName = "kredit",
            .HeaderText = "Total Kredit",
            .Name = "kredit",
            .MinimumWidth = 125,
            .DefaultCellStyle = dgvstyle_currency,
            .ReadOnly = True
            }
    Private hutang_jenis = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "jenisbayar",
        .HeaderText = "Jenis Bayar",
        .Name = "jenisbayar",
        .Width = 75,
        .ReadOnly = True
    }

    '----------piutang_awal dgv col-------------------
    Private hutangbgo_tglcair = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tglcair",
        .HeaderText = "Tgl Cair",
        .Name = "tglcair",
        .ReadOnly = True
    }
    Private hutangbgo_tgltolak = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tgltolak",
        .HeaderText = "Tgl Tolak",
        .Name = "tgltolak",
        .ReadOnly = True
    }
    Private piutangbgo_cairke = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "giro_akuncair_n",
        .HeaderText = "Cair Ke..",
        .Name = "bankcair",
        .ReadOnly = True
    }

    '----------piutang_awal dgv col-------------------
    Private piutang_awal = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "piutang_awal",
        .HeaderText = "Piutang Awal",
        .Name = "piutang_awal",
        .DefaultCellStyle = dgvstyle_currency,
        .ReadOnly = True
        }
    Private piutang_piutang = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "piutang_piutang",
        .HeaderText = "Piutang",
        .Name = "piutang_piutang",
        .DefaultCellStyle = dgvstyle_currency,
        .ReadOnly = True
    }
    Private piutang_retur = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "piutang_retur",
        .HeaderText = "Retur",
        .Name = "piutang_retur",
        .DefaultCellStyle = dgvstyle_currency,
        .ReadOnly = True
    }
    Private piutang_bayar = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "piutang_bayar",
        .HeaderText = "Bayar",
        .Name = "piutang_bayar",
        .DefaultCellStyle = dgvstyle_currency,
        .ReadOnly = True
        }
    Private piutang_sisa = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "piutang_sisa",
        .HeaderText = "Sisa",
        .Name = "piutang_sisa",
        .DefaultCellStyle = dgvstyle_currency,
        .ReadOnly = True
        }
    Private piutang_tempo = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "piutang_jt",
        .HeaderText = "Jatuh Tempo",
        .Name = "piutang_tempo",
        .ReadOnly = True
    }
    Private piutang_lunas = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "piutang_lunas",
        .HeaderText = "Tgl Lunas",
        .Name = "piutang_lunas",
        .ReadOnly = True
    }

    '----------piutang_bayar dgv col-------------------
    Private piutang_it = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "piutangit",
        .HeaderText = "Input Date",
        .Name = "piutang_it",
        .ReadOnly = True
    }
    Private piutang_et = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "piutanget",
        .HeaderText = "Last Edit",
        .Name = "piutang_et",
        .ReadOnly = True
    }

    '----------jurnal_umum dgv col-------------------
    Private jurnal_u_jenis = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "ju_type",
        .HeaderText = "Jenis",
        .Name = "jurnal_u_jenis",
        .Width = 75,
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
        .Width = 400
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
        .Width = 100
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
        .Visible = True
    }
    Private user_logstat = New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "loginstat",
        .HeaderText = "Login PC Status",
        .Name = "loginstats",
        .ReadOnly = True
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
            Case "draftrekap"
                With frmrekap
                    setDoubleBuffered(.dgv_listfaktur, True)
                    setDoubleBuffered(.dgv_draft_list, True)
                    .setpage(pgdraftrekap)
                End With
            Case "drafttagihan"
                With frmtagihan
                    setDoubleBuffered(.dgv_listfaktur, True)
                    setDoubleBuffered(.dgv_draft_list, True)
                    .setpage(pgdrafttagihan)
                End With
            Case "stok"
                setListcode(pgstok, type, frmstok, "Daftar Stok Barang")
            Case "mutasigudang"
                frmmutasigudang.dgv_list.Columns.Clear()
                setDoubleBuffered(frmmutasigudang.dgv_list, True)
                setTabPageControl(type)
                populateDGVUserCon(type, "", frmmutasigudang.dgv_list)
                With frmmutasigudang
                    .in_countdata.Text = .dgv_list.Rows.Count
                    .setpage(pgmutasigudang)
                End With
            Case "mutasistok"
                frmmutasistok.dgv_list.Columns.Clear()
                setDoubleBuffered(frmmutasistok.dgv_list, True)
                setTabPageControl(type)
                populateDGVUserCon(type, "", frmmutasistok.dgv_list)
                Console.WriteLine(pgmutasistok.Name.ToString & "listcode")
                With frmmutasistok
                    .in_countdata.Text = .dgv_list.Rows.Count
                    .setpage(pgmutasistok)
                End With
            Case "stockop"
                frmstockop.dgv_list.Columns.Clear()
                setDoubleBuffered(frmstockop.dgv_list, True)
                setTabPageControl(type)
                populateDGVUserCon(type, "", frmstockop.dgv_list)
                Console.WriteLine(pgstockop.Name.ToString & "listcode")
                With frmstockop
                    .in_countdata.Text = .dgv_list.Rows.Count
                    .setpage(pgstockop)
                End With
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
            Case "jurnalmemorial"
                setListcode(pgjurnalmemorial, type, frmjurnalmemorial, "List Jurnal Memorial")
            Case "kartustok"
                With frmkartustok
                    setDoubleBuffered(.dgv_barang, True)
                    .setpage(pgkartustok)
                End With
            Case "tutupbuku"
                With frmtutupbuku
                    'setDoubleBuffered(.dgv_stock, True)
                    .setpage(pgtutupbuku)
                End With
            Case "exportEfak"
                With frmexportEfak
                    '.loadFaktur()
                    .setpage(pgexportEFak)
                End With
            Case "setbarangsales"
                frmsalesbarang.performRefresh()
                frmsalesbarang.setpage(pgsalesbarang)
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
        populateDGVUserCon(type, "", frm.dgv_list)
        Console.WriteLine(tbpg.Name.ToString & "listcode")
        With frm
            '.export_sw = False
            .lbl_judul.Text = text
            .in_countdata.Text = .dgv_list.Rows.Count
            .setpage(tbpg)
        End With
    End Sub

    Public Sub setDoubleBuffered(dgv As DataGridView, x As Boolean)
        Dim type As Type = dgv.[GetType]()
        Dim PI As PropertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        PI.SetValue(dgv, True, Nothing)
        Console.WriteLine("SET dgvdblbuffer")
    End Sub

    Private Sub setTabPageControl(type As String)
        Select Case type
            Case "barang"
                With frmbarang
                    Dim barang_status = New DataGridViewColumn
                    Dim barang_supplier = New DataGridViewColumn
                    Dim barang_kategori = New DataGridViewColumn
                    Dim barang_userid = New DataGridViewColumn
                    Dim barang_pajak = New DataGridViewColumn
                    Dim barang_it = New DataGridViewColumn
                    Dim barang_et = New DataGridViewColumn
                    barang_status = gudang_status.Clone()
                    barang_supplier = beli_supplier.Clone()
                    barang_kategori = barang_jenis.Clone()
                    barang_userid = user_id.Clone()
                    barang_pajak = barang_jenis.Clone()
                    barang_it = piutang_it.Clone()
                    barang_et = piutang_et.Clone()

                    barang_pajak.Name = "barang_pajak"
                    barang_kategori.HeaderText = "Kategori"
                    barang_pajak.HeaderText = "Kategori 2"
                    barang_kategori.DataPropertyName = "kategori"
                    barang_pajak.DataPropertyName = "barang_pajak"
                    barang_it.DataPropertyName = "barangit"
                    barang_et.DataPropertyName = "baranget"

                    .export_sw = True

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {barang_kode, barang_nama, barang_jenis, barang_kategori, barang_pajak, barang_status, barang_kode_supplier,
                                                         barang_supplier, barang_satuan_kecil, barang_satuan_tengah, barang_satuan_besar, barang_harga_beli,
                                                         barang_harga_jual, barang_harga_mt, barang_harga_horeka, barang_harga_rita, barang_it, barang_et, barang_userid}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With
            Case "supplier"
                With frmsupplier
                    Dim supplier_it = New DataGridViewColumn
                    Dim supplier_et = New DataGridViewColumn
                    Dim supplier_userid = New DataGridViewColumn
                    Dim supplier_status = New DataGridViewColumn
                    supplier_userid = user_id.Clone()
                    supplier_it = piutang_it.Clone()
                    supplier_et = piutang_et.Clone()
                    supplier_status = gudang_status.Clone()

                    supplier_it.DataPropertyName = "supplierit"
                    supplier_et.DataPropertyName = "supplieret"

                    .export_sw = True
                    With .dgv_list
                        Dim x As DataGridViewColumn() = {supplier_kode, supplier_nama, supplier_alamat, supplier_telp, supplier_fax, supplier_cp, supplier_term,
                                                         supplier_status, supplier_npwp, supplier_it, supplier_et, supplier_userid}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With
            Case "gudang"
                With frmgudang
                    Dim gudang_alamat = New DataGridViewColumn
                    Dim gudang_userid = New DataGridViewColumn()
                    Dim gudang_it = New DataGridViewColumn
                    Dim gudang_et = New DataGridViewColumn
                    gudang_alamat = supplier_alamat.Clone()
                    gudang_userid = user_id.Clone()
                    gudang_it = piutang_it.Clone()
                    gudang_et = piutang_et.Clone()

                    gudang_it.DataPropertyName = "gudangit"
                    gudang_et.DataPropertyName = "gudanget"
                    .export_sw = True

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {gudang_kode, gudang_nama, gudang_alamat, gudang_status, gudang_it, gudang_et, gudang_userid}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With
            Case "sales"
                With frmsales
                    Dim sales_userid = New DataGridViewColumn
                    Dim sales_alamat = New DataGridViewColumn
                    Dim sales_jenis = New DataGridViewColumn
                    Dim sales_it = New DataGridViewColumn
                    Dim sales_et = New DataGridViewColumn
                    sales_userid = user_id.Clone()
                    sales_alamat = supplier_alamat.Clone()
                    sales_jenis = barang_jenis.Clone()
                    sales_it = piutang_it.Clone()
                    sales_et = piutang_et.Clone()

                    sales_it.DataPropertyName = "salesit"
                    sales_et.DataPropertyName = "saleset"

                    .export_sw = True

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {sales_kode, sales_nama, sales_jenis, sales_status, sales_alamat, sales_telp, sales_target,
                                                         sales_it, sales_et, sales_userid}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

            Case "custo"
                With frmcusto
                    Dim custo_userid = New DataGridViewColumn
                    Dim custo_alamat = New DataGridViewColumn()
                    Dim custo_it = New DataGridViewColumn
                    Dim custo_et = New DataGridViewColumn
                    custo_alamat = supplier_alamat.Clone()
                    custo_userid = user_id.Clone()
                    custo_it = piutang_it.Clone()
                    custo_et = piutang_et.Clone()

                    custo_it.DataPropertyName = "custoit"
                    custo_et.DataPropertyName = "custoet"

                    .export_sw = True

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {custo_kode, custo_nama, custo_type, custo_status, custo_alamat, custo_alamat_kec, custo_alamat_kab,
                                                         custo_alamat_pasar, custo_telp, custo_fax, custo_term, custo_npwp, custo_nik}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With
            Case "bank"
                With frmbank.dgv_list
                    .AutoGenerateColumns = False
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {bank_kode})
                    For i = 0 To .Columns.Count - 1
                        .Columns(i).DisplayIndex = i
                    Next
                End With
            Case "giro"
                With frmbgditangan
                    .add_sw = False
                    .edit_sw = False
                    .del_sw = False
                    .export_sw = True

                    With .dgv_list
                        Dim giro_tglcair = New DataGridViewColumn
                        Dim giro_status = New DataGridViewColumn
                        Dim giro_bukti = New DataGridViewColumn
                        Dim giro_cair = New DataGridViewColumn
                        giro_tglcair = giro_tgl_bg.Clone()
                        giro_status = gudang_status.Clone()
                        giro_bukti = retur_beli_bukti.Clone()
                        giro_cair = piutangbgo_cairke.Clone()

                        giro_tglcair.Name = "giro_tglcair"
                        giro_tglcair.DataPropertyName = "tglcair"
                        giro_tglcair.HeaderText = "Tanggal Cair"
                        giro_tgl_bg.DataPropertyName = "tglefektif"
                        giro_tgl_bg.HeaderText = "Tanggal Efektif"
                        giro_bukti.HeaderText = "Refer."
                        giro_status.Width = 60
                        giro_cair.Width = giro_bank.Width


                        Dim x As DataGridViewColumn() = {giro_nobg, giro_bank, giro_status, giro_tgl, giro_tgl_bg, giro_tglcair,
                                                         giro_jml, giro_sales, giro_custo, giro_cair}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                            consoleWriteLine(x(i).HeaderText & x(i).DisplayIndex)
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With
            Case "perkiraan"
                With frmperkiraan
                    .del_sw = False
                    .export_sw = True
                    With .dgv_list
                        Dim perkiraan_userid = New DataGridViewColumn
                        Dim perkiraan_status = New DataGridViewColumn
                        'Dim perkiraan_saperiode = New DataGridViewColumn
                        Dim perkiraan_keterangan = New DataGridViewColumn
                        perkiraan_userid = user_id.Clone()
                        perkiraan_status = gudang_status.Clone()
                        'perkiraan_saperiode = perkiraan_awal.Clone()
                        perkiraan_keterangan = group_ket.Clone()

                        'perkiraan_saperiode.DataPropertyName = "saldo_periode"
                        'perkiraan_saperiode.Name = "saldoperiode"
                        'perkiraan_saperiode.HeaderText = "Saldo Awal Periode"

                        Dim x As DataGridViewColumn() = {perkiraan_kode, perkiraan_jenis, perkiraan_gol, perkiraan_nama, perkiraan_posisi,
                                                         perkiraan_awal, perkiraan_status, perkiraan_userid}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                            consoleWriteLine(x(i).HeaderText & x(i).DisplayIndex)
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With
            Case "neracaawal"
                With frmawalneraca
                    Dim neraca_kode = New DataGridViewColumn()
                    Dim neraca_perkiraan = New DataGridViewColumn()
                    Dim neraca_kredit = New DataGridViewColumn()
                    Dim neraca_debet = New DataGridViewColumn()
                    neraca_kode = perkiraan_kode.Clone()
                    neraca_perkiraan = perkiraan_nama.Clone()
                    neraca_kredit = hutang_kredit.Clone()
                    neraca_debet = hutang_debet.Clone()

                    .add_sw = False
                    .edit_sw = False
                    .del_sw = False

                    With .dgv_list
                        .AutoGenerateColumns = False
                        .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {neraca_kode, neraca_perkiraan, neraca_awal, neraca_debet, neraca_kredit, neraca_mem_debet, neraca_sesuai_debet, neraca_mem_kredit, neraca_sesuai_kredit, neraca_akhir_debet, neraca_akhir_kredit})
                        For i = 0 To .Columns.Count - 1
                            .Columns(i).DisplayIndex = i
                        Next
                    End With
                End With
            Case "beli"
                Dim beli_user = New DataGridViewColumn
                Dim beli_tglinvoice = New DataGridViewColumn
                Dim beli_status = New DataGridViewColumn
                Dim beli_jenpajak = New DataGridViewColumn
                Dim beli_it = New DataGridViewColumn
                Dim beli_et = New DataGridViewColumn
                beli_user = user_id.Clone()
                beli_tglinvoice = beli_tgl.Clone()
                beli_status = gudang_status.Clone()
                beli_jenpajak = gudang_status.Clone()
                beli_it = jual_tgl.Clone()
                beli_et = jual_tgl.Clone()

                beli_jenpajak.Width = 50
                beli_jenpajak.Name = "jenpajak"
                beli_tglinvoice.Name = "tglinvoice"
                beli_jenpajak.HeaderText = "Kat."
                beli_tglinvoice.HeaderText = "Tgl.Pajak/Invoice"
                beli_jenpajak.DataPropertyName = "jenispajak"
                beli_tglinvoice.DataPropertyName = "tanggalinvoice"

                beli_it.Name = "beli_it"
                beli_it.HeaderText = "InputDate"
                beli_it.DataPropertyName = "regdate"

                beli_et.Name = "beli_et"
                beli_et.HeaderText = "LastEditDate"
                beli_et.DataPropertyName = "upddate"

                With frmpembelian
                    .print_sw = True
                    .cancel_sw = IIf(selectperiode.closed = False, loggeduser.allowedit_transact, False)
                    .add_sw = IIf(selectperiode.closed = True, False, True)
                    .del_sw = False
                    .delete_sw = IIf(selectperiode.closed = False, loggeduser.allowedit_transact, False)
                    .export_sw = True
                    .mn_edit.Text = IIf(selectperiode.closed = True, "Tampilkan Detail", "Edit Data")

                    Dim x As DataGridViewColumn() = {beli_faktur, beli_tgl, beli_tglinvoice, beli_status, beli_jenpajak, beli_supplier, beli_gudang, beli_pajak,
                                                     beli_netto, beli_klaim, beli_total, beli_term, beli_it, beli_et, beli_user}
                    For i = 0 To x.Count - 1
                        x(i).DisplayIndex = i
                    Next

                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)
                End With

            Case "returbeli"
                With frmreturbeli
                    Dim retur_beli_user = New DataGridViewColumn
                    Dim retur_jnsbyr = New DataGridViewColumn
                    Dim retur_status = New DataGridViewColumn
                    Dim retur_jenpajak = New DataGridViewColumn
                    Dim retur_it = New DataGridViewColumn
                    Dim retur_et = New DataGridViewColumn
                    retur_beli_user = user_id.Clone()
                    retur_jnsbyr = hutang_jenis.Clone()
                    retur_status = gudang_status.Clone()
                    retur_jenpajak = gudang_status.Clone()
                    retur_it = jual_tgl.Clone()
                    retur_et = jual_tgl.Clone()

                    retur_jenpajak.Width = 50
                    retur_jenpajak.Name = "jenpajak"
                    retur_jenpajak.HeaderText = "Kat."
                    retur_jenpajak.DataPropertyName = "jenispajak"

                    retur_it.Name = "retur_it"
                    retur_it.HeaderText = "InputDate"
                    retur_it.DataPropertyName = "regdate"

                    retur_et.Name = "retur_et"
                    retur_et.HeaderText = "LastEditDate"
                    retur_et.DataPropertyName = "upddate"

                    .print_sw = True
                    .cancel_sw = IIf(selectperiode.closed = False, loggeduser.allowedit_transact, False)
                    .add_sw = IIf(selectperiode.closed = True, False, True)
                    .del_sw = False
                    .delete_sw = IIf(selectperiode.closed = False, loggeduser.allowedit_transact, False)
                    .export_sw = True
                    .mn_edit.Text = IIf(selectperiode.closed = True, "Tampilkan Detail", "Edit Data")

                    Dim x As DataGridViewColumn() = {retur_beli_bukti, retur_jnsbyr, retur_jenpajak, retur_beli_faktur, retur_beli_tgl, retur_status, retur_beli_supplier,
                                                     retur_beli_gudang, retur_beli_jml, retur_it, retur_et, retur_beli_user}
                    For i = 0 To x.Count - 1
                        x(i).DisplayIndex = i
                        consoleWriteLine(x(i).HeaderText & x(i).DisplayIndex)
                    Next

                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)

                End With

            Case "pesanan"
                With frmpesanjual
                    Dim pesan_kode = New DataGridViewColumn
                    Dim pesan_tanggal = New DataGridViewColumn
                    Dim pesan_sales = New DataGridViewColumn
                    Dim pesan_custo = New DataGridViewColumn
                    Dim pesan_validstate = New DataGridViewColumn
                    Dim pesan_faktur = New DataGridViewColumn
                    Dim pesan_total = New DataGridViewColumn
                    Dim pesan_term = New DataGridViewColumn
                    Dim pesan_it = New DataGridViewColumn
                    Dim pesan_et = New DataGridViewColumn
                    Dim pesan_user = New DataGridViewColumn
                    Dim pesan_user2 = New DataGridViewColumn
                    Dim pesan_validdate = New DataGridViewColumn
                    Dim pesan_validuser = New DataGridViewColumn
                    Dim pesan_jualref = New DataGridViewColumn
                    Dim pesan_andro = New DataGridViewColumn
                    pesan_kode = gudang_kode.Clone()
                    pesan_tanggal = jual_tgl.Clone()
                    pesan_sales = jual_sales.Clone()
                    pesan_custo = jual_custo.Clone()
                    pesan_total = jual_total.Clone()
                    pesan_term = gudang_status.Clone()
                    pesan_validstate = gudang_status.Clone()
                    pesan_faktur = jual_faktur.Clone()
                    pesan_validdate = jual_tgl.Clone()
                    pesan_validuser = user_id.Clone()
                    pesan_jualref = retur_jual_faktur.Clone()
                    pesan_andro = gudang_status.Clone()
                    pesan_user = user_id.Clone()
                    pesan_user2 = user_id.clone()
                    pesan_it = jual_tgl.Clone()
                    pesan_et = jual_tgl.Clone()

                    pesan_user.Name = "user_id2"

                    pesan_kode.HeaderText = "ID Pesanan"
                    pesan_total.HeaderText = "Nilai Pesanan"
                    pesan_term.HeaderText = "Bayar"
                    pesan_validdate.HeaderText = "Tgl Validasi"
                    pesan_validuser.HeaderText = "By"
                    pesan_andro.HeaderText = "InputFrom"
                    pesan_user.HeaderText = "InputBy"
                    pesan_user2.HeaderText = "EditBy"
                    pesan_it.HeaderText = "InputDate"
                    pesan_et.HeaderText = "LastEditDate"

                    pesan_term.DataPropertyName = "term"
                    pesan_validdate.DataPropertyName = "valid_date"
                    pesan_validuser.DataPropertyName = "valid_alias"
                    pesan_andro.DataPropertyName = "input_source"
                    pesan_user2.DataPropertyName = "userid2"
                    pesan_it.DataPropertyName = "regdate"
                    pesan_et.DataPropertyName = "upddate"

                    pesan_kode.Width = 50
                    pesan_term.Width = 60
                    pesan_andro.Width = 60

                    .valid_sw = IIf(selectperiode.closed = False, loggeduser.validasi_trans, False)
                    .del_sw = False
                    .cancel_sw = IIf(selectperiode.closed = False, loggeduser.validasi_trans, False)
                    .delete_sw = IIf(selectperiode.closed = False, loggeduser.allowedit_transact, False)
                    .add_sw = IIf(selectperiode.closed = True, False, True)

                    Dim x As DataGridViewColumn() = {pesan_kode, pesan_tanggal, pesan_sales, pesan_custo, pesan_total, pesan_term, pesan_validstate,
                                                     pesan_faktur, pesan_validdate, pesan_validuser, pesan_andro, pesan_user, pesan_it, pesan_user2, pesan_et}

                    For i = 0 To x.Count - 1
                        x(i).DisplayIndex = i
                        consoleWriteLine(x(i).HeaderText & x(i).DisplayIndex)
                    Next

                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)
                End With

            Case "jual"
                With frmpenjualan
                    Dim jual_user = New DataGridViewColumn
                    Dim jual_status = New DataGridViewColumn
                    Dim jual_jenpajak = New DataGridViewColumn
                    Dim jual_it = New DataGridViewColumn
                    Dim jual_et = New DataGridViewColumn
                    jual_user = user_id.Clone()
                    jual_status = gudang_status.Clone()
                    jual_jenpajak = gudang_status.Clone()
                    jual_it = jual_tgl.Clone()
                    jual_et = jual_tgl.Clone()

                    jual_jenpajak.Width = 50
                    jual_jenpajak.Name = "jenpajak"
                    jual_jenpajak.HeaderText = "Kat."
                    jual_jenpajak.DataPropertyName = "jenispajak"
                    jual_it.HeaderText = "InputDate"
                    jual_et.HeaderText = "LastEditDate"
                    jual_it.Name = "jual_it"
                    jual_et.Name = "jual_et"
                    jual_it.DataPropertyName = "regdate"
                    jual_et.DataPropertyName = "upddate"

                    .print_sw = True
                    .cancel_sw = IIf(selectperiode.closed = False, loggeduser.allowedit_transact, False)
                    .add_sw = IIf(selectperiode.closed = True, False, True)
                    .del_sw = False
                    .delete_sw = IIf(selectperiode.closed = False, loggeduser.allowedit_transact, False)
                    .export_sw = True
                    .mn_edit.Text = IIf(selectperiode.closed = True, "Tampilkan Detail", "Edit Data")

                    Dim x As DataGridViewColumn() = {jual_faktur, jual_tgl, jual_status, jual_jenpajak, jual_term, jual_custo, jual_sales, jual_pajak,
                                                    jual_gudang, jual_netto, jual_klaim, jual_total, jual_it, jual_et, jual_user}
                    For i = 0 To x.Count - 1
                        x(i).DisplayIndex = i
                    Next

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

                    .print_sw = True
                    .cancel_sw = IIf(selectperiode.closed = False, loggeduser.allowedit_transact, False)
                    .add_sw = IIf(selectperiode.closed = True, False, True)
                    .del_sw = False
                    .delete_sw = IIf(selectperiode.closed = False, loggeduser.allowedit_transact, False)
                    .export_sw = True
                    .mn_edit.Text = IIf(selectperiode.closed = True, "Tampilkan Detail", "Edit Data")

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

                    .edit_sw = True
                    .del_sw = False
                    .add_sw = False

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

            Case "mutasigudang"
                With frmmutasigudang
                    With .dgv_list
                        Dim mutasig_gudang_tujuan = New DataGridViewColumn()
                        Dim mutasig_gudang_asal = New DataGridViewColumn()
                        Dim mutasig_user = New DataGridViewColumn()
                        Dim mutasig_tgl = New DataGridViewColumn()
                        Dim mutasig_id = New DataGridViewColumn()
                        Dim mutasig_status = New DataGridViewColumn()
                        Dim mutasig_jenpajak = New DataGridViewColumn
                        Dim mutasig_it = New DataGridViewColumn
                        Dim mutasig_et = New DataGridViewColumn
                        mutasig_gudang_tujuan = mutasi_gudang_tujuan.Clone()
                        mutasig_gudang_asal = mutasi_gudang_asal.Clone()
                        mutasig_user = user_id.Clone()
                        mutasig_tgl = mutasi_tgl.Clone()
                        mutasig_id = mutasi_id.CLone()
                        mutasig_status = gudang_status.Clone()
                        mutasig_jenpajak = gudang_status.Clone()
                        mutasig_it = jual_tgl.Clone()
                        mutasig_et = jual_tgl.Clone()

                        mutasig_jenpajak.Width = 50
                        mutasig_jenpajak.Name = "jenpajak"
                        mutasig_jenpajak.HeaderText = "Kat."
                        mutasig_jenpajak.DataPropertyName = "jenispajak"

                        mutasig_it.Name = "retur_it"
                        mutasig_it.HeaderText = "InputDate"
                        mutasig_it.DataPropertyName = "regdate"

                        mutasig_et.Name = "retur_et"
                        mutasig_et.HeaderText = "LastEditDate"
                        mutasig_et.DataPropertyName = "upddate"


                        Dim x As DataGridViewColumn() = {mutasig_id, mutasig_tgl, mutasig_jenpajak, mutasig_gudang_asal, mutasig_gudang_tujuan, mutasig_status,
                                                         mutasig_it, mutasig_et, mutasig_user}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

            Case "mutasistok"
                With frmmutasistok
                    With .dgv_list
                        Dim mutasis_user = New DataGridViewColumn()
                        Dim mutasis_id = New DataGridViewColumn()
                        Dim mutasis_tgl = New DataGridViewColumn()
                        Dim mutasis_gudang = New DataGridViewColumn()
                        Dim mutasis_jenpajak = New DataGridViewColumn
                        Dim mutasis_et = New DataGridViewColumn()
                        Dim mutasis_it = New DataGridViewColumn()
                        Dim mutasis_status = New DataGridViewColumn()
                        mutasis_user = user_id.Clone()
                        mutasis_id = mutasi_id.Clone()
                        mutasis_tgl = mutasi_tgl.Clone()
                        mutasis_gudang = mutasi_gudang.Clone()
                        mutasis_et = mutasi_tgl.Clone()
                        mutasis_it = mutasi_tgl.Clone()
                        mutasis_status = gudang_status.Clone()
                        mutasis_jenpajak = gudang_status.Clone()

                        mutasis_jenpajak.Width = 50
                        mutasis_jenpajak.Name = "jenpajak"
                        mutasis_jenpajak.HeaderText = "Kat."
                        mutasis_jenpajak.DataPropertyName = "jenispajak"

                        mutasis_it.Name = "mutasis_it"
                        mutasis_et.Name = "mutasis_et"
                        mutasis_it.DataPropertyName = "it"
                        mutasis_et.DataPropertyName = "et"
                        mutasis_it.HeaderText = "InputDate"
                        mutasis_et.HeaderText = "LastEditDate"

                        Dim x As DataGridViewColumn() = {mutasis_id, mutasis_jenpajak, mutasis_tgl, mutasis_gudang, mutasis_status, mutasis_it, mutasis_et, mutasis_user}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                            consoleWriteLine(x(i).HeaderText & x(i).DisplayIndex)
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

            Case "stockop"
                With frmstockop
                    With .dgv_list
                        Dim mutasiop_user = New DataGridViewColumn()
                        Dim mutasiop_id = New DataGridViewColumn()
                        Dim mutasiop_tgl = New DataGridViewColumn()
                        Dim mutasiop_gudang = New DataGridViewColumn()
                        Dim mutasiop_proses = New DataGridViewColumn()
                        Dim mutasiop_status = New DataGridViewColumn()
                        Dim mutasiop_jenpajak = New DataGridViewColumn
                        Dim mutasiop_et = New DataGridViewColumn()
                        Dim mutasiop_it = New DataGridViewColumn()
                        mutasiop_user = user_id.Clone()
                        mutasiop_id = mutasi_id.Clone()
                        mutasiop_tgl = mutasi_tgl.Clone()
                        mutasiop_gudang = mutasi_gudang.Clone()
                        mutasiop_proses = mutasi_proses.Clone()
                        mutasiop_status = gudang_status.Clone()
                        mutasiop_jenpajak = gudang_status.Clone()
                        mutasiop_et = mutasi_tgl.Clone()
                        mutasiop_it = mutasi_tgl.Clone()

                        mutasiop_jenpajak.Width = 50
                        mutasiop_jenpajak.Name = "jenpajak"
                        mutasiop_jenpajak.HeaderText = "Kat."
                        mutasiop_jenpajak.DataPropertyName = "jenispajak"

                        mutasiop_it.Name = "mutasis_it"
                        mutasiop_et.Name = "mutasiop_et"
                        mutasiop_it.DataPropertyName = "regdate"
                        mutasiop_et.DataPropertyName = "upddate"
                        mutasiop_it.HeaderText = "InputDate"
                        mutasiop_et.HeaderText = "LastEditDate"

                        Dim x As DataGridViewColumn() = {mutasiop_id, mutasiop_tgl, mutasiop_gudang, mutasiop_status, mutasiop_proses, mutasiop_user,
                                                         mutasiop_it, mutasiop_et}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                            consoleWriteLine(x(i).HeaderText & x(i).DisplayIndex)
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

            Case "hutangawal"
                With frmhutangawal
                    Dim hutang_faktur = New DataGridViewColumn()
                    Dim hutang_tgl = New DataGridViewColumn()
                    Dim hutang_supplier = New DataGridViewColumn()
                    Dim hutang_status = New DataGridViewColumn()
                    Dim hutang_term = New DataGridViewColumn()
                    Dim hutang_pending = New DataGridViewColumn()
                    Dim hutang_giro_awal = New DataGridViewColumn()
                    Dim hutang_jenpajak = New DataGridViewColumn()
                    hutang_faktur = beli_faktur.Clone()
                    hutang_tgl = beli_tgl.Clone()
                    hutang_supplier = beli_supplier.Clone()
                    hutang_status = gudang_status.Clone()
                    hutang_term = beli_term.Clone()
                    hutang_pending = hutang_bayar.Clone()
                    hutang_giro_awal = hutang_awal.Clone()
                    hutang_jenpajak = gudang_status.Clone()

                    hutang_jenpajak.Width = 50
                    hutang_jenpajak.Name = "jenpajak"
                    hutang_jenpajak.HeaderText = "Kat."
                    hutang_jenpajak.DataPropertyName = "hutang_kat"
                    hutang_pending.Name = "hutang_giro"
                    hutang_pending.DataPropertyName = "hutang_giro"
                    hutang_pending.HeaderText = "Giro"
                    hutang_giro_awal.Name = "hutang_giro_awal"
                    hutang_giro_awal.DataPropertyName = "hutang_giro_awal"
                    hutang_giro_awal.HeaderText = "Hutang Giro Awal"

                    .add_sw = False
                    .del_sw = False
                    .bayar_sw = IIf(selectperiode.closed = True, False, IIf(main.listkodemenu.Contains("mn0402"), True, False))
                    .cancel_sw = IIf(selectperiode.closed = True, False, True)
                    .mn_edit.Text = "Tampilkan Detail"
                    '.bayar_sw = False

                    Dim x As DataGridViewColumn() = {hutang_faktur, hutang_tgl, hutang_supplier, hutang_jenpajak, hutang_term, hutang_status, hutang_awal, hutang_hutang,
                                                     hutang_retur, hutang_bayar, hutang_sisa, hutang_giro_awal, hutang_pending}
                    For i = 0 To x.Count - 1
                        x(i).DisplayIndex = i
                        consoleWriteLine(x(i).HeaderText & x(i).DisplayIndex)
                    Next

                    With .dgv_list
                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With
            Case "hutangbayar"
                With frmhutangbayar
                    Dim hutang_bukti = New DataGridViewColumn()
                    Dim hutang_tgl = New DataGridViewColumn()
                    Dim hutang_supplier = New DataGridViewColumn()
                    Dim hutang_it = New DataGridViewColumn()
                    Dim hutang_et = New DataGridViewColumn()
                    Dim hutang_user = New DataGridViewColumn()
                    Dim hutang_status = New DataGridViewColumn()
                    Dim hutang_jenpajak = New DataGridViewColumn()
                    hutang_bukti = retur_beli_bukti.Clone()
                    hutang_tgl = beli_tgl.Clone()
                    hutang_supplier = beli_supplier.Clone()
                    hutang_it = piutang_it.Clone()
                    hutang_et = piutang_et.Clone()
                    hutang_user = user_id.Clone()
                    hutang_status = gudang_status.Clone()
                    hutang_jenpajak = gudang_status.Clone()

                    hutang_jenpajak.Width = 50
                    hutang_jenpajak.Name = "jenpajak"
                    hutang_jenpajak.HeaderText = "Kat."
                    hutang_jenpajak.DataPropertyName = "bayar_kat"
                    hutang_tgl.HeaderText = "Tgl. Pembayaran"

                    .print_sw = False
                    .add_sw = IIf(selectperiode.closed = True, False, True)
                    .cancel_sw = IIf(selectperiode.closed = False, loggeduser.allowedit_transact, False)
                    .del_sw = False
                    .mn_edit.Text = IIf(selectperiode.closed = True, "Tampilkan Detail", "Edit Data")

                    Dim x As DataGridViewColumn() = {hutang_bukti, hutang_tgl, hutang_supplier, hutang_debet, hutang_jenis, hutang_jenpajak,
                                                     hutang_status, hutang_it, hutang_et, hutang_user}
                    For i = 0 To x.Count - 1
                        x(i).DisplayIndex = i
                        consoleWriteLine(x(i).HeaderText & x(i).DisplayIndex)
                    Next

                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)
                End With

            Case "hutangbgo"
                With frmhutangbgo
                    Dim hutangbgo_kode = New DataGridViewColumn()
                    Dim hutangbgo_tgl = New DataGridViewColumn()
                    Dim hutangbgo_bank = New DataGridViewColumn()
                    Dim hutangbgo_jml = New DataGridViewColumn()
                    Dim hutangbgo_tglbgo = New DataGridViewColumn()
                    Dim hutangbgo_userid = New DataGridViewColumn()
                    Dim hutangbgo_ket = New DataGridViewColumn()
                    Dim hutangbgo_supplier = New DataGridViewColumn()
                    Dim hutangbgo_usercair = New DataGridViewColumn()
                    Dim hutangbgo_status = New DataGridViewColumn()
                    hutangbgo_kode = giro_nobg.Clone()
                    hutangbgo_tgl = giro_tgl.Clone()
                    hutangbgo_bank = giro_bank.Clone()
                    hutangbgo_jml = giro_jml.Clone()
                    hutangbgo_tglbgo = giro_tgl_bg.Clone()
                    hutangbgo_userid = user_id.Clone()
                    hutangbgo_ket = group_ket.Clone()
                    hutangbgo_supplier = beli_supplier.Clone()
                    hutangbgo_usercair = user_id.Clone()
                    hutangbgo_status = gudang_status.Clone()

                    hutangbgo_usercair.Name = "bg_usercair"
                    hutangbgo_usercair.HeaderText = "Input Cair By.."

                    hutangbgo_kode.DataPropertyName = "giro_no"
                    hutangbgo_bank.DataPropertyName = "giro_bank_n"
                    hutangbgo_tgl.DataPropertyName = "giro_tglterima"
                    hutangbgo_tglbgo.DataPropertyName = "giro_tglefektif"
                    hutangbgo_jml.DataPropertyName = "giro_nilai"
                    hutangbgo_ket.DataPropertyName = "giro_ket"
                    hutangbgo_tglcair.DataPropertyName = "giro_tglcair"
                    hutangbgo_usercair.DataPropertyName = "giro_cair_user"
                    hutangbgo_tgltolak.DataPropertyName = "giro_tgltolak"

                    hutangbgo_ket.MinimumWidth = 100
                    hutangbgo_ket.Width = 150
                    hutangbgo_status.Width = 75

                    .add_sw = False

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {hutangbgo_kode, hutangbgo_bank, hutangbgo_status, hutangbgo_supplier, hutangbgo_jml, hutangbgo_tgl,
                                                         hutangbgo_tglbgo, hutangbgo_ket, hutangbgo_tglcair, hutangbgo_usercair, hutangbgo_tgltolak, hutangbgo_userid}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With
            Case "piutangawal"
                With frmpiutangawal
                    Dim piutang_faktur = New DataGridViewColumn()
                    Dim piutang_tgl = New DataGridViewColumn()
                    Dim piutang_custo = New DataGridViewColumn()
                    Dim piutang_sales = New DataGridViewColumn()
                    Dim piutang_status = New DataGridViewColumn()
                    Dim piutang_term = New DataGridViewColumn()
                    Dim piutang_pending = New DataGridViewColumn()
                    Dim piutang_giro_awal = New DataGridViewColumn()
                    Dim piutang_jenpajak = New DataGridViewColumn()
                    piutang_faktur = beli_faktur.Clone()
                    piutang_tgl = beli_tgl.Clone()
                    piutang_custo = jual_custo.Clone()
                    piutang_sales = jual_sales.Clone()
                    piutang_status = gudang_status.Clone()
                    piutang_term = beli_term.Clone()
                    piutang_pending = piutang_bayar.Clone()
                    piutang_giro_awal = piutang_awal.Clone()
                    piutang_jenpajak = gudang_status.Clone()

                    piutang_jenpajak.Width = 50
                    piutang_jenpajak.Name = "jenpajak"
                    piutang_jenpajak.HeaderText = "Kat."
                    piutang_jenpajak.DataPropertyName = "piutang_kat"
                    piutang_pending.Name = "piutang_giro"
                    piutang_pending.DataPropertyName = "piutang_giro"
                    piutang_pending.HeaderText = "Giro"
                    piutang_giro_awal.Name = "piutang_giro_awal"
                    piutang_giro_awal.DataPropertyName = "piutang_giro_awal"
                    piutang_giro_awal.HeaderText = "Piutang Giro Awal"

                    piutang_status.Width = 75

                    .add_sw = False
                    .bayar_sw = IIf(selectperiode.closed = True, False, IIf(main.listkodemenu.Contains("mn0502"), True, False))
                    .del_sw = False
                    .cancel_sw = IIf(selectperiode.closed = True, False, True)
                    .mn_edit.Text = "Tampilkan Detail"
                    '.bayar_sw = False

                    Dim x As DataGridViewColumn() = {piutang_faktur, piutang_tgl, piutang_custo, piutang_jenpajak, piutang_status, piutang_term, piutang_tempo,
                                                     piutang_sales, piutang_awal, piutang_piutang, piutang_retur, piutang_bayar, piutang_sisa, piutang_giro_awal,
                                                     piutang_pending, piutang_lunas}
                    For i = 0 To x.Count - 1
                        x(i).DisplayIndex = i
                        consoleWriteLine(x(i).HeaderText & x(i).DisplayIndex)
                    Next

                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)
                End With

            Case "piutangbayar"
                With frmpiutangbayar
                    Dim piutang_bukti = New DataGridViewColumn()
                    Dim piutang_tgl = New DataGridViewColumn()
                    Dim piutang_sales = New DataGridViewColumn()
                    Dim piutang_custo = New DataGridViewColumn()
                    Dim piutang_debet = New DataGridViewColumn()
                    Dim piutang_user = New DataGridViewColumn()
                    Dim piutang_status = New DataGridViewColumn()
                    Dim piutang_jenis = New DataGridViewColumn()
                    Dim piutang_andro = New DataGridViewColumn()
                    Dim piutang_jenpajak = New DataGridViewColumn()
                    piutang_bukti = retur_beli_bukti.Clone()
                    piutang_tgl = beli_tgl.Clone()
                    piutang_sales = jual_sales.Clone()
                    piutang_custo = jual_custo.Clone()
                    piutang_debet = hutang_debet.Clone()
                    piutang_user = user_id.Clone()
                    piutang_status = gudang_status.Clone()
                    piutang_jenis = hutang_jenis.Clone()
                    piutang_andro = gudang_status.Clone()
                    piutang_jenpajak = gudang_status.Clone()

                    piutang_jenpajak.Width = 50
                    piutang_jenpajak.Name = "jenpajak"
                    piutang_jenpajak.HeaderText = "Kat."
                    piutang_jenpajak.DataPropertyName = "bayar_kat"
                    piutang_tgl.HeaderText = "Tanggal Pembayaran"
                    piutang_debet.HeaderText = "Total Pembayaran"
                    piutang_andro.HeaderText = "InputFrom"

                    piutang_andro.DataPropertyName = "input_source"

                    piutang_andro.Width = 60

                    .print_sw = True
                    .add_sw = IIf(selectperiode.closed = True, False, True)
                    .cancel_sw = IIf(selectperiode.closed = False, loggeduser.validasi_trans, False)
                    .del_sw = False
                    .mn_edit.Text = IIf(selectperiode.closed = True, "Tampilkan Detail", "Edit Data")

                    Dim x As DataGridViewColumn() = {piutang_bukti, piutang_tgl, piutang_custo, piutang_sales, piutang_debet, piutang_jenpajak, piutang_jenis,
                                                     piutang_status, piutang_andro, piutang_it, piutang_et, piutang_user}
                    For i = 0 To x.Count - 1
                        x(i).DisplayIndex = i
                    Next

                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)
                End With

            Case "piutangbgcair"
                With frmpiutangbgcair
                    Dim bg_no = New DataGridViewColumn()
                    Dim bg_bank = New DataGridViewColumn()
                    Dim bg_tglbg = New DataGridViewColumn()
                    Dim bg_jml = New DataGridViewColumn()
                    Dim bg_custo = New DataGridViewColumn()
                    Dim bg_sales = New DataGridViewColumn()
                    Dim bg_tgl = New DataGridViewColumn()
                    Dim bg_tglcair = New DataGridViewColumn()
                    Dim bg_usercair = New DataGridViewColumn()
                    Dim bg_tgltolak = New DataGridViewColumn()
                    Dim bg_userid = New DataGridViewColumn()
                    Dim bg_ket = New DataGridViewColumn()
                    Dim bg_status = New DataGridViewColumn()
                    bg_no = giro_nobg.Clone()
                    bg_bank = giro_bank.Clone()
                    bg_tglbg = giro_tgl_bg.Clone()
                    bg_tgl = giro_tgl.Clone()
                    bg_jml = giro_jml.Clone()
                    bg_custo = jual_custo.Clone()
                    bg_sales = jual_sales.Clone()
                    bg_tglcair = hutangbgo_tglcair.Clone()
                    bg_usercair = user_id.Clone()
                    bg_tgltolak = hutangbgo_tgltolak.Clone()
                    bg_userid = user_id.Clone()
                    bg_ket = group_ket.Clone()
                    bg_status = gudang_status.Clone()

                    bg_usercair.Name = "bg_usercair"
                    bg_usercair.HeaderText = "Input Cair By.."

                    bg_no.DataPropertyName = "giro_no"
                    bg_bank.DataPropertyName = "giro_bank"
                    bg_tgl.DataPropertyName = "giro_tglterima"
                    bg_tglbg.DataPropertyName = "giro_tglefektif"
                    bg_jml.DataPropertyName = "giro_nilai"
                    bg_ket.DataPropertyName = "bg_ket"
                    bg_tglcair.DataPropertyName = "giro_tglcair"
                    bg_usercair.DataPropertyName = "giro_cair_user"
                    bg_tgltolak.DataPropertyName = "giro_tgltolak"
                    bg_ket.DataPropertyName = "giro_ket"

                    bg_ket.MinimumWidth = 100
                    bg_ket.Width = 150
                    bg_status.Width = 75

                    .add_sw = False

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {bg_no, bg_bank, bg_status, bg_custo, bg_sales, bg_tgl, bg_tglbg, bg_jml,
                                                         piutangbgo_cairke, bg_tglcair, bg_usercair, bg_tgltolak, bg_ket, bg_userid}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

            Case "piutangbgtolak"
                With frmpiutangbgTolak
                    Dim bg_bukti = New DataGridViewColumn()
                    Dim bg_tgl = New DataGridViewColumn()
                    Dim bg_sales = New DataGridViewColumn()
                    Dim bg_custo = New DataGridViewColumn()
                    Dim bg_no = New DataGridViewColumn()
                    Dim bg_tglbg = New DataGridViewColumn()
                    Dim bg_jml = New DataGridViewColumn()
                    Dim bg_supplier = New DataGridViewColumn()
                    bg_bukti = retur_beli_bukti.Clone()
                    bg_tgl = beli_tgl.Clone()
                    bg_sales = jual_sales.Clone()
                    bg_custo = jual_custo.Clone()
                    bg_no = giro_nobg.Clone()
                    bg_tglbg = giro_tgl_bg.Clone()
                    bg_jml = giro_jml.Clone()
                    bg_supplier = beli_supplier.Clone()

                    With .dgv_list
                        .AutoGenerateColumns = False
                        .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {bg_bukti, bg_tgl, bg_sales, bg_custo, bg_no, bg_tglbg, bg_jml, bg_supplier})
                        For i = 0 To .Columns.Count - 1
                            .Columns(i).DisplayIndex = i
                        Next
                    End With
                End With

            Case "kas"
                With frmkas
                    Dim kas_bank = New DataGridViewColumn()
                    Dim kas_bukti = New DataGridViewColumn()
                    Dim kas_tgl = New DataGridViewColumn()
                    Dim kas_sales = New DataGridViewColumn()
                    Dim kas_debet = New DataGridViewColumn()
                    Dim kas_kredit = New DataGridViewColumn()
                    Dim kas_user = New DataGridViewColumn()
                    Dim kas_jenis = New DataGridViewColumn()
                    Dim kas_status = New DataGridViewColumn()
                    kas_bank = giro_bank.Clone()
                    kas_bukti = retur_beli_bukti.Clone()
                    kas_tgl = retur_beli_tgl.Clone()
                    kas_sales = jual_sales.Clone()
                    kas_debet = hutang_debet.Clone()
                    kas_kredit = hutang_kredit.Clone()
                    kas_user = user_id.Clone()
                    kas_jenis = hutang_jenis.Clone()
                    kas_status = gudang_status.Clone()

                    kas_jenis.HeaderText = "Jenis"
                    kas_debet.HeaderText = "Total Debet"
                    kas_bank.Width = 150

                    .add_sw = IIf(selectperiode.closed = True, False, True)
                    .cancel_sw = IIf(selectperiode.closed = True, False, loggeduser.validasi_akun)
                    .del_sw = False

                    Dim x As DataGridViewColumn() = {kas_bank, kas_bukti, kas_jenis, kas_tgl, kas_sales, kas_debet, kas_kredit, kas_user, kas_status}
                    For i = 0 To x.Count - 1
                        x(i).DisplayIndex = i
                    Next

                    .dgv_list.AutoGenerateColumns = False
                    .dgv_list.Columns.AddRange(x)

                End With
                'Exit Sub


            Case "jurnalumum"
                With frmjurnalumum
                    Dim jurnal_u_id = New DataGridViewColumn()
                    Dim jurnal_u_kredit = New DataGridViewColumn()
                    Dim jurnal_u_debet = New DataGridViewColumn()
                    Dim jurnal_u_tgl = New DataGridViewColumn()
                    Dim jurnal_u_bukti = New DataGridViewColumn()
                    Dim jurnal_u_ref = New DataGridViewColumn()
                    Dim jurnal_u_jenpajak = New DataGridViewColumn()

                    jurnal_u_id = gudang_kode.Clone()
                    jurnal_u_bukti = jual_faktur.Clone()
                    jurnal_u_tgl = beli_tgl.Clone()
                    jurnal_u_debet = hutang_debet.Clone()
                    jurnal_u_kredit = hutang_kredit.Clone()
                    jurnal_u_ref = group_ket.Clone()
                    jurnal_u_jenpajak = gudang_status.Clone()

                    jurnal_u_jenpajak.Width = 50
                    jurnal_u_jenpajak.Name = "jenpajak"
                    jurnal_u_jenpajak.HeaderText = "Kat."
                    jurnal_u_jenpajak.DataPropertyName = "jenispajak"

                    jurnal_u_id.HeaderText = "ID"
                    jurnal_u_bukti.HeaderText = "Kode Transaksi"
                    jurnal_u_debet.HeaderText = "Total Debet"
                    jurnal_u_kredit.HeaderText = "Total Kredit"
                    jurnal_u_ref.HeaderText = "Keterangan"

                    jurnal_u_id.DataPropertyName = "ju_id"
                    jurnal_u_tgl.DataPropertyName = "ju_tgl"
                    jurnal_u_bukti.DataPropertyName = "ju_kode"
                    jurnal_u_ref.DataPropertyName = "ju_ref"

                    jurnal_u_id.Width = 60
                    jurnal_u_id.Visible = True
                    jurnal_u_bukti.Width = 150
                    jurnal_u_ref.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

                    .add_sw = False
                    '.edit_sw = False
                    .del_sw = False
                    .mn_edit.Text = "Lihat Detail"

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {jurnal_u_id, jurnal_u_jenpajak, jurnal_u_tgl, jurnal_u_bukti, jurnal_u_jenis, jurnal_u_debet, jurnal_u_kredit,
                                                         jurnal_u_ref}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With

            Case "jurnalmemorial"
                With frmjurnalmemorial
                    Dim jurnal_e_tgl = New DataGridViewColumn()
                    Dim jurnal_e_bukti = New DataGridViewColumn()
                    Dim jurnal_e_ket = New DataGridViewColumn()
                    jurnal_e_tgl = beli_tgl.Clone()
                    jurnal_e_bukti = retur_beli_bukti.Clone()
                    jurnal_e_ket = group_ket.Clone()

                    With .dgv_list
                        .AutoGenerateColumns = False
                        .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {jurnal_e_tgl, jurnal_e_bukti, jurnal_e_ket})
                        For i = 0 To .Columns.Count - 1
                            .Columns(i).DisplayIndex = i
                        Next
                    End With
                End With
            Case "group"
                With frmgroup
                    Dim group_status = New DataGridViewColumn()
                    group_status = gudang_status.Clone()
                    .export_sw = False
                    .del_sw = False

                    With .dgv_list
                        Dim x As DataGridViewColumn() = {group_kode, group_nama, group_jmlmenu, group_ket, group_status}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With
            Case "user"
                With frmuser
                    Dim user_lastlogin = New DataGridViewColumn()
                    Dim user_android = New DataGridViewColumn()
                    Dim user_sales = New DataGridViewColumn()

                    user_lastlogin = beli_tgl.Clone()
                    user_android = gudang_status.Clone()
                    user_sales = jual_sales.Clone()

                    .del_sw = False

                    user_lastlogin.HeaderText = "Login PC Terakhir"
                    user_lastlogin.DataPropertyName = "lastlogin"
                    user_android.HeaderText = "Android"
                    user_android.DataPropertyName = "androsales"
                    With .dgv_list
                        Dim x As DataGridViewColumn() = {user_id, user_nama, user_status, user_logstat, user_lastlogin, user_group, user_group_nama,
                                                         user_android, user_sales}
                        For i = 0 To x.Count - 1
                            x(i).DisplayIndex = i
                        Next

                        .AutoGenerateColumns = False
                        .Columns.AddRange(x)
                    End With
                End With
            Case Else
                Exit Sub
        End Select
    End Sub

    Public Sub populateDGVUserCon(type As String, param As String, dgv As DataGridView)
        Dim bs As New BindingSource
        Dim q As String = ""
        Dim p As String = ""
        Dim colsort As DataGridViewColumn
        Dim dirsort As System.ComponentModel.ListSortDirection
        Dim _tglawal As String = selectperiode.tglawal.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = selectperiode.tglakhir.ToString("yyyy-MM-dd")

        Select Case type

            Case "barang"
                q = "getDataMaster('barang','" & param & "')"
                p = "nama LIKE '%{0}%' OR kode LIKE '{0}%' OR kodesupplier LIKE '{0}%' OR supplier LIKE '%{0}%' OR status LIKE '{0}%'"
                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "gudang"
                q = "getDataMaster('gudang','" & param & "')"
                p = "nama LIKE '%{0}%' OR kode LIKE '{0}%' OR alamat LIKE '%{0}%' OR status LIKE '{0}%'"
                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "supplier"
                q = "getDataMaster('supplier','" & param & "')"
                p = "nama LIKE '{0}%' OR kode LIKE '{0}%' OR alamat LIKE '%{0}%' OR cp LIKE '{0}%' OR status LIKE '{0}%'"
                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "sales"
                q = "getDataMaster('sales','" & param & "')"
                p = "nama LIKE '{0}%' OR kode LIKE '{0}%' OR alamat LIKE '%{0}%' OR status LIKE '{0}%' OR jenis LIKE '{0}%'"
                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "custo"
                q = "CALL getDataMaster('custo','" & param & "')"
                p = "nama LIKE '{0}%' OR kode LIKE '{0}%' OR tipe LIKE '{0}%' OR alamat LIKE '{0}%' OR kec LIKE '{0}%' OR kab LIKE '{0}%' OR pasar LIKE '{0}%' " _
                    & "OR telp LIKE '{0}%' OR fax LIKE '{0}%'"
                bs = populateDGVUserConTemp(q, "")

                colsort = dgv.Columns(1)
                dirsort = System.ComponentModel.ListSortDirection.Ascending

            Case "giro"
                q = "getDataMaster('giro','" & param & "')"
                Dim pDefault As String = "nobg LIKE '{0}%' OR tgl LIKE '{0}%' OR tglefektif LIKE '{0}%' OR tglcair LIKE '{0}%' " _
                                         & "OR sales LIKE '{0}%' OR custo LIKE '{0}%' OR bukti LIKE '{0}%' OR giro_akuncair_n LIKE '{0}%' OR status LIKE '{0}%'"
                Dim pNumeric As String = "jml={0}"
                p = IIf(IsNumeric(param), pNumeric, pDefault)
                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "perkiraan"
                q = "getDataMasterAkun('perkiraan','" & selectperiode.id & "')"
                Dim pDefault As String = "kode LIKE '%{0}%' OR nama LIKE '%{0}%' OR jenis LIKE '%{0}%' OR posisi LIKE '%{0}%' OR status LIKE '%{0}%' OR userid LIKE '%{0}%'"
                Dim pNumeric As String = "saldo_awal={0}"
                p = IIf(IsNumeric(param), pNumeric, pDefault)
                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "neracaawal"
                Exit Sub

            Case "beli"
                q = "getTableTrans('beli','{0}','{1}','{2}')"
                q = String.Format(q, _tglawal, _tglakhir, param)
                Dim pDefault As String = ""
                Dim pNumeric As String = ""
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "returbeli"
                q = "getTableTrans('rbeli','{0}','{1}','{2}')"
                q = String.Format(q, _tglawal, _tglakhir, param)
                Dim pDefault As String = ""
                Dim pNumeric As String = ""
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "pesanan"
                q = "CALL getTableTrans('pesanan','{0}','{1}','{2}')"
                q = String.Format(q, _tglawal, _tglakhir, param)
                Dim pDefault As String = ""
                Dim pNumeric As String = ""
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                bs = populateDGVUserConTemp(q, String.Format(p, param))

                colsort = dgv.Columns(0)
                dirsort = System.ComponentModel.ListSortDirection.Descending
                'Exit Sub

            Case "jual"
                q = "getTableTrans('jual','{0}','{1}','{2}')"
                q = String.Format(q, _tglawal, _tglakhir, param)
                Dim pDefault As String = ""
                Dim pNumeric As String = ""
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "returjual"
                q = "getTableTrans('rjual','{0}','{1}','{2}')"
                q = String.Format(q, _tglawal, _tglakhir, param)
                Dim pDefault As String = ""
                Dim pNumeric As String = ""
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "stok"
                'q = "CALL createDataStockTableTemp('" & selectperiode.id & "'); SELECT * FROM stock_temp;"
                q = "getDataStockTable('" & selectperiode.id & "')"
                Dim pAlphabet As String = "barang_nama LIKE '{0}%' OR gudang_nama LIKE '{0}%' OR stock_status LIKE '{0}%'"
                Dim pNumeric As String = "stock_sisa ='{0}' OR stock_sisastockop={0}"
                p = IIf(IsNumeric(param), pNumeric, pAlphabet)

                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "mutasigudang"
                q = "getDataStockTransTable('mutasigudang','{0}','{1}')"
                q = String.Format(q, selectperiode.id, param)
                Dim pDefault As String = ""
                Dim pNumeric As String = ""
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "mutasistok"
                q = "getDataStockTransTable('mutasibarang','{0}','{1}')"
                q = String.Format(q, selectperiode.id, param)
                Dim pDefault As String = ""
                Dim pNumeric As String = ""
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "stockop"
                q = "getDataStockTransTable('stockop','{0}','{1}')"
                q = String.Format(q, selectperiode.id, param)
                Dim pDefault As String = ""
                Dim pNumeric As String = ""
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "hutangawal"
                q = "getDataHutangTable('{0}','awal','{1}')"
                q = String.Format(q, selectperiode.id, param)
                Dim pDefault As String = ""
                Dim pNumeric As String = "hutang_sisa={0} OR term={0}"
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "hutangbayar"
                q = "getDataHutangTable('{0}','bayar','{1}')"
                q = String.Format(q, selectperiode.id, param)
                Dim pDefault As String = ""
                Dim pNumeric As String = ""
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "hutangbgo"
                q = "getDataHutangTable('{0}','bgo','{1}')"
                q = String.Format(q, selectperiode.id, param)
                Dim pDefault As String = ""
                Dim pNumeric As String = ""
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "piutangawal"
                q = "getDataPiutangTable('{0}','awal','{1}')"
                q = String.Format(q, selectperiode.id, param)
                Dim pDefault As String = ""
                Dim pNumeric As String = ""
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "piutangbayar"
                q = "getDataPiutangTable('{0}','bayar','{1}')"
                q = String.Format(q, selectperiode.id, param)
                Dim pDefault As String = ""
                Dim pNumeric As String = ""
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "piutangbgcair"
                q = "getDataPiutangTable('{0}','bgi','{1}')"
                q = String.Format(q, selectperiode.id, param)
                Dim pDefault As String = ""
                Dim pNumeric As String = ""
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "piutangbgtolak"
                Exit Sub
                'q = "getDataPiutangTable('" & selectperiode.id & "','bgitolak')"
                'Dim pDefault As String = "nobg LIKE '{0}%' OR bank LIKE '{0}%' OR tgl LIKE '{0}%' OR tglbg LIKE '{0}%' OR tgltolak LIKE '{0}%'"
                'Dim pNumeric As String = "jml={0}"
                'p = IIf(IsNumeric(param), pNumeric, pDefault)

                'bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "kas"
                q = "getDataAkunTable('kas','" & selectperiode.tglawal.ToString("yyyy-MM-dd") & "','" & selectperiode.tglakhir.ToString("yyyy-MM-dd") & "')"
                Dim pDefault As String = "bank LIKE '{0}%' OR tanggal LIKE '{0}%' OR sales LIKE '{0}%' OR userid LIKE '{0}%' OR bukti LIKE '{0}%'"
                Dim pNumeric As String = "kredit={0} OR debet={0}"
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                colsort = dgv.Columns(3)
                dirsort = System.ComponentModel.ListSortDirection.Descending

                bs = populateDGVUserConTemp(q, String.Format(p, param))

            Case "jurnalumum"
                q = "getDataAkunTable('jurnalumum','{0}','{1}')"
                Dim pDefault As String = "ju_kode LIKE '{0}%' OR ju_tgl LIKE '{0}%' OR ju_type LIKE '{0}%' OR ju_ref LIKE '%{0}%'"
                Dim pNumeric As String = "kredit={0} OR debet={0}"
                p = IIf(IsNumeric(param), pNumeric, pDefault)
                'p = ""

                bs = populateDGVUserConTemp(String.Format(q, selectperiode.tglawal.ToString("yyyy-MM-dd"), selectperiode.tglakhir.ToString("yyyy-MM-dd")),
                                            String.Format(p, param))

            Case "jurnalmemorial"
                Exit Sub
            Case "group"
                bs = populateDGVUserConTemp("getDataMaster('group','" & param & "')", "nama LIKE '%" & param & "%'")
            Case "user"
                q = "getDataMaster('user','" & param & "')"
                Dim pDefault As String = "nama LIKE '{0}%' OR userid LIKE '{0}%' OR groupnama LIKE '{0}%' OR status LIKE '{0}%' " _
                                         & "OR loginstat LIKE '{0}%' OR lastlogin LIKE '{0}%' OR sales LIKE '{0}%'"
                Dim pNumeric As String = ""
                p = IIf(IsNumeric(param), pNumeric, pDefault)

                consoleWriteLine(q)

                bs = populateDGVUserConTemp(q, String.Format(p, param))
            Case Else
                Exit Sub
        End Select
        With dgv
            .RowHeadersWidth = 20
            .DataSource = bs
            Console.WriteLine("dgv" & .RowCount)
            If IsNothing(colsort) = False And dirsort <> Nothing Then
                dgv.Sort(colsort, dirsort)
            End If
        End With
    End Sub

    Private Function populateDGVUserConTemp(query As String, paramQuery As String) As BindingSource
        Dim bs As New BindingSource
        Try
            bs.DataSource = getDataTablefromDB(query)
            consoleWriteLine("bs" & bs.Count.ToString & " " & paramQuery)
            bs.Filter = paramQuery
        Catch ex As Exception
            consoleWriteLine(ex.Message)
            logError(ex)
            bs = Nothing
        End Try
        Return bs
    End Function

    Public Sub refreshTabPage(tabpg As String)
        Dim fr As fr_list
        Select Case tabpg
            Case "pgbarang"
                fr = frmbarang
            Case "pgsupplier"
                fr = frmsupplier
            Case "pggudang"
                fr = frmgudang
            Case "pgsales"
                fr = frmsales
            Case "pgcusto"
                fr = frmcusto
            Case "pgbank"
                fr = frmbank
            Case "pgbgtangan"
                fr = frmbgditangan
            Case "pgperkiraan"
                fr = frmperkiraan
            Case "pgawalneraca"
                fr = frmawalneraca
            Case "pgpembelian"
                fr = frmpembelian
            Case "pgreturbeli"
                fr = frmreturbeli
            Case "pgpesanjual"
                fr = frmpesanjual
            Case "pgpenjualan"
                fr = frmpenjualan
            Case "pgreturjual"
                fr = frmreturjual
            Case "pgdrafttagihan"
                frmtagihan.performRefresh()
                Exit Sub
            Case "pgrekap"
                frmrekap.performRefresh()
                Exit Sub
            Case "pgstok"
                fr = frmstok
            Case "pgmutasigudang"
                frmmutasigudang.performRefresh()
                Exit Sub
            Case "pgmutasistok"
                frmmutasistok.performRefresh()
                Exit Sub
            Case "pgstockop"
                frmstockop.performRefresh()
                Exit Sub
            Case "pghutangawal"
                fr = frmhutangawal
            Case "pghutangbayar"
                fr = frmhutangbayar
            Case "pghutangbgo"
                fr = frmhutangbgo
            Case "pgpiutangawal"
                fr = frmpiutangawal
            Case "pgpiutangbayar"
                fr = frmpiutangbayar
            Case "pgpiutangbgcair"
                fr = frmpiutangbgcair
            Case "pgpiutangbgtolak"
                fr = frmpiutangbgTolak
            Case "pgkas"
                fr = frmkas
            Case "pgjurnalumum"
                fr = frmjurnalumum
            Case "pgjurnalmemorial"
                fr = frmjurnalmemorial
            Case "pgtutupbuku"
                frmtutupbuku.performRefresh()
                Exit Sub
            Case "pgkartustok"
                frmkartustok.performRefresh()
                Exit Sub
            Case "pguser"
                fr = frmuser
            Case "pggroup"
                fr = frmgroup
            Case Else
                Exit Sub
        End Select

        fr.add_sw = IIf(selectperiode.closed = True, False, True)
        fr.performRefresh()

    End Sub
End Module