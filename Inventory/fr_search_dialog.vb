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

    '--------jual
    Private jual_faktur As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Faktur",
        .Name = "kode",
        .ReadOnly = True
    }
    Private jual_tgl As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tgl",
        .HeaderText = "Tanggal",
        .Name = "tgl",
        .ReadOnly = True
    }
    Private jual_custo As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "custo",
        .HeaderText = "Customer",
        .Name = "custo",
        .ReadOnly = True,
        .MinimumWidth = 200
    }
    Private jual_sales As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "sales",
        .HeaderText = "Salesman",
        .Name = "sales",
        .ReadOnly = True,
        .MinimumWidth = 200
    }
    Private jual_gudang As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "gudang",
        .HeaderText = "Gudang",
        .Name = "gudang",
        .ReadOnly = True,
        .MinimumWidth = 200
    }
    '--------beli
    Private beli_faktur As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "kode",
        .HeaderText = "Faktur",
        .Name = "kode",
        .ReadOnly = True
    }
    Private beli_tgl As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "tgl",
        .HeaderText = "Tanggal",
        .Name = "tgl",
        .ReadOnly = True
    }
    Private beli_supplier As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "supplier",
        .HeaderText = "Supplier",
        .Name = "supplier",
        .ReadOnly = True,
        .MinimumWidth = 200
    }
    Private beli_gudang As New System.Windows.Forms.DataGridViewTextBoxColumn() With {
        .DataPropertyName = "gudang",
        .HeaderText = "Gudang",
        .Name = "gudang",
        .ReadOnly = True,
        .MinimumWidth = 200
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
            .Columns.Clear()
            setDoubleBuffered(dgv_list, True)
            Select Case type
                Case "sales"
                    lbl_judul.Text += " Salesman"
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
                Case "barangmutasi"
                    lbl_judul.Text += " Barang"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {barang_nama, barang_kode, jual_gudang})
                Case "jual"
                    lbl_judul.Text += " Penjualan"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {jual_faktur, jual_tgl, jual_sales, jual_custo, jual_gudang})
                Case "beli"
                    lbl_judul.Text += " Pembelian"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {beli_faktur, beli_tgl, beli_supplier, beli_gudang})
                Case "hutangfaktur"
                    lbl_judul.Text += " Faktur"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {beli_faktur, beli_tgl, beli_supplier})
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
            e.SuppressKeyPress = True
            bt_search.PerformClick()
        End If
    End Sub

    Private Sub bt_search_Click(sender As Object, e As EventArgs) Handles bt_search.Click
        Console.WriteLine(query)
        loadData(query, String.Format(paramquery, in_cari.Text))
        dgv_list.Focus()
    End Sub

    Private Sub dgv_list_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellEnter
        If e.RowIndex > -1 Then
            rowindex = e.RowIndex
        End If
    End Sub

    Private Sub dgv_list_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_list.CellDoubleClick
        If e.RowIndex > -1 Then
            rowindex = e.RowIndex
            Try
                returnkode = dgv_list.Rows(rowindex).Cells("kode").Value
            Catch ex As Exception
                returnkode = dgv_list.Rows(rowindex).Cells("kode").Value
                consoleWriteLine(ex.Message)
            End Try
            Me.Close()
        End If
    End Sub

    Private Sub bt_ok_Click(sender As Object, e As EventArgs) Handles bt_ok.Click
        Try
            returnkode = dgv_list.Rows(rowindex).Cells("kode").Value
        Catch ex As Exception
            returnkode = dgv_list.Rows(rowindex).Cells("kode").Value
            consoleWriteLine(ex.Message)
        End Try
        Me.Close()
    End Sub

    Private Sub fr_search_dialog_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter AndAlso dgv_list.Focused = True Then
            Try
                returnkode = dgv_list.Rows(rowindex).Cells("kode").Value
            Catch ex As Exception
                returnkode = dgv_list.Rows(rowindex).Cells("kode").Value
                consoleWriteLine(ex.Message)
            End Try
            Me.Close()
        End If
    End Sub

    Private Sub dgv_list_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_list.ColumnHeaderMouseClick, dgv_list.ColumnHeaderMouseDoubleClick
        dgv_list.ClearSelection()
        rowindex = 0
        dgv_list.Focus()
    End Sub
End Class