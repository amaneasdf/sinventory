<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_sales_set_det
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.in_sales_n = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_sales = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tb_gudang = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bt_remall_gudang = New System.Windows.Forms.Button()
        Me.bt_rem_gudang = New System.Windows.Forms.Button()
        Me.bt_add_gudang = New System.Windows.Forms.Button()
        Me.bt_cari_gudang = New System.Windows.Forms.Button()
        Me.in_cari_gudang = New System.Windows.Forms.TextBox()
        Me.dgv_gudang_slct = New System.Windows.Forms.DataGridView()
        Me.gs_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gs_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gs_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv_gudang_mstr = New System.Windows.Forms.DataGridView()
        Me.gdg_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gdg_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gdg_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tb_barang = New System.Windows.Forms.TabPage()
        Me.bt_remall_brg = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bt_rem_brg = New System.Windows.Forms.Button()
        Me.bt_add_brg = New System.Windows.Forms.Button()
        Me.bt_cari_barang = New System.Windows.Forms.Button()
        Me.in_cari_barang = New System.Windows.Forms.TextBox()
        Me.dgv_barang_slct = New System.Windows.Forms.DataGridView()
        Me.sb_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sb_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sb_kat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sb_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv_barang_mstr = New System.Windows.Forms.DataGridView()
        Me.barang_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.barang_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.barang_kat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.barang_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bt_simpanbeli = New System.Windows.Forms.Button()
        Me.bt_batalbeli = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.pnl_content.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tb_gudang.SuspendLayout()
        CType(Me.dgv_gudang_slct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_gudang_mstr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tb_barang.SuspendLayout()
        CType(Me.dgv_barang_slct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_barang_mstr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.lbl_title)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(676, 34)
        Me.Panel1.TabIndex = 286
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
        Me.bt_cl.Location = New System.Drawing.Point(649, 6)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 8
        Me.bt_cl.TabStop = False
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Orange
        Me.lbl_title.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(6, 6)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(215, 20)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Set Gudang/Barang Salesman"
        '
        'pnl_content
        '
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.BackColor = System.Drawing.Color.White
        Me.pnl_content.Controls.Add(Me.in_sales_n)
        Me.pnl_content.Controls.Add(Me.Label5)
        Me.pnl_content.Controls.Add(Me.in_sales)
        Me.pnl_content.Controls.Add(Me.TabControl1)
        Me.pnl_content.Controls.Add(Me.Label1)
        Me.pnl_content.Controls.Add(Me.bt_simpanbeli)
        Me.pnl_content.Controls.Add(Me.bt_batalbeli)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Location = New System.Drawing.Point(0, 34)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(676, 484)
        Me.pnl_content.TabIndex = 0
        '
        'in_sales_n
        '
        Me.in_sales_n.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales_n.Location = New System.Drawing.Point(346, 7)
        Me.in_sales_n.Name = "in_sales_n"
        Me.in_sales_n.ReadOnly = True
        Me.in_sales_n.Size = New System.Drawing.Size(269, 24)
        Me.in_sales_n.TabIndex = 40
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(251, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 15)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Nama Salesman"
        '
        'in_sales
        '
        Me.in_sales.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales.Location = New System.Drawing.Point(51, 7)
        Me.in_sales.Name = "in_sales"
        Me.in_sales.ReadOnly = True
        Me.in_sales.Size = New System.Drawing.Size(164, 24)
        Me.in_sales.TabIndex = 38
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tb_gudang)
        Me.TabControl1.Controls.Add(Me.tb_barang)
        Me.TabControl1.Location = New System.Drawing.Point(3, 38)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(670, 407)
        Me.TabControl1.TabIndex = 37
        '
        'tb_gudang
        '
        Me.tb_gudang.Controls.Add(Me.Label6)
        Me.tb_gudang.Controls.Add(Me.Label2)
        Me.tb_gudang.Controls.Add(Me.bt_remall_gudang)
        Me.tb_gudang.Controls.Add(Me.bt_rem_gudang)
        Me.tb_gudang.Controls.Add(Me.bt_add_gudang)
        Me.tb_gudang.Controls.Add(Me.bt_cari_gudang)
        Me.tb_gudang.Controls.Add(Me.in_cari_gudang)
        Me.tb_gudang.Controls.Add(Me.dgv_gudang_slct)
        Me.tb_gudang.Controls.Add(Me.dgv_gudang_mstr)
        Me.tb_gudang.Location = New System.Drawing.Point(4, 24)
        Me.tb_gudang.Name = "tb_gudang"
        Me.tb_gudang.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_gudang.Size = New System.Drawing.Size(662, 379)
        Me.tb_gudang.TabIndex = 0
        Me.tb_gudang.Text = "Gudang"
        Me.tb_gudang.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 15)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Gudang:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(353, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Gudang Terpilih:"
        '
        'bt_remall_gudang
        '
        Me.bt_remall_gudang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_remall_gudang.Image = Global.Inventory.My.Resources.Resources.Delete_16x16
        Me.bt_remall_gudang.Location = New System.Drawing.Point(566, 346)
        Me.bt_remall_gudang.Name = "bt_remall_gudang"
        Me.bt_remall_gudang.Size = New System.Drawing.Size(90, 27)
        Me.bt_remall_gudang.TabIndex = 8
        Me.bt_remall_gudang.Text = "   Clear All"
        Me.bt_remall_gudang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_remall_gudang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_remall_gudang.UseVisualStyleBackColor = True
        '
        'bt_rem_gudang
        '
        Me.bt_rem_gudang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_rem_gudang.Image = Global.Inventory.My.Resources.Resources.Delete_16x16
        Me.bt_rem_gudang.Location = New System.Drawing.Point(313, 66)
        Me.bt_rem_gudang.Name = "bt_rem_gudang"
        Me.bt_rem_gudang.Size = New System.Drawing.Size(36, 36)
        Me.bt_rem_gudang.TabIndex = 8
        Me.bt_rem_gudang.UseVisualStyleBackColor = True
        '
        'bt_add_gudang
        '
        Me.bt_add_gudang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_add_gudang.Image = Global.Inventory.My.Resources.Resources.Add_16x16
        Me.bt_add_gudang.Location = New System.Drawing.Point(313, 29)
        Me.bt_add_gudang.Name = "bt_add_gudang"
        Me.bt_add_gudang.Size = New System.Drawing.Size(36, 36)
        Me.bt_add_gudang.TabIndex = 7
        Me.bt_add_gudang.UseVisualStyleBackColor = True
        '
        'bt_cari_gudang
        '
        Me.bt_cari_gudang.BackColor = System.Drawing.Color.SteelBlue
        Me.bt_cari_gudang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_cari_gudang.FlatAppearance.BorderSize = 0
        Me.bt_cari_gudang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cari_gudang.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cari_gudang.ForeColor = System.Drawing.Color.White
        Me.bt_cari_gudang.Image = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.bt_cari_gudang.Location = New System.Drawing.Point(247, 346)
        Me.bt_cari_gudang.Name = "bt_cari_gudang"
        Me.bt_cari_gudang.Size = New System.Drawing.Size(59, 25)
        Me.bt_cari_gudang.TabIndex = 4
        Me.bt_cari_gudang.Text = "Cari"
        Me.bt_cari_gudang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_cari_gudang.UseVisualStyleBackColor = False
        '
        'in_cari_gudang
        '
        Me.in_cari_gudang.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari_gudang.Location = New System.Drawing.Point(6, 346)
        Me.in_cari_gudang.Name = "in_cari_gudang"
        Me.in_cari_gudang.Size = New System.Drawing.Size(241, 25)
        Me.in_cari_gudang.TabIndex = 3
        '
        'dgv_gudang_slct
        '
        Me.dgv_gudang_slct.AllowUserToAddRows = False
        Me.dgv_gudang_slct.AllowUserToDeleteRows = False
        Me.dgv_gudang_slct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_gudang_slct.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gs_kode, Me.gs_nama, Me.gs_status})
        Me.dgv_gudang_slct.Location = New System.Drawing.Point(356, 29)
        Me.dgv_gudang_slct.Name = "dgv_gudang_slct"
        Me.dgv_gudang_slct.ReadOnly = True
        Me.dgv_gudang_slct.RowHeadersVisible = False
        Me.dgv_gudang_slct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_gudang_slct.Size = New System.Drawing.Size(300, 311)
        Me.dgv_gudang_slct.TabIndex = 0
        '
        'gs_kode
        '
        Me.gs_kode.HeaderText = "Kode"
        Me.gs_kode.MinimumWidth = 50
        Me.gs_kode.Name = "gs_kode"
        Me.gs_kode.ReadOnly = True
        Me.gs_kode.Width = 75
        '
        'gs_nama
        '
        Me.gs_nama.HeaderText = "Nama Gudang"
        Me.gs_nama.MinimumWidth = 75
        Me.gs_nama.Name = "gs_nama"
        Me.gs_nama.ReadOnly = True
        Me.gs_nama.Width = 200
        '
        'gs_status
        '
        Me.gs_status.HeaderText = "Status"
        Me.gs_status.Name = "gs_status"
        Me.gs_status.ReadOnly = True
        '
        'dgv_gudang_mstr
        '
        Me.dgv_gudang_mstr.AllowUserToAddRows = False
        Me.dgv_gudang_mstr.AllowUserToDeleteRows = False
        Me.dgv_gudang_mstr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_gudang_mstr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gdg_kode, Me.gdg_nama, Me.gdg_status})
        Me.dgv_gudang_mstr.Location = New System.Drawing.Point(6, 29)
        Me.dgv_gudang_mstr.Name = "dgv_gudang_mstr"
        Me.dgv_gudang_mstr.ReadOnly = True
        Me.dgv_gudang_mstr.RowHeadersVisible = False
        Me.dgv_gudang_mstr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_gudang_mstr.Size = New System.Drawing.Size(300, 311)
        Me.dgv_gudang_mstr.TabIndex = 0
        '
        'gdg_kode
        '
        Me.gdg_kode.DataPropertyName = "gudang_kode"
        Me.gdg_kode.HeaderText = "Kode"
        Me.gdg_kode.MinimumWidth = 25
        Me.gdg_kode.Name = "gdg_kode"
        Me.gdg_kode.ReadOnly = True
        Me.gdg_kode.Width = 75
        '
        'gdg_nama
        '
        Me.gdg_nama.DataPropertyName = "gudang_nama"
        Me.gdg_nama.HeaderText = "Nama Gudang"
        Me.gdg_nama.MinimumWidth = 50
        Me.gdg_nama.Name = "gdg_nama"
        Me.gdg_nama.ReadOnly = True
        Me.gdg_nama.Width = 200
        '
        'gdg_status
        '
        Me.gdg_status.DataPropertyName = "gudang_status"
        Me.gdg_status.HeaderText = "Status"
        Me.gdg_status.Name = "gdg_status"
        Me.gdg_status.ReadOnly = True
        '
        'tb_barang
        '
        Me.tb_barang.Controls.Add(Me.bt_remall_brg)
        Me.tb_barang.Controls.Add(Me.Label3)
        Me.tb_barang.Controls.Add(Me.Label4)
        Me.tb_barang.Controls.Add(Me.bt_rem_brg)
        Me.tb_barang.Controls.Add(Me.bt_add_brg)
        Me.tb_barang.Controls.Add(Me.bt_cari_barang)
        Me.tb_barang.Controls.Add(Me.in_cari_barang)
        Me.tb_barang.Controls.Add(Me.dgv_barang_slct)
        Me.tb_barang.Controls.Add(Me.dgv_barang_mstr)
        Me.tb_barang.Location = New System.Drawing.Point(4, 24)
        Me.tb_barang.Name = "tb_barang"
        Me.tb_barang.Padding = New System.Windows.Forms.Padding(3)
        Me.tb_barang.Size = New System.Drawing.Size(662, 379)
        Me.tb_barang.TabIndex = 1
        Me.tb_barang.Text = "Barang"
        Me.tb_barang.UseVisualStyleBackColor = True
        '
        'bt_remall_brg
        '
        Me.bt_remall_brg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_remall_brg.Image = Global.Inventory.My.Resources.Resources.Delete_16x16
        Me.bt_remall_brg.Location = New System.Drawing.Point(566, 344)
        Me.bt_remall_brg.Name = "bt_remall_brg"
        Me.bt_remall_brg.Size = New System.Drawing.Size(90, 27)
        Me.bt_remall_brg.TabIndex = 19
        Me.bt_remall_brg.Text = "   Clear All"
        Me.bt_remall_brg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_remall_brg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_remall_brg.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(353, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 15)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Barang Terpilih:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 15)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Barang:"
        '
        'bt_rem_brg
        '
        Me.bt_rem_brg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_rem_brg.Image = Global.Inventory.My.Resources.Resources.Delete_16x16
        Me.bt_rem_brg.Location = New System.Drawing.Point(313, 66)
        Me.bt_rem_brg.Name = "bt_rem_brg"
        Me.bt_rem_brg.Size = New System.Drawing.Size(36, 36)
        Me.bt_rem_brg.TabIndex = 16
        Me.bt_rem_brg.Text = "-"
        Me.bt_rem_brg.UseVisualStyleBackColor = True
        '
        'bt_add_brg
        '
        Me.bt_add_brg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_add_brg.Image = Global.Inventory.My.Resources.Resources.Add_16x16
        Me.bt_add_brg.Location = New System.Drawing.Point(313, 29)
        Me.bt_add_brg.Name = "bt_add_brg"
        Me.bt_add_brg.Size = New System.Drawing.Size(36, 36)
        Me.bt_add_brg.TabIndex = 14
        Me.bt_add_brg.Text = "+"
        Me.bt_add_brg.UseVisualStyleBackColor = True
        '
        'bt_cari_barang
        '
        Me.bt_cari_barang.BackColor = System.Drawing.Color.SteelBlue
        Me.bt_cari_barang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_cari_barang.FlatAppearance.BorderSize = 0
        Me.bt_cari_barang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cari_barang.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cari_barang.ForeColor = System.Drawing.Color.White
        Me.bt_cari_barang.Image = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.bt_cari_barang.Location = New System.Drawing.Point(247, 346)
        Me.bt_cari_barang.Name = "bt_cari_barang"
        Me.bt_cari_barang.Size = New System.Drawing.Size(59, 25)
        Me.bt_cari_barang.TabIndex = 13
        Me.bt_cari_barang.Text = "Cari"
        Me.bt_cari_barang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_cari_barang.UseVisualStyleBackColor = False
        '
        'in_cari_barang
        '
        Me.in_cari_barang.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari_barang.Location = New System.Drawing.Point(6, 346)
        Me.in_cari_barang.Name = "in_cari_barang"
        Me.in_cari_barang.Size = New System.Drawing.Size(241, 25)
        Me.in_cari_barang.TabIndex = 12
        '
        'dgv_barang_slct
        '
        Me.dgv_barang_slct.AllowUserToAddRows = False
        Me.dgv_barang_slct.AllowUserToDeleteRows = False
        Me.dgv_barang_slct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_barang_slct.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sb_kode, Me.sb_nama, Me.sb_kat, Me.sb_status})
        Me.dgv_barang_slct.Location = New System.Drawing.Point(356, 29)
        Me.dgv_barang_slct.Name = "dgv_barang_slct"
        Me.dgv_barang_slct.ReadOnly = True
        Me.dgv_barang_slct.RowHeadersVisible = False
        Me.dgv_barang_slct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_barang_slct.Size = New System.Drawing.Size(300, 311)
        Me.dgv_barang_slct.TabIndex = 11
        '
        'sb_kode
        '
        Me.sb_kode.DataPropertyName = "barang_kode"
        Me.sb_kode.HeaderText = "Kode"
        Me.sb_kode.MinimumWidth = 50
        Me.sb_kode.Name = "sb_kode"
        Me.sb_kode.ReadOnly = True
        Me.sb_kode.Width = 75
        '
        'sb_nama
        '
        Me.sb_nama.DataPropertyName = "barang_nama"
        Me.sb_nama.HeaderText = "Nama Barang"
        Me.sb_nama.MinimumWidth = 75
        Me.sb_nama.Name = "sb_nama"
        Me.sb_nama.ReadOnly = True
        Me.sb_nama.Width = 200
        '
        'sb_kat
        '
        Me.sb_kat.DataPropertyName = "barang_kat"
        Me.sb_kat.HeaderText = "Kat."
        Me.sb_kat.Name = "sb_kat"
        Me.sb_kat.ReadOnly = True
        Me.sb_kat.Width = 50
        '
        'sb_status
        '
        Me.sb_status.DataPropertyName = "barang_status"
        Me.sb_status.HeaderText = "Status"
        Me.sb_status.Name = "sb_status"
        Me.sb_status.ReadOnly = True
        '
        'dgv_barang_mstr
        '
        Me.dgv_barang_mstr.AllowUserToAddRows = False
        Me.dgv_barang_mstr.AllowUserToDeleteRows = False
        Me.dgv_barang_mstr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_barang_mstr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.barang_kode, Me.barang_nama, Me.barang_kat, Me.barang_status})
        Me.dgv_barang_mstr.Location = New System.Drawing.Point(6, 29)
        Me.dgv_barang_mstr.Name = "dgv_barang_mstr"
        Me.dgv_barang_mstr.ReadOnly = True
        Me.dgv_barang_mstr.RowHeadersVisible = False
        Me.dgv_barang_mstr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_barang_mstr.Size = New System.Drawing.Size(300, 311)
        Me.dgv_barang_mstr.TabIndex = 11
        '
        'barang_kode
        '
        Me.barang_kode.DataPropertyName = "barang_kode"
        Me.barang_kode.HeaderText = "Kode"
        Me.barang_kode.MinimumWidth = 50
        Me.barang_kode.Name = "barang_kode"
        Me.barang_kode.ReadOnly = True
        Me.barang_kode.Width = 75
        '
        'barang_nama
        '
        Me.barang_nama.DataPropertyName = "barang_nama"
        Me.barang_nama.HeaderText = "Nama Barang"
        Me.barang_nama.MinimumWidth = 75
        Me.barang_nama.Name = "barang_nama"
        Me.barang_nama.ReadOnly = True
        Me.barang_nama.Width = 200
        '
        'barang_kat
        '
        Me.barang_kat.DataPropertyName = "barang_kat"
        Me.barang_kat.HeaderText = "Kat."
        Me.barang_kat.Name = "barang_kat"
        Me.barang_kat.ReadOnly = True
        Me.barang_kat.Width = 50
        '
        'barang_status
        '
        Me.barang_status.DataPropertyName = "barang_status"
        Me.barang_status.HeaderText = "Status"
        Me.barang_status.Name = "barang_status"
        Me.barang_status.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Kode"
        '
        'bt_simpanbeli
        '
        Me.bt_simpanbeli.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpanbeli.FlatAppearance.BorderSize = 0
        Me.bt_simpanbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpanbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbeli.ForeColor = System.Drawing.Color.White
        Me.bt_simpanbeli.Location = New System.Drawing.Point(396, 446)
        Me.bt_simpanbeli.Name = "bt_simpanbeli"
        Me.bt_simpanbeli.Size = New System.Drawing.Size(171, 30)
        Me.bt_simpanbeli.TabIndex = 35
        Me.bt_simpanbeli.Text = "Simpan"
        Me.bt_simpanbeli.UseVisualStyleBackColor = False
        '
        'bt_batalbeli
        '
        Me.bt_batalbeli.BackColor = System.Drawing.Color.Tomato
        Me.bt_batalbeli.FlatAppearance.BorderSize = 0
        Me.bt_batalbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_batalbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalbeli.ForeColor = System.Drawing.Color.White
        Me.bt_batalbeli.Location = New System.Drawing.Point(573, 446)
        Me.bt_batalbeli.Name = "bt_batalbeli"
        Me.bt_batalbeli.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalbeli.TabIndex = 36
        Me.bt_batalbeli.Text = "Batal"
        Me.bt_batalbeli.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 518)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(676, 10)
        Me.Panel3.TabIndex = 288
        '
        'fr_sales_set_det
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 528)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fr_sales_set_det"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tb_gudang.ResumeLayout(False)
        Me.tb_gudang.PerformLayout()
        CType(Me.dgv_gudang_slct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_gudang_mstr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tb_barang.ResumeLayout(False)
        Me.tb_barang.PerformLayout()
        CType(Me.dgv_barang_slct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_barang_mstr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents bt_simpanbeli As System.Windows.Forms.Button
    Friend WithEvents bt_batalbeli As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tb_gudang As System.Windows.Forms.TabPage
    Friend WithEvents tb_barang As System.Windows.Forms.TabPage
    Friend WithEvents dgv_gudang_mstr As System.Windows.Forms.DataGridView
    Friend WithEvents bt_cari_gudang As System.Windows.Forms.Button
    Friend WithEvents in_cari_gudang As System.Windows.Forms.TextBox
    Friend WithEvents in_sales_n As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_sales As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bt_remall_gudang As System.Windows.Forms.Button
    Friend WithEvents bt_rem_gudang As System.Windows.Forms.Button
    Friend WithEvents bt_add_gudang As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents bt_rem_brg As System.Windows.Forms.Button
    Friend WithEvents bt_add_brg As System.Windows.Forms.Button
    Friend WithEvents bt_cari_barang As System.Windows.Forms.Button
    Friend WithEvents in_cari_barang As System.Windows.Forms.TextBox
    Friend WithEvents dgv_barang_mstr As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gdg_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gdg_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gdg_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgv_gudang_slct As System.Windows.Forms.DataGridView
    Friend WithEvents gs_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gs_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gs_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents barang_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents barang_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents barang_kat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents barang_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bt_remall_brg As System.Windows.Forms.Button
    Friend WithEvents dgv_barang_slct As System.Windows.Forms.DataGridView
    Friend WithEvents sb_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sb_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sb_kat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sb_status As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
