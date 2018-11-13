<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_draft_rekap
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_draft_rekap))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.date_tgl_trans = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.date_faktur_akhir = New System.Windows.Forms.DateTimePicker()
        Me.date_faktur_awal = New System.Windows.Forms.DateTimePicker()
        Me.ck_tgl2 = New System.Windows.Forms.CheckBox()
        Me.bt_cari_sales = New System.Windows.Forms.Button()
        Me.in_cari_sales = New System.Windows.Forms.TextBox()
        Me.dgv_sales = New System.Windows.Forms.DataGridView()
        Me.sales_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sales_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv_draft_list = New System.Windows.Forms.DataGridView()
        Me.dgv_draftfaktur = New System.Windows.Forms.DataGridView()
        Me.draft_custo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_netto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.in_cari_faktur = New System.Windows.Forms.TextBox()
        Me.bt_cari_faktur = New System.Windows.Forms.Button()
        Me.bt_draft_barang = New System.Windows.Forms.Button()
        Me.bt_draft_nota = New System.Windows.Forms.Button()
        Me.bt_addfaktur = New System.Windows.Forms.Button()
        Me.dgv_listfaktur = New System.Windows.Forms.DataGridView()
        Me.list_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_tanggal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_custo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_netto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_draft = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bt_loaddraft = New System.Windows.Forms.Button()
        Me.mn_refresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_tambah = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_print = New System.Windows.Forms.ToolStripMenuItem()
        Me.DraftBarangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DraftNotaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.bt_addsales = New System.Windows.Forms.Button()
        Me.bt_remsales = New System.Windows.Forms.Button()
        Me.bt_remfaktur = New System.Windows.Forms.Button()
        Me.dgv_draftsales = New System.Windows.Forms.DataGridView()
        Me.draft_sales_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_sales_n = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.in_kode_draft = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.bt_caridraft = New System.Windows.Forms.Button()
        Me.in_caridraft = New System.Windows.Forms.TextBox()
        Me.bt_create_draft = New System.Windows.Forms.Button()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.draftlist_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draftlist_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draftlist_sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draftlist_countnota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draftlist_countitem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draftlist_gudang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_sales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_draft_list, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_draftfaktur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_listfaktur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgv_draftsales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnl_content.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(918, 42)
        Me.Panel1.TabIndex = 0
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(838, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(891, 9)
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
        Me.lbl_title.Size = New System.Drawing.Size(193, 31)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Rekap Penjualan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 250
        Me.Label2.Text = "Tgl Rekap"
        '
        'date_tgl_trans
        '
        Me.date_tgl_trans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_trans.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_tgl_trans.Location = New System.Drawing.Point(63, 32)
        Me.date_tgl_trans.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_trans.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_trans.Name = "date_tgl_trans"
        Me.date_tgl_trans.Size = New System.Drawing.Size(132, 20)
        Me.date_tgl_trans.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(344, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 252
        Me.Label3.Text = "s.d."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(233, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 253
        Me.Label1.Text = "Tgl Faktur"
        '
        'date_faktur_akhir
        '
        Me.date_faktur_akhir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_faktur_akhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_faktur_akhir.Location = New System.Drawing.Point(368, 26)
        Me.date_faktur_akhir.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_faktur_akhir.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_faktur_akhir.Name = "date_faktur_akhir"
        Me.date_faktur_akhir.Size = New System.Drawing.Size(104, 20)
        Me.date_faktur_akhir.TabIndex = 2
        '
        'date_faktur_awal
        '
        Me.date_faktur_awal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_faktur_awal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_faktur_awal.Location = New System.Drawing.Point(236, 26)
        Me.date_faktur_awal.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_faktur_awal.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_faktur_awal.Name = "date_faktur_awal"
        Me.date_faktur_awal.Size = New System.Drawing.Size(104, 20)
        Me.date_faktur_awal.TabIndex = 1
        '
        'ck_tgl2
        '
        Me.ck_tgl2.AutoSize = True
        Me.ck_tgl2.Location = New System.Drawing.Point(236, 52)
        Me.ck_tgl2.Name = "ck_tgl2"
        Me.ck_tgl2.Size = New System.Drawing.Size(95, 17)
        Me.ck_tgl2.TabIndex = 3
        Me.ck_tgl2.Text = "Filter tgl Faktur"
        Me.ck_tgl2.UseVisualStyleBackColor = True
        '
        'bt_cari_sales
        '
        Me.bt_cari_sales.Location = New System.Drawing.Point(267, 83)
        Me.bt_cari_sales.Name = "bt_cari_sales"
        Me.bt_cari_sales.Size = New System.Drawing.Size(38, 20)
        Me.bt_cari_sales.TabIndex = 5
        Me.bt_cari_sales.Text = "Cari"
        Me.bt_cari_sales.UseVisualStyleBackColor = True
        '
        'in_cari_sales
        '
        Me.in_cari_sales.BackColor = System.Drawing.Color.White
        Me.in_cari_sales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari_sales.ForeColor = System.Drawing.Color.Black
        Me.in_cari_sales.Location = New System.Drawing.Point(73, 83)
        Me.in_cari_sales.MaxLength = 30
        Me.in_cari_sales.Name = "in_cari_sales"
        Me.in_cari_sales.Size = New System.Drawing.Size(188, 20)
        Me.in_cari_sales.TabIndex = 4
        Me.in_cari_sales.TabStop = False
        '
        'dgv_sales
        '
        Me.dgv_sales.AllowUserToAddRows = False
        Me.dgv_sales.AllowUserToDeleteRows = False
        Me.dgv_sales.BackgroundColor = System.Drawing.Color.White
        Me.dgv_sales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_sales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sales_kode, Me.sales_nama})
        Me.dgv_sales.Location = New System.Drawing.Point(12, 109)
        Me.dgv_sales.Name = "dgv_sales"
        Me.dgv_sales.ReadOnly = True
        Me.dgv_sales.RowHeadersVisible = False
        Me.dgv_sales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_sales.Size = New System.Drawing.Size(309, 143)
        Me.dgv_sales.TabIndex = 6
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
        'dgv_draft_list
        '
        Me.dgv_draft_list.AllowUserToAddRows = False
        Me.dgv_draft_list.AllowUserToDeleteRows = False
        Me.dgv_draft_list.BackgroundColor = System.Drawing.Color.White
        Me.dgv_draft_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_draft_list.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.draftlist_kode, Me.draftlist_tgl, Me.draftlist_sales, Me.draftlist_countnota, Me.draftlist_countitem, Me.draftlist_gudang})
        Me.dgv_draft_list.Location = New System.Drawing.Point(12, 584)
        Me.dgv_draft_list.Name = "dgv_draft_list"
        Me.dgv_draft_list.ReadOnly = True
        Me.dgv_draft_list.RowHeadersVisible = False
        Me.dgv_draft_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_draft_list.Size = New System.Drawing.Size(874, 192)
        Me.dgv_draft_list.TabIndex = 22
        '
        'dgv_draftfaktur
        '
        Me.dgv_draftfaktur.AllowUserToAddRows = False
        Me.dgv_draftfaktur.AllowUserToDeleteRows = False
        Me.dgv_draftfaktur.BackgroundColor = System.Drawing.Color.White
        Me.dgv_draftfaktur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_draftfaktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.draft_custo, Me.draft_faktur, Me.draft_netto, Me.draft_sales})
        Me.dgv_draftfaktur.Location = New System.Drawing.Point(564, 288)
        Me.dgv_draftfaktur.Name = "dgv_draftfaktur"
        Me.dgv_draftfaktur.ReadOnly = True
        Me.dgv_draftfaktur.RowHeadersVisible = False
        Me.dgv_draftfaktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_draftfaktur.Size = New System.Drawing.Size(322, 174)
        Me.dgv_draftfaktur.TabIndex = 15
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
        'draft_sales
        '
        Me.draft_sales.DataPropertyName = "salesman_nama"
        Me.draft_sales.HeaderText = "Salesman"
        Me.draft_sales.Name = "draft_sales"
        Me.draft_sales.ReadOnly = True
        '
        'in_cari_faktur
        '
        Me.in_cari_faktur.BackColor = System.Drawing.Color.White
        Me.in_cari_faktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari_faktur.ForeColor = System.Drawing.Color.Black
        Me.in_cari_faktur.Location = New System.Drawing.Point(73, 262)
        Me.in_cari_faktur.MaxLength = 30
        Me.in_cari_faktur.Name = "in_cari_faktur"
        Me.in_cari_faktur.Size = New System.Drawing.Size(188, 20)
        Me.in_cari_faktur.TabIndex = 10
        Me.in_cari_faktur.TabStop = False
        '
        'bt_cari_faktur
        '
        Me.bt_cari_faktur.Location = New System.Drawing.Point(267, 262)
        Me.bt_cari_faktur.Name = "bt_cari_faktur"
        Me.bt_cari_faktur.Size = New System.Drawing.Size(38, 20)
        Me.bt_cari_faktur.TabIndex = 11
        Me.bt_cari_faktur.Text = "Cari"
        Me.bt_cari_faktur.UseVisualStyleBackColor = True
        '
        'bt_draft_barang
        '
        Me.bt_draft_barang.Location = New System.Drawing.Point(632, 501)
        Me.bt_draft_barang.Name = "bt_draft_barang"
        Me.bt_draft_barang.Size = New System.Drawing.Size(124, 27)
        Me.bt_draft_barang.TabIndex = 17
        Me.bt_draft_barang.Text = "Cetak Draft Barang"
        Me.bt_draft_barang.UseVisualStyleBackColor = True
        '
        'bt_draft_nota
        '
        Me.bt_draft_nota.Location = New System.Drawing.Point(762, 501)
        Me.bt_draft_nota.Name = "bt_draft_nota"
        Me.bt_draft_nota.Size = New System.Drawing.Size(124, 27)
        Me.bt_draft_nota.TabIndex = 18
        Me.bt_draft_nota.Text = "Cetak Draft Nota"
        Me.bt_draft_nota.UseVisualStyleBackColor = True
        '
        'bt_addfaktur
        '
        Me.bt_addfaktur.Location = New System.Drawing.Point(533, 288)
        Me.bt_addfaktur.Name = "bt_addfaktur"
        Me.bt_addfaktur.Size = New System.Drawing.Size(27, 85)
        Me.bt_addfaktur.TabIndex = 13
        Me.bt_addfaktur.Text = ">>"
        Me.bt_addfaktur.UseVisualStyleBackColor = True
        '
        'dgv_listfaktur
        '
        Me.dgv_listfaktur.AllowUserToAddRows = False
        Me.dgv_listfaktur.AllowUserToDeleteRows = False
        Me.dgv_listfaktur.BackgroundColor = System.Drawing.Color.White
        Me.dgv_listfaktur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listfaktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.list_faktur, Me.list_tanggal, Me.list_custo, Me.list_netto, Me.list_draft, Me.sales})
        Me.dgv_listfaktur.Location = New System.Drawing.Point(12, 288)
        Me.dgv_listfaktur.Name = "dgv_listfaktur"
        Me.dgv_listfaktur.ReadOnly = True
        Me.dgv_listfaktur.RowHeadersVisible = False
        Me.dgv_listfaktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listfaktur.Size = New System.Drawing.Size(516, 174)
        Me.dgv_listfaktur.TabIndex = 12
        '
        'list_faktur
        '
        Me.list_faktur.DataPropertyName = "kode"
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
        Me.list_custo.DataPropertyName = "nama"
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
        Me.list_draft.DataPropertyName = "faktur_draft_rekap"
        Me.list_draft.HeaderText = "Draft"
        Me.list_draft.Name = "list_draft"
        Me.list_draft.ReadOnly = True
        Me.list_draft.Width = 50
        '
        'sales
        '
        Me.sales.DataPropertyName = "salesman_nama"
        Me.sales.HeaderText = "Sales"
        Me.sales.Name = "sales"
        Me.sales.ReadOnly = True
        Me.sales.Width = 150
        '
        'bt_loaddraft
        '
        Me.bt_loaddraft.Location = New System.Drawing.Point(759, 559)
        Me.bt_loaddraft.Name = "bt_loaddraft"
        Me.bt_loaddraft.Size = New System.Drawing.Size(126, 23)
        Me.bt_loaddraft.TabIndex = 21
        Me.bt_loaddraft.Text = "Load Draft"
        Me.bt_loaddraft.UseVisualStyleBackColor = True
        '
        'mn_refresh
        '
        Me.mn_refresh.Name = "mn_refresh"
        Me.mn_refresh.Size = New System.Drawing.Size(58, 20)
        Me.mn_refresh.Text = "Refresh"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_tambah, Me.mn_edit, Me.mn_print, Me.mn_refresh})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 42)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(918, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mn_tambah
        '
        Me.mn_tambah.Image = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.mn_tambah.Name = "mn_tambah"
        Me.mn_tambah.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.mn_tambah.Size = New System.Drawing.Size(88, 20)
        Me.mn_tambah.Text = "Draft Baru"
        '
        'mn_edit
        '
        Me.mn_edit.Image = Global.Inventory.My.Resources.Resources.toolbar_list_icon1
        Me.mn_edit.Name = "mn_edit"
        Me.mn_edit.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.mn_edit.Size = New System.Drawing.Size(115, 20)
        Me.mn_edit.Text = "Edit/Load Draft"
        '
        'mn_print
        '
        Me.mn_print.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DraftBarangToolStripMenuItem, Me.DraftNotaToolStripMenuItem})
        Me.mn_print.Image = CType(resources.GetObject("mn_print.Image"), System.Drawing.Image)
        Me.mn_print.Name = "mn_print"
        Me.mn_print.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.mn_print.Size = New System.Drawing.Size(60, 20)
        Me.mn_print.Text = "Print"
        Me.mn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DraftBarangToolStripMenuItem
        '
        Me.DraftBarangToolStripMenuItem.Name = "DraftBarangToolStripMenuItem"
        Me.DraftBarangToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.DraftBarangToolStripMenuItem.Text = "Draft Barang"
        '
        'DraftNotaToolStripMenuItem
        '
        Me.DraftNotaToolStripMenuItem.Name = "DraftNotaToolStripMenuItem"
        Me.DraftNotaToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.DraftNotaToolStripMenuItem.Text = "Draft Nota"
        '
        'bt_addsales
        '
        Me.bt_addsales.Location = New System.Drawing.Point(326, 114)
        Me.bt_addsales.Name = "bt_addsales"
        Me.bt_addsales.Size = New System.Drawing.Size(27, 36)
        Me.bt_addsales.TabIndex = 7
        Me.bt_addsales.Text = "+"
        Me.bt_addsales.UseVisualStyleBackColor = True
        '
        'bt_remsales
        '
        Me.bt_remsales.Location = New System.Drawing.Point(326, 151)
        Me.bt_remsales.Name = "bt_remsales"
        Me.bt_remsales.Size = New System.Drawing.Size(27, 36)
        Me.bt_remsales.TabIndex = 8
        Me.bt_remsales.Text = "-"
        Me.bt_remsales.UseVisualStyleBackColor = True
        '
        'bt_remfaktur
        '
        Me.bt_remfaktur.Location = New System.Drawing.Point(533, 377)
        Me.bt_remfaktur.Name = "bt_remfaktur"
        Me.bt_remfaktur.Size = New System.Drawing.Size(27, 85)
        Me.bt_remfaktur.TabIndex = 14
        Me.bt_remfaktur.Text = "<<"
        Me.bt_remfaktur.UseVisualStyleBackColor = True
        '
        'dgv_draftsales
        '
        Me.dgv_draftsales.AllowUserToAddRows = False
        Me.dgv_draftsales.AllowUserToDeleteRows = False
        Me.dgv_draftsales.BackgroundColor = System.Drawing.Color.White
        Me.dgv_draftsales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_draftsales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.draft_sales_kode, Me.draft_sales_n})
        Me.dgv_draftsales.Location = New System.Drawing.Point(359, 109)
        Me.dgv_draftsales.Name = "dgv_draftsales"
        Me.dgv_draftsales.ReadOnly = True
        Me.dgv_draftsales.RowHeadersVisible = False
        Me.dgv_draftsales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_draftsales.Size = New System.Drawing.Size(303, 143)
        Me.dgv_draftsales.TabIndex = 9
        '
        'draft_sales_kode
        '
        Me.draft_sales_kode.DataPropertyName = "kode"
        Me.draft_sales_kode.HeaderText = "Kode"
        Me.draft_sales_kode.Name = "draft_sales_kode"
        Me.draft_sales_kode.ReadOnly = True
        '
        'draft_sales_n
        '
        Me.draft_sales_n.DataPropertyName = "nama"
        Me.draft_sales_n.HeaderText = "Nama"
        Me.draft_sales_n.MinimumWidth = 190
        Me.draft_sales_n.Name = "draft_sales_n"
        Me.draft_sales_n.ReadOnly = True
        Me.draft_sales_n.Width = 190
        '
        'in_kode_draft
        '
        Me.in_kode_draft.BackColor = System.Drawing.Color.White
        Me.in_kode_draft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode_draft.ForeColor = System.Drawing.Color.Black
        Me.in_kode_draft.Location = New System.Drawing.Point(63, 6)
        Me.in_kode_draft.MaxLength = 30
        Me.in_kode_draft.Name = "in_kode_draft"
        Me.in_kode_draft.ReadOnly = True
        Me.in_kode_draft.Size = New System.Drawing.Size(132, 20)
        Me.in_kode_draft.TabIndex = 0
        Me.in_kode_draft.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 250
        Me.Label7.Text = "No.Rekap"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.in_kode_draft)
        Me.Panel2.Controls.Add(Me.date_tgl_trans)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(12, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(208, 62)
        Me.Panel2.TabIndex = 0
        '
        'bt_caridraft
        '
        Me.bt_caridraft.Location = New System.Drawing.Point(206, 559)
        Me.bt_caridraft.Name = "bt_caridraft"
        Me.bt_caridraft.Size = New System.Drawing.Size(38, 20)
        Me.bt_caridraft.TabIndex = 20
        Me.bt_caridraft.Text = "Cari"
        Me.bt_caridraft.UseVisualStyleBackColor = True
        '
        'in_caridraft
        '
        Me.in_caridraft.BackColor = System.Drawing.Color.White
        Me.in_caridraft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_caridraft.ForeColor = System.Drawing.Color.Black
        Me.in_caridraft.Location = New System.Drawing.Point(12, 559)
        Me.in_caridraft.MaxLength = 30
        Me.in_caridraft.Name = "in_caridraft"
        Me.in_caridraft.Size = New System.Drawing.Size(188, 20)
        Me.in_caridraft.TabIndex = 19
        Me.in_caridraft.TabStop = False
        '
        'bt_create_draft
        '
        Me.bt_create_draft.Location = New System.Drawing.Point(632, 468)
        Me.bt_create_draft.Name = "bt_create_draft"
        Me.bt_create_draft.Size = New System.Drawing.Size(254, 27)
        Me.bt_create_draft.TabIndex = 16
        Me.bt_create_draft.Text = "Simpan Draft"
        Me.bt_create_draft.UseVisualStyleBackColor = True
        '
        'pnl_content
        '
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.Controls.Add(Me.Label15)
        Me.pnl_content.Controls.Add(Me.Label13)
        Me.pnl_content.Controls.Add(Me.Label8)
        Me.pnl_content.Controls.Add(Me.bt_remfaktur)
        Me.pnl_content.Controls.Add(Me.Panel2)
        Me.pnl_content.Controls.Add(Me.bt_caridraft)
        Me.pnl_content.Controls.Add(Me.bt_create_draft)
        Me.pnl_content.Controls.Add(Me.dgv_draft_list)
        Me.pnl_content.Controls.Add(Me.date_faktur_awal)
        Me.pnl_content.Controls.Add(Me.bt_remsales)
        Me.pnl_content.Controls.Add(Me.date_faktur_akhir)
        Me.pnl_content.Controls.Add(Me.bt_addsales)
        Me.pnl_content.Controls.Add(Me.Label1)
        Me.pnl_content.Controls.Add(Me.dgv_draftfaktur)
        Me.pnl_content.Controls.Add(Me.Label3)
        Me.pnl_content.Controls.Add(Me.ck_tgl2)
        Me.pnl_content.Controls.Add(Me.in_caridraft)
        Me.pnl_content.Controls.Add(Me.dgv_sales)
        Me.pnl_content.Controls.Add(Me.dgv_draftsales)
        Me.pnl_content.Controls.Add(Me.in_cari_faktur)
        Me.pnl_content.Controls.Add(Me.bt_cari_faktur)
        Me.pnl_content.Controls.Add(Me.in_cari_sales)
        Me.pnl_content.Controls.Add(Me.bt_draft_barang)
        Me.pnl_content.Controls.Add(Me.bt_cari_sales)
        Me.pnl_content.Controls.Add(Me.bt_draft_nota)
        Me.pnl_content.Controls.Add(Me.bt_loaddraft)
        Me.pnl_content.Controls.Add(Me.bt_addfaktur)
        Me.pnl_content.Controls.Add(Me.dgv_listfaktur)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Location = New System.Drawing.Point(0, 66)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(918, 509)
        Me.pnl_content.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label13.Location = New System.Drawing.Point(6, 265)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 373
        Me.Label13.Text = "Faktur"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(6, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 372
        Me.Label8.Text = "Salesman"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label15.Location = New System.Drawing.Point(6, 543)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 13)
        Me.Label15.TabIndex = 374
        Me.Label15.Text = "List Rekap"
        '
        'draftlist_kode
        '
        Me.draftlist_kode.DataPropertyName = "draft_kode"
        Me.draftlist_kode.HeaderText = "Kode Rekap"
        Me.draftlist_kode.MinimumWidth = 100
        Me.draftlist_kode.Name = "draftlist_kode"
        Me.draftlist_kode.ReadOnly = True
        Me.draftlist_kode.Width = 125
        '
        'draftlist_tgl
        '
        Me.draftlist_tgl.DataPropertyName = "draft_tanggal"
        Me.draftlist_tgl.HeaderText = "Tgl.Rekap"
        Me.draftlist_tgl.MinimumWidth = 50
        Me.draftlist_tgl.Name = "draftlist_tgl"
        Me.draftlist_tgl.ReadOnly = True
        '
        'draftlist_sales
        '
        Me.draftlist_sales.DataPropertyName = "draft_sales"
        Me.draftlist_sales.HeaderText = "Salesman"
        Me.draftlist_sales.MinimumWidth = 100
        Me.draftlist_sales.Name = "draftlist_sales"
        Me.draftlist_sales.ReadOnly = True
        Me.draftlist_sales.Width = 225
        '
        'draftlist_countnota
        '
        Me.draftlist_countnota.DataPropertyName = "draft_ctnota"
        Me.draftlist_countnota.HeaderText = "Jml.Nota"
        Me.draftlist_countnota.Name = "draftlist_countnota"
        Me.draftlist_countnota.ReadOnly = True
        Me.draftlist_countnota.Width = 75
        '
        'draftlist_countitem
        '
        Me.draftlist_countitem.DataPropertyName = "draft_ctitem"
        Me.draftlist_countitem.HeaderText = "Jml.Item"
        Me.draftlist_countitem.Name = "draftlist_countitem"
        Me.draftlist_countitem.ReadOnly = True
        Me.draftlist_countitem.Width = 75
        '
        'draftlist_gudang
        '
        Me.draftlist_gudang.DataPropertyName = "draft_gudang"
        Me.draftlist_gudang.HeaderText = "Gudang"
        Me.draftlist_gudang.Name = "draftlist_gudang"
        Me.draftlist_gudang.ReadOnly = True
        Me.draftlist_gudang.Width = 175
        '
        'fr_draft_rekap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "fr_draft_rekap"
        Me.Size = New System.Drawing.Size(918, 575)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv_sales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_draft_list, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_draftfaktur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_listfaktur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgv_draftsales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents date_tgl_trans As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents date_faktur_akhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_faktur_awal As System.Windows.Forms.DateTimePicker
    Friend WithEvents ck_tgl2 As System.Windows.Forms.CheckBox
    Friend WithEvents bt_cari_sales As System.Windows.Forms.Button
    Friend WithEvents in_cari_sales As System.Windows.Forms.TextBox
    Friend WithEvents dgv_sales As System.Windows.Forms.DataGridView
    Friend WithEvents sales_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgv_draft_list As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_draftfaktur As System.Windows.Forms.DataGridView
    Friend WithEvents in_cari_faktur As System.Windows.Forms.TextBox
    Friend WithEvents bt_cari_faktur As System.Windows.Forms.Button
    Friend WithEvents bt_draft_barang As System.Windows.Forms.Button
    Friend WithEvents bt_draft_nota As System.Windows.Forms.Button
    Friend WithEvents bt_addfaktur As System.Windows.Forms.Button
    Friend WithEvents dgv_listfaktur As System.Windows.Forms.DataGridView
    Friend WithEvents bt_loaddraft As System.Windows.Forms.Button
    Friend WithEvents mn_tambah As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DraftBarangToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DraftNotaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_refresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents bt_addsales As System.Windows.Forms.Button
    Friend WithEvents bt_remsales As System.Windows.Forms.Button
    Friend WithEvents bt_remfaktur As System.Windows.Forms.Button
    Friend WithEvents dgv_draftsales As System.Windows.Forms.DataGridView
    Friend WithEvents in_kode_draft As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents bt_caridraft As System.Windows.Forms.Button
    Friend WithEvents in_caridraft As System.Windows.Forms.TextBox
    Friend WithEvents bt_create_draft As System.Windows.Forms.Button
    Friend WithEvents draft_sales_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_sales_n As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_netto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_tanggal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_netto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_draft As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents draftlist_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draftlist_tgl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draftlist_sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draftlist_countnota As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draftlist_countitem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draftlist_gudang As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
