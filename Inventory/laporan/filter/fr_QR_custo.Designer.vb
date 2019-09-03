<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_QR_custo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_QR_custo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.rb_range = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.bt_print = New System.Windows.Forms.Button()
        Me.bt_close = New System.Windows.Forms.Button()
        Me.gb_selected = New System.Windows.Forms.GroupBox()
        Me.bt_remvcode = New System.Windows.Forms.Button()
        Me.bt_addcode = New System.Windows.Forms.Button()
        Me.bt_search = New System.Windows.Forms.Button()
        Me.dgv_selectedcode = New System.Windows.Forms.DataGridView()
        Me.select_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.select_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.in_search = New System.Windows.Forms.TextBox()
        Me.dgv_viewcode = New System.Windows.Forms.DataGridView()
        Me.view_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.view_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gb_range = New System.Windows.Forms.GroupBox()
        Me.in_kodeakhir = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_kodeawal = New System.Windows.Forms.TextBox()
        Me.rb_selected = New System.Windows.Forms.RadioButton()
        Me.rb_allcode = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.pnl_content.SuspendLayout()
        Me.gb_selected.SuspendLayout()
        CType(Me.dgv_selectedcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_viewcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_range.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(605, 42)
        Me.Panel1.TabIndex = 1
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(515, 8)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(52, 22)
        Me.lbl_close.TabIndex = 0
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
        Me.bt_cl.Location = New System.Drawing.Point(573, 9)
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
        Me.lbl_title.Font = New System.Drawing.Font("Open Sans", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(5, 3)
        Me.lbl_title.MaximumSize = New System.Drawing.Size(490, 33)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(189, 33)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Cetak QR Code"
        '
        'pnl_content
        '
        Me.pnl_content.AutoScroll = True
        Me.pnl_content.Controls.Add(Me.rb_range)
        Me.pnl_content.Controls.Add(Me.Panel3)
        Me.pnl_content.Controls.Add(Me.bt_print)
        Me.pnl_content.Controls.Add(Me.bt_close)
        Me.pnl_content.Controls.Add(Me.gb_selected)
        Me.pnl_content.Controls.Add(Me.gb_range)
        Me.pnl_content.Controls.Add(Me.rb_selected)
        Me.pnl_content.Controls.Add(Me.rb_allcode)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Location = New System.Drawing.Point(0, 42)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(605, 448)
        Me.pnl_content.TabIndex = 2
        '
        'rb_range
        '
        Me.rb_range.AutoSize = True
        Me.rb_range.Location = New System.Drawing.Point(11, 43)
        Me.rb_range.Name = "rb_range"
        Me.rb_range.Size = New System.Drawing.Size(14, 13)
        Me.rb_range.TabIndex = 1
        Me.rb_range.TabStop = True
        Me.rb_range.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 438)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(605, 10)
        Me.Panel3.TabIndex = 15
        '
        'bt_print
        '
        Me.bt_print.FlatAppearance.BorderSize = 0
        Me.bt_print.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_print.Location = New System.Drawing.Point(347, 394)
        Me.bt_print.Name = "bt_print"
        Me.bt_print.Size = New System.Drawing.Size(120, 33)
        Me.bt_print.TabIndex = 14
        Me.bt_print.Text = "Preview"
        Me.bt_print.UseVisualStyleBackColor = True
        '
        'bt_close
        '
        Me.bt_close.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_close.FlatAppearance.BorderSize = 0
        Me.bt_close.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_close.Location = New System.Drawing.Point(473, 394)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(120, 33)
        Me.bt_close.TabIndex = 13
        Me.bt_close.Text = "Close"
        Me.bt_close.UseVisualStyleBackColor = True
        '
        'gb_selected
        '
        Me.gb_selected.Controls.Add(Me.bt_remvcode)
        Me.gb_selected.Controls.Add(Me.bt_addcode)
        Me.gb_selected.Controls.Add(Me.bt_search)
        Me.gb_selected.Controls.Add(Me.dgv_selectedcode)
        Me.gb_selected.Controls.Add(Me.in_search)
        Me.gb_selected.Controls.Add(Me.dgv_viewcode)
        Me.gb_selected.Enabled = False
        Me.gb_selected.Location = New System.Drawing.Point(31, 128)
        Me.gb_selected.Name = "gb_selected"
        Me.gb_selected.Size = New System.Drawing.Size(562, 260)
        Me.gb_selected.TabIndex = 4
        Me.gb_selected.TabStop = False
        Me.gb_selected.Text = "Select"
        '
        'bt_remvcode
        '
        Me.bt_remvcode.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_remvcode.Location = New System.Drawing.Point(283, 154)
        Me.bt_remvcode.Name = "bt_remvcode"
        Me.bt_remvcode.Size = New System.Drawing.Size(30, 75)
        Me.bt_remvcode.TabIndex = 12
        Me.bt_remvcode.Text = "-"
        Me.bt_remvcode.UseVisualStyleBackColor = True
        '
        'bt_addcode
        '
        Me.bt_addcode.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_addcode.Location = New System.Drawing.Point(283, 73)
        Me.bt_addcode.Name = "bt_addcode"
        Me.bt_addcode.Size = New System.Drawing.Size(30, 75)
        Me.bt_addcode.TabIndex = 11
        Me.bt_addcode.Text = "+"
        Me.bt_addcode.UseVisualStyleBackColor = True
        '
        'bt_search
        '
        Me.bt_search.Image = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.bt_search.Location = New System.Drawing.Point(226, 20)
        Me.bt_search.Name = "bt_search"
        Me.bt_search.Size = New System.Drawing.Size(55, 24)
        Me.bt_search.TabIndex = 10
        Me.bt_search.Text = "Cari"
        Me.bt_search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_search.UseVisualStyleBackColor = True
        '
        'dgv_selectedcode
        '
        Me.dgv_selectedcode.AllowUserToAddRows = False
        Me.dgv_selectedcode.AllowUserToDeleteRows = False
        Me.dgv_selectedcode.BackgroundColor = System.Drawing.Color.White
        Me.dgv_selectedcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_selectedcode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.select_kode, Me.select_nama})
        Me.dgv_selectedcode.Location = New System.Drawing.Point(314, 49)
        Me.dgv_selectedcode.Name = "dgv_selectedcode"
        Me.dgv_selectedcode.ReadOnly = True
        Me.dgv_selectedcode.RowHeadersVisible = False
        Me.dgv_selectedcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_selectedcode.Size = New System.Drawing.Size(242, 205)
        Me.dgv_selectedcode.TabIndex = 9
        '
        'select_kode
        '
        Me.select_kode.HeaderText = "Kode"
        Me.select_kode.Name = "select_kode"
        Me.select_kode.ReadOnly = True
        Me.select_kode.Width = 175
        '
        'select_nama
        '
        Me.select_nama.HeaderText = "Nama"
        Me.select_nama.Name = "select_nama"
        Me.select_nama.ReadOnly = True
        '
        'in_search
        '
        Me.in_search.Location = New System.Drawing.Point(6, 21)
        Me.in_search.Name = "in_search"
        Me.in_search.Size = New System.Drawing.Size(214, 22)
        Me.in_search.TabIndex = 8
        '
        'dgv_viewcode
        '
        Me.dgv_viewcode.AllowUserToAddRows = False
        Me.dgv_viewcode.AllowUserToDeleteRows = False
        Me.dgv_viewcode.BackgroundColor = System.Drawing.Color.White
        Me.dgv_viewcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_viewcode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.view_kode, Me.view_nama})
        Me.dgv_viewcode.Location = New System.Drawing.Point(6, 49)
        Me.dgv_viewcode.Name = "dgv_viewcode"
        Me.dgv_viewcode.ReadOnly = True
        Me.dgv_viewcode.RowHeadersVisible = False
        Me.dgv_viewcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_viewcode.Size = New System.Drawing.Size(275, 205)
        Me.dgv_viewcode.TabIndex = 0
        '
        'view_kode
        '
        Me.view_kode.DataPropertyName = "kode"
        Me.view_kode.HeaderText = "Kode"
        Me.view_kode.Name = "view_kode"
        Me.view_kode.ReadOnly = True
        '
        'view_nama
        '
        Me.view_nama.DataPropertyName = "nama"
        Me.view_nama.HeaderText = "Nama"
        Me.view_nama.MinimumWidth = 30
        Me.view_nama.Name = "view_nama"
        Me.view_nama.ReadOnly = True
        Me.view_nama.Width = 250
        '
        'gb_range
        '
        Me.gb_range.Controls.Add(Me.in_kodeakhir)
        Me.gb_range.Controls.Add(Me.Label2)
        Me.gb_range.Controls.Add(Me.Label1)
        Me.gb_range.Controls.Add(Me.in_kodeawal)
        Me.gb_range.Enabled = False
        Me.gb_range.Location = New System.Drawing.Point(31, 41)
        Me.gb_range.Name = "gb_range"
        Me.gb_range.Size = New System.Drawing.Size(562, 81)
        Me.gb_range.TabIndex = 3
        Me.gb_range.TabStop = False
        Me.gb_range.Text = "Range"
        '
        'in_kodeakhir
        '
        Me.in_kodeakhir.Location = New System.Drawing.Point(287, 21)
        Me.in_kodeakhir.Name = "in_kodeakhir"
        Me.in_kodeakhir.Size = New System.Drawing.Size(225, 22)
        Me.in_kodeakhir.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(289, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "*Work with data which has system generated ID/Code."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(237, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "sampai"
        '
        'in_kodeawal
        '
        Me.in_kodeawal.Location = New System.Drawing.Point(6, 21)
        Me.in_kodeawal.Name = "in_kodeawal"
        Me.in_kodeawal.Size = New System.Drawing.Size(225, 22)
        Me.in_kodeawal.TabIndex = 7
        '
        'rb_selected
        '
        Me.rb_selected.AutoSize = True
        Me.rb_selected.Location = New System.Drawing.Point(11, 132)
        Me.rb_selected.Name = "rb_selected"
        Me.rb_selected.Size = New System.Drawing.Size(14, 13)
        Me.rb_selected.TabIndex = 2
        Me.rb_selected.TabStop = True
        Me.rb_selected.UseVisualStyleBackColor = True
        '
        'rb_allcode
        '
        Me.rb_allcode.AutoSize = True
        Me.rb_allcode.Location = New System.Drawing.Point(11, 16)
        Me.rb_allcode.Name = "rb_allcode"
        Me.rb_allcode.Size = New System.Drawing.Size(113, 19)
        Me.rb_allcode.TabIndex = 0
        Me.rb_allcode.TabStop = True
        Me.rb_allcode.Text = "Semua Customer"
        Me.rb_allcode.UseVisualStyleBackColor = True
        '
        'fr_QR_custo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.bt_close
        Me.ClientSize = New System.Drawing.Size(605, 490)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fr_QR_custo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cetak QR Code"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.gb_selected.ResumeLayout(False)
        Me.gb_selected.PerformLayout()
        CType(Me.dgv_selectedcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_viewcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_range.ResumeLayout(False)
        Me.gb_range.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents bt_print As System.Windows.Forms.Button
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents gb_selected As System.Windows.Forms.GroupBox
    Friend WithEvents bt_remvcode As System.Windows.Forms.Button
    Friend WithEvents bt_addcode As System.Windows.Forms.Button
    Friend WithEvents bt_search As System.Windows.Forms.Button
    Friend WithEvents dgv_selectedcode As System.Windows.Forms.DataGridView
    Friend WithEvents in_search As System.Windows.Forms.TextBox
    Friend WithEvents dgv_viewcode As System.Windows.Forms.DataGridView
    Friend WithEvents gb_range As System.Windows.Forms.GroupBox
    Friend WithEvents in_kodeakhir As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_kodeawal As System.Windows.Forms.TextBox
    Friend WithEvents rb_selected As System.Windows.Forms.RadioButton
    Friend WithEvents rb_range As System.Windows.Forms.RadioButton
    Friend WithEvents rb_allcode As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents select_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents select_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents view_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents view_nama As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
