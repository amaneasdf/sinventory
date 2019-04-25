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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_stok_mutasi))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.linkLbl_searchbarang = New System.Windows.Forms.LinkLabel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.cb_pajak = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
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
        Me.in_hpp = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.in_gudang2_n = New System.Windows.Forms.TextBox()
        Me.in_gudang2 = New System.Windows.Forms.TextBox()
        Me.in_gudang_n = New System.Windows.Forms.TextBox()
        Me.in_gudang = New System.Windows.Forms.TextBox()
        Me.bt_tbbarang = New System.Windows.Forms.Button()
        Me.in_sat3 = New System.Windows.Forms.TextBox()
        Me.in_sat2 = New System.Windows.Forms.TextBox()
        Me.in_sat1 = New System.Windows.Forms.TextBox()
        Me.in_barang = New System.Windows.Forms.TextBox()
        Me.in_barang_nm = New System.Windows.Forms.TextBox()
        Me.in_qty3 = New System.Windows.Forms.NumericUpDown()
        Me.in_qty2 = New System.Windows.Forms.NumericUpDown()
        Me.in_qty1 = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.date_tgl_beli = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_print = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_proses = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnl_footer = New System.Windows.Forms.Panel()
        Me.bt_simpanbeli = New System.Windows.Forms.Button()
        Me.bt_batalbeli = New System.Windows.Forms.Button()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.pnl_content.SuspendLayout()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.pnl_footer.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 510)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(874, 10)
        Me.Panel2.TabIndex = 284
        '
        'pnl_content
        '
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.Controls.Add(Me.popPnl_barang)
        Me.pnl_content.Controls.Add(Me.Label10)
        Me.pnl_content.Controls.Add(Me.in_ket)
        Me.pnl_content.Controls.Add(Me.cb_pajak)
        Me.pnl_content.Controls.Add(Me.Label18)
        Me.pnl_content.Controls.Add(Me.Label13)
        Me.pnl_content.Controls.Add(Me.in_status)
        Me.pnl_content.Controls.Add(Me.dgv_barang)
        Me.pnl_content.Controls.Add(Me.in_hpp)
        Me.pnl_content.Controls.Add(Me.Label9)
        Me.pnl_content.Controls.Add(Me.in_gudang2_n)
        Me.pnl_content.Controls.Add(Me.in_gudang2)
        Me.pnl_content.Controls.Add(Me.in_gudang_n)
        Me.pnl_content.Controls.Add(Me.in_gudang)
        Me.pnl_content.Controls.Add(Me.bt_tbbarang)
        Me.pnl_content.Controls.Add(Me.in_sat3)
        Me.pnl_content.Controls.Add(Me.in_sat2)
        Me.pnl_content.Controls.Add(Me.in_sat1)
        Me.pnl_content.Controls.Add(Me.in_barang)
        Me.pnl_content.Controls.Add(Me.in_barang_nm)
        Me.pnl_content.Controls.Add(Me.in_qty3)
        Me.pnl_content.Controls.Add(Me.in_qty2)
        Me.pnl_content.Controls.Add(Me.in_qty1)
        Me.pnl_content.Controls.Add(Me.Label8)
        Me.pnl_content.Controls.Add(Me.Label6)
        Me.pnl_content.Controls.Add(Me.date_tgl_beli)
        Me.pnl_content.Controls.Add(Me.Label21)
        Me.pnl_content.Controls.Add(Me.Label4)
        Me.pnl_content.Controls.Add(Me.Label20)
        Me.pnl_content.Controls.Add(Me.Label1)
        Me.pnl_content.Controls.Add(Me.Label16)
        Me.pnl_content.Controls.Add(Me.Label3)
        Me.pnl_content.Controls.Add(Me.in_kode)
        Me.pnl_content.Controls.Add(Me.Label5)
        Me.pnl_content.Controls.Add(Me.Label29)
        Me.pnl_content.Controls.Add(Me.txtRegdate)
        Me.pnl_content.Controls.Add(Me.Label28)
        Me.pnl_content.Controls.Add(Me.Label30)
        Me.pnl_content.Controls.Add(Me.Label27)
        Me.pnl_content.Controls.Add(Me.txtUpdAlias)
        Me.pnl_content.Controls.Add(Me.txtUpdDate)
        Me.pnl_content.Controls.Add(Me.txtRegAlias)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Location = New System.Drawing.Point(0, 66)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(874, 394)
        Me.pnl_content.TabIndex = 0
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Controls.Add(Me.linkLbl_searchbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(103, 173)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(362, 135)
        Me.popPnl_barang.TabIndex = 453
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
        Me.dgv_listbarang.Size = New System.Drawing.Size(362, 127)
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
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label10.Location = New System.Drawing.Point(9, 311)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 514
        Me.Label10.Text = "Keterangan"
        '
        'in_ket
        '
        Me.in_ket.BackColor = System.Drawing.Color.White
        Me.in_ket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.ForeColor = System.Drawing.Color.Black
        Me.in_ket.Location = New System.Drawing.Point(12, 327)
        Me.in_ket.MaxLength = 30
        Me.in_ket.Multiline = True
        Me.in_ket.Name = "in_ket"
        Me.in_ket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_ket.Size = New System.Drawing.Size(330, 64)
        Me.in_ket.TabIndex = 19
        '
        'cb_pajak
        '
        Me.cb_pajak.BackColor = System.Drawing.Color.White
        Me.cb_pajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_pajak.ForeColor = System.Drawing.Color.Black
        Me.cb_pajak.FormattingEnabled = True
        Me.cb_pajak.Location = New System.Drawing.Point(345, 10)
        Me.cb_pajak.Name = "cb_pajak"
        Me.cb_pajak.Size = New System.Drawing.Size(151, 21)
        Me.cb_pajak.TabIndex = 2
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(261, 14)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 13)
        Me.Label18.TabIndex = 512
        Me.Label18.Text = "Kategori"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(718, 11)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 457
        Me.Label13.Text = "Status"
        '
        'in_status
        '
        Me.in_status.BackColor = System.Drawing.Color.White
        Me.in_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status.ForeColor = System.Drawing.Color.Black
        Me.in_status.Location = New System.Drawing.Point(761, 7)
        Me.in_status.Name = "in_status"
        Me.in_status.ReadOnly = True
        Me.in_status.Size = New System.Drawing.Size(106, 20)
        Me.in_status.TabIndex = 7
        Me.in_status.TabStop = False
        '
        'dgv_barang
        '
        Me.dgv_barang.AllowUserToAddRows = False
        Me.dgv_barang.AllowUserToDeleteRows = False
        Me.dgv_barang.BackgroundColor = System.Drawing.Color.White
        Me.dgv_barang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kode, Me.nama, Me.qty_b, Me.sat_b, Me.qty_t, Me.sat_t, Me.qty_k, Me.sat_k, Me.qty_tot, Me.hpp_brg})
        Me.dgv_barang.Location = New System.Drawing.Point(12, 119)
        Me.dgv_barang.MultiSelect = False
        Me.dgv_barang.Name = "dgv_barang"
        Me.dgv_barang.ReadOnly = True
        Me.dgv_barang.RowHeadersVisible = False
        Me.dgv_barang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_barang.Size = New System.Drawing.Size(855, 189)
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
        Me.hpp_brg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        Me.hpp_brg.DefaultCellStyle = DataGridViewCellStyle2
        Me.hpp_brg.HeaderText = "HPP"
        Me.hpp_brg.Name = "hpp_brg"
        Me.hpp_brg.ReadOnly = True
        '
        'in_hpp
        '
        Me.in_hpp.BackColor = System.Drawing.Color.White
        Me.in_hpp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_hpp.ForeColor = System.Drawing.Color.Black
        Me.in_hpp.Location = New System.Drawing.Point(664, 95)
        Me.in_hpp.MaxLength = 150
        Me.in_hpp.Name = "in_hpp"
        Me.in_hpp.ReadOnly = True
        Me.in_hpp.Size = New System.Drawing.Size(154, 20)
        Me.in_hpp.TabIndex = 16
        Me.in_hpp.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(661, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 455
        Me.Label9.Text = "HPP"
        '
        'in_gudang2_n
        '
        Me.in_gudang2_n.BackColor = System.Drawing.Color.White
        Me.in_gudang2_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang2_n.ForeColor = System.Drawing.Color.Black
        Me.in_gudang2_n.Location = New System.Drawing.Point(439, 53)
        Me.in_gudang2_n.MaxLength = 200
        Me.in_gudang2_n.Name = "in_gudang2_n"
        Me.in_gudang2_n.ReadOnly = True
        Me.in_gudang2_n.Size = New System.Drawing.Size(254, 20)
        Me.in_gudang2_n.TabIndex = 6
        '
        'in_gudang2
        '
        Me.in_gudang2.BackColor = System.Drawing.Color.Gainsboro
        Me.in_gudang2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang2.ForeColor = System.Drawing.Color.Black
        Me.in_gudang2.Location = New System.Drawing.Point(345, 53)
        Me.in_gudang2.MaxLength = 30
        Me.in_gudang2.Name = "in_gudang2"
        Me.in_gudang2.ReadOnly = True
        Me.in_gudang2.Size = New System.Drawing.Size(93, 20)
        Me.in_gudang2.TabIndex = 5
        '
        'in_gudang_n
        '
        Me.in_gudang_n.BackColor = System.Drawing.Color.White
        Me.in_gudang_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang_n.ForeColor = System.Drawing.Color.Black
        Me.in_gudang_n.Location = New System.Drawing.Point(439, 32)
        Me.in_gudang_n.MaxLength = 200
        Me.in_gudang_n.Name = "in_gudang_n"
        Me.in_gudang_n.ReadOnly = True
        Me.in_gudang_n.Size = New System.Drawing.Size(254, 20)
        Me.in_gudang_n.TabIndex = 4
        '
        'in_gudang
        '
        Me.in_gudang.BackColor = System.Drawing.Color.Gainsboro
        Me.in_gudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang.ForeColor = System.Drawing.Color.Black
        Me.in_gudang.Location = New System.Drawing.Point(345, 32)
        Me.in_gudang.MaxLength = 30
        Me.in_gudang.Name = "in_gudang"
        Me.in_gudang.ReadOnly = True
        Me.in_gudang.Size = New System.Drawing.Size(93, 20)
        Me.in_gudang.TabIndex = 3
        '
        'bt_tbbarang
        '
        Me.bt_tbbarang.BackColor = System.Drawing.Color.Transparent
        Me.bt_tbbarang.BackgroundImage = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.bt_tbbarang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_tbbarang.FlatAppearance.BorderSize = 0
        Me.bt_tbbarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_tbbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tbbarang.Location = New System.Drawing.Point(824, 95)
        Me.bt_tbbarang.Name = "bt_tbbarang"
        Me.bt_tbbarang.Size = New System.Drawing.Size(18, 18)
        Me.bt_tbbarang.TabIndex = 17
        Me.bt_tbbarang.UseVisualStyleBackColor = False
        '
        'in_sat3
        '
        Me.in_sat3.BackColor = System.Drawing.Color.White
        Me.in_sat3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sat3.Location = New System.Drawing.Point(606, 95)
        Me.in_sat3.Name = "in_sat3"
        Me.in_sat3.ReadOnly = True
        Me.in_sat3.Size = New System.Drawing.Size(55, 20)
        Me.in_sat3.TabIndex = 15
        Me.in_sat3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_sat2
        '
        Me.in_sat2.BackColor = System.Drawing.Color.White
        Me.in_sat2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sat2.Location = New System.Drawing.Point(485, 95)
        Me.in_sat2.Name = "in_sat2"
        Me.in_sat2.ReadOnly = True
        Me.in_sat2.Size = New System.Drawing.Size(55, 20)
        Me.in_sat2.TabIndex = 13
        Me.in_sat2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_sat1
        '
        Me.in_sat1.BackColor = System.Drawing.Color.White
        Me.in_sat1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sat1.Location = New System.Drawing.Point(365, 95)
        Me.in_sat1.Name = "in_sat1"
        Me.in_sat1.ReadOnly = True
        Me.in_sat1.Size = New System.Drawing.Size(55, 20)
        Me.in_sat1.TabIndex = 11
        Me.in_sat1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_barang
        '
        Me.in_barang.BackColor = System.Drawing.Color.Gainsboro
        Me.in_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang.Location = New System.Drawing.Point(12, 95)
        Me.in_barang.MaxLength = 20
        Me.in_barang.Name = "in_barang"
        Me.in_barang.ReadOnly = True
        Me.in_barang.Size = New System.Drawing.Size(100, 20)
        Me.in_barang.TabIndex = 8
        Me.in_barang.TabStop = False
        '
        'in_barang_nm
        '
        Me.in_barang_nm.BackColor = System.Drawing.Color.White
        Me.in_barang_nm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang_nm.ForeColor = System.Drawing.Color.Black
        Me.in_barang_nm.Location = New System.Drawing.Point(112, 95)
        Me.in_barang_nm.MaxLength = 150
        Me.in_barang_nm.Name = "in_barang_nm"
        Me.in_barang_nm.Size = New System.Drawing.Size(188, 20)
        Me.in_barang_nm.TabIndex = 9
        '
        'in_qty3
        '
        Me.in_qty3.BackColor = System.Drawing.Color.White
        Me.in_qty3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty3.Location = New System.Drawing.Point(543, 95)
        Me.in_qty3.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.in_qty3.Name = "in_qty3"
        Me.in_qty3.Size = New System.Drawing.Size(64, 20)
        Me.in_qty3.TabIndex = 14
        Me.in_qty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_qty2
        '
        Me.in_qty2.BackColor = System.Drawing.Color.White
        Me.in_qty2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty2.Location = New System.Drawing.Point(422, 95)
        Me.in_qty2.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.in_qty2.Name = "in_qty2"
        Me.in_qty2.Size = New System.Drawing.Size(64, 20)
        Me.in_qty2.TabIndex = 12
        Me.in_qty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_qty1
        '
        Me.in_qty1.BackColor = System.Drawing.Color.White
        Me.in_qty1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty1.Location = New System.Drawing.Point(302, 95)
        Me.in_qty1.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.in_qty1.Name = "in_qty1"
        Me.in_qty1.Size = New System.Drawing.Size(64, 20)
        Me.in_qty1.TabIndex = 10
        Me.in_qty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(540, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 447
        Me.Label8.Text = "Qty Kecil"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.Location = New System.Drawing.Point(419, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 448
        Me.Label6.Text = "Qty Tengah"
        '
        'date_tgl_beli
        '
        Me.date_tgl_beli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_beli.Location = New System.Drawing.Point(72, 32)
        Me.date_tgl_beli.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_beli.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_beli.Name = "date_tgl_beli"
        Me.date_tgl_beli.Size = New System.Drawing.Size(172, 20)
        Me.date_tgl_beli.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label21.Location = New System.Drawing.Point(299, 79)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 13)
        Me.Label21.TabIndex = 449
        Me.Label21.Text = "Qty Besar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 452
        Me.Label4.Text = "Tanggal"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label20.Location = New System.Drawing.Point(107, 79)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 13)
        Me.Label20.TabIndex = 450
        Me.Label20.Text = "Nama Barang"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(261, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 444
        Me.Label1.Text = "Gudang Tujuan"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(9, 79)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 445
        Me.Label16.Text = "Kode"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(261, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 446
        Me.Label3.Text = "Gudang Asal"
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.White
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.Location = New System.Drawing.Point(72, 10)
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
        Me.Label5.Location = New System.Drawing.Point(9, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 451
        Me.Label5.Text = "No. Bukti"
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
        Me.Panel1.Size = New System.Drawing.Size(874, 42)
        Me.Panel1.TabIndex = 282
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(794, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(847, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 8
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
        Me.lbl_title.Size = New System.Drawing.Size(138, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Mutasi Stok"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_print, Me.mn_proses, Me.mn_cancel})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 42)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(874, 24)
        Me.MenuStrip1.TabIndex = 285
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
        'mn_proses
        '
        Me.mn_proses.Image = Global.Inventory.My.Resources.Resources.toolbar_cancel_icon
        Me.mn_proses.Name = "mn_proses"
        Me.mn_proses.Size = New System.Drawing.Size(69, 20)
        Me.mn_proses.Text = "Proses"
        Me.mn_proses.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.mn_proses.Visible = False
        '
        'mn_cancel
        '
        Me.mn_cancel.Name = "mn_cancel"
        Me.mn_cancel.Size = New System.Drawing.Size(103, 20)
        Me.mn_cancel.Text = "Batalkan Mutasi"
        '
        'pnl_footer
        '
        Me.pnl_footer.AutoScroll = True
        Me.pnl_footer.BackColor = System.Drawing.Color.Gainsboro
        Me.pnl_footer.Controls.Add(Me.bt_simpanbeli)
        Me.pnl_footer.Controls.Add(Me.bt_batalbeli)
        Me.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_footer.Location = New System.Drawing.Point(0, 460)
        Me.pnl_footer.Name = "pnl_footer"
        Me.pnl_footer.Size = New System.Drawing.Size(874, 50)
        Me.pnl_footer.TabIndex = 24
        '
        'bt_simpanbeli
        '
        Me.bt_simpanbeli.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpanbeli.FlatAppearance.BorderSize = 0
        Me.bt_simpanbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpanbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbeli.ForeColor = System.Drawing.Color.White
        Me.bt_simpanbeli.Location = New System.Drawing.Point(594, 14)
        Me.bt_simpanbeli.Name = "bt_simpanbeli"
        Me.bt_simpanbeli.Size = New System.Drawing.Size(171, 30)
        Me.bt_simpanbeli.TabIndex = 25
        Me.bt_simpanbeli.Text = "Simpan"
        Me.bt_simpanbeli.UseVisualStyleBackColor = False
        '
        'bt_batalbeli
        '
        Me.bt_batalbeli.BackColor = System.Drawing.Color.Tomato
        Me.bt_batalbeli.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalbeli.FlatAppearance.BorderSize = 0
        Me.bt_batalbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_batalbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalbeli.ForeColor = System.Drawing.Color.White
        Me.bt_batalbeli.Location = New System.Drawing.Point(771, 14)
        Me.bt_batalbeli.Name = "bt_batalbeli"
        Me.bt_batalbeli.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalbeli.TabIndex = 26
        Me.bt_batalbeli.Text = "Batal"
        Me.bt_batalbeli.UseVisualStyleBackColor = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(737, 347)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(130, 20)
        Me.txtRegAlias.TabIndex = 21
        Me.txtRegAlias.TabStop = False
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(532, 371)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(177, 20)
        Me.txtUpdDate.TabIndex = 22
        Me.txtUpdDate.TabStop = False
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(737, 371)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(130, 20)
        Me.txtUpdAlias.TabIndex = 23
        Me.txtUpdAlias.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(714, 351)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(19, 13)
        Me.Label27.TabIndex = 422
        Me.Label27.Text = "By"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(714, 375)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(19, 13)
        Me.Label30.TabIndex = 424
        Me.Label30.Text = "By"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(465, 375)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(62, 13)
        Me.Label28.TabIndex = 425
        Me.Label28.Text = "LastUpdate"
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(532, 347)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(177, 20)
        Me.txtRegdate.TabIndex = 20
        Me.txtRegdate.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(465, 350)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(43, 13)
        Me.Label29.TabIndex = 421
        Me.Label29.Text = "Inputed"
        '
        'fr_stok_mutasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(874, 520)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.pnl_footer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_stok_mutasi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mutasi Stok : "
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.popPnl_barang.ResumeLayout(False)
        Me.popPnl_barang.PerformLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_qty3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_qty2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_qty1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.pnl_footer.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_proses As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnl_footer As System.Windows.Forms.Panel
    Friend WithEvents bt_simpanbeli As System.Windows.Forms.Button
    Friend WithEvents bt_batalbeli As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents in_status As System.Windows.Forms.TextBox
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents linkLbl_searchbarang As System.Windows.Forms.LinkLabel
    Friend WithEvents dgv_barang As System.Windows.Forms.DataGridView
    Friend WithEvents in_hpp As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents in_gudang2_n As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang2 As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang As System.Windows.Forms.TextBox
    Friend WithEvents bt_tbbarang As System.Windows.Forms.Button
    Friend WithEvents in_sat3 As System.Windows.Forms.TextBox
    Friend WithEvents in_sat2 As System.Windows.Forms.TextBox
    Friend WithEvents in_sat1 As System.Windows.Forms.TextBox
    Friend WithEvents in_barang As System.Windows.Forms.TextBox
    Friend WithEvents in_barang_nm As System.Windows.Forms.TextBox
    Friend WithEvents in_qty3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_qty2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_qty1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents date_tgl_beli As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cb_pajak As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents mn_cancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
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
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
End Class
