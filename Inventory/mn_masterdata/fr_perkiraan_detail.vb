Public Class fr_perkiraan_detail
    Private prkStatus As String = "1"
    Private id As String = ""
    Private tipeAkun As String = "ACC"

    Private Sub loadDataPerkiraan(kode As String)
        Dim q As String = "SELECT perk_nama_akun, perk_d_or_k, perk_saldo_awal, perk_tipe, perk_status, perk_reg_date, perk_reg_alias, " _
                            & "perk_upd_date, perk_upd_alias FROM data_perkiraan WHERE perk_kode='{0}'"
        Dim q2 As String = "SELECT perk_gol_nama, perk_gol_pos, perk_gol_status, perk_gol_reg_date, perk_gol_reg_alias " _
                           & "FROM data_perkiraan_gol WHERE perk_gol_kode='{0}'"

        readcommd(String.Format(IIf(kode.Length = 6, q, q2), kode))
        If rd.HasRows Then
            in_kode.Text = kode
            If kode.Length = 6 Then
                in_akun_n.Text = rd.Item("perk_nama_akun")
                cb_posisi.SelectedValue = rd.Item("perk_d_or_k")
                in_saldoawal.Value = rd.Item("perk_saldo_awal")
                tipeAkun = rd.Item("perk_tipe")
                prkStatus = rd.Item("perk_status")
                txtRegAlias.Text = rd.Item("perk_reg_alias")
                txtRegdate.Text = rd.Item("perk_reg_date")
                Try
                    txtUpdDate.Text = rd.Item("perk_upd_date")
                Catch ex As Exception
                    consoleWriteLine(ex.Message)
                    txtUpdDate.Text = "00/00/0000 00:00:00"
                End Try
                txtUpdAlias.Text = rd.Item("perk_upd_alias")
            Else
                in_akun_n.Text = rd.Item("perk_gol_nama")
                cb_posisi.SelectedValue = rd.Item("perk_gol_pos")
                prkStatus = rd.Item("perk_gol_status")
                txtRegAlias.Text = rd.Item("perk_gol_reg_alias")
                txtRegdate.Text = rd.Item("perk_gol_reg_date")
            End If

        End If
        rd.Close()

        in_kode_parent.Text = sLeft(in_kode.Text, in_kode.Text.Length - 2)
        in_kode_akun.Text = Strings.Right(in_kode.Text, 2)
        cb_jenis.SelectedValue = Strings.Left(in_kode.Text, 2)
        loadCbParent(cb_jenis.SelectedValue)
        cb_parent.SelectedValue = in_kode_parent.Text
        'loadJenis(sLeft(in_kode.Text, 2))


        setStatus()
        inputSwitch(True)
        bt_simpanperkiraan.Enabled = loggeduser.allowedit_master
    End Sub

    Private Sub setStatus()
        Select Case prkStatus
            Case 0
                mn_deact.Text = "Activate"
                in_status.Text = "Non-Aktif"
            Case 1
                mn_deact.Text = "Deactivate"
                in_status.Text = "Aktif"
            Case 9
                mn_deact.Enabled = False
                in_status.Text = "Delete"
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub inputSwitch(sw As Boolean)
        If sw = True Then
            cb_jenis.Enabled = False
            cb_parent.Enabled = False
            in_saldoawal.Increment = 0
        Else
            cb_jenis.Enabled = True
            cb_parent.Enabled = True
            in_saldoawal.Increment = 1000
        End If
        in_kode_akun.ReadOnly = sw
        in_saldoawal.ReadOnly = sw
    End Sub

    Private Sub loadCbParent(kode As String)
        'Dim dt As New DataTable
        'Dim q As String = "SELECT SUBSTR(perk_kode,3,3) as 'Value', perk_nama_akun as 'Text' FROM data_perkiraan " _
        '                  & "WHERE perk_tipe IN ('GOL','SGL') AND perk_status<> 9 AND perk_jenis_akun='{0}'"
        'dt = getDataTablefromDB(String.Format(q, kode))
        With cb_parent
            .DataSource = jenisPerkiraan("gol", kode)
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With
        'loadJenis(kode)
    End Sub

    'Private Sub loadJenis(kode As String)
    '    Dim q As String = "SELECT perk_jen_nama FROM data_perkiraan_jenis WHERE perk_jen_kode='{0}'"
    '    readcommd(String.Format(q, kode))
    '    If rd.HasRows Then
    '        in_jenis.Text = rd.Item(0)
    '    End If
    '    rd.Close()
    'End Sub

    'SAVE DATA
    Private Sub saveData()
        Dim queryCheck As Boolean = False
        Dim queryArr As New List(Of String)
        Dim q, qsaldo As String
        Dim data1 As String()

        Dim qsaldotemp As String = "INSERT INTO data_perkiraan_saldoawal SET perk_saldoawal_kodeakun='{0}', perk_saldoawal_idperiode='{3}', " _
                                     & "{1},perk_saldoawal_reg_date=NOW(),perk_saldoawal_reg_alias='{2}' ON DUPLICATE KEY UPDATE " _
                                     & "{1},perk_saldoawal_upd_date=NOW(),perk_saldoawal_upd_alias='{2}'"

        op_con()
        data1 = {
            "perk_parent='" & cb_parent.SelectedValue & "'",
            "perk_nama_akun='" & in_akun_n.Text & "'",
            "perk_d_or_k='" & cb_posisi.SelectedValue & "'",
            "perk_tipe='" & sLeft(cb_parent.SelectedValue, 2) & "'",
            "perk_saldo_awal='" & in_saldoawal.Value & "'",
            "perk_status='" & prkStatus & "'"
            }
        If bt_simpanperkiraan.Text = "Simpan" Then
            If Trim(in_kode_akun.Text) = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT IFNULL(MAX(RIGHT(perk_kode,2)),0) FROM data_perkiraan WHERE perk_kode LIKE '" & cb_parent.SelectedValue & "%'")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()

                in_kode_akun.Text = no.ToString("D2")
            Else
                If checkdata("data_perkiraan", "'" & in_kode.Text & "'", "perk_kode") = True Then
                    MessageBox.Show("Akun perkiraan dg kode " & in_kode.Text & " sudah pernah diinput", "Akun Perkiraan", MessageBoxButtons.OK)
                    Exit Sub
                End If
            End If
            q = "INSERT INTO data_perkiraan SET perk_kode='{0}',{1},perk_reg_date=NOW(),perk_reg_alias='{2}'"
            qsaldo = qsaldotemp
        Else
            q = "UPDATE data_perkiraan SET {1},perk_upd_date=NOW(),perk_upd_alias='{2}' WHERE perk_kode='{0}'"
            If in_saldoawal.ReadOnly = False Then
                qsaldo = qsaldotemp
            End If
        End If
        queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", data1), loggeduser.user_id))
        If qsaldo <> Nothing Then
            data1 = {
                "perk_saldoawal_nilai=" & in_saldoawal.Value,
                "perk_saldoawal_status='" & prkStatus & "'"
                }
            queryArr.Add(String.Format(qsaldo, in_kode.Text, String.Join(",", data1), loggeduser.user_id, selectperiode.id))
        End If

        'BEGIN TRANSACTION
        queryCheck = startTrans(queryArr)

        If queryCheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            doRefreshTab({pgperkiraan})
            Me.Close()
        End If
    End Sub

    'DRAG FORM
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

    'CLOSE
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalperkiraan.Click
        If MessageBox.Show("Tutup Form?", "Data Akun Perkiraan", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
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

    'MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanperkiraan.PerformClick()
    End Sub

    Private Sub mn_deact_Click(sender As Object, e As EventArgs) Handles mn_deact.Click
        If mn_deact.Text = "Deactivate" Then
            prkStatus = "0"
        ElseIf mn_deact.Text = "Activate" Then
            prkStatus = "1"
        End If
        setStatus()
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click
        'brgStatus = 9
        'UPDATE STATUS TO 9
        'setStatus()
    End Sub

    'LOAD
    Private Sub fr_perkiraan_detail_Load(sender As Object, e As EventArgs) Handles Me.Load
        With cb_jenis
            .DataSource = jenisPerkiraan("jenis")
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
        'With cb_parent
        '    .DataSource = jenisPerkiraan("gol11")
        '    .DisplayMember = "Text"
        '    .ValueMember = "Value"
        '    .SelectedIndex = 0
        'End With
        loadCbParent(cb_jenis.SelectedValue)

        in_cur_saldo.Text = commaThousand(0)

        If bt_simpanperkiraan.Text = "Update" Then
            loadDataPerkiraan(in_kode.Text)
        End If
    End Sub

    'SAVE
    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click
        If cb_jenis.SelectedValue = Nothing Then
            MessageBox.Show("Jenis belum di input")
            cb_jenis.Focus()
            Exit Sub
        End If
        If cb_parent.Enabled = True And cb_parent.SelectedValue = Nothing Then
            MessageBox.Show("Parent belum di input")
            cb_parent.Focus()
            Exit Sub
        End If
        If Trim(in_akun_n.Text) = Nothing Then
            MessageBox.Show("Nama akun belum di input")
            in_akun_n.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan data perkiraan?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    'UI
    '------------------ cb prevent input
    Private Sub cb_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_parent.KeyPress, cb_posisi.KeyPress, cb_jenis.KeyPress
        If e.KeyChar <> ControlChars.Cr Then
            e.Handled = True
        End If
    End Sub

    '------------------ txtbox numeric
    Private Sub in_telpsales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_kode_akun.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    '----------------- numeric
    Private Sub in_target_Enter(sender As Object, e As EventArgs) Handles in_saldoawal.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_target_Leave(sender As Object, e As EventArgs) Handles in_saldoawal.Leave
        numericLostFocus(sender)
    End Sub

    '-------------input
    Private Sub cb_jenis_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_jenis.SelectionChangeCommitted
        If cb_jenis.SelectedValue <> Nothing Then
            loadCbParent(cb_jenis.SelectedValue)
            in_kode_parent.Text = cb_parent.SelectedValue
            in_kode.Text = in_kode_parent.Text & IIf(Trim(in_kode_akun.Text) = Nothing, "00", in_kode_akun.Text)
        End If
    End Sub

    Private Sub cb_parent_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_parent.SelectionChangeCommitted
        If cb_jenis.SelectedValue <> Nothing Then
            in_kode_parent.Text = cb_parent.SelectedValue
            in_kode.Text = in_kode_parent.Text & IIf(Trim(in_kode_akun.Text) = Nothing, "00", in_kode_akun.Text)
        End If
    End Sub

    Private Sub cb_jenis_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_jenis.KeyUp
        keyshortenter(cb_parent, e)
    End Sub

    Private Sub cb_parent_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_parent.KeyUp
        keyshortenter(in_kode_akun, e)
    End Sub

    Private Sub in_kode_akun_KeyUp(sender As Object, e As KeyEventArgs) Handles in_kode_akun.KeyUp
        keyshortenter(in_akun_n, e)
    End Sub

    Private Sub in_akun_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_akun_n.KeyUp
        keyshortenter(cb_posisi, e)
    End Sub

    Private Sub cb_posisi_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_posisi.KeyUp
        keyshortenter(in_saldoawal, e)
    End Sub

    Private Sub in_saldoawal_KeyUp(sender As Object, e As KeyEventArgs) Handles in_saldoawal.KeyUp
        keyshortenter(bt_simpanperkiraan, e)
    End Sub

    '--------kode
    Private Sub in_kode_akun_TextChanged(sender As Object, e As EventArgs) Handles in_kode_akun.TextChanged
        in_kode.Text = in_kode_parent.Text & IIf(Trim(in_kode_akun.Text) = Nothing, "00", in_kode_akun.Text)
    End Sub
End Class