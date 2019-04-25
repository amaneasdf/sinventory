<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_export_efaktur
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_judul = New System.Windows.Forms.Label()
        Me.pnl_container = New System.Windows.Forms.Panel()
        Me.date_tgl = New System.Windows.Forms.DateTimePicker()
        Me.bt_page_next = New System.Windows.Forms.Button()
        Me.bt_page_last = New System.Windows.Forms.Button()
        Me.bt_simpanbeli = New System.Windows.Forms.Button()
        Me.bt_page_prev = New System.Windows.Forms.Button()
        Me.bt_page_first = New System.Windows.Forms.Button()
        Me.in_page = New System.Windows.Forms.TextBox()
        Me.in_id = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.date_periode = New System.Windows.Forms.DateTimePicker()
        Me.bt_samamasapajak = New System.Windows.Forms.Button()
        Me.bt_urutnopajak = New System.Windows.Forms.Button()
        Me.bt_export = New System.Windows.Forms.Button()
        Me.bt_deletetemplate = New System.Windows.Forms.Button()
        Me.bt_savetemplate = New System.Windows.Forms.Button()
        Me.bt_refresh = New System.Windows.Forms.Button()
        Me.bt_createtemplate = New System.Windows.Forms.Button()
        Me.bt_loadtemplate = New System.Windows.Forms.Button()
        Me.dgv_faktur = New System.Windows.Forms.DataGridView()
        Me.faktur_ck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.faktur_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_tgl_trans = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_tgl_pajak = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_nopajak = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_custo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_npwp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_dpp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_ppn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ctxMn_dgv = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mn_viewdetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_removefaktur = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.pnl_container.SuspendLayout()
        CType(Me.dgv_faktur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMn_dgv.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.lbl_close)
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.lbl_judul)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1060, 42)
        Me.Panel1.TabIndex = 1
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(980, 8)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(52, 22)
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
        Me.bt_cl.Location = New System.Drawing.Point(1033, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 8
        Me.bt_cl.TabStop = False
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_judul
        '
        Me.lbl_judul.AutoSize = True
        Me.lbl_judul.BackColor = System.Drawing.Color.Orange
        Me.lbl_judul.Font = New System.Drawing.Font("Open Sans", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_judul.ForeColor = System.Drawing.Color.White
        Me.lbl_judul.Location = New System.Drawing.Point(6, 3)
        Me.lbl_judul.Name = "lbl_judul"
        Me.lbl_judul.Size = New System.Drawing.Size(199, 33)
        Me.lbl_judul.TabIndex = 136
        Me.lbl_judul.Text = "Export E-Faktur"
        '
        'pnl_container
        '
        Me.pnl_container.AutoScroll = True
        Me.pnl_container.Controls.Add(Me.date_tgl)
        Me.pnl_container.Controls.Add(Me.bt_page_next)
        Me.pnl_container.Controls.Add(Me.bt_page_last)
        Me.pnl_container.Controls.Add(Me.bt_simpanbeli)
        Me.pnl_container.Controls.Add(Me.bt_page_prev)
        Me.pnl_container.Controls.Add(Me.bt_page_first)
        Me.pnl_container.Controls.Add(Me.in_page)
        Me.pnl_container.Controls.Add(Me.in_id)
        Me.pnl_container.Controls.Add(Me.Label6)
        Me.pnl_container.Controls.Add(Me.Label5)
        Me.pnl_container.Controls.Add(Me.Label2)
        Me.pnl_container.Controls.Add(Me.date_periode)
        Me.pnl_container.Controls.Add(Me.bt_samamasapajak)
        Me.pnl_container.Controls.Add(Me.bt_urutnopajak)
        Me.pnl_container.Controls.Add(Me.bt_export)
        Me.pnl_container.Controls.Add(Me.bt_deletetemplate)
        Me.pnl_container.Controls.Add(Me.bt_savetemplate)
        Me.pnl_container.Controls.Add(Me.bt_refresh)
        Me.pnl_container.Controls.Add(Me.bt_createtemplate)
        Me.pnl_container.Controls.Add(Me.bt_loadtemplate)
        Me.pnl_container.Controls.Add(Me.dgv_faktur)
        Me.pnl_container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_container.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_container.Location = New System.Drawing.Point(0, 42)
        Me.pnl_container.Name = "pnl_container"
        Me.pnl_container.Size = New System.Drawing.Size(1060, 575)
        Me.pnl_container.TabIndex = 0
        '
        'date_tgl
        '
        Me.date_tgl.Location = New System.Drawing.Point(70, 71)
        Me.date_tgl.Name = "date_tgl"
        Me.date_tgl.Size = New System.Drawing.Size(136, 22)
        Me.date_tgl.TabIndex = 4
        '
        'bt_page_next
        '
        Me.bt_page_next.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_page_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_page_next.Location = New System.Drawing.Point(894, 504)
        Me.bt_page_next.Name = "bt_page_next"
        Me.bt_page_next.Size = New System.Drawing.Size(30, 30)
        Me.bt_page_next.TabIndex = 16
        Me.bt_page_next.Text = ">"
        Me.bt_page_next.UseVisualStyleBackColor = True
        '
        'bt_page_last
        '
        Me.bt_page_last.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_page_last.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_page_last.Location = New System.Drawing.Point(930, 504)
        Me.bt_page_last.Name = "bt_page_last"
        Me.bt_page_last.Size = New System.Drawing.Size(30, 30)
        Me.bt_page_last.TabIndex = 17
        Me.bt_page_last.Text = ">>"
        Me.bt_page_last.UseVisualStyleBackColor = True
        '
        'bt_simpanbeli
        '
        Me.bt_simpanbeli.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_simpanbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbeli.Location = New System.Drawing.Point(12, 504)
        Me.bt_simpanbeli.Name = "bt_simpanbeli"
        Me.bt_simpanbeli.Size = New System.Drawing.Size(175, 32)
        Me.bt_simpanbeli.TabIndex = 10
        Me.bt_simpanbeli.Text = "Tambahkan Faktur"
        Me.bt_simpanbeli.UseVisualStyleBackColor = True
        '
        'bt_page_prev
        '
        Me.bt_page_prev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_page_prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_page_prev.Location = New System.Drawing.Point(806, 504)
        Me.bt_page_prev.Name = "bt_page_prev"
        Me.bt_page_prev.Size = New System.Drawing.Size(30, 30)
        Me.bt_page_prev.TabIndex = 14
        Me.bt_page_prev.Text = "<"
        Me.bt_page_prev.UseVisualStyleBackColor = True
        '
        'bt_page_first
        '
        Me.bt_page_first.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_page_first.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_page_first.Location = New System.Drawing.Point(770, 504)
        Me.bt_page_first.Name = "bt_page_first"
        Me.bt_page_first.Size = New System.Drawing.Size(30, 30)
        Me.bt_page_first.TabIndex = 13
        Me.bt_page_first.Text = "<<"
        Me.bt_page_first.UseVisualStyleBackColor = True
        '
        'in_page
        '
        Me.in_page.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.in_page.Location = New System.Drawing.Point(842, 508)
        Me.in_page.Name = "in_page"
        Me.in_page.ReadOnly = True
        Me.in_page.Size = New System.Drawing.Size(46, 22)
        Me.in_page.TabIndex = 15
        Me.in_page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'in_id
        '
        Me.in_id.Location = New System.Drawing.Point(70, 45)
        Me.in_id.Name = "in_id"
        Me.in_id.Size = New System.Drawing.Size(56, 22)
        Me.in_id.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(239, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 15)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Periode Pajak"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 15)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Tanggal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "ID Export"
        '
        'date_periode
        '
        Me.date_periode.CustomFormat = "MMMM yyyy"
        Me.date_periode.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.date_periode.Location = New System.Drawing.Point(323, 71)
        Me.date_periode.Name = "date_periode"
        Me.date_periode.Size = New System.Drawing.Size(171, 22)
        Me.date_periode.TabIndex = 5
        '
        'bt_samamasapajak
        '
        Me.bt_samamasapajak.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_samamasapajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_samamasapajak.Location = New System.Drawing.Point(193, 504)
        Me.bt_samamasapajak.Name = "bt_samamasapajak"
        Me.bt_samamasapajak.Size = New System.Drawing.Size(175, 32)
        Me.bt_samamasapajak.TabIndex = 11
        Me.bt_samamasapajak.Text = "Samakan Masa Pajak"
        Me.bt_samamasapajak.UseVisualStyleBackColor = True
        '
        'bt_urutnopajak
        '
        Me.bt_urutnopajak.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_urutnopajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_urutnopajak.Location = New System.Drawing.Point(374, 504)
        Me.bt_urutnopajak.Name = "bt_urutnopajak"
        Me.bt_urutnopajak.Size = New System.Drawing.Size(175, 30)
        Me.bt_urutnopajak.TabIndex = 12
        Me.bt_urutnopajak.Text = "Urutkan Nomor Pajak"
        Me.bt_urutnopajak.UseVisualStyleBackColor = True
        '
        'bt_export
        '
        Me.bt_export.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_export.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_export.Location = New System.Drawing.Point(789, 23)
        Me.bt_export.Name = "bt_export"
        Me.bt_export.Size = New System.Drawing.Size(171, 30)
        Me.bt_export.TabIndex = 6
        Me.bt_export.Text = "Export"
        Me.bt_export.UseVisualStyleBackColor = True
        '
        'bt_deletetemplate
        '
        Me.bt_deletetemplate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_deletetemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_deletetemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_deletetemplate.Image = Global.Inventory.My.Resources.Resources._1492932873_Delete
        Me.bt_deletetemplate.Location = New System.Drawing.Point(861, 66)
        Me.bt_deletetemplate.Name = "bt_deletetemplate"
        Me.bt_deletetemplate.Size = New System.Drawing.Size(99, 30)
        Me.bt_deletetemplate.TabIndex = 8
        Me.bt_deletetemplate.Text = "Hapus"
        Me.bt_deletetemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_deletetemplate.UseVisualStyleBackColor = True
        '
        'bt_savetemplate
        '
        Me.bt_savetemplate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_savetemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_savetemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_savetemplate.Image = Global.Inventory.My.Resources.Resources.Add_16x16
        Me.bt_savetemplate.Location = New System.Drawing.Point(756, 67)
        Me.bt_savetemplate.Name = "bt_savetemplate"
        Me.bt_savetemplate.Size = New System.Drawing.Size(99, 30)
        Me.bt_savetemplate.TabIndex = 7
        Me.bt_savetemplate.Text = "Simpan"
        Me.bt_savetemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_savetemplate.UseVisualStyleBackColor = True
        '
        'bt_refresh
        '
        Me.bt_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_refresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_refresh.Location = New System.Drawing.Point(257, 6)
        Me.bt_refresh.Name = "bt_refresh"
        Me.bt_refresh.Size = New System.Drawing.Size(99, 30)
        Me.bt_refresh.TabIndex = 2
        Me.bt_refresh.Text = "Refresh"
        Me.bt_refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_refresh.UseVisualStyleBackColor = True
        '
        'bt_createtemplate
        '
        Me.bt_createtemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_createtemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_createtemplate.Image = Global.Inventory.My.Resources.Resources.Add_16x16
        Me.bt_createtemplate.Location = New System.Drawing.Point(152, 6)
        Me.bt_createtemplate.Name = "bt_createtemplate"
        Me.bt_createtemplate.Size = New System.Drawing.Size(99, 30)
        Me.bt_createtemplate.TabIndex = 1
        Me.bt_createtemplate.Text = "Buat Baru"
        Me.bt_createtemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_createtemplate.UseVisualStyleBackColor = True
        '
        'bt_loadtemplate
        '
        Me.bt_loadtemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_loadtemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_loadtemplate.Image = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.bt_loadtemplate.Location = New System.Drawing.Point(12, 6)
        Me.bt_loadtemplate.Name = "bt_loadtemplate"
        Me.bt_loadtemplate.Size = New System.Drawing.Size(134, 30)
        Me.bt_loadtemplate.TabIndex = 0
        Me.bt_loadtemplate.Text = "Pilih Data Export"
        Me.bt_loadtemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_loadtemplate.UseVisualStyleBackColor = True
        '
        'dgv_faktur
        '
        Me.dgv_faktur.AllowUserToAddRows = False
        Me.dgv_faktur.AllowUserToDeleteRows = False
        Me.dgv_faktur.AllowUserToResizeRows = False
        Me.dgv_faktur.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_faktur.BackgroundColor = System.Drawing.Color.White
        Me.dgv_faktur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_faktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.faktur_ck, Me.faktur_kode, Me.faktur_tgl_trans, Me.faktur_tgl_pajak, Me.faktur_nopajak, Me.faktur_custo, Me.faktur_npwp, Me.faktur_dpp, Me.faktur_ppn})
        Me.dgv_faktur.Location = New System.Drawing.Point(12, 103)
        Me.dgv_faktur.Name = "dgv_faktur"
        Me.dgv_faktur.RowHeadersVisible = False
        Me.dgv_faktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_faktur.Size = New System.Drawing.Size(948, 394)
        Me.dgv_faktur.TabIndex = 9
        '
        'faktur_ck
        '
        Me.faktur_ck.DataPropertyName = "e_list_selectstate"
        Me.faktur_ck.FalseValue = "0"
        Me.faktur_ck.HeaderText = "Export"
        Me.faktur_ck.IndeterminateValue = "0"
        Me.faktur_ck.Name = "faktur_ck"
        Me.faktur_ck.TrueValue = "1"
        Me.faktur_ck.Width = 50
        '
        'faktur_kode
        '
        Me.faktur_kode.DataPropertyName = "e_list_kodefaktur"
        Me.faktur_kode.HeaderText = "Kode Transaksi"
        Me.faktur_kode.Name = "faktur_kode"
        Me.faktur_kode.ReadOnly = True
        Me.faktur_kode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.faktur_kode.Width = 150
        '
        'faktur_tgl_trans
        '
        Me.faktur_tgl_trans.DataPropertyName = "faktur_tanggal_trans"
        Me.faktur_tgl_trans.HeaderText = "Tanggal Transaksi"
        Me.faktur_tgl_trans.Name = "faktur_tgl_trans"
        Me.faktur_tgl_trans.ReadOnly = True
        Me.faktur_tgl_trans.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.faktur_tgl_trans.Width = 125
        '
        'faktur_tgl_pajak
        '
        Me.faktur_tgl_pajak.DataPropertyName = "e_list_tglpajak"
        Me.faktur_tgl_pajak.HeaderText = "Tanggal Pajak"
        Me.faktur_tgl_pajak.Name = "faktur_tgl_pajak"
        Me.faktur_tgl_pajak.ReadOnly = True
        Me.faktur_tgl_pajak.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.faktur_tgl_pajak.Width = 125
        '
        'faktur_nopajak
        '
        Me.faktur_nopajak.DataPropertyName = "e_list_kodepajak"
        Me.faktur_nopajak.HeaderText = "Nomor Pajak"
        Me.faktur_nopajak.Name = "faktur_nopajak"
        Me.faktur_nopajak.ReadOnly = True
        Me.faktur_nopajak.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.faktur_nopajak.Width = 175
        '
        'faktur_custo
        '
        Me.faktur_custo.DataPropertyName = "faktur_customer"
        Me.faktur_custo.HeaderText = "Customer"
        Me.faktur_custo.Name = "faktur_custo"
        Me.faktur_custo.ReadOnly = True
        Me.faktur_custo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.faktur_custo.Width = 175
        '
        'faktur_npwp
        '
        Me.faktur_npwp.DataPropertyName = "faktur_npwp"
        Me.faktur_npwp.HeaderText = "NPWP"
        Me.faktur_npwp.Name = "faktur_npwp"
        Me.faktur_npwp.Width = 150
        '
        'faktur_dpp
        '
        Me.faktur_dpp.DataPropertyName = "faktur_dpp"
        Me.faktur_dpp.HeaderText = "Total DPP"
        Me.faktur_dpp.Name = "faktur_dpp"
        Me.faktur_dpp.ReadOnly = True
        Me.faktur_dpp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'faktur_ppn
        '
        Me.faktur_ppn.DataPropertyName = "faktur_ppn"
        Me.faktur_ppn.HeaderText = "Total PPN"
        Me.faktur_ppn.Name = "faktur_ppn"
        Me.faktur_ppn.ReadOnly = True
        Me.faktur_ppn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ctxMn_dgv
        '
        Me.ctxMn_dgv.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_viewdetail, Me.mn_removefaktur})
        Me.ctxMn_dgv.Name = "ctxMn_dgv"
        Me.ctxMn_dgv.Size = New System.Drawing.Size(133, 48)
        '
        'mn_viewdetail
        '
        Me.mn_viewdetail.Image = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.mn_viewdetail.Name = "mn_viewdetail"
        Me.mn_viewdetail.Size = New System.Drawing.Size(132, 22)
        Me.mn_viewdetail.Text = "View Detail"
        '
        'mn_removefaktur
        '
        Me.mn_removefaktur.Image = Global.Inventory.My.Resources.Resources._1492932873_Delete
        Me.mn_removefaktur.Name = "mn_removefaktur"
        Me.mn_removefaktur.Size = New System.Drawing.Size(132, 22)
        Me.mn_removefaktur.Text = "Remove"
        '
        'fr_export_efaktur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnl_container)
        Me.Controls.Add(Me.Panel1)
        Me.MinimumSize = New System.Drawing.Size(862, 369)
        Me.Name = "fr_export_efaktur"
        Me.Size = New System.Drawing.Size(1060, 617)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_container.ResumeLayout(False)
        Me.pnl_container.PerformLayout()
        CType(Me.dgv_faktur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMn_dgv.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_judul As System.Windows.Forms.Label
    Friend WithEvents pnl_container As System.Windows.Forms.Panel
    Friend WithEvents dgv_faktur As System.Windows.Forms.DataGridView
    Friend WithEvents bt_simpanbeli As System.Windows.Forms.Button
    Friend WithEvents bt_export As System.Windows.Forms.Button
    Friend WithEvents bt_urutnopajak As System.Windows.Forms.Button
    Friend WithEvents bt_samamasapajak As System.Windows.Forms.Button
    Friend WithEvents date_periode As System.Windows.Forms.DateTimePicker
    Friend WithEvents bt_page_next As System.Windows.Forms.Button
    Friend WithEvents bt_page_last As System.Windows.Forms.Button
    Friend WithEvents bt_page_prev As System.Windows.Forms.Button
    Friend WithEvents bt_page_first As System.Windows.Forms.Button
    Friend WithEvents in_page As System.Windows.Forms.TextBox
    Friend WithEvents bt_createtemplate As System.Windows.Forms.Button
    Friend WithEvents bt_loadtemplate As System.Windows.Forms.Button
    Friend WithEvents in_id As System.Windows.Forms.TextBox
    Friend WithEvents date_tgl As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bt_deletetemplate As System.Windows.Forms.Button
    Friend WithEvents bt_savetemplate As System.Windows.Forms.Button
    Friend WithEvents ctxMn_dgv As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mn_viewdetail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_removefaktur As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bt_refresh As System.Windows.Forms.Button
    Friend WithEvents faktur_ck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents faktur_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_tgl_trans As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_tgl_pajak As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_nopajak As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_npwp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_dpp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_ppn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
