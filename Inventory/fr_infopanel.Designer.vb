<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_infopanel
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
        Me.flpnl_container = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnl_giro = New System.Windows.Forms.Panel()
        Me.lkLbl_giro_piutang = New System.Windows.Forms.LinkLabel()
        Me.lbl_giro_curperiodetot = New System.Windows.Forms.Label()
        Me.lbl_giro_next30 = New System.Windows.Forms.Label()
        Me.lbl_giro_current = New System.Windows.Forms.Label()
        Me.dgv_giroin_jt = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ck_giro_periode = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lkLbl_user = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnl_orderjual = New System.Windows.Forms.Panel()
        Me.lbl_pesan_validtot = New System.Windows.Forms.Label()
        Me.lbl_pesan_valid = New System.Windows.Forms.Label()
        Me.lkLbl_pesan = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnl_piutang = New System.Windows.Forms.Panel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.flpnl_container.SuspendLayout()
        Me.pnl_giro.SuspendLayout()
        CType(Me.dgv_giroin_jt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnl_orderjual.SuspendLayout()
        Me.pnl_piutang.SuspendLayout()
        Me.SuspendLayout()
        '
        'flpnl_container
        '
        Me.flpnl_container.Controls.Add(Me.pnl_giro)
        Me.flpnl_container.Controls.Add(Me.Panel1)
        Me.flpnl_container.Controls.Add(Me.pnl_orderjual)
        Me.flpnl_container.Controls.Add(Me.pnl_piutang)
        Me.flpnl_container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpnl_container.Location = New System.Drawing.Point(0, 0)
        Me.flpnl_container.Name = "flpnl_container"
        Me.flpnl_container.Size = New System.Drawing.Size(890, 747)
        Me.flpnl_container.TabIndex = 0
        '
        'pnl_giro
        '
        Me.pnl_giro.BackColor = System.Drawing.Color.Transparent
        Me.pnl_giro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_giro.Controls.Add(Me.lkLbl_giro_piutang)
        Me.pnl_giro.Controls.Add(Me.lbl_giro_curperiodetot)
        Me.pnl_giro.Controls.Add(Me.lbl_giro_next30)
        Me.pnl_giro.Controls.Add(Me.lbl_giro_current)
        Me.pnl_giro.Controls.Add(Me.dgv_giroin_jt)
        Me.pnl_giro.Controls.Add(Me.Label2)
        Me.pnl_giro.Controls.Add(Me.Label1)
        Me.pnl_giro.Controls.Add(Me.ck_giro_periode)
        Me.pnl_giro.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_giro.Location = New System.Drawing.Point(3, 3)
        Me.pnl_giro.Name = "pnl_giro"
        Me.pnl_giro.Size = New System.Drawing.Size(515, 287)
        Me.pnl_giro.TabIndex = 0
        '
        'lkLbl_giro_piutang
        '
        Me.lkLbl_giro_piutang.AutoSize = True
        Me.lkLbl_giro_piutang.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lkLbl_giro_piutang.Location = New System.Drawing.Point(365, 255)
        Me.lkLbl_giro_piutang.Name = "lkLbl_giro_piutang"
        Me.lkLbl_giro_piutang.Size = New System.Drawing.Size(141, 17)
        Me.lkLbl_giro_piutang.TabIndex = 7
        Me.lkLbl_giro_piutang.TabStop = True
        Me.lkLbl_giro_piutang.Text = "Daftar Piutang Giro >>"
        '
        'lbl_giro_curperiodetot
        '
        Me.lbl_giro_curperiodetot.AutoSize = True
        Me.lbl_giro_curperiodetot.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_giro_curperiodetot.ForeColor = System.Drawing.Color.Black
        Me.lbl_giro_curperiodetot.Location = New System.Drawing.Point(4, 217)
        Me.lbl_giro_curperiodetot.Name = "lbl_giro_curperiodetot"
        Me.lbl_giro_curperiodetot.Size = New System.Drawing.Size(386, 17)
        Me.lbl_giro_curperiodetot.TabIndex = 5
        Me.lbl_giro_curperiodetot.Text = "Total BG diterima periode saat ini {0}, telah dicairkan {1}, ditolak {2}"
        '
        'lbl_giro_next30
        '
        Me.lbl_giro_next30.AutoSize = True
        Me.lbl_giro_next30.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_giro_next30.ForeColor = System.Drawing.Color.Black
        Me.lbl_giro_next30.Location = New System.Drawing.Point(282, 34)
        Me.lbl_giro_next30.Name = "lbl_giro_next30"
        Me.lbl_giro_next30.Size = New System.Drawing.Size(224, 18)
        Me.lbl_giro_next30.TabIndex = 5
        Me.lbl_giro_next30.Text = "BG Jatuh Tempo 30 Hari kedepan {0}"
        '
        'lbl_giro_current
        '
        Me.lbl_giro_current.AutoSize = True
        Me.lbl_giro_current.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_giro_current.ForeColor = System.Drawing.Color.Black
        Me.lbl_giro_current.Location = New System.Drawing.Point(4, 34)
        Me.lbl_giro_current.Name = "lbl_giro_current"
        Me.lbl_giro_current.Size = New System.Drawing.Size(169, 18)
        Me.lbl_giro_current.TabIndex = 3
        Me.lbl_giro_current.Text = "BG Jatuh Tempo Hari ini {0}"
        '
        'dgv_giroin_jt
        '
        Me.dgv_giroin_jt.AllowUserToAddRows = False
        Me.dgv_giroin_jt.AllowUserToDeleteRows = False
        Me.dgv_giroin_jt.BackgroundColor = System.Drawing.Color.White
        Me.dgv_giroin_jt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_giroin_jt.Location = New System.Drawing.Point(7, 80)
        Me.dgv_giroin_jt.MultiSelect = False
        Me.dgv_giroin_jt.Name = "dgv_giroin_jt"
        Me.dgv_giroin_jt.ReadOnly = True
        Me.dgv_giroin_jt.RowHeadersVisible = False
        Me.dgv_giroin_jt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_giroin_jt.Size = New System.Drawing.Size(499, 134)
        Me.dgv_giroin_jt.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(4, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "List BG"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Open Sans", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bilyet Giro Diterima"
        '
        'ck_giro_periode
        '
        Me.ck_giro_periode.AutoSize = True
        Me.ck_giro_periode.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ck_giro_periode.Location = New System.Drawing.Point(346, 61)
        Me.ck_giro_periode.Name = "ck_giro_periode"
        Me.ck_giro_periode.Size = New System.Drawing.Size(160, 19)
        Me.ck_giro_periode.TabIndex = 4
        Me.ck_giro_periode.Text = "Filter Giro Periode saat ini"
        Me.ck_giro_periode.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lkLbl_user)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(524, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(363, 287)
        Me.Panel1.TabIndex = 2
        '
        'lkLbl_user
        '
        Me.lkLbl_user.AutoSize = True
        Me.lkLbl_user.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lkLbl_user.Location = New System.Drawing.Point(257, 255)
        Me.lkLbl_user.Name = "lkLbl_user"
        Me.lkLbl_user.Size = New System.Drawing.Size(93, 17)
        Me.lkLbl_user.TabIndex = 8
        Me.lkLbl_user.TabStop = True
        Me.lkLbl_user.Text = "Daftar User >>"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Open Sans", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.Location = New System.Drawing.Point(3, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 26)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Data User"
        '
        'pnl_orderjual
        '
        Me.pnl_orderjual.BackColor = System.Drawing.Color.Transparent
        Me.pnl_orderjual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_orderjual.Controls.Add(Me.lbl_pesan_validtot)
        Me.pnl_orderjual.Controls.Add(Me.lbl_pesan_valid)
        Me.pnl_orderjual.Controls.Add(Me.lkLbl_pesan)
        Me.pnl_orderjual.Controls.Add(Me.Label3)
        Me.pnl_orderjual.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_orderjual.Location = New System.Drawing.Point(3, 296)
        Me.pnl_orderjual.Name = "pnl_orderjual"
        Me.pnl_orderjual.Size = New System.Drawing.Size(515, 287)
        Me.pnl_orderjual.TabIndex = 1
        '
        'lbl_pesan_validtot
        '
        Me.lbl_pesan_validtot.AutoSize = True
        Me.lbl_pesan_validtot.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pesan_validtot.ForeColor = System.Drawing.Color.Black
        Me.lbl_pesan_validtot.Location = New System.Drawing.Point(5, 55)
        Me.lbl_pesan_validtot.Name = "lbl_pesan_validtot"
        Me.lbl_pesan_validtot.Size = New System.Drawing.Size(293, 18)
        Me.lbl_pesan_validtot.TabIndex = 9
        Me.lbl_pesan_validtot.Text = "Total order belum tervalidasi periode saat ini {0}"
        '
        'lbl_pesan_valid
        '
        Me.lbl_pesan_valid.AutoSize = True
        Me.lbl_pesan_valid.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pesan_valid.ForeColor = System.Drawing.Color.Black
        Me.lbl_pesan_valid.Location = New System.Drawing.Point(5, 37)
        Me.lbl_pesan_valid.Name = "lbl_pesan_valid"
        Me.lbl_pesan_valid.Size = New System.Drawing.Size(168, 18)
        Me.lbl_pesan_valid.TabIndex = 8
        Me.lbl_pesan_valid.Text = "Order belum tervalidasi {0}"
        '
        'lkLbl_pesan
        '
        Me.lkLbl_pesan.AutoSize = True
        Me.lkLbl_pesan.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lkLbl_pesan.Location = New System.Drawing.Point(341, 258)
        Me.lkLbl_pesan.Name = "lkLbl_pesan"
        Me.lkLbl_pesan.Size = New System.Drawing.Size(165, 17)
        Me.lkLbl_pesan.TabIndex = 7
        Me.lkLbl_pesan.TabStop = True
        Me.lkLbl_pesan.Text = "Daftar Order Penjualan >>"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Open Sans", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(166, 26)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Order Penjualan"
        '
        'pnl_piutang
        '
        Me.pnl_piutang.BackColor = System.Drawing.Color.Transparent
        Me.pnl_piutang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_piutang.Controls.Add(Me.LinkLabel1)
        Me.pnl_piutang.Controls.Add(Me.Label4)
        Me.pnl_piutang.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_piutang.Location = New System.Drawing.Point(524, 296)
        Me.pnl_piutang.Name = "pnl_piutang"
        Me.pnl_piutang.Size = New System.Drawing.Size(363, 287)
        Me.pnl_piutang.TabIndex = 3
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(257, 255)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(93, 17)
        Me.LinkLabel1.TabIndex = 8
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Daftar User >>"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Open Sans", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(3, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 26)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Data User"
        '
        'fr_infopanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.flpnl_container)
        Me.Name = "fr_infopanel"
        Me.Size = New System.Drawing.Size(890, 747)
        Me.flpnl_container.ResumeLayout(False)
        Me.pnl_giro.ResumeLayout(False)
        Me.pnl_giro.PerformLayout()
        CType(Me.dgv_giroin_jt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_orderjual.ResumeLayout(False)
        Me.pnl_orderjual.PerformLayout()
        Me.pnl_piutang.ResumeLayout(False)
        Me.pnl_piutang.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents flpnl_container As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnl_giro As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_giroin_jt As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnl_orderjual As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_giro_current As System.Windows.Forms.Label
    Friend WithEvents ck_giro_periode As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_giro_next30 As System.Windows.Forms.Label
    Friend WithEvents lbl_giro_curperiodetot As System.Windows.Forms.Label
    Friend WithEvents lkLbl_giro_piutang As System.Windows.Forms.LinkLabel
    Friend WithEvents lkLbl_pesan As System.Windows.Forms.LinkLabel
    Friend WithEvents lbl_pesan_validtot As System.Windows.Forms.Label
    Friend WithEvents lbl_pesan_valid As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lkLbl_user As System.Windows.Forms.LinkLabel
    Friend WithEvents pnl_piutang As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
