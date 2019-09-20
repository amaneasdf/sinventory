<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_newexport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_newexport))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.popPnl_barang = New System.Windows.Forms.Panel()
        Me.dgv_listbarang = New System.Windows.Forms.DataGridView()
        Me.linkLbl_searchbarang = New System.Windows.Forms.LinkLabel()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_supplier = New System.Windows.Forms.Label()
        Me.in_supplier = New System.Windows.Forms.TextBox()
        Me.in_suppliernama = New System.Windows.Forms.TextBox()
        Me.bt_cancel = New System.Windows.Forms.Button()
        Me.bt_load = New System.Windows.Forms.Button()
        Me.date_tglawal = New System.Windows.Forms.DateTimePicker()
        Me.date_tglakhir = New System.Windows.Forms.DateTimePicker()
        Me.lbl_date = New System.Windows.Forms.Label()
        Me.ck_inputfaktur = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.date_periode = New System.Windows.Forms.DateTimePicker()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.popPnl_barang.SuspendLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.lbl_title)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(456, 34)
        Me.Panel1.TabIndex = 2
        '
        'bt_cl
        '
        Me.bt_cl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_cl.BackColor = System.Drawing.Color.Transparent
        Me.bt_cl.BackgroundImage = Global.Inventory.My.Resources.Resources.close
        Me.bt_cl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_cl.FlatAppearance.BorderSize = 0
        Me.bt_cl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange
        Me.bt_cl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange
        Me.bt_cl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cl.Location = New System.Drawing.Point(430, 6)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 0
        Me.bt_cl.TabStop = False
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Orange
        Me.lbl_title.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(5, 6)
        Me.lbl_title.MaximumSize = New System.Drawing.Size(490, 33)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(134, 22)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Export E-Faktur"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.popPnl_barang)
        Me.Panel2.Controls.Add(Me.in_ket)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.lbl_supplier)
        Me.Panel2.Controls.Add(Me.in_supplier)
        Me.Panel2.Controls.Add(Me.in_suppliernama)
        Me.Panel2.Controls.Add(Me.bt_cancel)
        Me.Panel2.Controls.Add(Me.bt_load)
        Me.Panel2.Controls.Add(Me.date_tglawal)
        Me.Panel2.Controls.Add(Me.date_tglakhir)
        Me.Panel2.Controls.Add(Me.lbl_date)
        Me.Panel2.Controls.Add(Me.ck_inputfaktur)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.date_periode)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(456, 199)
        Me.Panel2.TabIndex = 3
        '
        'popPnl_barang
        '
        Me.popPnl_barang.Controls.Add(Me.dgv_listbarang)
        Me.popPnl_barang.Controls.Add(Me.linkLbl_searchbarang)
        Me.popPnl_barang.Location = New System.Drawing.Point(430, 61)
        Me.popPnl_barang.Name = "popPnl_barang"
        Me.popPnl_barang.Size = New System.Drawing.Size(349, 77)
        Me.popPnl_barang.TabIndex = 494
        Me.popPnl_barang.Visible = False
        '
        'dgv_listbarang
        '
        Me.dgv_listbarang.AllowUserToAddRows = False
        Me.dgv_listbarang.AllowUserToDeleteRows = False
        Me.dgv_listbarang.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv_listbarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listbarang.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgv_listbarang.Location = New System.Drawing.Point(0, 0)
        Me.dgv_listbarang.MultiSelect = False
        Me.dgv_listbarang.Name = "dgv_listbarang"
        Me.dgv_listbarang.ReadOnly = True
        Me.dgv_listbarang.RowHeadersVisible = False
        Me.dgv_listbarang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listbarang.Size = New System.Drawing.Size(349, 74)
        Me.dgv_listbarang.TabIndex = 0
        '
        'linkLbl_searchbarang
        '
        Me.linkLbl_searchbarang.AutoSize = True
        Me.linkLbl_searchbarang.LinkColor = System.Drawing.Color.DimGray
        Me.linkLbl_searchbarang.Location = New System.Drawing.Point(3, 114)
        Me.linkLbl_searchbarang.Name = "linkLbl_searchbarang"
        Me.linkLbl_searchbarang.Size = New System.Drawing.Size(124, 15)
        Me.linkLbl_searchbarang.TabIndex = 1
        Me.linkLbl_searchbarang.TabStop = True
        Me.linkLbl_searchbarang.Text = "Tampilkan Pencarian..."
        Me.linkLbl_searchbarang.VisitedLinkColor = System.Drawing.Color.DimGray
        '
        'in_ket
        '
        Me.in_ket.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.Location = New System.Drawing.Point(96, 87)
        Me.in_ket.Multiline = True
        Me.in_ket.Name = "in_ket"
        Me.in_ket.Size = New System.Drawing.Size(348, 67)
        Me.in_ket.TabIndex = 498
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 15)
        Me.Label7.TabIndex = 499
        Me.Label7.Text = "Keterangan"
        '
        'lbl_supplier
        '
        Me.lbl_supplier.AutoSize = True
        Me.lbl_supplier.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_supplier.Location = New System.Drawing.Point(12, 36)
        Me.lbl_supplier.Name = "lbl_supplier"
        Me.lbl_supplier.Size = New System.Drawing.Size(50, 15)
        Me.lbl_supplier.TabIndex = 497
        Me.lbl_supplier.Text = "Supplier"
        '
        'in_supplier
        '
        Me.in_supplier.BackColor = System.Drawing.Color.Gainsboro
        Me.in_supplier.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_supplier.Location = New System.Drawing.Point(96, 33)
        Me.in_supplier.MaxLength = 10
        Me.in_supplier.Name = "in_supplier"
        Me.in_supplier.Size = New System.Drawing.Size(87, 22)
        Me.in_supplier.TabIndex = 495
        '
        'in_suppliernama
        '
        Me.in_suppliernama.BackColor = System.Drawing.Color.White
        Me.in_suppliernama.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_suppliernama.Location = New System.Drawing.Point(183, 33)
        Me.in_suppliernama.MaxLength = 10
        Me.in_suppliernama.Name = "in_suppliernama"
        Me.in_suppliernama.Size = New System.Drawing.Size(262, 22)
        Me.in_suppliernama.TabIndex = 496
        '
        'bt_cancel
        '
        Me.bt_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cancel.Image = Global.Inventory.My.Resources.Resources.Delete_16x16
        Me.bt_cancel.Location = New System.Drawing.Point(358, 160)
        Me.bt_cancel.Name = "bt_cancel"
        Me.bt_cancel.Size = New System.Drawing.Size(87, 30)
        Me.bt_cancel.TabIndex = 49
        Me.bt_cancel.Text = "Batal"
        Me.bt_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_cancel.UseVisualStyleBackColor = True
        '
        'bt_load
        '
        Me.bt_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_load.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_load.Image = Global.Inventory.My.Resources.Resources.Add_16x16
        Me.bt_load.Location = New System.Drawing.Point(241, 160)
        Me.bt_load.Name = "bt_load"
        Me.bt_load.Size = New System.Drawing.Size(111, 30)
        Me.bt_load.TabIndex = 50
        Me.bt_load.Text = "Tampilkan"
        Me.bt_load.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_load.UseVisualStyleBackColor = True
        '
        'date_tglawal
        '
        Me.date_tglawal.Enabled = False
        Me.date_tglawal.Location = New System.Drawing.Point(138, 59)
        Me.date_tglawal.Name = "date_tglawal"
        Me.date_tglawal.Size = New System.Drawing.Size(136, 22)
        Me.date_tglawal.TabIndex = 45
        '
        'date_tglakhir
        '
        Me.date_tglakhir.Enabled = False
        Me.date_tglakhir.Location = New System.Drawing.Point(309, 59)
        Me.date_tglakhir.Name = "date_tglakhir"
        Me.date_tglakhir.Size = New System.Drawing.Size(136, 22)
        Me.date_tglakhir.TabIndex = 46
        '
        'lbl_date
        '
        Me.lbl_date.AutoSize = True
        Me.lbl_date.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_date.ForeColor = System.Drawing.Color.Black
        Me.lbl_date.Location = New System.Drawing.Point(280, 63)
        Me.lbl_date.Name = "lbl_date"
        Me.lbl_date.Size = New System.Drawing.Size(23, 15)
        Me.lbl_date.TabIndex = 48
        Me.lbl_date.Text = "S.d"
        '
        'ck_inputfaktur
        '
        Me.ck_inputfaktur.AutoSize = True
        Me.ck_inputfaktur.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_inputfaktur.Location = New System.Drawing.Point(15, 61)
        Me.ck_inputfaktur.Name = "ck_inputfaktur"
        Me.ck_inputfaktur.Size = New System.Drawing.Size(114, 19)
        Me.ck_inputfaktur.TabIndex = 47
        Me.ck_inputfaktur.Text = "Faktur Penjualan"
        Me.ck_inputfaktur.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 15)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Periode Pajak"
        '
        'date_periode
        '
        Me.date_periode.CustomFormat = "MMMM yyyy"
        Me.date_periode.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.date_periode.Location = New System.Drawing.Point(96, 8)
        Me.date_periode.Name = "date_periode"
        Me.date_periode.Size = New System.Drawing.Size(171, 22)
        Me.date_periode.TabIndex = 43
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 233)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(456, 10)
        Me.Panel3.TabIndex = 4
        '
        'fr_newexport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 243)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fr_newexport"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.popPnl_barang.ResumeLayout(False)
        Me.popPnl_barang.PerformLayout()
        CType(Me.dgv_listbarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents date_periode As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_tglawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_tglakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_date As System.Windows.Forms.Label
    Friend WithEvents ck_inputfaktur As System.Windows.Forms.CheckBox
    Friend WithEvents bt_cancel As System.Windows.Forms.Button
    Friend WithEvents bt_load As System.Windows.Forms.Button
    Friend WithEvents popPnl_barang As System.Windows.Forms.Panel
    Friend WithEvents dgv_listbarang As System.Windows.Forms.DataGridView
    Friend WithEvents linkLbl_searchbarang As System.Windows.Forms.LinkLabel
    Friend WithEvents lbl_supplier As System.Windows.Forms.Label
    Friend WithEvents in_supplier As System.Windows.Forms.TextBox
    Friend WithEvents in_suppliernama As System.Windows.Forms.TextBox
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
End Class
