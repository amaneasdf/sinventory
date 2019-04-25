<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_stok_mutasibarang_list
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_stok_mutasibarang_list))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.in_kat = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.in_status = New System.Windows.Forms.TextBox()
        Me.dgv_barang = New System.Windows.Forms.DataGridView()
        Me.kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_a = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat_a = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hpp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kode_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nama_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hpp_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.in_gudang_n = New System.Windows.Forms.TextBox()
        Me.in_gudang = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.in_countdata = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.in_cari = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_Menu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
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
        Me.Panel1.TabIndex = 248
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
        Me.bt_cl.TabIndex = 21
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
        Me.lbl_title.Size = New System.Drawing.Size(223, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Data Mutasi Barang"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 42)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.in_kat)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label15)
        Me.SplitContainer1.Panel1.Controls.Add(Me.in_status)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgv_barang)
        Me.SplitContainer1.Panel1.Controls.Add(Me.in_gudang_n)
        Me.SplitContainer1.Panel1.Controls.Add(Me.in_gudang)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.date_tgl_beli_r)
        Me.SplitContainer1.Panel1.Controls.Add(Me.in_kode)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnl_Menu)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv_list)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel4)
        Me.SplitContainer1.Size = New System.Drawing.Size(964, 533)
        Me.SplitContainer1.SplitterDistance = 263
        Me.SplitContainer1.TabIndex = 250
        '
        'in_kat
        '
        Me.in_kat.BackColor = System.Drawing.Color.White
        Me.in_kat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kat.ForeColor = System.Drawing.Color.Black
        Me.in_kat.Location = New System.Drawing.Point(325, 56)
        Me.in_kat.MaxLength = 200
        Me.in_kat.Name = "in_kat"
        Me.in_kat.ReadOnly = True
        Me.in_kat.Size = New System.Drawing.Size(121, 20)
        Me.in_kat.TabIndex = 336
        Me.in_kat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(263, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 337
        Me.Label6.Text = "Kateg."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(768, 38)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 13)
        Me.Label15.TabIndex = 335
        Me.Label15.Text = "Status"
        '
        'in_status
        '
        Me.in_status.BackColor = System.Drawing.Color.White
        Me.in_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status.ForeColor = System.Drawing.Color.Black
        Me.in_status.Location = New System.Drawing.Point(811, 34)
        Me.in_status.Name = "in_status"
        Me.in_status.ReadOnly = True
        Me.in_status.Size = New System.Drawing.Size(146, 20)
        Me.in_status.TabIndex = 334
        Me.in_status.TabStop = False
        '
        'dgv_barang
        '
        Me.dgv_barang.AllowUserToAddRows = False
        Me.dgv_barang.AllowUserToDeleteRows = False
        Me.dgv_barang.BackgroundColor = System.Drawing.Color.White
        Me.dgv_barang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kode, Me.nama, Me.qty_a, Me.sat_a, Me.hpp, Me.kode_b, Me.nama_b, Me.qty_b, Me.sat_b, Me.hpp_b})
        Me.dgv_barang.Location = New System.Drawing.Point(11, 82)
        Me.dgv_barang.MultiSelect = False
        Me.dgv_barang.Name = "dgv_barang"
        Me.dgv_barang.ReadOnly = True
        Me.dgv_barang.RowHeadersVisible = False
        Me.dgv_barang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_barang.Size = New System.Drawing.Size(946, 175)
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
        'qty_a
        '
        Me.qty_a.DataPropertyName = "trans_qty"
        Me.qty_a.HeaderText = "QTY A"
        Me.qty_a.MinimumWidth = 65
        Me.qty_a.Name = "qty_a"
        Me.qty_a.ReadOnly = True
        Me.qty_a.Width = 65
        '
        'sat_a
        '
        Me.sat_a.DataPropertyName = "trans_satuan"
        Me.sat_a.HeaderText = "Sat. A"
        Me.sat_a.MinimumWidth = 65
        Me.sat_a.Name = "sat_a"
        Me.sat_a.ReadOnly = True
        Me.sat_a.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.sat_a.Width = 65
        '
        'hpp
        '
        Me.hpp.DataPropertyName = "hpp"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.hpp.DefaultCellStyle = DataGridViewCellStyle1
        Me.hpp.HeaderText = "HPP Asal"
        Me.hpp.Name = "hpp"
        Me.hpp.ReadOnly = True
        Me.hpp.Visible = False
        '
        'kode_b
        '
        Me.kode_b.HeaderText = "Kode"
        Me.kode_b.Name = "kode_b"
        Me.kode_b.ReadOnly = True
        '
        'nama_b
        '
        Me.nama_b.HeaderText = "Nama Barang"
        Me.nama_b.MinimumWidth = 190
        Me.nama_b.Name = "nama_b"
        Me.nama_b.ReadOnly = True
        Me.nama_b.Width = 190
        '
        'qty_b
        '
        Me.qty_b.HeaderText = "QTY B"
        Me.qty_b.MinimumWidth = 65
        Me.qty_b.Name = "qty_b"
        Me.qty_b.ReadOnly = True
        Me.qty_b.Width = 65
        '
        'sat_b
        '
        Me.sat_b.HeaderText = "Sat. B"
        Me.sat_b.MinimumWidth = 65
        Me.sat_b.Name = "sat_b"
        Me.sat_b.ReadOnly = True
        Me.sat_b.Width = 65
        '
        'hpp_b
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        Me.hpp_b.DefaultCellStyle = DataGridViewCellStyle2
        Me.hpp_b.HeaderText = "HPP Tujuan"
        Me.hpp_b.Name = "hpp_b"
        Me.hpp_b.ReadOnly = True
        '
        'in_gudang_n
        '
        Me.in_gudang_n.BackColor = System.Drawing.Color.White
        Me.in_gudang_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang_n.ForeColor = System.Drawing.Color.Black
        Me.in_gudang_n.Location = New System.Drawing.Point(449, 34)
        Me.in_gudang_n.MaxLength = 200
        Me.in_gudang_n.Name = "in_gudang_n"
        Me.in_gudang_n.ReadOnly = True
        Me.in_gudang_n.Size = New System.Drawing.Size(293, 20)
        Me.in_gudang_n.TabIndex = 3
        '
        'in_gudang
        '
        Me.in_gudang.BackColor = System.Drawing.Color.Gainsboro
        Me.in_gudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang.ForeColor = System.Drawing.Color.Black
        Me.in_gudang.Location = New System.Drawing.Point(325, 34)
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(263, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 256
        Me.Label3.Text = "Gudang"
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
        Me.dgv_list.Size = New System.Drawing.Size(964, 224)
        Me.dgv_list.TabIndex = 17
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Orange
        Me.Panel4.Controls.Add(Me.in_countdata)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.in_cari)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 224)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(964, 42)
        Me.Panel4.TabIndex = 248
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
        Me.in_countdata.TabIndex = 19
        Me.in_countdata.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 26)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Pencarian :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(CTRL+F)"
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
        'fr_stok_mutasibarang_list
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "fr_stok_mutasibarang_list"
        Me.Size = New System.Drawing.Size(964, 575)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_Menu.ResumeLayout(False)
        Me.pnl_Menu.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents date_tgl_beli_r As System.Windows.Forms.TextBox
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnl_Menu As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_tambah As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_hapus As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_refresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgv_list As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents in_countdata As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents in_cari As System.Windows.Forms.TextBox
    Friend WithEvents mn_cari As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgv_barang As System.Windows.Forms.DataGridView
    Friend WithEvents in_gudang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents in_status As System.Windows.Forms.TextBox
    Friend WithEvents kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_a As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_a As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hpp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kode_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nama_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hpp_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents in_kat As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
