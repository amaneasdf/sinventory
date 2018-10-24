Public Class fr_beli_retur_detail
    Private rowindex As Integer = 0
    Private rtbStatus As String = "1"
    Private _persediaan As Double = 0
    Private popupstate As String = "barang"
    Private indexrow As Integer = 0
    Private hargabesr As Decimal = 0
    Private isibesar As Integer = 0
    Private isitengah As Integer = 0
    Private _satuanstate As String = "kecil"

    '-----------------------note
    'hitung pajak -> unfinished
    'all accounting calculation is not yet finished or even created
    'retur di sistem berjalan tidak berdasarkan faktur pembelian saat input
    '

    Private Sub loadData(kode As String)
        op_con()
        Dim q As String = "SELECT faktur_pajak_no, faktur_tanggal_trans, faktur_pajak_no, faktur_kode_faktur, faktur_kode_exfaktur, " _
                          & "faktur_sebab, faktur_supplier, supplier_nama, faktur_gudang, gudang_nama, faktur_jumlah, faktur_ppn, " _
                          & "faktur_ppn_jenis, faktur_netto, faktur_status, faktur_reg_date, faktur_reg_alias, " _
                          & "faktur_upd_date, faktur_upd_alias, faktur_pajak_tanggal FROM data_pembelian_retur_faktur " _
                          & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                          & "LEFT JOIN data_barang_gudang ON gudang_kode=faktur_gudang " _
                          & "WHERE faktur_kode_bukti='{0}'"
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            in_no_bukti.Text = kode
            in_pajak.Text = rd.Item("faktur_pajak_no")
            date_tgl_trans.Value = rd.Item("faktur_tanggal_trans")
            date_tgl_pajak.Value = rd.Item("faktur_pajak_tanggal")
            in_no_faktur.Text = rd.Item("faktur_kode_faktur")
            in_no_faktur_ex.Text = rd.Item("faktur_kode_exfaktur")
            in_ket.Text = rd.Item("faktur_sebab")
            in_supplier.Text = rd.Item("faktur_supplier")
            in_supplier_n.Text = rd.Item("supplier_nama")
            in_gudang.Text = rd.Item("faktur_gudang")
            in_gudang_n.Text = rd.Item("gudang_nama")
            in_jumlah.Text = commaThousand(rd.Item("faktur_jumlah"))
            in_ppn_tot.Text = commaThousand(rd.Item("faktur_ppn"))
            cb_ppn.SelectedValue = rd.Item("faktur_ppn_jenis")
            in_netto.Text = commaThousand(rd.Item("faktur_netto"))
            in_status.Text = rd.Item("faktur_status")
            txtRegAlias.Text = rd.Item("faktur_reg_alias")
            txtRegdate.Text = rd.Item("faktur_reg_date")
        End If
        rd.Close()
        setStatus()

        'setReadOnly()
    End Sub

    Private Sub loadDataBrg(kode As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_retur, trans_qty, trans_satuan, " _
                                & "trans_satuan_type, trans_hpp, trans_diskon FROM data_pembelian_retur_trans " _
                                & "INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & kode & "' AND trans_status=1")
        With dgv_barang.Rows
            For Each rows As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("kode").Value = rows.ItemArray(0)
                    .Cells("nama").Value = rows.ItemArray(1)
                    .Cells("harga").Value = rows.ItemArray(2)
                    .Cells("qty").Value = rows.ItemArray(3)
                    .Cells("sat").Value = rows.ItemArray(4)
                    .Cells("sat_type").Value = rows.ItemArray(5)
                    .Cells("jml").Value = rows.ItemArray(3) * rows.ItemArray(2)
                    .Cells("brg_hpp").Value = rows.ItemArray(6)
                    .Cells("diskon").Value = rows.ItemArray(7)
                End With
            Next
        End With
        dt.Dispose()

        If dgv_barang.RowCount > 0 Then
            in_supplier_n.ReadOnly = True
            in_gudang_n.ReadOnly = True
        End If
    End Sub

    Private Sub setStatus()
        Select Case rtbStatus
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
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Dim autoco As New AutoCompleteStringCollection
        Select Case tipe
            Case "barang"
                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama', AVG(trans_harga_beli) as harga_beli " _
                    & "FROM data_barang_master LEFT JOIN data_stok_awal ON stock_barang=barang_kode AND stock_status=1 " _
                    & "LEFT JOIN data_pembelian_trans ON trans_barang=barang_kode AND trans_status=1" _
                    & "WHERE barang_nama LIKE '{0}%' AND stock_periode='" & selectperiode.id & "' AND stock_gudang='" & in_gudang.Text & "' " _
                    & "AND barang_supplier='" & in_supplier.Text & "' AND barang_status=1 LIMIT 250"
            Case "supplier"
                q = "SELECT supplier_kode AS 'Kode', supplier_nama AS 'Nama' FROM data_supplier_master WHERE supplier_status=1 AND supplier_nama LIKE '{0}%'"
            Case "gudang"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang WHERE gudang_status=1 AND gudang_nama LIKE '{0}%'"
            Case "faktur"
                'q = "SELECT hutang_faktur As 'Faktur', hutang_tgl As 'Tanggal', hutang_sisa As 'Sisa' FROM selecthutangawal " _
                '    & "WHERE hutang_supplier='" & in_supplier.Text & "' AND hutang_faktur LIKE '{0}%'"
                q = "SELECT hutang_faktur AS 'Faktur', hutang_awal AS 'SaldoAwal', getSisaHutang(hutang_faktur,'" & selectperiode.id & "') as 'SisaHutang' " _
                    & "FROM data_hutang_awal LEFT JOIN data_pembelian_faktur ON faktur_kode=hutang_faktur AND faktur_status=1 " _
                    & "WHERE hutang_idperiode='" & selectperiode.id & "' AND hutang_status=1 AND faktur_supplier='" & in_supplier.Text & "' " _
                    & "AND hutang_faktur LIKE '{0}%'"
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
                Case "supplier"
                    in_supplier.Text = .Cells(0).Value
                    in_supplier_n.Text = .Cells(1).Value
                    in_gudang_n.Focus()
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    in_no_faktur_ex.Focus()
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
    Sub textToDgv()
        If Trim(in_barang_nm.Text) = Nothing Then
            in_barang.Focus()
            Exit Sub
        End If

        If in_qty.Value = 0 Then
            in_qty.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.AppStarting

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
                .Cells("jml").Value = removeCommaThousand(in_subtotal.Text)
                .Cells("brg_hpp").Value = hpp
            End With
        End With

        countBiaya()
        clearInputBarang()
        in_barang.Clear()
        in_barang.Focus()

        Me.Cursor = Cursors.Default

        in_supplier_n.ReadOnly = True
        in_gudang_n.ReadOnly = True
    End Sub

    'GET DATA TO TEXTBOX FR DGV
    Private Sub dgvToTxt()
        With dgv_barang.SelectedRows.Item(0)
            loadSatuanBrg(.Cells("kode").Value)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty.Value = .Cells("qty").Value
            cb_sat.SelectedValue = .Cells("sat_type").Value
            in_harga_retur.Text = .Cells("harga").Value
        End With
        countBiaya()
        If dgv_barang.RowCount = 0 Then
            in_supplier_n.ReadOnly = False
            in_gudang_n.ReadOnly = False
        Else
            in_supplier_n.ReadOnly = True
            in_gudang_n.ReadOnly = True
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

    Private Sub setReadOnly()
        Dim txt As TextBox() = {
            in_no_bukti, in_no_faktur, in_no_faktur_ex, in_pajak, in_barang_nm
            }
        For Each x As TextBox In txt
            x.ReadOnly = True
        Next
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
            "faktur_supplier='" & in_supplier.Text & "'",
            "faktur_kode_faktur='" & in_no_faktur.Text & "'",
            "faktur_kode_exfaktur='" & in_no_faktur_ex.Text & "'",
            "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text).ToString.Replace(",", ".") & "'",
            "faktur_ppn='" & removeCommaThousand(in_ppn_tot.Text).ToString.Replace(",", ".") & "'",
            "faktur_ppn_jenis='" & cb_ppn.SelectedValue & "'",
            "faktur_netto='" & removeCommaThousand(in_netto.Text).ToString.Replace(",", ".") & "'",
            "faktur_jen_bayar='" & cb_bayar_jenis.SelectedValue & "'",
            "faktur_persediaan='" & _persediaan.ToString.Replace(",", ".") & "'",
            "faktur_sebab='" & in_ket.Text & "'",
            "faktur_status='" & rtbStatus & "'"
            }

        If bt_simpanreturbeli.Text = "Simpan" Then
            'GENERATE KODE
            If in_no_bukti.Text = Nothing Then
                Dim no As Integer = 1

                readcommd("SELECT COUNT(faktur_kode_bukti) FROM data_pembelian_retur_faktur WHERE SUBSTRING(faktur_kode_bukti,3,8)='" & date_tgl_trans.Value.ToString("yyyyMMdd") & "' AND faktur_kode_bukti LIKE 'RB%'")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()
                in_no_bukti.Text = "RB" & date_tgl_trans.Value.ToString("yyyyMMdd") & no.ToString("D3")
            ElseIf in_no_bukti.Text <> Nothing And bt_simpanreturbeli.Text <> "Update" Then
                If checkdata("data_pembelian_retur_faktur", "'" & in_no_bukti.Text & "'", "faktur_kode_bukti") = True Then
                    MessageBox.Show("Nomor faktur " & in_no_bukti.Text & " sudah pernah diinputkan", "Retur Pembelian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    in_no_bukti.Focus()
                    Exit Sub
                End If
            End If

            q = "INSERT INTO data_pembelian_retur_faktur SET faktur_kode_bukti='{0}',{1},faktur_reg_date=NOW(),faktur_reg_alias='{2}'"
        ElseIf bt_simpanreturbeli.Text = "Update" Then
            q = "UPDATE data_pembelian_retur_faktur SET {1},faktur_upd_date=NOW(), faktur_upd_alias='{2}' WHERE faktur_kode_bukti='{0}'"
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
        q = "UPDATE data_pembelian_retur_trans SET trans_status=9 WHERE trans_faktur='{0}'"
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
                "trans_diskon=" & rows.Cells("diskon").Value.ToString.Replace(",", "."),
                "trans_satuan_type='" & rows.Cells("sat_type").Value & "'",
                "trans_hpp='" & rows.Cells("brg_hpp").Value.ToString.Replace(",", ".") & "'",
                "trans_status='" & rtbStatus & "'"
                }
            q = "INSERT INTO data_pembelian_retur_trans SET trans_faktur= '{0}',{1} ON DUPLICATE KEY UPDATE {1}"
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
                    "'rb'",
                    "'" & in_no_bukti.Text & "'",
                    "'RETUR PEMBELIAN'",
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
                "trans_status='" & rtbStatus & "'"
                }
            queryArr.Add(String.Format(q4, String.Join(",", data1), String.Join(",", data2), stock, String.Join(",", dataBrg)))
            i += 1
        Next
        '==========================================================================================================================

        '==========================================================================================================================
        'TODO : WRITE HUTANG/TITIP RETUR
        q = "UPDATE data_hutang_retur SET h_retur_status=9 WHERE h_retur_bukti_retur='{0}'"
        queryArr.Add(String.Format(q, kode))
        q = "UPDATE data_hutang_titip SET h_titip_status=9 WHERE h_titip_faktur='{0}'"
        queryArr.Add(String.Format(q, kode))

        If cb_bayar_jenis.SelectedValue = 1 Then
            Dim q6 As String = "INSERT INTO data_hutang_retur SET h_retur_faktur='{0}',h_retur_bukti_retur='{1}',{2} ON DUPLICATE KEY UPDATE {2}"
            data1 = {
                "h_retur_total=" & removeCommaThousand(in_netto.Text),
                "h_retur_reg_date=NOW()",
                "h_retur_reg_alias='" & loggeduser.user_id & "'",
                "h_retur_status='" & rtbStatus & "'"
                }
            queryArr.Add(String.Format(q6, in_no_faktur.Text, in_no_bukti.Text, String.Join(",", data1)))
        ElseIf cb_bayar_jenis.SelectedValue = 3 Then
            q = "INSERT INTO data_hutang_titip SET h_titip_faktur='{0}',{1},h_titip_reg_date=NOW(),h_titip_reg_alias='{2}' ON DUPLICATE KEY UPDATE {1}," _
                & "h_titip_upd_alias='{2}',h_titip_upd_date=NOW()"
            data1 = {
                "h_titip_ref='" & in_supplier.Text & "'",
                "h_titip_nilai=" & removeCommaThousand(in_netto.Text).ToString.Replace(",", "."),
                "h_titip_idperiode='" & selectperiode.id & "'",
                "h_titip_status='" & rtbStatus & "'"
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
            "line_ref='" & in_supplier.Text & "'",
            "line_ref_type='SUPPLIER'",
            "line_tanggal='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
            "line_status='" & rtbStatus & "'"
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
            doRefreshTab({pgreturbeli, pgstok, pghutangawal})
            Me.Close()
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalreturbeli.Click
        If MessageBox.Show("Tutup Form?", "Retur Pembelian", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
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
            .Value = DateSerial(selectedperiode.Year, selectedperiode.Month, date_tgl_trans.Value.Day)
            .MaxDate = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)
            .MinDate = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
        End With
        date_tgl_pajak.Value = DateSerial(selectedperiode.Year, selectedperiode.Month, date_tgl_pajak.Value.Day)

        For Each x As DataGridViewColumn In {qty, harga, jml}
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
        If in_supplier.Text = "" Then
            MessageBox.Show("Supplier belum di input")
            in_supplier_n.Focus()
            Exit Sub
        End If
        If in_gudang.Text = "" Then
            MessageBox.Show("Gudang belum di input")
            in_gudang_n.Focus()
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

        If MessageBox.Show("Simpan data retur pembelian?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    'UI
    '------------- POPUPSEARCH PANEL
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

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            Dim x As TextBox
            Select Case popupstate
                Case "supplier"
                    x = in_supplier_n
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
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_harga_retur.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_harga_retur.Leave
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
        keyshortenter(in_supplier_n, e)
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        keyshortenter(in_supplier_n, e)
    End Sub

    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_supplier_n.Enter
        If in_supplier_n.ReadOnly = False And in_supplier_n.Enabled = True Then
            popPnl_barang.Location = New Point(in_supplier_n.Left, in_supplier_n.Top + in_supplier_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            popupstate = "supplier"
            loadDataBRGPopup("supplier", in_supplier_n.Text)
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_supplier_n.Leave, in_gudang_n.Leave, in_barang_nm.Leave, in_no_faktur.Leave
        If Not dgv_listbarang.Focused = True Then
            If sender.Text <> Nothing And sender.ReadOnly = False And sender.Enabled = True Then
                setPopUpResult()
            End If
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyUp
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
            If popPnl_barang.Visible = False And sender.ReadOnly = False And sender.Enabled = True Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("supplier", in_supplier_n.Text)
        End If
    End Sub

    Private Sub in_supplier_n_TextChanged(sender As Object, e As EventArgs) Handles in_supplier_n.TextChanged
        If in_supplier_n.Text = "" Then
            in_supplier.Clear()
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
            keyshortenter(in_no_faktur_ex, e)
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

    Private Sub in_no_faktur_ex_KeyUp(sender As Object, e As KeyEventArgs) Handles in_no_faktur_ex.KeyUp
        keyshortenter(cb_bayar_jenis, e)
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
            keyshortenter(in_barang, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("faktur", in_no_faktur.Text)
        End If
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
        End If
    End Sub

    Private Sub fr_hutang_bayar_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub

End Class