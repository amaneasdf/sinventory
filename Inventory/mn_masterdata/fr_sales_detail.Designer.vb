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
        Me.pic_sales = New System.Windows.Forms.PictureBox()
        Me.in_alamatsales = New System.Windows.Forms.TextBox()
        Me.in_nik = New System.Windows.Forms.TextBox()
        Me.bt_batalsales = New System.Windows.Forms.Button()
        Me.bt_simpansales = New System.Windows.Forms.Button()
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
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bt_gambar = New System.Windows.Forms.Button()
        Me.date_lahir_tgl = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_target = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_bank_nama = New System.Windows.Forms.TextBox()
        Me.cb_status = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.in_status_kode = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.date_kerja = New System.Windows.Forms.DateTimePicker()
        Me.in_jenis_kode = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cb_jenis = New System.Windows.Forms.ComboBox()
        CType(Me.pic_sales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pic_sales
        '
        Me.pic_sales.BackColor = System.Drawing.Color.LightGray
        Me.pic_sales.Enabled = False
        Me.pic_sales.Location = New System.Drawing.Point(532, 57)
        Me.pic_sales.Name = "pic_sales"
        Me.pic_sales.Size = New System.Drawing.Size(168, 170)
        Me.pic_sales.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_sales.TabIndex = 29
        Me.pic_sales.TabStop = False
        '
        'in_alamatsales
        '
        Me.in_alamatsales.BackColor = System.Drawing.Color.White
        Me.in_alamatsales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamatsales.ForeColor = System.Drawing.Color.Black
        Me.in_alamatsales.Location = New System.Drawing.Point(125, 117)
        Me.in_alamatsales.MaxLength = 200
        Me.in_alamatsales.Multiline = True
        Me.in_alamatsales.Name = "in_alamatsales"
        Me.in_alamatsales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_alamatsales.Size = New System.Drawing.Size(384, 84)
        Me.in_alamatsales.TabIndex = 2
        '
        'in_nik
        '
        Me.in_nik.BackColor = System.Drawing.Color.White
        Me.in_nik.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_nik.ForeColor = System.Drawing.Color.Black
        Me.in_nik.Location = New System.Drawing.Point(125, 315)
        Me.in_nik.MaxLength = 20
        Me.in_nik.Name = "in_nik"
        Me.in_nik.Size = New System.Drawing.Size(384, 22)
        Me.in_nik.TabIndex = 8
        '
        'bt_batalsales
        '
        Me.bt_batalsales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalsales.Location = New System.Drawing.Point(413, 498)
        Me.bt_batalsales.Name = "bt_batalsales"
        Me.bt_batalsales.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalsales.TabIndex = 16
        Me.bt_batalsales.Text = "Batal"
        Me.bt_batalsales.UseVisualStyleBackColor = True
        '
        'bt_simpansales
        '
        Me.bt_simpansales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpansales.Location = New System.Drawing.Point(311, 498)
        Me.bt_simpansales.Name = "bt_simpansales"
        Me.bt_simpansales.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpansales.TabIndex = 15
        Me.bt_simpansales.Text = "Simpan"
        Me.bt_simpansales.UseVisualStyleBackColor = True
        '
        'in_faxsales
        '
        Me.in_faxsales.BackColor = System.Drawing.Color.White
        Me.in_faxsales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_faxsales.ForeColor = System.Drawing.Color.Black
        Me.in_faxsales.Location = New System.Drawing.Point(342, 287)
        Me.in_faxsales.MaxLength = 20
        Me.in_faxsales.Name = "in_faxsales"
        Me.in_faxsales.Size = New System.Drawing.Size(167, 22)
        Me.in_faxsales.TabIndex = 7
        '
        'in_telpsales
        '
        Me.in_telpsales.BackColor = System.Drawing.Color.White
        Me.in_telpsales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_telpsales.ForeColor = System.Drawing.Color.Black
        Me.in_telpsales.Location = New System.Drawing.Point(125, 287)
        Me.in_telpsales.MaxLength = 20
        Me.in_telpsales.Name = "in_telpsales"
        Me.in_telpsales.Size = New System.Drawing.Size(167, 22)
        Me.in_telpsales.TabIndex = 6
        '
        'in_namasales
        '
        Me.in_namasales.BackColor = System.Drawing.Color.White
        Me.in_namasales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_namasales.ForeColor = System.Drawing.Color.Black
        Me.in_namasales.Location = New System.Drawing.Point(125, 89)
        Me.in_namasales.MaxLength = 50
        Me.in_namasales.Name = "in_namasales"
        Me.in_namasales.Size = New System.Drawing.Size(384, 22)
        Me.in_namasales.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Alamat"
        '
        'in_bank_an
        '
        Me.in_bank_an.BackColor = System.Drawing.Color.White
        Me.in_bank_an.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_bank_an.ForeColor = System.Drawing.Color.Black
        Me.in_bank_an.Location = New System.Drawing.Point(125, 427)
        Me.in_bank_an.MaxLength = 30
        Me.in_bank_an.Name = "in_bank_an"
        Me.in_bank_an.Size = New System.Drawing.Size(340, 22)
        Me.in_bank_an.TabIndex = 12
        '
        'in_bank_rek
        '
        Me.in_bank_rek.BackColor = System.Drawing.Color.White
        Me.in_bank_rek.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_bank_rek.ForeColor = System.Drawing.Color.Black
        Me.in_bank_rek.Location = New System.Drawing.Point(125, 399)
        Me.in_bank_rek.MaxLength = 20
        Me.in_bank_rek.Name = "in_bank_rek"
        Me.in_bank_rek.Size = New System.Drawing.Size(340, 22)
        Me.in_bank_rek.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 430)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Atas Nama Rek."
        '
        'in_lahir_kota
        '
        Me.in_lahir_kota.BackColor = System.Drawing.Color.White
        Me.in_lahir_kota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_lahir_kota.ForeColor = System.Drawing.Color.Black
        Me.in_lahir_kota.Location = New System.Drawing.Point(125, 259)
        Me.in_lahir_kota.MaxLength = 20
        Me.in_lahir_kota.Name = "in_lahir_kota"
        Me.in_lahir_kota.Size = New System.Drawing.Size(210, 22)
        Me.in_lahir_kota.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 318)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 16)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "NIK"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 402)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 16)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "No. Rek. Bank"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(303, 290)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 16)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Fax."
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.White
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.ForeColor = System.Drawing.Color.Black
        Me.in_kode.Location = New System.Drawing.Point(125, 59)
        Me.in_kode.MaxLength = 10
        Me.in_kode.Name = "in_kode"
        Me.in_kode.Size = New System.Drawing.Size(167, 22)
        Me.in_kode.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 290)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 16)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Telp."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 262)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 16)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Lahir"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Nama"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Kode"
        '
        'bt_gambar
        '
        Me.bt_gambar.Enabled = False
        Me.bt_gambar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_gambar.Location = New System.Drawing.Point(590, 231)
        Me.bt_gambar.Name = "bt_gambar"
        Me.bt_gambar.Size = New System.Drawing.Size(110, 33)
        Me.bt_gambar.TabIndex = 14
        Me.bt_gambar.Text = "Ubah Gambar"
        Me.bt_gambar.UseVisualStyleBackColor = True
        '
        'date_lahir_tgl
        '
        Me.date_lahir_tgl.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_lahir_tgl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_lahir_tgl.Location = New System.Drawing.Point(341, 259)
        Me.date_lahir_tgl.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.date_lahir_tgl.MinDate = New Date(1950, 1, 1, 0, 0, 0, 0)
        Me.date_lahir_tgl.Name = "date_lahir_tgl"
        Me.date_lahir_tgl.Size = New System.Drawing.Size(168, 22)
        Me.date_lahir_tgl.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 346)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Target"
        '
        'in_target
        '
        Me.in_target.BackColor = System.Drawing.Color.White
        Me.in_target.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_target.ForeColor = System.Drawing.Color.Black
        Me.in_target.Location = New System.Drawing.Point(125, 343)
        Me.in_target.MaxLength = 20
        Me.in_target.Name = "in_target"
        Me.in_target.Size = New System.Drawing.Size(211, 22)
        Me.in_target.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 374)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Bank"
        '
        'in_bank_nama
        '
        Me.in_bank_nama.BackColor = System.Drawing.Color.White
        Me.in_bank_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_bank_nama.ForeColor = System.Drawing.Color.Black
        Me.in_bank_nama.Location = New System.Drawing.Point(125, 371)
        Me.in_bank_nama.MaxLength = 20
        Me.in_bank_nama.Name = "in_bank_nama"
        Me.in_bank_nama.Size = New System.Drawing.Size(211, 22)
        Me.in_bank_nama.TabIndex = 10
        '
        'cb_status
        '
        Me.cb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_status.FormattingEnabled = True
        Me.cb_status.Location = New System.Drawing.Point(188, 455)
        Me.cb_status.Name = "cb_status"
        Me.cb_status.Size = New System.Drawing.Size(175, 23)
        Me.cb_status.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(14, 458)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 16)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Status"
        '
        'in_status_kode
        '
        Me.in_status_kode.BackColor = System.Drawing.Color.White
        Me.in_status_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status_kode.ForeColor = System.Drawing.Color.Black
        Me.in_status_kode.Location = New System.Drawing.Point(125, 455)
        Me.in_status_kode.MaxLength = 5
        Me.in_status_kode.Name = "in_status_kode"
        Me.in_status_kode.ReadOnly = True
        Me.in_status_kode.Size = New System.Drawing.Size(57, 22)
        Me.in_status_kode.TabIndex = 31
        Me.in_status_kode.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtRegAlias)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtUpdAlias)
        Me.GroupBox1.Controls.Add(Me.txtRegdate)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtUpdDate)
        Me.GroupBox1.Location = New System.Drawing.Point(515, 310)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(191, 218)
        Me.GroupBox1.TabIndex = 133
        Me.GroupBox1.TabStop = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(12, 85)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(173, 22)
        Me.txtRegAlias.TabIndex = 116
        Me.txtRegAlias.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(9, 66)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 16)
        Me.Label16.TabIndex = 119
        Me.Label16.Text = "Reg Alias"
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(12, 172)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(173, 22)
        Me.txtUpdAlias.TabIndex = 122
        Me.txtUpdAlias.TabStop = False
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(12, 41)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(173, 22)
        Me.txtRegdate.TabIndex = 115
        Me.txtRegdate.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(9, 153)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 16)
        Me.Label17.TabIndex = 125
        Me.Label17.Text = "Update Alias"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(9, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 16)
        Me.Label18.TabIndex = 118
        Me.Label18.Text = "Reg Date"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(9, 110)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 16)
        Me.Label19.TabIndex = 124
        Me.Label19.Text = "Update Date"
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(12, 128)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(173, 22)
        Me.txtUpdDate.TabIndex = 115
        Me.txtUpdDate.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Orange
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(184, 20)
        Me.Label14.TabIndex = 135
        Me.Label14.Text = "Detail Data Salesman"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(718, 42)
        Me.Panel1.TabIndex = 136
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 16)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Mulai Kerja"
        '
        'date_kerja
        '
        Me.date_kerja.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_kerja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_kerja.Location = New System.Drawing.Point(125, 205)
        Me.date_kerja.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.date_kerja.MinDate = New Date(1950, 1, 1, 0, 0, 0, 0)
        Me.date_kerja.Name = "date_kerja"
        Me.date_kerja.Size = New System.Drawing.Size(210, 22)
        Me.date_kerja.TabIndex = 3
        '
        'in_jenis_kode
        '
        Me.in_jenis_kode.BackColor = System.Drawing.Color.White
        Me.in_jenis_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_jenis_kode.ForeColor = System.Drawing.Color.Black
        Me.in_jenis_kode.Location = New System.Drawing.Point(125, 231)
        Me.in_jenis_kode.MaxLength = 5
        Me.in_jenis_kode.Name = "in_jenis_kode"
        Me.in_jenis_kode.ReadOnly = True
        Me.in_jenis_kode.Size = New System.Drawing.Size(57, 22)
        Me.in_jenis_kode.TabIndex = 31
        Me.in_jenis_kode.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(14, 234)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 16)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Jenis"
        '
        'cb_jenis
        '
        Me.cb_jenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_jenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_jenis.FormattingEnabled = True
        Me.cb_jenis.Location = New System.Drawing.Point(188, 231)
        Me.cb_jenis.Name = "cb_jenis"
        Me.cb_jenis.Size = New System.Drawing.Size(175, 23)
        Me.cb_jenis.TabIndex = 13
        '
        'fr_sales_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 540)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cb_jenis)
        Me.Controls.Add(Me.cb_status)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.in_jenis_kode)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.in_status_kode)
        Me.Controls.Add(Me.date_kerja)
        Me.Controls.Add(Me.date_lahir_tgl)
        Me.Controls.Add(Me.pic_sales)
        Me.Controls.Add(Me.in_alamatsales)
        Me.Controls.Add(Me.in_nik)
        Me.Controls.Add(Me.bt_batalsales)
        Me.Controls.Add(Me.bt_gambar)
        Me.Controls.Add(Me.bt_simpansales)
        Me.Controls.Add(Me.in_faxsales)
        Me.Controls.Add(Me.in_bank_nama)
        Me.Controls.Add(Me.in_target)
        Me.Controls.Add(Me.in_telpsales)
        Me.Controls.Add(Me.in_namasales)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.in_bank_an)
        Me.Controls.Add(Me.in_bank_rek)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.in_lahir_kota)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.in_kode)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "fr_sales_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detail Salesman :  "
        CType(Me.pic_sales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pic_sales As System.Windows.Forms.PictureBox
    Friend WithEvents in_alamatsales As System.Windows.Forms.TextBox
    Friend WithEvents in_nik As System.Windows.Forms.TextBox
    Friend WithEvents bt_batalsales As System.Windows.Forms.Button
    Friend WithEvents bt_simpansales As System.Windows.Forms.Button
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
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents bt_gambar As System.Windows.Forms.Button
    Friend WithEvents date_lahir_tgl As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_target As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_bank_nama As System.Windows.Forms.TextBox
    Friend WithEvents cb_status As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents in_status_kode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents date_kerja As System.Windows.Forms.DateTimePicker
    Friend WithEvents in_jenis_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cb_jenis As System.Windows.Forms.ComboBox
End Class
