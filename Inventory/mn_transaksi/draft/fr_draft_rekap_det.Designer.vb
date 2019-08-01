<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_draft_rekap_det
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_draft_rekap_det))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_print = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_printnota = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_printbrg = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_cancelorder = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnl_footer = New System.Windows.Forms.Panel()
        Me.bt_simpanreturbeli = New System.Windows.Forms.Button()
        Me.bt_batalreturbeli = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.bt_search2 = New System.Windows.Forms.Button()
        Me.bt_search = New System.Windows.Forms.Button()
        Me.date_faktur_awal = New System.Windows.Forms.DateTimePicker()
        Me.date_faktur_akhir = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ck_tgl2 = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.bt_remfaktur = New System.Windows.Forms.Button()
        Me.dgv_draftfaktur = New System.Windows.Forms.DataGridView()
        Me.draft_custo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_netto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.in_cari_faktur = New System.Windows.Forms.TextBox()
        Me.bt_faktur_clear = New System.Windows.Forms.Button()
        Me.bt_faktur_all = New System.Windows.Forms.Button()
        Me.bt_addfaktur = New System.Windows.Forms.Button()
        Me.dgv_listfaktur = New System.Windows.Forms.DataGridView()
        Me.list_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_tanggal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_custo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_alamat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.list_netto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_draft = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.bt_remsales = New System.Windows.Forms.Button()
        Me.bt_addsales = New System.Windows.Forms.Button()
        Me.dgv_sales = New System.Windows.Forms.DataGridView()
        Me.sales_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sales_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sales_filler = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv_draftsales = New System.Windows.Forms.DataGridView()
        Me.draft_sales_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_sales_n = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_sales_filler = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.in_cari_sales = New System.Windows.Forms.TextBox()
        Me.in_kode_draft = New System.Windows.Forms.TextBox()
        Me.date_tgl_trans = New System.Windows.Forms.DateTimePicker()
        Me.lbl_count_faktur = New System.Windows.Forms.Label()
        Me.lbl_count_sales = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.pnl_footer.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgv_draftfaktur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_listfaktur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_sales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_draftsales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.lbl_title)
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(946, 32)
        Me.Panel1.TabIndex = 0
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Orange
        Me.lbl_title.Font = New System.Drawing.Font("Source Sans Pro", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(3, 3)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(151, 24)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Rekap Penjualan"
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
        Me.bt_cl.Location = New System.Drawing.Point(919, 6)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 0
        Me.bt_cl.TabStop = False
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_print, Me.mn_cancelorder})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 32)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(946, 24)
        Me.MenuStrip1.TabIndex = 21
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
        'mn_print
        '
        Me.mn_print.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_printnota, Me.mn_printbrg})
        Me.mn_print.Image = CType(resources.GetObject("mn_print.Image"), System.Drawing.Image)
        Me.mn_print.Name = "mn_print"
        Me.mn_print.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.mn_print.Size = New System.Drawing.Size(60, 20)
        Me.mn_print.Text = "&Print"
        Me.mn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mn_printnota
        '
        Me.mn_printnota.Name = "mn_printnota"
        Me.mn_printnota.Size = New System.Drawing.Size(168, 22)
        Me.mn_printnota.Text = "Print Draft Nota"
        '
        'mn_printbrg
        '
        Me.mn_printbrg.Name = "mn_printbrg"
        Me.mn_printbrg.Size = New System.Drawing.Size(168, 22)
        Me.mn_printbrg.Text = "Print Draft Barang"
        '
        'mn_cancelorder
        '
        Me.mn_cancelorder.Image = Global.Inventory.My.Resources.Resources.toolbar_cancel_icon
        Me.mn_cancelorder.Name = "mn_cancelorder"
        Me.mn_cancelorder.Size = New System.Drawing.Size(98, 20)
        Me.mn_cancelorder.Text = "Hapus Draft"
        Me.mn_cancelorder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnl_footer
        '
        Me.pnl_footer.BackColor = System.Drawing.Color.Gainsboro
        Me.pnl_footer.Controls.Add(Me.bt_simpanreturbeli)
        Me.pnl_footer.Controls.Add(Me.bt_batalreturbeli)
        Me.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_footer.Location = New System.Drawing.Point(0, 555)
        Me.pnl_footer.Name = "pnl_footer"
        Me.pnl_footer.Size = New System.Drawing.Size(946, 41)
        Me.pnl_footer.TabIndex = 1
        '
        'bt_simpanreturbeli
        '
        Me.bt_simpanreturbeli.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpanreturbeli.FlatAppearance.BorderSize = 0
        Me.bt_simpanreturbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpanreturbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanreturbeli.ForeColor = System.Drawing.Color.White
        Me.bt_simpanreturbeli.Location = New System.Drawing.Point(666, 5)
        Me.bt_simpanreturbeli.Name = "bt_simpanreturbeli"
        Me.bt_simpanreturbeli.Size = New System.Drawing.Size(161, 30)
        Me.bt_simpanreturbeli.TabIndex = 19
        Me.bt_simpanreturbeli.Text = "Simpan"
        Me.bt_simpanreturbeli.UseVisualStyleBackColor = False
        '
        'bt_batalreturbeli
        '
        Me.bt_batalreturbeli.BackColor = System.Drawing.Color.Tomato
        Me.bt_batalreturbeli.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalreturbeli.FlatAppearance.BorderSize = 0
        Me.bt_batalreturbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_batalreturbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalreturbeli.ForeColor = System.Drawing.Color.White
        Me.bt_batalreturbeli.Location = New System.Drawing.Point(833, 5)
        Me.bt_batalreturbeli.Name = "bt_batalreturbeli"
        Me.bt_batalreturbeli.Size = New System.Drawing.Size(106, 30)
        Me.bt_batalreturbeli.TabIndex = 20
        Me.bt_batalreturbeli.Text = "Batal"
        Me.bt_batalreturbeli.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 596)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(946, 10)
        Me.Panel3.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.bt_search2)
        Me.Panel2.Controls.Add(Me.bt_search)
        Me.Panel2.Controls.Add(Me.date_faktur_awal)
        Me.Panel2.Controls.Add(Me.date_faktur_akhir)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.ck_tgl2)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.bt_remfaktur)
        Me.Panel2.Controls.Add(Me.dgv_draftfaktur)
        Me.Panel2.Controls.Add(Me.in_cari_faktur)
        Me.Panel2.Controls.Add(Me.bt_faktur_clear)
        Me.Panel2.Controls.Add(Me.bt_faktur_all)
        Me.Panel2.Controls.Add(Me.bt_addfaktur)
        Me.Panel2.Controls.Add(Me.dgv_listfaktur)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.bt_remsales)
        Me.Panel2.Controls.Add(Me.bt_addsales)
        Me.Panel2.Controls.Add(Me.dgv_sales)
        Me.Panel2.Controls.Add(Me.dgv_draftsales)
        Me.Panel2.Controls.Add(Me.in_cari_sales)
        Me.Panel2.Controls.Add(Me.in_kode_draft)
        Me.Panel2.Controls.Add(Me.date_tgl_trans)
        Me.Panel2.Controls.Add(Me.lbl_count_faktur)
        Me.Panel2.Controls.Add(Me.lbl_count_sales)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 56)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(946, 499)
        Me.Panel2.TabIndex = 0
        '
        'bt_search2
        '
        Me.bt_search2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bt_search2.BackgroundImage = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.bt_search2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_search2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_search2.Location = New System.Drawing.Point(278, 219)
        Me.bt_search2.Name = "bt_search2"
        Me.bt_search2.Size = New System.Drawing.Size(42, 20)
        Me.bt_search2.TabIndex = 9
        Me.bt_search2.UseVisualStyleBackColor = False
        '
        'bt_search
        '
        Me.bt_search.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bt_search.BackgroundImage = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.bt_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_search.Location = New System.Drawing.Point(278, 43)
        Me.bt_search.Name = "bt_search"
        Me.bt_search.Size = New System.Drawing.Size(42, 20)
        Me.bt_search.TabIndex = 3
        Me.bt_search.UseVisualStyleBackColor = False
        '
        'date_faktur_awal
        '
        Me.date_faktur_awal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_faktur_awal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_faktur_awal.Location = New System.Drawing.Point(181, 242)
        Me.date_faktur_awal.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_faktur_awal.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_faktur_awal.Name = "date_faktur_awal"
        Me.date_faktur_awal.Size = New System.Drawing.Size(104, 20)
        Me.date_faktur_awal.TabIndex = 11
        '
        'date_faktur_akhir
        '
        Me.date_faktur_akhir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_faktur_akhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_faktur_akhir.Location = New System.Drawing.Point(313, 242)
        Me.date_faktur_akhir.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_faktur_akhir.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_faktur_akhir.Name = "date_faktur_akhir"
        Me.date_faktur_akhir.Size = New System.Drawing.Size(104, 20)
        Me.date_faktur_akhir.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(289, 246)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 390
        Me.Label3.Text = "s.d."
        '
        'ck_tgl2
        '
        Me.ck_tgl2.AutoSize = True
        Me.ck_tgl2.Location = New System.Drawing.Point(71, 243)
        Me.ck_tgl2.Name = "ck_tgl2"
        Me.ck_tgl2.Size = New System.Drawing.Size(104, 19)
        Me.ck_tgl2.TabIndex = 10
        Me.ck_tgl2.Text = "Filter tgl Faktur"
        Me.ck_tgl2.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label13.Location = New System.Drawing.Point(8, 221)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 386
        Me.Label13.Text = "Faktur"
        '
        'bt_remfaktur
        '
        Me.bt_remfaktur.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_remfaktur.Location = New System.Drawing.Point(534, 348)
        Me.bt_remfaktur.Name = "bt_remfaktur"
        Me.bt_remfaktur.Size = New System.Drawing.Size(27, 36)
        Me.bt_remfaktur.TabIndex = 16
        Me.bt_remfaktur.Text = "<"
        Me.bt_remfaktur.UseVisualStyleBackColor = True
        '
        'dgv_draftfaktur
        '
        Me.dgv_draftfaktur.AllowUserToAddRows = False
        Me.dgv_draftfaktur.AllowUserToDeleteRows = False
        Me.dgv_draftfaktur.BackgroundColor = System.Drawing.Color.White
        Me.dgv_draftfaktur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_draftfaktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.draft_custo, Me.draft_faktur, Me.draft_netto, Me.draft_sales})
        Me.dgv_draftfaktur.Location = New System.Drawing.Point(565, 265)
        Me.dgv_draftfaktur.Name = "dgv_draftfaktur"
        Me.dgv_draftfaktur.ReadOnly = True
        Me.dgv_draftfaktur.RowHeadersVisible = False
        Me.dgv_draftfaktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_draftfaktur.Size = New System.Drawing.Size(369, 195)
        Me.dgv_draftfaktur.StandardTab = True
        Me.dgv_draftfaktur.TabIndex = 18
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
        Me.in_cari_faktur.Location = New System.Drawing.Point(71, 219)
        Me.in_cari_faktur.MaxLength = 30
        Me.in_cari_faktur.Name = "in_cari_faktur"
        Me.in_cari_faktur.Size = New System.Drawing.Size(207, 20)
        Me.in_cari_faktur.TabIndex = 8
        '
        'bt_faktur_clear
        '
        Me.bt_faktur_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_faktur_clear.Font = New System.Drawing.Font("Open Sans", 8.25!)
        Me.bt_faktur_clear.Location = New System.Drawing.Point(853, 236)
        Me.bt_faktur_clear.Name = "bt_faktur_clear"
        Me.bt_faktur_clear.Size = New System.Drawing.Size(81, 26)
        Me.bt_faktur_clear.TabIndex = 17
        Me.bt_faktur_clear.Text = "Clear"
        Me.bt_faktur_clear.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_faktur_clear.UseVisualStyleBackColor = True
        '
        'bt_faktur_all
        '
        Me.bt_faktur_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_faktur_all.Font = New System.Drawing.Font("Open Sans", 8.25!)
        Me.bt_faktur_all.Location = New System.Drawing.Point(449, 236)
        Me.bt_faktur_all.Name = "bt_faktur_all"
        Me.bt_faktur_all.Size = New System.Drawing.Size(81, 26)
        Me.bt_faktur_all.TabIndex = 13
        Me.bt_faktur_all.Text = "Pilih Semua"
        Me.bt_faktur_all.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_faktur_all.UseVisualStyleBackColor = True
        '
        'bt_addfaktur
        '
        Me.bt_addfaktur.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_addfaktur.Location = New System.Drawing.Point(534, 310)
        Me.bt_addfaktur.Name = "bt_addfaktur"
        Me.bt_addfaktur.Size = New System.Drawing.Size(27, 36)
        Me.bt_addfaktur.TabIndex = 15
        Me.bt_addfaktur.Text = ">"
        Me.bt_addfaktur.UseVisualStyleBackColor = True
        '
        'dgv_listfaktur
        '
        Me.dgv_listfaktur.AllowUserToAddRows = False
        Me.dgv_listfaktur.AllowUserToDeleteRows = False
        Me.dgv_listfaktur.BackgroundColor = System.Drawing.Color.White
        Me.dgv_listfaktur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listfaktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.list_faktur, Me.list_tanggal, Me.list_custo, Me.list_alamat, Me.list_netto, Me.faktur_draft, Me.sales})
        Me.dgv_listfaktur.Location = New System.Drawing.Point(14, 265)
        Me.dgv_listfaktur.Name = "dgv_listfaktur"
        Me.dgv_listfaktur.ReadOnly = True
        Me.dgv_listfaktur.RowHeadersVisible = False
        Me.dgv_listfaktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listfaktur.Size = New System.Drawing.Size(516, 195)
        Me.dgv_listfaktur.StandardTab = True
        Me.dgv_listfaktur.TabIndex = 14
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
        'list_alamat
        '
        Me.list_alamat.DataPropertyName = "alamat"
        Me.list_alamat.HeaderText = "Alamat"
        Me.list_alamat.Name = "list_alamat"
        Me.list_alamat.ReadOnly = True
        Me.list_alamat.Width = 150
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
        'faktur_draft
        '
        Me.faktur_draft.DataPropertyName = "faktur_draft_rekap"
        Me.faktur_draft.HeaderText = "Draft"
        Me.faktur_draft.Name = "faktur_draft"
        Me.faktur_draft.ReadOnly = True
        Me.faktur_draft.Width = 50
        '
        'sales
        '
        Me.sales.DataPropertyName = "salesman_nama"
        Me.sales.HeaderText = "Sales"
        Me.sales.Name = "sales"
        Me.sales.ReadOnly = True
        Me.sales.Width = 150
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(8, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 379
        Me.Label8.Text = "Salesman"
        '
        'bt_remsales
        '
        Me.bt_remsales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_remsales.Location = New System.Drawing.Point(327, 108)
        Me.bt_remsales.Name = "bt_remsales"
        Me.bt_remsales.Size = New System.Drawing.Size(27, 36)
        Me.bt_remsales.TabIndex = 6
        Me.bt_remsales.Text = "-"
        Me.bt_remsales.UseVisualStyleBackColor = True
        '
        'bt_addsales
        '
        Me.bt_addsales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_addsales.Location = New System.Drawing.Point(327, 71)
        Me.bt_addsales.Name = "bt_addsales"
        Me.bt_addsales.Size = New System.Drawing.Size(27, 36)
        Me.bt_addsales.TabIndex = 5
        Me.bt_addsales.Text = "+"
        Me.bt_addsales.UseVisualStyleBackColor = True
        '
        'dgv_sales
        '
        Me.dgv_sales.AllowUserToAddRows = False
        Me.dgv_sales.AllowUserToDeleteRows = False
        Me.dgv_sales.BackgroundColor = System.Drawing.Color.White
        Me.dgv_sales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_sales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sales_kode, Me.sales_nama, Me.sales_filler})
        Me.dgv_sales.Location = New System.Drawing.Point(11, 66)
        Me.dgv_sales.Name = "dgv_sales"
        Me.dgv_sales.ReadOnly = True
        Me.dgv_sales.RowHeadersVisible = False
        Me.dgv_sales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_sales.Size = New System.Drawing.Size(309, 143)
        Me.dgv_sales.StandardTab = True
        Me.dgv_sales.TabIndex = 4
        '
        'sales_kode
        '
        Me.sales_kode.DataPropertyName = "salesman_kode"
        Me.sales_kode.HeaderText = "Kode"
        Me.sales_kode.Name = "sales_kode"
        Me.sales_kode.ReadOnly = True
        '
        'sales_nama
        '
        Me.sales_nama.DataPropertyName = "salesman_nama"
        Me.sales_nama.HeaderText = "Nama"
        Me.sales_nama.MinimumWidth = 190
        Me.sales_nama.Name = "sales_nama"
        Me.sales_nama.ReadOnly = True
        Me.sales_nama.Width = 190
        '
        'sales_filler
        '
        Me.sales_filler.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.sales_filler.HeaderText = ""
        Me.sales_filler.Name = "sales_filler"
        Me.sales_filler.ReadOnly = True
        '
        'dgv_draftsales
        '
        Me.dgv_draftsales.AllowUserToAddRows = False
        Me.dgv_draftsales.AllowUserToDeleteRows = False
        Me.dgv_draftsales.BackgroundColor = System.Drawing.Color.White
        Me.dgv_draftsales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_draftsales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.draft_sales_kode, Me.draft_sales_n, Me.draft_sales_filler})
        Me.dgv_draftsales.Location = New System.Drawing.Point(360, 66)
        Me.dgv_draftsales.Name = "dgv_draftsales"
        Me.dgv_draftsales.ReadOnly = True
        Me.dgv_draftsales.RowHeadersVisible = False
        Me.dgv_draftsales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_draftsales.Size = New System.Drawing.Size(303, 143)
        Me.dgv_draftsales.StandardTab = True
        Me.dgv_draftsales.TabIndex = 7
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
        'draft_sales_filler
        '
        Me.draft_sales_filler.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.draft_sales_filler.HeaderText = ""
        Me.draft_sales_filler.Name = "draft_sales_filler"
        Me.draft_sales_filler.ReadOnly = True
        '
        'in_cari_sales
        '
        Me.in_cari_sales.BackColor = System.Drawing.Color.White
        Me.in_cari_sales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari_sales.ForeColor = System.Drawing.Color.Black
        Me.in_cari_sales.Location = New System.Drawing.Point(71, 43)
        Me.in_cari_sales.MaxLength = 30
        Me.in_cari_sales.Name = "in_cari_sales"
        Me.in_cari_sales.Size = New System.Drawing.Size(207, 20)
        Me.in_cari_sales.TabIndex = 2
        '
        'in_kode_draft
        '
        Me.in_kode_draft.BackColor = System.Drawing.Color.White
        Me.in_kode_draft.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode_draft.ForeColor = System.Drawing.Color.Black
        Me.in_kode_draft.Location = New System.Drawing.Point(71, 10)
        Me.in_kode_draft.MaxLength = 30
        Me.in_kode_draft.Name = "in_kode_draft"
        Me.in_kode_draft.ReadOnly = True
        Me.in_kode_draft.Size = New System.Drawing.Size(164, 22)
        Me.in_kode_draft.TabIndex = 0
        Me.in_kode_draft.TabStop = False
        '
        'date_tgl_trans
        '
        Me.date_tgl_trans.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_trans.Location = New System.Drawing.Point(313, 10)
        Me.date_tgl_trans.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_trans.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_trans.Name = "date_tgl_trans"
        Me.date_tgl_trans.Size = New System.Drawing.Size(164, 22)
        Me.date_tgl_trans.TabIndex = 1
        '
        'lbl_count_faktur
        '
        Me.lbl_count_faktur.AutoSize = True
        Me.lbl_count_faktur.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_count_faktur.Location = New System.Drawing.Point(562, 463)
        Me.lbl_count_faktur.Name = "lbl_count_faktur"
        Me.lbl_count_faktur.Size = New System.Drawing.Size(57, 15)
        Me.lbl_count_faktur.TabIndex = 253
        Me.lbl_count_faktur.Text = "Tgl Rekap"
        '
        'lbl_count_sales
        '
        Me.lbl_count_sales.AutoSize = True
        Me.lbl_count_sales.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_count_sales.Location = New System.Drawing.Point(606, 212)
        Me.lbl_count_sales.Name = "lbl_count_sales"
        Me.lbl_count_sales.Size = New System.Drawing.Size(57, 15)
        Me.lbl_count_sales.TabIndex = 253
        Me.lbl_count_sales.Text = "Tgl Rekap"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(250, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 253
        Me.Label2.Text = "Tgl Rekap"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 15)
        Me.Label7.TabIndex = 254
        Me.Label7.Text = "No.Rekap"
        '
        'fr_draft_rekap_det
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.bt_batalreturbeli
        Me.ClientSize = New System.Drawing.Size(946, 606)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnl_footer)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_draft_rekap_det"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Draft Rekap Penjualan"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.pnl_footer.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgv_draftfaktur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_listfaktur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_sales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_draftsales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_cancelorder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnl_footer As System.Windows.Forms.Panel
    Friend WithEvents bt_simpanreturbeli As System.Windows.Forms.Button
    Friend WithEvents bt_batalreturbeli As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents in_kode_draft As System.Windows.Forms.TextBox
    Friend WithEvents date_tgl_trans As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents mn_printnota As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_printbrg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents bt_remsales As System.Windows.Forms.Button
    Friend WithEvents bt_addsales As System.Windows.Forms.Button
    Friend WithEvents dgv_sales As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_draftsales As System.Windows.Forms.DataGridView
    Friend WithEvents in_cari_sales As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents bt_remfaktur As System.Windows.Forms.Button
    Friend WithEvents dgv_draftfaktur As System.Windows.Forms.DataGridView
    Friend WithEvents draft_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_netto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents in_cari_faktur As System.Windows.Forms.TextBox
    Friend WithEvents bt_addfaktur As System.Windows.Forms.Button
    Friend WithEvents dgv_listfaktur As System.Windows.Forms.DataGridView
    Friend WithEvents date_faktur_awal As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_faktur_akhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ck_tgl2 As System.Windows.Forms.CheckBox
    Friend WithEvents bt_search2 As System.Windows.Forms.Button
    Friend WithEvents bt_search As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents bt_faktur_clear As System.Windows.Forms.Button
    Friend WithEvents bt_faktur_all As System.Windows.Forms.Button
    Friend WithEvents lbl_count_faktur As System.Windows.Forms.Label
    Friend WithEvents lbl_count_sales As System.Windows.Forms.Label
    Friend WithEvents list_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_tanggal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_alamat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_netto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_draft As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales_filler As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_sales_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_sales_n As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_sales_filler As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
