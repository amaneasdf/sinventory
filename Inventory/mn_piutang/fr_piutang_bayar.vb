Public Class fr_piutang_bayar
    Private _popUpPos As String = ""

    Private selectedcusto As String = ""
    Private selectedsales As String = ""
    Private _totaltitipan As Decimal = 0
    Private _statusgiro As String = "1"
    Private _status As String = 1

    Private _sisaHutang As Decimal = 0
    Public _totalhutang As Decimal = 0

    Private _prevfakturbayar As New KeyValuePair(Of String, Decimal)
    Private _prevIsTitip As New KeyValuePair(Of Boolean, Decimal)
    Private _prevCusto As String = ""

    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
        View
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(NoFaktur As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Form Pembayaran Hutang : pp20190810902"

        formstate = FormSet
        With cb_bayar
            .DataSource = jenisBayar("piutang")
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
        Else
            mn_proses.Enabled = False
        End If

        If formstate = InputState.View Then AllowEdit = False
        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        Dim _ReadOnly As Boolean = If(AllowInput, False, True)
        For Each cbx As ComboBox In {cb_akun, cb_bayar}
            cbx.Enabled = AllowInput
        Next
        For Each txt As TextBox In {in_ket, in_bg_no, in_bank}
            txt.ReadOnly = _ReadOnly
        Next
        For Each ctr As Control In {in_faktur, in_kredit}
            ctr.Visible = AllowInput
        Next
        For Each dtpick As DateTimePicker In {date_bg_tgl, date_tgl_trans}
            dtpick.Enabled = AllowInput
        Next
        For Each x As DataGridViewColumn In {bayar_kredit, bayar_sisapiutang, bayar_totalpiutang}
            x.DefaultCellStyle = dgvstyle_currency
        Next

        bt_simpancusto.Enabled = AllowInput
        bt_simpancusto.Text = If(formstate = InputState.Edit, "Update", "Simpan")
        in_no_bukti.ReadOnly = If(formstate = InputState.Insert, _ReadOnly, True)
        If formstate = InputState.Edit Then
            Dim _rowcount As Integer = dgv_bayar.RowCount
            mn_proses.Enabled = IIf(_status = 0 And Not date_tgl_trans.Value < TransStartDate, loggeduser.validasi_trans, False)
            in_custo_n.ReadOnly = IIf(dgv_bayar.RowCount > 0, True, _ReadOnly)
            in_sales_n.ReadOnly = IIf(dgv_bayar.RowCount > 0, True, _ReadOnly)
            cb_pajak.Enabled = IIf(_rowcount > 0, False, True)
        Else
            mn_proses.Enabled = False
            in_custo_n.ReadOnly = _ReadOnly
            in_sales_n.ReadOnly = _ReadOnly
            cb_pajak.Enabled = AllowInput
        End If

        bt_proses.Visible = mn_proses.Enabled
        mn_delete.Enabled = IIf(formstate = InputState.Insert, False, AllowInput)
        mn_save.Enabled = AllowInput
        mn_print.Visible = False

        If AllowInput Then
            dgv_bayar.Location = New Point(12, 184) : dgv_bayar.Height = 152
            AddHandler dgv_bayar.CellDoubleClick, AddressOf dgv_bayar_CellDoubleClick
        Else
            dgv_bayar.Location = New Point(12, 145) : dgv_bayar.Height = 191
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
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Dim nobg As String = ""
                Dim tglbgcair As String = ""
                Dim akun As String = ""

                'LOAD HEADER
                q = "CALL getTransHeader('BPIUTANG','{0}')"
                Using rdx As MySql.Data.MySqlClient.MySqlDataReader = x.ReadCommand(String.Format(q, kode))
                    If rdx.Read And rdx.HasRows Then
                        in_no_bukti.Text = kode
                        in_sales.Text = rdx.Item("p_bayar_sales")
                        in_sales_n.Text = rdx.Item("salesman_nama")
                        in_custo.Text = rdx.Item("p_bayar_custo")
                        in_custo_n.Text = rdx.Item("customer_nama")
                        in_saldotitipan.Text = commaThousand(rdx.Item("titipan"))
                        cb_pajak.SelectedValue = rdx.Item("p_bayar_pajak")
                        cb_bayar.SelectedValue = rdx.Item("p_bayar_jenisbayar")
                        akun = rdx.Item("p_bayar_akun")
                        date_tgl_trans.Value = rdx.Item("p_bayar_tanggal_bayar")
                        date_bg_tgl.Value = rdx.Item("p_bayar_tanggal_jt")
                        nobg = rdx.Item("giro_no")
                        in_bank.Text = rdx.Item("giro_bank")
                        tglbgcair = rdx.Item("tgl")
                        in_potongan.Value = rdx.Item("p_bayar_potongan_nilai")
                        in_ket.Text = rdx.Item("p_bayar_ket")
                        _status = rdx.Item("p_bayar_status")
                        txtRegAlias.Text = rdx.Item("p_bayar_reg_alias")
                        txtRegdate.Text = rdx.Item("p_bayar_reg_date")
                        txtUpdAlias.Text = rdx.Item("p_bayar_upd_alias")
                        txtUpdDate.Text = rdx.Item("p_bayar_upd_date")
                        'Else
                        '    MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '    'Exit Sub
                        '    Me.Close()
                    End If
                End Using
                _prevCusto = in_custo.Text
                loadCBAkun(cb_bayar.SelectedValue) : cb_akun.SelectedValue = akun
                selectedcusto = in_custo.Text
                If nobg <> Nothing And cb_bayar.SelectedValue = "BG" Then : in_bg_no.Enabled = True : in_bank.Enabled = True : End If
                in_bg_no.Text = nobg
                in_tglpencairan.Text = tglbgcair

                'LOAD TABLE/ITEM
                q = "SELECT p_trans_kode_piutang, piutang_jt, piutang_awal, p_trans_sisa, p_trans_nilaibayar " _
                    & "FROM data_piutang_bayar_trans LEFT JOIN data_piutang_awal ON piutang_faktur=p_trans_kode_piutang AND piutang_status=1 " _
                    & "WHERE p_trans_status=1 AND p_trans_bukti='{0}'"
                Using dt = x.GetDataTable(String.Format(q, kode))
                    With dgv_bayar.Rows
                        For Each rows As DataRow In dt.Rows
                            Dim i = .Add
                            .Item(i).Cells("bayar_faktur").Value = rows.ItemArray(0)
                            .Item(i).Cells("bayar_tgljt").Value = rows.ItemArray(1)
                            .Item(i).Cells("bayar_totalpiutang").Value = rows.ItemArray(2)
                            .Item(i).Cells("bayar_sisapiutang").Value = rows.ItemArray(3)
                            .Item(i).Cells("bayar_kredit").Value = rows.ItemArray(4)
                        Next
                    End With
                    dgv_bayar.Columns(1).DefaultCellStyle = dgvstyle_date
                End Using
                in_total.Text = commaThousand(countTotal())
                _prevIsTitip = New KeyValuePair(Of Boolean, Decimal)(IIf(cb_bayar.SelectedValue = "PIUTSUPL", True, False), removeCommaThousand(in_total.Text))
                If _prevIsTitip.Key Then
                    in_saldotitipan.Text = commaThousand(removeCommaThousand(in_saldotitipan.Text) + If(_status = 1, _prevIsTitip.Value, 0))
                End If
                Select Case _status
                    Case 0 : in_status.Text = "Non-Aktif"
                    Case 1 : in_status.Text = "Aktif"
                    Case 2 : in_status.Text = "Batal"
                    Case 8 : in_status.Text = "On-Edit/NOT IMPLEMENTED!"
                    Case 9 : in_status.Text = "Delete"
                    Case Else : Exit Sub
                End Select
            Else
                MessageBox.Show("Tidak dapat terhubung ke server", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End Using

    End Sub

    'ADD INPUT FROM TEXTBOX TO DGV
    Private Sub textToDGV()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim _faktur_sw = True
        Dim _kredit_sw = True
        Dim msg As String = ""
        Dim q As String = ""

        in_faktur.Text = Trim(in_faktur.Text)
        If in_faktur.Text = "" Then
            _faktur_sw = False
            msg = "Kode faktur yang ingin dibayarkan belum terisi."
        ElseIf Trim(in_faktur.Text) <> "" And in_tgl_jtfaktur.Text = "" Then
            _faktur_sw = False
            msg = "Faktur " & in_faktur.Text & " tidak dapat ditemukan."
        Else
            q = "SELECT piutang_pajak, piutang_status, piutang_status_lunas, piutang_sales, piutang_custo FROM data_piutang_awal WHERE piutang_faktur='{0}'"
            Using x = MainConnection
                x.Open()
                If x.ConnectionState = ConnectionState.Open Then
                    Dim _jenispajak As String = ""
                    Dim _status As String = ""
                    Dim _customer As String = ""
                    Dim _salesman As String = ""
                    Using rdx = x.ReadCommand(String.Format(q, in_faktur.Text))
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            _jenispajak = rdx.Item(0)
                            _status = IIf(rdx.Item(1) < 9, rdx.Item(2), 9)
                            _salesman = rdx.Item(3)
                            _customer = rdx.Item(4)

                            If _salesman <> in_sales.Text Then
                                _faktur_sw = False : msg = "Kode salesman tidak sesuai dengan faktur."
                            ElseIf _customer <> in_custo.Text Then
                                _faktur_sw = False : msg = "Kode customer tidak sesuai dengan faktur."
                            ElseIf cb_pajak.SelectedValue <> _jenispajak Then
                                _faktur_sw = False : msg = "Kategori faktur tidak sesuai dengan kategori pembayaran terpilih."
                            Else
                                If _prevfakturbayar.Key = in_faktur.Text And formstate = InputState.Edit Then
                                    _faktur_sw = True
                                Else
                                    If _status <> 0 Then
                                        _faktur_sw = False : msg = "Faktur " & in_faktur.Text & " tidak dapat ditemukan atau sudah lunas."
                                    End If
                                End If
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

        If in_kredit.Value = 0 Then
            in_kredit.Focus() : Exit Sub
        End If

        If in_kredit.Value > removeCommaThousand(in_sisafaktur.Text) Then
            MessageBox.Show("Saldo Pembayaran lebih besar dari sisa") : in_kredit.Focus()
            Exit Sub
        End If
        If cb_bayar.SelectedValue = "PIUTSUPL" And removeCommaThousand(in_saldotitipan.Text) < in_kredit.Value + removeCommaThousand(in_total.Text) Then
            MessageBox.Show("Saldo Titipan tidak Mencukupi") : in_kredit.Focus()
            Exit Sub
        End If

        If formstate <> InputState.Insert Then
            _prevfakturbayar = New KeyValuePair(Of String, Decimal)
        End If
        dgv_bayar.Rows.Add(in_faktur.Text, in_tgl_jtfaktur.Text, _totalhutang, removeCommaThousand(in_sisafaktur.Text), in_kredit.Value)
        clearInput()
        in_total.Text = commaThousand(countTotal)
        in_custo_n.ReadOnly = True
        in_sales_n.ReadOnly = True
        cb_pajak.Enabled = False
    End Sub

    'LOAD SELECTED DGV ROW TO TEXTBOX INPUT
    Private Sub dgvToText()
        Dim idx As Integer = 0

        With dgv_bayar.SelectedRows.Item(0)
            in_faktur.Text = .Cells("bayar_faktur").Value
            in_kredit.Value = .Cells("bayar_kredit").Value
            in_tgl_jtfaktur.Text = .Cells("bayar_tgljt").Value
            _totalhutang = .Cells("bayar_totalpiutang").Value

            Dim _sisahutang = GetPiutang(in_faktur.Text)
            If formstate <> InputState.Insert Then
                in_sisafaktur.Text = commaThousand(_sisahutang + in_kredit.Value)
                _prevfakturbayar = New KeyValuePair(Of String, Decimal)(in_faktur.Text, in_kredit.Value)
            Else
                in_sisafaktur.Text = commaThousand(_sisahutang)
            End If
            idx = .Index
        End With
        dgv_bayar.Rows.RemoveAt(idx)
        in_total.Text = commaThousand(countTotal)

        If dgv_bayar.RowCount = 0 Then
            in_sales_n.ReadOnly = False
            in_custo_n.ReadOnly = False
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

    Private Sub loadCBAkun(kode As String)
        Dim q As String = "SELECT perk_kode as 'Value',perk_nama_akun as 'Text' FROM data_perkiraan WHERE perk_status=1 AND perk_parent='{0}'"
        Dim kodeparent As String = "1101"
        With cb_akun
            .DataSource = Nothing
            Select Case kode
                Case "TUNAI"
                    kodeparent = "1101"
                Case "BG", "TRANSFER"
                    kodeparent = "1102"
                Case "PIUTSUPL"
                    kodeparent = "2103' AND perk_kode='210302"
                Case Else
                    Exit Sub
            End Select
            consoleWriteLine(String.Format(q, kodeparent))
            .DataSource = getDataTablefromDB(String.Format(q, kodeparent))
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With
    End Sub

    'SAVE THE DATA
    Private Function saveData() As Boolean
        Dim querycheck As Boolean = False
        Dim dataHead, data1, data2 As String()
        Dim queryArr As New List(Of String)
        Dim q As String = ""

        If CheckKatPiutang() = False Then : Return False : Exit Function : End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then

                '==========================================================================================================================
                'INPUT HEADER

                If formstate = InputState.Insert And loggeduser.validasi_trans = False Then _status = 0

                dataHead = {
                    "p_bayar_tanggal_bayar='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                    "p_bayar_tanggal_jt='" & date_bg_tgl.Value.ToString("yyyy-MM-dd") & "'",
                    "p_bayar_pajak='" & cb_pajak.SelectedValue & "'",
                    "p_bayar_custo='" & in_custo.Text & "'",
                    "p_bayar_sales='" & in_sales.Text & "'",
                    "p_bayar_jenisbayar='" & cb_bayar.SelectedValue & "'",
                    "p_bayar_akun='" & cb_akun.SelectedValue & "'",
                    "p_bayar_potongan_nilai=" & in_potongan.Value.ToString.Replace(",", "."),
                    "p_bayar_ket=TRIM(BOTH '\r\n' FROM '" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "')",
                    "p_bayar_status='" & _status & "'"
                    }
                data2 = {
                    "p_bayar_giro_no='" & in_bg_no.Text & "'",
                    "p_bayar_giro_bank='" & in_bank.Text & "'"
                    }

                'START OF INSERT UPDATE HEADER ====================================================================================================
                If formstate = InputState.Insert Then
                    'START OF NEW TRANSACTION =====================================================================================================
                    If String.IsNullOrWhiteSpace(in_faktur.Text) Then
                        'START OF GENERATING NEW CODE =============================================================================================
                        Try
                            Dim i As Integer = 0 : Dim format As String = "D3"
                            q = "SELECT IFNULL(MAX(SUBSTR(p_bayar_bukti,11)),0) FROM data_piutang_bayar " _
                                & "WHERE SUBSTR(p_bayar_bukti,0,10)='PP{0:yyyyMMdd}' AND SUBSTR(p_bayar_bukti,11) REGEXP '^[0-9]+$'"
                            format = IIf(i + 1 > 999, "D" & (i + 1).ToString.Length, "D3")
                            in_faktur.Text = String.Format("PP{0:yyyyMMdd}", date_tgl_trans.Value) & (i + 1).ToString(format)

                            q = "INSERT INTO data_piutang_bayar SET p_bayar_bukti='{0}',{1},p_bayar_reg_date=NOW(),p_bayar_reg_alias='{2}'"
                        Catch ex As Exception
                            MessageBox.Show("Terjadi kesalahan dalam melakukan proses penyimpanan data." & Environment.NewLine & ex.Message,
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            logError(ex, True) : Return False : Exit Function
                        End Try
                        'END OF GENERATING NEW CODE ===============================================================================================

                    Else
                        'START OF CHECKING USER INPUTED CODE ======================================================================================
                        Dim cAct As Integer = 0 : Dim cDel As Integer = 0
                        q = "SELECT COUNT(CASE WHEN p_bayar_status!=9 THEN 1 END) ActiveCode, COUNT(CASE WHEN p_bayar_status=9 THEN 1 END) DeleteCode " _
                                & "FROM data_piutang_bayar WHERE faktur_kode='{0}'"
                        Using rdx = x.ReadCommand(String.Format(q, in_faktur.Text), CommandBehavior.SingleRow)
                            Dim red = rdx.Read
                            If red And rdx.HasRows Then
                                cAct = rdx.Item(0) : cDel = rdx.Item(1)
                            End If
                        End Using
                        If cAct = 1 Then 'WHEN THE CODE ALREADY TAKEN
                            MessageBox.Show("Nomor faktur " & in_faktur.Text & " sudah pernah diinputkan", "Penjualan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            in_faktur.Focus() : Return False : Exit Function
                        ElseIf cAct = 0 And cDel = 0 Then 'WHEN THE CODE IS AVAILABLE
                            q = "INSERT INTO data_piutang_bayar SET p_bayar_bukti='{0}',{1},p_bayar_reg_date=NOW(),p_bayar_reg_alias='{2}'"
                        ElseIf cDel = 1 And cAct = 0 Then 'WHEN THE CODE IS ALREADY TAKEN BUT THE TRASACTION STATE IS 'DELETE'
                            q = "UPDATE data_piutang_bayar SET {1}, p_bayar_reg_date=NOW(),p_bayar_reg_alias='{2}', " _
                                & "p_bayar_upd_date=NULL, p_bayar_upd_alias=NULL WHERE p_bayar_bukti='{0}'"
                        Else 'WHEN THERE IS DUPLICATION IN DATABASE ON THE CODE
                            MessageBox.Show("Terjadi kesalahan dalam melakukan proses penyimpanan data." & Environment.NewLine & _
                                            "Terdapat duplikasi kode pada database, kode faktur tidak dapat digunakan.",
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            errLog(New List(Of String) From {"Error : Duplicate primary code in database for sale transaction.",
                                                             "Duplicated Code : " & in_faktur.Text
                                                            }) : Return False : Exit Function
                        End If
                        'END OF CHECKING USER INPUTED CODE ========================================================================================
                    End If
                    'END OF NEW TRANSACTION =======================================================================================================

                Else
                    q = "UPDATE data_piutang_bayar SET {1},p_bayar_upd_date=NOW(),p_bayar_upd_alias='{2}' WHERE p_bayar_bukti='{0}' AND p_bayar_status<9"
                End If
                queryArr.Add(String.Format(
                             q, in_no_bukti.Text,
                             String.Join(",", dataHead) & IIf(cb_bayar.SelectedValue <> "BG", "", "," & String.Join(",", data2)),
                             loggeduser.user_id)
                         )
                'END OF INSERT UPDATE HEADER ======================================================================================================

                'START OF INSERT UPDATE BAYAR =====================================================================================================
                q = "UPDATE data_piutang_bayar_trans SET p_trans_status=9 WHERE p_trans_bukti='{0}'"
                queryArr.Add(String.Format(q, in_no_bukti.Text))

                For Each rows As DataGridViewRow In dgv_bayar.Rows
                    q = "INSERT INTO data_piutang_bayar_trans SET p_trans_bukti='{0}', p_trans_kode_piutang='{1}',{2} ON DUPLICATE KEY UPDATE {2}"
                    data1 = {
                        "p_trans_sisa=" & rows.Cells("bayar_sisapiutang").Value.ToString.Replace(",", "."),
                        "p_trans_nilaibayar=" & rows.Cells("bayar_kredit").Value.ToString.Replace(",", "."),
                        "p_trans_nobg='" & IIf(cb_bayar.SelectedValue = "BG", in_bg_no.Text, "") & "'",
                        "p_trans_reg_date=NOW()",
                        "p_trans_reg_alias='" & loggeduser.user_id & "'",
                        "p_trans_status='1'"
                        }
                    queryArr.Add(String.Format(q, in_no_bukti.Text, rows.Cells(0).Value, String.Join(",", data1)))
                Next
                'END OF INSERT UPDATE BARANG ======================================================================================================

                '==========================================================================================================================
                q = "CALL transBayarPiutangFin('{0}','{1}')"
                queryArr.Add(String.Format(q, in_no_bukti.Text, loggeduser.user_id))
                '==========================================================================================================================

                '==========================================================================================================================
                'BEGIN TRANSACTION
                querycheck = x.TransactCommand(queryArr)
                '==========================================================================================================================

                Me.Cursor = Cursors.Default

                If querycheck = False Then
                    MessageBox.Show("Data pembayaran tidak dapat tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    MessageBox.Show("Data pembayaran tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pgpiutangbayar, pgpiutangawal, pgpiutangbgcair})
                    Me.Close()
                End If
                Return querycheck
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Using
    End Function

    Private Function CheckGiro() As Boolean
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = ""
                Dim i As Integer = 0
                Dim _ck As Boolean = False
                q = "SELECT "
                Try

                Catch ex As Exception

                End Try

                Return _ck
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Using
    End Function

    Private Function CheckKatPiutang() As Boolean
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _q As String = ""
                Dim _ck As Boolean = False
                Dim _msg As String = ""
                For Each rows As DataGridViewRow In dgv_bayar.Rows
                    Dim i As Integer = 0
                    Dim _kode As String = rows.Cells(0).Value
                    _q = "SELECT piutang_pajak FROM data_piutang_awal WHERE piutang_faktur='{0}'"
                    _ck = Integer.TryParse(x.ExecScalar(String.Format(_q, _kode)), i)
                    If _ck Then
                        If i <> cb_pajak.SelectedValue Then
                            _msg = "Kategori piutang " & _kode & " tidak sesuai dengan kategori terpilih."
                            _ck = False : Exit For
                        Else
                            _ck = True
                        End If
                    Else
                        _msg = "Terjadi kesalahan saat melakukan pengecekan kategori pajak."
                        _ck = False : Exit For
                    End If
                Next
                If Not _ck Then MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Return _ck
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Using
    End Function

    'CANCEL TRANS
    Private Sub cancelData(KodeBayar As String)
        Dim q As String = ""
        Dim queryArr As New List(Of String)
        Dim queryCk As Boolean = False

        If {0, 1}.Contains(_status) Then
            q = "UPDATE data_piutang_bayar SET p_bayar_status=2,p_bayar_upd_date=NOW(),p_bayar_upd_alias='{1}' WHERE p_bayar_bukti='{0}'"
            queryArr.Add(String.Format(q, KodeBayar, loggeduser.user_id))

            '==========================================================================================================================
            q = "CALL transBayarPiutangFin('{0}','{1}')"
            queryArr.Add(String.Format(q, KodeBayar, loggeduser.user_id))
            '==========================================================================================================================

            '==========================================================================================================================
            'BEGIN TRANSACTION
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    queryCk = x.TransactCommand(queryArr)
                Else
                    MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End Using
            '==========================================================================================================================

            Me.Cursor = Cursors.Default

            If queryCk = False Then
                MessageBox.Show("Pembatalan transaksi gagal", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                'TODO : WRITE LOG ACTIVITY
                MessageBox.Show("Transaksi Dibatalkan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                DoRefreshTab_v2({pgpiutangbayar, pgpiutangawal}) : Me.Close()
            End If
        Else
            MessageBox.Show("Pembatalan transaksi tidak dapat dilakukan")
        End If
    End Sub

    'OPEN FULL WINDOWS SEARCH
    Private Sub searchData(tipe As String)
        Dim q As String = ""
        Using search As New fr_search_dialog

        End Using
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing, Optional param2 As String = Nothing)
        Dim q As String
        Dim dt As New DataTable

        Select Case tipe
            Case "sales"
                If String.IsNullOrWhiteSpace(in_custo.Text) Then
                    q = "SELECT salesman_kode 'Kode', salesman_nama 'Salesman' FROM data_salesman_master " _
                        & "WHERE salesman_status=1 AND (salesman_nama LIKE '%{0}%' OR salesman_kode LIKE '%{0}%') LIMIT 250"
                    q = String.Format(q, param)
                Else
                    q = "SELECT DISTINCT piutang_sales 'Kode', salesman_nama 'Salesman' FROM data_piutang_awal " _
                        & "LEFT JOIN data_salesman_master FORCE INDEX(sales_idx_kode_nama) ON salesman_kode=piutang_sales " _
                        & "WHERE piutang_status IN (1,2) AND piutang_custo='{1}' AND (piutang_sales LIKE '%{0}%' OR salesman_nama LIKE '%{0}%') LIMIT 250"
                    q = String.Format(q, param, in_custo.Text)
                End If
            Case "custo"
                If String.IsNullOrWhiteSpace(in_sales.Text) Then
                    q = "SELECT customer_kode 'Kode', customer_nama 'Customer', " _
                        & "GetPiutangSaldoAwal('titipan', customer_kode, ADDDATE('{1:yyyy-MM-dd}',1)) PiutangSupl " _
                        & "FROM data_customer_master " _
                        & "WHERE customer_status=1 AND (customer_nama LIKE '%{0}%' OR customer_kode LIKE '%{0}%') LIMIT 250"
                    q = String.Format(q, param, date_tgl_trans.Value)

                Else
                    q = "SELECT DISTINCT piutang_custo 'Kode', GetMasterNama('custo',piutang_custo) 'Customer', " _
                        & "GetPiutangSaldoAwal('titipan', piutang_custo, ADDDATE('{1:yyyy-MM-dd}',1)) PiutangSupl " _
                        & "FROM data_piutang_awal " _
                        & "WHERE piutang_status IN (1,2) AND piutang_sales='{2}' AND " _
                        & " (piutang_custo LIKE '%{0}%' OR GetMasterNama('custo',piutang_custo) LIKE '%{0}%') LIMIT 250"
                    q = String.Format(q, param, date_tgl_trans.Value, in_sales.Text)

                End If
            Case "faktur"
                q = "SELECT piutang_faktur 'Kode Faktur', GetPiutangSaldoAwal('piutang', piutang_faktur, ADDDATE('{1:yyyy-MM-dd}',1)) 'Sisa Piutang', " _
                    & "piutang_jt as 'Jatuh Tempo', piutang_awal " _
                    & "FROM data_piutang_awal " _
                    & "WHERE piutang_status_lunas=0 AND GetPiutangSaldoAwal('piutang', piutang_faktur, ADDDATE('{1:yyyy-MM-dd}',1)) > 0 " _
                    & " AND piutang_custo='{2}' AND piutang_sales='{3}' AND piutang_pajak='{4}' AND piutang_faktur LIKE '%{0}%'"
                q = String.Format(q, param, date_tgl_trans.Value, in_custo.Text, in_sales.Text, cb_pajak.SelectedValue)

            Case Else
                Exit Sub
        End Select

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    dt = x.GetDataTable(q)
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                MessageBox.Show("Tidak dapat terhurbung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

        With dgv_listbarang
            .DataSource = dt
            If .ColumnCount > 1 Then
                If {"custo", "sales"}.Contains(tipe) Then
                    .Columns(0).Width = 135 : .Columns(1).Width = 200
                    If tipe = "custo" Then .Columns(2).Visible = False
                ElseIf tipe = "faktur" Then
                    .Columns(1).Width = 100 : .Columns(1).DefaultCellStyle = dgvstyle_currency
                    .Columns(2).Width = 100 : .Columns(2).DefaultCellStyle = dgvstyle_date
                    .Columns(3).Visible = False
                End If
                .Columns(.DisplayedColumnCount(False) - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
        End With
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case _popUpPos
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    in_sales_n.Focus()
                Case "custo"
                    in_custo.Text = .Cells(0).Value
                    in_custo_n.Text = .Cells(1).Value
                    If formstate <> InputState.Insert And in_custo.Text = _prevCusto And _prevIsTitip.Key = True Then
                        in_saldotitipan.Text = commaThousand(.Cells(2).Value + _prevIsTitip.Value)
                    Else
                        in_saldotitipan.Text = commaThousand(.Cells(2).Value)
                    End If
                    in_custo_n.Focus()
                Case "faktur"
                    in_faktur.Text = .Cells(0).Value
                    If formstate <> InputState.Insert And _prevfakturbayar.Key = in_faktur.Text Then
                        in_sisafaktur.Text = commaThousand(_sisaHutang + _prevfakturbayar.Value)
                    Else
                        in_sisafaktur.Text = commaThousand(.Cells(1).Value)
                    End If
                    _totalhutang = .Cells(3).Value
                    in_tgl_jtfaktur.Text = .Cells(2).Value
                    'AND OTHER STUFF
                    in_kredit.Focus()
                Case Else
                    Exit Sub
            End Select

        End With
        popPnl_barang.Visible = False
    End Sub

    Private Sub clearInput()
        Dim txt As TextBox() = {in_tgl_jtfaktur, in_faktur, in_sisafaktur}
        For Each x As TextBox In txt
            x.Clear()
        Next
        _totalhutang = 0
        in_kredit.Value = 0
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalcusto.Click
        'If MessageBox.Show("Tutup Form?", "Pembayaran Piutang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        Me.Close()
        'End If
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'e.Cancel = True
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalcusto.PerformClick()
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
                bt_batalcusto.PerformClick()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    '------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpancusto.PerformClick()
    End Sub

    Private Sub mn_delete_Click(sender As Object, e As EventArgs) Handles mn_delete.Click
        If in_no_bukti.Text <> Nothing And formstate = InputState.Edit Then
            If MessageBox.Show("Batalkan pembayaran?", "Pembayaran Piutang", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim cnfrmval As Boolean = TransConfirmValid(in_ket.Text)

                If cnfrmval = True Then cancelData(in_no_bukti.Text)
            End If
        End If
    End Sub

    Private Sub mn_proses_Click(sender As Object, e As EventArgs) Handles mn_proses.Click
        If formstate <> InputState.Edit Then Exit Sub
        If String.IsNullOrWhiteSpace(in_no_bukti.Text) And _status = 0 And date_tgl_trans.Value >= TransStartDate Then
            'CHECK INPUT DATA
            For Each x As TextBox In {in_sales, in_custo}
                Dim Msg As String = "{0} belum diinput"
                Dim _input As TextBox
                Select Case x.Name
                    Case in_sales.Name : Msg = String.Format(Msg, "Salesman") : _input = in_sales_n
                    Case in_custo.Name : Msg = String.Format(Msg, "Customer") : _input = in_custo_n
                    Case Else : Exit Sub
                End Select

                If String.IsNullOrWhiteSpace(x.Text) Then
                    MessageBox.Show(Msg, "Proses Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    _input.Focus() : Exit Sub
                End If
            Next
            If dgv_bayar.RowCount = 0 Then
                MessageBox.Show("Pembayaran belum di input.", "Proses Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                in_custo_n.Focus() : Exit Sub
            End If

            'CHECK PEMBAYARAN
            If cb_bayar.SelectedValue = "BG" And Trim(in_bg_no.Text) = Nothing Then
                MessageBox.Show("Nomor Giro belum di input.", "Proses Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                in_bg_no.Focus()
                Exit Sub
            ElseIf cb_bayar.SelectedValue = "PIUTSUPL" And removeCommaThousand(in_total.Text) > removeCommaThousand(in_saldotitipan.Text) Then
                MessageBox.Show("Saldo titipan customer lebih kecil daripada total pembayaran.", "Proses Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                dgv_bayar.Focus()
                Exit Sub
            End If
            If cb_akun.SelectedValue = Nothing Then
                MessageBox.Show("Pilih akun pembayaran terlebih dahulu.", "Proses Pembayaran", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                cb_akun.Focus() : Exit Sub
            End If

            If MessageBox.Show("Proses pembayaran?", "Pembayaran Piutang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim _prevstatus = _status
                Dim cnfrmval As Boolean = False
                cnfrmval = TransConfirmValid(in_ket.Text)

                If cnfrmval = True Then
                    _status = 1
                    Dim _ck = saveData()
                    If Not _ck Then _status = _prevstatus
                End If
            End If
        End If
    End Sub

    '------------- load
    Private Sub fr_hutang_bayar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv_bayar.ClearSelection()
    End Sub

    'UI : BUTTON
    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpancusto.Click
        'CHECK TANGGAL TRANSAKSI
        If date_tgl_trans.Value < TransStartDate Then
            MessageBox.Show("Tanggal pembayaran tidak bisa kurang dari periode aktif. " & TransStartDate.ToString("(MMMM yyyy)"),
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            date_tgl_trans.Focus() : Exit Sub
        End If

        'CHECK INPUT DATA
        For Each x As TextBox In {in_sales, in_custo}
            Dim Msg As String = "{0} belum diinput"
            Dim _input As TextBox
            Select Case x.Name
                Case in_sales.Name : Msg = String.Format(Msg, "Salesman") : _input = in_sales_n
                Case in_custo.Name : Msg = String.Format(Msg, "Customer") : _input = in_custo_n
                Case Else : Exit Sub
            End Select

            If String.IsNullOrWhiteSpace(x.Text) Then
                MessageBox.Show(Msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                _input.Focus() : Exit Sub
            End If
        Next
        If dgv_bayar.RowCount = 0 Then
            MessageBox.Show("Pembayaran belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_faktur.Focus() : Exit Sub
        End If
        If Not CheckKatPiutang() Then Exit Sub

        'CHECK PEMBAYARAN
        If cb_bayar.SelectedValue = "BG" And String.IsNullOrWhiteSpace(in_bg_no.Text) Then
            MessageBox.Show("Nomor Giro belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_bg_no.Focus() : Exit Sub
        ElseIf cb_bayar.SelectedValue = "PIUTSUPL" And removeCommaThousand(in_total.Text) > removeCommaThousand(in_saldotitipan.Text) Then
            MessageBox.Show("Saldo titipan customer lebih kecil daripada total pembayaran.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dgv_bayar.Focus() : Exit Sub
        End If
        If cb_akun.SelectedValue = Nothing Then
            MessageBox.Show("Pilih akun pembayaran terlebih dahulu", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cb_akun.Focus() : Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim _askRes As DialogResult = Windows.Forms.DialogResult.Yes
        If Not formstate = InputState.Insert Then
            _askRes = MessageBox.Show("Simpan perubahan pembayaran piutang?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End If
        If _askRes = Windows.Forms.DialogResult.Yes Then saveData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub bt_proses_Click(sender As Object, e As EventArgs) Handles bt_proses.Click
        mn_proses.PerformClick()
    End Sub

    'UI : POPUP PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_sales_n.Focused Or in_custo_n.Focused Or in_faktur.Focused Then
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
        Dim x As TextBox
        Select Case _popUpPos
            Case "sales" : x = in_sales_n
            Case "custo" : x = in_custo_n
            Case "faktur" : x = in_faktur
            Case Else : Exit Sub
        End Select
        PopUpSearchKeyPress(e, x)
    End Sub

    'UI : cb prevent input
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_bayar.KeyPress, cb_akun.KeyPress, cb_pajak.KeyPress
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    'UI : numeric
    Private Sub in_debet_Enter(sender As Object, e As EventArgs) Handles in_kredit.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_debet_Leave(sender As Object, e As EventArgs) Handles in_kredit.Leave
        numericLostFocus(sender)
    End Sub

    'UI : INPUT
    Private Sub in_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales.KeyDown
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_sales_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter, in_custo_n.Enter
        If sender.ReadOnly = False And sender.Enabled Then
            Select Case sender.Name
                Case "in_sales_n" : _popUpPos = "sales"
                Case "in_custo_n" : _popUpPos = "custo"
                Case Else : Exit Sub
            End Select

            popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
            If popPnl_barang.Visible = False Then popPnl_barang.Visible = True
            loadDataBRGPopup(_popUpPos, sender.Text)
        End If
    End Sub

    Private Sub in_sales_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave, in_faktur.Leave, in_custo_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_sales_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyDown, in_custo_n.KeyDown, in_faktur.KeyDown
        If e.KeyCode = Keys.Enter And e.KeyCode = Keys.Escape Then e.SuppressKeyPress = True
    End Sub

    Private Sub in_sales_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp, in_custo_n.KeyUp, in_faktur.KeyUp
        Dim _next As Object : Dim _id As TextBox
        Select Case sender.Name.ToString
            Case "in_sales_n" : _next = in_custo_n : _id = in_sales
            Case "in_custo_n" : _next = cb_pajak : _id = in_custo
            Case "in_faktur" : _next = in_kredit : _id = Nothing
            Case Else
                Exit Sub
        End Select

        Dim _x = PopUpSearchInputHandle_inputKeyup(e, sender, _id, popPnl_barang, dgv_listbarang)
        For Each _resp As String In _x
            Select Case _resp
                Case "set" : setPopUpResult()
                Case "next" : keyshortenter(_next, e)
                Case "clear"
                    in_tgl_jtfaktur.Clear() : in_sisafaktur.Clear() : _totalhutang = 0
                    If {"in_sales_n", "in_custo_n"}.Contains(sender.Name) Then in_faktur.Clear()
                Case "load" : loadDataBRGPopup(_popUpPos, sender.Text)
            End Select
        Next
    End Sub

    Private Sub in_sales_n_MouseClick(sender As Object, e As MouseEventArgs) Handles in_sales_n.MouseClick
        If popPnl_barang.Visible = False And sender.ReadOnly = False Then
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles in_custo.KeyDown
        keyshortenter(in_custo_n, e)
    End Sub

    Private Sub in_custo_n_MouseClick(sender As Object, e As MouseEventArgs) Handles in_custo_n.MouseClick
        If popPnl_barang.Visible = False And sender.ReadOnly = False Then
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_faktur_Enter(sender As Object, e As EventArgs) Handles in_faktur.Enter
        If sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(in_faktur.Left, in_faktur.Top + in_faktur.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            _popUpPos = "faktur"
            loadDataBRGPopup("faktur", in_faktur.Text, in_custo.Text)
        End If
    End Sub

    Private Sub in_faktur_MouseClick(sender As Object, e As MouseEventArgs) Handles in_faktur.MouseClick
        If popPnl_barang.Visible = False And sender.ReadOnly = False Then
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub cb_pajak_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_pajak.KeyUp
        keyshortenter(cb_bayar, e)
    End Sub

    Private Sub cb_bayar_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_bayar.KeyUp
        keyshortenter(cb_akun, e)
    End Sub

    Private Sub cb_bayar_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_bayar.SelectionChangeCommitted
        If cb_bayar.SelectedValue = "BG" Then
            in_bg_no.Enabled = True
            in_bank.Enabled = True
        Else
            in_bank.Enabled = False
            in_bg_no.Enabled = False
        End If

        loadCBAkun(cb_bayar.SelectedValue)
    End Sub

    Private Sub cb_akun_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_akun.KeyUp
        keyshortenter(date_tgl_trans, e)
    End Sub

    Private Sub date_tgl_trans_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tgl_trans.KeyUp
        keyshortenter(date_bg_tgl, e)
    End Sub

    Private Sub date_bg_tgl_KeyUp(sender As Object, e As KeyEventArgs) Handles date_bg_tgl.KeyUp
        keyshortenter(in_faktur, e)
    End Sub

    Private Sub in_kredit_KeyUp(sender As Object, e As KeyEventArgs) Handles in_kredit.KeyUp
        keyshortenter(bt_tbbayar, e)
    End Sub

    Private Sub in_bg_no_KeyUp(sender As Object, e As KeyEventArgs) Handles in_bg_no.KeyUp
        keyshortenter(in_bank, e)
    End Sub

    Private Sub in_bank_KeyUp(sender As Object, e As KeyEventArgs) Handles in_bank.KeyUp
        keyshortenter(in_ket, e)
    End Sub

    'DGV
    Private Sub bt_tbbayar_Click(sender As Object, e As EventArgs) Handles bt_tbbayar.Click
        textToDGV()
    End Sub

    Private Sub dgv_bayar_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex > -1 Then dgvToText()
    End Sub
End Class