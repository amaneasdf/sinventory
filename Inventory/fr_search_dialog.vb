Public Class fr_search_dialog
    Public query As String = ""
    Public paramquery As String = ""
    Public type As String = ""
    Public returnkode As String = ""
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
    Private barang_harga_beli As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "hargabeli",
        .HeaderText = "Harga Beli",
        .Name = "hargabeli",
        .ReadOnly = True
    }
    Private barang_harga_jual As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "hargajual",
        .HeaderText = "Harga Jual",
        .Name = "hargajual",
        .ReadOnly = True
    }

    '--------gudang
    Private gudang_nama As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Nama Gudang",
        .Name = "nama",
        .ReadOnly = True,
        .MinimumWidth = 200
    }
    Private gudang_kode As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode Gudang",
        .Name = "kode",
        .ReadOnly = True
    }

    '--------supplier
    Private supplier_nama As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Nama",
        .Name = "nama",
        .ReadOnly = True,
        .MinimumWidth = 200
    }
    Private supplier_kode As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode Supplier",
        .Name = "kode",
        .ReadOnly = True
    }

    '--------sales
    Private sales_nama As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Nama",
        .Name = "nama",
        .ReadOnly = True,
        .MinimumWidth = 200
    }
    Private sales_kode As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode Sales",
        .Name = "kode",
        .ReadOnly = True
    }

    '--------custo
    Private custo_nama As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "nama",
        .HeaderText = "Nama",
        .Name = "nama",
        .ReadOnly = True,
        .MinimumWidth = 200
    }
    Private custo_kode As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Kode Customer",
        .Name = "kode",
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
                    lbl_judul.Text += " Gudang"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {sales_nama, sales_kode})
                Case "custo"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {custo_nama, custo_kode})
                Case "gudang"
                    lbl_judul.Text += " Gudang"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {gudang_nama, gudang_kode})
                Case "supplier"
                    lbl_judul.Text += " Supplier"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {supplier_nama, supplier_kode})
                Case "barang"
                    lbl_judul.Text += " Barang"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {barang_nama, barang_kode, barang_harga_beli, barang_harga_jual})
                Case "barangfaktur"
                    lbl_judul.Text += " Barang"
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

    Private Sub in_cari_KeyDown(sender As Object, e As KeyEventArgs) Handles in_cari.KeyDown
        If e.KeyCode = Keys.Enter Then
            bt_search.PerformClick()
        End If
    End Sub

    Private Sub bt_search_Click(sender As Object, e As EventArgs) Handles bt_search.Click
        Console.WriteLine(query)
        loadData(query, String.Format(paramquery, in_cari.Text))
        dgv_list.Focus()
    End Sub

    Private Sub dgv_list_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellEnter
        rowindex = e.RowIndex
    End Sub

    Private Sub dgv_list_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellDoubleClick
        rowindex = e.RowIndex
        returnkode = dgv_list.Rows(rowindex).Cells("kode").Value
        Me.Dispose()
    End Sub

    Private Sub bt_ok_Click(sender As Object, e As EventArgs) Handles bt_ok.Click
        returnkode = dgv_list.Rows(rowindex).Cells("kode").Value
        Me.Dispose()
    End Sub

    Private Sub fr_search_dialog_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub dgv_list_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_list.ColumnHeaderMouseClick, dgv_list.ColumnHeaderMouseDoubleClick
        dgv_list.ClearSelection()
        rowindex = 0
        dgv_list.Focus()
    End Sub
End Class