Public Class fr_perkiraan_detail
    Private id As Integer = 0

    Private Sub loadDataPerkiraan(kode As String)
        readcommd("SELECT * FROM setup_perkiraan WHERE CONCAT(perk_kode_jenis,perk_golongan,perk_sub_gol,perk_kd_akun)='" & kode & "'")
        If rd.HasRows Then
            id = rd.Item("perk_kode_id")
            in_akun_n.Text = rd.Item("perk_nama_akun")
            cb_posisi.SelectedValue = rd.Item("perk_d_or_k")
            in_saldoawal.Value = rd.Item("perk_saldo_awal")
            txtRegAlias.Text = rd.Item("perk_reg_alias")
            txtRegdate.Text = rd.Item("perk_reg_date")
            Try
                txtUpdDate.Text = rd.Item("perk_upd_date")
            Catch ex As Exception
                consoleWriteLine(ex.Message)
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("perk_upd_alias")
        End If
        rd.Close()

        cb_jenis.SelectedValue = Strings.Left(kode, 1)
        cb_gol.SelectedValue = Strings.Left(kode, 2)
        cb_subgol.SelectedValue = Strings.Mid(kode, 3, 2)
        in_akun.Text = Strings.Right(kode, 2)
        in_kode.Text = kode
        inputSwitch(True)
    End Sub

    Private Function getRecentSaldo(kode As String) As String
        Dim x As Decimal = 0

        Return commaThousand(x)
    End Function

    Private Sub inputSwitch(sw As Boolean)
        If sw = True Then
            cb_jenis.Enabled = False
            cb_gol.Enabled = False
            cb_subgol.Enabled = False
        Else
            cb_jenis.Enabled = True
            cb_gol.Enabled = True
            cb_subgol.Enabled = True
        End If
        in_akun.ReadOnly = sw
    End Sub

    Private Function saveData() As Boolean
        op_con()

        Dim data1, data2, data3, data4 As String()
        Dim q As String = "INSERT INTO setup_perkiraan SET {0},{1},{2} ON DUPLICATE KEY UPDATE {1},{3}"

        data1 = {
            "perk_kode_jenis='" & cb_jenis.SelectedValue & "'",
            "perk_golongan='" & Strings.Right(cb_gol.SelectedValue, 1) & "'",
            "perk_sub_gol='" & cb_subgol.SelectedValue & "'",
            "perk_kd_akun='" & in_akun.Text & "'"
            }
        data2 = {
            "perk_nama_akun='" & in_akun_n.Text & "'",
            "perk_d_or_k='" & cb_posisi.SelectedValue & "'",
            "perk_saldo_awal='" & in_saldoawal.Value & "'",
            "perk_status='" & cb_status.SelectedValue & "'"
            }
        data3 = {
            "perk_reg_alias='" & loggeduser.user_id & "'",
            "perk_reg_date=NOW()"
            }
        data4 = {
            "perk_upd_alias='" & loggeduser.user_id & "'",
            "perk_upd_date=NOW()"
            }
        Return commnd(String.Format(q, String.Join(",", data1), String.Join(",", data2), String.Join(",", data3), String.Join(",", data4)))
    End Function

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
    Private Sub cb_status_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_jenis.KeyPress, cb_status.KeyPress, cb_posisi.KeyPress, cb_gol.KeyPress
        e.Handled = True
    End Sub

    '------------------ num input
    Private Sub in_saldoawal_Enter(sender As Object, e As EventArgs) Handles in_saldoawal.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_saldoawal_Leave(sender As Object, e As EventArgs) Handles in_saldoawal.Leave
        numericLostFocus(sender)
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
            .DataSource = jenisPerkiraan("jenis")
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
        With cb_posisi
            .DataSource = jenisDeb()
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

        in_cur_saldo.Text = commaThousand(0)

        op_con()
        If in_kode.Text <> Nothing Then
            loadDataPerkiraan(in_kode.Text)
            in_akun_n.Focus()
        End If
    End Sub

    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click
        If cb_jenis.SelectedValue = Nothing Then
            MessageBox.Show("Jenis belum di input")
            cb_jenis.Focus()
            Exit Sub
        End If
        If cb_gol.SelectedValue = Nothing Then
            MessageBox.Show("Golongan belum di input")
            cb_gol.Focus()
            Exit Sub
        End If
        If Trim(in_kode.Text) = Nothing Then
            MessageBox.Show("Kode belum di input")
            in_kode.Focus()
            Exit Sub
        End If
        If Trim(in_akun_n.Text) = Nothing Then
            MessageBox.Show("Nama belum di input")
            in_akun_n.Focus()
            Exit Sub
        End If
        If cb_posisi.SelectedValue = Nothing Then
            MessageBox.Show("Posisi belum di input")
            cb_posisi.Focus()
            Exit Sub
        End If

        Dim querycheck As Boolean = False

        Me.Cursor = Cursors.WaitCursor
        querycheck = saveData()

        Me.Cursor = Cursors.Default
        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data Perkiraan Tersimpan")
            frmperkiraan.in_cari.Clear()
            populateDGVUserCon("perkiraan", "", frmperkiraan.dgv_list)
            Me.Close()
        End If
    End Sub

    '-------------- CB JENIS AKUN
    Private Sub cb_jenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_jenis.SelectedIndexChanged
        With cb_gol
            If cb_jenis.SelectedIndex > -1 Then
                .Enabled = True
                Dim q As String = "SELECT perk_gol_nama as 'Text', perk_gol_kode as 'Value' FROM ref_gol_perkiraan " _
                                  & "WHERE perk_gol_kode LIKE '{0}%' AND perk_gol_kat='GOL'"
                .DataSource = getDataTablefromDB(String.Format(q, cb_jenis.SelectedValue))
                .ValueMember = "Value"
                .DisplayMember = "Text"
            Else
                .Text = Nothing
                .DataSource = Nothing
                .Enabled = False
            End If
        End With
    End Sub

    Private Sub cb_gol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_gol.SelectedIndexChanged
        With cb_subgol
            If cb_gol.SelectedValue <> Nothing Then
                in_kode_gol.Text = cb_gol.SelectedValue
                Dim q As String = "SELECT perk_gol_nama as 'Text', RIGHT(perk_gol_kode,2) as 'Value' FROM ref_gol_perkiraan " _
                                  & "WHERE perk_gol_kode LIKE '{0}%' AND perk_gol_kat='SUB'"
                .Enabled = True
                .DataSource = getDataTablefromDB(String.Format(q, cb_gol.SelectedValue))
                .ValueMember = "Value"
                .DisplayMember = "Text"
            Else
                in_kode_gol.Clear()
                .Text = Nothing
                .DataSource = Nothing
                .Enabled = False
            End If
        End With
    End Sub

    Private Sub cb_subgol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_subgol.SelectedIndexChanged
        If cb_subgol.SelectedValue <> Nothing Then
            in_kode_subgol.Text = cb_subgol.SelectedValue
        Else
            in_kode_subgol.Clear()
        End If
    End Sub

    '------------ KODE AKUN
    Private Sub in_kode_gol_TextChanged(sender As Object, e As EventArgs) Handles in_kode_subgol.TextChanged, in_kode_gol.TextChanged
        in_kode.Text = in_kode_gol.Text & in_kode_subgol.Text & in_akun.Text
    End Sub

    Private Sub in_akun_Leave(sender As Object, e As EventArgs) Handles in_akun.Leave
        If bt_simpanperkiraan.Text <> "Update" Then
            If IsNumeric(in_akun.Text) Then
                If in_akun.Text <> 0 Then
                    in_akun.Text = CInt(in_akun.Text).ToString("D2")
                    in_kode.Text = in_kode_gol.Text & in_kode_subgol.Text & in_akun.Text

                    op_con()
                    If checkdata("setup_perkiraan", "'" & in_kode.Text & "'", "CONCAT(perk_kode_jenis,perk_golongan,perk_sub_gol,perk_kd_akun)") Then
                        MessageBox.Show("No.Akun sudah ada/terpakai")
                        in_akun.Focus()
                    End If
                Else
                    MessageBox.Show("No.Akun tidak boleh 0")
                    in_akun.Focus()
                End If
            ElseIf in_akun.Text = Nothing Then
                Exit Sub
            Else
                MessageBox.Show("No.Akun harus angka")
                in_akun.Focus()
            End If
        End If
    End Sub

    '-------------INPUT
    Private Sub in_akun_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_akun.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cb_jenis_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_jenis.KeyDown
        keyshortenter(cb_gol, e)
    End Sub

    Private Sub cb_gol_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_gol.KeyDown
        keyshortenter(cb_subgol, e)
    End Sub

    Private Sub cb_subgol_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_subgol.KeyDown
        keyshortenter(in_akun, e)
    End Sub

    Private Sub in_akun_KeyDown(sender As Object, e As KeyEventArgs) Handles in_akun.KeyDown
        keyshortenter(in_akun_n, e)
    End Sub

    Private Sub in_akun_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_akun_n.KeyDown
        keyshortenter(cb_posisi, e)
    End Sub

    Private Sub cb_posisi_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_posisi.KeyDown
        keyshortenter(in_saldoawal, e)
    End Sub

    Private Sub in_saldoawal_KeyDown(sender As Object, e As KeyEventArgs) Handles in_saldoawal.KeyDown
        keyshortenter(bt_simpanperkiraan, e)
    End Sub


End Class