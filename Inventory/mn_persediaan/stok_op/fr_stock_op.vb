﻿Public Class fr_stock_op
    Private _status As String = 0
    Private popupstate As String = "barang"
    Private _hppbrg As Decimal = 0
    Private _isitengah As Integer = 0
    Private _isibesar As Integer = 0
    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
        View
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(NoFaktur As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Stok Opname : op20190810902"

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
        in_ket.ReadOnly = IIf(AllowEdit, False, True)

        bt_simpanbeli.Enabled = AllowEdit

        mn_save.Enabled = AllowEdit
        mn_cancel.Enabled = IIf({0, 1}.Contains(_status), AllowEdit, False)
        mn_proses.Enabled = IIf(_status = 0, AllowEdit, False)
        mn_print.Enabled = False

        For Each x As Control In {in_barang, in_barang_nm, in_qty_b, in_qty_k, in_qty_t, in_qty_total, in_sat_b, in_sat_k, in_sat_t,
                                  in_qty_sys, in_qty_sys_n, in_hpp, bt_tbbarang}
            x.Visible = AllowEdit
        Next

        If AllowEdit Then
            dgv_barang.Location = New Point(12, 96) : dgv_barang.Height = 179
            AddHandler dgv_barang.CellDoubleClick, AddressOf dgv_barang_CellDoubleClick
        Else
            dgv_barang.Location = New Point(12, 57) : dgv_barang.Height = 218
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
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT faktur_bukti, faktur_pajak, faktur_tanggal, faktur_gudang, gudang_nama, faktur_status, faktur_ket, " _
                     & "IFNULL(DATE_FORMAT(faktur_reg_date,'%d/%m/%Y %H:%i:%S'),'') faktur_reg_date, IFNULL(faktur_reg_alias,'') faktur_reg_alias, " _
                     & "IFNULL(DATE_FORMAT(faktur_upd_date,'%d/%m/%Y %H:%i:%S'),'') faktur_upd_date, IFNULL(faktur_upd_alias,'') faktur_upd_alias, " _
                     & "IFNULL(DATE_FORMAT(faktur_proc_date,'%d/%m/%Y %H:%i:%S'),'') faktur_proc_date, IFNULL(faktur_proc_alias,'') faktur_proc_alias " _
                     & "FROM data_stok_opname " _
                     & "LEFT JOIN data_barang_gudang ON gudang_kode=faktur_gudang " _
                     & "WHERE faktur_bukti='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, NoFaktur))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_kode.Text = rdx.Item("faktur_bukti")
                        cb_pajak.SelectedValue = rdx.Item("faktur_pajak")
                        date_tgl_beli.Value = rdx.Item("faktur_tanggal")
                        in_gudang.Text = rdx.Item("faktur_gudang")
                        in_gudang_n.Text = rdx.Item("gudang_nama")
                        in_ket.Text = rdx.Item("faktur_ket")
                        _status = rdx.Item("faktur_status")
                        txtRegAlias.Text = rdx.Item("faktur_reg_alias")
                        txtRegdate.Text = rdx.Item("faktur_reg_date")
                        txtUpdDate.Text = rdx.Item("faktur_upd_date")
                        txtUpdAlias.Text = rdx.Item("faktur_upd_alias")
                        txtProcDate.Text = rdx.Item("faktur_proc_date")
                        txtProcAlias.Text = rdx.Item("faktur_proc_alias")
                    End If
                End Using
                q = "SELECT trans_barang, barang_nama, trans_qty_sys, getQTYDetail(trans_barang,trans_qty_sys,1), trans_satuan, " _
                    & "trans_qty_b_fis, trans_sat_b_fis, trans_qty_t_fis, trans_sat_t_fis, trans_qty_k_fis, " _
                    & "trans_qty_fisik, trans_hpp, trans_hpp_fisik " _
                    & "FROM data_stok_opname_trans LEFT JOIN data_barang_master ON trans_barang=barang_kode " _
                    & "WHERE trans_status=1 AND trans_faktur='{0}'"
                Using dt = x.GetDataTable(String.Format(q, NoFaktur))
                    With dgv_barang.Rows
                        For Each y As DataRow In dt.Rows
                            Dim i = .Add
                            .Item(i).Cells("kode").Value = y.ItemArray(0)
                            .Item(i).Cells("nama").Value = y.ItemArray(1)
                            .Item(i).Cells("qty_sys").Value = y.ItemArray(2)
                            .Item(i).Cells("qty_n_sys").Value = y.ItemArray(3)
                            .Item(i).Cells("sat_sys").Value = y.ItemArray(4)

                            .Item(i).Cells("qty_fis_b").Value = y.ItemArray(5)
                            .Item(i).Cells("sat_fis_b").Value = y.ItemArray(6)
                            .Item(i).Cells("qty_fis_t").Value = y.ItemArray(7)
                            .Item(i).Cells("sat_fis_t").Value = y.ItemArray(8)
                            .Item(i).Cells("qty_fis_k").Value = y.ItemArray(9)
                            .Item(i).Cells("sat_fis").Value = y.ItemArray(4)

                            .Item(i).Cells("qty_fis").Value = y.ItemArray(10)
                            .Item(i).Cells("qty_sel").Value = y.ItemArray(10) - y.ItemArray(2)
                            .Item(i).Cells("hpp").Value = y.ItemArray(11)
                            .Item(i).Cells("hpp_fis").Value = y.ItemArray(12)
                        Next
                    End With
                End Using
                'SET STATUS
                Select Case _status
                    Case 0 : in_status.Text = "Pending"
                    Case 1 : in_status.Text = "OK"
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
            Case "barang"
                Dim _tgltrans As String = date_tgl_beli.Value.ToString("yyyy-MM-dd")
                q = "SELECT stock_barang, barang_nama, SUM(trans_qty) as QTY, barang_satuan_kecil " _
                    & "FROM data_stok_awal " _
                    & "LEFT JOIN data_stok_kartustok ON stock_kode=trans_stock AND trans_status=1 " _
                    & "LEFT JOIN data_barang_master ON barang_kode=stock_barang " _
                    & "WHERE stock_kode=1 AND trans_tgl<='{1}' AND trans_periode={3} AND barang_pajak={4} AND stock_gudang='{2}' " _
                    & "AND (barang_nama LIKE '%{0}%' OR stock_barang LIKE '%{0}%') GROUP BY stock_barang LIMIT 250"
                q = String.Format(q, "{0}", _tgltrans, in_gudang.Text, selectperiode.id, cb_pajak.SelectedValue)

            Case "gudang"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang WHERE gudang_status=1 " _
                    & "AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%')"
            Case Else
                Exit Sub
        End Select

        dt = getDataTablefromDB(String.Format(q, param))

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 135
            .Columns(1).Width = 200
            If tipe = "barang" Then
                .Columns(2).DefaultCellStyle = dgvstyle_commathousand
                .Columns(3).Visible = False
            End If
        End With
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "barang"
                    in_barang.Text = .Cells(0).Value
                    in_barang_nm.Text = .Cells(1).Value
                    in_qty_sys.Text = commaThousand(.Cells(2).Value)
                    in_sat_k.Text = .Cells(3).Value
                    GetDataBarang(in_barang.Text)
                    in_qty_b.Focus()
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    in_barang_nm.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
    End Sub

    'GET DATA BARANG
    Private Sub GetDataBarang(KodeBrg As String)
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT barang_satuan_besar, barang_satuan_tengah, barang_satuan_besar_jumlah, barang_satuan_tengah_jumlah, " _
                    & "getQTYDetail(barang_kode,{1},1) FROM data_barang_master WHERE barang_kode='{0}'"
                q = String.Format(q, KodeBrg, removeCommaThousand(in_qty_sys.Text).ToString.Replace(",", "."))
                Using rdx = x.ReadCommand(q, CommandBehavior.SingleRow)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_sat_b.Text = rdx.Item(0)
                        in_sat_t.Text = rdx.Item(1)
                        _isibesar = rdx.Item(2)
                        _isitengah = rdx.Item(3)
                        in_qty_sys_n.Text = rdx.Item(4)
                    End If
                End Using

                q = "SELECT getHppAvg_v2('{0}','{1}')"
                q = String.Format(q, KodeBrg, date_tgl_beli.Value.ToString("yyyy-MM-dd"))
                Using rdx = x.ReadCommand(q, CommandBehavior.SingleRow)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _hppbrg = rdx.Item(0)
                        in_hpp.Value = _hppbrg
                    End If
                End Using

            End If
        End Using
    End Sub

    'ADD INPUT FROM TEXTBOX TO DGV
    Private Sub textToDGV()
        If in_barang.Text = Nothing Then
            MessageBox.Show("Barang belum diinput.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_barang_nm.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim check As Boolean = False
        Dim input As Boolean = False
        If dgv_barang.RowCount > 0 Then
            For Each rows As DataGridViewRow In dgv_barang.Rows
                If rows.Cells("kode").Value = in_barang.Text Then
                    If MessageBox.Show("Barang yang sama sudah diinputkan ke dalam list, tambahkan qty pada barang tersebut?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        rows.Cells("qty_fis_b").Value += in_qty_b.Value
                        rows.Cells("qty_fis_t").Value += in_qty_t.Value
                        rows.Cells("qty_fis_k").Value += in_qty_k.Value
                        rows.Cells("qty_fis").Value += removeCommaThousand(in_qty_total.Text)
                        rows.Cells("qty_sys").Value = removeCommaThousand(in_qty_sys.Text)
                        rows.Cells("qty_n_sys").Value = in_qty_sys_n.Text
                        rows.Cells("hpp_fis").Value = in_hpp.Value
                        rows.Cells("qty_sel").Value = rows.Cells("qty_fis").Value - rows.Cells("qty_sys").Value
                        check = True : input = True
                        Exit For
                    Else
                        check = True
                        Exit For
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
                .Item(x).Cells("qty_sys").Value = removeCommaThousand(in_qty_sys.Text)
                .Item(x).Cells("qty_n_sys").Value = in_qty_sys_n.Text
                .Item(x).Cells("sat_sys").Value = in_sat_k.Text

                .Item(x).Cells("qty_fis_b").Value = in_qty_b.Value
                .Item(x).Cells("sat_fis_b").Value = in_sat_b.Text
                .Item(x).Cells("qty_fis_t").Value = in_qty_t.Value
                .Item(x).Cells("sat_fis_t").Value = in_sat_t.Text
                .Item(x).Cells("qty_fis_k").Value = in_qty_k.Value
                .Item(x).Cells("sat_fis").Value = in_sat_k.Text

                .Item(x).Cells("qty_fis").Value = removeCommaThousand(in_qty_total.Text)
                .Item(x).Cells("qty_sel").Value = removeCommaThousand(in_qty_total.Text) - removeCommaThousand(in_qty_sys.Text)
                .Item(x).Cells("hpp").Value = _hppbrg
                .Item(x).Cells("hpp_fis").Value = in_hpp.Value
                input = True
            End With
        End If

        If input Then : clearInputBarang() : cb_pajak.Enabled = False : in_gudang_n.ReadOnly = True : End If
        Me.Cursor = Cursors.Default

        in_barang.Focus()
    End Sub

    'GET DATA FROM DGV
    Private Sub dgvToTxt()
        Dim _idx As Integer = 0
        With dgv_barang.SelectedRows.Item(0)
            _idx = .Index
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty_sys.Text = commaThousand(.Cells("qty_sys").Value)

            in_qty_b.Value = .Cells("qty_fis_b").Value
            in_qty_t.Value = .Cells("qty_fis_t").Value
            in_qty_k.Value = .Cells("qty_fis_k").Value
            in_sat_k.Text = .Cells("sat_fis").Value

            in_hpp.Value = .Cells("hpp_fis").Value
            GetDataBarang(in_barang.Text)
        End With
        dgv_barang.Rows.RemoveAt(_idx)
        in_barang.Focus()

        If dgv_barang.RowCount = 0 Then
            in_gudang_n.ReadOnly = False
            cb_pajak.Enabled = True
        End If
    End Sub

    Private Sub clearInputBarang()
        For Each txt As TextBox In {in_barang, in_barang_nm, in_sat_b, in_sat_t, in_sat_k, in_qty_total, in_qty_sys, in_qty_sys_n}
            txt.Clear()
        Next
        For Each num As NumericUpDown In {in_qty_b, in_qty_t, in_qty_k, in_hpp}
            num.Value = 0
        Next
        _hppbrg = 0
    End Sub

    'SAVE
    Private Sub saveData()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim querycheck As String = False
        Dim queryArr As New List(Of String)
        Dim datafaktur, dataBrg As String()
        Dim q As String = ""

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Dim _tgltrans As String = date_tgl_beli.Value.ToString("yyyy-MM-dd")
                Dim _kode As String = ""

                'GENERATE KODE
                in_kode.Text = Trim(in_kode.Text)
                If in_kode.Text = Nothing Then
                    Dim no As Integer = 1
                    Dim tgl As String = date_tgl_beli.Value.ToString("yyyyMMdd")
                    q = "SELECT COUNT(DISTINCT faktur_bukti) FROM data_stok_opname WHERE faktur_tanggal='{0}' AND faktur_bukti LIKE 'OP%'"
                    Using rdx = x.ReadCommand(String.Format(q, date_tgl_beli.Value.ToString("yyyy-MM-dd")))
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            no = CInt(rdx.Item(0)) + 1
                        End If
                    End Using
                    in_kode.Text = "OP" & tgl & no.ToString("D3")
                ElseIf in_kode.Text <> Nothing And formstate = InputState.Insert Then
                    q = "SELECT faktur_bukti FROM data_stok_opname WHERE faktur_bukti='{0}'"
                    Dim _ck As Boolean = True
                    Dim _msg As String = ""
                    Using rdx = x.ReadCommand(String.Format(q, in_kode.Text))
                        Dim red = rdx.Read
                        If red Then
                            If rdx.HasRows Then
                                _ck = False
                                _msg = "Kode " & in_kode.Text & " sudah pernah diinput."
                            End If
                        End If
                    End Using
                    If _ck = False Then
                        MessageBox.Show("Data tidak dapat tersimpan." & Environment.NewLine & _msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If

                '==========================================================================================================================
                'INSERT HEADER
                _kode = in_kode.Text
                datafaktur = {
                        "faktur_tanggal='" & _tgltrans & "'",
                        "faktur_pajak='" & cb_pajak.SelectedValue & "'",
                        "faktur_gudang='" & in_gudang.Text & "'",
                        "faktur_ket='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
                        "faktur_status='" & _status & "'"
                        }
                If formstate = InputState.Insert Then
                    q = "INSERT INTO data_stok_opname SET faktur_bukti='{0}',{1},faktur_reg_date=NOW(), faktur_reg_alias='{2}'"
                Else
                    q = "UPDATE data_stok_opname SET {1},faktur_upd_date=NOW(),faktur_upd_alias='{2}' WHERE faktur_bukti='{0}'"
                End If
                queryArr.Add(String.Format(q, _kode, String.Join(",", datafaktur), loggeduser.user_id))
                '==========================================================================================================================

                '==========================================================================================================================
                'INSERT BARANG
                q = "UPDATE data_stok_opname_trans SET trans_status=9 WHERE trans_faktur='{0}'"
                queryArr.Add(String.Format(q, in_kode.Text))

                For Each rows As DataGridViewRow In dgv_barang.Rows
                    dataBrg = {
                        "trans_barang='" & rows.Cells(0).Value & "'",
                        "trans_qty_sys=" & CInt(rows.Cells("qty_sys").Value).ToString.Replace(",", "."),
                        "trans_satuan='" & rows.Cells("sat_fis").Value & "'",
                        "trans_qty_b_fis=" & CInt(rows.Cells("qty_fis_b").Value).ToString.Replace(",", "."),
                        "trans_sat_b_fis='" & rows.Cells("sat_fis_b").Value & "'",
                        "trans_qty_t_fis=" & CInt(rows.Cells("qty_fis_t").Value).ToString.Replace(",", "."),
                        "trans_sat_t_fis='" & rows.Cells("sat_fis_t").Value & "'",
                        "trans_qty_k_fis=" & CInt(rows.Cells("qty_fis_k").Value).ToString.Replace(",", "."),
                        "trans_qty_fisik=" & CInt(rows.Cells("qty_fis").Value).ToString.Replace(",", "."),
                        "trans_hpp=" & CDbl(rows.Cells("hpp").Value).ToString.Replace(",", "."),
                        "trans_hpp_fisik=" & CDbl(rows.Cells("hpp_fis").Value).ToString.Replace(",", "."),
                        "trans_status=1"
                        }
                    q = "INSERT INTO data_stok_opname_trans SET trans_faktur='{0}',{1} ON DUPLICATE KEY UPDATE {1}"
                    queryArr.Add(String.Format(q, _kode, String.Join(",", dataBrg)))
                Next
                '==========================================================================================================================

                '==========================================================================================================================
                'OTHER PROCESS
                q = "CALL transMutasiOpnameFin('{0}','{1}')"
                queryArr.Add(String.Format(q, _kode, loggeduser.user_id))
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
                    MessageBox.Show("Data Opname tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'doRefreshTab({pgstockop})
                    DoRefreshTab_v2({pgstockop})
                    Me.Close()
                End If
            End If
        End Using

    End Sub

    'CANCEL
    Private Sub cancelData()
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
                    q = "UPDATE data_stok_opname SET faktur_status=2, faktur_ket='{2}', faktur_proc_date =NOW(), faktur_proc_alias='{1}' WHERE faktur_bukti='{0}'"
                    queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id, mysqlQueryFriendlyStringFeed(Trim(in_ket.Text))))

                    q = "CALL transMutasiOpnameFin('{0}','{1}')"
                    queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id))

                    queryCk = x.TransactCommand(queryArr)
                End If

                If queryCk Then
                    MessageBox.Show("Transaksi Opname dibatalkan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    doRefreshTab({pgstockop})
                    Me.Close()
                Else
                    MessageBox.Show("Error. Transaksi gagal dibatalkan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End If
    End Sub

    'PROSES
    Private Sub prosesData()
        If _status = 0 Then
            If TransConfirmValid(in_ket.Text) Then
                _status = 1
                saveData()
            End If
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        If MessageBox.Show("Tutup Form Opname Stok?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
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
        If Not in_gudang_n.Focused Or in_barang_nm.Focused Then
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
            'consoleWriteLine("fuck")
            e.SuppressKeyPress = True
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyUp
        If e.KeyCode = Keys.Enter Then
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            Dim x As TextBox
            Select Case popupstate
                Case "gudang"
                    x = in_gudang_n
                Case "barang"
                    x = in_barang_nm
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

    'UI :MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanbeli.PerformClick()
    End Sub

    Private Sub mn_print_Click(sender As Object, e As EventArgs) Handles mn_print.Click

    End Sub

    Private Sub mn_proses_Click(sender As Object, e As EventArgs) Handles mn_proses.Click
        If _status = 0 And formstate <> InputState.Insert Then
            If MessageBox.Show("Proses Opname stok?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                prosesData()
            End If
        End If
    End Sub

    Private Sub mn_cancel_Click(sender As Object, e As EventArgs) Handles mn_cancel.Click
        If {0, 1}.Contains(_status) And formstate <> InputState.Insert Then
            If MessageBox.Show("Batalkan opname stok?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cancelData()
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

        If MessageBox.Show("Simpan Data Opname stok?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            saveData()
        End If
    End Sub

    'UI : NUMERIC
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty_b.Enter, in_qty_t.Enter, in_qty_k.Enter, in_hpp.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty_b.Leave, in_qty_t.Leave, in_qty_k.Leave, in_hpp.Leave
        numericLostFocus(sender, IIf(sender.Name.ToString = "in_hpp", "N2", "N0"))
    End Sub

    Private Sub in_qty_b_ValueChanged(sender As Object, e As EventArgs) Handles in_qty_t.ValueChanged, in_qty_k.ValueChanged, in_qty_b.ValueChanged
        Dim _qtybesar As Integer = _isibesar * _isitengah * in_qty_b.Value
        Dim _qtytengah As Integer = _isitengah * in_qty_t.Value

        in_qty_total.Text = commaThousand(_qtybesar + _qtytengah + in_qty_k.Value)
    End Sub

    'UI : INPUT
    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(date_tgl_beli, e)
    End Sub

    Private Sub date_tgl_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyDown
        keyshortenter(cb_pajak, e)
    End Sub

    Private Sub cb_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_pajak.KeyDown
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub cb_pajak_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_pajak.KeyPress
        If e.KeyChar <> Chr(Keys.Enter) Then
            e.Handled = True
        End If
    End Sub

    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_gudang_n_Enter(sender As Object, e As EventArgs) Handles in_gudang_n.Enter, in_barang_nm.Enter
        If sender.Readonly = False Then
            Select Case sender.Name.ToString
                Case "in_gudang_n"
                    popupstate = "gudang"
                Case "in_barang_nm"
                    popupstate = "barang"
            End Select
            popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
            If popPnl_barang.Visible = False And sender.Readonly = False Then
                popPnl_barang.BringToFront()
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup(popupstate, sender.Text)
        End If
    End Sub

    Private Sub in_gudang_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyDown, in_barang_nm.KeyDown
        Dim _nxtcontrol As Object
        Dim _kdcontrol As Object
        Select Case sender.Name.ToString
            Case "in_gudang_n"
                _nxtcontrol = in_barang_nm
                _kdcontrol = in_gudang
            Case "in_barang_nm"
                _nxtcontrol = in_qty_b
                _kdcontrol = in_barang
            Case Else
                Exit Sub
        End Select

        If sender.Text = "" And IsNothing(_kdcontrol) = False Then
            _kdcontrol.Text = ""
        End If

        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(_nxtcontrol, e)
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            End If
        Else
            If e.KeyCode <> Keys.Escape And sender.ReadOnly = False Then
                If popPnl_barang.Visible = False Then
                    popPnl_barang.Visible = True
                End If
                If e.KeyCode = Keys.Back And IsNothing(_kdcontrol) = False And sender.SelectionStart > 0 Then _kdcontrol.Text = ""
                loadDataBRGPopup(popupstate, sender.Text)
            End If
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_gudang_n.Leave, in_barang_nm.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_gudang_n_TextChanged(sender As Object, e As EventArgs) Handles in_gudang_n.TextChanged, in_barang_nm.TextChanged
        Dim _kdcontrol As Object
        Select Case sender.Name.ToString
            Case "in_gudang_n"
                _kdcontrol = in_gudang
            Case "in_barang_nm"
                _kdcontrol = in_barang
            Case Else
                Exit Sub
        End Select

        If sender.Text = "" Then _kdcontrol.Text = ""
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        keyshortenter(in_barang_nm, e)
    End Sub

    Private Sub in_qty_b_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty_b.KeyDown
        keyshortenter(in_qty_t, e)
    End Sub

    Private Sub in_qty_t_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty_t.KeyDown
        keyshortenter(in_qty_k, e)
    End Sub

    Private Sub in_qty_k_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty_k.KeyDown
        keyshortenter(in_hpp, e)
    End Sub

    Private Sub in_hpp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_hpp.KeyDown
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