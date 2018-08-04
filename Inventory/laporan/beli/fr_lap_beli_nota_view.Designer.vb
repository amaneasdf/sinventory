<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_lap_beli_nota_view
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
        Me.dt_lap_beli_notaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ds_transaksi = New Inventory.ds_transaksi()
        Me.rv_beli_nota = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.dt_lap_beli_notaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds_transaksi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dt_lap_beli_notaBindingSource
        '
        Me.dt_lap_beli_notaBindingSource.DataMember = "dt_lap_beli_nota"
        Me.dt_lap_beli_notaBindingSource.DataSource = Me.ds_transaksi
        '
        'ds_transaksi
        '
        Me.ds_transaksi.DataSetName = "ds_transaksi"
        Me.ds_transaksi.Locale = New System.Globalization.CultureInfo("id-ID")
        Me.ds_transaksi.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'rv_beli_nota
        '
        Me.rv_beli_nota.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ds_nota"
        ReportDataSource1.Value = Me.dt_lap_beli_notaBindingSource
        Me.rv_beli_nota.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rv_beli_nota.LocalReport.ReportEmbeddedResource = "Inventory.lap_beli_nota.rdlc"
        Me.rv_beli_nota.Location = New System.Drawing.Point(0, 0)
        Me.rv_beli_nota.Name = "rv_beli_nota"
        Me.rv_beli_nota.Size = New System.Drawing.Size(869, 534)
        Me.rv_beli_nota.TabIndex = 0
        '
        'fr_lap_beli_nota_view
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 534)
        Me.Controls.Add(Me.rv_beli_nota)
        Me.Name = "fr_lap_beli_nota_view"
        Me.Text = "Laporan Pembelian Per Nota"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dt_lap_beli_notaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds_transaksi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rv_beli_nota As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dt_lap_beli_notaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ds_transaksi As Inventory.ds_transaksi
End Class
