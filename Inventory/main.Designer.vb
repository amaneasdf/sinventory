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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.pic_company = New System.Windows.Forms.PictureBox()
        Me.lbl_app = New System.Windows.Forms.Label()
        Me.tabcontrol = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.pnl_main = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_periode_main = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.cal_front = New System.Windows.Forms.MonthCalendar()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.strip_user = New System.Windows.Forms.ToolStripStatusLabel()
        Me.strip_tgl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.strip_host = New System.Windows.Forms.ToolStripStatusLabel()
        Me.strip_periode = New System.Windows.Forms.ToolStripStatusLabel()
        Me.strip_status = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        CType(Me.pic_company, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabcontrol.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.SplitContainer.Panel1.Controls.Add(Me.pic_company)
        Me.SplitContainer.Panel1.Controls.Add(Me.lbl_app)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.tabcontrol)
        Me.SplitContainer.Size = New System.Drawing.Size(969, 656)
        Me.SplitContainer.SplitterDistance = 60
        Me.SplitContainer.TabIndex = 1
        '
        'pic_company
        '
        Me.pic_company.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic_company.BackgroundImage = Global.Inventory.My.Resources.Resources.company_name
        Me.pic_company.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pic_company.Location = New System.Drawing.Point(742, 3)
        Me.pic_company.Name = "pic_company"
        Me.pic_company.Size = New System.Drawing.Size(224, 54)
        Me.pic_company.TabIndex = 138
        Me.pic_company.TabStop = False
        '
        'lbl_app
        '
        Me.lbl_app.AutoSize = True
        Me.lbl_app.BackColor = System.Drawing.Color.Transparent
        Me.lbl_app.Font = New System.Drawing.Font("Source Sans Pro", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_app.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_app.Location = New System.Drawing.Point(5, 15)
        Me.lbl_app.Name = "lbl_app"
        Me.lbl_app.Size = New System.Drawing.Size(119, 31)
        Me.lbl_app.TabIndex = 137
        Me.lbl_app.Text = "Inventory"
        '
        'tabcontrol
        '
        Me.tabcontrol.Controls.Add(Me.TabPage1)
        Me.tabcontrol.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabcontrol.Location = New System.Drawing.Point(0, 0)
        Me.tabcontrol.Name = "tabcontrol"
        Me.tabcontrol.SelectedIndex = 0
        Me.tabcontrol.Size = New System.Drawing.Size(969, 592)
        Me.tabcontrol.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.pnl_main)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(961, 566)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Menu Utama"
        '
        'pnl_main
        '
        Me.pnl_main.BackColor = System.Drawing.Color.White
        Me.pnl_main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnl_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_main.Location = New System.Drawing.Point(3, 3)
        Me.pnl_main.Name = "pnl_main"
        Me.pnl_main.Size = New System.Drawing.Size(704, 560)
        Me.pnl_main.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.bt_periode_main)
        Me.Panel1.Controls.Add(Me.ListView1)
        Me.Panel1.Controls.Add(Me.cal_front)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(707, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(251, 560)
        Me.Panel1.TabIndex = 1
        '
        'bt_periode_main
        '
        Me.bt_periode_main.Location = New System.Drawing.Point(103, 172)
        Me.bt_periode_main.Name = "bt_periode_main"
        Me.bt_periode_main.Size = New System.Drawing.Size(137, 31)
        Me.bt_periode_main.TabIndex = 2
        Me.bt_periode_main.Text = "Set Periode"
        Me.bt_periode_main.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(13, 336)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(227, 196)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.Visible = False
        '
        'cal_front
        '
        Me.cal_front.Location = New System.Drawing.Point(13, 9)
        Me.cal_front.MaxSelectionCount = 1
        Me.cal_front.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.cal_front.MinimumSize = New System.Drawing.Size(227, 162)
        Me.cal_front.Name = "cal_front"
        Me.cal_front.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.White
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.strip_user, Me.strip_tgl, Me.strip_host, Me.strip_periode, Me.strip_status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 656)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(969, 25)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'strip_user
        '
        Me.strip_user.ForeColor = System.Drawing.Color.Black
        Me.strip_user.Image = Global.Inventory.My.Resources.Resources.toolbar_list_icon1
        Me.strip_user.Name = "strip_user"
        Me.strip_user.Size = New System.Drawing.Size(46, 20)
        Me.strip_user.Text = "User"
        '
        'strip_tgl
        '
        Me.strip_tgl.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.strip_tgl.Name = "strip_tgl"
        Me.strip_tgl.Size = New System.Drawing.Size(88, 20)
        Me.strip_tgl.Text = "00 xxxxxxx 0000"
        '
        'strip_host
        '
        Me.strip_host.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.strip_host.Image = Global.Inventory.My.Resources.Resources.toolbar_list_icon1
        Me.strip_host.Name = "strip_host"
        Me.strip_host.Size = New System.Drawing.Size(87, 20)
        Me.strip_host.Text = "DB-ssssssss"
        '
        'strip_periode
        '
        Me.strip_periode.Image = Global.Inventory.My.Resources.Resources.toolbar_list_icon1
        Me.strip_periode.Name = "strip_periode"
        Me.strip_periode.Size = New System.Drawing.Size(85, 20)
        Me.strip_periode.Text = "xxxxxxx 0000"
        '
        'strip_status
        '
        Me.strip_status.Name = "strip_status"
        Me.strip_status.Size = New System.Drawing.Size(99, 20)
        Me.strip_status.Text = "Status Input : xxxx"
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 681)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(600, 480)
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
        CType(Me.pic_company, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabcontrol.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
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
    Friend WithEvents cal_front As System.Windows.Forms.MonthCalendar
    Friend WithEvents strip_periode As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pnl_main As System.Windows.Forms.Panel
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents lbl_app As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents strip_status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents bt_periode_main As System.Windows.Forms.Button
    Friend WithEvents pic_company As System.Windows.Forms.PictureBox

End Class
