<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_ref_areacusto
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_ket = New System.Windows.Forms.Label()
        Me.lbl_combo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rb_inactive = New System.Windows.Forms.RadioButton()
        Me.rb_active = New System.Windows.Forms.RadioButton()
        Me.in_ket = New System.Windows.Forms.TextBox()
        Me.in_nama = New System.Windows.Forms.TextBox()
        Me.cb_op = New System.Windows.Forms.ComboBox()
        Me.in_id = New System.Windows.Forms.TextBox()
        Me.bt_del = New System.Windows.Forms.Button()
        Me.bt_simpanbeli = New System.Windows.Forms.Button()
        Me.bt_batalbeli = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.lbl_title)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(657, 34)
        Me.Panel1.TabIndex = 0
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
        Me.bt_cl.Location = New System.Drawing.Point(630, 6)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 8
        Me.bt_cl.TabStop = False
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.BackColor = System.Drawing.Color.Orange
        Me.lbl_title.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(6, 6)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(32, 20)
        Me.lbl_title.TabIndex = 0
        Me.lbl_title.Text = "Ref"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.lbl_ket)
        Me.Panel2.Controls.Add(Me.lbl_combo)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.rb_inactive)
        Me.Panel2.Controls.Add(Me.rb_active)
        Me.Panel2.Controls.Add(Me.in_ket)
        Me.Panel2.Controls.Add(Me.in_nama)
        Me.Panel2.Controls.Add(Me.cb_op)
        Me.Panel2.Controls.Add(Me.in_id)
        Me.Panel2.Controls.Add(Me.bt_del)
        Me.Panel2.Controls.Add(Me.bt_simpanbeli)
        Me.Panel2.Controls.Add(Me.bt_batalbeli)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(657, 198)
        Me.Panel2.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 15)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Status"
        '
        'lbl_ket
        '
        Me.lbl_ket.AutoSize = True
        Me.lbl_ket.Location = New System.Drawing.Point(7, 83)
        Me.lbl_ket.Name = "lbl_ket"
        Me.lbl_ket.Size = New System.Drawing.Size(66, 15)
        Me.lbl_ket.TabIndex = 44
        Me.lbl_ket.Text = "Keterangan"
        '
        'lbl_combo
        '
        Me.lbl_combo.AutoSize = True
        Me.lbl_combo.Location = New System.Drawing.Point(7, 57)
        Me.lbl_combo.Name = "lbl_combo"
        Me.lbl_combo.Size = New System.Drawing.Size(64, 15)
        Me.lbl_combo.TabIndex = 44
        Me.lbl_combo.Text = "Kabupaten"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 15)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Nama Ref."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 15)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Kode Ref"
        '
        'rb_inactive
        '
        Me.rb_inactive.AutoSize = True
        Me.rb_inactive.Location = New System.Drawing.Point(153, 128)
        Me.rb_inactive.Name = "rb_inactive"
        Me.rb_inactive.Size = New System.Drawing.Size(75, 19)
        Me.rb_inactive.TabIndex = 5
        Me.rb_inactive.TabStop = True
        Me.rb_inactive.Text = "Non-Aktif"
        Me.rb_inactive.UseVisualStyleBackColor = True
        '
        'rb_active
        '
        Me.rb_active.AutoSize = True
        Me.rb_active.Location = New System.Drawing.Point(79, 128)
        Me.rb_active.Name = "rb_active"
        Me.rb_active.Size = New System.Drawing.Size(49, 19)
        Me.rb_active.TabIndex = 4
        Me.rb_active.TabStop = True
        Me.rb_active.Text = "Aktif"
        Me.rb_active.UseVisualStyleBackColor = True
        '
        'in_ket
        '
        Me.in_ket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_ket.Location = New System.Drawing.Point(79, 79)
        Me.in_ket.MaxLength = 255
        Me.in_ket.Multiline = True
        Me.in_ket.Name = "in_ket"
        Me.in_ket.Size = New System.Drawing.Size(354, 46)
        Me.in_ket.TabIndex = 3
        '
        'in_nama
        '
        Me.in_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_nama.Location = New System.Drawing.Point(79, 30)
        Me.in_nama.MaxLength = 100
        Me.in_nama.Name = "in_nama"
        Me.in_nama.Size = New System.Drawing.Size(354, 22)
        Me.in_nama.TabIndex = 1
        '
        'cb_op
        '
        Me.cb_op.FormattingEnabled = True
        Me.cb_op.Location = New System.Drawing.Point(79, 54)
        Me.cb_op.Name = "cb_op"
        Me.cb_op.Size = New System.Drawing.Size(221, 23)
        Me.cb_op.TabIndex = 2
        '
        'in_id
        '
        Me.in_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_id.Location = New System.Drawing.Point(79, 6)
        Me.in_id.MaxLength = 100
        Me.in_id.Name = "in_id"
        Me.in_id.ReadOnly = True
        Me.in_id.Size = New System.Drawing.Size(221, 22)
        Me.in_id.TabIndex = 0
        '
        'bt_del
        '
        Me.bt_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_del.Image = Global.Inventory.My.Resources.Resources.Delete_16x16
        Me.bt_del.Location = New System.Drawing.Point(10, 162)
        Me.bt_del.Name = "bt_del"
        Me.bt_del.Size = New System.Drawing.Size(100, 29)
        Me.bt_del.TabIndex = 6
        Me.bt_del.Text = "   Hapus"
        Me.bt_del.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bt_del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_del.UseVisualStyleBackColor = True
        '
        'bt_simpanbeli
        '
        Me.bt_simpanbeli.BackColor = System.Drawing.Color.RoyalBlue
        Me.bt_simpanbeli.FlatAppearance.BorderSize = 0
        Me.bt_simpanbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_simpanbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_simpanbeli.ForeColor = System.Drawing.Color.White
        Me.bt_simpanbeli.Location = New System.Drawing.Point(377, 162)
        Me.bt_simpanbeli.Name = "bt_simpanbeli"
        Me.bt_simpanbeli.Size = New System.Drawing.Size(171, 30)
        Me.bt_simpanbeli.TabIndex = 7
        Me.bt_simpanbeli.Text = "Simpan"
        Me.bt_simpanbeli.UseVisualStyleBackColor = False
        '
        'bt_batalbeli
        '
        Me.bt_batalbeli.BackColor = System.Drawing.Color.Tomato
        Me.bt_batalbeli.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bt_batalbeli.FlatAppearance.BorderSize = 0
        Me.bt_batalbeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_batalbeli.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_batalbeli.ForeColor = System.Drawing.Color.White
        Me.bt_batalbeli.Location = New System.Drawing.Point(554, 162)
        Me.bt_batalbeli.Name = "bt_batalbeli"
        Me.bt_batalbeli.Size = New System.Drawing.Size(96, 30)
        Me.bt_batalbeli.TabIndex = 8
        Me.bt_batalbeli.Text = "Batal"
        Me.bt_batalbeli.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Orange
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 232)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(657, 10)
        Me.Panel3.TabIndex = 0
        '
        'fr_ref_areacusto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.bt_batalbeli
        Me.ClientSize = New System.Drawing.Size(657, 242)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fr_ref_areacusto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fr_ref_areacusto"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents bt_simpanbeli As System.Windows.Forms.Button
    Friend WithEvents bt_batalbeli As System.Windows.Forms.Button
    Friend WithEvents bt_del As System.Windows.Forms.Button
    Friend WithEvents in_id As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ket As System.Windows.Forms.Label
    Friend WithEvents lbl_combo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rb_inactive As System.Windows.Forms.RadioButton
    Friend WithEvents rb_active As System.Windows.Forms.RadioButton
    Friend WithEvents in_ket As System.Windows.Forms.TextBox
    Friend WithEvents in_nama As System.Windows.Forms.TextBox
    Friend WithEvents cb_op As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
