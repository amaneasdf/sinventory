Public Class fr_newexport
    Public ReturnId As String = ""
    Private PopUpState As String = "supplier"
    Private SupplierBased As Boolean = False

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

    Private Sub fr_piutang_awal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_cancel.PerformClick()
        End If
    End Sub

    'LOAD FORM
    Public Sub DoLoadDialog()
        SetupForm()
        Me.ShowDialog(main)
    End Sub

    Public Sub DoLoadDialog_supplier()
        SupplierBased = True
        DoLoadDialog()
    End Sub

    Private Sub SetupForm()
        For Each ctr As Control In {lbl_supplier, in_supplier, in_suppliernama}
            ctr.Visible = SupplierBased
        Next
        If SupplierBased Then
            ck_inputfaktur.Location = New Point(15, 61)
            lbl_date.Location = New Point(280, 63)
            date_tglawal.Location = New Point(138, 59)
            date_tglakhir.Location = New Point(309, 59)
        Else
            ck_inputfaktur.Location = New Point(15, 61 - 25)
            lbl_date.Location = New Point(280, 63 - 25)
            date_tglawal.Location = New Point(138, 59 - 25)
            date_tglakhir.Location = New Point(309, 59 - 25)
        End If
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "supplier"
                q = "SELECT supplier_kode 'Kode', supplier_nama 'Nama Supplier' FROM data_supplier_master " _
                    & "WHERE supplier_status=1 AND (supplier_nama LIKE '{0}%' OR supplier_kode LIKE '{0}%') LIMIT 250"
            Case Else
                Exit Sub
        End Select

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                dt = x.GetDataTable(String.Format(q, param))
            End If
        End Using

        With dgv_listbarang
            .DataSource = dt
            If dt.Columns.Count >= 2 Then
                .Columns(0).Width = 100 : .Columns(1).Width = 200
                .Columns(.DisplayedColumnCount(False) - 1).AutoSizeMode = IIf(.DisplayedColumnCount(False) <= 3, DataGridViewAutoSizeColumnMode.Fill, DataGridViewAutoSizeColumnMode.NotSet)
            End If
        End With
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case PopUpState
                Case "supplier"
                    in_supplier.Text = .Cells(0).Value
                    in_suppliernama.Text = .Cells(1).Value

                Case Else
                    Exit Sub
            End Select
        End With
    End Sub

    'UI : POPUP PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_suppliernama.Focused Then
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
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dgv_listbarang_KeyUp(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyUp
        If e.KeyCode = Keys.Enter Then
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        PopUpSearchKeyPress(e, in_suppliernama)
    End Sub

    'CREATE EXPORT
    Private Function CreateExportTemplate() As String
        If MainConnection.Connection Is Nothing Then Throw New NullReferenceException("Main Connection is empty")
        If String.IsNullOrWhiteSpace(SupplierBased) Then Return String.Empty

        Dim _RetVal As String = ""
        Dim q As String = ""
        Dim _periode As String = date_periode.Value.ToString("yyyy-MM-01")

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                'CREATE ID TEMPLATE
                If SupplierBased Then
                    q = "SELECT EFak_CreateTemplate_BySupplier('{0}', '{1}', '{2}', '{3}')"
                    q = String.Format(q, _periode, in_supplier.Text, mysqlQueryFriendlyStringFeed(in_ket.Text), loggeduser.user_id)
                Else
                    q = "SELECT EFak_CreateTemplate('{0}', '{1}', '{2}')"
                    q = String.Format(q, _periode, mysqlQueryFriendlyStringFeed(in_ket.Text), loggeduser.user_id)
                End If
                Dim _id As String = CStr(x.ExecScalar(q))

                'INPUT DATA FAKTUR
                Dim _count As Integer = 0
                If Not String.IsNullOrWhiteSpace(_id) Then
                    If ck_inputfaktur.Checked Then
                        If SupplierBased Then
                            q = "SELECT EFak_AddNewFakturByDate_BySupplier({0}, '{1:yyyy-MM-dd}', '{2:yyyy-MM-dd}', '{3}', '{4}')"
                            _count = Integer.Parse(x.ExecScalar(String.Format(q, _id, date_tglawal.Value, date_tglakhir.Value, in_supplier.Text, loggeduser.user_id)))
                        Else
                            q = "SELECT EFak_AddNewFakturByDate({0}, '{1:yyyy-MM-dd}', '{2:yyyy-MM-dd}', '{3}')"
                            _count = Integer.Parse(x.ExecScalar(String.Format(q, _id, date_tglawal.Value, date_tglakhir.Value, loggeduser.user_id)))
                        End If

                        MessageBox.Show(_count & " faktur telah ditambahkan.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    _RetVal = _id
                Else
                    MessageBox.Show("Pembuatan data export gagal.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Export EFaktur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

        Return _RetVal
    End Function

    'CHECK EXPORT
    Private Function CheckExport(Periode As Date) As Boolean
        If MainConnection.Connection Is Nothing Then Throw New NullReferenceException("Main Connection is empty")

        Dim q As String = ""
        Dim _retval As Boolean = False
        Dim _periode As String = Periode.ToString("MMyyyy")
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                If SupplierBased Then
                    q = "SELECT COUNT(efak_id) FROM data_penjualan_efak WHERE efak_status=1 AND DATE_FORMAT(efak_periode,'%m%Y')='{0}' AND efak_suppliercode='{1}'"
                    q = String.Format(q, _periode, in_supplier.Text)
                Else
                    q = "SELECT COUNT(efak_id) FROM data_penjualan_efak WHERE efak_status=1 AND DATE_FORMAT(efak_periode,'%m%Y')='{0}' AND efak_supplierbased=0"
                    q = String.Format(q, _periode)
                End If
                Dim count As Integer = CInt(x.ExecScalar(q))
                If count > 0 Then
                    Dim _msgRes As DialogResult
                    If SupplierBased Then
                        _msgRes = MessageBox.Show("Data export untuk periode " & Periode.ToString("MMMM yyyy") & " supplier " & in_suppliernama.Text & " sudah ada, lanjutakan pembuatan export?", "Export EFaktur", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Else
                        _msgRes = MessageBox.Show("Data export untuk periode " & Periode.ToString("MMMM yyyy") & " sudah ada, lanjutakan pembuatan export?",
                                                  "Export EFaktur", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    End If
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

    '------------ INPUT
    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        keyshortenter(in_suppliernama, e)
    End Sub

    Private Sub in_suppliernama_Enter(sender As Object, e As EventArgs) Handles in_suppliernama.Enter
        If sender.Enabled And sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(sender.Left - (popPnl_barang.Width - sender.Width), sender.Top + sender.Height)
            If popPnl_barang.Visible = False Then popPnl_barang.Visible = True
            PopUpState = "supplier"
            loadDataBRGPopup(PopUpState, sender.Text)
        End If
    End Sub

    Private Sub in_suppliernama_Leave(sender As Object, e As EventArgs) Handles in_suppliernama.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_suppliernama_KeyDown(sender As Object, e As KeyEventArgs) Handles in_suppliernama.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then e.SuppressKeyPress = True
    End Sub

    Private Sub in_suppliernama_KeyUp(sender As Object, e As KeyEventArgs) Handles in_suppliernama.KeyUp
        Dim _x = PopUpSearchInputHandle_inputKeyup(e, sender, in_supplier, popPnl_barang, dgv_listbarang)
        For Each _resp As String In _x
            Select Case _resp
                Case "set" : setPopUpResult()
                Case "next" : keyshortenter(ck_inputfaktur, e)
                Case "load" : loadDataBRGPopup(PopUpState, sender.Text)
            End Select
        Next
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