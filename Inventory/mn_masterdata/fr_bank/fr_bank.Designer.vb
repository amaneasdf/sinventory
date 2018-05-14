<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_bank
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.bt_closegudang = New System.Windows.Forms.Button()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bt_editgudang = New System.Windows.Forms.Button()
        Me.in_carigudang = New System.Windows.Forms.TextBox()
        Me.bt_refreshgudang = New System.Windows.Forms.Button()
        Me.bt_tambahgudang = New System.Windows.Forms.Button()
        Me.bt_hapusgudang = New System.Windows.Forms.Button()
        Me.in_alamatgudang = New System.Windows.Forms.TextBox()
        Me.bt_batalgudang = New System.Windows.Forms.Button()
        Me.bt_simpangudang = New System.Windows.Forms.Button()
        Me.in_namagudang = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgv_supplier = New System.Windows.Forms.DataGridView()
        Me.col_kodesup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_namasup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_alamatsup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bt_exportsupplier = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.dgv_supplier, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Size = New System.Drawing.Size(917, 571)
        Me.SplitContainer1.SplitterDistance = 40
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 24)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Form Master Bank"
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.bt_closegudang)
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer3)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.bt_exportsupplier)
        Me.SplitContainer2.Size = New System.Drawing.Size(917, 530)
        Me.SplitContainer2.SplitterDistance = 493
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 2
        '
        'bt_closegudang
        '
        Me.bt_closegudang.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_closegudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_closegudang.Location = New System.Drawing.Point(818, 5)
        Me.bt_closegudang.Name = "bt_closegudang"
        Me.bt_closegudang.Size = New System.Drawing.Size(96, 30)
        Me.bt_closegudang.TabIndex = 5
        Me.bt_closegudang.Text = "Tutup"
        Me.bt_closegudang.UseVisualStyleBackColor = True
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
        Me.SplitContainer3.Panel1.Controls.Add(Me.bt_editgudang)
        Me.SplitContainer3.Panel1.Controls.Add(Me.in_carigudang)
        Me.SplitContainer3.Panel1.Controls.Add(Me.bt_refreshgudang)
        Me.SplitContainer3.Panel1.Controls.Add(Me.bt_tambahgudang)
        Me.SplitContainer3.Panel1.Controls.Add(Me.bt_hapusgudang)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.in_alamatgudang)
        Me.SplitContainer3.Panel2.Controls.Add(Me.bt_batalgudang)
        Me.SplitContainer3.Panel2.Controls.Add(Me.bt_simpangudang)
        Me.SplitContainer3.Panel2.Controls.Add(Me.in_namagudang)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer3.Panel2.Controls.Add(Me.in_kode)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer3.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer3.Panel2.Controls.Add(Me.dgv_supplier)
        Me.SplitContainer3.Size = New System.Drawing.Size(917, 493)
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
        'bt_editgudang
        '
        Me.bt_editgudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_editgudang.Location = New System.Drawing.Point(476, 5)
        Me.bt_editgudang.Name = "bt_editgudang"
        Me.bt_editgudang.Size = New System.Drawing.Size(96, 30)
        Me.bt_editgudang.TabIndex = 2
        Me.bt_editgudang.Text = "Koreksi"
        Me.bt_editgudang.UseVisualStyleBackColor = True
        '
        'in_carigudang
        '
        Me.in_carigudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_carigudang.Location = New System.Drawing.Point(85, 10)
        Me.in_carigudang.Name = "in_carigudang"
        Me.in_carigudang.Size = New System.Drawing.Size(248, 22)
        Me.in_carigudang.TabIndex = 0
        '
        'bt_refreshgudang
        '
        Me.bt_refreshgudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_refreshgudang.Location = New System.Drawing.Point(680, 5)
        Me.bt_refreshgudang.Name = "bt_refreshgudang"
        Me.bt_refreshgudang.Size = New System.Drawing.Size(96, 30)
        Me.bt_refreshgudang.TabIndex = 4
        Me.bt_refreshgudang.Text = "Refresh"
        Me.bt_refreshgudang.UseVisualStyleBackColor = True
        '
        'bt_tambahgudang
        '
        Me.bt_tambahgudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tambahgudang.Location = New System.Drawing.Point(374, 5)
        Me.bt_tambahgudang.Name = "bt_tambahgudang"
        Me.bt_tambahgudang.Size = New System.Drawing.Size(96, 30)
        Me.bt_tambahgudang.TabIndex = 1
        Me.bt_tambahgudang.Text = "Tambah"
        Me.bt_tambahgudang.UseVisualStyleBackColor = True
        '
        'bt_hapusgudang
        '
        Me.bt_hapusgudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_hapusgudang.Location = New System.Drawing.Point(578, 5)
        Me.bt_hapusgudang.Name = "bt_hapusgudang"
        Me.bt_hapusgudang.Size = New System.Drawing.Size(96, 30)
        Me.bt_hapusgudang.TabIndex = 3
        Me.bt_hapusgudang.Text = "Hapus"
        Me.bt_hapusgudang.UseVisualStyleBackColor = True
        '
        'in_alamatgudang
        '
        Me.in_alamatgudang.BackColor = System.Drawing.Color.LightGray
        Me.in_alamatgudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_alamatgudang.ForeColor = System.Drawing.Color.Black
        Me.in_alamatgudang.Location = New System.Drawing.Point(124, 69)
        Me.in_alamatgudang.Name = "in_alamatgudang"
        Me.in_alamatgudang.ReadOnly = True
        Me.in_alamatgudang.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_alamatgudang.Size = New System.Drawing.Size(167, 22)
        Me.in_alamatgudang.TabIndex = 8
        '
        'bt_batalgudang
        '
        Me.bt_batalgudang.Enabled = False
        Me.bt_batalgudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalgudang.Location = New System.Drawing.Point(368, 114)
        Me.bt_batalgudang.Name = "bt_batalgudang"
        Me.bt_batalgudang.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalgudang.TabIndex = 10
        Me.bt_batalgudang.Text = "Batal"
        Me.bt_batalgudang.UseVisualStyleBackColor = True
        '
        'bt_simpangudang
        '
        Me.bt_simpangudang.Enabled = False
        Me.bt_simpangudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpangudang.Location = New System.Drawing.Point(266, 114)
        Me.bt_simpangudang.Name = "bt_simpangudang"
        Me.bt_simpangudang.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpangudang.TabIndex = 9
        Me.bt_simpangudang.Text = "Simpan"
        Me.bt_simpangudang.UseVisualStyleBackColor = True
        '
        'in_namagudang
        '
        Me.in_namagudang.BackColor = System.Drawing.Color.LightGray
        Me.in_namagudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_namagudang.ForeColor = System.Drawing.Color.Black
        Me.in_namagudang.Location = New System.Drawing.Point(124, 41)
        Me.in_namagudang.Name = "in_namagudang"
        Me.in_namagudang.ReadOnly = True
        Me.in_namagudang.Size = New System.Drawing.Size(340, 22)
        Me.in_namagudang.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Pos"
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.LightGray
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.ForeColor = System.Drawing.Color.Black
        Me.in_kode.Location = New System.Drawing.Point(124, 11)
        Me.in_kode.Name = "in_kode"
        Me.in_kode.ReadOnly = True
        Me.in_kode.Size = New System.Drawing.Size(131, 22)
        Me.in_kode.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nama"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Kode"
        '
        'dgv_supplier
        '
        Me.dgv_supplier.AllowUserToAddRows = False
        Me.dgv_supplier.AllowUserToDeleteRows = False
        Me.dgv_supplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_supplier.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_kodesup, Me.col_namasup, Me.col_alamatsup})
        Me.dgv_supplier.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgv_supplier.Location = New System.Drawing.Point(0, 278)
        Me.dgv_supplier.Name = "dgv_supplier"
        Me.dgv_supplier.ReadOnly = True
        Me.dgv_supplier.Size = New System.Drawing.Size(917, 157)
        Me.dgv_supplier.TabIndex = 11
        '
        'col_kodesup
        '
        Me.col_kodesup.DataPropertyName = "kode"
        Me.col_kodesup.HeaderText = "Kode"
        Me.col_kodesup.Name = "col_kodesup"
        Me.col_kodesup.ReadOnly = True
        '
        'col_namasup
        '
        Me.col_namasup.DataPropertyName = "nama"
        Me.col_namasup.HeaderText = "Nama Gudang"
        Me.col_namasup.Name = "col_namasup"
        Me.col_namasup.ReadOnly = True
        '
        'col_alamatsup
        '
        Me.col_alamatsup.DataPropertyName = "alamat"
        Me.col_alamatsup.HeaderText = "Alamat"
        Me.col_alamatsup.Name = "col_alamatsup"
        Me.col_alamatsup.ReadOnly = True
        '
        'bt_exportsupplier
        '
        Me.bt_exportsupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_exportsupplier.Location = New System.Drawing.Point(16, 3)
        Me.bt_exportsupplier.Name = "bt_exportsupplier"
        Me.bt_exportsupplier.Size = New System.Drawing.Size(163, 32)
        Me.bt_exportsupplier.TabIndex = 1
        Me.bt_exportsupplier.Text = "Export ke Excel"
        Me.bt_exportsupplier.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(297, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Pos"
        '
        'fr_bank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "fr_bank"
        Me.Size = New System.Drawing.Size(917, 571)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.dgv_supplier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents bt_closegudang As System.Windows.Forms.Button
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bt_editgudang As System.Windows.Forms.Button
    Friend WithEvents in_carigudang As System.Windows.Forms.TextBox
    Friend WithEvents bt_refreshgudang As System.Windows.Forms.Button
    Friend WithEvents bt_tambahgudang As System.Windows.Forms.Button
    Friend WithEvents bt_hapusgudang As System.Windows.Forms.Button
    Friend WithEvents in_alamatgudang As System.Windows.Forms.TextBox
    Friend WithEvents bt_batalgudang As System.Windows.Forms.Button
    Friend WithEvents bt_simpangudang As System.Windows.Forms.Button
    Friend WithEvents in_namagudang As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgv_supplier As System.Windows.Forms.DataGridView
    Friend WithEvents col_kodesup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_namasup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_alamatsup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bt_exportsupplier As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
