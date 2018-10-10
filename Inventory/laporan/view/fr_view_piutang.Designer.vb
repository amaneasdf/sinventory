<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_view_piutang
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.rv_nota = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ds_hutangpiutang = New Inventory.ds_hutangpiutang()
        CType(Me.ds_hutangpiutang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rv_nota
        '
        Me.rv_nota.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "ds_jual_tgl"
        ReportDataSource2.Value = Nothing
        Me.rv_nota.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rv_nota.LocalReport.ReportEmbeddedResource = "Inventory.lap_jual_tgl.rdlc"
        Me.rv_nota.Location = New System.Drawing.Point(0, 0)
        Me.rv_nota.Name = "rv_nota"
        Me.rv_nota.Size = New System.Drawing.Size(818, 524)
        Me.rv_nota.TabIndex = 0
        '
        'ds_hutangpiutang
        '
        Me.ds_hutangpiutang.DataSetName = "ds_hutangpiutang"
        Me.ds_hutangpiutang.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'fr_view_piutang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 524)
        Me.Controls.Add(Me.rv_nota)
        Me.Name = "fr_view_piutang"
        CType(Me.ds_hutangpiutang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rv_nota As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ds_hutangpiutang As Inventory.ds_hutangpiutang
End Class
