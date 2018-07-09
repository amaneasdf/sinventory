Public Class fr_beli_retur_detail
    Private rowindex As Integer = 0
    Private ppnjenis As String = "1"
    Private statusretur As String = "1"

    '-----------------------note
    'hitung pajak -> unfinished
    'all accounting calculation is not yet finished or even created
    'retur di sistem berjalan tidak berdasarkan faktur pembelian saat input
    '

    Private Sub loadDataRetur(kode As String)
        readcommd("SELECT * FROM data_pembelian_retur_faktur WHERE faktur_kode_bukti='" & kode & "'")
        If rd.HasRows Then
            in_no_bukti.Text = kode
            in_pajak.Text = rd.Item("faktur_pajak_no")
            date_tgl_trans.Value = rd.Item("faktur_tanggal_trans")
            date_tgl_pajak.Value = rd.Item("faktur_pajak_tanggal")
            in_no_faktur.Text = rd.Item("faktur_kode_faktur")
            in_no_faktur_ex.Text = rd.Item("faktur_kode_exfaktur")
            'in_suratjalan.Text = rd.Item("faktur_surat_jalan")
            in_ket.Text = rd.Item("faktur_sebab")
            cb_supplier.SelectedValue = rd.Item("faktur_supplier")
            cb_gudang.SelectedValue = rd.Item("faktur_gudang")
            in_jumlah.Text = commaThousand(rd.Item("faktur_jumlah"))
            in_ppn_tot.Text = commaThousand(rd.Item("faktur_ppn"))
            ppnjenis = rd.Item("faktur_ppn_jenis")
            in_netto.Text = commaThousand(rd.Item("faktur_netto"))
            in_status_kode.Text = rd.Item("faktur_status")
            'cb_status.SelectedValue = in_status_kode.Text
            txtRegAlias.Text = rd.Item("faktur_reg_alias")
            txtRegdate.Text = rd.Item("faktur_reg_date")
        End If
        rd.Close()
        setReadOnly()
    End Sub

    Private Sub loadDataReturBrg(kode As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_retur, trans_qty, trans_satuan, trans_jumlah FROM data_pembelian_retur_trans INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & kode & "'")
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

    'Private Sub loadDataFaktur(kode As String)
    '    op_con()
    '    readcommd("SELECT faktur_gudang, faktur_supplier, faktur_ppn_jenis FROM data_pembelian_faktur WHERE faktur_kode='" & in_no_faktur.Text & "'")
    '    If rd.HasRows Then
    '        cb_gudang.SelectedValue = rd.Item("faktur_gudang")
    '        cb_supplier.SelectedValue = rd.Item("faktur_supplier")
    '        ppnjenis = rd.Item("faktur_ppn_jenis")
    '    End If
    '    rd.Close()
    'End Sub

    Private Sub loadSatuanBrg(kode As String)
        op_con()
        readcommd("SELECT barang_satuan_kecil, barang_satuan_tengah, barang_satuan_besar FROM data_barang_master WHERE barang_kode='" & kode & "'")
        cb_sat.ResetText()
        cb_sat.Items.Clear()
        cb_sat.Items.Add(rd.Item("barang_satuan_kecil"))
        cb_sat.Items.Add(rd.Item("barang_satuan_tengah"))
        cb_sat.Items.Add(rd.Item("barang_satuan_besar"))
        rd.Close()
    End Sub

    Private Sub loadDataBRGPopup()
        With dgv_listbarang
            .DataSource = getDataTablefromDB("SELECT barang_nama as nama, barang_kode as kode, barang_harga_beli as harga_beli FROM data_barang_master WHERE barang_kode LIKE '%" & in_barang.Text & "%' LIMIT 200")
        End With
    End Sub

    Private Sub setBarang(kode As String)
        op_con()
        readcommd("SELECT barang_nama, barang_kode, barang_harga_beli FROM data_barang_master WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            in_barang_nm.Text = rd.Item("barang_nama")
            in_harga_retur.Value = rd.Item("barang_harga_beli")
            'in_qty.Maximum = rd.Item("trans_qty")
        End If
        rd.Close()

        If in_barang_nm.Text <> Nothing Then
            loadSatuanBrg(kode)
            cb_sat.SelectedIndex = 2
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

        Me.Cursor = Cursors.AppStarting

        'op_con()
        'readcommd(String.Format("SELECT countQTYJual(a.trans_barang,a.trans_qty,a.trans_satuan)-countQTYJual(c.trans_barang,IFNULL(c.trans_qty,0),c.trans_satuan) as qtysisa, countQTYJual('{0}','{2}','{3}') as qtyinput FROM data_pembelian_trans a LEFT JOIN data_pembelian_retur_faktur b ON b.faktur_kode_faktur=a.trans_faktur LEFT JOIN data_pembelian_retur_trans c ON c.trans_faktur=b.faktur_kode_bukti WHERE a.trans_barang='{0}' AND a.trans_faktur='{1}'", in_barang.Text, in_no_faktur.Text, in_qty.Value, cb_sat.Text))
        'Dim qtysisa As Integer = rd.Item("qtysisa")
        'Dim qtyinput As Integer = rd.Item("qtyinput")
        'rd.Close()
        'If qtyinput > qtysisa Then
        '    MessageBox.Show("QTY yg diinput lebih besar dari pembelian")
        '    in_qty.Focus()
        '    Exit Sub
        'End If

        With dgv_barang.Rows
            Dim x As Integer = .Add
            With .Item(x)
                .Cells("kode").Value = in_barang.Text
                .Cells("nama").Value = in_barang_nm.Text
                .Cells("qty").Value = in_qty.Value
                .Cells("sat").Value = cb_sat.Text
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
            cb_sat.SelectedItem = .Cells("sat").Value
            in_harga_retur.Text = .Cells("harga").Value
        End With
        countBiaya()
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
        Dim txt As TextBox() = {
            in_no_bukti, in_no_faktur, in_no_faktur_ex, in_pajak, in_barang
            }
        For Each x As TextBox In txt
            x.ReadOnly = True
        Next

        in_ppn_tot.Enabled = False
        'cb_ppn_jenis.Enabled = False
    End Sub

    Private Sub clearDataFaktur()
        cb_gudang.SelectedIndex = -1
        cb_supplier.SelectedIndex = -1
    End Sub

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

        End With

        op_con()
        If bt_simpanreturbeli.Text = "OK" Then
            loadDataRetur(in_no_bukti.Text)
            loadDataReturBrg(in_no_bukti.Text)

        End If

        cb_supplier.Focus()
    End Sub

    '---------------numeric
    Private Sub numericenter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_harga_retur.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub numericleave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_harga_retur.Leave
        numericLostFocus(sender)
    End Sub

    '---------------close
    Private Sub bt_batalreturbeli_Click(sender As Object, e As EventArgs) Handles bt_batalreturbeli.Click
        If MessageBox.Show("Tutup Form?", "Retur Puchase Order", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    '----------------CL bt
    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalreturbeli.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '----------------save
    Private Sub bt_simpanreturbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanreturbeli.Click
        'If Trim(in_no_faktur.Text) = "" Then
        '    MessageBox.Show("No.Faktur belum di input")
        '    in_no_faktur.Focus()
        '    Exit Sub
        'End If
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

        Dim querycheck As Boolean = False
        Dim dataFak As String()
        Dim dataBrg As String()
        Dim queryArr As New List(Of String)

        op_con()
        If bt_simpanreturbeli.Text = "Simpan" Then
            If Trim(in_no_bukti.Text) <> Nothing Then
                'TODO check no_bukti
                If checkdata("data_pembelian_retur_faktur", "'" & in_no_bukti.Text & "'", "faktur_kode_bukti") = True Then
                    MessageBox.Show("No.Bukti " & in_no_bukti.Text & " sudah ada!")
                    in_no_bukti.Select()
                    Exit Sub
                End If
            Else
                'TODO generate kode
                readcommd("SELECT COUNT(faktur_tanggal_trans) FROM data_pembelian_retur_faktur WHERE faktur_tanggal_trans='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'")
                Dim x As Integer = rd.Item(0)
                x += 1
                rd.Close()
                Dim fakturkode As String = "RTJL-" & date_tgl_trans.Value.ToString("yyyyMMdd") & "-" & x.ToString("D2")
                in_no_bukti.Text = fakturkode
            End If


            dataFak = {
                "faktur_kode_bukti='" & in_no_bukti.Text & "'",
                "faktur_tanggal_trans='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_pajak_no='" & in_pajak.Text & "'",
                "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_gudang='" & cb_gudang.SelectedValue & "'",
                "faktur_supplier='" & cb_supplier.SelectedValue & "'",
                "faktur_kode_faktur='" & in_no_faktur.Text & "'",
                "faktur_kode_exfaktur='" & in_no_faktur_ex.Text & "'",
                "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text) & "'",
                "faktur_ppn_persen='" & removeCommaThousand(in_ppn_tot.Text) & "'",
                "faktur_ppn_jenis='1'",
                "faktur_netto='" & removeCommaThousand(in_netto.Text) & "'",
                "faktur_sebab='" & in_ket.Text & "'",
                "faktur_status=1",
                "faktur_reg_date=NOW()",
                "faktur_reg_alias='" & loggeduser.user_id & "'"
                }
            'TODO insert faktur
            'querycheck = commnd("INSERT INTO data_pembelian_retur_faktur SET " & String.Join(",", dataFak))
            queryArr.Add("INSERT INTO data_pembelian_retur_faktur SET " & String.Join(",", dataFak))

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
                'querycheck = commnd("INSERT INTO data_pembelian_retur_trans SET " & String.Join(",", dataBrg))
                queryArr.Add("INSERT INTO data_pembelian_retur_trans SET " & String.Join(",", dataBrg))

                'TODO Update stok
                queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_return_beli=IFNULL(stock_return_beli,0)+(countQTYJual('{0}','{2}','{3}')) WHERE stock_barang='{0}' AND stock_gudang='{1}'", rows.Cells(0).Value, cb_gudang.SelectedValue, rows.Cells("qty").Value, rows.Cells("sat").Value))
                queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_sisa=countQTYSisaSTock('{0}','{1}') WHERE stock_barang='{0}' AND stock_gudang='{1}'", rows.Cells(0).Value, cb_gudang.SelectedValue))

                'log
                queryArr.Add(String.Format("INSERT INTO log_stock SET log_reg=NOW(), log_user='{0}', log_barang='{1}', log_gudang='{2}', log_tanggal=NOW(), log_ip='{3}', log_komputer='{4}', log_mac='{5}', log_nama='RETUR BELI {6}', log_ket='BUKTI {7}'", loggeduser.user_id, rows.Cells(0).Value, cb_gudang.SelectedValue, loggeduser.user_ip, loggeduser.user_host, loggeduser.user_mac, in_no_faktur.Text, in_no_bukti.Text))
            Next
        Else
            Me.Close()
        End If

        'begin transaction
        querycheck = startTrans(queryArr)

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmpembelian.in_cari.Clear()
            populateDGVUserCon("returbeli", "", frmreturbeli.dgv_list)
            'Me.Close()
        End If
    End Sub

    Private Sub in_no_faktur_KeyDown(sender As Object, e As KeyEventArgs) Handles in_no_faktur.KeyDown
        'clearDataFaktur()
        If e.KeyCode = Keys.F1 Then
            bt_faktur_list.PerformClick()
        End If
        keyshortenter(in_pajak, e)
    End Sub

    Private Sub bt_faktur_list_Click(sender As Object, e As EventArgs) Handles bt_faktur_list.Click
        Using search As New fr_search_dialog
            With search
                If Trim(in_no_faktur.Text) <> Nothing Then
                    .in_cari.Text = Trim(in_no_faktur.Text)
                End If
                .query = "SELECT faktur_kode as kode, faktur_tanggal_trans as tgl, supplier_nama as supplier, gudang_nama as gudang FROM data_pembelian_faktur INNER JOIN data_supplier_master ON supplier_kode=faktur_supplier INNER JOIN data_barang_gudang ON gudang_kode=faktur_gudang ORDEr BY kode DESC"
                .paramquery = "supplier LIKE'%{0}%' OR kode LIKE '%{0}%' OR gudang LIKE '%{0}%'"
                .type = "beli"
                .ShowDialog()
                in_no_faktur.Text = .returnkode
                'loadDataFaktur(in_no_faktur.Text)
            End With
            in_pajak.Focus()
        End Using
    End Sub

    Private Sub in_no_faktur_ex_KeyDown(sender As Object, e As KeyEventArgs) Handles in_no_faktur_ex.KeyDown
        keyshortenter(cb_bayar_jenis, e)
    End Sub

    Private Sub cb_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_gudang.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_gudang_list.PerformClick()
        End If
        keyshortenter(in_no_faktur_ex, e)
    End Sub

    Private Sub cb_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_supplier.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_supplier_list.PerformClick()
        End If
        keyshortenter(cb_gudang, e)
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
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "supplier"
                .ShowDialog()
                cb_supplier.SelectedValue = .returnkode
            End With
        End Using
        cb_gudang.Focus()
    End Sub

    'Private Sub cb_gudang_Leave(sender As Object, e As EventArgs) Handles cb_supplier.Leave, cb_gudang.Leave
    '    If Trim(in_no_faktur.Text) <> Nothing Then
    '        'loadDataFaktur(in_no_faktur.Text)
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
                    .query = "SELECT barang_nama as nama, barang_kode as kode, trans_qty as qty FROM data_pembelian_trans INNER JOIN data_barang_master ON barang_kode=trans_barang WHERE trans_faktur='" & in_no_faktur.Text & "'"
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
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(in_qty, e)
            If Trim(in_barang.Text) <> Nothing Then
                setBarang(Trim(in_barang.Text))
            End If
        ElseIf e.KeyCode = Keys.Down And popPnl_barang.Visible = True Then
            dgv_listbarang.Focus()
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
                .query = "SELECT barang_nama as nama, barang_kode as kode, trans_qty as qty FROM data_pembelian_trans INNER JOIN data_barang_master ON barang_kode=trans_barang WHERE trans_faktur='" & in_no_faktur.Text & "'"
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

    'other
    Private Sub cb_bayar_jenis_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_bayar_jenis.KeyDown
        keyshortenter(in_no_faktur, e)
    End Sub

    Private Sub cb_bayar_jenis_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_bayar_jenis.SelectionChangeCommitted
        in_no_faktur.Focus()
    End Sub

    Private Sub cb_bayar_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_bayar_jenis.KeyPress
        e.Handled = True
    End Sub

    Private Sub in_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pajak.KeyDown
        keyshortenter(date_tgl_pajak, e)
    End Sub

    Private Sub date_tgl_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_pajak.KeyDown
        keyshortenter(in_barang, e)
    End Sub

    'menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanreturbeli.PerformClick()
    End Sub
End Class