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
        Me.nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_batal = New System.Windows.Forms.Button()
        CType(Me.dgv_menu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_menu
        '
        Me.dgv_menu.AllowUserToAddRows = False
        Me.dgv_menu.AllowUserToDeleteRows = False
        Me.dgv_menu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_menu.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.kode, Me.nama})
        Me.dgv_menu.Location = New System.Drawing.Point(12, 186)
        Me.dgv_menu.MultiSelect = False
        Me.dgv_menu.Name = "dgv_menu"
        Me.dgv_menu.ReadOnly = True
        Me.dgv_menu.RowHeadersVisible = False
        Me.dgv_menu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_menu.Size = New System.Drawing.Size(425, 350)
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
        'nama
        '
        Me.nama.DataPropertyName = "menu_label"
        Me.nama.HeaderText = "Nama"
        Me.nama.MinimumWidth = 200
        Me.nama.Name = "nama"
        Me.nama.ReadOnly = True
        Me.nama.Width = 300
        '
        'bt_keluar_menu
        '
        Me.bt_keluar_menu.BackColor = System.Drawing.Color.Orange
        Me.bt_keluar_menu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bt_keluar_menu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_keluar_menu.Location = New System.Drawing.Point(341, 542)
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
        Me.bt_hapus_menu.Location = New System.Drawing.Point(239, 150)
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
        Me.bt_tambah_menu.Location = New System.Drawing.Point(137, 150)
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
        Me.in_menu_nama.Location = New System.Drawing.Point(100, 122)
        Me.in_menu_nama.MaxLength = 30
        Me.in_menu_nama.Name = "in_menu_nama"
        Me.in_menu_nama.Size = New System.Drawing.Size(337, 22)
        Me.in_menu_nama.TabIndex = 2
        '
        'in_id
        '
        Me.in_id.BackColor = System.Drawing.Color.Gainsboro
        Me.in_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_id.ForeColor = System.Drawing.Color.Black
        Me.in_id.Location = New System.Drawing.Point(100, 51)
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
        Me.Label3.Location = New System.Drawing.Point(9, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Nama"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 16)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "ID Menu"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 92)
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
        Me.in_menu_kode.Location = New System.Drawing.Point(100, 89)
        Me.in_menu_kode.MaxLength = 30
        Me.in_menu_kode.Name = "in_menu_kode"
        Me.in_menu_kode.Size = New System.Drawing.Size(133, 22)
        Me.in_menu_kode.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(251, 92)
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
        Me.in_menu_parent.Location = New System.Drawing.Point(304, 89)
        Me.in_menu_parent.MaxLength = 30
        Me.in_menu_parent.Name = "in_menu_parent"
        Me.in_menu_parent.Size = New System.Drawing.Size(133, 22)
        Me.in_menu_parent.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Orange
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(183, 20)
        Me.Label9.TabIndex = 133
        Me.Label9.Text = "Setting Menu Aplikasi"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(451, 42)
        Me.Panel1.TabIndex = 134
        '
        'bt_batal
        '
        Me.bt_batal.BackColor = System.Drawing.Color.Orange
        Me.bt_batal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bt_batal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batal.Location = New System.Drawing.Point(341, 150)
        Me.bt_batal.Name = "bt_batal"
        Me.bt_batal.Size = New System.Drawing.Size(96, 30)
        Me.bt_batal.TabIndex = 5
        Me.bt_batal.Text = "Batal"
        Me.bt_batal.UseVisualStyleBackColor = False
        '
        'fr_setup_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(449, 584)
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
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bt_batal As System.Windows.Forms.Button
End Class
