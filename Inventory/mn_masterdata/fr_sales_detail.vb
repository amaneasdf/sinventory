Public Class fr_sales_detail
    Private slsStatus As String = "1"

    'Protected Overrides Sub WndProc(ByRef m As Message)
    '    Const WM_NCLBUTTONDOWN As Integer = 161
    '    Const WM_SYSCOMMAND As Integer = 274
    '    Const HTCAPTION As Integer = 2
    '    Const SC_MOVE As Integer = 61456

    '    If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32 = SC_MOVE) Then
    '        Exit Sub
    '    End If

    '    If (m.Msg = WM_NCLBUTTONDOWN) AndAlso (m.WParam.ToInt32 = HTCAPTION) Then
    '        Exit Sub
    '    End If

    '    MyBase.WndProc(m)
    'End Sub

    Private Sub loadDataSales(kode As String)
        op_con()

        Try
            readcommd("SELECT salesman_nama,salesman_alamat,salesman_tanggal_masuk,salesman_jenis,salesman_lahir_kota,salesman_lahir_tanggal,salesman_hp, " _
                      & "salesman_fax,salesman_nik,salesman_target,salesman_bank_nama,salesman_bank_rekening,salesman_bank_atasnama,salesman_status, " _
                      & "IFNULL(salesman_reg_alias,'') salesman_reg_alias, IFNULL(salesman_reg_date,'00/00/0000 00:00:00') salesman_reg_date, " _
                      & "IFNULL(salesman_upd_alias,'') salesman_upd_alias, IFNULL(salesman_upd_date,'00/00/0000 00:00:00') salesman_upd_date " _
                      & "FROM data_salesman_master WHERE salesman_kode='" & kode & "'")
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
                slsStatus = rd.Item("salesman_status")
                txtRegAlias.Text = rd.Item("salesman_reg_alias")
                txtRegdate.Text = rd.Item("salesman_reg_date")
                txtUpdDate.Text = rd.Item("salesman_upd_date")
                txtUpdAlias.Text = rd.Item("salesman_upd_alias")
            End If
            rd.Close()
            setStatus()

            If loggeduser.allowedit_master = False Then
                bt_simpansales.Visible = False
                bt_batalsales.Text = "OK"
                mn_save.Enabled = False
                mn_deact.Enabled = False
                mn_del.Enabled = False
            End If
        Catch ex As Exception
            logError(ex, True)
            MessageBox.Show("Terjadi kesalahan saat pengambilan data.", "Detail Salesman", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        Finally
            Try
                If rd.IsClosed = False Then
                    rd.Close()
                End If
            Catch ex As Exception
                logError(ex, True)
            End Try
        End Try
    End Sub

    Private Sub setStatus()
        Select Case slsStatus
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

    'SAVE DATA
    Private Sub saveData()
        Dim data1 As String()
        Dim querycheck As Boolean = False
        Dim q As String = ""

        Me.Cursor = Cursors.WaitCursor

        op_con()
        data1 = {
            "salesman_nama='" & in_namasales.Text.Replace("'", "`") & "'",
            "salesman_alamat='" & in_alamatsales.Text.Replace("'", "`") & "'",
            "salesman_tanggal_masuk='" & date_kerja.Value.ToString("yyyy-MM-dd") & "'",
            "salesman_jenis='" & cb_jenis.SelectedValue & "'",
            "salesman_lahir_kota='" & in_lahir_kota.Text.Replace("'", "`") & "'",
            "salesman_lahir_tanggal='" & date_lahir_tgl.Value.ToString("yyyy-MM-dd") & "'",
            "salesman_hp='" & in_telpsales.Text & "'",
            "salesman_fax='" & in_faxsales.Text & "'",
            "salesman_nik='" & in_nik.Text & "'",
            "salesman_target='" & in_target.Value.ToString.Replace(",", ".") & "'",
            "salesman_bank_nama='" & in_bank_nama.Text.Replace("'", "`") & "'",
            "salesman_bank_rekening='" & in_bank_rek.Text & "'",
            "salesman_bank_atasnama='" & in_bank_an.Text & "'",
            "salesman_status='" & slsStatus & "'"
            }

        If bt_simpansales.Text = "Simpan" Then
            'GENERATE CODE
            If Trim(in_kode.Text) = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT SUBSTRING(salesman_kode,4) as ss FROM data_salesman_master WHERE salesman_kode LIKE 'P%' " _
                          & "AND SUBSTRING(salesman_kode,4) REGEXP '^[0-9]+$' ORDER BY ss DESC LIMIT 1")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()

                in_kode.Text = "P" & CInt(cb_jenis.SelectedValue).ToString("D2") & no.ToString("D3")
            Else
                If checkdata("data_salesman_master", "'" & in_kode.Text & "'", "salesman_kode") = True Then
                    MessageBox.Show("Kode " & in_kode.Text & " sudah ada")
                    in_kode.Focus()
                    Exit Sub
                End If
            End If

            q = "INSERT INTO data_salesman_master SET salesman_kode='{0}',{1},salesman_reg_date=NOW(),salesman_reg_alias='{2}'"
        ElseIf bt_simpansales.Text = "Update" Then
            q = "UPDATE data_salesman_master SET {1}, salesman_upd_date=NOW(),salesman_upd_alias='{2}' WHERE salesman_kode='{0}'"
        End If
        querycheck = commnd(String.Format(q, Trim(in_kode.Text), String.Join(",", data1), loggeduser.user_id))

        Me.Cursor = Cursors.Default

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            'frmsales.in_cari.Clear()
            'populateDGVUserCon("sales", "", frmsales.dgv_list)
            doRefreshTab({pgsales})
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalsales.Click
        If MessageBox.Show("Tutup Form?", "Detail Salesman", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
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

    'MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpansales.PerformClick()
    End Sub

    Private Sub mn_deact_Click(sender As Object, e As EventArgs) Handles mn_deact.Click
        If mn_deact.Text = "Deactivate" Then
            slsStatus = "0"
        ElseIf mn_deact.Text = "Activate" Then
            slsStatus = "1"
        End If
        setStatus()
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click
        'brgStatus = 9
        'UPDATE STATUS TO 9
        'setStatus()
    End Sub

    'LOAD
    Private Sub fr_sales_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        op_con()
        With cb_jenis
            .DataSource = jenisSales()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With
        setStatus()

        If bt_simpansales.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadDataSales(.Text)
            End With
        End If
    End Sub

    'SAVE
    Private Sub bt_simpansales_Click(sender As Object, e As EventArgs) Handles bt_simpansales.Click
        If in_namasales.Text = Nothing Then
            MessageBox.Show("Nama belum di input")
            in_namasales.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan data sales?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    'UI
    '------------------ cb prevent input
    Private Sub cb_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_jenis.KeyPress
        e.Handled = True
    End Sub

    '------------------ txtbox numeric
    Private Sub in_telpsales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_nik.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub in_npwpsupplier_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_telpsales.KeyPress, in_faxsales.KeyPress, in_bank_rek.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> ControlChars.Back AndAlso e.KeyChar <> "-" Then
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

    '-------------input
    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(in_namasales, e)
    End Sub

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