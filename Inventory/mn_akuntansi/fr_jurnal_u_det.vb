Public Class fr_jurnal_u_det
    Private idjurnal As String = ""
    Private ketjurnal As String = ""

    Private Sub loadData(IdJurnal As String)
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT line_tanggal, line_kode,line_type, IFNULL(pajak.ref_text,'ERROR') line_kat, l_type_ket line_ket, line_ref_type, " _
                    & "(CASE " _
                    & "  WHEN line_ref_type='GUDANG' THEN gudang_nama " _
                    & "  WHEN line_ref_type='SUPPLIER' THEN supplier_nama " _
                    & "  WHEN line_ref_type='CUSTO' THEN customer_nama " _
                    & "  WHEN line_ref_type='AKUN' THEN refakun.perk_nama_akun " _
                    & "  WHEN line_ref_type='PERIODE' THEN 'Penyesuaian Saldo Awal Periode' " _
                    & "  ELSE line_ref " _
                    & "END) line_ref, SUM(jurnal_debet) as debet, SUM(jurnal_kredit) as kredit, " _
                    & "IF(IFNULL(MONTH(line_reg_date),0)=0,'',line_reg_date) line_reg_date, IFNULL(line_reg_alias,'') line_reg_alias, " _
                    & "IF(IFNULL(MONTH(line_upd_date),0)=0,'',line_upd_date) line_upd_date, IFNULL(line_upd_alias,'') line_upd_alias " _
                    & "FROM data_jurnal_line " _
                    & "LEFT JOIN data_jurnal_det ON jurnal_kode_line=line_id AND jurnal_status=1 " _
                    & "LEFT JOIN data_barang_gudang ON line_ref=gudang_kode AND line_ref_type='GUDANG' " _
                    & "LEFT JOIN data_supplier_master ON supplier_kode=line_ref AND line_ref_type='SUPPLIER' " _
                    & "LEFT JOIN data_customer_master ON customer_kode=line_ref AND line_ref_type='CUSTO' " _
                    & "LEFT JOIN data_perkiraan refakun ON refakun.perk_kode=line_ref AND line_ref_type='AKUN' " _
                    & "LEFT JOIN ref_jenis pajak ON line_pajak=pajak.ref_kode AND pajak.ref_status=1 AND pajak.ref_type='ppn_trans2' " _
                    & "LEFT JOIN data_jurnal_line_type ON line_type=l_type_kode " _
                    & "WHERE line_id='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, IdJurnal), CommandBehavior.SingleRow)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_kode.Text = IdJurnal
                        in_tgl.Text = CDate(rdx.Item("line_tanggal")).ToString("dd MMMM yyyy")
                        in_kat.Text = rdx.Item("line_kat")
                        in_faktur_type.Text = rdx.Item("line_type")
                        in_faktur.Text = rdx.Item("line_kode")
                        in_ref_type.Text = rdx.Item("line_ref_type")
                        in_ref.Text = rdx.Item("line_ref")
                        in_ket.Text = rdx.Item("line_ket") & " " & in_ref.Text
                        in_kredit_tot.Text = commaThousand(rdx.Item("kredit"))
                        in_debet_tot.Text = commaThousand(rdx.Item("debet"))
                        txtRegAlias.Text = rdx.Item("line_reg_alias")
                        txtRegdate.Text = rdx.Item("line_reg_date")
                        txtUpdDate.Text = rdx.Item("line_upd_date")
                        txtUpdAlias.Text = rdx.Item("line_upd_alias")
                    End If
                End Using
                q = "SELECT jurnal_kode_perk as ju_akun,perk_nama_akun as ju_akun_n, jurnal_index ju_akun_idx, " _
                    & "jurnal_ket as ju_akun_ket,jurnal_debet as ju_debet,jurnal_kredit as ju_kredit " _
                    & "FROM data_jurnal_det " _
                    & "LEFT JOIN data_perkiraan ON perk_kode=jurnal_kode_perk " _
                    & "WHERE jurnal_kode_line='{0}' AND jurnal_status=1 ORDER BY ju_akun_idx"
                Using dtx = x.GetDataTable(String.Format(q, IdJurnal))
                    dgv_kas.DataSource = dtx
                End Using
            End If
        End Using
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