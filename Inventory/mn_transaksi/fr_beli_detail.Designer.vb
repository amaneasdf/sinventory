﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_beli_detail
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_beli_detail))
        Me.in_klaim = New System.Windows.Forms.NumericUpDown()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.in_total_netto = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.in_total = New System.Windows.Forms.TextBox()
        Me.in_netto = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.in_ppn_tot = New System.Windows.Forms.TextBox()
        Me.in_diskon = New System.Windows.Forms.TextBox()
        Me.in_jumlah = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cb_ppn = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_faktur = New System.Windows.Forms.TextBox()
        Me.date_tgl_beli = New System.Windows.Forms.DateTimePicker()
        Me.bt_batalbeli = New System.Windows.Forms.Button()
        Me.bt_simpanbeli = New System.Windows.Forms.Button()
        Me.in_term = New System.Windows.Forms.NumericUpDown()
        Me.date_tgl_pajak = New System.Windows.Forms.DateTimePicker()
        Me.in_suratjalan = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.in_pajak = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb_sat = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.bt_tbbarang = New System.Windows.Forms.Button()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.linkLbl_searchbarang = New System.Windows.Forms.LinkLabel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.in_harga_beli = New System.Windows.Forms.NumericUpDown()
        Me.in_disc1 = New System.Windows.Forms.NumericUpDown()
        Me.in_discrp = New System.Windows.Forms.NumericUpDown()
        Me.in_subtotal = New System.Windows.Forms.TextBox()
        Me.in_disc2 = New System.Windows.Forms.NumericUpDown()
        Me.in_barang = New System.Windows.Forms.TextBox()
        Me.in_disc3 = New System.Windows.Forms.NumericUpDown()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.in_barang_nm = New System.Windows.Forms.TextBox()
        Me.in_qty = New System.Windows.Forms.NumericUpDown()
        Me.dgv_barang = New System.Windows.Forms.DataGridView()
        Me.kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.harga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subtot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.discrp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.disc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.disc2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.disc3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jml = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brg_filler = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.in_supplier_n = New System.Windows.Forms.TextBox()
        Me.in_supplier = New System.Windows.Forms.TextBox()
        Me.in_gudang_n = New System.Windows.Forms.TextBox()
        Me.in_gudang = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnl_footer = New System.Windows.Forms.Panel()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.in_status = New System.Windows.Forms.TextBox()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ctx_main = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tstrip_simpan = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstrip_print = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstrip_status = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstrip_inactivate = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstrip_activate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tstrip_delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstrip_other = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstrip_new_supplier = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstrip_new_barang = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstrip_new_gudang = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsrtip_close = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnl_header = New System.Windows.Forms.Panel()
        Me.bt_menu = New System.Windows.Forms.Button()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        CType(Me.in_klaim, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_term, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_harga_beli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_disc1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_discrp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_disc2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_disc3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_footer.SuspendLayout()
        Me.pnl_content.SuspendLayout()
        Me.ctx_main.SuspendLayout()
        Me.pnl_header.SuspendLayout()
        Me.SuspendLayout()
        '
        'in_klaim
        '
        Me.in_klaim.DecimalPlaces = 2
        Me.in_klaim.Font = New System.Drawing.Font("Open Sans", 8.75!)
        Me.in_klaim.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.in_klaim.Location = New System.Drawing.Point(933, 415)
        Me.in_klaim.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.in_klaim.Name = "in_klaim"
        Me.in_klaim.Size = New System.Drawing.Size(198, 23)
        Me.in_klaim.TabIndex = 30
        Me.in_klaim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_klaim.ThousandsSeparator = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label19.Location = New System.Drawing.Point(880, 417)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 18)
        Me.Label19.TabIndex = 342
        Me.Label19.Text = "Klaim"
        '
        'in_total_netto
        '
        Me.in_total_netto.BackColor = System.Drawing.Color.White
        Me.in_total_netto.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_total_netto.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_total_netto.ForeColor = System.Drawing.Color.Black
        Me.in_total_netto.Location = New System.Drawing.Point(933, 440)
        Me.in_total_netto.MaxLength = 20
        Me.in_total_netto.Name = "in_total_netto"
        Me.in_total_netto.ReadOnly = True
        Me.in_total_netto.Size = New System.Drawing.Size(198, 25)
        Me.in_total_netto.TabIndex = 31
        Me.in_total_netto.TabStop = False
        Me.in_total_netto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label18.Location = New System.Drawing.Point(880, 443)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(33, 18)
        Me.Label18.TabIndex = 343
        Me.Label18.Text = "Sisa"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(578, 461)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(28, 15)
        Me.Label15.TabIndex = 192
        Me.Label15.Text = "PPn"
        '
        'in_total
        '
        Me.in_total.BackColor = System.Drawing.Color.White
        Me.in_total.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_total.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_total.ForeColor = System.Drawing.Color.Black
        Me.in_total.Location = New System.Drawing.Point(646, 434)
        Me.in_total.MaxLength = 20
        Me.in_total.Name = "in_total"
        Me.in_total.ReadOnly = True
        Me.in_total.Size = New System.Drawing.Size(178, 22)
        Me.in_total.TabIndex = 27
        Me.in_total.TabStop = False
        Me.in_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_netto
        '
        Me.in_netto.BackColor = System.Drawing.Color.White
        Me.in_netto.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_netto.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_netto.ForeColor = System.Drawing.Color.Black
        Me.in_netto.Location = New System.Drawing.Point(933, 387)
        Me.in_netto.MaxLength = 20
        Me.in_netto.Name = "in_netto"
        Me.in_netto.ReadOnly = True
        Me.in_netto.Size = New System.Drawing.Size(198, 25)
        Me.in_netto.TabIndex = 29
        Me.in_netto.TabStop = False
        Me.in_netto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label17.Location = New System.Drawing.Point(880, 390)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 18)
        Me.Label17.TabIndex = 192
        Me.Label17.Text = "Netto"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(578, 437)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 15)
        Me.Label13.TabIndex = 192
        Me.Label13.Text = "Total"
        '
        'in_ppn_tot
        '
        Me.in_ppn_tot.BackColor = System.Drawing.Color.White
        Me.in_ppn_tot.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_ppn_tot.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ppn_tot.ForeColor = System.Drawing.Color.Black
        Me.in_ppn_tot.Location = New System.Drawing.Point(646, 458)
        Me.in_ppn_tot.MaxLength = 20
        Me.in_ppn_tot.Name = "in_ppn_tot"
        Me.in_ppn_tot.ReadOnly = True
        Me.in_ppn_tot.Size = New System.Drawing.Size(178, 22)
        Me.in_ppn_tot.TabIndex = 28
        Me.in_ppn_tot.TabStop = False
        Me.in_ppn_tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_diskon
        '
        Me.in_diskon.BackColor = System.Drawing.Color.White
        Me.in_diskon.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_diskon.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_diskon.ForeColor = System.Drawing.Color.Black
        Me.in_diskon.Location = New System.Drawing.Point(646, 410)
        Me.in_diskon.MaxLength = 20
        Me.in_diskon.Name = "in_diskon"
        Me.in_diskon.ReadOnly = True
        Me.in_diskon.Size = New System.Drawing.Size(178, 22)
        Me.in_diskon.TabIndex = 26
        Me.in_diskon.TabStop = False
        Me.in_diskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_jumlah
        '
        Me.in_jumlah.BackColor = System.Drawing.Color.White
        Me.in_jumlah.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_jumlah.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_jumlah.ForeColor = System.Drawing.Color.Black
        Me.in_jumlah.Location = New System.Drawing.Point(646, 386)
        Me.in_jumlah.MaxLength = 20
        Me.in_jumlah.Name = "in_jumlah"
        Me.in_jumlah.ReadOnly = True
        Me.in_jumlah.Size = New System.Drawing.Size(178, 22)
        Me.in_jumlah.TabIndex = 25
        Me.in_jumlah.TabStop = False
        Me.in_jumlah.Text = "0"
        Me.in_jumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(578, 389)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 15)
        Me.Label5.TabIndex = 192
        Me.Label5.Text = "Sub-Total"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(578, 413)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 15)
        Me.Label12.TabIndex = 192
        Me.Label12.Text = "Discount"
        '
        'cb_ppn
        '
        Me.cb_ppn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cb_ppn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_ppn.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_ppn.FormattingEnabled = True
        Me.cb_ppn.Items.AddRange(New Object() {"ii", "ooo", "eeee"})
        Me.cb_ppn.Location = New System.Drawing.Point(114, 102)
        Me.cb_ppn.Name = "cb_ppn"
        Me.cb_ppn.Size = New System.Drawing.Size(128, 23)
        Me.cb_ppn.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "No. Faktur"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 15)
        Me.Label1.TabIndex = 262
        Me.Label1.Text = "Tgl. Transaksi"
        '
        'in_faktur
        '
        Me.in_faktur.BackColor = System.Drawing.Color.White
        Me.in_faktur.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_faktur.ForeColor = System.Drawing.Color.Black
        Me.in_faktur.Location = New System.Drawing.Point(114, 6)
        Me.in_faktur.MaxLength = 20
        Me.in_faktur.Name = "in_faktur"
        Me.in_faktur.Size = New System.Drawing.Size(216, 22)
        Me.in_faktur.TabIndex = 0
        '
        'date_tgl_beli
        '
        Me.date_tgl_beli.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_beli.Location = New System.Drawing.Point(114, 30)
        Me.date_tgl_beli.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_beli.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_beli.Name = "date_tgl_beli"
        Me.date_tgl_beli.Size = New System.Drawing.Size(216, 22)
        Me.date_tgl_beli.TabIndex = 1
        '
        'bt_batalbeli
        '
        Me.bt_batalbeli.BackColor = System.Drawing.Color.Tomato
        Me.bt_batalbeli.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalbeli.FlatAppearance.BorderSize = 0
        Me.bt_batalbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_batalbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalbeli.ForeColor = System.Drawing.Color.White
        Me.bt_batalbeli.Location = New System.Drawing.Point(1033, 6)
        Me.bt_batalbeli.Name = "bt_batalbeli"
        Me.bt_batalbeli.Size = New System.Drawing.Size(96, 35)
        Me.bt_batalbeli.TabIndex = 34
        Me.bt_batalbeli.Text = "Batal"
        Me.bt_batalbeli.UseVisualStyleBackColor = False
        '
        'bt_simpanbeli
        '
        Me.bt_simpanbeli.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpanbeli.FlatAppearance.BorderSize = 0
        Me.bt_simpanbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpanbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbeli.ForeColor = System.Drawing.Color.White
        Me.bt_simpanbeli.Location = New System.Drawing.Point(856, 6)
        Me.bt_simpanbeli.Name = "bt_simpanbeli"
        Me.bt_simpanbeli.Size = New System.Drawing.Size(171, 35)
        Me.bt_simpanbeli.TabIndex = 33
        Me.bt_simpanbeli.Text = "Simpan"
        Me.bt_simpanbeli.UseVisualStyleBackColor = False
        '
        'in_term
        '
        Me.in_term.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_term.Location = New System.Drawing.Point(749, 104)
        Me.in_term.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.in_term.Name = "in_term"
        Me.in_term.Size = New System.Drawing.Size(91, 22)
        Me.in_term.TabIndex = 10
        Me.in_term.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'date_tgl_pajak
        '
        Me.date_tgl_pajak.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_pajak.Location = New System.Drawing.Point(749, 32)
        Me.date_tgl_pajak.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_pajak.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_pajak.Name = "date_tgl_pajak"
        Me.date_tgl_pajak.Size = New System.Drawing.Size(188, 22)
        Me.date_tgl_pajak.TabIndex = 7
        '
        'in_suratjalan
        '
        Me.in_suratjalan.BackColor = System.Drawing.Color.White
        Me.in_suratjalan.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_suratjalan.ForeColor = System.Drawing.Color.Black
        Me.in_suratjalan.Location = New System.Drawing.Point(749, 80)
        Me.in_suratjalan.MaxLength = 255
        Me.in_suratjalan.Name = "in_suratjalan"
        Me.in_suratjalan.Size = New System.Drawing.Size(287, 22)
        Me.in_suratjalan.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(643, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 15)
        Me.Label8.TabIndex = 335
        Me.Label8.Text = "Termin"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(11, 106)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 15)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Jenis Pjk Item"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(643, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 15)
        Me.Label9.TabIndex = 336
        Me.Label9.Text = "Surat Jalan"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 15)
        Me.Label7.TabIndex = 337
        Me.Label7.Text = "Supplier"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 15)
        Me.Label6.TabIndex = 339
        Me.Label6.Text = "Gudang"
        '
        'in_pajak
        '
        Me.in_pajak.BackColor = System.Drawing.Color.White
        Me.in_pajak.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_pajak.ForeColor = System.Drawing.Color.Black
        Me.in_pajak.Location = New System.Drawing.Point(749, 55)
        Me.in_pajak.MaxLength = 20
        Me.in_pajak.Name = "in_pajak"
        Me.in_pajak.Size = New System.Drawing.Size(287, 22)
        Me.in_pajak.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(643, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 15)
        Me.Label3.TabIndex = 340
        Me.Label3.Text = "Tgl.Pajak"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(643, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 341
        Me.Label2.Text = "No.Pajak"
        '
        'cb_sat
        '
        Me.cb_sat.BackColor = System.Drawing.Color.White
        Me.cb_sat.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_sat.FormattingEnabled = True
        Me.cb_sat.Location = New System.Drawing.Point(465, 150)
        Me.cb_sat.Name = "cb_sat"
        Me.cb_sat.Size = New System.Drawing.Size(61, 23)
        Me.cb_sat.TabIndex = 14
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label23.Location = New System.Drawing.Point(865, 133)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(35, 15)
        Me.Label23.TabIndex = 256
        Me.Label23.Text = "Disc1"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label24.Location = New System.Drawing.Point(922, 133)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(35, 15)
        Me.Label24.TabIndex = 256
        Me.Label24.Text = "Disc2"
        '
        'bt_tbbarang
        '
        Me.bt_tbbarang.BackColor = System.Drawing.Color.Transparent
        Me.bt_tbbarang.BackgroundImage = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.bt_tbbarang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_tbbarang.FlatAppearance.BorderSize = 0
        Me.bt_tbbarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_tbbarang.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tbbarang.Location = New System.Drawing.Point(1046, 152)
        Me.bt_tbbarang.Name = "bt_tbbarang"
        Me.bt_tbbarang.Size = New System.Drawing.Size(18, 18)
        Me.bt_tbbarang.TabIndex = 21
        Me.bt_tbbarang.UseVisualStyleBackColor = False
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Controls.Add(Me.linkLbl_searchbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(534, 223)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(375, 131)
        Me.popPnl_barang.TabIndex = 263
        Me.popPnl_barang.Visible = False
        '
        'dgv_listbarang
        '
        Me.dgv_listbarang.AllowUserToAddRows = False
        Me.dgv_listbarang.AllowUserToDeleteRows = False
        Me.dgv_listbarang.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv_listbarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listbarang.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgv_listbarang.Location = New System.Drawing.Point(0, 0)
        Me.dgv_listbarang.MultiSelect = False
        Me.dgv_listbarang.Name = "dgv_listbarang"
        Me.dgv_listbarang.ReadOnly = True
        Me.dgv_listbarang.RowHeadersVisible = False
        Me.dgv_listbarang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listbarang.Size = New System.Drawing.Size(375, 127)
        Me.dgv_listbarang.TabIndex = 0
        '
        'linkLbl_searchbarang
        '
        Me.linkLbl_searchbarang.AutoSize = True
        Me.linkLbl_searchbarang.LinkColor = System.Drawing.Color.DimGray
        Me.linkLbl_searchbarang.Location = New System.Drawing.Point(3, 113)
        Me.linkLbl_searchbarang.Name = "linkLbl_searchbarang"
        Me.linkLbl_searchbarang.Size = New System.Drawing.Size(124, 15)
        Me.linkLbl_searchbarang.TabIndex = 1
        Me.linkLbl_searchbarang.TabStop = True
        Me.linkLbl_searchbarang.Text = "Tampilkan Pencarian..."
        Me.linkLbl_searchbarang.VisitedLinkColor = System.Drawing.Color.DimGray
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label25.Location = New System.Drawing.Point(979, 133)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(35, 15)
        Me.Label25.TabIndex = 256
        Me.Label25.Text = "Disc3"
        '
        'in_harga_beli
        '
        Me.in_harga_beli.DecimalPlaces = 2
        Me.in_harga_beli.Font = New System.Drawing.Font("Open Sans", 8.275!)
        Me.in_harga_beli.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.in_harga_beli.Location = New System.Drawing.Point(530, 150)
        Me.in_harga_beli.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.in_harga_beli.Name = "in_harga_beli"
        Me.in_harga_beli.Size = New System.Drawing.Size(115, 23)
        Me.in_harga_beli.TabIndex = 15
        Me.in_harga_beli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_harga_beli.ThousandsSeparator = True
        '
        'in_disc1
        '
        Me.in_disc1.DecimalPlaces = 2
        Me.in_disc1.Font = New System.Drawing.Font("Open Sans", 8.275!)
        Me.in_disc1.Location = New System.Drawing.Point(868, 150)
        Me.in_disc1.Name = "in_disc1"
        Me.in_disc1.Size = New System.Drawing.Size(56, 23)
        Me.in_disc1.TabIndex = 18
        Me.in_disc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_discrp
        '
        Me.in_discrp.DecimalPlaces = 2
        Me.in_discrp.Font = New System.Drawing.Font("Open Sans", 8.275!)
        Me.in_discrp.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.in_discrp.Location = New System.Drawing.Point(765, 150)
        Me.in_discrp.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.in_discrp.Name = "in_discrp"
        Me.in_discrp.Size = New System.Drawing.Size(101, 23)
        Me.in_discrp.TabIndex = 17
        Me.in_discrp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_discrp.ThousandsSeparator = True
        '
        'in_subtotal
        '
        Me.in_subtotal.Font = New System.Drawing.Font("Open Sans", 8.275!)
        Me.in_subtotal.Location = New System.Drawing.Point(649, 150)
        Me.in_subtotal.Name = "in_subtotal"
        Me.in_subtotal.Size = New System.Drawing.Size(112, 23)
        Me.in_subtotal.TabIndex = 16
        Me.in_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_disc2
        '
        Me.in_disc2.DecimalPlaces = 2
        Me.in_disc2.Font = New System.Drawing.Font("Open Sans", 8.275!)
        Me.in_disc2.Location = New System.Drawing.Point(925, 150)
        Me.in_disc2.Name = "in_disc2"
        Me.in_disc2.Size = New System.Drawing.Size(56, 23)
        Me.in_disc2.TabIndex = 19
        Me.in_disc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_barang
        '
        Me.in_barang.BackColor = System.Drawing.Color.Gainsboro
        Me.in_barang.Font = New System.Drawing.Font("Open Sans", 8.275!)
        Me.in_barang.Location = New System.Drawing.Point(14, 150)
        Me.in_barang.MaxLength = 20
        Me.in_barang.Name = "in_barang"
        Me.in_barang.ReadOnly = True
        Me.in_barang.Size = New System.Drawing.Size(100, 23)
        Me.in_barang.TabIndex = 11
        Me.in_barang.TabStop = False
        '
        'in_disc3
        '
        Me.in_disc3.DecimalPlaces = 2
        Me.in_disc3.Font = New System.Drawing.Font("Open Sans", 8.275!)
        Me.in_disc3.Location = New System.Drawing.Point(982, 150)
        Me.in_disc3.Name = "in_disc3"
        Me.in_disc3.Size = New System.Drawing.Size(56, 23)
        Me.in_disc3.TabIndex = 20
        Me.in_disc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label32.Location = New System.Drawing.Point(762, 133)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(64, 15)
        Me.Label32.TabIndex = 256
        Me.Label32.Text = "Diskon Rp."
        '
        'in_barang_nm
        '
        Me.in_barang_nm.BackColor = System.Drawing.Color.White
        Me.in_barang_nm.Font = New System.Drawing.Font("Open Sans", 8.275!)
        Me.in_barang_nm.ForeColor = System.Drawing.Color.Black
        Me.in_barang_nm.Location = New System.Drawing.Point(114, 150)
        Me.in_barang_nm.MaxLength = 150
        Me.in_barang_nm.Name = "in_barang_nm"
        Me.in_barang_nm.Size = New System.Drawing.Size(282, 23)
        Me.in_barang_nm.TabIndex = 12
        '
        'in_qty
        '
        Me.in_qty.Font = New System.Drawing.Font("Open Sans", 8.275!)
        Me.in_qty.Location = New System.Drawing.Point(400, 150)
        Me.in_qty.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.in_qty.Name = "in_qty"
        Me.in_qty.Size = New System.Drawing.Size(64, 23)
        Me.in_qty.TabIndex = 13
        Me.in_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgv_barang
        '
        Me.dgv_barang.AllowUserToAddRows = False
        Me.dgv_barang.AllowUserToDeleteRows = False
        Me.dgv_barang.BackgroundColor = System.Drawing.Color.White
        Me.dgv_barang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_barang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kode, Me.nama, Me.qty, Me.sat, Me.sat_type, Me.harga, Me.subtot, Me.discrp, Me.disc1, Me.disc2, Me.disc3, Me.jml, Me.brg_filler})
        Me.dgv_barang.Location = New System.Drawing.Point(14, 175)
        Me.dgv_barang.MultiSelect = False
        Me.dgv_barang.Name = "dgv_barang"
        Me.dgv_barang.ReadOnly = True
        Me.dgv_barang.RowHeadersVisible = False
        Me.dgv_barang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_barang.Size = New System.Drawing.Size(1117, 207)
        Me.dgv_barang.TabIndex = 22
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
        Me.nama.MinimumWidth = 50
        Me.nama.Name = "nama"
        Me.nama.ReadOnly = True
        Me.nama.Width = 250
        '
        'qty
        '
        Me.qty.DataPropertyName = "trans_qty"
        Me.qty.HeaderText = "QTY"
        Me.qty.MinimumWidth = 10
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        Me.qty.Width = 65
        '
        'sat
        '
        Me.sat.DataPropertyName = "trans_satuan"
        Me.sat.HeaderText = "Satuan"
        Me.sat.MinimumWidth = 10
        Me.sat.Name = "sat"
        Me.sat.ReadOnly = True
        Me.sat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.sat.Width = 80
        '
        'sat_type
        '
        Me.sat_type.DataPropertyName = "trans_satuan_type"
        Me.sat_type.HeaderText = "sat_type"
        Me.sat_type.Name = "sat_type"
        Me.sat_type.ReadOnly = True
        Me.sat_type.Visible = False
        '
        'harga
        '
        Me.harga.DataPropertyName = "trans_harga_beli"
        Me.harga.HeaderText = "Harga Beli"
        Me.harga.MinimumWidth = 40
        Me.harga.Name = "harga"
        Me.harga.ReadOnly = True
        Me.harga.Width = 110
        '
        'subtot
        '
        Me.subtot.DataPropertyName = "trans_subtot"
        Me.subtot.HeaderText = "Sub-Total"
        Me.subtot.MinimumWidth = 40
        Me.subtot.Name = "subtot"
        Me.subtot.ReadOnly = True
        Me.subtot.Width = 125
        '
        'discrp
        '
        Me.discrp.DataPropertyName = "trans_disc_rupiah"
        Me.discrp.HeaderText = "Disc Rp."
        Me.discrp.MinimumWidth = 40
        Me.discrp.Name = "discrp"
        Me.discrp.ReadOnly = True
        Me.discrp.Width = 90
        '
        'disc1
        '
        Me.disc1.DataPropertyName = "trans_disc1"
        Me.disc1.HeaderText = "Disc1"
        Me.disc1.MinimumWidth = 10
        Me.disc1.Name = "disc1"
        Me.disc1.ReadOnly = True
        Me.disc1.Width = 50
        '
        'disc2
        '
        Me.disc2.DataPropertyName = "trans_disc2"
        Me.disc2.HeaderText = "Disc2"
        Me.disc2.MinimumWidth = 10
        Me.disc2.Name = "disc2"
        Me.disc2.ReadOnly = True
        Me.disc2.Width = 50
        '
        'disc3
        '
        Me.disc3.DataPropertyName = "trans_disc3"
        Me.disc3.HeaderText = "Disc3"
        Me.disc3.MinimumWidth = 10
        Me.disc3.Name = "disc3"
        Me.disc3.ReadOnly = True
        Me.disc3.Width = 50
        '
        'jml
        '
        Me.jml.DataPropertyName = "trans_jumlah"
        Me.jml.HeaderText = "Jumlah"
        Me.jml.Name = "jml"
        Me.jml.ReadOnly = True
        Me.jml.Width = 125
        '
        'brg_filler
        '
        Me.brg_filler.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.brg_filler.HeaderText = ""
        Me.brg_filler.Name = "brg_filler"
        Me.brg_filler.ReadOnly = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label31.Location = New System.Drawing.Point(646, 133)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(54, 15)
        Me.Label31.TabIndex = 256
        Me.Label31.Text = "Subtotal"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label22.Location = New System.Drawing.Point(527, 133)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(62, 15)
        Me.Label22.TabIndex = 256
        Me.Label22.Text = "Harga Beli"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label11.Location = New System.Drawing.Point(462, 133)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(28, 15)
        Me.Label11.TabIndex = 256
        Me.Label11.Text = "Sat."
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label21.Location = New System.Drawing.Point(397, 133)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(27, 15)
        Me.Label21.TabIndex = 256
        Me.Label21.Text = "Qty"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label20.Location = New System.Drawing.Point(111, 133)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 15)
        Me.Label20.TabIndex = 256
        Me.Label20.Text = "Nama Barang"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(11, 133)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 15)
        Me.Label16.TabIndex = 256
        Me.Label16.Text = "Kode Barang"
        '
        'in_supplier_n
        '
        Me.in_supplier_n.BackColor = System.Drawing.Color.White
        Me.in_supplier_n.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier_n.ForeColor = System.Drawing.Color.Black
        Me.in_supplier_n.Location = New System.Drawing.Point(218, 54)
        Me.in_supplier_n.MaxLength = 200
        Me.in_supplier_n.Name = "in_supplier_n"
        Me.in_supplier_n.Size = New System.Drawing.Size(336, 22)
        Me.in_supplier_n.TabIndex = 3
        '
        'in_supplier
        '
        Me.in_supplier.BackColor = System.Drawing.Color.Gainsboro
        Me.in_supplier.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier.ForeColor = System.Drawing.Color.Black
        Me.in_supplier.Location = New System.Drawing.Point(114, 54)
        Me.in_supplier.MaxLength = 30
        Me.in_supplier.Name = "in_supplier"
        Me.in_supplier.ReadOnly = True
        Me.in_supplier.Size = New System.Drawing.Size(104, 22)
        Me.in_supplier.TabIndex = 2
        '
        'in_gudang_n
        '
        Me.in_gudang_n.BackColor = System.Drawing.Color.White
        Me.in_gudang_n.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang_n.ForeColor = System.Drawing.Color.Black
        Me.in_gudang_n.Location = New System.Drawing.Point(218, 78)
        Me.in_gudang_n.MaxLength = 200
        Me.in_gudang_n.Name = "in_gudang_n"
        Me.in_gudang_n.Size = New System.Drawing.Size(336, 22)
        Me.in_gudang_n.TabIndex = 5
        '
        'in_gudang
        '
        Me.in_gudang.BackColor = System.Drawing.Color.Gainsboro
        Me.in_gudang.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang.ForeColor = System.Drawing.Color.Black
        Me.in_gudang.Location = New System.Drawing.Point(114, 78)
        Me.in_gudang.MaxLength = 30
        Me.in_gudang.Name = "in_gudang"
        Me.in_gudang.ReadOnly = True
        Me.in_gudang.Size = New System.Drawing.Size(104, 22)
        Me.in_gudang.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 595)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1140, 5)
        Me.Panel3.TabIndex = 409
        '
        'pnl_footer
        '
        Me.pnl_footer.AutoScroll = True
        Me.pnl_footer.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnl_footer.Controls.Add(Me.bt_simpanbeli)
        Me.pnl_footer.Controls.Add(Me.bt_batalbeli)
        Me.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_footer.Location = New System.Drawing.Point(0, 547)
        Me.pnl_footer.Name = "pnl_footer"
        Me.pnl_footer.Size = New System.Drawing.Size(1140, 48)
        Me.pnl_footer.TabIndex = 32
        '
        'pnl_content
        '
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.Controls.Add(Me.popPnl_barang)
        Me.pnl_content.Controls.Add(Me.Label10)
        Me.pnl_content.Controls.Add(Me.in_status)
        Me.pnl_content.Controls.Add(Me.in_ket)
        Me.pnl_content.Controls.Add(Me.Label26)
        Me.pnl_content.Controls.Add(Me.in_qty)
        Me.pnl_content.Controls.Add(Me.Label4)
        Me.pnl_content.Controls.Add(Me.dgv_barang)
        Me.pnl_content.Controls.Add(Me.Label6)
        Me.pnl_content.Controls.Add(Me.cb_sat)
        Me.pnl_content.Controls.Add(Me.Label7)
        Me.pnl_content.Controls.Add(Me.Label9)
        Me.pnl_content.Controls.Add(Me.Label23)
        Me.pnl_content.Controls.Add(Me.Label15)
        Me.pnl_content.Controls.Add(Me.Label14)
        Me.pnl_content.Controls.Add(Me.Label2)
        Me.pnl_content.Controls.Add(Me.in_term)
        Me.pnl_content.Controls.Add(Me.Label24)
        Me.pnl_content.Controls.Add(Me.in_suratjalan)
        Me.pnl_content.Controls.Add(Me.in_gudang_n)
        Me.pnl_content.Controls.Add(Me.Label8)
        Me.pnl_content.Controls.Add(Me.Label3)
        Me.pnl_content.Controls.Add(Me.bt_tbbarang)
        Me.pnl_content.Controls.Add(Me.in_total)
        Me.pnl_content.Controls.Add(Me.date_tgl_pajak)
        Me.pnl_content.Controls.Add(Me.Label25)
        Me.pnl_content.Controls.Add(Me.in_pajak)
        Me.pnl_content.Controls.Add(Me.cb_ppn)
        Me.pnl_content.Controls.Add(Me.in_gudang)
        Me.pnl_content.Controls.Add(Me.Label18)
        Me.pnl_content.Controls.Add(Me.in_harga_beli)
        Me.pnl_content.Controls.Add(Me.in_total_netto)
        Me.pnl_content.Controls.Add(Me.in_netto)
        Me.pnl_content.Controls.Add(Me.Label19)
        Me.pnl_content.Controls.Add(Me.in_disc1)
        Me.pnl_content.Controls.Add(Me.in_klaim)
        Me.pnl_content.Controls.Add(Me.Label17)
        Me.pnl_content.Controls.Add(Me.in_discrp)
        Me.pnl_content.Controls.Add(Me.in_supplier_n)
        Me.pnl_content.Controls.Add(Me.date_tgl_beli)
        Me.pnl_content.Controls.Add(Me.in_subtotal)
        Me.pnl_content.Controls.Add(Me.in_faktur)
        Me.pnl_content.Controls.Add(Me.Label13)
        Me.pnl_content.Controls.Add(Me.Label1)
        Me.pnl_content.Controls.Add(Me.in_disc2)
        Me.pnl_content.Controls.Add(Me.Label16)
        Me.pnl_content.Controls.Add(Me.in_supplier)
        Me.pnl_content.Controls.Add(Me.Label20)
        Me.pnl_content.Controls.Add(Me.in_barang)
        Me.pnl_content.Controls.Add(Me.Label12)
        Me.pnl_content.Controls.Add(Me.in_ppn_tot)
        Me.pnl_content.Controls.Add(Me.Label21)
        Me.pnl_content.Controls.Add(Me.in_disc3)
        Me.pnl_content.Controls.Add(Me.Label11)
        Me.pnl_content.Controls.Add(Me.Label5)
        Me.pnl_content.Controls.Add(Me.Label32)
        Me.pnl_content.Controls.Add(Me.Label22)
        Me.pnl_content.Controls.Add(Me.in_diskon)
        Me.pnl_content.Controls.Add(Me.Label31)
        Me.pnl_content.Controls.Add(Me.in_barang_nm)
        Me.pnl_content.Controls.Add(Me.in_jumlah)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_content.Location = New System.Drawing.Point(0, 42)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(1140, 505)
        Me.pnl_content.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 471)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 15)
        Me.Label10.TabIndex = 454
        Me.Label10.Text = "Status Trans."
        '
        'in_status
        '
        Me.in_status.BackColor = System.Drawing.Color.Gainsboro
        Me.in_status.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status.ForeColor = System.Drawing.Color.Black
        Me.in_status.Location = New System.Drawing.Point(114, 468)
        Me.in_status.Name = "in_status"
        Me.in_status.ReadOnly = True
        Me.in_status.Size = New System.Drawing.Size(133, 22)
        Me.in_status.TabIndex = 24
        Me.in_status.TabStop = False
        Me.in_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'in_ket
        '
        Me.in_ket.BackColor = System.Drawing.Color.White
        Me.in_ket.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.ForeColor = System.Drawing.Color.Black
        Me.in_ket.Location = New System.Drawing.Point(114, 387)
        Me.in_ket.MaxLength = 200
        Me.in_ket.Multiline = True
        Me.in_ket.Name = "in_ket"
        Me.in_ket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_ket.Size = New System.Drawing.Size(364, 75)
        Me.in_ket.TabIndex = 23
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(11, 389)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(87, 15)
        Me.Label26.TabIndex = 455
        Me.Label26.Text = "Catatan Invoice"
        '
        'ctx_main
        '
        Me.ctx_main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstrip_simpan, Me.tstrip_print, Me.tstrip_status, Me.tstrip_other, Me.ToolStripSeparator3, Me.tsrtip_close})
        Me.ctx_main.Name = "ctx_main"
        Me.ctx_main.Size = New System.Drawing.Size(188, 120)
        '
        'tstrip_simpan
        '
        Me.tstrip_simpan.Name = "tstrip_simpan"
        Me.tstrip_simpan.Size = New System.Drawing.Size(187, 22)
        Me.tstrip_simpan.Text = "Simpan"
        '
        'tstrip_print
        '
        Me.tstrip_print.Name = "tstrip_print"
        Me.tstrip_print.Size = New System.Drawing.Size(187, 22)
        Me.tstrip_print.Text = "Cetak Nota Transaksi"
        '
        'tstrip_status
        '
        Me.tstrip_status.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstrip_inactivate, Me.tstrip_activate, Me.ToolStripSeparator2, Me.tstrip_delete})
        Me.tstrip_status.Name = "tstrip_status"
        Me.tstrip_status.Size = New System.Drawing.Size(187, 22)
        Me.tstrip_status.Text = "Ubah Status Transaksi"
        '
        'tstrip_inactivate
        '
        Me.tstrip_inactivate.Name = "tstrip_inactivate"
        Me.tstrip_inactivate.Size = New System.Drawing.Size(209, 22)
        Me.tstrip_inactivate.Text = "Batalkan Transaksi"
        '
        'tstrip_activate
        '
        Me.tstrip_activate.Name = "tstrip_activate"
        Me.tstrip_activate.Size = New System.Drawing.Size(209, 22)
        Me.tstrip_activate.Text = "Cancel Pembatalan Trans."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(206, 6)
        '
        'tstrip_delete
        '
        Me.tstrip_delete.Name = "tstrip_delete"
        Me.tstrip_delete.Size = New System.Drawing.Size(209, 22)
        Me.tstrip_delete.Text = "Hapus Transaksi"
        '
        'tstrip_other
        '
        Me.tstrip_other.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstrip_new_supplier, Me.tstrip_new_barang, Me.tstrip_new_gudang})
        Me.tstrip_other.Name = "tstrip_other"
        Me.tstrip_other.Size = New System.Drawing.Size(187, 22)
        Me.tstrip_other.Text = "Lain-Lain"
        '
        'tstrip_new_supplier
        '
        Me.tstrip_new_supplier.Name = "tstrip_new_supplier"
        Me.tstrip_new_supplier.Size = New System.Drawing.Size(171, 22)
        Me.tstrip_new_supplier.Text = "Buat Supplier Baru"
        '
        'tstrip_new_barang
        '
        Me.tstrip_new_barang.Name = "tstrip_new_barang"
        Me.tstrip_new_barang.Size = New System.Drawing.Size(171, 22)
        Me.tstrip_new_barang.Text = "Buat Barang Baru"
        '
        'tstrip_new_gudang
        '
        Me.tstrip_new_gudang.Name = "tstrip_new_gudang"
        Me.tstrip_new_gudang.Size = New System.Drawing.Size(171, 22)
        Me.tstrip_new_gudang.Text = "Buat Gudang Baru"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(184, 6)
        '
        'tsrtip_close
        '
        Me.tsrtip_close.Name = "tsrtip_close"
        Me.tsrtip_close.Size = New System.Drawing.Size(187, 22)
        Me.tsrtip_close.Text = "Tutup Form Transaksi"
        '
        'pnl_header
        '
        Me.pnl_header.BackColor = System.Drawing.Color.White
        Me.pnl_header.Controls.Add(Me.bt_menu)
        Me.pnl_header.Controls.Add(Me.bt_cl)
        Me.pnl_header.Controls.Add(Me.lbl_title)
        Me.pnl_header.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_header.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_header.Location = New System.Drawing.Point(0, 0)
        Me.pnl_header.Name = "pnl_header"
        Me.pnl_header.Size = New System.Drawing.Size(1140, 42)
        Me.pnl_header.TabIndex = 3
        '
        'bt_menu
        '
        Me.bt_menu.BackColor = System.Drawing.Color.DarkOrange
        Me.bt_menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_menu.FlatAppearance.BorderSize = 0
        Me.bt_menu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange
        Me.bt_menu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed
        Me.bt_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_menu.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_menu.Image = Global.Inventory.My.Resources.Resources.menu_wh_thin_16x16
        Me.bt_menu.Location = New System.Drawing.Point(0, 5)
        Me.bt_menu.Name = "bt_menu"
        Me.bt_menu.Size = New System.Drawing.Size(32, 32)
        Me.bt_menu.TabIndex = 138
        Me.bt_menu.TabStop = False
        Me.bt_menu.UseVisualStyleBackColor = False
        '
        'bt_cl
        '
        Me.bt_cl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_cl.BackColor = System.Drawing.Color.Brown
        Me.bt_cl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_cl.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_cl.FlatAppearance.BorderSize = 0
        Me.bt_cl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tomato
        Me.bt_cl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.bt_cl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cl.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cl.Image = Global.Inventory.My.Resources.Resources.close_wh_thin_16x16
        Me.bt_cl.Location = New System.Drawing.Point(1082, 0)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(55, 30)
        Me.bt_cl.TabIndex = 137
        Me.bt_cl.TabStop = False
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.White
        Me.lbl_title.Font = New System.Drawing.Font("Open Sans", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_title.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbl_title.Location = New System.Drawing.Point(35, 8)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(207, 26)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Transaksi Pembelian"
        '
        'fr_beli_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1140, 600)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.pnl_header)
        Me.Controls.Add(Me.pnl_footer)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_beli_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pembelian : "
        CType(Me.in_klaim, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_term, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popPnl_barang.ResumeLayout(False)
        Me.popPnl_barang.PerformLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_harga_beli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_disc1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_discrp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_disc2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_disc3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_qty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_footer.ResumeLayout(False)
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.ctx_main.ResumeLayout(False)
        Me.pnl_header.ResumeLayout(False)
        Me.pnl_header.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents in_klaim As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents in_total_netto As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents in_total As System.Windows.Forms.TextBox
    Friend WithEvents in_netto As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents in_ppn_tot As System.Windows.Forms.TextBox
    Friend WithEvents in_diskon As System.Windows.Forms.TextBox
    Friend WithEvents in_jumlah As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cb_ppn As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_faktur As System.Windows.Forms.TextBox
    Friend WithEvents date_tgl_beli As System.Windows.Forms.DateTimePicker
    Friend WithEvents bt_batalbeli As System.Windows.Forms.Button
    Friend WithEvents bt_simpanbeli As System.Windows.Forms.Button
    Friend WithEvents in_term As System.Windows.Forms.NumericUpDown
    Friend WithEvents date_tgl_pajak As System.Windows.Forms.DateTimePicker
    Friend WithEvents in_suratjalan As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents in_pajak As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cb_sat As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents bt_tbbarang As System.Windows.Forms.Button
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents linkLbl_searchbarang As System.Windows.Forms.LinkLabel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents in_harga_beli As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_disc1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_discrp As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents in_disc2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_barang As System.Windows.Forms.TextBox
    Friend WithEvents in_disc3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents in_barang_nm As System.Windows.Forms.TextBox
    Friend WithEvents in_qty As System.Windows.Forms.NumericUpDown
    Friend WithEvents dgv_barang As System.Windows.Forms.DataGridView
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents in_supplier_n As System.Windows.Forms.TextBox
    Friend WithEvents in_supplier As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnl_footer As System.Windows.Forms.Panel
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents ctx_main As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tstrip_simpan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstrip_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstrip_status As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstrip_inactivate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstrip_activate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstrip_delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstrip_other As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstrip_new_supplier As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstrip_new_barang As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstrip_new_gudang As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsrtip_close As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnl_header As System.Windows.Forms.Panel
    Friend WithEvents bt_menu As System.Windows.Forms.Button
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents in_status As System.Windows.Forms.TextBox
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents harga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents subtot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents discrp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disc1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disc2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disc3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jml As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brg_filler As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
