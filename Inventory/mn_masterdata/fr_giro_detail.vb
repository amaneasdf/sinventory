Public Class fr_giro_detail

    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_NCLBUTTONDOWN As Integer = 161
        Const WM_SYSCOMMAND As Integer = 274
        Const HTCAPTION As Integer = 2
        Const SC_MOVE As Integer = 61456

        If (m.Msg = WM_SYSCOMMAND) AndAlso (m.WParam.ToInt32 = SC_MOVE) Then
            Exit Sub
        End If

        If (m.Msg = WM_NCLBUTTONDOWN) AndAlso (m.WParam.ToInt32 = HTCAPTION) Then
            Exit Sub
        End If

        MyBase.WndProc(m)
    End Sub

    Private Sub loadDataGiro(kode As String)
        readcommd("SELECT * FROM data_giro_master where giro_id='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = kode
            date_tgl.Value = rd.Item("giro_tanggal")
            in_kode_sales.Text = rd.Item("giro_salesman")
            in_kode_custo.Text = rd.Item("giro_customer")
            in_nobg.Text = rd.Item("giro_rekening")
            in_jumlah.Value = rd.Item("giro_jumlah")
            in_bank.Text = rd.Item("giro_bank")
            txtRegdate.Text = rd.Item("giro_reg_date")
            txtRegAlias.Text = rd.Item("giro_reg_alias")
            date_tgl_bg.Value = rd.Item("giro_tanggal_bg")
            cb_status.SelectedValue = rd.Item("giro_status")
            Try
                txtUpdDate.Text = rd.Item("giro_upd_date")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("giro_upd_alias")
        End If
        rd.Close()
    End Sub

    Private Sub fr_giro_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cb_sales

        End With
        If bt_simpangiro.Text = "Update" Then
            op_con()
            loadDataGiro(in_kode.Text)
        End If
    End Sub

    Private Sub bt_simpangiro_Click(sender As Object, e As EventArgs) Handles bt_simpangiro.Click
        Dim data As String()
        Dim dataCol As String()
        Dim querycheck As Boolean = False
        If in_kode_sales.Text = Nothing Then
            MessageBox.Show("Kode sales belum di input")
            in_kode_sales.Focus()
            Exit Sub
        End If

        If in_kode_custo.Text = Nothing Then
            MessageBox.Show("Kode Customer belum di input")
            in_kode_custo.Focus()
            Exit Sub
        End If

        If in_nobg.Text = Nothing Then
            MessageBox.Show("No. Rek BG belum di input")
            in_nobg.Focus()
            Exit Sub
        End If

        If in_bank.Text = Nothing Then
            MessageBox.Show("Nama bank belum belum di input")
            in_bank.Focus()
            Exit Sub
        End If

        If in_jumlah.Value = 0 Then
            MessageBox.Show("Jumlah BG belum belum di input")
            in_jumlah.Focus()
            Exit Sub
        End If

        op_con()
        If bt_simpangiro.Text = "Simpan" Then
            dataCol = {
                "giro_tanggal",
                "giro_salesman",
                "giro_customer",
                "giro_rekening",
                "giro_bank",
                "giro_jumlah",
                "giro_tanggal_bg",
                "giro_status",
                "giro_reg_date",
                "giro_reg_alias"
                }
            data = {
                "'" & date_tgl.Value.ToString("yyyy-MM-dd") & "'",
                "'" & in_kode_sales.Text & "'",
                "'" & in_kode_custo.Text & "'",
                "'" & in_nobg.Text & "'",
                "'" & in_bank.Text & "'",
                "'" & in_jumlah.Value & "'",
                "'" & date_tgl_bg.Value.ToString("yyyy-MM-dd") & "'",
                "'" & cb_status.SelectedValue & "'",
                "NOW()",
                "'" & loggeduser.user_id & "'"
                }
            querycheck = commnd("INSERT INTO data_giro_master(" & String.Join(",", dataCol) & ") VALUES(" & String.Join(",", data) & ")")
        ElseIf bt_simpangiro.Text = "Update" Then
            querycheck = commnd("UPDATE data_giro_master SET giro_tanggal='" & date_tgl.Value.ToString("yyyy-MM-dd") & "', giro_salesman='" & in_kode_sales.Text & "', giro_customer='" & in_kode_custo.Text & "', giro_rekening='" & in_nobg.Text & "', giro_jumlah='" & in_jumlah.Value & "', giro_tanggal_bg='" & date_tgl_bg.Value.ToString("yyyy-MM-dd") & "', giro_bank='" & in_bank.Text & "', giro_status='" & cb_status.SelectedValue & "', giro_upd_date=NOW(), giro_upd_alias='" & loggeduser.user_id & "' WHERE giro_id='" & in_kode.Text & "'")
        End If

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmbgditangan.in_cari.Clear()
            populateDGVUserCon("giro", "", frmbgditangan.dgv_list)
            Me.Dispose()
        End If
    End Sub

    Private Sub bt_batalgiro_Click(sender As Object, e As EventArgs) Handles bt_batalgiro.Click
        Me.Dispose()
    End Sub

    Private Sub fr_giro_detail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            bt_batalgiro.PerformClick()
        End If
    End Sub

    Private Sub in_kode_sales_Leave(sender As Object, e As EventArgs) Handles in_kode_sales.Leave
        If Trim(in_kode_sales.Text) <> Nothing Then
            cb_sales.SelectedValue = Trim(in_kode_sales.Text)
        End If
    End Sub

    Private Sub in_kode_custo_Leave(sender As Object, e As EventArgs) Handles in_kode_custo.Leave
        If Trim(in_kode_custo.Text) <> Nothing Then
            cb_custo.SelectedValue = Trim(in_kode_custo.Text)
        End If
    End Sub

    Private Sub in_kode_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode_sales.KeyDown
        keyshortenter(in_kode_custo, e)
    End Sub

    Private Sub in_kode_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode_custo.KeyDown
        keyshortenter(in_nobg, e)
    End Sub

    Private Sub date_tgl_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl.KeyDown
        keyshortenter(in_kode_sales, e)
    End Sub

    Private Sub in_nobg_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nobg.KeyDown
        keyshortenter(in_bank, e)
    End Sub

    Private Sub in_bank_KeyDown(sender As Object, e As KeyEventArgs) Handles in_bank.KeyDown
        keyshortenter(in_jumlah, e)
    End Sub

    Private Sub in_jumlah_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jumlah.KeyDown
        keyshortenter(date_tgl_bg, e)
    End Sub

    Private Sub date_tgl_bg_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_bg.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            cb_status.DroppedDown = True
            cb_status.Focus()
        End If
    End Sub

    Private Sub cb_status_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cb_status.SelectionChangeCommitted
        bt_simpangiro.Focus()
    End Sub

    Private Sub in_jumlah_Enter(sender As Object, e As EventArgs) Handles in_jumlah.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_jumlah_Leave(sender As Object, e As EventArgs) Handles in_jumlah.Leave
        numericLostFocus(sender)
    End Sub
End Class