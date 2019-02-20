Public Class fr_tutup_buku
    Public tabpagename As TabPage
    Private neracabalance As Boolean
    Private Enum ckdatres
        Valid
        Invalid
        Undefined
    End Enum

    Public Sub setpage(page As TabPage)
        tabpagename = page
        Console.WriteLine("pg" & page.Name.ToString)
        Console.WriteLine("pgset" & tabpagename.Name.ToString)
    End Sub

    Public Sub performRefresh()
        Console.WriteLine(tabpagename.Name.ToString)
        Me.Cursor = Cursors.AppStarting
        date_tgl_awal.MinDate = DateSerial(1990, 1, 1)
        date_tgl_awal.MaxDate = DateSerial(2100, 12, 31)
        date_tgl_akhir.MinDate = date_tgl_awal.MinDate
        date_tgl_akhir.MaxDate = date_tgl_awal.MaxDate
        doLoad()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub setStatus()
        in_kode.Text = selectperiode.id
        in_status.Text = IIf(selectperiode.closed = True, "Closed", "Open")

        If selectperiode.id <> currentperiode.id Or selectperiode.closed = True Then
            Dim q As String = "SELECT tutupbk_user, tutupbk_closedate,tutupbk_ket FROM data_tutup_buku WHERE tutupbk_id='{0}'"
            readcommd(String.Format(q, selectperiode.id))
            If rd.HasRows Then
                in_dateclose.Text = IIf(IsDBNull(rd.Item("tutupbk_closedate")) = True, "00/00/0000 00:00:00", rd.Item("tutupbk_closedate"))
                in_userclose.Text = rd.Item("tutupbk_user")
                in_ket.Text = IIf(IsDBNull(rd.Item("tutupbk_ket")) = True, "", rd.Item("tutupbk_ket"))
            End If
            If rd.IsClosed = False Then
                rd.Close()
            End If
            date_tgl_akhir.Enabled = False
            'show
            inputSW(False)
        Else
            inputSW(True)
        End If
    End Sub

    Private Sub inputSW(sw As Boolean)
        ck_proses.Enabled = sw
        If sw = False Then

        Else

        End If
    End Sub

    'Private Sub loadStock()
    '    Dim q As String = "CALL createDataStockTableTemp('" & selectperiode.id & "','" & date_tgl_akhir.Value.ToString("yyyy-MM-dd") & "'); " _
    '                      & "SELECT {0} FROM stock_temp LEFT JOIN data_barang_master brg ON barang_kode=stock_barang {1}; " _
    '                      & "DROP TEMPORARY TABLE IF EXISTS stock_temp;"
    '    Dim data As String()
    '    Dim qwh As String = ""
    '    Dim whr As New List(Of String)
    '    Dim _dt As New DataTable

    '    data = {
    '        "1 as stock_ck",
    '        "stock_tanggal",
    '        "stock_barang",
    '        "brg.barang_nama",
    '        "stock_gudang",
    '        "gudang_nama",
    '        "stock_status",
    '        "stock_sisa",
    '        "stock_stockop",
    '        "stock_sisastockop",
    '        "(CASE WHEN brg.barang_jenis=1 THEN 'STOK' WHEN brg.barang_jenis=2 THEN 'BONUS' ELSE 'ERROR' END) AS barang_jenis",
    '        "CONCAT('B:',stock_beli,',J:',stock_jual,',RB:',stock_rbeli,',RJ:',stock_rjual,',IN:',stock_min,',OUT:',stock_mout) as stock_det"
    '        }

    '    dgv_stock.Rows.Clear()

    '    If ck_stok.CheckState = CheckState.Checked Or ck_stok_bonus.CheckState = CheckState.Checked Then
    '        qwh = "WHERE barang_status IN ({0})"
    '        If ck_stok.Checked = True Then
    '            whr.Add("1")
    '        End If
    '        If ck_stok_bonus.Checked = True Then
    '            whr.Add("2")
    '        End If
    '        qwh = String.Format(qwh, String.Join(",", whr))

    '        q = String.Format(q, String.Join(",", data), qwh)
    '        consoleWriteLine(q)
    '        _dt = getDataTablefromDB(q)

    '        For Each x As DataRow In _dt.Rows
    '            With dgv_stock.Rows
    '                Dim ridx As Integer = .Add
    '                With .Item(ridx)
    '                    .Cells("brg_ck").Value = x.ItemArray(0)
    '                    .Cells("brg_tgl").Value = x.ItemArray(1)
    '                    .Cells("brg_brg").Value = x.ItemArray(2)
    '                    .Cells("brg_brg").ToolTipText = x.ItemArray(3)
    '                    .Cells("brg_gudang").Value = x.ItemArray(4)
    '                    .Cells("brg_gudang").ToolTipText = x.ItemArray(5)
    '                    .Cells("brg_status").Value = x.ItemArray(6)
    '                    .Cells("brg_sisa").Value = x.ItemArray(7)
    '                    .Cells("brg_stockop").Value = x.ItemArray(8)
    '                    .Cells("brg_sisaop").Value = x.ItemArray(9)
    '                    .Cells("brg_jenis").Value = x.ItemArray(10)
    '                    .Cells("brg_sisa").ToolTipText = x.ItemArray(11)
    '                End With
    '            End With
    '            'dgv_stock.Rows.Add(x.ItemArray(0), , x.ItemArray(2), x.ItemArray(3), x.ItemArray(4), x.ItemArray(5), x.ItemArray(6), x.ItemArray(7))
    '        Next
    '    ElseIf ck_stok.Checked = False And ck_stok_bonus.Checked = False Then
    '        dgv_stock.Rows.Clear()
    '    End If
    'End Sub

    Private Function ckDataValid(ByVal tipe As String) As ckdatres
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Config is empty")
        End If

        Dim _retval As ckdatres = ckdatres.Undefined
        Dim q As String = ""

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Select Case tipe
                    Case "sisahutang"
                        q = "SELECT IFNULL(COUNT(DISTINCT h_trans_kode_hutang),0) FROM data_hutang_trans  " _
                            & "WHERE h_trans_status=1 AND h_trans_tgl BETWEEN '{0}' AND '{1}' GROUP BY h_trans_kode_hutang HAVING SUM(h_trans_nilai) < 0"
                        q = String.Format(q, date_tgl_awal.Value.ToString("yyyy-MM-dd"), date_tgl_akhir.Value.ToString("yyyy-MM-dd"))
                    Case "piutangbayar"
                        q = "SELECT COUNT(IF(p_bayar_status=0,1,NULL)) FROM data_piutang_bayar WHERE p_bayar_tanggal_bayar BETWEEN '{0}' AND '{1}'"
                        q = String.Format(q, selectperiode.tglawal.ToString("yyyy-MM-dd"), date_tgl_akhir.Value.ToString("yyyy-MM-dd"))
                    Case "sisapiutang"
                        q = "SELECT IFNULL(COUNT(DISTINCT p_trans_kode_piutang),0) FROM data_piutang_trans " _
                            & "WHERE p_trans_status=1 AND p_trans_tgl BETWEEN '{0}' AND '{1}' GROUP BY p_trans_kode_piutang HAVING SUM(p_trans_nilai) < 0"
                        q = String.Format(q, date_tgl_awal.Value.ToString("yyyy-MM-dd"), date_tgl_akhir.Value.ToString("yyyy-MM-dd"))
                    Case "pesanan"
                        q = "SELECT COUNT(IF(j_order_status=0,1,NULL)) FROM data_penjualan_order_faktur WHERE j_order_tanggal_trans BETWEEN '{0}' AND '{1}'"
                        q = String.Format(q, selectperiode.tglawal.ToString("yyyy-MM-dd"), date_tgl_akhir.Value.ToString("yyyy-MM-dd"))
                End Select
                Using rdx = x.ReadCommand(q)
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        _retval = IIf(rdx.Item(0) > 0, ckdatres.Valid, ckdatres.Invalid)
                    Else
                        _retval = ckdatres.Undefined
                    End If
                End Using
            Else
                _retval = ckdatres.Undefined
            End If
        End Using
        Return _retval
    End Function

    Private Function checkuser() As Boolean
        Dim retrespond As Boolean = False

        Return retrespond
    End Function

    Private Sub doTutupBuku()
        Dim q As String = "CALL doTutupPeriode('{0}','{1}','{2}')"
        Dim q2 As String = "UPDATE data_tutup_buku SET tutupbk_ket='{1}' WHERE tutupbk_id='{0}'"
        Dim queryArr As New List(Of String)
        Dim queryChk As Boolean = False

        Me.Cursor = Cursors.WaitCursor

        If Trim(in_ket.Text) <> Nothing Then
            queryArr.Add(String.Format(q2, selectperiode.id, ""))
        End If
        queryArr.Add(String.Format(q, selectperiode.id, date_tgl_akhir.Value.ToString("yyyy-MM-dd"), loggeduser.user_id))

        'show dialog/window

        queryChk = startTrans(queryArr)

        Me.Cursor = Cursors.Default

        If queryChk = True Then
            setperiode(Today, False)
            currentperiode = selectperiode
            MessageBox.Show("Penutupan Berhasil")
            performRefresh()
            'Show lap.keuangan
        Else
            MessageBox.Show("Penutupan Gagal")
        End If
    End Sub

    '---------------- CLOSE
    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        main.tabcontrol.TabPages.Remove(tabpagename)
        'rowindex = 0
    End Sub

    '---------------- LOAD
    Private Sub doLoad()
        Dim endmonth As Date = DateSerial(selectperiode.tglawal.Year, selectperiode.tglawal.Month + 1, 0)
        Dim xdate As Date = IIf(Today > endmonth, endmonth, Today)

        With date_tgl_awal
            .Value = selectperiode.tglawal
            .MinDate = selectperiode.tglawal
            .MaxDate = selectperiode.tglakhir
            .Enabled = False
        End With
        With date_tgl_akhir
            .Value = IIf(selectperiode.tglakhir >= xdate, xdate, selectperiode.tglakhir)
            .MaxDate = selectperiode.tglakhir
            .MinDate = date_tgl_awal.Value
        End With

        setStatus()
    End Sub

    Private Sub fr_tutup_buku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        doLoad()
    End Sub

    '=================================================================================================================================================
    'MENU
    Private Sub mn_refresh_Click(sender As Object, e As EventArgs) Handles mn_refresh.Click
        performRefresh()
    End Sub

    '=================================================================================================================================================
    'PROCESS BUTTON
    Private Sub ck_proses_CheckedChanged(sender As Object, e As EventArgs) Handles ck_proses.CheckedChanged
        If ck_proses.CheckState = CheckState.Checked Then
            Dim ckstate As Boolean = checkuser()
            Using ckfrm As New fr_tutupconfirm_dialog
                With ckfrm
                    .in_user.Text = loggeduser.user_id
                    .in_user.ReadOnly = True
                    .in_pass.Focus()
                    .do_loaddialog()
                    ckstate = .returnval
                End With
            End Using
            ck_proses.Checked = ckstate
            bt_simpanperkiraan.Enabled = ckstate
        Else
            bt_simpanperkiraan.Enabled = False
        End If
    End Sub

    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click
        Dim ck As ckdatres = ckDataValid("piutangbayar")
        If ck = ckdatres.Invalid Then
            MessageBox.Show("Ada transaksi pembayaran piutang yang belum tervalidasi. Silahkan cek kembali.", "Tutup Periode", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        ElseIf ck = ckdatres.Undefined Then
            MessageBox.Show("Terjadi Kesalahan. Sistem tidak dapat melakukan pengecekan data", "Tutup Periode", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ck = ckDataValid("pesanan")
        If ck = ckdatres.Invalid Then
            Dim msgres As DialogResult = MessageBox.Show("Ada transaksi order penjualan yang belum divalidasi. Lanjutkan proses tutup buku?",
                                                         "Tutup Periode", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If msgres = DialogResult.No Then
                Exit Sub
            End If
        ElseIf ck = ckdatres.Undefined Then
            MessageBox.Show("Terjadi Kesalahan. Sistem tidak dapat melakukan pengecekan data", "Tutup Periode", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        If MessageBox.Show("Lakukan proses tutup buku?" & Environment.NewLine & "Pastikan semua transaksi pada periode yang akan di tutup telah selesai",
                           "Tutup Buku", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            doTutupBuku()
        End If
    End Sub

    '=================================================================================================================================================
    'DATE
    Private Sub date_tgl_akhir_ValueChanged(sender As Object, e As EventArgs) Handles date_tgl_akhir.ValueChanged
        'date_tgl_awal.MaxDate = date_tgl_akhir.Value
    End Sub

    Private Sub date_tgl_awal_ValueChanged(sender As Object, e As EventArgs) Handles date_tgl_awal.ValueChanged
        date_tgl_akhir.MinDate = date_tgl_awal.Value
    End Sub
End Class
