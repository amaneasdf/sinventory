<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_pesan_detail
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
        Me.bt_bataljual = New System.Windows.Forms.Button()
        Me.bt_simpanjual = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.linkLbl_searchbarang = New System.Windows.Forms.LinkLabel()
        Me.dgv_barang = New System.Windows.Forms.DataGridView()
        Me.valid_ck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_sisa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.harga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.discrp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.disc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.disc2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.disc3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.disc4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.disc5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jml = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cb_status = New System.Windows.Forms.ComboBox()
        Me.bt_createjual = New System.Windows.Forms.Button()
        Me.txtValDate = New System.Windows.Forms.TextBox()
        Me.txtValAlias = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cb_term = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.in_total = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.in_diskon = New System.Windows.Forms.TextBox()
        Me.bt_tbbarang = New System.Windows.Forms.Button()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.in_jumlah = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.in_qty = New System.Windows.Forms.NumericUpDown()
        Me.in_barang_nm = New System.Windows.Forms.TextBox()
        Me.in_custo_n = New System.Windows.Forms.TextBox()
        Me.in_disc3 = New System.Windows.Forms.NumericUpDown()
        Me.in_custo = New System.Windows.Forms.TextBox()
        Me.in_barang = New System.Windows.Forms.TextBox()
        Me.in_gudang_n = New System.Windows.Forms.TextBox()
        Me.in_disc2 = New System.Windows.Forms.NumericUpDown()
        Me.in_gudang = New System.Windows.Forms.TextBox()
        Me.in_disc5 = New System.Windows.Forms.NumericUpDown()
        Me.in_sales_n = New System.Windows.Forms.TextBox()
        Me.in_subtotal = New System.Windows.Forms.TextBox()
        Me.in_sales = New System.Windows.Forms.TextBox()
        Me.in_disc1 = New System.Windows.Forms.NumericUpDown()
        Me.in_discrp = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_harga_beli = New System.Windows.Forms.NumericUpDown()
        Me.in_status = New System.Windows.Forms.TextBox()
        Me.in_disc4 = New System.Windows.Forms.NumericUpDown()
        Me.in_faktur = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.date_tgl_beli = New System.Windows.Forms.DateTimePicker()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cb_sat = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_createjual = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbl_ref_faktur = New System.Windows.Forms.Label()
        Me.in_ref_faktur = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.pnl_content.SuspendLayout()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_disc3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_disc2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_disc5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_disc1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_discrp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_harga_beli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_disc4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bt_bataljual
        '
        Me.bt_bataljual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_bataljual.Location = New System.Drawing.Point(888, 440)
        Me.bt_bataljual.Name = "bt_bataljual"
        Me.bt_bataljual.Size = New System.Drawing.Size(100, 30)
        Me.bt_bataljual.TabIndex = 35
        Me.bt_bataljual.Text = "Batal"
        Me.bt_bataljual.UseVisualStyleBackColor = True
        '
        'bt_simpanjual
        '
        Me.bt_simpanjual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanjual.Location = New System.Drawing.Point(725, 440)
        Me.bt_simpanjual.Name = "bt_simpanjual"
        Me.bt_simpanjual.Size = New System.Drawing.Size(162, 30)
        Me.bt_simpanjual.TabIndex = 34
        Me.bt_simpanjual.Text = "Simpan"
        Me.bt_simpanjual.UseVisualStyleBackColor = True
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
        Me.Panel1.Size = New System.Drawing.Size(1005, 42)
        Me.Panel1.TabIndex = 252
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(925, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(978, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 137
        Me.bt_cl.TabStop = False
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Orange
        Me.lbl_title.Font = New System.Drawing.Font("Source Sans Pro", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(6, 4)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(250, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Form Order Penjualan"
        '
        'pnl_content
        '
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.Controls.Add(Me.lbl_ref_faktur)
        Me.pnl_content.Controls.Add(Me.in_ref_faktur)
        Me.pnl_content.Controls.Add(Me.popPnl_barang)
        Me.pnl_content.Controls.Add(Me.dgv_barang)
        Me.pnl_content.Controls.Add(Me.cb_status)
        Me.pnl_content.Controls.Add(Me.bt_createjual)
        Me.pnl_content.Controls.Add(Me.txtValDate)
        Me.pnl_content.Controls.Add(Me.txtValAlias)
        Me.pnl_content.Controls.Add(Me.Label5)
        Me.pnl_content.Controls.Add(Me.cb_term)
        Me.pnl_content.Controls.Add(Me.Label3)
        Me.pnl_content.Controls.Add(Me.Label2)
        Me.pnl_content.Controls.Add(Me.Label4)
        Me.pnl_content.Controls.Add(Me.bt_simpanjual)
        Me.pnl_content.Controls.Add(Me.bt_bataljual)
        Me.pnl_content.Controls.Add(Me.Label6)
        Me.pnl_content.Controls.Add(Me.Label7)
        Me.pnl_content.Controls.Add(Me.txtRegAlias)
        Me.pnl_content.Controls.Add(Me.in_total)
        Me.pnl_content.Controls.Add(Me.Label27)
        Me.pnl_content.Controls.Add(Me.Label8)
        Me.pnl_content.Controls.Add(Me.txtUpdDate)
        Me.pnl_content.Controls.Add(Me.Label13)
        Me.pnl_content.Controls.Add(Me.txtUpdAlias)
        Me.pnl_content.Controls.Add(Me.in_ket)
        Me.pnl_content.Controls.Add(Me.in_diskon)
        Me.pnl_content.Controls.Add(Me.bt_tbbarang)
        Me.pnl_content.Controls.Add(Me.txtRegdate)
        Me.pnl_content.Controls.Add(Me.Label16)
        Me.pnl_content.Controls.Add(Me.in_jumlah)
        Me.pnl_content.Controls.Add(Me.Label20)
        Me.pnl_content.Controls.Add(Me.Label21)
        Me.pnl_content.Controls.Add(Me.Label18)
        Me.pnl_content.Controls.Add(Me.Label22)
        Me.pnl_content.Controls.Add(Me.Label28)
        Me.pnl_content.Controls.Add(Me.Label31)
        Me.pnl_content.Controls.Add(Me.Label19)
        Me.pnl_content.Controls.Add(Me.in_qty)
        Me.pnl_content.Controls.Add(Me.in_barang_nm)
        Me.pnl_content.Controls.Add(Me.in_custo_n)
        Me.pnl_content.Controls.Add(Me.in_disc3)
        Me.pnl_content.Controls.Add(Me.in_custo)
        Me.pnl_content.Controls.Add(Me.in_barang)
        Me.pnl_content.Controls.Add(Me.in_gudang_n)
        Me.pnl_content.Controls.Add(Me.in_disc2)
        Me.pnl_content.Controls.Add(Me.in_gudang)
        Me.pnl_content.Controls.Add(Me.in_disc5)
        Me.pnl_content.Controls.Add(Me.in_sales_n)
        Me.pnl_content.Controls.Add(Me.in_subtotal)
        Me.pnl_content.Controls.Add(Me.in_sales)
        Me.pnl_content.Controls.Add(Me.in_disc1)
        Me.pnl_content.Controls.Add(Me.in_discrp)
        Me.pnl_content.Controls.Add(Me.Label1)
        Me.pnl_content.Controls.Add(Me.in_harga_beli)
        Me.pnl_content.Controls.Add(Me.in_status)
        Me.pnl_content.Controls.Add(Me.in_disc4)
        Me.pnl_content.Controls.Add(Me.in_faktur)
        Me.pnl_content.Controls.Add(Me.Label25)
        Me.pnl_content.Controls.Add(Me.Label34)
        Me.pnl_content.Controls.Add(Me.Label24)
        Me.pnl_content.Controls.Add(Me.date_tgl_beli)
        Me.pnl_content.Controls.Add(Me.Label23)
        Me.pnl_content.Controls.Add(Me.Label10)
        Me.pnl_content.Controls.Add(Me.Label12)
        Me.pnl_content.Controls.Add(Me.cb_sat)
        Me.pnl_content.Controls.Add(Me.Label9)
        Me.pnl_content.Controls.Add(Me.Label11)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Location = New System.Drawing.Point(0, 66)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(1005, 477)
        Me.pnl_content.TabIndex = 0
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Controls.Add(Me.linkLbl_searchbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(474, 176)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(375, 119)
        Me.popPnl_barang.TabIndex = 0
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
        Me.dgv_listbarang.Size = New System.Drawing.Size(375, 111)
        Me.dgv_listbarang.TabIndex = 0
        '
        'linkLbl_searchbarang
        '
        Me.linkLbl_searchbarang.AutoSize = True
        Me.linkLbl_searchbarang.LinkColor = System.Drawing.Color.DimGray
        Me.linkLbl_searchbarang.Location = New System.Drawing.Point(3, 98)
        Me.linkLbl_searchbarang.Name = "linkLbl_searchbarang"
        Me.linkLbl_searchbarang.Size = New System.Drawing.Size(116, 13)
        Me.linkLbl_searchbarang.TabIndex = 1
        Me.linkLbl_searchbarang.TabStop = True
        Me.linkLbl_searchbarang.Text = "Tampilkan Pencarian..."
        Me.linkLbl_searchbarang.VisitedLinkColor = System.Drawing.Color.DimGray
        '
        'dgv_barang
        '
        Me.dgv_barang.AllowUserToAddRows = False
        Me.dgv_barang.AllowUserToDeleteRows = False
        Me.dgv_barang.BackgroundColor = System.Drawing.Color.White
        Me.dgv_barang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_barang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.valid_ck, Me.kode, Me.sat_type, Me.nama, Me.qty, Me.sat, Me.qty_sisa, Me.harga, Me.subtotal, Me.discrp, Me.disc1, Me.disc2, Me.disc3, Me.disc4, Me.disc5, Me.jml})
        Me.dgv_barang.Location = New System.Drawing.Point(12, 146)
        Me.dgv_barang.MultiSelect = False
        Me.dgv_barang.Name = "dgv_barang"
        Me.dgv_barang.RowHeadersVisible = False
        Me.dgv_barang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_barang.Size = New System.Drawing.Size(980, 163)
        Me.dgv_barang.TabIndex = 21
        '
        'valid_ck
        '
        Me.valid_ck.FalseValue = "0"
        Me.valid_ck.HeaderText = "Stat"
        Me.valid_ck.IndeterminateValue = "0"
        Me.valid_ck.Name = "valid_ck"
        Me.valid_ck.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.valid_ck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.valid_ck.TrueValue = "1"
        Me.valid_ck.Width = 40
        '
        'kode
        '
        Me.kode.DataPropertyName = "trans_barang"
        Me.kode.HeaderText = "Kode"
        Me.kode.Name = "kode"
        Me.kode.ReadOnly = True
        '
        'sat_type
        '
        Me.sat_type.HeaderText = "sattype"
        Me.sat_type.Name = "sat_type"
        Me.sat_type.Visible = False
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
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        Me.qty.Width = 40
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
        'qty_sisa
        '
        Me.qty_sisa.HeaderText = "QtySisa"
        Me.qty_sisa.Name = "qty_sisa"
        Me.qty_sisa.ReadOnly = True
        Me.qty_sisa.Width = 75
        '
        'harga
        '
        Me.harga.DataPropertyName = "trans_harga_jual"
        Me.harga.HeaderText = "Harga Jual"
        Me.harga.Name = "harga"
        Me.harga.ReadOnly = True
        Me.harga.Width = 110
        '
        'subtotal
        '
        Me.subtotal.HeaderText = "Subtotal"
        Me.subtotal.Name = "subtotal"
        Me.subtotal.ReadOnly = True
        '
        'discrp
        '
        Me.discrp.DataPropertyName = "trans_disc_rupiah"
        Me.discrp.HeaderText = "Disc Rp."
        Me.discrp.Name = "discrp"
        Me.discrp.Width = 80
        '
        'disc1
        '
        Me.disc1.DataPropertyName = "trans_disc1"
        Me.disc1.HeaderText = "Disc1"
        Me.disc1.MinimumWidth = 40
        Me.disc1.Name = "disc1"
        Me.disc1.Width = 45
        '
        'disc2
        '
        Me.disc2.DataPropertyName = "trans_disc2"
        Me.disc2.HeaderText = "Disc2"
        Me.disc2.MinimumWidth = 40
        Me.disc2.Name = "disc2"
        Me.disc2.Width = 45
        '
        'disc3
        '
        Me.disc3.DataPropertyName = "trans_disc3"
        Me.disc3.HeaderText = "Disc3"
        Me.disc3.MinimumWidth = 40
        Me.disc3.Name = "disc3"
        Me.disc3.Width = 45
        '
        'disc4
        '
        Me.disc4.DataPropertyName = "trans_disc4"
        Me.disc4.HeaderText = "Disc4"
        Me.disc4.MinimumWidth = 40
        Me.disc4.Name = "disc4"
        Me.disc4.Width = 45
        '
        'disc5
        '
        Me.disc5.DataPropertyName = "trans_disc5"
        Me.disc5.HeaderText = "Disc5"
        Me.disc5.MinimumWidth = 40
        Me.disc5.Name = "disc5"
        Me.disc5.Width = 45
        '
        'jml
        '
        Me.jml.DataPropertyName = "trans_jumlah"
        Me.jml.HeaderText = "Jumlah"
        Me.jml.Name = "jml"
        Me.jml.ReadOnly = True
        '
        'cb_status
        '
        Me.cb_status.FormattingEnabled = True
        Me.cb_status.Location = New System.Drawing.Point(866, 33)
        Me.cb_status.Name = "cb_status"
        Me.cb_status.Size = New System.Drawing.Size(130, 21)
        Me.cb_status.TabIndex = 4
        Me.cb_status.Visible = False
        '
        'bt_createjual
        '
        Me.bt_createjual.Enabled = False
        Me.bt_createjual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_createjual.Location = New System.Drawing.Point(725, 440)
        Me.bt_createjual.Name = "bt_createjual"
        Me.bt_createjual.Size = New System.Drawing.Size(162, 30)
        Me.bt_createjual.TabIndex = 34
        Me.bt_createjual.Text = "Simpan Validasi"
        Me.bt_createjual.UseVisualStyleBackColor = True
        Me.bt_createjual.Visible = False
        '
        'txtValDate
        '
        Me.txtValDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValDate.Location = New System.Drawing.Point(203, 450)
        Me.txtValDate.Name = "txtValDate"
        Me.txtValDate.ReadOnly = True
        Me.txtValDate.Size = New System.Drawing.Size(289, 20)
        Me.txtValDate.TabIndex = 429
        Me.txtValDate.TabStop = False
        '
        'txtValAlias
        '
        Me.txtValAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValAlias.Location = New System.Drawing.Point(51, 450)
        Me.txtValAlias.Name = "txtValAlias"
        Me.txtValAlias.ReadOnly = True
        Me.txtValAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtValAlias.TabIndex = 430
        Me.txtValAlias.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(6, 454)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 431
        Me.Label5.Text = "ValBy"
        '
        'cb_term
        '
        Me.cb_term.FormattingEnabled = True
        Me.cb_term.Location = New System.Drawing.Point(65, 74)
        Me.cb_term.Name = "cb_term"
        Me.cb_term.Size = New System.Drawing.Size(121, 21)
        Me.cb_term.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(368, 315)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 428
        Me.Label3.Text = "Salesman"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(9, 312)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 427
        Me.Label2.Text = "Catatan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(842, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 13)
        Me.Label4.TabIndex = 254
        Me.Label4.Text = "ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 321
        Me.Label6.Text = "Gudang"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 319
        Me.Label7.Text = "Customer"
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(51, 406)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtRegAlias.TabIndex = 413
        Me.txtRegAlias.TabStop = False
        '
        'in_total
        '
        Me.in_total.BackColor = System.Drawing.Color.White
        Me.in_total.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_total.ForeColor = System.Drawing.Color.Black
        Me.in_total.Location = New System.Drawing.Point(797, 358)
        Me.in_total.MaxLength = 20
        Me.in_total.Name = "in_total"
        Me.in_total.ReadOnly = True
        Me.in_total.Size = New System.Drawing.Size(191, 21)
        Me.in_total.TabIndex = 27
        Me.in_total.TabStop = False
        Me.in_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(6, 410)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(39, 13)
        Me.Label27.TabIndex = 415
        Me.Label27.Text = "RegBy"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 317
        Me.Label8.Text = "Term"
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(203, 428)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(289, 20)
        Me.txtUpdDate.TabIndex = 411
        Me.txtUpdDate.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label13.Location = New System.Drawing.Point(722, 361)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 15)
        Me.Label13.TabIndex = 192
        Me.Label13.Text = "Total"
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(51, 428)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtUpdAlias.TabIndex = 416
        Me.txtUpdAlias.TabStop = False
        '
        'in_ket
        '
        Me.in_ket.BackColor = System.Drawing.Color.White
        Me.in_ket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.ForeColor = System.Drawing.Color.Black
        Me.in_ket.Location = New System.Drawing.Point(9, 328)
        Me.in_ket.MaxLength = 200
        Me.in_ket.Multiline = True
        Me.in_ket.Name = "in_ket"
        Me.in_ket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_ket.Size = New System.Drawing.Size(353, 72)
        Me.in_ket.TabIndex = 22
        '
        'in_diskon
        '
        Me.in_diskon.BackColor = System.Drawing.Color.White
        Me.in_diskon.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_diskon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_diskon.ForeColor = System.Drawing.Color.Black
        Me.in_diskon.Location = New System.Drawing.Point(797, 335)
        Me.in_diskon.MaxLength = 20
        Me.in_diskon.Name = "in_diskon"
        Me.in_diskon.ReadOnly = True
        Me.in_diskon.Size = New System.Drawing.Size(191, 21)
        Me.in_diskon.TabIndex = 26
        Me.in_diskon.TabStop = False
        Me.in_diskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bt_tbbarang
        '
        Me.bt_tbbarang.BackColor = System.Drawing.Color.Transparent
        Me.bt_tbbarang.BackgroundImage = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.bt_tbbarang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_tbbarang.FlatAppearance.BorderSize = 0
        Me.bt_tbbarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_tbbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tbbarang.Location = New System.Drawing.Point(982, 119)
        Me.bt_tbbarang.Name = "bt_tbbarang"
        Me.bt_tbbarang.Size = New System.Drawing.Size(18, 18)
        Me.bt_tbbarang.TabIndex = 20
        Me.bt_tbbarang.UseVisualStyleBackColor = False
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(203, 406)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(289, 20)
        Me.txtRegdate.TabIndex = 412
        Me.txtRegdate.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(9, 103)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 356
        Me.Label16.Text = "Kode"
        '
        'in_jumlah
        '
        Me.in_jumlah.BackColor = System.Drawing.Color.White
        Me.in_jumlah.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_jumlah.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_jumlah.ForeColor = System.Drawing.Color.Black
        Me.in_jumlah.Location = New System.Drawing.Point(797, 312)
        Me.in_jumlah.MaxLength = 20
        Me.in_jumlah.Name = "in_jumlah"
        Me.in_jumlah.ReadOnly = True
        Me.in_jumlah.Size = New System.Drawing.Size(191, 21)
        Me.in_jumlah.TabIndex = 25
        Me.in_jumlah.TabStop = False
        Me.in_jumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label20.Location = New System.Drawing.Point(107, 103)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 13)
        Me.Label20.TabIndex = 363
        Me.Label20.Text = "Nama"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label21.Location = New System.Drawing.Point(299, 103)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(26, 13)
        Me.Label21.TabIndex = 353
        Me.Label21.Text = "Qty"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label18.Location = New System.Drawing.Point(722, 315)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(69, 15)
        Me.Label18.TabIndex = 192
        Me.Label18.Text = "Sub-Total"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label22.Location = New System.Drawing.Point(418, 103)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 13)
        Me.Label22.TabIndex = 354
        Me.Label22.Text = "Harga Jual"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(6, 432)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(39, 13)
        Me.Label28.TabIndex = 418
        Me.Label28.Text = "UpdBy"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label31.Location = New System.Drawing.Point(863, 102)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(58, 13)
        Me.Label31.TabIndex = 355
        Me.Label31.Text = "SubTotal"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label19.Location = New System.Drawing.Point(722, 338)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 15)
        Me.Label19.TabIndex = 192
        Me.Label19.Text = "Discount"
        '
        'in_qty
        '
        Me.in_qty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty.Location = New System.Drawing.Point(302, 119)
        Me.in_qty.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.in_qty.Name = "in_qty"
        Me.in_qty.Size = New System.Drawing.Size(57, 20)
        Me.in_qty.TabIndex = 10
        Me.in_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_barang_nm
        '
        Me.in_barang_nm.BackColor = System.Drawing.Color.White
        Me.in_barang_nm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang_nm.ForeColor = System.Drawing.Color.Black
        Me.in_barang_nm.Location = New System.Drawing.Point(112, 119)
        Me.in_barang_nm.MaxLength = 200
        Me.in_barang_nm.Name = "in_barang_nm"
        Me.in_barang_nm.Size = New System.Drawing.Size(188, 20)
        Me.in_barang_nm.TabIndex = 9
        '
        'in_custo_n
        '
        Me.in_custo_n.BackColor = System.Drawing.Color.White
        Me.in_custo_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_custo_n.ForeColor = System.Drawing.Color.Black
        Me.in_custo_n.Location = New System.Drawing.Point(188, 29)
        Me.in_custo_n.MaxLength = 200
        Me.in_custo_n.Name = "in_custo_n"
        Me.in_custo_n.Size = New System.Drawing.Size(260, 20)
        Me.in_custo_n.TabIndex = 3
        '
        'in_disc3
        '
        Me.in_disc3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_disc3.Location = New System.Drawing.Point(711, 119)
        Me.in_disc3.Name = "in_disc3"
        Me.in_disc3.Size = New System.Drawing.Size(50, 20)
        Me.in_disc3.TabIndex = 16
        Me.in_disc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_custo
        '
        Me.in_custo.BackColor = System.Drawing.Color.White
        Me.in_custo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_custo.ForeColor = System.Drawing.Color.Black
        Me.in_custo.Location = New System.Drawing.Point(65, 29)
        Me.in_custo.MaxLength = 30
        Me.in_custo.Name = "in_custo"
        Me.in_custo.ReadOnly = True
        Me.in_custo.Size = New System.Drawing.Size(121, 20)
        Me.in_custo.TabIndex = 2
        '
        'in_barang
        '
        Me.in_barang.BackColor = System.Drawing.Color.White
        Me.in_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang.Location = New System.Drawing.Point(12, 119)
        Me.in_barang.MaxLength = 20
        Me.in_barang.Name = "in_barang"
        Me.in_barang.ReadOnly = True
        Me.in_barang.Size = New System.Drawing.Size(100, 20)
        Me.in_barang.TabIndex = 8
        Me.in_barang.TabStop = False
        '
        'in_gudang_n
        '
        Me.in_gudang_n.BackColor = System.Drawing.Color.White
        Me.in_gudang_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang_n.ForeColor = System.Drawing.Color.Black
        Me.in_gudang_n.Location = New System.Drawing.Point(188, 51)
        Me.in_gudang_n.MaxLength = 200
        Me.in_gudang_n.Name = "in_gudang_n"
        Me.in_gudang_n.Size = New System.Drawing.Size(260, 20)
        Me.in_gudang_n.TabIndex = 6
        '
        'in_disc2
        '
        Me.in_disc2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_disc2.Location = New System.Drawing.Point(660, 119)
        Me.in_disc2.Name = "in_disc2"
        Me.in_disc2.Size = New System.Drawing.Size(50, 20)
        Me.in_disc2.TabIndex = 15
        Me.in_disc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_gudang
        '
        Me.in_gudang.BackColor = System.Drawing.Color.White
        Me.in_gudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang.ForeColor = System.Drawing.Color.Black
        Me.in_gudang.Location = New System.Drawing.Point(65, 51)
        Me.in_gudang.MaxLength = 30
        Me.in_gudang.Name = "in_gudang"
        Me.in_gudang.ReadOnly = True
        Me.in_gudang.Size = New System.Drawing.Size(121, 20)
        Me.in_gudang.TabIndex = 5
        '
        'in_disc5
        '
        Me.in_disc5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_disc5.Location = New System.Drawing.Point(813, 119)
        Me.in_disc5.Name = "in_disc5"
        Me.in_disc5.Size = New System.Drawing.Size(50, 20)
        Me.in_disc5.TabIndex = 18
        Me.in_disc5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_sales_n
        '
        Me.in_sales_n.BackColor = System.Drawing.Color.White
        Me.in_sales_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales_n.ForeColor = System.Drawing.Color.Black
        Me.in_sales_n.Location = New System.Drawing.Point(371, 331)
        Me.in_sales_n.MaxLength = 200
        Me.in_sales_n.Name = "in_sales_n"
        Me.in_sales_n.Size = New System.Drawing.Size(293, 20)
        Me.in_sales_n.TabIndex = 23
        '
        'in_subtotal
        '
        Me.in_subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_subtotal.Location = New System.Drawing.Point(866, 118)
        Me.in_subtotal.Name = "in_subtotal"
        Me.in_subtotal.Size = New System.Drawing.Size(114, 20)
        Me.in_subtotal.TabIndex = 19
        Me.in_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_sales
        '
        Me.in_sales.BackColor = System.Drawing.Color.White
        Me.in_sales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales.ForeColor = System.Drawing.Color.Black
        Me.in_sales.Location = New System.Drawing.Point(371, 354)
        Me.in_sales.MaxLength = 30
        Me.in_sales.Name = "in_sales"
        Me.in_sales.ReadOnly = True
        Me.in_sales.Size = New System.Drawing.Size(121, 20)
        Me.in_sales.TabIndex = 24
        Me.in_sales.TabStop = False
        '
        'in_disc1
        '
        Me.in_disc1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_disc1.Location = New System.Drawing.Point(609, 119)
        Me.in_disc1.Name = "in_disc1"
        Me.in_disc1.Size = New System.Drawing.Size(50, 20)
        Me.in_disc1.TabIndex = 14
        Me.in_disc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_discrp
        '
        Me.in_discrp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_discrp.Location = New System.Drawing.Point(533, 119)
        Me.in_discrp.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.in_discrp.Name = "in_discrp"
        Me.in_discrp.Size = New System.Drawing.Size(75, 20)
        Me.in_discrp.TabIndex = 13
        Me.in_discrp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 262
        Me.Label1.Text = "Tgl Order"
        '
        'in_harga_beli
        '
        Me.in_harga_beli.DecimalPlaces = 2
        Me.in_harga_beli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_harga_beli.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.in_harga_beli.Location = New System.Drawing.Point(421, 119)
        Me.in_harga_beli.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.in_harga_beli.Name = "in_harga_beli"
        Me.in_harga_beli.Size = New System.Drawing.Size(110, 20)
        Me.in_harga_beli.TabIndex = 12
        Me.in_harga_beli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_harga_beli.ThousandsSeparator = True
        '
        'in_status
        '
        Me.in_status.BackColor = System.Drawing.Color.White
        Me.in_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status.ForeColor = System.Drawing.Color.Black
        Me.in_status.Location = New System.Drawing.Point(866, 33)
        Me.in_status.Name = "in_status"
        Me.in_status.ReadOnly = True
        Me.in_status.Size = New System.Drawing.Size(130, 20)
        Me.in_status.TabIndex = 4
        Me.in_status.TabStop = False
        '
        'in_disc4
        '
        Me.in_disc4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_disc4.Location = New System.Drawing.Point(762, 119)
        Me.in_disc4.Name = "in_disc4"
        Me.in_disc4.Size = New System.Drawing.Size(50, 20)
        Me.in_disc4.TabIndex = 17
        Me.in_disc4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_faktur
        '
        Me.in_faktur.BackColor = System.Drawing.Color.White
        Me.in_faktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_faktur.ForeColor = System.Drawing.Color.Black
        Me.in_faktur.Location = New System.Drawing.Point(866, 9)
        Me.in_faktur.MaxLength = 10
        Me.in_faktur.Name = "in_faktur"
        Me.in_faktur.ReadOnly = True
        Me.in_faktur.Size = New System.Drawing.Size(130, 20)
        Me.in_faktur.TabIndex = 1
        Me.in_faktur.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label25.Location = New System.Drawing.Point(708, 103)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(39, 13)
        Me.Label25.TabIndex = 357
        Me.Label25.Text = "Disc3"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label34.Location = New System.Drawing.Point(355, 103)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(30, 13)
        Me.Label34.TabIndex = 365
        Me.Label34.Text = "Sat."
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label24.Location = New System.Drawing.Point(657, 103)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(39, 13)
        Me.Label24.TabIndex = 358
        Me.Label24.Text = "Disc2"
        '
        'date_tgl_beli
        '
        Me.date_tgl_beli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_beli.Location = New System.Drawing.Point(65, 6)
        Me.date_tgl_beli.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_beli.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_beli.Name = "date_tgl_beli"
        Me.date_tgl_beli.Size = New System.Drawing.Size(154, 20)
        Me.date_tgl_beli.TabIndex = 0
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label23.Location = New System.Drawing.Point(606, 103)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(39, 13)
        Me.Label23.TabIndex = 359
        Me.Label23.Text = "Disc1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(823, 36)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 242
        Me.Label10.Text = "Status"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label12.Location = New System.Drawing.Point(530, 103)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 360
        Me.Label12.Text = "DiscRp"
        '
        'cb_sat
        '
        Me.cb_sat.BackColor = System.Drawing.Color.White
        Me.cb_sat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_sat.FormattingEnabled = True
        Me.cb_sat.Location = New System.Drawing.Point(358, 119)
        Me.cb_sat.Name = "cb_sat"
        Me.cb_sat.Size = New System.Drawing.Size(60, 21)
        Me.cb_sat.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(810, 103)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 361
        Me.Label9.Text = "Disc5"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label11.Location = New System.Drawing.Point(759, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 362
        Me.Label11.Text = "Disc4"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_cancel, Me.mn_createjual})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 42)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1005, 24)
        Me.MenuStrip1.TabIndex = 0
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
        'mn_cancel
        '
        Me.mn_cancel.Name = "mn_cancel"
        Me.mn_cancel.Size = New System.Drawing.Size(64, 20)
        Me.mn_cancel.Text = "&Batalkan"
        Me.mn_cancel.Visible = False
        '
        'mn_createjual
        '
        Me.mn_createjual.Name = "mn_createjual"
        Me.mn_createjual.Size = New System.Drawing.Size(98, 20)
        Me.mn_createjual.Text = "Buat Penjualan"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 543)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1005, 10)
        Me.Panel3.TabIndex = 410
        '
        'lbl_ref_faktur
        '
        Me.lbl_ref_faktur.AutoSize = True
        Me.lbl_ref_faktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ref_faktur.Location = New System.Drawing.Point(813, 61)
        Me.lbl_ref_faktur.Name = "lbl_ref_faktur"
        Me.lbl_ref_faktur.Size = New System.Drawing.Size(47, 13)
        Me.lbl_ref_faktur.TabIndex = 433
        Me.lbl_ref_faktur.Text = "Fak.Jual"
        '
        'in_ref_faktur
        '
        Me.in_ref_faktur.BackColor = System.Drawing.Color.White
        Me.in_ref_faktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ref_faktur.ForeColor = System.Drawing.Color.Black
        Me.in_ref_faktur.Location = New System.Drawing.Point(866, 58)
        Me.in_ref_faktur.MaxLength = 30
        Me.in_ref_faktur.Name = "in_ref_faktur"
        Me.in_ref_faktur.ReadOnly = True
        Me.in_ref_faktur.Size = New System.Drawing.Size(132, 20)
        Me.in_ref_faktur.TabIndex = 432
        '
        'fr_pesan_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.bt_cl
        Me.ClientSize = New System.Drawing.Size(1005, 553)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "fr_pesan_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Order Penjualan : "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.popPnl_barang.ResumeLayout(False)
        Me.popPnl_barang.PerformLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_qty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_disc3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_disc2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_disc5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_disc1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_discrp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_harga_beli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_disc4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_bataljual As System.Windows.Forms.Button
    Friend WithEvents bt_simpanjual As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents in_status As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_faktur As System.Windows.Forms.TextBox
    Friend WithEvents date_tgl_beli As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents bt_tbbarang As System.Windows.Forms.Button
    Friend WithEvents in_total As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents in_diskon As System.Windows.Forms.TextBox
    Friend WithEvents in_jumlah As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents cb_sat As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents in_disc4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_harga_beli As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_discrp As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_disc1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents in_disc5 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_disc2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_barang As System.Windows.Forms.TextBox
    Friend WithEvents in_disc3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_barang_nm As System.Windows.Forms.TextBox
    Friend WithEvents in_qty As System.Windows.Forms.NumericUpDown
    Friend WithEvents dgv_barang As System.Windows.Forms.DataGridView
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents in_gudang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang As System.Windows.Forms.TextBox
    Friend WithEvents in_sales_n As System.Windows.Forms.TextBox
    Friend WithEvents in_sales As System.Windows.Forms.TextBox
    Friend WithEvents in_custo_n As System.Windows.Forms.TextBox
    Friend WithEvents in_custo As System.Windows.Forms.TextBox
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents linkLbl_searchbarang As System.Windows.Forms.LinkLabel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cb_term As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtValDate As System.Windows.Forms.TextBox
    Friend WithEvents txtValAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents mn_cancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bt_createjual As System.Windows.Forms.Button
    Friend WithEvents cb_status As System.Windows.Forms.ComboBox
    Friend WithEvents mn_createjual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents valid_ck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_sisa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents harga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents subtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents discrp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disc1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disc2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disc3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disc4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents disc5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jml As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbl_ref_faktur As System.Windows.Forms.Label
    Friend WithEvents in_ref_faktur As System.Windows.Forms.TextBox
End Class
