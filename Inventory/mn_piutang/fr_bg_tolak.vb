Public Class fr_bg_tolak

    Private Sub loadData(kode As String)
        op_con()

        setSales(in_sales.Text)
        setCusto(in_custo.Text)
        setSupplier(in_supplier.Text)
    End Sub

    Private Sub setSales(kode As String)

    End Sub

    Private Sub setCusto(kode As String)

    End Sub

    Private Sub setSupplier(kode As String)

    End Sub

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

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick, lbl_title.DoubleClick
        CenterToScreen()
    End Sub

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalperkiraan.Click
        Me.Close()
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Tutup Form?", "BG Tolak", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalperkiraan.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanperkiraan.PerformClick()
    End Sub

    Private Sub mn_delete_Click(sender As Object, e As EventArgs) Handles mn_delete.Click

    End Sub

    Private Sub mn_proses_Click(sender As Object, e As EventArgs) Handles mn_proses.Click

    End Sub

    '------------- numeric
    Private Sub in_debet_Enter(sender As Object, e As EventArgs) Handles in_jumlah.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_debet_Leave(sender As Object, e As EventArgs) Handles in_jumlah.Leave
        numericLostFocus(sender)
    End Sub

    '------------- load
    Private Sub fr_bg_tolak_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    '------------- save
    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click

    End Sub

    '------------- input
    Private Sub in_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_sales_list.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(in_custo, e)
        End If
    End Sub

    Private Sub in_sales_Leave(sender As Object, e As EventArgs) Handles in_sales.Leave
        in_sales.Text = Trim(in_sales.Text)
        If in_sales.Text <> Nothing Then
            setSales(in_sales.Text)
        Else
            in_sales_n.Clear()
        End If
    End Sub

    Private Sub bt_sales_list_Click(sender As Object, e As EventArgs) Handles bt_sales_list.Click
        Using search As New fr_search_dialog
            With search

            End With
            in_custo.Focus()
        End Using
    End Sub

    Private Sub in_custo_KeyDown(sender As Object, e As KeyEventArgs) Handles in_custo.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_custo_list.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(in_nobg, e)
        End If
    End Sub

    Private Sub in_custo_Leave(sender As Object, e As EventArgs) Handles in_custo.Leave
        in_custo.Text = Trim(in_custo.Text)
        If in_custo.Text <> Nothing Then
            setCusto(in_custo.Text)
        Else
            in_custo_n.Clear()
        End If
    End Sub

    Private Sub bt_custo_list_Click(sender As Object, e As EventArgs) Handles bt_custo_list.Click
        Using search As New fr_search_dialog
            With search

            End With
            in_nobg.Focus()
        End Using
    End Sub

    Private Sub in_nobg_KeyDown(sender As Object, e As KeyEventArgs) Handles in_nobg.KeyDown
        keyshortenter(date_tgl_bg, e)
    End Sub

    Private Sub date_tgl_bg_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_bg.KeyDown
        keyshortenter(in_jumlah, e)
    End Sub

    Private Sub in_jumlah_KeyDown(sender As Object, e As KeyEventArgs) Handles in_jumlah.KeyDown
        keyshortenter(in_supplier, e)
    End Sub

    Private Sub in_supplier_KeyDown(sender As Object, e As KeyEventArgs) Handles in_supplier.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_supplier_list.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(bt_simpanperkiraan, e)
        End If
    End Sub

    Private Sub in_supplier_Leave(sender As Object, e As EventArgs) Handles in_supplier.Leave
        in_supplier.Text = Trim(in_supplier.Text)
        If in_supplier.Text <> Nothing Then
            setSupplier(in_supplier.Text)
        Else
            in_supplier_n.Clear()
        End If
    End Sub

    Private Sub bt_supplier_list_Click(sender As Object, e As EventArgs) Handles bt_supplier_list.Click
        Using search As New fr_search_dialog
            With search

            End With
        End Using
    End Sub

    Private Sub in_no_bukti_KeyDown(sender As Object, e As KeyEventArgs) Handles in_no_bukti.KeyDown
        keyshortenter(date_tgl_trans, e)
    End Sub

    Private Sub date_tgl_trans_KeyDown(sender As Object, e As KeyEventArgs) Handles date_tgl_trans.KeyDown
        keyshortenter(bt_simpanperkiraan, e)
    End Sub
End Class