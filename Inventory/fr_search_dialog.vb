Public Class fr_search_dialog
    Public query As String = ""
    Public paramquery As String = ""
    Public type As String = ""
    Private rowindex As Integer = 0

    'columns list
    '--------- barang
    Private barang_nama As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Nama Barang",
        .Name = "nama",
        .ReadOnly = True,
        .MinimumWidth = 200
    }
    Private barang_kode As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode Barang",
        .Name = "kode",
        .ReadOnly = True
    }
    Private barang_trans_qty As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "qty",
        .HeaderText = "Qty Trans",
        .Name = "qty",
        .ReadOnly = True
    }

    Private Sub loadData(query As String, paramquery As String)
        Dim bs As New BindingSource
        bs.DataSource = getDataTablefromDB(query)
        bs.Filter = paramquery
        With dgv_list
            .DataSource = bs
            .RowHeadersVisible = False
        End With
    End Sub

    Private Sub addColtoDGV(type As String)
        With dgv_list
            Select Case type
                Case "sales"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {})
                Case "custo"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {})
                Case "gudang"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {})
                Case "supplier"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {})
                Case "barang"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {barang_nama, barang_kode})
                Case "barangfaktur"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {barang_nama, barang_kode, barang_trans_qty})
                Case Else
                    Exit Sub
            End Select
            For i = 0 To .Columns.Count - 1
                .Columns(i).DisplayIndex = i
            Next
        End With
    End Sub

    Private Sub fr_search_dialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        addColtoDGV(type)
        loadData(query, String.Format(paramquery, ""))
    End Sub

    Private Sub bt_search_Click(sender As Object, e As EventArgs) Handles bt_search.Click
        Console.WriteLine(query)
        loadData(query, String.Format(paramquery, in_cari.Text))
        dgv_list.Focus()
    End Sub
End Class