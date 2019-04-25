﻿Public Class fr_jual_detail
    'note
    'penjualana bisa untuk input & validasi -> hutang custo
    'alur so -> sales>validasi>admin>gudang

    Private jeniscusto As String
    Public tjlStatus As String = 1
    Public refOrderJual As String = Nothing
    Private popupstate As String = "barang"
    Private isibesar As Integer = 0
    Private isitengah As Integer = 0
    Private qtybarang As Integer = 0
    Private _satuanstate As String = "kecil"
    Private _salesgudang As String = ""
    Private _salesitem As Boolean = False
    Private oldterm As Integer = 0
    Public jumlahpiutang As Decimal = 0
    Public maxpiutang As Decimal = 0 'jika melewati max, jika user !validator status=0, jika user validator status sama tp open confirm dialog, warning popup
    Private custo_priority As Boolean = False
    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
        View
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(NoFaktur As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Data Penjualan : PO201908109021"

        formstate = FormSet
        With cb_ppn
            .DataSource = jenisPPN()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        With date_tgl_beli
            .Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
            .MaxDate = selectperiode.tglakhir
            .MinDate = selectperiode.tglawal
        End With
        date_tgl_pajak.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)

        For Each x As DataGridViewColumn In {harga, discrp, jml, subtotal}
            x.DefaultCellStyle = dgvstyle_currency
        Next

        If Not FormSet = InputState.Insert Then
            Me.Text += NoFaktur
            Me.lbl_title.Text += " : " & NoFaktur
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            loadDataFaktur(NoFaktur)
            If Not {0, 1}.Contains(tjlStatus) Then AllowEdit = False : mn_cancelorder.Text = "Cancel Pembatalan"
            in_faktur.ReadOnly = IIf(formstate = InputState.Insert, False, True)
            bt_simpanjual.Text = "Update"
        End If

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        For Each txt As TextBox In {in_pajak, in_custo_n, in_ket, in_barang_nm, in_sales_n}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        For Each numin As NumericUpDown In {in_term, in_bayar}
            numin.Enabled = AllowInput
        Next
        For Each dtpick As DateTimePicker In {date_tgl_beli, date_tgl_pajak}
            dtpick.Enabled = AllowInput
        Next
        For Each x As Control In {in_qty, cb_sat, in_harga_beli, in_disc1, in_disc2, in_disc3, in_disc4, in_disc5, in_discrp, bt_tbbarang}
            x.Visible = AllowInput
        Next

        bt_simpanjual.Enabled = AllowInput
        mn_cancelorder.Enabled = IIf(formstate = InputState.Insert, False, IIf(tjlStatus = 2, loggeduser.allowedit_transact, AllowInput))
        mn_delete.Enabled = IIf(formstate = InputState.Insert, False, IIf(tjlStatus = 2, loggeduser.allowedit_transact, AllowInput))
        mn_print.Enabled = IIf(formstate = InputState.Insert, False, IIf(tjlStatus = 1, True, False))
        mn_save.Enabled = bt_simpanjual.Enabled

        If Not formstate = InputState.Insert Then
            Dim rowcount = dgv_barang.RowCount
            cb_ppn.Enabled = IIf(rowcount > 0, False, True)
            in_gudang_n.ReadOnly = IIf(rowcount > 0, True, False)
            'in_sales_n.ReadOnly = IIf(rowcount > 0, True, False)
        Else
            cb_ppn.Enabled = AllowInput
            in_gudang_n.ReadOnly = IIf(AllowInput, False, True)
            'in_sales_n.ReadOnly = IIf(AllowInput, False, True)
        End If

        If AllowInput Then
            dgv_barang.Location = New Point(12, 182) : dgv_barang.Height = 187
            AddHandler dgv_barang.CellDoubleClick, AddressOf dgv_barang_CellDoubleClick
        Else
            dgv_barang.Location = New Point(12, 142) : dgv_barang.Height = 227
            RemoveHandler dgv_barang.CellDoubleClick, AddressOf dgv_barang_CellDoubleClick
        End If
    End Sub

    Public Sub getDataCustomer(KodeCusto As String)
        Dim q As String = "SELECT customer_max_piutang, customer_priority, customer_kriteria_harga_jual, " _
                          & "customer_status, getPiutangSisaCustoSales('{0}','{1}') piutang " _
                          & "FROM data_customer_master WHERE customer_kode='{0}'"
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Using rdx = x.ReadCommand(String.Format(q, KodeCusto, in_sales.Text))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        jeniscusto = rdx.Item("customer_kriteria_harga_jual")
                        maxpiutang = rdx.Item("customer_max_piutang")
                        custo_priority = If(rdx.Item("customer_priority") = 1, True, False)
                        jumlahpiutang = rdx.Item("piutang")
                    End If
                End Using
                'jumlahpiutang = GetPiutangCusto(KodeCusto)
            End If
        End Using
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
    Private Sub loadDataFaktur(faktur As String)
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                'LOAD HEADER
                q = "CALL getTransHeader('JUAL','{0}')"
                Using rdx = x.ReadCommand(String.Format(q, faktur))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_faktur.Text = faktur
                        cb_ppn.SelectedValue = rdx.Item("faktur_ppn_jenis")
                        in_pajak.Text = rdx.Item("faktur_pajak_no")
                        date_tgl_beli.Value = rdx.Item("faktur_tanggal_trans")
                        date_tgl_pajak.Value = rdx.Item("faktur_pajak_tanggal")
                        in_gudang.Text = rdx.Item("faktur_gudang")
                        in_gudang_n.Text = rdx.Item("gudang_nama")
                        in_sales.Text = rdx.Item("faktur_sales")
                        in_sales_n.Text = rdx.Item("salesman_nama")
                        in_custo.Text = rdx.Item("faktur_customer")
                        in_custo_n.Text = rdx.Item("customer_nama")
                        in_custo_al.Text = rdx.Item("customer_alamat")
                        jeniscusto = rdx.Item("customer_kriteria_harga_jual")
                        in_term.Value = rdx.Item("faktur_term")
                        oldterm = rdx.Item("faktur_term")
                        in_ket.Text = rdx.Item("faktur_catatan")
                        'BIAYA
                        in_jumlah.Text = commaThousand(rdx.Item("faktur_jumlah"))
                        in_diskon.Text = commaThousand(rdx.Item("faktur_disc_rupiah"))
                        in_total.Text = commaThousand(rdx.Item("faktur_total"))
                        in_ppn_tot.Text = commaThousand(rdx.Item("faktur_ppn_persen"))
                        in_netto.Text = commaThousand(rdx.Item("faktur_netto"))
                        in_bayar.Value = rdx.Item("faktur_bayar")
                        in_sisa.Text = commaThousand(rdx.Item("faktur_netto") - rdx.Item("faktur_bayar"))
                        'STAT
                        tjlStatus = rdx.Item("faktur_status")
                        'INPUT
                        txtRegAlias.Text = rdx.Item("faktur_reg_alias")
                        txtRegdate.Text = rdx.Item("faktur_reg_date")
                        'UPDATE
                        txtUpdDate.Text = rdx.Item("faktur_upd_date")
                        txtUpdAlias.Text = rdx.Item("faktur_upd_alias")
                    End If
                End Using

                'LOAD TABLE/ITEM
                q = "SELECT trans_barang, barang_nama, trans_harga_jual, trans_qty, trans_satuan, " _
                    & "trans_disc1, trans_disc2, trans_disc3, trans_disc4, trans_disc5, " _
                    & "trans_disc_rupiah, trans_jumlah, trans_satuan_type, trans_hpp " _
                    & "FROM data_penjualan_trans INNER JOIN data_barang_master ON barang_kode = trans_barang " _
                    & "WHERE trans_faktur='" & faktur & "' AND trans_status=1"
                Using dt As DataTable = x.GetDataTable(String.Format(q, kode))
                    With dgv_barang.Rows
                        For Each rows As DataRow In dt.Rows
                            Dim i = .Add
                            .Item(i).Cells("kode").Value = rows.ItemArray(0)
                            .Item(i).Cells("nama").Value = rows.ItemArray(1)
                            .Item(i).Cells("harga").Value = rows.ItemArray(2)
                            .Item(i).Cells("qty").Value = rows.ItemArray(3)
                            .Item(i).Cells("sat").Value = rows.ItemArray(4)
                            .Item(i).Cells("disc1").Value = rows.ItemArray(5)
                            .Item(i).Cells("disc2").Value = rows.ItemArray(6)
                            .Item(i).Cells("disc3").Value = rows.ItemArray(7)
                            .Item(i).Cells("disc4").Value = rows.ItemArray(8)
                            .Item(i).Cells("disc5").Value = rows.ItemArray(9)
                            .Item(i).Cells("discrp").Value = rows.ItemArray(10)
                            .Item(i).Cells("jml").Value = rows.ItemArray(11)
                            .Item(i).Cells("sat_type").Value = rows.ItemArray(12)
                            .Item(i).Cells("subtotal").Value = rows.ItemArray(2) * rows.ItemArray(3)
                            .Item(i).Cells("brg_hpp").Value = rows.ItemArray(13)
                        Next
                    End With
                End Using
                Select Case tjlStatus
                    Case 0 : in_status.Text = "Pending"
                    Case 1 : in_status.Text = "Aktif"
                    Case 2 : in_status.Text = "Batal"
                    Case 9 : in_status.Text = "Delete"
                    Case Else : in_status.Text = "ERROR"
                End Select
            End If
        End Using

    End Sub

    'SET SATUAN BARANG
    Private Sub loadSatuanBrg(kode As String)
        Dim dt As DataTable = GetSatuanForCombo(kode, isitengah, isibesar)

        cb_sat.DataSource = dt
        cb_sat.DisplayMember = "Text"
        cb_sat.ValueMember = "Value"
        cb_sat.SelectedValue = "besar"
        _satuanstate = cb_sat.SelectedValue
    End Sub

    'COUNT PRICE
    Private Function countHarga(state As String, hargaawal As Decimal, convState As String) As Decimal
        Dim retHarga As Decimal = 0
        Dim isi As Integer = 0
        Dim opertr As String = "bagi"

        Select Case state
            Case "besar"
                If convState = "tengah" Then
                    retHarga = hargaawal / isibesar
                ElseIf convState = "kecil" Then
                    retHarga = hargaawal / (isibesar * isitengah)
                Else
                    retHarga = hargaawal
                End If
            Case "tengah"
                If convState = "besar" Then
                    retHarga = hargaawal * isibesar
                ElseIf convState = "kecil" Then
                    retHarga = hargaawal / isitengah
                Else
                    retHarga = hargaawal
                End If
            Case "kecil"
                If convState = "besar" Then
                    retHarga = hargaawal * isitengah * isibesar
                ElseIf convState = "tengah" Then
                    retHarga = hargaawal * isitengah
                Else
                    retHarga = hargaawal
                End If
            Case Else
                retHarga = hargaawal
        End Select

        Return retHarga
    End Function

    'LOAD DATA TO DGV POPUP PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        setDoubleBuffered(Me.dgv_listbarang, True)
        Dim q As String
        Dim dt As New DataTable
        Dim autoco As New AutoCompleteStringCollection

        Select Case tipe
            Case "barang"
                in_alamat_c.Visible = False
                popPnl_barang.Height = 135
                'WHERE kode_gudang, jenisPajak, kodesales 
                Dim _tgltrans As String = date_tgl_beli.Value.ToString("yyyy-MM-dd")
                Dim _pajak As String = IIf(cb_ppn.SelectedValue = 0, 0, 1)
                q = "SELECT barang_kode 'Kode', barang_nama 'Nama Barang', IF(IFNULL(b_hargajual_nilai,0)=0,barang_harga_jual, b_hargajual_nilai), " _
                    & "barang_harga_jual_d1, barang_harga_jual_d2, barang_harga_jual_d3, barang_harga_jual_d4, barang_harga_jual_d5, " _
                    & "barang_harga_jual_discount, SUM(trans_qty) 'QTY' " _
                    & "FROM data_stok_kartustok LEFT JOIN data_barang_master ON CONCAT('{1}','-',barang_kode) = trans_stock " _
                    & "LEFT JOIN data_barang_hargajual ON barang_kode=b_hargajual_barang AND b_hargajual_status = 1 " _
                    & "WHERE trans_status=1 AND trans_periode='{2}' AND trans_tgl<='{3}' AND barang_pajak='{4}' " _
                    & "AND b_hargajual_jenisharga='{5}' AND (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%') " _
                    & "GROUP BY barang_kode LIMIT 250"
                q = String.Format(q, "{0}", in_gudang.Text, selectperiode.id, _tgltrans, _pajak, jeniscusto)
            Case "custo"
                in_alamat_c.Clear()
                in_alamat_c.Visible = True
                popPnl_barang.Height = 175
                q = "SELECT customer_kode AS 'Kode', customer_nama AS 'Nama', customer_term, customer_kriteria_harga_jual, customer_priority, " _
                    & "customer_max_piutang, getPiutangSisaCusto(customer_kode), " _
                    & "TRIM(BOTH ', ' FROM CONCAT_WS(', ',customer_alamat,customer_kecamatan,customer_kabupaten)) 'Alamat' " _
                    & "FROM data_customer_master WHERE customer_status=1 AND (customer_nama LIKE '%{0}%' OR customer_kode LIKE '%{0}%') LIMIT 250"
            Case "gudang"
                in_alamat_c.Visible = False
                popPnl_barang.Height = 135
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang " _
                    & "WHERE gudang_status=1 AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%')"
            Case "sales"
                in_alamat_c.Visible = False
                popPnl_barang.Height = 135
                q = "SELECT salesman_kode AS 'Kode', salesman_nama AS 'Nama' FROM data_salesman_master " _
                    & "WHERE salesman_status=1 AND (salesman_nama LIKE '%{0}%' OR salesman_kode LIKE '%{0}%')"
            Case Else
                Exit Sub
        End Select

        dt = getDataTablefromDB(String.Format(q, param))

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 100
            .Columns(1).Width = 150
            If tipe = "barang" Or tipe = "custo" Then
                For i = 2 To IIf(tipe = "custo", 6, 8)
                    .Columns(i).Visible = False
                Next
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
                    If .Cells(9).Value <= 0 Then
                        If MessageBox.Show("Barang " & .Cells(0).Value & " kosong/minus. Lanjutkan?", Me.Text,
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                            If Not TransConfirmValid(in_ket.Text) Then
                                Exit Sub
                            End If
                        Else
                            Exit Sub
                        End If
                    End If

                    in_barang.Text = .Cells(0).Value
                    in_barang_nm.Text = .Cells(1).Value
                    in_harga_beli.Value = .Cells(2).Value
                    in_disc1.Value = .Cells(3).Value
                    in_disc2.Value = .Cells(4).Value
                    in_disc3.Value = .Cells(5).Value
                    in_disc4.Value = .Cells(6).Value
                    in_disc5.Value = .Cells(7).Value
                    in_discrp.Value = .Cells(8).Value
                    loadSatuanBrg(in_barang.Text)
                    in_qty.Focus()

                Case "custo"
                    in_custo.Text = .Cells(0).Value
                    in_custo_n.Text = .Cells(1).Value
                    jeniscusto = .Cells(3).Value
                    in_term.Value = If(.Cells(2).Value = 0, 14, .Cells(2).Value)
                    maxpiutang = .Cells(4).Value
                    jumlahpiutang = .Cells(5).Value - IIf(formstate = InputState.Insert, 0, removeCommaThousand(in_netto.Text))
                    in_custo_al.Text = Strings.Replace(.Cells(7).Value, Environment.NewLine, " ")
                    in_gudang_n.Focus()
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    in_custo_n.Focus()
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    in_term.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
    End Sub

    'INPUT DATA TO DGV FR TEXTBOX
    Private Sub txtToDgv()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        in_barang.Text = Trim(in_barang.Text)
        If in_barang_nm.Text = Nothing Then
            in_barang.Focus()
            Exit Sub
        End If
        If in_qty.Value = 0 Then
            in_qty.Focus()
            Exit Sub
        End If

        Dim pajak_tot As Decimal = 0
        Dim total As Decimal = in_harga_beli.Value * in_qty.Value
        Dim hpp As Decimal = 0
        Dim _pajak As String = ""
        Dim q As String = ""

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT barang_pajak FROM data_barang_master WHERE barang_kode='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, in_barang.Text))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _pajak = rdx.Item(0)
                    Else
                        Exit Sub
                    End If
                End Using

                If (_pajak = 0 And cb_ppn.SelectedValue <> 0) Or (_pajak = 1 And {1, 2}.Contains(cb_ppn.SelectedValue) = False) Then
                    MessageBox.Show("Kategori barang tidak sesuai dengan kategori pajak faktur/nota beli", "Penjualan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    in_barang_nm.Focus()
                    popPnl_barang.Visible = False
                    Exit Sub
                End If

                q = "SELECT getHPPAVG('{0}','{1}','{2}')"
                Using rdx = x.ReadCommand(String.Format(q, in_barang.Text, date_tgl_beli.Value.ToString("yyyy-MM-dd"), selectperiode.id))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        hpp = rdx.Item(0)
                    Else
                        Exit Sub
                    End If
                End Using
            Else
                Exit Sub
            End If
        End Using

        If in_discrp.Value <> 0 Then
            total -= in_discrp.Value * in_qty.Value
        End If

        For Each x As Decimal In {in_disc1.Value, in_disc2.Value, in_disc3.Value, in_disc4.Value, in_disc5.Value}
            If x <> 0 Then
                total = total * (1 - x / 100)
            Else
                total = total
            End If
        Next

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
                .Cells("discrp").Value = in_discrp.Value
                .Cells("disc1").Value = in_disc1.Value
                .Cells("disc2").Value = in_disc2.Value
                .Cells("disc3").Value = in_disc3.Value
                .Cells("disc4").Value = in_disc4.Value
                .Cells("disc5").Value = in_disc5.Value
                .Cells("jml").Value = total
                .Cells("brg_hpp").Value = hpp
            End With
        End With

        countBiaya()
        clearInputBarang()
        in_barang_nm.Clear()
        in_barang.Focus()

        cb_ppn.Enabled = False
        in_gudang_n.ReadOnly = True
        'in_sales_n.ReadOnly = True
    End Sub

    'GET DATA FRM DGV TO TEXTBOX
    Private Sub dgvToTxt()
        Dim _idx As Integer = 0

        With dgv_barang.SelectedRows.Item(0)
            _idx = .Index
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty.Value = .Cells("qty").Value
            loadSatuanBrg(.Cells("kode").Value)
            cb_sat.SelectedValue = .Cells("sat_type").Value
            _satuanstate = .Cells("sat_type").Value
            in_harga_beli.Text = .Cells("harga").Value
            'in_subtotal.Text = .Cells("subtot").Value
            in_disc1.Value = .Cells("disc1").Value
            in_disc2.Value = .Cells("disc2").Value
            in_disc3.Value = .Cells("disc3").Value
            in_disc4.Value = .Cells("disc4").Value
            in_disc5.Value = .Cells("disc5").Value
            in_discrp.Value = .Cells("discrp").Value
        End With

        dgv_barang.Rows.RemoveAt(_idx)
        countBiaya()
        in_qty.Focus()

        If dgv_barang.RowCount = 0 Then
            cb_ppn.Enabled = True
            in_gudang_n.ReadOnly = False
            'in_sales_n.ReadOnly = False
        End If
    End Sub

    'COUNT COST & VALUE
    Public Sub countBiaya()
        Dim pajak As Decimal = 0
        Dim subtotal As Decimal = 0
        Dim y As Decimal = 0
        Dim netto As Decimal = y
        Dim diskon As Decimal = 0

        For Each rows As DataGridViewRow In dgv_barang.Rows
            subtotal += rows.Cells("subtotal").Value
            diskon += rows.Cells("subtotal").Value - rows.Cells("jml").Value
        Next

        y = subtotal - diskon
        netto = y

        If cb_ppn.SelectedValue = 2 Then
            pajak = subtotal * 0.1
            netto += pajak
        ElseIf cb_ppn.SelectedValue = 1 Then
            pajak = subtotal * (1 - 10 / 11)
        Else
            pajak = 0
        End If

        in_jumlah.Text = commaThousand(subtotal)
        in_diskon.Text = commaThousand(diskon)
        in_ppn_tot.Text = commaThousand(pajak)
        in_total.Text = commaThousand(y)
        in_netto.Text = commaThousand(netto)
        in_sisa.Text = commaThousand(netto - in_bayar.Value)
    End Sub

    Private Sub countSubtotalItem()

    End Sub

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
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim dataBrg, dataHead As String()
        Dim querycheck As Boolean = False
        Dim queryArr As New List(Of String)
        Dim q As String = ""

        Dim _tgltrans As String = date_tgl_beli.Value.ToString("yyyy-MM-dd")
        in_faktur.Text = Trim(in_faktur.Text)

        '==========================================================================================================================
        dataHead = {
            "faktur_tanggal_trans='" & _tgltrans & "'",
            "faktur_pajak_no='" & in_pajak.Text & "'",
            "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
            "faktur_gudang='" & in_gudang.Text & "'",
            "faktur_sales='" & in_sales.Text & "'",
            "faktur_customer='" & in_custo.Text & "'",
            "faktur_term='" & in_term.Value & "'",
            "faktur_catatan='" & in_ket.Text & "'",
            "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text).ToString.Replace(",", ".") & "'",
            "faktur_disc_rupiah='" & removeCommaThousand(in_diskon.Text).ToString.Replace(",", ".") & "'",
            "faktur_total='" & removeCommaThousand(in_total.Text).ToString.Replace(",", ".") & "'",
            "faktur_ppn_persen='" & removeCommaThousand(in_ppn_tot.Text).ToString.Replace(",", ".") & "'",
            "faktur_ppn_jenis='" & cb_ppn.SelectedValue & "'",
            "faktur_netto='" & removeCommaThousand(in_netto.Text).ToString.Replace(",", ".") & "'",
            "faktur_bayar='" & in_bayar.Value.ToString.Replace(",", ".") & "'",
            "faktur_status=" & tjlStatus
            }

        'SAVE HEADER
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _qGet As String = ""
                'START OF INSERT UPDATE HEADER ====================================================================================================
                If bt_simpanjual.Text = "Simpan" Then
                    'START OF NEW TRANSACTION =====================================================================================================
                    If in_faktur.Text = Nothing Then
                        'START OF GENERATING NEW CODE =============================================================================================
                        Dim no As Integer = 1
                        Dim tgl As String = date_tgl_beli.Value.ToString("yyyyMMdd")

                        _qGet = "SELECT COUNT(faktur_kode) FROM data_penjualan_faktur WHERE SUBSTRING(faktur_kode,3,8)='{0}' AND faktur_kode LIKE 'SO%'"

                        Try
                            no = CInt(x.ExecScalar(String.Format(_qGet, tgl)))
                            in_faktur.Text = "SO" & tgl & no.ToString("D4")

                            q = "INSERT INTO data_penjualan_faktur SET faktur_kode='{0}',{1},faktur_reg_date=NOW(),faktur_reg_alias='{2}'"
                        Catch ex As Exception
                            MessageBox.Show("Terjadi kesalahan dalam melakukan proses penyimpanan data." & Environment.NewLine & ex.Message,
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            logError(ex, True) : Exit Sub
                        End Try
                        'END OF GENERATING NEW CODE ===============================================================================================

                    ElseIf in_faktur.Text <> Nothing Then
                        'START OF CHECKING USER INPUTED CODE ======================================================================================
                        Dim cAct As Integer = 0 : Dim cDel As Integer = 0
                        _qGet = "SELECT COUNT(CASE WHEN faktur_status!=9 THEN 1 END) ActiveCode, COUNT(CASE WHEN faktur_status=9 THEN 1 END) DeleteCode " _
                                & "FROM data_penjualan_faktur WHERE faktur_kode='{0}'"
                        Using rdx = x.ReadCommand(String.Format(_qGet, in_faktur.Text), CommandBehavior.SingleRow)
                            Dim red = rdx.Read
                            If red And rdx.HasRows Then
                                cAct = rdx.Item(0) : cDel = rdx.Item(1)
                            End If
                        End Using

                        If cAct = 1 Then 'WHEN THE CODE ALREADY TAKEN
                            MessageBox.Show("Nomor faktur " & in_faktur.Text & " sudah pernah diinputkan", "Penjualan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            in_faktur.Focus() : Exit Sub
                        ElseIf cAct = 0 And cDel = 0 Then 'WHEN THE CODE IS AVAILABLE
                            q = "INSERT INTO data_penjualan_faktur SET faktur_kode='{0}',{1},faktur_reg_date=NOW(),faktur_reg_alias='{2}'"
                        ElseIf cDel = 1 Then 'WHEN THE CODE IS ALREADY TAKEN BUT THE TRASACTION STATE IS DELETE
                            q = "UPDATE data_penjualan_faktur SET {1}, faktur_reg_date=NOW(), faktur_reg_alias='{2}', " _
                                & "faktur_upd_date=NULL, faktur_upd_alias=NULL WHERE faktur_kode='{0}'"
                        Else 'WHEN THERE IS DUPLICATION IN DATABASE ON THE CODE
                            MessageBox.Show("Terjadi kesalahan dalam melakukan proses penyimpanan data." & Environment.NewLine & _
                                            "Terdapat duplikasi kode pada database, kode faktur tidak dapat digunakan.",
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            errLog(New List(Of String) From {"Error : Duplicate primary code in database for sale transaction.",
                                                             encryptString("Duplicated Code : " & in_faktur.Text)
                                                            }) : Exit Sub
                        End If
                        'END OF CHECKING USER INPUTED CODE ========================================================================================
                    End If
                    'END OF NEW TRANSACTION =======================================================================================================

                ElseIf bt_simpanjual.Text = "Update" Then
                    q = "UPDATE data_penjualan_faktur SET {1},faktur_upd_date=NOW(), faktur_upd_alias='{2}' WHERE faktur_kode='{0}'"
                End If
                queryArr.Add(String.Format(q, in_faktur.Text, String.Join(",", dataHead), loggeduser.user_id))
                'END OF INSERT UPDATE HEADER ======================================================================================================

                'START OF INSERT UPDATE BARANG ====================================================================================================
                q = "UPDATE data_penjualan_trans SET trans_status=9 WHERE trans_faktur='{0}'"
                queryArr.Add(String.Format(q, in_faktur.Text))

                Dim _ckbarang As Boolean = True
                Dim _brg As New List(Of String)
                For Each rows As DataGridViewRow In dgv_barang.Rows
                    Dim stockkode As String = in_gudang.Text & "-" & rows.Cells(0).Value & "-" & selectperiode.id
                    Dim _qty As Integer = 0
                    Dim _qty2 As Integer = 0
                    Dim _hpp As Decimal = 0
                    Dim _kdbrg As String = rows.Cells(0).Value

                    'GET HPP
                    _qGet = "SELECT getHPPAVG('{0}','{1}','{2}')"
                    _hpp = CDec(x.ExecScalar(String.Format(_qGet, _kdbrg, _tgltrans, selectperiode.id)))
                    'q = "SELECT getHPPAVG('{0}','{1}','{2}'), getStockSisa('{0}','{3}'), countQTYItem('{0}',{4},'{5}')"
                    'readcommd(String.Format(q, _kdbrg, _tgltrans, selectperiode.id, in_gudang.Text, rows.Cells("qty").Value, rows.Cells("sat_type").Value))
                    'If rd.HasRows Then
                    '    _hpp = rd.Item(0)
                    '    _qty = rd.Item(1)
                    '    _qty2 = rd.Item(2)
                    'End If
                    'rd.Close()

                    'If _qty <= 0 Or If(formstate = InputState.Insert, _qty2, 0) > _qty Then
                    '    _ckbarang = False
                    '    _brg.Add(_kdbrg)
                    'End If

                    dataBrg = {
                       "trans_barang='" & _kdbrg & "'",
                       "trans_harga_jual='" & rows.Cells("harga").Value & "'",
                       "trans_qty='" & rows.Cells("qty").Value & "'",
                       "trans_satuan='" & rows.Cells("sat").Value & "'",
                       "trans_satuan_type='" & rows.Cells("sat_type").Value & "'",
                       "trans_disc1='" & Decimal.Parse(rows.Cells("disc1").Value).ToString.Replace(",", ".") & "'",
                       "trans_disc2='" & Decimal.Parse(rows.Cells("disc2").Value).ToString.Replace(",", ".") & "'",
                       "trans_disc3='" & Decimal.Parse(rows.Cells("disc3").Value).ToString.Replace(",", ".") & "'",
                       "trans_disc4='" & Decimal.Parse(rows.Cells("disc4").Value).ToString.Replace(",", ".") & "'",
                       "trans_disc5='" & Decimal.Parse(rows.Cells("disc5").Value).ToString.Replace(",", ".") & "'",
                       "trans_disc_rupiah='" & Decimal.Parse(rows.Cells("discrp").Value).ToString.Replace(",", ".") & "'",
                       "trans_jumlah='" & Decimal.Parse(rows.Cells("jml").Value).ToString.Replace(",", ".") & "'",
                       "trans_hpp='" & Decimal.Parse(_hpp).ToString.Replace(",", ".") & "'",
                       "trans_status=1",
                       "trans_reg_date=NOW()",
                       "trans_reg_alias='" & loggeduser.user_id & "'"
                       }
                    q = "INSERT INTO data_penjualan_trans SET trans_faktur= '{0}',{1}"
                    queryArr.Add(String.Format(q, in_faktur.Text, String.Join(",", dataBrg)))

                Next
                'END OF INSERT UPDATE BARANG ======================================================================================================

                'UPDATE ORDER JUAL
                q = "UPDATE data_penjualan_order_faktur SET j_order_ref_faktur='{0}' WHERE j_order_kode='{1}'"
                If refOrderJual <> Nothing Then
                    queryArr.Add(String.Format(q, in_faktur.Text, refOrderJual))
                End If

                '==========================================================================================================================
                'BEGIN TRANSACTION
                querycheck = x.TransactCommand(queryArr)
                '==========================================================================================================================
            End If
        End Using
        '==========================================================================================================================
        '==========================================================================================================================

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            doRefreshTab({pgpenjualan})
            Me.Close()
        End If
    End Sub

    Private Function CheckPenjualan() As Boolean
        Dim RetVal As Boolean = False

        'CEK DATA CUSTO KETIKA INSERT BARU
        getDataCustomer(in_custo.Text)

        'CEK PRIORITAS CUSTO
        If custo_priority = False Then
            'CEK PIUTANG CUSTOMER
            If jumlahpiutang > 0 Then
                MessageBox.Show("Customer masih memiliki piutang yang belum dilunasi, transaksi penjualan tidak dapat dilakukan",
                                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                RetVal = TransConfirmValid(in_ket.Text)
            Else
                RetVal = True
            End If
        Else
            'CEK PIUTANG CUSTOMER
            If jumlahpiutang > 0 Then
                If MessageBox.Show("Customer masih memiliki piutang yang belum dilunasi, lanjutkan transaksi penjualan?",
                                   Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    RetVal = TransConfirmValid(in_ket.Text)
                End If
            Else
                RetVal = True
            End If
        End If


        Return RetVal
    End Function

    'CANCEL
    Private Sub changeTransactState(TransState As Integer)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If

        Dim _ket As String = ""

        If Not TransConfirmValid(_ket) Then Exit Sub

        Dim _failmsg As String = ""
        Dim _succmsg As String = ""
        If TransState = 1 Or TransState = 0 Then
            _failmsg = "Pembatalan gagal." : _succmsg = "Pembatalan Berhasil"
        ElseIf TransState = 2 Then
            _failmsg = "Pembatalan transaksi gagal." : _succmsg = "Pembatalan transaksi berhasil."
        ElseIf TransState = 9 Then
            _failmsg = "Transaksi tidak dapat dihapus." : _succmsg = "Transaksi berhasil dihapus."
        Else
            Exit Sub
        End If

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = "UPDATE data_penjualan_faktur SET faktur_status={3}, faktur_upd_date=NOW(), faktur_upd_alias='{1}', " _
                                  & "faktur_catatan=TRIM(BOTH '\r\n' FROM '{2}') WHERE faktur_kode='{0}'"
                Dim ckQuery = x.TransactCommand(New List(Of String) From {String.Format(q, in_faktur.Text, loggeduser.user_id, _ket, TransState)})
                If ckQuery Then
                    MessageBox.Show(_succmsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    doRefreshTab({pgpenjualan, pgpiutangawal})
                    Me.Close()
                Else
                    MessageBox.Show(_failmsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
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
        If MessageBox.Show("Tutup Form?", "Penjualan", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
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

    'MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanjual.PerformClick()
    End Sub

    Private Sub mn_print_Click(sender As Object, e As EventArgs) Handles mn_print.Click
        Me.Cursor = Cursors.WaitCursor
        Using nota As New fr_nota_dialog
            nota.do_load("jual", in_faktur.Text)
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mn_cancelorder_Click(sender As Object, e As EventArgs) Handles mn_cancelorder.Click
        If {0, 1}.Contains(tjlStatus) Then
            If MessageBox.Show("Batalkan Penjualan?", "Penjualan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim chkdt As Boolean = False
                Dim kodefaktur As String = in_faktur.Text

                Dim _msg As String = ""
                chkdt = CheckCancelPenjualan(kodefaktur, _msg)
                If chkdt Then
                    changeTransactState(2)
                Else
                    MessageBox.Show("Transaksi tidak dapat dibatalkan." & Environment.NewLine & _msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        ElseIf tjlStatus = 2 Then
            If MessageBox.Show("Cancel pembatalan?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'TODO : CHECK INPUT
                changeTransactState(1)
            End If
        End If
    End Sub

    Private Sub mn_delete_Click(sender As Object, e As EventArgs) Handles mn_delete.Click
        If MessageBox.Show("Hapus penjualan?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim chkdt As Boolean = False
            Dim kodefaktur As String = in_faktur.Text

            Dim _msg As String = ""
            chkdt = CheckCancelPenjualan(kodefaktur, _msg)
            If chkdt Then
                changeTransactState(9)
            Else
                MessageBox.Show("Transaksi tidak dapat dibatalkan." & Environment.NewLine & _msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    'LOAD
    Private Sub fr_jual_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv_barang.ClearSelection()
    End Sub

    'SAVE
    Private Sub bt_simpanjual_Click(sender As Object, e As EventArgs) Handles bt_simpanjual.Click
        If in_sales.Text = Nothing Then
            MessageBox.Show("Sales belum di input")
            in_sales_n.Focus()
            Exit Sub
        End If

        If in_custo.Text = Nothing Then
            MessageBox.Show("Customer belum di input")
            in_custo_n.Focus()
            Exit Sub
        End If

        If in_gudang.Text = Nothing Then
            MessageBox.Show("Gudang belum di input")
            in_gudang_n.Focus()
            Exit Sub
        End If

        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum di input")
            in_barang.Focus()
            Exit Sub
        End If

        If in_term.Value > 0 And formstate = InputState.Insert Then
            If Not CheckPenjualan() Then Exit Sub
        ElseIf formstate = InputState.Edit And oldterm = 0 And in_term.Value > 0 Then
            If Not CheckPenjualan() Then Exit Sub
        End If

        If in_bayar.Value <> 0 And removeCommaThousand(in_sisa.Text) < 0 Then
            MessageBox.Show("Nilai pembayaran melebihi nilai faktur.")
            in_bayar.Focus()
            Exit Sub
        End If

        If date_tgl_beli.Value < selectperiode.tglawal Then
            MessageBox.Show("Tanggal transaksi lebih kecil daripada Jangka waktu periode terpilih")
            date_tgl_beli.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan data penjualan?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    'UI
    '------------- POPUPSEARCH PANEL
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

    Private Sub dgv_listbarang_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellEnter
        If popupstate = "custo" And dgv_listbarang.Focused = True Then
            in_alamat_c.Text = dgv_listbarang.SelectedRows.Item(0).Cells(7).Value
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            Dim x As TextBox
            Select Case popupstate
                Case "sales"
                    x = in_sales_n
                Case "gudang"
                    x = in_gudang_n
                Case "barang"
                    x = in_barang_nm
                Case "custo"
                    x = in_custo_n
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

    '------------- cb prevent input
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_ppn.KeyPress, cb_sat.KeyPress
        If e.KeyChar <> ControlChars.Cr Then
            e.Handled = True
        End If
    End Sub

    '-------------cb_ppn hanlde
    Private Sub cb_ppn_change(sender As Object, e As EventArgs) Handles cb_ppn.SelectionChangeCommitted
        If cb_ppn.SelectedIndex > -1 Then
            countBiaya()
        End If
    End Sub

    '------------- numeric
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_bayar.Enter, in_discrp.Enter, in_disc3.Enter, in_disc2.Enter, in_disc1.Enter, in_disc4.Enter, in_disc5.Enter, in_term.Enter, in_harga_beli.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_bayar.Leave, in_discrp.Leave, in_disc3.Leave, in_disc2.Leave, in_disc1.Leave, in_disc4.Leave, in_disc5.Leave, in_term.Leave, in_harga_beli.Leave
        Select Case sender.Name.ToString
            Case "in_bayar", "in_harga_beli"
                numericLostFocus(sender)
            Case "in_disc1", "in_disc2", "in_disc3", "in_disc4", "in_disc5"
                numericLostFocus(sender, "N1")
            Case Else
                numericLostFocus(sender, "N0")
        End Select
    End Sub

    '----------------- HEADER
    Private Sub in_faktur_KeyUp(sender As Object, e As KeyEventArgs) Handles in_faktur.KeyUp
        keyshortenter(date_tgl_beli, e)
    End Sub

    Private Sub date_tgl_beli_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyUp
        keyshortenter(in_pajak, e)
    End Sub

    Private Sub in_pajak_KeyUp(sender As Object, e As KeyEventArgs) Handles in_pajak.KeyUp
        keyshortenter(date_tgl_pajak, e)
    End Sub

    Private Sub date_tgl_pajak_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tgl_pajak.KeyUp
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_sales_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales.KeyUp
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_sales_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter
        If sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(in_sales_n.Left, in_sales_n.Top + in_sales_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
                popPnl_barang.Width = 386
            End If
            popupstate = "sales"
            loadDataBRGPopup("sales", in_sales_n.Text)
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave, in_custo_n.Leave, in_gudang_n.Leave, in_barang_nm.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_sales_n_MouseClick(sender As Object, e As MouseEventArgs) Handles in_sales_n.MouseClick, in_custo_n.MouseClick, in_barang_nm.MouseClick
        If popPnl_barang.Visible = False And sender.ReadOnly = False Then
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyDown, in_custo_n.KeyDown, in_barang_nm.KeyDown, in_gudang_n.KeyDown
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            Select Case sender.Name.ToString
                Case "in_sales_n"
                    keyshortenter(in_custo_n, e)
                Case "in_custo_n"
                    keyshortenter(in_gudang_n, e)
                Case "in_barang_nm"
                    keyshortenter(in_qty, e)
                Case "in_gudang_n"
                    keyshortenter(in_term, e)
                Case Else
                    Exit Sub
            End Select
        Else
            If e.KeyCode <> Keys.Escape Then
                If e.KeyCode = Keys.Back Or sender.Text = "" Then
                    Select Case sender.Name.ToString
                        Case "in_sales_n"
                            in_sales.Clear()
                            _salesgudang = False
                            _salesitem = False
                        Case "in_custo_n"
                            in_custo.Clear()
                            maxpiutang = 0
                            jumlahpiutang = 0
                        Case "in_barang_nm"
                            in_barang.Clear()
                        Case "in_gudang_n"
                            in_gudang.Clear()
                        Case Else
                            Exit Sub
                    End Select
                End If
                If popPnl_barang.Visible = False And sender.ReadOnly = False Then
                    popPnl_barang.Visible = True
                End If
                loadDataBRGPopup(popupstate, sender.Text & IIf(Char.IsLetterOrDigit(Convert.ToChar(e.KeyCode)), Convert.ToChar(e.KeyCode), ""))
            End If
        End If
    End Sub

    Private Sub in_custo_KeyUp(sender As Object, e As KeyEventArgs) Handles in_custo.KeyDown
        keyshortenter(in_custo_n, e)
    End Sub

    Private Sub in_custo_n_Enter(sender As Object, e As EventArgs) Handles in_custo_n.Enter
        If sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(in_custo_n.Left, in_custo_n.Top + in_custo_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
                popPnl_barang.Width = 436
            End If
            popupstate = "custo"
            loadDataBRGPopup("custo", in_custo_n.Text)
        End If
    End Sub

    Private Sub in_custo_n_TextChanged(sender As Object, e As EventArgs) Handles in_custo_n.TextChanged
        If in_custo_n.Text = "" Then
            in_custo_n.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub in_gudang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_gudang_n_Enter(sender As Object, e As EventArgs) Handles in_gudang_n.Enter
        If sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(in_gudang_n.Left, in_gudang_n.Top + in_gudang_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
                popPnl_barang.Width = 386
            End If
            popupstate = "gudang"
            loadDataBRGPopup("gudang", in_gudang_n.Text)
        End If
    End Sub

    Private Sub in_gudang_n_TextChanged(sender As Object, e As EventArgs) Handles in_gudang_n.TextChanged
        If in_gudang_n.Text = "" Then
            in_gudang_n.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub in_term_KeyUp(sender As Object, e As KeyEventArgs) Handles in_term.KeyDown
        keyshortenter(cb_ppn, e)
    End Sub

    Private Sub cb_ppn_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_ppn.KeyDown
        keyshortenter(in_barang_nm, e)
    End Sub

    'BARANG
    Private Sub in_barang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_barang.KeyUp
        keyshortenter(in_barang_nm, e)
    End Sub

    Private Sub in_barang_nm_Enter(sender As Object, e As EventArgs) Handles in_barang_nm.Enter
        If sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(in_barang_nm.Left, in_barang_nm.Top + in_barang_nm.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
                popPnl_barang.Width = 386
            End If
            popupstate = "barang"
            loadDataBRGPopup("barang", in_barang_nm.Text)
        End If
    End Sub

    Private Sub in_qty_KeyUp(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
        keyshortenter(cb_sat, e)
    End Sub

    Private Sub in_harga_beli_ValueChanged(sender As Object, e As EventArgs) Handles in_qty.ValueChanged, in_harga_beli.ValueChanged, in_disc1.ValueChanged, in_disc2.ValueChanged, in_disc3.ValueChanged, in_disc4.ValueChanged, in_disc5.ValueChanged, in_discrp.ValueChanged
        'in_subtotal.Text = commaThousand(in_qty.Value * in_harga_beli.Value)
        Dim total As Decimal = in_qty.Value * in_harga_beli.Value

        If in_discrp.Value <> 0 Then
            total -= in_discrp.Value * in_qty.Value
        End If

        For Each x As Decimal In {in_disc1.Value, in_disc2.Value, in_disc3.Value, in_disc4.Value, in_disc5.Value}
            If x <> 0 Then
                Dim y As Decimal = total
                total = y * (1 - x / 100)
            Else
                total = total
            End If
        Next

        in_subtotal.Text = commaThousand(total)
    End Sub

    Private Sub cb_sat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_sat.SelectionChangeCommitted
        in_harga_beli.Value = countHarga(_satuanstate, in_harga_beli.Value, cb_sat.SelectedValue)
        _satuanstate = cb_sat.SelectedValue
    End Sub

    Private Sub cb_sat_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_sat.KeyDown
        keyshortenter(in_harga_beli, e)
    End Sub

    Private Sub in_harga_beli_KeyUp(sender As Object, e As KeyEventArgs) Handles in_harga_beli.KeyDown
        keyshortenter(in_discrp, e)
    End Sub

    Private Sub in_discrp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_discrp.KeyDown
        keyshortenter(in_disc1, e)
    End Sub

    Private Sub in_subtotal_KeyUp(sender As Object, e As KeyEventArgs) Handles in_subtotal.KeyDown
        keyshortenter(in_disc1, e)
    End Sub

    Private Sub in_disc1_KeyUp(sender As Object, e As KeyEventArgs) Handles in_disc1.KeyDown
        keyshortenter(in_disc2, e)
    End Sub

    Private Sub in_disc2_KeyUp(sender As Object, e As KeyEventArgs) Handles in_disc2.KeyDown
        keyshortenter(in_disc3, e)
    End Sub

    Private Sub in_disc3_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc3.KeyDown
        keyshortenter(in_disc4, e)
    End Sub

    Private Sub in_disc4_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc4.KeyDown
        keyshortenter(in_disc5, e)
    End Sub

    Private Sub in_disc5_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc5.KeyDown
        keyshortenter(bt_tbbarang, e)
    End Sub

    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        txtToDgv()
    End Sub

    'DGV
    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If loggeduser.allowedit_transact = True And selectperiode.closed = False And ({0, 1}).Contains(tjlStatus) = True Then
            If e.RowIndex > -1 Then
                dgvToTxt()
                dgv_barang.ClearSelection()
            End If
        End If
    End Sub

    Private Sub in_bayar_ValueChanged(sender As Object, e As EventArgs) Handles in_bayar.ValueChanged
        Dim sisa As Decimal = IIf(in_netto.Text <> Nothing, removeCommaThousand(in_netto.Text), 0) - in_bayar.Value
        in_sisa.Text = commaThousand(sisa)
        If sisa = 0 Then
            in_term.Value = 0
        End If
        'countBiaya()
    End Sub

    Private Sub fr_jual_detail_Click(sender As Object, e As EventArgs) Handles MyBase.Click, pnl_content.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub
End Class