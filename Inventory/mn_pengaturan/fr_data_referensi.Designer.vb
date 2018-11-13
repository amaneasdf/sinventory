<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_data_referensi
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
        Me.pnl_listref = New System.Windows.Forms.Panel()
        Me.pnl_container = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'pnl_listref
        '
        Me.pnl_listref.AutoScroll = True
        Me.pnl_listref.BackColor = System.Drawing.Color.Orange
        Me.pnl_listref.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnl_listref.Location = New System.Drawing.Point(0, 0)
        Me.pnl_listref.Name = "pnl_listref"
        Me.pnl_listref.Size = New System.Drawing.Size(197, 553)
        Me.pnl_listref.TabIndex = 0
        '
        'pnl_container
        '
        Me.pnl_container.AutoScroll = True
        Me.pnl_container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_container.Location = New System.Drawing.Point(197, 0)
        Me.pnl_container.Name = "pnl_container"
        Me.pnl_container.Size = New System.Drawing.Size(762, 553)
        Me.pnl_container.TabIndex = 1
        '
        'fr_data_referensi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnl_container)
        Me.Controls.Add(Me.pnl_listref)
        Me.Name = "fr_data_referensi"
        Me.Size = New System.Drawing.Size(959, 553)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnl_listref As System.Windows.Forms.Panel
    Friend WithEvents pnl_container As System.Windows.Forms.Panel

End Class
