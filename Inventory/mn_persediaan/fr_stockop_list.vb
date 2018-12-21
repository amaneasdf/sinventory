Public Class fr_stockop_list
    Private Structure menu_sw
        Dim sw As Boolean
        Dim txt As String
    End Structure

    Public tabpagename As TabPage
    Private rowindex As Integer = 0
    Private rowindexlist As Integer = 0
    Private rowindexbarang As Integer = 0
    Private tblStatus As String = 0
    Private popupstate As String = "gudang"
    Private _hppsys As Decimal = 0
    Private dgvallowed As Boolean = False

    'FUCKING SPAGHETTI CODE, FUCK

    Public Sub setpage(page As TabPage)
        tabpagename = page
        Console.WriteLine("pg" & page.Name.ToString)
        Console.WriteLine("pgset" & tabpagename.Name.ToString)
    End Sub

    Public Sub performRefresh(Optional pass As Boolean = False)
        With date_tgl_beli
            .MinDate = DateSerial(1990, 1, 1)
            .MaxDate = DateSerial(2100, 12, 31)
            .MinDate = selectperiode.tglawal
            .MaxDate = selectperiode.tglakhir
        End With
        in_cari.Clear()
        tblStatus = 0
        searchData("", pass)
        in_countdata.Text = dgv_list.Rows.Count
        If selectperiode.closed = True Then
            mn_tambah.Enabled = False
            mn_edit.Enabled = False
            mn_proses.Enabled = False
        End If
    End Sub

    Private Sub loadData(kode As String)
        Dim q As String = "SELECT faktur_bukti, faktur_tanggal, faktur_gudang, gudang_nama, faktur_status, faktur_ket, faktur_reg_alias, faktur_reg_date, " _
                         & "faktur_upd_date, faktur_upd_alias, faktur_proc_date, faktur_proc_alias FROM data_stok_opname " _
                         & "LEFT JOIN data_barang_gudang ON gudang_kode=faktur_gudang " _
                         & "WHERE faktur_bukti='{0}'"
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            in_kode.Text = rd.Item("faktur_bukti")
            date_tgl_beli.Value = rd.Item("faktur_tanggal")
            date_tgl_beli_r.Text = date_tgl_beli.Value.ToLongDateString
            in_gudang.Text = rd.Item("faktur_gudang")
            in_gudang_n.Text = rd.Item("gudang_nama")
            in_ket.Text = rd.Item("faktur_ket")
            tblStatus = rd.Item("faktur_status")
            txtRegAlias.Text = rd.Item("faktur_reg_alias")
            txtRegdate.Text = rd.Item("faktur_reg_date")
            Try
                txtUpdDate.Text = rd.Item("faktur_upd_date")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("faktur_upd_alias")
            Try
                txtProcDate.Text = rd.Item("faktur_proc_date")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                txtProcDate.Text = "00/00/0000 00:00:00"
            End Try
            txtProcAlias.Text = rd.Item("faktur_proc_alias")
        End If
        rd.Close()

        setStatus()
    End Sub

    Private Sub loadDataBrg(kode As String)
        Dim dt As New DataTable
        Dim q As String = "SELECT trans_barang, barang_nama, trans_qty_sys, trans_satuan, trans_qty_fisik, trans_hpp,trans_hpp_fisik " _
                          & "FROM data_stok_opname_trans LEFT JOIN data_barang_master ON trans_barang=barang_kode " _
                          & "WHERE trans_status=1 AND trans_faktur='{0}'"
        dt = getDataTablefromDB(String.Format(q, kode))
        With dgv_barang.Rows
            For Each x As DataRow In dt.Rows
                Dim y As Integer = .Add
                With .Item(y)
                    .Cells("kode").Value = x.ItemArray(0)
                    .Cells("nama").Value = x.ItemArray(1)
                    .Cells("qty_sys").Value = x.ItemArray(2)
                    .Cells("sat_sys").Value = x.ItemArray(3)
                    .Cells("qty_fis").Value = x.ItemArray(4)
                    .Cells("sat_fis").Value = x.ItemArray(3)
                    .Cells("qty_sel").Value = x.ItemArray(4) - x.ItemArray(2)
                    .Cells("hpp").Value = x.ItemArray(5)
                    .Cells("hpp_fis").Value = x.ItemArray(6)
                End With
            Next
        End With
    End Sub

    Private Sub setStatus()
        Select Case tblStatus
            Case 0
                in_status.Text = "Pending"
                mn_proses.Enabled = If(selectperiode.closed = False, True, False)
                mn_hapus.Enabled = If(selectperiode.closed = False, True, False)
                mn_edit.Enabled = If(selectperiode.closed = False, True, False)
            Case 1
                in_status.Text = "Terproses"
                'mn_proses.Enabled = False
                mn_hapus.Enabled = False
                mn_edit.Enabled = False
            Case 2
                in_status.Text = "Batal"
                mn_proses.Enabled = False
                mn_hapus.Enabled = False
                mn_edit.Enabled = False
            Case 9
                in_status.Text = "Delete"
                mn_proses.Enabled = False
                mn_edit.Enabled = False
                mn_hapus.Enabled = False
            Case Else
                Exit Sub
        End Select
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Dim autoco As New AutoCompleteStringCollection
        Select Case tipe
            Case "barang"
                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama', getSisaStock('{0}',barang_kode,'{1}') as 'SisaStok', " _
                    & "getHPPAVG(barang_kode,'{2}','{0}') as 'HPP', barang_satuan_kecil " _
                    & "FROM data_stok_awal LEFT JOIN data_barang_master ON stock_barang=barang_kode " _
                    & "WHERE stock_gudang='{1}' AND barang_nama LIKE '{3}%'"
                q = String.Format(q, selectperiode.id, in_gudang.Text, date_tgl_beli.Value.ToString("yyyy-MM-dd"), "{0}")
            Case "gudang"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang WHERE gudang_status=1 " _
                    & "AND gudang_nama LIKE '{0}%'"
            Case Else
                Exit Sub
        End Select

        dt = getDataTablefromDB(String.Format(q, param))

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 135
            .Columns(1).Width = 200
            If tipe = "barang" Then
                .Columns(2).DefaultCellStyle = dgvstyle_commathousand
                .Columns(3).DefaultCellStyle = dgvstyle_currency
                .Columns(4).Visible = False
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
                    in_qty1.Text = commaThousand(.Cells(2).Value)
                    in_sat1.Text = .Cells(4).Value
                    in_sat2.Text = in_sat1.Text
                    in_hpp.Value = .Cells(3).Value
                    _hppsys = .Cells(3).Value
                    in_qty2.Focus()
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    in_barang.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
    End Sub

    Private Sub searchData(param As String, Optional pass As Boolean = False)
        If mn_save.Enabled = True And pass = False Then
            If MessageBox.Show("Batalkan Perubahan?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            Else
                mn_save.Enabled = False
            End If
        ElseIf mn_save.Enabled = True And pass = True Then
            mn_save.Enabled = False
        End If
        clearAll()
        disableAllSwitch(True)
        mn_tambah.Text = "Baru"
        mn_tambah.Enabled = True
        mn_edit.Text = "Edit"
        mn_edit.Enabled = True
        populateDGVUserCon("stockop", param, frmstockop.dgv_list)
    End Sub

    Private Sub listToDetail()
        If mn_save.Enabled = True Then
            If MessageBox.Show("Batalkan Perubahan?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            Else
                mn_save.Enabled = True
            End If
        End If
        clearAll()
        disableAllSwitch(True)
        dgv_barang.Rows.Clear()
        Try
            Me.Cursor = Cursors.AppStarting
            loadData(dgv_list.Rows(rowindex).Cells("kode").Value)
            loadDataBrg(in_kode.Text)
        Catch ex As Exception
            Dim text As String = "Tidak dapat menampilkan data" & Environment.NewLine & ex.Message
            MessageBox.Show(text)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub textToDGV()
        If in_barang_nm.Text = Nothing Then
            in_barang.Focus()
            Exit Sub
        End If
        If in_qty2.Value = 0 Then
            in_qty2.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim check As Boolean = False
        If dgv_barang.RowCount > 0 Then
            For Each rows As DataGridViewRow In dgv_barang.Rows
                If rows.Cells("kode").Value = in_barang.Text Then
                    If MessageBox.Show("Barang yang sama sudah diinputkan ke dalam list, tambahkan qty pada barang tersebut?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        rows.Cells("qty_fis").Value += in_qty2.Value
                        rows.Cells("qty_sel").Value = rows.Cells("qty_fis").Value - rows.Cells("qty_sys").Value
                        Me.Cursor = Cursors.Default
                        clearInputBarang()
                        check = True
                        Exit For
                    Else
                        check = True
                        Exit For
                    End If
                Else
                    Exit For
                End If
            Next
        End If

        If check = False Then
            With dgv_barang.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("kode").Value = in_barang.Text
                    .Cells("nama").Value = in_barang_nm.Text
                    .Cells("qty_sys").Value = CDbl(in_qty1.Text)
                    .Cells("sat_sys").Value = in_sat1.Text
                    .Cells("qty_fis").Value = in_qty2.Value
                    .Cells("sat_fis").Value = in_sat2.Text
                    .Cells("qty_sel").Value = in_qty2.Value - CDbl(in_qty1.Text)
                    .Cells("hpp").Value = _hppsys
                    .Cells("hpp_fis").Value = in_hpp.Value
                End With
            End With
            clearInputBarang()
        End If

        in_gudang_n.ReadOnly = True
        Me.Cursor = Cursors.Default

        in_barang.Focus()
    End Sub

    Private Sub dgvToTxt()
        With dgv_barang.SelectedRows.Item(0)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty1.Text = .Cells("qty_sys").Value
            in_sat1.Text = .Cells("sat_sys").Value
            _hppsys = .Cells("hpp").Value
            in_qty2.Value = .Cells("qty_fis").Value
            in_sat2.Text = .Cells("sat_fis").Value
            in_hpp.Value = .Cells("hpp_fis").Value
        End With
        in_barang.Focus()
        If dgv_barang.RowCount = 0 Then
            in_gudang_n.ReadOnly = False
        Else
            in_gudang_n.ReadOnly = True
        End If
    End Sub

    'SAVE DATA
    Private Sub saveData(tipe As String)
        Dim querycheck As String = False
        Dim queryArr As New List(Of String)
        Dim datafaktur, dataBrg As String()
        Dim data, data2 As String()
        Dim q As String = ""
        Dim q2 As String = "INSERT INTO data_stok_opname_trans SET trans_faktur='{0}',{1} ON DUPLICATE KEY UPDATE {1}"
        Dim q3 As String = "DELETE FROM data_stok_opname_trans WHERE trans_faktur='{0}' AND trans_barang NOT IN({1})"

        Me.Cursor = Cursors.WaitCursor

        op_con()

        Select Case tipe
            Case "save"
                'GENERATE KODE
                If in_kode.Text = Nothing Then
                    Dim st As Integer = 1
                    readcommd("SELECT RIGHT(faktur_bukti,3) FROM data_stok_opname WHERE SUBSTRING(faktur_bukti,3,8)='" & date_tgl_beli.Value.ToString("yyyyMMdd") & "' " _
                               & "AND faktur_bukti LIKE 'OP%' ORDER BY faktur_bukti DESC LIMIT 1")
                    If rd.HasRows Then
                        st = CInt(rd.Item(0)) + 1
                    End If
                    rd.Close()
                    in_kode.Text = "OP" & date_tgl_beli.Value.ToString("yyyyMMdd") & st.ToString("D3")
                ElseIf in_kode.Text <> Nothing And mn_tambah.Text = "Batal" Then
                    If checkdata("data_stok_opname", "'" & in_kode.Text & "'", "faktur_bukti") = True Then
                        MessageBox.Show("Nomor faktur " & in_kode.Text & " sudah pernah diinputkan", "Stok Opname", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        in_kode.Focus()
                        Exit Sub
                        'If MessageBox.Show("Update data faktur " & in_faktur.Text & "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                        '    Exit Sub
                        'End If
                    End If
                End If
            Case "proc"
                tblStatus = 1
                setStatus()
            Case Else
                Exit Sub
        End Select

        Dim _tgltrans As String = date_tgl_beli.Value.ToString("yyyy-MM-dd")

        '==========================================================================================================================
        'INSERT HEADER
        datafaktur = {
                "faktur_tanggal='" & _tgltrans & "'",
                "faktur_gudang='" & in_gudang.Text & "'",
                "faktur_ket='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
                "faktur_status='" & tblStatus & "'"
                }
        q = "INSERT INTO data_stok_opname SET faktur_bukti='{0}',{1},faktur_reg_date=NOW(), faktur_reg_alias='{2}' " _
            & "ON DUPLICATE KEY UPDATE {1},faktur_upd_date=NOW(),faktur_upd_alias='{2}'"
        queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", datafaktur), loggeduser.user_id))
        '==========================================================================================================================

        '==========================================================================================================================
        'INSERT BARANG
        Dim x As New List(Of String)
        Dim qty As New List(Of Integer)
        Dim nilai As New List(Of Decimal)

        '==========================================================================================================================
        q = "UPDATE data_stok_opname_trans SET trans_status=9 WHERE trans_faktur='{0}'"
        queryArr.Add(String.Format(q, in_kode.Text))

        q = "UPDATE data_stok_kartustok SET trans_status=9 WHERE trans_faktur='{0}'"
        queryArr.Add(String.Format(q, in_kode.Text))
        '==========================================================================================================================

        '==========================================================================================================================
        For Each rows As DataGridViewRow In dgv_barang.Rows
            Dim _hppsys As Decimal = rows.Cells("hpp").Value
            Dim _hppfis As Decimal = rows.Cells("hpp_fis").Value
            Dim _qtySel As Integer = rows.Cells("qty_sel").Value
            Dim _nilaiSel As Decimal = _qtySel * IIf(_qtySel < 0, _hppsys, _hppfis)

            dataBrg = {
                "trans_barang='" & rows.Cells(0).Value & "'",
                "trans_qty_sys=" & rows.Cells("qty_sys").Value,
                "trans_qty_fisik=" & rows.Cells("qty_fis").Value,
                "trans_satuan='" & rows.Cells("sat_sys").Value & "'",
                "trans_hpp=" & _hppsys.ToString.Replace(",", "."),
                "trans_hpp_fisik=" & _hppfis.ToString.Replace(",", "."),
                "trans_status=1"
                }
            q = "INSERT INTO data_stok_opname_trans SET trans_faktur='{0}',{1} ON DUPLICATE KEY UPDATE {1}"
            queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", dataBrg)))

            x.Add("'" & rows.Cells(0).Value & "'")
            qty.Add(_qtySel)
            nilai.Add(_nilaiSel)
        Next
        '==========================================================================================================================

        '==========================================================================================================================
        'TODO : WRITE KARTU STOCK
        Dim q5 As String = "INSERT INTO data_stok_kartustok({0}) SELECT {1} FROM data_stok_kartustok WHERE trans_stock='{2}' ON DUPLICATE KEY UPDATE {3}"
        'Dim x_kodestok = New List(Of String)
        data = {
            "trans_stock", "trans_index", "trans_jenis", "trans_faktur", "trans_tgl", "trans_periode",
            "trans_ket", "trans_qty", "trans_nilai", "trans_reg_alias", "trans_reg_date", "trans_status"
            }
        Dim i As Integer = 0
        For Each brg As String In x
            If qty.Item(i) <> 0 Then

                Dim kd As String = in_gudang.Text & "-" & Replace(brg, "'", "")

                data2 = {
                         "'" & kd & "'",
                         "MAX(trans_index)+1",
                         "'op'",
                         "'" & in_kode.Text & "'",
                         "'" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                         "'" & selectperiode.id & "'",
                         "'STOK OPNAME " & in_gudang_n.Text & "'",
                         qty.Item(i),
                         nilai.Item(i).ToString.Replace(",", "."),
                         "'" & loggeduser.user_id & "'",
                         "NOW()",
                         tblStatus
                         }
                dataBrg = {
                    "trans_tgl='" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "'",
                    "trans_periode='" & selectperiode.id & "'",
                    "trans_qty=" & qty.Item(i),
                    "trans_nilai=" & nilai.Item(i).ToString.Replace(",", "."),
                    "trans_upd_date=NOW()",
                    "trans_upd_alias='" & loggeduser.user_id & "'",
                    "trans_status=" & tblStatus
                    }
                queryArr.Add(String.Format(q5, String.Join(",", data), String.Join(",", data2), kd, String.Join(",", dataBrg)))

                'x_kodestok.Add("'" & kd & "'")
            End If
            i += 1
        Next
        '==========================================================================================================================
        '==========================================================================================================================

        '==========================================================================================================================
        'INPUT JURNAL AND UPDATE PROC
        '----------HEAD
        If tipe = "proc" Then
            q = "INSERT INTO data_jurnal_line SET line_kode='{0}', line_type='MGOPN',{1},line_reg_date=NOW(),line_reg_alias='{2}' " _
            & "ON DUPLICATE KEY UPDATE {1},line_upd_date=NOW(),line_upd_alias='{2}'"
            data2 = {
                "line_ref='" & in_gudang.Text & "'",
                "line_ref_type='GUDANG'",
                "line_tanggal='" & _tgltrans & "'",
                "line_status='1'"
                }
            queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", data2), loggeduser.user_id))

            q = "UPDATE data_stok_opname SET faktur_proc_date=NOW(),faktur_proc_alias='{0}' WHERE faktur_bukti='{1}'"
            queryArr.Add(String.Format(q, txtProcAlias.Text, in_kode.Text))
        End If
        '==========================================================================================================================


        '==========================================================================================================================
        'BEGIN TRANSACTION
        querycheck = startTrans(queryArr)
        '==========================================================================================================================

        Me.Cursor = Cursors.Default

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Exit Sub
        Else
            'TODO: WRITE LOG AKTIVITAS

            MessageBox.Show("Data tersimpan")
            Dim _kode As String = in_kode.Text
            performRefresh(True)
            loadData(_kode)
            loadDataBrg(_kode)
        End If
    End Sub

    'Cancel Data
    Private Sub cancelData()
        Dim q As String = ""
        Dim queryArr As New List(Of String)
        Dim queryCk As Boolean = False
        Dim _confrm As Boolean = False

        If tblStatus = 0 Then
            Using vlid As New fr_stockopconfirm_dialog
                With vlid
                    .lbl_title.Text = "Konfirmasi Pembatalan"
                    .Text = "Stok Opname"
                    .in_user.Text = loggeduser.user_id
                    .in_user.ReadOnly = True
                    .ShowDialog()
                    _confrm = .returnval
                End With
            End Using

            If _confrm = False Then
                Exit Sub
            End If

            q = "UPDATE data_stok_opname SET faktur_status=2, faktur_upd_date=NOW(), faktur_upd_alias='{1}' WHERE faktur_bukti='{0}'"
            queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id))

            q = "UPDATE data_stok_kartustok SET trans_status=9, trans_upd_date=NOW(), trans_upd_alias='{1}' WHERE trans_faktur='{0}'"
            queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id))

            q = "UPDATE data_jurnal_line SET line_status=9, line_upd_date=NOW(), line_upd_alias='{1}' WHERE line_kode='{0}'"
            queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id))

            queryCk = startTrans(queryArr)

            If queryCk Then
                MessageBox.Show("Transaksi Dibatalkan")
                performRefresh()
            Else
                MessageBox.Show("Error. Transaksi gagal dibatalkan")
            End If
        End If
    End Sub

    'CLEAR
    Private Sub clearTextBarang()
        'For Each x As NumericUpDown In {in_qty2}
        '    x.Value = 0
        'Next
        For Each x As TextBox In {in_barang, in_sat1, in_sat2, in_qty1}
            x.Clear()
        Next
        in_hpp.Value = 0
    End Sub

    Private Sub clearInputBarang()
        clearTextBarang()
        in_barang_nm.Clear()
        in_qty2.Value = 0
    End Sub

    Private Sub clearAll()
        If selectperiode.tglakhir >= Today Then
            date_tgl_beli.Value = Today
        Else
            date_tgl_beli.Value = selectperiode.tglakhir
        End If
        For Each x As TextBox In {in_kode, in_barang, in_barang_nm, in_sat1, in_sat2, txtRegAlias, txtRegdate, txtUpdAlias, txtUpdDate,
                                  txtProcAlias, txtProcDate, in_gudang, in_gudang_n, date_tgl_beli_r, in_ket, in_qty1, in_status}
            x.Clear()
        Next
        For Each x As NumericUpDown In {in_qty2, in_hpp}
            x.Value = 0
        Next
        _hppsys = 0
        dgv_barang.Rows.Clear()
    End Sub

    Private Sub disableAllSwitch(switch As Boolean)
        For Each x As TextBox In {in_barang_nm, in_ket, in_gudang_n}
            x.ReadOnly = switch
        Next
        For Each x As NumericUpDown In {in_qty2}
            x.ReadOnly = switch
        Next
        For Each x As Button In {bt_tbbarang}
            If switch = True Then
                x.Enabled = False
            Else
                x.Enabled = True
            End If
        Next
        If switch = True Then
            date_tgl_beli.Visible = False
            dgvallowed = False
            'dgv_barang.Enabled = False
        Else
            date_tgl_beli.Visible = True
            dgvallowed = True
            'dgv_barang.Enabled = True
        End If

        date_tgl_beli_r.Visible = switch

        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub

    '----------------- close
    Private Sub bt_close_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_close_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        clearAll()
        disableAllSwitch(True)
        mn_save.Enabled = False
        mn_tambah.Text = "Baru"
        mn_tambah.Enabled = True
        mn_edit.Text = "Edit"
        mn_edit.Enabled = True
        main.tabcontrol.TabPages.Remove(tabpagename)
        rowindex = 0
    End Sub

    '----------------- menu
    Private Sub mn_tambah_Click(sender As Object, e As EventArgs) Handles mn_tambah.Click
        'loadCBGudang()

        If mn_tambah.Text = "Baru" Then
            clearAll()
            disableAllSwitch(False)
            mn_save.Enabled = True
            mn_edit.Enabled = False
            mn_proses.Enabled = False
            in_gudang.Focus()
            mn_tambah.Text = "Batal"
        Else
            If MessageBox.Show("Batalkan Perubahan?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            Else
                performRefresh(True)
            End If
        End If
    End Sub

    Private Sub mn_edit_Click(sender As Object, e As EventArgs) Handles mn_edit.Click
        If mn_edit.Text = "Edit" And in_kode.Text <> Nothing Then
            'in_kode.Text = dgv_list.Rows(rowindex).Cells("kode").Value
            Try
                loadData(in_kode.Text)
                dgv_barang.Rows.Clear()
                loadDataBrg(in_kode.Text)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            disableAllSwitch(False)
            in_gudang.Focus()
            sender.Text = "Batal Edit"
            mn_tambah.Enabled = False
            mn_proses.Enabled = False
            mn_save.Enabled = True
        ElseIf mn_edit.Text = "Batal Edit" Then
            If MessageBox.Show("Batalkan Perubahan?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            Else
                Dim kode As String = in_kode.Text
                performRefresh(True)
                loadData(kode)
                loadDataBrg(kode)
            End If
        End If
    End Sub

    Private Sub mn_hapus_Click(sender As Object, e As EventArgs) Handles mn_hapus.Click
        If in_kode.Text <> Nothing And tblStatus = 0 Then
            If MessageBox.Show("Batalkan transaksi Stock Opname?", "Stock Opname", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                cancelData()
            End If
        End If
    End Sub

    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
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

        If MessageBox.Show("Simpan Data?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            saveData("save")
        End If
    End Sub

    Private Sub mn_proses_Click(sender As Object, e As EventArgs) Handles mn_proses.Click
        Dim _konfirm As Boolean = False
        If Trim(in_kode.Text) <> Nothing Then
            If MessageBox.Show("Proses Stock Opname No." & in_kode.Text & "?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Using x As New fr_stockopconfirm_dialog
                    With x
                        .do_load("opname")
                        .ShowDialog()
                        _konfirm = .returnval
                        If .returnval = True Then
                            in_ket.Text += IIf(in_ket.Text = Nothing, "", Environment.NewLine) & .in_ket.Text
                            txtProcAlias.Text = .in_user.Text
                        Else
                            Exit Sub
                        End If
                    End With
                End Using

                If _konfirm = False Then Exit Sub

                saveData("proc")
            End If
        End If
    End Sub

    Private Sub mn_refresh_Click(sender As Object, e As EventArgs) Handles mn_refresh.Click
        performRefresh()
    End Sub

    Private Sub mn_cari_Click(sender As Object, e As EventArgs) Handles mn_cari.Click
        in_cari.Focus()
    End Sub

    '==========================================================================================================================
    'LOAD
    Private Sub fr_stockop_list_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each x As DataGridViewColumn In {hpp, hpp_fis}
            x.DefaultCellStyle = dgvstyle_currency
        Next
        performRefresh()
    End Sub
    '==========================================================================================================================

    '==========================================================================================================================
    'cari
    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If dgv_list.Visible = False Then
                dgv_list.Visible = True
            End If
            searchData(in_cari.Text)
        End If
    End Sub
    '==========================================================================================================================

    '==========================================================================================================================
    'dgv list
    Private Sub dgv_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellClick
        If e.RowIndex >= 0 Then
            rowindex = e.RowIndex
            listToDetail()
        End If
    End Sub

    Private Sub dgv_list_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.RowEnter
        If e.RowIndex >= 0 Then
            rowindex = e.RowIndex
        End If
    End Sub

    Private Sub dgv_list_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_list.KeyDown
        If e.KeyCode = Keys.Enter And rowindex >= 0 Then
            listToDetail()
        End If
    End Sub
    '==========================================================================================================================

    '==========================================================================================================================
    'input
    'numeric input
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty2.Enter, in_hpp.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty2.Leave, in_hpp.Leave
        numericLostFocus(sender, IIf(sender.Name = "in_hpp", "N2", "N0"))
    End Sub
    '==========================================================================================================================

    '==========================================================================================================================
    'HEADR
    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(date_tgl_beli, e)
    End Sub

    Private Sub date_tgl_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyDown
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub date_tgl_beli_ValueChanged(sender As Object, e As EventArgs) Handles date_tgl_beli.ValueChanged
        date_tgl_beli_r.Text = date_tgl_beli.Value.ToLongDateString
    End Sub
    '==========================================================================================================================

    '==========================================================================================================================
    '------------- POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_gudang_n.Focused Or in_barang_nm.Focused Then
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
    '==========================================================================================================================

    '==========================================================================================================================
    'gudang awal
    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_gudang_n_Enter(sender As Object, e As EventArgs) Handles in_gudang_n.Enter
        If mn_save.Enabled = True Then
            popPnl_barang.Location = New Point(in_gudang_n.Left, in_gudang_n.Top + in_gudang_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            popupstate = "gudang"
            loadDataBRGPopup("gudang", in_gudang_n.Text)
        End If
    End Sub

    Private Sub in_gudang_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(in_barang_nm, e)
        ElseIf e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            End If
        Else
            If popPnl_barang.Visible = False And in_gudang_n.ReadOnly = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("gudang", in_gudang_n.Text)
        End If
    End Sub

    Private Sub in_sales_n_MouseClick(sender As Object, e As MouseEventArgs) Handles in_gudang_n.MouseClick, in_barang_nm.MouseClick
        If popPnl_barang.Visible = False And sender.ReadOnly = False Then
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_gudang_n_TextChanged(sender As Object, e As EventArgs) Handles in_gudang_n.TextChanged
        If in_gudang_n.Text = "" Then
            in_gudang.Clear()
            clearInputBarang()
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_gudang_n.Leave, in_barang_nm.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub
    '==========================================================================================================================

    '==========================================================================================================================
    '---------------input barang
    Private Sub in_barang_Enter(sender As Object, e As EventArgs) Handles in_barang_nm.Enter
        If mn_save.Enabled = True Then
            popPnl_barang.Location = New Point(in_barang_nm.Left, in_barang_nm.Top + in_barang_nm.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
                popupstate = "barang"
                loadDataBRGPopup("barang", in_barang_nm.Text)
            End If
        End If
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
            keyshortenter(in_qty2, e)
        ElseIf e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            End If
        Else
            If popPnl_barang.Visible = False And in_barang_nm.ReadOnly = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("barang", in_barang_nm.Text)
        End If
    End Sub

    Private Sub in_barang_nm_TextChanged(sender As Object, e As EventArgs) Handles in_barang_nm.TextChanged
        If in_barang_nm.Text = "" Then
            clearTextBarang()
        End If
    End Sub

    Private Sub in_qty2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty2.KeyDown
        keyshortenter(in_hpp, e)
    End Sub

    Private Sub in_hpp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_hpp.KeyDown
        keyshortenter(bt_tbbarang, e)
    End Sub
    '==========================================================================================================================

    '==========================================================================================================================
    'dgv barang
    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        textToDGV()
    End Sub

    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        If dgvallowed = True Then
            If e.RowIndex >= 0 Then
                rowindexbarang = e.RowIndex
                dgvToTxt()
                dgv_barang.Rows.RemoveAt(rowindexbarang)
            End If
        End If
    End Sub
    '==========================================================================================================================

    Private Sub fr_stok_mutasi_list_Click(sender As Object, e As EventArgs) Handles Me.Click, pnl_container.Click, pnl_side.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_sidepnl_sw.Click
        With dgv_list
            If .Visible = False Then
                .Visible = True
            Else
                .Visible = False
            End If
        End With
    End Sub
End Class
