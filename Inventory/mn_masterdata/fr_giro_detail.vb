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
            in_status_kode.Text = rd.Item("giro_status")
            'cb_status.SelectedValue = in_status_kode.Text
            Try
                txtUpdDate.Text = rd.Item("giro_upd_date")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("giro_upd_alias")
        End If
        rd.Close()
        setNamaSales(in_kode_sales.Text)
        setNamaCusto(in_kode_custo.Text)
    End Sub

    Private Sub setNamaSales(kode As String)
        op_con()
        Try
            readcommd("SELECT salesman_nama FROM data_salesman_master WHERE salesman_kode='" & kode & "'")
            If rd.HasRows Then
                lbl_sales.Text = rd.Item("salesman_nama")
            Else
                lbl_sales.Text = ""
            End If
            rd.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub setNamaCusto(kode As String)
        op_con()
        Try
            readcommd("SELECT customer_nama FROM data_customer_master WHERE customer_kode='" & kode & "'")
            If rd.HasRows Then
                lbl_custo.Text = rd.Item("customer_nama")
            Else
                lbl_custo.Text = ""
            End If
            rd.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub fr_giro_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_sales.Text = ""
        lbl_custo.Text = ""
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
                "'" & in_status_kode.Text & "'",
                "NOW()",
                "'" & loggeduser.user_id & "'"
                }
            querycheck = commnd("INSERT INTO data_giro_master(" & String.Join(",", dataCol) & ") VALUES(" & String.Join(",", data) & ")")
        ElseIf bt_simpangiro.Text = "Update" Then
            querycheck = commnd("UPDATE data_giro_master SET giro_tanggal='" & date_tgl.Value.ToString("yyyy-MM-dd") & "', giro_salesman='" & in_kode_sales.Text & "', giro_customer='" & in_kode_custo.Text & "', giro_rekening='" & in_nobg.Text & "', giro_jumlah='" & in_jumlah.Value & "', giro_tanggal_bg='" & date_tgl_bg.Value.ToString("yyyy-MM-dd") & "', giro_bank='" & in_bank.Text & "', giro_status='" & in_status_kode.Text & "', giro_upd_date=NOW(), giro_upd_alias='" & loggeduser.user_id & "' WHERE giro_id='" & in_kode.Text & "'")
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
        setNamaSales(in_kode_sales.Text)
    End Sub

    Private Sub in_kode_custo_Leave(sender As Object, e As EventArgs) Handles in_kode_custo.Leave
        setNamaCusto(in_kode_custo.Text)
    End Sub

    Private Sub in_kode_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode_sales.KeyDown
        lbl_sales.Text = ""
    End Sub

    Private Sub in_kode_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode_custo.KeyDown
        lbl_custo.Text = ""
    End Sub
End Class