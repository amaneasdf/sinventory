Public Class fr_jual_retur_detail
    Private indexrow As Integer = 0
    Private rtjstatus As String = "1"
    Private popupstate As String = ""
    Private _persediaan As Decimal = 0
    Private hargabesr As Decimal = 0
    Private isibesar As Integer = 0
    Private isitengah As Integer = 0
    Private _satuanstate As String = "kecil"

    Private Sub loadData(kode As String)
        Dim q As String = "SELECT faktur_kode_bukti, faktur_tanggal_trans, faktur_pajak_no, faktur_pajak_tanggal, faktur_kode_faktur, " _
                          & "faktur_kode_exfaktur,faktur_sebab, faktur_custo, customer_nama, faktur_gudang, gudang_nama, faktur_sales, salesman_nama, " _
                          & "faktur_jumlah, faktur_ppn_persen, faktur_ppn_jenis, faktur_netto, faktur_status, faktur_reg_date, " _
                          & "faktur_reg_alias, faktur_upd_date, faktur_upd_alias FROM data_penjualan_retur_faktur " _
                          & "LEFT JOIN data_customer_master ON customer_kode=faktur_custo " _
                          & "LEFT JOIN data_barang_gudang ON gudang_kode=faktur_gudang " _
                          & "LEFT JOIN data_salesman_master ON salesman_kode=faktur_sales " _
                          & "WHERE faktur_kode_bukti='{0}'"
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            in_no_bukti.Text = kode
            in_pajak.Text = rd.Item("faktur_pajak_no")
            date_tgl_trans.Value = rd.Item("faktur_tanggal_trans")
            date_tgl_pajak.Value = rd.Item("faktur_pajak_tanggal")
            in_no_faktur.Text = rd.Item("faktur_kode_faktur")
            in_no_faktur_ex.Text = rd.Item("faktur_kode_exfaktur")
            in_sales.Text = rd.Item("faktur_sales")
            in_sales_n.Text = rd.Item("salesman_nama")
            in_custo.Text = rd.Item("faktur_custo")
            in_custo_n.Text = rd.Item("customer_nama")
            in_gudang.Text = rd.Item("faktur_gudang")
            in_gudang_n.Text = rd.Item("gudang_nama")
            in_jumlah.Text = commaThousand(rd.Item("faktur_jumlah"))
            in_ppn_tot.Text = commaThousand(rd.Item("faktur_ppn_persen"))
            cb_ppn.SelectedValue = rd.Item("faktur_ppn_jenis")
            in_netto.Text = commaThousand(rd.Item("faktur_netto"))
            rtjstatus = rd.Item("faktur_status")
            txtRegAlias.Text = rd.Item("faktur_reg_alias")
            txtRegdate.Text = rd.Item("faktur_reg_date")
        End If
        rd.Close()
        setStatus()

        'If loggeduser.allowedit_transact = False Then
        If loggeduser.allowedit_transact = False Or currentperiode.id <> selectperiode.id Or (rtjstatus = 0 And loggeduser.validasi_trans = False) Then
            bt_simpanreturbeli.Enabled = False
        End If
        'End If

        'setReadOnly()
    End Sub

    Private Sub loadDataBrg(kode As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_retur, trans_qty, trans_satuan, " _
                                & "trans_satuan_type, trans_hpp, trans_diskon FROM data_penjualan_retur_trans " _
                                & "INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & kode & "' AND trans_status=1")
        With dgv_barang.Rows
            For Each rows As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("kode").Value = rows.ItemArray(0)
                    .Cells("nama").Value = rows.ItemArray(1)
                    .Cells("harga").Value = rows.ItemArray(2)
                    .Cells("qty").Value = rows.ItemArray(3)
                    .Cells("sat_type").Value = rows.ItemArray(5)
                    .Cells("sat").Value = rows.ItemArray(4)
                    .Cells("subtotal").Value = rows.ItemArray(3) * rows.ItemArray(2)
                    .Cells("brg_hpp").Value = rows.ItemArray(6)
                    .Cells("diskon").Value = rows.ItemArray(7)
                    .Cells("jml").Value = .Cells("subtotal").Value * (1 - (rows.ItemArray(7) / 100))
                End With
            Next
        End With
        dt.Dispose()
    End Sub

    Private Sub setStatus()
        Select Case rtjstatus
            Case 0
                in_status.Text = "Non-Aktif"
            Case 1
                in_status.Text = "Aktif"
            Case 9
                in_status.Text = "Delete"
            Case Else
                Exit Sub
        End Select
    End Sub

    'SET SATUAN BARANG
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
                Return retHarga
                Exit Function
        End Select

        Return retHarga
    End Function

    'COUNT SUBTOTAL
    Private Function countSubtot(harga As Double, qty As Integer, Optional disk As Double = 0) As Double
        Dim retSubtot As Double = 0
        Dim _jl As Double = 0
        Dim _disk As Double = 0

        _jl = harga * qty
        _disk = _jl * (disk / 100)
        retSubtot = _jl - _disk

        Return retSubtot
    End Function

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, param As String)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "barang"
                q = "SELECT barang_kode as 'Kode', barang_nama as 'Nama', IF(trans_harga_jual=0,AVG(trans_harga_jual),trans_harga_jual) as harga_jual " _
                    & "FROM data_penjualan_trans LEFT JOIN data_penjualan_faktur ON faktur_kode=trans_faktur AND faktur_status=1 " _
                    & "LEFT JOIN data_barang_master ON trans_barang=barang_kode AND trans_status=1 " _
                    & "WHERE trans_status=1 AND faktur_customer='" & in_custo.Text & "' AND barang_nama LIKE '{0}%' " _
                    & "GROUP BY barang_kode LIMIT 250"
            Case "custo"
                q = "SELECT customer_kode AS 'Kode', customer_nama AS 'Nama' FROM data_customer_master WHERE customer_status=1 AND customer_nama LIKE '{0}%'"
            Case "gudang"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang WHERE gudang_status=1 AND gudang_nama LIKE '{0}%'"
            Case "sales"
                q = "SELECT salesman_kode AS 'Kode', salesman_nama AS 'Nama' FROM data_salesman_master WHERE salesman_status=1 AND salesman_nama LIKE '{0}%'"
            Case "faktur"
                q = "SELECT piutang_faktur AS 'faktur', piutang_awal AS 'SaldoAwal', getSisaPiutang(piutang_faktur,'" & selectperiode.id & "') as 'SisaPiutang' " _
                    & "FROM data_piutang_awal LEFT JOIN data_penjualan_faktur ON faktur_kode=piutang_faktur AND faktur_status=1 " _
                    & "WHERE piutang_idperiode='" & selectperiode.id & "' AND piutang_status=1 AND faktur_customer='" & in_custo.Text & "' " _
                    & "AND piutang_faktur LIKE '{0}%' AND faktur_sales LIKE '" & in_sales.Text & "%'"
                'q = "SELECT hutang_faktur AS 'Faktur', hutang_awal AS 'SaldoAwal', getSisaHutang(hutang_faktur,'" & selectperiode.id & "') as 'SisaHutang' " _
                '    & "FROM data_hutang_awal LEFT JOIN data_pembelian_faktur ON faktur_kode=hutang_faktur AND faktur_status=1 " _
                '    & "WHERE hutang_idperiode='" & selectperiode.id & "' AND hutang_status=1 AND faktur_supplier='" & in_supplier.Text & "' " _
                '    & "AND hutang_faktur LIKE '{0}%'"
            Case Else
                Exit Sub
        End Select
        consoleWriteLine(String.Format(q, param))
        dt = getDataTablefromDB(String.Format(q, param))

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 135
            .Columns(1).Width = 200
            If tipe = "barang" Then
                .Columns(2).Visible = False
            ElseIf tipe = "faktur" Then
                .Columns(1).Width = 80
                .Columns(2).Width = 125
                .Columns(2).DefaultCellStyle = dgvstyle_currency
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
                    in_harga_retur.Value = .Cells(2).Value
                    loadSatuanBrg(in_barang.Text)
                    in_qty.Focus()
                Case "custo"
                    in_custo.Text = .Cells(0).Value
                    in_custo_n.Text = .Cells(1).Value
                    in_gudang_n.Focus()
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    in_sales_n.Focus()
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    cb_bayar_jenis.Focus()
                Case "faktur"
                    in_no_faktur.Text = .Cells(0).Value
                    in_barang.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
    End Sub

    'INPUT DATA TO DGV FR TEXTBOX
    Private Sub textToDgv()
        If Trim(in_barang_nm.Text) = Nothing Then
            in_barang.Focus()
            Exit Sub
        End If
        If in_qty.Value = 0 Then
            in_qty.Focus()
            Exit Sub
        End If

        Dim hpp As Double = 0

        op_con()
        readcommd("SELECT getHPP('" & in_barang.Text & "')")
        If rd.HasRows Then
            hpp = rd.Item(0)
        End If
        rd.Close()

        With dgv_barang.Rows
            Dim x As Integer = .Add
            With .Item(x)
                .Cells("kode").Value = in_barang.Text
                .Cells("nama").Value = in_barang_nm.Text
                .Cells("qty").Value = in_qty.Value
                .Cells("sat").Value = cb_sat.Text
                .Cells("sat_type").Value = cb_sat.SelectedValue
                .Cells("harga").Value = in_harga_retur.Value
                .Cells("subtotal").Value = in_harga_retur.Value * in_qty.Value
                .Cells("diskon").Value = in_diskon.Value
                .Cells("jml").Value = removeCommaThousand(in_subtotal.Text)
                .Cells("brg_hpp").Value = hpp
            End With
        End With

        countBiaya()
        clearInputBarang()

        in_custo_n.ReadOnly = True

        in_barang_nm.Clear()
        in_barang.Focus()
    End Sub

    Private Sub dgvToTxt()
        With dgv_barang.SelectedRows.Item(0)
            loadSatuanBrg(.Cells("kode").Value)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty.Value = .Cells("qty").Value
            in_diskon.Value = .Cells("diskon").Value
            cb_sat.SelectedValue = .Cells("sat_type").Value
            in_harga_retur.Text = .Cells("harga").Value
        End With

        If dgv_barang.RowCount = 0 Then
            in_custo_n.ReadOnly = False
        Else
            in_custo_n.ReadOnly = True
        End If
    End Sub

    Private Sub countBiaya()
        Dim subtot As Double = 0
        Dim pajak As Double = 0
        Dim z As Double = 0
        _persediaan = 0

        op_con()
        For Each rows As DataGridViewRow In dgv_barang.Rows
            Dim _qtytot As Integer = 0
            readcommd("SELECT countQTYItem('" & rows.Cells(0).Value & "'," & rows.Cells("qty").Value & ",'" & rows.Cells("sat_type").Value & "')")
            If rd.HasRows Then
                _qtytot = rd.Item(0)
            End If
            rd.Close()
            subtot += rows.Cells("jml").Value
            _persediaan += _qtytot * rows.Cells("brg_hpp").Value
        Next

        z = subtot

        If cb_ppn.SelectedValue = "1" Then
            'incl
            pajak = subtot * (1 - 10 / 11)
        ElseIf cb_ppn.SelectedValue = "0" Then
            'excl
            pajak = subtot * 0.1
            z = subtot + pajak
        Else
            pajak = 0
        End If

        Dim cc As Globalization.CultureInfo = Globalization.CultureInfo.GetCultureInfo("id-ID")
        in_jumlah.Text = subtot.ToString("N2", cc)
        in_netto.Text = z.ToString("N2", cc)
        in_ppn_tot.Text = pajak.ToString("N2", cc)
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
    End Sub

    'SAVE
    Private Sub saveData()
        Dim q As String = ""
        Dim querycheck As Boolean = False
        Dim dataHead, dataBrg As String()
        Dim data1, data2 As String()
        Dim queryArr As New List(Of String)

        '==========================================================================================================================
        'SAVE HEADER
        dataHead = {
            "faktur_tanggal_trans='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
            "faktur_pajak_no='" & in_pajak.Text & "'",
            "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
            "faktur_gudang='" & in_gudang.Text & "'",
            "faktur_custo='" & in_custo.Text & "'",
            "faktur_sales='" & in_sales.Text & "'",
            "faktur_kode_faktur='" & in_no_faktur.Text & "'",
            "faktur_kode_exfaktur='" & in_no_faktur_ex.Text & "'",
            "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text).ToString.Replace(",", ".") & "'",
            "faktur_ppn_persen='" & removeCommaThousand(in_ppn_tot.Text).ToString.Replace(",", ".") & "'",
            "faktur_ppn_jenis='" & cb_ppn.SelectedValue & "'",
            "faktur_netto='" & removeCommaThousand(in_netto.Text).ToString.Replace(",", ".") & "'",
            "faktur_jen_bayar='" & cb_bayar_jenis.SelectedValue & "'",
            "faktur_persediaan='" & _persediaan.ToString.Replace(",", ".") & "'",
            "faktur_sebab='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
            "faktur_status='" & rtjstatus & "'"
            }

        If bt_simpanreturbeli.Text = "Simpan" Then
            'GENERATE KODE
            If in_no_bukti.Text = Nothing Then
                Dim no As Integer = 1

                readcommd("SELECT COUNT(faktur_kode_bukti) FROM data_penjualan_retur_faktur WHERE SUBSTRING(faktur_kode_bukti,3,8)='" & date_tgl_trans.Value.ToString("yyyyMMdd") & "' AND faktur_kode_bukti LIKE 'RJ%'")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()

                in_no_bukti.Text = "RJ" & date_tgl_trans.Value.ToString("yyyyMMdd") & no.ToString("D3")
            ElseIf in_no_bukti.Text <> Nothing And bt_simpanreturbeli.Text <> "Update" Then
                If checkdata("data_penjualan_retur_faktur", "'" & in_no_bukti.Text & "'", "faktur_kode_bukti") = True Then
                    MessageBox.Show("Nomor faktur " & in_no_bukti.Text & " sudah pernah diinputkan", "Retur Penjualan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    in_no_bukti.Focus()
                    Exit Sub
                End If
            End If

            q = "INSERT INTO data_penjualan_retur_faktur SET faktur_kode_bukti='{0}',{1},faktur_reg_date=NOW(),faktur_reg_alias='{2}'"
        ElseIf bt_simpanreturbeli.Text = "Update" Then
            q = "UPDATE data_penjualan_retur_faktur SET {1},faktur_upd_date=NOW(), faktur_upd_alias='{2}' WHERE faktur_kode_bukti='{0}'"
        End If
        queryArr.Add(String.Format(q, in_no_bukti.Text, String.Join(",", dataHead), loggeduser.user_id))
        '==========================================================================================================================


        '==========================================================================================================================
        'INSERT BARANG
        Dim x As New List(Of String)
        Dim x_kodestock As New List(Of String)
        Dim qty As New List(Of Integer)
        Dim nilai As New List(Of Double)

        '==========================================================================================================================
        q = "UPDATE data_penjualan_retur_trans SET trans_status=9 WHERE trans_faktur='{0}'"
        queryArr.Add(String.Format(q, in_no_bukti.Text))

        q = "UPDATE data_stok_kartustok SET trans_status=9 WHERE trans_faktur='{0}'"
        queryArr.Add(String.Format(q, in_no_bukti.Text))
        '==========================================================================================================================

        '==========================================================================================================================
        For Each rows As DataGridViewRow In dgv_barang.Rows
            Dim _stock As String = in_gudang.Text & "-" & rows.Cells(0).Value & "-" & selectperiode.id
            'INSERT DATA BARANG
            dataBrg = {
                "trans_barang='" & rows.Cells(0).Value & "'",
                "trans_harga_retur='" & rows.Cells("harga").Value.ToString.Replace(",", ".") & "'",
                "trans_qty='" & rows.Cells("qty").Value & "'",
                "trans_satuan='" & rows.Cells("sat").Value & "'",
                "trans_satuan_type='" & rows.Cells("sat_type").Value & "'",
                "trans_hpp='" & rows.Cells("brg_hpp").Value.ToString.Replace(",", ".") & "'",
                "trans_status='" & rtjstatus & "'"
                }
            q = "INSERT INTO data_penjualan_retur_trans SET trans_faktur= '{0}',{1} ON DUPLICATE KEY UPDATE {1}"
            queryArr.Add(String.Format(q, in_no_bukti.Text, String.Join(",", dataBrg)))

            'COUNT QTY TOTAL PER ITEM
            Dim _qtytot As Integer = 0
            readcommd("SELECT countQTYItem('" & rows.Cells(0).Value & "'," & rows.Cells("qty").Value & ",'" & rows.Cells("sat_type").Value & "')")
            If rd.HasRows Then
                _qtytot = rd.Item(0)
            End If
            rd.Close()

            x.Add("'" & rows.Cells(0).Value & "'")
            qty.Add(_qtytot)
            x_kodestock.Add("'" & _stock & "'")
            nilai.Add(rows.Cells("jml").Value)
        Next
        '==========================================================================================================================
        '==========================================================================================================================


        '==========================================================================================================================
        'WRITE KARTU STOK
        Dim q4 As String = "INSERT INTO data_stok_kartustok({0}) SELECT {1} FROM data_stok_kartustok WHERE trans_stock={2} ON DUPLICATE KEY UPDATE {3}"
        data1 = {
                "trans_stock", "trans_index", "trans_jenis", "trans_faktur",
                "trans_ket", "trans_qty", "trans_nilai", "trans_reg_alias", "trans_reg_date"
                }
        Dim i As Integer = 0
        For Each stock As String In x_kodestock
            data2 = {
                    stock,
                    "MAX(trans_index)+1",
                    "'rj'",
                    "'" & in_no_bukti.Text & "'",
                    "'RETUR PENJUALAN'",
                    qty.Item(i) * -1,
                    (nilai.Item(i) * -1).ToString.Replace(",", "."),
                    "'" & loggeduser.user_id & "'",
                    "NOW()"
                    }
            dataBrg = {
                "trans_qty=" & qty.Item(i) * -1,
                "trans_nilai=" & (nilai.Item(i) * -1).ToString.Replace(",", "."),
                "trans_upd_date=NOW()",
                "trans_upd_alias='" & loggeduser.user_id & "'",
                "trans_status='" & rtjstatus & "'"
                }
            queryArr.Add(String.Format(q4, String.Join(",", data1), String.Join(",", data2), stock, String.Join(",", dataBrg)))
            i += 1
        Next
        '==========================================================================================================================

        '==========================================================================================================================
        'TODO : WRITE PIUTANG RETUR/TITIPAN
        q = "UPDATE data_piutang_retur SET p_retur_status=9 WHERE p_retur_bukti_retur='{0}'"
        queryArr.Add(String.Format(q, kode))
        q = "UPDATE data_piutang_titip SET p_titip_status=9 WHERE p_titip_faktur='{0}'"
        queryArr.Add(String.Format(q, kode))

        If cb_bayar_jenis.SelectedValue = 1 Then
            Dim q6 As String = "INSERT INTO data_piutang_retur SET p_retur_faktur='{0}',p_retur_bukti_retur='{1}',{2} ON DUPLICATE KEY UPDATE {2}"
            data1 = {
                "p_retur_total=" & removeCommaThousand(in_netto.Text).ToString.Replace(",", "."),
                "p_retur_reg_date=NOW()",
                "p_retur_reg_alias='" & loggeduser.user_id & "'",
                "p_retur_status='" & rtjstatus & "'"
                }
            queryArr.Add(String.Format(q6, in_no_faktur.Text, in_no_bukti.Text, String.Join(",", data1)))
        ElseIf cb_bayar_jenis.SelectedValue = 3 Then
            q = "INSERT INTO data_piutang_titip SET p_titip_faktur='{0}',{1},p_titip_reg_date=NOW(),p_titip_reg_alias='{2}' ON DUPLICATE KEY UPDATE {1}," _
                & "p_titip_upd_alias='{2}',p_titip_upd_date=NOW()"
            data1 = {
                "p_titip_ref='" & in_custo.Text & "'",
                "p_titip_nilai=" & removeCommaThousand(in_netto.Text).ToString.Replace(",", "."),
                "p_titip_idperiode='" & selectperiode.id & "'",
                "p_titip_status='" & rtjstatus & "'"
                }
            queryArr.Add(String.Format(q, in_no_bukti.Text, String.Join(",", data1), loggeduser.user_id))
        End If
        '==========================================================================================================================

        '==========================================================================================================================
        'INPUT JURNAL
        '----------HEAD
        q = "INSERT INTO data_jurnal_line SET line_kode='{0}', line_type='RBELI',{1},line_reg_date=NOW(),line_reg_alias='{2}' " _
            & "ON DUPLICATE KEY UPDATE {1},line_upd_date=NOW(),line_upd_alias='{2}'"
        data1 = {
            "line_ref='" & in_custo.Text & "'",
            "line_ref_type='CUSTO'",
            "line_tanggal='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
            "line_status='1'"
            }
        queryArr.Add(String.Format(q, in_no_bukti.Text, String.Join(",", data1), loggeduser.user_id))
        '==========================================================================================================================

        '==========================================================================================================================
        'BEGIN TRANSACTION
        querycheck = startTrans(queryArr)
        '==========================================================================================================================
        Me.Cursor = Cursors.Default

        If querycheck = False Then
            Exit Sub
        Else
            'TODO : WRITE LOG ACTIVITY
            MessageBox.Show("Data tersimpan")
            doRefreshTab({pgreturjual, pgstok, pgpiutangawal})
            Me.Close()
        End If
    End Sub

    Private Sub setReadOnly()
        Dim txt As TextBox() = {
            in_no_bukti, in_no_faktur, in_no_faktur_ex, in_pajak, in_barang_nm
            }
        For Each x As TextBox In txt
            x.ReadOnly = True
        Next
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

    '----------------close
    Private Sub bt_batalbeli_Click(sender As Object, e As EventArgs) Handles bt_batalreturbeli.Click
        If MessageBox.Show("Tutup Form?", "Retur Penjualan", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalreturbeli.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    'MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanreturbeli.PerformClick()
    End Sub

    Private Sub mn_print_Click(sender As Object, e As EventArgs) Handles mn_print.Click
        Using nota As New fr_view_piutang
            Me.Cursor = Cursors.WaitCursor
            With nota
                '.setVar("beli", in_faktur.Text, "")
                '.ShowDialog()
            End With
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    'LOAD
    Private Sub fr_beli_retur_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_bayar_jenis
            .DataSource = jenisBayar("retur")
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With
        With cb_ppn
            .DataSource = jenisPPN()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        With date_tgl_trans
            .Value = IIf(selectperiode.tglakhir >= Today, Today, selectperiode.tglakhir)
            .MaxDate = selectperiode.tglakhir
            .MinDate = selectperiode.tglawal
        End With
        date_tgl_pajak.Value = IIf(selectperiode.tglakhir >= Today, Today, selectperiode.tglakhir)

        For Each x As DataGridViewColumn In {qty, harga, jml, diskon}
            x.DefaultCellStyle = dgvstyle_commathousand
        Next

        op_con()
        If in_no_bukti.Text <> Nothing Then
            loadData(in_no_bukti.Text)
            loadDataBrg(in_no_bukti.Text)
            in_no_bukti.ReadOnly = True
        End If
    End Sub

    'SAVE
    Private Sub bt_simpanreturbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanreturbeli.Click
        If in_custo.Text = "" Then
            MessageBox.Show("Customer belum di input")
            in_custo_n.Focus()
            Exit Sub
        End If
        If in_gudang.Text = "" Then
            MessageBox.Show("Gudang belum di input")
            in_gudang_n.Focus()
            Exit Sub
        End If
        If in_sales.Text = "" Then
            MessageBox.Show("Salesman belum di input")
            in_sales_n.Focus()
            Exit Sub
        End If
        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum di input")
            in_barang.Focus()
            Exit Sub
        End If
        If cb_bayar_jenis.SelectedValue = 1 And in_no_faktur.Text = Nothing Then
            MessageBox.Show("Faktur belum di input")
            in_no_faktur.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan data retur Penjualan?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    'UI
    '------------- POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_custo_n.Focused Or in_gudang_n.Focused Or in_barang_nm.Focused Or in_no_faktur.Focused Or in_sales_n.Focused Then
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
                Case "custo"
                    x = in_custo_n
                Case "sales"
                    x = in_sales_n
                Case "gudang"
                    x = in_gudang_n
                Case "barang"
                    x = in_barang_nm
                Case "faktur"
                    x = in_no_faktur
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

    '--------------- numeric input
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

    '--------------- cb prevent input
    Private Sub cb_bayar_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_bayar_jenis.KeyPress, cb_sat.KeyPress, cb_ppn.KeyPress
        If e.KeyChar <> ControlChars.Cr Then
            e.Handled = True
        End If
    End Sub

    '----------------- HEADER
    Private Sub in_no_bukti_KeyUp(sender As Object, e As KeyEventArgs) Handles in_no_bukti.KeyUp
        keyshortenter(date_tgl_trans, e)
    End Sub

    Private Sub date_tgl_trans_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tgl_trans.KeyUp
        keyshortenter(in_pajak, e)
    End Sub

    Private Sub in_pajak_KeyUp(sender As Object, e As KeyEventArgs) Handles in_pajak.KeyUp
        keyshortenter(date_tgl_pajak, e)
    End Sub

    Private Sub date_tgl_pajak_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tgl_pajak.KeyUp
        keyshortenter(in_custo_n, e)
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_custo.KeyDown
        keyshortenter(in_custo_n, e)
    End Sub

    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_custo_n.Enter
        If in_custo_n.ReadOnly = False Then
            popPnl_barang.Location = New Point(in_custo_n.Left, in_custo_n.Top + in_custo_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            popupstate = "custo"
            loadDataBRGPopup("custo", in_custo_n.Text)
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_custo_n.Leave, in_gudang_n.Leave, in_barang_nm.Leave, in_no_faktur.Leave, in_sales_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_custo_n.KeyUp
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
            If popPnl_barang.Visible = False And in_custo_n.ReadOnly = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("custo", in_custo_n.Text)
        End If
    End Sub

    Private Sub in_supplier_n_TextChanged(sender As Object, e As EventArgs) Handles in_custo_n.TextChanged
        If in_custo_n.Text = "" Then
            in_custo.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_gudang_n_Enter(sender As Object, e As EventArgs) Handles in_gudang_n.Enter
        popPnl_barang.Location = New Point(in_gudang_n.Left, in_gudang_n.Top + in_gudang_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "gudang"
        loadDataBRGPopup("gudang", in_gudang_n.Text)
    End Sub

    Private Sub in_gudang_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(in_sales_n, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("gudang", in_gudang_n.Text)
        End If
    End Sub

    Private Sub in_gudang_n_TextChanged(sender As Object, e As EventArgs) Handles in_gudang_n.TextChanged
        If in_gudang_n.Text = "" Then
            in_gudang.Clear()
        End If
    End Sub

    Private Sub in_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales.KeyDown
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_sales_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter
        popPnl_barang.Location = New Point(in_sales_n.Left, in_sales_n.Top + in_sales_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "sales"
        loadDataBRGPopup("sales", in_sales_n.Text)
    End Sub

    Private Sub in_sales_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(cb_bayar_jenis, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("sales", in_sales_n.Text)
        End If
    End Sub

    Private Sub in_sales_n_TextChanged(sender As Object, e As EventArgs) Handles in_sales_n.TextChanged
        If in_sales_n.Text = "" Then
            in_sales.Clear()
        End If
    End Sub

    Private Sub cb_bayar_jenis_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_bayar_jenis.KeyUp
        keyshortenter(in_no_faktur, e)
    End Sub

    Private Sub in_no_faktur_Enter(sender As Object, e As EventArgs) Handles in_no_faktur.Enter
        If cb_bayar_jenis.SelectedValue = "1" Then
            popPnl_barang.Location = New Point(in_no_faktur.Left - (popPnl_barang.Width - in_no_faktur.Width), in_no_faktur.Top + in_no_faktur.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            popupstate = "faktur"
            loadDataBRGPopup("faktur", in_no_faktur.Text)
        End If
    End Sub

    Private Sub in_no_faktur_KeyUp(sender As Object, e As KeyEventArgs) Handles in_no_faktur.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(in_no_faktur_ex, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("faktur", in_no_faktur.Text)
        End If
    End Sub

    Private Sub in_no_faktur_ex_KeyUp(sender As Object, e As KeyEventArgs) Handles in_no_faktur_ex.KeyUp
        keyshortenter(in_barang_nm, e)
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
            clearTextBarang()
        End If
    End Sub

    Private Sub in_qty_KeyUp(sender As Object, e As KeyEventArgs) Handles in_qty.KeyUp
        keyshortenter(cb_sat, e)
    End Sub

    Private Sub in_harga_retur_ValueChanged(sender As Object, e As EventArgs) Handles in_harga_retur.ValueChanged, in_qty.ValueChanged, in_diskon.ValueChanged
        in_subtotal.Text = commaThousand(countSubtot(in_harga_retur.Value, in_qty.Value, in_diskon.Value))
    End Sub

    Private Sub cb_sat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_sat.SelectionChangeCommitted
        in_harga_retur.Value = countHarga(_satuanstate, in_harga_retur.Value, cb_sat.SelectedValue)
        _satuanstate = cb_sat.SelectedValue
    End Sub

    Private Sub cb_sat_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_sat.KeyUp
        keyshortenter(in_harga_retur, e)
    End Sub

    Private Sub in_harga_retur_KeyUp(sender As Object, e As KeyEventArgs) Handles in_harga_retur.KeyUp
        keyshortenter(in_diskon, e)
    End Sub

    Private Sub in_diskon_KeyUp(sender As Object, e As KeyEventArgs) Handles in_diskon.KeyUp
        keyshortenter(bt_tbbarang, e)
    End Sub

    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        textToDgv()
    End Sub

    'DGV
    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        If e.RowIndex < 0 Then
            indexrow = 0
        Else
            indexrow = e.RowIndex
            dgvToTxt()
            dgv_barang.Rows.RemoveAt(indexrow)
            countBiaya()
        End If
    End Sub

    Private Sub cb_ppn_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_ppn.SelectionChangeCommitted
        countBiaya()
    End Sub

    Private Sub fr_hutang_bayar_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub
End Class