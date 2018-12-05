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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_jurnal_u_det))
        Me.bt_batalperkiraan = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.dgv_kas = New System.Windows.Forms.DataGridView()
        Me.kas_idx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kas_rek = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kas_rek_n = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kas_debet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kas_kredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kas_ket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_faktur = New System.Windows.Forms.TextBox()
        Me.in_kredit_tot = New System.Windows.Forms.TextBox()
        Me.in_debet_tot = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.in_tgl = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_kode = New System.Windows.Forms.TextBox()
        Me.txtRegAlias = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtUpdDate = New System.Windows.Forms.TextBox()
        Me.txtUpdAlias = New System.Windows.Forms.TextBox()
        Me.txtRegdate = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.in_faktur_type = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.in_ref_type = New System.Windows.Forms.TextBox()
        Me.in_ref = New System.Windows.Forms.TextBox()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_kas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_content.SuspendLayout()
        Me.SuspendLayout()
        '
        'bt_batalperkiraan
        '
        Me.bt_batalperkiraan.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalperkiraan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalperkiraan.Location = New System.Drawing.Point(672, 356)
        Me.bt_batalperkiraan.Name = "bt_batalperkiraan"
        Me.bt_batalperkiraan.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalperkiraan.TabIndex = 14
        Me.bt_batalperkiraan.Text = "OK"
        Me.bt_batalperkiraan.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 440)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(779, 10)
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
        Me.Panel1.Size = New System.Drawing.Size(779, 42)
        Me.Panel1.TabIndex = 7
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(699, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(752, 9)
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
        Me.lbl_title.Size = New System.Drawing.Size(229, 31)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Detail Jurnal Umum"
        '
        'dgv_kas
        '
        Me.dgv_kas.AllowUserToAddRows = False
        Me.dgv_kas.AllowUserToDeleteRows = False
        Me.dgv_kas.BackgroundColor = System.Drawing.Color.White
        Me.dgv_kas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_kas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.kas_idx, Me.kas_rek, Me.kas_rek_n, Me.kas_debet, Me.kas_kredit, Me.kas_ket})
        Me.dgv_kas.Location = New System.Drawing.Point(12, 105)
        Me.dgv_kas.Name = "dgv_kas"
        Me.dgv_kas.ReadOnly = True
        Me.dgv_kas.RowHeadersVisible = False
        Me.dgv_kas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_kas.Size = New System.Drawing.Size(756, 189)
        Me.dgv_kas.TabIndex = 7
        '
        'kas_idx
        '
        Me.kas_idx.DataPropertyName = "ju_akun_idx"
        Me.kas_idx.HeaderText = "No."
        Me.kas_idx.Name = "kas_idx"
        Me.kas_idx.ReadOnly = True
        Me.kas_idx.Visible = False
        Me.kas_idx.Width = 35
        '
        'kas_rek
        '
        Me.kas_rek.DataPropertyName = "ju_akun"
        Me.kas_rek.HeaderText = "No. Rek"
        Me.kas_rek.Name = "kas_rek"
        Me.kas_rek.ReadOnly = True
        '
        'kas_rek_n
        '
        Me.kas_rek_n.DataPropertyName = "ju_akun_n"
        Me.kas_rek_n.HeaderText = "Nama Perkiraan"
        Me.kas_rek_n.Name = "kas_rek_n"
        Me.kas_rek_n.ReadOnly = True
        Me.kas_rek_n.Width = 180
        '
        'kas_debet
        '
        Me.kas_debet.DataPropertyName = "ju_debet"
        Me.kas_debet.HeaderText = "Debet"
        Me.kas_debet.Name = "kas_debet"
        Me.kas_debet.ReadOnly = True
        Me.kas_debet.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.kas_debet.Width = 130
        '
        'kas_kredit
        '
        Me.kas_kredit.DataPropertyName = "ju_kredit"
        Me.kas_kredit.HeaderText = "Kredit"
        Me.kas_kredit.Name = "kas_kredit"
        Me.kas_kredit.ReadOnly = True
        Me.kas_kredit.Width = 130
        '
        'kas_ket
        '
        Me.kas_ket.DataPropertyName = "ju_akun_ket"
        Me.kas_ket.HeaderText = "Keterangan"
        Me.kas_ket.Name = "kas_ket"
        Me.kas_ket.ReadOnly = True
        Me.kas_ket.Width = 200
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Kode Transaksi"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Tgl"
        '
        'in_faktur
        '
        Me.in_faktur.BackColor = System.Drawing.Color.White
        Me.in_faktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_faktur.ForeColor = System.Drawing.Color.Black
        Me.in_faktur.Location = New System.Drawing.Point(191, 33)
        Me.in_faktur.MaxLength = 30
        Me.in_faktur.Name = "in_faktur"
        Me.in_faktur.ReadOnly = True
        Me.in_faktur.Size = New System.Drawing.Size(325, 20)
        Me.in_faktur.TabIndex = 3
        Me.in_faktur.TabStop = False
        '
        'in_kredit_tot
        '
        Me.in_kredit_tot.BackColor = System.Drawing.Color.White
        Me.in_kredit_tot.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kredit_tot.ForeColor = System.Drawing.Color.Black
        Me.in_kredit_tot.Location = New System.Drawing.Point(588, 300)
        Me.in_kredit_tot.MaxLength = 150
        Me.in_kredit_tot.Name = "in_kredit_tot"
        Me.in_kredit_tot.ReadOnly = True
        Me.in_kredit_tot.Size = New System.Drawing.Size(180, 25)
        Me.in_kredit_tot.TabIndex = 9
        Me.in_kredit_tot.TabStop = False
        Me.in_kredit_tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'in_debet_tot
        '
        Me.in_debet_tot.BackColor = System.Drawing.Color.White
        Me.in_debet_tot.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_debet_tot.ForeColor = System.Drawing.Color.Black
        Me.in_debet_tot.Location = New System.Drawing.Point(336, 300)
        Me.in_debet_tot.MaxLength = 150
        Me.in_debet_tot.Name = "in_debet_tot"
        Me.in_debet_tot.ReadOnly = True
        Me.in_debet_tot.Size = New System.Drawing.Size(180, 25)
        Me.in_debet_tot.TabIndex = 8
        Me.in_debet_tot.TabStop = False
        Me.in_debet_tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label10.Location = New System.Drawing.Point(533, 303)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 18)
        Me.Label10.TabIndex = 384
        Me.Label10.Text = "Kredit"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label9.Location = New System.Drawing.Point(282, 303)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 18)
        Me.Label9.TabIndex = 385
        Me.Label9.Text = "Debet"
        '
        'in_tgl
        '
        Me.in_tgl.BackColor = System.Drawing.Color.White
        Me.in_tgl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_tgl.ForeColor = System.Drawing.Color.Black
        Me.in_tgl.Location = New System.Drawing.Point(91, 10)
        Me.in_tgl.MaxLength = 30
        Me.in_tgl.Name = "in_tgl"
        Me.in_tgl.ReadOnly = True
        Me.in_tgl.Size = New System.Drawing.Size(188, 20)
        Me.in_tgl.TabIndex = 1
        Me.in_tgl.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(624, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 386
        Me.Label2.Text = "ID Sys."
        '
        'in_kode
        '
        Me.in_kode.BackColor = System.Drawing.Color.White
        Me.in_kode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_kode.ForeColor = System.Drawing.Color.Black
        Me.in_kode.Location = New System.Drawing.Point(675, 10)
        Me.in_kode.MaxLength = 30
        Me.in_kode.Name = "in_kode"
        Me.in_kode.ReadOnly = True
        Me.in_kode.Size = New System.Drawing.Size(93, 20)
        Me.in_kode.TabIndex = 0
        Me.in_kode.TabStop = False
        Me.in_kode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRegAlias
        '
        Me.txtRegAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegAlias.Location = New System.Drawing.Point(55, 344)
        Me.txtRegAlias.Name = "txtRegAlias"
        Me.txtRegAlias.ReadOnly = True
        Me.txtRegAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtRegAlias.TabIndex = 10
        Me.txtRegAlias.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(10, 348)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(39, 13)
        Me.Label27.TabIndex = 422
        Me.Label27.Text = "RegBy"
        '
        'txtUpdDate
        '
        Me.txtUpdDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdDate.Location = New System.Drawing.Point(207, 366)
        Me.txtUpdDate.Name = "txtUpdDate"
        Me.txtUpdDate.ReadOnly = True
        Me.txtUpdDate.Size = New System.Drawing.Size(289, 20)
        Me.txtUpdDate.TabIndex = 13
        Me.txtUpdDate.TabStop = False
        '
        'txtUpdAlias
        '
        Me.txtUpdAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdAlias.Location = New System.Drawing.Point(55, 366)
        Me.txtUpdAlias.Name = "txtUpdAlias"
        Me.txtUpdAlias.ReadOnly = True
        Me.txtUpdAlias.Size = New System.Drawing.Size(150, 20)
        Me.txtUpdAlias.TabIndex = 12
        Me.txtUpdAlias.TabStop = False
        '
        'txtRegdate
        '
        Me.txtRegdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegdate.Location = New System.Drawing.Point(207, 344)
        Me.txtRegdate.Name = "txtRegdate"
        Me.txtRegdate.ReadOnly = True
        Me.txtRegdate.Size = New System.Drawing.Size(289, 20)
        Me.txtRegdate.TabIndex = 11
        Me.txtRegdate.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(10, 370)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(39, 13)
        Me.Label28.TabIndex = 424
        Me.Label28.Text = "UpdBy"
        '
        'in_faktur_type
        '
        Me.in_faktur_type.BackColor = System.Drawing.Color.White
        Me.in_faktur_type.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_faktur_type.ForeColor = System.Drawing.Color.Black
        Me.in_faktur_type.Location = New System.Drawing.Point(91, 33)
        Me.in_faktur_type.MaxLength = 30
        Me.in_faktur_type.Name = "in_faktur_type"
        Me.in_faktur_type.ReadOnly = True
        Me.in_faktur_type.Size = New System.Drawing.Size(97, 20)
        Me.in_faktur_type.TabIndex = 2
        Me.in_faktur_type.TabStop = False
        Me.in_faktur_type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 426
        Me.Label1.Text = "Ref."
        '
        'in_ref_type
        '
        Me.in_ref_type.BackColor = System.Drawing.Color.White
        Me.in_ref_type.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ref_type.ForeColor = System.Drawing.Color.Black
        Me.in_ref_type.Location = New System.Drawing.Point(91, 56)
        Me.in_ref_type.MaxLength = 30
        Me.in_ref_type.Name = "in_ref_type"
        Me.in_ref_type.ReadOnly = True
        Me.in_ref_type.Size = New System.Drawing.Size(97, 20)
        Me.in_ref_type.TabIndex = 4
        Me.in_ref_type.TabStop = False
        Me.in_ref_type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'in_ref
        '
        Me.in_ref.BackColor = System.Drawing.Color.White
        Me.in_ref.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ref.ForeColor = System.Drawing.Color.Black
        Me.in_ref.Location = New System.Drawing.Point(191, 56)
        Me.in_ref.MaxLength = 30
        Me.in_ref.Name = "in_ref"
        Me.in_ref.ReadOnly = True
        Me.in_ref.Size = New System.Drawing.Size(325, 20)
        Me.in_ref.TabIndex = 5
        Me.in_ref.TabStop = False
        '
        'in_ket
        '
        Me.in_ket.BackColor = System.Drawing.Color.White
        Me.in_ket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.ForeColor = System.Drawing.Color.Black
        Me.in_ket.Location = New System.Drawing.Point(91, 79)
        Me.in_ket.MaxLength = 30
        Me.in_ket.Name = "in_ket"
        Me.in_ket.ReadOnly = True
        Me.in_ket.Size = New System.Drawing.Size(425, 20)
        Me.in_ket.TabIndex = 6
        Me.in_ket.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 426
        Me.Label3.Text = "Keterangan"
        '
        'pnl_content
        '
        Me.pnl_content.Controls.Add(Me.Label4)
        Me.pnl_content.Controls.Add(Me.Label3)
        Me.pnl_content.Controls.Add(Me.bt_batalperkiraan)
        Me.pnl_content.Controls.Add(Me.Label1)
        Me.pnl_content.Controls.Add(Me.dgv_kas)
        Me.pnl_content.Controls.Add(Me.in_ket)
        Me.pnl_content.Controls.Add(Me.in_faktur)
        Me.pnl_content.Controls.Add(Me.in_ref_type)
        Me.pnl_content.Controls.Add(Me.in_ref)
        Me.pnl_content.Controls.Add(Me.in_faktur_type)
        Me.pnl_content.Controls.Add(Me.in_tgl)
        Me.pnl_content.Controls.Add(Me.txtRegAlias)
        Me.pnl_content.Controls.Add(Me.Label5)
        Me.pnl_content.Controls.Add(Me.Label27)
        Me.pnl_content.Controls.Add(Me.Label9)
        Me.pnl_content.Controls.Add(Me.txtUpdDate)
        Me.pnl_content.Controls.Add(Me.Label10)
        Me.pnl_content.Controls.Add(Me.txtUpdAlias)
        Me.pnl_content.Controls.Add(Me.in_debet_tot)
        Me.pnl_content.Controls.Add(Me.txtRegdate)
        Me.pnl_content.Controls.Add(Me.in_kredit_tot)
        Me.pnl_content.Controls.Add(Me.Label28)
        Me.pnl_content.Controls.Add(Me.in_kode)
        Me.pnl_content.Controls.Add(Me.Label2)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_content.Location = New System.Drawing.Point(0, 42)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(779, 398)
        Me.pnl_content.TabIndex = 427
        '
        'fr_jurnal_u_det
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.bt_batalperkiraan
        Me.ClientSize = New System.Drawing.Size(779, 450)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_jurnal_u_det"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Jurnal Umum : "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv_kas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bt_batalperkiraan As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents dgv_kas As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_faktur As System.Windows.Forms.TextBox
    Friend WithEvents in_kredit_tot As System.Windows.Forms.TextBox
    Friend WithEvents in_debet_tot As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents in_tgl As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_kode As System.Windows.Forms.TextBox
    Friend WithEvents txtRegAlias As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtUpdDate As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtRegdate As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents in_faktur_type As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents in_ref_type As System.Windows.Forms.TextBox
    Friend WithEvents in_ref As System.Windows.Forms.TextBox
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents kas_idx As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kas_rek As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kas_rek_n As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kas_debet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kas_kredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kas_ket As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
End Class
