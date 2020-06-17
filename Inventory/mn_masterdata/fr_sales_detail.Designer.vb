<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_sales_detail))
        Me.in_alamatsales = New System.Windows.Forms.TextBox()
        Me.in_nik = New System.Windows.Forms.TextBox()
        Me.in_faxsales = New System.Windows.Forms.TextBox()
        Me.in_telpsales = New System.Windows.Forms.TextBox()
        Me.in_namasales = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_bank_an = New System.Windows.Forms.TextBox()
        Me.in_bank_rek = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_bank_nama = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cb_jenis = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.in_status = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_email = New System.Windows.Forms.TextBox()
        Me.ctx_main = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tstrip_simpan = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstrip_status = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstrip_activate = New System.Windows.Forms.ToolStripMenuItem()
        Me.tstrip_inactivate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tstrip_delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tstrip_setupsales = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsrtip_close = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnl_header = New System.Windows.Forms.Panel()
        Me.bt_menu = New System.Windows.Forms.Button()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnl_footer.SuspendLayout()
        Me.pnl_content.SuspendLayout()
        Me.ctx_main.SuspendLayout()
        Me.pnl_header.SuspendLayout()
        Me.SuspendLayout()
        '
        'in_alamatsales
        '
        Me.in_alamatsales.BackColor = System.Drawing.Color.White
        Me.in_alamatsales.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamatsales.ForeColor = System.Drawing.Color.Black
        Me.in_alamatsales.Location = New System.Drawing.Point(83, 94)
        Me.in_alamatsales.MaxLength = 200
        Me.in_alamatsales.Multiline = True
        Me.in_alamatsales.Name = "in_alamatsales"
        Me.in_alamatsales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_alamatsales.Size = New System.Drawing.Size(359, 65)
        Me.in_alamatsales.TabIndex = 3
        '
        'in_nik
        '
        Me.in_nik.BackColor = System.Drawing.Color.White
        Me.in_nik.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_nik.ForeColor = System.Drawing.Color.Black
        Me.in_nik.Location = New System.Drawing.Point(85, 241)
        Me.in_nik.MaxLength = 20
        Me.in_nik.Name = "in_nik"
        Me.in_nik.Size = New System.Drawing.Size(359, 22)
        Me.in_nik.TabIndex = 7
        '
        'in_faxsales
        '
        Me.in_faxsales.BackColor = System.Drawing.Color.White
        Me.in_faxsales.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_faxsales.ForeColor = System.Drawing.Color.Black
        Me.in_faxsales.Location = New System.Drawing.Point(85, 190)
        Me.in_faxsales.MaxLength = 20
        Me.in_faxsales.Name = "in_faxsales"
        Me.in_faxsales.Size = New System.Drawing.Size(253, 22)
        Me.in_faxsales.TabIndex = 5
        '
        'in_telpsales
        '
        Me.in_telpsales.BackColor = System.Drawing.Color.White
        Me.in_telpsales.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_telpsales.ForeColor = System.Drawing.Color.Black
        Me.in_telpsales.Location = New System.Drawing.Point(85, 166)
        Me.in_telpsales.MaxLength = 20
        Me.in_telpsales.Name = "in_telpsales"
        Me.in_telpsales.Size = New System.Drawing.Size(253, 22)
        Me.in_telpsales.TabIndex = 4
        '
        'in_namasales
        '
        Me.in_namasales.BackColor = System.Drawing.Color.White
        Me.in_namasales.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_namasales.ForeColor = System.Drawing.Color.Black
        Me.in_namasales.Location = New System.Drawing.Point(83, 40)
        Me.in_namasales.MaxLength = 50
        Me.in_namasales.Name = "in_namasales"
        Me.in_namasales.Size = New System.Drawing.Size(359, 22)
        Me.in_namasales.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Alamat"
        '
        'in_bank_an
        '
        Me.in_bank_an.BackColor = System.Drawing.Color.White
        Me.in_bank_an.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_bank_an.ForeColor = System.Drawing.Color.Black
        Me.in_bank_an.Location = New System.Drawing.Point(592, 91)
        Me.in_bank_an.MaxLength = 30
        Me.in_bank_an.Name = "in_bank_an"
        Me.in_bank_an.Size = New System.Drawing.Size(289, 22)
        Me.in_bank_an.TabIndex = 10
        '
        'in_bank_rek
        '
        Me.in_bank_rek.BackColor = System.Drawing.Color.White
        Me.in_bank_rek.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_bank_rek.ForeColor = System.Drawing.Color.Black
        Me.in_bank_rek.Location = New System.Drawing.Point(592, 65)
        Me.in_bank_rek.MaxLength = 20
        Me.in_bank_rek.Name = "in_bank_rek"
        Me.in_bank_rek.Size = New System.Drawing.Size(289, 22)
        Me.in_bank_rek.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(499, 94)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 15)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Atas Nama Rek."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 244)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(25, 15)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "NIK"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(499, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 15)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "No. Rek. Bank"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 193)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 15)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Fax."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 15)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Telp."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Nama"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(499, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Bank"
        '
        'in_bank_nama
        '
        Me.in_bank_nama.BackColor = System.Drawing.Color.White
        Me.in_bank_nama.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_bank_nama.ForeColor = System.Drawing.Color.Black
        Me.in_bank_nama.Location = New System.Drawing.Point(592, 40)
        Me.in_bank_nama.MaxLength = 20
        Me.in_bank_nama.Name = "in_bank_nama"
        Me.in_bank_nama.Size = New System.Drawing.Size(289, 22)
        Me.in_bank_nama.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(10, 68)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(31, 15)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Jenis"
        '
        'cb_jenis
        '
        Me.cb_jenis.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_jenis.FormattingEnabled = True
        Me.cb_jenis.Location = New System.Drawing.Point(83, 65)
        Me.cb_jenis.Name = "cb_jenis"
        Me.cb_jenis.Size = New System.Drawing.Size(189, 23)
        Me.cb_jenis.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 474)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(909, 5)
        Me.Panel2.TabIndex = 0
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.White
        Me.in_kode.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.ForeColor = System.Drawing.Color.Black
        Me.in_kode.Location = New System.Drawing.Point(83, 12)
        Me.in_kode.MaxLength = 10
        Me.in_kode.Name = "in_kode"
        Me.in_kode.Size = New System.Drawing.Size(189, 22)
        Me.in_kode.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 15)
        Me.Label4.TabIndex = 282
        Me.Label4.Text = "Kode"
        '
        'in_status
        '
        Me.in_status.BackColor = System.Drawing.Color.Gainsboro
        Me.in_status.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status.ForeColor = System.Drawing.Color.Black
        Me.in_status.Location = New System.Drawing.Point(592, 245)
        Me.in_status.MaxLength = 10
        Me.in_status.Name = "in_status"
        Me.in_status.ReadOnly = True
        Me.in_status.Size = New System.Drawing.Size(165, 22)
        Me.in_status.TabIndex = 11
        Me.in_status.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(499, 248)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 15)
        Me.Label13.TabIndex = 283
        Me.Label13.Text = "Status Data"
        '
        'pnl_footer
        '
        Me.pnl_footer.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnl_footer.Controls.Add(Me.bt_batalcusto)
        Me.pnl_footer.Controls.Add(Me.bt_simpancusto)
        Me.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_footer.Location = New System.Drawing.Point(0, 427)
        Me.pnl_footer.Name = "pnl_footer"
        Me.pnl_footer.Size = New System.Drawing.Size(909, 47)
        Me.pnl_footer.TabIndex = 16
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
        Me.bt_batalcusto.Location = New System.Drawing.Point(801, 6)
        Me.bt_batalcusto.Name = "bt_batalcusto"
        Me.bt_batalcusto.Size = New System.Drawing.Size(96, 35)
        Me.bt_batalcusto.TabIndex = 18
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
        Me.bt_simpancusto.Location = New System.Drawing.Point(641, 6)
        Me.bt_simpancusto.Name = "bt_simpancusto"
        Me.bt_simpancusto.Size = New System.Drawing.Size(154, 35)
        Me.bt_simpancusto.TabIndex = 17
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
        Me.pnl_content.Controls.Add(Me.Label1)
        Me.pnl_content.Controls.Add(Me.Label9)
        Me.pnl_content.Controls.Add(Me.in_kode)
        Me.pnl_content.Controls.Add(Me.Label10)
        Me.pnl_content.Controls.Add(Me.in_status)
        Me.pnl_content.Controls.Add(Me.Label2)
        Me.pnl_content.Controls.Add(Me.Label13)
        Me.pnl_content.Controls.Add(Me.Label7)
        Me.pnl_content.Controls.Add(Me.Label11)
        Me.pnl_content.Controls.Add(Me.Label8)
        Me.pnl_content.Controls.Add(Me.cb_jenis)
        Me.pnl_content.Controls.Add(Me.in_bank_rek)
        Me.pnl_content.Controls.Add(Me.Label15)
        Me.pnl_content.Controls.Add(Me.in_bank_an)
        Me.pnl_content.Controls.Add(Me.Label6)
        Me.pnl_content.Controls.Add(Me.Label5)
        Me.pnl_content.Controls.Add(Me.in_namasales)
        Me.pnl_content.Controls.Add(Me.in_ket)
        Me.pnl_content.Controls.Add(Me.in_email)
        Me.pnl_content.Controls.Add(Me.in_alamatsales)
        Me.pnl_content.Controls.Add(Me.in_telpsales)
        Me.pnl_content.Controls.Add(Me.in_nik)
        Me.pnl_content.Controls.Add(Me.in_bank_nama)
        Me.pnl_content.Controls.Add(Me.in_faxsales)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_content.Location = New System.Drawing.Point(0, 42)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(909, 385)
        Me.pnl_content.TabIndex = 0
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(85, 323)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(179, 22)
        Me.txtRegdate.TabIndex = 12
        Me.txtRegdate.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(12, 351)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(66, 15)
        Me.Label28.TabIndex = 443
        Me.Label28.Text = "LastUpdate"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(270, 351)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(20, 15)
        Me.Label30.TabIndex = 442
        Me.Label30.Text = "By"
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(85, 347)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(179, 22)
        Me.txtUpdDate.TabIndex = 14
        Me.txtUpdDate.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(12, 326)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(48, 15)
        Me.Label29.TabIndex = 440
        Me.Label29.Text = "Inputed"
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(293, 347)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(106, 22)
        Me.txtUpdAlias.TabIndex = 15
        Me.txtUpdAlias.TabStop = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(293, 323)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(106, 22)
        Me.txtRegAlias.TabIndex = 13
        Me.txtRegAlias.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(270, 327)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(20, 15)
        Me.Label27.TabIndex = 441
        Me.Label27.Text = "By"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 218)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 15)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Email"
        '
        'in_email
        '
        Me.in_email.BackColor = System.Drawing.Color.White
        Me.in_email.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_email.ForeColor = System.Drawing.Color.Black
        Me.in_email.Location = New System.Drawing.Point(85, 215)
        Me.in_email.MaxLength = 255
        Me.in_email.Name = "in_email"
        Me.in_email.Size = New System.Drawing.Size(359, 22)
        Me.in_email.TabIndex = 6
        '
        'ctx_main
        '
        Me.ctx_main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstrip_simpan, Me.tstrip_status, Me.ToolStripSeparator4, Me.tstrip_setupsales, Me.ToolStripSeparator3, Me.tsrtip_close})
        Me.ctx_main.Name = "ctx_main"
        Me.ctx_main.Size = New System.Drawing.Size(184, 104)
        '
        'tstrip_simpan
        '
        Me.tstrip_simpan.Name = "tstrip_simpan"
        Me.tstrip_simpan.Size = New System.Drawing.Size(183, 22)
        Me.tstrip_simpan.Text = "Simpan"
        '
        'tstrip_status
        '
        Me.tstrip_status.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstrip_activate, Me.tstrip_inactivate, Me.ToolStripSeparator2, Me.tstrip_delete})
        Me.tstrip_status.Name = "tstrip_status"
        Me.tstrip_status.Size = New System.Drawing.Size(183, 22)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(180, 6)
        '
        'tstrip_setupsales
        '
        Me.tstrip_setupsales.Name = "tstrip_setupsales"
        Me.tstrip_setupsales.Size = New System.Drawing.Size(183, 22)
        Me.tstrip_setupsales.Text = "Set Gudang / Barang"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(180, 6)
        '
        'tsrtip_close
        '
        Me.tsrtip_close.Name = "tsrtip_close"
        Me.tsrtip_close.Size = New System.Drawing.Size(183, 22)
        Me.tsrtip_close.Text = "Tutup Form"
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
        Me.pnl_header.Name = "pnl_header"
        Me.pnl_header.Size = New System.Drawing.Size(909, 42)
        Me.pnl_header.TabIndex = 288
        '
        'bt_menu
        '
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
        Me.bt_menu.TabIndex = 138
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
        Me.bt_cl.Location = New System.Drawing.Point(851, 0)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(55, 30)
        Me.bt_cl.TabIndex = 137
        Me.bt_cl.TabStop = False
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.White
        Me.lbl_title.Font = New System.Drawing.Font("Open Sans", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lbl_title.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbl_title.Location = New System.Drawing.Point(35, 8)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(162, 26)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Detail Salesman"
        '
        'in_ket
        '
        Me.in_ket.BackColor = System.Drawing.Color.White
        Me.in_ket.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.ForeColor = System.Drawing.Color.Black
        Me.in_ket.Location = New System.Drawing.Point(592, 132)
        Me.in_ket.MaxLength = 200
        Me.in_ket.Multiline = True
        Me.in_ket.Name = "in_ket"
        Me.in_ket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_ket.Size = New System.Drawing.Size(289, 65)
        Me.in_ket.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(499, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 15)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Keterangan"
        '
        'fr_sales_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(909, 479)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.pnl_header)
        Me.Controls.Add(Me.pnl_footer)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_sales_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Salesman :  "
        Me.pnl_footer.ResumeLayout(False)
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.ctx_main.ResumeLayout(False)
        Me.pnl_header.ResumeLayout(False)
        Me.pnl_header.PerformLayout()
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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_bank_nama As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cb_jenis As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents in_status As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pnl_footer As System.Windows.Forms.Panel
    Friend WithEvents bt_batalcusto As System.Windows.Forms.Button
    Friend WithEvents bt_simpancusto As System.Windows.Forms.Button
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_email As System.Windows.Forms.TextBox
    Friend WithEvents ctx_main As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tstrip_simpan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstrip_status As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstrip_activate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tstrip_inactivate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstrip_delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tstrip_setupsales As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsrtip_close As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnl_header As System.Windows.Forms.Panel
    Friend WithEvents bt_menu As System.Windows.Forms.Button
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
End Class
