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
        Me.pnl_listref = New System.Windows.Forms.Panel()
        Me.pnl_fl_container = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnl_areacusto = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.in_area_n = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_area = New System.Windows.Forms.ComboBox()
        Me.bt_tbbarang = New System.Windows.Forms.Button()
        Me.dgv_listarea = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.in_faktur = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.pnl_fl_container.SuspendLayout()
        Me.pnl_areacusto.SuspendLayout()
        CType(Me.dgv_listarea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl_listref
        '
        Me.pnl_listref.AutoScroll = True
        Me.pnl_listref.BackColor = System.Drawing.Color.Orange
        Me.pnl_listref.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnl_listref.Location = New System.Drawing.Point(0, 0)
        Me.pnl_listref.Name = "pnl_listref"
        Me.pnl_listref.Size = New System.Drawing.Size(200, 553)
        Me.pnl_listref.TabIndex = 0
        '
        'pnl_fl_container
        '
        Me.pnl_fl_container.AutoScroll = True
        Me.pnl_fl_container.Controls.Add(Me.pnl_areacusto)
        Me.pnl_fl_container.Controls.Add(Me.Panel1)
        Me.pnl_fl_container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_fl_container.Location = New System.Drawing.Point(200, 0)
        Me.pnl_fl_container.Name = "pnl_fl_container"
        Me.pnl_fl_container.Size = New System.Drawing.Size(759, 553)
        Me.pnl_fl_container.TabIndex = 1
        '
        'pnl_areacusto
        '
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
        Me.pnl_areacusto.Size = New System.Drawing.Size(735, 283)
        Me.pnl_areacusto.TabIndex = 0
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
        'in_area_n
        '
        Me.in_area_n.Location = New System.Drawing.Point(173, 34)
        Me.in_area_n.Name = "in_area_n"
        Me.in_area_n.Size = New System.Drawing.Size(222, 20)
        Me.in_area_n.TabIndex = 358
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(138, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 359
        Me.Label7.Text = "Area"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(401, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 360
        Me.Label1.Text = "Kabupaten"
        '
        'cb_area
        '
        Me.cb_area.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_area.FormattingEnabled = True
        Me.cb_area.Location = New System.Drawing.Point(466, 34)
        Me.cb_area.Name = "cb_area"
        Me.cb_area.Size = New System.Drawing.Size(200, 21)
        Me.cb_area.TabIndex = 381
        '
        'bt_tbbarang
        '
        Me.bt_tbbarang.BackColor = System.Drawing.Color.Transparent
        Me.bt_tbbarang.BackgroundImage = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.bt_tbbarang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bt_tbbarang.FlatAppearance.BorderSize = 0
        Me.bt_tbbarang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_tbbarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_tbbarang.Location = New System.Drawing.Point(672, 35)
        Me.bt_tbbarang.Name = "bt_tbbarang"
        Me.bt_tbbarang.Size = New System.Drawing.Size(18, 18)
        Me.bt_tbbarang.TabIndex = 382
        Me.bt_tbbarang.UseVisualStyleBackColor = False
        '
        'dgv_listarea
        '
        Me.dgv_listarea.AllowUserToAddRows = False
        Me.dgv_listarea.AllowUserToDeleteRows = False
        Me.dgv_listarea.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv_listarea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_listarea.Location = New System.Drawing.Point(9, 58)
        Me.dgv_listarea.MultiSelect = False
        Me.dgv_listarea.Name = "dgv_listarea"
        Me.dgv_listarea.ReadOnly = True
        Me.dgv_listarea.RowHeadersVisible = False
        Me.dgv_listarea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_listarea.Size = New System.Drawing.Size(717, 217)
        Me.dgv_listarea.TabIndex = 383
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
        Me.in_faktur.Location = New System.Drawing.Point(30, 34)
        Me.in_faktur.MaxLength = 10
        Me.in_faktur.Name = "in_faktur"
        Me.in_faktur.ReadOnly = True
        Me.in_faktur.Size = New System.Drawing.Size(102, 20)
        Me.in_faktur.TabIndex = 384
        Me.in_faktur.TabStop = False
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
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(194, 33)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(132, 20)
        Me.TextBox1.TabIndex = 358
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(147, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 359
        Me.Label3.Text = "Satuan"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(625, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(18, 18)
        Me.Button1.TabIndex = 382
        Me.Button1.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(9, 60)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(717, 217)
        Me.DataGridView1.TabIndex = 383
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(400, 33)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(219, 20)
        Me.TextBox2.TabIndex = 384
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(332, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 385
        Me.Label2.Text = "Keterangan"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(3, 292)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(735, 290)
        Me.Panel1.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 387
        Me.Label6.Text = "Kode"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(44, 32)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(97, 20)
        Me.TextBox3.TabIndex = 386
        '
        'fr_data_referensi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnl_fl_container)
        Me.Controls.Add(Me.pnl_listref)
        Me.Name = "fr_data_referensi"
        Me.Size = New System.Drawing.Size(959, 553)
        Me.pnl_fl_container.ResumeLayout(False)
        Me.pnl_areacusto.ResumeLayout(False)
        Me.pnl_areacusto.PerformLayout()
        CType(Me.dgv_listarea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_listref As System.Windows.Forms.Panel
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
