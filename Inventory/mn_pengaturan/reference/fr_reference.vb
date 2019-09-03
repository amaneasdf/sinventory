Public Class fr_reference
    Private selecteditem As String
    Private selectSatState As String
    Private selectAreaId As String
    Private selectAreaState As String
    Private selectKabState As String

    Private Sub loadDgv(type As String)
        Dim q As String = ""
        Dim dgv As DataGridView
        Dim dt As New DataTable

        Select Case type
            Case "custokab"
                q = "SELECT ref_kab_id as 'ID',ref_kab_nama 'Nama Kabupaten', ref_kab_status, " _
                    & "(CASE ref_kab_status " _
                    & " WHEN 1 THEN 'AKTIF' " _
                    & " WHEN 0 THEN 'NON-AKTIF' " _
                    & " ELSE 'ERROR' END) Status " _
                    & "FROM ref_area_kabupaten WHERE ref_kab_status<>9"
                dgv = dgv_kab

            Case "custoarea"
                q = "SELECT c_area_id as 'ID', c_area_nama as 'Nama Area', ref_kab_nama as 'Kabupaten',c_area_kode_kab,c_area_status, " _
                    & "(CASE c_area_status " _
                    & " WHEN 1 THEN 'AKTIF' " _
                    & " WHEN 0 THEN 'NON-AKTIF' " _
                    & " ELSE 'ERROR' END) Status " _
                    & "FROM data_customer_area LEFT JOIN ref_area_kabupaten ON ref_kab_id=c_area_kode_kab AND ref_kab_status=1 " _
                    & "WHERE c_area_status<>9"
                dgv = dgv_area
                With cb_area_kab
                    .DataSource = jenis("areacustokab")
                    .ValueMember = "Value"
                    .DisplayMember = "Text"
                End With

            Case "satbrg"
                q = "SELECT satuan_kode as 'Kode', satuan_nama as 'Nama Satuan', satuan_keterangan as 'Keterangan', satuan_status, " _
                    & "(CASE satuan_status " _
                    & " WHEN 1 THEN 'AKTIF' " _
                    & " WHEN 0 THEN 'NON-AKTIF' " _
                    & " ELSE 'ERROR' END) Status " _
                    & "FROM ref_satuan WHERE satuan_status<>9"
                dgv = dgv_sat

            Case Else
                Exit Sub
        End Select

        dt = getDataTablefromDB(q)

        setDoubleBuffered(dgv, True)
        dgv.DataSource = dt

        Select Case type
            Case "satbrg"
                dgv.Columns(2).Width = 150
                dgv.Columns(3).Visible = False
                dgv.Sort(dgv.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            Case "custoarea"
                dgv.Columns(1).Width = 150
                dgv.Columns(2).Width = 150
                dgv.Columns(3).Visible = False
                dgv.Columns(4).Visible = False
            Case "custokab"
                dgv.Columns(1).Width = 150
                dgv.Columns(2).Visible = False
        End Select

    End Sub

    Private Sub DgvToTxt(jenis As String)
        Select Case jenis
            Case "custoarea"
                With dgv_area.SelectedRows.Item(0)
                    in_area_id.Text = .Cells(0).Value
                    in_area_n.Text = .Cells(1).Value
                    cb_area_kab.SelectedValue = .Cells(3).Value
                    selectAreaState = .Cells(4).Value
                End With
            Case "custokab"
                With dgv_kab.SelectedRows.Item(0)
                    in_kab_id.Text = .Cells(0).Value
                    in_kab_n.Text = .Cells(1).Value
                    selectKabState = .Cells(2).Value
                End With
            Case "satbrg"
                With dgv_sat.SelectedRows
                    in_sat_id.Text = .Item(0).Cells(0).Value
                    in_sat_nm.Text = .Item(0).Cells(1).Value
                    in_sat_ket.Text = .Item(0).Cells(2).Value
                    selectSatState = .Item(0).Cells(3).Value

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
                q = "INSERT INTO data_customer_area SET c_area_id={0},{1},c_area_reg_date=NOW(),c_area_reg_alias='{2}' " _
                    & "ON DUPLICATE KEY UPDATE {1},c_area_upd_date=NOW(),c_area_upd_alias='{2}'"
                data = {
                    "c_area_nama='" & in_area_n.Text & "'",
                    "c_area_kode_kab='" & cb_area_kab.SelectedValue & "'",
                    "c_area_status='1'"
                    }
                q = String.Format(q, IIf(in_area_id.Text = "", "NULL", "'" & in_area_id.Text & "'"), String.Join(",", data), loggeduser.user_id)
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

    Private Function actDeactData(jenis As String, kode As String, newstate As String) As Boolean
        Dim q As String = ""
        Dim ckdata As Boolean = True
        Dim retval As Boolean = False

        Select Case jenis
            Case "custokab"
                If selectKabState = "1" Then
                    ckdata = checkdata("data_customer_area", "'" & kode & "' AND c_area_status<>9", "c_area_kode_kab")
                Else
                    ckdata = False
                End If
                q = "UPDATE ref_area_kabupaten SET ref_kab_status='{1}' WHERE ref_kab_id='{0}'"
                q = String.Format(q, in_kab_id.Text, newstate)

            Case "custoarea"
                If selectAreaState = "1" Then
                    ckdata = checkdata("data_customer_master", "'" & kode & "' AND customer_status<>9", "customer_area")
                Else
                    ckdata = False
                End If
                q = "UPDATE data_customer_area SET c_area_status='{1}',c_area_upd_date=NOW(),c_area_upd_alias='{2}' " _
                    & "WHERE c_area_id='{0}'"
                q = String.Format(q, kode, newstate, loggeduser.user_id)

            Case "satbrg"
                If selectSatState = "1" Then
                    ckdata = checkdata("data_barang_satuan", "'" & kode & "' AND b_satuan_status<>9", "b_satuan_barang")
                Else
                    ckdata = False
                End If
                q = "UPDATE ref_satuan SET satuan_status='{1}', satuan_upd_date=NOW(), satuan_upd_alias='{2}' " _
                                     & "WHERE satuan_kode='{0}'"
                q = String.Format(q, kode, newstate, loggeduser.user_id)
            Case Else
                Return False
                Exit Function
        End Select
        If ckdata = False Then
            retval = commnd(q)
        End If

        Return retval
    End Function

    Private Sub delData(jenis As String, kode As String)
        actDeactData(jenis, kode, "9")
    End Sub

    Private Sub resetForm(type As String)
        Select Case type
            Case "satbrg"
                in_sat_id.ReadOnly = False
                selectSatState = 1
                For Each txt As TextBox In {in_sat_id, in_sat_ket, in_sat_nm}
                    txt.Clear()
                Next
            Case "custoarea"
                selectAreaId = ""
                selectAreaState = 1
                For Each txt As TextBox In {in_area_id, in_area_n}
                    txt.Clear()
                Next
            Case "custokab"
                With cb_area_kab
                    .DataSource = jenis("areacustokab")
                    .ValueMember = "Value"
                    .DisplayMember = "Text"
                End With
                selectKabState = 1
                For Each txt As TextBox In {in_kab_id, in_kab_n}
                    txt.Clear()
                Next
        End Select
        loadDgv(type)
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

    Private Sub fr_reference_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadDgv("satbrg")
        loadDgv("custoarea")
        loadDgv("custokab")
    End Sub

    'REF SATUAN =============================================================================================================================================
    Private Sub bt_save_sat_Click(sender As Object, e As EventArgs) Handles bt_save_sat.Click, bt_save_area.Click, bt_save_kab.Click
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
                If Trim(in_area_n.Text) = Nothing Then
                    MessageBox.Show("Area belum diinput")
                ElseIf cb_area_kab.SelectedValue = Nothing Then
                    MessageBox.Show("Kabupaten belum diinput")
                Else
                    retval = saveData("custoarea")
                    If retval = True Then
                        resetForm("custoarea")
                    End If
                End If
            Case "bt_save_kab"
                If Trim(in_kab_n.Text) = Nothing Then
                    MessageBox.Show("Nama Kabupaten belum diinput")
                Else
                    retval = saveData("custokab")
                    If retval = True Then
                        resetForm("custokab")
                        With cb_area_kab
                            .DataSource = jenis("areacustokab")
                            .ValueMember = "Value"
                            .DisplayMember = "Text"
                        End With
                    End If
                End If
        End Select
    End Sub

    Private Sub dgv_sat_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_sat.CellClick, dgv_area.CellClick, dgv_kab.CellClick
        Dim _sndername As String = sender.Name.ToString
        If sender.RowCount > 0 And e.RowIndex >= 0 Then
            Select Case _sndername
                Case "dgv_sat"
                    DgvToTxt("satbrg")
                    in_sat_nm.Focus()
                Case "dgv_area"
                    DgvToTxt("custoarea")
                    in_area_n.Focus()
                Case "dgv_kab"
                    DgvToTxt("custokab")
                    in_kab_n.Focus()
            End Select
        End If
    End Sub

    Private Sub lk_sat_refresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lk_sat_refresh.LinkClicked, lk_area_refresh.LinkClicked, lk_kab_refresh.LinkClicked
        Dim _sndername As String = sender.Name.ToString
        Select Case _sndername
            Case "lk_sat_refresh"
                resetForm("satbrg")
                in_sat_nm.Focus()
            Case "lk_area_refresh"
                resetForm("custoarea")
                in_area_n.Focus()
            Case "lk_kab_refresh"
                resetForm("custokab")
                in_kab_n.Focus()
        End Select
    End Sub

    Private Sub bt_deact_sat_Click(sender As Object, e As EventArgs) Handles bt_deact_sat.Click, bt_deact_area.Click, bt_deact_kab.Click
        Dim _sndername As String = sender.Name.ToString
        Dim retval As Boolean = False
        Select Case _sndername
            Case "bt_deact_sat"
                If in_sat_id.Text <> Nothing Then
                    retval = actDeactData("satbrg", in_sat_id.Text, IIf(selectSatState = 1, 0, 1))
                    If retval = True Then
                        MessageBox.Show("Data tersimpan", "Ref. Satuan")
                        resetForm("satbrg")
                    End If
                Else

                End If
            Case "bt_deact_area"
                If in_area_id.Text <> Nothing Then
                    retval = actDeactData("custoarea", in_area_id.Text, IIf(selectAreaState = 1, 0, 1))
                    If retval Then
                        MessageBox.Show("Data tersimpan", "Ref. Area Customer")
                        resetForm("custoarea")
                    Else
                        MessageBox.Show("Data tidak dapat tersimpan", "Ref. Area Customer")
                    End If
                End If

            Case "bt_deact_kab"
                If in_kab_id.Text <> Nothing Then
                    retval = actDeactData("custokab", in_kab_id.Text, IIf(selectKabState = 1, 0, 1))
                    If retval Then
                        MessageBox.Show("Data tersimpan", "Ref. Kabupaten")
                        resetForm("custokab")
                    Else
                        MessageBox.Show("Data tidak dapat tersimpan", "Ref. Area Customer")
                    End If
                End If
        End Select
    End Sub

    Private Sub bt_del_sat_Click(sender As Object, e As EventArgs) Handles bt_del_sat.Click

    End Sub

    Private Sub bt_satbrg_Click(sender As Object, e As EventArgs) Handles bt_satbrg.Click, bt_kodearea.Click, bt_kabupaten.Click
        Dim _sndername As String = sender.Name.ToString
        Select Case _sndername
            Case "bt_satbrg"
                pnl_satbrg.Focus()
            Case "bt_kodearea"
                pnl_area.Focus()
            Case "bt_kabupaten"
                pnl_kab.Focus()
        End Select
    End Sub
End Class