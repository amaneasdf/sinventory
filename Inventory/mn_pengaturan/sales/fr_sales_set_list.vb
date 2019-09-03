Public Class fr_setsales_list
    Public tabpagename As TabPage

    Private MaxPageData As Integer = 1
    Private SelectedPageData As Integer = 1
    Private SearchString As String = ""

    Private _limit As Integer = LimitDataPerPage

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
                    EditData(dgv_list.SelectedRows.Item(0).Cells(0).Value) : Return True
                End If
            End If
        End If

        Return MyBase.ProcessKeyPreview(m)
    End Function

    'SETUP PAGE CONTROL
    Public Sub SetPage(page As TabPage)
        tabpagename = page
        MenuSw()
        SetDataGrid("sales_list")
        LoadDataGrid("", 1)
        SplitContainer1.SplitterDistance = SplitContainer1.Width * 0.5
    End Sub

    Private Sub MenuSw()
        Dim _EditText = IIf(loggeduser.allowedit_master, "Edit Data", "Tampilkan Data")
        mn_edit.Text = _EditText
    End Sub

    Private Sub SetDataGrid(DgvType As String)
        Dim x As DataGridViewColumn()

        Dim x_filler = New DataGridViewColumn
        x_filler = dgvcol_templ_id.Clone()
        x_filler.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Select Case LCase(DgvType)
            Case "sales_list"
                setDoubleBuffered(dgv_list, True)
                dgv_list.Columns.Clear()
                dgv_list.AutoGenerateColumns = False

                Dim list_sales = New DataGridViewColumn
                Dim list_sales_n = New DataGridViewColumn
                Dim list_jenis = New DataGridViewColumn
                Dim list_status = New DataGridViewColumn
                list_sales = dgvcol_templ_id.Clone()
                list_sales_n = dgvcol_templ_status.Clone()
                list_jenis = dgvcol_templ_status.Clone()
                list_status = dgvcol_templ_status.Clone()

                list_sales.Name = "list_sales" : list_sales.HeaderText = "Kode" : list_sales.DataPropertyName = "salesman_kode"
                list_sales_n.Name = "list_sales_n" : list_sales_n.HeaderText = "Nama Salesman" : list_sales_n.DataPropertyName = "salesman_nama"
                list_jenis.Name = "list_jenis" : list_jenis.HeaderText = "Jenis" : list_jenis.DataPropertyName = "salesman_jenis"
                list_status.Name = "list_status" : list_status.HeaderText = "Status" : list_status.DataPropertyName = "salesman_status"

                list_sales.Width = 100 : list_sales_n.Width = 200
                x = {list_sales, list_sales_n, list_jenis, list_status, x_filler}
                For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                dgv_list.Columns.AddRange(x)

            Case "sales_gudang"
                setDoubleBuffered(dgv_detail, True)
                dgv_detail.Columns.Clear()
                dgv_detail.AutoGenerateColumns = False

                Dim gudang_id = New DataGridViewColumn
                Dim gudang_nama = New DataGridViewColumn
                Dim gudang_status = New DataGridViewColumn
                gudang_id = dgvcol_templ_status.Clone()
                gudang_nama = dgvcol_templ_status.Clone()
                gudang_status = dgvcol_templ_status.Clone()

                gudang_id.Name = "gudang_id" : gudang_id.HeaderText = "Kode" : gudang_id.DataPropertyName = "gudang"
                gudang_nama.Name = "gudang_nama" : gudang_nama.HeaderText = "Nama Gudang" : gudang_nama.DataPropertyName = "gudang_n"
                gudang_status.Name = "gudang_status" : gudang_status.HeaderText = "Status" : gudang_status.DataPropertyName = "status"

                gudang_id.Width = 100 : gudang_nama.Width = 250

                x = {gudang_id, gudang_nama, gudang_status, x_filler}
                For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                dgv_detail.Columns.AddRange(x)

            Case "sales_barang"
                setDoubleBuffered(dgv_detail2, True)
                dgv_detail2.Columns.Clear()
                dgv_detail2.AutoGenerateColumns = False

                Dim brg_id = New DataGridViewColumn
                Dim brg_nama = New DataGridViewColumn
                Dim brg_kat = New DataGridViewColumn
                Dim brg_status = New DataGridViewColumn
                brg_id = dgvcol_templ_status.Clone()
                brg_nama = dgvcol_templ_id.Clone()
                brg_kat = dgvcol_templ_id.Clone()
                brg_status = dgvcol_templ_status.Clone()

                brg_id.Name = "brg_id" : brg_id.HeaderText = "Kode Brg." : brg_id.DataPropertyName = "barang"
                brg_nama.Name = "brg_nama" : brg_nama.HeaderText = "Nama Brg." : brg_nama.DataPropertyName = "barang_n"
                brg_kat.Name = "brg_kat" : brg_kat.HeaderText = "Kat." : brg_kat.DataPropertyName = "pajak"
                brg_status.Name = "brg_status" : brg_status.HeaderText = "Status" : brg_kat.DataPropertyName = "status"

                brg_id.Width = 100 : brg_nama.Width = 250

                x = {brg_id, brg_nama, brg_kat, brg_status, x_filler}
                For i = 0 To x.Count - 1 : x(i).DisplayIndex = i : Next
                dgv_detail2.Columns.AddRange(x)

            Case Else
                Exit Sub
        End Select
    End Sub

    'LOAD DATA
    Private Async Sub LoadDataGrid(Param As String, Page As Integer)
        Dim dt As New DataTable
        Dim _typedata As String = ""
        Dim _limitdata As Integer = _limit
        Dim DataCount As Integer = 0
        Dim PageInfo As String = "{0}-{1} dari {2} data."

        setDoubleBuffered(Me.dgv_list, True)
        _typedata = "salessetting"

        Dim done As Boolean = False
        Dim _switchCtrl() As Control = {bt_search, bt_cl, bt_page_first, bt_page_last, bt_page_next, bt_page_prev}
        Try
            Me.Cursor = Cursors.WaitCursor : dgv_list.Cursor = Cursors.WaitCursor
            For Each ctr As Control In _switchCtrl
                ctr.Enabled = False
            Next
            mnstrip_main.Enabled = False

            dgv_list.DataSource = New DataTable
            lbl_pageinfo.Text = String.Format(PageInfo, 0, 0, 0) & " - LOADING . . ."

            Dim _datalist = Await Task.Run(Function() GetDataLIstForListTemplate(_typedata, Param, Page, _limitdata))
            Dim _datacount = Await Task.Run(Function() GetDataCount(_typedata, Param))

            If _datalist.Key And _datacount.Key Then
                dgv_list.DataSource = _datalist.Value
                DataCount = _datacount.Value

                MaxPageData = CInt(Math.Ceiling(DataCount / _limitdata))
                SelectedPageData = Page
                in_page.Text = SelectedPageData
                PageInfo = String.Format(PageInfo,
                                         If(dgv_list.RowCount > 0, 1, 0) + (_limitdata * Page) - _limitdata,
                                         dgv_list.RowCount + (_limitdata * Page) - _limitdata,
                                         DataCount
                                         )
                lbl_pageinfo.Text = PageInfo
            Else
                MaxPageData = 1
                SelectedPageData = 1
                lbl_pageinfo.Text = String.Format(PageInfo, 0, 0, 0)
            End If

            in_page.Text = SelectedPageData
            done = True
        Catch ex As Exception
            logError(ex, True)
            MessageBox.Show("Terjadi kesalahan saat pengambilan data " & Environment.NewLine & ex.Message,
                            lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            done = True
        Finally
            If done Then
                Me.Cursor = Cursors.Default : dgv_list.Cursor = Cursors.Default
                For Each ctr As Control In _switchCtrl
                    ctr.Enabled = True
                Next
                mnstrip_main.Enabled = True
            End If
        End Try
    End Sub

    Public Sub PerformRefresh()
        Me.Cursor = Cursors.WaitCursor

        MenuSw()
        in_cari.Clear() : SearchString = ""
        LoadDataGrid("", 1)
        dgv_detail.Rows.Clear() : dgv_detail.Columns.Clear()
        dgv_detail2.Rows.Clear() : dgv_detail2.Columns.Clear()
        dgv_list.ClearSelection()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub EditData(KodeSales As String)
        Dim x As New fr_sales_set_det
        x.DoLoad(KodeSales, loggeduser.allowedit_master)
    End Sub

    Private Sub SearchData(Optional Page As Integer = 1)
        Me.Cursor = Cursors.WaitCursor
        SearchString = in_cari.Text
        LoadDataGrid(in_cari.Text, Page)
        dgv_list.Focus()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadTableTrans(DetailType As String, IdTrans As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If

        Dim q As String = LoadTableTransQuery("sales_" & DetailType)
        If String.IsNullOrWhiteSpace(q) Then Exit Sub

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Using dtx = x.GetDataTable(String.Format(q, IdTrans))
                    Dim _dgv As DataGridView
                    Select Case DetailType
                        Case "gudang" : _dgv = dgv_detail
                        Case "barang" : _dgv = dgv_detail2
                        Case Else : Exit Sub
                    End Select

                    For Each row As DataRow In dtx.Rows
                        Dim i = _dgv.Rows.Add
                        For y = 0 To dtx.Columns.Count - 1
                            _dgv.Rows.Item(i).Cells(y).Value = row.ItemArray(y)
                        Next
                    Next
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke server", lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Function LoadTableTransQuery(DataType As String) As String
        Dim _retval As String = ""

        Select Case LCase(DataType)
            Case "sales_gudang"
                _retval = "SELECT sg_kode_gudang gudang, gudang_nama gudang_n, ref_text status FROM data_salesman_gudang " _
                        & "LEFT JOIN data_barang_gudang ON gudang_kode=sg_kode_gudang " _
                        & "LEFT JOIN ref_jenis ON gudang_status=ref_kode AND ref_status=1 AND ref_type='status_master' " _
                        & "WHERE sg_kode_sales='{0}' AND sg_status=1"
            Case "sales_barang"
                _retval = "SELECT sb_kode_barang barang, barang_nama barang_n, pajak.ref_text pajak, status.ref_text status " _
                        & "FROM data_salesman_barang " _
                        & "LEFT JOIN data_barang_master ON barang_kode=sb_kode_barang " _
                        & "LEFT JOIN ref_jenis pajak ON barang_pajak=pajak.ref_kode AND pajak.ref_status=1 AND pajak.ref_type='ppn_trans2' " _
                        & "LEFT JOIN ref_jenis status ON barang_status=status.ref_kode AND status.ref_status=1 AND status.ref_type='status_master' " _
                        & "WHERE sb_kode_sales='{0}' AND sb_status=1"
        End Select

        Return _retval
    End Function

    Private Sub ShowDetail(DetailType As String, IdTrans As String)
        Me.Cursor = Cursors.AppStarting
        Try
            SetDataGrid("sales_" & LCase(DetailType))
            LoadTableTrans(DetailType, IdTrans)
            Select Case DetailType
                Case "gudang" : dgv_detail.ClearSelection()
                Case "barang" : dgv_detail2.ClearSelection()
                Case Else : Exit Sub
            End Select
        Catch ex As Exception
            logError(ex, True)
            Dim text = "Tidak dapat menampilkan data" & Environment.NewLine & ex.Message
            MessageBox.Show(text, lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
EndSub:
        Me.Cursor = Cursors.Default
    End Sub

    'UI : CLOSE
    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        dgv_detail.Rows.Clear() : dgv_detail.Columns.Clear()
        dgv_detail2.Rows.Clear() : dgv_detail2.Columns.Clear()
        main.tabcontrol.TabPages.Remove(tabpagename)
    End Sub

    'UI : FLUID
    Private Sub SplitContainer1_SizeChanged(sender As Object, e As EventArgs) Handles SplitContainer1.SizeChanged
        SplitContainer1.SplitterDistance = SplitContainer1.Width * 0.5
    End Sub

    'UI : DGV ITEM LIST
    Private Sub dgv_list_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                EditData(dgv_list.Rows(e.RowIndex).Cells(0).Value)
            End If
        Catch ex As Exception
            logError(ex, False)
        End Try
    End Sub

    Private Sub dgv_list_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_list.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            If dgv_list.SelectedRows.Count > 0 And dgv_list.RowCount > 0 Then
                EditData(dgv_list.SelectedRows.Item(0).Cells(0).Value)
            End If
        End If
    End Sub

    Private Sub dgv_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellClick, dgv_list.RowEnter
        If dgv_list.RowCount > 0 And dgv_list.SelectedRows.Count > 0 And e.RowIndex >= 0 Then
            ShowDetail("gudang", dgv_list.SelectedRows.Item(0).Cells(0).Value)
            dgv_detail.ClearSelection()
            ShowDetail("barang", dgv_list.SelectedRows.Item(0).Cells(0).Value)
            dgv_detail2.ClearSelection()
        End If
    End Sub

    'UI : MENU
    Private Sub mn_edit_Click(sender As Object, e As EventArgs) Handles mn_edit.Click
        If dgv_list.RowCount > 0 And dgv_list.SelectedRows.Count > 0 Then
            EditData(dgv_list.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    Private Sub mn_refresh_Click(sender As Object, e As EventArgs) Handles mn_refresh.Click
        PerformRefresh()
    End Sub

    'UI : BUTTON
    Private Sub bt_search_Click(sender As Object, e As EventArgs) Handles bt_search.Click
        SearchData()
    End Sub

    Private Sub bt_page_prev_Click(sender As Object, e As EventArgs) Handles bt_page_prev.Click, bt_page_first.Click
        If String.IsNullOrWhiteSpace(in_page.Text) Then Exit Sub
        in_cari.Text = SearchString

        Me.Cursor = Cursors.WaitCursor
        If SelectedPageData = 1 Then
            in_page.Text = SelectedPageData
        ElseIf SelectedPageData > 1 And sender.Name = "bt_page_prev" Then
            SearchData(SelectedPageData - 1)
        Else
            SearchData(1)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_page_next_Click(sender As Object, e As EventArgs) Handles bt_page_next.Click, bt_page_last.Click
        If String.IsNullOrWhiteSpace(in_page.Text) Then Exit Sub
        in_cari.Text = SearchString

        Me.Cursor = Cursors.WaitCursor
        If SelectedPageData = MaxPageData Then
            in_page.Text = SelectedPageData
        ElseIf SelectedPageData < MaxPageData And sender.Name = "bt_page_next" Then
            SearchData(SelectedPageData + 1)
        Else
            SearchData(MaxPageData)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    'UI : TEXTBOX
    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.Cursor = Cursors.WaitCursor : bt_search.PerformClick() : Me.Cursor = Cursors.Default
        End If
    End Sub
End Class
