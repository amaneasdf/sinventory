Public Class fr_supplier_detail

    Private Sub loadDataSupplier(kode As String)
        readcommd("SELECT * FROM data_supplier_master WHERE supplier_kode='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = kode
            in_namasupplier.Text = rd.Item("supplier_nama")
            in_alamatsupplier.Text = rd.Item("supplier_alamat")
            in_telp1supplier.Text = rd.Item("supplier_telpon1")
            in_telp2supplier.Text = rd.Item("supplier_telpon2")
            in_faxsupplier.Text = rd.Item("supplier_fax")
            in_cp.Text = rd.Item("supplier_cp")
            in_emailsupplier.Text = rd.Item("supplier_email")
            in_npwpsupplier.Text = rd.Item("supplier_npwp")
            in_rek_bank.Text = rd.Item("supplier_rek_bank")
            in_rek_giro.Text = rd.Item("supplier_rek_bg")
            in_ket.Text = rd.Item("supplier_keterangan")
            in_term.Text = rd.Item("supplier_term")
            in_status_kode.Text = rd.Item("supplier_status")
            cb_status.SelectedValue = in_status_kode.Text
            txtRegAlias.Text = rd.Item("supplier_reg_alias")
            txtRegdate.Text = rd.Item("supplier_reg_date")
            Try
                txtUpdDate.Text = rd.Item("supplier_upd_date")
            Catch ex As Exception
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("supplier_upd_alias")
        End If
        rd.Close()
    End Sub

    Private Sub fr_supplier_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        op_con()
        With cb_status
            .DataSource = statusSupplier()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With

        If bt_simpansupplier.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadDataSupplier(.Text)
            End With
        End If
    End Sub

    Private Sub cb_status_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_status.SelectionChangeCommitted
        in_status_kode.Text = cb_status.SelectedValue
    End Sub

    Private Sub bt_simpansupplier_Click(sender As Object, e As EventArgs) Handles bt_simpansupplier.Click
        Dim data As String()
        Dim dataCol As String()
        Dim querycheck As Boolean = False
        If in_kode.Text = Nothing Then
            MessageBox.Show("Kode belum di input")
            in_kode.Focus()
            Exit Sub
        End If

        If in_namasupplier.Text = Nothing Then
            MessageBox.Show("Nama supplier belum di input")
            in_namasupplier.Focus()
            Exit Sub
        End If

        If in_alamatsupplier.Text = Nothing Then
            MessageBox.Show("Alamat supplier belum di input")
            in_alamatsupplier.Focus()
            Exit Sub
        End If

        If in_status_kode.Text = Nothing Then
            MessageBox.Show("Status supplier belum di input")
            cb_status.Focus()
            Exit Sub
        End If

        If bt_simpansupplier.Text = "Simpan" Then
            If checkdata("data_supplier_master", in_kode.Text, "supplier_kode") = True Then
                MessageBox.Show("Kode " & in_kode.Text & " sudah ada")
                in_kode.Focus()
                Exit Sub
            End If

            data = {
                "'" & in_kode.Text & "'",
                "'" & in_namasupplier.Text & "'",
                "'" & in_alamatsupplier.Text & "'",
                "'" & in_telp1supplier.Text & "'",
                "'" & in_telp2supplier.Text & "'",
                "'" & in_faxsupplier.Text & "'",
                "'" & in_cp.Text & "'",
                "'" & in_emailsupplier.Text & "'",
                "'" & in_npwpsupplier.Text & "'",
                "'" & in_rek_giro.Text & "'",
                "'" & in_rek_bank.Text & "'",
                "'" & in_term.Text & "'",
                "'" & in_ket.Text & "'",
                "'" & in_status_kode.Text & "'",
                "NOW()",
                "'" & loggeduser.user_ip & "'",
                "'" & loggeduser.user_id & "'",
                "''",
                "''",
                "''"
                }

            op_con()
            querycheck = commnd("INSERT INTO data_supplier_master VALUES(" & String.Join(",", data) & ")")
        ElseIf bt_simpansupplier.Text = "Update" Then
            data = {
                "'" & in_namasupplier.Text & "'",
                "'" & in_alamatsupplier.Text & "'",
                "'" & in_telp1supplier.Text & "'",
                "'" & in_telp2supplier.Text & "'",
                "'" & in_faxsupplier.Text & "'",
                "'" & in_cp.Text & "'",
                "'" & in_emailsupplier.Text & "'",
                "'" & in_npwpsupplier.Text & "'",
                "'" & in_rek_giro.Text & "'",
                "'" & in_rek_bank.Text & "'",
                "'" & in_term.Text & "'",
                "'" & in_ket.Text & "'",
                "'" & in_status_kode.Text & "'",
                "NOW()",
                "'" & loggeduser.user_ip & "'",
                "'" & loggeduser.user_id & "'"
                }
            dataCol = {
                "supplier_nama",
                "supplier_alamat",
                "supplier_telpon1",
                "supplier_telpon2",
                "supplier_fax",
                "supplier_cp",
                "supplier_email",
                "supplier_npwp",
                "supplier_rek_bg",
                "supplier_rek_bank",
                "supplier_term",
                "supplier_keterangan",
                "supplier_status",
                "supplier_upd_date",
                "supplier_upd_ip",
                "supplier_upd_alias"
                }

            Dim i As Integer = 0
            For Each x As String In dataCol
                x += "=" & data(i)
                dataCol(i) = x
                i = i + 1
            Next

            op_con()
            querycheck = commnd("UPDATE data_supplier_master SET " & String.Join(",", dataCol) & " WHERE supplier_kode='" & in_kode.Text & "'")
        End If

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmsupplier.in_cari.Clear()
            populateDGVUserCon("supplier", "", frmsupplier.dgv_list)
            Me.Dispose()
        End If
    End Sub

    Private Sub bt_batalsupplier_Click(sender As Object, e As EventArgs) Handles bt_batalsupplier.Click
        Me.Dispose()
    End Sub
End Class