<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_exportaddfaktur
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_exportaddfaktur))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.bt_cari = New System.Windows.Forms.Button()
        Me.in_cari = New System.Windows.Forms.TextBox()
        Me.dgv_cari = New System.Windows.Forms.DataGridView()
        Me.view_kodefaktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.view_tanggal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.view_custo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.view_nopajak = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv_listfak = New System.Windows.Forms.DataGridView()
        Me.add_kodefaktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.add_tglfaktur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.add_custo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.date_cari = New System.Windows.Forms.DateTimePicker()
        Me.date_tglawal = New System.Windows.Forms.DateTimePicker()
        Me.date_tglakhir = New System.Windows.Forms.DateTimePicker()
        Me.bt_list_delfak = New System.Windows.Forms.Button()
        Me.bt_list_addfak = New System.Windows.Forms.Button()
        Me.lbl_list_countfaktur = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ck_range = New System.Windows.Forms.CheckBox()
        Me.ck_list = New System.Windows.Forms.CheckBox()
        Me.bt_cancel = New System.Windows.Forms.Button()
        Me.bt_load = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        CType(Me.dgv_cari, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_listfak, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.bt_cari)
        Me.Panel2.Controls.Add(Me.in_cari)
        Me.Panel2.Controls.Add(Me.dgv_cari)
        Me.Panel2.Controls.Add(Me.dgv_listfak)
        Me.Panel2.Controls.Add(Me.date_cari)
        Me.Panel2.Controls.Add(Me.date_tglawal)
        Me.Panel2.Controls.Add(Me.date_tglakhir)
        Me.Panel2.Controls.Add(Me.bt_list_delfak)
        Me.Panel2.Controls.Add(Me.bt_list_addfak)
        Me.Panel2.Controls.Add(Me.lbl_list_countfaktur)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.ck_range)
        Me.Panel2.Controls.Add(Me.ck_list)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(909, 412)
        Me.Panel2.TabIndex = 5
        '
        'bt_cari
        '
        Me.bt_cari.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bt_cari.Enabled = False
        Me.bt_cari.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cari.Image = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.bt_cari.Location = New System.Drawing.Point(791, 29)
        Me.bt_cari.Name = "bt_cari"
        Me.bt_cari.Size = New System.Drawing.Size(42, 22)
        Me.bt_cari.TabIndex = 60
        Me.bt_cari.UseVisualStyleBackColor = False
        '
        'in_cari
        '
        Me.in_cari.Enabled = False
        Me.in_cari.Location = New System.Drawing.Point(532, 29)
        Me.in_cari.Name = "in_cari"
        Me.in_cari.Size = New System.Drawing.Size(259, 22)
        Me.in_cari.TabIndex = 59
        '
        'dgv_cari
        '
        Me.dgv_cari.AllowUserToAddRows = False
        Me.dgv_cari.AllowUserToDeleteRows = False
        Me.dgv_cari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_cari.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.view_kodefaktur, Me.view_tanggal, Me.view_custo, Me.view_nopajak})
        Me.dgv_cari.Enabled = False
        Me.dgv_cari.Location = New System.Drawing.Point(445, 57)
        Me.dgv_cari.Name = "dgv_cari"
        Me.dgv_cari.ReadOnly = True
        Me.dgv_cari.RowHeadersVisible = False
        Me.dgv_cari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_cari.Size = New System.Drawing.Size(452, 233)
        Me.dgv_cari.StandardTab = True
        Me.dgv_cari.TabIndex = 58
        '
        'view_kodefaktur
        '
        Me.view_kodefaktur.DataPropertyName = "faktur_kode"
        Me.view_kodefaktur.HeaderText = "Kode Faktur"
        Me.view_kodefaktur.Name = "view_kodefaktur"
        Me.view_kodefaktur.ReadOnly = True
        Me.view_kodefaktur.Width = 125
        '
        'view_tanggal
        '
        Me.view_tanggal.DataPropertyName = "faktur_tanggal_trans"
        Me.view_tanggal.HeaderText = "Tanggal Jual."
        Me.view_tanggal.Name = "view_tanggal"
        Me.view_tanggal.ReadOnly = True
        '
        'view_custo
        '
        Me.view_custo.DataPropertyName = "faktur_custo"
        Me.view_custo.HeaderText = "Customer"
        Me.view_custo.Name = "view_custo"
        Me.view_custo.ReadOnly = True
        Me.view_custo.Width = 175
        '
        'view_nopajak
        '
        Me.view_nopajak.DataPropertyName = "faktur_pajak_no"
        Me.view_nopajak.HeaderText = "No.Pajak"
        Me.view_nopajak.Name = "view_nopajak"
        Me.view_nopajak.ReadOnly = True
        Me.view_nopajak.Width = 150
        '
        'dgv_listfak
        '
        Me.dgv_listfak.AllowUserToAddRows = False
        Me.dgv_listfak.AllowUserToDeleteRows = False
        Me.dgv_listfak.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listfak.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.add_kodefaktur, Me.add_tglfaktur, Me.add_custo})
        Me.dgv_listfak.Enabled = False
        Me.dgv_listfak.Location = New System.Drawing.Point(36, 29)
        Me.dgv_listfak.Name = "dgv_listfak"
        Me.dgv_listfak.ReadOnly = True
        Me.dgv_listfak.RowHeadersVisible = False
        Me.dgv_listfak.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listfak.Size = New System.Drawing.Size(383, 261)
        Me.dgv_listfak.StandardTab = True
        Me.dgv_listfak.TabIndex = 1
        '
        'add_kodefaktur
        '
        Me.add_kodefaktur.HeaderText = "Kode Faktur"
        Me.add_kodefaktur.Name = "add_kodefaktur"
        Me.add_kodefaktur.ReadOnly = True
        Me.add_kodefaktur.Width = 125
        '
        'add_tglfaktur
        '
        Me.add_tglfaktur.HeaderText = "Tanggal"
        Me.add_tglfaktur.Name = "add_tglfaktur"
        Me.add_tglfaktur.ReadOnly = True
        '
        'add_custo
        '
        Me.add_custo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.add_custo.HeaderText = "Customer"
        Me.add_custo.Name = "add_custo"
        Me.add_custo.ReadOnly = True
        '
        'date_cari
        '
        Me.date_cari.Enabled = False
        Me.date_cari.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date_cari.Location = New System.Drawing.Point(445, 29)
        Me.date_cari.Name = "date_cari"
        Me.date_cari.Size = New System.Drawing.Size(81, 22)
        Me.date_cari.TabIndex = 5
        '
        'date_tglawal
        '
        Me.date_tglawal.Enabled = False
        Me.date_tglawal.Location = New System.Drawing.Point(132, 354)
        Me.date_tglawal.Name = "date_tglawal"
        Me.date_tglawal.Size = New System.Drawing.Size(136, 22)
        Me.date_tglawal.TabIndex = 5
        '
        'date_tglakhir
        '
        Me.date_tglakhir.Enabled = False
        Me.date_tglakhir.Location = New System.Drawing.Point(303, 354)
        Me.date_tglakhir.Name = "date_tglakhir"
        Me.date_tglakhir.Size = New System.Drawing.Size(136, 22)
        Me.date_tglakhir.TabIndex = 6
        '
        'bt_list_delfak
        '
        Me.bt_list_delfak.Enabled = False
        Me.bt_list_delfak.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_list_delfak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_list_delfak.Image = Global.Inventory.My.Resources.Resources.Delete_16x16
        Me.bt_list_delfak.Location = New System.Drawing.Point(294, 296)
        Me.bt_list_delfak.Name = "bt_list_delfak"
        Me.bt_list_delfak.Size = New System.Drawing.Size(125, 30)
        Me.bt_list_delfak.TabIndex = 3
        Me.bt_list_delfak.Text = "Hapus Faktur"
        Me.bt_list_delfak.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_list_delfak.UseVisualStyleBackColor = True
        '
        'bt_list_addfak
        '
        Me.bt_list_addfak.Enabled = False
        Me.bt_list_addfak.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_list_addfak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_list_addfak.Image = Global.Inventory.My.Resources.Resources.Add_16x16
        Me.bt_list_addfak.Location = New System.Drawing.Point(755, 296)
        Me.bt_list_addfak.Name = "bt_list_addfak"
        Me.bt_list_addfak.Size = New System.Drawing.Size(142, 30)
        Me.bt_list_addfak.TabIndex = 2
        Me.bt_list_addfak.Text = "Tambah Faktur"
        Me.bt_list_addfak.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_list_addfak.UseVisualStyleBackColor = True
        '
        'lbl_list_countfaktur
        '
        Me.lbl_list_countfaktur.AutoSize = True
        Me.lbl_list_countfaktur.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_list_countfaktur.ForeColor = System.Drawing.Color.Black
        Me.lbl_list_countfaktur.Location = New System.Drawing.Point(33, 305)
        Me.lbl_list_countfaktur.Name = "lbl_list_countfaktur"
        Me.lbl_list_countfaktur.Size = New System.Drawing.Size(23, 15)
        Me.lbl_list_countfaktur.TabIndex = 57
        Me.lbl_list_countfaktur.Text = "S.d"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(274, 358)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 15)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "S.d"
        '
        'ck_range
        '
        Me.ck_range.AutoSize = True
        Me.ck_range.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_range.Location = New System.Drawing.Point(9, 356)
        Me.ck_range.Name = "ck_range"
        Me.ck_range.Size = New System.Drawing.Size(117, 19)
        Me.ck_range.TabIndex = 4
        Me.ck_range.Text = "Tanggal Transaksi"
        Me.ck_range.UseVisualStyleBackColor = True
        '
        'ck_list
        '
        Me.ck_list.AutoSize = True
        Me.ck_list.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_list.Location = New System.Drawing.Point(9, 6)
        Me.ck_list.Name = "ck_list"
        Me.ck_list.Size = New System.Drawing.Size(89, 19)
        Me.ck_list.TabIndex = 0
        Me.ck_list.Text = "Kode Faktur"
        Me.ck_list.UseVisualStyleBackColor = True
        '
        'bt_cancel
        '
        Me.bt_cancel.BackColor = System.Drawing.Color.White
        Me.bt_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cancel.Image = Global.Inventory.My.Resources.Resources.Delete_16x16
        Me.bt_cancel.Location = New System.Drawing.Point(810, 7)
        Me.bt_cancel.Name = "bt_cancel"
        Me.bt_cancel.Size = New System.Drawing.Size(87, 30)
        Me.bt_cancel.TabIndex = 8
        Me.bt_cancel.Text = "Batal"
        Me.bt_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_cancel.UseVisualStyleBackColor = False
        '
        'bt_load
        '
        Me.bt_load.BackColor = System.Drawing.Color.White
        Me.bt_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_load.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_load.Image = Global.Inventory.My.Resources.Resources.Add_16x16
        Me.bt_load.Location = New System.Drawing.Point(693, 8)
        Me.bt_load.Name = "bt_load"
        Me.bt_load.Size = New System.Drawing.Size(111, 30)
        Me.bt_load.TabIndex = 7
        Me.bt_load.Text = "Tampilkan"
        Me.bt_load.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_load.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.lbl_title)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(909, 34)
        Me.Panel1.TabIndex = 4
        '
        'bt_cl
        '
        Me.bt_cl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_cl.BackColor = System.Drawing.Color.Transparent
        Me.bt_cl.BackgroundImage = Global.Inventory.My.Resources.Resources.close
        Me.bt_cl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_cl.FlatAppearance.BorderSize = 0
        Me.bt_cl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange
        Me.bt_cl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange
        Me.bt_cl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cl.Location = New System.Drawing.Point(883, 6)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
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
        Me.lbl_title.Location = New System.Drawing.Point(5, 6)
        Me.lbl_title.MaximumSize = New System.Drawing.Size(490, 33)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(134, 22)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Tambah Faktur"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel3.Controls.Add(Me.bt_cancel)
        Me.Panel3.Controls.Add(Me.bt_load)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 446)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(909, 46)
        Me.Panel3.TabIndex = 6
        '
        'fr_exportaddfaktur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(909, 492)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_exportaddfaktur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgv_cari, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_listfak, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents bt_cancel As System.Windows.Forms.Button
    Friend WithEvents bt_load As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents dgv_listfak As System.Windows.Forms.DataGridView
    Friend WithEvents date_tglawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_tglakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents bt_list_delfak As System.Windows.Forms.Button
    Friend WithEvents bt_list_addfak As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ck_range As System.Windows.Forms.CheckBox
    Friend WithEvents ck_list As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_list_countfaktur As System.Windows.Forms.Label
    Friend WithEvents add_kodefaktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents add_tglfaktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents add_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bt_cari As System.Windows.Forms.Button
    Friend WithEvents in_cari As System.Windows.Forms.TextBox
    Friend WithEvents dgv_cari As System.Windows.Forms.DataGridView
    Friend WithEvents date_cari As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents view_kodefaktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents view_tanggal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents view_custo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents view_nopajak As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
