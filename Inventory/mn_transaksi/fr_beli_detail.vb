Public Class fr_beli_detail
    Private indexrow As Integer = 0
    Private popupstate As String = "barang"
    Private tblStatus As String = "1"
    Private selectSupplier As String = ""
    Public add_sw As Boolean = True
    Public edit_sw As Boolean = True

    Private Sub loadDataFaktur(kode As String)
        Dim q As String = "SELECT faktur_surat_jalan, faktur_pajak_no, faktur_tanggal_trans, faktur_pajak_tanggal, faktur_gudang, " _
                          & "gudang_nama, faktur_supplier, supplier_nama, faktur_term, faktur_jumlah, faktur_disc, faktur_total, " _
                          & "faktur_ppn_jenis, faktur_netto, faktur_ppn, faktur_klaim, faktur_total_netto, faktur_status, " _
                          & "faktur_reg_alias, faktur_reg_date, faktur_upd_alias, faktur_upd_date " _
                          & "FROM data_pembelian_faktur LEFT JOIN data_barang_gudang ON faktur_gudang=gudang_kode " _
                          & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                          & "WHERE faktur_kode='{0}'"
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            in_faktur.Text = kode
            in_suratjalan.Text = rd.Item("faktur_surat_jalan")
            in_pajak.Text = rd.Item("faktur_pajak_no")
            date_tgl_beli.Value = rd.Item("faktur_tanggal_trans")
            date_tgl_pajak.Value = rd.Item("faktur_pajak_tanggal")
            in_gudang.Text = rd.Item("faktur_gudang")
            in_gudang_n.Text = rd.Item("gudang_nama")
            selectSupplier = rd.Item("faktur_supplier")
            in_supplier.Text = rd.Item("faktur_supplier")
            in_supplier_n.Text = rd.Item("supplier_nama")
            in_term.Value = rd.Item("faktur_term")
            in_jumlah.Text = commaThousand(rd.Item("faktur_jumlah"))
            in_diskon.Text = commaThousand(rd.Item("faktur_disc"))
            in_total.Text = commaThousand(rd.Item("faktur_total"))
            cb_ppn.SelectedValue = rd.Item("faktur_ppn_jenis")
            in_netto.Text = commaThousand(rd.Item("faktur_netto"))
            in_ppn_tot.Text = commaThousand(rd.Item("faktur_ppn"))
            in_klaim.Value = CDbl(rd.Item("faktur_klaim"))
            in_total_netto.Text = commaThousand(rd.Item("faktur_total_netto"))
            tblStatus = rd.Item("faktur_status")
            txtRegAlias.Text = rd.Item("faktur_reg_alias")
            txtRegdate.Text = rd.Item("faktur_reg_date")
            Try
                txtUpdDate.Text = rd.Item("faktur_upd_date")
            Catch ex As Exception
                consoleWriteLine(ex.Message)
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("faktur_upd_alias")
        End If
        rd.Close()

        setStatus()
        in_faktur.ReadOnly = True
    End Sub

    Private Sub loadDataBarang(kode As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_beli, trans_qty, trans_satuan, trans_disc1,trans_disc2,trans_disc3,trans_disc_rupiah, trans_jumlah, trans_ppn,trans_satuan_type FROM data_pembelian_trans INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & kode & "' AND trans_status=1")
        With dgv_barang.Rows
            For Each row As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("kode").Value = row.ItemArray(0)
                    .Cells("nama").Value = row.ItemArray(1)
                    .Cells("qty").Value = row.ItemArray(3)
                    .Cells("sat").Value = row.ItemArray(4)
                    .Cells("sat_type").Value = row.ItemArray(11)
                    .Cells("harga").Value = row.ItemArray(2)
                    .Cells("subtot").Value = row.ItemArray(3) * row.ItemArray(2)
                    .Cells("disc1").Value = row.ItemArray(5)
                    .Cells("disc2").Value = row.ItemArray(6)
                    .Cells("disc3").Value = row.ItemArray(7)
                    .Cells("discrp").Value = row.ItemArray(8)
                    .Cells("jml").Value = row.ItemArray(9)
                End With
            Next
        End With
    End Sub

    'SET STATUS
    Private Sub setStatus()
        Select Case tblStatus
            Case 0
                in_status.Text = "Pending"
            Case 1
                in_status.Text = "Aktif"
            Case 2
                in_status.Text = "Batal"
            Case 9
                in_status.Text = "Delete"
            Case Else
                Exit Sub
        End Select

        If selectperiode.closed = True Or loggeduser.allowedit_transact = False Or tblStatus = 2 Then
            For Each txt As TextBox In {in_supplier_n, in_gudang_n, in_suratjalan, in_barang_nm, in_pajak, in_ket}
                txt.ReadOnly = True
            Next

            With dgv_barang
                .Location = New Point(8, 179)
                .Height = 247
            End With

            bt_simpanbeli.Visible = False
            bt_batalbeli.Text = "OK"
            bt_tbbarang.Enabled = False
            date_tgl_beli.Enabled = False
            date_tgl_pajak.Enabled = False
            cb_ppn.Enabled = False
            mn_save.Enabled = False
            mn_cancelorder.Enabled = False
        End If

        mn_print.Enabled = IIf(tblStatus = 1, True, False)
    End Sub

    'SET SATUAN BARANG
    Private Sub loadSatuanBrg(kode As String)
        op_con()
        Dim dt As New DataTable
        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))
        readcommd("SELECT barang_satuan_kecil, barang_satuan_tengah, barang_satuan_besar FROM data_barang_master WHERE barang_kode='" & kode & "'")
        With dt.Rows
            If rd.HasRows Then
                .Add(rd.Item("barang_satuan_kecil"), "kecil")
                .Add(rd.Item("barang_satuan_tengah"), "tengah")
                .Add(rd.Item("barang_satuan_besar"), "besar")
            End If
        End With
        rd.Close()
        cb_sat.DataSource = dt
        cb_sat.DisplayMember = "Text"
        cb_sat.ValueMember = "Value"
        cb_sat.SelectedIndex = cb_sat.Items.Count - 1
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Dim autoco As New AutoCompleteStringCollection
        Select Case tipe
            Case "barang"
                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama', barang_harga_beli 'Harga Default', barang_harga_beli_d1, " _
                    & "barang_harga_beli_d2, barang_harga_beli_d3 FROM data_barang_master WHERE barang_nama LIKE '{0}%' " _
                    & "AND barang_supplier='" & in_supplier.Text & "' AND barang_status=1 LIMIT 250"
            Case "supplier"
                q = "SELECT supplier_kode AS 'Kode', supplier_nama AS 'Nama', supplier_term FROM data_supplier_master WHERE supplier_status=1 AND supplier_nama LIKE '{0}%'"
            Case "gudang"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang WHERE gudang_status=1 AND gudang_nama LIKE '{0}%'"
            Case Else
                Exit Sub
        End Select

        dt = getDataTablefromDB(String.Format(q, param))

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 135
            .Columns(1).Width = 200
            If tipe = "barang" Or tipe = "supplier" Then
                For i = IIf(tipe = "barang", 3, 2) To IIf(tipe = "supplier", 2, 5)
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
                    loadSatuanBrg(in_barang.Text)
                    in_qty.Focus()
                Case "supplier"
                    If ckSupplierChange() = True Then
                        in_supplier.Text = .Cells(0).Value
                        in_supplier_n.Text = .Cells(1).Value
                        in_term.Value = .Cells(2).Value
                        selectSupplier = in_supplier.Text
                    End If
                    in_gudang_n.Focus()
                    popPnl_barang.Visible = False
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    in_suratjalan.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
    End Sub

    'INPUT DATA TO DGV FR TEXTBOX
    Private Sub textToDgv()
        Dim _supplier As String = ""
        Dim q As String = ""

        If Trim(in_barang_nm.Text) = Nothing Then
            in_barang.Focus()
            Exit Sub
        End If
        If in_qty.Value = 0 Then
            in_qty.Focus()
            Exit Sub
        End If

        op_con()
        q = "SELECT barang_supplier FROM data_barang_master WHERE barang_kode='{0}'"
        readcommd(String.Format(q, in_barang.Text))
        If rd.HasRows Then
            _supplier = rd.Item(0)
        End If
        rd.Close()

        If in_supplier.Text <> _supplier Then
            MessageBox.Show("Supplier barang berbeda dengan barang yang terpilih.", "Pembelian", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_barang_nm.Focus()
            popPnl_barang.Visible = False
            Exit Sub
        End If

        Dim pajak_tot As Double = 0
        Dim total As Double = removeCommaThousand(in_subtotal.Text)

        For Each x As Double In {in_disc1.Value, in_disc2.Value, in_disc3.Value}
            If x <> 0 Then
                Dim y As Double = total
                total = y * (1 - x / 100)
            Else
                total = total
            End If
        Next

        If in_discrp.Value <> 0 Then
            total -= in_qty.Value * in_discrp.Value
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
                .Cells("subtot").Value = removeCommaThousand(in_subtotal.Text)
                .Cells("disc1").Value = in_disc1.Value
                .Cells("disc2").Value = in_disc2.Value
                .Cells("disc3").Value = in_disc3.Value
                .Cells("discrp").Value = in_discrp.Value
                .Cells("jml").Value = total
            End With
        End With

        countbiaya()
        clearInputBarang()
        cb_sat.Text = ""
        cb_sat.DataSource.Clear()
        in_barang.Focus()
    End Sub

    'GET DATA TO TEXTBOX FR DGV
    Private Sub dgvTotxt()
        With dgv_barang.Rows(indexrow)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty.Value = .Cells("qty").Value
            loadSatuanBrg(.Cells("kode").Value)
            cb_sat.SelectedValue = .Cells("sat_type").Value
            in_harga_beli.Text = .Cells("harga").Value
            in_disc1.Value = .Cells("disc1").Value
            in_disc2.Value = .Cells("disc2").Value
            in_disc3.Value = .Cells("disc3").Value
            in_discrp.Value = .Cells("discrp").Value
        End With

        'countbiaya()
        in_qty.Focus()
        selectSupplier = in_supplier.Text
    End Sub


    Private Sub countbiaya()
        Dim pajak As Double = 0
        Dim x As Double = jumlahbiaya()
        Dim y As Double = x
        Dim netto As Double = 0
        Dim diskon As Double = 0

        For Each row As DataGridViewRow In dgv_barang.Rows
            diskon += row.Cells(6).Value - row.Cells(11).Value
        Next

        y = x - diskon
        netto = y

        If cb_ppn.SelectedValue = 0 Then
            pajak = x * 0.1
            netto += pajak
        ElseIf cb_ppn.SelectedValue = 1 Then
            'pajak = x - (x / 1.1)
            pajak = x * (1 - 10 / 11)
        Else
            pajak = 0
        End If

        Dim aa As Double = netto - CDbl(in_klaim.Value)
        Dim cc As Globalization.CultureInfo = Globalization.CultureInfo.GetCultureInfo("id-ID")
        in_jumlah.Text = x.ToString("N2", cc)
        in_diskon.Text = commaThousand(diskon)
        in_ppn_tot.Text = commaThousand(pajak)
        in_total.Text = y.ToString("N2", cc)
        in_netto.Text = netto.ToString("N2", cc)
        in_klaim.Maximum = netto
        in_total_netto.Text = aa.ToString("N2", cc)

        Console.WriteLine("ss" & aa)
        Console.WriteLine(removeCommaThousand(in_total_netto.Text))
    End Sub

    Private Function jumlahbiaya() As Double
        Dim x As Double = 0

        For Each rows As DataGridViewRow In dgv_barang.Rows
            Console.WriteLine(rows.Cells("subtot").Value)
            x += rows.Cells("subtot").Value
        Next

        Console.WriteLine(x)
        Return x
    End Function

    Private Sub clearTextBarang()
        in_harga_beli.Value = 0
        For Each x As TextBox In {in_barang, in_subtotal}
            x.Clear()
        Next
    End Sub

    Private Sub clearInputBarang()
        clearTextBarang()
        in_barang_nm.Clear()
        in_qty.Value = 0
        in_disc1.Value = 0
        in_disc2.Value = 0
        in_disc3.Value = 0
        in_discrp.Value = 0
    End Sub

    Private Function ckSupplierChange() As Boolean
        Dim supcg As String = dgv_listbarang.SelectedRows.Item(0).Cells(0).Value
        If supcg <> selectSupplier And dgv_barang.RowCount > 0 Then
            Dim _msgRes As DialogResult = MessageBox.Show("Supplier yang terpilih berubah. Ubah data barang?", "Pembelian", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            Dim q As String = ""

            If _msgRes = Windows.Forms.DialogResult.Yes Then
                clearInputBarang()
                Return True
            Else
                q = "SELECT supplier_nama FROM data_supplier_master WHERE supplier_kode='{0}'"
                readcommd(String.Format(q, selectSupplier))
                If rd.HasRows Then
                    in_supplier_n.Text = rd.Item(0)
                End If
                rd.Close()
                Return False
            End If
        ElseIf supcg = selectSupplier Then
            Return True
        ElseIf selectSupplier = "" Then
            Return True
        Else
            Return False
        End If
    End Function

    'SAVE
    Private Sub saveData()
        'INSERT
        'SAVE HEADER -> LISTBARANG(GET QTY->UPD HPP->CHECK STOK AWAL(IFNULL INPUT->INPUT KARTU STOK)->INPUT BARANG->INPUT KARTU STOK) -> INPUT HUTANG AWAL
        'UPDATE
        'SAVE HEADER -> LISTBARANG(GET QTY->SAVEBARANG->UPD HPP-> UPD KARTUSTOK) -> UPD HUTANG AWAL
        Dim dataHead, dataBrg As String()
        Dim querycheck As Boolean = False
        Dim queryArr As New List(Of String)
        Dim q As String = ""

        Dim _tgltrans As String = date_tgl_beli.Value.ToString("yyyy-MM-dd")

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

        'SAVE HEADER
        op_con()
        If bt_simpanbeli.Text = "Simpan" Then
            'GENERATE KODE
            If in_faktur.Text = Nothing Then
                Dim tgl = date_tgl_beli.Value.ToString("yyyyMMdd")
                Dim no As Integer = 1
                readcommd("SELECT COUNT(faktur_kode) FROM data_pembelian_faktur WHERE SUBSTRING(faktur_kode,3,8)='" & tgl & "' AND faktur_kode LIKE 'PO%'")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()
                in_faktur.Text = "PO" & tgl & no.ToString("D3")
            ElseIf in_faktur.Text <> Nothing And bt_simpanbeli.Text <> "Update" Then
                If checkdata("data_pembelian_faktur", "'" & in_faktur.Text & "'", "faktur_kode") = True Then
                    MessageBox.Show("Nomor faktur " & in_faktur.Text & " sudah pernnah diinputkan", "Pembelian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    in_faktur.Focus()
                    Exit Sub
                End If
            End If

            q = "INSERT INTO data_pembelian_faktur SET faktur_kode='{0}',{1},faktur_reg_date=NOW(),faktur_reg_alias='{2}'"
        ElseIf bt_simpanbeli.Text = "Update" Then
            q = "UPDATE data_pembelian_faktur SET {1},faktur_upd_date=NOW(), faktur_upd_alias='{2}' WHERE faktur_kode='{0}'"
        End If
        queryArr.Add(String.Format(q, in_faktur.Text, String.Join(",", dataHead), loggeduser.user_id))
        '==========================================================================================================================


        '==========================================================================================================================
        'INSERT BARANG
        Dim x As New List(Of String)
        Dim x_kodestock As New List(Of String)
        Dim qty As New List(Of Integer)
        Dim nilai As New List(Of Double)

        '==========================================================================================================================
        q = "UPDATE data_pembelian_trans SET trans_status=9 WHERE trans_faktur='{0}'"
        queryArr.Add(String.Format(q, in_faktur.Text))
        '==========================================================================================================================

        '==========================================================================================================================
        For Each rows As DataGridViewRow In dgv_barang.Rows
            Dim _kdbrg As String = rows.Cells(0).Value

            'INSERT DATA BARANG
            dataBrg = {
                "trans_barang='" & _kdbrg & "'",
                "trans_harga_beli='" & rows.Cells("harga").Value & "'",
                "trans_qty='" & rows.Cells("qty").Value & "'",
                "trans_satuan='" & rows.Cells("sat").Value & "'",
                "trans_satuan_type='" & rows.Cells("sat_type").Value & "'",
                "trans_disc1='" & rows.Cells("disc1").Value & "'",
                "trans_disc2='" & rows.Cells("disc2").Value & "'",
                "trans_disc3='" & rows.Cells("disc3").Value & "'",
                "trans_disc_rupiah='" & rows.Cells("discrp").Value & "'",
                "trans_jumlah='" & rows.Cells("jml").Value & "'",
                "trans_status='1'"
                }
            q = "INSERT INTO data_pembelian_trans SET trans_faktur= '{0}',{1} ON DUPLICATE KEY UPDATE {1}"
            queryArr.Add(String.Format(q, in_faktur.Text, String.Join(",", dataBrg)))
        Next
        '==========================================================================================================================
        '==========================================================================================================================

        '==========================================================================================================================
        q = "CALL transPembelianFin('{0}','{1}')"
        queryArr.Add(String.Format(q, in_faktur.Text, loggeduser.user_id))
        '==========================================================================================================================

        '==========================================================================================================================
        'BEGIN TRANSACT
        querycheck = startTrans(queryArr)
        '==========================================================================================================================

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            doRefreshTab({pgpembelian, pgstok, pghutangawal})
            Me.Close()
        End If
    End Sub

    'CANCEL
    Private Function cancelData() As Boolean
        Dim _retval As Boolean = False
        Dim _status As Integer = 2
        Dim _ckdata As Boolean = False
        Dim _kode As String = in_faktur.Text
        Dim q As String = ""
        Dim queryArr As New List(Of String)
        Dim queryCk As Boolean = False

        op_con()
        _ckdata = checkdata("data_hutang_trans", "'" & _kode & "' AND h_trans_status<>9 AND h_trans_jenis NOT IN ('awal','beli')", "h_trans_kode_hutang")
        If _ckdata = False Then
            Dim _msg As String = "Batalkan transaksi pembelian {0}?"
            If MessageBox.Show(String.Format(_msg, _kode), "Batal Pembelian", MessageBoxButtons.YesNo) Then
                '==========================================================================================================================
                q = "UPDATE data_pembelian_faktur SET faktur_status=2, faktur_upd_alias='{1}', faktur_upd_date=NOW() WHERE faktur_kode='{0}'"
                queryArr.Add(String.Format(q, _kode, loggeduser.user_id))
                '==========================================================================================================================

                '==========================================================================================================================
                q = "CALL transPembelianFin('{0}','{1}')"
                queryArr.Add(String.Format(q, _kode, loggeduser.user_id))
                '==========================================================================================================================

                '==========================================================================================================================
                'BEGIN TRANSACT
                queryCk = startTrans(queryArr)
                '==========================================================================================================================

                _retval = queryCk
                If queryCk = False Then
                    MessageBox.Show("Pembatalan transaksi gagal", "Batal Pembelian", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            Dim msg As String = "Pembelian {0} untuk supplier {1} sudah pernah dilakukan transaksi pembayaran/retur pembelian. Pembatalan tidak dapat dilakukan."
            MessageBox.Show(String.Format(msg, _kode, in_supplier_n.Text), "Batal Pembelian", MessageBoxButtons.OK)
            _retval = False
        End If

        Return _retval
    End Function

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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        If MessageBox.Show("Tutup Form?", "Pembelian", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
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

    Private Sub fr_beli_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            Else
                bt_batalbeli.PerformClick()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    'MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanbeli.PerformClick()
    End Sub

    Private Sub mn_print_Click(sender As Object, e As EventArgs) Handles mn_print.Click
        Using nota As New fr_view_nota
            Me.Cursor = Cursors.WaitCursor
            With nota
                .setVar("beli", in_faktur.Text, "")
                .ShowDialog()
            End With
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mn_cancelorder_Click(sender As Object, e As EventArgs) Handles mn_cancelorder.Click
        If MessageBox.Show("Batalkan Penjualan?", "Penjualan", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim res As Boolean = cancelData()

            If res = True Then
                MessageBox.Show("Transaksi pembelian dibatalkan", "Batal Pembelian", MessageBoxButtons.OK)
                doRefreshTab({pgpembelian, pgstok, pghutangawal})
                Me.Close()
            End If
        End If
    End Sub

    'LOAD
    Private Sub fr_beli_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub do_load()
        'unfinished

        '------------------------
        Me.Cursor = Cursors.WaitCursor

        With cb_ppn
            .DataSource = jenisPPN()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        With date_tgl_beli
            .Value = IIf(selectperiode.tglakhir >= Today, Today, selectperiode.tglakhir)
            .MaxDate = selectperiode.tglakhir
            '.MinDate = selectperiode.tglawal
        End With
        date_tgl_pajak.Value = IIf(selectperiode.tglakhir >= Today, Today, selectperiode.tglakhir)

        For Each x As DataGridViewColumn In {harga, discrp, jml, subtot}
            x.DefaultCellStyle = dgvstyle_currency
        Next

        setStatus()

        If bt_simpanbeli.Text = "Update" Then
            loadDataBarang(in_faktur.Text)
            loadDataFaktur(in_faktur.Text)
            in_faktur.ReadOnly = True

        End If
        Me.Cursor = Cursors.Default

    End Sub

    'SAVE
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
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
        If date_tgl_beli.Value < selectperiode.tglawal Then
            MessageBox.Show("Tanggal transaksi lebih kecil daripada Jangka waktu periode terpilih")
            date_tgl_beli.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan data pembelian?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    'UI
    '------------- POPUPSEARCH PANEL
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
            'consoleWriteLine("fuck")
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
                Case "supplier"
                    x = in_supplier_n
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

    '------------- cb prevent input
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_ppn.KeyPress, cb_sat.KeyPress
        If e.KeyChar <> ControlChars.Cr Then
            e.Handled = True
        End If
    End Sub

    '------------- numeric
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_klaim.Enter, in_discrp.Enter, in_disc3.Enter, in_disc2.Enter, in_disc1.Enter, in_term.Enter, in_harga_beli.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_klaim.Leave, in_discrp.Leave, in_disc3.Leave, in_disc2.Leave, in_disc1.Leave, in_term.Leave, in_harga_beli.Leave
        If sender.Name.ToString = "in_term" Then
            numericLostFocus(sender, "N0")
        Else
            numericLostFocus(sender)
        End If
    End Sub

    '----------------- HEADER
    Private Sub in_supplier_n_KeyPress(sender As Object, e As KeyPressEventArgs) Handles in_supplier_n.KeyPress, in_gudang_n.KeyPress, in_barang_nm.KeyPress
        If e.KeyChar = Chr(Keys.Return) Then
            e.Handled = True
        End If
    End Sub

    Private Sub in_faktur_KeyUp(sender As Object, e As KeyEventArgs) Handles in_faktur.KeyDown
        keyshortenter(date_tgl_beli, e)
    End Sub

    Private Sub date_tgl_beli_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyDown
        keyshortenter(in_pajak, e)
    End Sub

    Private Sub in_pajak_KeyUp(sender As Object, e As KeyEventArgs) Handles in_pajak.KeyDown
        keyshortenter(date_tgl_pajak, e)
    End Sub

    Private Sub date_tgl_pajak_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tgl_pajak.KeyDown
        keyshortenter(in_supplier_n, e)
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        keyshortenter(in_supplier_n, e)
    End Sub

    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_supplier_n.Enter
        If in_supplier_n.ReadOnly = False Then
            popPnl_barang.Location = New Point(in_supplier_n.Left, in_supplier_n.Top + in_supplier_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            popupstate = "supplier"
            loadDataBRGPopup("supplier", in_supplier_n.Text)
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

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyUp, in_gudang_n.KeyUp, in_barang_nm.KeyUp
        Dim _nxtcontrol As Control
        Dim _kdcontrol As Control
        Select Case sender.Name.ToString
            Case "in_supplier_n"
                _nxtcontrol = in_gudang_n
                _kdcontrol = in_supplier
            Case "in_gudang_n"
                _nxtcontrol = in_suratjalan
                _kdcontrol = in_gudang
            Case "in_barang_nm"
                _nxtcontrol = in_qty
            Case Else
                Exit Sub
        End Select

        If IsNothing(_kdcontrol) = False And sender.Text = "" Then
            _kdcontrol.Text = ""
        ElseIf sender.Text = "" And sender.Name.ToString = "in_barang_nm" Then
            clearTextBarang()
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
        Else
            If e.KeyCode <> Keys.Escape Then
                If popPnl_barang.Visible = False And sender.ReadOnly = False Then
                    popPnl_barang.Visible = True
                End If
                loadDataBRGPopup(popupstate, sender.Text)
            End If
        End If
    End Sub

    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_gudang_n_Enter(sender As Object, e As EventArgs) Handles in_gudang_n.Enter
        If sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(in_gudang_n.Left, in_gudang_n.Top + in_gudang_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            popupstate = "gudang"
            loadDataBRGPopup(popupstate, sender.Text)
        End If
    End Sub

    Private Sub in_suratjalan_KeyUp(sender As Object, e As KeyEventArgs) Handles in_suratjalan.KeyDown
        keyshortenter(in_term, e)
    End Sub

    Private Sub in_term_KeyUp(sender As Object, e As KeyEventArgs) Handles in_term.KeyDown
        keyshortenter(cb_ppn, e)
    End Sub

    Private Sub cb_ppn_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_ppn.KeyDown
        keyshortenter(in_barang_nm, e)
    End Sub

    '-----------------BARANG
    'Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
    '    If e.KeyCode = Keys.Right Then
    '        consoleWriteLine(sender.SelectionStart)
    '        If sender.SelectionStart = sender.TextLength Then
    '            in_barang_nm.Focus()
    '        End If
    '    End If
    'End Sub

    Private Sub in_barang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        keyshortenter(in_barang_nm, e)
    End Sub

    Private Sub in_barang_nm_Enter(sender As Object, e As EventArgs) Handles in_barang_nm.Enter
        If sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(in_barang_nm.Left, in_barang_nm.Top + in_barang_nm.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            popupstate = "barang"
            loadDataBRGPopup("barang", in_barang_nm.Text)
        End If
    End Sub

    Private Sub in_qty_KeyUp(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
        keyshortenter(cb_sat, e)
    End Sub

    Private Sub in_harga_beli_ValueChanged(sender As Object, e As EventArgs) Handles in_qty.ValueChanged, in_harga_beli.ValueChanged
        in_subtotal.Text = commaThousand(in_qty.Value * in_harga_beli.Value)
    End Sub

    Private Sub cb_sat_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_sat.KeyDown
        keyshortenter(in_harga_beli, e)
    End Sub

    Private Sub in_harga_beli_KeyUp(sender As Object, e As KeyEventArgs) Handles in_harga_beli.KeyDown
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
        keyshortenter(in_discrp, e)
    End Sub

    Private Sub in_discrp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_discrp.KeyDown
        keyshortenter(bt_tbbarang, e)
    End Sub

    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        textToDgv()
    End Sub

    'DGV
    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        If selectperiode.closed = False And loggeduser.allowedit_transact = True And tblStatus <> 2 Then
            If e.RowIndex < 0 Then
                indexrow = 0
            Else
                indexrow = e.RowIndex
                dgvTotxt()
                dgv_barang.Rows.RemoveAt(indexrow)
                countbiaya()
            End If
        End If
    End Sub

    Private Sub cb_ppn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_ppn.SelectionChangeCommitted
        countbiaya()
    End Sub

    Private Sub in_klaim_ValueChanged(sender As Object, e As EventArgs) Handles in_klaim.ValueChanged
        countbiaya()
    End Sub
End Class