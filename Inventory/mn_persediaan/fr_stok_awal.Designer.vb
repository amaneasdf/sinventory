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
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.in_nilai = New System.Windows.Forms.NumericUpDown()
        Me.in_hpp = New System.Windows.Forms.NumericUpDown()
        Me.in_qty = New System.Windows.Forms.NumericUpDown()
        Me.in_barang_n = New System.Windows.Forms.TextBox()
        Me.in_tgl = New System.Windows.Forms.TextBox()
        Me.in_barang = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_gudang_n = New System.Windows.Forms.TextBox()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.in_gudang = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_deact = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_del = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.pnl_footer = New System.Windows.Forms.Panel()
        Me.bt_simpanreturbeli = New System.Windows.Forms.Button()
        Me.bt_batalreturbeli = New System.Windows.Forms.Button()
        Me.pnl_content.SuspendLayout()
        CType(Me.in_nilai, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_hpp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnl_footer.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 366)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(551, 10)
        Me.Panel2.TabIndex = 284
        '
        'pnl_content
        '
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.Controls.Add(Me.in_nilai)
        Me.pnl_content.Controls.Add(Me.in_hpp)
        Me.pnl_content.Controls.Add(Me.in_qty)
        Me.pnl_content.Controls.Add(Me.in_barang_n)
        Me.pnl_content.Controls.Add(Me.in_tgl)
        Me.pnl_content.Controls.Add(Me.in_barang)
        Me.pnl_content.Controls.Add(Me.Label6)
        Me.pnl_content.Controls.Add(Me.Label5)
        Me.pnl_content.Controls.Add(Me.Label4)
        Me.pnl_content.Controls.Add(Me.Label7)
        Me.pnl_content.Controls.Add(Me.Label1)
        Me.pnl_content.Controls.Add(Me.in_gudang_n)
        Me.pnl_content.Controls.Add(Me.in_kode)
        Me.pnl_content.Controls.Add(Me.in_gudang)
        Me.pnl_content.Controls.Add(Me.Label2)
        Me.pnl_content.Controls.Add(Me.Label3)
        Me.pnl_content.Controls.Add(Me.MenuStrip1)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Location = New System.Drawing.Point(0, 42)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(551, 278)
        Me.pnl_content.TabIndex = 0
        '
        'in_nilai
        '
        Me.in_nilai.DecimalPlaces = 2
        Me.in_nilai.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_nilai.Location = New System.Drawing.Point(70, 228)
        Me.in_nilai.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 0})
        Me.in_nilai.Minimum = New Decimal(New Integer() {276447231, 23283, 0, -2147483648})
        Me.in_nilai.Name = "in_nilai"
        Me.in_nilai.Size = New System.Drawing.Size(196, 24)
        Me.in_nilai.TabIndex = 9
        Me.in_nilai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_nilai.ThousandsSeparator = True
        '
        'in_hpp
        '
        Me.in_hpp.DecimalPlaces = 2
        Me.in_hpp.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_hpp.Location = New System.Drawing.Point(70, 202)
        Me.in_hpp.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 0})
        Me.in_hpp.Name = "in_hpp"
        Me.in_hpp.Size = New System.Drawing.Size(196, 24)
        Me.in_hpp.TabIndex = 8
        Me.in_hpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_hpp.ThousandsSeparator = True
        '
        'in_qty
        '
        Me.in_qty.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty.Location = New System.Drawing.Point(70, 168)
        Me.in_qty.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.in_qty.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.in_qty.Name = "in_qty"
        Me.in_qty.Size = New System.Drawing.Size(137, 24)
        Me.in_qty.TabIndex = 7
        Me.in_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_qty.ThousandsSeparator = True
        '
        'in_barang_n
        '
        Me.in_barang_n.BackColor = System.Drawing.Color.White
        Me.in_barang_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang_n.ForeColor = System.Drawing.Color.Black
        Me.in_barang_n.Location = New System.Drawing.Point(159, 98)
        Me.in_barang_n.MaxLength = 200
        Me.in_barang_n.Name = "in_barang_n"
        Me.in_barang_n.ReadOnly = True
        Me.in_barang_n.Size = New System.Drawing.Size(273, 20)
        Me.in_barang_n.TabIndex = 5
        '
        'in_tgl
        '
        Me.in_tgl.BackColor = System.Drawing.Color.Gainsboro
        Me.in_tgl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_tgl.ForeColor = System.Drawing.Color.Black
        Me.in_tgl.Location = New System.Drawing.Point(60, 136)
        Me.in_tgl.MaxLength = 30
        Me.in_tgl.Name = "in_tgl"
        Me.in_tgl.ReadOnly = True
        Me.in_tgl.Size = New System.Drawing.Size(206, 20)
        Me.in_tgl.TabIndex = 6
        '
        'in_barang
        '
        Me.in_barang.BackColor = System.Drawing.Color.Gainsboro
        Me.in_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang.ForeColor = System.Drawing.Color.Black
        Me.in_barang.Location = New System.Drawing.Point(60, 98)
        Me.in_barang.MaxLength = 30
        Me.in_barang.Name = "in_barang"
        Me.in_barang.ReadOnly = True
        Me.in_barang.Size = New System.Drawing.Size(98, 20)
        Me.in_barang.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "Nilai Awal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 208)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 262
        Me.Label5.Text = "HPP"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 262
        Me.Label4.Text = "QTY Awal"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(22, 13)
        Me.Label7.TabIndex = 262
        Me.Label7.Text = "Tgl"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 262
        Me.Label1.Text = "Barang"
        '
        'in_gudang_n
        '
        Me.in_gudang_n.BackColor = System.Drawing.Color.White
        Me.in_gudang_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang_n.ForeColor = System.Drawing.Color.Black
        Me.in_gudang_n.Location = New System.Drawing.Point(159, 76)
        Me.in_gudang_n.MaxLength = 200
        Me.in_gudang_n.Name = "in_gudang_n"
        Me.in_gudang_n.ReadOnly = True
        Me.in_gudang_n.Size = New System.Drawing.Size(273, 20)
        Me.in_gudang_n.TabIndex = 3
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.Gainsboro
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.ForeColor = System.Drawing.Color.Black
        Me.in_kode.Location = New System.Drawing.Point(60, 35)
        Me.in_kode.MaxLength = 30
        Me.in_kode.Name = "in_kode"
        Me.in_kode.ReadOnly = True
        Me.in_kode.Size = New System.Drawing.Size(206, 20)
        Me.in_kode.TabIndex = 0
        '
        'in_gudang
        '
        Me.in_gudang.BackColor = System.Drawing.Color.Gainsboro
        Me.in_gudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang.ForeColor = System.Drawing.Color.Black
        Me.in_gudang.Location = New System.Drawing.Point(60, 76)
        Me.in_gudang.MaxLength = 30
        Me.in_gudang.Name = "in_gudang"
        Me.in_gudang.ReadOnly = True
        Me.in_gudang.Size = New System.Drawing.Size(98, 20)
        Me.in_gudang.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 13)
        Me.Label2.TabIndex = 259
        Me.Label2.Text = "ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 259
        Me.Label3.Text = "Gudang"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_deact, Me.mn_del})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(551, 24)
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.lbl_close)
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.lbl_title)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(551, 42)
        Me.Panel1.TabIndex = 282
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(471, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(524, 9)
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
        Me.lbl_title.Size = New System.Drawing.Size(119, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Stok Awal"
        '
        'pnl_footer
        '
        Me.pnl_footer.BackColor = System.Drawing.Color.Gainsboro
        Me.pnl_footer.Controls.Add(Me.bt_simpanreturbeli)
        Me.pnl_footer.Controls.Add(Me.bt_batalreturbeli)
        Me.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_footer.Location = New System.Drawing.Point(0, 320)
        Me.pnl_footer.Name = "pnl_footer"
        Me.pnl_footer.Size = New System.Drawing.Size(551, 46)
        Me.pnl_footer.TabIndex = 14
        '
        'bt_simpanreturbeli
        '
        Me.bt_simpanreturbeli.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpanreturbeli.FlatAppearance.BorderSize = 0
        Me.bt_simpanreturbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpanreturbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanreturbeli.ForeColor = System.Drawing.Color.White
        Me.bt_simpanreturbeli.Location = New System.Drawing.Point(271, 10)
        Me.bt_simpanreturbeli.Name = "bt_simpanreturbeli"
        Me.bt_simpanreturbeli.Size = New System.Drawing.Size(161, 30)
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
        Me.bt_batalreturbeli.Location = New System.Drawing.Point(438, 10)
        Me.bt_batalreturbeli.Name = "bt_batalreturbeli"
        Me.bt_batalreturbeli.Size = New System.Drawing.Size(106, 30)
        Me.bt_batalreturbeli.TabIndex = 16
        Me.bt_batalreturbeli.Text = "Batal"
        Me.bt_batalreturbeli.UseVisualStyleBackColor = False
        '
        'fr_stok_awal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(551, 376)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.pnl_footer)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_stok_awal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Setup Stok Awal"
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        CType(Me.in_nilai, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_hpp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_qty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_footer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_deact As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents pnl_footer As System.Windows.Forms.Panel
    Friend WithEvents bt_simpanreturbeli As System.Windows.Forms.Button
    Friend WithEvents bt_batalreturbeli As System.Windows.Forms.Button
    Friend WithEvents in_gudang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents in_barang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_barang As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_nilai As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_hpp As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_qty As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_tgl As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
