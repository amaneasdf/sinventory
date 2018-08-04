<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_lap_stok
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.dt_persediaanBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ds_stock = New Inventory.ds_stock()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.rv_stock = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.bt_viewrep = New System.Windows.Forms.Button()
        Me.bt_filter = New System.Windows.Forms.Button()
        Me.date_tgl_awal = New System.Windows.Forms.DateTimePicker()
        Me.date_tgl_akhir = New System.Windows.Forms.DateTimePicker()
        CType(Me.dt_persediaanBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds_stock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dt_persediaanBindingSource
        '
        Me.dt_persediaanBindingSource.DataMember = "dt_persediaan"
        Me.dt_persediaanBindingSource.DataSource = Me.ds_stock
        '
        'ds_stock
        '
        Me.ds_stock.DataSetName = "ds_stock"
        Me.ds_stock.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.Panel1.Size = New System.Drawing.Size(1031, 42)
        Me.Panel1.TabIndex = 248
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(951, 9)
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
        Me.bt_cl.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_cl.FlatAppearance.BorderSize = 0
        Me.bt_cl.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange
        Me.bt_cl.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange
        Me.bt_cl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_cl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cl.Location = New System.Drawing.Point(1004, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 137
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
        Me.lbl_title.Size = New System.Drawing.Size(104, 30)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Lap Stok"
        '
        'rv_stock
        '
        Me.rv_stock.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "ds_rep_stock"
        ReportDataSource1.Value = Me.dt_persediaanBindingSource
        Me.rv_stock.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rv_stock.LocalReport.ReportEmbeddedResource = "Inventory.lap_stock.rdlc"
        Me.rv_stock.Location = New System.Drawing.Point(3, 75)
        Me.rv_stock.Name = "rv_stock"
        Me.rv_stock.Size = New System.Drawing.Size(923, 479)
        Me.rv_stock.TabIndex = 249
        '
        'bt_viewrep
        '
        Me.bt_viewrep.Location = New System.Drawing.Point(792, 46)
        Me.bt_viewrep.Name = "bt_viewrep"
        Me.bt_viewrep.Size = New System.Drawing.Size(75, 23)
        Me.bt_viewrep.TabIndex = 250
        Me.bt_viewrep.Text = "Preview"
        Me.bt_viewrep.UseVisualStyleBackColor = True
        '
        'bt_filter
        '
        Me.bt_filter.Location = New System.Drawing.Point(873, 46)
        Me.bt_filter.Name = "bt_filter"
        Me.bt_filter.Size = New System.Drawing.Size(53, 23)
        Me.bt_filter.TabIndex = 250
        Me.bt_filter.Text = "Filter"
        Me.bt_filter.UseVisualStyleBackColor = True
        '
        'date_tgl_awal
        '
        Me.date_tgl_awal.Location = New System.Drawing.Point(468, 49)
        Me.date_tgl_awal.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_awal.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_awal.Name = "date_tgl_awal"
        Me.date_tgl_awal.Size = New System.Drawing.Size(140, 20)
        Me.date_tgl_awal.TabIndex = 251
        '
        'date_tgl_akhir
        '
        Me.date_tgl_akhir.Location = New System.Drawing.Point(646, 49)
        Me.date_tgl_akhir.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.date_tgl_akhir.MinDate = New Date(1990, 1, 1, 0, 0, 0, 0)
        Me.date_tgl_akhir.Name = "date_tgl_akhir"
        Me.date_tgl_akhir.Size = New System.Drawing.Size(140, 20)
        Me.date_tgl_akhir.TabIndex = 251
        '
        'fr_lap_stok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.date_tgl_akhir)
        Me.Controls.Add(Me.date_tgl_awal)
        Me.Controls.Add(Me.bt_filter)
        Me.Controls.Add(Me.bt_viewrep)
        Me.Controls.Add(Me.rv_stock)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "fr_lap_stok"
        Me.Size = New System.Drawing.Size(1031, 570)
        CType(Me.dt_persediaanBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds_stock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents rv_stock As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dt_persediaanBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ds_stock As Inventory.ds_stock
    Friend WithEvents bt_viewrep As System.Windows.Forms.Button
    Friend WithEvents bt_filter As System.Windows.Forms.Button
    Friend WithEvents date_tgl_awal As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_tgl_akhir As System.Windows.Forms.DateTimePicker

End Class
