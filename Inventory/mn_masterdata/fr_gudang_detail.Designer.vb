<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_gudang_detail
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.bt_batalgudang = New System.Windows.Forms.Button()
        Me.bt_simpangudang = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.dgv_inv = New System.Windows.Forms.DataGridView()
        Me.prod_item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prod_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.in_status_kode = New System.Windows.Forms.TextBox()
        Me.cb_status = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_alamatgudang = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_namagudang = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cb_kodeprod = New System.Windows.Forms.ComboBox()
        Me.dt_akhir = New System.Windows.Forms.DateTimePicker()
        Me.dt_awal = New System.Windows.Forms.DateTimePicker()
        Me.bt_su_view = New System.Windows.Forms.Button()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.dgv_su = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtRegIP = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtUpdIp = New System.Windows.Forms.TextBox()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.his_tanggal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_faktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_kodebarang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_barang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_qty_in = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_qty_out = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_source = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.his_dest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgv_inv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv_su, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bt_batalgudang
        '
        Me.bt_batalgudang.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_batalgudang.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalgudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalgudang.Location = New System.Drawing.Point(635, 520)
        Me.bt_batalgudang.Name = "bt_batalgudang"
        Me.bt_batalgudang.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalgudang.TabIndex = 5
        Me.bt_batalgudang.Text = "Batal"
        Me.bt_batalgudang.UseVisualStyleBackColor = True
        '
        'bt_simpangudang
        '
        Me.bt_simpangudang.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_simpangudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpangudang.Location = New System.Drawing.Point(533, 520)
        Me.bt_simpangudang.Name = "bt_simpangudang"
        Me.bt_simpangudang.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpangudang.TabIndex = 4
        Me.bt_simpangudang.Text = "Simpan"
        Me.bt_simpangudang.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.lbl_close)
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(743, 42)
        Me.Panel1.TabIndex = 134
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Orange
        Me.Label9.Font = New System.Drawing.Font("Source Sans Pro", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(3, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(151, 30)
        Me.Label9.TabIndex = 138
        Me.Label9.Text = "Data Gudang"
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(658, 9)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(47, 20)
        Me.lbl_close.TabIndex = 137
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
        Me.bt_cl.Location = New System.Drawing.Point(711, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 136
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 42)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(743, 476)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label44)
        Me.TabPage1.Controls.Add(Me.dgv_inv)
        Me.TabPage1.Controls.Add(Me.in_kode)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.in_status_kode)
        Me.TabPage1.Controls.Add(Me.cb_status)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.in_alamatgudang)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.in_namagudang)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(735, 448)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Basic Info"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Source Sans Pro", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label44.Location = New System.Drawing.Point(389, 16)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(78, 24)
        Me.Label44.TabIndex = 393
        Me.Label44.Text = "Product"
        '
        'dgv_inv
        '
        Me.dgv_inv.AllowUserToAddRows = False
        Me.dgv_inv.AllowUserToDeleteRows = False
        Me.dgv_inv.BackgroundColor = System.Drawing.Color.White
        Me.dgv_inv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_inv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.prod_item, Me.prod_qty})
        Me.dgv_inv.Location = New System.Drawing.Point(393, 43)
        Me.dgv_inv.Name = "dgv_inv"
        Me.dgv_inv.ReadOnly = True
        Me.dgv_inv.RowHeadersVisible = False
        Me.dgv_inv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_inv.Size = New System.Drawing.Size(256, 334)
        Me.dgv_inv.TabIndex = 394
        '
        'prod_item
        '
        Me.prod_item.DataPropertyName = "barang_nama"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prod_item.DefaultCellStyle = DataGridViewCellStyle1
        Me.prod_item.HeaderText = "Produk"
        Me.prod_item.MinimumWidth = 165
        Me.prod_item.Name = "prod_item"
        Me.prod_item.ReadOnly = True
        Me.prod_item.Width = 165
        '
        'prod_qty
        '
        Me.prod_qty.DataPropertyName = "stock_sisa"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.prod_qty.DefaultCellStyle = DataGridViewCellStyle2
        Me.prod_qty.HeaderText = "Qty"
        Me.prod_qty.MinimumWidth = 75
        Me.prod_qty.Name = "prod_qty"
        Me.prod_qty.ReadOnly = True
        Me.prod_qty.Width = 75
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.White
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.ForeColor = System.Drawing.Color.Black
        Me.in_kode.Location = New System.Drawing.Point(95, 43)
        Me.in_kode.MaxLength = 10
        Me.in_kode.Name = "in_kode"
        Me.in_kode.Size = New System.Drawing.Size(272, 22)
        Me.in_kode.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 390
        Me.Label4.Text = "Kode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Source Sans Pro", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(10, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 24)
        Me.Label2.TabIndex = 392
        Me.Label2.Text = "Basic"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 389
        Me.Label3.Text = "Nama"
        '
        'in_status_kode
        '
        Me.in_status_kode.BackColor = System.Drawing.Color.White
        Me.in_status_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_status_kode.ForeColor = System.Drawing.Color.Black
        Me.in_status_kode.Location = New System.Drawing.Point(95, 195)
        Me.in_status_kode.MaxLength = 5
        Me.in_status_kode.Name = "in_status_kode"
        Me.in_status_kode.Size = New System.Drawing.Size(57, 22)
        Me.in_status_kode.TabIndex = 382
        Me.in_status_kode.TabStop = False
        '
        'cb_status
        '
        Me.cb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_status.FormattingEnabled = True
        Me.cb_status.Location = New System.Drawing.Point(158, 195)
        Me.cb_status.Name = "cb_status"
        Me.cb_status.Size = New System.Drawing.Size(175, 23)
        Me.cb_status.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 16)
        Me.Label5.TabIndex = 388
        Me.Label5.Text = "Alamat"
        '
        'in_alamatgudang
        '
        Me.in_alamatgudang.BackColor = System.Drawing.Color.White
        Me.in_alamatgudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamatgudang.ForeColor = System.Drawing.Color.Black
        Me.in_alamatgudang.Location = New System.Drawing.Point(95, 101)
        Me.in_alamatgudang.MaxLength = 200
        Me.in_alamatgudang.Multiline = True
        Me.in_alamatgudang.Name = "in_alamatgudang"
        Me.in_alamatgudang.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_alamatgudang.Size = New System.Drawing.Size(272, 84)
        Me.in_alamatgudang.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 198)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 387
        Me.Label1.Text = "Status"
        '
        'in_namagudang
        '
        Me.in_namagudang.BackColor = System.Drawing.Color.White
        Me.in_namagudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_namagudang.ForeColor = System.Drawing.Color.Black
        Me.in_namagudang.Location = New System.Drawing.Point(95, 73)
        Me.in_namagudang.MaxLength = 50
        Me.in_namagudang.Name = "in_namagudang"
        Me.in_namagudang.Size = New System.Drawing.Size(272, 22)
        Me.in_namagudang.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cb_kodeprod)
        Me.TabPage2.Controls.Add(Me.dt_akhir)
        Me.TabPage2.Controls.Add(Me.dt_awal)
        Me.TabPage2.Controls.Add(Me.bt_su_view)
        Me.TabPage2.Controls.Add(Me.Label65)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label64)
        Me.TabPage2.Controls.Add(Me.Label63)
        Me.TabPage2.Controls.Add(Me.dgv_su)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(735, 448)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "History"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cb_kodeprod
        '
        Me.cb_kodeprod.FormattingEnabled = True
        Me.cb_kodeprod.Location = New System.Drawing.Point(73, 45)
        Me.cb_kodeprod.Name = "cb_kodeprod"
        Me.cb_kodeprod.Size = New System.Drawing.Size(306, 23)
        Me.cb_kodeprod.TabIndex = 393
        '
        'dt_akhir
        '
        Me.dt_akhir.CustomFormat = "MMMM yyyy"
        Me.dt_akhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_akhir.Location = New System.Drawing.Point(236, 74)
        Me.dt_akhir.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dt_akhir.Name = "dt_akhir"
        Me.dt_akhir.Size = New System.Drawing.Size(143, 21)
        Me.dt_akhir.TabIndex = 391
        Me.dt_akhir.Value = New Date(2018, 6, 22, 9, 15, 23, 0)
        '
        'dt_awal
        '
        Me.dt_awal.CustomFormat = "MMMM yyyy"
        Me.dt_awal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_awal.Location = New System.Drawing.Point(73, 74)
        Me.dt_awal.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dt_awal.Name = "dt_awal"
        Me.dt_awal.Size = New System.Drawing.Size(143, 21)
        Me.dt_awal.TabIndex = 392
        Me.dt_awal.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'bt_su_view
        '
        Me.bt_su_view.Location = New System.Drawing.Point(393, 72)
        Me.bt_su_view.Name = "bt_su_view"
        Me.bt_su_view.Size = New System.Drawing.Size(75, 25)
        Me.bt_su_view.TabIndex = 390
        Me.bt_su_view.Text = "View"
        Me.bt_su_view.UseVisualStyleBackColor = True
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(220, 76)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(12, 16)
        Me.Label65.TabIndex = 388
        Me.Label65.Text = "-"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 16)
        Me.Label6.TabIndex = 389
        Me.Label6.Text = "Product"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(11, 76)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(56, 16)
        Me.Label64.TabIndex = 389
        Me.Label64.Text = "Periode"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Source Sans Pro", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label63.Location = New System.Drawing.Point(8, 15)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(256, 24)
        Me.Label63.TabIndex = 386
        Me.Label63.Text = "Summary Transaksi Perbulan"
        '
        'dgv_su
        '
        Me.dgv_su.AllowUserToAddRows = False
        Me.dgv_su.AllowUserToDeleteRows = False
        Me.dgv_su.BackgroundColor = System.Drawing.Color.White
        Me.dgv_su.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_su.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.his_tanggal, Me.his_faktur, Me.his_type, Me.his_kodebarang, Me.his_barang, Me.his_qty_in, Me.his_qty_out, Me.his_source, Me.his_dest})
        Me.dgv_su.Location = New System.Drawing.Point(8, 103)
        Me.dgv_su.Name = "dgv_su"
        Me.dgv_su.ReadOnly = True
        Me.dgv_su.RowHeadersVisible = False
        Me.dgv_su.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_su.Size = New System.Drawing.Size(719, 339)
        Me.dgv_su.TabIndex = 387
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(735, 448)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Extra Info"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtRegIP)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtRegAlias)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtUpdIp)
        Me.GroupBox1.Controls.Add(Me.txtUpdAlias)
        Me.GroupBox1.Controls.Add(Me.txtRegdate)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtUpdDate)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(487, 113)
        Me.GroupBox1.TabIndex = 392
        Me.GroupBox1.TabStop = False
        '
        'txtRegIP
        '
        Me.txtRegIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegIP.Location = New System.Drawing.Point(82, 71)
        Me.txtRegIP.Name = "txtRegIP"
        Me.txtRegIP.ReadOnly = True
        Me.txtRegIP.Size = New System.Drawing.Size(146, 22)
        Me.txtRegIP.TabIndex = 117
        Me.txtRegIP.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(9, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 16)
        Me.Label13.TabIndex = 120
        Me.Label13.Text = "Reg IP"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(234, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 16)
        Me.Label8.TabIndex = 126
        Me.Label8.Text = "Update IP"
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(82, 45)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(146, 22)
        Me.txtRegAlias.TabIndex = 116
        Me.txtRegAlias.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(9, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 16)
        Me.Label12.TabIndex = 119
        Me.Label12.Text = "Reg Alias"
        '
        'txtUpdIp
        '
        Me.txtUpdIp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdIp.Location = New System.Drawing.Point(326, 71)
        Me.txtUpdIp.Name = "txtUpdIp"
        Me.txtUpdIp.ReadOnly = True
        Me.txtUpdIp.Size = New System.Drawing.Size(146, 22)
        Me.txtUpdIp.TabIndex = 123
        Me.txtUpdIp.TabStop = False
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(326, 45)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(146, 22)
        Me.txtUpdAlias.TabIndex = 122
        Me.txtUpdAlias.TabStop = False
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(82, 19)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(146, 22)
        Me.txtRegdate.TabIndex = 115
        Me.txtRegdate.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(234, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 16)
        Me.Label17.TabIndex = 125
        Me.Label17.Text = "Update Alias"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(9, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 16)
        Me.Label11.TabIndex = 118
        Me.Label11.Text = "Reg Date"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(234, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 16)
        Me.Label18.TabIndex = 124
        Me.Label18.Text = "Update Date"
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(326, 19)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(146, 22)
        Me.txtUpdDate.TabIndex = 115
        Me.txtUpdDate.TabStop = False
        '
        'his_tanggal
        '
        Me.his_tanggal.DataPropertyName = "trans_tanggal"
        Me.his_tanggal.HeaderText = "Tanggal"
        Me.his_tanggal.MinimumWidth = 100
        Me.his_tanggal.Name = "his_tanggal"
        Me.his_tanggal.ReadOnly = True
        '
        'his_faktur
        '
        Me.his_faktur.DataPropertyName = "trans_faktur"
        Me.his_faktur.HeaderText = "Kode Faktur"
        Me.his_faktur.MinimumWidth = 125
        Me.his_faktur.Name = "his_faktur"
        Me.his_faktur.ReadOnly = True
        Me.his_faktur.Width = 125
        '
        'his_type
        '
        Me.his_type.DataPropertyName = "trans_type"
        Me.his_type.HeaderText = "Keterangan"
        Me.his_type.MinimumWidth = 150
        Me.his_type.Name = "his_type"
        Me.his_type.ReadOnly = True
        Me.his_type.Width = 150
        '
        'his_kodebarang
        '
        Me.his_kodebarang.DataPropertyName = "trans_barang"
        Me.his_kodebarang.HeaderText = "Kode"
        Me.his_kodebarang.MinimumWidth = 100
        Me.his_kodebarang.Name = "his_kodebarang"
        Me.his_kodebarang.ReadOnly = True
        '
        'his_barang
        '
        Me.his_barang.DataPropertyName = "barang_nama"
        Me.his_barang.HeaderText = "Nama Barang"
        Me.his_barang.MinimumWidth = 150
        Me.his_barang.Name = "his_barang"
        Me.his_barang.ReadOnly = True
        Me.his_barang.Width = 150
        '
        'his_qty_in
        '
        Me.his_qty_in.DataPropertyName = "trans_qty_in"
        Me.his_qty_in.HeaderText = "Debet"
        Me.his_qty_in.MinimumWidth = 75
        Me.his_qty_in.Name = "his_qty_in"
        Me.his_qty_in.ReadOnly = True
        Me.his_qty_in.Width = 75
        '
        'his_qty_out
        '
        Me.his_qty_out.DataPropertyName = "trans_qty_out"
        Me.his_qty_out.HeaderText = "Kredit"
        Me.his_qty_out.MinimumWidth = 75
        Me.his_qty_out.Name = "his_qty_out"
        Me.his_qty_out.ReadOnly = True
        Me.his_qty_out.Width = 75
        '
        'his_source
        '
        Me.his_source.DataPropertyName = "trans_source"
        Me.his_source.HeaderText = "Asal"
        Me.his_source.MinimumWidth = 100
        Me.his_source.Name = "his_source"
        Me.his_source.ReadOnly = True
        '
        'his_dest
        '
        Me.his_dest.DataPropertyName = "trans_dest"
        Me.his_dest.HeaderText = "Tujuan"
        Me.his_dest.MinimumWidth = 100
        Me.his_dest.Name = "his_dest"
        Me.his_dest.ReadOnly = True
        '
        'fr_gudang_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.bt_batalgudang
        Me.ClientSize = New System.Drawing.Size(743, 559)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.bt_batalgudang)
        Me.Controls.Add(Me.bt_simpangudang)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fr_gudang_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Gudang : "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgv_inv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgv_su, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bt_batalgudang As System.Windows.Forms.Button
    Friend WithEvents bt_simpangudang As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents dgv_inv As System.Windows.Forms.DataGridView
    Friend WithEvents prod_item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents prod_qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents in_status_kode As System.Windows.Forms.TextBox
    Friend WithEvents cb_status As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_alamatgudang As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_namagudang As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRegIP As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtUpdIp As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents cb_kodeprod As System.Windows.Forms.ComboBox
    Friend WithEvents dt_akhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt_awal As System.Windows.Forms.DateTimePicker
    Friend WithEvents bt_su_view As System.Windows.Forms.Button
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents dgv_su As System.Windows.Forms.DataGridView
    Friend WithEvents his_tanggal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_faktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_kodebarang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_barang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_qty_in As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_qty_out As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_source As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents his_dest As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
