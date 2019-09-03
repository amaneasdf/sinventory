<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_lap_keuangan
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_lap_keuangan))
        Me.rv_nota = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ds_keuangan = New Inventory.ds_keuangan()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds_keuangan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rv_nota
        '
        Me.rv_nota.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ds_jual_tgl"
        ReportDataSource1.Value = Nothing
        Me.rv_nota.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rv_nota.LocalReport.ReportEmbeddedResource = "Inventory.lap_jual_tgl.rdlc"
        Me.rv_nota.Location = New System.Drawing.Point(0, 0)
        Me.rv_nota.Name = "rv_nota"
        Me.rv_nota.Size = New System.Drawing.Size(818, 524)
        Me.rv_nota.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 415)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(818, 97)
        Me.DataGridView1.TabIndex = 1
        Me.DataGridView1.Visible = False
        '
        'ds_keuangan
        '
        Me.ds_keuangan.DataSetName = "ds_keuangan"
        Me.ds_keuangan.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'fr_lap_keuangan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 524)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.rv_nota)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "fr_lap_keuangan"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds_keuangan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rv_nota As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ds_keuangan As Inventory.ds_keuangan
End Class
