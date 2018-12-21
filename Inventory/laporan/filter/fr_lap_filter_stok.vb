Public Class fr_lap_filter_stok
    Private popupstate As String = "gudang"
    Private lapwintext As String = ""
    Public laptype As String
    Public supplier_sw As Boolean = False
    Public barang_sw As Boolean = True
    Public gudang_sw As Boolean = True

    Private Sub prcessSW()
        'If supplier_sw = False Then
        lbl_supplier.Visible = supplier_sw
        in_supplier.Visible = supplier_sw
        in_supplier_n.Visible = supplier_sw
        'End If
        'If jenis_sw = False Then
        lbl_gudang.Visible = gudang_sw
        in_gudang.Visible = gudang_sw
        in_gudang_n.Visible = gudang_sw
        'End If
        'If barang_sw = False Then
        lbl_barang.Visible = barang_sw
        in_barang.Visible = barang_sw
        in_barang_n.Visible = barang_sw
        'End If

        Me.Text = lapwintext
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "supplier"
                q = "SELECT supplier_kode AS 'Kode', supplier_nama AS 'Nama' FROM data_supplier_master WHERE supplier_status=1 AND supplier_nama LIKE '{0}%'"
            Case "barang"
                q = "SELECT barang_kode as 'Kode', barang_nama as 'Nama' FROM data_stok_awal " _
                    & "LEFT JOIN data_barang_master ON barang_kode=stock_barang WHERE stock_status=1 " _
                    & "AND stock_gudang LIKE '{0}' AND barang_nama LIKE '{2}%' AND stock_periode='{1}' " _
                    & "GROUP BY barang_kode"
                If in_gudang.Text <> Nothing Then
                    q = String.Format(q, in_gudang.Text, selectperiode.id, "{0}")
                Else
                    q = String.Format(q, "%", selectperiode.id, "{0}")
                End If
            Case "gudang"
                q = "SELECT gudang_kode as 'Kode', gudang_nama as 'Nama' FROM data_barang_gudang WHERE gudang_status=1 AND gudang_nama LIKE '{0}%'"
            Case Else
                Exit Sub
        End Select
        consoleWriteLine(String.Format(q, param))
        dt = getDataTablefromDB(String.Format(q, param))

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 135
            .Columns(1).Width = 200
        End With
    End Sub

    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popupstate
                Case "supplier"
                    in_supplier.Text = .Cells(0).Value
                    in_supplier_n.Text = .Cells(1).Value
                    bt_simpanbeli.Focus()
                Case "barang"
                    in_barang.Text = .Cells(0).Value
                    in_barang_n.Text = .Cells(1).Value
                    bt_simpanbeli.Focus()
                Case "gudang"
                    in_gudang.Text = .Cells(0).Value
                    in_gudang_n.Text = .Cells(1).Value
                    in_barang_n.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
        'popPnl_barang.Visible = False
    End Sub

    Private Function createQuery(tipe As String) As String
        Dim q As String = ""
        Dim qwh As String = ""
        Dim qreturn As String = ""
        Dim qpersed As String = "SELECT stock_gudang, gudang_nama as stock_gudang_n, stock_barang, barang_nama as stocK_barang_n, " _
                                & "barang_supplier as stock_supplier, supplier_nama As stock_supplier_n," _
                                & "stock_qty, getQTYdetail(stock_barang, stock_qty, 1) as stock_qty_n, stock_hpp " _
                                & "FROM( " _
                                & " SELECT stock_kode, stock_barang, stock_gudang, " _
                                & "  getSisaStock('{0}',stock_barang,stock_gudang) as stock_qty, " _
                                & "	 getHPPAVG(stock_barang,'{1}','{0}') as stock_hpp " _
                                & "	FROM data_stok_awal " _
                                & "	WHERE stock_status=1 " _
                                & ") stok LEFT JOIN data_barang_master ON stock_barang=barang_kode " _
                                & "LEFT JOIN data_barang_gudang ON stock_gudang=gudang_kode " _
                                & "LEFT JOIN data_supplier_master ON barang_supplier=supplier_kode {2} " _
                                & "ORDER BY barang_kode"

        Select Case tipe
            Case "lapKartuStok"
                q = "getDataKartuStok('{0}','{1}','{2}')"
                q = String.Format(q, selectperiode.id, IIf(in_barang.Text = Nothing, "all", in_barang.Text), IIf(in_gudang.Text = Nothing, "all", in_gudang.Text))

            Case "lapPersediaan", "lapStok", "lapStokSupplier"
                q = qpersed
                q = String.Format(q, selectperiode.id, date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}")

                Dim whr As New List(Of String)
                If in_gudang.Text <> Nothing Or in_barang.Text <> Nothing Or in_supplier.Text <> Nothing Then
                    qwh += "WHERE {0}"
                End If
                If in_gudang.Text <> Nothing Then
                    whr.Add("stock_gudang='" & in_gudang.Text & "'")
                End If
                If in_barang.Text <> Nothing Then
                    whr.Add("stock_barang='" & in_barang.Text & "'")
                End If
                If in_supplier.Text <> Nothing Then
                    whr.Add("barang_supplier='" & in_supplier.Text & "'")
                End If

                qwh = String.Format(qwh, String.Join(" AND ", whr))

            Case "lapStokMutasi", "lapPersediaanMutasi"
                q = "getDataPersediaan('{0}','{1}','{2}')"
                q = String.Format(q, selectperiode.id, IIf(in_barang.Text = Nothing, "all", in_barang.Text), IIf(in_gudang.Text = Nothing, "all", in_gudang.Text))
        End Select

        qreturn = String.Format(q, qwh)
        consoleWriteLine(qreturn)

        Return qreturn
    End Function

    Private Sub exportData(type As String)
        Dim q As String = createQuery(type)
        Dim _dt As New DataTable
        Dim _colheader As New List(Of String)
        Dim _outputdir As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\SIMInvent\"
        Dim _filename As String = "dataexport" & Today.ToString("yyyyMMdd")
        Dim _respond As Boolean = False
        Dim _svdialog As New SaveFileDialog
        Dim _title As String = ""

        MyBase.Cursor = Cursors.AppStarting

        Select Case type
            Case "lapKartuStok"
                '_colheader.AddRange({"Kode Gudang", "Nama Gudang", "Kode Barang", "Nama Barang", "Tgl.Transaksi", "Tgl.Jatuh Tempo", "Faktur", "Saldo Awal", "Pembayaran", "Retur", "Sisa"})
                '_title = "Kartu Stok"
                '_filename = "BiayaSales" & Today.ToString("yyyyMMdd") & ".xlsx"

            Case Else

        End Select

    End Sub

    'DRAG FORM
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, lbl_title.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, lbl_title.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, lbl_title.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick, lbl_title.DoubleClick
        CenterToScreen()
    End Sub

    'CLOSE
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbeli.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbeli.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    'LOAD
    Private Sub fr_lap_filter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub do_load(judulLap As String, tipeLap As String)
        laptype = tipeLap
        lapwintext = judulLap

        date_tglawal.Value = selectperiode.tglawal
        date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)

        prcessSW()
        lbl_periodedata.Text = main.strip_periode.Text
    End Sub

    'LOAD LAPORAN
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        Dim x As New fr_lap_stock_view With {
                    .Text = lapwintext
                }
        Dim header As String = ""
        If date_tglawal.Value.Month = date_tglakhir.Value.Month And date_tglawal.Value.Year = date_tglakhir.Value.Year Then
            header = "Periode " & selectperiode.tglawal.ToString("MMMM yyyy")
        Else
            header = "Periode " & date_tglawal.Value.ToString("dd/MM/yyyy") & " s.d. " & date_tglakhir.Value.ToString("dd/MM/yyyy")
        End If
        x.setVar(laptype, createQuery(laptype), header)
        x.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_exportxl.Click
        MessageBox.Show("Under Construction")
    End Sub

    'UI
    '------------- POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_supplier_n.Focused Or in_barang_n.Focused Or in_gudang_n.Focused Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub dgv_listbarang_CellContentDBLClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listbarang.CellDoubleClick
        If e.RowIndex >= 0 Then
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keydown(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            Dim x As TextBox
            Select Case popupstate
                Case "supplier"
                    x = in_supplier_n
                Case "barang"
                    x = in_barang_n
                Case "gudang"
                    x = in_gudang_n
                Case Else
                    x = Nothing
                    x.Dispose()
                    Exit Sub
            End Select
            x.Text += e.KeyChar
            e.Handled = True
            x.Focus()
            x.Select(x.TextLength, x.TextLength)
        End If
    End Sub

    Private Sub date_tglawal_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglawal.KeyUp
        keyshortenter(date_tglakhir, e)
    End Sub

    Private Sub date_tglawal_ValueChanged(sender As Object, e As EventArgs) Handles date_tglawal.ValueChanged
        date_tglakhir.MinDate = date_tglawal.Value
    End Sub

    Private Sub date_tglakhir_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglakhir.KeyUp
        keyshortenter(bt_simpanbeli, e)
    End Sub

    Private Sub date_tglakhir_ValueChanged(sender As Object, e As EventArgs) Handles date_tglakhir.ValueChanged
        date_tglawal.MaxDate = date_tglakhir.Value
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        keyshortenter(in_supplier_n, e)
    End Sub

    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_supplier_n.Enter
        popPnl_barang.Location = New Point(in_supplier_n.Left, in_supplier_n.Top + in_supplier_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "supplier"
        loadDataBRGPopup("supplier", in_supplier_n.Text)
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_supplier_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_supplier_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(bt_simpanbeli, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("supplier", in_supplier_n.Text)
        End If
    End Sub

    Private Sub in_supplier_n_TextChanged(sender As Object, e As EventArgs) Handles in_supplier_n.TextChanged
        If in_supplier_n.Text = "" Then
            in_supplier.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        keyshortenter(in_barang_n, e)
    End Sub

    Private Sub in_barang_n_Enter(sender As Object, e As EventArgs) Handles in_barang_n.Enter
        popPnl_barang.Location = New Point(in_barang_n.Left, in_barang_n.Top + in_barang_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "barang"
        loadDataBRGPopup("barang", in_barang_n.Text)
    End Sub

    Private Sub in_barang_n_Leave(sender As Object, e As EventArgs) Handles in_barang_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_barang_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_barang_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(bt_simpanbeli, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("barang", in_barang_n.Text)
        End If
    End Sub

    Private Sub in_barang_n_TextChanged(sender As Object, e As EventArgs) Handles in_barang_n.TextChanged
        If in_barang_n.Text = "" Then
            in_barang.Clear()
            'AND OTHER STUFF
        End If
    End Sub
    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_gudang_n_Enter(sender As Object, e As EventArgs) Handles in_gudang_n.Enter
        popPnl_barang.Location = New Point(in_gudang_n.Left, in_gudang_n.Top + in_gudang_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "gudang"
        loadDataBRGPopup("gudang", in_gudang_n.Text)
    End Sub

    Private Sub in_gudang_n_Leave(sender As Object, e As EventArgs) Handles in_gudang_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_gudang_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(bt_simpanbeli, e)
        Else
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            loadDataBRGPopup("gudang", in_gudang_n.Text)
        End If
    End Sub

    Private Sub in_gudang_n_TextChanged(sender As Object, e As EventArgs) Handles in_gudang_n.TextChanged
        If in_gudang_n.Text = "" Then
            in_gudang.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub fr_hutang_bayar_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub
End Class