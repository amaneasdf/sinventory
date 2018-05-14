<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_user_list
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.bt_closebarang = New System.Windows.Forms.Button()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bt_edit_user = New System.Windows.Forms.Button()
        Me.in_cari_user = New System.Windows.Forms.TextBox()
        Me.bt_refreshbarang = New System.Windows.Forms.Button()
        Me.bt_tambah_user = New System.Windows.Forms.Button()
        Me.bt_hapusbarang = New System.Windows.Forms.Button()
        Me.dgv_user = New System.Windows.Forms.DataGridView()
        Me.kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.user_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.user_nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.group_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.groupnama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statuslogin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.dgv_user, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(950, 568)
        Me.SplitContainer1.SplitterDistance = 40
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 24)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Daftar User"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.bt_closebarang)
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(950, 527)
        Me.SplitContainer2.SplitterDistance = 494
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 2
        '
        'bt_closebarang
        '
        Me.bt_closebarang.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_closebarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_closebarang.Location = New System.Drawing.Point(851, 5)
        Me.bt_closebarang.Name = "bt_closebarang"
        Me.bt_closebarang.Size = New System.Drawing.Size(96, 30)
        Me.bt_closebarang.TabIndex = 1
        Me.bt_closebarang.Text = "Tutup"
        Me.bt_closebarang.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer3.Panel1.Controls.Add(Me.bt_edit_user)
        Me.SplitContainer3.Panel1.Controls.Add(Me.in_cari_user)
        Me.SplitContainer3.Panel1.Controls.Add(Me.bt_refreshbarang)
        Me.SplitContainer3.Panel1.Controls.Add(Me.bt_tambah_user)
        Me.SplitContainer3.Panel1.Controls.Add(Me.bt_hapusbarang)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.dgv_user)
        Me.SplitContainer3.Size = New System.Drawing.Size(950, 494)
        Me.SplitContainer3.SplitterDistance = 48
        Me.SplitContainer3.SplitterWidth = 10
        Me.SplitContainer3.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Pencarian :"
        '
        'bt_edit_user
        '
        Me.bt_edit_user.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_edit_user.Location = New System.Drawing.Point(441, 5)
        Me.bt_edit_user.Name = "bt_edit_user"
        Me.bt_edit_user.Size = New System.Drawing.Size(96, 30)
        Me.bt_edit_user.TabIndex = 2
        Me.bt_edit_user.Text = "Koreksi"
        Me.bt_edit_user.UseVisualStyleBackColor = True
        '
        'in_cari_user
        '
        Me.in_cari_user.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari_user.Location = New System.Drawing.Point(85, 10)
        Me.in_cari_user.Name = "in_cari_user"
        Me.in_cari_user.Size = New System.Drawing.Size(248, 22)
        Me.in_cari_user.TabIndex = 0
        '
        'bt_refreshbarang
        '
        Me.bt_refreshbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_refreshbarang.Location = New System.Drawing.Point(645, 5)
        Me.bt_refreshbarang.Name = "bt_refreshbarang"
        Me.bt_refreshbarang.Size = New System.Drawing.Size(96, 30)
        Me.bt_refreshbarang.TabIndex = 1
        Me.bt_refreshbarang.Text = "Refresh"
        Me.bt_refreshbarang.UseVisualStyleBackColor = True
        '
        'bt_tambah_user
        '
        Me.bt_tambah_user.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tambah_user.Location = New System.Drawing.Point(339, 5)
        Me.bt_tambah_user.Name = "bt_tambah_user"
        Me.bt_tambah_user.Size = New System.Drawing.Size(96, 30)
        Me.bt_tambah_user.TabIndex = 1
        Me.bt_tambah_user.Text = "Tambah"
        Me.bt_tambah_user.UseVisualStyleBackColor = True
        '
        'bt_hapusbarang
        '
        Me.bt_hapusbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_hapusbarang.Location = New System.Drawing.Point(543, 5)
        Me.bt_hapusbarang.Name = "bt_hapusbarang"
        Me.bt_hapusbarang.Size = New System.Drawing.Size(96, 30)
        Me.bt_hapusbarang.TabIndex = 1
        Me.bt_hapusbarang.Text = "Hapus"
        Me.bt_hapusbarang.UseVisualStyleBackColor = True
        '
        'dgv_user
        '
        Me.dgv_user.AllowUserToAddRows = False
        Me.dgv_user.AllowUserToDeleteRows = False
        Me.dgv_user.BackgroundColor = System.Drawing.Color.White
        Me.dgv_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_user.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kode, Me.user_id, Me.user_nama, Me.group_kode, Me.groupnama, Me.status, Me.statuslogin})
        Me.dgv_user.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_user.Location = New System.Drawing.Point(0, 0)
        Me.dgv_user.MultiSelect = False
        Me.dgv_user.Name = "dgv_user"
        Me.dgv_user.ReadOnly = True
        Me.dgv_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_user.Size = New System.Drawing.Size(950, 436)
        Me.dgv_user.TabIndex = 2
        '
        'kode
        '
        Me.kode.DataPropertyName = "kode"
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = "-"
        Me.kode.DefaultCellStyle = DataGridViewCellStyle1
        Me.kode.HeaderText = "Kode User"
        Me.kode.Name = "kode"
        Me.kode.ReadOnly = True
        '
        'user_id
        '
        Me.user_id.DataPropertyName = "userid"
        Me.user_id.HeaderText = "UserID"
        Me.user_id.Name = "user_id"
        Me.user_id.ReadOnly = True
        '
        'user_nama
        '
        Me.user_nama.DataPropertyName = "nama"
        Me.user_nama.HeaderText = "Nama"
        Me.user_nama.Name = "user_nama"
        Me.user_nama.ReadOnly = True
        '
        'group_kode
        '
        Me.group_kode.DataPropertyName = "groupkode"
        Me.group_kode.HeaderText = "Kode Group User"
        Me.group_kode.Name = "group_kode"
        Me.group_kode.ReadOnly = True
        Me.group_kode.Visible = False
        '
        'groupnama
        '
        Me.groupnama.DataPropertyName = "groupnama"
        Me.groupnama.HeaderText = "Group"
        Me.groupnama.Name = "groupnama"
        Me.groupnama.ReadOnly = True
        '
        'status
        '
        Me.status.DataPropertyName = "status"
        Me.status.HeaderText = "Status User"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        '
        'statuslogin
        '
        Me.statuslogin.DataPropertyName = "loginstat"
        Me.statuslogin.HeaderText = "Login"
        Me.statuslogin.Name = "statuslogin"
        Me.statuslogin.ReadOnly = True
        '
        'fr_user_list
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "fr_user_list"
        Me.Size = New System.Drawing.Size(950, 568)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.dgv_user, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents bt_closebarang As System.Windows.Forms.Button
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bt_edit_user As System.Windows.Forms.Button
    Friend WithEvents in_cari_user As System.Windows.Forms.TextBox
    Friend WithEvents bt_refreshbarang As System.Windows.Forms.Button
    Friend WithEvents bt_tambah_user As System.Windows.Forms.Button
    Friend WithEvents bt_hapusbarang As System.Windows.Forms.Button
    Friend WithEvents dgv_user As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents user_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents user_nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents group_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents groupnama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents statuslogin As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
