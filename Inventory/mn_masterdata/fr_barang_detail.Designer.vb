<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_barang_detail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_barang_detail))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.tab_prod = New System.Windows.Forms.TabControl()
        Me.tb_prodinfo = New System.Windows.Forms.TabPage()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.in_jual_d5 = New System.Windows.Forms.NumericUpDown()
        Me.in_jual_d4 = New System.Windows.Forms.NumericUpDown()
        Me.in_jual_d3 = New System.Windows.Forms.NumericUpDown()
        Me.in_jual_d2 = New System.Windows.Forms.NumericUpDown()
        Me.in_jual_d1 = New System.Windows.Forms.NumericUpDown()
        Me.in_harga_disc = New System.Windows.Forms.NumericUpDown()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.in_beli_klaim = New System.Windows.Forms.NumericUpDown()
        Me.in_beli_d3 = New System.Windows.Forms.NumericUpDown()
        Me.in_beli_d2 = New System.Windows.Forms.NumericUpDown()
        Me.in_beli_d1 = New System.Windows.Forms.NumericUpDown()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.bt_supplier_list = New System.Windows.Forms.Button()
        Me.in_suppliernama = New System.Windows.Forms.TextBox()
        Me.in_supplier = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbl_satuan2 = New System.Windows.Forms.Label()
        Me.lbl_satuan1 = New System.Windows.Forms.Label()
        Me.in_isi_besar = New System.Windows.Forms.NumericUpDown()
        Me.in_isi_tengah = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.in_harga_rita = New System.Windows.Forms.NumericUpDown()
        Me.in_harga_horeka = New System.Windows.Forms.NumericUpDown()
        Me.in_harga_mt = New System.Windows.Forms.NumericUpDown()
        Me.in_harga_jual = New System.Windows.Forms.NumericUpDown()
        Me.in_harga_beli = New System.Windows.Forms.NumericUpDown()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.in_nama = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.cb_status = New System.Windows.Forms.ComboBox()
        Me.cb_kategori = New System.Windows.Forms.ComboBox()
        Me.cb_sat_besar = New System.Windows.Forms.ComboBox()
        Me.cb_sat_tengah = New System.Windows.Forms.ComboBox()
        Me.cb_sat_kecil = New System.Windows.Forms.ComboBox()
        Me.cb_jenis = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.dgv_his_st = New System.Windows.Forms.DataGridView()
        Me.his_tanggal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_kodebarang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_barang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_qty_in = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_qty_out = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_source = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_dest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cb_kodegd = New System.Windows.Forms.ComboBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.dt_akhir_st = New System.Windows.Forms.DateTimePicker()
        Me.dt_awal_st = New System.Windows.Forms.DateTimePicker()
        Me.bt_view_st = New System.Windows.Forms.Button()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.bt_simpanbarang = New System.Windows.Forms.Button()
        Me.bt_batalbarang = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.tab_prod.SuspendLayout()
        Me.tb_prodinfo.SuspendLayout()
        CType(Me.in_jual_d5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_jual_d4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_jual_d3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_jual_d2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_jual_d1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_harga_disc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_beli_klaim, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_beli_d3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_beli_d2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_beli_d1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_isi_besar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_isi_tengah, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_harga_rita, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_harga_horeka, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_harga_mt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_harga_jual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_harga_beli, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgv_his_st, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.lbl_close)
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.lbl_title)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(790, 42)
        Me.Panel1.TabIndex = 136
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(702, 9)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(47, 20)
        Me.lbl_close.TabIndex = 135
        Me.lbl_close.Text = "Close"
        Me.lbl_close.Visible = False
        '
        'bt_cl
        '
        Me.bt_cl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_cl.BackColor = System.Drawing.Color.Transparent
        Me.bt_cl.BackgroundImage = Global.Inventory.My.Resources.Resources.close
        Me.bt_cl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_cl.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_cl.FlatAppearance.BorderSize = 0
        Me.bt_cl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange
        Me.bt_cl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange
        Me.bt_cl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cl.Location = New System.Drawing.Point(755, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 134
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Orange
        Me.lbl_title.Font = New System.Drawing.Font("Source Sans Pro", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(3, 4)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(146, 30)
        Me.lbl_title.TabIndex = 1
        Me.lbl_title.Text = "Data Produk"
        '
        'tab_prod
        '
        Me.tab_prod.Controls.Add(Me.tb_prodinfo)
        Me.tab_prod.Controls.Add(Me.TabPage5)
        Me.tab_prod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_prod.Location = New System.Drawing.Point(0, 42)
        Me.tab_prod.Name = "tab_prod"
        Me.tab_prod.SelectedIndex = 0
        Me.tab_prod.Size = New System.Drawing.Size(790, 494)
        Me.tab_prod.TabIndex = 0
        '
        'tb_prodinfo
        '
        Me.tb_prodinfo.Controls.Add(Me.txtUpdAlias)
        Me.tb_prodinfo.Controls.Add(Me.Label48)
        Me.tb_prodinfo.Controls.Add(Me.Label50)
        Me.tb_prodinfo.Controls.Add(Me.txtUpdDate)
        Me.tb_prodinfo.Controls.Add(Me.txtRegAlias)
        Me.tb_prodinfo.Controls.Add(Me.txtRegdate)
        Me.tb_prodinfo.Controls.Add(Me.Label47)
        Me.tb_prodinfo.Controls.Add(Me.Label49)
        Me.tb_prodinfo.Controls.Add(Me.Label68)
        Me.tb_prodinfo.Controls.Add(Me.in_jual_d5)
        Me.tb_prodinfo.Controls.Add(Me.in_jual_d4)
        Me.tb_prodinfo.Controls.Add(Me.in_jual_d3)
        Me.tb_prodinfo.Controls.Add(Me.in_jual_d2)
        Me.tb_prodinfo.Controls.Add(Me.in_jual_d1)
        Me.tb_prodinfo.Controls.Add(Me.in_harga_disc)
        Me.tb_prodinfo.Controls.Add(Me.Label42)
        Me.tb_prodinfo.Controls.Add(Me.Label41)
        Me.tb_prodinfo.Controls.Add(Me.Label40)
        Me.tb_prodinfo.Controls.Add(Me.Label39)
        Me.tb_prodinfo.Controls.Add(Me.Label38)
        Me.tb_prodinfo.Controls.Add(Me.Label24)
        Me.tb_prodinfo.Controls.Add(Me.Label66)
        Me.tb_prodinfo.Controls.Add(Me.Label67)
        Me.tb_prodinfo.Controls.Add(Me.Label60)
        Me.tb_prodinfo.Controls.Add(Me.Label17)
        Me.tb_prodinfo.Controls.Add(Me.Label23)
        Me.tb_prodinfo.Controls.Add(Me.Label15)
        Me.tb_prodinfo.Controls.Add(Me.Label22)
        Me.tb_prodinfo.Controls.Add(Me.Label21)
        Me.tb_prodinfo.Controls.Add(Me.in_beli_klaim)
        Me.tb_prodinfo.Controls.Add(Me.in_beli_d3)
        Me.tb_prodinfo.Controls.Add(Me.in_beli_d2)
        Me.tb_prodinfo.Controls.Add(Me.in_beli_d1)
        Me.tb_prodinfo.Controls.Add(Me.Label34)
        Me.tb_prodinfo.Controls.Add(Me.Label37)
        Me.tb_prodinfo.Controls.Add(Me.Label35)
        Me.tb_prodinfo.Controls.Add(Me.Label36)
        Me.tb_prodinfo.Controls.Add(Me.bt_supplier_list)
        Me.tb_prodinfo.Controls.Add(Me.in_suppliernama)
        Me.tb_prodinfo.Controls.Add(Me.in_supplier)
        Me.tb_prodinfo.Controls.Add(Me.Label1)
        Me.tb_prodinfo.Controls.Add(Me.Label5)
        Me.tb_prodinfo.Controls.Add(Me.Label8)
        Me.tb_prodinfo.Controls.Add(Me.lbl_satuan2)
        Me.tb_prodinfo.Controls.Add(Me.lbl_satuan1)
        Me.tb_prodinfo.Controls.Add(Me.in_isi_besar)
        Me.tb_prodinfo.Controls.Add(Me.in_isi_tengah)
        Me.tb_prodinfo.Controls.Add(Me.Label6)
        Me.tb_prodinfo.Controls.Add(Me.Label10)
        Me.tb_prodinfo.Controls.Add(Me.Label7)
        Me.tb_prodinfo.Controls.Add(Me.Label45)
        Me.tb_prodinfo.Controls.Add(Me.in_harga_rita)
        Me.tb_prodinfo.Controls.Add(Me.in_harga_horeka)
        Me.tb_prodinfo.Controls.Add(Me.in_harga_mt)
        Me.tb_prodinfo.Controls.Add(Me.in_harga_jual)
        Me.tb_prodinfo.Controls.Add(Me.in_harga_beli)
        Me.tb_prodinfo.Controls.Add(Me.Label27)
        Me.tb_prodinfo.Controls.Add(Me.Label26)
        Me.tb_prodinfo.Controls.Add(Me.Label52)
        Me.tb_prodinfo.Controls.Add(Me.Label25)
        Me.tb_prodinfo.Controls.Add(Me.Label28)
        Me.tb_prodinfo.Controls.Add(Me.Label9)
        Me.tb_prodinfo.Controls.Add(Me.Label20)
        Me.tb_prodinfo.Controls.Add(Me.Label19)
        Me.tb_prodinfo.Controls.Add(Me.Label3)
        Me.tb_prodinfo.Controls.Add(Me.in_kode)
        Me.tb_prodinfo.Controls.Add(Me.Label4)
        Me.tb_prodinfo.Controls.Add(Me.in_nama)
        Me.tb_prodinfo.Controls.Add(Me.Label11)
        Me.tb_prodinfo.Controls.Add(Me.Label62)
        Me.tb_prodinfo.Controls.Add(Me.Label46)
        Me.tb_prodinfo.Controls.Add(Me.cb_status)
        Me.tb_prodinfo.Controls.Add(Me.cb_kategori)
        Me.tb_prodinfo.Controls.Add(Me.cb_sat_besar)
        Me.tb_prodinfo.Controls.Add(Me.cb_sat_tengah)
        Me.tb_prodinfo.Controls.Add(Me.cb_sat_kecil)
        Me.tb_prodinfo.Controls.Add(Me.cb_jenis)
        Me.tb_prodinfo.Controls.Add(Me.Label2)
        Me.tb_prodinfo.Controls.Add(Me.Label51)
        Me.tb_prodinfo.Location = New System.Drawing.Point(4, 22)
        Me.tb_prodinfo.Name = "tb_prodinfo"
        Me.tb_prodinfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_prodinfo.Size = New System.Drawing.Size(782, 468)
        Me.tb_prodinfo.TabIndex = 0
        Me.tb_prodinfo.Text = "Product Info"
        Me.tb_prodinfo.UseVisualStyleBackColor = True
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(623, 413)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(151, 20)
        Me.txtUpdAlias.TabIndex = 411
        Me.txtUpdAlias.TabStop = False
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.Black
        Me.Label48.Location = New System.Drawing.Point(578, 416)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(39, 13)
        Me.Label48.TabIndex = 413
        Me.Label48.Text = "UpdBy"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(578, 439)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(30, 13)
        Me.Label50.TabIndex = 412
        Me.Label50.Text = "Date"
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(623, 435)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(151, 20)
        Me.txtUpdDate.TabIndex = 410
        Me.txtUpdDate.TabStop = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(421, 413)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(151, 20)
        Me.txtRegAlias.TabIndex = 407
        Me.txtRegAlias.TabStop = False
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(421, 435)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(151, 20)
        Me.txtRegdate.TabIndex = 406
        Me.txtRegdate.TabStop = False
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.Black
        Me.Label47.Location = New System.Drawing.Point(376, 416)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(39, 13)
        Me.Label47.TabIndex = 409
        Me.Label47.Text = "RegBy"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.Color.Black
        Me.Label49.Location = New System.Drawing.Point(376, 438)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(30, 13)
        Me.Label49.TabIndex = 408
        Me.Label49.Text = "Date"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.ForeColor = System.Drawing.Color.Black
        Me.Label68.Location = New System.Drawing.Point(294, 299)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(28, 13)
        Me.Label68.TabIndex = 405
        Me.Label68.Text = "Disc"
        '
        'in_jual_d5
        '
        Me.in_jual_d5.DecimalPlaces = 2
        Me.in_jual_d5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_jual_d5.ForeColor = System.Drawing.Color.Black
        Me.in_jual_d5.Location = New System.Drawing.Point(432, 347)
        Me.in_jual_d5.Name = "in_jual_d5"
        Me.in_jual_d5.Size = New System.Drawing.Size(57, 20)
        Me.in_jual_d5.TabIndex = 399
        Me.in_jual_d5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_jual_d4
        '
        Me.in_jual_d4.DecimalPlaces = 2
        Me.in_jual_d4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_jual_d4.ForeColor = System.Drawing.Color.Black
        Me.in_jual_d4.Location = New System.Drawing.Point(321, 348)
        Me.in_jual_d4.Name = "in_jual_d4"
        Me.in_jual_d4.Size = New System.Drawing.Size(57, 20)
        Me.in_jual_d4.TabIndex = 398
        Me.in_jual_d4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_jual_d3
        '
        Me.in_jual_d3.DecimalPlaces = 2
        Me.in_jual_d3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_jual_d3.ForeColor = System.Drawing.Color.Black
        Me.in_jual_d3.Location = New System.Drawing.Point(543, 323)
        Me.in_jual_d3.Name = "in_jual_d3"
        Me.in_jual_d3.Size = New System.Drawing.Size(57, 20)
        Me.in_jual_d3.TabIndex = 397
        Me.in_jual_d3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_jual_d2
        '
        Me.in_jual_d2.DecimalPlaces = 2
        Me.in_jual_d2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_jual_d2.ForeColor = System.Drawing.Color.Black
        Me.in_jual_d2.Location = New System.Drawing.Point(432, 323)
        Me.in_jual_d2.Name = "in_jual_d2"
        Me.in_jual_d2.Size = New System.Drawing.Size(57, 20)
        Me.in_jual_d2.TabIndex = 396
        Me.in_jual_d2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_jual_d1
        '
        Me.in_jual_d1.DecimalPlaces = 2
        Me.in_jual_d1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_jual_d1.ForeColor = System.Drawing.Color.Black
        Me.in_jual_d1.Location = New System.Drawing.Point(322, 322)
        Me.in_jual_d1.Name = "in_jual_d1"
        Me.in_jual_d1.Size = New System.Drawing.Size(57, 20)
        Me.in_jual_d1.TabIndex = 395
        Me.in_jual_d1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_harga_disc
        '
        Me.in_harga_disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_harga_disc.ForeColor = System.Drawing.Color.Black
        Me.in_harga_disc.Location = New System.Drawing.Point(322, 297)
        Me.in_harga_disc.Maximum = New Decimal(New Integer() {1569325055, 23283064, 0, 0})
        Me.in_harga_disc.Name = "in_harga_disc"
        Me.in_harga_disc.Size = New System.Drawing.Size(168, 20)
        Me.in_harga_disc.TabIndex = 394
        Me.in_harga_disc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_harga_disc.ThousandsSeparator = True
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Black
        Me.Label42.Location = New System.Drawing.Point(379, 325)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(15, 13)
        Me.Label42.TabIndex = 403
        Me.Label42.Text = "%"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(490, 350)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(15, 13)
        Me.Label41.TabIndex = 404
        Me.Label41.Text = "%"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(379, 350)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(15, 13)
        Me.Label40.TabIndex = 402
        Me.Label40.Text = "%"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(601, 325)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(15, 13)
        Me.Label39.TabIndex = 401
        Me.Label39.Text = "%"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(490, 325)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(15, 13)
        Me.Label38.TabIndex = 400
        Me.Label38.Text = "%"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(627, 255)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(46, 13)
        Me.Label24.TabIndex = 393
        Me.Label24.Text = "D3Klaim"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.ForeColor = System.Drawing.Color.Black
        Me.Label66.Location = New System.Drawing.Point(405, 350)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(21, 13)
        Me.Label66.TabIndex = 390
        Me.Label66.Text = "D5"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.ForeColor = System.Drawing.Color.Black
        Me.Label67.Location = New System.Drawing.Point(516, 325)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(21, 13)
        Me.Label67.TabIndex = 390
        Me.Label67.Text = "D3"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.Color.Black
        Me.Label60.Location = New System.Drawing.Point(294, 350)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(21, 13)
        Me.Label60.TabIndex = 390
        Me.Label60.Text = "D4"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(405, 325)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(21, 13)
        Me.Label17.TabIndex = 392
        Me.Label17.Text = "D2"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(516, 255)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(21, 13)
        Me.Label23.TabIndex = 390
        Me.Label23.Text = "D3"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(294, 325)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(21, 13)
        Me.Label15.TabIndex = 391
        Me.Label15.Text = "D1"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(405, 255)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(21, 13)
        Me.Label22.TabIndex = 392
        Me.Label22.Text = "D2"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(294, 255)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(21, 13)
        Me.Label21.TabIndex = 391
        Me.Label21.Text = "D1"
        '
        'in_beli_klaim
        '
        Me.in_beli_klaim.DecimalPlaces = 2
        Me.in_beli_klaim.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_beli_klaim.ForeColor = System.Drawing.Color.Black
        Me.in_beli_klaim.Location = New System.Drawing.Point(688, 252)
        Me.in_beli_klaim.Name = "in_beli_klaim"
        Me.in_beli_klaim.Size = New System.Drawing.Size(57, 20)
        Me.in_beli_klaim.TabIndex = 385
        Me.in_beli_klaim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_beli_d3
        '
        Me.in_beli_d3.DecimalPlaces = 2
        Me.in_beli_d3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_beli_d3.ForeColor = System.Drawing.Color.Black
        Me.in_beli_d3.Location = New System.Drawing.Point(544, 252)
        Me.in_beli_d3.Name = "in_beli_d3"
        Me.in_beli_d3.Size = New System.Drawing.Size(57, 20)
        Me.in_beli_d3.TabIndex = 384
        Me.in_beli_d3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_beli_d2
        '
        Me.in_beli_d2.DecimalPlaces = 2
        Me.in_beli_d2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_beli_d2.ForeColor = System.Drawing.Color.Black
        Me.in_beli_d2.Location = New System.Drawing.Point(433, 252)
        Me.in_beli_d2.Name = "in_beli_d2"
        Me.in_beli_d2.Size = New System.Drawing.Size(57, 20)
        Me.in_beli_d2.TabIndex = 383
        Me.in_beli_d2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_beli_d1
        '
        Me.in_beli_d1.DecimalPlaces = 2
        Me.in_beli_d1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_beli_d1.ForeColor = System.Drawing.Color.Black
        Me.in_beli_d1.Location = New System.Drawing.Point(322, 252)
        Me.in_beli_d1.Name = "in_beli_d1"
        Me.in_beli_d1.Size = New System.Drawing.Size(57, 20)
        Me.in_beli_d1.TabIndex = 382
        Me.in_beli_d1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(379, 255)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(15, 13)
        Me.Label34.TabIndex = 387
        Me.Label34.Text = "%"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(746, 255)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(15, 13)
        Me.Label37.TabIndex = 386
        Me.Label37.Text = "%"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(490, 255)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(15, 13)
        Me.Label35.TabIndex = 388
        Me.Label35.Text = "%"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(601, 255)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(15, 13)
        Me.Label36.TabIndex = 389
        Me.Label36.Text = "%"
        '
        'bt_supplier_list
        '
        Me.bt_supplier_list.BackColor = System.Drawing.Color.Transparent
        Me.bt_supplier_list.BackgroundImage = CType(resources.GetObject("bt_supplier_list.BackgroundImage"), System.Drawing.Image)
        Me.bt_supplier_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_supplier_list.FlatAppearance.BorderSize = 0
        Me.bt_supplier_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_supplier_list.Location = New System.Drawing.Point(463, 28)
        Me.bt_supplier_list.Name = "bt_supplier_list"
        Me.bt_supplier_list.Size = New System.Drawing.Size(12, 15)
        Me.bt_supplier_list.TabIndex = 2
        Me.bt_supplier_list.UseVisualStyleBackColor = False
        '
        'in_suppliernama
        '
        Me.in_suppliernama.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_suppliernama.Location = New System.Drawing.Point(228, 24)
        Me.in_suppliernama.MaxLength = 10
        Me.in_suppliernama.Name = "in_suppliernama"
        Me.in_suppliernama.Size = New System.Drawing.Size(229, 20)
        Me.in_suppliernama.TabIndex = 1
        '
        'in_supplier
        '
        Me.in_supplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier.Location = New System.Drawing.Point(100, 24)
        Me.in_supplier.MaxLength = 10
        Me.in_supplier.Name = "in_supplier"
        Me.in_supplier.Size = New System.Drawing.Size(129, 20)
        Me.in_supplier.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 381
        Me.Label1.Text = "Supplier"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(207, 167)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 13)
        Me.Label5.TabIndex = 372
        Me.Label5.Text = "="
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(206, 190)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 13)
        Me.Label8.TabIndex = 373
        Me.Label8.Text = "="
        '
        'lbl_satuan2
        '
        Me.lbl_satuan2.AutoSize = True
        Me.lbl_satuan2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_satuan2.ForeColor = System.Drawing.Color.Black
        Me.lbl_satuan2.Location = New System.Drawing.Point(314, 190)
        Me.lbl_satuan2.Name = "lbl_satuan2"
        Me.lbl_satuan2.Size = New System.Drawing.Size(32, 13)
        Me.lbl_satuan2.TabIndex = 374
        Me.lbl_satuan2.Text = "Kode"
        '
        'lbl_satuan1
        '
        Me.lbl_satuan1.AutoSize = True
        Me.lbl_satuan1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_satuan1.ForeColor = System.Drawing.Color.Black
        Me.lbl_satuan1.Location = New System.Drawing.Point(314, 167)
        Me.lbl_satuan1.Name = "lbl_satuan1"
        Me.lbl_satuan1.Size = New System.Drawing.Size(32, 13)
        Me.lbl_satuan1.TabIndex = 375
        Me.lbl_satuan1.Text = "Kode"
        '
        'in_isi_besar
        '
        Me.in_isi_besar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_isi_besar.ForeColor = System.Drawing.Color.Black
        Me.in_isi_besar.Location = New System.Drawing.Point(227, 186)
        Me.in_isi_besar.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.in_isi_besar.Name = "in_isi_besar"
        Me.in_isi_besar.Size = New System.Drawing.Size(80, 20)
        Me.in_isi_besar.TabIndex = 11
        Me.in_isi_besar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_isi_besar.ThousandsSeparator = True
        '
        'in_isi_tengah
        '
        Me.in_isi_tengah.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_isi_tengah.ForeColor = System.Drawing.Color.Black
        Me.in_isi_tengah.Location = New System.Drawing.Point(228, 163)
        Me.in_isi_tengah.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.in_isi_tengah.Name = "in_isi_tengah"
        Me.in_isi_tengah.Size = New System.Drawing.Size(80, 20)
        Me.in_isi_tengah.TabIndex = 9
        Me.in_isi_tengah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_isi_tengah.ThousandsSeparator = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(20, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 368
        Me.Label6.Text = "Tengah"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(20, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 369
        Me.Label10.Text = "Kecil"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(20, 190)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 367
        Me.Label7.Text = "Besar"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label45.Location = New System.Drawing.Point(10, 117)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(58, 20)
        Me.Label45.TabIndex = 363
        Me.Label45.Text = "Satuan"
        '
        'in_harga_rita
        '
        Me.in_harga_rita.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_harga_rita.ForeColor = System.Drawing.Color.Black
        Me.in_harga_rita.Location = New System.Drawing.Point(100, 366)
        Me.in_harga_rita.Maximum = New Decimal(New Integer() {1569325055, 23283064, 0, 0})
        Me.in_harga_rita.Name = "in_harga_rita"
        Me.in_harga_rita.Size = New System.Drawing.Size(157, 20)
        Me.in_harga_rita.TabIndex = 16
        Me.in_harga_rita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_harga_rita.ThousandsSeparator = True
        '
        'in_harga_horeka
        '
        Me.in_harga_horeka.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_harga_horeka.ForeColor = System.Drawing.Color.Black
        Me.in_harga_horeka.Location = New System.Drawing.Point(100, 343)
        Me.in_harga_horeka.Maximum = New Decimal(New Integer() {1569325055, 23283064, 0, 0})
        Me.in_harga_horeka.Name = "in_harga_horeka"
        Me.in_harga_horeka.Size = New System.Drawing.Size(157, 20)
        Me.in_harga_horeka.TabIndex = 15
        Me.in_harga_horeka.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_harga_horeka.ThousandsSeparator = True
        '
        'in_harga_mt
        '
        Me.in_harga_mt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_harga_mt.ForeColor = System.Drawing.Color.Black
        Me.in_harga_mt.Location = New System.Drawing.Point(101, 320)
        Me.in_harga_mt.Maximum = New Decimal(New Integer() {1569325055, 23283064, 0, 0})
        Me.in_harga_mt.Name = "in_harga_mt"
        Me.in_harga_mt.Size = New System.Drawing.Size(157, 20)
        Me.in_harga_mt.TabIndex = 14
        Me.in_harga_mt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_harga_mt.ThousandsSeparator = True
        '
        'in_harga_jual
        '
        Me.in_harga_jual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_harga_jual.ForeColor = System.Drawing.Color.Black
        Me.in_harga_jual.Location = New System.Drawing.Point(101, 297)
        Me.in_harga_jual.Maximum = New Decimal(New Integer() {1569325055, 23283064, 0, 0})
        Me.in_harga_jual.Name = "in_harga_jual"
        Me.in_harga_jual.Size = New System.Drawing.Size(157, 20)
        Me.in_harga_jual.TabIndex = 13
        Me.in_harga_jual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_harga_jual.ThousandsSeparator = True
        '
        'in_harga_beli
        '
        Me.in_harga_beli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_harga_beli.ForeColor = System.Drawing.Color.Black
        Me.in_harga_beli.Location = New System.Drawing.Point(101, 253)
        Me.in_harga_beli.Maximum = New Decimal(New Integer() {1569325055, 23283064, 0, 0})
        Me.in_harga_beli.Name = "in_harga_beli"
        Me.in_harga_beli.Size = New System.Drawing.Size(156, 20)
        Me.in_harga_beli.TabIndex = 12
        Me.in_harga_beli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_harga_beli.ThousandsSeparator = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(20, 368)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(26, 13)
        Me.Label27.TabIndex = 318
        Me.Label27.Text = "Rita"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(20, 345)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(42, 13)
        Me.Label26.TabIndex = 319
        Me.Label26.Text = "Horeka"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(21, 299)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(40, 13)
        Me.Label52.TabIndex = 320
        Me.Label52.Text = "Normal"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(21, 322)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(23, 13)
        Me.Label25.TabIndex = 320
        Me.Label25.Text = "MT"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Navy
        Me.Label28.Location = New System.Drawing.Point(294, 280)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(71, 15)
        Me.Label28.TabIndex = 321
        Me.Label28.Text = "Diskon Jual"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(294, 235)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 15)
        Me.Label9.TabIndex = 321
        Me.Label9.Text = "Diskon Beli"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Navy
        Me.Label20.Location = New System.Drawing.Point(20, 280)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 15)
        Me.Label20.TabIndex = 321
        Me.Label20.Text = "Harga Jual"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(20, 255)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 13)
        Me.Label19.TabIndex = 322
        Me.Label19.Text = "Harga Beli"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 308
        Me.Label3.Text = "Kode"
        '
        'in_kode
        '
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.ForeColor = System.Drawing.Color.Black
        Me.in_kode.Location = New System.Drawing.Point(100, 46)
        Me.in_kode.MaxLength = 15
        Me.in_kode.Name = "in_kode"
        Me.in_kode.Size = New System.Drawing.Size(357, 20)
        Me.in_kode.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(20, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 310
        Me.Label4.Text = "Nama"
        '
        'in_nama
        '
        Me.in_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_nama.ForeColor = System.Drawing.Color.Black
        Me.in_nama.Location = New System.Drawing.Point(100, 68)
        Me.in_nama.MaxLength = 200
        Me.in_nama.Name = "in_nama"
        Me.in_nama.Size = New System.Drawing.Size(357, 20)
        Me.in_nama.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(583, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 311
        Me.Label11.Text = "Status"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.Black
        Me.Label62.Location = New System.Drawing.Point(244, 94)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(46, 13)
        Me.Label62.TabIndex = 311
        Me.Label62.Text = "Kategori"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Location = New System.Drawing.Point(20, 93)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(31, 13)
        Me.Label46.TabIndex = 311
        Me.Label46.Text = "Jenis"
        '
        'cb_status
        '
        Me.cb_status.BackColor = System.Drawing.Color.White
        Me.cb_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_status.ForeColor = System.Drawing.Color.Black
        Me.cb_status.FormattingEnabled = True
        Me.cb_status.Location = New System.Drawing.Point(626, 23)
        Me.cb_status.Name = "cb_status"
        Me.cb_status.Size = New System.Drawing.Size(148, 21)
        Me.cb_status.TabIndex = 6
        '
        'cb_kategori
        '
        Me.cb_kategori.BackColor = System.Drawing.Color.White
        Me.cb_kategori.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_kategori.ForeColor = System.Drawing.Color.Black
        Me.cb_kategori.FormattingEnabled = True
        Me.cb_kategori.Location = New System.Drawing.Point(309, 90)
        Me.cb_kategori.Name = "cb_kategori"
        Me.cb_kategori.Size = New System.Drawing.Size(148, 21)
        Me.cb_kategori.TabIndex = 6
        '
        'cb_sat_besar
        '
        Me.cb_sat_besar.BackColor = System.Drawing.Color.White
        Me.cb_sat_besar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_sat_besar.ForeColor = System.Drawing.Color.Black
        Me.cb_sat_besar.FormattingEnabled = True
        Me.cb_sat_besar.Location = New System.Drawing.Point(100, 186)
        Me.cb_sat_besar.Name = "cb_sat_besar"
        Me.cb_sat_besar.Size = New System.Drawing.Size(105, 21)
        Me.cb_sat_besar.TabIndex = 5
        '
        'cb_sat_tengah
        '
        Me.cb_sat_tengah.BackColor = System.Drawing.Color.White
        Me.cb_sat_tengah.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_sat_tengah.ForeColor = System.Drawing.Color.Black
        Me.cb_sat_tengah.FormattingEnabled = True
        Me.cb_sat_tengah.Location = New System.Drawing.Point(100, 163)
        Me.cb_sat_tengah.Name = "cb_sat_tengah"
        Me.cb_sat_tengah.Size = New System.Drawing.Size(105, 21)
        Me.cb_sat_tengah.TabIndex = 5
        '
        'cb_sat_kecil
        '
        Me.cb_sat_kecil.BackColor = System.Drawing.Color.White
        Me.cb_sat_kecil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_sat_kecil.ForeColor = System.Drawing.Color.Black
        Me.cb_sat_kecil.FormattingEnabled = True
        Me.cb_sat_kecil.Location = New System.Drawing.Point(100, 140)
        Me.cb_sat_kecil.Name = "cb_sat_kecil"
        Me.cb_sat_kecil.Size = New System.Drawing.Size(105, 21)
        Me.cb_sat_kecil.TabIndex = 5
        '
        'cb_jenis
        '
        Me.cb_jenis.BackColor = System.Drawing.Color.White
        Me.cb_jenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_jenis.ForeColor = System.Drawing.Color.Black
        Me.cb_jenis.FormattingEnabled = True
        Me.cb_jenis.Location = New System.Drawing.Point(100, 90)
        Me.cb_jenis.Name = "cb_jenis"
        Me.cb_jenis.Size = New System.Drawing.Size(129, 21)
        Me.cb_jenis.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(10, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 20)
        Me.Label2.TabIndex = 291
        Me.Label2.Text = "Basic"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label51.Location = New System.Drawing.Point(6, 222)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(163, 20)
        Me.Label51.TabIndex = 291
        Me.Label51.Text = "Harga (Per Sat. Besar)"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.dgv_his_st)
        Me.TabPage5.Controls.Add(Me.cb_kodegd)
        Me.TabPage5.Controls.Add(Me.Label73)
        Me.TabPage5.Controls.Add(Me.dt_akhir_st)
        Me.TabPage5.Controls.Add(Me.dt_awal_st)
        Me.TabPage5.Controls.Add(Me.bt_view_st)
        Me.TabPage5.Controls.Add(Me.Label70)
        Me.TabPage5.Controls.Add(Me.Label71)
        Me.TabPage5.Controls.Add(Me.Label72)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(782, 468)
        Me.TabPage5.TabIndex = 5
        Me.TabPage5.Text = "History"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'dgv_his_st
        '
        Me.dgv_his_st.AllowUserToAddRows = False
        Me.dgv_his_st.AllowUserToDeleteRows = False
        Me.dgv_his_st.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_his_st.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_his_st.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_his_st.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.his_tanggal, Me.his_kodebarang, Me.his_barang, Me.his_type, Me.his_faktur, Me.his_qty_in, Me.his_qty_out, Me.his_source, Me.his_dest})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_his_st.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_his_st.Location = New System.Drawing.Point(18, 104)
        Me.dgv_his_st.Name = "dgv_his_st"
        Me.dgv_his_st.ReadOnly = True
        Me.dgv_his_st.RowHeadersVisible = False
        Me.dgv_his_st.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_his_st.Size = New System.Drawing.Size(753, 339)
        Me.dgv_his_st.TabIndex = 396
        '
        'his_tanggal
        '
        Me.his_tanggal.DataPropertyName = "trans_tanggal"
        Me.his_tanggal.HeaderText = "Tanggal"
        Me.his_tanggal.MinimumWidth = 125
        Me.his_tanggal.Name = "his_tanggal"
        Me.his_tanggal.ReadOnly = True
        Me.his_tanggal.Width = 125
        '
        'his_kodebarang
        '
        Me.his_kodebarang.DataPropertyName = "trans_barang"
        Me.his_kodebarang.HeaderText = "Kode"
        Me.his_kodebarang.MinimumWidth = 100
        Me.his_kodebarang.Name = "his_kodebarang"
        Me.his_kodebarang.ReadOnly = True
        Me.his_kodebarang.Visible = False
        '
        'his_barang
        '
        Me.his_barang.DataPropertyName = "barang_nama"
        Me.his_barang.HeaderText = "Nama Barang"
        Me.his_barang.MinimumWidth = 150
        Me.his_barang.Name = "his_barang"
        Me.his_barang.ReadOnly = True
        Me.his_barang.Visible = False
        Me.his_barang.Width = 150
        '
        'his_type
        '
        Me.his_type.DataPropertyName = "trans_type"
        Me.his_type.HeaderText = "Keterangan"
        Me.his_type.MinimumWidth = 150
        Me.his_type.Name = "his_type"
        Me.his_type.ReadOnly = True
        Me.his_type.Width = 150
        '
        'his_faktur
        '
        Me.his_faktur.DataPropertyName = "trans_faktur"
        Me.his_faktur.HeaderText = "Kode Faktur"
        Me.his_faktur.MinimumWidth = 125
        Me.his_faktur.Name = "his_faktur"
        Me.his_faktur.ReadOnly = True
        Me.his_faktur.Width = 125
        '
        'his_qty_in
        '
        Me.his_qty_in.DataPropertyName = "trans_qty_in"
        Me.his_qty_in.HeaderText = "Debet"
        Me.his_qty_in.MinimumWidth = 75
        Me.his_qty_in.Name = "his_qty_in"
        Me.his_qty_in.ReadOnly = True
        Me.his_qty_in.Width = 75
        '
        'his_qty_out
        '
        Me.his_qty_out.DataPropertyName = "trans_qty_out"
        Me.his_qty_out.HeaderText = "Kredit"
        Me.his_qty_out.MinimumWidth = 75
        Me.his_qty_out.Name = "his_qty_out"
        Me.his_qty_out.ReadOnly = True
        Me.his_qty_out.Width = 75
        '
        'his_source
        '
        Me.his_source.DataPropertyName = "trans_source"
        Me.his_source.HeaderText = "Asal"
        Me.his_source.MinimumWidth = 100
        Me.his_source.Name = "his_source"
        Me.his_source.ReadOnly = True
        '
        'his_dest
        '
        Me.his_dest.DataPropertyName = "trans_dest"
        Me.his_dest.HeaderText = "Tujuan"
        Me.his_dest.MinimumWidth = 100
        Me.his_dest.Name = "his_dest"
        Me.his_dest.ReadOnly = True
        '
        'cb_kodegd
        '
        Me.cb_kodegd.FormattingEnabled = True
        Me.cb_kodegd.Location = New System.Drawing.Point(77, 48)
        Me.cb_kodegd.Name = "cb_kodegd"
        Me.cb_kodegd.Size = New System.Drawing.Size(306, 21)
        Me.cb_kodegd.TabIndex = 395
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.Location = New System.Drawing.Point(15, 51)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(56, 16)
        Me.Label73.TabIndex = 394
        Me.Label73.Text = "Gudang"
        '
        'dt_akhir_st
        '
        Me.dt_akhir_st.CustomFormat = "MMMM yyyy"
        Me.dt_akhir_st.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_akhir_st.Location = New System.Drawing.Point(240, 77)
        Me.dt_akhir_st.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dt_akhir_st.Name = "dt_akhir_st"
        Me.dt_akhir_st.Size = New System.Drawing.Size(143, 20)
        Me.dt_akhir_st.TabIndex = 391
        Me.dt_akhir_st.Value = New Date(2018, 6, 22, 9, 15, 23, 0)
        '
        'dt_awal_st
        '
        Me.dt_awal_st.CustomFormat = "MMMM yyyy"
        Me.dt_awal_st.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_awal_st.Location = New System.Drawing.Point(77, 77)
        Me.dt_awal_st.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dt_awal_st.Name = "dt_awal_st"
        Me.dt_awal_st.Size = New System.Drawing.Size(143, 20)
        Me.dt_awal_st.TabIndex = 392
        Me.dt_awal_st.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'bt_view_st
        '
        Me.bt_view_st.Location = New System.Drawing.Point(397, 75)
        Me.bt_view_st.Name = "bt_view_st"
        Me.bt_view_st.Size = New System.Drawing.Size(75, 25)
        Me.bt_view_st.TabIndex = 390
        Me.bt_view_st.Text = "View"
        Me.bt_view_st.UseVisualStyleBackColor = True
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(224, 79)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(12, 16)
        Me.Label70.TabIndex = 388
        Me.Label70.Text = "-"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(15, 79)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(56, 16)
        Me.Label71.TabIndex = 389
        Me.Label71.Text = "Periode"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Source Sans Pro", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label72.Location = New System.Drawing.Point(14, 14)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(256, 24)
        Me.Label72.TabIndex = 386
        Me.Label72.Text = "Summary Transaksi Perbulan"
        '
        'bt_simpanbarang
        '
        Me.bt_simpanbarang.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_simpanbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbarang.Location = New System.Drawing.Point(580, 8)
        Me.bt_simpanbarang.Name = "bt_simpanbarang"
        Me.bt_simpanbarang.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpanbarang.TabIndex = 249
        Me.bt_simpanbarang.Text = "Simpan"
        Me.bt_simpanbarang.UseVisualStyleBackColor = True
        '
        'bt_batalbarang
        '
        Me.bt_batalbarang.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_batalbarang.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalbarang.Location = New System.Drawing.Point(682, 8)
        Me.bt_batalbarang.Name = "bt_batalbarang"
        Me.bt_batalbarang.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalbarang.TabIndex = 250
        Me.bt_batalbarang.Text = "Tutup"
        Me.bt_batalbarang.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Controls.Add(Me.bt_batalbarang)
        Me.Panel2.Controls.Add(Me.bt_simpanbarang)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 534)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(790, 45)
        Me.Panel2.TabIndex = 138
        '
        'fr_barang_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.bt_batalbarang
        Me.ClientSize = New System.Drawing.Size(790, 579)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.tab_prod)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "fr_barang_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detail Barang : "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tab_prod.ResumeLayout(False)
        Me.tb_prodinfo.ResumeLayout(False)
        Me.tb_prodinfo.PerformLayout()
        CType(Me.in_jual_d5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_jual_d4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_jual_d3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_jual_d2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_jual_d1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_harga_disc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_beli_klaim, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_beli_d3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_beli_d2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_beli_d1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_isi_besar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_isi_tengah, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_harga_rita, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_harga_horeka, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_harga_mt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_harga_jual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_harga_beli, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.dgv_his_st, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents tab_prod As System.Windows.Forms.TabControl
    Friend WithEvents tb_prodinfo As System.Windows.Forms.TabPage
    Friend WithEvents bt_simpanbarang As System.Windows.Forms.Button
    Friend WithEvents bt_batalbarang As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents in_nama As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents cb_jenis As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_harga_rita As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_harga_horeka As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_harga_mt As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_harga_jual As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_harga_beli As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbl_satuan2 As System.Windows.Forms.Label
    Friend WithEvents lbl_satuan1 As System.Windows.Forms.Label
    Friend WithEvents in_isi_besar As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_isi_tengah As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents cb_kategori As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents dt_akhir_st As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_awal_st As System.Windows.Forms.DateTimePicker
    Friend WithEvents bt_view_st As System.Windows.Forms.Button
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents cb_kodegd As System.Windows.Forms.ComboBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents dgv_his_st As System.Windows.Forms.DataGridView
    Friend WithEvents in_supplier As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bt_supplier_list As System.Windows.Forms.Button
    Friend WithEvents in_suppliernama As System.Windows.Forms.TextBox
    Friend WithEvents his_tanggal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_kodebarang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_barang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_qty_in As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_qty_out As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_source As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_dest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cb_sat_besar As System.Windows.Forms.ComboBox
    Friend WithEvents cb_sat_tengah As System.Windows.Forms.ComboBox
    Friend WithEvents cb_sat_kecil As System.Windows.Forms.ComboBox
    Friend WithEvents in_beli_klaim As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_beli_d3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_beli_d2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_beli_d1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents in_jual_d5 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_jual_d4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_jual_d3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_jual_d2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_jual_d1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_harga_disc As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cb_status As System.Windows.Forms.ComboBox
End Class
