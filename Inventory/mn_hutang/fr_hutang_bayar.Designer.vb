﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.bt_supplier_list = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_no_bukti = New System.Windows.Forms.TextBox()
        Me.date_tgl_trans = New System.Windows.Forms.DateTimePicker()
        Me.in_supplier = New System.Windows.Forms.TextBox()
        Me.dgv_faktur = New System.Windows.Forms.DataGridView()
        Me.faktur_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_debet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_faktur = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.in_bg_no = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dgv_bayar = New System.Windows.Forms.DataGridView()
        Me.bayar_kodebayar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bayar_bgno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bayar_bank = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bayar_debet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bayar_kredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bayar_bgtgl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.date_bg_tgl = New System.Windows.Forms.DateTimePicker()
        Me.cb_bank = New System.Windows.Forms.ComboBox()
        Me.cb_bayar = New System.Windows.Forms.ComboBox()
        Me.in_kredit = New System.Windows.Forms.NumericUpDown()
        Me.in_supplier_n = New System.Windows.Forms.TextBox()
        Me.bt_tbbayar = New System.Windows.Forms.Button()
        Me.bt_faktur_add = New System.Windows.Forms.Button()
        Me.in_faktur_debet = New System.Windows.Forms.NumericUpDown()
        Me.in_debet = New System.Windows.Forms.TextBox()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.linkLbl_searchbarang = New System.Windows.Forms.LinkLabel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.in_sisa_hutang = New System.Windows.Forms.TextBox()
        Me.in_total_deb = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.in_total_kre = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.in_total_sel = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnl_Menu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_faktur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_bayar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_kredit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_faktur_debet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_Menu
        '
        Me.pnl_Menu.Controls.Add(Me.MenuStrip1)
        Me.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Menu.Location = New System.Drawing.Point(0, 42)
        Me.pnl_Menu.Name = "pnl_Menu"
        Me.pnl_Menu.Size = New System.Drawing.Size(901, 32)
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
        Me.lbl_title.Size = New System.Drawing.Size(294, 30)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Form Pembayaran Hutang"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 539)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(901, 10)
        Me.Panel2.TabIndex = 342
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(231, 516)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(30, 13)
        Me.Label30.TabIndex = 351
        Me.Label30.Text = "Date"
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(272, 491)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtUpdAlias.TabIndex = 350
        Me.txtUpdAlias.TabStop = False
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(272, 513)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(150, 20)
        Me.txtUpdDate.TabIndex = 345
        Me.txtUpdDate.TabStop = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(52, 491)
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
        Me.Label28.Location = New System.Drawing.Point(231, 494)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(39, 13)
        Me.Label28.TabIndex = 352
        Me.Label28.Text = "UpdBy"
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(52, 513)
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
        Me.Label27.Location = New System.Drawing.Point(11, 494)
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
        Me.Label29.Location = New System.Drawing.Point(11, 516)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(30, 13)
        Me.Label29.TabIndex = 348
        Me.Label29.Text = "Date"
        '
        'bt_batalperkiraan
        '
        Me.bt_batalperkiraan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_batalperkiraan.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalperkiraan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalperkiraan.Location = New System.Drawing.Point(793, 503)
        Me.bt_batalperkiraan.Name = "bt_batalperkiraan"
        Me.bt_batalperkiraan.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalperkiraan.TabIndex = 19
        Me.bt_batalperkiraan.Text = "Batal"
        Me.bt_batalperkiraan.UseVisualStyleBackColor = True
        '
        'bt_simpanperkiraan
        '
        Me.bt_simpanperkiraan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_simpanperkiraan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanperkiraan.Location = New System.Drawing.Point(691, 503)
        Me.bt_simpanperkiraan.Name = "bt_simpanperkiraan"
        Me.bt_simpanperkiraan.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpanperkiraan.TabIndex = 18
        Me.bt_simpanperkiraan.Text = "Simpan"
        Me.bt_simpanperkiraan.UseVisualStyleBackColor = True
        '
        'bt_supplier_list
        '
        Me.bt_supplier_list.BackColor = System.Drawing.Color.Transparent
        Me.bt_supplier_list.BackgroundImage = CType(resources.GetObject("bt_supplier_list.BackgroundImage"), System.Drawing.Image)
        Me.bt_supplier_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_supplier_list.FlatAppearance.BorderSize = 0
        Me.bt_supplier_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_supplier_list.Location = New System.Drawing.Point(422, 83)
        Me.bt_supplier_list.Name = "bt_supplier_list"
        Me.bt_supplier_list.Size = New System.Drawing.Size(12, 15)
        Me.bt_supplier_list.TabIndex = 2
        Me.bt_supplier_list.TabStop = False
        Me.bt_supplier_list.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 356
        Me.Label7.Text = "Supplier"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(641, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 358
        Me.Label4.Text = "No. Bukti"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(641, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 357
        Me.Label1.Text = "Tgl"
        '
        'in_no_bukti
        '
        Me.in_no_bukti.BackColor = System.Drawing.Color.White
        Me.in_no_bukti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_no_bukti.ForeColor = System.Drawing.Color.Black
        Me.in_no_bukti.Location = New System.Drawing.Point(700, 80)
        Me.in_no_bukti.MaxLength = 30
        Me.in_no_bukti.Name = "in_no_bukti"
        Me.in_no_bukti.ReadOnly = True
        Me.in_no_bukti.Size = New System.Drawing.Size(188, 20)
        Me.in_no_bukti.TabIndex = 3
        Me.in_no_bukti.TabStop = False
        '
        'date_tgl_trans
        '
        Me.date_tgl_trans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_trans.Location = New System.Drawing.Point(700, 103)
        Me.date_tgl_trans.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_trans.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_trans.Name = "date_tgl_trans"
        Me.date_tgl_trans.Size = New System.Drawing.Size(188, 20)
        Me.date_tgl_trans.TabIndex = 4
        Me.date_tgl_trans.TabStop = False
        '
        'in_supplier
        '
        Me.in_supplier.BackColor = System.Drawing.Color.White
        Me.in_supplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier.ForeColor = System.Drawing.Color.Black
        Me.in_supplier.Location = New System.Drawing.Point(67, 80)
        Me.in_supplier.MaxLength = 30
        Me.in_supplier.Name = "in_supplier"
        Me.in_supplier.ReadOnly = True
        Me.in_supplier.Size = New System.Drawing.Size(135, 20)
        Me.in_supplier.TabIndex = 0
        '
        'dgv_faktur
        '
        Me.dgv_faktur.AllowUserToAddRows = False
        Me.dgv_faktur.AllowUserToDeleteRows = False
        Me.dgv_faktur.BackgroundColor = System.Drawing.Color.White
        Me.dgv_faktur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_faktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.faktur_kode, Me.faktur_debet})
        Me.dgv_faktur.Location = New System.Drawing.Point(234, 129)
        Me.dgv_faktur.MultiSelect = False
        Me.dgv_faktur.Name = "dgv_faktur"
        Me.dgv_faktur.ReadOnly = True
        Me.dgv_faktur.RowHeadersVisible = False
        Me.dgv_faktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_faktur.Size = New System.Drawing.Size(383, 117)
        Me.dgv_faktur.TabIndex = 9
        '
        'faktur_kode
        '
        Me.faktur_kode.DataPropertyName = "trans_faktur"
        Me.faktur_kode.HeaderText = "Faktur"
        Me.faktur_kode.MinimumWidth = 100
        Me.faktur_kode.Name = "faktur_kode"
        Me.faktur_kode.ReadOnly = True
        Me.faktur_kode.Width = 200
        '
        'faktur_debet
        '
        Me.faktur_debet.DataPropertyName = "trans_debet"
        Me.faktur_debet.HeaderText = "Debet"
        Me.faktur_debet.MinimumWidth = 100
        Me.faktur_debet.Name = "faktur_debet"
        Me.faktur_debet.ReadOnly = True
        Me.faktur_debet.Width = 150
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 356
        Me.Label2.Text = "Faktur"
        '
        'in_faktur
        '
        Me.in_faktur.BackColor = System.Drawing.Color.White
        Me.in_faktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_faktur.ForeColor = System.Drawing.Color.Black
        Me.in_faktur.Location = New System.Drawing.Point(67, 129)
        Me.in_faktur.MaxLength = 30
        Me.in_faktur.Name = "in_faktur"
        Me.in_faktur.Size = New System.Drawing.Size(161, 20)
        Me.in_faktur.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 177)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 356
        Me.Label3.Text = "Debet"
        '
        'in_bg_no
        '
        Me.in_bg_no.BackColor = System.Drawing.Color.White
        Me.in_bg_no.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_bg_no.ForeColor = System.Drawing.Color.Black
        Me.in_bg_no.Location = New System.Drawing.Point(127, 267)
        Me.in_bg_no.MaxLength = 150
        Me.in_bg_no.Name = "in_bg_no"
        Me.in_bg_no.ReadOnly = True
        Me.in_bg_no.Size = New System.Drawing.Size(170, 20)
        Me.in_bg_no.TabIndex = 11
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label22.Location = New System.Drawing.Point(598, 252)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 13)
        Me.Label22.TabIndex = 363
        Me.Label22.Text = "Kredit"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label20.Location = New System.Drawing.Point(124, 252)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 13)
        Me.Label20.TabIndex = 364
        Me.Label20.Text = "No. BG"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(8, 252)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 13)
        Me.Label16.TabIndex = 365
        Me.Label16.Text = "Kode Bayar"
        '
        'dgv_bayar
        '
        Me.dgv_bayar.AllowUserToAddRows = False
        Me.dgv_bayar.AllowUserToDeleteRows = False
        Me.dgv_bayar.BackgroundColor = System.Drawing.Color.White
        Me.dgv_bayar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_bayar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.bayar_kodebayar, Me.bayar_bgno, Me.bayar_bank, Me.bayar_debet, Me.bayar_kredit, Me.bayar_bgtgl})
        Me.dgv_bayar.Location = New System.Drawing.Point(11, 294)
        Me.dgv_bayar.Name = "dgv_bayar"
        Me.dgv_bayar.ReadOnly = True
        Me.dgv_bayar.RowHeadersVisible = False
        Me.dgv_bayar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_bayar.Size = New System.Drawing.Size(877, 159)
        Me.dgv_bayar.TabIndex = 17
        '
        'bayar_kodebayar
        '
        Me.bayar_kodebayar.DataPropertyName = "trans_kode_bayar"
        Me.bayar_kodebayar.HeaderText = "Kode"
        Me.bayar_kodebayar.MinimumWidth = 75
        Me.bayar_kodebayar.Name = "bayar_kodebayar"
        Me.bayar_kodebayar.ReadOnly = True
        Me.bayar_kodebayar.Width = 120
        '
        'bayar_bgno
        '
        Me.bayar_bgno.DataPropertyName = "trans_bg"
        Me.bayar_bgno.HeaderText = "No.BG"
        Me.bayar_bgno.MinimumWidth = 190
        Me.bayar_bgno.Name = "bayar_bgno"
        Me.bayar_bgno.ReadOnly = True
        Me.bayar_bgno.Width = 190
        '
        'bayar_bank
        '
        Me.bayar_bank.DataPropertyName = "trans_bank"
        Me.bayar_bank.HeaderText = "Bank"
        Me.bayar_bank.MinimumWidth = 100
        Me.bayar_bank.Name = "bayar_bank"
        Me.bayar_bank.ReadOnly = True
        Me.bayar_bank.Width = 200
        '
        'bayar_debet
        '
        Me.bayar_debet.DataPropertyName = "trans_debet"
        Me.bayar_debet.HeaderText = "Debet"
        Me.bayar_debet.MinimumWidth = 150
        Me.bayar_debet.Name = "bayar_debet"
        Me.bayar_debet.ReadOnly = True
        Me.bayar_debet.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.bayar_debet.Width = 150
        '
        'bayar_kredit
        '
        Me.bayar_kredit.DataPropertyName = "trans_kredit"
        Me.bayar_kredit.HeaderText = "Kredit"
        Me.bayar_kredit.MinimumWidth = 150
        Me.bayar_kredit.Name = "bayar_kredit"
        Me.bayar_kredit.ReadOnly = True
        Me.bayar_kredit.Width = 150
        '
        'bayar_bgtgl
        '
        Me.bayar_bgtgl.DataPropertyName = "trans_bg_tgl"
        Me.bayar_bgtgl.HeaderText = "Tgl. BG"
        Me.bayar_bgtgl.MinimumWidth = 75
        Me.bayar_bgtgl.Name = "bayar_bgtgl"
        Me.bayar_bgtgl.ReadOnly = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(296, 252)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 364
        Me.Label5.Text = "Bank"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.Location = New System.Drawing.Point(450, 252)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 364
        Me.Label6.Text = "Debet"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(745, 251)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 363
        Me.Label8.Text = "Tgl BG"
        '
        'date_bg_tgl
        '
        Me.date_bg_tgl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_bg_tgl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_bg_tgl.Location = New System.Drawing.Point(748, 267)
        Me.date_bg_tgl.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_bg_tgl.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_bg_tgl.Name = "date_bg_tgl"
        Me.date_bg_tgl.Size = New System.Drawing.Size(101, 20)
        Me.date_bg_tgl.TabIndex = 15
        '
        'cb_bank
        '
        Me.cb_bank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cb_bank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_bank.FormattingEnabled = True
        Me.cb_bank.Items.AddRange(New Object() {"ii", "ooo", "eeee"})
        Me.cb_bank.Location = New System.Drawing.Point(299, 267)
        Me.cb_bank.Name = "cb_bank"
        Me.cb_bank.Size = New System.Drawing.Size(152, 21)
        Me.cb_bank.TabIndex = 12
        '
        'cb_bayar
        '
        Me.cb_bayar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cb_bayar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_bayar.FormattingEnabled = True
        Me.cb_bayar.Items.AddRange(New Object() {"ii", "ooo", "eeee"})
        Me.cb_bayar.Location = New System.Drawing.Point(11, 267)
        Me.cb_bayar.Name = "cb_bayar"
        Me.cb_bayar.Size = New System.Drawing.Size(113, 21)
        Me.cb_bayar.TabIndex = 10
        '
        'in_kredit
        '
        Me.in_kredit.DecimalPlaces = 2
        Me.in_kredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kredit.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.in_kredit.Location = New System.Drawing.Point(601, 267)
        Me.in_kredit.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.in_kredit.Name = "in_kredit"
        Me.in_kredit.Size = New System.Drawing.Size(145, 20)
        Me.in_kredit.TabIndex = 14
        Me.in_kredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_kredit.ThousandsSeparator = True
        '
        'in_supplier_n
        '
        Me.in_supplier_n.BackColor = System.Drawing.Color.White
        Me.in_supplier_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier_n.ForeColor = System.Drawing.Color.Black
        Me.in_supplier_n.Location = New System.Drawing.Point(203, 80)
        Me.in_supplier_n.MaxLength = 30
        Me.in_supplier_n.Name = "in_supplier_n"
        Me.in_supplier_n.Size = New System.Drawing.Size(218, 20)
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
        Me.bt_tbbayar.Location = New System.Drawing.Point(857, 268)
        Me.bt_tbbayar.Name = "bt_tbbayar"
        Me.bt_tbbayar.Size = New System.Drawing.Size(18, 18)
        Me.bt_tbbayar.TabIndex = 16
        Me.bt_tbbayar.UseVisualStyleBackColor = False
        '
        'bt_faktur_add
        '
        Me.bt_faktur_add.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_faktur_add.Location = New System.Drawing.Point(169, 200)
        Me.bt_faktur_add.Name = "bt_faktur_add"
        Me.bt_faktur_add.Size = New System.Drawing.Size(59, 22)
        Me.bt_faktur_add.TabIndex = 8
        Me.bt_faktur_add.Text = "Add"
        Me.bt_faktur_add.UseVisualStyleBackColor = True
        '
        'in_faktur_debet
        '
        Me.in_faktur_debet.DecimalPlaces = 2
        Me.in_faktur_debet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_faktur_debet.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.in_faktur_debet.Location = New System.Drawing.Point(67, 173)
        Me.in_faktur_debet.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.in_faktur_debet.Name = "in_faktur_debet"
        Me.in_faktur_debet.Size = New System.Drawing.Size(161, 20)
        Me.in_faktur_debet.TabIndex = 14
        Me.in_faktur_debet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_faktur_debet.ThousandsSeparator = True
        '
        'in_debet
        '
        Me.in_debet.BackColor = System.Drawing.Color.White
        Me.in_debet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_debet.ForeColor = System.Drawing.Color.Black
        Me.in_debet.Location = New System.Drawing.Point(453, 267)
        Me.in_debet.MaxLength = 30
        Me.in_debet.Name = "in_debet"
        Me.in_debet.ReadOnly = True
        Me.in_debet.Size = New System.Drawing.Size(146, 20)
        Me.in_debet.TabIndex = 0
        Me.in_debet.TabStop = False
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.linkLbl_searchbarang)
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(311, 330)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(288, 135)
        Me.popPnl_barang.TabIndex = 366
        Me.popPnl_barang.Visible = False
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
        Me.dgv_listbarang.Size = New System.Drawing.Size(288, 111)
        Me.dgv_listbarang.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 356
        Me.Label9.Text = "SIsa"
        '
        'in_sisa_hutang
        '
        Me.in_sisa_hutang.BackColor = System.Drawing.Color.White
        Me.in_sisa_hutang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sisa_hutang.ForeColor = System.Drawing.Color.Black
        Me.in_sisa_hutang.Location = New System.Drawing.Point(67, 151)
        Me.in_sisa_hutang.MaxLength = 30
        Me.in_sisa_hutang.Name = "in_sisa_hutang"
        Me.in_sisa_hutang.Size = New System.Drawing.Size(161, 20)
        Me.in_sisa_hutang.TabIndex = 5
        '
        'in_total_deb
        '
        Me.in_total_deb.BackColor = System.Drawing.Color.White
        Me.in_total_deb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_total_deb.ForeColor = System.Drawing.Color.Black
        Me.in_total_deb.Location = New System.Drawing.Point(700, 174)
        Me.in_total_deb.MaxLength = 30
        Me.in_total_deb.Name = "in_total_deb"
        Me.in_total_deb.ReadOnly = True
        Me.in_total_deb.Size = New System.Drawing.Size(188, 20)
        Me.in_total_deb.TabIndex = 3
        Me.in_total_deb.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(641, 177)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 358
        Me.Label10.Text = "Debet"
        '
        'in_total_kre
        '
        Me.in_total_kre.BackColor = System.Drawing.Color.White
        Me.in_total_kre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_total_kre.ForeColor = System.Drawing.Color.Black
        Me.in_total_kre.Location = New System.Drawing.Point(700, 200)
        Me.in_total_kre.MaxLength = 30
        Me.in_total_kre.Name = "in_total_kre"
        Me.in_total_kre.ReadOnly = True
        Me.in_total_kre.Size = New System.Drawing.Size(188, 20)
        Me.in_total_kre.TabIndex = 3
        Me.in_total_kre.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(641, 203)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 358
        Me.Label11.Text = "Kredit"
        '
        'in_total_sel
        '
        Me.in_total_sel.BackColor = System.Drawing.Color.White
        Me.in_total_sel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_total_sel.ForeColor = System.Drawing.Color.Black
        Me.in_total_sel.Location = New System.Drawing.Point(700, 226)
        Me.in_total_sel.MaxLength = 30
        Me.in_total_sel.Name = "in_total_sel"
        Me.in_total_sel.ReadOnly = True
        Me.in_total_sel.Size = New System.Drawing.Size(188, 20)
        Me.in_total_sel.TabIndex = 3
        Me.in_total_sel.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(641, 229)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 358
        Me.Label12.Text = "Selisih"
        '
        'fr_hutang_bayar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.bt_batalperkiraan
        Me.ClientSize = New System.Drawing.Size(901, 549)
        Me.Controls.Add(Me.popPnl_barang)
        Me.Controls.Add(Me.bt_tbbayar)
        Me.Controls.Add(Me.cb_bayar)
        Me.Controls.Add(Me.cb_bank)
        Me.Controls.Add(Me.dgv_bayar)
        Me.Controls.Add(Me.in_faktur_debet)
        Me.Controls.Add(Me.in_kredit)
        Me.Controls.Add(Me.in_bg_no)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.dgv_faktur)
        Me.Controls.Add(Me.in_sisa_hutang)
        Me.Controls.Add(Me.in_faktur)
        Me.Controls.Add(Me.in_supplier_n)
        Me.Controls.Add(Me.in_debet)
        Me.Controls.Add(Me.in_supplier)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.bt_supplier_list)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.in_total_sel)
        Me.Controls.Add(Me.in_total_kre)
        Me.Controls.Add(Me.in_total_deb)
        Me.Controls.Add(Me.in_no_bukti)
        Me.Controls.Add(Me.date_bg_tgl)
        Me.Controls.Add(Me.date_tgl_trans)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtUpdAlias)
        Me.Controls.Add(Me.txtUpdDate)
        Me.Controls.Add(Me.txtRegAlias)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.txtRegdate)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.bt_batalperkiraan)
        Me.Controls.Add(Me.bt_faktur_add)
        Me.Controls.Add(Me.bt_simpanperkiraan)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnl_Menu)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "fr_hutang_bayar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fr_hutang_bayar"
        Me.pnl_Menu.ResumeLayout(False)
        Me.pnl_Menu.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv_faktur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_bayar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_kredit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_faktur_debet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popPnl_barang.ResumeLayout(False)
        Me.popPnl_barang.PerformLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents bt_supplier_list As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_no_bukti As System.Windows.Forms.TextBox
    Friend WithEvents date_tgl_trans As System.Windows.Forms.DateTimePicker
    Friend WithEvents in_supplier As System.Windows.Forms.TextBox
    Friend WithEvents dgv_faktur As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_faktur As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents in_bg_no As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dgv_bayar As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents date_bg_tgl As System.Windows.Forms.DateTimePicker
    Friend WithEvents cb_bank As System.Windows.Forms.ComboBox
    Friend WithEvents cb_bayar As System.Windows.Forms.ComboBox
    Friend WithEvents in_kredit As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_supplier_n As System.Windows.Forms.TextBox
    Friend WithEvents bt_tbbayar As System.Windows.Forms.Button
    Friend WithEvents bt_faktur_add As System.Windows.Forms.Button
    Friend WithEvents bayar_kodebayar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bayar_bgno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bayar_bank As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bayar_debet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bayar_kredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bayar_bgtgl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents in_faktur_debet As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_debet As System.Windows.Forms.TextBox
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents linkLbl_searchbarang As System.Windows.Forms.LinkLabel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents faktur_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_debet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents in_sisa_hutang As System.Windows.Forms.TextBox
    Friend WithEvents in_total_deb As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents in_total_kre As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents in_total_sel As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
