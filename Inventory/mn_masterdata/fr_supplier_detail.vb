Public Class fr_supplier_detail
    Private supstatus As Integer = 1
    Private act As String = "INSERT"

    Private Sub loadDataSupplier(kode As String)
        readcommd("SELECT * FROM data_supplier_master WHERE supplier_kode='" & kode & "' ORDER BY supplier_version DESC LIMIT 1")
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
            supstatus = rd.Item("supplier_status")
            in_status_kode.Text = setStatus(supstatus)
        End If
        rd.Close()

        Dim q As String = "SELECT " _
                            & "reg.supplier_reg_date,reg.supplier_reg_alias, " _
                            & "upd.supplier_reg_date as supplier_upd_date, " _
                            & "upd.supplier_reg_alias as supplier_upd_alias " _
                          & "FROM (" _
                            & "SELECT supplier_kode, supplier_reg_date,supplier_reg_alias, supplier_version " _
                            & "FROM data_supplier_master WHERE supplier_kode='{0}' ORDER BY supplier_version ASC LIMIT 1 " _
                          & ") reg " _
                          & "LEFT JOIN (" _
                            & "SELECT supplier_kode, supplier_reg_date,supplier_reg_alias, supplier_version " _
                            & "FROM data_supplier_master WHERE supplier_kode='{0}' ORDER BY supplier_version DESC LIMIT 1 " _
                            & ") upd ON reg.supplier_kode=upd.supplier_kode"
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            txtRegdate.Text = rd.Item("supplier_reg_date")
            txtRegAlias.Text = rd.Item("supplier_reg_alias")
            txtUpdDate.Text = rd.Item("supplier_upd_date")
            txtUpdAlias.Text = rd.Item("supplier_upd_alias")
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
                x = "ERR"
        End Select
        Return x
    End Function

    Private Sub writeLogAct(kode As String)
        Dim ver, dataid As String
        Dim q As String = "SELECT CONCAT_WS('/',supplier_id,supplier_kode,supplier_version), supplier_version FROM data_supplier_master WHERE supplier_kode ='" & kode & "' ORDER BY supplier_version DESC LIMIT 1"

        readcommd(q)
        If rd.HasRows Then
            ver = rd.Item("supplier_version")
            dataid = rd.Item(0)
        Else
            ver = "-1"
            dataid = "err"
        End If
        rd.Close()

        If ver = "0" Then
            act = "INSERT"
        ElseIf CInt(ver) > 0 And supstatus <> 9 Then
            act = "UPDATE"
        ElseIf CInt(ver) < 0 Then
            act = "ERR"
        End If
        Console.Write(act & "-" & dataid)

        createLogAct(act, "data_supplier_master", dataid)
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

    '-------------- load
    Private Sub fr_supplier_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        op_con()
        in_status_kode.Text = setStatus(supstatus)

        If bt_simpansupplier.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadDataSupplier(.Text)
            End With
        End If

        in_namasupplier.Focus()
    End Sub

    '-------------- save
    Private Sub bt_simpansupplier_Click(sender As Object, e As EventArgs) Handles bt_simpansupplier.Click
        Dim data As String()
        Dim querycheck As Boolean = False
        Dim query As String = "INSERT INTO data_supplier_master(supplier_kode, supplier_nama, supplier_alamat, supplier_telpon1, supplier_telpon2, supplier_fax, supplier_cp, supplier_email, supplier_npwp, supplier_rek_bg, supplier_rek_bank, supplier_term, supplier_keterangan, supplier_status, supplier_reg_date, supplier_reg_alias, supplier_version) SELECT {0}, MAX(supplier_version)+1 FROM data_supplier_master WHERE supplier_kode={1}"

        If in_namasupplier.Text = Nothing Then
            MessageBox.Show("Nama supplier belum di input")
            in_namasupplier.Focus()
            Exit Sub
        End If

        'DONE : TODO : (?) : GENERATE KODE SUPPLIER -> PREVENT DUPLICATE AND ACCIDENTALY OVERWRITE EXISTING DATA
        'TODO : (?) : ADD REFFERRAL CODE INPUT
        If MessageBox.Show("Simpan Data Supplier?", "Data Supplier", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'WITH DATA-VERSION-ING  & USER ACT LOG
            If Trim(in_kode.Text) = Nothing Then
                Dim x As Integer = 0
                readcommd("SELECT SUBSTR(supplier_kode,3,5) FROM data_supplier_master GROUP BY supplier_kode ORDER BY supplier_kode DESC LIMIT 1")
                If rd.HasRows Then
                    x = CInt(rd.Item(0)) + 1
                Else
                    x = 1
                End If
                rd.Close()
                in_kode.Text = "SP" & x.ToString("D5")
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
                "'" & supstatus & "'",
                "NOW()",
                "'" & loggeduser.user_id & "'"
                }

            op_con()
            Dim q As String = String.Format(query, String.Join(",", data), "'" & in_kode.Text & "'")
            Console.WriteLine(q)
            querycheck = commnd(q)
        
            If querycheck = False Then
                Exit Sub
            Else
                'TODO : WRITE LOG
                writeLogAct(in_kode.Text)
                MessageBox.Show("Data tersimpan", "Data SUpplier")
                frmsupplier.in_cari.Clear()
                populateDGVUserCon("supplier", "", frmsupplier.dgv_list)
                Me.Close()
            End If
        End If
    End Sub

    '------------------ menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpansupplier.PerformClick()
    End Sub

    Private Sub mn_status_switch_Click(sender As Object, e As EventArgs) Handles mn_status_switch.Click
        Select Case supstatus
            Case 1
                supstatus = 2
            Case 2
                supstatus = 1
            Case 9
                supstatus = 1
                act = "UPDATE"
            Case Else
                Exit Sub
        End Select
        in_status_kode.Text = setStatus(supstatus)
    End Sub

    Private Sub mn_status_del_Click(sender As Object, e As EventArgs) Handles mn_status_del.Click
        If MessageBox.Show("Hapus Data Supplier?", "Data Supplier", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            supstatus = 9
            in_status_kode.Text = setStatus(supstatus)
            act = "DELETE"
        End If
    End Sub

    '---------------- numeric
    Private Sub in_term_Enter(sender As Object, e As EventArgs) Handles in_term.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_term_Leave(sender As Object, e As EventArgs) Handles in_term.Leave
        numericLostFocus(sender)
    End Sub

    '---------------- cb prevent input
    Private Sub cb_status_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    '--------------- textbox numeric
    Private Sub in_npwpsupplier_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_telp2supplier.KeyPress, in_telp1supplier.KeyPress, in_rek_giro.KeyPress, in_rek_bank.KeyPress, in_npwpsupplier.KeyPress, in_faxsupplier.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
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
End Class