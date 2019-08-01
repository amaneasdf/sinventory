<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_stok_awal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_stok_awal))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.pnl_footer = New System.Windows.Forms.Panel()
        Me.bt_simpanreturbeli = New System.Windows.Forms.Button()
        Me.bt_batalreturbeli = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_deact = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_del = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.in_qty = New System.Windows.Forms.NumericUpDown()
        Me.in_nilai = New System.Windows.Forms.NumericUpDown()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.linkLbl_searchbarang = New System.Windows.Forms.LinkLabel()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.in_barang_n = New System.Windows.Forms.TextBox()
        Me.in_gudang_n = New System.Windows.Forms.TextBox()
        Me.in_barang = New System.Windows.Forms.TextBox()
        Me.in_gudang = New System.Windows.Forms.TextBox()
        Me.in_id = New System.Windows.Forms.TextBox()
        Me.in_old_qty = New System.Windows.Forms.TextBox()
        Me.in_old_nilai = New System.Windows.Forms.TextBox()
        Me.in_old_hpp = New System.Windows.Forms.TextBox()
        Me.in_hpp = New System.Windows.Forms.TextBox()
        Me.lbl_old_qty = New System.Windows.Forms.Label()
        Me.lbl_old_nilai = New System.Windows.Forms.Label()
        Me.lbl_old_hpp = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.date_input = New System.Windows.Forms.DateTimePicker()
        Me.Panel1.SuspendLayout()
        Me.pnl_footer.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.in_qty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_nilai, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_content.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 412)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(593, 12)
        Me.Panel2.TabIndex = 284
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.lbl_title)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(593, 29)
        Me.Panel1.TabIndex = 282
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
        Me.bt_cl.Location = New System.Drawing.Point(566, 3)
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
        Me.lbl_title.Font = New System.Drawing.Font("Source Sans Pro", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(3, 2)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(143, 24)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Input Stok Awal"
        '
        'pnl_footer
        '
        Me.pnl_footer.BackColor = System.Drawing.Color.Gainsboro
        Me.pnl_footer.Controls.Add(Me.bt_simpanreturbeli)
        Me.pnl_footer.Controls.Add(Me.bt_batalreturbeli)
        Me.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_footer.Location = New System.Drawing.Point(0, 365)
        Me.pnl_footer.Name = "pnl_footer"
        Me.pnl_footer.Size = New System.Drawing.Size(593, 47)
        Me.pnl_footer.TabIndex = 14
        '
        'bt_simpanreturbeli
        '
        Me.bt_simpanreturbeli.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpanreturbeli.FlatAppearance.BorderSize = 0
        Me.bt_simpanreturbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpanreturbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanreturbeli.ForeColor = System.Drawing.Color.White
        Me.bt_simpanreturbeli.Location = New System.Drawing.Point(313, 6)
        Me.bt_simpanreturbeli.Name = "bt_simpanreturbeli"
        Me.bt_simpanreturbeli.Size = New System.Drawing.Size(161, 35)
        Me.bt_simpanreturbeli.TabIndex = 15
        Me.bt_simpanreturbeli.Text = "Simpan"
        Me.bt_simpanreturbeli.UseVisualStyleBackColor = False
        '
        'bt_batalreturbeli
        '
        Me.bt_batalreturbeli.BackColor = System.Drawing.Color.Tomato
        Me.bt_batalreturbeli.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalreturbeli.FlatAppearance.BorderSize = 0
        Me.bt_batalreturbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_batalreturbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalreturbeli.ForeColor = System.Drawing.Color.White
        Me.bt_batalreturbeli.Location = New System.Drawing.Point(480, 6)
        Me.bt_batalreturbeli.Name = "bt_batalreturbeli"
        Me.bt_batalreturbeli.Size = New System.Drawing.Size(106, 35)
        Me.bt_batalreturbeli.TabIndex = 16
        Me.bt_batalreturbeli.Text = "Batal"
        Me.bt_batalreturbeli.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_deact, Me.mn_del})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(576, 24)
        Me.MenuStrip1.TabIndex = 182
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
        'mn_deact
        '
        Me.mn_deact.Image = Global.Inventory.My.Resources.Resources.toolbar_cancel_icon
        Me.mn_deact.Name = "mn_deact"
        Me.mn_deact.Size = New System.Drawing.Size(90, 20)
        Me.mn_deact.Text = "Deactivate"
        Me.mn_deact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.mn_deact.Visible = False
        '
        'mn_del
        '
        Me.mn_del.Name = "mn_del"
        Me.mn_del.Size = New System.Drawing.Size(53, 20)
        Me.mn_del.Text = "Hapus"
        Me.mn_del.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 259
        Me.Label3.Text = "Gudang"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 259
        Me.Label2.Text = "ID Stok"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 262
        Me.Label1.Text = "Barang"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 262
        Me.Label4.Text = "QTY Awal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 231)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 262
        Me.Label5.Text = "HPP"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 204)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "Nilai Awal"
        '
        'in_qty
        '
        Me.in_qty.Font = New System.Drawing.Font("Open Sans", 8.25!)
        Me.in_qty.Location = New System.Drawing.Point(68, 173)
        Me.in_qty.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.in_qty.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.in_qty.Name = "in_qty"
        Me.in_qty.Size = New System.Drawing.Size(176, 22)
        Me.in_qty.TabIndex = 7
        Me.in_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_qty.ThousandsSeparator = True
        '
        'in_nilai
        '
        Me.in_nilai.DecimalPlaces = 2
        Me.in_nilai.Font = New System.Drawing.Font("Open Sans", 8.25!)
        Me.in_nilai.Location = New System.Drawing.Point(68, 199)
        Me.in_nilai.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 0})
        Me.in_nilai.Minimum = New Decimal(New Integer() {276447231, 23283, 0, -2147483648})
        Me.in_nilai.Name = "in_nilai"
        Me.in_nilai.Size = New System.Drawing.Size(176, 22)
        Me.in_nilai.TabIndex = 9
        Me.in_nilai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_nilai.ThousandsSeparator = True
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Controls.Add(Me.linkLbl_searchbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(12, 256)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(330, 156)
        Me.popPnl_barang.TabIndex = 425
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
        Me.dgv_listbarang.Size = New System.Drawing.Size(330, 147)
        Me.dgv_listbarang.TabIndex = 0
        '
        'linkLbl_searchbarang
        '
        Me.linkLbl_searchbarang.AutoSize = True
        Me.linkLbl_searchbarang.LinkColor = System.Drawing.Color.DimGray
        Me.linkLbl_searchbarang.Location = New System.Drawing.Point(3, 132)
        Me.linkLbl_searchbarang.Name = "linkLbl_searchbarang"
        Me.linkLbl_searchbarang.Size = New System.Drawing.Size(124, 15)
        Me.linkLbl_searchbarang.TabIndex = 1
        Me.linkLbl_searchbarang.TabStop = True
        Me.linkLbl_searchbarang.Text = "Tampilkan Pencarian..."
        Me.linkLbl_searchbarang.VisitedLinkColor = System.Drawing.Color.DimGray
        '
        'pnl_content
        '
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.Controls.Add(Me.popPnl_barang)
        Me.pnl_content.Controls.Add(Me.in_barang_n)
        Me.pnl_content.Controls.Add(Me.in_gudang_n)
        Me.pnl_content.Controls.Add(Me.in_barang)
        Me.pnl_content.Controls.Add(Me.in_gudang)
        Me.pnl_content.Controls.Add(Me.in_id)
        Me.pnl_content.Controls.Add(Me.in_old_qty)
        Me.pnl_content.Controls.Add(Me.in_old_nilai)
        Me.pnl_content.Controls.Add(Me.in_old_hpp)
        Me.pnl_content.Controls.Add(Me.in_hpp)
        Me.pnl_content.Controls.Add(Me.in_nilai)
        Me.pnl_content.Controls.Add(Me.in_qty)
        Me.pnl_content.Controls.Add(Me.Label6)
        Me.pnl_content.Controls.Add(Me.lbl_old_qty)
        Me.pnl_content.Controls.Add(Me.lbl_old_nilai)
        Me.pnl_content.Controls.Add(Me.lbl_old_hpp)
        Me.pnl_content.Controls.Add(Me.Label5)
        Me.pnl_content.Controls.Add(Me.Label7)
        Me.pnl_content.Controls.Add(Me.Label4)
        Me.pnl_content.Controls.Add(Me.Label1)
        Me.pnl_content.Controls.Add(Me.Label2)
        Me.pnl_content.Controls.Add(Me.Label3)
        Me.pnl_content.Controls.Add(Me.MenuStrip1)
        Me.pnl_content.Controls.Add(Me.date_input)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Location = New System.Drawing.Point(0, 29)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(593, 336)
        Me.pnl_content.TabIndex = 0
        '
        'in_barang_n
        '
        Me.in_barang_n.Location = New System.Drawing.Point(209, 100)
        Me.in_barang_n.Name = "in_barang_n"
        Me.in_barang_n.Size = New System.Drawing.Size(351, 22)
        Me.in_barang_n.TabIndex = 4
        '
        'in_gudang_n
        '
        Me.in_gudang_n.Location = New System.Drawing.Point(209, 74)
        Me.in_gudang_n.Name = "in_gudang_n"
        Me.in_gudang_n.Size = New System.Drawing.Size(351, 22)
        Me.in_gudang_n.TabIndex = 2
        '
        'in_barang
        '
        Me.in_barang.BackColor = System.Drawing.Color.WhiteSmoke
        Me.in_barang.Location = New System.Drawing.Point(68, 100)
        Me.in_barang.Name = "in_barang"
        Me.in_barang.ReadOnly = True
        Me.in_barang.Size = New System.Drawing.Size(141, 22)
        Me.in_barang.TabIndex = 3
        '
        'in_gudang
        '
        Me.in_gudang.BackColor = System.Drawing.Color.WhiteSmoke
        Me.in_gudang.Location = New System.Drawing.Point(68, 74)
        Me.in_gudang.Name = "in_gudang"
        Me.in_gudang.ReadOnly = True
        Me.in_gudang.Size = New System.Drawing.Size(141, 22)
        Me.in_gudang.TabIndex = 1
        '
        'in_id
        '
        Me.in_id.BackColor = System.Drawing.Color.WhiteSmoke
        Me.in_id.Location = New System.Drawing.Point(68, 40)
        Me.in_id.Name = "in_id"
        Me.in_id.ReadOnly = True
        Me.in_id.Size = New System.Drawing.Size(208, 22)
        Me.in_id.TabIndex = 0
        '
        'in_old_qty
        '
        Me.in_old_qty.BackColor = System.Drawing.Color.WhiteSmoke
        Me.in_old_qty.Location = New System.Drawing.Point(360, 173)
        Me.in_old_qty.Name = "in_old_qty"
        Me.in_old_qty.ReadOnly = True
        Me.in_old_qty.Size = New System.Drawing.Size(200, 22)
        Me.in_old_qty.TabIndex = 426
        Me.in_old_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'in_old_nilai
        '
        Me.in_old_nilai.BackColor = System.Drawing.Color.WhiteSmoke
        Me.in_old_nilai.Location = New System.Drawing.Point(360, 199)
        Me.in_old_nilai.Name = "in_old_nilai"
        Me.in_old_nilai.ReadOnly = True
        Me.in_old_nilai.Size = New System.Drawing.Size(200, 22)
        Me.in_old_nilai.TabIndex = 426
        Me.in_old_nilai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'in_old_hpp
        '
        Me.in_old_hpp.BackColor = System.Drawing.Color.WhiteSmoke
        Me.in_old_hpp.Location = New System.Drawing.Point(360, 225)
        Me.in_old_hpp.Name = "in_old_hpp"
        Me.in_old_hpp.ReadOnly = True
        Me.in_old_hpp.Size = New System.Drawing.Size(200, 22)
        Me.in_old_hpp.TabIndex = 426
        Me.in_old_hpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'in_hpp
        '
        Me.in_hpp.BackColor = System.Drawing.Color.WhiteSmoke
        Me.in_hpp.Location = New System.Drawing.Point(68, 226)
        Me.in_hpp.Name = "in_hpp"
        Me.in_hpp.ReadOnly = True
        Me.in_hpp.Size = New System.Drawing.Size(176, 22)
        Me.in_hpp.TabIndex = 426
        Me.in_hpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_old_qty
        '
        Me.lbl_old_qty.AutoSize = True
        Me.lbl_old_qty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_old_qty.Location = New System.Drawing.Point(301, 178)
        Me.lbl_old_qty.Name = "lbl_old_qty"
        Me.lbl_old_qty.Size = New System.Drawing.Size(52, 13)
        Me.lbl_old_qty.TabIndex = 262
        Me.lbl_old_qty.Text = "Qty Lama"
        '
        'lbl_old_nilai
        '
        Me.lbl_old_nilai.AutoSize = True
        Me.lbl_old_nilai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_old_nilai.Location = New System.Drawing.Point(301, 204)
        Me.lbl_old_nilai.Name = "lbl_old_nilai"
        Me.lbl_old_nilai.Size = New System.Drawing.Size(56, 13)
        Me.lbl_old_nilai.TabIndex = 262
        Me.lbl_old_nilai.Text = "Nilai Lama"
        '
        'lbl_old_hpp
        '
        Me.lbl_old_hpp.AutoSize = True
        Me.lbl_old_hpp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_old_hpp.Location = New System.Drawing.Point(301, 230)
        Me.lbl_old_hpp.Name = "lbl_old_hpp"
        Me.lbl_old_hpp.Size = New System.Drawing.Size(58, 13)
        Me.lbl_old_hpp.TabIndex = 262
        Me.lbl_old_hpp.Text = "HPP Lama"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 262
        Me.Label7.Text = "Tgl Input"
        '
        'date_input
        '
        Me.date_input.Checked = False
        Me.date_input.Location = New System.Drawing.Point(68, 137)
        Me.date_input.Name = "date_input"
        Me.date_input.ShowCheckBox = True
        Me.date_input.Size = New System.Drawing.Size(208, 22)
        Me.date_input.TabIndex = 5
        '
        'fr_stok_awal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(593, 424)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.pnl_footer)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_stok_awal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setup Stok Awal"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_footer.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.in_qty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_nilai, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popPnl_barang.ResumeLayout(False)
        Me.popPnl_barang.PerformLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents pnl_footer As System.Windows.Forms.Panel
    Friend WithEvents bt_simpanreturbeli As System.Windows.Forms.Button
    Friend WithEvents bt_batalreturbeli As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_deact As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents in_qty As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_nilai As System.Windows.Forms.NumericUpDown
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents linkLbl_searchbarang As System.Windows.Forms.LinkLabel
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents in_barang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_barang As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang As System.Windows.Forms.TextBox
    Friend WithEvents in_id As System.Windows.Forms.TextBox
    Friend WithEvents in_old_qty As System.Windows.Forms.TextBox
    Friend WithEvents in_old_nilai As System.Windows.Forms.TextBox
    Friend WithEvents in_old_hpp As System.Windows.Forms.TextBox
    Friend WithEvents in_hpp As System.Windows.Forms.TextBox
    Friend WithEvents lbl_old_qty As System.Windows.Forms.Label
    Friend WithEvents lbl_old_nilai As System.Windows.Forms.Label
    Friend WithEvents lbl_old_hpp As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents date_input As System.Windows.Forms.DateTimePicker
End Class
