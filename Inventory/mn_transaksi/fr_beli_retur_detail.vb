﻿Public Class fr_beli_retur_detail
    Private rtbStatus As String = "1"
    Private _persediaan As Decimal = 0
    Private popupstate As String = "barang"
    Private indexrow As Integer = 0
    Private hargabesr As Decimal = 0
    Private isibesar As Integer = 0
    Private isitengah As Integer = 0
    Private _satuanstate As String = "kecil"
    Private jumlahhutang As Decimal = 0

    Private _prevjenisbayar As New KeyValuePair(Of String, String)
    Private _prevnilairetur As Decimal = 0

    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
        View
    End Enum

    '-----------------------note
    'hitung pajak -> unfinished
    'all accounting calculation is not yet finished or even created
    'retur di sistem berjalan tidak berdasarkan faktur pembelian saat input
    '

    'STYLE
    Private m_aeroEnabled As Boolean = False
    Private Const CS_DROPSHADOW As Int32 = &H20000
    Private Const WM_NCPAINT As Int32 = 133
    Private Const WM_ACTIVATEAPP As Int32 = 28

    Private Const WM_NCHITTEST As Int32 = &H84
    Private Const HTCLIENT As Int32 = &H1
    Private Const HTCAPTION As Int32 = &H2

    'DROP SHADOW
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            m_aeroEnabled = CheckAeroEnabled()

            Dim parameters As CreateParams = MyBase.CreateParams
            If Not m_aeroEnabled Then parameters.ClassStyle += CS_DROPSHADOW
            Return parameters
        End Get
    End Property

    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case WM_NCPAINT
                If m_aeroEnabled Then
                    Dim v = 2
                    DwmSetWindowAttribute(Me.Handle, 2, v, 4)
                    Dim margins As New Margins With {
                        .bottomHeight = 1,
                        .leftWidth = 0,
                        .rightWidth = 0,
                        .topHeight = 0
                        }
                    DwmExtendFrameIntoClientArea(Me.Handle, margins)
                End If
        End Select
        MyBase.WndProc(m)
        If (m.Msg = WM_NCHITTEST AndAlso m.Result.ToInt32 = HTCLIENT) Then m.Result = HTCAPTION
    End Sub

    'SETUP FORM
    Private Sub SetUpForm(NoFaktur As String, FormSet As InputState, AllowEdit As Boolean)
        formstate = FormSet : Me.Opacity = 0

        With cb_bayar_jenis
            .DataSource = jenisBayar("retur")
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With
        With cb_ppn
            .DataSource = jenis("jenis_ppn")
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedValue = 1
        End With

        'With date_tgl_trans
        '    .Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        '    .MaxDate = selectperiode.tglakhir
        '    .MinDate = selectperiode.tglawal
        'End With
        'date_tgl_pajak.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        For Each x As DateTimePicker In {date_tgl_trans, date_tgl_pajak}
            x.Value = IIf(DataListEndDate > Today, Today, DataListEndDate)
            x.MinDate = If(formstate = InputState.Insert, TransStartDate, DataListStartDate)
            x.MaxDate = DataListEndDate
        Next

        If Not FormSet = InputState.Insert Then
            Dim _resp = loadData(NoFaktur)
            If Not _resp.Key Then
                MessageBox.Show(_resp.Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
            End If
            If Not {0, 1}.Contains(rtbStatus) Or date_tgl_trans.Value < TransStartDate Then formstate = InputState.View
        End If

        If formstate = InputState.View Then AllowEdit = False
        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        If formstate <> InputState.Insert Then
            in_no_bukti.ReadOnly = True : in_no_bukti.BackColor = Color.Gainsboro
            bt_simpanreturbeli.Text = "Update"
            tstrip_print.Enabled = If(rtbStatus = 1, True, False)
            tstrip_status.Enabled = If(date_tgl_trans.Value < TransStartDate, False, True)
        Else
            tstrip_print.Enabled = False
            tstrip_status.Enabled = False
        End If
        For Each txt As TextBox In {in_gudang_n, in_no_faktur_ex, in_no_faktur, in_barang_nm, in_pajak, in_ket}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        For Each cbx As ComboBox In {cb_bayar_jenis}
            cbx.Enabled = AllowInput
        Next
        For Each dtpick As DateTimePicker In {date_tgl_pajak, date_tgl_trans}
            dtpick.Enabled = AllowInput
        Next
        For Each ctr As Control In {in_qty, cb_sat, in_harga_retur, in_diskon, bt_tbbarang}
            ctr.Visible = AllowInput
        Next
        For Each x As DataGridViewColumn In {harga, jml, subtot, diskon}
            x.DefaultCellStyle = dgvstyle_currency
        Next
        qty.DefaultCellStyle = dgvstyle_commathousand

        bt_simpanreturbeli.Enabled = AllowInput
        tstrip_simpan.Enabled = AllowInput
        tstrip_other.Enabled = AllowInput
        tstrip_new_barang.Enabled = IIf(main.listkodemenu.Contains("mn0101"), AllowInput, False)
        tstrip_new_gudang.Enabled = IIf(main.listkodemenu.Contains("mn0103"), AllowInput, False)

        If Not formstate = InputState.Insert Then
            Dim _rowcount As Integer = dgv_barang.RowCount
            in_supplier_n.ReadOnly = IIf(_rowcount > 0, True, False)
            If in_supplier_n.ReadOnly Then in_supplier_n.BackColor = Color.Gainsboro
            cb_ppn.Enabled = IIf(_rowcount > 0, False, True)
        Else
            in_supplier_n.ReadOnly = IIf(AllowInput, False, True)
            cb_ppn.Enabled = AllowInput
        End If

        If AllowInput Then
            dgv_barang.Location = New Point(12, 178) : dgv_barang.Height = 154
            AddHandler dgv_barang.CellDoubleClick, AddressOf dgv_barang_CellDoubleClick
        Else
            dgv_barang.Location = New Point(12, 136) : dgv_barang.Height = 196
            RemoveHandler dgv_barang.CellDoubleClick, AddressOf dgv_barang_CellDoubleClick
        End If
    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        SetUpForm(Nothing, InputState.Insert, AllowInput)
        Me.Show()
        in_supplier_n.Focus()
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, AllowEdit As Boolean)
        SetUpForm(NoFaktur, InputState.Edit, AllowEdit)
        Me.Show()
        in_supplier_n.Focus()
    End Sub

    Public Sub doLoadView(NoFaktur As String)
        SetUpForm(NoFaktur, InputState.View, Nothing)
        Me.Show()
        bt_batalreturbeli.Focus()
    End Sub

    Private Sub fr_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 100
        dgv_barang.ClearSelection()
    End Sub

    'LOAD DATA
    Private Function loadData(kode As String) As KeyValuePair(Of Boolean, String)
        If MainConnData.IsEmpty Then Return New KeyValuePair(Of Boolean, String)(False, "Main DB Configuration is empty.")

        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    'LOAD HEADER
                    Using rdx As MySql.Data.MySqlClient.MySqlDataReader = x.ReadCommand(String.Format("CALL getTransHeader('RBELI','{0}')", kode))
                        Dim red = rdx.Read()
                        If red And rdx.HasRows Then
                            in_no_bukti.Text = kode
                            in_pajak.Text = rdx.Item("faktur_pajak_no")
                            date_tgl_trans.Value = rdx.Item("faktur_tanggal_trans")
                            date_tgl_pajak.Value = rdx.Item("faktur_pajak_tanggal")
                            cb_bayar_jenis.SelectedValue = rdx.Item("faktur_jen_bayar")
                            in_no_faktur.Text = rdx.Item("faktur_kode_faktur")
                            _prevjenisbayar = New KeyValuePair(Of String, String)(rdx.Item("faktur_jen_bayar"), rdx.Item("faktur_kode_faktur"))
                            in_no_faktur_ex.Text = rdx.Item("faktur_kode_exfaktur")
                            in_ket.Text = rdx.Item("faktur_sebab")
                            in_supplier.Text = rdx.Item("faktur_supplier")
                            in_supplier_n.Text = rdx.Item("supplier_nama")
                            in_gudang.Text = rdx.Item("faktur_gudang")
                            in_gudang_n.Text = rdx.Item("gudang_nama")
                            _persediaan = rdx.Item("faktur_persediaan")
                            in_jumlah.Text = commaThousand(rdx.Item("faktur_jumlah"))
                            in_ppn_tot.Text = commaThousand(rdx.Item("faktur_ppn"))
                            cb_ppn.SelectedValue = rdx.Item("faktur_ppn_jenis")
                            in_netto.Text = commaThousand(rdx.Item("faktur_netto"))
                            _prevnilairetur = rdx.Item("faktur_netto")
                            rtbStatus = rdx.Item("faktur_status")
                        End If
                        cb_bayar_jenis_SelectedIndexChanged(Nothing, Nothing)
                    End Using

                    If cb_bayar_jenis.SelectedValue = 1 Then
                        Dim _nilaihutang As Decimal = GetHutang(in_no_faktur.Text)
                        If formstate <> InputState.Insert Then
                            jumlahhutang = _nilaihutang + IIf({0, 1}.Contains(rtbStatus), removeCommaThousand(in_netto.Text), 0)
                        Else
                            jumlahhutang = _nilaihutang
                        End If
                        in_nilaihutang.Text = commaThousand(jumlahhutang)
                    End If

                    'LOAD TABLE/ITEM
                    Dim q As String = "SELECT trans_barang, barang_nama, trans_harga_retur, trans_qty, trans_satuan, " _
                                      & "trans_satuan_type, trans_hpp, trans_diskon FROM data_pembelian_retur_trans " _
                                      & "INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='{0}' AND trans_status=1"
                    Using dt As DataTable = x.GetDataTable(String.Format(q, kode))
                        With dgv_barang.Rows
                            For Each rows As DataRow In dt.Rows
                                Dim i = .Add
                                .Item(i).Cells("kode").Value = rows.ItemArray(0)
                                .Item(i).Cells("nama").Value = rows.ItemArray(1)
                                .Item(i).Cells("harga").Value = rows.ItemArray(2)
                                .Item(i).Cells("qty").Value = rows.ItemArray(3)
                                .Item(i).Cells("sat").Value = rows.ItemArray(4)
                                .Item(i).Cells("sat_type").Value = rows.ItemArray(5)
                                .Item(i).Cells("subtot").Value = rows.ItemArray(3) * rows.ItemArray(2)
                                .Item(i).Cells("brg_hpp").Value = rows.ItemArray(6)
                                .Item(i).Cells("diskon").Value = rows.ItemArray(7)
                                .Item(i).Cells("jml").Value = .Item(i).Cells("subtot").Value * (1 - (rows.ItemArray(7) / 100))
                            Next
                        End With
                    End Using
                    Select Case rtbStatus
                        Case 0 : in_status.Text = "Pending"
                        Case 1 : in_status.Text = "Aktif"
                        Case 2 : in_status.Text = "Batal"
                        Case 8 : in_status.Text = "On-Edit/NOT IMPLEMENTED!"
                        Case 9 : in_status.Text = "Delete"
                        Case Else
                            Return New KeyValuePair(Of Boolean, String)(False, "Status data ")
                    End Select
                    Return New KeyValuePair(Of Boolean, String)(True, "OK")

                Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat terhubung ke database.")
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            Return New KeyValuePair(Of Boolean, String)(False, "Terjadi kesalahan saat melakukan pengambilan data." & Environment.NewLine & ex.Message)
        End Try
    End Function

    'SET SATUAN BARANG
    Private Sub loadSatuanBrg(kode As String)
        Dim dt As DataTable = GetSatuanForCombo(kode, isitengah, isibesar)

        cb_sat.DataSource = dt
        cb_sat.DisplayMember = "Text"
        cb_sat.ValueMember = "Value"
        cb_sat.SelectedValue = "besar"
        _satuanstate = cb_sat.SelectedValue
    End Sub

    'COUNT SUBTOTAL
    Private Function countSubtot(harga As Decimal, qty As Integer, Optional disk As Decimal = 0) As Decimal
        Dim retSubtot As Decimal = 0
        Dim _jl As Decimal = 0
        Dim _disk As Decimal = 0

        _jl = harga * qty
        _disk = _jl * (disk / 100)
        retSubtot = _jl - _disk

        Return retSubtot
    End Function

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Dim autoco As New AutoCompleteStringCollection
        Dim _pajak As String = IIf(cb_ppn.SelectedValue = 0, 0, 1)

        Select Case tipe
            Case "barang"
                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama', barang_harga_beli as harga_beli, getStockSisa(barang_kode,'{1}') 'Jumlah Stock' " _
                    & "FROM data_barang_master " _
                    & "LEFT JOIN data_stok_awal ON stock_barang=barang_kode AND stock_status=1 " _
                    & "WHERE (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%') AND stock_gudang='{1}' AND barang_supplier='{2}' AND barang_status=1 AND barang_pajak='{3}' LIMIT 250"
                q = String.Format(q, "{0}", in_gudang.Text, in_supplier.Text, _pajak)

            Case "supplier"
                q = "SELECT supplier_kode AS 'Kode', supplier_nama AS 'Nama' FROM data_supplier_master " _
                    & "WHERE supplier_status=1 AND (supplier_nama LIKE '%{0}%' OR supplier_kode LIKE '%{0}%') LIMIT 250"

            Case "gudang"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang " _
                    & "WHERE gudang_status=1 AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%') LIMIT 250"

            Case "faktur"
                q = "SELECT hutang_faktur AS 'Faktur', GetHutangSaldoAwal('hutang', hutang_faktur, ADDDATE(CURDATE(), 1)) as 'SisaHutang' " _
                    & "FROM data_hutang_awal " _
                    & "WHERE hutang_status=1 AND hutang_supplier='{1}' AND hutang_pajak={2} " _
                    & "AND hutang_faktur LIKE '%{0}%' LIMIT 250"
                q = String.Format(q, "{0}", in_supplier.Text, _pajak)

            Case Else
                Exit Sub
        End Select

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                dt = x.GetDataTable(String.Format(q, param))
            Else
                Exit Sub
            End If
        End Using

        With dgv_listbarang
            .DataSource = dt
            If .ColumnCount > 0 Then
                .Columns(0).Width = 135
                .Columns(1).Width = 200
                If tipe = "barang" Then : .Columns(2).Visible = False : .Columns(0).Width = 75
                ElseIf tipe = "faktur" Then : .Columns(1).Width = 125 : .Columns(1).DefaultCellStyle = dgvstyle_currency
                End If
                .Columns(.DisplayedColumnCount(False) - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
            If String.IsNullOrWhiteSpace(param) Then .ClearSelection()
        End With
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        If dgv_listbarang.SelectedRows.Count > 0 Then
            With dgv_listbarang.SelectedRows.Item(0)
                Select Case popupstate
                    Case "barang"
                        Dim validUid As String = ""
                        If .Cells(3).Value <= 0 Then
                            If MessageBox.Show("Barang " & .Cells(0).Value & " kosong/minus. Lanjutkan?", Me.Text,
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                                If Not TransConfirmValid(validUid) Then Exit Sub
                                'ADD LOG VALIDASI
                            Else : Exit Sub
                            End If
                        End If
                        in_barang.Text = .Cells(0).Value
                        in_barang_nm.Text = .Cells(1).Value
                        in_harga_retur.Value = .Cells(2).Value
                        loadSatuanBrg(in_barang.Text)
                        in_qty.Focus()
                    Case "supplier"
                        in_supplier.Text = .Cells(0).Value
                        in_supplier_n.Text = .Cells(1).Value
                        in_gudang_n.Focus()
                    Case "gudang"
                        in_gudang.Text = .Cells(0).Value
                        in_gudang_n.Text = .Cells(1).Value
                        cb_bayar_jenis.Focus()
                    Case "faktur"
                        in_no_faktur.Text = .Cells(0).Value
                        If formstate <> InputState.Insert And _prevjenisbayar.Key = 1 And _prevjenisbayar.Value = in_no_faktur.Text Then
                            jumlahhutang = .Cells(1).Value + _prevnilairetur
                        Else
                            jumlahhutang = .Cells(1).Value
                        End If
                        in_nilaihutang.Text = commaThousand(jumlahhutang)
                        in_barang.Focus()
                    Case Else
                        Exit Sub
                End Select
            End With
        End If
        'popPnl_barang.Visible = False
    End Sub

    'INPUT DATA TO DGV FR TEXTBOX
    Sub textToDgv()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Me.Cursor = Cursors.AppStarting

        Dim hpp As Decimal = 0
        Dim q As String = ""
        Dim _pajak As String = ""
        Dim _supplier As String = ""
        Dim _kode As String = in_barang.Text

        If Trim(in_barang.Text) = Nothing Then

            in_barang_nm.Focus() : Exit Sub
        End If
        If in_qty.Value = 0 Then
            in_qty.Focus()
            Exit Sub
        End If

        'GET DATA BARANG
        q = "SELECT barang_supplier, barang_pajak FROM data_barang_master WHERE barang_kode='{0}'"
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Using rdx = x.ReadCommand(String.Format(q, _kode), CommandBehavior.SingleRow)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _supplier = rdx.Item(0)
                        _pajak = rdx.Item(1)
                    End If
                End Using

                If in_supplier.Text <> _supplier Then
                    MessageBox.Show("Supplier barang berbeda dengan barang yang terpilih.", "Retur Pembelian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    in_barang_nm.Focus()
                    popPnl_barang.Visible = False
                    Exit Sub
                End If
                If (_pajak = 0 And cb_ppn.SelectedValue <> 0) Or (_pajak = 1 And {1, 2}.Contains(cb_ppn.SelectedValue) = False) Then
                    MessageBox.Show("Kategori barang tidak sesuai dengan kategori pajak faktur/nota beli", "Retur Pembelian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    in_barang_nm.Focus()
                    popPnl_barang.Visible = False
                    Exit Sub
                End If

                q = "SELECT getHppAvg_v2('{0}','{1}')"
                Dim ok = Decimal.TryParse(x.ExecScalar(String.Format(q, in_barang.Text, date_tgl_trans.Value.ToString("yyyy-MM-dd"))), hpp)
                If Not ok Then
                    MessageBox.Show("Terjadi kesalahan saat melakukan pengecekan data barang.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
        End Using

        dgv_barang.ClearSelection()
        With dgv_barang.Rows
            Dim x As Integer = .Add
            With .Item(x)
                .Cells("kode").Value = in_barang.Text
                .Cells("nama").Value = in_barang_nm.Text
                .Cells("nama").ToolTipText = in_barang.Text & "-" & in_barang_nm.Text
                .Cells("qty").Value = in_qty.Value
                .Cells("sat").Value = cb_sat.Text
                .Cells("sat_type").Value = cb_sat.SelectedValue
                .Cells("harga").Value = in_harga_retur.Value
                .Cells("subtot").Value = in_qty.Value * in_harga_retur.Value
                .Cells("diskon").Value = in_diskon.Value
                .Cells("jml").Value = removeCommaThousand(in_subtotal.Text)
                .Cells("brg_hpp").Value = hpp
                .Selected = True
            End With
        End With

        countBiaya()
        clearInputBarang()
        in_barang.Clear()
        in_barang.Select()

        Me.Cursor = Cursors.Default

        in_supplier_n.ReadOnly = True : in_supplier_n.BackColor = Color.Gainsboro
        cb_ppn.Enabled = False
    End Sub

    'GET DATA TO TEXTBOX FR DGV
    Private Sub dgvToTxt()
        Dim _idx As Integer = 0
        Dim red As Boolean = False

        With dgv_barang.SelectedRows.Item(0)
            _idx = .Index
            loadSatuanBrg(.Cells("kode").Value)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty.Value = .Cells("qty").Value
            _satuanstate = .Cells("sat_type").Value
            cb_sat.SelectedValue = .Cells("sat_type").Value
            in_diskon.Value = .Cells("diskon").Value
            in_harga_retur.Text = .Cells("harga").Value
        End With

        dgv_barang.Rows.RemoveAt(_idx)
        dgv_barang.ClearSelection()
        countBiaya()

        If dgv_barang.RowCount = 0 Then
            in_supplier_n.ReadOnly = False : in_supplier_n.BackColor = Color.White
            cb_ppn.Enabled = True
        End If
    End Sub

    'COUNT COST & VALUE
    Private Sub countBiaya()
        Dim subtot As Decimal = 0
        Dim pajak As Decimal = 0
        Dim netto As Decimal = 0
        For Each rows As DataGridViewRow In dgv_barang.Rows
            subtot += rows.Cells("jml").Value
        Next

        netto = subtot

        If cb_ppn.SelectedValue = "1" Then
            'incl
            pajak = subtot * (1 - 10 / 11)
        ElseIf cb_ppn.SelectedValue = "2" Then
            'excl
            pajak = subtot * 0.1 : netto = subtot + pajak
        Else
            pajak = 0
        End If

        in_jumlah.Text = commaThousand(subtot)
        in_netto.Text = commaThousand(netto)
        in_ppn_tot.Text = commaThousand(pajak)
    End Sub

    Private Sub clearTextBarang()
        in_harga_retur.Value = 0
        For Each x As TextBox In {in_barang, in_subtotal}
            x.Clear()
        Next
    End Sub

    Private Sub clearInputBarang()
        clearTextBarang()
        in_barang_nm.Clear()
        cb_sat.Text = ""
        cb_sat.DataSource = Nothing
        in_qty.Value = 0
        in_diskon.Value = 0
    End Sub

    'SAVE
    Private Function CheckInputedData(ByRef Msg As List(Of String)) As Boolean
        Dim retval As Boolean = True

        'If cb_bayar_jenis.SelectedValue = 1 Then
        '    Dim sisapiutang As Decimal = GetHutang(in_no_faktur.Text)
        '    If sisapiutang < removeCommaThousand(in_netto.Text) Then
        '        retval = False
        '        Msg.Add("Nilai retur lebih besar dari sisa hutang")
        '    End If
        'End If

        Dim invalid As Integer = 0
        For Each rows As DataGridViewRow In dgv_barang.Rows
            rows.DefaultCellStyle.BackColor = Color.White
            Dim kode As String = rows.Cells(0).Value
            Dim _stokaval As Integer = GetItemStock(kode, in_gudang.Text)
            Dim _stokInp As Integer = GetItemSmallQty(kode, rows.Cells("qty").Value, rows.Cells("sat_type").Value)
            If IsNothing(_stokaval) Then
                retval = False : invalid += 1 : rows.DefaultCellStyle.BackColor = Color.Yellow
                Msg.Add("Item " & rows.Cells("nama").Value & " Kode " & kode & " tidak ditemukan.")
            Else
                If formstate <> InputState.Insert Then _stokaval += _stokInp
                If _stokaval < _stokInp Then : rows.DefaultCellStyle.BackColor = Color.Yellow : invalid += 1 : End If
            End If
        Next
        If invalid > 0 Then
            retval = False
            Msg.Add("Beberapa item yg diretur melebihi jumlah stok tersedia")
        End If

        Return retval
    End Function

    Private Sub saveData()
        Dim q As String = ""
        Dim querycheck As Boolean = False
        Dim dataHead, dataBrg As String()
        Dim queryArr As New List(Of String)

        Dim _tgltrans As String = date_tgl_trans.Value.ToString("yyyy-MM-dd")

        '==========================================================================================================================
        'CHECK INPUTED DATA
        dgv_barang.ClearSelection()
        If {0, 1}.Contains(rtbStatus) Then
            Dim _invMsg As New List(Of String)
            If Not CheckInputedData(_invMsg) Then
                MessageBox.Show("Data yang diinput tidak sesuai." & Environment.NewLine & String.Join(Environment.NewLine, _invMsg), Me.Text,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If

        '==========================================================================================================================
        'SAVE HEADER
        dataHead = {
            "faktur_tanggal_trans='" & _tgltrans & "'",
            "faktur_pajak_no='" & in_pajak.Text & "'",
            "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
            "faktur_gudang='" & in_gudang.Text & "'",
            "faktur_supplier='" & in_supplier.Text & "'",
            "faktur_kode_faktur='" & in_no_faktur.Text & "'",
            "faktur_kode_exfaktur='" & in_no_faktur_ex.Text & "'",
            "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text).ToString.Replace(",", ".") & "'",
            "faktur_ppn='" & removeCommaThousand(in_ppn_tot.Text).ToString.Replace(",", ".") & "'",
            "faktur_ppn_jenis='" & cb_ppn.SelectedValue & "'",
            "faktur_netto='" & removeCommaThousand(in_netto.Text).ToString.Replace(",", ".") & "'",
            "faktur_jen_bayar='" & cb_bayar_jenis.SelectedValue & "'",
            "faktur_sebab='" & in_ket.Text & "'",
            "faktur_status='" & rtbStatus & "'"
            }

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                'START OF INSERT UPDATE HEADER ====================================================================================================
                If formstate = InputState.Insert Then
                    'START OF NEW TRANSACTION =====================================================================================================
                    If String.IsNullOrWhiteSpace(in_no_bukti.Text) Then
                        'START OF GENERATING NEW CODE =============================================================================================
                        Try
                            Dim i As Integer = 0 : Dim format As String = "D3"
                            q = "SELECT IFNULL(MAX(SUBSTRING(faktur_kode_bukti, 11)),0) FROM data_pembelian_retur_faktur " _
                                & "WHERE faktur_kode_bukti LIKE 'RB{0:yyyyMMdd}%' AND SUBSTRING(faktur_kode_bukti,11) REGEXP '^[0-9]+$'"
                            i = CInt(x.ExecScalar(String.Format(q, date_tgl_trans.Value)))
                            format = IIf(i + 1 > 999, "D" & (i + 1).ToString.Length, "D3")
                            in_no_bukti.Text = String.Format("RB{0:yyyyMMdd}", date_tgl_trans.Value) & (i + 1).ToString(format)

                            q = "INSERT INTO data_pembelian_retur_faktur SET faktur_kode_bukti='{0}',{1},faktur_reg_date=NOW(),faktur_reg_alias='{2}'"
                        Catch ex As Exception
                            MessageBox.Show("Terjadi kesalahan dalam melakukan proses penyimpanan data." & Environment.NewLine & ex.Message,
                                           Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            LogError(ex, True) : Exit Sub
                        End Try
                        'END OF GENERATING NEW CODE ===============================================================================================

                    Else
                        'START OF CHECKING USER INPUTED CODE ======================================================================================
                        Dim cAct As Integer = 0 : Dim cDel As Integer = 0
                        q = "SELECT COUNT(CASE WHEN faktur_status!=9 THEN 1 END) ActiveCode, COUNT(CASE WHEN faktur_status=9 THEN 1 END) DeleteCode " _
                                & "FROM data_pembelian_retur_faktur WHERE faktur_kode_bukti='{0}'"
                        Using rdx = x.ReadCommand(String.Format(q, in_no_bukti.Text), CommandBehavior.SingleRow)
                            Dim red = rdx.Read
                            If red And rdx.HasRows Then
                                cAct = rdx.Item(0) : cDel = rdx.Item(1)
                            Else
                                MessageBox.Show("Terjadi kesalahan dalam melakukan proses penyimpanan data." & Environment.NewLine & _
                                                "Pengecekan kode faktur gagal.",
                                                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                errLog(New List(Of String) From {"Error : Cant read. Mysql.",
                                                                 "Query : RETUR_BELI.CHECKING_INPUTED_CODE"
                                                                }) : Exit Sub
                            End If
                        End Using

                        If cAct = 1 Then 'WHEN THE CODE ALREADY TAKEN
                            MessageBox.Show("Nomor faktur " & in_no_bukti.Text & " sudah pernah diinputkan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            in_no_bukti.Focus() : Exit Sub
                        ElseIf cAct = 0 Then 'WHEN THE CODE IS AVAILABLE
                            q = "INSERT INTO data_pembelian_retur_faktur SET faktur_kode_bukti='{0}',{1},faktur_reg_date=NOW(),faktur_reg_alias='{2}'"
                        Else 'WHEN THERE IS DUPLICATION IN DATABASE ON THE CODE
                            MessageBox.Show("Terjadi kesalahan dalam melakukan proses penyimpanan data." & Environment.NewLine & _
                                            "Terdapat duplikasi kode pada database, kode faktur tidak dapat digunakan.",
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            errLog(New List(Of String) From {"Error : Duplicate primary code in database for sale transaction.",
                                                             "Duplicated Code : " & in_no_bukti.Text
                                                            }) : Exit Sub
                        End If
                        'END OF CHECKING USER INPUTED CODE ========================================================================================
                    End If
                    'END OF NEW TRANSACTION =======================================================================================================

                Else
                    q = "UPDATE data_pembelian_retur_faktur SET {1},faktur_upd_date=NOW(), faktur_upd_alias='{2}' WHERE faktur_kode_bukti='{0}' AND faktur_status<9"
                End If
                queryArr.Add(String.Format(q, in_no_bukti.Text, String.Join(",", dataHead), loggeduser.User_ID))
                'END OF INSERT UPDATE HEADER ======================================================================================================

                'START OF INSERT UPDATE BARANG ====================================================================================================
                q = "UPDATE data_pembelian_retur_trans SET trans_status=9 WHERE trans_faktur='{0}'"
                queryArr.Add(String.Format(q, in_no_bukti.Text))

                For Each rows As DataGridViewRow In dgv_barang.Rows
                    Dim _stock As String = in_gudang.Text & "-" & rows.Cells(0).Value & "-" & selectperiode.id
                    Dim _hpp As Decimal = 0
                    Dim _kdbrg As String = rows.Cells(0).Value

                    'GET HPP
                    q = "SELECT getHppAvg_v2('{0}','{1}')"
                    _hpp = Decimal.Parse(x.ExecScalar(String.Format(q, _kdbrg, _tgltrans)))

                    'INSERT DATA BARANG
                    dataBrg = {
                        "trans_barang='" & rows.Cells(0).Value & "'",
                        "trans_harga_retur='" & Decimal.Parse(rows.Cells("harga").Value).ToString.Replace(",", ".") & "'",
                        "trans_qty='" & rows.Cells("qty").Value & "'",
                        "trans_satuan='" & rows.Cells("sat").Value & "'",
                        "trans_diskon=" & Decimal.Parse(rows.Cells("diskon").Value).ToString.Replace(",", "."),
                        "trans_satuan_type='" & rows.Cells("sat_type").Value & "'",
                        "trans_hpp='" & _hpp.ToString.Replace(",", ".") & "'",
                        "trans_status='" & IIf({0, 1, 2}.Contains(rtbStatus), 1, rtbStatus) & "'"
                        }
                    q = "INSERT INTO data_pembelian_retur_trans SET trans_faktur= '{0}',{1} ON DUPLICATE KEY UPDATE {1}"
                    queryArr.Add(String.Format(q, in_no_bukti.Text, String.Join(",", dataBrg)))
                Next
                'END OF INSERT UPDATE BARANG ======================================================================================================

                '==========================================================================================================================
                q = "CALL transReturBeliFin('{0}','{1}')"
                queryArr.Add(String.Format(q, in_no_bukti.Text, loggeduser.User_ID))
                '==========================================================================================================================

                querycheck = x.TransactCommand(queryArr)
                If querycheck Then
                    MessageBox.Show("Data retur pembelian tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pgreturbeli, pgstok, pghutangawal}) : Me.Close()
                Else
                    MessageBox.Show("Data retur pembelian gagal tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Function CheckFakturPembelian(KodeFaktur As String) As Boolean
        If String.IsNullOrWhiteSpace(KodeFaktur) Then Return False

        Try
            Using x = MainConnection
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Dim q As String = ""
                    'CHECK AVALIABLITY
                    q = "SELECT COUNT(hutang_id) FROM data_hutang_awal WHERE hutang_faktur='{0}' AND hutang_status<9"
                    Dim _count As Integer = Integer.Parse(x.ExecScalar(String.Format(q, KodeFaktur)))

                    If _count = 1 Then
                        'IF EXIST
                        'CHECK AMOUNT
                        'q = "SELECT "

                        Return True
                    Else
                        'IF NOT EXIST
                        MessageBox.Show("Nomor faktur penjualan tidak dapat ditemukan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    End If
                Else
                    MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat melakukan pengecekan data retur penjualan." & Environment.NewLine & ex.Message,
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            LogError(ex, True)
            Return False
        End Try
    End Function

    'UI : FORM / DRAG
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles pnl_header.MouseDown, lbl_title.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles pnl_header.MouseMove, lbl_title.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles pnl_header.MouseUp, lbl_title.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles pnl_header.DoubleClick, lbl_title.DoubleClick
        CenterToScreen()
    End Sub

    'UI : FORM
    Private Sub fr_beli_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            Else
                bt_batalreturbeli.PerformClick()
            End If
            e.SuppressKeyPress = True
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            bt_simpanreturbeli.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    'UI : BUTTON
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalreturbeli.Click
        bt_cl.PerformClick()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.Close()
    End Sub

    Private Sub bt_simpanreturbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanreturbeli.Click
        'CHECK TANGGAL TRANSAKSI
        If date_tgl_trans.Value < TransStartDate Then
            MessageBox.Show("Tanggal transaksi tidak boleh kurang dari periode aktif." & TransStartDate.ToString("(MMMM yyyy)"),
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            date_tgl_trans.Focus() : Exit Sub
        End If

        'CHECK INPUT DATA
        For Each x As TextBox In {in_supplier, in_gudang}
            Dim Msg As String = "{0} belum diinput"
            Dim _input As TextBox
            Select Case x.Name
                Case in_supplier.Name : Msg = String.Format(Msg, "Supplier") : _input = in_supplier_n
                Case in_gudang.Name : Msg = String.Format(Msg, "Gudang") : _input = in_gudang_n
                Case Else : Exit Sub
            End Select

            If String.IsNullOrWhiteSpace(x.Text) Then
                MessageBox.Show(Msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                _input.Focus() : Exit Sub
            End If
        Next

        'CHECK BARANG
        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang yang akan diretur belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_barang.Focus() : Exit Sub
        End If

        'CHECK JENIS PEMBAYARAN
        If cb_bayar_jenis.SelectedValue = 1 And String.IsNullOrWhiteSpace(in_no_faktur.Text) Then
            MessageBox.Show("Nomor faktur pembelian untuk pemotongan nota belum di input.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_no_faktur.Focus() : Exit Sub
        ElseIf cb_bayar_jenis.SelectedValue = 1 And in_no_faktur.Text <> Nothing Then
            'CHECK FAKTUR PIUTANG
            If Not CheckFakturPembelian(in_no_faktur.Text) Then Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim _askRes As DialogResult = Windows.Forms.DialogResult.Yes
        If Not formstate = InputState.Insert Then _askRes = MessageBox.Show("Simpan perubahan data retur?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _askRes = Windows.Forms.DialogResult.Yes Then saveData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_menu.Click
        Dim _x As Integer = sender.Location.X
        Dim _y As Integer = sender.Location.Y + sender.Height
        ctx_main.Show(pnl_header, _x, _y)
    End Sub

    'UI : CONTEXT MENU
    Private Sub tstrip_simpan_Click(sender As Object, e As EventArgs) Handles tstrip_simpan.Click
        bt_simpanreturbeli.PerformClick()
    End Sub

    Private Sub tsrtip_close_Click(sender As Object, e As EventArgs) Handles tsrtip_close.Click
        bt_cl.PerformClick()
    End Sub

    Private Sub tstrip_print_Click(sender As Object, e As EventArgs) Handles tstrip_print.Click
        Me.Cursor = Cursors.WaitCursor
        Using nota As New fr_nota_dialog
            nota.do_load("returbeli", in_no_bukti.Text)
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tstrip_activate_Click(sender As Object, e As EventArgs) Handles tstrip_activate.Click
        If rtbStatus = 1 Then
            MessageBox.Show("Status transaksi retur pembelian sudah aktif.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub tstrip_inactivate_Click(sender As Object, e As EventArgs) Handles tstrip_inactivate.Click
        If rtbStatus = 2 Then
            MessageBox.Show("Transaksi retur pembelian sudah terbatalkan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub tstrip_delete_Click(sender As Object, e As EventArgs) Handles tstrip_delete.Click

    End Sub

    Private Sub tstrip_new_barang_Click(sender As Object, e As EventArgs) Handles tstrip_new_barang.Click
        Dim brg As New fr_barang_detail
        brg.doLoadNew()
    End Sub

    Private Sub tstrip_new_gudang_Click(sender As Object, e As EventArgs) Handles tstrip_new_gudang.Click
        Dim gdg As New fr_gudang_detail
        gdg.doLoadNew()
    End Sub

    'UI : POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_supplier_n.Focused Or in_gudang_n.Focused Or in_barang_nm.Focused Or in_no_faktur.Focused Then
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
            Case "supplier" : x = in_supplier_n
            Case "gudang" : x = in_gudang_n
            Case "barang" : x = in_barang_nm
            Case "faktur" : x = in_no_faktur
            Case Else : Exit Sub
        End Select
        PopUpSearchKeyPress(e, x)
    End Sub

    'UI : NUMERIC INPUT
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_harga_retur.Enter, in_diskon.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_harga_retur.Leave, in_diskon.Leave
        Select Case sender.Name.ToString
            Case "in_qty"
                numericLostFocus(sender, "N0")
            Case Else
                numericLostFocus(sender)
        End Select
    End Sub

    'UI : COMBOBOX
    Private Sub cb_bayar_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_bayar_jenis.KeyPress, cb_sat.KeyPress, cb_ppn.KeyPress
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    Private Sub cb_bayar_jenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_bayar_jenis.SelectionChangeCommitted
        For Each x As TextBox In {in_no_faktur, in_nilaihutang}
            x.Enabled = IIf(cb_bayar_jenis.SelectedValue = 1, True, False)
            x.Text = IIf(cb_bayar_jenis.SelectedValue = 1, x.Text, "")
            jumlahhutang = IIf(cb_bayar_jenis.SelectedValue = 1, jumlahhutang, 0)
        Next
    End Sub

    Private Sub cb_ppn_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_ppn.SelectionChangeCommitted
        countBiaya()
    End Sub

    'UI : HEADER
    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_supplier_n.Enter, in_gudang_n.Enter, in_no_faktur.Enter, in_barang_nm.Enter
        If sender.ReadOnly = False And sender.Enabled = True Then
            If sender.name = in_no_faktur.Name Then
                popPnl_barang.Location = New Point(sender.Left - (popPnl_barang.Width - sender.Width), sender.Top + sender.Height)
            Else
                popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
            End If
            If popPnl_barang.Visible = False Then popPnl_barang.Visible = True

            Select Case sender.Name
                Case "in_supplier_n" : popupstate = "supplier"
                Case "in_gudang_n" : popupstate = "gudang"
                Case "in_no_faktur" : popupstate = "faktur"
                Case "in_barang_nm" : popupstate = "barang"
                Case Else : Exit Sub
            End Select
            loadDataBRGPopup(popupstate, sender.Text)
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_supplier_n.Leave, in_gudang_n.Leave, in_barang_nm.Leave, in_no_faktur.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_s_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyDown, in_gudang_n.KeyDown, in_no_faktur.KeyDown, in_barang_nm.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then e.SuppressKeyPress = True
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyUp, in_gudang_n.KeyUp, in_no_faktur.KeyUp, in_barang_nm.KeyUp
        Dim _next As Control : Dim _id As TextBox
        Select Case sender.Name.ToString
            Case "in_supplier_n" : _next = in_gudang_n : _id = in_supplier
            Case "in_gudang_n" : _next = cb_bayar_jenis : _id = in_gudang
            Case "in_no_faktur" : _next = in_barang_nm : _id = in_nilaihutang
            Case "in_barang_nm" : _next = in_qty : _id = in_barang
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

    'UI :INPUT BARANG
    Private Sub in_harga_retur_ValueChanged(sender As Object, e As EventArgs) Handles in_harga_retur.ValueChanged, in_qty.ValueChanged, in_diskon.ValueChanged
        in_subtotal.Text = commaThousand(countSubtot(in_harga_retur.Value, in_qty.Value, in_diskon.Value))
    End Sub

    Private Sub cb_sat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_sat.SelectionChangeCommitted
        in_harga_retur.Value = CountItemPrice(_satuanstate, cb_sat.SelectedValue, in_harga_retur.Value, isibesar, isitengah)
        _satuanstate = cb_sat.SelectedValue
    End Sub

    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        If String.IsNullOrEmpty(in_barang.Text) Then
            MessageBox.Show("Barang tidak ditemukan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_barang_nm.Focus() : Exit Sub
        End If
        If in_qty.Value = 0 Then
            MessageBox.Show("Masukan jumlah barang terlebih dahulu.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_qty.Focus()
            Exit Sub
        End If

        textToDgv()
    End Sub

    'DGV
    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If loggeduser.AllowEdit_Transact = True And rtbStatus < 2 Then
            If e.RowIndex < 0 Then
                indexrow = 0
            Else
                indexrow = e.RowIndex
                dgvToTxt()
            End If
        End If
    End Sub
End Class