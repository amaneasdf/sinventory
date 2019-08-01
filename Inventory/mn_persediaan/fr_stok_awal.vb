Public Class fr_stok_awal
    Private rowindexlist As Integer = 0
    Private popupstate As String = "barang"
    Private formstate As InputState = InputState.Insert
    Private _oldqty As Integer = 0
    Private _oldnilai As Decimal = 0
    Private _brgPajak As String = ""
    Private NewItemHpp As Decimal = 0

    Private Enum InputState
        Insert
        Edit
        View
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(NoFaktur As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Data Stok : PO201908109021"

        formstate = FormSet
        date_input.Value = selectperiode.tglawal

        If formstate <> InputState.Insert Then
            Me.Text += " : " & NoFaktur
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            LoadData(NoFaktur)
            bt_simpanreturbeli.Text = "Update"
        End If

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        For Each txt As TextBox In {in_barang_n, in_gudang_n}
            txt.ReadOnly = IIf(formstate = InputState.Insert, If(AllowInput, False, True), True)
        Next

        in_qty.Enabled = AllowInput
        in_nilai.Enabled = AllowInput
        bt_simpanreturbeli.Enabled = AllowInput

        For Each ctr As Control In {lbl_old_hpp, lbl_old_nilai, lbl_old_qty, in_old_hpp, in_old_nilai, in_old_qty}
            ctr.Visible = IIf(formstate = InputState.Insert, False, True)
        Next
    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        SetUpForm(Nothing, InputState.Insert, AllowInput)
        Me.Show(main)
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, AllowEdit As Boolean)
        SetUpForm(NoFaktur, InputState.Edit, AllowEdit)
        Me.Show(main)
        date_input.Checked = False
    End Sub

    Public Sub doLoadView(NoFaktur As String)
        SetUpForm(NoFaktur, InputState.View, False)
        Me.Show(main)
    End Sub

    'LOAD DATA
    Private Sub LoadData(KodeStock As String)
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                'GET HEADER
                q = "SELECT stock_kode, IFNULL(DATE_FORMAT(MIN(trans_tgl),'%Y-%m-%d'),'{2:yyyy-MM-dd}') trans_tgl, " _
                    & "stock_barang, GetMasterNama('barang',stock_barang) barang_nama, " _
                    & "stock_gudang, GetMasterNama('gudang',stock_gudang) gudang_nama " _
                    & "FROM data_stok_awal " _
                    & "LEFT JOIN data_stok_kartustok ON stock_kode=trans_stock AND trans_status=1 AND trans_jenis IN ('mi','ad') AND trans_periode='{1}'  " _
                    & "WHERE stock_kode='{0}'" _
                    & "GROUP BY stock_kode"
                Using rdx = x.ReadCommand(String.Format(q, KodeStock, selectperiode.id, selectperiode.tglawal))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_id.Text = KodeStock
                        in_barang.Text = rdx.Item("stock_barang")
                        in_barang_n.Text = rdx.Item("barang_nama")
                        in_gudang.Text = rdx.Item("stock_gudang")
                        in_gudang_n.Text = rdx.Item("gudang_nama")
                        date_input.Checked = True
                        date_input.Value = rdx.Item("trans_tgl")
                    Else
                        MessageBox.Show("Tidak dapat mengambil data stok.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        GoTo EndSub
                    End If
                End Using

                'GET VALUE
                Dim _startVal, _adjVal, _finVal, _hpp As Decimal
                Dim _startQty, _adjQty, _finQty As Integer

                q = "SELECT IFNULL(SUM(trans_qty),0), IFNULL(SUM(trans_nilai),0) FROM data_stok_kartustok " _
                    & "WHERE trans_stock='{0}' AND trans_status=1 AND trans_tgl<'{1:yyyy-MM-dd}'"
                Using rdx = x.ReadCommand(String.Format(q, KodeStock, selectperiode.tglawal))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _startQty = rdx.Item(0)
                        _startVal = rdx.Item(1)
                    Else
                        MessageBox.Show("Tidak dapat mengambil data stok.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        GoTo EndSub
                    End If
                End Using

                q = "SELECT IFNULL(SUM(trans_qty),0), IFNULL(SUM(trans_nilai),0) FROM data_stok_kartustok " _
                    & "WHERE trans_stock='{0}' AND trans_status AND trans_tgl BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' AND trans_jenis IN ('mi','ad')"
                Using rdx = x.ReadCommand(String.Format(q, KodeStock, selectperiode.tglawal, selectperiode.tglakhir))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _adjQty = rdx.Item(0)
                        _adjVal = rdx.Item(1)
                    Else
                        MessageBox.Show("Tidak dapat mengambil data stok.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        GoTo EndSub
                    End If
                End Using
                _finQty = _startQty + _adjQty
                _finVal = _startVal + _adjVal
                If _finQty <> 0 And _finVal <> 0 Then
                    _hpp = Math.Round(_finVal / _finQty, 2)
                    If _hpp < 0 Then
                        _hpp = 0 : MessageBox.Show("Nilai persediaan stok negatif!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    _hpp = 0
                End If

                in_qty.Value = _finQty
                in_nilai.Value = _finVal
                in_hpp.Text = _hpp
                in_old_hpp.Text = in_hpp.Text
                in_old_qty.Text = commaThousand(in_qty.Value)
                in_old_nilai.Text = commaThousand(in_nilai.Value)
            End If
        End Using

EndSub:
        Me.Cursor = Cursors.Default
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Dim autoco As New AutoCompleteStringCollection
        Select Case tipe
            Case "barang"
                q = "SELECT barang_kode Kode, barang_nama Nama FROM data_barang_master " _
                    & "WHERE barang_status=1 AND (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%') LIMIT 250"
            Case "gudang"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang " _
                    & "WHERE gudang_status=1 AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%') LIMIT 250"
            Case Else
                Exit Sub
        End Select

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                With dgv_listbarang
                    .DataSource = x.GetDataTable(String.Format(q, param))
                    If .ColumnCount > 0 Then
                        .Columns(0).Width = 135
                        .Columns(1).Width = 200
                    End If
                End With
            Else
                dgv_listbarang.DataSource = Nothing
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "barang"
                    If formstate = InputState.Insert Then
                        Try : SetNewItemHpp(.Cells(0).Value)
                        Catch ex As Exception : logError(ex, True) : Exit Sub
                        End Try
                    End If
                    in_barang.Text = .Cells(0).Value
                    in_barang_n.Text = .Cells(1).Value
                    date_input.Focus()
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    in_barang_n.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
    End Sub

    Private Sub SetNewItemHpp(KodeBarang As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _ct = CInt(x.ExecScalar(
                            String.Format("SELECT COUNT(trans_stock) FROM data_stok_kartustok " _
                                          & "WHERE trans_stock LIKE '%-{0}' AND trans_status=1",
                                          KodeBarang
                                          )
                                      ))

                If _ct > 0 Then
                    NewItemHpp = CDec(x.ExecScalar(String.Format("SELECT getHppAvg_v2('{0}',CURDATE())", KodeBarang)))
                Else
                    NewItemHpp = CDec(x.ExecScalar(
                            String.Format("SELECT ROUND(barang_harga_beli/(barang_satuan_tengah_jumlah*barang_satuan_besar_jumlah),2)" _
                                          & "FROM data_barang_master WHERE barang_kode='{0}'",
                                          KodeBarang
                                          )
                                      ))
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Throw New Exception("Tidak dapat terhubung ke database. GET HPP FOR NEW STOK PROC.")
            End If
        End Using
    End Sub

    'SAVE DATA
    Private Sub saveData()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim q As String = ""
        Dim _data As String()
        Dim queryArr As New List(Of String)
        Dim queryCk As Boolean = False
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Dim _kodetrans As String = ""
                Dim _kodestock As String = ""
                Dim _tgltrans As Date = Today
                Dim _qty As Integer = 0
                Dim _nilai As Decimal = 0

                '==========================================================================================================================
                'INPUT DATA STOK
                If formstate = InputState.Insert Then
                    _kodestock = in_gudang.Text & "-" & in_barang.Text
                    _qty = in_qty.Value
                    _nilai = in_nilai.Value
                    If date_input.Checked Then
                        _tgltrans = date_input.Value
                    Else
                        _tgltrans = Today
                    End If

                    q = "SELECT COUNT(stock_kode) FROM data_stok_awal WHERE stock_kode='{0}' AND stock_status=1"
                    Dim i = CInt(x.ExecScalar(String.Format(q, _kodestock)))
                    If i > 0 Then
                        MessageBox.Show("Data stok sudah ada di database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                Else
                    _kodestock = in_id.Text
                    _qty = in_qty.Value - removeCommaThousand(in_old_qty.Text)
                    _nilai = in_nilai.Value - removeCommaThousand(in_old_nilai.Text)
                    If date_input.Checked Then
                        _tgltrans = date_input.Value
                    Else
                        q = "SELECT IFNULL(MIN(trans_tgl),'{1:yyyy-MM-dd}') FROM data_stok_kartustok " _
                            & "WHERE trans_stock='{0}' AND trans_status=1 AND trans_tgl>='{1:yyyy-MM-dd}'"
                        _tgltrans = CDate(x.ExecScalar(String.Format(q, _kodestock, selectperiode.tglawal)))
                    End If

                End If
                _kodetrans = _kodestock & "-ad-" & Now.ToString("yyMMdd.hhmmss")
                q = "INSERT INTO data_stok_kartustok SET {0}"
                _data = {
                       "trans_stock='" & _kodestock & "'",
                       "trans_periode='" & selectperiode.id & "'",
                       "trans_index=0",
                       "trans_jenis='ad'",
                       "trans_ket='Stock Adjustment'",
                       String.Format("trans_tgl='{0:yyyy-MM-dd}'", _tgltrans),
                       "trans_faktur='" & _kodetrans & "'",
                       "trans_qty=" & _qty.ToString.Replace(",", "."),
                       "trans_nilai=" & _nilai.ToString.Replace(",", "."),
                       "trans_reg_date=NOW()",
                       "trans_reg_alias='" & loggeduser.user_id & "'"
                       }
                queryArr.Add(String.Format(q, String.Join(",", _data)))
                '==========================================================================================================================

                '==========================================================================================================================
                'INPUT DATA TRANSAKSI
                q = "INSERT INTO data_stok_penyesuaian SET {0}"
                _data = {
                    "s_p_kode='" & _kodetrans & "'",
                    "s_p_stock='" & _kodestock & "'",
                    "s_p_oldqty=" & _oldqty.ToString.Replace(",", "."),
                    "s_p_oldnilai=" & _oldnilai.ToString.Replace(",", "."),
                    "s_p_newqty=" & in_qty.Value.ToString.Replace(",", "."),
                    "s_p_newnilai=" & in_nilai.Value.ToString.Replace(",", "."),
                    "s_p_reg_alias='" & loggeduser.user_id & "'",
                    "s_p_reg_date=NOW()"
                    }
                queryArr.Add(String.Format(q, String.Join(",", _data)))
                '==========================================================================================================================

                '==========================================================================================================================
                'INPUT DATA JURNAL
                q = "SELECT barang_pajak FROM data_barang_master WHERE barang_kode='{0}'"
                _brgPajak = IIf(x.ExecScalar(String.Format(q, in_barang.Text)) = 1, True, False)

                q = "INSERT INTO data_jurnal_line SET {0}"
                _data = {
                    "line_kode='" & _kodetrans & "'",
                    "line_type='STOKADJ'",
                    "line_ref='" & _kodestock & "'",
                    "line_ref_type='STOCK'",
                    "line_pajak=" & IIf(_brgPajak, 1, 0),
                    "line_tanggal='" & _tgltrans.ToString("yyyy-MM-dd") & "'",
                    "line_status=1",
                    "line_reg_date=NOW()",
                    "line_reg_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add(String.Format(q, String.Join(",", _data)))
                queryCk = x.TransactCommand(queryArr)
                '==========================================================================================================================
            End If

        End Using

        If queryCk Then
            MessageBox.Show("Saldo awal stok tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            doRefreshTab({pgstok})
        Else
            MessageBox.Show("Data tidak dapat tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------drag form
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalreturbeli.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalreturbeli.PerformClick()
    End Sub

    Private Sub fr_jual_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            'If popPnl_barang.Visible = True Then
            '    popPnl_barang.Visible = False
            'Else
            bt_batalreturbeli.PerformClick()
            'End If
        End If
    End Sub

    'SAVE
    Private Sub bt_simpanreturbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanreturbeli.Click
        If String.IsNullOrWhiteSpace(Trim(in_id.Text)) And formstate <> InputState.Insert Then
            MessageBox.Show("Kode Stok tidak ada.")
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(Trim(in_barang.Text)) Then
            MessageBox.Show("Item/Barang belum diinput.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(Trim(in_gudang.Text)) Then
            MessageBox.Show("Gudang belum diinput.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("Simpan saldo awal?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    'UI : POPUP PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_gudang_n.Focused Or in_barang_n.Focused Then
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
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            Dim x As TextBox
            Select Case popupstate
                Case "gudang"
                    x = in_gudang_n
                Case "barang"
                    x = in_barang_n
                Case Else
                    x = Nothing
                    x.Dispose()
                    Exit Sub
            End Select
            x.Text += e.KeyChar
            e.Handled = True
            x.Focus()
            x.Select(x.TextLength, x.TextLength)
        End If
    End Sub

    'UI : NUMERIC
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_nilai.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_nilai.Leave
        numericLostFocus(sender, IIf(sender.Name = "in_qty", "N0", "N2"))
    End Sub

    Private Sub in_nilai_ValueChanged(sender As Object, e As EventArgs) Handles in_nilai.ValueChanged, in_qty.ValueChanged
        If in_qty.Value = 0 Or (in_qty.Value < 0 And in_nilai.Value >= 0) Then
            in_hpp.Text = 0
        Else
            consoleWriteLine(sender.Name)
            If sender.Name = "in_qty" And sender.Value <> 0 AndAlso formstate = InputState.Insert Then
                If NewItemHpp > 0 Then
                    in_nilai.Value = sender.Value * NewItemHpp
                Else
                    GoTo CountHpp
                End If
            ElseIf sender.Name = "in_qty" And Not String.IsNullOrWhiteSpace(in_hpp.Text) Then
                in_nilai.Value = in_qty.Value * removeCommaThousand(in_hpp.Text)
            Else
CountHpp:
                in_hpp.Text = commaThousand(Math.Round(in_nilai.Value / in_qty.Value, 2))
            End If
        End If
    End Sub

    'UI : INPUT
    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_gudang_n_Enter(sender As Object, e As EventArgs) Handles in_gudang_n.Enter, in_barang_n.Enter
        If sender.ReadOnly = False Or sender.Enabled Then
            popPnl_barang.Visible = True
            popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
            Select Case sender.Name
                Case "in_gudang_n" : popupstate = "gudang"
                Case "in_barang_n" : popupstate = "barang"
            End Select

            loadDataBRGPopup(popupstate)
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_barang_n.Leave, in_gudang_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_custo_n_MouseClick(sender As Object, e As MouseEventArgs) Handles in_gudang_n.MouseClick, in_barang_n.MouseClick
        If popPnl_barang.Visible = False And sender.ReadOnly = False Then
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_gudang_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyDown, in_barang_n.KeyDown
        If sender.ReadOnly = False Or sender.Enabled Then
            Dim _nxtcontrol As Control
            Dim _kdcontrol As Control
            Select Case sender.Name.ToString
                Case "in_gudang_n"
                    _nxtcontrol = in_barang_n
                    _kdcontrol = in_gudang
                Case "in_barang_n"
                    _nxtcontrol = date_input
                    _kdcontrol = in_barang
                Case Else
                    Exit Sub
            End Select

            If IsNothing(_kdcontrol) = False And sender.Text = "" Then
                _kdcontrol.Text = ""
            End If

            If e.KeyCode = Keys.Down Then
                If popPnl_barang.Visible = True Then dgv_listbarang.Focus()
            ElseIf e.KeyCode = Keys.Enter Then
                If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then setPopUpResult()

                keyshortenter(_nxtcontrol, e)
            Else
                If e.KeyCode <> Keys.Escape Then
                    If sender.Enabled And sender.ReadOnly = False Then
                        popPnl_barang.Visible = True
                        _kdcontrol.Text = ""
                    End If
                    loadDataBRGPopup(popupstate, sender.Text)
                Else
                    popPnl_barang.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        keyshortenter(in_barang_n, e)
    End Sub

    Private Sub in_qty_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
        keyshortenter(in_nilai, e)
    End Sub

    Private Sub in_nilai_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nilai.KeyDown
        keyshortenter(bt_simpanreturbeli, e)
    End Sub
End Class