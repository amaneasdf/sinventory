﻿Public Class fr_sales_detail

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

    Private Sub loadDataSales(kode As String)
        readcommd("SELECT * FROM data_salesman_master WHERE salesman_kode='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = kode
            in_namasales.Text = rd.Item("salesman_nama")
            in_alamatsales.Text = rd.Item("salesman_alamat")
            date_kerja.Value = rd.Item("salesman_tanggal_masuk")
            in_jenis_kode.Text = rd.Item("salesman_jenis")
            cb_jenis.SelectedValue = in_jenis_kode.Text
            in_lahir_kota.Text = rd.Item("salesman_lahir_kota")
            date_lahir_tgl.Value = rd.Item("salesman_lahir_tanggal")
            in_telpsales.Text = rd.Item("salesman_hp")
            in_faxsales.Text = rd.Item("salesman_fax")
            in_nik.Text = rd.Item("salesman_nik")
            in_target.Text = rd.Item("salesman_target")
            in_bank_nama.Text = rd.Item("salesman_bank_nama")
            in_bank_rek.Text = rd.Item("salesman_bank_rekening")
            in_bank_an.Text = rd.Item("salesman_bank_atasnama")
            in_status_kode.Text = rd.Item("salesman_status")
            cb_status.SelectedValue = in_status_kode.Text
            txtRegAlias.Text = rd.Item("salesman_reg_alias")
            txtRegdate.Text = rd.Item("salesman_reg_date")
            Try
                txtUpdDate.Text = rd.Item("salesman_upd_date")
            Catch ex As Exception
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("salesman_upd_alias")
        End If
        rd.Close()
    End Sub

    Private Sub keyshortenter(nextcontrol As Control, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nextcontrol.Focus()
        End If
    End Sub

    Private Sub fr_sales_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        op_con()
        With cb_status
            .DataSource = statusSales()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
        With cb_jenis
            .DataSource = jenisSales()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
        If bt_simpansales.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadDataSales(.Text)
            End With
        End If
    End Sub

    Private Sub cb_status_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_status.SelectionChangeCommitted
        in_status_kode.Text = cb_status.SelectedValue
        bt_simpansales.Focus()
    End Sub

    Private Sub bt_simpansales_Click(sender As Object, e As EventArgs) Handles bt_simpansales.Click
        Dim data As String()
        'Dim dataCol As String()
        Dim querycheck As Boolean = False
        If in_kode.Text = Nothing Then
            MessageBox.Show("Kode belum di input")
            in_kode.Focus()
            Exit Sub
        End If

        If in_namasales.Text = Nothing Then
            MessageBox.Show("Nama belum di input")
            in_namasales.Focus()
            Exit Sub
        End If

        If bt_simpansales.Text = "Simpan" Then
            If checkdata("data_salesman_master", in_kode.Text, "salesman_kode") = True Then
                MessageBox.Show("Kode " & in_kode.Text & " sudah ada")
                in_kode.Focus()
                Exit Sub
            End If

            data = {
                "'" & in_kode.Text & "'",
                "'" & in_namasales.Text & "'",
                "'" & in_alamatsales.Text & "'",
                "'" & date_kerja.Value.ToString("yyyy-MM-dd") & "'",
                "'" & in_jenis_kode.Text & "'",
                "'" & in_lahir_kota.Text & "'",
                "'" & date_lahir_tgl.Value.ToString("yyyy-MM-dd") & "'",
                "'" & in_telpsales.Text & "'",
                "'" & in_faxsales.Text & "'",
                "'" & in_nik.Text & "'",
                "'" & in_target.Text & "'",
                "'" & in_bank_nama.Text & "'",
                "'" & in_bank_rek.Text & "'",
                "'" & in_bank_an.Text & "'",
                "''",
                "'" & in_status_kode.Text & "'",
                "NOW()",
                "'" & loggeduser.user_id & "'",
                "''",
                "''"
            }
            op_con()
            querycheck = commnd("INSERT INTO data_salesman_master VALUES(" & String.Join(",", data) & ")")
        ElseIf bt_simpansales.Text = "Update" Then
            op_con()
            querycheck = commnd("UPDATE data_salesman_master SET salesman_nama='" & in_namasales.Text & "', salesman_alamat='" & in_alamatsales.Text & "', salesman_tanggal_masuk='" & date_kerja.Value.ToString("yyyy-MM-dd") & "', salesman_jenis='" & in_jenis_kode.Text & "', salesman_lahir_kota='" & in_lahir_kota.Text & "', salesman_lahir_tanggal='" & date_lahir_tgl.Value.ToString("yyyy-MM-dd") & "', salesman_hp='" & in_telpsales.Text & "', salesman_fax='" & in_faxsales.Text & "', salesman_nik='" & in_nik.Text & "', salesman_target='" & in_target.Text & "', salesman_bank_nama='" & in_bank_nama.Text & "', salesman_bank_rekening='" & in_bank_rek.Text & "', salesman_bank_atasnama='" & in_bank_an.Text & "', salesman_status='" & in_status_kode.Text & "', salesman_upd_date=NOW(), salesman_upd_alias='" & loggeduser.user_id & "' WHERE salesman_kode='" & in_kode.Text & "'")
        End If

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmsales.in_cari.Clear()
            populateDGVUserCon("sales", "", frmsales.dgv_list)
            Me.Dispose()
        End If
    End Sub

    Private Sub bt_batalsales_Click(sender As Object, e As EventArgs) Handles bt_batalsales.Click
        Me.Dispose()
    End Sub

    Private Sub cb_jenis_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_jenis.SelectionChangeCommitted
        in_jenis_kode.Text = cb_jenis.SelectedValue
        in_lahir_kota.Focus()
    End Sub

    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(in_namasales, e)
    End Sub

    Private Sub in_namasales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_namasales.KeyDown
        keyshortenter(in_alamatsales, e)
    End Sub

    Private Sub i(sender As Object, e As KeyEventArgs) Handles date_kerja.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            cb_jenis.DroppedDown = True
            cb_jenis.Focus()
        End If
    End Sub

    Private Sub in_lahir_kota_KeyDown(sender As Object, e As KeyEventArgs) Handles in_lahir_kota.KeyDown
        keyshortenter(date_lahir_tgl, e)
    End Sub

    Private Sub date_lahir_tgl_KeyDown(sender As Object, e As KeyEventArgs) Handles date_lahir_tgl.KeyDown
        keyshortenter(in_telpsales, e)
    End Sub

    Private Sub in_telpsales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_telpsales.KeyDown
        keyshortenter(in_faxsales, e)
    End Sub

    Private Sub in_faxsales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_faxsales.KeyDown
        keyshortenter(in_nik, e)
    End Sub

    Private Sub in_nik_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nik.KeyDown
        keyshortenter(in_target, e)
    End Sub

    Private Sub in_target_KeyDown(sender As Object, e As KeyEventArgs) Handles in_target.KeyDown
        keyshortenter(in_bank_nama, e)
    End Sub

    Private Sub in_bank_nama_KeyDown(sender As Object, e As KeyEventArgs) Handles in_bank_nama.KeyDown
        keyshortenter(in_bank_rek, e)
    End Sub

    Private Sub in_bank_rek_KeyDown(sender As Object, e As KeyEventArgs) Handles in_bank_rek.KeyDown
        keyshortenter(in_bank_an, e)
    End Sub

    Private Sub in_bank_an_KeyDown(sender As Object, e As KeyEventArgs) Handles in_bank_an.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            cb_status.DroppedDown = True
            cb_status.Focus()
        End If
    End Sub
End Class