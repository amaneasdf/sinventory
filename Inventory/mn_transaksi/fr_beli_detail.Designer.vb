<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_beli_detail))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_print = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_cancelorder = New System.Windows.Forms.ToolStripMenuItem()
        Me.split_content = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tb_beli = New System.Windows.Forms.TabPage()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.in_klaim = New System.Windows.Forms.NumericUpDown()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.in_total_netto = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.in_discount = New System.Windows.Forms.NumericUpDown()
        Me.in_total = New System.Windows.Forms.TextBox()
        Me.in_netto = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.in_ppn_tot = New System.Windows.Forms.TextBox()
        Me.in_jumlah = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.bt_gudang_list = New System.Windows.Forms.Button()
        Me.bt_supplier_list = New System.Windows.Forms.Button()
        Me.cb_gudang = New System.Windows.Forms.ComboBox()
        Me.cb_ppn = New System.Windows.Forms.ComboBox()
        Me.cb_supplier = New System.Windows.Forms.ComboBox()
        Me.gb_fakturkode = New System.Windows.Forms.GroupBox()
        Me.in_status_kode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_faktur = New System.Windows.Forms.TextBox()
        Me.date_tgl_beli = New System.Windows.Forms.DateTimePicker()
        Me.bt_batalbeli = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.bt_tbbarang = New System.Windows.Forms.Button()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.linkLbl_searchbarang = New System.Windows.Forms.LinkLabel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.brg_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brg_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brg_beli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.in_harga_beli = New System.Windows.Forms.NumericUpDown()
        Me.in_disc1 = New System.Windows.Forms.NumericUpDown()
        Me.in_discrp = New System.Windows.Forms.NumericUpDown()
        Me.in_subtotal = New System.Windows.Forms.TextBox()
        Me.in_disc2 = New System.Windows.Forms.NumericUpDown()
        Me.in_barang = New System.Windows.Forms.TextBox()
        Me.in_disc3 = New System.Windows.Forms.NumericUpDown()
        Me.in_satuan = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.in_barang_nm = New System.Windows.Forms.TextBox()
        Me.in_qty = New System.Windows.Forms.NumericUpDown()
        Me.dgv_barang = New System.Windows.Forms.DataGridView()
        Me.kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.harga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subtot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ppnbrg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.disc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.disc2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.disc3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.discrp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jml = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.NumericUpDown6 = New System.Windows.Forms.NumericUpDown()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.rec_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_brg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_sat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.retur_ket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
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
        Me.MenuStrip1.SuspendLayout()
        CType(Me.split_content, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.split_content.Panel1.SuspendLayout()
        Me.split_content.Panel2.SuspendLayout()
        Me.split_content.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tb_beli.SuspendLayout()
        CType(Me.in_klaim, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.in_discount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_fakturkode.SuspendLayout()
        CType(Me.in_term, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_harga_beli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_disc1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_discrp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_disc2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_disc3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.lbl_close)
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1038, 42)
        Me.Panel1.TabIndex = 180
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(958, 9)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(47, 20)
        Me.lbl_close.TabIndex = 138
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
        Me.bt_cl.Location = New System.Drawing.Point(1011, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 137
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Orange
        Me.Label11.Font = New System.Drawing.Font("Source Sans Pro", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(6, 4)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(248, 30)
        Me.Label11.TabIndex = 136
        Me.Label11.Text = "Data Order Pembelian"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_print, Me.mn_cancelorder})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1038, 24)
        Me.MenuStrip1.TabIndex = 181
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mn_save
        '
        Me.mn_save.Image = Global.Inventory.My.Resources.Resources.toolbar_save_icon_s
        Me.mn_save.Name = "mn_save"
        Me.mn_save.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mn_save.Size = New System.Drawing.Size(59, 20)
        Me.mn_save.Text = "&Save"
        Me.mn_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mn_print
        '
        Me.mn_print.Image = CType(resources.GetObject("mn_print.Image"), System.Drawing.Image)
        Me.mn_print.Name = "mn_print"
        Me.mn_print.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.mn_print.Size = New System.Drawing.Size(60, 20)
        Me.mn_print.Text = "&Print"
        Me.mn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mn_cancelorder
        '
        Me.mn_cancelorder.Image = Global.Inventory.My.Resources.Resources.toolbar_cancel_icon
        Me.mn_cancelorder.Name = "mn_cancelorder"
        Me.mn_cancelorder.Size = New System.Drawing.Size(104, 20)
        Me.mn_cancelorder.Text = "Cancel Order"
        Me.mn_cancelorder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'split_content
        '
        Me.split_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.split_content.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.split_content.IsSplitterFixed = True
        Me.split_content.Location = New System.Drawing.Point(0, 42)
        Me.split_content.Name = "split_content"
        Me.split_content.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'split_content.Panel1
        '
        Me.split_content.Panel1.Controls.Add(Me.MenuStrip1)
        '
        'split_content.Panel2
        '
        Me.split_content.Panel2.Controls.Add(Me.TabControl1)
        Me.split_content.Size = New System.Drawing.Size(1038, 610)
        Me.split_content.SplitterDistance = 25
        Me.split_content.SplitterWidth = 1
        Me.split_content.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tb_beli)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1038, 584)
        Me.TabControl1.TabIndex = 0
        '
        'tb_beli
        '
        Me.tb_beli.Controls.Add(Me.in_ket)
        Me.tb_beli.Controls.Add(Me.Label26)
        Me.tb_beli.Controls.Add(Me.in_klaim)
        Me.tb_beli.Controls.Add(Me.Label19)
        Me.tb_beli.Controls.Add(Me.in_total_netto)
        Me.tb_beli.Controls.Add(Me.Label18)
        Me.tb_beli.Controls.Add(Me.GroupBox3)
        Me.tb_beli.Controls.Add(Me.bt_gudang_list)
        Me.tb_beli.Controls.Add(Me.bt_supplier_list)
        Me.tb_beli.Controls.Add(Me.cb_gudang)
        Me.tb_beli.Controls.Add(Me.cb_ppn)
        Me.tb_beli.Controls.Add(Me.cb_supplier)
        Me.tb_beli.Controls.Add(Me.gb_fakturkode)
        Me.tb_beli.Controls.Add(Me.bt_batalbeli)
        Me.tb_beli.Controls.Add(Me.Button1)
        Me.tb_beli.Controls.Add(Me.bt_simpanbeli)
        Me.tb_beli.Controls.Add(Me.in_term)
        Me.tb_beli.Controls.Add(Me.date_tgl_pajak)
        Me.tb_beli.Controls.Add(Me.in_suratjalan)
        Me.tb_beli.Controls.Add(Me.Label8)
        Me.tb_beli.Controls.Add(Me.Label14)
        Me.tb_beli.Controls.Add(Me.Label9)
        Me.tb_beli.Controls.Add(Me.Label7)
        Me.tb_beli.Controls.Add(Me.Label6)
        Me.tb_beli.Controls.Add(Me.in_pajak)
        Me.tb_beli.Controls.Add(Me.Label3)
        Me.tb_beli.Controls.Add(Me.Label2)
        Me.tb_beli.Controls.Add(Me.Panel2)
        Me.tb_beli.Location = New System.Drawing.Point(4, 22)
        Me.tb_beli.Name = "tb_beli"
        Me.tb_beli.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_beli.Size = New System.Drawing.Size(1030, 558)
        Me.tb_beli.TabIndex = 0
        Me.tb_beli.Text = "Pembelian"
        Me.tb_beli.UseVisualStyleBackColor = True
        '
        'in_ket
        '
        Me.in_ket.BackColor = System.Drawing.Color.White
        Me.in_ket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.ForeColor = System.Drawing.Color.Black
        Me.in_ket.Location = New System.Drawing.Point(545, 411)
        Me.in_ket.MaxLength = 200
        Me.in_ket.Multiline = True
        Me.in_ket.Name = "in_ket"
        Me.in_ket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_ket.Size = New System.Drawing.Size(188, 85)
        Me.in_ket.TabIndex = 33
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(462, 415)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(82, 13)
        Me.Label26.TabIndex = 273
        Me.Label26.Text = "Catatan Invoice"
        '
        'in_klaim
        '
        Me.in_klaim.DecimalPlaces = 2
        Me.in_klaim.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_klaim.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.in_klaim.Location = New System.Drawing.Point(283, 433)
        Me.in_klaim.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.in_klaim.Name = "in_klaim"
        Me.in_klaim.Size = New System.Drawing.Size(157, 20)
        Me.in_klaim.TabIndex = 31
        Me.in_klaim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_klaim.ThousandsSeparator = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(280, 416)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(32, 13)
        Me.Label19.TabIndex = 269
        Me.Label19.Text = "Klaim"
        '
        'in_total_netto
        '
        Me.in_total_netto.BackColor = System.Drawing.Color.White
        Me.in_total_netto.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_total_netto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_total_netto.ForeColor = System.Drawing.Color.Black
        Me.in_total_netto.Location = New System.Drawing.Point(283, 476)
        Me.in_total_netto.MaxLength = 20
        Me.in_total_netto.Name = "in_total_netto"
        Me.in_total_netto.ReadOnly = True
        Me.in_total_netto.Size = New System.Drawing.Size(157, 20)
        Me.in_total_netto.TabIndex = 32
        Me.in_total_netto.TabStop = False
        Me.in_total_netto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(280, 458)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 13)
        Me.Label18.TabIndex = 270
        Me.Label18.Text = "Netto - Klaim"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.in_discount)
        Me.GroupBox3.Controls.Add(Me.in_total)
        Me.GroupBox3.Controls.Add(Me.in_netto)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.in_ppn_tot)
        Me.GroupBox3.Controls.Add(Me.in_jumlah)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 399)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(256, 148)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 94)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(27, 13)
        Me.Label15.TabIndex = 192
        Me.Label15.Text = "PPn"
        '
        'in_discount
        '
        Me.in_discount.DecimalPlaces = 2
        Me.in_discount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_discount.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.in_discount.Location = New System.Drawing.Point(85, 39)
        Me.in_discount.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.in_discount.Name = "in_discount"
        Me.in_discount.Size = New System.Drawing.Size(157, 20)
        Me.in_discount.TabIndex = 27
        Me.in_discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_discount.ThousandsSeparator = True
        '
        'in_total
        '
        Me.in_total.BackColor = System.Drawing.Color.White
        Me.in_total.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_total.ForeColor = System.Drawing.Color.Black
        Me.in_total.Location = New System.Drawing.Point(85, 65)
        Me.in_total.MaxLength = 20
        Me.in_total.Name = "in_total"
        Me.in_total.ReadOnly = True
        Me.in_total.Size = New System.Drawing.Size(157, 20)
        Me.in_total.TabIndex = 28
        Me.in_total.TabStop = False
        Me.in_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_netto
        '
        Me.in_netto.BackColor = System.Drawing.Color.White
        Me.in_netto.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_netto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_netto.ForeColor = System.Drawing.Color.Black
        Me.in_netto.Location = New System.Drawing.Point(85, 117)
        Me.in_netto.MaxLength = 20
        Me.in_netto.Name = "in_netto"
        Me.in_netto.ReadOnly = True
        Me.in_netto.Size = New System.Drawing.Size(157, 20)
        Me.in_netto.TabIndex = 30
        Me.in_netto.TabStop = False
        Me.in_netto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 120)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 13)
        Me.Label17.TabIndex = 192
        Me.Label17.Text = "NETTO"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 13)
        Me.Label13.TabIndex = 192
        Me.Label13.Text = "Total"
        '
        'in_ppn_tot
        '
        Me.in_ppn_tot.BackColor = System.Drawing.Color.White
        Me.in_ppn_tot.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_ppn_tot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ppn_tot.ForeColor = System.Drawing.Color.Black
        Me.in_ppn_tot.Location = New System.Drawing.Point(85, 91)
        Me.in_ppn_tot.MaxLength = 20
        Me.in_ppn_tot.Name = "in_ppn_tot"
        Me.in_ppn_tot.ReadOnly = True
        Me.in_ppn_tot.Size = New System.Drawing.Size(157, 20)
        Me.in_ppn_tot.TabIndex = 29
        Me.in_ppn_tot.TabStop = False
        Me.in_ppn_tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_jumlah
        '
        Me.in_jumlah.BackColor = System.Drawing.Color.White
        Me.in_jumlah.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_jumlah.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_jumlah.ForeColor = System.Drawing.Color.Black
        Me.in_jumlah.Location = New System.Drawing.Point(85, 13)
        Me.in_jumlah.MaxLength = 20
        Me.in_jumlah.Name = "in_jumlah"
        Me.in_jumlah.ReadOnly = True
        Me.in_jumlah.Size = New System.Drawing.Size(157, 20)
        Me.in_jumlah.TabIndex = 26
        Me.in_jumlah.TabStop = False
        Me.in_jumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 192
        Me.Label5.Text = "Sub-Total"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 41)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 192
        Me.Label12.Text = "Discount"
        '
        'bt_gudang_list
        '
        Me.bt_gudang_list.BackColor = System.Drawing.Color.Transparent
        Me.bt_gudang_list.BackgroundImage = CType(resources.GetObject("bt_gudang_list.BackgroundImage"), System.Drawing.Image)
        Me.bt_gudang_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_gudang_list.FlatAppearance.BorderSize = 0
        Me.bt_gudang_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_gudang_list.Location = New System.Drawing.Point(270, 34)
        Me.bt_gudang_list.Name = "bt_gudang_list"
        Me.bt_gudang_list.Size = New System.Drawing.Size(12, 15)
        Me.bt_gudang_list.TabIndex = 3
        Me.bt_gudang_list.UseVisualStyleBackColor = False
        '
        'bt_supplier_list
        '
        Me.bt_supplier_list.BackColor = System.Drawing.Color.Transparent
        Me.bt_supplier_list.BackgroundImage = CType(resources.GetObject("bt_supplier_list.BackgroundImage"), System.Drawing.Image)
        Me.bt_supplier_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_supplier_list.FlatAppearance.BorderSize = 0
        Me.bt_supplier_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_supplier_list.Location = New System.Drawing.Point(270, 9)
        Me.bt_supplier_list.Name = "bt_supplier_list"
        Me.bt_supplier_list.Size = New System.Drawing.Size(12, 15)
        Me.bt_supplier_list.TabIndex = 1
        Me.bt_supplier_list.UseVisualStyleBackColor = False
        '
        'cb_gudang
        '
        Me.cb_gudang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cb_gudang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_gudang.FormattingEnabled = True
        Me.cb_gudang.Items.AddRange(New Object() {"ii", "ooo", "eeee"})
        Me.cb_gudang.Location = New System.Drawing.Point(76, 31)
        Me.cb_gudang.Name = "cb_gudang"
        Me.cb_gudang.Size = New System.Drawing.Size(188, 21)
        Me.cb_gudang.TabIndex = 2
        '
        'cb_ppn
        '
        Me.cb_ppn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cb_ppn.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_ppn.FormattingEnabled = True
        Me.cb_ppn.Items.AddRange(New Object() {"ii", "ooo", "eeee"})
        Me.cb_ppn.Location = New System.Drawing.Point(382, 6)
        Me.cb_ppn.Name = "cb_ppn"
        Me.cb_ppn.Size = New System.Drawing.Size(188, 21)
        Me.cb_ppn.TabIndex = 6
        '
        'cb_supplier
        '
        Me.cb_supplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cb_supplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_supplier.FormattingEnabled = True
        Me.cb_supplier.Items.AddRange(New Object() {"ii", "ooo", "eeee"})
        Me.cb_supplier.Location = New System.Drawing.Point(76, 6)
        Me.cb_supplier.Name = "cb_supplier"
        Me.cb_supplier.Size = New System.Drawing.Size(188, 21)
        Me.cb_supplier.TabIndex = 0
        '
        'gb_fakturkode
        '
        Me.gb_fakturkode.Controls.Add(Me.in_status_kode)
        Me.gb_fakturkode.Controls.Add(Me.Label10)
        Me.gb_fakturkode.Controls.Add(Me.Label4)
        Me.gb_fakturkode.Controls.Add(Me.Label1)
        Me.gb_fakturkode.Controls.Add(Me.in_faktur)
        Me.gb_fakturkode.Controls.Add(Me.date_tgl_beli)
        Me.gb_fakturkode.Location = New System.Drawing.Point(773, 6)
        Me.gb_fakturkode.Name = "gb_fakturkode"
        Me.gb_fakturkode.Size = New System.Drawing.Size(251, 97)
        Me.gb_fakturkode.TabIndex = 249
        Me.gb_fakturkode.TabStop = False
        '
        'in_status_kode
        '
        Me.in_status_kode.BackColor = System.Drawing.Color.White
        Me.in_status_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status_kode.ForeColor = System.Drawing.Color.Black
        Me.in_status_kode.Location = New System.Drawing.Point(68, 63)
        Me.in_status_kode.Name = "in_status_kode"
        Me.in_status_kode.ReadOnly = True
        Me.in_status_kode.Size = New System.Drawing.Size(169, 20)
        Me.in_status_kode.TabIndex = 11
        Me.in_status_kode.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 242
        Me.Label10.Text = "Status"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 254
        Me.Label4.Text = "Faktur"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 262
        Me.Label1.Text = "Tgl"
        '
        'in_faktur
        '
        Me.in_faktur.BackColor = System.Drawing.Color.White
        Me.in_faktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_faktur.ForeColor = System.Drawing.Color.Black
        Me.in_faktur.Location = New System.Drawing.Point(68, 13)
        Me.in_faktur.MaxLength = 10
        Me.in_faktur.Name = "in_faktur"
        Me.in_faktur.ReadOnly = True
        Me.in_faktur.Size = New System.Drawing.Size(169, 20)
        Me.in_faktur.TabIndex = 9
        '
        'date_tgl_beli
        '
        Me.date_tgl_beli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_beli.Location = New System.Drawing.Point(68, 39)
        Me.date_tgl_beli.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_beli.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_beli.Name = "date_tgl_beli"
        Me.date_tgl_beli.Size = New System.Drawing.Size(169, 20)
        Me.date_tgl_beli.TabIndex = 10
        '
        'bt_batalbeli
        '
        Me.bt_batalbeli.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalbeli.Location = New System.Drawing.Point(914, 520)
        Me.bt_batalbeli.Name = "bt_batalbeli"
        Me.bt_batalbeli.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalbeli.TabIndex = 36
        Me.bt_batalbeli.Text = "Batal"
        Me.bt_batalbeli.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(711, 520)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 30)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "Simpan"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'bt_simpanbeli
        '
        Me.bt_simpanbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbeli.Location = New System.Drawing.Point(812, 520)
        Me.bt_simpanbeli.Name = "bt_simpanbeli"
        Me.bt_simpanbeli.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpanbeli.TabIndex = 35
        Me.bt_simpanbeli.Text = "Simpan"
        Me.bt_simpanbeli.UseVisualStyleBackColor = True
        '
        'in_term
        '
        Me.in_term.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_term.Location = New System.Drawing.Point(76, 77)
        Me.in_term.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.in_term.Name = "in_term"
        Me.in_term.Size = New System.Drawing.Size(94, 20)
        Me.in_term.TabIndex = 5
        Me.in_term.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'date_tgl_pajak
        '
        Me.date_tgl_pajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_pajak.Location = New System.Drawing.Point(382, 56)
        Me.date_tgl_pajak.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_pajak.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_pajak.Name = "date_tgl_pajak"
        Me.date_tgl_pajak.Size = New System.Drawing.Size(188, 21)
        Me.date_tgl_pajak.TabIndex = 8
        '
        'in_suratjalan
        '
        Me.in_suratjalan.BackColor = System.Drawing.Color.White
        Me.in_suratjalan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_suratjalan.ForeColor = System.Drawing.Color.Black
        Me.in_suratjalan.Location = New System.Drawing.Point(76, 55)
        Me.in_suratjalan.MaxLength = 10
        Me.in_suratjalan.Name = "in_suratjalan"
        Me.in_suratjalan.Size = New System.Drawing.Size(188, 20)
        Me.in_suratjalan.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 256
        Me.Label8.Text = "Term"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(308, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(27, 13)
        Me.Label14.TabIndex = 258
        Me.Label14.Text = "PPn"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 257
        Me.Label9.Text = "Surat Jalan"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 258
        Me.Label7.Text = "Supplier"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 259
        Me.Label6.Text = "Gudang"
        '
        'in_pajak
        '
        Me.in_pajak.BackColor = System.Drawing.Color.White
        Me.in_pajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_pajak.ForeColor = System.Drawing.Color.Black
        Me.in_pajak.Location = New System.Drawing.Point(382, 31)
        Me.in_pajak.MaxLength = 20
        Me.in_pajak.Name = "in_pajak"
        Me.in_pajak.Size = New System.Drawing.Size(188, 21)
        Me.in_pajak.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(308, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 15)
        Me.Label3.TabIndex = 260
        Me.Label3.Text = "Tgl. Pajak"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(308, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 261
        Me.Label2.Text = "No.Pajak"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.bt_tbbarang)
        Me.Panel2.Controls.Add(Me.popPnl_barang)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Controls.Add(Me.in_harga_beli)
        Me.Panel2.Controls.Add(Me.in_disc1)
        Me.Panel2.Controls.Add(Me.in_discrp)
        Me.Panel2.Controls.Add(Me.in_subtotal)
        Me.Panel2.Controls.Add(Me.in_disc2)
        Me.Panel2.Controls.Add(Me.in_barang)
        Me.Panel2.Controls.Add(Me.in_disc3)
        Me.Panel2.Controls.Add(Me.in_satuan)
        Me.Panel2.Controls.Add(Me.Label32)
        Me.Panel2.Controls.Add(Me.in_barang_nm)
        Me.Panel2.Controls.Add(Me.in_qty)
        Me.Panel2.Controls.Add(Me.dgv_barang)
        Me.Panel2.Controls.Add(Me.Label31)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Location = New System.Drawing.Point(0, 103)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1024, 291)
        Me.Panel2.TabIndex = 12
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label23.Location = New System.Drawing.Point(694, 9)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(39, 13)
        Me.Label23.TabIndex = 256
        Me.Label23.Text = "Disc1"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label24.Location = New System.Drawing.Point(749, 9)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(39, 13)
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
        Me.bt_tbbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tbbarang.Location = New System.Drawing.Point(996, 26)
        Me.bt_tbbarang.Name = "bt_tbbarang"
        Me.bt_tbbarang.Size = New System.Drawing.Size(18, 18)
        Me.bt_tbbarang.TabIndex = 23
        Me.bt_tbbarang.UseVisualStyleBackColor = False
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.linkLbl_searchbarang)
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(34, 79)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(444, 135)
        Me.popPnl_barang.TabIndex = 263
        Me.popPnl_barang.Visible = False
        '
        'linkLbl_searchbarang
        '
        Me.linkLbl_searchbarang.AutoSize = True
        Me.linkLbl_searchbarang.LinkColor = System.Drawing.Color.DimGray
        Me.linkLbl_searchbarang.Location = New System.Drawing.Point(3, 114)
        Me.linkLbl_searchbarang.Name = "linkLbl_searchbarang"
        Me.linkLbl_searchbarang.Size = New System.Drawing.Size(116, 13)
        Me.linkLbl_searchbarang.TabIndex = 1
        Me.linkLbl_searchbarang.TabStop = True
        Me.linkLbl_searchbarang.Text = "Tampilkan Pencarian..."
        Me.linkLbl_searchbarang.VisitedLinkColor = System.Drawing.Color.DimGray
        '
        'dgv_listbarang
        '
        Me.dgv_listbarang.AllowUserToAddRows = False
        Me.dgv_listbarang.AllowUserToDeleteRows = False
        Me.dgv_listbarang.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv_listbarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listbarang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.brg_kode, Me.brg_nama, Me.brg_beli})
        Me.dgv_listbarang.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgv_listbarang.Location = New System.Drawing.Point(0, 0)
        Me.dgv_listbarang.MultiSelect = False
        Me.dgv_listbarang.Name = "dgv_listbarang"
        Me.dgv_listbarang.ReadOnly = True
        Me.dgv_listbarang.RowHeadersVisible = False
        Me.dgv_listbarang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listbarang.Size = New System.Drawing.Size(444, 111)
        Me.dgv_listbarang.TabIndex = 0
        '
        'brg_kode
        '
        Me.brg_kode.DataPropertyName = "barang_kode"
        Me.brg_kode.HeaderText = "Kode"
        Me.brg_kode.MinimumWidth = 125
        Me.brg_kode.Name = "brg_kode"
        Me.brg_kode.ReadOnly = True
        Me.brg_kode.Width = 125
        '
        'brg_nama
        '
        Me.brg_nama.DataPropertyName = "barang_nama"
        Me.brg_nama.HeaderText = "Nama"
        Me.brg_nama.MinimumWidth = 175
        Me.brg_nama.Name = "brg_nama"
        Me.brg_nama.ReadOnly = True
        Me.brg_nama.Width = 175
        '
        'brg_beli
        '
        Me.brg_beli.DataPropertyName = "barang_harga_beli"
        Me.brg_beli.HeaderText = "Harga Beli"
        Me.brg_beli.MinimumWidth = 135
        Me.brg_beli.Name = "brg_beli"
        Me.brg_beli.ReadOnly = True
        Me.brg_beli.Width = 135
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label25.Location = New System.Drawing.Point(808, 9)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(39, 13)
        Me.Label25.TabIndex = 256
        Me.Label25.Text = "Disc3"
        '
        'in_harga_beli
        '
        Me.in_harga_beli.DecimalPlaces = 2
        Me.in_harga_beli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_harga_beli.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.in_harga_beli.Location = New System.Drawing.Point(429, 25)
        Me.in_harga_beli.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.in_harga_beli.Name = "in_harga_beli"
        Me.in_harga_beli.Size = New System.Drawing.Size(126, 20)
        Me.in_harga_beli.TabIndex = 17
        Me.in_harga_beli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_harga_beli.ThousandsSeparator = True
        '
        'in_disc1
        '
        Me.in_disc1.DecimalPlaces = 2
        Me.in_disc1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_disc1.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.in_disc1.Location = New System.Drawing.Point(694, 25)
        Me.in_disc1.Name = "in_disc1"
        Me.in_disc1.Size = New System.Drawing.Size(56, 20)
        Me.in_disc1.TabIndex = 19
        Me.in_disc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_discrp
        '
        Me.in_discrp.DecimalPlaces = 2
        Me.in_discrp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_discrp.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.in_discrp.Location = New System.Drawing.Point(865, 25)
        Me.in_discrp.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.in_discrp.Name = "in_discrp"
        Me.in_discrp.Size = New System.Drawing.Size(126, 20)
        Me.in_discrp.TabIndex = 22
        Me.in_discrp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_discrp.ThousandsSeparator = True
        '
        'in_subtotal
        '
        Me.in_subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_subtotal.Location = New System.Drawing.Point(555, 25)
        Me.in_subtotal.Name = "in_subtotal"
        Me.in_subtotal.Size = New System.Drawing.Size(133, 20)
        Me.in_subtotal.TabIndex = 18
        Me.in_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_disc2
        '
        Me.in_disc2.DecimalPlaces = 2
        Me.in_disc2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_disc2.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.in_disc2.Location = New System.Drawing.Point(751, 25)
        Me.in_disc2.Name = "in_disc2"
        Me.in_disc2.Size = New System.Drawing.Size(56, 20)
        Me.in_disc2.TabIndex = 20
        Me.in_disc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_barang
        '
        Me.in_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang.Location = New System.Drawing.Point(9, 25)
        Me.in_barang.MaxLength = 20
        Me.in_barang.Name = "in_barang"
        Me.in_barang.Size = New System.Drawing.Size(100, 20)
        Me.in_barang.TabIndex = 13
        '
        'in_disc3
        '
        Me.in_disc3.DecimalPlaces = 2
        Me.in_disc3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_disc3.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.in_disc3.Location = New System.Drawing.Point(808, 25)
        Me.in_disc3.Name = "in_disc3"
        Me.in_disc3.Size = New System.Drawing.Size(56, 20)
        Me.in_disc3.TabIndex = 21
        Me.in_disc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_satuan
        '
        Me.in_satuan.BackColor = System.Drawing.Color.White
        Me.in_satuan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_satuan.ForeColor = System.Drawing.Color.Black
        Me.in_satuan.Location = New System.Drawing.Point(364, 25)
        Me.in_satuan.MaxLength = 6
        Me.in_satuan.Name = "in_satuan"
        Me.in_satuan.ReadOnly = True
        Me.in_satuan.Size = New System.Drawing.Size(60, 20)
        Me.in_satuan.TabIndex = 16
        Me.in_satuan.TabStop = False
        Me.in_satuan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label32.Location = New System.Drawing.Point(865, 9)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(70, 13)
        Me.Label32.TabIndex = 256
        Me.Label32.Text = "Diskon Rp."
        '
        'in_barang_nm
        '
        Me.in_barang_nm.BackColor = System.Drawing.Color.White
        Me.in_barang_nm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang_nm.ForeColor = System.Drawing.Color.Black
        Me.in_barang_nm.Location = New System.Drawing.Point(109, 25)
        Me.in_barang_nm.MaxLength = 150
        Me.in_barang_nm.Name = "in_barang_nm"
        Me.in_barang_nm.ReadOnly = True
        Me.in_barang_nm.Size = New System.Drawing.Size(188, 20)
        Me.in_barang_nm.TabIndex = 14
        Me.in_barang_nm.TabStop = False
        '
        'in_qty
        '
        Me.in_qty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty.Location = New System.Drawing.Point(301, 25)
        Me.in_qty.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.in_qty.Name = "in_qty"
        Me.in_qty.Size = New System.Drawing.Size(63, 20)
        Me.in_qty.TabIndex = 15
        Me.in_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgv_barang
        '
        Me.dgv_barang.AllowUserToAddRows = False
        Me.dgv_barang.AllowUserToDeleteRows = False
        Me.dgv_barang.BackgroundColor = System.Drawing.Color.White
        Me.dgv_barang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_barang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kode, Me.nama, Me.qty, Me.sat, Me.harga, Me.subtot, Me.ppnbrg, Me.disc1, Me.disc2, Me.disc3, Me.discrp, Me.jml})
        Me.dgv_barang.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgv_barang.Location = New System.Drawing.Point(0, 51)
        Me.dgv_barang.Name = "dgv_barang"
        Me.dgv_barang.ReadOnly = True
        Me.dgv_barang.RowHeadersVisible = False
        Me.dgv_barang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_barang.Size = New System.Drawing.Size(1024, 240)
        Me.dgv_barang.TabIndex = 24
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
        Me.qty.MinimumWidth = 80
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        Me.qty.Width = 80
        '
        'sat
        '
        Me.sat.DataPropertyName = "trans_satuan"
        Me.sat.HeaderText = "Satuan"
        Me.sat.MinimumWidth = 80
        Me.sat.Name = "sat"
        Me.sat.ReadOnly = True
        Me.sat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.sat.Width = 80
        '
        'harga
        '
        Me.harga.DataPropertyName = "trans_harga_beli"
        Me.harga.HeaderText = "Harga Beli"
        Me.harga.MinimumWidth = 135
        Me.harga.Name = "harga"
        Me.harga.ReadOnly = True
        Me.harga.Width = 135
        '
        'subtot
        '
        Me.subtot.DataPropertyName = "trans_subtot"
        Me.subtot.HeaderText = "Sub-Total"
        Me.subtot.MinimumWidth = 135
        Me.subtot.Name = "subtot"
        Me.subtot.ReadOnly = True
        Me.subtot.Width = 135
        '
        'ppnbrg
        '
        Me.ppnbrg.DataPropertyName = "trans_ppn"
        Me.ppnbrg.HeaderText = "PPn"
        Me.ppnbrg.Name = "ppnbrg"
        Me.ppnbrg.ReadOnly = True
        '
        'disc1
        '
        Me.disc1.DataPropertyName = "trans_disc1"
        Me.disc1.HeaderText = "Disc1"
        Me.disc1.MinimumWidth = 60
        Me.disc1.Name = "disc1"
        Me.disc1.ReadOnly = True
        Me.disc1.Width = 60
        '
        'disc2
        '
        Me.disc2.DataPropertyName = "trans_disc2"
        Me.disc2.HeaderText = "Disc2"
        Me.disc2.MinimumWidth = 60
        Me.disc2.Name = "disc2"
        Me.disc2.ReadOnly = True
        Me.disc2.Width = 60
        '
        'disc3
        '
        Me.disc3.DataPropertyName = "trans_disc3"
        Me.disc3.HeaderText = "Disc3"
        Me.disc3.MinimumWidth = 60
        Me.disc3.Name = "disc3"
        Me.disc3.ReadOnly = True
        Me.disc3.Width = 60
        '
        'discrp
        '
        Me.discrp.DataPropertyName = "trans_disc_rupiah"
        Me.discrp.HeaderText = "Disc Rp."
        Me.discrp.MinimumWidth = 90
        Me.discrp.Name = "discrp"
        Me.discrp.ReadOnly = True
        Me.discrp.Width = 90
        '
        'jml
        '
        Me.jml.DataPropertyName = "trans_jumlah"
        Me.jml.HeaderText = "Jumlah"
        Me.jml.Name = "jml"
        Me.jml.ReadOnly = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label31.Location = New System.Drawing.Point(552, 9)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(58, 13)
        Me.Label31.TabIndex = 256
        Me.Label31.Text = "SubTotal"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label22.Location = New System.Drawing.Point(426, 9)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(66, 13)
        Me.Label22.TabIndex = 256
        Me.Label22.Text = "Harga Beli"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label21.Location = New System.Drawing.Point(298, 9)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(26, 13)
        Me.Label21.TabIndex = 256
        Me.Label21.Text = "Qty"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label20.Location = New System.Drawing.Point(104, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 13)
        Me.Label20.TabIndex = 256
        Me.Label20.Text = "Nama"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(6, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 256
        Me.Label16.Text = "Kode"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1030, 558)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Recieved"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.Button4)
        Me.Panel3.Controls.Add(Me.TextBox2)
        Me.Panel3.Controls.Add(Me.TextBox3)
        Me.Panel3.Controls.Add(Me.TextBox4)
        Me.Panel3.Controls.Add(Me.NumericUpDown6)
        Me.Panel3.Controls.Add(Me.DataGridView2)
        Me.Panel3.Controls.Add(Me.Label38)
        Me.Panel3.Controls.Add(Me.Label39)
        Me.Panel3.Controls.Add(Me.Label40)
        Me.Panel3.Location = New System.Drawing.Point(3, 134)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1024, 291)
        Me.Panel3.TabIndex = 265
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImage = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(821, 22)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(23, 23)
        Me.Button4.TabIndex = 260
        Me.Button4.UseVisualStyleBackColor = False
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(9, 25)
        Me.TextBox2.MaxLength = 20
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 253
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.White
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.Black
        Me.TextBox3.Location = New System.Drawing.Point(364, 25)
        Me.TextBox3.MaxLength = 6
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(60, 20)
        Me.TextBox3.TabIndex = 262
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.White
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.Black
        Me.TextBox4.Location = New System.Drawing.Point(109, 25)
        Me.TextBox4.MaxLength = 150
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(188, 20)
        Me.TextBox4.TabIndex = 262
        '
        'NumericUpDown6
        '
        Me.NumericUpDown6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown6.Location = New System.Drawing.Point(301, 25)
        Me.NumericUpDown6.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.NumericUpDown6.Name = "NumericUpDown6"
        Me.NumericUpDown6.Size = New System.Drawing.Size(63, 20)
        Me.NumericUpDown6.TabIndex = 254
        Me.NumericUpDown6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rec_kode, Me.rec_brg, Me.rec_qty, Me.rec_sat, Me.rec_tgl})
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridView2.Location = New System.Drawing.Point(0, 51)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(1024, 240)
        Me.DataGridView2.TabIndex = 248
        '
        'rec_kode
        '
        Me.rec_kode.DataPropertyName = "trans_barang"
        Me.rec_kode.HeaderText = "Kode"
        Me.rec_kode.Name = "rec_kode"
        Me.rec_kode.ReadOnly = True
        '
        'rec_brg
        '
        Me.rec_brg.DataPropertyName = "barang_nama"
        Me.rec_brg.HeaderText = "Nama Barang"
        Me.rec_brg.MinimumWidth = 190
        Me.rec_brg.Name = "rec_brg"
        Me.rec_brg.ReadOnly = True
        Me.rec_brg.Width = 190
        '
        'rec_qty
        '
        Me.rec_qty.DataPropertyName = "trans_qty"
        Me.rec_qty.HeaderText = "QTY"
        Me.rec_qty.MinimumWidth = 80
        Me.rec_qty.Name = "rec_qty"
        Me.rec_qty.ReadOnly = True
        Me.rec_qty.Width = 80
        '
        'rec_sat
        '
        Me.rec_sat.DataPropertyName = "trans_satuan"
        Me.rec_sat.HeaderText = "Satuan"
        Me.rec_sat.MinimumWidth = 80
        Me.rec_sat.Name = "rec_sat"
        Me.rec_sat.ReadOnly = True
        Me.rec_sat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.rec_sat.Width = 80
        '
        'rec_tgl
        '
        Me.rec_tgl.HeaderText = "Tanggal"
        Me.rec_tgl.Name = "rec_tgl"
        Me.rec_tgl.ReadOnly = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label38.Location = New System.Drawing.Point(298, 9)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(26, 13)
        Me.Label38.TabIndex = 256
        Me.Label38.Text = "Qty"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label39.Location = New System.Drawing.Point(104, 9)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(39, 13)
        Me.Label39.TabIndex = 256
        Me.Label39.Text = "Nama"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label40.Location = New System.Drawing.Point(6, 9)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(36, 13)
        Me.Label40.TabIndex = 256
        Me.Label40.Text = "Kode"
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(926, 520)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 30)
        Me.Button2.TabIndex = 253
        Me.Button2.Text = "Batal"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(824, 520)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 30)
        Me.Button3.TabIndex = 252
        Me.Button3.Text = "Simpan"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Controls.Add(Me.LinkLabel1)
        Me.TabPage3.Controls.Add(Me.DataGridView1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1030, 558)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Retur"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.TextBox5)
        Me.GroupBox1.Location = New System.Drawing.Point(759, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 45)
        Me.GroupBox1.TabIndex = 251
        Me.GroupBox1.TabStop = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(12, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(37, 13)
        Me.Label33.TabIndex = 254
        Me.Label33.Text = "Faktur"
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.White
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.ForeColor = System.Drawing.Color.Black
        Me.TextBox5.Location = New System.Drawing.Point(68, 13)
        Me.TextBox5.MaxLength = 10
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(169, 20)
        Me.TextBox5.TabIndex = 252
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.DimGray
        Me.LinkLabel1.Location = New System.Drawing.Point(37, 314)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(116, 13)
        Me.LinkLabel1.TabIndex = 250
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Tampilkan Pencarian..."
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.DimGray
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn8, Me.retur_ket})
        Me.DataGridView1.Location = New System.Drawing.Point(3, 71)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1007, 240)
        Me.DataGridView1.TabIndex = 249
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "trans_faktur"
        Me.DataGridViewTextBoxColumn1.HeaderText = "No. Retur"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "barang_nama"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nama Barang"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 190
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 190
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "trans_qty"
        Me.DataGridViewTextBoxColumn3.HeaderText = "QTY"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "trans_satuan"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Satuan"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'retur_ket
        '
        Me.retur_ket.DataPropertyName = "faktur_sebab"
        Me.retur_ket.HeaderText = "Keterangan"
        Me.retur_ket.Name = "retur_ket"
        Me.retur_ket.ReadOnly = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1030, 558)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "Extra"
        Me.TabPage1.UseVisualStyleBackColor = True
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
        Me.GroupBox2.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(512, 72)
        Me.GroupBox2.TabIndex = 265
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
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(346, 44)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(150, 22)
        Me.txtUpdAlias.TabIndex = 122
        Me.txtUpdAlias.TabStop = False
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
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(254, 47)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(86, 16)
        Me.Label28.TabIndex = 125
        Me.Label28.Text = "Update Alias"
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
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(255, 19)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(85, 16)
        Me.Label30.TabIndex = 124
        Me.Label30.Text = "Update Date"
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(346, 16)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(150, 22)
        Me.txtUpdDate.TabIndex = 115
        Me.txtUpdDate.TabStop = False
        '
        'fr_beli_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.bt_batalbeli
        Me.ClientSize = New System.Drawing.Size(1038, 652)
        Me.Controls.Add(Me.split_content)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "fr_beli_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pembelian : "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.split_content.Panel1.ResumeLayout(False)
        Me.split_content.Panel1.PerformLayout()
        Me.split_content.Panel2.ResumeLayout(False)
        CType(Me.split_content, System.ComponentModel.ISupportInitialize).EndInit()
        Me.split_content.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tb_beli.ResumeLayout(False)
        Me.tb_beli.PerformLayout()
        CType(Me.in_klaim, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.in_discount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_fakturkode.ResumeLayout(False)
        Me.gb_fakturkode.PerformLayout()
        CType(Me.in_term, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
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
        Me.TabPage2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_cancelorder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents split_content As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tb_beli As System.Windows.Forms.TabPage
    Friend WithEvents cb_supplier As System.Windows.Forms.ComboBox
    Friend WithEvents gb_fakturkode As System.Windows.Forms.GroupBox
    Friend WithEvents in_status_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
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
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents in_pajak As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents cb_gudang As System.Windows.Forms.ComboBox
    Friend WithEvents bt_gudang_list As System.Windows.Forms.Button
    Friend WithEvents bt_supplier_list As System.Windows.Forms.Button
    Friend WithEvents cb_ppn As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents bt_tbbarang As System.Windows.Forms.Button
    Friend WithEvents in_barang As System.Windows.Forms.TextBox
    Friend WithEvents in_satuan As System.Windows.Forms.TextBox
    Friend WithEvents in_barang_nm As System.Windows.Forms.TextBox
    Friend WithEvents in_disc3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_disc2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_disc1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_qty As System.Windows.Forms.NumericUpDown
    Friend WithEvents dgv_barang As System.Windows.Forms.DataGridView
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents in_klaim As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents in_total_netto As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents in_discount As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_total As System.Windows.Forms.TextBox
    Friend WithEvents in_netto As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents in_ppn_tot As System.Windows.Forms.TextBox
    Friend WithEvents in_jumlah As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents in_discrp As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents in_harga_beli As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents harga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents subtot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ppnbrg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disc1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disc2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disc3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents discrp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jml As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents linkLbl_searchbarang As System.Windows.Forms.LinkLabel
    Friend WithEvents brg_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brg_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brg_beli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents NumericUpDown6 As System.Windows.Forms.NumericUpDown
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents rec_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rec_brg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rec_qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rec_sat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rec_tgl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents retur_ket As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
End Class
