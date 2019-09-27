Public Class fr_giro_dialog
    Private tipe As String = "IN"
    Private dialogtipe As String = "CAIR"
    Private GiroID As String = ""
    Public returnval As Boolean = False
    Public ValidID As String = ""

    Private Sub do_load(GiroID As String, tipegiro As String, GiroDate As Date)
        tipe = UCase(tipegiro) : Me.GiroID = GiroID

        If tipe = "IN" Then
            lbl_cair.Visible = True
            cb_akun.Visible = True
        Else
            lbl_cair.Visible = False
            cb_akun.Visible = False
        End If

        RemoveHandler date_tgl_cair.ValueChanged, AddressOf date_tgl_cair_ValueChanged
        With date_tgl_cair
            .MinDate = If(GiroDate < TransStartDate, TransStartDate, GiroDate)
            .Value = If(TransStartDate > Today, TransStartDate, Today)
        End With
        AddHandler date_tgl_cair.ValueChanged, AddressOf date_tgl_cair_ValueChanged

        With cb_akun
            .DataSource = jenisPerkiraan("akun", "1102")
            .ValueMember = "Value"
            .DisplayMember = "Text"
            .SelectedIndex = -1
        End With
    End Sub

    Public Sub doLoadCair(GiroID As String, GiroType As String, GiroDate As Date, AccID As String)
        do_load(GiroID, GiroType, GiroDate)
        If String.IsNullOrWhiteSpace(AccID) Then cb_akun.SelectedValue = AccID
    End Sub

    Public Sub doLoadTolak(GiroID As String, GiroType As String, GiroDate As Date)
        do_load(GiroID, GiroType, GiroDate)
        cb_akun.Visible = False
        lbl_cair.Visible = False
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
            MessageBox.Show("Tanggal belum di input.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            date_tgl_cair.Focus() : Exit Sub
        End If
        If cb_akun.Visible And cb_akun.SelectedIndex = -1 Then
            MessageBox.Show("Akun pencairan. belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cb_akun.Focus() : Exit Sub
        End If

        Dim _ok As Boolean = False
        Using _Valid As New fr_jualconfirm_dialog
            _Valid.doLoadValid()
            _ok = _Valid.returnval.Key
            If _ok Then LogValidTrans(_Valid.returnval.Value, loggeduser, "GIRO" & tipe, dialogtipe, GiroID, ValidID)
        End Using
        returnval = _ok
        If _ok Then Me.Close()
    End Sub
End Class