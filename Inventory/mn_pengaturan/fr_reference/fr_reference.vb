Public Class fr_reference
    Private selecteditem As String

    Private ref_kode As New DataGridViewTextBoxColumn() With {
        .Name = "ref_kode",
        .DataPropertyName = "kode",
        .HeaderText = "Kode",
        .ReadOnly = True
      }
    Private ref_nama As New DataGridViewTextBoxColumn() With {
        .Name = "ref_nama",
        .DataPropertyName = "nama",
        .HeaderText = "Nama",
        .ReadOnly = True,
        .Width = 200
      }
    Private ref_ket As New DataGridViewTextBoxColumn() With {
        .Name = "ref_ket",
        .DataPropertyName = "ket",
        .HeaderText = "Definisi/Keterangan",
        .ReadOnly = True,
        .Width = 200
      }
    Private ref_hgjual As New DataGridViewTextBoxColumn() With {
        .Name = "ref_hgjual",
        .DataPropertyName = "hgjual",
        .HeaderText = "Harga Jual",
        .ReadOnly = True,
        .Width = 150
      }
    Private ref_diskjual As New DataGridViewTextBoxColumn() With {
        .Name = "ref_diskjual",
        .DataPropertyName = "diskjual",
        .HeaderText = "Diskon Jual",
        .ReadOnly = True,
        .Width = 150
      }

    Private Sub setDGVColl(tipe As String)
        With dgv_list

            Select Case tipe
                Case "jenisbarang"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {ref_kode, ref_nama, ref_ket})
                Case "satuan"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {ref_kode, ref_nama, ref_ket})
                Case "custo"
                    .Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {ref_kode, ref_nama, ref_hgjual, ref_diskjual, ref_ket})
                Case Else
                    Exit Sub
            End Select

            For i = 0 To .Columns.Count - 1
                .Columns(i).DisplayIndex = i
            Next
        End With
    End Sub

    Private Sub loadDatatoDGV(source As String, filter As String)
        Dim bs As New BindingSource
        bs.Filter = filter

        Select Case source
            Case "jenisbarang"
                bs.DataSource = getDataTablefromDB("SELECT jenis_kode as kode, jenis_nama as nama, jenis_keterangan as ket FROM data_barang_jenis")
            Case "satuan"
                bs.DataSource = getDataTablefromDB("SELECT satuan_kode as kode, satuan_nama as nama, satuan_keterangan as ket FROM ref_satuan")
            Case "custo"
                bs.DataSource = getDataTablefromDB("SELECT ")
            Case Else
                Exit Sub
        End Select

        dgv_list.DataSource = bs
    End Sub

    Private Sub itemSelected(tipe As String)

    End Sub

    Private Sub fr_reference_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'load data for cb
        With lb_reflist
            .DataSource = jenisRef()
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With

    End Sub

    Private Sub bt_batal_jenis_Click(sender As Object, e As EventArgs) Handles bt_batal_jenis.Click
        Me.Close()
    End Sub

    Private Sub lb_reflist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lb_reflist.SelectedIndexChanged
        If Not lb_reflist.SelectedValue Is Nothing Then
            selecteditem = lb_reflist.SelectedValue.ToString

            dgv_list.Columns.Clear()
            setDGVColl(selecteditem)
            'loadDatatoDGV(selecteditem, "")

        End If
    End Sub

    Private Sub bt_tb_jenis_Click(sender As Object, e As EventArgs) Handles bt_tb_jenis.Click
        Select Case lb_reflist.SelectedValue

        End Select
    End Sub
End Class