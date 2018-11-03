Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class fr_draft_tagihan_view
    Private kodedraft As String = ""
    Private tgldraft As String = ""
    Public printing As Integer = 0

    Public Sub setHeader(kode As String, tgl As String)
        kodedraft = kode
        tgldraft = tgl
    End Sub

    Private Sub filldatatabel(query As String, dt As DataTable)
        op_con()
        Try
            Dim data_adpt As New MySqlDataAdapter(query, getConn)
            data_adpt.Fill(dt)
            data_adpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}", ex.Message))
        End Try
        cl_con()
    End Sub

    Private Sub fr_draft_barang_view_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim parUserId As New ReportParameter("parUserId", loggeduser.user_id)
        Dim parTglTagihan As New ReportParameter("parTglTagihan", tgldraft)
        Dim parNoTagihan As New ReportParameter("parNoTagihan", kodedraft)
        Dim q As String = "SELECT salesman_kode as piutang_sales, salesman_nama as draft_sales_n, nota_faktur as draft_faktur, " _
                          & "customer_kode as draft_customer, customer_nama as draft_customer_n, customer_alamat as draft_customer_al, " _
                          & "faktur_tanggal_trans as draft_faktur_tgl, ADDDATE(faktur_tanggal_trans,faktur_term) as draft_jatuhtemp, " _
                          & "nota_tagihan as draft_saldo, piutang_awal as draft_fakturrp, piutang_awal-getSisaPiutang(nota_faktur,'{0}') as draft_bayar " _
                          & "FROM data_tagihan_nota LEFT JOIN data_piutang_awal ON piutang_faktur=nota_faktur AND piutang_idperiode='{0}' " _
                          & "LEFT JOIN data_penjualan_faktur ON faktur_kode=nota_faktur AND faktur_status=1 " _
                          & "LEFT JOIN data_customer_master ON customer_kode=faktur_customer " _
                          & "LEFT JOIN data_salesman_master ON salesman_kode=faktur_sales " _
                          & "WHERE nota_draft='{1}'"
        'Dim query2 As String = "SELECT piutang_sales,piutang_sales_n as draft_sales_n,nota_faktur as draft_faktur, " _
        '                               & "piutang_custo as draft_customer, piutang_custo_n as draft_customer_n, " _
        '                               & "customer_alamat as draft_customer_al,piutang_tgl as draft_faktur_tgl, " _
        '                               & "piutang_jt as draft_jatuhtemp,0 as draft_bayar, piutang_awal as draft_fakturrp, " _
        '                               & "piutang_sisa as draft_saldo " _
        '                               & "FROM data_tagihan_nota LEFT JOIN selectPiutangAwal ON nota_faktur=piutang_faktur " _
        '                               & "LEFT JOIN data_customer_master ON customer_kode=piutang_custo " _
        '                               & "WHERE nota_draft='" & kodedraft & "'"
        Dim query2 As String = String.Format(q, selectperiode.id, kodedraft)
        'consoleWriteLine(query2)

        ds_transaksi.dt_rekap_tagihan_detail.Clear()
        filldatatabel(query2, ds_transaksi.dt_rekap_tagihan_detail)
        With Me.rv_draft_barang
            .LocalReport.SetParameters(New ReportParameter() {parUserId, parNoTagihan, parTglTagihan})
            .RefreshReport()
            .SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            .ZoomMode = 2
            .ZoomPercent = 100
        End With
    End Sub

    Private Sub rv_draft_barang_PrintingBegin(sender As Object, e As ReportPrintEventArgs) Handles rv_draft_barang.PrintingBegin
        printing = 1
    End Sub
End Class