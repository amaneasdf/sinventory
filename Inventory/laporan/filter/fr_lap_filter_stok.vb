Public Class fr_lap_filter_stok
    Private popupstate As String = "gudang"
    Private lapwintext As String = ""
    Public laptype As String
    Public supplier_sw As Boolean = False
    Public barang_sw As Boolean = True
    Public gudang_sw As Boolean = True
    Private groupby_sw As Boolean = False

    'LOAD FORM
    Public Sub do_load(judulLap As String, tipeLap As String)
        laptype = tipeLap
        lapwintext = judulLap

        date_tglawal.Value = selectperiode.tglawal
        date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        'date_tglawal.MinDate = selectperiode.tglawal
        'date_tglakhir.MaxDate = selectperiode.tglakhir

        lbl_periodedata.Text = main.strip_periode.Text
        lbl_periodedata.Visible = False
        SetForm(tipeLap)

        Me.ShowDialog(main)
    End Sub

    Private Sub SetForm(FrmType As String)
        With cb_jenis
            .DataSource = jenis("trans_pajak2")
            .DisplayMember = "Text"
            .ValueMember = "Value"
        End With

        Select Case FrmType
            Case "lapKartuStok", "lapStokMutasi", "lapPersediaanMutasi", "lapPersediaan", "lapStok"

            Case "lapStokSupplier"
                supplier_sw = True

            Case "lapKartuPersediaan", "lapKartuPersediaanGudang"
                If FrmType = "lapKartuPersediaan" Then
                    lapwintext = "Laporan Rincian Persediaan"
                ElseIf FrmType = "lapKartuPersediaanGudang" Then
                    lapwintext = "Laporan Rincian Persediaan Per Gudang"
                End If
                groupby_sw = True

                lbl_groupby.Location = lbl_supplier.Location
                With cb_groupBy
                    .Location = in_supplier.Location
                    .DataSource = LoadGroupCombo(FrmType)
                    .DisplayMember = "Text"
                    .ValueMember = "Value"
                    .SelectedValue = FrmType
                End With
        End Select

        prcessSW()
    End Sub

    Private Sub prcessSW()
        lbl_supplier.Visible = supplier_sw
        in_supplier.Visible = supplier_sw
        in_supplier_n.Visible = supplier_sw

        lbl_gudang.Visible = gudang_sw
        in_gudang.Visible = gudang_sw
        in_gudang_n.Visible = gudang_sw

        lbl_barang.Visible = barang_sw
        in_barang.Visible = barang_sw
        in_barang_n.Visible = barang_sw

        lbl_groupby.Visible = groupby_sw
        cb_groupBy.Visible = groupby_sw

        Me.Text = lapwintext
        bt_exportxl.Visible = IIf({"lapStokMutasi"}.Contains(laptype), False, True)
        bt_simpanbeli.Enabled = IIf({"lapOpname"}.Contains(laptype), False, True)
    End Sub

    Private Function LoadGroupCombo(LapType As String) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Text", GetType(String))
        dt.Columns.Add("Value", GetType(String))

        Select Case LapType
            Case "lapKartuPersediaan", "lapKartuPersediaanGudang"
                dt.Rows.Add("Per Barang", "lapKartuPersediaan")
                dt.Rows.Add("Per Gudang & Barang", "lapKartuPersediaanGudang")
        End Select

        Return dt
    End Function

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "supplier"
                q = "SELECT supplier_kode AS 'Kode', supplier_nama AS 'Nama' FROM data_supplier_master " _
                    & "WHERE supplier_status=1 AND (supplier_nama LIKE '%{0}%' OR supplier_kode LIKE '%{0}%')"
            Case "barang"
                q = "SELECT barang_kode as 'Kode', barang_nama as 'Nama' FROM data_stok_awal " _
                    & "LEFT JOIN data_barang_master ON barang_kode=stock_barang WHERE stock_status=1 " _
                    & "AND stock_gudang LIKE '{0}' AND barang_nama LIKE '%{1}%' AND barang_pajak IN ({2})" _
                    & "GROUP BY barang_kode"
                q = String.Format(q, IIf(in_gudang.Text <> Nothing, in_gudang.Text, "%"), "{0}", cb_jenis.SelectedValue)
            Case "gudang"
                q = "SELECT gudang_kode as 'Kode', gudang_nama as 'Nama' FROM data_barang_gudang " _
                    & "WHERE gudang_status=1 AND (gudang_nama LIKE '%{0}%' OR gudang_kode LIKE '%{0}%')"
            Case Else
                Exit Sub
        End Select

        dt = getDataTablefromDB(String.Format(q, param))

        If dt.Columns.Count >= 2 Then
            With dgv_listbarang
                .DataSource = dt
                .Columns(0).Width = 125
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
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

    'CREATE MYSQL QUERY
    Private Function createQuery(tipe As String) As String
        Dim q As String = ""
        Dim _qwh, _qjoin, _qorder As String
        Dim _colselect As New List(Of String)
        Dim _whrArr As New List(Of String)

        Select Case tipe
            Case "lapKartuStok", "lapKartuPersediaan", "lapKartuPersediaanGudang", "lapStokMutasi", "lapPersediaanMutasi"
                'FFS >20s JUST TO GET THE DATA IS KINDA TOO MUCH
                q = "SELECT {0} FROM( " _
                    & " SELECT stock_gudang, stock_barang, 0 trans_id, '{1:yyyy-MM-dd}' trans_tgl, 'sa' trans_jenis, 'SALDO AWAL' trans_ket, " _
                    & "  '' trans_faktur, SUM(trans_qty) trans_qty, SUM(trans_nilai) trans_nilai " _
                    & " FROM data_stok_kartustok " _
                    & " LEFT JOIN data_stok_awal ON trans_stock=stock_kode " _
                    & " WHERE stock_status=1 AND trans_status=1 AND (trans_tgl<'{1:yyyy-MM-dd}' " _
                    & "     OR (trans_tgl BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' AND trans_jenis IN ('mi','ad','sa'))) {3}" _
                    & " GROUP BY trans_stock " _
                    & " UNION " _
                    & " SELECT stock_gudang, stock_barang, trans_id, trans_tgl, trans_jenis, trans_ket, trans_faktur, trans_qty, trans_nilai " _
                    & " FROM data_stok_kartustok " _
                    & " LEFT JOIN data_stok_awal ON trans_stock=stock_kode " _
                    & " WHERE stock_status=1 AND trans_status=1 AND trans_tgl BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' " _
                    & "     AND trans_jenis NOT IN ('mi','ad','sa') {3}" _
                    & ") liststock {4}"

                If Not String.IsNullOrWhiteSpace(in_barang.Text) Then _whrArr.Add("stock_barang='" & in_barang.Text & "'")
                If Not String.IsNullOrWhiteSpace(in_gudang.Text) Then _whrArr.Add("stock_gudang='" & in_gudang.Text & "'")

                If {"lapStokMutasi", "lapPersediaanMutasi"}.Contains(tipe) Then
                    _colselect.AddRange({"stock_gudang mts_gudang", "gudang_nama mts_gudang_n",
                                         "stock_barang mts_barang", "GetMasterNama('barang', stock_barang) mts_barang_n",
                                         "GetMasterNama('barangpajaknama', stock_barang) mts_kat",
                                         "SUM(IF(trans_jenis='sa', trans_qty, 0)) mts_qty_saldoawal",
                                         "SUM(IF(trans_jenis='po', trans_qty, 0)) mts_qty_beli",
                                         "SUM(IF(trans_jenis='rj', trans_qty, 0)) mts_qty_rjual",
                                         "SUM(IF(trans_jenis IN('mg','mb') AND trans_qty>0, trans_qty, 0)) mts_qty_mmsk",
                                         "SUM(IF(trans_jenis='so', trans_qty*-1, 0)) mts_qty_jual",
                                         "SUM(IF(trans_jenis='rb', trans_qty*-1, 0)) mts_qty_rbeli",
                                         "SUM(IF(trans_jenis IN('mg','mb') AND trans_qty<0, trans_qty*-1, 0)) mts_qty_mklr",
                                         "SUM(IF(trans_jenis='op', trans_qty, 0)) mts_qty_opname"
                                        })

                    If tipe = "lapPersediaanMutasi" Then
                        _colselect.AddRange({"SUM(IF(trans_jenis='sa', trans_nilai, 0)) mts_nilai_saldoawal",
                                             "SUM(IF(trans_jenis='po', trans_nilai, 0)) mts_nilai_beli",
                                             "SUM(IF(trans_jenis='rj', trans_nilai, 0)) mts_nilai_rjual",
                                             "SUM(IF(trans_jenis IN('mg','mb') AND trans_nilai>0, trans_nilai, 0)) mts_nilai_mmsk",
                                             "SUM(IF(trans_jenis='so', trans_nilai*-1, 0)) mts_nilai_jual",
                                             "SUM(IF(trans_jenis='rb', trans_nilai*-1, 0)) mts_nilai_rbeli",
                                             "SUM(IF(trans_jenis IN('mg','mb') AND trans_nilai<0, trans_nilai*-1, 0)) mts_nilai_mklr",
                                             "SUM(IF(trans_jenis='op', trans_nilai, 0)) mts_nilai_opname"
                                            })
                    End If

                    _qorder = " GROUP BY stock_gudang, stock_barang"

                Else
                    'COLUMN 'KET2' STILL EMPTY
                    _colselect.AddRange({"stock_gudang kartu_gudang", "gudang_nama kartu_gudang_n",
                                         "stock_barang kartu_barang", "GetMasterNama('barang', stock_barang) kartu_barang_n",
                                         "GetMasterNama('barangpajaknama', stock_barang) kartu_kat",
                                         "trans_tgl kartu_tgl", "trans_faktur kartu_faktur",
                                         "trans_ket kartu_ket", "GetKartuStok_ket2(trans_jenis, trans_faktur) kartu_ket2",
                                         "IF(trans_qty>0, trans_qty, 0) kartu_debet",
                                         "IF(trans_qty<0, trans_qty*-1, 0) kartu_kredit"})

                    If {"lapKartuPersediaan", "lapKartuPersediaanGudang"}.Contains(tipe) Then
                        _colselect.AddRange({"IF(trans_nilai>0, trans_nilai, 0) kartu_debet_nilai",
                                             "IF(trans_nilai<0, trans_nilai*-1, 0) kartu_kredit_nilai"})
                    End If

                    If tipe = "lapKartuPersediaan" Then
                        _qorder = " ORDER BY stock_barang, trans_tgl, trans_id"
                    Else
                        _qorder = " ORDER BY stock_gudang, stock_barang, trans_tgl, trans_id"
                    End If
                End If

                _qjoin = " LEFT JOIN data_barang_gudang ON gudang_kode=stock_gudang "
                _qwh = String.Format(" AND GetMasterNama('barangpajak', stock_barang) IN ({0})", cb_jenis.SelectedValue) _
                                        & IIf(_whrArr.Count > 0, " AND " & String.Join(" AND ", _whrArr), "")

                Return String.Format(q, String.Join(",", _colselect), date_tglawal.Value, date_tglakhir.Value, _qwh, _qjoin + _qorder)
                Exit Function

            Case "lapPersediaan", "lapStok", "lapStokSupplier"
                q = "SELECT {0} FROM (" _
                    & " SELECT stock_gudang, stock_barang, GetMasterNama('barangsupplier', stock_barang) stock_supplier, " _
                    & "  SUM(trans_qty) stock_qty, SUM(trans_nilai) stock_nilai, getHppAvg_v2(stock_barang, '{1:yyyy-MM-dd}') stock_hpp " _
                    & " FROM data_stok_kartustok " _
                    & " LEFT JOIN data_stok_awal ON stock_kode=trans_stock " _
                    & " WHERE trans_status=1 AND stock_status=1 AND trans_tgl<='{1:yyyy-MM-dd}' {2}" _
                    & " GROUP BY trans_stock " _
                    & ")stok {3}"
                If Not String.IsNullOrWhiteSpace(in_barang.Text) Then _whrArr.Add("stock_barang='" & in_barang.Text & "'")
                If Not String.IsNullOrWhiteSpace(in_gudang.Text) Then _whrArr.Add("stock_gudang='" & in_gudang.Text & "'")

                _colselect.AddRange({"stock_gudang", "gudang_nama stock_gudang_n",
                                     "stock_barang", "GetMasterNama('barang', stock_barang) stock_barang_n",
                                     "GetMasterNama('barangpajaknama', stock_barang) stock_kat",
                                     "stock_qty", "getQTYdetail(stock_barang, stock_qty, 1) stock_qty_n"
                                    })
                _qjoin = " LEFT JOIN data_barang_gudang ON gudang_kode=stock_gudang"
                _qwh = String.Format(" AND GetMasterNama('barangpajak', stock_barang) IN ({0})", cb_jenis.SelectedValue) _
                                        & IIf(_whrArr.Count > 0, " AND " & String.Join(" AND ", _whrArr), "")

                If LCase(tipe) = "lappersediaan" Then
                    _colselect.AddRange({"stock_nilai", "stock_hpp"})

                ElseIf LCase(tipe) = "lapstoksupplier" Then
                    _colselect.AddRange({"stock_nilai", "stock_hpp", "stock_supplier", "supplier_nama stock_supplier_n"})
                    _qjoin = " LEFT JOIN data_barang_gudang ON gudang_kode=stock_gudang " _
                            & "LEFT JOIN data_supplier_master ON supplier_kode=stock_supplier"

                End If

                If LCase(tipe) = "lapstoksupplier" Then
                    Dim _qwh2 As String = IIf(Not String.IsNullOrWhiteSpace(in_supplier.Text), "WHERE stock_supplier='" & in_supplier.Text & "'", "")
                    Return String.Format(q, String.Join(",", _colselect), date_tglakhir.Value, _qwh, _qjoin + _qwh2)
                    Exit Function
                Else
                    Return String.Format(q, String.Join(",", _colselect), date_tglakhir.Value, _qwh, _qjoin)
                    Exit Function
                End If

            Case "lapOpname"

        End Select

        Return String.Empty
    End Function

    'EXPORT DATA
    Private Sub ExportLaporan(LapType As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim q As String = createQuery(LapType)
        Dim _dt As New List(Of DataTable)
        Dim _title As New List(Of String)
        Dim _subtitle As New List(Of String())
        Dim _colHeader As New List(Of String)
        Dim _outputdir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\SIMInvent\"
        Dim _periode As String = "" : Dim _tglawal As Date = date_tglawal.Value : Dim _tglakhir As Date = date_tglakhir.Value
        Dim _ck As Boolean = False

        If _tglawal.ToString("MMyyyy") = _tglakhir.ToString("MMyyyy") AndAlso _tglawal.Day = 1 _
            AndAlso _tglakhir.Day = DateSerial(_tglakhir.Year, _tglakhir.Month + 1, 0).Day Then
            _periode = UCase(_tglawal.ToString("MMMM yyyy"))
        Else
            _periode = _tglawal.ToString("dd/MM/yyyy") & " S.d " & _tglakhir.ToString("dd/MM/yyyy")
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Using dtx = x.GetDataTable(q)
                    If dtx.Rows.Count = 0 Then
                        MessageBox.Show("Jumlah data 0, tidak dapat mengexport data.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    Select Case LCase(LapType)
                        Case "lapkartustok", "lapkartupersediaangudang"
                            _colHeader.AddRange({"TGL.", "NO.BUKTI", "KETERANGAN1", "KETERANGAN2"})
                            _title.AddRange({IIf(LCase(LapType) = "lapkartustok", "KARTU STOK", "KARTU PERSEDIAAN BARANG"),
                                             "PERIODE " & _periode})
                            If LCase(LapType) = "lapkartustok" Then
                                _colHeader.AddRange({"MASUK", "KELUAR"})
                            Else
                                _colHeader.AddRange({"QTY_MASUK", "NILAI_MASUK", "QTY_KELUAR", "NILAI_KELUAR"})
                            End If

                            Dim _gudanglist = New DataView(dtx).ToTable(True, {"kartu_gudang", "kartu_gudang_n"}).Select("", "kartu_gudang ASC")
                            For Each row As DataRow In _gudanglist
                                Dim _expression = String.Format("kartu_gudang = '{0}'", row.ItemArray(0))
                                Dim _baranglist = New DataView(dtx.Select(_expression).CopyToDataTable).ToTable(True, {"kartu_barang", "kartu_barang_n"}).Select("", "kartu_barang ASC")
                                For Each _row As DataRow In _baranglist
                                    _subtitle.Add({"GUDANG", row.ItemArray(0), row.ItemArray(1), "ITEM", _row.ItemArray(0), _row.ItemArray(1)})
                                    _expression = String.Format("kartu_gudang='{0}' AND kartu_barang='{1}'", row.ItemArray(0), _row.ItemArray(0))
                                    Dim _ddd = dtx.Select(_expression).CopyToDataTable
                                    If LCase(LapType) = "lapkartustok" Then
                                        _dt.Add(New DataView(_ddd).ToTable(False, {"kartu_tgl", "kartu_faktur", "kartu_ket", "kartu_ket2", "kartu_debet", "kartu_kredit"}))
                                    Else
                                        _dt.Add(New DataView(_ddd).ToTable(False, {"kartu_tgl", "kartu_faktur", "kartu_ket", "kartu_ket2", "kartu_debet", "kartu_debet_nilai", "kartu_kredit", "kartu_kredit_nilai"}))
                                    End If
                                Next
                            Next

                        Case "lapkartupersediaan"
                            _colHeader.AddRange({"TGL.", "KD.GUDANG", "NAMAGUDANG", "NO.BUKTI", "KETERANGAN1", "KETERANGAN2",
                                                 "QTY_MASUK", "NILAI_MASUK", "QTY_KELUAR", "NILAI_KELUAR"})
                            _title.AddRange({"KARTU PERSEDIAAN BARANG", "PERIODE " & _periode})

                            Dim _baranglist = New DataView(dtx).ToTable(True, {"kartu_barang", "kartu_barang_n"}).Select("", "kartu_barang ASC")
                            For Each row As DataRow In _baranglist
                                _subtitle.Add({row.ItemArray(0), row.ItemArray(1)})
                                Dim _expression = String.Format("kartu_barang = '{0}'", row.ItemArray(0))
                                _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, {"kartu_tgl", "kartu_gudang", "kartu_gudang_n", "kartu_faktur", "kartu_ket", "kartu_ket2", "kartu_debet", "kartu_debet_nilai", "kartu_kredit", "kartu_kredit_nilai"}))
                            Next

                        Case "lapStokMutasi", "lapPersediaanMutasi"
                            _colHeader.AddRange({"KD.BARANG", "NAMABARANG", "KAT"})
                            _title.AddRange({String.Format("LAPORAN MUTASI {0} BARANG", IIf(LCase(LapType), "STOK", "PERSEDIAAN")),
                                             "PERIODE " & _periode})

                            If LCase(LapType) = "lapStokMutasi" Then
                                _colHeader.AddRange({"SALDOAWAL", "BELI", "G.MASUK", "RETURJUAL", "JUAL", "G.KELUAR", "RETURBELI", "OPNAME"})
                            Else
                                _colHeader.AddRange({"QTY_SALDOAWAL", "NILAI_SALDOAWAL", "QTY_BELI", "NILAI_BELI", "QTY_G.MASUK", "NILAI_G.MASUK",
                                                     "QTY_RETURJUAL", "NILAI_RETURJUAL", "QTY_JUAL", "NILAI_JUAL", "QTY_G.KELUAR", "NILAI_G.KELUAR",
                                                     "QTY_RETURBELI", "NILAI_RETURBELI", "QTY_OPNAME", "NILAI_OPNAME"})
                            End If
                            Dim _gudanglist = New DataView(dtx).ToTable(True, {"mst_gudang", "mts_gudang_n"}).Select("", "mts_gudang ASC")
                            For Each row As DataRow In _gudanglist
                                _subtitle.Add({row.ItemArray(0), row.ItemArray(1)})
                                Dim _expression = String.Format("mts_gudang = '{0}'", row.ItemArray(0))
                                If LCase(LapType) = "lapstokmutasi" Then
                                    _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, {"mts_barang", "mts_barang_n", "mts_kat", "mts_qty_saldoawal", "mts_qty_beli", "mts_qty_mmsk", "mts_qty_rjual", "mts_qty_jual", "mts_qty_mklr", "mts_qty_rbeli", "mts_qty_opname"}))
                                Else
                                    _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, {"mts_barang", "mts_barang_n", "mts_kat", "mts_qty_saldoawal", "mts_nilai_saldoawal", "mts_qty_beli", "mts_nilai_beli", "mts_qty_mmsk", "mts_nilai_mmsk", "mts_qty_rjual", "mts_nilai_rjual", "mts_qty_jual", "mts_nilai_jual", "mts_qty_mklr", "mts_nilai_mklr", "mts_qty_rbeli", "mts_nilai_rbeli", "mts_qty_opname", "mts_nilai_opname"}))
                                End If
                            Next

                        Case "lappersediaan", "lapstok", "lapstoksupplier"
                            If LCase(LapType) = "lapstok" Then
                                _colHeader.AddRange({"KD.BARANG", "NAMABARANG", "KAT", "QTY(PCS)", "QTY"})
                                _title.AddRange({"LAPORAN STOK BARANG", "PERIODE " & _periode})

                            ElseIf LCase(LapType) = "lappersediaan" Then
                                _colHeader.AddRange({"KD.BARANG", "NAMABARANG", "KAT", "HPP", "QTY(PCS)", "QTY", "NILAI"})
                                _title.AddRange({"LAPORAN PERSEDIAAN BARANG", "PERIODE " & _periode})

                            Else
                                _colHeader.AddRange({"KD.SUPPLIER", "NAMASUPPLIER", "KD.BARANG", "NAMABARANG", "KAT", "HPP", "QTY(PCS)", "QTY", "NILAI"})
                                _title.AddRange({"LAPORAN PERSEDIAAN BARANG PER SUPPLIER", "PERIODE " & _periode})

                            End If

                            Dim _gudanglist = New DataView(dtx).ToTable(True, {"stock_gudang", "stock_gudang_n"}).Select("", "stock_gudang ASC")
                            For Each row As DataRow In _gudanglist
                                _subtitle.Add({row.ItemArray(0), row.ItemArray(1)})
                                Dim _expression = String.Format("stock_gudang = '{0}'", row.ItemArray(0))
                                If LCase(LapType) = "lapstok" Then
                                    _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, {"stock_barang", "stock_barang_n", "stock_kat", "stock_qty", "stock_qty_n"}))
                                ElseIf LCase(LapType) = "lappersediaan" Then
                                    _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, {"stock_barang", "stock_barang_n", "stock_kat", "stock_hpp", "stock_qty", "stock_qty_n", "stock_nilai"}))
                                Else
                                    _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, {"stock_supplier", "stock_supplier_n", "stock_barang", "stock_barang_n", "stock_kat", "stock_hpp", "stock_qty", "stock_qty_n", "stock_nilai"}))
                                End If
                            Next

                        Case Else
                            Exit Sub
                    End Select
                End Using

                Using dd As New SaveFileDialog
                    dd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
                    dd.FilterIndex = 1
                    dd.FileName = dd.InitialDirectory
                    dd.RestoreDirectory = True
                    If dd.ShowDialog = DialogResult.OK Then
                        If dd.FileName <> Nothing Then
                            Dim fk = dd.FileName.Split(".")
                            Dim _fileExt As String = IIf(dd.FilterIndex = 1, "xlsx", fk(fk.Count - 1))

                            Me.Cursor = Cursors.WaitCursor
                            If ExportExcel(_colHeader, _dt, _title, dd.FileName, _fileExt, _outputdir, _subtitle) Then
                                If System.IO.File.Exists(_outputdir) = True Then
                                    MessageBox.Show("Export Data Sukses", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Process.Start(_outputdir)
                                Else
                                    MessageBox.Show("File tidak dapat ditemukan", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                            Me.Cursor = Cursors.Default
                        End If
                    End If
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Export Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
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
        'Dim _dialogres As Windows.Forms.DialogResult = MessageBox.Show("Tutup Form?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'If _dialogres = Windows.Forms.DialogResult.No Then
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbeli.PerformClick()
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

    'LOAD LAPORAN
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        Dim x As New fr_lap_stock_view With {
                    .Text = lapwintext
                }
        Dim header As String = ""
        If date_tglawal.Value.Month = date_tglakhir.Value.Month And date_tglawal.Value.Year = date_tglakhir.Value.Year Then
            header = "Periode " & date_tglawal.Value.ToString("MMMM yyyy")
        Else
            header = "Periode " & date_tglawal.Value.ToString("dd/MM/yyyy") & " s.d. " & date_tglakhir.Value.ToString("dd/MM/yyyy")
        End If

        Me.Cursor = Cursors.WaitCursor
        x.setVar(laptype, createQuery(laptype), header)
        x.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_exportxl.Click
        Me.Cursor = Cursors.WaitCursor
        ExportLaporan(laptype)
        Me.Cursor = Cursors.Default
    End Sub

    'UI
    Private Sub fr_hutang_bayar_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub

    'UI : POPUPSEARCH PANEL
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

    'UI : INPUT
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

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyUp
        keyshortenter(in_supplier_n, e)
    End Sub

    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_supplier_n.Enter, in_barang_n.Enter, in_gudang_n.Enter
        popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
        If popPnl_barang.Visible = False Then popPnl_barang.Visible = True

        If sender.Name = "in_supplier_n" Then
            popupstate = "supplier"
        ElseIf sender.Name = "in_barang_n" Then
            popupstate = "barang"
        Else
            popupstate = "gudang"
        End If
        loadDataBRGPopup(popupstate, sender.Text)
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_supplier_n.Leave, in_barang_n.Leave, in_gudang_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyDown, in_barang_n.KeyDown, in_gudang_n.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
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

    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyUp
        keyshortenter(in_gudang_n, e)
    End Sub

    'UI : COMBO BOX
    Private Sub cb_groupBy_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_groupBy.KeyPress
        e.Handled = True
    End Sub

    Private Sub cb_groupBy_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_groupBy.SelectionChangeCommitted
        laptype = cb_groupBy.SelectedValue
        If laptype = "lapKartuPersediaan" Then
            lapwintext = "Laporan Rincian Persediaan"
        ElseIf laptype = "lapKartuPersediaanGudang" Then
            lapwintext = "Laporan Rincian Persediaan Per Gudang"
        End If
    End Sub
End Class