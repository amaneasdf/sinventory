<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_urut_kartustok
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.dgv_barang = New System.Windows.Forms.DataGridView()
        Me.brg_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brg_kategori = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brg_n = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv_gudang = New System.Windows.Forms.DataGridView()
        Me.sales_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sales_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv_kartustok = New System.Windows.Forms.DataGridView()
        Me.kartu_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kartu_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kartu_ket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kartu_ket2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kartu_debet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kartu_kredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kartu_saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bt_cari_gudang = New System.Windows.Forms.Button()
        Me.in_cari_gudang = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_cari_barang = New System.Windows.Forms.TextBox()
        Me.bt_cari_barang = New System.Windows.Forms.Button()
        Me.bt_load_kartu = New System.Windows.Forms.Button()
        Me.in_kode_stok = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_refresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.bt_down = New System.Windows.Forms.Button()
        Me.bt_up = New System.Windows.Forms.Button()
        Me.bt_save = New System.Windows.Forms.Button()
        Me.in_gudang_n = New System.Windows.Forms.TextBox()
        Me.in_barang_n = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_gudang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_kartustok, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(918, 42)
        Me.Panel1.TabIndex = 250
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(838, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(891, 9)
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
        Me.lbl_title.Size = New System.Drawing.Size(263, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Urutkan Transaksi Stok"
        '
        'dgv_barang
        '
        Me.dgv_barang.AllowUserToAddRows = False
        Me.dgv_barang.AllowUserToDeleteRows = False
        Me.dgv_barang.BackgroundColor = System.Drawing.Color.White
        Me.dgv_barang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_barang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.brg_kode, Me.brg_kategori, Me.brg_n})
        Me.dgv_barang.Location = New System.Drawing.Point(385, 100)
        Me.dgv_barang.MultiSelect = False
        Me.dgv_barang.Name = "dgv_barang"
        Me.dgv_barang.ReadOnly = True
        Me.dgv_barang.RowHeadersVisible = False
        Me.dgv_barang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_barang.Size = New System.Drawing.Size(455, 145)
        Me.dgv_barang.TabIndex = 5
        '
        'brg_kode
        '
        Me.brg_kode.DataPropertyName = "kode"
        Me.brg_kode.HeaderText = "Kode"
        Me.brg_kode.MinimumWidth = 75
        Me.brg_kode.Name = "brg_kode"
        Me.brg_kode.ReadOnly = True
        Me.brg_kode.Width = 125
        '
        'brg_kategori
        '
        Me.brg_kategori.HeaderText = "Kategori"
        Me.brg_kategori.Name = "brg_kategori"
        Me.brg_kategori.ReadOnly = True
        '
        'brg_n
        '
        Me.brg_n.DataPropertyName = "nama"
        Me.brg_n.HeaderText = "Nama"
        Me.brg_n.MinimumWidth = 125
        Me.brg_n.Name = "brg_n"
        Me.brg_n.ReadOnly = True
        Me.brg_n.Width = 225
        '
        'dgv_gudang
        '
        Me.dgv_gudang.AllowUserToAddRows = False
        Me.dgv_gudang.AllowUserToDeleteRows = False
        Me.dgv_gudang.BackgroundColor = System.Drawing.Color.White
        Me.dgv_gudang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_gudang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sales_kode, Me.sales_nama})
        Me.dgv_gudang.Location = New System.Drawing.Point(11, 100)
        Me.dgv_gudang.MultiSelect = False
        Me.dgv_gudang.Name = "dgv_gudang"
        Me.dgv_gudang.ReadOnly = True
        Me.dgv_gudang.RowHeadersVisible = False
        Me.dgv_gudang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_gudang.Size = New System.Drawing.Size(359, 145)
        Me.dgv_gudang.TabIndex = 2
        '
        'sales_kode
        '
        Me.sales_kode.DataPropertyName = "kode"
        Me.sales_kode.HeaderText = "Kode"
        Me.sales_kode.MinimumWidth = 75
        Me.sales_kode.Name = "sales_kode"
        Me.sales_kode.ReadOnly = True
        '
        'sales_nama
        '
        Me.sales_nama.DataPropertyName = "nama"
        Me.sales_nama.HeaderText = "Nama"
        Me.sales_nama.MinimumWidth = 150
        Me.sales_nama.Name = "sales_nama"
        Me.sales_nama.ReadOnly = True
        Me.sales_nama.Width = 225
        '
        'dgv_kartustok
        '
        Me.dgv_kartustok.AllowUserToAddRows = False
        Me.dgv_kartustok.AllowUserToDeleteRows = False
        Me.dgv_kartustok.BackgroundColor = System.Drawing.Color.White
        Me.dgv_kartustok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_kartustok.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kartu_tgl, Me.kartu_faktur, Me.kartu_ket, Me.kartu_ket2, Me.kartu_debet, Me.kartu_kredit, Me.kartu_saldo})
        Me.dgv_kartustok.Location = New System.Drawing.Point(11, 277)
        Me.dgv_kartustok.MultiSelect = False
        Me.dgv_kartustok.Name = "dgv_kartustok"
        Me.dgv_kartustok.RowHeadersVisible = False
        Me.dgv_kartustok.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_kartustok.Size = New System.Drawing.Size(857, 208)
        Me.dgv_kartustok.TabIndex = 8
        '
        'kartu_tgl
        '
        Me.kartu_tgl.HeaderText = "Tanggal"
        Me.kartu_tgl.MinimumWidth = 50
        Me.kartu_tgl.Name = "kartu_tgl"
        Me.kartu_tgl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.kartu_tgl.Width = 75
        '
        'kartu_faktur
        '
        Me.kartu_faktur.DataPropertyName = "kode"
        Me.kartu_faktur.HeaderText = "No.Faktur"
        Me.kartu_faktur.Name = "kartu_faktur"
        Me.kartu_faktur.ReadOnly = True
        Me.kartu_faktur.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'kartu_ket
        '
        Me.kartu_ket.HeaderText = "Keterangan"
        Me.kartu_ket.MinimumWidth = 100
        Me.kartu_ket.Name = "kartu_ket"
        Me.kartu_ket.ReadOnly = True
        Me.kartu_ket.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.kartu_ket.Width = 200
        '
        'kartu_ket2
        '
        Me.kartu_ket2.HeaderText = "Nama"
        Me.kartu_ket2.Name = "kartu_ket2"
        Me.kartu_ket2.ReadOnly = True
        Me.kartu_ket2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.kartu_ket2.Width = 200
        '
        'kartu_debet
        '
        Me.kartu_debet.HeaderText = "Debet"
        Me.kartu_debet.Name = "kartu_debet"
        Me.kartu_debet.ReadOnly = True
        Me.kartu_debet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.kartu_debet.Width = 75
        '
        'kartu_kredit
        '
        Me.kartu_kredit.HeaderText = "Kredit"
        Me.kartu_kredit.Name = "kartu_kredit"
        Me.kartu_kredit.ReadOnly = True
        Me.kartu_kredit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.kartu_kredit.Width = 75
        '
        'kartu_saldo
        '
        Me.kartu_saldo.HeaderText = "Saldo"
        Me.kartu_saldo.Name = "kartu_saldo"
        Me.kartu_saldo.ReadOnly = True
        Me.kartu_saldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'bt_cari_gudang
        '
        Me.bt_cari_gudang.Location = New System.Drawing.Point(282, 77)
        Me.bt_cari_gudang.Name = "bt_cari_gudang"
        Me.bt_cari_gudang.Size = New System.Drawing.Size(38, 20)
        Me.bt_cari_gudang.TabIndex = 1
        Me.bt_cari_gudang.Text = "Cari"
        Me.bt_cari_gudang.UseVisualStyleBackColor = True
        '
        'in_cari_gudang
        '
        Me.in_cari_gudang.BackColor = System.Drawing.Color.White
        Me.in_cari_gudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari_gudang.ForeColor = System.Drawing.Color.Black
        Me.in_cari_gudang.Location = New System.Drawing.Point(65, 77)
        Me.in_cari_gudang.MaxLength = 30
        Me.in_cari_gudang.Name = "in_cari_gudang"
        Me.in_cari_gudang.Size = New System.Drawing.Size(211, 20)
        Me.in_cari_gudang.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 280
        Me.Label5.Text = "Gudang"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(382, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 280
        Me.Label1.Text = "Barang"
        '
        'in_cari_barang
        '
        Me.in_cari_barang.BackColor = System.Drawing.Color.White
        Me.in_cari_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari_barang.ForeColor = System.Drawing.Color.Black
        Me.in_cari_barang.Location = New System.Drawing.Point(439, 77)
        Me.in_cari_barang.MaxLength = 30
        Me.in_cari_barang.Name = "in_cari_barang"
        Me.in_cari_barang.Size = New System.Drawing.Size(211, 20)
        Me.in_cari_barang.TabIndex = 3
        '
        'bt_cari_barang
        '
        Me.bt_cari_barang.Location = New System.Drawing.Point(656, 77)
        Me.bt_cari_barang.Name = "bt_cari_barang"
        Me.bt_cari_barang.Size = New System.Drawing.Size(38, 20)
        Me.bt_cari_barang.TabIndex = 4
        Me.bt_cari_barang.Text = "Cari"
        Me.bt_cari_barang.UseVisualStyleBackColor = True
        '
        'bt_load_kartu
        '
        Me.bt_load_kartu.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_load_kartu.Location = New System.Drawing.Point(846, 100)
        Me.bt_load_kartu.Name = "bt_load_kartu"
        Me.bt_load_kartu.Size = New System.Drawing.Size(55, 55)
        Me.bt_load_kartu.TabIndex = 6
        Me.bt_load_kartu.Text = "Load"
        Me.bt_load_kartu.UseVisualStyleBackColor = True
        '
        'in_kode_stok
        '
        Me.in_kode_stok.BackColor = System.Drawing.Color.White
        Me.in_kode_stok.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode_stok.ForeColor = System.Drawing.Color.Black
        Me.in_kode_stok.Location = New System.Drawing.Point(11, 251)
        Me.in_kode_stok.MaxLength = 30
        Me.in_kode_stok.Name = "in_kode_stok"
        Me.in_kode_stok.ReadOnly = True
        Me.in_kode_stok.Size = New System.Drawing.Size(211, 20)
        Me.in_kode_stok.TabIndex = 7
        Me.in_kode_stok.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_refresh})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 42)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(918, 24)
        Me.MenuStrip1.TabIndex = 283
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mn_refresh
        '
        Me.mn_refresh.Name = "mn_refresh"
        Me.mn_refresh.Size = New System.Drawing.Size(58, 20)
        Me.mn_refresh.Text = "Refresh"
        '
        'bt_down
        '
        Me.bt_down.Image = Global.Inventory.My.Resources.Resources.DnArrow
        Me.bt_down.Location = New System.Drawing.Point(874, 379)
        Me.bt_down.Name = "bt_down"
        Me.bt_down.Size = New System.Drawing.Size(27, 85)
        Me.bt_down.TabIndex = 285
        Me.bt_down.UseVisualStyleBackColor = True
        '
        'bt_up
        '
        Me.bt_up.Image = Global.Inventory.My.Resources.Resources.UpArrow
        Me.bt_up.Location = New System.Drawing.Point(874, 290)
        Me.bt_up.Name = "bt_up"
        Me.bt_up.Size = New System.Drawing.Size(27, 85)
        Me.bt_up.TabIndex = 286
        Me.bt_up.UseVisualStyleBackColor = True
        '
        'bt_save
        '
        Me.bt_save.Location = New System.Drawing.Point(680, 491)
        Me.bt_save.Name = "bt_save"
        Me.bt_save.Size = New System.Drawing.Size(188, 27)
        Me.bt_save.TabIndex = 6
        Me.bt_save.Text = "Simpan"
        Me.bt_save.UseVisualStyleBackColor = True
        '
        'in_gudang_n
        '
        Me.in_gudang_n.BackColor = System.Drawing.Color.White
        Me.in_gudang_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang_n.ForeColor = System.Drawing.Color.Black
        Me.in_gudang_n.Location = New System.Drawing.Point(228, 251)
        Me.in_gudang_n.MaxLength = 30
        Me.in_gudang_n.Name = "in_gudang_n"
        Me.in_gudang_n.ReadOnly = True
        Me.in_gudang_n.Size = New System.Drawing.Size(215, 20)
        Me.in_gudang_n.TabIndex = 8
        Me.in_gudang_n.TabStop = False
        '
        'in_barang_n
        '
        Me.in_barang_n.BackColor = System.Drawing.Color.White
        Me.in_barang_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang_n.ForeColor = System.Drawing.Color.Black
        Me.in_barang_n.Location = New System.Drawing.Point(449, 251)
        Me.in_barang_n.MaxLength = 30
        Me.in_barang_n.Name = "in_barang_n"
        Me.in_barang_n.ReadOnly = True
        Me.in_barang_n.Size = New System.Drawing.Size(391, 20)
        Me.in_barang_n.TabIndex = 9
        Me.in_barang_n.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(846, 249)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 22)
        Me.Button1.TabIndex = 287
        Me.Button1.Text = ">>"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'fr_urut_kartustok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.bt_down)
        Me.Controls.Add(Me.bt_up)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.in_barang_n)
        Me.Controls.Add(Me.in_gudang_n)
        Me.Controls.Add(Me.in_kode_stok)
        Me.Controls.Add(Me.bt_save)
        Me.Controls.Add(Me.bt_load_kartu)
        Me.Controls.Add(Me.bt_cari_barang)
        Me.Controls.Add(Me.bt_cari_gudang)
        Me.Controls.Add(Me.in_cari_barang)
        Me.Controls.Add(Me.in_cari_gudang)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgv_kartustok)
        Me.Controls.Add(Me.dgv_barang)
        Me.Controls.Add(Me.dgv_gudang)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "fr_urut_kartustok"
        Me.Size = New System.Drawing.Size(918, 531)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_gudang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_kartustok, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents dgv_barang As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_gudang As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_kartustok As System.Windows.Forms.DataGridView
    Friend WithEvents bt_cari_gudang As System.Windows.Forms.Button
    Friend WithEvents in_cari_gudang As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_cari_barang As System.Windows.Forms.TextBox
    Friend WithEvents bt_cari_barang As System.Windows.Forms.Button
    Friend WithEvents bt_load_kartu As System.Windows.Forms.Button
    Friend WithEvents in_kode_stok As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_refresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bt_down As System.Windows.Forms.Button
    Friend WithEvents bt_up As System.Windows.Forms.Button
    Friend WithEvents bt_save As System.Windows.Forms.Button
    Friend WithEvents sales_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brg_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brg_kategori As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brg_n As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents in_gudang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_barang_n As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents kartu_tgl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kartu_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kartu_ket As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kartu_ket2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kartu_debet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kartu_kredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kartu_saldo As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
