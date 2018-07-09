<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
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
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tabcontrol = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.strip_user = New System.Windows.Forms.ToolStripStatusLabel()
        Me.strip_tgl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.strip_host = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.tabcontrol.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer
        '
        Me.SplitContainer.BackColor = System.Drawing.Color.White
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer.IsSplitterFixed = True
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        Me.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer.Panel1.BackgroundImage = Global.Inventory.My.Resources.Resources.bg_stripes_gray
        Me.SplitContainer.Panel1.Controls.Add(Me.Label12)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.tabcontrol)
        Me.SplitContainer.Size = New System.Drawing.Size(944, 659)
        Me.SplitContainer.SplitterDistance = 60
        Me.SplitContainer.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Source Sans Pro", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Orange
        Me.Label12.Location = New System.Drawing.Point(3, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(443, 30)
        Me.Label12.TabIndex = 137
        Me.Label12.Text = "Sistem Informasi managemen inventory"
        '
        'tabcontrol
        '
        Me.tabcontrol.Controls.Add(Me.TabPage1)
        Me.tabcontrol.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabcontrol.Location = New System.Drawing.Point(0, 0)
        Me.tabcontrol.Name = "tabcontrol"
        Me.tabcontrol.SelectedIndex = 0
        Me.tabcontrol.Size = New System.Drawing.Size(944, 595)
        Me.tabcontrol.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TabPage1.BackgroundImage = Global.Inventory.My.Resources.Resources.bg
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(936, 569)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Menu Utama"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.White
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.strip_user, Me.strip_tgl, Me.strip_host})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 659)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(944, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'strip_user
        '
        Me.strip_user.Name = "strip_user"
        Me.strip_user.Size = New System.Drawing.Size(30, 17)
        Me.strip_user.Text = "User"
        '
        'strip_tgl
        '
        Me.strip_tgl.Name = "strip_tgl"
        Me.strip_tgl.Size = New System.Drawing.Size(121, 17)
        Me.strip_tgl.Text = "ToolStripStatusLabel1"
        '
        'strip_host
        '
        Me.strip_host.Name = "strip_host"
        Me.strip_host.Size = New System.Drawing.Size(121, 17)
        Me.strip_host.Text = "ToolStripStatusLabel1"
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 681)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.StatusStrip1)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(960, 720)
        Me.Name = "main"
        Me.Opacity = 0.0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Utama"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        Me.tabcontrol.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents tabcontrol As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents strip_user As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents strip_tgl As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents strip_host As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label12 As System.Windows.Forms.Label

End Class
