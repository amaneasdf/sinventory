<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_list
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
        Me.dgv_list = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_judul = New System.Windows.Forms.Label()
        Me.mnstrip_main = New System.Windows.Forms.MenuStrip()
        Me.mn_add = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_validasi = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_print = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_export = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_exportExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_bayar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_transedit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_deact = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_bataljual = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_cancelbatal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_cari = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_refresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.svdialog_export = New System.Windows.Forms.SaveFileDialog()
        Me.in_cari = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_pageinfo = New System.Windows.Forms.Label()
        Me.bt_page_next = New System.Windows.Forms.Button()
        Me.bt_page_last = New System.Windows.Forms.Button()
        Me.bt_page_prev = New System.Windows.Forms.Button()
        Me.bt_page_first = New System.Windows.Forms.Button()
        Me.in_page = New System.Windows.Forms.TextBox()
        Me.pnl_top = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbl_date = New System.Windows.Forms.Label()
        Me.date_tglakhir = New System.Windows.Forms.DateTimePicker()
        Me.date_tglawal = New System.Windows.Forms.DateTimePicker()
        Me.bt_search = New System.Windows.Forms.Button()
        Me.pnl_grid = New System.Windows.Forms.Panel()
        Me.mn_addentry = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_delentry = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.mnstrip_main.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnl_top.SuspendLayout()
        Me.pnl_grid.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_list
        '
        Me.dgv_list.AllowUserToAddRows = False
        Me.dgv_list.AllowUserToDeleteRows = False
        Me.dgv_list.AllowUserToResizeRows = False
        Me.dgv_list.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_list.BackgroundColor = System.Drawing.Color.White
        Me.dgv_list.CausesValidation = False
        Me.dgv_list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_list.Location = New System.Drawing.Point(0, 0)
        Me.dgv_list.MultiSelect = False
        Me.dgv_list.Name = "dgv_list"
        Me.dgv_list.ReadOnly = True
        Me.dgv_list.RowHeadersVisible = False
        Me.dgv_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_list.Size = New System.Drawing.Size(950, 431)
        Me.dgv_list.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Orange
        Me.Panel1.Controls.Add(Me.lbl_close)
        Me.Panel1.Controls.Add(Me.bt_cl)
        Me.Panel1.Controls.Add(Me.lbl_judul)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(950, 42)
        Me.Panel1.TabIndex = 2
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Open Sans", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(870, 8)
        Me.lbl_close.Name = "lbl_close"
        Me.lbl_close.Size = New System.Drawing.Size(52, 22)
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
        Me.bt_cl.Location = New System.Drawing.Point(923, 9)
        Me.bt_cl.Name = "bt_cl"
        Me.bt_cl.Size = New System.Drawing.Size(20, 20)
        Me.bt_cl.TabIndex = 8
        Me.bt_cl.TabStop = False
        Me.bt_cl.UseVisualStyleBackColor = False
        '
        'lbl_judul
        '
        Me.lbl_judul.AutoSize = True
        Me.lbl_judul.BackColor = System.Drawing.Color.Orange
        Me.lbl_judul.Font = New System.Drawing.Font("Open Sans", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_judul.ForeColor = System.Drawing.Color.White
        Me.lbl_judul.Location = New System.Drawing.Point(6, 3)
        Me.lbl_judul.Name = "lbl_judul"
        Me.lbl_judul.Size = New System.Drawing.Size(194, 33)
        Me.lbl_judul.TabIndex = 136
        Me.lbl_judul.Text = "Data Perkiraan"
        '
        'mnstrip_main
        '
        Me.mnstrip_main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_add, Me.mn_edit, Me.mn_validasi, Me.mn_print, Me.mn_export, Me.mn_bayar, Me.mn_transedit, Me.mn_refresh})
        Me.mnstrip_main.Location = New System.Drawing.Point(0, 42)
        Me.mnstrip_main.Name = "mnstrip_main"
        Me.mnstrip_main.Size = New System.Drawing.Size(950, 24)
        Me.mnstrip_main.TabIndex = 3
        Me.mnstrip_main.Text = "MenuStrip1"
        '
        'mn_add
        '
        Me.mn_add.Image = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.mn_add.Name = "mn_add"
        Me.mn_add.ShortcutKeyDisplayString = "Ctrl+N"
        Me.mn_add.Size = New System.Drawing.Size(78, 20)
        Me.mn_add.Text = "Tambah"
        Me.mn_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mn_edit
        '
        Me.mn_edit.Image = Global.Inventory.My.Resources.Resources.toolbar_cancel_icon
        Me.mn_edit.Name = "mn_edit"
        Me.mn_edit.ShortcutKeyDisplayString = "Ctrl+O"
        Me.mn_edit.Size = New System.Drawing.Size(82, 20)
        Me.mn_edit.Text = "Edit Data"
        Me.mn_edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mn_validasi
        '
        Me.mn_validasi.Name = "mn_validasi"
        Me.mn_validasi.Size = New System.Drawing.Size(58, 20)
        Me.mn_validasi.Text = "Validasi"
        '
        'mn_print
        '
        Me.mn_print.Image = Global.Inventory.My.Resources.Resources.toolbar_print_icon
        Me.mn_print.Name = "mn_print"
        Me.mn_print.ShortcutKeyDisplayString = "Ctrl+P"
        Me.mn_print.Size = New System.Drawing.Size(60, 20)
        Me.mn_print.Text = "&Print"
        Me.mn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.mn_print.Visible = False
        '
        'mn_export
        '
        Me.mn_export.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_exportExcel})
        Me.mn_export.Name = "mn_export"
        Me.mn_export.Size = New System.Drawing.Size(52, 20)
        Me.mn_export.Text = "&Export"
        '
        'mn_exportExcel
        '
        Me.mn_exportExcel.Name = "mn_exportExcel"
        Me.mn_exportExcel.Size = New System.Drawing.Size(116, 22)
        Me.mn_exportExcel.Text = "To Excel"
        '
        'mn_bayar
        '
        Me.mn_bayar.Name = "mn_bayar"
        Me.mn_bayar.Size = New System.Drawing.Size(48, 20)
        Me.mn_bayar.Text = "Bayar"
        Me.mn_bayar.Visible = False
        '
        'mn_transedit
        '
        Me.mn_transedit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_deact, Me.mn_bataljual, Me.mn_cancelbatal, Me.mn_delete, Me.mn_addentry, Me.mn_delentry, Me.mn_cari})
        Me.mn_transedit.Name = "mn_transedit"
        Me.mn_transedit.Size = New System.Drawing.Size(68, 20)
        Me.mn_transedit.Text = "Lain-Lain"
        '
        'mn_deact
        '
        Me.mn_deact.Name = "mn_deact"
        Me.mn_deact.Size = New System.Drawing.Size(176, 22)
        Me.mn_deact.Text = "De/Activate Data"
        '
        'mn_bataljual
        '
        Me.mn_bataljual.Name = "mn_bataljual"
        Me.mn_bataljual.Size = New System.Drawing.Size(176, 22)
        Me.mn_bataljual.Text = "Batalkan Transaksi"
        '
        'mn_cancelbatal
        '
        Me.mn_cancelbatal.Name = "mn_cancelbatal"
        Me.mn_cancelbatal.Size = New System.Drawing.Size(176, 22)
        Me.mn_cancelbatal.Text = "Cancel Pembatalan"
        '
        'mn_delete
        '
        Me.mn_delete.Name = "mn_delete"
        Me.mn_delete.Size = New System.Drawing.Size(176, 22)
        Me.mn_delete.Text = "Hapus Transaksi"
        '
        'mn_cari
        '
        Me.mn_cari.Name = "mn_cari"
        Me.mn_cari.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.mn_cari.Size = New System.Drawing.Size(176, 22)
        Me.mn_cari.Text = "Cari Data"
        '
        'mn_refresh
        '
        Me.mn_refresh.Name = "mn_refresh"
        Me.mn_refresh.ShortcutKeyDisplayString = "F5"
        Me.mn_refresh.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mn_refresh.Size = New System.Drawing.Size(58, 20)
        Me.mn_refresh.Text = "Refresh"
        '
        'in_cari
        '
        Me.in_cari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari.Location = New System.Drawing.Point(386, 9)
        Me.in_cari.MaxLength = 100
        Me.in_cari.Name = "in_cari"
        Me.in_cari.Size = New System.Drawing.Size(248, 22)
        Me.in_cari.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lbl_pageinfo)
        Me.Panel2.Controls.Add(Me.bt_page_next)
        Me.Panel2.Controls.Add(Me.bt_page_last)
        Me.Panel2.Controls.Add(Me.bt_page_prev)
        Me.Panel2.Controls.Add(Me.bt_page_first)
        Me.Panel2.Controls.Add(Me.in_page)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 534)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(950, 42)
        Me.Panel2.TabIndex = 4
        '
        'lbl_pageinfo
        '
        Me.lbl_pageinfo.AutoSize = True
        Me.lbl_pageinfo.Location = New System.Drawing.Point(9, 17)
        Me.lbl_pageinfo.Name = "lbl_pageinfo"
        Me.lbl_pageinfo.Size = New System.Drawing.Size(81, 15)
        Me.lbl_pageinfo.TabIndex = 23
        Me.lbl_pageinfo.Text = "0-0 dari 0 data"
        '
        'bt_page_next
        '
        Me.bt_page_next.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_page_next.BackColor = System.Drawing.Color.White
        Me.bt_page_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_page_next.Location = New System.Drawing.Point(877, 6)
        Me.bt_page_next.Name = "bt_page_next"
        Me.bt_page_next.Size = New System.Drawing.Size(30, 30)
        Me.bt_page_next.TabIndex = 21
        Me.bt_page_next.Text = ">"
        Me.bt_page_next.UseVisualStyleBackColor = False
        '
        'bt_page_last
        '
        Me.bt_page_last.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_page_last.BackColor = System.Drawing.Color.White
        Me.bt_page_last.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_page_last.Location = New System.Drawing.Point(913, 6)
        Me.bt_page_last.Name = "bt_page_last"
        Me.bt_page_last.Size = New System.Drawing.Size(30, 30)
        Me.bt_page_last.TabIndex = 22
        Me.bt_page_last.Text = ">>"
        Me.bt_page_last.UseVisualStyleBackColor = False
        '
        'bt_page_prev
        '
        Me.bt_page_prev.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_page_prev.BackColor = System.Drawing.Color.White
        Me.bt_page_prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_page_prev.Location = New System.Drawing.Point(789, 6)
        Me.bt_page_prev.Name = "bt_page_prev"
        Me.bt_page_prev.Size = New System.Drawing.Size(30, 30)
        Me.bt_page_prev.TabIndex = 19
        Me.bt_page_prev.Text = "<"
        Me.bt_page_prev.UseVisualStyleBackColor = False
        '
        'bt_page_first
        '
        Me.bt_page_first.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_page_first.BackColor = System.Drawing.Color.White
        Me.bt_page_first.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_page_first.Location = New System.Drawing.Point(753, 6)
        Me.bt_page_first.Name = "bt_page_first"
        Me.bt_page_first.Size = New System.Drawing.Size(30, 30)
        Me.bt_page_first.TabIndex = 18
        Me.bt_page_first.Text = "<<"
        Me.bt_page_first.UseVisualStyleBackColor = False
        '
        'in_page
        '
        Me.in_page.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.in_page.Location = New System.Drawing.Point(825, 10)
        Me.in_page.Name = "in_page"
        Me.in_page.ReadOnly = True
        Me.in_page.Size = New System.Drawing.Size(46, 22)
        Me.in_page.TabIndex = 20
        Me.in_page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pnl_top
        '
        Me.pnl_top.BackColor = System.Drawing.Color.White
        Me.pnl_top.Controls.Add(Me.Button1)
        Me.pnl_top.Controls.Add(Me.lbl_date)
        Me.pnl_top.Controls.Add(Me.date_tglakhir)
        Me.pnl_top.Controls.Add(Me.date_tglawal)
        Me.pnl_top.Controls.Add(Me.bt_search)
        Me.pnl_top.Controls.Add(Me.in_cari)
        Me.pnl_top.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_top.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_top.Location = New System.Drawing.Point(0, 66)
        Me.pnl_top.Name = "pnl_top"
        Me.pnl_top.Size = New System.Drawing.Size(950, 37)
        Me.pnl_top.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.BackgroundImage = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(901, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(42, 22)
        Me.Button1.TabIndex = 21
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'lbl_date
        '
        Me.lbl_date.AutoSize = True
        Me.lbl_date.Location = New System.Drawing.Point(183, 13)
        Me.lbl_date.Name = "lbl_date"
        Me.lbl_date.Size = New System.Drawing.Size(26, 15)
        Me.lbl_date.TabIndex = 0
        Me.lbl_date.Text = "S.d."
        '
        'date_tglakhir
        '
        Me.date_tglakhir.CustomFormat = "dd MMM yyyy"
        Me.date_tglakhir.Location = New System.Drawing.Point(215, 9)
        Me.date_tglakhir.Name = "date_tglakhir"
        Me.date_tglakhir.Size = New System.Drawing.Size(165, 22)
        Me.date_tglakhir.TabIndex = 1
        '
        'date_tglawal
        '
        Me.date_tglawal.CustomFormat = "dd MMM yyyy"
        Me.date_tglawal.Location = New System.Drawing.Point(12, 9)
        Me.date_tglawal.Name = "date_tglawal"
        Me.date_tglawal.Size = New System.Drawing.Size(165, 22)
        Me.date_tglawal.TabIndex = 0
        '
        'bt_search
        '
        Me.bt_search.BackColor = System.Drawing.Color.WhiteSmoke
        Me.bt_search.BackgroundImage = Global.Inventory.My.Resources.Resources.Search_16x16
        Me.bt_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.bt_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_search.Location = New System.Drawing.Point(633, 9)
        Me.bt_search.Name = "bt_search"
        Me.bt_search.Size = New System.Drawing.Size(42, 22)
        Me.bt_search.TabIndex = 20
        Me.bt_search.UseVisualStyleBackColor = False
        '
        'pnl_grid
        '
        Me.pnl_grid.Controls.Add(Me.dgv_list)
        Me.pnl_grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_grid.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_grid.Location = New System.Drawing.Point(0, 103)
        Me.pnl_grid.Name = "pnl_grid"
        Me.pnl_grid.Size = New System.Drawing.Size(950, 431)
        Me.pnl_grid.TabIndex = 5
        '
        'mn_addentry
        '
        Me.mn_addentry.Name = "mn_addentry"
        Me.mn_addentry.Size = New System.Drawing.Size(176, 22)
        Me.mn_addentry.Text = "Tambah Entry"
        '
        'mn_delentry
        '
        Me.mn_delentry.Name = "mn_delentry"
        Me.mn_delentry.Size = New System.Drawing.Size(176, 22)
        Me.mn_delentry.Text = "Delete Entry"
        '
        'fr_list
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnl_grid)
        Me.Controls.Add(Me.pnl_top)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.mnstrip_main)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "fr_list"
        Me.Size = New System.Drawing.Size(950, 576)
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.mnstrip_main.ResumeLayout(False)
        Me.mnstrip_main.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnl_top.ResumeLayout(False)
        Me.pnl_top.PerformLayout()
        Me.pnl_grid.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_list As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_judul As System.Windows.Forms.Label
    Friend WithEvents mnstrip_main As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_add As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents mn_refresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_export As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_exportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_bayar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_validasi As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents svdialog_export As System.Windows.Forms.SaveFileDialog
    Friend WithEvents mn_transedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_deact As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_bataljual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_cancelbatal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_cari As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents in_cari As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnl_top As System.Windows.Forms.Panel
    Friend WithEvents bt_page_next As System.Windows.Forms.Button
    Friend WithEvents bt_page_last As System.Windows.Forms.Button
    Friend WithEvents bt_page_prev As System.Windows.Forms.Button
    Friend WithEvents bt_page_first As System.Windows.Forms.Button
    Friend WithEvents in_page As System.Windows.Forms.TextBox
    Friend WithEvents bt_search As System.Windows.Forms.Button
    Friend WithEvents lbl_pageinfo As System.Windows.Forms.Label
    Friend WithEvents pnl_grid As System.Windows.Forms.Panel
    Friend WithEvents lbl_date As System.Windows.Forms.Label
    Friend WithEvents date_tglakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_tglawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents mn_addentry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_delentry As System.Windows.Forms.ToolStripMenuItem

End Class
