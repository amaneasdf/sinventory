Public Class fr_stok_awal
    Private rowindexlist As Integer = 0

    Private Sub getGudang(kode As String)
        op_con()
        readcommd("SELECT gudang_kode, gudang_nama FROM data_barang_gudang WHERE gudang_kode='" & kode & "'")
        If rd.HasRows Then
            in_gudang.Text = rd.Item("gudang_kode")
            in_gudang_n.Text = rd.Item("gudang_nama")
        End If
        rd.Close()
    End Sub

    Private Sub getBarang(kode As String)
        op_con()
        readcommd("SELECT barang_kode, barang_nama, getHPP(barang_kode) as hpp FROM data_barang_master WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            in_barang.Text = rd.Item("barang_kode")
            in_barang_n.Text = rd.Item("barang_nama")
            in_hpp.Value = rd.Item("hpp")
        End If
        rd.Close()
    End Sub

    Private Sub baranglist()
        in_barang.Text = Trim(in_barang.Text)
        Using search As New fr_search_dialog
            With search
                If in_barang.Text <> Nothing Then
                    .returnkode = in_barang.Text
                End If
                .in_cari.Text = in_barang.Text
                .returnkode = in_barang.Text
                .query = "SELECT barang_nama as nama, barang_kode as kode, barang_harga_beli as hargabeli, barang_harga_jual as hargajual FROM data_barang_master"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "barang"
                .ShowDialog()
                If .returnkode <> Nothing Then
                    getBarang(.returnkode)
                End If
            End With
        End Using
        in_stok_awal.Focus()
    End Sub

    Private Sub gudanglist()
        in_gudang.Text = Trim(in_gudang.Text)
        Using search As New fr_search_dialog
            With search
                If in_gudang.Text <> Nothing Then
                    .returnkode = in_gudang.Text
                End If
                .in_cari.Text = in_gudang_n.Text
                .query = "SELECT gudang_kode as kode, gudang_nama as nama FROM data_barang_gudang"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "gudang"
                .ShowDialog()
                If .returnkode <> Nothing Then
                    getGudang(.returnkode)
                End If
            End With
        End Using
        in_barang.Focus()
    End Sub

    Private Sub loadDataBRGPopup(type As String)
        Dim q As String = "SELECT barang_kode, barang_nama FROM data_barang_master WHERE barang_nama LIKE '{0}%' ORDER BY barang_kode LIMIT 100"
        Dim q2 As String = "SELECT gudang_kode as barang_kode, gudang_nama as barang_nama FROM data_barang_gudang WHERE gudang_nama LIKE '{0}%' ORDER BY gudang_kode LIMIT 100"
        With dgv_listbarang
            Select Case type
                Case "barang"
                    .DataSource = getDataTablefromDB(String.Format(q, in_barang_n.Text))
                Case "gudang"
                    .DataSource = getDataTablefromDB(String.Format(q2, in_gudang_n.Text))
            End Select
        End With
    End Sub

    '------------drag form
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, lbl_title.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, lbl_title.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, lbl_title.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick, lbl_title.DoubleClick
        CenterToScreen()
    End Sub

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbarang.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbarang.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '---------------pop up list barang & input barang
    Private Sub in_barang_Enter(sender As Object, e As EventArgs) Handles in_barang_n.Enter
        If mn_save.Enabled = True Then
            popPnl_barang.Location = New Point(in_barang_n.Left, in_barang_n.Top + in_barang_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("barang")
        End If
    End Sub

    Private Sub in_barang2_Enter(sender As Object, e As EventArgs) Handles in_gudang_n.Enter
        If mn_save.Enabled = True Then
            popPnl_barang.Location = New Point(in_gudang_n.Left, in_gudang_n.Top + in_gudang_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("gudang")
        End If
    End Sub

    Private Sub in_barang_n_Leave(sender As Object, e As EventArgs) Handles in_barang_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
            'If Trim(in_barang.Text) <> Nothing Then
            '    getBarang(in_kode.Text)
            'End If
        Else
            popPnl_barang.Visible = True
        End If

    End Sub

    Private Sub in_gudang_n_Leave(sender As Object, e As EventArgs) Handles in_gudang_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
            'If Trim(in_barang_nm2.Text) <> Nothing Then
            '    setBarang("tujuan", , in_barang_nm2.Text)
            'End If
        Else
            popPnl_barang.Visible = True
        End If

    End Sub
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_barang_n.Focused = True Or in_gudang_n.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub dgv_listbarang_CellContentDBLClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellDoubleClick
        If e.RowIndex >= 0 Then
            rowindexlist = e.RowIndex
            If popPnl_barang.Location = New Point(in_barang_n.Left, in_barang_n.Top + in_barang_n.Height) Then
                in_barang.Text = dgv_listbarang.Rows(rowindexlist).Cells("brg_kode").Value
                getBarang(in_barang.Text)
                in_stok_awal.Focus()
            ElseIf popPnl_barang.Location = New Point(in_gudang_n.Left, in_gudang_n.Top + in_gudang_n.Height) Then
                in_gudang.Text = dgv_listbarang.Rows(rowindexlist).Cells("brg_kode").Value
                getGudang(in_gudang.Text)
                in_barang.Focus()
            End If
        End If
    End Sub

    Private Sub dgv_listbarang_Cellenter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellEnter
        If e.RowIndex >= 0 Then
            rowindexlist = e.RowIndex
        End If
    End Sub

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            If popPnl_barang.Location = New Point(in_barang_n.Left, in_barang_n.Top + in_barang_n.Height) Then
                in_barang.Text = dgv_listbarang.Rows(rowindexlist).Cells("brg_kode").Value
                getBarang(in_barang.Text)
                in_stok_awal.Focus()
            ElseIf popPnl_barang.Location = New Point(in_gudang_n.Left, in_gudang_n.Top + in_gudang_n.Height) Then
                in_gudang.Text = dgv_listbarang.Rows(rowindexlist).Cells("brg_kode").Value
                getGudang(in_gudang.Text)
                in_barang.Focus()
            End If
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            e.Handled = True
            If popPnl_barang.Location = New Point(in_barang_n.Left, in_barang_n.Top + in_barang_n.Height) Then
                in_barang_n.Text += e.KeyChar
                in_barang_n.Focus()
            ElseIf popPnl_barang.Location = New Point(in_gudang_n.Left, in_gudang_n.Top + in_gudang_n.Height) Then
                in_gudang_n.Text += e.KeyChar
                in_gudang_n.Focus()
            End If
        End If
    End Sub

    Private Sub in_barang_n_TextChanged(sender As Object, e As EventArgs) Handles in_barang_n.TextChanged
        If in_barang_n.Text = "" Then
            in_barang.Clear()
        End If
    End Sub

    Private Sub in_gudang_n_TextChanged(sender As Object, e As EventArgs) Handles in_gudang_n.TextChanged
        If in_gudang_n.Text = "" Then
            in_gudang.Clear()
        End If
    End Sub

    Private Sub in_gudang_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyDown
        If e.KeyCode = Keys.F1 Then
            gudanglist()
        ElseIf e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                rowindexlist = 0
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            'If popPnl_barang.Visible = True Then
            '    rowindexlist = 0
            '    dgv_listbarang.Focus()
            'Else
            keyshortenter(in_barang, e)
            'End If
        End If
    End Sub

    Private Sub in_barang_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang_n.KeyDown
        If e.KeyCode = Keys.F1 Then
            baranglist()
        ElseIf e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                rowindexlist = 0
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            'If popPnl_barang.Visible = True Then
            '    rowindexlist = 0
            '    dgv_listbarang.Focus()
            'Else
            keyshortenter(in_stok_awal, e)
            'End If
        End If
    End Sub

    Private Sub in_barang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_barang_n.KeyUp
        If popPnl_barang.Visible = True Then
            loadDataBRGPopup("barang")
        End If
    End Sub

    Private Sub in_gudang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyUp
        If popPnl_barang.Visible = True Then
            loadDataBRGPopup("gudang")
        End If
    End Sub

    Private Sub linkLbl_searchbarang_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLbl_searchbarang.LinkClicked
        popPnl_barang.Visible = False
        If popPnl_barang.Location = New Point(in_barang_n.Left, in_barang_n.Top + in_barang_n.Height) Then
            bt_barang_list.PerformClick()
        ElseIf popPnl_barang.Location = New Point(in_gudang_n.Left, in_gudang_n.Top + in_gudang_n.Height) Then
            bt_gudang_list.PerformClick()
        End If
    End Sub


    '----------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanbarang.PerformClick()
    End Sub

    Private Sub mn_cancelorder_Click(sender As Object, e As EventArgs) Handles mn_deact.Click

    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click

    End Sub

    '---------------- numeric
    Private Sub in_stok_awal_Enter(sender As Object, e As EventArgs) Handles in_stok_awal.Enter, in_hpp.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_stok_awal_Leave(sender As Object, e As EventArgs) Handles in_stok_awal.Leave, in_hpp.Leave
        numericLostFocus(sender)
    End Sub

    '---------------- load
    Private Sub fr_stok_awal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        date_tgl_beli.Value = DateSerial(selectedperiode.Year, selectedperiode.Month, Today.Day)
        date_tgl_beli.Focus()
    End Sub

    'input
    Private Sub date_tgl_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyDown
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_stok_awal_KeyDown(sender As Object, e As KeyEventArgs) Handles in_stok_awal.KeyDown
        keyshortenter(in_hpp, e)
    End Sub

    Private Sub in_hpp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_hpp.KeyDown
        keyshortenter(bt_simpanbarang, e)
    End Sub

    '------------------- save
    Private Sub bt_simpanbarang_Click(sender As Object, e As EventArgs) Handles bt_simpanbarang.Click
        Dim dataCol As String()
        Dim stockkode As String = in_gudang.Text & "-" & in_barang.Text & "-" & date_tgl_beli.Value.ToString("yyMM")
        Dim queryarr As New List(Of String)
        Dim querycheck As Boolean = False

        Me.Cursor = Cursors.WaitCursor

        dataCol = {
            "stock_kode='" & stockkode & "'",
            "stock_gudang='" & in_gudang.Text & "'",
            "stock_barang='" & in_barang.Text & "'",
            "stock_hpp='" & in_hpp.Value & "'",
            "stock_awal=" & in_stok_awal.Value,
            "stock_periode='" & date_tgl_beli.Value.ToString("yyyy-MM") & "'",
            "stock_reg_alias='" & loggeduser.user_id & "'",
            "stock_reg_date=NOW()"
            }
        in_kode.Text = stockkode

        op_con()
        If bt_simpanbarang.Text = "Simpan" Then
            If MessageBox.Show("Buat data stok baru?", "Stok Awal", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                If checkdata("data_stok_awal", "'" & stockkode & "'", "stock_kode") = True Then
                    MessageBox.Show("Stok sudah ada di database")
                    Exit Sub
                End If

                queryarr.Add("INSERT INTO data_stok_awal SET " & String.Join(",", dataCol))

                'TODO: WRITE LOG

                querycheck = startTrans(queryarr)
                Me.Cursor = Cursors.Default

                If querycheck = False Then
                    MessageBox.Show("Data tidak dapat tersimpan")
                    Exit Sub
                Else
                    MessageBox.Show("Data tersimpan")
                    frmstok.performRefresh()
                    Me.Close()
                End If
            End If
        ElseIf bt_simpanbarang.Text = "Update" Then

        End If

        Me.Cursor = Cursors.Default
    End Sub
End Class