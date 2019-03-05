<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_lap_filter_jual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_lap_filter_jual))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.bt_exportxl = New System.Windows.Forms.Button()
        Me.bt_batalbeli = New System.Windows.Forms.Button()
        Me.bt_simpanbeli = New System.Windows.Forms.Button()
        Me.in_custo_n = New System.Windows.Forms.TextBox()
        Me.in_custo = New System.Windows.Forms.TextBox()
        Me.lbl_custo = New System.Windows.Forms.Label()
        Me.in_sales_n = New System.Windows.Forms.TextBox()
        Me.in_sales = New System.Windows.Forms.TextBox()
        Me.lbl_sales = New System.Windows.Forms.Label()
        Me.lbl_tgl2 = New System.Windows.Forms.Label()
        Me.date_tglakhir = New System.Windows.Forms.DateTimePicker()
        Me.lbl_tgl = New System.Windows.Forms.Label()
        Me.date_tglawal = New System.Windows.Forms.DateTimePicker()
        Me.cb_jenis = New System.Windows.Forms.ComboBox()
        Me.lbl_jenis = New System.Windows.Forms.Label()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.in_barang_n = New System.Windows.Forms.TextBox()
        Me.in_barang = New System.Windows.Forms.TextBox()
        Me.lbl_barang = New System.Windows.Forms.Label()
        Me.lbl_pajak = New System.Windows.Forms.Label()
        Me.cb_pajak = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 280)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(591, 10)
        Me.Panel3.TabIndex = 412
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
        Me.Panel1.Size = New System.Drawing.Size(591, 30)
        Me.Panel1.TabIndex = 411
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(511, 4)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(52, 22)
        Me.lbl_close.TabIndex = 138
        Me.lbl_close.Text = "Close"
        Me.lbl_close.Visible = False
        '
        'bt_cl
        '
        Me.bt_cl.BackColor = System.Drawing.Color.Transparent
        Me.bt_cl.BackgroundImage = Global.Inventory.My.Resources.Resources.close
        Me.bt_cl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_cl.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_cl.FlatAppearance.BorderSize = 0
        Me.bt_cl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange
        Me.bt_cl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange
        Me.bt_cl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cl.Location = New System.Drawing.Point(564, 5)
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
        Me.lbl_title.Font = New System.Drawing.Font("Open Sans", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(5, 3)
        Me.lbl_title.MaximumSize = New System.Drawing.Size(490, 33)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(138, 19)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Laporan Penjualan"
        '
        'bt_exportxl
        '
        Me.bt_exportxl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_exportxl.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_exportxl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_exportxl.Location = New System.Drawing.Point(11, 244)
        Me.bt_exportxl.Name = "bt_exportxl"
        Me.bt_exportxl.Size = New System.Drawing.Size(96, 30)
        Me.bt_exportxl.TabIndex = 415
        Me.bt_exportxl.Text = "Export Excel"
        Me.bt_exportxl.UseVisualStyleBackColor = True
        '
        'bt_batalbeli
        '
        Me.bt_batalbeli.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_batalbeli.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalbeli.Location = New System.Drawing.Point(488, 244)
        Me.bt_batalbeli.Name = "bt_batalbeli"
        Me.bt_batalbeli.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalbeli.TabIndex = 414
        Me.bt_batalbeli.Text = "Close"
        Me.bt_batalbeli.UseVisualStyleBackColor = True
        '
        'bt_simpanbeli
        '
        Me.bt_simpanbeli.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_simpanbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbeli.Location = New System.Drawing.Point(311, 244)
        Me.bt_simpanbeli.Name = "bt_simpanbeli"
        Me.bt_simpanbeli.Size = New System.Drawing.Size(171, 30)
        Me.bt_simpanbeli.TabIndex = 413
        Me.bt_simpanbeli.Text = "Tampilkan"
        Me.bt_simpanbeli.UseVisualStyleBackColor = True
        '
        'in_custo_n
        '
        Me.in_custo_n.BackColor = System.Drawing.Color.White
        Me.in_custo_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_custo_n.ForeColor = System.Drawing.Color.Black
        Me.in_custo_n.Location = New System.Drawing.Point(205, 126)
        Me.in_custo_n.MaxLength = 200
        Me.in_custo_n.Name = "in_custo_n"
        Me.in_custo_n.Size = New System.Drawing.Size(322, 20)
        Me.in_custo_n.TabIndex = 428
        '
        'in_custo
        '
        Me.in_custo.BackColor = System.Drawing.Color.White
        Me.in_custo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_custo.ForeColor = System.Drawing.Color.Black
        Me.in_custo.Location = New System.Drawing.Point(82, 126)
        Me.in_custo.MaxLength = 30
        Me.in_custo.Name = "in_custo"
        Me.in_custo.ReadOnly = True
        Me.in_custo.Size = New System.Drawing.Size(121, 20)
        Me.in_custo.TabIndex = 427
        '
        'lbl_custo
        '
        Me.lbl_custo.AutoSize = True
        Me.lbl_custo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_custo.Location = New System.Drawing.Point(8, 130)
        Me.lbl_custo.Name = "lbl_custo"
        Me.lbl_custo.Size = New System.Drawing.Size(51, 13)
        Me.lbl_custo.TabIndex = 430
        Me.lbl_custo.Text = "Customer"
        '
        'in_sales_n
        '
        Me.in_sales_n.BackColor = System.Drawing.Color.White
        Me.in_sales_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales_n.ForeColor = System.Drawing.Color.Black
        Me.in_sales_n.Location = New System.Drawing.Point(205, 103)
        Me.in_sales_n.MaxLength = 200
        Me.in_sales_n.Name = "in_sales_n"
        Me.in_sales_n.Size = New System.Drawing.Size(322, 20)
        Me.in_sales_n.TabIndex = 436
        '
        'in_sales
        '
        Me.in_sales.BackColor = System.Drawing.Color.White
        Me.in_sales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales.ForeColor = System.Drawing.Color.Black
        Me.in_sales.Location = New System.Drawing.Point(82, 103)
        Me.in_sales.MaxLength = 30
        Me.in_sales.Name = "in_sales"
        Me.in_sales.ReadOnly = True
        Me.in_sales.Size = New System.Drawing.Size(121, 20)
        Me.in_sales.TabIndex = 435
        '
        'lbl_sales
        '
        Me.lbl_sales.AutoSize = True
        Me.lbl_sales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sales.Location = New System.Drawing.Point(8, 107)
        Me.lbl_sales.Name = "lbl_sales"
        Me.lbl_sales.Size = New System.Drawing.Size(53, 13)
        Me.lbl_sales.TabIndex = 437
        Me.lbl_sales.Text = "Salesman"
        '
        'lbl_tgl2
        '
        Me.lbl_tgl2.AutoSize = True
        Me.lbl_tgl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tgl2.Location = New System.Drawing.Point(228, 38)
        Me.lbl_tgl2.Name = "lbl_tgl2"
        Me.lbl_tgl2.Size = New System.Drawing.Size(24, 13)
        Me.lbl_tgl2.TabIndex = 434
        Me.lbl_tgl2.Text = "s.d."
        '
        'date_tglakhir
        '
        Me.date_tglakhir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tglakhir.Location = New System.Drawing.Point(258, 34)
        Me.date_tglakhir.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.date_tglakhir.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tglakhir.Name = "date_tglakhir"
        Me.date_tglakhir.Size = New System.Drawing.Size(140, 20)
        Me.date_tglakhir.TabIndex = 432
        Me.date_tglakhir.TabStop = False
        '
        'lbl_tgl
        '
        Me.lbl_tgl.AutoSize = True
        Me.lbl_tgl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tgl.Location = New System.Drawing.Point(8, 38)
        Me.lbl_tgl.Name = "lbl_tgl"
        Me.lbl_tgl.Size = New System.Drawing.Size(52, 13)
        Me.lbl_tgl.TabIndex = 433
        Me.lbl_tgl.Text = "Tgl.Trans"
        '
        'date_tglawal
        '
        Me.date_tglawal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tglawal.Location = New System.Drawing.Point(82, 34)
        Me.date_tglawal.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tglawal.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.date_tglawal.Name = "date_tglawal"
        Me.date_tglawal.Size = New System.Drawing.Size(140, 20)
        Me.date_tglawal.TabIndex = 431
        Me.date_tglawal.TabStop = False
        '
        'cb_jenis
        '
        Me.cb_jenis.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_jenis.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_jenis.BackColor = System.Drawing.Color.White
        Me.cb_jenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_jenis.FormattingEnabled = True
        Me.cb_jenis.Location = New System.Drawing.Point(82, 57)
        Me.cb_jenis.Name = "cb_jenis"
        Me.cb_jenis.Size = New System.Drawing.Size(193, 21)
        Me.cb_jenis.TabIndex = 439
        '
        'lbl_jenis
        '
        Me.lbl_jenis.AutoSize = True
        Me.lbl_jenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_jenis.Location = New System.Drawing.Point(8, 61)
        Me.lbl_jenis.Name = "lbl_jenis"
        Me.lbl_jenis.Size = New System.Drawing.Size(64, 13)
        Me.lbl_jenis.TabIndex = 440
        Me.lbl_jenis.Text = "Jenis Trans."
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(228, 130)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(351, 112)
        Me.popPnl_barang.TabIndex = 441
        Me.popPnl_barang.Visible = False
        '
        'dgv_listbarang
        '
        Me.dgv_listbarang.AllowUserToAddRows = False
        Me.dgv_listbarang.AllowUserToDeleteRows = False
        Me.dgv_listbarang.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_listbarang.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv_listbarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listbarang.Location = New System.Drawing.Point(0, 0)
        Me.dgv_listbarang.MultiSelect = False
        Me.dgv_listbarang.Name = "dgv_listbarang"
        Me.dgv_listbarang.ReadOnly = True
        Me.dgv_listbarang.RowHeadersVisible = False
        Me.dgv_listbarang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listbarang.Size = New System.Drawing.Size(351, 103)
        Me.dgv_listbarang.TabIndex = 0
        '
        'in_barang_n
        '
        Me.in_barang_n.BackColor = System.Drawing.Color.White
        Me.in_barang_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang_n.ForeColor = System.Drawing.Color.Black
        Me.in_barang_n.Location = New System.Drawing.Point(205, 149)
        Me.in_barang_n.MaxLength = 200
        Me.in_barang_n.Name = "in_barang_n"
        Me.in_barang_n.Size = New System.Drawing.Size(322, 20)
        Me.in_barang_n.TabIndex = 443
        '
        'in_barang
        '
        Me.in_barang.BackColor = System.Drawing.Color.White
        Me.in_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang.ForeColor = System.Drawing.Color.Black
        Me.in_barang.Location = New System.Drawing.Point(82, 149)
        Me.in_barang.MaxLength = 30
        Me.in_barang.Name = "in_barang"
        Me.in_barang.ReadOnly = True
        Me.in_barang.Size = New System.Drawing.Size(121, 20)
        Me.in_barang.TabIndex = 442
        '
        'lbl_barang
        '
        Me.lbl_barang.AutoSize = True
        Me.lbl_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_barang.Location = New System.Drawing.Point(8, 153)
        Me.lbl_barang.Name = "lbl_barang"
        Me.lbl_barang.Size = New System.Drawing.Size(41, 13)
        Me.lbl_barang.TabIndex = 444
        Me.lbl_barang.Text = "Barang"
        '
        'lbl_pajak
        '
        Me.lbl_pajak.AutoSize = True
        Me.lbl_pajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pajak.Location = New System.Drawing.Point(8, 84)
        Me.lbl_pajak.Name = "lbl_pajak"
        Me.lbl_pajak.Size = New System.Drawing.Size(46, 13)
        Me.lbl_pajak.TabIndex = 446
        Me.lbl_pajak.Text = "Kategori"
        '
        'cb_pajak
        '
        Me.cb_pajak.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_pajak.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_pajak.BackColor = System.Drawing.Color.White
        Me.cb_pajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_pajak.FormattingEnabled = True
        Me.cb_pajak.Location = New System.Drawing.Point(82, 80)
        Me.cb_pajak.Name = "cb_pajak"
        Me.cb_pajak.Size = New System.Drawing.Size(193, 21)
        Me.cb_pajak.TabIndex = 445
        '
        'fr_lap_filter_jual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(591, 290)
        Me.Controls.Add(Me.lbl_pajak)
        Me.Controls.Add(Me.cb_pajak)
        Me.Controls.Add(Me.popPnl_barang)
        Me.Controls.Add(Me.in_barang_n)
        Me.Controls.Add(Me.in_barang)
        Me.Controls.Add(Me.lbl_barang)
        Me.Controls.Add(Me.cb_jenis)
        Me.Controls.Add(Me.lbl_jenis)
        Me.Controls.Add(Me.in_custo_n)
        Me.Controls.Add(Me.in_custo)
        Me.Controls.Add(Me.lbl_custo)
        Me.Controls.Add(Me.in_sales_n)
        Me.Controls.Add(Me.in_sales)
        Me.Controls.Add(Me.lbl_sales)
        Me.Controls.Add(Me.lbl_tgl2)
        Me.Controls.Add(Me.date_tglakhir)
        Me.Controls.Add(Me.lbl_tgl)
        Me.Controls.Add(Me.date_tglawal)
        Me.Controls.Add(Me.bt_exportxl)
        Me.Controls.Add(Me.bt_batalbeli)
        Me.Controls.Add(Me.bt_simpanbeli)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_lap_filter_jual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filter Laporan Penjualan"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.popPnl_barang.ResumeLayout(False)
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents bt_exportxl As System.Windows.Forms.Button
    Friend WithEvents bt_batalbeli As System.Windows.Forms.Button
    Friend WithEvents bt_simpanbeli As System.Windows.Forms.Button
    Friend WithEvents in_custo_n As System.Windows.Forms.TextBox
    Friend WithEvents in_custo As System.Windows.Forms.TextBox
    Friend WithEvents lbl_custo As System.Windows.Forms.Label
    Friend WithEvents in_sales_n As System.Windows.Forms.TextBox
    Friend WithEvents in_sales As System.Windows.Forms.TextBox
    Friend WithEvents lbl_sales As System.Windows.Forms.Label
    Friend WithEvents lbl_tgl2 As System.Windows.Forms.Label
    Friend WithEvents date_tglakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_tgl As System.Windows.Forms.Label
    Friend WithEvents date_tglawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents cb_jenis As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_jenis As System.Windows.Forms.Label
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents in_barang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_barang As System.Windows.Forms.TextBox
    Friend WithEvents lbl_barang As System.Windows.Forms.Label
    Friend WithEvents lbl_pajak As System.Windows.Forms.Label
    Friend WithEvents cb_pajak As System.Windows.Forms.ComboBox
End Class
