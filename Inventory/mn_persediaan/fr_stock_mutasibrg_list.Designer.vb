<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fr_stock_mutasibrg_list
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fr_stock_mutasibrg_list))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_close = New System.Windows.Forms.Label()
        Me.bt_cl = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.pnl_Menu = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgv_list = New System.Windows.Forms.DataGridView()
        Me.dgv_barang = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lbl_pageinfo = New System.Windows.Forms.Label()
        Me.bt_page_next = New System.Windows.Forms.Button()
        Me.bt_page_last = New System.Windows.Forms.Button()
        Me.bt_page_prev = New System.Windows.Forms.Button()
        Me.bt_page_first = New System.Windows.Forms.Button()
        Me.in_page = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbl_date = New System.Windows.Forms.Label()
        Me.date_tglakhir = New System.Windows.Forms.DateTimePicker()
        Me.date_tglawal = New System.Windows.Forms.DateTimePicker()
        Me.bt_search = New System.Windows.Forms.Button()
        Me.in_cari = New System.Windows.Forms.TextBox()
        Me.mnstrip_main = New System.Windows.Forms.MenuStrip()
        Me.mn_tambah = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_print = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_export = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_exportExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_other = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_uncancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mn_search = New System.Windows.Forms.ToolStripMenuItem()
        Me.mn_refresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        Me.pnl_Menu.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.mnstrip_main.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(950, 42)
        Me.Panel1.TabIndex = 3
        '
        'lbl_close
        '
        Me.lbl_close.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_close.AutoSize = True
        Me.lbl_close.BackColor = System.Drawing.Color.Orange
        Me.lbl_close.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_close.ForeColor = System.Drawing.Color.White
        Me.lbl_close.Location = New System.Drawing.Point(870, 9)
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
        Me.bt_cl.Location = New System.Drawing.Point(923, 9)
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
        Me.lbl_title.Font = New System.Drawing.Font("Source Sans Pro", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.ForeColor = System.Drawing.Color.White
        Me.lbl_title.Location = New System.Drawing.Point(3, 4)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(223, 31)
        Me.lbl_title.TabIndex = 136
        Me.lbl_title.Text = "Data Mutasi Barang"
        '
        'pnl_Menu
        '
        Me.pnl_Menu.BackColor = System.Drawing.Color.White
        Me.pnl_Menu.Controls.Add(Me.SplitContainer1)
        Me.pnl_Menu.Controls.Add(Me.Panel2)
        Me.pnl_Menu.Controls.Add(Me.Panel3)
        Me.pnl_Menu.Controls.Add(Me.mnstrip_main)
        Me.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_Menu.Location = New System.Drawing.Point(0, 42)
        Me.pnl_Menu.Name = "pnl_Menu"
        Me.pnl_Menu.Size = New System.Drawing.Size(950, 534)
        Me.pnl_Menu.TabIndex = 249
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 61)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgv_list)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgv_barang)
        Me.SplitContainer1.Size = New System.Drawing.Size(950, 431)
        Me.SplitContainer1.SplitterDistance = 822
        Me.SplitContainer1.TabIndex = 0
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
        Me.dgv_list.Size = New System.Drawing.Size(822, 431)
        Me.dgv_list.TabIndex = 0
        '
        'dgv_barang
        '
        Me.dgv_barang.AllowUserToAddRows = False
        Me.dgv_barang.AllowUserToDeleteRows = False
        Me.dgv_barang.AllowUserToResizeRows = False
        Me.dgv_barang.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv_barang.BackgroundColor = System.Drawing.Color.White
        Me.dgv_barang.CausesValidation = False
        Me.dgv_barang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_barang.Location = New System.Drawing.Point(0, 0)
        Me.dgv_barang.MultiSelect = False
        Me.dgv_barang.Name = "dgv_barang"
        Me.dgv_barang.ReadOnly = True
        Me.dgv_barang.RowHeadersVisible = False
        Me.dgv_barang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_barang.Size = New System.Drawing.Size(124, 431)
        Me.dgv_barang.TabIndex = 1
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
        Me.Panel2.Location = New System.Drawing.Point(0, 492)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(950, 42)
        Me.Panel2.TabIndex = 2
        '
        'lbl_pageinfo
        '
        Me.lbl_pageinfo.AutoSize = True
        Me.lbl_pageinfo.Location = New System.Drawing.Point(9, 13)
        Me.lbl_pageinfo.Name = "lbl_pageinfo"
        Me.lbl_pageinfo.Size = New System.Drawing.Size(41, 15)
        Me.lbl_pageinfo.TabIndex = 23
        Me.lbl_pageinfo.Text = "Label1"
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.lbl_date)
        Me.Panel3.Controls.Add(Me.date_tglakhir)
        Me.Panel3.Controls.Add(Me.date_tglawal)
        Me.Panel3.Controls.Add(Me.bt_search)
        Me.Panel3.Controls.Add(Me.in_cari)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Font = New System.Drawing.Font("Open Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(0, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(950, 37)
        Me.Panel3.TabIndex = 1
        '
        'lbl_date
        '
        Me.lbl_date.AutoSize = True
        Me.lbl_date.Location = New System.Drawing.Point(180, 13)
        Me.lbl_date.Name = "lbl_date"
        Me.lbl_date.Size = New System.Drawing.Size(26, 15)
        Me.lbl_date.TabIndex = 0
        Me.lbl_date.Text = "S.d."
        '
        'date_tglakhir
        '
        Me.date_tglakhir.CustomFormat = "dd MMM yyyy"
        Me.date_tglakhir.Location = New System.Drawing.Point(212, 9)
        Me.date_tglakhir.Name = "date_tglakhir"
        Me.date_tglakhir.Size = New System.Drawing.Size(165, 22)
        Me.date_tglakhir.TabIndex = 1
        '
        'date_tglawal
        '
        Me.date_tglawal.CustomFormat = "dd MMM yyyy"
        Me.date_tglawal.Location = New System.Drawing.Point(9, 9)
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
        Me.bt_search.Location = New System.Drawing.Point(630, 9)
        Me.bt_search.Name = "bt_search"
        Me.bt_search.Size = New System.Drawing.Size(42, 22)
        Me.bt_search.TabIndex = 3
        Me.bt_search.UseVisualStyleBackColor = False
        '
        'in_cari
        '
        Me.in_cari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.in_cari.Location = New System.Drawing.Point(383, 9)
        Me.in_cari.MaxLength = 100
        Me.in_cari.Name = "in_cari"
        Me.in_cari.Size = New System.Drawing.Size(248, 22)
        Me.in_cari.TabIndex = 2
        '
        'mnstrip_main
        '
        Me.mnstrip_main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_tambah, Me.mn_edit, Me.mn_print, Me.mn_export, Me.mn_other, Me.mn_refresh})
        Me.mnstrip_main.Location = New System.Drawing.Point(0, 0)
        Me.mnstrip_main.Name = "mnstrip_main"
        Me.mnstrip_main.Size = New System.Drawing.Size(950, 24)
        Me.mnstrip_main.TabIndex = 182
        Me.mnstrip_main.Text = "MenuStrip1"
        '
        'mn_tambah
        '
        Me.mn_tambah.Image = Global.Inventory.My.Resources.Resources.toolbar_add_icon
        Me.mn_tambah.Name = "mn_tambah"
        Me.mn_tambah.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.mn_tambah.Size = New System.Drawing.Size(59, 20)
        Me.mn_tambah.Text = "Baru"
        '
        'mn_edit
        '
        Me.mn_edit.Image = Global.Inventory.My.Resources.Resources.toolbar_list_icon1
        Me.mn_edit.Name = "mn_edit"
        Me.mn_edit.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.mn_edit.Size = New System.Drawing.Size(55, 20)
        Me.mn_edit.Text = "Edit"
        '
        'mn_print
        '
        Me.mn_print.Image = CType(resources.GetObject("mn_print.Image"), System.Drawing.Image)
        Me.mn_print.Name = "mn_print"
        Me.mn_print.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.mn_print.Size = New System.Drawing.Size(60, 20)
        Me.mn_print.Text = "Print"
        Me.mn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.mn_print.Visible = False
        '
        'mn_export
        '
        Me.mn_export.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_exportExcel})
        Me.mn_export.Name = "mn_export"
        Me.mn_export.Size = New System.Drawing.Size(52, 20)
        Me.mn_export.Text = "Export"
        '
        'mn_exportExcel
        '
        Me.mn_exportExcel.Name = "mn_exportExcel"
        Me.mn_exportExcel.Size = New System.Drawing.Size(136, 22)
        Me.mn_exportExcel.Text = "Export Excel"
        '
        'mn_other
        '
        Me.mn_other.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_cancel, Me.mn_uncancel, Me.mn_delete, Me.ToolStripSeparator1, Me.mn_search})
        Me.mn_other.Name = "mn_other"
        Me.mn_other.Size = New System.Drawing.Size(68, 20)
        Me.mn_other.Text = "Lain-Lain"
        '
        'mn_cancel
        '
        Me.mn_cancel.Name = "mn_cancel"
        Me.mn_cancel.Size = New System.Drawing.Size(176, 22)
        Me.mn_cancel.Text = "Batalkan Transaksi"
        '
        'mn_uncancel
        '
        Me.mn_uncancel.Name = "mn_uncancel"
        Me.mn_uncancel.Size = New System.Drawing.Size(176, 22)
        Me.mn_uncancel.Text = "Cancel Pembatalan"
        '
        'mn_delete
        '
        Me.mn_delete.Name = "mn_delete"
        Me.mn_delete.Size = New System.Drawing.Size(176, 22)
        Me.mn_delete.Text = "Hapus Transaksi"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(173, 6)
        '
        'mn_search
        '
        Me.mn_search.Name = "mn_search"
        Me.mn_search.Size = New System.Drawing.Size(176, 22)
        Me.mn_search.Text = "Cari"
        '
        'mn_refresh
        '
        Me.mn_refresh.Name = "mn_refresh"
        Me.mn_refresh.Size = New System.Drawing.Size(58, 20)
        Me.mn_refresh.Text = "Refresh"
        '
        'fr_stock_mutasibrg_list
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnl_Menu)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "fr_stock_mutasibrg_list"
        Me.Size = New System.Drawing.Size(950, 576)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnl_Menu.ResumeLayout(False)
        Me.pnl_Menu.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgv_list, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_barang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.mnstrip_main.ResumeLayout(False)
        Me.mnstrip_main.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_close As System.Windows.Forms.Label
    Friend WithEvents bt_cl As System.Windows.Forms.Button
    Friend WithEvents lbl_title As System.Windows.Forms.Label
    Friend WithEvents pnl_Menu As System.Windows.Forms.Panel
    Friend WithEvents mnstrip_main As System.Windows.Forms.MenuStrip
    Friend WithEvents mn_tambah As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_other As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_cancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mn_search As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_refresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_uncancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_export As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mn_exportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents bt_search As System.Windows.Forms.Button
    Friend WithEvents in_cari As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lbl_pageinfo As System.Windows.Forms.Label
    Friend WithEvents bt_page_next As System.Windows.Forms.Button
    Friend WithEvents bt_page_last As System.Windows.Forms.Button
    Friend WithEvents bt_page_prev As System.Windows.Forms.Button
    Friend WithEvents bt_page_first As System.Windows.Forms.Button
    Friend WithEvents in_page As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgv_list As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_barang As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_date As System.Windows.Forms.Label
    Friend WithEvents date_tglakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents date_tglawal As System.Windows.Forms.DateTimePicker

End Class
