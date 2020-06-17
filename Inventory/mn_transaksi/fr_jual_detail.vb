Public Class fr_jual_detail
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

        With cb_ppn
            .DataSource = jenis("jenis_ppn")
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedValue = 1
        End With

        'With date_tgl_beli
        '    .Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        '    .MaxDate = selectperiode.tglakhir
        '    .MinDate = selectperiode.tglawal
        'End With
        'date_tgl_pajak.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        For Each x As DateTimePicker In {date_tgl_beli, date_tgl_pajak}
            x.Value = IIf(DataListEndDate > Today, Today, DataListEndDate)
            x.MinDate = If(formstate = InputState.Insert, TransStartDate, DataListStartDate)
            x.MaxDate = DataListEndDate
        Next

        If Not FormSet = InputState.Insert Then
            Dim _resp = loadDataFaktur(NoFaktur)
            If Not _resp.Key Then
                MessageBox.Show(_resp.Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
            End If
            If Not {0, 1}.Contains(tjlStatus) Or date_tgl_beli.Value < TransStartDate Then formstate = InputState.View
        End If

        If formstate = InputState.View Then AllowEdit = False
        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        If formstate <> InputState.Insert Then
            in_faktur.ReadOnly = True : in_faktur.BackColor = Color.Gainsboro
            tstrip_print.Enabled = If(tjlStatus = 1, True, False)
            tstrip_status.Enabled = If(date_tgl_beli.Value < TransStartDate, False, True)
            bt_simpanjual.Text = "Update"
        Else
            tstrip_print.Enabled = False
            tstrip_status.Enabled = False
        End If
        For Each txt As TextBox In {in_pajak, in_custo_n, in_ket, in_barang_nm, in_sales_n}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        For Each numin As NumericUpDown In {in_term, in_bayar, in_harga_beli, in_disc1, in_disc2, in_disc3, in_disc4, in_disc5, in_discrp}
            numin.Enabled = AllowInput
            If AllowInput Then
                AddHandler numin.Enter, AddressOf in_qty_Enter
                AddHandler numin.Leave, AddressOf in_qty_Leave
            End If
        Next
        For Each dtpick As DateTimePicker In {date_tgl_beli, date_tgl_pajak}
            dtpick.Enabled = AllowInput
        Next
        For Each x As Control In {in_qty, cb_sat, in_harga_beli, in_disc1, in_disc2, in_disc3, in_disc4, in_disc5, in_discrp, bt_tbbarang}
            x.Visible = AllowInput
            If x.GetType = GetType(NumericUpDown) Then AddHandler DirectCast(x, NumericUpDown).ValueChanged, AddressOf in_harga_beli_ValueChanged
        Next

        bt_simpanjual.Enabled = AllowInput
        tstrip_simpan.Enabled = bt_simpanjual.Enabled
        tstrip_new_custo.Enabled = IIf(main.listkodemenu.Contains("mn0105"), AllowInput, False)

        If Not formstate = InputState.Insert Then
            Dim rowcount = dgv_barang.RowCount
            cb_ppn.Enabled = IIf(rowcount > 0, False, True)
        Else
            cb_ppn.Enabled = AllowInput
        End If

        For Each x As DataGridViewColumn In {harga, discrp, jml, subtotal, disc1, disc2, disc3, disc4, disc5}
            x.DefaultCellStyle = dgvstyle_currency
        Next

        If AllowInput Then
            dgv_barang.Location = New Point(12, 201) : dgv_barang.Height = 207
            AddHandler dgv_barang.CellDoubleClick, AddressOf dgv_barang_CellDoubleClick
        Else
            dgv_barang.Location = New Point(12, 154) : dgv_barang.Height = 254
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

    Private Sub fr_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 100
        dgv_barang.ClearSelection()
    End Sub

    'LOAD DATA
    Private Function loadDataFaktur(faktur As String) As KeyValuePair(Of Boolean, String)
        If MainConnData.IsEmpty Then Return New KeyValuePair(Of Boolean, String)(False, "Main DB Configuration is empty.")

        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    'LOAD HEADER
                    Using rdx = x.ReadCommand(String.Format("CALL getTransHeader('JUAL','{0}')", faktur))
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

                            in_bayar.Value = rdx.Item("faktur_bayar")
                            tjlStatus = rdx.Item("faktur_status")

                        End If
                    End Using

                    'LOAD TABLE/ITEM
                    Dim q As String = "SELECT trans_barang, barang_nama, trans_harga_jual, trans_qty, trans_satuan, " _
                                      & "trans_disc1, trans_disc2, trans_disc3, trans_disc4, trans_disc5, " _
                                      & "trans_disc_rupiah, trans_jumlah, trans_satuan_type, trans_hpp " _
                                      & "FROM data_penjualan_trans INNER JOIN data_barang_master ON barang_kode = trans_barang " _
                                      & "WHERE trans_faktur='" & faktur & "' AND trans_status=1"
                    Using dt As DataTable = x.GetDataTable(String.Format(q, kode))
                        setDoubleBuffered(dgv_barang, True)
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
                            countBiaya()
                        End With
                    End Using
                    in_gudang_n.ReadOnly = True : cb_ppn.Enabled = False
                    Select Case tjlStatus
                        Case 0 : in_status.Text = "Pending"
                        Case 1 : in_status.Text = "Aktif"
                        Case 2 : in_status.Text = "Batal"
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

        Return Math.Round(retHarga, 2)
    End Function

    'LOAD DATA TO DGV POPUP PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        setDoubleBuffered(Me.dgv_listbarang, True)
        Dim q As String : Dim dt As New DataTable
        in_alamat_c.Visible = False : popPnl_barang.Height = 135

        Select Case tipe
            Case "barang"
                Dim _pajak As String = IIf(cb_ppn.SelectedValue = 0, 0, 1)
                If String.IsNullOrWhiteSpace(in_sales.Text) Then
                    q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama' FROM data_barang_master " _
                        & "WHERE (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%') AND barang_pajak='{1}' LIMIT 250"
                    q = String.Format(q, "{0}", _pajak)

                Else
                    Dim _sales = in_sales.Text : Dim _barangCt As Integer = 0
                    Using x = MainConnection
                        x.Open() : If x.ConnectionState = ConnectionState.Open Then
                            q = "SELECT COUNT(sb_id) FROM data_salesman_barang WHERE sb_status=1 AND sb_kode_sales='{0}'"
                            _barangCt = Integer.Parse(x.ExecScalar(String.Format(q, _sales)))

                            If _barangCt = 0 Then
                                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama' FROM data_barang_master " _
                                    & "WHERE (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%') AND barang_pajak='{1}' LIMIT 250"
                                q = String.Format(q, "{0}", _pajak)

                            Else
                                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama' FROM data_barang_master " _
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
                    & "customer_priority, customer_max_piutang, getPiutangSisaCusto(customer_kode), " _
                    & "TRIM(BOTH ', ' FROM CONCAT_WS(', ',customer_alamat,customer_kecamatan,customer_kabupaten)) 'Alamat' " _
                    & "FROM data_customer_master WHERE customer_status=1 AND (customer_nama LIKE '%{0}%' OR customer_kode LIKE '%{0}%') LIMIT 250"

            Case "gudang"
                If String.IsNullOrWhiteSpace(in_sales.Text) Then
                    q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang " _
                        & "WHERE gudang_status=1 AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%')"

                Else
                    Dim _sales = in_sales.Text : Dim _gudangCt As Integer = 0
                    Using x = MainConnection
                        x.Open() : If x.ConnectionState = ConnectionState.Open Then
                            q = "SELECT COUNT(sg_id) FROM data_salesman_gudang WHERE sg_status=1 AND sg_kode_sales='{0}'"
                            _gudangCt = Integer.Parse(x.ExecScalar(String.Format(q, _sales)))

                            If _gudangCt = 0 Then
                                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang " _
                                    & "WHERE gudang_status=1 AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%')"

                            Else
                                q = "SELECT gudang_kode Kode, gudang_nama Nama FROM data_barang_gudang " _
                                    & "WHERE gudang_kode IN (SELECT sg_kode_gudang FROM data_salesman_gudang WHERE sg_kode_sales='{1}' AND sg_status=1) " _
                                    & " AND gudang_status=1 AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%')"
                                q = String.Format(q, "{0}", _sales)

                            End If
                        Else
                            Exit Sub
                        End If
                    End Using
                End If

            Case "sales"
                q = "SELECT salesman_kode AS 'Kode', salesman_nama AS 'Nama', IFNULL(ref_text,'ERROR') Jenis " _
                    & "FROM data_salesman_master " _
                    & "LEFT JOIN ref_jenis ON salesman_jenis=ref_kode AND ref_status=1 AND ref_type='sales_jenis' " _
                    & "WHERE salesman_status=1 AND (salesman_nama LIKE '%{0}%' OR salesman_kode LIKE '%{0}%')"

            Case Else
                Exit Sub
        End Select

        Me.Cursor = Cursors.WaitCursor
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                consoleWriteLine(q)
                dt = x.GetDataTable(String.Format(q, param))
            Else
                Exit Sub
            End If
        End Using
        Me.Cursor = Cursors.Default

        With dgv_listbarang
            .DataSource = dt
            If .ColumnCount >= 2 Then
                .Columns(0).Width = 100 : .Columns(1).Width = 150
                If tipe = "custo" Then
                    For i = 2 To 6 : .Columns(i).Visible = False : Next
                ElseIf tipe = "barang" Then
                    .Columns(1).Width = 200
                End If
                .Columns(.ColumnCount - 1).AutoSizeMode = IIf(.DisplayedColumnCount(False) <= 3, DataGridViewAutoSizeColumnMode.Fill, DataGridViewAutoSizeColumnMode.NotSet)
            End If
            If String.IsNullOrWhiteSpace(param) Then .ClearSelection()
        End With
    End Sub

    'OPEN SEARCH WINDOW
    Private Sub doSearch()

    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult(ResType As String)
        If dgv_listbarang.SelectedRows.Count > 0 Then
            With dgv_listbarang.SelectedRows.Item(0)
                Select Case ResType
                    Case "barang"
                        Dim _qty = GetItemStock(.Cells(0).Value, in_gudang.Text)
                        If _qty <= 0 Then
                            Dim _Msg = String.Format("Stok {0} kosong/minus. Lanjutkan?" & Environment.NewLine & "Stok tersedia {1} : {2}",
                                                     .Cells(0).Value, If(String.IsNullOrWhiteSpace(in_gudang.Text), "", "di gudang " & in_gudang.Text), _qty)
                            If MessageBox.Show(_Msg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                                If Not TransConfirmValid("") Then Exit Sub
                            Else
                                Exit Sub
                            End If
                        End If

                        in_barang.Text = .Cells(0).Value
                        in_barang_nm.Text = .Cells(1).Value
                        loadSatuanBrg(in_barang.Text)
                        in_harga_beli.Value = getHargaBarang(in_barang.Text, jeniscusto)
                        in_qty.Focus()

                    Case "custo"
                        in_custo.Text = .Cells(0).Value
                        in_custo_n.Text = .Cells(1).Value
                        jeniscusto = .Cells(3).Value
                        in_term.Value = If(.Cells(2).Value = 0, 12, .Cells(2).Value)
                        maxpiutang = .Cells(4).Value
                        jumlahpiutang = .Cells(5).Value - IIf(formstate = InputState.Insert, 0, removeCommaThousand(in_netto.Text))
                        in_custo_al.Text = Strings.Replace(.Cells(7).Value, Environment.NewLine, " ")
                        in_sales_n.Focus()

                    Case "sales"
                        in_sales.Text = .Cells(0).Value
                        in_sales_n.Text = .Cells(1).Value
                        in_gudang_n.Focus()

                    Case "gudang"
                        in_gudang.Text = .Cells(0).Value
                        in_gudang_n.Text = .Cells(1).Value
                        cb_ppn.Focus()

                    Case Else
                        Exit Sub
                End Select
            End With
        End If
        'popPnl_barang.Visible = False
    End Sub

    'INPUT DATA TO DGV FR TEXTBOX
    Private Sub txtToDgv()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        in_barang.Text = Trim(in_barang.Text)
        If in_barang_nm.Text = Nothing Then
            in_barang.Focus() : Exit Sub
        End If
        If in_qty.Value = 0 Then
            in_qty.Focus() : Exit Sub
        End If

        Dim pajak_tot As Decimal = 0
        Dim hpp As Decimal = 0
        Dim _pajak As String = ""
        Dim q As String = ""

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Try
                    q = "SELECT barang_pajak FROM data_barang_master WHERE barang_kode='{0}'"
                    _pajak = Integer.Parse(x.ExecScalar(String.Format(q, in_barang.Text)))
                Catch ex As Exception
                    MessageBox.Show("Trejadi kesalahan saat melakukan pengecekan barang.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    logError(ex, True) : Exit Sub
                End Try

                If (_pajak = 0 And cb_ppn.SelectedValue <> 0) Or (_pajak = 1 And {1, 2}.Contains(cb_ppn.SelectedValue) = False) Then
                    MessageBox.Show("Kategori barang tidak sesuai dengan kategori pajak faktur/nota beli", "Penjualan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    in_barang_nm.Focus() : popPnl_barang.Visible = False
                    Exit Sub
                End If

                q = "SELECT getHppAvg_v2('{0}','{1}')"
                Using rdx = x.ReadCommand(String.Format(q, in_barang.Text, date_tgl_beli.Value.ToString("yyyy-MM-dd")))
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

        dgv_barang.ClearSelection()
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
                .Cells("jml").Value = removeCommaThousand(in_subtotal.Text)
                .Cells("brg_hpp").Value = hpp
                .Selected = True
            End With
        End With

        countBiaya()
        clearInputBarang()
        in_barang_nm.Clear()
        in_barang.Focus()

        cb_ppn.Enabled = False
        'in_gudang_n.ReadOnly = True
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
            in_disc1.Value = .Cells("disc1").Value
            in_disc2.Value = .Cells("disc2").Value
            in_disc3.Value = .Cells("disc3").Value
            in_disc4.Value = .Cells("disc4").Value
            in_disc5.Value = .Cells("disc5").Value
            in_discrp.Value = .Cells("discrp").Value
        End With

        dgv_barang.Rows.RemoveAt(_idx)
        dgv_barang.ClearSelection()
        countBiaya()
        in_qty.Focus()

        If dgv_barang.RowCount = 0 Then
            cb_ppn.Enabled = True
            'in_gudang_n.ReadOnly = False
        End If
    End Sub

    'COUNT COST & VALUE
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
            pajak = netto * 0.1 : netto += pajak
        ElseIf cb_ppn.SelectedValue = 1 Then
            pajak = (subtotal * (1 - 10 / 11)) - (diskon * (1 - 10 / 11))
        Else
            pajak = 0
        End If

        in_jumlah.Text = commaThousand(subtotal)
        in_diskon.Text = commaThousand(diskon)
        in_ppn_tot.Text = commaThousand(pajak)
        in_total.Text = commaThousand(subtotal - diskon)
        in_netto.Text = commaThousand(netto)
        in_sisa.Text = commaThousand(netto - in_bayar.Value)
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
                If formstate = InputState.Insert Then
                    'START OF NEW TRANSACTION =====================================================================================================
                    If in_faktur.Text = Nothing Then
                        'START OF GENERATING NEW CODE =============================================================================================
                        Try
                            Dim i As Integer = 0 : Dim format As String = "D3"
                            q = "SELECT IFNULL(MAX(SUBSTRING(faktur_kode, 11)),0) FROM data_penjualan_faktur " _
                                & "WHERE faktur_kode LIKE 'SO{0:yyyyMMdd}%' AND SUBSTRING(faktur_kode,11) REGEXP '^[0-9]+$'"
                            i = CInt(x.ExecScalar(String.Format(q, date_tgl_beli.Value)))
                            format = IIf(i + 1 > 999, "D" & (i + 1).ToString.Length, "D3")
                            in_faktur.Text = String.Format("SO{0:yyyyMMdd}", date_tgl_beli.Value) & (i + 1).ToString(format)

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
                        ElseIf cDel = 1 And cAct = 0 Then 'WHEN THE CODE IS ALREADY TAKEN BUT THE TRASACTION STATE IS 'DELETE'
                            q = "UPDATE data_penjualan_faktur SET {1}, faktur_reg_date=NOW(), faktur_reg_alias='{2}', " _
                                & "faktur_upd_date=NULL, faktur_upd_alias=NULL WHERE faktur_kode='{0}'"
                        Else 'WHEN THERE IS DUPLICATION IN DATABASE ON THE CODE
                            MessageBox.Show("Terjadi kesalahan dalam melakukan proses penyimpanan data." & Environment.NewLine & _
                                            "Terdapat duplikasi kode pada database, kode faktur tidak dapat digunakan.",
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            errLog(New List(Of String) From {"Error : Duplicate primary code in database for sale transaction.",
                                                             "Duplicated Code : " & in_faktur.Text
                                                            }) : Exit Sub
                        End If
                        'END OF CHECKING USER INPUTED CODE ========================================================================================
                    End If
                    'END OF NEW TRANSACTION =======================================================================================================

                Else
                    q = "UPDATE data_penjualan_faktur SET {1},faktur_upd_date=NOW(), faktur_upd_alias='{2}' WHERE faktur_kode='{0}' AND faktur_status<9"
                End If
                queryArr.Add(String.Format(q, in_faktur.Text, String.Join(",", dataHead), loggeduser.user_id))
                'END OF INSERT UPDATE HEADER ======================================================================================================

                'START OF INSERT UPDATE BARANG ====================================================================================================
                q = "UPDATE data_penjualan_trans SET trans_status=9 WHERE trans_faktur='{0}'"
                queryArr.Add(String.Format(q, in_faktur.Text))

                Dim _ckbarang As Boolean = True
                Dim _brg As New List(Of String)
                For Each rows As DataGridViewRow In dgv_barang.Rows
                    Dim _hpp As Decimal = 0
                    Dim _kdbrg As String = rows.Cells(0).Value

                    'GET HPP
                    _qGet = "SELECT getHppAvg_v2('{0}','{1}')"
                    _hpp = CDec(x.ExecScalar(String.Format(_qGet, _kdbrg, _tgltrans)))

                    dataBrg = {
                       "trans_barang='" & _kdbrg & "'",
                       "trans_harga_jual='" & Decimal.Parse(rows.Cells("harga").Value).ToString.Replace(",", ".") & "'",
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
                q = "UPDATE data_penjualan_order_faktur SET j_order_ref_faktur='{0}', j_order_upd_date=NOW(), j_order_upd_alias='{2}' WHERE j_order_kode='{1}'"
                If refOrderJual <> Nothing Then
                    queryArr.Add(String.Format(q, in_faktur.Text, refOrderJual, loggeduser.user_id))
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
            MessageBox.Show("Data tidak dapat tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            MessageBox.Show("Data tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            doRefreshTab({pgpenjualan})
            If Not String.IsNullOrWhiteSpace(refOrderJual) Then doRefreshTab({pgpesanjual})
            Me.Close()
        End If
    End Sub

    Private Function CheckPenjualan() As Boolean
        Dim RetVal As Boolean = False
        Dim ValidUid As String = ""

        'CEK DATA CUSTO KETIKA INSERT BARU
        getDataCustomer(in_custo.Text)

        'CEK PRIORITAS CUSTO
        If custo_priority = False Then
            'CEK PIUTANG CUSTOMER
            If jumlahpiutang > 0 Then
                MessageBox.Show("Customer masih memiliki piutang yang belum dilunasi, transaksi penjualan tidak dapat dilakukan.",
                                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                RetVal = TransConfirmValid(ValidUid)
            Else
                RetVal = True
            End If
        Else
            'CEK PIUTANG CUSTOMER
            If jumlahpiutang > 0 Then
                If MessageBox.Show("Customer masih memiliki piutang yang belum dilunasi, lanjutkan transaksi penjualan?",
                                   Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    RetVal = TransConfirmValid(ValidUid)
                End If
            Else
                RetVal = True
            End If
        End If

        Using x = MainConnection
            'ADD LOG VALIDASI
        End Using

        Return RetVal
    End Function

    Private Function CheckPiutang() As Boolean
        'DATA YANG DIBUTUHKAN : NILAI PIUTANG TERSIMPAN SEBELUM UPDATE, NILAI YG SUDAH TERBAYAR, STATUS LUNAS, TANGGAL PEMBAYARAN PIUTANG PALING AWAL
        If Not formstate = InputState.Insert Then
            Try
                Using x = MainConnection
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        Dim _q As String = ""
                        _q = "SELECT COUNT(piutang_id) FROM data_piutang_awal WHERE piutang_faktur='{0}' AND piutang_status<9"

                        Dim _count = Integer.Parse(x.ExecScalar(String.Format(_q, in_faktur.Text)))
                        If _count = 1 Then
                            'IF EXIST
                            Dim _oldpiutang As Decimal = 0 : Dim _sisapiutang As Decimal = 0
                            'CHECK STATUS LUNAS, SALDO PIUTANG, SISA PIUTANG
                            _q = "SELECT piutang_awal, GetPiutangSaldoAwal('piutang', piutang_faktur, ADDDATE(CURDATE(), 1)) " _
                                & "FROM data_piutang_awal WHERE piutang_faktur='{0}'"
                            Using rdx = x.ReadCommand(String.Format(_q, in_faktur.Text))
                                Dim red = rdx.Read
                                If red And rdx.HasRows Then
                                    _oldpiutang = Decimal.Parse(rdx.Item(0))
                                    _sisapiutang = Decimal.Parse(rdx.Item(1))
                                Else
                                    MessageBox.Show("Terjadi kesalahan saat melakukan pengecekan data." & Environment.NewLine & "Data piutang tidak dapat ditemukan",
                                                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Return False
                                End If
                            End Using

                            If _oldpiutang <> _sisapiutang Then
                                Dim _minDate As Date = date_tgl_beli.Value
                                _q = "SELECT COUNT(p_trans_id), MIN(p_trans_tgl) FROM data_piutang_trans " _
                                    & "WHERE p_trans_kode_piutang='{0}' AND p_trans_jenis='bayar' AND p_trans_status=1"

                                Using rdx = x.ReadCommand(String.Format(_q, in_faktur.Text))
                                    Dim red = rdx.Read
                                    If red And rdx.HasRows Then
                                        _count = rdx.Item(0)
                                        If _count > 0 Then _minDate = rdx.Item(1)
                                    Else
                                        MessageBox.Show("Terjadi kesalahan saat melakukan pengecekan data." & Environment.NewLine & "Data piutang tidak dapat ditemukan",
                                                        Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Return False
                                    End If
                                End Using

                                If _count > 0 And date_tgl_beli.Value > _minDate Then
                                    MessageBox.Show("Pembayaran piutang untuk faktur penjualan sudah diinput untuk tanggal " & _minDate.ToString("dd MMMM yyyy.") & _
                                                    Environment.NewLine & "Tanggal penjualan tidak dapat lebih besar dari tanggal pembayaran, silahkan cek kembali.",
                                                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    date_tgl_beli.Focus() : Return False
                                End If
                            End If

                            Dim _newPiutang = removeCommaThousand(in_sisa.Text)
                            If _newPiutang > _oldpiutang Then
                                Return True
                            Else
                                If _sisapiutang < _newPiutang Then
                                    MessageBox.Show("Nilai piutang penjualan yang akan diinputkan lebih kecil dari pembayaran yang telah diinputkan." & _
                                                    Environment.NewLine & "Harap cek kembali nilai pembayaran yang telah diinput.", Me.Text,
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Return False
                                Else
                                    Return True
                                End If
                            End If

                        ElseIf _count = 0 Then
                            Return True
                        Else
                            'IF DUPLICATE
                            MessageBox.Show("Terjadi kesalahan saat pelakukan pengecekan data penjualan." & Environment.NewLine & _
                                            "Terdapat duplikasi kode pada database, kode faktur tidak dapat digunakan.",
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            errLog(New List(Of String) From {"Error : Duplicate faktur kode pada table piutang awal.",
                                                             "Duplicated Code : " & in_faktur.Text
                                                            })
                            Return False
                        End If
                    Else
                        MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Terjadi kesalahan saat melakukan pengecekan data penjualan." & Environment.NewLine & ex.Message,
                                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                logError(ex, True)
                Return False
            End Try
        Else
            Return True
        End If
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
                        If Not _kodeBrg.Contains(row.Cells(0).Value) Then
                            _kodeBrg.Add(row.Cells(0).Value)
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

    'CANCEL
    Private Sub changeTransactState(TransState As Integer)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If
        If String.IsNullOrWhiteSpace(in_faktur.Text) Then Exit Sub

        Dim ValidUid As String = ""
        Dim q As String = "" : Dim qArr As New List(Of String)
        If Not TransConfirmValid(ValidUid) Then Exit Sub

        Dim _failmsg, _succmsg As String
        If {0, 1}.Contains(TransState) Then
            _failmsg = "Cancel pembatalan gagal." : _succmsg = "Cancel pembatalan berhasil."
        ElseIf TransState = 2 Then
            _failmsg = "Pembatalan transaksi gagal." : _succmsg = "Pembatalan transaksi berhasil."
        ElseIf TransState = 9 Then
            _failmsg = "Transaksi tidak dapat dihapus." : _succmsg = "Transaksi berhasil dihapus."
        Else : Exit Sub
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                q = "UPDATE data_penjualan_faktur SET faktur_status={2}, faktur_upd_date=NOW(), faktur_upd_alias='{1}' WHERE faktur_kode='{0}'"
                qArr.Add(String.Format(in_faktur.Text, ValidUid, TransState))
                If TransState = 9 Then
                    q = "UPDATE data_penjualan_trans SET trans_status=9 WHERE trans_faktur='{0}' AND trans_status=1"
                    qArr.Add(String.Format(in_faktur.Text))
                End If
                'ADD LOG VALIDASI
                Dim ckQuery = x.TransactCommand(qArr)
                If ckQuery Then
                    MessageBox.Show(_succmsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pgpenjualan, pgpiutangawal}) : Me.Close()
                Else
                    MessageBox.Show(_failmsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End Using
    End Sub

    'CHANGE CODE
    Private Sub ChangeCode()
        Dim _ck As Boolean = False
        Dim _newcode As String = ""

        Using x = New fr_changecode
            x.do_load(in_faktur.Text, "transaksi", "jual")
            _ck = x.RetVal.Key
            _newcode = x.RetVal.Value
        End Using

        If _ck Then
            Me.Cursor = Cursors.WaitCursor
            Dim fk As New fr_jual_detail
            DoRefreshTab_v2({pgpenjualan, pgpiutangawal})
            fk.Hide() : fk.doLoadEdit(_newcode, loggeduser.allowedit_transact) : fk.Show()
            Me.Close()
        End If
    End Sub

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
                bt_bataljual.PerformClick()
            End If
            e.SuppressKeyPress = True
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            bt_simpanjual.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    'UI : BUTTON
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_bataljual.Click
        bt_cl.PerformClick()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.Close()
    End Sub

    Private Sub bt_simpanjual_Click(sender As Object, e As EventArgs) Handles bt_simpanjual.Click
        'CHECK TANGGAL TRANSAKSI
        If date_tgl_beli.Value < TransStartDate Then
            MessageBox.Show("Tanggal transaksi tidak boleh kurang dari periode aktif." & TransStartDate.ToString("(MMMM yyyy)"),
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            date_tgl_beli.Focus() : Exit Sub
        End If

        'CHECK INPUT DATA
        If in_sales.Text = Nothing Then
            MessageBox.Show("Sales belum di input.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_sales_n.Focus()
            Exit Sub
        End If

        If in_custo.Text = Nothing Then
            MessageBox.Show("Customer belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_custo_n.Focus()
            Exit Sub
        End If

        'CHECK INPUT GUDANG
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

        'CHECK INPUT BARANG
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

        If in_term.Value > 0 And formstate = InputState.Insert Then
            If Not CheckPenjualan() Then Exit Sub
        ElseIf formstate = InputState.Edit And oldterm = 0 And in_term.Value > 0 Then
            If Not CheckPenjualan() Then Exit Sub
        End If

        If in_bayar.Value <> 0 And removeCommaThousand(in_sisa.Text) < 0 Then
            MessageBox.Show("Nilai pembayaran melebihi nilai faktur.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_bayar.Focus() : Exit Sub
        End If

        If date_tgl_beli.Value < selectperiode.tglawal Then
            MessageBox.Show("Tanggal transaksi lebih kecil daripada Jangka waktu periode terpilih", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            date_tgl_beli.Focus() : Exit Sub
        End If
        If CheckPiutang() = False Then Exit Sub

        Dim _askres As DialogResult = Windows.Forms.DialogResult.Yes
        If formstate <> InputState.Insert Then
            _askres = MessageBox.Show("Simpan perubahan data penjualan?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        End If

        If _askres = Windows.Forms.DialogResult.Yes Then saveData()
    End Sub

    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        txtToDgv()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_menu.Click
        Dim _x As Integer = sender.Location.X
        Dim _y As Integer = sender.Location.Y + sender.Height
        ctx_main.Show(pnl_header, _x, _y)
    End Sub

    'UI : CONTEXT MENU
    Private Sub tstrip_simpan_Click(sender As Object, e As EventArgs) Handles tstrip_simpan.Click
        bt_simpanjual.PerformClick()
    End Sub

    Private Sub tsrtip_close_Click(sender As Object, e As EventArgs) Handles tsrtip_close.Click
        bt_cl.PerformClick()
    End Sub

    Private Sub tstrip_print_Click(sender As Object, e As EventArgs) Handles tstrip_print.Click
        Me.Cursor = Cursors.WaitCursor
        Using nota As New fr_nota_dialog
            nota.do_load("jual", in_faktur.Text)
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tstrip_activate_Click(sender As Object, e As EventArgs) Handles tstrip_activate.Click
        If tjlStatus = 1 Then
            MessageBox.Show("Status penjualan pembelian sudah aktif.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf tjlStatus = 0 Then

        ElseIf tjlStatus = 2 Then
            If MessageBox.Show("Cancel pembatalan?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'TODO : CHECK INPUT
                changeTransactState(1)
            End If
        End If
    End Sub

    Private Sub tstrip_inactivate_Click(sender As Object, e As EventArgs) Handles tstrip_inactivate.Click
        If tjlStatus = 2 Then
            MessageBox.Show("Transaksi penjualan sudah terbatalkan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf {0, 1}.Contains(tjlStatus) Then
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
        End If
    End Sub

    Private Sub tstrip_delete_Click(sender As Object, e As EventArgs) Handles tstrip_delete.Click
        If MessageBox.Show("Hapus penjualan?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            changeTransactState(9)
        End If
    End Sub

    Private Sub mn_changecode_Click(sender As Object, e As EventArgs)
        If Not selectperiode.closed Then
            If MessageBox.Show("Ubah nomor faktur penjualan?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ChangeCode()
            End If
        End If
    End Sub

    Private Sub tstrip_new_custo_Click(sender As Object, e As EventArgs) Handles tstrip_new_custo.Click
        Dim x As New fr_custo_detail
        x.doLoadNew()
    End Sub

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
            setPopUpResult(popupstate)
        End If
    End Sub

    Private Sub dgv_listbarang_KeyDown_1(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dgv_listbarang_KeyUp(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyUp
        If e.KeyCode = Keys.Enter Then
            setPopUpResult(popupstate)
        End If
    End Sub

    Private Sub dgv_listbarang_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellEnter
        If popupstate = "custo" And dgv_listbarang.SelectedRows.Count > 0 Then
            in_alamat_c.Text = dgv_listbarang.SelectedRows.Item(0).Cells(7).Value
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

    'UI : COMBOBOX
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_ppn.KeyPress, cb_sat.KeyPress
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    Private Sub cb_ppn_change(sender As Object, e As EventArgs) Handles cb_ppn.SelectionChangeCommitted
        If cb_ppn.SelectedIndex > -1 Then countBiaya()
    End Sub

    'UI : NUMERIC INPUT
    Private Sub in_qty_Enter(sender As Object, e As EventArgs)
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs)
        If {"in_term", "in_qty"}.Contains(sender.Name) Then
            numericLostFocus(sender, "N0")
        Else
            numericLostFocus(sender)
        End If
    End Sub

    Private Sub in_bayar_ValueChanged(sender As Object, e As EventArgs) Handles in_bayar.ValueChanged
        Dim sisa As Decimal = IIf(in_netto.Text <> Nothing, removeCommaThousand(in_netto.Text), 0) - in_bayar.Value
        in_sisa.Text = commaThousand(sisa)
        If sisa = 0 Then in_term.Value = 0
    End Sub

    'UI : INPUT
    Private Sub in_sales_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter, in_custo_n.Enter, in_gudang_n.Enter, in_barang_nm.Enter
        If sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
            If popPnl_barang.Visible = False Then popPnl_barang.Visible = True

            If sender.Name = "in_sales_n" Then
                popupstate = "sales"
                popPnl_barang.Width = 386
            ElseIf sender.Name = "in_custo_n" Then
                popupstate = "custo"
                popPnl_barang.Width = 436
            ElseIf sender.Name = "in_gudang_n" Then
                popupstate = "gudang"
                popPnl_barang.Width = 386
            ElseIf sender.Name = "in_barang_nm" Then
                popupstate = "barang"
                popPnl_barang.Width = 386
            End If
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

    Private Sub in_supplier_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyDown, in_custo_n.KeyDown, in_barang_nm.KeyDown, in_gudang_n.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp, in_custo_n.KeyUp, in_barang_nm.KeyUp, in_gudang_n.KeyUp
        Dim _id As TextBox : Dim _next As Control : Dim _result As String = ""

        Select Case sender.Name
            Case "in_sales_n" : _id = in_sales : _next = in_custo_n
            Case "in_custo_n" : _id = in_custo : _next = in_gudang_n
            Case "in_barang_nm" : _id = in_barang : _next = in_qty
            Case "in_gudang_n" : _id = in_gudang : _next = in_term
            Case Else
                Exit Sub
        End Select
        _result = popupstate

        Dim _x = PopUpSearchInputHandle_inputKeyup(e, sender, _id, popPnl_barang, dgv_listbarang)
        For Each _resp As String In _x
            Select Case _resp
                Case "set" : setPopUpResult(_result)
                Case "next" : keyshortenter(_next, e)
                Case "clear"
                    If sender.Name = "in_sales_n" Then
                        _salesgudang = False : _salesitem = False
                    ElseIf sender.Name = "in_custo_n" Then
                        maxpiutang = 0 : jumlahpiutang = 0
                    End If
                Case "load" : loadDataBRGPopup(popupstate, sender.Text)
            End Select
        Next
    End Sub

    'BARANG
    Private Sub in_harga_beli_ValueChanged(sender As Object, e As EventArgs)
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
        If cb_sat.SelectedIndex > -1 Then
            in_harga_beli.Value = CountItemPrice(_satuanstate, cb_sat.SelectedValue, in_harga_beli.Value, isibesar, isitengah)
            _satuanstate = cb_sat.SelectedValue
        End If
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
End Class