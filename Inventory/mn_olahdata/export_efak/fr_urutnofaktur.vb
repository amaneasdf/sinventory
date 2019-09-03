Public Class fr_urutnofaktur
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
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = "SELECT COUNT(DISTINCT e_list_kodefaktur) FROM data_penjualan_efak_list " _
                                  & "WHERE e_list_status=1 AND e_list_selectstate=1 AND e_list_templateid='{0}'"
                in_jmlpajak.Value = CInt(x.ExecScalar(String.Format(q, IdExport)))
            End If
        End Using

        Me.IdExport = IdExport
        Me.ShowDialog(main)
    End Sub

    'SET NOMOR PAJAK
    Private Function SetNomorPajak(IdExport As String, StartCode As String, FakturAmount As Integer, Optional ByRef RowAffected As Integer = 0) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim _retval As Boolean = False
        Dim q As String = "CALL EFak_SetKodePajakJual('{0}','{1}',{2})"
        q = String.Format(q, IdExport, StartCode, FakturAmount)

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    RowAffected = x.ExecCommand(q)
                    _retval = True
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Terjadi kesalahan saat melakukan pengurutan nomor pajak." & Environment.NewLine & ex.Message,
                                    "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    _retval = False
                End Try
            Else
                _retval = False
                MessageBox.Show("Tidak dapat terhubung ke database.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

        Return _retval
    End Function

    'UI : BUTTON
    Private Sub bt_load_Click(sender As Object, e As EventArgs) Handles bt_load.Click
        in_nopajak.Text = Trim(in_nopajak.Text)

        If String.IsNullOrWhiteSpace(in_nopajak.Text) Then
            MessageBox.Show("Masukan No. Pajak awal terlebih dulu", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Else
            If Not in_nopajak.Text Like "###.###-##.########" Then
                MessageBox.Show("Format No. Pajak tidak sesuai", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If

        If in_jmlpajak.Value = 0 Then
            MessageBox.Show("Masukan jumlah faktur terlabih dahulu", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim _ct As Integer = 0
        Me.Cursor = Cursors.WaitCursor
        If SetNomorPajak(Me.IdExport, in_nopajak.Text, in_jmlpajak.Value, _ct) Then
            consoleWriteLine(_ct)
            ReturnValue = True : Me.Close()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    'UI : NUMERIC
    Private Sub in_jmlpajak_Enter(sender As Object, e As EventArgs) Handles in_jmlpajak.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_jmlpajak_Leave(sender As Object, e As EventArgs) Handles in_jmlpajak.Leave
        numericLostFocus(sender, "N0")
    End Sub

    Private Sub in_jmlpajak_KeyPress(sender As Object, e As KeyEventArgs) Handles in_jmlpajak.KeyDown
        keyshortenter(bt_load, e)
    End Sub

    'UI : TEXTBOX
    Private Sub in_nopajak_KeyPress(sender As Object, e As KeyEventArgs) Handles in_nopajak.KeyDown
        keyshortenter(in_jmlpajak, e)
    End Sub
End Class