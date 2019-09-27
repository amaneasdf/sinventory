Public Class fr_pesan_detail
    'note
    'penjualana bisa untuk input & validasi -> hutang custo
    'alur so -> sales>validasi>admin>gudang

    Private jeniscusto As String = ""
    Private priority_custo As Boolean = False
    Public tjlStatus As String = 0
    Private popupstate As String = "barang"
    Private isibesar As Integer = 0
    Private isitengah As Integer = 0
    Private _satuanstate As String = "kecil"
    Private term As Integer = 0
    Private state As String = "order"
    Private ValidUid As String = ""

    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
        View
        Valid
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(NoFaktur As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Form Order Penjualan : pp20190810902"
        formstate = FormSet

        'For Each x As DateTimePicker In {date_tgl_beli}
        '    x.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        '    x.MaxDate = selectperiode.tglakhir
        '    x.MinDate = selectperiode.tglawal
        'Next
        For Each x As DateTimePicker In {date_tgl_beli}
            x.Value = IIf(DataListEndDate > Today, Today, DataListEndDate)
            x.MinDate = If(formstate = InputState.Insert, TransStartDate, DataListStartDate)
            x.MaxDate = DataListEndDate
        Next

        With cb_term
            .DataSource = jenis("term")
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With

        With cb_status
            .DataSource = jenis("validasi")
            .ValueMember = "Value"
            .DisplayMember = "Text"
            .SelectedIndex = -1
        End With

        With cb_ppn
            .DataSource = jenis("jenis_ppn")
            .ValueMember = "Value"
            .DisplayMember = "Text"
            .SelectedValue = 1
        End With

        If formstate <> InputState.Insert Then
            Me.Text += NoFaktur
            Me.lbl_title.Text += " : " & NoFaktur
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            loadDataFaktur(NoFaktur)
            If tjlStatus <> 0 Then AllowEdit = False
            If formstate = InputState.Valid And (tjlStatus <> 0 Or Not loggeduser.validasi_trans) Then formstate = InputState.View
            If date_tgl_beli.Value < TransStartDate Then formstate = InputState.View
            If formstate = InputState.View Then AllowEdit = False
        End If

        ControlSwitch(formstate, AllowEdit)
    End Sub

    Private Sub ControlSwitch(FormSet As InputState, AllowInput As Boolean)
        Dim _dgv_input As Boolean = AllowInput
        Dim _custo_info As Boolean = False

        If FormSet = InputState.Valid Then
            For Each txt As TextBox In {in_custo_n, in_sales_n, in_gudang_n}
                txt.ReadOnly = True
            Next
            cb_ppn.Enabled = False

            bt_simpanjual.Visible = False
            bt_createjual.Visible = True
            bt_createjual.Enabled = True
            cb_status.Visible = True

            valid_ck.Visible = True
            trans_status.Visible = False
            qty_sisa.Visible = True
            kode.Visible = False

            mn_validasi.Visible = False
            mn_cancel.Visible = False

            _custo_info = True
            _dgv_input = False
        Else
            For Each txt As TextBox In {in_custo_n, in_ket}
                txt.ReadOnly = IIf(AllowInput, False, True)
            Next
            For Each cb As ComboBox In {cb_term}
                cb.Enabled = AllowInput
            Next
            date_tgl_beli.Enabled = AllowInput

            in_gudang_n.ReadOnly = If(dgv_barang.RowCount > 0, True, IIf(AllowInput, False, True))
            in_sales_n.ReadOnly = If(dgv_barang.RowCount > 0, True, IIf(AllowInput, False, True))
            cb_ppn.Enabled = If(dgv_barang.RowCount > 0, False, AllowInput)

            kode.Visible = True
            valid_ck.Visible = False
            trans_status.Visible = If(AllowInput, False, True)
            qty_sisa.Visible = False

            cb_status.Visible = False
            bt_createjual.Visible = False
            bt_simpanjual.Visible = True
            bt_simpanjual.Enabled = AllowInput

            mn_save.Enabled = AllowInput
            mn_validasi.Visible = True
            mn_validasi.Enabled = IIf(AllowInput And FormSet = InputState.Edit, loggeduser.validasi_trans, False)
            mn_cancel.Visible = False
            mn_cancel.Enabled = AllowInput
            mn_createjual.Enabled = IIf(String.IsNullOrWhiteSpace(in_ref_faktur.Text) And tjlStatus = 1, True, False)
        End If

        bt_simpanjual.Text = If(formstate = InputState.Insert, "Simpan", "Update")
        lbl_ref_faktur.Visible = IIf(formstate = InputState.Insert, False, IIf(tjlStatus = 1, True, False))
        in_ref_faktur.Visible = IIf(formstate = InputState.Insert, False, IIf(tjlStatus = 1, True, False))
        For Each x As Object In {in_barang, in_barang_nm, in_qty, cb_sat, in_harga_beli, in_disc1, in_disc2, in_disc3, in_disc4, in_disc5,
                                 in_discrp, in_subtotal, bt_tbbarang}
            x.Visible = _dgv_input
        Next
        For Each x As DataGridViewColumn In {harga, discrp, jml, subtotal, disc1, disc2, disc3, disc4, disc5, discrp}
            x.DefaultCellStyle = dgvstyle_currency
        Next
        If _dgv_input Then
            dgv_barang.Location = New Point(12, 148) : dgv_barang.Height = 186
            AddHandler dgv_barang.CellDoubleClick, AddressOf dgv_barang_CellDoubleClick
        Else
            dgv_barang.Location = New Point(12, 107) : dgv_barang.Height = 227
            RemoveHandler dgv_barang.CellDoubleClick, AddressOf dgv_barang_CellDoubleClick
        End If

        lbl_piutang.Visible = _custo_info
        in_piutang.Visible = _custo_info
        If _custo_info And Not String.IsNullOrWhiteSpace(in_custo_n.Text) Then
            loadDataCusto(in_custo.Text)
        End If
    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        Dim saleskode As String = loggeduser.saleskode

        SetUpForm(Nothing, InputState.Insert, AllowInput)
        If Not String.IsNullOrWhiteSpace(saleskode) Then
            in_sales_n.Text = getSales(saleskode)
            in_sales.Text = IIf(Not String.IsNullOrWhiteSpace(in_sales_n.Text), saleskode, "")
        End If

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

    Public Sub doLoadValid(NoFaktur As String)
        SetUpForm(NoFaktur, InputState.Valid, Nothing)
        Me.Show(main)
    End Sub

    Private Sub loadDataCusto(KodeCusto As String)
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        in_piutang.Text = commaThousand(GetPiutangCusto(KodeCusto))
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT customer_priority FROM data_customer_master WHERE customer_kode='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, KodeCusto))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        priority_custo = IIf(rdx.Item(0) = 1, True, False)
                    End If
                End Using
            End If
        End Using
    End Sub
    '^ UNFINISHED USE ONE BELLOW


    Private Function getSales(kode As String) As String
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = "SELECT salesman_nama FROM data_salesman_master WHERE salesman_kode='{0}'"
                Try
                    Return CStr(x.ExecScalar(String.Format(q, kode)))
                Catch ex As Exception
                    logError(ex, True)
                    Return String.Empty
                End Try
            Else
                Return String.Empty
            End If
        End Using
    End Function

    Private Sub loadDataFaktur(kode As String)
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        q = "CALL getTransHeader('PESAN','{0}')"
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Using rdx = x.ReadCommand(String.Format(q, kode))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_faktur.Text = kode
                        date_tgl_beli.Value = rdx.Item("j_order_tanggal_trans")
                        in_gudang.Text = rdx.Item("j_order_gudang")
                        in_gudang_n.Text = rdx.Item("gudang_nama")
                        in_sales.Text = rdx.Item("j_order_sales")
                        in_sales_n.Text = rdx.Item("salesman_nama")
                        in_custo.Text = rdx.Item("j_order_customer")
                        in_custo_n.Text = rdx.Item("customer_nama")
                        in_custo_al.Text = rdx.Item("customer_alamat")
                        jeniscusto = rdx.Item("customer_kriteria_harga_jual")
                        cb_term.SelectedValue = If(rdx.Item("j_order_term") > 0, 1, 0)
                        cb_ppn.SelectedValue = rdx.Item("j_order_ppn_jenis")

                        in_ket.Text = rdx.Item("j_order_catatan")
                        tjlStatus = rdx.Item("j_order_status")
                        in_ref_faktur.Text = rdx.Item("j_order_ref_faktur")

                        txtRegAlias.Text = rdx.Item("j_order_reg_alias")
                        txtRegdate.Text = rdx.Item("j_order_reg_date")
                        txtUpdDate.Text = rdx.Item("j_order_upd_date")
                        txtUpdAlias.Text = rdx.Item("j_order_upd_alias")
                        txtValDate.Text = rdx.Item("j_order_valid_date")
                        txtValAlias.Text = rdx.Item("j_order_valid_alias")
                    End If
                End Using
                q = "SELECT j_order_trans_barang, barang_nama, j_order_trans_harga_jual, j_order_trans_qty, j_order_trans_satuan, " _
                    & "j_order_trans_disc1, j_order_trans_disc2, j_order_trans_disc3, j_order_trans_disc4, j_order_trans_disc5, " _
                    & "j_order_trans_disc_rupiah, j_order_trans_satuan_type, j_order_trans_valid_status, " _
                    & "getQtyDetail(j_order_trans_barang, getStockBarang(j_order_trans_barang), 1) qty_sisa " _
                    & "FROM data_penjualan_order_trans " _
                    & "INNER JOIN data_barang_master ON barang_kode = j_order_trans_barang " _
                    & "JOIN (SELECT @qtypsn:=0,@qtysys:=0) para " _
                    & "WHERE j_order_trans_faktur='{0}' AND j_order_trans_status=1"
                Using dt = x.GetDataTable(String.Format(q, kode))
                    For Each rows As DataRow In dt.Rows
                        Dim i As Integer = dgv_barang.Rows.Add
                        With dgv_barang.Rows
                            .Item(i).Cells("kode").Value = rows.ItemArray(0)
                            .Item(i).Cells("nama").Value = rows.ItemArray(1)
                            .Item(i).Cells("nama").ToolTipText = rows.ItemArray(0)
                            .Item(i).Cells("harga").Value = rows.ItemArray(2)
                            .Item(i).Cells("qty").Value = rows.ItemArray(3)
                            .Item(i).Cells("sat").Value = rows.ItemArray(4)

                            .Item(i).Cells("disc1").Value = rows.ItemArray(5)
                            .Item(i).Cells("disc2").Value = rows.ItemArray(6)
                            .Item(i).Cells("disc3").Value = rows.ItemArray(7)
                            .Item(i).Cells("disc4").Value = rows.ItemArray(8)
                            .Item(i).Cells("disc5").Value = rows.ItemArray(9)
                            .Item(i).Cells("discrp").Value = rows.ItemArray(10)

                            Dim _subtot As Decimal = rows.ItemArray(2) * rows.ItemArray(3)
                            .Item(i).Cells("subtotal").Value = _subtot

                            If rows.ItemArray(10) <> 0 Then _subtot -= rows.ItemArray(10) * rows.ItemArray(3)
                            For ss = 5 To 9
                                If rows.ItemArray(ss) <> 0 Then
                                    _subtot = _subtot * (1 - CDec(rows.ItemArray(ss)) / 100)
                                Else
                                    _subtot = _subtot
                                End If
                            Next
                            .Item(i).Cells("jml").Value = _subtot

                            .Item(i).Cells("sat_type").Value = rows.ItemArray(11)
                            .Item(i).Cells("valid_ck").Value = IIf(rows.ItemArray(12) = 0, 0, 1)
                            .Item(i).Cells("trans_status").Value = IIf(rows.ItemArray(12) = 0, "-", "Approved")
                            .Item(i).Cells("qty_sisa").Value = rows.ItemArray(13)
                        End With
                    Next
                    countBiaya()
                    cb_status.SelectedValue = tjlStatus
                End Using

                Select Case tjlStatus
                    Case 0 : in_status.Text = "Pending"
                    Case 1 : in_status.Text = "Approved"
                    Case 2 : in_status.Text = "Tolak"
                    Case 9 : in_status.Text = "Delete"
                    Case Else : in_status.Text = "ERROR"
                End Select
            End If
        End Using
    End Sub

    'LOAD SATUAN
    Private Sub loadSatuanBrg(kode As String)
        Dim dt As DataTable = GetSatuanForCombo(kode, isitengah, isibesar)

        cb_sat.DataSource = dt
        cb_sat.DisplayMember = "Text"
        cb_sat.ValueMember = "Value"
        cb_sat.SelectedValue = "besar"
        _satuanstate = cb_sat.SelectedValue
    End Sub

    Private Function getHargaBarang(KdBrg As String, Optional KdCusto As String = "") As Decimal
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = ""
                Dim i As Decimal = 0
                Dim ct As String = "1"
                Try
                    If Not String.IsNullOrWhiteSpace(KdCusto) Then
                        q = "SELECT customer_kriteria_harga_jual FROM data_customer_master WHERE customer_kode='{0}'"
                        ct = CInt(x.ExecScalar(String.Format(q, KdCusto)))
                    End If

                    'GET DISCOUNT/PROMO
                    q = "SELECT barang_harga_jual_d1, barang_harga_jual_d2, barang_harga_jual_d3, barang_harga_jual_d4, barang_harga_jual_d5, " _
                        & "barang_harga_jual_discount FROM data_barang_master WHERE barang_kode='{0}'"
                    Using rdx = x.ReadCommand(String.Format(q, KdBrg))
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            in_disc1.Value = rdx.Item(0)
                            in_disc2.Value = rdx.Item(1)
                            in_disc3.Value = rdx.Item(2)
                            in_disc4.Value = rdx.Item(3)
                            in_disc5.Value = rdx.Item(4)
                            in_discrp.Value = rdx.Item(5)
                        End If
                    End Using

CountHarga:
                    q = "SELECT b_hargajual_nilai FROM data_barang_hargajual WHERE b_hargajual_status=1 AND b_hargajual_barang='{0}' AND b_hargajual_jenisharga='{1}'"
                    i = CDec(x.ExecScalar(String.Format(q, KdBrg, ct)))
                    If i = 0 And ct <> "1" Then : ct = "1" : GoTo CountHarga : End If
                    Return i
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Terjadi kesalahan saat pengambilan data harga barang.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return Nothing
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End If
        End Using
    End Function

    'POPUP PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        setDoubleBuffered(Me.dgv_listbarang, True)
        Dim q As String
        Dim dt As New DataTable
        in_alamat_c.Visible = False : popPnl_barang.Height = 135
        Select Case tipe
            Case "barang"
                Dim _pajak As String = IIf(cb_ppn.SelectedValue = 0, 0, 1)
                If String.IsNullOrWhiteSpace(in_sales.Text) Then
                    q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama', getStockBarang(barang_kode) QTY FROM data_barang_master " _
                        & "WHERE (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%') AND barang_pajak='{2}' LIMIT 250"
                    q = String.Format(q, "{0}", in_gudang.Text, _pajak)

                Else
                    Dim _sales = in_sales.Text : Dim _barangCt As Integer = 0
                    Using x = MainConnection
                        x.Open() : If x.ConnectionState = ConnectionState.Open Then
                            q = "SELECT COUNT(sb_id) FROM data_salesman_barang WHERE sb_status=1 AND sb_kode_sales='{0}'"
                            _barangCt = Integer.Parse(x.ExecScalar(String.Format(q, _sales)))

                            If _barangCt = 0 Then
                                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama', getStockBarang(barang_kode) QTY FROM data_barang_master " _
                                    & "WHERE (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%') AND barang_pajak='{1}' LIMIT 250"
                                q = String.Format(q, "{0}", _pajak)

                            Else
                                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama', getStockBarang(barang_kode) QTY FROM data_barang_master " _
                                    & "WHERE barang_kode IN (SELECT sb_kode_barang FROM data_salesman_barang WHERE sb_kode_sales='{1}' AND sb_status=1) " _
                                    & " AND barang_pajak='{2}' AND (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%') LIMIT 250"
                                q = String.Format(q, "{0}", _sales, _pajak)

                            End If
                        Else
                            Exit Sub
                        End If
                    End Using
                End If
            Case "custo"
                in_alamat_c.Clear() : in_alamat_c.Visible = True
                popPnl_barang.Height = 175
                q = "SELECT customer_kode AS 'Kode', customer_nama AS 'Nama', customer_term, customer_kriteria_harga_jual, " _
                    & "TRIM(BOTH ', ' FROM CONCAT_WS(', ',customer_alamat,customer_kecamatan,customer_kabupaten)) 'Alamat' " _
                    & "FROM data_customer_master WHERE customer_status=1 AND (customer_nama LIKE '%{0}%' OR customer_kode LIKE '%{0}%') LIMIT 250"
            Case "gudang"
                If String.IsNullOrWhiteSpace(in_sales.Text) Then
                    q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang " _
                        & "WHERE gudang_status=1 AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%') LIMIT 250"

                Else
                    Dim _sales = in_sales.Text : Dim _gudangCt As Integer = 0
                    Using x = MainConnection
                        x.Open() : If x.ConnectionState = ConnectionState.Open Then
                            q = "SELECT COUNT(sg_id) FROM data_salesman_gudang WHERE sg_status=1 AND sg_kode_sales='{0}'"
                            _gudangCt = Integer.Parse(x.ExecScalar(String.Format(q, _sales)))

                            If _gudangCt = 0 Then
                                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang " _
                                    & "WHERE gudang_status=1 AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%') LIMIT 250"

                            Else
                                q = "SELECT gudang_kode Kode, gudang_nama Nama FROM data_barang_gudang " _
                                    & "WHERE gudang_kode IN (SELECT sg_kode_gudang FROM data_salesman_gudang WHERE sg_kode_sales='{1}' AND sg_status=1) " _
                                    & " AND gudang_status=1 AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%') LIMIT 250"
                                q = String.Format(q, "{0}", _sales)

                            End If
                        Else
                            Exit Sub
                        End If
                    End Using
                End If

            Case "sales"
                q = "SELECT salesman_kode AS 'Kode', salesman_nama AS 'Nama' FROM data_salesman_master " _
                    & "WHERE salesman_status=1 AND (salesman_nama LIKE '%{0}%' OR salesman_kode LIKE '%{0}%') LIMIT 250"
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
                .Columns(0).Width = 100 : .Columns(1).Width = 200
                If tipe = "custo" Then
                    For i = 2 To 3 : .Columns(i).Visible = False : Next
                End If
                .Columns(.DisplayedColumnCount(False) - 1).AutoSizeMode = IIf(.DisplayedColumnCount(False) = 2,
                                                                              DataGridViewAutoSizeColumnMode.Fill,
                                                                              DataGridViewAutoSizeColumnMode.NotSet)
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
                Case "barang"
                    in_barang.Text = .Cells(0).Value
                    in_barang_nm.Text = .Cells(1).Value
                    loadSatuanBrg(in_barang.Text)
                    in_harga_beli.Value = getHargaBarang(in_barang.Text, jeniscusto)
                    in_qty.Focus()
                Case "custo"
                    in_custo.Text = .Cells(0).Value
                    in_custo_n.Text = .Cells(1).Value
                    jeniscusto = .Cells(3).Value
                    in_custo_al.Text = Strings.Replace(.Cells(4).Value, Environment.NewLine, " ")
                    'in_term.Value = .Cells(2).Value
                    in_sales_n.Focus()
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    in_gudang_n.Focus()
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    cb_term.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
    End Sub

    'INPUT DATA TO DGV FR TEXTBOX /// V NEED TO BE UPDATED SAME TO RECOGNIZE ITEM'S TAX CATEGORY
    Private Sub txtToDgv()
        in_barang.Text = Trim(in_barang.Text)
        If in_barang_nm.Text = Nothing Then
            in_barang.Focus()
            Exit Sub
        End If
        If in_qty.Value = 0 Then
            in_qty.Focus()
            Exit Sub
        End If

        With dgv_barang.Rows
            Dim x As Integer = .Add
            With .Item(x)
                .Cells("kode").Value = in_barang.Text
                .Cells("nama").Value = in_barang_nm.Text
                .Cells("qty").Value = in_qty.Value
                .Cells("sat").Value = cb_sat.Text
                .Cells("sat_type").Value = cb_sat.SelectedValue
                .Cells("harga").Value = in_harga_beli.Value
                .Cells("subtotal").Value = in_harga_beli.Value * in_qty.Value
                .Cells("disc1").Value = in_disc1.Value
                .Cells("disc2").Value = in_disc2.Value
                .Cells("disc3").Value = in_disc3.Value
                .Cells("disc4").Value = in_disc4.Value
                .Cells("disc5").Value = in_disc5.Value
                .Cells("discrp").Value = in_discrp.Value
                .Cells("jml").Value = removeCommaThousand(in_subtotal.Text)
            End With
        End With

        countBiaya()
        clearInputBarang()
        in_barang_nm.Clear()
        in_barang.Focus()
    End Sub

    Private Sub dgvToTxt()
        With dgv_barang.SelectedRows.Item(0)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty.Value = .Cells("qty").Value
            loadSatuanBrg(.Cells("kode").Value)
            _satuanstate = .Cells("sat_type").Value
            cb_sat.SelectedValue = .Cells("sat_type").Value
            in_harga_beli.Text = .Cells("harga").Value
            in_disc1.Value = .Cells("disc1").Value
            in_disc2.Value = .Cells("disc2").Value
            in_disc3.Value = .Cells("disc3").Value
            in_disc4.Value = .Cells("disc4").Value
            in_disc5.Value = .Cells("disc5").Value
            in_discrp.Value = .Cells("discrp").Value
        End With

        in_qty.Focus()
    End Sub

    Public Sub countBiaya()
        Dim pajak As Decimal = 0
        Dim subtotal As Decimal = 0
        Dim netto As Decimal = 0
        Dim diskon As Decimal = 0

        For Each rows As DataGridViewRow In dgv_barang.Rows
            subtotal += rows.Cells("subtotal").Value
            diskon += rows.Cells("subtotal").Value - rows.Cells("jml").Value
        Next

        netto = subtotal - diskon
        If cb_ppn.SelectedValue = 2 Then
            pajak = netto * 0.1
            netto += pajak
        ElseIf cb_ppn.SelectedValue = 1 Then
            pajak = subtotal * (1 - 10 / 11) - diskon * (1 - 10 / 11)
        Else
            pajak = 0
        End If

        in_jumlah.Text = commaThousand(subtotal)
        in_diskon.Text = commaThousand(diskon)
        in_ppn.Text = commaThousand(pajak)
        in_total.Text = commaThousand(netto)
    End Sub

    'CLEAR
    Private Sub clearTextBarang()
        in_harga_beli.Value = 0
        For Each x As TextBox In {in_barang, in_subtotal}
            x.Clear()
        Next
    End Sub

    Private Sub clearInputBarang()
        clearTextBarang()
        in_barang_nm.Clear()
        For Each x As NumericUpDown In {in_qty, in_disc1, in_disc2, in_disc3, in_disc4, in_disc5, in_discrp}
            x.Value = 0
        Next
    End Sub

    'SAVE
    Private Sub saveData()
        Dim dataHead As String()
        Dim querycheck As Boolean = False
        Dim queryArr As New List(Of String)
        Dim q As String = ""

        Dim _tgltrans As String = date_tgl_beli.Value.ToString("yyyy-MM-dd")

        '==========================================================================================================================
        dataHead = {
            "j_order_tanggal_trans='" & _tgltrans & "'",
            "j_order_sales='" & in_sales.Text & "'",
            "j_order_customer='" & in_custo.Text & "'",
            "j_order_gudang='" & in_gudang.Text & "'",
            "j_order_ppn_jenis='" & cb_ppn.SelectedValue & "'",
            "j_order_term=" & cb_term.SelectedValue,
            "j_order_catatan='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
            "j_order_status=" & tjlStatus
            }

        'SAVE HEADER
        If bt_simpanjual.Text = "Simpan" Then
            Dim id As Integer = 0

            q = "INSERT INTO data_penjualan_order_faktur SET {0},j_order_reg_date=NOW(),j_order_reg_alias='{1}';SELECT @id:=LAST_INSERT_ID();"
            queryArr.Add(String.Format(q, String.Join(",", dataHead), loggeduser.user_id))
        ElseIf bt_simpanjual.Text = "Update" Then
            q = "UPDATE data_penjualan_order_faktur SET {1},j_order_upd_date=NOW(), j_order_upd_alias='{2}' WHERE j_order_kode='{0}';"
            queryArr.Add(String.Format(q, in_faktur.Text, String.Join(",", dataHead), loggeduser.user_id))
        End If
        '==========================================================================================================================


        '==========================================================================================================================
        'INSERT BARANG
        '==========================================================================================================================
        q = "UPDATE data_penjualan_order_trans SET j_order_trans_status=9 WHERE j_order_trans_faktur='{0}';"
        queryArr.Add(String.Format(q, in_faktur.Text))
        '==========================================================================================================================

        '==========================================================================================================================
        Dim kode As String = IIf(formstate = InputState.Insert, "@id", in_faktur.Text)
        q = "INSERT INTO data_penjualan_order_trans({0}) SELECT {1},{2} ON DUPLICATE KEY UPDATE {3}"
        Dim col As String() = {"j_order_trans_faktur", "j_order_trans_barang", "j_order_trans_harga_jual", "j_order_trans_qty", "j_order_trans_satuan",
                               "j_order_trans_satuan_type", "j_order_trans_disc1", "j_order_trans_disc2", "j_order_trans_disc3",
                               "j_order_trans_disc4", "j_order_trans_disc5", "j_order_trans_disc_rupiah", "j_order_trans_jumlah", "j_order_trans_status"
                              }
        For Each rows As DataGridViewRow In dgv_barang.Rows
            Dim _kdbrg As String = rows.Cells("kode").Value
            Dim i As Integer = 0
            Dim upd As New List(Of String)
            Dim ct As Integer = 0

            dataHead = {
                "'" & _kdbrg & "'",
                "'" & rows.Cells("harga").Value.ToString.Replace(",", ".") & "'",
                "'" & rows.Cells("qty").Value & "'",
                "'" & rows.Cells("sat").Value & "'",
                "'" & rows.Cells("sat_type").Value & "'",
                "'" & rows.Cells("disc1").Value.ToString.Replace(",", ".") & "'",
                "'" & rows.Cells("disc2").Value.ToString.Replace(",", ".") & "'",
                "'" & rows.Cells("disc3").Value.ToString.Replace(",", ".") & "'",
                "'" & rows.Cells("disc4").Value.ToString.Replace(",", ".") & "'",
                "'" & rows.Cells("disc5").Value.ToString.Replace(",", ".") & "'",
                "'" & rows.Cells("discrp").Value.ToString.Replace(",", ".") & "'",
                "'" & rows.Cells("jml").Value.ToString.Replace(",", ".") & "'",
                "1"
                }

            For Each c As String In col
                If ct > 0 Then
                    upd.Add(c & "=" & dataHead(i))
                    i += 1
                End If
                ct += 1
            Next

            queryArr.Add(String.Format(q, String.Join(",", col), kode, String.Join(",", dataHead), String.Join(",", upd)))
        Next
        '==========================================================================================================================
        '==========================================================================================================================

        '==========================================================================================================================
        'BEGIN TRANSACTION
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                querycheck = x.TransactCommand(queryArr)

                If querycheck = False Then
                    MessageBox.Show("Data tidak dapat tersimpan")
                    Exit Sub
                Else
                    MessageBox.Show("Data tersimpan")
                    doRefreshTab({pgpesanjual})
                    Me.Close()
                End If
            Else
                MessageBox.Show("Tidaj dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
        '==========================================================================================================================
    End Sub

    Private Function CheckKatBrg() As Boolean
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _q As String = "" : Dim _msg As String = ""
                Dim _ck As Boolean = False
                Dim _selPjk As Integer = IIf({1, 2}.Contains(cb_ppn.SelectedValue), 1, 0)
                For Each rows As DataGridViewRow In dgv_barang.Rows
                    Dim _kode As String = rows.Cells("kode").Value
                    Dim i As Integer = 0
                    If (formstate = InputState.Valid And rows.Cells(0).Value = 1) Or formstate <> InputState.Valid Then
                        _q = "SELECT barang_pajak FROM data_barang_master WHERE barang_kode='{0}'"
                        _ck = Integer.TryParse(x.ExecScalar(String.Format(_q, _kode)), i)
                        If _ck Then
                            If i <> _selPjk Then
                                _msg = "Kategori pajak item " & _kode & " tidak sesuai dengan yang terpilih."
                                _ck = False : Exit For
                            Else
                                _ck = True
                            End If
                        Else
                            _msg = "Terjadi kesalahan saat melakukan pengecekan kategori barang."
                            _ck = False : Exit For
                        End If
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

    Private Function CheckGudang(KodeSales As String, KodeGudang As String, ByRef Msg As String) As Boolean
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = ""
                Dim _gudangCK As Boolean = False

                q = "SELECT COUNT(sg_id) FROM data_salesman_gudang WHERE sg_kode_sales='{0}' AND sg_status=1"
                If Integer.Parse(x.ExecScalar(String.Format(q, KodeSales))) > 0 Then
                    q = "SELECT COUNT(sg_id) FROM data_salesman_gudang WHERE sg_kode_sales='{0}' AND sg_kode_gudang='{1}' AND sg_status=1"
                    Dim i = Integer.Parse(x.ExecScalar(String.Format(q, KodeSales, KodeGudang)))
                    If i = 1 Then
                        Return True
                    ElseIf i = 0 Then
                        Msg = "Gudang yang diinput tidak sesuai dengan gudang yang ditentukan untuk sales " & KodeSales & "."
                        Return False
                    Else
                        Msg = "Terjadi kesalahan saat melakukan pengecekan kode gudang."
                        Return False
                    End If
                Else
                    Return True
                End If
            Else
                Msg = "Tidak dapat terhubung ke database."
                Return False
            End If
        End Using
    End Function

    Private Function CheckBarang(KodeSales As String, ByRef Msg As String) As Boolean
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = ""

                q = "SELECT COUNT(sb_id) FROM data_salesman_barang WHERE sb_kode_sales='{0}' AND sb_status=1"
                If Integer.Parse(x.ExecScalar(String.Format(q, KodeSales))) > 0 Then
                    Dim _kodeBrg As New List(Of String)
                    Dim _wrongItem As New List(Of String)
                    For Each row As DataGridViewRow In dgv_barang.Rows
                        If Not _kodeBrg.Contains(row.Cells(1).Value) Then
                            _kodeBrg.Add(row.Cells(1).Value)
                        End If
                    Next
                    For Each _brg As String In _kodeBrg
                        q = "SELECT COUNT(sb_id) FROM data_salesman_barang WHERE sb_kode_sales='{0}' AND sb_kode_barang='{1}' AND sb_status=1"
                        Dim i = Integer.Parse(x.ExecScalar(String.Format(q, KodeSales, _brg)))
                        If i = 0 Then
                            q = "SELECT barang_nama FROM data_barang_master WHERE barang_kode='{0}'"
                            _wrongItem.Add(x.ExecScalar(String.Format(q, _brg)).ToString)
                        ElseIf i < 0 Or i > 1 Then
                            Msg = "Terjadi kesalahan saat melakukan pengecekan barang " & _brg & "."
                            Return False : Exit Function
                        End If
                    Next

                    If _wrongItem.Count > 0 Then
                        Msg = "Item berikut tidak sesuai dengan item yang ditentukan untuk sales " & KodeSales & "."
                        Msg += Environment.NewLine & String.Join(Environment.NewLine, _wrongItem)
                        Return False
                    Else
                        Return True
                    End If
                Else
                    Return True
                End If
            Else
                Msg = "Tidak dapat terhubung ke database."
                Return False
            End If
        End Using
    End Function

    'CANCEL/DELETE TRANSACTION
    Private Sub CancelDeleteTrans(KodeOrder As String, NewStatus As Integer, ByRef Msg As String)
        Dim _OldStatus As Integer = tjlStatus
        Dim q As String = "" : Dim queryArr As New List(Of String)

        If formstate = InputState.Insert Then Exit Sub
        If String.IsNullOrWhiteSpace(KodeOrder) Then Exit Sub
        If _OldStatus = 1 And Not String.IsNullOrWhiteSpace(in_ref_faktur.Text) Then Exit Sub

        If {0, 1}.Contains(_OldStatus) Then
            'FOR ACTIVE TRANSACTION
            If Not {2, 9}.Contains(NewStatus) Then Exit Sub
            'CHECKING SELL TRANS REF 
            If Not String.IsNullOrWhiteSpace(in_ref_faktur.Text) Then Exit Sub

            q = "UPDATE data_penjualan_order_faktur SET j_order_status={2}, j_order_upd_date=NOW(), j_order_upd_alias='{1}' WHERE j_order_kode='{0}'"
            queryArr.Add(String.Format(q, KodeOrder, loggeduser.user_id, NewStatus))

            If NewStatus = 9 Then
                'FOR DELETING
                q = "UPDATE data_penjualan_order_trans SET j_order_trans_status=9 WHERE j_order_trans_faktur='{0}' AND j_order_trans_status=1"
                queryArr.Add(String.Format(q, KodeOrder))
            End If

        ElseIf _OldStatus = 2 And NewStatus = 1 Then
            'FOR REACTIVATE TRANSACTION

        Else
            Exit Sub
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then

            End If
        End Using
    End Sub

    'CREATE PENJUALAN
    Private Sub validOrder(ValidStatus As String)
        Dim dataHead As String()
        Dim querycheck As Boolean = False
        Dim queryArr As New List(Of String)
        Dim q As String = ""

        Dim _tglTrans As String = date_tgl_beli.Value.ToString("yyyy-MM-dd")

        '==========================================================================================================================
        'UPDATE STATUS ORDER
        q = "UPDATE data_penjualan_order_faktur SET {1},j_order_valid_date=NOW(),j_order_valid_alias='{2}' " _
            & "WHERE j_order_kode='{0}'"
        dataHead = {
                "j_order_tanggal_trans='" & _tglTrans & "'",
                "j_order_status='" & ValidStatus & "'",
                "j_order_term='" & cb_term.SelectedValue & "'",
                "j_order_catatan='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'"
                }
        queryArr.Add(String.Format(q, in_faktur.Text, String.Join(",", dataHead), ValidUid))
        '==========================================================================================================================

        '==========================================================================================================================
        q = "UPDATE data_penjualan_order_trans SET j_order_trans_valid_status='{1}' " _
            & "WHERE j_order_trans_faktur='{0}' AND j_order_trans_barang='{2}'"
        For Each row As DataGridViewRow In dgv_barang.Rows
            queryArr.Add(String.Format(q, in_faktur.Text, row.Cells("valid_ck").Value, row.Cells("kode").Value))
        Next
        '==========================================================================================================================

        '==========================================================================================================================
        'BEGIN TRANSACTION
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                querycheck = x.TransactCommand(queryArr)
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Order Penjualan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End Using
        '==========================================================================================================================

        If querycheck = False Then
            MessageBox.Show("Data validasi tidak dapat tersimpan", "Order Penjualan", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            MessageBox.Show("Data validasi tersimpan", "Order Penjualan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tjlStatus = ValidStatus
            If tjlStatus = 1 Then
                If MessageBox.Show("Buat transaksi penjualan berdasarkan pesanan yg sudah divalidasi?", "Validasi Order Penjualan",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    createJual()
                End If
            End If
            doRefreshTab({pgpesanjual})
            Me.Close()
        End If
    End Sub

    Private Sub createJual()
        Dim newJual As New fr_jual_detail
        Dim q As String = ""
        Dim term As Integer = 0
        Dim piutang, maxpiutang As Decimal

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT customer_term, IFNULL(customer_max_piutang,0), getPiutangSisaCusto(customer_kode) FROM data_customer_master WHERE customer_kode='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, in_custo.Text))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        term = rdx.Item(0)
                        maxpiutang = rdx.Item(1)
                        piutang = rdx.Item(2)
                    Else
                        MessageBox.Show("Terjadi kesalahan dalam proses pengambilan data. Data customer tidak dapat ditemukan.",
                                        "Order Penjualan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using

                If cb_term.SelectedValue = 1 Then
                    If term = 0 Then term = 1
                End If

                With newJual
                    .doLoadNew()
                    'DATE
                    .date_tgl_beli.Value = If(date_tgl_beli.Value < TransStartDate,
                                              If(Today < TransStartDate, TransStartDate, Today),
                                              date_tgl_beli.Value
                                              )
                    .date_tgl_pajak.Value = .date_tgl_beli.Value
                    'REF
                    .in_ket.Text = "Ref. Order #" & in_faktur.Text
                    .refOrderJual = in_faktur.Text
                    'SALES
                    .in_sales.Text = in_sales.Text
                    .in_sales_n.Text = in_sales_n.Text
                    .in_sales_n.ReadOnly = True
                    .in_term.Value = term
                    'CUSTO
                    .in_custo.Text = in_custo.Text
                    .in_custo_n.Text = in_custo_n.Text
                    .jumlahpiutang = piutang
                    .maxpiutang = maxpiutang
                    .in_custo_n.ReadOnly = True
                    'GUDANG
                    .in_gudang.Text = in_gudang.Text
                    .in_gudang_n.Text = in_gudang_n.Text
                    'BARANG
                    .cb_ppn.SelectedValue = cb_ppn.SelectedValue
                    For Each rows As DataGridViewRow In dgv_barang.Rows
                        If rows.Cells("valid_ck").Value = 1 Then
                            With .dgv_barang.Rows
                                Dim ss As Integer = .Add
                                With .Item(ss)
                                    .Cells("kode").Value = rows.Cells("kode").Value
                                    .Cells("nama").Value = rows.Cells("nama").Value
                                    .Cells("qty").Value = rows.Cells("qty").Value
                                    .Cells("sat").Value = rows.Cells("sat").Value
                                    .Cells("sat_type").Value = rows.Cells("sat_type").Value
                                    .Cells("harga").Value = rows.Cells("harga").Value
                                    .Cells("subtotal").Value = rows.Cells("subtotal").Value
                                    .Cells("disc1").Value = rows.Cells("disc1").Value
                                    .Cells("disc2").Value = rows.Cells("disc2").Value
                                    .Cells("disc3").Value = rows.Cells("disc3").Value
                                    .Cells("disc4").Value = rows.Cells("disc4").Value
                                    .Cells("disc5").Value = rows.Cells("disc5").Value
                                    .Cells("discrp").Value = rows.Cells("discrp").Value
                                    .Cells("jml").Value = rows.Cells("jml").Value
                                End With
                            End With
                        End If
                    Next
                    .countBiaya()
                    If cb_term.SelectedValue = 0 Then .in_bayar.Value = removeCommaThousand(.in_netto.Text)
                End With
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Order Penjualan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End Using
    End Sub

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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_bataljual.Click
        'If MessageBox.Show("Tutup Form?", "Penjualan", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        Me.Close()
        'End If
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

    Private Sub fr_pesan_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            Else
                bt_bataljual.PerformClick()
            End If
        End If
    End Sub

    'MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        If bt_simpanjual.Visible = True Then
            bt_simpanjual.PerformClick()
        Else
            bt_createjual.PerformClick()
        End If
    End Sub

    Private Sub mn_cancelorder_Click(sender As Object, e As EventArgs) Handles mn_cancel.Click
        If MessageBox.Show("Batalkan Pemesanan?", "Order Penjualan", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'Cancel Jual
        End If
    End Sub

    Private Sub mn_createjual_Click(sender As Object, e As EventArgs) Handles mn_createjual.Click
        If tjlStatus = 1 Then
            If MessageBox.Show("Buat transaksi penjualan berdasarkan pesanan yg sudah divalidasi?", "Validasi Order Penjualan",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                createJual()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub mn_validasi_Click(sender As Object, e As EventArgs) Handles mn_validasi.Click
        If MessageBox.Show("Validasi order penjualan?", "Order Penjualan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            ControlSwitch(InputState.Valid, loggeduser.validasi_trans)
        End If
    End Sub

    'SAVE
    Private Sub bt_simpanjual_Click(sender As Object, e As EventArgs) Handles bt_simpanjual.Click
        'CHECK TANGGAL TRANSAKSI
        If date_tgl_beli.Value < TransStartDate Then
            MessageBox.Show("Tanggal transaksi tidak boleh kurang dari periode aktif." & TransStartDate.ToString("(MMMM yyyy)"),
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            date_tgl_beli.Focus() : Exit Sub
        End If

        'CHECK INPUT DATA
        For Each x As TextBox In {in_custo, in_sales}
            Dim Msg As String = "{0} belum diinput"
            Dim _input As TextBox
            Select Case x.Name
                Case in_custo.Name : Msg = String.Format(Msg, "Customer") : _input = in_custo_n
                Case in_sales.Name : Msg = String.Format(Msg, "Salesman") : _input = in_sales_n
                Case Else : Exit Sub
            End Select

            If String.IsNullOrWhiteSpace(x.Text) Then
                MessageBox.Show(Msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                _input.Focus() : Exit Sub
            End If
        Next

        'CHECK GUDANG
        If in_gudang.Text = Nothing Then
            MessageBox.Show("Gudang belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_gudang_n.Focus() : Exit Sub
        Else
            Dim _msg As String = ""
            If Not CheckGudang(in_sales.Text, in_gudang.Text, _msg) Then
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                in_gudang_n.Focus() : Exit Sub
            End If
        End If

        'CHECK BARANG
        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_barang.Focus() : Exit Sub
        Else
            Dim _msg As String = ""
            If Not CheckBarang(in_sales.Text, _msg) Then
                MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                in_barang.Focus() : Exit Sub
            End If
        End If
        If Not CheckKatBrg() Then Exit Sub

        Dim _resMsg As DialogResult = Windows.Forms.DialogResult.Yes
        If Not formstate = InputState.Insert Then _resMsg = MessageBox.Show("Update data pesanan?", "Order Penjualan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _resMsg = Windows.Forms.DialogResult.Yes Then
            If formstate <> InputState.Insert And (loggeduser.saleskode = Nothing Or loggeduser.saleskode <> in_sales.Text Or loggeduser.user_id <> txtRegAlias.Text) Then
                _resMsg = MessageBox.Show("Kode Sales/UserID yg anda miliki tidak sama dgn Kode Sales/UserID pembuat, lanjutkan transaksi?",
                                          "Order Penjualan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If
            If _resMsg = Windows.Forms.DialogResult.Yes Then saveData()
        End If
    End Sub

    'CREATE DATA JUAL/VALIDASI
    Private Sub bt_createjual_Click(sender As Object, e As EventArgs) Handles bt_createjual.Click
        Dim ck_valitem As Boolean = False
        Dim valid As Boolean = False

        If tjlStatus = cb_status.SelectedValue Or cb_status.SelectedValue = Nothing Then
            MessageBox.Show("Status Validasi belum terpilih")
            cb_status.Focus()
            Exit Sub
        End If

        For Each rows As DataGridViewRow In dgv_barang.Rows
            If rows.Cells("valid_ck").Value = 1 Then
                ck_valitem = True
                Exit For
            End If
        Next
        If ck_valitem = False And cb_status.SelectedValue = 1 Then
            MessageBox.Show("Barang belum terpilih")
            dgv_barang.Focus()
            Exit Sub
        End If
        If Not CheckKatBrg() Then Exit Sub

        If MessageBox.Show("Simpan validasi pesanan?", "Validasi Order Penjualan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor

            If tjlStatus = 1 Then : ck_valitem = ckItem()
            Else : ck_valitem = True
            End If
            If ck_valitem = True Then valid = valConfirm()
            If valid = True Then validOrder(cb_status.SelectedValue)

            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Function valConfirm() As Boolean
        Using valid As New fr_jualconfirm_dialog
            valid.doLoadValid()
            If valid.returnval.Key Then
                ValidUid = valid.returnval.Value
                Return True
            Else
                If valid.returnval.Value <> String.Empty Then
                    MessageBox.Show(valid.returnval.Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                Return False
            End If
        End Using
    End Function

    Private Function ckItem() As Boolean
        Dim ck_valitem As Boolean = False

        For Each rows As DataGridViewRow In dgv_barang.Rows
            If rows.Cells("valid_ck").Value = 1 Then
                Dim kode As String = rows.Cells("kode").Value
                Dim tgltrans As String = date_tgl_beli.Value.ToString("yyyy-MM-dd")
                Dim q As String = "SELECT IFNULL(SUM(trans_qty),0),getHppAvg_v2('{0}','{1}') FROM data_stok_awal " _
                                  & "LEFT JOIN data_stok_kartustok ON stock_kode=trans_stock AND trans_status=1 " _
                                  & "WHERE stock_barang='{0}' AND stock_status=1"
                Dim qty As Integer = 0
                Dim hpp As Decimal = -1

                readcommd(String.Format(q, kode, tgltrans))
                If rd.HasRows Then
                    qty = rd.Item(0)
                    hpp = rd.Item(1)
                End If
                rd.Close()

                If qty <= 0 Then
                    Dim _msgRes As DialogResult = MessageBox.Show("Stok untuk item terpilih tidak dapat ditemukan/kosong." & Environment.NewLine & "Lanjutkan validasi?",
                                                                  "Validasi Order Penjualan", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                    If Not _msgRes = Windows.Forms.DialogResult.Yes Then
                        ck_valitem = False : Exit For
                    End If
                ElseIf hpp < 0 Then
                    MessageBox.Show("", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    ck_valitem = True
                End If
            End If
        Next

        Return ck_valitem
    End Function

    'UI : POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_sales_n.Focused Or in_gudang_n.Focused Or in_barang_nm.Focused Or in_custo_n.Focused Then
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
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
    End Sub

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyUp
        If e.KeyCode = Keys.Enter Then setPopUpResult()
    End Sub

    Private Sub dgv_listbarang_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellEnter
        If popupstate = "custo" And dgv_listbarang.Focused = True Then
            in_alamat_c.Text = dgv_listbarang.SelectedRows.Item(0).Cells(4).Value
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        Dim x As TextBox
        Select Case popupstate
            Case "sales" : x = in_sales_n
            Case "gudang" : x = in_gudang_n
            Case "barang" : x = in_barang_nm
            Case "custo" : x = in_custo_n
            Case Else : Exit Sub
        End Select
        PopUpSearchKeyPress(e, x)
    End Sub

    '------------- cb prevent input
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_sat.KeyPress, cb_term.KeyPress, cb_status.KeyPress
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    '------------- numeric
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_discrp.Enter, in_disc3.Enter, in_disc2.Enter, in_disc1.Enter, in_disc4.Enter, in_disc5.Enter, in_harga_beli.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_discrp.Leave, in_disc3.Leave, in_disc2.Leave, in_disc1.Leave, in_disc4.Leave, in_disc5.Leave, in_harga_beli.Leave
        Select Case sender.Name
            Case "in_qty"
                numericLostFocus(sender, "N0")
            Case Else
                numericLostFocus(sender)
        End Select
    End Sub

    '----------------- HEADER
    Private Sub in_faktur_KeyUp(sender As Object, e As KeyEventArgs) Handles in_faktur.KeyUp
        keyshortenter(date_tgl_beli, e)
    End Sub

    Private Sub date_tgl_beli_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyUp
        keyshortenter(in_custo_n, e)
    End Sub

    Private Sub in_sales_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales.KeyUp
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_sales_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter, in_gudang_n.Enter, in_custo_n.Enter, in_barang_nm.Enter
        If sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
            If popPnl_barang.Visible = False Then popPnl_barang.Visible = True
            Select Case sender.Name
                Case "in_sales_n" : popupstate = "sales"
                Case "in_custo_n" : popupstate = "custo"
                Case "in_gudang_n" : popupstate = "gudang"
                Case "in_barang_nm" : popupstate = "barang"
                Case Else : Exit Sub
            End Select

            loadDataBRGPopup(popupstate, sender.Text)
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave, in_custo_n.Leave, in_gudang_n.Leave, in_barang_nm.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyDown, in_gudang_n.KeyDown, in_custo_n.KeyDown, in_barang_nm.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then e.SuppressKeyPress = True
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp, in_gudang_n.KeyUp, in_custo_n.KeyUp, in_barang_nm.KeyUp
        Dim _id As TextBox : Dim _next As Control
        Select Case sender.Name
            Case "in_sales_n" : _id = in_sales : _next = in_gudang_n
            Case "in_gudang_n" : _id = in_gudang : _next = cb_term
            Case "in_custo_n" : _id = in_custo : _next = in_sales_n
            Case "in_barang_nm" : _id = in_barang : _next = in_qty
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

    Private Sub in_custo_KeyUp(sender As Object, e As KeyEventArgs) Handles in_custo.KeyUp, in_custo_al.KeyUp
        keyshortenter(in_custo_n, e)
    End Sub

    Private Sub in_gudang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyUp
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub cb_term_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_term.KeyUp
        keyshortenter(If(cb_ppn.Enabled, cb_ppn, in_barang_nm), e)
    End Sub

    Private Sub cb_ppn_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_ppn.KeyUp
        keyshortenter(in_barang_nm, e)
    End Sub

    Private Sub cb_status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_status.SelectedValueChanged
        If tjlStatus <> 0 Then
            bt_createjual.Enabled = True
        End If
        'If tjlStatus <> cb_status.SelectedValue Then
        '    tjlStatus = cb_status.SelectedValue
        'End If
    End Sub

    'BARANG
    Private Sub in_barang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_barang.KeyUp
        keyshortenter(in_barang_nm, e)
    End Sub

    Private Sub in_qty_KeyUp(sender As Object, e As KeyEventArgs) Handles in_qty.KeyUp
        keyshortenter(cb_sat, e)
    End Sub

    Private Sub in_harga_beli_ValueChanged(sender As Object, e As EventArgs) Handles in_qty.ValueChanged, in_harga_beli.ValueChanged, in_disc1.ValueChanged, in_disc2.ValueChanged, in_disc3.ValueChanged, in_disc4.ValueChanged, in_disc5.ValueChanged, in_discrp.ValueChanged
        Dim total As Decimal = in_qty.Value * in_harga_beli.Value

        If in_discrp.Value <> 0 Then
            total -= in_discrp.Value * in_qty.Value
        End If

        For Each x As Decimal In {in_disc1.Value, in_disc2.Value, in_disc3.Value, in_disc4.Value, in_disc5.Value}
            If x <> 0 Then
                total = total * (1 - x / 100)
            End If
        Next

        in_subtotal.Text = commaThousand(total)
    End Sub

    Private Sub cb_sat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_sat.SelectionChangeCommitted
        in_harga_beli.Value = CountItemPrice(_satuanstate, cb_sat.SelectedValue, in_harga_beli.Value, isibesar, isitengah)
        _satuanstate = cb_sat.SelectedValue
    End Sub

    Private Sub cb_sat_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_sat.KeyUp
        keyshortenter(in_harga_beli, e)
    End Sub

    Private Sub in_harga_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_beli.KeyDown, in_qty.KeyDown, in_subtotal.KeyDown, in_disc1.KeyDown, in_disc2.KeyDown, in_disc3.KeyDown, in_disc4.KeyDown, in_disc5.KeyDown, in_discrp.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub in_harga_beli_KeyUp(sender As Object, e As KeyEventArgs) Handles in_harga_beli.KeyUp
        keyshortenter(in_discrp, e)
    End Sub

    Private Sub in_discrp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_discrp.KeyUp
        keyshortenter(in_disc1, e)
    End Sub

    Private Sub in_subtotal_KeyUp(sender As Object, e As KeyEventArgs) Handles in_subtotal.KeyUp
        keyshortenter(in_disc1, e)
    End Sub

    Private Sub in_disc1_KeyUp(sender As Object, e As KeyEventArgs) Handles in_disc1.KeyUp
        keyshortenter(in_disc2, e)
    End Sub

    Private Sub in_disc2_KeyUp(sender As Object, e As KeyEventArgs) Handles in_disc2.KeyUp
        keyshortenter(in_disc3, e)
    End Sub

    Private Sub in_disc3_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc3.KeyUp
        keyshortenter(in_disc4, e)
    End Sub

    Private Sub in_disc4_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc4.KeyUp
        keyshortenter(in_disc5, e)
    End Sub

    Private Sub in_disc5_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc5.KeyUp
        keyshortenter(bt_tbbarang, e)
    End Sub

    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        txtToDgv()
    End Sub

    'DGV
    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        If state = "order" Then
            If e.RowIndex > -1 And tjlStatus = 0 Then
                dgvToTxt()
                dgv_barang.Rows.RemoveAt(e.RowIndex)
                countBiaya()
            End If
        End If
    End Sub

    Private Sub fr_jual_detail_Click(sender As Object, e As EventArgs) Handles MyBase.Click, pnl_content.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub

    Private Sub dgv_barang_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellEndEdit
        With dgv_barang.SelectedRows.Item(0)

        End With
    End Sub
End Class