Public Class fr_stok_mutasi_list
    Public tabpagename As TabPage
    Private rowindex As Integer = 0
    Private rowindexlist As Integer = 0
    Private rowindexbarang As Integer = 0
    Private isisat_t As Integer = 0
    Private isisat_b As Integer = 0
    Private tblstatus As String = ""
    Private popupstate As String = "barang"
    Private selectedgudang As String = ""
    Private _hppbrg As Decimal = 0

    Public Sub setpage(page As TabPage)
        tabpagename = page
        Console.WriteLine("pg" & page.Name.ToString)
        Console.WriteLine("pgset" & tabpagename.Name.ToString)
    End Sub

    Public Sub performRefresh()
        With date_tgl_beli
            .MinDate = DateSerial(1990, 1, 1)
            .MaxDate = DateSerial(2100, 12, 31)
            .MaxDate = selectperiode.tglakhir
            .MinDate = selectperiode.tglawal
            If selectperiode.tglakhir >= Today Then
                .Value = Today
            Else
                .Value = selectperiode.tglakhir
            End If
        End With
        in_cari.Clear()
        searchData("")
        in_countdata.Text = dgv_list.Rows.Count
        If selectperiode.closed = True Then
            mn_tambah.Enabled = False
            mn_edit.Enabled = False
        End If
    End Sub

    Private Sub loadData(kode As String)
        Dim q As String = "SELECT faktur_kode, faktur_tanggal, faktur_gudang_asal, a.gudang_nama as gudang_asal, faktur_gudang_tujuan, " _
                          & "b.gudang_nama as gudang_tujuan, faktur_reg_alias, faktur_reg_date, faktur_upd_alias, faktur_upd_date " _
                          & "FROM data_barang_stok_mutasi LEFT JOIN data_barang_gudang a ON faktur_gudang_asal=a.gudang_kode " _
                          & "LEFT JOIN data_barang_gudang b ON faktur_gudang_tujuan=b.gudang_kode " _
                          & "WHERE faktur_kode='{0}'"
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            in_kode.Text = rd.Item("faktur_kode")
            date_tgl_beli.Value = rd.Item("faktur_tanggal")
            date_tgl_beli_r.Text = date_tgl_beli.Value.ToLongDateString
            in_gudang.Text = rd.Item("faktur_gudang_asal")
            in_gudang_n.Text = rd.Item("gudang_asal")
            in_gudang2.Text = rd.Item("faktur_gudang_tujuan")
            in_gudang2_n.Text = rd.Item("gudang_tujuan")
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

    Private Sub loadBrg(kode As String)
        Dim dt As New DataTable
        Dim q As String = "SELECT trans_barang, barang_nama, trans_qty_besar, barang_satuan_besar, trans_qty_tengah, " _
                          & "barang_satuan_tengah, trans_qty_kecil, barang_satuan_kecil, trans_qty_tot,trans_hpp " _
                          & "FROM data_barang_stok_mutasi_trans LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                          & "WHERE trans_faktur='{0}' AND trans_status=1"
        dt = getDataTablefromDB(String.Format(q, kode))
        With dgv_barang.Rows
            For Each x As DataRow In dt.Rows
                Dim y As Integer = .Add
                With .Item(y)
                    .Cells("kode").Value = x.ItemArray(0)
                    .Cells("nama").Value = x.ItemArray(1)
                    .Cells("qty_b").Value = x.ItemArray(2)
                    .Cells("sat_b").Value = x.ItemArray(3)
                    .Cells("qty_t").Value = x.ItemArray(4)
                    .Cells("sat_t").Value = x.ItemArray(5)
                    .Cells("qty_k").Value = x.ItemArray(6)
                    .Cells("sat_k").Value = x.ItemArray(7)
                    .Cells("qty_tot").Value = x.ItemArray(8)
                    .Cells("hpp_brg").Value = x.ItemArray(9)
                End With
            Next
        End With
    End Sub


    Private Sub setStatus()
        Select Case tblStatus
            Case 0
                'in_status.Text = "Non-Aktif"
            Case 1
                'in_status.Text = "Aktif"
            Case 9
                'in_status.Text = "Delete"
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
                q = "SELECT barang_kode AS 'Kode', barang_nama AS 'Nama', " _
                    & "getHPPAVG(barang_kode,'" & date_tgl_beli.Value.ToString("yyyy-MM-dd") & "','" & selectperiode.id & "') as 'HPP', barang_satuan_besar, " _
                    & "barang_satuan_besar_jumlah, barang_satuan_tengah, barang_satuan_tengah_jumlah, barang_satuan_kecil " _
                    & "FROM data_stok_awal LEFT JOIN data_barang_master ON stock_barang=barang_kode " _
                    & "WHERE stock_status=1 AND stock_gudang='" & in_gudang.Text & "' " _
                    & "AND barang_nama LIKE '{0}%'"
            Case "gudang2"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang WHERE gudang_status=1 " _
                    & "AND gudang_nama LIKE '{0}%' AND gudang_kode<>'" & in_gudang.Text & "'"
            Case "gudang"
                q = "SELECT gudang_kode AS 'Kode', gudang_nama AS 'Nama' FROM data_barang_gudang WHERE gudang_status=1 " _
                    & "AND gudang_nama LIKE '{0}%' AND gudang_kode<>'" & in_gudang2.Text & "'"
            Case Else
                Exit Sub
        End Select

        dt = getDataTablefromDB(String.Format(q, param))

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 135
            .Columns(1).Width = 200
            If tipe = "barang" Then
                .Columns(2).DefaultCellStyle = dgvstyle_currency
                For i = 3 To 7
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
                    in_sat1.Text = .Cells(3).Value
                    isisat_b = .Cells(4).Value
                    in_sat2.Text = .Cells(5).Value
                    isisat_t = .Cells(6).Value
                    in_sat3.Text = .Cells(7).Value
                    _hppbrg = .Cells(2).Value
                    in_hpp.Text = commaThousand(_hppbrg)
                    in_qty1.Focus()
                Case "gudang2"
                    in_gudang2.Text = .Cells(0).Value
                    in_gudang2_n.Text = .Cells(1).Value
                    in_barang_nm.Focus()
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    in_gudang2_n.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
    End Sub

    Private Sub searchData(param As String)
        If mn_save.Enabled = True Then
            If MessageBox.Show("Batalkan Perubahan?", "Mutasi Gudang", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            Else
                mn_save.Enabled = False
            End If
        End If
        clearAll()
        disableAllSwitch(True)
        mn_tambah.Text = "Baru"
        mn_tambah.Enabled = True
        mn_edit.Text = "Edit"
        mn_edit.Enabled = True
        populateDGVUserCon("mutasigudang", param, frmmutasigudang.dgv_list)
    End Sub

    Private Sub listToDetail()
        If mn_save.Enabled = True Then
            If MessageBox.Show("Batalkan Perubahan?", "Mutasi Gudang", MessageBoxButtons.YesNo) = DialogResult.No Then
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
            loadBrg(in_kode.Text)
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

        Dim qtytot As Integer = 0
        qtytot = in_qty1.Value * isisat_b * isisat_t + in_qty2.Value * isisat_t + in_qty3.Value
        If qtytot = 0 Then
            in_qty1.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim check As Boolean = False
        If dgv_barang.RowCount > 0 Then
            For Each rows As DataGridViewRow In dgv_barang.Rows
                If rows.Cells("kode").Value = in_barang.Text Then
                    If MessageBox.Show("Barang yang sama sudah diinputkan ke dalam list, tambahkan qty pada barang tersebut?", "Mutasi Antar Gudang", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        rows.Cells("qty_b").Value += in_qty1.Value
                        rows.Cells("qty_t").Value += in_qty2.Value
                        rows.Cells("qty_k").Value += in_qty3.Value
                        rows.Cells("qty_tot").Value += qtytot
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
                    .Cells("qty_b").Value = in_qty1.Value
                    .Cells("sat_b").Value = in_sat1.Text
                    .Cells("qty_t").Value = in_qty2.Value
                    .Cells("sat_t").Value = in_sat2.Text
                    .Cells("qty_k").Value = in_qty3.Value
                    .Cells("sat_k").Value = in_sat3.Text
                    .Cells("qty_tot").Value = qtytot
                    .Cells("hpp_brg").Value = _hppbrg
                End With
            End With
            clearInputBarang()
        End If

        in_gudang_n.ReadOnly = True
        Me.Cursor = Cursors.Default

        'in_barang_nm.Focus()
    End Sub

    Private Sub dgvToTxt()
        With dgv_barang.SelectedRows.Item(0)
            in_barang.Text = .Cells("kode").Value
            in_barang_nm.Text = .Cells("nama").Value
            in_qty1.Value = .Cells("qty_b").Value
            in_sat1.Text = .Cells("sat_b").Value
            in_qty2.Value = .Cells("qty_t").Value
            in_sat2.Text = .Cells("sat_t").Value
            in_qty3.Value = .Cells("qty_k").Value
            in_sat3.Text = .Cells("sat_k").Value
            _hppbrg = .Cells("hpp_brg").Value
            in_hpp.Text = commaThousand(_hppbrg)
        End With
        'in_barang.Focus()
    End Sub

    Private Sub saveData()
        Dim querycheck As String = False
        Dim queryArr As New List(Of String)
        Dim datafaktur, dataBrg As String()
        Dim data, data2 As String()
        Dim q As String = ""

        Dim _tgltrans As String = date_tgl_beli.Value.ToString("yyyy-MM-dd")

        Me.Cursor = Cursors.WaitCursor

        op_con()
        'GENERATE KODE
        If in_kode.Text = Nothing Then
            Dim no As Integer = 1
            Dim tgl As String = date_tgl_beli.Value.ToString("yyyyMMdd")

            readcommd("SELECT RIGHT(faktur_kode,3) FROM data_barang_stok_mutasi WHERE SUBSTRING(faktur_kode,3,8)='" & tgl & "'" _
                      & "AND faktur_kode LIKE 'MG%' ORDER BY faktur_kode DESC LIMIT 1")
            If rd.HasRows Then
                no = CInt(rd.Item(0)) + 1
            End If
            rd.Close()
            in_kode.Text = "MG" & tgl & no.ToString("D3")
        ElseIf in_kode.Text <> Nothing And mn_tambah.Text = "Batal" Then
            If checkdata("data_barang_stok_mutasi", "'" & in_kode.Text & "'", "faktur_kode") = True Then
                MessageBox.Show("Nomor faktur " & in_kode.Text & " sudah pernnah diinputkan", "Mutasi Antar Gudang", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                in_kode.Focus()
                Exit Sub
                'If MessageBox.Show("Update data faktur " & in_faktur.Text & "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                '    Exit Sub
                'End If
            End If
        End If

        '==========================================================================================================================
        'INSERT HEADER
        datafaktur = {
                "faktur_tanggal='" & _tgltrans & "'",
                "faktur_gudang_asal='" & in_gudang.Text & "'",
                "faktur_gudang_tujuan='" & in_gudang2.Text & "'",
                "faktur_status='1'"
                }
        q = "INSERT INTO data_barang_stok_mutasi SET faktur_kode='{0}',{1},faktur_reg_date=NOW(),faktur_reg_alias='{2}' ON DUPLICATE KEY UPDATE {1},faktur_upd_date=NOW()," _
            & "faktur_upd_alias='{2}'"
        queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", datafaktur), loggeduser.user_id))
        '==========================================================================================================================


        '==========================================================================================================================
        'INSERT BARANG
        Dim x As New List(Of String)
        Dim qty As New List(Of Integer)
        Dim nilai As New List(Of Decimal)

        '==========================================================================================================================
        q = "UPDATE data_barang_stok_mutasi_trans SET trans_status=9 WHERE trans_faktur='{0}'"
        queryArr.Add(String.Format(q, in_kode.Text))

        q = "UPDATE data_stok_kartustok SET trans_status=9 WHERE trans_faktur='{0}'"
        queryArr.Add(String.Format(q, in_kode.Text))
        '==========================================================================================================================

        '==========================================================================================================================
        For Each rows As DataGridViewRow In dgv_barang.Rows
            Dim _qtytot As Integer = rows.Cells("qty_tot").Value
            Dim _hpp As Decimal = rows.Cells("hpp_brg").Value
            dataBrg = {
                "trans_barang='" & rows.Cells(0).Value & "'",
                "trans_qty_besar=" & rows.Cells("qty_b").Value,
                "trans_qty_tengah=" & rows.Cells("qty_t").Value,
                "trans_qty_kecil=" & rows.Cells("qty_k").Value,
                "trans_qty_tot=" & _qtytot,
                "trans_satuan_besar='" & rows.Cells("sat_b").Value & "'",
                "trans_satuan_tengah='" & rows.Cells("sat_t").Value & "'",
                "trans_satuan_kecil='" & rows.Cells("sat_k").Value & "'",
                "trans_hpp=" & _hpp.ToString.Replace(",", "."),
                "trans_status='1'"
                }
            q = "INSERT INTO data_barang_stok_mutasi_trans SET trans_faktur='{0}',{1} ON DUPLICATE KEY UPDATE {1}"
            queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", dataBrg)))

            x.Add("'" & rows.Cells(0).Value & "'")
            qty.Add(_qtytot)
            nilai.Add(_qtytot * _hpp)
            consoleWriteLine(_qtytot & "-" & _hpp)
        Next
        '==========================================================================================================================

        '==========================================================================================================================
        'WRITE KARTU STOK
        Dim x_kodestock As New List(Of String)
        Dim q4 As String = "SELECT stock_kode FROM data_stok_awal WHERE stock_gudang='{0}' AND stock_barang={1} AND stock_periode='{2}'"
        Dim q5 As String = "INSERT INTO data_stok_kartustok({0}) SELECT {1} FROM data_stok_kartustok WHERE trans_stock='{2}' ON DUPLICATE KEY UPDATE {3}"
        data = Nothing
        data = {
            "trans_stock", "trans_index", "trans_jenis", "trans_faktur", "trans_tgl", "trans_periode",
            "trans_ket", "trans_qty", "trans_nilai", "trans_reg_alias", "trans_reg_date", "trans_status"
            }
        Dim i As Integer = 0

        For Each brg As String In x
            Dim kd, kd2 As String
            consoleWriteLine(nilai.Item(i))

            'ASAL
            kd = in_gudang.Text & "-" & Replace(brg, "'", "")
            data2 = {
                "'" & kd & "'",
                "MAX(trans_index)+1",
                "'mg'",
                "'" & in_kode.Text & "'",
                "'" & _tgltrans & "'",
                "'" & selectperiode.id & "'",
                "'" & in_gudang_n.Text & " -> " & in_gudang2_n.Text & "'",
                qty.Item(i) * -1,
                (nilai.Item(i) * -1).ToString.Replace(",", "."),
                "'" & loggeduser.user_id & "'",
                "NOW()",
                "1"
                }
            dataBrg = {
                "trans_ket='" & in_gudang_n.Text & " -> " & in_gudang2_n.Text & "'",
                "trans_tgl='" & _tgltrans & "'",
                "trans_periode='" & selectperiode.id & "'",
                "trans_qty=" & qty.Item(i) * -1,
                "trans_nilai=" & (nilai.Item(i) * -1).ToString.Replace(",", "."),
                "trans_upd_date=NOW()",
                "trans_upd_alias='" & loggeduser.user_id & "'",
                "trans_status=1"
                }
            queryArr.Add(String.Format(q5, String.Join(",", data), String.Join(",", data2), kd, String.Join(",", dataBrg)))

            'TUJUAN
            kd2 = in_gudang2.Text & "-" & Replace(brg, "'", "")
            'CREATE SALDO AWAL
            data2 = {
                "'" & kd2 & "'", 0, "'sa'",
                "''", "'" & selectperiode.tglawal.ToString("yyyy-MM-dd") & "'",
                "'" & selectperiode.id & "'", "'SALDO AWAL PERIODE'",
                0, 0,
                "'" & loggeduser.user_id & "'", "NOW()", "1"
                }
            dataBrg = {
                "trans_id=trans_id"
                }
            queryArr.Add(String.Format(q5, String.Join(",", data), String.Join(",", data2), kd2, String.Join(",", dataBrg)))

            'DONE : TODO : WRITE KARTU STOK TUJUAN
            data2 = {
                "'" & kd2 & "'",
                "MAX(trans_index)+1",
                "'mg'",
                "'" & in_kode.Text & "'",
                "'" & _tgltrans & "'",
                "'" & selectperiode.id & "'",
                "'" & in_gudang_n.Text & " -> " & in_gudang2_n.Text & "'",
                qty.Item(i),
                nilai.Item(i).ToString.Replace(",", "."),
                "'" & loggeduser.user_id & "'",
                "NOW()",
                "1"
                }
            dataBrg = {
                "trans_ket='" & in_gudang_n.Text & " -> " & in_gudang2_n.Text & "'",
                "trans_tgl='" & _tgltrans & "'",
                "trans_periode='" & selectperiode.id & "'",
                "trans_qty=" & qty.Item(i),
                "trans_nilai=" & nilai.Item(i).ToString.Replace(",", "."),
                "trans_upd_date=NOW()",
                "trans_upd_alias='" & loggeduser.user_id & "'",
                "trans_status=1"
                }
            queryArr.Add(String.Format(q5, String.Join(",", data), String.Join(",", data2), kd2, String.Join(",", dataBrg)))

            i += 1
        Next
        '==========================================================================================================================
        '==========================================================================================================================

        '==========================================================================================================================
        'INPUT JURNAL
        '----------HEAD
        q = "INSERT INTO data_jurnal_line SET line_kode='{0}', line_type='MTGOUT',{1},line_reg_date=NOW(),line_reg_alias='{2}' " _
            & "ON DUPLICATE KEY UPDATE {1},line_upd_date=NOW(),line_upd_alias='{2}'"
        data2 = {
            "line_ref='" & in_gudang.Text & "'",
            "line_ref_type='GUDANG'",
            "line_tanggal='" & _tgltrans & "'",
            "line_status='1'"
            }
        queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", data2), loggeduser.user_id))

        q = "INSERT INTO data_jurnal_line SET line_kode='{0}', line_type='MTGIN',{1},line_reg_date=NOW(),line_reg_alias='{2}' " _
            & "ON DUPLICATE KEY UPDATE {1},line_upd_date=NOW(),line_upd_alias='{2}'"
        data2 = {
            "line_ref='" & in_gudang2.Text & "'",
            "line_ref_type='GUDANG'",
            "line_tanggal='" & _tgltrans & "'",
            "line_status='1'"
            }
        queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", data2), loggeduser.user_id))
        ''==========================================================================================================================

        '==========================================================================================================================
        'BEGIN TRANSACTION
        querycheck = startTrans(queryArr)
        '==========================================================================================================================

        Me.Cursor = Cursors.Default

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Exit Sub
        Else
            'TODO : WRITE LOG AKTIVITAS

            MessageBox.Show("Data tersimpan")
            frmmutasigudang.in_cari.Clear()
            populateDGVUserCon("mutasigudang", "", frmmutasigudang.dgv_list)
            in_countdata.Text = dgv_list.Rows.Count
            mn_edit.Enabled = True
            mn_tambah.Enabled = True
            mn_edit.Text = "Edit"
            mn_tambah.Text = "Tambah"
            disableAllSwitch(True)
            mn_save.Enabled = False
        End If
    End Sub

    Private Sub clearTextBarang()
        For Each x As NumericUpDown In {in_qty1, in_qty2, in_qty3}
            x.Value = 0
        Next
        For Each x As TextBox In {in_barang, in_sat1, in_sat2, in_sat3, in_hpp}
            x.Clear()
        Next
        _hppbrg = 0
    End Sub

    Private Sub clearInputBarang()
        clearTextBarang()
        in_barang_nm.Clear()
    End Sub

    Private Sub clearAll()
        For Each x As TextBox In {in_kode, in_barang, in_barang_nm, in_sat1, in_sat2, in_sat3, txtRegAlias, txtRegdate, txtUpdAlias, txtUpdDate,
                                    in_gudang_n, in_gudang, in_gudang2, in_gudang2_n, date_tgl_beli_r, in_hpp}
            x.Clear()
        Next
        For Each x As NumericUpDown In {in_qty1, in_qty2, in_qty3}
            x.Value = 0
        Next
        If selectperiode.tglakhir >= Today Then
            date_tgl_beli.Value = Today
        Else
            date_tgl_beli.Value = selectperiode.tglakhir
        End If

        _hppbrg = 0

        dgv_barang.Rows.Clear()
    End Sub

    Private Sub disableAllSwitch(switch As Boolean)
        For Each x As TextBox In {in_barang_nm, in_gudang_n, in_gudang2_n}
            x.ReadOnly = switch
        Next
        For Each x As NumericUpDown In {in_qty1, in_qty2, in_qty3}
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
            dgv_barang.Enabled = False
        Else
            date_tgl_beli.Visible = True
            dgv_barang.Enabled = True
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

    '---------------- form
    Private Sub fr_stok_mutasi_list_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        performRefresh()
    End Sub

    '----------------- menu
    Private Sub mn_tambah_Click(sender As Object, e As EventArgs) Handles mn_tambah.Click
        'loadCBGudang()

        If mn_tambah.Text = "Baru" Then
            clearAll()
            disableAllSwitch(False)
            mn_save.Enabled = True
            mn_edit.Enabled = False
            in_gudang_n.Focus()
            mn_tambah.Text = "Batal"
        Else
            If MessageBox.Show("Batalkan Perubahan?", "Mutasi Gudang", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            Else
                clearAll()
                disableAllSwitch(True)
                mn_save.Enabled = False
                mn_edit.Enabled = True
                mn_tambah.Text = "Baru"
            End If
        End If
    End Sub

    Private Sub mn_edit_Click(sender As Object, e As EventArgs) Handles mn_edit.Click
        If mn_edit.Text = "Edit" And in_kode.Text <> Nothing Then
            in_kode.Text = dgv_list.Rows(rowindex).Cells("kode").Value
            Try
                loadData(in_kode.Text)
                dgv_barang.Rows.Clear()
                loadBrg(in_kode.Text)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            disableAllSwitch(False)
            in_gudang_n.Focus()
            sender.Text = "Batal Edit"
            mn_tambah.Enabled = False
            mn_save.Enabled = True

            If dgv_barang.RowCount > 0 Then
                in_gudang_n.ReadOnly = True
            Else
                in_gudang_n.ReadOnly = False
            End If

        ElseIf mn_edit.Text = "Batal Edit" Then
            If MessageBox.Show("Batalkan Perubahan?", "Mutasi Gudang", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            Else
                disableAllSwitch(True)
                loadData(in_kode.Text)
                dgv_barang.Rows.Clear()
                loadBrg(in_kode.Text)
                mn_edit.Text = "Edit"
                mn_tambah.Enabled = True
                mn_save.Enabled = False
            End If
        End If
    End Sub

    Private Sub mn_hapus_Click(sender As Object, e As EventArgs) Handles mn_hapus.Click
        MessageBox.Show("Under Construction")
    End Sub

    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        If in_gudang.Text = Nothing Then
            MessageBox.Show("Gudang asal belum dimasukkan")
            in_gudang_n.Focus()
            Exit Sub
        End If
        If in_gudang2.Text = Nothing Then
            MessageBox.Show("Gudang tujuan belum dimasukkan")
            in_gudang2_n.Focus()
            Exit Sub
        End If
        If in_gudang.Text = in_gudang2.Text Then
            If in_gudang.Text = Nothing Then
                MessageBox.Show("Gudang belum dimasukkan")
            Else
                MessageBox.Show("Gudang asal dan tujuan sama")
            End If
            in_gudang.Focus()
            Exit Sub
        End If

        If dgv_barang.RowCount = 0 Then
            MessageBox.Show("Barang belum dimasukkan")
            in_barang.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan Data?", "Mutasi Antar Gudang", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            saveData()
        End If
    End Sub

    Private Sub mn_refresh_Click(sender As Object, e As EventArgs) Handles mn_refresh.Click
        performRefresh()
    End Sub

    Private Sub mn_cari_Click(sender As Object, e As EventArgs) Handles mn_cari.Click
        in_cari.Focus()
    End Sub

    'cari
    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            searchData(in_cari.Text)
        End If
    End Sub

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

    Private Sub dgv_list_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgv_list.RowsAdded
        in_countdata.Text = dgv_list.Rows.Count
    End Sub

    'input
    'numeric input
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty1.Enter, in_qty2.Enter, in_qty3.Enter
        Console.WriteLine(sender.Name & sender.Value)
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty1.Leave, in_qty2.Leave, in_qty3.Leave
        numericLostFocus(sender, "N0")
    End Sub

    'HEDR
    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(date_tgl_beli, e)
    End Sub

    Private Sub date_tgl_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_beli.KeyDown
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub date_tgl_beli_ValueChanged(sender As Object, e As EventArgs) Handles date_tgl_beli.ValueChanged
        date_tgl_beli_r.Text = date_tgl_beli.Value.ToLongDateString
    End Sub

    '------------- POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_gudang2_n.Focused Or in_gudang_n.Focused Or in_barang_nm.Focused Then
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
                Case "gudang2"
                    x = in_gudang2_n
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
            keyshortenter(in_gudang2_n, e)
        ElseIf e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            End If
        Else
            If e.KeyCode <> Keys.Escape Then
                If popPnl_barang.Visible = False And in_gudang_n.ReadOnly = False Then
                    popPnl_barang.Visible = True
                    loadDataBRGPopup("gudang", in_gudang_n.Text)
                End If
            End If
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub in_sales_n_MouseClick(sender As Object, e As MouseEventArgs) Handles in_gudang_n.MouseClick, in_gudang2_n.MouseClick, in_barang_nm.MouseClick
        If popPnl_barang.Visible = False And sender.ReadOnly = False Then
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_gudang_n_TextChanged(sender As Object, e As EventArgs) Handles in_gudang_n.TextChanged
        If in_gudang_n.Text = "" Then
            in_gudang.Clear()
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_gudang2_n.Leave, in_gudang_n.Leave, in_barang_nm.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    'gudang tujuan
    Private Sub in_gudang2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang2.KeyDown
        keyshortenter(in_gudang2_n, e)
    End Sub

    Private Sub in_gudang2_n_Enter(sender As Object, e As EventArgs) Handles in_gudang2_n.Enter
        If mn_save.Enabled = True Then
            popPnl_barang.Location = New Point(in_gudang2_n.Left, in_gudang2_n.Top + in_gudang2_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            popupstate = "gudang2"
            loadDataBRGPopup("gudang2", in_gudang2_n.Text)
        End If
    End Sub

    Private Sub in_gudang2_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang2_n.KeyUp
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
            If e.KeyCode = Keys.Escape Then
                If popPnl_barang.Visible = False And in_gudang2_n.ReadOnly = False Then
                    popPnl_barang.Visible = True
                    loadDataBRGPopup("gudang2", in_gudang2_n.Text)
                End If
            End If
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub in_gudang2_n_TextChanged(sender As Object, e As EventArgs) Handles in_gudang2_n.TextChanged
        If in_gudang2_n.Text = "" Then
            in_gudang2.Clear()
        End If
    End Sub

    Private Sub bt_addgudang_Click(sender As Object, e As EventArgs) Handles bt_addgudang.Click

    End Sub

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
            keyshortenter(in_qty1, e)
        ElseIf e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            End If
        Else
            If popPnl_barang.Visible = False And in_barang_nm.ReadOnly = False Then
                popPnl_barang.Visible = True
                loadDataBRGPopup("barang", in_barang_nm.Text)
            End If
        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub in_barang_nm_TextChanged(sender As Object, e As EventArgs) Handles in_barang_nm.TextChanged
        If in_barang_nm.Text = "" Then
            in_barang.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    'input qty
    Private Sub in_qty1_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty1.KeyDown
        keyshortenter(in_qty2, e)
    End Sub

    Private Sub in_qty2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty2.KeyDown
        keyshortenter(in_qty3, e)
    End Sub

    Private Sub in_qty3_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty3.KeyDown
        keyshortenter(bt_tbbarang, e)
    End Sub

    'dgv barang
    Private Sub bt_tbbarang_Click(sender As Object, e As EventArgs) Handles bt_tbbarang.Click
        textToDGV()
    End Sub

    Private Sub dgv_barang_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellDoubleClick
        If e.RowIndex >= 0 Then
            rowindexbarang = e.RowIndex
            dgvToTxt()
            dgv_barang.Rows.RemoveAt(rowindexbarang)
            If dgv_barang.RowCount = 0 Then
                in_gudang_n.ReadOnly = False
            Else
                in_gudang_n.ReadOnly = True
            End If
        End If
    End Sub

    Private Sub fr_stok_mutasi_list_Click(sender As Object, e As EventArgs) Handles Me.Click, SplitContainer1.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub
End Class
