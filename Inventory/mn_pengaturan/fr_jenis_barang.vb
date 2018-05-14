Public Class fr_jenis_barang

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

    Private Sub fr_jenis_barang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        op_con()
        If bt_simpan_jenis.Text = "Update" Then
            in_nama_jenis.Focus()
            With in_kode
                loadDataJenis(.Text)
            End With
        End If
    End Sub

    Private Sub bt_simpan_jenis_Click(sender As Object, e As EventArgs) Handles bt_simpan_jenis.Click
        Dim data As String()
        Dim dataCol As String()
        Dim querycheck As Boolean = False

        If in_nama_jenis.Text = Nothing Then
            MessageBox.Show("Nama jenis belum di input")
            in_nama_jenis.Focus()
            Exit Sub
        End If

        op_con()
        If bt_simpan_jenis.Text = "Simpan" Then
            data = {
                "'" & in_nama_jenis.Text & "'",
                "'" & in_ket_jenis.Text & "'",
                "NOW()",
                "'" & loggeduser.user_id & "'"
                }
            dataCol = {
                "jenis_nama",
                "jenis_keterangan",
                "jenis_reg_date",
                "jenis_reg_alias"
                }

            If checkdata("data_barang_jenis", "'" & in_nama_jenis.Text & "'", "jenis_nama") = True Then
                MessageBox.Show("Jenis barang " & in_nama_jenis.Text & " sudah ada")
                Exit Sub
            End If

            querycheck = commnd("INSERT INTO data_barang_jenis(" & String.Join(",", dataCol) & ") VALUES(" & String.Join(",", data) & ")")
        ElseIf bt_simpan_jenis.Text = "Update" Then
            querycheck = commnd("UPDATE data_barang_jenis SET jenis_nama='" & in_nama_jenis.Text & "', jenis_keterangan='" & in_ket_jenis.Text & "', jenis_upd_date=NOW(), jenis_upd_alias='" & loggeduser.user_id & "'")
        End If

        If querycheck = False Then
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            frmjenisbarang.in_cari.Clear()
            populateDGVUserCon("jenisbarang", "", frmjenisbarang.dgv_list)
            Me.Dispose()
        End If
    End Sub

    Private Sub bt_batal_jenis_Click(sender As Object, e As EventArgs) Handles bt_batal_jenis.Click
        Me.Dispose()
    End Sub
End Class