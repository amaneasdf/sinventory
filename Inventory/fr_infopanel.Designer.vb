<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_infopanel
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
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnl_giro = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgv_giroin_jt = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.giro_kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.giro_sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.giro_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnl_giro.SuspendLayout()
        CType(Me.dgv_giroin_jt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.pnl_giro)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(890, 747)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'pnl_giro
        '
        Me.pnl_giro.BackColor = System.Drawing.Color.OliveDrab
        Me.pnl_giro.Controls.Add(Me.dgv_giroin_jt)
        Me.pnl_giro.Controls.Add(Me.Label2)
        Me.pnl_giro.Controls.Add(Me.Label1)
        Me.pnl_giro.Location = New System.Drawing.Point(3, 3)
        Me.pnl_giro.Name = "pnl_giro"
        Me.pnl_giro.Size = New System.Drawing.Size(376, 360)
        Me.pnl_giro.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Open Sans", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bilyet Giro Diterima"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(17, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Jatuh Tempo Hari Ini"
        '
        'dgv_giroin_jt
        '
        Me.dgv_giroin_jt.AllowUserToAddRows = False
        Me.dgv_giroin_jt.AllowUserToDeleteRows = False
        Me.dgv_giroin_jt.BackgroundColor = System.Drawing.Color.White
        Me.dgv_giroin_jt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_giroin_jt.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.giro_kode, Me.giro_sales, Me.giro_status})
        Me.dgv_giroin_jt.Location = New System.Drawing.Point(21, 68)
        Me.dgv_giroin_jt.MultiSelect = False
        Me.dgv_giroin_jt.Name = "dgv_giroin_jt"
        Me.dgv_giroin_jt.ReadOnly = True
        Me.dgv_giroin_jt.RowHeadersVisible = False
        Me.dgv_giroin_jt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_giroin_jt.Size = New System.Drawing.Size(341, 124)
        Me.dgv_giroin_jt.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Location = New System.Drawing.Point(385, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(469, 360)
        Me.Panel1.TabIndex = 1
        '
        'giro_kode
        '
        Me.giro_kode.DataPropertyName = "giro_no"
        Me.giro_kode.HeaderText = "Kode"
        Me.giro_kode.Name = "giro_kode"
        Me.giro_kode.ReadOnly = True
        '
        'giro_sales
        '
        Me.giro_sales.DataPropertyName = "salesman_nama"
        Me.giro_sales.HeaderText = "Salesman"
        Me.giro_sales.Name = "giro_sales"
        Me.giro_sales.ReadOnly = True
        Me.giro_sales.Width = 150
        '
        'giro_status
        '
        Me.giro_status.DataPropertyName = "giro_status"
        Me.giro_status.HeaderText = "Status"
        Me.giro_status.Name = "giro_status"
        Me.giro_status.ReadOnly = True
        Me.giro_status.Width = 75
        '
        'fr_infopanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "fr_infopanel"
        Me.Size = New System.Drawing.Size(890, 747)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pnl_giro.ResumeLayout(False)
        Me.pnl_giro.PerformLayout()
        CType(Me.dgv_giroin_jt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnl_giro As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_giroin_jt As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents giro_kode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents giro_sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents giro_status As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
