<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_jurnal_u_det
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
        Me.bt_batalperkiraan = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.dgv_kas = New System.Windows.Forms.DataGridView()
        Me.kas_rek = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kas_rek_n = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kas_debet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kas_kredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kas_ket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_no_bukti = New System.Windows.Forms.TextBox()
        Me.in_kredit_tot = New System.Windows.Forms.TextBox()
        Me.in_debet_tot = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_total = New System.Windows.Forms.TextBox()
        Me.in_tgl = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_kas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bt_batalperkiraan
        '
        Me.bt_batalperkiraan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_batalperkiraan.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalperkiraan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalperkiraan.Location = New System.Drawing.Point(667, 442)
        Me.bt_batalperkiraan.Name = "bt_batalperkiraan"
        Me.bt_batalperkiraan.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalperkiraan.TabIndex = 6
        Me.bt_batalperkiraan.Text = "OK"
        Me.bt_batalperkiraan.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 478)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(775, 10)
        Me.Panel2.TabIndex = 7
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
        Me.Panel1.Size = New System.Drawing.Size(775, 42)
        Me.Panel1.TabIndex = 7
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(695, 9)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(47, 20)
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
        Me.bt_cl.Location = New System.Drawing.Point(748, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 7
        Me.bt_cl.TabStop = False
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
        Me.lbl_title.Size = New System.Drawing.Size(228, 30)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Detail Jurnal Umum"
        '
        'dgv_kas
        '
        Me.dgv_kas.AllowUserToAddRows = False
        Me.dgv_kas.AllowUserToDeleteRows = False
        Me.dgv_kas.BackgroundColor = System.Drawing.Color.White
        Me.dgv_kas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_kas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kas_rek, Me.kas_rek_n, Me.kas_debet, Me.kas_kredit, Me.kas_ket})
        Me.dgv_kas.Location = New System.Drawing.Point(11, 102)
        Me.dgv_kas.Name = "dgv_kas"
        Me.dgv_kas.ReadOnly = True
        Me.dgv_kas.RowHeadersVisible = False
        Me.dgv_kas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_kas.Size = New System.Drawing.Size(753, 294)
        Me.dgv_kas.TabIndex = 2
        '
        'kas_rek
        '
        Me.kas_rek.DataPropertyName = "trans_rek"
        Me.kas_rek.HeaderText = "No. Rek"
        Me.kas_rek.MinimumWidth = 75
        Me.kas_rek.Name = "kas_rek"
        Me.kas_rek.ReadOnly = True
        '
        'kas_rek_n
        '
        Me.kas_rek_n.DataPropertyName = "rek_nama"
        Me.kas_rek_n.HeaderText = "Nama Perkiraan"
        Me.kas_rek_n.MinimumWidth = 100
        Me.kas_rek_n.Name = "kas_rek_n"
        Me.kas_rek_n.ReadOnly = True
        Me.kas_rek_n.Width = 180
        '
        'kas_debet
        '
        Me.kas_debet.DataPropertyName = "trans_debet"
        Me.kas_debet.HeaderText = "Debet"
        Me.kas_debet.MinimumWidth = 125
        Me.kas_debet.Name = "kas_debet"
        Me.kas_debet.ReadOnly = True
        Me.kas_debet.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.kas_debet.Width = 130
        '
        'kas_kredit
        '
        Me.kas_kredit.DataPropertyName = "trans_kredit"
        Me.kas_kredit.HeaderText = "Kredit"
        Me.kas_kredit.MinimumWidth = 125
        Me.kas_kredit.Name = "kas_kredit"
        Me.kas_kredit.ReadOnly = True
        Me.kas_kredit.Width = 130
        '
        'kas_ket
        '
        Me.kas_ket.DataPropertyName = "trans_Ket"
        Me.kas_ket.HeaderText = "Keterangan"
        Me.kas_ket.MinimumWidth = 100
        Me.kas_ket.Name = "kas_ket"
        Me.kas_ket.ReadOnly = True
        Me.kas_ket.Width = 180
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "No. Bukti"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Tgl"
        '
        'in_no_bukti
        '
        Me.in_no_bukti.BackColor = System.Drawing.Color.White
        Me.in_no_bukti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_no_bukti.ForeColor = System.Drawing.Color.Black
        Me.in_no_bukti.Location = New System.Drawing.Point(67, 53)
        Me.in_no_bukti.MaxLength = 30
        Me.in_no_bukti.Name = "in_no_bukti"
        Me.in_no_bukti.ReadOnly = True
        Me.in_no_bukti.Size = New System.Drawing.Size(188, 20)
        Me.in_no_bukti.TabIndex = 0
        Me.in_no_bukti.TabStop = False
        '
        'in_kredit_tot
        '
        Me.in_kredit_tot.BackColor = System.Drawing.Color.White
        Me.in_kredit_tot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kredit_tot.ForeColor = System.Drawing.Color.Black
        Me.in_kredit_tot.Location = New System.Drawing.Point(197, 416)
        Me.in_kredit_tot.MaxLength = 150
        Me.in_kredit_tot.Name = "in_kredit_tot"
        Me.in_kredit_tot.ReadOnly = True
        Me.in_kredit_tot.Size = New System.Drawing.Size(180, 20)
        Me.in_kredit_tot.TabIndex = 4
        Me.in_kredit_tot.TabStop = False
        '
        'in_debet_tot
        '
        Me.in_debet_tot.BackColor = System.Drawing.Color.White
        Me.in_debet_tot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_debet_tot.ForeColor = System.Drawing.Color.Black
        Me.in_debet_tot.Location = New System.Drawing.Point(11, 416)
        Me.in_debet_tot.MaxLength = 150
        Me.in_debet_tot.Name = "in_debet_tot"
        Me.in_debet_tot.ReadOnly = True
        Me.in_debet_tot.Size = New System.Drawing.Size(180, 20)
        Me.in_debet_tot.TabIndex = 3
        Me.in_debet_tot.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label10.Location = New System.Drawing.Point(194, 400)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 384
        Me.Label10.Text = "Kredit"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(8, 400)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 385
        Me.Label9.Text = "Debet"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(381, 400)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 384
        Me.Label1.Text = "Total"
        '
        'in_total
        '
        Me.in_total.BackColor = System.Drawing.Color.White
        Me.in_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_total.ForeColor = System.Drawing.Color.Black
        Me.in_total.Location = New System.Drawing.Point(384, 416)
        Me.in_total.MaxLength = 150
        Me.in_total.Name = "in_total"
        Me.in_total.ReadOnly = True
        Me.in_total.Size = New System.Drawing.Size(180, 20)
        Me.in_total.TabIndex = 5
        Me.in_total.TabStop = False
        '
        'in_tgl
        '
        Me.in_tgl.BackColor = System.Drawing.Color.White
        Me.in_tgl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_tgl.ForeColor = System.Drawing.Color.Black
        Me.in_tgl.Location = New System.Drawing.Point(67, 77)
        Me.in_tgl.MaxLength = 30
        Me.in_tgl.Name = "in_tgl"
        Me.in_tgl.ReadOnly = True
        Me.in_tgl.Size = New System.Drawing.Size(188, 20)
        Me.in_tgl.TabIndex = 1
        Me.in_tgl.TabStop = False
        '
        'fr_jurnal_u_det
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.bt_batalperkiraan
        Me.ClientSize = New System.Drawing.Size(775, 488)
        Me.Controls.Add(Me.in_total)
        Me.Controls.Add(Me.in_kredit_tot)
        Me.Controls.Add(Me.in_debet_tot)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.in_tgl)
        Me.Controls.Add(Me.in_no_bukti)
        Me.Controls.Add(Me.dgv_kas)
        Me.Controls.Add(Me.bt_batalperkiraan)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "fr_jurnal_u_det"
        Me.Text = "fr_jurnal_u_det"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv_kas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_batalperkiraan As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents dgv_kas As System.Windows.Forms.DataGridView
    Friend WithEvents kas_rek As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kas_rek_n As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kas_debet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kas_kredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kas_ket As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_no_bukti As System.Windows.Forms.TextBox
    Friend WithEvents in_kredit_tot As System.Windows.Forms.TextBox
    Friend WithEvents in_debet_tot As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_total As System.Windows.Forms.TextBox
    Friend WithEvents in_tgl As System.Windows.Forms.TextBox
End Class
