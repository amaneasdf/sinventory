<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_reference
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.bt_kodearea = New System.Windows.Forms.Button()
        Me.bt_kabupaten = New System.Windows.Forms.Button()
        Me.bt_satbrg = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pnl_area = New System.Windows.Forms.Panel()
        Me.lk_area_refresh = New System.Windows.Forms.LinkLabel()
        Me.bt_del_area = New System.Windows.Forms.Button()
        Me.bt_deact_area = New System.Windows.Forms.Button()
        Me.bt_save_area = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.in_area_id = New System.Windows.Forms.TextBox()
        Me.dgv_area = New System.Windows.Forms.DataGridView()
        Me.cb_area_kab = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.in_area_n = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnl_satbrg = New System.Windows.Forms.Panel()
        Me.lk_sat_refresh = New System.Windows.Forms.LinkLabel()
        Me.bt_del_sat = New System.Windows.Forms.Button()
        Me.bt_deact_sat = New System.Windows.Forms.Button()
        Me.bt_save_sat = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.in_sat_id = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_sat_ket = New System.Windows.Forms.TextBox()
        Me.dgv_sat = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.in_sat_nm = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnl_kab = New System.Windows.Forms.Panel()
        Me.lk_kab_refresh = New System.Windows.Forms.LinkLabel()
        Me.bt_del_kab = New System.Windows.Forms.Button()
        Me.bt_deact_kab = New System.Windows.Forms.Button()
        Me.bt_save_kab = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_kab_id = New System.Windows.Forms.TextBox()
        Me.dgv_kab = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.in_kab_n = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.bt_simpanbeli = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnl_area.SuspendLayout()
        CType(Me.dgv_area, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_satbrg.SuspendLayout()
        CType(Me.dgv_sat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_kab.SuspendLayout()
        CType(Me.dgv_kab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 524)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(747, 10)
        Me.Panel3.TabIndex = 418
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.lbl_title)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(747, 30)
        Me.Panel1.TabIndex = 417
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
        Me.bt_cl.Location = New System.Drawing.Point(723, 5)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(17, 17)
        Me.bt_cl.TabIndex = 0
        Me.bt_cl.TabStop = False
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Orange
        Me.lbl_title.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(6, 4)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(85, 22)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Referensi"
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.bt_kodearea)
        Me.Panel2.Controls.Add(Me.bt_kabupaten)
        Me.Panel2.Controls.Add(Me.bt_satbrg)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(175, 454)
        Me.Panel2.TabIndex = 0
        '
        'bt_kodearea
        '
        Me.bt_kodearea.FlatAppearance.BorderSize = 0
        Me.bt_kodearea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_kodearea.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_kodearea.Location = New System.Drawing.Point(3, 6)
        Me.bt_kodearea.Name = "bt_kodearea"
        Me.bt_kodearea.Size = New System.Drawing.Size(166, 25)
        Me.bt_kodearea.TabIndex = 9
        Me.bt_kodearea.Text = "Kode Area Customer"
        Me.bt_kodearea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_kodearea.UseVisualStyleBackColor = True
        '
        'bt_kabupaten
        '
        Me.bt_kabupaten.FlatAppearance.BorderSize = 0
        Me.bt_kabupaten.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_kabupaten.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_kabupaten.Location = New System.Drawing.Point(3, 35)
        Me.bt_kabupaten.Name = "bt_kabupaten"
        Me.bt_kabupaten.Size = New System.Drawing.Size(166, 25)
        Me.bt_kabupaten.TabIndex = 8
        Me.bt_kabupaten.Text = "Kabupaten"
        Me.bt_kabupaten.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_kabupaten.UseVisualStyleBackColor = True
        '
        'bt_satbrg
        '
        Me.bt_satbrg.FlatAppearance.BorderSize = 0
        Me.bt_satbrg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_satbrg.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_satbrg.Location = New System.Drawing.Point(3, 64)
        Me.bt_satbrg.Name = "bt_satbrg"
        Me.bt_satbrg.Size = New System.Drawing.Size(166, 25)
        Me.bt_satbrg.TabIndex = 7
        Me.bt_satbrg.Text = "Satuan Barang"
        Me.bt_satbrg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_satbrg.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.AutoScroll = True
        Me.Panel4.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel4.Controls.Add(Me.pnl_area)
        Me.Panel4.Controls.Add(Me.pnl_satbrg)
        Me.Panel4.Controls.Add(Me.pnl_kab)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(175, 30)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(572, 454)
        Me.Panel4.TabIndex = 1
        '
        'pnl_area
        '
        Me.pnl_area.AutoScroll = True
        Me.pnl_area.BackColor = System.Drawing.Color.White
        Me.pnl_area.Controls.Add(Me.lk_area_refresh)
        Me.pnl_area.Controls.Add(Me.bt_del_area)
        Me.pnl_area.Controls.Add(Me.bt_deact_area)
        Me.pnl_area.Controls.Add(Me.bt_save_area)
        Me.pnl_area.Controls.Add(Me.Label8)
        Me.pnl_area.Controls.Add(Me.in_area_id)
        Me.pnl_area.Controls.Add(Me.dgv_area)
        Me.pnl_area.Controls.Add(Me.cb_area_kab)
        Me.pnl_area.Controls.Add(Me.Label9)
        Me.pnl_area.Controls.Add(Me.Label10)
        Me.pnl_area.Controls.Add(Me.in_area_n)
        Me.pnl_area.Controls.Add(Me.Label11)
        Me.pnl_area.Location = New System.Drawing.Point(6, 6)
        Me.pnl_area.Name = "pnl_area"
        Me.pnl_area.Size = New System.Drawing.Size(546, 262)
        Me.pnl_area.TabIndex = 3
        '
        'lk_area_refresh
        '
        Me.lk_area_refresh.AutoSize = True
        Me.lk_area_refresh.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lk_area_refresh.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lk_area_refresh.Location = New System.Drawing.Point(11, 79)
        Me.lk_area_refresh.Name = "lk_area_refresh"
        Me.lk_area_refresh.Size = New System.Drawing.Size(47, 15)
        Me.lk_area_refresh.TabIndex = 388
        Me.lk_area_refresh.TabStop = True
        Me.lk_area_refresh.Text = "Refresh"
        '
        'bt_del_area
        '
        Me.bt_del_area.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_del_area.Location = New System.Drawing.Point(216, 73)
        Me.bt_del_area.Name = "bt_del_area"
        Me.bt_del_area.Size = New System.Drawing.Size(76, 25)
        Me.bt_del_area.TabIndex = 387
        Me.bt_del_area.Text = "Hapus"
        Me.bt_del_area.UseVisualStyleBackColor = True
        Me.bt_del_area.Visible = False
        '
        'bt_deact_area
        '
        Me.bt_deact_area.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_deact_area.Location = New System.Drawing.Point(456, 73)
        Me.bt_deact_area.Name = "bt_deact_area"
        Me.bt_deact_area.Size = New System.Drawing.Size(76, 25)
        Me.bt_deact_area.TabIndex = 386
        Me.bt_deact_area.Text = "Activate"
        Me.bt_deact_area.UseVisualStyleBackColor = True
        '
        'bt_save_area
        '
        Me.bt_save_area.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_save_area.Location = New System.Drawing.Point(377, 73)
        Me.bt_save_area.Name = "bt_save_area"
        Me.bt_save_area.Size = New System.Drawing.Size(76, 25)
        Me.bt_save_area.TabIndex = 6
        Me.bt_save_area.Text = "Simpan"
        Me.bt_save_area.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 13)
        Me.Label8.TabIndex = 385
        Me.Label8.Text = "ID"
        '
        'in_area_id
        '
        Me.in_area_id.BackColor = System.Drawing.Color.White
        Me.in_area_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_area_id.ForeColor = System.Drawing.Color.Black
        Me.in_area_id.Location = New System.Drawing.Point(71, 25)
        Me.in_area_id.MaxLength = 10
        Me.in_area_id.Name = "in_area_id"
        Me.in_area_id.ReadOnly = True
        Me.in_area_id.Size = New System.Drawing.Size(102, 20)
        Me.in_area_id.TabIndex = 384
        Me.in_area_id.TabStop = False
        '
        'dgv_area
        '
        Me.dgv_area.AllowUserToAddRows = False
        Me.dgv_area.AllowUserToDeleteRows = False
        Me.dgv_area.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv_area.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_area.Location = New System.Drawing.Point(11, 101)
        Me.dgv_area.MultiSelect = False
        Me.dgv_area.Name = "dgv_area"
        Me.dgv_area.ReadOnly = True
        Me.dgv_area.RowHeadersVisible = False
        Me.dgv_area.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_area.Size = New System.Drawing.Size(521, 148)
        Me.dgv_area.TabIndex = 383
        '
        'cb_area_kab
        '
        Me.cb_area_kab.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_area_kab.FormattingEnabled = True
        Me.cb_area_kab.Location = New System.Drawing.Point(343, 46)
        Me.cb_area_kab.Name = "cb_area_kab"
        Me.cb_area_kab.Size = New System.Drawing.Size(189, 21)
        Me.cb_area_kab.TabIndex = 381
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(278, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 360
        Me.Label9.Text = "Kabupaten"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 359
        Me.Label10.Text = "Area"
        '
        'in_area_n
        '
        Me.in_area_n.Location = New System.Drawing.Point(71, 47)
        Me.in_area_n.Name = "in_area_n"
        Me.in_area_n.Size = New System.Drawing.Size(192, 20)
        Me.in_area_n.TabIndex = 358
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label11.Location = New System.Drawing.Point(6, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 13)
        Me.Label11.TabIndex = 357
        Me.Label11.Text = "Area Customer"
        '
        'pnl_satbrg
        '
        Me.pnl_satbrg.AutoScroll = True
        Me.pnl_satbrg.BackColor = System.Drawing.Color.White
        Me.pnl_satbrg.Controls.Add(Me.lk_sat_refresh)
        Me.pnl_satbrg.Controls.Add(Me.bt_del_sat)
        Me.pnl_satbrg.Controls.Add(Me.bt_deact_sat)
        Me.pnl_satbrg.Controls.Add(Me.bt_save_sat)
        Me.pnl_satbrg.Controls.Add(Me.Label6)
        Me.pnl_satbrg.Controls.Add(Me.in_sat_id)
        Me.pnl_satbrg.Controls.Add(Me.Label2)
        Me.pnl_satbrg.Controls.Add(Me.in_sat_ket)
        Me.pnl_satbrg.Controls.Add(Me.dgv_sat)
        Me.pnl_satbrg.Controls.Add(Me.Label3)
        Me.pnl_satbrg.Controls.Add(Me.in_sat_nm)
        Me.pnl_satbrg.Controls.Add(Me.Label4)
        Me.pnl_satbrg.Location = New System.Drawing.Point(6, 542)
        Me.pnl_satbrg.Name = "pnl_satbrg"
        Me.pnl_satbrg.Size = New System.Drawing.Size(546, 262)
        Me.pnl_satbrg.TabIndex = 2
        '
        'lk_sat_refresh
        '
        Me.lk_sat_refresh.AutoSize = True
        Me.lk_sat_refresh.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lk_sat_refresh.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lk_sat_refresh.Location = New System.Drawing.Point(11, 78)
        Me.lk_sat_refresh.Name = "lk_sat_refresh"
        Me.lk_sat_refresh.Size = New System.Drawing.Size(47, 15)
        Me.lk_sat_refresh.TabIndex = 0
        Me.lk_sat_refresh.TabStop = True
        Me.lk_sat_refresh.Text = "Refresh"
        '
        'bt_del_sat
        '
        Me.bt_del_sat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_del_sat.Location = New System.Drawing.Point(216, 73)
        Me.bt_del_sat.Name = "bt_del_sat"
        Me.bt_del_sat.Size = New System.Drawing.Size(76, 25)
        Me.bt_del_sat.TabIndex = 6
        Me.bt_del_sat.Text = "Hapus"
        Me.bt_del_sat.UseVisualStyleBackColor = True
        Me.bt_del_sat.Visible = False
        '
        'bt_deact_sat
        '
        Me.bt_deact_sat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_deact_sat.Location = New System.Drawing.Point(456, 74)
        Me.bt_deact_sat.Name = "bt_deact_sat"
        Me.bt_deact_sat.Size = New System.Drawing.Size(76, 25)
        Me.bt_deact_sat.TabIndex = 389
        Me.bt_deact_sat.Text = "Activate"
        Me.bt_deact_sat.UseVisualStyleBackColor = True
        '
        'bt_save_sat
        '
        Me.bt_save_sat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_save_sat.Location = New System.Drawing.Point(377, 74)
        Me.bt_save_sat.Name = "bt_save_sat"
        Me.bt_save_sat.Size = New System.Drawing.Size(76, 25)
        Me.bt_save_sat.TabIndex = 388
        Me.bt_save_sat.Text = "Simpan"
        Me.bt_save_sat.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 387
        Me.Label6.Text = "Kode"
        '
        'in_sat_id
        '
        Me.in_sat_id.Location = New System.Drawing.Point(76, 24)
        Me.in_sat_id.Name = "in_sat_id"
        Me.in_sat_id.Size = New System.Drawing.Size(138, 20)
        Me.in_sat_id.TabIndex = 386
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 385
        Me.Label2.Text = "Keterangan"
        '
        'in_sat_ket
        '
        Me.in_sat_ket.Location = New System.Drawing.Point(76, 48)
        Me.in_sat_ket.Name = "in_sat_ket"
        Me.in_sat_ket.Size = New System.Drawing.Size(456, 20)
        Me.in_sat_ket.TabIndex = 384
        '
        'dgv_sat
        '
        Me.dgv_sat.AllowUserToAddRows = False
        Me.dgv_sat.AllowUserToDeleteRows = False
        Me.dgv_sat.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv_sat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_sat.Location = New System.Drawing.Point(11, 102)
        Me.dgv_sat.MultiSelect = False
        Me.dgv_sat.Name = "dgv_sat"
        Me.dgv_sat.ReadOnly = True
        Me.dgv_sat.RowHeadersVisible = False
        Me.dgv_sat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_sat.Size = New System.Drawing.Size(521, 148)
        Me.dgv_sat.TabIndex = 383
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(234, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 359
        Me.Label3.Text = "Satuan"
        '
        'in_sat_nm
        '
        Me.in_sat_nm.Location = New System.Drawing.Point(281, 22)
        Me.in_sat_nm.Name = "in_sat_nm"
        Me.in_sat_nm.Size = New System.Drawing.Size(251, 20)
        Me.in_sat_nm.TabIndex = 358
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(6, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 357
        Me.Label4.Text = "Satuan Barang"
        '
        'pnl_kab
        '
        Me.pnl_kab.AutoScroll = True
        Me.pnl_kab.BackColor = System.Drawing.Color.White
        Me.pnl_kab.Controls.Add(Me.lk_kab_refresh)
        Me.pnl_kab.Controls.Add(Me.bt_del_kab)
        Me.pnl_kab.Controls.Add(Me.bt_deact_kab)
        Me.pnl_kab.Controls.Add(Me.bt_save_kab)
        Me.pnl_kab.Controls.Add(Me.Label5)
        Me.pnl_kab.Controls.Add(Me.in_kab_id)
        Me.pnl_kab.Controls.Add(Me.dgv_kab)
        Me.pnl_kab.Controls.Add(Me.Label7)
        Me.pnl_kab.Controls.Add(Me.in_kab_n)
        Me.pnl_kab.Controls.Add(Me.Label16)
        Me.pnl_kab.Location = New System.Drawing.Point(6, 274)
        Me.pnl_kab.Name = "pnl_kab"
        Me.pnl_kab.Size = New System.Drawing.Size(546, 262)
        Me.pnl_kab.TabIndex = 1
        '
        'lk_kab_refresh
        '
        Me.lk_kab_refresh.AutoSize = True
        Me.lk_kab_refresh.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lk_kab_refresh.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lk_kab_refresh.Location = New System.Drawing.Point(11, 57)
        Me.lk_kab_refresh.Name = "lk_kab_refresh"
        Me.lk_kab_refresh.Size = New System.Drawing.Size(47, 15)
        Me.lk_kab_refresh.TabIndex = 389
        Me.lk_kab_refresh.TabStop = True
        Me.lk_kab_refresh.Text = "Refresh"
        '
        'bt_del_kab
        '
        Me.bt_del_kab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_del_kab.Location = New System.Drawing.Point(216, 51)
        Me.bt_del_kab.Name = "bt_del_kab"
        Me.bt_del_kab.Size = New System.Drawing.Size(76, 25)
        Me.bt_del_kab.TabIndex = 387
        Me.bt_del_kab.Text = "Hapus"
        Me.bt_del_kab.UseVisualStyleBackColor = True
        Me.bt_del_kab.Visible = False
        '
        'bt_deact_kab
        '
        Me.bt_deact_kab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_deact_kab.Location = New System.Drawing.Point(456, 51)
        Me.bt_deact_kab.Name = "bt_deact_kab"
        Me.bt_deact_kab.Size = New System.Drawing.Size(76, 25)
        Me.bt_deact_kab.TabIndex = 386
        Me.bt_deact_kab.Text = "Activate"
        Me.bt_deact_kab.UseVisualStyleBackColor = True
        '
        'bt_save_kab
        '
        Me.bt_save_kab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_save_kab.Location = New System.Drawing.Point(377, 51)
        Me.bt_save_kab.Name = "bt_save_kab"
        Me.bt_save_kab.Size = New System.Drawing.Size(76, 25)
        Me.bt_save_kab.TabIndex = 6
        Me.bt_save_kab.Text = "Simpan"
        Me.bt_save_kab.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 13)
        Me.Label5.TabIndex = 385
        Me.Label5.Text = "ID"
        '
        'in_kab_id
        '
        Me.in_kab_id.BackColor = System.Drawing.Color.White
        Me.in_kab_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kab_id.ForeColor = System.Drawing.Color.Black
        Me.in_kab_id.Location = New System.Drawing.Point(40, 25)
        Me.in_kab_id.MaxLength = 10
        Me.in_kab_id.Name = "in_kab_id"
        Me.in_kab_id.ReadOnly = True
        Me.in_kab_id.Size = New System.Drawing.Size(102, 20)
        Me.in_kab_id.TabIndex = 384
        Me.in_kab_id.TabStop = False
        '
        'dgv_kab
        '
        Me.dgv_kab.AllowUserToAddRows = False
        Me.dgv_kab.AllowUserToDeleteRows = False
        Me.dgv_kab.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv_kab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_kab.Location = New System.Drawing.Point(11, 82)
        Me.dgv_kab.MultiSelect = False
        Me.dgv_kab.Name = "dgv_kab"
        Me.dgv_kab.ReadOnly = True
        Me.dgv_kab.RowHeadersVisible = False
        Me.dgv_kab.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_kab.Size = New System.Drawing.Size(521, 167)
        Me.dgv_kab.TabIndex = 383
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(167, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 359
        Me.Label7.Text = "Area"
        '
        'in_kab_n
        '
        Me.in_kab_n.Location = New System.Drawing.Point(212, 25)
        Me.in_kab_n.Name = "in_kab_n"
        Me.in_kab_n.Size = New System.Drawing.Size(320, 20)
        Me.in_kab_n.TabIndex = 358
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(6, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 13)
        Me.Label16.TabIndex = 357
        Me.Label16.Text = "Ref.Kabupaten"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Controls.Add(Me.bt_simpanbeli)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 484)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(747, 40)
        Me.Panel5.TabIndex = 2
        '
        'bt_simpanbeli
        '
        Me.bt_simpanbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbeli.Location = New System.Drawing.Point(627, 6)
        Me.bt_simpanbeli.Name = "bt_simpanbeli"
        Me.bt_simpanbeli.Size = New System.Drawing.Size(108, 30)
        Me.bt_simpanbeli.TabIndex = 5
        Me.bt_simpanbeli.Text = "OK"
        Me.bt_simpanbeli.UseVisualStyleBackColor = True
        '
        'fr_reference
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(747, 534)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fr_reference"
        Me.Text = "Referensi"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.pnl_area.ResumeLayout(False)
        Me.pnl_area.PerformLayout()
        CType(Me.dgv_area, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_satbrg.ResumeLayout(False)
        Me.pnl_satbrg.PerformLayout()
        CType(Me.dgv_sat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_kab.ResumeLayout(False)
        Me.pnl_kab.PerformLayout()
        CType(Me.dgv_kab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents bt_simpanbeli As System.Windows.Forms.Button
    Friend WithEvents pnl_kab As System.Windows.Forms.Panel
    Friend WithEvents bt_del_kab As System.Windows.Forms.Button
    Friend WithEvents bt_deact_kab As System.Windows.Forms.Button
    Friend WithEvents bt_save_kab As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_kab_id As System.Windows.Forms.TextBox
    Friend WithEvents dgv_kab As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents in_kab_n As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents pnl_area As System.Windows.Forms.Panel
    Friend WithEvents bt_del_area As System.Windows.Forms.Button
    Friend WithEvents bt_deact_area As System.Windows.Forms.Button
    Friend WithEvents bt_save_area As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents in_area_id As System.Windows.Forms.TextBox
    Friend WithEvents dgv_area As System.Windows.Forms.DataGridView
    Friend WithEvents cb_area_kab As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents in_area_n As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pnl_satbrg As System.Windows.Forms.Panel
    Friend WithEvents bt_del_sat As System.Windows.Forms.Button
    Friend WithEvents bt_deact_sat As System.Windows.Forms.Button
    Friend WithEvents bt_save_sat As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents in_sat_id As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_sat_ket As System.Windows.Forms.TextBox
    Friend WithEvents dgv_sat As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents in_sat_nm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lk_sat_refresh As System.Windows.Forms.LinkLabel
    Friend WithEvents lk_area_refresh As System.Windows.Forms.LinkLabel
    Friend WithEvents lk_kab_refresh As System.Windows.Forms.LinkLabel
    Friend WithEvents bt_satbrg As System.Windows.Forms.Button
    Friend WithEvents bt_kabupaten As System.Windows.Forms.Button
    Friend WithEvents bt_kodearea As System.Windows.Forms.Button
End Class
