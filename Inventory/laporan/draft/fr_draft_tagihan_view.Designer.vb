<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_draft_tagihan_view
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.dt_rekap_tagihanBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ds_transaksi = New Inventory.ds_transaksi()
        Me.dt_rekap_tagihan_detailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rv_draft_barang = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.dt_rekap_tagihanBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds_transaksi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_rekap_tagihan_detailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dt_rekap_tagihanBindingSource
        '
        Me.dt_rekap_tagihanBindingSource.DataMember = "dt_rekap_tagihan"
        Me.dt_rekap_tagihanBindingSource.DataSource = Me.ds_transaksi
        '
        'ds_transaksi
        '
        Me.ds_transaksi.DataSetName = "ds_transaksi"
        Me.ds_transaksi.Locale = New System.Globalization.CultureInfo("id-ID")
        Me.ds_transaksi.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dt_rekap_tagihan_detailBindingSource
        '
        Me.dt_rekap_tagihan_detailBindingSource.DataMember = "dt_rekap_tagihan_detail"
        Me.dt_rekap_tagihan_detailBindingSource.DataSource = Me.ds_transaksi
        '
        'rv_draft_barang
        '
        Me.rv_draft_barang.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ds_tagihan_header"
        ReportDataSource1.Value = Me.dt_rekap_tagihanBindingSource
        ReportDataSource2.Name = "ds_tagihan_detail"
        ReportDataSource2.Value = Me.dt_rekap_tagihan_detailBindingSource
        Me.rv_draft_barang.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rv_draft_barang.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rv_draft_barang.LocalReport.ReportEmbeddedResource = "Inventory.draft_tagihan.rdlc"
        Me.rv_draft_barang.Location = New System.Drawing.Point(0, 0)
        Me.rv_draft_barang.Name = "rv_draft_barang"
        Me.rv_draft_barang.Size = New System.Drawing.Size(789, 535)
        Me.rv_draft_barang.TabIndex = 0
        '
        'fr_draft_tagihan_view
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 535)
        Me.Controls.Add(Me.rv_draft_barang)
        Me.Name = "fr_draft_tagihan_view"
        Me.Text = "Preview Draft Tagihan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dt_rekap_tagihanBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds_transaksi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_rekap_tagihan_detailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rv_draft_barang As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dt_rekap_tagihanBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ds_transaksi As Inventory.ds_transaksi
    Friend WithEvents dt_rekap_tagihan_detailBindingSource As System.Windows.Forms.BindingSource
End Class
