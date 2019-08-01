<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_importjual
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.ck_faktur_all = New System.Windows.Forms.CheckBox()
        Me.bt_openfile = New System.Windows.Forms.Button()
        Me.bt_import = New System.Windows.Forms.Button()
        Me.dgv_ckImport = New System.Windows.Forms.DataGridView()
        Me.import_ck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cb_dataselect = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_ckImport, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(842, 42)
        Me.Panel1.TabIndex = 418
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(752, 10)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(52, 22)
        Me.lbl_close.TabIndex = 138
        Me.lbl_close.Text = "Close"
        Me.lbl_close.Visible = False
        '
        'bt_cl
        '
        Me.bt_cl.BackColor = System.Drawing.Color.Transparent
        Me.bt_cl.BackgroundImage = Global.Inventory.My.Resources.Resources.close
        Me.bt_cl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_cl.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_cl.FlatAppearance.BorderSize = 0
        Me.bt_cl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange
        Me.bt_cl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange
        Me.bt_cl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cl.Location = New System.Drawing.Point(810, 11)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 137
        Me.bt_cl.TabStop = False
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Orange
        Me.lbl_title.Font = New System.Drawing.Font("Open Sans", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(5, 3)
        Me.lbl_title.MaximumSize = New System.Drawing.Size(490, 33)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(160, 33)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Import Data"
        '
        'ck_faktur_all
        '
        Me.ck_faktur_all.AutoSize = True
        Me.ck_faktur_all.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_faktur_all.Location = New System.Drawing.Point(12, 60)
        Me.ck_faktur_all.Name = "ck_faktur_all"
        Me.ck_faktur_all.Size = New System.Drawing.Size(114, 19)
        Me.ck_faktur_all.TabIndex = 414
        Me.ck_faktur_all.Text = "Pilih Semua Data"
        Me.ck_faktur_all.UseVisualStyleBackColor = True
        '
        'bt_openfile
        '
        Me.bt_openfile.BackColor = System.Drawing.Color.Gold
        Me.bt_openfile.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bt_openfile.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_openfile.Location = New System.Drawing.Point(691, 48)
        Me.bt_openfile.Name = "bt_openfile"
        Me.bt_openfile.Size = New System.Drawing.Size(147, 31)
        Me.bt_openfile.TabIndex = 417
        Me.bt_openfile.Text = "Pilih File (.xlsx)"
        Me.bt_openfile.UseVisualStyleBackColor = False
        '
        'bt_import
        '
        Me.bt_import.Location = New System.Drawing.Point(691, 462)
        Me.bt_import.Name = "bt_import"
        Me.bt_import.Size = New System.Drawing.Size(147, 33)
        Me.bt_import.TabIndex = 416
        Me.bt_import.Text = "Import"
        Me.bt_import.UseVisualStyleBackColor = True
        '
        'dgv_ckImport
        '
        Me.dgv_ckImport.AllowUserToAddRows = False
        Me.dgv_ckImport.AllowUserToDeleteRows = False
        Me.dgv_ckImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ckImport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.import_ck})
        Me.dgv_ckImport.Location = New System.Drawing.Point(12, 85)
        Me.dgv_ckImport.MultiSelect = False
        Me.dgv_ckImport.Name = "dgv_ckImport"
        Me.dgv_ckImport.RowHeadersVisible = False
        Me.dgv_ckImport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ckImport.Size = New System.Drawing.Size(826, 371)
        Me.dgv_ckImport.TabIndex = 415
        '
        'import_ck
        '
        Me.import_ck.FalseValue = "0"
        Me.import_ck.HeaderText = "Pilih"
        Me.import_ck.Name = "import_ck"
        Me.import_ck.TrueValue = "1"
        Me.import_ck.Width = 50
        '
        'cb_dataselect
        '
        Me.cb_dataselect.FormattingEnabled = True
        Me.cb_dataselect.Location = New System.Drawing.Point(448, 468)
        Me.cb_dataselect.Name = "cb_dataselect"
        Me.cb_dataselect.Size = New System.Drawing.Size(237, 23)
        Me.cb_dataselect.TabIndex = 419
        '
        'fr_importjual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(842, 500)
        Me.Controls.Add(Me.cb_dataselect)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ck_faktur_all)
        Me.Controls.Add(Me.bt_openfile)
        Me.Controls.Add(Me.bt_import)
        Me.Controls.Add(Me.dgv_ckImport)
        Me.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fr_importjual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fr_importjual"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv_ckImport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents ck_faktur_all As System.Windows.Forms.CheckBox
    Friend WithEvents bt_openfile As System.Windows.Forms.Button
    Friend WithEvents bt_import As System.Windows.Forms.Button
    Friend WithEvents dgv_ckImport As System.Windows.Forms.DataGridView
    Friend WithEvents import_ck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cb_dataselect As System.Windows.Forms.ComboBox
End Class
