<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_stockopconfirm_dialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_stockopconfirm_dialog))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.bt_batalbeli = New System.Windows.Forms.Button()
        Me.bt_simpanbeli = New System.Windows.Forms.Button()
        Me.lbl_cair = New System.Windows.Forms.Label()
        Me.lbl_tgl = New System.Windows.Forms.Label()
        Me.bt_switch = New System.Windows.Forms.Button()
        Me.in_pass = New System.Windows.Forms.TextBox()
        Me.in_user = New System.Windows.Forms.TextBox()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(417, 30)
        Me.Panel1.TabIndex = 411
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
        Me.bt_cl.Location = New System.Drawing.Point(388, 7)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(17, 17)
        Me.bt_cl.TabIndex = 137
        Me.bt_cl.TabStop = False
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Orange
        Me.lbl_title.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(6, 4)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(220, 22)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Konfirmasi Stock Opname"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 194)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(417, 10)
        Me.Panel3.TabIndex = 416
        '
        'bt_batalbeli
        '
        Me.bt_batalbeli.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalbeli.Location = New System.Drawing.Point(325, 158)
        Me.bt_batalbeli.Name = "bt_batalbeli"
        Me.bt_batalbeli.Size = New System.Drawing.Size(80, 30)
        Me.bt_batalbeli.TabIndex = 5
        Me.bt_batalbeli.Text = "Batal"
        Me.bt_batalbeli.UseVisualStyleBackColor = True
        '
        'bt_simpanbeli
        '
        Me.bt_simpanbeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbeli.Location = New System.Drawing.Point(211, 158)
        Me.bt_simpanbeli.Name = "bt_simpanbeli"
        Me.bt_simpanbeli.Size = New System.Drawing.Size(108, 30)
        Me.bt_simpanbeli.TabIndex = 4
        Me.bt_simpanbeli.Text = "OK"
        Me.bt_simpanbeli.UseVisualStyleBackColor = True
        '
        'lbl_cair
        '
        Me.lbl_cair.AutoSize = True
        Me.lbl_cair.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cair.Location = New System.Drawing.Point(7, 69)
        Me.lbl_cair.Name = "lbl_cair"
        Me.lbl_cair.Size = New System.Drawing.Size(53, 13)
        Me.lbl_cair.TabIndex = 432
        Me.lbl_cair.Text = "Password"
        '
        'lbl_tgl
        '
        Me.lbl_tgl.AutoSize = True
        Me.lbl_tgl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tgl.Location = New System.Drawing.Point(7, 46)
        Me.lbl_tgl.Name = "lbl_tgl"
        Me.lbl_tgl.Size = New System.Drawing.Size(43, 13)
        Me.lbl_tgl.TabIndex = 431
        Me.lbl_tgl.Text = "User ID"
        '
        'bt_switch
        '
        Me.bt_switch.BackColor = System.Drawing.Color.White
        Me.bt_switch.BackgroundImage = Global.Inventory.My.Resources.Resources.show_password
        Me.bt_switch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_switch.FlatAppearance.BorderSize = 0
        Me.bt_switch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_switch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_switch.Location = New System.Drawing.Point(383, 66)
        Me.bt_switch.Name = "bt_switch"
        Me.bt_switch.Size = New System.Drawing.Size(19, 19)
        Me.bt_switch.TabIndex = 2
        Me.bt_switch.TabStop = False
        Me.bt_switch.UseVisualStyleBackColor = False
        '
        'in_pass
        '
        Me.in_pass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_pass.Location = New System.Drawing.Point(89, 65)
        Me.in_pass.MaxLength = 20
        Me.in_pass.Name = "in_pass"
        Me.in_pass.Size = New System.Drawing.Size(316, 21)
        Me.in_pass.TabIndex = 1
        '
        'in_user
        '
        Me.in_user.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_user.Location = New System.Drawing.Point(89, 42)
        Me.in_user.MaxLength = 20
        Me.in_user.Name = "in_user"
        Me.in_user.Size = New System.Drawing.Size(316, 21)
        Me.in_user.TabIndex = 0
        '
        'in_ket
        '
        Me.in_ket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.Location = New System.Drawing.Point(89, 89)
        Me.in_ket.MaxLength = 255
        Me.in_ket.Multiline = True
        Me.in_ket.Name = "in_ket"
        Me.in_ket.Size = New System.Drawing.Size(316, 63)
        Me.in_ket.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 432
        Me.Label1.Text = "Keterangan"
        '
        'fr_stockopconfirm_dialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.bt_batalbeli
        Me.ClientSize = New System.Drawing.Size(417, 204)
        Me.Controls.Add(Me.in_ket)
        Me.Controls.Add(Me.bt_switch)
        Me.Controls.Add(Me.in_pass)
        Me.Controls.Add(Me.in_user)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_cair)
        Me.Controls.Add(Me.lbl_tgl)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.bt_batalbeli)
        Me.Controls.Add(Me.bt_simpanbeli)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fr_stockopconfirm_dialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "fr_giro_dialog"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents bt_batalbeli As System.Windows.Forms.Button
    Friend WithEvents bt_simpanbeli As System.Windows.Forms.Button
    Friend WithEvents lbl_cair As System.Windows.Forms.Label
    Friend WithEvents lbl_tgl As System.Windows.Forms.Label
    Friend WithEvents bt_switch As System.Windows.Forms.Button
    Friend WithEvents in_pass As System.Windows.Forms.TextBox
    Friend WithEvents in_user As System.Windows.Forms.TextBox
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
