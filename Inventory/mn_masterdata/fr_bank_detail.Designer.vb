<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_bank_detail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_bank_detail))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.pnl_Menu = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_deact = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_del = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.in_namabank = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_pos = New System.Windows.Forms.TextBox()
        Me.bt_pos = New System.Windows.Forms.Button()
        Me.cb_pos = New System.Windows.Forms.ComboBox()
        Me.bt_batalcusto = New System.Windows.Forms.Button()
        Me.bt_simpancusto = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cb_status = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.pnl_Menu.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(427, 42)
        Me.Panel1.TabIndex = 277
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(347, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(400, 9)
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
        Me.lbl_title.Size = New System.Drawing.Size(201, 30)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Data Master Bank"
        '
        'pnl_Menu
        '
        Me.pnl_Menu.Controls.Add(Me.MenuStrip1)
        Me.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Menu.Location = New System.Drawing.Point(0, 42)
        Me.pnl_Menu.Name = "pnl_Menu"
        Me.pnl_Menu.Size = New System.Drawing.Size(427, 30)
        Me.pnl_Menu.TabIndex = 280
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_deact, Me.mn_del})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(427, 24)
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
        '
        'mn_del
        '
        Me.mn_del.Name = "mn_del"
        Me.mn_del.Size = New System.Drawing.Size(53, 20)
        Me.mn_del.Text = "Hapus"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 292)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(427, 10)
        Me.Panel2.TabIndex = 281
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.White
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.ForeColor = System.Drawing.Color.Black
        Me.in_kode.Location = New System.Drawing.Point(50, 81)
        Me.in_kode.MaxLength = 10
        Me.in_kode.Name = "in_kode"
        Me.in_kode.Size = New System.Drawing.Size(160, 20)
        Me.in_kode.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 285
        Me.Label4.Text = "Kode"
        '
        'in_namabank
        '
        Me.in_namabank.BackColor = System.Drawing.Color.White
        Me.in_namabank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_namabank.ForeColor = System.Drawing.Color.Black
        Me.in_namabank.Location = New System.Drawing.Point(50, 103)
        Me.in_namabank.MaxLength = 100
        Me.in_namabank.Name = "in_namabank"
        Me.in_namabank.Size = New System.Drawing.Size(314, 20)
        Me.in_namabank.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 284
        Me.Label3.Text = "Nama"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 285
        Me.Label1.Text = "Pos"
        '
        'in_pos
        '
        Me.in_pos.BackColor = System.Drawing.Color.White
        Me.in_pos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_pos.ForeColor = System.Drawing.Color.Black
        Me.in_pos.Location = New System.Drawing.Point(50, 125)
        Me.in_pos.MaxLength = 10
        Me.in_pos.Name = "in_pos"
        Me.in_pos.Size = New System.Drawing.Size(95, 20)
        Me.in_pos.TabIndex = 2
        '
        'bt_pos
        '
        Me.bt_pos.BackColor = System.Drawing.Color.Transparent
        Me.bt_pos.BackgroundImage = CType(resources.GetObject("bt_pos.BackgroundImage"), System.Drawing.Image)
        Me.bt_pos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_pos.FlatAppearance.BorderSize = 0
        Me.bt_pos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_pos.Location = New System.Drawing.Point(370, 128)
        Me.bt_pos.Name = "bt_pos"
        Me.bt_pos.Size = New System.Drawing.Size(12, 15)
        Me.bt_pos.TabIndex = 4
        Me.bt_pos.TabStop = False
        Me.bt_pos.UseVisualStyleBackColor = False
        '
        'cb_pos
        '
        Me.cb_pos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_pos.FormattingEnabled = True
        Me.cb_pos.Location = New System.Drawing.Point(145, 125)
        Me.cb_pos.Name = "cb_pos"
        Me.cb_pos.Size = New System.Drawing.Size(219, 21)
        Me.cb_pos.TabIndex = 3
        '
        'bt_batalcusto
        '
        Me.bt_batalcusto.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalcusto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalcusto.Location = New System.Drawing.Point(319, 245)
        Me.bt_batalcusto.Name = "bt_batalcusto"
        Me.bt_batalcusto.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalcusto.TabIndex = 7
        Me.bt_batalcusto.Text = "Batal"
        Me.bt_batalcusto.UseVisualStyleBackColor = True
        '
        'bt_simpancusto
        '
        Me.bt_simpancusto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpancusto.Location = New System.Drawing.Point(217, 245)
        Me.bt_simpancusto.Name = "bt_simpancusto"
        Me.bt_simpancusto.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpancusto.TabIndex = 6
        Me.bt_simpancusto.Text = "Simpan"
        Me.bt_simpancusto.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(12, 258)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 13)
        Me.Label30.TabIndex = 323
        Me.Label30.Text = "Date"
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(53, 233)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtUpdAlias.TabIndex = 322
        Me.txtUpdAlias.TabStop = False
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(53, 255)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(150, 20)
        Me.txtUpdDate.TabIndex = 317
        Me.txtUpdDate.TabStop = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(53, 185)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtRegAlias.TabIndex = 319
        Me.txtRegAlias.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(12, 236)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(39, 13)
        Me.Label28.TabIndex = 324
        Me.Label28.Text = "UpdBy"
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(53, 207)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(150, 20)
        Me.txtRegdate.TabIndex = 318
        Me.txtRegdate.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(12, 188)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(39, 13)
        Me.Label27.TabIndex = 321
        Me.Label27.Text = "RegBy"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(12, 210)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(30, 13)
        Me.Label29.TabIndex = 320
        Me.Label29.Text = "Date"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 151)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 326
        Me.Label13.Text = "Status"
        '
        'cb_status
        '
        Me.cb_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_status.FormattingEnabled = True
        Me.cb_status.Location = New System.Drawing.Point(50, 148)
        Me.cb_status.Name = "cb_status"
        Me.cb_status.Size = New System.Drawing.Size(170, 21)
        Me.cb_status.TabIndex = 5
        '
        'fr_bank_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(427, 302)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cb_status)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtUpdAlias)
        Me.Controls.Add(Me.txtUpdDate)
        Me.Controls.Add(Me.txtRegAlias)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtRegdate)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.bt_batalcusto)
        Me.Controls.Add(Me.bt_simpancusto)
        Me.Controls.Add(Me.bt_pos)
        Me.Controls.Add(Me.cb_pos)
        Me.Controls.Add(Me.in_pos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.in_kode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.in_namabank)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnl_Menu)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fr_bank_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Bank : "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_Menu.ResumeLayout(False)
        Me.pnl_Menu.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents pnl_Menu As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_deact As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents in_namabank As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_pos As System.Windows.Forms.TextBox
    Friend WithEvents bt_pos As System.Windows.Forms.Button
    Friend WithEvents cb_pos As System.Windows.Forms.ComboBox
    Friend WithEvents bt_batalcusto As System.Windows.Forms.Button
    Friend WithEvents bt_simpancusto As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cb_status As System.Windows.Forms.ComboBox
End Class
