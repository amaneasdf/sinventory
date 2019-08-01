Public Class fr_lap_filter_piutang
    Private popupstate As String = "supplier"
    Private lapwintext As String = ""
    Public laptype As String
    Private pajak_sw As Boolean = True
    Public bayar_sw As Boolean = False
    Public custo_sw As Boolean = True
    Public sales_sw As Boolean = True
    Public faktur_sw As Boolean = False
    Public tgltrans_sw As Boolean = True
    Public periode_sw As Boolean = False

    'LOAD
    Public Sub do_load(judulLap As String, tipeLap As String)
        laptype = tipeLap
        lapwintext = judulLap

        date_tglawal.Value = selectperiode.tglawal
        date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        date_tglawal.MinDate = selectperiode.tglawal
        date_tglakhir.MaxDate = selectperiode.tglakhir

        lbl_periodedata.Text = main.strip_periode.Text
        formSW(tipeLap)

        Me.ShowDialog(main)
    End Sub

    Private Sub prcessSW()
        lbl_sales.Visible = sales_sw
        in_sales.Visible = sales_sw
        in_sales_n.Visible = sales_sw

        lbl_custo.Visible = custo_sw
        in_custo.Visible = custo_sw
        in_custo_n.Visible = custo_sw

        lbl_bayar.Visible = bayar_sw
        cb_bayar.Visible = bayar_sw

        lbl_faktur.Visible = faktur_sw
        in_faktur.Visible = faktur_sw

        lbl_pajak.Visible = pajak_sw
        cb_pajak.Visible = pajak_sw

        lbl_tgl.Visible = tgltrans_sw
        lbl_tgl2.Visible = tgltrans_sw
        date_tglawal.Visible = tgltrans_sw
        date_tglakhir.Visible = tgltrans_sw

        Me.Text = lapwintext
    End Sub

    Private Sub formSW(tipe As String)
        Dim _pajak As String = "trans_pajak2"

        Select Case LCase(tipe)
            Case "p_salesnota", "p_saleslengkap2", "p_kartupiutangsales", "p_kartupiutang"
                bayar_sw = False : faktur_sw = False
                If LCase(tipe) = "p_saleslengkap2" Then _pajak = "trans_pajak"
                If LCase(tipe) = "p_kartupiutang" Then sales_sw = False

            Case "p_titipancusto", "p_titipancusto_det"
                lbl_custo.Location = lbl_sales.Location
                in_custo.Location = in_sales.Location : in_custo_n.Location = in_sales_n.Location
                sales_sw = False : pajak_sw = False

            Case "p_salesglobal"
                custo_sw = False
                bayar_sw = False

            Case "p_bayarnota", "p_salesbayartanggal"
                faktur_sw = True
                bayar_sw = False
                If LCase(tipe) = "p_salesbayartanggal" Then
                    custo_sw = False : faktur_sw = True
                    lbl_bayar.Location = New Point(lbl_custo.Left, lbl_custo.Top)
                    cb_bayar.Location = New Point(in_custo.Left, in_custo.Top)
                End If

        End Select

        If {"p_kartupiutangsales", "p_kartupiutang"}.Contains(LCase(tipe)) Then date_tglawal.Enabled = False

        cb_bayar.DataSource = jenis("bayarpiutang")
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
            Case "sales"
                q = "SELECT salesman_kode AS 'Kode', salesman_nama AS 'Nama' FROM data_salesman_master " _
                    & "WHERE salesman_status=1 AND (salesman_nama LIKE '%{0}%' OR salesman_kode LIKE '%{0}%') LIMIT 250"
            Case "custo"
                q = "SELECT customer_kode AS 'Kode', customer_nama AS 'Nama' FROM data_customer_master " _
                    & "WHERE customer_status=1 AND (customer_nama LIKE '%{0}%' OR customer_kode LIKE '%{0}% ') LIMIT 250"
            Case "faktur"
                q = "SELECT piutang_faktur as 'Kode Faktur', salesman_kode as 'Kode Sales', salesman_nama as 'Salesman', " _
                    & "customer_kode as 'Kode Custo', customer_nama as 'Customer' " _
                    & "FROM data_piutang_awal " _
                    & "LEFT JOIN data_salesman_master ON salesman_kode=piutang_sales " _
                    & "LEFT JOIN data_customer_master ON customer_kode=piutang_custo " _
                    & "WHERE piutang_status=1 AND piutang_faktur LIKE '%{0}%' {1} LIMIT 250"

                Dim qwh As String = ""
                If in_sales.Text <> Nothing Then
                    qwh += "AND piutang_sales='" & in_sales.Text & "' "
                End If
                If in_custo.Text <> Nothing Then
                    qwh += "AND piutang_custo='" & in_custo.Text & "' "
                End If
                q = String.Format(q, "{0}", qwh)
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
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    'If faktur_sw = True Then in_faktur.Focus() Else bt_simpanbeli.Focus()
                Case "custo"
                    in_custo.Text = .Cells(0).Value
                    in_custo_n.Text = .Cells(1).Value

                Case "faktur"
                    in_faktur.Text = .Cells(0).Value
                    in_sales.Text = .Cells(1).Value
                    in_sales_n.Text = .Cells(2).Value
                    in_custo.Text = .Cells(3).Value
                    in_custo_n.Text = .Cells(4).Value
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
        Dim _qwh, _qjoin, _qorder As String
        Dim _colSelect As New List(Of String)
        Dim _whrArr As New List(Of String)

        Select Case LCase(tipe)
            Case "p_over2bulan"

            Case "p_salesnota", "p_salesglobal" 'SEMUA PIUTANG YG DI PEGANG SALES(YG BELUM LUNAS) ->BASED periode,sales,custo;OPT saldo_sisa
                q = "SELECT {0} FROM( " _
                    & " SELECT piutang_faktur, piutang_tgl, piutang_jt, piutang_custo, piutang_sales, piutang_pajak, piutang_status_lunas, piutang_tgl_lunas " _
                    & " FROM data_piutang_awal " _
                    & " WHERE piutang_status IN (1,2) AND piutang_tgl<='{2:yyyy-MM-dd}' AND piutang_pajak IN({3}) " _
                    & "  AND (piutang_status_lunas = 0 OR piutang_tgl_lunas >= '{1:yyyy-MM-dd}') " _
                    & " ORDER BY piutang_tgl, piutang_faktur " _
                    & ") piutang {4}"

                If Not String.IsNullOrWhiteSpace(in_sales.Text) Then _whrArr.Add("piutang_sales='" & in_sales.Text & "'")
                If Not String.IsNullOrWhiteSpace(in_custo.Text) Then _whrArr.Add("piutang_custo='" & in_custo.Text & "'")

                If LCase(tipe) = "p_salesnota" Then
                    _colSelect.AddRange({"piutang_faktur psn_faktur",
                                         "piutang_jt psn_jt",
                                         "piutang_sales psn_sales",
                                         "salesman_nama psn_sales_n",
                                         "piutang_custo psn_custo",
                                         "GetMasterNama('custo',piutang_custo) psn_custo_n",
                                         String.Format("@awal:= GetPiutangSaldo('awal',piutang_faktur,'{0:yyyy-MM-dd}','{1:yyyy-MM-dd}') psn_saldoawal",
                                                        selectperiode.tglawal, selectperiode.tglakhir),
                                         String.Format("@jual:= GetPiutangSaldo('piutang',piutang_faktur,'{0:yyyy-MM-dd}','{1:yyyy-MM-dd}') psn_penjualan",
                                                        selectperiode.tglawal, selectperiode.tglakhir),
                                         String.Format("(@retur:= GetPiutangSaldo('retur',piutang_faktur,'{0:yyyy-MM-dd}','{1:yyyy-MM-dd}'))*-1 psn_retur",
                                                        selectperiode.tglawal, selectperiode.tglakhir),
                                         String.Format("(@bayar:= GetPiutangSaldo('bayar',piutang_faktur,'{0:yyyy-MM-dd}','{1:yyyy-MM-dd}') " _
                                                       & "+ GetPiutangSaldo('tolak',piutang_faktur,'{0:yyyy-MM-dd}','{1:yyyy-MM-dd}')) * -1 psn_bayar",
                                                        selectperiode.tglawal, selectperiode.tglakhir),
                                         "ROUND(@awal + @jual + @retur + @bayar, 2) psn_sisa"
                                        })
                    _qjoin = " LEFT JOIN data_salesman_master FORCE INDEX(sales_idx_kode_nama) ON piutang_sales=salesman_kode"
                    _qwh = IIf(_whrArr.Count > 0, " WHERE " & String.Join(" AND ", _whrArr), "")

                ElseIf LCase(tipe) = "p_salesglobal" Then
                    Dim _pajakjual As String = ""
                    Select Case cb_pajak.SelectedValue
                        Case "1" : _pajakjual = "1, 2"
                        Case "0,1" : _pajakjual = "0,1,2"
                        Case Else : _pajakjual = cb_pajak.SelectedValue
                    End Select
                    _colSelect.AddRange({"piutang_sales psg_sales",
                                         "salesman_nama psg_sales_n",
                                         "COUNT(DISTINCT piutang_faktur) psg_jlFak",
                                         String.Format("SUM(GetPiutangSaldo('awal',piutang_faktur,'{0:yyyy-MM-dd}','{1:yyyy-MM-dd}')) psg_saldoawal",
                                                       selectperiode.tglawal, date_tglakhir.Value),
                                         String.Format("SUM(GetPiutangSaldo('piutang',piutang_faktur,'{0:yyyy-MM-dd}','{1:yyyy-MM-dd}')) psg_penjualan",
                                                       selectperiode.tglawal, date_tglakhir.Value),
                                         String.Format("SUM(GetPiutangSaldo('retur',piutang_faktur,'{0:yyyy-MM-dd}','{1:yyyy-MM-dd}'))*-1 psg_retur",
                                                       date_tglawal.Value, date_tglakhir.Value),
                                         String.Format("SUM(GetPiutangSaldo('bayar',piutang_faktur,'{0:yyyy-MM-dd}','{1:yyyy-MM-dd}'))*-1 psg_bayar",
                                                       date_tglawal.Value, date_tglakhir.Value),
                                         "IFNULL(p_byr_count,0) psg_jlFakT",
                                         "ROUND(IFNULL(p_byr_val,0),2) psg_tunai"
                                        })
                    _qjoin = " LEFT JOIN data_salesman_master FORCE INDEX(sales_idx_kode_nama) ON piutang_sales=salesman_kode AND salesman_status=1 " _
                            & "LEFT JOIN(" _
                            & String.Format("SELECT faktur_sales, COUNT(DISTINCT faktur_kode) p_byr_count, SUM(faktur_netto - faktur_bayar) p_byr_val " _
                                            & "FROM data_penjualan_faktur " _
                                            & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0:yyyy-MM-dd}' AND'{1:yyyy-MM-dd}' " _
                                            & " AND faktur_term=0 AND faktur_ppn_jenis IN ({2}) " _
                                            & "GROUP BY faktur_sales", date_tglawal.Value, date_tglakhir.Value, _pajakjual) _
                            & ")piutangtunai ON piutang_sales=faktur_sales"
                    _qwh = IIf(_whrArr.Count > 0, " WHERE " & String.Join(" AND ", _whrArr), "")
                    _qorder = " GROUP BY piutang_sales"

                Else
                    Return String.Empty : Exit Function
                End If

                Return String.Format(q, String.Join(",", _colSelect), date_tglawal.Value, date_tglakhir.Value, cb_pajak.SelectedValue, _qjoin + _qwh + _qorder)
                Exit Function

            Case "p_saleslengkap2" 'PIUTANG YG DI PEGANG SALES BERDASARKAN PENJUALAN DALAM KURUN WAKTU TERTENTU (+YG SUDAH LUNAS)
                q = "SELECT faktur_kode psl2_faktur, faktur_tanggal_trans psl2_tgl, " _
                    & "faktur_customer psl2_custo, GetMasterNama('custo',faktur_customer) psl2_custo_n, " _
                    & "faktur_sales psl2_sales, salesman_nama psl2_sales_n, " _
                    & "faktur_term psl2_term, ADDDATE(faktur_tanggal_trans,faktur_term) psl2_jt, " _
                    & "faktur_jumlah + IF(faktur_ppn_jenis=2, faktur_ppn_persen, 0) psl2_brutto, " _
                    & "faktur_disc_rupiah+faktur_bayar psl2_potongan, " _
                    & "@piutang:=GetPiutangSaldo('piutang',faktur_kode,'{2:yyyy-MM-dd}','{3:yyyy-MM-dd}') psl2_penjualan, " _
                    & "@bayar := GetPiutangSaldo('bayar',faktur_kode,'{2:yyyy-MM-dd}','{3:yyyy-MM-dd}')*-1 psl2_bayar, " _
                    & "@retur := GetPiutangSaldo('retur',faktur_kode,'{2:yyyy-MM-dd}','{3:yyyy-MM-dd}')*-1 psl2_retur, " _
                    & "ROUND(@piutang-@bayar-@retur,2) psl2_sisa " _
                    & "FROM data_penjualan_faktur " _
                    & "LEFT JOIN data_salesman_master FORCE INDEX(sales_idx_kode_nama) ON faktur_sales=salesman_kode " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}' " _
                    & " AND faktur_ppn_jenis IN ({4}) AND faktur_bayar<faktur_netto {5}"

                If Not String.IsNullOrWhiteSpace(in_sales.Text) Then _whrArr.Add("faktur_sales='" & in_sales.Text & "'")
                If Not String.IsNullOrWhiteSpace(in_custo.Text) Then _whrArr.Add("faktur_customer='" & in_custo.Text & "'")

                _qwh = IIf(_whrArr.Count > 0, " AND " & String.Join(" AND ", _whrArr), "")

                Return String.Format(q, date_tglawal.Value, date_tglakhir.Value, selectperiode.tglawal, selectperiode.tglakhir, cb_pajak.SelectedValue, _qwh)
                Exit Function

            Case "p_salesbayartanggal" 'BASED sales,jenisbayar, tgl ;OPT 
                q = "SELECT p_bayar_tanggal_bayar psb_tgl, p_bayar_sales psb_sales, salesman_nama psb_sales_n, " _
                    & "p_bayar_bukti psb_bukti, p_trans_kode_piutang as psb_faktur, p_bayar_jenisbayar psb_jenisbayar, " _
                    & "SUM(p_trans_nilaibayar) psb_total, ref_text psb_status " _
                    & "FROM data_piutang_bayar " _
                    & "LEFT JOIN data_piutang_bayar_trans ON p_bayar_bukti=p_trans_bukti AND p_trans_status=1 " _
                    & "LEFT JOIN data_salesman_master ON p_bayar_sales=salesman_kode " _
                    & "LEFT JOIN ref_jenis ON p_bayar_status=ref_kode AND ref_status=1 AND ref_type='status_trans'" _
                    & "WHERE p_bayar_status=1 AND p_bayar_tanggal_bayar BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}' AND p_bayar_pajak IN({2}) {3} " _
                    & "GROUP BY p_bayar_bukti, p_trans_kode_piutang ORDER BY p_bayar_tanggal_bayar, p_bayar_sales, p_bayar_bukti"

                If Not String.IsNullOrWhiteSpace(in_sales.Text) Then _whrArr.Add("p_bayar_sales='" & in_sales.Text & "'")
                If Not String.IsNullOrWhiteSpace(in_faktur.Text) Then _whrArr.Add("p_trans_kode_piutang='" & in_faktur.Text & "'")
                If Not IsNothing(cb_bayar.SelectedValue) And cb_bayar.SelectedValue <> "ALL" Then _whrArr.Add("p_bayar_jenisbayar='" & cb_bayar.SelectedValue & "'")

                _qwh = IIf(_whrArr.Count > 0, " AND " & String.Join(" AND ", _whrArr), "")

                Return String.Format(q, date_tglawal.Value, date_tglakhir.Value, cb_pajak.SelectedValue, _qwh)
                Exit Function

            Case "p_kartupiutang", "p_kartupiutangsales" 'BASED periode,custo;OPT 
                Dim _grouping As String = ""
                Dim _qColSaldoawal As String = ""

                If LCase(tipe) = "p_kartupiutang" Then
                    _grouping = "piutang_custo"
                    _qColSaldoawal = "'' p_sales, piutang_custo p_custo, 0 p_id, '' p_kode"
                    _qjoin = " LEFT JOIN ref_jenis ppn ON p_kat=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans2'"
                    _qorder = " ORDER BY p_custo, p_tgl, p_id"

                    _colSelect.AddRange({"p_custo pk_custo",
                                         "GetMasterNama('custo',p_custo) pk_custo_n",
                                         "GetMasterNama('custoalamat2',p_custo) pk_custo_k"
                                        })

                ElseIf {"p_kartupiutangsales", "p_kartupiutangsalesonly", "p_kartupiutangnota"}.Contains(LCase(tipe)) Then
                    Select Case LCase(tipe)
                        Case "p_kartupiutangsales"
                            _grouping = "piutang_custo, piutang_sales"
                            _qColSaldoawal = "piutang_sales p_sales, piutang_custo p_custo, 0 p_id, '' p_kode"
                            _qorder = " ORDER BY p_custo, p_sales, p_tgl, p_id"
                            _colSelect.AddRange({"p_custo pk_custo",
                                                 "GetMasterNama('custo',p_custo) pk_custo_n",
                                                 "GetMasterNama('custoalamat2',p_custo) pk_custo_k",
                                                 "p_sales pk_sales",
                                                 "salesman_nama pk_sales_n"
                                                })

                        Case "p_kartupiutangsalesonly"
                            _grouping = "piutang_sales"
                            _qColSaldoawal = "piutang_sales p_sales, '' p_custo, 0 p_id, '' p_kode"
                            _qorder = " ORDER BY p_sales, p_tgl, p_id"
                            _colSelect.AddRange({"p_sales pk_sales",
                                                 "salesman_nama pk_sales_n"
                                                })

                        Case "p_kartupiutangnota"
                            _grouping = "piutang_faktur"
                            _qColSaldoawal = "piutang_sales p_sales, piutang_custo p_custo, 0 p_id, piutang_faktur p_kode"
                            _qorder = " ORDER BY p_custo, p_kode, p_tgl, p_id"
                            _colSelect.AddRange({"p_custo pk_custo",
                                                 "GetMasterNama('custo',p_custo) pk_custo_n",
                                                 "GetMasterNama('custoalamat2',p_custo) pk_custo_k",
                                                 "p_sales pk_sales",
                                                 "salesman_nama pk_sales_n"
                                                })
                        Case Else
                    End Select
                    _qjoin = " LEFT JOIN data_salesman_master FORCE INDEX(sales_idx_kode_nama) ON p_sales=salesman_kode" _
                            & " LEFT JOIN ref_jenis ppn ON p_kat=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans2'"

                Else
                    Return String.Empty : Exit Function
                End If

                _colSelect.AddRange({"p_tgl pk_tgl", "p_ref pk_no_bukti",
                                     "ppn.ref_text pk_kat", "p_ket pk_ket", "p_kode pk_ref",
                                     "p_debet pk_debet", "p_kredit pk_kredit"
                                    })

                q = "SELECT {0} FROM( " _
                    & " SELECT {1}, '{3:yyy-MM-dd}' p_tgl, piutang_pajak p_kat, 'SALDO AWAL' p_ket, '' p_ref, " _
                    & "  SUM(GetPiutangSaldo('awal', piutang_faktur, '{3:yyy-MM-dd}', '{4:yyy-MM-dd}')) p_debet, 0 p_kredit " _
                    & " FROM data_piutang_awal " _
                    & " WHERE piutang_status IN (1,2) AND piutang_tgl<='{4:yyy-MM-dd}' AND (piutang_status_lunas = 0 OR piutang_tgl_lunas >= '{3:yyy-MM-dd}') " _
                    & "  AND piutang_pajak IN({5}) " _
                    & " GROUP BY {2}, piutang_pajak " _
                    & " UNION " _
                    & " SELECT piutang_sales, piutang_custo, p_trans_id, p_trans_kode_piutang, p_trans_tgl, piutang_pajak, " _
                    & "  jenis.ref_text, p_trans_faktur, IF(p_trans_nilai>0, p_trans_nilai, 0), IF(p_trans_nilai<0, p_trans_nilai*-1, 0) " _
                    & " FROM data_piutang_trans " _
                    & " LEFT JOIN data_piutang_awal ON p_trans_kode_piutang=piutang_faktur " _
                    & " LEFT JOIN ref_jenis jenis ON jenis.ref_kode=p_trans_jenis AND jenis.ref_status=1 AND jenis.ref_type='piutang_trans' " _
                    & " WHERE piutang_status IN (1,2) AND p_trans_status=1 AND p_trans_tgl BETWEEN '{3:yyy-MM-dd}' AND '{4:yyy-MM-dd}' " _
                    & "  AND p_trans_jenis NOT IN ('migrasi') AND piutang_pajak IN({5}) " _
                    & ") detailtrans {6}"

                If Not String.IsNullOrWhiteSpace(in_sales.Text) Then _whrArr.Add("p_sales='" & in_sales.Text & "'")
                If Not String.IsNullOrWhiteSpace(in_custo.Text) Then _whrArr.Add("p_custo='" & in_custo.Text & "'")

                _qwh = IIf(_whrArr.Count > 0, " WHERE " & String.Join(" AND ", _whrArr), "")

                Return String.Format(q, String.Join(",", _colSelect), _qColSaldoawal, _grouping, date_tglawal.Value, date_tglakhir.Value,
                                     cb_pajak.SelectedValue, _qjoin + _qwh + _qorder)
                Exit Function

            Case "p_bayarnota" 'BASED periode,custo,sales ;OPT 
                _colSelect.AddRange({"piutang_sales pbd_sales", "salesman_nama pbd_sales_n",
                                     "piutang_custo pbd_custo", "GetMasterNama('custo',piutang_custo) pbd_custo_n",
                                     "p_trans_kode_piutang pbd_faktur", "piutang_tgl pbd_tanggal",
                                     "ppn.ref_text pbd_kat", "p_saldoawal pbd_saldoawal",
                                     "IF(p_jenis='RETUR', p_trans_nilai *-1, 0) pbd_retur",
                                     "IF(p_jenis NOT IN('RETUR', 'BGTOLAK'), p_trans_nilai * -1, 0) pbd_bayar",
                                     "IF(p_jenis='BGTOLAK', p_trans_nilai *-1, 0) pbd_tolak",
                                     "p_trans_tgl pbd_tglbayar", "CONCAT_WS(':',p_trans_faktur,p_jenis) pbd_ket",
                                     "DATEDIFF(p_trans_tgl,piutang_tgl) pbd_hari"
                                    })

                _qjoin = " LEFT JOIN data_salesman_master FORCE INDEX(sales_idx_kode_nama) ON piutang_sales=salesman_kode " _
                        & "LEFT JOIN ref_jenis ppn ON piutang_pajak=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans2'"
                _qorder = " ORDER BY piutang_sales, piutang_custo, p_trans_kode_piutang, p_trans_tgl, p_trans_id"

                q = "SELECT {0} FROM( " _
                    & " SELECT piutang_sales, piutang_custo, p_trans_id, p_trans_kode_piutang, piutang_tgl, piutang_pajak, " _
                    & "  GetPiutangSaldo('awal',piutang_faktur,'{1:yyy-MM-dd}', '{2:yyy-MM-dd}') + " _
                    & "     GetPiutangSaldo('jual',piutang_faktur,'{1:yyy-MM-dd}', '{2:yyy-MM-dd}') p_saldoawal, " _
                    & "  IFNULL(p_bayar_jenisbayar, (CASE p_trans_jenis " _
                    & "     WHEN 'retur' THEN 'RETUR' WHEN 'tolak' THEN 'BGTOLAK' WHEN 'cair' THEN 'BGCAIR' ELSE '-' END)) p_jenis, " _
                    & "  p_trans_nilai, p_trans_faktur, p_trans_tgl " _
                    & " FROM data_piutang_trans " _
                    & " LEFT JOIN data_piutang_awal ON p_trans_kode_piutang=piutang_faktur " _
                    & " LEFT JOIN data_piutang_bayar ON p_trans_faktur=p_bayar_bukti " _
                    & " WHERE piutang_status IN (1,2) AND p_trans_status=1 AND p_trans_tgl BETWEEN '{1:yyy-MM-dd}' AND '{2:yyy-MM-dd}'" _
                    & "  AND p_trans_jenis NOT IN ('jual','migrasi') AND piutang_pajak IN({3}) " _
                    & ") pembayaran {4}"

                If Not String.IsNullOrWhiteSpace(in_sales.Text) Then _whrArr.Add("piutang_sales='" & in_sales.Text & "'")
                If Not String.IsNullOrWhiteSpace(in_custo.Text) Then _whrArr.Add("piutang_custo='" & in_custo.Text & "'")
                If Not String.IsNullOrWhiteSpace(in_faktur.Text) Then _whrArr.Add("p_trans_kode_piutang='" & in_faktur.Text & "'")
                'If Not IsNothing(cb_bayar.SelectedValue) And cb_bayar.SelectedValue <> "ALL" Then _whrArr.Add("p_jenis='" & cb_bayar.SelectedValue & "'")
                _qwh = IIf(_whrArr.Count > 0, " WHERE " & String.Join(" AND ", _whrArr), "")

                Return String.Format(q, String.Join(",", _colSelect), date_tglawal.Value, date_tglakhir.Value, cb_pajak.SelectedValue, _qjoin + _qwh + _qorder)
                Exit Function

            Case "p_titipancusto", "p_titipancusto_det" 'BASED supplier, tgl_akhir;OPT saldo_Sisa
                q = "SELECT {0} FROM( " _
                    & " SELECT p_titip_ref t_custo, p_titip_id t_id, p_titip_tgl t_tgl, p_titip_nilai t_nilai, p_titip_tipe t_jenis, p_titip_faktur t_ref " _
                    & " FROM data_piutang_titip " _
                    & " WHERE p_titip_status=1 AND p_titip_tgl BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' " _
                    & " UNION " _
                    & " SELECT DISTINCT p_titip_ref t_custo, 0 t_id, '{1:yyyy-MM-dd}' t_tgl, GetPiutangSaldoAwal('titipan', p_titip_ref, '{1:yyyy-MM-dd}'), " _
                    & "  'awal' t_jenis, '' t_ref " _
                    & " FROM data_piutang_titip " _
                    & " WHERE p_titip_status=1 AND p_titip_tgl BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' " _
                    & " GROUP BY p_titip_ref " _
                    & ")titipan {3}"
                If Not String.IsNullOrWhiteSpace(in_custo.Text) Then _whrArr.Add("t_custo='" & in_custo.Text & "'")

                If LCase(tipe) = "p_titipancusto" Then
                    _colSelect.AddRange({"t_custo",
                                         "GetMasterNama('custo',t_custo) t_custo_n",
                                         "SUM(IF(t_jenis='awal', t_nilai,0)) t_awal",
                                         "SUM(IF(t_jenis='retur', t_nilai,0)) t_titip",
                                         "SUM(IF(t_jenis='bayar', t_nilai,0)) t_bayar"
                                        })
                    _qorder = " GROUP BY t_custo"
                    _qwh = IIf(_whrArr.Count > 0, " WHERE " & String.Join(" AND ", _whrArr), "")

                    Return String.Format(q, String.Join(",", _colSelect), date_tglawal.Value, date_tglakhir.Value, _qwh + _qorder)
                    Exit Function

                ElseIf LCase(tipe) = "p_titipancusto_det" Then
                    _colSelect.AddRange({"t_custo",
                                         "GetMasterNama('custo',t_custo) t_custo_n",
                                         "t_tgl",
                                         "IFNULL(ref_text, 'ERROR') t_ket",
                                         "t_ref",
                                         "IF(t_nilai<0, t_nilai*-1, 0) t_debet",
                                         "IF(t_nilai>0, t_nilai, 0) t_kredit"
                                        })
                    _qjoin = " LEFT JOIN ref_jenis ON ref_status=1 AND ref_kode=t_jenis AND ref_type='piutang_titip'"
                    _qorder = " ORDER BY t_custo, t_tgl, t_id"
                    _qwh = IIf(_whrArr.Count > 0, " WHERE " & String.Join(" AND ", _whrArr), "")

                    Return String.Format(q, String.Join(",", _colSelect), date_tglawal.Value, date_tglakhir.Value, _qjoin + _qwh + _qorder)
                    Exit Function

                Else
                    Return String.Empty : Exit Function

                End If
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
                        Case "p_salesnota"
                            _colHeader.AddRange({"KODE PIUTANG", "TGL. JTH TEMPO", "KD.SALES", "NAMA SALESMAN", "KD.CUSTOMER", "NAMA CUSTOMER", "SALDOAWAL",
                                                 "PENJUALAN", "RETUR", "BAYAR", "SISA"})
                            _title.AddRange({"LAPORAN NOTA PIUTANG PER SALESMAN", "PERIODE " & _periode})

                            Dim _saleslist = New DataView(dtx).ToTable(True, {"psn_sales", "psn_sales_n"}).Select("", "psn_sales ASC")
                            For Each row As DataRow In _saleslist
                                _subtitle.Add({"SALES", row.ItemArray(0), row.ItemArray(1)})
                                Dim _expression = String.Format("psn_sales = '{0}'", row.ItemArray(0))
                                _dt.Add(dtx.Select(_expression).CopyToDataTable())
                            Next

                        Case "p_salesglobal"
                            _colHeader.AddRange({"KD.SALES", "NAMA SALESMAN", "JML FAKTUR", "TOT.SALDOAWAL", "TOT.PENJUALAN", "TOT.RETUR", "TOT.PEMBAYARAN",
                                                 "JML.FAKTURTUNAI", "TOT.TUNAI"})
                            _title.AddRange({"LAPORAN PIUTANG GLOBAL PER SALESMAN", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "p_saleslengkap2"
                            _colHeader.AddRange({"KODE PIUTANG", "TGL.TRANSAKSI", "KD.CUSTOMER", "NAMA CUSTOMER", "KD.SALES", "NAMA SALESMAN", "TERM",
                                                 "JTH TEMPO", "BRUTTO", "POTONGAN", "PIUTANG", "BAYAR", "RETUR", "SISA"})
                            _title.AddRange({"LAPORAN PIUTANG PENJUALAN PER SALESMAN", "PERIODE " & _periode})

                            Dim _saleslist = New DataView(dtx).ToTable(True, {"psl2_sales", "psl2_sales_n"}).Select("", "psl2_sales ASC")
                            For Each row As DataRow In _saleslist
                                _subtitle.Add({"SALES", row.ItemArray(0), row.ItemArray(1)})
                                Dim _expression = String.Format("psl2_sales = '{0}'", row.ItemArray(0))
                                _dt.Add(dtx.Select(_expression).CopyToDataTable())
                            Next

                        Case "p_salesbayartanggal"
                            _colHeader.AddRange({"TGL.TRANSAKSI", "KD.SALES", "NAMA SALESMAN", "KD.BAYAR", "KD.PIUTANG", "JENIS BAYAR", "NILAI BAYAR", "STATUS"})
                            _title.AddRange({"LAPORAN PEMBAYARAN PIUTANG PER SALESMAN", "PERIODE " & _periode})

                            Dim _saleslist = New DataView(dtx).ToTable(True, {"psb_sales", "psb_sales_n"}).Select("", "psb_sales ASC")
                            For Each row As DataRow In _saleslist
                                _subtitle.Add({"SALES", row.ItemArray(0), row.ItemArray(1)})
                                Dim _expression = String.Format("psb_sales = '{0}'", row.ItemArray(0))
                                _dt.Add(dtx.Select(_expression).CopyToDataTable())
                            Next

                        Case "p_kartupiutang"
                            _colHeader.AddRange({"TGL.TRANSAKSI", "KD.BUKTI", "KAT.", "KETERANGAN", "REFERENSI", "DEBET", "KREDIT"})
                            _title.AddRange({"KARTU PIUTANG", "PERIODE " & _periode})

                            Dim _custolist = New DataView(dtx).ToTable(True, {"pk_custo", "pk_custo_n", "pk_custo_k"}).Select("", "pk_custo ASC")
                            For Each row As DataRow In _custolist
                                _subtitle.Add({row.ItemArray(0), row.ItemArray(1), row.ItemArray(2)})
                                Dim _expression = String.Format("pk_custo = '{0}'", row.ItemArray(0))
                                _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, {"pk_tgl", "pk_no_bukti", "pk_kat", "pk_ket", "pk_ref", "pk_debet", "pk_kredit"}))
                            Next

                        Case "p_kartupiutangsales"
                            _colHeader.AddRange({"KD.SALES", "NAMA SALES", "TGL.TRANSAKSI", "KD.BUKTI", "KAT.", "KETERANGAN", "REFERENSI", "DEBET", "KREDIT"})
                            _title.AddRange({"KARTU PIUTANG PER SALES", "PERIODE " & _periode})

                            Dim _custolist = New DataView(dtx).ToTable(True, {"pk_custo", "pk_custo_n", "pk_custo_k"}).Select("", "pk_custo ASC")
                            For Each row As DataRow In _custolist
                                _subtitle.Add({row.ItemArray(0), row.ItemArray(1), row.ItemArray(2)})

                                Dim _expression = String.Format("pk_custo = '{0}'", row.ItemArray(0))
                                Dim _saleslist = New DataView(dtx.Select(_expression).CopyToDataTable).ToTable(True, {"pk_sales"}).Select("", "pk_sales ASC")
                                For Each _row As DataRow In _saleslist
                                    _expression = String.Format("pk_custo='{0}' AND pk_sales='{1}'", row.ItemArray(0), _row.ItemArray(0))
                                    Dim _ddd = dtx.Select(_expression).CopyToDataTable
                                    If _ddd.Rows.Count > 0 Then _dt.Add(New DataView(_ddd).ToTable(False, {"pk_sales", "pk_sales_n", "pk_tgl", "pk_no_bukti", "pk_kat", "pk_ket", "pk_ref", "pk_debet", "pk_kredit"}))
                                Next
                            Next

                        Case "p_bayarnota"
                            _colHeader.AddRange({"KD.CUSTOMER", "NAMA CUSTOMER", "NO.FAKTUR", "TGL.FAKTUR", "KAT.", "SALDOAWAL", "RETUR", "PEMBAYARAN",
                                                 "BATAL/TOLAK", "TGL.BAYAR", "KETERANGAN", "HARI"})
                            _title.AddRange({"LAPORAN PEMBAYARAN PIUTANG PER NOTA", "PERIODE " & _periode})

                            Dim _saleslist = New DataView(dtx).ToTable(True, {"pbd_sales", "pbd_sales_n"}).Select("", "pbd_sales ASC")
                            For Each row As DataRow In _saleslist
                                _subtitle.Add({"SALES", row.ItemArray(0), row.ItemArray(1)})
                                Dim _expression = String.Format("pbd_sales = '{0}'", row.ItemArray(0))
                                _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, {"pbd_custo", "pbd_custo_n", "pbd_faktur", "pbd_tanggal", "pbd_kat", "pbd_saldoawal", "pbd_retur", "pbd_bayar", "pbd_tolak", "pbd_tglbayar", "pbd_ket", "pbd_hari"}))
                            Next

                        Case "p_titipancusto"
                            _colHeader.AddRange({"KD.CUSTOMER", "NAMA CUSTOMER", "SALDOWAL", "TITiPAN", "PEMBAYARAN"})
                            _title.AddRange({"LAPORAN HUTANG TITIPAN CUSTOMER", "PERIODE " & _periode})
                            _dt.Add(dtx)

                        Case "p_titipancusto_det"
                            _colHeader.AddRange({"TANGGAL", "KETERANGAN", "REFERENSI", "DEBET", "KREDIT"})
                            _title.AddRange({"LAPORAN DETAIL HUTANG TITIPAN CUSTOMER", "PERIODE " & _periode})

                            Dim _custolist = New DataView(dtx).ToTable(True, {"t_custo", "t_custo_n"}).Select("", "t_custo ASC")
                            For Each row As DataRow In _custolist
                                _subtitle.Add({row.ItemArray(0), row.ItemArray(1), row.ItemArray(2)})
                                Dim _expression = String.Format("t_custo = '{0}'", row.ItemArray(0))
                                _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, {"t_tgl", "t_ket", "t_ref", "t_debet", "t_kredit"}))
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
            e.SuppressKeyPress = True
        End If
    End Sub

    'UI
    Private Sub fr_hutang_bayar_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
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

    'UI : POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_sales_n.Focused Or in_faktur.Focused Or in_custo_n.Focused Then
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
                Case "sales"
                    x = in_sales_n
                Case "custo"
                    x = in_custo_n
                Case "faktur"
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
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub date_tglakhir_ValueChanged(sender As Object, e As EventArgs) Handles date_tglakhir.ValueChanged
        date_tglawal.MaxDate = date_tglakhir.Value
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales.KeyUp
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter, in_custo_n.Enter, in_faktur.Enter
        popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)

        Select Case sender.Name
            Case "in_sales_n" : popupstate = "sales"
            Case "in_custo_n" : popupstate = "custo"
            Case "in_faktur" : popupstate = "faktur"
        End Select

        If popPnl_barang.Visible = False Then popPnl_barang.Visible = True
        loadDataBRGPopup(popupstate, in_sales_n.Text)
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave, in_custo_n.Leave, in_faktur.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp, in_custo_n.KeyUp, in_faktur.KeyUp
        Dim _nxtcontrol As Object
        Dim _kdcontrol As Object
        Select Case sender.Name.ToString
            Case "in_sales_n"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = in_sales
            Case "in_custo_n"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = in_custo
            Case "in_faktur"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = Nothing
            Case Else
                Exit Sub
        End Select

        If sender.Text = "" And IsNothing(_kdcontrol) = False Then  _kdcontrol.Text = ""

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

    Private Sub in_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles in_custo.KeyDown
        keyshortenter(in_sales_n, e)
    End Sub
End Class