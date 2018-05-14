Public Class fr_gudang_detail

    Private Sub loadDataGudang(kode As String)
        readcommd("SELECT * FROM data_barang_gudang WHERE gudang_kode='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = kode
            in_namagudang.Text = rd.Item("gudang_nama")
            in_alamatgudang.Text = rd.Item("gudang_alamat")
            in_status_kode.Text = rd.Item("gudang_status")
            cb_status.SelectedValue = in_status_kode.Text
            txtRegIP.Text = rd.Item("gudang_reg_ip")
            txtRegdate.Text = rd.Item("gudang_reg_date")
            txtRegAlias.Text = rd.Item("gudang_reg_alias")
            Try
                txtUpdDate.Text = rd.Item("gudang_upd_date")
            Catch ex As Exception
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdIp.Text = rd.Item("gudang_upd_ip")
            txtUpdAlias.Text = rd.Item("gudang_upd_alias")
        End If
        rd.Close()
    End Sub

    Private Sub fr_gudang_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        op_con()
        With cb_status
            .DataSource = statusGudang()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With

        If bt_simpangudang.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadDataGudang(.Text)
            End With
            in_namagudang.Focus()
        End If
    End Sub

    Private Sub cb_status_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_status.SelectionChangeCommitted
        in_status_kode.Text = cb_status.SelectedValue
    End Sub

    Private Sub bt_simpangudang_Click(sender As Object, e As EventArgs) Handles bt_simpangudang.Click
        Dim data As String()
        Dim dataCol As String()
        Dim querycheck As Boolean = False
        If in_kode.Text = Nothing Then
            MessageBox.Show("Kode gudang belum di input")
            in_kode.Focus()
            Exit Sub
        End If
        If in_namagudang.Text = Nothing Then
            MessageBox.Show("Nama gudang belum di input")
            in_namagudang.Focus()
            Exit Sub
        End If
        If in_alamatgudang.Text = Nothing Then
            MessageBox.Show("Alamat gudang belum di input")
            in_alamatgudang.Focus()
            Exit Sub
        End If
        If in_status_kode.Text = Nothing Then
            MessageBox.Show("Status gudang belum di input")
            cb_status.Focus()
            Exit Sub
        End If

        If bt_simpangudang.Text = "Simpan" Then
            If checkdata("data_barang_gudang", in_kode.Text, "gudang_kode") = True Then
                MessageBox.Show("Kode gudang " & in_kode.Text & " sudah ada")
                in_kode.Focus()
                Exit Sub
            End If

            data = {"'" & in_kode.Text & "'", "'" & in_namagudang.Text & "'", "'" & in_alamatgudang.Text & "'", "'" & in_status_kode.Text & "'", "NOW()", "'" & loggeduser.user_ip & "'", "'" & loggeduser.user_id & "'"}
            dataCol = {"gudang_kode", "gudang_nama", "gudang_alamat", "gudang_status", "gudang_reg_date", "gudang_reg_ip", "gudang_reg_alias"}
            op_con()
            querycheck = commnd("insert into data_barang_gudang(" & String.Join(",", dataCol) & ") values (" & String.Join(",", data) & ")")
        ElseIf bt_simpangudang.Text = "Update" Then
            op_con()
            querycheck = commnd("UPDATE data_barang_gudang SET gudang_nama = '" & in_namagudang.Text & "', gudang_alamat = '" & in_alamatgudang.Text & "', gudang_status = '" & in_status_kode.Text & "',gudang_upd_date = NOW(), gudang_upd_alias = '" & loggeduser.user_id & "', gudang_upd_ip = '" & loggeduser.user_ip & "' WHERE gudang_kode = '" & in_kode.Text & "'")
        End If

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmgudang.in_cari.Clear()
            populateDGVUserCon("gudang", "", frmgudang.dgv_list)
            Me.Dispose()
        End If
    End Sub

    Private Sub bt_batalgudang_Click(sender As Object, e As EventArgs) Handles bt_batalgudang.Click
        Me.Dispose()
    End Sub
End Class