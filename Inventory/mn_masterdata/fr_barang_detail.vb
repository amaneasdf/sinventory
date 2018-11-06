Public Class fr_barang_detail
    Private popState As String = "suppier"
    Private brgStatus As String = "1"

    'LOAD DATA BARANG
    Private Sub loadData(kode As String)
        readcommd("SELECT * FROM data_barang_master WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            'Basic
            in_supplier.Text = rd.Item("barang_supplier")
            in_kode.Text = kode
            in_nama.Text = rd.Item("barang_nama")
            Try
                cb_jenis.SelectedValue = rd.Item("barang_jenis")
            Catch ex As Exception
                cb_jenis.SelectedValue = 0
            End Try
            Try
                cb_kategori.SelectedValue = rd.Item("barang_kategori")
            Catch ex As Exception
                'cb_kategori.SelectedIndex = 0
            End Try
            'satuan
            cb_sat_kecil.Text = rd.Item("barang_satuan_kecil")
            cb_sat_tengah.Text = rd.Item("barang_satuan_tengah")
            cb_sat_besar.Text = rd.Item("barang_satuan_besar")
            in_isi_tengah.Value = rd.Item("barang_satuan_tengah_jumlah")
            in_isi_besar.Value = rd.Item("barang_satuan_besar_jumlah")
            'harga
            in_harga_beli.Value = rd.Item("barang_harga_beli")
            in_harga_jual.Value = rd.Item("barang_harga_jual")
            in_harga_mt.Value = rd.Item("barang_harga_jual_mt")
            in_harga_horeka.Value = rd.Item("barang_harga_jual_horeka")
            in_harga_rita.Value = rd.Item("barang_harga_jual_rita")
            in_harga_disc.Value = rd.Item("barang_harga_jual_discount")
            in_beli_d1.Value = rd.Item("Barang_harga_beli_d1")
            in_beli_d2.Value = rd.Item("Barang_harga_beli_d2")
            in_beli_d3.Value = rd.Item("Barang_harga_beli_d3")
            in_beli_klaim.Value = rd.Item("Barang_harga_beli_klaim")
            in_jual_d1.Value = rd.Item("barang_harga_jual_d1")
            in_jual_d2.Value = rd.Item("barang_harga_jual_d2")
            in_jual_d3.Value = rd.Item("barang_harga_jual_d3")
            in_jual_d4.Value = rd.Item("barang_harga_jual_d4")
            in_jual_d5.Value = rd.Item("barang_harga_jual_d5")
            'other
            brgStatus = rd.Item("barang_status")
            'user
            txtRegAlias.Text = rd.Item("barang_reg_alias")
            txtRegdate.Text = rd.Item("barang_reg_date")
            Try
                txtUpdDate.Text = rd.Item("barang_upd_date")
            Catch ex As Exception
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("barang_upd_alias")
        End If
        rd.Close()

        'satuan
        lbl_satuan1.Text = cb_sat_kecil.Text
        lbl_satuan2.Text = cb_sat_tengah.Text

        getSupplier(in_supplier.Text)
        setStatus()
        in_suppliernama.ReadOnly = True
    End Sub

    'LOAD DATA SUPPLIER
    Private Sub getSupplier(kode As String, Optional param As String = Nothing)
        op_con()
        If kode = Nothing And param <> Nothing Then
            readcommd("SELECT supplier_kode FROM data_supplier_master WHERE supplier_nama LIKE '" & param & "%' " _
                      & "AND supplier_status=1 LIMIT 1")
            If rd.HasRows Then
                kode = rd.Item(0)
            End If
            rd.Close()
        End If

        readcommd("SELECT supplier_nama FROM data_supplier_master WHERE supplier_kode='" & kode & "'")
        If rd.HasRows Then
            in_suppliernama.Text = rd.Item("supplier_nama")
        Else
            in_suppliernama.Clear()
        End If
        rd.Close()
    End Sub

    'SET STATUS
    Private Sub setStatus()
        Select Case brgStatus
            Case 0
                mn_deact.Text = "Activate"
                in_status.Text = "Non-Aktif"
            Case 1
                mn_deact.Text = "Deactivate"
                in_status.Text = "Aktif"
            Case 9
                mn_deact.Enabled = False
                in_status.Text = "Delete"
            Case Else
                Exit Sub
        End Select
    End Sub

    'OPEN FULL WINDOWS SEARCH
    Private Sub searchData(tipe As String)
        Dim q As String = ""
        Using search As New fr_search_dialog

        End Using
    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing, Optional param2 As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Dim autoco As New AutoCompleteStringCollection
        Select Case tipe
            Case "supplier"
                q = "SELECT supplier_kode as 'Kode', supplier_nama as 'Nama Supplier', " _
                    & "If(supplier_status=1,'Aktif','Non_Aktif') as 'Status' FROM data_supplier_master " _
                    & "WHERE supplier_status<>9 AND supplier_nama LIKE '{0}%'"
                dt = getDataTablefromDB(String.Format(q, param))
            Case Else
                Exit Sub
        End Select

        With dgv_listbarang
            .DataSource = dt
            .Columns(0).Width = 135
            .Columns(1).Width = 200
        End With
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popState
                Case "supplier"
                    in_supplier.Text = .Cells(0).Value
                    in_suppliernama.Text = .Cells(1).Value
                    in_kode.Focus()
                Case Else
                    Exit Sub
            End Select

        End With
        popPnl_barang.Visible = False
    End Sub

    'SAVE DATA
    Private Sub saveData()
        Dim data As String()
        Dim querycheck As Boolean = False

        Me.Cursor = Cursors.WaitCursor

        data = {
                "barang_nama='" & in_nama.Text.Replace("'", "`") & "'",
                "barang_supplier='" & in_supplier.Text & "'",
                "barang_jenis='" & cb_jenis.SelectedValue & "'",
                "barang_satuan_kecil='" & cb_sat_kecil.Text & "'",
                "barang_satuan_tengah='" & cb_sat_tengah.Text & "'",
                "barang_satuan_tengah_jumlah='" & in_isi_tengah.Value & "'",
                "barang_satuan_besar='" & cb_sat_besar.Text & "'",
                "barang_satuan_besar_jumlah='" & in_isi_besar.Value & "'",
                "barang_harga_beli='" & in_harga_beli.Value & "'",
                "barang_harga_jual='" & in_harga_jual.Value & "'",
                "barang_harga_beli_d1='" & in_beli_d1.Value & "'",
                "barang_harga_beli_d2='" & in_beli_d2.Value & "'",
                "barang_harga_beli_d3='" & in_beli_d3.Value & "'",
                "barang_harga_beli_klaim='" & in_beli_klaim.Value & "'",
                "barang_harga_jual_mt='" & in_harga_mt.Value & "'",
                "barang_harga_jual_rita='" & in_harga_rita.Value & "'",
                "barang_harga_jual_horeka='" & in_harga_horeka.Value & "'",
                "barang_harga_jual_discount='" & in_harga_disc.Value & "'",
                "barang_harga_jual_d1='" & in_jual_d1.Value & "'",
                "barang_harga_jual_d2='" & in_jual_d2.Value & "'",
                "barang_harga_jual_d3='" & in_jual_d3.Value & "'",
                "barang_harga_jual_d4='" & in_jual_d4.Value & "'",
                "barang_harga_jual_d5='" & in_jual_d5.Value & "'",
                "barang_status='" & brgStatus & "'"
                }

        op_con()
        If bt_simpanbarang.Text = "Simpan" Then
            'GENNERATE CODE
            If Trim(in_kode.Text) = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT SUBSTRING(barang_kode," & in_supplier.Text.Length & ") as ss FROM data_barang_master WHERE barang_kode LIKE '" & in_supplier.Text & "%' " _
                          & "AND SUBSTRING(barang_kode," & in_supplier.Text.Length & ") REGEXP '^[0-9]+$' ORDER BY ss DESC LIMIT 1")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()

                in_kode.Text = in_supplier.Text & no.ToString("D5")
            Else
                If checkdata("data_barang_master", "'" & in_kode.Text & "'", "barang_kode") Then
                    MessageBox.Show("Kode Barang " & in_kode.Text & " sudah ada")
                    in_kode.Focus()
                    Exit Sub
                End If
            End If

            querycheck = commnd("INSERT INTO data_barang_master SET barang_kode='" & in_kode.Text & "'," & String.Join(",", data) & ",barang_reg_date=NOW(), barang_reg_alias='" & loggeduser.user_id & "'")

        ElseIf bt_simpanbarang.Text = "Update" Then
            querycheck = commnd("UPDATE data_barang_master SET " & String.Join(",", data) & ",barang_upd_date=NOW(), barang_upd_alias='" & loggeduser.user_id & "' WHERE barang_kode='" & in_kode.Text & "'")
        End If

        Me.Cursor = Cursors.Default

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            'createLogAct("BARANG " & in_kode.Text)
            'frmbank.in_cari.Clear()
            'populateDGVUserCon("barang", "", frmbarang.dgv_list)
            doRefreshTab({pgbarang})
            Me.Close()
            'bt_simpanbarang.Text = "Update"
        End If
    End Sub

    'DEL DATA
    Private Sub delData()
        op_con()
        Dim q As String = "UPDATE data_barang_master SET barang_status=9 WHERE barang_kode='{0}'"
        'chk if item already used
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbarang.Click
        If MessageBox.Show("Tutup Form?", "Barang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbarang.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    'MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanbarang.PerformClick()
    End Sub

    Private Sub mn_deact_Click(sender As Object, e As EventArgs) Handles mn_deact.Click
        If mn_deact.Text = "Deactivate" Then
            brgStatus = "0"
        ElseIf mn_deact.Text = "Activate" Then
            brgStatus = "1"
        End If
        setStatus()
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click
        'brgStatus = 9
        'UPDATE STATUS TO 9
        'setStatus()
    End Sub

    'NUMERIC
    Private Sub in_stok_berat_Enter(sender As Object, e As EventArgs) Handles in_isi_tengah.Enter, in_isi_besar.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_stok_berat_Leave(sender As Object, e As EventArgs) Handles in_isi_tengah.Leave, in_isi_besar.Leave
        numericLostFocus(sender, "N0")
    End Sub

    Private Sub in_harga_Enter(sender As Object, e As EventArgs) Handles in_harga_rita.Enter, in_harga_mt.Enter, in_harga_mt.Enter, in_harga_jual.Enter,
        in_harga_horeka.Enter, in_harga_beli.Enter, in_jual_d5.Enter, in_jual_d4.Enter, in_jual_d3.Enter, in_jual_d2.Enter, in_jual_d1.Enter,
        in_harga_disc.Enter, in_beli_klaim.Enter, in_beli_d3.Enter, in_beli_d2.Enter, in_beli_d1.Enter

        numericGotFocus(sender)
    End Sub

    Private Sub in_harga_Leave(sender As Object, e As EventArgs) Handles in_harga_rita.Leave, in_harga_mt.Leave, in_harga_jual.Leave,
        in_harga_horeka.Leave, in_harga_beli.Leave, in_jual_d5.Leave, in_jual_d4.Leave, in_jual_d3.Leave, in_jual_d2.Leave, in_jual_d1.Leave,
        in_harga_disc.Leave, in_beli_klaim.Leave, in_beli_d3.Leave, in_beli_d2.Leave, in_beli_d1.Leave

        numericLostFocus(sender)
    End Sub

    'LOAD
    Private Sub fr_barang_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_jenis
            .DataSource = jenisBarang()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With
        Dim cbsat As ComboBox() = {cb_sat_besar, cb_sat_kecil, cb_sat_tengah}
        For Each x As ComboBox In cbsat
            With x
                .DataSource = jenis("satuan")
                .DisplayMember = "Text"
                .ValueMember = "Value"
                .SelectedIndex = -1
            End With
        Next

        op_con()
        If bt_simpanbarang.Text = "Update" Then
            With in_kode
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                loadData(.Text)
            End With
        End If
    End Sub

    'SAVE
    Private Sub bt_simpanbarang_Click(sender As Object, e As EventArgs) Handles bt_simpanbarang.Click
        If in_supplier.Text = Nothing Then
            MessageBox.Show("Supplier belum di input")
            in_suppliernama.Focus()
            Exit Sub
        End If
        If Trim(in_nama.Text) = Nothing Then
            MessageBox.Show("Nama belum di input")
            in_nama.Focus()
            Exit Sub
        End If
        If cb_jenis.SelectedValue = Nothing Then
            MessageBox.Show("Jenis barang belum di input")
            'cb_jenis.DroppedDown = True
            cb_jenis.Focus()
            Exit Sub
        End If
        Dim sw As Boolean = True
        Dim cbsat As ComboBox() = {cb_sat_kecil, cb_sat_tengah, cb_sat_besar}
        For Each x As ComboBox In cbsat
            If x.SelectedValue = Nothing Then
                MessageBox.Show("Satuan belum di input")
                x.Focus()
                sw = False
                Exit For
            End If
        Next
        If sw = False Then Exit Sub
        Dim n As NumericUpDown() = {in_isi_tengah, in_isi_besar}
        For Each x As NumericUpDown In n
            If x.Value = 0 Then
                MessageBox.Show("Isi satuan belum di input")
                x.Focus()
                sw = False
                Exit For
            End If
        Next
        If sw = False Then Exit Sub

        If MessageBox.Show("Simpan data barang?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    'UI
    '----------------POPUP PANEL
    Private Sub dgv_listbarang_Leave(sender As Object, e As EventArgs) Handles dgv_listbarang.Leave
        If Not in_suppliernama.Focused Then
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
            in_suppliernama.Text += e.KeyChar
            e.Handled = True
            in_suppliernama.Focus()
            in_suppliernama.Select(in_suppliernama.TextLength, in_suppliernama.TextLength)
        End If
    End Sub

    '------------ INPUT
    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        keyshortenter(in_suppliernama, e)
    End Sub

    Private Sub in_suppliernama_Enter(sender As Object, e As EventArgs) Handles in_suppliernama.Enter
        If in_suppliernama.ReadOnly = False Then
            popPnl_barang.Location = New Point(in_suppliernama.Left, in_suppliernama.Top + in_suppliernama.Height)
            If popPnl_barang.Visible = False Then
                popPnl_barang.Visible = True
            End If
            popState = "supplier"
            loadDataBRGPopup(popState, in_suppliernama.Text)
        End If
    End Sub

    Private Sub in_suppliernama_Leave(sender As Object, e As EventArgs) Handles in_suppliernama.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
            If Trim(in_suppliernama.Text) <> Nothing Then
                'setBarang(in_barang_nm.Text)
            End If
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_suppliernama_KeyDown(sender As Object, e As KeyEventArgs) Handles in_suppliernama.KeyUp
        If e.KeyCode = Keys.Down Then
            If popPnl_barang.Visible = True Then
                dgv_listbarang.Focus()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If popPnl_barang.Visible = True And dgv_listbarang.RowCount > 0 Then
                setPopUpResult()
            End If
            keyshortenter(in_kode, e)
        Else
            If in_suppliernama.ReadOnly = False Then
                If popPnl_barang.Visible = False Then
                    popPnl_barang.Visible = True
                End If
                loadDataBRGPopup(popState, in_suppliernama.Text)
            End If
        End If
    End Sub

    Private Sub in_suppliernama_TextChanged(sender As Object, e As EventArgs) Handles in_suppliernama.TextChanged
        If sender.Text = Nothing Then
            in_supplier.Clear()
        End If
    End Sub

    Private Sub bt_supplier_add_Click(sender As Object, e As EventArgs) Handles bt_supplier_add.Click

    End Sub

    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(in_nama, e)
    End Sub

    Private Sub in_nama_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nama.KeyDown
        keyshortenter(cb_jenis, e)
    End Sub

    Private Sub cb_sat_besar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_sat_besar.KeyPress, cb_sat_kecil.KeyPress, cb_sat_tengah.KeyPress, cb_jenis.KeyPress
        If e.KeyChar <> ControlChars.Cr Then
            e.Handled = True
        End If
    End Sub

    Private Sub cb_jenis_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_jenis.KeyDown
        keyshortenter(cb_kategori, e)
    End Sub

    Private Sub cb_kategori_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_kategori.KeyDown
        keyshortenter(cb_sat_kecil, e)
    End Sub

    Private Sub cb_sat_kecil_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat_kecil.KeyUp
        keyshortenter(cb_sat_tengah, e)
    End Sub

    Private Sub cb_sat_tengah_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat_tengah.KeyUp
        keyshortenter(in_isi_tengah, e)
    End Sub

    Private Sub in_isi_tengah_KeyDown(sender As Object, e As KeyEventArgs) Handles in_isi_tengah.KeyDown
        keyshortenter(cb_sat_besar, e)
    End Sub

    Private Sub cb_sat_besar_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_sat_besar.KeyDown
        keyshortenter(in_isi_besar, e)
    End Sub

    Private Sub in_isi_besar_KeyDown(sender As Object, e As KeyEventArgs) Handles in_isi_besar.KeyDown
        keyshortenter(in_harga_beli, e)
    End Sub

    Private Sub cb_sat_kecil_Leave(sender As Object, e As EventArgs) Handles cb_sat_kecil.SelectionChangeCommitted
        lbl_satuan1.Text = cb_sat_kecil.SelectedValue
    End Sub

    Private Sub cb_sat_tengah_Leave(sender As Object, e As EventArgs) Handles cb_sat_tengah.SelectionChangeCommitted
        lbl_satuan2.Text = cb_sat_tengah.SelectedValue
    End Sub

    Private Sub in_harga_beli_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_beli.KeyDown
        keyshortenter(in_harga_jual, e)
    End Sub

    Private Sub in_harga_jual_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_jual.KeyDown
        keyshortenter(in_harga_mt, e)
    End Sub

    Private Sub in_harga_mt_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_mt.KeyDown
        keyshortenter(in_harga_horeka, e)
    End Sub

    Private Sub in_harga_horeka_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_horeka.KeyDown
        keyshortenter(in_harga_rita, e)
    End Sub

    Private Sub in_harga_rita_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_rita.KeyDown
        keyshortenter(in_beli_d1, e)
    End Sub

    Private Sub in_beli_d1_KeyDown(sender As Object, e As KeyEventArgs) Handles in_beli_d1.KeyDown
        keyshortenter(in_beli_d2, e)
    End Sub

    Private Sub in_beli_d2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_beli_d2.KeyDown
        keyshortenter(in_beli_d3, e)
    End Sub

    Private Sub in_beli_d3_KeyDown(sender As Object, e As KeyEventArgs) Handles in_beli_d3.KeyDown
        keyshortenter(in_beli_klaim, e)
    End Sub

    Private Sub in_beli_klaim_KeyDown(sender As Object, e As KeyEventArgs) Handles in_beli_klaim.KeyDown
        keyshortenter(in_harga_disc, e)
    End Sub

    Private Sub in_harga_disc_KeyDown(sender As Object, e As KeyEventArgs) Handles in_harga_disc.KeyDown
        keyshortenter(in_jual_d1, e)
    End Sub

    Private Sub in_jual_d1_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jual_d1.KeyDown
        keyshortenter(in_jual_d2, e)
    End Sub

    Private Sub in_jual_d2_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jual_d2.KeyDown
        keyshortenter(in_jual_d3, e)
    End Sub

    Private Sub in_jual_d3_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jual_d3.KeyDown
        keyshortenter(in_jual_d4, e)
    End Sub

    Private Sub in_jual_d4_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jual_d4.KeyDown
        keyshortenter(in_jual_d5, e)
    End Sub

    Private Sub in_jual_d5_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jual_d5.KeyDown
        keyshortenter(bt_simpanbarang, e)
    End Sub
End Class