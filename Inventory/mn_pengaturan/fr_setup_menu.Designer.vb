<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_setup_menu
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
        Me.dgv_menu = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.parent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bt_keluar_menu = New System.Windows.Forms.Button()
        Me.bt_hapus_menu = New System.Windows.Forms.Button()
        Me.bt_tambah_menu = New System.Windows.Forms.Button()
        Me.in_menu_nama = New System.Windows.Forms.TextBox()
        Me.in_id = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_menu_kode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_menu_parent = New System.Windows.Forms.TextBox()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.bt_batal = New System.Windows.Forms.Button()
        Me.ck_enable = New System.Windows.Forms.CheckBox()
        CType(Me.dgv_menu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_menu
        '
        Me.dgv_menu.AllowUserToAddRows = False
        Me.dgv_menu.AllowUserToDeleteRows = False
        Me.dgv_menu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_menu.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.kode, Me.parent, Me.nama, Me.status})
        Me.dgv_menu.Location = New System.Drawing.Point(12, 186)
        Me.dgv_menu.MultiSelect = False
        Me.dgv_menu.Name = "dgv_menu"
        Me.dgv_menu.ReadOnly = True
        Me.dgv_menu.RowHeadersVisible = False
        Me.dgv_menu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_menu.Size = New System.Drawing.Size(708, 350)
        Me.dgv_menu.TabIndex = 6
        '
        'id
        '
        Me.id.DataPropertyName = "menu_id"
        Me.id.HeaderText = "ID"
        Me.id.MinimumWidth = 50
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 50
        '
        'kode
        '
        Me.kode.DataPropertyName = "menu_kode"
        Me.kode.HeaderText = "Kode Menu"
        Me.kode.MinimumWidth = 100
        Me.kode.Name = "kode"
        Me.kode.ReadOnly = True
        '
        'parent
        '
        Me.parent.DataPropertyName = "menu_parent"
        Me.parent.HeaderText = "Menu Parent"
        Me.parent.Name = "parent"
        Me.parent.ReadOnly = True
        '
        'nama
        '
        Me.nama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.nama.DataPropertyName = "menu_label"
        Me.nama.HeaderText = "Nama"
        Me.nama.Name = "nama"
        Me.nama.ReadOnly = True
        '
        'status
        '
        Me.status.DataPropertyName = "menu_status"
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        '
        'bt_keluar_menu
        '
        Me.bt_keluar_menu.BackColor = System.Drawing.Color.Orange
        Me.bt_keluar_menu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bt_keluar_menu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_keluar_menu.ForeColor = System.Drawing.Color.White
        Me.bt_keluar_menu.Location = New System.Drawing.Point(624, 542)
        Me.bt_keluar_menu.Name = "bt_keluar_menu"
        Me.bt_keluar_menu.Size = New System.Drawing.Size(96, 30)
        Me.bt_keluar_menu.TabIndex = 7
        Me.bt_keluar_menu.Text = "Keluar"
        Me.bt_keluar_menu.UseVisualStyleBackColor = False
        '
        'bt_hapus_menu
        '
        Me.bt_hapus_menu.BackColor = System.Drawing.Color.Orange
        Me.bt_hapus_menu.Enabled = False
        Me.bt_hapus_menu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bt_hapus_menu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_hapus_menu.ForeColor = System.Drawing.Color.White
        Me.bt_hapus_menu.Location = New System.Drawing.Point(522, 150)
        Me.bt_hapus_menu.Name = "bt_hapus_menu"
        Me.bt_hapus_menu.Size = New System.Drawing.Size(96, 30)
        Me.bt_hapus_menu.TabIndex = 4
        Me.bt_hapus_menu.Text = "Hapus"
        Me.bt_hapus_menu.UseVisualStyleBackColor = False
        '
        'bt_tambah_menu
        '
        Me.bt_tambah_menu.BackColor = System.Drawing.Color.Orange
        Me.bt_tambah_menu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bt_tambah_menu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tambah_menu.ForeColor = System.Drawing.Color.White
        Me.bt_tambah_menu.Location = New System.Drawing.Point(420, 150)
        Me.bt_tambah_menu.Name = "bt_tambah_menu"
        Me.bt_tambah_menu.Size = New System.Drawing.Size(96, 30)
        Me.bt_tambah_menu.TabIndex = 3
        Me.bt_tambah_menu.Text = "Tambah"
        Me.bt_tambah_menu.UseVisualStyleBackColor = False
        '
        'in_menu_nama
        '
        Me.in_menu_nama.BackColor = System.Drawing.Color.White
        Me.in_menu_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_menu_nama.ForeColor = System.Drawing.Color.Black
        Me.in_menu_nama.Location = New System.Drawing.Point(100, 82)
        Me.in_menu_nama.MaxLength = 255
        Me.in_menu_nama.Name = "in_menu_nama"
        Me.in_menu_nama.Size = New System.Drawing.Size(337, 22)
        Me.in_menu_nama.TabIndex = 2
        '
        'in_id
        '
        Me.in_id.BackColor = System.Drawing.Color.Gainsboro
        Me.in_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_id.ForeColor = System.Drawing.Color.Black
        Me.in_id.Location = New System.Drawing.Point(627, 54)
        Me.in_id.Name = "in_id"
        Me.in_id.ReadOnly = True
        Me.in_id.Size = New System.Drawing.Size(93, 22)
        Me.in_id.TabIndex = 27
        Me.in_id.TabStop = False
        Me.in_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Nama"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(564, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 16)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "ID Menu"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Kode Menu"
        '
        'in_menu_kode
        '
        Me.in_menu_kode.BackColor = System.Drawing.Color.White
        Me.in_menu_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_menu_kode.ForeColor = System.Drawing.Color.Black
        Me.in_menu_kode.Location = New System.Drawing.Point(100, 54)
        Me.in_menu_kode.MaxLength = 30
        Me.in_menu_kode.Name = "in_menu_kode"
        Me.in_menu_kode.Size = New System.Drawing.Size(133, 22)
        Me.in_menu_kode.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(251, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 16)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Parent"
        '
        'in_menu_parent
        '
        Me.in_menu_parent.BackColor = System.Drawing.Color.White
        Me.in_menu_parent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_menu_parent.ForeColor = System.Drawing.Color.Black
        Me.in_menu_parent.Location = New System.Drawing.Point(304, 54)
        Me.in_menu_parent.MaxLength = 30
        Me.in_menu_parent.Name = "in_menu_parent"
        Me.in_menu_parent.Size = New System.Drawing.Size(133, 22)
        Me.in_menu_parent.TabIndex = 1
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Orange
        Me.lbl_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(9, 9)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(183, 20)
        Me.lbl_title.TabIndex = 133
        Me.lbl_title.Text = "Setting Menu Aplikasi"
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
        Me.Panel1.Size = New System.Drawing.Size(732, 42)
        Me.Panel1.TabIndex = 134
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(647, 9)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(47, 20)
        Me.lbl_close.TabIndex = 140
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
        Me.bt_cl.Location = New System.Drawing.Point(700, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 139
        Me.bt_cl.TabStop = False
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'bt_batal
        '
        Me.bt_batal.BackColor = System.Drawing.Color.Orange
        Me.bt_batal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bt_batal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batal.ForeColor = System.Drawing.Color.White
        Me.bt_batal.Location = New System.Drawing.Point(624, 150)
        Me.bt_batal.Name = "bt_batal"
        Me.bt_batal.Size = New System.Drawing.Size(96, 30)
        Me.bt_batal.TabIndex = 5
        Me.bt_batal.Text = "Batal"
        Me.bt_batal.UseVisualStyleBackColor = False
        '
        'ck_enable
        '
        Me.ck_enable.AutoSize = True
        Me.ck_enable.Location = New System.Drawing.Point(378, 110)
        Me.ck_enable.Name = "ck_enable"
        Me.ck_enable.Size = New System.Drawing.Size(59, 17)
        Me.ck_enable.TabIndex = 135
        Me.ck_enable.Text = "Enable"
        Me.ck_enable.UseVisualStyleBackColor = True
        '
        'fr_setup_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(732, 584)
        Me.Controls.Add(Me.ck_enable)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.in_menu_parent)
        Me.Controls.Add(Me.in_menu_kode)
        Me.Controls.Add(Me.in_menu_nama)
        Me.Controls.Add(Me.in_id)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.bt_batal)
        Me.Controls.Add(Me.bt_keluar_menu)
        Me.Controls.Add(Me.bt_tambah_menu)
        Me.Controls.Add(Me.bt_hapus_menu)
        Me.Controls.Add(Me.dgv_menu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fr_setup_menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Setting Menu"
        CType(Me.dgv_menu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_menu As System.Windows.Forms.DataGridView
    Friend WithEvents bt_keluar_menu As System.Windows.Forms.Button
    Friend WithEvents bt_hapus_menu As System.Windows.Forms.Button
    Friend WithEvents bt_tambah_menu As System.Windows.Forms.Button
    Friend WithEvents in_menu_nama As System.Windows.Forms.TextBox
    Friend WithEvents in_id As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_menu_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_menu_parent As System.Windows.Forms.TextBox
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_batal As System.Windows.Forms.Button
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents parent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ck_enable As System.Windows.Forms.CheckBox
End Class
