<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_stok_awal
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
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_gudang = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_barang = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_gudang = New System.Windows.Forms.Label()
        Me.lbl_barang = New System.Windows.Forms.Label()
        Me.in_stok_awal = New System.Windows.Forms.NumericUpDown()
        Me.in_hpp = New System.Windows.Forms.NumericUpDown()
        Me.bt_batalbarang = New System.Windows.Forms.Button()
        Me.bt_simpanbarang = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.in_stok_awal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.in_hpp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'in_kode
        '
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.Location = New System.Drawing.Point(105, 66)
        Me.in_kode.MaxLength = 15
        Me.in_kode.Name = "in_kode"
        Me.in_kode.ReadOnly = True
        Me.in_kode.Size = New System.Drawing.Size(131, 22)
        Me.in_kode.TabIndex = 138
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "Kode"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(424, 42)
        Me.Panel1.TabIndex = 140
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Orange
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(188, 20)
        Me.Label9.TabIndex = 133
        Me.Label9.Text = "Form Setup Stok Awal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = "Gudang"
        '
        'in_gudang
        '
        Me.in_gudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_gudang.Location = New System.Drawing.Point(105, 94)
        Me.in_gudang.MaxLength = 15
        Me.in_gudang.Name = "in_gudang"
        Me.in_gudang.Size = New System.Drawing.Size(131, 22)
        Me.in_gudang.TabIndex = 138
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 139
        Me.Label2.Text = "Barang"
        '
        'in_barang
        '
        Me.in_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_barang.Location = New System.Drawing.Point(105, 122)
        Me.in_barang.MaxLength = 15
        Me.in_barang.Name = "in_barang"
        Me.in_barang.Size = New System.Drawing.Size(131, 22)
        Me.in_barang.TabIndex = 138
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "Stok Awal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 16)
        Me.Label5.TabIndex = 139
        Me.Label5.Text = "HPP"
        '
        'lbl_gudang
        '
        Me.lbl_gudang.AutoSize = True
        Me.lbl_gudang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_gudang.Location = New System.Drawing.Point(242, 97)
        Me.lbl_gudang.Name = "lbl_gudang"
        Me.lbl_gudang.Size = New System.Drawing.Size(56, 16)
        Me.lbl_gudang.TabIndex = 139
        Me.lbl_gudang.Text = "Gudang"
        '
        'lbl_barang
        '
        Me.lbl_barang.AutoSize = True
        Me.lbl_barang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_barang.Location = New System.Drawing.Point(242, 125)
        Me.lbl_barang.Name = "lbl_barang"
        Me.lbl_barang.Size = New System.Drawing.Size(52, 16)
        Me.lbl_barang.TabIndex = 139
        Me.lbl_barang.Text = "Barang"
        '
        'in_stok_awal
        '
        Me.in_stok_awal.Location = New System.Drawing.Point(105, 153)
        Me.in_stok_awal.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.in_stok_awal.Name = "in_stok_awal"
        Me.in_stok_awal.Size = New System.Drawing.Size(131, 20)
        Me.in_stok_awal.TabIndex = 141
        Me.in_stok_awal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_stok_awal.ThousandsSeparator = True
        '
        'in_hpp
        '
        Me.in_hpp.DecimalPlaces = 2
        Me.in_hpp.Location = New System.Drawing.Point(105, 181)
        Me.in_hpp.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.in_hpp.Name = "in_hpp"
        Me.in_hpp.Size = New System.Drawing.Size(131, 20)
        Me.in_hpp.TabIndex = 141
        Me.in_hpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.in_hpp.ThousandsSeparator = True
        '
        'bt_batalbarang
        '
        Me.bt_batalbarang.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_batalbarang.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalbarang.Location = New System.Drawing.Point(316, 301)
        Me.bt_batalbarang.Name = "bt_batalbarang"
        Me.bt_batalbarang.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalbarang.TabIndex = 143
        Me.bt_batalbarang.Text = "Batal"
        Me.bt_batalbarang.UseVisualStyleBackColor = True
        '
        'bt_simpanbarang
        '
        Me.bt_simpanbarang.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_simpanbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbarang.Location = New System.Drawing.Point(316, 266)
        Me.bt_simpanbarang.Name = "bt_simpanbarang"
        Me.bt_simpanbarang.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpanbarang.TabIndex = 142
        Me.bt_simpanbarang.Text = "Simpan"
        Me.bt_simpanbarang.UseVisualStyleBackColor = True
        '
        'fr_stok_awal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.bt_batalbarang
        Me.ClientSize = New System.Drawing.Size(424, 343)
        Me.Controls.Add(Me.bt_batalbarang)
        Me.Controls.Add(Me.bt_simpanbarang)
        Me.Controls.Add(Me.in_hpp)
        Me.Controls.Add(Me.in_stok_awal)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.in_barang)
        Me.Controls.Add(Me.lbl_barang)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_gudang)
        Me.Controls.Add(Me.in_gudang)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.in_kode)
        Me.Controls.Add(Me.Label3)
        Me.Name = "fr_stok_awal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "fr_stok_awal"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.in_stok_awal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.in_hpp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_gudang As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_barang As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_gudang As System.Windows.Forms.Label
    Friend WithEvents lbl_barang As System.Windows.Forms.Label
    Friend WithEvents in_stok_awal As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_hpp As System.Windows.Forms.NumericUpDown
    Friend WithEvents bt_batalbarang As System.Windows.Forms.Button
    Friend WithEvents bt_simpanbarang As System.Windows.Forms.Button
End Class
