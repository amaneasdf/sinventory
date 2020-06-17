Public Class fr_lap_filter_beli
    Private popupstate As String = "supplier"
    Private lapwintext As String = ""
    Private _parentPanel As Panel
    Private _parentForm As Form

    Public laptype As String
    Public jenis_sw As Boolean = True
    Public supplier_sw As Boolean = True
    Public barang_sw As Boolean = False

    Private Sub prcessSW()
        lbl_supplier.Visible = supplier_sw
        in_supplier.Visible = supplier_sw
        in_supplier_n.Visible = supplier_sw

        lbl_jenis.Visible = jenis_sw
        cb_jenis.Visible = jenis_sw

        lbl_barang.Visible = barang_sw
        in_barang.Visible = barang_sw
        in_barang_n.Visible = barang_sw

        Me.Text = lapwintext
    End Sub

    Private Sub formSW(tipe As String)
        Select Case laptype
            Case "lapBeliTgl"
                supplier_sw = False
            Case "lapBeliSupplierBarang", "lapBeliTglBarang"
                barang_sw = True
            Case "lapBeliTglNotaBarang"
                jenis_sw = False : barang_sw = True
        End Select
        prcessSW()
    End Sub

    'LOAD FORM
    Public Sub do_load(judulLap As String, tipeLap As String)
        laptype = tipeLap : lapwintext = judulLap
        lbl_title.Text = judulLap : Me.Text = judulLap

        With cb_jenis
            .DataSource = jenis("transbeli")
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 2
        End With

        With cb_pajak
            .DataSource = jenis("trans_pajak")
            .DisplayMember = "Text"
            .ValueMember = "Value"
        End With

        date_tglawal.Value = selectperiode.tglawal
        date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        'date_tglawal.MinDate = selectperiode.tglawal
        'date_tglakhir.MaxDate = selectperiode.tglakhir

        formSW(tipeLap)
        Me.ShowDialog(main)
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "supplier"
                q = "SELECT supplier_kode AS 'Kode', supplier_nama AS 'Nama' FROM data_supplier_master " _
                    & "WHERE supplier_status=1 AND (supplier_nama LIKE '%{0}%' OR supplier_kode LIKE '%{0}%')"
            Case "barang"
                If in_supplier.Text <> Nothing Then
                    q = "SELECT barang_kode as 'Kode', barang_nama as 'Nama' FROM data_barang_master " _
                        & "WHERE barang_status=1 AND barang_supplier='" & in_supplier.Text & "' AND (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%')"
                Else
                    q = "SELECT barang_kode as 'Kode', barang_nama as 'Nama' FROM data_barang_master " _
                        & "WHERE barang_status=1 AND (barang_nama LIKE '%{0}%' OR barang_kode LIKE '%{0}%')"
                End If
            Case Else
                Exit Sub
        End Select
        consoleWriteLine(String.Format(q, param))
        dt = getDataTablefromDB(String.Format(q, param))

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 135
            .Columns(1).Width = 200
        End With
    End Sub

    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "supplier"
                    in_supplier.Text = .Cells(0).Value
                    in_supplier_n.Text = .Cells(1).Value
                    If barang_sw = True Then in_barang.Focus() Else bt_simpanbeli.Focus()
                Case "barang"
                    in_barang.Text = .Cells(0).Value
                    in_barang_n.Text = .Cells(1).Value
                    bt_simpanbeli.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
    End Sub

    'CREATE MYSQL QUERY
    Private Function createQuery(tipe As String) As String
        Dim q As String = ""
        Dim _whrArr As New List(Of String)
        Dim _tipe As String = ""

        Select Case tipe
            Case "lapBeliNota", "lapBeliTgl", "lapBeliSupplier", "lapBeliTglNota", "lapBeliSupplierNota"
                If Not String.IsNullOrWhiteSpace(in_supplier.Text) Then _whrArr.Add(String.Format("faktur_supplier='{0}'", in_supplier.Text))
                If Not cb_jenis.SelectedValue = Nothing Then _whrArr.Add(String.Format("jenis IN({0})", cb_jenis.SelectedValue))

                If tipe = "lapBeliNota" Then : _tipe = "nota"
                ElseIf tipe = "lapBeliTgl" Then : _tipe = "tanggal"
                ElseIf tipe = "lapBeliSupplier" Then : _tipe = "supplier"
                ElseIf tipe = "lapBeliTglNota" Then : _tipe = "tanggalnota"
                ElseIf tipe = "lapBeliSupplierNota" Then : _tipe = "suppliernota"
                Else : Return String.Empty : Exit Function
                End If

                Return CreateQueryBeliNota("report", _tipe, date_tglawal.Value, date_tglakhir.Value, cb_pajak.SelectedValue, _whrArr)

            Case "lapBeliSupplierBarang", "lapBeliTglBarang"
                If Not String.IsNullOrWhiteSpace(in_supplier.Text) Then
                    _whrArr.Add(String.Format("faktur_supplier='{0}'", in_barang.Text))
                End If
                If Not String.IsNullOrWhiteSpace(in_barang.Text) Then
                    _whrArr.Add(String.Format("trans_barang='{0}'", in_barang.Text))
                End If
                If cb_jenis.SelectedValue <> Nothing Then
                    _whrArr.Add("jenis IN (" & cb_jenis.SelectedValue & ")")
                End If

                If tipe = "lapBeliSupplierBarang" Then : _tipe = "supplier"
                ElseIf tipe = "lapBeliTglBarang" Then : _tipe = "tanggal"
                Else : Return String.Empty : Exit Function
                End If

                Return CreateQueryBeliBarang("report", _tipe, date_tglawal.Value, date_tglakhir.Value, cb_pajak.SelectedValue, _whrArr)

            Case "lapBeliTglNotaBarang", "lapBeliSupplierNotaBarang"
                Dim _colselect As New List(Of String)
                Dim _qjoin, _qwh, _qorder As String

                q = "SELECT {0} FROM(" _
                    & "SELECT faktur_kode, faktur_tanggal_trans, faktur_supplier, faktur_gudang, faktur_ppn_jenis, trans_barang, " _
                    & "  trans_qty, trans_satuan, trans_harga_beli, trans_disc_rupiah, trans_disc1, trans_disc2, trans_disc3 " _
                    & " FROM data_pembelian_faktur " _
                    & " LEFT JOIN data_pembelian_trans ON trans_faktur=faktur_kode AND faktur_status=1 " _
                    & " WHERE faktur_tanggal_trans BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' AND faktur_status=1 AND faktur_ppn_jenis IN ({3}) {4} " _
                    & ")pembelian {5}"

                _colselect.AddRange({"faktur_kode dlap_faktur", "faktur_tanggal_trans dlap_tgl", "ref_text dlap_kat",
                                     "faktur_supplier dlap_supplier", "supplier_nama dlap_supplier_n",
                                     "faktur_gudang dlap_gudang", "gudang_nama dlap_gudang_n",
                                     "trans_barang dlap_barang", "barang_nama dlap_barang_n",
                                     "trans_harga_beli dlap_hargabeli", "trans_qty dlap_qty", "trans_satuan dlap_sat",
                                     "@subtotal:=trans_harga_beli*trans_qty dlap_subtot",
                                     "trans_disc_rupiah dlap_discrp", "@discrp:=trans_disc_rupiah*trans_qty dlap_discrp_n",
                                     "trans_disc1 dlap_disc1", "trans_disc2 dlap_disc2", "trans_disc3 dlap_disc3",
                                     "@disc1:=ROUND(IF(trans_disc1=0, 0, (@subtotal-@discrp) * (trans_disc1/100)),2) dlap_disc1_n",
                                     "@disc2:=ROUND(IF(trans_disc2=0, 0, (@subtotal-(@discrp+@disc1)) * (trans_disc2/100)),2) dlap_disc2_n",
                                     "@disc3:=ROUND(IF(trans_disc3=0, 0, (@subtotal-(@discrp+@disc1+@disc2)) * (trans_disc3/100)),2) dlap_disc3_n",
                                     "ROUND(@discrp+@disc1+@disc2+@disc3,2) dlap_disctot",
                                     "@subtotal-ROUND(@discrp+@disc1+@disc2+@disc3,2) dlap_jumlah"})

                If Not String.IsNullOrWhiteSpace(in_supplier.Text) Then _whrArr.Add(String.Format("faktur_supplier='{0}'", in_barang.Text))
                If Not String.IsNullOrWhiteSpace(in_barang.Text) Then _whrArr.Add(String.Format("trans_barang='{0}'", in_barang.Text))
                _qjoin = " LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                        & "LEFT JOIN data_barang_master ON barang_kode=trans_barang " _
                        & "LEFT JOIN data_barang_gudang ON gudang_kode=faktur_gudang " _
                        & "LEFT JOIN ref_jenis ON ref_status=1 AND ref_type='ppn_trans' AND ref_kode=faktur_ppn_jenis"
                _qwh = IIf(_whrArr.Count > 0, "AND " & String.Join(" AND ", _whrArr), "")
                _qorder = " ORDER BY faktur_tanggal_trans, faktur_kode"

                Return String.Format(q, String.Join(",", _colselect), date_tglawal.Value, date_tglakhir.Value, cb_pajak.SelectedValue, _qwh, _qjoin + _qorder)

            Case Else
                Return String.Empty
        End Select
    End Function

    Private Function CreateQueryBeliBarang(TipeOut As String, Grouping As String, StartDate As Date, EndDate As Date,
                                           KategoriPajak As String, Conditional As List(Of String)) As String
        If StartDate = Nothing Or EndDate = Nothing Then
            Throw New ArgumentNullException
        ElseIf StartDate > EndDate Then
            Throw New ArgumentException("StartDate Value cannot be bigger than EndDate value")
        End If

        Dim _q As String = ""
        Dim _selectCol As New List(Of String)
        Dim _ppnType As String = ""
        Dim _qjoin As String = "" : Dim _qwhr As String = "" : Dim _qorder As String = ""

        _q = "SELECT {0} FROM( " _
            & " SELECT 'BELI' jenis, faktur_kode, faktur_tanggal_trans, faktur_supplier, trans_barang, faktur_ppn_jenis, " _
            & "  IF(faktur_term=0, 'TUNAI', 'TEMPO') faktur_jenis_bayar, " _
            & "  countQTYItem(trans_barang, trans_qty, trans_satuan_type) qtybrg, " _
            & "  @subtotal:=trans_qty*trans_harga_beli subtot, " _
            & "  @diskon:=CountTotalDiskonBeliItem(@subtotal, trans_disc_rupiah*trans_qty, trans_disc1, trans_disc2, trans_disc3) diskon, " _
            & "  @subtotal-@diskon totalnilai " _
            & " FROM data_pembelian_faktur LEFT JOIN data_pembelian_trans ON faktur_kode=trans_faktur AND trans_status=1 " _
            & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' AND faktur_ppn_jenis IN ({3}) " _
            & " UNION " _
            & " SELECT 'RETUR' jenis, faktur_kode_bukti, faktur_tanggal_trans, faktur_supplier, trans_barang, faktur_ppn_jenis, ref_text, " _
            & "  countQTYItem(trans_barang, trans_qty, trans_satuan_type) qtybrg, " _
            & "  @subtot:=(trans_harga_retur*trans_qty) subtot, @diskon:=@subtot*(trans_diskon/100) diskon, @subtot-@diskon totalnilai " _
            & " FROM data_pembelian_retur_faktur LEFT JOIN data_pembelian_retur_trans ON faktur_kode_bukti=trans_faktur AND trans_status=1 " _
            & " LEFT JOIN ref_jenis ON ref_status=1 AND ref_type='bayar_retur' AND ref_kode=faktur_jen_bayar " _
            & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' AND faktur_ppn_jenis IN ({3}) " _
            & ") pembelian {4}"

        If Not Conditional.Count = 0 Then
            _qwhr = " WHERE " & String.Join(" AND ", Conditional)
        End If

        If Not {"report", "excel"}.Contains(LCase(TipeOut)) Then
            Return String.Empty : Exit Function
        End If

        Select LCase(Grouping)
            Case "supplier"
                _selectCol.AddRange({"faktur_supplier dlap_supplier",
                                     "GetMasterNama('supplier', faktur_supplier) dlap_supplier_n",
                                     "trans_barang dlap_barang",
                                     "GetMasterNama('barang', trans_barang) dlap_barang_n"
                                    })
                _qorder = " GROUP BY faktur_supplier, trans_barang, jenis"

            Case "tanggal"
                _selectCol.AddRange({"faktur_tanggal_trans dlap_tanggal",
                                    "trans_barang dlap_barang",
                                    "GetMasterNama('barang', trans_barang) dlap_barang_n"
                                   })
                _qorder = " GROUP BY faktur_tanggal_trans, trans_barang, jenis"

            Case Else
                Return String.Empty : Exit Function
        End Select

        _selectCol.AddRange({"jenis dlap_jenis",
                             "IFNULL(SUM(qtybrg),0) dlap_qty",
                             "getQTYdetail(trans_barang,IFNULL(SUM(qtybrg),0),2) dlap_qty_n",
                             "IFNULL(SUM(subtot),0) dlap_harga_beli",
                             "IFNULL(SUM(diskon),0) dlap_total_diskon",
                             "IFNULL(SUM(totalnilai),0) dlap_jumlah"
                            })

        Return String.Format(_q, String.Join(",", _selectCol), StartDate, EndDate, KategoriPajak, _qjoin + _qwhr + _qorder)
    End Function

    Private Function CreateQueryBeliNota(TipeOut As String, Grouping As String, StartDate As Date, EndDate As Date,
                                          KategoriPajak As String, Conditional As List(Of String)) As String
        If StartDate = Nothing Or EndDate = Nothing Then
            Throw New ArgumentNullException
        ElseIf StartDate > EndDate Then
            Throw New ArgumentException("StartDate Value cannot be bigger than EndDate value")
        End If

        Dim _q As String = ""
        Dim _selectCol As New List(Of String)
        Dim _ppnType As String = ""
        Dim _qjoin As String = "" : Dim _qwhr As String = "" : Dim _qorder As String = ""

        _q = "SELECT {0} FROM(" _
            & " SELECT 'BELI' jenis, faktur_kode, faktur_supplier, faktur_tanggal_trans, faktur_term, faktur_ppn_jenis, " _
            & "  IF(faktur_term=0, 'TUNAI', 'TEMPO') faktur_jenis_bayar, " _
            & "  ROUND(IF(faktur_ppn_jenis=1, faktur_jumlah*(10/11), faktur_jumlah),2) faktur_brutto, " _
            & "  ROUND(IF(faktur_ppn_jenis=1, faktur_disc*(10/11), faktur_disc),2) faktur_diskon, " _
            & "  ROUND(IF(faktur_ppn_jenis=1, faktur_jumlah*(1-(10/11))-faktur_disc*(1-(10/11)), faktur_ppn),2) faktur_ppn, " _
            & "  faktur_netto, faktur_klaim " _
            & " FROM data_pembelian_faktur " _
            & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' AND faktur_ppn_jenis IN ({3}) " _
            & " UNION " _
            & " SELECT 'RETUR', faktur_kode_bukti, faktur_supplier, faktur_tanggal_trans, NULL faktur_term, faktur_ppn_jenis, ref_text, " _
            & "  ROUND(IF(faktur_ppn_jenis=1, faktur_jumlah*(10/11),faktur_jumlah),2) faktur_brutto, " _
            & "  ROUND(IF(faktur_ppn_jenis=1, (faktur_jumlah-faktur_netto)*(10/11), faktur_jumlah-(faktur_netto-faktur_ppn)),2) faktur_diskon, " _
            & "  ROUND(IF(faktur_ppn_jenis=1, faktur_jumlah*(1-(10/11))-(faktur_jumlah-faktur_netto)*(1-(10/11)), faktur_ppn),2) faktur_ppn, " _
            & "  faktur_netto , NULL faktur_klaim " _
            & " FROM data_pembelian_retur_faktur " _
            & " LEFT JOIN ref_jenis ON ref_status=1 AND ref_type='bayar_retur' AND ref_kode=faktur_jen_bayar " _
            & " WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' AND faktur_ppn_jenis IN ({3}) " _
            & ")penjualan {4}"

        If Not Conditional.Count = 0 Then
            _qwhr = " WHERE " & String.Join(" AND ", Conditional)
        End If

        If Not {"report", "excel"}.Contains(LCase(TipeOut)) Then
            Return String.Empty : Exit Function
        End If

        Select Case LCase(Grouping)
            Case "nota"
                _selectCol.AddRange({"jenis beli_jenis",
                                     "faktur_kode beli_kode",
                                     "faktur_tanggal_trans beli_tgl",
                                     "ppn.ref_text lap_kat",
                                     "faktur_supplier beli_supplier",
                                     "GetMasterNama('supplier', faktur_supplier) beli_supplier_n",
                                     "faktur_jenis_bayar beli_jenisbayar",
                                     "faktur_term beli_term",
                                     "faktur_brutto beli_brutto",
                                     "faktur_diskon beli_diskon",
                                     "faktur_ppn beli_ppn",
                                     "faktur_netto beli_netto",
                                     "faktur_klaim beli_klaim"
                                    })
                _qjoin = " LEFT JOIN ref_jenis ppn ON faktur_ppn_jenis=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans'"
                _qorder = "ORDER BY faktur_tanggal_trans, faktur_kode"

            Case "supplier", "tanggal", "tanggalnota", "suppliernota"
                If LCase(Grouping) = "supplier" Then
                    _selectCol.AddRange({"faktur_supplier lap_supplier",
                                         "GetMasterNama('supplier', faktur_supplier) lap_supplier_n"
                                        })
                    _qorder = " GROUP BY faktur_supplier, jenis"

                ElseIf LCase(Grouping) = "tanggal" Then
                    _selectCol.AddRange({"faktur_tanggal_trans lap_tgl"})
                    _qorder = " GROUP BY faktur_tanggal_trans, jenis"

                ElseIf {"suppliernota", "tanggalnota"}.Contains(LCase(Grouping)) Then
                    _selectCol.AddRange({"faktur_tanggal_trans lap_tgl",
                                         "faktur_kode lap_faktur",
                                         "faktur_supplier lap_supplier",
                                         "GetMasterNama('supplier', faktur_supplier) lap_supplier_n",
                                         "ppn.ref_text lap_kat"
                                         })
                    If LCase(Grouping) = "suppliernota" Then
                        _qorder = " GROUP BY jenis, faktur_supplier, faktur_kode"
                    Else
                        _qorder = " GROUP BY jenis, faktur_tanggal_trans, faktur_kode"
                    End If
                    _qjoin = " LEFT JOIN ref_jenis ppn ON faktur_ppn_jenis=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans'"

                End If
                _selectCol.AddRange({"jenis lap_jenis",
                                     "SUM(IF(faktur_jenis_bayar!='TUNAI',faktur_brutto,0)) lap_brutto",
                                     "SUM(IF(faktur_jenis_bayar='TUNAI',faktur_brutto,0)) lap_tunai",
                                     "SUM(faktur_diskon) lap_diskon",
                                     "SUM(faktur_ppn) lap_ppn",
                                     "SUM(faktur_netto) lap_jumlah"
                                    })

            Case Else : Return String.Empty : Exit Function
        End Select

        Return String.Format(_q, String.Join(",", _selectCol), StartDate, EndDate, KategoriPajak, _qjoin + _qwhr + _qorder)
    End Function

    'EXPORT EXCEL
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
        ElseIf _tglawal = _tglakhir Then
            _periode = UCase(_tglawal.ToString("dd MMMM yyyy"))
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

                    Select Case LapType
                        Case "lapBeliNota"
                            _colHeader.AddRange({"JENISTRANS.", "NO.FAKTUR", "TANGGAL", "KAT.", "KD.SUPPLIER", "NAMASUPPLIER",
                                                 "JEN.BAYAR", "TERM.", "BRUTTO", "DISKON", "PPN", "JUMLAH", "BAYAR/TUNAI"})
                            _title.AddRange({"LAPORAN NOTA PEMBELIAN", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "lapBeliTgl", "lapBeliSupplier"
                            Dim fk_title As String = ""
                            If LapType = "lapBeliTgl" Then
                                _colHeader.AddRange({"TANGGAL"}) : fk_title = "TANGGAL"
                            Else
                                _colHeader.AddRange({"KD.SUPPLIER", "NAMASUPPLIER"}) : fk_title = "SUPPLIER"
                            End If
                            _colHeader.AddRange({"JENIS", "KREDIT", "TUNAI", "DISKON", "PPN", "JUMLAH"})
                            _title.AddRange({"LAPORAN PEMBELIAN PER " & fk_title, "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "lapBeliTglNota"
                            _colHeader.AddRange({"TANGGAL", "NO.FAKTUR", "KD.SUPPLIER", "NAMASUPPLIER", "KAT.", "JENIS", "KREDIT", "TUNAI", "DISKON", "PPN", "JUMLAH"})
                            _title.AddRange({"LAPORAN NOTA PEMBELIAN PER TANGGAL", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "lapBeliSupplierNota"
                            Dim _col() As String = {"lap_faktur", "lap_tanggal", "lap_jenis", "lap_kat", "lap_tunai", "lap_brutto", "lap_diskon", "lap_ppn", "lap_jumlah"}
                            _colHeader.AddRange({"NO.FAKTUR", "TANGGAL", "JENIS", "KAT.", "TUNAI", "BRUTTO", "DISKON", "PPN", "JUMLAH"})
                            _title.AddRange({"LAPORAN NOTA PEMBELIAN PER SUPPLIER", "PERIODE " & _periode})
                            Dim _headlist = New DataView(dtx).ToTable(True, {"lap_supplier", "lap_supplier_n"}).Select("", "lap_supplier ASC")
                            For Each row As DataRow In _headlist
                                _subtitle.Add({"SUPPLIER", row.ItemArray(0), row.ItemArray(1)})
                                Dim _expression = String.Format("lap_supplier='{0}'", row.ItemArray(0))
                                _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, _col))
                            Next

                        Case "lapBeliSupplierBarang", "lapBeliTglBarang"
                            Dim fk_title As String = "" : Dim _col() As String
                            If LapType = "lapBeliSupplierBarang" Then
                                fk_title = "SUPPLIER"
                                _colHeader.AddRange({"KD.SUPPLIER", "NAMASUPPLIER"})
                                _col = {"dlap_supplier", "dlap_supplier_n", "dlap_jenis", "dlap_barang", "dlap_barang_n", "dlap_qty", "dlap_qty_n",
                                        "dlap_harga_beli", "dlap_total_diskon", "dlap_jumlah"}
                            Else
                                fk_title = "TANGGAL"
                                _colHeader.Add("TANGGAL")
                                _col = {"dlap_tanggal", "dlap_jenis", "dlap_barang", "dlap_barang_n", "dlap_qty", "dlap_qty_n",
                                        "dlap_harga_beli", "dlap_total_diskon", "dlap_jumlah"}
                            End If
                            _colHeader.AddRange({"JENIS", "KD.BARANG", "NAMABARANG", "QTY", "KONVERSI", "SUBTOTAL", "DISKON", "TOTAL"})
                            _title.AddRange({"LAPORAN PEMBELIAN BARANG PER " & fk_title, "PERIODE " & _periode})
                            _dt.Add(New DataView(dtx).ToTable(False, _col))

                        Case "lapBeliTglNotaBarang", "lapBeliSupplierNotaBarang"
                            Dim fk_title As String = "" : Dim _col As New List(Of String)
                            Dim _headlist() As DataRow : Dim _expression As String = ""
                            If LapType = "lapBeliSupplierNotaBarang" Then
                                fk_title = "SUPPLIER"
                                _colHeader.AddRange({"NO.FAKTUR", "TANGGAL", "KAT."})
                                _col.AddRange({"dlap_faktur", "dlap_tanggal", "dlap_kat"})
                                _headlist = New DataView(dtx).ToTable(True, {"dlap_supplier", "dlap_supplier_n"}).Select("", "dlap_supplier ASC")
                            Else
                                fk_title = "TANGGAL"
                                _colHeader.AddRange({"NO.FAKTUR", "KAT.", "KD.SUPPLIER", "NAMASUPPLIER"})
                                _col.AddRange({"dlap_faktur", "dlap_kat", "dlap_supplier", "dlap_supplier_n"})
                                _headlist = New DataView(dtx).ToTable(True, {"dlap_tanggal"}).Select("", "dlap_tanggal ASC")
                            End If
                            _title.AddRange({"LAPORAN PEMBELIAN DISTRIBUTOR PER " & fk_title, "PERIODE " & _periode})
                            _colHeader.AddRange({"KD.GUDANG", "NAMAGUDANG", "KD.BARANG", "NAMA BARANG", "HARGABELI", "QTY", "SATUAN", "TOT.DISKON", "TOTALBELI",
                                                 "DISCRP", "TOT.DISCRP", "DISC1", "TOT.DISC1", "DISC2", "TOT.DISC2", "DISC3"})
                            _col.AddRange({"dlap_gudang", "dlap_gudang_n", "dlap_barang", "dlap_barang_n", "dlap_hargabeli", "dlap_qty", "dlap_sat",
                                           "dlap_disctot", "dlap_jumlah", "dlap_discrp", "dlap_discrp_n", "dlap_disc1", "dlap_disc1_n",
                                           "dlap_disc2", "dlap_disc2_n", "dlap_disc3", "dlap_disc3_n"})
                            For Each row As DataRow In _headlist
                                If LapType = "" Then
                                    _subtitle.Add({"SUPPLIER", row.ItemArray(0), row.ItemArray(1)})
                                    _expression = String.Format("dlap_supplier = '{0}'", row.ItemArray(0))
                                Else
                                    _subtitle.Add({"TANGGAL", CDate(row.ItemArray(0)).ToShortDateString})
                                    _expression = String.Format("dlap_tanggal = '{0}'", row.ItemArray(0))
                                End If
                                _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, _col.ToArray))
                            Next

                        Case Else : Exit Sub
                    End Select

                    Using dd As New SaveFileDialog
                        dd.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
                        dd.FilterIndex = 1
                        dd.FileName = dd.InitialDirectory
                        dd.RestoreDirectory = True : dd.AddExtension = True
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
                End Using
            Else

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
        Cursor = Cursors.WaitCursor
        Dim x As New fr_lap_beli_nota_view With {
                    .inlap_type = laptype,
                    .Text = lapwintext,
                    .inquery = createQuery(laptype),
                    .intglawal = date_tglawal.Value.ToString("dd/MM/yyyy"),
                    .intglakhir = date_tglakhir.Value.ToString("dd/MM/yyyy")
                }
        x.ShowDialog(Me)
        Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_exportxl.Click
        Me.Cursor = Cursors.WaitCursor
        ExportLaporan(laptype)
        Me.Cursor = Cursors.Default
    End Sub

    'UI
    '------------- POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_supplier_n.Focused Or in_barang_n.Focused Then
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

    '------------- INPUT
    Private Sub date_tglawal_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglawal.KeyUp
        keyshortenter(date_tglakhir, e)
    End Sub

    Private Sub date_tglawal_ValueChanged(sender As Object, e As EventArgs) Handles date_tglawal.ValueChanged
        date_tglakhir.MinDate = date_tglawal.Value
    End Sub

    Private Sub date_tglakhir_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglakhir.KeyUp
        keyshortenter(IIf(jenis_sw = False, in_supplier_n, cb_jenis), e)
    End Sub

    Private Sub date_tglakhir_ValueChanged(sender As Object, e As EventArgs) Handles date_tglakhir.ValueChanged
        date_tglawal.MaxDate = date_tglakhir.Value
    End Sub

    Private Sub cb_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_jenis.KeyPress
        If e.KeyChar <> ControlChars.CrLf Then
            e.Handled = True
        End If
    End Sub

    Private Sub cb_jenis_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_jenis.KeyUp
        keyshortenter(IIf(supplier_sw = False, bt_simpanbeli, in_supplier_n), e)
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        keyshortenter(in_supplier_n, e)
    End Sub

    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_supplier_n.Enter, in_barang_n.Enter
        popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
        If popPnl_barang.Visible = False Then popPnl_barang.Visible = True

        Select Case sender.Name
            Case "in_supplier_n"
                popupstate = "supplier"
            Case Else
                popupstate = "barang"
        End Select
        loadDataBRGPopup(popupstate, sender.Text)
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_supplier_n.Leave, in_barang_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyDown, in_barang_n.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyUp, in_barang_n.KeyUp
        Dim _nxtcontrol As Object
        Dim _kdcontrol As Object
        Select Case sender.Name.ToString
            Case "in_supplier_n"
                _nxtcontrol = IIf(barang_sw = True, in_barang_n, bt_simpanbeli)
                _kdcontrol = in_supplier
            Case "in_barang_n"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = in_barang
            Case Else
                Exit Sub
        End Select

        If sender.Text = "" And IsNothing(_kdcontrol) = False Then _kdcontrol.Text = ""

        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then dgv_listbarang.Focus()

        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then setPopUpResult()

            keyshortenter(_nxtcontrol, e)
        Else
            If e.KeyCode <> Keys.Escape Then
                If popPnl_barang.Visible = False Then popPnl_barang.Visible = True

                loadDataBRGPopup(popupstate, sender.Text)
            End If
        End If
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        keyshortenter(in_barang_n, e)
    End Sub

    Private Sub fr_hutang_bayar_Click(sender As Object, e As EventArgs) Handles MyBase.Click, pnl_content.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub
End Class