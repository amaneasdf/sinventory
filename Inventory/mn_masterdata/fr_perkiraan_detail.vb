Public Class fr_perkiraan_detail

    Private Sub loadDataPerkiraan(kode As String)
        readcommd("SELECT * FROM setup_perkiraan WHERE perk_kode='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = kode
            in_parent.Text = rd.Item("perk_parent")
            in_nama.Text = rd.Item("perk_nama")
            in_ket.Text = rd.Item("perk_keterangan")
            in_kode_jenis.Text = rd.Item("perk_jenis")
            in_kode_posisi.Text = rd.Item("perk_d_or_k")
            in_kode_jurnal.Text = rd.Item("perk_jurnal")
            cb_jenis.SelectedValue = in_kode_jenis.Text
            cb_jurnal.SelectedValue = in_kode_jurnal.Text
            cb_posisi.SelectedValue = in_kode_posisi.Text
        End If
        rd.Close()
    End Sub

    Private Sub fr_perkiraan_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        If Trim(in_kode_jenis.Text) = Nothing Then
            MessageBox.Show("Nama belum di input")
            cb_jenis.Focus()
            Exit Sub
        End If
        If Trim(in_kode_jurnal.Text) = Nothing Then
            MessageBox.Show("Nama belum di input")
            cb_jurnal.Focus()
            Exit Sub
        End If
        If Trim(in_kode_posisi.Text) = Nothing Then
            MessageBox.Show("Nama belum di input")
            cb_posisi.Focus()
            Exit Sub
        End If

        data = {
            "perk_kode='" & in_kode.Text & "'",
            "perk_parent='" & in_parent.Text & "'",
            "perk_nama='" & in_nama.Text & "'",
            "perk_jenis='" & in_kode_jenis.Text & "'",
            "perk_jurnal='" & in_kode_jurnal.Text & "'",
            "perk_d_or_k='" & in_kode_posisi.Text & "'",
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
            Me.Dispose()
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

    Private Sub bt_batalperkiraan_Click(sender As Object, e As EventArgs) Handles bt_batalperkiraan.Click
        Me.Dispose()
    End Sub
End Class