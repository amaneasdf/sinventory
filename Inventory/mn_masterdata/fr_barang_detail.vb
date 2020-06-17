Public Class fr_barang_detail
    Private popState As String = "suppier"
    Private brgStatus As String = "1"
    Private olddata As String = ""
    Private formstate As InputState = InputState.Insert

    Private Enum InputState
        Insert
        Edit
    End Enum

    'STYLE
    Private m_aeroEnabled As Boolean = False
    Private Const CS_DROPSHADOW As Int32 = &H20000
    Private Const WM_NCPAINT As Int32 = 133
    Private Const WM_ACTIVATEAPP As Int32 = 28

    Private Const WM_NCHITTEST As Int32 = &H84
    Private Const HTCLIENT As Int32 = &H1
    Private Const HTCAPTION As Int32 = &H2

    'DROP SHADOW
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            m_aeroEnabled = CheckAeroEnabled()

            Dim parameters As CreateParams = MyBase.CreateParams
            If Not m_aeroEnabled Then parameters.ClassStyle += CS_DROPSHADOW
            Return parameters
        End Get
    End Property

    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case WM_NCPAINT
                If m_aeroEnabled Then
                    Dim v = 2
                    DwmSetWindowAttribute(Me.Handle, 2, v, 4)
                    Dim margins As New Margins With {
                        .bottomHeight = 1,
                        .leftWidth = 0,
                        .rightWidth = 0,
                        .topHeight = 0
                        }
                    DwmExtendFrameIntoClientArea(Me.Handle, margins)
                End If
        End Select
        MyBase.WndProc(m)
        If (m.Msg = WM_NCHITTEST AndAlso m.Result.ToInt32 = HTCLIENT) Then m.Result = HTCAPTION
    End Sub

    'SETUP FORM
    Private Sub SetUpForm(KodeBarang As String, FormSet As InputState, AllowEdit As Boolean)
        Me.Opacity = 0 : formstate = FormSet

        For Each cbo As ComboBox In {cb_jenis, cb_kategori, cb_pajak, cb_sat_besar, cb_sat_tengah, cb_sat_kecil}
            Dim _type As String = "" : Dim _idx As Integer = 0
            Select Case cbo.Name
                Case cb_jenis.Name : _type = "jenis_barang"
                Case cb_kategori.Name : _type = "kat_barang"
                Case cb_pajak.Name : _type = "pajak_barang"
                Case cb_sat_besar.Name, cb_sat_tengah.Name, cb_sat_kecil.Name
                    _type = "satuan_plus" : _idx = -1
                Case Else : GoTo NextCbo
            End Select

            cbo.DataSource = jenis(_type)
            cbo.ValueMember = "Value"
            cbo.DisplayMember = "Text"
            cbo.SelectedIndex = _idx
            AddHandler cbo.KeyPress, AddressOf cb_sat_besar_KeyPress
            If {cb_sat_kecil.Name, cb_sat_tengah.Name}.Contains(cbo.Name) Then
                AddHandler cbo.SelectedIndexChanged, AddressOf cb_sat_kecil_SelectedIndexChange
            End If
NextCbo:
        Next

        If Not FormSet = InputState.Insert Then
            Dim _resp = loadData(KodeBarang)
            If Not _resp.Key Then
                MessageBox.Show(_resp.Value, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
            End If
        End If

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        If formstate = InputState.Edit Or Not AllowInput Then
            in_kode.ReadOnly = True : in_kode.BackColor = Color.Gainsboro
            in_suppliernama.ReadOnly = True : in_suppliernama.BackColor = Color.Gainsboro
            tstrip_supplier.Visible = False
            ToolStripSeparator3.Visible = False
            If formstate = InputState.Edit Then bt_simpancusto.Text = "Update"
        Else
            in_kode.ReadOnly = False
            in_suppliernama.ReadOnly = False
            If Not main.listkodemenu.Contains("mn0102") Then
                tstrip_supplier.Visible = False
                ToolStripSeparator3.Visible = False
            End If
        End If

        For Each txt As TextBox In {in_nama, in_ket}
            txt.ReadOnly = IIf(AllowInput, False, True)
        Next
        For Each cbx As ComboBox In {cb_sat_besar, cb_sat_kecil, cb_sat_tengah, cb_jenis, cb_pajak, cb_kategori}
            cbx.Enabled = AllowInput
            cbx.ContextMenuStrip = New ContextMenuStrip
        Next
        For Each numx As NumericUpDown In {in_harga_beli, in_beli_d1, in_beli_d2, in_beli_d3, in_beli_klaim, in_harga_jual, in_harga_disc, in_harga_mt, in_harga_rita,
                                           in_harga_horeka, in_jual_d1, in_jual_d2, in_jual_d3, in_jual_d4, in_jual_d5, in_isi_besar, in_isi_tengah}
            numx.Enabled = AllowInput
            AddHandler numx.Enter, AddressOf in_harga_Enter
            AddHandler numx.Leave, AddressOf in_harga_Leave
        Next

        bt_simpancusto.Enabled = AllowInput
        tstrip_status.Enabled = IIf(formstate = InputState.Insert, False, AllowInput)
        tstrip_simpan.Enabled = AllowInput
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

    Private Sub fr_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Opacity = 100
    End Sub

    'LOAD DATA BARANG
    Private Function loadData(kode As String) As KeyValuePair(Of Boolean, String)
        If MainConnData.IsEmpty Then Return New KeyValuePair(Of Boolean, String)(False, "Main DB Configuration is empty.")

        Try
            Using x = New MySqlThing(MainConnData.host, MainConnData.db, decryptString(MainConnData.uid), decryptString(MainConnData.pass))
                x.Open() : If x.ConnectionState = ConnectionState.Open Then
                    Using rdx = x.ReadCommand(String.Format("CALL getDataMasterHeader('{0}','BARANG')", kode))
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
                    Select Case brgStatus
                        Case 0 : in_status.Text = "Non-Aktif"
                        Case 1 : in_status.Text = "Aktif"
                        Case 9 : in_status.Text = "Delete"
                        Case Else
                            Return New KeyValuePair(Of Boolean, String)(False, "Status data ")
                    End Select

                    Return New KeyValuePair(Of Boolean, String)(True, "OK")

                Else
                    Return New KeyValuePair(Of Boolean, String)(False, "Tidak dapat terhubung ke database.")
                End If
            End Using
        Catch ex As Exception
            LogError(ex)
            Return New KeyValuePair(Of Boolean, String)(False, "Terjadi kesalahan saat melakukan pengambilan data." & Environment.NewLine & ex.Message)
        End Try
    End Function

    'OPEN FULL WINDOWS SEARCH
    Private Sub searchData(tipe As String)

    End Sub

    'LOAD DATA TO DGV IN POPUP SEARCH PANEL
    Private Sub loadDataBRGPopup(tipe As String, Optional param As String = "")
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
            If String.IsNullOrWhiteSpace(param) Then .ClearSelection()
        End With
    End Sub

    'SET RESULT VALUE FROM DGV SEARCH
    Private Sub setPopUpResult()
        If dgv_listbarang.SelectedRows.Count > 0 Then
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
        End If
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

    'UI : DRAG FORM
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles pnl_header.MouseDown, lbl_title.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles pnl_header.MouseMove, lbl_title.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles pnl_header.MouseUp, lbl_title.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles pnl_header.DoubleClick, lbl_title.DoubleClick
        CenterToScreen()
    End Sub

    'UI : FORM
    Private Sub fr_jual_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If popPnl_barang.Visible = True Then
                popPnl_barang.Visible = False
            Else
                bt_batalcusto.PerformClick()
            End If
            e.SuppressKeyPress = True
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            bt_simpancusto.PerformClick()
            e.SuppressKeyPress = True
        End If
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

    'UI : BUTTON
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalcusto.Click
        bt_cl.PerformClick()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        Me.Close()
    End Sub

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

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles bt_menu.Click
        Dim _x As Integer = sender.Location.X
        Dim _y As Integer = sender.Location.Y + sender.Height
        ctx_main.Show(pnl_header, _x, _y)
    End Sub

    'UI : CONTEXT MENU
    Private Sub tstrip_simpan_Click(sender As Object, e As EventArgs) Handles tstrip_simpan.Click
        bt_simpancusto.PerformClick()
    End Sub

    Private Sub tsrtip_close_Click(sender As Object, e As EventArgs) Handles tsrtip_close.Click
        bt_cl.PerformClick()
    End Sub

    Private Sub tstrip_activate_Click(sender As Object, e As EventArgs) Handles tstrip_activate.Click
        If brgStatus = 1 Then
            MessageBox.Show("Status data barang sudah aktif.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub

    Private Sub tstrip_inactivate_Click(sender As Object, e As EventArgs) Handles tstrip_inactivate.Click
        If brgStatus = 0 Then
            MessageBox.Show("Status data barang sudah nonaktif.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub tstrip_delete_Click(sender As Object, e As EventArgs) Handles tstrip_delete.Click

    End Sub

    Private Sub tstrip_supplier_Click(sender As Object, e As EventArgs) Handles tstrip_supplier.Click
        Dim sup As New fr_supplier_detail
        sup.doLoadNew()
    End Sub

    'UI : NUMERIC INPUT
    Private Sub in_harga_Enter(sender As Object, e As EventArgs)
        numericGotFocus(sender)
    End Sub

    Private Sub in_harga_Leave(sender As Object, e As EventArgs)
        Dim _N0 As String() = {in_isi_tengah.Name, in_isi_besar.Name, in_harga_jual.Name, in_harga_rita.Name, in_harga_mt.Name, in_harga_horeka.Name,
                               in_harga_beli.Name, in_harga_disc.Name}
        If _N0.Contains(sender.Name) Then
            numericLostFocus(sender, "N0")
        Else
            numericLostFocus(sender)
        End If
    End Sub

    'UI : COMBOBOX
    Private Sub cb_sat_besar_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar <> ControlChars.CrLf Or e.KeyChar <> ControlChars.Cr Or e.KeyChar <> ControlChars.Lf Then
            e.Handled = True
        End If
    End Sub

    Private Sub cb_sat_kecil_SelectedIndexChange(sender As Object, e As EventArgs)
        Select Case sender.Name
            Case cb_sat_kecil.Name : out_sat_kecil.Text = cb_sat_kecil.SelectedValue
            Case cb_sat_tengah.Name : out_sat_tengah.Text = cb_sat_tengah.SelectedValue
            Case Else : Exit Sub
        End Select
    End Sub

    'UI : INPUT
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
End Class