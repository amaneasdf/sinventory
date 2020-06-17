<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_gudang_detail
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_gudang_detail))
        Me.pnl_header = New System.Windows.Forms.Panel()
        Me.bt_menu = New System.Windows.Forms.Button()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_alamatgudang = New System.Windows.Forms.TextBox()
        Me.in_namagudang = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.in_status = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnl_footer = New System.Windows.Forms.Panel()
        Me.bt_batalcusto = New System.Windows.Forms.Button()
        Me.bt_simpancusto = New System.Windows.Forms.Button()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.ctx_main = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tstrip_simpan = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstrip_status = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstrip_activate = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstrip_inactivate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tstrip_delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsrtip_close = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnl_header.SuspendLayout()
        Me.pnl_footer.SuspendLayout()
        Me.pnl_content.SuspendLayout()
        Me.ctx_main.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_header
        '
        Me.pnl_header.BackColor = System.Drawing.Color.White
        Me.pnl_header.Controls.Add(Me.bt_menu)
        Me.pnl_header.Controls.Add(Me.bt_cl)
        Me.pnl_header.Controls.Add(Me.lbl_title)
        Me.pnl_header.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_header.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_header.Location = New System.Drawing.Point(0, 0)
        Me.pnl_header.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.pnl_header.Name = "pnl_header"
        Me.pnl_header.Size = New System.Drawing.Size(533, 42)
        Me.pnl_header.TabIndex = 1
        '
        'bt_menu
        '
        Me.bt_menu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_menu.BackColor = System.Drawing.Color.DarkOrange
        Me.bt_menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_menu.FlatAppearance.BorderSize = 0
        Me.bt_menu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange
        Me.bt_menu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed
        Me.bt_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_menu.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_menu.Image = Global.Inventory.My.Resources.Resources.menu_wh_thin_16x16
        Me.bt_menu.Location = New System.Drawing.Point(0, 5)
        Me.bt_menu.Name = "bt_menu"
        Me.bt_menu.Size = New System.Drawing.Size(32, 32)
        Me.bt_menu.TabIndex = 428
        Me.bt_menu.TabStop = False
        Me.bt_menu.UseVisualStyleBackColor = False
        '
        'bt_cl
        '
        Me.bt_cl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_cl.BackColor = System.Drawing.Color.Brown
        Me.bt_cl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_cl.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_cl.FlatAppearance.BorderSize = 0
        Me.bt_cl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tomato
        Me.bt_cl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.bt_cl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cl.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cl.Image = Global.Inventory.My.Resources.Resources.close_wh_thin_16x16
        Me.bt_cl.Location = New System.Drawing.Point(475, 0)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(55, 30)
        Me.bt_cl.TabIndex = 0
        Me.bt_cl.TabStop = False
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Transparent
        Me.lbl_title.Font = New System.Drawing.Font("Open Sans", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_title.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbl_title.Location = New System.Drawing.Point(37, 5)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(145, 26)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Detail Gudang"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nama Gudang"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 15)
        Me.Label5.TabIndex = 401
        Me.Label5.Text = "Alamat"
        '
        'in_alamatgudang
        '
        Me.in_alamatgudang.BackColor = System.Drawing.Color.White
        Me.in_alamatgudang.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamatgudang.ForeColor = System.Drawing.Color.Black
        Me.in_alamatgudang.Location = New System.Drawing.Point(117, 61)
        Me.in_alamatgudang.MaxLength = 200
        Me.in_alamatgudang.Multiline = True
        Me.in_alamatgudang.Name = "in_alamatgudang"
        Me.in_alamatgudang.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_alamatgudang.Size = New System.Drawing.Size(336, 84)
        Me.in_alamatgudang.TabIndex = 2
        '
        'in_namagudang
        '
        Me.in_namagudang.BackColor = System.Drawing.Color.White
        Me.in_namagudang.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_namagudang.ForeColor = System.Drawing.Color.Black
        Me.in_namagudang.Location = New System.Drawing.Point(117, 37)
        Me.in_namagudang.MaxLength = 50
        Me.in_namagudang.Name = "in_namagudang"
        Me.in_namagudang.Size = New System.Drawing.Size(336, 22)
        Me.in_namagudang.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 478)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(533, 5)
        Me.Panel2.TabIndex = 0
        '
        'in_status
        '
        Me.in_status.BackColor = System.Drawing.Color.Gainsboro
        Me.in_status.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status.ForeColor = System.Drawing.Color.Black
        Me.in_status.Location = New System.Drawing.Point(117, 227)
        Me.in_status.MaxLength = 10
        Me.in_status.Name = "in_status"
        Me.in_status.ReadOnly = True
        Me.in_status.Size = New System.Drawing.Size(153, 22)
        Me.in_status.TabIndex = 15
        Me.in_status.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 230)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 15)
        Me.Label13.TabIndex = 170
        Me.Label13.Text = "Status"
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.White
        Me.in_kode.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.ForeColor = System.Drawing.Color.Black
        Me.in_kode.Location = New System.Drawing.Point(117, 9)
        Me.in_kode.MaxLength = 10
        Me.in_kode.Name = "in_kode"
        Me.in_kode.Size = New System.Drawing.Size(153, 22)
        Me.in_kode.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 15)
        Me.Label4.TabIndex = 166
        Me.Label4.Text = "Kode"
        '
        'in_ket
        '
        Me.in_ket.BackColor = System.Drawing.Color.White
        Me.in_ket.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.ForeColor = System.Drawing.Color.Black
        Me.in_ket.Location = New System.Drawing.Point(117, 157)
        Me.in_ket.MaxLength = 500
        Me.in_ket.Multiline = True
        Me.in_ket.Name = "in_ket"
        Me.in_ket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_ket.Size = New System.Drawing.Size(336, 56)
        Me.in_ket.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 419
        Me.Label2.Text = "Keterangan"
        '
        'pnl_footer
        '
        Me.pnl_footer.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnl_footer.Controls.Add(Me.bt_batalcusto)
        Me.pnl_footer.Controls.Add(Me.bt_simpancusto)
        Me.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_footer.Location = New System.Drawing.Point(0, 431)
        Me.pnl_footer.Name = "pnl_footer"
        Me.pnl_footer.Size = New System.Drawing.Size(533, 47)
        Me.pnl_footer.TabIndex = 1
        '
        'bt_batalcusto
        '
        Me.bt_batalcusto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_batalcusto.BackColor = System.Drawing.Color.Tomato
        Me.bt_batalcusto.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalcusto.FlatAppearance.BorderSize = 0
        Me.bt_batalcusto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_batalcusto.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalcusto.ForeColor = System.Drawing.Color.White
        Me.bt_batalcusto.Location = New System.Drawing.Point(425, 6)
        Me.bt_batalcusto.Name = "bt_batalcusto"
        Me.bt_batalcusto.Size = New System.Drawing.Size(96, 35)
        Me.bt_batalcusto.TabIndex = 27
        Me.bt_batalcusto.Text = "Batal"
        Me.bt_batalcusto.UseVisualStyleBackColor = False
        '
        'bt_simpancusto
        '
        Me.bt_simpancusto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_simpancusto.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpancusto.FlatAppearance.BorderSize = 0
        Me.bt_simpancusto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpancusto.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpancusto.ForeColor = System.Drawing.Color.White
        Me.bt_simpancusto.Location = New System.Drawing.Point(265, 6)
        Me.bt_simpancusto.Name = "bt_simpancusto"
        Me.bt_simpancusto.Size = New System.Drawing.Size(154, 35)
        Me.bt_simpancusto.TabIndex = 26
        Me.bt_simpancusto.Text = "Simpan"
        Me.bt_simpancusto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_simpancusto.UseVisualStyleBackColor = False
        '
        'pnl_content
        '
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.Controls.Add(Me.txtRegdate)
        Me.pnl_content.Controls.Add(Me.Label28)
        Me.pnl_content.Controls.Add(Me.Label30)
        Me.pnl_content.Controls.Add(Me.txtUpdDate)
        Me.pnl_content.Controls.Add(Me.Label29)
        Me.pnl_content.Controls.Add(Me.txtUpdAlias)
        Me.pnl_content.Controls.Add(Me.txtRegAlias)
        Me.pnl_content.Controls.Add(Me.Label27)
        Me.pnl_content.Controls.Add(Me.in_status)
        Me.pnl_content.Controls.Add(Me.Label13)
        Me.pnl_content.Controls.Add(Me.Label4)
        Me.pnl_content.Controls.Add(Me.in_namagudang)
        Me.pnl_content.Controls.Add(Me.in_ket)
        Me.pnl_content.Controls.Add(Me.in_alamatgudang)
        Me.pnl_content.Controls.Add(Me.Label2)
        Me.pnl_content.Controls.Add(Me.Label5)
        Me.pnl_content.Controls.Add(Me.in_kode)
        Me.pnl_content.Controls.Add(Me.Label3)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_content.Location = New System.Drawing.Point(0, 42)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(533, 389)
        Me.pnl_content.TabIndex = 0
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(117, 315)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(178, 22)
        Me.txtRegdate.TabIndex = 420
        Me.txtRegdate.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(12, 343)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(66, 15)
        Me.Label28.TabIndex = 427
        Me.Label28.Text = "LastUpdate"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(301, 343)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(20, 15)
        Me.Label30.TabIndex = 426
        Me.Label30.Text = "By"
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(117, 339)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(178, 22)
        Me.txtUpdDate.TabIndex = 421
        Me.txtUpdDate.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(12, 318)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(48, 15)
        Me.Label29.TabIndex = 423
        Me.Label29.Text = "Inputed"
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(324, 339)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(112, 22)
        Me.txtUpdAlias.TabIndex = 425
        Me.txtUpdAlias.TabStop = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(324, 315)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(112, 22)
        Me.txtRegAlias.TabIndex = 422
        Me.txtRegAlias.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(301, 319)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(20, 15)
        Me.Label27.TabIndex = 424
        Me.Label27.Text = "By"
        '
        'ctx_main
        '
        Me.ctx_main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstrip_simpan, Me.tstrip_status, Me.ToolStripSeparator1, Me.tsrtip_close})
        Me.ctx_main.Name = "ctx_main"
        Me.ctx_main.Size = New System.Drawing.Size(165, 76)
        '
        'tstrip_simpan
        '
        Me.tstrip_simpan.Name = "tstrip_simpan"
        Me.tstrip_simpan.Size = New System.Drawing.Size(164, 22)
        Me.tstrip_simpan.Text = "Simpan"
        '
        'tstrip_status
        '
        Me.tstrip_status.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstrip_activate, Me.tstrip_inactivate, Me.ToolStripSeparator2, Me.tstrip_delete})
        Me.tstrip_status.Name = "tstrip_status"
        Me.tstrip_status.Size = New System.Drawing.Size(164, 22)
        Me.tstrip_status.Text = "Ubah Status Data"
        '
        'tstrip_activate
        '
        Me.tstrip_activate.Name = "tstrip_activate"
        Me.tstrip_activate.Size = New System.Drawing.Size(166, 22)
        Me.tstrip_activate.Text = "Aktifkan Data"
        '
        'tstrip_inactivate
        '
        Me.tstrip_inactivate.Name = "tstrip_inactivate"
        Me.tstrip_inactivate.Size = New System.Drawing.Size(166, 22)
        Me.tstrip_inactivate.Text = "Nonaktifkan Data"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(163, 6)
        '
        'tstrip_delete
        '
        Me.tstrip_delete.Name = "tstrip_delete"
        Me.tstrip_delete.Size = New System.Drawing.Size(166, 22)
        Me.tstrip_delete.Text = "Hapus Data"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(161, 6)
        '
        'tsrtip_close
        '
        Me.tsrtip_close.Name = "tsrtip_close"
        Me.tsrtip_close.Size = New System.Drawing.Size(164, 22)
        Me.tsrtip_close.Text = "Tutup Form"
        '
        'fr_gudang_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(533, 483)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.pnl_footer)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnl_header)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_gudang_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Gudang : "
        Me.pnl_header.ResumeLayout(False)
        Me.pnl_header.PerformLayout()
        Me.pnl_footer.ResumeLayout(False)
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.ctx_main.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_header As System.Windows.Forms.Panel
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_alamatgudang As System.Windows.Forms.TextBox
    Friend WithEvents in_namagudang As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents in_status As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnl_footer As System.Windows.Forms.Panel
    Friend WithEvents bt_batalcusto As System.Windows.Forms.Button
    Friend WithEvents bt_simpancusto As System.Windows.Forms.Button
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents bt_menu As System.Windows.Forms.Button
    Friend WithEvents ctx_main As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tstrip_simpan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstrip_status As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstrip_activate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstrip_inactivate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstrip_delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsrtip_close As System.Windows.Forms.ToolStripMenuItem
End Class
