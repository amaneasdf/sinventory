<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_bg_tolak
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_bg_tolak))
        Me.bt_batalperkiraan = New System.Windows.Forms.Button()
        Me.bt_simpanperkiraan = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnl_Menu = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_print = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_proses = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.in_sales_n = New System.Windows.Forms.TextBox()
        Me.in_sales = New System.Windows.Forms.TextBox()
        Me.bt_sales_list = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_no_bukti = New System.Windows.Forms.TextBox()
        Me.date_tgl_trans = New System.Windows.Forms.DateTimePicker()
        Me.in_custo = New System.Windows.Forms.TextBox()
        Me.bt_custo_list = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.in_custo_n = New System.Windows.Forms.TextBox()
        Me.date_tgl_bg = New System.Windows.Forms.DateTimePicker()
        Me.in_jumlah = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.in_nobg = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.in_supplier_n = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bt_supplier_list = New System.Windows.Forms.Button()
        Me.in_supplier = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.pnl_Menu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.in_jumlah, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bt_batalperkiraan
        '
        Me.bt_batalperkiraan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_batalperkiraan.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalperkiraan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalperkiraan.Location = New System.Drawing.Point(643, 279)
        Me.bt_batalperkiraan.Name = "bt_batalperkiraan"
        Me.bt_batalperkiraan.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalperkiraan.TabIndex = 15
        Me.bt_batalperkiraan.Text = "Batal"
        Me.bt_batalperkiraan.UseVisualStyleBackColor = True
        '
        'bt_simpanperkiraan
        '
        Me.bt_simpanperkiraan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_simpanperkiraan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanperkiraan.Location = New System.Drawing.Point(541, 279)
        Me.bt_simpanperkiraan.Name = "bt_simpanperkiraan"
        Me.bt_simpanperkiraan.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpanperkiraan.TabIndex = 14
        Me.bt_simpanperkiraan.Text = "Simpan"
        Me.bt_simpanperkiraan.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 315)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(751, 10)
        Me.Panel2.TabIndex = 347
        '
        'pnl_Menu
        '
        Me.pnl_Menu.Controls.Add(Me.MenuStrip1)
        Me.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Menu.Location = New System.Drawing.Point(0, 42)
        Me.pnl_Menu.Name = "pnl_Menu"
        Me.pnl_Menu.Size = New System.Drawing.Size(751, 32)
        Me.pnl_Menu.TabIndex = 346
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_delete, Me.mn_print, Me.mn_proses})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(751, 24)
        Me.MenuStrip1.TabIndex = 183
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
        'mn_delete
        '
        Me.mn_delete.Name = "mn_delete"
        Me.mn_delete.Size = New System.Drawing.Size(52, 20)
        Me.mn_delete.Text = "Delete"
        Me.mn_delete.Visible = False
        '
        'mn_print
        '
        Me.mn_print.Image = CType(resources.GetObject("mn_print.Image"), System.Drawing.Image)
        Me.mn_print.Name = "mn_print"
        Me.mn_print.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.mn_print.Size = New System.Drawing.Size(60, 20)
        Me.mn_print.Text = "&Print"
        Me.mn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.mn_print.Visible = False
        '
        'mn_proses
        '
        Me.mn_proses.Image = Global.Inventory.My.Resources.Resources.toolbar_cancel_icon
        Me.mn_proses.Name = "mn_proses"
        Me.mn_proses.Size = New System.Drawing.Size(69, 20)
        Me.mn_proses.Text = "P&roses"
        Me.mn_proses.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.mn_proses.Visible = False
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
        Me.Panel1.Size = New System.Drawing.Size(751, 42)
        Me.Panel1.TabIndex = 345
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(671, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(724, 9)
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
        Me.lbl_title.Size = New System.Drawing.Size(167, 30)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Form BG Tolak"
        '
        'in_sales_n
        '
        Me.in_sales_n.BackColor = System.Drawing.Color.White
        Me.in_sales_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales_n.ForeColor = System.Drawing.Color.Black
        Me.in_sales_n.Location = New System.Drawing.Point(228, 87)
        Me.in_sales_n.MaxLength = 30
        Me.in_sales_n.Name = "in_sales_n"
        Me.in_sales_n.ReadOnly = True
        Me.in_sales_n.Size = New System.Drawing.Size(218, 20)
        Me.in_sales_n.TabIndex = 1
        Me.in_sales_n.TabStop = False
        '
        'in_sales
        '
        Me.in_sales.BackColor = System.Drawing.Color.White
        Me.in_sales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales.ForeColor = System.Drawing.Color.Black
        Me.in_sales.Location = New System.Drawing.Point(92, 87)
        Me.in_sales.MaxLength = 30
        Me.in_sales.Name = "in_sales"
        Me.in_sales.Size = New System.Drawing.Size(135, 20)
        Me.in_sales.TabIndex = 0
        '
        'bt_sales_list
        '
        Me.bt_sales_list.BackColor = System.Drawing.Color.Transparent
        Me.bt_sales_list.BackgroundImage = CType(resources.GetObject("bt_sales_list.BackgroundImage"), System.Drawing.Image)
        Me.bt_sales_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_sales_list.FlatAppearance.BorderSize = 0
        Me.bt_sales_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_sales_list.Location = New System.Drawing.Point(447, 90)
        Me.bt_sales_list.Name = "bt_sales_list"
        Me.bt_sales_list.Size = New System.Drawing.Size(12, 15)
        Me.bt_sales_list.TabIndex = 2
        Me.bt_sales_list.TabStop = False
        Me.bt_sales_list.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 364
        Me.Label7.Text = "Salesman"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(487, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 366
        Me.Label4.Text = "No. Bukti"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(487, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 365
        Me.Label1.Text = "Tgl"
        '
        'in_no_bukti
        '
        Me.in_no_bukti.BackColor = System.Drawing.Color.White
        Me.in_no_bukti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_no_bukti.ForeColor = System.Drawing.Color.Black
        Me.in_no_bukti.Location = New System.Drawing.Point(546, 87)
        Me.in_no_bukti.MaxLength = 30
        Me.in_no_bukti.Name = "in_no_bukti"
        Me.in_no_bukti.Size = New System.Drawing.Size(188, 20)
        Me.in_no_bukti.TabIndex = 12
        '
        'date_tgl_trans
        '
        Me.date_tgl_trans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_trans.Location = New System.Drawing.Point(546, 110)
        Me.date_tgl_trans.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_trans.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_trans.Name = "date_tgl_trans"
        Me.date_tgl_trans.Size = New System.Drawing.Size(188, 20)
        Me.date_tgl_trans.TabIndex = 13
        '
        'in_custo
        '
        Me.in_custo.BackColor = System.Drawing.Color.White
        Me.in_custo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_custo.ForeColor = System.Drawing.Color.Black
        Me.in_custo.Location = New System.Drawing.Point(92, 111)
        Me.in_custo.MaxLength = 30
        Me.in_custo.Name = "in_custo"
        Me.in_custo.Size = New System.Drawing.Size(135, 20)
        Me.in_custo.TabIndex = 3
        '
        'bt_custo_list
        '
        Me.bt_custo_list.BackColor = System.Drawing.Color.Transparent
        Me.bt_custo_list.BackgroundImage = CType(resources.GetObject("bt_custo_list.BackgroundImage"), System.Drawing.Image)
        Me.bt_custo_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_custo_list.FlatAppearance.BorderSize = 0
        Me.bt_custo_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_custo_list.Location = New System.Drawing.Point(447, 114)
        Me.bt_custo_list.Name = "bt_custo_list"
        Me.bt_custo_list.Size = New System.Drawing.Size(12, 15)
        Me.bt_custo_list.TabIndex = 5
        Me.bt_custo_list.TabStop = False
        Me.bt_custo_list.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 115)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 369
        Me.Label9.Text = "Customer"
        '
        'in_custo_n
        '
        Me.in_custo_n.BackColor = System.Drawing.Color.White
        Me.in_custo_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_custo_n.ForeColor = System.Drawing.Color.Black
        Me.in_custo_n.Location = New System.Drawing.Point(228, 111)
        Me.in_custo_n.MaxLength = 30
        Me.in_custo_n.Name = "in_custo_n"
        Me.in_custo_n.ReadOnly = True
        Me.in_custo_n.Size = New System.Drawing.Size(218, 20)
        Me.in_custo_n.TabIndex = 4
        Me.in_custo_n.TabStop = False
        '
        'date_tgl_bg
        '
        Me.date_tgl_bg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_bg.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_tgl_bg.Location = New System.Drawing.Point(92, 159)
        Me.date_tgl_bg.MaxDate = New Date(3000, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_bg.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_bg.Name = "date_tgl_bg"
        Me.date_tgl_bg.Size = New System.Drawing.Size(147, 20)
        Me.date_tgl_bg.TabIndex = 7
        '
        'in_jumlah
        '
        Me.in_jumlah.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_jumlah.Location = New System.Drawing.Point(92, 183)
        Me.in_jumlah.Maximum = New Decimal(New Integer() {1874919423, 2328306, 0, 0})
        Me.in_jumlah.Name = "in_jumlah"
        Me.in_jumlah.Size = New System.Drawing.Size(186, 20)
        Me.in_jumlah.TabIndex = 8
        Me.in_jumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_jumlah.ThousandsSeparator = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 375
        Me.Label8.Text = "Tanggal BG"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 187)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 373
        Me.Label6.Text = "Jumlah"
        '
        'in_nobg
        '
        Me.in_nobg.BackColor = System.Drawing.Color.White
        Me.in_nobg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_nobg.ForeColor = System.Drawing.Color.Black
        Me.in_nobg.Location = New System.Drawing.Point(92, 135)
        Me.in_nobg.MaxLength = 10
        Me.in_nobg.Name = "in_nobg"
        Me.in_nobg.Size = New System.Drawing.Size(314, 20)
        Me.in_nobg.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 374
        Me.Label3.Text = "No. BG"
        '
        'in_supplier_n
        '
        Me.in_supplier_n.BackColor = System.Drawing.Color.White
        Me.in_supplier_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier_n.ForeColor = System.Drawing.Color.Black
        Me.in_supplier_n.Location = New System.Drawing.Point(228, 207)
        Me.in_supplier_n.MaxLength = 30
        Me.in_supplier_n.Name = "in_supplier_n"
        Me.in_supplier_n.ReadOnly = True
        Me.in_supplier_n.Size = New System.Drawing.Size(218, 20)
        Me.in_supplier_n.TabIndex = 10
        Me.in_supplier_n.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 211)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 369
        Me.Label2.Text = "Supplier"
        '
        'bt_supplier_list
        '
        Me.bt_supplier_list.BackColor = System.Drawing.Color.Transparent
        Me.bt_supplier_list.BackgroundImage = CType(resources.GetObject("bt_supplier_list.BackgroundImage"), System.Drawing.Image)
        Me.bt_supplier_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_supplier_list.FlatAppearance.BorderSize = 0
        Me.bt_supplier_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_supplier_list.Location = New System.Drawing.Point(447, 210)
        Me.bt_supplier_list.Name = "bt_supplier_list"
        Me.bt_supplier_list.Size = New System.Drawing.Size(12, 15)
        Me.bt_supplier_list.TabIndex = 11
        Me.bt_supplier_list.TabStop = False
        Me.bt_supplier_list.UseVisualStyleBackColor = False
        '
        'in_supplier
        '
        Me.in_supplier.BackColor = System.Drawing.Color.White
        Me.in_supplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier.ForeColor = System.Drawing.Color.Black
        Me.in_supplier.Location = New System.Drawing.Point(92, 207)
        Me.in_supplier.MaxLength = 30
        Me.in_supplier.Name = "in_supplier"
        Me.in_supplier.Size = New System.Drawing.Size(135, 20)
        Me.in_supplier.TabIndex = 9
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(228, 288)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 13)
        Me.Label30.TabIndex = 382
        Me.Label30.Text = "Date"
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(269, 263)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtUpdAlias.TabIndex = 381
        Me.txtUpdAlias.TabStop = False
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(269, 285)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(150, 20)
        Me.txtUpdDate.TabIndex = 376
        Me.txtUpdDate.TabStop = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(49, 263)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtRegAlias.TabIndex = 378
        Me.txtRegAlias.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(228, 266)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(39, 13)
        Me.Label28.TabIndex = 383
        Me.Label28.Text = "UpdBy"
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(49, 285)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(150, 20)
        Me.txtRegdate.TabIndex = 377
        Me.txtRegdate.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(8, 266)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(39, 13)
        Me.Label27.TabIndex = 380
        Me.Label27.Text = "RegBy"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(8, 288)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(30, 13)
        Me.Label29.TabIndex = 379
        Me.Label29.Text = "Date"
        '
        'fr_bg_tolak
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.bt_batalperkiraan
        Me.ClientSize = New System.Drawing.Size(751, 325)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtUpdAlias)
        Me.Controls.Add(Me.txtUpdDate)
        Me.Controls.Add(Me.txtRegAlias)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtRegdate)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.date_tgl_bg)
        Me.Controls.Add(Me.in_jumlah)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.in_nobg)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.in_supplier)
        Me.Controls.Add(Me.in_custo)
        Me.Controls.Add(Me.bt_supplier_list)
        Me.Controls.Add(Me.bt_custo_list)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.in_supplier_n)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.in_custo_n)
        Me.Controls.Add(Me.in_sales_n)
        Me.Controls.Add(Me.in_sales)
        Me.Controls.Add(Me.bt_sales_list)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.in_no_bukti)
        Me.Controls.Add(Me.date_tgl_trans)
        Me.Controls.Add(Me.bt_batalperkiraan)
        Me.Controls.Add(Me.bt_simpanperkiraan)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnl_Menu)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "fr_bg_tolak"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fr_bg_tolak"
        Me.pnl_Menu.ResumeLayout(False)
        Me.pnl_Menu.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.in_jumlah, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_batalperkiraan As System.Windows.Forms.Button
    Friend WithEvents bt_simpanperkiraan As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnl_Menu As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_proses As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents in_sales_n As System.Windows.Forms.TextBox
    Friend WithEvents in_sales As System.Windows.Forms.TextBox
    Friend WithEvents bt_sales_list As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_no_bukti As System.Windows.Forms.TextBox
    Friend WithEvents date_tgl_trans As System.Windows.Forms.DateTimePicker
    Friend WithEvents in_custo As System.Windows.Forms.TextBox
    Friend WithEvents bt_custo_list As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents in_custo_n As System.Windows.Forms.TextBox
    Friend WithEvents date_tgl_bg As System.Windows.Forms.DateTimePicker
    Friend WithEvents in_jumlah As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents in_nobg As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents in_supplier_n As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bt_supplier_list As System.Windows.Forms.Button
    Friend WithEvents in_supplier As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
End Class
