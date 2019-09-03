<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_closing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_closing))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.date_tglawal = New System.Windows.Forms.DateTimePicker()
        Me.lbl_user1 = New System.Windows.Forms.Label()
        Me.lbl_closeDate = New System.Windows.Forms.Label()
        Me.lbl_user2 = New System.Windows.Forms.Label()
        Me.lbl_status = New System.Windows.Forms.Label()
        Me.ck_list = New System.Windows.Forms.CheckBox()
        Me.bt_load = New System.Windows.Forms.Button()
        Me.ck_range = New System.Windows.Forms.CheckBox()
        Me.date_tglakhir = New System.Windows.Forms.DateTimePicker()
        Me.ck_confirm = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bt_cancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(425, 412)
        Me.Panel2.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(12, 251)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(384, 199)
        Me.GroupBox2.TabIndex = 59
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Laporan Keuangan"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.date_tglawal)
        Me.GroupBox1.Controls.Add(Me.lbl_user1)
        Me.GroupBox1.Controls.Add(Me.lbl_closeDate)
        Me.GroupBox1.Controls.Add(Me.lbl_user2)
        Me.GroupBox1.Controls.Add(Me.lbl_status)
        Me.GroupBox1.Controls.Add(Me.ck_list)
        Me.GroupBox1.Controls.Add(Me.bt_load)
        Me.GroupBox1.Controls.Add(Me.ck_range)
        Me.GroupBox1.Controls.Add(Me.date_tglakhir)
        Me.GroupBox1.Controls.Add(Me.ck_confirm)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(384, 229)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periode"
        '
        'date_tglawal
        '
        Me.date_tglawal.Enabled = False
        Me.date_tglawal.Location = New System.Drawing.Point(9, 21)
        Me.date_tglawal.Name = "date_tglawal"
        Me.date_tglawal.Size = New System.Drawing.Size(157, 22)
        Me.date_tglawal.TabIndex = 5
        '
        'lbl_user1
        '
        Me.lbl_user1.AutoSize = True
        Me.lbl_user1.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_user1.ForeColor = System.Drawing.Color.Black
        Me.lbl_user1.Location = New System.Drawing.Point(6, 127)
        Me.lbl_user1.Name = "lbl_user1"
        Me.lbl_user1.Size = New System.Drawing.Size(48, 15)
        Me.lbl_user1.TabIndex = 57
        Me.lbl_user1.Text = "Status : "
        '
        'lbl_closeDate
        '
        Me.lbl_closeDate.AutoSize = True
        Me.lbl_closeDate.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_closeDate.ForeColor = System.Drawing.Color.Black
        Me.lbl_closeDate.Location = New System.Drawing.Point(6, 193)
        Me.lbl_closeDate.Name = "lbl_closeDate"
        Me.lbl_closeDate.Size = New System.Drawing.Size(48, 15)
        Me.lbl_closeDate.TabIndex = 57
        Me.lbl_closeDate.Text = "Status : "
        '
        'lbl_user2
        '
        Me.lbl_user2.AutoSize = True
        Me.lbl_user2.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_user2.ForeColor = System.Drawing.Color.Black
        Me.lbl_user2.Location = New System.Drawing.Point(6, 146)
        Me.lbl_user2.Name = "lbl_user2"
        Me.lbl_user2.Size = New System.Drawing.Size(48, 15)
        Me.lbl_user2.TabIndex = 57
        Me.lbl_user2.Text = "Status : "
        '
        'lbl_status
        '
        Me.lbl_status.AutoSize = True
        Me.lbl_status.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.ForeColor = System.Drawing.Color.Black
        Me.lbl_status.Location = New System.Drawing.Point(6, 172)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(48, 15)
        Me.lbl_status.TabIndex = 57
        Me.lbl_status.Text = "Status : "
        '
        'ck_list
        '
        Me.ck_list.AutoSize = True
        Me.ck_list.Enabled = False
        Me.ck_list.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_list.Location = New System.Drawing.Point(6, 64)
        Me.ck_list.Name = "ck_list"
        Me.ck_list.Size = New System.Drawing.Size(89, 19)
        Me.ck_list.TabIndex = 0
        Me.ck_list.Text = "Kode Faktur"
        Me.ck_list.UseVisualStyleBackColor = True
        '
        'bt_load
        '
        Me.bt_load.BackColor = System.Drawing.Color.White
        Me.bt_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_load.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_load.Image = Global.Inventory.My.Resources.Resources.Add_16x16
        Me.bt_load.Location = New System.Drawing.Point(267, 193)
        Me.bt_load.Name = "bt_load"
        Me.bt_load.Size = New System.Drawing.Size(111, 30)
        Me.bt_load.TabIndex = 7
        Me.bt_load.Text = "Closing"
        Me.bt_load.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_load.UseVisualStyleBackColor = False
        '
        'ck_range
        '
        Me.ck_range.AutoSize = True
        Me.ck_range.Enabled = False
        Me.ck_range.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_range.Location = New System.Drawing.Point(6, 89)
        Me.ck_range.Name = "ck_range"
        Me.ck_range.Size = New System.Drawing.Size(117, 19)
        Me.ck_range.TabIndex = 4
        Me.ck_range.Text = "Tanggal Transaksi"
        Me.ck_range.UseVisualStyleBackColor = True
        '
        'date_tglakhir
        '
        Me.date_tglakhir.Enabled = False
        Me.date_tglakhir.Location = New System.Drawing.Point(201, 21)
        Me.date_tglakhir.Name = "date_tglakhir"
        Me.date_tglakhir.Size = New System.Drawing.Size(157, 22)
        Me.date_tglakhir.TabIndex = 6
        '
        'ck_confirm
        '
        Me.ck_confirm.AutoSize = True
        Me.ck_confirm.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_confirm.Location = New System.Drawing.Point(267, 168)
        Me.ck_confirm.Name = "ck_confirm"
        Me.ck_confirm.Size = New System.Drawing.Size(100, 19)
        Me.ck_confirm.TabIndex = 4
        Me.ck_confirm.Text = "Tutup Periode"
        Me.ck_confirm.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(172, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 15)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "S.d"
        '
        'bt_cancel
        '
        Me.bt_cancel.BackColor = System.Drawing.Color.White
        Me.bt_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cancel.Image = Global.Inventory.My.Resources.Resources.Delete_16x16
        Me.bt_cancel.Location = New System.Drawing.Point(318, 6)
        Me.bt_cancel.Name = "bt_cancel"
        Me.bt_cancel.Size = New System.Drawing.Size(87, 30)
        Me.bt_cancel.TabIndex = 8
        Me.bt_cancel.Text = "Batal"
        Me.bt_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.bt_cancel.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.lbl_title)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(425, 34)
        Me.Panel1.TabIndex = 4
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
        Me.bt_cl.Location = New System.Drawing.Point(399, 6)
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
        Me.lbl_title.Size = New System.Drawing.Size(132, 22)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Closing Periode"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel3.Controls.Add(Me.bt_cancel)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 446)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(425, 46)
        Me.Panel3.TabIndex = 6
        '
        'fr_closing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(425, 492)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_closing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents bt_cancel As System.Windows.Forms.Button
    Friend WithEvents bt_load As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents date_tglawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_tglakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ck_range As System.Windows.Forms.CheckBox
    Friend WithEvents ck_list As System.Windows.Forms.CheckBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_status As System.Windows.Forms.Label
    Friend WithEvents ck_confirm As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_user1 As System.Windows.Forms.Label
    Friend WithEvents lbl_closeDate As System.Windows.Forms.Label
    Friend WithEvents lbl_user2 As System.Windows.Forms.Label
End Class
