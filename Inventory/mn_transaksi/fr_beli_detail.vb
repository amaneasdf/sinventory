
Public Class fr_beli_detail
    Private indexrow As Integer = 0
    Private pajak As String
    Private statusbarang As String = 0
    Private statusbayar As String = 0

    Private Sub loadDataBeliFaktur(faktur As String)
        readcommd("SELECT * FROM data_pembelian_faktur WHERE faktur_kode='" & faktur & "'")
        If rd.HasRows Then
            in_faktur.Text = faktur
            in_suratjalan.Text = rd.Item("faktur_surat_jalan")
            in_pajak.Text = rd.Item("faktur_pajak_no")
            date_tgl_beli.Value = rd.Item("faktur_tanggal_trans")
            date_tgl_pajak.Value = rd.Item("faktur_pajak_tanggal")
            cb_gudang.SelectedValue = rd.Item("faktur_gudang")
            cb_supplier.SelectedValue = rd.Item("faktur_supplier")
            in_term.Value = rd.Item("faktur_term")
            Console.WriteLine("rd" & rd.Item("faktur_jumlah") & "nett" & rd.Item("faktur_netto"))
            in_jumlah.Text = commaThousand(rd.Item("faktur_jumlah"))
            in_discount.Maximum = rd.Item("faktur_jumlah")
            in_discount.Value = rd.Item("faktur_disc")
            in_total.Text = commaThousand(rd.Item("faktur_total"))
            'in_ppn_persen.Value = rd.Item("faktur_ppn_persen")
            cb_ppn.SelectedValue = rd.Item("faktur_ppn_jenis")
            in_netto.Text = commaThousand(rd.Item("faktur_netto"))
            in_ppn_tot.Text = commaThousand(rd.Item("faktur_ppn"))
            'Console.WriteLine(rd.Item("faktur_netto"))
            in_klaim.Value = CDbl(rd.Item("faktur_klaim"))
            in_total_netto.Text = commaThousand(rd.Item("faktur_total_netto"))
            in_status_kode.Text = rd.Item("faktur_status")
            'cb_status.SelectedValue = in_status_kode.Text
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

    Private Sub loadDatabeliBarang(faktur As String)
        'dgv_barang.DataSource = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_beli, trans_qty, trans_satuan, trans_disc1,trans_disc2,trans_disc3,trans_disc_rupiah, trans_jumlah FROM data_pembelian_trans INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & faktur & "'")
        Dim dt As New DataTable
        dt = getDataTablefromDB("SELECT trans_barang, barang_nama, trans_harga_beli, trans_qty, trans_satuan, trans_disc1,trans_disc2,trans_disc3,trans_disc_rupiah, trans_jumlah, trans_ppn FROM data_pembelian_trans INNER JOIN data_barang_master ON barang_kode = trans_barang WHERE trans_faktur='" & faktur & "'")
        With dgv_barang.Rows
            For Each row As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("kode").Value = row.ItemArray(0)
                    .Cells("nama").Value = row.ItemArray(1)
                    .Cells("qty").Value = row.ItemArray(3)
                    .Cells("sat").Value = row.ItemArray(4)
                    .Cells("harga").Value = row.ItemArray(2)
                    .Cells("ppnbrg").Value = row.ItemArray(10)
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

    Private Sub setBarang(kode As String)
        op_con()
        readcommd("SELECT barang_kode, barang_nama, barang_satuan_besar, barang_harga_beli, barang_harga_beli_d1, barang_harga_beli_d2, barang_harga_beli_d3, barang_status_pajak FROM data_barang_master WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            in_barang.Text = rd.Item("barang_kode")
            in_barang_nm.Text = rd.Item("barang_nama")
            in_satuan.Text = rd.Item("barang_satuan_besar")
            in_harga_beli.Text = rd.Item("barang_harga_beli")
            in_disc1.Value = rd.Item("barang_harga_beli_d1")
            in_disc2.Value = rd.Item("barang_harga_beli_d2")
            in_disc2.Value = rd.Item("barang_harga_beli_d3")
            pajak = rd.Item("barang_status_pajak")
        End If
        rd.Close()
    End Sub

    Private Sub setStatus(stbarang As String, stbayar As String)
        Dim statustext As New List(Of String)
        Select Case stbarang
            Case "0"
                statustext.Add("Unfulfilled(?)")
            Case "1"
                statustext.Add("Active")
            Case "2"
                statustext.Add("Fulfilled(?)")
        End Select
        Select Case stbayar
            Case "0"
                statustext.Add("Unpaid")
            Case "1"
                statustext.Add("Paid")
        End Select

        If stbarang = "9" And stbayar = "9" Then
            in_status_kode.Text = "canceled"
        End If

        Dim text As String = String.Join(",", statustext)
        in_status_kode.Text = text
    End Sub

    Private Sub loadDataBRGPopup()
        'Dim bs As New BindingSource
        'bs.DataSource = getDataTablefromDB("SELECT barang_kode, barang_nama FROM data_barang_master")
        'bs.Filter = "barang_kode LIKE'%" & in_barang.Text & "%'"
        With dgv_listbarang
            .DataSource = getDataTablefromDB("SELECT barang_kode, barang_nama, barang_harga_beli FROM data_barang_master WHERE barang_kode LIKE'%" & in_barang.Text & "%' LIMIT 100")
        End With
    End Sub

    Private Sub addRowBarang()
        Dim pajak_tot As Double = 0
        Dim total As Double = removeCommaThousand(in_subtotal.Text) - in_discrp.Value

        If Trim(in_barang_nm.Text) = Nothing Then
            in_barang.Focus()
            Exit Sub
        End If
        If in_qty.Value = 0 Then
            in_qty.Focus()
            Exit Sub
        End If

        If cb_ppn.SelectedValue = "1" Then
            If pajak = "1" Then '---------------------------------------------------------------------tax included
                'pajak_tot = ppn * (in_qty.Value * in_harga_beli.Value)
                'If cb_ppn.SelectedValue = "1" Then
                pajak_tot = (10 * (in_qty.Value * in_harga_beli.Value) / 11)
                Console.WriteLine("pajak " & pajak_tot & " harga " & in_harga_beli.Value - pajak_tot)
                total = removeCommaThousand(in_subtotal.Text) - in_discrp.Value
                'End If
            ElseIf pajak = "2" Then '------------------------------------------------------------------tax excluded
                pajak_tot = ppn * (in_qty.Value * in_harga_beli.Value)
                total = removeCommaThousand(in_subtotal.Text) + pajak_tot - in_discrp.Value
            Else '-------------------------------------------------------------------------------------non tax
                pajak_tot = 0
            End If
        End If

        With dgv_barang.Rows
            Dim x As Integer = .Add
            With .Item(x)
                .Cells("kode").Value = in_barang.Text
                .Cells("nama").Value = in_barang_nm.Text
                .Cells("qty").Value = in_qty.Value
                .Cells("sat").Value = in_satuan.Text
                .Cells("harga").Value = in_harga_beli.Value
                .Cells("subtot").Value = removeCommaThousand(in_subtotal.Text)
                .Cells("ppnbrg").Value = pajak_tot
                .Cells("disc1").Value = in_disc1.Value
                .Cells("disc2").Value = in_disc2.Value
                .Cells("disc3").Value = in_disc3.Value
                .Cells("discrp").Value = in_discrp.Value
                .Cells("jml").Value = total
            End With
        End With

        'in_jumlah.Text = jumlahbiaya()
        countbiaya()
        clearInputBarang()
        in_barang.Focus()
    End Sub

    Private Sub dgvTotxt()
        With dgv_barang.Rows(indexrow)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty.Value = .Cells("qty").Value
            in_satuan.Text = .Cells("sat").Value
            in_harga_beli.Text = .Cells("harga").Value
            in_disc1.Value = .Cells("disc1").Value
            in_disc2.Value = .Cells("disc2").Value
            in_disc3.Value = .Cells("disc3").Value
            in_discrp.Value = .Cells("discrp").Value
        End With
        in_barang.Focus()
    End Sub

    Private Sub countbiaya()
        Dim w As Double = 0
        Dim x As Double = jumlahbiaya()
        Dim y As Double = x - CDbl(in_discount.Value)
        Dim z As Double = y
        'If cb_ppn_jenis.SelectedValue = 0 Then
        '    z += x * in_ppn_persen.Value / 100
        'End If
        For Each row As DataGridViewRow In dgv_barang.Rows
            w += row.Cells("ppnbrg").Value
        Next

        Dim aa As Double = z - CDbl(in_klaim.Value)
        Dim cc As Globalization.CultureInfo = Globalization.CultureInfo.GetCultureInfo("id-ID")
        in_jumlah.Text = x.ToString("N2", cc)
        in_discount.Maximum = x
        in_ppn_tot.Text = commaThousand(w)
        in_total.Text = y.ToString("N2", cc)
        in_netto.Text = z.ToString("N2", cc)
        in_klaim.Maximum = z
        in_total_netto.Text = aa.ToString("N2", cc)

        Console.WriteLine("ss" & aa)
        Console.WriteLine(removeCommaThousand(in_total_netto.Text))
    End Sub

    Private Function jumlahbiaya() As Double
        Dim x As Double = 0

        For Each rows As DataGridViewRow In dgv_barang.Rows
            Console.WriteLine(rows.Cells("jml").Value)
            x += rows.Cells("jml").Value
        Next

        Console.WriteLine(x)
        Return x
    End Function

    Private Sub numericGotFocus(x As NumericUpDown)
        If x.Value = 0 Then
            x.ResetText()
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

    Private Sub clearTextBarang()
        in_harga_beli.Value = 0
        For Each x As TextBox In {in_barang_nm, in_satuan, in_subtotal}
            x.Clear()
        Next
    End Sub

    Private Sub clearInputBarang()
        clearTextBarang()
        in_barang.Clear()
        in_qty.Value = 0
        in_disc1.Value = 0
        in_disc2.Value = 0
        in_disc3.Value = 0
        in_discrp.Value = 0
    End Sub

    Private Sub fr_beli_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'unfinished
        in_disc1.ReadOnly = True
        in_disc2.ReadOnly = True
        in_disc3.ReadOnly = True
        TabControl1.TabPages.Remove(TabPage2)
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

        For Each x As DataGridViewColumn In {harga, discrp, jml, ppnbrg, subtot}
            x.DefaultCellStyle = dgvstyle_currency
        Next

        If bt_simpanbeli.Text = "Update" Then
            loadDatabeliBarang(in_faktur.Text)
            loadDataBeliFaktur(in_faktur.Text)

        End If

        setStatus(statusbarang, statusbayar)
    End Sub

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

        Dim dataBrg As String()
        Dim dataFak As String()
        Dim queryArr As New List(Of String)
        Dim querycheck As Boolean = False

        op_con()
        If MessageBox.Show("Simpan data transaksi pembelian?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
            If bt_simpanbeli.Text = "Simpan" Then
                'TODO generate kode
                readcommd("SELECT COUNT(faktur_tanggal_trans) FROM data_pembelian_faktur WHERE faktur_tanggal_trans='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'")
                Dim x As Integer = rd.Item(0)
                x += 1
                rd.Close()
                Dim fakturkode As String = "PO" & date_tgl_beli.Value.ToString("yyyyMMdd") & x.ToString("D4")
                in_faktur.Text = fakturkode

                dataFak = {
                    "faktur_kode='" & in_faktur.Text & "'",
                    "faktur_tanggal_trans='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_pajak_no='" & in_pajak.Text & "'",
                    "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_surat_jalan='" & in_suratjalan.Text & "'",
                    "faktur_gudang='" & cb_gudang.SelectedValue & "'",
                    "faktur_supplier='" & cb_supplier.SelectedValue & "'",
                    "faktur_term='" & in_term.Value & "'",
                    "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text) & "'",
                    "faktur_disc='" & in_discount.Value & "'",
                    "faktur_total='" & removeCommaThousand(in_total.Text) & "'",
                    "faktur_ppn='" & removeCommaThousand(in_ppn_tot.Text) & "'",
                    "faktur_ppn_jenis='" & cb_ppn.SelectedValue & "'",
                    "faktur_netto='" & removeCommaThousand(in_netto.Text) & "'",
                    "faktur_klaim='" & in_klaim.Value & "'",
                    "faktur_total_netto='" & removeCommaThousand(in_total_netto.Text) & "'",
                    "faktur_status=1",
                    "faktur_reg_date=NOW()",
                    "faktur_reg_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add("INSERT INTO data_pembelian_faktur SET " & String.Join(",", dataFak))

            ElseIf bt_simpanbeli.Text = "Update" Then
                'TODO update?
                dataFak = {
                    "faktur_tanggal_trans='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_pajak_no='" & in_pajak.Text & "'",
                    "faktur_pajak_tanggal='" & date_tgl_pajak.Value.ToString("yyyy-MM-dd") & "'",
                    "faktur_surat_jalan='" & in_suratjalan.Text & "'",
                    "faktur_gudang='" & cb_gudang.SelectedValue & "'",
                    "faktur_supplier='" & cb_gudang.SelectedValue & "'",
                    "faktur_term='" & in_term.Value & "'",
                    "faktur_jumlah='" & removeCommaThousand(in_jumlah.Text) & "'",
                    "faktur_disc='" & in_discount.Value & "'",
                    "faktur_total='" & removeCommaThousand(in_total.Text) & "'",
                    "faktur_ppnn='" & removeCommaThousand(in_ppn_tot.Text) & "'",
                    "faktur_ppn_jenis='" & cb_ppn.SelectedValue & "'",
                    "faktur_netto='" & removeCommaThousand(in_netto.Text) & "'",
                    "faktur_klaim='" & in_klaim.Value & "'",
                    "faktur_total_netto='" & removeCommaThousand(in_total_netto.Text) & "'",
                    "faktur_status='" & in_status_kode.Text & "'",
                    "faktur_upd_date=NOW()",
                    "faktur_upd_alias='" & loggeduser.user_id & "'"
                    }
                'TODO update faktur
                queryArr.Add("UPDATE data_pembelian_faktur SET " & String.Join(",", dataFak) & " WHERE faktur_kode='" & in_faktur.Text & "'")

                'TODO delete trans
                queryArr.Add("DELETE FROM data_pembelian_trans WHERE trans_faktur='" & in_faktur.Text & "'")
            End If

            'TODO insert / re-insert data trans
            For Each rows As DataGridViewRow In dgv_barang.Rows
                dataBrg = {
                    "trans_faktur='" & in_faktur.Text & "'",
                    "trans_tanggal='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                    "trans_barang='" & rows.Cells(0).Value & "'",
                    "trans_harga_beli='" & rows.Cells("harga").Value & "'",
                    "trans_qty='" & rows.Cells("qty").Value & "'",
                    "trans_satuan='" & rows.Cells("sat").Value & "'",
                    "trans_ppn='" & rows.Cells("ppnbrg").Value & "'",
                    "trans_disc1='" & rows.Cells("disc1").Value & "'",
                    "trans_disc2='" & rows.Cells("disc2").Value & "'",
                    "trans_disc3='" & rows.Cells("disc3").Value & "'",
                    "trans_disc_rupiah='" & rows.Cells("discrp").Value & "'",
                    "trans_jumlah='" & rows.Cells("jml").Value & "'",
                    "trans_reg_date=NOW()",
                    "trans_reg_alias='" & loggeduser.user_id & "'"
                    }
                'querycheck = commnd("INSERT INTO data_pembelian_trans SET " & String.Join(",", dataBrg))
                queryArr.Add("INSERT INTO data_pembelian_trans SET " & String.Join(",", dataBrg))

                'TODO update stock?
                'count qty to s sat <- stored procedure/function

                '--check?
                If checkdata("data_barang_stok", "'" & rows.Cells(0).Value & "' AND stock_gudang='" & cb_gudang.SelectedValue & "'", "stock_barang") = False Then
                    queryArr.Add("INSERT INTO data_barang_stok SET stock_barang='" & rows.Cells(0).Value & "', stock_gudang='" & cb_gudang.SelectedValue & "', stock_reg_date=NOW(), stock_reg_alias='" & loggeduser.user_id & "'")
                    'write log
                    queryArr.Add("INSERT INTO log_stock SET log_reg=NOW(), log_user='" & loggeduser.user_id & "', log_barang='" & rows.Cells(0).Value & "', log_gudang='" & cb_gudang.SelectedValue & "', log_tanggal=NOW(), log_ip='" & loggeduser.user_ip & "', log_komputer='" & loggeduser.user_host & "', log_mac='" & loggeduser.user_mac & "', log_ket='SYSTEM', log_nama='SETUP AWAL STOK'")
                End If

                '--insert or update?
                Dim selisih As Integer = rows.Cells("qty").Value
                If bt_simpanbeli.Text = "Update" Then
                    'TODO UPDATE stok beli -> must recognize whether is added or substracted when trans update
                    'select original qty from trans_beli
                    readcommd("SELECT IFNULL(trans_qty,0) as a FROM data_pembelian_trans WHERE trans_barang='" & rows.Cells(0).Value & "' AND trans_faktur='" & in_faktur.Text & "'")
                    'count the diff
                    selisih = rows.Cells("qty").Value - rd.Item("a")
                    rd.Close()
                End If

                queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_beli= IFNULL(stock_beli,0) + (countQTYBesarToKecil('{0}',{2}))  WHERE stock_barang='{0}' AND stock_gudang='{1}'", rows.Cells(0).Value, cb_gudang.SelectedValue, selisih))
                queryArr.Add(String.Format("UPDATE data_barang_stok SET stock_sisa=countQTYSisaSTock('{0}','{1}') WHERE stock_barang='{0}' AND stock_gudang='{1}'", rows.Cells(0).Value, cb_gudang.SelectedValue))
                'write log
                queryArr.Add(String.Format("INSERT INTO log_stock SET log_reg=NOW(), log_user='{0}', log_barang='{1}', log_gudang='{2}', log_tanggal=NOW(), log_ip='{3}', log_komputer='{4}', log_mac='{5}', log_nama='PEMBELIAN {6}'", loggeduser.user_id, rows.Cells(0).Value, cb_gudang.SelectedValue, loggeduser.user_ip, loggeduser.user_host, loggeduser.user_mac, in_faktur.Text))
            Next

            'begin transaction
            querycheck = startTrans(queryArr)

            If querycheck = False Then
                MessageBox.Show("Data tidak dapat tersimpan")
                Exit Sub
            Else
                MessageBox.Show("Data tersimpan")
                frmpembelian.in_cari.Clear()
                populateDGVUserCon("beli", "", frmpembelian.dgv_list)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub fr_beli_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_batalbeli.PerformClick()
        End If
    End Sub

    Private Sub bt_batalbeli_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        If MessageBox.Show("Tutup Form?", "Puchase Order", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    '----------------CL bt
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
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_klaim.Enter, in_discrp.Enter, in_discount.Enter, in_disc3.Enter, in_disc2.Enter, in_disc1.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_klaim.Leave, in_discrp.Leave, in_discount.Leave, in_disc3.Leave, in_disc2.Leave, in_disc1.Leave
        numericLostFocus(sender)
    End Sub

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
        keyshortenter(cb_ppn, e)
        cb_ppn.DroppedDown = True
    End Sub

    Private Sub cb_ppn_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_ppn.KeyDown
        If cb_ppn.SelectedValue = "1" Then
            keyshortenter(in_pajak, e)
        ElseIf cb_ppn.SelectedValue = "0" Then
            in_pajak.Enabled = False
            date_tgl_pajak.Enabled = False
            keyshortenter(in_barang, e)
        End If
    End Sub

    Private Sub cb_ppn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_ppn.KeyPress
        e.Handled = True
    End Sub

    Private Sub cb_ppn_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_ppn.SelectionChangeCommitted
        If cb_ppn.SelectedValue = "1" Then
            in_pajak.Enabled = True
            date_tgl_pajak.Enabled = True
        ElseIf cb_ppn.SelectedValue = "0" Then
            in_pajak.Enabled = False
            date_tgl_pajak.Enabled = False
        End If
    End Sub

    Private Sub in_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles in_pajak.KeyDown
        keyshortenter(date_tgl_pajak, e)
    End Sub

    Private Sub date_tgl_pajak_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_pajak.KeyDown
        keyshortenter(in_barang, e)
    End Sub

    '---------------input barang
    '---------------pop up list barang
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

    Private Sub dgv_listbarang_CellContentDBLClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellContentDoubleClick
        in_barang.Text = dgv_listbarang.Rows(e.RowIndex).Cells("brg_kode").Value
        setBarang(in_barang.Text)
        in_qty.Focus()
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
        End If
        keyshortenter(in_qty, e)
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

    Private Sub in_qty_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
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
        addRowBarang()
    End Sub

    Private Sub dgv_barang_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv_barang.RowsRemoved
        countbiaya()
        If dgv_barang.Rows.Count = 0 Then
            cb_ppn.Enabled = True
        End If
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
        If TabControl1.SelectedTab Is tb_beli Then
            bt_simpanbeli.PerformClick()
        End If
    End Sub

    Private Sub mn_cancelorder_Click(sender As Object, e As EventArgs) Handles mn_cancelorder.Click
        'set status pembelian to canceled (9,9)
    End Sub
End Class