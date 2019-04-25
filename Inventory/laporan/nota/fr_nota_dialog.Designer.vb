<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_nota_dialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_nota_dialog))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.pnl_content = New System.Windows.Forms.Panel()
        Me.bt_previewnota = New System.Windows.Forms.Button()
        Me.bt_cetaknota = New System.Windows.Forms.Button()
        Me.cb_printer = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.pnl_content.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(435, 42)
        Me.Panel1.TabIndex = 249
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(355, 9)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(47, 20)
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
        Me.bt_cl.FlatAppearance.BorderSize = 0
        Me.bt_cl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange
        Me.bt_cl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange
        Me.bt_cl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cl.Location = New System.Drawing.Point(408, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 0
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
        Me.lbl_title.Size = New System.Drawing.Size(130, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Cetak Nota"
        '
        'pnl_content
        '
        Me.pnl_content.Controls.Add(Me.bt_previewnota)
        Me.pnl_content.Controls.Add(Me.bt_cetaknota)
        Me.pnl_content.Controls.Add(Me.cb_printer)
        Me.pnl_content.Controls.Add(Me.Label18)
        Me.pnl_content.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_content.Location = New System.Drawing.Point(0, 42)
        Me.pnl_content.Name = "pnl_content"
        Me.pnl_content.Size = New System.Drawing.Size(435, 152)
        Me.pnl_content.TabIndex = 250
        '
        'bt_previewnota
        '
        Me.bt_previewnota.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_previewnota.FlatAppearance.BorderSize = 0
        Me.bt_previewnota.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_previewnota.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_previewnota.ForeColor = System.Drawing.Color.White
        Me.bt_previewnota.Location = New System.Drawing.Point(222, 69)
        Me.bt_previewnota.Name = "bt_previewnota"
        Me.bt_previewnota.Size = New System.Drawing.Size(90, 46)
        Me.bt_previewnota.TabIndex = 2
        Me.bt_previewnota.Text = "Preview"
        Me.bt_previewnota.UseVisualStyleBackColor = False
        '
        'bt_cetaknota
        '
        Me.bt_cetaknota.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_cetaknota.FlatAppearance.BorderSize = 0
        Me.bt_cetaknota.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cetaknota.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cetaknota.ForeColor = System.Drawing.Color.White
        Me.bt_cetaknota.Location = New System.Drawing.Point(126, 69)
        Me.bt_cetaknota.Name = "bt_cetaknota"
        Me.bt_cetaknota.Size = New System.Drawing.Size(90, 46)
        Me.bt_cetaknota.TabIndex = 1
        Me.bt_cetaknota.Text = "Print"
        Me.bt_cetaknota.UseVisualStyleBackColor = False
        '
        'cb_printer
        '
        Me.cb_printer.BackColor = System.Drawing.Color.White
        Me.cb_printer.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_printer.ForeColor = System.Drawing.Color.Black
        Me.cb_printer.FormattingEnabled = True
        Me.cb_printer.Location = New System.Drawing.Point(88, 20)
        Me.cb_printer.Name = "cb_printer"
        Me.cb_printer.Size = New System.Drawing.Size(285, 23)
        Me.cb_printer.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(36, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 15)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Printer"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 194)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(435, 10)
        Me.Panel2.TabIndex = 289
        '
        'fr_nota_dialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(435, 204)
        Me.Controls.Add(Me.pnl_content)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "fr_nota_dialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cetak Nota"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_content.ResumeLayout(False)
        Me.pnl_content.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents pnl_content As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cb_printer As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents bt_previewnota As System.Windows.Forms.Button
    Friend WithEvents bt_cetaknota As System.Windows.Forms.Button
End Class
