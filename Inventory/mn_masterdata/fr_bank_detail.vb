Public Class fr_bank_detail
    '------------drag form
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, lbl_title.MouseDown, Panel2.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, lbl_title.MouseMove, Panel2.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, lbl_title.MouseUp, Panel2.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick, lbl_title.DoubleClick, Panel2.DoubleClick
        CenterToScreen()
    End Sub

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalcusto.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalcusto.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '----------------- cb disable input
    Private Sub cb_status_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_pos.KeyPress, cb_status.KeyPress
        e.Handled = True
    End Sub

    '----------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpancusto.PerformClick()
    End Sub

    Private Sub mn_cancelorder_Click(sender As Object, e As EventArgs) Handles mn_deact.Click
        If mn_deact.Text = "Deactivate" Then
            cb_status.SelectedValue = "2"
            mn_deact.Text = "Activate"
        ElseIf mn_deact.Text = "Activate" Then
            cb_status.SelectedValue = "1"
            mn_deact.Text = "Deactivate"
        End If
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click

    End Sub

    '----------------- load
    Private Sub fr_bank_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_status
            .DataSource = statusBarang()
            .ValueMember = "Value"
            .DisplayMember = "Text"
            .SelectedIndex = 0
        End With

        With cb_pos

        End With


    End Sub

    '----------------- save
    Private Sub bt_simpancusto_Click(sender As Object, e As EventArgs) Handles bt_simpancusto.Click

    End Sub

    '----------------- input
    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(in_namabank, e)
    End Sub

    Private Sub in_namabank_KeyDown(sender As Object, e As KeyEventArgs) Handles in_namabank.KeyDown
        keyshortenter(in_pos, e)
    End Sub

    Private Sub in_pos_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pos.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_pos.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(cb_status, e)
        End If
    End Sub

    Private Sub in_pos_Leave(sender As Object, e As EventArgs) Handles in_pos.Leave
        If Trim(in_pos.Text) <> Nothing Then
            cb_pos.SelectedValue = in_pos.Text
        End If
    End Sub

    Private Sub cb_pos_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_pos.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_pos.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(cb_status, e)
        End If
    End Sub

    Private Sub cb_pos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_pos.SelectionChangeCommitted
        in_pos.Text = cb_pos.SelectedValue
    End Sub

    Private Sub bt_pos_Click(sender As Object, e As EventArgs) Handles bt_pos.Click
        Using search As New fr_search_dialog
            With search
                .query = ""
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = ""
                If Trim(in_pos.Text) <> Nothing Then
                    .returnkode = Trim(in_pos.Text)
                    .in_cari.Text = Trim(in_pos.Text)
                End If
                If cb_pos.SelectedValue <> Nothing Then
                    .returnkode = cb_pos.SelectedValue
                    .in_cari.Text = cb_pos.Text
                End If
                cb_pos.SelectedValue = .returnkode
                in_pos.Text = .returnkode
            End With
        End Using
        cb_status.Focus()
    End Sub

    Private Sub cb_status_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_status.KeyDown
        keyshortenter(bt_simpancusto, e)
    End Sub
End Class