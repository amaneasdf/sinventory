Public Class fr_jual_retur_detail
    Private rowindex As Integer = 0
    Private rowindexlist As Integer = 0
    Private ppnjenis As String = "1"
    Private returstatus As String = "1"
    Private _persed As Decimal = 0

    Private Sub loadDataRetur(kode As String)
        readcommd("SELECT * FROM data_penjualan_retur_faktur WHERE faktur_kode_bukti='" & kode & "'")
        If rd.HasRows Then
            in_no_bukti.Text = kode
            in_pajak.Text = rd.Item("faktur_pajak_no")
            date_tgl_trans.Value = rd.Item("faktur_tanggal_trans")
            date_tgl_pajak.Value = rd.Item("faktur_pajak_tanggal")
            in_no_faktur.Text = rd.Item("faktur_kode_faktur")
            in_no_faktur_ex.Text = rd.Item("faktur_kode_exfaktur")
            'in_suratjalan.Text = rd.Item("faktur_surat_jalan")
            cb_sales.SelectedValue = rd.Item("faktur_sales")
            cb_custo.SelectedValue = rd.Item("faktur_custo")
            cb_gudang.SelectedValue = rd.Item("faktur_gudang")
            in_jumlah.Text = commaThousand(rd.Item("faktur_jumlah"))
            in_ppn_tot.Text = commaThousand(rd.Item("faktur_ppn_persen"))
            ppnjenis = rd.Item("faktur_ppn_jenis")
            in_netto.Text = commaThousand(rd.Item("faktur_netto"))
            returstatus = rd.Item("faktur_status")
            txtRegAlias.Text = rd.Item("faktur_reg_alias")
            txtRegdate.Text = rd.Item("faktur_reg_date")
        End If
        rd.Close()

        setReadOnly()
    End Sub

    Private Sub loadDataReturJualBrg(kode As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_retur, trans_qty, trans_satuan, trans_satuan_type, trans_hpp FROM data_penjualan_retur_trans INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & kode & "'")
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
                    .Cells("jml").Value = rows.ItemArray(3) * rows.ItemArray(2)
                    .Cells("brg_hpp").Value = rows.ItemArray(6)
                End With
            Next
        End With
        dt.Dispose()
    End Sub

    Private Sub loadDataFaktur(kode As String)
        op_con()
        readcommd("SELECT faktur_sales, faktur_ppn_jenis FROM data_penjualan_faktur WHERE faktur_kode='" & in_no_faktur.Text & "'")
        If rd.HasRows Then
            'cb_gudang.SelectedValue = rd.Item("faktur_gudang")
            cb_sales.SelectedValue = rd.Item("faktur_sales")
            'cb_custo.SelectedValue = rd.Item("faktur_customer")
            ppnjenis = rd.Item("faktur_ppn_jenis")
        End If
        rd.Close()
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
            .DataSource = getDataTablefromDB("SELECT barang_nama as nama, barang_kode as kode, barang_harga_jual FROM data_barang_master LEFT JOIN data_penjualan_trans ON trans_barang=barang_kode LEFT JOIN data_penjualan_faktur ON trans_faktur=faktur_kode WHERE barang_nama LIKE'" & in_barang_nm.Text & "%' AND faktur_customer='" & cb_custo.SelectedValue & "' GROUP BY barang_kode LIMIT 200")
        End With
    End Sub

    Private Sub setBarang(nama As String, Optional kode As String = Nothing)
        op_con()
        Dim isi As Integer = 1
        op_con()
        If kode = Nothing Then
            readcommd("SELECT barang_kode FROM data_stok_awal LEFT JOIN data_barang_master ON barang_kode=stock_barang WHERE barang_nama LIKE '" & nama & "%' LIMIT 1")
            If rd.HasRows Then
                kode = rd.Item(0)
                rd.Close()
            Else
                rd.Close()
                Exit Sub
            End If
        End If

        readcommd("SELECT barang_nama, barang_harga_jual FROM data_barang_master WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            in_barang_nm.Text = rd.Item("barang_nama")
            'satuan = rd.Item("trans_satuan")
            in_harga_retur.Value = rd.Item("barang_harga_jual")
            'in_qty.Maximum = rd.Item("trans_qty")
        End If
        rd.Close()

        If in_barang.Text <> Nothing Then
            loadSatuanBrg(kode)
            'cb_sat.SelectedIndex = 0
        End If
    End Sub

    Private Sub addRowBarang()
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
        readcommd("SELECT AVG(stock_hpp) FROM data_stok_awal WHERE stock_barang='" & in_barang.Text & "' AND stock_periode='" & date_tgl_trans.Value.ToString("yyyy-MM") & "'")
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
                .Cells("jml").Value = biayaPerItem()
                .Cells("brg_hpp").Value = hpp
            End With
        End With

        countBiaya()
        clearInputBarang()
        in_barang_nm.Clear()
        in_barang.Focus()
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
    End Sub

    Private Sub setFor(status As String)
        Select Case status
            Case "0"
                bt_simpanreturjual.Text = "Simpan"
            Case "1"
                bt_simpanreturjual.Text = "Update"
                in_status_kode.Text = "Active"
                in_no_bukti.ReadOnly = True
            Case "2"

        End Select
    End Sub

    Private Function biayaPerItem() As Double
        Dim x As Double = 0
        Dim y As Double = CDbl(in_harga_retur.Value)
        x = in_qty.Value * y

        Return x
    End Function

    Private Function jumlahBiayaPerItem() As Double
        Dim x As Double = 0
        _persed = 0
        For Each rows As DataGridViewRow In dgv_barang.Rows
            op_con()
            Dim _qtytot As Integer = 0
            readcommd("SELECT countQTYItem('" & rows.Cells(0).Value & "'," & rows.Cells("qty").Value & ",'" & rows.Cells("sat_type").Value & "')")
            If rd.HasRows Then
                _qtytot = rd.Item(0)
            End If
            x += rows.Cells("jml").Value
            _persed += _qtytot * rows.Cells("brg_hpp").Value
        Next
        Return x
    End Function

    Private Sub countBiaya()
        Dim x As Double = jumlahBiayaPerItem()
        Dim y As Double = 0
        Dim z As Double = x
        If ppnjenis = "1" Then
            y = x * (1 - 10 / 11)
        ElseIf ppnjenis = "2" Then
            y = x * 0.1
            z = x + y
        End If
        Dim cc As Globalization.CultureInfo = Globalization.CultureInfo.GetCultureInfo("id-ID")
        in_jumlah.Text = x.ToString("N2", cc)
        in_netto.Text = z.ToString("N2", cc)
        in_ppn_tot.Text = y.ToString("N2", cc)
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
        Dim txt As TextBox() = {in_no_bukti, in_no_faktur, in_no_faktur_ex, in_pajak, in_barang}
        For Each x As TextBox In txt
            x.ReadOnly = True
        Next

        in_ppn_tot.Enabled = False
        'cb_ppn_jenis.Enabled = False
    End Sub

    Private Sub clearDataFaktur()
        cb_gudang.SelectedValue = -1
        cb_sales.SelectedValue = -1
        cb_custo.SelectedValue = -1
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
    Private Sub bt_batalbeli_Click(sender As Object, e As EventArgs) Handles bt_batalreturjual.Click
        If MessageBox.Show("Tutup Form?", "Puchase Order", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalreturjual.PerformClick()
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

    '---------------- cb prevent input
    Private Sub cb_sat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_sat.KeyPress
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
            rowindexlist = e.RowIndex
            in_barang.Text = dgv_listbarang.Rows(rowindexlist).Cells("brg_kode").Value
            setBarang("", in_barang.Text)
            in_qty.Focus()
        End If
    End Sub

    Private Sub dgv_listbarang_Cellenter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellEnter
        If e.RowIndex >= 0 Then
            rowindexlist = e.RowIndex
        End If
    End Sub

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            in_barang.Text = dgv_listbarang.Rows(rowindexlist).Cells("brg_kode").Value
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
        clearTextBarang()
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    If Trim(in_barang_nm.Text) <> Nothing Then
                        .in_cari.Text = in_barang_nm.Text
                    End If
                    .returnkode = in_barang.Text
                    .query = "SELECT barang_nama as nama, barang_kode as kode, barang_harga_beli as hargabeli, barang_harga_jual as hargajual FROM data_barang_master"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "barang"
                    .ShowDialog()
                    in_barang.Text = .returnkode
                    setBarang(in_barang_nm.Text, in_barang.Text)
                End With
            End Using
            in_qty.Focus()
            Exit Sub
        ElseIf e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                rowindexlist = 0
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True Then
                rowindexlist = 0
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
                .query = "SELECT barang_nama as nama, barang_kode as kode, barang_harga_beli as hargabeli, barang_harga_jual as hargajual FROM data_barang_master"
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

    '------ LOAD
    Private Sub fr_jual_retur_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cb_sat.SelectedIndex = -1
        With cb_sales
            .DataSource = getDataTablefromDB("SELECT salesman_kode, salesman_nama FROM data_salesman_master")
            .DisplayMember = "salesman_nama"
            .ValueMember = "salesman_kode"
            .SelectedIndex = -1
        End With
        With cb_custo
            .DataSource = getDataTablefromDB("SELECT customer_kode, customer_nama FROM data_customer_master")
            .DisplayMember = "customer_nama"
            .ValueMember = "customer_kode"
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

        With date_tgl_trans
            .Value = DateSerial(selectedperiode.Year, selectedperiode.Month, date_tgl_trans.Value.Day)
            .MaxDate = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)
            .MinDate = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
        End With
        date_tgl_pajak.Value = DateSerial(selectedperiode.Year, selectedperiode.Month, date_tgl_pajak.Value.Day)


        op_con()
        If in_no_bukti.Text <> Nothing Then
            loadDataRetur(in_no_bukti.Text)
            loadDataReturJualBrg(in_no_bukti.Text)

        End If
    End Sub

    Private Sub bt_simpanreturjual_Click(sender As Object, e As EventArgs) Handles bt_simpanreturjual.Click
        If IsNothing(cb_gudang.SelectedValue) = True Then
            MessageBox.Show("Gudang belum di input")
            in_no_faktur.Focus()
            Exit Sub
        End If
        If IsNothing(cb_custo.SelectedValue) = True Then
            MessageBox.Show("Customer belum di input")
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

        Me.Cursor = Cursors.AppStarting

        op_con()

        'GENERATE KODE
        If in_no_bukti.Text = Nothing Then
            Dim no As Integer = 1
            readcommd("SELECT COUNT(faktur_kode) FROM data_penjualan_retur_faktur WHERE SUBSTRING(faktur_kode,3,8)='" & date_tgl_trans.Value.ToString("yyyyMMdd") & "' AND faktur_kode LIKE 'RJ%'")
            If rd.HasRows Then
                no = CInt(rd.Item(0)) + 1
            End If
            rd.Close()
            in_no_bukti.Text = "RJ" & date_tgl_trans.Value.ToString("yyyyMMdd") & no.ToString("D4")
        ElseIf in_no_bukti.Text <> Nothing And bt_simpanreturjual.Text <> "Update" Then
            If checkdata("data_penjualan_faktur", "'" & in_no_bukti.Text & "'", "faktur_kode") = True Then
                If MessageBox.Show("Faktur sudah ada. Update data faktur " & in_no_bukti.Text & "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If
        End If

        If MessageBox.Show("Simpan data transaksi retur penjualan?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
            Dim querycheck As Boolean = False
            Dim dataFak, dataBrg As String()
            Dim data1, data2 As String()
            Dim queryArr As New List(Of String)
            Dim q1 As String = "INSERT INTO data_penjualan_retur_faktur SET faktur_kode_bukti='{0}',{1},{2} ON DUPLICATE KEY UPDATE {1},{3}"
            Dim q2 As String = "INSERT INTO data_penjualan_retur_trans SET trans_faktur= '{0}',{1} ON DUPLICATE KEY UPDATE {1}"
            Dim q3 As String = "DELETE FROM data_penjualan_retur_trans WHERE trans_faktur='{0}' AND trans_barang NOT IN({1})"

            dataFak = {
                    "faktur_tanggal_trans='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_pajak_no='" & in_pajak.Text & "'",
                    "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_gudang='" & cb_gudang.SelectedValue & "'",
                    "faktur_sales='" & cb_sales.SelectedValue & "'",
                    "faktur_custo='" & cb_custo.SelectedValue & "'",
                    "faktur_kode_faktur='" & in_no_faktur.Text & "'",
                    "faktur_kode_exfaktur='" & in_no_faktur_ex.Text & "'",
                    "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text) & "'",
                    "faktur_ppn_persen='" & removeCommaThousand(in_ppn_tot.Text) & "'",
                    "faktur_ppn_jenis='" & ppnjenis & "'",
                    "faktur_netto='" & removeCommaThousand(in_netto.Text) & "'",
                    "faktur_jen_bayar='" & cb_bayar_jenis.SelectedValue & "'",
                    "faktur_status='" & returstatus & "'",
                    "faktur_persediaan='" & _persed & "'"
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

            Dim x As New List(Of String)
            Dim x_kodestock As New List(Of String)
            Dim qty As New List(Of Integer)
            Dim nilai As New List(Of Double)
            For Each rows As DataGridViewRow In dgv_barang.Rows
                'CHECK / INSERT DATA STOCK FOR GUDANG TUJUAN -> STOCK AWAL
                Dim stockkode As String = cb_gudang.SelectedValue & "-" & rows.Cells(0).Value & "-" & date_tgl_trans.Value.ToString("yyMM")
                dataBrg = {
                    "stock_kode='" & stockkode & "'",
                    "stock_gudang='" & cb_gudang.SelectedValue & "'",
                    "stock_barang='" & rows.Cells(0).Value & "'",
                    "stock_awal=0",
                    "stock_reg_alias='" & loggeduser.user_id & "'",
                    "stock_reg_date=NOW()"
                    }
                queryArr.Add("INSERT INTO data_stok_awal SET " & String.Join(",", dataBrg) & " ON DUPLICATE KEY UPDATE stock_kode=stock_kode")

                'INSERT BARANG
                dataBrg = {
                    "trans_barang='" & rows.Cells(0).Value & "'",
                    "trans_harga_retur='" & rows.Cells("harga").Value.ToString.Replace(".", ",") & "'",
                    "trans_qty='" & rows.Cells("qty").Value & "'",
                    "trans_satuan_type='" & rows.Cells("sat_type").Value & "'",
                    "trans_satuan='" & rows.Cells("sat").Value & "'",
                    "trans_hpp='" & rows.Cells("brg_hpp").Value.ToString.Replace(".", ",") & "'"
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
                x_kodestock.Add("'" & stockkode & "'")
            Next
            'DELETE REMOVED ITEM
            queryArr.Add(String.Format(q3, in_no_bukti.Text, String.Join(",", x)))

            'WRITE KARTU STOK
            Dim q4 As String = "INSERT INTO data_stok_kartustok({0}) SELECT {1} FROM data_stok_kartustok WHERE trans_stock={2} ON DUPLICATE KEY UPDATE {3}"
            Dim q5 As String = "DELETE FROM data_stok_kartustok WHERE trans_faktur='{0}' AND trans_stock NOT IN({1})"
            data1 = {
                    "trans_stock", "trans_index", "trans_jenis", "trans_faktur",
                    "trans_ket", "trans_qty", "trans_reg_alias", "trans_reg_date"
                    }
            Dim i As Integer = 0
            For Each stock As String In x_kodestock
                data2 = {
                        stock,
                        "MAX(trans_index)+1",
                        "'rj'",
                        "'" & in_no_bukti.Text & "'",
                        "'RETUR PENJUALAN'",
                        qty.Item(i),
                        "'" & loggeduser.user_id & "'",
                        "NOW()"
                        }
                dataBrg = {
                    "trans_qty=" & qty.Item(i),
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
                Dim q6 As String = "INSERT INTO data_piutang_retur SET p_retur_faktur='{0}',p_retur_bukti_retur='{1}',{2} ON DUPLICATE KEY UPDATE p_retur_id=p_retur_id"
                data1 = {
                    "p_retur_total=" & removeCommaThousand(in_netto.Text),
                    "p_retur_reg_date=NOW()",
                    "p_retur_reg_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add(String.Format(q6, in_no_faktur.Text, in_no_bukti.Text, String.Join(",", data1)))
            End If

            'BEGIN TRANSACTION
            querycheck = startTrans(queryArr)

            Me.Cursor = Cursors.Default

            If querycheck = False Then
                MessageBox.Show("Data tidak dapat tersimpan")
                Exit Sub
            Else
                MessageBox.Show("Data tersimpan")
                frmstockop.in_cari.Clear()
                populateDGVUserCon("returjual", "", frmreturjual.dgv_list)
                Me.Close()
            End If
        End If
    End Sub

    '--------------------input
    Private Sub in_no_bukti_KeyDown(sender As Object, e As KeyEventArgs) Handles in_no_bukti.KeyDown
        keyshortenter(cb_custo, e)
    End Sub

    Private Sub cb_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_custo.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_custo_list.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            cb_gudang.Focus()
        End If
    End Sub

    Private Sub bt_custo_list_Click(sender As Object, e As EventArgs) Handles bt_custo_list.Click
        Using search As New fr_search_dialog
            With search
                If cb_custo.Text <> Nothing Then
                    .in_cari.Text = cb_custo.Text
                End If
                If cb_custo.SelectedValue <> Nothing Then
                    .returnkode = cb_custo.SelectedValue
                End If
                .query = "SELECT customer_nama as nama, customer_kode as kode FROM data_customer_master"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "custo"
                .ShowDialog()
                cb_custo.SelectedValue = .returnkode
            End With
        End Using
        cb_gudang.Focus()
        Exit Sub
    End Sub

    Private Sub cb_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_gudang.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_gudang_list.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            in_no_faktur_ex.Focus()
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
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
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

    Private Sub cb_bayar_jenis_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_bayar_jenis.SelectionChangeCommitted
        in_no_faktur.Focus()
    End Sub

    Private Sub cb_bayar_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_bayar_jenis.KeyPress
        e.Handled = True
    End Sub

    Private Sub in_no_faktur_KeyUp(sender As Object, e As KeyEventArgs) Handles in_no_faktur.KeyUp
        If e.KeyCode = Keys.Enter Then
            keyshortenter(in_pajak, e)
        Else
            bt_faktur_list.PerformClick()
        End If
    End Sub

    Private Sub in_no_faktur_Leave(sender As Object, e As EventArgs) Handles in_no_faktur.Leave
        If in_no_faktur.Text <> Nothing Then
            loadDataFaktur(in_no_faktur.Text)
        End If
    End Sub

    Private Sub bt_faktur_list_Click(sender As Object, e As EventArgs) Handles bt_faktur_list.Click
        Using search As New fr_search_dialog
            With search
                If Trim(in_no_faktur.Text) <> Nothing Then
                    .in_cari.Text = Trim(in_no_faktur.Text)
                End If
                .query = "SELECT faktur_kode as kode, faktur_tanggal_trans as tgl, gudang_nama as gudang, salesman_nama as sales, customer_nama as custo FROM data_penjualan_faktur inner join data_barang_gudang on gudang_kode=faktur_gudang inner join `data_customer_master` on customer_kode=faktur_customer inner join `data_salesman_master` on salesman_kode=faktur_sales WHERE DATE_FORMAT(faktur_tanggal_trans,'%y%m')='" & date_tgl_trans.Value.ToString("yyMM") & "' ORDER BY kode DESC;"
                .paramquery = "kode LIKE '%{0}%' OR sales LIKE '%{0}%' OR custo LIKE '%{0}%'"
                .type = "jual"
                .ShowDialog()
                .in_cari.Focus()
                in_no_faktur.Text = .returnkode
            End With
            in_pajak.Focus()
        End Using
    End Sub

    Private Sub in_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pajak.KeyDown
        keyshortenter(date_tgl_pajak, e)
    End Sub

    Private Sub date_tgl_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_pajak.KeyDown
        keyshortenter(in_barang, e)
    End Sub

    '--------------- input barang
    Private Sub in_qty_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
        If e.KeyCode = Keys.Enter Then
            keyshortenter(cb_sat, e)
            cb_sat.DroppedDown = True
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
        addRowBarang()
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
        bt_simpanreturjual.PerformClick()
    End Sub

    Private Sub mn_print_Click(sender As Object, e As EventArgs) Handles mn_print.Click
        Using nota As New fr_view_piutang
            Me.Cursor = Cursors.WaitCursor
            With nota
                .setVar("returjual", in_no_bukti.Text, "")
                .ShowDialog()
            End With
        End Using
        Me.Cursor = Cursors.Default
    End Sub
End Class