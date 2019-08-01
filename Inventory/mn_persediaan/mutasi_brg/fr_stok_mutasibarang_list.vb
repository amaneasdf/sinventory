Public Class fr_stok_mutasibarang_list
    Public tabpagename As TabPage

    Private MaxPageData As Integer = 1
    Private SelectedPageData As Integer = 1
    Private SearchedString As String = ""

    Private tblstatus As String = ""

    'KEYSHORTCUT
    Protected Overrides Function ProcessKeyPreview(ByRef m As Message) As Boolean
        If m.Msg = &H100 Or m.Msg = &H101 Then  'WM_KEYDOWN / WM_KEYUP
            Dim key As Keys = m.WParam
            If key = Keys.F5 Then
                performRefresh()
                Return True
            ElseIf key = Keys.N And My.Computer.Keyboard.CtrlKeyDown Then
                AddData() : Return True
            ElseIf key = Keys.F And My.Computer.Keyboard.CtrlKeyDown Then
                in_cari.Focus() : Return True
            ElseIf key = Keys.O And My.Computer.Keyboard.CtrlKeyDown Then
                If dgv_barang.SelectedRows.Count > 0 Then
                    EditData(dgv_barang.SelectedRows.Item(0).Cells(0).Value) : Return True
                End If
                'ElseIf key = Keys.P And My.Computer.Keyboard.CtrlKeyDown Then
                '    printItem()
                '    Return True
            End If
        End If

        Return MyBase.ProcessKeyPreview(m)
    End Function


    Public Sub setpage(page As TabPage)
        tabpagename = page
        lbl_title.Text = page.Text
        performRefresh()
    End Sub

    'REFRESH PAGE
    Public Sub performRefresh()
        clearPreview()
        in_cari.Clear() : SearchedString = ""
        LoadDataGrid("", 1)

        If selectperiode.closed = True Then
            mn_tambah.Enabled = False
            mn_hapus.Enabled = False
        End If
    End Sub

    Private Sub LoadDataGrid(Param As String, Page As Integer)
        Dim dt As New DataTable
        Dim _typedata As String = ""
        Dim _limitdata As Integer = 2000
        Dim DataCount As Integer = 0
        Dim PageInfo As String = "{0}-{1} dari {2} data."

        setDoubleBuffered(Me.dgv_list, True)

        dgv_list.DataSource = GetDataLIstForListTemplate(_typedata, Param, Page)
        DataCount = GetDataCount(_typedata, Param)
        MaxPageData = CInt(Math.Ceiling(DataCount / _limitdata))
        SelectedPageData = Page
        in_page.Text = SelectedPageData
        PageInfo = String.Format(PageInfo,
                                 If(dgv_list.RowCount > 0, 1, 0) + (_limitdata * Page) - _limitdata,
                                 dgv_list.RowCount + (_limitdata * Page) - _limitdata,
                                 DataCount
                                 )
        lbl_pageinfo.Text = PageInfo
    End Sub

    'LOAD DATA
    Private Sub loadData(kode As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If
        Dim q As String = ""
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT faktur_kode, faktur_tanggal, pajak.ref_text faktur_kat, faktur_gudang, gudang_nama, faktur_status " _
                    & "FROM data_barang_mutasi " _
                    & "LEFT JOIN data_barang_gudang ON gudang_kode=faktur_gudang " _
                    & "LEFT JOIN ref_jenis pajak ON faktur_pajak=pajak.ref_kode AND pajak.ref_status=1 AND pajak.ref_type='ppn_trans2'" _
                    & "WHERE faktur_kode ='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, kode))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_kode.Text = rdx.Item("faktur_kode")
                        in_kat.Text = rdx.Item("faktur_kat")
                        date_tgl_beli_r.Text = CDate(rdx.Item("faktur_tanggal")).ToLongDateString
                        in_gudang.Text = rdx.Item("faktur_gudang")
                        in_gudang_n.Text = rdx.Item("gudang_nama")
                        tblstatus = rdx.Item("faktur_status")
                    End If
                End Using
                q = "SELECT trans_barang_asal, a.barang_nama, trans_qty_asal, trans_sat_asal,trans_hpp_asal, " _
                    & "trans_barang_tujuan, b.barang_nama, trans_qty_tujuan, trans_sat_tujuan,trans_hpp_tujuan  " _
                    & "FROM data_barang_mutasi_trans " _
                    & "LEFT JOIN data_barang_master a ON a.barang_kode=trans_barang_asal " _
                    & "LEFT JOIN data_barang_master b ON b.barang_kode=trans_barang_tujuan " _
                    & "WHERE trans_faktur='{0}' AND trans_status=1"
                Using dt = x.GetDataTable(String.Format(q, kode))
                    With dgv_barang.Rows
                        For Each row As DataRow In dt.Rows
                            Dim i = .Add
                            .Item(i).Cells("kode").Value = row.ItemArray(0)
                            .Item(i).Cells("nama").Value = row.ItemArray(1)
                            .Item(i).Cells("qty_a").Value = row.ItemArray(2)
                            .Item(i).Cells("sat_a").Value = row.ItemArray(3)
                            .Item(i).Cells("hpp").Value = row.ItemArray(4)
                            .Item(i).Cells("kode_b").Value = row.ItemArray(5)
                            .Item(i).Cells("nama_b").Value = row.ItemArray(6)
                            .Item(i).Cells("qty_b").Value = row.ItemArray(7)
                            .Item(i).Cells("sat_b").Value = row.ItemArray(8)
                            .Item(i).Cells("hpp_b").Value = row.ItemArray(9)
                        Next
                    End With
                End Using
                Select Case tblstatus
                    Case 0 : in_status.Text = "Pending"
                    Case 1 : in_status.Text = "Aktif"
                    Case 2 : in_status.Text = "Batal"
                    Case 8 : in_status.Text = "On-Edit/NOT IMPLEMENTED!"
                    Case 9 : in_status.Text = "Delete"
                    Case Else : Exit Sub
                End Select
                setStatus()
            Else
                MessageBox.Show("Tidak dapat terhubung ke server", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Sub setStatus()
        Select Case tblstatus
            Case 0, 1
                mn_hapus.Enabled = If(selectperiode.closed = False, True, False)
                mn_print.Enabled = If(tblstatus = 1, True, False)
            Case 2, 9
                mn_hapus.Enabled = False
                mn_print.Enabled = False
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub AddData()
        If selectperiode.closed Then Exit Sub
        Dim detail As New fr_stok_mutasi_barang
        detail.doLoadNew()
    End Sub

    Private Sub EditData(IdTrans As String)
        Dim detail As New fr_stok_mutasi_barang
        If selectperiode.closed Then
            detail.doLoadView(IdTrans)
        Else
            detail.doLoadEdit(IdTrans, loggeduser.allowedit_transact)
        End If
    End Sub

    Private Sub CancelData(IdTrans As String)
        Me.Cursor = Cursors.WaitCursor
        If selectperiode.closed Or Not loggeduser.validasi_trans Then Exit Sub

        Dim q As String = ""
        Dim _status As Integer = 0
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    q = "SELECT faktur_status FROM data_barang_mutasi WHERE faktur_kode='{0}' AND faktur_status<9 ORDER BY faktur_id DESC LIMIT 1"
                    _status = CInt(x.ExecScalar(String.Format(q, IdTrans)))
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data." & Environment.NewLine & ex.Message,
                                    lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GoTo EndSub
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                GoTo EndSub
            End If
        End Using

        If Not {0, 1}.Contains(_status) Then GoTo EndSub
        ChangeDataState(IdTrans, 2)

EndSub:
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub UnCancelData(IdTrans As String)
        Me.Cursor = Cursors.WaitCursor
        If selectperiode.closed Or Not loggeduser.validasi_trans Then Exit Sub

        Dim q As String = ""
        Dim _status As Integer = 0
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    q = "SELECT faktur_status FROM data_barang_mutasi WHERE faktur_kode='{0}' AND faktur_status<9 ORDER BY faktur_id DESC LIMIT 1"
                    _status = CInt(x.ExecScalar(String.Format(q, IdTrans)))
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data." & Environment.NewLine & ex.Message,
                                    lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GoTo EndSub
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                GoTo EndSub
            End If
        End Using

        If Not _status = 2 Then GoTo EndSub
        ChangeDataState(IdTrans, 1)

EndSub:
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DeleteData(IdTrans As String)
        If selectperiode.closed Or Not loggeduser.validasi_trans Then Exit Sub
        ChangeDataState(IdTrans, 9)
    End Sub

    Private Sub ChangeDataState(IdTrans As String, DataState As Integer)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim MsgList As New List(Of String)
        Select Case DataState
            Case 1
                Dim _prevState As Integer = 0
                Dim _q As String = ""

                Using x = MainConnection
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        Try
                            _q = "SELECT faktur_status FROM data_barang_mutasi WHERE faktur_kode='{0}' ORDER BY faktur_id DESC LIMIT 1"
                            _prevState = CInt(x.ExecScalar(String.Format(_q, IdTrans)))
                        Catch ex As Exception
                            logError(ex, True)
                            MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data." & Environment.NewLine & ex.Message,
                                            lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try
                    Else
                        MessageBox.Show("Tidak dapat terhubung ke database.", lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using

                If _prevState = 0 Then
                    MsgList.AddRange({"Proses transaksi mutasi?", "Transaksi berhasil di proses", "Transaksi gagal di proses. Terjadi kesalahan saat melakukan proses."})
                ElseIf _prevState = 2 Then
                    MsgList.AddRange({"Cancel pembatalan transaksi mutasi?", "Cancel pembatalan berhasil dilakukan.",
                                      "Cancel pembatalan gagal. Terjadi kesalahn saat melakukan proses."})
                Else
                    Exit Sub
                End If
            Case 2
                MsgList.AddRange({"Batalkan transaksi mutasi?", "Transaksi berhasil dibatalkan.", "Pembatalan transaksi gagal. Terjadi kesalahan saat melakukan proses."})
            Case 9
                MsgList.AddRange({"Hapus transaksi mutasi?", "Transaksi berhasil dihapus.", "Transaksi tidak dapat dihapus. Terjadi kesalahan saat melakukan proses."})
            Case Else : Exit Sub
        End Select

        If MessageBox.Show(MsgList.Item(0), lbl_title.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim _ket As String = ""
            If TransConfirmValid(_ket) Then
                Dim q As String = ""
                Dim qArr As New List(Of String)
                Dim qCk As Boolean = False

                Using x = MainConnection
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        q = "UPDATE data_barang_mutasi SET faktur_status={3}, faktur_ket=TRIM(BOTH '\r\n' FROM CONCAT(faktur_ket,'\r\n','{2}')), " _
                            & "faktur_upd_date =NOW(), faktur_upd_alias='{1}' WHERE faktur_kode='{0}' AND faktur_status<9"
                        qArr.Add(String.Format(q, IdTrans, loggeduser.user_id, _ket, DataState))
                        q = "CALL transMutasiBarangFin('{0}','{1}')"
                        qArr.Add(String.Format(q, IdTrans, loggeduser.user_id))

                        qCk = x.TransactCommand(qArr)

                        If qCk Then
                            MessageBox.Show(MsgList.Item(1), lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            performRefresh()
                            If DataState < 9 Then loadData(IdTrans)
                        Else
                            MessageBox.Show(MsgList.Item(2), lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Tidak dapat terhubung ke database.", lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End If
        End If
    End Sub

    Private Sub PrintData(IdTrans As String)

    End Sub

    Private Sub ExportData()

    End Sub

    Private Sub SearchData(ParamStr As String)
        clearPreview()
        SearchedString = ParamStr
        LoadDataGrid(ParamStr, 1)
    End Sub

    'LOAD DATA TO FORM + SETUP
    Private Sub listToDetail()
        Try
            Me.Cursor = Cursors.AppStarting
            dgv_barang.Rows.Clear()
            loadData(dgv_list.SelectedRows.Item(0).Cells(0).Value)
        Catch ex As Exception
            logError(ex, True)
            Dim text = "Tidak dapat menampilkan data" & Environment.NewLine & ex.Message
            MessageBox.Show(text, lbl_title.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub clearPreview()
        For Each x As TextBox In {in_kode, in_kat, in_gudang, in_gudang_n, in_status, date_tgl_beli_r}
            x.Clear()
        Next
        dgv_barang.Rows.Clear()
    End Sub

    'UI : CLOSE
    Private Sub bt_close_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_close_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        clearPreview()
        main.tabcontrol.TabPages.Remove(tabpagename)
    End Sub

    'UI : MENU
    Private Sub mn_tambah_Click(sender As Object, e As EventArgs) Handles mn_tambah.Click
        AddData()
    End Sub

    Private Sub mn_edit_Click(sender As Object, e As EventArgs) Handles mn_edit.Click
        If dgv_list.RowCount > 0 And dgv_list.SelectedRows.Count > 0 Then
            EditData(dgv_list.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    Private Sub mn_hapus_Click(sender As Object, e As EventArgs) Handles mn_hapus.Click
        If dgv_list.RowCount > 0 And dgv_list.SelectedRows.Count > 0 Then
            CancelData(dgv_barang.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    Private Sub mn_refresh_Click(sender As Object, e As EventArgs) Handles mn_refresh.Click
        performRefresh()
    End Sub

    Private Sub mn_cari_Click(sender As Object, e As EventArgs) Handles mn_cari.Click
        in_cari.Focus()
    End Sub

    'cari
    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            searchData(in_cari.Text)
        End If
    End Sub

    'UI : DGV LIST
    Private Sub dgv_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellClick
        If e.RowIndex >= 0 Then
            listToDetail()
        End If
    End Sub

    Private Sub dgv_list_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_list.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim detail As New fr_stok_mutasi_barang
            If selectperiode.closed = False Then
                detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
            Else
                detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
            End If
        End If
    End Sub

    Private Sub dgv_list_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgv_list.RowsAdded
        in_countdata.Text = dgv_list.Rows.Count
    End Sub

    Private Sub dgv_list_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellDoubleClick
        Dim detail As New fr_stok_mutasi_barang
        If selectperiode.closed = False Then
            detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
        Else
            detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub
End Class
