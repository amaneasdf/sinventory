<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_hutang_awal
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.bt_batalreturbeli = New System.Windows.Forms.Button()
        Me.in_faktur = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_tgl = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_supplier = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.in_supplier_n = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_hutang_awal = New System.Windows.Forms.TextBox()
        Me.in_term = New System.Windows.Forms.NumericUpDown()
        Me.in_tgl_term = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.in_total = New System.Windows.Forms.TextBox()
        Me.in_sisa = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.in_tgllunas = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.bt_bayar = New System.Windows.Forms.Button()
        Me.dgv_hutang = New System.Windows.Forms.DataGridView()
        Me.ket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tgl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hutang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bayar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.in_term, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_hutang, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(550, 42)
        Me.Panel1.TabIndex = 276
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(470, 9)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(47, 20)
        Me.lbl_close.TabIndex = 138
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
        Me.bt_cl.Location = New System.Drawing.Point(523, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 137
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Orange
        Me.lbl_title.Font = New System.Drawing.Font("Source Sans Pro", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(6, 4)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(148, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Data Hutang"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 533)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(550, 10)
        Me.Panel2.TabIndex = 288
        '
        'bt_batalreturbeli
        '
        Me.bt_batalreturbeli.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_batalreturbeli.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalreturbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalreturbeli.Location = New System.Drawing.Point(442, 498)
        Me.bt_batalreturbeli.Name = "bt_batalreturbeli"
        Me.bt_batalreturbeli.Size = New System.Drawing.Size(96, 29)
        Me.bt_batalreturbeli.TabIndex = 9
        Me.bt_batalreturbeli.Text = "OK"
        Me.bt_batalreturbeli.UseVisualStyleBackColor = True
        '
        'in_faktur
        '
        Me.in_faktur.BackColor = System.Drawing.Color.White
        Me.in_faktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_faktur.Location = New System.Drawing.Point(82, 50)
        Me.in_faktur.MaxLength = 15
        Me.in_faktur.Name = "in_faktur"
        Me.in_faktur.ReadOnly = True
        Me.in_faktur.Size = New System.Drawing.Size(172, 20)
        Me.in_faktur.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 292
        Me.Label3.Text = "Faktur"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 292
        Me.Label1.Text = "Tanggal"
        '
        'in_tgl
        '
        Me.in_tgl.BackColor = System.Drawing.Color.White
        Me.in_tgl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_tgl.Location = New System.Drawing.Point(82, 72)
        Me.in_tgl.MaxLength = 15
        Me.in_tgl.Name = "in_tgl"
        Me.in_tgl.ReadOnly = True
        Me.in_tgl.Size = New System.Drawing.Size(172, 20)
        Me.in_tgl.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 292
        Me.Label2.Text = "Supplier"
        '
        'in_supplier
        '
        Me.in_supplier.BackColor = System.Drawing.Color.White
        Me.in_supplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier.Location = New System.Drawing.Point(82, 94)
        Me.in_supplier.MaxLength = 15
        Me.in_supplier.Name = "in_supplier"
        Me.in_supplier.ReadOnly = True
        Me.in_supplier.Size = New System.Drawing.Size(95, 20)
        Me.in_supplier.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 292
        Me.Label4.Text = "Term"
        '
        'in_supplier_n
        '
        Me.in_supplier_n.BackColor = System.Drawing.Color.White
        Me.in_supplier_n.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier_n.Location = New System.Drawing.Point(178, 94)
        Me.in_supplier_n.MaxLength = 15
        Me.in_supplier_n.Name = "in_supplier_n"
        Me.in_supplier_n.ReadOnly = True
        Me.in_supplier_n.Size = New System.Drawing.Size(177, 20)
        Me.in_supplier_n.TabIndex = 4
        Me.in_supplier_n.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 292
        Me.Label5.Text = "Hutang Awal"
        '
        'in_hutang_awal
        '
        Me.in_hutang_awal.BackColor = System.Drawing.Color.White
        Me.in_hutang_awal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_hutang_awal.Location = New System.Drawing.Point(82, 138)
        Me.in_hutang_awal.MaxLength = 15
        Me.in_hutang_awal.Name = "in_hutang_awal"
        Me.in_hutang_awal.ReadOnly = True
        Me.in_hutang_awal.Size = New System.Drawing.Size(172, 20)
        Me.in_hutang_awal.TabIndex = 6
        '
        'in_term
        '
        Me.in_term.Location = New System.Drawing.Point(82, 116)
        Me.in_term.Name = "in_term"
        Me.in_term.Size = New System.Drawing.Size(95, 20)
        Me.in_term.TabIndex = 296
        '
        'in_tgl_term
        '
        Me.in_tgl_term.BackColor = System.Drawing.Color.White
        Me.in_tgl_term.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_tgl_term.Location = New System.Drawing.Point(178, 116)
        Me.in_tgl_term.MaxLength = 15
        Me.in_tgl_term.Name = "in_tgl_term"
        Me.in_tgl_term.ReadOnly = True
        Me.in_tgl_term.Size = New System.Drawing.Size(177, 20)
        Me.in_tgl_term.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.Location = New System.Drawing.Point(11, 414)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 13)
        Me.Label6.TabIndex = 370
        Me.Label6.Text = "Total Pembayaran"
        '
        'in_total
        '
        Me.in_total.BackColor = System.Drawing.Color.White
        Me.in_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_total.ForeColor = System.Drawing.Color.Black
        Me.in_total.Location = New System.Drawing.Point(123, 411)
        Me.in_total.MaxLength = 50
        Me.in_total.Name = "in_total"
        Me.in_total.ReadOnly = True
        Me.in_total.Size = New System.Drawing.Size(218, 21)
        Me.in_total.TabIndex = 369
        Me.in_total.TabStop = False
        Me.in_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_sisa
        '
        Me.in_sisa.BackColor = System.Drawing.Color.White
        Me.in_sisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_sisa.ForeColor = System.Drawing.Color.Black
        Me.in_sisa.Location = New System.Drawing.Point(123, 435)
        Me.in_sisa.MaxLength = 50
        Me.in_sisa.Name = "in_sisa"
        Me.in_sisa.ReadOnly = True
        Me.in_sisa.Size = New System.Drawing.Size(218, 21)
        Me.in_sisa.TabIndex = 369
        Me.in_sisa.TabStop = False
        Me.in_sisa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(11, 438)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 370
        Me.Label7.Text = "Sisa Hutang"
        '
        'in_tgllunas
        '
        Me.in_tgllunas.BackColor = System.Drawing.Color.White
        Me.in_tgllunas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_tgllunas.ForeColor = System.Drawing.Color.Black
        Me.in_tgllunas.Location = New System.Drawing.Point(123, 460)
        Me.in_tgllunas.MaxLength = 50
        Me.in_tgllunas.Name = "in_tgllunas"
        Me.in_tgllunas.ReadOnly = True
        Me.in_tgllunas.Size = New System.Drawing.Size(218, 21)
        Me.in_tgllunas.TabIndex = 369
        Me.in_tgllunas.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(11, 463)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 370
        Me.Label8.Text = "Tgl Pelunasan"
        '
        'bt_bayar
        '
        Me.bt_bayar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_bayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_bayar.Location = New System.Drawing.Point(14, 487)
        Me.bt_bayar.Name = "bt_bayar"
        Me.bt_bayar.Size = New System.Drawing.Size(146, 29)
        Me.bt_bayar.TabIndex = 371
        Me.bt_bayar.Text = "Tambah Pembayaran"
        Me.bt_bayar.UseVisualStyleBackColor = True
        '
        'dgv_hutang
        '
        Me.dgv_hutang.AllowUserToAddRows = False
        Me.dgv_hutang.AllowUserToDeleteRows = False
        Me.dgv_hutang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_hutang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ket, Me.tgl, Me.hutang, Me.bayar, Me.ref, Me.status})
        Me.dgv_hutang.Location = New System.Drawing.Point(10, 164)
        Me.dgv_hutang.Name = "dgv_hutang"
        Me.dgv_hutang.ReadOnly = True
        Me.dgv_hutang.RowHeadersVisible = False
        Me.dgv_hutang.Size = New System.Drawing.Size(530, 241)
        Me.dgv_hutang.TabIndex = 372
        '
        'ket
        '
        Me.ket.DataPropertyName = "Ket"
        Me.ket.HeaderText = "Ket"
        Me.ket.Name = "ket"
        Me.ket.ReadOnly = True
        Me.ket.Width = 75
        '
        'tgl
        '
        Me.tgl.DataPropertyName = "Tanggal"
        Me.tgl.HeaderText = "Tanggal"
        Me.tgl.Name = "tgl"
        Me.tgl.ReadOnly = True
        Me.tgl.Width = 85
        '
        'hutang
        '
        Me.hutang.DataPropertyName = "Hutang"
        Me.hutang.HeaderText = "Hutang"
        Me.hutang.Name = "hutang"
        Me.hutang.ReadOnly = True
        '
        'bayar
        '
        Me.bayar.DataPropertyName = "Bayar"
        Me.bayar.HeaderText = "Bayar"
        Me.bayar.Name = "bayar"
        Me.bayar.ReadOnly = True
        '
        'ref
        '
        Me.ref.DataPropertyName = "Ref"
        Me.ref.HeaderText = "Ref"
        Me.ref.Name = "ref"
        Me.ref.ReadOnly = True
        Me.ref.Width = 150
        '
        'status
        '
        Me.status.DataPropertyName = "piutang_status"
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        '
        'fr_hutang_awal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(550, 543)
        Me.Controls.Add(Me.dgv_hutang)
        Me.Controls.Add(Me.bt_bayar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.in_tgllunas)
        Me.Controls.Add(Me.in_sisa)
        Me.Controls.Add(Me.in_total)
        Me.Controls.Add(Me.in_term)
        Me.Controls.Add(Me.in_hutang_awal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.in_supplier_n)
        Me.Controls.Add(Me.in_supplier)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.in_tgl_term)
        Me.Controls.Add(Me.in_tgl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.in_faktur)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.bt_batalreturbeli)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fr_hutang_awal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fr_hutang_awal"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.in_term, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_hutang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents bt_batalreturbeli As System.Windows.Forms.Button
    Friend WithEvents in_faktur As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_tgl As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_supplier As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents in_supplier_n As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_hutang_awal As System.Windows.Forms.TextBox
    Friend WithEvents in_term As System.Windows.Forms.NumericUpDown
    Friend WithEvents in_tgl_term As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents in_total As System.Windows.Forms.TextBox
    Friend WithEvents in_sisa As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents in_tgllunas As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents bt_bayar As System.Windows.Forms.Button
    Friend WithEvents dgv_hutang As System.Windows.Forms.DataGridView
    Friend WithEvents ket As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tgl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hutang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bayar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
