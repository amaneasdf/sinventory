Public Class fr_bank_detail
    Private bnkStatus As String = "1"
    Private popState As String = "perkiraan"

    Private Sub loadData(kode As String)
        op_con()

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
                Case "supplier"
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
            }

        op_con()
        If bt_simpancusto.Text = "Simpan" Then
            'GENNERATE CODE
            If Trim(in_kode.Text) = Nothing Then
                Dim no As Integer = 1
                readcommd("SELECT SUBSTRING(bank_kode,4) as ss FROM data_barang_master WHERE barang_kode LIKE 'BNK%' " _
                          & "ORDER BY ss DESC LIMIT 1")
                If rd.HasRows Then
                    no = CInt(rd.Item(0)) + 1
                End If
                rd.Close()

                in_kode.Text = "BNK" & no.ToString("D5")
            Else
                If checkdata("data_barang_master", "'" & in_kode.Text & "'", "barang_kode") Then
                    MessageBox.Show("Kode Barang " & in_kode.Text & " sudah ada")
                    in_kode.Focus()
                    Exit Sub
                End If
            End If

        ElseIf bt_simpancusto.Text = "Update" Then

        End If


    End Sub

End Class