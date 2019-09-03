Public Class fr_closing
    Private IdClosing As String = ""
    Private ClSts As Boolean = False
    Private ValidUid As String = ""

    'LOAD FORM
    Public Sub DoLoadDialog(IdClosing As String)
        Me.IdClosing = IdClosing
        loadData(IdClosing)
        FormSwitch()
        Me.ShowDialog(main)
    End Sub

    'FORM SWITCH
    Private Sub FormSwitch()
        Me.Text = lbl_title.Text
        lbl_status.Text = "Status : " & IIf(ClSts, "TUTUP", "OPEN")
        bt_load.Enabled = False
        date_tglawal.Enabled = False
        date_tglakhir.Enabled = IIf(ClSts, False, True)
        ck_confirm.Visible = IIf(ClSts, False, True)
        For Each s As DateTimePicker In {date_tglawal, date_tglakhir}
            s.MinDate = date_tglawal.Value
            s.MaxDate = date_tglakhir.Value
        Next
        If date_tglakhir.Value > Today Then date_tglakhir.Value = Today
        For Each x As Control In {lbl_closeDate, lbl_user1, lbl_user2}
            x.Visible = ClSts
        Next
    End Sub

    'LOAD DATA CLOSING
    Private Sub loadData(IdClosing As String)
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _q As String = "SELECT tutupbk_periode_tglawal, tutupbk_periode_tglakhir, tutupbk_closed, " _
                                   & "IFNULL(tutupbk_user,''), IFNULL(tutupbk_valid,''), " _
                                   & "DATE_FORMAT(tutupbk_tgl, '%d %M %Y'), DATE_FORMAT(tutupbk_time, '%H:%i:%s') " _
                                   & "FROM data_tutup_buku WHERE tutupbk_id='{0}'"
                Using rdx = x.ReadCommand(String.Format(_q, IdClosing))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        date_tglawal.Value = rdx.Item(0)
                        date_tglakhir.Value = rdx.Item(1)
                        lbl_user1.Text = "Validate by " & rdx.Item(4)
                        lbl_user2.Text = "Closed by " & rdx.Item(3)
                        lbl_closeDate.Text = "Closed on " & rdx.Item(5) & " " & rdx.Item(6)
                        ClSts = rdx.Item(2)
                    Else
                        MessageBox.Show("Terjadi kesalahan saat melakukan pengambilan data.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Close()
                    End If
                End Using

            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End Using
    End Sub

    'DRAG FORM
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

    'CLOSE
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_cancel.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_cancel.PerformClick()
    End Sub

    Private Sub fr_jual_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_cancel.PerformClick()
        End If
    End Sub

    Private Sub fr_closing_FormClosed(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DoRefreshTab_v2({pgtutupbuku})
    End Sub

    'CLOSING PERIODE
    Private Function ConfirmValidasi(JenisValid As String) As Boolean
        Dim valid As New fr_tutupconfirm_dialog
        Select Case JenisValid
            Case "ValidClosing"
                valid.doLoadValid()
                If valid.returnval.Key Then
                    ValidUid = valid.returnval.Value
                    Return True
                Else
                    If valid.returnval.Value <> String.Empty Then
                        MessageBox.Show(valid.returnval.Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                    Return False
                End If
            Case "UserConfirm"
                valid.doLoadConfirm(loggeduser.user_id)
                Return valid.returnval.Key
            Case Else
                Return False
        End Select
    End Function

    Private Function NewClosing(StartDate As Date, EndDate As Date) As Boolean
        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                Dim _q As String = ""
                Dim _ck As Boolean = False
                Dim _done As Boolean = False
                Dim _diff As Integer = DateDiff(DateInterval.Day, StartDate, EndDate)

                consoleWriteLine("START PROCEDURE : " & Now.ToString)
                Try
                    'UPDATE VARIABLE SYSTEM
                    _q = "UPDATE system_var SET var_value='TRUE' WHERE var_name IN ('sys_syslock', 'sys_dblock', 'eventsch_jual_running')"
                    x.ExecCommand(_q)

                    _q = "UPDATE system_var SET var_value='System sedang melakukan closing periode. Harap tunggu beberapa saat lagi.' WHERE var_name='sys_lockmsg'"
                    x.ExecCommand(_q)

                    _q = "UPDATE data_tutup_buku SET tutupbk_closed=2 WHERE tutupbk_id='{0}'"

                    'DO REVALUATE HPP IN 'TRANSAKSI'
                    Dim _day As Integer = StartDate.Day
                    Dim _month As Integer = StartDate.Month
                    Dim _year As Integer = StartDate.Year

                    Do While _done = False
                        consoleWriteLine(DateSerial(_year, _month, _day))
                        _q = "CALL Closing_RevaluateHPPTransaksi_date('{0:yyyy-MM-dd}', '{1}')"
                        x.ExecCommand(String.Format(_q, DateSerial(_year, _month, _day), loggeduser.user_id))

                        Dim _nextdate = DateSerial(_year, _month, _day + 1)
                        If _nextdate > EndDate Then
                            _done = True
                        Else
                            _day = _nextdate.Day
                            _month = _nextdate.Month
                            _year = _nextdate.Year
                        End If
                    Loop
                    _ck = _done

                    'CREATE JURNAL PENUTUPAN
                    _q = "CALL Closing_createJurnalPenutupan('{0:yyyy-MM-dd}', '{1:yyyy-MM-dd}', '{2}')"
                    If _ck Then : x.ExecCommand(String.Format(_q, StartDate, EndDate, loggeduser.user_id)) : _ck = True : End If

                    'INSERT LABA RUGI AWAL
                    _q = "CALL Closing_createLabaRugiAwal('{0:yyyy-MM-dd}', '{1:yyyy-MM-dd}', '{2}')"
                    If _ck Then : x.ExecCommand(String.Format(_q, StartDate, EndDate, loggeduser.user_id)) : _ck = True : End If

EndProc:
                    If _ck Then
                        'UPDATE DATA CLOSING
                        _q = "UPDATE data_tutup_buku " _
                            & "SET tutupbk_periode_tglakhir='{1:yyyy-MM-dd}', tutupbk_closed=1, " _
                            & "tutupbk_tgl=CURDATE(), tutupbk_time=NOW(), tutupbk_valid='{2}', tutupbk_user='{3}' " _
                            & "WHERE tutupbk_id='{0}'"
                        x.ExecCommand(String.Format(_q, IdClosing, EndDate, ValidUid, loggeduser.user_id))
                        _q = "INSERT INTO data_tutup_buku(tutupbk_id, tutupbk_periode_tglawal, tutupbk_reg_date, tutupbk_reg_alias) " _
                            & "VALUE('{0}', '{1:yyyy-MM-dd}', NOW(), '{2}')"
                        x.ExecCommand(String.Format(_q, CInt(IdClosing) + 1, EndDate.AddDays(1), loggeduser.user_id))

                        'UPDATE VARIABLE SYSTEM
                        _q = "UPDATE system_var SET var_value='FALSE' WHERE var_name IN ('sys_syslock', 'sys_dblock', 'eventsch_jual_running')"
                        x.ExecCommand(_q)
                        _q = "UPDATE system_var SET var_value=NULL WHERE var_name='sys_lockmsg'"
                        x.ExecCommand(_q)

                        consoleWriteLine("END PROCEDURE : " & Now.ToString)
                        Return True
                    Else
                        'LOG ERROR

                        _q = "UPDATE system_var SET var_value='Terjadi Kesalahaan saat melakukan proses penutupan periode.' WHERE var_name='sys_lockmsg'"
                        x.ExecCommand(_q)

                        consoleWriteLine("END PROCEDURE : " & Now.ToString)
                        Return False
                    End If
                Catch ex As Exception
                    logError(ex, True)
                    MessageBox.Show("Terjadi kesalahan saat melakukan proses closing." & Environment.NewLine & ex.Message,
                                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    consoleWriteLine("END PROCEDURE : " & Now.ToString)
                    Return False
                End Try
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK)
                Return False
            End If
        End Using
    End Function

    Private Function StartClosing(StartDate As Date, EndDate As Date) As Boolean
        Dim view As New fr_closing_loading
        Dim ck As Boolean = False
        view.Show(Me)
        Return view.IsDisposed
    End Function

    'LOAD REPORT
    Private Sub LoadReport(ReportType As String, StartDate As Date, EndDate As Date, PjkType As Integer)
        Dim LapType As String = ""
        Select Case ReportType
            Case "penyesuaian" : LapType = "k_jurnalsesuai"
            Case "neracasaldo"

            Case "labarugi" : LapType = "k_labarugi"
            Case "neraca"

            Case "labarugi_comp" : LapType = "k_laba_comp"
            Case "neraca_comp"
            Case Else : Exit Sub
        End Select
        Using ff As New fr_lap_filter_keuangan
            ff.do_loadview(LapType, StartDate, EndDate, PjkType)
        End Using
    End Sub

    'UI : BUTTON
    Private Async Sub bt_load_Click(sender As Object, e As EventArgs) Handles bt_load.Click
        Dim _msgRes As DialogResult = Windows.Forms.DialogResult.No
        Dim ck As Boolean = False
        Dim _msgPeriode As String = ""
        If date_tglakhir.Value.ToString("MMyyyy") = date_tglawal.Value.ToString("MMyyyy") AndAlso date_tglawal.Value.Day = 1 _
            AndAlso date_tglakhir.Value.Day = DateSerial(date_tglakhir.Value.Year, date_tglakhir.Value.Month + 1, 0).Day Then
            _msgPeriode = date_tglawal.Value.ToString("MMMM yyyy")
        Else
            _msgPeriode = date_tglawal.Value.ToString("dd/MM/yyyy") & " S.d " & date_tglakhir.Value.ToString("dd/MM/yyyy")
        End If

        _msgRes = MessageBox.Show(String.Format("Tutup periode transaksi {0}?", _msgPeriode), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _msgRes = Windows.Forms.DialogResult.Yes Then ck = ConfirmValidasi("UserConfirm")
        Me.Cursor = Cursors.WaitCursor
        If ck Then
            Dim view As New fr_closing_loading
            Try
                view.lbl_title.Text = "Closing Periode " & _msgPeriode & " . . . "
                view.Show()
                main.Enabled = False
                ck = Await Task.Run(Function() NewClosing(date_tglawal.Value, date_tglakhir.Value))
            Catch ex As Exception
                logError(ex, True)
                MessageBox.Show("Terjadi kesalahan saat melakukan proses closing." & Environment.NewLine & ex.Message,
                                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                main.Enabled = True
                view.Close()
                If ck Then
                    loadData(Me.IdClosing)
                    FormSwitch()
                    MessageBox.Show("Closing periode berhasil.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    setperiode(Today, False)
                Else
                    MessageBox.Show("Terjadi kesalahan saat melakukan proses penutupan periode.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

    End Sub

    'UI : CHECKBOX
    Private Sub ck_confirm_CheckedChanged(sender As Object, e As EventArgs) Handles ck_confirm.CheckedChanged
        If ck_confirm.Checked Then
            ck_confirm.Checked = ConfirmValidasi("ValidClosing")
            If ck_confirm.Checked Then bt_load.Focus()
        End If
        bt_load.Enabled = ck_confirm.Checked
    End Sub
End Class