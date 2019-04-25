<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_stok_mutasi_list
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_stok_mutasi_list))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.splitCt = New System.Windows.Forms.SplitContainer()
        Me.in_kat = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.in_status = New System.Windows.Forms.TextBox()
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
        Me.hpp_brg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.in_gudang2_n = New System.Windows.Forms.TextBox()
        Me.in_gudang2 = New System.Windows.Forms.TextBox()
        Me.in_gudang_n = New System.Windows.Forms.TextBox()
        Me.in_gudang = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.date_tgl_beli_r = New System.Windows.Forms.TextBox()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnl_Menu = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_tambah = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_hapus = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_print = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_refresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_cari = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgv_list = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.in_countdata = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_cari = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.splitCt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitCt.Panel1.SuspendLayout()
        Me.splitCt.Panel2.SuspendLayout()
        Me.splitCt.SuspendLayout()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_Menu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(964, 42)
        Me.Panel1.TabIndex = 247
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(884, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(937, 9)
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
        Me.lbl_title.Location = New System.Drawing.Point(6, 4)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(193, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Data Mutasi Stok"
        '
        'splitCt
        '
        Me.splitCt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitCt.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitCt.IsSplitterFixed = True
        Me.splitCt.Location = New System.Drawing.Point(0, 42)
        Me.splitCt.Name = "splitCt"
        Me.splitCt.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitCt.Panel1
        '
        Me.splitCt.Panel1.AutoScroll = True
        Me.splitCt.Panel1.BackColor = System.Drawing.Color.White
        Me.splitCt.Panel1.Controls.Add(Me.in_kat)
        Me.splitCt.Panel1.Controls.Add(Me.Label6)
        Me.splitCt.Panel1.Controls.Add(Me.Label13)
        Me.splitCt.Panel1.Controls.Add(Me.in_status)
        Me.splitCt.Panel1.Controls.Add(Me.dgv_barang)
        Me.splitCt.Panel1.Controls.Add(Me.in_gudang2_n)
        Me.splitCt.Panel1.Controls.Add(Me.in_gudang2)
        Me.splitCt.Panel1.Controls.Add(Me.in_gudang_n)
        Me.splitCt.Panel1.Controls.Add(Me.in_gudang)
        Me.splitCt.Panel1.Controls.Add(Me.Label4)
        Me.splitCt.Panel1.Controls.Add(Me.Label1)
        Me.splitCt.Panel1.Controls.Add(Me.Label3)
        Me.splitCt.Panel1.Controls.Add(Me.date_tgl_beli_r)
        Me.splitCt.Panel1.Controls.Add(Me.in_kode)
        Me.splitCt.Panel1.Controls.Add(Me.Label5)
        Me.splitCt.Panel1.Controls.Add(Me.pnl_Menu)
        '
        'splitCt.Panel2
        '
        Me.splitCt.Panel2.Controls.Add(Me.dgv_list)
        Me.splitCt.Panel2.Controls.Add(Me.Panel2)
        Me.splitCt.Size = New System.Drawing.Size(964, 533)
        Me.splitCt.SplitterDistance = 262
        Me.splitCt.TabIndex = 248
        '
        'in_kat
        '
        Me.in_kat.BackColor = System.Drawing.Color.White
        Me.in_kat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kat.ForeColor = System.Drawing.Color.Black
        Me.in_kat.Location = New System.Drawing.Point(71, 78)
        Me.in_kat.MaxLength = 200
        Me.in_kat.Name = "in_kat"
        Me.in_kat.ReadOnly = True
        Me.in_kat.Size = New System.Drawing.Size(93, 20)
        Me.in_kat.TabIndex = 330
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 331
        Me.Label6.Text = "Kateg."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(761, 37)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 329
        Me.Label13.Text = "Status"
        '
        'in_status
        '
        Me.in_status.BackColor = System.Drawing.Color.White
        Me.in_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status.ForeColor = System.Drawing.Color.Black
        Me.in_status.Location = New System.Drawing.Point(804, 35)
        Me.in_status.Name = "in_status"
        Me.in_status.ReadOnly = True
        Me.in_status.Size = New System.Drawing.Size(127, 20)
        Me.in_status.TabIndex = 328
        Me.in_status.TabStop = False
        '
        'dgv_barang
        '
        Me.dgv_barang.AllowUserToAddRows = False
        Me.dgv_barang.AllowUserToDeleteRows = False
        Me.dgv_barang.BackgroundColor = System.Drawing.Color.White
        Me.dgv_barang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kode, Me.nama, Me.qty_b, Me.sat_b, Me.qty_t, Me.sat_t, Me.qty_k, Me.sat_k, Me.qty_tot, Me.hpp_brg})
        Me.dgv_barang.Location = New System.Drawing.Point(11, 104)
        Me.dgv_barang.MultiSelect = False
        Me.dgv_barang.Name = "dgv_barang"
        Me.dgv_barang.ReadOnly = True
        Me.dgv_barang.RowHeadersVisible = False
        Me.dgv_barang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_barang.Size = New System.Drawing.Size(920, 146)
        Me.dgv_barang.TabIndex = 16
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
        Me.nama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.nama.DataPropertyName = "barang_nama"
        Me.nama.HeaderText = "Nama Barang"
        Me.nama.MinimumWidth = 190
        Me.nama.Name = "nama"
        Me.nama.ReadOnly = True
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
        Me.qty_tot.MinimumWidth = 30
        Me.qty_tot.Name = "qty_tot"
        Me.qty_tot.ReadOnly = True
        Me.qty_tot.Width = 65
        '
        'hpp_brg
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.hpp_brg.DefaultCellStyle = DataGridViewCellStyle1
        Me.hpp_brg.HeaderText = "HPP"
        Me.hpp_brg.Name = "hpp_brg"
        Me.hpp_brg.ReadOnly = True
        Me.hpp_brg.Width = 125
        '
        'in_gudang2_n
        '
        Me.in_gudang2_n.BackColor = System.Drawing.Color.White
        Me.in_gudang2_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang2_n.ForeColor = System.Drawing.Color.Black
        Me.in_gudang2_n.Location = New System.Drawing.Point(466, 56)
        Me.in_gudang2_n.MaxLength = 200
        Me.in_gudang2_n.Name = "in_gudang2_n"
        Me.in_gudang2_n.ReadOnly = True
        Me.in_gudang2_n.Size = New System.Drawing.Size(236, 20)
        Me.in_gudang2_n.TabIndex = 5
        '
        'in_gudang2
        '
        Me.in_gudang2.BackColor = System.Drawing.Color.Gainsboro
        Me.in_gudang2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang2.ForeColor = System.Drawing.Color.Black
        Me.in_gudang2.Location = New System.Drawing.Point(343, 56)
        Me.in_gudang2.MaxLength = 30
        Me.in_gudang2.Name = "in_gudang2"
        Me.in_gudang2.ReadOnly = True
        Me.in_gudang2.Size = New System.Drawing.Size(121, 20)
        Me.in_gudang2.TabIndex = 4
        '
        'in_gudang_n
        '
        Me.in_gudang_n.BackColor = System.Drawing.Color.White
        Me.in_gudang_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang_n.ForeColor = System.Drawing.Color.Black
        Me.in_gudang_n.Location = New System.Drawing.Point(466, 34)
        Me.in_gudang_n.MaxLength = 200
        Me.in_gudang_n.Name = "in_gudang_n"
        Me.in_gudang_n.ReadOnly = True
        Me.in_gudang_n.Size = New System.Drawing.Size(236, 20)
        Me.in_gudang_n.TabIndex = 3
        '
        'in_gudang
        '
        Me.in_gudang.BackColor = System.Drawing.Color.Gainsboro
        Me.in_gudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang.ForeColor = System.Drawing.Color.Black
        Me.in_gudang.Location = New System.Drawing.Point(343, 34)
        Me.in_gudang.MaxLength = 30
        Me.in_gudang.Name = "in_gudang"
        Me.in_gudang.ReadOnly = True
        Me.in_gudang.Size = New System.Drawing.Size(121, 20)
        Me.in_gudang.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 258
        Me.Label4.Text = "Tanggal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(259, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 254
        Me.Label1.Text = "Gudang Tujuan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(259, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 256
        Me.Label3.Text = "Gudang Asal"
        '
        'date_tgl_beli_r
        '
        Me.date_tgl_beli_r.BackColor = System.Drawing.Color.White
        Me.date_tgl_beli_r.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_beli_r.Location = New System.Drawing.Point(71, 56)
        Me.date_tgl_beli_r.MaxLength = 15
        Me.date_tgl_beli_r.Name = "date_tgl_beli_r"
        Me.date_tgl_beli_r.ReadOnly = True
        Me.date_tgl_beli_r.Size = New System.Drawing.Size(172, 20)
        Me.date_tgl_beli_r.TabIndex = 252
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.White
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.Location = New System.Drawing.Point(71, 34)
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
        Me.Label5.Location = New System.Drawing.Point(8, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 257
        Me.Label5.Text = "No. Bukti"
        '
        'pnl_Menu
        '
        Me.pnl_Menu.Controls.Add(Me.MenuStrip1)
        Me.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Menu.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Menu.Name = "pnl_Menu"
        Me.pnl_Menu.Size = New System.Drawing.Size(964, 28)
        Me.pnl_Menu.TabIndex = 248
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_tambah, Me.mn_edit, Me.mn_hapus, Me.mn_print, Me.mn_refresh, Me.mn_cari})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(964, 24)
        Me.MenuStrip1.TabIndex = 182
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mn_tambah
        '
        Me.mn_tambah.Image = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.mn_tambah.Name = "mn_tambah"
        Me.mn_tambah.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.mn_tambah.Size = New System.Drawing.Size(78, 20)
        Me.mn_tambah.Text = "Tambah"
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
        'mn_print
        '
        Me.mn_print.Image = CType(resources.GetObject("mn_print.Image"), System.Drawing.Image)
        Me.mn_print.Name = "mn_print"
        Me.mn_print.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.mn_print.Size = New System.Drawing.Size(60, 20)
        Me.mn_print.Text = "Print"
        Me.mn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.mn_print.Visible = False
        '
        'mn_refresh
        '
        Me.mn_refresh.Name = "mn_refresh"
        Me.mn_refresh.ShortcutKeys = System.Windows.Forms.Keys.F5
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
        Me.dgv_list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_list.Location = New System.Drawing.Point(0, 0)
        Me.dgv_list.MultiSelect = False
        Me.dgv_list.Name = "dgv_list"
        Me.dgv_list.ReadOnly = True
        Me.dgv_list.RowHeadersVisible = False
        Me.dgv_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_list.Size = New System.Drawing.Size(964, 225)
        Me.dgv_list.TabIndex = 17
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Controls.Add(Me.in_countdata)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.in_cari)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 225)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(964, 42)
        Me.Panel2.TabIndex = 248
        '
        'in_countdata
        '
        Me.in_countdata.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.in_countdata.BackColor = System.Drawing.Color.White
        Me.in_countdata.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_countdata.Location = New System.Drawing.Point(899, 10)
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
        'fr_stok_mutasi_list
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.splitCt)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "fr_stok_mutasi_list"
        Me.Size = New System.Drawing.Size(964, 575)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.splitCt.Panel1.ResumeLayout(False)
        Me.splitCt.Panel1.PerformLayout()
        Me.splitCt.Panel2.ResumeLayout(False)
        CType(Me.splitCt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitCt.ResumeLayout(False)
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_Menu.ResumeLayout(False)
        Me.pnl_Menu.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents splitCt As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgv_list As System.Windows.Forms.DataGridView
    Friend WithEvents pnl_Menu As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents in_countdata As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_cari As System.Windows.Forms.TextBox
    Friend WithEvents mn_tambah As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_hapus As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_refresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgv_barang As System.Windows.Forms.DataGridView
    Friend WithEvents date_tgl_beli_r As System.Windows.Forms.TextBox
    Friend WithEvents mn_cari As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents in_gudang2_n As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang2 As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents in_status As System.Windows.Forms.TextBox
    Friend WithEvents kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_k As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_k As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_tot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hpp_brg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents in_kat As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
