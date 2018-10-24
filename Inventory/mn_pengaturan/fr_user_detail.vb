﻿Public Class fr_user_detail
    Private usrstatus As String = "1"


    Private Sub loadDatauser(kode As Integer)
        Dim q As String = "SELECT user_id,user_alias, user_nama, user_group, user_sales, user_sales_kode, salesman_nama," _
                          & "(CASE " _
                          & " WHEN salesman_jenis=1 THEN 'Sales TO' " _
                          & " WHEN salesman_jenis=2 THEN 'Sales Kanvas' " _
                          & " ELSE 'ERROR') AS salesman_jenis, user_validasi_master, user_validasi_trans, " _
                          & "user_allowedit_master, user_allowedit_trans, IF(user_login_status=1,'ON','OFF') as user_login_status, " _
                          & "user_login_terakhir, user_status " _
                          & "FROM data_pengguna_alias LEFT JOIN data_salesman_master ON salesman_kode=user_sales_kode " _
                          & "WHERE user_alias='{0}'"

        op_con()
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            'general
            in_kode.Text = rd.Item("user_id")
            in_userid.Text = rd.Item("user_alias")
            in_karyawan_nama.Text = rd.Item("user_nama")
            'level
            in_group_kode.Text = rd.Item("user_group")
            cb_group.SelectedValue = rd.Item("user_group")
            'priviledge
            If rd.Item("user_validasi_master") = 1 Then

            End If
            If rd.Item("user_validasi_trans") = 1 Then

            End If
            If rd.Item("user_allowedit_trans") = 1 Then

            End If
            If rd.Item("user_allowedit_master") = 1 Then

            End If
            'sales
            If rd.Item("user_sales") = 1 Then
                ckSalesSW(rd.Item("user_sales"))
                in_sales.Text = rd.Item("user_sales_kode")
                in_sales_n.Text = rd.Item("salesman_nama")
                in_sales_t.Text = rd.Item("salesman_jenis")
            End If
            'status
            usrstatus = rd.Item("user_status")
            in_login_status.Text = rd.Item("user_login_status")
            Try
                txtLastLogin.Text = rd.Item("user_login_terakhir")
            Catch ex As Exception
                txtLastLogin.Text = "00/00/0000 00:00:00"
            End Try
            'db
            txtRegdate.Text = rd.Item("user_reg_date")
            txtRegAlias.Text = rd.Item("user_reg_alias")
            Try
                txtUpdDate.Text = rd.Item("user_upd_date")
            Catch ex As Exception
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("user_upd_alias")
            txtExpDate.Text = rd.Item("user_exp_date")
        End If

        rd.Close()
        setStatus()
    End Sub

    Private Sub setStatus()
        Select Case usrstatus
            Case 0
                in_status.Text = "Non-Aktif"
            Case 1
                in_status.Text = "Aktif"
            Case 9
                in_status.Text = "Delete"
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub ckSalesSW(swch As String)
        Dim tx As TextBox() = {in_sales, in_sales_n, in_sales_t}
        If swch = "1" Then
            ck_sales.CheckState = CheckState.Checked
            For Each x As TextBox In tx
                x.Enabled = True
            Next
        Else
            ck_sales.CheckState = CheckState.Unchecked
            For Each x As TextBox In tx
                x.Clear()
                x.Enabled = False
            Next
        End If
    End Sub

    Private Sub do_load()

    End Sub

    Private Sub fr_user_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        op_con()
        With cb_group
            .DataSource = getDataTablefromDB("select group_kode, group_nama from data_pengguna_group")
            .DisplayMember = "group_nama"
            .ValueMember = "group_kode"
            .SelectedIndex = -1
        End With
        If bt_simpanuser.Text = "Update" Then
            For Each txt As TextBox In {in_userid, in_pass}
                With txt
                    .ReadOnly = True
                    .BackColor = Color.Gainsboro
                End With
            Next
            loadDatauser(in_kode.Text)
        End If
    End Sub

    Private Sub cb_group_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_group.SelectionChangeCommitted
        in_group_kode.Text = cb_group.SelectedValue
    End Sub

    Private Sub cb_status_SelectionChangeCommitted(sender As Object, e As EventArgs)
        in_status.Text = cb_status.SelectedValue
    End Sub

    Private Sub bt_simpanuser_Click(sender As Object, e As EventArgs) Handles bt_simpanuser.Click
        Dim data As String()
        Dim dataCol As String()
        Dim querycheck As Boolean = False
        If in_kode.Text = Nothing Then
            If in_userid.Text = Nothing Then
                MessageBox.Show("UserID belum di input")
                in_userid.Focus()
                Exit Sub
            End If

            If in_pass.Text = Nothing Then
                MessageBox.Show("Password belum di input")
                in_pass.Focus()
                Exit Sub
            End If
        End If

        If in_group_kode.Text = Nothing Then
            MessageBox.Show("Group user belum di pilih")
            cb_group.Focus()
            Exit Sub
        End If


        If bt_simpanuser.Text = "Simpan" Then
            If checkdata("data_pengguna_alias", "'" & in_userid.Text & "'", "user_alias") = True Then
                MessageBox.Show("User login sudah ada, ganti dengan user lainnya!")
                in_userid.Focus()
                Exit Sub
            End If

            data = {"'" & in_userid.Text & "'", "MD5('" & in_pass.Text & "')", "'" & in_group_kode.Text & "'", "'" & in_karyawan_nama.Text & "'", "1", "NOW()", "'" & loggeduser.user_id & "'", "'" & loggeduser.user_ip & "'", "DATE_ADD(CURDATE(),INTERVAL 3 MONTH)"}
            dataCol = {"user_alias", "user_pwd", "user_group", "user_nama", "user_status", "user_reg_date", "user_reg_alias", "user_reg_ip", "user_exp_date"}
            'insertData("data_pengguna_alias", data, dataCol)
            op_con()
            querycheck = commnd("insert into data_pengguna_alias(" & String.Join(",", dataCol) & ") values (" & String.Join(",", data) & ")")
        ElseIf bt_simpanuser.Text = "Update" Then
            op_con()
            querycheck = commnd("UPDATE data_pengguna_alias SET user_group = '" & in_group_kode.Text & "', user_alias = '" & in_userid.Text & "', user_nama = '" & in_karyawan_nama.Text & "', user_status = '" & in_status.Text & "',user_upd_date = NOW(), user_upd_alias = '" & loggeduser.user_id & "', user_upd_ip = '" & loggeduser.user_ip & "' WHERE user_kode = '" & in_kode.Text & "'")
        End If
        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmuser.in_cari.Clear()
            populateDGVUserCon("user", "", frmuser.dgv_list)
            Me.Close()
        End If
    End Sub

    Private Sub bt_reset_user_Click(sender As Object, e As EventArgs)
        If in_kode.Text = "" Then
            MsgBox("Simpan data terlebih dahulu!", MsgBoxStyle.Exclamation, Application.ProductName)
            Exit Sub
        End If

        If MsgBox("Apakah yakin akan mereset user ini?", MsgBoxStyle.YesNo, Application.ProductName) = MsgBoxResult.Yes Then
            commnd("UPDATE data_pengguna_alias SET user_password = Password('123456'), user_exp_date=DATE_ADD(CURDATE(),INTERVAL 3 MONTH) WHERE user_alias = '" & in_userid.Text & "'")
            MsgBox("Password telah reset, password defaultnya: 123456 ", MsgBoxStyle.Information, Application.ProductName)
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub bt_bataluser_Click(sender As Object, e As EventArgs) Handles bt_bataluser.Click
        Me.Close()
    End Sub
End Class