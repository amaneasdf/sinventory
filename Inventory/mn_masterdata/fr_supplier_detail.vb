Public Class fr_supplier_detail
    Private supStatus As String = 1
    Private olddata As String = ""
    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(KodeBarang As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Detail Barang : xxxxxxxxx"

        formstate = FormSet

        If Not FormSet = InputState.Insert Then
            Me.Text += KodeBarang
            Me.lbl_title.Text += " : " & KodeBarang
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            loadDataSupplier(KodeBarang)
            in_kode.ReadOnly = True
            bt_simpansupplier.Text = "Update"
        End If

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        For Each txt As TextBox In {in_namasupplier, in_alamatsupplier, in_telp1supplier, in_telp2supplier, in_faxsupplier, in_cp, in_emailsupplier,
                                    in_npwpsupplier, in_rek_bank, in_rek_giro, in_ket}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        For Each numx As NumericUpDown In {in_term}
            numx.Enabled = AllowInput
        Next

        bt_simpansupplier.Enabled = AllowInput
        mn_deact.Enabled = AllowInput
        mn_save.Enabled = AllowInput
    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        SetUpForm(Nothing, InputState.Insert, AllowInput)
        Me.Show()
        in_namasupplier.Focus()
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, AllowEdit As Boolean)
        SetUpForm(NoFaktur, InputState.Edit, AllowEdit)
        Me.Show()
        in_namasupplier.Focus()
    End Sub

    'LOAD DATA
    Private Sub loadDataSupplier(kode As String)
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "CALL getDataMasterHeader('{0}','SUPPLIER')"
                Using rdx = x.ReadCommand(String.Format(q, kode))
                    Dim red = rdx.Read
                    in_kode.Text = kode
                    in_namasupplier.Text = rdx.Item("supplier_nama")
                    in_alamatsupplier.Text = rdx.Item("supplier_alamat")
                    in_telp1supplier.Text = rdx.Item("supplier_telpon1")
                    in_telp2supplier.Text = rdx.Item("supplier_telpon2")
                    in_faxsupplier.Text = rdx.Item("supplier_fax")
                    in_cp.Text = rdx.Item("supplier_cp")
                    in_emailsupplier.Text = rdx.Item("supplier_email")
                    in_npwpsupplier.Text = rdx.Item("supplier_npwp")
                    in_rek_bank.Text = rdx.Item("supplier_rek_bank")
                    in_rek_giro.Text = rdx.Item("supplier_rek_bg")
                    in_ket.Text = rdx.Item("supplier_keterangan")
                    in_term.Text = rdx.Item("supplier_term")
                    supStatus = rdx.Item("supplier_status")
                    txtRegAlias.Text = rdx.Item("supplier_reg_alias")
                    txtRegdate.Text = rdx.Item("supplier_reg_date")
                    txtUpdDate.Text = rdx.Item("supplier_upd_date")
                    txtUpdAlias.Text = rdx.Item("supplier_upd_alias")
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Detail Barang", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End Using
        setStatus()

        'Dim _data As New List(Of String)
        'Try
        '    readcommd("SELECT supplier_nama,supplier_alamat,supplier_telpon1,supplier_telpon2,supplier_fax,supplier_cp,supplier_email,supplier_npwp,supplier_rek_bank, " _
        '          & "supplier_rek_bg,supplier_keterangan,supplier_term,supplier_status,IFNULL(supplier_reg_alias,'') supplier_reg_alias, " _
        '          & "IFNULL(supplier_reg_date,'00/00/0000 00:00:00') supplier_reg_date,IFNULL(supplier_upd_alias,'') supplier_upd_alias, " _
        '          & "IFNULL(supplier_upd_date,'00/00/0000 00:00:00') supplier_upd_date FROM data_supplier_master WHERE supplier_kode='" & kode & "'")
        '    If rd.HasRows Then
        '        in_kode.Text = kode
        '        in_namasupplier.Text = rd.Item("supplier_nama")
        '        in_alamatsupplier.Text = rd.Item("supplier_alamat")
        '        in_telp1supplier.Text = rd.Item("supplier_telpon1")
        '        in_telp2supplier.Text = rd.Item("supplier_telpon2")
        '        in_faxsupplier.Text = rd.Item("supplier_fax")
        '        in_cp.Text = rd.Item("supplier_cp")
        '        in_emailsupplier.Text = rd.Item("supplier_email")
        '        in_npwpsupplier.Text = rd.Item("supplier_npwp")
        '        in_rek_bank.Text = rd.Item("supplier_rek_bank")
        '        in_rek_giro.Text = rd.Item("supplier_rek_bg")
        '        in_ket.Text = rd.Item("supplier_keterangan")
        '        in_term.Text = rd.Item("supplier_term")
        '        supStatus = rd.Item("supplier_status")
        '        txtRegAlias.Text = rd.Item("supplier_reg_alias")
        '        txtRegdate.Text = rd.Item("supplier_reg_date")
        '        txtUpdDate.Text = rd.Item("supplier_upd_date")
        '        txtUpdAlias.Text = rd.Item("supplier_upd_alias")
        '    End If
        '    For i = 0 To rd.FieldCount - 1
        '        _data.Add(rd.Item(i))
        '    Next
        '    olddata = String.Join(";", _data)
        '    rd.Close()
        '    setStatus()

        '    If loggeduser.allowedit_master = False Then
        '        bt_simpansupplier.Visible = False
        '        bt_batalsupplier.Text = "OK"
        '        mn_deact.Enabled = False
        '        mn_save.Enabled = False
        '        mn_del.Enabled = False
        '    End If
        'Catch ex As Exception
        '    logError(ex, True)
        '    MessageBox.Show("Terjadi kesalahan saat pengambilan data.", "Detail Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Me.Close()
        'Finally
        '    Try
        '        If rd.IsClosed = False Then
        '            rd.Close()
        '        End If
        '    Catch ex As Exception
        '        logError(ex, True)
        '    End Try
        'End Try
    End Sub

    Private Sub setStatus()
        Select Case supStatus
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

    '-------------- save
    Private Sub bt_simpansupplier_Click(sender As Object, e As EventArgs) Handles bt_simpansupplier.Click
        Dim _data As New List(Of String)
        _data.AddRange({in_namasupplier.Text.Replace("'", "`"), in_alamatsupplier.Text.Replace("'", "`"), in_telp1supplier.Text})
        If in_namasupplier.Text = Nothing Then
            MessageBox.Show("Nama supplier belum di input")
            in_namasupplier.Focus()
            Exit Sub
        End If

        op_con()
        If MessageBox.Show("Simpan data supplier?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim data1 As String()
            Dim q As String = ""
            Dim querycheck As Boolean = False

            data1 = {
                "supplier_nama='" & in_namasupplier.Text.Replace("'", "`") & "'",
                "supplier_alamat='" & in_alamatsupplier.Text.Replace("'", "`") & "'",
                "supplier_telpon1='" & in_telp1supplier.Text & "'",
                "supplier_telpon2='" & in_telp2supplier.Text & "'",
                "supplier_fax='" & in_faxsupplier.Text & "'",
                "supplier_cp='" & in_cp.Text.Replace("'", "`") & "'",
                "supplier_email='" & in_emailsupplier.Text & "'",
                "supplier_npwp='" & in_npwpsupplier.Text & "'",
                "supplier_rek_bg='" & in_rek_giro.Text & "'",
                "supplier_rek_bank='" & in_rek_bank.Text & "'",
                "supplier_term=" & in_term.Value,
                "supplier_keterangan='" & in_ket.Text.Replace("'", "`") & "'",
                "supplier_status='" & supStatus & "'"
                }

            op_con()
            If bt_simpansupplier.Text = "Simpan" Then
                'GENERATE CODE
                If in_kode.Text = Nothing Then
                    Dim no As Integer = 1
                    readcommd("SELECT RIGHT(supplier_kode,3) as ss FROM data_supplier_master WHERE supplier_kode LIKE 'S%' " _
                              & "AND RIGHT(supplier_kode,3) REGEXP '^[0-9]+$' ORDER BY ss DESC LIMIT 1")
                    If rd.HasRows Then
                        no = CInt(rd.Item(0)) + 1
                    End If
                    rd.Close()

                    in_kode.Text = "S" & no.ToString("D3")
                Else
                    If checkdata("data_supplier_master", "'" & in_kode.Text & "'", "supplier_kode") = True Then
                        MessageBox.Show("Kode " & in_kode.Text & " sudah ada")
                        in_kode.Focus()
                        Exit Sub
                    End If

                End If

                q = "INSERT INTO data_supplier_master SET supplier_kode='{0}',{1},supplier_reg_date=NOW(), supplier_reg_alias='{2}'"
            ElseIf bt_simpansupplier.Text = "Update" Then
                q = "UPDATE data_supplier_master SET {1},supplier_upd_date=NOW(), supplier_upd_alias='{2}' WHERE supplier_kode='{0}'"
            End If
            querycheck = commnd(String.Format(q, Trim(in_kode.Text), String.Join(",", data1), loggeduser.user_id))

            If querycheck = False Then
                Exit Sub
            Else
                MessageBox.Show("Data tersimpan")
                doRefreshTab({pgsupplier, pgpembelian, pgreturbeli, pghutangawal, pghutangbayar, pghutangbgo})
                'frmsupplier.in_cari.Clear()
                'populateDGVUserCon("supplier", "", frmsupplier.dgv_list)
                Me.Close()
            End If
        End If
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalsupplier.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalsupplier.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub fr_supplier_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        For Each tx As TextBox In {in_kode, in_alamatsupplier, in_cp, in_emailsupplier, in_faxsupplier, in_ket, in_namasupplier, in_npwpsupplier, in_rek_bank, in_rek_giro, in_telp1supplier, in_telp2supplier}
            tx.Clear()
        Next
        in_term.Value = 0
    End Sub

    '------------------ menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpansupplier.PerformClick()
    End Sub

    Private Sub mn_deact_Click(sender As Object, e As EventArgs) Handles mn_deact.Click
        Dim ckdata = MasterConfirmValid(in_ket.Text)
        If Not ckdata Then Exit Sub
        If mn_deact.Text = "Deactivate" Then
            supStatus = "0"
        ElseIf mn_deact.Text = "Activate" Then
            supStatus = "1"
        End If
        setStatus()
        bt_simpansupplier.PerformClick()
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click
        'supStatus = 9
        'UPDATE STATUS TO 9
        'setStatus()
    End Sub

    '---------------- numeric
    Private Sub in_term_Enter(sender As Object, e As EventArgs) Handles in_term.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_term_Leave(sender As Object, e As EventArgs) Handles in_term.Leave
        numericLostFocus(sender)
    End Sub

    '--------------- textbox numeric
    Private Sub in_npwpsupplier_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_telp2supplier.KeyPress, in_telp1supplier.KeyPress, in_npwpsupplier.KeyPress, in_faxsupplier.KeyPress
        e.Handled = Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "-"
    End Sub

    Private Sub in_namasupplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_namasupplier.KeyDown
        keyshortenter(in_alamatsupplier, e)
    End Sub

    Private Sub in_telp1supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_telp1supplier.KeyDown
        keyshortenter(in_telp2supplier, e)
    End Sub

    Private Sub in_telp2supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_telp2supplier.KeyDown
        keyshortenter(in_faxsupplier, e)
    End Sub

    Private Sub in_faxsupplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_faxsupplier.KeyDown
        keyshortenter(in_cp, e)
    End Sub

    Private Sub in_cp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cp.KeyDown
        keyshortenter(in_emailsupplier, e)
    End Sub

    Private Sub in_emailsupplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_emailsupplier.KeyDown
        keyshortenter(in_term, e)
    End Sub

    Private Sub in_term_KeyDown(sender As Object, e As KeyEventArgs) Handles in_term.KeyDown
        keyshortenter(in_npwpsupplier, e)
    End Sub

    Private Sub in_npwpsupplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_npwpsupplier.KeyDown
        keyshortenter(in_rek_bank, e)
    End Sub

    Private Sub in_rek_bank_KeyDown(sender As Object, e As KeyEventArgs) Handles in_rek_bank.KeyDown
        keyshortenter(in_rek_giro, e)
    End Sub

    Private Sub in_rek_giro_KeyDown(sender As Object, e As KeyEventArgs) Handles in_rek_giro.KeyDown
        keyshortenter(bt_simpansupplier, e)
    End Sub

    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(in_namasupplier, e)
    End Sub

    'Private Sub bt_gambar_Click(sender As Object, e As EventArgs) Handles bt_gambar.Click
    '    pic_supplier.Image = createQRString(in_kode.Text, 500)
    'End Sub

    'Private Sub pic_supplier_Click(sender As Object, e As EventArgs) Handles pic_supplier.Click
    '    If Not pic_supplier.Image Is Nothing Then
    '        Dim ss = decodeQR(pic_supplier.Image)
    '        MessageBox.Show(ss.Key & " " & ss.Value)
    '    End If
    'End Sub
End Class