Public Class fr_lap_filter_hutang
    Private popupstate As String = "supplier"
    Private lapwintext As String = ""
    Public laptype As String
    Public bayar_sw As Boolean = False
    Private pajak_sw As Boolean = True
    Public supplier_sw As Boolean = True
    Public faktur_sw As Boolean = False
    Public tgltrans_sw As Boolean = True
    Public periode_sw As Boolean = False

    'LOAD
    Public Sub do_load(judulLap As String, tipeLap As String)
        laptype = tipeLap : lapwintext = judulLap

        date_tglawal.Value = selectperiode.tglawal
        date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        date_tglawal.MinDate = selectperiode.tglawal
        date_tglakhir.MaxDate = selectperiode.tglakhir

        lbl_periodedata.Text = main.strip_periode.Text
        formSW(tipeLap)
        Me.ShowDialog(main)
    End Sub

    Private Sub prcessSW()
        lbl_supplier.Visible = supplier_sw
        in_supplier.Visible = supplier_sw
        in_supplier_n.Visible = supplier_sw

        lbl_bayar.Visible = bayar_sw
        cb_bayar.Visible = bayar_sw

        lbl_pajak.Visible = pajak_sw
        cb_pajak.Visible = pajak_sw

        lbl_faktur.Visible = faktur_sw
        in_faktur.Visible = faktur_sw

        lbl_tgl.Visible = tgltrans_sw
        lbl_tgl2.Visible = tgltrans_sw
        date_tglawal.Visible = tgltrans_sw
        date_tglakhir.Visible = tgltrans_sw

        Me.Text = lapwintext
    End Sub

    Private Sub formSW(tipe As String)
        Dim _pajak As String = "trans_pajak2"

        Select Case LCase(tipe)
            Case "h_nota", "h_notabeli", "h_kartuhutang"
                If LCase(tipe) = "h_notabeli" Then _pajak = "trans_pajak"
                If LCase(tipe) = "h_kartuhutang" Then date_tglawal.Enabled = False

            Case "h_titipsupplier", "h_titipsupplier_det"
                pajak_sw = False

            Case "h_bayarnota"

            Case Else
                Exit Sub
        End Select

        cb_bayar.DataSource = jenis("bayarhutang")
        cb_pajak.DataSource = jenis(_pajak)
        For Each cb As ComboBox In {cb_bayar, cb_pajak}
            cb.DisplayMember = "Text"
            cb.ValueMember = "Value"
        Next
        prcessSW()
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable


        Select Case tipe
            Case "supplier"
                q = "SELECT supplier_kode AS 'Kode', supplier_nama AS 'Nama' FROM data_supplier_master " _
                    & "WHERE supplier_status=1 AND (supplier_nama LIKE '{0}%' OR supplier_kode LIKE '{0}%')"
            Case "faktur"
                If in_supplier.Text <> Nothing Then
                    q = "SELECT hutang_faktur as 'Kode Faktur', supplier_kode as 'Kode Supplier', supplier_nama AS 'Supplier' " _
                        & "FROM data_hutang_awal " _
                        & "LEFT JOIN data_supplier_master ON supplier_kode=hutang_supplier " _
                        & "WHERE hutang_status=1 AND faktur_supplier='" & in_supplier.Text & "' AND hutang_faktur LIKE '{0}%'"
                Else
                    q = "SELECT hutang_faktur as 'Kode Faktur', supplier_kode as 'Kode Supplier', supplier_nama AS 'Supplier' " _
                        & "FROM data_hutang_awal " _
                        & "LEFT JOIN data_supplier_master ON supplier_kode=hutang_supplier " _
                        & "WHERE hutang_status=1 AND hutang_faktur LIKE '{0}%'"
                End If
            Case Else
                Exit Sub
        End Select

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                dt = x.GetDataTable(String.Format(q, param))
            Else
                MessageBox.Show("Tidak dapat terhubung ke database", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using

        With dgv_listbarang
            .DataSource = dt
            If .ColumnCount >= 2 Then
                .Columns(0).Width = 135
                .Columns(1).Width = 200
            End If
        End With
    End Sub

    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "supplier"
                    in_supplier.Text = .Cells(0).Value
                    in_supplier_n.Text = .Cells(1).Value
                    'If faktur_sw = True Then in_faktur.Focus() Else bt_simpanbeli.Focus()
                Case "faktur"
                    in_faktur.Text = .Cells(0).Value
                    in_supplier.Text = .Cells(1).Value
                    in_supplier_n.Text = .Cells(2).Value
                    'bt_simpanbeli.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        popPnl_barang.Visible = False
    End Sub

    'CREATE MYSQL QUERY
    Private Function createQuery(tipe As String) As String
        Dim q As String = ""
        Dim _qjoin, _qorder, _qwh As String
        Dim _colSelect As New List(Of String)
        Dim _whrArr As New List(Of String)

        Select Case LCase(tipe)
            Case "h_nota" 'BASED periode,supplier;OPT saldo_sisa
                q = "SELECT {0} FROM( " _
                    & " SELECT hutang_faktur, hutang_tgl, hutang_tgl_jt, hutang_supplier, hutang_pajak, hutang_status_lunas, hutang_tgl_lunas " _
                    & " FROM data_hutang_awal " _
                    & " WHERE hutang_status IN (1,2) AND hutang_tgl<='{2:yyyy-MM-dd}' AND hutang_pajak IN ({3}) " _
                    & "  AND (hutang_status_lunas = 0 OR hutang_tgl_lunas >= '{1:yyyy-MM-dd}') " _
                    & " ORDER BY hutang_tgl, hutang_faktur " _
                    & ")hutangawal {4}"
                If Not String.IsNullOrWhiteSpace(in_supplier.Text) Then _whrArr.Add("hutang_supplier='" & in_supplier.Text & "'")


                _colSelect.AddRange({"hutang_faktur hn_faktur",
                                     "hutang_tgl_jt hn_jt",
                                     "hutang_supplier hn_supplier",
                                     "supplier_nama hn_supplier_n",
                                     String.Format("@awal:= GetHutangSaldo('awal',hutang_faktur,'{0:yyyy-MM-dd}','{1:yyyy-MM-dd}') hn_saldoawal",
                                                   selectperiode.tglawal, selectperiode.tglakhir),
                                     String.Format("@beli:= GetHutangSaldo('beli',hutang_faktur,'{0:yyyy-MM-dd}','{1:yyyy-MM-dd}') hn_beli",
                                                   selectperiode.tglawal, selectperiode.tglakhir),
                                     String.Format("(@retur:= GetHutangSaldo('retur',hutang_faktur,'{0:yyyy-MM-dd}','{1:yyyy-MM-dd}'))*-1 hn_retur",
                                                   selectperiode.tglawal, selectperiode.tglakhir),
                                     String.Format("(@bayar:= GetHutangSaldo('bayar',hutang_faktur,'{0:yyyy-MM-dd}','{1:yyyy-MM-dd}') " _
                                                   & "+ GetHutangSaldo('tolak',hutang_faktur,'{0:yyyy-MM-dd}','{1:yyyy-MM-dd}'))*-1 hn_bayar",
                                                   selectperiode.tglawal, selectperiode.tglakhir),
                                     "ROUND(@awal + @beli + @retur + @bayar, 2) hn_sisa"
                                    })
                _qjoin = " LEFT JOIN data_supplier_master FORCE INDEX(supplier_idx3) ON supplier_kode=hutang_supplier"
                _qwh = IIf(_whrArr.Count > 0, " WHERE " & String.Join(" AND ", _whrArr), "")
                _qorder = ""

                Return String.Format(q, String.Join(",", _colSelect), date_tglawal.Value, date_tglakhir.Value, cb_pajak.SelectedValue, _qjoin + _qwh + _qorder)
                Exit Function

            Case "h_notabeli" 'HUTANG BERDASARKAN PEMBELIAN DALAM KURUN WAKTU TERTENTU (+YG SUDAH LUNAS)
                q = "SELECT faktur_kode psl2_faktur, faktur_tanggal_trans psl2_tgl, " _
                    & "faktur_supplier psl2_sales, supplier_nama psl2_sales_n, " _
                    & "faktur_term psl2_term, ADDDATE(faktur_tanggal_trans, faktur_term) psl2_jt, " _
                    & "faktur_jumlah + IF(faktur_ppn_jenis=2, faktur_ppn, 0) psl2_brutto, " _
                    & "faktur_disc + faktur_klaim psl2_potongan, " _
                    & "@hutang:= GetHutangSaldo('hutang',faktur_kode,'{2:yyyy-MM-dd}','{3:yyyy-MM-dd}') psl2_penjualan, " _
                    & "@bayar := GetHutangSaldo('bayar',faktur_kode,'{2:yyyy-MM-dd}','{3:yyyy-MM-dd}')*-1 psl2_bayar, " _
                    & "@retur := GetHutangSaldo('retur',faktur_kode,'{2:yyyy-MM-dd}','{3:yyyy-MM-dd}')*-1 psl2_retur, " _
                    & "ROUND(@hutang-@bayar-@retur,2) psl2_sisa " _
                    & "FROM data_pembelian_faktur " _
                    & "LEFT JOIN data_supplier_master FORCE INDEX(supplier_idx3) ON supplier_kode=faktur_supplier " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}' " _
                    & " AND faktur_ppn_jenis IN ({4}) {5}"

                If Not String.IsNullOrWhiteSpace(in_supplier.Text) Then _whrArr.Add("faktur_supplier='" & in_supplier.Text & "'")
                _qwh = IIf(_whrArr.Count > 0, " AND " & String.Join(" AND ", _whrArr), "")

                Return String.Format(q, date_tglawal.Value, date_tglakhir.Value, selectperiode.tglawal, selectperiode.tglakhir, cb_pajak.SelectedValue, _qwh)
                Exit Function

            Case "h_titipsupplier", "h_titipsupplier_det" 'BASED supplier, tgl_akhir;OPT saldo_Sisa
                q = "SELECT {0} FROM( " _
                     & " SELECT h_titip_ref t_supplier, h_titip_id t_id, h_titip_tgl t_tgl, h_titip_nilai t_nilai, h_titip_tipe t_jenis, h_titip_faktur t_ref " _
                    & " FROM data_hutang_titip " _
                    & " WHERE h_titip_status=1 AND h_titip_tgl BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' " _
                    & " UNION " _
                    & " SELECT DISTINCT h_titip_ref t_supplier, 0 t_id, '{1:yyyy-MM-dd}' t_tgl, GetHutangSaldoAwal('titipan', h_titip_ref, '{1:yyyy-MM-dd}'), " _
                    & "  'awal' t_jenis, '' t_ref " _
                    & " FROM data_hutang_titip " _
                    & " WHERE h_titip_status=1 AND h_titip_tgl BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' " _
                    & " GROUP BY h_titip_ref " _
                    & ")titipan {3}"

                If Not String.IsNullOrWhiteSpace(in_supplier.Text) Then _whrArr.Add("t_supplier='" & in_supplier.Text & "'")

                If LCase(tipe) = "h_titipsupplier" Then
                    _colSelect.AddRange({"t_supplier t_custo",
                                         "supplier_nama t_custo_n",
                                         "SUM(IF(t_jenis='awal', t_nilai,0)) t_awal",
                                         "SUM(IF(t_jenis='retur', t_nilai,0)) t_titip",
                                         "SUM(IF(t_jenis='bayar', t_nilai,0)) t_bayar"
                                        })
                    _qjoin = " LEFT JOIN data_supplier_master FORCE INDEX(supplier_idx3) ON supplier_kode=t_supplier"
                    _qorder = " GROUP BY t_custo"
                    _qwh = IIf(_whrArr.Count > 0, " WHERE " & String.Join(" AND ", _whrArr), "")

                    Return String.Format(q, String.Join(",", _colSelect), date_tglawal.Value, date_tglakhir.Value, _qjoin + _qwh + _qorder)
                    Exit Function

                ElseIf LCase(tipe) = "h_titipsupplier_det" Then
                    _colSelect.AddRange({"t_supplier t_custo",
                                         "supplier_nama t_custo_n",
                                         "t_tgl",
                                         "IFNULL(ref_text, 'ERROR') t_ket",
                                         "t_ref",
                                         "IF(t_nilai<0, t_nilai*-1, 0) t_debet",
                                         "IF(t_nilai>0, t_nilai, 0) t_kredit"
                                        })
                    _qjoin = " LEFT JOIN data_supplier_master FORCE INDEX(supplier_idx3) ON supplier_kode=t_supplier " _
                            & "LEFT JOIN ref_jenis ON ref_status=1 AND ref_kode=t_jenis AND ref_type='piutang_titip'"
                    _qorder = " ORDER BY t_supplier, t_tgl, t_id"
                    _qwh = IIf(_whrArr.Count > 0, " WHERE " & String.Join(" AND ", _whrArr), "")

                    Return String.Format(q, String.Join(",", _colSelect), date_tglawal.Value, date_tglakhir.Value, _qjoin + _qwh + _qorder)
                    Exit Function
                End If

            Case "h_kartuhutang", "p_kartupiutangnota" 'BASED periode,supplier;OPT 
                Dim _grouping As String = ""
                Dim _colSaldoAwal As String = ""

                q = "SELECT {0} FROM( " _
                    & " SELECT {1}, '{3:yyy-MM-dd}' h_tgl, hutang_pajak h_kat, 'SALDO AWAL' h_ket, " _
                    & "  '' h_ref, SUM(GetHutangSaldo('awal', hutang_faktur, '{3:yyy-MM-dd}', '{4:yyy-MM-dd}')) h_debet, 0 h_kredit " _
                    & " FROM data_hutang_awal " _
                    & " WHERE hutang_status IN (1,2) AND hutang_tgl<='{4:yyy-MM-dd}' AND (hutang_status_lunas = 0 OR hutang_tgl_lunas >= '{3:yyy-MM-dd}') " _
                    & "  AND hutang_pajak IN({5}) " _
                    & " GROUP BY {2}, hutang_pajak " _
                    & " UNION " _
                    & " SELECT hutang_supplier, h_trans_id, h_trans_kode_hutang, h_trans_tgl, hutang_pajak, " _
                    & "  jenis.ref_text, h_trans_faktur, IF(h_trans_nilai>0, h_trans_nilai, 0), IF(h_trans_nilai<0, h_trans_nilai*-1, 0) " _
                    & " FROM data_hutang_trans " _
                    & " LEFT JOIN data_hutang_awal ON h_trans_kode_hutang=hutang_faktur " _
                    & " LEFT JOIN ref_jenis jenis ON jenis.ref_kode=h_trans_jenis AND jenis.ref_status=1 AND jenis.ref_type='hutang_trans' " _
                    & " WHERE hutang_status IN (1,2) AND h_trans_status=1 AND h_trans_tgl BETWEEN '{3:yyy-MM-dd}' AND '{4:yyy-MM-dd}' " _
                    & "  AND h_trans_jenis NOT IN ('migrasi') AND hutang_pajak IN({5}) " _
                    & ") detailtrans {6}"

                If Not String.IsNullOrWhiteSpace(in_supplier.Text) Then _whrArr.Add("h_supplier='" & in_supplier.Text & "'")
                If Not String.IsNullOrWhiteSpace(in_faktur.Text) Then _whrArr.Add("h_kode='" & in_faktur.Text & "'")

                If LCase(tipe) = "h_kartuhutang" Then
                    _colSaldoAwal = "hutang_supplier h_supplier, 0 h_id, '' h_kode"
                    _grouping = "hutang_supplier"
                    _qorder = " ORDER BY h_supplier, h_tgl, h_id"

                ElseIf LCase(tipe) = "h_kartuhutangnota" Then
                    _colSaldoAwal = "hutang_supplier h_supplier, 0 h_id, hutang_faktur h_kode"
                    _grouping = "hutang_faktur"
                    _qorder = " ORDER BY h_supplier, h_kode, h_tgl, h_id"

                Else
                    Return String.Empty : Exit Function
                End If

                _colSelect.AddRange({"h_supplier pk_custo", "supplier_nama pk_custo_n",
                                     "supplier_alamat pk_custo_k", "h_tgl pk_tgl",
                                     "h_ref pk_no_bukti", "ref_text pk_kat",
                                     "h_ket pk_ket", "h_kode pk_ref",
                                     "h_debet pk_debet", "h_kredit pk_kredit"
                                    })
                _qjoin = " LEFT JOIN data_supplier_master FORCE INDEX(supplier_idx3) ON supplier_kode=h_supplier " _
                        & "LEFT JOIN ref_jenis ON h_kat=ref_kode AND ref_status=1 AND ref_type='ppn_trans2'"
                _qwh = IIf(_whrArr.Count > 0, " WHERE " & String.Join(" AND ", _whrArr), "")

                Return String.Format(q, String.Join(",", _colSelect), _colSaldoAwal, _grouping, date_tglawal.Value, date_tglakhir.Value,
                                     cb_pajak.SelectedValue, _qjoin + _qwh + _qorder)
                Exit Function

            Case "h_bayarnota"
                q = "SELECT {0} FROM( " _
                    & " SELECT hutang_supplier, h_trans_id, h_trans_kode_hutang, hutang_tgl, hutang_pajak, " _
                    & "  GetHutangSaldo('awal',hutang_faktur,'{1:yyy-MM-dd}', '{2:yyy-MM-dd}') + " _
                    & "     GetHutangSaldo('beli',hutang_faktur,'{1:yyy-MM-dd}', '{2:yyy-MM-dd}') h_saldoawal, " _
                    & "  IFNULL(h_bayar_jenis_bayar, (CASE h_trans_jenis " _
                    & "     WHEN 'retur' THEN 'RETUR' WHEN 'tolak' THEN 'BGTOLAK' WHEN 'cair' THEN 'BGCAIR' ELSE '-' END)) h_jenis, " _
                    & "  h_trans_nilai, h_trans_faktur, h_trans_tgl " _
                    & " FROM data_hutang_trans " _
                    & " LEFT JOIN data_hutang_awal ON h_trans_kode_hutang=hutang_faktur " _
                    & " LEFT JOIN data_hutang_bayar ON h_trans_faktur=h_bayar_bukti " _
                    & " WHERE hutang_status IN (1,2) AND h_trans_status=1 AND h_trans_tgl BETWEEN '{1:yyy-MM-dd}' AND '{2:yyy-MM-dd}'" _
                    & "  AND h_trans_jenis NOT IN ('beli','migrasi') AND hutang_pajak IN({3}) " _
                    & ") pembayaran {4}"

                _colSelect.AddRange({"hutang_supplier pbd_custo", "supplier_nama pbd_custo_n",
                                     "h_trans_kode_hutang pbd_faktur", "hutang_tgl pbd_tanggal",
                                     "ref_text pbd_kat", "h_saldoawal pbd_saldoawal",
                                     "IF(h_jenis='RETUR', h_trans_nilai *-1, 0) pbd_retur",
                                     "IF(h_jenis NOT IN('RETUR', 'BGTOLAK'), h_trans_nilai * -1, 0) pbd_bayar",
                                     "IF(h_jenis='BGTOLAK', h_trans_nilai *-1, 0) pbd_tolak",
                                     "h_trans_tgl pbd_tglbayar", "CONCAT_WS(':',h_trans_faktur,h_jenis) pbd_ket",
                                     "DATEDIFF(h_trans_tgl, hutang_tgl) pbd_hari"
                                    })

                If Not String.IsNullOrWhiteSpace(in_supplier.Text) Then _whrArr.Add("hutang_supplier='" & in_supplier.Text & "'")
                If Not String.IsNullOrWhiteSpace(in_faktur.Text) Then _whrArr.Add("h_trans_kode_hutang='" & in_faktur.Text & "'")
                _qwh = IIf(_whrArr.Count > 0, " WHERE " & String.Join(" AND ", _whrArr), "")
                _qjoin = " LEFT JOIN data_supplier_master FORCE INDEX(supplier_idx3) ON supplier_kode=hutang_supplier " _
                        & "LEFT JOIN ref_jenis ON hutang_pajak=ref_kode AND ref_status=1 AND ref_type='ppn_trans2'"
                _qorder = " ORDER BY hutang_supplier, h_trans_kode_hutang, h_trans_tgl, h_trans_id"

                Return String.Format(q, String.Join(",", _colSelect), date_tglawal.Value, date_tglakhir.Value, cb_pajak.SelectedValue, _qjoin + _qwh + _qorder)
                Exit Function

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

                    Select Case LapType
                        Case "h_nota"
                            _colHeader.AddRange({"KODE PIUTANG", "TGL. JTH TEMPO", "KD.SUPPLIER", "NAMA SUPPLIER", "SALDOAWAL", "PEMBELIAN", "RETUR", "BAYAR", "SISA"})
                            _title.AddRange({"LAPORAN NOTA HUTANG SUPPLIER", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "h_notabeli"
                            _colHeader.AddRange({"KODE PIUTANG", "TGL.TRANSAKSI", "KD.SUPPLIER", "NAMA SUPPLIER", "TERM", "JTH TEMPO", "BRUTTO", "POTONGAN", "HUTANG", "BAYAR", "RETUR", "SISA"})
                            _title.AddRange({"LAPORAN HUTANG PEMBELIAN", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "h_titipsupplier"
                            _colHeader.AddRange({"KD.SUPPLIER", "NAMA SUPPLIER", "SALDOWAL", "TITIPAN", "PEMBAYARAN"})
                            _title.AddRange({"LAPORAN PIUTANG TITIPAN SUPPLIER", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "h_titipsupplier_det"
                            _colHeader.AddRange({"TANGGAL", "KETERANGAN", "REFERENSI", "DEBET", "KREDIT"})
                            _title.AddRange({"LAPORAN DETAIL PIUTANG TITIPAN SUPPLIER", "PERIODE " & _periode})

                            Dim _custolist = New DataView(dtx).ToTable(True, {"t_custo", "t_custo_n"}).Select("", "t_custo ASC")
                            For Each row As DataRow In _custolist
                                _subtitle.Add({row.ItemArray(0), row.ItemArray(1), row.ItemArray(2)})
                                Dim _expression = String.Format("t_custo = '{0}'", row.ItemArray(0))
                                _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, {"t_tgl", "t_ket", "t_ref", "t_debet", "t_kredit"}))
                            Next

                        Case "h_kartuhutang"
                            _colHeader.AddRange({"TGL.TRANSAKSI", "KD.BUKTI", "KAT.", "KETERANGAN", "REFERENSI", "DEBET", "KREDIT"})
                            _title.AddRange({"KARTU HUTANG", "PERIODE " & _periode})

                            Dim _custolist = New DataView(dtx).ToTable(True, {"pk_custo", "pk_custo_n", "pk_custo_k"}).Select("", "pk_custo ASC")
                            For Each row As DataRow In _custolist
                                _subtitle.Add({row.ItemArray(0), row.ItemArray(1), row.ItemArray(2)})
                                Dim _expression = String.Format("pk_custo = '{0}'", row.ItemArray(0))
                                _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, {"pk_tgl", "pk_no_bukti", "pk_kat", "pk_ket", "pk_ref", "pk_debet", "pk_kredit"}))
                            Next

                        Case "h_bayarnota"
                            _colHeader.AddRange({"KD.SUPPLIER", "NAMA SUPPLIER", "NO.FAKTUR", "TGL.FAKTUR", "KAT.", "SALDOAWAL", "RETUR", "PEMBAYARAN",
                                                 "BATAL/TOLAK", "TGL.BAYAR", "KETERANGAN", "HARI"})
                            _title.AddRange({"LAPORAN PEMBAYARAN HUTANG PER NOTA", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case Else : Exit Sub
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

    'UI : BUTTON
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        Dim x As New fr_view_piutang With {
                    .Text = lapwintext
                }
        Dim _periode As String = ""
        Dim _tglawal As Date = date_tglawal.Value
        Dim _tglakhir As Date = date_tglakhir.Value

        If _tglawal.ToString("MMyyyy") = _tglakhir.ToString("MMyyyy") And _tglawal.Day = 1 And _tglakhir = DateSerial(_tglakhir.Year, _tglakhir.Month + 1, 0) Then
            _periode = "Periode " & _tglawal.ToString("MMMM yyyy")
        Else
            _periode = date_tglawal.Value.ToString("dd/MM/yyyy") & " S.d " & date_tglakhir.Value.ToString("dd/MM/yyyy")
        End If

        Me.Cursor = Cursors.WaitCursor
        x.setVar(laptype, createQuery(laptype), _periode)
        x.ShowDialog(Me)
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

    '------------- POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_supplier_n.Focused Or in_faktur.Focused Then
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
                Case "supplier"
                    x = in_supplier_n
                Case "barang"
                    x = in_faktur
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
    Private Sub cb_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_bayar.KeyPress, cb_pajak.KeyPress
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    Private Sub date_tglawal_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglawal.KeyUp
        keyshortenter(date_tglakhir, e)
    End Sub

    Private Sub date_tglawal_ValueChanged(sender As Object, e As EventArgs) Handles date_tglawal.ValueChanged
        date_tglakhir.MinDate = date_tglawal.Value
    End Sub

    Private Sub date_tglakhir_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglakhir.KeyUp
        keyshortenter(in_supplier_n, e)
    End Sub

    Private Sub date_tglakhir_ValueChanged(sender As Object, e As EventArgs) Handles date_tglakhir.ValueChanged
        date_tglawal.MaxDate = date_tglakhir.Value
    End Sub

    Private Sub cb_periode_SelectionChangeCommitted(sender As Object, e As EventArgs)
        'readcommd("SELECT tutupbk_periode_tglawal, tutupbk_periode_tglakhir FROM data_tutup_buku WHERE tutupbk_status=1 AND tutupbk_id='" & cb_periode.SelectedValue & "'")
        'If rd.HasRows Then
        '    'date_tglawal.MaxDate = rd.Item(1)
        '    'date_tglawal.MinDate = rd.Item(0)
        '    'date_tglakhir.MaxDate = rd.Item(1)
        '    'date_tglakhir.MinDate = rd.Item(0)
        '    date_tglawal.Value = rd.Item(0)
        '    date_tglakhir.Value = rd.Item(1)
        'End If
        'rd.Close()

        'date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        keyshortenter(in_supplier_n, e)
    End Sub

    Private Sub in_supplier_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyDown, in_faktur.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_supplier_n.Enter, in_faktur.Enter
        popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
        If popPnl_barang.Visible = False Then popPnl_barang.Visible = True

        If sender.Name = "in_supplier_n" Then : popupstate = "supplier"
        Else : popupstate = "faktur"
        End If
        loadDataBRGPopup(popupstate, sender.Text)
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_supplier_n.Leave, in_faktur.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyUp, in_faktur.KeyUp
        Dim _nxtcontrol As Object
        Dim _kdcontrol As Object
        Select Case sender.Name.ToString
            Case "in_supplier_n"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = in_supplier
            Case "in_faktur"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = Nothing
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

    Private Sub in_supplier_n_TextChanged(sender As Object, e As EventArgs) Handles in_supplier_n.TextChanged
        If in_supplier_n.Text = "" Then
            in_supplier.Clear()
            'AND OTHER STUFF
        End If
    End Sub
End Class