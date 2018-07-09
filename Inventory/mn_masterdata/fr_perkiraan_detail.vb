Public Class fr_perkiraan_detail

    Private Sub loadDataPerkiraan(kode As String)
        readcommd("SELECT * FROM setup_perkiraan WHERE perk_kode='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = kode
            in_parent.Text = rd.Item("perk_parent")
            in_nama.Text = rd.Item("perk_nama")
            in_ket.Text = rd.Item("perk_keterangan")
            cb_jenis.SelectedValue = rd.Item("perk_jenis")
            cb_jurnal.SelectedValue = rd.Item("perk_jurnal")
            cb_posisi.SelectedValue = rd.Item("perk_d_or_k")
        End If
        rd.Close()
    End Sub

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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalperkiraan.Click
        Me.Close()
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

    '----------------- cb disable input
    Private Sub cb_status_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_jenis.KeyPress, cb_status.KeyPress, cb_jurnal.KeyPress, cb_posisi.KeyPress
        e.Handled = True
    End Sub

    '----------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanperkiraan.PerformClick()
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

    Private Sub fr_perkiraan_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_jenis
            .DataSource = jenisPerkiraan()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With
        With cb_posisi
            .DataSource = jenisDeb()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With
        With cb_jurnal
            .DataSource = jenisJurnal()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With
        With cb_status
            .DataSource = statusBarang()
            .ValueMember = "Value"
            .DisplayMember = "Text"
            .SelectedIndex = 0
        End With

        op_con()
        If bt_simpanperkiraan.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadDataPerkiraan(.Text)
            End With
        End If
    End Sub

    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click
        Dim data As String()
        Dim querycheck As Boolean = False
        If Trim(in_kode.Text) = Nothing Then
            MessageBox.Show("Kode belum di input")
            in_kode.Focus()
            Exit Sub
        End If
        If Trim(in_nama.Text) = Nothing Then
            MessageBox.Show("Nama belum di input")
            in_nama.Focus()
            Exit Sub
        End If
        If cb_jenis.SelectedValue = Nothing Then
            MessageBox.Show("Nama belum di input")
            cb_jenis.Focus()
            Exit Sub
        End If
        If cb_jurnal.SelectedValue = Nothing Then
            MessageBox.Show("Nama belum di input")
            cb_jurnal.Focus()
            Exit Sub
        End If
        If cb_posisi.SelectedValue = Nothing Then
            MessageBox.Show("Nama belum di input")
            cb_posisi.Focus()
            Exit Sub
        End If

        data = {
            "perk_kode='" & in_kode.Text & "'",
            "perk_parent='" & in_parent.Text & "'",
            "perk_nama='" & in_nama.Text & "'",
            "perk_jenis='" & cb_jenis.SelectedValue & "'",
            "perk_jurnal='" & cb_jurnal.SelectedValue & "'",
            "perk_d_or_k='" & cb_posisi.SelectedValue & "'",
            "perk_keterangan='" & in_ket.Text & "'"
        }

        op_con()
        If bt_simpanperkiraan.Text = "Simpan" Then
            If checkdata("setup_perkiraan", "'" & in_kode.Text & "'", "perk_kode") = True Then
                MessageBox.Show(in_kode.Text & " sudah ada")
                Exit Sub
            End If

            querycheck = commnd("INSERT INTO setup_perkiraan SET " & String.Join(",", data))
        ElseIf bt_simpanperkiraan.Text = "Update" Then
            data = data.Skip(1).ToArray
            querycheck = commnd("UPDATE setup_perkiraan SET " & String.Join(",", data) & " WHERE perk_kode='" & in_kode.Text & "'")
        End If

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmperkiraan.in_cari.Clear()
            populateDGVUserCon("perkiraan", "", frmperkiraan.dgv_list)
            Me.Close()
        End If
    End Sub
End Class