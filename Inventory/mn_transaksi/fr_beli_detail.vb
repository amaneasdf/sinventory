Public Class fr_beli_detail
    Private indexrow As Integer = 0
    Private popupstate As String = "barang"

    'VARIABLE FAKTUR
    Private tblStatus As String = "1"
    Private selectSupplier As String = ""
    Private _HutangLunas As Boolean = False

    'VARIABLE BARANG
    Private isibesar As Integer = 0
    Private isitengah As Integer = 0
    Private _satuanstate As String = "kecil"

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
        '    .Value = IIf(selectperiode.tglakhir >= Today, Today, selectperiode.tglakhir)
        '    .MaxDate = selectperiode.tglakhir
        '    .MinDate = selectperiode.tglawal
        'End With
        'date_tgl_pajak.Value = IIf(selectperiode.tglakhir >= Today, Today, selectperiode.tglakhir)
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
            If Not {0, 1}.Contains(tblStatus) Or date_tgl_beli.Value < TransStartDate Then formstate = InputState.View
        End If

        If formstate = InputState.View Then AllowEdit = False
        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        If formstate <> InputState.Insert Then
            in_faktur.ReadOnly = True : in_faktur.BackColor = Color.Gainsboro
            tstrip_print.Enabled = If(tblStatus = 1, True, False)
            tstrip_status.Enabled = If(date_tgl_beli.Value < TransStartDate, False, True)
            bt_simpanbeli.Text = "Update"
        Else
            tstrip_print.Enabled = False
            tstrip_status.Enabled = False
        End If
        For Each txt As TextBox In {in_gudang_n, in_barang_nm, in_pajak, in_ket, in_suratjalan}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        For Each dtpick As DateTimePicker In {date_tgl_pajak, date_tgl_beli}
            dtpick.Enabled = AllowInput
        Next
        For Each numx As NumericUpDown In {in_term, in_klaim, in_harga_beli, in_disc1, in_disc2, in_disc3, in_discrp}
            numx.Enabled = AllowInput
            AddHandler numx.Enter, AddressOf in_qty_Enter
            AddHandler numx.Leave, AddressOf in_qty_Leave
        Next
        For Each x As DataGridViewColumn In {harga, discrp, jml, subtot, disc1, disc2, disc3}
            x.DefaultCellStyle = dgvstyle_currency
        Next
        For Each x As DataGridViewColumn In {qty}
            x.DefaultCellStyle = dgvstyle_commathousand
        Next

        'ITEM INPUT CONTROL
        For Each ctr As Control In {in_qty, cb_sat, in_harga_beli, in_disc1, in_disc2, in_disc3, in_discrp, bt_tbbarang}
            ctr.Visible = AllowInput
        Next

        bt_simpanbeli.Enabled = AllowInput
        tstrip_simpan.Enabled = AllowInput
        tstrip_other.Enabled = AllowInput
        tstrip_new_barang.Enabled = IIf(main.listkodemenu.Contains("mn0101"), AllowInput, False)
        tstrip_new_supplier.Enabled = IIf(main.listkodemenu.Contains("mn0102"), AllowInput, False)
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
            dgv_barang.Location = New Point(14, 175) : dgv_barang.Height = 207
            AddHandler dgv_barang.CellDoubleClick, AddressOf dgv_barang_CellDoubleClick
        Else
            dgv_barang.Location = New Point(14, 132) : dgv_barang.Height = 247
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

    Private Sub fr_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 100
        dgv_barang.ClearSelection()
    End Sub

    'LOAD DATA
    Private Function loadDataFaktur(kode As String) As KeyValuePair(Of Boolean, String)
        If MainConnData.IsEmpty Then Return New KeyValuePair(Of Boolean, String)(False, "Main DB Configuration is empty.")

        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    'LOAD HEADER
                    Using rdx = x.ReadCommand(String.Format("CALL getTransHeader('BELI','{0}')", kode))
                        If rdx.Read And rdx.HasRows Then
                            RemoveHandler in_klaim.ValueChanged, AddressOf in_klaim_ValueChanged
                            in_faktur.Text = kode
                            in_suratjalan.Text = rdx.Item("faktur_surat_jalan")
                            in_pajak.Text = rdx.Item("faktur_pajak_no")
                            date_tgl_beli.Value = rdx.Item("faktur_tanggal_trans")
                            date_tgl_pajak.Value = rdx.Item("faktur_pajak_tanggal")

                            in_gudang.Text = rdx.Item("faktur_gudang")
                            in_gudang_n.Text = rdx.Item("gudang_nama")
                            selectSupplier = rdx.Item("faktur_supplier")
                            in_supplier.Text = selectSupplier
                            in_supplier_n.Text = rdx.Item("supplier_nama")

                            in_term.Value = rdx.Item("faktur_term")
                            cb_ppn.SelectedValue = rdx.Item("faktur_ppn_jenis")

                            in_klaim.Value = CDbl(rdx.Item("faktur_klaim"))

                            in_ket.Text = rdx.Item("faktur_ket")
                            tblStatus = rdx.Item("faktur_status")
                            AddHandler in_klaim.ValueChanged, AddressOf in_klaim_ValueChanged
                        End If
                    End Using

                    'LOAD TABLE/ITEM
                    Dim q As String = "SELECT trans_barang, barang_nama, trans_harga_beli, trans_qty, trans_satuan, trans_disc1, trans_disc2, trans_disc3, " _
                                      & "trans_disc_rupiah, trans_jumlah, trans_ppn,trans_satuan_type " _
                                      & "FROM data_pembelian_trans INNER JOIN data_barang_master ON barang_kode = trans_barang " _
                                      & "WHERE trans_faktur='{0}' AND trans_status=1"
                    setDoubleBuffered(dgv_barang, True)
                    Using dt = x.GetDataTable(String.Format(q, kode))
                        With dgv_barang.Rows
                            For Each row As DataRow In dt.Rows
                                Dim i = .Add
                                .Item(i).Cells("kode").Value = row.ItemArray(0)
                                .Item(i).Cells("nama").Value = row.ItemArray(1)
                                .Item(i).Cells("nama").ToolTipText = row.ItemArray(0) & " - " & row.ItemArray(1)
                                .Item(i).Cells("qty").Value = row.ItemArray(3)
                                .Item(i).Cells("sat").Value = row.ItemArray(4)
                                .Item(i).Cells("sat_type").Value = row.ItemArray(11)
                                .Item(i).Cells("harga").Value = row.ItemArray(2)
                                .Item(i).Cells("subtot").Value = row.ItemArray(3) * row.ItemArray(2)
                                .Item(i).Cells("disc1").Value = row.ItemArray(5)
                                .Item(i).Cells("disc2").Value = row.ItemArray(6)
                                .Item(i).Cells("disc3").Value = row.ItemArray(7)
                                .Item(i).Cells("discrp").Value = row.ItemArray(8)
                                .Item(i).Cells("jml").Value = row.ItemArray(9)
                            Next
                        End With
                    End Using
                    countbiaya() : cb_ppn.Enabled = False
                    Select Case tblStatus
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

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Dim autoco As New AutoCompleteStringCollection
        Select Case tipe
            Case "barang"
                Dim _pajak As String = IIf(cb_ppn.SelectedValue = 0, 0, 1)
                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama', barang_harga_beli 'Harga', barang_harga_beli_d1, " _
                    & "barang_harga_beli_d2, barang_harga_beli_d3 FROM data_barang_master " _
                    & "WHERE (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%') AND barang_supplier='{1}' AND barang_status=1 AND barang_pajak='{2}' LIMIT 250"
                q = String.Format(q, "{0}", in_supplier.Text, _pajak)
            Case "supplier"
                q = "SELECT supplier_kode AS 'Kode', supplier_nama AS 'Nama', supplier_term FROM data_supplier_master " _
                    & "WHERE supplier_status=1 AND (supplier_nama LIKE '%{0}%' OR supplier_kode LIKE '%{0}%') LIMIT 250"
            Case "gudang"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang " _
                    & "WHERE gudang_status=1 AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%') LIMIT 250"
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
            If .ColumnCount >= 2 Then
                .Columns(0).Width = IIf(tipe = "barang", 75, 135)
                .Columns(1).Width = 200
                If {"barang", "supplier"}.Contains(tipe) Then
                    If tipe = "barang" Then .Columns(2).DefaultCellStyle = dgvstyle_currency
                    For i = IIf(tipe = "barang", 3, 2) To IIf(tipe = "supplier", 2, 5)
                        .Columns(i).Visible = False
                    Next
                End If
                .Columns(.DisplayedColumnCount(False) - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If
            If String.IsNullOrWhiteSpace(param) Then .ClearSelection()
        End With
    End Sub

    'OPEN SEARCH WINDOW
    Private Sub doSearch()
        
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        If dgv_listbarang.SelectedRows.Count > 0 Then
            With dgv_listbarang.SelectedRows.Item(0)
                Select Case popupstate
                    Case "barang"
                        in_barang.Text = .Cells(0).Value
                        in_barang_nm.Text = .Cells(1).Value
                        in_harga_beli.Value = .Cells(2).Value
                        in_disc1.Value = .Cells(3).Value
                        in_disc2.Value = .Cells(4).Value
                        in_disc3.Value = .Cells(5).Value
                        loadSatuanBrg(in_barang.Text)
                        in_qty.Focus()
                    Case "supplier"
                        in_supplier.Text = .Cells(0).Value
                        in_supplier_n.Text = .Cells(1).Value
                        in_term.Value = .Cells(2).Value
                        selectSupplier = in_supplier.Text
                        in_gudang_n.Focus()
                    Case "gudang"
                        in_gudang.Text = .Cells(0).Value
                        in_gudang_n.Text = .Cells(1).Value
                        in_suratjalan.Focus()
                    Case Else
                        Exit Sub
                End Select
            End With
        End If
        'popPnl_barang.Visible = False
    End Sub

    'INPUT DATA TO DGV FR TEXTBOX
    Private Sub textToDgv()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main Connection is empty")
        End If

        Dim _supplier As String = ""
        Dim _pajak As String = ""
        Dim kode As String = in_barang.Text
        Dim q As String = ""

        If String.IsNullOrWhiteSpace(Trim(in_barang.Text)) Then
            MessageBox.Show("Masukkan barang terlebih dahulu.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_barang.Focus() : Exit Sub
        End If
        If in_qty.Value = 0 Then
            MessageBox.Show("Masukkan jumlah quantitas terlebih dahulu.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_qty.Focus() : Exit Sub
        End If

        'GET DATA BARANG
        q = "SELECT barang_supplier, barang_pajak FROM data_barang_master WHERE barang_kode='{0}'"
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Using rdx = x.ReadCommand(String.Format(q, kode), CommandBehavior.SingleRow)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _supplier = rdx.Item(0)
                        _pajak = rdx.Item(1)
                    Else
                        MessageBox.Show("Terjadi kesalahan saat melakukan penambahan item." & Environment.NewLine & "Data barang tidak dapat ditemukan",
                                        Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using
            End If
        End Using

        If in_supplier.Text <> _supplier Then
            MessageBox.Show("Supplier barang berbeda dengan barang yang terpilih.", "Pembelian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_barang_nm.Focus()
            popPnl_barang.Visible = False
            Exit Sub
        End If

        If (_pajak = 0 And cb_ppn.SelectedValue <> 0) Or (_pajak = 1 And {1, 2}.Contains(cb_ppn.SelectedValue) = False) Then
            MessageBox.Show("Kategori barang tidak sesuai dengan kategori pajak faktur/nota beli", "Pembelian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_barang_nm.Focus()
            popPnl_barang.Visible = False
            Exit Sub
        End If


        Dim pajak_tot As Decimal = 0
        Dim total As Decimal = removeCommaThousand(in_subtotal.Text)

        If in_discrp.Value <> 0 Then total -= in_qty.Value * in_discrp.Value

        For Each x As Decimal In {in_disc1.Value, in_disc2.Value, in_disc3.Value}
            If x <> 0 Then
                Dim y As Decimal = total
                total = y * (1 - x / 100)
            Else
                total = total
            End If
        Next

        dgv_barang.ClearSelection()
        With dgv_barang.Rows
            Dim x As Integer = .Add
            With .Item(x)
                .Cells("kode").Value = in_barang.Text
                .Cells("nama").Value = in_barang_nm.Text
                .Cells("nama").ToolTipText = in_barang.Text & " - " & in_barang_nm.Text
                .Cells("qty").Value = in_qty.Value
                .Cells("sat").Value = cb_sat.Text
                .Cells("sat_type").Value = cb_sat.SelectedValue
                .Cells("harga").Value = in_harga_beli.Value
                .Cells("subtot").Value = removeCommaThousand(in_subtotal.Text)
                .Cells("disc1").Value = in_disc1.Value
                .Cells("disc2").Value = in_disc2.Value
                .Cells("disc3").Value = in_disc3.Value
                .Cells("discrp").Value = in_discrp.Value
                .Cells("jml").Value = total

                .Selected = True
            End With
        End With

        countbiaya()
        clearInputBarang()
        in_barang.Focus()

        in_supplier_n.ReadOnly = True : in_supplier_n.BackColor = Color.Gainsboro
        cb_ppn.Enabled = False
    End Sub

    'GET DATA TO TEXTBOX FR DGV
    Private Sub dgvTotxt()
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
            in_discrp.Value = .Cells("discrp").Value
        End With

        in_qty.Focus()
        selectSupplier = in_supplier.Text
        dgv_barang.Rows.RemoveAt(_idx)
        dgv_barang.ClearSelection()
        countbiaya()

        If dgv_barang.RowCount = 0 Then
            in_supplier_n.ReadOnly = False : in_supplier_n.BackColor = Color.White
            cb_ppn.Enabled = True
        End If
    End Sub

    'COUNT COST & VALUE
    Private Sub countbiaya()
        Dim pajak As Decimal = 0
        Dim subtotal As Decimal = 0
        Dim netto As Decimal = 0
        Dim diskon As Decimal = 0

        For Each row As DataGridViewRow In dgv_barang.Rows
            subtotal += row.Cells("subtot").Value
            diskon += row.Cells("subtot").Value - row.Cells("jml").Value
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
        in_klaim.Maximum = netto
        in_total_netto.Text = commaThousand(netto - in_klaim.Value)
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
        For Each x As NumericUpDown In {in_qty, in_disc1, in_disc2, in_disc3, in_discrp}
            x.Value = 0
        Next
    End Sub

    'SAVE
    Private Sub saveData()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim dataHead, dataBrg As String()
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
            "faktur_surat_jalan='" & in_suratjalan.Text & "'",
            "faktur_gudang='" & in_gudang.Text & "'",
            "faktur_supplier='" & in_supplier.Text & "'",
            "faktur_term='" & in_term.Value & "'",
            "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text) & "'",
            "faktur_disc='" & removeCommaThousand(in_diskon.Text).ToString.Replace(",", ".") & "'",
            "faktur_total='" & removeCommaThousand(in_total.Text).ToString.Replace(",", ".") & "'",
            "faktur_ppn='" & removeCommaThousand(in_ppn_tot.Text).ToString.Replace(",", ".") & "'",
            "faktur_ppn_jenis='" & cb_ppn.SelectedValue & "'",
            "faktur_netto='" & removeCommaThousand(in_netto.Text).ToString.Replace(",", ".") & "'",
            "faktur_klaim='" & in_klaim.Value & "'",
            "faktur_total_netto='" & removeCommaThousand(in_total_netto.Text).ToString.Replace(",", ".") & "'",
            "faktur_ket='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
            "faktur_status='" & tblStatus & "'"
        }

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
                            q = "SELECT IFNULL(MAX(SUBSTRING(faktur_kode, 11)),0) FROM data_pembelian_faktur " _
                                & "WHERE faktur_kode LIKE 'PO{0:yyyyMMdd}%' AND SUBSTRING(faktur_kode,11) REGEXP '^[0-9]+$'"

                            i = CInt(x.ExecScalar(String.Format(q, date_tgl_beli.Value)))
                            Format = IIf(i + 1 > 999, "D" & (i + 1).ToString.Length, "D3")
                            in_faktur.Text = String.Format("PO{0:yyyyMMdd}", date_tgl_beli.Value) & (i + 1).ToString(format)

                            q = "INSERT INTO data_pembelian_faktur SET faktur_kode='{0}',{1},faktur_reg_date=NOW(),faktur_reg_alias='{2}'"
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
                                & "FROM data_pembelian_faktur WHERE faktur_kode='{0}'"
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
                            q = "INSERT INTO data_pembelian_faktur SET faktur_kode='{0}',{1},faktur_reg_date=NOW(),faktur_reg_alias='{2}'"
                        ElseIf cDel = 1 Then 'WHEN THE CODE IS ALREADY TAKEN BUT THE TRASACTION STATE IS DELETE
                            q = "UPDATE data_pembelian_faktur SET {1}, faktur_reg_date=NOW(), faktur_reg_alias='{2}', " _
                                & "faktur_upd_date=NULL, faktur_upd_alias=NULL WHERE faktur_kode='{0}'"
                        Else 'WHEN THERE IS DUPLICATION IN DATABASE ON THE CODE
                            MessageBox.Show("Terjadi kesalahan dalam melakukan proses penyimpanan data." & Environment.NewLine & _
                                            "Terdapat duplikasi kode pada database, kode faktur tidak dapat digunakan.",
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            errLog(New List(Of String) From {"Error : Duplicate primary code in database for purchase data.",
                                                             encryptString("Duplicated Code : " & in_faktur.Text)
                                                            }) : Exit Sub
                        End If
                        'END OF CHECKING USER INPUTED CODE ========================================================================================
                    End If
                    'END OF NEW TRANSACTION =======================================================================================================

                ElseIf bt_simpanbeli.Text = "Update" Then
                    q = "UPDATE data_pembelian_faktur SET {1},faktur_upd_date=NOW(), faktur_upd_alias='{2}' WHERE faktur_kode='{0}' AND faktur_status<9"
                End If
                queryArr.Add(String.Format(q, in_faktur.Text, String.Join(",", dataHead), loggeduser.user_id))
                'END OF INSERT UPDATE HEADER ======================================================================================================

                'START OF INSERT UPDATE BARANG ====================================================================================================
                q = "UPDATE data_pembelian_trans SET trans_status=9 WHERE trans_faktur='{0}'"
                queryArr.Add(String.Format(q, in_faktur.Text))

                For Each rows As DataGridViewRow In dgv_barang.Rows
                    Dim _kdbrg As String = rows.Cells(0).Value

                    'INSERT DATA BARANG
                    dataBrg = {
                        "trans_barang='" & _kdbrg & "'",
                        "trans_harga_beli='" & Decimal.Parse(rows.Cells("harga").Value).ToString.Replace(",", ".") & "'",
                        "trans_qty='" & rows.Cells("qty").Value & "'",
                        "trans_satuan='" & rows.Cells("sat").Value & "'",
                        "trans_satuan_type='" & rows.Cells("sat_type").Value & "'",
                        "trans_disc1='" & Decimal.Parse(rows.Cells("disc1").Value).ToString.Replace(",", ".") & "'",
                        "trans_disc2='" & Decimal.Parse(rows.Cells("disc2").Value).ToString.Replace(",", ".") & "'",
                        "trans_disc3='" & Decimal.Parse(rows.Cells("disc3").Value).ToString.Replace(",", ".") & "'",
                        "trans_disc_rupiah='" & Decimal.Parse(rows.Cells("discrp").Value).ToString.Replace(",", ".") & "'",
                        "trans_jumlah='" & Decimal.Parse(rows.Cells("jml").Value).ToString.Replace(",", ".") & "'",
                        "trans_status='1'"
                        }
                    q = "INSERT INTO data_pembelian_trans SET trans_faktur= '{0}',{1} ON DUPLICATE KEY UPDATE {1}"
                    queryArr.Add(String.Format(q, in_faktur.Text, String.Join(",", dataBrg)))
                Next
                'END OF INSERT UPDATE BARANG ======================================================================================================

                'START OF OTHER DATA CALC AND INPUT ===============================================================================================
                q = "CALL transPembelianFin('{0}','{1}')"
                queryArr.Add(String.Format(q, in_faktur.Text, loggeduser.user_id))
                'END OF OTHER DATA CALC AND INPUT =================================================================================================

                '==========================================================================================================================
                'BEGIN MYSQL TRANSACTION
                querycheck = x.TransactCommand(queryArr)
                '==========================================================================================================================

                If querycheck = False Then
                    MessageBox.Show("Data pembelian tidak dapat tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                Else
                    MessageBox.Show("Data pembelian tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    doRefreshTab({pgpembelian, pgstok, pghutangawal})
                    Me.Close()
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error) : Exit Sub
            End If
        End Using
    End Sub

    Private Function CheckHutang() As Boolean
        'DATA YANG DIBUTUHKAN : NILAI HUTANG TERSIMPAN SEBELUM UPDATE, NILAI YG SUDAH TERBAYAR, STATUS LUNAS, TANGGAL PEMBAYARAN HUTANG PALING AWAL
        If Not formstate = InputState.Insert Then
            Try
                Using x = MainConnection
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        Dim _q As String = ""
                        _q = "SELECT COUNT(hutang_id) FROM data_hutang_awal WHERE hutang_faktur='{0}' AND hutang_status<9"

                        Dim _count = Integer.Parse(x.ExecScalar(String.Format(_q, in_faktur.Text)))
                        If _count = 1 Then
                            'IF EXIST
                            Dim _oldhutang As Decimal = 0 : Dim _sisahutang As Decimal = 0

                            'CHECK STATUS LUNAS, SALDO PIUTANG, SISA PIUTANG
                            _q = "SELECT hutang_awal, GetHutangSaldoAwal('hutang', hutang_faktur, ADDDATE(CURDATE(), 1)) " _
                                & "FROM data_hutang_awal WHERE hutang_faktur='{0}' AND hutang_status<9"
                            Using rdx = x.ReadCommand(String.Format(_q, in_faktur.Text))
                                Dim red = rdx.Read
                                If red And rdx.HasRows Then
                                    _oldhutang = Decimal.Parse(rdx.Item(0))
                                    _sisahutang = Decimal.Parse(rdx.Item(1))
                                Else
                                    MessageBox.Show("Terjadi kesalahan saat melakukan pengecekan data." & Environment.NewLine & "Data hutang tidak dapat ditemukan",
                                                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Return False
                                End If
                            End Using

                            If _oldhutang <> _sisahutang Then
                                Dim _minDate As Date = date_tgl_beli.Value
                                _q = "SELECT COUNT(h_trans_id), MIN(h_trans_tgl) FROM data_hutang_trans " _
                                    & "WHERE h_trans_kode_hutang='{0}' AND h_trans_jenis='bayar' AND h_trans_status=1"

                                Using rdx = x.ReadCommand(String.Format(_q, in_faktur.Text))
                                    Dim red = rdx.Read
                                    If red And rdx.HasRows Then
                                        _count = rdx.Item(0)
                                        If _count > 0 Then _minDate = rdx.Item(1)
                                    Else
                                        MessageBox.Show("Terjadi kesalahan saat melakukan pengecekan data." & Environment.NewLine & "Data hutang tidak dapat ditemukan",
                                                        Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Return False
                                    End If
                                End Using

                                If _count > 0 And date_tgl_beli.Value > _minDate Then
                                    MessageBox.Show("Pembayaran hutang untuk faktur pembelian sudah diinput untuk tanggal " & _minDate.ToString("dd MMMM yyyy.") & _
                                                    Environment.NewLine & "Tanggal pembelian tidak dapat lebih besar dari tanggal pembayaran, silahkan cek kembali.",
                                                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    date_tgl_beli.Focus() : Return False
                                End If
                            End If

                            Dim _newHutang = removeCommaThousand(in_total_netto.Text)
                            If _newHutang > _oldhutang Then
                                Return True
                            Else
                                If _sisahutang < _newHutang Then
                                    MessageBox.Show("Nilai hutang pembelian yang akan diinputkan lebih kecil dari pembayaran yang telah diinputkan." & _
                                                    Environment.NewLine & "Harap cek kembali nilai pembayaran yang telah diinput.", Me.Text,
                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Return False
                                Else
                                    Return True
                                End If
                            End If

                        ElseIf _count = 0 Then
                            'IF NEW
                            Return True

                        Else
                            'IF DUPLICATE
                            MessageBox.Show("Terjadi kesalahan saat pelakukan pengecekan data pembelian." & Environment.NewLine & _
                                            "Terdapat duplikasi kode pada database, kode faktur tidak dapat digunakan.",
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            errLog(New List(Of String) From {"Error : Duplicate faktur kode pada table hutang awal.",
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
                MessageBox.Show("Terjadi kesalahan saat melakukan pengecekan data pembelian." & Environment.NewLine & ex.Message,
                                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                logError(ex, True)
                Return False
            End Try
        Else
            Return True
        End If
    End Function

    'CANCEL
    Private Sub cancelData(NewStatus As Integer)
        Dim _kode As String = in_faktur.Text
        Dim q As String = ""
        Dim queryArr As New List(Of String)
        Dim queryCk As Boolean = False

        Dim _failmsg, _succmsg As String
        If {0, 1}.Contains(NewStatus) Then
            _failmsg = "Cancel pembatalan gagal." : _succmsg = "Cancel pembatalan berhasil."
        ElseIf NewStatus = 2 Then
            _failmsg = "Pembatalan transaksi gagal." : _succmsg = "Pembatalan transaksi berhasil."
        ElseIf NewStatus = 9 Then
            _failmsg = "Transaksi tidak dapat dihapus." : _succmsg = "Transaksi berhasil dihapus."
        Else : Exit Sub
        End If

        Dim _resMsg As String = "" : Dim ValidUid As String = ""
        If String.IsNullOrWhiteSpace(in_faktur.Text) Then Exit Sub
        If {2, 9}.Contains(NewStatus) Then
            If Not CheckCancelPembelian(_kode, _resMsg) Then
                MessageBox.Show(_failmsg & Environment.NewLine & _resMsg, Me.Text, MessageBoxButtons.OK)
                Exit Sub
            End If
        End If
        If Not TransConfirmValid(ValidUid) Then Exit Sub
        'ADD LOG VALIDASI

        q = "UPDATE data_pembelian_faktur SET faktur_status={2}, faktur_upd_alias='{1}', faktur_upd_date=NOW() WHERE faktur_kode='{0}' AND faktur_status<9"
        queryArr.Add(String.Format(q, _kode, ValidUid, NewStatus))
        If NewStatus = 9 Then
            q = "UPDATE data_pembelian_trans SET trans_status=9 WHERE trans_faktur='{0}' AND trans_status=1"
            queryArr.Add(String.Format(q, _kode))
        End If
        q = "CALL transPembelianFin('{0}','{1}')"
        queryArr.Add(String.Format(q, _kode, ValidUid))

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                queryCk = x.TransactCommand(queryArr)
                If queryCk Then
                    DoRefreshTab_v2({pgpembelian, pghutangawal})
                    MessageBox.Show(_succmsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    MessageBox.Show(_failmsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
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
                bt_batalbeli.PerformClick()
            End If
            e.SuppressKeyPress = True
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            bt_simpanbeli.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    'UI : BUTTON
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        bt_cl.PerformClick()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.Close()
    End Sub

    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        'CHECK TANGGAL TRANSAKSI
        If date_tgl_beli.Value < TransStartDate Then
            MessageBox.Show("Tanggal transaksi tidak bisa kurang dari periode aktif. " & TransStartDate.ToString("(MMMM yyyy)"),
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            date_tgl_beli.Focus() : Exit Sub
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
            MessageBox.Show("Barang belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_barang.Focus() : Exit Sub
        End If
        If CheckHutang() = False Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim _askres As DialogResult = Windows.Forms.DialogResult.Yes
        If Not formstate = InputState.Insert Then _askres = MessageBox.Show("Simpan perubahan data pembelian?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _askres = Windows.Forms.DialogResult.Yes Then saveData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_menu.Click
        Dim _x As Integer = sender.Location.X
        Dim _y As Integer = sender.Location.Y + sender.Height
        ctx_main.Show(pnl_header, _x, _y)
    End Sub

    'UI : CONTEXT MENU
    Private Sub tstrip_simpan_Click(sender As Object, e As EventArgs) Handles tstrip_simpan.Click
        bt_simpanbeli.PerformClick()
    End Sub

    Private Sub tsrtip_close_Click(sender As Object, e As EventArgs) Handles tsrtip_close.Click
        bt_cl.PerformClick()
    End Sub

    Private Sub tstrip_print_Click(sender As Object, e As EventArgs) Handles tstrip_print.Click
        Me.Cursor = Cursors.WaitCursor
        Using nota As New fr_nota_dialog
            nota.do_load("beli", in_faktur.Text)
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tstrip_activate_Click(sender As Object, e As EventArgs) Handles tstrip_activate.Click
        If tblStatus = 1 Then
            MessageBox.Show("Status transaksi pembelian sudah aktif.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub tstrip_inactivate_Click(sender As Object, e As EventArgs) Handles tstrip_inactivate.Click
        If tblStatus = 2 Then
            MessageBox.Show("Transaksi pembelian sudah terbatalkan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub tstrip_delete_Click(sender As Object, e As EventArgs) Handles tstrip_delete.Click

    End Sub

    Private Sub tstrip_supplier_Click(sender As Object, e As EventArgs) Handles tstrip_new_supplier.Click
        Dim sup As New fr_supplier_detail
        sup.doLoadNew()
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
        If Not in_supplier_n.Focused Or in_gudang_n.Focused Or in_barang_nm.Focused Then
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
                Case "supplier" : x = in_supplier_n
                Case "gudang" : x = in_gudang_n
                Case "barang" : x = in_barang_nm
                Case Else : Exit Sub
            End Select
            PopUpSearchKeyPress(e, x)
        End If
    End Sub

    'UI : COMBOBOX
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_ppn.KeyPress, cb_sat.KeyPress
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    Private Sub cb_ppn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_ppn.SelectionChangeCommitted
        countbiaya()
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

    Private Sub in_klaim_ValueChanged(sender As Object, e As EventArgs) Handles in_klaim.ValueChanged
        countbiaya()
    End Sub

    'UI : INPUT
    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_supplier_n.Enter, in_gudang_n.Enter, in_barang_nm.Enter
        If sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
            If popPnl_barang.Visible = False Then popPnl_barang.Visible = True
            Select Case sender.Name
                Case "in_supplier_n" : popupstate = "supplier"
                Case "in_gudang_n" : popupstate = "gudang"
                Case "in_barang_nm" : popupstate = "barang"
            End Select
            loadDataBRGPopup(popupstate, sender.Text)
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_supplier_n.Leave, in_gudang_n.Leave, in_barang_nm.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_custo_n_MouseClick(sender As Object, e As MouseEventArgs) Handles in_supplier_n.MouseClick, in_gudang_n.MouseClick, in_barang_nm.MouseClick
        If popPnl_barang.Visible = False And sender.ReadOnly = False Then
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyDown, in_gudang_n.KeyDown, in_barang_nm.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then e.SuppressKeyPress = True
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyUp, in_gudang_n.KeyUp, in_barang_nm.KeyUp
        Dim _next As Control : Dim _id As TextBox
        Select Case sender.Name.ToString
            Case "in_supplier_n" : _next = in_gudang_n : _id = in_supplier
            Case "in_gudang_n" : _next = in_suratjalan : _id = in_gudang
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

    'UI : INPUT BARANG
    Private Sub in_harga_beli_ValueChanged(sender As Object, e As EventArgs) Handles in_qty.ValueChanged, in_harga_beli.ValueChanged
        in_subtotal.Text = commaThousand(in_qty.Value * in_harga_beli.Value)
    End Sub

    Private Sub cb_sat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_sat.SelectionChangeCommitted
        in_harga_beli.Value = CountItemPrice(_satuanstate, cb_sat.SelectedValue, in_harga_beli.Value, isibesar, isitengah)
        _satuanstate = cb_sat.SelectedValue
    End Sub

    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        textToDgv()
    End Sub

    'UI : DGV
    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If loggeduser.AllowEdit_Transaction = True And tblStatus <> 2 Then
            If e.RowIndex < 0 Then
                indexrow = 0
            Else
                indexrow = e.RowIndex
                dgvTotxt()
            End If
        End If
    End Sub
End Class