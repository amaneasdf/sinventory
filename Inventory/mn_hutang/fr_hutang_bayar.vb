Public Class fr_hutang_bayar
    Private popupstate As String = ""
    Private indexrowlist As Integer = 0
    Private indexrowbayar As Integer = 0

    Private selectedsup As String = ""
    Private _totaltitipan As Double = 0

    Private _sisaHutang As Double = 0
    Public _totalhutang As Double = 0

    Private Sub loadData(kode As String)
        Dim nobg As String = ""
        Dim tglbgcair As String = ""
        Dim akun As String = ""
        Dim q As String = "SELECT h_bayar_bukti, h_bayar_supplier, supplier_nama, h_bayar_jenis_bayar, h_bayar_akun, h_bayar_tgl_bayar, h_bayar_tgl_jt, " _
                          & "IFNULL(giro_no,'') as giro_no, h_bayar_ket, h_bayar_potongan_nilai, " _
                          & "CONCAT((CASE giro_status_pencairan WHEN 1 THEN 'CAIR : ' WHEN 2 THEN 'TOLAK : ' ELSE '' END),IFNULL(DATE_FORMAT(giro_tgl_tolakcair,'%d/%m/%Y'),'')) tgl, " _
                          & "h_bayar_reg_alias,h_bayar_reg_date,h_bayar_upd_alias,h_bayar_upd_date, " _
                          & "getSisaTitipan('hutang','" & selectperiode.id & "',h_bayar_supplier) as titipan " _
                          & "FROM data_hutang_bayar LEFT JOIN data_supplier_master ON supplier_kode=h_bayar_supplier " _
                          & "LEFT JOIN data_giro ON giro_no=h_bayar_giro_no AND giro_status<>9 AND giro_type='OUT'" _
                          & "WHERE h_bayar_bukti='{0}'"

        op_con()
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            in_no_bukti.Text = rd.Item("h_bayar_bukti")
            in_supplier.Text = rd.Item("h_bayar_supplier")
            in_supplier_n.Text = rd.Item("supplier_nama")
            in_saldotitipan.Text = commaThousand(rd.Item("titipan"))
            cb_bayar.SelectedValue = rd.Item("h_bayar_jenis_bayar")
            akun = rd.Item("h_bayar_akun")
            date_tgl_trans.Value = rd.Item("h_bayar_tgl_bayar")
            date_bg_tgl.Value = rd.Item("h_bayar_tgl_jt")
            in_ket.Text = rd.Item("h_bayar_ket")
            nobg = rd.Item("giro_no")
            tglbgcair = rd.Item("tgl")
            in_potongan.Value = rd.Item("h_bayar_potongan_nilai")
            txtRegAlias.Text = rd.Item("h_bayar_reg_alias")
            txtRegdate.Text = rd.Item("h_bayar_reg_date")
            txtUpdAlias.Text = rd.Item("h_bayar_upd_alias")
            Try
                txtUpdDate.Text = rd.Item("h_bayar_upd_date")
            Catch ex As Exception
                txtUpdDate.Text = "0000/00/00 00:00:00"
            End Try
            'If IsDBNull(rd.Item("giro_no")) = False Then
            '    in_nobg.Text = rd.Item("giro_no")
            '    in_tglpencairan.Text = IIf(IsDBNull(rd.Item("g_cair_tglcair")), "", rd.Item("g_cair_tglcair"))
            'End If
        End If
        rd.Close()

        loadCBAkun(cb_bayar.SelectedValue)
        cb_akun.SelectedValue = akun

        selectedsup = in_supplier.Text
        in_supplier_n.ReadOnly = True

        If nobg <> Nothing And cb_bayar.SelectedValue = "BG" Then in_no_bg.Enabled = True
        in_no_bg.Text = nobg
        in_tglpencairan.Text = tglbgcair

        If Trim(in_tglpencairan.Text) <> Nothing And cb_bayar.SelectedValue = "BG" Then
            'IF jenisbayar->BG AND sudahdicairkan SET readonly ALL
            in_no_bg.ReadOnly = True
        End If

        loadListedBayar(kode)
        in_supplier.Focus()

        If loggeduser.allowedit_transact = False Or selectperiode.closed = True Then
            For Each txt As TextBox In {in_supplier_n, in_faktur, in_no_bg, in_no_bukti, in_ket}
                txt.ReadOnly = True
            Next

            cb_bayar.Enabled = False
            cb_akun.Enabled = False
            date_bg_tgl.Enabled = False
            date_tgl_trans.Enabled = False
            mn_save.Enabled = False
            bt_tbbayar.Enabled = False
            bt_simpanperkiraan.Visible = False
            bt_batalperkiraan.Text = "Tutup"
            'pnl_content.Enabled = False
        End If
    End Sub

    Private Sub loadListedBayar(kode As String)
        Dim dt As New DataTable
        Dim q As String = "SELECT h_trans_faktur, DATE_FORMAT(ADDDATE(faktur_tanggal_trans,faktur_term),'%d/%m/%Y'), faktur_total_netto, " _
                          & "h_trans_sisa, h_trans_nilaibayar " _
                          & "FROM data_hutang_bayar_trans LEFT JOIN data_pembelian_faktur ON h_trans_faktur=faktur_kode AND faktur_status=1 " _
                          & "WHERE h_trans_status=1 AND h_trans_bukti='{0}'"
        dt = getDataTablefromDB(String.Format(q, kode))
        With dgv_bayar.Rows
            For Each rows As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("bayar_faktur").Value = rows.ItemArray(0)
                    .Cells("bayar_jt").Value = rows.ItemArray(1)
                    .Cells("bayar_saldoawal").Value = rows.ItemArray(2)
                    .Cells("bayar_sisahutang").Value = rows.ItemArray(3)
                    .Cells("bayar_kredit").Value = rows.ItemArray(4)
                End With
            Next
        End With
        dt.Dispose()

        in_total.Text = commaThousand(countTotal())
    End Sub

    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        setDoubleBuffered(Me.dgv_listbarang, True)
        Dim q As String
        With dgv_listbarang
            .DataSource = Nothing
            Select Case tipe
                Case "supplier"
                    q = "SELECT supplier_kode as Kode, supplier_nama as Nama, getSisaTitipan('hutang','{0}',supplier_kode) as sisaTitip " _
                        & "FROM data_supplier_master WHERE supplier_nama LIKE '" & param & "%' LIMIT 100"
                    q = String.Format(q, selectperiode.id)
                Case "faktur"
                    q = "SELECT hutang_faktur AS Faktur, getSisaHutang(hutang_faktur,{0}) as Sisa, faktur_total_netto, " _
                        & "DATE_FORMAT(ADDDATE(faktur_tanggal_trans,faktur_term),'%d/%m/%Y') as TglJatuhTempo " _
                        & "FROM data_hutang_awal LEFT JOIN data_pembelian_faktur ON faktur_kode= hutang_faktur AND faktur_status=1 " _
                        & "WHERE hutang_status=1 AND hutang_faktur LIKE '{1}%' AND faktur_supplier='{2}'"
                    q = String.Format(q, selectperiode.id, param, in_supplier.Text)
                Case Else
                    Exit Sub
            End Select
            .DataSource = getDataTablefromDB(q)
            .Columns(0).Width = 150
            .Columns(1).Width = 125
            If tipe = "faktur" Then
                .Columns(1).DefaultCellStyle = dgvstyle_currency
                .Columns(2).Visible = False
            ElseIf tipe = "supplier" Then
                .Columns(2).Visible = False
            End If
            popupstate = tipe
        End With
    End Sub

    Private Sub setSupplier(kode As String)
        If kode <> Nothing Then
            Dim q As String = "SELECT supplier_kode, supplier_nama FROM data_supplier_master WHERE supplier_kode='" & kode & "'"
            op_con()
            readcommd(q)
            If rd.HasRows Then
                in_supplier.Text = rd.Item("supplier_kode")
                in_supplier_n.Text = rd.Item("supplier_nama")
            End If
            rd.Close()
        End If
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "supplier"
                    in_supplier.Text = .Cells(0).Value
                    in_supplier_n.Text = .Cells(1).Value
                    in_saldotitipan.Text = commaThousand(.Cells(2).Value)
                    cb_bayar.Focus()
                Case "faktur"
                    in_faktur.Text = .Cells(0).Value
                    in_sisafaktur.Text = commaThousand(.Cells(1).Value)
                    _totalhutang = .Cells(2).Value
                    in_tgl_jtfaktur.Text = .Cells(3).Value
                    'setFaktur(in_faktur.Text)
                    in_kredit.Focus()
                Case Else
                    Exit Sub
            End Select

        End With
        popPnl_barang.Visible = False
    End Sub

    Private Function checkFaktur() As Boolean
        op_con()
        Try
            readcommd("SELECT faktur_kode,faktur_supplier FROM data_pembelian_faktur WHERE faktur_kode='" & in_faktur.Text & "' AND faktur_status=1")
            If rd.HasRows Then
                If in_supplier.Text = "" Then
                    rd.Close()
                    setSupplier(rd.Item("faktur_supplier"))
                    Return True
                ElseIf in_supplier.Text <> "" And rd.Item("faktur_supplier") <> in_supplier.Text Then
                    in_faktur.Focus()
                    rd.Close()
                    MessageBox.Show("No.Faktur yg diinput tidak sesuai dg supplier")
                    Return False
                Else
                    rd.Close()
                    Return True
                End If
            Else
                rd.Close()
                MessageBox.Show("No.Faktur yg diinput tidak sesuai")
                Return False
            End If
        Catch ex As Exception
            consoleWriteLine(String.Format("Error: {0}", ex.Message))
            MessageBox.Show(String.Format("Error. {1}: {0}", ex.GetType.ToString & ex.Message, "Terjadi Kesalahan"))
            logError(ex)
            Return False
        End Try
    End Function

    Private Sub textToDGV()
        Dim _faktur_sw = True
        Dim _kredit_sw = True

        If Trim(in_faktur.Text) = "" And in_kredit.Value <> 0 Then
            _faktur_sw = False
        ElseIf Trim(in_faktur.Text) <> "" And in_tgl_jtfaktur.Text = "" Then
            _faktur_sw = False
        ElseIf checkFaktur() = False Then
            _faktur_sw = False
        End If
        If _faktur_sw = False Then
            in_faktur.Focus()
            MessageBox.Show("Faktur tidak sesuai")
            Exit Sub
        End If
        If in_kredit.Value > removeCommaThousand(in_sisafaktur.Text) Then
            MessageBox.Show("Saldo Pembayaran lebih besar dari sisa")
            in_kredit.Focus()
            Exit Sub
        End If
        If in_kredit.Value = 0 Then
            in_kredit.Focus()
            Exit Sub
        End If
        If cb_bayar.SelectedValue = "PIUTSUPL" And removeCommaThousand(in_saldotitipan.Text) < in_kredit.Value + removeCommaThousand(in_total.Text) Then
            MessageBox.Show("Saldo Titipan tidak Mencukupi")
            in_kredit.Focus()
            Exit Sub
        End If


        dgv_bayar.Rows.Add(in_faktur.Text, in_tgl_jtfaktur.Text, _totalhutang, removeCommaThousand(in_sisafaktur.Text), in_kredit.Value)
        clearInput("bayar")
        in_total.Text = commaThousand(countTotal())
    End Sub

    Private Sub dgvToText(tipe As String)
        If in_faktur.Text <> Nothing And in_kredit.Value <> 0 Then
            bt_tbbayar.PerformClick()
        End If
        With dgv_bayar.Rows(indexrowbayar)
            in_faktur.Text = .Cells("bayar_faktur").Value
            in_tgl_jtfaktur.Text = .Cells("bayar_jt").Value
            _totalhutang = .Cells("bayar_saldoawal").Value
            in_sisafaktur.Text = commaThousand(.Cells("bayar_sisahutang").Value)
            in_kredit.Value = .Cells("bayar_kredit").Value
        End With
        dgv_bayar.Rows.RemoveAt(indexrowbayar)

        in_total.Text = commaThousand(countTotal())
    End Sub

    Private Function countTotal() As Double
        Dim res As Double = 0

        For Each row As DataGridViewRow In dgv_bayar.Rows
            res += row.Cells("bayar_kredit").Value
        Next

        res -= in_potongan.Value

        Return res
    End Function

    Private Sub loadCBAkun(kode As String)
        Dim q As String = "SELECT perk_kode as 'Value',perk_nama_akun as 'Text' FROM data_perkiraan WHERE perk_status=1 AND perk_parent='{0}'"
        Dim kodeparent As String = "1101"
        With cb_akun
            .DataSource = Nothing
            Select Case kode
                Case "TUNAI"
                    kodeparent = "1101"
                    .DataSource = getDataTablefromDB(String.Format(q, kodeparent))
                Case "BG", "TRANSFER"
                    kodeparent = "1102"
                    .DataSource = getDataTablefromDB(String.Format(q, kodeparent))
                Case "PIUTSUPL"
                    kodeparent = "1105"
                    .DataSource = getDataTablefromDB(String.Format(q, kodeparent) & " AND perk_kode='110502'")
                Case Else
                    Exit Sub
            End Select
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With
    End Sub

    Private Sub clearInput(tipe As String)
        Select Case tipe
            Case "bayar"
                in_faktur.Clear()
                in_sisafaktur.Clear()
                in_tgl_jtfaktur.Clear()
                _totalhutang = 0
                in_kredit.Value = 0
                'Case "all"
                '    For Each x As TextBox In {in_faktur, in_supplier, in_supplier_n, in_no_bukti, in_bg_no, txtRegAlias, txtRegdate, txtUpdAlias, txtUpdDate}
                '        x.Clear()
                '    Next
                '    For Each dgv As DataGridView In {dgv_bayar, dgv_listbarang}
                '        dgv.Rows.Clear()
                '    Next
                '    For Each nu As NumericUpDown In {in_kredit}
                '        nu.Value = 0
                '        nu.Maximum = 999999999999
                '    Next
                '    With date_tgl_trans
                '        .Value = DateSerial(selectedperiode.Year, selectedperiode.Month, date_tgl_trans.Value.Day)
                '        .MaxDate = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, 0)
                '        .MinDate = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
                '    End With
                '    date_bg_tgl.Value = DateSerial(selectedperiode.Year, selectedperiode.Month, date_tgl_trans.Value.Day)
            Case Else
                Exit Sub
        End Select
    End Sub

    'SAVE DATA
    Private Sub saveBayar()
        Dim q As String = ""
        Dim querycheck As Boolean = False
        Dim dataHead As String()
        Dim data1, data2 As String()
        Dim queryArr As New List(Of String)
        op_con()

        '==========================================================================================================================
        'INPUT HEADER
        dataHead = {
            "h_bayar_tgl_bayar='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
            "h_bayar_tgl_jt='" & date_bg_tgl.Value.ToString("yyyy-MM-dd") & "'",
            "h_bayar_supplier='" & in_supplier.Text & "'",
            "h_bayar_jenis_bayar='" & cb_bayar.SelectedValue & "'",
            "h_bayar_akun='" & cb_akun.SelectedValue & "'",
            "h_bayar_potongan_nilai=" & in_potongan.Value.ToString.Replace(",", "."),
            "h_bayar_ket='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
            "h_bayar_status='1'"
            }
        data2 = {
            "h_bayar_giro_no='" & in_no_bg.Text & "'"
            }

        If bt_simpanperkiraan.Text = "Simpan Pembayaran" Then
            'GENERATE KODE
            If in_no_bukti.Text = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT COUNT(h_bayar_bukti) FROM data_hutang_bayar WHERE SUBSTRING(h_bayar_bukti,3,8)='" & date_tgl_trans.Value.ToString("yyyyMMdd") & "' AND h_bayar_bukti LIKE 'PH%'")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()
                in_no_bukti.Text = "PH" & date_tgl_trans.Value.ToString("yyyyMMdd") & no.ToString("D3")
            ElseIf in_no_bukti.Text <> Nothing And LCase(bt_simpanperkiraan.Text) = "simpan pembayaran" Then
                If checkdata("data_hutang_bayar", "'" & in_no_bukti.Text & "'", "h_bayar_bukti") = True Then
                    MessageBox.Show("Nomor faktur " & in_no_bukti.Text & " sudah pernah diinputkan", "Pembayaran Hutang", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    in_no_bukti.Focus()
                    Exit Sub
                End If
            End If
            q = "INSERT INTO data_hutang_bayar SET h_bayar_bukti='{0}',{1},h_bayar_reg_date=NOW(),h_bayar_reg_alias='{2}'"
        ElseIf bt_simpanperkiraan.Text = "Update" Then
            q = "UPDATE data_hutang_bayar SET {1},h_bayar_upd_date=NOW(),h_bayar_upd_alias='{2}' WHERE h_bayar_bukti='{0}'"
        End If
        queryArr.Add(String.Format(
                     q, in_no_bukti.Text,
                     String.Join(",", dataHead) & IIf(cb_bayar.SelectedValue <> "BG", "", "," & String.Join(",", data2)),
                     loggeduser.user_id)
                 )
        '==========================================================================================================================

        '==========================================================================================================================
        'INPUT BAYAR
        q = "UPDATE data_hutang_bayar_trans SET h_trans_status=9 WHERE h_trans_bukti='{0}'"
        queryArr.Add(String.Format(q, in_no_bukti.Text))

        For Each rows As DataGridViewRow In dgv_bayar.Rows
            q = "INSERT INTO data_hutang_bayar_trans SET h_trans_bukti='{0}', h_trans_faktur='{1}',{2} ON DUPLICATE KEY UPDATE {2}"
            data1 = {
                "h_trans_sisa=" & rows.Cells("bayar_sisahutang").Value.ToString.Replace(",", "."),
                "h_trans_nilaibayar=" & rows.Cells("bayar_kredit").Value.ToString.Replace(",", "."),
                "h_trans_nobg='" & IIf(cb_bayar.SelectedValue = "BG", in_no_bg.Text, "") & "'",
                "h_trans_reg_date=NOW()",
                "h_trans_reg_alias='" & loggeduser.user_id & "'",
                "h_trans_status='1'"
                }
            queryArr.Add(String.Format(q, in_no_bukti.Text, rows.Cells(0).Value, String.Join(",", data1)))
        Next
        '==========================================================================================================================

        '==========================================================================================================================
        q = "CALL transBayarHutangFin('{0}','{1}')"
        queryArr.Add(String.Format(q, in_no_bukti.Text, loggeduser.user_id))
        '==========================================================================================================================


        '==========================================================================================================================
        'BEGIN TRANSACTION
        querycheck = startTrans(queryArr)
        '==========================================================================================================================

        Me.Cursor = Cursors.Default

        If querycheck = False Then
            Exit Sub
        Else
            'TODO : WRITE LOG ACTIVITY
            MessageBox.Show("Data tersimpan")
            'frmhutangbayar.in_cari.Clear()
            'populateDGVUserCon("hutangbayar", "", frmhutangbayar.dgv_list)
            doRefreshTab({pghutangbayar, pghutangawal, pghutangbgo})
            Me.Close()
        End If
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
        bt_cl.PerformClick()
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Tutup Form?", "Pembayaran Hutang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub fr_jual_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            Else
                bt_batalperkiraan.PerformClick()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    '------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanperkiraan.PerformClick()
    End Sub

    Private Sub mn_delete_Click(sender As Object, e As EventArgs) Handles mn_delete.Click

    End Sub

    Private Sub mn_proses_Click(sender As Object, e As EventArgs) Handles mn_proses.Click

    End Sub

    '------------- numeric
    Private Sub in_debet_Enter(sender As Object, e As EventArgs) Handles in_kredit.Enter, in_potongan.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_debet_Leave(sender As Object, e As EventArgs) Handles in_kredit.Leave, in_potongan.Leave
        numericLostFocus(sender)
    End Sub

    '------------- cb prevent input
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_bayar.KeyPress, cb_akun.KeyPress
        e.Handled = True
    End Sub

    '---------- PopUp Search
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_supplier_n.Focused = True Or in_faktur.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub dgv_listbarang_Cellenter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellEnter
        If e.RowIndex >= 0 Then
            indexrowlist = e.RowIndex
        End If
    End Sub

    Private Sub dgv_listbarang_CellContentDBLClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellDoubleClick
        If e.RowIndex >= 0 Then
            indexrowlist = e.RowIndex
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            Dim x As TextBox
            Select Case popupstate
                Case "supplier"
                    x = in_supplier
                Case "faktur"
                    x = in_faktur
                Case Else
                    x = Nothing
                    x.Dispose()
                    Exit Sub
            End Select
            x.Text += e.KeyChar
            e.Handled = True
            x.Focus()
            x.Select(x.TextLength, x.TextLength)
        End If
    End Sub

    Private Sub linkLbl_searchbarang_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLbl_searchbarang.LinkClicked
        'search(popupstate)
    End Sub

    '------------- load
    Private Sub fr_hutang_bayar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Size = New Size(300, 300)
    End Sub

    Public Sub do_load()
        Me.Cursor = Cursors.WaitCursor

        With cb_bayar
            .DataSource = jenisBayar("hutang")
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With
        loadCBAkun(cb_bayar.SelectedValue)

        With date_tgl_trans
            .Value = IIf(selectperiode.tglakhir >= Today, Today, selectperiode.tglakhir)
            .MaxDate = selectperiode.tglakhir
            '.MinDate = selectperiode.tglawal
        End With

        For Each x As DataGridViewColumn In {bayar_kredit, bayar_sisahutang, bayar_saldoawal}
            x.DefaultCellStyle = dgvstyle_commathousand
        Next

        If in_no_bukti.Text <> Nothing Then
            loadData(in_no_bukti.Text)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    '------------ save
    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click
        If in_supplier.Text = Nothing Then
            MessageBox.Show("Supplier belum di input")
            in_supplier.Focus()
            Exit Sub
        End If
        If dgv_bayar.Rows.Count = 0 Then
            MessageBox.Show("Pembayaran belum di input")
            in_faktur.Focus()
            Exit Sub
        End If
        If cb_bayar.SelectedValue = "BG" And Trim(in_no_bg.Text) = Nothing Then
            MessageBox.Show("Nomor Giro belum di input")
            in_no_bg.Focus()
            Exit Sub
        End If
        If date_tgl_trans.Value < selectperiode.tglawal Then
            MessageBox.Show("Tanggal transaksi lebih kecil daripada Jangka waktu periode terpilih")
            date_tgl_trans.Focus()
            Exit Sub
        End If
        If date_bg_tgl.Value < date_tgl_trans.Value Then
            MessageBox.Show("Tanggal jatuhtempo/efektif BG lebih kecil daripada tanggal transaksi")
            date_bg_tgl.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan data transaksi pembayaran hutang?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            saveBayar()
        End If
    End Sub

    '----------- Input Supplier
    '---------------pop up list Supplier
    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_supplier_n.Enter
        If in_supplier_n.ReadOnly = False And in_supplier_n.Enabled = True Then
            popPnl_barang.Location = New Point(in_supplier_n.Left, in_supplier_n.Top + in_supplier_n.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            popupstate = "supplier"
            loadDataBRGPopup("supplier", in_supplier_n.Text)
        End If
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_supplier_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_TextChanged(sender As Object, e As EventArgs) Handles in_supplier_n.TextChanged
        If in_supplier_n.Text = "" Then
            in_supplier.Clear()
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyDown
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(cb_bayar, e)
        Else
            If e.KeyCode <> Keys.Escape Then
                If popPnl_barang.Visible = False And sender.ReadOnly = True Then
                    popPnl_barang.Visible = True
                End If
                loadDataBRGPopup("supplier", in_supplier_n.Text)
            End If
        End If
    End Sub

    Private Sub in_sales_n_MouseClick(sender As Object, e As MouseEventArgs) Handles in_supplier_n.MouseClick, in_faktur.MouseClick
        If popPnl_barang.Visible = False And sender.ReadOnly = False Then
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub cb_bayar_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_bayar.KeyDown
        keyshortenter(cb_akun, e)
    End Sub

    Private Sub cb_bayar_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_bayar.SelectionChangeCommitted
        If cb_bayar.SelectedValue = "BG" Then
            in_no_bg.Enabled = True
        Else
            in_no_bg.Enabled = False
        End If
        loadCBAkun(cb_bayar.SelectedValue)
    End Sub

    Private Sub cb_akun_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_akun.KeyDown
        keyshortenter(date_tgl_trans, e)
    End Sub

    Private Sub date_tgl_trans_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_trans.KeyDown
        keyshortenter(date_bg_tgl, e)
    End Sub

    Private Sub date_bg_tgl_KeyDown(sender As Object, e As KeyEventArgs) Handles date_bg_tgl.KeyDown
        keyshortenter(in_faktur, e)
    End Sub

    '----------- Input Faktur
    '---------------pop up list faktur
    Private Sub in_faktur_Enter(sender As Object, e As EventArgs) Handles in_faktur.Enter
        If sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(in_faktur.Left, in_faktur.Top + in_faktur.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            popupstate = "faktur"
            loadDataBRGPopup("faktur", in_faktur.Text)
        End If
    End Sub

    Private Sub in_faktur_Leave(sender As Object, e As EventArgs) Handles in_faktur.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_faktur_TextChanged(sender As Object, e As EventArgs) Handles in_faktur.TextChanged
        If in_faktur.Text = "" Then
            in_tgl_jtfaktur.Clear()
            in_sisafaktur.Clear()
            _totalhutang = 0
        End If
    End Sub

    Private Sub in_faktur_KeyUp(sender As Object, e As KeyEventArgs) Handles in_faktur.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(in_kredit, e)
        Else
            If e.KeyCode <> Keys.Escape Then
                If popPnl_barang.Visible = False And sender.ReadOnly = False Then
                    popPnl_barang.Visible = True
                End If
                loadDataBRGPopup("faktur", in_faktur.Text)
            End If
        End If
    End Sub

    '----------- Input Bayar
    Private Sub in_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kredit.KeyDown
        keyshortenter(bt_tbbayar, e)
    End Sub

    Private Sub bt_tbbayar_Click(sender As Object, e As EventArgs) Handles bt_tbbayar.Click
        textToDGV()
    End Sub

    '---------------------- DGV Bayar
    Private Sub dgv_bayar_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_bayar.CellEnter
        If e.RowIndex > -1 Then
            indexrowbayar = e.RowIndex
        End If
    End Sub

    Private Sub dgv_bayar_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_bayar.CellDoubleClick
        If loggeduser.allowedit_transact = True And selectperiode.closed = False Then
            If e.RowIndex > -1 Then
                indexrowbayar = e.RowIndex
                dgvToText("bayar")
            End If
        End If
    End Sub

    Private Sub fr_hutang_bayar_Click(sender As Object, e As EventArgs) Handles MyBase.Click, Panel1.Click, Panel2.Click, pnl_content.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub

    'FOOTER
    Private Sub in_no_bg_KeyDown(sender As Object, e As KeyEventArgs) Handles in_no_bg.KeyDown
        keyshortenter(in_ket, e)
    End Sub

    Private Sub in_potongan_KeyDown(sender As Object, e As KeyEventArgs) Handles in_potongan.KeyDown
        keyshortenter(bt_simpanperkiraan, e)
    End Sub

    Private Sub in_potongan_ValueChanged(sender As Object, e As EventArgs) Handles in_potongan.ValueChanged
        in_total.Text = commaThousand(countTotal())
    End Sub

End Class