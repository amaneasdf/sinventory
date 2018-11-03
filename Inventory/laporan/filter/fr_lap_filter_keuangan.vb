Public Class fr_lap_filter_keuangan
    Private popupstate As String = "supplier"
    Private lapwintext As String = ""
    Public laptype As String
    Public sales_sw As String = "ON"
    Public akun_sw As Boolean = True
    Public tgltrans_sw As Boolean = True
    Public periode_sw As Boolean = False

    Private Sub prcessSW()
        'SALES
        If sales_sw = "OFF" Then
            lbl_sales.Visible = False
            in_sales.Visible = False
            in_sales_n.Visible = False
        ElseIf sales_sw = "ON" Or sales_sw = "JENISCUSTO" Then
            lbl_sales.Visible = True
            in_sales.Visible = True
            in_sales_n.Visible = True
            If sales_sw = "JENISCUSTO" Then
                lbl_sales.Text = "Jenis"
            End If
        End If

        'TGL
        lbl_tgl.Visible = tgltrans_sw
        lbl_tgl2.Visible = tgltrans_sw
        date_tglawal.Visible = tgltrans_sw
        date_tglakhir.Visible = tgltrans_sw

        'periode
        cb_periode.Visible = periode_sw
        lbl_periode.Visible = periode_sw

        'akun
        lbl_akun.Visible = akun_sw
        in_akun.Visible = akun_sw
        in_akun_n.Visible = akun_sw

        'End If

        Me.Text = lapwintext
    End Sub

    Private Sub formSW(tipe As String)
        Select Case tipe
            Case "k_biayasales"
                prcessSW()

            Case "k_biayasales_global"
                prcessSW()

                date_tglawal.Enabled = False
                date_tglakhir.Enabled = False

            Case "k_bukubesar"
                sales_sw = "OFF"
                prcessSW()

                date_tglawal.Enabled = False
                date_tglakhir.Enabled = False

        End Select
    End Sub
    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "sales"
                q = "SELECT salesman_kode AS 'Kode', salesman_nama AS 'Nama' FROM data_salesman_master WHERE salesman_status=1 AND salesman_nama LIKE '{0}%'"
            Case "akun"
                If laptype = "k_biayasales" Or laptype = "k_biayasales_global" Then
                    q = "SELECT perk_kode as 'Kode', perk_nama_akun as 'Nama' FROM data_perkiraan WHERE perk_status=1 " _
                        & "AND LEFT(perk_tipe,1)='4' AND perk_nama_akun LIKE '{0}%'"
                Else
                    q = "SELECT perk_kode as 'Kode', perk_nama_akun as 'Nama' FROM data_perkiraan WHERE perk_status=1 AND perk_nama_akun LIKE '{0}%'"
                End If
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
                Case "sales"
                    in_sales.Text = .Cells(0).Value
                    in_sales_n.Text = .Cells(1).Value
                    'If faktur_sw = True Then in_faktur.Focus() Else bt_simpanbeli.Focus()
                Case "akun"
                    in_akun.Text = .Cells(0).Value
                    in_akun_n.Text = .Cells(1).Value

                Case Else
                    Exit Sub
            End Select
        End With
        popPnl_barang.Visible = False
    End Sub

    Private Function createQuery(tipe As String) As String
        Dim q As String = ""
        Dim qwh As String = ""
        Dim qreturn As String = ""
        Dim qbiaya As String = "SELECT {4}kas_sales as b_sales, salesman_nama as b_sales_n, " _
                               & "k_trans_rek as b_akun,perk_nama_akun as b_akun_n, SUM(k_trans_debet) as b_saldo " _
                               & "FROM data_kas_faktur " _
                               & "LEFT JOIN data_kas_trans ON kas_kode=k_trans_faktur AND k_trans_status=1 AND k_trans_rek LIKE '4%' " _
                               & "LEFT JOIN data_perkiraan ON k_trans_rek=perk_kode " _
                               & "LEFT JOIN data_salesman_master ON salesman_kode=kas_sales " _
                               & "WHERE kas_status=1 AND kas_tgl BETWEEN '{0}' AND '{1}' {2} GROUP BY {3}kas_sales,k_trans_rek"

        Select Case tipe
            Case "k_biayasales"
                q = String.Format(qbiaya, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}",
                                  "kas_tgl,", "kas_tgl as b_tgl,")

                If in_sales.Text <> Nothing Then
                    qwh += "AND salesman_kode='" & in_sales.Text & "'"
                End If
                If in_akun.Text <> Nothing Then
                    qwh += "AND perk_kode='" & in_akun.Text & "'"
                End If
            Case "k_biayasales_global"
                q = String.Format(qbiaya, date_tglawal.Value.ToString("yyyy-MM-dd"), date_tglakhir.Value.ToString("yyyy-MM-dd"), "{0}",
                                  "", "")

                If in_sales.Text <> Nothing Then
                    qwh += "AND salesman_kode='" & in_sales.Text & "'"
                End If
                If in_akun.Text <> Nothing Then
                    qwh += "AND perk_kode='" & in_akun.Text & "'"
                End If

            Case "k_bukubesar"

        End Select

        qreturn = String.Format(q, qwh)
        consoleWriteLine(qreturn)

        Return qreturn
    End Function

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

        With cb_periode
            .DataSource = jenis("periode")
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedValue = selectperiode.id
        End With
        date_tglawal.Value = selectperiode.tglawal
        date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)

        lbl_periodedata.Text = main.strip_periode.Text
        formSW(tipeLap)
        'prcessSW()
    End Sub

    Private Sub fr_lap_filter_hutang_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'LOAD LAPORAN
    Private Sub bt_simpanbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanbeli.Click
        Dim x As New fr_lap_keuangan With {
                    .Text = lapwintext
                }
        Dim header As String = ""

        If date_tglakhir.Value.ToString("MMyyyy") = date_tglawal.Value.ToString("MMyyyy") Then
            header = date_tglawal.Value.ToString("MMMM yyyy")
        Else
            header = date_tglawal.Value.ToString("dd/MM/yyyy") & " S.d " & date_tglakhir.Value.ToString("dd/MM/yyyy")
        End If

        x.setVar(laptype, createQuery(laptype), header)
        x.do_load()
        x.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_exportxl.Click

    End Sub

    'UI
    Private Sub fr_hutang_bayar_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        If popPnl_barang.Visible = True Then
            popPnl_barang.Visible = False
        End If
    End Sub

    '------------- POPUPSEARCH PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_sales_n.Focused Or in_akun_n.Focused Then
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
                Case "sales"
                    x = in_sales_n
                Case "akun"
                    x = in_akun_n
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

    Private Sub cb_jenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_periode.KeyPress
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    Private Sub date_tglawal_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglawal.KeyUp
        keyshortenter(date_tglakhir, e)
    End Sub

    Private Sub date_tglawal_ValueChanged(sender As Object, e As EventArgs) Handles date_tglawal.ValueChanged
        date_tglakhir.MinDate = date_tglawal.Value
    End Sub

    Private Sub date_tglakhir_KeyUp(sender As Object, e As KeyEventArgs) Handles date_tglakhir.KeyUp
        'keyshortenter(in_sales_n, e)
    End Sub

    Private Sub date_tglakhir_ValueChanged(sender As Object, e As EventArgs) Handles date_tglakhir.ValueChanged
        date_tglawal.MaxDate = date_tglakhir.Value
    End Sub

    Private Sub cb_periode_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_periode.SelectionChangeCommitted
        'readcommd("SELECT tutupbk_periode_tglawal, tutupbk_periode_tglakhir FROM data_tutup_buku WHERE tutupbk_status=1 AND tutupbk_id='" & cb_periode.SelectedValue & "'")
        'If rd.HasRows Then
        '    'date_tglawal.MaxDate = rd.Item(1)
        '    'date_tglawal.MinDate = rd.Item(0)
        '    'date_tglakhir.MaxDate = rd.Item(1)
        '    'date_tglakhir.MinDate = rd.Item(0)
        '    date_tglawal.Value = rd.Item(0)
        '    date_tglakhir.Value = rd.Item(1)
        'End If
        'rd.Close()

        'date_tglakhir.Value = IIf(selectperiode.tglakhir > Today, Today, selectperiode.tglakhir)
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales.KeyDown
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_supplier_n_Enter(sender As Object, e As EventArgs) Handles in_sales_n.Enter
        popPnl_barang.Location = New Point(in_sales_n.Left, in_sales_n.Top + in_sales_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "sales"
        loadDataBRGPopup("sales", in_sales_n.Text)
    End Sub

    Private Sub in_supplier_n_Leave(sender As Object, e As EventArgs) Handles in_sales_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_supplier_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_sales_n.KeyUp
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
            loadDataBRGPopup("sales", in_sales_n.Text)
        End If
    End Sub

    Private Sub in_supplier_n_TextChanged(sender As Object, e As EventArgs) Handles in_sales_n.TextChanged
        If in_sales_n.Text = "" Then
            in_sales.Clear()
            'AND OTHER STUFF
        End If
    End Sub

    Private Sub in_akun_KeyDown(sender As Object, e As KeyEventArgs) Handles in_akun.KeyDown
        keyshortenter(in_sales_n, e)
    End Sub

    Private Sub in_akun_n_Enter(sender As Object, e As EventArgs) Handles in_akun_n.Enter
        popPnl_barang.Location = New Point(in_akun_n.Left, in_akun_n.Top + in_akun_n.Height)
        If popPnl_barang.Visible = False Then
            popPnl_barang.Visible = True
        End If
        popupstate = "akun"
        loadDataBRGPopup("akun", in_akun_n.Text)
    End Sub

    Private Sub in_akun_n_Leave(sender As Object, e As EventArgs) Handles in_akun_n.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_akun_n_KeyUp(sender As Object, e As KeyEventArgs) Handles in_akun_n.KeyUp
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
            loadDataBRGPopup("akun", in_akun_n.Text)
        End If
    End Sub

    Private Sub in_akun_n_TextChanged(sender As Object, e As EventArgs) Handles in_akun_n.TextChanged
        If in_akun_n.Text = "" Then
            in_akun.Clear()
            'AND OTHER STUFF
        End If
    End Sub

End Class