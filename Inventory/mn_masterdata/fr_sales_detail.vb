Public Class fr_sales_detail
    Private gdstatus As Integer = 1
    Private act As String = "INSERT"

    Private Sub loadDataSales(kode As String)
        readcommd("SELECT * FROM data_salesman_master WHERE salesman_kode='" & kode & "' ORDER BY salesman_version DESC LIMIT 1")
        If rd.HasRows Then
            in_kode.Text = kode
            in_namasales.Text = rd.Item("salesman_nama")
            in_alamatsales.Text = rd.Item("salesman_alamat")
            date_kerja.Value = rd.Item("salesman_tanggal_masuk")
            cb_jenis.SelectedValue = rd.Item("salesman_jenis")
            in_lahir_kota.Text = rd.Item("salesman_lahir_kota")
            date_lahir_tgl.Value = rd.Item("salesman_lahir_tanggal")
            in_telpsales.Text = rd.Item("salesman_hp")
            in_faxsales.Text = rd.Item("salesman_fax")
            in_nik.Text = rd.Item("salesman_nik")
            in_target.Value = rd.Item("salesman_target")
            in_bank_nama.Text = rd.Item("salesman_bank_nama")
            in_bank_rek.Text = rd.Item("salesman_bank_rekening")
            in_bank_an.Text = rd.Item("salesman_bank_atasnama")
            gdstatus = rd.Item("salesman_status")
            in_status_kode.Text = setStatus(gdstatus)
        End If
        rd.Close()

        Dim q As String = "SELECT " _
                              & "reg.salesman_reg_date,reg.salesman_reg_alias, " _
                              & "upd.salesman_reg_date as salesman_upd_date, " _
                              & "upd.salesman_reg_alias as salesman_upd_alias " _
                          & "FROM (SELECT " _
                              & "salesman_kode, salesman_reg_date,salesman_reg_alias, salesman_version " _
                              & "FROM data_salesman_master WHERE salesman_kode='{0}' ORDER BY salesman_version ASC LIMIT 1 " _
                          & ") reg LEFT JOIN (SELECT " _
                              & "salesman_kode, salesman_reg_date,salesman_reg_alias, salesman_version " _
                              & "FROM data_salesman_master WHERE salesman_kode='{0}' ORDER BY salesman_version DESC LIMIT 1 " _
                          & ") upd ON reg.salesman_kode=upd.salesman_kode"
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            txtRegdate.Text = rd.Item("salesman_reg_date")
            txtRegAlias.Text = rd.Item("salesman_reg_alias")
            txtUpdDate.Text = rd.Item("salesman_upd_date")
            txtUpdAlias.Text = rd.Item("salesman_upd_alias")
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
        Dim q As String = "SELECT CONCAT_WS('/',salesman_id,salesman_kode,salesman_version), salesman_version FROM data_salesman_master WHERE salesman_kode ='" & kode & "' ORDER BY salesman_version DESC LIMIT 1"

        readcommd(q)
        If rd.HasRows Then
            ver = rd.Item("salesman_version")
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

        createLogAct(act, "data_supplier_master", dataid)
    End Sub

    '--------------- load
    Private Sub fr_sales_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        op_con()
        in_status_kode.Text = setStatus(gdstatus)

        With cb_jenis
            .DataSource = jenisSales()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        If bt_simpansales.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadDataSales(.Text)
            End With
        End If

        in_namasales.Focus()
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalsales.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalsales.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub fr_sales_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        For Each tx As TextBox In {in_kode, in_namasales, in_alamatsales, in_bank_an, in_bank_nama, in_bank_rek, in_faxsales, in_lahir_kota, in_nik, in_telpsales}
            tx.Clear()
        Next
        in_target.Value = 0
    End Sub

    '----------------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpansales.PerformClick()
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
        If MessageBox.Show("Hapus Data Salesman?", "Data Salesman", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            gdstatus = 9
            in_status_kode.Text = setStatus(gdstatus)
            act = "DELETE"
        End If
    End Sub

    '------------------ save
    Private Sub bt_simpansales_Click(sender As Object, e As EventArgs) Handles bt_simpansales.Click
        Dim data, dataCol As String()
        Dim querycheck As Boolean = False
        Dim query As String = "INSERT INTO data_salesman_master({0}) SELECT {1} FROM data_salesman_master WHERE salesman_kode={2}"

        'DONE : TODO : (?) : GENERATE KODE SALES -> PREVENT DUPLICATE AND ACCIDENTALY OVERWRITE EXISTING DATA
        'TODO : (?) : ADD REFFERRAL CODE INPUT
        If in_namasales.Text = Nothing Then
            MessageBox.Show("Nama belum di input")
            in_namasales.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan Data Salesman?", "Data Salesman", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'WITH DATA-VERSION-ING  & USER ACT LOG
            If Trim(in_kode.Text) = Nothing Then
                Dim x As Integer = 0
                readcommd("SELECT SUBSTR(salesman_kode,3,5) FROM data_salesman_master GROUP BY salesman_kode ORDER BY salesman_kode DESC LIMIT 1")
                If rd.HasRows Then
                    x = CInt(rd.Item(0)) + 1
                Else
                    x = 1
                End If
                rd.Close()
                in_kode.Text = "GD" & x.ToString("D5")
            End If

            dataCol = {
                "salesman_kode", "salesman_nama", "salesman_alamat",
                "salesman_tanggal_masuk", "salesman_jenis", "salesman_lahir_kota",
                "salesman_lahir_tanggal", "salesman_hp", "salesman_fax",
                "salesman_nik", "salesman_target", "salesman_bank_nama",
                "salesman_bank_rekening", "salesman_bank_atasnama",
                "salesman_status", "salesman_reg_date", "salesman_reg_alias",
                "salesman_version"
                }

            data = {
                "'" & in_kode.Text & "'",
                "'" & in_namasales.Text & "'",
                "'" & in_alamatsales.Text & "'",
                "'" & date_kerja.Value.ToString("yyyy-MM-dd") & "'",
                "'" & cb_jenis.SelectedValue & "'",
                "'" & in_lahir_kota.Text & "'",
                "'" & date_lahir_tgl.Value.ToString("yyyy-MM-dd") & "'",
                "'" & in_telpsales.Text & "'",
                "'" & in_faxsales.Text & "'",
                "'" & in_nik.Text & "'",
                "'" & in_target.Value & "'",
                "'" & in_bank_nama.Text & "'",
                "'" & in_bank_rek.Text & "'",
                "'" & in_bank_an.Text & "'",
                "'" & gdstatus & "'",
                "NOW()",
                "'" & loggeduser.user_id & "'",
                "MAX(salesman_version)+1"
            }

            op_con()
            Dim q As String = String.Format(query, String.Join(",", dataCol), String.Join(",", data), "'" & in_kode.Text & "'")
            Console.WriteLine(q)
            querycheck = commnd(q)

            If querycheck = False Then
                MessageBox.Show("Data gagal tersimpan")
                Exit Sub
            Else
                'DONE : TODO : WRITE LOG
                writeLogAct(in_kode.Text)
                MessageBox.Show("Data tersimpan")
                frmsales.in_cari.Clear()
                populateDGVUserCon("sales", "", frmsales.dgv_list)
                Me.Close()
            End If
        End If
    End Sub

    '------------------ cb prevent input
    Private Sub cb_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_jenis.KeyPress
        e.Handled = True
    End Sub

    '------------------ txtbox numeric
    Private Sub in_telpsales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_telpsales.KeyPress, in_nik.KeyPress, in_faxsales.KeyPress, in_bank_rek.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    '----------------- numeric
    Private Sub in_target_Enter(sender As Object, e As EventArgs) Handles in_target.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_target_Leave(sender As Object, e As EventArgs) Handles in_target.Leave
        numericLostFocus(sender)
    End Sub

    '----------------- input
    Private Sub in_namasales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_namasales.KeyDown
        keyshortenter(cb_jenis, e)
    End Sub

    Private Sub cb_jenis_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_jenis.KeyDown
        keyshortenter(in_alamatsales, e)
    End Sub

    Private Sub in_lahir_kota_KeyDown(sender As Object, e As KeyEventArgs) Handles in_lahir_kota.KeyDown
        keyshortenter(date_lahir_tgl, e)
    End Sub

    Private Sub date_lahir_tgl_KeyDown(sender As Object, e As KeyEventArgs) Handles date_lahir_tgl.KeyDown
        keyshortenter(date_kerja, e)
    End Sub

    Private Sub date_kerja_KeyDown(sender As Object, e As KeyEventArgs) Handles date_kerja.KeyDown
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
        keyshortenter(bt_simpansales, e)
    End Sub
End Class