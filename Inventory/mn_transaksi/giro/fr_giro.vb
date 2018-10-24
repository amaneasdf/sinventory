﻿Public Class fr_giro
    Public tipegiro As String = ""
    Private statuscair As Boolean = False
    Private datecairchange As Boolean = False
    Private statustolak As Boolean = False

    Private _statusgiro As String
    Private _akuncair As String
    Private _tglcairtolak As Date
    Private _allowedit As Boolean = True


    Private Sub loadData(kode As String, tipe As String)
        Dim q As String = ""
        op_con()

        On Error Resume Next
        Select Case tipe
            Case "OUT"
                q = "SELECT giro_no, giro_nilai, giro_tglcair, g_cair_tglcair," _
                    & "h_bayar_supplier, supplier_nama, giro_ref, giro_ket, giro_status " _
                    & "FROM data_giro LEFT JOIN data_giro_cair ON giro_no=g_cair_nobg AND g_cair_status=1 " _
                    & "left join data_hutang_bayar ON giro_ref=h_bayar_bukti AND h_bayar_status=1 " _
                    & "LEFT JOIN data_supplier_master ON h_bayar_supplier=supplier_kode " _
                    & "WHERE giro_type='OUT' AND giro_no='{0}'"
                q = String.Format(q, kode)

                readcommd(q)
                If rd.HasRows Then
                    in_nobg.Text = rd.Item("giro_no")
                    'bank
                    in_nilaibg.Text = commaThousand(rd.Item("giro_nilai"))
                    in_tgl_bg.Text = CDate(rd.Item("giro_tglcair"))
                    If IsDBNull(rd.Item("g_cair_tglcair")) = False Then
                        statuscair = True
                        _statusgiro = rd.Item("giro_status")
                        in_statusgiro.Text = "DICAIRKAN"
                        _tglcairtolak = rd.Item("g_cair_tglcair")
                        in_tglcair.Text = _tglcairtolak.ToShortDateString
                    End If
                    in_ref.Text = rd.Item("h_bayar_supplier")
                    in_ref_n.Text = rd.Item("supplier_nama")
                    in_faktur.Text = rd.Item("giro_ref")
                    in_ket.Text = rd.Item("giro_ket")
                End If
                rd.Close()
            Case "IN"
                q = "SELECT giro_no, giro_nilai, giro_tglcair, g_cair_tglcair," _
                    & "p_bayar_custo, customer_nama, giro_ref, giro_ket, giro_status,giro_bank " _
                    & "FROM data_giro LEFT JOIN data_giro_cair ON giro_no=g_cair_nobg AND g_cair_status=1 " _
                    & "left join data_piutang_bayar ON giro_ref=p_bayar_bukti AND p_bayar_status<>9 " _
                    & "LEFT JOIN data_customer_master ON p_bayar_custo=customer_kode " _
                    & "WHERE giro_type='IN' AND giro_no='{0}'"
                q = String.Format(q, kode)

                readcommd(q)
                If rd.HasRows Then
                    in_nobg.Text = rd.Item("giro_no")
                    'bank
                    in_nilaibg.Text = commaThousand(rd.Item("giro_nilai"))
                    in_tgl_bg.Text = CDate(rd.Item("giro_tglcair"))
                    in_bank_n.Text = rd.Item("giro_bank")
                    If IsDBNull(rd.Item("g_cair_tglcair")) = False Then
                        statuscair = True
                        _statusgiro = rd.Item("giro_status")
                        in_statusgiro.Text = "DICAIRKAN"
                        _tglcairtolak = rd.Item("g_cair_tanggalcair")
                        in_tglcair.Text = _tglcairtolak.ToShortDateString
                    End If
                    in_ref.Text = rd.Item("p_bayar_custo")
                    in_ref_n.Text = rd.Item("customer_nama")
                    in_faktur.Text = rd.Item("giro_ref")
                    in_ket.Text = rd.Item("giro_ket")
                End If
                rd.Close()
            Case Else
                Exit Sub
        End Select

        If CDate(in_tgl_bg.Text) <= Today And _statusgiro = "1" Then
            mn_cair.Enabled = True
        ElseIf CDate(in_tgl_bg.Text) > Today And _statusgiro = "1" Then
            mn_cair.Enabled = False
        End If

        If _statusgiro = "2" Then
            mn_tolak.Enabled = False
            mn_cair.Text = "Ubah Tanggal Cair"
        ElseIf _statusgiro = "3" Then
            mn_cair.Enabled = False
            mn_tolak.Text = "Ubah Tanggal Tolak"
        End If
    End Sub

    Private Sub formSW(tipe As String)
        Select Case tipe
            Case "OUT"
                lbl_akun.Visible = False
                in_akuncair.Visible = False
                in_akuncair_n.Visible = False
            Case Else
                lbl_akun.Visible = True
                in_akuncair.Visible = True
                in_akuncair_n.Visible = True
        End Select
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        If MessageBox.Show("Tutup Form?", "Detail Giro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
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

    '------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanbeli.PerformClick()
    End Sub

    Private Sub mn_cair_Click(sender As Object, e As EventArgs) Handles mn_cair.Click
        If statuscair = True And _allowedit = True Then
            If MessageBox.Show("Ubah data pencairan giro?", "Detail Giro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                datecairchange = True
            End If
        End If

        Using x As New fr_giro_dialog
            With x
                .do_load(tipegiro)
                With .date_tgl_cair
                    .Value = CDate(IIf(in_tglcair.Text = Nothing, in_tgl_bg.Text, in_tglcair.Text))
                    .MinDate = CDate(in_tgl_bg.Text)
                End With
                .ShowDialog(Me)
                If .returnval = True Then
                    in_statusgiro.Text = "DICAIRKAN"
                    in_tglcair.Text = .in_tgl_cair.Text
                    If tipegiro = "IN" Then
                        in_akuncair.Text = .cb_akun.SelectedValue
                        in_akuncair_n.Text = .cb_akun.Text
                    End If
                Else
                    datecairchange = False
                End If
            End With
        End Using
    End Sub

    Private Sub mn_tolak_Click(sender As Object, e As EventArgs) Handles mn_tolak.Click
        If statustolak = True And _allowedit = True Then
            If MessageBox.Show("Ubah data penolakan giro?", "Detail Giro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                datecairchange = True
            End If
        End If

        Using x As New fr_giro_dialog
            With x
                .do_load(tipegiro)
                .lbl_cair.Visible = False
                .cb_akun.Visible = False
                .ShowDialog(Me)
                If .returnval = True Then
                    in_statusgiro.Text = "DITOLAK"
                    in_tglcair.Text = .in_tgl_cair.Text
                Else
                    datecairchange = False
                End If
            End With
        End Using
    End Sub

    'SAVE
    Private Function cairBg(faktur As String, giro As String) As Boolean
        Dim q As String = ""
        Dim data1 As String()
        Dim chkquery As Boolean = False
        Dim queryArr As New List(Of String)

        Dim tanggalcair As String = CDate(in_tglcair.Text).ToString("yyyy-MM-dd")

        q = "UPDATE data_giro_cair SET g_cair_status=9 WHERE g_cair_nobg='{0}'"
        queryArr.Add(String.Format(q, giro))

        q = "INSERT INTO data_giro_cair SET g_cair_nobg='{0}',{1}"
        data1 = {
            "g_cair_tglcair='" & tanggalcair & "'",
            "g_cair_tujuan='" & IIf(tipegiro = "IN", in_akuncair.Text, "") & "'",
            "g_cair_status='1'",
            "g_cair_reg_alias='" & loggeduser.user_id & "'",
            "g_cair_reg_date=NOW()"
            }
        queryArr.Add(String.Format(q, giro, String.Join(",", data1)))

        q = "UPDATE data_giro SET giro_status=2 WHERE giro_no='{0}' AND giro_type='{1}'"
        queryArr.Add(String.Format(q, giro, UCase(tipegiro)))

        '------------> UPDATE PEMBAYARAN HUTANG/PIUTANG
        Select Case UCase(tipegiro)
            Case "OUT"
                q = "UPDATE data_hutang_bayar SET h_bayar_status=1 WHERE h_bayar_bukti='{0}'"
            Case "IN"
                q = "UPDATE data_piutang_bayar SET p_bayar_status=1 WHERE p_bayar_bukti='{0}'"
        End Select
        queryArr.Add(String.Format(q, faktur))

        '==========================================================================================================================
        'INPUT JURNAL
        '----------HEAD
        q = "INSERT INTO data_jurnal_line SET line_kode='{0}', line_type='BGCR',{1},line_reg_date=NOW(),line_reg_alias='{2}' " _
            & "ON DUPLICATE KEY UPDATE {1},line_upd_date=NOW(),line_upd_alias='{2}'"
        data1 = {
            "line_ref='" & faktur & "'",
            "line_ref_type='GIRO" & tipegiro & "'",
            "line_tanggal='" & tanggalcair & "'",
            "line_status='1'"
            }
        queryArr.Add(String.Format(q, giro, String.Join(",", data1), loggeduser.user_id))
        '==========================================================================================================================

        '==========================================================================================================================
        'BEGIN TRANSACTION
        chkquery = startTrans(queryArr)
        '==========================================================================================================================

        Return chkquery
    End Function

    Private Function tolakBg(faktur As String, giro As String) As Boolean
        Dim q As String = ""
        Dim data1 As String()
        Dim chkquery As Boolean = False
        Dim queryArr As New List(Of String)

        Dim tgltolak As String = CDate(in_tglcair.Text).ToString("yyyy-MM-dd")

        q = "UPDATE INTO data_giro_tolak SET g_tolak_status=9 WHERE g_tolak_nobg='{0}'"
        queryArr.Add(String.Format(q, giro))

        q = "INSERT INTO data_giro_tolak SET g_tolak_nobg='{0}',{1}"
        data1 = {
            "g_tolak_tanggal='" & tgltolak & "'",
            "g_tolak_status='1'",
            "g_tolak_reg_alias='" & loggeduser.user_id & "'",
            "g_tolak_reg_date=NOW()"
            }
        queryArr.Add(String.Format(q, giro, String.Join(",", data1)))

        q = "UPDATE data_giro SET giro_status=3 WHERE giro_no='{0}' AND giro_type='{1}'"
        queryArr.Add(String.Format(q, giro, UCase(tipegiro)))

        '------------> UPDATE PEMBAYARAN HUTANG/PIUTANG
        Select Case UCase(tipegiro)
            Case "OUT"
                q = "UPDATE data_hutang_bayar SET p_bayar_status=2 WHERE h_bayar_bukti='{0}'"
            Case "IN"
                q = "UPDATE data_piutang_bayar SET p_bayar_status=2 WHERE p_bayar_bukti='{0}'"
        End Select
        queryArr.Add(String.Format(q, faktur))

        '==========================================================================================================================
        'BEGIN TRANSACTION
        chkquery = startTrans(queryArr)
        '==========================================================================================================================

        Return chkquery
    End Function

    Private Sub saveData()
        op_con()
        Dim q As String = ""
        Dim chkquery As Boolean = False

        Me.Cursor = Cursors.WaitCursor

        q = "UPDATE data_giro SET giro_ket='" & in_ket.Text & "', giro_upd_date=NOW(), giro_upd_alias='{2}' WHERE giro_no='{0}' AND giro_type='{1}'"
        q = String.Format(q, in_nobg.Text, tipegiro, loggeduser.user_id)
        chkquery = commnd(q)

        If UCase(in_statusgiro.Text) = "DICAIRKAN" Then
            Dim question As String = "Simpan data pencairan giro?{0}*Perubahan terhadap transaksi pembayaran yang berhubungan{0}atau penolakan giro tidak dapat dilakukan " _
                                     & "setelah pencairan."

            If MessageBox.Show(String.Format(question, Environment.NewLine), "Detail Giro",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question
                               ) = Windows.Forms.DialogResult.Yes Then
                chkquery = cairBg(in_faktur.Text, in_nobg.Text)
            End If
        ElseIf UCase(in_statusgiro.Text) = "DITOLAK" Then
            Dim question As String = "Simpan data penolakan giro?{0}*Pencairan giro tidak dapat dilakukan setelah penolakan."

            If MessageBox.Show(String.Format(question, Environment.NewLine), "Detail Giro",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question
                               ) = Windows.Forms.DialogResult.Yes Then
                chkquery = tolakBg(in_faktur.Text, in_nobg.Text)
            End If
        End If

        Me.Cursor = Cursors.Default

        If chkquery = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
        Else
            MessageBox.Show("Data tersimpan")
            doRefreshTab({pghutangbgo, pgpiutangbgcair})
            Me.Close()
        End If
    End Sub

    'load
    Public Sub do_load(tipe As String, kode As String)
        tipegiro = tipe

        If currentperiode.id <> selectperiode.id Then _allowedit = False

        formSW(tipe)
        loadData(kode, tipe)
    End Sub

    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        If _allowedit = True Then
            If MessageBox.Show("Simpan data giro?", "Detail Giro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                saveData()
            End If
        End If
    End Sub

    'UI
End Class