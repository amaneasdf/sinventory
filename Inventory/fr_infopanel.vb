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

    Private Enum PanelType
        GIRO
        PESANAN
        PIUTANG
    End Enum

    Private Sub SetUpPanel(paneltype As PanelType)
        Select Case paneltype
            Case paneltype.GIRO
                lbl_giro_current.Text = "BG Jatuh Tempo Hari ini {0}"
                lbl_giro_next30.Text = "BG Jatuh Tempo 30 Hari kedepan {0}"
                lbl_giro_curperiodetot.Text = "Total BG diterima periode saat ini {0}, telah dicairkan {1}, ditolak {2}"
            Case paneltype.PESANAN
                lbl_pesan_aprovedtoday.Text = "Order diterima/diapprove {0}."
                lbl_pesan_totpesantoday.Text = "Total order hari ini {0} PO, dari {1} salesman."
                lbl_pesan_valid.Text = "Order hari ini yang belum tervalidasi {0}."
                lbl_pesan_validtot.Text = "Total order belum tervalidasi periode saat ini {0}."
            Case paneltype.PIUTANG
                lbl_piutang_custo.Text = "Dari {0} customer dalam {1} faktur tertagih."
                lbl_piutang_custojt.Text = lbl_piutang_custo.Text
                lbl_piutang_jt.Text = "Total faktur tertagih/jatuh tempo hari ini {0}"
                lbl_piutang_valid.Text = "Total pembayaran piutang menunggu validasi {0}"

        End Select

    End Sub

    'BLYAT GIRO KELUAR
    Private Async Function loadPnlGiro(switch As Boolean) As Task(Of Boolean)
        Dim q As String = ""
        Dim _tglawal As String = currentperiode.tglawal.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = currentperiode.tglakhir.ToString("yyyy-MM-dd")
        Dim retval As Boolean = False

        SetUpPanel(PanelType.GIRO)

        If switch Then
            Using x As MySqlThing = MainConnection
                Await x.OpenAsync

                q = "SELECT COUNT(IF(giro_tglefektif<=CURDATE(),1,NULL)), COUNT(IF(giro_tglefektif BETWEEN CURDATE() AND ADDDATE(CURDATE(),30),1,NULL)) " _
                                & "FROM data_giro WHERE giro_status=1 AND giro_status_pencairan=0 AND giro_type='IN'"

                Using rdx As MySql.Data.MySqlClient.MySqlDataReader = Await x.ReadCommandAsync(q, CommandBehavior.SingleRow)
                    If Await rdx.ReadAsync Then
                        If rdx.HasRows Then
                            lbl_giro_current.Text = String.Format(lbl_giro_current.Text, rdx.Item(0))
                            lbl_giro_next30.Text = String.Format(lbl_giro_next30.Text, rdx.Item(1))
                        End If
                        rdx.Close()
                    End If
                End Using

                q = "SELECT COUNT(IF(giro_status_pencairan=1,1,NULL)), COUNT(IF(giro_status_pencairan=2,1,NULL)),COUNT(giro_no) " _
                    & "FROM data_giro WHERE giro_status=1 AND giro_type='IN' AND (giro_tgl_tolakcair BETWEEN '{0}' AND '{1}' OR giro_tglefektif BETWEEN '{0}' AND '{1}')"
                Using rdx As MySql.Data.MySqlClient.MySqlDataReader = Await x.ReadCommandAsync(String.Format(q, _tglawal, _tglakhir), CommandBehavior.SingleRow)
                    If Await rdx.ReadAsync Then
                        If rdx.HasRows Then
                            lbl_giro_curperiodetot.Text = String.Format(lbl_giro_curperiodetot.Text, rdx.Item(2), rdx.Item(0), rdx.Item(1))
                        End If
                        rdx.Close()
                    End If
                End Using

                dgv_giroin_jt.DataSource = Await loadDgvGiro()

                retval = True

            End Using
        End If
        Return retval
    End Function

    Private Async Function loadDgvGiro() As Task(Of DataTable)
        Dim x As MySqlThing = MainConnection
        Dim q As String = "SELECT giro_no 'No.Giro', giro_nilai 'Nilai BG.', giro_tglefektif 'Tgl.Efektif',IFNULL(salesman_nama,'-') 'Salesman', " _
                                    & "(CASE giro_status_pencairan WHEN 0 THEN '-' WHEN 1 THEN 'CAIR' WHEN 2 THEN 'TOLAK' ELSE 'ERROR' END) 'Status' " _
                                    & "FROM data_giro LEFT JOIN data_salesman_master ON giro_ref3=salesman_kode WHERE giro_status=1 AND giro_type='IN' {0}"
        Dim _tglawal As String = currentperiode.tglawal.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = currentperiode.tglakhir.ToString("yyyy-MM-dd")
        Dim _qtgl As String = String.Format("AND (giro_tglefektif BETWEEN '{0}' AND '{1}' OR giro_tglterima BETWEEN '{0}' AND '{1}')", _tglawal, _tglakhir)
        Dim _qtdy As String = "AND giro_tglefektif=CURDATE()"
        Dim retVal As New DataTable

        Await x.OpenAsync()
        If x.Connection.State = ConnectionState.Open Then
            retVal = Await x.GetDTAsync(String.Format(q, IIf(ck_giro_periode.Checked = True, _qtgl, _qtdy)))
        End If

        'dgv_giroin_jt.DataSource = getDataTablefromDB(String.Format(q, IIf(ck_giro_periode.Checked = True, _qtgl, _qtdy)))

        Return retVal
    End Function

    'PESANAN
    Private Async Function loadPnlPesanan(switch As Boolean) As Task(Of Boolean)
        Dim x As MySqlThing = MainConnection
        Dim retVal As Boolean = False
        Dim q As String = ""
        Dim _tglawal As String = currentperiode.tglawal.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = currentperiode.tglakhir.ToString("yyyy-MM-dd")

        SetUpPanel(PanelType.PESANAN)

        If switch Then
            Await x.OpenAsync

            q = "SELECT COUNT(IF(j_order_status=0,1,NULL)), " _
                & "COUNT(IF(j_order_tanggal_trans=CURDATE() AND j_order_status=0,1,NULL))," _
                & "COUNT(IF(j_order_tanggal_trans=CURDATE() AND j_order_status=1,1,NULL))," _
                & "COUNT(IF(j_order_tanggal_trans=CURDATE(),1,NULL)) , COUNT(IF(j_order_tanggal_trans=CURDATE(),j_order_sales,NULL))" _
                & "FROM data_penjualan_order_faktur WHERE j_order_status IN (0,1,2) AND j_order_tanggal_trans BETWEEN '{0}' AND '{1}'"
            Using rdx As MySql.Data.MySqlClient.MySqlDataReader = Await x.ReadCommandAsync(String.Format(q, _tglawal, _tglakhir))
                If Await rdx.ReadAsync() Then
                    If rdx.HasRows Then
                        lbl_pesan_valid.Text = String.Format(lbl_pesan_valid.Text, rdx.Item(1))
                        lbl_pesan_validtot.Text = String.Format(lbl_pesan_validtot.Text, rdx.Item(0))
                        lbl_pesan_aprovedtoday.Text = String.Format(lbl_pesan_aprovedtoday.Text, rdx.Item(2))
                        lbl_pesan_totpesantoday.Text = String.Format(lbl_pesan_totpesantoday.Text, rdx.Item(3), rdx.Item(4))
                    End If
                    rdx.Close()
                End If
            End Using
            retVal = True
        End If
        Return retVal
    End Function

    'PIUTANG
    Private Async Function loadPnlPiutang(switch As Boolean) As Task(Of Boolean)
        Dim x As MySqlThing = MainConnection
        Dim retval As Boolean = False
        Dim q As String = ""
        Dim _tglawal As String = currentperiode.tglawal.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = currentperiode.tglakhir.ToString("yyyy-MM-dd")

        SetUpPanel(PanelType.PIUTANG)

        If switch Then
            Await x.OpenAsync

            q = "SELECT IFNULL(SUM(getPiutangSisa(piutang_faktur)),0), COUNT(DISTINCT faktur_customer), COUNT(piutang_faktur), " _
                & "IFNULL(SUM(IF(piutang_jt <= CURDATE(),getPiutangSisa(piutang_faktur),0)),0), " _
                & "COUNT(DISTINCT IF(piutang_jt <= CURDATE(),faktur_customer, NULL))," _
                & "COUNT(IF(piutang_jt <= CURDATE(),piutang_faktur,NULL)), " _
                & "COUNT(IF(piutang_jt=CURDATE(),piutang_faktur,NULL)), " _
                & "COUNT(IF(piutang_status_approve=1,1,NULL)) " _
                & "FROM data_piutang_awal " _
                & "LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode " _
                & "WHERE piutang_status<>9 AND piutang_status_lunas=0"
            Using rdx As MySql.Data.MySqlClient.MySqlDataReader = Await x.ReadCommandAsync(String.Format(q, currentperiode.id), CommandBehavior.SingleRow)
                If Await rdx.ReadAsync Then
                    If rdx.HasRows Then
                        in_piutang_tot.Text = commaThousand(rdx.Item(0))
                        lbl_piutang_custo.Text = String.Format(lbl_piutang_custo.Text, rdx.Item(1), rdx.Item(2))
                        in_piutang_totjt.Text = commaThousand(rdx.Item(3))
                        lbl_piutang_custojt.Text = String.Format(lbl_piutang_custojt.Text, rdx.Item(4), rdx.Item(5))
                        lbl_piutang_jt.Text = String.Format(lbl_piutang_jt.Text, rdx.Item(6))
                    End If
                    rdx.Close()
                End If
            End Using

            q = "SELECT COUNT(IF(p_bayar_status=0,p_bayar_bukti,NULL)) FROM data_piutang_bayar WHERE p_bayar_tanggal_bayar BETWEEN '{0}' AND '{1}'"
            Using rdx As MySql.Data.MySqlClient.MySqlDataReader = Await x.ReadCommandAsync(String.Format(q, _tglawal, _tglakhir), CommandBehavior.SingleResult)
                If Await rdx.ReadAsync Then
                    If rdx.HasRows Then
                        lbl_piutang_valid.Text = String.Format(lbl_piutang_valid.Text, rdx.Item(0))
                    End If
                    rdx.Close()
                End If
            End Using
            retval = True
        End If
        Return retval
    End Function

    'USER
    Private Sub loadPnlUser(switch As Boolean)
        Dim q As String = "SELECT user_email, user_telp, user_nama FROM data_pengguna_alias WHERE user_alias='{0}'"
        If switch Then

        End If
    End Sub

    Public Async Function do_load() As Task
        Dim x As New TaskCompletionSource(Of Object)
        consoleWriteLine("xxx" & Now.ToLongTimeString)
        Try
            'GIRO
            If Await loadPnlGiro(giro_sw) Then : pnl_giro.Visible = giro_sw : dgv_giroin_jt.Columns(1).DefaultCellStyle = dgvstyle_currency : End If

            'ORDER JUAL
            If Await loadPnlPesanan(pesan_sw) Then pnl_orderjual.Visible = pesan_sw

            'PIUTANG
            If Await loadPnlPiutang(piutang_sw) Then pnl_piutang.Visible = piutang_sw

            'USER
            lkLbl_user.Visible = user_sw

        Catch ex As Exception
            Timer1.Stop()
            logError(ex, True)
            MessageBox.Show("Terjadi kesalahan saat melakukan koneksi ke database" & Environment.NewLine & "Error : " & ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            main.isForcedClose = True
            Application.Exit()
        End Try
        'loadPnlUser(user_sw)
    End Function

    Private Async Sub fr_infopanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await do_load()
        Panel1.Visible = False

        'auto refresh
        Timer1.Interval = 10000
        Timer1.Start()

        'clock
        lbl_clock.Text = Now.ToString("hh:mm:ss")
        lbl_date.Text = Now.ToString("dddd, dd MMMM yyyy")
        Timer_clock.Interval = 1000
        Timer_clock.Start()
    End Sub

    'Main Panel
    Private Async Sub bt_refreshPnl_Click(sender As Object, e As EventArgs) Handles bt_refreshPnl.Click
        Timer1.Stop()

        Using x As Task = do_load()
            Await x
            If x.IsFaulted Then
                MessageBox.Show("Terjadi kesalahan saat melakukan koneksi ke database" & Environment.NewLine, Application.ProductName,
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                logError(x.Exception, True)
                main.isForcedClose = True
                Application.Exit()
            Else
                Timer1.Interval = 7500
                Timer1.Start()
                consoleWriteLine("Manual Refresh")
            End If
        End Using
    End Sub

    'PANEL GIRO MASUK
    Private Async Sub ck_giro_periode_CheckedChanged(sender As Object, e As EventArgs) Handles ck_giro_periode.CheckedChanged
        dgv_giroin_jt.DataSource = Await loadDgvGiro()
        If dgv_giroin_jt.ColumnCount > 2 Then
            dgv_giroin_jt.Columns(1).DefaultCellStyle = dgvstyle_currency
        End If
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
    Private Sub test(text As String, ByRef returntext As String)
        returntext = text
    End Sub

    Private Async Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Using x As Task = do_load()
            Try
                Await x
#If DEBUG Then
                Dim ss As String = Nothing
                test("refresh " & Now.ToLongTimeString, ss)
                consoleWriteLine(ss)
#End If
            Catch ex As Exception
                logError(ex, True)
                Timer1.Stop()
                MessageBox.Show("Terjadi kesalahan saat melakukan koneksi ke database. Aplikasi akan ditutup." & Environment.NewLine, Application.ProductName,
                                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                logError(x.Exception, True)
                main.isForcedClose = True
                Application.Exit()
            End Try
        End Using
    End Sub

    'CLOCK
    Private Sub Timer_clock_Tick(sender As Object, e As EventArgs) Handles Timer_clock.Tick
        lbl_clock.Text = Now.ToString("hh:mm:ss")
        lbl_date.Text = Now.ToString("dddd, dd MMMM yyyy")
    End Sub
End Class
