Public Class fr_exportaddfaktur
    Public ReturnValue As Boolean = False
    Private IdExport As String = ""

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
        Me.ShowDialog(main)
    End Sub

    'ADD FAKTUR TO EXPORT TEMPLATE
    Private Sub ProcAddFaktur()
        Dim Result As Boolean = False
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

            Result = AddFaktur(Me.IdExport, dt)

        ElseIf ck_range.Checked Then
            Result = AddFaktur(Me.IdExport, date_tglawal.Value, date_tglakhir.Value)
        Else
            MessageBox.Show("Tidak ada yg terpilih", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Result Then
            MessageBox.Show("Faktur berhasil ditambahkan.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ReturnValue = True : Me.Close()
        End If
    End Sub

    Private Function AddFaktur(IdExport As String, DataTableInput As DataTable, Optional RowAffected As Integer = 0) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim _retVal As Boolean = False
        Dim q As String = "INSERT INTO data_penjualan_efak_list(e_list_templateid, e_list_kodefaktur, e_list_kodepajak, e_list_tglpajak, e_list_selectstate) " _
                          & "SELECT {0}, faktur_kode, faktur_pajak_no, faktur_pajak_tanggal, 1 " _
                          & "FROM data_penjualan_faktur WHERE faktur_kode='{1}' " _
                          & "ON DUPLICATE KEY UPDATE e_list_selectstate=1, e_list_status=1, e_list_kodepajak=faktur_pajak_no, e_list_tglpajak=faktur_pajak_tanggal"

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Dim i As Integer = 0
                For Each row As DataRow In DataTableInput.Rows
                    q = String.Format(q, IdExport, row.ItemArray(0))
                    i += x.ExecCommand(q)
                Next
                RowAffected = i
                If RowAffected = 0 Then
                    _retVal = False : MessageBox.Show("Tidak ada data ditambahkan.", "Export Efaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Function AddFaktur(IdExport As String, StartDate As Date, EndDate As Date, Optional RowAffected As Integer = 0) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim _retVal As Boolean = False
        Dim q As String = "INSERT INTO data_penjualan_efak_list(e_list_templateid, e_list_kodefaktur, e_list_kodepajak, e_list_tglpajak, e_list_selectstate) " _
                          & "SELECT {0}, faktur_kode, faktur_pajak_no, faktur_pajak_tanggal, 1 " _
                          & "FROM data_penjualan_faktur WHERE faktur_tanggal_trans BETWEEN '{1}' AND '{2}' AND faktur_status=1 AND faktur_ppn_jenis IN ('1','2') " _
                          & "ON DUPLICATE KEY UPDATE e_list_selectstate=1, e_list_status=1, e_list_kodepajak=faktur_pajak_no, e_list_tglpajak=faktur_pajak_tanggal"
        Dim _tglAwal As String = StartDate.ToString("yyyy-MM-dd")
        Dim _tglAkhir As String = EndDate.ToString("yyyy-MM-dd")

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                RowAffected = x.ExecCommand(String.Format(q, IdExport, _tglAwal, _tglAkhir))
                If RowAffected = 0 Then
                    _retVal = False : MessageBox.Show("Tidak ada data ditambahkan.", "Export Efaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    _retVal = True
                End If
            Else
                _retVal = False : MessageBox.Show("Tidak dapat terhubung ke server.", "Export Efaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using

        Return _retVal
    End Function

    'UI : BUTTON
    Private Sub bt_list_addfak_Click(sender As Object, e As EventArgs) Handles bt_list_addfak.Click

    End Sub

    Private Sub bt_list_delfak_Click(sender As Object, e As EventArgs) Handles bt_list_delfak.Click
        If dgv_listfak.RowCount > 0 Then
            For Each row As DataGridViewRow In dgv_listfak.SelectedRows
                dgv_listfak.Rows.RemoveAt(row.Index)
            Next
        End If
    End Sub

    Private Sub bt_load_Click(sender As Object, e As EventArgs) Handles bt_load.Click
        If ck_list.Checked = False And ck_range.Checked = False Then
            MessageBox.Show("Tidak ada faktur terpilih.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ProcAddFaktur()
    End Sub

    'UI : CHECKBOX
    Private Sub ck_list_CheckedChanged(sender As Object, e As EventArgs) Handles ck_list.CheckedChanged
        Dim _ck As Boolean = ck_list.Checked
        ck_range.Checked = Not ck_list.Checked
        For Each x As Control In {dgv_listfak, bt_list_addfak, bt_list_delfak}
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
End Class