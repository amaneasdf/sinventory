Public Class fr_pesan_detail
    'note
    'penjualana bisa untuk input & validasi -> hutang custo
    'alur so -> sales>validasi>admin>gudang

    Private jeniscusto As String
    Public tjlStatus As String = 0
    Private popupstate As String = "barang"
    Private isibesar As Integer = 0
    Private isitengah As Integer = 0
    Private _satuanstate As String = "kecil"
    Private term As Integer = 0
    Private state As String = "order"


    Private Sub loadDataFaktur(kode As String)
        Dim q As String = "SELECT j_order_kode,j_order_tanggal_trans,j_order_sales,salesman_nama,j_order_customer,customer_nama,customer_kriteria_harga_jual, " _
                          & "j_order_term, j_order_catatan, j_order_status,j_order_gudang,gudang_nama,j_order_reg_date,j_order_reg_alias, " _
                          & "j_order_upd_date,j_order_upd_alias,j_order_valid_date,j_order_valid_alias,j_order_ref_faktur " _
                          & "FROM data_penjualan_order_faktur " _
                          & "LEFT JOIN data_customer_master ON j_order_customer=customer_kode " _
                          & "LEFT JOIN data_barang_gudang ON j_order_gudang=gudang_kode " _
                          & "LEFT JOIN data_salesman_master ON j_order_sales=salesman_kode " _
                          & "WHERE j_order_kode='{0}'"

        op_con()
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            in_faktur.Text = kode
            date_tgl_beli.Value = rd.Item("j_order_tanggal_trans")
            in_gudang.Text = rd.Item("j_order_gudang")
            in_gudang_n.Text = rd.Item("gudang_nama")
            in_sales.Text = rd.Item("j_order_sales")
            in_sales_n.Text = rd.Item("salesman_nama")
            in_custo.Text = rd.Item("j_order_customer")
            in_custo_n.Text = rd.Item("customer_nama")
            jeniscusto = rd.Item("customer_kriteria_harga_jual")
            cb_term.SelectedValue = If(rd.Item("j_order_term") > 0, 1, 0)
            in_ket.Text = rd.Item("j_order_catatan")
            tjlStatus = rd.Item("j_order_status")
            txtRegAlias.Text = rd.Item("j_order_reg_alias")
            txtRegdate.Text = rd.Item("j_order_reg_date")
            Try
                txtUpdDate.Text = rd.Item("j_order_upd_date")
            Catch ex As Exception
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("j_order_upd_alias")
            Try
                txtValDate.Text = rd.Item("j_order_valid_date")
            Catch ex As Exception
                txtValDate.Text = "00/00/0000 00:00:00"
            End Try
            txtValAlias.Text = rd.Item("j_order_valid_alias")
            in_ref_faktur.Text = rd.Item("j_order_ref_faktur")
        End If
        rd.Close()

        setStatus()
        If in_ref_faktur.Text <> Nothing Then
            mn_createjual.Enabled = False
        Else
            mn_createjual.Enabled = True
        End If
    End Sub

    Private Sub loadDataBarang(faktur As String)
        Dim dt As New DataTable
        Dim q As String = "SELECT j_order_trans_barang, barang_nama, j_order_trans_harga_jual, j_order_trans_qty, j_order_trans_satuan, " _
                            & "j_order_trans_disc1, j_order_trans_disc2, j_order_trans_disc3, j_order_trans_disc4, j_order_trans_disc5, " _
                            & "j_order_trans_disc_rupiah, j_order_trans_jumlah, j_order_trans_satuan_type,j_order_trans_valid_status, " _
                            & "@qtypsn:=getStockPesan('{1}',j_order_trans_barang, j_order_gudang), " _
                            & "@qtysys:=getSisaStock('{1}',j_order_trans_barang, j_order_gudang), " _
                            & "getQTYDetail(j_order_trans_barang, @qtysys-@qtypsn, 1), " _
                            & "getQTYDetail(j_order_trans_barang, @qtypsn, 1), " _
                            & "getQtyDetail(j_order_trans_barang, @qtysys, 1) " _
                            & "FROM data_penjualan_order_faktur " _
                            & "LEFT JOIN data_penjualan_order_trans ON j_order_trans_faktur=j_order_kode AND j_order_trans_status=1 " _
                            & "INNER JOIN data_barang_master ON barang_kode = j_order_trans_barang " _
                            & "JOIN (SELECT @qtypsn:=0,@qtysys:=0) para " _
                            & "WHERE j_order_kode='{0}'"
        dt = getDataTablefromDB(String.Format(q, faktur, selectperiode.id))
        With dgv_barang.Rows
            For Each rows As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("kode").Value = rows.ItemArray(0)
                    .Cells("nama").Value = rows.ItemArray(1)
                    .Cells("nama").ToolTipText = rows.ItemArray(0)
                    .Cells("harga").Value = rows.ItemArray(2)
                    .Cells("qty").Value = rows.ItemArray(3)
                    .Cells("sat").Value = rows.ItemArray(4)
                    .Cells("disc1").Value = rows.ItemArray(5)
                    .Cells("disc2").Value = rows.ItemArray(6)
                    .Cells("disc3").Value = rows.ItemArray(7)
                    .Cells("disc4").Value = rows.ItemArray(8)
                    .Cells("disc5").Value = rows.ItemArray(9)
                    .Cells("discrp").Value = rows.ItemArray(10)
                    .Cells("jml").Value = rows.ItemArray(11)
                    .Cells("sat_type").Value = rows.ItemArray(12)
                    .Cells("subtotal").Value = rows.ItemArray(2) * rows.ItemArray(3)
                    .Cells("valid_ck").Value = IIf(rows.ItemArray(13) = 0, 0, 1)
                    .Cells("qty_sisa").Value = rows.ItemArray(16)
                    .Cells("qty_sisa").ToolTipText = "Pesan : " & rows.ItemArray(17) & Environment.NewLine _
                                                    & "Stock : " & rows.ItemArray(18)

                End With
            Next
        End With
        dt.Dispose()

        countBiaya()
    End Sub

    Private Sub setStatus()
        Dim stattext As String = ""
        Dim savebt_sw As Boolean = True

        Select Case tjlStatus
            Case 0
                stattext = "Pending"
            Case 1
                stattext = "Approved"
            Case 2
                stattext = "Tolak"
            Case 9
                stattext = "Delete"
            Case Else
                stattext = "ERROR"
        End Select

        If tjlStatus <> 0 Then
            savebt_sw = False
        End If
        If loggeduser.allowedit_transact = False And bt_simpanjual.Text <> "Update" Then
            savebt_sw = False
        End If

        bt_simpanjual.Enabled = savebt_sw
        bt_createjual.Enabled = savebt_sw
        in_status.Text = stattext
        cb_status.SelectedValue = tjlStatus
        cb_status.Enabled = savebt_sw

        If tjlStatus <> 1 Then
            mn_createjual.Enabled = False
        End If
    End Sub

    Private Sub setForm(ss As String)
        Dim _k As String = LCase(ss)
        Dim _input_sw As Boolean = False

        Select Case _k
            Case "order"
                With dgv_barang
                    .Location = New Point(12, 146)
                    .Height = 163
                End With
                valid_ck.Visible = False
                valid_ck.ReadOnly = True
                bt_tbbarang.Visible = True
                in_status.Visible = True
                cb_status.Visible = False
                bt_simpanjual.Visible = True
                bt_createjual.Visible = False
                qty_sisa.Visible = False
            Case "valid"
                With dgv_barang
                    .Location = New Point(12, 101)
                    .Height = 208
                End With
                valid_ck.Visible = True
                valid_ck.ReadOnly = False
                bt_tbbarang.Visible = False
                _input_sw = True
                in_status.Visible = False
                cb_status.Visible = True
                bt_simpanjual.Visible = False
                bt_createjual.Visible = True
                qty_sisa.Visible = True
                kode.Visible = False
        End Select
        in_sales_n.ReadOnly = _input_sw
        in_custo_n.ReadOnly = _input_sw
        in_gudang_n.ReadOnly = _input_sw
        state = _k
    End Sub

    'LOAD SATUAN
    Private Sub loadSatuanBrg(kode As String)
        op_con()
        Dim dt As New DataTable
        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        readcommd("SELECT barang_satuan_kecil, barang_satuan_tengah, barang_satuan_besar, " _
                          & "barang_satuan_tengah_jumlah, barang_satuan_besar_jumlah FROM data_barang_master WHERE barang_kode='" & kode & "'")
        With dt.Rows
            If rd.HasRows Then
                .Add(rd.Item("barang_satuan_kecil"), "kecil")
                .Add(rd.Item("barang_satuan_tengah"), "tengah")
                .Add(rd.Item("barang_satuan_besar"), "besar")
                isibesar = rd.Item("barang_satuan_besar_jumlah")
                isitengah = rd.Item("barang_satuan_tengah_jumlah")
            End If
        End With
        rd.Close()
        'cb_sat.DataSource.Clear()
        cb_sat.DataSource = dt
        cb_sat.DisplayMember = "Text"
        cb_sat.ValueMember = "Value"
        cb_sat.SelectedIndex = 2
        _satuanstate = cb_sat.SelectedValue
        'rd.Close()
    End Sub

    'COUNT PRICE
    Private Function countHarga(state As String, hargaawal As Decimal, convState As String) As Decimal
        Dim retHarga As Decimal = 0
        Dim isi As Integer = 0

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

    'POPUP PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        setDoubleBuffered(Me.dgv_listbarang, True)
        Dim q As String
        Dim dt As New DataTable
        Dim autoco As New AutoCompleteStringCollection
        Select Case tipe
            Case "barang"
                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama', b_hargajual_nilai, barang_harga_jual_d1, barang_harga_jual_d2, " _
                    & "barang_harga_jual_d3, barang_harga_jual_d4, barang_harga_jual_d5, barang_harga_jual_discount " _
                    & "FROM data_barang_master " _
                    & "RIGHT JOIN data_stok_awal ON stock_barang=barang_kode AND stock_gudang='" & in_gudang.Text & "' " _
                    & "LEFT JOIN data_barang_hargajual ON barang_kode=b_hargajual_barang AND b_hargajual_jenisharga='{0}' " _
                    & "WHERE barang_nama LIKE '{1}' GROUP BY barang_kode LIMIT 250"
                q = String.Format(q, jeniscusto, "{0}%")
            Case "custo"
                q = "SELECT customer_kode AS 'Kode', customer_nama AS 'Nama', customer_term, customer_kriteria_harga_jual FROM data_customer_master WHERE customer_status=1 AND customer_nama LIKE '{0}%'"
            Case "gudang"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang WHERE gudang_status=1 AND gudang_nama LIKE '{0}%'"
            Case "sales"
                q = "SELECT salesman_kode AS 'Kode', salesman_nama AS 'Nama' FROM data_salesman_master WHERE salesman_status=1 AND salesman_nama LIKE '{0}%'"
            Case Else
                Exit Sub
        End Select

        consoleWriteLine(String.Format(q, param))
        dt = getDataTablefromDB(String.Format(q, param))

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 135
            .Columns(1).Width = 200
            If tipe = "barang" Or tipe = "custo" Then
                For i = 2 To IIf(tipe = "custo", 3, 8)
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
                    in_barang.Text = .Cells(0).Value
                    in_barang_nm.Text = .Cells(1).Value
                    in_harga_beli.Value = .Cells(2).Value
                    in_disc1.Value = .Cells(3).Value
                    in_disc2.Value = .Cells(4).Value
                    in_disc3.Value = .Cells(5).Value
                    in_disc4.Value = .Cells(6).Value
                    in_disc5.Value = .Cells(7).Value
                    loadSatuanBrg(in_barang.Text)
                    in_qty.Focus()
                Case "custo"
                    in_custo.Text = .Cells(0).Value
                    in_custo_n.Text = .Cells(1).Value
                    jeniscusto = .Cells(3).Value
                    'in_term.Value = .Cells(2).Value
                    in_gudang_n.Focus()
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    bt_simpanjual.Focus()
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

    'INPUT DATA TO DGV FR TEXTBOX
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

        Dim total As Double = removeCommaThousand(in_subtotal.Text)

        For Each x As Double In {in_disc1.Value, in_disc2.Value, in_disc3.Value, in_disc4.Value, in_disc5.Value}
            If x <> 0 Then
                Dim y As Double = total
                total = y * (1 - x / 100)
            Else
                total = total
            End If
        Next

        If in_discrp.Value <> 0 Then
            total -= in_discrp.Value * in_qty.Value
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

    Private Sub countBiaya()
        Dim subtotal As Double = 0
        Dim y As Double = 0
        Dim diskon As Double = 0

        For Each rows As DataGridViewRow In dgv_barang.Rows
            subtotal += rows.Cells("subtotal").Value
        Next

        For Each row As DataGridViewRow In dgv_barang.Rows
            diskon += row.Cells("subtotal").Value - row.Cells("jml").Value
        Next

        y = subtotal - diskon

        Dim cc As Globalization.CultureInfo = Globalization.CultureInfo.GetCultureInfo("id-ID")
        in_jumlah.Text = subtotal.ToString("N2", cc)
        in_diskon.Text = commaThousand(diskon)
        in_total.Text = commaThousand(y)
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
        op_con()

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
        Dim x As New List(Of String)
        Dim x_kodestock As New List(Of String)
        Dim qty As New List(Of Integer)
        Dim nilai As New List(Of Double)

        '==========================================================================================================================
        q = "UPDATE data_penjualan_order_trans SET j_order_trans_status=9 WHERE j_order_trans_faktur='{0}';"
        queryArr.Add(String.Format(q, in_faktur.Text))
        '==========================================================================================================================

        '==========================================================================================================================
        Dim kode As String = IIf(in_faktur.Text = "", "@id", in_faktur.Text)
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
                "'" & rows.Cells("harga").Value & "'",
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
        querycheck = startTrans(queryArr)
        '==========================================================================================================================

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            doRefreshTab({pgpesanjual})
            Me.Close()
        End If
    End Sub

    'CREATE PENJUALAN
    Private Sub validOrder()
        op_con()

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
                "j_order_status='" & tjlStatus & "'",
                "j_order_term='" & cb_term.SelectedValue & "'",
                "j_order_catatan='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'"
                }
        queryArr.Add(String.Format(q, in_faktur.Text, String.Join(",", dataHead), txtValAlias.Text))
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
        querycheck = startTrans(queryArr)
        '==========================================================================================================================

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            doRefreshTab({pgpesanjual})
            If tjlStatus = 1 Then
                If MessageBox.Show("Buat transaksi penjualan berdasarkan pesanan yg sudah divalidasi?", "Validasi Order Penjualan",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    createJual()
                End If
            End If
            Me.Close()
        End If
    End Sub

    Private Sub createJual()
        Dim newJual As New fr_jual_detail
        Dim q As String = ""
        Dim term As Integer = 0

        op_con()
        If cb_term.SelectedValue = 1 Then
            q = "SELECT customer_term FROM data_customer_master WHERE customer_kode='{0}'"
            readcommd(String.Format(q, in_custo.Text))
            If rd.HasRows Then
                term = rd.Item(0)
            End If
            rd.Close()
        End If

        With newJual
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
            .in_custo_n.ReadOnly = True
            'GUDANG
            .in_gudang.Text = in_gudang.Text
            .in_gudang_n.Text = in_gudang_n.Text
            'BARANG
            For Each rows As DataGridViewRow In dgv_barang.Rows
                If rows.Cells("valid_ck").Value = 1 Then
                    With .dgv_barang.Rows
                        Dim x As Integer = .Add
                        With .Item(x)
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
            .Show(main)
        End With
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

    'LOAD
    Public Sub doLoad(Optional saleskode As String = "", Optional state As String = "order")
        If saleskode <> "" Then
            in_sales_n.Text = getSales(saleskode)
            in_sales.Text = IIf(in_sales_n.Text <> Nothing, saleskode, "")
        End If

        For Each x As DateTimePicker In {date_tgl_beli}
            x.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
            x.MaxDate = selectperiode.tglakhir
            'x.MinDate = selectperiode.tglawal
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

        With dgv_barang
            For Each x As DataGridViewColumn In {harga, discrp, jml, subtotal}
                x.DefaultCellStyle = dgvstyle_currency
            Next
        End With

        setForm(state)

        If bt_simpanjual.Text = "Update" Then
            loadDataFaktur(in_faktur.Text)
            loadDataBarang(in_faktur.Text)
            With in_faktur
                .ReadOnly = True
            End With
        End If

        setStatus()
    End Sub

    Private Function getSales(kode As String) As String
        Dim ret As String = ""
        Dim q As String = "SELECT salesman_nama FROM data_salesman_master WHERE salesman_kode='{0}'"

        op_con()
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            ret = rd.Item(0)
        End If
        rd.Close()

        Return ret
    End Function

    Private Sub fr_jual_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'SAVE
    Private Sub bt_simpanjual_Click(sender As Object, e As EventArgs) Handles bt_simpanjual.Click
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
        If date_tgl_beli.Value < selectperiode.tglawal Then
            MessageBox.Show("Tanggal transaksi lebih kecil daripada Jangka waktu periode terpilih")
            date_tgl_beli.Focus()
            Exit Sub
        End If
        If in_sales.Text = Nothing Then
            MessageBox.Show("Sales belum di input")
            in_sales_n.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan data pesanan?", "Order Penjualan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If loggeduser.saleskode = Nothing Or loggeduser.saleskode <> in_sales.Text Then
                If MessageBox.Show("Kode Sales yg anda miliki tidak sama dgn yang akan diinputkan, lanjutkan transaksi?", "Order Penjualan",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If
            saveData()
        End If
    End Sub

    'CREATE DATA JUAL
    Private Sub bt_createjual_Click(sender As Object, e As EventArgs) Handles bt_createjual.Click
        Dim ck_valitem As Boolean = False
        Dim valid As Boolean = False

        If tjlStatus <> cb_status.SelectedValue Then
            tjlStatus = cb_status.SelectedValue
        End If

        If cb_status.SelectedValue = Nothing Then
            MessageBox.Show("Status Validasi belum terpilih")
            dgv_barang.Focus()
            Exit Sub
        End If

        For Each rows As DataGridViewRow In dgv_barang.Rows
            If rows.Cells("valid_ck").Value = 1 Then
                ck_valitem = True
                Exit For
            End If
        Next
        If ck_valitem = False And tjlStatus = 1 Then
            MessageBox.Show("Barang belum terpilih")
            dgv_barang.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan validasi pesanan?", "Validasi Order Penjualan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Using x As New fr_jualconfirm_dialog
                With x
                    If loggeduser.validasi_trans = True Then
                        .in_user.Text = loggeduser.user_id
                    End If
                    .do_load("jual")
                    .in_user.Text = loggeduser.user_id
                    .in_pass.Focus()
                    .ShowDialog()
                    If .returnval = True Then
                        If loggeduser.user_id <> .in_user.Text Then
                            MessageBox.Show("User tidak sama dengan user yg anda gunakan untuk login. Pastikan anda menggunakan user yang sama untuk meakukan validasi",
                                            "Validasi Order Penjualan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        Else
                            in_ket.Text += IIf(in_ket.Text = Nothing, "", Environment.NewLine) & .in_ket.Text
                            txtValAlias.Text = loggeduser.user_id
                            valid = .returnval
                        End If
                    Else
                        Exit Sub
                    End If
                End With
            End Using
            If valid = True Then
                validOrder()
            End If
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

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            setPopUpResult()
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
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_sat.KeyPress, cb_term.KeyPress, cb_status.KeyPress
        If e.KeyChar <> ControlChars.Cr Then
            e.Handled = True
        End If
    End Sub

    '------------- numeric
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_discrp.Enter, in_disc3.Enter, in_disc2.Enter, in_disc1.Enter, in_disc4.Enter, in_disc5.Enter, in_harga_beli.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_discrp.Leave, in_disc3.Leave, in_disc2.Leave, in_disc1.Leave, in_disc4.Leave, in_disc5.Leave, in_harga_beli.Leave
        Select Case sender.Name.ToString
            Case "in_bayar", "in_harga_beli"
                numericLostFocus(sender)
            Case Else
                numericLostFocus(sender, "N0")
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

    Private Sub in_sales_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter
        If sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(in_sales_n.Left, in_sales_n.Top + in_sales_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
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

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(bt_simpanjual, e)
        Else
            If popPnl_barang.Visible = False And sender.ReadOnly = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("sales", in_sales_n.Text)
        End If
    End Sub

    Private Sub in_supplier_n_TextChanged(sender As Object, e As EventArgs) Handles in_sales_n.TextChanged
        If in_sales_n.Text = "" Then
            in_sales_n.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub in_custo_KeyUp(sender As Object, e As KeyEventArgs) Handles in_custo.KeyUp
        keyshortenter(in_custo_n, e)
    End Sub

    Private Sub in_custo_n_Enter(sender As Object, e As EventArgs) Handles in_custo_n.Enter
        If sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(in_custo_n.Left, in_custo_n.Top + in_custo_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            popupstate = "custo"
            loadDataBRGPopup("custo", in_custo_n.Text)
        End If
    End Sub

    Private Sub in_custo_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_custo_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(in_gudang_n, e)
        Else
            If popPnl_barang.Visible = False And sender.ReadOnly = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("custo", in_custo_n.Text)
        End If
    End Sub

    Private Sub in_custo_n_TextChanged(sender As Object, e As EventArgs) Handles in_custo_n.TextChanged
        If in_custo_n.Text = "" Then
            in_custo_n.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub in_gudang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyUp
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_gudang_n_Enter(sender As Object, e As EventArgs) Handles in_gudang_n.Enter
        If sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(in_gudang_n.Left, in_gudang_n.Top + in_gudang_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            popupstate = "gudang"
            loadDataBRGPopup("gudang", in_gudang_n.Text)
        End If
    End Sub

    Private Sub in_gudang_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(cb_term, e)
        Else
            If popPnl_barang.Visible = False And sender.ReadOnly = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("gudang", in_gudang_n.Text)
        End If
    End Sub

    Private Sub in_gudang_n_TextChanged(sender As Object, e As EventArgs) Handles in_gudang_n.TextChanged
        If in_gudang_n.Text = "" Then
            in_gudang_n.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub cb_term_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_term.KeyUp
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

    Private Sub in_barang_nm_Enter(sender As Object, e As EventArgs) Handles in_barang_nm.Enter
        popPnl_barang.Location = New Point(in_barang_nm.Left, in_barang_nm.Top + in_barang_nm.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "barang"
        loadDataBRGPopup("barang", in_barang_nm.Text)
    End Sub

    Private Sub in_barang_nm_KeyUp(sender As Object, e As KeyEventArgs) Handles in_barang_nm.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(in_qty, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("barang", in_barang_nm.Text)
        End If
    End Sub

    Private Sub in_barang_nm_TextChanged(sender As Object, e As EventArgs) Handles in_barang_nm.TextChanged
        If in_barang_nm.Text = "" Then
            in_barang.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub in_qty_KeyUp(sender As Object, e As KeyEventArgs) Handles in_qty.KeyUp
        keyshortenter(cb_sat, e)
    End Sub

    Private Sub in_harga_beli_ValueChanged(sender As Object, e As EventArgs) Handles in_qty.ValueChanged, in_harga_beli.ValueChanged, in_disc1.ValueChanged, in_disc2.ValueChanged, in_disc3.ValueChanged, in_disc4.ValueChanged, in_disc5.ValueChanged, in_discrp.ValueChanged
        'in_subtotal.Text = commaThousand(in_qty.Value * in_harga_beli.Value)
        Dim total As Double = in_qty.Value * in_harga_beli.Value

        For Each x As Double In {in_disc1.Value, in_disc2.Value, in_disc3.Value, in_disc4.Value, in_disc5.Value}
            If x <> 0 Then
                Dim y As Double = total
                total = y * (1 - x / 100)
            Else
                total = total
            End If
        Next

        If in_discrp.Value <> 0 Then
            total -= in_discrp.Value * in_qty.Value
        End If

        in_subtotal.Text = commaThousand(total)
    End Sub

    Private Sub cb_sat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_sat.SelectionChangeCommitted
        in_harga_beli.Value = countHarga(_satuanstate, in_harga_beli.Value, cb_sat.SelectedValue)
        _satuanstate = cb_sat.SelectedValue
    End Sub

    Private Sub cb_sat_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_sat.KeyUp
        keyshortenter(in_harga_beli, e)
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