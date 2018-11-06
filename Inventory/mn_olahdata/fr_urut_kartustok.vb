Public Class fr_urut_kartustok
    Public tabpagename As TabPage
    Private brgrowindex As Integer = 0
    Private gdgrowindex As Integer = 0
    Private stokrowindex As Integer = 0

    Public Sub setpage(page As TabPage)
        tabpagename = page
        Console.WriteLine("pg" & page.Name.ToString)
        Console.WriteLine("pgset" & tabpagename.Name.ToString)
    End Sub

    Public Sub performRefresh()
        clearAll()
        loadGudang()
        loadbarang("")
    End Sub

    Private Sub loadGudang(Optional param As String = "")
        Dim bs As New BindingSource

        bs.DataSource = getDataTablefromDB("SELECT gudang_kode as kode, gudang_nama as nama FROM data_barang_gudang WHERE gudang_status=1")
        bs.Filter = "kode LIKE '" & param & "%' OR nama LIKE '" & param & "%'"

        dgv_gudang.DataSource = bs
        brgrowindex = 0
    End Sub

    Private Sub loadbarang(gudang As String, Optional param As String = "")
        Dim bs As New BindingSource
        Dim q As String = "SELECT stock_barang as kode, barang_nama as nama " _
                          & "FROM data_stok_awal LEFT JOIN data_barang_master ON barang_kode=stock_barang " _
                          & "WHERE stock_gudang='" & gudang & "' AND stock_periode='" & selectperiode.id & "' AND stock_status=1"

        bs.DataSource = getDataTablefromDB(q)
        bs.Filter = "kode LIKE '" & param & "%' OR nama LIKE '" & param & "%'"

        dgv_barang.DataSource = bs
        gdgrowindex = 0
    End Sub

    Private Sub loadKartuStok(barang As String, gudang As String)
        Dim dt As New DataTable
        Dim q As String = "getDataKartuStok('{0}','{1}','{2}')"
        Dim kode As String = gudang & "-" & barang & "-" & selectperiode.id

        in_kode_stok.Text = kode
        readcommd("SELECT gudang_nama FROM data_barang_gudang WHERE gudang_kode='" & gudang & "'")
        If rd.HasRows Then
            in_gudang_n.Text = rd.Item("gudang_nama")
        End If
        rd.Close()
        readcommd("SELECT barang_nama FROM data_barang_master WHERE barang_kode='" & barang & "'")
        If rd.HasRows Then
            in_barang_n.Text = rd.Item("barang_nama")
        End If
        rd.Close()

        q = String.Format(q, selectperiode.id, barang, gudang)
        Console.WriteLine(q)
        dt = getDataTablefromDB(q)
        With dgv_kartustok.Rows
            .Clear()
            For Each x As DataRow In dt.Rows
                Dim y As Integer = .Add
                With .Item(y)
                    .Cells("kartu_tgl").Value = x.ItemArray(3)
                    .Cells("kartu_faktur").Value = x.ItemArray(8)
                    .Cells("kartu_ket").Value = x.ItemArray(9)
                    .Cells("kartu_ket2").Value = x.ItemArray(10)
                    .Cells("kartu_debet").Value = x.ItemArray(11)
                    .Cells("kartu_kredit").Value = x.ItemArray(12)
                    .Cells("kartu_saldo").Value = x.ItemArray(13)
                End With
            Next
        End With
    End Sub

    Private Sub saveKartustok()
        Dim q As String = "UPDATE data_stok_kartustok SET {0} WHERE trans_stock='{1}' AND trans_faktur='{2}'"
        Dim data1 As String()
        Dim queryArr As New List(Of String)
        Dim queryChk As Boolean = False

        op_con()
        For Each rows As DataGridViewRow In dgv_kartustok.Rows
            Dim index As Integer = rows.Index
            Dim tgl As String = rows.Cells("kartu_tgl").Value
            data1 = {
                "trans_index='" & index & "'",
                "trans_tgl='" & tgl & "'"
                }
            queryArr.Add(String.Format(q, String.Join(",", data1), in_kode_stok.Text, rows.Cells("kartu_faktur").Value))
        Next

        queryChk = startTrans(queryArr)

        If queryChk = False Then
            MessageBox.Show("data tidak dapat disimpan")
        Else
            MessageBox.Show("data tersimpan")
        End If
    End Sub

    Private Sub countSaldoKartu(idx As Integer, idx2 As Integer)
        If idx > 0 And idx2 > 0 Then
            For Each x As Integer In {idx, idx2}
                With dgv_kartustok
                    Dim saldo As Integer = .Rows(x - 1).Cells("kartu_saldo").Value + .Rows(x).Cells("kartu_debet").Value - .Rows(x).Cells("kartu_kredit").Value
                    .Rows(x).Cells("kartu_saldo").Value = saldo
                End With
            Next
        End If
    End Sub

    Private Sub setBTkartustok()
        If stokrowindex = 0 Or (stokrowindex = 1 And stokrowindex = dgv_kartustok.Rows.Count - 1) Then
            bt_up.Enabled = False
            bt_down.Enabled = False
        ElseIf stokrowindex = 1 Then
            bt_up.Enabled = False
            bt_down.Enabled = True
        ElseIf stokrowindex = dgv_kartustok.Rows.Count - 1 Then
            bt_up.Enabled = True
            bt_down.Enabled = False
        Else
            bt_up.Enabled = True
            bt_down.Enabled = True
        End If
    End Sub

    Private Sub clearAll()
        Dim x As TextBox() = {in_cari_barang, in_cari_gudang, in_kode_stok, in_barang_n, in_gudang_n}
        For Each text As TextBox In x
            text.Clear()
        Next
        dgv_kartustok.Rows.Clear()
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

    '------------------ MENU
    Private Sub mn_refresh_Click(sender As Object, e As EventArgs) Handles mn_refresh.Click
        performRefresh()
    End Sub

    '----------------- load
    Private Sub fr_urut_kartustok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadGudang()

        For Each x As DataGridViewColumn In {kartu_debet, kartu_kredit, kartu_saldo}
            x.DefaultCellStyle = dgvstyle_commathousand
        Next
    End Sub

    '------------------ GUDANG
    Private Sub in_cari_gudang_TextChanged(sender As Object, e As EventArgs) Handles in_cari_gudang.TextChanged
        If in_cari_gudang.Text = "" Then
            loadGudang()
        End If
    End Sub

    Private Sub in_cari_gudang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_cari_gudang.KeyUp
        If e.KeyCode = Keys.Enter Then
            bt_cari_gudang.PerformClick()
        End If
    End Sub

    Private Sub bt_cari_gudang_Click(sender As Object, e As EventArgs) Handles bt_cari_gudang.Click
        in_cari_gudang.Text = Trim(in_cari_gudang.Text)
        If in_cari_gudang.Text <> Nothing Then
            loadGudang(in_cari_gudang.Text)
        End If
    End Sub

    Private Sub dgv_gudang_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_gudang.CellEnter
        gdgrowindex = e.RowIndex
    End Sub

    Private Sub dgv_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_gudang.KeyDown
        If e.KeyCode = Keys.Enter Then
            loadbarang(dgv_gudang.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    Private Sub dgv_gudang_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_gudang.CellClick
        If e.RowIndex > -1 Then
            gdgrowindex = e.RowIndex
            loadbarang(dgv_gudang.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    '-------------- BARANG
    Private Sub bt_cari_barang_Click(sender As Object, e As EventArgs) Handles bt_cari_barang.Click
        in_cari_barang.Text = Trim(in_cari_barang.Text)
        If in_cari_barang.Text <> Nothing Then
            loadbarang(dgv_gudang.SelectedRows.Item(0).Cells(0).Value, in_cari_barang.Text)
        End If
    End Sub

    Private Sub in_cari_barang_KeyUp(sender As Object, e As KeyEventArgs) Handles in_cari_barang.KeyUp
        If e.KeyCode = Keys.Enter Then
            bt_cari_barang.PerformClick()
        End If
    End Sub

    Private Sub dgv_barang_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellEnter
        brgrowindex = e.RowIndex
    End Sub

    Private Sub dgv_barang_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_barang.CellClick
        If e.RowIndex > -1 Then
            brgrowindex = e.RowIndex

        End If
    End Sub

    Private Sub dgv_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_barang.KeyDown
        If e.KeyCode = Keys.Enter Then
            bt_load_kartu.PerformClick()
        End If
    End Sub

    '-------------- LOAD KARTU STOK
    Private Sub bt_load_kartu_Click(sender As Object, e As EventArgs) Handles bt_load_kartu.Click
        If dgv_barang.Rows.Count > 0 Then
            loadKartuStok(dgv_barang.SelectedRows.Item(0).Cells("brg_kode").Value, dgv_gudang.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    '------------- KARTU STOK
    Private Sub dgv_kartustok_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_kartustok.CellEnter
        If e.RowIndex > -1 Then
            stokrowindex = e.RowIndex
            setBTkartustok()
        End If
    End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_up.Click, bt_down.Click
        Dim btn As Button = DirectCast(sender, Button)
            'Dim DGV As DataGridView = DirectCast(Me.Controls("DGV1"), DataGridView)
        If dgv_kartustok.SelectedRows.Count > 0 Then
            Dim dragRow As DataGridViewRow = dgv_kartustok.SelectedRows(0).Clone
            Dim index1 As Integer = dgv_kartustok.SelectedRows(0).Index
            For i As Integer = 0 To dragRow.Cells.Count - 1
                dragRow.Cells(i).Value = dgv_kartustok.SelectedRows(0).Cells(i).Value
            Next
            dgv_kartustok.Rows.RemoveAt(index1)
            Select Case btn.Name
                Case "bt_up"
                    dgv_kartustok.Rows.Insert(index1 - 1, dragRow)
                    stokrowindex = index1 - 1
                    countSaldoKartu(index1 - 1, index1)
                Case "bt_down"
                    dgv_kartustok.Rows.Insert(index1 + 1, dragRow)
                    stokrowindex = index1 + 1
                    countSaldoKartu(index1, index1 + 1)
            End Select
            dragRow.Selected = True
            setBTkartustok()
        End If
    End Sub

    Private Sub bt_save_Click(sender As Object, e As EventArgs) Handles bt_save.Click
        saveKartustok()
    End Sub
End Class
