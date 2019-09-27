Public Class fr_stok_mutasi
    Private _status As String = 0
    Private isisat_t As Integer = 0
    Private isisat_b As Integer = 0
    Private popupstate As String = "barang"
    Private _hppbrg As Decimal = 0
    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
        View
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(NoFaktur As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Mutasi Stok : rj20190810902"

        formstate = FormSet
        With cb_pajak
            .DataSource = jenis("bayar_pajak")
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With

        'With date_tgl_beli
        '    .MaxDate = selectperiode.tglakhir
        '    .MinDate = selectperiode.tglawal
        '    If selectperiode.tglakhir >= Today Then : .Value = Today
        '    Else : .Value = selectperiode.tglakhir
        '    End If
        'End With
        For Each x As DateTimePicker In {date_tgl_beli}
            x.Value = IIf(DataListEndDate > Today, Today, DataListEndDate)
            x.MinDate = If(formstate = InputState.Insert, TransStartDate, DataListStartDate)
            x.MaxDate = DataListEndDate
        Next

        setDoubleBuffered(dgv_barang, True)

        If Not formstate = InputState.Insert Then
            Me.Text += " : " & NoFaktur
            Me.lbl_title.Text += " : " & NoFaktur
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            loadData(NoFaktur)
            If Not {0, 1}.Contains(_status) Or date_tgl_beli.Value < TransStartDate Then formstate = InputState.View
        End If

        If formstate = InputState.View Then AllowEdit = False
        FormSwitch(AllowEdit)
    End Sub

    Private Sub FormSwitch(AllowEdit As Boolean)
        Dim _ReadOnly As Boolean = IIf(AllowEdit, False, True)
        cb_pajak.Enabled = IIf(dgv_barang.RowCount > 0, False, AllowEdit)
        in_gudang_n.ReadOnly = IIf(dgv_barang.RowCount > 0, True, _ReadOnly)
        in_gudang2_n.ReadOnly = _ReadOnly
        date_tgl_beli.Enabled = AllowEdit

        bt_simpanbeli.Enabled = AllowEdit
        bt_simpanbeli.Text = If(formstate = InputState.Edit, "Update", "Simpan")
        mn_save.Enabled = AllowEdit
        mn_cancel.Enabled = If(formstate = InputState.Insert, False, IIf({0, 1}.Contains(_status), AllowEdit, False))
        mn_print.Enabled = False

        For Each x As Control In {in_barang, in_barang_nm, in_qty1, in_qty2, in_qty3, in_sat1, in_sat2, in_sat3, in_hpp, bt_tbbarang}
            x.Visible = AllowEdit
        Next

        If AllowEdit Then
            dgv_barang.Location = New Point(12, 121) : dgv_barang.Height = 189
            AddHandler dgv_barang.CellDoubleClick, AddressOf dgv_barang_CellDoubleClick
        Else
            dgv_barang.Location = New Point(12, 79) : dgv_barang.Height = 229
            RemoveHandler dgv_barang.CellDoubleClick, AddressOf dgv_barang_CellDoubleClick
        End If

    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        SetUpForm(Nothing, InputState.Insert, AllowInput)
        Me.Show(main)
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, AllowEdit As Boolean)
        SetUpForm(NoFaktur, InputState.Edit, AllowEdit)
        Me.Show(main)
    End Sub

    Public Sub doLoadView(NoFaktur As String)
        SetUpForm(NoFaktur, InputState.View, False)
        Me.Show(main)
    End Sub

    'LOAD DATA
    Private Sub loadData(NoFaktur)
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT faktur_kode, faktur_tanggal, faktur_pajak, faktur_gudang_asal, a.gudang_nama as gudang_asal, " _
                    & "faktur_gudang_tujuan, b.gudang_nama as gudang_tujuan, faktur_ket, faktur_status, " _
                    & "IFNULL(faktur_reg_alias,'') faktur_reg_alias, DATE_FORMAT(faktur_reg_date,'%d/%m/%Y %H:%i:%S') faktur_reg_date, " _
                    & "IFNULL(faktur_upd_alias,'') faktur_upd_alias, IFNULL(DATE_FORMAT(faktur_upd_date,'%d/%m/%Y %H:%i:%S'),'') faktur_upd_date " _
                    & "FROM data_barang_stok_mutasi " _
                    & "LEFT JOIN data_barang_gudang a ON faktur_gudang_asal=a.gudang_kode " _
                    & "LEFT JOIN data_barang_gudang b ON faktur_gudang_tujuan=b.gudang_kode " _
                    & "WHERE faktur_kode='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, NoFaktur), CommandBehavior.SingleRow)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_kode.Text = rdx.Item("faktur_kode")
                        date_tgl_beli.Value = rdx.Item("faktur_tanggal")
                        cb_pajak.SelectedValue = rdx.Item("faktur_pajak")

                        in_gudang.Text = rdx.Item("faktur_gudang_asal")
                        in_gudang_n.Text = rdx.Item("gudang_asal")
                        in_gudang2.Text = rdx.Item("faktur_gudang_tujuan")
                        in_gudang2_n.Text = rdx.Item("gudang_tujuan")

                        in_ket.Text = rdx.Item("faktur_ket")
                        _status = rdx.Item("faktur_status")

                        txtRegAlias.Text = rdx.Item("faktur_reg_alias")
                        txtRegdate.Text = rdx.Item("faktur_reg_date")
                        txtUpdDate.Text = rdx.Item("faktur_upd_date")
                        txtUpdAlias.Text = rdx.Item("faktur_upd_alias")
                    End If
                End Using

                q = "SELECT trans_barang, barang_nama, trans_qty_besar, barang_satuan_besar, trans_qty_tengah, " _
                    & "barang_satuan_tengah, trans_qty_kecil, barang_satuan_kecil, trans_qty_tot,trans_hpp " _
                    & "FROM data_barang_stok_mutasi_trans LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                    & "WHERE trans_faktur='{0}' AND trans_status=1"
                Using dt = x.GetDataTable(String.Format(q, NoFaktur))
                    With dgv_barang.Rows
                        For Each row As DataRow In dt.Rows
                            Dim i = .Add
                            .Item(i).Cells("kode").Value = row.ItemArray(0)
                            .Item(i).Cells("nama").Value = row.ItemArray(1)
                            .Item(i).Cells("qty_b").Value = row.ItemArray(2)
                            .Item(i).Cells("sat_b").Value = row.ItemArray(3)
                            .Item(i).Cells("qty_t").Value = row.ItemArray(4)
                            .Item(i).Cells("sat_t").Value = row.ItemArray(5)
                            .Item(i).Cells("qty_k").Value = row.ItemArray(6)
                            .Item(i).Cells("sat_k").Value = row.ItemArray(7)
                            .Item(i).Cells("qty_tot").Value = row.ItemArray(8)
                            .Item(i).Cells("hpp_brg").Value = row.ItemArray(9)
                        Next
                    End With
                End Using
                'SET STATUS
                Select Case _status
                    Case 0 : in_status.Text = "Pending"
                    Case 1 : in_status.Text = "Aktif"
                    Case 2 : in_status.Text = "Batal"
                    Case 8 : in_status.Text = "On-Edit/NOT IMPLEMENTED!"
                    Case 9 : in_status.Text = "Delete"
                    Case Else : Exit Sub
                End Select
            Else
                MessageBox.Show("Tidak dapat terhubung ke server", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable

        dgv_listbarang.DataSource = New DataTable
        setDoubleBuffered(dgv_listbarang, True)
        Select Case tipe
            Case "barang"
                Dim _date As Date = date_tgl_beli.Value
                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama', SUM(trans_qty) QTY, " _
                    & "barang_satuan_besar, barang_satuan_besar_jumlah, barang_satuan_tengah, barang_satuan_tengah_jumlah, barang_satuan_kecil " _
                    & "FROM data_stok_kartustok " _
                    & "LEFT JOIN data_stok_awal ON trans_stock=stock_kode " _
                    & "LEFT JOIN data_barang_master ON stock_barang=barang_kode " _
                    & "WHERE stock_status=1 AND trans_tgl<='{1:yyyy-MM-dd}' AND stock_gudang='{2}' AND barang_pajak='{3}' " _
                    & " AND (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%') GROUP BY barang_kode LIMIT 250"
                q = String.Format(q, "{0}", _date, in_gudang.Text, cb_pajak.SelectedValue)

            Case "gudang2"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang WHERE gudang_status=1 " _
                    & "AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%') AND gudang_kode<>'" & in_gudang.Text & "'"

            Case "gudang"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang WHERE gudang_status=1 " _
                    & "AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%') AND gudang_kode<>'" & in_gudang2.Text & "'"
            Case Else
                Exit Sub
        End Select

        Me.Cursor = Cursors.WaitCursor
        Using x = MainConnection : dt = x.GetDataTable(String.Format(q, param)) : End Using

        With dgv_listbarang
            .DataSource = dt
            If .ColumnCount >= 2 Then
                If tipe = "barang" Then
                    .Columns(0).Width = 75 : .Columns(1).Width = 200
                    .Columns(2).DefaultCellStyle = dgvstyle_currency
                    For i = 3 To 7 : .Columns(i).Visible = False : Next
                Else
                    .Columns(0).Width = 100 : .Columns(1).Width = 200
                End If
            End If
            If .DisplayedColumnCount(False) <= 3 Then .Columns(.DisplayedColumnCount(False) - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
        Me.Cursor = Cursors.Default
    End Sub

    'OPEN SEARCH WINDOW
    Private Sub doSearch()

    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "barang"
                    Dim validUid As String = ""
                    If .Cells(2).Value <= 0 Then
                        If MessageBox.Show("Barang " & .Cells(1).Value & " kosong/minus. Lanjutkan?", Me.Text,
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                            If Not TransConfirmValid(validUid) Then Exit Sub
                            'ADD LOG VALIDASI
                        Else
                            Exit Sub
                        End If
                    End If
                    in_barang.Text = .Cells(0).Value
                    in_barang_nm.Text = .Cells(1).Value
                    in_sat1.Text = .Cells(3).Value
                    isisat_b = .Cells(4).Value
                    in_sat2.Text = .Cells(5).Value
                    isisat_t = .Cells(6).Value
                    in_sat3.Text = .Cells(7).Value
                    _hppbrg = getHpp(.Cells(0).Value)
                    in_hpp.Text = commaThousand(_hppbrg)
                    in_qty1.Focus()
                Case "gudang2"
                    in_gudang2.Text = .Cells(0).Value
                    in_gudang2_n.Text = .Cells(1).Value
                    in_barang_nm.Focus()
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    in_gudang2_n.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
    End Sub

    'GET HPP BARANG
    Private Function getHpp(KodeBrg As String) As Decimal
        Dim retval As Decimal = 0
        Dim q As String = ""

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT getHppAvg_v2('{0}','{1:yyyy-MM-dd}')"
                q = String.Format(q, KodeBrg, date_tgl_beli.Value)
                retval = x.ExecScalar(q)
            End If
        End Using

        Return retval
    End Function

    'ADD INPUT FROM TEXTBOX TO DGV
    Private Sub textToDGV()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        If in_barang.Text = Nothing Then
            MessageBox.Show("Barang belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_barang_nm.Focus()
            Exit Sub
        End If

        Dim qtytot As Integer = 0
        qtytot = in_qty1.Value * isisat_b * isisat_t + in_qty2.Value * isisat_t + in_qty3.Value
        If qtytot = 0 Then
            MessageBox.Show("Qty belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_qty1.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim check As Boolean = False
        Dim input As Boolean = False
        If dgv_barang.RowCount > 0 Then
            For Each rows As DataGridViewRow In dgv_barang.Rows
                If rows.Cells("kode").Value = in_barang.Text Then
                    If MessageBox.Show("Barang yang sama sudah diinputkan ke dalam list, tambahkan qty pada barang tersebut?", "Mutasi Antar Gudang", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        rows.Cells("qty_b").Value += in_qty1.Value
                        rows.Cells("qty_t").Value += in_qty2.Value
                        rows.Cells("qty_k").Value += in_qty3.Value
                        rows.Cells("qty_tot").Value += qtytot
                        check = True : input = True
                        Exit For
                    Else
                        check = True
                        Exit For
                    End If
                End If
            Next
        End If

        If Not check Then
            With dgv_barang.Rows
                Dim x As Integer = .Add
                .Item(x).Cells("kode").Value = in_barang.Text
                .Item(x).Cells("nama").Value = in_barang_nm.Text
                .Item(x).Cells("qty_b").Value = in_qty1.Value
                .Item(x).Cells("sat_b").Value = in_sat1.Text
                .Item(x).Cells("qty_t").Value = in_qty2.Value
                .Item(x).Cells("sat_t").Value = in_sat2.Text
                .Item(x).Cells("qty_k").Value = in_qty3.Value
                .Item(x).Cells("sat_k").Value = in_sat3.Text
                .Item(x).Cells("qty_tot").Value = qtytot
                .Item(x).Cells("hpp_brg").Value = _hppbrg
            End With
            input = True
        End If

        If input Then : clearInputBarang() : in_gudang_n.ReadOnly = True : cb_pajak.Enabled = False : End If

        Me.Cursor = Cursors.Default
    End Sub

    'GET DATA FROM DGV
    Private Sub dgvToTxt()
        Dim _idx As Integer = 0
        With dgv_barang.SelectedRows.Item(0)
            _idx = .Index
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty1.Value = .Cells("qty_b").Value
            in_sat1.Text = .Cells("sat_b").Value
            in_qty2.Value = .Cells("qty_t").Value
            in_sat2.Text = .Cells("sat_t").Value
            in_qty3.Value = .Cells("qty_k").Value
            in_sat3.Text = .Cells("sat_k").Value
            _hppbrg = .Cells("hpp_brg").Value
            in_hpp.Text = commaThousand(_hppbrg)
        End With
        dgv_barang.Rows.RemoveAt(_idx)

        If dgv_barang.RowCount = 0 Then
            cb_pajak.Enabled = True
            in_gudang_n.ReadOnly = False
        End If
    End Sub

    Private Sub clearInputBarang()
        For Each txt As TextBox In {in_barang, in_barang_nm, in_sat1, in_sat2, in_sat3, in_hpp}
            txt.Clear()
        Next
        For Each num As NumericUpDown In {in_qty1, in_qty2, in_qty3}
            num.Value = 0
        Next
    End Sub

    'SAVE
    Private Sub SaveData()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim querycheck As String = False
        Dim queryArr As New List(Of String)
        Dim datafaktur, dataBrg As String()
        Dim q As String = ""

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _tgltrans As String = date_tgl_beli.Value.ToString("yyyy-MM-dd")
                Dim _kode As String = ""

                datafaktur = {"faktur_tanggal='" & _tgltrans & "'",
                              "faktur_pajak='" & cb_pajak.SelectedValue & "'",
                              "faktur_gudang_asal='" & in_gudang.Text & "'",
                              "faktur_gudang_tujuan='" & in_gudang2.Text & "'",
                              "faktur_ket='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
                              "faktur_status='1'"
                             }
                If formstate = InputState.Insert Then
                    in_kode.Text = Trim(in_kode.Text)
                    'GENERATE KODE
                    If String.IsNullOrWhiteSpace(in_kode.Text) Then
                        'START OF GENERATING NEW CODE =============================================================================================
                        Try
                            Dim i As Integer = 0 : Dim format As String = "D3"
                            q = "SELECT IFNULL(MAX(SUBSTRING(faktur_kode, 11)),0) FROM data_barang_stok_mutasi " _
                                & "WHERE faktur_kode LIKE 'MG{0:yyyyMMdd}%' AND SUBSTRING(faktur_kode,11) REGEXP '^[0-9]+$'"
                            i = CInt(x.ExecScalar(String.Format(q, date_tgl_beli.Value)))
                            format = IIf(i + 1 > 999, "D" & (i + 1).ToString.Length, "D3")
                            in_kode.Text = String.Format("MG{0:yyyyMMdd}", date_tgl_beli.Value) & (i + 1).ToString(format)

                        Catch ex As Exception
                            MessageBox.Show("Terjadi kesalahan dalam melakukan proses penyimpanan data." & Environment.NewLine & ex.Message,
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            logError(ex, True) : Exit Sub
                        End Try
                        'END OF GENERATING NEW CODE ===============================================================================================
                    Else
                        'START OF CHECKING USER INPUTED CODE ======================================================================================
                        q = "SELECT COUNT(faktur_kode) FROM data_barang_stok_mutasi WHERE faktur_kode='{0}'"
                        If CInt(x.ExecScalar(String.Format(q, in_kode.Text))) > 0 Then
                            MessageBox.Show("Kode Mutasi sudah pernah diinputkan sebelumnya. Silahkan masukan kode lain.", Me.Text,
                                            MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            in_kode.Focus() : Exit Sub
                        End If
                        'END OF CHECKING USER INPUTED CODE ========================================================================================
                    End If
                    q = "INSERT INTO data_barang_stok_mutasi SET faktur_kode='{0}',{1},faktur_reg_date=NOW(),faktur_reg_alias='{2}'"
                Else
                    q = "UPDATE data_barang_stok_mutasi SET {1}, faktur_upd_date=NOW(), faktur_upd_alias='{2}' WHERE faktur_kode='{0}'"
                End If
                '==========================================================================================================================
                'INSERT HEADER
                queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", datafaktur), loggeduser.user_id))
                '==========================================================================================================================

                '==========================================================================================================================
                'INSERT BARANG
                q = "UPDATE data_barang_stok_mutasi_trans SET trans_status=9 WHERE trans_faktur='{0}'"
                queryArr.Add(String.Format(q, in_kode.Text))

                For Each rows As DataGridViewRow In dgv_barang.Rows
                    Dim _qtytot As Integer = rows.Cells("qty_tot").Value
                    Dim _hpp As Decimal = getHpp(rows.Cells(0).Value)
                    dataBrg = {
                        "trans_barang='" & rows.Cells(0).Value & "'",
                        "trans_qty_besar=" & rows.Cells("qty_b").Value,
                        "trans_qty_tengah=" & rows.Cells("qty_t").Value,
                        "trans_qty_kecil=" & rows.Cells("qty_k").Value,
                        "trans_qty_tot=" & _qtytot,
                        "trans_satuan_besar='" & rows.Cells("sat_b").Value & "'",
                        "trans_satuan_tengah='" & rows.Cells("sat_t").Value & "'",
                        "trans_satuan_kecil='" & rows.Cells("sat_k").Value & "'",
                        "trans_hpp=" & _hpp.ToString.Replace(",", "."),
                        "trans_status='1'"
                        }
                    q = "INSERT INTO data_barang_stok_mutasi_trans SET trans_faktur='{0}',{1} ON DUPLICATE KEY UPDATE {1}"
                    queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", dataBrg)))
                Next
                '==========================================================================================================================

                '==========================================================================================================================
                'OTHER PROCESS
                q = "CALL transMutasiStokFin('{0}','{1}')"
                queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id))
                '==========================================================================================================================

                '==========================================================================================================================
                'BEGIN TRANSACTION
                querycheck = x.TransactCommand(queryArr)
                '==========================================================================================================================

                Me.Cursor = Cursors.Default

                If querycheck = False Then
                    MessageBox.Show("Data tidak dapat tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    MessageBox.Show("Data mutasi tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pgstok, pgmutasigudang})
                    Me.Close()
                End If
            End If
        End Using
    End Sub

    'CANCEL
    Private Sub CancelData()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        If TransConfirmValid(in_ket.Text) Then
            Dim queryCk As Boolean = False
            Dim queryArr As New List(Of String)
            Dim q As String = ""

            Using x = MainConnection
                x.Open()
                If x.ConnectionState = ConnectionState.Open Then
                    q = "UPDATE data_barang_stok_mutasi SET faktur_status=2, faktur_ket='{2}', faktur_upd_date =NOW(), faktur_upd_alias='{1}' WHERE faktur_kode='{0}'"
                    queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id, mysqlQueryFriendlyStringFeed(Trim(in_ket.Text))))

                    q = "CALL transMutasiStokFin('{0}','{1}')"
                    queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id))

                    queryCk = x.TransactCommand(queryArr)
                End If

                If queryCk Then
                    MessageBox.Show("Transaksi mutasi dibatalkan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    doRefreshTab({pgmutasigudang})
                Else
                    MessageBox.Show("Error. Transaksi gagal dibatalkan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        'If MessageBox.Show("Tutup Form Mutasi?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        Me.Close()
        'End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbeli.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub fr_stok_mutasi_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            Else
                bt_batalbeli.PerformClick()
            End If
        End If
    End Sub

    '------------- POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_gudang2_n.Focused Or in_gudang_n.Focused Or in_barang_nm.Focused Then
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
            Case "gudang2" : x = in_gudang2_n
            Case "gudang" : x = in_gudang_n
            Case "barang" : x = in_barang_nm
            Case Else : Exit Sub
        End Select
        PopUpSearchKeyPress(e, x)
    End Sub

    'UI :MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanbeli.PerformClick()
    End Sub

    Private Sub mn_print_Click(sender As Object, e As EventArgs) Handles mn_print.Click

    End Sub

    Private Sub mn_proses_Click(sender As Object, e As EventArgs) Handles mn_proses.Click

    End Sub

    Private Sub mn_cancel_Click(sender As Object, e As EventArgs) Handles mn_cancel.Click
        If {0, 1}.Contains(_status) And formstate = InputState.Edit Then
            If MessageBox.Show("Batalkan mutasi stok?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                CancelData()
            End If
        End If
    End Sub

    'UI : SAVE
    Private Sub bt_simpanreturbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        'CHECK TANGGAL TRANSAKSI
        If date_tgl_beli.Value < TransStartDate Then
            MessageBox.Show("Tanggal transaksi tidak bisa kurang dari periode aktif. " & TransStartDate.ToString("(MMMM yyyy)"),
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            date_tgl_beli.Focus() : Exit Sub
        End If

        'CHECK INPUT DATA
        For Each x As TextBox In {in_gudang, in_gudang2}
            Dim Msg As String = "{0} belum diinput"
            Dim _input As TextBox
            Select Case x.Name
                Case in_gudang2.Name : Msg = String.Format(Msg, "Gudang Tujuan") : _input = in_gudang2_n
                Case in_gudang.Name : Msg = String.Format(Msg, "Gudang Asal") : _input = in_gudang_n
                Case Else : Exit Sub
            End Select

            If String.IsNullOrWhiteSpace(x.Text) Then
                MessageBox.Show(Msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                _input.Focus() : Exit Sub
            End If
        Next
        If in_gudang.Text = in_gudang2.Text Then
            MessageBox.Show("Gudang asal dan tujuan sama", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_gudang.Focus() : Exit Sub
        End If

        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum dimasukkan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_barang.Focus() : Exit Sub
        End If

        Dim _retMsg As DialogResult = Windows.Forms.DialogResult.Yes
        If Not formstate = InputState.Insert Then _retMsg = MessageBox.Show("Simpan Data mutasi?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _retMsg = Windows.Forms.DialogResult.Yes Then SaveData()
    End Sub

    'UI : NUMERIC
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty1.Enter, in_qty2.Enter, in_qty3.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty1.Leave, in_qty2.Leave, in_qty3.Leave
        numericLostFocus(sender, "N0")
    End Sub

    'UI : INPUT
    Private Sub in_kode_KeyUp(sender As Object, e As KeyEventArgs) Handles in_kode.KeyUp
        keyshortenter(date_tgl_beli, e)
    End Sub

    Private Sub date_tgl_beli_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyUp
        keyshortenter(cb_pajak, e)
    End Sub

    Private Sub cb_pajak_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_pajak.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cb_pajak_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_pajak.KeyUp
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_gudang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyUp
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_gudang_n_Enter(sender As Object, e As EventArgs) Handles in_gudang_n.Enter, in_gudang2_n.Enter, in_barang_nm.Enter
        If sender.Readonly = False Then
            Select Case sender.Name.ToString
                Case "in_gudang_n"
                    popupstate = "gudang"
                Case "in_gudang2_n"
                    popupstate = "gudang2"
                Case "in_barang_nm"
                    popupstate = "barang"
            End Select
            popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.BringToFront()
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup(popupstate, sender.Text)
        End If
    End Sub

    Private Sub in_gudang_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyDown, in_gudang2_n.KeyDown, in_barang_nm.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then e.SuppressKeyPress = True
    End Sub

    Private Sub in_gudang_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyUp, in_gudang2_n.KeyUp, in_barang_nm.KeyUp
        Dim _next As Object : Dim _id As TextBox
        Select Case sender.Name
            Case "in_gudang_n" : _next = in_gudang2_n : _id = in_gudang
            Case "in_gudang2_n" : _next = in_barang_nm : _id = in_gudang2
            Case "in_barang_nm" : _next = in_qty1 : _id = in_barang
            Case Else : Exit Sub
        End Select

        Dim _x = PopUpSearchInputHandle_inputKeyup(e, sender, _id, popPnl_barang, dgv_listbarang)
        For Each _resp As String In _x
            Select Case _resp
                Case "set" : setPopUpResult()
                Case "next" : keyshortenter(_next, e)
                Case "load" : loadDataBRGPopup(popupstate, sender.Text)
            End Select
        Next
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_gudang2_n.Leave, in_gudang_n.Leave, in_barang_nm.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_gudang2_KeyUp(sender As Object, e As KeyEventArgs) Handles in_gudang2.KeyUp
        keyshortenter(in_gudang2_n, e)
    End Sub

    Private Sub in_barang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_barang.KeyUp
        keyshortenter(in_barang_nm, e)
    End Sub

    Private Sub in_qty1_KeyUp(sender As Object, e As KeyEventArgs) Handles in_qty1.KeyUp
        keyshortenter(in_qty2, e)
    End Sub

    Private Sub in_qty2_KeyUp(sender As Object, e As KeyEventArgs) Handles in_qty2.KeyUp
        keyshortenter(in_qty3, e)
    End Sub

    Private Sub in_qty3_KeyUp(sender As Object, e As KeyEventArgs) Handles in_qty3.KeyUp
        keyshortenter(bt_tbbarang, e)
    End Sub

    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        textToDGV()
    End Sub

    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            dgvToTxt()
        End If
    End Sub
End Class