<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_jurnal_u_entry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_jurnal_u_entry))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.dgv_kas = New System.Windows.Forms.DataGridView()
        Me.kas_rek = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kas_rek_n = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kas_ket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kas_debet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kas_kredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_kredit_tot = New System.Windows.Forms.TextBox()
        Me.in_debet_tot = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.linkLbl_searchbarang = New System.Windows.Forms.LinkLabel()
        Me.bt_tbkas = New System.Windows.Forms.Button()
        Me.in_kredit = New System.Windows.Forms.NumericUpDown()
        Me.in_debet = New System.Windows.Forms.NumericUpDown()
        Me.in_rek = New System.Windows.Forms.TextBox()
        Me.in_rek_ket = New System.Windows.Forms.TextBox()
        Me.in_rek_n = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.cb_ppn = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.date_tglentry = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.in_selisih = New System.Windows.Forms.TextBox()
        Me.pnl_footer = New System.Windows.Forms.Panel()
        Me.bt_bataljual = New System.Windows.Forms.Button()
        Me.bt_simpanjual = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_other = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_duplicate = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_kas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_content.SuspendLayout()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_kredit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_debet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_footer.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 505)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(797, 10)
        Me.Panel2.TabIndex = 7
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
        Me.Panel1.Size = New System.Drawing.Size(797, 42)
        Me.Panel1.TabIndex = 7
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(717, 9)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(47, 20)
        Me.lbl_close.TabIndex = 0
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
        Me.bt_cl.Location = New System.Drawing.Point(770, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 7
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
        Me.lbl_title.Size = New System.Drawing.Size(229, 31)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Detail Jurnal Umum"
        '
        'dgv_kas
        '
        Me.dgv_kas.AllowUserToAddRows = False
        Me.dgv_kas.AllowUserToDeleteRows = False
        Me.dgv_kas.BackgroundColor = System.Drawing.Color.White
        Me.dgv_kas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_kas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kas_rek, Me.kas_rek_n, Me.kas_ket, Me.kas_debet, Me.kas_kredit})
        Me.dgv_kas.Location = New System.Drawing.Point(12, 124)
        Me.dgv_kas.Name = "dgv_kas"
        Me.dgv_kas.ReadOnly = True
        Me.dgv_kas.RowHeadersVisible = False
        Me.dgv_kas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_kas.Size = New System.Drawing.Size(760, 199)
        Me.dgv_kas.TabIndex = 10
        '
        'kas_rek
        '
        Me.kas_rek.DataPropertyName = "ju_akun"
        Me.kas_rek.HeaderText = "No. Rek"
        Me.kas_rek.Name = "kas_rek"
        Me.kas_rek.ReadOnly = True
        '
        'kas_rek_n
        '
        Me.kas_rek_n.DataPropertyName = "ju_akun_n"
        Me.kas_rek_n.HeaderText = "Nama Perkiraan"
        Me.kas_rek_n.Name = "kas_rek_n"
        Me.kas_rek_n.ReadOnly = True
        Me.kas_rek_n.Width = 180
        '
        'kas_ket
        '
        Me.kas_ket.DataPropertyName = "ju_akun_ket"
        Me.kas_ket.HeaderText = "Keterangan"
        Me.kas_ket.Name = "kas_ket"
        Me.kas_ket.ReadOnly = True
        Me.kas_ket.Width = 225
        '
        'kas_debet
        '
        Me.kas_debet.DataPropertyName = "ju_debet"
        Me.kas_debet.HeaderText = "Debet"
        Me.kas_debet.Name = "kas_debet"
        Me.kas_debet.ReadOnly = True
        Me.kas_debet.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.kas_debet.Width = 130
        '
        'kas_kredit
        '
        Me.kas_kredit.DataPropertyName = "ju_kredit"
        Me.kas_kredit.HeaderText = "Kredit"
        Me.kas_kredit.Name = "kas_kredit"
        Me.kas_kredit.ReadOnly = True
        Me.kas_kredit.Width = 130
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(542, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Kode"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Tgl"
        '
        'in_kredit_tot
        '
        Me.in_kredit_tot.BackColor = System.Drawing.Color.White
        Me.in_kredit_tot.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kredit_tot.ForeColor = System.Drawing.Color.Black
        Me.in_kredit_tot.Location = New System.Drawing.Point(592, 329)
        Me.in_kredit_tot.MaxLength = 150
        Me.in_kredit_tot.Name = "in_kredit_tot"
        Me.in_kredit_tot.ReadOnly = True
        Me.in_kredit_tot.Size = New System.Drawing.Size(180, 25)
        Me.in_kredit_tot.TabIndex = 12
        Me.in_kredit_tot.TabStop = False
        Me.in_kredit_tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_debet_tot
        '
        Me.in_debet_tot.BackColor = System.Drawing.Color.White
        Me.in_debet_tot.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_debet_tot.ForeColor = System.Drawing.Color.Black
        Me.in_debet_tot.Location = New System.Drawing.Point(351, 329)
        Me.in_debet_tot.MaxLength = 150
        Me.in_debet_tot.Name = "in_debet_tot"
        Me.in_debet_tot.ReadOnly = True
        Me.in_debet_tot.Size = New System.Drawing.Size(180, 25)
        Me.in_debet_tot.TabIndex = 11
        Me.in_debet_tot.TabStop = False
        Me.in_debet_tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label10.Location = New System.Drawing.Point(542, 332)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 18)
        Me.Label10.TabIndex = 384
        Me.Label10.Text = "Kredit"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(301, 332)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 18)
        Me.Label9.TabIndex = 385
        Me.Label9.Text = "Debet"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 426
        Me.Label3.Text = "Keterangan"
        '
        'pnl_content
        '
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.Controls.Add(Me.popPnl_barang)
        Me.pnl_content.Controls.Add(Me.dgv_kas)
        Me.pnl_content.Controls.Add(Me.bt_tbkas)
        Me.pnl_content.Controls.Add(Me.in_kredit)
        Me.pnl_content.Controls.Add(Me.in_debet)
        Me.pnl_content.Controls.Add(Me.in_rek)
        Me.pnl_content.Controls.Add(Me.in_rek_ket)
        Me.pnl_content.Controls.Add(Me.in_rek_n)
        Me.pnl_content.Controls.Add(Me.Label22)
        Me.pnl_content.Controls.Add(Me.Label8)
        Me.pnl_content.Controls.Add(Me.Label1)
        Me.pnl_content.Controls.Add(Me.Label16)
        Me.pnl_content.Controls.Add(Me.in_kode)
        Me.pnl_content.Controls.Add(Me.in_ket)
        Me.pnl_content.Controls.Add(Me.cb_ppn)
        Me.pnl_content.Controls.Add(Me.Label35)
        Me.pnl_content.Controls.Add(Me.Label29)
        Me.pnl_content.Controls.Add(Me.txtRegdate)
        Me.pnl_content.Controls.Add(Me.txtRegAlias)
        Me.pnl_content.Controls.Add(Me.Label28)
        Me.pnl_content.Controls.Add(Me.txtUpdAlias)
        Me.pnl_content.Controls.Add(Me.txtUpdDate)
        Me.pnl_content.Controls.Add(Me.Label30)
        Me.pnl_content.Controls.Add(Me.Label27)
        Me.pnl_content.Controls.Add(Me.date_tglentry)
        Me.pnl_content.Controls.Add(Me.Label6)
        Me.pnl_content.Controls.Add(Me.Label4)
        Me.pnl_content.Controls.Add(Me.Label3)
        Me.pnl_content.Controls.Add(Me.Label5)
        Me.pnl_content.Controls.Add(Me.Label7)
        Me.pnl_content.Controls.Add(Me.Label9)
        Me.pnl_content.Controls.Add(Me.Label10)
        Me.pnl_content.Controls.Add(Me.in_selisih)
        Me.pnl_content.Controls.Add(Me.in_debet_tot)
        Me.pnl_content.Controls.Add(Me.in_kredit_tot)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_content.Location = New System.Drawing.Point(0, 66)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(797, 391)
        Me.pnl_content.TabIndex = 0
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Controls.Add(Me.linkLbl_searchbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(184, 148)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(347, 135)
        Me.popPnl_barang.TabIndex = 429
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
        Me.dgv_listbarang.Size = New System.Drawing.Size(347, 132)
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
        'bt_tbkas
        '
        Me.bt_tbkas.BackColor = System.Drawing.Color.Transparent
        Me.bt_tbkas.BackgroundImage = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.bt_tbkas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_tbkas.FlatAppearance.BorderSize = 0
        Me.bt_tbkas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_tbkas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tbkas.Location = New System.Drawing.Point(750, 102)
        Me.bt_tbkas.Name = "bt_tbkas"
        Me.bt_tbkas.Size = New System.Drawing.Size(17, 17)
        Me.bt_tbkas.TabIndex = 9
        Me.bt_tbkas.UseVisualStyleBackColor = False
        '
        'in_kredit
        '
        Me.in_kredit.DecimalPlaces = 2
        Me.in_kredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kredit.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.in_kredit.Location = New System.Drawing.Point(617, 100)
        Me.in_kredit.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.in_kredit.Name = "in_kredit"
        Me.in_kredit.Size = New System.Drawing.Size(129, 20)
        Me.in_kredit.TabIndex = 8
        Me.in_kredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_kredit.ThousandsSeparator = True
        '
        'in_debet
        '
        Me.in_debet.DecimalPlaces = 2
        Me.in_debet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_debet.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.in_debet.Location = New System.Drawing.Point(487, 100)
        Me.in_debet.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.in_debet.Name = "in_debet"
        Me.in_debet.Size = New System.Drawing.Size(129, 20)
        Me.in_debet.TabIndex = 7
        Me.in_debet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_debet.ThousandsSeparator = True
        '
        'in_rek
        '
        Me.in_rek.BackColor = System.Drawing.Color.White
        Me.in_rek.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_rek.ForeColor = System.Drawing.Color.Black
        Me.in_rek.Location = New System.Drawing.Point(12, 100)
        Me.in_rek.MaxLength = 150
        Me.in_rek.Name = "in_rek"
        Me.in_rek.ReadOnly = True
        Me.in_rek.Size = New System.Drawing.Size(91, 20)
        Me.in_rek.TabIndex = 4
        '
        'in_rek_ket
        '
        Me.in_rek_ket.BackColor = System.Drawing.Color.White
        Me.in_rek_ket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_rek_ket.ForeColor = System.Drawing.Color.Black
        Me.in_rek_ket.Location = New System.Drawing.Point(286, 100)
        Me.in_rek_ket.MaxLength = 150
        Me.in_rek_ket.Name = "in_rek_ket"
        Me.in_rek_ket.Size = New System.Drawing.Size(199, 20)
        Me.in_rek_ket.TabIndex = 6
        '
        'in_rek_n
        '
        Me.in_rek_n.BackColor = System.Drawing.Color.White
        Me.in_rek_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_rek_n.ForeColor = System.Drawing.Color.Black
        Me.in_rek_n.Location = New System.Drawing.Point(103, 100)
        Me.in_rek_n.MaxLength = 150
        Me.in_rek_n.Name = "in_rek_n"
        Me.in_rek_n.Size = New System.Drawing.Size(181, 20)
        Me.in_rek_n.TabIndex = 5
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label22.Location = New System.Drawing.Point(615, 85)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 13)
        Me.Label22.TabIndex = 447
        Me.Label22.Text = "Kredit"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(283, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 448
        Me.Label8.Text = "Keterangan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(484, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 449
        Me.Label1.Text = "Debet"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(9, 85)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(94, 13)
        Me.Label16.TabIndex = 450
        Me.Label16.Text = "Kode Perkiraan"
        '
        'in_kode
        '
        Me.in_kode.Location = New System.Drawing.Point(592, 5)
        Me.in_kode.MaxLength = 100
        Me.in_kode.Name = "in_kode"
        Me.in_kode.ReadOnly = True
        Me.in_kode.Size = New System.Drawing.Size(180, 22)
        Me.in_kode.TabIndex = 0
        '
        'in_ket
        '
        Me.in_ket.Location = New System.Drawing.Point(91, 55)
        Me.in_ket.MaxLength = 255
        Me.in_ket.Name = "in_ket"
        Me.in_ket.Size = New System.Drawing.Size(394, 22)
        Me.in_ket.TabIndex = 3
        '
        'cb_ppn
        '
        Me.cb_ppn.FormattingEnabled = True
        Me.cb_ppn.Location = New System.Drawing.Point(91, 29)
        Me.cb_ppn.Name = "cb_ppn"
        Me.cb_ppn.Size = New System.Drawing.Size(121, 23)
        Me.cb_ppn.TabIndex = 2
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.Label35.Location = New System.Drawing.Point(435, 435)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(28, 31)
        Me.Label35.TabIndex = 440
        Me.Label35.Text = "  "
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(9, 417)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(43, 13)
        Me.Label29.TabIndex = 435
        Me.Label29.Text = "Inputed"
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(76, 414)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(177, 20)
        Me.txtRegdate.TabIndex = 432
        Me.txtRegdate.TabStop = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(281, 414)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(130, 20)
        Me.txtRegAlias.TabIndex = 434
        Me.txtRegAlias.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(9, 439)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(62, 13)
        Me.Label28.TabIndex = 439
        Me.Label28.Text = "LastUpdate"
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(281, 435)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(130, 20)
        Me.txtUpdAlias.TabIndex = 437
        Me.txtUpdAlias.TabStop = False
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(76, 435)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(177, 20)
        Me.txtUpdDate.TabIndex = 433
        Me.txtUpdDate.TabStop = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(258, 439)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(19, 13)
        Me.Label30.TabIndex = 438
        Me.Label30.Text = "By"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(258, 418)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(19, 13)
        Me.Label27.TabIndex = 436
        Me.Label27.Text = "By"
        '
        'date_tglentry
        '
        Me.date_tglentry.Location = New System.Drawing.Point(91, 5)
        Me.date_tglentry.Name = "date_tglentry"
        Me.date_tglentry.Size = New System.Drawing.Size(173, 22)
        Me.date_tglentry.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 428
        Me.Label6.Text = "Kateg."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(542, 363)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 18)
        Me.Label7.TabIndex = 385
        Me.Label7.Text = "Selisih"
        '
        'in_selisih
        '
        Me.in_selisih.BackColor = System.Drawing.Color.White
        Me.in_selisih.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_selisih.ForeColor = System.Drawing.Color.Black
        Me.in_selisih.Location = New System.Drawing.Point(592, 360)
        Me.in_selisih.MaxLength = 150
        Me.in_selisih.Name = "in_selisih"
        Me.in_selisih.ReadOnly = True
        Me.in_selisih.Size = New System.Drawing.Size(180, 25)
        Me.in_selisih.TabIndex = 13
        Me.in_selisih.TabStop = False
        Me.in_selisih.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnl_footer
        '
        Me.pnl_footer.AutoScroll = True
        Me.pnl_footer.BackColor = System.Drawing.Color.Gainsboro
        Me.pnl_footer.Controls.Add(Me.bt_bataljual)
        Me.pnl_footer.Controls.Add(Me.bt_simpanjual)
        Me.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_footer.Location = New System.Drawing.Point(0, 457)
        Me.pnl_footer.Name = "pnl_footer"
        Me.pnl_footer.Size = New System.Drawing.Size(797, 48)
        Me.pnl_footer.TabIndex = 432
        '
        'bt_bataljual
        '
        Me.bt_bataljual.BackColor = System.Drawing.Color.Tomato
        Me.bt_bataljual.FlatAppearance.BorderSize = 0
        Me.bt_bataljual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_bataljual.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_bataljual.ForeColor = System.Drawing.Color.White
        Me.bt_bataljual.Location = New System.Drawing.Point(694, 10)
        Me.bt_bataljual.Name = "bt_bataljual"
        Me.bt_bataljual.Size = New System.Drawing.Size(96, 30)
        Me.bt_bataljual.TabIndex = 336
        Me.bt_bataljual.Text = "Batal"
        Me.bt_bataljual.UseVisualStyleBackColor = False
        '
        'bt_simpanjual
        '
        Me.bt_simpanjual.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpanjual.FlatAppearance.BorderSize = 0
        Me.bt_simpanjual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpanjual.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanjual.ForeColor = System.Drawing.Color.White
        Me.bt_simpanjual.Location = New System.Drawing.Point(536, 10)
        Me.bt_simpanjual.Name = "bt_simpanjual"
        Me.bt_simpanjual.Size = New System.Drawing.Size(152, 30)
        Me.bt_simpanjual.TabIndex = 35
        Me.bt_simpanjual.Text = "Simpan"
        Me.bt_simpanjual.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_other})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 42)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(797, 24)
        Me.MenuStrip1.TabIndex = 433
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
        'mn_other
        '
        Me.mn_other.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_delete, Me.mn_duplicate})
        Me.mn_other.Name = "mn_other"
        Me.mn_other.Size = New System.Drawing.Size(68, 20)
        Me.mn_other.Text = "Lain-Lain"
        '
        'mn_delete
        '
        Me.mn_delete.Name = "mn_delete"
        Me.mn_delete.Size = New System.Drawing.Size(154, 22)
        Me.mn_delete.Text = "Hapus Entry"
        '
        'mn_duplicate
        '
        Me.mn_duplicate.Name = "mn_duplicate"
        Me.mn_duplicate.Size = New System.Drawing.Size(154, 22)
        Me.mn_duplicate.Text = "Duplicate Entry"
        Me.mn_duplicate.Visible = False
        '
        'fr_jurnal_u_entry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(797, 515)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.pnl_footer)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_jurnal_u_entry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entry Jurnal Umum : "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv_kas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.popPnl_barang.ResumeLayout(False)
        Me.popPnl_barang.PerformLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_kredit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_debet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_footer.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents dgv_kas As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_kredit_tot As System.Windows.Forms.TextBox
    Friend WithEvents in_debet_tot As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents in_selisih As System.Windows.Forms.TextBox
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents linkLbl_searchbarang As System.Windows.Forms.LinkLabel
    Friend WithEvents date_tglentry As System.Windows.Forms.DateTimePicker
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
    Friend WithEvents cb_ppn As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents pnl_footer As System.Windows.Forms.Panel
    Friend WithEvents bt_bataljual As System.Windows.Forms.Button
    Friend WithEvents bt_simpanjual As System.Windows.Forms.Button
    Friend WithEvents bt_tbkas As System.Windows.Forms.Button
    Friend WithEvents in_kredit As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_debet As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_rek As System.Windows.Forms.TextBox
    Friend WithEvents in_rek_ket As System.Windows.Forms.TextBox
    Friend WithEvents in_rek_n As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents kas_rek As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kas_rek_n As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kas_ket As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kas_debet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kas_kredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_other As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_duplicate As System.Windows.Forms.ToolStripMenuItem
End Class
