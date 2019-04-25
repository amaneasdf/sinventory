Public Class uc_sales_barang
    Public tabpagename As TabPage
    Private popupstate As String = ""
    Private _brgstatus As String = ""

    Public Sub setpage(page As TabPage)
        tabpagename = page
    End Sub

    'REFRESH PAGE
    Public Sub performRefresh(Optional clearPreview As Boolean = True)
        If clearPreview Then Me.clearPreview()
        in_cari.Clear()
        SearchData("")
        ck_setgudang_CheckedChanged(Nothing, Nothing)
    End Sub

    'SEARCH
    Private Sub SearchData(param As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                setDoubleBuffered(dgv_sales, True)
                Dim q As String = "SELECT salesman_kode, salesman_nama, jenis.ref_text salesman_jenis, " _
                                  & "(CASE salesman_status WHEN 0 THEN 'INACTIVE' WHEN 1 THEN 'ACTIVE' ELSE 'ERROR' END) salesman_status " _
                                  & "FROM data_salesman_master LEFT JOIN ref_jenis jenis ON salesman_jenis=jenis.ref_kode AND jenis.ref_status=1 AND jenis.ref_type='sales_jenis' " _
                                  & "WHERE salesman_status IN (0,1) AND (salesman_kode LIKE '%{0}%' OR salesman_nama LIKE '%{0}%') LIMIT 0,2000"
                dgv_sales.DataSource = x.GetDataTable(String.Format(q, param))
            End If
        End Using
    End Sub

    'LOAD DATA
    Private Sub loadData(KodeSales)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If

        Using x = MainConnection
            Dim q As String
            Dim _status As String = 0
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT salesman_kode, salesman_nama, jenis.ref_text, salesman_status, sg_kode_gudang, gudang_nama, sg_allitem " _
                    & "FROM data_salesman_master " _
                    & "LEFT JOIN data_salesman_gudang ON salesman_kode=sg_kode_sales AND sg_status=1 " _
                    & "LEFT JOIN data_barang_gudang ON gudang_kode=sg_kode_gudang " _
                    & "LEFT JOIN ref_jenis jenis ON jenis.ref_kode=salesman_jenis AND jenis.ref_status=1 AND jenis.ref_type='sales_jenis' " _
                    & "WHERE salesman_kode='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, KodeSales), CommandBehavior.SingleRow)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_sales.Text = rdx.Item(0)
                        in_sales_n.Text = rdx.Item(1)
                        in_sales_j.Text = rdx.Item(2)
                        _status = rdx.Item(3)
                        If Not IsDBNull(rdx.Item("sg_kode_gudang")) Then
                            Dim _gudang As String = rdx.Item("sg_kode_gudang")
                            If Not String.IsNullOrWhiteSpace(_gudang) Then
                                ck_setgudang.Checked = True
                                in_gudang.Text = _gudang
                                in_gudang_n.Text = rdx.Item("gudang_nama")
                                ck_allitem.Checked = IIf(rdx.Item("sg_allitem") = 1, True, False)
                            End If
                        Else
                            ck_setgudang.Checked = False
                            ck_allitem.Checked = True
                            ck_setgudang_CheckedChanged(Nothing, Nothing)
                        End If
                    Else
                        MessageBox.Show("Tidak dapat mengambil data", "Set barang salesman", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using
                If ck_setgudang.Checked And ck_allitem.Checked = False Then
                    q = "SELECT sb_kode_barang, barang_nama, " _
                        & "(CASE barang_status WHEN 1 THEN 'AKTIF' WHEN 0 THEN 'INACTIVE' ELSE 'ERROR' END) barang_status " _
                        & "FROM data_salesman_barang " _
                        & "LEFT JOIN data_barang_master ON sb_kode_barang=barang_kode " _
                        & "WHERE sb_status=1 AND sb_kode_sales='{0}'"
                    Using dtx = x.GetDataTable(String.Format(q, KodeSales))
                        For Each row As DataRow In dtx.Rows
                            With dgv_barang.Rows
                                Dim i As Integer = .Add
                                .Item(i).Cells(0).Value = row.ItemArray(0)
                                .Item(i).Cells(1).Value = row.ItemArray(1)
                                .Item(i).Cells(2).Value = row.ItemArray(2)
                            End With
                        Next
                    End Using
                End If
                Select Case _status
                    Case 0 : in_status.Text = "Inactive"
                    Case 1 : in_status.Text = "Active"
                    Case 9 : in_status.Text = "Delete"
                    Case Else : in_status.Text = "Error"
                End Select

                bt_batalbeli.Enabled = True
                bt_simpanbeli.Enabled = True
            End If
        End Using
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Dim autoco As New AutoCompleteStringCollection
        Select Case tipe
            Case "gudang"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang " _
                    & "WHERE gudang_status=1 AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%') LIMIT 250"
            Case "barang"
                q = "SELECT barang_kode AS Kode, barang_nama AS Nama, (CASE barang_status WHEN 0 THEN 'Non-Aktif' WHEN 1 THEN 'AKTIF' ELSE 'ERROR' END) Status " _
                    & "FROM data_stok_awal " _
                    & "LEFT JOIN data_barang_master ON stock_barang=barang_kode " _
                    & "WHERE stock_status=1 AND stock_gudang='{0}' AND (barang_kode LIKE '%{1}%' OR barang_nama LIKE '%{1}%') LIMIT 250"
                q = String.Format(q, in_gudang.Text, "{0}")
            Case Else
                Exit Sub
        End Select

        dt = getDataTablefromDB(String.Format(q, param))

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 100
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
    End Sub

    'OPEN SEARCH WINDOW
    Private Sub doSearch()

    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    popPnl_barang.Visible = False
                Case "barang"
                    in_barang.Text = .Cells(0).Value
                    in_barang_n.Text = .Cells(1).Value
                    _brgstatus = .Cells(2).Value
                    bt_tbbarang.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
    End Sub

    'CLEAR INPUT
    Private Sub clearPreview()
        For Each txt As TextBox In {in_sales, in_sales_n, in_sales_j, in_status, in_gudang, in_gudang_n, in_barang, in_barang_n}
            txt.Clear()
        Next
        For Each dgv As DataGridView In {dgv_barang}
            dgv.Rows.Clear()
        Next
        ck_setgudang.Checked = False
        ck_allitem.Checked = True
    End Sub

    Private Sub clearInputBrg()
        in_barang.Clear()
        in_barang_n.Clear()
        _brgstatus = ""
    End Sub

    'SAVE DATA
    Private Sub saveData()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If
        Dim queryArr As New List(Of String)
        Dim queryCk As Boolean = False
        Dim q As String = ""
        Dim _data As String()

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "UPDATE data_salesman_master SET salesman_gudang={0} WHERE salesman_kode='{1}'"
                If ck_setgudang.Checked Then
                    queryArr.Add(String.Format(q, 1, in_sales.Text))
                Else
                    queryArr.Add(String.Format(q, 0, in_sales.Text))
                End If

                q = "UPDATE data_salesman_gudang SET sg_status=9 WHERE sg_kode_sales='{0}'"
                queryArr.Add(String.Format(q, in_sales.Text))

                q = "INSERT INTO data_salesman_gudang SET {0}"
                _data = {
                    "sg_kode_sales='" & in_sales.Text & "'",
                    "sg_kode_gudang='" & in_gudang.Text & "'",
                    "sg_allitem=" & IIf(ck_allitem.Checked, 1, 0),
                    "sg_reg_date=NOW()",
                    "sg_reg_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add(String.Format(q, String.Join(",", _data)))

                q = "UPDATE data_salesman_barang SET sb_status=9 WHERE sb_kode_sales='{0}'"
                queryArr.Add(String.Format(q, in_sales.Text))

                q = "UPDATE data_salesman_master SET salesman_barang={0} WHERE salesman_kode='{1}'"
                If Not ck_allitem.Checked Then
                    queryArr.Add(String.Format(q, 1, in_sales.Text))

                    q = "INSERT INTO data_salesman_barang SET {0} ON DUPLICATE KEY UPDATE sb_status=1"
                    For Each row As DataGridViewRow In dgv_barang.Rows
                        _data = {
                            "sb_kode_sales='" & in_sales.Text & "'",
                            "sb_kode_barang='" & row.Cells(0).Value & "'",
                            "sb_reg_date=NOW()",
                            "sb_reg_alias='" & loggeduser.user_id & "'"
                            }
                        queryArr.Add(String.Format(q, String.Join(",", _data)))
                    Next
                Else
                    queryArr.Add(String.Format(q, 0, in_sales.Text))
                End If

                queryCk = x.TransactCommand(queryArr)
            Else
                queryCk = False
            End If
        End Using

        If queryCk Then
            MessageBox.Show("Data tersimpan", "Set Barang Sales", MessageBoxButtons.OK, MessageBoxIcon.Information)
            performRefresh(False)
        Else
            MessageBox.Show("Data tidak dapat tersimpan", "Set Barang Sales", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
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

    'UI : POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_gudang_n.Focused Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub dgv_listbarang_CellContentDBLClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellDoubleClick
        If e.RowIndex >= 0 Then
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_KeyDown_1(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            'consoleWriteLine("fuck")
            e.SuppressKeyPress = True
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        Dim x As TextBox
        Select Case popupstate
            Case "gudang"
                x = in_gudang_n
            Case Else
                x = Nothing
                x.Dispose()
                Exit Sub
        End Select

        If Char.IsLetterOrDigit(e.KeyChar) Then
            x.Text += e.KeyChar
            e.Handled = True
            x.Focus()
            x.Select(x.TextLength, x.TextLength)
        ElseIf e.KeyChar = Chr(Keys.Escape) Then
            x.Focus()
            popPnl_barang.Visible = False
            e.Handled = True
        ElseIf e.KeyChar = Chr(Keys.Back) Then
            x.Focus()
            x.Text = Strings.Left(x.Text, x.Text.Length - 1)
            e.Handled = True
        End If
    End Sub

    'UI : BUTTON
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        If ck_setgudang.Checked Then
            If String.IsNullOrWhiteSpace(in_gudang.Text) Then
                MessageBox.Show("Gudang belum diinput.", "Set Barang Salesman", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            If ck_allitem.Checked = False And dgv_barang.RowCount = 0 Then
                MessageBox.Show("Barang belum diinput.", "Set Barang Salesman", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If
        End If

        If MessageBox.Show("Simpan data?", "Set Barang Salesman", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If MasterConfirmValid("") Then saveData()
        End If
    End Sub

    Private Sub bt_batalbeli_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        If MessageBox.Show("Batalkan Perubahan?", "Set Barang Salesman", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim _sales As String = in_sales.Text
            clearPreview()
            loadData(_sales)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles bt_cari.Click
        SearchData(in_cari.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_refresh.Click
        performRefresh()
    End Sub

    'UI : CHECKBOX
    Private Sub ck_setgudang_CheckedChanged(sender As Object, e As EventArgs) Handles ck_setgudang.CheckedChanged
        Dim _swEnabled = ck_setgudang.Checked
        If Not _swEnabled Then : in_gudang.Clear() : in_gudang_n.Clear() : End If
        For Each ctr As Control In {in_gudang, in_gudang_n, ck_allitem, dgv_barang, bt_tbbarang, in_barang, in_barang_n}
            ctr.Enabled = _swEnabled
        Next
        If _swEnabled Then ck_allitem_CheckedChanged(Nothing, Nothing)
        If dgv_barang.RowCount = 0 Then
            in_gudang_n.ReadOnly = False
        End If
    End Sub

    Private Sub ck_allitem_CheckedChanged(sender As Object, e As EventArgs) Handles ck_allitem.CheckedChanged
        Dim _swEnabled = If(ck_allitem.Checked, False, True)
        dgv_barang.Rows.Clear()
        clearInputBrg()
        For Each ctr As Control In {dgv_barang, in_barang, in_barang_n, bt_tbbarang}
            ctr.Enabled = _swEnabled
        Next
        If dgv_barang.RowCount = 0 Then
            in_gudang_n.ReadOnly = False
        End If
    End Sub

    'UI : LIST SALES
    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyCode = Keys.Enter Then
            bt_cari.Focus()
            bt_cari.PerformClick()
        End If
    End Sub

    Private Sub dgv_sales_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_sales.CellDoubleClick
        If e.RowIndex > -1 Then
            loadData(dgv_sales.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    Private Sub dgv_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_sales.KeyDown
        If dgv_sales.SelectedRows.Count > 0 Then
            loadData(dgv_sales.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    'UI : INPUT DATA
    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_gudang_n_Enter(sender As Object, e As EventArgs) Handles in_gudang_n.Enter, in_barang_n.Enter
        If sender.Readonly = False And sender.Enabled = True Then
            Select Case sender.Name.ToString
                Case "in_gudang_n"
                    popupstate = "gudang"
                Case "in_barang_n"
                    popupstate = "barang"
            End Select
            popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup(popupstate, sender.Text)
        End If
    End Sub

    Private Sub in_gudang_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyDown, in_barang_n.KeyDown
        Dim _nxtcntrl As Control = Nothing
        Dim _kdcntrl As Control = Nothing

        Select Case sender.Name.ToString
            Case "in_gudang_n"
                _nxtcntrl = ck_allitem
                _kdcntrl = in_gudang
            Case "in_barang_n"
                _nxtcntrl = bt_tbbarang
                _kdcntrl = in_barang
            Case Else
                Exit Sub
        End Select

        If sender.Text = "" And IsNothing(_kdcntrl) = False Then
            _kdcntrl.Text = ""
        End If

        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            _nxtcntrl.Focus()
        Else
            If e.KeyCode <> Keys.Escape And sender.Readonly = False Then
                If e.KeyCode = Keys.Back And Not IsNothing(_kdcntrl) Then
                    _kdcntrl.Text = ""
                End If
                If popPnl_barang.Visible = False Then
                    popPnl_barang.Visible = True
                End If
                loadDataBRGPopup(popupstate, sender.Text & IIf(Char.IsLetterOrDigit(Convert.ToChar(e.KeyCode)), Convert.ToChar(e.KeyCode), ""))
            Else
                popPnl_barang.Visible = False
            End If
        End If
    End Sub

    Private Sub in_gudang_n_Leave(sender As Object, e As EventArgs) Handles in_gudang_n.Leave, in_barang_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    'UI : INPUT BARANG
    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        keyshortenter(in_barang_n, e)
    End Sub

    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        If String.IsNullOrWhiteSpace(in_barang.Text) Then
            MessageBox.Show("Barang belum diinput.", "Set Barang Salesman", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_barang_n.Focus()
            Exit Sub
        End If

        For Each row As DataGridViewRow In dgv_barang.Rows
            If row.Cells(0).Value = in_barang.Text Then
                MessageBox.Show(in_barang_n.Text & " sudah diinput.", "Set Barang Salesman", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                in_barang_n.Focus()
                clearInputBrg()
                Exit Sub
            End If
        Next

        With dgv_barang.Rows
            Dim i As Integer = .Add()
            .Item(i).Cells(0).Value = in_barang.Text
            .Item(i).Cells(1).Value = in_barang_n.Text
            .Item(i).Cells(2).Value = _brgstatus
        End With

        in_gudang_n.ReadOnly = True
        clearInputBrg()
        in_barang_n.Focus()
    End Sub

    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        If e.RowIndex >= 0 Then
            With dgv_barang.SelectedRows.Item(0)
                in_barang.Text = .Cells(0).Value
                in_barang_n.Text = .Cells(1).Value
                _brgstatus = .Cells(2).Value
            End With
            dgv_barang.Rows.RemoveAt(e.RowIndex)

            If dgv_barang.RowCount = 0 Then
                in_gudang_n.ReadOnly = False
            End If
        End If
    End Sub

    Private Sub bt_clear_Click(sender As Object, e As EventArgs) Handles bt_clear.Click
        If MessageBox.Show("Hapus barang?", "Set Barang Sales", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            dgv_barang.Rows.Clear()
            in_gudang_n.ReadOnly = False
        End If
    End Sub
End Class