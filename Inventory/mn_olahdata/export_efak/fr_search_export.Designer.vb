<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_search_export
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_search_export))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.bt_cancel = New System.Windows.Forms.Button()
        Me.bt_load = New System.Windows.Forms.Button()
        Me.dgv_listexport = New System.Windows.Forms.DataGridView()
        Me.bt_cari = New System.Windows.Forms.Button()
        Me.in_cari = New System.Windows.Forms.TextBox()
        Me.ex_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ex_periode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ex_tgl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ex_tglexport = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.pnl_content.SuspendLayout()
        CType(Me.dgv_listexport, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(362, 34)
        Me.Panel1.TabIndex = 1
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
        Me.bt_cl.Location = New System.Drawing.Point(336, 6)
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
        Me.lbl_title.Size = New System.Drawing.Size(167, 22)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "List Export E-Faktur"
        '
        'pnl_content
        '
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.Controls.Add(Me.bt_cancel)
        Me.pnl_content.Controls.Add(Me.bt_load)
        Me.pnl_content.Controls.Add(Me.dgv_listexport)
        Me.pnl_content.Controls.Add(Me.bt_cari)
        Me.pnl_content.Controls.Add(Me.in_cari)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Location = New System.Drawing.Point(0, 34)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(362, 479)
        Me.pnl_content.TabIndex = 0
        '
        'bt_cancel
        '
        Me.bt_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cancel.Image = Global.Inventory.My.Resources.Resources._1492932873_Delete
        Me.bt_cancel.Location = New System.Drawing.Point(263, 437)
        Me.bt_cancel.Name = "bt_cancel"
        Me.bt_cancel.Size = New System.Drawing.Size(87, 30)
        Me.bt_cancel.TabIndex = 4
        Me.bt_cancel.Text = "Batal"
        Me.bt_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_cancel.UseVisualStyleBackColor = True
        '
        'bt_load
        '
        Me.bt_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_load.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_load.Image = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.bt_load.Location = New System.Drawing.Point(146, 438)
        Me.bt_load.Name = "bt_load"
        Me.bt_load.Size = New System.Drawing.Size(111, 30)
        Me.bt_load.TabIndex = 3
        Me.bt_load.Text = "Tampilkan"
        Me.bt_load.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_load.UseVisualStyleBackColor = True
        '
        'dgv_listexport
        '
        Me.dgv_listexport.AllowUserToAddRows = False
        Me.dgv_listexport.AllowUserToDeleteRows = False
        Me.dgv_listexport.BackgroundColor = System.Drawing.Color.White
        Me.dgv_listexport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listexport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ex_id, Me.ex_periode, Me.ex_tgl, Me.ex_tglexport})
        Me.dgv_listexport.Location = New System.Drawing.Point(12, 34)
        Me.dgv_listexport.MultiSelect = False
        Me.dgv_listexport.Name = "dgv_listexport"
        Me.dgv_listexport.ReadOnly = True
        Me.dgv_listexport.RowHeadersVisible = False
        Me.dgv_listexport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listexport.Size = New System.Drawing.Size(338, 393)
        Me.dgv_listexport.TabIndex = 2
        '
        'bt_cari
        '
        Me.bt_cari.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cari.Location = New System.Drawing.Point(291, 6)
        Me.bt_cari.Name = "bt_cari"
        Me.bt_cari.Size = New System.Drawing.Size(59, 23)
        Me.bt_cari.TabIndex = 1
        Me.bt_cari.Text = "Cari"
        Me.bt_cari.UseVisualStyleBackColor = True
        '
        'in_cari
        '
        Me.in_cari.Location = New System.Drawing.Point(12, 6)
        Me.in_cari.Name = "in_cari"
        Me.in_cari.Size = New System.Drawing.Size(273, 22)
        Me.in_cari.TabIndex = 0
        '
        'ex_id
        '
        Me.ex_id.DataPropertyName = "efak_id"
        Me.ex_id.HeaderText = "ID"
        Me.ex_id.Name = "ex_id"
        Me.ex_id.ReadOnly = True
        Me.ex_id.Width = 50
        '
        'ex_periode
        '
        Me.ex_periode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ex_periode.DataPropertyName = "efak_periode"
        Me.ex_periode.HeaderText = "Periode"
        Me.ex_periode.Name = "ex_periode"
        Me.ex_periode.ReadOnly = True
        '
        'ex_tgl
        '
        Me.ex_tgl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ex_tgl.DataPropertyName = "efak_tgl"
        Me.ex_tgl.HeaderText = "Tanggal"
        Me.ex_tgl.Name = "ex_tgl"
        Me.ex_tgl.ReadOnly = True
        Me.ex_tgl.Width = 72
        '
        'ex_tglexport
        '
        Me.ex_tglexport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ex_tglexport.DataPropertyName = "efak_lastexport"
        Me.ex_tglexport.HeaderText = "Last Export"
        Me.ex_tglexport.Name = "ex_tglexport"
        Me.ex_tglexport.ReadOnly = True
        Me.ex_tglexport.Width = 90
        '
        'fr_search_export
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(362, 513)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "fr_search_export"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        CType(Me.dgv_listexport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents in_cari As System.Windows.Forms.TextBox
    Friend WithEvents dgv_listexport As System.Windows.Forms.DataGridView
    Friend WithEvents bt_cari As System.Windows.Forms.Button
    Friend WithEvents bt_cancel As System.Windows.Forms.Button
    Friend WithEvents bt_load As System.Windows.Forms.Button
    Friend WithEvents ex_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ex_periode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ex_tgl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ex_tglexport As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
