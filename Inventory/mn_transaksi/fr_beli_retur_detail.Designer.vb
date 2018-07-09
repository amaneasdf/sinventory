<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_beli_retur_detail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_beli_retur_detail))
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.pnl_Menu = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_print = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_cancelorder = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tb_returbeli = New System.Windows.Forms.TabPage()
        Me.bt_gudang_list = New System.Windows.Forms.Button()
        Me.bt_supplier_list = New System.Windows.Forms.Button()
        Me.bt_faktur_list = New System.Windows.Forms.Button()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.in_netto = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.in_ppn_tot = New System.Windows.Forms.TextBox()
        Me.in_jumlah = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.linkLbl_searchbarang = New System.Windows.Forms.LinkLabel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.bt_tbbarang = New System.Windows.Forms.Button()
        Me.in_subtotal = New System.Windows.Forms.TextBox()
        Me.cb_sat = New System.Windows.Forms.ComboBox()
        Me.in_barang = New System.Windows.Forms.TextBox()
        Me.in_barang_nm = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.in_harga_retur = New System.Windows.Forms.NumericUpDown()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.in_qty = New System.Windows.Forms.NumericUpDown()
        Me.dgv_barang = New System.Windows.Forms.DataGridView()
        Me.kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.harga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.jml = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cb_gudang = New System.Windows.Forms.ComboBox()
        Me.cb_supplier = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_status_kode = New System.Windows.Forms.TextBox()
        Me.in_no_bukti = New System.Windows.Forms.TextBox()
        Me.date_tgl_trans = New System.Windows.Forms.DateTimePicker()
        Me.bt_batalreturbeli = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.bt_simpanreturbeli = New System.Windows.Forms.Button()
        Me.cb_bayar_jenis = New System.Windows.Forms.ComboBox()
        Me.date_tgl_pajak = New System.Windows.Forms.DateTimePicker()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.in_no_faktur_ex = New System.Windows.Forms.TextBox()
        Me.in_no_faktur = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.in_pajak = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.brg_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brg_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brg_beli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.pnl_Menu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tb_returbeli.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_harga_retur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Orange
        Me.Label12.Font = New System.Drawing.Font("Source Sans Pro", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(6, 4)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(246, 30)
        Me.Label12.TabIndex = 136
        Me.Label12.Text = "Data Retur Pembelian"
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(823, 9)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(47, 20)
        Me.lbl_close.TabIndex = 138
        Me.lbl_close.Text = "Close"
        Me.lbl_close.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.lbl_close)
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(903, 42)
        Me.Panel1.TabIndex = 246
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
        Me.bt_cl.Location = New System.Drawing.Point(876, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 137
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'pnl_Menu
        '
        Me.pnl_Menu.Controls.Add(Me.MenuStrip1)
        Me.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Menu.Location = New System.Drawing.Point(0, 42)
        Me.pnl_Menu.Name = "pnl_Menu"
        Me.pnl_Menu.Size = New System.Drawing.Size(903, 32)
        Me.pnl_Menu.TabIndex = 247
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_print, Me.mn_cancelorder})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(903, 24)
        Me.MenuStrip1.TabIndex = 182
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
        Me.mn_cancelorder.Size = New System.Drawing.Size(102, 20)
        Me.mn_cancelorder.Text = "Cancel Retur"
        Me.mn_cancelorder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tb_returbeli)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 74)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(903, 444)
        Me.TabControl1.TabIndex = 0
        '
        'tb_returbeli
        '
        Me.tb_returbeli.Controls.Add(Me.bt_gudang_list)
        Me.tb_returbeli.Controls.Add(Me.bt_supplier_list)
        Me.tb_returbeli.Controls.Add(Me.bt_faktur_list)
        Me.tb_returbeli.Controls.Add(Me.txtRegAlias)
        Me.tb_returbeli.Controls.Add(Me.Label27)
        Me.tb_returbeli.Controls.Add(Me.txtRegdate)
        Me.tb_returbeli.Controls.Add(Me.Label29)
        Me.tb_returbeli.Controls.Add(Me.GroupBox3)
        Me.tb_returbeli.Controls.Add(Me.Panel2)
        Me.tb_returbeli.Controls.Add(Me.cb_gudang)
        Me.tb_returbeli.Controls.Add(Me.cb_supplier)
        Me.tb_returbeli.Controls.Add(Me.GroupBox1)
        Me.tb_returbeli.Controls.Add(Me.bt_batalreturbeli)
        Me.tb_returbeli.Controls.Add(Me.Button1)
        Me.tb_returbeli.Controls.Add(Me.bt_simpanreturbeli)
        Me.tb_returbeli.Controls.Add(Me.cb_bayar_jenis)
        Me.tb_returbeli.Controls.Add(Me.date_tgl_pajak)
        Me.tb_returbeli.Controls.Add(Me.in_ket)
        Me.tb_returbeli.Controls.Add(Me.in_no_faktur_ex)
        Me.tb_returbeli.Controls.Add(Me.in_no_faktur)
        Me.tb_returbeli.Controls.Add(Me.Label14)
        Me.tb_returbeli.Controls.Add(Me.Label8)
        Me.tb_returbeli.Controls.Add(Me.Label5)
        Me.tb_returbeli.Controls.Add(Me.Label9)
        Me.tb_returbeli.Controls.Add(Me.Label7)
        Me.tb_returbeli.Controls.Add(Me.Label6)
        Me.tb_returbeli.Controls.Add(Me.in_pajak)
        Me.tb_returbeli.Controls.Add(Me.Label3)
        Me.tb_returbeli.Controls.Add(Me.Label2)
        Me.tb_returbeli.Location = New System.Drawing.Point(4, 22)
        Me.tb_returbeli.Name = "tb_returbeli"
        Me.tb_returbeli.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_returbeli.Size = New System.Drawing.Size(895, 418)
        Me.tb_returbeli.TabIndex = 0
        Me.tb_returbeli.Text = "Retur Pembelian"
        Me.tb_returbeli.UseVisualStyleBackColor = True
        '
        'bt_gudang_list
        '
        Me.bt_gudang_list.BackColor = System.Drawing.Color.Transparent
        Me.bt_gudang_list.BackgroundImage = CType(resources.GetObject("bt_gudang_list.BackgroundImage"), System.Drawing.Image)
        Me.bt_gudang_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_gudang_list.FlatAppearance.BorderSize = 0
        Me.bt_gudang_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_gudang_list.Location = New System.Drawing.Point(288, 34)
        Me.bt_gudang_list.Name = "bt_gudang_list"
        Me.bt_gudang_list.Size = New System.Drawing.Size(12, 15)
        Me.bt_gudang_list.TabIndex = 287
        Me.bt_gudang_list.UseVisualStyleBackColor = False
        '
        'bt_supplier_list
        '
        Me.bt_supplier_list.BackColor = System.Drawing.Color.Transparent
        Me.bt_supplier_list.BackgroundImage = CType(resources.GetObject("bt_supplier_list.BackgroundImage"), System.Drawing.Image)
        Me.bt_supplier_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_supplier_list.FlatAppearance.BorderSize = 0
        Me.bt_supplier_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_supplier_list.Location = New System.Drawing.Point(288, 10)
        Me.bt_supplier_list.Name = "bt_supplier_list"
        Me.bt_supplier_list.Size = New System.Drawing.Size(12, 15)
        Me.bt_supplier_list.TabIndex = 288
        Me.bt_supplier_list.UseVisualStyleBackColor = False
        '
        'bt_faktur_list
        '
        Me.bt_faktur_list.BackColor = System.Drawing.Color.Transparent
        Me.bt_faktur_list.BackgroundImage = CType(resources.GetObject("bt_faktur_list.BackgroundImage"), System.Drawing.Image)
        Me.bt_faktur_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_faktur_list.FlatAppearance.BorderSize = 0
        Me.bt_faktur_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_faktur_list.Location = New System.Drawing.Point(589, 35)
        Me.bt_faktur_list.Name = "bt_faktur_list"
        Me.bt_faktur_list.Size = New System.Drawing.Size(12, 15)
        Me.bt_faktur_list.TabIndex = 1
        Me.bt_faktur_list.UseVisualStyleBackColor = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(730, 334)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtRegAlias.TabIndex = 285
        Me.txtRegAlias.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(691, 337)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(33, 13)
        Me.Label27.TabIndex = 286
        Me.Label27.Text = "Date:"
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(730, 310)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(150, 20)
        Me.txtRegdate.TabIndex = 283
        Me.txtRegdate.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(679, 313)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(45, 13)
        Me.Label29.TabIndex = 284
        Me.Label29.Text = "Reg By:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.in_netto)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.in_ppn_tot)
        Me.GroupBox3.Controls.Add(Me.in_jumlah)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 305)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(273, 100)
        Me.GroupBox3.TabIndex = 282
        Me.GroupBox3.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 42)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(27, 13)
        Me.Label15.TabIndex = 192
        Me.Label15.Text = "PPn"
        '
        'in_netto
        '
        Me.in_netto.BackColor = System.Drawing.Color.White
        Me.in_netto.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_netto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_netto.ForeColor = System.Drawing.Color.Black
        Me.in_netto.Location = New System.Drawing.Point(85, 65)
        Me.in_netto.MaxLength = 20
        Me.in_netto.Name = "in_netto"
        Me.in_netto.ReadOnly = True
        Me.in_netto.Size = New System.Drawing.Size(182, 20)
        Me.in_netto.TabIndex = 24
        Me.in_netto.TabStop = False
        Me.in_netto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 68)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 13)
        Me.Label17.TabIndex = 192
        Me.Label17.Text = "NETTO"
        '
        'in_ppn_tot
        '
        Me.in_ppn_tot.BackColor = System.Drawing.Color.White
        Me.in_ppn_tot.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_ppn_tot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ppn_tot.ForeColor = System.Drawing.Color.Black
        Me.in_ppn_tot.Location = New System.Drawing.Point(85, 39)
        Me.in_ppn_tot.MaxLength = 20
        Me.in_ppn_tot.Name = "in_ppn_tot"
        Me.in_ppn_tot.ReadOnly = True
        Me.in_ppn_tot.Size = New System.Drawing.Size(182, 20)
        Me.in_ppn_tot.TabIndex = 19
        Me.in_ppn_tot.TabStop = False
        Me.in_ppn_tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_jumlah
        '
        Me.in_jumlah.BackColor = System.Drawing.Color.White
        Me.in_jumlah.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_jumlah.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_jumlah.ForeColor = System.Drawing.Color.Black
        Me.in_jumlah.Location = New System.Drawing.Point(85, 13)
        Me.in_jumlah.MaxLength = 20
        Me.in_jumlah.Name = "in_jumlah"
        Me.in_jumlah.ReadOnly = True
        Me.in_jumlah.Size = New System.Drawing.Size(182, 20)
        Me.in_jumlah.TabIndex = 19
        Me.in_jumlah.TabStop = False
        Me.in_jumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 13)
        Me.Label11.TabIndex = 192
        Me.Label11.Text = "Sub-Total"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.popPnl_barang)
        Me.Panel2.Controls.Add(Me.bt_tbbarang)
        Me.Panel2.Controls.Add(Me.in_subtotal)
        Me.Panel2.Controls.Add(Me.cb_sat)
        Me.Panel2.Controls.Add(Me.in_barang)
        Me.Panel2.Controls.Add(Me.in_barang_nm)
        Me.Panel2.Controls.Add(Me.Label31)
        Me.Panel2.Controls.Add(Me.in_harga_retur)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.in_qty)
        Me.Panel2.Controls.Add(Me.dgv_barang)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Location = New System.Drawing.Point(0, 106)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(881, 198)
        Me.Panel2.TabIndex = 8
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.linkLbl_searchbarang)
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(54, 58)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(444, 135)
        Me.popPnl_barang.TabIndex = 271
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
        Me.dgv_listbarang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.brg_kode, Me.brg_nama, Me.brg_beli})
        Me.dgv_listbarang.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgv_listbarang.Location = New System.Drawing.Point(0, 0)
        Me.dgv_listbarang.MultiSelect = False
        Me.dgv_listbarang.Name = "dgv_listbarang"
        Me.dgv_listbarang.ReadOnly = True
        Me.dgv_listbarang.RowHeadersVisible = False
        Me.dgv_listbarang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listbarang.Size = New System.Drawing.Size(444, 111)
        Me.dgv_listbarang.TabIndex = 0
        '
        'bt_tbbarang
        '
        Me.bt_tbbarang.BackColor = System.Drawing.Color.Transparent
        Me.bt_tbbarang.BackgroundImage = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.bt_tbbarang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_tbbarang.FlatAppearance.BorderSize = 0
        Me.bt_tbbarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_tbbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tbbarang.Location = New System.Drawing.Point(746, 18)
        Me.bt_tbbarang.Name = "bt_tbbarang"
        Me.bt_tbbarang.Size = New System.Drawing.Size(23, 23)
        Me.bt_tbbarang.TabIndex = 9
        Me.bt_tbbarang.UseVisualStyleBackColor = False
        '
        'in_subtotal
        '
        Me.in_subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_subtotal.Location = New System.Drawing.Point(584, 21)
        Me.in_subtotal.Name = "in_subtotal"
        Me.in_subtotal.Size = New System.Drawing.Size(156, 20)
        Me.in_subtotal.TabIndex = 263
        Me.in_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cb_sat
        '
        Me.cb_sat.BackColor = System.Drawing.Color.White
        Me.cb_sat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_sat.FormattingEnabled = True
        Me.cb_sat.Location = New System.Drawing.Point(367, 21)
        Me.cb_sat.Name = "cb_sat"
        Me.cb_sat.Size = New System.Drawing.Size(71, 21)
        Me.cb_sat.TabIndex = 7
        '
        'in_barang
        '
        Me.in_barang.BackColor = System.Drawing.Color.White
        Me.in_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang.ForeColor = System.Drawing.Color.Black
        Me.in_barang.Location = New System.Drawing.Point(12, 21)
        Me.in_barang.Name = "in_barang"
        Me.in_barang.Size = New System.Drawing.Size(100, 20)
        Me.in_barang.TabIndex = 5
        '
        'in_barang_nm
        '
        Me.in_barang_nm.BackColor = System.Drawing.Color.White
        Me.in_barang_nm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang_nm.ForeColor = System.Drawing.Color.Black
        Me.in_barang_nm.Location = New System.Drawing.Point(112, 21)
        Me.in_barang_nm.MaxLength = 150
        Me.in_barang_nm.Name = "in_barang_nm"
        Me.in_barang_nm.ReadOnly = True
        Me.in_barang_nm.Size = New System.Drawing.Size(188, 20)
        Me.in_barang_nm.TabIndex = 270
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label31.Location = New System.Drawing.Point(581, 5)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(58, 13)
        Me.Label31.TabIndex = 264
        Me.Label31.Text = "SubTotal"
        '
        'in_harga_retur
        '
        Me.in_harga_retur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_harga_retur.Location = New System.Drawing.Point(444, 21)
        Me.in_harga_retur.Maximum = New Decimal(New Integer() {-1981284353, -1966660860, 0, 0})
        Me.in_harga_retur.Name = "in_harga_retur"
        Me.in_harga_retur.Size = New System.Drawing.Size(140, 20)
        Me.in_harga_retur.TabIndex = 8
        Me.in_harga_retur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label22.Location = New System.Drawing.Point(441, 5)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(76, 13)
        Me.Label22.TabIndex = 265
        Me.Label22.Text = "Harga Retur"
        '
        'in_qty
        '
        Me.in_qty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty.Location = New System.Drawing.Point(304, 21)
        Me.in_qty.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.in_qty.Name = "in_qty"
        Me.in_qty.Size = New System.Drawing.Size(63, 20)
        Me.in_qty.TabIndex = 6
        Me.in_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgv_barang
        '
        Me.dgv_barang.AllowUserToAddRows = False
        Me.dgv_barang.AllowUserToDeleteRows = False
        Me.dgv_barang.BackgroundColor = System.Drawing.Color.White
        Me.dgv_barang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_barang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kode, Me.nama, Me.qty, Me.sat, Me.harga, Me.jml})
        Me.dgv_barang.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgv_barang.Location = New System.Drawing.Point(0, 44)
        Me.dgv_barang.Name = "dgv_barang"
        Me.dgv_barang.ReadOnly = True
        Me.dgv_barang.RowHeadersVisible = False
        Me.dgv_barang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_barang.Size = New System.Drawing.Size(881, 154)
        Me.dgv_barang.TabIndex = 10
        '
        'kode
        '
        Me.kode.DataPropertyName = "trans_barang"
        Me.kode.HeaderText = "Kode"
        Me.kode.Name = "kode"
        Me.kode.ReadOnly = True
        '
        'nama
        '
        Me.nama.DataPropertyName = "barang_nama"
        Me.nama.HeaderText = "Nama Barang"
        Me.nama.MinimumWidth = 190
        Me.nama.Name = "nama"
        Me.nama.ReadOnly = True
        Me.nama.Width = 190
        '
        'qty
        '
        Me.qty.DataPropertyName = "trans_qty"
        Me.qty.HeaderText = "QTY"
        Me.qty.MinimumWidth = 60
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        Me.qty.Width = 60
        '
        'sat
        '
        Me.sat.DataPropertyName = "trans_satuan"
        Me.sat.HeaderText = "Satuan"
        Me.sat.MinimumWidth = 60
        Me.sat.Name = "sat"
        Me.sat.ReadOnly = True
        Me.sat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.sat.Width = 60
        '
        'harga
        '
        Me.harga.DataPropertyName = "trans_harga_retur"
        Me.harga.HeaderText = "Harga Retur"
        Me.harga.MinimumWidth = 110
        Me.harga.Name = "harga"
        Me.harga.ReadOnly = True
        Me.harga.Width = 110
        '
        'jml
        '
        Me.jml.DataPropertyName = "trans_jumlah"
        Me.jml.HeaderText = "Jumlah"
        Me.jml.Name = "jml"
        Me.jml.ReadOnly = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label20.Location = New System.Drawing.Point(107, 5)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 13)
        Me.Label20.TabIndex = 267
        Me.Label20.Text = "Nama"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(9, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 268
        Me.Label16.Text = "Kode"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label21.Location = New System.Drawing.Point(301, 5)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(26, 13)
        Me.Label21.TabIndex = 266
        Me.Label21.Text = "Qty"
        '
        'cb_gudang
        '
        Me.cb_gudang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cb_gudang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_gudang.FormattingEnabled = True
        Me.cb_gudang.Items.AddRange(New Object() {"ii", "ooo", "eeee"})
        Me.cb_gudang.Location = New System.Drawing.Point(95, 31)
        Me.cb_gudang.Name = "cb_gudang"
        Me.cb_gudang.Size = New System.Drawing.Size(188, 21)
        Me.cb_gudang.TabIndex = 1
        '
        'cb_supplier
        '
        Me.cb_supplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cb_supplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_supplier.FormattingEnabled = True
        Me.cb_supplier.Items.AddRange(New Object() {"ii", "ooo", "eeee"})
        Me.cb_supplier.Location = New System.Drawing.Point(95, 7)
        Me.cb_supplier.Name = "cb_supplier"
        Me.cb_supplier.Size = New System.Drawing.Size(188, 21)
        Me.cb_supplier.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.in_status_kode)
        Me.GroupBox1.Controls.Add(Me.in_no_bukti)
        Me.GroupBox1.Controls.Add(Me.date_tgl_trans)
        Me.GroupBox1.Location = New System.Drawing.Point(627, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(262, 90)
        Me.GroupBox1.TabIndex = 278
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 270
        Me.Label4.Text = "No. Retur"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 277
        Me.Label13.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 267
        Me.Label1.Text = "Tgl"
        '
        'in_status_kode
        '
        Me.in_status_kode.BackColor = System.Drawing.Color.White
        Me.in_status_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status_kode.ForeColor = System.Drawing.Color.Black
        Me.in_status_kode.Location = New System.Drawing.Point(65, 59)
        Me.in_status_kode.Name = "in_status_kode"
        Me.in_status_kode.ReadOnly = True
        Me.in_status_kode.Size = New System.Drawing.Size(188, 20)
        Me.in_status_kode.TabIndex = 276
        Me.in_status_kode.TabStop = False
        '
        'in_no_bukti
        '
        Me.in_no_bukti.BackColor = System.Drawing.Color.White
        Me.in_no_bukti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_no_bukti.ForeColor = System.Drawing.Color.Black
        Me.in_no_bukti.Location = New System.Drawing.Point(65, 13)
        Me.in_no_bukti.MaxLength = 30
        Me.in_no_bukti.Name = "in_no_bukti"
        Me.in_no_bukti.Size = New System.Drawing.Size(188, 20)
        Me.in_no_bukti.TabIndex = 246
        Me.in_no_bukti.TabStop = False
        '
        'date_tgl_trans
        '
        Me.date_tgl_trans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_trans.Location = New System.Drawing.Point(65, 36)
        Me.date_tgl_trans.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_trans.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_trans.Name = "date_tgl_trans"
        Me.date_tgl_trans.Size = New System.Drawing.Size(188, 20)
        Me.date_tgl_trans.TabIndex = 247
        Me.date_tgl_trans.TabStop = False
        '
        'bt_batalreturbeli
        '
        Me.bt_batalreturbeli.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalreturbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalreturbeli.Location = New System.Drawing.Point(784, 375)
        Me.bt_batalreturbeli.Name = "bt_batalreturbeli"
        Me.bt_batalreturbeli.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalreturbeli.TabIndex = 16
        Me.bt_batalreturbeli.Text = "Batal"
        Me.bt_batalreturbeli.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(583, 375)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 30)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Process"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'bt_simpanreturbeli
        '
        Me.bt_simpanreturbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanreturbeli.Location = New System.Drawing.Point(685, 375)
        Me.bt_simpanreturbeli.Name = "bt_simpanreturbeli"
        Me.bt_simpanreturbeli.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpanreturbeli.TabIndex = 15
        Me.bt_simpanreturbeli.Text = "Simpan"
        Me.bt_simpanreturbeli.UseVisualStyleBackColor = True
        '
        'cb_bayar_jenis
        '
        Me.cb_bayar_jenis.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cb_bayar_jenis.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cb_bayar_jenis.BackColor = System.Drawing.Color.White
        Me.cb_bayar_jenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_bayar_jenis.FormattingEnabled = True
        Me.cb_bayar_jenis.Location = New System.Drawing.Point(396, 7)
        Me.cb_bayar_jenis.Name = "cb_bayar_jenis"
        Me.cb_bayar_jenis.Size = New System.Drawing.Size(188, 21)
        Me.cb_bayar_jenis.TabIndex = 4
        '
        'date_tgl_pajak
        '
        Me.date_tgl_pajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_pajak.Location = New System.Drawing.Point(396, 80)
        Me.date_tgl_pajak.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_pajak.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_pajak.Name = "date_tgl_pajak"
        Me.date_tgl_pajak.Size = New System.Drawing.Size(188, 20)
        Me.date_tgl_pajak.TabIndex = 7
        '
        'in_ket
        '
        Me.in_ket.BackColor = System.Drawing.Color.White
        Me.in_ket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.ForeColor = System.Drawing.Color.Black
        Me.in_ket.Location = New System.Drawing.Point(376, 318)
        Me.in_ket.MaxLength = 200
        Me.in_ket.Multiline = True
        Me.in_ket.Name = "in_ket"
        Me.in_ket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_ket.Size = New System.Drawing.Size(188, 72)
        Me.in_ket.TabIndex = 4
        '
        'in_no_faktur_ex
        '
        Me.in_no_faktur_ex.BackColor = System.Drawing.Color.White
        Me.in_no_faktur_ex.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_no_faktur_ex.ForeColor = System.Drawing.Color.Black
        Me.in_no_faktur_ex.Location = New System.Drawing.Point(95, 55)
        Me.in_no_faktur_ex.MaxLength = 30
        Me.in_no_faktur_ex.Name = "in_no_faktur_ex"
        Me.in_no_faktur_ex.Size = New System.Drawing.Size(188, 20)
        Me.in_no_faktur_ex.TabIndex = 3
        '
        'in_no_faktur
        '
        Me.in_no_faktur.BackColor = System.Drawing.Color.White
        Me.in_no_faktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_no_faktur.ForeColor = System.Drawing.Color.Black
        Me.in_no_faktur.Location = New System.Drawing.Point(396, 32)
        Me.in_no_faktur.MaxLength = 30
        Me.in_no_faktur.Name = "in_no_faktur"
        Me.in_no_faktur.Size = New System.Drawing.Size(188, 20)
        Me.in_no_faktur.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(293, 322)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 13)
        Me.Label14.TabIndex = 262
        Me.Label14.Text = "Catatan Invoice"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 266
        Me.Label8.Text = "Ex.No.Faktur"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(313, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 264
        Me.Label5.Text = "Jenis Bayar"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(313, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 265
        Me.Label9.Text = "Faktur Beli"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 263
        Me.Label7.Text = "Supplier"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 269
        Me.Label6.Text = "Gudang"
        '
        'in_pajak
        '
        Me.in_pajak.BackColor = System.Drawing.Color.White
        Me.in_pajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_pajak.ForeColor = System.Drawing.Color.Black
        Me.in_pajak.Location = New System.Drawing.Point(396, 56)
        Me.in_pajak.MaxLength = 20
        Me.in_pajak.Name = "in_pajak"
        Me.in_pajak.Size = New System.Drawing.Size(188, 20)
        Me.in_pajak.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(313, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 261
        Me.Label3.Text = "Tgl. Pajak"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(313, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 260
        Me.Label2.Text = "No.Pajak"
        '
        'brg_kode
        '
        Me.brg_kode.DataPropertyName = "kode"
        Me.brg_kode.HeaderText = "Kode"
        Me.brg_kode.MinimumWidth = 125
        Me.brg_kode.Name = "brg_kode"
        Me.brg_kode.ReadOnly = True
        Me.brg_kode.Width = 125
        '
        'brg_nama
        '
        Me.brg_nama.DataPropertyName = "nama"
        Me.brg_nama.HeaderText = "Nama"
        Me.brg_nama.MinimumWidth = 175
        Me.brg_nama.Name = "brg_nama"
        Me.brg_nama.ReadOnly = True
        Me.brg_nama.Width = 175
        '
        'brg_beli
        '
        Me.brg_beli.DataPropertyName = "harga_beli"
        Me.brg_beli.HeaderText = "Harga Beli"
        Me.brg_beli.MinimumWidth = 135
        Me.brg_beli.Name = "brg_beli"
        Me.brg_beli.ReadOnly = True
        Me.brg_beli.Width = 135
        '
        'fr_beli_retur_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.bt_batalreturbeli
        Me.ClientSize = New System.Drawing.Size(903, 518)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.pnl_Menu)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "fr_beli_retur_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Retur Pembelian : "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_Menu.ResumeLayout(False)
        Me.pnl_Menu.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tb_returbeli.ResumeLayout(False)
        Me.tb_returbeli.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.popPnl_barang.ResumeLayout(False)
        Me.popPnl_barang.PerformLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_harga_retur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_qty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnl_Menu As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tb_returbeli As System.Windows.Forms.TabPage
    Friend WithEvents bt_batalreturbeli As System.Windows.Forms.Button
    Friend WithEvents bt_simpanreturbeli As System.Windows.Forms.Button
    Friend WithEvents cb_bayar_jenis As System.Windows.Forms.ComboBox
    Friend WithEvents date_tgl_trans As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_tgl_pajak As System.Windows.Forms.DateTimePicker
    Friend WithEvents in_no_faktur_ex As System.Windows.Forms.TextBox
    Friend WithEvents in_no_faktur As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents in_pajak As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents in_no_bukti As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_cancelorder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents in_status_kode As System.Windows.Forms.TextBox
    Friend WithEvents cb_gudang As System.Windows.Forms.ComboBox
    Friend WithEvents cb_supplier As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents bt_tbbarang As System.Windows.Forms.Button
    Friend WithEvents in_subtotal As System.Windows.Forms.TextBox
    Friend WithEvents cb_sat As System.Windows.Forms.ComboBox
    Friend WithEvents in_barang As System.Windows.Forms.TextBox
    Friend WithEvents in_barang_nm As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents in_harga_retur As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents in_qty As System.Windows.Forms.NumericUpDown
    Friend WithEvents dgv_barang As System.Windows.Forms.DataGridView
    Friend WithEvents kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents harga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jml As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents in_netto As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents in_ppn_tot As System.Windows.Forms.TextBox
    Friend WithEvents in_jumlah As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents bt_faktur_list As System.Windows.Forms.Button
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents linkLbl_searchbarang As System.Windows.Forms.LinkLabel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents bt_gudang_list As System.Windows.Forms.Button
    Friend WithEvents bt_supplier_list As System.Windows.Forms.Button
    Friend WithEvents brg_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brg_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brg_beli As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
