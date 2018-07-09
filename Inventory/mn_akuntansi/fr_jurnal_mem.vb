Public Class fr_jurnal_mem
    Private rowindex As Integer = 0

    Private Sub loadData(kode As String)
        op_con()
        Try

        Catch ex As Exception

        End Try
        loadDgv(kode)
    End Sub

    Private Sub loadDgv(kode As String)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub textToDgv()

        countTotal()
    End Sub

    Private Sub dgvToText()

        countTotal()
    End Sub

    Private Sub countTotal()

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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalperkiraan.Click
        Me.Close()
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Tutup Form?", "Kas", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalperkiraan.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '--------------- cb prevent input
    Private Sub cb_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_jenis.KeyPress
        e.Handled = True
    End Sub

    '--------------- numeric
    Private Sub in_debet_Enter(sender As Object, e As EventArgs) Handles in_kredit.Enter, in_debet.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_debet_Leave(sender As Object, e As EventArgs) Handles in_kredit.Leave, in_debet.Leave
        numericLostFocus(sender)
    End Sub

    '--------------- load
    Private Sub fr_jurnal_mem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    '--------------- input
    Private Sub cb_jenis_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_jenis.KeyDown
        keyshortenter(in_no_bukti, e)
    End Sub

    Private Sub in_no_bukti_KeyDown(sender As Object, e As KeyEventArgs) Handles in_no_bukti.KeyDown
        keyshortenter(date_tgl_trans, e)
    End Sub

    Private Sub date_tgl_trans_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_trans.KeyDown
        keyshortenter(in_rek, e)
    End Sub

    Private Sub in_rek_KeyDown(sender As Object, e As KeyEventArgs) Handles in_rek.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_rek_list.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(in_debet, e)
        End If
    End Sub

    Private Sub in_debet_KeyDown(sender As Object, e As KeyEventArgs) Handles in_debet.KeyDown
        keyshortenter(in_kredit, e)
    End Sub

    Private Sub in_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kredit.KeyDown
        keyshortenter(in_ket, e)
    End Sub

    Private Sub in_ket_KeyDown(sender As Object, e As KeyEventArgs) Handles in_ket.KeyDown
        keyshortenter(bt_tbkas, e)
    End Sub

    Private Sub bt_tbkas_Click(sender As Object, e As EventArgs) Handles bt_tbkas.Click
        textToDgv()
    End Sub

    Private Sub dgv_kas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_kas.CellDoubleClick
        dgvToText()
    End Sub
End Class