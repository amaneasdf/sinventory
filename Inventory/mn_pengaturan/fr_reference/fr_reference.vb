Public Class fr_reference
    Private selecteditem As String
    Private selectSatState As String

    Private Sub loadDgv(jenis As String)
        Dim q As String = ""
        Dim dgv As DataGridView
        Dim dt As New DataTable

        Select Case jenis
            Case "custokab"
                q = "SELECT ref_kab_id,ref_kab_nama FROM ref_area_kabupaten WHERE ref_kab_status<>9"
                dgv = dgv_kab

            Case "custoarea"
                q = "SELECT c_area_id as 'ID', c_area_nama as 'Nama Area', ref_kab_nama as 'Kabupaten' " _
                    & "FROM data_customer_area LEFT JOIN ref_area_kabupaten ON ref_kab_id=c_area_kode_kab AND ref_kab_status=1 " _
                    & "WHERE c_area_status=1"
                dgv = dgv_area

            Case "satbrg"
                q = "SELECT satuan_kode as 'Kode', satuan_nama as 'Nama Satuan', satuan_keterangan as 'Keterangan' " _
                    & "FROM ref_satuan WHERE satuan_status=1"
                dgv = dgv_sat

            Case Else
                Exit Sub
        End Select

        dt = getDataTablefromDB(q)

        dgv.DataSource = dt

    End Sub

    Private Sub DgvToTxt(jenis As String)
        Select Case jenis
            Case "custoarea"

            Case "satbrg"
                With dgv_sat.SelectedRows
                    in_sat_id.Text = .Item(0).Cells(0).Value
                    in_sat_nm.Text = .Item(0).Cells(1).Value
                    in_sat_ket.Text = .Item(0).Cells(2).Value

                    in_sat_id.ReadOnly = True
                End With
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Function saveData(jenis As String) As Boolean
        Dim q As String = ""
        Dim data As String()
        Dim queryChk As Boolean = False
        Dim _title As String = ""

        Select Case jenis
            Case "custokab"
                q = "INSERT INTO ref_area_kabupaten SET ref_kab_id='{0}',{1},ref_kab_reg_date=NOW(),ref_kab_reg_alias='{2}' " _
                    & "ON DUPLICATE KEY UPDATE {1},ref_kab_upd_date=NOW(),ref_kab_upd_alias='{2}'"
                data = {
                    "ref_kab_nama='" & in_kab_n.Text & "'",
                    "ref_kab_status='1'"
                    }
            Case "custoarea"
                q = "INSERT INTO data_customer_area SET c_area_id='{0}',{1},c_area_reg_date=NOW(),c_area_reg_alias='{2}' " _
                    & "ON DUPLICATE KEY UPDATE {1},c_area_upd_date=NOW(),c_area_upd_alias='{2}'"
                data = {
                    "c_area_nama='" & in_area_n.Text & "'",
                    "c_area_kode_kab='" & cb_area_kab.SelectedValue & "'",
                    "c_area_status='1'"
                    }
            Case "satbrg"
                q = "INSERT INTO ref_satuan SET satuan_kode='{0}',{1},satuan_reg_date=NOW(),satuan_reg_alias='{2}' " _
                    & "ON DUPLICATE KEY UPDATE {1},satuan_upd_date=NOW(),satuan_upd_alias='{2}'"
                data = {
                    "satuan_nama='" & in_sat_nm.Text & "'",
                    "satuan_keterangan='" & in_sat_ket.Text & "'",
                    "satuan_status='1'"
                    }
                q = String.Format(q, in_sat_id.Text, String.Join(",", data), loggeduser.user_id)
            Case Else
                Return False
                Exit Function
        End Select

        queryChk = commnd(q)
        If queryChk Then
            MessageBox.Show("Data tersimpan", _title, MessageBoxButtons.OK)
        Else
            MessageBox.Show("Data tidak dapat disimpan", _title, MessageBoxButtons.OK)
        End If
        Return queryChk
    End Function

    Private Function actDeactData(jenis As String, kode As String, newstate As Boolean) As Boolean
        Dim q As String = ""
        Dim ckdata As Boolean = True
        Dim _status As String = 1
        Dim retval As Boolean = False

        If newstate = False Then
            _status = 0
        End If

        Select Case jenis
            Case "custokab"
                ckdata = checkdata("data_customer_area", "' AND c_area_status<>9", "c_area_kodekab")
                q = "UPDATE ref_area_kabupaten SET ref_kab_status='{1}',ref_kab_upd_date=NOW(), ref_kab_upd_alias='{2}' " _
                    & "WHERE ref_kab_id='{0}'"

            Case "custoarea"
                ckdata = checkdata("data_customer_master", " AND customer_status<>9", "customer_area")
                q = "UPDATE data_customer_area SET c_area_status='{1}',c_area_upd_date=NOW(),c_area_upd_alias='{2}' " _
                    & "WHERE c_area_id='{0}'"
            Case "satbrg"
                ckdata = checkdata("data_barang_satuan", "' AND b_satuan_status<>9", "b_satuan_barang")
                q = "UPDATE ref_satuan SET satuan_status='{1}', satuan_upd_date=NOW(), satuan_upd_alias='{2}' " _
                    & "WHERE satuan_kode='{0}'"
                q = String.Format(q, _status, kode, loggeduser.user_id)
            Case Else
                Return False
                Exit Function
        End Select

        retval = commnd(q)

        Return retval
    End Function

    Private Sub delData(jenis As String, kode As String)
        actDeactData(jenis, kode, "9")
    End Sub

    Private Sub resetForm(jenis As String)
        Select Case jenis
            Case "satbrg"
                in_sat_id.ReadOnly = False
                selectSatState = 1
                For Each txt As TextBox In {in_sat_id, in_sat_ket, in_sat_nm}
                    txt.Clear()
                Next
        End Select
        loadDgv(jenis)
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_simpanbeli.PerformClick()
    End Sub

    'REF SATUAN =============================================================================================================================================
    Private Sub bt_save_sat_Click(sender As Object, e As EventArgs) Handles bt_save_sat.Click, bt_save_area.Click
        Dim _sndername As String = sender.Name.ToString
        Dim retval As Boolean = False
        Select Case _sndername
            Case "bt_save_sat"
                If Trim(in_sat_id.Text) = "" Then
                    MessageBox.Show("Kode belum diinput")
                ElseIf Trim(in_sat_nm.Text) = "" Then
                    MessageBox.Show("Nama belum diinput")
                Else
                    retval = saveData("satbrg")
                    If retval = True Then
                        resetForm("satbrg")
                    End If
                End If
            Case "bt_save_area"

        End Select
    End Sub

    Private Sub dgv_sat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_sat.CellClick
        If dgv_sat.RowCount > 0 Then
            DgvToTxt("satbrg")
        End If
    End Sub

    Private Sub fr_reference_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadDgv("satbrg")
    End Sub

    Private Sub lk_sat_refresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lk_sat_refresh.LinkClicked
        resetForm("satbrg")
    End Sub

    Private Sub bt_deact_sat_Click(sender As Object, e As EventArgs) Handles bt_deact_sat.Click
        Dim _sndername As String = sender.Name.ToString
        Dim retval As Boolean = False
        Select Case _sndername
            Case "bt_deact_sat"
                If in_sat_id.Text <> Nothing Then
                    retval = actDeactData("satbrg", in_sat_id.Text, IIf(selectSatState = 1, False, True))
                    If retval = True Then
                        resetForm("satbrg")
                    End If
                Else

                End If

        End Select
    End Sub
End Class