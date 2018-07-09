Public Class fr_jual_detail
    'note
    'penjualana bisa untuk input & validasi -> hutang custo
    'alur so -> sales>validasi>admin>gudang

    Private rowindex As Integer = 0
    Private jeniscusto As String

    Private Sub loadDataFaktur(faktur As String)
        op_con()
        readcommd("SELECT * FROM data_penjualan_faktur WHERE faktur_kode='" & faktur & "'")
        If rd.HasRows Then
            in_faktur.Text = faktur
            in_pajak.Text = rd.Item("faktur_pajak_no")
            date_tgl_beli.Value = rd.Item("faktur_tanggal_trans")
            date_tgl_pajak.Value = rd.Item("faktur_pajak_tanggal")
            in_gudang.Text = rd.Item("faktur_gudang")
            in_sales.Text = rd.Item("faktur_sales")
            in_custo.Text = rd.Item("faktur_customer")
            in_term.Value = rd.Item("faktur_term")
            in_catatan.Text = rd.Item("faktur_catatan")
            'cb_jenis_jual.SelectedValue = rd.Item("")
            in_jumlah.Text = commaThousand(rd.Item("faktur_jumlah"))
            in_discount.Maximum = rd.Item("faktur_jumlah")
            in_discount.Value = rd.Item("faktur_disc_rupiah")
            in_total.Text = commaThousand(rd.Item("faktur_total"))
            in_ppn_persen.Value = rd.Item("faktur_ppn_persen")
            cb_ppn_jenis.SelectedValue = rd.Item("faktur_ppn_jenis")
            in_netto.Text = commaThousand(rd.Item("faktur_netto"))
            in_klaim.Value = CDbl(rd.Item("faktur_klaim"))
            in_total_netto.Text = commaThousand(rd.Item("faktur_total_netto"))
            in_status_kode.Text = rd.Item("faktur_status")
            cb_status.SelectedValue = in_status_kode.Text
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
        setGudang(in_gudang.Text)
        setSales(in_sales.Text)
        setCusto(in_custo.Text)
    End Sub

    Private Sub loadDataBarang(faktur As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_beli, trans_harga_jual, trans_qty, trans_satuan, trans_disc1, trans_disc2, trans_disc3, trans_disc4, trans_disc5, trans_disc_rupiah, trans_jumlah FROM data_penjualan_trans INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & faktur & "'")
        With dgv_barang.Rows
            For Each rows As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("kode").Value = rows.ItemArray(0)
                    .Cells("nama").Value = rows.ItemArray(1)
                    .Cells("hargabeli").Value = rows.ItemArray(2)
                    .Cells("harga").Value = rows.ItemArray(3)
                    .Cells("qty").Value = rows.ItemArray(4)
                    .Cells("sat").Value = rows.ItemArray(5)
                    .Cells("disc1").Value = rows.ItemArray(6)
                    .Cells("disc2").Value = rows.ItemArray(7)
                    .Cells("disc3").Value = rows.ItemArray(8)
                    .Cells("disc4").Value = rows.ItemArray(9)
                    .Cells("disc5").Value = rows.ItemArray(10)
                    .Cells("discrp").Value = rows.ItemArray(11)
                    .Cells("jml").Value = rows.ItemArray(12)
                End With
            Next
        End With
        dt.Dispose()
    End Sub

    Private Sub setGudang(kode As String)
        op_con()
        readcommd("SELECT gudang_nama FROM data_barang_gudang WHERE gudang_kode='" & kode & "'")
        If rd.HasRows Then
            lbl_gudang.Text = rd.Item("gudang_nama")
        End If
        rd.Close()
    End Sub

    Private Sub setCusto(kode As String)
        op_con()
        readcommd("SELECT customer_nama, customer_kriteria_harga_jual FROM data_customer_master WHERE customer_kode='" & kode & "'")
        If rd.HasRows Then
            lbl_custo.Text = rd.Item("customer_nama")
            jeniscusto = rd.Item("customer_kriteria_harga_jual")
        End If
        rd.Close()
    End Sub

    Private Sub setSales(kode As String)
        op_con()
        readcommd("SELECT salesman_nama FROM data_salesman_master WHERE salesman_kode='" & kode & "'")
        If rd.HasRows Then
            lbl_sales.Text = rd.Item("salesman_nama")
        End If
        rd.Close()
    End Sub

    Private Sub setBarang(kode As String, gudang As String)
        Dim qtymax As Integer = 0
        Dim isi As Integer = 1
        op_con()
        readcommd("SELECT barang_nama, barang_satuan_besar, barang_harga_jual, barang_harga_jual_mt, barang_harga_jual_horeka, barang_harga_jual_rita, barang_harga_jual_d1, barang_harga_jual_d2, barang_harga_jual_d3, barang_harga_jual_d4, barang_harga_jual_d5, barang_satuan_besar_jumlah, barang_satuan_tengah_jumlah FROM data_barang_master WHERE barang_kode='" & kode & "'")
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
            lbl_barang.Text = rd.Item("barang_nama")
            lbl_sat.Text = rd.Item("barang_satuan_besar")
            in_harga_jual.Text = harga
            in_disc1.Value = rd.Item("barang_harga_jual_d1")
            in_disc2.Value = rd.Item("barang_harga_jual_d2")
            in_disc3.Value = rd.Item("barang_harga_jual_d3")
            in_disc4.Value = rd.Item("barang_harga_jual_d4")
            in_disc5.Value = rd.Item("barang_harga_jual_d5")
            isi = CInt(rd.Item("barang_satuan_besar_jumlah")) * CInt(rd.Item("barang_satuan_tengah_jumlah"))
        End If
        rd.Close()
        '- limit qty berdasarkan stok
        readcommd("SELECT stock_sisa FROM data_barang_stok WHERE stock_barang='" & kode & "' AND stock_gudang='" & gudang & "'")
        If rd.HasRows Then
            qtymax = rd.Item("stock_sisa")
        End If
        rd.Close()
        in_qty.Maximum = CInt(qtymax / isi)
    End Sub

    Private Sub addRowBarang()
        If Trim(lbl_barang.Text) = Nothing Then
            in_barang.Focus()
            Exit Sub
        End If
        If in_qty.Value = 0 Then
            in_qty.Focus()
            Exit Sub
        End If

        With dgv_barang.Rows
            Dim x As Integer = .Add
            With .Item(x)
                .Cells("kode").Value = in_barang.Text
                .Cells("nama").Value = lbl_barang.Text
                .Cells("qty").Value = in_qty.Value
                .Cells("sat").Value = lbl_sat.Text
                .Cells("harga").Value = in_harga_jual.Text
                .Cells("disc1").Value = in_disc1.Value
                .Cells("disc2").Value = in_disc2.Value
                .Cells("disc3").Value = in_disc3.Value
                .Cells("disc4").Value = in_disc4.Value
                .Cells("disc5").Value = in_disc5.Value
                .Cells("discrp").Value = in_discrp.Value
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
            in_barang.Text = .Cells("kode").Value
            lbl_barang.Text = .Cells("nama").Value
            in_qty.Value = .Cells("qty").Value
            lbl_sat.Text = .Cells("sat").Value
            in_harga_jual.Text = .Cells("harga").Value
            in_disc1.Value = .Cells("disc1").Value
            in_disc2.Value = .Cells("disc2").Value
            in_disc3.Value = .Cells("disc3").Value
            in_disc4.Value = .Cells("disc4").Value
            in_disc5.Value = .Cells("disc5").Value
            in_discrp.Value = .Cells("discrp").Value
        End With
    End Sub

    Private Function biayaPerItem() As Double
        Dim x As Double = 0
        Dim y As Double = CDbl(in_harga_jual.Text)
        x = in_qty.Value * y
        x = x - (x * in_disc1.Value / 100)
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
        Dim y As Double = x - CDbl(in_discount.Value)
        Dim z As Double = y
        If cb_ppn_jenis.SelectedValue = 0 Then
            z += x * in_ppn_persen.Value / 100
        End If
        Dim aa As Double = z - CDbl(in_klaim.Value)
        Dim cc As Globalization.CultureInfo = Globalization.CultureInfo.GetCultureInfo("id-ID")
        in_jumlah.Text = x.ToString("N2", cc)
        in_discount.Maximum = x
        in_total.Text = y.ToString("N2", cc)
        in_netto.Text = z.ToString("N2", cc)
        in_klaim.Maximum = z
        in_total_netto.Text = aa.ToString("N2", cc)
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
        lbl_barang.Text = ""
        lbl_sat.Text = ""
        in_harga_jual.Clear()
        'in_barang.Clear()
        in_qty.Value = 0
        in_qty.Maximum = 99999
        in_disc1.Value = 0
        in_disc2.Value = 0
        in_disc3.Value = 0
        in_disc4.Value = 0
        in_disc5.Value = 0
        in_discrp.Value = 0
    End Sub

    Private Sub fr_jual_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_barang.Text = ""
        lbl_gudang.Text = ""
        lbl_sales.Text = ""
        lbl_custo.Text = ""
        lbl_sat.Text = ""

        With cb_jenis_jual
            .DataSource = jenisJual()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
        With cb_status
            .DataSource = statusBarang()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
        With cb_ppn_jenis
            .DataSource = jenisPPN()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        With dgv_barang
            For Each x As DataGridViewColumn In {harga, discrp, jml}
                x.DefaultCellStyle = dgvstyle_currency
            Next
        End With

        If bt_simpanjual.Text = "Update" Then
            GroupBox4.Visible = True
            loadDataBarang(in_faktur.Text)
            loadDataFaktur(in_faktur.Text)

        End If
    End Sub

    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanjual.Click
        If lbl_sales.Text = "" Then
            MessageBox.Show("Sales belum di input")
            in_sales.Focus()
            Exit Sub
        End If
        If lbl_custo.Text = "" Then
            MessageBox.Show("Customer belum di input")
            in_custo.Focus()
            Exit Sub
        End If
        If lbl_gudang.Text = "" Then
            MessageBox.Show("Gudang belum di input")
            in_gudang.Focus()
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
        If bt_simpanjual.Text = "Simpan" Then
            'TODO generate ID
            readcommd("SELECT COUNT(faktur_tanggal_trans) FROM data_penjualan_faktur WHERE faktur_tanggal_trans='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'")
            Dim x As Integer = rd.Item(0)
            x += 1
            rd.Close()
            Dim fakturkode As String = date_tgl_beli.Value.ToString("yyyyMMdd") & x.ToString("D4")
            in_faktur.Text = fakturkode

            '-> kurang jenis jual
            dataFak = {
                "faktur_kode='" & in_faktur.Text & "'",
                "faktur_tanggal_trans='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_jenis_jual='" & cb_jenis_jual.SelectedValue & "'",
                "faktur_pajak_no='" & in_pajak.Text & "'",
                "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_gudang='" & in_gudang.Text & "'",
                "faktur_sales='" & in_sales.Text & "'",
                "faktur_customer='" & in_custo.Text & "'",
                "faktur_term='" & in_term.Value & "'",
                "faktur_catatan='" & in_catatan.Text & "'",
                "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text) & "'",
                "faktur_disc_rupiah='" & in_discount.Value & "'",
                "faktur_total='" & removeCommaThousand(in_total.Text) & "'",
                "faktur_ppn_persen='" & in_ppn_persen.Value & "'",
                "faktur_ppn_jenis='" & cb_ppn_jenis.SelectedValue & "'",
                "faktur_netto='" & removeCommaThousand(in_netto.Text) & "'",
                "faktur_klaim='" & in_klaim.Value & "'",
                "faktur_total_netto='" & removeCommaThousand(in_total_netto.Text) & "'",
                "faktur_status=1",
                "faktur_reg_date=NOW()",
                "faktur_reg_alias='" & loggeduser.user_id & "'"
                }
            'TODO Insert to data_penjualan_faktur
            'querycheck = commnd("INSERT INTO data_penjualan_faktur SET " & String.Join(",", dataFak))
            queryArr.Add("INSERT INTO data_penjualan_faktur SET " & String.Join(",", dataFak))
        ElseIf bt_simpanjual.Text = "Update" Then
            dataFak = {
                "faktur_tanggal_trans='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_jenis_jual='" & cb_jenis_jual.SelectedValue & "'",
                "faktur_pajak_no='" & in_pajak.Text & "'",
                "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
                "faktur_gudang='" & in_gudang.Text & "'",
                "faktur_sales='" & in_sales.Text & "'",
                "faktur_customer='" & in_custo.Text & "'",
                "faktur_term='" & in_term.Value & "'",
                "faktur_catatan='" & in_catatan.Text & "'",
                "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text) & "'",
                "faktur_disc_rupiah='" & in_discount.Value & "'",
                "faktur_total='" & removeCommaThousand(in_total.Text) & "'",
                "faktur_ppn_persen='" & in_ppn_persen.Value & "'",
                "faktur_ppn_jenis='" & cb_ppn_jenis.SelectedValue & "'",
                "faktur_netto='" & removeCommaThousand(in_netto.Text) & "'",
                "faktur_klaim='" & in_klaim.Value & "'",
                "faktur_total_netto='" & removeCommaThousand(in_total_netto.Text) & "'",
                "faktur_status='" & in_status_kode.Text & "'",
                "faktur_upd_date=NOW()",
                "faktur_upd_alias='" & loggeduser.user_id & "'"
                }
            'TODO update to data_penjualan_faktur
            'querycheck = commnd("UPDATE data_penjualan_faktur SET " & String.Join(",", dataFak) & " WHERE faktur_kode='" & in_faktur.Text & "'")
            queryArr.Add("UPDATE data_penjualan_faktur SET " & String.Join(",", dataFak) & " WHERE faktur_kode='" & in_faktur.Text & "'")

            'TODO delete trans
            'querycheck = commnd("DELETE FROM data_penjualan_trans WHERE trans_faktur='" & in_faktur.Text & "'")
            queryArr.Add("DELETE FROM data_penjualan_trans WHERE trans_faktur='" & in_faktur.Text & "'")
        End If

        'TODO insert / re-insert data trans
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
            'querycheck = commnd("INSERT INTO data_penjualan_trans SET " & String.Join(",", dataBrg))
            queryArr.Add("INSERT INTO data_penjualan_trans SET " & String.Join(",", dataBrg))

            'TODO update stock
            'check data_barang_stok?

            'querycheck = commnd(String.Format("UPDATE data_barang_stok SET stock_jual=(SELECT stock_jual FROM data_barang_stok WHERE stock_barang='{0}' AND stock_gudang='{1}')+{2} ", rows.Cells(0).Value, in_gudang.Text, rows.Cells("qty").Value))
            'recognise satuan <-db function
            queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_jual=IFNULL(stock_jual,0)+(countQTYJual('{0}',{2},'{3}')) WHERE stock_barang='{0}' AND stock_gudang='{1}'", rows.Cells(0).Value, in_gudang.Text, rows.Cells("qty").Value, rows.Cells("sat").Value))
            queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_sisa=countQTYSisaSTock('{0}','{1}') WHERE stock_barang='{0}' AND stock_gudang='{1}'", rows.Cells(0).Value, in_gudang.Text, rows.Cells("qty").Value, rows.Cells("sat").Value))

            'log
            'queryArr.Add(String.Format("INSERT INTO log_stock SET log_reg=NOW(), log_user='{0}', log_barang='{1}', log_gudang='{2}', log_tanggal=NOW(), log_ip='{3}', log_komputer='{4}', log_mac='{5}', log_nama='PENJUALAN {6}'", loggeduser.user_id, rows.Cells(0).Value, in_gudang.Text, loggeduser.user_ip, loggeduser.user_host, loggeduser.user_mac, in_faktur.Text))
        Next

        'begin transaction
        querycheck = startTrans(queryArr)

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            'commnd("ROLLBACK")
            Exit Sub
        Else
            'commnd("COMMIT")
            MessageBox.Show("Data tersimpan")
            frmpembelian.in_cari.Clear()
            populateDGVUserCon("jual", "", frmpenjualan.dgv_list)
            Me.Close()
        End If
    End Sub

    Private Sub bt_batalbeli_Click(sender As Object, e As EventArgs) Handles bt_bataljual.Click
        Me.Close()
    End Sub

    Private Sub date_tgl_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = False
            'SendKeys.Send("{Right}")
            in_pajak.Focus()
        End If
    End Sub

    Private Sub in_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pajak.KeyDown
        keyshortenter(date_tgl_pajak, e)
    End Sub

    Private Sub date_tgl_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_pajak.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = False
            'SendKeys.Send("{Right}")
            cb_jenis_jual.DroppedDown = True
            cb_jenis_jual.Focus()
        End If
    End Sub

    Private Sub cb_jenis_jual_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_jenis_jual.SelectionChangeCommitted
        in_gudang.Focus()
    End Sub

    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        lbl_gudang.Text = ""
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    If Trim(in_gudang.Text) <> Nothing Then
                        .in_cari.Text = in_gudang.Text
                        .returnkode = in_gudang.Text
                    End If
                    .query = "SELECT gudang_nama as nama, gudang_kode as kode FROM data_barang_gudang"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "gudang"
                    .ShowDialog()
                    in_gudang.Text = .returnkode
                End With
            End Using
            in_sales.Focus()
            Exit Sub
        End If
        keyshortenter(in_sales, e)
    End Sub

    Private Sub in_gudang_Leave(sender As Object, e As EventArgs) Handles in_gudang.Leave
        setGudang(in_gudang.Text)
    End Sub

    Private Sub in_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales.KeyDown
        lbl_sales.Text = ""
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    .query = "SELECT salesman_nama as nama, salesman_kode as kode FROM data_salesman_master"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "sales"
                    .ShowDialog()
                    in_sales.Text = .returnkode
                End With
            End Using
            in_custo.Focus()
            Exit Sub
        End If
        keyshortenter(in_custo, e)
    End Sub

    Private Sub in_sales_Leave(sender As Object, e As EventArgs) Handles in_sales.Leave
        setSales(in_sales.Text)
    End Sub

    Private Sub in_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles in_custo.KeyDown
        lbl_custo.Text = ""
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    .query = "SELECT customer_nama as nama, customer_kode as kode FROM data_customer_master"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "custo"
                    .ShowDialog()
                    in_custo.Text = .returnkode
                End With
            End Using
            in_term.Focus()
            Exit Sub
        ElseIf e.KeyCode = Keys.F2 Then
            setCusto(Trim(in_custo.Text))
            If lbl_custo.Text = "" Then
                Using newcus As New fr_custo_detail
                    With newcus
                        .in_kode.Text = in_custo.Text
                        .in_kode_sales.Focus()
                        .in_kode_sales.Text = in_sales.Text
                        .in_nama_custo.Focus()
                        .ShowDialog()
                        in_custo.Text = .in_kode.Text
                        in_sales.Text = .in_kode_sales.Text
                        setSales(in_sales.Text)
                    End With
                End Using
                in_term.Focus()
                Exit Sub
            End If
        End If
        keyshortenter(in_term, e)
    End Sub

    Private Sub in_custo_Leave(sender As Object, e As EventArgs) Handles in_custo.Leave
        setCusto(in_custo.Text)
    End Sub

    Private Sub in_term_KeyDown(sender As Object, e As KeyEventArgs) Handles in_term.KeyDown
        keyshortenter(in_catatan, e)
    End Sub

    Private Sub in_catatan_KeyDown(sender As Object, e As KeyEventArgs) Handles in_catatan.KeyDown
        keyshortenter(in_barang, e)
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        clearInputBarang()
        If e.KeyCode = Keys.F1 Then
            Using search As New fr_search_dialog
                With search
                    .query = "SELECT barang_nama as nama, barang_kode as kode, barang_harga_jual as hargajual, barang_harga_beli as hargabeli FROM data_barang_master INNER JOIN data_barang_stok ON barang_kode=stock_barang WHERE stock_gudang='" & in_gudang.Text & "'"
                    .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                    .type = "barang"
                    .ShowDialog()
                    in_barang.Text = .returnkode
                End With
            End Using
            in_qty.Focus()
            Exit Sub
        End If
        keyshortenter(in_qty, e)
    End Sub

    Private Sub in_barang_Leave(sender As Object, e As EventArgs) Handles in_barang.Leave
        If Trim(in_barang.Text) <> "" And lbl_gudang.Text <> "" Then
            setBarang(in_barang.Text, in_gudang.Text)
        End If
    End Sub

    Private Sub in_qty_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
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
        keyshortenter(in_discrp, e)
    End Sub

    Private Sub in_discrp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_discrp.KeyDown
        If e.KeyCode = Keys.Enter Then
            addRowBarang()
            in_barang.Focus()
        End If
    End Sub

    Private Sub in_discount_KeyDown(sender As Object, e As KeyEventArgs) Handles in_discount.KeyUp
        keyshortenter(in_ppn_persen, e)
    End Sub

    Private Sub in_ppn_persen_KeyDown(sender As Object, e As KeyEventArgs) Handles in_ppn_persen.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = False
            cb_ppn_jenis.Focus()
            cb_ppn_jenis.DroppedDown = True
        End If
    End Sub

    Private Sub cb_ppn_jenis_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_ppn_jenis.SelectionChangeCommitted
        countBiaya()
        in_klaim.Focus()
    End Sub

    Private Sub in_klaim_KeyDown(sender As Object, e As KeyEventArgs) Handles in_klaim.KeyDown
        keyshortenter(bt_simpanjual, e)
    End Sub

    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        rowindex = e.RowIndex
        dgvToTxt()
        dgv_barang.Rows.RemoveAt(e.RowIndex)
    End Sub

    Private Sub dgv_barang_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv_barang.RowsRemoved
        countBiaya()
    End Sub

    Private Sub in_discount_ValueChanged(sender As Object, e As EventArgs) Handles in_discount.Leave, in_ppn_persen.Leave, in_klaim.Leave
        countBiaya()
    End Sub

    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_disc1.Enter, in_disc2.Enter, in_disc3.Enter, in_disc4.Enter, in_disc5.Enter, in_discrp.Enter, in_discount.Enter, in_ppn_persen.Enter, in_klaim.Enter, in_term.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_disc1.Leave, in_disc2.Leave, in_disc3.Leave, in_disc4.Leave, in_disc5.Leave, in_discrp.Leave, in_discount.Leave, in_ppn_persen.Leave, in_klaim.Leave, in_term.Leave
        numericLostFocus(sender)
    End Sub

    Private Sub cb_status_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_status.SelectionChangeCommitted
        in_status_kode.Text = cb_status.SelectedValue
    End Sub

    Private Sub fr_jual_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_bataljual.PerformClick()
        End If
    End Sub
End Class