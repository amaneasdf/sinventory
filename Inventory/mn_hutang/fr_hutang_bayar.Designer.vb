<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_hutang_bayar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_hutang_bayar))
        Me.pnl_Menu = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_print = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_proses = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.bt_batalperkiraan = New System.Windows.Forms.Button()
        Me.bt_simpanperkiraan = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_no_bukti = New System.Windows.Forms.TextBox()
        Me.date_tgl_trans = New System.Windows.Forms.DateTimePicker()
        Me.in_supplier = New System.Windows.Forms.TextBox()
        Me.in_faktur = New System.Windows.Forms.TextBox()
        Me.dgv_bayar = New System.Windows.Forms.DataGridView()
        Me.bayar_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bayar_jt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bayar_saldoawal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bayar_sisahutang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bayar_kredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.date_bg_tgl = New System.Windows.Forms.DateTimePicker()
        Me.cb_bayar = New System.Windows.Forms.ComboBox()
        Me.in_kredit = New System.Windows.Forms.NumericUpDown()
        Me.in_supplier_n = New System.Windows.Forms.TextBox()
        Me.bt_tbbayar = New System.Windows.Forms.Button()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.linkLbl_searchbarang = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.in_total = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.in_sisafaktur = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.in_tgl_jtfaktur = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cb_akun = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.in_potongan = New System.Windows.Forms.NumericUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.in_tglpencairan = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.in_no_bg = New System.Windows.Forms.TextBox()
        Me.in_saldotitipan = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnl_Menu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_bayar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_kredit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_potongan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_Menu
        '
        Me.pnl_Menu.Controls.Add(Me.MenuStrip1)
        Me.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Menu.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Menu.Name = "pnl_Menu"
        Me.pnl_Menu.Size = New System.Drawing.Size(901, 28)
        Me.pnl_Menu.TabIndex = 277
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_delete, Me.mn_print, Me.mn_proses})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(901, 24)
        Me.MenuStrip1.TabIndex = 183
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
        'mn_delete
        '
        Me.mn_delete.Name = "mn_delete"
        Me.mn_delete.Size = New System.Drawing.Size(52, 20)
        Me.mn_delete.Text = "Delete"
        Me.mn_delete.Visible = False
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
        'mn_proses
        '
        Me.mn_proses.Image = Global.Inventory.My.Resources.Resources.toolbar_cancel_icon
        Me.mn_proses.Name = "mn_proses"
        Me.mn_proses.Size = New System.Drawing.Size(69, 20)
        Me.mn_proses.Text = "P&roses"
        Me.mn_proses.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.mn_proses.Visible = False
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
        Me.Panel1.Size = New System.Drawing.Size(901, 42)
        Me.Panel1.TabIndex = 276
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(821, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(874, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 20
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
        Me.lbl_title.Size = New System.Drawing.Size(295, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Form Pembayaran Hutang"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 534)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(901, 10)
        Me.Panel2.TabIndex = 342
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(229, 465)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 13)
        Me.Label30.TabIndex = 351
        Me.Label30.Text = "Date"
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(270, 440)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtUpdAlias.TabIndex = 350
        Me.txtUpdAlias.TabStop = False
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(270, 462)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(150, 20)
        Me.txtUpdDate.TabIndex = 345
        Me.txtUpdDate.TabStop = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(50, 440)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtRegAlias.TabIndex = 347
        Me.txtRegAlias.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(229, 443)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(39, 13)
        Me.Label28.TabIndex = 352
        Me.Label28.Text = "UpdBy"
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(50, 462)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(150, 20)
        Me.txtRegdate.TabIndex = 346
        Me.txtRegdate.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(9, 443)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(39, 13)
        Me.Label27.TabIndex = 349
        Me.Label27.Text = "RegBy"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(9, 465)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(30, 13)
        Me.Label29.TabIndex = 348
        Me.Label29.Text = "Date"
        '
        'bt_batalperkiraan
        '
        Me.bt_batalperkiraan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_batalperkiraan.BackColor = System.Drawing.Color.Transparent
        Me.bt_batalperkiraan.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalperkiraan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalperkiraan.ForeColor = System.Drawing.Color.Black
        Me.bt_batalperkiraan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_batalperkiraan.Location = New System.Drawing.Point(793, 456)
        Me.bt_batalperkiraan.Name = "bt_batalperkiraan"
        Me.bt_batalperkiraan.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalperkiraan.TabIndex = 20
        Me.bt_batalperkiraan.Text = "Batal"
        Me.bt_batalperkiraan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_batalperkiraan.UseVisualStyleBackColor = False
        '
        'bt_simpanperkiraan
        '
        Me.bt_simpanperkiraan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_simpanperkiraan.BackColor = System.Drawing.Color.Transparent
        Me.bt_simpanperkiraan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanperkiraan.ForeColor = System.Drawing.Color.Black
        Me.bt_simpanperkiraan.Location = New System.Drawing.Point(627, 456)
        Me.bt_simpanperkiraan.Name = "bt_simpanperkiraan"
        Me.bt_simpanperkiraan.Size = New System.Drawing.Size(160, 30)
        Me.bt_simpanperkiraan.TabIndex = 19
        Me.bt_simpanperkiraan.Text = "Simpan Pembayaran"
        Me.bt_simpanperkiraan.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 356
        Me.Label7.Text = "Supplier"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(662, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 358
        Me.Label4.Text = "No. Bukti"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 357
        Me.Label1.Text = "Jenis Bayar"
        '
        'in_no_bukti
        '
        Me.in_no_bukti.BackColor = System.Drawing.Color.White
        Me.in_no_bukti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_no_bukti.ForeColor = System.Drawing.Color.Black
        Me.in_no_bukti.Location = New System.Drawing.Point(721, 34)
        Me.in_no_bukti.MaxLength = 30
        Me.in_no_bukti.Name = "in_no_bukti"
        Me.in_no_bukti.ReadOnly = True
        Me.in_no_bukti.Size = New System.Drawing.Size(168, 20)
        Me.in_no_bukti.TabIndex = 2
        Me.in_no_bukti.TabStop = False
        '
        'date_tgl_trans
        '
        Me.date_tgl_trans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_trans.Location = New System.Drawing.Point(81, 103)
        Me.date_tgl_trans.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_trans.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_trans.Name = "date_tgl_trans"
        Me.date_tgl_trans.Size = New System.Drawing.Size(188, 20)
        Me.date_tgl_trans.TabIndex = 6
        '
        'in_supplier
        '
        Me.in_supplier.BackColor = System.Drawing.Color.White
        Me.in_supplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier.ForeColor = System.Drawing.Color.Black
        Me.in_supplier.Location = New System.Drawing.Point(81, 33)
        Me.in_supplier.MaxLength = 30
        Me.in_supplier.Name = "in_supplier"
        Me.in_supplier.ReadOnly = True
        Me.in_supplier.Size = New System.Drawing.Size(135, 20)
        Me.in_supplier.TabIndex = 0
        '
        'in_faktur
        '
        Me.in_faktur.BackColor = System.Drawing.Color.White
        Me.in_faktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_faktur.ForeColor = System.Drawing.Color.Black
        Me.in_faktur.Location = New System.Drawing.Point(14, 156)
        Me.in_faktur.MaxLength = 30
        Me.in_faktur.Name = "in_faktur"
        Me.in_faktur.Size = New System.Drawing.Size(206, 20)
        Me.in_faktur.TabIndex = 8
        '
        'dgv_bayar
        '
        Me.dgv_bayar.AllowUserToAddRows = False
        Me.dgv_bayar.AllowUserToDeleteRows = False
        Me.dgv_bayar.BackgroundColor = System.Drawing.Color.White
        Me.dgv_bayar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_bayar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.bayar_faktur, Me.bayar_jt, Me.bayar_saldoawal, Me.bayar_sisahutang, Me.bayar_kredit})
        Me.dgv_bayar.Location = New System.Drawing.Point(12, 182)
        Me.dgv_bayar.Name = "dgv_bayar"
        Me.dgv_bayar.ReadOnly = True
        Me.dgv_bayar.RowHeadersVisible = False
        Me.dgv_bayar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_bayar.Size = New System.Drawing.Size(877, 144)
        Me.dgv_bayar.TabIndex = 13
        '
        'bayar_faktur
        '
        Me.bayar_faktur.HeaderText = "No.Faktur"
        Me.bayar_faktur.Name = "bayar_faktur"
        Me.bayar_faktur.ReadOnly = True
        Me.bayar_faktur.Width = 175
        '
        'bayar_jt
        '
        Me.bayar_jt.HeaderText = "Jatuh Tempo"
        Me.bayar_jt.MinimumWidth = 50
        Me.bayar_jt.Name = "bayar_jt"
        Me.bayar_jt.ReadOnly = True
        '
        'bayar_saldoawal
        '
        Me.bayar_saldoawal.HeaderText = "Total Hutang"
        Me.bayar_saldoawal.MinimumWidth = 100
        Me.bayar_saldoawal.Name = "bayar_saldoawal"
        Me.bayar_saldoawal.ReadOnly = True
        Me.bayar_saldoawal.Width = 150
        '
        'bayar_sisahutang
        '
        Me.bayar_sisahutang.HeaderText = "Sisa Hutang"
        Me.bayar_sisahutang.MinimumWidth = 100
        Me.bayar_sisahutang.Name = "bayar_sisahutang"
        Me.bayar_sisahutang.ReadOnly = True
        Me.bayar_sisahutang.Width = 150
        '
        'bayar_kredit
        '
        Me.bayar_kredit.DataPropertyName = "trans_kredit"
        Me.bayar_kredit.HeaderText = "Nilai Bayar"
        Me.bayar_kredit.MinimumWidth = 150
        Me.bayar_kredit.Name = "bayar_kredit"
        Me.bayar_kredit.ReadOnly = True
        Me.bayar_kredit.Width = 150
        '
        'date_bg_tgl
        '
        Me.date_bg_tgl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_bg_tgl.Location = New System.Drawing.Point(365, 103)
        Me.date_bg_tgl.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.date_bg_tgl.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_bg_tgl.Name = "date_bg_tgl"
        Me.date_bg_tgl.Size = New System.Drawing.Size(188, 20)
        Me.date_bg_tgl.TabIndex = 7
        '
        'cb_bayar
        '
        Me.cb_bayar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cb_bayar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_bayar.FormattingEnabled = True
        Me.cb_bayar.Items.AddRange(New Object() {"ii", "ooo", "eeee"})
        Me.cb_bayar.Location = New System.Drawing.Point(81, 79)
        Me.cb_bayar.Name = "cb_bayar"
        Me.cb_bayar.Size = New System.Drawing.Size(188, 21)
        Me.cb_bayar.TabIndex = 4
        '
        'in_kredit
        '
        Me.in_kredit.DecimalPlaces = 2
        Me.in_kredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kredit.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.in_kredit.Location = New System.Drawing.Point(593, 156)
        Me.in_kredit.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.in_kredit.Name = "in_kredit"
        Me.in_kredit.Size = New System.Drawing.Size(161, 20)
        Me.in_kredit.TabIndex = 11
        Me.in_kredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_kredit.ThousandsSeparator = True
        '
        'in_supplier_n
        '
        Me.in_supplier_n.BackColor = System.Drawing.Color.White
        Me.in_supplier_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier_n.ForeColor = System.Drawing.Color.Black
        Me.in_supplier_n.Location = New System.Drawing.Point(217, 33)
        Me.in_supplier_n.MaxLength = 255
        Me.in_supplier_n.Name = "in_supplier_n"
        Me.in_supplier_n.Size = New System.Drawing.Size(390, 20)
        Me.in_supplier_n.TabIndex = 1
        '
        'bt_tbbayar
        '
        Me.bt_tbbayar.BackColor = System.Drawing.Color.Transparent
        Me.bt_tbbayar.BackgroundImage = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.bt_tbbayar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_tbbayar.FlatAppearance.BorderSize = 0
        Me.bt_tbbayar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_tbbayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tbbayar.Location = New System.Drawing.Point(760, 157)
        Me.bt_tbbayar.Name = "bt_tbbayar"
        Me.bt_tbbayar.Size = New System.Drawing.Size(18, 18)
        Me.bt_tbbayar.TabIndex = 12
        Me.bt_tbbayar.UseVisualStyleBackColor = False
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Controls.Add(Me.linkLbl_searchbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(411, 198)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(389, 135)
        Me.popPnl_barang.TabIndex = 366
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
        Me.dgv_listbarang.Size = New System.Drawing.Size(389, 127)
        Me.dgv_listbarang.TabIndex = 0
        '
        'linkLbl_searchbarang
        '
        Me.linkLbl_searchbarang.AutoSize = True
        Me.linkLbl_searchbarang.LinkColor = System.Drawing.Color.DimGray
        Me.linkLbl_searchbarang.Location = New System.Drawing.Point(3, 114)
        Me.linkLbl_searchbarang.Name = "linkLbl_searchbarang"
        Me.linkLbl_searchbarang.Size = New System.Drawing.Size(116, 13)
        Me.linkLbl_searchbarang.TabIndex = 1
        Me.linkLbl_searchbarang.TabStop = True
        Me.linkLbl_searchbarang.Text = "Tampilkan Pencarian..."
        Me.linkLbl_searchbarang.VisitedLinkColor = System.Drawing.Color.DimGray
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(592, 141)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 367
        Me.Label3.Text = "Nilai Bayar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(11, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 368
        Me.Label2.Text = "Faktur"
        '
        'in_ket
        '
        Me.in_ket.BackColor = System.Drawing.Color.White
        Me.in_ket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.ForeColor = System.Drawing.Color.Black
        Me.in_ket.Location = New System.Drawing.Point(55, 363)
        Me.in_ket.MaxLength = 30
        Me.in_ket.Multiline = True
        Me.in_ket.Name = "in_ket"
        Me.in_ket.Size = New System.Drawing.Size(382, 60)
        Me.in_ket.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label10.Location = New System.Drawing.Point(10, 366)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 368
        Me.Label10.Text = "Memo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.Location = New System.Drawing.Point(520, 336)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 13)
        Me.Label6.TabIndex = 368
        Me.Label6.Text = "Total Pembayaran"
        '
        'in_total
        '
        Me.in_total.BackColor = System.Drawing.Color.White
        Me.in_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_total.ForeColor = System.Drawing.Color.Black
        Me.in_total.Location = New System.Drawing.Point(632, 333)
        Me.in_total.MaxLength = 50
        Me.in_total.Name = "in_total"
        Me.in_total.ReadOnly = True
        Me.in_total.Size = New System.Drawing.Size(257, 26)
        Me.in_total.TabIndex = 18
        Me.in_total.TabStop = False
        Me.in_total.Text = "0"
        Me.in_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 107)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 357
        Me.Label9.Text = "Tgl.Bayar"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(275, 107)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 13)
        Me.Label11.TabIndex = 357
        Me.Label11.Text = "Tgl.JatuhTempo"
        '
        'in_sisafaktur
        '
        Me.in_sisafaktur.BackColor = System.Drawing.Color.White
        Me.in_sisafaktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sisafaktur.ForeColor = System.Drawing.Color.Black
        Me.in_sisafaktur.Location = New System.Drawing.Point(392, 156)
        Me.in_sisafaktur.MaxLength = 30
        Me.in_sisafaktur.Name = "in_sisafaktur"
        Me.in_sisafaktur.ReadOnly = True
        Me.in_sisafaktur.Size = New System.Drawing.Size(195, 20)
        Me.in_sisafaktur.TabIndex = 10
        Me.in_sisafaktur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(389, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 368
        Me.Label8.Text = "Sisa"
        '
        'in_tgl_jtfaktur
        '
        Me.in_tgl_jtfaktur.BackColor = System.Drawing.Color.White
        Me.in_tgl_jtfaktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_tgl_jtfaktur.ForeColor = System.Drawing.Color.Black
        Me.in_tgl_jtfaktur.Location = New System.Drawing.Point(223, 156)
        Me.in_tgl_jtfaktur.MaxLength = 30
        Me.in_tgl_jtfaktur.Name = "in_tgl_jtfaktur"
        Me.in_tgl_jtfaktur.ReadOnly = True
        Me.in_tgl_jtfaktur.Size = New System.Drawing.Size(165, 20)
        Me.in_tgl_jtfaktur.TabIndex = 9
        Me.in_tgl_jtfaktur.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(220, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 370
        Me.Label5.Text = "Jatuh Tempo"
        '
        'cb_akun
        '
        Me.cb_akun.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cb_akun.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_akun.FormattingEnabled = True
        Me.cb_akun.Items.AddRange(New Object() {"ii", "ooo", "eeee"})
        Me.cb_akun.Location = New System.Drawing.Point(365, 79)
        Me.cb_akun.Name = "cb_akun"
        Me.cb_akun.Size = New System.Drawing.Size(188, 21)
        Me.cb_akun.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(275, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 373
        Me.Label12.Text = "Bayar Dari"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label13.Location = New System.Drawing.Point(520, 405)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 13)
        Me.Label13.TabIndex = 374
        Me.Label13.Text = "Pemotongan"
        Me.Label13.Visible = False
        '
        'in_potongan
        '
        Me.in_potongan.DecimalPlaces = 2
        Me.in_potongan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_potongan.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.in_potongan.Location = New System.Drawing.Point(632, 403)
        Me.in_potongan.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.in_potongan.Name = "in_potongan"
        Me.in_potongan.Size = New System.Drawing.Size(257, 20)
        Me.in_potongan.TabIndex = 17
        Me.in_potongan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_potongan.ThousandsSeparator = True
        Me.in_potongan.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label14.Location = New System.Drawing.Point(9, 336)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 376
        Me.Label14.Text = "No.BG"
        '
        'in_tglpencairan
        '
        Me.in_tglpencairan.BackColor = System.Drawing.Color.White
        Me.in_tglpencairan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_tglpencairan.ForeColor = System.Drawing.Color.Black
        Me.in_tglpencairan.Location = New System.Drawing.Point(272, 332)
        Me.in_tglpencairan.MaxLength = 30
        Me.in_tglpencairan.Name = "in_tglpencairan"
        Me.in_tglpencairan.ReadOnly = True
        Me.in_tglpencairan.Size = New System.Drawing.Size(165, 20)
        Me.in_tglpencairan.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label15.Location = New System.Drawing.Point(223, 336)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 13)
        Me.Label15.TabIndex = 378
        Me.Label15.Text = "Tgl.Cair"
        '
        'in_no_bg
        '
        Me.in_no_bg.BackColor = System.Drawing.Color.White
        Me.in_no_bg.Enabled = False
        Me.in_no_bg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_no_bg.ForeColor = System.Drawing.Color.Black
        Me.in_no_bg.Location = New System.Drawing.Point(55, 333)
        Me.in_no_bg.MaxLength = 30
        Me.in_no_bg.Name = "in_no_bg"
        Me.in_no_bg.Size = New System.Drawing.Size(165, 20)
        Me.in_no_bg.TabIndex = 14
        '
        'in_saldotitipan
        '
        Me.in_saldotitipan.BackColor = System.Drawing.Color.White
        Me.in_saldotitipan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_saldotitipan.ForeColor = System.Drawing.Color.Black
        Me.in_saldotitipan.Location = New System.Drawing.Point(81, 56)
        Me.in_saldotitipan.MaxLength = 30
        Me.in_saldotitipan.Name = "in_saldotitipan"
        Me.in_saldotitipan.Size = New System.Drawing.Size(278, 20)
        Me.in_saldotitipan.TabIndex = 3
        Me.in_saldotitipan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(9, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 13)
        Me.Label16.TabIndex = 380
        Me.Label16.Text = "Saldo Titipan"
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label30)
        Me.Panel3.Controls.Add(Me.pnl_Menu)
        Me.Panel3.Controls.Add(Me.popPnl_barang)
        Me.Panel3.Controls.Add(Me.txtUpdAlias)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtUpdDate)
        Me.Panel3.Controls.Add(Me.in_saldotitipan)
        Me.Panel3.Controls.Add(Me.txtRegAlias)
        Me.Panel3.Controls.Add(Me.date_tgl_trans)
        Me.Panel3.Controls.Add(Me.Label28)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.txtRegdate)
        Me.Panel3.Controls.Add(Me.date_bg_tgl)
        Me.Panel3.Controls.Add(Me.Label27)
        Me.Panel3.Controls.Add(Me.in_no_bg)
        Me.Panel3.Controls.Add(Me.Label29)
        Me.Panel3.Controls.Add(Me.bt_batalperkiraan)
        Me.Panel3.Controls.Add(Me.in_no_bukti)
        Me.Panel3.Controls.Add(Me.bt_simpanperkiraan)
        Me.Panel3.Controls.Add(Me.in_tglpencairan)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.in_potongan)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.in_supplier)
        Me.Panel3.Controls.Add(Me.cb_akun)
        Me.Panel3.Controls.Add(Me.in_total)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.in_supplier_n)
        Me.Panel3.Controls.Add(Me.in_tgl_jtfaktur)
        Me.Panel3.Controls.Add(Me.in_ket)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.in_faktur)
        Me.Panel3.Controls.Add(Me.in_sisafaktur)
        Me.Panel3.Controls.Add(Me.in_kredit)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.dgv_bayar)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.cb_bayar)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.bt_tbbayar)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 42)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(901, 492)
        Me.Panel3.TabIndex = 381
        '
        'fr_hutang_bayar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.bt_batalperkiraan
        Me.ClientSize = New System.Drawing.Size(901, 544)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_hutang_bayar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pembayaran Hutang : "
        Me.pnl_Menu.ResumeLayout(False)
        Me.pnl_Menu.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv_bayar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_kredit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popPnl_barang.ResumeLayout(False)
        Me.popPnl_barang.PerformLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_potongan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_Menu As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_proses As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents bt_batalperkiraan As System.Windows.Forms.Button
    Friend WithEvents bt_simpanperkiraan As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_no_bukti As System.Windows.Forms.TextBox
    Friend WithEvents date_tgl_trans As System.Windows.Forms.DateTimePicker
    Friend WithEvents in_supplier As System.Windows.Forms.TextBox
    Friend WithEvents in_faktur As System.Windows.Forms.TextBox
    Friend WithEvents dgv_bayar As System.Windows.Forms.DataGridView
    Friend WithEvents date_bg_tgl As System.Windows.Forms.DateTimePicker
    Friend WithEvents cb_bayar As System.Windows.Forms.ComboBox
    Friend WithEvents in_kredit As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_supplier_n As System.Windows.Forms.TextBox
    Friend WithEvents bt_tbbayar As System.Windows.Forms.Button
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents linkLbl_searchbarang As System.Windows.Forms.LinkLabel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents in_total As System.Windows.Forms.TextBox
    Friend WithEvents bayar_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bayar_jt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bayar_saldoawal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bayar_sisahutang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bayar_kredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents in_sisafaktur As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents in_tgl_jtfaktur As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cb_akun As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents in_potongan As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents in_tglpencairan As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents in_no_bg As System.Windows.Forms.TextBox
    Friend WithEvents in_saldotitipan As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
