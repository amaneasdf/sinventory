<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_data_referensi
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_judul = New System.Windows.Forms.Label()
        Me.split_main = New System.Windows.Forms.SplitContainer()
        Me.bt_ref_kab = New System.Windows.Forms.Button()
        Me.bt_ref_areacusto = New System.Windows.Forms.Button()
        Me.bt_ref_satbrg = New System.Windows.Forms.Button()
        Me.bt_ref_katbrg = New System.Windows.Forms.Button()
        Me.dgv_list = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.bt_search = New System.Windows.Forms.Button()
        Me.in_cari = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mn_add = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_other = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_search = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_refresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.bt_ref_jeniscusto = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        CType(Me.split_main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.split_main.Panel1.SuspendLayout()
        Me.split_main.Panel2.SuspendLayout()
        Me.split_main.SuspendLayout()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Controls.Add(Me.lbl_close)
        Me.Panel2.Controls.Add(Me.bt_cl)
        Me.Panel2.Controls.Add(Me.lbl_judul)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(959, 48)
        Me.Panel2.TabIndex = 342
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(879, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(932, 10)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 23)
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
        Me.lbl_judul.Size = New System.Drawing.Size(303, 33)
        Me.lbl_judul.TabIndex = 136
        Me.lbl_judul.Text = "Set Kode/Data Referensi"
        '
        'split_main
        '
        Me.split_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.split_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.split_main.IsSplitterFixed = True
        Me.split_main.Location = New System.Drawing.Point(0, 48)
        Me.split_main.Name = "split_main"
        '
        'split_main.Panel1
        '
        Me.split_main.Panel1.Controls.Add(Me.bt_ref_jeniscusto)
        Me.split_main.Panel1.Controls.Add(Me.bt_ref_kab)
        Me.split_main.Panel1.Controls.Add(Me.bt_ref_areacusto)
        Me.split_main.Panel1.Controls.Add(Me.bt_ref_satbrg)
        Me.split_main.Panel1.Controls.Add(Me.bt_ref_katbrg)
        '
        'split_main.Panel2
        '
        Me.split_main.Panel2.Controls.Add(Me.dgv_list)
        Me.split_main.Panel2.Controls.Add(Me.Panel3)
        Me.split_main.Panel2.Controls.Add(Me.MenuStrip1)
        Me.split_main.Size = New System.Drawing.Size(959, 590)
        Me.split_main.SplitterDistance = 183
        Me.split_main.SplitterWidth = 2
        Me.split_main.TabIndex = 343
        '
        'bt_ref_kab
        '
        Me.bt_ref_kab.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_ref_kab.FlatAppearance.BorderSize = 0
        Me.bt_ref_kab.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_ref_kab.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_ref_kab.ForeColor = System.Drawing.Color.White
        Me.bt_ref_kab.Location = New System.Drawing.Point(0, 110)
        Me.bt_ref_kab.Name = "bt_ref_kab"
        Me.bt_ref_kab.Size = New System.Drawing.Size(182, 35)
        Me.bt_ref_kab.TabIndex = 0
        Me.bt_ref_kab.TabStop = False
        Me.bt_ref_kab.Text = "Kode Kabupaten"
        Me.bt_ref_kab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_ref_kab.UseVisualStyleBackColor = False
        '
        'bt_ref_areacusto
        '
        Me.bt_ref_areacusto.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_ref_areacusto.FlatAppearance.BorderSize = 0
        Me.bt_ref_areacusto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_ref_areacusto.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_ref_areacusto.ForeColor = System.Drawing.Color.White
        Me.bt_ref_areacusto.Location = New System.Drawing.Point(0, 74)
        Me.bt_ref_areacusto.Name = "bt_ref_areacusto"
        Me.bt_ref_areacusto.Size = New System.Drawing.Size(182, 35)
        Me.bt_ref_areacusto.TabIndex = 0
        Me.bt_ref_areacusto.TabStop = False
        Me.bt_ref_areacusto.Text = "Kode Area Customer"
        Me.bt_ref_areacusto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_ref_areacusto.UseVisualStyleBackColor = False
        '
        'bt_ref_satbrg
        '
        Me.bt_ref_satbrg.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_ref_satbrg.FlatAppearance.BorderSize = 0
        Me.bt_ref_satbrg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_ref_satbrg.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_ref_satbrg.ForeColor = System.Drawing.Color.White
        Me.bt_ref_satbrg.Location = New System.Drawing.Point(0, 38)
        Me.bt_ref_satbrg.Name = "bt_ref_satbrg"
        Me.bt_ref_satbrg.Size = New System.Drawing.Size(182, 35)
        Me.bt_ref_satbrg.TabIndex = 0
        Me.bt_ref_satbrg.TabStop = False
        Me.bt_ref_satbrg.Text = "Satuan Barang"
        Me.bt_ref_satbrg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_ref_satbrg.UseVisualStyleBackColor = False
        '
        'bt_ref_katbrg
        '
        Me.bt_ref_katbrg.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_ref_katbrg.FlatAppearance.BorderSize = 0
        Me.bt_ref_katbrg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_ref_katbrg.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_ref_katbrg.ForeColor = System.Drawing.Color.White
        Me.bt_ref_katbrg.Location = New System.Drawing.Point(0, 2)
        Me.bt_ref_katbrg.Name = "bt_ref_katbrg"
        Me.bt_ref_katbrg.Size = New System.Drawing.Size(182, 35)
        Me.bt_ref_katbrg.TabIndex = 0
        Me.bt_ref_katbrg.TabStop = False
        Me.bt_ref_katbrg.Text = "Kategori Barang"
        Me.bt_ref_katbrg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_ref_katbrg.UseVisualStyleBackColor = False
        '
        'dgv_list
        '
        Me.dgv_list.AllowUserToAddRows = False
        Me.dgv_list.AllowUserToDeleteRows = False
        Me.dgv_list.AllowUserToResizeRows = False
        Me.dgv_list.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_list.BackgroundColor = System.Drawing.Color.White
        Me.dgv_list.CausesValidation = False
        Me.dgv_list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_list.Location = New System.Drawing.Point(0, 61)
        Me.dgv_list.MultiSelect = False
        Me.dgv_list.Name = "dgv_list"
        Me.dgv_list.ReadOnly = True
        Me.dgv_list.RowHeadersVisible = False
        Me.dgv_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_list.Size = New System.Drawing.Size(774, 529)
        Me.dgv_list.TabIndex = 185
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.bt_search)
        Me.Panel3.Controls.Add(Me.in_cari)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(0, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(774, 37)
        Me.Panel3.TabIndex = 184
        '
        'bt_search
        '
        Me.bt_search.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bt_search.BackgroundImage = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.bt_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_search.Location = New System.Drawing.Point(256, 9)
        Me.bt_search.Name = "bt_search"
        Me.bt_search.Size = New System.Drawing.Size(42, 22)
        Me.bt_search.TabIndex = 3
        Me.bt_search.UseVisualStyleBackColor = False
        '
        'in_cari
        '
        Me.in_cari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari.Location = New System.Drawing.Point(9, 9)
        Me.in_cari.MaxLength = 100
        Me.in_cari.Name = "in_cari"
        Me.in_cari.Size = New System.Drawing.Size(248, 22)
        Me.in_cari.TabIndex = 2
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_add, Me.mn_edit, Me.mn_other, Me.mn_refresh})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(774, 24)
        Me.MenuStrip1.TabIndex = 186
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mn_add
        '
        Me.mn_add.Image = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.mn_add.Name = "mn_add"
        Me.mn_add.Size = New System.Drawing.Size(78, 20)
        Me.mn_add.Text = "Tambah"
        '
        'mn_edit
        '
        Me.mn_edit.Image = Global.Inventory.My.Resources.Resources.toolbar_list_icon1
        Me.mn_edit.Name = "mn_edit"
        Me.mn_edit.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.mn_edit.Size = New System.Drawing.Size(55, 20)
        Me.mn_edit.Text = "Edit"
        '
        'mn_other
        '
        Me.mn_other.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_search})
        Me.mn_other.Name = "mn_other"
        Me.mn_other.Size = New System.Drawing.Size(68, 20)
        Me.mn_other.Text = "Lain-Lain"
        '
        'mn_search
        '
        Me.mn_search.Name = "mn_search"
        Me.mn_search.Size = New System.Drawing.Size(95, 22)
        Me.mn_search.Text = "Cari"
        '
        'mn_refresh
        '
        Me.mn_refresh.Name = "mn_refresh"
        Me.mn_refresh.Size = New System.Drawing.Size(58, 20)
        Me.mn_refresh.Text = "Refresh"
        '
        'bt_ref_jeniscusto
        '
        Me.bt_ref_jeniscusto.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_ref_jeniscusto.FlatAppearance.BorderSize = 0
        Me.bt_ref_jeniscusto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_ref_jeniscusto.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_ref_jeniscusto.ForeColor = System.Drawing.Color.White
        Me.bt_ref_jeniscusto.Location = New System.Drawing.Point(0, 146)
        Me.bt_ref_jeniscusto.Name = "bt_ref_jeniscusto"
        Me.bt_ref_jeniscusto.Size = New System.Drawing.Size(182, 35)
        Me.bt_ref_jeniscusto.TabIndex = 0
        Me.bt_ref_jeniscusto.TabStop = False
        Me.bt_ref_jeniscusto.Text = "Jenis Customer"
        Me.bt_ref_jeniscusto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bt_ref_jeniscusto.UseVisualStyleBackColor = False
        '
        'fr_data_referensi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.split_main)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "fr_data_referensi"
        Me.Size = New System.Drawing.Size(959, 638)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.split_main.Panel1.ResumeLayout(False)
        Me.split_main.Panel2.ResumeLayout(False)
        Me.split_main.Panel2.PerformLayout()
        CType(Me.split_main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.split_main.ResumeLayout(False)
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_judul As System.Windows.Forms.Label
    Friend WithEvents split_main As System.Windows.Forms.SplitContainer
    Friend WithEvents bt_ref_satbrg As System.Windows.Forms.Button
    Friend WithEvents bt_ref_katbrg As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgv_list As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents bt_search As System.Windows.Forms.Button
    Friend WithEvents in_cari As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_add As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_other As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_search As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_refresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bt_ref_areacusto As System.Windows.Forms.Button
    Friend WithEvents bt_ref_kab As System.Windows.Forms.Button
    Friend WithEvents bt_ref_jeniscusto As System.Windows.Forms.Button

End Class
