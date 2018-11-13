<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_login))
        Me.bt_close = New System.Windows.Forms.Button()
        Me.bt_login = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.in_user = New System.Windows.Forms.TextBox()
        Me.in_pass = New System.Windows.Forms.TextBox()
        Me.out_tglserver = New System.Windows.Forms.TextBox()
        Me.out_tglkomp = New System.Windows.Forms.TextBox()
        Me.lbl_judul = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.bt_switch = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bt_close
        '
        Me.bt_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_close.BackColor = System.Drawing.Color.White
        Me.bt_close.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_close.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bt_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_close.Location = New System.Drawing.Point(311, 185)
        Me.bt_close.Name = "bt_close"
        Me.bt_close.Size = New System.Drawing.Size(101, 39)
        Me.bt_close.TabIndex = 3
        Me.bt_close.Text = "Keluar"
        Me.bt_close.UseVisualStyleBackColor = False
        '
        'bt_login
        '
        Me.bt_login.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_login.BackColor = System.Drawing.Color.White
        Me.bt_login.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bt_login.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_login.Location = New System.Drawing.Point(199, 185)
        Me.bt_login.Name = "bt_login"
        Me.bt_login.Size = New System.Drawing.Size(101, 39)
        Me.bt_login.TabIndex = 2
        Me.bt_login.Text = "Login"
        Me.bt_login.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(112, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "User Login"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(112, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(112, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Tgl. Server"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(112, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 15)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Tgl. Komp"
        '
        'in_user
        '
        Me.in_user.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_user.Location = New System.Drawing.Point(190, 62)
        Me.in_user.MaxLength = 20
        Me.in_user.Name = "in_user"
        Me.in_user.Size = New System.Drawing.Size(222, 21)
        Me.in_user.TabIndex = 0
        Me.in_user.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'in_pass
        '
        Me.in_pass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_pass.Location = New System.Drawing.Point(190, 91)
        Me.in_pass.MaxLength = 20
        Me.in_pass.Name = "in_pass"
        Me.in_pass.Size = New System.Drawing.Size(222, 21)
        Me.in_pass.TabIndex = 1
        Me.in_pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'out_tglserver
        '
        Me.out_tglserver.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.out_tglserver.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.out_tglserver.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.out_tglserver.ForeColor = System.Drawing.Color.Black
        Me.out_tglserver.Location = New System.Drawing.Point(190, 127)
        Me.out_tglserver.Name = "out_tglserver"
        Me.out_tglserver.ReadOnly = True
        Me.out_tglserver.Size = New System.Drawing.Size(222, 21)
        Me.out_tglserver.TabIndex = 2
        Me.out_tglserver.TabStop = False
        Me.out_tglserver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'out_tglkomp
        '
        Me.out_tglkomp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.out_tglkomp.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.out_tglkomp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.out_tglkomp.ForeColor = System.Drawing.Color.Black
        Me.out_tglkomp.Location = New System.Drawing.Point(190, 156)
        Me.out_tglkomp.Name = "out_tglkomp"
        Me.out_tglkomp.ReadOnly = True
        Me.out_tglkomp.Size = New System.Drawing.Size(222, 21)
        Me.out_tglkomp.TabIndex = 2
        Me.out_tglkomp.TabStop = False
        Me.out_tglkomp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_judul
        '
        Me.lbl_judul.AutoSize = True
        Me.lbl_judul.Font = New System.Drawing.Font("Source Sans Pro", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_judul.ForeColor = System.Drawing.Color.White
        Me.lbl_judul.Location = New System.Drawing.Point(112, 24)
        Me.lbl_judul.Name = "lbl_judul"
        Me.lbl_judul.Size = New System.Drawing.Size(74, 27)
        Me.lbl_judul.TabIndex = 1
        Me.lbl_judul.Text = "Label1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Inventory.My.Resources.Resources.logo5
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(94, 100)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'bt_switch
        '
        Me.bt_switch.BackColor = System.Drawing.Color.White
        Me.bt_switch.BackgroundImage = Global.Inventory.My.Resources.Resources.show_password
        Me.bt_switch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_switch.FlatAppearance.BorderSize = 0
        Me.bt_switch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_switch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_switch.Location = New System.Drawing.Point(392, 92)
        Me.bt_switch.Name = "bt_switch"
        Me.bt_switch.Size = New System.Drawing.Size(19, 19)
        Me.bt_switch.TabIndex = 19
        Me.bt_switch.TabStop = False
        Me.bt_switch.UseVisualStyleBackColor = False
        '
        'fr_login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CancelButton = Me.bt_close
        Me.ClientSize = New System.Drawing.Size(434, 245)
        Me.Controls.Add(Me.bt_switch)
        Me.Controls.Add(Me.out_tglkomp)
        Me.Controls.Add(Me.out_tglserver)
        Me.Controls.Add(Me.in_pass)
        Me.Controls.Add(Me.in_user)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_judul)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bt_login)
        Me.Controls.Add(Me.bt_close)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fr_login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bt_close As System.Windows.Forms.Button
    Friend WithEvents bt_login As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents in_user As System.Windows.Forms.TextBox
    Friend WithEvents in_pass As System.Windows.Forms.TextBox
    Friend WithEvents out_tglserver As System.Windows.Forms.TextBox
    Friend WithEvents out_tglkomp As System.Windows.Forms.TextBox
    Friend WithEvents lbl_judul As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents bt_switch As System.Windows.Forms.Button
End Class
