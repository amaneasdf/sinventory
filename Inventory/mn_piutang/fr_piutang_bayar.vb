Public Class fr_piutang_bayar
    Private _popUpPos As String = ""

    Private selectedcusto As String = ""
    Private selectedsales As String = ""
    Private _totaltitipan As Double = 0
    Private _statusgiro As String = "1"

    Private _sisaHutang As Double = 0
    Public _totalhutang As Double = 0


    Private Sub loadData(kode As String)
        Dim nobg As String = ""
        Dim tglbgcair As String = ""
        Dim akun As String = ""
        Dim q As String = "SELECT p_bayar_sales, salesman_nama, p_bayar_custo, customer_nama, p_bayar_jenisbayar, p_bayar_akun, p_bayar_tanggal_bayar, " _
                          & "p_bayar_tanggal_jt, IFNULL(giro_no,'') as giro_no, IFNULL(giro_bank,'') as giro_bank, IFNULL(g_cair_tglcair,'') as g_cair_tglcair, " _
                          & "IFNULL(giro_status,'') as giro_status, p_bayar_ket, p_bayar_potongan_nilai, p_bayar_reg_date,p_bayar_reg_alias,p_bayar_upd_date, " _
                          & "p_bayar_upd_alias, getSisaTitipan('piutang','" & selectperiode.id & "',p_bayar_custo) as titipan " _
                          & "FROM data_piutang_bayar LEFT JOIN data_salesman_master ON p_bayar_sales=salesman_kode " _
                          & "LEFT JOIN data_customer_master ON customer_kode=p_bayar_custo " _
                          & "LEFT JOIN data_giro ON giro_ref=p_bayar_bukti AND giro_status<>9 AND giro_type='IN'" _
                          & "LEFT JOIN data_giro_cair ON giro_no=g_cair_nobg and g_cair_status=1 " _
                          & "WHERE p_bayar_bukti='{0}'"

        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            in_no_bukti.Text = kode
            in_sales.Text = rd.Item("p_bayar_sales")
            in_sales_n.Text = rd.Item("salesman_nama")
            in_custo.Text = rd.Item("p_bayar_custo")
            in_custo_n.Text = rd.Item("customer_nama")
            in_saldotitipan.Text = commaThousand(rd.Item("titipan"))
            cb_bayar.SelectedValue = rd.Item("p_bayar_jenisbayar")
            akun = rd.Item("p_bayar_akun")
            '-------akun
            date_tgl_trans.Value = rd.Item("p_bayar_tanggal_bayar")
            date_bg_tgl.Value = rd.Item("p_bayar_tanggal_jt")
            nobg = rd.Item("giro_no")
            in_bank.Text = rd.Item("giro_bank")
            tglbgcair = rd.Item("g_cair_tglcair")
            '_statusgiro = rd.Item("giro_status")
            in_potongan.Value = rd.Item("p_bayar_potongan_nilai")
            txtRegAlias.Text = rd.Item("p_bayar_reg_alias")
            txtRegdate.Text = rd.Item("p_bayar_reg_date")
            txtUpdAlias.Text = rd.Item("p_bayar_upd_alias")
            Try
                txtUpdDate.Text = rd.Item("p_bayar_upd_date")
            Catch ex As Exception
                txtUpdDate.Text = "0000/00/00 00:00:00"
            End Try
        End If
        rd.Close()

        loadCBAkun(cb_bayar.SelectedValue)
        cb_akun.SelectedValue = akun

        selectedcusto = in_custo.Text
        in_custo.ReadOnly = True
        selectedsales = in_sales.Text
        in_sales_n.ReadOnly = True

        If nobg <> Nothing And cb_bayar.SelectedValue = "BG" Then
            in_bg_no.Enabled = True
            in_bank.Enabled = True
        End If
        in_bg_no.Text = nobg
        in_tglpencairan.Text = tglbgcair

        If Trim(in_tglpencairan.Text) <> Nothing And cb_bayar.SelectedValue = "BG" Then
            'IF jenisbayar->BG AND sudahdicairkan SET readonly ALL
            in_bg_no.ReadOnly = True
            in_bank.ReadOnly = True
            bt_simpanperkiraan.Visible = False
            bt_batalperkiraan.Text = "OK"
        End If

        loadListedBayar(kode)
        in_sales.Focus()
    End Sub

    Private Sub loadListedBayar(kode As String)
        Dim dt As New DataTable
        Dim q As String = "SELECT p_trans_kode_piutang, DATE_FORMAT(ADDDATE(faktur_tanggal_trans,faktur_term),'%d/%m/%Y'), faktur_netto-faktur_bayar as faktur_sisa, " _
                          & "p_trans_sisa, p_trans_nilaibayar " _
                          & "FROM data_piutang_bayar_trans LEFT JOIN data_penjualan_faktur ON faktur_kode=p_trans_kode_piutang AND faktur_status=1 " _
                          & "WHERE p_trans_status=1 AND p_trans_bukti='{0}'"
        dt = getDataTablefromDB(String.Format(q, kode))

        With dgv_bayar.Rows
            For Each rows As DataRow In dt.Rows
                Dim x As Integer = .Add
                With .Item(x)
                    .Cells("bayar_faktur").Value = rows.ItemArray(0)
                    .Cells("bayar_tgljt").Value = rows.ItemArray(1)
                    .Cells("bayar_totalpiutang").Value = rows.ItemArray(2)
                    .Cells("bayar_sisapiutang").Value = rows.ItemArray(3)
                    .Cells("bayar_kredit").Value = rows.ItemArray(4)
                End With
            Next
        End With
        dt.Dispose()

        in_total.Text = commaThousand(countTotal)
    End Sub

    Private Sub setSales(kode As String)

    End Sub

    Private Sub setFaktur(kode As String)

    End Sub

    'ADD INPUT FROM TEXTBOX TO DGV
    Private Sub textToDGV()
        If in_faktur.Text = "" Then
            in_faktur.Focus()
            Exit Sub
        End If
        If in_kredit.Value = 0 Then
            in_kredit.Focus()
            Exit Sub
        End If
        If in_faktur.Text <> "" And in_sisafaktur.Text = Nothing Then
            MessageBox.Show("Faktur tidak sesuai")
            in_faktur.Focus()
            Exit Sub
        End If
        If in_kredit.Value > removeCommaThousand(in_sisafaktur.Text) Then
            MessageBox.Show("Saldo Pembayaran lebih besar dari sisa")
            in_kredit.Focus()
            Exit Sub
        End If
        If cb_bayar.SelectedValue = "PIUTSUPL" And removeCommaThousand(in_saldotitipan.Text) < in_kredit.Value + removeCommaThousand(in_total.Text) Then
            MessageBox.Show("Saldo Titipan tidak Mencukupi")
            in_kredit.Focus()
            Exit Sub
        End If

        dgv_bayar.Rows.Add(in_faktur.Text, in_tgl_jtfaktur.Text, _totalhutang, removeCommaThousand(in_sisafaktur.Text), in_kredit.Value)
        clearInput()
        in_total.Text = commaThousand(countTotal)
    End Sub

    'LOAD SELECTED DGV ROW TO TEXTBOX INPUT
    Private Sub dgvToText()
        Dim idx As Integer = 0
        With dgv_bayar.SelectedRows.Item(0)
            in_faktur.Text = .Cells("bayar_faktur").Value
            in_kredit.Value = .Cells("bayar_kredit").Value
            in_tgl_jtfaktur.Text = .Cells("bayar_tgljt").Value
            _totalhutang = .Cells("bayar_totalpiutang").Value
            in_sisafaktur.Text = commaThousand(.Cells("bayar_sisapiutang").Value)
            idx = .Index
        End With
        dgv_bayar.Rows.RemoveAt(idx)
        in_total.Text = commaThousand(countTotal)

        If dgv_bayar.RowCount <= 0 Then
            in_sales_n.ReadOnly = True
            in_custo_n.ReadOnly = True
        Else
            in_sales_n.ReadOnly = False
            in_custo_n.ReadOnly = False
        End If
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
                Case Else
                    Exit Sub
            End Select
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With
    End Sub

    'SAVE THE DATA
    Private Sub saveData()
        Dim querycheck As Boolean = False
        Dim dataHead, data1, data2 As String()
        Dim queryArr As New List(Of String)
        Dim q As String = ""

        op_con()
        '==========================================================================================================================
        'INPUT HEADER
        dataHead = {
            "p_bayar_tanggal_bayar='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
            "p_bayar_tanggal_jt='" & date_bg_tgl.Value.ToString("yyyy-MM-dd") & "'",
            "p_bayar_custo='" & in_custo.Text & "'",
            "p_bayar_sales='" & in_sales.Text & "'",
            "p_bayar_jenisbayar='" & cb_bayar.SelectedValue & "'",
            "p_bayar_akun='" & cb_akun.SelectedValue & "'",
            "p_bayar_potongan_nilai=" & in_potongan.Value.ToString.Replace(",", "."),
            "p_bayar_ket='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
            "p_bayar_status='" & IIf(cb_bayar.SelectedValue = "BG" And in_tglpencairan.Text = "", 0, 1) & "'"
            }

        'GENERATE KODE
        If bt_simpanperkiraan.Text = "Simpan Pembayaran" Then
            If in_no_bukti.Text = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT COUNT(p_bayar_bukti) FROM data_piutang_bayar WHERE SUBSTRING(p_bayar_bukti,3,8)='" & date_tgl_trans.Value.ToString("yyyyMMdd") & "' AND p_bayar_bukti LIKE 'PP%'")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()
                in_no_bukti.Text = "PP" & date_tgl_trans.Value.ToString("yyyyMMdd") & no.ToString("D3")
            ElseIf in_no_bukti.Text <> Nothing And LCase(bt_simpanperkiraan.Text) = "simpan pembayaran" Then
                If checkdata("data_piutang_bayar", "'" & in_no_bukti.Text & "'", "p_bayar_bukti") = True Then
                    MessageBox.Show("Nomor faktur " & in_no_bukti.Text & " sudah pernah diinputkan", "Pembayaran Piutang", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    in_no_bukti.Focus()
                    Exit Sub
                End If
            End If
            q = "INSERT INTO data_piutang_bayar SET p_bayar_bukti='{0}',{1},p_bayar_reg_date=NOW(),p_bayar_reg_alias='{2}'"
        ElseIf bt_simpanperkiraan.Text = "Update" Then
            q = "UPDATE data_piutang_bayar SET {1},p_bayar_upd_date=NOW(),p_bayar_upd_alias='{2}' WHERE p_bayar_bukti='{0}'"
        End If
        queryArr.Add(String.Format(q, in_no_bukti.Text, String.Join(",", dataHead), loggeduser.user_id))
        '==========================================================================================================================

        '==========================================================================================================================
        'GIRO BLYAT/TITIPAN
        q = "UPDATE data_giro SET giro_status=9,giro_upd_date=NOW(),giro_upd_alias='system' WHERE giro_ref='{0}' AND giro_type='IN'"
        queryArr.Add(String.Format(q, in_no_bukti.Text))
        q = "UPDATE data_piutang_titip SET p_titip_status=9 WHERE p_titip_faktur='{0}' AND p_titip_idperiode='{1}' AND p_titip_tipe='bayar'"
        queryArr.Add(String.Format(q, in_no_bukti.Text, selectperiode.id))


        If cb_bayar.SelectedValue = "BG" Then
            q = "INSERT INTO data_giro SET giro_no='{0}',giro_ref='{1}',{2},giro_reg_date=NOW(),giro_reg_alias='{3}' ON DUPLICATE KEY UPDATE {2}," _
                & "giro_upd_date=NOW(),giro_upd_alias='{3}'"
            data2 = {
                "giro_tglbg='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                "giro_tglcair='" & date_bg_tgl.Value.ToString("yyyy-MM-dd") & "'",
                "giro_bank='" & in_bank.Text & "'",
                "giro_nilai=" & removeCommaThousand(in_total.Text).ToString.Replace(",", "."),
                "giro_type='IN'",
                "giro_status=1"
                }
            queryArr.Add(String.Format(q, in_bg_no.Text, in_no_bukti.Text, String.Join(",", data2), loggeduser.user_id))
        ElseIf cb_bayar.SelectedValue = "PIUTSUPL" Then
            q = "INSERT INTO data_piutang_titip SET p_titip_faktur='{0}',p_titip_idperiode='{1}',{2} ON DUPLICATE KEY UPDATE {2}"
            data2 = {
                "p_titip_tipe='bayar'",
                "p_titip_ref='" & in_custo.Text & "'",
                "p_titip_nilai=" & removeCommaThousand(in_total.Text).ToString.Replace(",", ".") * -1,
                "p_titip_status=1"
                }
            queryArr.Add(String.Format(q, in_no_bukti.Text, selectperiode.id, String.Join(",", data2)))

        End If
        '==========================================================================================================================

        Dim q2 As String = "INSERT INTO data_piutang_bayar_trans SET p_trans_bukti='{0}',{1},{2} ON DUPLICATE KEY UPDATE {1}"
        Dim q3 As String = "INSERT INTO data_jurnal_line SET {0},{1} ON DUPLICATE KEY UPDATE {0},{2}"

        '==========================================================================================================================
        'INPUT BAYAR
        q = "UPDATE data_piutang_bayar_trans SET p_trans_status=9 WHERE p_trans_bukti='{0}'"
        queryArr.Add(String.Format(q, in_no_bukti.Text))

        For Each rows As DataGridViewRow In dgv_bayar.Rows
            q = "INSERT INTO data_piutang_bayar_trans SET p_trans_bukti='{0}', p_trans_kode_piutang='{1}',{2} ON DUPLICATE KEY UPDATE {2}"
            data1 = {
                "p_trans_sisa=" & rows.Cells("bayar_sisapiutang").Value.ToString.Replace(",", "."),
                "p_trans_nilaibayar=" & rows.Cells("bayar_kredit").Value.ToString.Replace(",", "."),
                "p_trans_reg_date=NOW()",
                "p_trans_reg_alias='" & loggeduser.user_id & "'",
                "p_trans_status='1'"
                }
            queryArr.Add(String.Format(q, in_no_bukti.Text, rows.Cells(0).Value, String.Join(",", data1)))
        Next
        '==========================================================================================================================


        '==========================================================================================================================
        'INPUT JURNAL
        '----------HEAD
        q = "INSERT INTO data_jurnal_line SET line_kode='{0}', line_type='PBAYAR',{1},line_reg_date=NOW(),line_reg_alias='{2}' " _
            & "ON DUPLICATE KEY UPDATE {1},line_upd_date=NOW(),line_upd_alias='{2}'"
        data1 = {
            "line_ref='" & in_custo.Text & "'",
            "line_ref_type='CUSTO'",
            "line_tanggal='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
            "line_status='1'"
            }
        queryArr.Add(String.Format(q, in_no_bukti.Text, String.Join(",", data1), loggeduser.user_id))
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
            doRefreshTab({pgpiutangbayar, pgpiutangawal})
            'frmhutangbayar.in_cari.Clear()
            'populateDGVUserCon("piutangbayar", "", frmpiutangbayar.dgv_list)
            Me.Close()
        End If
    End Sub

    'OPEN FULL WINDOWS SEARCH
    Private Sub searchData(tipe As String)
        Dim q As String = ""
        Using search As New fr_search_dialog

        End Using
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing, Optional param2 As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Dim autoco As New AutoCompleteStringCollection
        Select Case tipe
            Case "sales"
                q = "SELECT salesman_kode as 'Kode', salesman_nama as 'Salesman' FROM data_salesman_master " _
                    & "WHERE salesman_status<>9 AND salesman_nama LIKE '{0}%'"
                dt = getDataTablefromDB(String.Format(q, param))
            Case "custo"
                q = "SELECT customer_kode as 'Kode', customer_nama as 'Customer', getSisaTitipan('piutang','{0}',customer_kode) as PiutangSupl FROM data_customer_master " _
                    & "WHERE customer_status<>9 AND customer_nama LIKE '{1}%'"
                q = String.Format(q, selectperiode.id, "{0}")
                dt = getDataTablefromDB(String.Format(q, param))
            Case "faktur"
                q = "SELECT piutang_faktur as 'Kode Faktur', getSisaPiutang(piutang_faktur,'" & selectperiode.id & "') as 'Sisa Piutang', " _
                    & "ADDDATE(faktur_tanggal_trans, faktur_term) as 'Jatuh Tempo' " _
                    & "FROM data_piutang_awal LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode AND faktur_status=1 " _
                    & "WHERE getSisaPiutang(piutang_faktur,'" & selectperiode.id & "') <> 0 AND faktur_customer='{1}' " _
                    & "AND faktur_sales='" & in_sales.Text & "' AND piutang_faktur LIKE '{0}%'"
                consoleWriteLine(String.Format(q, param, param2))
                dt = getDataTablefromDB(String.Format(q, param, param2))
            Case Else
                Exit Sub
        End Select

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 135
            .Columns(1).Width = 200
            If tipe = "faktur" Then
                .Columns(2).Width = 175
                .Columns(1).DefaultCellStyle = dgvstyle_currency
            ElseIf tipe = "custo" Then
                .Columns(2).Visible = False
            End If
        End With
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case _popUpPos
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    in_sales_n.Focus()
                Case "custo"
                    in_custo.Text = .Cells(0).Value
                    in_custo_n.Text = .Cells(1).Value
                    in_saldotitipan.Text = commaThousand(.Cells(2).Value)
                    in_custo_n.Focus()
                Case "faktur"
                    in_faktur.Text = .Cells(0).Value
                    in_kredit.Value = .Cells(1).Value
                    'AND OTHER STUFF
                    cb_bayar.Focus()
                Case Else
                    Exit Sub
            End Select

        End With
        popPnl_barang.Visible = False
    End Sub

    Private Sub clearInput()
        Dim txt As TextBox() = {in_tgl_jtfaktur, in_faktur, in_sisafaktur}
        For Each x As TextBox In txt
            x.Clear()
        Next
        _totalhutang = 0
        in_kredit.Value = 0
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

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Tutup Form?", "Pembayaran Piutang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
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

    '------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanperkiraan.PerformClick()
    End Sub

    Private Sub mn_delete_Click(sender As Object, e As EventArgs) Handles mn_delete.Click

    End Sub

    Private Sub mn_proses_Click(sender As Object, e As EventArgs) Handles mn_proses.Click

    End Sub

    '------------- load
    Private Sub fr_hutang_bayar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_bayar
            .DataSource = jenisBayar("piutang")
            .ValueMember = "Value"
            .DisplayMember = "Text"
        End With
        loadCBAkun(cb_bayar.SelectedValue)

        With date_tgl_trans
            .Value = IIf(selectperiode.tglakhir >= Today, Today, selectperiode.tglakhir)
            .MaxDate = selectperiode.tglakhir
            '.MinDate = selectperiode.tglawal
        End With

        For Each x As DataGridViewColumn In {bayar_kredit, bayar_sisapiutang, bayar_totalpiutang}
            x.DefaultCellStyle = dgvstyle_commathousand
        Next

        If in_no_bukti.Text <> Nothing Then
            loadData(in_no_bukti.Text)
        End If
    End Sub

    '------------ save
    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click
        If in_sales.Text = "" Then
            MessageBox.Show("Sales belum di input")
            in_sales_n.Focus()
            Exit Sub
        End If
        If in_custo_n.Text = "" Then
            MessageBox.Show("Customer belum di input")
            in_sales_n.Focus()
            Exit Sub
        End If
        If dgv_bayar.RowCount = 0 Then
            MessageBox.Show("Pembayaran belum di input")
            in_custo_n.Focus()
            Exit Sub
        End If
        If cb_bayar.SelectedValue = "BG" And Trim(in_bg_no.Text) = Nothing Then
            MessageBox.Show("Nomor Giro belum di input")
            in_bg_no.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan data transaksi pembayaran piutang?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            saveData()
        End If
    End Sub

    'UI
    Private Sub in_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales.KeyDown
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_sales_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter
        popPnl_barang.Location = New Point(in_sales_n.Left, in_sales_n.Top + in_sales_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        _popUpPos = "sales"
        loadDataBRGPopup("sales", in_sales_n.Text)
    End Sub

    Private Sub in_sales_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave, in_faktur.Leave, in_custo_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_sales_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(in_custo_n, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("sales", in_sales_n.Text)
        End If
    End Sub

    Private Sub in_sales_n_TextChanged(sender As Object, e As EventArgs) Handles in_sales_n.TextChanged
        If in_sales_n.Text = "" Then
            'DO THING
            in_sales.Clear()
        End If
    End Sub

    Private Sub in_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles in_custo.KeyDown
        keyshortenter(in_custo_n, e)
    End Sub

    Private Sub in_custo_n_Enter(sender As Object, e As EventArgs) Handles in_custo_n.Enter
        popPnl_barang.Location = New Point(in_custo_n.Left, in_custo_n.Top + in_custo_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        _popUpPos = "custo"
        loadDataBRGPopup("custo", in_custo_n.Text)
    End Sub

    Private Sub in_custo_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_custo_n.KeyUp
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
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("custo", in_custo_n.Text)
        End If
    End Sub

    Private Sub in_custo_n_TextChanged(sender As Object, e As EventArgs) Handles in_custo_n.TextChanged
        If in_custo_n.Text = "" Then
            in_custo.Clear()
            in_faktur.Clear()
            'AND OTHER THINGS
        End If
    End Sub

    Private Sub in_faktur_Enter(sender As Object, e As EventArgs) Handles in_faktur.Enter
        popPnl_barang.Location = New Point(in_faktur.Left, in_faktur.Top + in_faktur.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        _popUpPos = "faktur"
        loadDataBRGPopup("faktur", in_faktur.Text, in_custo.Text)
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
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("faktur", in_faktur.Text, in_custo.Text)
        End If
    End Sub

    Private Sub in_faktur_TextChanged(sender As Object, e As EventArgs) Handles in_faktur.TextChanged
        If in_faktur.Text = "" Then
            in_sisafaktur.Text = ""
            in_tgl_jtfaktur.Text = ""

        End If
    End Sub

    '----------------POPUP PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_sales_n.Focused Or in_custo_n.Focused Or in_faktur.Focused Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub dgv_listbarang_CellContentDBLClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellDoubleClick
        If e.RowIndex >= 0 Then
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
            Select Case _popUpPos
                Case "sales"
                    x = in_sales_n
                Case "custo"
                    x = in_custo_n
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

    '------------- cb prevent input
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_bayar.KeyPress
        e.Handled = True
    End Sub

    '------------- numeric
    Private Sub in_debet_Enter(sender As Object, e As EventArgs) Handles in_kredit.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_debet_Leave(sender As Object, e As EventArgs) Handles in_kredit.Leave
        numericLostFocus(sender)
    End Sub

    '-------------- OTHER
    Private Sub cb_bayar_KeyUp(sender As Object, e As KeyEventArgs) Handles cb_bayar.KeyUp
        keyshortenter(date_tgl_trans, e)
    End Sub

    Private Sub cb_bayar_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_bayar.SelectionChangeCommitted
        If cb_bayar.SelectedValue = "BG" Then
            in_bg_no.Enabled = True
            in_bank.Enabled = True
        Else
            in_bank.Enabled = False
            in_bg_no.Enabled = False
        End If

        loadCBAkun(cb_bayar.SelectedValue)
    End Sub

    Private Sub date_tgl_trans_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_trans.KeyDown
        keyshortenter(date_bg_tgl, e)
    End Sub

    Private Sub date_bg_tgl_KeyUp(sender As Object, e As KeyEventArgs) Handles date_bg_tgl.KeyUp
        keyshortenter(in_faktur, e)
    End Sub

    Private Sub in_kredit_KeyUp(sender As Object, e As KeyEventArgs) Handles in_kredit.KeyUp
        keyshortenter(bt_tbbayar, e)
    End Sub

    Private Sub in_bg_no_KeyUp(sender As Object, e As KeyEventArgs) Handles in_bg_no.KeyUp
        keyshortenter(in_bank, e)
    End Sub

    Private Sub in_bank_KeyUp(sender As Object, e As KeyEventArgs) Handles in_bank.KeyUp
        keyshortenter(in_ket, e)
    End Sub

    'DGV
    Private Sub bt_tbbayar_Click(sender As Object, e As EventArgs) Handles bt_tbbayar.Click
        textToDGV()
    End Sub

    Private Sub dgv_bayar_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_bayar.CellDoubleClick
        If e.RowIndex > -1 Then
            dgvToText()
        End If
    End Sub
End Class