Public Class fr_bank_detail
    Private bnkStatus As String = "1"
    Private popState As String = "perk"

    Private Sub loadData(kode As String)
        Dim q As String = ""
        op_con()


        setStatus()
        in_kode.ReadOnly = True
        mn_deact.Enabled = True
    End Sub

    'SET STATUS
    Private Sub setStatus()
        Select Case bnkStatus
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
            Case "perk"
                q = "SELECT perkiraan_kode as 'Kode', perkiraan_nama as 'Perkiraan', " _
                    & "If(perkiraan_status=1,'Aktif','Non_Aktif') as 'Status' FROM data_perkiraan " _
                    & "WHERE perkiraan_status<>9 AND perkiraan_nama LIKE '{0}%'"
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
                Case "perk"
                    in_pos.Text = .Cells(0).Value
                    in_pos_n.Text = .Cells(1).Value
                    bt_simpancusto.Focus()
                Case Else
                    Exit Sub
            End Select

        End With
        popPnl_barang.Visible = False
    End Sub

    'SAVE DATA
    Private Sub saveData()
        Dim data1 As String()
        Dim querycheck As Boolean = False
        Dim q As String = ""

        Me.Cursor = Cursors.WaitCursor

        data1 = {
            "bank_nama='" & in_namabank.Text & "'",
            "bank_akun='" & in_pos.Text & "'"
            }

        op_con()
        If bt_simpancusto.Text = "Simpan" Then
            'GENNERATE CODE
            If Trim(in_kode.Text) = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT SUBSTRING(bank_kode,2) as ss FROM data_barang_master WHERE barang_kode LIKE 'B%' " _
                          & "ORDER BY ss DESC LIMIT 1")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()

                in_kode.Text = "B" & no.ToString("D3")
            Else
                If checkdata("data_barang_master", "'" & in_kode.Text & "'", "barang_kode") Then
                    MessageBox.Show("Kode Barang " & in_kode.Text & " sudah ada")
                    in_kode.Focus()
                    Exit Sub
                End If
            End If
            q = "INSERT INTO data_bank_master SET bank_kode='{0}',{1},bank_reg_date=NOW(),bank_reg_alias='{2}'"
        ElseIf bt_simpancusto.Text = "Update" Then
            q = "UPDATE data_bank_master SET {1},bank_upd_date=NOW(),bank_upd_alias='{1}' WHERE bank_kode='{0}'"
        End If
        querycheck = commnd(String.Format(q, in_kode.Text, String.Join(",", data1), loggeduser.user_id))

        If querycheck = False Then
            MessageBox.Show("Data tidak dapat tersimpan")
            Exit Sub
        Else
            MessageBox.Show("Data tersimpan")
            doRefreshTab({pgbank})
            Me.Close()
        End If
    End Sub

    Private Sub bt_simpancusto_Click(sender As Object, e As EventArgs) Handles bt_simpancusto.Click
        If in_namabank.Text = Nothing Then
            MessageBox.Show("Nama belum di input")
            in_namabank.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Simpan data bank?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            saveData()
        End If
    End Sub

    'LOAD
    Private Sub fr_bank_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If bt_simpancusto.Text = "Update" Then

        End If
    End Sub

    'UI
End Class