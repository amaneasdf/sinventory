Public Class fr_draft_tagihan
    Public tabpagename As TabPage
    Private list_row_faktur As Integer = 0
    Private list_row_sales As Integer = 0
    Private list_row_draft As Integer = 0
    Private kodedraftselected As String = "all"
    Private edited As Boolean = False

    Public Sub setpage(page As TabPage)
        tabpagename = page
        Console.WriteLine("pg" & page.Name.ToString)
        Console.WriteLine("pgset" & tabpagename.Name.ToString)
    End Sub

    Private Sub loadSales(param As String)
        Dim bs As New BindingSource

        bs.DataSource = getDataTablefromDB("SELECT salesman_kode as kode, salesman_nama as nama FROM data_salesman_master")
        bs.Filter = "kode LIKE '%" & param & "%' OR nama LIKE '%" & param & "'"

        dgv_sales.DataSource = bs
    End Sub

    Private Sub ClearAll()
        For Each x As TextBox In {in_cari_faktur, in_cari_sales, in_caridraft, in_kode_draft}
            x.Clear()
        Next
        For Each x As Integer In {list_row_draft, list_row_faktur, list_row_sales}
            x = 0
        Next
        For Each x As DataGridView In {dgv_draftfaktur, dgv_draftsales}
            x.Rows.Clear()
        Next
        date_tgl_trans.Value = DateSerial(selectedperiode.Year, selectedperiode.Month, Today.Day)
        date_faktur_awal.Value = DateSerial(selectedperiode.Year, selectedperiode.Month, 1)
        date_faktur_akhir.Value = DateSerial(selectedperiode.Year, selectedperiode.Month + 1, -1)
        ck_tgl2.CheckState = CheckState.Unchecked
        ck_tgl1.CheckState = CheckState.Unchecked
    End Sub

    '--------------resize dgv
    Private Sub fr_draft_rekap_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If MyBase.Size.Width > 1170 Then
            dgv_draft_list.Size = New System.Drawing.Size(236, 373)
            bt_loaddraft.Location = New Point(dgv_draft_list.Left + (dgv_draft_list.Size.Width - bt_loaddraft.Size.Width), 486)
        Else
            dgv_draft_list.Size = New System.Drawing.Size(236, 154)
            bt_loaddraft.Location = New Point(dgv_draft_list.Left + (dgv_draft_list.Size.Width - bt_loaddraft.Size.Width), 264)
        End If
    End Sub

    '----------------- close
    Private Sub bt_close_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_close_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        ClearAll()
        'disableAllSwitch(True)
        main.tabcontrol.TabPages.Remove(tabpagename)
    End Sub

    '---------------- load
    Private Sub fr_draft_tagihan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    '------------- menu
    Private Sub mn_tambah_Click(sender As Object, e As EventArgs) Handles mn_tambah.Click
        If in_kode_draft.Text <> Nothing Then
            If MessageBox.Show("Batalkan Input?", "Rekap Penjualan", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If
        End If
        ClearAll()
        date_tgl_trans.Focus()
    End Sub

    Private Sub mn_edit_Click(sender As Object, e As EventArgs) Handles mn_edit.Click
        in_caridraft.Focus()
    End Sub

    Private Sub mn_refresh_Click(sender As Object, e As EventArgs) Handles mn_refresh.Click
        ClearAll()
        bt_cari_sales.PerformClick()
        bt_cari_faktur.PerformClick()
        bt_caridraft.PerformClick()
    End Sub
End Class
