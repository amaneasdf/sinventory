<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_beli_retur_detail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_judul = New System.Windows.Forms.Label()
        Me.lbl_supplier = New System.Windows.Forms.Label()
        Me.lbl_gudang = New System.Windows.Forms.Label()
        Me.date_tgl_trans = New System.Windows.Forms.DateTimePicker()
        Me.date_tgl_pajak = New System.Windows.Forms.DateTimePicker()
        Me.in_supplier = New System.Windows.Forms.TextBox()
        Me.in_no_faktur = New System.Windows.Forms.TextBox()
        Me.in_gudang = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.in_pajak = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.in_no_bukti = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.in_no_faktur_ex = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.in_suratjalan = New System.Windows.Forms.TextBox()
        Me.cb_bayar_jenis = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cb_ppn_jenis = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.in_ppn_persen = New System.Windows.Forms.NumericUpDown()
        Me.in_netto = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.in_jumlah = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cb_status = New System.Windows.Forms.ComboBox()
        Me.in_status_kode = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.bt_batalreturbeli = New System.Windows.Forms.Button()
        Me.bt_simpanreturbeli = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cb_sat = New System.Windows.Forms.ComboBox()
        Me.dgv_barang = New System.Windows.Forms.DataGridView()
        Me.kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.harga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jml = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.in_barang = New System.Windows.Forms.TextBox()
        Me.lbl_barang = New System.Windows.Forms.Label()
        Me.in_harga_retur = New System.Windows.Forms.NumericUpDown()
        Me.in_qty = New System.Windows.Forms.NumericUpDown()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.in_ppn_persen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_harga_retur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.lbl_judul)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(859, 42)
        Me.Panel1.TabIndex = 181
        '
        'lbl_judul
        '
        Me.lbl_judul.AutoSize = True
        Me.lbl_judul.BackColor = System.Drawing.Color.Orange
        Me.lbl_judul.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_judul.Location = New System.Drawing.Point(18, 9)
        Me.lbl_judul.Name = "lbl_judul"
        Me.lbl_judul.Size = New System.Drawing.Size(188, 20)
        Me.lbl_judul.TabIndex = 178
        Me.lbl_judul.Text = "Form Retur Pembelian"
        '
        'lbl_supplier
        '
        Me.lbl_supplier.AutoSize = True
        Me.lbl_supplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_supplier.Location = New System.Drawing.Point(588, 104)
        Me.lbl_supplier.MaximumSize = New System.Drawing.Size(300, 15)
        Me.lbl_supplier.Name = "lbl_supplier"
        Me.lbl_supplier.Size = New System.Drawing.Size(36, 15)
        Me.lbl_supplier.TabIndex = 201
        Me.lbl_supplier.Text = "Term"
        '
        'lbl_gudang
        '
        Me.lbl_gudang.AutoSize = True
        Me.lbl_gudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_gudang.Location = New System.Drawing.Point(588, 76)
        Me.lbl_gudang.MaximumSize = New System.Drawing.Size(300, 15)
        Me.lbl_gudang.Name = "lbl_gudang"
        Me.lbl_gudang.Size = New System.Drawing.Size(36, 15)
        Me.lbl_gudang.TabIndex = 208
        Me.lbl_gudang.Text = "Term"
        '
        'date_tgl_trans
        '
        Me.date_tgl_trans.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_trans.Location = New System.Drawing.Point(102, 74)
        Me.date_tgl_trans.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_trans.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_trans.Name = "date_tgl_trans"
        Me.date_tgl_trans.Size = New System.Drawing.Size(188, 21)
        Me.date_tgl_trans.TabIndex = 1
        '
        'date_tgl_pajak
        '
        Me.date_tgl_pajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_pajak.Location = New System.Drawing.Point(102, 182)
        Me.date_tgl_pajak.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_pajak.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_pajak.Name = "date_tgl_pajak"
        Me.date_tgl_pajak.Size = New System.Drawing.Size(188, 21)
        Me.date_tgl_pajak.TabIndex = 5
        '
        'in_supplier
        '
        Me.in_supplier.BackColor = System.Drawing.Color.White
        Me.in_supplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier.ForeColor = System.Drawing.Color.Black
        Me.in_supplier.Location = New System.Drawing.Point(394, 101)
        Me.in_supplier.MaxLength = 10
        Me.in_supplier.Name = "in_supplier"
        Me.in_supplier.Size = New System.Drawing.Size(188, 21)
        Me.in_supplier.TabIndex = 8
        '
        'in_no_faktur
        '
        Me.in_no_faktur.BackColor = System.Drawing.Color.White
        Me.in_no_faktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_no_faktur.ForeColor = System.Drawing.Color.Black
        Me.in_no_faktur.Location = New System.Drawing.Point(102, 101)
        Me.in_no_faktur.MaxLength = 30
        Me.in_no_faktur.Name = "in_no_faktur"
        Me.in_no_faktur.Size = New System.Drawing.Size(188, 21)
        Me.in_no_faktur.TabIndex = 2
        '
        'in_gudang
        '
        Me.in_gudang.BackColor = System.Drawing.Color.White
        Me.in_gudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang.ForeColor = System.Drawing.Color.Black
        Me.in_gudang.Location = New System.Drawing.Point(394, 74)
        Me.in_gudang.MaxLength = 10
        Me.in_gudang.Name = "in_gudang"
        Me.in_gudang.Size = New System.Drawing.Size(188, 21)
        Me.in_gudang.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(19, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 15)
        Me.Label9.TabIndex = 206
        Me.Label9.Text = "No.Faktur"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(313, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 15)
        Me.Label7.TabIndex = 205
        Me.Label7.Text = "Supplier"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(313, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 15)
        Me.Label6.TabIndex = 209
        Me.Label6.Text = "Gudang"
        '
        'in_pajak
        '
        Me.in_pajak.BackColor = System.Drawing.Color.White
        Me.in_pajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_pajak.ForeColor = System.Drawing.Color.Black
        Me.in_pajak.Location = New System.Drawing.Point(102, 155)
        Me.in_pajak.MaxLength = 20
        Me.in_pajak.Name = "in_pajak"
        Me.in_pajak.Size = New System.Drawing.Size(188, 21)
        Me.in_pajak.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 15)
        Me.Label3.TabIndex = 203
        Me.Label3.Text = "Tgl. Pajak"
        '
        'in_no_bukti
        '
        Me.in_no_bukti.BackColor = System.Drawing.Color.White
        Me.in_no_bukti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_no_bukti.ForeColor = System.Drawing.Color.Black
        Me.in_no_bukti.Location = New System.Drawing.Point(102, 48)
        Me.in_no_bukti.MaxLength = 30
        Me.in_no_bukti.Name = "in_no_bukti"
        Me.in_no_bukti.Size = New System.Drawing.Size(188, 21)
        Me.in_no_bukti.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 202
        Me.Label2.Text = "No.Pajak"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 15)
        Me.Label1.TabIndex = 207
        Me.Label1.Text = "Tgl"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 15)
        Me.Label4.TabIndex = 210
        Me.Label4.Text = "No. Bukti"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(19, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 15)
        Me.Label8.TabIndex = 206
        Me.Label8.Text = "Ex.No.Faktur"
        '
        'in_no_faktur_ex
        '
        Me.in_no_faktur_ex.BackColor = System.Drawing.Color.White
        Me.in_no_faktur_ex.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_no_faktur_ex.ForeColor = System.Drawing.Color.Black
        Me.in_no_faktur_ex.Location = New System.Drawing.Point(102, 128)
        Me.in_no_faktur_ex.MaxLength = 30
        Me.in_no_faktur_ex.Name = "in_no_faktur_ex"
        Me.in_no_faktur_ex.Size = New System.Drawing.Size(188, 21)
        Me.in_no_faktur_ex.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(313, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 15)
        Me.Label5.TabIndex = 205
        Me.Label5.Text = "Jenis Bayar"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(313, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 15)
        Me.Label10.TabIndex = 205
        Me.Label10.Text = "Surat Jalan"
        '
        'in_suratjalan
        '
        Me.in_suratjalan.BackColor = System.Drawing.Color.White
        Me.in_suratjalan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_suratjalan.ForeColor = System.Drawing.Color.Black
        Me.in_suratjalan.Location = New System.Drawing.Point(394, 48)
        Me.in_suratjalan.MaxLength = 10
        Me.in_suratjalan.Name = "in_suratjalan"
        Me.in_suratjalan.Size = New System.Drawing.Size(188, 21)
        Me.in_suratjalan.TabIndex = 6
        '
        'cb_bayar_jenis
        '
        Me.cb_bayar_jenis.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_bayar_jenis.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_bayar_jenis.BackColor = System.Drawing.Color.White
        Me.cb_bayar_jenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_bayar_jenis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cb_bayar_jenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_bayar_jenis.FormattingEnabled = True
        Me.cb_bayar_jenis.Location = New System.Drawing.Point(394, 126)
        Me.cb_bayar_jenis.Name = "cb_bayar_jenis"
        Me.cb_bayar_jenis.Size = New System.Drawing.Size(188, 23)
        Me.cb_bayar_jenis.TabIndex = 8
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cb_ppn_jenis)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.in_ppn_persen)
        Me.GroupBox3.Controls.Add(Me.in_netto)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.in_jumlah)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Location = New System.Drawing.Point(680, 209)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(169, 215)
        Me.GroupBox3.TabIndex = 244
        Me.GroupBox3.TabStop = False
        '
        'cb_ppn_jenis
        '
        Me.cb_ppn_jenis.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_ppn_jenis.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_ppn_jenis.BackColor = System.Drawing.Color.White
        Me.cb_ppn_jenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_ppn_jenis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cb_ppn_jenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_ppn_jenis.FormattingEnabled = True
        Me.cb_ppn_jenis.Location = New System.Drawing.Point(6, 128)
        Me.cb_ppn_jenis.Name = "cb_ppn_jenis"
        Me.cb_ppn_jenis.Size = New System.Drawing.Size(157, 23)
        Me.cb_ppn_jenis.TabIndex = 15
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(140, 89)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(18, 15)
        Me.Label20.TabIndex = 192
        Me.Label20.Text = "%"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 68)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 15)
        Me.Label15.TabIndex = 192
        Me.Label15.Text = "PPN"
        '
        'in_ppn_persen
        '
        Me.in_ppn_persen.BackColor = System.Drawing.Color.White
        Me.in_ppn_persen.DecimalPlaces = 2
        Me.in_ppn_persen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ppn_persen.ForeColor = System.Drawing.Color.Black
        Me.in_ppn_persen.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.in_ppn_persen.Location = New System.Drawing.Point(6, 87)
        Me.in_ppn_persen.Name = "in_ppn_persen"
        Me.in_ppn_persen.Size = New System.Drawing.Size(128, 22)
        Me.in_ppn_persen.TabIndex = 14
        Me.in_ppn_persen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_ppn_persen.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'in_netto
        '
        Me.in_netto.BackColor = System.Drawing.Color.White
        Me.in_netto.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_netto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_netto.ForeColor = System.Drawing.Color.Black
        Me.in_netto.Location = New System.Drawing.Point(6, 180)
        Me.in_netto.MaxLength = 20
        Me.in_netto.Name = "in_netto"
        Me.in_netto.ReadOnly = True
        Me.in_netto.Size = New System.Drawing.Size(157, 26)
        Me.in_netto.TabIndex = 16
        Me.in_netto.TabStop = False
        Me.in_netto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 162)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 18)
        Me.Label17.TabIndex = 192
        Me.Label17.Text = "NETTO"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(3, 110)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 15)
        Me.Label16.TabIndex = 192
        Me.Label16.Text = "Jenis PPN"
        '
        'in_jumlah
        '
        Me.in_jumlah.BackColor = System.Drawing.Color.White
        Me.in_jumlah.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_jumlah.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_jumlah.ForeColor = System.Drawing.Color.Black
        Me.in_jumlah.Location = New System.Drawing.Point(6, 44)
        Me.in_jumlah.MaxLength = 20
        Me.in_jumlah.Name = "in_jumlah"
        Me.in_jumlah.ReadOnly = True
        Me.in_jumlah.Size = New System.Drawing.Size(157, 21)
        Me.in_jumlah.TabIndex = 13
        Me.in_jumlah.TabStop = False
        Me.in_jumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 15)
        Me.Label11.TabIndex = 192
        Me.Label11.Text = "Jumlah"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cb_status)
        Me.GroupBox4.Controls.Add(Me.in_status_kode)
        Me.GroupBox4.Location = New System.Drawing.Point(261, 460)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(240, 44)
        Me.GroupBox4.TabIndex = 243
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Status"
        Me.GroupBox4.Visible = False
        '
        'cb_status
        '
        Me.cb_status.BackColor = System.Drawing.Color.White
        Me.cb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cb_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_status.FormattingEnabled = True
        Me.cb_status.Location = New System.Drawing.Point(66, 16)
        Me.cb_status.Name = "cb_status"
        Me.cb_status.Size = New System.Drawing.Size(167, 23)
        Me.cb_status.TabIndex = 27
        '
        'in_status_kode
        '
        Me.in_status_kode.BackColor = System.Drawing.Color.White
        Me.in_status_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status_kode.ForeColor = System.Drawing.Color.Black
        Me.in_status_kode.Location = New System.Drawing.Point(6, 16)
        Me.in_status_kode.Name = "in_status_kode"
        Me.in_status_kode.ReadOnly = True
        Me.in_status_kode.Size = New System.Drawing.Size(49, 22)
        Me.in_status_kode.TabIndex = 243
        Me.in_status_kode.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtRegAlias)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.txtRegdate)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 460)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(243, 72)
        Me.GroupBox2.TabIndex = 242
        Me.GroupBox2.TabStop = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(81, 44)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(150, 22)
        Me.txtRegAlias.TabIndex = 116
        Me.txtRegAlias.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(9, 47)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(67, 16)
        Me.Label27.TabIndex = 119
        Me.Label27.Text = "Reg Alias"
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(81, 16)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(150, 22)
        Me.txtRegdate.TabIndex = 115
        Me.txtRegdate.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(9, 19)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(66, 16)
        Me.Label29.TabIndex = 118
        Me.Label29.Text = "Reg Date"
        '
        'bt_batalreturbeli
        '
        Me.bt_batalreturbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalreturbeli.Location = New System.Drawing.Point(753, 507)
        Me.bt_batalreturbeli.Name = "bt_batalreturbeli"
        Me.bt_batalreturbeli.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalreturbeli.TabIndex = 18
        Me.bt_batalreturbeli.Text = "Batal"
        Me.bt_batalreturbeli.UseVisualStyleBackColor = True
        '
        'bt_simpanreturbeli
        '
        Me.bt_simpanreturbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanreturbeli.Location = New System.Drawing.Point(651, 507)
        Me.bt_simpanreturbeli.Name = "bt_simpanreturbeli"
        Me.bt_simpanreturbeli.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpanreturbeli.TabIndex = 17
        Me.bt_simpanreturbeli.Text = "Simpan"
        Me.bt_simpanreturbeli.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_sat)
        Me.GroupBox1.Controls.Add(Me.dgv_barang)
        Me.GroupBox1.Controls.Add(Me.in_barang)
        Me.GroupBox1.Controls.Add(Me.lbl_barang)
        Me.GroupBox1.Controls.Add(Me.in_harga_retur)
        Me.GroupBox1.Controls.Add(Me.in_qty)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(18, 209)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(656, 241)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Barang"
        '
        'cb_sat
        '
        Me.cb_sat.BackColor = System.Drawing.Color.White
        Me.cb_sat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_sat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cb_sat.FormattingEnabled = True
        Me.cb_sat.Location = New System.Drawing.Point(356, 19)
        Me.cb_sat.Name = "cb_sat"
        Me.cb_sat.Size = New System.Drawing.Size(62, 23)
        Me.cb_sat.TabIndex = 11
        '
        'dgv_barang
        '
        Me.dgv_barang.AllowUserToAddRows = False
        Me.dgv_barang.AllowUserToDeleteRows = False
        Me.dgv_barang.BackgroundColor = System.Drawing.Color.White
        Me.dgv_barang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_barang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kode, Me.nama, Me.qty, Me.sat, Me.harga, Me.jml})
        Me.dgv_barang.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgv_barang.Location = New System.Drawing.Point(3, 47)
        Me.dgv_barang.Name = "dgv_barang"
        Me.dgv_barang.ReadOnly = True
        Me.dgv_barang.RowHeadersVisible = False
        Me.dgv_barang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_barang.Size = New System.Drawing.Size(650, 191)
        Me.dgv_barang.TabIndex = 18
        '
        'kode
        '
        Me.kode.DataPropertyName = "trans_barang"
        Me.kode.HeaderText = "Kode"
        Me.kode.Name = "kode"
        Me.kode.ReadOnly = True
        '
        'nama
        '
        Me.nama.DataPropertyName = "barang_nama"
        Me.nama.HeaderText = "Nama Barang"
        Me.nama.MinimumWidth = 190
        Me.nama.Name = "nama"
        Me.nama.ReadOnly = True
        Me.nama.Width = 190
        '
        'qty
        '
        Me.qty.DataPropertyName = "trans_qty"
        Me.qty.HeaderText = "QTY"
        Me.qty.MinimumWidth = 60
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        Me.qty.Width = 60
        '
        'sat
        '
        Me.sat.DataPropertyName = "trans_satuan"
        Me.sat.HeaderText = "Satuan"
        Me.sat.MinimumWidth = 60
        Me.sat.Name = "sat"
        Me.sat.ReadOnly = True
        Me.sat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.sat.Width = 60
        '
        'harga
        '
        Me.harga.DataPropertyName = "trans_harga_retur"
        Me.harga.HeaderText = "Harga Retur"
        Me.harga.MinimumWidth = 110
        Me.harga.Name = "harga"
        Me.harga.ReadOnly = True
        Me.harga.Width = 110
        '
        'jml
        '
        Me.jml.DataPropertyName = "trans_jumlah"
        Me.jml.HeaderText = "Jumlah"
        Me.jml.Name = "jml"
        Me.jml.ReadOnly = True
        '
        'in_barang
        '
        Me.in_barang.BackColor = System.Drawing.Color.White
        Me.in_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang.ForeColor = System.Drawing.Color.Black
        Me.in_barang.Location = New System.Drawing.Point(6, 21)
        Me.in_barang.Name = "in_barang"
        Me.in_barang.Size = New System.Drawing.Size(100, 20)
        Me.in_barang.TabIndex = 9
        '
        'lbl_barang
        '
        Me.lbl_barang.AutoSize = True
        Me.lbl_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_barang.Location = New System.Drawing.Point(112, 24)
        Me.lbl_barang.MaximumSize = New System.Drawing.Size(250, 16)
        Me.lbl_barang.Name = "lbl_barang"
        Me.lbl_barang.Size = New System.Drawing.Size(31, 13)
        Me.lbl_barang.TabIndex = 192
        Me.lbl_barang.Text = "Term"
        '
        'in_harga_retur
        '
        Me.in_harga_retur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_harga_retur.Location = New System.Drawing.Point(424, 21)
        Me.in_harga_retur.Maximum = New Decimal(New Integer() {-1981284353, -1966660860, 0, 0})
        Me.in_harga_retur.Name = "in_harga_retur"
        Me.in_harga_retur.Size = New System.Drawing.Size(140, 20)
        Me.in_harga_retur.TabIndex = 12
        Me.in_harga_retur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_qty
        '
        Me.in_qty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty.Location = New System.Drawing.Point(298, 21)
        Me.in_qty.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.in_qty.Name = "in_qty"
        Me.in_qty.Size = New System.Drawing.Size(52, 20)
        Me.in_qty.TabIndex = 10
        Me.in_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fr_beli_retur_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 544)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bt_batalreturbeli)
        Me.Controls.Add(Me.bt_simpanreturbeli)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cb_bayar_jenis)
        Me.Controls.Add(Me.lbl_supplier)
        Me.Controls.Add(Me.lbl_gudang)
        Me.Controls.Add(Me.date_tgl_trans)
        Me.Controls.Add(Me.date_tgl_pajak)
        Me.Controls.Add(Me.in_suratjalan)
        Me.Controls.Add(Me.in_supplier)
        Me.Controls.Add(Me.in_no_faktur_ex)
        Me.Controls.Add(Me.in_no_faktur)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.in_gudang)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.in_pajak)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.in_no_bukti)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "fr_beli_retur_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Retur Pembelian : "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.in_ppn_persen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_harga_retur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_qty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_judul As System.Windows.Forms.Label
    Friend WithEvents lbl_supplier As System.Windows.Forms.Label
    Friend WithEvents lbl_gudang As System.Windows.Forms.Label
    Friend WithEvents date_tgl_trans As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_tgl_pajak As System.Windows.Forms.DateTimePicker
    Friend WithEvents in_supplier As System.Windows.Forms.TextBox
    Friend WithEvents in_no_faktur As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents in_pajak As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents in_no_bukti As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents in_no_faktur_ex As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents in_suratjalan As System.Windows.Forms.TextBox
    Friend WithEvents cb_bayar_jenis As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_ppn_jenis As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents in_ppn_persen As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_netto As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents in_jumlah As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_status As System.Windows.Forms.ComboBox
    Friend WithEvents in_status_kode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents bt_batalreturbeli As System.Windows.Forms.Button
    Friend WithEvents bt_simpanreturbeli As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_barang As System.Windows.Forms.DataGridView
    Friend WithEvents kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents harga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jml As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents in_barang As System.Windows.Forms.TextBox
    Friend WithEvents lbl_barang As System.Windows.Forms.Label
    Friend WithEvents in_qty As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_harga_retur As System.Windows.Forms.NumericUpDown
    Friend WithEvents cb_sat As System.Windows.Forms.ComboBox
End Class
