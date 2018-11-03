Public Class fr_giro_dialog
    Private tipe As String = "IN"
    Public returnval As Boolean = False

    Private Sub loadCBAkun(kode As String)
        Dim q As String = "SELECT perk_kode as 'Value',perk_nama_akun as 'Text' FROM data_perkiraan WHERE perk_status=1 AND perk_parent='{0}'"
        Dim kodeparent As String = "1101"
        With cb_akun
            .DataSource = Nothing
            Select Case kode
                Case "TUNAI"
                    kodeparent = "1101"
                    .DataSource = getDataTablefromDB(String.Format(q, kodeparent))
                Case "BG", "TRANSFER"
                    kodeparent = "1102"
                    .DataSource = getDataTablefromDB(String.Format(q, kodeparent))
                Case Else
                    Exit Sub
            End Select
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With
    End Sub

    Public Sub do_load(tipegiro As String)
        tipe = UCase(tipegiro)

        If tipe = "IN" Then
            lbl_cair.Visible = True
            cb_akun.Visible = True
        Else
            lbl_cair.Visible = False
            cb_akun.Visible = False
        End If

        loadCBAkun("BG")
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        If MessageBox.Show("Batalkan?", "Detail Giro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            returnval = False
            Me.Close()
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbeli.PerformClick()
    End Sub

    'UI
    Private Sub date_tgl_cair_ValueChanged(sender As Object, e As EventArgs) Handles date_tgl_cair.ValueChanged
        in_tgl_cair.Text = date_tgl_cair.Value.ToShortDateString
    End Sub

    Private Sub cb_akun_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_akun.KeyPress
        If e.KeyChar <> ControlChars.CrLf Then
            e.Handled = True
        End If
    End Sub

    'BUTTON
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        If in_tgl_cair.Text = "" Then
            MessageBox.Show("Tanggal belum di input")
            date_tgl_cair.Focus()
            Exit Sub
        End If
        If cb_akun.SelectedValue = Nothing And tipe = "IN" Then
            MessageBox.Show("Akun pencairan belum di input")
            cb_akun.Focus()
            Exit Sub
        End If

        returnval = True
        Me.Close()
    End Sub
End Class