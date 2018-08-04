Public Class fr_jual_detail
    'note
    'penjualana bisa untuk input & validasi -> hutang custo
    'alur so -> sales>validasi>admin>gudang

    Private rowindex As Integer = 0
    Private rowindexlist As Integer = 0
    Private jeniscusto As String

    Private Sub loadDataFaktur(faktur As String)
        op_con()
        readcommd("SELECT * FROM data_penjualan_faktur WHERE faktur_kode='" & faktur & "'")
        If rd.HasRows Then
            in_faktur.Text = faktur
            cb_ppn.SelectedValue = rd.Item("faktur_ppn_jenis")
            in_pajak.Text = rd.Item("faktur_pajak_no")
            date_tgl_beli.Value = rd.Item("faktur_tanggal_trans")
            date_tgl_pajak.Value = rd.Item("faktur_pajak_tanggal")
            cb_gudang.SelectedValue = rd.Item("faktur_gudang")
            cb_sales.SelectedValue = rd.Item("faktur_sales")
            cb_custo.SelectedValue = rd.Item("faktur_customer")
            in_term.Value = rd.Item("faktur_term")
            in_ket.Text = rd.Item("faktur_catatan")
            'cb_jenis_jual.SelectedValue = rd.Item("")
            in_jumlah.Text = commaThousand(rd.Item("faktur_jumlah"))
            in_diskon.Text = commaThousand(rd.Item("faktur_disc_rupiah"))
            in_total.Text = commaThousand(rd.Item("faktur_total"))
            in_ppn_tot.Text = commaThousand(rd.Item("faktur_ppn_persen"))
            in_netto.Text = commaThousand(rd.Item("faktur_netto"))
            in_klaim.Value = CDbl(rd.Item("faktur_klaim"))
            in_total_netto.Text = commaThousand(rd.Item("faktur_total_netto"))
            in_status_kode.Text = rd.Item("faktur_status")
            txtRegAlias.Text = rd.Item("faktur_reg_alias")
            txtRegdate.Text = rd.Item("faktur_reg_date")
            Try
                txtUpdDate.Text = rd.Item("faktur_upd_date")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("faktur_upd_alias")
        End If
        rd.Close()
    End Sub

    Private Sub loadDataBarang(faktur As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_jual, trans_qty, trans_satuan, trans_disc1, trans_disc2, trans_disc3, trans_disc4, trans_disc5, trans_disc_rupiah, trans_jumlah FROM data_penjualan_trans INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & faktur & "'")
        With dgv_barang.Rows
            For Each rows As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("kode").Value = rows.ItemArray(0)
                    .Cells("nama").Value = rows.ItemArray(1)
                    .Cells("harga").Value = rows.ItemArray(2)
                    .Cells("qty").Value = rows.ItemArray(3)
                    .Cells("sat").Value = rows.ItemArray(4)
                    .Cells("subtot").Value = rows.ItemArray(2) * rows.ItemArray(3)
                    .Cells("disc1").Value = rows.ItemArray(5)
                    .Cells("disc2").Value = rows.ItemArray(6)
                    .Cells("disc3").Value = rows.ItemArray(7)
                    .Cells("disc4").Value = rows.ItemArray(8)
                    .Cells("disc5").Value = rows.ItemArray(9)
                    .Cells("discrp").Value = rows.ItemArray(10)
                    .Cells("jml").Value = rows.ItemArray(11)
                End With
            Next
        End With
        dt.Dispose()
    End Sub

    Private Sub setBarang(kode As String)
        Dim qtymax As Integer = 0
        Dim isi As Integer = 1
        op_con()
        readcommd("SELECT barang_nama, barang_satuan_besar, barang_harga_jual, barang_harga_jual_mt, barang_harga_jual_horeka, barang_harga_jual_rita, barang_harga_jual_d1, barang_harga_jual_d2, barang_harga_jual_d3, barang_harga_jual_d4, barang_harga_jual_d5 FROM data_barang_master WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            Dim harga As Double = 0
            Select Case jeniscusto
                Case "1"
                    harga = rd.Item("barang_harga_jual")
                Case "2"
                    harga = rd.Item("barang_harga_jual_mt")
                Case "3"
                    harga = rd.Item("barang_harga_jual_horeka")
                Case "4"
                    harga = rd.Item("barang_harga_jual_rita")
                Case Else
                    harga = rd.Item("barang_harga_jual")
            End Select
            in_barang_nm.Text = rd.Item("barang_nama")
            in_harga_beli.Text = harga
            in_disc1.Value = rd.Item("barang_harga_jual_d1")
            in_disc2.Value = rd.Item("barang_harga_jual_d2")
            in_disc3.Value = rd.Item("barang_harga_jual_d3")
            in_disc4.Value = rd.Item("barang_harga_jual_d4")
            in_disc5.Value = rd.Item("barang_harga_jual_d5")
        End If
        rd.Close()

        If in_barang_nm.Text <> Nothing Then
            loadSatuanBrg(in_barang.Text)
            cb_sat.SelectedIndex = 2
        End If
    End Sub

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
            .DataSource = getDataTablefromDB("SELECT barang_kode, barang_nama, barang_harga_beli FROM data_barang_master WHERE barang_kode LIKE'%" & in_barang.Text & "%' LIMIT 100")
        End With
    End Sub

    Private Sub setStatus()

    End Sub

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

        Dim pajak_tot As Double = 0
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
            total -= in_discrp.Value
        End If

        With dgv_barang.Rows
            Dim x As Integer = .Add
            With .Item(x)
                .Cells("kode").Value = in_barang.Text
                .Cells("nama").Value = in_barang_nm.Text
                .Cells("qty").Value = in_qty.Value
                .Cells("sat").Value = cb_sat.Text
                .Cells("harga").Value = in_harga_beli.Value
                .Cells("subtot").Value = removeCommaThousand(in_subtotal.Text)
                .Cells("disc1").Value = in_disc1.Value
                .Cells("disc2").Value = in_disc2.Value
                .Cells("disc3").Value = in_disc3.Value
                .Cells("disc4").Value = in_disc4.Value
                .Cells("disc5").Value = in_disc5.Value
                .Cells("discrp").Value = in_discrp.Value
                .Cells("jml").Value = total
            End With
        End With

        countBiaya()
        clearInputBarang()
        in_barang.Clear()
        in_barang.Focus()
    End Sub

    Private Sub dgvToTxt()
        With dgv_barang.Rows(rowindex)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty.Value = .Cells("qty").Value
            cb_sat.SelectedText = .Cells("sat").Value
            in_harga_beli.Text = .Cells("harga").Value
            in_subtotal.Text = .Cells("subtot").Value
            in_disc1.Value = .Cells("disc1").Value
            in_disc2.Value = .Cells("disc2").Value
            in_disc3.Value = .Cells("disc3").Value
            in_disc4.Value = .Cells("disc4").Value
            in_disc5.Value = .Cells("disc5").Value
            in_discrp.Value = .Cells("discrp").Value
        End With
    End Sub

    Private Sub countBiaya()
        Dim pajak As Double = 0
        Dim subtotal As Double = 0
        Dim y As Double = 0
        Dim netto As Double = y
        Dim diskon As Double = 0

        For Each rows As DataGridViewRow In dgv_barang.Rows
            Console.WriteLine(rows.Cells("subtot").Value)
            subtotal += rows.Cells("subtot").Value
        Next

        For Each row As DataGridViewRow In dgv_barang.Rows
            diskon += row.Cells("subtot").Value - row.Cells("jml").Value
        Next

        y = subtotal - diskon

        If cb_ppn.SelectedValue = 0 Then
            pajak = subtotal * 0.1
            netto += pajak
        Else
            netto = y
        End If

        Dim aa As Double = netto - CDbl(in_klaim.Value)
        Dim cc As Globalization.CultureInfo = Globalization.CultureInfo.GetCultureInfo("id-ID")
        in_jumlah.Text = subtotal.ToString("N2", cc)
        in_diskon.Text = commaThousand(diskon)
        in_ppn_tot.Text = commaThousand(pajak)
        in_total.Text = y.ToString("N2", cc)
        in_netto.Text = netto.ToString("N2", cc)
        in_klaim.Maximum = netto
        in_total_netto.Text = aa.ToString("N2", cc)

        Console.WriteLine("ss" & aa)
        Console.WriteLine(removeCommaThousand(in_total_netto.Text))
    End Sub

    Private Sub clearTextBarang()
        in_harga_beli.Value = 0
        For Each x As TextBox In {in_barang_nm, in_subtotal}
            x.Clear()
        Next
    End Sub

    Private Sub clearInputBarang()
        clearTextBarang()
        in_barang.Clear()
        For Each x As NumericUpDown In {in_qty, in_disc1, in_disc2, in_disc3, in_disc4, in_disc5, in_discrp}
            x.Value = 0
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
    Private Sub bt_batalbeli_Click(sender As Object, e As EventArgs) Handles bt_bataljual.Click
        If MessageBox.Show("Tutup Form?", "Puchase Order", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
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

    'numeric input
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_klaim.Enter, in_discrp.Enter, in_disc3.Enter, in_disc2.Enter, in_disc1.Enter, in_disc4.Enter, in_disc5.Enter, in_harga_beli.Enter
        Console.WriteLine(sender.Name & sender.Value)
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_klaim.Leave, in_discrp.Leave, in_disc3.Leave, in_disc2.Leave, in_disc1.Leave, in_disc4.Leave, in_disc5.Leave, in_harga_beli.Leave
        numericLostFocus(sender)
    End Sub

    '---------------- cb prevent input
    Private Sub cb_sat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_sat.KeyPress, cb_ppn.KeyPress
        e.Handled = True
    End Sub

    '---------------pop up list barang & input barang
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
        If e.RowIndex >= 0 Then
            rowindexlist = e.RowIndex
            in_barang.Text = dgv_listbarang.Rows(rowindexlist).Cells("brg_kode").Value
            setBarang(in_barang.Text)
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
            setBarang(in_barang.Text)
            in_qty.Focus()
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.keyChar) Then
            in_barang.Text += e.KeyChar
            e.Handled = True
            in_barang.Focus()
        End If
    End Sub

    Private Sub in_barang_TextChanged(sender As Object, e As EventArgs) Handles in_barang.TextChanged
        If in_barang.Text = "" Then
            clearTextBarang()
        End If
        If popPnl_barang.Visible = True Then
            loadDataBRGPopup()
        End If
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        clearTextBarang()
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    If Trim(in_barang.Text) <> Nothing Then
                        .in_cari.Text = in_barang.Text
                    End If
                    .returnkode = in_barang.Text
                    .query = "SELECT barang_nama as nama, barang_kode as kode, barang_harga_beli as hargabeli, barang_harga_jual as hargajual FROM data_barang_master"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "barang"
                    .ShowDialog()
                    in_barang.Text = .returnkode
                    in_barang.Focus()
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
                If Trim(in_barang.Text) <> Nothing Then
                    .in_cari.Text = in_barang.Text
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
            setBarang(Trim(in_barang.Text))
        End If
        in_qty.Focus()
        Exit Sub
    End Sub

    '---------------- load
    Private Sub fr_jual_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_gudang
            .DataSource = getDataTablefromDB("SELECT gudang_kode, gudang_nama FROM data_barang_gudang")
            .DisplayMember = "gudang_nama"
            .ValueMember = "gudang_kode"
            .SelectedIndex = -1
        End With
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
        With cb_ppn
            .DataSource = jenisPPN()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        With dgv_barang
            For Each x As DataGridViewColumn In {harga, discrp, jml, subtot}
                x.DefaultCellStyle = dgvstyle_currency
            Next
        End With

        If bt_simpanjual.Text = "Update" Then
            loadDataBarang(in_faktur.Text)
            loadDataFaktur(in_faktur.Text)

        End If
    End Sub

    '------------ save
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanjual.Click
        If cb_sales.SelectedValue = Nothing Then
            MessageBox.Show("Sales belum di input")
            cb_sales.Focus()
            Exit Sub
        End If
        If cb_custo.SelectedValue = Nothing Then
            MessageBox.Show("Customer belum di input")
            cb_custo.Focus()
            Exit Sub
        End If
        If cb_gudang.SelectedValue = Nothing Then
            MessageBox.Show("Gudang belum di input")
            cb_gudang.Focus()
            Exit Sub
        End If
        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum di input")
            in_barang.Focus()
            Exit Sub
        End If

        Dim dataBrg As String()
        Dim dataFak As String()
        Dim querycheck As Boolean = False
        Dim queryArr As New List(Of String)

        op_con()
        If MessageBox.Show("Simpan data transaksi pembelian?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
            If bt_simpanjual.Text = "Simpan" Then
                'IF NEW DATA
                in_faktur.Text = Trim(in_faktur.Text)
                'GENERATE KODE
                If in_faktur.Text = Nothing Then
                    readcommd("SELECT COUNT(faktur_tanggal_trans) FROM data_penjualan_faktur WHERE SUBSTRING(faktur_kode,3,8)='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'")
                    Dim x As Integer = rd.Item(0)
                    x += 1
                    rd.Close()
                    Dim fakturkode As String = "SO" & date_tgl_beli.Value.ToString("yyyyMMdd") & x.ToString("D4")
                    in_faktur.Text = fakturkode
                Else
                    If checkdata("data_penjualan_faktur", "'" & in_faktur.Text & "'", "faktur_kode") = True Then
                        MessageBox.Show("No. Faktur sudah pernah diinputkan")
                        in_faktur.Focus()
                    End If
                End If

                'INSERT DATA FAKTUR
                dataFak = {
                    "faktur_kode='" & in_faktur.Text & "'",
                    "faktur_tanggal_trans='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_pajak_no='" & in_pajak.Text & "'",
                    "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_gudang='" & cb_gudang.SelectedValue & "'",
                    "faktur_sales='" & cb_sales.SelectedValue & "'",
                    "faktur_customer='" & cb_custo.SelectedValue & "'",
                    "faktur_term='" & in_term.Value & "'",
                    "faktur_catatan='" & in_ket.Text & "'",
                    "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text) & "'",
                    "faktur_disc_rupiah='" & removeCommaThousand(in_diskon.Text) & "'",
                    "faktur_total='" & removeCommaThousand(in_total.Text) & "'",
                    "faktur_ppn_persen='" & removeCommaThousand(in_ppn_tot.Text) & "'",
                    "faktur_ppn_jenis='" & cb_ppn.SelectedValue & "'",
                    "faktur_netto='" & removeCommaThousand(in_netto.Text) & "'",
                    "faktur_klaim='" & in_klaim.Value & "'",
                    "faktur_total_netto='" & removeCommaThousand(in_total_netto.Text) & "'",
                    "faktur_status=1",
                    "faktur_reg_date=NOW()",
                    "faktur_reg_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add("INSERT INTO data_penjualan_faktur SET " & String.Join(",", dataFak))

                'TODO : INSERT DATA PIUTANG AWAL

            ElseIf bt_simpanjual.Text = "Update" Then
                'IF UPDATE
                'UPDATE DATA FAKTUR
                dataFak = {
                    "faktur_tanggal_trans='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_pajak_no='" & in_pajak.Text & "'",
                    "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_gudang='" & cb_gudang.SelectedValue & "'",
                    "faktur_sales='" & cb_sales.SelectedValue & "'",
                    "faktur_customer='" & cb_custo.SelectedValue & "'",
                    "faktur_term='" & in_term.Value & "'",
                    "faktur_catatan='" & in_ket.Text & "'",
                    "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text) & "'",
                    "faktur_disc_rupiah='" & removeCommaThousand(in_diskon.Text) & "'",
                    "faktur_total='" & removeCommaThousand(in_total.Text) & "'",
                    "faktur_ppn_persen='" & removeCommaThousand(in_ppn_tot.Text) & "'",
                    "faktur_ppn_jenis='" & cb_ppn.SelectedValue & "'",
                    "faktur_netto='" & removeCommaThousand(in_netto.Text) & "'",
                    "faktur_klaim='" & in_klaim.Value & "'",
                    "faktur_total_netto='" & removeCommaThousand(in_total_netto.Text) & "'",
                    "faktur_status='" & in_status_kode.Text & "'",
                    "faktur_upd_date=NOW()",
                    "faktur_upd_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add("UPDATE data_penjualan_faktur SET " & String.Join(",", dataFak) & " WHERE faktur_kode='" & in_faktur.Text & "'")

                'DELETE DATA BARANG
                queryArr.Add("DELETE FROM data_penjualan_trans WHERE trans_faktur='" & in_faktur.Text & "'")

                'TODO : UPDATE DATA HUTANG
            End If

            'INSERT / REINSERT DATA BARANG
            For Each rows As DataGridViewRow In dgv_barang.Rows
                dataBrg = {
                    "trans_faktur='" & in_faktur.Text & "'",
                    "trans_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                    "trans_barang='" & rows.Cells(0).Value & "'",
                    "trans_harga_jual='" & rows.Cells("harga").Value & "'",
                    "trans_qty='" & rows.Cells("qty").Value & "'",
                    "trans_satuan='" & rows.Cells("sat").Value & "'",
                    "trans_disc1='" & rows.Cells("disc1").Value & "'",
                    "trans_disc2='" & rows.Cells("disc2").Value & "'",
                    "trans_disc3='" & rows.Cells("disc3").Value & "'",
                    "trans_disc4='" & rows.Cells("disc4").Value & "'",
                    "trans_disc5='" & rows.Cells("disc5").Value & "'",
                    "trans_disc_rupiah='" & rows.Cells("discrp").Value & "'",
                    "trans_jumlah='" & rows.Cells("jml").Value & "'",
                    "trans_reg_date=NOW()",
                    "trans_reg_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add("INSERT INTO data_penjualan_trans SET " & String.Join(",", dataBrg))

                'TODO update stock >in trans or when printing draft? <- does thi still needed?

                Dim stockkode As String = cb_gudang.SelectedValue & "-" & rows.Cells(0).Value & "-" & date_tgl_beli.Value.ToString("yyMM")

                'TODO:
                'GET INDEX KARTU STOK
                'DELETE THE DATA
                'INSERT INTO KARTU STOK WITH OBTAINED INDEX

                'TODO : WRITE LOG
            Next

            'BEGIN TRANSACTION
            querycheck = startTrans(queryArr)

            If querycheck = False Then
                MessageBox.Show("Data tidak dapat tersimpan")
                Exit Sub
            Else
                MessageBox.Show("Data tersimpan")
                frmpembelian.in_cari.Clear()
                populateDGVUserCon("jual", "", frmpenjualan.dgv_list)
                Me.Close()
            End If
        End If
    End Sub

    'input
    Private Sub in_faktur_KeyDown(sender As Object, e As KeyEventArgs) Handles in_faktur.KeyDown
        keyshortenter(date_tgl_beli, e)
    End Sub

    Private Sub date_tgl_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyDown
        keyshortenter(cb_gudang, e)
    End Sub

    Private Sub cb_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_gudang.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_gudang_list.PerformClick()
        End If
        keyshortenter(cb_custo, e)
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
        cb_custo.Focus()
    End Sub

    Private Sub cb_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_custo.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_custo_list.PerformClick()
        End If
        keyshortenter(in_term, e)
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
                .query = "SELECT customer_kode as kode, customer_nama as nama FROM data_customer_master"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "custo"
                .ShowDialog()
                cb_custo.SelectedValue = .returnkode
            End With
        End Using
        in_term.Focus()
    End Sub

    Private Sub in_term_KeyDown(sender As Object, e As KeyEventArgs) Handles in_term.KeyDown
        keyshortenter(cb_sales, e)
    End Sub

    Private Sub cb_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sales.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_sales_list.PerformClick()
        End If
        keyshortenter(cb_ppn, e)
    End Sub

    Private Sub bt_sales_list_Click(sender As Object, e As EventArgs) Handles bt_sales_list.Click
        Using search As New fr_search_dialog
            With search
                If cb_sales.Text <> Nothing Then
                    .in_cari.Text = cb_sales.Text
                End If
                If cb_sales.SelectedValue <> Nothing Then
                    .returnkode = cb_sales.SelectedValue
                End If
                .query = "SELECT salesman_kode as kode, salesman_nama as nama FROM datasalesman_master"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "sales"
                .ShowDialog()
                cb_custo.SelectedValue = .returnkode
            End With
        End Using
        cb_ppn.Focus()
    End Sub

    Private Sub cb_ppn_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_ppn.KeyDown
        keyshortenter(in_pajak, e)
    End Sub

    Private Sub cb_ppn_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_ppn.SelectionChangeCommitted

    End Sub

    Private Sub in_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pajak.KeyDown
        keyshortenter(date_tgl_pajak, e)
    End Sub

    Private Sub date_tgl_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_pajak.KeyDown
        keyshortenter(in_barang, e)
    End Sub

    'input barang
    Private Sub in_qty_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
        keyshortenter(cb_sat, e)
    End Sub

    Private Sub cb_sat_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat.KeyDown
        keyshortenter(in_harga_beli, e)
    End Sub

    Private Sub in_harga_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_beli.KeyDown
        keyshortenter(in_discrp, e)
    End Sub

    Private Sub in_harga_beli_ValueChanged(sender As Object, e As EventArgs) Handles in_qty.ValueChanged, in_harga_beli.ValueChanged
        in_subtotal.Text = commaThousand(in_qty.Value * in_harga_beli.Value)
    End Sub

    Private Sub in_discrp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_discrp.KeyDown
        keyshortenter(in_disc1, e)
    End Sub

    Private Sub in_disc1_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc1.KeyDown
        keyshortenter(in_disc2, e)
    End Sub

    Private Sub in_disc2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc2.KeyDown
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

    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        txtToDgv()
    End Sub

    '------------ dgv barang
    Private Sub dgv_barang_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv_barang.RowsRemoved
        countbiaya()
    End Sub

    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        If e.RowIndex < 0 Then
            rowindex = 0
        Else
            rowindex = e.RowIndex
            dgvTotxt()
            dgv_barang.Rows.RemoveAt(rowindex)
        End If
    End Sub

    'menu bar
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanjual.PerformClick()
    End Sub

    Private Sub mn_cancelorder_Click(sender As Object, e As EventArgs) Handles mn_cancelorder.Click
        'set status pembelian to canceled
    End Sub

End Class