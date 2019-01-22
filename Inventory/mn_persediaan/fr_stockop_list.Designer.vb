<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_stockop_list
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_stockop_list))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.in_hpp = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.linkLbl_searchbarang = New System.Windows.Forms.LinkLabel()
        Me.in_gudang_n = New System.Windows.Forms.TextBox()
        Me.in_gudang = New System.Windows.Forms.TextBox()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.in_sat2 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.in_qty1 = New System.Windows.Forms.TextBox()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.in_sat1 = New System.Windows.Forms.TextBox()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.in_barang = New System.Windows.Forms.TextBox()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.in_barang_nm = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.in_qty2 = New System.Windows.Forms.NumericUpDown()
        Me.date_tgl_beli = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.date_tgl_beli_r = New System.Windows.Forms.TextBox()
        Me.dgv_barang = New System.Windows.Forms.DataGridView()
        Me.kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_sys = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat_sys = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nilai_sys = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hpp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_fis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat_fis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nilai_fis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hpp_fis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_sel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nilai_sel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_tambah = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_hapus = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_proses = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_print = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_refresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_cari = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgv_list = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.in_countdata = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_cari = New System.Windows.Forms.TextBox()
        Me.pnl_container = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbl_bttmpad = New System.Windows.Forms.Label()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.txtProcAlias = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtProcDate = New System.Windows.Forms.TextBox()
        Me.in_status = New System.Windows.Forms.TextBox()
        Me.bt_tbbarang = New System.Windows.Forms.Button()
        Me.bt_sidepnl_sw = New System.Windows.Forms.Button()
        Me.pnl_side = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.in_hpp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnl_container.SuspendLayout()
        Me.pnl_side.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(1096, 42)
        Me.Panel1.TabIndex = 248
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(1011, 11)
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
        Me.bt_cl.Location = New System.Drawing.Point(1064, 11)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 137
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Orange
        Me.lbl_title.Font = New System.Drawing.Font("Source Sans Pro", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(6, 6)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(222, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Data Stock Opname"
        '
        'in_hpp
        '
        Me.in_hpp.BackColor = System.Drawing.Color.White
        Me.in_hpp.DecimalPlaces = 2
        Me.in_hpp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_hpp.Location = New System.Drawing.Point(553, 73)
        Me.in_hpp.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.in_hpp.Name = "in_hpp"
        Me.in_hpp.Size = New System.Drawing.Size(138, 20)
        Me.in_hpp.TabIndex = 13
        Me.in_hpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_hpp.ThousandsSeparator = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(550, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 327
        Me.Label7.Text = "HPP"
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Controls.Add(Me.linkLbl_searchbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(207, 86)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(330, 135)
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
        Me.dgv_listbarang.Size = New System.Drawing.Size(330, 127)
        Me.dgv_listbarang.TabIndex = 0
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
        'in_gudang_n
        '
        Me.in_gudang_n.BackColor = System.Drawing.Color.White
        Me.in_gudang_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang_n.ForeColor = System.Drawing.Color.Black
        Me.in_gudang_n.Location = New System.Drawing.Point(457, 9)
        Me.in_gudang_n.MaxLength = 200
        Me.in_gudang_n.Name = "in_gudang_n"
        Me.in_gudang_n.ReadOnly = True
        Me.in_gudang_n.Size = New System.Drawing.Size(236, 20)
        Me.in_gudang_n.TabIndex = 3
        '
        'in_gudang
        '
        Me.in_gudang.BackColor = System.Drawing.Color.White
        Me.in_gudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang.ForeColor = System.Drawing.Color.Black
        Me.in_gudang.Location = New System.Drawing.Point(334, 9)
        Me.in_gudang.MaxLength = 30
        Me.in_gudang.Name = "in_gudang"
        Me.in_gudang.ReadOnly = True
        Me.in_gudang.Size = New System.Drawing.Size(121, 20)
        Me.in_gudang.TabIndex = 2
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(567, 339)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(107, 20)
        Me.txtRegAlias.TabIndex = 320
        Me.txtRegAlias.TabStop = False
        '
        'in_sat2
        '
        Me.in_sat2.BackColor = System.Drawing.Color.White
        Me.in_sat2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sat2.Location = New System.Drawing.Point(495, 73)
        Me.in_sat2.Name = "in_sat2"
        Me.in_sat2.ReadOnly = True
        Me.in_sat2.Size = New System.Drawing.Size(55, 20)
        Me.in_sat2.TabIndex = 12
        Me.in_sat2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(508, 342)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(39, 13)
        Me.Label27.TabIndex = 322
        Me.Label27.Text = "RegBy"
        '
        'in_qty1
        '
        Me.in_qty1.BackColor = System.Drawing.Color.White
        Me.in_qty1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty1.Location = New System.Drawing.Point(311, 73)
        Me.in_qty1.Name = "in_qty1"
        Me.in_qty1.ReadOnly = True
        Me.in_qty1.Size = New System.Drawing.Size(63, 20)
        Me.in_qty1.TabIndex = 10
        Me.in_qty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(676, 361)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(178, 20)
        Me.txtUpdDate.TabIndex = 318
        Me.txtUpdDate.TabStop = False
        '
        'in_sat1
        '
        Me.in_sat1.BackColor = System.Drawing.Color.White
        Me.in_sat1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sat1.Location = New System.Drawing.Point(374, 73)
        Me.in_sat1.Name = "in_sat1"
        Me.in_sat1.ReadOnly = True
        Me.in_sat1.Size = New System.Drawing.Size(55, 20)
        Me.in_sat1.TabIndex = 10
        Me.in_sat1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(567, 361)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(107, 20)
        Me.txtUpdAlias.TabIndex = 323
        Me.txtUpdAlias.TabStop = False
        '
        'in_barang
        '
        Me.in_barang.BackColor = System.Drawing.Color.White
        Me.in_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang.Location = New System.Drawing.Point(21, 73)
        Me.in_barang.MaxLength = 20
        Me.in_barang.Name = "in_barang"
        Me.in_barang.Size = New System.Drawing.Size(100, 20)
        Me.in_barang.TabIndex = 7
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(676, 339)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(178, 20)
        Me.txtRegdate.TabIndex = 319
        Me.txtRegdate.TabStop = False
        '
        'in_barang_nm
        '
        Me.in_barang_nm.BackColor = System.Drawing.Color.White
        Me.in_barang_nm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang_nm.ForeColor = System.Drawing.Color.Black
        Me.in_barang_nm.Location = New System.Drawing.Point(121, 73)
        Me.in_barang_nm.MaxLength = 150
        Me.in_barang_nm.Name = "in_barang_nm"
        Me.in_barang_nm.ReadOnly = True
        Me.in_barang_nm.Size = New System.Drawing.Size(188, 20)
        Me.in_barang_nm.TabIndex = 8
        Me.in_barang_nm.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(508, 364)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(59, 13)
        Me.Label28.TabIndex = 325
        Me.Label28.Text = "LastUpdBy"
        '
        'in_qty2
        '
        Me.in_qty2.BackColor = System.Drawing.Color.White
        Me.in_qty2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty2.Location = New System.Drawing.Point(432, 73)
        Me.in_qty2.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.in_qty2.Name = "in_qty2"
        Me.in_qty2.Size = New System.Drawing.Size(64, 20)
        Me.in_qty2.TabIndex = 11
        Me.in_qty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'date_tgl_beli
        '
        Me.date_tgl_beli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_beli.Location = New System.Drawing.Point(72, 31)
        Me.date_tgl_beli.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_beli.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_beli.Name = "date_tgl_beli"
        Me.date_tgl_beli.Size = New System.Drawing.Size(172, 20)
        Me.date_tgl_beli.TabIndex = 1
        Me.date_tgl_beli.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.Location = New System.Drawing.Point(429, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 256
        Me.Label6.Text = "Qty Fisik"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 258
        Me.Label4.Text = "Tanggal"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label21.Location = New System.Drawing.Point(308, 57)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(70, 13)
        Me.Label21.TabIndex = 256
        Me.Label21.Text = "Qty System"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label20.Location = New System.Drawing.Point(116, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 13)
        Me.Label20.TabIndex = 256
        Me.Label20.Text = "Nama"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(260, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 256
        Me.Label3.Text = "Gudang Asal"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(18, 57)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 256
        Me.Label16.Text = "Kode"
        '
        'date_tgl_beli_r
        '
        Me.date_tgl_beli_r.BackColor = System.Drawing.Color.White
        Me.date_tgl_beli_r.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_beli_r.Location = New System.Drawing.Point(72, 31)
        Me.date_tgl_beli_r.MaxLength = 15
        Me.date_tgl_beli_r.Name = "date_tgl_beli_r"
        Me.date_tgl_beli_r.ReadOnly = True
        Me.date_tgl_beli_r.Size = New System.Drawing.Size(172, 20)
        Me.date_tgl_beli_r.TabIndex = 252
        '
        'dgv_barang
        '
        Me.dgv_barang.AllowUserToAddRows = False
        Me.dgv_barang.AllowUserToDeleteRows = False
        Me.dgv_barang.BackgroundColor = System.Drawing.Color.White
        Me.dgv_barang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kode, Me.nama, Me.qty_sys, Me.sat_sys, Me.nilai_sys, Me.hpp, Me.qty_fis, Me.sat_fis, Me.nilai_fis, Me.hpp_fis, Me.qty_sel, Me.nilai_sel})
        Me.dgv_barang.Location = New System.Drawing.Point(12, 99)
        Me.dgv_barang.MultiSelect = False
        Me.dgv_barang.Name = "dgv_barang"
        Me.dgv_barang.ReadOnly = True
        Me.dgv_barang.RowHeadersVisible = False
        Me.dgv_barang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_barang.Size = New System.Drawing.Size(789, 179)
        Me.dgv_barang.TabIndex = 264
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
        'qty_sys
        '
        Me.qty_sys.DataPropertyName = "trans_qty"
        Me.qty_sys.HeaderText = "QTY Sys."
        Me.qty_sys.MinimumWidth = 65
        Me.qty_sys.Name = "qty_sys"
        Me.qty_sys.ReadOnly = True
        Me.qty_sys.Width = 65
        '
        'sat_sys
        '
        Me.sat_sys.DataPropertyName = "trans_satuan"
        Me.sat_sys.HeaderText = "Sat. Sys."
        Me.sat_sys.MinimumWidth = 65
        Me.sat_sys.Name = "sat_sys"
        Me.sat_sys.ReadOnly = True
        Me.sat_sys.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.sat_sys.Width = 65
        '
        'nilai_sys
        '
        Me.nilai_sys.HeaderText = "Nilai Pers. Sys."
        Me.nilai_sys.Name = "nilai_sys"
        Me.nilai_sys.ReadOnly = True
        Me.nilai_sys.Visible = False
        '
        'hpp
        '
        Me.hpp.HeaderText = "HPP"
        Me.hpp.Name = "hpp"
        Me.hpp.ReadOnly = True
        '
        'qty_fis
        '
        Me.qty_fis.HeaderText = "QTY Fisik"
        Me.qty_fis.MinimumWidth = 65
        Me.qty_fis.Name = "qty_fis"
        Me.qty_fis.ReadOnly = True
        Me.qty_fis.Width = 70
        '
        'sat_fis
        '
        Me.sat_fis.HeaderText = "Sat. Fisik"
        Me.sat_fis.MinimumWidth = 65
        Me.sat_fis.Name = "sat_fis"
        Me.sat_fis.ReadOnly = True
        Me.sat_fis.Width = 70
        '
        'nilai_fis
        '
        Me.nilai_fis.HeaderText = "Nilai Pers. Fis."
        Me.nilai_fis.Name = "nilai_fis"
        Me.nilai_fis.ReadOnly = True
        Me.nilai_fis.Visible = False
        '
        'hpp_fis
        '
        Me.hpp_fis.HeaderText = "HPP Fisik"
        Me.hpp_fis.Name = "hpp_fis"
        Me.hpp_fis.ReadOnly = True
        '
        'qty_sel
        '
        Me.qty_sel.HeaderText = "Selisih"
        Me.qty_sel.MinimumWidth = 65
        Me.qty_sel.Name = "qty_sel"
        Me.qty_sel.ReadOnly = True
        Me.qty_sel.Width = 65
        '
        'nilai_sel
        '
        Me.nilai_sel.HeaderText = "Selisih Nilai"
        Me.nilai_sel.Name = "nilai_sel"
        Me.nilai_sel.ReadOnly = True
        Me.nilai_sel.Visible = False
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.White
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.Location = New System.Drawing.Point(72, 9)
        Me.in_kode.MaxLength = 15
        Me.in_kode.Name = "in_kode"
        Me.in_kode.ReadOnly = True
        Me.in_kode.Size = New System.Drawing.Size(172, 20)
        Me.in_kode.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 257
        Me.Label5.Text = "No. Bukti"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_tambah, Me.mn_edit, Me.mn_hapus, Me.mn_save, Me.mn_proses, Me.mn_print, Me.mn_refresh, Me.mn_cari})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 42)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1096, 24)
        Me.MenuStrip1.TabIndex = 182
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mn_tambah
        '
        Me.mn_tambah.Image = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.mn_tambah.Name = "mn_tambah"
        Me.mn_tambah.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.mn_tambah.Size = New System.Drawing.Size(59, 20)
        Me.mn_tambah.Text = "Baru"
        '
        'mn_edit
        '
        Me.mn_edit.Image = Global.Inventory.My.Resources.Resources.toolbar_list_icon1
        Me.mn_edit.Name = "mn_edit"
        Me.mn_edit.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.mn_edit.Size = New System.Drawing.Size(55, 20)
        Me.mn_edit.Text = "Edit"
        '
        'mn_hapus
        '
        Me.mn_hapus.Name = "mn_hapus"
        Me.mn_hapus.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.mn_hapus.Size = New System.Drawing.Size(115, 20)
        Me.mn_hapus.Text = "Batalkan Transaksi"
        '
        'mn_save
        '
        Me.mn_save.Enabled = False
        Me.mn_save.Image = Global.Inventory.My.Resources.Resources.toolbar_save_icon_s
        Me.mn_save.Name = "mn_save"
        Me.mn_save.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mn_save.Size = New System.Drawing.Size(59, 20)
        Me.mn_save.Text = "Save"
        Me.mn_save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mn_proses
        '
        Me.mn_proses.Image = Global.Inventory.My.Resources.Resources.toolbar_list_icon1
        Me.mn_proses.Name = "mn_proses"
        Me.mn_proses.Size = New System.Drawing.Size(69, 20)
        Me.mn_proses.Text = "Proses"
        '
        'mn_print
        '
        Me.mn_print.Image = CType(resources.GetObject("mn_print.Image"), System.Drawing.Image)
        Me.mn_print.Name = "mn_print"
        Me.mn_print.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.mn_print.Size = New System.Drawing.Size(60, 20)
        Me.mn_print.Text = "Print"
        Me.mn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mn_refresh
        '
        Me.mn_refresh.Name = "mn_refresh"
        Me.mn_refresh.Size = New System.Drawing.Size(58, 20)
        Me.mn_refresh.Text = "Refresh"
        '
        'mn_cari
        '
        Me.mn_cari.Name = "mn_cari"
        Me.mn_cari.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.mn_cari.Size = New System.Drawing.Size(40, 20)
        Me.mn_cari.Text = "Cari"
        Me.mn_cari.Visible = False
        '
        'dgv_list
        '
        Me.dgv_list.AllowUserToAddRows = False
        Me.dgv_list.AllowUserToDeleteRows = False
        Me.dgv_list.AllowUserToResizeRows = False
        Me.dgv_list.BackgroundColor = System.Drawing.Color.White
        Me.dgv_list.CausesValidation = False
        Me.dgv_list.Dock = System.Windows.Forms.DockStyle.Right
        Me.dgv_list.Location = New System.Drawing.Point(737, 66)
        Me.dgv_list.MultiSelect = False
        Me.dgv_list.Name = "dgv_list"
        Me.dgv_list.ReadOnly = True
        Me.dgv_list.RowHeadersVisible = False
        Me.dgv_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_list.Size = New System.Drawing.Size(333, 467)
        Me.dgv_list.TabIndex = 17
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Controls.Add(Me.in_countdata)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.in_cari)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 533)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1096, 42)
        Me.Panel2.TabIndex = 248
        '
        'in_countdata
        '
        Me.in_countdata.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.in_countdata.BackColor = System.Drawing.Color.White
        Me.in_countdata.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_countdata.Location = New System.Drawing.Point(1101, 10)
        Me.in_countdata.MaxLength = 100
        Me.in_countdata.Name = "in_countdata"
        Me.in_countdata.ReadOnly = True
        Me.in_countdata.Size = New System.Drawing.Size(45, 22)
        Me.in_countdata.TabIndex = 12
        Me.in_countdata.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 26)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Pencarian :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(CTRL+F)"
        '
        'in_cari
        '
        Me.in_cari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari.Location = New System.Drawing.Point(92, 10)
        Me.in_cari.MaxLength = 100
        Me.in_cari.Name = "in_cari"
        Me.in_cari.Size = New System.Drawing.Size(248, 22)
        Me.in_cari.TabIndex = 18
        '
        'pnl_container
        '
        Me.pnl_container.AutoScroll = True
        Me.pnl_container.BackColor = System.Drawing.Color.White
        Me.pnl_container.Controls.Add(Me.Label1)
        Me.pnl_container.Controls.Add(Me.popPnl_barang)
        Me.pnl_container.Controls.Add(Me.Label10)
        Me.pnl_container.Controls.Add(Me.lbl_bttmpad)
        Me.pnl_container.Controls.Add(Me.in_ket)
        Me.pnl_container.Controls.Add(Me.txtProcAlias)
        Me.pnl_container.Controls.Add(Me.Label8)
        Me.pnl_container.Controls.Add(Me.txtProcDate)
        Me.pnl_container.Controls.Add(Me.in_status)
        Me.pnl_container.Controls.Add(Me.bt_tbbarang)
        Me.pnl_container.Controls.Add(Me.in_hpp)
        Me.pnl_container.Controls.Add(Me.Label7)
        Me.pnl_container.Controls.Add(Me.Label5)
        Me.pnl_container.Controls.Add(Me.in_kode)
        Me.pnl_container.Controls.Add(Me.dgv_barang)
        Me.pnl_container.Controls.Add(Me.in_gudang_n)
        Me.pnl_container.Controls.Add(Me.date_tgl_beli_r)
        Me.pnl_container.Controls.Add(Me.Label16)
        Me.pnl_container.Controls.Add(Me.Label3)
        Me.pnl_container.Controls.Add(Me.in_gudang)
        Me.pnl_container.Controls.Add(Me.Label20)
        Me.pnl_container.Controls.Add(Me.txtRegAlias)
        Me.pnl_container.Controls.Add(Me.Label21)
        Me.pnl_container.Controls.Add(Me.in_sat2)
        Me.pnl_container.Controls.Add(Me.Label4)
        Me.pnl_container.Controls.Add(Me.Label27)
        Me.pnl_container.Controls.Add(Me.Label6)
        Me.pnl_container.Controls.Add(Me.in_qty1)
        Me.pnl_container.Controls.Add(Me.date_tgl_beli)
        Me.pnl_container.Controls.Add(Me.txtUpdDate)
        Me.pnl_container.Controls.Add(Me.in_qty2)
        Me.pnl_container.Controls.Add(Me.in_sat1)
        Me.pnl_container.Controls.Add(Me.Label28)
        Me.pnl_container.Controls.Add(Me.txtUpdAlias)
        Me.pnl_container.Controls.Add(Me.in_barang_nm)
        Me.pnl_container.Controls.Add(Me.in_barang)
        Me.pnl_container.Controls.Add(Me.txtRegdate)
        Me.pnl_container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_container.Location = New System.Drawing.Point(0, 66)
        Me.pnl_container.Name = "pnl_container"
        Me.pnl_container.Size = New System.Drawing.Size(737, 467)
        Me.pnl_container.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(9, 311)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 338
        Me.Label1.Text = "Keterangan"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label10.Location = New System.Drawing.Point(9, 287)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 337
        Me.Label10.Text = "Status"
        '
        'lbl_bttmpad
        '
        Me.lbl_bttmpad.AutoSize = True
        Me.lbl_bttmpad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_bttmpad.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_bttmpad.Location = New System.Drawing.Point(564, 409)
        Me.lbl_bttmpad.Name = "lbl_bttmpad"
        Me.lbl_bttmpad.Size = New System.Drawing.Size(0, 13)
        Me.lbl_bttmpad.TabIndex = 335
        '
        'in_ket
        '
        Me.in_ket.BackColor = System.Drawing.Color.White
        Me.in_ket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.ForeColor = System.Drawing.Color.Black
        Me.in_ket.Location = New System.Drawing.Point(87, 308)
        Me.in_ket.Multiline = True
        Me.in_ket.Name = "in_ket"
        Me.in_ket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_ket.Size = New System.Drawing.Size(409, 95)
        Me.in_ket.TabIndex = 334
        '
        'txtProcAlias
        '
        Me.txtProcAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcAlias.Location = New System.Drawing.Point(567, 383)
        Me.txtProcAlias.Name = "txtProcAlias"
        Me.txtProcAlias.ReadOnly = True
        Me.txtProcAlias.Size = New System.Drawing.Size(107, 20)
        Me.txtProcAlias.TabIndex = 332
        Me.txtProcAlias.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(508, 386)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 333
        Me.Label8.Text = "ProcBy"
        '
        'txtProcDate
        '
        Me.txtProcDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcDate.Location = New System.Drawing.Point(676, 383)
        Me.txtProcDate.Name = "txtProcDate"
        Me.txtProcDate.ReadOnly = True
        Me.txtProcDate.Size = New System.Drawing.Size(178, 20)
        Me.txtProcDate.TabIndex = 331
        Me.txtProcDate.TabStop = False
        '
        'in_status
        '
        Me.in_status.BackColor = System.Drawing.Color.White
        Me.in_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status.ForeColor = System.Drawing.Color.Black
        Me.in_status.Location = New System.Drawing.Point(87, 284)
        Me.in_status.Name = "in_status"
        Me.in_status.ReadOnly = True
        Me.in_status.Size = New System.Drawing.Size(169, 20)
        Me.in_status.TabIndex = 329
        Me.in_status.TabStop = False
        '
        'bt_tbbarang
        '
        Me.bt_tbbarang.BackColor = System.Drawing.Color.Transparent
        Me.bt_tbbarang.BackgroundImage = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.bt_tbbarang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_tbbarang.FlatAppearance.BorderSize = 0
        Me.bt_tbbarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_tbbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tbbarang.Location = New System.Drawing.Point(697, 74)
        Me.bt_tbbarang.Name = "bt_tbbarang"
        Me.bt_tbbarang.Size = New System.Drawing.Size(18, 18)
        Me.bt_tbbarang.TabIndex = 328
        Me.bt_tbbarang.UseVisualStyleBackColor = False
        '
        'bt_sidepnl_sw
        '
        Me.bt_sidepnl_sw.BackColor = System.Drawing.Color.Transparent
        Me.bt_sidepnl_sw.BackgroundImage = Global.Inventory.My.Resources.Resources.toolbar_list_icon1
        Me.bt_sidepnl_sw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_sidepnl_sw.FlatAppearance.BorderSize = 0
        Me.bt_sidepnl_sw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_sidepnl_sw.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_sidepnl_sw.Location = New System.Drawing.Point(4, 9)
        Me.bt_sidepnl_sw.Name = "bt_sidepnl_sw"
        Me.bt_sidepnl_sw.Size = New System.Drawing.Size(18, 18)
        Me.bt_sidepnl_sw.TabIndex = 338
        Me.bt_sidepnl_sw.UseVisualStyleBackColor = False
        '
        'pnl_side
        '
        Me.pnl_side.BackColor = System.Drawing.SystemColors.Control
        Me.pnl_side.Controls.Add(Me.bt_sidepnl_sw)
        Me.pnl_side.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnl_side.Location = New System.Drawing.Point(1070, 66)
        Me.pnl_side.Name = "pnl_side"
        Me.pnl_side.Size = New System.Drawing.Size(26, 467)
        Me.pnl_side.TabIndex = 249
        '
        'fr_stockop_list
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.pnl_container)
        Me.Controls.Add(Me.dgv_list)
        Me.Controls.Add(Me.pnl_side)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "fr_stockop_list"
        Me.Size = New System.Drawing.Size(1096, 575)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.in_hpp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popPnl_barang.ResumeLayout(False)
        Me.popPnl_barang.PerformLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_qty2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnl_container.ResumeLayout(False)
        Me.pnl_container.PerformLayout()
        Me.pnl_side.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents linkLbl_searchbarang As System.Windows.Forms.LinkLabel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents in_sat2 As System.Windows.Forms.TextBox
    Friend WithEvents in_sat1 As System.Windows.Forms.TextBox
    Friend WithEvents in_barang As System.Windows.Forms.TextBox
    Friend WithEvents in_barang_nm As System.Windows.Forms.TextBox
    Friend WithEvents in_qty2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents date_tgl_beli As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents date_tgl_beli_r As System.Windows.Forms.TextBox
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_tambah As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_hapus As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_refresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_cari As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgv_list As System.Windows.Forms.DataGridView
    Friend WithEvents in_countdata As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_cari As System.Windows.Forms.TextBox
    Friend WithEvents dgv_barang As System.Windows.Forms.DataGridView
    Friend WithEvents in_qty1 As System.Windows.Forms.TextBox
    Friend WithEvents mn_proses As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents in_gudang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang As System.Windows.Forms.TextBox
    Friend WithEvents in_hpp As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnl_container As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents bt_tbbarang As System.Windows.Forms.Button
    Friend WithEvents kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_sys As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_sys As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nilai_sys As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hpp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_fis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_fis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nilai_fis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hpp_fis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_sel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nilai_sel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbl_bttmpad As System.Windows.Forms.Label
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
    Friend WithEvents txtProcAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtProcDate As System.Windows.Forms.TextBox
    Friend WithEvents in_status As System.Windows.Forms.TextBox
    Friend WithEvents bt_sidepnl_sw As System.Windows.Forms.Button
    Friend WithEvents pnl_side As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
