Public Class fr_exportaddfaktur
    Public ReturnValue As Boolean = False

    Private IdExport As String = ""
    Private _SupplierBased As Boolean = False
    Private _SupplierCode As String = ""

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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_cancel.Click
        'If MessageBox.Show("Tutup Form?", "Penjualan", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        ReturnValue = False
        Me.Close()
        'End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_cancel.PerformClick()
    End Sub

    Private Sub fr_jual_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_cancel.PerformClick()
        End If
    End Sub

    'LOAD FORM
    Public Sub DoLoadDialog(IdExport As String)
        Me.IdExport = IdExport
        If String.IsNullOrWhiteSpace(Me.IdExport) Then
            'SHOW ERROR MSG
            Exit Sub
        End If

        For Each x As DataGridViewColumn In {add_tglfaktur, view_tanggal}
            x.DefaultCellStyle = dgvstyle_date
        Next
        lbl_list_countfaktur.Text = String.Empty
        Me.ShowDialog(main)
    End Sub

    Public Sub DoLoadDialog(IdExport As String, SupplierKode As String)
        _SupplierBased = True
        _SupplierCode = SupplierKode
        If String.IsNullOrWhiteSpace(_SupplierCode) Then
            'SHOW ERROR MSG
            Exit Sub
        End If
        DoLoadDialog(IdExport)
    End Sub

    'ADD FAKTUR TO EXPORT TEMPLATE
    Private Sub ProcAddFaktur()
        Dim Result As Boolean = False
        Dim FaktCount As Integer = 0
        If ck_list.Checked Then
            If dgv_listfak.RowCount = 0 Then
                MessageBox.Show("Pilih faktur yg akan ditambahkan terlebih dahulu", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim dt As New DataTable
            dt.Columns.Add("kodefaktur", GetType(String))
            For Each row As DataGridViewRow In dgv_listfak.Rows
                dt.Rows.Add(row.Cells(0).Value)
            Next

            Result = AddFaktur(Me.IdExport, dt, FaktCount)

        ElseIf ck_range.Checked Then
            Result = AddFaktur(Me.IdExport, date_tglawal.Value, date_tglakhir.Value, FaktCount)
        Else
            MessageBox.Show("Tidak ada yg terpilih", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Result Then
            consoleWriteLine(FaktCount)
            MessageBox.Show(FaktCount & " faktur berhasil ditambahkan.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ReturnValue = True : DoRefreshTab_v2({pgexportEFak}) : Me.Close()
        End If
    End Sub

    Private Function AddFaktur(IdExport As String, DataTableInput As DataTable, Optional ByRef RowAffected As Integer = 0) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim _retVal As Boolean = False
        Dim q As String = ""

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Dim i As Integer = 0
                For Each row As DataRow In DataTableInput.Rows
                    If _SupplierBased Then
                        q = "SELECT EFak_AddNewFaktur_BySupplier({0}, '{1}', '{2}', '{3}')"
                        i += x.ExecScalar(String.Format(q, IdExport, row.ItemArray(0), _SupplierCode, loggeduser.user_id))
                    Else
                        q = "SELECT EFak_AddNewFaktur({0}, '{1}', '{2}')"
                        i += x.ExecScalar(String.Format(q, IdExport, row.ItemArray(0), loggeduser.user_id))
                    End If
                    consoleWriteLine(i)
                Next
                RowAffected = i
                If RowAffected = 0 Then
                    _retVal = False : MessageBox.Show("Tidak ada faktur ditambahkan.", "Export Efaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    _retVal = True
                End If
            Else
                _retVal = False : MessageBox.Show("Tidak dapat terhubung ke server.", "Export Efaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Message
            End If
        End Using

        Return _retVal
    End Function

    Private Function AddFaktur(IdExport As String, StartDate As Date, EndDate As Date, Optional ByRef RowAffected As Integer = 0) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim _retVal As Boolean = False
        Dim q As String = ""

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                If _SupplierBased Then
                    q = "SELECT EFak_AddNewFakturByDate_BySupplier({0}, '{1:yyyy-MM-dd}', '{2:yyyy-MM-dd}', '{3}', '{4}')"
                    RowAffected = x.ExecScalar(String.Format(q, IdExport, StartDate, EndDate, _SupplierCode, loggeduser.user_id))
                Else
                    q = "SELECT EFak_AddNewFakturByDate({0}, '{1:yyyy-MM-dd}', '{2:yyyy-MM-dd}', '{3}')"
                    RowAffected = x.ExecScalar(String.Format(q, IdExport, StartDate, EndDate, loggeduser.user_id))
                End If
                If RowAffected = 0 Then
                    _retVal = False : MessageBox.Show("Tidak ada faktur yang ditambahkan.", "Export Efaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    _retVal = True
                End If
            Else
                _retVal = False : MessageBox.Show("Tidak dapat terhubung ke server.", "Export Efaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using

        Return _retVal
    End Function

    'SEARCH/ADD FAKTUR
    Private Sub loadSearchFaktur(searchDate As Date, searchParam As String)
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _q As String = ""
                Dim _qWhrArr() As String = {"faktur_kode REGEXP '{0}'", "getMasterNama('custo', faktur_customer) REGEXP '{0}'",
                                            "faktur_customer REGEXP '{0}'"}
                Dim _qWhr As String = ""
                Dim _qOrder As String = ""
                If Not String.IsNullOrWhiteSpace(searchParam) Then
                    searchParam = mysqlQueryFriendlyStringFeed(Trim(searchParam)).Replace(" ", ".+").Replace("(", "[(]").Replace(")", "[)]")
                    _qWhr = String.Format(" AND (" & String.Join(" OR ", _qWhrArr) & ")", searchParam)
                End If

                If _SupplierBased Then
                    _q = "SELECT faktur_kode, faktur_tanggal_trans, getMasterNama('custo', faktur_customer) faktur_custo, faktur_pajak_no " _
                        & "FROM data_penjualan_faktur " _
                        & "LEFT JOIN data_penjualan_trans ON faktur_kode=trans_faktur AND trans_status=1 " _
                        & "LEFT JOIN data_barang_master ON trans_barang=barang_kode " _
                        & "WHERE faktur_tanggal_trans='{0:yyyy-MM-dd}' AND barang_supplier='{1}'"
                    _q = " GROUP BY faktur_kode ORDER BY faktur_kode"
                Else
                    _q = "SELECT faktur_kode, faktur_tanggal_trans, getMasterNama('custo', faktur_customer) faktur_custo, faktur_pajak_no " _
                        & "FROM data_penjualan_faktur " _
                        & "WHERE faktur_tanggal_trans='{0:yyyy-MM-dd}' AND faktur_ppn_jenis IN(1,2)"
                    _qOrder = " ORDER BY faktur_kode ASC"
                End If
                If dgv_listfak.RowCount > 0 Then
                    Dim _selectFk As New List(Of String)
                    For Each rows As DataGridViewRow In dgv_listfak.Rows
                        Dim _date As Date = CDate(rows.Cells(1).Value)
                        If _date = searchDate Then _selectFk.Add(String.Format("'{0}'", rows.Cells(0).Value))
                    Next
                    If _selectFk.Count > 0 Then _qWhr += String.Format(" AND faktur_kode NOT IN({0})", String.Join(",", _selectFk))
                End If
                Using dtx = x.GetDataTable(String.Format(_q, searchDate, _SupplierCode) + _qWhr + _qOrder)
                    setDoubleBuffered(dgv_cari, True)
                    dgv_cari.AutoGenerateColumns = False
                    dgv_cari.DataSource = dtx
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Sub AddFaktur()
        Me.Cursor = Cursors.WaitCursor
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _q As String = ""
                Dim _ck As Boolean = False
                Dim _fakExist As Boolean = False
                dgv_listfak.ClearSelection()
                For Each rows As DataGridViewRow In dgv_cari.SelectedRows
                    Dim f As Integer = 0
                    Dim _kode As String = rows.Cells(0).Value
                    For Each frows As DataGridViewRow In dgv_listfak.Rows
                        If frows.Cells(0).Value = _kode Then GoTo NextCode
                    Next

                    _q = "SELECT COUNT(e_list_kodefaktur) FROM data_penjualan_efak_list WHERE e_list_templateid='{0}' AND e_list_kodefaktur='{1}'"
                    _ck = Integer.TryParse(x.ExecScalar(String.Format(_q, IdExport, _kode)), f)
                    If _ck And f = 0 Then
                        GoTo AddFaktur
                    ElseIf _ck And f > 0 Then
                        _q = "SELECT e_list_status FROM data_penjualan_efak_list WHERE e_list_templateid='{0}' AND e_list_kodefaktur='{1}'"
                        _ck = Integer.TryParse(x.ExecScalar(String.Format(_q, IdExport, _kode)), f)
                        If _ck And f = 1 Then : _fakExist = True : GoTo NextCode : End If
                    Else
                        GoTo NextCode
                    End If
AddFaktur:
                    With dgv_listfak
                        Dim i = .Rows.Add
                        For y = 0 To 2
                            .Rows(i).Cells(y).Value = rows.Cells(y).Value
                        Next
                        dgv_listfak.Rows(i).Selected = True
                    End With

NextCode:
                Next
                If _fakExist Then MessageBox.Show("Beberapa faktur sudah ada di template export.", "Tambah Faktur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dgv_cari.ClearSelection()
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Tambah Faktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    'UI : BUTTON
    Private Sub bt_list_addfak_Click(sender As Object, e As EventArgs) Handles bt_list_addfak.Click
        If dgv_cari.RowCount > 0 And dgv_cari.SelectedRows.Count > 0 Then
            AddFaktur()
        End If
    End Sub

    Private Sub bt_list_delfak_Click(sender As Object, e As EventArgs) Handles bt_list_delfak.Click
        If dgv_listfak.RowCount > 0 And dgv_listfak.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In dgv_listfak.SelectedRows
                dgv_listfak.Rows.RemoveAt(row.Index)
            Next
            dgv_listfak.ClearSelection()
        End If
    End Sub

    Private Sub bt_load_Click(sender As Object, e As EventArgs) Handles bt_load.Click
        If ck_list.Checked = False And ck_range.Checked = False Then
            MessageBox.Show("Tidak ada faktur terpilih.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        ProcAddFaktur()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_cari_Click(sender As Object, e As EventArgs) Handles bt_cari.Click
        Me.Cursor = Cursors.WaitCursor
        loadSearchFaktur(date_cari.Value, in_cari.Text)
        Me.Cursor = Cursors.Default
    End Sub

    'UI : CHECKBOX
    Private Sub ck_list_CheckedChanged(sender As Object, e As EventArgs) Handles ck_list.CheckedChanged
        Dim _ck As Boolean = ck_list.Checked
        ck_range.Checked = Not ck_list.Checked
        For Each x As Control In {dgv_listfak, bt_list_addfak, bt_list_delfak, date_cari, in_cari, bt_cari, dgv_cari}
            x.Enabled = _ck
        Next
    End Sub

    Private Sub ck_range_CheckedChanged(sender As Object, e As EventArgs) Handles ck_range.CheckedChanged
        Dim _ck As Boolean = ck_range.Checked
        ck_list.Checked = Not _ck
        For Each x As Control In {date_tglawal, date_tglakhir}
            x.Enabled = _ck
        Next
    End Sub

    'UI : DGV
    Private Sub dgv_listfak_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgv_listfak.RowsAdded
        lbl_list_countfaktur.Text = dgv_listfak.RowCount & " Faktur"
    End Sub

    Private Sub dgv_listfak_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv_listfak.RowsRemoved
        lbl_list_countfaktur.Text = dgv_listfak.RowCount & " Faktur"
    End Sub

    Private Sub dgv_cari_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_cari.CellDoubleClick
        bt_list_addfak.PerformClick()
    End Sub

    Private Sub dgv_listfak_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listfak.CellDoubleClick
        bt_list_delfak.PerformClick()
    End Sub

    'UI : OTHER
    Private Sub in_cari_KeyUp(sender As Object, e As KeyEventArgs) Handles in_cari.KeyUp
        If e.KeyCode = Keys.Enter Then
            bt_cari.PerformClick()
        End If
    End Sub

    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub date_cari_KeyUp(sender As Object, e As KeyEventArgs) Handles date_cari.KeyUp
        keyshortenter(in_cari, e)
    End Sub
End Class