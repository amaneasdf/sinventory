Public Class fr_sales_set_det

    Private Sub SetUpForm(KodeSales As String, AllowInput As Boolean)
        GetTableGudang("")
        GetTableBarang("")
        LoadDataSales(KodeSales)
        ControlSwitch(AllowInput)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        For Each btn As Button In {bt_simpanbeli, bt_add_brg, bt_add_gudang, bt_rem_gudang, bt_rem_brg, bt_remall_brg, bt_remall_gudang}
            btn.Enabled = AllowInput
        Next
        Me.Text = lbl_title.Text
    End Sub

    Public Sub DoLoad(KodeSales As String, AllowInput As Boolean)
        SetUpForm(KodeSales, AllowInput)
        Me.Show()
    End Sub

    'LOAD DATA
    Private Sub LoadDataSales(KodeSales As String)
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = ""
                q = "SELECT salesman_nama FROM data_salesman_master WHERE salesman_kode='{0}'"
                in_sales.Text = KodeSales
                in_sales_n.Text = x.ExecScalar(String.Format(q, KodeSales)).ToString

                setDoubleBuffered(dgv_gudang_slct, True)
                q = "SELECT sg_kode_gudang, gudang_nama, ref_text FROM data_salesman_gudang " _
                    & "LEFT JOIN data_barang_gudang ON sg_kode_gudang=gudang_kode " _
                    & "LEFT JOIN ref_jenis ON gudang_status=ref_kode AND ref_status=1 AND ref_type='status_master' " _
                    & "WHERE sg_kode_sales='{0}' AND sg_status=1"
                Using dtx = x.GetDataTable(String.Format(q, KodeSales))
                    For Each row As DataRow In dtx.Rows
                        With dgv_gudang_slct
                            Dim i = .Rows.Add
                            For ss = 0 To 2 : .Rows(i).Cells(ss).Value = row.Item(ss) : Next
                        End With
                    Next
                End Using

                setDoubleBuffered(dgv_barang_slct, True)
                q = "SELECT sb_kode_barang, barang_nama, pajak.ref_text, status.ref_text " _
                    & "FROM data_salesman_barang " _
                    & "LEFT JOIN data_barang_master ON barang_kode=sb_kode_barang " _
                    & "LEFT JOIN ref_jenis pajak ON barang_pajak=pajak.ref_kode AND pajak.ref_status=1 AND pajak.ref_type='ppn_trans2' " _
                    & "LEFT JOIN ref_jenis status ON barang_status=status.ref_kode AND status.ref_status=1 AND status.ref_type='status_master' " _
                    & "WHERE sb_kode_sales='{0}' AND sb_status=1"
                Using dtx = x.GetDataTable(String.Format(q, KodeSales))
                    For Each row As DataRow In dtx.Rows
                        With dgv_barang_slct
                            Dim i = .Rows.Add
                            For ss = 0 To 3 : .Rows(i).Cells(ss).Value = row.Item(ss) : Next
                        End With
                    Next
                End Using

            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Setting Salesman", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Sub GetTableGudang(ParamStr As String)
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = ""
                Dim qwhr, qorder As String
                q = "SELECT gudang_kode, gudang_nama, ref_text gudang_status FROM data_barang_gudang " _
                    & "LEFT JOIN ref_jenis ON gudang_status=ref_kode AND ref_status=1 AND ref_type='status_master' " _
                    & "WHERE gudang_status<9 {0}"
                qorder = " ORDER BY gudang_kode LIMIT 500"
                If Not String.IsNullOrWhiteSpace(ParamStr) Then
                    ParamStr = mysqlQueryFriendlyStringFeed(ParamStr)
                    ParamStr = Trim(ParamStr).Replace(" ", ".+").Replace("(", "[(]").Replace(")", "[)]")
                    qwhr = String.Join("'" & ParamStr & "'", {" AND(gudang_kode REGEXP ", " OR gudang_nama REGEXP ", " OR ref_text REGEXP ", ")"})
                Else
                    qwhr = ""
                End If

                Using dtx = x.GetDataTable(String.Format(q, qwhr + qorder))
                    setDoubleBuffered(dgv_gudang_mstr, True)
                    dgv_gudang_mstr.AutoGenerateColumns = False
                    dgv_gudang_mstr.DataSource = dtx
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Setting Salesman", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Sub GetTableBarang(ParamStr As String)
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = ""
                Dim qwhr, qorder As String
                q = "SELECT barang_kode, barang_nama, pajak.ref_text barang_kat, status.ref_text barang_status " _
                    & "FROM data_barang_master " _
                    & "LEFT JOIN ref_jenis pajak ON barang_pajak=pajak.ref_kode AND pajak.ref_status=1 AND pajak.ref_type='ppn_trans2' " _
                    & "LEFT JOIN ref_jenis status ON barang_status=status.ref_kode AND status.ref_status=1 AND status.ref_type='status_master' " _
                    & "WHERE barang_status<9 {0}"
                qorder = "ORDER BY barang_kode LIMIT 500"
                If Not String.IsNullOrWhiteSpace(ParamStr) Then
                    ParamStr = mysqlQueryFriendlyStringFeed(ParamStr)
                    ParamStr = Trim(ParamStr).Replace(" ", ".+").Replace("(", "[(]").Replace(")", "[)]")
                    qwhr = String.Join("'" & ParamStr & "'", {" AND(barang_nama REGEXP ", " OR barang_kode REGEXP ",
                                                              " OR pajak.ref_text REGEXP ", " OR status.ref_text REGEXP ", ")"
                                                             })
                Else
                    qwhr = ""
                End If

                Using dtx = x.GetDataTable(String.Format(q, qwhr + qorder))
                    setDoubleBuffered(dgv_barang_mstr, True)
                    dgv_barang_mstr.AutoGenerateColumns = False
                    dgv_barang_mstr.DataSource = dtx
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Setting Salesman", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'SAVE DATA
    Private Sub SaveData()
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = ""
                Dim qArr As New List(Of String)
                'INSERT DATA GUDANG
                q = "UPDATE data_salesman_gudang SET sg_status=9 WHERE sg_kode_sales='{0}'"
                qArr.Add(String.Format(q, in_sales.Text))
                For Each row As DataGridViewRow In dgv_gudang_slct.Rows
                    q = "INSERT data_salesman_gudang SET {0}"
                    Dim fg = {"sg_kode_gudang='" & row.Cells(0).Value & "'",
                              "sg_kode_sales='" & in_sales.Text & "'",
                              "sg_reg_date=NOW()",
                              "sg_reg_alias='" & loggeduser.user_id & "'"
                             }
                    qArr.Add(String.Format(q, String.Join(",", fg)))
                Next

                'INSERT DATA BARANG
                q = "UPDATE data_salesman_barang SET sb_status=9 WHERE sb_kode_sales='{0}'"
                qArr.Add(String.Format(q, in_sales.Text))
                For Each row As DataGridViewRow In dgv_barang_slct.Rows
                    q = "INSERT data_salesman_barang SET {0} ON DUPLICATE KEY UPDATE sb_status=1"
                    Dim fb = {"sb_kode_barang='" & row.Cells(0).Value & "'",
                              "sb_kode_sales='" & in_sales.Text & "'",
                              "sb_reg_alias='" & loggeduser.user_id & "'",
                              "sb_reg_date=NOW()"
                             }
                    qArr.Add(String.Format(q, String.Join(",", fb)))
                Next

                Dim _ck = x.TransactCommand(qArr)
                If _ck Then
                    MessageBox.Show("Data tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pgsalesbarang}) : Me.Close()
                Else
                    MessageBox.Show("Data gagal tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Setting Salesman", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'ADD ITEM
    Private Sub AddItem(TypeItem As String)
        Dim _sourcedgv, _inputdgv As DataGridView
        Dim _colCount As Integer = 0
        Select Case LCase(TypeItem)
            Case "gudang"
                _sourcedgv = dgv_gudang_mstr
                _inputdgv = dgv_gudang_slct
                _colCount = 2
            Case "barang"
                _sourcedgv = dgv_barang_mstr
                _inputdgv = dgv_barang_slct
                _colCount = 3
            Case Else : Exit Sub
        End Select

        _inputdgv.ClearSelection()
        For Each source As DataGridViewRow In _sourcedgv.SelectedRows
            Dim _kode As String = source.Cells(0).Value
            Dim _addItem As Boolean = True
            For Each inpt As DataGridViewRow In _inputdgv.Rows
                If _kode = inpt.Cells(0).Value Then
                    _addItem = False : inpt.Selected = True
                    Exit For
                End If
            Next
            If _addItem Then
                With _inputdgv
                    Dim i = .Rows.Add
                    For ss = 0 To _colCount : .Rows(i).Cells(ss).Value = source.Cells(ss).Value : Next
                    .Rows(i).Selected = True
                End With
            End If
        Next
        _sourcedgv.ClearSelection()
    End Sub

    'REMOVE ITEM
    Private Sub RemItem(TypeItem As String)
        Dim _sourcedgv As DataGridView
        Dim _idx As New List(Of Integer)
        Select Case LCase(TypeItem)
            Case "gudang" : _sourcedgv = dgv_gudang_slct
            Case "barang" : _sourcedgv = dgv_barang_slct
            Case Else : Exit Sub
        End Select
        For Each row As DataGridViewRow In _sourcedgv.SelectedRows : _idx.Add(row.Index) : Next
        For Each i As Integer In _idx : _sourcedgv.Rows.RemoveAt(i) : Next
        _sourcedgv.ClearSelection()
    End Sub

    'UI :DRAG FORM
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

    'UI : CLOSE
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbeli.PerformClick()
    End Sub

    Private Sub fr_jual_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_batalbeli.PerformClick()
        End If
    End Sub

    'UI : BUTTON
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        SaveData()
    End Sub

    Private Sub bt_cari_gudang_Click(sender As Object, e As EventArgs) Handles bt_cari_gudang.Click, bt_cari_barang.Click
        Select Case sender.Name
            Case "bt_cari_gudang" : GetTableGudang(in_cari_gudang.Text)
            Case "bt_cari_barang" : GetTableBarang(in_cari_barang.Text)
        End Select
    End Sub

    Private Sub bt_add_gudang_Click(sender As Object, e As EventArgs) Handles bt_add_gudang.Click, bt_add_brg.Click
        Dim _type As String = ""
        Dim _dgv As DataGridView
        Select Case sender.Name
            Case "bt_add_gudang" : _dgv = dgv_gudang_mstr : _type = "gudang"
            Case "bt_add_brg" : _dgv = dgv_barang_mstr : _type = "barang"
            Case Else : Exit Sub
        End Select
        If _dgv.SelectedRows.Count > 0 Then AddItem(_type)
    End Sub

    Private Sub bt_rem_gudang_Click(sender As Object, e As EventArgs) Handles bt_rem_gudang.Click, bt_rem_brg.Click
        Dim _type As String = ""
        Dim _dgv As DataGridView
        Select Case sender.Name
            Case "bt_rem_gudang" : _dgv = dgv_gudang_slct : _type = "gudang"
            Case "bt_rem_brg" : _dgv = dgv_barang_slct : _type = "barang"
            Case Else : Exit Sub
        End Select

        If _dgv.SelectedRows.Count > 0 Then RemItem(_type)
    End Sub

    Private Sub bt_remall_gudang_Click(sender As Object, e As EventArgs) Handles bt_remall_gudang.Click, bt_remall_brg.Click
        Dim _dgv As DataGridView
        Select Case sender.Name
            Case "bt_remall_gudang" : _dgv = dgv_gudang_slct
            Case "bt_remall_brg" : _dgv = dgv_barang_slct
            Case Else : Exit Sub
        End Select
        If _dgv.RowCount > 0 Then _dgv.Rows.Clear()
    End Sub

    'UI : INPUT
    Private Sub in_cari_gudang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_cari_gudang.KeyUp, in_cari_barang.KeyUp
        If e.KeyCode = Keys.Enter Then
            Select Case sender.Name
                Case "in_cari_gudang" : bt_cari_gudang.PerformClick()
                Case "in_cari_barang" : bt_cari_barang.PerformClick()
            End Select
        End If
    End Sub

    Private Sub dgv_gudang_mstr_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_gudang_mstr.CellDoubleClick, dgv_barang_mstr.CellDoubleClick
        If e.RowIndex > -1 Then
            Select Case sender.Name
                Case "dgv_gudang_mstr" : bt_add_gudang.PerformClick()
                Case "dgv_barang_mstr" : bt_add_brg.PerformClick()
            End Select
        End If
    End Sub

    Private Sub dgv_gudang_slct_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_gudang_slct.CellDoubleClick, dgv_barang_slct.CellDoubleClick
        If e.RowIndex > -1 Then
            Select Case sender.Name
                Case "dgv_gudang_slct" : bt_rem_gudang.PerformClick()
                Case "dgv_barang_slct" : bt_rem_brg.PerformClick()
            End Select
        End If
    End Sub
End Class