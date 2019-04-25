Public Class fr_stok_awal
    Private rowindexlist As Integer = 0
    Private popupstate As String = "barang"
    Private formstate As InputState = InputState.Insert
    Private _oldqty As Integer = 0
    Private _oldnilai As Decimal = 0
    Private _brgPajak As String = ""

    Private Enum InputState
        Insert
        Edit
        View
    End Enum

    'SETUP FORM
    Private Sub SetUpForm(NoFaktur As String, FormSet As InputState, AllowEdit As Boolean)
        Const _tempTitle As String = "Data Stok : PO201908109021"

        formstate = FormSet

        in_tgl.Text = Today.ToString("dd-MM-yyyy")

        If formstate <> InputState.Insert Then
            Me.Text += " : " & NoFaktur
            Me.lbl_title.Text += " : " & NoFaktur
            If Me.lbl_title.Text.Length > _tempTitle.Length Then
                Me.lbl_title.Text = Strings.Left(Me.lbl_title.Text, _tempTitle.Length - 3) & "..."
            End If

            LoadData(NoFaktur)
            bt_simpanreturbeli.Text = "Update"
        End If

        ControlSwitch(AllowEdit)
    End Sub

    Private Sub ControlSwitch(AllowInput As Boolean)
        For Each txt As TextBox In {in_barang_n, in_gudang_n}
            txt.ReadOnly = IIf(formstate = InputState.Insert, AllowInput, True)
        Next

        in_qty.Enabled = AllowInput
        in_hpp.Enabled = AllowInput
        in_nilai.Enabled = AllowInput
        bt_simpanreturbeli.Enabled = AllowInput
    End Sub

    Public Sub doLoadNew(Optional AllowInput As Boolean = True)
        SetUpForm(Nothing, InputState.Insert, AllowInput)
        Me.Show(main)
    End Sub

    Public Sub doLoadEdit(NoFaktur As String, AllowEdit As Boolean)
        SetUpForm(NoFaktur, InputState.Edit, AllowEdit)
        Me.Show(main)
    End Sub

    Public Sub doLoadView(NoFaktur As String)
        SetUpForm(NoFaktur, InputState.View, False)
        Me.Show(main)
    End Sub

    'LOAD DATA
    Private Sub LoadData(KodeStock As String)
        Dim q As String = ""
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                q = "SELECT stock_kode, DATE_FORMAT(MIN(trans_tgl),'%Y-%m-%d') trans_tgl, stock_barang, barang_nama, barang_pajak, stock_gudang, gudang_nama, " _
                    & "SUM(trans_qty) trans_qty, SUM(trans_nilai) trans_nilai " _
                    & "FROM data_stok_awal " _
                    & "LEFT JOIN data_stok_kartustok ON stock_kode=trans_stock AND trans_status=1 " _
                    & "LEFT JOIN data_barang_master ON barang_kode=stock_barang " _
                    & "LEFT JOIN data_barang_gudang ON gudang_kode=stock_gudang " _
                    & "WHERE stock_kode='{0}' AND trans_periode='{1}' AND trans_jenis IN ('sa','mi','ad') " _
                    & "GROUP BY stock_kode"
                Using rdx = x.ReadCommand(String.Format(q, KodeStock, selectperiode.id))
                    Dim red = rdx.Read
                    If red And rdx.HasRows Then
                        in_kode.Text = KodeStock
                        in_barang.Text = rdx.Item("stock_barang")
                        in_barang_n.Text = rdx.Item("barang_nama")
                        in_gudang.Text = rdx.Item("stock_gudang")
                        in_gudang_n.Text = rdx.Item("gudang_nama")
                        in_qty.Value = rdx.Item("trans_qty")
                        in_tgl.Text = rdx.Item("trans_tgl")
                        in_nilai.Value = rdx.Item("trans_nilai")
                        _oldqty = rdx.Item("trans_qty")
                        _oldnilai = rdx.Item("trans_nilai")
                        _brgPajak = IIf(rdx.Item("barang_pajak") = 1, True, False)
                    End If
                End Using
            End If
        End Using
    End Sub

    'OPEN SEARCH WINDOW
    Private Sub doSearch()

    End Sub

    'SAVE DATA
    Private Sub saveData()
        If MainConnection.Connection Is Nothing Then
            Throw New NullReferenceException("Main db connection setting is empty.")
        End If

        Dim q As String = ""
        Dim _data As String()
        Dim queryArr As New List(Of String)
        Dim queryCk As Boolean = False
        Using x = MainConnection
            x.Open()
            If x.ConnectionState = ConnectionState.Open Then
                Dim _kodetrans As String = ""
                Dim _kodestock As String = ""

                '==========================================================================================================================
                'INPUT DATA STOK
                If formstate = InputState.Insert Then
                    _kodestock = in_gudang.Text & "-" & in_barang.Text

                    _kodetrans = _kodestock & "-sa-" & Now.ToString("yyMMdd.hhmmss")

                    q = "INSERT INTO data_stok_awal SET {0}"
                    _data = {
                        "stock_kode='" & _kodestock & "'",
                        "stock_barang='" & in_barang.Text & "'",
                        "stock_gudang='" & in_gudang.Text & "'",
                        "stock_status='1'",
                        "stock_reg_date=NOW()",
                        "stock_reg_alias='" & loggeduser.user_id & "'"
                        }
                    queryArr.Add(String.Format(q, String.Join(",", _data)))

                    q = "INSERT INTO data_stok_kartustok SET {0}"
                    _data = {
                        "trans_stock='" & _kodestock & "'",
                        "trans_tgl='" & CDate(in_tgl.Text).ToString("yyyy-MM-dd") & "'",
                        "trans_periode='" & selectperiode.id & "'",
                        "trans_index=0",
                        "trans_jenis='sa'",
                        "trans_ket='SALDO AWAL PERIODE'",
                        "trans_qty=" & in_qty.Value.ToString.Replace(",", "."),
                        "trans_nilai=" & in_nilai.Value.ToString.Replace(",", "."),
                        "trans_reg_date=NOW()",
                        "trans_reg_alias='" & loggeduser.user_id & "'"
                        }
                    queryArr.Add(String.Format(q, String.Join(",", _data)))
                Else
                    Dim _qty As Integer = in_qty.Value - _oldqty
                    Dim _nilai As Decimal = in_nilai.Value - _oldnilai

                    _kodestock = Trim(in_kode.Text)
                    _kodetrans = _kodestock & "-ad-" & Now.ToString("yyMMdd.hhmmss")

                    q = "INSERT INTO data_stok_kartustok SET {0}"
                    _data = {
                        "trans_stock='" & _kodestock & "'",
                        "trans_tgl='" & CDate(in_tgl.Text).ToString("yyyy-MM-dd") & "'",
                        "trans_periode='" & selectperiode.id & "'",
                        "trans_index=0",
                        "trans_jenis='ad'",
                        "trans_ket='Stock Adjustment'",
                        "trans_faktur='" & _kodetrans & "'",
                        "trans_qty=" & _qty.ToString.Replace(",", "."),
                        "trans_nilai=" & _nilai.ToString.Replace(",", "."),
                        "trans_reg_date=NOW()",
                        "trans_reg_alias='" & loggeduser.user_id & "'"
                        }
                    queryArr.Add(String.Format(q, String.Join(",", _data)))
                End If
                '==========================================================================================================================

                '==========================================================================================================================
                'INPUT DATA TRANSAKSI
                q = "INSERT INTO data_stok_penyesuaian SET {0}"
                _data = {
                    "s_p_kode='" & _kodetrans & "'",
                    "s_p_stock='" & _kodestock & "'",
                    "s_p_oldqty=" & _oldqty.ToString.Replace(",", "."),
                    "s_p_oldnilai=" & _oldnilai.ToString.Replace(",", "."),
                    "s_p_newqty=" & in_qty.Value.ToString.Replace(",", "."),
                    "s_p_newnilai=" & in_nilai.Value.ToString.Replace(",", "."),
                    "s_p_reg_alias='" & loggeduser.user_id & "'",
                    "s_p_reg_date=NOW()"
                    }
                queryArr.Add(String.Format(q, String.Join(",", _data)))
                '==========================================================================================================================
                'queryCk = x.TransactCommand(queryArr)

                '==========================================================================================================================
                'INPUT DATA JURNAL
                'If queryCk Then
                q = "INSERT INTO data_jurnal_line SET {0}"
                _data = {
                    "line_kode='" & _kodetrans & "'",
                    "line_type='STOKADJ'",
                    "line_ref='" & _kodestock & "'",
                    "line_ref_type='STOCK'",
                    "line_pajak=" & IIf(_brgPajak, 1, 0),
                    "line_tanggal='" & CDate(in_tgl.Text).ToString("yyyy-MM-dd") & "'",
                    "line_status=1",
                    "line_reg_date=NOW()",
                    "line_reg_alias='" & loggeduser.user_id & "'"
                    }
                queryArr.Add(String.Format(q, String.Join(",", _data)))
                queryCk = x.TransactCommand(queryArr)
                'End If
                '==========================================================================================================================
            End If

        End Using

        If queryCk Then
            MessageBox.Show("Saldo awal stok tersimpan.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            doRefreshTab({pgstok})
        Else
            MessageBox.Show("Data tidak dapat tersimpan", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    '------------drag form
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

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalreturbeli.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalreturbeli.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    Private Sub fr_jual_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            'If popPnl_barang.Visible = True Then
            '    popPnl_barang.Visible = False
            'Else
            bt_batalreturbeli.PerformClick()
            'End If
        End If
    End Sub

    'SAVE
    Private Sub bt_simpanreturbeli_Click(sender As Object, e As EventArgs) Handles bt_simpanreturbeli.Click
        If String.IsNullOrWhiteSpace(Trim(in_kode.Text)) And formstate <> InputState.Insert Then
            MessageBox.Show("Kode Stok ")
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(Trim(in_barang.Text)) Then
            MessageBox.Show("Kode barang ")
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(Trim(in_gudang.Text)) Then
            MessageBox.Show("Kode gudang ")
            Exit Sub
        End If

        If MessageBox.Show("Simpan saldo awal?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    'UI : NUMERIC
    Private Sub in_qty_Enter(sender As Object, e As EventArgs) Handles in_qty.Enter, in_hpp.Enter, in_nilai.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_qty_Leave(sender As Object, e As EventArgs) Handles in_qty.Leave, in_hpp.Leave, in_nilai.Leave
        numericLostFocus(sender, IIf(sender.Name = "in_qty", "N0", "N2"))
    End Sub

    Private Sub in_qty_ValueChanged(sender As Object, e As EventArgs) Handles in_qty.ValueChanged, in_hpp.ValueChanged
        in_nilai.Value = in_qty.Value * in_hpp.Value
    End Sub

    Private Sub in_nilai_ValueChanged(sender As Object, e As EventArgs) Handles in_nilai.ValueChanged
        If in_qty.Value = 0 Or (in_qty.Value < 0 And in_nilai.Value >= 0) Then
            in_hpp.Value = 0
        Else
            in_hpp.Value = in_nilai.Value / in_qty.Value
        End If
    End Sub

    'UI : INPUT
    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        keyshortenter(in_gudang_n, e)
    End Sub

    Private Sub in_gudang_n_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang_n.KeyDown, in_barang_n.KeyDown

    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        keyshortenter(in_barang_n, e)
    End Sub

    Private Sub in_qty_KeyDown(sender As Object, e As KeyEventArgs) Handles in_qty.KeyDown
        keyshortenter(in_hpp, e)
    End Sub

    Private Sub in_hpp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_hpp.KeyDown
        keyshortenter(in_nilai, e)
    End Sub

    Private Sub in_nilai_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nilai.KeyDown
        keyshortenter(bt_simpanreturbeli, e)
    End Sub
End Class