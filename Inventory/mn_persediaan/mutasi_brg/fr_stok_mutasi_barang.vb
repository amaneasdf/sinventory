Public Class fr_stok_mutasi_barang
    Private _status As String = 1
    Private _hppasal As Decimal = 0
    Private formstate As InputState = InputState.Insert
    Private popupstate As String = ""

    Private Enum InputState
        Insert
        Edit
        View
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(NoFaktur As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Mutasi Barang : rj20190810902"

        formstate = FormSet

        With cb_pajak
            .DataSource = jenis("bayar_pajak")
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With

        With date_tgl_beli
            .MaxDate = selectperiode.tglakhir
            .MinDate = selectperiode.tglawal
            If selectperiode.tglakhir >= Today Then
                .Value = Today
            Else
                .Value = selectperiode.tglakhir
            End If
        End With

        If formstate = InputState.Edit Or formstate = InputState.View Then
            Me.Text += NoFaktur
            Me.lbl_title.Text += " : " & NoFaktur
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            loadData(NoFaktur)
            in_kode.ReadOnly = True
            If Not {0, 1}.Contains(_status) Then AllowEdit = False
            If formstate = InputState.View Then AllowEdit = False

            bt_simpanbeli.Text = "Update"
        End If

        FormSwitch(AllowEdit)
    End Sub

    Private Sub FormSwitch(AllowEdit As Boolean)
        cb_pajak.Enabled = IIf(dgv_barang.RowCount > 0, False, AllowEdit)
        in_gudang_n.ReadOnly = IIf(dgv_barang.RowCount > 0, True, IIf(AllowEdit, False, True))
        date_tgl_beli.Enabled = AllowEdit

        bt_simpanbeli.Enabled = AllowEdit

        mn_save.Enabled = AllowEdit
        mn_cancel.Enabled = IIf({0, 1}.Contains(_status), AllowEdit, False)
        mn_print.Enabled = False

        For Each x As Control In {in_barang, in_barang_nm, in_qty1, in_qty2, in_sat1, in_sat2, in_hpp, bt_tbbarang}
            x.Visible = AllowEdit
        Next

        If AllowEdit Then
            dgv_barang.Location = New Point(12, 115) : dgv_barang.Height = 192
            AddHandler dgv_barang.CellDoubleClick, AddressOf dgv_barang_CellDoubleClick
        Else
            dgv_barang.Location = New Point(12, 55) : dgv_barang.Height = 252
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
    Private Sub loadData(kode As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If
        Dim q As String = ""
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT faktur_kode, faktur_pajak, faktur_tanggal, faktur_gudang, gudang_nama, faktur_ket, faktur_reg_alias, " _
                    & "faktur_reg_date, IFNULL(faktur_upd_alias,'') faktur_upd_alias, " _
                    & "IFNULL(CAST(DATE_FORMAT(faktur_upd_date,'%d/%m/%Y %H:%i:%s') AS CHAR),'') faktur_upd_date, " _
                    & "faktur_status FROM data_barang_mutasi " _
                    & "LEFT JOIN data_barang_gudang ON gudang_kode=faktur_gudang " _
                    & "WHERE faktur_kode ='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, kode))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_kode.Text = rdx.Item("faktur_kode")
                        date_tgl_beli.Value = rdx.Item("faktur_tanggal")
                        cb_pajak.SelectedValue = rdx.Item("faktur_pajak")
                        in_gudang.Text = rdx.Item("faktur_gudang")
                        in_gudang_n.Text = rdx.Item("gudang_nama")
                        in_ket.Text = rdx.Item("faktur_ket")
                        _status = rdx.Item("faktur_status")
                        txtRegAlias.Text = rdx.Item("faktur_reg_alias")
                        txtRegdate.Text = rdx.Item("faktur_reg_date")
                        txtUpdDate.Text = rdx.Item("faktur_upd_date")
                        txtUpdAlias.Text = rdx.Item("faktur_upd_alias")
                    End If
                End Using
                q = "SELECT trans_barang_asal, a.barang_nama, trans_qty_asal, trans_sat_asal,trans_hpp_asal, " _
                    & "trans_barang_tujuan, b.barang_nama, trans_qty_tujuan, trans_sat_tujuan,trans_hpp_tujuan " _
                    & "FROM data_barang_mutasi_trans " _
                    & "LEFT JOIN data_barang_master a ON a.barang_kode=trans_barang_asal " _
                    & "LEFT JOIN data_barang_master b ON b.barang_kode=trans_barang_tujuan " _
                    & "WHERE trans_faktur='{0}' AND trans_status=1"
                Using dt = x.GetDataTable(String.Format(q, kode))
                    With dgv_barang.Rows
                        For Each row As DataRow In dt.Rows
                            Dim i = .Add
                            .Item(i).Cells("kode").Value = row.ItemArray(0)
                            .Item(i).Cells("nama").Value = row.ItemArray(1)
                            .Item(i).Cells("qty_a").Value = row.ItemArray(2)
                            .Item(i).Cells("sat_a").Value = row.ItemArray(3)
                            .Item(i).Cells("hpp").Value = row.ItemArray(4)
                            .Item(i).Cells("kode_b").Value = row.ItemArray(5)
                            .Item(i).Cells("nama_b").Value = row.ItemArray(6)
                            .Item(i).Cells("qty_b").Value = row.ItemArray(7)
                            .Item(i).Cells("sat_b").Value = row.ItemArray(8)
                            .Item(i).Cells("hpp_b").Value = row.ItemArray(9)
                        Next
                    End With
                End Using
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
        Dim autoco As New AutoCompleteStringCollection
        Select Case tipe
            Case "barangasal", "barangtujuan"
                Dim _tgltrans As String = date_tgl_beli.Value.ToString("yyyy-MM-dd")
                Dim _exbarang As String = IIf(tipe = "barangasal", in_barang2.Text, in_barang.Text)
                q = "SELECT stock_barang 'Kode', barang_nama 'Nama Barang', SUM(trans_qty) as QTY, barang_satuan_kecil " _
                    & "FROM data_stok_awal " _
                    & "LEFT JOIN data_stok_kartustok ON stock_kode=trans_stock AND trans_status=1 " _
                    & "LEFT JOIN data_barang_master ON barang_kode=stock_barang " _
                    & "WHERE stock_kode=1 AND trans_tgl<='{1}' AND barang_pajak={3} AND stock_gudang='{2}' " _
                    & "AND (barang_nama LIKE '%{0}%' OR stock_barang LIKE '%{0}%') AND barang_kode <> '{4}' GROUP BY stock_barang LIMIT 250"
                q = String.Format(q, "{0}", _tgltrans, in_gudang.Text, cb_pajak.SelectedValue, _exbarang)

            Case "gudang"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang " _
                    & "WHERE gudang_status=1 AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%')"
            Case Else
                Exit Sub
        End Select

        Using x = MainConnection : dt = x.GetDataTable(String.Format(q, param)) : End Using

        With dgv_listbarang
            .DataSource = dt
            If .ColumnCount >= 2 Then
                If {"barangasal", "barangtujuan"}.Contains(tipe) Then
                    .Columns(0).Width = 100 : .Columns(1).Width = 175
                    .Columns(2).DefaultCellStyle = dgvstyle_commathousand
                    .Columns(3).Visible = False
                Else
                    .Columns(0).Width = 125 : .Columns(1).Width = 200
                End If
                If .DisplayedColumnCount(False) <= 3 Then .Columns(.DisplayedColumnCount(False) - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
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
                Case "barangasal"
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
                    _hppasal = getHpp(in_barang.Text)
                    in_qty1.Focus()
                Case "barangtujuan"
                    in_barang2.Text = .Cells(0).Value
                    in_barang_nm2.Text = .Cells(1).Value
                    in_qty2.Value = in_qty1.Value
                    in_sat2.Text = .Cells(3).Value
                    in_hpp.Value = getHpp(in_barang2.Text)
                    in_qty2.Focus()
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    in_barang_nm.Focus()
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
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT getHppAvg_v2('{0}','{1}')"
                q = String.Format(q, KodeBrg, date_tgl_beli.Value.ToString("yyyy-MM-dd"))
                retval = x.ExecScalar(q)
            End If
        End Using

        Return retval
    End Function

    'ADD INPUT FROM TEXTBOX TO DGV
    Private Sub textToDGV()
        If in_barang_nm.Text = Nothing Then
            MessageBox.Show("Barang asal belum diinput.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_barang.Focus()
            Exit Sub
        End If
        If in_qty1.Value = 0 Or in_qty2.Value = 0 Then
            MessageBox.Show("Qty barang beum diinput.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_qty1.Focus()
            Exit Sub
        End If
        If in_barang_nm2.Text = Nothing Then
            MessageBox.Show("Barang tujuan belum diinput.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_barang2.Focus()
            Exit Sub
        End If
        If in_barang_nm.Text = in_barang_nm2.Text Then
            MessageBox.Show("Barang asal dan tujuan sama")
            in_barang.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim check As Boolean = False
        Dim input As Boolean = False
        If dgv_barang.RowCount > 0 Then
            For Each rows As DataGridViewRow In dgv_barang.Rows
                If rows.Cells("kode").Value = in_barang.Text And rows.Cells("kode_b").Value = in_barang2.Text Then
                    If MessageBox.Show("Barang yang sama sudah diinputkan ke dalam list, tambahkan qty pada barang tersebut?",
                                       "Mutasi Barang", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        rows.Cells("qty_a").Value += in_qty1.Value
                        rows.Cells("qty_b").Value += in_qty2.Value
                        check = True : input = True
                        Exit For
                    Else
                        check = True
                        Exit Sub
                    End If
                Else
                    Exit For
                End If
            Next
        End If

        If check = False Then
            With dgv_barang.Rows
                Dim x As Integer = .Add
                .Item(x).Cells("kode").Value = in_barang.Text
                .Item(x).Cells("nama").Value = in_barang_nm.Text
                .Item(x).Cells("qty_a").Value = in_qty1.Value
                .Item(x).Cells("sat_a").Value = in_sat1.Text
                .Item(x).Cells("hpp").Value = getHpp(in_barang.Text)
                .Item(x).Cells("kode_b").Value = in_barang2.Text
                .Item(x).Cells("nama_b").Value = in_barang_nm2.Text
                .Item(x).Cells("qty_b").Value = in_qty2.Value
                .Item(x).Cells("sat_b").Value = in_sat2.Text
                .Item(x).Cells("hpp_b").Value = in_hpp.Value
            End With
            input = True
        End If

        Me.Cursor = Cursors.Default

        If input Then : clearInputBarang() : in_gudang_n.ReadOnly = True : cb_pajak.Enabled = False : End If
        in_barang.Focus()
    End Sub

    'GET DATA FROM DGV
    Private Sub dgvToTxt()
        Dim _idx As Integer = 0
        With dgv_barang.SelectedRows.Item(0)
            _idx = .Index
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty1.Value = .Cells("qty_a").Value
            in_sat1.Text = .Cells("sat_a").Value
            _hppasal = .Cells("hpp").Value

            in_barang2.Text = .Cells("kode_b").Value
            in_barang_nm2.Text = .Cells("nama_b").Value
            in_qty2.Value = .Cells("qty_b").Value
            in_sat2.Text = .Cells("sat_b").Value
            in_hpp.Value = .Cells("hpp_b").Value
        End With
        dgv_barang.Rows.RemoveAt(_idx)

        If dgv_barang.RowCount = 0 Then
            cb_pajak.Enabled = True
            in_gudang_n.ReadOnly = False
        End If
        in_barang.Focus()
    End Sub

    Private Sub clearInputBarang()
        For Each txt As TextBox In {in_barang, in_barang_nm, in_barang2, in_barang_nm2, in_sat1, in_sat2}
            txt.Clear()
        Next
        For Each num As NumericUpDown In {in_qty1, in_qty2, in_hpp}
            num.Value = 0
        Next
        _hppasal = 0
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

                'GENERATE KODE
                in_kode.Text = Trim(in_kode.Text)
                datafaktur = {"faktur_tanggal='" & _tgltrans & "'",
                              "faktur_pajak='" & cb_pajak.SelectedValue & "'",
                              "faktur_gudang='" & in_gudang.Text & "'",
                              "faktur_ket='" & in_ket.Text & "'",
                              "faktur_status=1"
                             }
                '==========================================================================================================================
                'INSERT HEADER
                If formstate = InputState.Insert Then
                    If String.IsNullOrWhiteSpace(in_kode.Text) Then
                        'START OF GENERATING NEW CODE =============================================================================================
                        Try
                            Dim i As Integer = 0 : Dim format As String = "D3"
                            q = "SELECT IFNULL(MAX(SUBSTRING(faktur_kode, 11)),0) FROM data_barang_mutasi " _
                                & "WHERE faktur_kode LIKE 'MB{0:yyyyMMdd}%' AND SUBSTRING(faktur_kode,11) REGEXP '^[0-9]+$'"
                            i = CInt(x.ExecScalar(String.Format(q, date_tgl_beli.Value)))
                            format = IIf(i + 1 > 999, "D" & (i + 1).ToString.Length, "D3")
                            in_kode.Text = String.Format("MB{0:yyyyMMdd}", date_tgl_beli.Value) & (i + 1).ToString(format)

                        Catch ex As Exception
                            MessageBox.Show("Terjadi kesalahan dalam melakukan proses penyimpanan data." & Environment.NewLine & ex.Message,
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            logError(ex, True) : Exit Sub
                        End Try
                        'END OF GENERATING NEW CODE ===============================================================================================
                    Else
                        'START OF CHECKING USER INPUTED CODE ======================================================================================
                        q = "SELECT COUNT(faktur_kode) FROM data_barang_mutasi WHERE faktur_kode='{0}'"
                        If CInt(x.ExecScalar(String.Format(q, in_kode.Text))) > 0 Then
                            MessageBox.Show("Kode Mutasi sudah pernah diinputkan sebelumnya. Silahkan masukan kode lain.", Me.Text,
                                            MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            in_kode.Focus() : Exit Sub
                        End If
                        'END OF CHECKING USER INPUTED CODE ========================================================================================
                    End If
                    q = "INSERT INTO data_barang_mutasi SET faktur_kode='{0}',{1},faktur_reg_date=NOW(),faktur_reg_alias='{2}'"
                Else
                    q = "UPDATE data_barang_mutasi SET {1}, faktur_upd_date=NOW(), faktur_upd_alias='{2}' WHERE faktur_kode='{0}'"
                End If
                queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", datafaktur), loggeduser.user_id))
                '==========================================================================================================================

                '==========================================================================================================================
                'INSERT BARANG
                q = "UPDATE data_barang_mutasi_trans SET trans_status=9 WHERE trans_faktur='{0}'"
                queryArr.Add(String.Format(q, in_kode.Text))

                For Each rows As DataGridViewRow In dgv_barang.Rows
                    Dim _brgA As String = rows.Cells(0).Value
                    Dim _qtyA As Integer = rows.Cells("qty_a").Value
                    Dim _brgB As String = rows.Cells("kode_b").Value
                    Dim _qtyB As Integer = rows.Cells("qty_b").Value
                    Dim _hppA As Decimal = rows.Cells("hpp").Value
                    Dim _hppB As Decimal = rows.Cells("hpp_b").Value

                    dataBrg = {
                        "trans_barang_asal='" & _brgA & "'",
                        "trans_qty_asal=" & _qtyA,
                        "trans_sat_asal='" & rows.Cells("sat_a").Value & "'",
                        "trans_barang_tujuan='" & _brgB & "'",
                        "trans_qty_tujuan=" & _qtyB,
                        "trans_sat_tujuan='" & rows.Cells("sat_b").Value & "'",
                        "trans_hpp_asal=" & _hppA.ToString.Replace(",", "."),
                        "trans_hpp_tujuan=" & _hppB.ToString.Replace(",", "."),
                        "trans_status=1"
                        }
                    q = "INSERT INTO data_barang_mutasi_trans SET trans_faktur='{0}',{1} ON DUPLICATE KEY UPDATE {1}"
                    queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", dataBrg)))
                Next
                '==========================================================================================================================

                '==========================================================================================================================
                'OTHER PROCESS
                q = "CALL transMutasiBarangFin('{0}','{1}')"
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
                    DoRefreshTab_v2({pgstok, pgmutasistok})
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
                    q = "UPDATE data_barang_mutasi SET faktur_status=2, faktur_ket='{2}', faktur_upd_date =NOW(), faktur_upd_alias='{1}' WHERE faktur_kode='{0}'"
                    queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id, mysqlQueryFriendlyStringFeed(Trim(in_ket.Text))))

                    q = "CALL transMutasiBarangFin('{0}','{1}')"
                    queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id))

                    queryCk = x.TransactCommand(queryArr)
                End If

                If queryCk Then
                    MessageBox.Show("Transaksi mutasi dibatalkan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'doRefreshTab({pgmutasistok})
                    DoRefreshTab_v2({pgstok, pgmutasistok})
                    Me.Close()
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
        If Not in_barang_nm2.Focused Or in_gudang_n.Focused Or in_barang_nm.Focused Then
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
        If Char.IsLetterOrDigit(e.KeyChar) Then
            Dim x As TextBox
            Select Case popupstate
                Case "gudang"
                    x = in_gudang_n
                Case "barangasal"
                    x = in_barang_nm
                Case "barangtujuan"
                    x = in_barang_nm2
                Case Else : Exit Sub
            End Select
            PopUpSearchKeyPress(e, x)
        End If
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
        If {0, 1}.Contains(_status) And formstate <> InputState.Insert Then
            If MessageBox.Show("Batalkan mutasi stok?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                CancelData()
            End If
        End If
    End Sub

    'UI : SAVE
    Private Sub bt_simpanreturbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        If in_gudang.Text = Nothing Then
            MessageBox.Show("Gudang asal belum dimasukkan")
            in_gudang_n.Focus()
            Exit Sub
        End If

        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum dimasukkan")
            in_barang.Focus()
            Exit Sub
        End If

        Dim _resMsg As DialogResult = Windows.Forms.DialogResult.Yes
        If Not formstate = InputState.Insert Then _resMsg = MessageBox.Show("Simpan Data mutasi?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _resMsg = Windows.Forms.DialogResult.Yes Then SaveData()
    End Sub

    'UI : NUMERIC
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty1.Enter, in_qty2.Enter, in_hpp.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty1.Leave, in_qty2.Leave, in_hpp.Leave
        numericLostFocus(sender, IIf(sender.Name.ToString = "in_hpp", "N2", "N0"))
    End Sub

    'UI : INPUT
    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyUp
        keyshortenter(date_tgl_beli, e)
    End Sub

    Private Sub date_tgl_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyDown
        keyshortenter(cb_pajak, e)
    End Sub

    Private Sub cb_pajak_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_pajak.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cb_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_pajak.KeyUp
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyUp
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_gudang_n_Enter(sender As Object, e As EventArgs) Handles in_gudang_n.Enter, in_barang_nm2.Enter, in_barang_nm.Enter
        If sender.Readonly = False Then
            Select Case sender.Name.ToString
                Case "in_gudang_n"
                    popupstate = "gudang"
                Case "in_barang_nm2"
                    popupstate = "barangtujuan"
                Case "in_barang_nm"
                    popupstate = "barangasal"
            End Select
            popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
            If popPnl_barang.Visible = False And sender.Readonly = False Then
                popPnl_barang.BringToFront()
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup(popupstate, sender.Text)
        End If
    End Sub

    Private Sub in_gudang_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyDown, in_barang_nm2.KeyDown, in_barang_nm.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then e.SuppressKeyPress = True
    End Sub

    Private Sub in_gudang_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyUp, in_barang_nm2.KeyUp, in_barang_nm.KeyUp
        Dim _next As Object : Dim _id As TextBox
        Select Case sender.Name.ToString
            Case "in_gudang_n" : _next = in_barang_nm : _id = in_gudang
            Case "in_barang_nm2" : _next = in_qty2 : _id = in_barang2
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

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_barang_nm2.Leave, in_gudang_n.Leave, in_barang_nm.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_gudang_n_TextChanged(sender As Object, e As EventArgs) Handles in_barang_nm2.TextChanged, in_gudang_n.TextChanged, in_barang_nm.TextChanged
        Dim _kdcontrol As Object
        Select Case sender.Name.ToString
            Case "in_gudang_n"
                _kdcontrol = in_gudang
            Case "in_barang_nm2"
                _kdcontrol = in_barang2
            Case "in_barang_nm"
                _kdcontrol = in_barang
            Case Else
                Exit Sub
        End Select

        If sender.Text = "" Then _kdcontrol.Text = ""
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyUp
        keyshortenter(in_barang_nm, e)
    End Sub

    Private Sub in_barang2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang2.KeyUp
        keyshortenter(in_barang_nm2, e)
    End Sub

    Private Sub in_qty1_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty1.KeyUp
        keyshortenter(in_barang_nm2, e)
    End Sub

    Private Sub in_qty2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty2.KeyUp
        keyshortenter(in_hpp, e)
    End Sub

    Private Sub in_hpp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_hpp.KeyUp
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