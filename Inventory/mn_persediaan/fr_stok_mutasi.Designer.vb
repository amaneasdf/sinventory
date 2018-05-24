<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_stok_mutasi
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.in_gudang2 = New System.Windows.Forms.TextBox()
        Me.lbl_gudang2 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_gudang1 = New System.Windows.Forms.Label()
        Me.in_gudang = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.date_tgl_beli = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv_barang = New System.Windows.Forms.DataGridView()
        Me.kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_t = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat_t = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_k = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat_k = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_tot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.in_barang = New System.Windows.Forms.TextBox()
        Me.lbl_sat_kecil = New System.Windows.Forms.Label()
        Me.lbl_sat_tengah = New System.Windows.Forms.Label()
        Me.lbl_sat_besar = New System.Windows.Forms.Label()
        Me.lbl_barang = New System.Windows.Forms.Label()
        Me.in_qty_k = New System.Windows.Forms.NumericUpDown()
        Me.in_qty_t = New System.Windows.Forms.NumericUpDown()
        Me.in_qty_b = New System.Windows.Forms.NumericUpDown()
        Me.bt_batalreturbeli = New System.Windows.Forms.Button()
        Me.bt_simpanreturbeli = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty_k, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty_t, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty_b, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(818, 42)
        Me.Panel1.TabIndex = 141
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Orange
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(226, 20)
        Me.Label9.TabIndex = 133
        Me.Label9.Text = "Form Mutasi Antar Gudang"
        '
        'in_gudang2
        '
        Me.in_gudang2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang2.Location = New System.Drawing.Point(114, 133)
        Me.in_gudang2.MaxLength = 15
        Me.in_gudang2.Name = "in_gudang2"
        Me.in_gudang2.Size = New System.Drawing.Size(172, 21)
        Me.in_gudang2.TabIndex = 143
        '
        'lbl_gudang2
        '
        Me.lbl_gudang2.AutoSize = True
        Me.lbl_gudang2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_gudang2.Location = New System.Drawing.Point(292, 137)
        Me.lbl_gudang2.Name = "lbl_gudang2"
        Me.lbl_gudang2.Size = New System.Drawing.Size(47, 15)
        Me.lbl_gudang2.TabIndex = 145
        Me.lbl_gudang2.Text = "Barang"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 15)
        Me.Label2.TabIndex = 146
        Me.Label2.Text = "Gudang Tujuan"
        '
        'lbl_gudang1
        '
        Me.lbl_gudang1.AutoSize = True
        Me.lbl_gudang1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_gudang1.Location = New System.Drawing.Point(292, 109)
        Me.lbl_gudang1.Name = "lbl_gudang1"
        Me.lbl_gudang1.Size = New System.Drawing.Size(51, 15)
        Me.lbl_gudang1.TabIndex = 147
        Me.lbl_gudang1.Text = "Gudang"
        '
        'in_gudang
        '
        Me.in_gudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang.Location = New System.Drawing.Point(114, 106)
        Me.in_gudang.MaxLength = 15
        Me.in_gudang.Name = "in_gudang"
        Me.in_gudang.Size = New System.Drawing.Size(172, 21)
        Me.in_gudang.TabIndex = 142
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 15)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "Gudang Asal"
        '
        'in_kode
        '
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.Location = New System.Drawing.Point(114, 52)
        Me.in_kode.MaxLength = 15
        Me.in_kode.Name = "in_kode"
        Me.in_kode.Size = New System.Drawing.Size(172, 21)
        Me.in_kode.TabIndex = 144
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 15)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "No. Bukti"
        '
        'date_tgl_beli
        '
        Me.date_tgl_beli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_beli.Location = New System.Drawing.Point(114, 79)
        Me.date_tgl_beli.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_beli.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_beli.Name = "date_tgl_beli"
        Me.date_tgl_beli.Size = New System.Drawing.Size(172, 21)
        Me.date_tgl_beli.TabIndex = 193
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 194
        Me.Label4.Text = "Tanggal"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv_barang)
        Me.GroupBox1.Controls.Add(Me.in_barang)
        Me.GroupBox1.Controls.Add(Me.lbl_sat_kecil)
        Me.GroupBox1.Controls.Add(Me.lbl_sat_tengah)
        Me.GroupBox1.Controls.Add(Me.lbl_sat_besar)
        Me.GroupBox1.Controls.Add(Me.lbl_barang)
        Me.GroupBox1.Controls.Add(Me.in_qty_k)
        Me.GroupBox1.Controls.Add(Me.in_qty_t)
        Me.GroupBox1.Controls.Add(Me.in_qty_b)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 160)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(794, 241)
        Me.GroupBox1.TabIndex = 195
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Barang"
        '
        'dgv_barang
        '
        Me.dgv_barang.AllowUserToAddRows = False
        Me.dgv_barang.AllowUserToDeleteRows = False
        Me.dgv_barang.BackgroundColor = System.Drawing.Color.White
        Me.dgv_barang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_barang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kode, Me.nama, Me.qty_b, Me.sat_b, Me.qty_t, Me.sat_t, Me.qty_k, Me.sat_k, Me.qty_tot})
        Me.dgv_barang.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgv_barang.Location = New System.Drawing.Point(3, 47)
        Me.dgv_barang.Name = "dgv_barang"
        Me.dgv_barang.ReadOnly = True
        Me.dgv_barang.RowHeadersVisible = False
        Me.dgv_barang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_barang.Size = New System.Drawing.Size(788, 191)
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
        'qty_b
        '
        Me.qty_b.DataPropertyName = "trans_qty"
        Me.qty_b.HeaderText = "QTY B"
        Me.qty_b.MinimumWidth = 65
        Me.qty_b.Name = "qty_b"
        Me.qty_b.ReadOnly = True
        Me.qty_b.Width = 65
        '
        'sat_b
        '
        Me.sat_b.DataPropertyName = "trans_satuan"
        Me.sat_b.HeaderText = "Sat. B."
        Me.sat_b.MinimumWidth = 65
        Me.sat_b.Name = "sat_b"
        Me.sat_b.ReadOnly = True
        Me.sat_b.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.sat_b.Width = 65
        '
        'qty_t
        '
        Me.qty_t.HeaderText = "QTY T"
        Me.qty_t.MinimumWidth = 65
        Me.qty_t.Name = "qty_t"
        Me.qty_t.ReadOnly = True
        Me.qty_t.Width = 65
        '
        'sat_t
        '
        Me.sat_t.HeaderText = "Sat. T."
        Me.sat_t.MinimumWidth = 65
        Me.sat_t.Name = "sat_t"
        Me.sat_t.ReadOnly = True
        Me.sat_t.Width = 65
        '
        'qty_k
        '
        Me.qty_k.HeaderText = "QTY K"
        Me.qty_k.MinimumWidth = 65
        Me.qty_k.Name = "qty_k"
        Me.qty_k.ReadOnly = True
        Me.qty_k.Width = 65
        '
        'sat_k
        '
        Me.sat_k.HeaderText = "Sat. K."
        Me.sat_k.MinimumWidth = 65
        Me.sat_k.Name = "sat_k"
        Me.sat_k.ReadOnly = True
        Me.sat_k.Width = 65
        '
        'qty_tot
        '
        Me.qty_tot.HeaderText = "QTY"
        Me.qty_tot.MinimumWidth = 65
        Me.qty_tot.Name = "qty_tot"
        Me.qty_tot.ReadOnly = True
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
        'lbl_sat_kecil
        '
        Me.lbl_sat_kecil.AutoSize = True
        Me.lbl_sat_kecil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sat_kecil.Location = New System.Drawing.Point(619, 24)
        Me.lbl_sat_kecil.MaximumSize = New System.Drawing.Size(250, 16)
        Me.lbl_sat_kecil.Name = "lbl_sat_kecil"
        Me.lbl_sat_kecil.Size = New System.Drawing.Size(31, 13)
        Me.lbl_sat_kecil.TabIndex = 192
        Me.lbl_sat_kecil.Text = "Term"
        '
        'lbl_sat_tengah
        '
        Me.lbl_sat_tengah.AutoSize = True
        Me.lbl_sat_tengah.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sat_tengah.Location = New System.Drawing.Point(491, 24)
        Me.lbl_sat_tengah.MaximumSize = New System.Drawing.Size(250, 16)
        Me.lbl_sat_tengah.Name = "lbl_sat_tengah"
        Me.lbl_sat_tengah.Size = New System.Drawing.Size(31, 13)
        Me.lbl_sat_tengah.TabIndex = 192
        Me.lbl_sat_tengah.Text = "Term"
        '
        'lbl_sat_besar
        '
        Me.lbl_sat_besar.AutoSize = True
        Me.lbl_sat_besar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sat_besar.Location = New System.Drawing.Point(356, 24)
        Me.lbl_sat_besar.MaximumSize = New System.Drawing.Size(250, 16)
        Me.lbl_sat_besar.Name = "lbl_sat_besar"
        Me.lbl_sat_besar.Size = New System.Drawing.Size(31, 13)
        Me.lbl_sat_besar.TabIndex = 192
        Me.lbl_sat_besar.Text = "Term"
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
        'in_qty_k
        '
        Me.in_qty_k.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty_k.Location = New System.Drawing.Point(561, 22)
        Me.in_qty_k.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.in_qty_k.Name = "in_qty_k"
        Me.in_qty_k.Size = New System.Drawing.Size(52, 20)
        Me.in_qty_k.TabIndex = 10
        Me.in_qty_k.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_qty_t
        '
        Me.in_qty_t.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty_t.Location = New System.Drawing.Point(433, 22)
        Me.in_qty_t.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.in_qty_t.Name = "in_qty_t"
        Me.in_qty_t.Size = New System.Drawing.Size(52, 20)
        Me.in_qty_t.TabIndex = 10
        Me.in_qty_t.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_qty_b
        '
        Me.in_qty_b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty_b.Location = New System.Drawing.Point(298, 21)
        Me.in_qty_b.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.in_qty_b.Name = "in_qty_b"
        Me.in_qty_b.Size = New System.Drawing.Size(52, 20)
        Me.in_qty_b.TabIndex = 10
        Me.in_qty_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bt_batalreturbeli
        '
        Me.bt_batalreturbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalreturbeli.Location = New System.Drawing.Point(708, 420)
        Me.bt_batalreturbeli.Name = "bt_batalreturbeli"
        Me.bt_batalreturbeli.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalreturbeli.TabIndex = 194
        Me.bt_batalreturbeli.Text = "Batal"
        Me.bt_batalreturbeli.UseVisualStyleBackColor = True
        '
        'bt_simpanreturbeli
        '
        Me.bt_simpanreturbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanreturbeli.Location = New System.Drawing.Point(606, 420)
        Me.bt_simpanreturbeli.Name = "bt_simpanreturbeli"
        Me.bt_simpanreturbeli.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpanreturbeli.TabIndex = 193
        Me.bt_simpanreturbeli.Text = "Simpan"
        Me.bt_simpanreturbeli.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtRegAlias)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.txtUpdAlias)
        Me.GroupBox2.Controls.Add(Me.txtRegdate)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.txtUpdDate)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 404)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(485, 68)
        Me.GroupBox2.TabIndex = 239
        Me.GroupBox2.TabStop = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(81, 36)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtRegAlias.TabIndex = 116
        Me.txtRegAlias.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(10, 39)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(52, 13)
        Me.Label27.TabIndex = 119
        Me.Label27.Text = "Reg Alias"
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(321, 36)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtUpdAlias.TabIndex = 122
        Me.txtUpdAlias.TabStop = False
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(81, 16)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(150, 20)
        Me.txtRegdate.TabIndex = 115
        Me.txtRegdate.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(248, 39)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(52, 13)
        Me.Label28.TabIndex = 125
        Me.Label28.Text = "Upd Alias"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(9, 19)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 13)
        Me.Label29.TabIndex = 118
        Me.Label29.Text = "Reg Date"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(249, 19)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(53, 13)
        Me.Label30.TabIndex = 124
        Me.Label30.Text = "Upd Date"
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(321, 16)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(150, 20)
        Me.txtUpdDate.TabIndex = 115
        Me.txtUpdDate.TabStop = False
        '
        'fr_stok_mutasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 481)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.bt_batalreturbeli)
        Me.Controls.Add(Me.bt_simpanreturbeli)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.date_tgl_beli)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.in_gudang2)
        Me.Controls.Add(Me.lbl_gudang2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_gudang1)
        Me.Controls.Add(Me.in_gudang)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.in_kode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "fr_stok_mutasi"
        Me.Text = "Mutasi Stok"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_qty_k, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_qty_t, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_qty_b, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents in_gudang2 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_gudang2 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_gudang1 As System.Windows.Forms.Label
    Friend WithEvents in_gudang As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents date_tgl_beli As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_barang As System.Windows.Forms.DataGridView
    Friend WithEvents in_barang As System.Windows.Forms.TextBox
    Friend WithEvents lbl_sat_kecil As System.Windows.Forms.Label
    Friend WithEvents lbl_sat_tengah As System.Windows.Forms.Label
    Friend WithEvents lbl_sat_besar As System.Windows.Forms.Label
    Friend WithEvents lbl_barang As System.Windows.Forms.Label
    Friend WithEvents in_qty_k As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_qty_t As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_qty_b As System.Windows.Forms.NumericUpDown
    Friend WithEvents bt_batalreturbeli As System.Windows.Forms.Button
    Friend WithEvents bt_simpanreturbeli As System.Windows.Forms.Button
    Friend WithEvents kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_k As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_k As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_tot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
End Class
