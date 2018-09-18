Public Class fr_beli_retur_detail
    Private rowindex As Integer = 0
    Private indexrowlist As Integer = 0
    Private ppnjenis As String = "1"
    Private statusretur As String = "1"

    '-----------------------note
    'hitung pajak -> unfinished
    'all accounting calculation is not yet finished or even created
    'retur di sistem berjalan tidak berdasarkan faktur pembelian saat input
    '

    Private Sub loadData(kode As String)
        readcommd("SELECT * FROM data_pembelian_retur_faktur WHERE faktur_kode_bukti='" & kode & "'")
        If rd.HasRows Then
            in_no_bukti.Text = kode
            in_pajak.Text = rd.Item("faktur_pajak_no")
            date_tgl_trans.Value = rd.Item("faktur_tanggal_trans")
            date_tgl_pajak.Value = rd.Item("faktur_pajak_tanggal")
            in_no_faktur.Text = rd.Item("faktur_kode_faktur")
            in_no_faktur_ex.Text = rd.Item("faktur_kode_exfaktur")
            in_ket.Text = rd.Item("faktur_sebab")
            cb_supplier.SelectedValue = rd.Item("faktur_supplier")
            cb_gudang.SelectedValue = rd.Item("faktur_gudang")
            in_jumlah.Text = commaThousand(rd.Item("faktur_jumlah"))
            in_ppn_tot.Text = commaThousand(rd.Item("faktur_ppn"))
            cb_ppn.SelectedValue = rd.Item("faktur_ppn_jenis")
            in_netto.Text = commaThousand(rd.Item("faktur_netto"))
            in_status_kode.Text = rd.Item("faktur_status")
            txtRegAlias.Text = rd.Item("faktur_reg_alias")
            txtRegdate.Text = rd.Item("faktur_reg_date")
        End If
        rd.Close()

        'setReadOnly()
    End Sub

    Private Sub loadDataBrg(kode As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_retur, trans_qty, trans_satuan, trans_jumlah, trans_satuan_type FROM data_pembelian_retur_trans INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & kode & "'")
        With dgv_barang.Rows
            For Each rows As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("kode").Value = rows.ItemArray(0)
                    .Cells("nama").Value = rows.ItemArray(1)
                    .Cells("harga").Value = rows.ItemArray(2)
                    .Cells("qty").Value = rows.ItemArray(3)
                    .Cells("sat").Value = rows.ItemArray(4)
                    .Cells("sat_type").Value = rows.ItemArray(6)
                    .Cells("jml").Value = rows.ItemArray(5)
                End With
            Next
        End With
        dt.Dispose()
    End Sub

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
        'cb_sat.DataSource.Clear()
        cb_sat.DataSource = dt
        cb_sat.DisplayMember = "Text"
        cb_sat.ValueMember = "Value"
    End Sub

    Private Sub loadDataBRGPopup()
        With dgv_listbarang
            .DataSource = getDataTablefromDB("SELECT barang_nama as nama, barang_kode as kode, barang_harga_beli as harga_beli " _
                                             & "FROM data_barang_master " _
                                             & "LEFT JOIN data_pembelian_trans ON barang_kode=trans_barang " _
                                             & "LEFT JOIN data_pembelian_faktur ON trans_faktur=faktur_kode " _
                                             & "WHERE faktur_supplier='" & cb_supplier.SelectedValue & "' " _
                                             & "AND barang_nama LIKE '" & in_barang_nm.Text & "%' " _
                                             & "GROUP BY barang_kode")
        End With
    End Sub

    Private Sub setBarang(nama As String, Optional kode As String = Nothing)
        op_con()
        If kode = Nothing Then
            readcommd("SELECT barang_kode FROM data_barang_master WHERE barang_nama LIKE '" & nama & "%' LIMIT 1")
            If rd.HasRows Then
                kode = rd.Item(0)
                rd.Close()
            Else
                rd.Close()
                Exit Sub
            End If
        End If

        readcommd("SELECT barang_nama, barang_kode, barang_harga_beli FROM data_barang_master WHERE barang_kode='" & kode & "' AND barang_supplier='" & cb_supplier.SelectedValue & "'")
        If rd.HasRows Then
            in_barang_nm.Text = rd.Item("barang_nama")
            in_harga_retur.Value = rd.Item("barang_harga_beli")
        End If
        rd.Close()

        If in_barang.Text <> Nothing Then
            loadSatuanBrg(kode)
            'cb_sat.SelectedIndex = 2
        End If
    End Sub

    Private Sub textToDgv()
        If Trim(in_barang_nm.Text) = Nothing Then
            in_barang.Focus()
            Exit Sub
        End If

        If in_qty.Value = 0 Then
            in_qty.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.AppStarting

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
            End With
        End With

        countBiaya()
        clearInputBarang()
        in_barang.Clear()
        in_barang.Focus()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvToTxt()
        With dgv_barang.Rows(rowindex)
            loadSatuanBrg(.Cells("kode").Value)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty.Value = .Cells("qty").Value
            cb_sat.SelectedValue = .Cells("sat_type").Value
            in_harga_retur.Text = .Cells("harga").Value
        End With
        countBiaya()
    End Sub

    Private Sub countBiaya()
        Dim subtot As Double = 0
        Dim pajak As Double = 0
        Dim z As Double = 0

        For Each rows As DataGridViewRow In dgv_barang.Rows
            Console.WriteLine(rows.Cells("jml").Value)
            subtot += rows.Cells("jml").Value
        Next

        z = subtot

        If cb_ppn.SelectedValue = "1" Then
            'incl
            pajak = subtot * (1 - 1 / 1.1)
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
        If MessageBox.Show("Tutup Form?", "Retur Purchase", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
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

    'numeric input
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_harga_retur.Enter
        Console.WriteLine(sender.Name & sender.Value)
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_harga_retur.Leave
        numericLostFocus(sender)
    End Sub

    '--------------- cb prevent input
    Private Sub cb_bayar_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_bayar_jenis.KeyPress, cb_sat.KeyPress, cb_ppn.KeyPress
        e.Handled = True
    End Sub

    '---------------pop up list barang & input barang
    Private Sub in_barang_Enter(sender As Object, e As EventArgs) Handles in_barang_nm.Enter
        popPnl_barang.Location = New Point(in_barang_nm.Left, in_barang_nm.Top + in_barang_nm.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
            loadDataBRGPopup()
        End If
    End Sub

    Private Sub in_barang_Leave(sender As Object, e As EventArgs) Handles in_barang_nm.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
            If Trim(in_barang_nm.Text) <> Nothing Then
                setBarang(in_barang_nm.Text)
            End If
        Else
            popPnl_barang.Visible = True
        End If

    End Sub

    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_barang_nm.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub dgv_listbarang_CellContentDBLClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellDoubleClick
        If e.RowIndex >= 0 Then
            indexrowlist = e.RowIndex
            in_barang.Text = dgv_listbarang.Rows(indexrowlist).Cells("brg_kode").Value
            setBarang("", in_barang.Text)
            in_qty.Focus()
        End If
    End Sub

    Private Sub dgv_listbarang_Cellenter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellEnter
        If e.RowIndex >= 0 Then
            indexrowlist = e.RowIndex
        End If
    End Sub

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            in_barang.Text = dgv_listbarang.Rows(indexrowlist).Cells("brg_kode").Value
            setBarang("", in_barang.Text)
            in_qty.Focus()
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.keyChar) Then
            in_barang_nm.Text += e.KeyChar
            e.Handled = True
            in_barang_nm.Focus()
        End If
    End Sub

    Private Sub in_barang_TextChanged(sender As Object, e As EventArgs) Handles in_barang_nm.TextChanged
        If in_barang_nm.Text = "" Then
            clearTextBarang()
        End If
    End Sub

    Private Sub in_barang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_barang_nm.KeyUp
        If popPnl_barang.Visible = True Then
            loadDataBRGPopup()
        End If
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang_nm.KeyDown
       If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            Else
                keyshortenter(in_qty, e)
            End If
        End If
    End Sub

    Private Sub linkLbl_searchbarang_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLbl_searchbarang.LinkClicked
        popPnl_barang.Visible = False
        Using search As New fr_search_dialog
            With search
                If Trim(in_barang_nm.Text) <> Nothing Then
                    .in_cari.Text = in_barang_nm.Text
                End If
                .returnkode = in_barang.Text
                .query = "SELECT barang_nama as nama, barang_kode as kode, barang_harga_beli as harga_beli " _
                         & "FROM data_barang_master " _
                         & "LEFT JOIN data_pembelian_trans ON barang_kode=trans_barang " _
                         & "LEFT JOIN data_pembelian_faktur ON trans_faktur=faktur_kode " _
                         & "WHERE faktur_supplier='" & cb_supplier.SelectedValue & "' " _
                         & "AND barang_nama LIKE '" & in_barang_nm.Text & "%' " _
                         & "GROUP BY barang_kode"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "barang"
                .ShowDialog()
                in_barang.Text = .returnkode
            End With
        End Using
        If Trim(in_barang.Text) <> Nothing Then
            setBarang(in_barang_nm.Text, Trim(in_barang.Text))
        End If
        in_qty.Focus()
        Exit Sub
    End Sub

    '-------------- load
    Private Sub fr_beli_retur_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cb_sat.SelectedIndex = -1
        With cb_supplier
            .DataSource = getDataTablefromDB("SELECT supplier_kode, supplier_nama FROM data_supplier_master")
            .DisplayMember = "supplier_nama"
            .ValueMember = "supplier_kode"
            .SelectedIndex = -1
        End With
        With cb_gudang
            .DataSource = getDataTablefromDB("SELECT gudang_kode, gudang_nama FROM data_barang_gudang")
            .DisplayMember = "gudang_nama"
            .ValueMember = "gudang_kode"
            .SelectedIndex = -1
        End With
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

        For Each x As DataGridViewColumn In {qty, harga, jml, brg_beli}
            x.DefaultCellStyle = dgvstyle_commathousand
        Next

        op_con()
        If in_no_bukti.Text <> Nothing Then
            loadData(in_no_bukti.Text)
            loadDataBrg(in_no_bukti.Text)
            in_no_bukti.ReadOnly = True
        End If

            cb_supplier.Focus()
    End Sub

    '----------------save
    Private Sub bt_simpanreturbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanreturbeli.Click
        If IsNothing(cb_supplier.SelectedValue) = True Then
            MessageBox.Show("Supplier belum di input")
            in_no_faktur.Focus()
            Exit Sub
        End If
        If IsNothing(cb_gudang.SelectedValue) = True Then
            MessageBox.Show("Gudang belum di input")
            in_no_faktur.Focus()
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

        op_con()

        If MessageBox.Show("Simpan data transaksi retur pembelian?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            'GENERATE KODE
            If in_no_bukti.Text = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT COUNT(faktur_kode_bukti) FROM data_pembelian_retur_faktur WHERE SUBSTRING(faktur_kode_bukti,3,8)='" & date_tgl_trans.Value.ToString("yyyyMMdd") & "' AND faktur_kode_bukti LIKE 'RB%'")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()
                in_no_bukti.Text = "RB" & date_tgl_trans.Value.ToString("yyyyMMdd") & no.ToString("D4")
            ElseIf in_no_bukti.Text <> Nothing And bt_simpanreturbeli.Text <> "Update" Then
                If checkdata("data_pembelian_faktur", "'" & in_no_bukti.Text & "'", "faktur_kode") = True Then
                    If MessageBox.Show("Update data faktur " & in_no_bukti.Text & "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                End If
            End If

            Dim querycheck As Boolean = False
            Dim dataFak, dataBrg As String()
            Dim data1, data2 As String()
            Dim queryArr As New List(Of String)
            Dim q1 As String = "INSERT INTO data_pembelian_retur_faktur SET faktur_kode_bukti='{0}',{1},{2} ON DUPLICATE KEY UPDATE {1},{3}"
            Dim q2 As String = "INSERT INTO data_pembelian_retur_trans SET trans_faktur= '{0}',{1} ON DUPLICATE KEY UPDATE {1}"
            Dim q3 As String = "DELETE FROM data_pembelian_retur_trans WHERE trans_faktur='{0}' AND trans_barang NOT IN({1})"

            dataFak = {
                    "faktur_tanggal_trans='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_pajak_no='" & in_pajak.Text & "'",
                    "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_gudang='" & cb_gudang.SelectedValue & "'",
                    "faktur_supplier='" & cb_supplier.SelectedValue & "'",
                    "faktur_kode_faktur='" & in_no_faktur.Text & "'",
                    "faktur_kode_exfaktur='" & in_no_faktur_ex.Text & "'",
                    "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text).ToString.Replace(",", ".") & "'",
                    "faktur_ppn='" & removeCommaThousand(in_ppn_tot.Text).ToString.Replace(",", ".") & "'",
                    "faktur_ppn_jenis='" & cb_ppn.SelectedValue & "'",
                    "faktur_netto='" & removeCommaThousand(in_netto.Text).ToString.Replace(",", ".") & "'",
                    "faktur_jen_bayar='" & cb_bayar_jenis.SelectedValue & "'",
                    "faktur_sebab='" & in_ket.Text & "'",
                    "faktur_status='" & statusretur & "'"
                    }
            data1 = {
                "faktur_reg_date=NOW()",
                "faktur_reg_alias='" & loggeduser.user_id & "'"
                }
            data2 = {
                "faktur_upd_date=NOW()",
                "faktur_upd_alias='" & loggeduser.user_id & "'"
                }
            'INSERT HEADER
            queryArr.Add(String.Format(q1, in_no_bukti.Text, String.Join(",", dataFak), String.Join(",", data1), String.Join(",", data2)))

            'INSERT BARANG
            Dim x As New List(Of String)
            Dim x_kodestock As New List(Of String)
            Dim qty As New List(Of Integer)
            Dim nilai As New List(Of Double)
            For Each rows As DataGridViewRow In dgv_barang.Rows
                Dim _stock As String = cb_gudang.SelectedValue & "-" & rows.Cells(0).Value & "-" & date_tgl_trans.Value.ToString("yyMM")
                'INSERT DATA BARANG
                dataBrg = {
                    "trans_barang='" & rows.Cells(0).Value & "'",
                    "trans_harga_retur='" & rows.Cells("harga").Value.ToString.Replace(",", ".") & "'",
                    "trans_qty='" & rows.Cells("qty").Value & "'",
                    "trans_satuan='" & rows.Cells("sat").Value & "'",
                    "trans_satuan_type='" & rows.Cells("sat_type").Value & "'",
                    "trans_jumlah='" & rows.Cells("jml").Value.ToString.Replace(",", ".") & "'"
                    }
                queryArr.Add(String.Format(q2, in_no_bukti.Text, String.Join(",", dataBrg)))

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
            'DELETE REMOVED ITEM
            queryArr.Add(String.Format(q3, in_no_bukti.Text, String.Join(",", x)))

            'WRITE KARTU STOK
            Dim q4 As String = "INSERT INTO data_stok_kartustok({0}) SELECT {1} FROM data_stok_kartustok WHERE trans_stock={2} ON DUPLICATE KEY UPDATE {3}"
            Dim q5 As String = "DELETE FROM data_stok_kartustok WHERE trans_faktur='{0}' AND trans_stock NOT IN({1})"
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
                    "trans_upd_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add(String.Format(q4, String.Join(",", data1), String.Join(",", data2), stock, String.Join(",", dataBrg)))
                i += 1
            Next
            'DONE : TODO : DELETE REMOVED ITEM FROM KARTU STOK
            queryArr.Add(String.Format(q5, in_no_bukti.Text, String.Join(",", x_kodestock)))

            'TODO : WRITE HUTANG AWAL
            If cb_bayar_jenis.SelectedValue = 1 Then
                Dim q6 As String = "INSERT INTO data_hutang_retur SET h_retur_faktur='{0}',h_retur_bukti_retur='{1}',{2} ON DUPLICATE KEY UPDATE h_retur_id=h_retur_id"
                data1 = {
                    "h_retur_total=" & removeCommaThousand(in_netto.Text),
                    "h_retur_reg_date=NOW()",
                    "h_retur_reg_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add(String.Format(q6, in_no_faktur.Text, in_no_bukti.Text, String.Join(",", data1)))
            End If

            'BEGIN TRANSACTION
            querycheck = startTrans(queryArr)
            Me.Cursor = Cursors.Default

            If querycheck = False Then
                Exit Sub
            Else
                'TODO : WRITE LOG ACTIVITY
                MessageBox.Show("Data tersimpan")
                frmpembelian.in_cari.Clear()
                populateDGVUserCon("returbeli", "", frmreturbeli.dgv_list)
                Me.Close()
            End If
        End If
    End Sub

    '------------------------ input
    Private Sub in_no_bukti_KeyDown(sender As Object, e As KeyEventArgs) Handles in_no_bukti.KeyDown
        keyshortenter(date_tgl_trans, e)
    End Sub

    Private Sub date_tgl_trans_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_trans.KeyDown
        keyshortenter(cb_supplier, e)
    End Sub

    Private Sub cb_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_supplier.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_supplier_list.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(cb_gudang, e)
        End If
    End Sub

    Private Sub bt_supplier_list_Click(sender As Object, e As EventArgs) Handles bt_supplier_list.Click
        Using search As New fr_search_dialog
            With search
                If cb_supplier.Text <> Nothing Then
                    .in_cari.Text = cb_supplier.Text
                End If
                If cb_supplier.SelectedValue <> Nothing Then
                    .returnkode = cb_supplier.SelectedValue
                End If
                .query = "SELECT supplier_kode as kode, supplier_nama as nama FROM data_supplier_master"
                .paramquery = "nama LIKE'{0}%' OR kode LIKE '{0}%'"
                .type = "supplier"
                .ShowDialog()
                cb_supplier.SelectedValue = .returnkode
            End With
        End Using
        cb_gudang.Focus()
    End Sub

    Private Sub cb_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_gudang.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_gudang_list.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(in_no_faktur_ex, e)
        End If
    End Sub

    Private Sub bt_gudang_list_Click(sender As Object, e As EventArgs) Handles bt_gudang_list.Click
        Using search As New fr_search_dialog
            With search
                If cb_gudang.Text <> Nothing Then
                    .in_cari.Text = cb_gudang.Text
                End If
                If cb_gudang.SelectedValue <> Nothing Then
                    .returnkode = cb_gudang.SelectedValue
                End If
                .query = "SELECT gudang_kode as kode, gudang_nama as nama FROM data_barang_gudang"
                .paramquery = "nama LIKE'{0}%' OR kode LIKE '{0}%'"
                .type = "gudang"
                .ShowDialog()
                cb_gudang.SelectedValue = .returnkode
            End With
        End Using
        in_no_faktur_ex.Focus()
    End Sub

    Private Sub in_no_faktur_ex_KeyDown(sender As Object, e As KeyEventArgs) Handles in_no_faktur_ex.KeyDown
        keyshortenter(cb_bayar_jenis, e)
    End Sub

    Private Sub cb_bayar_jenis_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_bayar_jenis.KeyDown
        keyshortenter(in_no_faktur, e)
    End Sub

    Private Sub in_no_faktur_KeyDown(sender As Object, e As KeyEventArgs) Handles in_no_faktur.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_faktur_list.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(in_pajak, e)
        End If
    End Sub

    Private Sub bt_faktur_list_Click(sender As Object, e As EventArgs) Handles bt_faktur_list.Click
        Using search As New fr_search_dialog
            With search
                If Trim(in_no_faktur.Text) <> Nothing Then
                    .in_cari.Text = Trim(in_no_faktur.Text)
                End If
                .query = "SELECT faktur_kode as kode, faktur_tanggal_trans as tgl, supplier_nama as supplier, gudang_nama as gudang FROM data_pembelian_faktur INNER JOIN data_supplier_master ON supplier_kode=faktur_supplier INNER JOIN data_barang_gudang ON gudang_kode=faktur_gudang ORDER BY kode DESC"
                .paramquery = "supplier LIKE'{0}%' OR kode LIKE '{0}%' OR gudang LIKE '{0}%'"
                .type = "beli"
                .ShowDialog()
                in_no_faktur.Text = .returnkode
                'loadDataFaktur(in_no_faktur.Text)
            End With
            in_pajak.Focus()
        End Using
    End Sub

    Private Sub in_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pajak.KeyDown
        keyshortenter(date_tgl_pajak, e)
    End Sub

    Private Sub date_tgl_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_pajak.KeyDown
        keyshortenter(in_barang_nm, e)
    End Sub

    '-------------------- input barang
    Private Sub in_qty_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
        If e.KeyCode = Keys.Enter Then
            keyshortenter(cb_sat, e)
            'cb_sat.DroppedDown = True
        End If
    End Sub

    Private Sub cb_sat_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat.KeyDown
        keyshortenter(in_harga_retur, e)
    End Sub
    Private Sub in_harga_retur_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_retur.KeyDown
        keyshortenter(bt_tbbarang, e)
    End Sub

    Private Sub in_harga_retur_ValueChanged(sender As Object, e As EventArgs) Handles in_harga_retur.ValueChanged, in_qty.ValueChanged
        in_subtotal.Text = commaThousand(in_qty.Value * in_harga_retur.Value)
    End Sub

    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        textToDgv()
    End Sub

    Private Sub dgv_barang_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        If e.RowIndex >= 0 Then
            rowindex = e.RowIndex
            dgvToTxt()
            dgv_barang.Rows.RemoveAt(rowindex)
        End If
    End Sub

    'menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanreturbeli.PerformClick()
    End Sub

    Private Sub mn_print_Click(sender As Object, e As EventArgs) Handles mn_print.Click
        Using nota As New fr_view_nota
            Me.Cursor = Cursors.WaitCursor
            With nota
                .setVar("returbeli", in_no_bukti.Text, "")
                .ShowDialog()
            End With
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    'other
    Private Sub cb_ppn_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_ppn.SelectionChangeCommitted
        countBiaya()
    End Sub
End Class