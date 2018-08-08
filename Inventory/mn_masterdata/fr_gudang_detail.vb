Public Class fr_gudang_detail
    Private gdstatus As Integer = 1
    Private act As String = "INSERT"

    Private Sub loadDataGudang(kode As String)
        readcommd("SELECT * FROM data_barang_gudang WHERE gudang_kode='" & kode & "' ORDER BY gudang_version DESC LIMIT 1")
        If rd.HasRows Then
            in_kode.Text = kode
            in_namagudang.Text = rd.Item("gudang_nama")
            in_alamatgudang.Text = rd.Item("gudang_alamat")
            gdstatus = rd.Item("gudang_status")
            in_status_kode.Text = setStatus(gdstatus)
        End If
        rd.Close()

        Dim q As String = "SELECT " _
                              & "reg.gudang_reg_date,reg.gudang_reg_alias, " _
                              & "upd.gudang_reg_date as gudang_upd_date, " _
                              & "upd.gudang_reg_alias as gudang_upd_alias " _
                          & "FROM (SELECT " _
                              & "gudang_kode, gudang_reg_date,gudang_reg_alias, gudang_version " _
                              & "FROM data_barang_gudang WHERE gudang_kode='{0}' ORDER BY gudang_version ASC LIMIT 1 " _
                          & ") reg LEFT JOIN (SELECT " _
                              & "gudang_kode, gudang_reg_date,gudang_reg_alias, gudang_version " _
                              & "FROM data_barang_gudang WHERE gudang_kode='{0}' ORDER BY gudang_version DESC LIMIT 1 " _
                          & ") upd ON reg.gudang_kode=upd.gudang_kode"
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            txtRegdate.Text = rd.Item("gudang_reg_date")
            txtRegAlias.Text = rd.Item("gudang_reg_alias")
            txtUpdDate.Text = rd.Item("gudang_upd_date")
            txtUpdAlias.Text = rd.Item("gudang_upd_alias")
        End If
        rd.Close()
        'dgv_inv.DataSource = getDataTablefromDB("SELECT barang_nama, stock_sisa FROM data_barang_stok INNER JOIN data_barang_master ON barang_kode=stock_barang WHERE stock_gudang='" & kode & "'")
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
        Dim q As String = "SELECT CONCAT_WS('/',gudang_id,gudang_kode,gudang_version), gudang_version FROM data_barang_gudang WHERE gudang_kode ='" & kode & "' ORDER BY gudang_version DESC LIMIT 1"

        readcommd(q)
        If rd.HasRows Then
            ver = rd.Item("gudang_version")
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

        createLogAct(act, "data_barang_gudang", dataid)
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

    '----------------close
    Private Sub bt_batalbeli_Click(sender As Object, e As EventArgs) Handles bt_batalgudang.Click
        If MessageBox.Show("Tutup Form?", "Data Master Gudang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalgudang.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '------------------load
    Private Sub fr_gudang_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        op_con()

        in_status_kode.Text = setStatus(gdstatus)

        If bt_simpangudang.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadDataGudang(.Text)
            End With
        End If

        in_namagudang.Focus()
    End Sub

    Private Sub bt_simpangudang_Click(sender As Object, e As EventArgs) Handles bt_simpangudang.Click
        Dim data As String()
        Dim querycheck As Boolean = False
        Dim query As String = "INSERT INTO data_barang_gudang(gudang_kode, gudang_nama, gudang_alamat, gudang_status, gudang_reg_date, gudang_reg_alias, gudang_version) SELECT {0},MAX(gudang_version)+1 FROM data_barang_gudang WHERE gudang_kode={1}"

        'DONE : TODO : (?) : GENERATE KODE GUDANG -> PREVENT DUPLICATE AND ACCIDENTALY OVERWRITE EXISTING DATA
        'TODO : (?) : ADD REFFERRAL CODE INPUT
        If in_namagudang.Text = Nothing Then
            MessageBox.Show("Nama gudang belum di input")
            in_namagudang.Focus()
            Exit Sub
        End If
        If in_alamatgudang.Text = Nothing Then
            MessageBox.Show("Alamat gudang belum di input")
            in_alamatgudang.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan Data Gudang?", "Data Gudang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'WITH DATA-VERSION-ING  & USER ACT LOG
            If Trim(in_kode.Text) = Nothing Then
                Dim x As Integer = 0
                readcommd("SELECT SUBSTR(gudang_kode,3,3) FROM data_barang_gudang GROUP BY gudang_kode ORDER BY gudang_kode DESC LIMIT 1")
                If rd.HasRows Then
                    x = CInt(rd.Item(0)) + 1
                Else
                    x = 1
                End If
                rd.Close()
                in_kode.Text = "GD" & x.ToString("D3")
            End If

            data = {
                "'" & in_kode.Text & "'",
                "'" & in_namagudang.Text & "'",
                "'" & in_alamatgudang.Text & "'",
                "'" & gdstatus & "'",
                "NOW()",
                "'" & loggeduser.user_id & "'"
                }
            Dim q As String = String.Format(query, String.Join(",", data), "'" & in_kode.Text & "'")
            Console.WriteLine(q)
            querycheck = commnd(q)

            If querycheck = False Then
                Exit Sub
            Else
                'TODO : WRITE LOG
                writeLogAct(in_kode.Text)
                MessageBox.Show("Data Tersimpan", "Data Gudang")
                frmgudang.in_cari.Clear()
                populateDGVUserCon("gudang", "", frmgudang.dgv_list)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(in_namagudang, e)
    End Sub

    Private Sub in_namagudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(in_alamatgudang, e)
    End Sub

    '----------------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpangudang.PerformClick()
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
        If MessageBox.Show("Hapus Data Gudang?", "Data Gudang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            gdstatus = 9
            in_status_kode.Text = setStatus(gdstatus)
            act = "DELETE"
        End If
    End Sub

End Class