<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_data_referensi
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
        Me.pnl_fl_container = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnl_areacusto = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_faktur = New System.Windows.Forms.TextBox()
        Me.dgv_listarea = New System.Windows.Forms.DataGridView()
        Me.bt_tbbarang = New System.Windows.Forms.Button()
        Me.cb_area = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.in_area_n = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.pnl_satbrg = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.dgv_listsat = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_judul = New System.Windows.Forms.Label()
        Me.pnl_fl_container.SuspendLayout()
        Me.pnl_areacusto.SuspendLayout()
        CType(Me.dgv_listarea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_satbrg.SuspendLayout()
        CType(Me.dgv_listsat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_fl_container
        '
        Me.pnl_fl_container.AutoScroll = True
        Me.pnl_fl_container.Controls.Add(Me.pnl_areacusto)
        Me.pnl_fl_container.Controls.Add(Me.pnl_satbrg)
        Me.pnl_fl_container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_fl_container.Location = New System.Drawing.Point(0, 66)
        Me.pnl_fl_container.Name = "pnl_fl_container"
        Me.pnl_fl_container.Size = New System.Drawing.Size(959, 487)
        Me.pnl_fl_container.TabIndex = 1
        '
        'pnl_areacusto
        '
        Me.pnl_areacusto.AutoScroll = True
        Me.pnl_areacusto.Controls.Add(Me.Label5)
        Me.pnl_areacusto.Controls.Add(Me.in_faktur)
        Me.pnl_areacusto.Controls.Add(Me.dgv_listarea)
        Me.pnl_areacusto.Controls.Add(Me.bt_tbbarang)
        Me.pnl_areacusto.Controls.Add(Me.cb_area)
        Me.pnl_areacusto.Controls.Add(Me.Label1)
        Me.pnl_areacusto.Controls.Add(Me.Label7)
        Me.pnl_areacusto.Controls.Add(Me.in_area_n)
        Me.pnl_areacusto.Controls.Add(Me.Label16)
        Me.pnl_areacusto.Location = New System.Drawing.Point(3, 3)
        Me.pnl_areacusto.Name = "pnl_areacusto"
        Me.pnl_areacusto.Size = New System.Drawing.Size(460, 520)
        Me.pnl_areacusto.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 13)
        Me.Label5.TabIndex = 385
        Me.Label5.Text = "ID"
        '
        'in_faktur
        '
        Me.in_faktur.BackColor = System.Drawing.Color.White
        Me.in_faktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_faktur.ForeColor = System.Drawing.Color.Black
        Me.in_faktur.Location = New System.Drawing.Point(71, 34)
        Me.in_faktur.MaxLength = 10
        Me.in_faktur.Name = "in_faktur"
        Me.in_faktur.ReadOnly = True
        Me.in_faktur.Size = New System.Drawing.Size(102, 20)
        Me.in_faktur.TabIndex = 384
        Me.in_faktur.TabStop = False
        '
        'dgv_listarea
        '
        Me.dgv_listarea.AllowUserToAddRows = False
        Me.dgv_listarea.AllowUserToDeleteRows = False
        Me.dgv_listarea.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv_listarea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listarea.Location = New System.Drawing.Point(11, 101)
        Me.dgv_listarea.MultiSelect = False
        Me.dgv_listarea.Name = "dgv_listarea"
        Me.dgv_listarea.ReadOnly = True
        Me.dgv_listarea.RowHeadersVisible = False
        Me.dgv_listarea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listarea.Size = New System.Drawing.Size(438, 415)
        Me.dgv_listarea.TabIndex = 383
        '
        'bt_tbbarang
        '
        Me.bt_tbbarang.BackColor = System.Drawing.Color.Transparent
        Me.bt_tbbarang.BackgroundImage = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.bt_tbbarang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_tbbarang.FlatAppearance.BorderSize = 0
        Me.bt_tbbarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_tbbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tbbarang.Location = New System.Drawing.Point(299, 79)
        Me.bt_tbbarang.Name = "bt_tbbarang"
        Me.bt_tbbarang.Size = New System.Drawing.Size(18, 18)
        Me.bt_tbbarang.TabIndex = 382
        Me.bt_tbbarang.UseVisualStyleBackColor = False
        '
        'cb_area
        '
        Me.cb_area.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_area.FormattingEnabled = True
        Me.cb_area.Location = New System.Drawing.Point(71, 78)
        Me.cb_area.Name = "cb_area"
        Me.cb_area.Size = New System.Drawing.Size(222, 21)
        Me.cb_area.TabIndex = 381
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 360
        Me.Label1.Text = "Kabupaten"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 359
        Me.Label7.Text = "Area"
        '
        'in_area_n
        '
        Me.in_area_n.Location = New System.Drawing.Point(71, 56)
        Me.in_area_n.Name = "in_area_n"
        Me.in_area_n.Size = New System.Drawing.Size(222, 20)
        Me.in_area_n.TabIndex = 358
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label16.Location = New System.Drawing.Point(6, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 13)
        Me.Label16.TabIndex = 357
        Me.Label16.Text = "Area Customer"
        '
        'pnl_satbrg
        '
        Me.pnl_satbrg.AutoScroll = True
        Me.pnl_satbrg.Controls.Add(Me.Label6)
        Me.pnl_satbrg.Controls.Add(Me.TextBox3)
        Me.pnl_satbrg.Controls.Add(Me.Label2)
        Me.pnl_satbrg.Controls.Add(Me.TextBox2)
        Me.pnl_satbrg.Controls.Add(Me.dgv_listsat)
        Me.pnl_satbrg.Controls.Add(Me.Button1)
        Me.pnl_satbrg.Controls.Add(Me.Label3)
        Me.pnl_satbrg.Controls.Add(Me.TextBox1)
        Me.pnl_satbrg.Controls.Add(Me.Label4)
        Me.pnl_satbrg.Location = New System.Drawing.Point(469, 3)
        Me.pnl_satbrg.Name = "pnl_satbrg"
        Me.pnl_satbrg.Size = New System.Drawing.Size(460, 520)
        Me.pnl_satbrg.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 387
        Me.Label6.Text = "Kode"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(74, 34)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(97, 20)
        Me.TextBox3.TabIndex = 386
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 385
        Me.Label2.Text = "Keterangan"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(74, 78)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(219, 20)
        Me.TextBox2.TabIndex = 384
        '
        'dgv_listsat
        '
        Me.dgv_listsat.AllowUserToAddRows = False
        Me.dgv_listsat.AllowUserToDeleteRows = False
        Me.dgv_listsat.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv_listsat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listsat.Location = New System.Drawing.Point(11, 102)
        Me.dgv_listsat.MultiSelect = False
        Me.dgv_listsat.Name = "dgv_listsat"
        Me.dgv_listsat.ReadOnly = True
        Me.dgv_listsat.RowHeadersVisible = False
        Me.dgv_listsat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listsat.Size = New System.Drawing.Size(438, 415)
        Me.dgv_listsat.TabIndex = 383
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(299, 78)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(18, 18)
        Me.Button1.TabIndex = 382
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 359
        Me.Label3.Text = "Satuan"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(74, 56)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(132, 20)
        Me.TextBox1.TabIndex = 358
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(6, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 357
        Me.Label4.Text = "Satuan Barang"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 42)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(959, 24)
        Me.MenuStrip1.TabIndex = 343
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Controls.Add(Me.lbl_close)
        Me.Panel2.Controls.Add(Me.bt_cl)
        Me.Panel2.Controls.Add(Me.lbl_judul)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(959, 42)
        Me.Panel2.TabIndex = 342
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(879, 8)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(52, 22)
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
        Me.bt_cl.Location = New System.Drawing.Point(932, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 8
        Me.bt_cl.TabStop = False
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_judul
        '
        Me.lbl_judul.AutoSize = True
        Me.lbl_judul.BackColor = System.Drawing.Color.Orange
        Me.lbl_judul.Font = New System.Drawing.Font("Open Sans", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_judul.ForeColor = System.Drawing.Color.White
        Me.lbl_judul.Location = New System.Drawing.Point(6, 3)
        Me.lbl_judul.Name = "lbl_judul"
        Me.lbl_judul.Size = New System.Drawing.Size(177, 33)
        Me.lbl_judul.TabIndex = 136
        Me.lbl_judul.Text = "List Referensi"
        '
        'fr_data_referensi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnl_fl_container)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "fr_data_referensi"
        Me.Size = New System.Drawing.Size(959, 553)
        Me.pnl_fl_container.ResumeLayout(False)
        Me.pnl_areacusto.ResumeLayout(False)
        Me.pnl_areacusto.PerformLayout()
        CType(Me.dgv_listarea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_satbrg.ResumeLayout(False)
        Me.pnl_satbrg.PerformLayout()
        CType(Me.dgv_listsat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnl_fl_container As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnl_areacusto As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents in_area_n As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cb_area As System.Windows.Forms.ComboBox
    Friend WithEvents bt_tbbarang As System.Windows.Forms.Button
    Friend WithEvents dgv_listarea As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents in_faktur As System.Windows.Forms.TextBox
    Friend WithEvents pnl_satbrg As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents dgv_listsat As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_judul As System.Windows.Forms.Label

End Class
