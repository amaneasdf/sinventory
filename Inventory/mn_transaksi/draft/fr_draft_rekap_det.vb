Public Class fr_draft_rekap_det
    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
        View
    End Enum

    Private Sub SetupForm(IdDraft As String, FormState As InputState, AllowEdit As Boolean)
        Me.formstate = FormState

        setDoubleBuffered(dgv_draftsales, True)
        setDoubleBuffered(dgv_draftfaktur, True)
        setDoubleBuffered(dgv_listfaktur, True)
        setDoubleBuffered(dgv_sales, True)

        LoadDataGridSales()
        list_tanggal.DefaultCellStyle = dgvstyle_date
        list_netto.DefaultCellStyle = dgvstyle_currency
        draft_netto.DefaultCellStyle = dgvstyle_currency

        lbl_count_faktur.Text = "0 Faktur"
        lbl_count_sales.Text = "0 Sales"

        date_faktur_awal.Enabled = False
        date_faktur_akhir.Enabled = False
        For Each dt As DateTimePicker In {date_faktur_akhir, date_faktur_awal, date_tgl_trans}
            dt.MinDate = selectperiode.tglawal
            dt.MaxDate = selectperiode.tglakhir
        Next

        If Not FormState = InputState.Insert Then
            in_kode_draft.ReadOnly = True
            LoadData(IdDraft)
        End If

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowEdit As Boolean)
        date_tgl_trans.Enabled = AllowEdit
        mn_save.Enabled = AllowEdit
        mn_cancelorder.Enabled = AllowEdit
        For Each bt As Button In {bt_addsales, bt_remsales, bt_faktur_all, bt_faktur_clear, bt_addfaktur, bt_remfaktur, bt_simpanreturbeli}
            bt.Enabled = AllowEdit
        Next
    End Sub

    Public Sub DoLoadNew()
        SetupForm("", InputState.Insert, True)
        Me.Show(main)
    End Sub

    Public Sub DoLoadEdit(IdDraft As String, AllowEdit As Boolean)
        If Not AllowEdit Then : DoLoadView(IdDraft) : Exit Sub : End If
        SetupForm(IdDraft, InputState.Edit, AllowEdit)
        Me.Show(main)
    End Sub

    Public Sub DoLoadView(IdDraft As String)
        SetupForm(IdDraft, InputState.View, False)
        Me.Show(main)
        bt_batalreturbeli.Focus()
    End Sub

    'LOAD DATA
    Private Sub LoadData(IdDraft As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Dim q As String = ""

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                in_kode_draft.Text = IdDraft
                q = "SELECT draft_tanggal FROM data_draft_faktur WHERE draft_kode = '{0}' AND draft_status<9"
                date_tgl_trans.Value = CDate(x.ExecScalar(String.Format(q, IdDraft)))

                q = "CALL viewDraft('{0}', 'sales')"
                Using dtx = x.GetDataTable(String.Format(q, IdDraft))
                    For Each row As DataRow In dtx.Rows
                        With dgv_draftsales.Rows
                            Dim i = .Add()
                            .Item(i).Cells(0).Value = row.ItemArray(0)
                            .Item(i).Cells(1).Value = row.ItemArray(1)
                        End With
                    Next
                End Using
                LoadDataGridFaktur()
                lbl_count_sales.Text = String.Format("{0} Sales", dgv_draftsales.RowCount)

                q = "CALL viewDraft('{0}', 'faktur')"
                Using dtx = x.GetDataTable(String.Format(q, IdDraft))
                    For Each row As DataRow In dtx.Rows
                        With dgv_draftfaktur.Rows
                            Dim i = .Add()
                            .Item(i).Cells(0).Value = row.ItemArray(2)
                            .Item(i).Cells(1).Value = row.ItemArray(0)
                            .Item(i).Cells(2).Value = row.ItemArray(4)
                            .Item(i).Cells(3).Value = row.ItemArray(5)
                        End With
                    Next
                End Using
                lbl_count_faktur.Text = dgv_draftfaktur.RowCount & " Faktur"
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'LOAD DGV
    Private Sub LoadDataGridSales(Optional ParamString As String = "")
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Dim q As String = ""

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                setDoubleBuffered(dgv_sales, True)
                q = "SELECT salesman_kode, salesman_nama FROM data_salesman_master WHERE salesman_status<9"
                If Not String.IsNullOrWhiteSpace(ParamString) Then
                    Dim _param As String = Trim(ParamString).Replace(" ", ".+")
                    q += String.Format(" AND(salesman_kode REGEXP '{0}' OR salesman_nama REGEXP '{0}')", _param)
                End If
                dgv_sales.DataSource = x.GetDataTable(q & " LIMIT 250")
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

    End Sub

    Private Sub LoadDataGridFaktur(Optional ParamStr As String = "")
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Dim q As String = ""
        Dim _listSales As New List(Of String)
        Dim _tglawal As Date = date_faktur_awal.Value
        Dim _tglakhir As Date = date_faktur_akhir.Value

        If dgv_draftsales.RowCount > 0 Then
            For Each row As DataGridViewRow In dgv_draftsales.Rows
                _listSales.Add("'" & row.Cells(0).Value & "'")
            Next
        Else
            Exit Sub
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                setDoubleBuffered(dgv_listfaktur, True)
                q = "SELECT faktur_kode as kode, GetMasterNama('custo',faktur_customer) as nama, GetMasterNama('custoalamat2',faktur_customer) alamat, " _
                    & "faktur_tanggal_trans,faktur_netto, IF(IFNULL(faktur_draft_rekap,'')='','N',faktur_draft_rekap) as faktur_draft_rekap, salesman_nama " _
                    & "FROM data_penjualan_faktur " _
                    & "LEFT JOIN data_salesman_master ON faktur_sales=salesman_kode " _
                    & "WHERE faktur_sales IN ({0}) AND faktur_status=1"
                q = String.Format(q, String.Join(",", _listSales))
                If ck_tgl2.Checked Then
                    q += String.Format("  AND faktur_tanggal_trans BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}' ", _tglawal, _tglakhir)
                End If
                If Not String.IsNullOrWhiteSpace(ParamStr) Then
                    ParamStr = Trim(ParamStr).Replace(" ", ".+")
                    Dim _whr() = {"faktur_kode REGEXP '{0}'",
                                  "GetMasterNama('custo',faktur_customer) REGEXP '{0}'",
                                  "salesman_nama REGEXP '{0}'",
                                  "GetMasterNama('custo',faktur_customer) REGEXP '{0}'",
                                  "GetMasterNama('custoalamat2',faktur_customer) REGEXP '{0}'"
                                  }
                    q += String.Format(" AND ({0}) ", String.Format(String.Join(" OR ", _whr), ParamStr))
                End If
                dgv_listfaktur.DataSource = x.GetDataTable(q + " LIMIT 500")

            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'SAVE DRAFT
    Private Sub SaveDraft()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        If dgv_draftsales.RowCount = 0 Then
            MessageBox.Show("Data salesman masih kosong, input data salesman terlebih dahulu.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If dgv_draftfaktur.RowCount = 0 Then
            MessageBox.Show("Data faktur masih kosong, input faktur terlebih dahulu.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If MessageBox.Show("Simpan Draft?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor

            Dim q As String = ""
            Dim qArr As New List(Of String)

            'HEADER DRAFT
            If formstate = InputState.Insert Then
                Using x = MainConnection
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        'GENERATE / CEK KODE
                        If String.IsNullOrWhiteSpace(in_kode_draft.Text) Then
                            q = "SELECT IFNULL(RIGHT(MAX(draft_kode),3),0) FROM data_draft_faktur " _
                                & "WHERE LEFT(draft_kode,10)='RS{0:yyyyMMdd}' AND draft_tanggal='{0:yyyy-MM-dd}' " _
                                & "AND RIGHT(draft_kode,3) REGEXP {1} AND LENGTH(draft_kode)=13"
                            Dim i = CInt(x.ExecScalar(String.Format(q, date_tgl_trans.Value, "'(^|[^0-9])[0-9]{3}$'")))
                            in_kode_draft.Text = "RS" & date_tgl_trans.Value.ToString("yyyyMMdd") & (i + 1).ToString("D3")
                        Else
                            q = "SELECT COUNT(draft_kode) FROM data_draft_faktur WHERE draft_kode='{0}' AND draft_status<9"
                            Dim i = CInt(x.ExecScalar(String.Format(q, in_kode_draft.Text)))
                            If i > 0 Then
                                MessageBox.Show(String.Format("Kode draft {0} sudah pernah di input. Silahkan gunakan kode lain.", in_kode_draft.Text),
                                                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                in_kode_draft.Focus() : in_kode_draft.SelectAll()
                                GoTo EndSub
                            End If
                        End If
                    Else
                        MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        GoTo EndSub
                    End If
                End Using
                q = "INSERT INTO data_draft_faktur SET draft_kode='{0}', draft_tanggal='{1:yyyy-MM-dd}', draft_reg_date=NOW(), draft_reg_alias='{2}'"
            ElseIf formstate = InputState.Edit Then
                q = "UPDATE data_draft_faktur SET draft_tanggal='{1:yyyy-MM-dd}', draft_upd_date=NOW(), draft_upd_alias='{2}' WHERE draft_kode='{0}' AND draft_status<9"
            End If
            qArr.Add(String.Format(q, in_kode_draft.Text, date_tgl_trans.Value, loggeduser.user_id))

            'SALES
            q = "UPDATE data_draft_sales SET sales_status=9 WHERE sales_draft='{0}'"
            qArr.Add(String.Format(q, in_kode_draft.Text))

            For Each row As DataGridViewRow In dgv_draftsales.Rows
                q = "INSERT INTO data_draft_sales SET sales_sales='{1}', sales_draft='{0}', sales_reg_date=NOW(), sales_reg_alias='{2}' " _
                    & "ON DUPLICATE KEY UPDATE sales_status=1"
                qArr.Add(String.Format(q, in_kode_draft.Text, row.Cells(0).Value, loggeduser.user_id))
            Next

            'FAKTUR
            q = "UPDATE data_draft_nota SET nota_status=9 WHERE nota_draft='{0}'"
            qArr.Add(String.Format(q, in_kode_draft.Text))

            For Each row As DataGridViewRow In dgv_draftfaktur.Rows
                q = "INSERT INTO data_draft_nota SET nota_draft='{0}', nota_faktur='{1}', nota_reg_date=NOW(), nota_reg_alias='{2}' " _
                    & "ON DUPLICATE KEY UPDATE nota_status=1"
                qArr.Add(String.Format(q, in_kode_draft.Text, row.Cells(1).Value, loggeduser.user_id))
            Next

            'SAVE DRAFT
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim _ck As Boolean = x.TransactCommand(qArr)
                    If _ck Then
                        MessageBox.Show("Draft tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        in_kode_draft.ReadOnly = True : formstate = InputState.Edit : ControlSwitch(True)
                        DoRefreshTab_v2({pgdraftrekap})
                        in_cari_faktur.Clear() : ck_tgl2.Checked = False : LoadDataGridFaktur()
                    Else
                        MessageBox.Show("Draft tidak tersimpan." & Environment.NewLine & "Terjadi kesalahan saat melakukan penyimpanan.",
                                        Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
EndSub:
            Me.Cursor = Cursors.Default
        End If
    End Sub

    'DELETE DRAFT
    Private Sub DeleteDraft()
        If String.IsNullOrWhiteSpace(in_kode_draft.Text) Then Exit Sub
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Dim q As String = ""
        Dim qArr As New List(Of String)

        q = "UPDATE data_draft_faktur SET draft_status=9, draft_upd_date=NOW(), draft_upd_alias='{1}' WHERE draft_kode='{0}'"
        qArr.Add(String.Format(q, in_kode_draft.Text, loggeduser.user_id))
        q = "UPDATE data_draft_sales SET sales_status=9 WHERE sales_draft='{0}'"
        qArr.Add(String.Format(q, in_kode_draft.Text))
        q = "UPDATE data_draft_nota SET nota_status=9 WHERE nota_draft='{0}'"
        qArr.Add(String.Format(q, in_kode_draft.Text))

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _ck = x.TransactCommand(qArr)
                If _ck Then
                    MessageBox.Show("Draft telah dihapus.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pgdraftrekap})
                    Me.Close()
                Else
                    MessageBox.Show("Draft gagal terhapus. Terjadi kesalahan saat melakukan penghapusan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'PRINT DRAFT
    Private Sub PrintDraft(PrintType As String)
        If String.IsNullOrWhiteSpace(in_kode_draft.Text) Or formstate = InputState.Insert Then
            MessageBox.Show("Draft belum tersimpan ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'SaveDraft()
            Exit Sub
        Else
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim q As String = "SELECT COUNT(draft_kode) FROM data_draft_faktur WHERE draft_kode='{0}' AND draft_status=1"
                    Dim i = CInt(x.ExecScalar(String.Format(q, in_kode_draft.Text)))
                    If i = 0 Then
                        MessageBox.Show("Draft tidak dapat di temukan di database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End Using
        End If

        Me.Cursor = Cursors.WaitCursor
        Select Case PrintType
            Case "brg"
                Using draftbarang As New fr_draft_barang_view
                    draftbarang.kodedraft = in_kode_draft.Text
                    draftbarang.ShowDialog()
                End Using
            Case "nota"
                Using draftbarang As New fr_draft_nota_view
                    draftbarang.kodedraft = in_kode_draft.Text
                    draftbarang.ShowDialog()
                End Using
        End Select
        Me.Cursor = Cursors.Default
    End Sub

    'UI : DRAG
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
    Private Sub bt_batalbeli_Click(sender As Object, e As EventArgs) Handles bt_batalreturbeli.Click
        If MessageBox.Show("Tutup Form?", Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalreturbeli.PerformClick()
    End Sub

    'UI : MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        SaveDraft()
    End Sub

    Private Sub mn_printnota_Click(sender As Object, e As EventArgs) Handles mn_printnota.Click
        PrintDraft("nota")
    End Sub

    Private Sub mn_printbrg_Click(sender As Object, e As EventArgs) Handles mn_printbrg.Click
        PrintDraft("brg")
    End Sub

    Private Sub mn_cancelorder_Click(sender As Object, e As EventArgs) Handles mn_cancelorder.Click
        DeleteDraft()
    End Sub

    'UI : CHECKBOX
    Private Sub ck_tgl2_CheckedChanged(sender As Object, e As EventArgs) Handles ck_tgl2.CheckedChanged
        date_faktur_awal.Enabled = ck_tgl2.Checked
        date_faktur_akhir.Enabled = ck_tgl2.Checked
    End Sub

    'UI : BUTTON
    Private Sub bt_simpanreturbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanreturbeli.Click
        SaveDraft()
    End Sub

    Private Sub bt_search_Click(sender As Object, e As EventArgs) Handles bt_search.Click
        LoadDataGridSales(in_cari_sales.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_search2.Click
        LoadDataGridFaktur(in_cari_faktur.Text)
    End Sub

    Private Sub bt_addsales_Click(sender As Object, e As EventArgs) Handles bt_addsales.Click
        Me.Cursor = Cursors.WaitCursor
        If dgv_sales.SelectedRows.Count > 0 Then
            dgv_draftsales.ClearSelection()
            For Each selected As DataGridViewRow In dgv_sales.SelectedRows
                Dim _kode As String = selected.Cells(0).Value
                For Each row As DataGridViewRow In dgv_draftsales.Rows
                    If row.Cells(0).Value = _kode Then GoTo NextKode
                Next
                Dim i = dgv_draftsales.Rows.Add(selected.Cells(0).Value, selected.Cells(1).Value)
                dgv_draftsales.Rows(i).Selected = True
NextKode:
            Next
            dgv_sales.ClearSelection()
            in_cari_faktur.Clear() : ck_tgl2.Checked = False : LoadDataGridFaktur()
            lbl_count_sales.Text = String.Format("{0} Sales", dgv_draftsales.RowCount)
        End If
EndSub:
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_remsales_Click(sender As Object, e As EventArgs) Handles bt_remsales.Click
        Me.Cursor = Cursors.WaitCursor
        If dgv_draftsales.RowCount > 0 And dgv_draftsales.SelectedRows.Count > 0 Then
            For Each selected As DataGridViewRow In dgv_draftsales.SelectedRows
                Dim cksales As Boolean = False
                For Each fkt As DataGridViewRow In dgv_draftfaktur.Rows
                    If fkt.Cells("draft_sales").Value = selected.Cells("draft_sales_n").Value Then
                        cksales = True
                        Exit For
                    End If
                Next
                If Not cksales Then
                    dgv_draftsales.Rows.RemoveAt(selected.Index)
                Else
                    MessageBox.Show("Faktur untuk sales tsb sudah diinput, Hapus faktur yang berhubungan terlebih dahulu.", Me.Text, MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning)
                    GoTo EndSub
                End If
            Next
            dgv_draftsales.ClearSelection()
            in_cari_faktur.Clear() : ck_tgl2.Checked = False : LoadDataGridFaktur()
            lbl_count_sales.Text = String.Format("{0} Sales", dgv_draftsales.RowCount)
        End If
EndSub:
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_faktur_all.Click, bt_addfaktur.Click
        Me.Cursor = Cursors.WaitCursor
        If dgv_listfaktur.RowCount > 0 Then
            dgv_draftfaktur.ClearSelection()
            For Each row As DataGridViewRow In IIf(sender.Name = "bt_faktur_all", dgv_listfaktur.Rows, dgv_listfaktur.SelectedRows)
                If Not row.Cells("faktur_draft").Value = "Y" Then
                    Dim _kode As String = row.Cells(0).Value
                    For Each listed As DataGridViewRow In dgv_draftfaktur.Rows
                        If listed.Cells(1).Value = _kode Then GoTo NextKode
                    Next
                    Dim i = dgv_draftfaktur.Rows.Add(row.Cells("list_custo").Value, _kode, row.Cells(4).Value, row.Cells(6).Value)
                    dgv_draftfaktur.Rows(i).Selected = True
NextKode:
                    row.Cells("faktur_draft").Value = "Y"
                End If
            Next
            dgv_listfaktur.ClearSelection()
            lbl_count_faktur.Text = dgv_draftfaktur.RowCount & " Faktur"
        End If
EndSub:
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_remfaktur_Click(sender As Object, e As EventArgs) Handles bt_remfaktur.Click, bt_faktur_clear.Click
        Me.Cursor = Cursors.WaitCursor

        Dim x As New List(Of String)
        If dgv_draftfaktur.RowCount > 0 Or dgv_draftfaktur.SelectedRows.Count > 0 Then
            in_cari_faktur.Clear() : ck_tgl2.Checked = False : LoadDataGridFaktur()

            For Each row As DataGridViewRow In IIf(sender.Name = "bt_faktur_clear", dgv_draftfaktur.Rows, dgv_draftfaktur.SelectedRows)
                x.Add(row.Cells(1).Value)
                dgv_draftfaktur.Rows.RemoveAt(row.Index)
            Next

            For Each _kode As String In x
                For Each _list As DataGridViewRow In dgv_listfaktur.Rows
                    If _list.Cells(0).Value = _kode Then _list.Cells("faktur_draft").Value = "N"
                Next
            Next
            lbl_count_faktur.Text = dgv_draftfaktur.RowCount & " Faktur"
        End If

        Me.Cursor = Cursors.Default
    End Sub

    'UI : DGV
    Private Sub dgv_sales_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_sales.CellDoubleClick
        bt_addsales.PerformClick()
    End Sub

    Private Sub dgv_draftsales_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_draftsales.CellDoubleClick
        bt_remsales.PerformClick()
    End Sub

    Private Sub dgv_listfaktur_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listfaktur.CellDoubleClick
        bt_addfaktur.PerformClick()
    End Sub

    Private Sub dgv_draftfaktur_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_draftfaktur.CellDoubleClick
        bt_remfaktur.PerformClick()
    End Sub
End Class