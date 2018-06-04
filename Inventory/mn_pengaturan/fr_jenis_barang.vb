Public Class fr_jenis_barang
    Public setfor As String = ""
    Private query As String
    Private param As String = ""
    Private paramQuery As String = "kode LIKE '%{0}%' OR nama LIKE '%{0}%'"


    Private Sub loadDataJenis(kode As String)
        readcommd("SELECT * FROM data_barang_jenis WHERE jenis_kode='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = kode
            in_nama_jenis.Text = rd.Item("jenis_nama")
            in_ket_jenis.Text = rd.Item("jenis_keterangan")
            txtRegdate.Text = rd.Item("jenis_reg_date")
            txtRegAlias.Text = rd.Item("jenis_reg_alias")
            Try
                txtUpdDate.Text = rd.Item("jenis_upd_date")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("jenis_upd_alias")
        End If
        rd.Close()
    End Sub

    Private Sub loadDataSatuan(kode As String)
        readcommd("SELECT * FROM ref_satuan WHERE satuan_kode='" & kode & "'")
        If rd.HasRows Then
            in_kode.Text = kode
            in_nama_jenis.Text = rd.Item("satuan_nama")
            in_ket_jenis.Text = rd.Item("satuan_keterangan")
            Try
                txtRegdate.Text = rd.Item("satuan_reg_date")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                txtRegdate.Text = "00/00/0000 00:00:00"
            End Try
            txtRegAlias.Text = rd.Item("satuan_reg_alias")
            Try
                txtUpdDate.Text = rd.Item("satuan_upd_date")
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                txtUpdDate.Text = "00/00/0000 00:00:00"
            End Try
            txtUpdAlias.Text = rd.Item("satuan_upd_alias")
        End If
        rd.Close()
    End Sub

    Private Sub loadDGV(query As String, param As String, paramQuery As String)
        Dim bs As New BindingSource
        bs.DataSource = getDataTablefromDB(query)
        bs.Filter = String.Format(paramQuery, param)
        dgv_list.DataSource = bs
        Console.WriteLine(dgv_list.RowCount)
    End Sub

    Private Sub resetForm()
        in_ket_jenis.Clear()
        in_nama_jenis.Clear()
        in_kode.Clear()
        If setfor <> "jenisbarang" Then
            in_kode.ReadOnly = False
            in_kode.BackColor = Color.White
        End If
        txtRegAlias.Clear()
        txtRegdate.Clear()
        txtUpdAlias.Clear()
        txtUpdDate.Clear()
        bt_simpan_jenis.Text = "Simpan"
    End Sub

    Private Sub keyshortenter(nextcontrol As Control, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nextcontrol.Focus()
        End If
    End Sub

    Private Sub fr_jenis_barang_Closing(sender As Object, e As EventArgs) Handles Me.FormClosing
        Select Case setfor
            Case "jenisbarang"
                frmsatuanbarang = New fr_jenis_barang
            Case "satuan"
                frmjenisbarang = New fr_jenis_barang
        End Select
    End Sub

    Private Sub fr_jenis_barang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        op_con()

        Select Case setfor
            Case "jenisbarang"
                query = "SELECT jenis_kode as kode, jenis_nama as nama, jenis_keterangan as ket FROM data_barang_jenis"
                paramQuery = "nama LIKE '%{0}%'"
                in_kode.ReadOnly = True
                in_kode.BackColor = Color.Gainsboro
                in_nama_jenis.Focus()
            Case "satuan"
                query = "SELECT satuan_kode as kode, satuan_nama as nama, satuan_keterangan as ket FROM ref_satuan"
                in_nama_jenis.MaxLength = 10
                in_kode.MaxLength = 3
                in_kode.TextAlign = HorizontalAlignment.Left
            Case Else
                query = ""
                Me.Close()
        End Select

        loadDGV(query, param, paramQuery)
    End Sub

    Private Sub bt_simpan_jenis_Click(sender As Object, e As EventArgs) Handles bt_simpan_jenis.Click
        Dim data As String()
        'Dim dataCol As String()
        Dim querycheck As Boolean = False

        Dim table As String = "data_barang_jenis"
        Dim check_col As String = "jenis_nama"
        Dim check_txt As String = "'" & in_nama_jenis.Text & "'"

        If setfor <> "jenisbarang" And (in_kode.Text) = Nothing Then
            MessageBox.Show("Kode belum di input")
            in_nama_jenis.Focus()
            Exit Sub
        End If

        If Trim(in_nama_jenis.Text) = Nothing Then
            MessageBox.Show("Nama belum di input")
            in_nama_jenis.Focus()
            Exit Sub
        End If

        Select Case setfor
            Case "jenisbarang"
                table = "data_barang_jenis"
                check_col = "jenis_nama"
                check_txt = "'" & in_nama_jenis.Text & "'"
                data = {
                    "jenis_nama='" & in_nama_jenis.Text & "'",
                    "jenis_keterangan='" & in_ket_jenis.Text & "'",
                    "jenis_reg_date=NOW()",
                    "jenis_reg_alias='" & loggeduser.user_id & "'"
                }
            Case "satuan"
                table = "ref_satuan"
                check_col = "satuan_kode"
                check_txt = "'" & in_kode.Text & "'"
                data = {
                    "satuan_kode='" & in_kode.Text & "'",
                    "satuan_nama='" & in_nama_jenis.Text & "'",
                    "satuan_keterangan='" & in_ket_jenis.Text & "'",
                    "satuan_reg_date=NOW()",
                    "satuan_reg_alias='" & loggeduser.user_id & "'"
                }
            Case Else
                data = {}
        End Select

        op_con()
        If bt_simpan_jenis.Text = "Simpan" Then
            'dataCol = {
            '    "jenis_nama",
            '    "jenis_keterangan",
            '    "jenis_reg_date",
            '    "jenis_reg_alias"
            '    }

            If checkdata(table, check_txt, check_col) = True Then
                MessageBox.Show(check_txt & " sudah ada")
                in_cari.Text = Replace(check_txt, "'", "")
                bt_cari.PerformClick()
                Exit Sub
            End If

            querycheck = commnd("INSERT INTO " & table & " SET " & String.Join(",", data))

        ElseIf bt_simpan_jenis.Text = "Update" Then
            Dim update_col As String
            Select Case setfor
                Case "jenisbarang"
                    data = {
                        "jenis_nama='" & in_nama_jenis.Text & "'",
                        "jenis_keterangan='" & in_ket_jenis.Text & "'",
                        "jenis_upd_date=NOW()",
                        "jenis_upd_alias='" & loggeduser.user_id & "'"
                    }
                    update_col = "jenis_kode"
                Case "satuan"
                    data = {
                        "satuan_nama='" & in_nama_jenis.Text & "'",
                        "satuan_keterangan='" & in_ket_jenis.Text & "'",
                        "satuan_upd_date=NOW()",
                        "satuan_upd_alias='" & loggeduser.user_id & "'"
                    }
                    update_col = "satuan_kode"
                Case Else
                    data = {}
                    update_col = ""
            End Select
            querycheck = commnd("UPDATE " & table & " SET " & String.Join(",", data) & " WHERE " & update_col & "='" & in_kode.Text & "'")
        End If

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            resetForm()
            in_cari.Clear()
            loadDGV(query, "", paramQuery)

            'frmjenisbarang.in_cari.Clear()
            'populateDGVUserCon("jenisbarang", "", frmjenisbarang.dgv_list)
            'Me.Close()
        End If
    End Sub

    Private Sub bt_cancel_Click(sender As Object, e As EventArgs) Handles bt_cancel.Click
        resetForm()
    End Sub

    Private Sub bt_batal_jenis_Click(sender As Object, e As EventArgs) Handles bt_batal_jenis.Click
        Me.Close()
    End Sub

    Private Sub bt_cari_Click(sender As Object, e As EventArgs) Handles bt_cari.Click
        loadDGV(query, in_cari.Text, paramQuery)
    End Sub

    Private Sub dgv_list_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim kode As String = dgv_list.Rows(e.RowIndex).Cells("kode").Value
            op_con()
            Select Case setfor
                Case "jenisbarang"
                    loadDataJenis(kode)
                Case "satuan"
                    loadDataSatuan(kode)
            End Select
            in_kode.ReadOnly = True
            in_kode.BackColor = Color.Gainsboro
            in_nama_jenis.Focus()
            bt_simpan_jenis.Text = "Update"
        End If
    End Sub

    Private Sub fr_jenis_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control = True AndAlso e.KeyCode = Keys.F Then
            in_cari.Focus()
        ElseIf e.KeyCode = Keys.F5 Then
            resetForm()
            in_cari.Clear()
            loadDGV(query, "", paramQuery)
        End If
    End Sub

    Private Sub in_kode_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kode.KeyDown
        keyshortenter(in_nama_jenis, e)
    End Sub

    Private Sub in_nama_jenis_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nama_jenis.KeyDown
        keyshortenter(in_ket_jenis, e)
    End Sub

    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyCode = Keys.Enter Then
            bt_cari.PerformClick()
        End If
    End Sub
End Class