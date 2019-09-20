Public Class fr_giro
    Public tipegiro As String = ""
    Private statuscair As Boolean = False
    Private datecairchange As Boolean = False
    Private statustolak As Boolean = False
    Private bankpencairan As String = ""

    Private _statusgiro As String
    Private _akuncair As String
    Private _tglcairtolak As Date
    Private _allowedit As Boolean = True

    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
    End Enum

    'LOAD
    Public Sub do_load(tipe As String, kode As String)
        tipegiro = tipe

        If currentperiode.id <> selectperiode.id Then _allowedit = False

        loadData(kode, tipe)
        formSW(tipe)
        Me.Show(main)
    End Sub

    'LOAD DATA GIRO
    Private Sub loadData(kode As String, tipe As String)
        Dim q As String = ""

        'On Error Resume Next
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                If tipe = "OUT" Then
                    q = "SELECT giro_no, giro_nilai, giro_tglterima, giro_tglefektif, giro_tgl_tolakcair, giro_bank, perk_nama_akun, " _
                        & "giro_ref2, GetMasterNama('supplier', giro_ref2) giro_ref2_n, giro_ref, giro_ket, giro_status_pencairan, giro_status " _
                        & "FROM data_giro  " _
                        & "left join data_hutang_bayar ON giro_ref=h_bayar_bukti AND h_bayar_status=1 " _
                        & "LEFT JOIN data_perkiraan ON perk_kode=giro_bank " _
                        & "WHERE giro_type='OUT' AND giro_no='{0}'"
                ElseIf tipe = "IN" Then
                    q = "SELECT giro_no, giro_nilai, giro_tglterima, giro_tglefektif, giro_tgl_tolakcair, " _
                        & "giro_ref, IFNULL(p_bayar_akun, '') p_bayar_akun, IFNULL(giro_akun_pencairan, '') giro_akun_pencairan, " _
                        & "IFNULL(perk_nama_akun, '') perk_nama_akun, giro_ref2, GetMasterNama('custo', giro_ref2) giro_ref2_n, " _
                        & "giro_ket, giro_status_pencairan, giro_status, giro_bank " _
                        & "FROM data_giro " _
                        & "left join data_piutang_bayar ON giro_ref=p_bayar_bukti AND p_bayar_status<>9 " _
                        & "LEFT JOIN data_perkiraan ON giro_akun_pencairan=perk_kode " _
                        & "WHERE giro_type='IN' AND giro_no='{0}'"
                Else : Exit Sub
                End If
                q = String.Format(q, kode)

                Using rdx = x.ReadCommand(q)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        Try
                            'DATA GIRO
                            in_nobg.Text = rdx.Item("giro_no")
                            in_nilaibg.Text = commaThousand(rdx.Item("giro_nilai"))
                            in_tgl_penarikan.Text = CDate(rdx.Item("giro_tglterima"))
                            in_tgl_bg.Text = CDate(rdx.Item("giro_tglefektif"))
                            _statusgiro = rdx.Item("giro_status_pencairan")
                            If tipe = "OUT" Then
                                in_bank.Text = rdx.Item("giro_bank")
                                in_bank_n.Text = rdx.Item("perk_nama_akun")
                            Else
                                in_bank_n.Text = rdx.Item("giro_bank")
                                bankpencairan = rdx.Item("p_bayar_akun")
                            End If

                            'DATA STATUS GIRO
                            If _statusgiro = 2 Then
                                in_statusgiro.Text = "DITOLAK"
                                _tglcairtolak = CDate(rdx.Item("giro_tgl_tolakcair"))
                                in_tglcair.Text = _tglcairtolak.ToShortDateString
                            ElseIf _statusgiro = 1 Then
                                statuscair = True
                                in_statusgiro.Text = "DICAIRKAN"
                                _tglcairtolak = CDate(rdx.Item("giro_tgl_tolakcair"))
                                If tipe = "IN" Then
                                    in_akuncair.Text = rdx.Item("giro_akun_pencairan")
                                    in_akuncair_n.Text = rdx.Item("perk_nama_akun")
                                End If
                                in_tglcair.Text = _tglcairtolak.ToShortDateString
                            End If

                            'DATA REF
                            in_ref.Text = rdx.Item("giro_ref2")
                            in_ref_n.Text = rdx.Item("giro_ref2_n")
                            in_faktur.Text = rdx.Item("giro_ref")
                            in_ket.Text = rdx.Item("giro_ket")
                        Catch ex As Exception
                            logError(ex, True)
                            MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data giro." & Environment.NewLine & ex.Message,
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    Else
                        MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data giro." & Environment.NewLine & "Data giro tidak dapat ditemukan.",
                                        Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
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

        If selectperiode.closed = True Or loggeduser.allowedit_transact = False Then
            mn_cair.Enabled = False
            mn_tolak.Enabled = False
        Else
            If CDate(in_tgl_bg.Text) <= Today And _statusgiro = 0 Then
                mn_cair.Enabled = True
            ElseIf CDate(in_tgl_bg.Text) > Today And _statusgiro = 0 Then
                mn_cair.Enabled = False
            End If

            If _statusgiro = "1" Then
                mn_tolak.Enabled = False
                mn_cair.Text = "Ubah Tanggal Cair"
            ElseIf _statusgiro = "2" Then
                mn_cair.Enabled = False
                mn_tolak.Text = "Ubah Tanggal Tolak"
            End If
        End If
        bt_simpanbeli.Enabled = _allowedit
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

    'UI : CLOSE
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        'If MessageBox.Show("Tutup Form?", "Detail Giro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        Me.Close()
        'End If
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

    Private Sub fr_pesan_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            bt_batalbeli.PerformClick()
            e.SuppressKeyPress = True
        End If
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
                If bankpencairan <> Nothing Then
                    .cb_akun.SelectedValue = bankpencairan
                End If
                .ShowDialog(Me)
                If .returnval Then
                    in_statusgiro.Text = "DICAIRKAN"
                    in_tglcair.Text = .in_tgl_cair.Text
                    If tipegiro = "IN" Then
                        in_akuncair.Text = .cb_akun.SelectedValue
                        in_akuncair_n.Text = .cb_akun.Text
                    End If
                    datecairchange = True
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
                If .returnval Then
                    in_statusgiro.Text = "DITOLAK"
                    in_tglcair.Text = .in_tgl_cair.Text
                    datecairchange = True
                Else
                    datecairchange = False
                End If
            End With
        End Using
    End Sub

    'SAVE
    Private Function cairBg(faktur As String, giro As String) As Boolean
        Dim q As String = ""
        'Dim data1 As String()
        Dim chkquery As Boolean = False
        Dim queryArr As New List(Of String)

        Dim tanggalcair As String = CDate(in_tglcair.Text).ToString("yyyy-MM-dd")

        consoleWriteLine(giro)

        '==========================================================================================================================
        q = "UPDATE data_giro SET giro_status_pencairan=1, giro_tgl_tolakcair='{1}',giro_akun_pencairan='{2}',giro_user_tolakcair='{3}' WHERE giro_no='{0}'"
        queryArr.Add(String.Format(q, giro, tanggalcair, in_akuncair.Text, loggeduser.user_id))
        '==========================================================================================================================

        '==========================================================================================================================
        q = "CALL transGiroFin('{0}','{1}')"
        queryArr.Add(String.Format(q, giro, loggeduser.user_id))
        '==========================================================================================================================

        '==========================================================================================================================
        'BEGIN TRANSACTION
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Return x.TransactCommand(queryArr)
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Using
        '==========================================================================================================================

        Return chkquery
    End Function

    Private Function tolakBg( giro As String) As Boolean
        Dim q As String = ""
        Dim chkquery As Boolean = False
        Dim queryArr As New List(Of String)

        Dim tgltolak As String = CDate(in_tglcair.Text).ToString("yyyy-MM-dd")

        consoleWriteLine(giro)

        '==========================================================================================================================
        q = "UPDATE data_giro SET giro_status_pencairan=2, giro_tgl_tolakcair='{1}',giro_user_tolakcair='{2}' WHERE giro_no='{0}'"
        queryArr.Add(String.Format(q, giro, tgltolak, loggeduser.user_id))
        '==========================================================================================================================

        '==========================================================================================================================
        q = "CALL transGiroFin('{0}','{1}')"
        queryArr.Add(String.Format(q, giro, loggeduser.user_id))
        '==========================================================================================================================

        '==========================================================================================================================
        'BEGIN TRANSACTION
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Return x.TransactCommand(queryArr)
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Using
        '==========================================================================================================================
    End Function

    Private Sub saveData()
        Dim q As String = ""
        Dim queryArr As New List(Of String)
        Dim chkquery As Boolean = False

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                q = "UPDATE data_giro SET giro_ket='{1}', giro_upd_date=NOW(), giro_upd_alias='{3}' WHERE giro_no='{0}' AND giro_type='{2}'"
                queryArr.Add(String.Format(q, in_nobg.Text, mysqlQueryFriendlyStringFeed(in_ket.Text), tipegiro, loggeduser.user_id))

                chkquery = x.TransactCommand(queryArr)

                If chkquery And datecairchange Then
                    If loggeduser.allowedit_transact And Not selectperiode.closed Then
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
                                chkquery = tolakBg(in_nobg.Text)
                            End If
                        End If
                    End If
                End If

                If chkquery Then
                    MessageBox.Show("Data giro tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pghutangbgo, pgpiutangbgcair}) : Me.Close()
                Else
                    MessageBox.Show("Data giro tidak dapat tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    'UI : SAVE
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        If _allowedit Then
            Me.Cursor = Cursors.WaitCursor
            Dim _resMsg As DialogResult = Windows.Forms.DialogResult.Yes
            _resMsg = MessageBox.Show("Simpan data giro?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If _resMsg = Windows.Forms.DialogResult.Yes Then saveData()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    'UI
End Class