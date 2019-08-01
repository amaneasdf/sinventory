Public Class fr_draft_tagihan
    Public tabpagename As TabPage
    Private list_row_faktur As Integer = 0
    Private list_row_sales As Integer = 0
    Private list_row_draft As Integer = 0
    Private kodedraftselected As String = "all"
    Private edited As Boolean = False
    Private printedstat As Integer = 0

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

    'LOAD SALES
    Private Sub loadSales(Optional param As String = Nothing)
        Dim bs As New BindingSource

        bs.DataSource = getDataTablefromDB("SELECT salesman_kode as kode, salesman_nama as nama FROM data_salesman_master")
        bs.Filter = "kode LIKE '%" & param & "%' OR nama LIKE '%" & param & "'"

        dgv_sales.DataSource = bs
    End Sub

    'LOAD FAKTUR
    Private Sub loadFaktur(sales As String, Optional param As String = Nothing)
        Dim bs As New BindingSource
        Dim _tglawal As String = date_faktur_awal.Value.ToString("yyyy-MM-dd")
        Dim _tglakhir As String = date_faktur_akhir.Value.ToString("yyyy-MM-dd")
        'Dim q As String = "SELECT piutang_faktur, piutang_tgl, piutang_custo_n, piutang_sisa, piutang_jt, " _
        '                  & "customer_pasar, customer_kabupaten, customer_kecamatan " _
        '                  & "FROM selectPiutangAwal LEFT JOIN data_customer_master ON piutang_custo=customer_kode " _
        '                  & "WHERE piutang_sales='{0}' {1} AND piutang_sisa<>0"

        Dim q As String = "SELECT piutang_faktur, @tgl:=faktur_tanggal_trans as piutang_tgl, getSisaPiutang(piutang_faktur,'{0}') as piutang_sisa, " _
                          & "ADDDATE(@tgl,faktur_term) as piutang_jt, customer_nama As piutang_custo_n, customer_pasar, customer_kecamatan, " _
                          & "customer_kabupaten, salesman_nama " _
                          & "FROM data_piutang_awal LEFT JOIN data_penjualan_faktur ON faktur_kode=piutang_faktur AND faktur_status=1 " _
                          & "LEFT JOIN data_customer_master ON customer_kode=faktur_customer " _
                          & "LEFT JOIN data_salesman_master ON salesman_kode= faktur_sales " _
                          & "WHERE piutang_status=1 AND piutang_idperiode='{0}' AND faktur_sales='{1}' " _
                          & " {2}"
        Dim qwh As String = ""
        Dim whr As New List(Of String)
        Dim whr_tgl As New List(Of String)
        If in_kabupaten.Text <> Nothing Then
            whr.Add("customer_kabupaten LIKE '" & in_kabupaten.Text & "'")
        End If
        If in_kecamatan.Text <> Nothing Then
            whr.Add("customer_kecamatan LIKE '" & in_kecamatan.Text & "'")
        End If
        If in_pasar.Text <> Nothing Then
            whr.Add("customer_pasar LIKE '" & in_pasar.Text & "'")
        End If
        If ck_tgl2.Checked = True Then
            whr_tgl.Add("ADDDATE(faktur_tanggal_trans,faktur_term) BETWEEN '" & _tglawal & "' AND '" & _tglakhir & "'")
        End If
        If ck_tgl1.Checked = True Then
            whr_tgl.Add("ADDDATE(faktur_tanggal_trans,faktur_term) < '" & _tglawal & "'")
        End If
        'If ck_tgl2.Checked = True And ck_tgl1.Checked = False Then
        '    whr.Add("ADDDATE(faktur_tanggal_trans,faktur_term) BETWEEN '" & _tglawal & "' AND '" & _tglakhir & "'")
        'ElseIf ck_tgl1.Checked = True And ck_tgl2.Checked = False Then
        '    whr.Add("ADDDATE(faktur_tanggal_trans,faktur_term) < '" & _tglawal & "'")
        'End If
        qwh = IIf(whr.Count > 0, "AND ", "") & String.Join(" AND ", whr)
        If whr_tgl.Count > 0 Then
            qwh += " AND ({0})"
            qwh = String.Format(qwh, String.Join(" OR ", whr_tgl))
        End If


        q = String.Format(q, selectperiode.id, in_sales.Text, qwh)
        consoleWriteLine(q)

        bs.DataSource = getDataTablefromDB(q)
        bs.Filter = "piutang_faktur LIKE '" & param & "%' OR piutang_custo_n LIKE '" & param & "%'"

        dgv_listfaktur.DataSource = bs
    End Sub

    Private Sub loadDraftList(param As String)
        Dim q As String = "SELECT draft_kode, draft_tanggal as draft_tgl, salesman_nama as draft_sales " _
                          & "FROM data_tagihan_faktur LEFT JOIN data_salesman_master ON salesman_kode=draft_sales " _
                          & "WHERE draft_status=1 AND draft_tanggal BETWEEN '{0}' AND '{1}'"
        Dim bs As New BindingSource

        bs.DataSource = getDataTablefromDB(String.Format(q, selectperiode.tglawal.ToString("yyyy-MM-dd"), selectperiode.tglakhir.ToString("yyyy-MM-dd")))
        bs.Filter = "draft_kode LIKE '%" & param & "%' OR draft_sales LIKE '%" & param & "%'"
        dgv_draft_list.DataSource = bs
    End Sub

    Private Sub loadListedFaktur(kodedraft As String)
        Dim q As String = "SELECT nota_faktur, customer_nama,nota_tagihan, salesman_nama FROM data_tagihan_nota " _
                          & "LEFT JOIN data_penjualan_faktur ON nota_faktur=faktur_kode " _
                          & "LEFT JOIN data_customer_master ON customer_kode=faktur_customer " _
                          & "LEFT JOIN data_salesman_master ON salesman_kode=faktur_sales " _
                          & "WHERE nota_draft='{0}'"
        Dim dt As New DataTable
        dt = getDataTablefromDB(String.Format(q, kodedraft))
        consoleWriteLine(String.Format(q, kodedraft))

        With dgv_draftfaktur.Rows
            .Clear()
            For Each x As DataRow In dt.Rows
                Dim y As Integer = .Add
                With .Item(y)
                    .Cells("draft_custo").Value = x.ItemArray(1)
                    .Cells("draft_faktur").Value = x.ItemArray(0)
                    .Cells("draft_sisa").Value = x.ItemArray(2)
                    .Cells("draft_sales").Value = x.ItemArray(3)
                End With
            Next
        End With
    End Sub

    Private Sub loadDraft(kodedraft As String)
        ClearAll()

        op_con()
        readcommd("SELECT draft_kode,draft_tanggal,draft_sales,salesman_nama, draft_status, draft_printstatus " _
                  & "FROM data_tagihan_faktur LEFT JOIN data_salesman_master ON draft_sales=salesman_kode " _
                  & "WHERE draft_kode='" & kodedraft & "'")
        If rd.HasRows Then
            in_kode_draft.Text = rd.Item("draft_kode")
            date_tgl_trans.Value = rd.Item("draft_tanggal")
            in_sales.Text = rd.Item("draft_sales")
            in_sales_n.Text = rd.Item("salesman_nama")
            printedstat = rd.Item("draft_printstatus")
            kodedraftselected = kodedraft
        End If
        rd.Close()

        If printedstat = 1 Then
            lbl_statprint.Visible = True
        Else
            lbl_statprint.Visible = False
        End If

        loadListedFaktur(kodedraft)
        loadFaktur(in_sales.Text)
    End Sub

    Private Sub loadHistoryTagih(kodefaktur As String)
        Dim q As String = "SELECT "
    End Sub

    Private Function createDraft() As Boolean
        op_con()
        Try
            Dim kodedraft = "DT"
            Dim queryArr As New List(Of String)
            Dim querycheck As Boolean = False

            '-------------- create kode if kode is nothing
            If in_kode_draft.Text = Nothing Then
                readcommd("SELECT COUNT(draft_kode) FROM data_tagihan_faktur WHERE SUBSTRING(draft_kode,3,8)='" & date_tgl_trans.Value.ToString("yyyyMMdd") & "'")
                Dim x As Integer = 0
                If rd.HasRows Then
                    x = CInt(rd.Item(0))
                End If
                x += 1
                rd.Close()
                kodedraft = "DT" & date_tgl_trans.Value.ToString("yyyyMMdd") & x.ToString("D4")
                kodedraftselected = kodedraft
                in_kode_draft.Text = kodedraft
            End If

            '--------------- insert draft
            Dim dataArr As String() = {
                "draft_kode='" & kodedraftselected & "'",
                "draft_tanggal='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                "draft_sales='" & in_sales.Text & "'",
                "draft_reg_date=NOW()",
                "draft_reg_alias='" & loggeduser.user_id & "'"
                }
            Dim data1 As String() = {
                "draft_tanggal='" & date_tgl_trans.Value.ToString("yyyy-MM-dd") & "'",
                "draft_sales='" & in_sales.Text & "'",
                "draft_upd_date=NOW()",
                "draft_upd_alias='" & loggeduser.user_id & "'"
                }
            queryArr.Add("INSERT INTO data_tagihan_faktur SET " & String.Join(",", dataArr) & " ON DUPLICATE KEY UPDATE " & String.Join(",", data1))

            '-------------- insert faktur -> delete removed faktur
            Dim delquery As String = "DELETE FROM data_tagihan_nota WHERE nota_draft='" & kodedraftselected & "' AND nota_faktur NOT IN ({0})"
            Dim koded As New List(Of String)
            For Each x As DataGridViewRow In dgv_draftfaktur.Rows
                dataArr = {
                    "nota_draft='" & kodedraftselected & "'",
                    "nota_faktur='" & x.Cells("draft_faktur").Value & "'",
                    "nota_tagihan=" & CDbl(x.Cells("draft_sisa").Value),
                    "nota_reg_alias='" & loggeduser.user_id & "'",
                    "nota_reg_date=NOW()"
                    }
                koded.Add("'" & x.Cells("draft_faktur").Value & "'")
                queryArr.Add("INSERT INTO data_tagihan_nota SET " & String.Join(",", dataArr) & " ON DUPLICATE KEY UPDATE nota_index=nota_index")
            Next
            queryArr.Add(String.Format(delquery, String.Join(",", koded)))

            Return startTrans(queryArr)
        Catch ex As Exception
            consoleWriteLine(ex.Message)
            Return False
        End Try
    End Function

    Private Sub ClearAll()
        For Each x As TextBox In {in_cari_faktur, in_cari_sales, in_caridraft, in_kode_draft, in_sales, in_sales_n}
            x.Clear()
        Next
        For Each x As Integer In {list_row_draft, list_row_faktur, list_row_sales}
            x = 0
        Next
        For Each x As DataGridView In {dgv_draftfaktur}
            x.Rows.Clear()
            x.Refresh()
        Next
        For Each s As DateTimePicker In {date_tgl_trans}
            s.MinDate = selectperiode.tglawal
            s.MaxDate = selectperiode.tglakhir
        Next
        date_tgl_trans.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        date_faktur_awal.Value = selectperiode.tglawal
        date_faktur_akhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
        ck_tgl2.CheckState = CheckState.Unchecked
        ck_tgl1.CheckState = CheckState.Unchecked
        lbl_statprint.Visible = False
    End Sub

    '--------------resize dgv
    Private Sub fr_draft_rekap_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        'If MyBase.Size.Width > 1170 Then
        '    dgv_draft_list.Size = New System.Drawing.Size(236, 373)
        '    bt_loaddraft.Location = New Point(dgv_draft_list.Left + (dgv_draft_list.Size.Width - bt_loaddraft.Size.Width), 486)
        'Else
        '    dgv_draft_list.Size = New System.Drawing.Size(236, 154)
        '    bt_loaddraft.Location = New Point(dgv_draft_list.Left + (dgv_draft_list.Size.Width - bt_loaddraft.Size.Width), 264)
        'End If
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

    '----------------------- ck state
    Private Sub ck_tgl2_CheckedChanged(sender As Object, e As EventArgs) Handles ck_tgl2.CheckedChanged
        'If ck_tgl2.Checked = True Then
        '    ck_tgl1.Checked = False
        'End If
        loadFaktur(in_sales.Text)
    End Sub

    Private Sub ck_tgl1_CheckedChanged(sender As Object, e As EventArgs) Handles ck_tgl1.CheckedChanged
        'If ck_tgl1.Checked = True Then
        '    ck_tgl2.Checked = False
        'End If
        loadFaktur(in_sales.Text)
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
        loadFaktur(in_sales.Text, in_cari_faktur.Text)
    End Sub

    Private Sub date_faktur_akhir_ValueChanged(sender As Object, e As EventArgs) Handles date_faktur_akhir.ValueChanged
        date_faktur_awal.MaxDate = date_faktur_akhir.Value
        loadFaktur(in_sales.Text, in_cari_faktur.Text)
    End Sub

    '---------------- load
    Private Sub fr_draft_tagihan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearAll()
        loadSales()
        loadDraftList("")

        For Each x As DataGridViewColumn In {list_sisa, draft_sisa}
            x.DefaultCellStyle = dgvstyle_currency
        Next
    End Sub

    '------------- menu
    Private Sub mn_tambah_Click(sender As Object, e As EventArgs) Handles mn_tambah.Click
        If in_kode_draft.Text <> Nothing Then
            If MessageBox.Show("Batalkan Input?", "Draft Tagihan", MessageBoxButtons.YesNo) = DialogResult.No Then
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
        loadFaktur(in_sales.Text, in_cari_faktur.Text)
    End Sub

    Private Sub in_cari_faktur_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari_faktur.KeyDown
        If e.KeyCode = Keys.Enter Then
            bt_cari_faktur.PerformClick()
        End If
    End Sub

    Private Sub in_caridraft_KeyUp(sender As Object, e As KeyEventArgs) Handles in_caridraft.KeyUp
        If e.KeyCode = Keys.Enter Then
            bt_caridraft.PerformClick()
        End If
    End Sub

    Private Sub bt_caridraft_Click(sender As Object, e As EventArgs) Handles bt_caridraft.Click
        loadDraftList(Trim(in_caridraft.Text))
    End Sub

    '------------- SELECT SALES
    Private Sub dgv_sales_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_sales.CellMouseDoubleClick
        If e.RowIndex > -1 Then
            bt_addsales.PerformClick()
        End If
    End Sub

    Private Sub bt_addsales_Click(sender As Object, e As EventArgs) Handles bt_addsales.Click
        If dgv_sales.SelectedRows.Count = 1 Then
            With dgv_sales.SelectedRows.Item(0)
                If printedstat = 0 Then
                    If dgv_draftfaktur.Rows.Count > 0 Then
                        Dim x As DialogResult = MessageBox.Show("Simpan draft tagihan sebelum mengganti sales?", "Draft Tagihan", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                        If x = DialogResult.Yes Then
                            bt_create_draft.PerformClick()
                            ClearAll()
                        ElseIf x = DialogResult.No Then
                            in_kode_draft.Clear()
                            dgv_draftfaktur.Rows.Clear()
                            dgv_draftfaktur.Refresh()
                        ElseIf x = DialogResult.Cancel Then
                            Exit Sub
                        End If
                    End If
                ElseIf printedstat = 1 Then
                    If MessageBox.Show("Buat draft tagihan baru utk sales a.n. " & .Cells("sales_nama").Value & "?", "Draft Tagihan", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                        ClearAll()
                    Else
                        Exit Sub
                    End If
                End If

                dgv_draftfaktur.Rows.Clear()
                dgv_draftfaktur.Refresh()
                in_sales.Text = .Cells("sales_kode").Value
                in_sales_n.Text = .Cells("sales_nama").Value
            End With
        End If
        loadFaktur(in_sales.Text, in_cari_faktur.Text)
    End Sub

    Private Sub bt_remsales_Click(sender As Object, e As EventArgs) Handles bt_remsales.Click
        If printedstat = 0 Then
            If dgv_draftfaktur.Rows.Count > 0 Then
                Dim x As DialogResult = MessageBox.Show("Simpan draft tagihan sebelum mengganti sales?", "Draft Tagihan", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If x = DialogResult.Yes Then
                    bt_create_draft.PerformClick()
                    ClearAll()
                ElseIf x = DialogResult.No Then
                    dgv_draftfaktur.Rows.Clear()
                    dgv_draftfaktur.Refresh()
                ElseIf x = DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
        ElseIf printedstat = 1 Then
            MessageBox.Show("Tidak dapat mengganti sales pada draft yg sudah dicetak", "Draft Tagihan")
            Exit Sub
        End If

        dgv_draftfaktur.Rows.Clear()
        dgv_draftfaktur.Refresh()
        in_sales.Clear()
        in_sales_n.Clear()
        loadFaktur(in_sales.Text, in_cari_faktur.Text)
    End Sub

    '--------------- ADD FAKTUR
    Private Sub dgv_listfaktur_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listfaktur.CellDoubleClick
        If e.RowIndex > -1 Then
            bt_addfaktur.PerformClick()
        End If
    End Sub

    Private Sub bt_addfaktur_Click(sender As Object, e As EventArgs) Handles bt_addfaktur.Click
        'If printedstat <> 0 Then
        '    Exit Sub
        'End If

        With dgv_listfaktur
            For Each selected As DataGridViewRow In .SelectedRows
                For Each rows As DataGridViewRow In dgv_draftfaktur.Rows
                    If rows.Cells("draft_faktur").Value = selected.Cells("list_faktur").Value Then
                        Exit Sub
                    End If
                Next

                dgv_draftfaktur.Rows.Add(selected.Cells("list_custo").Value, selected.Cells("list_faktur").Value, selected.Cells("list_sisa").Value,
                                         selected.Cells("list_sales").Value)
            Next
        End With
    End Sub

    Private Sub bt_remfaktur_Click(sender As Object, e As EventArgs) Handles bt_remfaktur.Click
        With dgv_draftfaktur
            If MessageBox.Show("Hapus Faktur?", "Draft Tagihan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                For Each selected As DataGridViewRow In .SelectedRows
                    .Rows.RemoveAt(selected.Index)
                Next
                If bt_create_draft.Enabled = False Then
                    bt_create_draft.Enabled = True
                End If
            End If
        End With
    End Sub

    Private Sub dgv_draftfaktur_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_draftfaktur.CellDoubleClick
        If e.RowIndex > -1 Then
            bt_remfaktur.PerformClick()
        End If
    End Sub

    '------------ SAVE DRAFT
    Private Sub bt_create_draft_Click(sender As Object, e As EventArgs) Handles bt_create_draft.Click
        If in_sales.Text = Nothing Then
            MessageBox.Show("Salesman belum di input")
            Exit Sub
        End If

        If dgv_draftfaktur.Rows.Count = 0 Then
            MessageBox.Show("Faktur tertagih belum di input")
            Exit Sub
        End If

        If createDraft() = True Then
            MessageBox.Show("Draft Rekap Saved")
            loadDraftList("")
            bt_create_draft.Enabled = False
        Else
            MessageBox.Show("Error has been occured when inputing data")
            bt_create_draft.Enabled = True
        End If
    End Sub

    '--------- LOAD DRAFT
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

    '-------------CETAK DRAFT
    Private Sub bt_draft_nota_Click(sender As Object, e As EventArgs) Handles bt_draft_nota.Click
        If in_kode_draft.Text = Nothing Then
            MessageBox.Show("Input/Pilih draft tagihan yang akan dicetak terlebih dahulu.", "Rekap Salesman", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If printedstat = 0 Then
            Using draftbarang As New fr_draft_tagihan_view
                With draftbarang
                    .setHeader(in_kode_draft.Text, date_tgl_trans.Value.ToString("dd-MMMM-yyyy"))
                    .ShowDialog()
                    If .printing = 1 Then
                        printedstat = 1
                        lbl_statprint.Visible = True
                        op_con()
                        commnd("UPDATE data_tagihan_faktur SET draft_printstatus=1 WHERE draft_kode='" & in_kode_draft.Text & "'")
                    End If
                End With
            End Using
        End If
    End Sub

    Private Sub in_kecamatan_KeyUp(sender As Object, e As KeyEventArgs) Handles in_pasar.KeyUp, in_kecamatan.KeyUp, in_kabupaten.KeyUp
        If e.KeyCode = Keys.Enter Then
            sender.Text = Trim(sender.Text)
            loadFaktur(in_sales.Text, in_cari_faktur.Text)
        End If
    End Sub

    Private Sub DraftBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DraftBarangToolStripMenuItem.Click
        bt_draft_nota.PerformClick()
    End Sub
End Class
