Public Class fr_data_referensi
    Public tabpagename As TabPage

    Private SearchString As String = ""
    Private SetRefData As String = ""

    'KEYSHORTCUT
    Protected Overrides Function ProcessKeyPreview(ByRef m As Message) As Boolean
        If m.Msg = &H100 Or m.Msg = &H101 Then  'WM_KEYDOWN / WM_KEYUP
            Dim key As Keys = m.WParam
            If key = Keys.F5 Then
                PerformRefresh() : Return True
            ElseIf key = Keys.F And My.Computer.Keyboard.CtrlKeyDown Then
                in_cari.Focus() : Return True
            ElseIf key = Keys.O And My.Computer.Keyboard.CtrlKeyDown Then
                If dgv_list.SelectedRows.Count > 0 Then
                    EditData() : Return True
                End If
            End If
        End If

        Return MyBase.ProcessKeyPreview(m)
    End Function

    Public Sub SetPage(page As TabPage)
        tabpagename = page
        MenuSw()
        SetDataGrid() : LoadDataGrid("")
    End Sub

    Private Sub MenuSw()
        Dim _enable As Boolean = loggeduser.admin_pc
        mn_add.Enabled = _enable
        mn_edit.Enabled = _enable

    End Sub

    Public Sub PerformRefresh()
        Me.Cursor = Cursors.WaitCursor
        in_cari.Clear() : SearchString = ""
        SetDataGrid() : LoadDataGrid(SearchString)
        If String.IsNullOrWhiteSpace(SetRefData) Then
            For Each btn As Button In {bt_ref_katbrg, bt_ref_satbrg, bt_ref_areacusto, bt_ref_kab, bt_ref_jeniscusto}
                btn.BackColor = Color.White : btn.ForeColor = Color.Black
            Next
        End If
        Me.Cursor = Cursors.Default
    End Sub

    'SET DATAGRID
    Private Sub SetDataGrid()
        Dim x_filler = New DataGridViewColumn
        Dim x As DataGridViewColumn()
        x_filler = dgvcol_templ_id.Clone()
        x_filler.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        dgv_list.Columns.Clear()
        dgv_list.AutoGenerateColumns = False
        setDoubleBuffered(dgv_list, True)

        Dim ref_kode = New DataGridViewColumn : ref_kode = dgvcol_templ_status.Clone() : ref_kode.Name = "ref_kode"
        Dim ref_nama = New DataGridViewColumn : ref_nama = dgvcol_templ_status.Clone() : ref_nama.Name = "ref_nama"
        Dim ref_ket = New DataGridViewColumn : ref_ket = dgvcol_templ_status.Clone() : ref_ket.Name = "ref_ket"
        Dim ref_status = New DataGridViewColumn : ref_status = dgvcol_templ_status.Clone() : ref_status.Name = "ref_status"

        Select Case SetRefData
            Case "kategoribarang"
                ref_kode.HeaderText = "Kode" : ref_kode.DataPropertyName = "ref_kode"
                ref_nama.HeaderText = "Nama Kategori" : ref_nama.DataPropertyName = "ref_nama"
                ref_ket.HeaderText = "Keterangan" : ref_ket.DataPropertyName = "ref_ket"
                ref_status.HeaderText = "Status" : ref_status.DataPropertyName = "ref_status"

                ref_ket.Width = 350 : ref_nama.Width = 120

                x = {ref_kode, ref_nama, ref_ket, ref_status, x_filler}

            Case "satuanbarang"
                ref_kode.HeaderText = "Kode" : ref_kode.DataPropertyName = "ref_kode"
                ref_nama.HeaderText = "Nama Statuan" : ref_nama.DataPropertyName = "ref_nama"
                ref_ket.HeaderText = "Keterangan" : ref_ket.DataPropertyName = "ref_ket"
                ref_status.HeaderText = "Status" : ref_status.DataPropertyName = "ref_status"

                ref_ket.Width = 350 : ref_nama.Width = 120

                x = {ref_kode, ref_nama, ref_ket, ref_status, x_filler}

            Case "areacusto"
                Dim ref_kab = New DataGridViewColumn : ref_kab = dgvcol_templ_status.Clone()
                ref_kode.HeaderText = "Kode" : ref_kode.DataPropertyName = "ref_kode"
                ref_nama.HeaderText = "Kecamatan/Area" : ref_nama.DataPropertyName = "ref_nama"
                ref_ket.HeaderText = "Keterangan" : ref_ket.DataPropertyName = "ref_ket"
                ref_status.HeaderText = "Status" : ref_status.DataPropertyName = "ref_status"
                ref_kab.Name = "ref_kab" : ref_kab.HeaderText = "Kabupaten" : ref_kab.DataPropertyName = "ref_kab"

                ref_ket.Width = 350 : ref_nama.Width = 200 : ref_kab.Width = ref_nama.Width

                x = {ref_kode, ref_nama, ref_kab, ref_ket, ref_status, x_filler}

            Case "kabupaten"
                ref_kode.HeaderText = "Kode" : ref_kode.DataPropertyName = "ref_kode"
                ref_nama.HeaderText = "Kabupaten" : ref_nama.DataPropertyName = "ref_nama"
                ref_ket.HeaderText = "Keterangan" : ref_ket.DataPropertyName = "ref_ket"
                ref_status.HeaderText = "Status" : ref_status.DataPropertyName = "ref_status"

                ref_ket.Width = 350 : ref_nama.Width = 200

                x = {ref_kode, ref_nama, ref_ket, ref_status, x_filler}

            Case "jeniscusto"
                Dim ref_jual = New DataGridViewColumn : ref_jual = dgvcol_templ_status.Clone()
                ref_kode.HeaderText = "Kode" : ref_kode.DataPropertyName = "ref_kode"
                ref_nama.HeaderText = "Jenis Customer" : ref_nama.DataPropertyName = "ref_nama"
                ref_ket.HeaderText = "Keterangan" : ref_ket.DataPropertyName = "ref_ket"
                ref_status.HeaderText = "Status" : ref_status.DataPropertyName = "ref_status"
                ref_jual.Name = "ref_jual" : ref_jual.HeaderText = "Jenis Hargajual" : ref_jual.DataPropertyName = "ref_jual"

                ref_ket.Width = 350 : ref_nama.Width = 200 : ref_jual.Width = ref_nama.Width

                x = {ref_kode, ref_nama, ref_jual, ref_ket, ref_status, x_filler}

            Case Else : Exit Sub
        End Select

        For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
        dgv_list.Columns.AddRange(x)
    End Sub

    Private Sub LoadDataGrid(ParamStr As String)
        If String.IsNullOrWhiteSpace(SetRefData) Then Exit Sub

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                SearchString = String.Empty
                dgv_list.DataSource = New DataTable
                Dim q = CreateQueryData(SetRefData, ParamStr)
                If Not String.IsNullOrWhiteSpace(q) Then
                    dgv_list.DataSource = x.GetDataTable(q)
                    If Not String.IsNullOrWhiteSpace(ParamStr) Then SearchString = ParamStr
                End If

            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.lbl_judul.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Function CreateQueryData(DataType As String, ParamStr As String) As String
        Dim q As String = ""
        Dim qwhr, qorder As String
        If Not String.IsNullOrWhiteSpace(ParamStr) Then
            ParamStr = mysqlQueryFriendlyStringFeed(ParamStr)
            ParamStr = Trim(ParamStr).Replace(" ", ".+").Replace("(", "[(]").Replace(")", "[)]")
        End If
        Select Case DataType
            Case "kategoribarang"
                q = "SELECT kategori_kode ref_kode, kategori_nama ref_nama, kategori_keterangan ref_ket, ref_text ref_status " _
                    & "FROM ref_barang_kategori " _
                    & "LEFT JOIN ref_jenis ON kategori_status=ref_kode AND ref_status=1 AND ref_type='status_master' " _
                    & "WHERE kategori_status<9 {0}"
                If Not String.IsNullOrWhiteSpace(ParamStr) Then
                    qwhr = String.Join("'" & ParamStr & "'", {" AND(kategori_kode REGEXP ", " OR kategori_nama REGEXP ", ")"})
                Else
                    qwhr = ""
                End If
                qorder = " ORDER BY kategori_kode"
                Return String.Format(q, qwhr + qorder)

            Case "satuanbarang"
                q = "SELECT satuan_kode ref_kode, satuan_nama ref_nama, satuan_keterangan ref_ket, ref_text ref_status " _
                    & "FROM ref_satuan " _
                    & "LEFT JOIN ref_jenis ON satuan_status=ref_kode AND ref_status=1 AND ref_type='status_master' " _
                    & "WHERE satuan_status<9 {0}"
                If Not String.IsNullOrWhiteSpace(ParamStr) Then
                    qwhr = String.Join("'" & ParamStr & "'", {" AND(satuan_kode REGEXP ", " OR satuan_nama REGEXP ", ")"})
                Else
                    qwhr = ""
                End If
                qorder = " ORDER BY satuan_kode"
                Return String.Format(q, qwhr + qorder)

            Case "areacusto"
                q = "SELECT c_area_id ref_kode, c_area_nama ref_nama, ref_kab_nama ref_kab, c_area_ket ref_ket, ref_text ref_status " _
                    & "FROM data_customer_area " _
                    & "LEFT JOIN ref_area_kabupaten ON ref_kab_id=c_area_kode_kab " _
                    & "LEFT JOIN ref_jenis ON c_area_status=ref_kode AND ref_status=1 AND ref_type='status_master' " _
                    & "WHERE c_area_status<9 {0}"
                If Not String.IsNullOrWhiteSpace(ParamStr) Then
                    qwhr = String.Join("'" & ParamStr & "'", {" AND(c_area_id REGEXP ", " OR c_area_nama REGEXP ", " OR ref_kab_nama REGEXP ", ")"})
                Else
                    qwhr = ""
                End If
                qorder = " ORDER BY c_area_id"
                Return String.Format(q, qwhr + qorder)

            Case "kabupaten"
                q = "SELECT ref_kab_id ref_kode, ref_kab_nama ref_nama, ref_kab_ket ref_ket, ref_text ref_status " _
                    & "FROM ref_area_kabupaten " _
                    & "LEFT JOIN ref_jenis ON ref_kab_status=ref_kode AND ref_status=1 AND ref_type='status_master' " _
                    & "WHERE ref_kab_status<9 {0}"
                If Not String.IsNullOrWhiteSpace(ParamStr) Then
                    qwhr = String.Join("'" & ParamStr & "'", {" AND(ref_kab_id REGEXP ", " OR ref_kab_nama REGEXP ", ")"})
                Else
                    qwhr = ""
                End If
                qorder = " ORDER BY ref_kab_id"
                Return String.Format(q, qwhr + qorder)

            Case "jeniscusto"
                q = "SELECT jenis_kode ref_kode, jenis_nama ref_nama, hargajual_nama ref_jual, jenis_keterangan ref_ket, ref_text ref_status " _
                    & "FROM data_customer_jenis " _
                    & "LEFT JOIN data_customer_hargajual ON jenis_def_jual=hargajual_kode " _
                    & "LEFT JOIN ref_jenis ON jenis_status=ref_kode AND ref_status=1 AND ref_type='status_master' " _
                    & "WHERE jenis_status<9 {0}"
                If Not String.IsNullOrWhiteSpace(ParamStr) Then
                    qwhr = String.Join("'" & ParamStr & "'", {" AND(jenis_kode REGEXP ", " OR jenis_nama REGEXP ", " OR hargajual_nama REGEXP ", ")"})
                Else
                    qwhr = ""
                End If
                qorder = " ORDER BY jenis_kode"
                Return String.Format(q, qwhr + qorder)

        End Select
        Return String.Empty
    End Function

    Private Sub AddData()
        If String.IsNullOrWhiteSpace(SetRefData) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Using x As New fr_ref_areacusto
            x.DoLoadNew(SetRefData, loggeduser.admin_pc)
            If x.DoRefresh Then PerformRefresh()
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub EditData()
        If String.IsNullOrWhiteSpace(SetRefData) Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim _kode As String = ""
        _kode = dgv_list.SelectedRows.Item(0).Cells(0).Value
        Using x As New fr_ref_areacusto
            x.DoLoadEdit(SetRefData, _kode, loggeduser.admin_pc)
            If x.DoRefresh Then PerformRefresh()
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    'UI : CLOSE
    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        SetRefData = String.Empty : PerformRefresh()
        main.tabcontrol.TabPages.Remove(tabpagename)
    End Sub

    'UI : MENU
    Private Sub mn_add_Click(sender As Object, e As EventArgs) Handles mn_add.Click
        AddData()
    End Sub

    Private Sub mn_edit_Click(sender As Object, e As EventArgs) Handles mn_edit.Click
        EditData()
    End Sub

    Private Sub mn_search_Click(sender As Object, e As EventArgs) Handles mn_search.Click
        in_cari.Focus()
    End Sub

    Private Sub mn_refresh_Click(sender As Object, e As EventArgs) Handles mn_refresh.Click
        PerformRefresh()
    End Sub

    'UI : BUTTON
    Private Sub bt_search_Click(sender As Object, e As EventArgs) Handles bt_search.Click
        Me.Cursor = Cursors.WaitCursor
        LoadDataGrid(in_cari.Text)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_ref_katbrg_Click(sender As Object, e As EventArgs) Handles bt_ref_katbrg.Click, bt_ref_satbrg.Click, bt_ref_areacusto.Click, bt_ref_kab.Click, bt_ref_jeniscusto.Click
        For Each btn As Button In {bt_ref_katbrg, bt_ref_satbrg, bt_ref_areacusto, bt_ref_kab, bt_ref_jeniscusto}
            If btn.Name = sender.Name Then
                btn.BackColor = Color.Tomato : btn.ForeColor = Color.White
            Else
                btn.BackColor = Color.White : btn.ForeColor = Color.Black
            End If
        Next

        Select Case sender.Name
            Case "bt_ref_katbrg" : SetRefData = "kategoribarang"
            Case "bt_ref_satbrg" : SetRefData = "satuanbarang"
            Case "bt_ref_areacusto" : SetRefData = "areacusto"
            Case "bt_ref_kab" : SetRefData = "kabupaten"
            Case "bt_ref_jeniscusto" : SetRefData = "jeniscusto"
            Case Else : SetRefData = String.Empty
        End Select
        PerformRefresh()
    End Sub

    'UI : INPUT
    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True : bt_search.PerformClick()
        End If
    End Sub

    'UI : DGV
    Private Sub dgv_list_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellDoubleClick
        If e.RowIndex >= 0 And Not String.IsNullOrWhiteSpace(SetRefData) Then EditData()
    End Sub

    Private Sub dgv_list_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_list.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgv_list.RowCount > 0 And Not String.IsNullOrWhiteSpace(SetRefData) Then EditData()
        End If
    End Sub
End Class