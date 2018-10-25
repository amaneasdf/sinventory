<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_user_detail
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
        Me.in_pass = New System.Windows.Forms.TextBox()
        Me.bt_bataluser = New System.Windows.Forms.Button()
        Me.bt_simpanuser = New System.Windows.Forms.Button()
        Me.in_userid = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_karyawan_nama = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtExpDate = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.in_group_kode = New System.Windows.Forms.TextBox()
        Me.in_status = New System.Windows.Forms.TextBox()
        Me.txtLastLogin = New System.Windows.Forms.TextBox()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.in_login_status = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cb_group = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.linkLbl_searchbarang = New System.Windows.Forms.LinkLabel()
        Me.ck_edit_trans = New System.Windows.Forms.CheckBox()
        Me.ck_edit_master = New System.Windows.Forms.CheckBox()
        Me.ck_valid_trans = New System.Windows.Forms.CheckBox()
        Me.ck_valid_master = New System.Windows.Forms.CheckBox()
        Me.in_sales_n = New System.Windows.Forms.TextBox()
        Me.in_sales_t = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.in_sales = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ck_sales = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_reset = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_actdeact = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_del = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'in_pass
        '
        Me.in_pass.BackColor = System.Drawing.Color.White
        Me.in_pass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_pass.ForeColor = System.Drawing.Color.Black
        Me.in_pass.Location = New System.Drawing.Point(99, 32)
        Me.in_pass.MaxLength = 15
        Me.in_pass.Name = "in_pass"
        Me.in_pass.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_pass.Size = New System.Drawing.Size(235, 20)
        Me.in_pass.TabIndex = 1
        '
        'bt_bataluser
        '
        Me.bt_bataluser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_bataluser.Location = New System.Drawing.Point(554, 364)
        Me.bt_bataluser.Name = "bt_bataluser"
        Me.bt_bataluser.Size = New System.Drawing.Size(96, 30)
        Me.bt_bataluser.TabIndex = 14
        Me.bt_bataluser.Text = "Keluar"
        Me.bt_bataluser.UseVisualStyleBackColor = True
        '
        'bt_simpanuser
        '
        Me.bt_simpanuser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanuser.Location = New System.Drawing.Point(452, 364)
        Me.bt_simpanuser.Name = "bt_simpanuser"
        Me.bt_simpanuser.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpanuser.TabIndex = 13
        Me.bt_simpanuser.Text = "Simpan"
        Me.bt_simpanuser.UseVisualStyleBackColor = True
        '
        'in_userid
        '
        Me.in_userid.BackColor = System.Drawing.Color.White
        Me.in_userid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_userid.ForeColor = System.Drawing.Color.Black
        Me.in_userid.Location = New System.Drawing.Point(99, 9)
        Me.in_userid.MaxLength = 15
        Me.in_userid.Name = "in_userid"
        Me.in_userid.Size = New System.Drawing.Size(235, 20)
        Me.in_userid.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Password"
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.Gainsboro
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.ForeColor = System.Drawing.Color.Black
        Me.in_kode.Location = New System.Drawing.Point(538, 9)
        Me.in_kode.Name = "in_kode"
        Me.in_kode.ReadOnly = True
        Me.in_kode.Size = New System.Drawing.Size(112, 20)
        Me.in_kode.TabIndex = 15
        Me.in_kode.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "User ID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(496, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Kode"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Nama"
        '
        'in_karyawan_nama
        '
        Me.in_karyawan_nama.BackColor = System.Drawing.Color.White
        Me.in_karyawan_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_karyawan_nama.ForeColor = System.Drawing.Color.Black
        Me.in_karyawan_nama.Location = New System.Drawing.Point(99, 55)
        Me.in_karyawan_nama.Name = "in_karyawan_nama"
        Me.in_karyawan_nama.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_karyawan_nama.Size = New System.Drawing.Size(325, 20)
        Me.in_karyawan_nama.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Group Akses"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(496, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Status"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(9, 254)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(56, 13)
        Me.Label20.TabIndex = 130
        Me.Label20.Text = "Last Login"
        '
        'txtExpDate
        '
        Me.txtExpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExpDate.Location = New System.Drawing.Point(83, 274)
        Me.txtExpDate.Name = "txtExpDate"
        Me.txtExpDate.ReadOnly = True
        Me.txtExpDate.Size = New System.Drawing.Size(234, 20)
        Me.txtExpDate.TabIndex = 127
        Me.txtExpDate.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(9, 277)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 13)
        Me.Label19.TabIndex = 128
        Me.Label19.Text = "Expired Date"
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(57, 374)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(146, 20)
        Me.txtUpdAlias.TabIndex = 122
        Me.txtUpdAlias.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(9, 377)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(42, 13)
        Me.Label17.TabIndex = 125
        Me.Label17.Text = "Upd By"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(216, 377)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(30, 13)
        Me.Label18.TabIndex = 124
        Me.Label18.Text = "Date"
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(57, 351)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(146, 20)
        Me.txtRegAlias.TabIndex = 116
        Me.txtRegAlias.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(9, 354)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 119
        Me.Label12.Text = "Reg By"
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(252, 351)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(146, 20)
        Me.txtRegdate.TabIndex = 115
        Me.txtRegdate.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(216, 354)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 118
        Me.Label11.Text = "Date"
        '
        'in_group_kode
        '
        Me.in_group_kode.BackColor = System.Drawing.Color.White
        Me.in_group_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_group_kode.ForeColor = System.Drawing.Color.Black
        Me.in_group_kode.Location = New System.Drawing.Point(99, 78)
        Me.in_group_kode.MaxLength = 2
        Me.in_group_kode.Name = "in_group_kode"
        Me.in_group_kode.Size = New System.Drawing.Size(68, 20)
        Me.in_group_kode.TabIndex = 3
        Me.in_group_kode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'in_status
        '
        Me.in_status.BackColor = System.Drawing.Color.White
        Me.in_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status.ForeColor = System.Drawing.Color.Black
        Me.in_status.Location = New System.Drawing.Point(538, 34)
        Me.in_status.MaxLength = 2
        Me.in_status.Name = "in_status"
        Me.in_status.Size = New System.Drawing.Size(112, 20)
        Me.in_status.TabIndex = 5
        '
        'txtLastLogin
        '
        Me.txtLastLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastLogin.Location = New System.Drawing.Point(83, 251)
        Me.txtLastLogin.Name = "txtLastLogin"
        Me.txtLastLogin.ReadOnly = True
        Me.txtLastLogin.Size = New System.Drawing.Size(234, 20)
        Me.txtLastLogin.TabIndex = 115
        Me.txtLastLogin.TabStop = False
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(252, 374)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(146, 20)
        Me.txtUpdDate.TabIndex = 115
        Me.txtUpdDate.TabStop = False
        '
        'in_login_status
        '
        Me.in_login_status.BackColor = System.Drawing.Color.Gainsboro
        Me.in_login_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_login_status.ForeColor = System.Drawing.Color.Black
        Me.in_login_status.Location = New System.Drawing.Point(404, 251)
        Me.in_login_status.MaxLength = 2
        Me.in_login_status.Name = "in_login_status"
        Me.in_login_status.ReadOnly = True
        Me.in_login_status.Size = New System.Drawing.Size(68, 20)
        Me.in_login_status.TabIndex = 20
        Me.in_login_status.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(332, 254)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Login Status"
        '
        'cb_group
        '
        Me.cb_group.BackColor = System.Drawing.Color.White
        Me.cb_group.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_group.FormattingEnabled = True
        Me.cb_group.Location = New System.Drawing.Point(169, 78)
        Me.cb_group.Name = "cb_group"
        Me.cb_group.Size = New System.Drawing.Size(255, 21)
        Me.cb_group.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.AutoScroll = True
        Me.Panel4.Controls.Add(Me.popPnl_barang)
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Controls.Add(Me.ck_edit_trans)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Controls.Add(Me.bt_bataluser)
        Me.Panel4.Controls.Add(Me.ck_edit_master)
        Me.Panel4.Controls.Add(Me.bt_simpanuser)
        Me.Panel4.Controls.Add(Me.txtExpDate)
        Me.Panel4.Controls.Add(Me.ck_valid_trans)
        Me.Panel4.Controls.Add(Me.ck_valid_master)
        Me.Panel4.Controls.Add(Me.txtLastLogin)
        Me.Panel4.Controls.Add(Me.in_sales_n)
        Me.Panel4.Controls.Add(Me.in_sales_t)
        Me.Panel4.Controls.Add(Me.in_kode)
        Me.Panel4.Controls.Add(Me.txtRegAlias)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.txtUpdAlias)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.txtRegdate)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.txtUpdDate)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.in_sales)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.ck_sales)
        Me.Panel4.Controls.Add(Me.in_userid)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.cb_group)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.in_login_status)
        Me.Panel4.Controls.Add(Me.in_pass)
        Me.Panel4.Controls.Add(Me.in_status)
        Me.Panel4.Controls.Add(Me.in_karyawan_nama)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.in_group_kode)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 66)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(662, 406)
        Me.Panel4.TabIndex = 0
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Controls.Add(Me.linkLbl_searchbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(252, 128)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(375, 119)
        Me.popPnl_barang.TabIndex = 481
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
        Me.dgv_listbarang.Size = New System.Drawing.Size(375, 111)
        Me.dgv_listbarang.TabIndex = 0
        '
        'linkLbl_searchbarang
        '
        Me.linkLbl_searchbarang.AutoSize = True
        Me.linkLbl_searchbarang.LinkColor = System.Drawing.Color.DimGray
        Me.linkLbl_searchbarang.Location = New System.Drawing.Point(3, 98)
        Me.linkLbl_searchbarang.Name = "linkLbl_searchbarang"
        Me.linkLbl_searchbarang.Size = New System.Drawing.Size(116, 13)
        Me.linkLbl_searchbarang.TabIndex = 1
        Me.linkLbl_searchbarang.TabStop = True
        Me.linkLbl_searchbarang.Text = "Tampilkan Pencarian..."
        Me.linkLbl_searchbarang.Visible = False
        Me.linkLbl_searchbarang.VisitedLinkColor = System.Drawing.Color.DimGray
        '
        'ck_edit_trans
        '
        Me.ck_edit_trans.AutoSize = True
        Me.ck_edit_trans.Location = New System.Drawing.Point(201, 105)
        Me.ck_edit_trans.Name = "ck_edit_trans"
        Me.ck_edit_trans.Size = New System.Drawing.Size(133, 17)
        Me.ck_edit_trans.TabIndex = 6
        Me.ck_edit_trans.Text = "Edit/Update Transaksi"
        Me.ck_edit_trans.UseVisualStyleBackColor = True
        '
        'ck_edit_master
        '
        Me.ck_edit_master.AutoSize = True
        Me.ck_edit_master.Location = New System.Drawing.Point(36, 105)
        Me.ck_edit_master.Name = "ck_edit_master"
        Me.ck_edit_master.Size = New System.Drawing.Size(145, 17)
        Me.ck_edit_master.TabIndex = 5
        Me.ck_edit_master.Text = "Edit/Update Data Master"
        Me.ck_edit_master.UseVisualStyleBackColor = True
        '
        'ck_valid_trans
        '
        Me.ck_valid_trans.AutoSize = True
        Me.ck_valid_trans.Location = New System.Drawing.Point(201, 128)
        Me.ck_valid_trans.Name = "ck_valid_trans"
        Me.ck_valid_trans.Size = New System.Drawing.Size(137, 17)
        Me.ck_valid_trans.TabIndex = 8
        Me.ck_valid_trans.Text = "Validasi Data Transaksi"
        Me.ck_valid_trans.UseVisualStyleBackColor = True
        '
        'ck_valid_master
        '
        Me.ck_valid_master.AutoSize = True
        Me.ck_valid_master.Location = New System.Drawing.Point(36, 128)
        Me.ck_valid_master.Name = "ck_valid_master"
        Me.ck_valid_master.Size = New System.Drawing.Size(123, 17)
        Me.ck_valid_master.TabIndex = 7
        Me.ck_valid_master.Text = "Validasi Data Master"
        Me.ck_valid_master.UseVisualStyleBackColor = True
        '
        'in_sales_n
        '
        Me.in_sales_n.BackColor = System.Drawing.SystemColors.Control
        Me.in_sales_n.Enabled = False
        Me.in_sales_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales_n.ForeColor = System.Drawing.Color.Black
        Me.in_sales_n.Location = New System.Drawing.Point(232, 172)
        Me.in_sales_n.MaxLength = 200
        Me.in_sales_n.Name = "in_sales_n"
        Me.in_sales_n.Size = New System.Drawing.Size(322, 20)
        Me.in_sales_n.TabIndex = 11
        '
        'in_sales_t
        '
        Me.in_sales_t.BackColor = System.Drawing.SystemColors.Control
        Me.in_sales_t.Enabled = False
        Me.in_sales_t.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales_t.ForeColor = System.Drawing.Color.Black
        Me.in_sales_t.Location = New System.Drawing.Point(109, 194)
        Me.in_sales_t.MaxLength = 30
        Me.in_sales_t.Name = "in_sales_t"
        Me.in_sales_t.ReadOnly = True
        Me.in_sales_t.Size = New System.Drawing.Size(208, 20)
        Me.in_sales_t.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(35, 199)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 479
        Me.Label10.Text = "Jenis"
        '
        'in_sales
        '
        Me.in_sales.BackColor = System.Drawing.SystemColors.Control
        Me.in_sales.Enabled = False
        Me.in_sales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sales.ForeColor = System.Drawing.Color.Black
        Me.in_sales.Location = New System.Drawing.Point(109, 172)
        Me.in_sales.MaxLength = 30
        Me.in_sales.Name = "in_sales"
        Me.in_sales.ReadOnly = True
        Me.in_sales.Size = New System.Drawing.Size(121, 20)
        Me.in_sales.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(35, 177)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 479
        Me.Label9.Text = "Salesman"
        '
        'ck_sales
        '
        Me.ck_sales.AutoSize = True
        Me.ck_sales.Location = New System.Drawing.Point(36, 152)
        Me.ck_sales.Name = "ck_sales"
        Me.ck_sales.Size = New System.Drawing.Size(52, 17)
        Me.ck_sales.TabIndex = 9
        Me.ck_sales.Text = "Sales"
        Me.ck_sales.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 472)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(662, 10)
        Me.Panel3.TabIndex = 345
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_save, Me.mn_reset, Me.mn_actdeact, Me.mn_del})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 42)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(662, 24)
        Me.MenuStrip1.TabIndex = 343
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
        'mn_reset
        '
        Me.mn_reset.Enabled = False
        Me.mn_reset.Name = "mn_reset"
        Me.mn_reset.Size = New System.Drawing.Size(100, 20)
        Me.mn_reset.Text = "Reset Password"
        '
        'mn_actdeact
        '
        Me.mn_actdeact.Enabled = False
        Me.mn_actdeact.Name = "mn_actdeact"
        Me.mn_actdeact.Size = New System.Drawing.Size(74, 20)
        Me.mn_actdeact.Text = "Deactivate"
        '
        'mn_del
        '
        Me.mn_del.Enabled = False
        Me.mn_del.Name = "mn_del"
        Me.mn_del.Size = New System.Drawing.Size(53, 20)
        Me.mn_del.Text = "Hapus"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Controls.Add(Me.lbl_close)
        Me.Panel2.Controls.Add(Me.bt_cl)
        Me.Panel2.Controls.Add(Me.lbl_title)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(662, 42)
        Me.Panel2.TabIndex = 344
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(582, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(635, 9)
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
        Me.lbl_title.Location = New System.Drawing.Point(6, 6)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(118, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Data User"
        '
        'fr_user_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(662, 482)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fr_user_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail User : "
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.popPnl_barang.ResumeLayout(False)
        Me.popPnl_barang.PerformLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents in_pass As System.Windows.Forms.TextBox
    Friend WithEvents bt_bataluser As System.Windows.Forms.Button
    Friend WithEvents bt_simpanuser As System.Windows.Forms.Button
    Friend WithEvents in_userid As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_karyawan_nama As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtExpDate As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents in_group_kode As System.Windows.Forms.TextBox
    Friend WithEvents in_status As System.Windows.Forms.TextBox
    Friend WithEvents txtLastLogin As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents in_login_status As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cb_group As System.Windows.Forms.ComboBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ck_sales As System.Windows.Forms.CheckBox
    Friend WithEvents ck_edit_trans As System.Windows.Forms.CheckBox
    Friend WithEvents ck_edit_master As System.Windows.Forms.CheckBox
    Friend WithEvents ck_valid_master As System.Windows.Forms.CheckBox
    Friend WithEvents in_sales_n As System.Windows.Forms.TextBox
    Friend WithEvents in_sales_t As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents in_sales As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ck_valid_trans As System.Windows.Forms.CheckBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_reset As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_actdeact As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents mn_del As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents linkLbl_searchbarang As System.Windows.Forms.LinkLabel
End Class
