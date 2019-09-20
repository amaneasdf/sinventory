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
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_judul = New System.Windows.Forms.Label()
        Me.pnl_container = New System.Windows.Forms.Panel()
        Me.bt_search = New System.Windows.Forms.Button()
        Me.in_cari = New System.Windows.Forms.TextBox()
        Me.bt_export_other = New System.Windows.Forms.Button()
        Me.bt_page_next = New System.Windows.Forms.Button()
        Me.bt_page_last = New System.Windows.Forms.Button()
        Me.bt_simpanbeli = New System.Windows.Forms.Button()
        Me.bt_page_prev = New System.Windows.Forms.Button()
        Me.bt_page_first = New System.Windows.Forms.Button()
        Me.in_page = New System.Windows.Forms.TextBox()
        Me.bt_samamasapajak = New System.Windows.Forms.Button()
        Me.bt_urutnopajak = New System.Windows.Forms.Button()
        Me.bt_export = New System.Windows.Forms.Button()
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
        Me.faktur_filler = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.date_tgl = New System.Windows.Forms.DateTimePicker()
        Me.in_id = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.date_periode = New System.Windows.Forms.DateTimePicker()
        Me.bt_deletetemplate = New System.Windows.Forms.Button()
        Me.bt_savetemplate = New System.Windows.Forms.Button()
        Me.bt_refresh = New System.Windows.Forms.Button()
        Me.bt_createtemplate = New System.Windows.Forms.Button()
        Me.bt_loadtemplate = New System.Windows.Forms.Button()
        Me.ctxMn_dgv = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mn_viewdetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_editdetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_removefaktur = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxMn_export = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mn_export_efak = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_export_jual = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_exportjual_master = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnl_head = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.in_ppn = New System.Windows.Forms.TextBox()
        Me.in_fak = New System.Windows.Forms.TextBox()
        Me.in_dpp = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_supplier = New System.Windows.Forms.Label()
        Me.in_supplier = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.pnl_container.SuspendLayout()
        CType(Me.dgv_faktur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMn_dgv.SuspendLayout()
        Me.ctxMn_export.SuspendLayout()
        Me.pnl_head.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.lbl_judul)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1060, 42)
        Me.Panel1.TabIndex = 1
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
        Me.pnl_container.Controls.Add(Me.bt_search)
        Me.pnl_container.Controls.Add(Me.in_cari)
        Me.pnl_container.Controls.Add(Me.bt_export_other)
        Me.pnl_container.Controls.Add(Me.bt_page_next)
        Me.pnl_container.Controls.Add(Me.bt_page_last)
        Me.pnl_container.Controls.Add(Me.bt_simpanbeli)
        Me.pnl_container.Controls.Add(Me.bt_page_prev)
        Me.pnl_container.Controls.Add(Me.bt_page_first)
        Me.pnl_container.Controls.Add(Me.in_page)
        Me.pnl_container.Controls.Add(Me.bt_samamasapajak)
        Me.pnl_container.Controls.Add(Me.bt_urutnopajak)
        Me.pnl_container.Controls.Add(Me.bt_export)
        Me.pnl_container.Controls.Add(Me.dgv_faktur)
        Me.pnl_container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_container.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_container.Location = New System.Drawing.Point(0, 93)
        Me.pnl_container.Name = "pnl_container"
        Me.pnl_container.Size = New System.Drawing.Size(833, 524)
        Me.pnl_container.TabIndex = 0
        '
        'bt_search
        '
        Me.bt_search.BackColor = System.Drawing.Color.Gainsboro
        Me.bt_search.BackgroundImage = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.bt_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_search.Location = New System.Drawing.Point(259, 10)
        Me.bt_search.Name = "bt_search"
        Me.bt_search.Size = New System.Drawing.Size(42, 22)
        Me.bt_search.TabIndex = 44
        Me.bt_search.UseVisualStyleBackColor = False
        '
        'in_cari
        '
        Me.in_cari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari.Location = New System.Drawing.Point(12, 10)
        Me.in_cari.MaxLength = 100
        Me.in_cari.Name = "in_cari"
        Me.in_cari.Size = New System.Drawing.Size(248, 22)
        Me.in_cari.TabIndex = 43
        '
        'bt_export_other
        '
        Me.bt_export_other.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_export_other.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_export_other.BackgroundImage = Global.Inventory.My.Resources.Resources.downarrow_white
        Me.bt_export_other.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_export_other.Enabled = False
        Me.bt_export_other.FlatAppearance.BorderSize = 0
        Me.bt_export_other.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_export_other.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_export_other.ForeColor = System.Drawing.Color.White
        Me.bt_export_other.Location = New System.Drawing.Point(797, 6)
        Me.bt_export_other.Name = "bt_export_other"
        Me.bt_export_other.Size = New System.Drawing.Size(30, 30)
        Me.bt_export_other.TabIndex = 42
        Me.bt_export_other.UseVisualStyleBackColor = False
        '
        'bt_page_next
        '
        Me.bt_page_next.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_page_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_page_next.Location = New System.Drawing.Point(761, 472)
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
        Me.bt_page_last.Location = New System.Drawing.Point(797, 472)
        Me.bt_page_last.Name = "bt_page_last"
        Me.bt_page_last.Size = New System.Drawing.Size(30, 30)
        Me.bt_page_last.TabIndex = 17
        Me.bt_page_last.Text = ">>"
        Me.bt_page_last.UseVisualStyleBackColor = True
        '
        'bt_simpanbeli
        '
        Me.bt_simpanbeli.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_simpanbeli.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpanbeli.Enabled = False
        Me.bt_simpanbeli.FlatAppearance.BorderSize = 0
        Me.bt_simpanbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpanbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbeli.ForeColor = System.Drawing.Color.White
        Me.bt_simpanbeli.Location = New System.Drawing.Point(12, 470)
        Me.bt_simpanbeli.Name = "bt_simpanbeli"
        Me.bt_simpanbeli.Size = New System.Drawing.Size(175, 32)
        Me.bt_simpanbeli.TabIndex = 10
        Me.bt_simpanbeli.Text = "Tambahkan Faktur"
        Me.bt_simpanbeli.UseVisualStyleBackColor = False
        '
        'bt_page_prev
        '
        Me.bt_page_prev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_page_prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_page_prev.Location = New System.Drawing.Point(673, 472)
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
        Me.bt_page_first.Location = New System.Drawing.Point(637, 472)
        Me.bt_page_first.Name = "bt_page_first"
        Me.bt_page_first.Size = New System.Drawing.Size(30, 30)
        Me.bt_page_first.TabIndex = 13
        Me.bt_page_first.Text = "<<"
        Me.bt_page_first.UseVisualStyleBackColor = True
        '
        'in_page
        '
        Me.in_page.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.in_page.Location = New System.Drawing.Point(709, 476)
        Me.in_page.Name = "in_page"
        Me.in_page.ReadOnly = True
        Me.in_page.Size = New System.Drawing.Size(46, 22)
        Me.in_page.TabIndex = 15
        Me.in_page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'bt_samamasapajak
        '
        Me.bt_samamasapajak.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_samamasapajak.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_samamasapajak.Enabled = False
        Me.bt_samamasapajak.FlatAppearance.BorderSize = 0
        Me.bt_samamasapajak.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_samamasapajak.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_samamasapajak.ForeColor = System.Drawing.Color.White
        Me.bt_samamasapajak.Location = New System.Drawing.Point(193, 470)
        Me.bt_samamasapajak.Name = "bt_samamasapajak"
        Me.bt_samamasapajak.Size = New System.Drawing.Size(175, 32)
        Me.bt_samamasapajak.TabIndex = 11
        Me.bt_samamasapajak.Text = "Samakan Masa Pajak"
        Me.bt_samamasapajak.UseVisualStyleBackColor = False
        '
        'bt_urutnopajak
        '
        Me.bt_urutnopajak.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bt_urutnopajak.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_urutnopajak.Enabled = False
        Me.bt_urutnopajak.FlatAppearance.BorderSize = 0
        Me.bt_urutnopajak.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_urutnopajak.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_urutnopajak.ForeColor = System.Drawing.Color.White
        Me.bt_urutnopajak.Location = New System.Drawing.Point(374, 470)
        Me.bt_urutnopajak.Name = "bt_urutnopajak"
        Me.bt_urutnopajak.Size = New System.Drawing.Size(175, 32)
        Me.bt_urutnopajak.TabIndex = 12
        Me.bt_urutnopajak.Text = "Urutkan Nomor Pajak"
        Me.bt_urutnopajak.UseVisualStyleBackColor = False
        '
        'bt_export
        '
        Me.bt_export.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_export.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_export.Enabled = False
        Me.bt_export.FlatAppearance.BorderSize = 0
        Me.bt_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_export.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_export.ForeColor = System.Drawing.Color.White
        Me.bt_export.Location = New System.Drawing.Point(637, 6)
        Me.bt_export.Name = "bt_export"
        Me.bt_export.Size = New System.Drawing.Size(161, 30)
        Me.bt_export.TabIndex = 6
        Me.bt_export.Text = "Export"
        Me.bt_export.UseVisualStyleBackColor = False
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
        Me.dgv_faktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.faktur_ck, Me.faktur_kode, Me.faktur_tgl_trans, Me.faktur_tgl_pajak, Me.faktur_nopajak, Me.faktur_custo, Me.faktur_npwp, Me.faktur_dpp, Me.faktur_ppn, Me.faktur_filler})
        Me.dgv_faktur.Location = New System.Drawing.Point(12, 42)
        Me.dgv_faktur.MultiSelect = False
        Me.dgv_faktur.Name = "dgv_faktur"
        Me.dgv_faktur.RowHeadersVisible = False
        Me.dgv_faktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_faktur.Size = New System.Drawing.Size(815, 421)
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
        Me.faktur_kode.Width = 125
        '
        'faktur_tgl_trans
        '
        Me.faktur_tgl_trans.DataPropertyName = "faktur_tanggal_trans"
        Me.faktur_tgl_trans.HeaderText = "Tanggal Transaksi"
        Me.faktur_tgl_trans.Name = "faktur_tgl_trans"
        Me.faktur_tgl_trans.ReadOnly = True
        Me.faktur_tgl_trans.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.faktur_tgl_trans.Width = 120
        '
        'faktur_tgl_pajak
        '
        Me.faktur_tgl_pajak.DataPropertyName = "e_list_tglpajak"
        Me.faktur_tgl_pajak.HeaderText = "Tanggal Pajak"
        Me.faktur_tgl_pajak.Name = "faktur_tgl_pajak"
        Me.faktur_tgl_pajak.ReadOnly = True
        Me.faktur_tgl_pajak.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.faktur_tgl_pajak.Width = 120
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
        'faktur_filler
        '
        Me.faktur_filler.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.faktur_filler.HeaderText = ""
        Me.faktur_filler.Name = "faktur_filler"
        Me.faktur_filler.ReadOnly = True
        '
        'date_tgl
        '
        Me.date_tgl.Location = New System.Drawing.Point(84, 425)
        Me.date_tgl.Name = "date_tgl"
        Me.date_tgl.Size = New System.Drawing.Size(136, 20)
        Me.date_tgl.TabIndex = 4
        Me.date_tgl.Visible = False
        '
        'in_id
        '
        Me.in_id.BackColor = System.Drawing.Color.White
        Me.in_id.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_id.Location = New System.Drawing.Point(67, 9)
        Me.in_id.Name = "in_id"
        Me.in_id.ReadOnly = True
        Me.in_id.Size = New System.Drawing.Size(56, 22)
        Me.in_id.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 15)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Periode"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 429)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Tanggal"
        Me.Label5.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 15)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "ID Export"
        '
        'date_periode
        '
        Me.date_periode.CustomFormat = "MMMM yyyy"
        Me.date_periode.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date_periode.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.date_periode.Location = New System.Drawing.Point(67, 41)
        Me.date_periode.Name = "date_periode"
        Me.date_periode.Size = New System.Drawing.Size(153, 22)
        Me.date_periode.TabIndex = 5
        '
        'bt_deletetemplate
        '
        Me.bt_deletetemplate.Enabled = False
        Me.bt_deletetemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_deletetemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_deletetemplate.Image = Global.Inventory.My.Resources.Resources.Delete_16x16
        Me.bt_deletetemplate.Location = New System.Drawing.Point(99, 333)
        Me.bt_deletetemplate.Name = "bt_deletetemplate"
        Me.bt_deletetemplate.Size = New System.Drawing.Size(121, 30)
        Me.bt_deletetemplate.TabIndex = 8
        Me.bt_deletetemplate.Text = "Hapus Daftar"
        Me.bt_deletetemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_deletetemplate.UseVisualStyleBackColor = True
        '
        'bt_savetemplate
        '
        Me.bt_savetemplate.Enabled = False
        Me.bt_savetemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_savetemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_savetemplate.Image = Global.Inventory.My.Resources.Resources.Add_16x16
        Me.bt_savetemplate.Location = New System.Drawing.Point(99, 369)
        Me.bt_savetemplate.Name = "bt_savetemplate"
        Me.bt_savetemplate.Size = New System.Drawing.Size(121, 30)
        Me.bt_savetemplate.TabIndex = 7
        Me.bt_savetemplate.Text = "Simpan Detail"
        Me.bt_savetemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_savetemplate.UseVisualStyleBackColor = True
        '
        'bt_refresh
        '
        Me.bt_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_refresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_refresh.Location = New System.Drawing.Point(292, 10)
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
        Me.bt_createtemplate.Location = New System.Drawing.Point(152, 10)
        Me.bt_createtemplate.Name = "bt_createtemplate"
        Me.bt_createtemplate.Size = New System.Drawing.Size(134, 30)
        Me.bt_createtemplate.TabIndex = 1
        Me.bt_createtemplate.Text = "Buat Export Baru"
        Me.bt_createtemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_createtemplate.UseVisualStyleBackColor = True
        '
        'bt_loadtemplate
        '
        Me.bt_loadtemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_loadtemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_loadtemplate.Image = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.bt_loadtemplate.Location = New System.Drawing.Point(12, 10)
        Me.bt_loadtemplate.Name = "bt_loadtemplate"
        Me.bt_loadtemplate.Size = New System.Drawing.Size(134, 30)
        Me.bt_loadtemplate.TabIndex = 0
        Me.bt_loadtemplate.Text = "Pilih Data Export"
        Me.bt_loadtemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_loadtemplate.UseVisualStyleBackColor = True
        '
        'ctxMn_dgv
        '
        Me.ctxMn_dgv.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_viewdetail, Me.mn_editdetail, Me.mn_removefaktur})
        Me.ctxMn_dgv.Name = "ctxMn_dgv"
        Me.ctxMn_dgv.Size = New System.Drawing.Size(149, 70)
        '
        'mn_viewdetail
        '
        Me.mn_viewdetail.Image = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.mn_viewdetail.Name = "mn_viewdetail"
        Me.mn_viewdetail.Size = New System.Drawing.Size(148, 22)
        Me.mn_viewdetail.Text = "View Detail"
        '
        'mn_editdetail
        '
        Me.mn_editdetail.Name = "mn_editdetail"
        Me.mn_editdetail.Size = New System.Drawing.Size(148, 22)
        Me.mn_editdetail.Text = "Edit Data Item"
        '
        'mn_removefaktur
        '
        Me.mn_removefaktur.Image = Global.Inventory.My.Resources.Resources.Delete_16x16
        Me.mn_removefaktur.Name = "mn_removefaktur"
        Me.mn_removefaktur.Size = New System.Drawing.Size(148, 22)
        Me.mn_removefaktur.Text = "Remove"
        '
        'ctxMn_export
        '
        Me.ctxMn_export.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_export_efak, Me.mn_export_jual, Me.mn_exportjual_master})
        Me.ctxMn_export.Name = "ctxMn_export"
        Me.ctxMn_export.Size = New System.Drawing.Size(238, 70)
        '
        'mn_export_efak
        '
        Me.mn_export_efak.Name = "mn_export_efak"
        Me.mn_export_efak.Size = New System.Drawing.Size(237, 22)
        Me.mn_export_efak.Text = "Export E-Faktur"
        '
        'mn_export_jual
        '
        Me.mn_export_jual.Name = "mn_export_jual"
        Me.mn_export_jual.Size = New System.Drawing.Size(237, 22)
        Me.mn_export_jual.Text = "Export Data Penjualan"
        '
        'mn_exportjual_master
        '
        Me.mn_exportjual_master.Name = "mn_exportjual_master"
        Me.mn_exportjual_master.Size = New System.Drawing.Size(237, 22)
        Me.mn_exportjual_master.Text = "Export Data Penjualan (Master)"
        '
        'pnl_head
        '
        Me.pnl_head.Controls.Add(Me.bt_loadtemplate)
        Me.pnl_head.Controls.Add(Me.bt_createtemplate)
        Me.pnl_head.Controls.Add(Me.bt_refresh)
        Me.pnl_head.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_head.Location = New System.Drawing.Point(0, 42)
        Me.pnl_head.Name = "pnl_head"
        Me.pnl_head.Size = New System.Drawing.Size(1060, 51)
        Me.pnl_head.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.in_ppn)
        Me.Panel2.Controls.Add(Me.in_fak)
        Me.Panel2.Controls.Add(Me.in_dpp)
        Me.Panel2.Controls.Add(Me.date_tgl)
        Me.Panel2.Controls.Add(Me.in_ket)
        Me.Panel2.Controls.Add(Me.in_supplier)
        Me.Panel2.Controls.Add(Me.in_id)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.lbl_supplier)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.date_periode)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.bt_deletetemplate)
        Me.Panel2.Controls.Add(Me.bt_savetemplate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(833, 93)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(227, 524)
        Me.Panel2.TabIndex = 3
        '
        'in_ppn
        '
        Me.in_ppn.BackColor = System.Drawing.Color.White
        Me.in_ppn.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ppn.Location = New System.Drawing.Point(67, 302)
        Me.in_ppn.Name = "in_ppn"
        Me.in_ppn.ReadOnly = True
        Me.in_ppn.Size = New System.Drawing.Size(153, 22)
        Me.in_ppn.TabIndex = 3
        Me.in_ppn.TabStop = False
        Me.in_ppn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_fak
        '
        Me.in_fak.BackColor = System.Drawing.Color.White
        Me.in_fak.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_fak.Location = New System.Drawing.Point(67, 252)
        Me.in_fak.Name = "in_fak"
        Me.in_fak.ReadOnly = True
        Me.in_fak.Size = New System.Drawing.Size(153, 22)
        Me.in_fak.TabIndex = 3
        Me.in_fak.TabStop = False
        Me.in_fak.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'in_dpp
        '
        Me.in_dpp.BackColor = System.Drawing.Color.White
        Me.in_dpp.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_dpp.Location = New System.Drawing.Point(67, 277)
        Me.in_dpp.Name = "in_dpp"
        Me.in_dpp.ReadOnly = True
        Me.in_dpp.Size = New System.Drawing.Size(153, 22)
        Me.in_dpp.TabIndex = 3
        Me.in_dpp.TabStop = False
        Me.in_dpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 306)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 15)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Total PPN"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 256)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 15)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Jml.Faktur"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 281)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 15)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Total DPP"
        '
        'lbl_supplier
        '
        Me.lbl_supplier.AutoSize = True
        Me.lbl_supplier.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_supplier.Location = New System.Drawing.Point(6, 69)
        Me.lbl_supplier.Name = "lbl_supplier"
        Me.lbl_supplier.Size = New System.Drawing.Size(50, 15)
        Me.lbl_supplier.TabIndex = 41
        Me.lbl_supplier.Text = "Supplier"
        '
        'in_supplier
        '
        Me.in_supplier.BackColor = System.Drawing.Color.White
        Me.in_supplier.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier.Location = New System.Drawing.Point(67, 66)
        Me.in_supplier.Name = "in_supplier"
        Me.in_supplier.ReadOnly = True
        Me.in_supplier.Size = New System.Drawing.Size(153, 22)
        Me.in_supplier.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 15)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Ket."
        '
        'in_ket
        '
        Me.in_ket.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.Location = New System.Drawing.Point(67, 91)
        Me.in_ket.Multiline = True
        Me.in_ket.Name = "in_ket"
        Me.in_ket.Size = New System.Drawing.Size(153, 81)
        Me.in_ket.TabIndex = 3
        '
        'fr_export_efaktur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnl_container)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnl_head)
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
        Me.ctxMn_export.ResumeLayout(False)
        Me.pnl_head.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
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
    Friend WithEvents mn_editdetail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bt_export_other As System.Windows.Forms.Button
    Friend WithEvents ctxMn_export As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mn_export_efak As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_export_jual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_exportjual_master As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnl_head As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents in_ppn As System.Windows.Forms.TextBox
    Friend WithEvents in_fak As System.Windows.Forms.TextBox
    Friend WithEvents in_dpp As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents faktur_ck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents faktur_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_tgl_trans As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_tgl_pajak As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_nopajak As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_npwp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_dpp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_ppn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_filler As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bt_search As System.Windows.Forms.Button
    Friend WithEvents in_cari As System.Windows.Forms.TextBox
    Friend WithEvents in_supplier As System.Windows.Forms.TextBox
    Friend WithEvents lbl_supplier As System.Windows.Forms.Label
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
