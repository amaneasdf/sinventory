Public Class fr_jual_detail
    'note
    'penjualana bisa untuk input & validasi -> hutang custo
    'alur so -> sales>validasi>admin>gudang

    Private rowindex As Integer = 0
    Private rowindexlist As Integer = 0
    Private jeniscusto As String
    Public tjlStatus As String = 1
    Private popupstate As String = "barang"

    Private Sub loadDataFaktur(faktur As String)
        Dim q As String = "SELECT faktur_ppn_jenis, faktur_pajak_no, faktur_tanggal_trans, faktur_pajak_tanggal, faktur_gudang, " _
                          & "gudang_nama, faktur_sales, salesman_nama, faktur_customer,customer_nama , faktur_term, faktur_catatan, " _
                          & "faktur_jumlah, faktur_disc_rupiah, faktur_total, faktur_ppn_persen, faktur_netto, faktur_status, " _
                          & "faktur_reg_alias, faktur_reg_date, faktur_upd_alias, faktur_upd_date, faktur_bayar " _
                          & "FROM data_penjualan_faktur LEFT JOIN data_barang_gudang ON gudang_kode=faktur_gudang " _
                          & "LEFT JOIN data_salesman_master ON salesman_kode=faktur_sales " _
                          & "LEFT JOIN data_customer_master ON customer_kode=faktur_customer " _
                          & "WHERE faktur_kode='{0}'"
        op_con()
        readcommd(String.Format(q, faktur))
        If rd.HasRows Then
            in_faktur.Text = faktur
            cb_ppn.SelectedValue = rd.Item("faktur_ppn_jenis")
            in_pajak.Text = rd.Item("faktur_pajak_no")
            date_tgl_beli.Value = rd.Item("faktur_tanggal_trans")
            date_tgl_pajak.Value = rd.Item("faktur_pajak_tanggal")
            in_gudang.Text = rd.Item("faktur_gudang")
            in_gudang_n.Text = rd.Item("gudang_nama")
            in_sales.Text = rd.Item("faktur_sales")
            in_sales_n.Text = rd.Item("salesman_nama")
            in_custo.Text = rd.Item("faktur_customer")
            in_custo_n.Text = rd.Item("customer_nama")
            in_term.Value = rd.Item("faktur_term")
            in_ket.Text = rd.Item("faktur_catatan")
            in_jumlah.Text = commaThousand(rd.Item("faktur_jumlah"))
            in_diskon.Text = commaThousand(rd.Item("faktur_disc_rupiah"))
            in_total.Text = commaThousand(rd.Item("faktur_total"))
            in_ppn_tot.Text = commaThousand(rd.Item("faktur_ppn_persen"))
            in_netto.Text = commaThousand(rd.Item("faktur_netto"))
            in_bayar.Value = rd.Item("faktur_bayar")
            in_sisa.Text = commaThousand(rd.Item("faktur_netto") - rd.Item("faktur_bayar"))
            tjlStatus = rd.Item("faktur_status")
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

        setStatus()
    End Sub

    Private Sub loadDataBarang(faktur As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_jual, trans_qty, trans_satuan, trans_disc1, trans_disc2, trans_disc3, trans_disc4, trans_disc5, trans_disc_rupiah, trans_jumlah, trans_satuan_type, trans_hpp FROM data_penjualan_trans INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & faktur & "'")
        With dgv_barang.Rows
            For Each rows As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("kode").Value = rows.ItemArray(0)
                    .Cells("nama").Value = rows.ItemArray(1)
                    .Cells("harga").Value = rows.ItemArray(2)
                    .Cells("qty").Value = rows.ItemArray(3)
                    .Cells("sat").Value = rows.ItemArray(4)
                    .Cells("sat_type").Value = rows.ItemArray(12)
                    .Cells("subtotal").Value = rows.ItemArray(2) * rows.ItemArray(3)
                    .Cells("disc1").Value = rows.ItemArray(5)
                    .Cells("disc2").Value = rows.ItemArray(6)
                    .Cells("disc3").Value = rows.ItemArray(7)
                    .Cells("disc4").Value = rows.ItemArray(8)
                    .Cells("disc5").Value = rows.ItemArray(9)
                    .Cells("discrp").Value = rows.ItemArray(10)
                    .Cells("jml").Value = rows.ItemArray(11)
                    .Cells("brg_hpp").Value = rows.ItemArray(12)
                End With
            Next
        End With
        dt.Dispose()
    End Sub

    Private Sub setStatus()
        Select Case tjlStatus
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
        rd.Close()
    End Sub

    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        setDoubleBuffered(Me.dgv_listbarang, True)
        Dim q As String
        Dim dt As New DataTable
        Dim autoco As New AutoCompleteStringCollection
        Select Case tipe
            Case "barang"
                Dim jns As String = "barang_harga_jual"
                Select Case jeniscusto
                    Case "1"
                        jns = jns
                    Case "2"
                        jns = "barang_harga_jual_mt"
                    Case "3"
                        jns = "barang_harga_jual_horeka"
                    Case "4"
                        jns = "barang_harga_jual_rita"
                    Case "5"
                        jns = "barang_harga_jual"
                    Case Else
                        jns = jns
                End Select
                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama', {0}, barang_harga_jual_d1, barang_harga_jual_d2, " _
                    & "barang_harga_jual_d3, barang_harga_jual_d4, barang_harga_jual_d5, barang_harga_jual_discount " _
                    & "FROM data_barang_master RIGHT JOIN data_stok_awal ON stock_barang=barang_kode AND " _
                    & "stock_gudang='" & in_gudang.Text & "' WHERE barang_nama LIKE '{1}' GROUP BY barang_kode LIMIT 250"
                q = String.Format(q, jns, "{0}%")
            Case "custo"
                q = "SELECT customer_kode AS 'Kode', customer_nama AS 'Nama', customer_term, customer_kriteria_harga_jual FROM data_customer_master WHERE customer_status=1 AND customer_nama LIKE '{0}%'"
            Case "gudang"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang WHERE gudang_status=1 AND gudang_nama LIKE '{0}%'"
            Case "sales"
                q = "SELECT salesman_kode AS 'Kode', salesman_nama AS 'Nama' FROM data_salesman_master WHERE salesman_status=1 AND salesman_nama LIKE '{0}%'"
            Case Else
                Exit Sub
        End Select

        consoleWriteLine(String.Format(q, param))
        dt = getDataTablefromDB(String.Format(q, param))

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 135
            .Columns(1).Width = 200
            If tipe = "barang" Or tipe = "custo" Then
                For i = 2 To IIf(tipe = "custo", 3, 8)
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
                    in_disc4.Value = .Cells(6).Value
                    in_disc5.Value = .Cells(7).Value
                    loadSatuanBrg(in_barang.Text)
                    in_qty.Focus()
                Case "custo"
                    in_custo.Text = .Cells(0).Value
                    in_custo_n.Text = .Cells(1).Value
                    jeniscusto = .Cells(3).Value
                    in_term.Value = .Cells(2).Value
                    in_gudang_n.Focus()
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    in_custo_n.Focus()
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    in_term.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
    End Sub

    'INPUT DATA TO DGV FR TEXTBOX
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
        Dim hpp As Double = 0

        op_con()
        readcommd("SELECT AVG(stock_hpp) FROM data_stok_awal WHERE stock_barang='" & in_barang.Text & "'")
        If rd.HasRows Then
            hpp = rd.Item(0)
        End If
        rd.Close()

        For Each x As Double In {in_disc1.Value, in_disc2.Value, in_disc3.Value, in_disc4.Value, in_disc5.Value}
            If x <> 0 Then
                Dim y As Double = total
                total = y * (1 - x / 100)
            Else
                total = total
            End If
        Next

        If in_discrp.Value <> 0 Then
            total -= in_discrp.Value * in_qty.Value
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
                .Cells("subtotal").Value = in_harga_beli.Value * in_qty.Value
                .Cells("disc1").Value = in_disc1.Value
                .Cells("disc2").Value = in_disc2.Value
                .Cells("disc3").Value = in_disc3.Value
                .Cells("disc4").Value = in_disc4.Value
                .Cells("disc5").Value = in_disc5.Value
                .Cells("discrp").Value = in_discrp.Value
                .Cells("jml").Value = removeCommaThousand(in_subtotal.Text)
                .Cells("brg_hpp").Value = hpp
            End With
        End With

        countBiaya()
        clearInputBarang()
        in_barang_nm.Clear()
        in_barang.Focus()
    End Sub

    Private Sub dgvToTxt()
        With dgv_barang.SelectedRows.Item(0)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty.Value = .Cells("qty").Value
            loadSatuanBrg(.Cells("kode").Value)
            cb_sat.SelectedValue = .Cells("sat_type").Value
            in_harga_beli.Text = .Cells("harga").Value
            'in_subtotal.Text = .Cells("subtot").Value
            in_disc1.Value = .Cells("disc1").Value
            in_disc2.Value = .Cells("disc2").Value
            in_disc3.Value = .Cells("disc3").Value
            in_disc4.Value = .Cells("disc4").Value
            in_disc5.Value = .Cells("disc5").Value
            in_discrp.Value = .Cells("discrp").Value
        End With

        countBiaya()
        in_qty.Focus()
    End Sub

    Private Sub countBiaya()
        Dim pajak As Double = 0
        Dim subtotal As Double = 0
        Dim y As Double = 0
        Dim netto As Double = y
        Dim diskon As Double = 0

        For Each rows As DataGridViewRow In dgv_barang.Rows
            Console.WriteLine(rows.Cells("subtotal").Value)
            subtotal += rows.Cells("subtotal").Value
        Next

        For Each row As DataGridViewRow In dgv_barang.Rows
            diskon += row.Cells("subtotal").Value - row.Cells("jml").Value
        Next

        y = subtotal - diskon
        netto = y

        If cb_ppn.SelectedValue = 0 Then
            pajak = subtotal * 0.1
            netto += pajak
        ElseIf cb_ppn.SelectedValue = 1 Then
            'pajak = x - (x / 1.1)
            pajak = subtotal * (1 - 10 / 11)
        Else
            pajak = 0
        End If

        'Dim aa As Double = netto - CDbl(in_klaim.Value)
        Dim cc As Globalization.CultureInfo = Globalization.CultureInfo.GetCultureInfo("id-ID")
        in_jumlah.Text = subtotal.ToString("N2", cc)
        in_diskon.Text = commaThousand(diskon)
        in_ppn_tot.Text = commaThousand(pajak)
        in_total.Text = y.ToString("N2", cc)
        in_netto.Text = netto.ToString("N2", cc)
        in_sisa.Text = commaThousand(netto - in_bayar.Value)
        'in_klaim.Maximum = netto
        'in_total_netto.Text = aa.ToString("N2", cc)
    End Sub

    Private Sub clearTextBarang()
        in_harga_beli.Value = 0
        For Each x As TextBox In {in_barang, in_subtotal}
            x.Clear()
        Next
    End Sub

    Private Sub clearInputBarang()
        clearTextBarang()
        in_barang_nm.Clear()
        For Each x As NumericUpDown In {in_qty, in_disc1, in_disc2, in_disc3, in_disc4, in_disc5, in_discrp}
            x.Value = 0
        Next
    End Sub

    'SAVE
    Private Sub saveData()
        'THESE NEED REWORK
        op_con()

        Dim dataBrg, dataFak As String()
        Dim data1, data2 As String()
        Dim querycheck As Boolean = False
        Dim queryArr As New List(Of String)
        Dim q1 As String = "INSERT INTO data_penjualan_faktur SET faktur_kode='{0}',{1},{2} ON DUPLICATE KEY UPDATE {1},{3}"
        Dim q2 As String = "INSERT INTO data_penjualan_trans SET trans_faktur= '{0}',{1} ON DUPLICATE KEY UPDATE {1}"
        Dim q3 As String = "DELETE FROM data_penjualan_trans WHERE trans_faktur='{0}' AND trans_barang NOT IN({1})"

        If bt_simpanjual.Text = "Simpan" Then
            'GENERATE KODE
            If in_faktur.Text = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT COUNT(faktur_kode) FROM data_penjualan_faktur WHERE SUBSTRING(faktur_kode,3,8)='" & date_tgl_beli.Value.ToString("yyyyMMdd") & "' AND faktur_kode LIKE 'SO%'")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()
                in_faktur.Text = "SO" & date_tgl_beli.Value.ToString("yyyyMMdd") & no.ToString("D4")
            ElseIf in_faktur.Text <> Nothing And bt_simpanjual.Text <> "Update" Then
                If checkdata("data_penjualan_faktur", "'" & in_faktur.Text & "'", "faktur_kode") = True Then
                    If MessageBox.Show("Faktur sudah ada. Update data faktur " & in_faktur.Text & "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                        Exit Sub
                    End If
                End If
            End If


        End If

        'INSERT BARANG
        Dim x As New List(Of String)
        Dim x_kodestock As New List(Of String)
        Dim qty As New List(Of Integer)
        Dim nilai As New List(Of Double)
        Dim persediaan As Double = 0
        For Each rows As DataGridViewRow In dgv_barang.Rows
            Dim stockkode As String = in_gudang.Text & "-" & rows.Cells(0).Value & "-" & date_tgl_beli.Value.ToString("yyMM")
            dataBrg = {
               "trans_barang='" & rows.Cells(0).Value & "'",
               "trans_harga_jual='" & rows.Cells("harga").Value & "'",
               "trans_qty='" & rows.Cells("qty").Value & "'",
               "trans_satuan='" & rows.Cells("sat").Value & "'",
               "trans_satuan_type='" & rows.Cells("sat_type").Value & "'",
               "trans_disc1='" & rows.Cells("disc1").Value.ToString.Replace(",", ".") & "'",
               "trans_disc2='" & rows.Cells("disc2").Value.ToString.Replace(",", ".") & "'",
               "trans_disc3='" & rows.Cells("disc3").Value.ToString.Replace(",", ".") & "'",
               "trans_disc4='" & rows.Cells("disc4").Value.ToString.Replace(",", ".") & "'",
               "trans_disc5='" & rows.Cells("disc5").Value.ToString.Replace(",", ".") & "'",
               "trans_disc_rupiah='" & rows.Cells("discrp").Value.ToString.Replace(",", ".") & "'",
               "trans_jumlah='" & rows.Cells("jml").Value.ToString.Replace(",", ".") & "'",
               "trans_hpp='" & rows.Cells("brg_hpp").Value.ToString.Replace(",", ".") & "'"
               }
            queryArr.Add(String.Format(q2, in_faktur.Text, String.Join(",", dataBrg)))

            'COUNT QTY TOTAL PER ITEM
            Dim _qtytot As Integer = 0
            Dim _hpp As Double = 0
            readcommd("SELECT countQTYItem('" & rows.Cells(0).Value & "'," & rows.Cells("qty").Value & ",'" & rows.Cells("sat_type").Value & "'), AVG(stock_hpp) FROM data_stok_awal WHERE stock_barang='" & rows.Cells(0).Value & "'")
            If rd.HasRows Then
                _qtytot = rd.Item(0)
                _hpp = rd.Item(1)
            End If
            rd.Close()

            persediaan += _qtytot * _hpp

            x.Add("'" & rows.Cells(0).Value & "'")
            qty.Add(_qtytot)
            x_kodestock.Add("'" & stockkode & "'")
            nilai.Add(_qtytot * _hpp)
        Next
        'DELETE REMOVED ITEM
        queryArr.Add(String.Format(q3, in_faktur.Text, String.Join(",", x)))

        dataFak = {
                    "faktur_tanggal_trans='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_pajak_no='" & in_pajak.Text & "'",
                    "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_gudang='" & in_gudang.Text & "'",
                    "faktur_sales='" & in_sales.Text & "'",
                    "faktur_customer='" & in_custo.Text & "'",
                    "faktur_term='" & in_term.Value & "'",
                    "faktur_catatan='" & in_ket.Text & "'",
                    "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text).ToString.Replace(",", ".") & "'",
                    "faktur_disc_rupiah='" & removeCommaThousand(in_diskon.Text).ToString.Replace(",", ".") & "'",
                    "faktur_total='" & removeCommaThousand(in_total.Text).ToString.Replace(",", ".") & "'",
                    "faktur_ppn_persen='" & removeCommaThousand(in_ppn_tot.Text).ToString.Replace(",", ".") & "'",
                    "faktur_ppn_jenis='" & cb_ppn.SelectedValue & "'",
                    "faktur_netto='" & removeCommaThousand(in_netto.Text).ToString.Replace(",", ".") & "'",
                    "faktur_bayar='" & in_bayar.Value.ToString.Replace(",", ".") & "'",
                    "faktur_persediaan='" & persediaan & "'",
                    "faktur_status=" & tjlStatus
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
                    "'so'",
                    "'" & in_faktur.Text & "'",
                    "'PENJUALAN'",
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
        queryArr.Add(String.Format(q5, in_faktur.Text, String.Join(",", x_kodestock)))

        'TODO : WRITE HUTANG AWAL
        Dim q6 As String = "INSERT INTO data_piutang_awal SET piutang_faktur='{0}',{1},{2} ON DUPLICATE KEY UPDATE {1},{3}"
        dataBrg = {
            "piutang_awal=" & removeCommaThousand(in_sisa.Text).ToString.Replace(",", "."),
            "piutang_piutang=0"
            }
        data1 = {
            "piutang_reg_date=NOW()",
            "piutang_reg_alias='" & loggeduser.user_id & "'"
            }
        data2 = {
            "piutang_upd_date=NOW()",
            "piutang_upd_alias='" & loggeduser.user_id & "'"
            }
        queryArr.Add(String.Format(q6, in_faktur.Text, String.Join(",", dataBrg), String.Join(",", data1), String.Join(",", data2)))

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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_bataljual.Click
        If MessageBox.Show("Tutup Form?", "Penjualan", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
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

    'MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanjual.PerformClick()
    End Sub

    Private Sub mn_print_Click(sender As Object, e As EventArgs) Handles mn_print.Click
        Using nota As New fr_view_nota
            Me.Cursor = Cursors.WaitCursor
            With nota
                .setVar("jual", in_faktur.Text, "")
                .ShowDialog()
            End With
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mn_cancelorder_Click(sender As Object, e As EventArgs) Handles mn_cancelorder.Click

    End Sub

    'LOAD
    Private Sub fr_jual_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_ppn
            .DataSource = jenisPPN()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        For Each x As DateTimePicker In {date_tgl_beli, date_tgl_pajak}
            x.Value = DateSerial(selectedperiode.Year, selectedperiode.Month, x.Value.Day)
            x.MaxDate = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)
            x.MinDate = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
        Next

        With dgv_barang
            For Each x As DataGridViewColumn In {harga, discrp, jml, subtotal}
                x.DefaultCellStyle = dgvstyle_currency
            Next
        End With

        setStatus()

        If bt_simpanjual.Text = "Update" Then
            loadDataBarang(in_faktur.Text)
            loadDataFaktur(in_faktur.Text)
            With in_faktur
                .ReadOnly = True
            End With
        End If
    End Sub

    'SAVE
    Private Sub bt_simpanjual_Click(sender As Object, e As EventArgs) Handles bt_simpanjual.Click
        If in_sales.Text = Nothing Then
            MessageBox.Show("Sales belum di input")
            in_sales_n.Focus()
            Exit Sub
        End If
        If in_custo.Text = Nothing Then
            MessageBox.Show("Customer belum di input")
            in_custo_n.Focus()
            Exit Sub
        End If
        If in_gudang.Text = Nothing Then
            MessageBox.Show("Gudang belum di input")
            in_gudang_n.Focus()
            Exit Sub
        End If
        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum di input")
            in_barang.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan data penjualan?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    'UI
    '------------- POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_sales_n.Focused Or in_gudang_n.Focused Or in_barang_nm.Focused Or in_custo_n.Focused Then
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
                Case "sales"
                    x = in_sales_n
                Case "gudang"
                    x = in_gudang_n
                Case "barang"
                    x = in_barang_nm
                Case "custo"
                    x = in_custo_n
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

    '-------------cb_ppn hanlde
    Private Sub cb_ppn_change(sender As Object, e As EventArgs) Handles cb_ppn.SelectionChangeCommitted
        If cb_ppn.SelectedIndex > -1 Then
            countBiaya()
        End If
    End Sub

    '------------- numeric
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_bayar.Enter, in_discrp.Enter, in_disc3.Enter, in_disc2.Enter, in_disc1.Enter, in_disc4.Enter, in_disc5.Enter, in_term.Enter, in_harga_beli.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_bayar.Leave, in_discrp.Leave, in_disc3.Leave, in_disc2.Leave, in_disc1.Leave, in_disc4.Leave, in_disc5.Leave, in_term.Leave, in_harga_beli.Leave
        Select Case sender.Name.ToString
            Case "in_bayar", "in_harga_beli"
                numericLostFocus(sender)
            Case Else
                numericLostFocus(sender, "N0")
        End Select
    End Sub

    '----------------- HEADER
    Private Sub in_faktur_KeyUp(sender As Object, e As KeyEventArgs) Handles in_faktur.KeyUp
        keyshortenter(date_tgl_beli, e)
    End Sub

    Private Sub date_tgl_beli_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyUp
        keyshortenter(in_pajak, e)
    End Sub

    Private Sub in_pajak_KeyUp(sender As Object, e As KeyEventArgs) Handles in_pajak.KeyUp
        keyshortenter(date_tgl_pajak, e)
    End Sub

    Private Sub date_tgl_pajak_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tgl_pajak.KeyUp
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_sales_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales.KeyUp
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

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave, in_custo_n.Leave, in_gudang_n.Leave, in_barang_nm.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(in_custo_n, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("sales", in_sales_n.Text)
        End If
    End Sub

    Private Sub in_supplier_n_TextChanged(sender As Object, e As EventArgs) Handles in_sales_n.TextChanged
        If in_sales_n.Text = "" Then
            in_sales_n.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub in_custo_KeyUp(sender As Object, e As KeyEventArgs) Handles in_custo.KeyUp
        keyshortenter(in_custo_n, e)
    End Sub

    Private Sub in_custo_n_Enter(sender As Object, e As EventArgs) Handles in_custo_n.Enter
        popPnl_barang.Location = New Point(in_custo_n.Left, in_custo_n.Top + in_custo_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "custo"
        loadDataBRGPopup("custo", in_custo_n.Text)
    End Sub

    Private Sub in_custo_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_custo_n.KeyUp
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
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("custo", in_custo_n.Text)
        End If
    End Sub

    Private Sub in_custo_n_TextChanged(sender As Object, e As EventArgs) Handles in_custo_n.TextChanged
        If in_custo_n.Text = "" Then
            in_custo_n.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub in_gudang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyUp
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

    Private Sub in_gudang_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(in_term, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("gudang", in_gudang_n.Text)
        End If
    End Sub

    Private Sub in_gudang_n_TextChanged(sender As Object, e As EventArgs) Handles in_gudang_n.TextChanged
        If in_gudang_n.Text = "" Then
            in_gudang_n.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub in_term_KeyUp(sender As Object, e As KeyEventArgs) Handles in_term.KeyUp
        keyshortenter(cb_ppn, e)
    End Sub

    Private Sub cb_ppn_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_ppn.KeyUp
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
            in_barang.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub in_qty_KeyUp(sender As Object, e As KeyEventArgs) Handles in_qty.KeyUp
        keyshortenter(cb_sat, e)
    End Sub

    Private Sub in_harga_beli_ValueChanged(sender As Object, e As EventArgs) Handles in_qty.ValueChanged, in_harga_beli.ValueChanged, in_disc1.ValueChanged, in_disc2.ValueChanged, in_disc3.ValueChanged, in_disc4.ValueChanged, in_disc5.ValueChanged, in_discrp.ValueChanged
        'in_subtotal.Text = commaThousand(in_qty.Value * in_harga_beli.Value)
        Dim total As Double = in_qty.Value * in_harga_beli.Value

        For Each x As Double In {in_disc1.Value, in_disc2.Value, in_disc3.Value, in_disc4.Value, in_disc5.Value}
            If x <> 0 Then
                Dim y As Double = total
                total = y * (1 - x / 100)
            Else
                total = total
            End If
        Next

        If in_discrp.Value <> 0 Then
            total -= in_discrp.Value * in_qty.Value
        End If

        in_subtotal.Text = commaThousand(total)
    End Sub

    Private Sub cb_sat_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_sat.KeyUp
        keyshortenter(in_harga_beli, e)
    End Sub

    Private Sub in_harga_beli_KeyUp(sender As Object, e As KeyEventArgs) Handles in_harga_beli.KeyUp
        keyshortenter(in_discrp, e)
    End Sub

    Private Sub in_discrp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_discrp.KeyUp
        keyshortenter(in_disc1, e)
    End Sub

    Private Sub in_subtotal_KeyUp(sender As Object, e As KeyEventArgs) Handles in_subtotal.KeyUp
        keyshortenter(in_disc1, e)
    End Sub

    Private Sub in_disc1_KeyUp(sender As Object, e As KeyEventArgs) Handles in_disc1.KeyUp
        keyshortenter(in_disc2, e)
    End Sub

    Private Sub in_disc2_KeyUp(sender As Object, e As KeyEventArgs) Handles in_disc2.KeyUp
        keyshortenter(in_disc3, e)
    End Sub

    Private Sub in_disc3_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc3.KeyUp
        keyshortenter(in_disc4, e)
    End Sub

    Private Sub in_disc4_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc4.KeyUp
        keyshortenter(in_disc5, e)
    End Sub

    Private Sub in_disc5_KeyDown(sender As Object, e As KeyEventArgs) Handles in_disc5.KeyUp
        keyshortenter(bt_tbbarang, e)
    End Sub

    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        txtToDgv()
    End Sub

    'DGV
    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        If e.RowIndex > -1 Then
            dgvToTxt()
            dgv_barang.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    Private Sub in_bayar_ValueChanged(sender As Object, e As EventArgs) Handles in_bayar.ValueChanged
        in_sisa.Text = commaThousand(IIf(in_netto.Text <> Nothing, removeCommaThousand(in_netto.Text), 0) - in_bayar.Value)
    End Sub
End Class