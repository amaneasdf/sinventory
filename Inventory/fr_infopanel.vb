Public Class fr_infopanel

    Private Sub loadPnlGiro()
        Dim q As String = "SELECT giro_no, salesman_nama, (CASE WHEN giro_status=1 THEN '-' " _
                          & "WHEN giro_status=2 THEN 'CAIR' WHEN giro_status='3' THEN 'TOLAK' ELSE 'ERROR' " _
                          & "END) as giro_status FROM data_giro LEFT JOIN data_piutang_bayar ON giro_ref=p_bayar_bukti AND p_bayar_status=1 " _
                          & "LEFT JOIN data_salesman_master ON salesman_kode=p_bayar_sales " _
                          & "WHERE giro_type='IN' AND giro_tglcair=CURDATE() AND giro_status=1"
        consoleWriteLine(q)
        dgv_giroin_jt.DataSource = getDataTablefromDB(q)
    End Sub


    Private Sub fr_infopanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If pnl_giro.Visible = True Then
            loadPnlGiro()
        End If
    End Sub
End Class
