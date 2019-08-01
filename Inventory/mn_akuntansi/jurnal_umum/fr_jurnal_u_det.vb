Public Class fr_jurnal_u_det
    'LOAD FORM
    Public Sub doLoad(IdJurnal As Integer)
        kas_debet.DefaultCellStyle = dgvstyle_currency
        kas_kredit.DefaultCellStyle = dgvstyle_currency

        Dim _ent As String = CheckJurnalEntry(IdJurnal)
        If _ent = "ENTRY1" Then
            Dim x As New fr_jurnal_u_entry
            If selectperiode.closed Then
                GoTo LoadJurnal
            Else
                x.doLoadEdit(IdJurnal, loggeduser.allowedit_akun)
            End If
        ElseIf _ent = String.Empty Then
            Exit Sub
        Else
LoadJurnal:
            loadData(IdJurnal)
            Me.Text += in_faktur.Text
            Me.Show(main)
        End If
    End Sub

    'LOAD DATA JURNAL
    Private Function CheckJurnalEntry(IdJurnal As Integer) As String
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT line_type FROM data_jurnal_line WHERE line_id='{0}'"
                Try
                    Return x.ExecScalar(String.Format(q, IdJurnal))
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data." & Environment.NewLine & ex.Message,
                                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return String.Empty
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return String.Empty
            End If
        End Using
    End Function

    Private Sub loadData(IdJurnal As String)
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT line_tanggal, line_kode,line_type, IFNULL(pajak.ref_text,'ERROR') line_kat, " _
                    & "GetJurnalUmum_ket(line_type, line_ref_type, line_ref) line_ket, " _
                    & "IF(IFNULL(MONTH(line_reg_date),0)=0,'',line_reg_date) line_reg_date, IFNULL(line_reg_alias,'') line_reg_alias, " _
                    & "IF(IFNULL(MONTH(line_upd_date),0)=0,'',line_upd_date) line_upd_date, IFNULL(line_upd_alias,'') line_upd_alias " _
                    & "FROM data_jurnal_line " _
                    & "LEFT JOIN ref_jenis pajak ON line_pajak=pajak.ref_kode AND pajak.ref_status=1 AND pajak.ref_type='ppn_trans2' " _
                    & "WHERE line_id='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, IdJurnal), CommandBehavior.SingleRow)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_kode.Text = IdJurnal
                        in_tgl.Text = CDate(rdx.Item("line_tanggal")).ToString("dd MMMM yyyy")
                        in_kat.Text = rdx.Item("line_kat")
                        in_faktur_type.Text = rdx.Item("line_type")
                        in_faktur.Text = rdx.Item("line_kode")
                        in_ket.Text = rdx.Item("line_ket")

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
                    CountValue()
                End Using
            End If
        End Using
    End Sub

    Private Sub CountValue()
        Dim _debet As Decimal = 0 : Dim _kredit As Decimal = 0
        For Each row As DataGridViewRow In dgv_kas.Rows
            _debet += row.Cells("kas_debet").Value
            _kredit += row.Cells("kas_kredit").Value
        Next
        in_debet_tot.Text = commaThousand(_debet)
        in_kredit_tot.Text = commaThousand(_kredit)
        in_selisih.Text = commaThousand(IIf(_debet - _kredit < 0, (_debet - _kredit) * -1, _debet - _kredit))
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
End Class