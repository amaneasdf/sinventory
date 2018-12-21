Public Class fr_export_efaktur
    Private tabpagename As TabPage

    Public Sub setpage(page As TabPage)
        tabpagename = page
        consoleWriteLine("pg" & page.Name.ToString)
        consoleWriteLine("pgset" & tabpagename.Name.ToString)
    End Sub

    Public Sub performRefresh()

    End Sub

    Private Function createQuery(type As String) As String
        Dim q As String = ""
        Dim col As New List(Of String)
        Dim _tglawal As String = date_tglawal.Value.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = date_tglakhir.Value.ToString("yyyy-MM-dd")
        Dim _qwhr As String = ""
        Dim whr As New List(Of String)

        q = "SELECT {0} FROM data_penjualan_faktur " _
            & "LEFT JOIN data_customer_master ON customer_kode=faktur_customer " _
            & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' {3}"

        Select Case type
            Case "dgv"
                col.AddRange({"faktur_kode", "faktur_pkp", "faktur_tanggal_trans", "faktur_pajak_no", "faktur_customer", "cusomer_nama", "faktur_jumlah", "faktur_disc_rupiah",
                              "faktur_total", "faktur_ppn_persen", "faktur_netto", "faktur_bayar"})

            Case "export"
                col.AddRange({"faktur_pajak_no", "faktur_kode", "customer_nama", "customer_alamat", "customer_npwp", "barang_nama", "trans_qty", "trans_harga_jual"})
                q = "SELECT {0} FROM data_penjualan_faktur LEFT JOIN data_penjualan_trans ON faktur_kode=trans_bukti AND trans_status=1 " _
                    & "LFET JOIN data_customer_master ON faktur_customer=customer_kode " _
                    & "WHERE faktur_status=1 AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}' {3}"
        End Select

        If ck_pkp.Checked = True Then
            whr.Add("faktur_pkp<>1")
        End If
        If whr.Count > 0 Then
            _qwhr = "AND " & String.Join(" AND ", whr)
        End If

        q = String.Format(q, String.Join(",", col), _tglawal, _tglakhir, _qwhr)

        Return q
    End Function

    Private Sub loadFaktur()
        dgv_faktur.DataSource = getDataTablefromDB(createQuery("dgv"))
    End Sub

    Private Sub exportData()
        Dim colheadr As New List(Of String)
        Dim dt As DataTable
        Dim q As String = ""
        Dim _qwhr As String = ""
        Dim whr As New List(Of String)


    End Sub

    Private Sub insertNoPajak(startstring As String)

    End Sub

    Private Sub save()

    End Sub


    'CLOSE
    Private Sub bt_close_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_close_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        main.tabcontrol.TabPages.Remove(tabpagename)
    End Sub

End Class
