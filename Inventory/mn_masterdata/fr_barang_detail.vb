Public Class fr_barang_detail
    Private popState As String = "suppier"
    Private brgStatus As String = "1"
    Private olddata As String = ""
    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(KodeBarang As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Data Barang : xxxxxxxxx"

        formstate = FormSet

        With cb_jenis
            .DataSource = jenisBarang()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        With cb_kategori
            .DataSource = jenis("kat_barang")
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        With cb_pajak
            .DataSource = jenis("pajak_barang")
            .DisplayMember = "Text"
            .ValueMember = "Value"
        End With

        Dim cbsat As ComboBox() = {cb_sat_besar, cb_sat_kecil, cb_sat_tengah}
        For Each x As ComboBox In cbsat
            With x
                .DataSource = jenis("satuan_plus")
                .DisplayMember = "Text"
                .ValueMember = "Value"
                .SelectedIndex = -1
            End With
        Next

        If Not FormSet = InputState.Insert Then
            Me.Text += KodeBarang
            Me.lbl_title.Text += " : " & KodeBarang
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            loadData(KodeBarang)
        End If

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        in_kode.ReadOnly = IIf(formstate = InputState.Edit, True, False)
        bt_simpancusto.Text = IIf(formstate = InputState.Edit, "Update", "Simpan")
        in_suppliernama.ReadOnly = IIf(formstate = InputState.Insert, IIf(AllowInput, False, True), True)
        For Each txt As TextBox In {in_nama, in_ket}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        For Each cbx As ComboBox In {cb_sat_besar, cb_sat_kecil, cb_sat_tengah, cb_jenis, cb_kategori}
            cbx.Enabled = AllowInput
        Next
        For Each numx As NumericUpDown In {in_harga_beli, in_beli_d1, in_beli_d2, in_beli_d3, in_beli_klaim, in_harga_jual, in_harga_disc, in_harga_mt, in_harga_rita,
                                           in_harga_horeka, in_jual_d1, in_jual_d2, in_jual_d3, in_jual_d4, in_jual_d5, in_isi_besar, in_isi_tengah}
            numx.Enabled = AllowInput
        Next

        bt_simpancusto.Enabled = AllowInput
        mn_deact.Enabled = IIf(formstate = InputState.Insert, False, AllowInput)
        mn_save.Enabled = IIf(formstate = InputState.Insert, False, AllowInput)
        mn_del.Enabled = False
        mn_new_supplier.Enabled = IIf(main.listkodemenu.Contains("mn0102"), AllowInput, False)
    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        SetUpForm(Nothing, InputState.Insert, AllowInput)
        Me.Show()
        in_supplier.Focus()
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, AllowEdit As Boolean)
        SetUpForm(NoFaktur, InputState.Edit, AllowEdit)
        Me.Show()
        in_nama.Focus()
    End Sub

    'LOAD DATA BARANG
    Private Sub loadData(kode As String)
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "CALL getDataMasterHeader('{0}','BARANG')"
                Using rdx = x.ReadCommand(String.Format(q, kode))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        'Basic
                        in_supplier.Text = rdx.Item("barang_supplier")
                        in_suppliernama.Text = rdx.Item("supplier_nama")
                        in_kode.Text = kode
                        in_nama.Text = rdx.Item("barang_nama")
                        cb_jenis.SelectedValue = rdx.Item("barang_jenis")
                        cb_kategori.SelectedValue = IIf(IsDBNull(rdx.Item("barang_kategori")) = True, "000", rdx.Item("barang_kategori"))
                        cb_pajak.SelectedValue = rdx.Item("barang_pajak")
                        'satuan
                        cb_sat_kecil.SelectedValue = rdx.Item("barang_satuan_kecil")
                        out_sat_kecil.Text = rdx.Item("barang_satuan_kecil")
                        cb_sat_tengah.SelectedValue = rdx.Item("barang_satuan_tengah")
                        out_sat_tengah.Text = rdx.Item("barang_satuan_tengah")
                        cb_sat_besar.SelectedValue = rdx.Item("barang_satuan_besar")
                        in_isi_tengah.Value = rdx.Item("barang_satuan_tengah_jumlah")
                        in_isi_besar.Value = rdx.Item("barang_satuan_besar_jumlah")
                        'harga
                        in_harga_beli.Value = rdx.Item("barang_harga_beli")
                        in_harga_jual.Value = rdx.Item("barang_harga_jual")
                        in_harga_mt.Value = rdx.Item("barang_harga_jual_mt")
                        in_harga_horeka.Value = rdx.Item("barang_harga_jual_horeka")
                        in_harga_rita.Value = rdx.Item("barang_harga_jual_rita")
                        in_harga_disc.Value = rdx.Item("barang_harga_jual_discount")
                        in_beli_d1.Value = rdx.Item("barang_harga_beli_d1")
                        in_beli_d2.Value = rdx.Item("barang_harga_beli_d2")
                        in_beli_d3.Value = rdx.Item("barang_harga_beli_d3")
                        in_beli_klaim.Value = rdx.Item("barang_harga_beli_klaim")
                        in_jual_d1.Value = rdx.Item("barang_harga_jual_d1")
                        in_jual_d2.Value = rdx.Item("barang_harga_jual_d2")
                        in_jual_d3.Value = rdx.Item("barang_harga_jual_d3")
                        in_jual_d4.Value = rdx.Item("barang_harga_jual_d4")
                        in_jual_d5.Value = rdx.Item("barang_harga_jual_d5")
                        'other
                        in_ket.Text = rdx.Item("barang_keterangan")
                        brgStatus = rdx.Item("barang_status")
                        'user
                        txtRegAlias.Text = rdx.Item("barang_reg_alias")
                        txtRegdate.Text = rdx.Item("barang_reg_date")
                        txtUpdDate.Text = rdx.Item("barang_upd_date")
                        txtUpdAlias.Text = rdx.Item("barang_upd_alias")
                    End If
                End Using
                setStatus()
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", "Detail Barang", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        End Using
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

    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = Nothing, Optional param2 As String = Nothing)
        Dim q As String
        Dim dt As New DataTable
        Select Case tipe
            Case "supplier"
                q = "SELECT supplier_kode 'Kode', supplier_nama 'Nama Supplier' FROM data_supplier_master " _
                    & "WHERE supplier_status=1 AND (supplier_nama LIKE '{0}%' OR supplier_kode LIKE '{0}%') LIMIT 250"
            Case Else
                Exit Sub
        End Select

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                dt = x.GetDataTable(String.Format(q, param))
            End If
        End Using

        With dgv_listbarang
            .DataSource = dt
            If dt.Columns.Count >= 2 Then
                .Columns(0).Width = 100 : .Columns(1).Width = 200
                .Columns(.DisplayedColumnCount(False) - 1).AutoSizeMode = IIf(.DisplayedColumnCount(False) <= 3, DataGridViewAutoSizeColumnMode.Fill, DataGridViewAutoSizeColumnMode.NotSet)
            End If
        End With
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        With dgv_listbarang.SelectedRows.Item(0)
            Select Case popState
                Case "supplier"
                    in_supplier.Text = .Cells(0).Value
                    in_suppliernama.Text = .Cells(1).Value
                    If String.IsNullOrWhiteSpace(in_kode.Text) Then in_kode.Text = in_supplier.Text
                    in_kode.Focus()
                Case Else
                    Exit Sub
            End Select
        End With
    End Sub

    'SAVE DATA
    Private Sub saveData()
        Dim data As String()
        Dim querycheck As Boolean = False
        Dim queryArr As New List(Of String)
        Dim q As String = ""

        data = {
                "barang_nama='" & in_nama.Text.Replace("'", "`") & "'",
                "barang_supplier='" & in_supplier.Text & "'",
                "barang_jenis='" & cb_jenis.SelectedValue & "'",
                "barang_kategori='" & IIf(IsNothing(cb_kategori.SelectedValue) = True, "000", cb_kategori.SelectedValue) & "'",
                "barang_pajak='" & cb_pajak.SelectedValue & "'",
                "barang_satuan_kecil='" & cb_sat_kecil.SelectedValue & "'",
                "barang_satuan_tengah='" & cb_sat_tengah.SelectedValue & "'",
                "barang_satuan_tengah_jumlah='" & in_isi_tengah.Value & "'",
                "barang_satuan_besar='" & cb_sat_besar.SelectedValue & "'",
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
                "barang_keterangan='" & mysqlQueryFriendlyStringFeed(in_ket.Text) & "'",
                "barang_status='" & brgStatus & "'"
                }
        Dim _inputvalue(,) As String = {{"kecil", "1", cb_sat_kecil.SelectedValue,
                                         in_harga_jual.Value / (in_isi_besar.Value * in_isi_tengah.Value),
                                         in_harga_mt.Value / (in_isi_besar.Value * in_isi_tengah.Value),
                                         in_harga_horeka.Value / (in_isi_besar.Value * in_isi_tengah.Value),
                                         in_harga_rita.Value / (in_isi_besar.Value * in_isi_tengah.Value)
                                        },
                                        {
                                        "tengah", in_isi_tengah.Value, cb_sat_tengah.SelectedValue,
                                         in_harga_jual.Value / in_isi_besar.Value,
                                         in_harga_mt.Value / in_isi_besar.Value,
                                         in_harga_horeka.Value / in_isi_besar.Value,
                                         in_harga_rita.Value / in_isi_besar.Value
                                        },
                                        {
                                        "besar", in_isi_besar.Value, cb_sat_besar.SelectedValue,
                                         in_harga_jual.Value,
                                         in_harga_mt.Value,
                                         in_harga_horeka.Value,
                                         in_harga_rita.Value
                                        }
                                       }

        If formstate = InputState.Insert Then
            If String.IsNullOrWhiteSpace(in_kode.Text) Then
                Dim no As Integer = 0 : Dim format As String = "D5"
                Using x = MainConnection
                    'GENERATE CODE
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        q = "SELECT IFNULL(MAX(SUBSTR(barang_kode,{1})), 0) FROM data_barang_master " _
                            & "WHERE barang_kode LIKE '{0}%' AND SUBSTR(barang_kode,{1}) REGEXP '^[0-9]+$'"
                        Try
                            no = Integer.Parse(x.ExecScalar(String.Format(q, in_supplier.Text, in_supplier.Text.Length + 1)))
                            format = IIf(no + 1 > 99999, "D" & (no + 1).ToString.Length, "D5")
                            in_kode.Text = in_supplier.Text & (no + 1).ToString(format)
                        Catch ex As Exception
                            logError(ex, True)
                            MessageBox.Show("Terjadi kesalahan saat melakukan proses input data." & Environment.NewLine & ex.Message,
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try
                    Else
                        MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using
            Else
                'CHECK INPUTED CODE
                Using x = MainConnection
                    x.Open() : If x.ConnectionState = ConnectionState.Open Then
                        q = "SELECT COUNT(barang_kode) FROM data_barang_master WHERE barang_kode='{0}'"
                        Try
                            If Integer.Parse(x.ExecScalar(String.Format(q, in_kode.Text))) > 0 Then
                                MessageBox.Show("Kode barang " & in_kode.Text & " sudah pernah diinputkan ke database.",
                                                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If
                        Catch ex As Exception
                            logError(ex, True)
                            MessageBox.Show("Terjadi kesalahan saat melakukan proses input data." & Environment.NewLine & ex.Message,
                                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try
                    Else
                        MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End Using
            End If

            q = "INSERT INTO data_barang_master SET barang_kode='{0}',{1},barang_reg_date=NOW(), barang_reg_alias='{2}'"
            queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", data), loggeduser.user_id))

            q = "INSERT INTO data_barang_satuan SET b_satuan_barang='{0}',{1}"
            For i = 0 To 2
                data = {
                    "b_satuan_jenis='" & _inputvalue(i, 0) & "'",
                    "b_satuan_isi='" & _inputvalue(i, 1) & "'",
                    "b_satuan_kodesatuan='" & _inputvalue(i, 2) & "'",
                    "b_satuan_hargajual='" & _inputvalue(i, 3).ToString.Replace(",", ".") & "'",
                    "b_satuan_hargajual_mt='" & _inputvalue(i, 4).ToString.Replace(",", ".") & "'",
                    "b_satuan_hargajual_horeka='" & _inputvalue(i, 5).ToString.Replace(",", ".") & "'",
                    "b_satuan_hargajual_rita='" & _inputvalue(i, 6).ToString.Replace(",", ".") & "'",
                    "b_satuan_status='" & IIf(brgStatus <> 1, 9, 1) & "'",
                    "b_satuan_reg_date=NOW()",
                    "b_satuan_reg_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", data)))
            Next

        Else
            q = "UPDATE data_barang_master SET {1},barang_upd_date=NOW(), barang_upd_alias='{2}' WHERE barang_kode='{0}'"
            queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", data), loggeduser.user_id))

            q = "UPDATE data_barang_satuan SET {1} WHERE b_satuan_barang='{0}' AND b_satuan_jenis='{2}'"
            For i = 0 To 2
                data = {
                    "b_satuan_isi='" & _inputvalue(i, 1) & "'",
                    "b_satuan_kodesatuan='" & _inputvalue(i, 2) & "'",
                    "b_satuan_hargajual='" & _inputvalue(i, 3).ToString.Replace(",", ".") & "'",
                    "b_satuan_hargajual_mt='" & _inputvalue(i, 4).ToString.Replace(",", ".") & "'",
                    "b_satuan_hargajual_horeka='" & _inputvalue(i, 5).ToString.Replace(",", ".") & "'",
                    "b_satuan_hargajual_rita='" & _inputvalue(i, 6).ToString.Replace(",", ".") & "'",
                    "b_satuan_status='" & IIf(brgStatus <> 1, 9, 1) & "'",
                    "b_satuan_upd_date=NOW()",
                    "b_satuan_upd_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add(String.Format(q, in_kode.Text, String.Join(",", data), _inputvalue(i, 0)))
            Next

        End If

        Using x = MainConnection
            x.Open() : If x.ConnectionState = ConnectionState.Open Then
                querycheck = x.TransactCommand(queryArr)

                If querycheck Then
                    MessageBox.Show("Data barang tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DoRefreshTab_v2({pgbarang})
                    Me.Close()
                Else
                    MessageBox.Show("Data barang tidak dapat tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Tidak dapat terhubung ke database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalcusto.Click
        'If MessageBox.Show("Tutup Form?", "Barang", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        Me.Close()
        'End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalcusto.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub fr_jual_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            Else
                bt_batalcusto.PerformClick()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    'UI : MENU
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpancusto.PerformClick()
    End Sub

    Private Sub mn_deact_Click(sender As Object, e As EventArgs) Handles mn_deact.Click
        If loggeduser.validasi_master Then
            If MessageBox.Show("Ubah status barang?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim _ket As String = ""
                Dim ckuser = MasterConfirmValid(_ket)

                If Not ckuser Then Exit Sub

                in_ket.Text += IIf(String.IsNullOrWhiteSpace(in_ket.Text), "", Environment.NewLine) & _ket

                If mn_deact.Text = "Deactivate" Then
                    brgStatus = "0"
                ElseIf mn_deact.Text = "Activate" Then
                    brgStatus = "1"
                End If
                setStatus() : bt_simpancusto.PerformClick()
            End If
        Else
            MessageBox.Show("Anda tidak dapat mengubah status barang", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click
        'brgStatus = 9
        'UPDATE STATUS TO 9
        'setStatus()
    End Sub

    Private Sub mn_new_supplier_Click(sender As Object, e As EventArgs) Handles mn_new_supplier.Click
        Dim x As New fr_supplier_detail
        x.doLoadNew()
    End Sub

    'NUMERIC
    Private Sub in_stok_berat_Enter(sender As Object, e As EventArgs) Handles in_isi_tengah.Enter, in_isi_besar.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_stok_berat_Leave(sender As Object, e As EventArgs) Handles in_isi_tengah.Leave, in_isi_besar.Leave, in_harga_rita.Leave, in_harga_mt.Leave, in_harga_jual.Leave,
        in_harga_horeka.Leave, in_harga_beli.Leave

        numericLostFocus(sender, "N0")
    End Sub

    Private Sub in_harga_Enter(sender As Object, e As EventArgs) Handles in_harga_rita.Enter, in_harga_mt.Enter, in_harga_mt.Enter, in_harga_jual.Enter,
        in_harga_horeka.Enter, in_harga_beli.Enter, in_jual_d5.Enter, in_jual_d4.Enter, in_jual_d3.Enter, in_jual_d2.Enter, in_jual_d1.Enter,
        in_harga_disc.Enter, in_beli_klaim.Enter, in_beli_d3.Enter, in_beli_d2.Enter, in_beli_d1.Enter

        numericGotFocus(sender)
    End Sub

    Private Sub in_harga_Leave(sender As Object, e As EventArgs) Handles  in_jual_d5.Leave, in_jual_d4.Leave, in_jual_d3.Leave, in_jual_d2.Leave, in_jual_d1.Leave,
        in_harga_disc.Leave, in_beli_klaim.Leave, in_beli_d3.Leave, in_beli_d2.Leave, in_beli_d1.Leave

        numericLostFocus(sender)
    End Sub

    'SAVE
    Private Sub bt_simpanbarang_Click(sender As Object, e As EventArgs) Handles bt_simpancusto.Click
        If in_supplier.Text = Nothing Then
            MessageBox.Show("Supplier belum di input.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_suppliernama.Focus() : Exit Sub
        End If
        If Trim(in_nama.Text) = Nothing Then
            MessageBox.Show("Nama belum di input.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            in_nama.Focus()
            Exit Sub
        End If
        If cb_jenis.SelectedValue = Nothing Then
            MessageBox.Show("Jenis barang belum di input.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cb_jenis.Focus() : Exit Sub
        End If

        'CHECK SATUAN/ISI
        Dim sw As Boolean = True
        Dim cbsat As ComboBox() = {cb_sat_kecil, cb_sat_tengah, cb_sat_besar}
        For Each x As ComboBox In cbsat
            If x.SelectedValue = Nothing Then
                MessageBox.Show("Satuan belum di input.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                x.Focus() : sw = False : Exit For
            End If
        Next : If Not sw Then Exit Sub
        Dim n As NumericUpDown() = {in_isi_tengah, in_isi_besar}
        For Each x As NumericUpDown In n
            If x.Value = 0 Then
                MessageBox.Show("Isi satuan belum di input.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                x.Focus() : sw = False : Exit For
            End If
        Next : If Not sw Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        Dim _resMsg As DialogResult = Windows.Forms.DialogResult.Yes
        If formstate <> InputState.Insert Then _resMsg = MessageBox.Show("Simpan perubahan data barang?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _resMsg = Windows.Forms.DialogResult.Yes Then
            If formstate = InputState.Edit Then
                If Not MasterConfirmValid("") Then GoTo endsub
            End If
            saveData()
        End If
endsub:
        Me.Cursor = Cursors.Default
    End Sub

    'UI : POPUP PANEL
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

    Private Sub dgv_listbarang_KeyDown_1(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dgv_listbarang_KeyUp(sender As Object, e As KeyEventArgs) Handles dgv_listbarang.KeyUp
        If e.KeyCode = Keys.Enter Then
            setPopUpResult()
        End If
    End Sub

    Private Sub dgv_listbarang_keypress(sender As Object, e As KeyPressEventArgs) Handles dgv_listbarang.KeyPress
        PopUpSearchKeyPress(e, in_suppliernama)
    End Sub

    '------------ INPUT
    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        keyshortenter(in_suppliernama, e)
    End Sub

    Private Sub in_suppliernama_Enter(sender As Object, e As EventArgs) Handles in_suppliernama.Enter
        If sender.Enabled And sender.ReadOnly = False Then
            popPnl_barang.Location = New Point(sender.Left, sender.Top + sender.Height)
            If popPnl_barang.Visible = False Then popPnl_barang.Visible = True
            popState = "supplier"
            loadDataBRGPopup(popState, sender.Text)
        End If
    End Sub

    Private Sub in_suppliernama_Leave(sender As Object, e As EventArgs) Handles in_suppliernama.Leave
        If Not dgv_listbarang.Focused = True Then
            popPnl_barang.Visible = False
        Else
            popPnl_barang.Visible = True
        End If
    End Sub

    Private Sub in_suppliernama_KeyDown(sender As Object, e As KeyEventArgs) Handles in_suppliernama.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Escape Then e.SuppressKeyPress = True
    End Sub

    Private Sub in_suppliernama_KeyUp(sender As Object, e As KeyEventArgs) Handles in_suppliernama.KeyUp
        Dim _x = PopUpSearchInputHandle_inputKeyup(e, sender, in_supplier, popPnl_barang, dgv_listbarang)
        For Each _resp As String In _x
            Select Case _resp
                Case "set" : setPopUpResult()
                Case "next" : keyshortenter(in_nama, e)
                Case "load" : loadDataBRGPopup(popState, sender.Text)
            End Select
        Next
    End Sub

    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(in_nama, e)
    End Sub

    Private Sub in_nama_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nama.KeyDown
        keyshortenter(cb_jenis, e)
    End Sub

    Private Sub cb_sat_besar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_sat_besar.KeyPress, cb_sat_kecil.KeyPress, cb_sat_tengah.KeyPress, cb_jenis.KeyPress
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
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
        out_sat_kecil.Text = cb_sat_kecil.SelectedValue
    End Sub

    Private Sub cb_sat_tengah_Leave(sender As Object, e As EventArgs) Handles cb_sat_tengah.SelectionChangeCommitted
        out_sat_tengah.Text = cb_sat_tengah.SelectedValue
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
        keyshortenter(bt_simpancusto, e)
    End Sub
End Class