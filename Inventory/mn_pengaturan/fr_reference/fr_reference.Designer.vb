<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_reference
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgv_list = New System.Windows.Forms.DataGridView()
        Me.in_cari = New System.Windows.Forms.TextBox()
        Me.bt_cari = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_judul = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.bt_batal_jenis = New System.Windows.Forms.Button()
        Me.bt_edit = New System.Windows.Forms.Button()
        Me.bt_tb_jenis = New System.Windows.Forms.Button()
        Me.bt_del = New System.Windows.Forms.Button()
        Me.lb_reflist = New System.Windows.Forms.ListBox()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgv_list)
        Me.GroupBox2.Controls.Add(Me.in_cari)
        Me.GroupBox2.Controls.Add(Me.bt_cari)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(161, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(581, 380)
        Me.GroupBox2.TabIndex = 136
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Daftar :"
        '
        'dgv_list
        '
        Me.dgv_list.AllowUserToAddRows = False
        Me.dgv_list.AllowUserToDeleteRows = False
        Me.dgv_list.BackgroundColor = System.Drawing.Color.White
        Me.dgv_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_list.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgv_list.Location = New System.Drawing.Point(3, 53)
        Me.dgv_list.MultiSelect = False
        Me.dgv_list.Name = "dgv_list"
        Me.dgv_list.ReadOnly = True
        Me.dgv_list.RowHeadersVisible = False
        Me.dgv_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_list.Size = New System.Drawing.Size(575, 324)
        Me.dgv_list.TabIndex = 3
        '
        'in_cari
        '
        Me.in_cari.BackColor = System.Drawing.Color.White
        Me.in_cari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari.ForeColor = System.Drawing.Color.Black
        Me.in_cari.Location = New System.Drawing.Point(6, 24)
        Me.in_cari.MaxLength = 5
        Me.in_cari.Name = "in_cari"
        Me.in_cari.Size = New System.Drawing.Size(302, 22)
        Me.in_cari.TabIndex = 1
        '
        'bt_cari
        '
        Me.bt_cari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cari.Location = New System.Drawing.Point(310, 22)
        Me.bt_cari.Name = "bt_cari"
        Me.bt_cari.Size = New System.Drawing.Size(96, 25)
        Me.bt_cari.TabIndex = 2
        Me.bt_cari.Text = "Cari"
        Me.bt_cari.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.lbl_judul)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(747, 42)
        Me.Panel1.TabIndex = 137
        '
        'lbl_judul
        '
        Me.lbl_judul.AutoSize = True
        Me.lbl_judul.BackColor = System.Drawing.Color.Orange
        Me.lbl_judul.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_judul.Location = New System.Drawing.Point(9, 9)
        Me.lbl_judul.Name = "lbl_judul"
        Me.lbl_judul.Size = New System.Drawing.Size(147, 20)
        Me.lbl_judul.TabIndex = 133
        Me.lbl_judul.Text = "Set Jenis Barang"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Controls.Add(Me.bt_batal_jenis)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 492)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(747, 42)
        Me.Panel2.TabIndex = 138
        '
        'bt_batal_jenis
        '
        Me.bt_batal_jenis.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batal_jenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batal_jenis.Location = New System.Drawing.Point(634, 5)
        Me.bt_batal_jenis.Name = "bt_batal_jenis"
        Me.bt_batal_jenis.Size = New System.Drawing.Size(96, 30)
        Me.bt_batal_jenis.TabIndex = 7
        Me.bt_batal_jenis.Text = "Keluar"
        Me.bt_batal_jenis.UseVisualStyleBackColor = True
        '
        'bt_edit
        '
        Me.bt_edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_edit.Location = New System.Drawing.Point(535, 434)
        Me.bt_edit.Name = "bt_edit"
        Me.bt_edit.Size = New System.Drawing.Size(96, 30)
        Me.bt_edit.TabIndex = 9
        Me.bt_edit.Text = "Edit"
        Me.bt_edit.UseVisualStyleBackColor = True
        '
        'bt_tb_jenis
        '
        Me.bt_tb_jenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tb_jenis.Location = New System.Drawing.Point(436, 434)
        Me.bt_tb_jenis.Name = "bt_tb_jenis"
        Me.bt_tb_jenis.Size = New System.Drawing.Size(96, 30)
        Me.bt_tb_jenis.TabIndex = 8
        Me.bt_tb_jenis.Text = "Tambah"
        Me.bt_tb_jenis.UseVisualStyleBackColor = True
        '
        'bt_del
        '
        Me.bt_del.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_del.Location = New System.Drawing.Point(634, 434)
        Me.bt_del.Name = "bt_del"
        Me.bt_del.Size = New System.Drawing.Size(96, 30)
        Me.bt_del.TabIndex = 9
        Me.bt_del.Text = "Hapus"
        Me.bt_del.UseVisualStyleBackColor = True
        '
        'lb_reflist
        '
        Me.lb_reflist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_reflist.FormattingEnabled = True
        Me.lb_reflist.ItemHeight = 16
        Me.lb_reflist.Location = New System.Drawing.Point(13, 58)
        Me.lb_reflist.Name = "lb_reflist"
        Me.lb_reflist.Size = New System.Drawing.Size(142, 420)
        Me.lb_reflist.TabIndex = 4
        '
        'fr_reference
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 534)
        Me.Controls.Add(Me.lb_reflist)
        Me.Controls.Add(Me.bt_del)
        Me.Controls.Add(Me.bt_edit)
        Me.Controls.Add(Me.bt_tb_jenis)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "fr_reference"
        Me.Text = "Referensi"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv_list As System.Windows.Forms.DataGridView
    Friend WithEvents in_cari As System.Windows.Forms.TextBox
    Friend WithEvents bt_cari As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_judul As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents bt_batal_jenis As System.Windows.Forms.Button
    Friend WithEvents bt_edit As System.Windows.Forms.Button
    Friend WithEvents bt_tb_jenis As System.Windows.Forms.Button
    Friend WithEvents bt_del As System.Windows.Forms.Button
    Friend WithEvents lb_reflist As System.Windows.Forms.ListBox
End Class
