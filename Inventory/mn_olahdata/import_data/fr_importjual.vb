Public Class fr_importjual
    Private selectedimport As String = ""
    Private SuccID As New List(Of String)

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
    Private Sub fr_lap_filter_jual_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim _dialogres As Windows.Forms.DialogResult = MessageBox.Show("Tutup Form?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _dialogres = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub fr_pesan_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            bt_cl.PerformClick()
        End If
    End Sub

    '
    Private Sub addData(path As String, Optional hasheader As Boolean = True)
        Dim dt As New DataTable

        ck_faktur_all.Checked = False
        dt = GetDataTablefromExcel(path, hasheader)

        If IsNothing(dt) = False Then
            dgv_ckImport.DataSource = dt
        End If
    End Sub

    Private Function CekColumn(type As String, DataImport As DataTable) As Boolean

        Select Case type

        End Select

        Return False
    End Function

    Private Function importData(type As String) As KeyValuePair(Of Boolean, String)
        Dim _dt As New DataTable

        For i = 1 To dgv_ckImport.Columns.Count - 1
            _dt.Columns.Add(dgv_ckImport.Columns(i).Name)
            consoleWriteLine(_dt.Columns(i - 1).ColumnName)
        Next

        For Each row As DataGridViewRow In dgv_ckImport.Rows
            If row.Cells(0).Value = 1 Then
                Dim _arr(dgv_ckImport.Columns.Count - 2) As String
                For i = 1 To dgv_ckImport.Columns.Count - 1
                    _arr(i - 1) = IIf(IsDBNull(row.Cells(i).Value), "", row.Cells(i).Value)
                Next
                _dt.Rows.Add(_arr)
            End If
        Next

        If _dt.Rows.Count = 0 Then Return New KeyValuePair(Of Boolean, String)(False, "Tidak ada data yang terpilih.")
        SuccID = New List(Of String)
        Select Case type
            Case "barang"
                Return DoImportBarang(_dt, SuccID)
            Case "beli"
                Return DoImportPembelian(GetImportBeli(_dt, 1), GetImportBeli(_dt, 2), SuccID)
            Case "jual"
                Return DoImportPenjualan(GetImportJual(_dt, 1), GetImportJual(_dt, 2), SuccID)
            Case "returjual"
                Return DoImportReturJual(GetImportRetur(_dt, 1), GetImportRetur(_dt, 2), SuccID)
            Case "piutang"
                Return DoImportPiutangPajak(_dt)
            Case "piutang2"
                Return DoImportPiutangNonPajak(_dt)
            Case Else
                Return New KeyValuePair(Of Boolean, String)(False, "Type import data tidak sesuai.")
        End Select
    End Function

    Private Function loadCombo() As DataTable
        Dim dt As New DataTable

        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        dt.Rows.Add("Master Barang", "barang")
        dt.Rows.Add("Pembelian", "beli")
        dt.Rows.Add("Retur Pembelian", "returbeli")
        dt.Rows.Add("Penjualan", "jual")
        dt.Rows.Add("Retur Penjualan", "returjual")
        dt.Rows.Add("Piutang Awal (Pajak)", "piutang")
        dt.Rows.Add("Piutang Awal (Non-Pajak)", "piutang2")
        dt.Rows.Add("Hutang Awal", "hutang")

        Return dt
    End Function

    'LOAD
    Private Sub fr_lap_filter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_dataselect
            .DataSource = loadCombo()
            .ValueMember = "Value"
            .DisplayMember = "Text"
            selectedimport = .SelectedValue
        End With
        setDoubleBuffered(dgv_ckImport, True)
    End Sub

    'BUTTON
    Private Sub bt_import_Click(sender As Object, e As EventArgs) Handles bt_openfile.Click
        Dim _opfiledialog As New OpenFileDialog
        _opfiledialog.Title = "Pilih file..."
        _opfiledialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        _opfiledialog.FilterIndex = 1
        If _opfiledialog.ShowDialog = DialogResult.OK Then
            If _opfiledialog.FileName <> Nothing Then
                Me.Cursor = Cursors.WaitCursor
                addData(_opfiledialog.FileName)
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_import.Click
        Dim datatab As TabPage()
        Dim msg As String = "Import data {0}?"

        If cb_dataselect.SelectedValue = Nothing Then
            Exit Sub
        End If

        If dgv_ckImport.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data untuk di import")
            Exit Sub
        End If

        Select Case cb_dataselect.SelectedValue
            Case "barang"
                msg = String.Format(msg, "barang")
                datatab = {pgbarang}
            Case "hutang"
                msg = String.Format(msg, "hutang awal")
                datatab = {pghutangawal}
            Case "beli"
                msg = String.Format(msg, "pembelian")
                datatab = {pgpembelian, pghutangawal}
            Case "returbeli"
                msg = String.Format(msg, "retur pembelian")
                datatab = {pgreturbeli}
            Case "piutang", "piutang2"
                msg = String.Format(msg, "piutang awal")
                datatab = {pgpiutangawal}
            Case "jual"
                msg = String.Format(msg, "penjualan")
                datatab = {pgpenjualan, pgpiutangawal}
            Case "returjual"
                msg = String.Format(msg, "retur penjualan")
                datatab = {pgreturjual}
            Case Else
                Exit Sub
        End Select


        If MessageBox.Show(msg, "Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            Dim x = importData(cb_dataselect.SelectedValue)
            MessageBox.Show(x.Value, Me.Text, MessageBoxButtons.OK, IIf(x.Key, MessageBoxIcon.Information, MessageBoxIcon.Error))
            If x.Key Then  doRefreshTab(datatab)

            If SuccID.Count > 0 Then
                For Each _ID As String In SuccID
                    For Each row As DataGridViewRow In dgv_ckImport.Rows
                        If row.Cells(1).Value = _ID Then row.Cells(0).Value = 0
                    Next
                Next
            End If

            Me.Cursor = Cursors.Default
        End If
    End Sub

    'DGV CHECKBOX
    Private Sub ck_faktur_all_CheckStateChanged(sender As Object, e As EventArgs) Handles ck_faktur_all.CheckedChanged
        If ck_faktur_all.CheckState = CheckState.Checked Then
            For Each rows As DataGridViewRow In dgv_ckImport.Rows
                rows.Cells(0).Value = 1
            Next
        ElseIf ck_faktur_all.CheckState = CheckState.Unchecked Then
            For Each rows As DataGridViewRow In dgv_ckImport.Rows
                rows.Cells(0).Value = 0
            Next
        End If
    End Sub

    Private Sub dgv_faktur_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ckImport.CellValueChanged
        If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
            Dim count As Integer = 0
            For Each rows As DataGridViewRow In dgv_ckImport.Rows
                If rows.Cells(0).Value = 1 Then
                    count += 1
                End If
            Next

            If count = 0 Then
                ck_faktur_all.CheckState = CheckState.Unchecked
            ElseIf count > 0 And dgv_ckImport.Rows.Count > count Then
                ck_faktur_all.CheckState = CheckState.Indeterminate
            ElseIf count > 0 And count = dgv_ckImport.Rows.Count Then
                ck_faktur_all.CheckState = CheckState.Checked
            End If
        End If
    End Sub

    Private Sub dgv_faktur_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_ckImport.CellMouseUp
        If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
            dgv_ckImport.EndEdit()
        End If
    End Sub

    'COMBOBOX
    Private Sub cb_dataselect_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_dataselect.SelectionChangeCommitted
        If dgv_ckImport.Rows.Count <> 0 And selectedimport <> cb_dataselect.SelectedValue Then
            If MessageBox.Show("Ubah import?", "Import Data", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                selectedimport = cb_dataselect.SelectedValue
                dgv_ckImport.DataSource = Nothing
            Else
                cb_dataselect.SelectedValue = selectedimport
            End If
        ElseIf dgv_ckImport.Rows.Count = 0 Then
            selectedimport = cb_dataselect.SelectedValue
        End If
    End Sub

End Class