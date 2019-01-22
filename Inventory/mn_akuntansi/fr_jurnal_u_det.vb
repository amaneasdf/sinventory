Public Class fr_jurnal_u_det
    Private idjurnal As String = ""
    Private ketjurnal As String = ""

    Private Sub loadData(kode As String)
        Dim q As String = "SELECT line_tanggal, line_kode,line_type, line_ref_type, " _
                          & "CONCAT_WS(' - ',line_ref," _
                          & " (CASE " _
                          & "   WHEN line_ref_type='GUDANG' THEN gudang_nama " _
                          & "   WHEN line_ref_type='SUPPLIER' THEN supplier_nama " _
                          & "   WHEN line_ref_type='CUSTO' THEN customer_nama " _
                          & "   WHEN line_ref_type='AKUN' THEN refakun.perk_nama_akun " _
                          & "   WHEN line_ref_type='PERIODE' THEN 'Transaksi Penyesuaian Saldo Awal Periode' " _
                          & "   ELSE '...' " _
                          & " END)) as ref_ket, SUM(jurnal_debet) as debet, SUM(jurnal_kredit) as kredit, " _
                          & "line_reg_date, line_reg_alias, line_upd_date, line_upd_alias " _
                          & "FROM data_jurnal_line " _
                          & "LEFT JOIN data_jurnal_det ON jurnal_kode_line=line_id AND jurnal_status=1 " _
                          & "LEFT JOIN data_barang_gudang ON line_ref=gudang_kode AND line_ref_type='GUDANG' " _
                          & "LEFT JOIN data_supplier_master ON supplier_kode=line_ref AND line_ref_type='SUPPLIER' " _
                          & "LEFT JOIN data_customer_master ON customer_kode=line_ref AND line_ref_type='CUSTO' " _
                          & "LEFT JOIN data_perkiraan refakun ON refakun.perk_kode=line_ref AND line_ref_type='AKUN' " _
                          & "WHERE line_id='{0}'"
        op_con()
        Try
            readcommd(String.Format(q, kode))
            If rd.HasRows Then
                in_kode.Text = kode
                in_tgl.Text = CDate(rd.Item("line_tanggal")).ToString("dd MMMM yyyy")
                in_faktur_type.Text = rd.Item("line_type")
                in_faktur.Text = rd.Item("line_kode")
                in_ref_type.Text = rd.Item("line_ref_type")
                in_ref.Text = rd.Item("ref_ket")
                in_kredit_tot.Text = commaThousand(rd.Item("kredit"))
                in_debet_tot.Text = commaThousand(rd.Item("debet"))
                txtRegAlias.Text = rd.Item("line_reg_alias")
                txtRegdate.Text = rd.Item("line_reg_date")
                Try
                    txtUpdDate.Text = rd.Item("line_upd_date")
                Catch ex As Exception
                    txtUpdDate.Text = "00/00/0000 00:00:00"
                End Try
                txtUpdAlias.Text = rd.Item("line_upd_alias")
            End If
            rd.Close()

            in_ket.Text = ketjurnal
        Catch ex As Exception
            logError(ex)
        Finally
            If rd.IsClosed = False Then
                rd.Close()
            End If
        End Try
        loadDgv(kode)
    End Sub

    Private Sub loadDgv(kode As String)
        Dim q As String = "SELECT jurnal_kode_perk as ju_akun,perk_nama_akun as ju_akun_n, jurnal_index ju_akun_idx, " _
                          & "jurnal_ket as ju_akun_ket,jurnal_debet as ju_debet,jurnal_kredit as ju_kredit " _
                          & "FROM data_jurnal_det " _
                          & "LEFT JOIN data_perkiraan ON perk_kode=jurnal_kode_perk " _
                          & "WHERE jurnal_kode_line='{0}' AND jurnal_status=1 ORDER BY ju_akun_idx"
        op_con()
        Try
            dgv_kas.DataSource = getDataTablefromDB(String.Format(q, kode))
        Catch ex As Exception
            logError(ex)
        End Try
    End Sub

    '------------drag form
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

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalperkiraan.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalperkiraan.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '--------------- load
    Public Sub doLoad(Optional kode As String = Nothing, Optional keterangan As String = Nothing)
        kas_debet.DefaultCellStyle = dgvstyle_currency
        kas_kredit.DefaultCellStyle = dgvstyle_currency

        If kode <> Nothing Then
            idjurnal = kode
            ketjurnal = keterangan
            loadData(kode)
        End If
    End Sub

    Private Sub fr_jurnal_u_det_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class