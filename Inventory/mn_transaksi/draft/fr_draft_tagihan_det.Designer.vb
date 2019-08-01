<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_draft_tagihan_det
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_draft_tagihan_det))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_print = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_cancelorder = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnl_footer = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.in_printed = New System.Windows.Forms.TextBox()
        Me.bt_simpanreturbeli = New System.Windows.Forms.Button()
        Me.bt_batalreturbeli = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Pnl_content = New System.Windows.Forms.Panel()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.linkLbl_searchbarang = New System.Windows.Forms.LinkLabel()
        Me.dgv_detail_tagihan = New System.Windows.Forms.DataGridView()
        Me.hist_tanggal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hist_ket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hist_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hist_debet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hist_kredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hist_saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hist_tagihan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hist_filler = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bt_remfaktur = New System.Windows.Forms.Button()
        Me.bt_faktur_clear = New System.Windows.Forms.Button()
        Me.bt_addfaktur = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_count_faktur = New System.Windows.Forms.Label()
        Me.ck_hidepaid = New System.Windows.Forms.CheckBox()
        Me.ck_tgl2 = New System.Windows.Forms.CheckBox()
        Me.ck_tgl1 = New System.Windows.Forms.CheckBox()
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
        Me.dgv_draftfaktur = New System.Windows.Forms.DataGridView()
        Me.draft_custo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_sisa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.draft_sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bt_search2 = New System.Windows.Forms.Button()
        Me.date_faktur_awal = New System.Windows.Forms.DateTimePicker()
        Me.date_faktur_akhir = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.in_cari_faktur = New System.Windows.Forms.TextBox()
        Me.bt_faktur_all = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.in_sales_n = New System.Windows.Forms.TextBox()
        Me.in_sales = New System.Windows.Forms.TextBox()
        Me.in_kode_draft = New System.Windows.Forms.TextBox()
        Me.date_tgl_trans = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.pnl_footer.SuspendLayout()
        Me.Pnl_content.SuspendLayout()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_detail_tagihan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_listfaktur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_draftfaktur, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(960, 32)
        Me.Panel1.TabIndex = 1
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
        Me.bt_cl.Location = New System.Drawing.Point(933, 6)
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
        Me.MenuStrip1.Size = New System.Drawing.Size(960, 24)
        Me.MenuStrip1.TabIndex = 22
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
        Me.mn_print.Image = CType(resources.GetObject("mn_print.Image"), System.Drawing.Image)
        Me.mn_print.Name = "mn_print"
        Me.mn_print.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.mn_print.Size = New System.Drawing.Size(60, 20)
        Me.mn_print.Text = "&Print"
        Me.mn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mn_cancelorder
        '
        Me.mn_cancelorder.Image = Global.Inventory.My.Resources.Resources.toolbar_cancel_icon
        Me.mn_cancelorder.Name = "mn_cancelorder"
        Me.mn_cancelorder.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Delete), System.Windows.Forms.Keys)
        Me.mn_cancelorder.Size = New System.Drawing.Size(98, 20)
        Me.mn_cancelorder.Text = "Hapus Draft"
        Me.mn_cancelorder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnl_footer
        '
        Me.pnl_footer.BackColor = System.Drawing.Color.Gainsboro
        Me.pnl_footer.Controls.Add(Me.Label4)
        Me.pnl_footer.Controls.Add(Me.in_printed)
        Me.pnl_footer.Controls.Add(Me.bt_simpanreturbeli)
        Me.pnl_footer.Controls.Add(Me.bt_batalreturbeli)
        Me.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_footer.Location = New System.Drawing.Point(0, 549)
        Me.pnl_footer.Name = "pnl_footer"
        Me.pnl_footer.Size = New System.Drawing.Size(960, 41)
        Me.pnl_footer.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(12, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "PrintState"
        '
        'in_printed
        '
        Me.in_printed.BackColor = System.Drawing.Color.WhiteSmoke
        Me.in_printed.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_printed.ForeColor = System.Drawing.Color.Black
        Me.in_printed.Location = New System.Drawing.Point(81, 10)
        Me.in_printed.MaxLength = 30
        Me.in_printed.Name = "in_printed"
        Me.in_printed.ReadOnly = True
        Me.in_printed.Size = New System.Drawing.Size(81, 22)
        Me.in_printed.TabIndex = 22
        Me.in_printed.TabStop = False
        Me.in_printed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bt_simpanreturbeli
        '
        Me.bt_simpanreturbeli.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpanreturbeli.FlatAppearance.BorderSize = 0
        Me.bt_simpanreturbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpanreturbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanreturbeli.ForeColor = System.Drawing.Color.White
        Me.bt_simpanreturbeli.Location = New System.Drawing.Point(680, 5)
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
        Me.bt_batalreturbeli.Location = New System.Drawing.Point(847, 5)
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
        Me.Panel3.Location = New System.Drawing.Point(0, 590)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(960, 10)
        Me.Panel3.TabIndex = 23
        '
        'Pnl_content
        '
        Me.Pnl_content.AutoScroll = True
        Me.Pnl_content.Controls.Add(Me.popPnl_barang)
        Me.Pnl_content.Controls.Add(Me.dgv_detail_tagihan)
        Me.Pnl_content.Controls.Add(Me.bt_remfaktur)
        Me.Pnl_content.Controls.Add(Me.bt_faktur_clear)
        Me.Pnl_content.Controls.Add(Me.bt_addfaktur)
        Me.Pnl_content.Controls.Add(Me.Label1)
        Me.Pnl_content.Controls.Add(Me.lbl_count_faktur)
        Me.Pnl_content.Controls.Add(Me.ck_hidepaid)
        Me.Pnl_content.Controls.Add(Me.ck_tgl2)
        Me.Pnl_content.Controls.Add(Me.ck_tgl1)
        Me.Pnl_content.Controls.Add(Me.dgv_listfaktur)
        Me.Pnl_content.Controls.Add(Me.dgv_draftfaktur)
        Me.Pnl_content.Controls.Add(Me.bt_search2)
        Me.Pnl_content.Controls.Add(Me.date_faktur_awal)
        Me.Pnl_content.Controls.Add(Me.date_faktur_akhir)
        Me.Pnl_content.Controls.Add(Me.Label3)
        Me.Pnl_content.Controls.Add(Me.Label13)
        Me.Pnl_content.Controls.Add(Me.in_cari_faktur)
        Me.Pnl_content.Controls.Add(Me.bt_faktur_all)
        Me.Pnl_content.Controls.Add(Me.Label8)
        Me.Pnl_content.Controls.Add(Me.in_sales_n)
        Me.Pnl_content.Controls.Add(Me.in_sales)
        Me.Pnl_content.Controls.Add(Me.in_kode_draft)
        Me.Pnl_content.Controls.Add(Me.date_tgl_trans)
        Me.Pnl_content.Controls.Add(Me.Label2)
        Me.Pnl_content.Controls.Add(Me.Label7)
        Me.Pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnl_content.Location = New System.Drawing.Point(0, 56)
        Me.Pnl_content.Name = "Pnl_content"
        Me.Pnl_content.Size = New System.Drawing.Size(960, 493)
        Me.Pnl_content.TabIndex = 0
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Controls.Add(Me.linkLbl_searchbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(119, 190)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(375, 135)
        Me.popPnl_barang.TabIndex = 1
        Me.popPnl_barang.Visible = False
        '
        'dgv_listbarang
        '
        Me.dgv_listbarang.AllowUserToAddRows = False
        Me.dgv_listbarang.AllowUserToDeleteRows = False
        Me.dgv_listbarang.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv_listbarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listbarang.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgv_listbarang.Location = New System.Drawing.Point(0, 0)
        Me.dgv_listbarang.MultiSelect = False
        Me.dgv_listbarang.Name = "dgv_listbarang"
        Me.dgv_listbarang.ReadOnly = True
        Me.dgv_listbarang.RowHeadersVisible = False
        Me.dgv_listbarang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listbarang.Size = New System.Drawing.Size(375, 129)
        Me.dgv_listbarang.TabIndex = 0
        '
        'linkLbl_searchbarang
        '
        Me.linkLbl_searchbarang.AutoSize = True
        Me.linkLbl_searchbarang.LinkColor = System.Drawing.Color.DimGray
        Me.linkLbl_searchbarang.Location = New System.Drawing.Point(3, 114)
        Me.linkLbl_searchbarang.Name = "linkLbl_searchbarang"
        Me.linkLbl_searchbarang.Size = New System.Drawing.Size(124, 15)
        Me.linkLbl_searchbarang.TabIndex = 1
        Me.linkLbl_searchbarang.TabStop = True
        Me.linkLbl_searchbarang.Text = "Tampilkan Pencarian..."
        Me.linkLbl_searchbarang.VisitedLinkColor = System.Drawing.Color.DimGray
        '
        'dgv_detail_tagihan
        '
        Me.dgv_detail_tagihan.AllowUserToAddRows = False
        Me.dgv_detail_tagihan.AllowUserToDeleteRows = False
        Me.dgv_detail_tagihan.BackgroundColor = System.Drawing.Color.White
        Me.dgv_detail_tagihan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgv_detail_tagihan.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.hist_tanggal, Me.hist_ket, Me.hist_faktur, Me.hist_debet, Me.hist_kredit, Me.hist_saldo, Me.hist_tagihan, Me.hist_filler})
        Me.dgv_detail_tagihan.Location = New System.Drawing.Point(15, 369)
        Me.dgv_detail_tagihan.Name = "dgv_detail_tagihan"
        Me.dgv_detail_tagihan.ReadOnly = True
        Me.dgv_detail_tagihan.RowHeadersVisible = False
        Me.dgv_detail_tagihan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_detail_tagihan.Size = New System.Drawing.Size(938, 118)
        Me.dgv_detail_tagihan.TabIndex = 19
        Me.dgv_detail_tagihan.TabStop = False
        '
        'hist_tanggal
        '
        Me.hist_tanggal.DataPropertyName = "tanggal"
        Me.hist_tanggal.HeaderText = "Tanggal"
        Me.hist_tanggal.Name = "hist_tanggal"
        Me.hist_tanggal.ReadOnly = True
        '
        'hist_ket
        '
        Me.hist_ket.DataPropertyName = "keterangan"
        Me.hist_ket.HeaderText = "Keterangan"
        Me.hist_ket.Name = "hist_ket"
        Me.hist_ket.ReadOnly = True
        Me.hist_ket.Width = 200
        '
        'hist_faktur
        '
        Me.hist_faktur.DataPropertyName = "piutang_faktur"
        Me.hist_faktur.HeaderText = "No.Faktur"
        Me.hist_faktur.Name = "hist_faktur"
        Me.hist_faktur.ReadOnly = True
        '
        'hist_debet
        '
        Me.hist_debet.DataPropertyName = "debet"
        Me.hist_debet.HeaderText = "Debet"
        Me.hist_debet.Name = "hist_debet"
        Me.hist_debet.ReadOnly = True
        '
        'hist_kredit
        '
        Me.hist_kredit.DataPropertyName = "kredit"
        Me.hist_kredit.HeaderText = "Kredit"
        Me.hist_kredit.Name = "hist_kredit"
        Me.hist_kredit.ReadOnly = True
        '
        'hist_saldo
        '
        Me.hist_saldo.DataPropertyName = "saldo"
        Me.hist_saldo.HeaderText = "Saldo"
        Me.hist_saldo.Name = "hist_saldo"
        Me.hist_saldo.ReadOnly = True
        '
        'hist_tagihan
        '
        Me.hist_tagihan.DataPropertyName = "tagihan"
        Me.hist_tagihan.HeaderText = "Tagihan"
        Me.hist_tagihan.Name = "hist_tagihan"
        Me.hist_tagihan.ReadOnly = True
        '
        'hist_filler
        '
        Me.hist_filler.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.hist_filler.HeaderText = ""
        Me.hist_filler.Name = "hist_filler"
        Me.hist_filler.ReadOnly = True
        '
        'bt_remfaktur
        '
        Me.bt_remfaktur.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_remfaktur.Location = New System.Drawing.Point(543, 218)
        Me.bt_remfaktur.Name = "bt_remfaktur"
        Me.bt_remfaktur.Size = New System.Drawing.Size(27, 36)
        Me.bt_remfaktur.TabIndex = 14
        Me.bt_remfaktur.Text = "<"
        Me.bt_remfaktur.UseVisualStyleBackColor = True
        '
        'bt_faktur_clear
        '
        Me.bt_faktur_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_faktur_clear.Font = New System.Drawing.Font("Open Sans", 8.25!)
        Me.bt_faktur_clear.Location = New System.Drawing.Point(872, 129)
        Me.bt_faktur_clear.Name = "bt_faktur_clear"
        Me.bt_faktur_clear.Size = New System.Drawing.Size(81, 26)
        Me.bt_faktur_clear.TabIndex = 16
        Me.bt_faktur_clear.Text = "Clear"
        Me.bt_faktur_clear.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_faktur_clear.UseVisualStyleBackColor = True
        '
        'bt_addfaktur
        '
        Me.bt_addfaktur.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_addfaktur.Location = New System.Drawing.Point(543, 180)
        Me.bt_addfaktur.Name = "bt_addfaktur"
        Me.bt_addfaktur.Size = New System.Drawing.Size(27, 36)
        Me.bt_addfaktur.TabIndex = 13
        Me.bt_addfaktur.Text = ">"
        Me.bt_addfaktur.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 353)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Histori Piutang :"
        '
        'lbl_count_faktur
        '
        Me.lbl_count_faktur.AutoSize = True
        Me.lbl_count_faktur.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_count_faktur.Location = New System.Drawing.Point(570, 139)
        Me.lbl_count_faktur.Name = "lbl_count_faktur"
        Me.lbl_count_faktur.Size = New System.Drawing.Size(57, 15)
        Me.lbl_count_faktur.TabIndex = 1
        Me.lbl_count_faktur.Text = "Tgl Rekap"
        '
        'ck_hidepaid
        '
        Me.ck_hidepaid.AutoSize = True
        Me.ck_hidepaid.Checked = True
        Me.ck_hidepaid.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_hidepaid.Location = New System.Drawing.Point(388, 107)
        Me.ck_hidepaid.Name = "ck_hidepaid"
        Me.ck_hidepaid.Size = New System.Drawing.Size(162, 19)
        Me.ck_hidepaid.TabIndex = 10
        Me.ck_hidepaid.Text = "Sembunyikan faktur lunas"
        Me.ck_hidepaid.UseVisualStyleBackColor = True
        '
        'ck_tgl2
        '
        Me.ck_tgl2.AutoSize = True
        Me.ck_tgl2.Checked = True
        Me.ck_tgl2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_tgl2.Location = New System.Drawing.Point(78, 106)
        Me.ck_tgl2.Name = "ck_tgl2"
        Me.ck_tgl2.Size = New System.Drawing.Size(135, 19)
        Me.ck_tgl2.TabIndex = 8
        Me.ck_tgl2.Text = "Filter tgl jatuh tempo"
        Me.ck_tgl2.UseVisualStyleBackColor = True
        '
        'ck_tgl1
        '
        Me.ck_tgl1.AutoSize = True
        Me.ck_tgl1.Location = New System.Drawing.Point(219, 106)
        Me.ck_tgl1.Name = "ck_tgl1"
        Me.ck_tgl1.Size = New System.Drawing.Size(163, 19)
        Me.ck_tgl1.TabIndex = 9
        Me.ck_tgl1.Text = "Filter sblm tgl jatuh tempo"
        Me.ck_tgl1.UseVisualStyleBackColor = True
        '
        'dgv_listfaktur
        '
        Me.dgv_listfaktur.AllowUserToAddRows = False
        Me.dgv_listfaktur.AllowUserToDeleteRows = False
        Me.dgv_listfaktur.BackgroundColor = System.Drawing.Color.White
        Me.dgv_listfaktur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listfaktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.list_faktur, Me.list_tanggal, Me.list_custo, Me.list_sisa, Me.list_temp, Me.list_pasar, Me.list_kec, Me.list_kab, Me.list_sales})
        Me.dgv_listfaktur.Location = New System.Drawing.Point(15, 157)
        Me.dgv_listfaktur.Name = "dgv_listfaktur"
        Me.dgv_listfaktur.ReadOnly = True
        Me.dgv_listfaktur.RowHeadersVisible = False
        Me.dgv_listfaktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listfaktur.Size = New System.Drawing.Size(525, 192)
        Me.dgv_listfaktur.StandardTab = True
        Me.dgv_listfaktur.TabIndex = 12
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
        Me.list_custo.DataPropertyName = "piutang_custo"
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle1.Format = "N2"
        Me.list_sisa.DefaultCellStyle = DataGridViewCellStyle1
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
        Me.list_pasar.DataPropertyName = "piutang_pasar"
        Me.list_pasar.HeaderText = "Pasar"
        Me.list_pasar.Name = "list_pasar"
        Me.list_pasar.ReadOnly = True
        '
        'list_kec
        '
        Me.list_kec.DataPropertyName = "piutang_kec"
        Me.list_kec.HeaderText = "Kecamatan"
        Me.list_kec.Name = "list_kec"
        Me.list_kec.ReadOnly = True
        '
        'list_kab
        '
        Me.list_kab.DataPropertyName = "piutang_kab"
        Me.list_kab.HeaderText = "Kabupaten"
        Me.list_kab.Name = "list_kab"
        Me.list_kab.ReadOnly = True
        '
        'list_sales
        '
        Me.list_sales.DataPropertyName = "piutang_sales"
        Me.list_sales.HeaderText = "Salesman"
        Me.list_sales.Name = "list_sales"
        Me.list_sales.ReadOnly = True
        Me.list_sales.Width = 125
        '
        'dgv_draftfaktur
        '
        Me.dgv_draftfaktur.AllowUserToAddRows = False
        Me.dgv_draftfaktur.AllowUserToDeleteRows = False
        Me.dgv_draftfaktur.BackgroundColor = System.Drawing.Color.White
        Me.dgv_draftfaktur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgv_draftfaktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.draft_custo, Me.draft_faktur, Me.draft_sisa, Me.draft_sales})
        Me.dgv_draftfaktur.Location = New System.Drawing.Point(573, 157)
        Me.dgv_draftfaktur.Name = "dgv_draftfaktur"
        Me.dgv_draftfaktur.ReadOnly = True
        Me.dgv_draftfaktur.RowHeadersVisible = False
        Me.dgv_draftfaktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_draftfaktur.Size = New System.Drawing.Size(380, 192)
        Me.dgv_draftfaktur.StandardTab = True
        Me.dgv_draftfaktur.TabIndex = 15
        '
        'draft_custo
        '
        Me.draft_custo.DataPropertyName = "customer_nama"
        Me.draft_custo.HeaderText = "Customer"
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
        '
        'draft_sisa
        '
        Me.draft_sisa.DataPropertyName = "trans_harga_retur"
        Me.draft_sisa.HeaderText = "Sisa Tertagih"
        Me.draft_sisa.Name = "draft_sisa"
        Me.draft_sisa.ReadOnly = True
        Me.draft_sisa.Width = 130
        '
        'draft_sales
        '
        Me.draft_sales.HeaderText = "Salesman"
        Me.draft_sales.Name = "draft_sales"
        Me.draft_sales.ReadOnly = True
        Me.draft_sales.Width = 130
        '
        'bt_search2
        '
        Me.bt_search2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bt_search2.BackgroundImage = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.bt_search2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_search2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_search2.Location = New System.Drawing.Point(535, 79)
        Me.bt_search2.Name = "bt_search2"
        Me.bt_search2.Size = New System.Drawing.Size(42, 22)
        Me.bt_search2.TabIndex = 7
        Me.bt_search2.UseVisualStyleBackColor = False
        '
        'date_faktur_awal
        '
        Me.date_faktur_awal.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_faktur_awal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_faktur_awal.Location = New System.Drawing.Point(294, 79)
        Me.date_faktur_awal.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_faktur_awal.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_faktur_awal.Name = "date_faktur_awal"
        Me.date_faktur_awal.Size = New System.Drawing.Size(104, 22)
        Me.date_faktur_awal.TabIndex = 5
        '
        'date_faktur_akhir
        '
        Me.date_faktur_akhir.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_faktur_akhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_faktur_akhir.Location = New System.Drawing.Point(426, 79)
        Me.date_faktur_akhir.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_faktur_akhir.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_faktur_akhir.Name = "date_faktur_akhir"
        Me.date_faktur_akhir.Size = New System.Drawing.Size(104, 22)
        Me.date_faktur_akhir.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(400, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "s.d."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label13.Location = New System.Drawing.Point(12, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Faktur"
        '
        'in_cari_faktur
        '
        Me.in_cari_faktur.BackColor = System.Drawing.Color.White
        Me.in_cari_faktur.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari_faktur.ForeColor = System.Drawing.Color.Black
        Me.in_cari_faktur.Location = New System.Drawing.Point(81, 79)
        Me.in_cari_faktur.MaxLength = 255
        Me.in_cari_faktur.Name = "in_cari_faktur"
        Me.in_cari_faktur.Size = New System.Drawing.Size(207, 22)
        Me.in_cari_faktur.TabIndex = 4
        '
        'bt_faktur_all
        '
        Me.bt_faktur_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_faktur_all.Font = New System.Drawing.Font("Open Sans", 8.25!)
        Me.bt_faktur_all.Location = New System.Drawing.Point(459, 129)
        Me.bt_faktur_all.Name = "bt_faktur_all"
        Me.bt_faktur_all.Size = New System.Drawing.Size(81, 26)
        Me.bt_faktur_all.TabIndex = 11
        Me.bt_faktur_all.Text = "Pilih Semua"
        Me.bt_faktur_all.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_faktur_all.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(12, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Salesman"
        '
        'in_sales_n
        '
        Me.in_sales_n.BackColor = System.Drawing.Color.White
        Me.in_sales_n.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales_n.ForeColor = System.Drawing.Color.Black
        Me.in_sales_n.Location = New System.Drawing.Point(201, 47)
        Me.in_sales_n.MaxLength = 255
        Me.in_sales_n.Name = "in_sales_n"
        Me.in_sales_n.Size = New System.Drawing.Size(293, 22)
        Me.in_sales_n.TabIndex = 3
        '
        'in_sales
        '
        Me.in_sales.BackColor = System.Drawing.Color.WhiteSmoke
        Me.in_sales.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales.ForeColor = System.Drawing.Color.Black
        Me.in_sales.Location = New System.Drawing.Point(81, 47)
        Me.in_sales.MaxLength = 30
        Me.in_sales.Name = "in_sales"
        Me.in_sales.ReadOnly = True
        Me.in_sales.Size = New System.Drawing.Size(120, 22)
        Me.in_sales.TabIndex = 2
        Me.in_sales.TabStop = False
        '
        'in_kode_draft
        '
        Me.in_kode_draft.BackColor = System.Drawing.Color.White
        Me.in_kode_draft.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode_draft.ForeColor = System.Drawing.Color.Black
        Me.in_kode_draft.Location = New System.Drawing.Point(81, 7)
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
        Me.date_tgl_trans.Location = New System.Drawing.Point(330, 7)
        Me.date_tgl_trans.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_trans.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_trans.Name = "date_tgl_trans"
        Me.date_tgl_trans.Size = New System.Drawing.Size(164, 22)
        Me.date_tgl_trans.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(261, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tgl Tagihan"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 15)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "No.Tagihan"
        '
        'fr_draft_tagihan_det
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(960, 600)
        Me.Controls.Add(Me.Pnl_content)
        Me.Controls.Add(Me.pnl_footer)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_draft_tagihan_det"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Draft Tagihan Piutang/Penjualan"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.pnl_footer.ResumeLayout(False)
        Me.pnl_footer.PerformLayout()
        Me.Pnl_content.ResumeLayout(False)
        Me.Pnl_content.PerformLayout()
        Me.popPnl_barang.ResumeLayout(False)
        Me.popPnl_barang.PerformLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_detail_tagihan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_listfaktur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_draftfaktur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_cancelorder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnl_footer As System.Windows.Forms.Panel
    Friend WithEvents bt_simpanreturbeli As System.Windows.Forms.Button
    Friend WithEvents bt_batalreturbeli As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Pnl_content As System.Windows.Forms.Panel
    Friend WithEvents in_kode_draft As System.Windows.Forms.TextBox
    Friend WithEvents date_tgl_trans As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents in_sales_n As System.Windows.Forms.TextBox
    Friend WithEvents in_sales As System.Windows.Forms.TextBox
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents linkLbl_searchbarang As System.Windows.Forms.LinkLabel
    Friend WithEvents bt_search2 As System.Windows.Forms.Button
    Friend WithEvents date_faktur_awal As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_faktur_akhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents in_cari_faktur As System.Windows.Forms.TextBox
    Friend WithEvents bt_faktur_all As System.Windows.Forms.Button
    Friend WithEvents dgv_listfaktur As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_draftfaktur As System.Windows.Forms.DataGridView
    Friend WithEvents ck_hidepaid As System.Windows.Forms.CheckBox
    Friend WithEvents ck_tgl2 As System.Windows.Forms.CheckBox
    Friend WithEvents ck_tgl1 As System.Windows.Forms.CheckBox
    Friend WithEvents bt_remfaktur As System.Windows.Forms.Button
    Friend WithEvents bt_faktur_clear As System.Windows.Forms.Button
    Friend WithEvents bt_addfaktur As System.Windows.Forms.Button
    Friend WithEvents lbl_count_faktur As System.Windows.Forms.Label
    Friend WithEvents dgv_detail_tagihan As System.Windows.Forms.DataGridView
    Friend WithEvents hist_tanggal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hist_ket As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hist_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hist_debet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hist_kredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hist_saldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hist_tagihan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hist_filler As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents draft_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_sisa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents draft_sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_tanggal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_sisa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_temp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_pasar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_kec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_kab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents list_sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents in_printed As System.Windows.Forms.TextBox
End Class
