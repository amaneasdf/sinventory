Public Class fr_jurnal_p_entry
    Private ID As Integer = 0
    Private popupstate As String = ""
    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
        View
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(IdJurnal As String, FormSet As InputState, AllowInput As Boolean)
        Const _tempTitle As String = "Detail Jurnal Umum : JP.ENT.xxx"
        formstate = FormSet
        With cb_ppn
            .DataSource = jenis("bayar_pajak2")
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With

        With date_tglentry
            .Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
            .MaxDate = selectperiode.tglakhir
            .MinDate = selectperiode.tglawal
        End With

        If FormSet <> InputState.Insert Then
            loadData(IdJurnal)

            Me.Text += in_kode.Text
            lbl_title.Text += ":" & in_kode.Text
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            If selectperiode.closed Then AllowInput = False
            in_kode.ReadOnly = True
            bt_simpanjual.Text = "Update"
        End If

        ControlSwitch(AllowInput)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        in_ket.ReadOnly = IIf(AllowInput, False, True)
        date_tglentry.Enabled = AllowInput
        cb_ppn.Enabled = AllowInput
        bt_simpanjual.Visible = AllowInput
        mn_save.Enabled = AllowInput
        mn_delete.Enabled = AllowInput
        mn_duplicate.Enabled = AllowInput
        If Not AllowInput Then bt_bataljual.Text = "OK"
        For Each x As DataGridViewColumn In {kas_debet, kas_kredit}
            x.DefaultCellStyle = dgvstyle_currency
        Next
        For Each x As Control In {in_rek, in_rek_n, in_rek_ket, in_debet, in_kredit, bt_tbkas}
            x.Visible = AllowInput
        Next

        If AllowInput Then
            dgv_kas.Location = New Point(12, 124) : dgv_kas.Height = 199
            AddHandler dgv_kas.CellDoubleClick, AddressOf dgv_kas_CellDoubleClick
        Else
            dgv_kas.Location = New Point(12, 85) : dgv_kas.Height = 238
            RemoveHandler dgv_kas.CellDoubleClick, AddressOf dgv_kas_CellDoubleClick
        End If
    End Sub

    Public Sub doLoadNew()
        SetUpForm(Nothing, InputState.Insert, True)
        Me.Show(main)
    End Sub

    Public Sub doLoadEdit(IdJurnal As Integer, AllowInput As Boolean)
        SetUpForm(IdJurnal, InputState.Edit, AllowInput)
        Me.Show(main)
    End Sub

    Public Sub doLoadView(IdJurnal As Integer)
        SetUpForm(IdJurnal, InputState.View, False)
        Me.Show(main)
    End Sub

    'LOAD DATA JURNAL
    Private Sub loadData(IdJurnal As String)
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT line_kode, line_ref, line_tanggal, line_pajak, " _
                    & "line_reg_date, line_reg_alias, " _
                    & "IF(MONTH(line_upd_date)=0, '', line_upd_date) upddate, IFNULL(line_upd_alias, '') updalias " _
                    & "FROM data_jurnal_line WHERE line_id='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, IdJurnal), CommandBehavior.SingleRow)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        Me.ID = IdJurnal
                        in_kode.Text = rdx.Item("line_kode")
                        in_ket.Text = rdx.Item("line_ref")
                        date_tglentry.Value = rdx.Item("line_tanggal")
                        cb_ppn.SelectedValue = rdx.Item("line_pajak")

                        txtRegdate.Text = rdx.Item("line_reg_date")
                        txtRegAlias.Text = rdx.Item("line_reg_alias")
                        txtUpdDate.Text = rdx.Item("upddate")
                        txtUpdAlias.Text = rdx.Item("updalias")
                    Else
                        MessageBox.Show("Tidak dapat menemukan data jurnal umum.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using
                q = "SELECT jurnal_kode_perk as ju_akun,perk_nama_akun as ju_akun_n, jurnal_ket as ju_ket, " _
                    & "jurnal_debet as ju_debet,jurnal_kredit as ju_kredit " _
                    & "FROM data_jurnal_det " _
                    & "LEFT JOIN data_perkiraan ON perk_kode=jurnal_kode_perk " _
                    & "WHERE jurnal_kode_line='{0}' AND jurnal_status=1 ORDER BY jurnal_index"
                Using dtx = x.GetDataTable(String.Format(q, IdJurnal))
                    For Each row As DataRow In dtx.Rows
                        dgv_kas.Rows.Add({row.Item("ju_akun"), row.Item("ju_akun_n"), row.Item("ju_ket"),
                                          row.Item("ju_debet"), row.Item("ju_kredit")})
                    Next
                    CountValue()
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, param As String)
        Dim q As String
        Dim dt As New DataTable
        Dim _pajak As String = IIf(cb_ppn.SelectedValue = 0, 0, 1)

        Select Case tipe
            Case "perkiraan"
                q = "SELECT perk_kode as 'Kode', perk_nama_akun as 'Nama' FROM data_perkiraan " _
                    & "WHERE perk_status=1 AND (perk_nama_akun LIKE '%{0}%' OR perk_kode LIKE '%{0}%') LIMIT 100"
            Case Else
                Exit Sub
        End Select

        Me.Cursor = Cursors.WaitCursor
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                dt = x.GetDataTable(String.Format(q, param))
            End If
        End Using
        Me.Cursor = Cursors.Default

        With dgv_listbarang
            .DataSource = dt
            If .Columns.Count >= 2 Then
                .Columns(0).Width = 100 : .Columns(1).Width = 150
                .Columns(1).AutoSizeMode = IIf(.ColumnCount = 2, DataGridViewAutoSizeColumnMode.Fill, DataGridViewAutoSizeColumnMode.NotSet)
            End If
        End With
    End Sub

    'OPEN SEARCH WINDOW
    Private Sub doSearch()

    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "perkiraan"
                    in_rek.Text = .Cells(0).Value
                    in_rek_n.Text = .Cells(1).Value
                    in_rek_ket.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
    End Sub

    'ADD/REMOVE ITEM
    Private Sub AddItem()
        With dgv_kas.Rows
            Dim x As Integer = .Add
            With .Item(x)
                .Cells("kas_rek").Value = in_rek.Text
                .Cells("kas_rek_n").Value = in_rek_n.Text
                .Cells("kas_ket").Value = IIf(String.IsNullOrWhiteSpace(in_rek_ket.Text), in_ket.Text, in_rek_ket.Text)
                .Cells("kas_kredit").Value = in_kredit.Value
                .Cells("kas_debet").Value = in_debet.Value
            End With
        End With
        For Each x As TextBox In {in_rek, in_rek_n, in_rek_ket} : x.Clear() : Next
        in_debet.Value = 0 : in_kredit.Value = 0
        in_rek.Focus()
        CountValue()
    End Sub

    Private Sub RemoveItem()
        Dim _idx As Integer = 0
        With dgv_kas.SelectedRows.Item(0)
            _idx = .Index
            in_rek.Text = .Cells(0).Value
            in_rek_n.Text = .Cells(1).Value
            in_rek_ket.Text = .Cells(2).Value
            in_debet.Value = .Cells(3).Value
            in_kredit.Value = .Cells(4).Value
        End With
        dgv_kas.Rows.RemoveAt(_idx)
        CountValue()
    End Sub

    Private Sub CountValue()
        Dim _debet As Decimal = 0 : Dim _kredit As Decimal = 0
        For Each row As DataGridViewRow In dgv_kas.Rows
            _debet += row.Cells("kas_debet").Value
            _kredit += row.Cells("kas_kredit").Value
        Next
        in_debet_tot.Text = commaThousand(_debet)
        in_kredit_tot.Text = commaThousand(_kredit)
        in_selisih.Text = commaThousand(IIf(_debet - _kredit < 0, (_debet - _kredit) * -1, _debet - _kredit))
    End Sub

    'SAVE
    Private Sub saveEntryJurnal()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _qArr As New List(Of String)
                Dim q As String = "" : Dim _col As New List(Of String)
                Dim _ck As Boolean = False

                Try
                    If formstate = InputState.Insert Then
                        If String.IsNullOrWhiteSpace(in_kode.Text) Then
                            'GENERATE CODE
                            Dim i As Integer = 0 : Dim format As String = "D3"
                            q = "SELECT IFNULL(MAX(SUBSTRING_INDEX(line_kode, '.', -1)),0) FROM data_jurnal_line " _
                                & "WHERE line_kode REGEXP 'JP.ENT.[[:digit:]]{3,93}$'"
                            i = CInt(x.ExecScalar(q))
                            format = IIf(i + 1 > 999, "D" & (i + 1).ToString.Length, "D3")
                            in_kode.Text = String.Format("JP.ENT.{0}", (i + 1).ToString(format))

                        Else
                            'CHECK INPUTED CODE
                            Dim _ckCode As Integer = 0
                            q = "SELECT COUNT(line_kode) FROM data_jurnal_line WHERE line_kode='{0}' AND line_kat='SESUAI' AND line_type='ENTRY1'"
                            _ckCode = CInt(x.ExecScalar(String.Format(q, in_kode.Text)))
                            If _ckCode > 0 Then
                                MessageBox.Show("Kode " & in_kode.Text & " sudah pernah dipakai/diinputkan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                in_kode.Focus() : Exit Sub
                            End If
                        End If
                        Dim fuk As Integer = 1
                        _col.AddRange({"line_kode='" & in_kode.Text & "'",
                                       "line_tanggal='" & date_tglentry.Value.ToString("yyyy-MM-dd") & "'",
                                       "line_pajak='" & cb_ppn.SelectedValue & "'",
                                       "line_ref='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
                                       "line_ref_type='TEXT'", "line_type='ENTRY1'", "line_kat='SESUAI'"
                                      })
                        q = "INSERT INTO data_jurnal_line SET {0}, line_reg_date=NOW(), line_reg_alias='{1}'; SELECT LAST_INSERT_ID() INTO @ID_line;"
                        _qArr.Add(String.Format(q, String.Join(",", _col), loggeduser.user_id))
                        For Each row As DataGridViewRow In dgv_kas.Rows
                            _col = New List(Of String) From {"jurnal_kode_line=@ID_line", "jurnal_kode_perk='" & row.Cells("kas_rek").Value & "'",
                                                             "jurnal_ket='" & mysqlQueryFriendlyStringFeed(row.Cells("kas_ket").Value) & "'",
                                                             "jurnal_debet=" & CDec(row.Cells("kas_debet").Value).ToString.Replace(",", "."),
                                                             "jurnal_kredit=" & CDec(row.Cells("kas_kredit").Value).ToString.Replace(",", "."),
                                                             "jurnal_index=" & fuk
                                                            }
                            q = "INSERT INTO data_jurnal_det SET {0}"
                            _qArr.Add(String.Format(q, String.Join(",", _col)))
                            fuk += 1
                        Next
                    Else
                        _col.AddRange({"line_tanggal='" & date_tglentry.Value.ToString("yyyy-MM-dd") & "'",
                                       "line_pajak='" & cb_ppn.SelectedValue & "'",
                                       "line_ref='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
                                       "line_ref_type='TEXT'", "line_type='ENTRY1'", "line_kat='SESUAI'"
                                      })
                        q = "UPDATE data_jurnal_line SET {0}, line_upd_date=NOW(), line_upd_alias='{1}' WHERE line_id={2}"
                        _qArr.Add(String.Format(q, String.Join(",", _col), loggeduser.user_id, ID))

                        q = "UPDATE data_jurnal_det SET jurnal_status=9 WHERE jurnal_kode_line={0}"
                        _qArr.Add(String.Format(q, ID))

                        For Each row As DataGridViewRow In dgv_kas.Rows
                            _col = New List(Of String) From {"jurnal_ket='" & mysqlQueryFriendlyStringFeed(row.Cells("kas_ket").Value) & "'",
                                                             "jurnal_debet=" & CDec(row.Cells("kas_debet").Value).ToString.Replace(",", "."),
                                                             "jurnal_kredit=" & CDec(row.Cells("kas_kredit").Value).ToString.Replace(",", "."),
                                                             "jurnal_index=" & row.Index + 1, "jurnal_status=1"
                                                            }
                            q = "INSERT INTO data_jurnal_det SET jurnal_kode_line={0}, jurnal_kode_perk='{1}', {2} ON DUPLICATE KEY UPDATE {2}"
                            _qArr.Add(String.Format(q, ID, row.Cells("kas_rek").Value, String.Join(",", _col)))
                        Next
                    End If

                    _ck = x.TransactCommand(_qArr)
                Catch ex As Exception
                    MessageBox.Show("Terjadi kesalahan dalam melakukan penginputan data.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    logError(ex, True) : Exit Sub
                End Try

                If _ck = False Then
                    MessageBox.Show("Data tidak dapat tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    MessageBox.Show("Data entry jurnal tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pgjurnalumum}) : Me.Close()
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'DELETE
    Private Sub deletEntryJurnal()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        If Me.ID = 0 Then Exit Sub

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                If Not UserPrivChk("DELETE") Then Exit Sub

                Dim _q As String = "" : Dim _qArr As New List(Of String)
                _q = "UPDATE data_jurnal_line SET line_status=9, line_upd_date=NOW(), line_upd_alias='{1}' WHERE line_id='{0}'"
                _qArr.Add(String.Format(_q, Me.ID, loggeduser.user_id))
                Dim _ck = x.TransactCommand(_qArr)
                If _ck Then
                    MessageBox.Show("Entry jurnal penyesuaian telah dihapus.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pgjurnalsesuai})
                    Me.Close()
                Else
                    MessageBox.Show("Entry jurnal penyesuaian gagal dihapus.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'VALIDASI USER PRIVILEDGE
    Private Function UserPrivChk(InputType As String) As Boolean
        If formstate = InputState.Insert Then
            Return True
        Else
            Dim ValidUid As String = ""
            If AkunConfirmValid(ValidUid) Then
                LogValidTrans(ValidUid, loggeduser.user_id, "JP.ENTRY", InputType, Me.ID)
                Return True
            Else
                Return False
            End If
        End If
    End Function

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

    'UI : CLOSE
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_bataljual.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_bataljual.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub fr_jual_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            Else
                bt_bataljual.PerformClick()
            End If
        End If
    End Sub

    'UI : POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_rek_n.Focused Then
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
        If Char.IsLetterOrDigit(e.KeyChar) Then
            Dim x As TextBox
            Select Case popupstate
                Case "perkiraan" : x = in_rek_n
                Case Else : Exit Sub
            End Select
            PopUpSearchKeyPress(e, x)
        End If
    End Sub

    'UI : BUTTON
    Private Sub bt_simpanjual_Click(sender As Object, e As EventArgs) Handles bt_simpanjual.Click
        If removeCommaThousand(in_selisih.Text) <> 0 Then
            MessageBox.Show("Nilai yang dimasukan tidak seimbang, silahkan cek kembali.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If dgv_kas.RowCount = 0 Then
            MessageBox.Show("Entry jurnal masih kosong, harap isi terlebih dahulu.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If date_tglentry.Value.Day <> DateSerial(date_tglentry.Value.Year, date_tglentry.Value.Month + 1, 0).Day Then
            Dim _msg = MessageBox.Show("Tanggal input bukan akhir bulan/periode, lanjutkan proses input?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If _msg <> Windows.Forms.DialogResult.Yes Then Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim _resMsg As DialogResult = Windows.Forms.DialogResult.Yes
        'CHECK TANGGAL AKHIR
        If formstate <> InputState.Insert Then _resMsg = MessageBox.Show("Ubah data entry jurnal umum?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _resMsg = Windows.Forms.DialogResult.Yes Then
            If UserPrivChk(IIf(formstate = InputState.Insert, "INSERT", "UPDATE")) Then saveEntryJurnal()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_tbkas_Click(sender As Object, e As EventArgs) Handles bt_tbkas.Click
        If String.IsNullOrWhiteSpace(in_rek.Text) And String.IsNullOrEmpty(in_rek_n.Text) Then
            in_rek_n.Focus() : Exit Sub
        End If
        If in_debet.Value = 0 And in_kredit.Value = 0 Then
            in_debet.Focus() : Exit Sub
        End If
        If in_debet.Value <> 0 And in_kredit.Value <> 0 Then
            in_debet.Focus() : Exit Sub
        End If

        AddItem()
    End Sub

    'UI : INPUT
    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown, in_ket.KeyDown, in_rek.KeyDown, in_rek_n.KeyDown, in_rek_ket.KeyDown, in_debet.KeyDown, in_kredit.KeyDown
        If e.KeyCode = Keys.Enter Or (sender.Name = "in_rek_n" And e.KeyCode = Keys.Escape) Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub in_kode_KeyUp(sender As Object, e As KeyEventArgs) Handles in_kode.KeyUp
        keyshortenter(date_tglentry, e)
    End Sub

    Private Sub date_tglentry_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglentry.KeyUp
        keyshortenter(cb_ppn, e)
    End Sub

    Private Sub cb_ppn_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_ppn.KeyUp
        keyshortenter(in_ket, e)
    End Sub

    Private Sub cb_ppn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_ppn.KeyPress
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    Private Sub in_ket_KeyUp(sender As Object, e As KeyEventArgs) Handles in_ket.KeyUp
        keyshortenter(in_rek_n, e)
    End Sub

    Private Sub in_rek_KeyUp(sender As Object, e As KeyEventArgs) Handles in_rek.KeyUp
        keyshortenter(in_rek_n, e)
    End Sub

    Private Sub in_rek_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_rek_n.KeyUp
        Dim _kdcntrl As TextBox = in_rek
        Dim _nxtctrl As Control = in_rek_ket
        If sender.Text = "" And IsNothing(_kdcntrl) = False Then
            _kdcntrl.Text = ""
        End If

        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then dgv_listbarang.Focus()

        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then setPopUpResult()
            keyshortenter(_nxtctrl, e)
        Else
            If e.KeyCode <> Keys.Escape And sender.Readonly = False Then
                Dim x() As Keys = {Keys.Tab, Keys.CapsLock, Keys.End, Keys.Home, Keys.PageUp, Keys.PageDown}
                If Not x.Contains(e.KeyCode) And Not e.Shift And Not e.Control And Not e.Alt Then
                    If Not IsNothing(_kdcntrl) Then _kdcntrl.Text = ""
                End If
                If popPnl_barang.Visible = False Then popPnl_barang.Visible = True
                loadDataBRGPopup(popupstate, sender.Text)
            End If
        End If
    End Sub

    Private Sub in_rek_n_Enter(sender As Object, e As EventArgs) Handles in_rek_n.Enter
        If sender.ReadOnly = False And sender.Enabled Then
            popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            popupstate = "perkiraan"
            loadDataBRGPopup(popupstate, sender.Text)
        End If
    End Sub

    Private Sub in_rek_n_Leave(sender As Object, e As EventArgs) Handles in_rek_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_rek_ket_KeyUp(sender As Object, e As KeyEventArgs) Handles in_rek_ket.KeyUp
        keyshortenter(in_debet, e)
    End Sub

    Private Sub in_debet_KeyUp(sender As Object, e As KeyEventArgs) Handles in_debet.KeyUp
        keyshortenter(in_kredit, e)
    End Sub

    Private Sub in_kredit_KeyUp(sender As Object, e As KeyEventArgs) Handles in_kredit.KeyUp
        keyshortenter(bt_tbkas, e)
    End Sub

    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_debet.Enter, in_kredit.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_debet.Leave, in_kredit.Leave
        numericLostFocus(sender)
    End Sub

    'UI : DGV
    Private Sub dgv_kas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If dgv_kas.SelectedRows.Count = 1 And e.RowIndex >= 0 Then
            RemoveItem()
        End If
    End Sub

    'UI : MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanjual.PerformClick()
    End Sub

    Private Sub mn_delete_Click(sender As Object, e As EventArgs) Handles mn_delete.Click
        Me.Cursor = Cursors.WaitCursor
        If MessageBox.Show("Hapus data entry jurnal penutupan?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            deletEntryJurnal()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mn_duplicate_Click(sender As Object, e As EventArgs) Handles mn_duplicate.Click

    End Sub
End Class