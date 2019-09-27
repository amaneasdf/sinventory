Public Class fr_hutang_bayar
    Private popupstate As String = ""
    Private indexrowlist As Integer = 0
    Private indexrowbayar As Integer = 0

    Private selectedsup As String = ""
    Private _totaltitipan As Decimal = 0
    Private _status As String = Nothing

    Private _sisaHutang As Decimal = 0
    Public _totalhutang As Decimal = 0

    Private _prevfakturbayar As New KeyValuePair(Of String, Decimal)
    Private _prevIsTitip As New KeyValuePair(Of Boolean, Decimal)
    Private _prevSupplier As String = ""

    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
        View
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(NoFaktur As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Form Pembayaran Hutang : ph20190810902"

        formstate = FormSet
        With cb_bayar
            .DataSource = jenisBayar("hutang")
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With
        loadCBAkun(cb_bayar.SelectedValue)

        With cb_pajak
            .DataSource = jenis("bayar_pajak")
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With

        'With date_tgl_trans
        '    .Value = IIf(selectperiode.tglakhir >= Today, Today, selectperiode.tglakhir)
        '    .MaxDate = selectperiode.tglakhir
        '    .MinDate = selectperiode.tglawal
        'End With
        'date_bg_tgl.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        For Each x As DateTimePicker In {date_tgl_trans, date_bg_tgl}
            x.Value = IIf(DataListEndDate > Today, Today, DataListEndDate)
            x.MinDate = DataListStartDate
            x.MaxDate = DataListEndDate
        Next

        If Not FormSet = InputState.Insert Then
            Me.Text += NoFaktur
            Me.lbl_title.Text += " : " & NoFaktur
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            loadData(NoFaktur)
            If Not {0, 1}.Contains(_status) Or date_tgl_trans.Value < TransStartDate Then formstate = InputState.View
            If cb_bayar.SelectedValue = "BG" And in_tglpencairan.Text <> "" Then formstate = InputState.View
            dgv_bayar.ClearSelection()
        End If

        If formstate = InputState.View Then AllowEdit = False
        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        For Each cbx As ComboBox In {cb_akun, cb_bayar}
            cbx.Enabled = AllowInput
        Next
        For Each txt As TextBox In {in_ket, in_no_bg}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        For Each ctr As Control In {in_faktur, in_kredit}
            ctr.Visible = AllowInput
        Next
        For Each dtpick As DateTimePicker In {date_bg_tgl, date_tgl_trans}
            dtpick.Enabled = AllowInput
        Next
        For Each x As DataGridViewColumn In {bayar_kredit, bayar_sisahutang, bayar_saldoawal}
            x.DefaultCellStyle = dgvstyle_currency
        Next

        mn_cancel.Enabled = AllowInput
        bt_simpanperkiraan.Enabled = AllowInput
        bt_simpanperkiraan.Text = If(formstate = InputState.Edit, "Update", "Simpan")

        If Not formstate = InputState.Insert Then
            Dim _rowcount As Integer = dgv_bayar.RowCount
            in_no_bukti.ReadOnly = True
            in_supplier_n.ReadOnly = IIf(_rowcount > 0, True, False)
            cb_pajak.Enabled = IIf(_rowcount > 0, False, True)
        Else
            in_supplier_n.ReadOnly = IIf(AllowInput, False, True)
            cb_pajak.Enabled = AllowInput
        End If

        If AllowInput Then
            dgv_bayar.Location = New Point(12, 168) : dgv_bayar.Height = 158
            AddHandler dgv_bayar.CellDoubleClick, AddressOf dgv_bayar_CellDoubleClick
        Else
            dgv_bayar.Location = New Point(12, 128) : dgv_bayar.Height = 198
            RemoveHandler dgv_bayar.CellDoubleClick, AddressOf dgv_bayar_CellDoubleClick
        End If
    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        SetUpForm(Nothing, InputState.Insert, AllowInput)
        Me.Show()
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, AllowEdit As Boolean)
        SetUpForm(NoFaktur, InputState.Edit, AllowEdit)
        Me.Show()
    End Sub

    Public Sub doLoadView(NoFaktur As String)
        SetUpForm(NoFaktur, InputState.View, Nothing)
        Me.Show()
    End Sub

    'LOAD DATA
    Private Sub loadData(kode As String)
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim nobg As String = ""
                Dim tglbgcair As String = ""
                Dim akun As String = ""

                'LOAD HEADER
                q = "CALL getTransHeader('BHUTANG','{0}')"
                Using rdx As MySql.Data.MySqlClient.MySqlDataReader = x.ReadCommand(String.Format(q, kode))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_no_bukti.Text = rdx.Item("h_bayar_bukti")
                        in_supplier.Text = rdx.Item("h_bayar_supplier")
                        in_supplier_n.Text = rdx.Item("supplier_nama")
                        in_saldotitipan.Text = commaThousand(rdx.Item("titipan"))
                        cb_pajak.SelectedValue = rdx.Item("h_bayar_pajak")
                        cb_bayar.SelectedValue = rdx.Item("h_bayar_jenis_bayar")
                        akun = rdx.Item("h_bayar_akun")
                        date_tgl_trans.Value = rdx.Item("h_bayar_tgl_bayar")
                        date_bg_tgl.Value = rdx.Item("h_bayar_tgl_jt")
                        in_ket.Text = rdx.Item("h_bayar_ket")
                        nobg = rdx.Item("giro_no")
                        tglbgcair = rdx.Item("tgl")
                        in_potongan.Value = rdx.Item("h_bayar_potongan_nilai")
                        _status = rdx.Item("h_bayar_status")
                        txtRegAlias.Text = rdx.Item("h_bayar_reg_alias")
                        txtRegdate.Text = rdx.Item("h_bayar_reg_date")
                        txtUpdAlias.Text = rdx.Item("h_bayar_upd_alias")
                        txtUpdDate.Text = rdx.Item("h_bayar_upd_date")
                    End If
                End Using
                _prevSupplier = in_supplier.Text
                loadCBAkun(cb_bayar.SelectedValue) : cb_akun.SelectedValue = akun
                selectedsup = in_supplier.Text
                If nobg <> Nothing And cb_bayar.SelectedValue = "BG" Then in_no_bg.Enabled = True
                in_no_bg.Text = nobg
                in_tglpencairan.Text = tglbgcair

                'LOAD TABLE/ITEM
                q = "SELECT h_trans_faktur, DATE_FORMAT(hutang_tgl_jt,'%d/%m/%Y'), hutang_awal, h_trans_sisa, h_trans_nilaibayar " _
                    & "FROM data_hutang_bayar_trans LEFT JOIN data_hutang_awal ON h_trans_faktur=hutang_faktur AND hutang_status=1 " _
                    & "WHERE h_trans_status=1 AND h_trans_bukti='{0}'"
                Using dt = x.GetDataTable(String.Format(q, kode))
                    With dgv_bayar.Rows
                        For Each rows As DataRow In dt.Rows
                            Dim i = .Add
                            .Item(i).Cells("bayar_faktur").Value = rows.ItemArray(0)
                            .Item(i).Cells("bayar_jt").Value = rows.ItemArray(1)
                            .Item(i).Cells("bayar_saldoawal").Value = rows.ItemArray(2)
                            .Item(i).Cells("bayar_sisahutang").Value = rows.ItemArray(3)
                            .Item(i).Cells("bayar_kredit").Value = rows.ItemArray(4)
                        Next
                    End With
                End Using
                in_total.Text = commaThousand(countTotal())
                _prevIsTitip = New KeyValuePair(Of Boolean, Decimal)(IIf(cb_bayar.SelectedValue = "PIUTSUPL", True, False), removeCommaThousand(in_total.Text))
                If _prevIsTitip.Key Then
                    in_saldotitipan.Text = commaThousand(removeCommaThousand(in_saldotitipan.Text) + _prevIsTitip.Value)
                End If
                Select Case _status
                    Case 0 : in_status.Text = "Non-Aktif"
                    Case 1 : in_status.Text = "Aktif"
                    Case 2 : in_status.Text = "Batal"
                    Case 8 : in_status.Text = "On-Edit/NOT IMPLEMENTED!"
                    Case 9 : in_status.Text = "Delete"
                    Case Else : Exit Sub
                End Select
            End If
        End Using
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        setDoubleBuffered(Me.dgv_listbarang, True)
        Dim q As String : Dim dt As New DataTable
        With dgv_listbarang
            .DataSource = Nothing
            Select Case tipe
                Case "supplier"
                    q = "SELECT supplier_kode as Kode, supplier_nama as Nama, GetHutangSaldoAwal('titipan', supplier_kode, ADDDATE(CURDATE(),1)) sisaTitip " _
                        & "FROM data_supplier_master WHERE (supplier_nama LIKE '%{0}%' OR supplier_kode LIKE '%{0}%') AND supplier_status=1 LIMIT 250"
                    q = String.Format(q, param)
                Case "faktur"
                    q = "SELECT hutang_faktur Faktur, GetHutangSaldoAwal('hutang', hutang_faktur, ADDDATE('{0:yyyy-MM-dd}',1)) Sisa, " _
                        & "hutang_awal, hutang_tgl_jt as TglJatuhTempo " _
                        & "FROM data_hutang_awal " _
                        & "WHERE hutang_status=1 AND hutang_faktur LIKE '%{1}%' AND hutang_supplier='{2}' AND hutang_pajak='{3}' LIMIT 250"
                    q = String.Format(q, date_tgl_trans.Value, param, in_supplier.Text, cb_pajak.SelectedValue)
                Case Else
                    Exit Sub
            End Select
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    dt = x.GetDataTable(q)
                End If
            End Using

            .DataSource = dt
            If .ColumnCount >= 3 Then
                .Columns(0).Width = 100
                .Columns(1).Width = 150
                .Columns(2).Visible = False
                If tipe = "faktur" Then .Columns(1).DefaultCellStyle = dgvstyle_currency
                .Columns(.DisplayedColumnCount(False) - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        End With
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "supplier"
                    in_supplier.Text = .Cells(0).Value
                    in_supplier_n.Text = .Cells(1).Value
                    If formstate <> InputState.Insert And in_supplier.Text = _prevSupplier And _prevIsTitip.Key = True Then
                        in_saldotitipan.Text = commaThousand(.Cells(2).Value + _prevIsTitip.Value)
                    Else
                        in_saldotitipan.Text = commaThousand(.Cells(2).Value)
                    End If
                    cb_bayar.Focus()
                Case "faktur"
                    in_faktur.Text = .Cells(0).Value
                    Dim _sisahutang = .Cells(1).Value
                    If formstate <> InputState.Insert And _prevfakturbayar.Key = in_faktur.Text Then
                        in_sisafaktur.Text = commaThousand(_sisahutang + _prevfakturbayar.Value)
                    Else
                        in_sisafaktur.Text = commaThousand(.Cells(1).Value)
                    End If
                    _totalhutang = .Cells(2).Value
                    in_tgl_jtfaktur.Text = .Cells(3).Value
                    in_kredit.Focus()
                Case Else
                    Exit Sub
            End Select

        End With
        popPnl_barang.Visible = False
    End Sub

    Private Function checkFaktur(kodeFaktur As String, ByRef Msg As String) As Boolean
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If
        Dim q As String = ""
        Dim retval As Boolean = False

        Try
            Using x = MainConnection : x.Open()
                If x.ConnectionState = ConnectionState.Open Then
                    Dim getsupplier As New KeyValuePair(Of Boolean, String)
                    q = "SELECT hutang_supplier FROM data_hutang_awal WHERE hutang_faktur='{0}' AND hutang_status=1"
                    Using rdx = x.ReadCommand(String.Format(q, kodeFaktur), CommandBehavior.SingleRow)
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            If in_supplier.Text = "" Then
                                getsupplier = New KeyValuePair(Of Boolean, String)(True, rdx.Item("hutang_supplier"))
                                retval = True
                            ElseIf in_supplier.Text <> rdx.Item("hutang_supplier") Then
                                in_faktur.Focus()
                                retval = False
                                Msg = "No.Faktur yg diinput tidak sesuai dg supplier"
                            Else
                                retval = True
                            End If
                        Else
                            retval = False
                            Msg = "No.Faktur yg diinput tidak sesuai"
                        End If
                    End Using
                End If
            End Using
            Return retval
        Catch ex As Exception
            logError(ex, True)
            MessageBox.Show(String.Format("Error. {1}: {0}", ex.GetType.ToString & ex.Message, "Terjadi Kesalahan"))
            Return False
        End Try
    End Function

    'ITEM ADD/REMOVE
    Private Sub textToDGV()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim _faktur_sw = True
        Dim _kredit_sw = True
        Dim msg As String = ""
        Dim q As String = ""

        If in_faktur.Text = "" Then
            _faktur_sw = False : msg = "Kode faktur yang ingin dibayarkan belum terisi."
        ElseIf Trim(in_faktur.Text) <> "" And in_tgl_jtfaktur.Text = "" Then
            _faktur_sw = False : msg = "Faktur " & in_faktur.Text & " tidak dapat ditemukan."
        Else
            q = "SELECT hutang_pajak, hutang_status, hutang_status_lunas, hutang_supplier FROM data_hutang_awal WHERE hutang_faktur='{0}'"
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim _pajak, _status, _supplier As String
                    Using rdx = x.ReadCommand(String.Format(q, in_faktur.Text))
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            _pajak = rdx.Item(0)
                            _status = IIf(rdx.Item(2) <> 0, 9, rdx.Item(1))
                            _supplier = rdx.Item(3)

                            If _supplier <> in_supplier.Text Then
                                _faktur_sw = False : msg = "Kode Supplier tidak sesuai dengan faktur."
                            ElseIf _pajak <> cb_pajak.SelectedValue Then
                                _faktur_sw = False : msg = "Kategori faktur tidak sesuai dengan kategori pembayaran terpilih."
                            ElseIf _status <> 1 Then
                                _faktur_sw = False : msg = "Faktur " & in_faktur.Text & " tidak dapat ditemukan atau sudah lunas."
                            End If
                        Else
                            _faktur_sw = False : msg = "Faktur " & in_faktur.Text & " tidak dapat ditemukan."
                        End If
                    End Using
                Else
                    _faktur_sw = False : msg = "Tidak dapat terhubung ke database."
                End If
            End Using
        End If

        If _faktur_sw = False Then
            MessageBox.Show("Faktur tidak sesuai." & Environment.NewLine & msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_faktur.Focus() : Exit Sub
        End If

        If in_kredit.Value > removeCommaThousand(in_sisafaktur.Text) Then
            MessageBox.Show("Saldo Pembayaran lebih besar dari sisa")
            in_kredit.Focus() : Exit Sub
        End If
        If in_kredit.Value = 0 Then
            in_kredit.Focus() : Exit Sub
        End If
        If cb_bayar.SelectedValue = "PIUTSUPL" And removeCommaThousand(in_saldotitipan.Text) < in_kredit.Value + removeCommaThousand(in_total.Text) Then
            MessageBox.Show("Saldo Titipan tidak Mencukupi")
            in_kredit.Focus() : Exit Sub
        End If

        If formstate <> InputState.Insert Then _prevfakturbayar = New KeyValuePair(Of String, Decimal)
        dgv_bayar.Rows.Add(in_faktur.Text, in_tgl_jtfaktur.Text, _totalhutang, removeCommaThousand(in_sisafaktur.Text), in_kredit.Value)

        clearInput("bayar")
        in_total.Text = commaThousand(countTotal())

        in_supplier_n.ReadOnly = True
        cb_pajak.Enabled = False
    End Sub

    Private Sub dgvToText()
        Dim idx As Integer = 0
        With dgv_bayar.SelectedRows.Item(0)
            in_faktur.Text = .Cells("bayar_faktur").Value
            in_tgl_jtfaktur.Text = .Cells("bayar_jt").Value
            _totalhutang = .Cells("bayar_saldoawal").Value
            in_kredit.Value = .Cells("bayar_kredit").Value

            Dim _sisahutang = GetHutang(in_faktur.Text)
            If formstate <> InputState.Insert Then
                in_sisafaktur.Text = commaThousand(_sisahutang + in_kredit.Value)
                _prevfakturbayar = New KeyValuePair(Of String, Decimal)(in_faktur.Text, in_kredit.Value)
            Else
                in_sisafaktur.Text = commaThousand(_sisahutang)
            End If
            idx = .Index
        End With
        dgv_bayar.Rows.RemoveAt(idx)

        in_total.Text = commaThousand(countTotal())

        If dgv_bayar.RowCount = 0 Then
            in_supplier_n.ReadOnly = False
            cb_pajak.Enabled = True
        End If
    End Sub

    Private Function countTotal() As Decimal
        Dim res As Decimal = 0

        For Each row As DataGridViewRow In dgv_bayar.Rows
            res += row.Cells("bayar_kredit").Value
        Next

        res -= in_potongan.Value

        Return res
    End Function

    'COMBO AKUN BAYAR
    Private Sub loadCBAkun(kode As String)
        Dim q As String = "SELECT perk_kode as 'Value',perk_nama_akun as 'Text' FROM data_perkiraan WHERE perk_status=1 AND perk_parent='{0}'"
        Dim kodeparent As String = "1101"
        With cb_akun
            .DataSource = Nothing
            Select Case kode
                Case "TUNAI"
                    kodeparent = "1101"
                    .DataSource = getDataTablefromDB(String.Format(q, kodeparent))
                Case "BG", "TRANSFER"
                    kodeparent = "1102"
                    .DataSource = getDataTablefromDB(String.Format(q, kodeparent))
                Case "PIUTSUPL"
                    kodeparent = "1105"
                    .DataSource = getDataTablefromDB(String.Format(q, kodeparent) & " AND perk_kode='110502'")
                Case Else
                    Exit Sub
            End Select
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With
    End Sub

    Private Sub clearInput(tipe As String)
        Select Case tipe
            Case "bayar"
                in_faktur.Clear()
                in_sisafaktur.Clear()
                in_tgl_jtfaktur.Clear()
                _totalhutang = 0
                in_kredit.Value = 0
                'Case "all"
                '    For Each x As TextBox In {in_faktur, in_supplier, in_supplier_n, in_no_bukti, in_bg_no, txtRegAlias, txtRegdate, txtUpdAlias, txtUpdDate}
                '        x.Clear()
                '    Next
                '    For Each dgv As DataGridView In {dgv_bayar, dgv_listbarang}
                '        dgv.Rows.Clear()
                '    Next
                '    For Each nu As NumericUpDown In {in_kredit}
                '        nu.Value = 0
                '        nu.Maximum = 999999999999
                '    Next
                '    With date_tgl_trans
                '        .Value = DateSerial(selectedperiode.Year, selectedperiode.Month, date_tgl_trans.Value.Day)
                '        .MaxDate = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)
                '        .MinDate = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
                '    End With
                '    date_bg_tgl.Value = DateSerial(selectedperiode.Year, selectedperiode.Month, date_tgl_trans.Value.Day)
            Case Else
                Exit Sub
        End Select
    End Sub

    'SAVE DATA
    Private Function CheckInput()
        Dim _faktur_sw As Boolean = True
        Dim _msgList As New List(Of String)

        Try
            For Each rows As DataGridViewRow In dgv_bayar.Rows
                Dim msg As String = ""
                Dim kode As String = rows.Cells("bayar_faktur").Value
                Dim nilaibayar As Decimal = rows.Cells("bayar_kredit").Value
                dgv_bayar.Rows(rows.Index).DefaultCellStyle.BackColor = Color.White

                If checkFaktur(kode, msg) = False Then
                    dgv_bayar.Rows(rows.Index).DefaultCellStyle.BackColor = Color.Yellow
                    _faktur_sw = False
                    _msgList.Add(msg & " : " & kode)
                End If
            Next
            If Not _faktur_sw Then
                MessageBox.Show("Data yang diinput tidak sesuai" & Environment.NewLine & String.Join(Environment.NewLine, _msgList),
                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            dgv_bayar.ClearSelection()
        Catch ex As Exception
            logError(ex, True)
            MessageBox.Show("Terjadi Kesalahan saat melakukan pengecekan input" & Environment.NewLine & "ERROR : " & ex.Message,
                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            _faktur_sw = False
        End Try
        Return _faktur_sw
    End Function

    Private Sub saveBayar()
        Dim q As String = ""
        Dim querycheck As Boolean = False
        Dim dataHead As String()
        Dim data1, data2 As String()
        Dim queryArr As New List(Of String)

        '==========================================================================================================================
        'CHECK INPUT
        If Not CheckInput() Then Exit Sub

        '==========================================================================================================================
        'INPUT HEADER
        dataHead = {
            "h_bayar_pajak='" & cb_pajak.SelectedValue & "'",
            "h_bayar_tgl_bayar='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
            "h_bayar_tgl_jt='" & date_bg_tgl.Value.ToString("yyyy-MM-dd") & "'",
            "h_bayar_supplier='" & in_supplier.Text & "'",
            "h_bayar_jenis_bayar='" & cb_bayar.SelectedValue & "'",
            "h_bayar_akun='" & cb_akun.SelectedValue & "'",
            "h_bayar_potongan_nilai=" & in_potongan.Value.ToString.Replace(",", "."),
            "h_bayar_ket='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
            "h_bayar_status='1'"
            }
        data2 = {
            "h_bayar_giro_no='" & in_no_bg.Text & "'"
            }
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                If formstate = InputState.Insert Then
                    If String.IsNullOrWhiteSpace(in_no_bukti.Text) Then
                        Dim i As Integer = 0 : Dim format As String = "D3"
                        q = "SELECT IFNULL(MAX(SUBSTRING(h_bayar_bukti, 11)), 0) FROM data_hutang_bayar " _
                            & "WHERE h_bayar_bukti LIKE 'PH{0:yyyyMMdd}%' AND SUBSTRING(h_bayar_bukti,11) REGEXP '^[0-9]+$'"
                        Try
                            i = CInt(x.ExecScalar(String.Format(q, date_tgl_trans.Value)))
                            format = IIf(i + 1 > 999, "D" & (i + 1).ToString.Length, "D3")
                            in_no_bukti.Text = String.Format("PH{0:yyyyMMdd}", date_tgl_trans.Value) & (i + 1).ToString(format)
                        Catch ex As Exception
                            MessageBox.Show("Terjadi kesalahan dalam melakukan proses penyimpanan data." & Environment.NewLine & ex.Message,
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            logError(ex, True) : Exit Sub
                        End Try

                    Else
                        Dim i As Integer = 0
                        q = "SELECT COUNT(h_bayar_bukti) FROM data_hutang_bayar WHERE h_bayar_bukti='{0}'"
                        Try
                            i = Integer.Parse(x.ExecScalar(String.Format(q, in_no_bukti.Text)))
                        Catch ex As Exception
                            MessageBox.Show("Terjadi kesalahan dalam melakukan proses penyimpanan data." & Environment.NewLine & ex.Message,
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            logError(ex, True) : Exit Sub
                        End Try
                        If i <> 0 Then
                            MessageBox.Show("Kode bukti " & in_no_bukti.Text & " sudah pernah di inputkan ke database.",
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            in_no_bukti.Focus() : Exit Sub
                        End If
                    End If

                    q = "INSERT INTO data_hutang_bayar SET h_bayar_bukti='{0}',{1},h_bayar_reg_date=NOW(),h_bayar_reg_alias='{2}'"
                Else
                    q = "UPDATE data_hutang_bayar SET {1},h_bayar_upd_date=NOW(),h_bayar_upd_alias='{2}' WHERE h_bayar_bukti='{0}'"
                End If
                queryArr.Add(String.Format(
                                q, mysqlQueryFriendlyStringFeed(in_no_bukti.Text),
                                String.Join(",", dataHead) & IIf(cb_bayar.SelectedValue <> "BG", "", "," & String.Join(",", data2)),
                                loggeduser.user_id)
                            )

                '==========================================================================================================================
                'INPUT BAYAR
                q = "UPDATE data_hutang_bayar_trans SET h_trans_status=9 WHERE h_trans_bukti='{0}'"
                queryArr.Add(String.Format(q, mysqlQueryFriendlyStringFeed(in_no_bukti.Text)))

                For Each rows As DataGridViewRow In dgv_bayar.Rows
                    q = "INSERT INTO data_hutang_bayar_trans SET h_trans_bukti='{0}', h_trans_faktur='{1}',{2}"
                    data1 = {
                        "h_trans_sisa=" & Decimal.Parse(rows.Cells("bayar_sisahutang").Value).ToString.Replace(",", "."),
                        "h_trans_nilaibayar=" & Decimal.Parse(rows.Cells("bayar_kredit").Value).ToString.Replace(",", "."),
                        "h_trans_nobg='" & IIf(cb_bayar.SelectedValue = "BG", in_no_bg.Text, "") & "'",
                        "h_trans_reg_date=NOW()",
                        "h_trans_reg_alias='" & loggeduser.user_id & "'",
                        "h_trans_status='1'"
                        }
                    queryArr.Add(String.Format(q, mysqlQueryFriendlyStringFeed(in_no_bukti.Text), rows.Cells(0).Value, String.Join(",", data1)))
                Next
                '==========================================================================================================================

                '==========================================================================================================================
                q = "CALL transBayarHutangFin('{0}','{1}')"
                queryArr.Add(String.Format(q, mysqlQueryFriendlyStringFeed(in_no_bukti.Text), loggeduser.user_id))
                '==========================================================================================================================

                '==========================================================================================================================
                'BEGIN TRANSACTION
                querycheck = x.TransactCommand(queryArr)
                '==========================================================================================================================

                If querycheck Then
                    MessageBox.Show("Data pembayaran tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pghutangbayar, pghutangawal, pghutangbgo})
                    Me.Close()
                Else
                    MessageBox.Show("Data pembayaran tidak dapat tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'CANCEL DATA
    Private Sub cancelData(kodebayar As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim q As String = ""
        Dim queryArr As New List(Of String)
        Dim queryCk As Boolean = False
        Dim ValidUid As String = ""


        If _status <> 2 Then
            If Not TransConfirmValid(ValidUid) Then Exit Sub

            Me.Cursor = Cursors.WaitCursor

            q = "UPDATE data_hutang_bayar SET h_bayar_status=2, h_bayar_upd_date=NOW(), h_bayar_upd_alias='{1}' WHERE h_bayar_bukti='{0}'"
            queryArr.Add(String.Format(q, kodebayar, loggeduser.user_id))
            q = "CALL transBayarHutangFin('{0}','{1}')"
            queryArr.Add(String.Format(q, kodebayar, loggeduser.user_id))
            'ADD LOG VALIDASI

            '==========================================================================================================================
            'BEGIN TRANSACTION
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    queryCk = x.TransactCommand(queryArr)

                    If queryCk = False Then
                        MessageBox.Show("Pembatalan transaksi pembayaran gagal.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        MessageBox.Show("Transaksi pembayaran berhasil dibatalkan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        doRefreshTab({pgpiutangbayar, pgpiutangawal}) : Me.Close()
                    End If

                Else
                    MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
            '==========================================================================================================================

            Me.Cursor = Cursors.Default
        Else
            MessageBox.Show("Pembatalan transaksi tidak dapat dilakukan")
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

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalperkiraan.Click
        'If MessageBox.Show("Tutup Form?", "Pembayaran Hutang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        bt_cl.PerformClick()
        'End If
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub fr_jual_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            Else
                bt_batalperkiraan.PerformClick()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    '------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanperkiraan.PerformClick()
    End Sub

    Private Sub mn_cancel_Click(sender As Object, e As EventArgs) Handles mn_cancel.Click
        If Not String.IsNullOrWhiteSpace(in_no_bukti.Text) Then
            If MessageBox.Show("Batalkan pembayaran?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cancelData(in_no_bukti.Text)
            End If
        End If
    End Sub

    'UI : POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_supplier_n.Focused = True Or in_faktur.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub dgv_listbarang_Cellenter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellEnter
        If e.RowIndex >= 0 Then
            indexrowlist = e.RowIndex
        End If
    End Sub

    Private Sub dgv_listbarang_CellContentDBLClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellDoubleClick
        If e.RowIndex >= 0 Then
            indexrowlist = e.RowIndex
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
            Case "supplier" : x = in_supplier_n
            Case "faktur" : x = in_faktur
            Case Else : Exit Sub
        End Select
        PopUpSearchKeyPress(e, x)
    End Sub

    'UI : numeric
    Private Sub in_debet_Enter(sender As Object, e As EventArgs) Handles in_kredit.Enter, in_potongan.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_debet_Leave(sender As Object, e As EventArgs) Handles in_kredit.Leave, in_potongan.Leave
        numericLostFocus(sender)
    End Sub

    '------------- cb prevent input
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_bayar.KeyPress, cb_akun.KeyPress
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    '------------- load
    Private Sub fr_hutang_bayar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv_bayar.ClearSelection()
    End Sub

    '------------ save
    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click
        'CHECK TANGGAL TRANSAKSI
        If date_tgl_trans.Value < TransStartDate Then
            MessageBox.Show("Tanggal pembayaran tidak bisa kurang dari periode aktif. " & TransStartDate.ToString("(MMMM yyyy)"),
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            date_tgl_trans.Focus() : Exit Sub
        End If

        'CHECK INPUT
        If String.IsNullOrWhiteSpace(in_supplier.Text) Then
            MessageBox.Show("Supplier belum di input.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_supplier.Focus() : Exit Sub
        End If
        If dgv_bayar.Rows.Count = 0 Then
            MessageBox.Show("Pembayaran belum di input.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_faktur.Focus() : Exit Sub
        End If

        'CHECK INPUT GIRO
        If cb_bayar.SelectedValue = "BG" And String.IsNullOrWhiteSpace(in_no_bg.Text) Then
            MessageBox.Show("Nomor Giro belum di input.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_no_bg.Focus() : Exit Sub
        End If
        If date_bg_tgl.Value < date_tgl_trans.Value Then
            MessageBox.Show("Tanggal jatuhtempo/efektif giro lebih kecil daripada tanggal transaksi.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            date_bg_tgl.Focus() : Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim _askRes As DialogResult = Windows.Forms.DialogResult.Yes
        If Not formstate = InputState.Insert Then _askRes = MessageBox.Show("Simpan perubahan data pembayaran?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _askRes = Windows.Forms.DialogResult.Yes Then saveBayar()
        Me.Cursor = Cursors.Default
    End Sub

    'UI : INPUT
    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_supplier_n.Enter, in_faktur.Enter
        If sender.ReadOnly = False And sender.Enabled Then
            popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
            If popPnl_barang.Visible = False Then popPnl_barang.Visible = True
            Select Case sender.Name
                Case "in_supplier_n" : popupstate = "supplier"
                Case "in_faktur" : popupstate = "faktur"
                Case Else : Exit Sub
            End Select
            loadDataBRGPopup(popupstate, sender.Text)
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_supplier_n.Leave, in_faktur.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyDown, in_faktur.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then e.SuppressKeyPress = True
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyUp, in_faktur.KeyUp
        Dim _next As Control : Dim _id As TextBox
        Select Case sender.Name.ToString
            Case "in_supplier_n" : _next = cb_pajak : _id = in_supplier
            Case "in_faktur" : _next = in_kredit : _id = Nothing
            Case Else : Exit Sub
        End Select
        Dim _x = PopUpSearchInputHandle_inputKeyup(e, sender, _id, popPnl_barang, dgv_listbarang)
        For Each _resp As String In _x
            Select Case _resp
                Case "set" : setPopUpResult()
                Case "next" : keyshortenter(_next, e)
                Case "clear"
                    in_tgl_jtfaktur.Clear() : in_sisafaktur.Clear() : _totalhutang = 0
                    If sender.Name = "in_supplier_n" Then in_faktur.Clear()
                Case "load" : loadDataBRGPopup(popupstate, sender.Text)
            End Select
        Next
    End Sub

    Private Sub in_sales_n_MouseClick(sender As Object, e As MouseEventArgs) Handles in_supplier_n.MouseClick, in_faktur.MouseClick
        If popPnl_barang.Visible = False And sender.ReadOnly = False Then
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub cb_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_pajak.KeyDown
        keyshortenter(cb_bayar, e)
    End Sub

    Private Sub cb_bayar_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_bayar.KeyDown
        keyshortenter(cb_akun, e)
    End Sub

    Private Sub cb_bayar_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_bayar.SelectionChangeCommitted
        If cb_bayar.SelectedValue = "BG" Then
            in_no_bg.Enabled = True
        Else
            in_no_bg.Enabled = False
        End If
        loadCBAkun(cb_bayar.SelectedValue)
    End Sub

    Private Sub cb_akun_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_akun.KeyDown
        keyshortenter(date_tgl_trans, e)
    End Sub

    Private Sub date_tgl_trans_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_trans.KeyDown
        keyshortenter(date_bg_tgl, e)
    End Sub

    Private Sub date_bg_tgl_KeyDown(sender As Object, e As KeyEventArgs) Handles date_bg_tgl.KeyUp
        keyshortenter(in_faktur, e)
    End Sub

    '----------- Input Bayar
    Private Sub in_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kredit.KeyDown
        keyshortenter(bt_tbbayar, e)
    End Sub

    Private Sub bt_tbbayar_Click(sender As Object, e As EventArgs) Handles bt_tbbayar.Click
        textToDGV()
    End Sub

    'UI : DGV
    Private Sub dgv_bayar_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex > -1 Then dgvToText()
    End Sub

    Private Sub fr_hutang_bayar_Click(sender As Object, e As EventArgs) Handles MyBase.Click, Panel1.Click, Panel2.Click, pnl_content.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub

    'FOOTER
    Private Sub in_no_bg_KeyDown(sender As Object, e As KeyEventArgs) Handles in_no_bg.KeyDown
        keyshortenter(in_ket, e)
    End Sub

    Private Sub in_potongan_KeyDown(sender As Object, e As KeyEventArgs) Handles in_potongan.KeyDown
        keyshortenter(bt_simpanperkiraan, e)
    End Sub

    Private Sub in_potongan_ValueChanged(sender As Object, e As EventArgs) Handles in_potongan.ValueChanged
        in_total.Text = commaThousand(countTotal())
    End Sub
End Class