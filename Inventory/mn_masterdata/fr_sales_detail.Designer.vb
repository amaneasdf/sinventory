﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_sales_detail
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
        Me.in_alamatsales = New System.Windows.Forms.TextBox()
        Me.in_nik = New System.Windows.Forms.TextBox()
        Me.in_faxsales = New System.Windows.Forms.TextBox()
        Me.in_telpsales = New System.Windows.Forms.TextBox()
        Me.in_namasales = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_bank_an = New System.Windows.Forms.TextBox()
        Me.in_bank_rek = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.in_lahir_kota = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.date_lahir_tgl = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_bank_nama = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.date_kerja = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cb_jenis = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.in_target = New System.Windows.Forms.NumericUpDown()
        Me.pnl_Menu = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_deact = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_del = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.in_status = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pic_supplier = New System.Windows.Forms.PictureBox()
        Me.bt_gambar = New System.Windows.Forms.Button()
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
        Me.Panel1.SuspendLayout()
        CType(Me.in_target, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_Menu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.pic_supplier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_footer.SuspendLayout()
        Me.pnl_content.SuspendLayout()
        Me.SuspendLayout()
        '
        'in_alamatsales
        '
        Me.in_alamatsales.BackColor = System.Drawing.Color.White
        Me.in_alamatsales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamatsales.ForeColor = System.Drawing.Color.Black
        Me.in_alamatsales.Location = New System.Drawing.Point(79, 73)
        Me.in_alamatsales.MaxLength = 200
        Me.in_alamatsales.Multiline = True
        Me.in_alamatsales.Name = "in_alamatsales"
        Me.in_alamatsales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_alamatsales.Size = New System.Drawing.Size(359, 65)
        Me.in_alamatsales.TabIndex = 2
        '
        'in_nik
        '
        Me.in_nik.BackColor = System.Drawing.Color.White
        Me.in_nik.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_nik.ForeColor = System.Drawing.Color.Black
        Me.in_nik.Location = New System.Drawing.Point(79, 228)
        Me.in_nik.MaxLength = 20
        Me.in_nik.Name = "in_nik"
        Me.in_nik.Size = New System.Drawing.Size(359, 20)
        Me.in_nik.TabIndex = 8
        '
        'in_faxsales
        '
        Me.in_faxsales.BackColor = System.Drawing.Color.White
        Me.in_faxsales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_faxsales.ForeColor = System.Drawing.Color.Black
        Me.in_faxsales.Location = New System.Drawing.Point(79, 206)
        Me.in_faxsales.MaxLength = 20
        Me.in_faxsales.Name = "in_faxsales"
        Me.in_faxsales.Size = New System.Drawing.Size(189, 20)
        Me.in_faxsales.TabIndex = 7
        '
        'in_telpsales
        '
        Me.in_telpsales.BackColor = System.Drawing.Color.White
        Me.in_telpsales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_telpsales.ForeColor = System.Drawing.Color.Black
        Me.in_telpsales.Location = New System.Drawing.Point(79, 184)
        Me.in_telpsales.MaxLength = 20
        Me.in_telpsales.Name = "in_telpsales"
        Me.in_telpsales.Size = New System.Drawing.Size(189, 20)
        Me.in_telpsales.TabIndex = 6
        '
        'in_namasales
        '
        Me.in_namasales.BackColor = System.Drawing.Color.White
        Me.in_namasales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_namasales.ForeColor = System.Drawing.Color.Black
        Me.in_namasales.Location = New System.Drawing.Point(79, 28)
        Me.in_namasales.MaxLength = 50
        Me.in_namasales.Name = "in_namasales"
        Me.in_namasales.Size = New System.Drawing.Size(359, 20)
        Me.in_namasales.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Alamat"
        '
        'in_bank_an
        '
        Me.in_bank_an.BackColor = System.Drawing.Color.White
        Me.in_bank_an.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_bank_an.ForeColor = System.Drawing.Color.Black
        Me.in_bank_an.Location = New System.Drawing.Point(121, 324)
        Me.in_bank_an.MaxLength = 30
        Me.in_bank_an.Name = "in_bank_an"
        Me.in_bank_an.Size = New System.Drawing.Size(317, 20)
        Me.in_bank_an.TabIndex = 12
        '
        'in_bank_rek
        '
        Me.in_bank_rek.BackColor = System.Drawing.Color.White
        Me.in_bank_rek.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_bank_rek.ForeColor = System.Drawing.Color.Black
        Me.in_bank_rek.Location = New System.Drawing.Point(121, 302)
        Me.in_bank_rek.MaxLength = 20
        Me.in_bank_rek.Name = "in_bank_rek"
        Me.in_bank_rek.Size = New System.Drawing.Size(317, 20)
        Me.in_bank_rek.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 327)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Atas Nama Rek."
        '
        'in_lahir_kota
        '
        Me.in_lahir_kota.BackColor = System.Drawing.Color.White
        Me.in_lahir_kota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_lahir_kota.ForeColor = System.Drawing.Color.Black
        Me.in_lahir_kota.Location = New System.Drawing.Point(79, 140)
        Me.in_lahir_kota.MaxLength = 20
        Me.in_lahir_kota.Name = "in_lahir_kota"
        Me.in_lahir_kota.Size = New System.Drawing.Size(189, 20)
        Me.in_lahir_kota.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 232)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(25, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "NIK"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 305)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "No. Rek. Bank"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 210)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Fax."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 188)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Telp."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Lahir"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Nama"
        '
        'date_lahir_tgl
        '
        Me.date_lahir_tgl.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_lahir_tgl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_lahir_tgl.Location = New System.Drawing.Point(272, 140)
        Me.date_lahir_tgl.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.date_lahir_tgl.MinDate = New Date(1950, 1, 1, 0, 0, 0, 0)
        Me.date_lahir_tgl.Name = "date_lahir_tgl"
        Me.date_lahir_tgl.Size = New System.Drawing.Size(166, 20)
        Me.date_lahir_tgl.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 254)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Target"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 283)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Bank"
        '
        'in_bank_nama
        '
        Me.in_bank_nama.BackColor = System.Drawing.Color.White
        Me.in_bank_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_bank_nama.ForeColor = System.Drawing.Color.Black
        Me.in_bank_nama.Location = New System.Drawing.Point(121, 280)
        Me.in_bank_nama.MaxLength = 20
        Me.in_bank_nama.Name = "in_bank_nama"
        Me.in_bank_nama.Size = New System.Drawing.Size(211, 20)
        Me.in_bank_nama.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 166)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Mulai Kerja"
        '
        'date_kerja
        '
        Me.date_kerja.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_kerja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_kerja.Location = New System.Drawing.Point(79, 162)
        Me.date_kerja.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.date_kerja.MinDate = New Date(1950, 1, 1, 0, 0, 0, 0)
        Me.date_kerja.Name = "date_kerja"
        Me.date_kerja.Size = New System.Drawing.Size(189, 20)
        Me.date_kerja.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(31, 13)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Jenis"
        '
        'cb_jenis
        '
        Me.cb_jenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_jenis.FormattingEnabled = True
        Me.cb_jenis.Location = New System.Drawing.Point(79, 50)
        Me.cb_jenis.Name = "cb_jenis"
        Me.cb_jenis.Size = New System.Drawing.Size(189, 21)
        Me.cb_jenis.TabIndex = 1
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
        Me.Panel1.Size = New System.Drawing.Size(678, 42)
        Me.Panel1.TabIndex = 276
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(598, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(651, 9)
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
        Me.lbl_title.Size = New System.Drawing.Size(173, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Data Salesman"
        '
        'in_target
        '
        Me.in_target.Location = New System.Drawing.Point(79, 250)
        Me.in_target.Maximum = New Decimal(New Integer() {-1486618625, 232830643, 0, 0})
        Me.in_target.Name = "in_target"
        Me.in_target.Size = New System.Drawing.Size(189, 20)
        Me.in_target.TabIndex = 9
        Me.in_target.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_target.ThousandsSeparator = True
        '
        'pnl_Menu
        '
        Me.pnl_Menu.Controls.Add(Me.MenuStrip1)
        Me.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Menu.Location = New System.Drawing.Point(0, 42)
        Me.pnl_Menu.Name = "pnl_Menu"
        Me.pnl_Menu.Size = New System.Drawing.Size(678, 30)
        Me.pnl_Menu.TabIndex = 278
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_deact, Me.mn_del})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(678, 24)
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
        Me.Panel2.Location = New System.Drawing.Point(0, 525)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(678, 11)
        Me.Panel2.TabIndex = 279
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.White
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.ForeColor = System.Drawing.Color.Black
        Me.in_kode.Location = New System.Drawing.Point(79, 6)
        Me.in_kode.MaxLength = 10
        Me.in_kode.Name = "in_kode"
        Me.in_kode.Size = New System.Drawing.Size(189, 20)
        Me.in_kode.TabIndex = 280
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 282
        Me.Label4.Text = "Kode"
        '
        'in_status
        '
        Me.in_status.BackColor = System.Drawing.Color.White
        Me.in_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status.ForeColor = System.Drawing.Color.Black
        Me.in_status.Location = New System.Drawing.Point(503, 6)
        Me.in_status.MaxLength = 10
        Me.in_status.Name = "in_status"
        Me.in_status.ReadOnly = True
        Me.in_status.Size = New System.Drawing.Size(168, 20)
        Me.in_status.TabIndex = 281
        Me.in_status.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(458, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 283
        Me.Label13.Text = "Status"
        '
        'pic_supplier
        '
        Me.pic_supplier.BackColor = System.Drawing.Color.LightGray
        Me.pic_supplier.Enabled = False
        Me.pic_supplier.Location = New System.Drawing.Point(503, 32)
        Me.pic_supplier.Name = "pic_supplier"
        Me.pic_supplier.Size = New System.Drawing.Size(168, 183)
        Me.pic_supplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_supplier.TabIndex = 285
        Me.pic_supplier.TabStop = False
        Me.pic_supplier.Visible = False
        '
        'bt_gambar
        '
        Me.bt_gambar.Enabled = False
        Me.bt_gambar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_gambar.Location = New System.Drawing.Point(561, 221)
        Me.bt_gambar.Name = "bt_gambar"
        Me.bt_gambar.Size = New System.Drawing.Size(110, 24)
        Me.bt_gambar.TabIndex = 284
        Me.bt_gambar.Text = "Ubah Gambar"
        Me.bt_gambar.UseVisualStyleBackColor = True
        Me.bt_gambar.Visible = False
        '
        'pnl_footer
        '
        Me.pnl_footer.BackColor = System.Drawing.Color.LightGray
        Me.pnl_footer.Controls.Add(Me.bt_batalcusto)
        Me.pnl_footer.Controls.Add(Me.bt_simpancusto)
        Me.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_footer.Location = New System.Drawing.Point(0, 478)
        Me.pnl_footer.Name = "pnl_footer"
        Me.pnl_footer.Size = New System.Drawing.Size(678, 47)
        Me.pnl_footer.TabIndex = 286
        '
        'bt_batalcusto
        '
        Me.bt_batalcusto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_batalcusto.BackColor = System.Drawing.Color.Tomato
        Me.bt_batalcusto.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalcusto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_batalcusto.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalcusto.ForeColor = System.Drawing.Color.White
        Me.bt_batalcusto.Location = New System.Drawing.Point(575, 11)
        Me.bt_batalcusto.Name = "bt_batalcusto"
        Me.bt_batalcusto.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalcusto.TabIndex = 27
        Me.bt_batalcusto.Text = "Batal"
        Me.bt_batalcusto.UseVisualStyleBackColor = False
        '
        'bt_simpancusto
        '
        Me.bt_simpancusto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_simpancusto.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpancusto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpancusto.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpancusto.ForeColor = System.Drawing.Color.White
        Me.bt_simpancusto.Location = New System.Drawing.Point(415, 11)
        Me.bt_simpancusto.Name = "bt_simpancusto"
        Me.bt_simpancusto.Size = New System.Drawing.Size(154, 30)
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
        Me.pnl_content.Controls.Add(Me.Label4)
        Me.pnl_content.Controls.Add(Me.Label3)
        Me.pnl_content.Controls.Add(Me.pic_supplier)
        Me.pnl_content.Controls.Add(Me.Label6)
        Me.pnl_content.Controls.Add(Me.bt_gambar)
        Me.pnl_content.Controls.Add(Me.Label9)
        Me.pnl_content.Controls.Add(Me.in_kode)
        Me.pnl_content.Controls.Add(Me.Label1)
        Me.pnl_content.Controls.Add(Me.Label10)
        Me.pnl_content.Controls.Add(Me.in_status)
        Me.pnl_content.Controls.Add(Me.Label2)
        Me.pnl_content.Controls.Add(Me.Label13)
        Me.pnl_content.Controls.Add(Me.Label7)
        Me.pnl_content.Controls.Add(Me.Label11)
        Me.pnl_content.Controls.Add(Me.in_lahir_kota)
        Me.pnl_content.Controls.Add(Me.in_target)
        Me.pnl_content.Controls.Add(Me.Label12)
        Me.pnl_content.Controls.Add(Me.Label8)
        Me.pnl_content.Controls.Add(Me.cb_jenis)
        Me.pnl_content.Controls.Add(Me.in_bank_rek)
        Me.pnl_content.Controls.Add(Me.Label15)
        Me.pnl_content.Controls.Add(Me.in_bank_an)
        Me.pnl_content.Controls.Add(Me.date_kerja)
        Me.pnl_content.Controls.Add(Me.Label5)
        Me.pnl_content.Controls.Add(Me.date_lahir_tgl)
        Me.pnl_content.Controls.Add(Me.in_namasales)
        Me.pnl_content.Controls.Add(Me.in_alamatsales)
        Me.pnl_content.Controls.Add(Me.in_telpsales)
        Me.pnl_content.Controls.Add(Me.in_nik)
        Me.pnl_content.Controls.Add(Me.in_bank_nama)
        Me.pnl_content.Controls.Add(Me.in_faxsales)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Location = New System.Drawing.Point(0, 72)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(678, 406)
        Me.pnl_content.TabIndex = 0
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(336, 356)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(177, 20)
        Me.txtRegdate.TabIndex = 383
        Me.txtRegdate.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(269, 384)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(62, 13)
        Me.Label28.TabIndex = 390
        Me.Label28.Text = "LastUpdate"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(518, 384)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(19, 13)
        Me.Label30.TabIndex = 389
        Me.Label30.Text = "By"
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(336, 380)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(177, 20)
        Me.txtUpdDate.TabIndex = 384
        Me.txtUpdDate.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(269, 359)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(43, 13)
        Me.Label29.TabIndex = 386
        Me.Label29.Text = "Inputed"
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(541, 380)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(130, 20)
        Me.txtUpdAlias.TabIndex = 388
        Me.txtUpdAlias.TabStop = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(541, 356)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(130, 20)
        Me.txtRegAlias.TabIndex = 385
        Me.txtRegAlias.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(518, 360)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(19, 13)
        Me.Label27.TabIndex = 387
        Me.Label27.Text = "By"
        '
        'fr_sales_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(678, 536)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.pnl_footer)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnl_Menu)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fr_sales_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Salesman :  "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.in_target, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_Menu.ResumeLayout(False)
        Me.pnl_Menu.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.pic_supplier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_footer.ResumeLayout(False)
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents in_alamatsales As System.Windows.Forms.TextBox
    Friend WithEvents in_nik As System.Windows.Forms.TextBox
    Friend WithEvents in_faxsales As System.Windows.Forms.TextBox
    Friend WithEvents in_telpsales As System.Windows.Forms.TextBox
    Friend WithEvents in_namasales As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_bank_an As System.Windows.Forms.TextBox
    Friend WithEvents in_bank_rek As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents in_lahir_kota As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents date_lahir_tgl As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_bank_nama As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents date_kerja As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cb_jenis As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents in_target As System.Windows.Forms.NumericUpDown
    Friend WithEvents pnl_Menu As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_deact As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents in_status As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pic_supplier As System.Windows.Forms.PictureBox
    Friend WithEvents bt_gambar As System.Windows.Forms.Button
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
End Class
