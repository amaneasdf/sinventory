Public Class fr_efak_detail
    'note
    'penjualana bisa untuk input & validasi -> hutang custo
    'alur so -> sales>validasi>admin>gudang

    Private _PeriodePajak As Date = Today
    Private _SupplierBased As Boolean = False
    Private _SupplierCode As String = ""
    Private _JenisPajak As Integer = 1
    Private _IdExport As Integer = 1
    Private _IdFaktur As Integer = 0

    Private jeniscusto As String
    Private popupstate As String = "barang"
    Private isibesar As Integer = 0
    Private isitengah As Integer = 0
    Private qtybarang As Integer = 0
    Private _satuanstate As String = "kecil"
    Private _salesgudang As String = ""
    Private _salesitem As Boolean = False
    Private formstate As InputState = InputState.Edit

    Private Enum InputState
        Edit
        View
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(NoFaktur As String, IdExport As Integer, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Detail Penjualan : PO201908109021"

        formstate = FormSet

        For Each x As DataGridViewColumn In {harga, discrp, jml, subtotal}
            x.DefaultCellStyle = dgvstyle_currency
        Next

        _IdExport = IdExport
        _IdFaktur = GetIdFaktur(NoFaktur, IdExport)
        If _IdFaktur = 0 Then
            MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data." & Environment.NewLine & "Data tidak dapat ditemukan.",
                            NoFaktur, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        loadDataFaktur(_IdFaktur)
        bt_simpanjual.Text = "Update"

        Me.lbl_title.Text = "Detail Penjualan : " & NoFaktur
        If Me.lbl_title.Text.Length > _tempTitle.Length Then
            Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
        End If
        Me.Text = lbl_title.Text

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        For Each txt As TextBox In {in_pajak}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        For Each dtpick As DateTimePicker In {date_tgl_pajak}
            dtpick.Enabled = AllowInput
        Next
        For Each x As Control In {in_qty, cb_sat, in_harga_beli, in_disc1, in_disc2, in_disc3, in_disc4, in_disc5, in_discrp, bt_tbbarang}
            x.Visible = AllowInput
        Next

        bt_simpanjual.Enabled = AllowInput
        mn_save.Enabled = bt_simpanjual.Enabled
        mn_reinput.Enabled = AllowInput

        For Each x As DataGridViewColumn In {disc1, disc2, disc3, disc4, disc5}
            x.DefaultCellStyle = dgvstyle_currency
        Next

        If AllowInput Then
            dgv_barang.Location = New Point(12, 182) : dgv_barang.Height = 187
            AddHandler dgv_barang.CellDoubleClick, AddressOf dgv_barang_CellDoubleClick
        Else
            dgv_barang.Location = New Point(12, 142) : dgv_barang.Height = 227
            RemoveHandler dgv_barang.CellDoubleClick, AddressOf dgv_barang_CellDoubleClick
        End If
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, IdExport As Integer, AllowEdit As Boolean)
        SetUpForm(NoFaktur, IdExport, InputState.Edit, AllowEdit)
        Me.Show(main)
    End Sub

    Public Sub doLoadView(NoFaktur As String, IdExport As Integer)
        SetUpForm(NoFaktur, IdExport, InputState.View, False)
        Me.Show(main)
    End Sub

    'GET ID FAKTUR BASED FROM EXPORT TEMPLATE
    Private Function GetIdFaktur(NoFaktur As String, IdExport As String) As Integer
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim q As String = "SELECT e_list_id FROM data_penjualan_efak_list WHERE e_list_templateid='{0}' AND e_list_kodefaktur='{1}' AND e_list_status=1"
                Dim _ret As Integer = 0
                Dim _res As Boolean = Integer.TryParse(x.ExecScalar(String.Format(q, IdExport, NoFaktur)), _ret)
                Return _ret
            Else
                Return 0
            End If
        End Using
    End Function

    'LOAD DATA
    Private Sub loadDataFaktur(IdFaktur As String)
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        'LOAD DATA EXPORT
        LoadDataTemplateExport(_IdExport)

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                'LOAD HEADER
                q = "CALL EFak_LoadDetail_Header('{0}')"
                Using rdx = x.ReadCommand(String.Format(q, IdFaktur))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_faktur.Text = rdx.Item("head_faktur")
                        in_tgl_trans.Text = Date.Parse(rdx.Item("head_tgl_trans")).ToString("dd MMMM yyyy")
                        in_pajak.Text = rdx.Item("head_pajak")
                        date_tgl_pajak.Value = rdx.Item("head_pajak_tgl")
                        _JenisPajak = rdx.Item("head_pajak_type_id")
                        Select Case _JenisPajak
                            Case 1 : in_jenispajak.Text = "Included"
                            Case 2 : in_jenispajak.Text = "Excluded"
                            Case 0
                                If _SupplierBased Then
                                    _JenisPajak = 1
                                    in_jenispajak.Text = "Included"
                                Else
                                    in_jenispajak.Text = "Non-PPN"
                                End If
                            Case Else : in_jenispajak.Text = "Error"
                        End Select

                        in_gudang.Text = rdx.Item("faktur_gudang")
                        in_gudang_n.Text = rdx.Item("gudang_nama")
                        in_sales.Text = rdx.Item("faktur_sales")
                        in_sales_n.Text = rdx.Item("salesman_nama")
                        in_custo.Text = rdx.Item("faktur_customer")
                        in_custo_n.Text = rdx.Item("customer_nama")
                        in_custo_al.Text = rdx.Item("customer_alamat")
                        jeniscusto = rdx.Item("customer_kriteria_harga_jual")
                        in_bayar.Text = rdx.Item("faktur_bayar")

                    End If
                End Using

                'LOAD TABLE/ITEM
                q = "SELECT e_list_det_kodebrg, barang_nama, e_list_det_hargajual, e_list_det_qty, e_list_det_satuan, e_list_det_satuan_type, " _
                    & "e_list_det_disc1, e_list_det_disc2, e_list_det_disc3, e_list_det_disc4, e_list_det_disc5, e_list_det_disc_rupiah, " _
                    & "e_list_det_jumlah " _
                    & "FROM data_penjualan_efak_list_detail " _
                    & "LEFT JOIN data_barang_master ON barang_kode=e_list_det_kodebrg " _
                    & "WHERE e_list_det_idlist='{0}' AND e_list_det_status=1"
                Using dt As DataTable = x.GetDataTable(String.Format(q, IdFaktur))
                    setDoubleBuffered(dgv_barang, True)
                    With dgv_barang.Rows
                        For Each rows As DataRow In dt.Rows
                            Dim i = .Add
                            .Item(i).Cells("kode").Value = rows.ItemArray(0)
                            .Item(i).Cells("nama").Value = rows.ItemArray(1)
                            .Item(i).Cells("harga").Value = rows.ItemArray(2)
                            .Item(i).Cells("qty").Value = rows.ItemArray(3)
                            .Item(i).Cells("sat").Value = rows.ItemArray(4)
                            .Item(i).Cells("sat_type").Value = rows.ItemArray(5)
                            .Item(i).Cells("disc1").Value = rows.ItemArray(6)
                            .Item(i).Cells("disc2").Value = rows.ItemArray(7)
                            .Item(i).Cells("disc3").Value = rows.ItemArray(8)
                            .Item(i).Cells("disc4").Value = rows.ItemArray(9)
                            .Item(i).Cells("disc5").Value = rows.ItemArray(10)
                            .Item(i).Cells("discrp").Value = rows.ItemArray(11)
                            .Item(i).Cells("jml").Value = rows.ItemArray(12)
                            .Item(i).Cells("subtotal").Value = rows.ItemArray(2) * rows.ItemArray(3)
                        Next
                        countBiaya()
                    End With
                End Using
            End If
        End Using

    End Sub

    Private Sub LoadDataTemplateExport(IdExport)
        Dim q As String = ""
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT efak_periode, efak_supplierbased, IFNULL(efak_suppliercode, '') FROM data_penjualan_efak WHERE efak_id='{0}'"
                Try
                    Using rdx = x.ReadCommand(String.Format(q, IdExport))
                        Dim red = rdx.Read
                        If red And rdx.HasRows Then
                            _PeriodePajak = Date.Parse(rdx.Item(0))
                            _SupplierBased = If(rdx.Item(1) = 1, True, False)
                            _SupplierCode = If(_SupplierBased, rdx.Item(2), String.Empty)
                        End If
                    End Using
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data." & Environment.NewLine & ex.Message,
                                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    'SAMAKAN DATA DG YANG ASLI
    Private Sub LoadDataMaster(KodeFaktur As String)

    End Sub

    'VIEW DATA PENJUALAN ASLI
    Private Sub ViewDataMaster(KodeFaktur As String)
        If String.IsNullOrWhiteSpace(KodeFaktur) Then Exit Sub

        Dim _view As New fr_jual_detail
        Me.Cursor = Cursors.WaitCursor
        _view.doLoadView(KodeFaktur)
        Me.Cursor = Cursors.Default
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
                    q = "SELECT ROUND(b_hargajual_nilai,2) FROM data_barang_hargajual " _
                        & "WHERE b_hargajual_status=1 AND b_hargajual_barang='{0}' AND b_hargajual_jenisharga='{1}'"
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
                Dim _pajak As String = IIf(LCase(in_jenispajak.Text) = "non-pajak", 0, 1)
                If _SupplierBased Then
                    q = "SELECT barang_kode Kode, barang_nama Nama, barang_pajak Pajak FROM data_barang_master " _
                        & "WHERE (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%') AND barang_supplier='{1}' LIMIT 250"
                    q = String.Format(q, "{0}", _SupplierCode)
                Else
                    q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama' FROM data_barang_master " _
                        & "WHERE (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%') AND barang_pajak='{1}' LIMIT 250"
                    q = String.Format(q, "{0}", _pajak)
                End If
            Case Else
                Exit Sub
        End Select

        Me.Cursor = Cursors.WaitCursor
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                consoleWriteLine(q)
                dt = x.GetDataTable(String.Format(q, param))
            Else
                Me.Cursor = Cursors.Default : Exit Sub
            End If
        End Using
        Me.Cursor = Cursors.Default

        With dgv_listbarang
            .DataSource = dt
            If .ColumnCount >= 2 Then
                .Columns(0).Width = 100 : .Columns(1).Width = 150
                If _SupplierBased Then .Columns(2).Visible = False
                .Columns(.DisplayedColumnCount(False) - 1).AutoSizeMode = IIf(.DisplayedColumnCount(False) <= 3, DataGridViewAutoSizeColumnMode.Fill, DataGridViewAutoSizeColumnMode.NotSet)
            End If
        End With
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult(ResType As String)
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case ResType
                Case "barang"
                    If _SupplierBased Then
                        If .Cells(2).Value = 0 Then
                            Dim _resMsg = MessageBox.Show("Barang terpilih merupakan barang non-pajak, lanjutkan input?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            If _resMsg = Windows.Forms.DialogResult.No Then Exit Sub
                        End If
                    End If
                    in_barang.Text = .Cells(0).Value
                    in_barang_nm.Text = .Cells(1).Value
                    loadSatuanBrg(in_barang.Text)
                    in_harga_beli.Value = getHargaBarang(in_barang.Text, jeniscusto)
                    in_qty.Focus()

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
            in_barang.Focus() : Exit Sub
        End If
        If in_qty.Value = 0 Then
            in_qty.Focus() : Exit Sub
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
                .Cells("discrp").Value = in_discrp.Value
                .Cells("disc1").Value = in_disc1.Value
                .Cells("disc2").Value = in_disc2.Value
                .Cells("disc3").Value = in_disc3.Value
                .Cells("disc4").Value = in_disc4.Value
                .Cells("disc5").Value = in_disc5.Value
                .Cells("jml").Value = removeCommaThousand(in_subtotal.Text)
            End With
        End With

        countBiaya()
        clearInputBarang()
        in_barang_nm.Clear()
        in_barang.Focus()
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
        countBiaya()
        in_qty.Focus()
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

        If _JenisPajak = 2 Then
            pajak = netto * 0.1 : netto += pajak
        ElseIf _JenisPajak = 1 Then
            pajak = (subtotal * (1 - 10 / 11)) - (diskon * (1 - 10 / 11))
        Else
            pajak = 0
        End If

        in_jumlah.Text = commaThousand(subtotal)
        in_diskon.Text = commaThousand(diskon)
        in_ppn_tot.Text = commaThousand(pajak)
        in_total.Text = commaThousand(subtotal - diskon)
        in_netto.Text = commaThousand(netto)
        in_sisa.Text = commaThousand(netto - removeCommaThousand(in_bayar.Text))
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
        If String.IsNullOrWhiteSpace(_IdFaktur) Or _IdFaktur = 0 Then Exit Sub

        Dim dataBrg, dataHead As String()
        Dim querycheck As Boolean = False
        Dim queryArr As New List(Of String)
        Dim q As String = ""

        '==========================================================================================================================
        dataHead = {
            "e_list_kodepajak='" & in_pajak.Text & "'",
            "e_list_tglpajak='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'"
            }

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                'START OF INSERT UPDATE HEADER ====================================================================================================
                q = "UPDATE data_penjualan_efak_list SET {0} WHERE e_list_id={1}"
                queryArr.Add(String.Format(q, String.Join(",", dataHead), _IdFaktur))
                'END OF INSERT UPDATE HEADER ======================================================================================================

                'START OF INSERT UPDATE BARANG ====================================================================================================
                q = "UPDATE data_penjualan_efak_list_detail SET e_list_det_status=9 WHERE e_list_det_idlist={0}"
                queryArr.Add(String.Format(q, _IdFaktur))

                Dim _ckbarang As Boolean = True
                Dim _brg As New List(Of String)
                For Each rows As DataGridViewRow In dgv_barang.Rows
                    Dim _kdbrg As String = rows.Cells(0).Value

                    dataBrg = {
                       "e_list_det_kodebrg='" & _kdbrg & "'",
                       "e_list_det_hargajual='" & Decimal.Parse(rows.Cells("harga").Value).ToString.Replace(",", ".") & "'",
                       "e_list_det_qty='" & rows.Cells("qty").Value & "'",
                       "e_list_det_satuan='" & rows.Cells("sat").Value & "'",
                       "e_list_det_satuan_type='" & rows.Cells("sat_type").Value & "'",
                       "e_list_det_disc1='" & Decimal.Parse(rows.Cells("disc1").Value).ToString.Replace(",", ".") & "'",
                       "e_list_det_disc2='" & Decimal.Parse(rows.Cells("disc2").Value).ToString.Replace(",", ".") & "'",
                       "e_list_det_disc3='" & Decimal.Parse(rows.Cells("disc3").Value).ToString.Replace(",", ".") & "'",
                       "e_list_det_disc4='" & Decimal.Parse(rows.Cells("disc4").Value).ToString.Replace(",", ".") & "'",
                       "e_list_det_disc5='" & Decimal.Parse(rows.Cells("disc5").Value).ToString.Replace(",", ".") & "'",
                       "e_list_det_disc_rupiah='" & Decimal.Parse(rows.Cells("discrp").Value).ToString.Replace(",", ".") & "'",
                       "e_list_det_jumlah='" & Decimal.Parse(rows.Cells("jml").Value).ToString.Replace(",", ".") & "'",
                       "e_list_det_status=1",
                       "e_list_det_reg_date=NOW()",
                       "e_list_det_reg_alias='" & loggeduser.user_id & "'"
                       }
                    q = "INSERT INTO data_penjualan_efak_list_detail SET e_list_det_idlist={0},{1}"
                    queryArr.Add(String.Format(q, _IdFaktur, String.Join(",", dataBrg)))

                Next
                'END OF INSERT UPDATE BARANG ======================================================================================================

                querycheck = x.TransactCommand(queryArr)
            End If
        End Using
        '==========================================================================================================================

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            MessageBox.Show("Data tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            DoRefreshTab_v2({pgexportEFak}) : Me.Close()
        End If
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
        Me.Close()
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

    Private Sub mn_viewmaster_Click(sender As Object, e As EventArgs) Handles mn_viewmaster.Click
        If Not String.IsNullOrWhiteSpace(in_faktur.Text) Then ViewDataMaster(in_faktur.Text)
    End Sub

    Private Sub mn_reinput_Click(sender As Object, e As EventArgs) Handles mn_reinput.Click
        LoadDataMaster(in_faktur.Text)
    End Sub

    'LOAD
    Private Sub fr_jual_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv_barang.ClearSelection()
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

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        Dim x As TextBox
        Select Case popupstate
            Case "barang" : x = in_barang_nm
            Case Else : Exit Sub
        End Select
        PopUpSearchKeyPress(e, x)
    End Sub

    'UI : COMBOBOX
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_sat.KeyPress
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    '------------- numeric
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_discrp.Enter, in_disc3.Enter, in_disc2.Enter, in_disc1.Enter, in_disc4.Enter, in_disc5.Enter, in_harga_beli.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_discrp.Leave, in_disc3.Leave, in_disc2.Leave, in_disc1.Leave, in_disc4.Leave, in_disc5.Leave, in_harga_beli.Leave
        If {"in_term", "in_qty"}.Contains(sender.Name) Then
            numericLostFocus(sender, "N0")
        Else
            numericLostFocus(sender)
        End If
    End Sub

    'UI : BUTTON
    Private Sub bt_simpanjual_Click(sender As Object, e As EventArgs) Handles bt_simpanjual.Click
        'CHECK INPUT BARANG
        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum di input", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_barang.Focus() : Exit Sub
        End If

        If date_tgl_pajak.Value < _PeriodePajak Then
            MessageBox.Show("Tanggal pajak lebih kecil dari periode pajak terpilih.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            date_tgl_pajak.Focus() : Exit Sub
        ElseIf date_tgl_pajak.Value > DateSerial(_PeriodePajak.Year, _PeriodePajak.Month + 1, 0) Then
            MessageBox.Show("Tanggal pajak lebih besar dari periode pajak terpilih.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            date_tgl_pajak.Focus() : Exit Sub
        End If

        Dim _askres As DialogResult = Windows.Forms.DialogResult.Yes
        If Not String.IsNullOrWhiteSpace(in_pajak.Text) Then
            If Not in_pajak.Text Like "###.###-##.########" Then
                _askres = MessageBox.Show("Format No. Pajak tidak sesuai. Lanjutkan perubahan data?", "Export EFaktur", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If _askres = Windows.Forms.DialogResult.No Then Exit Sub
            End If
        End If

        _askres = MessageBox.Show("Simpan perubahan data penjualan?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _askres = Windows.Forms.DialogResult.Yes Then
            Dim _k As Boolean = False
            Using _x As New fr_tutupconfirm_dialog With {.Text = "Kofirmasi Edit"}
                _x.doLoadConfirm(loggeduser.user_id)
                _k = _x.returnval.Key
            End Using
            If _k Then saveData()
        End If
    End Sub

    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        txtToDgv()
    End Sub

    'UI : BARANG
    Private Sub in_barang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_barang.KeyUp
        keyshortenter(in_barang_nm, e)
    End Sub

    Private Sub in_sales_n_Enter(sender As Object, e As EventArgs) Handles in_barang_nm.Enter
        If sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
            If popPnl_barang.Visible = False Then popPnl_barang.Visible = True
            If sender.Name = "in_barang_nm" Then
                popupstate = "barang"
                popPnl_barang.Width = 386
            End If
            loadDataBRGPopup(popupstate, sender.Text)
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_barang_nm.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_sales_n_MouseClick(sender As Object, e As MouseEventArgs) Handles in_barang_nm.MouseClick
        If popPnl_barang.Visible = False And sender.ReadOnly = False Then popPnl_barang.Visible = True
    End Sub

    Private Sub in_supplier_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang_nm.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub in_barang_nm_KeyUp(sender As Object, e As KeyEventArgs) Handles in_barang_nm.KeyUp
        Dim _id As TextBox : Dim _next As Control : Dim _result As String = ""

        Select Case sender.Name
            Case "in_barang_nm" : _id = in_barang : _next = in_qty
            Case Else : Exit Sub
        End Select
        _result = popupstate

        Dim _x = PopUpSearchInputHandle_inputKeyup(e, sender, _id, popPnl_barang, dgv_listbarang)
        For Each _resp As String In _x
            Select Case _resp
                Case "set" : setPopUpResult(_result)
                Case "next" : keyshortenter(_next, e)
                Case "load" : loadDataBRGPopup(popupstate, sender.Text)
            End Select
        Next
    End Sub

    Private Sub in_qty_KeyUp(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
        keyshortenter(cb_sat, e)
    End Sub

    Private Sub in_harga_beli_ValueChanged(sender As Object, e As EventArgs) Handles in_qty.ValueChanged, in_harga_beli.ValueChanged, in_disc1.ValueChanged, in_disc2.ValueChanged, in_disc3.ValueChanged, in_disc4.ValueChanged, in_disc5.ValueChanged, in_discrp.ValueChanged
        Dim total As Decimal = in_qty.Value * in_harga_beli.Value

        If in_discrp.Value <> 0 Then
            total -= in_discrp.Value * in_qty.Value
        End If

        For Each x As Decimal In {in_disc1.Value, in_disc2.Value, in_disc3.Value, in_disc4.Value, in_disc5.Value}
            If x <> 0 Then total = total * (1 - x / 100)
        Next

        in_subtotal.Text = commaThousand(total)
    End Sub

    Private Sub cb_sat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_sat.SelectionChangeCommitted
        If cb_sat.SelectedIndex > -1 Then
            in_harga_beli.Value = countHarga(_satuanstate, in_harga_beli.Value, cb_sat.SelectedValue)
            _satuanstate = cb_sat.SelectedValue
        End If
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

    Private Sub in_bayar_KeyUp(sender As Object, e As KeyEventArgs)
        keyshortenter(bt_simpanjual, e)
    End Sub

    'DGV
    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex > -1 Then
            dgvToTxt()
            dgv_barang.ClearSelection()
        End If
    End Sub

    Private Sub fr_jual_detail_Click(sender As Object, e As EventArgs) Handles MyBase.Click, pnl_content.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub
End Class