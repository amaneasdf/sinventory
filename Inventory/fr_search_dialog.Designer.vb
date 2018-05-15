<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_search_dialog
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
        Me.in_cari = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_judul = New System.Windows.Forms.Label()
        Me.bt_search = New System.Windows.Forms.Button()
        Me.dgv_list = New System.Windows.Forms.DataGridView()
        Me.bt_ok = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'in_cari
        '
        Me.in_cari.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari.Location = New System.Drawing.Point(12, 51)
        Me.in_cari.Name = "in_cari"
        Me.in_cari.Size = New System.Drawing.Size(425, 26)
        Me.in_cari.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.lbl_judul)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(559, 42)
        Me.Panel1.TabIndex = 183
        '
        'lbl_judul
        '
        Me.lbl_judul.AutoSize = True
        Me.lbl_judul.BackColor = System.Drawing.Color.Orange
        Me.lbl_judul.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_judul.Location = New System.Drawing.Point(8, 9)
        Me.lbl_judul.Name = "lbl_judul"
        Me.lbl_judul.Size = New System.Drawing.Size(65, 20)
        Me.lbl_judul.TabIndex = 178
        Me.lbl_judul.Text = "Daftar "
        '
        'bt_search
        '
        Me.bt_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_search.Location = New System.Drawing.Point(443, 48)
        Me.bt_search.Name = "bt_search"
        Me.bt_search.Size = New System.Drawing.Size(104, 32)
        Me.bt_search.TabIndex = 184
        Me.bt_search.Text = "Cari"
        Me.bt_search.UseVisualStyleBackColor = True
        '
        'dgv_list
        '
        Me.dgv_list.AllowUserToAddRows = False
        Me.dgv_list.AllowUserToDeleteRows = False
        Me.dgv_list.BackgroundColor = System.Drawing.Color.White
        Me.dgv_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_list.Location = New System.Drawing.Point(0, 86)
        Me.dgv_list.Name = "dgv_list"
        Me.dgv_list.ReadOnly = True
        Me.dgv_list.Size = New System.Drawing.Size(559, 393)
        Me.dgv_list.TabIndex = 185
        '
        'bt_ok
        '
        Me.bt_ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_ok.Location = New System.Drawing.Point(443, 485)
        Me.bt_ok.Name = "bt_ok"
        Me.bt_ok.Size = New System.Drawing.Size(104, 32)
        Me.bt_ok.TabIndex = 184
        Me.bt_ok.Text = "OK"
        Me.bt_ok.UseVisualStyleBackColor = True
        '
        'fr_search_dialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 529)
        Me.Controls.Add(Me.dgv_list)
        Me.Controls.Add(Me.bt_ok)
        Me.Controls.Add(Me.bt_search)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.in_cari)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "fr_search_dialog"
        Me.Text = "Cari"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents in_cari As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_judul As System.Windows.Forms.Label
    Friend WithEvents bt_search As System.Windows.Forms.Button
    Friend WithEvents dgv_list As System.Windows.Forms.DataGridView
    Friend WithEvents bt_ok As System.Windows.Forms.Button
End Class
