Public Class fr_search_export
    Public ReturnId As String = ""
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
        LoadData("")
        ex_supplier.Visible = SupplierBased
        Me.ShowDialog()
    End Sub

    Public Sub DoLoadDialog_Supplier()
        SupplierBased = True
        DoLoadDialog()
    End Sub

    'LOAD DATAGRID
    Private Sub LoadData(Optional param As String = "")
        If MainConnection.Connection Is Nothing Then Throw New NullReferenceException("Main db connection setting is empty.")

        Dim q As String = ""
        Dim _Where As String = ""
        If SupplierBased Then
            q = "SELECT efak_id, DATE_FORMAT(efak_periode,'%M %Y') efak_periode, GetMasterNama('supplier', efak_suppliercode) efak_supplier, " _
                & " efak_tgl, efak_ket, efak_reg_user, efak_lastexport " _
                & "FROM data_penjualan_efak WHERE efak_status<>9 AND efak_supplierbased=1 {0}"
            _Where = "AND (DATE_FORMAT(efak_periode,'%M %Y') LIKE '{0}' OR CONVERT(efak_id,CHAR(11)) LIKE '{0}' OR efak_suppliercode LIKE '{0}' OR GetMasterNama('supplier', efak_suppliercode) LIKE '{0}')"
        Else
            q = "SELECT efak_id, DATE_FORMAT(efak_periode,'%M %Y') efak_periode, efak_tgl, efak_ket, efak_reg_user, efak_lastexport " _
                & "FROM data_penjualan_efak WHERE efak_status<>9 AND efak_supplierbased=0 {0}"
            _Where = "AND (DATE_FORMAT(efak_periode,'%M %Y') LIKE '{0}' OR CONVERT(efak_id,CHAR(11)) LIKE '{0}')"
        End If
        If Not String.IsNullOrWhiteSpace(param) Then
            param = "%" & param & "%"
            _Where = String.Format(_Where, param)
            q = String.Format(q, _Where)
        Else
            q = String.Format(q, "")
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Using dtx = x.GetDataTable(q)
                    dgv_listexport.DataSource = dtx
                End Using
            End If
        End Using
    End Sub

    'UI : BUTTON
    Private Sub bt_cari_Click(sender As Object, e As EventArgs) Handles bt_cari.Click
        If Not String.IsNullOrWhiteSpace(in_cari.Text) Then
            LoadData(in_cari.Text)
        End If
    End Sub

    Private Sub bt_load_Click(sender As Object, e As EventArgs) Handles bt_load.Click
        ReturnId = dgv_listexport.SelectedRows.Item(0).Cells("ex_id").Value
        Me.Close()
    End Sub

    'UI : DGV
    Private Sub dgv_listexport_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listexport.CellDoubleClick
        bt_load.PerformClick()
    End Sub

    'UI : TEXTBOX
    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyCode = Keys.Enter Then
            bt_cari.PerformClick()
        End If
    End Sub
End Class