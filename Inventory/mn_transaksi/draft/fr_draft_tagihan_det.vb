Public Class fr_draft_tagihan_det
    Private formstate As InputState = InputState.Insert
    Private popupstate As String = "sales"
    Private _DateTransOldVal As Date = Today
    Private _DateTransNewVal As Date = Today

    Private Enum InputState
        Insert
        Edit
        View
    End Enum

    Private Sub SetupForm(IdDraft As String, FormState As InputState, AllowEdit As Boolean)
        Me.formstate = FormState
        lbl_title.Text = "Draft Tagihan" : Me.Text = lbl_title.Text

        setDoubleBuffered(dgv_draftfaktur, True)
        setDoubleBuffered(dgv_listfaktur, True)
        setDoubleBuffered(dgv_listbarang, True)

        list_tanggal.DefaultCellStyle = dgvstyle_date
        list_temp.DefaultCellStyle = dgvstyle_date
        For Each x As DataGridViewColumn In {list_sisa, draft_sisa, hist_debet, hist_kredit, hist_saldo, hist_tagihan}
            x.DefaultCellStyle = dgvstyle_currency
        Next

        date_faktur_awal.Value = selectperiode.tglawal

        lbl_count_faktur.Text = "0 Faktur"

        For Each dt As DateTimePicker In {date_faktur_akhir, date_faktur_awal, date_tgl_trans}
            'dt.MinDate = selectperiode.tglawal
            'dt.MaxDate = selectperiode.tglakhir
            dt.MinDate = DataListStartDate
            dt.MaxDate = DataListEndDate
        Next

        If Not FormState = InputState.Insert Then
            in_kode_draft.ReadOnly = True
            LoadData(IdDraft)
        End If
        _DateTransOldVal = date_faktur_awal.Value

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowEdit As Boolean)
        date_tgl_trans.Enabled = AllowEdit
        mn_save.Enabled = AllowEdit
        mn_cancelorder.Enabled = If(formstate = InputState.Insert, False, AllowEdit)
        mn_print.Enabled = If(formstate = InputState.Insert, False, True)
        For Each bt As Button In {bt_faktur_all, bt_faktur_clear, bt_addfaktur, bt_remfaktur, bt_simpanreturbeli}
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

                q = "SELECT draft_tanggal, draft_sales, salesman_nama, IF(draft_printstatus='Y','Printed','') FROM data_tagihan_faktur " _
                    & "LEFT JOIN data_salesman_master ON salesman_kode=draft_sales WHERE draft_kode='{0}' AND draft_status<9"
                Using rdx = x.ReadCommand(String.Format(q, IdDraft))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_kode_draft.Text = IdDraft
                        date_tgl_trans.Value = rdx.Item(0)
                        in_sales.Text = rdx.Item(1)
                        in_sales_n.Text = rdx.Item(2)
                        in_printed.Text = rdx.Item(3)
                    Else
                        MessageBox.Show("Tidak dapat mengambil data draft dari database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using
                LoadDataGridFaktur()

                q = "CALL viewTagihan('{0}', 'faktur')"
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
    Private Sub LoadDataGridFaktur(Optional ParamStr As String = "")
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Dim q As String = ""
        Dim _sales As String = in_sales_n.Text
        Dim _tglawal As Date = date_faktur_awal.Value
        Dim _tglakhir As Date = date_faktur_akhir.Value

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT piutang_faktur, piutang_tgl, GetMasterNama('custotagihan', piutang_custo) piutang_custo, " _
                    & "GetPiutangSaldoAwal('piutang',piutang_faktur,ADDDATE('{0:yyyy-MM-dd}',1)) piutang_sisa, piutang_jt, salesman_nama piutang_sales " _
                    & "FROM data_piutang_awal " _
                    & "LEFT JOIN data_salesman_master ON piutang_sales=salesman_kode " _
                    & "WHERE piutang_sales='{1}' AND piutang_status<9"
                q = String.Format(q, date_tgl_trans.Value, in_sales.Text)

                If Not ck_tgl1.Checked And Not ck_tgl2.Checked Then
                    q += String.Format(" AND piutang_tgl BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}'", _tglawal, _tglakhir)
                Else
                    Dim _tgl2q = String.Format("piutang_jt BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}'", _tglawal, _tglakhir)
                    Dim _tgl1q = String.Format("piutang_jt <= '{0:yyyy-MM-dd}'", _tglawal)
                    If ck_tgl1.Checked And ck_tgl2.Checked Then
                        q += String.Format(" AND({0} OR {1})", _tgl1q, _tgl2q)
                    Else
                        q += String.Format(" AND {0}", IIf(ck_tgl1.Checked, _tgl1q, _tgl2q))
                    End If
                End If
                If Not String.IsNullOrWhiteSpace(ParamStr) Then
                    ParamStr = Trim(ParamStr).Replace(" ", ".+")
                    q += String.Format(" AND(piutang_faktur REGEXP '{0}' OR GetMasterNama('custotagihan', piutang_custo) REGEXP '{0}')", ParamStr)
                End If
                If ck_hidepaid.Checked Then
                    q = String.Format("SELECT * FROM ({0}) piutang WHERE piutang_sisa<>0", q)
                End If

                q += " ORDER BY piutang_faktur LIMIT 500"
                consoleWriteLine(q)

                Using dtx = x.GetDataTable(q)
                    dgv_listfaktur.Rows.Clear()
                    For Each row As DataRow In dtx.Rows
                        Dim _custoInfo = row.Item(2).ToString.Split("|")
                        dgv_listfaktur.Rows.Add(row.Item(0), row.Item(1), _custoInfo(0), row.Item(3), row.Item(4),
                                                _custoInfo(1), _custoInfo(2), _custoInfo(3), row.Item(5)
                                                )
                    Next
                    dgv_detail_tagihan.Rows.Clear()
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Sub LoadDataGridHistory(IdPiutang As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Dim q As String = ""
        dgv_detail_tagihan.Rows.Clear()
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    q = "SELECT piutang_tgl, piutang_ket, piutang_faktur, piutang_debet, piutang_kredit, " _
                        & "@saldo:=@saldo+(piutang_debet-piutang_kredit) piutang_saldo, piutang_tagihan " _
                        & "FROM( " _
                        & " SELECT 'awal' piutang_tipe, '{1:yyyy-MM-dd}' piutang_tgl, 'SALDO AWAL' piutang_ket, '' piutang_faktur, " _
                        & "     GetPiutangSaldoAwal('piutang', '{0}', '{1:yyyy-MM-dd}') piutang_debet, 0 piutang_kredit, 0 piutang_tagihan " _
                        & " UNION " _
                        & " SELECT 'tagih', draft_tanggal, CONCAT('Tagihan ', draft_kode), draft_kode, 0, 0, nota_tagihan " _
                        & " FROM data_tagihan_nota " _
                        & " LEFT JOIN data_tagihan_faktur ON draft_kode=nota_draft AND draft_status<9 " _
                        & " WHERE nota_status=1 AND nota_faktur='{0}' " _
                        & " UNION " _
                        & " SELECT p_trans_jenis, p_trans_tgl, CONCAT(UCASE(p_trans_jenis), ' ', p_trans_kode_piutang), " _
                        & " IF(IFNULL(p_trans_faktur,'')='', p_trans_kode_piutang, p_trans_faktur), " _
                        & " IF(p_trans_nilai>0, p_trans_nilai, 0), IF(p_trans_nilai<0, p_trans_nilai*-1, 0), 0 " _
                        & " FROM data_piutang_trans " _
                        & " WHERE p_trans_status=1 AND p_trans_kode_piutang='{0}' AND p_trans_tgl BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' " _
                        & " ORDER BY FIELD(piutang_tipe,'awal','migrasi','jual','tagih','bayar','cair','tolak'), piutang_tgl " _
                        & ")history " _
                        & "JOIN (SELECT @saldo:=0) param " _
                        & "WHERE piutang_debet+piutang_kredit+piutang_tagihan<>0"
                    Using dtx = x.GetDataTable(String.Format(q, IdPiutang, selectperiode.tglawal, selectperiode.tglakhir))
                        For Each row As DataRow In dtx.Rows
                            dgv_detail_tagihan.Rows.Add(row.ItemArray(0), row.ItemArray(1), row.ItemArray(2),
                                                        row.ItemArray(3), row.ItemArray(4), row.ItemArray(5), row.ItemArray(6))
                        Next
                    End Using
                Catch ex As Exception
                    logError(ex, True) : Exit Sub
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable

        Select Case tipe
            Case "sales"
                q = "SELECT salesman_kode as 'Kode', salesman_nama as 'Salesman'" _
                    & "FROM data_salesman_master " _
                    & "WHERE salesman_status=1 AND (salesman_nama LIKE '%{0}%' OR salesman_kode LIKE '%{0}%')"
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
            If .ColumnCount = 2 Then
                .Columns(0).Width = 135 : .Columns(1).Width = 200
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        End With
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        Me.Cursor = Cursors.WaitCursor
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    in_cari_faktur.Focus()
                    LoadDataGridFaktur()
                Case Else
                    Exit Sub
            End Select
        End With
        Me.Cursor = Cursors.Default
        'popPnl_barang.Visible = False
    End Sub

    'SAVE DRAFT
    Private Sub SaveDraft()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        If String.IsNullOrWhiteSpace(in_sales.Text) Then
            MessageBox.Show("Data salesman masih kosong, input data salesman terlebih dahulu.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If dgv_draftfaktur.RowCount = 0 Then
            MessageBox.Show("Data tagihan masih kosong, input data faktur/tagihan terlebih dahulu.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If MessageBox.Show("Simpan Draft?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor

            Dim q As String = ""
            Dim qArr As New List(Of String)

            'HEADER
            If formstate = InputState.Insert Then
                Using x = MainConnection
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        If String.IsNullOrWhiteSpace(in_kode_draft.Text) Then
                            q = "SELECT IFNULL(RIGHT(MAX(draft_kode),3),0) FROM data_tagihan_faktur " _
                                & "WHERE LEFT(draft_kode,10)='DT{0:yyyyMMdd}' AND draft_tanggal='{0:yyyy-MM-dd}' " _
                                & "AND RIGHT(draft_kode,3) REGEXP {1} AND LENGTH(draft_kode)=13"
                            Dim i = CInt(x.ExecScalar(String.Format(q, date_tgl_trans.Value, "'(^|[^0-9])[0-9]{3}$'")))
                            in_kode_draft.Text = "DT" & date_tgl_trans.Value.ToString("yyyyMMdd") & (i + 1).ToString("D3")
                        Else
                            q = "SELECT COUNT(draft_kode) FROM data_tagihan_faktur WHERE draft_kode='{0}' AND draft_status<9"
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
                q = "INSERT INTO data_tagihan_faktur SET draft_kode='{0}', draft_tanggal='{1:yyyy-MM-dd}', draft_sales='{2}', " _
                    & "draft_reg_date=NOW(), draft_reg_alias='{3}'"
            Else
                q = "UPDATE data_tagihan_faktur SET draft_tanggal='{1:yyyy-MM-dd}', draft_sales='{2}', draft_upd_date=NOW(), draft_upd_alias='{3}' " _
                    & "WHERE draft_kode='{0}' AND draft_status<9"
            End If
            qArr.Add(String.Format(q, in_kode_draft.Text, date_tgl_trans.Value, in_sales.Text, loggeduser.user_id))

            'FAKTUR
            q = "UPDATE data_tagihan_nota SET nota_status=9 WHERE nota_draft='{0}'"
            qArr.Add(String.Format(q, in_kode_draft.Text))

            For Each row As DataGridViewRow In dgv_draftfaktur.Rows
                q = "INSERT INTO data_tagihan_nota SET nota_draft='{0}', nota_faktur='{1}', nota_tagihan={2}, nota_reg_date=NOW(), nota_reg_alias='{3}'"
                qArr.Add(String.Format(q, in_kode_draft.Text, row.Cells(1).Value, row.Cells(2).Value.ToString.Replace(",", "."), loggeduser.user_id))
            Next

            'INPUT DRAFT TO DB
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim _ck As Boolean = x.TransactCommand(qArr)
                    If _ck Then
                        MessageBox.Show("Draft tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        in_kode_draft.ReadOnly = True : formstate = InputState.Edit : ControlSwitch(True)
                        DoRefreshTab_v2({pgdrafttagihan})
                        in_cari_faktur.Clear() : ck_tgl1.Checked = False : ck_tgl2.Checked = True : ck_hidepaid.Checked = True
                        LoadDataGridFaktur()
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
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Dim q As String = ""
        Dim qArr As New List(Of String)

        q = "UPDATE data_tagihan_faktur SET draft_status=9, draft_upd_date=NOW(), draft_upd_alias='{1}' WHERE draft_kode='{0}'"
        qArr.Add(String.Format(q, in_kode_draft.Text, loggeduser.user_id))
        q = "UPDATE data_tagihan_nota SET nota_status=9 WHERE nota_draft='{0}'"
        qArr.Add(String.Format(q, in_kode_draft.Text))

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _ck = x.TransactCommand(qArr)
                If _ck Then
                    MessageBox.Show("Draft telah dihapus.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pgdrafttagihan})
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
    Private Sub PrintDraft()
        Using drafttagihan As New fr_draft_tagihan_view
            drafttagihan.SetDraft(in_kode_draft.Text)
        End Using
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
        'If MessageBox.Show("Tutup Form?", Me.Text, MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        Me.Close()
        'End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalreturbeli.PerformClick()
    End Sub

    'UI : POPUP PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_sales_n.Focused Then
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

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyUp
        If e.KeyCode = Keys.Enter Then
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        Dim x As TextBox
        Select Case popupstate
            Case "sales" : x = in_sales_n
            Case Else : Exit Sub
        End Select
        PopUpSearchKeyPress(e, x)
    End Sub

    Private Sub pnl_content_Click(sender As Object, e As EventArgs) Handles Pnl_content.Click, pnl_footer.Click, Panel1.Click, Panel3.Click, MyBase.Click
        If popPnl_barang.Visible Then popPnl_barang.Visible = False
    End Sub

    'UI : FORM
    Private Sub fr_draft_tagihan_det_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible Then
                popPnl_barang.Visible = False
            Else
                bt_batalreturbeli.PerformClick()
            End If
        End If
    End Sub

    'UI : MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        SaveDraft()
    End Sub

    Private Sub mn_print_Click(sender As Object, e As EventArgs) Handles mn_print.Click
        PrintDraft()
    End Sub

    Private Sub mn_cancelorder_Click(sender As Object, e As EventArgs) Handles mn_cancelorder.Click
        DeleteDraft()
    End Sub

    'UI : BUTTON
    Private Sub bt_search2_Click(sender As Object, e As EventArgs) Handles bt_search2.Click
        LoadDataGridFaktur(in_cari_faktur.Text)
    End Sub

    Private Sub bt_faktur_all_Click(sender As Object, e As EventArgs) Handles bt_faktur_all.Click, bt_addfaktur.Click
        Me.Cursor = Cursors.WaitCursor
        If dgv_listfaktur.RowCount > 0 Then
            dgv_draftfaktur.ClearSelection()
            For Each row As DataGridViewRow In IIf(sender.Name = "bt_faktur_all", dgv_listfaktur.Rows, dgv_listfaktur.SelectedRows)
                Dim _kode As String = row.Cells(0).Value
                For Each s As DataGridViewRow In dgv_draftfaktur.Rows
                    If _kode = s.Cells(1).Value Then GoTo NextKode
                Next
                Dim i = dgv_draftfaktur.Rows.Add(row.Cells(2).Value, row.Cells(0).Value, row.Cells(3).Value, row.Cells(8).Value)
                dgv_draftfaktur.Rows(i).Selected = True
NextKode:
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
            in_cari_faktur.Clear() : LoadDataGridFaktur()
            dgv_listfaktur.ClearSelection()
            If sender.Name = "bt_faktur_clear" Then
                dgv_draftfaktur.Rows.Clear()
            Else
                For Each row As DataGridViewRow In dgv_draftfaktur.SelectedRows
                    dgv_draftfaktur.Rows.RemoveAt(row.Index)
                Next
            End If
            dgv_draftfaktur.ClearSelection()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_simpanreturbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanreturbeli.Click
        SaveDraft()
    End Sub

    'UI : DGV
    Private Sub dgv_listfaktur_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listfaktur.CellDoubleClick
        bt_addfaktur.PerformClick()
    End Sub

    Private Sub dgv_draftfaktur_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_draftfaktur.CellDoubleClick
        bt_remfaktur.PerformClick()
    End Sub

    Private Sub dgv_draftfaktur_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgv_draftfaktur.RowsAdded
        in_sales_n.ReadOnly = True
        date_tgl_trans.Enabled = False
    End Sub

    Private Sub dgv_draftfaktur_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv_draftfaktur.RowsRemoved
        If dgv_draftfaktur.RowCount = 0 Then
            in_sales_n.ReadOnly = False
            date_tgl_trans.Enabled = True
        End If
        lbl_count_faktur.Text = dgv_draftfaktur.RowCount & " Faktur"
    End Sub

    Private Sub dgv_listfaktur_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listfaktur.RowEnter, dgv_draftfaktur.RowEnter
        If e.RowIndex >= 0 Then
            Dim _colIdx As Integer = IIf(sender.Name = "dgv_listfaktur", 0, 1)
            LoadDataGridHistory(sender.Rows(e.RowIndex).Cells(_colIdx).Value)
        End If
    End Sub

    'UI : INPUT
    Private Sub in_sales_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales.KeyUp
        keyshortenter(in_sales, e)
    End Sub

    Private Sub in_sales_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter
        If in_sales_n.ReadOnly = False And in_sales_n.Enabled Then
            popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
            If popPnl_barang.Visible = False Then popPnl_barang.Visible = True
            popupstate = "sales"
            loadDataBRGPopup(popupstate, sender.Text)
        End If
    End Sub

    Private Sub in_sales_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp
        Dim _x = PopUpSearchInputHandle_inputKeyup(e, sender, in_sales, popPnl_barang, dgv_listbarang)
        For Each _resp As String In _x
            Select Case _resp
                Case "set" : setPopUpResult()
                Case "next" : keyshortenter(in_cari_faktur, e)
                Case "clear"
                Case "load" : loadDataBRGPopup(popupstate, sender.Text)
            End Select
        Next
    End Sub

    Private Sub in_sales_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_sales_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyDown
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
    End Sub

    Private Sub in_cari_faktur_KeyUp(sender As Object, e As KeyEventArgs) Handles in_cari_faktur.KeyUp
        If e.KeyCode = Keys.Enter Then
            LoadDataGridFaktur(sender.Text)
            bt_addfaktur.Focus()
        End If
    End Sub

    Private Sub date_tgl_trans_ValueChanged(sender As Object, e As EventArgs) Handles date_tgl_trans.ValueChanged
        _DateTransNewVal = sender.Value
    End Sub

    Private Sub date_tgl_trans_Leave(sender As Object, e As EventArgs) Handles date_tgl_trans.Validated
        If Not String.IsNullOrWhiteSpace(in_sales.Text) And _DateTransNewVal <> _DateTransOldVal Then
            in_cari_faktur.Clear()
            LoadDataGridFaktur()
        End If
        _DateTransOldVal = sender.Value
    End Sub
End Class