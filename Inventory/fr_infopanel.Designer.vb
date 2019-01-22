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
        Me.components = New System.ComponentModel.Container()
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lkLbl_user = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnl_piutang = New System.Windows.Forms.Panel()
        Me.in_piutang_totjt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_piutang_custojt = New System.Windows.Forms.Label()
        Me.lbl_piutang_valid = New System.Windows.Forms.Label()
        Me.in_piutang_tot = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbl_piutang_jt = New System.Windows.Forms.Label()
        Me.lbl_piutang_custo = New System.Windows.Forms.Label()
        Me.lkLbl_piutang = New System.Windows.Forms.LinkLabel()
        Me.lbl_piutang = New System.Windows.Forms.Label()
        Me.pnl_orderjual = New System.Windows.Forms.Panel()
        Me.lbl_pesan_aprovedtoday = New System.Windows.Forms.Label()
        Me.lbl_pesan_totpesantoday = New System.Windows.Forms.Label()
        Me.lbl_pesan_validtot = New System.Windows.Forms.Label()
        Me.lbl_pesan_valid = New System.Windows.Forms.Label()
        Me.lkLbl_pesan = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnl_header = New System.Windows.Forms.Panel()
        Me.lbl_date = New System.Windows.Forms.Label()
        Me.lbl_clock = New System.Windows.Forms.Label()
        Me.bt_refreshPnl = New System.Windows.Forms.Button()
        Me.Timer_clock = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.flpnl_container.SuspendLayout()
        Me.pnl_giro.SuspendLayout()
        CType(Me.dgv_giroin_jt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnl_piutang.SuspendLayout()
        Me.pnl_orderjual.SuspendLayout()
        Me.pnl_header.SuspendLayout()
        Me.SuspendLayout()
        '
        'flpnl_container
        '
        Me.flpnl_container.AutoScroll = True
        Me.flpnl_container.Controls.Add(Me.pnl_giro)
        Me.flpnl_container.Controls.Add(Me.Panel1)
        Me.flpnl_container.Controls.Add(Me.pnl_piutang)
        Me.flpnl_container.Controls.Add(Me.pnl_orderjual)
        Me.flpnl_container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpnl_container.Location = New System.Drawing.Point(0, 82)
        Me.flpnl_container.Name = "flpnl_container"
        Me.flpnl_container.Size = New System.Drawing.Size(890, 676)
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
        Me.ck_giro_periode.Location = New System.Drawing.Point(242, 58)
        Me.ck_giro_periode.Name = "ck_giro_periode"
        Me.ck_giro_periode.Size = New System.Drawing.Size(264, 19)
        Me.ck_giro_periode.TabIndex = 4
        Me.ck_giro_periode.Text = "Tampilkan semua BG diterima periode saat ini"
        Me.ck_giro_periode.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lkLbl_user)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(524, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(363, 287)
        Me.Panel1.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "UserID"
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
        'pnl_piutang
        '
        Me.pnl_piutang.BackColor = System.Drawing.Color.Transparent
        Me.pnl_piutang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_piutang.Controls.Add(Me.in_piutang_totjt)
        Me.pnl_piutang.Controls.Add(Me.Label4)
        Me.pnl_piutang.Controls.Add(Me.lbl_piutang_custojt)
        Me.pnl_piutang.Controls.Add(Me.lbl_piutang_valid)
        Me.pnl_piutang.Controls.Add(Me.in_piutang_tot)
        Me.pnl_piutang.Controls.Add(Me.Label8)
        Me.pnl_piutang.Controls.Add(Me.lbl_piutang_jt)
        Me.pnl_piutang.Controls.Add(Me.lbl_piutang_custo)
        Me.pnl_piutang.Controls.Add(Me.lkLbl_piutang)
        Me.pnl_piutang.Controls.Add(Me.lbl_piutang)
        Me.pnl_piutang.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_piutang.Location = New System.Drawing.Point(3, 296)
        Me.pnl_piutang.Name = "pnl_piutang"
        Me.pnl_piutang.Size = New System.Drawing.Size(363, 287)
        Me.pnl_piutang.TabIndex = 3
        '
        'in_piutang_totjt
        '
        Me.in_piutang_totjt.BackColor = System.Drawing.Color.White
        Me.in_piutang_totjt.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_piutang_totjt.Font = New System.Drawing.Font("Open Sans", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_piutang_totjt.Location = New System.Drawing.Point(17, 143)
        Me.in_piutang_totjt.Name = "in_piutang_totjt"
        Me.in_piutang_totjt.ReadOnly = True
        Me.in_piutang_totjt.Size = New System.Drawing.Size(283, 33)
        Me.in_piutang_totjt.TabIndex = 17
        Me.in_piutang_totjt.TabStop = False
        Me.in_piutang_totjt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(4, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 18)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Total Piutang Jatuh Tempo"
        '
        'lbl_piutang_custojt
        '
        Me.lbl_piutang_custojt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_piutang_custojt.AutoSize = True
        Me.lbl_piutang_custojt.Font = New System.Drawing.Font("Open Sans", 9.0!)
        Me.lbl_piutang_custojt.ForeColor = System.Drawing.Color.Black
        Me.lbl_piutang_custojt.Location = New System.Drawing.Point(53, 179)
        Me.lbl_piutang_custojt.Name = "lbl_piutang_custojt"
        Me.lbl_piutang_custojt.Size = New System.Drawing.Size(252, 17)
        Me.lbl_piutang_custojt.TabIndex = 15
        Me.lbl_piutang_custojt.Text = "Dari {0} customer dalam {1} faktur tertagih."
        '
        'lbl_piutang_valid
        '
        Me.lbl_piutang_valid.AutoSize = True
        Me.lbl_piutang_valid.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_piutang_valid.ForeColor = System.Drawing.Color.Black
        Me.lbl_piutang_valid.Location = New System.Drawing.Point(14, 232)
        Me.lbl_piutang_valid.Name = "lbl_piutang_valid"
        Me.lbl_piutang_valid.Size = New System.Drawing.Size(301, 18)
        Me.lbl_piutang_valid.TabIndex = 14
        Me.lbl_piutang_valid.Text = "Total pembayaran piutang menunggu validasi {0}"
        '
        'in_piutang_tot
        '
        Me.in_piutang_tot.BackColor = System.Drawing.Color.White
        Me.in_piutang_tot.Cursor = System.Windows.Forms.Cursors.Default
        Me.in_piutang_tot.Font = New System.Drawing.Font("Open Sans", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_piutang_tot.Location = New System.Drawing.Point(18, 58)
        Me.in_piutang_tot.Name = "in_piutang_tot"
        Me.in_piutang_tot.ReadOnly = True
        Me.in_piutang_tot.Size = New System.Drawing.Size(283, 33)
        Me.in_piutang_tot.TabIndex = 13
        Me.in_piutang_tot.TabStop = False
        Me.in_piutang_tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(5, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 18)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Total Piutang"
        '
        'lbl_piutang_jt
        '
        Me.lbl_piutang_jt.AutoSize = True
        Me.lbl_piutang_jt.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_piutang_jt.ForeColor = System.Drawing.Color.Black
        Me.lbl_piutang_jt.Location = New System.Drawing.Point(14, 210)
        Me.lbl_piutang_jt.Name = "lbl_piutang_jt"
        Me.lbl_piutang_jt.Size = New System.Drawing.Size(269, 18)
        Me.lbl_piutang_jt.TabIndex = 11
        Me.lbl_piutang_jt.Text = "Total faktur tertagih/jatuh tempo hari ini {0}"
        '
        'lbl_piutang_custo
        '
        Me.lbl_piutang_custo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_piutang_custo.AutoSize = True
        Me.lbl_piutang_custo.Font = New System.Drawing.Font("Open Sans", 9.0!)
        Me.lbl_piutang_custo.ForeColor = System.Drawing.Color.Black
        Me.lbl_piutang_custo.Location = New System.Drawing.Point(54, 94)
        Me.lbl_piutang_custo.Name = "lbl_piutang_custo"
        Me.lbl_piutang_custo.Size = New System.Drawing.Size(252, 17)
        Me.lbl_piutang_custo.TabIndex = 10
        Me.lbl_piutang_custo.Text = "Dari {0} customer dalam {1} faktur tertagih."
        '
        'lkLbl_piutang
        '
        Me.lkLbl_piutang.AutoSize = True
        Me.lkLbl_piutang.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lkLbl_piutang.Location = New System.Drawing.Point(166, 253)
        Me.lkLbl_piutang.Name = "lkLbl_piutang"
        Me.lkLbl_piutang.Size = New System.Drawing.Size(192, 17)
        Me.lkLbl_piutang.TabIndex = 8
        Me.lkLbl_piutang.TabStop = True
        Me.lkLbl_piutang.Text = "Daftar Pembayaran Piutang >>"
        '
        'lbl_piutang
        '
        Me.lbl_piutang.AutoSize = True
        Me.lbl_piutang.Font = New System.Drawing.Font("Open Sans", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_piutang.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_piutang.Location = New System.Drawing.Point(3, 3)
        Me.lbl_piutang.Name = "lbl_piutang"
        Me.lbl_piutang.Size = New System.Drawing.Size(208, 26)
        Me.lbl_piutang.TabIndex = 1
        Me.lbl_piutang.Text = "Pembayaran Piutang"
        '
        'pnl_orderjual
        '
        Me.pnl_orderjual.BackColor = System.Drawing.Color.Transparent
        Me.pnl_orderjual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_orderjual.Controls.Add(Me.lbl_pesan_aprovedtoday)
        Me.pnl_orderjual.Controls.Add(Me.lbl_pesan_totpesantoday)
        Me.pnl_orderjual.Controls.Add(Me.lbl_pesan_validtot)
        Me.pnl_orderjual.Controls.Add(Me.lbl_pesan_valid)
        Me.pnl_orderjual.Controls.Add(Me.lkLbl_pesan)
        Me.pnl_orderjual.Controls.Add(Me.Label3)
        Me.pnl_orderjual.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_orderjual.Location = New System.Drawing.Point(372, 296)
        Me.pnl_orderjual.Name = "pnl_orderjual"
        Me.pnl_orderjual.Size = New System.Drawing.Size(515, 287)
        Me.pnl_orderjual.TabIndex = 10
        '
        'lbl_pesan_aprovedtoday
        '
        Me.lbl_pesan_aprovedtoday.AutoSize = True
        Me.lbl_pesan_aprovedtoday.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pesan_aprovedtoday.ForeColor = System.Drawing.Color.Black
        Me.lbl_pesan_aprovedtoday.Location = New System.Drawing.Point(307, 58)
        Me.lbl_pesan_aprovedtoday.Name = "lbl_pesan_aprovedtoday"
        Me.lbl_pesan_aprovedtoday.Size = New System.Drawing.Size(182, 18)
        Me.lbl_pesan_aprovedtoday.TabIndex = 13
        Me.lbl_pesan_aprovedtoday.Text = "Order diterima/diapprove {0}"
        '
        'lbl_pesan_totpesantoday
        '
        Me.lbl_pesan_totpesantoday.AutoSize = True
        Me.lbl_pesan_totpesantoday.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pesan_totpesantoday.ForeColor = System.Drawing.Color.Black
        Me.lbl_pesan_totpesantoday.Location = New System.Drawing.Point(5, 37)
        Me.lbl_pesan_totpesantoday.Name = "lbl_pesan_totpesantoday"
        Me.lbl_pesan_totpesantoday.Size = New System.Drawing.Size(137, 18)
        Me.lbl_pesan_totpesantoday.TabIndex = 12
        Me.lbl_pesan_totpesantoday.Text = "Total order hari ini {0}"
        '
        'lbl_pesan_validtot
        '
        Me.lbl_pesan_validtot.AutoSize = True
        Me.lbl_pesan_validtot.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_pesan_validtot.ForeColor = System.Drawing.Color.Black
        Me.lbl_pesan_validtot.Location = New System.Drawing.Point(5, 99)
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
        Me.lbl_pesan_valid.Location = New System.Drawing.Point(30, 58)
        Me.lbl_pesan_valid.Name = "lbl_pesan_valid"
        Me.lbl_pesan_valid.Size = New System.Drawing.Size(168, 18)
        Me.lbl_pesan_valid.TabIndex = 8
        Me.lbl_pesan_valid.Text = "Order belum tervalidasi {0}"
        '
        'lkLbl_pesan
        '
        Me.lkLbl_pesan.AutoSize = True
        Me.lkLbl_pesan.Font = New System.Drawing.Font("Open Sans", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lkLbl_pesan.Location = New System.Drawing.Point(337, 162)
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
        'pnl_header
        '
        Me.pnl_header.BackColor = System.Drawing.Color.White
        Me.pnl_header.Controls.Add(Me.lbl_date)
        Me.pnl_header.Controls.Add(Me.lbl_clock)
        Me.pnl_header.Controls.Add(Me.bt_refreshPnl)
        Me.pnl_header.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_header.Location = New System.Drawing.Point(0, 0)
        Me.pnl_header.Name = "pnl_header"
        Me.pnl_header.Size = New System.Drawing.Size(890, 82)
        Me.pnl_header.TabIndex = 1
        '
        'lbl_date
        '
        Me.lbl_date.AutoSize = True
        Me.lbl_date.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_date.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_date.Location = New System.Drawing.Point(7, 38)
        Me.lbl_date.Name = "lbl_date"
        Me.lbl_date.Size = New System.Drawing.Size(145, 18)
        Me.lbl_date.TabIndex = 2
        Me.lbl_date.Text = "dddd, dd MMMM yyyy"
        '
        'lbl_clock
        '
        Me.lbl_clock.AutoSize = True
        Me.lbl_clock.Font = New System.Drawing.Font("Open Sans", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_clock.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbl_clock.Location = New System.Drawing.Point(7, 10)
        Me.lbl_clock.Name = "lbl_clock"
        Me.lbl_clock.Size = New System.Drawing.Size(96, 28)
        Me.lbl_clock.TabIndex = 1
        Me.lbl_clock.Text = "00:00:00"
        '
        'bt_refreshPnl
        '
        Me.bt_refreshPnl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_refreshPnl.BackColor = System.Drawing.Color.White
        Me.bt_refreshPnl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_refreshPnl.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_refreshPnl.ForeColor = System.Drawing.Color.MidnightBlue
        Me.bt_refreshPnl.Location = New System.Drawing.Point(785, 53)
        Me.bt_refreshPnl.Name = "bt_refreshPnl"
        Me.bt_refreshPnl.Size = New System.Drawing.Size(90, 23)
        Me.bt_refreshPnl.TabIndex = 0
        Me.bt_refreshPnl.Text = "Refresh"
        Me.bt_refreshPnl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bt_refreshPnl.UseVisualStyleBackColor = False
        '
        'Timer_clock
        '
        '
        'Timer1
        '
        '
        'fr_infopanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.flpnl_container)
        Me.Controls.Add(Me.pnl_header)
        Me.Name = "fr_infopanel"
        Me.Size = New System.Drawing.Size(890, 758)
        Me.flpnl_container.ResumeLayout(False)
        Me.pnl_giro.ResumeLayout(False)
        Me.pnl_giro.PerformLayout()
        CType(Me.dgv_giroin_jt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_piutang.ResumeLayout(False)
        Me.pnl_piutang.PerformLayout()
        Me.pnl_orderjual.ResumeLayout(False)
        Me.pnl_orderjual.PerformLayout()
        Me.pnl_header.ResumeLayout(False)
        Me.pnl_header.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents flpnl_container As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnl_giro As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_giroin_jt As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_giro_current As System.Windows.Forms.Label
    Friend WithEvents ck_giro_periode As System.Windows.Forms.CheckBox
    Friend WithEvents lbl_giro_next30 As System.Windows.Forms.Label
    Friend WithEvents lbl_giro_curperiodetot As System.Windows.Forms.Label
    Friend WithEvents lkLbl_giro_piutang As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lkLbl_user As System.Windows.Forms.LinkLabel
    Friend WithEvents pnl_header As System.Windows.Forms.Panel
    Friend WithEvents bt_refreshPnl As System.Windows.Forms.Button
    Friend WithEvents pnl_piutang As System.Windows.Forms.Panel
    Friend WithEvents lkLbl_piutang As System.Windows.Forms.LinkLabel
    Friend WithEvents lbl_piutang As System.Windows.Forms.Label
    Friend WithEvents pnl_orderjual As System.Windows.Forms.Panel
    Friend WithEvents lbl_pesan_validtot As System.Windows.Forms.Label
    Friend WithEvents lbl_pesan_valid As System.Windows.Forms.Label
    Friend WithEvents lkLbl_pesan As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Timer_clock As System.Windows.Forms.Timer
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbl_piutang_jt As System.Windows.Forms.Label
    Friend WithEvents lbl_pesan_totpesantoday As System.Windows.Forms.Label
    Friend WithEvents lbl_pesan_aprovedtoday As System.Windows.Forms.Label
    Friend WithEvents in_piutang_tot As System.Windows.Forms.TextBox
    Friend WithEvents lbl_piutang_valid As System.Windows.Forms.Label
    Friend WithEvents in_piutang_totjt As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_piutang_custojt As System.Windows.Forms.Label
    Friend WithEvents lbl_piutang_custo As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lbl_date As System.Windows.Forms.Label
    Friend WithEvents lbl_clock As System.Windows.Forms.Label

End Class
