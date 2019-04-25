Public Class fr_stockop_list
    Private Structure menu_sw
        Dim sw As Boolean
        Dim txt As String
    End Structure

    Public tabpagename As TabPage
    Private rowindex As Integer = 0
    Private rowindexlist As Integer = 0
    Private rowindexbarang As Integer = 0
    Private tblStatus As String = 0
    Private popupstate As String = "gudang"
    Private _hppsys As Decimal = 0
    Private dgvallowed As Boolean = False

    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Blank
        Insert
        Edit
        View
    End Enum

    'FUCKING SPAGHETTI CODE, FUCK

    'SET TAB PAGE
    Public Sub setpage(page As TabPage)
        tabpagename = page
    End Sub

    'REFRESH PAGE
    Public Sub performRefresh()
        in_cari.Clear()
        searchData("")
        in_countdata.Text = dgv_list.Rows.Count
        If selectperiode.closed = True Then
            mn_tambah.Enabled = False
            mn_proses.Enabled = False
        End If
    End Sub

    'LOAD DATA
    Private Sub loadData(NoFaktur As String)
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main DB Connection is empty")
        End If
        Dim q As String = ""
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT faktur_bukti, IFNULL(pajak.ref_text,'ERROR') faktur_kat, faktur_tanggal, faktur_gudang, gudang_nama, faktur_status, " _
                    & "IFNULL(DATE_FORMAT(faktur_reg_date,'%d/%m/%Y %H:%i:%S'),'') faktur_reg_date, IFNULL(faktur_reg_alias,'') faktur_reg_alias, " _
                    & "IFNULL(DATE_FORMAT(faktur_upd_date,'%d/%m/%Y %H:%i:%S'),'') faktur_upd_date, IFNULL(faktur_upd_alias,'') faktur_upd_alias, " _
                    & "IFNULL(DATE_FORMAT(faktur_proc_date,'%d/%m/%Y %H:%i:%S'),'') faktur_proc_date, IFNULL(faktur_proc_alias,'') faktur_proc_alias " _
                    & "FROM data_stok_opname " _
                    & "LEFT JOIN data_barang_gudang ON gudang_kode=faktur_gudang " _
                    & "LEFT JOIN ref_jenis pajak ON faktur_pajak=pajak.ref_kode AND pajak.ref_status=1 AND pajak.ref_type='ppn_trans2' " _
                    & "WHERE faktur_bukti='{0}'"
                Using rdx = x.ReadCommand(String.Format(q, NoFaktur))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_kode.Text = rdx.Item("faktur_bukti")
                        in_kat.Text = rdx.Item("faktur_kat")
                        date_tgl_beli_r.Text = CDate(rdx.Item("faktur_tanggal")).ToLongDateString
                        in_gudang.Text = rdx.Item("faktur_gudang")
                        in_gudang_n.Text = rdx.Item("gudang_nama")
                        tblStatus = rdx.Item("faktur_status")
                        txtRegAlias.Text = rdx.Item("faktur_reg_alias")
                        txtRegdate.Text = rdx.Item("faktur_reg_date")
                        txtUpdDate.Text = rdx.Item("faktur_upd_date")
                        txtUpdAlias.Text = rdx.Item("faktur_upd_alias")
                        txtProcDate.Text = rdx.Item("faktur_proc_date")
                        txtProcAlias.Text = rdx.Item("faktur_proc_alias")
                    End If
                End Using
            End If
            q = "SELECT trans_barang, barang_nama, trans_qty_sys, getQTYDetail(trans_barang,trans_qty_sys,1), trans_satuan, " _
                & "trans_qty_b_fis, trans_sat_b_fis, trans_qty_t_fis, trans_sat_t_fis, trans_qty_k_fis, " _
                & "trans_qty_fisik, trans_hpp, trans_hpp_fisik " _
                & "FROM data_stok_opname_trans LEFT JOIN data_barang_master ON trans_barang=barang_kode " _
                & "WHERE trans_status=1 AND trans_faktur='{0}'"
            Using dt = x.GetDataTable(String.Format(q, NoFaktur))
                With dgv_barang.Rows
                    For Each y As DataRow In dt.Rows
                        Dim i = .Add
                        .Item(i).Cells("kode").Value = y.ItemArray(0)
                        .Item(i).Cells("nama").Value = y.ItemArray(1)
                        .Item(i).Cells("qty_sys").Value = y.ItemArray(2)
                        .Item(i).Cells("qty_n_sys").Value = y.ItemArray(3)
                        .Item(i).Cells("sat_sys").Value = y.ItemArray(4)

                        .Item(i).Cells("qty_fis_b").Value = y.ItemArray(5)
                        .Item(i).Cells("sat_fis_b").Value = y.ItemArray(6)
                        .Item(i).Cells("qty_fis_t").Value = y.ItemArray(7)
                        .Item(i).Cells("sat_fis_t").Value = y.ItemArray(8)
                        .Item(i).Cells("qty_fis_k").Value = y.ItemArray(9)
                        .Item(i).Cells("sat_fis").Value = y.ItemArray(4)

                        .Item(i).Cells("qty_fis").Value = y.ItemArray(10)
                        .Item(i).Cells("qty_sel").Value = y.ItemArray(10) - y.ItemArray(2)
                        .Item(i).Cells("hpp").Value = y.ItemArray(11)
                        .Item(i).Cells("hpp_fis").Value = y.ItemArray(12)
                    Next
                End With
            End Using
            'SET STATUS
            Select Case tblStatus
                Case 0 : in_status.Text = "Pending"
                Case 1 : in_status.Text = "OK"
                Case 2 : in_status.Text = "Batal"
                Case 8 : in_status.Text = "On-Edit/NOT IMPLEMENTED!"
                Case 9 : in_status.Text = "Delete"
                Case Else : Exit Sub
            End Select
            setStatus()
        End Using

    End Sub

    Private Sub setStatus()
        Select Case tblStatus
            Case 0, 1
                mn_proses.Enabled = If(selectperiode.closed = False, If(tblStatus = 1, False, True), False)
                mn_hapus.Enabled = If(selectperiode.closed = False, True, False)
            Case 2, 9
                mn_proses.Enabled = False
                mn_hapus.Enabled = False
            Case Else
                Exit Sub
        End Select
    End Sub

    'SEARCH DATA
    Private Sub searchData(param As String, Optional pass As Boolean = False)
        clearPreview()
        populateDGVUserCon("stockop", param, frmstockop.dgv_list)
    End Sub

    Private Sub listToDetail()
        Try
            Me.Cursor = Cursors.AppStarting
            dgv_barang.Rows.Clear()
            loadData(dgv_list.Rows(rowindex).Cells("kode").Value)
        Catch ex As Exception
            Dim text As String = "Tidak dapat menampilkan data" & Environment.NewLine & ex.Message
            MessageBox.Show(text)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    'CANCEL DATA
    Private Sub cancelData()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim queryCk As Boolean = False
        Dim queryArr As New List(Of String)
        Dim q As String = ""
        Dim _ket As String = ""

        If TransConfirmValid(_ket) Then
            Using x = MainConnection
                x.Open()
                If x.ConnectionState = ConnectionState.Open Then
                    q = "UPDATE data_stok_opname SET faktur_status=2, faktur_ket=TRIM(BOTH '\r\n' FROM CONCAT(faktur_ket,'\r\n','{2}')), " _
                        & "faktur_proc_date =NOW(), faktur_proc_alias='{1}' WHERE faktur_bukti='{0}'"
                    queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id, mysqlQueryFriendlyStringFeed(_ket)))

                    q = "CALL transMutasiOpnameFin('{0}','{1}')"
                    queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id))

                    queryCk = x.TransactCommand(queryArr)
                End If

                If queryCk Then
                    MessageBox.Show("Transaksi opname dibatalkan.", "Stok Opname", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    performRefresh()
                Else
                    MessageBox.Show("Error. Transaksi gagal dibatalkan", "Stok Opname", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End If
    End Sub

    'PROCESS DATA
    Private Sub prosesData()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim queryCk As Boolean = False
        Dim queryArr As New List(Of String)
        Dim q As String = ""
        Dim _confrm As Boolean = False
        Dim _ket As String = ""
        If TransConfirmValid(_ket) Then
            Using x = MainConnection
                x.Open()
                If x.ConnectionState = ConnectionState.Open Then
                    q = "UPDATE data_stok_opname SET faktur_status=1, faktur_ket=TRIM(BOTH '\r\n' FROM CONCAT(faktur_ket,'\r\n','{2}')), " _
                        & "faktur_proc_date =NOW(), faktur_proc_alias='{1}' WHERE faktur_bukti='{0}'"
                    queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id, mysqlQueryFriendlyStringFeed(_ket)))

                    q = "CALL transMutasiOpnameFin('{0}','{1}')"
                    queryArr.Add(String.Format(q, in_kode.Text, loggeduser.user_id))

                    queryCk = x.TransactCommand(queryArr)
                End If

                If queryCk Then
                    MessageBox.Show("Transaksi opname terproses.", "Stok Opname", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    performRefresh()
                Else
                    MessageBox.Show("Error. Transaksi gagal tersimpan", "Stok Opname", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End If
    End Sub

    'CLEAR
    Private Sub clearPreview()
        For Each x As TextBox In {in_kode, in_kat, in_gudang, in_gudang_n, in_status, date_tgl_beli_r}
            x.Clear()
        Next
        dgv_barang.Rows.Clear()
    End Sub

    'UI : CLOSE
    Private Sub bt_close_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_close_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub bt_close_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        clearPreview()
        main.tabcontrol.TabPages.Remove(tabpagename)
        rowindex = 0
    End Sub

    'UI : MENU
    Private Sub mn_tambah_Click(sender As Object, e As EventArgs) Handles mn_tambah.Click
        Dim detail As New fr_stock_op
        detail.doLoadNew()
    End Sub

    Private Sub mn_edit_Click(sender As Object, e As EventArgs) Handles mn_edit.Click
        Dim detail As New fr_stock_op
        If selectperiode.closed = False Then
            If in_kode.Text <> Nothing Then
                detail.doLoadEdit(in_kode.Text, loggeduser.allowedit_transact)
            Else
                detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
            End If
        End If
    End Sub

    Private Sub mn_hapus_Click(sender As Object, e As EventArgs) Handles mn_hapus.Click
        Dim _kode As String = ""
        If in_kode.Text <> Nothing And {0, 1}.Contains(tblStatus) Then
            _kode = in_kode.Text
            If MessageBox.Show("Batalkan Transaksi opname?", "Stok Opname", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                cancelData()
            End If
        End If
    End Sub

    Private Sub mn_proses_Click(sender As Object, e As EventArgs) Handles mn_proses.Click
        Dim _konfirm As Boolean = False
        If Trim(in_kode.Text) <> Nothing And tblStatus = 0 Then
            If MessageBox.Show("Proses Stock Opname No." & in_kode.Text & "?", "Stock Opname", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                prosesData()
            End If
        End If
    End Sub

    Private Sub mn_refresh_Click(sender As Object, e As EventArgs) Handles mn_refresh.Click
        performRefresh()
    End Sub

    Private Sub mn_cari_Click(sender As Object, e As EventArgs) Handles mn_cari.Click
        in_cari.Focus()
    End Sub

    'LOAD
    Private Sub fr_stockop_list_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each x As DataGridViewColumn In {hpp, hpp_fis}
            x.DefaultCellStyle = dgvstyle_currency
        Next
        performRefresh()
    End Sub

    'UI : CARI
    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If dgv_list.Visible = False Then
                dgv_list.Visible = True
            End If
            searchData(in_cari.Text)
        End If
    End Sub

    'UI : DGV
    Private Sub dgv_list_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellClick
        If e.RowIndex >= 0 Then
            listToDetail()
        End If
    End Sub

    Private Sub dgv_list_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_list.KeyDown
        If e.KeyCode = Keys.Enter And rowindex >= 0 Then
            Dim detail As New fr_stok_mutasi_barang
            If selectperiode.closed = False Then
                detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
            Else
                detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
            End If
        End If
    End Sub

    Private Sub dgv_list_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgv_list.RowsAdded
        in_countdata.Text = dgv_list.Rows.Count
    End Sub

    Private Sub dgv_list_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellDoubleClick
        Dim detail As New fr_stok_mutasi_barang
        If selectperiode.closed = False Then
            detail.doLoadEdit(dgv_list.SelectedRows.Item(0).Cells(0).Value, loggeduser.allowedit_transact)
        Else
            detail.doLoadView(dgv_list.SelectedRows.Item(0).Cells(0).Value)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_sidepnl_sw.Click
        With dgv_list
            If .Visible = False Then
                .Visible = True
            Else
                .Visible = False
            End If
        End With
    End Sub
End Class
