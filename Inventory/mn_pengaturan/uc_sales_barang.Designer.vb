<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_sales_barang
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.bt_clear = New System.Windows.Forms.Button()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.linkLbl_searchbarang = New System.Windows.Forms.LinkLabel()
        Me.bt_tbbarang = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.in_status = New System.Windows.Forms.TextBox()
        Me.in_sales_j = New System.Windows.Forms.TextBox()
        Me.in_barang_n = New System.Windows.Forms.TextBox()
        Me.in_gudang_n = New System.Windows.Forms.TextBox()
        Me.in_sales_n = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_barang = New System.Windows.Forms.TextBox()
        Me.in_gudang = New System.Windows.Forms.TextBox()
        Me.in_sales = New System.Windows.Forms.TextBox()
        Me.dgv_barang = New System.Windows.Forms.DataGridView()
        Me.barang_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.barang_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.barang_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ck_allitem = New System.Windows.Forms.CheckBox()
        Me.ck_setgudang = New System.Windows.Forms.CheckBox()
        Me.pnl_footer = New System.Windows.Forms.Panel()
        Me.bt_simpanbeli = New System.Windows.Forms.Button()
        Me.bt_batalbeli = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnl_dgv = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.bt_refresh = New System.Windows.Forms.Button()
        Me.bt_cari = New System.Windows.Forms.Button()
        Me.in_cari = New System.Windows.Forms.TextBox()
        Me.dgv_sales = New System.Windows.Forms.DataGridView()
        Me.sales_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sales_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sales_jenis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sales_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.pnl_content.SuspendLayout()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_footer.SuspendLayout()
        Me.pnl_dgv.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgv_sales, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(928, 42)
        Me.Panel1.TabIndex = 1
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(848, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(901, 9)
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
        Me.lbl_title.Size = New System.Drawing.Size(282, 31)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Setting Barang Salesman"
        '
        'pnl_content
        '
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.Controls.Add(Me.bt_clear)
        Me.pnl_content.Controls.Add(Me.popPnl_barang)
        Me.pnl_content.Controls.Add(Me.bt_tbbarang)
        Me.pnl_content.Controls.Add(Me.Label24)
        Me.pnl_content.Controls.Add(Me.in_status)
        Me.pnl_content.Controls.Add(Me.in_sales_j)
        Me.pnl_content.Controls.Add(Me.in_barang_n)
        Me.pnl_content.Controls.Add(Me.in_gudang_n)
        Me.pnl_content.Controls.Add(Me.in_sales_n)
        Me.pnl_content.Controls.Add(Me.Label4)
        Me.pnl_content.Controls.Add(Me.Label3)
        Me.pnl_content.Controls.Add(Me.Label2)
        Me.pnl_content.Controls.Add(Me.Label1)
        Me.pnl_content.Controls.Add(Me.in_barang)
        Me.pnl_content.Controls.Add(Me.in_gudang)
        Me.pnl_content.Controls.Add(Me.in_sales)
        Me.pnl_content.Controls.Add(Me.dgv_barang)
        Me.pnl_content.Controls.Add(Me.ck_allitem)
        Me.pnl_content.Controls.Add(Me.ck_setgudang)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_content.Location = New System.Drawing.Point(319, 42)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(609, 438)
        Me.pnl_content.TabIndex = 1
        '
        'bt_clear
        '
        Me.bt_clear.BackColor = System.Drawing.Color.Tomato
        Me.bt_clear.FlatAppearance.BorderSize = 0
        Me.bt_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_clear.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold)
        Me.bt_clear.ForeColor = System.Drawing.Color.White
        Me.bt_clear.Location = New System.Drawing.Point(480, 203)
        Me.bt_clear.Name = "bt_clear"
        Me.bt_clear.Size = New System.Drawing.Size(96, 22)
        Me.bt_clear.TabIndex = 39
        Me.bt_clear.Text = "Clear Barang"
        Me.bt_clear.UseVisualStyleBackColor = False
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Controls.Add(Me.linkLbl_searchbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(506, 264)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(375, 135)
        Me.popPnl_barang.TabIndex = 0
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
        Me.dgv_listbarang.Size = New System.Drawing.Size(375, 132)
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
        'bt_tbbarang
        '
        Me.bt_tbbarang.BackColor = System.Drawing.Color.Transparent
        Me.bt_tbbarang.BackgroundImage = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.bt_tbbarang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_tbbarang.FlatAppearance.BorderSize = 0
        Me.bt_tbbarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_tbbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tbbarang.Location = New System.Drawing.Point(408, 204)
        Me.bt_tbbarang.Name = "bt_tbbarang"
        Me.bt_tbbarang.Size = New System.Drawing.Size(18, 18)
        Me.bt_tbbarang.TabIndex = 38
        Me.bt_tbbarang.UseVisualStyleBackColor = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.Label24.Location = New System.Drawing.Point(263, 486)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(28, 31)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "  "
        '
        'in_status
        '
        Me.in_status.BackColor = System.Drawing.Color.White
        Me.in_status.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status.Location = New System.Drawing.Point(77, 45)
        Me.in_status.Name = "in_status"
        Me.in_status.ReadOnly = True
        Me.in_status.Size = New System.Drawing.Size(110, 22)
        Me.in_status.TabIndex = 3
        '
        'in_sales_j
        '
        Me.in_sales_j.BackColor = System.Drawing.Color.White
        Me.in_sales_j.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales_j.Location = New System.Drawing.Point(423, 17)
        Me.in_sales_j.Name = "in_sales_j"
        Me.in_sales_j.ReadOnly = True
        Me.in_sales_j.Size = New System.Drawing.Size(104, 22)
        Me.in_sales_j.TabIndex = 2
        Me.in_sales_j.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'in_barang_n
        '
        Me.in_barang_n.BackColor = System.Drawing.Color.White
        Me.in_barang_n.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang_n.Location = New System.Drawing.Point(130, 203)
        Me.in_barang_n.Name = "in_barang_n"
        Me.in_barang_n.Size = New System.Drawing.Size(272, 22)
        Me.in_barang_n.TabIndex = 6
        '
        'in_gudang_n
        '
        Me.in_gudang_n.BackColor = System.Drawing.Color.White
        Me.in_gudang_n.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang_n.Location = New System.Drawing.Point(188, 120)
        Me.in_gudang_n.Name = "in_gudang_n"
        Me.in_gudang_n.Size = New System.Drawing.Size(272, 22)
        Me.in_gudang_n.TabIndex = 6
        '
        'in_sales_n
        '
        Me.in_sales_n.BackColor = System.Drawing.Color.White
        Me.in_sales_n.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales_n.Location = New System.Drawing.Point(188, 17)
        Me.in_sales_n.Name = "in_sales_n"
        Me.in_sales_n.ReadOnly = True
        Me.in_sales_n.Size = New System.Drawing.Size(229, 22)
        Me.in_sales_n.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 15)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Barang :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Gudang :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Salesman"
        '
        'in_barang
        '
        Me.in_barang.BackColor = System.Drawing.Color.Gainsboro
        Me.in_barang.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang.Location = New System.Drawing.Point(19, 203)
        Me.in_barang.Name = "in_barang"
        Me.in_barang.ReadOnly = True
        Me.in_barang.Size = New System.Drawing.Size(110, 22)
        Me.in_barang.TabIndex = 5
        '
        'in_gudang
        '
        Me.in_gudang.BackColor = System.Drawing.Color.Gainsboro
        Me.in_gudang.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang.Location = New System.Drawing.Point(77, 120)
        Me.in_gudang.Name = "in_gudang"
        Me.in_gudang.ReadOnly = True
        Me.in_gudang.Size = New System.Drawing.Size(110, 22)
        Me.in_gudang.TabIndex = 5
        '
        'in_sales
        '
        Me.in_sales.BackColor = System.Drawing.Color.Gainsboro
        Me.in_sales.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales.Location = New System.Drawing.Point(77, 17)
        Me.in_sales.Name = "in_sales"
        Me.in_sales.ReadOnly = True
        Me.in_sales.Size = New System.Drawing.Size(110, 22)
        Me.in_sales.TabIndex = 0
        '
        'dgv_barang
        '
        Me.dgv_barang.AllowUserToAddRows = False
        Me.dgv_barang.AllowUserToDeleteRows = False
        Me.dgv_barang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_barang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.barang_kode, Me.barang_nama, Me.barang_status})
        Me.dgv_barang.Location = New System.Drawing.Point(19, 231)
        Me.dgv_barang.Name = "dgv_barang"
        Me.dgv_barang.ReadOnly = True
        Me.dgv_barang.RowHeadersVisible = False
        Me.dgv_barang.Size = New System.Drawing.Size(557, 252)
        Me.dgv_barang.TabIndex = 10
        '
        'barang_kode
        '
        Me.barang_kode.HeaderText = "Kode"
        Me.barang_kode.Name = "barang_kode"
        Me.barang_kode.ReadOnly = True
        Me.barang_kode.Width = 150
        '
        'barang_nama
        '
        Me.barang_nama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.barang_nama.HeaderText = "Nama Barang"
        Me.barang_nama.Name = "barang_nama"
        Me.barang_nama.ReadOnly = True
        '
        'barang_status
        '
        Me.barang_status.HeaderText = "Status"
        Me.barang_status.Name = "barang_status"
        Me.barang_status.ReadOnly = True
        '
        'ck_allitem
        '
        Me.ck_allitem.AutoSize = True
        Me.ck_allitem.Checked = True
        Me.ck_allitem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ck_allitem.Location = New System.Drawing.Point(77, 148)
        Me.ck_allitem.Name = "ck_allitem"
        Me.ck_allitem.Size = New System.Drawing.Size(118, 19)
        Me.ck_allitem.TabIndex = 7
        Me.ck_allitem.Text = "Set semua barang"
        Me.ck_allitem.UseVisualStyleBackColor = True
        '
        'ck_setgudang
        '
        Me.ck_setgudang.AutoSize = True
        Me.ck_setgudang.Location = New System.Drawing.Point(18, 87)
        Me.ck_setgudang.Name = "ck_setgudang"
        Me.ck_setgudang.Size = New System.Drawing.Size(148, 19)
        Me.ck_setgudang.TabIndex = 4
        Me.ck_setgudang.Text = "Set Gudang dan Barang"
        Me.ck_setgudang.UseVisualStyleBackColor = True
        '
        'pnl_footer
        '
        Me.pnl_footer.AutoScroll = True
        Me.pnl_footer.BackColor = System.Drawing.Color.Gainsboro
        Me.pnl_footer.Controls.Add(Me.bt_simpanbeli)
        Me.pnl_footer.Controls.Add(Me.bt_batalbeli)
        Me.pnl_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_footer.Location = New System.Drawing.Point(319, 480)
        Me.pnl_footer.Name = "pnl_footer"
        Me.pnl_footer.Size = New System.Drawing.Size(609, 50)
        Me.pnl_footer.TabIndex = 2
        '
        'bt_simpanbeli
        '
        Me.bt_simpanbeli.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpanbeli.FlatAppearance.BorderSize = 0
        Me.bt_simpanbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpanbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbeli.ForeColor = System.Drawing.Color.White
        Me.bt_simpanbeli.Location = New System.Drawing.Point(329, 14)
        Me.bt_simpanbeli.Name = "bt_simpanbeli"
        Me.bt_simpanbeli.Size = New System.Drawing.Size(171, 30)
        Me.bt_simpanbeli.TabIndex = 33
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
        Me.bt_batalbeli.Location = New System.Drawing.Point(506, 14)
        Me.bt_batalbeli.Name = "bt_batalbeli"
        Me.bt_batalbeli.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalbeli.TabIndex = 34
        Me.bt_batalbeli.Text = "Batal"
        Me.bt_batalbeli.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 530)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(928, 10)
        Me.Panel3.TabIndex = 3
        '
        'pnl_dgv
        '
        Me.pnl_dgv.BackColor = System.Drawing.Color.Gainsboro
        Me.pnl_dgv.Controls.Add(Me.SplitContainer1)
        Me.pnl_dgv.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnl_dgv.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_dgv.Location = New System.Drawing.Point(0, 42)
        Me.pnl_dgv.Name = "pnl_dgv"
        Me.pnl_dgv.Size = New System.Drawing.Size(319, 488)
        Me.pnl_dgv.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.bt_refresh)
        Me.SplitContainer1.Panel1.Controls.Add(Me.bt_cari)
        Me.SplitContainer1.Panel1.Controls.Add(Me.in_cari)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv_sales)
        Me.SplitContainer1.Size = New System.Drawing.Size(319, 488)
        Me.SplitContainer1.SplitterDistance = 34
        Me.SplitContainer1.TabIndex = 0
        '
        'bt_refresh
        '
        Me.bt_refresh.BackColor = System.Drawing.Color.SteelBlue
        Me.bt_refresh.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_refresh.FlatAppearance.BorderSize = 0
        Me.bt_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_refresh.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_refresh.ForeColor = System.Drawing.Color.White
        Me.bt_refresh.Location = New System.Drawing.Point(3, 6)
        Me.bt_refresh.Name = "bt_refresh"
        Me.bt_refresh.Size = New System.Drawing.Size(66, 25)
        Me.bt_refresh.TabIndex = 0
        Me.bt_refresh.Text = "Refresh"
        Me.bt_refresh.UseVisualStyleBackColor = False
        '
        'bt_cari
        '
        Me.bt_cari.BackColor = System.Drawing.Color.SteelBlue
        Me.bt_cari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_cari.FlatAppearance.BorderSize = 0
        Me.bt_cari.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cari.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cari.ForeColor = System.Drawing.Color.White
        Me.bt_cari.Image = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.bt_cari.Location = New System.Drawing.Point(257, 6)
        Me.bt_cari.Name = "bt_cari"
        Me.bt_cari.Size = New System.Drawing.Size(59, 25)
        Me.bt_cari.TabIndex = 2
        Me.bt_cari.Text = "Cari"
        Me.bt_cari.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_cari.UseVisualStyleBackColor = False
        '
        'in_cari
        '
        Me.in_cari.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari.Location = New System.Drawing.Point(75, 6)
        Me.in_cari.Name = "in_cari"
        Me.in_cari.Size = New System.Drawing.Size(182, 25)
        Me.in_cari.TabIndex = 1
        '
        'dgv_sales
        '
        Me.dgv_sales.AllowUserToAddRows = False
        Me.dgv_sales.AllowUserToDeleteRows = False
        Me.dgv_sales.BackgroundColor = System.Drawing.Color.White
        Me.dgv_sales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_sales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sales_kode, Me.sales_nama, Me.sales_jenis, Me.sales_status})
        Me.dgv_sales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_sales.Location = New System.Drawing.Point(0, 0)
        Me.dgv_sales.MultiSelect = False
        Me.dgv_sales.Name = "dgv_sales"
        Me.dgv_sales.ReadOnly = True
        Me.dgv_sales.RowHeadersVisible = False
        Me.dgv_sales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_sales.Size = New System.Drawing.Size(319, 450)
        Me.dgv_sales.TabIndex = 3
        '
        'sales_kode
        '
        Me.sales_kode.DataPropertyName = "salesman_kode"
        Me.sales_kode.HeaderText = "Kode"
        Me.sales_kode.Name = "sales_kode"
        Me.sales_kode.ReadOnly = True
        Me.sales_kode.Width = 75
        '
        'sales_nama
        '
        Me.sales_nama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.sales_nama.DataPropertyName = "salesman_nama"
        Me.sales_nama.HeaderText = "Nama Salesman"
        Me.sales_nama.Name = "sales_nama"
        Me.sales_nama.ReadOnly = True
        '
        'sales_jenis
        '
        Me.sales_jenis.DataPropertyName = "salesman_jenis"
        Me.sales_jenis.HeaderText = "Jenis"
        Me.sales_jenis.Name = "sales_jenis"
        Me.sales_jenis.ReadOnly = True
        Me.sales_jenis.Width = 50
        '
        'sales_status
        '
        Me.sales_status.DataPropertyName = "salesman_status"
        Me.sales_status.HeaderText = "Status"
        Me.sales_status.Name = "sales_status"
        Me.sales_status.ReadOnly = True
        Me.sales_status.Width = 50
        '
        'uc_sales_barang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.pnl_footer)
        Me.Controls.Add(Me.pnl_dgv)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "uc_sales_barang"
        Me.Size = New System.Drawing.Size(928, 540)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.popPnl_barang.ResumeLayout(False)
        Me.popPnl_barang.PerformLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_footer.ResumeLayout(False)
        Me.pnl_dgv.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgv_sales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents dgv_barang As System.Windows.Forms.DataGridView
    Friend WithEvents ck_setgudang As System.Windows.Forms.CheckBox
    Friend WithEvents pnl_footer As System.Windows.Forms.Panel
    Friend WithEvents bt_simpanbeli As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnl_dgv As System.Windows.Forms.Panel
    Friend WithEvents dgv_sales As System.Windows.Forms.DataGridView
    Friend WithEvents bt_cari As System.Windows.Forms.Button
    Friend WithEvents in_cari As System.Windows.Forms.TextBox
    Friend WithEvents bt_refresh As System.Windows.Forms.Button
    Friend WithEvents in_status As System.Windows.Forms.TextBox
    Friend WithEvents in_sales_j As System.Windows.Forms.TextBox
    Friend WithEvents in_gudang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_sales_n As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_gudang As System.Windows.Forms.TextBox
    Friend WithEvents in_sales As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents linkLbl_searchbarang As System.Windows.Forms.LinkLabel
    Friend WithEvents ck_allitem As System.Windows.Forms.CheckBox
    Friend WithEvents bt_batalbeli As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents sales_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales_jenis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents in_barang_n As System.Windows.Forms.TextBox
    Friend WithEvents in_barang As System.Windows.Forms.TextBox
    Friend WithEvents barang_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents barang_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents barang_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bt_tbbarang As System.Windows.Forms.Button
    Friend WithEvents bt_clear As System.Windows.Forms.Button

End Class
