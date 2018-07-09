Public Class fr_jual_retur_detail
    Private rowindex As Integer
    Private ppnjenis As String = "1"
    Private returstatus As String = "0"

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
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_retur, trans_qty, trans_satuan, trans_jumlah FROM data_penjualan_retur_trans INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & kode & "'")
        With dgv_barang.Rows
            For Each rows As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("kode").Value = rows.ItemArray(0)
                    .Cells("nama").Value = rows.ItemArray(1)
                    .Cells("harga").Value = rows.ItemArray(2)
                    .Cells("qty").Value = rows.ItemArray(3)
                    .Cells("sat").Value = rows.ItemArray(4)
                    .Cells("jml").Value = rows.ItemArray(5)
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
        readcommd("SELECT barang_satuan_kecil, barang_satuan_tengah, barang_satuan_besar FROM data_barang_master WHERE barang_kode='" & kode & "'")
        cb_sat.Items.Clear()
        cb_sat.Items.Add(rd.Item("barang_satuan_kecil"))
        cb_sat.Items.Add(rd.Item("barang_satuan_tengah"))
        cb_sat.Items.Add(rd.Item("barang_satuan_besar"))
        rd.Close()
    End Sub

    Private Sub loadDataBRGPopup()
        With dgv_listbarang
            .DataSource = getDataTablefromDB("SELECT barang_nama as nama, barang_kode as kode, barang_harga_jual FROM data_barang_master WHERE barang_kode LIKE '%" & in_barang.Text & "%' LIMIT 200")
        End With
    End Sub

    Private Sub setBarang(kode As String)
        op_con()
        readcommd("SELECT barang_nama, barang_harga_jual FROM data_barang_master WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            in_barang_nm.Text = rd.Item("barang_nama")
            'satuan = rd.Item("trans_satuan")
            in_harga_retur.Value = rd.Item("barang_harga_jual")
            'in_qty.Maximum = rd.Item("trans_qty")
        End If
        rd.Close()

        If in_barang_nm.Text <> Nothing Then
            loadSatuanBrg(kode)
            cb_sat.SelectedIndex = 0
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

        'op_con()
        'Try
        '    readcommd(String.Format("SELECT countQTYJual(a.trans_barang,a.trans_qty,a.trans_satuan)-countQTYJual(c.trans_barang,IFNULL(c.trans_qty,0),c.trans_satuan) as qtysisa, countQTYJual('{0}','{2}','{3}') as qtyinput FROM data_penjualan_trans a LEFT JOIN data_penjualan_retur_faktur b ON b.faktur_kode_faktur=a.trans_faktur LEFT JOIN data_penjualan_retur_trans c ON c.trans_faktur=b.faktur_kode_bukti WHERE a.trans_barang='{0}' AND a.trans_faktur='{1}'", in_barang.Text, in_no_faktur.Text, in_qty.Value, cb_sat.SelectedItem))
        '    Dim qtysisa As Integer = rd.Item("qtysisa")
        '    Dim qtyinput As Integer = rd.Item("qtyinput")
        '    rd.Close()
        '    If qtyinput > qtysisa Then
        '        MessageBox.Show("QTY yg diinput lebih besar dari penjualan")
        '        in_qty.Focus()
        '        Exit Sub
        '    End If
        'Catch ex As Exception
        '    Console.WriteLine("ERR:" & ex.Message)
        '    Exit Sub
        'End Try

        With dgv_barang.Rows
            Dim x As Integer = .Add
            With .Item(x)
                .Cells("kode").Value = in_barang.Text
                .Cells("nama").Value = in_barang_nm.Text
                .Cells("qty").Value = in_qty.Value
                .Cells("sat").Value = cb_sat.SelectedItem
                .Cells("harga").Value = in_harga_retur.Value
                .Cells("jml").Value = biayaPerItem()
            End With
        End With

        countBiaya()
        clearInputBarang()
        in_barang.Clear()
        in_barang.Focus()
    End Sub

    Private Sub dgvToTxt()
        With dgv_barang.Rows(rowindex)
            loadSatuanBrg(.Cells("kode").Value)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty.Value = .Cells("qty").Value
            cb_sat.SelectedItem = .Cells("sat").Value
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
        For Each rows As DataGridViewRow In dgv_barang.Rows
            Console.WriteLine(rows.Cells("jml").Value)
            x += rows.Cells("jml").Value
        Next
        Return x
    End Function

    Private Sub countBiaya()
        Dim x As Double = jumlahBiayaPerItem()
        Dim y As Double = 0
        Dim z As Double = x
        If ppnjenis = "1" Then
            y = x * 0.1
        ElseIf ppnjenis = "2" Then
            y = x * 0.1
            z = x + y
        End If
        Dim cc As Globalization.CultureInfo = Globalization.CultureInfo.GetCultureInfo("id-ID")
        in_jumlah.Text = x.ToString("N2", cc)
        in_netto.Text = z.ToString("N2", cc)
        in_ppn_tot.Text = y.ToString("N2", cc)
    End Sub

    Private Sub numericGotFocus(sender As NumericUpDown)
        If sender.Value = 0 Then
            sender.ResetText()
        End If
    End Sub

    Private Sub numericLostFocus(x As NumericUpDown)
        x.Controls.Item(1).Text = x.Value
    End Sub

    Private Sub keyshortenter(nextcontrol As Control, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nextcontrol.Focus()
        End If
    End Sub

    Private Sub clearInputBarang()
        in_barang_nm.Clear()
        cb_sat.Text = ""
        cb_sat.Items.Clear()
        in_subtotal.Clear()
        in_harga_retur.Value = 0
        'in_barang.Clear()
        in_qty.Value = 0
        'in_qty.Maximum = 99999
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

        End With

        op_con()
        If bt_simpanreturjual.Text <> "Simpan" Then
            loadDataRetur(in_no_bukti.Text)
            loadDataReturJualBrg(in_no_bukti.Text)

        End If
    End Sub

    Private Sub bt_simpanreturjual_Click(sender As Object, e As EventArgs) Handles bt_simpanreturjual.Click
        'If Trim(in_no_bukti.Text) = "" Then
        '    MessageBox.Show("No.Bukti belum di input")
        '    in_no_bukti.Focus()
        '    Exit Sub
        'End If
        If Trim(in_no_faktur.Text) = "" Then
            MessageBox.Show("No.Faktur belum di input")
            in_no_faktur.Focus()
            Exit Sub
        Else
            op_con()
            Try
                loadDataFaktur(in_no_faktur.Text)
            Catch ex As Exception
                Console.Write(ex.Message)
            End Try
        End If
        If IsNothing(cb_gudang.SelectedValue) = True Then
            MessageBox.Show("Gudang belum di input, Input No.Faktur yang benar")
            in_no_faktur.Focus()
            Exit Sub
        End If
        If IsNothing(cb_custo.SelectedValue) = True Then
            MessageBox.Show("Customer belum di input, Input No.Faktur yang benar")
            in_no_faktur.Focus()
            Exit Sub
        End If
        If IsNothing(cb_gudang.SelectedValue) = True Then
            MessageBox.Show("Gudang belum di input, Input No.Faktur yang benar")
            in_no_faktur.Focus()
            Exit Sub
        End If
        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum di input")
            in_barang.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.AppStarting

        Dim querycheck As Boolean = False
        Dim dataFak As String()
        Dim dataBrg As String()
        Dim queryArr As New List(Of String)

        op_con()
        If bt_simpanreturjual.Text = "Simpan" Then
            If Trim(in_no_bukti.Text) <> Nothing Then
                'TODO check no_bukti
                If checkdata("data_penjualan_retur_faktur", "'" & in_no_bukti.Text & "'", "faktur_kode_bukti") = True Then
                    MessageBox.Show("No.Bukti " & in_no_bukti.Text & " sudah ada!")
                    in_no_bukti.Select()
                    Exit Sub
                End If
            Else
                'TODO generate kode
                readcommd("SELECT COUNT(faktur_kode_faktur) FROM data_penjualan_retur_faktur WHERE faktur_kode_faktur='" & in_no_faktur.Text & "'")
                Dim x As Integer = rd.Item(0)
                x += 1
                rd.Close()
                Dim fakturkode As String = "RS" & in_no_faktur.Text & "" & x.ToString("D2")
                in_no_bukti.Text = fakturkode
            End If
            
            dataFak = {
                "faktur_kode_bukti='" & in_no_bukti.Text & "'",
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
                "faktur_status=1",
                "faktur_reg_date=NOW()",
                "faktur_reg_alias='" & loggeduser.user_id & "'"
                }
            'TODO insert faktur
            queryArr.Add("INSERT INTO data_penjualan_retur_faktur SET " & String.Join(",", dataFak))


            For Each rows As DataGridViewRow In dgv_barang.Rows
                dataBrg = {
                "trans_faktur='" & in_no_bukti.Text & "'",
                "trans_tanggal='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                "trans_barang='" & rows.Cells(0).Value & "'",
                "trans_harga_retur='" & rows.Cells("harga").Value & "'",
                "trans_qty='" & rows.Cells("qty").Value & "'",
                "trans_satuan='" & rows.Cells("sat").Value & "'",
                "trans_jumlah='" & rows.Cells("jml").Value & "'",
                "trans_reg_date=NOW()",
                "trans_reg_alias='" & loggeduser.user_id & "'"
                }
                'TODO insert brg
                queryArr.Add("INSERT INTO data_penjualan_retur_trans SET " & String.Join(",", dataBrg))

                ''TODO Update stok
                'queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_return_jual=IFNULL(stock_return_jual,0)+(countQTYJual('{0}','{2}','{3}')) WHERE stock_barang='{0}' AND stock_gudang='{1}'", rows.Cells(0).Value, cb_gudang.SelectedValue, rows.Cells("qty").Value, rows.Cells("sat").Value))
                'queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_sisa=countQTYSisaSTock('{0}','{1}') WHERE stock_barang='{0}' AND stock_gudang='{1}'", rows.Cells(0).Value, cb_gudang.SelectedValue))

                ''log
                'queryArr.Add(String.Format("INSERT INTO log_stock SET log_reg=NOW(), log_user='{0}', log_barang='{1}', log_gudang='{2}', log_tanggal=NOW(), log_ip='{3}', log_komputer='{4}', log_mac='{5}', log_nama='RETURJUAL {6}', log_ket='BUKTI {7}'", loggeduser.user_id, rows.Cells(0).Value, cb_gudang.SelectedValue, loggeduser.user_ip, loggeduser.user_host, loggeduser.user_mac, in_no_faktur.Text, in_no_bukti.Text))
            Next
        Else
            Me.Close()
        End If

        querycheck = startTrans(queryArr)

        Me.Cursor = Cursors.Default

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            Try
                loadDataFaktur(in_no_bukti.Text)
            Catch ex As Exception
                returstatus = "1"
            End Try
            'setFor(statusop)
            frmstockop.in_cari.Clear()
            populateDGVUserCon("returjual", "", frmreturjual.dgv_list)
            'Me.Close()
        End If
    End Sub

    '---------------numeric
    Private Sub numericenter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_harga_retur.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub numericleave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_harga_retur.Leave
        numericLostFocus(sender)
    End Sub

    '---------------close
    Private Sub bt_batalreturjual_Click(sender As Object, e As EventArgs) Handles bt_batalreturjual.Click
        If MessageBox.Show("Tutup Form?", "Retur Sales", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    '----------------CL bt
    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalreturjual.PerformClick()
        'Me.WindowState = 1
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
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

    Private Sub in_no_faktur_KeyDown(sender As Object, e As KeyEventArgs) Handles in_no_faktur.KeyDown
        clearDataFaktur()
        If e.KeyCode = Keys.F1 Then
            bt_faktur_list.PerformClick()
        End If
        keyshortenter(in_pajak, e)
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
                .query = "SELECT faktur_kode as kode, faktur_tanggal_trans as tgl, gudang_nama as gudang, salesman_nama as sales, customer_nama as custo FROM data_penjualan_faktur inner join data_barang_gudang on gudang_kode=faktur_gudang inner join `data_customer_master` on customer_kode=faktur_customer inner join `data_salesman_master` on salesman_kode=faktur_sales ORDER BY kode DESC;"
                .paramquery = "kode LIKE '%{0}%' OR sales LIKE '%{0}%' OR custo LIKE '%{0}%'"
                .type = "jual"
                .ShowDialog()
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

    'Private Sub cb_gudang_Leave(sender As Object, e As EventArgs) Handles cb_custo.Leave, cb_gudang.Leave, cb_sales.Leave
    '    If Trim(in_no_faktur.Text) <> Nothing Then
    '        loadDataFaktur(in_no_faktur.Text)
    '    End If
    'End Sub

    '--------------- input barang
    Private Sub in_barang_Enter(sender As Object, e As EventArgs) Handles in_barang_nm.Enter, in_barang.Enter
        popPnl_barang.Location = New Point(in_barang.Left, in_barang.Top + in_barang.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
            loadDataBRGPopup()
        End If
    End Sub

    Private Sub in_barang_Leave(sender As Object, e As EventArgs) Handles in_barang_nm.Leave, in_barang.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If

        If Trim(in_barang.Text) <> Nothing Then
            setBarang(in_barang.Text)
        End If
    End Sub

    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_barang.Focused = True Or in_barang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub dgv_listbarang_CellContentDBLClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellDoubleClick
        in_barang.Text = dgv_listbarang.Rows(e.RowIndex).Cells("brg_kode").Value
        setBarang(in_barang.Text)
        in_qty.Focus()
    End Sub

    Private Sub in_barang_TextChanged(sender As Object, e As EventArgs) Handles in_barang.TextChanged
        If in_barang.Text = "" Then
            clearInputBarang()
        End If
        If popPnl_barang.Visible = True Then
            loadDataBRGPopup()
        End If
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        clearInputBarang()
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    If Trim(in_barang.Text) <> Nothing Then
                        .in_cari.Text = in_barang.Text
                    End If
                    .returnkode = in_barang.Text
                    .query = "SELECT barang_nama as nama, barang_kode as kode, trans_qty as qty FROM data_penjualan_trans INNER JOIN data_barang_master ON barang_kode=trans_barang WHERE trans_faktur='" & in_no_faktur.Text & "'"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "barangfaktur"
                    .ShowDialog()
                    in_barang.Text = .returnkode
                End With
            End Using
            If Trim(in_barang.Text) <> Nothing Then
                setBarang(Trim(in_barang.Text))
            End If
            in_qty.Focus()
            Exit Sub

        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(in_qty, e)
            If Trim(in_barang.Text) <> Nothing Then
                setBarang(Trim(in_barang.Text))
            End If
        End If
    End Sub

    Private Sub linkLbl_searchbarang_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLbl_searchbarang.LinkClicked
        popPnl_barang.Visible = False
        Using search As New fr_search_dialog
            With search
                If Trim(in_barang.Text) <> Nothing Then
                    .in_cari.Text = in_barang.Text
                End If
                .returnkode = in_barang.Text
                .query = "SELECT barang_nama as nama, barang_kode as kode, trans_qty as qty FROM data_penjualan_trans INNER JOIN data_barang_master ON barang_kode=trans_barang WHERE trans_faktur='" & in_no_faktur.Text & "'"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "barangfaktur"
                .ShowDialog()
                in_barang.Text = .returnkode
            End With
        End Using
        If Trim(in_barang.Text) <> Nothing Then
            setBarang(Trim(in_barang.Text))
        End If
        in_qty.Focus()
        Exit Sub
    End Sub

    Private Sub in_qty_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
        If e.KeyCode = Keys.Enter Then
            keyshortenter(cb_sat, e)
            cb_sat.DroppedDown = True
        End If
    End Sub

    Private Sub cb_sat_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat.KeyDown
        keyshortenter(in_harga_retur, e)
    End Sub

    Private Sub cb_sat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_sat.KeyPress
        e.Handled = True
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
End Class