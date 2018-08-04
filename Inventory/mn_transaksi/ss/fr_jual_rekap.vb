Public Class fr_jual_rekap
    Private list_row As Integer = 0
    'FLOW
    'select date
    'select faktur date
    'select sales
    'select faktur(s)
    '-----------> print

    '------------drag form
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, lbl_title.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, lbl_title.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, lbl_title.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick
        CenterToScreen()
    End Sub

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_close.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_close.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '---------------- load fr
    Private Sub fr_jual_rekap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv_sales.DataSource = getDataTablefromDB("SELECT salesman_kode as kode, salesman_nama as nama FROM data_salesman_master")
    End Sub

    '--------------- dgv
    Private Sub dgv_sales_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_sales.CellClick, DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim sales As String = dgv_sales.Rows(e.RowIndex).Cells("sales_kode").Value
            dgv_listfaktur.DataSource = getDataTablefromDB("SELECT faktur_kode, customer_nama, faktur_tanggal_trans,faktur_netto FROM data_penjualan_faktur INNER JOIN data_customer_master ON customer_kode=faktur_customer WHERE faktur_sales='" & sales & "'")
        End If
    End Sub

    Private Sub dgv_listfaktur_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listfaktur.CellClick
        If e.RowIndex >= 0 Then
            list_row = e.RowIndex
        End If
    End Sub

    Private Sub dgv_listfaktur_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_listfaktur.CellDoubleClick
        If e.RowIndex >= 0 Then
            list_row = e.RowIndex
            bt_addfaktur.PerformClick()
        End If
    End Sub

    Private Sub bt_addfaktur_Click(sender As Object, e As EventArgs) Handles bt_addfaktur.Click
        With dgv_listfaktur
            For Each selected As DataGridViewRow In .SelectedRows
                For Each rows As DataGridViewRow In dgv_draftfaktur.Rows
                    If rows.Cells("draft_faktur").Value = selected.Cells("list_faktur").Value Then
                        Exit Sub
                    End If
                Next
                dgv_draftfaktur.Rows.Add(selected.Cells("list_custo").Value, selected.Cells("list_faktur").Value, selected.Cells("list_netto").Value)
            Next
        End With
    End Sub

    Private Sub dgv_draftfaktur_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_draftfaktur.CellDoubleClick
        If e.RowIndex >= 0 Then
            dgv_draftfaktur.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub
End Class