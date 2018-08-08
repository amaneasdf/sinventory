Public Class fr_perkiraan_detail
    Private gdstatus As Integer = 1
    Private act As String = "INSERT"

    Private Sub loadDataPerkiraan(kode As String)
        readcommd("SELECT * FROM setup_perkiraan WHERE perk_no='" & kode & "' ORDER BY perk_version DESC LIMIT 1")
        If rd.HasRows Then
            in_no.Text = kode
            in_parent.Text = rd.Item("perk_parent")
            in_nama.Text = rd.Item("perk_nama")
            in_ket.Text = rd.Item("perk_keterangan")
            cb_jenis.SelectedValue = rd.Item("perk_jenis")
            cb_neraca.SelectedValue = rd.Item("perk_neraca")
            cb_posisi.SelectedValue = rd.Item("perk_d_or_k")
            cb_posisi_neraca.SelectedValue = rd.Item("perk_neraca_d_or_k")
            gdstatus = rd.Item("perk_status")
        End If
        rd.Close()

        Dim q As String = "SELECT " _
                              & "reg.perk_reg_date,reg.perk_reg_alias, " _
                              & "upd.perk_reg_date as perk_upd_date, " _
                              & "upd.perk_reg_alias as perk_upd_alias " _
                          & "FROM (SELECT " _
                              & "perk_kode, perk_reg_date,perk_reg_alias, perk_version " _
                              & "FROM setup_perkiraan WHERE perk_kode='{0}' ORDER BY perk_version ASC LIMIT 1 " _
                          & ") reg LEFT JOIN (SELECT " _
                              & "perk_kode, perk_reg_date,perk_reg_alias, perk_version " _
                              & "FROM setup_perkiraan WHERE perk_kode='{0}' ORDER BY perk_version DESC LIMIT 1 " _
                          & ") upd ON reg.perk_kode=upd.perk_kode"
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            txtRegdate.Text = rd.Item("perk_reg_date")
            txtRegAlias.Text = rd.Item("perk_reg_alias")
            txtUpdDate.Text = rd.Item("perk_upd_date")
            txtUpdAlias.Text = rd.Item("perk_upd_alias")
        End If
        rd.Close()
    End Sub

    Private Function setStatus(statcode As Integer) As String
        Dim x As String = "A"
        Select Case statcode
            Case 1
                x = "Aktif"
            Case 2
                x = "NonAktif"
            Case 9
                x = "Delete"
            Case Else
                x = "Err"
        End Select
        Return x
    End Function

    Private Sub writeLogAct(kode As String)
        Dim ver, dataid As String
        Dim q As String = "SELECT CONCAT_WS('/',perk_id,perk_no,perk_version), perk_version FROM setup_perkiraan WHERE perk_no ='" & kode & "' ORDER BY perk_version DESC LIMIT 1"

        readcommd(q)
        If rd.HasRows Then
            ver = rd.Item("perk_version")
            dataid = rd.Item(0)
        Else
            ver = "-1"
            dataid = "err"
        End If
        rd.Close()

        If ver = "0" Then
            act = "INSERT"
        ElseIf CInt(ver) > 0 And gdstatus <> 9 Then
            act = "UPDATE"
        ElseIf CInt(ver) < 0 Then
            act = "ERR"
        End If
        Console.Write(act & "-" & dataid)

        createLogAct(act, "setup_perkiraan", dataid)
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
    Private Sub cb_status_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    '----------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanperkiraan.PerformClick()
    End Sub

    Private Sub mn_status_switch_Click(sender As Object, e As EventArgs) Handles mn_status_switch.Click
        Select Case gdstatus
            Case 1
                gdstatus = 2
            Case 2
                gdstatus = 1
            Case 9
                gdstatus = 1
                act = "UPDATE"
            Case Else
                Exit Sub
        End Select
        in_status_kode.Text = setStatus(gdstatus)
    End Sub

    Private Sub mn_status_del_Click(sender As Object, e As EventArgs) Handles mn_status_del.Click
        If MessageBox.Show("Hapus Data Perkiraan?", "Data Perkiraan", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            gdstatus = 9
            in_status_kode.Text = setStatus(gdstatus)
            act = "DELETE"
        End If
    End Sub

    '-------------------- CB PREVENT OTHER INPUT
    Private Sub cb_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_posisi_neraca.KeyPress, cb_posisi.KeyPress, cb_neraca.KeyPress, cb_jenis.KeyPress
        e.Handled = True
    End Sub

    '------------------------------ TXTBOX NUMERIC INPUT
    Private Sub in_no_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_parent.KeyPress, in_no.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    '-------------------- Load
    Private Sub fr_perkiraan_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_jenis
            .DataSource = jenisPerkiraan()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        Dim pos As ComboBox() = {cb_posisi, cb_posisi_neraca}
        For Each x As ComboBox In pos
            With x
                .DataSource = jenisDeb()
                .DisplayMember = "Text"
                .ValueMember = "Value"
                .SelectedIndex = 0
            End With
        Next

        With cb_neraca
            .DataSource = jenisJurnal()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        op_con()
        in_status_kode.Text = setStatus(gdstatus)

        If bt_simpanperkiraan.Text = "Update" Then
            With in_no
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadDataPerkiraan(.Text)
            End With
        End If

        in_no.Focus()
    End Sub

    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click
        Dim data, dataCol As String()
        Dim querycheck As Boolean = False
        Dim query As String = "INSERT INTO setup_perkiraan({0}) SELECT {1} FROM setup_perkiraan WHERE perk_no={2}"

        'DONE : TODO : (?) : GENERATE KODE GUDANG -> PREVENT DUPLICATE AND ACCIDENTALY OVERWRITE EXISTING DATA
        'TODO : (?) : ADD REFFERRAL CODE INPUT
        'DONE(?) : TODO : CHECK WHETHER NO_PERK WTH NO_HEADER ALREADY EXIST
        If Trim(in_no.Text) = Nothing Then
            MessageBox.Show("Nomor perkiraan belum di input")
            in_no.Focus()
            Exit Sub
        End If
        If bt_simpanperkiraan.Text <> "Update" And checkdata("setup_perkiraan", in_no.Text, "perk_no") = True Then
            MessageBox.Show("Nomor perkiraan sudah pernah diinputkan")
            in_no.Focus()
            Exit Sub
        End If
        If Trim(in_nama.Text) = Nothing Then
            MessageBox.Show("Nama perkiraan belum di input")
            in_nama.Focus()
            Exit Sub
        End If
        If cb_jenis.SelectedValue = Nothing Then
            MessageBox.Show("Nama belum di input")
            cb_jenis.Focus()
            Exit Sub
        End If
        If cb_neraca.SelectedValue = Nothing Then
            MessageBox.Show("Nama belum di input")
            cb_neraca.Focus()
            Exit Sub
        End If
        If cb_posisi.SelectedValue = Nothing Then
            MessageBox.Show("Nama belum di input")
            cb_posisi.Focus()
            Exit Sub
        End If

        op_con()
        If MessageBox.Show("Simpan Data Perkiraan?", "Data Perkiraan", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'WITH DATA-VERSION-ING  & USER ACT LOG
            'If Trim(in_kode.Text) = Nothing Then
            '    Dim x As Integer = 0
            '    readcommd("SELECT SUBSTR(perk_kode,3,4) FROM setup_perkiraan GROUP BY perk_kode ORDER BY perk_kode DESC LIMIT 1")
            '    If rd.HasRows Then
            '        x = CInt(rd.Item(0)) + 1
            '    Else
            '        x = 1
            '    End If
            '    rd.Close()
            '    in_kode.Text = "PK" & x.ToString("D4")
            'End If

            dataCol = {
                "perk_no", "perk_parent", "perk_nama", "perk_jenis", "perk_neraca",
                "perk_d_or_k", "perk_neraca_d_or_k", "perk_keterangan",
                "perk_reg_date", "perk_reg_alias",
                "perk_status", "perk_version"
                }
            data = {
                "'" & in_no.Text & "'",
                "'" & in_parent.Text & "'",
                "'" & in_nama.Text & "'",
                "'" & cb_jenis.SelectedValue & "'",
                "'" & cb_neraca.SelectedValue & "'",
                "'" & cb_posisi.SelectedValue & "'",
                "'" & cb_posisi_neraca.SelectedValue & "'",
                "'" & in_ket.Text & "'",
                "NOW()",
                "'" & loggeduser.user_id & "'",
                "'" & gdstatus & "'",
                "MAX(perk_version)+1"
                }

            Dim q As String = String.Format(query, String.Join(",", dataCol), String.Join(",", data), "'" & in_no.Text & "'")
            Console.WriteLine(q)
            querycheck = commnd(q)

            If querycheck = False Then
                Exit Sub
            Else
                'TODO : WRITE LOG
                writeLogAct(in_no.Text)
                MessageBox.Show("Data Perkiraan Tersimpan", "Data Perkiraan")
                frmperkiraan.in_cari.Clear()
                populateDGVUserCon("perkiraan", "", frmperkiraan.dgv_list)
                Me.Close()
            End If
        End If
    End Sub

    '---------------------- INPUT
    Private Sub in_no_KeyDown(sender As Object, e As KeyEventArgs) Handles in_no.KeyDown
        keyshortenter(in_parent, e)
    End Sub

    Private Sub in_parent_KeyDown(sender As Object, e As KeyEventArgs) Handles in_parent.KeyDown
        keyshortenter(cb_jenis, e)
    End Sub

    Private Sub cb_jenis_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_jenis.KeyDown
        keyshortenter(in_nama, e)
    End Sub

    Private Sub in_nama_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nama.KeyDown
        keyshortenter(cb_posisi, e)
    End Sub

    Private Sub cb_posisi_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_posisi.KeyDown
        keyshortenter(cb_neraca, e)
    End Sub

    Private Sub cb_neraca_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_neraca.KeyDown
        keyshortenter(cb_posisi_neraca, e)
    End Sub

    Private Sub cb_posisi_neraca_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_posisi_neraca.KeyDown
        keyshortenter(in_ket, e)
    End Sub
End Class