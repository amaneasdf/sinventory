<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_neracaawal_detail
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cb_jenis = New System.Windows.Forms.ComboBox()
        Me.cb_jurnal = New System.Windows.Forms.ComboBox()
        Me.cb_posisi = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.in_kode_jenis = New System.Windows.Forms.TextBox()
        Me.in_kode_jurnal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_kode_posisi = New System.Windows.Forms.TextBox()
        Me.in_parent = New System.Windows.Forms.TextBox()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.in_nama = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_saldo = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.bt_batalmigrasi = New System.Windows.Forms.Button()
        Me.bt_simpanmigrasi = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.in_saldo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Orange
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(180, 20)
        Me.Label9.TabIndex = 133
        Me.Label9.Text = "Detail Migrasi Neraca"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(439, 42)
        Me.Panel1.TabIndex = 143
        '
        'cb_jenis
        '
        Me.cb_jenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_jenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_jenis.FormattingEnabled = True
        Me.cb_jenis.Location = New System.Drawing.Point(164, 119)
        Me.cb_jenis.Name = "cb_jenis"
        Me.cb_jenis.Size = New System.Drawing.Size(175, 23)
        Me.cb_jenis.TabIndex = 3
        '
        'cb_jurnal
        '
        Me.cb_jurnal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_jurnal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_jurnal.FormattingEnabled = True
        Me.cb_jurnal.Location = New System.Drawing.Point(164, 177)
        Me.cb_jurnal.Name = "cb_jurnal"
        Me.cb_jurnal.Size = New System.Drawing.Size(175, 23)
        Me.cb_jurnal.TabIndex = 5
        '
        'cb_posisi
        '
        Me.cb_posisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_posisi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_posisi.FormattingEnabled = True
        Me.cb_posisi.Location = New System.Drawing.Point(164, 148)
        Me.cb_posisi.Name = "cb_posisi"
        Me.cb_posisi.Size = New System.Drawing.Size(175, 23)
        Me.cb_posisi.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 162
        Me.Label6.Text = "Jenis"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 180)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 16)
        Me.Label8.TabIndex = 161
        Me.Label8.Text = "Jurnal"
        '
        'in_kode_jenis
        '
        Me.in_kode_jenis.BackColor = System.Drawing.Color.White
        Me.in_kode_jenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode_jenis.ForeColor = System.Drawing.Color.Black
        Me.in_kode_jenis.Location = New System.Drawing.Point(101, 119)
        Me.in_kode_jenis.MaxLength = 5
        Me.in_kode_jenis.Name = "in_kode_jenis"
        Me.in_kode_jenis.Size = New System.Drawing.Size(57, 22)
        Me.in_kode_jenis.TabIndex = 159
        Me.in_kode_jenis.TabStop = False
        '
        'in_kode_jurnal
        '
        Me.in_kode_jurnal.BackColor = System.Drawing.Color.White
        Me.in_kode_jurnal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode_jurnal.ForeColor = System.Drawing.Color.Black
        Me.in_kode_jurnal.Location = New System.Drawing.Point(101, 177)
        Me.in_kode_jurnal.MaxLength = 5
        Me.in_kode_jurnal.Name = "in_kode_jurnal"
        Me.in_kode_jurnal.Size = New System.Drawing.Size(57, 22)
        Me.in_kode_jurnal.TabIndex = 158
        Me.in_kode_jurnal.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 16)
        Me.Label5.TabIndex = 163
        Me.Label5.Text = "Posisi D/K"
        '
        'in_kode_posisi
        '
        Me.in_kode_posisi.BackColor = System.Drawing.Color.White
        Me.in_kode_posisi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode_posisi.ForeColor = System.Drawing.Color.Black
        Me.in_kode_posisi.Location = New System.Drawing.Point(101, 148)
        Me.in_kode_posisi.MaxLength = 5
        Me.in_kode_posisi.Name = "in_kode_posisi"
        Me.in_kode_posisi.Size = New System.Drawing.Size(57, 22)
        Me.in_kode_posisi.TabIndex = 160
        Me.in_kode_posisi.TabStop = False
        '
        'in_parent
        '
        Me.in_parent.BackColor = System.Drawing.Color.White
        Me.in_parent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_parent.ForeColor = System.Drawing.Color.Black
        Me.in_parent.Location = New System.Drawing.Point(293, 63)
        Me.in_parent.MaxLength = 20
        Me.in_parent.Name = "in_parent"
        Me.in_parent.Size = New System.Drawing.Size(133, 22)
        Me.in_parent.TabIndex = 1
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.White
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.ForeColor = System.Drawing.Color.Black
        Me.in_kode.Location = New System.Drawing.Point(101, 63)
        Me.in_kode.MaxLength = 20
        Me.in_kode.Name = "in_kode"
        Me.in_kode.Size = New System.Drawing.Size(133, 22)
        Me.in_kode.TabIndex = 0
        '
        'in_ket
        '
        Me.in_ket.BackColor = System.Drawing.Color.White
        Me.in_ket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.ForeColor = System.Drawing.Color.Black
        Me.in_ket.Location = New System.Drawing.Point(101, 233)
        Me.in_ket.MaxLength = 200
        Me.in_ket.Multiline = True
        Me.in_ket.Name = "in_ket"
        Me.in_ket.Size = New System.Drawing.Size(323, 75)
        Me.in_ket.TabIndex = 7
        '
        'in_nama
        '
        Me.in_nama.BackColor = System.Drawing.Color.White
        Me.in_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_nama.ForeColor = System.Drawing.Color.Black
        Me.in_nama.Location = New System.Drawing.Point(101, 91)
        Me.in_nama.MaxLength = 100
        Me.in_nama.Name = "in_nama"
        Me.in_nama.Size = New System.Drawing.Size(325, 22)
        Me.in_nama.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 236)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 16)
        Me.Label4.TabIndex = 154
        Me.Label4.Text = "Keterangan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(240, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 16)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Parent"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 155
        Me.Label3.Text = "Nama"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 157
        Me.Label7.Text = "Kode"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 207)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 16)
        Me.Label1.TabIndex = 161
        Me.Label1.Text = "Saldo"
        '
        'in_saldo
        '
        Me.in_saldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_saldo.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.in_saldo.Location = New System.Drawing.Point(137, 205)
        Me.in_saldo.Maximum = New Decimal(New Integer() {1661992959, 1808227885, 5, 0})
        Me.in_saldo.Name = "in_saldo"
        Me.in_saldo.Size = New System.Drawing.Size(202, 22)
        Me.in_saldo.TabIndex = 6
        Me.in_saldo.ThousandsSeparator = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(98, 207)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 16)
        Me.Label10.TabIndex = 161
        Me.Label10.Text = "Rp."
        '
        'bt_batalmigrasi
        '
        Me.bt_batalmigrasi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_batalmigrasi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalmigrasi.Location = New System.Drawing.Point(330, 316)
        Me.bt_batalmigrasi.Name = "bt_batalmigrasi"
        Me.bt_batalmigrasi.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalmigrasi.TabIndex = 165
        Me.bt_batalmigrasi.Text = "Batal"
        Me.bt_batalmigrasi.UseVisualStyleBackColor = True
        '
        'bt_simpanmigrasi
        '
        Me.bt_simpanmigrasi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_simpanmigrasi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanmigrasi.Location = New System.Drawing.Point(228, 316)
        Me.bt_simpanmigrasi.Name = "bt_simpanmigrasi"
        Me.bt_simpanmigrasi.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpanmigrasi.TabIndex = 164
        Me.bt_simpanmigrasi.Text = "Simpan"
        Me.bt_simpanmigrasi.UseVisualStyleBackColor = True
        '
        'fr_neracaawal_detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 358)
        Me.Controls.Add(Me.bt_batalmigrasi)
        Me.Controls.Add(Me.bt_simpanmigrasi)
        Me.Controls.Add(Me.in_saldo)
        Me.Controls.Add(Me.cb_jenis)
        Me.Controls.Add(Me.cb_jurnal)
        Me.Controls.Add(Me.cb_posisi)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.in_kode_jenis)
        Me.Controls.Add(Me.in_kode_jurnal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.in_kode_posisi)
        Me.Controls.Add(Me.in_parent)
        Me.Controls.Add(Me.in_kode)
        Me.Controls.Add(Me.in_ket)
        Me.Controls.Add(Me.in_nama)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "fr_neracaawal_detail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detail Migrasi : "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.in_saldo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cb_jenis As System.Windows.Forms.ComboBox
    Friend WithEvents cb_jurnal As System.Windows.Forms.ComboBox
    Friend WithEvents cb_posisi As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents in_kode_jenis As System.Windows.Forms.TextBox
    Friend WithEvents in_kode_jurnal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_kode_posisi As System.Windows.Forms.TextBox
    Friend WithEvents in_parent As System.Windows.Forms.TextBox
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
    Friend WithEvents in_nama As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_saldo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents bt_batalmigrasi As System.Windows.Forms.Button
    Friend WithEvents bt_simpanmigrasi As System.Windows.Forms.Button
End Class
