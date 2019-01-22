<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_import_data
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_import_data))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.lkLbl_template = New System.Windows.Forms.LinkLabel()
        Me.cb_dataselect = New System.Windows.Forms.ComboBox()
        Me.ck_faktur_all = New System.Windows.Forms.CheckBox()
        Me.bt_openfile = New System.Windows.Forms.Button()
        Me.bt_import = New System.Windows.Forms.Button()
        Me.dgv_ckImport = New System.Windows.Forms.DataGridView()
        Me.import_ck = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.pnl_content.SuspendLayout()
        CType(Me.dgv_ckImport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 537)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(910, 10)
        Me.Panel3.TabIndex = 414
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
        Me.Panel1.Size = New System.Drawing.Size(910, 42)
        Me.Panel1.TabIndex = 413
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(820, 10)
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
        Me.bt_cl.Location = New System.Drawing.Point(878, 11)
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
        'pnl_content
        '
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.Controls.Add(Me.lkLbl_template)
        Me.pnl_content.Controls.Add(Me.cb_dataselect)
        Me.pnl_content.Controls.Add(Me.ck_faktur_all)
        Me.pnl_content.Controls.Add(Me.bt_openfile)
        Me.pnl_content.Controls.Add(Me.bt_import)
        Me.pnl_content.Controls.Add(Me.dgv_ckImport)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_content.Location = New System.Drawing.Point(0, 42)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(910, 495)
        Me.pnl_content.TabIndex = 0
        '
        'lkLbl_template
        '
        Me.lkLbl_template.AutoSize = True
        Me.lkLbl_template.Location = New System.Drawing.Point(8, 465)
        Me.lkLbl_template.Name = "lkLbl_template"
        Me.lkLbl_template.Size = New System.Drawing.Size(153, 15)
        Me.lkLbl_template.TabIndex = 4
        Me.lkLbl_template.TabStop = True
        Me.lkLbl_template.Text = "Buat Template Import Data.."
        '
        'cb_dataselect
        '
        Me.cb_dataselect.FormattingEnabled = True
        Me.cb_dataselect.Location = New System.Drawing.Point(508, 11)
        Me.cb_dataselect.Name = "cb_dataselect"
        Me.cb_dataselect.Size = New System.Drawing.Size(237, 23)
        Me.cb_dataselect.TabIndex = 3
        '
        'ck_faktur_all
        '
        Me.ck_faktur_all.AutoSize = True
        Me.ck_faktur_all.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_faktur_all.Location = New System.Drawing.Point(12, 18)
        Me.ck_faktur_all.Name = "ck_faktur_all"
        Me.ck_faktur_all.Size = New System.Drawing.Size(114, 19)
        Me.ck_faktur_all.TabIndex = 0
        Me.ck_faktur_all.Text = "Pilih Semua Data"
        Me.ck_faktur_all.UseVisualStyleBackColor = True
        '
        'bt_openfile
        '
        Me.bt_openfile.Location = New System.Drawing.Point(751, 6)
        Me.bt_openfile.Name = "bt_openfile"
        Me.bt_openfile.Size = New System.Drawing.Size(147, 31)
        Me.bt_openfile.TabIndex = 2
        Me.bt_openfile.Text = "Import File (.xlsx)"
        Me.bt_openfile.UseVisualStyleBackColor = True
        '
        'bt_import
        '
        Me.bt_import.Location = New System.Drawing.Point(751, 456)
        Me.bt_import.Name = "bt_import"
        Me.bt_import.Size = New System.Drawing.Size(147, 33)
        Me.bt_import.TabIndex = 1
        Me.bt_import.Text = "Import"
        Me.bt_import.UseVisualStyleBackColor = True
        '
        'dgv_ckImport
        '
        Me.dgv_ckImport.AllowUserToAddRows = False
        Me.dgv_ckImport.AllowUserToDeleteRows = False
        Me.dgv_ckImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ckImport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.import_ck})
        Me.dgv_ckImport.Location = New System.Drawing.Point(11, 43)
        Me.dgv_ckImport.MultiSelect = False
        Me.dgv_ckImport.Name = "dgv_ckImport"
        Me.dgv_ckImport.RowHeadersVisible = False
        Me.dgv_ckImport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ckImport.Size = New System.Drawing.Size(887, 407)
        Me.dgv_ckImport.TabIndex = 0
        '
        'import_ck
        '
        Me.import_ck.FalseValue = "0"
        Me.import_ck.HeaderText = "Pilih"
        Me.import_ck.Name = "import_ck"
        Me.import_ck.TrueValue = "1"
        Me.import_ck.Width = 50
        '
        'fr_import_data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(910, 547)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "fr_import_data"
        Me.Text = "Import Data"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        CType(Me.dgv_ckImport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents bt_openfile As System.Windows.Forms.Button
    Friend WithEvents bt_import As System.Windows.Forms.Button
    Friend WithEvents dgv_ckImport As System.Windows.Forms.DataGridView
    Friend WithEvents ck_faktur_all As System.Windows.Forms.CheckBox
    Friend WithEvents cb_dataselect As System.Windows.Forms.ComboBox
    Friend WithEvents import_ck As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents lkLbl_template As System.Windows.Forms.LinkLabel
End Class
