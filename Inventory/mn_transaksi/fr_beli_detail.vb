﻿Public Class fr_beli_detail
    Private indexrow As Integer = 0
    Private indexrowlist As Integer = 0
    Private pajak As String
    Private gdstatus As String = 1
    Private statusbarang As String = 0
    Private statusbayar As String = 0

    Private Sub loadDataFaktur(kode As String)
        readcommd("SELECT * FROM data_pembelian_faktur WHERE faktur_kode='" & kode & "'")
        If rd.HasRows Then
            in_faktur.Text = kode
            in_suratjalan.Text = rd.Item("faktur_surat_jalan")
            in_pajak.Text = rd.Item("faktur_pajak_no")
            date_tgl_beli.Value = rd.Item("faktur_tanggal_trans")
            date_tgl_pajak.Value = rd.Item("faktur_pajak_tanggal")
            cb_gudang.SelectedValue = rd.Item("faktur_gudang")
            cb_supplier.SelectedValue = rd.Item("faktur_supplier")
            in_term.Value = rd.Item("faktur_term")
            in_jumlah.Text = commaThousand(rd.Item("faktur_jumlah"))
            in_diskon.Text = commaThousand(rd.Item("faktur_disc"))
            in_total.Text = commaThousand(rd.Item("faktur_total"))
            cb_ppn.SelectedValue = rd.Item("faktur_ppn_jenis")
            in_netto.Text = commaThousand(rd.Item("faktur_netto"))
            in_ppn_tot.Text = commaThousand(rd.Item("faktur_ppn"))
            in_klaim.Value = CDbl(rd.Item("faktur_klaim"))
            in_total_netto.Text = commaThousand(rd.Item("faktur_total_netto"))
            in_status_kode.Text = rd.Item("faktur_status")
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
    End Sub

    Private Sub loadDataBarang(kode As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_beli, trans_qty, trans_satuan, trans_disc1,trans_disc2,trans_disc3,trans_disc_rupiah, trans_jumlah, trans_ppn,trans_satuan_type FROM data_pembelian_trans INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & kode & "'")
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

    Private Sub setBarang(nama As String, Optional kode As String = Nothing)
        op_con()
        If kode = Nothing Then
            readcommd("SELECT barang_kode FROM data_barang_master WHERE barang_nama LIKE '" & nama & "%' AND barang_supplier='" & cb_supplier.SelectedValue & "' LIMIT 1")
            If rd.HasRows Then
                kode = rd.Item(0)
                rd.Close()
            Else
                rd.Close()
                Exit Sub
            End If
        End If

        readcommd("SELECT barang_kode, barang_nama, barang_harga_beli, barang_harga_beli_d1, barang_harga_beli_d2, barang_harga_beli_d3 FROM data_barang_master WHERE barang_kode='" & kode & "' AND barang_supplier='" & cb_supplier.SelectedValue & "'")
        If rd.HasRows Then
            in_barang.Text = rd.Item("barang_kode")
            in_barang_nm.Text = rd.Item("barang_nama")
            in_harga_beli.Text = rd.Item("barang_harga_beli")
            in_disc1.Value = rd.Item("barang_harga_beli_d1")
            in_disc2.Value = rd.Item("barang_harga_beli_d2")
            in_disc2.Value = rd.Item("barang_harga_beli_d3")
            'pajak = rd.Item("barang_status_pajak")
        End If
        rd.Close()

        If in_barang.Text <> Nothing Then
            loadSatuanBrg(in_barang.Text)
            'cb_sat.SelectedIndex = 2
        End If
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
        setDoubleBuffered(Me.dgv_listbarang, True)
        With dgv_listbarang
            .DataSource = getDataTablefromDB("SELECT barang_kode, barang_nama, barang_harga_beli FROM data_barang_master WHERE barang_nama LIKE'" & in_barang_nm.Text & "%' AND barang_supplier='" & cb_supplier.SelectedValue & "' LIMIT 100")
        End With
    End Sub

    Private Sub setStatus()

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
            total -= in_discrp.Value
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

        countbiaya()
        'in_barang.Focus()
        in_qty.Focus()
    End Sub

    Private Sub countbiaya()
        Dim pajak As Double = 0
        Dim x As Double = jumlahbiaya()
        Dim y As Double = x
        Dim netto As Double = 0
        Dim diskon As Double = 0

        For Each row As DataGridViewRow In dgv_barang.Rows
            diskon += row.Cells("subtot").Value - row.Cells("jml").Value
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
    Private Sub bt_batalbeli_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        If MessageBox.Show("Tutup Form?", "Puchase Order", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
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

    'numeric input
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_klaim.Enter, in_discrp.Enter, in_disc3.Enter, in_disc2.Enter, in_disc1.Enter, in_term.Enter, in_harga_beli.Enter
        Console.WriteLine(sender.Name & sender.Value)
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_klaim.Leave, in_discrp.Leave, in_disc3.Leave, in_disc2.Leave, in_disc1.Leave, in_term.Leave, in_harga_beli.Leave
        numericLostFocus(sender)
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
            setBarang(in_barang_nm.Text, in_barang.Text)
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
            in_barang.Text = dgv_listbarang.Rows(indexrowlist).Cells(0).Value
            setBarang(in_barang_nm.Text, in_barang.Text)
            in_qty.Focus()
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
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
                    .query = "SELECT barang_nama as nama, barang_kode as kode, barang_harga_beli as hargabeli, barang_harga_jual as hargajual FROM data_barang_master WHERE barang_supplier='" & cb_supplier.SelectedValue & "'"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "barang"
                    .ShowDialog()
                    in_barang.Text = .returnkode
                    in_barang.Focus()
                End With
            End Using
            in_qty.Focus()
            Exit Sub
        ElseIf e.KeyCode = Keys.F2 Then
            'setBarang(Trim(in_barang.Text))
            If in_barang_nm.Text = Nothing Then
                Using addbarang As New fr_barang_detail
                    With addbarang
                        .in_supplier.Focus()
                        .in_supplier.Text = cb_supplier.SelectedValue
                        If Trim(in_barang.Text) <> Nothing Then
                            .in_kode.Text = in_barang.Text
                        End If
                        .in_nama.Focus()
                        .ShowDialog()
                        in_barang.Text = .in_kode.Text
                        in_barang.Focus()
                    End With
                End Using
                in_qty.Focus()
                Exit Sub
            Else
                Exit Sub
            End If
        ElseIf e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                indexrowlist = 0
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True Then
                indexrowlist = 0
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
                .query = "SELECT barang_nama as nama, barang_kode as kode, barang_harga_beli as hargabeli, barang_harga_jual as hargajual FROM data_barang_master WHERE barang_supplier='" & cb_supplier.SelectedValue & "'"
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

    '-------------------------------- load
    Private Sub fr_beli_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'unfinished

        '------------------------

        With cb_ppn
            .DataSource = jenisPPN()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With
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

        With date_tgl_beli
            .Value = DateSerial(selectedperiode.Year, selectedperiode.Month, date_tgl_beli.Value.Day)
            .MaxDate = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)
            .MinDate = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
        End With
        date_tgl_pajak.Value = selectedperiode

        For Each x As DataGridViewColumn In {harga, discrp, jml, subtot}
            x.DefaultCellStyle = dgvstyle_currency
        Next

        If bt_simpanbeli.Text = "Update" Then
            loadDataBarang(in_faktur.Text)
            loadDataFaktur(in_faktur.Text)

        End If

        in_faktur.Focus()
        'setStatus(statusbarang, statusbayar)
    End Sub

    '-------------------------------- save
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        If IsNothing(cb_supplier.SelectedValue) = True Then
            MessageBox.Show("Supplier belum di input")
            cb_supplier.Focus()
            Exit Sub
        End If
        If IsNothing(cb_gudang.SelectedValue) = True Then
            MessageBox.Show("Gudang belum di input")
            cb_gudang.Focus()
            Exit Sub
        End If
        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum di input")
            in_barang.Focus()
            Exit Sub
        End If

        op_con()

        If MessageBox.Show("Simpan data transaksi pembelian?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            'GENERATE KODE
            If in_faktur.Text = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT COUNT(faktur_kode) FROM data_pembelian_faktur WHERE SUBSTRING(faktur_kode,3,8)='" & date_tgl_beli.Value.ToString("yyyyMMdd") & "' AND faktur_kode LIKE 'PO%'")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()
                in_faktur.Text = "PO" & date_tgl_beli.Value.ToString("yyyyMMdd") & no.ToString("D4")
            ElseIf in_faktur.Text <> Nothing And bt_simpanbeli.Text <> "Update" Then
                If checkdata("data_pembelian_faktur", "'" & in_faktur.Text & "'", "faktur_kode") = True Then
                    If MessageBox.Show("Update data faktur " & in_faktur.Text & "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                End If
            End If

            Dim dataBrg, dataFak As String()
            Dim data1, data2 As String()
            Dim queryArr As New List(Of String)
            Dim querycheck As Boolean = False
            Dim q1 As String = "INSERT INTO data_pembelian_faktur SET faktur_kode='{0}',{1},{2} ON DUPLICATE KEY UPDATE {1},{3}"
            Dim q2 As String = "INSERT INTO data_pembelian_trans SET trans_faktur= '{0}',{1} ON DUPLICATE KEY UPDATE {1}"
            Dim q3 As String = "DELETE FROM data_pembelian_trans WHERE trans_faktur='{0}' AND trans_barang NOT IN({1})"


            dataFak = {
                    "faktur_tanggal_trans='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_pajak_no='" & in_pajak.Text & "'",
                    "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_surat_jalan='" & in_suratjalan.Text & "'",
                    "faktur_gudang='" & cb_gudang.SelectedValue & "'",
                    "faktur_supplier='" & cb_supplier.SelectedValue & "'",
                    "faktur_term='" & in_term.Value & "'",
                    "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text) & "'",
                    "faktur_disc='" & removeCommaThousand(in_diskon.Text).ToString.Replace(",", ".") & "'",
                    "faktur_total='" & removeCommaThousand(in_total.Text).ToString.Replace(",", ".") & "'",
                    "faktur_ppn='" & removeCommaThousand(in_ppn_tot.Text).ToString.Replace(",", ".") & "'",
                    "faktur_ppn_jenis='" & cb_ppn.SelectedValue & "'",
                    "faktur_netto='" & removeCommaThousand(in_netto.Text).ToString.Replace(",", ".") & "'",
                    "faktur_klaim='" & in_klaim.Value & "'",
                    "faktur_total_netto='" & removeCommaThousand(in_total_netto.Text).ToString.Replace(",", ".") & "'",
                    "faktur_status='" & gdstatus & "'"
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
            queryArr.Add(String.Format(q1, in_faktur.Text, String.Join(",", dataFak), String.Join(",", data1), String.Join(",", data2)))

            'INSERT BARANG
            Dim x As New List(Of String)
            Dim x_kodestock As New List(Of String)
            Dim qty As New List(Of Integer)
            Dim nilai As New List(Of Double)
            For Each rows As DataGridViewRow In dgv_barang.Rows

                'INSERT DATA BARANG
                dataBrg = {
                    "trans_barang='" & rows.Cells(0).Value & "'",
                    "trans_harga_beli='" & rows.Cells("harga").Value & "'",
                    "trans_qty='" & rows.Cells("qty").Value & "'",
                    "trans_satuan='" & rows.Cells("sat").Value & "'",
                    "trans_satuan_type='" & rows.Cells("sat_type").Value & "'",
                    "trans_disc1='" & rows.Cells("disc1").Value & "'",
                    "trans_disc2='" & rows.Cells("disc2").Value & "'",
                    "trans_disc3='" & rows.Cells("disc3").Value & "'",
                    "trans_disc_rupiah='" & rows.Cells("discrp").Value & "'",
                    "trans_jumlah='" & rows.Cells("jml").Value & "'"
                    }
                queryArr.Add(String.Format(q2, in_faktur.Text, String.Join(",", dataBrg)))

                'CHECK / INSERT DATA STOCK FOR GUDANG TUJUAN -> STOCK AWAL
                Dim stockkode As String = cb_gudang.SelectedValue & "-" & rows.Cells(0).Value & "-" & date_tgl_beli.Value.ToString("yyMM")

                dataBrg = {
                    "stock_kode='" & stockkode & "'",
                    "stock_gudang='" & cb_gudang.SelectedValue & "'",
                    "stock_barang='" & rows.Cells(0).Value & "'",
                    "stock_awal=0",
                    "stock_periode='" & date_tgl_beli.Value.ToString("yyyy-MM") & "'",
                    "stock_reg_alias='" & loggeduser.user_id & "'",
                    "stock_reg_date=NOW()"
                    }
                queryArr.Add("INSERT INTO data_stok_awal SET " & String.Join(",", dataBrg) & " ON DUPLICATE KEY UPDATE stock_kode=stock_kode")

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
                nilai.Add(rows.Cells("jml").Value)
            Next
            queryArr.Add(String.Format(q3, in_faktur.Text, String.Join(",", x)))

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
                        "'po'",
                        "'" & in_faktur.Text & "'",
                        "'PEMBELIAN'",
                        qty.Item(i),
                        nilai.Item(i).ToString.Replace(",", "."),
                        "'" & loggeduser.user_id & "'",
                        "NOW()"
                        }
                dataBrg = {
                    "trans_qty=" & qty.Item(i),
                    "trans_nilai=" & nilai.Item(i).ToString.Replace(",", "."),
                    "trans_upd_date=NOW()",
                    "trans_upd_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add(String.Format(q4, String.Join(",", data1), String.Join(",", data2), stock, String.Join(",", dataBrg)))
                i += 1
            Next
            'DONE : TODO : DELETE REMOVED ITEM FROM KARTU STOK
            queryArr.Add(String.Format(q5, in_faktur.Text, String.Join(",", x_kodestock)))

            'TODO : WRITE HUTANG AWAL
            Dim q6 As String = "INSERT INTO data_hutang_awal SET hutang_faktur='{0}',{1},{2} ON DUPLICATE KEY UPDATE {1},{3}"
            dataBrg = {
                "hutang_awal=" & removeCommaThousand(in_netto.Text),
                "hutang_hutang=0"
                }
            data1 = {
                "hutang_reg_date=NOW()",
                "hutang_reg_alias='" & loggeduser.user_id & "'"
                }
            data2 = {
                "hutang_upd_date=NOW()",
                "hutang_upd_alias='" & loggeduser.user_id & "'"
                }
            queryArr.Add(String.Format(q6, in_faktur.Text, String.Join(",", dataBrg), String.Join(",", data1), String.Join(",", data2)))

            '--------------------------------------------------------------------------------------------------------------
            'BEGIN TRANSACT
            querycheck = startTrans(queryArr)

            If querycheck = False Then
                MessageBox.Show("Data tidak dapat tersimpan")
                Exit Sub
            Else
                'TODO : ? : WRITE GENERAL LEDGER

                MessageBox.Show("Data tersimpan")
                frmpembelian.in_cari.Clear()
                populateDGVUserCon("beli", "", frmpembelian.dgv_list)
                Me.Close()
            End If
        End If
    End Sub

    'Private Sub create_ledger()
    '    Dim q1 As String = "INSERT INTO data_jurnal (jurnal_kode, jurnal_jenis, jurnal_tanggal, jurnal_perkiraan, jurnal_uraian, jurnal_debet, jurnal_kredit, jurnal_reg_alias, jurnal_reg_date) VALUES{0}"
    '    Dim queryarr As New List(Of String)
    '    Dim data1 As String()

    '    data1 = {
    '        "'BELI_" & in_faktur.Text
    '        }
    '    queryarr.Add(String.Format(q1, ))
    'End Sub

    '-------------------- input
    Private Sub cb_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_supplier.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_supplier_list.PerformClick()
        End If
        keyshortenter(cb_gudang, e)
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

    Private Sub cb_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_gudang.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_gudang_list.PerformClick()
        End If
        keyshortenter(in_suratjalan, e)
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
        in_suratjalan.Focus()
    End Sub

    Private Sub in_suratjalan_KeyDown(sender As Object, e As KeyEventArgs) Handles in_suratjalan.KeyDown
        keyshortenter(in_term, e)
    End Sub

    Private Sub in_term_KeyDown(sender As Object, e As KeyEventArgs) Handles in_term.KeyDown
        If e.KeyCode = Keys.Enter Then
            keyshortenter(cb_ppn, e)
            cb_ppn.DroppedDown = True
        End If
    End Sub

    Private Sub cb_ppn_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_ppn.KeyDown
        keyshortenter(in_pajak, e)
    End Sub

    Private Sub cb_ppn_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_ppn.SelectionChangeCommitted
        countbiaya()
    End Sub

    Private Sub cb_ppn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_ppn.KeyPress, cb_sat.KeyPress
        e.Handled = True
    End Sub

    Private Sub in_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pajak.KeyDown
        keyshortenter(date_tgl_pajak, e)
    End Sub

    Private Sub date_tgl_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_pajak.KeyDown
        keyshortenter(in_barang_nm, e)
    End Sub

    '---------------- faktur
    Private Sub in_faktur_KeyDown(sender As Object, e As KeyEventArgs) Handles in_faktur.KeyDown
        keyshortenter(date_tgl_beli, e)
    End Sub

    Private Sub date_tgl_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyDown
        keyshortenter(cb_supplier, e)
    End Sub

    '------------------------ input barang
    Private Sub in_qty_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
        keyshortenter(cb_sat, e)
    End Sub

    Private Sub cb_sat_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat.KeyDown
        keyshortenter(in_harga_beli, e)
    End Sub

    Private Sub in_harga_beli_ValueChanged(sender As Object, e As EventArgs) Handles in_qty.ValueChanged, in_harga_beli.ValueChanged
        in_subtotal.Text = commaThousand(in_qty.Value * in_harga_beli.Value)
    End Sub

    Private Sub in_harga_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_beli.KeyDown
        keyshortenter(in_disc1, e)
    End Sub

    Private Sub in_disc1_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc1.KeyDown
        keyshortenter(in_disc2, e)
    End Sub

    Private Sub in_disc2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc2.KeyDown
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

    '------------ dgv barang
    Private Sub dgv_barang_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv_barang.RowsRemoved
        countbiaya()
    End Sub

    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        If e.RowIndex < 0 Then
            indexrow = 0
        Else
            indexrow = e.RowIndex
            dgvTotxt()
            dgv_barang.Rows.RemoveAt(indexrow)
        End If
    End Sub

    'menu bar
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanbeli.PerformClick()
    End Sub

    Private Sub mn_cancelorder_Click(sender As Object, e As EventArgs) Handles mn_cancelorder.Click
        'set status pembelian to canceled
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
End Class