Public Class fr_set_periode
    '----------------close
    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '-----------------load
    Private Sub fr_set_periode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cal_periode.SelectionRange.Start = selectperiode.tglawal
    End Sub

    '-----------------set periode
    Private Sub bt_set_periode_Click(sender As Object, e As EventArgs) Handles bt_set_periode.Click
        setperiode(cal_periode.SelectionRange.Start)
        'Dim x As Date = cal_periode.SelectionRange.Start
        'selectedperiode = DateSerial(x.Year, x.Month, 1)
        'main.strip_periode.Text = "Periode data : " & selectedperiode.ToString("MMMM yyyy")

        ''TODO:REFRESH TAB
        'Dim tbpg As TabPage() = {
        '    pgstockop,
        '    pgstok,
        '    pgpembelian,
        '    pgpenjualan,
        '    pgreturbeli,
        '    pgreturjual,
        '    pgmutasigudang,
        '    pgmutasistok,
        '    pghutangawal,
        '    pghutangbayar,
        '    pghutangbgo,
        '    pgpiutangawal,
        '    pgpiutangbayar,
        '    pgpiutangbgcair,
        '    pgpiutangbgtolak,
        '    pgkas,
        '    pgjurnalmemorial,
        '    pgjurnalumum,
        '    pgkartustok
        '    }
        'For Each y As TabPage In tbpg
        '    If main.tabcontrol.Contains(y) = True Then
        '        refreshTabPage(y.Name.ToString)
        '    End If
        'Next

        'TODO : SET MAX/MIN TANGGAL TRANSAKSI BASED ON PERIODE <- code on each form?
        Me.Close()
    End Sub
End Class