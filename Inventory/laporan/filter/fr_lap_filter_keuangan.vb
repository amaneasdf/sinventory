Public Class fr_lap_filter_keuangan
    Private popupstate As String = "supplier"
    Private lapwintext As String = ""
    Public laptype As String
    Public sales_sw As String = "ON"
    Public akun_sw As Boolean = True
    Public tgltrans_sw As Boolean = True
    Public periode_sw As Boolean = False

    'LOAD FORM
    Public Sub do_load(judulLap As String, tipeLap As String)
        With cb_pajak
            .DataSource = jenis("trans_pajak2")
            .DisplayMember = "Text"
            .ValueMember = "Value"
        End With

        laptype = tipeLap : lapwintext = judulLap
        Me.Text = judulLap : lbl_title.Text = Me.Text

        date_tglawal.Value = selectperiode.tglawal
        date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        'date_tglawal.MinDate = selectperiode.tglawal
        'date_tglakhir.MaxDate = selectperiode.tglakhir

        lbl_periodedata.Text = main.strip_periode.Text
        lbl_periodedata.Visible = False
        formSW(tipeLap)
        Me.ShowDialog(main)
    End Sub

    Public Sub do_loadview(LapType As String, StartDate As Date, EndDate As Date, PjkType As Integer)
        If String.IsNullOrWhiteSpace(LapType) Then GoTo CloseForm
        If Not {0, 1}.Contains(PjkType) Then GoTo CloseForm

        Me.laptype = LapType
        date_tglawal.Value = StartDate : date_tglakhir.Value = EndDate

        With cb_pajak
            .DataSource = jenis("trans_pajak2")
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = PjkType
        End With

        bt_simpanbeli_Click(Nothing, Nothing)

CloseForm:
        Me.Close()
    End Sub

    Private Sub prcessSW()
        'SALES
        If sales_sw = "OFF" Then
            lbl_sales.Visible = False
            in_sales.Visible = False
            in_sales_n.Visible = False
        ElseIf sales_sw = "ON" Or sales_sw = "JENISCUSTO" Then
            lbl_sales.Visible = True
            in_sales.Visible = True
            in_sales_n.Visible = True
            If sales_sw = "JENISCUSTO" Then lbl_sales.Text = "Jenis"
        End If

        'TGL
        lbl_tgl.Visible = tgltrans_sw
        lbl_tgl2.Visible = tgltrans_sw
        date_tglawal.Visible = tgltrans_sw
        date_tglakhir.Visible = tgltrans_sw

        'akun
        lbl_akun.Visible = akun_sw
        in_akun.Visible = akun_sw
        in_akun_n.Visible = akun_sw

        'End If

        Me.Text = lapwintext
    End Sub

    Private Sub formSW(tipe As String)
        Dim closed_sw As Boolean = selectperiode.closed

        Select Case tipe
            Case "k_biayasales", "k_biayasales_global", "k_transkas"
                cb_pajak.SelectedIndex = 1
                cb_pajak.Visible = False
                lbl_pajak.Visible = False

            Case "k_bukubesar"
                sales_sw = "OFF"

            Case "k_jurnalumum", "k_jurnalsesuai", "k_labarugi", "k_neraca", "k_neracalajur", "k_jurnaltutup", "k_daftarperk"
                sales_sw = "OFF"
                akun_sw = False
                lbl_pajak.Location = lbl_sales.Location
                cb_pajak.Location = in_sales.Location

        End Select
        prcessSW()

        Select Case tipe
            Case "k_labarugi", "k_neraca", "k_neracalajur", "k_jurnaltutup"
                date_tglawal.Enabled = IIf(closed_sw = False, True, False)
                date_tglakhir.Enabled = IIf(closed_sw = False, True, False)
            Case "k_daftarperk"
                date_tglawal.Visible = False
                lbl_tgl.Visible = False
                lbl_tgl2.Visible = False
                date_tglakhir.Visible = False
        End Select

        If Not {"k_biayasales", "k_biayasales_global", "k_neracalajur"}.Contains(tipe) Then
            bt_exportxl.Enabled = False
        End If
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "sales"
                q = "SELECT salesman_kode AS 'Kode', salesman_nama AS 'Nama' FROM data_salesman_master " _
                    & "WHERE salesman_status=1 AND (salesman_nama LIKE '%{0}%' OR salesman_kode LIKE '%{0}%')"
            Case "akun"
                If laptype = "k_biayasales" Or laptype = "k_biayasales_global" Then
                    q = "SELECT perk_kode as 'Kode', perk_nama_akun as 'Nama' FROM data_perkiraan WHERE perk_status=1 " _
                        & "AND LEFT(perk_tipe,1)='4' AND (perk_nama_akun LIKE '%{0}%' OR perk_kode LIKE '%{0}%')"
                Else
                    q = "SELECT perk_kode as 'Kode', perk_nama_akun as 'Nama' FROM data_perkiraan " _
                        & "WHERE perk_status=1 AND (perk_nama_akun LIKE '%{0}%' OR perk_kode LIKE '%{0}%')"
                End If
            Case Else
                Exit Sub
        End Select
        Me.Cursor = Cursors.WaitCursor
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                dt = x.GetDataTable(String.Format(q, param))
            End If
        End Using
        Me.Cursor = Cursors.Default

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 120
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With
    End Sub

    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                Case "akun"
                    in_akun.Text = .Cells(0).Value
                    in_akun_n.Text = .Cells(1).Value
                Case Else
                    Exit Sub
            End Select
        End With
        bt_simpanbeli.Focus()
    End Sub

    'CREATE QUERY
    Private Function createQuery(tipe As String) As String
        Dim q As String = ""
        Dim _qjoin, _qwh, _qorder As String
        Dim _whrArr As New List(Of String)
        Dim _colselect As New List(Of String)

        Dim qdaftarperk As String = "SELECT perk_kode da_kode,(CASE " _
                                    & "WHEN LEFT(perk_kode,1)=1 THEN 'Aktiva' WHEN LEFT(perk_kode,1)=2 THEN 'Passiva' WHEN LEFT(perk_kode,1)=3 THEN 'Pendapatan' " _
                                    & "WHEN LEFT(perk_kode,1)=4 THEN 'Biaya' ELSE 'ERROR' END) da_jenis, perk_jen_nama da_gol, perk_nama_akun da_akun_n, " _
                                    & "IF(perk_d_or_k='D','Debet','Kredit') da_akun_pos, " _
                                    & "(CASE WHEN perk_status='1' THEN 'AKTIF' WHEN perk_status='0' THEN 'NON AKTIF' WHEN perk_status='9' THEN 'DELETE' " _
                                    & "ELSE 'ERROR' END) as da_akun_status, perk_parent da_akun_parent, perk_ket da_akun_ket " _
                                    & "FROM ( " _
                                    & "SELECT perk_kode, CONCAT('   ',perk_nama_akun) as perk_nama_akun, perk_tipe, " _
                                    & "perk_ket, perk_d_or_k, perk_parent, perk_status " _
                                    & "FROM data_perkiraan " _
                                    & "UNION " _
                                    & "SELECT perk_gol_kode,perk_gol_nama, perk_gol_kodejen, perk_gol_ket, perk_gol_pos, " _
                                    & "perk_gol_kodejen,perk_gol_status " _
                                    & "FROM data_perkiraan_gol LEFT JOIN data_perkiraan ON perk_parent=perk_gol_kode AND perk_status=1 " _
                                    & "WHERE perk_gol_status<>9 GROUP BY perk_gol_kode " _
                                    & "ORDER BY perk_kode " _
                                    & ")perk LEFT JOIN data_perkiraan_jenis ON perk_tipe=perk_jen_kode AND perk_jen_status=1"

        Select Case tipe
            Case "k_transkas", "k_biayasales", "k_biayasales_global"
                q = "SELECT {0} FROM(" _
                    & " SELECT kas_kode, kas_tgl, kas_bank, kas_jenis, kas_nobg, kas_sales, k_trans_ket kas_ket, " _
                    & "  k_trans_rek kas_rek, k_trans_debet kas_debet, k_trans_kredit kas_kredit " _
                    & " FROM data_kas_faktur " _
                    & " LEFT JOIN data_kas_trans ON kas_kode=k_trans_faktur AND k_trans_status=1 " _
                    & " WHERE kas_status=1 AND kas_tgl BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' {3} " _
                    & ")transkas {4}"

                If Not String.IsNullOrWhiteSpace(in_akun.Text) Then
                    If tipe = "k_transkas" Then
                        _whrArr.Add("kas_bank='" & in_akun.Text & "'")
                    Else
                        _whrArr.Add("k_trans_rek='" & in_akun.Text & "'")
                    End If
                End If
                If Not String.IsNullOrWhiteSpace(in_sales.Text) Then _whrArr.Add("kas_sales='" & in_sales.Text & "'")

                If tipe = "k_transkas" Then
                    _colselect.AddRange({""})
                    _qorder = " GROUP BY kas_kode ORDER BY kas_tgl, kas_kode"

                    Return String.Empty
                    Exit Function

                Else
                    If tipe = "k_biayasales" Then
                        _colselect.AddRange({"kas_sales", "salesman_nama kas_sales_n",
                                             "kas_kode", "kas_tgl", "kas_ket",
                                             "kas_rek kas_akun", "perk_nama_akun kas_akun_n",
                                             "kas_debet", "kas_kredit"})
                        _qorder = " ORDER BY kas_sales, kas_tgl, kas_kode"
                    Else
                        _colselect.AddRange({"kas_sales", "salesman_nama kas_sales_n",
                                             "kas_rek kas_akun", "perk_nama_akun kas_akun_n",
                                             "SUM(kas_debet) kas_debet", "SUM(kas_kredit) kas_kredit"
                                            })
                        _qorder = " GROUP BY kas_sales, kas_rek"
                    End If

                    _qjoin = " LEFT JOIN data_salesman_master ON salesman_kode=kas_sales " _
                            & "LEFT JOIN data_perkiraan ON perk_kode=kas_rek"
                    _qwh = " AND LEFT(k_trans_rek,1)='4'" & IIf(_whrArr.Count > 0, " AND " & String.Join(" AND ", _whrArr), "")

                    Return String.Format(q, String.Join(",", _colselect), date_tglawal.Value, date_tglakhir.Value, _qwh, _qjoin + _qorder)
                    Exit Function

                End If

            Case "k_bukubesar"
                Dim _katPajak As String = ""
                q = "SELECT {0} FROM(" _
                    & " SELECT perk_kode, perk_nama_akun, perk_d_or_k, NULL id_line, 0 idx, 'SALDO AWAL PERIODE {1:MMMM yyyy}' perk_ket, " _
                    & "  IF(LCASE(perk_d_or_k)='d', GetSumPerkiraan_V2(perk_kode, 'saldo', '{4}', NULL, '{1:yyyy-MM-dd}'),0) perk_debet, " _
                    & "  IF(LCASE(perk_d_or_k)='k', GetSumPerkiraan_V2(perk_kode, 'saldo', '{4}', NULL, '{1:yyyy-MM-dd}'),0) perk_kredit " _
                    & " FROM data_perkiraan WHERE perk_status = 1 " _
                    & " UNION " _
                    & " SELECT jurnal_kode_perk, perk_nama_akun, perk_d_or_k, " _
                    & "  jurnal_kode_line, jurnal_id, jurnal_ket, jurnal_debet, jurnal_kredit " _
                    & " FROM  data_jurnal_det " _
                    & " LEFT JOIN data_perkiraan ON perk_kode=jurnal_kode_perk " _
                    & " WHERE jurnal_kode_line IN (" _
                    & "     SELECT line_id FROM data_jurnal_line " _
                    & "     WHERE line_status=1 AND line_tanggal BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' AND  line_pajak IN ({3}) AND line_kat='UMUM' " _
                    & "  ) AND jurnal_status=1 " _
                    & ")datajurnal {5}"

                Select Case cb_pajak.SelectedValue.ToString.Replace(" ", "").Replace("'", "")
                    Case "0" : _katPajak = "A"
                    Case "1" : _katPajak = "B"
                    Case "0,1" : _katPajak = "C"
                End Select

                If Not String.IsNullOrWhiteSpace(in_akun.Text) Then _whrArr.Add("perk_kode='" & in_akun.Text & "'")
                _qwh = IIf(_whrArr.Count > 0, " WHERE " & String.Join(" AND ", _whrArr), "")

                _colselect.AddRange({"perk_kode bb_akun", "perk_nama_akun bb_akun_n", "perk_d_or_k bb_pos",
                                     String.Format("IFNULL(line_tanggal, '{0:yyyy-MM-dd}') bb_tgl", date_tglawal.Value),
                                     "ref_text bb_kat", "line_kode bb_kodebukti", "perk_ket bb_ket",
                                     "perk_debet bb_debet", "perk_kredit bb_kredit"})
                _qjoin = " LEFT JOIN data_jurnal_line ON line_id=id_line " _
                        & "LEFT JOIN ref_jenis ON ref_kode=line_pajak AND ref_status=1 AND ref_type='ppn_trans2'"
                _qorder = " ORDER BY perk_kode, bb_tgl, line_id, idx"

                Return String.Format(q, String.Join(",", _colselect), date_tglawal.Value, date_tglakhir.Value, cb_pajak.SelectedValue, _katPajak, _qjoin + _qwh + _qorder)
                Exit Function

            Case "k_jurnalumum", "k_jurnalsesuai", "k_jurnaltutup"
                q = "SELECT {0} FROM(" _
                    & " SELECT jurnal_kode_perk jurnal_akun, perk_nama_akun jurnal_akun_n, perk_d_or_k jurnal_akun_pos, " _
                    & "  jurnal_kode_line jurnal_lineid, jurnal_index, jurnal_ket, jurnal_debet, jurnal_kredit " _
                    & " FROM  data_jurnal_det " _
                    & " LEFT JOIN data_perkiraan ON perk_kode=jurnal_kode_perk " _
                    & " WHERE jurnal_kode_line IN (" _
                    & "     SELECT line_id FROM data_jurnal_line " _
                    & "     WHERE line_status=1 AND line_tanggal BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' AND  line_pajak IN ({3}) AND line_kat='{4}'" _
                    & "  ) AND jurnal_status=1 " _
                    & ")detail {5}"
                _qjoin = " LEFT JOIN data_jurnal_line ON jurnal_lineid=line_id " _
                        & "LEFT JOIN ref_jenis ON ref_kode=line_pajak AND ref_status=1 AND ref_type='ppn_trans2' "
                _qorder = " ORDER BY line_tanggal, jurnal_lineid, jurnal_index"
                _colselect.AddRange({"jurnal_lineid", "line_kode jurnal_kode", "line_tanggal jurnal_tgl", "ref_text jurnal_kat", "line_type jurnal_type"})

                If tipe = "k_jurnalumum" Then
                    _colselect.AddRange({"GetJurnalUmum_ket(line_type, line_ref_type, line_ref) jurnal_ket_line",
                                         "jurnal_akun", "jurnal_akun_n", "jurnal_ket",
                                         "jurnal_debet", "jurnal_kredit"
                                        })

                    Return String.Format(q, String.Join(",", _colselect), date_tglawal.Value, date_tglakhir.Value, cb_pajak.SelectedValue, "UMUM", _qjoin + _qorder)
                    Exit Function

                ElseIf tipe = "k_jurnaltutup" Then
                    _colselect.AddRange({"GetJurnalTutup_ket(line_type, line_ref_type, line_ref) jurnal_ket_line",
                                        "jurnal_akun", "jurnal_akun_n", "jurnal_ket",
                                        "jurnal_debet", "jurnal_kredit"
                                       })
                    _qwh = " WHERE jurnal_debet + jurnal_kredit != 0"

                    Return String.Format(q, String.Join(",", _colselect), date_tglawal.Value, date_tglakhir.Value,
                                         cb_pajak.SelectedValue, "TUTUP", _qjoin + _qwh + _qorder)
                    Exit Function

                ElseIf tipe = "k_jurnalsesuai" Then
                    _colselect.AddRange({"GetJurnalSesuai_ket(line_type, line_ref_type, line_ref) jurnal_ket_line",
                                         "jurnal_akun", "jurnal_akun_n", "jurnal_ket",
                                         "jurnal_debet", "jurnal_kredit"
                                         })

                    Return String.Format(q, String.Join(",", _colselect), date_tglawal.Value, date_tglakhir.Value, cb_pajak.SelectedValue, "SESUAI", _qjoin + _qorder)

                Else : Exit Select
                End If

            Case "k_labarugi", "k_neracalajur", "k_neraca"
                Dim _katPajak As String = ""
                q = "SELECT {0} FROM data_perkiraan {3} " _
                    & "WHERE (perk_status=1 OR perk_kode IN(SELECT DISTINCT jurnal_kode_perk FROM data_jurnal_det " _
                    & "  WHERE jurnal_status=1 AND jurnal_kode_line IN (" _
                    & "     SELECT line_id FROM data_jurnal_line WHERE line_status=1 AND line_tanggal BETWEEN '{1:yyyy-MM-dd}' AND '{2:yyyy-MM-dd}' " _
                    & "  ))) {4}"

                Select Case cb_pajak.SelectedValue.ToString.Replace(" ", "").Replace("'", "")
                    Case "0" : _katPajak = "A"
                    Case "1" : _katPajak = "B"
                    Case "0,1" : _katPajak = "C"
                End Select

                If {"k_labarugi", "k_neraca"}.Contains(tipe) Then
                    _colselect.AddRange({"perk_kode neraca_akun", "perk_nama_akun neraca_akun_n", "perk_gol_pos neraca_pos",
                                         "perk_parent neraca_parent", "perk_gol_nama neraca_parent_n",
                                         String.Format("'{0}' perk_kat", _katPajak)})
                    _qjoin = " LEFT JOIN data_perkiraan_gol ON perk_parent=perk_gol_kode " _
                            & "LEFT JOIN data_perkiraan_jenis ON perk_gol_kodejen=perk_jen_kode"

                    If tipe = "k_labarugi" Then
                        _colselect.AddRange({"perk_jen_kode neraca_jenis", "perk_jen_nama neraca_jenis_n",
                                             String.Format("IF(perk_d_or_k='D', " _
                                                           & "GetJurnalUmum_saldoperk(perk_kode,'SALDO','{0}', '{1:yyyy-MM-dd}', '{2:yyyy-MM-dd}'), NULL) neraca_saldo_d",
                                                           _katPajak, date_tglawal.Value, date_tglakhir.Value),
                                             String.Format("IF(perk_d_or_k='K', " _
                                                           & "GetJurnalUmum_saldoperk(perk_kode,'SALDO','{0}', '{1:yyyy-MM-dd}', '{2:yyyy-MM-dd}'), NULL) neraca_saldo_k",
                                                           _katPajak, date_tglawal.Value, date_tglakhir.Value)})
                        _qwh = " AND LEFT(perk_kode,1) IN ('3','4')"

                    ElseIf tipe = "k_neraca" Then
                        _colselect.AddRange({"perk_jen_kode neraca_subjenis", "perk_jen_nama neraca_subjenis_n",
                                             "LEFT(perk_kode,1) neraca_jenis", "IF(LEFT(perk_kode,1)='1', 'AKTIVA', 'PASSIVA') neraca_jenis_n",
                                             String.Format("IF(perk_d_or_k='D', " _
                                                           & "GetSumPerkiraan_V2(perk_kode,'SALDO','{0}', NULL, '{1:yyyy-MM-dd}'), NULL) neraca_saldo_d",
                                                           _katPajak, date_tglakhir.Value.AddDays(1)),
                                             String.Format("IF(perk_d_or_k='K', " _
                                                           & "GetSumPerkiraan_V2(perk_kode,'SALDO','{0}', NULL, '{1:yyyy-MM-dd}'), NULL) neraca_saldo_k",
                                                           _katPajak, date_tglakhir.Value.AddDays(1))})
                        _qwh = " AND LEFT(perk_kode,1) IN ('1','2')"

                    End If
                    _qorder = " ORDER BY perk_kode"

                    Return String.Format(q, String.Join(",", _colselect), date_tglawal.Value, date_tglakhir.Value, _qjoin, _qwh + _qorder)
                    Exit Function

                ElseIf {"k_laba_komp", "k_neraca_komp"}.Contains(tipe) Then
                    _colselect.AddRange({"perk_kode neraca_akun", "perk_nama_akun neraca_akun_n", "perk_gol_pos neraca_pos",
                                        "perk_parent neraca_parent", "perk_gol_nama neraca_parent_n",
                                        String.Format("'{0}' perk_kat", _katPajak)})
                    _qjoin = " LEFT JOIN data_perkiraan_gol ON perk_parent=perk_gol_kode " _
                            & "LEFT JOIN data_perkiraan_jenis ON perk_gol_kodejen=perk_jen_kode"

                    If tipe = "k_laba_komp" Then
                        _colselect.AddRange({"perk_jen_kode neraca_jenis", "perk_jen_nama neraca_jenis_n"})
                        For i = 2 To 0
                            Dim _tglawal As Date = DateSerial(date_tglawal.Value.Year, date_tglawal.Value.Month - i, 1)
                            Dim _tglakhir As Date = DateSerial(date_tglakhir.Value.Year, date_tglakhir.Value.Month - i + 1, 0)
                            _colselect.AddRange({String.Format(
                                                    "IF(perk_d_or_k='D', " _
                                                    & "GetJurnalUmum_saldoperk(perk_kode,'SALDO','{0}', '{1:yyyy-MM-dd}', '{2:yyyy-MM-dd}'), NULL) neraca_saldo_{3}",
                                                    _katPajak, date_tglawal.Value, date_tglakhir.Value, i + 1),
                                                 String.Format(
                                                    "IF(perk_d_or_k='K', " _
                                                    & "GetJurnalUmum_saldoperk(perk_kode,'SALDO','{0}', '{1:yyyy-MM-dd}', '{2:yyyy-MM-dd}'), NULL) neraca_saldo_{3}",
                                                    _katPajak, date_tglawal.Value, date_tglakhir.Value, i + 1)})
                        Next
                        _qwh = " AND LEFT(perk_kode,1) IN ('3','4')"

                    Else
                        _colselect.AddRange({"perk_jen_kode neraca_subjenis", "perk_jen_nama neraca_subjenis_n",
                                             "LEFT(perk_kode,1) neraca_jenis", "IF(LEFT(perk_kode,1)='1', 'AKTIVA', 'PASSIVA') neraca_jenis_n"})
                        For i = 2 To 0
                            Dim _tglakhir As Date = DateSerial(date_tglakhir.Value.Year, date_tglakhir.Value.Month - i + 1, 0)
                            _colselect.AddRange({String.Format("IF(perk_d_or_k='D', " _
                                                               & "GetSumPerkiraan_V2(perk_kode,'SALDO','{0}', NULL, '{1:yyyy-MM-dd}'), NULL) neraca_saldo_{2}",
                                                               _katPajak, _tglakhir.AddDays(1), i + 1),
                                                 String.Format("IF(perk_d_or_k='K', " _
                                                               & "GetSumPerkiraan_V2(perk_kode,'SALDO','{0}', NULL, '{1:yyyy-MM-dd}'), NULL) neraca_saldo_{2}",
                                                               _katPajak, _tglakhir.AddDays(1), i + 1)})
                        Next
                        _qwh = " AND LEFT(perk_kode,1) IN ('1','2')"

                    End If
                    _qorder = " ORDER BY perk_kode"

                    Return String.Format(q, String.Join(",", _colselect), date_tglawal.Value, date_tglakhir.Value, _qjoin, _qwh + _qorder)
                    Exit Function

                ElseIf tipe = "k_neracalajur" Then
                    _colselect.AddRange({"LEFT(perk_kode,1) n_jenis",
                                         "(CASE LEFT(perk_kode,1) WHEN 1 THEN 'AKTIVA' WHEN 2 THEN 'PASSIVA' WHEN 3 THEN 'PENDAPATAN' WHEN 4 THEN 'BIAYA' ELSE '-' END) n_jenis_n",
                                         "perk_jen_kode n_subjen", "perk_jen_nama n_subjen_n", "perk_gol_kode n_parent", "perk_gol_nama n_parent_n",
                                         "perk_kode n_akun", "perk_nama_akun n_akun_n", "perk_gol_pos n_pos", String.Format("'{0}' n_kat", _katPajak),
                                         String.Format("@d_awal := IF(perk_d_or_k='D', GetSumPerkiraan_V2(perk_kode,'SALDO','{0}',NULL,'{1:yyyy-MM-dd}'), NULL) n_awal_d",
                                                       _katPajak, date_tglawal.Value),
                                         String.Format("@k_awal := IF(perk_d_or_k='K', GetSumPerkiraan_V2(perk_kode,'SALDO','{0}',NULL,'{1:yyyy-MM-dd}'), NULL) n_awal_k",
                                                       _katPajak, date_tglawal.Value),
                                         String.Format("@d_saldo:= GetJurnalUmum_saldoperk(perk_kode,'DEBET','{0}', '{1:yyyy-MM-dd}', '{2:yyyy-MM-dd}') n_saldo_d",
                                                       _katPajak, date_tglawal.Value, date_tglakhir.Value),
                                         String.Format("@k_saldo:= GetJurnalUmum_saldoperk(perk_kode,'KREDIT','{0}', '{1:yyyy-MM-dd}', '{2:yyyy-MM-dd}') n_saldo_k",
                                                       _katPajak, date_tglawal.Value, date_tglakhir.Value),
                                         String.Format("@d_sesuai:= GetJurnalSesuai_saldoperk(perk_kode,'DEBET','{0}', '{1:yyyy-MM-dd}', '{2:yyyy-MM-dd}') n_sesuai_d",
                                                       _katPajak, date_tglawal.Value, date_tglakhir.Value),
                                         String.Format("@k_sesuai:= GetJurnalSesuai_saldoperk(perk_kode,'KREDIT','{0}', '{1:yyyy-MM-dd}', '{2:yyyy-MM-dd}') n_sesuai_k",
                                                       _katPajak, date_tglawal.Value, date_tglakhir.Value),
                                         "IF(LEFT(perk_kode,1) IN ('3','4') AND perk_d_or_k='D', ROUND(@d_awal+(@d_saldo-@k_saldo)+(@d_sesuai-@k_sesuai),2), NULL) n_laba_d",
                                         "IF(LEFT(perk_kode,1) IN ('3','4') AND perk_d_or_k='K', ROUND(@k_awal+(@k_saldo-@d_saldo)+(@k_sesuai-@d_sesuai),2), NULL) n_laba_k",
                                         "IF(LEFT(perk_kode,1) IN ('1','2') AND perk_d_or_k='D', ROUND(@d_awal+(@d_saldo-@k_saldo)+(@d_sesuai-@k_sesuai),2), NULL) n_neraca_d",
                                         "IF(LEFT(perk_kode,1) IN ('1','2') AND perk_d_or_k='K', ROUND(@k_awal+(@k_saldo-@d_saldo)+(@k_sesuai-@d_sesuai),2), NULL) n_neraca_k"
                                        })
                    _qjoin = " LEFT JOIN data_perkiraan_gol ON perk_parent=perk_gol_kode " _
                            & "LEFT JOIN data_perkiraan_jenis ON perk_gol_kodejen=perk_jen_kode"
                    _qorder = " ORDER BY perk_kode"

                    Return String.Format(q, String.Join(",", _colselect), date_tglawal.Value, date_tglakhir.Value, _qjoin, _qorder)
                    Exit Function

                End If

            Case "k_daftarperk"
                q = qdaftarperk

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
                        Case "k_biayasales"
                            _colHeader.AddRange({"KODETRANS", "TGLTRANS", "KETERANGAN", "KODEBIAYA", "NAMA", "DEBET", "KREDIT"})
                            _title.AddRange({"LAPORAN BIAYA PER SALESMAN", "PERIODE " & _periode})

                            Dim _saleslist = New DataView(dtx).ToTable(True, {"kas_sales", "kas_sales_n"}).Select("", "kas_sales ASC")
                            For Each row As DataRow In _saleslist
                                _subtitle.Add({"SALES", row.ItemArray(0), IIf(IsDBNull(row.ItemArray(1)), "", row.ItemArray(1))})
                                Dim _expression = String.Format("kas_sales = '{0}'", row.ItemArray(0))
                                _dt.Add(New DataView(dtx.Select(_expression).CopyToDataTable()).ToTable(False, {"kas_kode", "kas_tgl", "kas_ket", "kas_akun", "kas_akun_n", "kas_debet", "kas_kredit"}))
                            Next

                        Case "k_biayasales_global"
                            _colHeader.AddRange({"KODESALES", "NAMASALESMAN", "KODEBIAYA", "NAMA", "DEBET", "KREDIT"})
                            _title.AddRange({"LAPORAN BIAYA GLOBAL PER SALESMAN", "PERIODE " & _periode})
                            _dt.Add(dtx)

                            'Case "k_jurnalumum"

                        Case "k_neracalajur"
                            _colHeader.AddRange({"JENIS", "GROUP", "KODEAKUN", "NAMA", "SALDOAWAL DEBET", "SALDOAWAL KREDIT", "NERACASALDO DEBET", "NERACASALDO KREDIT",
                                                 "PENYESUAIAN DEBET", "PENYESUAIAN KREDIT", "LABA DEBET", "LABA KREDIT", "NERACA DEBET", "NERACA KREDIT"})
                            _title.AddRange({"NERACA LAJUR", "PERIODE " & _periode})
                            _dt.Add(New DataView(dtx).ToTable(False, {"n_jenis_n", "n_parent_n", "n_akun", "n_akun_n", "n_awal_d", "n_awal_k", "n_saldo_d", "n_saldo_k",
                                                                      "n_laba_d", "n_laba_k", "n_neraca_d", "n_neraca_k"}))

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

    Private Sub fr_jual_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
        Dim x As New fr_lap_keuangan With {.Text = lapwintext}
        Dim header As String = ""

        If date_tglakhir.Value.ToString("MMyyyy") = date_tglawal.Value.ToString("MMyyyy") AndAlso date_tglawal.Value.Day = 1 _
            AndAlso date_tglakhir.Value.Day = DateSerial(date_tglakhir.Value.Year, date_tglakhir.Value.Month + 1, 0).Day Then
            header = date_tglawal.Value.ToString("MMMM yyyy")
        Else
            header = date_tglawal.Value.ToString("dd/MM/yyyy") & " S.d " & date_tglakhir.Value.ToString("dd/MM/yyyy")
        End If

        Me.Cursor = Cursors.WaitCursor
        If Not {"k_laba_komp", "k_neraca_komp"}.Contains(laptype) Then
            x.setVar(laptype, createQuery(laptype), header)
        Else
            Exit Sub
        End If
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
        If Not in_sales_n.Focused Or in_akun_n.Focused Then
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

    Private Sub dgv_listbarang_KeyUp(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyUp
        If e.KeyCode = Keys.Enter Then
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            Dim x As TextBox
            Select Case popupstate
                Case "sales" : x = in_sales_n
                Case "akun" : x = in_akun_n
                Case Else : Exit Sub
            End Select
            PopUpSearchKeyPress(e, x)
        End If
    End Sub

    'UI : INPUT
    Private Sub cb_jenis_KeyPress(sender As Object, e As KeyPressEventArgs)
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
        'keyshortenter(in_sales_n, e)
    End Sub

    Private Sub date_tglakhir_ValueChanged(sender As Object, e As EventArgs) Handles date_tglakhir.ValueChanged
        date_tglawal.MaxDate = date_tglakhir.Value
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales.KeyDown
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter, in_akun_n.Enter
        popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
        If popPnl_barang.Visible = False Then popPnl_barang.Visible = True

        Select Case sender.Name
            Case "in_sales_n"
                popupstate = "sales"
            Case "in_akun_n"
                popupstate = "akun"
        End Select
        loadDataBRGPopup(popupstate, sender.Text)
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave, in_akun_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyDown, in_akun_n.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp, in_akun_n.KeyUp
        Dim _nxtcontrol As Object
        Dim _kdcontrol As Object
        Select Case sender.Name.ToString
            Case "in_sales_n"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = in_sales
            Case "in_akun_n"
                _nxtcontrol = bt_simpanbeli
                _kdcontrol = in_akun
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
                'If e.KeyCode = Keys.Back And sender.SelectionStart > 0 And sender.SelectedText.Count = 0 Then _kdcontrol.Text = ""
                If popPnl_barang.Visible = False Then popPnl_barang.Visible = True
                loadDataBRGPopup(popupstate, sender.Text)
            End If
        End If
    End Sub

    Private Sub in_supplier_n_TextChanged(sender As Object, e As EventArgs) Handles in_sales_n.TextChanged
        If in_sales_n.Text = "" Then
            in_sales.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub in_akun_KeyDown(sender As Object, e As KeyEventArgs) Handles in_akun.KeyDown
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_akun_n_TextChanged(sender As Object, e As EventArgs) Handles in_akun_n.TextChanged
        If in_akun_n.Text = "" Then
            in_akun.Clear()
        End If
    End Sub

End Class