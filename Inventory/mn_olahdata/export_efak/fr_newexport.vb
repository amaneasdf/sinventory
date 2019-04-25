Public Class fr_newexport
    Public ReturnId As String = ""

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
        Me.Close()
        'End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_cancel.PerformClick()
    End Sub

    'LOAD FORM
    Public Sub DoLoadDialog()
        Me.ShowDialog(main)
    End Sub

    'CREATE EXPORT
    Private Function CreateExportTemplate() As String
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim _RetVal As String = ""
        Dim q As String = ""
        Dim _periode As String = date_periode.Value.ToString("yyyy-MM-01")

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "INSERT INTO data_penjualan_efak SET efak_tgl=CURDATE(), efak_periode='{0}', efak_reg_user='{1}', efak_reg_date=NOW(); " _
                    & "SELECT LAST_INSERT_ID();"
                q = String.Format(q, _periode, loggeduser.user_id)
                Dim _id As String = CStr(x.ExecScalar(q))
                Dim _count As Integer = 0
                If Not String.IsNullOrWhiteSpace(_id) Then
                    q = "INSERT INTO data_penjualan_efak_list(e_list_templateid,e_list_kodefaktur,e_list_kodepajak,e_list_tglpajak,e_list_selectstate) " _
                        & "SELECT '{0}',faktur_kode, faktur_pajak_no, faktur_pajak_tanggal,1 FROM data_penjualan_faktur " _
                        & "WHERE faktur_status=1 AND faktur_ppn_jenis IN (1,2) AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' " _
                        & "ORDER BY faktur_tanggal_trans"
                    If ck_inputfaktur.Checked Then
                        _count = x.ExecCommand(String.Format(q, _id, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd")))
                        MessageBox.Show(_count & " faktur telah ditambahkan.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    _RetVal = _id
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

        Return _RetVal
    End Function

    'CHECK EXPORT
    Private Function CheckExport(Periode As Date) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim q As String = ""
        Dim _retval As Boolean = False
        Dim _periode As String = Periode.ToString("MMyyyy")
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT COUNT(efak_id) FROM data_penjualan_efak WHERE efak_status=1 AND DATE_FORMAT(efak_periode,'%m%Y')='{0}'"
                Dim count As Integer = CInt(x.ExecScalar(String.Format(q, _periode)))
                If count > 0 Then
                    Dim _msgRes As DialogResult = MessageBox.Show("Data export untuk periode " & Periode.ToString("MMMM yyyy") & " sudah ada, lanjutakan pembuatan export?",
                                                                  "Export EFaktur", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If _msgRes = Windows.Forms.DialogResult.Yes Then _retval = True
                ElseIf count = 0 Then
                    _retval = True
                Else
                    _retval = False
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

        Return _retval
    End Function

    'UI : BUTTON
    Private Sub bt_load_Click(sender As Object, e As EventArgs) Handles bt_load.Click
        If Not ck_inputfaktur.Checked Then
            If MessageBox.Show("Buat export tanpa menambahkan faktur?", "Export EFaktur",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        If CheckExport(date_periode.Value) Then
            Me.Cursor = Cursors.WaitCursor
            Dim ck = CreateExportTemplate()
            Me.Cursor = Cursors.Default

            If Not String.IsNullOrWhiteSpace(ck) Then : ReturnId = ck : Me.Close() : End If
        End If
    End Sub

    'UI : DATETIME PICKER
    Private Sub date_periode_ValueChanged(sender As Object, e As EventArgs) Handles date_periode.ValueChanged
        date_periode.Value = DateSerial(date_periode.Value.Year, date_periode.Value.Month, 1)
        date_tglawal.Value = DateSerial(date_periode.Value.Year, date_periode.Value.Month, 1)
        date_tglakhir.Value = DateSerial(date_periode.Value.Year, date_periode.Value.Month + 1, 0)
    End Sub

    'UI : CHECKBOX
    Private Sub ck_inputfaktur_CheckedChanged(sender As Object, e As EventArgs) Handles ck_inputfaktur.CheckedChanged
        Dim sw As Boolean = ck_inputfaktur.Checked
        date_tglakhir.Enabled = sw : date_tglakhir.Value = DateSerial(date_periode.Value.Year, date_periode.Value.Month + 1, 0)
        date_tglawal.Enabled = sw : date_tglawal.Value = DateSerial(date_periode.Value.Year, date_periode.Value.Month, 1)
    End Sub
End Class