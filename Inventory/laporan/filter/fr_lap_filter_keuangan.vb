Public Class fr_lap_filter_keuangan
    Private popupstate As String = "supplier"
    Private lapwintext As String = ""
    Public laptype As String
    Public sales_sw As String = "ON"
    Public akun_sw As Boolean = True
    Public tgltrans_sw As Boolean = True
    Public periode_sw As Boolean = False

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
            If sales_sw = "JENISCUSTO" Then
                lbl_sales.Text = "Jenis"
            End If
        End If

        'TGL
        lbl_tgl.Visible = tgltrans_sw
        lbl_tgl2.Visible = tgltrans_sw
        date_tglawal.Visible = tgltrans_sw
        date_tglakhir.Visible = tgltrans_sw

        'periode
        cb_periode.Visible = periode_sw
        lbl_periode.Visible = periode_sw

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
                prcessSW()

            Case "k_bukubesar"
                sales_sw = "OFF"
                prcessSW()

            Case "k_jurnalumum", "k_labarugi", "k_neraca", "k_neracalajur", "k_jurnaltutup", "k_daftarperk"
                sales_sw = "OFF"
                akun_sw = False
                prcessSW()
        End Select

        Select Case tipe
            Case "k_biayasales_global", "k_bukubesar", "k_jurnaltutup"
                date_tglawal.Enabled = False
                date_tglakhir.Enabled = False
            Case "k_Labarugi", "k_neraca", "k_neracalajur"
                date_tglawal.Enabled = IIf(closed_sw = False, True, False)
                date_tglakhir.Enabled = IIf(closed_sw = False, True, False)
            Case "k_daftarperk"
                date_tglawal.Visible = False
                lbl_tgl.Visible = False
                lbl_tgl2.Visible = False
                date_tglakhir.Visible = False
        End Select
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "sales"
                q = "SELECT salesman_kode AS 'Kode', salesman_nama AS 'Nama' FROM data_salesman_master WHERE salesman_status=1 AND salesman_nama LIKE '{0}%'"
            Case "akun"
                If laptype = "k_biayasales" Or laptype = "k_biayasales_global" Then
                    q = "SELECT perk_kode as 'Kode', perk_nama_akun as 'Nama' FROM data_perkiraan WHERE perk_status=1 " _
                        & "AND LEFT(perk_tipe,1)='4' AND perk_nama_akun LIKE '{0}%'"
                Else
                    q = "SELECT perk_kode as 'Kode', perk_nama_akun as 'Nama' FROM data_perkiraan WHERE perk_status=1 AND perk_nama_akun LIKE '{0}%'"
                End If
            Case "faktur"
                Exit Sub
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
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    'If faktur_sw = True Then in_faktur.Focus() Else bt_simpanbeli.Focus()
                Case "akun"
                    in_akun.Text = .Cells(0).Value
                    in_akun_n.Text = .Cells(1).Value

                Case Else
                    Exit Sub
            End Select
        End With
        popPnl_barang.Visible = False
    End Sub

    Private Function createQuery(tipe As String) As String
        Dim q As String = ""
        Dim qwh As String = ""
        Dim qreturn As String = ""
        Dim qbiaya As String = "SELECT {4}kas_sales as b_sales, salesman_nama as b_sales_n, " _
                               & "k_trans_rek as b_akun,perk_nama_akun as b_akun_n, SUM(k_trans_debet) as b_saldo " _
                               & "FROM data_perkiraan " _
                               & "LEFT JOIN data_kas_trans ON k_trans_rek=perk_kode AND k_trans_status=1 " _
                               & "RIGHT JOIN data_kas_faktur ON kas_kode=k_trans_faktur AND kas_status=1 AND kas_tgl BETWEEN '{0}' AND '{1}' " _
                               & "LEFT JOIN data_salesman_master ON salesman_kode=kas_sales " _
                               & "WHERE perk_kode LIKE '4%' {2} GROUP BY {3}kas_sales,k_trans_rek"

        Dim qbukubesar As String = "CALL createBukuBesarTableTemp('{0}'); " _
                                   & "SELECT bb_akun, bb_akun_n, bb_tgl, bb_kodebukti,bb_ket,bb_debet,bb_kredit,bb_saldo FROM bukubesar_temp{1}; " _
                                   & "DROP TEMPORARY TABLE IF EXISTS bukubesar_temp;"

        Dim qjurnalumum As String = "CALL createJurnalUmumTableTemp('{0}'); " _
                                    & "SELECT * FROM jurnalumum_temp{1}; " _
                                    & "DROP TEMPORARY TABLE IF EXISTS jurnalumum_temp;"

        Dim qjurnaltutup As String = "CALL createJurnalTutupTableTemp('{0}'); " _
                                    & "SELECT * FROM jurnaltutup_temp WHERE ju_debet+ju_kredit<>0{1}; " _
                                    & "DROP TEMPORARY TABLE IF EXISTS jurnaltutup_temp;"

        Dim qneracalajur As String = "SELECT n_kat, n_group,n_group_n, n_parent,n_parent_n,n_parent_pos,n_akun,n_akun_n,n_akun_pos," _
                                     & "n_saldoawal, IFNULL(n_debet,0) n_debet,IFNULL(n_kredit,0) n_kredit, " _
                                     & "@saldo:=IFNULL(IF(n_akun_pos='K',n_kredit-n_debet,n_debet-n_kredit),0) as n_saldo, " _
                                     & "IF(n_kat IN ('1','2'),TRUNCATE(@saldo+n_saldoawal,2),0) n_neraca, " _
                                     & "IF(n_kat IN ('1','2'),0,@saldo) n_labarugi " _
                                     & "FROM( " _
                                     & " SELECT perk_gol_kat n_kat, perk_tipe as n_group,perk_jen_nama as n_group_n," _
                                     & "  perk_parent n_parent,perk_gol_nama n_parent_n,perk_gol_pos n_parent_pos, " _
                                     & "  perk_kode n_akun,perk_nama_akun n_akun_n, perk_d_or_k n_akun_pos,IFNULL(perk_saldoawal_nilai,0) n_saldoawal " _
                                     & " FROM data_perkiraan " _
                                     & " LEFT JOIN data_perkiraan_gol ON perk_parent=perk_gol_kode " _
                                     & " LEFT JOIN data_perkiraan_jenis ON perk_jen_kode= perk_gol_kodejen " _
                                     & " LEFT JOIN data_perkiraan_saldoawal ON perk_saldoawal_kodeakun=perk_kode AND perk_saldoawal_status=1 AND perk_saldoawal_idperiode='{0}' " _
                                     & " WHERE perk_status = 1 " _
                                     & ")akun_det LEFT JOIN( " _
                                     & " SELECT jurnal_kode_perk,SUM(IFNULL(jurnal_debet,0)) n_debet, SUM(IFNULL(jurnal_kredit,0)) n_kredit " _
                                     & " FROM data_jurnal_line " _
                                     & " RIGHT JOIN data_jurnal_det ON jurnal_kode_line=line_id AND jurnal_status='1' " _
                                     & " WHERE line_status=1 AND line_tanggal BETWEEN '{1}' AND '{2}' AND line_kat='UMUM' " _
                                     & " GROUP BY jurnal_kode_perk " _
                                     & ")akun_saldo ON jurnal_kode_perk=n_akun " _
                                     & "JOIN (SELECT @saldo:=0) para"

        Dim qlabarugi As String = "CALL createLabaRugiTemp('{0}','{1}','{2}'); " _
                                  & "SELECT * FROM labarugi_temp; " _
                                  & "DROP TEMPORARY TABLE IF EXISTS labarugi_temp;"
        Dim qneraca As String = "CALL createNeracaTemp('{0}','{1}','{2}'); " _
                                & "SELECT * FROM neraca_temp; " _
                                & "DROP TEMPORARY TABLE IF EXISTS neraca_temp;"
        Dim qkas As String = "SELECT kas_kode, kas_tgl, kas_bank, aa.perk_nama_akun kas_bank_n, kas_jenis, kas_nobg, kas_sales, salesman_nama kas_sales_n," _
                             & "(CASE kas_status WHEN 1 THEN 'AKTIF' WHEN 2 THEN 'BATAL' ELSE 'ERROR' END) kas_status, " _
                             & "k_trans_rek kas_rek, bb.perk_nama_akun kas_rek_n, k_trans_debet kas_debet, k_trans_kredit kas_kredit, k_trans_ket kas_keterangan " _
                             & "FROM data_kas_faktur " _
                             & "LEFT JOIN data_kas_trans ON k_trans_faktur=kas_kode AND k_trans_status=1 " _
                             & "LEFT JOIN data_perkiraan aa ON aa.perk_kode=kas_bank " _
                             & "LEFT JOIN data_perkiraan bb ON bb.perk_kode=k_trans_rek " _
                             & "LEFT JOIN data_salesman_master ON salesman_kode=kas_sales " _
                             & "WHERE kas_status=1 AND kas_tgl BETWEEN '{0}' AND '{1}' {2}"
        Dim qdaftarperk As String = "SELECT perk_kode da_kode,(CASE " _
                                    & "WHEN LEFT(perk_kode,1)=1 THEN 'Aktiva' WHEN LEFT(perk_kode,1)=2 THEN 'Pasiva' WHEN LEFT(perk_kode,1)=3 THEN 'Pendapatan' " _
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

        Dim _tglawal As String = date_tglawal.Value.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = date_tglakhir.Value.ToString("yyyy-MM-dd")

        Select Case tipe
            Case "k_transkas"
                q = String.Format(qkas, _tglawal, _tglakhir, "{0}")

                If in_sales.Text <> Nothing Then
                    qwh += "AND kas_sales='" & in_sales.Text & "' "
                End If
                If in_akun.Text <> Nothing Then
                    qwh += "AND kas_bank='" & in_akun.Text & "' "
                End If
                'filter for akun_...w.ev

            Case "k_biayasales"
                q = String.Format(qbiaya, _tglawal, _tglakhir, "{0}", "kas_tgl,", "kas_tgl as b_tgl,")

                If in_sales.Text <> Nothing Then
                    qwh += "AND salesman_kode='" & in_sales.Text & "'"
                End If
                If in_akun.Text <> Nothing Then
                    qwh += "AND perk_kode='" & in_akun.Text & "'"
                End If

            Case "k_biayasales_global"
                q = String.Format(qbiaya, _tglawal, _tglakhir, "{0}", "", "")

                If in_sales.Text <> Nothing Then
                    qwh += "AND salesman_kode='" & in_sales.Text & "'"
                End If
                If in_akun.Text <> Nothing Then
                    qwh += "AND perk_kode='" & in_akun.Text & "'"
                End If

            Case "k_bukubesar"
                q = String.Format(qbukubesar, selectperiode.id, "{0}")

                If in_akun.Text <> Nothing Then
                    qwh += " WHERE bb_akun='" & in_akun.Text & "'"
                End If

            Case "k_jurnalumum"
                'If selectperiode.closed = False Then
                q = String.Format(qjurnalumum, selectperiode.id, "{0}")
                'End If
                qwh += " WHERE ju_tgl BETWEEN '" & _tglawal & "' AND '" & _tglakhir & "'"

            Case "k_jurnaltutup"
                'If selectperiode.closed = False Then
                q = String.Format(qjurnaltutup, selectperiode.id, "{0}")
                'End If
                qwh += " AND ju_tgl BETWEEN '" & _tglawal & "' AND '" & _tglakhir & "'"

            Case "k_labarugi"
                q = String.Format(qlabarugi, selectperiode.id, _tglawal, _tglakhir)

            Case "k_neraca"
                q = String.Format(qneraca, selectperiode.id, _tglawal, _tglakhir)

            Case "k_neracalajur"
                q = String.Format(qneracalajur, selectperiode.id, _tglawal, _tglakhir)

            Case "k_daftarperk"
                q = qdaftarperk

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
        Dim _filedate As String = ""
        Dim _periode As String = ""
        If date_tglakhir.Value.ToString("MMyyyy") = date_tglawal.Value.ToString("MMyyyy") Then
            _periode = date_tglawal.Value.ToString("MMMM yyyy")
            _filedate = _periode.Replace(" ", "") & "_" & Today.ToString("yyyyMMdd")
        Else
            _periode = date_tglawal.Value.ToString("dd/MM/yyyy") & " S.d " & date_tglakhir.Value.ToString("dd/MM/yyyy")
            _filedate = date_tglawal.Value.ToString("yyyyMMdd") & "-" & date_tglakhir.Value.ToString("yyyyMMdd") & "_" & Today.ToString("yyyyMMdd")
        End If
        Dim _tglawal As String = date_tglawal.Value.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = date_tglakhir.Value.ToString("yyyy-MM-dd")

        MyBase.Cursor = Cursors.AppStarting

        Select Case type
            Case "k_transkas"
                _colheader.AddRange({"NO_TRANSAKSI", "TGL_TRANSAKSI", "KODE_AKUN_ASAL", "NAMA_AKUN_ASAL", "JENIS_TRANS", "NO_BG", "KODE_SALES", "NAMA_SALESMAN",
                                     "STATUS_TRANSAKSI", "KODE_AKUN", "NAMA_AKUN", "DEBET", "KREDIT", "KETERANGAN"})
                _title = "Data Transaksi Kas " & _periode
                _filename = "TransKas" & _filedate & ".xlsx"

            Case "k_biayasales"
                _colheader.AddRange({"Tgl.Transaksi", "Kode Salesman", "Nama Salesman", "Tgl.Jatuh Tempo", "Faktur", "Saldo Awal", "Pembayaran", "Retur", "Sisa"})
                _title = "LAPORAN BIAYA SALES " & _periode
                _filename = "BiayaSales" & _filedate & ".xlsx"

            Case "k_biayasales_global"
                _colheader.AddRange({"Kode Salesman", "Nama Salesman", "Tgl.Jatuh Tempo", "Faktur", "Saldo Awal", "Pembayaran", "Retur", "Sisa"})
                _title = "LAPORAN BIAYA SALES GLOBAL " & _periode
                _filename = "BiayaSalesGlobal" & _filedate & ".xlsx"

            Case "k_jurnalumum"
                q = "CALL createJurnalUmumTableTemp('{0}'); " _
                    & "SELECT ju_lineid,ju_tgl,ju_kode,ju_ref,ju_akun,ju_akun_n,ju_akun_ket,ju_debet,ju_kredit FROM jurnalumum_temp{1}; " _
                    & "DROP TEMPORARY TABLE IF EXISTS jurnalumum_temp;"
                q = String.Format(q, selectperiode.id, " WHERE ju_tgl BETWEEN '" & _tglawal & "' AND '" & _tglakhir & "'")

                _colheader.AddRange({"ID_JURNAL", "TGL_TRANSAKSI", "KODE_TRANSAKSI", "KETERANGAN_TRANS", "KODE_AKUN", "NAMA_AKUN", "KETERANGAN", "DEBET", "KREDIT"})
                _title = "Data Jurnal Umum Periode " & _periode
                _filename = "JurnalUmum" & _filedate & ".xlsx"

            Case "k_bukubesar"
                _colheader.AddRange({"KODE_AKUN", "NAMA_AKUN", "TGL_TRANSAKSI", "KODE_TRANSAKSI", "KETERANGAN", "DEBET", "KREDIT", "SALDO"})
                _title = "Data Jurnal Umum Periode " & _periode
                _filename = "JurnalUmum" & _filedate & ".xlsx"

            Case "k_neracalajur"
                _colheader.AddRange({"No.Perkiraan", "Nama Perkiraan", "Parent/Group", "Saldo Awal Debet", "Saldo Awal Kredit", "Neraca Saldo Debet", "Neraca Saldo Kredit",
                                     "Laba Rugi Debet", "Laba Rugi Kredit", "Neraca Debet", "Neraca Kredit"})
                _title = "NERACA LAJUR " & _periode
                _filename = "NeracaLajur" & _filedate & ".xlsx"
                q = "SELECT n_akun, n_akun_n, n_parent_n, IF(n_akun_pos='D',n_saldoawal,0),IF(n_akun_pos='K',n_saldoawal,0),n_debet,n_kredit, " _
                    & "IF(n_kat NOT IN (1,2),IF(n_akun_pos='D',n_labarugi,0),0),IF(n_kat NOT IN (1,2),IF(n_akun_pos='K',n_labarugi,0),0), " _
                    & "IF(n_kat IN (1,2),IF(n_akun_pos='D',n_neraca,0),0),IF(n_kat IN (1,2),IF(n_akun_pos='K',n_neraca,0),0) " _
                    & "FROM (" & q & ") neracalajur"

            Case "k_labarugi"
                q = "CALL createLabaRugiTemp('{0}','{1}','{2}'); " _
                    & "SELECT lr_akun, lr_group_ket,lr_parent_n, lr_akun_n, lr_akun_pos, lr_debet, lr_kredit, lr_saldo " _
                    & "FROM labarugi_temp; " _
                    & "DROP TEMPORARY TABLE IF EXISTS labarugi_temp;"
                q = String.Format(q, selectperiode.id, _tglawal, _tglakhir)
                _colheader.AddRange({"KODE_AKUN", "GROUP_AKUN", "PARENT_AKUN", "NAMA_AKUN", "POSISI_AKUN", "DEBET", "KREDIT", "SALDO",
                     "Laba Rugi Debet", "Laba Rugi Kredit", "Neraca Debet", "Neraca Kredit"})
                _title = "Data Laba Rugi " & _periode
                _filename = "LabaRugi" & _filedate & ".xlsx"

            Case "k_jurnaltutup"
                q = "CALL createJurnalTutupTableTemp('{0}'); " _
                    & "SELECT ju_lineid,ju_tgl,ju_kode,ju_ref,ju_akun, ju_akun_n,ju_akun_ket,ju_debet,ju_kredit FROM jurnaltutup_temp WHERE ju_debet+ju_kredit<>0{1}; " _
                    & "DROP TEMPORARY TABLE IF EXISTS jurnaltutup_temp;"
                q = String.Format(q, selectperiode.id, " AND ju_tgl BETWEEN '" & _tglawal & "' AND '" & _tglakhir & "'")

                _colheader.AddRange({"ID_JURNAL", "TGL_TRANSAKSI", "KODE_TRANSAKSI", "KETERANGAN_TRANS", "KODE_AKUN", "NAMA_AKUN", "KETERANGAN", "DEBET", "KREDIT"})
                _title = "Data Jurnal Penutupan Periode " & _periode
                _filename = "JurnalTutup" & _filedate & ".xlsx"

            Case "k_neraca"
                q = "CALL createNeracaTemp('{0}','{1}','{2}'); " _
                    & "SELECT (CASE n_kat WHEN 1 THEN 'AKTIVA' WHEN 2 THEN 'PASSIVA' END) n_kat, n_akun, n_group_n, n_parent_n, " _
                    & "n_akun_n, n_akun_pos,IF(n_akun_pos='D',n_saldoakhir,0) n_debet, IF(n_akun_pos='K',n_saldoakhir,0) n_kredit " _
                    & "FROM neraca_temp; " _
                    & "DROP TEMPORARY TABLE IF EXISTS neraca_temp;"
                q = String.Format(q, selectperiode.id, _tglawal, _tglakhir)

                _colheader.AddRange({"KATEGORI_AKUN", "KODE_AKUN", "GROUP_AKUN", "PARENT_AKUN", "NAMA_AKUN", "POSISI_AKUN", "DEBET", "KREDIT"})
                _title = "Data Neraca Periode " & _periode
                _filename = "Neraca" & _filedate & ".xlsx"

            Case "k_daftarperk"
                _colheader.AddRange({"KODE_AKUN", "KATEGORI_AKUN", "GROUP_AKUN", "NAMA_AKUN", "POSISI_AKUN", "STATUS_AKUN", "KODE_PARENT", "KETERANGAN"})
                _title = "Daftar Perkiraan"
                _filename = "DaftarPerk" & "_" & Today.ToString("yyyyMMdd") & ".xlsx"

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

    Private Sub fr_jual_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
        Me.Text = judulLap

        With cb_periode
            .DataSource = jenis("periode")
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedValue = selectperiode.id
        End With

        date_tglawal.MinDate = selectperiode.tglawal
        date_tglawal.Value = selectperiode.tglawal
        date_tglakhir.MaxDate = selectperiode.tglakhir
        date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)

        lbl_periodedata.Text = main.strip_periode.Text
        lbl_title2.Text = Me.Text

        formSW(tipeLap)
        'prcessSW()
    End Sub

    Private Sub fr_lap_filter_hutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'LOAD LAPORAN
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        Dim x As New fr_lap_keuangan With {
                    .Text = lapwintext
                }
        Dim header As String = ""

        If date_tglakhir.Value.ToString("MMyyyy") = date_tglawal.Value.ToString("MMyyyy") Then
            header = date_tglawal.Value.ToString("MMMM yyyy")
        Else
            header = date_tglawal.Value.ToString("dd/MM/yyyy") & " S.d " & date_tglakhir.Value.ToString("dd/MM/yyyy")
        End If

        x.setVar(laptype, createQuery(laptype), header)
        x.do_load()
        x.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_exportxl.Click
        exportData(laptype)
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
                Case "akun"
                    x = in_akun_n
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

    Private Sub cb_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_periode.KeyPress
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

    Private Sub cb_periode_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_periode.SelectionChangeCommitted
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

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales.KeyDown
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter
        popPnl_barang.Location = New Point(in_sales_n.Left, in_sales_n.Top + in_sales_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "sales"
        loadDataBRGPopup("sales", in_sales_n.Text)
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
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
                If popPnl_barang.Visible = False Then
                    popPnl_barang.Visible = True
                End If
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

    Private Sub in_akun_n_Enter(sender As Object, e As EventArgs) Handles in_akun_n.Enter
        popPnl_barang.Location = New Point(in_akun_n.Left, in_akun_n.Top + in_akun_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "akun"
        loadDataBRGPopup("akun", in_akun_n.Text)
    End Sub

    Private Sub in_akun_n_Leave(sender As Object, e As EventArgs) Handles in_akun_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_akun_n_TextChanged(sender As Object, e As EventArgs) Handles in_akun_n.TextChanged
        If in_akun_n.Text = "" Then
            in_akun.Clear()
            'AND OTHER STUFF
        End If
    End Sub

End Class