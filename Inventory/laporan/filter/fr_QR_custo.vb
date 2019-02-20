Public Class fr_QR_custo
    Private QRCodeData As String = "custo"

    'LOAD COLUMN
    Private Sub loadDGVColumns()

    End Sub

    'CREATE QUERY
    Private Function createQuery()
        Dim retval As String = ""
        Dim qcusto As String = "SELECT customer_kode, customer_nama, IF(IFNULL(customer_alamat,'')='', " _
                               & "IF((@temp:=CONCAT_WS(' , ', customer_kecamatan,customer_kabupaten))=' , ','-',@temp), " _
                               & "customer_alamat) customer_alamat FROM data_customer_master {0}"
        Dim qwhr As String = "WHERE {0}"

        Select Case QRCodeData
            Case "custo"
                If rb_allcode.Checked = True Then
                    qwhr = ""
                ElseIf rb_range.Checked = True Then
                    Dim _kodeawal As String = IIf(UCase(Strings.Left(in_kodeawal.Text, 2)) = "CT", Strings.Mid(in_kodeawal.Text, 3), in_kodeawal.Text)
                    Dim _kodeakhir As String = IIf(UCase(Strings.Left(in_kodeakhir.Text, 2)) = "CT", Strings.Mid(in_kodeakhir.Text, 3), in_kodeakhir.Text)
                    Dim _isAwalNull As Boolean = String.IsNullOrWhiteSpace(_kodeawal)
                    Dim _isAkhirNull As Boolean = String.IsNullOrWhiteSpace(_kodeakhir)
                    Dim _inkodeawal, _inkodeakhir As Integer
                    If Integer.TryParse(_kodeawal, _inkodeawal) Then
                        _kodeawal = _inkodeawal
                    Else
                        _kodeawal = "'" & _kodeawal & "'"
                    End If
                    If Integer.TryParse(_kodeakhir, _inkodeakhir) Then
                        _kodeakhir = _inkodeakhir
                    Else
                        _kodeakhir = "'" & _kodeakhir & "'"
                    End If

                    If _isAkhirNull And _isAwalNull = False Then
                        qwhr = String.Format(qwhr, "customer_kode LIKE 'CT%' AND MID(customer_kode,3)>=" & _kodeawal)
                    ElseIf Not _isAwalNull And Not _isAkhirNull Then
                        qwhr = String.Format(qwhr, "customer_kode LIKE 'CT%' AND MID(customer_kode,3) BETWEEN " & _kodeawal & " AND " & _kodeakhir)
                    ElseIf _isAwalNull And _isAkhirNull = False Then
                        qwhr = String.Format(qwhr, "customer_kode LIKE 'CT%' AND MID(customer_kode,3)<=" & _kodeakhir)
                    End If

                ElseIf rb_selected.Checked = True Then
                    Dim _selectkode As New List(Of String)
                    For Each row As DataGridViewRow In dgv_selectedcode.Rows
                        Dim _kode As String = "'" & row.Cells(0).Value & "'"
                        _selectkode.Add(_kode)
                    Next
                    qwhr = String.Format(qwhr, "customer_kode IN (" & String.Join(",", _selectkode) & ")")
                Else
                    qcusto = "{0}"
                    qwhr = ""
                End If
                retval = String.Format(qcusto, qwhr)
        End Select

        consoleWriteLine(retval)
        Return retval
    End Function

    'LOAD DATA DGV
    Private Sub loadDGV(param As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection configuration is empty")
        End If

        Dim dt As New DataTable
        Dim q As String = ""

        Select Case QRCodeData
            Case "custo"
                q = "SELECT customer_kode kode, customer_nama nama FROM data_customer_master WHERE customer_kode LIKE '%{0}%' OR customer_nama LIKE '%{0}%' LIMIT 250"
            Case Else
                Exit Sub
        End Select

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                dt = x.GetDataTable(String.Format(q, param))
            End If
        End Using

        dgv_viewcode.DataSource = dt

    End Sub

    'LOAD REPORT
    Private Sub loadReport()
        Dim dt As New DataTable
        Dim _tempdt As New DataTable
        Dim _repID As String = ""
        Select Case QRCodeData
            Case "custo"
                dt.Columns.Add("cust_kode", GetType(String))
                dt.Columns.Add("cust_qr", GetType(Byte()))
                dt.Columns.Add("cust_nama", GetType(String))
                dt.Columns.Add("cust_alamat", GetType(String))

                Using z = MainConnection : z.Open()
                    If z.ConnectionState = ConnectionState.Open Then
                        For Each row As DataRow In z.GetDataTable(createQuery).Rows
                            Dim kode As String = row.ItemArray(0)
                            Dim qr As Bitmap = createQR(kode, 250, 4)
                            Dim _ms As New System.IO.MemoryStream

                            qr.Save(_ms, System.Drawing.Imaging.ImageFormat.Bmp)

                            dt.Rows.Add(kode, _ms.ToArray, row.ItemArray(1), row.ItemArray(2))
                        Next
                    End If
                End Using

                _repID = "m_custo_qr"
            Case Else
                Exit Sub
        End Select

        Dim x As New fr_lap_master
        x.setVar(_repID, dt)
        x.do_load()
        x.ShowDialog()
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.Close()
    End Sub

    'LOAD
    Public Sub do_load(Optional QRdata As String = "custo")
        QRCodeData = QRdata
    End Sub

    'UI : RADIO BUTTON
    Private Sub rb_range_CheckedChanged(sender As Object, e As EventArgs) Handles rb_range.CheckedChanged
        gb_range.Enabled = rb_range.Checked
    End Sub

    Private Sub rb_selected_CheckedChanged(sender As Object, e As EventArgs) Handles rb_selected.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        gb_selected.Enabled = rb_selected.Checked
        If rb_selected.Checked = True Then loadDGV(in_search.Text)
        Me.Cursor = Cursors.Default
    End Sub

    'UI : BUTTON
    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_close.Click
        bt_cl.PerformClick()
    End Sub

    Private Sub bt_print_Click(sender As Object, e As EventArgs) Handles bt_print.Click
        If rb_selected.Checked And dgv_selectedcode.RowCount <= 0 Then
            MessageBox.Show("Tidak ada data yg terpilih")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor : loadReport() : Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_search_Click(sender As Object, e As EventArgs) Handles bt_search.Click
        loadDGV(in_search.Text)
    End Sub

    Private Sub bt_addcode_Click(sender As Object, e As EventArgs) Handles bt_addcode.Click
        If dgv_viewcode.SelectedRows.Count <= 0 Then
            Exit Sub
        End If

        dgv_selectedcode.ClearSelection()

        With dgv_viewcode
            For Each rows As DataGridViewRow In .SelectedRows
                Dim add As Boolean = True
                Dim i As Integer = 0
                For Each getdata As DataGridViewRow In dgv_selectedcode.Rows
                    If rows.Cells(0).Value = getdata.Cells(0).Value Then
                        i = getdata.Index
                        add = False
                        Exit For
                    End If
                Next

                If add Then i = dgv_selectedcode.Rows.Add(rows.Cells(0).Value, rows.Cells(1).Value)
                dgv_selectedcode.Rows(i).Selected = True
            Next
            .ClearSelection()
        End With
    End Sub

    Private Sub bt_remvcode_Click(sender As Object, e As EventArgs) Handles bt_remvcode.Click
        If dgv_selectedcode.SelectedRows.Count <= 0 Then
            Exit Sub
        End If
        For Each selected As DataGridViewRow In dgv_selectedcode.SelectedRows
            dgv_selectedcode.Rows.RemoveAt(selected.Index)
        Next
    End Sub

    Private Sub dgv_viewcode_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_viewcode.CellDoubleClick
        bt_addcode.PerformClick()
    End Sub

    Private Sub dgv_selectedcode_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_selectedcode.CellDoubleClick
        bt_remvcode.PerformClick()
    End Sub

    'UI : TEXTBOX
    Private Sub in_search_KeyDown(sender As Object, e As KeyEventArgs) Handles in_search.KeyDown, in_kodeawal.KeyDown, in_kodeakhir.KeyDown
        Dim _nm As String = sender.Name.ToString
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Select Case _nm
                Case "in_search"
                    bt_search.PerformClick()
                Case "in_kodeawal"
                    in_kodeakhir.Focus()
                Case "in_kodeakhir"
                    bt_print.PerformClick()
            End Select
        End If
    End Sub
End Class