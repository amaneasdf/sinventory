<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_jual_tagihan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_jual_tagihan))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.date_tgl_trans = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgv_sales = New System.Windows.Forms.DataGridView()
        Me.sales_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sales_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv_listfaktur = New System.Windows.Forms.DataGridView()
        Me.bt_addfaktur = New System.Windows.Forms.Button()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ck_tgl1 = New System.Windows.Forms.CheckBox()
        Me.ck_tgl2 = New System.Windows.Forms.CheckBox()
        Me.ck_sales = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.in_no_bukti = New System.Windows.Forms.TextBox()
        Me.bt_cari = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.dgv_draftfaktur = New System.Windows.Forms.DataGridView()
        Me.bt_close = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.bt_sales = New System.Windows.Forms.Button()
        Me.list_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_tanggal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_custo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_netto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_draft = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv_sales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_listfaktur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_draftfaktur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tgl"
        '
        'date_tgl_trans
        '
        Me.date_tgl_trans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_trans.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_tgl_trans.Location = New System.Drawing.Point(12, 64)
        Me.date_tgl_trans.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_trans.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_trans.Name = "date_tgl_trans"
        Me.date_tgl_trans.Size = New System.Drawing.Size(104, 20)
        Me.date_tgl_trans.TabIndex = 0
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(160, 64)
        Me.DateTimePicker1.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.DateTimePicker1.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(104, 20)
        Me.DateTimePicker1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(157, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tgl"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(298, 64)
        Me.DateTimePicker2.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.DateTimePicker2.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(104, 20)
        Me.DateTimePicker2.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(270, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tgl"
        '
        'dgv_sales
        '
        Me.dgv_sales.AllowUserToAddRows = False
        Me.dgv_sales.AllowUserToDeleteRows = False
        Me.dgv_sales.BackgroundColor = System.Drawing.Color.White
        Me.dgv_sales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_sales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sales_kode, Me.sales_nama})
        Me.dgv_sales.Location = New System.Drawing.Point(12, 90)
        Me.dgv_sales.Name = "dgv_sales"
        Me.dgv_sales.ReadOnly = True
        Me.dgv_sales.RowHeadersVisible = False
        Me.dgv_sales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_sales.Size = New System.Drawing.Size(390, 107)
        Me.dgv_sales.TabIndex = 20
        '
        'sales_kode
        '
        Me.sales_kode.DataPropertyName = "kode"
        Me.sales_kode.HeaderText = "Kode"
        Me.sales_kode.Name = "sales_kode"
        Me.sales_kode.ReadOnly = True
        '
        'sales_nama
        '
        Me.sales_nama.DataPropertyName = "nama"
        Me.sales_nama.HeaderText = "Nama"
        Me.sales_nama.MinimumWidth = 190
        Me.sales_nama.Name = "sales_nama"
        Me.sales_nama.ReadOnly = True
        Me.sales_nama.Width = 190
        '
        'dgv_listfaktur
        '
        Me.dgv_listfaktur.AllowUserToAddRows = False
        Me.dgv_listfaktur.AllowUserToDeleteRows = False
        Me.dgv_listfaktur.BackgroundColor = System.Drawing.Color.White
        Me.dgv_listfaktur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listfaktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.list_faktur, Me.list_tanggal, Me.list_custo, Me.list_netto, Me.list_draft})
        Me.dgv_listfaktur.Location = New System.Drawing.Point(12, 233)
        Me.dgv_listfaktur.Name = "dgv_listfaktur"
        Me.dgv_listfaktur.ReadOnly = True
        Me.dgv_listfaktur.RowHeadersVisible = False
        Me.dgv_listfaktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listfaktur.Size = New System.Drawing.Size(519, 174)
        Me.dgv_listfaktur.TabIndex = 20
        '
        'bt_addfaktur
        '
        Me.bt_addfaktur.Location = New System.Drawing.Point(536, 287)
        Me.bt_addfaktur.Name = "bt_addfaktur"
        Me.bt_addfaktur.Size = New System.Drawing.Size(38, 41)
        Me.bt_addfaktur.TabIndex = 21
        Me.bt_addfaktur.Text = ">>"
        Me.bt_addfaktur.UseVisualStyleBackColor = True
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18})
        Me.DataGridView3.Location = New System.Drawing.Point(12, 413)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.RowHeadersVisible = False
        Me.DataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView3.Size = New System.Drawing.Size(908, 117)
        Me.DataGridView3.TabIndex = 20
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "trans_barang"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Kode"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "barang_nama"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Nama Barang"
        Me.DataGridViewTextBoxColumn14.MinimumWidth = 190
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Width = 190
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "trans_qty"
        Me.DataGridViewTextBoxColumn15.HeaderText = "QTY"
        Me.DataGridViewTextBoxColumn15.MinimumWidth = 60
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 60
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "trans_satuan"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Satuan"
        Me.DataGridViewTextBoxColumn16.MinimumWidth = 60
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn16.Width = 60
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "trans_harga_retur"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Harga Retur"
        Me.DataGridViewTextBoxColumn17.MinimumWidth = 110
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Width = 110
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "trans_jumlah"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Jumlah"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'ck_tgl1
        '
        Me.ck_tgl1.AutoSize = True
        Me.ck_tgl1.Location = New System.Drawing.Point(411, 67)
        Me.ck_tgl1.Name = "ck_tgl1"
        Me.ck_tgl1.Size = New System.Drawing.Size(144, 17)
        Me.ck_tgl1.TabIndex = 22
        Me.ck_tgl1.Text = "Filter sblm tgl jatuh tempo"
        Me.ck_tgl1.UseVisualStyleBackColor = True
        '
        'ck_tgl2
        '
        Me.ck_tgl2.AutoSize = True
        Me.ck_tgl2.Location = New System.Drawing.Point(411, 90)
        Me.ck_tgl2.Name = "ck_tgl2"
        Me.ck_tgl2.Size = New System.Drawing.Size(120, 17)
        Me.ck_tgl2.TabIndex = 22
        Me.ck_tgl2.Text = "Filter tgl jatuh tempo"
        Me.ck_tgl2.UseVisualStyleBackColor = True
        '
        'ck_sales
        '
        Me.ck_sales.AutoSize = True
        Me.ck_sales.Location = New System.Drawing.Point(411, 113)
        Me.ck_sales.Name = "ck_sales"
        Me.ck_sales.Size = New System.Drawing.Size(77, 17)
        Me.ck_sales.TabIndex = 22
        Me.ck_sales.Text = "Filter Sales"
        Me.ck_sales.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 210)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 272
        Me.Label4.Text = "No. Retur"
        '
        'in_no_bukti
        '
        Me.in_no_bukti.BackColor = System.Drawing.Color.White
        Me.in_no_bukti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_no_bukti.ForeColor = System.Drawing.Color.Black
        Me.in_no_bukti.Location = New System.Drawing.Point(66, 207)
        Me.in_no_bukti.MaxLength = 30
        Me.in_no_bukti.Name = "in_no_bukti"
        Me.in_no_bukti.Size = New System.Drawing.Size(188, 20)
        Me.in_no_bukti.TabIndex = 271
        Me.in_no_bukti.TabStop = False
        '
        'bt_cari
        '
        Me.bt_cari.Location = New System.Drawing.Point(260, 207)
        Me.bt_cari.Name = "bt_cari"
        Me.bt_cari.Size = New System.Drawing.Size(38, 20)
        Me.bt_cari.TabIndex = 21
        Me.bt_cari.Text = "Cari"
        Me.bt_cari.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(796, 200)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(124, 27)
        Me.Button3.TabIndex = 21
        Me.Button3.Text = "Cetak Draft Tagihan"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(580, 200)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(46, 27)
        Me.Button6.TabIndex = 21
        Me.Button6.Text = "Clear"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'dgv_draftfaktur
        '
        Me.dgv_draftfaktur.AllowUserToAddRows = False
        Me.dgv_draftfaktur.AllowUserToDeleteRows = False
        Me.dgv_draftfaktur.BackgroundColor = System.Drawing.Color.White
        Me.dgv_draftfaktur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_draftfaktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn4})
        Me.dgv_draftfaktur.Location = New System.Drawing.Point(580, 233)
        Me.dgv_draftfaktur.Name = "dgv_draftfaktur"
        Me.dgv_draftfaktur.ReadOnly = True
        Me.dgv_draftfaktur.RowHeadersVisible = False
        Me.dgv_draftfaktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_draftfaktur.Size = New System.Drawing.Size(340, 174)
        Me.dgv_draftfaktur.TabIndex = 273
        '
        'bt_close
        '
        Me.bt_close.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_close.Location = New System.Drawing.Point(828, 539)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(92, 27)
        Me.bt_close.TabIndex = 21
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(644, 200)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(46, 27)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(690, 200)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 27)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "V"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.lbl_close)
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(932, 42)
        Me.Panel1.TabIndex = 276
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(852, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(905, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 137
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Orange
        Me.Label13.Font = New System.Drawing.Font("Source Sans Pro", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(6, 4)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(240, 30)
        Me.Label13.TabIndex = 136
        Me.Label13.Text = "Data Retur Penjualan"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Location = New System.Drawing.Point(411, 136)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(238, 32)
        Me.Panel2.TabIndex = 291
        Me.Panel2.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(3, 9)
        Me.TextBox1.MaxLength = 30
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(188, 20)
        Me.TextBox1.TabIndex = 271
        Me.TextBox1.TabStop = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(197, 9)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(38, 20)
        Me.Button4.TabIndex = 21
        Me.Button4.Text = "Cari"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'bt_sales
        '
        Me.bt_sales.BackColor = System.Drawing.Color.Transparent
        Me.bt_sales.BackgroundImage = CType(resources.GetObject("bt_sales.BackgroundImage"), System.Drawing.Image)
        Me.bt_sales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_sales.FlatAppearance.BorderSize = 0
        Me.bt_sales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_sales.Location = New System.Drawing.Point(488, 113)
        Me.bt_sales.Name = "bt_sales"
        Me.bt_sales.Size = New System.Drawing.Size(12, 15)
        Me.bt_sales.TabIndex = 290
        Me.bt_sales.TabStop = False
        Me.bt_sales.UseVisualStyleBackColor = False
        '
        'list_faktur
        '
        Me.list_faktur.DataPropertyName = "faktur_kode"
        Me.list_faktur.HeaderText = "No.Faktur"
        Me.list_faktur.Name = "list_faktur"
        Me.list_faktur.ReadOnly = True
        Me.list_faktur.Width = 90
        '
        'list_tanggal
        '
        Me.list_tanggal.DataPropertyName = "faktur_tanggal_trans"
        Me.list_tanggal.HeaderText = "Tanggal"
        Me.list_tanggal.MinimumWidth = 90
        Me.list_tanggal.Name = "list_tanggal"
        Me.list_tanggal.ReadOnly = True
        Me.list_tanggal.Width = 90
        '
        'list_custo
        '
        Me.list_custo.DataPropertyName = "customer_nama"
        Me.list_custo.HeaderText = "Customer"
        Me.list_custo.MinimumWidth = 160
        Me.list_custo.Name = "list_custo"
        Me.list_custo.ReadOnly = True
        Me.list_custo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.list_custo.Width = 160
        '
        'list_netto
        '
        Me.list_netto.DataPropertyName = "faktur_netto"
        Me.list_netto.HeaderText = "Sisa"
        Me.list_netto.MinimumWidth = 95
        Me.list_netto.Name = "list_netto"
        Me.list_netto.ReadOnly = True
        Me.list_netto.Width = 95
        '
        'list_draft
        '
        Me.list_draft.DataPropertyName = "faktur_draft_tagihan"
        Me.list_draft.HeaderText = "Draft"
        Me.list_draft.Name = "list_draft"
        Me.list_draft.ReadOnly = True
        Me.list_draft.Width = 50
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "customer_nama"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Customer"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 140
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.Width = 140
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "trans_faktur"
        Me.DataGridViewTextBoxColumn1.HeaderText = "No.Faktur"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 90
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "trans_harga_retur"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Sisa"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 90
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 90
        '
        'fr_jual_tagihan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.bt_close
        Me.ClientSize = New System.Drawing.Size(932, 578)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.bt_sales)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgv_draftfaktur)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.in_no_bukti)
        Me.Controls.Add(Me.ck_sales)
        Me.Controls.Add(Me.ck_tgl2)
        Me.Controls.Add(Me.ck_tgl1)
        Me.Controls.Add(Me.bt_cari)
        Me.Controls.Add(Me.bt_close)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.bt_addfaktur)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.dgv_listfaktur)
        Me.Controls.Add(Me.dgv_sales)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.date_tgl_trans)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "fr_jual_tagihan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fr_jual_rekap"
        CType(Me.dgv_sales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_listfaktur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_draftfaktur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents date_tgl_trans As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgv_sales As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_listfaktur As System.Windows.Forms.DataGridView
    Friend WithEvents bt_addfaktur As System.Windows.Forms.Button
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ck_tgl1 As System.Windows.Forms.CheckBox
    Friend WithEvents ck_tgl2 As System.Windows.Forms.CheckBox
    Friend WithEvents ck_sales As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents in_no_bukti As System.Windows.Forms.TextBox
    Friend WithEvents bt_cari As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents dgv_draftfaktur As System.Windows.Forms.DataGridView
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents bt_sales As System.Windows.Forms.Button
    Friend WithEvents sales_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_tanggal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_netto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_draft As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
