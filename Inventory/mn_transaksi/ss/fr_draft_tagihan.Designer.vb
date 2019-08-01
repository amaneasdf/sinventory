<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_draft_tagihan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_draft_tagihan))
        Me.bt_create_draft = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.in_kode_draft = New System.Windows.Forms.TextBox()
        Me.date_tgl_trans = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.bt_remsales = New System.Windows.Forms.Button()
        Me.bt_addsales = New System.Windows.Forms.Button()
        Me.dgv_draftfaktur = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.in_caridraft = New System.Windows.Forms.TextBox()
        Me.bt_caridraft = New System.Windows.Forms.Button()
        Me.in_cari_faktur = New System.Windows.Forms.TextBox()
        Me.bt_cari_faktur = New System.Windows.Forms.Button()
        Me.bt_draft_nota = New System.Windows.Forms.Button()
        Me.bt_remfaktur = New System.Windows.Forms.Button()
        Me.bt_addfaktur = New System.Windows.Forms.Button()
        Me.dgv_listfaktur = New System.Windows.Forms.DataGridView()
        Me.list_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_tanggal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_custo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_sisa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_temp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_pasar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_kec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_kab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv_draft_list = New System.Windows.Forms.DataGridView()
        Me.bt_loaddraft = New System.Windows.Forms.Button()
        Me.bt_cari_sales = New System.Windows.Forms.Button()
        Me.in_cari_sales = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgv_sales = New System.Windows.Forms.DataGridView()
        Me.sales_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sales_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.date_faktur_akhir = New System.Windows.Forms.DateTimePicker()
        Me.date_faktur_awal = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_tambah = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_print = New System.Windows.Forms.ToolStripMenuItem()
        Me.DraftBarangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_refresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelPrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.ck_tgl2 = New System.Windows.Forms.CheckBox()
        Me.ck_tgl1 = New System.Windows.Forms.CheckBox()
        Me.in_sales = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.in_sales_n = New System.Windows.Forms.TextBox()
        Me.lbl_statprint = New System.Windows.Forms.Label()
        Me.in_kecamatan = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.in_kabupaten = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.in_pasar = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.dgv_detail_tagihan = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draftlist_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draftlist_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draftlist_sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_status_print = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_custo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_sisa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_tglcicil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_countcicil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2.SuspendLayout()
        CType(Me.dgv_draftfaktur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_listfaktur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_draft_list, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_sales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnl_content.SuspendLayout()
        CType(Me.dgv_detail_tagihan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bt_create_draft
        '
        Me.bt_create_draft.Location = New System.Drawing.Point(563, 252)
        Me.bt_create_draft.Name = "bt_create_draft"
        Me.bt_create_draft.Size = New System.Drawing.Size(151, 27)
        Me.bt_create_draft.TabIndex = 22
        Me.bt_create_draft.Text = "Simpan Draft"
        Me.bt_create_draft.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.in_kode_draft)
        Me.Panel2.Controls.Add(Me.date_tgl_trans)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(5, 9)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(208, 62)
        Me.Panel2.TabIndex = 0
        '
        'in_kode_draft
        '
        Me.in_kode_draft.BackColor = System.Drawing.Color.White
        Me.in_kode_draft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode_draft.ForeColor = System.Drawing.Color.Black
        Me.in_kode_draft.Location = New System.Drawing.Point(71, 6)
        Me.in_kode_draft.MaxLength = 30
        Me.in_kode_draft.Name = "in_kode_draft"
        Me.in_kode_draft.ReadOnly = True
        Me.in_kode_draft.Size = New System.Drawing.Size(132, 20)
        Me.in_kode_draft.TabIndex = 0
        Me.in_kode_draft.TabStop = False
        '
        'date_tgl_trans
        '
        Me.date_tgl_trans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_trans.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_tgl_trans.Location = New System.Drawing.Point(71, 32)
        Me.date_tgl_trans.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_trans.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_trans.Name = "date_tgl_trans"
        Me.date_tgl_trans.Size = New System.Drawing.Size(132, 20)
        Me.date_tgl_trans.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 250
        Me.Label2.Text = "Tgl Tagihan"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 250
        Me.Label7.Text = "No.Tagihan"
        '
        'bt_remsales
        '
        Me.bt_remsales.Location = New System.Drawing.Point(320, 156)
        Me.bt_remsales.Name = "bt_remsales"
        Me.bt_remsales.Size = New System.Drawing.Size(27, 36)
        Me.bt_remsales.TabIndex = 9
        Me.bt_remsales.Text = "-"
        Me.bt_remsales.UseVisualStyleBackColor = True
        '
        'bt_addsales
        '
        Me.bt_addsales.Location = New System.Drawing.Point(320, 119)
        Me.bt_addsales.Name = "bt_addsales"
        Me.bt_addsales.Size = New System.Drawing.Size(27, 36)
        Me.bt_addsales.TabIndex = 8
        Me.bt_addsales.Text = "+"
        Me.bt_addsales.UseVisualStyleBackColor = True
        '
        'dgv_draftfaktur
        '
        Me.dgv_draftfaktur.AllowUserToAddRows = False
        Me.dgv_draftfaktur.AllowUserToDeleteRows = False
        Me.dgv_draftfaktur.BackgroundColor = System.Drawing.Color.White
        Me.dgv_draftfaktur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgv_draftfaktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.draft_custo, Me.draft_faktur, Me.draft_sisa, Me.draft_sales, Me.draft_tglcicil, Me.draft_countcicil})
        Me.dgv_draftfaktur.Location = New System.Drawing.Point(563, 282)
        Me.dgv_draftfaktur.Name = "dgv_draftfaktur"
        Me.dgv_draftfaktur.ReadOnly = True
        Me.dgv_draftfaktur.RowHeadersVisible = False
        Me.dgv_draftfaktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_draftfaktur.Size = New System.Drawing.Size(321, 194)
        Me.dgv_draftfaktur.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(260, 263)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 315
        Me.Label4.Text = "Faktur"
        '
        'in_caridraft
        '
        Me.in_caridraft.BackColor = System.Drawing.Color.White
        Me.in_caridraft.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_caridraft.ForeColor = System.Drawing.Color.Black
        Me.in_caridraft.Location = New System.Drawing.Point(890, 26)
        Me.in_caridraft.MaxLength = 30
        Me.in_caridraft.Name = "in_caridraft"
        Me.in_caridraft.Size = New System.Drawing.Size(188, 20)
        Me.in_caridraft.TabIndex = 24
        Me.in_caridraft.TabStop = False
        '
        'bt_caridraft
        '
        Me.bt_caridraft.Location = New System.Drawing.Point(1084, 26)
        Me.bt_caridraft.Name = "bt_caridraft"
        Me.bt_caridraft.Size = New System.Drawing.Size(42, 20)
        Me.bt_caridraft.TabIndex = 25
        Me.bt_caridraft.Text = "Cari"
        Me.bt_caridraft.UseVisualStyleBackColor = True
        '
        'in_cari_faktur
        '
        Me.in_cari_faktur.BackColor = System.Drawing.Color.White
        Me.in_cari_faktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari_faktur.ForeColor = System.Drawing.Color.Black
        Me.in_cari_faktur.Location = New System.Drawing.Point(300, 259)
        Me.in_cari_faktur.MaxLength = 30
        Me.in_cari_faktur.Name = "in_cari_faktur"
        Me.in_cari_faktur.Size = New System.Drawing.Size(175, 20)
        Me.in_cari_faktur.TabIndex = 15
        Me.in_cari_faktur.TabStop = False
        '
        'bt_cari_faktur
        '
        Me.bt_cari_faktur.Location = New System.Drawing.Point(487, 236)
        Me.bt_cari_faktur.Name = "bt_cari_faktur"
        Me.bt_cari_faktur.Size = New System.Drawing.Size(38, 43)
        Me.bt_cari_faktur.TabIndex = 16
        Me.bt_cari_faktur.Text = "Cari"
        Me.bt_cari_faktur.UseVisualStyleBackColor = True
        '
        'bt_draft_nota
        '
        Me.bt_draft_nota.Location = New System.Drawing.Point(720, 252)
        Me.bt_draft_nota.Name = "bt_draft_nota"
        Me.bt_draft_nota.Size = New System.Drawing.Size(164, 27)
        Me.bt_draft_nota.TabIndex = 23
        Me.bt_draft_nota.Text = "Cetak Draft Tagihan"
        Me.bt_draft_nota.UseVisualStyleBackColor = True
        '
        'bt_remfaktur
        '
        Me.bt_remfaktur.Location = New System.Drawing.Point(530, 383)
        Me.bt_remfaktur.Name = "bt_remfaktur"
        Me.bt_remfaktur.Size = New System.Drawing.Size(27, 85)
        Me.bt_remfaktur.TabIndex = 19
        Me.bt_remfaktur.Text = "<<"
        Me.bt_remfaktur.UseVisualStyleBackColor = True
        '
        'bt_addfaktur
        '
        Me.bt_addfaktur.Location = New System.Drawing.Point(530, 294)
        Me.bt_addfaktur.Name = "bt_addfaktur"
        Me.bt_addfaktur.Size = New System.Drawing.Size(27, 85)
        Me.bt_addfaktur.TabIndex = 18
        Me.bt_addfaktur.Text = ">>"
        Me.bt_addfaktur.UseVisualStyleBackColor = True
        '
        'dgv_listfaktur
        '
        Me.dgv_listfaktur.AllowUserToAddRows = False
        Me.dgv_listfaktur.AllowUserToDeleteRows = False
        Me.dgv_listfaktur.BackgroundColor = System.Drawing.Color.White
        Me.dgv_listfaktur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listfaktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.list_faktur, Me.list_tanggal, Me.list_custo, Me.list_sisa, Me.list_temp, Me.list_pasar, Me.list_kec, Me.list_kab, Me.list_sales})
        Me.dgv_listfaktur.Location = New System.Drawing.Point(6, 282)
        Me.dgv_listfaktur.Name = "dgv_listfaktur"
        Me.dgv_listfaktur.ReadOnly = True
        Me.dgv_listfaktur.RowHeadersVisible = False
        Me.dgv_listfaktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listfaktur.Size = New System.Drawing.Size(519, 194)
        Me.dgv_listfaktur.TabIndex = 17
        '
        'list_faktur
        '
        Me.list_faktur.DataPropertyName = "piutang_faktur"
        Me.list_faktur.HeaderText = "No.Faktur"
        Me.list_faktur.Name = "list_faktur"
        Me.list_faktur.ReadOnly = True
        Me.list_faktur.Width = 90
        '
        'list_tanggal
        '
        Me.list_tanggal.DataPropertyName = "piutang_tgl"
        Me.list_tanggal.HeaderText = "Tanggal"
        Me.list_tanggal.MinimumWidth = 90
        Me.list_tanggal.Name = "list_tanggal"
        Me.list_tanggal.ReadOnly = True
        Me.list_tanggal.Width = 90
        '
        'list_custo
        '
        Me.list_custo.DataPropertyName = "piutang_custo_n"
        Me.list_custo.HeaderText = "Customer"
        Me.list_custo.MinimumWidth = 160
        Me.list_custo.Name = "list_custo"
        Me.list_custo.ReadOnly = True
        Me.list_custo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.list_custo.Width = 160
        '
        'list_sisa
        '
        Me.list_sisa.DataPropertyName = "piutang_sisa"
        Me.list_sisa.HeaderText = "Sisa"
        Me.list_sisa.MinimumWidth = 95
        Me.list_sisa.Name = "list_sisa"
        Me.list_sisa.ReadOnly = True
        Me.list_sisa.Width = 95
        '
        'list_temp
        '
        Me.list_temp.DataPropertyName = "piutang_jt"
        Me.list_temp.HeaderText = "Tgl.Jt.Tempo"
        Me.list_temp.Name = "list_temp"
        Me.list_temp.ReadOnly = True
        '
        'list_pasar
        '
        Me.list_pasar.DataPropertyName = "customer_pasar"
        Me.list_pasar.HeaderText = "Pasar"
        Me.list_pasar.Name = "list_pasar"
        Me.list_pasar.ReadOnly = True
        '
        'list_kec
        '
        Me.list_kec.DataPropertyName = "customer_kecamatan"
        Me.list_kec.HeaderText = "Kecamatan"
        Me.list_kec.Name = "list_kec"
        Me.list_kec.ReadOnly = True
        '
        'list_kab
        '
        Me.list_kab.DataPropertyName = "customer_kabupaten"
        Me.list_kab.HeaderText = "Kabupaten"
        Me.list_kab.Name = "list_kab"
        Me.list_kab.ReadOnly = True
        '
        'list_sales
        '
        Me.list_sales.DataPropertyName = "salesman_nama"
        Me.list_sales.HeaderText = "Salesman"
        Me.list_sales.Name = "list_sales"
        Me.list_sales.ReadOnly = True
        Me.list_sales.Width = 125
        '
        'dgv_draft_list
        '
        Me.dgv_draft_list.AllowUserToAddRows = False
        Me.dgv_draft_list.AllowUserToDeleteRows = False
        Me.dgv_draft_list.BackgroundColor = System.Drawing.Color.White
        Me.dgv_draft_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_draft_list.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.draftlist_kode, Me.draftlist_tgl, Me.draftlist_sales, Me.draft_status_print})
        Me.dgv_draft_list.Location = New System.Drawing.Point(890, 50)
        Me.dgv_draft_list.Name = "dgv_draft_list"
        Me.dgv_draft_list.ReadOnly = True
        Me.dgv_draft_list.RowHeadersVisible = False
        Me.dgv_draft_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_draft_list.Size = New System.Drawing.Size(432, 606)
        Me.dgv_draft_list.TabIndex = 27
        '
        'bt_loaddraft
        '
        Me.bt_loaddraft.Location = New System.Drawing.Point(1196, 25)
        Me.bt_loaddraft.Name = "bt_loaddraft"
        Me.bt_loaddraft.Size = New System.Drawing.Size(126, 23)
        Me.bt_loaddraft.TabIndex = 26
        Me.bt_loaddraft.Text = "Load Draft"
        Me.bt_loaddraft.UseVisualStyleBackColor = True
        '
        'bt_cari_sales
        '
        Me.bt_cari_sales.Location = New System.Drawing.Point(264, 77)
        Me.bt_cari_sales.Name = "bt_cari_sales"
        Me.bt_cari_sales.Size = New System.Drawing.Size(38, 20)
        Me.bt_cari_sales.TabIndex = 6
        Me.bt_cari_sales.Text = "Cari"
        Me.bt_cari_sales.UseVisualStyleBackColor = True
        '
        'in_cari_sales
        '
        Me.in_cari_sales.BackColor = System.Drawing.Color.White
        Me.in_cari_sales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari_sales.ForeColor = System.Drawing.Color.Black
        Me.in_cari_sales.Location = New System.Drawing.Point(70, 77)
        Me.in_cari_sales.MaxLength = 30
        Me.in_cari_sales.Name = "in_cari_sales"
        Me.in_cari_sales.Size = New System.Drawing.Size(188, 20)
        Me.in_cari_sales.TabIndex = 5
        Me.in_cari_sales.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 304
        Me.Label5.Text = "Sales"
        '
        'dgv_sales
        '
        Me.dgv_sales.AllowUserToAddRows = False
        Me.dgv_sales.AllowUserToDeleteRows = False
        Me.dgv_sales.BackgroundColor = System.Drawing.Color.White
        Me.dgv_sales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_sales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sales_kode, Me.sales_nama})
        Me.dgv_sales.Location = New System.Drawing.Point(5, 103)
        Me.dgv_sales.MultiSelect = False
        Me.dgv_sales.Name = "dgv_sales"
        Me.dgv_sales.ReadOnly = True
        Me.dgv_sales.RowHeadersVisible = False
        Me.dgv_sales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_sales.Size = New System.Drawing.Size(309, 127)
        Me.dgv_sales.TabIndex = 7
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(337, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 294
        Me.Label3.Text = "s.d."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(226, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 295
        Me.Label1.Text = "Tgl Jatuh Tempo"
        '
        'date_faktur_akhir
        '
        Me.date_faktur_akhir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_faktur_akhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_faktur_akhir.Location = New System.Drawing.Point(361, 25)
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
        Me.date_faktur_awal.Location = New System.Drawing.Point(229, 25)
        Me.date_faktur_awal.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_faktur_awal.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_faktur_awal.Name = "date_faktur_awal"
        Me.date_faktur_awal.Size = New System.Drawing.Size(104, 20)
        Me.date_faktur_awal.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(885, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 293
        Me.Label6.Text = "List Rekap :"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_tambah, Me.mn_edit, Me.mn_print, Me.mn_refresh, Me.CancelPrintToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 42)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(918, 24)
        Me.MenuStrip1.TabIndex = 291
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
        Me.mn_edit.Size = New System.Drawing.Size(84, 20)
        Me.mn_edit.Text = "Edit Draft"
        Me.mn_edit.Visible = False
        '
        'mn_print
        '
        Me.mn_print.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DraftBarangToolStripMenuItem})
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
        Me.DraftBarangToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DraftBarangToolStripMenuItem.Text = "Draft Tagihan"
        '
        'mn_refresh
        '
        Me.mn_refresh.Name = "mn_refresh"
        Me.mn_refresh.Size = New System.Drawing.Size(58, 20)
        Me.mn_refresh.Text = "Refresh"
        '
        'CancelPrintToolStripMenuItem
        '
        Me.CancelPrintToolStripMenuItem.Name = "CancelPrintToolStripMenuItem"
        Me.CancelPrintToolStripMenuItem.Size = New System.Drawing.Size(83, 20)
        Me.CancelPrintToolStripMenuItem.Text = "Cancel Print"
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
        Me.Panel1.TabIndex = 292
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(838, 11)
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
        Me.bt_cl.Location = New System.Drawing.Point(891, 11)
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
        Me.lbl_title.Location = New System.Drawing.Point(6, 6)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(158, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Draft Tagihan"
        '
        'ck_tgl2
        '
        Me.ck_tgl2.AutoSize = True
        Me.ck_tgl2.Location = New System.Drawing.Point(229, 51)
        Me.ck_tgl2.Name = "ck_tgl2"
        Me.ck_tgl2.Size = New System.Drawing.Size(120, 17)
        Me.ck_tgl2.TabIndex = 3
        Me.ck_tgl2.Text = "Filter tgl jatuh tempo"
        Me.ck_tgl2.UseVisualStyleBackColor = True
        '
        'ck_tgl1
        '
        Me.ck_tgl1.AutoSize = True
        Me.ck_tgl1.Location = New System.Drawing.Point(352, 51)
        Me.ck_tgl1.Name = "ck_tgl1"
        Me.ck_tgl1.Size = New System.Drawing.Size(144, 17)
        Me.ck_tgl1.TabIndex = 4
        Me.ck_tgl1.Text = "Filter sblm tgl jatuh tempo"
        Me.ck_tgl1.UseVisualStyleBackColor = True
        '
        'in_sales
        '
        Me.in_sales.BackColor = System.Drawing.Color.White
        Me.in_sales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales.ForeColor = System.Drawing.Color.Black
        Me.in_sales.Location = New System.Drawing.Point(361, 128)
        Me.in_sales.MaxLength = 30
        Me.in_sales.Name = "in_sales"
        Me.in_sales.ReadOnly = True
        Me.in_sales.Size = New System.Drawing.Size(236, 20)
        Me.in_sales.TabIndex = 10
        Me.in_sales.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(358, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 250
        Me.Label8.Text = "Kode Salesman"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(358, 156)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 250
        Me.Label9.Text = "Salesman"
        '
        'in_sales_n
        '
        Me.in_sales_n.BackColor = System.Drawing.Color.White
        Me.in_sales_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales_n.ForeColor = System.Drawing.Color.Black
        Me.in_sales_n.Location = New System.Drawing.Point(361, 172)
        Me.in_sales_n.MaxLength = 30
        Me.in_sales_n.Name = "in_sales_n"
        Me.in_sales_n.ReadOnly = True
        Me.in_sales_n.Size = New System.Drawing.Size(236, 20)
        Me.in_sales_n.TabIndex = 11
        Me.in_sales_n.TabStop = False
        '
        'lbl_statprint
        '
        Me.lbl_statprint.AutoSize = True
        Me.lbl_statprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_statprint.Location = New System.Drawing.Point(557, 19)
        Me.lbl_statprint.Name = "lbl_statprint"
        Me.lbl_statprint.Size = New System.Drawing.Size(40, 13)
        Me.lbl_statprint.TabIndex = 250
        Me.lbl_statprint.Text = "Printed"
        Me.lbl_statprint.Visible = False
        '
        'in_kecamatan
        '
        Me.in_kecamatan.BackColor = System.Drawing.Color.White
        Me.in_kecamatan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kecamatan.ForeColor = System.Drawing.Color.Black
        Me.in_kecamatan.Location = New System.Drawing.Point(65, 236)
        Me.in_kecamatan.MaxLength = 30
        Me.in_kecamatan.Name = "in_kecamatan"
        Me.in_kecamatan.Size = New System.Drawing.Size(188, 20)
        Me.in_kecamatan.TabIndex = 12
        Me.in_kecamatan.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(5, 239)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 324
        Me.Label10.Text = "Kecamatan"
        '
        'in_kabupaten
        '
        Me.in_kabupaten.BackColor = System.Drawing.Color.White
        Me.in_kabupaten.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kabupaten.ForeColor = System.Drawing.Color.Black
        Me.in_kabupaten.Location = New System.Drawing.Point(65, 259)
        Me.in_kabupaten.MaxLength = 30
        Me.in_kabupaten.Name = "in_kabupaten"
        Me.in_kabupaten.Size = New System.Drawing.Size(188, 20)
        Me.in_kabupaten.TabIndex = 13
        Me.in_kabupaten.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(5, 263)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 326
        Me.Label11.Text = "Kabupaten"
        '
        'in_pasar
        '
        Me.in_pasar.BackColor = System.Drawing.Color.White
        Me.in_pasar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_pasar.ForeColor = System.Drawing.Color.Black
        Me.in_pasar.Location = New System.Drawing.Point(300, 236)
        Me.in_pasar.MaxLength = 30
        Me.in_pasar.Name = "in_pasar"
        Me.in_pasar.Size = New System.Drawing.Size(175, 20)
        Me.in_pasar.TabIndex = 14
        Me.in_pasar.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(260, 239)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 328
        Me.Label12.Text = "Pasar"
        '
        'pnl_content
        '
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.Controls.Add(Me.dgv_detail_tagihan)
        Me.pnl_content.Controls.Add(Me.in_pasar)
        Me.pnl_content.Controls.Add(Me.Label6)
        Me.pnl_content.Controls.Add(Me.Label12)
        Me.pnl_content.Controls.Add(Me.date_faktur_awal)
        Me.pnl_content.Controls.Add(Me.in_kabupaten)
        Me.pnl_content.Controls.Add(Me.date_faktur_akhir)
        Me.pnl_content.Controls.Add(Me.Label11)
        Me.pnl_content.Controls.Add(Me.Label1)
        Me.pnl_content.Controls.Add(Me.in_kecamatan)
        Me.pnl_content.Controls.Add(Me.Label3)
        Me.pnl_content.Controls.Add(Me.Label10)
        Me.pnl_content.Controls.Add(Me.dgv_sales)
        Me.pnl_content.Controls.Add(Me.in_sales_n)
        Me.pnl_content.Controls.Add(Me.Label5)
        Me.pnl_content.Controls.Add(Me.in_sales)
        Me.pnl_content.Controls.Add(Me.in_cari_sales)
        Me.pnl_content.Controls.Add(Me.ck_tgl2)
        Me.pnl_content.Controls.Add(Me.bt_cari_sales)
        Me.pnl_content.Controls.Add(Me.lbl_statprint)
        Me.pnl_content.Controls.Add(Me.bt_loaddraft)
        Me.pnl_content.Controls.Add(Me.Label9)
        Me.pnl_content.Controls.Add(Me.dgv_draft_list)
        Me.pnl_content.Controls.Add(Me.ck_tgl1)
        Me.pnl_content.Controls.Add(Me.dgv_listfaktur)
        Me.pnl_content.Controls.Add(Me.Label8)
        Me.pnl_content.Controls.Add(Me.bt_addfaktur)
        Me.pnl_content.Controls.Add(Me.bt_create_draft)
        Me.pnl_content.Controls.Add(Me.bt_remfaktur)
        Me.pnl_content.Controls.Add(Me.Panel2)
        Me.pnl_content.Controls.Add(Me.bt_draft_nota)
        Me.pnl_content.Controls.Add(Me.bt_remsales)
        Me.pnl_content.Controls.Add(Me.bt_cari_faktur)
        Me.pnl_content.Controls.Add(Me.bt_addsales)
        Me.pnl_content.Controls.Add(Me.in_cari_faktur)
        Me.pnl_content.Controls.Add(Me.dgv_draftfaktur)
        Me.pnl_content.Controls.Add(Me.bt_caridraft)
        Me.pnl_content.Controls.Add(Me.Label4)
        Me.pnl_content.Controls.Add(Me.in_caridraft)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Location = New System.Drawing.Point(0, 66)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(918, 515)
        Me.pnl_content.TabIndex = 0
        '
        'dgv_detail_tagihan
        '
        Me.dgv_detail_tagihan.AllowUserToAddRows = False
        Me.dgv_detail_tagihan.AllowUserToDeleteRows = False
        Me.dgv_detail_tagihan.BackgroundColor = System.Drawing.Color.White
        Me.dgv_detail_tagihan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgv_detail_tagihan.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.dgv_detail_tagihan.Location = New System.Drawing.Point(13, 482)
        Me.dgv_detail_tagihan.Name = "dgv_detail_tagihan"
        Me.dgv_detail_tagihan.ReadOnly = True
        Me.dgv_detail_tagihan.RowHeadersVisible = False
        Me.dgv_detail_tagihan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_detail_tagihan.Size = New System.Drawing.Size(869, 174)
        Me.dgv_detail_tagihan.TabIndex = 21
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "customer_nama"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Customer"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "trans_faktur"
        Me.DataGridViewTextBoxColumn2.HeaderText = "No.Faktur"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 90
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "trans_harga_retur"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Sisa Tertagih"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 50
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 75
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Salesman"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'draftlist_kode
        '
        Me.draftlist_kode.DataPropertyName = "draft_kode"
        Me.draftlist_kode.HeaderText = "Kode Tagihan"
        Me.draftlist_kode.MinimumWidth = 100
        Me.draftlist_kode.Name = "draftlist_kode"
        Me.draftlist_kode.ReadOnly = True
        Me.draftlist_kode.Width = 125
        '
        'draftlist_tgl
        '
        Me.draftlist_tgl.DataPropertyName = "draft_tgl"
        Me.draftlist_tgl.HeaderText = "Tgl.Tagihan"
        Me.draftlist_tgl.MinimumWidth = 50
        Me.draftlist_tgl.Name = "draftlist_tgl"
        Me.draftlist_tgl.ReadOnly = True
        '
        'draftlist_sales
        '
        Me.draftlist_sales.DataPropertyName = "draft_sales"
        Me.draftlist_sales.HeaderText = "Salesman"
        Me.draftlist_sales.MinimumWidth = 175
        Me.draftlist_sales.Name = "draftlist_sales"
        Me.draftlist_sales.ReadOnly = True
        Me.draftlist_sales.Width = 175
        '
        'draft_status_print
        '
        Me.draft_status_print.DataPropertyName = "draft_printstatus"
        Me.draft_status_print.HeaderText = "Printed"
        Me.draft_status_print.Name = "draft_status_print"
        Me.draft_status_print.ReadOnly = True
        '
        'draft_custo
        '
        Me.draft_custo.DataPropertyName = "customer_nama"
        Me.draft_custo.HeaderText = "Customer"
        Me.draft_custo.MinimumWidth = 100
        Me.draft_custo.Name = "draft_custo"
        Me.draft_custo.ReadOnly = True
        Me.draft_custo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.draft_custo.Width = 120
        '
        'draft_faktur
        '
        Me.draft_faktur.DataPropertyName = "trans_faktur"
        Me.draft_faktur.HeaderText = "No.Faktur"
        Me.draft_faktur.Name = "draft_faktur"
        Me.draft_faktur.ReadOnly = True
        Me.draft_faktur.Width = 90
        '
        'draft_sisa
        '
        Me.draft_sisa.DataPropertyName = "trans_harga_retur"
        Me.draft_sisa.HeaderText = "Sisa Tertagih"
        Me.draft_sisa.MinimumWidth = 50
        Me.draft_sisa.Name = "draft_sisa"
        Me.draft_sisa.ReadOnly = True
        Me.draft_sisa.Width = 75
        '
        'draft_sales
        '
        Me.draft_sales.HeaderText = "Salesman"
        Me.draft_sales.Name = "draft_sales"
        Me.draft_sales.ReadOnly = True
        '
        'draft_tglcicil
        '
        Me.draft_tglcicil.HeaderText = "Tgl.Cicilan"
        Me.draft_tglcicil.Name = "draft_tglcicil"
        Me.draft_tglcicil.ReadOnly = True
        '
        'draft_countcicil
        '
        Me.draft_countcicil.HeaderText = "Cicilan"
        Me.draft_countcicil.Name = "draft_countcicil"
        Me.draft_countcicil.ReadOnly = True
        '
        'fr_draft_tagihan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "fr_draft_tagihan"
        Me.Size = New System.Drawing.Size(918, 581)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgv_draftfaktur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_listfaktur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_draft_list, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_sales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        CType(Me.dgv_detail_tagihan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_create_draft As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents in_kode_draft As System.Windows.Forms.TextBox
    Friend WithEvents date_tgl_trans As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents bt_remsales As System.Windows.Forms.Button
    Friend WithEvents bt_addsales As System.Windows.Forms.Button
    Friend WithEvents dgv_draftfaktur As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents in_caridraft As System.Windows.Forms.TextBox
    Friend WithEvents bt_caridraft As System.Windows.Forms.Button
    Friend WithEvents in_cari_faktur As System.Windows.Forms.TextBox
    Friend WithEvents bt_cari_faktur As System.Windows.Forms.Button
    Friend WithEvents bt_draft_nota As System.Windows.Forms.Button
    Friend WithEvents bt_remfaktur As System.Windows.Forms.Button
    Friend WithEvents bt_addfaktur As System.Windows.Forms.Button
    Friend WithEvents dgv_listfaktur As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_draft_list As System.Windows.Forms.DataGridView
    Friend WithEvents bt_loaddraft As System.Windows.Forms.Button
    Friend WithEvents bt_cari_sales As System.Windows.Forms.Button
    Friend WithEvents in_cari_sales As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgv_sales As System.Windows.Forms.DataGridView
    Friend WithEvents sales_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents date_faktur_akhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_faktur_awal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_tambah As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DraftBarangToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_refresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents ck_tgl2 As System.Windows.Forms.CheckBox
    Friend WithEvents ck_tgl1 As System.Windows.Forms.CheckBox
    Friend WithEvents in_sales As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents in_sales_n As System.Windows.Forms.TextBox
    Friend WithEvents lbl_statprint As System.Windows.Forms.Label
    Friend WithEvents in_kecamatan As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents in_kabupaten As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents in_pasar As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents list_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_tanggal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_sisa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_temp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_pasar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_kec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_kab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CancelPrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents dgv_detail_tagihan As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_sisa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_tglcicil As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_countcicil As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draftlist_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draftlist_tgl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draftlist_sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_status_print As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
