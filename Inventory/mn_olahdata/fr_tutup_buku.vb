Public Class fr_tutup_buku
    Public tabpagename As TabPage

    Public Sub setpage(page As TabPage)
        tabpagename = page
        Console.WriteLine("pg" & page.Name.ToString)
        Console.WriteLine("pgset" & tabpagename.Name.ToString)
    End Sub

    Public Sub performRefresh()
        Console.WriteLine(tabpagename.Name.ToString)
        Me.Cursor = Cursors.AppStarting

    End Sub

    Private Sub inputSW(sw As Boolean)
        ck_proses.Enabled = sw
        pnl_content.Enabled = sw
    End Sub

    Private Sub loadStock()
        Dim q As String = "CALL createDataStockTableTemp('" & selectperiode.id & "','" & date_tgl_akhir.Value.ToString("yyyy-MM-dd") & "'); " _
                          & "SELECT {0} FROM stock_temp LEFT JOIN data_barang_master brg ON barang_kode=stock_barang {1}; " _
                          & "DROP TEMPORARY TABLE IF EXISTS stock_temp;"
        Dim data As String()
        Dim qwh As String = ""
        Dim whr As New List(Of String)
        Dim _dt As New DataTable

        data = {
            "1 as stock_ck",
            "stock_tanggal",
            "stock_barang",
            "brg.barang_nama",
            "stock_gudang",
            "gudang_nama",
            "stock_status",
            "stock_sisa",
            "stock_stockop",
            "stock_sisastockop",
            "(CASE WHEN brg.barang_jenis=1 THEN 'STOK' WHEN brg.barang_jenis=2 THEN 'BONUS' ELSE 'ERROR' END) AS barang_jenis",
            "CONCAT('B:',stock_beli,',J:',stock_jual,',RB:',stock_rbeli,',RJ:',stock_rjual,',IN:',stock_min,',OUT:',stock_mout) as stock_det"
            }

        dgv_stock.Rows.Clear()

        If ck_stok.CheckState = CheckState.Checked Or ck_stok_bonus.CheckState = CheckState.Checked Then
            qwh = "WHERE barang_status IN ({0})"
            If ck_stok.Checked = True Then
                whr.Add("1")
            End If
            If ck_stok_bonus.Checked = True Then
                whr.Add("2")
            End If
            qwh = String.Format(qwh, String.Join(",", whr))

            q = String.Format(q, String.Join(",", data), qwh)
            consoleWriteLine(q)
            _dt = getDataTablefromDB(q)

            For Each x As DataRow In _dt.Rows
                With dgv_stock.Rows
                    Dim ridx As Integer = .Add
                    With .Item(ridx)
                        .Cells("brg_ck").Value = x.ItemArray(0)
                        .Cells("brg_tgl").Value = x.ItemArray(1)
                        .Cells("brg_brg").Value = x.ItemArray(2)
                        .Cells("brg_brg").ToolTipText = x.ItemArray(3)
                        .Cells("brg_gudang").Value = x.ItemArray(4)
                        .Cells("brg_gudang").ToolTipText = x.ItemArray(5)
                        .Cells("brg_status").Value = x.ItemArray(6)
                        .Cells("brg_sisa").Value = x.ItemArray(7)
                        .Cells("brg_stockop").Value = x.ItemArray(8)
                        .Cells("brg_sisaop").Value = x.ItemArray(9)
                        .Cells("brg_jenis").Value = x.ItemArray(10)
                        .Cells("brg_sisa").ToolTipText = x.ItemArray(11)
                    End With
                End With
                'dgv_stock.Rows.Add(x.ItemArray(0), , x.ItemArray(2), x.ItemArray(3), x.ItemArray(4), x.ItemArray(5), x.ItemArray(6), x.ItemArray(7))
            Next
        ElseIf ck_stok.Checked = False And ck_stok_bonus.Checked = False Then
            dgv_stock.Rows.Clear()
        End If
    End Sub

    Private Sub doTutupBuku()
        'INSERT STOK AWAL FOR SELECTED ITEM IN dgv_barang WITH NEW IDPERIODE
        'CREATE KARTU STOCK FOR THE ONE INSERTED
        'UPDATE IDPERIODE STOK AWAL WHERE reg_date IS ON THE NEW PERIODE

    End Sub



    Private Sub fr_tutup_buku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim endmonth As Date = DateSerial(selectperiode.tglawal.Year, selectperiode.tglawal.Month + 1, 0)
        Dim xdate As Date = IIf(Today > endmonth, endmonth, Today)

        in_kode.Text = selectperiode.id

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

        If selectperiode.id <> currentperiode.id Then
            inputSW(False)
        Else
            inputSW(True)
        End If
    End Sub

    '=================================================================================================================================================
    'PROCESS BUTTON
    Private Sub ck_proses_CheckedChanged(sender As Object, e As EventArgs) Handles ck_proses.CheckedChanged
        If ck_proses.CheckState = CheckState.Checked Then
            bt_simpanperkiraan.Enabled = True
        Else
            bt_simpanperkiraan.Enabled = False
        End If
    End Sub

    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click
        If MessageBox.Show("Lakukan proses tutup buku?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            doTutupBuku()
        End If
    End Sub

    '=================================================================================================================================================
    'DATE
    Private Sub date_tgl_akhir_ValueChanged(sender As Object, e As EventArgs) Handles date_tgl_akhir.ValueChanged
        loadStock()
    End Sub

    '=================================================================================================================================================
    'STOCK
    Private Sub ck_stok_CheckedChanged(sender As Object, e As EventArgs) Handles ck_stok.CheckedChanged, ck_stok_bonus.CheckedChanged
        loadStock()
    End Sub
End Class
