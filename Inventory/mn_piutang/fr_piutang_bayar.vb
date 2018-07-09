Public Class fr_piutang_bayar

    Private Sub loadData(kode As String)

    End Sub

    Private Sub setSupplier(kode As String)

    End Sub

    Private Sub setFaktur(kode As String)

    End Sub

    Private Sub textToDGV(tipe As String)

    End Sub

    Private Sub dgvToText(tipe As String)

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

    '------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanperkiraan.PerformClick()
    End Sub

    Private Sub mn_delete_Click(sender As Object, e As EventArgs) Handles mn_delete.Click

    End Sub

    Private Sub mn_proses_Click(sender As Object, e As EventArgs) Handles mn_proses.Click

    End Sub

    '------------- numeric
    Private Sub in_debet_Enter(sender As Object, e As EventArgs) Handles in_kredit.Enter, in_debet.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_debet_Leave(sender As Object, e As EventArgs) Handles in_kredit.Leave, in_debet.Leave
        numericLostFocus(sender)
    End Sub

    '------------- cb prevent input
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_bayar.KeyPress
        e.Handled = True
    End Sub

    '------------- load
    Private Sub fr_hutang_bayar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    '------------ save
    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click

    End Sub
End Class