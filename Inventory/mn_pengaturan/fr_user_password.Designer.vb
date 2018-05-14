<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_user_password
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
        Me.in_passnew = New System.Windows.Forms.TextBox()
        Me.in_userid = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.bt_bataluser = New System.Windows.Forms.Button()
        Me.bt_simpanuser = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.in_passold = New System.Windows.Forms.TextBox()
        Me.bt_switch_newpass = New System.Windows.Forms.Button()
        Me.bt_switch_oldpass = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'in_passnew
        '
        Me.in_passnew.BackColor = System.Drawing.Color.White
        Me.in_passnew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_passnew.ForeColor = System.Drawing.Color.Black
        Me.in_passnew.Location = New System.Drawing.Point(15, 125)
        Me.in_passnew.MaxLength = 15
        Me.in_passnew.Name = "in_passnew"
        Me.in_passnew.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_passnew.Size = New System.Drawing.Size(266, 22)
        Me.in_passnew.TabIndex = 1
        '
        'in_userid
        '
        Me.in_userid.BackColor = System.Drawing.Color.Gainsboro
        Me.in_userid.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_userid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_userid.ForeColor = System.Drawing.Color.Black
        Me.in_userid.Location = New System.Drawing.Point(15, 28)
        Me.in_userid.MaxLength = 15
        Me.in_userid.Name = "in_userid"
        Me.in_userid.ReadOnly = True
        Me.in_userid.Size = New System.Drawing.Size(294, 22)
        Me.in_userid.TabIndex = 14
        Me.in_userid.TabStop = False
        Me.in_userid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Password Baru"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "User ID"
        '
        'bt_bataluser
        '
        Me.bt_bataluser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_bataluser.Location = New System.Drawing.Point(213, 166)
        Me.bt_bataluser.Name = "bt_bataluser"
        Me.bt_bataluser.Size = New System.Drawing.Size(96, 30)
        Me.bt_bataluser.TabIndex = 3
        Me.bt_bataluser.Text = "Keluar"
        Me.bt_bataluser.UseVisualStyleBackColor = True
        '
        'bt_simpanuser
        '
        Me.bt_simpanuser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanuser.Location = New System.Drawing.Point(111, 166)
        Me.bt_simpanuser.Name = "bt_simpanuser"
        Me.bt_simpanuser.Size = New System.Drawing.Size(96, 30)
        Me.bt_simpanuser.TabIndex = 2
        Me.bt_simpanuser.Text = "Simpan"
        Me.bt_simpanuser.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Password Lama"
        '
        'in_passold
        '
        Me.in_passold.BackColor = System.Drawing.Color.White
        Me.in_passold.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_passold.ForeColor = System.Drawing.Color.Black
        Me.in_passold.Location = New System.Drawing.Point(15, 72)
        Me.in_passold.MaxLength = 15
        Me.in_passold.Name = "in_passold"
        Me.in_passold.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.in_passold.Size = New System.Drawing.Size(266, 22)
        Me.in_passold.TabIndex = 0
        '
        'bt_switch_newpass
        '
        Me.bt_switch_newpass.BackgroundImage = Global.Inventory.My.Resources.Resources.show_password
        Me.bt_switch_newpass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_switch_newpass.FlatAppearance.BorderSize = 0
        Me.bt_switch_newpass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_switch_newpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_switch_newpass.Location = New System.Drawing.Point(287, 123)
        Me.bt_switch_newpass.Name = "bt_switch_newpass"
        Me.bt_switch_newpass.Size = New System.Drawing.Size(25, 25)
        Me.bt_switch_newpass.TabIndex = 18
        Me.bt_switch_newpass.TabStop = False
        Me.bt_switch_newpass.UseVisualStyleBackColor = True
        '
        'bt_switch_oldpass
        '
        Me.bt_switch_oldpass.BackgroundImage = Global.Inventory.My.Resources.Resources.show_password
        Me.bt_switch_oldpass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_switch_oldpass.FlatAppearance.BorderSize = 0
        Me.bt_switch_oldpass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_switch_oldpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_switch_oldpass.Location = New System.Drawing.Point(287, 69)
        Me.bt_switch_oldpass.Name = "bt_switch_oldpass"
        Me.bt_switch_oldpass.Size = New System.Drawing.Size(25, 25)
        Me.bt_switch_oldpass.TabIndex = 18
        Me.bt_switch_oldpass.TabStop = False
        Me.bt_switch_oldpass.UseVisualStyleBackColor = True
        '
        'fr_user_password
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 210)
        Me.Controls.Add(Me.bt_bataluser)
        Me.Controls.Add(Me.bt_switch_newpass)
        Me.Controls.Add(Me.bt_switch_oldpass)
        Me.Controls.Add(Me.bt_simpanuser)
        Me.Controls.Add(Me.in_passold)
        Me.Controls.Add(Me.in_passnew)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.in_userid)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "fr_user_password"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ubah Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents in_passnew As System.Windows.Forms.TextBox
    Friend WithEvents in_userid As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents bt_bataluser As System.Windows.Forms.Button
    Friend WithEvents bt_simpanuser As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents in_passold As System.Windows.Forms.TextBox
    Friend WithEvents bt_switch_oldpass As System.Windows.Forms.Button
    Friend WithEvents bt_switch_newpass As System.Windows.Forms.Button
End Class
