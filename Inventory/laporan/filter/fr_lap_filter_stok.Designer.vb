﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_lap_filter_stok
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_lap_filter_stok))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.bt_exportxl = New System.Windows.Forms.Button()
        Me.date_tglawal = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.date_tglakhir = New System.Windows.Forms.DateTimePicker()
        Me.in_supplier_n = New System.Windows.Forms.TextBox()
        Me.in_supplier = New System.Windows.Forms.TextBox()
        Me.lbl_supplier = New System.Windows.Forms.Label()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.in_barang_n = New System.Windows.Forms.TextBox()
        Me.in_barang = New System.Windows.Forms.TextBox()
        Me.lbl_barang = New System.Windows.Forms.Label()
        Me.in_gudang_n = New System.Windows.Forms.TextBox()
        Me.in_gudang = New System.Windows.Forms.TextBox()
        Me.lbl_gudang = New System.Windows.Forms.Label()
        Me.lbl_periodedata = New System.Windows.Forms.Label()
        Me.cb_groupBy = New System.Windows.Forms.ComboBox()
        Me.lbl_groupby = New System.Windows.Forms.Label()
        Me.cb_jenis = New System.Windows.Forms.ComboBox()
        Me.lbl_jenis = New System.Windows.Forms.Label()
        Me.bt_simpanbeli = New System.Windows.Forms.Button()
        Me.bt_batalbeli = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.lbl_title)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(591, 30)
        Me.Panel1.TabIndex = 335
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
        Me.bt_cl.TabIndex = 9
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
        Me.lbl_title.Size = New System.Drawing.Size(184, 19)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Laporan Stok/Persediaan"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 247)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(591, 10)
        Me.Panel3.TabIndex = 410
        '
        'bt_exportxl
        '
        Me.bt_exportxl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_exportxl.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_exportxl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_exportxl.Location = New System.Drawing.Point(11, 210)
        Me.bt_exportxl.Name = "bt_exportxl"
        Me.bt_exportxl.Size = New System.Drawing.Size(96, 30)
        Me.bt_exportxl.TabIndex = 10
        Me.bt_exportxl.Text = "Export Excel"
        Me.bt_exportxl.UseVisualStyleBackColor = True
        '
        'date_tglawal
        '
        Me.date_tglawal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tglawal.Location = New System.Drawing.Point(80, 37)
        Me.date_tglawal.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tglawal.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.date_tglawal.Name = "date_tglawal"
        Me.date_tglawal.Size = New System.Drawing.Size(140, 20)
        Me.date_tglawal.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 412
        Me.Label4.Text = "Tanggal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(226, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 414
        Me.Label1.Text = "s.d."
        '
        'date_tglakhir
        '
        Me.date_tglakhir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tglakhir.Location = New System.Drawing.Point(256, 37)
        Me.date_tglakhir.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.date_tglakhir.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tglakhir.Name = "date_tglakhir"
        Me.date_tglakhir.Size = New System.Drawing.Size(140, 20)
        Me.date_tglakhir.TabIndex = 1
        '
        'in_supplier_n
        '
        Me.in_supplier_n.BackColor = System.Drawing.Color.White
        Me.in_supplier_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier_n.ForeColor = System.Drawing.Color.Black
        Me.in_supplier_n.Location = New System.Drawing.Point(203, 103)
        Me.in_supplier_n.MaxLength = 200
        Me.in_supplier_n.Name = "in_supplier_n"
        Me.in_supplier_n.Size = New System.Drawing.Size(322, 20)
        Me.in_supplier_n.TabIndex = 7
        '
        'in_supplier
        '
        Me.in_supplier.BackColor = System.Drawing.Color.White
        Me.in_supplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier.ForeColor = System.Drawing.Color.Black
        Me.in_supplier.Location = New System.Drawing.Point(80, 103)
        Me.in_supplier.MaxLength = 30
        Me.in_supplier.Name = "in_supplier"
        Me.in_supplier.ReadOnly = True
        Me.in_supplier.Size = New System.Drawing.Size(121, 20)
        Me.in_supplier.TabIndex = 6
        '
        'lbl_supplier
        '
        Me.lbl_supplier.AutoSize = True
        Me.lbl_supplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_supplier.Location = New System.Drawing.Point(6, 107)
        Me.lbl_supplier.Name = "lbl_supplier"
        Me.lbl_supplier.Size = New System.Drawing.Size(45, 13)
        Me.lbl_supplier.TabIndex = 0
        Me.lbl_supplier.Text = "Supplier"
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(541, 42)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(351, 129)
        Me.popPnl_barang.TabIndex = 425
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
        Me.dgv_listbarang.Size = New System.Drawing.Size(351, 125)
        Me.dgv_listbarang.TabIndex = 0
        '
        'in_barang_n
        '
        Me.in_barang_n.BackColor = System.Drawing.Color.White
        Me.in_barang_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang_n.ForeColor = System.Drawing.Color.Black
        Me.in_barang_n.Location = New System.Drawing.Point(203, 81)
        Me.in_barang_n.MaxLength = 200
        Me.in_barang_n.Name = "in_barang_n"
        Me.in_barang_n.Size = New System.Drawing.Size(322, 20)
        Me.in_barang_n.TabIndex = 5
        '
        'in_barang
        '
        Me.in_barang.BackColor = System.Drawing.Color.White
        Me.in_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang.ForeColor = System.Drawing.Color.Black
        Me.in_barang.Location = New System.Drawing.Point(80, 81)
        Me.in_barang.MaxLength = 30
        Me.in_barang.Name = "in_barang"
        Me.in_barang.ReadOnly = True
        Me.in_barang.Size = New System.Drawing.Size(121, 20)
        Me.in_barang.TabIndex = 4
        '
        'lbl_barang
        '
        Me.lbl_barang.AutoSize = True
        Me.lbl_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_barang.Location = New System.Drawing.Point(6, 85)
        Me.lbl_barang.Name = "lbl_barang"
        Me.lbl_barang.Size = New System.Drawing.Size(41, 13)
        Me.lbl_barang.TabIndex = 0
        Me.lbl_barang.Text = "Barang"
        '
        'in_gudang_n
        '
        Me.in_gudang_n.BackColor = System.Drawing.Color.White
        Me.in_gudang_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang_n.ForeColor = System.Drawing.Color.Black
        Me.in_gudang_n.Location = New System.Drawing.Point(203, 59)
        Me.in_gudang_n.MaxLength = 200
        Me.in_gudang_n.Name = "in_gudang_n"
        Me.in_gudang_n.Size = New System.Drawing.Size(322, 20)
        Me.in_gudang_n.TabIndex = 3
        '
        'in_gudang
        '
        Me.in_gudang.BackColor = System.Drawing.Color.White
        Me.in_gudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang.ForeColor = System.Drawing.Color.Black
        Me.in_gudang.Location = New System.Drawing.Point(80, 59)
        Me.in_gudang.MaxLength = 30
        Me.in_gudang.Name = "in_gudang"
        Me.in_gudang.ReadOnly = True
        Me.in_gudang.Size = New System.Drawing.Size(121, 20)
        Me.in_gudang.TabIndex = 2
        '
        'lbl_gudang
        '
        Me.lbl_gudang.AutoSize = True
        Me.lbl_gudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_gudang.Location = New System.Drawing.Point(6, 63)
        Me.lbl_gudang.Name = "lbl_gudang"
        Me.lbl_gudang.Size = New System.Drawing.Size(45, 13)
        Me.lbl_gudang.TabIndex = 0
        Me.lbl_gudang.Text = "Gudang"
        '
        'lbl_periodedata
        '
        Me.lbl_periodedata.AutoSize = True
        Me.lbl_periodedata.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_periodedata.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_periodedata.Location = New System.Drawing.Point(8, 192)
        Me.lbl_periodedata.Name = "lbl_periodedata"
        Me.lbl_periodedata.Size = New System.Drawing.Size(50, 13)
        Me.lbl_periodedata.TabIndex = 432
        Me.lbl_periodedata.Text = "Periode"
        '
        'cb_groupBy
        '
        Me.cb_groupBy.FormattingEnabled = True
        Me.cb_groupBy.Location = New System.Drawing.Point(80, 150)
        Me.cb_groupBy.Name = "cb_groupBy"
        Me.cb_groupBy.Size = New System.Drawing.Size(170, 21)
        Me.cb_groupBy.TabIndex = 9
        '
        'lbl_groupby
        '
        Me.lbl_groupby.AutoSize = True
        Me.lbl_groupby.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_groupby.Location = New System.Drawing.Point(6, 154)
        Me.lbl_groupby.Name = "lbl_groupby"
        Me.lbl_groupby.Size = New System.Drawing.Size(48, 13)
        Me.lbl_groupby.TabIndex = 0
        Me.lbl_groupby.Text = "GroupBy"
        '
        'cb_jenis
        '
        Me.cb_jenis.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_jenis.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_jenis.BackColor = System.Drawing.Color.White
        Me.cb_jenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_jenis.FormattingEnabled = True
        Me.cb_jenis.Location = New System.Drawing.Point(80, 125)
        Me.cb_jenis.Name = "cb_jenis"
        Me.cb_jenis.Size = New System.Drawing.Size(170, 21)
        Me.cb_jenis.TabIndex = 8
        '
        'lbl_jenis
        '
        Me.lbl_jenis.AutoSize = True
        Me.lbl_jenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_jenis.Location = New System.Drawing.Point(6, 129)
        Me.lbl_jenis.Name = "lbl_jenis"
        Me.lbl_jenis.Size = New System.Drawing.Size(46, 13)
        Me.lbl_jenis.TabIndex = 442
        Me.lbl_jenis.Text = "Kategori"
        '
        'bt_simpanbeli
        '
        Me.bt_simpanbeli.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpanbeli.FlatAppearance.BorderSize = 0
        Me.bt_simpanbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpanbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbeli.ForeColor = System.Drawing.Color.White
        Me.bt_simpanbeli.Location = New System.Drawing.Point(311, 211)
        Me.bt_simpanbeli.Name = "bt_simpanbeli"
        Me.bt_simpanbeli.Size = New System.Drawing.Size(171, 30)
        Me.bt_simpanbeli.TabIndex = 11
        Me.bt_simpanbeli.Text = "Tampilkan"
        Me.bt_simpanbeli.UseVisualStyleBackColor = False
        '
        'bt_batalbeli
        '
        Me.bt_batalbeli.BackColor = System.Drawing.Color.Tomato
        Me.bt_batalbeli.FlatAppearance.BorderSize = 0
        Me.bt_batalbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_batalbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalbeli.ForeColor = System.Drawing.Color.White
        Me.bt_batalbeli.Location = New System.Drawing.Point(488, 211)
        Me.bt_batalbeli.Name = "bt_batalbeli"
        Me.bt_batalbeli.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalbeli.TabIndex = 12
        Me.bt_batalbeli.Text = "Close"
        Me.bt_batalbeli.UseVisualStyleBackColor = False
        '
        'fr_lap_filter_stok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(591, 257)
        Me.Controls.Add(Me.popPnl_barang)
        Me.Controls.Add(Me.bt_simpanbeli)
        Me.Controls.Add(Me.bt_batalbeli)
        Me.Controls.Add(Me.cb_jenis)
        Me.Controls.Add(Me.lbl_jenis)
        Me.Controls.Add(Me.cb_groupBy)
        Me.Controls.Add(Me.lbl_periodedata)
        Me.Controls.Add(Me.in_gudang_n)
        Me.Controls.Add(Me.in_gudang)
        Me.Controls.Add(Me.lbl_gudang)
        Me.Controls.Add(Me.in_barang_n)
        Me.Controls.Add(Me.in_barang)
        Me.Controls.Add(Me.lbl_barang)
        Me.Controls.Add(Me.in_supplier_n)
        Me.Controls.Add(Me.in_supplier)
        Me.Controls.Add(Me.lbl_groupby)
        Me.Controls.Add(Me.lbl_supplier)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.date_tglakhir)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.date_tglawal)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.bt_exportxl)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_lap_filter_stok"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Laporan "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.popPnl_barang.ResumeLayout(False)
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents bt_exportxl As System.Windows.Forms.Button
    Friend WithEvents date_tglawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents date_tglakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents in_supplier_n As System.Windows.Forms.TextBox
    Friend WithEvents in_supplier As System.Windows.Forms.TextBox
    Friend WithEvents lbl_supplier As System.Windows.Forms.Label
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents in_barang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_barang As System.Windows.Forms.TextBox
    Friend WithEvents lbl_barang As System.Windows.Forms.Label
    Friend WithEvents in_gudang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang As System.Windows.Forms.TextBox
    Friend WithEvents lbl_gudang As System.Windows.Forms.Label
    Friend WithEvents lbl_periodedata As System.Windows.Forms.Label
    Friend WithEvents cb_groupBy As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_groupby As System.Windows.Forms.Label
    Friend WithEvents cb_jenis As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_jenis As System.Windows.Forms.Label
    Friend WithEvents bt_simpanbeli As System.Windows.Forms.Button
    Friend WithEvents bt_batalbeli As System.Windows.Forms.Button
End Class
