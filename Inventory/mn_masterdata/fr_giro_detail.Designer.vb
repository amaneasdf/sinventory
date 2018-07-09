<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_giro_detail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_giro_detail))
        Me.bt_batalgiro = New System.Windows.Forms.Button()
        Me.bt_simpangiro = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_kode_sales = New System.Windows.Forms.TextBox()
        Me.cb_status = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_kode_custo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.in_nobg = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_bank = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.in_jumlah = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.date_tgl = New System.Windows.Forms.DateTimePicker()
        Me.date_tgl_bg = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.pnl_Menu = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_deact = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_del = New System.Windows.Forms.ToolStripMenuItem()
        Me.cb_sales = New System.Windows.Forms.ComboBox()
        Me.cb_custo = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.bt_pos = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.in_jumlah, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_Menu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bt_batalgiro
        '
        Me.bt_batalgiro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalgiro.Location = New System.Drawing.Point(525, 366)
        Me.bt_batalgiro.Name = "bt_batalgiro"
        Me.bt_batalgiro.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalgiro.TabIndex = 9
        Me.bt_batalgiro.Text = "Batal"
        Me.bt_batalgiro.UseVisualStyleBackColor = True
        '
        'bt_simpangiro
        '
        Me.bt_simpangiro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpangiro.Location = New System.Drawing.Point(423, 366)
        Me.bt_simpangiro.Name = "bt_simpangiro"
        Me.bt_simpangiro.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpangiro.TabIndex = 8
        Me.bt_simpangiro.Text = "Simpan"
        Me.bt_simpangiro.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 170
        Me.Label4.Text = "Tanggal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Salesman"
        '
        'in_kode_sales
        '
        Me.in_kode_sales.BackColor = System.Drawing.Color.White
        Me.in_kode_sales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode_sales.ForeColor = System.Drawing.Color.Black
        Me.in_kode_sales.Location = New System.Drawing.Point(97, 104)
        Me.in_kode_sales.MaxLength = 10
        Me.in_kode_sales.Name = "in_kode_sales"
        Me.in_kode_sales.Size = New System.Drawing.Size(110, 20)
        Me.in_kode_sales.TabIndex = 1
        '
        'cb_status
        '
        Me.cb_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_status.FormattingEnabled = True
        Me.cb_status.Location = New System.Drawing.Point(493, 100)
        Me.cb_status.Name = "cb_status"
        Me.cb_status.Size = New System.Drawing.Size(128, 21)
        Me.cb_status.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(455, 103)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 173
        Me.Label13.Text = "Status"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "Customer"
        '
        'in_kode_custo
        '
        Me.in_kode_custo.BackColor = System.Drawing.Color.White
        Me.in_kode_custo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode_custo.ForeColor = System.Drawing.Color.Black
        Me.in_kode_custo.Location = New System.Drawing.Point(97, 133)
        Me.in_kode_custo.MaxLength = 10
        Me.in_kode_custo.Name = "in_kode_custo"
        Me.in_kode_custo.Size = New System.Drawing.Size(110, 20)
        Me.in_kode_custo.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 170
        Me.Label3.Text = "No. BG"
        '
        'in_nobg
        '
        Me.in_nobg.BackColor = System.Drawing.Color.White
        Me.in_nobg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_nobg.ForeColor = System.Drawing.Color.Black
        Me.in_nobg.Location = New System.Drawing.Point(97, 162)
        Me.in_nobg.MaxLength = 10
        Me.in_nobg.Name = "in_nobg"
        Me.in_nobg.Size = New System.Drawing.Size(314, 20)
        Me.in_nobg.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 170
        Me.Label5.Text = "Bank"
        '
        'in_bank
        '
        Me.in_bank.BackColor = System.Drawing.Color.White
        Me.in_bank.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_bank.ForeColor = System.Drawing.Color.Black
        Me.in_bank.Location = New System.Drawing.Point(97, 190)
        Me.in_bank.MaxLength = 10
        Me.in_bank.Name = "in_bank"
        Me.in_bank.Size = New System.Drawing.Size(186, 20)
        Me.in_bank.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 220)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 170
        Me.Label6.Text = "Jumlah"
        '
        'in_jumlah
        '
        Me.in_jumlah.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_jumlah.Location = New System.Drawing.Point(97, 218)
        Me.in_jumlah.Maximum = New Decimal(New Integer() {1874919423, 2328306, 0, 0})
        Me.in_jumlah.Name = "in_jumlah"
        Me.in_jumlah.Size = New System.Drawing.Size(186, 20)
        Me.in_jumlah.TabIndex = 5
        Me.in_jumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_jumlah.ThousandsSeparator = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 251)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 173
        Me.Label8.Text = "Tanggal BG"
        '
        'date_tgl
        '
        Me.date_tgl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_tgl.Location = New System.Drawing.Point(97, 78)
        Me.date_tgl.MaxDate = New Date(3000, 12, 31, 0, 0, 0, 0)
        Me.date_tgl.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl.Name = "date_tgl"
        Me.date_tgl.Size = New System.Drawing.Size(147, 20)
        Me.date_tgl.TabIndex = 0
        '
        'date_tgl_bg
        '
        Me.date_tgl_bg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_bg.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_tgl_bg.Location = New System.Drawing.Point(97, 246)
        Me.date_tgl_bg.MaxDate = New Date(3000, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_bg.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_bg.Name = "date_tgl_bg"
        Me.date_tgl_bg.Size = New System.Drawing.Size(147, 20)
        Me.date_tgl_bg.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(455, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 170
        Me.Label9.Text = "Kode"
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.White
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.ForeColor = System.Drawing.Color.Black
        Me.in_kode.Location = New System.Drawing.Point(493, 78)
        Me.in_kode.MaxLength = 10
        Me.in_kode.Name = "in_kode"
        Me.in_kode.ReadOnly = True
        Me.in_kode.Size = New System.Drawing.Size(128, 20)
        Me.in_kode.TabIndex = 167
        Me.in_kode.TabStop = False
        '
        'pnl_Menu
        '
        Me.pnl_Menu.Controls.Add(Me.MenuStrip1)
        Me.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Menu.Location = New System.Drawing.Point(0, 42)
        Me.pnl_Menu.Name = "pnl_Menu"
        Me.pnl_Menu.Size = New System.Drawing.Size(633, 30)
        Me.pnl_Menu.TabIndex = 280
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_deact, Me.mn_del})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(633, 24)
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
        'cb_sales
        '
        Me.cb_sales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_sales.FormattingEnabled = True
        Me.cb_sales.Location = New System.Drawing.Point(206, 103)
        Me.cb_sales.Name = "cb_sales"
        Me.cb_sales.Size = New System.Drawing.Size(205, 21)
        Me.cb_sales.TabIndex = 281
        '
        'cb_custo
        '
        Me.cb_custo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_custo.FormattingEnabled = True
        Me.cb_custo.Location = New System.Drawing.Point(206, 132)
        Me.cb_custo.Name = "cb_custo"
        Me.cb_custo.Size = New System.Drawing.Size(205, 21)
        Me.cb_custo.TabIndex = 281
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(16, 379)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 13)
        Me.Label30.TabIndex = 332
        Me.Label30.Text = "Date"
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(57, 354)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtUpdAlias.TabIndex = 331
        Me.txtUpdAlias.TabStop = False
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(57, 376)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(150, 20)
        Me.txtUpdDate.TabIndex = 326
        Me.txtUpdDate.TabStop = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(57, 306)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtRegAlias.TabIndex = 328
        Me.txtRegAlias.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(16, 357)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(39, 13)
        Me.Label28.TabIndex = 333
        Me.Label28.Text = "UpdBy"
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(57, 328)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(150, 20)
        Me.txtRegdate.TabIndex = 327
        Me.txtRegdate.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(16, 309)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(39, 13)
        Me.Label27.TabIndex = 330
        Me.Label27.Text = "RegBy"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(16, 331)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(30, 13)
        Me.Label29.TabIndex = 329
        Me.Label29.Text = "Date"
        '
        'bt_pos
        '
        Me.bt_pos.BackColor = System.Drawing.Color.Transparent
        Me.bt_pos.BackgroundImage = CType(resources.GetObject("bt_pos.BackgroundImage"), System.Drawing.Image)
        Me.bt_pos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_pos.FlatAppearance.BorderSize = 0
        Me.bt_pos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_pos.Location = New System.Drawing.Point(417, 106)
        Me.bt_pos.Name = "bt_pos"
        Me.bt_pos.Size = New System.Drawing.Size(12, 15)
        Me.bt_pos.TabIndex = 325
        Me.bt_pos.TabStop = False
        Me.bt_pos.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(417, 134)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(12, 15)
        Me.Button1.TabIndex = 325
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Orange
        Me.lbl_title.Font = New System.Drawing.Font("Source Sans Pro", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(6, 4)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(159, 30)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Data Supplier"
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
        Me.bt_cl.Location = New System.Drawing.Point(606, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 137
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(553, 9)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(47, 20)
        Me.lbl_close.TabIndex = 138
        Me.lbl_close.Text = "Close"
        Me.lbl_close.Visible = False
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
        Me.Panel1.Size = New System.Drawing.Size(633, 42)
        Me.Panel1.TabIndex = 277
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 402)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(633, 10)
        Me.Panel2.TabIndex = 334
        '
        'fr_giro_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.bt_batalgiro
        Me.ClientSize = New System.Drawing.Size(633, 412)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtUpdAlias)
        Me.Controls.Add(Me.txtUpdDate)
        Me.Controls.Add(Me.txtRegAlias)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtRegdate)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.bt_pos)
        Me.Controls.Add(Me.cb_custo)
        Me.Controls.Add(Me.cb_sales)
        Me.Controls.Add(Me.pnl_Menu)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.date_tgl_bg)
        Me.Controls.Add(Me.date_tgl)
        Me.Controls.Add(Me.in_jumlah)
        Me.Controls.Add(Me.cb_status)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.bt_batalgiro)
        Me.Controls.Add(Me.in_kode)
        Me.Controls.Add(Me.in_kode_custo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.bt_simpangiro)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.in_kode_sales)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.in_bank)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.in_nobg)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "fr_giro_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detail BG : "
        CType(Me.in_jumlah, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_Menu.ResumeLayout(False)
        Me.pnl_Menu.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_batalgiro As System.Windows.Forms.Button
    Friend WithEvents bt_simpangiro As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_kode_sales As System.Windows.Forms.TextBox
    Friend WithEvents cb_status As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_kode_custo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents in_nobg As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_bank As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents in_jumlah As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents date_tgl As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_tgl_bg As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents pnl_Menu As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_deact As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cb_sales As System.Windows.Forms.ComboBox
    Friend WithEvents cb_custo As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents bt_pos As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
