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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_judul = New System.Windows.Forms.Label()
        Me.pnl_container = New System.Windows.Forms.Panel()
        Me.in_jmlpajak = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.in_nopajak = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dt_periodeselect = New System.Windows.Forms.DateTimePicker()
        Me.bt_samamasapajak = New System.Windows.Forms.Button()
        Me.ck_faktur_all = New System.Windows.Forms.CheckBox()
        Me.bt_kosongnopajak = New System.Windows.Forms.Button()
        Me.bt_urutnopajak = New System.Windows.Forms.Button()
        Me.bt_export = New System.Windows.Forms.Button()
        Me.bt_simpanbeli = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ck_period = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ck_no_nomorpajak = New System.Windows.Forms.CheckBox()
        Me.date_tglakhir = New System.Windows.Forms.DateTimePicker()
        Me.date_tglawal = New System.Windows.Forms.DateTimePicker()
        Me.dgv_faktur = New System.Windows.Forms.DataGridView()
        Me.faktur_ck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.faktur_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_tgl_trans = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_tgl_pajak = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_nopajak = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_npwp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_custo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_dpp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.faktur_ppn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.pnl_container.SuspendLayout()
        CType(Me.in_jmlpajak, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_faktur, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(890, 42)
        Me.Panel1.TabIndex = 341
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(810, 8)
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
        Me.bt_cl.Location = New System.Drawing.Point(863, 9)
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
        Me.pnl_container.Controls.Add(Me.in_jmlpajak)
        Me.pnl_container.Controls.Add(Me.Label4)
        Me.pnl_container.Controls.Add(Me.in_nopajak)
        Me.pnl_container.Controls.Add(Me.Label3)
        Me.pnl_container.Controls.Add(Me.dt_periodeselect)
        Me.pnl_container.Controls.Add(Me.bt_samamasapajak)
        Me.pnl_container.Controls.Add(Me.ck_faktur_all)
        Me.pnl_container.Controls.Add(Me.bt_kosongnopajak)
        Me.pnl_container.Controls.Add(Me.bt_urutnopajak)
        Me.pnl_container.Controls.Add(Me.bt_export)
        Me.pnl_container.Controls.Add(Me.bt_simpanbeli)
        Me.pnl_container.Controls.Add(Me.Label1)
        Me.pnl_container.Controls.Add(Me.ck_period)
        Me.pnl_container.Controls.Add(Me.Label2)
        Me.pnl_container.Controls.Add(Me.ck_no_nomorpajak)
        Me.pnl_container.Controls.Add(Me.date_tglakhir)
        Me.pnl_container.Controls.Add(Me.date_tglawal)
        Me.pnl_container.Controls.Add(Me.dgv_faktur)
        Me.pnl_container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_container.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_container.Location = New System.Drawing.Point(0, 42)
        Me.pnl_container.Name = "pnl_container"
        Me.pnl_container.Size = New System.Drawing.Size(890, 575)
        Me.pnl_container.TabIndex = 342
        '
        'in_jmlpajak
        '
        Me.in_jmlpajak.Location = New System.Drawing.Point(12, 343)
        Me.in_jmlpajak.Name = "in_jmlpajak"
        Me.in_jmlpajak.Size = New System.Drawing.Size(171, 22)
        Me.in_jmlpajak.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 321)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 15)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Jml.Faktur"
        '
        'in_nopajak
        '
        Me.in_nopajak.Location = New System.Drawing.Point(12, 296)
        Me.in_nopajak.Name = "in_nopajak"
        Me.in_nopajak.Size = New System.Drawing.Size(171, 22)
        Me.in_nopajak.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 278)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 15)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "No.Faktur Pajak"
        '
        'dt_periodeselect
        '
        Me.dt_periodeselect.CustomFormat = "MMMM yyyy"
        Me.dt_periodeselect.Enabled = False
        Me.dt_periodeselect.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_periodeselect.Location = New System.Drawing.Point(12, 196)
        Me.dt_periodeselect.Name = "dt_periodeselect"
        Me.dt_periodeselect.Size = New System.Drawing.Size(171, 22)
        Me.dt_periodeselect.TabIndex = 6
        '
        'bt_samamasapajak
        '
        Me.bt_samamasapajak.Enabled = False
        Me.bt_samamasapajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_samamasapajak.Location = New System.Drawing.Point(12, 226)
        Me.bt_samamasapajak.Name = "bt_samamasapajak"
        Me.bt_samamasapajak.Size = New System.Drawing.Size(171, 30)
        Me.bt_samamasapajak.TabIndex = 7
        Me.bt_samamasapajak.Text = "Samakan Masa Pajak"
        Me.bt_samamasapajak.UseVisualStyleBackColor = True
        '
        'ck_faktur_all
        '
        Me.ck_faktur_all.AutoSize = True
        Me.ck_faktur_all.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_faktur_all.Location = New System.Drawing.Point(211, 14)
        Me.ck_faktur_all.Name = "ck_faktur_all"
        Me.ck_faktur_all.Size = New System.Drawing.Size(123, 19)
        Me.ck_faktur_all.TabIndex = 12
        Me.ck_faktur_all.Text = "Pilih Semua Faktur"
        Me.ck_faktur_all.UseVisualStyleBackColor = True
        '
        'bt_kosongnopajak
        '
        Me.bt_kosongnopajak.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_kosongnopajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_kosongnopajak.Location = New System.Drawing.Point(712, 6)
        Me.bt_kosongnopajak.Name = "bt_kosongnopajak"
        Me.bt_kosongnopajak.Size = New System.Drawing.Size(171, 30)
        Me.bt_kosongnopajak.TabIndex = 13
        Me.bt_kosongnopajak.Text = "Kosongkan Nomor Pajak"
        Me.bt_kosongnopajak.UseVisualStyleBackColor = True
        '
        'bt_urutnopajak
        '
        Me.bt_urutnopajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_urutnopajak.Location = New System.Drawing.Point(12, 371)
        Me.bt_urutnopajak.Name = "bt_urutnopajak"
        Me.bt_urutnopajak.Size = New System.Drawing.Size(171, 30)
        Me.bt_urutnopajak.TabIndex = 10
        Me.bt_urutnopajak.Text = "Urutkan Nomor Pajak"
        Me.bt_urutnopajak.UseVisualStyleBackColor = True
        '
        'bt_export
        '
        Me.bt_export.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_export.Location = New System.Drawing.Point(12, 461)
        Me.bt_export.Name = "bt_export"
        Me.bt_export.Size = New System.Drawing.Size(171, 30)
        Me.bt_export.TabIndex = 11
        Me.bt_export.Text = "Export"
        Me.bt_export.UseVisualStyleBackColor = True
        '
        'bt_simpanbeli
        '
        Me.bt_simpanbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbeli.Location = New System.Drawing.Point(12, 119)
        Me.bt_simpanbeli.Name = "bt_simpanbeli"
        Me.bt_simpanbeli.Size = New System.Drawing.Size(171, 30)
        Me.bt_simpanbeli.TabIndex = 4
        Me.bt_simpanbeli.Text = "Tampilkan Faktur"
        Me.bt_simpanbeli.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(154, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "S.d"
        '
        'ck_period
        '
        Me.ck_period.AutoSize = True
        Me.ck_period.Enabled = False
        Me.ck_period.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_period.Location = New System.Drawing.Point(12, 171)
        Me.ck_period.Name = "ck_period"
        Me.ck_period.Size = New System.Drawing.Size(147, 19)
        Me.ck_period.TabIndex = 5
        Me.ck_period.Text = "Samakan Periode Pajak"
        Me.ck_period.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(9, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Tanggal Transaksi"
        '
        'ck_no_nomorpajak
        '
        Me.ck_no_nomorpajak.AutoSize = True
        Me.ck_no_nomorpajak.Enabled = False
        Me.ck_no_nomorpajak.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_no_nomorpajak.Location = New System.Drawing.Point(12, 94)
        Me.ck_no_nomorpajak.Name = "ck_no_nomorpajak"
        Me.ck_no_nomorpajak.Size = New System.Drawing.Size(186, 19)
        Me.ck_no_nomorpajak.TabIndex = 3
        Me.ck_no_nomorpajak.Text = "Exclude Faktur Tanpa No.Pajak"
        Me.ck_no_nomorpajak.UseVisualStyleBackColor = True
        '
        'date_tglakhir
        '
        Me.date_tglakhir.Location = New System.Drawing.Point(12, 59)
        Me.date_tglakhir.Name = "date_tglakhir"
        Me.date_tglakhir.Size = New System.Drawing.Size(136, 22)
        Me.date_tglakhir.TabIndex = 2
        '
        'date_tglawal
        '
        Me.date_tglawal.Location = New System.Drawing.Point(12, 33)
        Me.date_tglawal.Name = "date_tglawal"
        Me.date_tglawal.Size = New System.Drawing.Size(136, 22)
        Me.date_tglawal.TabIndex = 0
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
        Me.dgv_faktur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.faktur_ck, Me.faktur_kode, Me.faktur_tgl_trans, Me.faktur_tgl_pajak, Me.faktur_nopajak, Me.faktur_npwp, Me.faktur_custo, Me.faktur_dpp, Me.faktur_ppn})
        Me.dgv_faktur.Location = New System.Drawing.Point(211, 42)
        Me.dgv_faktur.Name = "dgv_faktur"
        Me.dgv_faktur.RowHeadersVisible = False
        Me.dgv_faktur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_faktur.Size = New System.Drawing.Size(672, 478)
        Me.dgv_faktur.TabIndex = 14
        '
        'faktur_ck
        '
        Me.faktur_ck.DataPropertyName = "faktur_select"
        Me.faktur_ck.FalseValue = "0"
        Me.faktur_ck.HeaderText = "Pilih"
        Me.faktur_ck.Name = "faktur_ck"
        Me.faktur_ck.TrueValue = "1"
        Me.faktur_ck.Width = 50
        '
        'faktur_kode
        '
        Me.faktur_kode.DataPropertyName = "faktur_kode"
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
        Me.faktur_tgl_pajak.DataPropertyName = "faktur_pajak_tanggal"
        Me.faktur_tgl_pajak.HeaderText = "Tanggal Pajak"
        Me.faktur_tgl_pajak.Name = "faktur_tgl_pajak"
        Me.faktur_tgl_pajak.ReadOnly = True
        Me.faktur_tgl_pajak.Width = 125
        '
        'faktur_nopajak
        '
        Me.faktur_nopajak.DataPropertyName = "faktur_pajak_no"
        Me.faktur_nopajak.HeaderText = "Nomor Pajak"
        Me.faktur_nopajak.Name = "faktur_nopajak"
        Me.faktur_nopajak.ReadOnly = True
        Me.faktur_nopajak.Width = 175
        '
        'faktur_npwp
        '
        Me.faktur_npwp.DataPropertyName = "customer_npwp"
        Me.faktur_npwp.HeaderText = "NPWP"
        Me.faktur_npwp.Name = "faktur_npwp"
        Me.faktur_npwp.ReadOnly = True
        Me.faktur_npwp.Width = 150
        '
        'faktur_custo
        '
        Me.faktur_custo.DataPropertyName = "customer_nama"
        Me.faktur_custo.HeaderText = "Customer"
        Me.faktur_custo.Name = "faktur_custo"
        Me.faktur_custo.ReadOnly = True
        Me.faktur_custo.Width = 175
        '
        'faktur_dpp
        '
        Me.faktur_dpp.DataPropertyName = "faktur_dpp"
        Me.faktur_dpp.HeaderText = "Total DPP"
        Me.faktur_dpp.Name = "faktur_dpp"
        Me.faktur_dpp.ReadOnly = True
        '
        'faktur_ppn
        '
        Me.faktur_ppn.DataPropertyName = "faktur_ppn"
        Me.faktur_ppn.HeaderText = "Total PPN"
        Me.faktur_ppn.Name = "faktur_ppn"
        Me.faktur_ppn.ReadOnly = True
        '
        'fr_export_efaktur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnl_container)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "fr_export_efaktur"
        Me.Size = New System.Drawing.Size(890, 617)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_container.ResumeLayout(False)
        Me.pnl_container.PerformLayout()
        CType(Me.in_jmlpajak, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_faktur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_judul As System.Windows.Forms.Label
    Friend WithEvents pnl_container As System.Windows.Forms.Panel
    Friend WithEvents dgv_faktur As System.Windows.Forms.DataGridView
    Friend WithEvents date_tglakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_tglawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ck_period As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ck_no_nomorpajak As System.Windows.Forms.CheckBox
    Friend WithEvents bt_simpanbeli As System.Windows.Forms.Button
    Friend WithEvents bt_export As System.Windows.Forms.Button
    Friend WithEvents bt_urutnopajak As System.Windows.Forms.Button
    Friend WithEvents bt_kosongnopajak As System.Windows.Forms.Button
    Friend WithEvents ck_faktur_all As System.Windows.Forms.CheckBox
    Friend WithEvents bt_samamasapajak As System.Windows.Forms.Button
    Friend WithEvents faktur_ck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents faktur_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_tgl_trans As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_tgl_pajak As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_nopajak As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_npwp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_dpp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents faktur_ppn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dt_periodeselect As System.Windows.Forms.DateTimePicker
    Friend WithEvents in_jmlpajak As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents in_nopajak As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
