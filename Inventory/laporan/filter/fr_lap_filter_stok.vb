Public Class fr_lap_filter_stok
    Private popupstate As String = "gudang"
    Private lapwintext As String = ""
    Public laptype As String
    Public supplier_sw As Boolean = False
    Public barang_sw As Boolean = True
    Public gudang_sw As Boolean = True

    Private Sub prcessSW()
        'If supplier_sw = False Then
        lbl_supplier.Visible = supplier_sw
        in_supplier.Visible = supplier_sw
        in_supplier_n.Visible = supplier_sw
        'End If
        'If jenis_sw = False Then
        lbl_gudang.Visible = gudang_sw
        in_gudang.Visible = gudang_sw
        in_gudang_n.Visible = gudang_sw
        'End If
        'If barang_sw = False Then
        lbl_barang.Visible = barang_sw
        in_barang.Visible = barang_sw
        in_barang_n.Visible = barang_sw
        'End If

        Me.Text = lapwintext
        bt_exportxl.Visible = IIf({"lapStokMutasi"}.Contains(laptype), False, True)
        bt_simpanbeli.Enabled = IIf({"lapOpname"}.Contains(laptype), False, True)
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "supplier"
                q = "SELECT supplier_kode AS 'Kode', supplier_nama AS 'Nama' FROM data_supplier_master WHERE supplier_status=1 AND supplier_nama LIKE '{0}%'"
            Case "barang"
                q = "SELECT barang_kode as 'Kode', barang_nama as 'Nama' FROM data_stok_awal " _
                    & "LEFT JOIN data_barang_master ON barang_kode=stock_barang WHERE stock_status=1 " _
                    & "AND stock_gudang LIKE '{0}' AND barang_nama LIKE '{1}%' " _
                    & "GROUP BY barang_kode"
                q = String.Format(q, IIf(in_gudang.Text <> Nothing, in_gudang.Text, "%"), "{0}")
            Case "gudang"
                q = "SELECT gudang_kode as 'Kode', gudang_nama as 'Nama' FROM data_barang_gudang WHERE gudang_status=1 AND gudang_nama LIKE '{0}%'"
            Case Else
                Exit Sub
        End Select

        consoleWriteLine(String.Format(q, param))
        dt = getDataTablefromDB(String.Format(q, param))

        If IsNothing(dt) = False Then
            With dgv_listbarang
                .DataSource = dt
                .Columns(0).Width = 135
                .Columns(1).Width = 200
            End With
        End If
    End Sub

    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "supplier"
                    in_supplier.Text = .Cells(0).Value
                    in_supplier_n.Text = .Cells(1).Value
                    bt_simpanbeli.Focus()
                Case "barang"
                    in_barang.Text = .Cells(0).Value
                    in_barang_n.Text = .Cells(1).Value
                    bt_simpanbeli.Focus()
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    in_barang_n.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
    End Sub

    Private Function createQuery(tipe As String) As String
        Dim q As String = ""
        Dim qwh As String = ""
        Dim qreturn As String = ""
        Dim _colselect As New List(Of String)
        Dim qpersed As String = "SELECT {0} " _
                                & "FROM( " _
                                & " SELECT stock_kode, stock_barang, stock_gudang, " _
                                & "  getSisaStock('{1}',stock_barang,stock_gudang) as stock_qty, " _
                                & "	 getHPPAVG(stock_barang,'{2}','{1}') as stock_hpp " _
                                & "	FROM data_stok_awal " _
                                & "	WHERE stock_status=1 " _
                                & ") stok LEFT JOIN data_barang_master ON stock_barang=barang_kode " _
                                & "LEFT JOIN data_barang_gudang ON stock_gudang=gudang_kode " _
                                & "LEFT JOIN data_supplier_master ON barang_supplier=supplier_kode {3} " _
                                & "ORDER BY barang_kode"
        Dim qOpname As String = "SELECT faktur_bukti, faktur_tanggal, (CASE faktur_status " _
                                & "WHEN 0 THEN 'PENDING' WHEN 1 THEN 'TERPROSES' WHEN 2 THEN 'BATAL' ELSE 'ERROR' END) 'status', " _
                                & "faktur_gudang, gudang_nama, trans_barang, barang_nama, " _
                                & "CONCAT(trans_qty_sys, trans_satuan) qty_sys, trans_hpp, trans_qty_fisik*trans_hpp nilai_sys, " _
                                & "CONCAT(trans_qty_fisik,trans_satuan) qty_fisik, trans_hpp_fisik, trans_qty_fisik*trans_hpp_fisik nilai_fisik, " _
                                & "trans_keterangan, faktur_reg_alias, faktur_upd_alias, faktur_proc_alias " _
                                & "FROM data_stok_opname " _
                                & "LEFT JOIN data_stok_opname_trans ON faktur_bukti=trans_faktur AND trans_status=1 " _
                                & "LEFT JOIN data_barang_master ON trans_barang=barang_kode " _
                                & "LEFT JOIN data_barang_gudang ON faktur_gudang=gudang_kode " _
                                & "WHERE faktur_status IN (0,1,2) AND faktur_tanggal BETWEEN '{0}' AND '{1}' {2}"
        Dim _tglawal As String = date_tglawal.Value.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = date_tglakhir.Value.ToString("yyyy-MM-dd")

        Select Case tipe
            Case "lapKartuStok"
                q = "getDataKartuStok('{0}','{1}','{2}')"
                q = String.Format(q, selectperiode.id, IIf(in_barang.Text = Nothing, "all", in_barang.Text), IIf(in_gudang.Text = Nothing, "all", in_gudang.Text))

            Case "lapPersediaan", "lapStok", "lapStokSupplier"
                If tipe = "lapPersediaan" Then
                    _colselect.AddRange({"stock_gudang", "gudang_nama stock_gudang_n", "stock_barang", "barang_nama stock_barang_n", "stock_qty",
                                         "getQTYdetail(stock_barang, stock_qty, 1) stock_qty_n", "stock_hpp", "stock_hpp*stock_qty stock_nilai"})
                ElseIf tipe = "lapStok" Then
                    _colselect.AddRange({"stock_gudang", "gudang_nama stock_gudang_n", "stock_barang", "barang_nama stock_barang_n", "stock_qty",
                                         "getQTYdetail(stock_barang, stock_qty, 1) stock_qty_n"})
                ElseIf tipe = "lapStokSupplier" Then
                    _colselect.AddRange({"barang_supplier stock_supplier", "supplier_nama stock_supplier_n", "stock_gudang", "gudang_nama stock_gudang_n", "stock_barang",
                                         "barang_nama stock_barang_n", "stock_qty", "getQTYdetail(stock_barang, stock_qty, 1) stock_qty_n", "stock_hpp",
                                         "stock_hpp*stock_qty stock_nilai"})
                End If

                q = qpersed
                q = String.Format(q, String.Join(",", _colselect), selectperiode.id, _tglakhir, "{0}")

                Dim whr As New List(Of String)
                If in_gudang.Text <> Nothing Or in_barang.Text <> Nothing Or in_supplier.Text <> Nothing Then
                    qwh += "WHERE {0}"
                End If
                If in_gudang.Text <> Nothing Then
                    whr.Add("stock_gudang='" & in_gudang.Text & "'")
                End If
                If in_barang.Text <> Nothing Then
                    whr.Add("stock_barang='" & in_barang.Text & "'")
                End If
                If in_supplier.Text <> Nothing And tipe = "lapStokSupplier" Then
                    whr.Add("barang_supplier='" & in_supplier.Text & "'")
                End If

                qwh = String.Format(qwh, String.Join(" AND ", whr))

            Case "lapStokMutasi", "lapPersediaanMutasi"
                q = "getDataPersediaan('{0}','{1}','{2}')"
                q = String.Format(q, selectperiode.id, IIf(in_barang.Text = Nothing, "all", in_barang.Text), IIf(in_gudang.Text = Nothing, "all", in_gudang.Text))

            Case "lapOpname"
                q = qOpname
                q = String.Format(q, _tglawal, _tglakhir, "{0}")

                If in_gudang.Text <> Nothing Then
                    qwh += "AND faktur_gudang='" & in_gudang.Text & "' "
                End If
                If in_barang.Text <> Nothing Then
                    qwh += "AND trans_barang='" & in_barang.Text & "' "
                End If
        End Select

        qreturn = String.Format(q, qwh)
        consoleWriteLine(qreturn)

        Return qreturn
    End Function

    Private Sub exportData(type As String)
        Dim q As String = createQuery(type)
        Dim _dt As New DataTable
        Dim _colheader As New List(Of String)
        Dim _outputdir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Inventory\"
        Dim _filename As String = "dataexport" & Today.ToString("yyyyMMdd")
        Dim _respond As Boolean = False
        Dim _svdialog As New SaveFileDialog
        Dim _title As String = ""
        Dim header As String = ""
        Dim _datefile As String = ""
        If date_tglawal.Value.Month = date_tglakhir.Value.Month And date_tglawal.Value.Year = date_tglakhir.Value.Year Then
            header = "Periode " & selectperiode.tglawal.ToString("MMMM yyyy")
            _datefile = header.Replace("Periode ", "") & "_" & Today.ToString("yyyyMMdd")
        Else
            header = "Periode " & date_tglawal.Value.ToString("dd/MM/yyyy") & " s.d. " & date_tglakhir.Value.ToString("dd/MM/yyyy")
            _datefile = date_tglawal.Value.ToString("yyyyMMdd") & "-" & date_tglakhir.Value.ToString("yyyyMMdd") & "_" & Today.ToString("yyyyMMdd")
        End If

        MyBase.Cursor = Cursors.AppStarting

        Select Case type
            Case "lapKartuStok"
                _colheader.AddRange({"KODE_STOCK", "IDX", "TANGGAL_TRANS", "KODE_BARANG", "NAMA_BARANG", "KODE_GUDANG", "NAMA_GUDANG", "REF_NO_TRANSAKSI",
                                     "KETERANGAN", "KETERANGAN2", "DEBET", "KREDIT", "SALDO", "NILAI", "KODE_JENIS_TRANS"})
                _title = "Kartu Stok " & header
                _filename = "KartuStok" & _datefile & ".xlsx"
            Case "lapPersediaan"
                _colheader.AddRange({"KODE_GUDANG", "NAMA_GUDANG", "KODE_BARANG", "NAMA_BARANG", "QTY_STOK", "DETAIL_QTY", "HPP_STOK", "NILAI_STOK"})
                _title = "Laporan Persediaan Barang " & header
                _filename = "PersediaanBarang" & _datefile & ".xlsx"
            Case "lapStok"
                _colheader.AddRange({"KODE_GUDANG", "NAMA_GUDANG", "KODE_BARANG", "NAMA_BARANG", "QTY_STOK", "DETAIL_QTY"})
                _title = "Laporan Stok Barang " & header
                _filename = "StokBarang" & _datefile & ".xlsx"
            Case "lapStokSupplier"
                _colheader.AddRange({"KODE_SUPPLIER", "NAMA_SUPPLIER", "KODE_GUDANG", "NAMA_GUDANG", "KODE_BARANG", "NAMA_BARANG", "QTY_STOK", "DETAIL_QTY", "HPP_STOK", "NILAI_STOK"})
                _title = "Laporan Persediaan Barang Per Suppplier " & header
                _filename = "PersediaanSupplierBarang" & _datefile & ".xlsx"
            Case "lapPersediaanMutasi"
                _colheader.AddRange({"KODE_GUDANG", "NAMA_GUDANG", "KODE_BARANG", "NAMA_BARANG", "HPP_BARANG", "QTY_AWAL", "NILAI_AWAL", "QTY_BELI", "NILAI_BELI", "QTY_JUAL",
                                     "NILAI_JUAL", "QTY_RETURBELI", "NILAI_RETURBELI", "QTY_RETURJUAL", "NILAI_RETURJUAL", "QTY_KELUAR", "NILAI_KELUAR", "QTY_MASUK", "NILAI_MASUK",
                                     "QTY_OPNAME", "NILAI_OPNAME"})
                _title = "Laporan Mutasi Persediaan Barang " & header
                _filename = "MutasiPersediaanBarang" & _datefile & ".xlsx"
                'Case "lapStokMutasi"
                '    _colheader.AddRange({"KODE_GUDANG", "NAMA_GUDANG", "KODE_BARANG", "NAMA_BARANG", "HPP_BARANG", "QTY_AWAL", "QTY_BELI", "QTY_JUAL", "QTY_RETURBELI",
                '                         "QTY_RETURJUAL", "QTY_KELUAR", "QTY_MASUK", "QTY_OPNAME"})
                '    _title = "Laporan Mutasi Stok Barang " & header
                '    _filename = "MutasiStokBarang" & _datefile & ".xlsx"
            Case "lapOpname"
                _colheader.AddRange({"NO_OPNAME", "TGL_OPNAME", "STATUS_OPNAME", "KODE_GUDANG", "NAMA_GUDANG", "KODE_BARANG", "NAMA_BARANG", "QTY_SYSTEM", "HPP_SYSTEM", "NILAI_STOK",
                                     "QTY_FISIK", "HPP_FISIK", "NILAI_FISIK", "KETERANGAN", "INPUT_USER", "EDIT_USER", "PROCES_USER"})
                _title = "Laporan Stok Opname " & header
                _filename = "StokOpname" & _datefile & ".xlsx"
            Case Else
                Exit Sub
        End Select

        _svdialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
        _svdialog.FilterIndex = 1
        _svdialog.FileName = _svdialog.InitialDirectory & _filename
        _svdialog.RestoreDirectory = True
        If _svdialog.ShowDialog = DialogResult.OK Then
            If _svdialog.FileName <> Nothing Then
                _outputdir = IO.Path.GetDirectoryName(_svdialog.FileName)
                _filename = Strings.Replace(_svdialog.FileName, _outputdir, "")
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If

        _dt = getDataTablefromDB(q)

        If exportXlsx(_colheader, _dt, _outputdir, _filename, _title) = True Then
            MessageBox.Show("Export sukses")
            If System.IO.File.Exists(_svdialog.FileName) = True Then
                Process.Start(_svdialog.FileName)
            End If
        Else
            MessageBox.Show("Export gagal")
        End If

        MyBase.Cursor = Cursors.Default
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        Me.Close()
    End Sub

    Private Sub fr_lap_filter_jual_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim _dialogres As Windows.Forms.DialogResult = MessageBox.Show("Tutup Form?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _dialogres = Windows.Forms.DialogResult.No Then
            e.Cancel = True
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

    Private Sub fr_pesan_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            Else
                bt_batalbeli.PerformClick()
            End If
        End If
    End Sub

    'LOAD
    Private Sub fr_lap_filter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub do_load(judulLap As String, tipeLap As String)
        laptype = tipeLap
        lapwintext = judulLap

        date_tglawal.Value = selectperiode.tglawal
        date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)

        prcessSW()
        lbl_periodedata.Text = main.strip_periode.Text
    End Sub

    'LOAD LAPORAN
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        Dim x As New fr_lap_stock_view With {
                    .Text = lapwintext
                }
        Dim header As String = ""
        If date_tglawal.Value.Month = date_tglakhir.Value.Month And date_tglawal.Value.Year = date_tglakhir.Value.Year Then
            header = "Periode " & selectperiode.tglawal.ToString("MMMM yyyy")
        Else
            header = "Periode " & date_tglawal.Value.ToString("dd/MM/yyyy") & " s.d. " & date_tglakhir.Value.ToString("dd/MM/yyyy")
        End If
        x.setVar(laptype, createQuery(laptype), header)
        x.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_exportxl.Click
        'MessageBox.Show("Under Construction")
        exportData(laptype)
    End Sub

    'UI
    '------------- POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_supplier_n.Focused Or in_barang_n.Focused Or in_gudang_n.Focused Then
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

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyUp
        If e.KeyCode = Keys.Enter Then
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_KeyDown_1(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            'consoleWriteLine("fuck")
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            Dim x As TextBox
            Select Case popupstate
                Case "supplier"
                    x = in_supplier_n
                Case "barang"
                    x = in_barang_n
                Case "gudang"
                    x = in_gudang_n
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

    '-------------- INPUT
    Private Sub date_tglawal_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglawal.KeyUp
        keyshortenter(date_tglakhir, e)
    End Sub

    Private Sub date_tglawal_ValueChanged(sender As Object, e As EventArgs) Handles date_tglawal.ValueChanged
        date_tglakhir.MinDate = date_tglawal.Value
    End Sub

    Private Sub date_tglakhir_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglakhir.KeyUp
        keyshortenter(bt_simpanbeli, e)
    End Sub

    Private Sub date_tglakhir_ValueChanged(sender As Object, e As EventArgs) Handles date_tglakhir.ValueChanged
        date_tglawal.MaxDate = date_tglakhir.Value
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        keyshortenter(in_supplier_n, e)
    End Sub

    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_supplier_n.Enter
        popPnl_barang.Location = New Point(in_supplier_n.Left, in_supplier_n.Top + in_supplier_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "supplier"
        loadDataBRGPopup("supplier", in_supplier_n.Text)
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_supplier_n.Leave, in_barang_n.Leave, in_gudang_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyUp, in_barang_n.KeyUp, in_gudang_n.KeyUp
        Dim _nxtcontrol As Object
        Dim _kdcontrol As Object
        Select Case sender.Name.ToString
            Case "in_supplier_n"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = in_supplier
            Case "in_barang_n"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = in_barang
            Case "in_gudang_n"
                _nxtcontrol = bt_batalbeli
                _kdcontrol = in_gudang
            Case Else
                Exit Sub
        End Select

        If sender.Text = "" And IsNothing(_kdcontrol) = False Then
            _kdcontrol.Text = ""
        End If

        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(_nxtcontrol, e)
        Else
            If e.KeyCode <> Keys.Escape Then
                If popPnl_barang.Visible = False Then
                    popPnl_barang.Visible = True
                End If
                loadDataBRGPopup(popupstate, sender.Text)
            End If
        End If
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyUp
        keyshortenter(in_barang_n, e)
    End Sub

    Private Sub in_barang_n_Enter(sender As Object, e As EventArgs) Handles in_barang_n.Enter
        popPnl_barang.Location = New Point(in_barang_n.Left, in_barang_n.Top + in_barang_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "barang"
        loadDataBRGPopup("barang", in_barang_n.Text)
    End Sub

    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyUp
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

    Private Sub fr_hutang_bayar_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub
End Class