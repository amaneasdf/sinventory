<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_view_nota
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.dt_nota_beliBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ds_transaksi = New Inventory.ds_transaksi()
        Me.rv_nota = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dt_lap_jual_notaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dt_nota_beliBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds_transaksi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_lap_jual_notaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dt_nota_beliBindingSource
        '
        Me.dt_nota_beliBindingSource.DataMember = "dt_nota_beli"
        Me.dt_nota_beliBindingSource.DataSource = Me.ds_transaksi
        '
        'ds_transaksi
        '
        Me.ds_transaksi.DataSetName = "ds_transaksi"
        Me.ds_transaksi.Locale = New System.Globalization.CultureInfo("id-ID")
        Me.ds_transaksi.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'rv_nota
        '
        Me.rv_nota.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ds_jual_tgl"
        ReportDataSource1.Value = Me.dt_lap_jual_notaBindingSource
        Me.rv_nota.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rv_nota.LocalReport.ReportEmbeddedResource = "Inventory.lap_jual_tgl.rdlc"
        Me.rv_nota.Location = New System.Drawing.Point(0, 0)
        Me.rv_nota.Name = "rv_nota"
        Me.rv_nota.Size = New System.Drawing.Size(818, 524)
        Me.rv_nota.TabIndex = 0
        '
        'dt_lap_jual_notaBindingSource
        '
        Me.dt_lap_jual_notaBindingSource.DataMember = "dt_lap_jual_nota"
        Me.dt_lap_jual_notaBindingSource.DataSource = Me.ds_transaksi
        '
        'fr_view_nota
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 524)
        Me.Controls.Add(Me.rv_nota)
        Me.Name = "fr_view_nota"
        CType(Me.dt_nota_beliBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds_transaksi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_lap_jual_notaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rv_nota As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dt_nota_beliBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ds_transaksi As Inventory.ds_transaksi
    Friend WithEvents dt_lap_jual_notaBindingSource As System.Windows.Forms.BindingSource
End Class
