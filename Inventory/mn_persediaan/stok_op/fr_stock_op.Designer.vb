<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_stock_op
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_stock_op))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.linkLbl_searchbarang = New System.Windows.Forms.LinkLabel()
        Me.dgv_barang = New System.Windows.Forms.DataGridView()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.in_qty_total = New System.Windows.Forms.TextBox()
        Me.in_sat_k = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.in_qty_k = New System.Windows.Forms.NumericUpDown()
        Me.in_sat_t = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_qty_t = New System.Windows.Forms.NumericUpDown()
        Me.in_qty_sys = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.in_status = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtProcAlias = New System.Windows.Forms.TextBox()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.txtProcDate = New System.Windows.Forms.TextBox()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.bt_tbbarang = New System.Windows.Forms.Button()
        Me.in_hpp = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.in_gudang_n = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.in_gudang = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.in_sat_b = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.in_qty_sys_n = New System.Windows.Forms.TextBox()
        Me.date_tgl_beli = New System.Windows.Forms.DateTimePicker()
        Me.in_qty_b = New System.Windows.Forms.NumericUpDown()
        Me.in_barang_nm = New System.Windows.Forms.TextBox()
        Me.in_barang = New System.Windows.Forms.TextBox()
        Me.cb_pajak = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.pnl_footer = New System.Windows.Forms.Panel()
        Me.bt_simpanbeli = New System.Windows.Forms.Button()
        Me.bt_batalbeli = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_print = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_proses = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_fis_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat_fis_b = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_fis_t = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat_fis_t = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_fis_k = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat_fis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_fis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_sys = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_n_sys = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sat_sys = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hpp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hpp_fis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nilai_sys = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nilai_fis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty_sel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nilai_sel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.pnl_content.SuspendLayout()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty_k, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty_t, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_hpp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_qty_b, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_footer.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(1016, 42)
        Me.Panel1.TabIndex = 248
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(936, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(989, 9)
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
        Me.lbl_title.Size = New System.Drawing.Size(156, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Stok Opname"
        '
        'pnl_content
        '
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.BackColor = System.Drawing.Color.White
        Me.pnl_content.Controls.Add(Me.popPnl_barang)
        Me.pnl_content.Controls.Add(Me.dgv_barang)
        Me.pnl_content.Controls.Add(Me.Label9)
        Me.pnl_content.Controls.Add(Me.in_qty_total)
        Me.pnl_content.Controls.Add(Me.in_sat_k)
        Me.pnl_content.Controls.Add(Me.Label8)
        Me.pnl_content.Controls.Add(Me.in_qty_k)
        Me.pnl_content.Controls.Add(Me.in_sat_t)
        Me.pnl_content.Controls.Add(Me.Label2)
        Me.pnl_content.Controls.Add(Me.in_qty_t)
        Me.pnl_content.Controls.Add(Me.in_qty_sys)
        Me.pnl_content.Controls.Add(Me.Label13)
        Me.pnl_content.Controls.Add(Me.in_status)
        Me.pnl_content.Controls.Add(Me.Label29)
        Me.pnl_content.Controls.Add(Me.txtRegdate)
        Me.pnl_content.Controls.Add(Me.Label11)
        Me.pnl_content.Controls.Add(Me.Label28)
        Me.pnl_content.Controls.Add(Me.Label10)
        Me.pnl_content.Controls.Add(Me.Label30)
        Me.pnl_content.Controls.Add(Me.Label27)
        Me.pnl_content.Controls.Add(Me.txtProcAlias)
        Me.pnl_content.Controls.Add(Me.txtUpdAlias)
        Me.pnl_content.Controls.Add(Me.txtProcDate)
        Me.pnl_content.Controls.Add(Me.txtUpdDate)
        Me.pnl_content.Controls.Add(Me.txtRegAlias)
        Me.pnl_content.Controls.Add(Me.Label1)
        Me.pnl_content.Controls.Add(Me.in_ket)
        Me.pnl_content.Controls.Add(Me.bt_tbbarang)
        Me.pnl_content.Controls.Add(Me.in_hpp)
        Me.pnl_content.Controls.Add(Me.Label7)
        Me.pnl_content.Controls.Add(Me.Label5)
        Me.pnl_content.Controls.Add(Me.in_kode)
        Me.pnl_content.Controls.Add(Me.in_gudang_n)
        Me.pnl_content.Controls.Add(Me.Label16)
        Me.pnl_content.Controls.Add(Me.Label3)
        Me.pnl_content.Controls.Add(Me.in_gudang)
        Me.pnl_content.Controls.Add(Me.Label20)
        Me.pnl_content.Controls.Add(Me.Label21)
        Me.pnl_content.Controls.Add(Me.in_sat_b)
        Me.pnl_content.Controls.Add(Me.Label4)
        Me.pnl_content.Controls.Add(Me.Label6)
        Me.pnl_content.Controls.Add(Me.in_qty_sys_n)
        Me.pnl_content.Controls.Add(Me.date_tgl_beli)
        Me.pnl_content.Controls.Add(Me.in_qty_b)
        Me.pnl_content.Controls.Add(Me.in_barang_nm)
        Me.pnl_content.Controls.Add(Me.in_barang)
        Me.pnl_content.Controls.Add(Me.cb_pajak)
        Me.pnl_content.Controls.Add(Me.Label18)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Location = New System.Drawing.Point(0, 66)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(1016, 384)
        Me.pnl_content.TabIndex = 0
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Controls.Add(Me.linkLbl_searchbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(376, 173)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(360, 135)
        Me.popPnl_barang.TabIndex = 534
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
        Me.dgv_listbarang.Size = New System.Drawing.Size(360, 127)
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
        'dgv_barang
        '
        Me.dgv_barang.AllowUserToAddRows = False
        Me.dgv_barang.AllowUserToDeleteRows = False
        Me.dgv_barang.BackgroundColor = System.Drawing.Color.White
        Me.dgv_barang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kode, Me.nama, Me.qty_fis_b, Me.sat_fis_b, Me.qty_fis_t, Me.sat_fis_t, Me.qty_fis_k, Me.sat_fis, Me.qty_fis, Me.qty_sys, Me.qty_n_sys, Me.sat_sys, Me.hpp, Me.hpp_fis, Me.nilai_sys, Me.nilai_fis, Me.qty_sel, Me.nilai_sel})
        Me.dgv_barang.Location = New System.Drawing.Point(12, 97)
        Me.dgv_barang.MultiSelect = False
        Me.dgv_barang.Name = "dgv_barang"
        Me.dgv_barang.ReadOnly = True
        Me.dgv_barang.RowHeadersVisible = False
        Me.dgv_barang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_barang.Size = New System.Drawing.Size(997, 178)
        Me.dgv_barang.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(638, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 560
        Me.Label9.Text = "Qty Total"
        '
        'in_qty_total
        '
        Me.in_qty_total.BackColor = System.Drawing.Color.White
        Me.in_qty_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty_total.Location = New System.Drawing.Point(641, 73)
        Me.in_qty_total.Name = "in_qty_total"
        Me.in_qty_total.ReadOnly = True
        Me.in_qty_total.Size = New System.Drawing.Size(70, 20)
        Me.in_qty_total.TabIndex = 14
        Me.in_qty_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_sat_k
        '
        Me.in_sat_k.BackColor = System.Drawing.Color.White
        Me.in_sat_k.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sat_k.Location = New System.Drawing.Point(588, 73)
        Me.in_sat_k.Name = "in_sat_k"
        Me.in_sat_k.ReadOnly = True
        Me.in_sat_k.Size = New System.Drawing.Size(50, 20)
        Me.in_sat_k.TabIndex = 13
        Me.in_sat_k.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(525, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 558
        Me.Label8.Text = "Qty Sat.Kecil"
        '
        'in_qty_k
        '
        Me.in_qty_k.BackColor = System.Drawing.Color.White
        Me.in_qty_k.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty_k.Location = New System.Drawing.Point(528, 73)
        Me.in_qty_k.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.in_qty_k.Name = "in_qty_k"
        Me.in_qty_k.Size = New System.Drawing.Size(60, 20)
        Me.in_qty_k.TabIndex = 12
        Me.in_qty_k.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_sat_t
        '
        Me.in_sat_t.BackColor = System.Drawing.Color.White
        Me.in_sat_t.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sat_t.Location = New System.Drawing.Point(476, 73)
        Me.in_sat_t.Name = "in_sat_t"
        Me.in_sat_t.ReadOnly = True
        Me.in_sat_t.Size = New System.Drawing.Size(50, 20)
        Me.in_sat_t.TabIndex = 11
        Me.in_sat_t.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(413, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 555
        Me.Label2.Text = "Qty Sat.Tengah"
        '
        'in_qty_t
        '
        Me.in_qty_t.BackColor = System.Drawing.Color.White
        Me.in_qty_t.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty_t.Location = New System.Drawing.Point(416, 73)
        Me.in_qty_t.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.in_qty_t.Name = "in_qty_t"
        Me.in_qty_t.Size = New System.Drawing.Size(60, 20)
        Me.in_qty_t.TabIndex = 10
        Me.in_qty_t.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_qty_sys
        '
        Me.in_qty_sys.BackColor = System.Drawing.Color.White
        Me.in_qty_sys.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty_sys.Location = New System.Drawing.Point(808, 73)
        Me.in_qty_sys.Name = "in_qty_sys"
        Me.in_qty_sys.ReadOnly = True
        Me.in_qty_sys.Size = New System.Drawing.Size(70, 20)
        Me.in_qty_sys.TabIndex = 16
        Me.in_qty_sys.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(860, 11)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 551
        Me.Label13.Text = "Status"
        '
        'in_status
        '
        Me.in_status.BackColor = System.Drawing.Color.White
        Me.in_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status.ForeColor = System.Drawing.Color.Black
        Me.in_status.Location = New System.Drawing.Point(903, 7)
        Me.in_status.Name = "in_status"
        Me.in_status.ReadOnly = True
        Me.in_status.Size = New System.Drawing.Size(106, 20)
        Me.in_status.TabIndex = 4
        Me.in_status.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(607, 317)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(43, 13)
        Me.Label29.TabIndex = 546
        Me.Label29.Text = "Inputed"
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(674, 314)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(177, 20)
        Me.txtRegdate.TabIndex = 21
        Me.txtRegdate.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(607, 362)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 549
        Me.Label11.Text = "Process"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(607, 340)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(62, 13)
        Me.Label28.TabIndex = 549
        Me.Label28.Text = "LastUpdate"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(856, 362)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(19, 13)
        Me.Label10.TabIndex = 548
        Me.Label10.Text = "By"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(856, 340)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(19, 13)
        Me.Label30.TabIndex = 548
        Me.Label30.Text = "By"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(856, 318)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(19, 13)
        Me.Label27.TabIndex = 547
        Me.Label27.Text = "By"
        '
        'txtProcAlias
        '
        Me.txtProcAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcAlias.Location = New System.Drawing.Point(879, 358)
        Me.txtProcAlias.Name = "txtProcAlias"
        Me.txtProcAlias.ReadOnly = True
        Me.txtProcAlias.Size = New System.Drawing.Size(130, 20)
        Me.txtProcAlias.TabIndex = 26
        Me.txtProcAlias.TabStop = False
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(879, 336)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(130, 20)
        Me.txtUpdAlias.TabIndex = 24
        Me.txtUpdAlias.TabStop = False
        '
        'txtProcDate
        '
        Me.txtProcDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcDate.Location = New System.Drawing.Point(674, 358)
        Me.txtProcDate.Name = "txtProcDate"
        Me.txtProcDate.ReadOnly = True
        Me.txtProcDate.Size = New System.Drawing.Size(177, 20)
        Me.txtProcDate.TabIndex = 25
        Me.txtProcDate.TabStop = False
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(674, 336)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(177, 20)
        Me.txtUpdDate.TabIndex = 23
        Me.txtUpdDate.TabStop = False
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(879, 314)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(130, 20)
        Me.txtRegAlias.TabIndex = 22
        Me.txtRegAlias.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(9, 278)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 541
        Me.Label1.Text = "Keterangan"
        '
        'in_ket
        '
        Me.in_ket.BackColor = System.Drawing.Color.White
        Me.in_ket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.ForeColor = System.Drawing.Color.Black
        Me.in_ket.Location = New System.Drawing.Point(12, 294)
        Me.in_ket.Multiline = True
        Me.in_ket.Name = "in_ket"
        Me.in_ket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_ket.Size = New System.Drawing.Size(340, 84)
        Me.in_ket.TabIndex = 20
        '
        'bt_tbbarang
        '
        Me.bt_tbbarang.BackColor = System.Drawing.Color.Transparent
        Me.bt_tbbarang.BackgroundImage = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.bt_tbbarang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_tbbarang.FlatAppearance.BorderSize = 0
        Me.bt_tbbarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_tbbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tbbarang.Location = New System.Drawing.Point(987, 73)
        Me.bt_tbbarang.Name = "bt_tbbarang"
        Me.bt_tbbarang.Size = New System.Drawing.Size(18, 18)
        Me.bt_tbbarang.TabIndex = 18
        Me.bt_tbbarang.UseVisualStyleBackColor = False
        '
        'in_hpp
        '
        Me.in_hpp.BackColor = System.Drawing.Color.White
        Me.in_hpp.DecimalPlaces = 2
        Me.in_hpp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_hpp.Location = New System.Drawing.Point(881, 73)
        Me.in_hpp.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.in_hpp.Name = "in_hpp"
        Me.in_hpp.Size = New System.Drawing.Size(100, 20)
        Me.in_hpp.TabIndex = 17
        Me.in_hpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_hpp.ThousandsSeparator = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(878, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 536
        Me.Label7.Text = "HPP"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 532
        Me.Label5.Text = "No. Bukti"
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.White
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.Location = New System.Drawing.Point(72, 6)
        Me.in_kode.MaxLength = 15
        Me.in_kode.Name = "in_kode"
        Me.in_kode.ReadOnly = True
        Me.in_kode.Size = New System.Drawing.Size(172, 20)
        Me.in_kode.TabIndex = 0
        '
        'in_gudang_n
        '
        Me.in_gudang_n.BackColor = System.Drawing.Color.White
        Me.in_gudang_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang_n.ForeColor = System.Drawing.Color.Black
        Me.in_gudang_n.Location = New System.Drawing.Point(429, 29)
        Me.in_gudang_n.MaxLength = 200
        Me.in_gudang_n.Name = "in_gudang_n"
        Me.in_gudang_n.Size = New System.Drawing.Size(262, 20)
        Me.in_gudang_n.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(9, 57)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 13)
        Me.Label16.TabIndex = 530
        Me.Label16.Text = "Kode"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(258, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 531
        Me.Label3.Text = "Gudang Asal"
        '
        'in_gudang
        '
        Me.in_gudang.BackColor = System.Drawing.Color.Gainsboro
        Me.in_gudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang.ForeColor = System.Drawing.Color.Black
        Me.in_gudang.Location = New System.Drawing.Point(332, 29)
        Me.in_gudang.MaxLength = 30
        Me.in_gudang.Name = "in_gudang"
        Me.in_gudang.ReadOnly = True
        Me.in_gudang.Size = New System.Drawing.Size(95, 20)
        Me.in_gudang.TabIndex = 3
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label20.Location = New System.Drawing.Point(107, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 13)
        Me.Label20.TabIndex = 529
        Me.Label20.Text = "Nama"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label21.Location = New System.Drawing.Point(713, 57)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(70, 13)
        Me.Label21.TabIndex = 528
        Me.Label21.Text = "Qty System"
        '
        'in_sat_b
        '
        Me.in_sat_b.BackColor = System.Drawing.Color.White
        Me.in_sat_b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sat_b.Location = New System.Drawing.Point(364, 73)
        Me.in_sat_b.Name = "in_sat_b"
        Me.in_sat_b.ReadOnly = True
        Me.in_sat_b.Size = New System.Drawing.Size(50, 20)
        Me.in_sat_b.TabIndex = 9
        Me.in_sat_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 533
        Me.Label4.Text = "Tanggal"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.Location = New System.Drawing.Point(301, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 527
        Me.Label6.Text = "Qty Sat.Besar"
        '
        'in_qty_sys_n
        '
        Me.in_qty_sys_n.BackColor = System.Drawing.Color.White
        Me.in_qty_sys_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty_sys_n.Location = New System.Drawing.Point(716, 73)
        Me.in_qty_sys_n.Name = "in_qty_sys_n"
        Me.in_qty_sys_n.ReadOnly = True
        Me.in_qty_sys_n.Size = New System.Drawing.Size(89, 20)
        Me.in_qty_sys_n.TabIndex = 15
        Me.in_qty_sys_n.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'date_tgl_beli
        '
        Me.date_tgl_beli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_tgl_beli.Location = New System.Drawing.Point(72, 28)
        Me.date_tgl_beli.MaxDate = New Date(2050, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_beli.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_beli.Name = "date_tgl_beli"
        Me.date_tgl_beli.Size = New System.Drawing.Size(172, 20)
        Me.date_tgl_beli.TabIndex = 1
        '
        'in_qty_b
        '
        Me.in_qty_b.BackColor = System.Drawing.Color.White
        Me.in_qty_b.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_qty_b.Location = New System.Drawing.Point(304, 73)
        Me.in_qty_b.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.in_qty_b.Name = "in_qty_b"
        Me.in_qty_b.Size = New System.Drawing.Size(60, 20)
        Me.in_qty_b.TabIndex = 8
        Me.in_qty_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_barang_nm
        '
        Me.in_barang_nm.BackColor = System.Drawing.Color.White
        Me.in_barang_nm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang_nm.ForeColor = System.Drawing.Color.Black
        Me.in_barang_nm.Location = New System.Drawing.Point(112, 73)
        Me.in_barang_nm.MaxLength = 150
        Me.in_barang_nm.Name = "in_barang_nm"
        Me.in_barang_nm.Size = New System.Drawing.Size(188, 20)
        Me.in_barang_nm.TabIndex = 6
        '
        'in_barang
        '
        Me.in_barang.BackColor = System.Drawing.Color.Gainsboro
        Me.in_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang.Location = New System.Drawing.Point(12, 73)
        Me.in_barang.MaxLength = 20
        Me.in_barang.Name = "in_barang"
        Me.in_barang.Size = New System.Drawing.Size(100, 20)
        Me.in_barang.TabIndex = 5
        '
        'cb_pajak
        '
        Me.cb_pajak.BackColor = System.Drawing.Color.White
        Me.cb_pajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_pajak.ForeColor = System.Drawing.Color.Black
        Me.cb_pajak.FormattingEnabled = True
        Me.cb_pajak.Location = New System.Drawing.Point(332, 6)
        Me.cb_pajak.Name = "cb_pajak"
        Me.cb_pajak.Size = New System.Drawing.Size(151, 21)
        Me.cb_pajak.TabIndex = 2
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(258, 10)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 13)
        Me.Label18.TabIndex = 514
        Me.Label18.Text = "Kategori"
        '
        'pnl_footer
        '
        Me.pnl_footer.AutoScroll = True
        Me.pnl_footer.BackColor = System.Drawing.Color.Gainsboro
        Me.pnl_footer.Controls.Add(Me.bt_simpanbeli)
        Me.pnl_footer.Controls.Add(Me.bt_batalbeli)
        Me.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_footer.Location = New System.Drawing.Point(0, 450)
        Me.pnl_footer.Name = "pnl_footer"
        Me.pnl_footer.Size = New System.Drawing.Size(1016, 50)
        Me.pnl_footer.TabIndex = 25
        '
        'bt_simpanbeli
        '
        Me.bt_simpanbeli.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpanbeli.FlatAppearance.BorderSize = 0
        Me.bt_simpanbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpanbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbeli.ForeColor = System.Drawing.Color.White
        Me.bt_simpanbeli.Location = New System.Drawing.Point(736, 14)
        Me.bt_simpanbeli.Name = "bt_simpanbeli"
        Me.bt_simpanbeli.Size = New System.Drawing.Size(171, 30)
        Me.bt_simpanbeli.TabIndex = 26
        Me.bt_simpanbeli.Text = "Simpan"
        Me.bt_simpanbeli.UseVisualStyleBackColor = False
        '
        'bt_batalbeli
        '
        Me.bt_batalbeli.BackColor = System.Drawing.Color.Tomato
        Me.bt_batalbeli.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalbeli.FlatAppearance.BorderSize = 0
        Me.bt_batalbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_batalbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalbeli.ForeColor = System.Drawing.Color.White
        Me.bt_batalbeli.Location = New System.Drawing.Point(913, 14)
        Me.bt_batalbeli.Name = "bt_batalbeli"
        Me.bt_batalbeli.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalbeli.TabIndex = 27
        Me.bt_batalbeli.Text = "Batal"
        Me.bt_batalbeli.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_print, Me.mn_proses, Me.mn_cancel})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 42)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1016, 24)
        Me.MenuStrip1.TabIndex = 289
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
        'mn_proses
        '
        Me.mn_proses.Image = Global.Inventory.My.Resources.Resources.toolbar_proses_icon
        Me.mn_proses.Name = "mn_proses"
        Me.mn_proses.Size = New System.Drawing.Size(69, 20)
        Me.mn_proses.Text = "Proses"
        Me.mn_proses.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mn_cancel
        '
        Me.mn_cancel.Name = "mn_cancel"
        Me.mn_cancel.Size = New System.Drawing.Size(113, 20)
        Me.mn_cancel.Text = "Batalkan Opname"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 500)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1016, 10)
        Me.Panel2.TabIndex = 288
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
        'qty_fis_b
        '
        Me.qty_fis_b.HeaderText = "Qty Besar"
        Me.qty_fis_b.Name = "qty_fis_b"
        Me.qty_fis_b.ReadOnly = True
        Me.qty_fis_b.Width = 75
        '
        'sat_fis_b
        '
        Me.sat_fis_b.HeaderText = "Sat. Besar"
        Me.sat_fis_b.Name = "sat_fis_b"
        Me.sat_fis_b.ReadOnly = True
        Me.sat_fis_b.Width = 50
        '
        'qty_fis_t
        '
        Me.qty_fis_t.HeaderText = "Qty Tengah"
        Me.qty_fis_t.Name = "qty_fis_t"
        Me.qty_fis_t.ReadOnly = True
        Me.qty_fis_t.Width = 75
        '
        'sat_fis_t
        '
        Me.sat_fis_t.HeaderText = "Sat. Tengah"
        Me.sat_fis_t.Name = "sat_fis_t"
        Me.sat_fis_t.ReadOnly = True
        Me.sat_fis_t.Width = 50
        '
        'qty_fis_k
        '
        Me.qty_fis_k.HeaderText = "Qty Kecil"
        Me.qty_fis_k.Name = "qty_fis_k"
        Me.qty_fis_k.ReadOnly = True
        Me.qty_fis_k.Width = 75
        '
        'sat_fis
        '
        Me.sat_fis.HeaderText = "Sat. Kecil"
        Me.sat_fis.MinimumWidth = 65
        Me.sat_fis.Name = "sat_fis"
        Me.sat_fis.ReadOnly = True
        Me.sat_fis.Width = 65
        '
        'qty_fis
        '
        Me.qty_fis.HeaderText = "Qty Total"
        Me.qty_fis.MinimumWidth = 65
        Me.qty_fis.Name = "qty_fis"
        Me.qty_fis.ReadOnly = True
        Me.qty_fis.Width = 70
        '
        'qty_sys
        '
        Me.qty_sys.DataPropertyName = "trans_qty"
        Me.qty_sys.HeaderText = "QTY Sys."
        Me.qty_sys.MinimumWidth = 65
        Me.qty_sys.Name = "qty_sys"
        Me.qty_sys.ReadOnly = True
        Me.qty_sys.Width = 75
        '
        'qty_n_sys
        '
        Me.qty_n_sys.HeaderText = "Qty Sys. Det."
        Me.qty_n_sys.Name = "qty_n_sys"
        Me.qty_n_sys.ReadOnly = True
        '
        'sat_sys
        '
        Me.sat_sys.DataPropertyName = "trans_satuan"
        Me.sat_sys.HeaderText = "Sat. Sys."
        Me.sat_sys.MinimumWidth = 65
        Me.sat_sys.Name = "sat_sys"
        Me.sat_sys.ReadOnly = True
        Me.sat_sys.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.sat_sys.Width = 65
        '
        'hpp
        '
        Me.hpp.HeaderText = "HPP System"
        Me.hpp.Name = "hpp"
        Me.hpp.ReadOnly = True
        Me.hpp.Visible = False
        '
        'hpp_fis
        '
        Me.hpp_fis.HeaderText = "HPP"
        Me.hpp_fis.Name = "hpp_fis"
        Me.hpp_fis.ReadOnly = True
        '
        'nilai_sys
        '
        Me.nilai_sys.HeaderText = "Nilai Pers. Sys."
        Me.nilai_sys.Name = "nilai_sys"
        Me.nilai_sys.ReadOnly = True
        Me.nilai_sys.Visible = False
        '
        'nilai_fis
        '
        Me.nilai_fis.HeaderText = "Nilai Pers. Fis."
        Me.nilai_fis.Name = "nilai_fis"
        Me.nilai_fis.ReadOnly = True
        Me.nilai_fis.Visible = False
        '
        'qty_sel
        '
        Me.qty_sel.HeaderText = "Selisih"
        Me.qty_sel.MinimumWidth = 65
        Me.qty_sel.Name = "qty_sel"
        Me.qty_sel.ReadOnly = True
        Me.qty_sel.Width = 65
        '
        'nilai_sel
        '
        Me.nilai_sel.HeaderText = "Selisih Nilai"
        Me.nilai_sel.Name = "nilai_sel"
        Me.nilai_sel.ReadOnly = True
        Me.nilai_sel.Visible = False
        '
        'fr_stock_op
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 510)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.pnl_footer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_stock_op"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "StokOp : "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.popPnl_barang.ResumeLayout(False)
        Me.popPnl_barang.PerformLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_qty_k, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_qty_t, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_hpp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_qty_b, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_footer.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents pnl_footer As System.Windows.Forms.Panel
    Friend WithEvents bt_simpanbeli As System.Windows.Forms.Button
    Friend WithEvents bt_batalbeli As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_proses As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_cancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cb_pajak As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents linkLbl_searchbarang As System.Windows.Forms.LinkLabel
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
    Friend WithEvents bt_tbbarang As System.Windows.Forms.Button
    Friend WithEvents in_hpp As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents dgv_barang As System.Windows.Forms.DataGridView
    Friend WithEvents in_gudang_n As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents in_gudang As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents in_sat_b As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents in_qty_sys_n As System.Windows.Forms.TextBox
    Friend WithEvents date_tgl_beli As System.Windows.Forms.DateTimePicker
    Friend WithEvents in_qty_b As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_barang_nm As System.Windows.Forms.TextBox
    Friend WithEvents in_barang As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents in_status As System.Windows.Forms.TextBox
    Friend WithEvents in_qty_sys As System.Windows.Forms.TextBox
    Friend WithEvents in_qty_total As System.Windows.Forms.TextBox
    Friend WithEvents in_sat_k As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents in_qty_k As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_sat_t As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_qty_t As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtProcAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtProcDate As System.Windows.Forms.TextBox
    Friend WithEvents kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_fis_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_fis_b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_fis_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_fis_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_fis_k As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_fis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_fis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_sys As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_n_sys As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sat_sys As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hpp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hpp_fis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nilai_sys As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nilai_fis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty_sel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nilai_sel As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
