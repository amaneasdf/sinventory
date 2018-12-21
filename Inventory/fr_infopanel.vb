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

        dgv_giroin_jt.DataSource = getDataTablefromDB(String.Format(q, IIf(ck_giro_periode.Checked = True, _qtgl, "")))
    End Sub

    'PESANAN
    Private Sub loadPnlPesanan(switch As Boolean)
        Dim q As String = ""
        Dim _tglawal As String = currentperiode.tglawal.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = currentperiode.tglakhir.ToString("yyyy-MM-dd")

        If switch Then
            q = "SELECT COUNT(j_order_kode), COUNT(IF(j_order_tanggal_trans=CURDATE() OR j_order_reg_date=CURDATE(),1,NULL)) " _
                & "FROM data_penjualan_order_faktur WHERE j_order_status=0 AND j_order_tanggal_trans BETWEEN '{0}' AND '{1}'"
            readcommd(String.Format(q, _tglawal, _tglakhir))
            If rd.HasRows Then
                lbl_pesan_valid.Text = String.Format(lbl_pesan_valid.Text, rd.Item(1))
                lbl_pesan_validtot.Text = String.Format(lbl_pesan_validtot.Text, rd.Item(0))
            End If
            rd.Close()

            q = "SELECT COUNT(j_order_kode),COUNT(IF(j_order_status=1,1,NULL)),COUNT(IF(j_order_status=2,1,NULL)) FROM data_penjualan_order_faktur " _
                & "WHERE j_order_status<>9 AND j_order_tanggal_trans BETWEEN '{0}' AND '{1}'"
            readcommd(String.Format(q, _tglawal, _tglakhir))
            If rd.HasRows Then

            End If
            rd.Close()
        End If

    End Sub

    'PIUTANG
    Private Sub loadPnlPiutang(switch As Boolean)
        Dim q As String = ""
        Dim _tglawal As String = currentperiode.tglawal.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = currentperiode.tglakhir.ToString("yyyy-MM-dd")

        If switch Then
            q = "SELECT COUNT(IF(p_bayar_status=0,1,NULL)), COUNT(p_bayar_bukti) FROM data_piutang_bayar " _
                & "WHERE p_bayar_status NOT IN ('2','9') AND p_bayar_tanggal_bayar BETWEEN '{0}' AND '{1}'"
            readcommd(String.Format(q, _tglawal, _tglakhir))
            If rd.HasRows Then

            End If
            rd.Close()

        End If
    End Sub

    'USER
    Private Sub loadPnlUser(switch As Boolean)
        Dim q As String = ""
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
End Class
