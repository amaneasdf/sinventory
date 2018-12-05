Public Class fr_set_periode
    '----------------close
    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '-----------------load
    Private Sub fr_set_periode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cal_periode.SelectionRange.Start = selectperiode.tglawal
    End Sub

    '-----------------set periode
    Private Sub bt_set_periode_Click(sender As Object, e As EventArgs) Handles bt_set_periode.Click
        setperiode(cal_periode.SelectionRange.Start)
        Me.Close()
    End Sub
End Class