Public Class fr_neracaawal_detail

    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_NCLBUTTONDOWN As Integer = 161
        Const WM_SYSCOMMAND As Integer = 274
        Const HTCAPTION As Integer = 2
        Const SC_MOVE As Integer = 61456

        If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32 = SC_MOVE) Then
            Exit Sub
        End If

        If (m.Msg = WM_NCLBUTTONDOWN) AndAlso (m.WParam.ToInt32 = HTCAPTION) Then
            Exit Sub
        End If

        MyBase.WndProc(m)
    End Sub

    Private Sub loadDatamigrasi(kode As String)
        readcommd("SELECT * FROM setup_migrasi WHERE perk_kode='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = kode
            in_parent.Text = rd.Item("perk_parent")
            in_nama.Text = rd.Item("perk_nama")
            in_ket.Text = rd.Item("perk_keterangan")
            in_kode_jenis.Text = rd.Item("perk_jenis")
            in_kode_posisi.Text = rd.Item("perk_d_or_k")
            in_kode_jurnal.Text = rd.Item("perk_jurnal")
            in_saldo.Value = rd.Item("perk_saldo")
            cb_jenis.SelectedValue = in_kode_jenis.Text
            cb_jurnal.SelectedValue = in_kode_jurnal.Text
            cb_posisi.SelectedValue = in_kode_posisi.Text
        End If
        rd.Close()
    End Sub

    Private Sub fr_neracaawal_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_jenis
            .DataSource = jenisPerkiraan()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
        With cb_posisi
            .DataSource = jenisDeb()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
        With cb_jurnal
            .DataSource = jenisJurnal()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With

        op_con()
        If bt_simpanmigrasi.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadDatamigrasi(.Text)
            End With
        End If
    End Sub

    Private Sub cb_jenis_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_jenis.SelectionChangeCommitted
        in_kode_jenis.Text = cb_jenis.SelectedValue
    End Sub

    Private Sub cb_posisi_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_posisi.SelectionChangeCommitted
        in_kode_posisi.Text = cb_posisi.SelectedValue
    End Sub

    Private Sub cb_jurnal_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_jurnal.SelectionChangeCommitted
        in_kode_jurnal.Text = cb_jurnal.SelectedValue
    End Sub
    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanmigrasi.Click
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
        If Trim(in_kode_jenis.Text) = Nothing Then
            MessageBox.Show("Jenis belum di input")
            cb_jenis.Focus()
            Exit Sub
        End If
        If Trim(in_kode_jurnal.Text) = Nothing Then
            MessageBox.Show("Jurnal belum di input")
            cb_jurnal.Focus()
            Exit Sub
        End If
        If Trim(in_kode_posisi.Text) = Nothing Then
            MessageBox.Show("Posisi D/K belum di input")
            cb_posisi.Focus()
            Exit Sub
        End If
        If in_saldo.Value = 0 Then
            MessageBox.Show("Saldo belum di input")
            in_saldo.Focus()
            Exit Sub
        End If

        data = {
            "perk_kode='" & in_kode.Text & "'",
            "perk_parent='" & in_parent.Text & "'",
            "perk_nama='" & in_nama.Text & "'",
            "perk_jenis='" & in_kode_jenis.Text & "'",
            "perk_jurnal='" & in_kode_jurnal.Text & "'",
            "perk_d_or_k='" & in_kode_posisi.Text & "'",
            "perk_saldo='" & in_saldo.Value & "'",
            "perk_keterangan='" & in_ket.Text & "'"
        }

        op_con()
        If bt_simpanmigrasi.Text = "Simpan" Then
            If checkdata("setup_migrasi", "'" & in_kode.Text & "'", "perk_kode") = True Then
                MessageBox.Show(in_kode.Text & " sudah ada")
                Exit Sub
            End If

            querycheck = commnd("INSERT INTO setup_migrasi SET " & String.Join(",", data))
        ElseIf bt_simpanmigrasi.Text = "Update" Then
            data = data.Skip(1).ToArray
            querycheck = commnd("UPDATE setup_migrasi SET " & String.Join(",", data) & " WHERE perk_kode='" & in_kode.Text & "'")
        End If

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmawalneraca.in_cari.Clear()
            populateDGVUserCon("neracaawal", "", frmawalneraca.dgv_list)
            Me.Dispose()
        End If
    End Sub

    Private Sub bt_batalmigrasi_Click(sender As Object, e As EventArgs) Handles bt_batalmigrasi.Click
        Me.Dispose()
    End Sub

    Private Sub fr_neracaawal_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_batalmigrasi.PerformClick()
        End If
    End Sub
End Class