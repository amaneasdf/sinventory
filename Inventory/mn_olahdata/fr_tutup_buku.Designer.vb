<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_tutup_buku
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
        Me.ck_stok = New System.Windows.Forms.CheckBox()
        Me.ck_piutang = New System.Windows.Forms.CheckBox()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.date_tgl_awal = New System.Windows.Forms.DateTimePicker()
        Me.date_tgl_akhir = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bt_batalperkiraan = New System.Windows.Forms.Button()
        Me.bt_simpanperkiraan = New System.Windows.Forms.Button()
        Me.ck_stok_bonus = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.ck_neraca = New System.Windows.Forms.CheckBox()
        Me.ck_proses = New System.Windows.Forms.CheckBox()
        Me.dgv_stock = New System.Windows.Forms.DataGridView()
        Me.brg_ck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.brg_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brg_brg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brg_gudang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brg_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brg_sisa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brg_stockop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brg_sisaop = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brg_jenis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        Me.DataGridView4 = New System.Windows.Forms.DataGridView()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_stock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_content.SuspendLayout()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(881, 42)
        Me.Panel1.TabIndex = 251
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(801, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(854, 9)
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
        Me.lbl_title.Size = New System.Drawing.Size(200, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "From Tutup Buku"
        '
        'ck_stok
        '
        Me.ck_stok.AutoSize = True
        Me.ck_stok.Location = New System.Drawing.Point(6, 15)
        Me.ck_stok.Name = "ck_stok"
        Me.ck_stok.Size = New System.Drawing.Size(48, 17)
        Me.ck_stok.TabIndex = 252
        Me.ck_stok.Text = "Stok"
        Me.ck_stok.UseVisualStyleBackColor = True
        '
        'ck_piutang
        '
        Me.ck_piutang.AutoSize = True
        Me.ck_piutang.Location = New System.Drawing.Point(6, 205)
        Me.ck_piutang.Name = "ck_piutang"
        Me.ck_piutang.Size = New System.Drawing.Size(62, 17)
        Me.ck_piutang.TabIndex = 252
        Me.ck_piutang.Text = "Piutang"
        Me.ck_piutang.UseVisualStyleBackColor = True
        '
        'in_kode
        '
        Me.in_kode.Location = New System.Drawing.Point(33, 55)
        Me.in_kode.Name = "in_kode"
        Me.in_kode.ReadOnly = True
        Me.in_kode.Size = New System.Drawing.Size(100, 20)
        Me.in_kode.TabIndex = 0
        Me.in_kode.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 254
        Me.Label1.Text = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(156, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 255
        Me.Label2.Text = "Periode"
        '
        'date_tgl_awal
        '
        Me.date_tgl_awal.Location = New System.Drawing.Point(205, 55)
        Me.date_tgl_awal.Name = "date_tgl_awal"
        Me.date_tgl_awal.Size = New System.Drawing.Size(143, 20)
        Me.date_tgl_awal.TabIndex = 0
        '
        'date_tgl_akhir
        '
        Me.date_tgl_akhir.Location = New System.Drawing.Point(384, 55)
        Me.date_tgl_akhir.Name = "date_tgl_akhir"
        Me.date_tgl_akhir.Size = New System.Drawing.Size(143, 20)
        Me.date_tgl_akhir.TabIndex = 257
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(354, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 258
        Me.Label3.Text = "s.d."
        '
        'bt_batalperkiraan
        '
        Me.bt_batalperkiraan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_batalperkiraan.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalperkiraan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalperkiraan.Location = New System.Drawing.Point(778, 503)
        Me.bt_batalperkiraan.Name = "bt_batalperkiraan"
        Me.bt_batalperkiraan.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalperkiraan.TabIndex = 260
        Me.bt_batalperkiraan.Text = "Batal"
        Me.bt_batalperkiraan.UseVisualStyleBackColor = True
        '
        'bt_simpanperkiraan
        '
        Me.bt_simpanperkiraan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_simpanperkiraan.Enabled = False
        Me.bt_simpanperkiraan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanperkiraan.Location = New System.Drawing.Point(616, 503)
        Me.bt_simpanperkiraan.Name = "bt_simpanperkiraan"
        Me.bt_simpanperkiraan.Size = New System.Drawing.Size(156, 30)
        Me.bt_simpanperkiraan.TabIndex = 259
        Me.bt_simpanperkiraan.Text = "Simpan Pembayaran"
        Me.bt_simpanperkiraan.UseVisualStyleBackColor = True
        '
        'ck_stok_bonus
        '
        Me.ck_stok_bonus.AutoSize = True
        Me.ck_stok_bonus.Location = New System.Drawing.Point(112, 15)
        Me.ck_stok_bonus.Name = "ck_stok_bonus"
        Me.ck_stok_bonus.Size = New System.Drawing.Size(81, 17)
        Me.ck_stok_bonus.TabIndex = 261
        Me.ck_stok_bonus.Text = "Stok Bonus"
        Me.ck_stok_bonus.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(6, 396)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(61, 17)
        Me.CheckBox3.TabIndex = 262
        Me.CheckBox3.Text = "Hutang"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(6, 589)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(53, 17)
        Me.CheckBox4.TabIndex = 263
        Me.CheckBox4.Text = "BG In"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(132, 589)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(61, 17)
        Me.CheckBox5.TabIndex = 264
        Me.CheckBox5.Text = "BG Out"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(6, 776)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(56, 17)
        Me.CheckBox6.TabIndex = 265
        Me.CheckBox6.Text = "Aktiva"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'ck_neraca
        '
        Me.ck_neraca.AutoSize = True
        Me.ck_neraca.Location = New System.Drawing.Point(6, 967)
        Me.ck_neraca.Name = "ck_neraca"
        Me.ck_neraca.Size = New System.Drawing.Size(61, 17)
        Me.ck_neraca.TabIndex = 266
        Me.ck_neraca.Text = "Neraca"
        Me.ck_neraca.UseVisualStyleBackColor = True
        '
        'ck_proses
        '
        Me.ck_proses.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ck_proses.AutoSize = True
        Me.ck_proses.Location = New System.Drawing.Point(616, 480)
        Me.ck_proses.Name = "ck_proses"
        Me.ck_proses.Size = New System.Drawing.Size(93, 17)
        Me.ck_proses.TabIndex = 267
        Me.ck_proses.Text = "Tutup Periode"
        Me.ck_proses.UseVisualStyleBackColor = True
        '
        'dgv_stock
        '
        Me.dgv_stock.AllowUserToAddRows = False
        Me.dgv_stock.AllowUserToDeleteRows = False
        Me.dgv_stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_stock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.brg_ck, Me.brg_tgl, Me.brg_brg, Me.brg_gudang, Me.brg_status, Me.brg_sisa, Me.brg_stockop, Me.brg_sisaop, Me.brg_jenis})
        Me.dgv_stock.Location = New System.Drawing.Point(6, 38)
        Me.dgv_stock.Name = "dgv_stock"
        Me.dgv_stock.RowHeadersVisible = False
        Me.dgv_stock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_stock.Size = New System.Drawing.Size(554, 150)
        Me.dgv_stock.TabIndex = 268
        '
        'brg_ck
        '
        Me.brg_ck.DataPropertyName = "stock_ck"
        Me.brg_ck.FalseValue = "0"
        Me.brg_ck.HeaderText = "Check"
        Me.brg_ck.Name = "brg_ck"
        Me.brg_ck.TrueValue = "1"
        Me.brg_ck.Width = 50
        '
        'brg_tgl
        '
        Me.brg_tgl.HeaderText = "Tanggal"
        Me.brg_tgl.Name = "brg_tgl"
        Me.brg_tgl.Width = 75
        '
        'brg_brg
        '
        Me.brg_brg.DataPropertyName = "stock_barang"
        Me.brg_brg.HeaderText = "KodeBarang"
        Me.brg_brg.Name = "brg_brg"
        Me.brg_brg.Width = 95
        '
        'brg_gudang
        '
        Me.brg_gudang.HeaderText = "KodeGudang"
        Me.brg_gudang.Name = "brg_gudang"
        Me.brg_gudang.Width = 80
        '
        'brg_status
        '
        Me.brg_status.HeaderText = "Status"
        Me.brg_status.Name = "brg_status"
        Me.brg_status.Width = 50
        '
        'brg_sisa
        '
        Me.brg_sisa.HeaderText = "Sisa"
        Me.brg_sisa.Name = "brg_sisa"
        Me.brg_sisa.Width = 50
        '
        'brg_stockop
        '
        Me.brg_stockop.HeaderText = "StockOpn"
        Me.brg_stockop.Name = "brg_stockop"
        Me.brg_stockop.Width = 50
        '
        'brg_sisaop
        '
        Me.brg_sisaop.HeaderText = "SisaStockOpn"
        Me.brg_sisaop.Name = "brg_sisaop"
        Me.brg_sisaop.Width = 50
        '
        'brg_jenis
        '
        Me.brg_jenis.HeaderText = "Jenis"
        Me.brg_jenis.Name = "brg_jenis"
        Me.brg_jenis.Width = 50
        '
        'pnl_content
        '
        Me.pnl_content.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.Controls.Add(Me.DataGridView5)
        Me.pnl_content.Controls.Add(Me.DataGridView4)
        Me.pnl_content.Controls.Add(Me.DataGridView3)
        Me.pnl_content.Controls.Add(Me.DataGridView2)
        Me.pnl_content.Controls.Add(Me.DataGridView1)
        Me.pnl_content.Controls.Add(Me.dgv_stock)
        Me.pnl_content.Controls.Add(Me.ck_neraca)
        Me.pnl_content.Controls.Add(Me.ck_stok)
        Me.pnl_content.Controls.Add(Me.CheckBox6)
        Me.pnl_content.Controls.Add(Me.ck_stok_bonus)
        Me.pnl_content.Controls.Add(Me.CheckBox5)
        Me.pnl_content.Controls.Add(Me.ck_piutang)
        Me.pnl_content.Controls.Add(Me.CheckBox4)
        Me.pnl_content.Controls.Add(Me.CheckBox3)
        Me.pnl_content.Location = New System.Drawing.Point(6, 81)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(868, 385)
        Me.pnl_content.TabIndex = 3
        '
        'DataGridView5
        '
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView5.Location = New System.Drawing.Point(6, 986)
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.Size = New System.Drawing.Size(515, 150)
        Me.DataGridView5.TabIndex = 273
        '
        'DataGridView4
        '
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Location = New System.Drawing.Point(6, 799)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.Size = New System.Drawing.Size(515, 150)
        Me.DataGridView4.TabIndex = 272
        '
        'DataGridView3
        '
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(6, 612)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.Size = New System.Drawing.Size(515, 150)
        Me.DataGridView3.TabIndex = 271
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(6, 419)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(515, 150)
        Me.DataGridView2.TabIndex = 270
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 228)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(554, 150)
        Me.DataGridView1.TabIndex = 269
        '
        'fr_tutup_buku
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ck_proses)
        Me.Controls.Add(Me.bt_batalperkiraan)
        Me.Controls.Add(Me.bt_simpanperkiraan)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.date_tgl_akhir)
        Me.Controls.Add(Me.date_tgl_awal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.in_kode)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnl_content)
        Me.Name = "fr_tutup_buku"
        Me.Size = New System.Drawing.Size(881, 548)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv_stock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents ck_stok As System.Windows.Forms.CheckBox
    Friend WithEvents ck_piutang As System.Windows.Forms.CheckBox
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents date_tgl_awal As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_tgl_akhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents bt_batalperkiraan As System.Windows.Forms.Button
    Friend WithEvents bt_simpanperkiraan As System.Windows.Forms.Button
    Friend WithEvents ck_stok_bonus As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents ck_neraca As System.Windows.Forms.CheckBox
    Friend WithEvents ck_proses As System.Windows.Forms.CheckBox
    Friend WithEvents dgv_stock As System.Windows.Forms.DataGridView
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents DataGridView5 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView4 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents brg_ck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents brg_tgl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brg_brg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brg_gudang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brg_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brg_sisa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brg_stockop As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brg_sisaop As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brg_jenis As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
