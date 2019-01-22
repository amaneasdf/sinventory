Public Class fr_infopanel
    Public pesan_sw As Boolean = True
    Public giro_sw As Boolean = True
    Public stok_sw As Boolean = True
    Public trans_sw As Boolean = True
    Public piutang_sw As Boolean = True
    Public piutang_sw_bayar As Boolean = False
    Public hutang_sw As Boolean = True
    Public hutang_sw_bayar As Boolean = False
    Public uang_sw As Boolean = False
    Public user_sw As Boolean = False

    'BLYAT GIRO KELUAR
    Private Sub loadPnlGiro(switch As Boolean)
        Dim q As String = ""
        Dim _tglawal As String = currentperiode.tglawal.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = currentperiode.tglakhir.ToString("yyyy-MM-dd")

        lbl_giro_current.Text = "BG Jatuh Tempo Hari ini {0}"
        lbl_giro_next30.Text = "BG Jatuh Tempo 30 Hari kedepan {0}"
        lbl_giro_curperiodetot.Text = "Total BG diterima periode saat ini {0}, telah dicairkan {1}, ditolak {2}"

        op_con()

        If switch Then
            q = "SELECT COUNT(IF(giro_tglefektif<=CURDATE(),1,NULL)), COUNT(IF(giro_tglefektif BETWEEN CURDATE() AND ADDDATE(CURDATE(),30),1,NULL)) " _
                & "FROM data_giro WHERE giro_status=1 AND giro_status_pencairan=0 AND giro_type='IN'"
            readcommd(q)
            If rd.HasRows Then
                lbl_giro_current.Text = String.Format(lbl_giro_current.Text, rd.Item(0))
                lbl_giro_next30.Text = String.Format(lbl_giro_next30.Text, rd.Item(0))
            End If
            rd.Close()

            q = "SELECT COUNT(IF(giro_status_pencairan=1,1,NULL)), COUNT(IF(giro_status_pencairan=2,1,NULL)),COUNT(giro_no) " _
                & "FROM data_giro WHERE giro_status=1 AND giro_type='IN' AND (giro_tgl_tolakcair BETWEEN '{0}' AND '{1}' OR giro_tglefektif BETWEEN '{0}' AND '{1}')"
            readcommd(String.Format(q, _tglawal, _tglakhir))
            If rd.HasRows Then
                lbl_giro_curperiodetot.Text = String.Format(lbl_giro_curperiodetot.Text, rd.Item(2), rd.Item(0), rd.Item(1))
            End If
            rd.Close()

            'ck_giro_periode.CheckState = CheckState.Checked

            loadDgvGiro()
        End If
    End Sub

    Private Sub loadDgvGiro()
        Dim q As String = "SELECT giro_no 'No.Giro', giro_nilai 'Nilai BG.', giro_tglefektif 'Tgl.Efektif',IFNULL(salesman_nama,'-') 'Salesman', " _
                                    & "(CASE giro_status_pencairan WHEN 0 THEN '-' WHEN 1 THEN 'CAIR' WHEN 2 THEN 'TOLAK' ELSE 'ERROR' END) 'Status' " _
                                    & "FROM data_giro LEFT JOIN data_salesman_master ON giro_ref3=salesman_kode WHERE giro_status=1 AND giro_type='IN' {0}"
        Dim _tglawal As String = currentperiode.tglawal.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = currentperiode.tglakhir.ToString("yyyy-MM-dd")
        Dim _qtgl As String = String.Format("AND (giro_tglefektif BETWEEN '{0}' AND '{1}' OR giro_tglterima BETWEEN '{0}' AND '{1}')", _tglawal, _tglakhir)
        Dim _qtdy As String = "AND giro_tglefektif=CURDATE()"

        dgv_giroin_jt.DataSource = getDataTablefromDB(String.Format(q, IIf(ck_giro_periode.Checked = True, _qtgl, _qtdy)))

        dgv_giroin_jt.Columns(1).DefaultCellStyle = dgvstyle_currency
    End Sub

    'PESANAN
    Private Sub loadPnlPesanan(switch As Boolean)
        Dim q As String = ""
        Dim _tglawal As String = currentperiode.tglawal.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = currentperiode.tglakhir.ToString("yyyy-MM-dd")
        lbl_pesan_aprovedtoday.Text = "Order diterima/diapprove {0}."
        lbl_pesan_totpesantoday.Text = "Total order hari ini {0} PO, dari {1} salesman."
        lbl_pesan_valid.Text = "Order hari ini yang belum tervalidasi {0}."
        lbl_pesan_validtot.Text = "Total order belum tervalidasi periode saat ini {0}."

        op_con()

        If switch Then
            q = "SELECT COUNT(IF(j_order_status=0,1,NULL)), " _
                & "COUNT(IF(j_order_tanggal_trans=CURDATE() AND j_order_status=0,1,NULL))," _
                & "COUNT(IF(j_order_tanggal_trans=CURDATE() AND j_order_status=1,1,NULL))," _
                & "COUNT(IF(j_order_tanggal_trans=CURDATE(),1,NULL)) , COUNT(IF(j_order_tanggal_trans=CURDATE(),j_order_sales,NULL))" _
                & "FROM data_penjualan_order_faktur WHERE j_order_status IN (0,1,2) AND j_order_tanggal_trans BETWEEN '{0}' AND '{1}'"
            readcommd(String.Format(q, _tglawal, _tglakhir))
            If rd.HasRows Then
                lbl_pesan_valid.Text = String.Format(lbl_pesan_valid.Text, rd.Item(1))
                lbl_pesan_validtot.Text = String.Format(lbl_pesan_validtot.Text, rd.Item(0))
                lbl_pesan_aprovedtoday.Text = String.Format(lbl_pesan_aprovedtoday.Text, rd.Item(2))
                lbl_pesan_totpesantoday.Text = String.Format(lbl_pesan_totpesantoday.Text, rd.Item(3), rd.Item(4))
            End If
            rd.Close()

            'q = "SELECT COUNT(j_order_kode),COUNT(IF(j_order_status=1,1,NULL)),COUNT(IF(j_order_status=2,1,NULL)) FROM data_penjualan_order_faktur " _
            '    & "WHERE j_order_status<>9 AND j_order_tanggal_trans BETWEEN '{0}' AND '{1}'"
            'readcommd(String.Format(q, _tglawal, _tglakhir))
            'If rd.HasRows Then

            'End If
            'rd.Close()
        End If

    End Sub

    'PIUTANG
    Private Sub loadPnlPiutang(switch As Boolean)
        Dim q As String = ""
        Dim _tglawal As String = currentperiode.tglawal.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = currentperiode.tglakhir.ToString("yyyy-MM-dd")
        lbl_piutang_custo.Text = "Dari {0} customer dalam {1} faktur tertagih."
        lbl_piutang_custojt.Text = lbl_piutang_custo.Text
        lbl_piutang_jt.Text = "Total faktur tertagih/jatuh tempo hari ini {0}"
        lbl_piutang_valid.Text = "Total pembayaran piutang menunggu validasi {0}"

        op_con()

        If switch Then
            q = "SELECT SUM(IFNULL(getSisaPiutang(piutang_faktur,{0}),0)), COUNT(DISTINCT faktur_customer), COUNT(piutang_faktur), " _
                & "SUM(IF(piutang_jt <= CURDATE(),getSisaPiutang(piutang_faktur,{0}),0)), " _
                & "COUNT(DISTINCT IF(piutang_jt <= CURDATE(),faktur_customer, NULL))," _
                & "COUNT(IF(piutang_jt <= CURDATE(),piutang_faktur,NULL)), " _
                & "COUNT(IF(piutang_jt= CURDATE(),piutang_faktur,NULL)), " _
                & "COUNT(IF(piutang_status_approve=1,1,NULL)) " _
                & "FROM data_piutang_awal " _
                & "LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode " _
                & "WHERE piutang_status<>9 AND piutang_status_lunas<>1"
            readcommd(String.Format(q, currentperiode.id))
            If rd.HasRows Then
                in_piutang_tot.Text = commaThousand(rd.Item(0))
                lbl_piutang_custo.Text = String.Format(lbl_piutang_custo.Text, rd.Item(1), rd.Item(2))
                in_piutang_totjt.Text = commaThousand(rd.Item(3))
                lbl_piutang_custojt.Text = String.Format(lbl_piutang_custojt.Text, rd.Item(4), rd.Item(5))
                lbl_piutang_jt.Text = String.Format(lbl_piutang_jt.Text, rd.Item(6))
            End If
            rd.Close()

            q = "SELECT COUNT(IF(p_bayar_status=0,p_bayar_bukti,NULL)) FROM data_piutang_bayar " _
                & "WHERE p_bayar_tanggal_bayar BETWEEN '{0}' AND '{1}'"
            readcommd(String.Format(q, _tglawal, _tglakhir))
            If rd.HasRows Then
                lbl_piutang_valid.Text = String.Format(lbl_piutang_valid.Text, rd.Item(0))
            End If
            rd.Close()
        End If
    End Sub

    'USER
    Private Sub loadPnlUser(switch As Boolean)
        Dim q As String = "SELECT user_email, user_telp, user_nama FROM data_pengguna_alias WHERE user_alias='{0}'"
        If switch Then

        End If
    End Sub

    Public Sub do_load()
        'GIRO
        pnl_giro.Visible = giro_sw
        loadPnlGiro(giro_sw)

        'ORDER JUAL
        pnl_orderjual.Visible = pesan_sw
        loadPnlPesanan(pesan_sw)

        'PIUTANG
        pnl_piutang.Visible = piutang_sw
        loadPnlPiutang(piutang_sw)

        'USER
        lkLbl_user.Visible = user_sw
        loadPnlUser(user_sw)
    End Sub

    Private Sub fr_infopanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        do_load()
        Panel1.Visible = False

        'auto refresh
        Timer1.Interval = 7500
        Timer1.Start()

        'clock
        lbl_clock.Text = Now.ToString("hh:mm:ss")
        lbl_date.Text = Now.ToString("dddd, dd MMMM yyyy")
        Timer_clock.Interval = 1000
        Timer_clock.Start()
    End Sub

    'Main Panel
    Private Sub bt_refreshPnl_Click(sender As Object, e As EventArgs) Handles bt_refreshPnl.Click
        Timer1.Stop()

        do_load()

        Timer1.Interval = 7500
        Timer1.Start()
    End Sub

    'PANEL GIRO MASUK
    Private Sub ck_giro_periode_CheckedChanged(sender As Object, e As EventArgs) Handles ck_giro_periode.CheckedChanged
        loadDgvGiro()
    End Sub

    Private Sub lkLbl_giro_piutang_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkLbl_giro_piutang.LinkClicked
        main.openTab("piutangbgcair")
    End Sub

    'PANEL PESANAN
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkLbl_pesan.LinkClicked
        main.openTab("pesanan")
    End Sub

    'PANEL PIUTANG
    Private Sub lkLbl_piutang_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkLbl_piutang.LinkClicked
        main.openTab("piutangbayar")
    End Sub

    'AUTO REFRESH
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        op_con()
        If getConn.State = ConnectionState.Open Then
            do_load()
        End If
        'consoleWriteLine("refresh")
    End Sub

    'CLOCK
    Private Sub Timer_clock_Tick(sender As Object, e As EventArgs) Handles Timer_clock.Tick
        lbl_clock.Text = Now.ToString("hh:mm:ss")
        lbl_date.Text = Now.ToString("dddd, dd MMMM yyyy")
    End Sub
End Class
