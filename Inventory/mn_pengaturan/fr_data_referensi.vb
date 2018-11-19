Public Class fr_data_referensi
    Public tabpagename As TabPage

    Public Sub setpage(page As TabPage)
        tabpagename = page
        Console.WriteLine("pg" & page.Name.ToString)
        Console.WriteLine("pgset" & tabpagename.Name.ToString)
    End Sub

    Public Sub performRefresh()

    End Sub

    Private Sub loadDgv(jenis As String)
        Dim q As String = ""
        Dim dgv As DataGridView
        Dim dt As New DataTable

        Select Case jenis
            Case "custoarea"
                q = "SELECT c_area_id as 'ID', c_area_nama as 'Nama Area', ref_kab_nama as 'Kabupaten' " _
                    & "FROM data_customer_area LEFT JOIN ref_area_kabupaten ON ref_kab_id=c_area_kode_kab AND ref_kab_status=1 " _
                    & "WHERE c_area_status=1"
                dgv = dgv_listarea
        End Select

        dt = getDataTablefromDB(q)

        With dgv.Rows
            For Each rows As DataRow In dt.Rows
                .Add(rows)
            Next
        End With
    End Sub

    Public Sub doLoad()
        If pnl_fl_container.Visible = True Then
            With cb_area
                .DataSource = jenis("areacustokab")
                .ValueMember = "Value"
                .DisplayMember = "Text"
            End With
            loadDgv("custoarea")
        End If
    End Sub
End Class
