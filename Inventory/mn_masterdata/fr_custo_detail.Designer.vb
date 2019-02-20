<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_custo_detail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_custo_detail))
        Me.bt_batalcusto = New System.Windows.Forms.Button()
        Me.bt_simpancusto = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.pnl_Menu = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_deact = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_del = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_cetakQr = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.in_piutang = New System.Windows.Forms.NumericUpDown()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.in_term = New System.Windows.Forms.NumericUpDown()
        Me.cb_harga = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.in_alamat_kelurahan = New System.Windows.Forms.TextBox()
        Me.in_alamat_kecamatan = New System.Windows.Forms.TextBox()
        Me.in_alamat_kabupaten = New System.Windows.Forms.TextBox()
        Me.in_alamat_provinsi = New System.Windows.Forms.TextBox()
        Me.in_alamat_pasar = New System.Windows.Forms.TextBox()
        Me.in_kodepos = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.in_alamat_blok = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.in_alamat_rt = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.in_alamat_no = New System.Windows.Forms.TextBox()
        Me.in_alamat_rw = New System.Windows.Forms.TextBox()
        Me.in_alamat_custo = New System.Windows.Forms.TextBox()
        Me.cb_tipe = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.in_faxcusto = New System.Windows.Forms.TextBox()
        Me.in_telpcusto = New System.Windows.Forms.TextBox()
        Me.in_cpcusto = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.in_nama_custo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.date_tgl_pkp = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.in_nik = New System.Windows.Forms.TextBox()
        Me.in_pajak_alamat = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.in_pajak_jabatan = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.in_npwp = New System.Windows.Forms.TextBox()
        Me.in_pajak_nama = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.in_status = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cb_area = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.cb_diskon = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.pnl_Menu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.in_piutang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_term, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bt_batalcusto
        '
        Me.bt_batalcusto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_batalcusto.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalcusto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalcusto.Location = New System.Drawing.Point(751, 455)
        Me.bt_batalcusto.Name = "bt_batalcusto"
        Me.bt_batalcusto.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalcusto.TabIndex = 30
        Me.bt_batalcusto.Text = "Batal"
        Me.bt_batalcusto.UseVisualStyleBackColor = True
        '
        'bt_simpancusto
        '
        Me.bt_simpancusto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_simpancusto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpancusto.Location = New System.Drawing.Point(649, 455)
        Me.bt_simpancusto.Name = "bt_simpancusto"
        Me.bt_simpancusto.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpancusto.TabIndex = 29
        Me.bt_simpancusto.Text = "Simpan"
        Me.bt_simpancusto.UseVisualStyleBackColor = True
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
        Me.Panel1.Size = New System.Drawing.Size(861, 42)
        Me.Panel1.TabIndex = 35
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(776, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(829, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 35
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
        Me.lbl_title.Size = New System.Drawing.Size(173, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Data Customer"
        '
        'pnl_Menu
        '
        Me.pnl_Menu.Controls.Add(Me.MenuStrip1)
        Me.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Menu.Location = New System.Drawing.Point(0, 42)
        Me.pnl_Menu.Name = "pnl_Menu"
        Me.pnl_Menu.Size = New System.Drawing.Size(861, 30)
        Me.pnl_Menu.TabIndex = 277
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_deact, Me.mn_del, Me.mn_cetakQr})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(861, 24)
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
        'mn_cetakQr
        '
        Me.mn_cetakQr.Name = "mn_cetakQr"
        Me.mn_cetakQr.Size = New System.Drawing.Size(68, 20)
        Me.mn_cetakQr.Text = "Cetak QR"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 491)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(861, 10)
        Me.Panel2.TabIndex = 313
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.White
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.ForeColor = System.Drawing.Color.Black
        Me.in_kode.Location = New System.Drawing.Point(75, 80)
        Me.in_kode.MaxLength = 10
        Me.in_kode.Name = "in_kode"
        Me.in_kode.Size = New System.Drawing.Size(195, 20)
        Me.in_kode.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 315
        Me.Label4.Text = "Kode"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(472, 465)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 13)
        Me.Label30.TabIndex = 344
        Me.Label30.Text = "Date"
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(336, 462)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(130, 20)
        Me.txtUpdAlias.TabIndex = 343
        Me.txtUpdAlias.TabStop = False
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(508, 462)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(130, 20)
        Me.txtUpdDate.TabIndex = 339
        Me.txtUpdDate.TabStop = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(336, 440)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(130, 20)
        Me.txtRegAlias.TabIndex = 340
        Me.txtRegAlias.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(295, 465)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(39, 13)
        Me.Label28.TabIndex = 345
        Me.Label28.Text = "UpdBy"
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(508, 440)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(130, 20)
        Me.txtRegdate.TabIndex = 338
        Me.txtRegdate.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(295, 443)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(39, 13)
        Me.Label27.TabIndex = 342
        Me.Label27.Text = "RegBy"
        '
        'in_piutang
        '
        Me.in_piutang.DecimalPlaces = 2
        Me.in_piutang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_piutang.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.in_piutang.Location = New System.Drawing.Point(539, 103)
        Me.in_piutang.Maximum = New Decimal(New Integer() {1874919423, 2328306, 0, 0})
        Me.in_piutang.Name = "in_piutang"
        Me.in_piutang.Size = New System.Drawing.Size(170, 20)
        Me.in_piutang.TabIndex = 18
        Me.in_piutang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_piutang.ThousandsSeparator = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(472, 443)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(30, 13)
        Me.Label29.TabIndex = 341
        Me.Label29.Text = "Date"
        '
        'in_term
        '
        Me.in_term.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_term.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.in_term.Location = New System.Drawing.Point(539, 170)
        Me.in_term.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.in_term.Name = "in_term"
        Me.in_term.Size = New System.Drawing.Size(66, 20)
        Me.in_term.TabIndex = 21
        Me.in_term.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cb_harga
        '
        Me.cb_harga.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_harga.FormattingEnabled = True
        Me.cb_harga.Location = New System.Drawing.Point(539, 147)
        Me.cb_harga.Name = "cb_harga"
        Me.cb_harga.Size = New System.Drawing.Size(170, 21)
        Me.cb_harga.TabIndex = 20
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(449, 173)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(31, 13)
        Me.Label31.TabIndex = 364
        Me.Label31.Text = "Term"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(449, 106)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(69, 13)
        Me.Label32.TabIndex = 365
        Me.Label32.Text = "Max. Piutang"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(449, 150)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(79, 13)
        Me.Label33.TabIndex = 362
        Me.Label33.Text = "Krit. Harga Jual"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 313)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 352
        Me.Label6.Text = "Kelurahan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 270)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 353
        Me.Label1.Text = "Blok"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(12, 335)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(61, 13)
        Me.Label19.TabIndex = 354
        Me.Label19.Text = "Kecamatan"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(12, 357)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 13)
        Me.Label20.TabIndex = 355
        Me.Label20.Text = "Kabupaten"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 291)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(22, 13)
        Me.Label16.TabIndex = 356
        Me.Label16.Text = "RT"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(226, 270)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(24, 13)
        Me.Label15.TabIndex = 358
        Me.Label15.Text = "No."
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(224, 291)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(26, 13)
        Me.Label17.TabIndex = 357
        Me.Label17.Text = "RW"
        '
        'in_alamat_kelurahan
        '
        Me.in_alamat_kelurahan.BackColor = System.Drawing.Color.White
        Me.in_alamat_kelurahan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamat_kelurahan.ForeColor = System.Drawing.Color.Black
        Me.in_alamat_kelurahan.Location = New System.Drawing.Point(75, 309)
        Me.in_alamat_kelurahan.Name = "in_alamat_kelurahan"
        Me.in_alamat_kelurahan.Size = New System.Drawing.Size(195, 20)
        Me.in_alamat_kelurahan.TabIndex = 12
        '
        'in_alamat_kecamatan
        '
        Me.in_alamat_kecamatan.BackColor = System.Drawing.Color.White
        Me.in_alamat_kecamatan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamat_kecamatan.ForeColor = System.Drawing.Color.Black
        Me.in_alamat_kecamatan.Location = New System.Drawing.Point(75, 331)
        Me.in_alamat_kecamatan.Name = "in_alamat_kecamatan"
        Me.in_alamat_kecamatan.Size = New System.Drawing.Size(195, 20)
        Me.in_alamat_kecamatan.TabIndex = 13
        '
        'in_alamat_kabupaten
        '
        Me.in_alamat_kabupaten.BackColor = System.Drawing.Color.White
        Me.in_alamat_kabupaten.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamat_kabupaten.ForeColor = System.Drawing.Color.Black
        Me.in_alamat_kabupaten.Location = New System.Drawing.Point(75, 353)
        Me.in_alamat_kabupaten.Name = "in_alamat_kabupaten"
        Me.in_alamat_kabupaten.Size = New System.Drawing.Size(195, 20)
        Me.in_alamat_kabupaten.TabIndex = 14
        '
        'in_alamat_provinsi
        '
        Me.in_alamat_provinsi.BackColor = System.Drawing.Color.White
        Me.in_alamat_provinsi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamat_provinsi.ForeColor = System.Drawing.Color.Black
        Me.in_alamat_provinsi.Location = New System.Drawing.Point(75, 397)
        Me.in_alamat_provinsi.Name = "in_alamat_provinsi"
        Me.in_alamat_provinsi.Size = New System.Drawing.Size(195, 20)
        Me.in_alamat_provinsi.TabIndex = 16
        '
        'in_alamat_pasar
        '
        Me.in_alamat_pasar.BackColor = System.Drawing.Color.White
        Me.in_alamat_pasar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamat_pasar.ForeColor = System.Drawing.Color.Black
        Me.in_alamat_pasar.Location = New System.Drawing.Point(75, 375)
        Me.in_alamat_pasar.Name = "in_alamat_pasar"
        Me.in_alamat_pasar.Size = New System.Drawing.Size(195, 20)
        Me.in_alamat_pasar.TabIndex = 15
        '
        'in_kodepos
        '
        Me.in_kodepos.BackColor = System.Drawing.Color.White
        Me.in_kodepos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kodepos.ForeColor = System.Drawing.Color.Black
        Me.in_kodepos.Location = New System.Drawing.Point(75, 419)
        Me.in_kodepos.MaxLength = 5
        Me.in_kodepos.Name = "in_kodepos"
        Me.in_kodepos.Size = New System.Drawing.Size(106, 20)
        Me.in_kodepos.TabIndex = 17
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(12, 423)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 13)
        Me.Label21.TabIndex = 359
        Me.Label21.Text = "Kode Pos"
        '
        'in_alamat_blok
        '
        Me.in_alamat_blok.BackColor = System.Drawing.Color.White
        Me.in_alamat_blok.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamat_blok.ForeColor = System.Drawing.Color.Black
        Me.in_alamat_blok.Location = New System.Drawing.Point(75, 266)
        Me.in_alamat_blok.MaxLength = 4
        Me.in_alamat_blok.Name = "in_alamat_blok"
        Me.in_alamat_blok.Size = New System.Drawing.Size(103, 20)
        Me.in_alamat_blok.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 379)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 360
        Me.Label7.Text = "Pasar"
        '
        'in_alamat_rt
        '
        Me.in_alamat_rt.BackColor = System.Drawing.Color.White
        Me.in_alamat_rt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamat_rt.ForeColor = System.Drawing.Color.Black
        Me.in_alamat_rt.Location = New System.Drawing.Point(75, 287)
        Me.in_alamat_rt.MaxLength = 4
        Me.in_alamat_rt.Name = "in_alamat_rt"
        Me.in_alamat_rt.Size = New System.Drawing.Size(103, 20)
        Me.in_alamat_rt.TabIndex = 10
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(12, 401)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 13)
        Me.Label18.TabIndex = 361
        Me.Label18.Text = "Provinsi"
        '
        'in_alamat_no
        '
        Me.in_alamat_no.BackColor = System.Drawing.Color.White
        Me.in_alamat_no.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamat_no.ForeColor = System.Drawing.Color.Black
        Me.in_alamat_no.Location = New System.Drawing.Point(259, 266)
        Me.in_alamat_no.MaxLength = 4
        Me.in_alamat_no.Name = "in_alamat_no"
        Me.in_alamat_no.Size = New System.Drawing.Size(103, 20)
        Me.in_alamat_no.TabIndex = 9
        '
        'in_alamat_rw
        '
        Me.in_alamat_rw.BackColor = System.Drawing.Color.White
        Me.in_alamat_rw.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamat_rw.ForeColor = System.Drawing.Color.Black
        Me.in_alamat_rw.Location = New System.Drawing.Point(259, 287)
        Me.in_alamat_rw.MaxLength = 4
        Me.in_alamat_rw.Name = "in_alamat_rw"
        Me.in_alamat_rw.Size = New System.Drawing.Size(103, 20)
        Me.in_alamat_rw.TabIndex = 11
        '
        'in_alamat_custo
        '
        Me.in_alamat_custo.BackColor = System.Drawing.Color.White
        Me.in_alamat_custo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamat_custo.ForeColor = System.Drawing.Color.Black
        Me.in_alamat_custo.Location = New System.Drawing.Point(75, 214)
        Me.in_alamat_custo.MaxLength = 300
        Me.in_alamat_custo.Multiline = True
        Me.in_alamat_custo.Name = "in_alamat_custo"
        Me.in_alamat_custo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_alamat_custo.Size = New System.Drawing.Size(329, 50)
        Me.in_alamat_custo.TabIndex = 7
        '
        'cb_tipe
        '
        Me.cb_tipe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_tipe.FormattingEnabled = True
        Me.cb_tipe.Location = New System.Drawing.Point(75, 124)
        Me.cb_tipe.Name = "cb_tipe"
        Me.cb_tipe.Size = New System.Drawing.Size(195, 21)
        Me.cb_tipe.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 218)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 13)
        Me.Label14.TabIndex = 351
        Me.Label14.Text = "Alamat"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 350
        Me.Label12.Text = "Tipe Outlet"
        '
        'in_faxcusto
        '
        Me.in_faxcusto.BackColor = System.Drawing.Color.White
        Me.in_faxcusto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_faxcusto.ForeColor = System.Drawing.Color.Black
        Me.in_faxcusto.Location = New System.Drawing.Point(259, 169)
        Me.in_faxcusto.MaxLength = 20
        Me.in_faxcusto.Name = "in_faxcusto"
        Me.in_faxcusto.Size = New System.Drawing.Size(145, 20)
        Me.in_faxcusto.TabIndex = 5
        '
        'in_telpcusto
        '
        Me.in_telpcusto.BackColor = System.Drawing.Color.White
        Me.in_telpcusto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_telpcusto.ForeColor = System.Drawing.Color.Black
        Me.in_telpcusto.Location = New System.Drawing.Point(75, 169)
        Me.in_telpcusto.MaxLength = 20
        Me.in_telpcusto.Name = "in_telpcusto"
        Me.in_telpcusto.Size = New System.Drawing.Size(145, 20)
        Me.in_telpcusto.TabIndex = 4
        '
        'in_cpcusto
        '
        Me.in_cpcusto.BackColor = System.Drawing.Color.White
        Me.in_cpcusto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cpcusto.ForeColor = System.Drawing.Color.Black
        Me.in_cpcusto.Location = New System.Drawing.Point(75, 192)
        Me.in_cpcusto.MaxLength = 20
        Me.in_cpcusto.Name = "in_cpcusto"
        Me.in_cpcusto.Size = New System.Drawing.Size(195, 20)
        Me.in_cpcusto.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(226, 173)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 13)
        Me.Label10.TabIndex = 347
        Me.Label10.Text = "Fax."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 173)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 348
        Me.Label9.Text = "Telp."
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(12, 195)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(24, 13)
        Me.Label22.TabIndex = 349
        Me.Label22.Text = "CP."
        '
        'in_nama_custo
        '
        Me.in_nama_custo.BackColor = System.Drawing.Color.White
        Me.in_nama_custo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_nama_custo.ForeColor = System.Drawing.Color.Black
        Me.in_nama_custo.Location = New System.Drawing.Point(75, 102)
        Me.in_nama_custo.MaxLength = 30
        Me.in_nama_custo.Name = "in_nama_custo"
        Me.in_nama_custo.Size = New System.Drawing.Size(329, 20)
        Me.in_nama_custo.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 346
        Me.Label3.Text = "Nama"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(449, 309)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 376
        Me.Label5.Text = "Jabatan Pajak"
        '
        'date_tgl_pkp
        '
        Me.date_tgl_pkp.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_pkp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_pkp.Location = New System.Drawing.Point(539, 260)
        Me.date_tgl_pkp.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_pkp.MinDate = New Date(1950, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_pkp.Name = "date_tgl_pkp"
        Me.date_tgl_pkp.Size = New System.Drawing.Size(168, 20)
        Me.date_tgl_pkp.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(449, 287)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 375
        Me.Label8.Text = "Nama Pajak"
        '
        'in_nik
        '
        Me.in_nik.BackColor = System.Drawing.Color.White
        Me.in_nik.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_nik.ForeColor = System.Drawing.Color.Black
        Me.in_nik.Location = New System.Drawing.Point(539, 214)
        Me.in_nik.Name = "in_nik"
        Me.in_nik.Size = New System.Drawing.Size(308, 20)
        Me.in_nik.TabIndex = 22
        '
        'in_pajak_alamat
        '
        Me.in_pajak_alamat.BackColor = System.Drawing.Color.White
        Me.in_pajak_alamat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_pajak_alamat.ForeColor = System.Drawing.Color.Black
        Me.in_pajak_alamat.Location = New System.Drawing.Point(539, 327)
        Me.in_pajak_alamat.Multiline = True
        Me.in_pajak_alamat.Name = "in_pajak_alamat"
        Me.in_pajak_alamat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_pajak_alamat.Size = New System.Drawing.Size(308, 50)
        Me.in_pajak_alamat.TabIndex = 27
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(449, 263)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 13)
        Me.Label25.TabIndex = 372
        Me.Label25.Text = "Tanggal PKP"
        '
        'in_pajak_jabatan
        '
        Me.in_pajak_jabatan.BackColor = System.Drawing.Color.White
        Me.in_pajak_jabatan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_pajak_jabatan.ForeColor = System.Drawing.Color.Black
        Me.in_pajak_jabatan.Location = New System.Drawing.Point(539, 305)
        Me.in_pajak_jabatan.Name = "in_pajak_jabatan"
        Me.in_pajak_jabatan.Size = New System.Drawing.Size(308, 20)
        Me.in_pajak_jabatan.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(449, 218)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(25, 13)
        Me.Label11.TabIndex = 374
        Me.Label11.Text = "NIK"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(449, 334)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(69, 13)
        Me.Label26.TabIndex = 377
        Me.Label26.Text = "Alamat Pajak"
        '
        'in_npwp
        '
        Me.in_npwp.BackColor = System.Drawing.Color.White
        Me.in_npwp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_npwp.ForeColor = System.Drawing.Color.Black
        Me.in_npwp.Location = New System.Drawing.Point(539, 237)
        Me.in_npwp.Name = "in_npwp"
        Me.in_npwp.Size = New System.Drawing.Size(308, 20)
        Me.in_npwp.TabIndex = 23
        '
        'in_pajak_nama
        '
        Me.in_pajak_nama.BackColor = System.Drawing.Color.White
        Me.in_pajak_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_pajak_nama.ForeColor = System.Drawing.Color.Black
        Me.in_pajak_nama.Location = New System.Drawing.Point(539, 283)
        Me.in_pajak_nama.Name = "in_pajak_nama"
        Me.in_pajak_nama.Size = New System.Drawing.Size(308, 20)
        Me.in_pajak_nama.TabIndex = 25
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(449, 240)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 13)
        Me.Label23.TabIndex = 373
        Me.Label23.Text = "NPWP"
        '
        'in_status
        '
        Me.in_status.BackColor = System.Drawing.Color.White
        Me.in_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status.ForeColor = System.Drawing.Color.Black
        Me.in_status.Location = New System.Drawing.Point(120, 462)
        Me.in_status.MaxLength = 10
        Me.in_status.Name = "in_status"
        Me.in_status.ReadOnly = True
        Me.in_status.Size = New System.Drawing.Size(150, 20)
        Me.in_status.TabIndex = 28
        Me.in_status.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(77, 465)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 379
        Me.Label13.Text = "Status"
        '
        'cb_area
        '
        Me.cb_area.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_area.FormattingEnabled = True
        Me.cb_area.Location = New System.Drawing.Point(75, 146)
        Me.cb_area.Name = "cb_area"
        Me.cb_area.Size = New System.Drawing.Size(195, 21)
        Me.cb_area.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 150)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 381
        Me.Label2.Text = "Area"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(449, 128)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(61, 13)
        Me.Label35.TabIndex = 363
        Me.Label35.Text = "Krit. Diskon"
        Me.Label35.Visible = False
        '
        'cb_diskon
        '
        Me.cb_diskon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_diskon.FormattingEnabled = True
        Me.cb_diskon.Location = New System.Drawing.Point(539, 125)
        Me.cb_diskon.Name = "cb_diskon"
        Me.cb_diskon.Size = New System.Drawing.Size(170, 21)
        Me.cb_diskon.TabIndex = 19
        Me.cb_diskon.Visible = False
        '
        'fr_custo_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.bt_batalcusto
        Me.ClientSize = New System.Drawing.Size(861, 501)
        Me.Controls.Add(Me.cb_area)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.bt_batalcusto)
        Me.Controls.Add(Me.bt_simpancusto)
        Me.Controls.Add(Me.in_status)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.date_tgl_pkp)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.in_nik)
        Me.Controls.Add(Me.in_pajak_alamat)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.in_pajak_jabatan)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.in_npwp)
        Me.Controls.Add(Me.in_pajak_nama)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtUpdAlias)
        Me.Controls.Add(Me.txtUpdDate)
        Me.Controls.Add(Me.txtRegAlias)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtRegdate)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.in_piutang)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.in_term)
        Me.Controls.Add(Me.cb_harga)
        Me.Controls.Add(Me.cb_diskon)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.in_alamat_kelurahan)
        Me.Controls.Add(Me.in_alamat_kecamatan)
        Me.Controls.Add(Me.in_alamat_kabupaten)
        Me.Controls.Add(Me.in_alamat_provinsi)
        Me.Controls.Add(Me.in_alamat_pasar)
        Me.Controls.Add(Me.in_kodepos)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.in_alamat_blok)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.in_alamat_rt)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.in_alamat_no)
        Me.Controls.Add(Me.in_alamat_rw)
        Me.Controls.Add(Me.in_alamat_custo)
        Me.Controls.Add(Me.cb_tipe)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.in_faxcusto)
        Me.Controls.Add(Me.in_telpcusto)
        Me.Controls.Add(Me.in_cpcusto)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.in_nama_custo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.in_kode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.pnl_Menu)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_custo_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Customer : "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_Menu.ResumeLayout(False)
        Me.pnl_Menu.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.in_piutang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_term, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_batalcusto As System.Windows.Forms.Button
    Friend WithEvents bt_simpancusto As System.Windows.Forms.Button
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
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents in_piutang As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents in_term As System.Windows.Forms.NumericUpDown
    Friend WithEvents cb_harga As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents in_alamat_kelurahan As System.Windows.Forms.TextBox
    Friend WithEvents in_alamat_kecamatan As System.Windows.Forms.TextBox
    Friend WithEvents in_alamat_kabupaten As System.Windows.Forms.TextBox
    Friend WithEvents in_alamat_provinsi As System.Windows.Forms.TextBox
    Friend WithEvents in_alamat_pasar As System.Windows.Forms.TextBox
    Friend WithEvents in_kodepos As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents in_alamat_blok As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents in_alamat_rt As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents in_alamat_no As System.Windows.Forms.TextBox
    Friend WithEvents in_alamat_rw As System.Windows.Forms.TextBox
    Friend WithEvents in_alamat_custo As System.Windows.Forms.TextBox
    Friend WithEvents cb_tipe As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents in_faxcusto As System.Windows.Forms.TextBox
    Friend WithEvents in_telpcusto As System.Windows.Forms.TextBox
    Friend WithEvents in_cpcusto As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents in_nama_custo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents date_tgl_pkp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents in_nik As System.Windows.Forms.TextBox
    Friend WithEvents in_pajak_alamat As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents in_pajak_jabatan As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents in_npwp As System.Windows.Forms.TextBox
    Friend WithEvents in_pajak_nama As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents in_status As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cb_area As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents mn_cetakQr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cb_diskon As System.Windows.Forms.ComboBox
End Class
