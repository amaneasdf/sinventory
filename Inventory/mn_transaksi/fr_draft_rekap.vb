Public Class fr_draft_rekap
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

    Public Sub performRefresh()
        ClearAll()
        bt_cari_sales.PerformClick()
        bt_cari_faktur.PerformClick()
        loadDraftList(Trim(in_caridraft.Text))
    End Sub

    'LOAD LIST FAKTUR
    Private Sub loadFaktur(param As String)
        Dim query As String = "SELECT faktur_kode as kode, customer_nama as nama, faktur_tanggal_trans,faktur_netto, " _
                              & "IF(faktur_draft_rekap='','N',faktur_draft_rekap) as faktur_draft_rekap, salesman_nama " _
                              & "FROM data_penjualan_faktur INNER JOIN data_customer_master ON customer_kode=faktur_customer " _
                              & "LEFT JOIN data_salesman_master ON faktur_sales=salesman_kode " _
                              & "WHERE faktur_sales IN ({0}) AND faktur_tanggal_trans BETWEEN '{1}' AND '{2}'"
        Dim _tglawal As String = date_faktur_awal.Value.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = date_faktur_akhir.Value.ToString("yyyy-MM-dd")
        Dim bs As New BindingSource
        Dim sales As New List(Of String)

        If dgv_draftsales.Rows.Count > 0 Then
            For Each x As DataGridViewRow In dgv_draftsales.Rows
                sales.Add("'" & x.Cells("draft_sales_kode").Value & "'")
            Next
        Else
            sales.Add("'all'")
        End If

        If ck_tgl2.CheckState = CheckState.Checked Then
            _tglakhir = date_faktur_akhir.Value.ToString("yyyy-MM-dd")
            _tglawal = date_faktur_awal.Value.ToString("yyyy-MM-dd")
        Else
            _tglawal = selectperiode.tglawal.ToString("yyyy-MM-dd")
            _tglakhir = selectperiode.tglakhir.ToString("yyyy-MM-dd")
        End If

        query = String.Format(query, String.Join(",", sales), _tglawal, _tglakhir)

        consoleWriteLine(query)
        bs.DataSource = getDataTablefromDB(query)
        bs.Filter = "kode LIKE '%" & param & "%' OR nama LIKE '%" & param & "%'"

        dgv_listfaktur.DataSource = bs
    End Sub

    'LOAD LIST SALES
    Private Sub loadSales(param As String)
        Dim bs As New BindingSource

        bs.DataSource = getDataTablefromDB("SELECT salesman_kode as kode, salesman_nama as nama FROM data_salesman_master WHERE salesman_status=1")
        bs.Filter = "kode LIKE '%" & param & "%' OR nama LIKE '" & param & "%'"

        dgv_sales.DataSource = bs
    End Sub

    'LOAD LIST DRAFT
    Private Sub loadDraftList(param As String)
        Dim bs As New BindingSource
        Dim q As String = "SELECT draft_kode, draft_tanggal, GROUP_CONCAT(salesman_nama SEPARATOR ',') as draft_sales, (CASE " _
                          & " WHEN draft_printstatus=0 THEN 'N' " _
                          & " WHEN draft_printstatus=1 THEN 'Y' " _
                          & " ELSE 'ERROR' END) as draft_print " _
                          & "FROM data_draft_faktur LEFT JOIN data_draft_sales ON draft_kode=sales_draft AND sales_status=1 " _
                          & "LEFT JOIN data_salesman_master ON salesman_kode=sales_sales " _
                          & "WHERE draft_status=1 AND draft_tanggal BETWEEN '{0}' AND '{1}' GROUP BY draft_kode"
        'bs.DataSource = getDataTablefromDB("viewDraft('all','header')")

        bs.DataSource = getDataTablefromDB(String.Format(q, selectperiode.tglawal.ToString("yyyy-MM-dd"), selectperiode.tglakhir.ToString("yyyy-MM-dd")))
        consoleWriteLine(String.Format(q, selectperiode.tglawal, selectperiode.tglakhir))
        bs.Filter = "draft_kode LIKE '" & param & "%' OR draft_sales LIKE '%" & param & "%'"
        dgv_draft_list.DataSource = bs
    End Sub

    'LOAD SAVED SALES
    Private Sub loadListedSales(kodedraft As String)
        Dim dt As New DataTable
        dt = getDataTablefromDB("viewDraft('" & kodedraft & "','sales')")
        With dgv_draftsales.Rows
            .Clear()
            For Each x As DataRow In dt.Rows
                Dim y As Integer = .Add
                With .Item(y)
                    .Cells("draft_sales_kode").Value = x.ItemArray(0)
                    .Cells("draft_sales_n").Value = x.ItemArray(1)
                End With
            Next
        End With
        bt_cari_faktur.PerformClick()
    End Sub

    'LOAD SAVED FAKTUR
    Private Sub loadListedFaktur(kodedraft As String)
        'dgv_draft_list.DataSource = getDataTablefromDB("viewDraft('" & kodedraft & "','listfaktur')")
        Dim dt As New DataTable
        dt = getDataTablefromDB("viewDraft('" & kodedraft & "','faktur')")
        With dgv_draftfaktur.Rows
            .Clear()
            For Each x As DataRow In dt.Rows
                Dim y As Integer = .Add
                With .Item(y)
                    .Cells("draft_custo").Value = x.ItemArray(0)
                    .Cells("draft_faktur").Value = x.ItemArray(1)
                    .Cells("draft_netto").Value = x.ItemArray(2)
                    .Cells("draft_sales").Value = x.ItemArray(3)
                End With
            Next
        End With
    End Sub

    'LOAD DRAFT
    Private Sub loadDraft(kodedraft As String)
        ClearAll()

        op_con()
        readcommd("SELECT draft_kode,draft_tanggal FROM data_draft_faktur WHERE draft_kode='" & kodedraft & "'")
        If rd.HasRows Then
            in_kode_draft.Text = rd.Item("draft_kode")
            date_tgl_trans.Value = rd.Item("draft_tanggal")
            kodedraftselected = kodedraft
        End If
        rd.Close()

        loadListedSales(kodedraft)
        loadListedFaktur(kodedraft)
        bt_create_draft.Text = "Update Draft"
        If loggeduser.allowedit_transact = False Then
            bt_create_draft.Enabled = False
        Else
            bt_create_draft.Enabled = True
        End If
    End Sub

    'SAVE DRAFT
    Private Function createDraft() As Boolean
        Dim q As String
        op_con()
        Try
            Dim kodedraft = "RS"
            Dim queryArr As New List(Of String)
            Dim querycheck As Boolean = False

            '-------------- create kode if kode is nothing
            If in_kode_draft.Text = Nothing Then
                readcommd("SELECT RIGHT(draft_kode,4) as ctx FROM data_draft_faktur WHERE SUBSTRING(draft_kode,3,8)='" & date_tgl_trans.Value.ToString("yyyyMMdd") & "' ORDER BY ctx DESC LIMIT 1")
                Dim x As Integer = 0
                If rd.HasRows Then
                    x = CInt(rd.Item(0))
                End If
                x += 1
                rd.Close()
                kodedraft = "RS" & date_tgl_trans.Value.ToString("yyyyMMdd") & x.ToString("D4")
                kodedraftselected = kodedraft
                in_kode_draft.Text = kodedraft
            End If

            '--------------- insert draft
            Dim dataArr As String() = {
                "draft_kode='" & kodedraftselected & "'",
                "draft_tanggal='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                "draft_status='1'",
                "draft_reg_date=NOW()",
                "draft_reg_alias='" & loggeduser.user_id & "'"
                }
            queryArr.Add("INSERT INTO data_draft_faktur SET " & String.Join(",", dataArr) & " ON DUPLICATE KEY UPDATE draft_kode=draft_kode")

            '------------- insert sales -> delete removed sales
            Dim delquery As String = "DELETE FROM data_draft_sales WHERE sales_draft='" & kodedraftselected & "' AND sales_sales NOT IN({0})"
            Dim koded As New List(Of String)
            For Each x As DataGridViewRow In dgv_draftsales.Rows
                dataArr = {
                    "sales_sales='" & x.Cells("draft_sales_kode").Value & "'",
                    "sales_draft='" & kodedraftselected & "'",
                    "sales_reg_alias='" & loggeduser.user_id & "'",
                    "sales_reg_date=NOW()"
                    }
                koded.Add("'" & x.Cells("draft_sales_kode").Value & "'")
                queryArr.Add("INSERT INTO data_draft_sales SET " & String.Join(",", dataArr) & " ON DUPLICATE KEY UPDATE sales_index=sales_index")
            Next
            queryArr.Add(String.Format(delquery, String.Join(",", koded)))

            '-------------- insert faktur -> delete removed faktur
            delquery = "DELETE FROM data_draft_nota WHERE nota_draft='" & kodedraftselected & "' AND nota_faktur NOT IN ({0})"
            koded.Clear()
            For Each x As DataGridViewRow In dgv_draftfaktur.Rows
                dataArr = {
                    "nota_draft='" & kodedraftselected & "'",
                    "nota_faktur='" & x.Cells("draft_faktur").Value & "'",
                    "nota_reg_alias='" & loggeduser.user_id & "'",
                    "nota_reg_date=NOW()"
                    }
                koded.Add("'" & x.Cells("draft_faktur").Value & "'")
                queryArr.Add("INSERT INTO data_draft_nota SET " & String.Join(",", dataArr) & " ON DUPLICATE KEY UPDATE nota_index=nota_index")
            Next
            queryArr.Add(String.Format(delquery, String.Join(",", koded)))

            startTrans(queryArr)
            Return True
        Catch ex As Exception
            consoleWriteLine(ex.Message)
            Return False
        End Try
    End Function

    'CLEAR
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
        date_tgl_trans.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        date_faktur_awal.Value = selectperiode.tglawal
        date_faktur_akhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        ck_tgl2.CheckState = CheckState.Unchecked
        bt_create_draft.Enabled = True
        bt_create_draft.Text = "Simpan Draft"
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

    '----------------- load
    Private Sub fr_draft_rekap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each s As DateTimePicker In {date_tgl_trans, date_faktur_akhir, date_faktur_awal}
            s.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
            s.MaxDate = selectperiode.tglakhir
            s.MinDate = selectperiode.tglawal
        Next
        date_faktur_awal.Value = selectperiode.tglawal
        date_faktur_akhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)

        loadSales("")
        loadDraftList("")
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
        performRefresh()
    End Sub

    '----------------- cari
    Private Sub bt_cari_sales_Click(sender As Object, e As EventArgs) Handles bt_cari_sales.Click
        loadSales(in_cari_sales.Text)
    End Sub

    Private Sub in_cari_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari_sales.KeyDown, in_kode_draft.KeyDown
        If e.KeyCode = Keys.Enter Then
            bt_cari_sales.PerformClick()
        End If
    End Sub

    Private Sub bt_cari_faktur_Click(sender As Object, e As EventArgs) Handles bt_cari_faktur.Click
        Dim sales As New List(Of String)
        If dgv_draftsales.Rows.Count > 0 Then
            For Each x As DataGridViewRow In dgv_draftsales.Rows
                sales.Add("'" & x.Cells("draft_sales_kode").Value & "'")
            Next
        Else
            sales.Add("'all'")
        End If
        loadFaktur(in_cari_faktur.Text)
    End Sub

    Private Sub in_cari_faktur_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari_faktur.KeyDown, in_caridraft.KeyDown
        If e.KeyCode = Keys.Enter Then
            bt_cari_faktur.PerformClick()
        End If
    End Sub

    Private Sub bt_caridraft_Click(sender As Object, e As EventArgs) Handles bt_caridraft.Click
        loadDraftList(Trim(in_caridraft.Text))
    End Sub

    '------------------ dgv
    Private Sub dgv_sales_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_sales.CellClick
        If e.RowIndex >= 0 Then
            list_row_sales = e.RowIndex
        End If
    End Sub

    Private Sub dgv_sales_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_sales.CellDoubleClick
        If e.RowIndex >= 0 Then
            list_row_sales = e.RowIndex
            bt_addsales.PerformClick()
        End If
    End Sub

    Private Sub dgv_draftsales_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgv_draftsales.RowsAdded
        Dim sales As New List(Of String)
        If dgv_draftsales.Rows.Count > 0 Then
            For Each x As DataGridViewRow In dgv_draftsales.Rows
                sales.Add("'" & x.Cells("draft_sales_kode").Value & "'")
            Next
        Else
            sales.Add("'all'")
        End If
        loadFaktur("")
    End Sub

    Private Sub dgv_draftsales_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv_draftsales.RowsRemoved
        Dim sales As New List(Of String)
        If dgv_draftsales.Rows.Count > 0 Then
            For Each x As DataGridViewRow In dgv_draftsales.Rows
                sales.Add("'" & x.Cells("draft_sales_kode").Value & "'")
            Next
        Else
            sales.Add("'all'")
        End If
        loadFaktur("")
    End Sub

    Private Sub dgv_listfaktur_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listfaktur.CellClick
        If e.RowIndex >= 0 Then
            list_row_faktur = e.RowIndex
        End If
    End Sub

    Private Sub dgv_listfaktur_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listfaktur.CellDoubleClick
        If e.RowIndex >= 0 Then
            list_row_faktur = e.RowIndex
            bt_addfaktur.PerformClick()
        End If
    End Sub

    Private Sub dgv_draftfaktur_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_draftfaktur.CellDoubleClick
        If e.RowIndex > -1 And in_kode_draft.Text = Nothing Then
            bt_remfaktur.PerformClick()
        End If
    End Sub

    Private Sub dgv_draftsales_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_draftsales.CellDoubleClick
        If e.RowIndex > -1 Then
            bt_remsales.PerformClick()
        End If
    End Sub

    '------------------ add and remove faktur and sales bt
    Private Sub bt_addsales_Click(sender As Object, e As EventArgs) Handles bt_addsales.Click
        With dgv_sales
            For Each selected As DataGridViewRow In .SelectedRows
                For Each rows As DataGridViewRow In dgv_draftsales.Rows
                    If rows.Cells("draft_sales_kode").Value = selected.Cells("sales_kode").Value Then
                        Exit Sub
                    End If
                Next
                dgv_draftsales.Rows.Add(selected.Cells("sales_kode").Value, selected.Cells("sales_nama").Value)
            Next
        End With
    End Sub

    Private Sub bt_addfaktur_Click(sender As Object, e As EventArgs) Handles bt_addfaktur.Click
        With dgv_listfaktur
            For Each selected As DataGridViewRow In .SelectedRows
                For Each rows As DataGridViewRow In dgv_draftfaktur.Rows
                    If rows.Cells("draft_faktur").Value = selected.Cells("list_faktur").Value Then
                        Exit Sub
                    End If
                Next
                If selected.Cells("list_draft").Value = "N" Or selected.Cells("list_draft").Value = "" Then
                    selected.Cells("list_draft").Value = "Y"
                    dgv_draftfaktur.Rows.Add(selected.Cells("list_custo").Value, selected.Cells("list_faktur").Value, selected.Cells("list_netto").Value)
                End If
            Next
        End With
    End Sub
    Private Sub bt_remsales_Click(sender As Object, e As EventArgs) Handles bt_remsales.Click
        Dim cksales As Boolean = False
        With dgv_draftsales
            For Each selected As DataGridViewRow In .SelectedRows
                For Each fkt As DataGridViewRow In dgv_draftfaktur.Rows
                    If fkt.Cells("draft_sales").Value = selected.Cells("draft_sales_n").Value Then
                        cksales = True
                        Exit For
                    End If
                Next
                If cksales = False Then
                    .Rows.RemoveAt(selected.Index)
                Else
                    MessageBox.Show("Faktur untuk sales tsb sudah diinput, Hapus faktur yang berhubungan terlebih dahulu.")
                    Exit Sub
                End If
            Next
        End With
    End Sub

    Private Sub bt_remfaktur_Click(sender As Object, e As EventArgs) Handles bt_remfaktur.Click
        With dgv_draftfaktur
            For Each selected As DataGridViewRow In .SelectedRows
                For Each rows As DataGridViewRow In dgv_listfaktur.Rows
                    If selected.Cells("draft_faktur").Value = rows.Cells("list_faktur").Value Then
                        rows.Cells("list_draft").Value = "N"
                    End If
                Next
                .Rows.RemoveAt(selected.Index)
            Next
        End With
    End Sub

    '----------------- load draft
    Private Sub bt_loaddraft_Click(sender As Object, e As EventArgs) Handles bt_loaddraft.Click
        If list_row_draft > -1 Then
            loadDraft(dgv_draft_list.Rows(list_row_draft).Cells(0).Value)
        End If
    End Sub

    Private Sub dgv_draft_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_draft_list.CellClick
        If e.RowIndex >= 0 Then
            list_row_draft = e.RowIndex
        End If
    End Sub

    Private Sub dgv_draft_list_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_draft_list.CellDoubleClick
        If e.RowIndex >= 0 Then
            list_row_draft = e.RowIndex
            bt_loaddraft.PerformClick()
        End If
    End Sub

    '------------- cetak
    Private Sub bt_draft_barang_Click(sender As Object, e As EventArgs) Handles bt_draft_barang.Click
        If in_kode_draft.Text = Nothing Then
            MessageBox.Show("Input/Pilih draft rekap penjualan salesman yang akan dicetak terlebih dahulu.", "Rekap Salesman", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Using draftbarang As New fr_draft_barang_view
            With draftbarang
                .kodedraft = in_kode_draft.Text
                .ShowDialog()
            End With
        End Using
    End Sub

    Private Sub bt_draft_nota_Click(sender As Object, e As EventArgs) Handles bt_draft_nota.Click
        If in_kode_draft.Text = Nothing Then
            MessageBox.Show("Input/Pilih draft rekap penjualan salesman yang akan dicetak terlebih dahulu.", "Rekap Salesman", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Using draftbarang As New fr_draft_nota_view
            Me.Cursor = Cursors.WaitCursor
            With draftbarang
                .kodedraft = in_kode_draft.Text
                .ShowDialog()
            End With
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    '------------ input
    Private Sub date_tgl_trans_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_trans.KeyDown
        keyshortenter(date_faktur_awal, e)
    End Sub

    Private Sub date_faktur_awal_KeyDown(sender As Object, e As KeyEventArgs) Handles date_faktur_awal.KeyDown
        keyshortenter(date_faktur_akhir, e)
    End Sub

    Private Sub date_faktur_akhir_KeyDown(sender As Object, e As KeyEventArgs) Handles date_faktur_akhir.KeyDown
        keyshortenter(in_cari_sales, e)
    End Sub

    Private Sub date_faktur_awal_ValueChanged(sender As Object, e As EventArgs) Handles date_faktur_awal.ValueChanged
        date_faktur_akhir.MinDate = date_faktur_awal.Value
        loadFaktur("")
    End Sub

    Private Sub date_faktur_akhir_ValueChanged(sender As Object, e As EventArgs) Handles date_faktur_akhir.ValueChanged
        date_faktur_awal.MaxDate = date_faktur_akhir.Value
        loadFaktur("")
    End Sub

    Private Sub ck_tgl2_CheckedChanged(sender As Object, e As EventArgs) Handles ck_tgl2.CheckedChanged
        loadFaktur("")
    End Sub

    '------------- save draft
    Private Sub bt_create_draft_Click(sender As Object, e As EventArgs) Handles bt_create_draft.Click
        If dgv_draftsales.Rows.Count = 0 Then
            MessageBox.Show("Salesman belum di masukan")
            Exit Sub
        End If

        If dgv_draftfaktur.Rows.Count = 0 Then
            MessageBox.Show("Faktur belum dimasukan")
            Exit Sub
        End If

        If createDraft() = True Then
            MessageBox.Show("Draft Rekap Tersimpan")
            loadDraftList("")
        Else
            MessageBox.Show("Error has been occured when inputing data")
        End If
    End Sub

    Private Sub DraftBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DraftBarangToolStripMenuItem.Click
        bt_draft_barang.PerformClick()
    End Sub

    Private Sub DraftNotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DraftNotaToolStripMenuItem.Click
        bt_draft_nota.PerformClick()
    End Sub
End Class

'inputing dgv detail
'delete fr where kodedraft= this AND (kodefordetail NOT this OR ... this)
'insert on dup key updt kodedraft=kodedraft