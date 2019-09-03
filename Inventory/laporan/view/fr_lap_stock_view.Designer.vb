<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_lap_stock_view
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
        Me.rv_beli_nota = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ds_stock = New Inventory.ds_stock()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.ds_stock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rv_beli_nota
        '
        Me.rv_beli_nota.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ds_nota"
        ReportDataSource1.Value = Nothing
        Me.rv_beli_nota.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rv_beli_nota.LocalReport.ReportEmbeddedResource = "Inventory.lap_beli_nota.rdlc"
        Me.rv_beli_nota.Location = New System.Drawing.Point(0, 0)
        Me.rv_beli_nota.Name = "rv_beli_nota"
        Me.rv_beli_nota.Size = New System.Drawing.Size(869, 534)
        Me.rv_beli_nota.TabIndex = 1
        '
        'ds_stock
        '
        Me.ds_stock.DataSetName = "ds_stock"
        Me.ds_stock.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 429)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(845, 105)
        Me.DataGridView1.TabIndex = 2
        Me.DataGridView1.Visible = False
        '
        'fr_lap_stock_view
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 534)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.rv_beli_nota)
        Me.Name = "fr_lap_stock_view"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fr_lap_stock_view"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ds_stock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rv_beli_nota As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ds_stock As Inventory.ds_stock
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
