<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_jual_rekap
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.date_tgl_trans = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgv_listfaktur = New System.Windows.Forms.DataGridView()
        Me.list_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_tanggal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_custo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_netto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_draft = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bt_addfaktur = New System.Windows.Forms.Button()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ck_tgl2 = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.in_no_bukti = New System.Windows.Forms.TextBox()
        Me.bt_cari = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dgv_draftfaktur = New System.Windows.Forms.DataGridView()
        Me.draft_custo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_netto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bt_close = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.draftlist_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draftlist_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draftlist_sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.sales_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sales_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv_sales = New System.Windows.Forms.DataGridView()
        Me.ck_sales = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_cari_sales = New System.Windows.Forms.TextBox()
        Me.bt_cari_sales = New System.Windows.Forms.Button()
        CType(Me.dgv_listfaktur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_draftfaktur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_sales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tgl Cetak"
        '
        'date_tgl_trans
        '
        Me.date_tgl_trans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_trans.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_tgl_trans.Location = New System.Drawing.Point(12, 65)
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
        Me.DateTimePicker1.Location = New System.Drawing.Point(142, 65)
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
        Me.Label1.Location = New System.Drawing.Point(139, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tgl Nota"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(280, 65)
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
        Me.Label3.Location = New System.Drawing.Point(252, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "s.d."
        '
        'dgv_listfaktur
        '
        Me.dgv_listfaktur.AllowUserToAddRows = False
        Me.dgv_listfaktur.AllowUserToDeleteRows = False
        Me.dgv_listfaktur.BackgroundColor = System.Drawing.Color.White
        Me.dgv_listfaktur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listfaktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.list_faktur, Me.list_tanggal, Me.list_custo, Me.list_netto, Me.list_draft})
        Me.dgv_listfaktur.Location = New System.Drawing.Point(12, 234)
        Me.dgv_listfaktur.Name = "dgv_listfaktur"
        Me.dgv_listfaktur.ReadOnly = True
        Me.dgv_listfaktur.RowHeadersVisible = False
        Me.dgv_listfaktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listfaktur.Size = New System.Drawing.Size(519, 174)
        Me.dgv_listfaktur.TabIndex = 20
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
        Me.list_netto.HeaderText = "Netto"
        Me.list_netto.MinimumWidth = 95
        Me.list_netto.Name = "list_netto"
        Me.list_netto.ReadOnly = True
        Me.list_netto.Width = 95
        '
        'list_draft
        '
        Me.list_draft.HeaderText = "Draft"
        Me.list_draft.Name = "list_draft"
        Me.list_draft.ReadOnly = True
        Me.list_draft.Width = 50
        '
        'bt_addfaktur
        '
        Me.bt_addfaktur.Location = New System.Drawing.Point(536, 234)
        Me.bt_addfaktur.Name = "bt_addfaktur"
        Me.bt_addfaktur.Size = New System.Drawing.Size(27, 174)
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
        Me.DataGridView3.Location = New System.Drawing.Point(12, 414)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.RowHeadersVisible = False
        Me.DataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView3.Size = New System.Drawing.Size(897, 117)
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
        'ck_tgl2
        '
        Me.ck_tgl2.AutoSize = True
        Me.ck_tgl2.Location = New System.Drawing.Point(337, 117)
        Me.ck_tgl2.Name = "ck_tgl2"
        Me.ck_tgl2.Size = New System.Drawing.Size(95, 17)
        Me.ck_tgl2.TabIndex = 22
        Me.ck_tgl2.Text = "Filter tgl Faktur"
        Me.ck_tgl2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 211)
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
        Me.in_no_bukti.Location = New System.Drawing.Point(66, 208)
        Me.in_no_bukti.MaxLength = 30
        Me.in_no_bukti.Name = "in_no_bukti"
        Me.in_no_bukti.Size = New System.Drawing.Size(188, 20)
        Me.in_no_bukti.TabIndex = 271
        Me.in_no_bukti.TabStop = False
        '
        'bt_cari
        '
        Me.bt_cari.Location = New System.Drawing.Point(260, 208)
        Me.bt_cari.Name = "bt_cari"
        Me.bt_cari.Size = New System.Drawing.Size(38, 20)
        Me.bt_cari.TabIndex = 21
        Me.bt_cari.Text = "Cari"
        Me.bt_cari.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(785, 205)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(124, 27)
        Me.Button3.TabIndex = 21
        Me.Button3.Text = "Cetak Draft Nota"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dgv_draftfaktur
        '
        Me.dgv_draftfaktur.AllowUserToAddRows = False
        Me.dgv_draftfaktur.AllowUserToDeleteRows = False
        Me.dgv_draftfaktur.BackgroundColor = System.Drawing.Color.White
        Me.dgv_draftfaktur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_draftfaktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.draft_custo, Me.draft_faktur, Me.draft_netto})
        Me.dgv_draftfaktur.Location = New System.Drawing.Point(569, 234)
        Me.dgv_draftfaktur.Name = "dgv_draftfaktur"
        Me.dgv_draftfaktur.ReadOnly = True
        Me.dgv_draftfaktur.RowHeadersVisible = False
        Me.dgv_draftfaktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_draftfaktur.Size = New System.Drawing.Size(340, 174)
        Me.dgv_draftfaktur.TabIndex = 273
        '
        'draft_custo
        '
        Me.draft_custo.DataPropertyName = "customer_nama"
        Me.draft_custo.HeaderText = "Customer"
        Me.draft_custo.MinimumWidth = 140
        Me.draft_custo.Name = "draft_custo"
        Me.draft_custo.ReadOnly = True
        Me.draft_custo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.draft_custo.Width = 140
        '
        'draft_faktur
        '
        Me.draft_faktur.DataPropertyName = "trans_faktur"
        Me.draft_faktur.HeaderText = "No.Faktur"
        Me.draft_faktur.Name = "draft_faktur"
        Me.draft_faktur.ReadOnly = True
        Me.draft_faktur.Width = 90
        '
        'draft_netto
        '
        Me.draft_netto.DataPropertyName = "trans_harga_retur"
        Me.draft_netto.HeaderText = "Netto"
        Me.draft_netto.MinimumWidth = 90
        Me.draft_netto.Name = "draft_netto"
        Me.draft_netto.ReadOnly = True
        Me.draft_netto.Width = 90
        '
        'bt_close
        '
        Me.bt_close.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_close.Location = New System.Drawing.Point(817, 540)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(92, 27)
        Me.bt_close.TabIndex = 21
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(655, 205)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(124, 27)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Cetak Draft Barang"
        Me.Button1.UseVisualStyleBackColor = True
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
        Me.Panel1.Size = New System.Drawing.Size(920, 42)
        Me.Panel1.TabIndex = 275
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(840, 9)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(47, 20)
        Me.lbl_close.TabIndex = 138
        Me.lbl_close.Text = "Close"
        Me.lbl_close.Visible = False
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Orange
        Me.lbl_title.Font = New System.Drawing.Font("Source Sans Pro", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(6, 4)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(192, 30)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Rekap Penjualan"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.draftlist_kode, Me.draftlist_tgl, Me.draftlist_sales})
        Me.DataGridView1.Location = New System.Drawing.Point(451, 65)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(458, 137)
        Me.DataGridView1.TabIndex = 20
        '
        'draftlist_kode
        '
        Me.draftlist_kode.DataPropertyName = "kode"
        Me.draftlist_kode.HeaderText = "Kode Draft"
        Me.draftlist_kode.MinimumWidth = 100
        Me.draftlist_kode.Name = "draftlist_kode"
        Me.draftlist_kode.ReadOnly = True
        Me.draftlist_kode.Width = 125
        '
        'draftlist_tgl
        '
        Me.draftlist_tgl.DataPropertyName = "tanggal"
        Me.draftlist_tgl.HeaderText = "Tanggal"
        Me.draftlist_tgl.MinimumWidth = 50
        Me.draftlist_tgl.Name = "draftlist_tgl"
        Me.draftlist_tgl.ReadOnly = True
        '
        'draftlist_sales
        '
        Me.draftlist_sales.DataPropertyName = "sales"
        Me.draftlist_sales.HeaderText = "Salesman"
        Me.draftlist_sales.MinimumWidth = 175
        Me.draftlist_sales.Name = "draftlist_sales"
        Me.draftlist_sales.ReadOnly = True
        Me.draftlist_sales.Width = 175
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
        Me.bt_cl.Location = New System.Drawing.Point(893, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 137
        Me.bt_cl.UseVisualStyleBackColor = False
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
        'sales_kode
        '
        Me.sales_kode.DataPropertyName = "kode"
        Me.sales_kode.HeaderText = "Kode"
        Me.sales_kode.Name = "sales_kode"
        Me.sales_kode.ReadOnly = True
        '
        'dgv_sales
        '
        Me.dgv_sales.AllowUserToAddRows = False
        Me.dgv_sales.AllowUserToDeleteRows = False
        Me.dgv_sales.BackgroundColor = System.Drawing.Color.White
        Me.dgv_sales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_sales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sales_kode, Me.sales_nama})
        Me.dgv_sales.Location = New System.Drawing.Point(10, 117)
        Me.dgv_sales.Name = "dgv_sales"
        Me.dgv_sales.ReadOnly = True
        Me.dgv_sales.RowHeadersVisible = False
        Me.dgv_sales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_sales.Size = New System.Drawing.Size(321, 85)
        Me.dgv_sales.TabIndex = 20
        '
        'ck_sales
        '
        Me.ck_sales.AutoSize = True
        Me.ck_sales.Location = New System.Drawing.Point(337, 140)
        Me.ck_sales.Name = "ck_sales"
        Me.ck_sales.Size = New System.Drawing.Size(77, 17)
        Me.ck_sales.TabIndex = 22
        Me.ck_sales.Text = "Filter Sales"
        Me.ck_sales.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 272
        Me.Label5.Text = "Sales"
        '
        'in_cari_sales
        '
        Me.in_cari_sales.BackColor = System.Drawing.Color.White
        Me.in_cari_sales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari_sales.ForeColor = System.Drawing.Color.Black
        Me.in_cari_sales.Location = New System.Drawing.Point(66, 91)
        Me.in_cari_sales.MaxLength = 30
        Me.in_cari_sales.Name = "in_cari_sales"
        Me.in_cari_sales.Size = New System.Drawing.Size(188, 20)
        Me.in_cari_sales.TabIndex = 271
        Me.in_cari_sales.TabStop = False
        '
        'bt_cari_sales
        '
        Me.bt_cari_sales.Location = New System.Drawing.Point(260, 91)
        Me.bt_cari_sales.Name = "bt_cari_sales"
        Me.bt_cari_sales.Size = New System.Drawing.Size(38, 20)
        Me.bt_cari_sales.TabIndex = 21
        Me.bt_cari_sales.Text = "Cari"
        Me.bt_cari_sales.UseVisualStyleBackColor = True
        '
        'fr_jual_rekap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.bt_close
        Me.ClientSize = New System.Drawing.Size(920, 579)
        Me.Controls.Add(Me.bt_cari_sales)
        Me.Controls.Add(Me.in_cari_sales)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgv_draftfaktur)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.in_no_bukti)
        Me.Controls.Add(Me.ck_sales)
        Me.Controls.Add(Me.ck_tgl2)
        Me.Controls.Add(Me.bt_cari)
        Me.Controls.Add(Me.bt_close)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.bt_addfaktur)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.dgv_listfaktur)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.dgv_sales)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.date_tgl_trans)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "fr_jual_rekap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fr_jual_rekap"
        CType(Me.dgv_listfaktur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_draftfaktur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_sales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents date_tgl_trans As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgv_listfaktur As System.Windows.Forms.DataGridView
    Friend WithEvents bt_addfaktur As System.Windows.Forms.Button
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ck_tgl2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents in_no_bukti As System.Windows.Forms.TextBox
    Friend WithEvents bt_cari As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents dgv_draftfaktur As System.Windows.Forms.DataGridView
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents draft_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_netto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_tanggal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_netto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_draft As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents draftlist_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draftlist_tgl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draftlist_sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgv_sales As System.Windows.Forms.DataGridView
    Friend WithEvents ck_sales As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_cari_sales As System.Windows.Forms.TextBox
    Friend WithEvents bt_cari_sales As System.Windows.Forms.Button
End Class
