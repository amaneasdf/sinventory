Public Class fr_lap_filter
    Public lap_type As String
    Private query_lap As String
    Private lap_type_arr As String() = {
        "BeliNota", "BeliSupplier", "BeliTanggal",
        "JualNota", "JualSupplier", "JualCusto", "JualSales", "JualTanggal", "JualTipe",
        "Stock", "StockDetail"
        }

    Private Function createQuery(selector As String) As String
        Dim dbView As String
        Dim q As String = "SELECT {0} FROM {1} WHERE {2}"
        Dim param_date1 As String = "{0} BETWEEN '" & date_awal.Value.ToString("yyyy-MM-dd") & "' AND '" & date_akhir.Value.ToString("yyyy-MM-dd") & "'"
        Dim paramArr As New List(Of String)
        Dim colArr As String()

        Select Case selector
            Case "selectBeliNota"
                colArr = {"*"}
                param_date1 = String.Format(param_date1, "lap_tgl")
                dbView = selector
            Case "selectBeliSupplier"
                colArr = {
                    "lap_supplier_n",
                    "SUM(lap_brutto) AS lap_brutto",
                    "SUM(lap_diskon) AS lap_diskon",
                    "SUM(lap_ppn) AS lap_ppn",
                    "SUM(lap_jumlah) AS lap_jumlah"
                    }
                q = q & " GROUP BY lap_supplier_n"
                param_date1 = String.Format(param_date1, "lap_tgl")
                dbView = "selectBeliNota"
            Case "selectBeliTanggal"
                colArr = {
                    "lap_tgl",
                    "SUM(lap_brutto) AS lap_brutto",
                    "SUM(lap_diskon) AS lap_diskon",
                    "SUM(lap_ppn) AS lap_ppn",
                    "SUM(lap_jumlah) AS lap_jumlah"
                    }
                q = q & " GROUP BY lap_tgl"
                param_date1 = String.Format(param_date1, "lap_tgl")
                dbView = "selectBeliNota"
            Case "selectJualNota"
                colArr = {"*"}
                param_date1 = String.Format(param_date1, "lap_tgl")
                dbView = selector
            Case "selectStock"
                colArr = {"*"}
                param_date1 = String.Format(param_date1, "stock_tanggal")
                dbView = selector
            Case Else
                colArr = {"*"}
                dbView = ""
        End Select

        Select Case dbView
            Case ""
                Return "err"
            Case Else
                q = String.Format(q, String.Join(",", colArr), dbView, String.Join(" ", paramArr))

                Console.Write("que_b : " & q)
                Return q
        End Select
    End Function

    Private Sub lapSelector()
        'Select Case lap_type
        '    Case "belinota"
        '        query_lap = createQuery("selectBeliNota")
        '    Case "belisupplier"
        '        query_lap = 
        '    Case "jualnota"
        '        query_lap = createQuery("selectJualNota")
        '        'Case "stock"
        '        '    query_lap = createQuery("selectStock")
        '        'Case "stockdetail"
        '        '    query_lap = createQuery("selectStockDetail")
        '    Case Else
        '        Exit Sub
        'End Select
        query_lap = createQuery("select" & lap_type)
    End Sub

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.Close()
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Tutup Form?", "Data Barang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '---------------load
    Private Sub fr_lap_filter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        date_awal.Value = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
        date_akhir.Value = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, -1)
    End Sub

    '---------------button
    Private Sub bt_cetak_Click(sender As Object, e As EventArgs) Handles bt_cetak.Click

    End Sub

    Private Sub bt_preview_Click(sender As Object, e As EventArgs) Handles bt_preview.Click

    End Sub
End Class