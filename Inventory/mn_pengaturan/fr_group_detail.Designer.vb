<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_group_detail
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
        Me.in_nama_group = New System.Windows.Forms.TextBox()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bt_batal_group = New System.Windows.Forms.Button()
        Me.bt_simpan_group = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_ket_group = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bt_tv_checkall_group = New System.Windows.Forms.Button()
        Me.bt_tv_reset = New System.Windows.Forms.Button()
        Me.tv_menu = New System.Windows.Forms.TreeView()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.in_status = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_actdeact = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_del = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'in_nama_group
        '
        Me.in_nama_group.BackColor = System.Drawing.Color.White
        Me.in_nama_group.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_nama_group.ForeColor = System.Drawing.Color.Black
        Me.in_nama_group.Location = New System.Drawing.Point(12, 83)
        Me.in_nama_group.MaxLength = 30
        Me.in_nama_group.Name = "in_nama_group"
        Me.in_nama_group.Size = New System.Drawing.Size(252, 20)
        Me.in_nama_group.TabIndex = 0
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.Gainsboro
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.ForeColor = System.Drawing.Color.Black
        Me.in_kode.Location = New System.Drawing.Point(51, 31)
        Me.in_kode.Name = "in_kode"
        Me.in_kode.ReadOnly = True
        Me.in_kode.Size = New System.Drawing.Size(112, 20)
        Me.in_kode.TabIndex = 0
        Me.in_kode.TabStop = False
        Me.in_kode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Nama Group"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Kode"
        '
        'bt_batal_group
        '
        Me.bt_batal_group.BackColor = System.Drawing.Color.Tomato
        Me.bt_batal_group.FlatAppearance.BorderSize = 0
        Me.bt_batal_group.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_batal_group.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batal_group.ForeColor = System.Drawing.Color.White
        Me.bt_batal_group.Location = New System.Drawing.Point(497, 460)
        Me.bt_batal_group.Name = "bt_batal_group"
        Me.bt_batal_group.Size = New System.Drawing.Size(96, 30)
        Me.bt_batal_group.TabIndex = 12
        Me.bt_batal_group.Text = "Keluar"
        Me.bt_batal_group.UseVisualStyleBackColor = False
        '
        'bt_simpan_group
        '
        Me.bt_simpan_group.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpan_group.FlatAppearance.BorderSize = 0
        Me.bt_simpan_group.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpan_group.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpan_group.ForeColor = System.Drawing.Color.White
        Me.bt_simpan_group.Location = New System.Drawing.Point(365, 460)
        Me.bt_simpan_group.Name = "bt_simpan_group"
        Me.bt_simpan_group.Size = New System.Drawing.Size(129, 30)
        Me.bt_simpan_group.TabIndex = 11
        Me.bt_simpan_group.Text = "Simpan"
        Me.bt_simpan_group.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Keterangan"
        '
        'in_ket_group
        '
        Me.in_ket_group.BackColor = System.Drawing.Color.White
        Me.in_ket_group.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket_group.ForeColor = System.Drawing.Color.Black
        Me.in_ket_group.Location = New System.Drawing.Point(12, 127)
        Me.in_ket_group.MaxLength = 300
        Me.in_ket_group.Multiline = True
        Me.in_ket_group.Name = "in_ket_group"
        Me.in_ket_group.Size = New System.Drawing.Size(252, 72)
        Me.in_ket_group.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(275, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Akses Menu"
        '
        'bt_tv_checkall_group
        '
        Me.bt_tv_checkall_group.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_tv_checkall_group.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tv_checkall_group.Location = New System.Drawing.Point(497, 27)
        Me.bt_tv_checkall_group.Name = "bt_tv_checkall_group"
        Me.bt_tv_checkall_group.Size = New System.Drawing.Size(96, 24)
        Me.bt_tv_checkall_group.TabIndex = 9
        Me.bt_tv_checkall_group.Text = "Pilih Semua"
        Me.bt_tv_checkall_group.UseVisualStyleBackColor = True
        '
        'bt_tv_reset
        '
        Me.bt_tv_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_tv_reset.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tv_reset.Location = New System.Drawing.Point(398, 27)
        Me.bt_tv_reset.Name = "bt_tv_reset"
        Me.bt_tv_reset.Size = New System.Drawing.Size(96, 24)
        Me.bt_tv_reset.TabIndex = 8
        Me.bt_tv_reset.Text = "Uncheck"
        Me.bt_tv_reset.UseVisualStyleBackColor = True
        '
        'tv_menu
        '
        Me.tv_menu.CheckBoxes = True
        Me.tv_menu.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tv_menu.FullRowSelect = True
        Me.tv_menu.Location = New System.Drawing.Point(278, 54)
        Me.tv_menu.Name = "tv_menu"
        Me.tv_menu.Size = New System.Drawing.Size(315, 400)
        Me.tv_menu.TabIndex = 10
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(54, 391)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(146, 20)
        Me.txtRegAlias.TabIndex = 4
        Me.txtRegAlias.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(9, 394)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 13)
        Me.Label12.TabIndex = 119
        Me.Label12.Text = "RegBy"
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(54, 438)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(146, 20)
        Me.txtUpdAlias.TabIndex = 6
        Me.txtUpdAlias.TabStop = False
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(54, 413)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(146, 20)
        Me.txtRegdate.TabIndex = 5
        Me.txtRegdate.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(9, 441)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 13)
        Me.Label17.TabIndex = 125
        Me.Label17.Text = "UpdBy"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(18, 416)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 118
        Me.Label11.Text = "Date"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(18, 463)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(30, 13)
        Me.Label18.TabIndex = 124
        Me.Label18.Text = "Date"
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(54, 460)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(146, 20)
        Me.txtUpdDate.TabIndex = 7
        Me.txtUpdDate.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 538)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(600, 10)
        Me.Panel1.TabIndex = 347
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Controls.Add(Me.lbl_close)
        Me.Panel2.Controls.Add(Me.bt_cl)
        Me.Panel2.Controls.Add(Me.lbl_title)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(600, 42)
        Me.Panel2.TabIndex = 346
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(520, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(573, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 20
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
        Me.lbl_title.Size = New System.Drawing.Size(189, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Data Group User"
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.in_status)
        Me.Panel3.Controls.Add(Me.txtUpdAlias)
        Me.Panel3.Controls.Add(Me.txtRegAlias)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.txtRegdate)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.txtUpdDate)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.MenuStrip1)
        Me.Panel3.Controls.Add(Me.bt_tv_reset)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.tv_menu)
        Me.Panel3.Controls.Add(Me.in_kode)
        Me.Panel3.Controls.Add(Me.bt_tv_checkall_group)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.bt_batal_group)
        Me.Panel3.Controls.Add(Me.in_nama_group)
        Me.Panel3.Controls.Add(Me.in_ket_group)
        Me.Panel3.Controls.Add(Me.bt_simpan_group)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(0, 42)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(600, 496)
        Me.Panel3.TabIndex = 348
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 341)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 346
        Me.Label6.Text = "Status"
        '
        'in_status
        '
        Me.in_status.BackColor = System.Drawing.Color.White
        Me.in_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status.ForeColor = System.Drawing.Color.Black
        Me.in_status.Location = New System.Drawing.Point(54, 340)
        Me.in_status.MaxLength = 2
        Me.in_status.Name = "in_status"
        Me.in_status.Size = New System.Drawing.Size(112, 20)
        Me.in_status.TabIndex = 3
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_actdeact, Me.mn_del})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(600, 24)
        Me.MenuStrip1.TabIndex = 344
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
        'mn_actdeact
        '
        Me.mn_actdeact.Name = "mn_actdeact"
        Me.mn_actdeact.Size = New System.Drawing.Size(74, 20)
        Me.mn_actdeact.Text = "Deactivate"
        '
        'mn_del
        '
        Me.mn_del.Enabled = False
        Me.mn_del.Name = "mn_del"
        Me.mn_del.Size = New System.Drawing.Size(53, 20)
        Me.mn_del.Text = "Hapus"
        '
        'fr_group_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(600, 548)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fr_group_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detail User Group : "
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents in_nama_group As System.Windows.Forms.TextBox
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents bt_batal_group As System.Windows.Forms.Button
    Friend WithEvents bt_simpan_group As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_ket_group As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bt_tv_checkall_group As System.Windows.Forms.Button
    Friend WithEvents bt_tv_reset As System.Windows.Forms.Button
    Friend WithEvents tv_menu As System.Windows.Forms.TreeView
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_actdeact As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents in_status As System.Windows.Forms.TextBox
End Class
