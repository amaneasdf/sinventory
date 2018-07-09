Public Class fr_kas_detail
    Private rowindex As Integer = 0

    Private Sub loadData(kode As String)
        op_con()

        setBank(in_bank.Text)
        setSales(in_sales.Text)
    End Sub

    Private Sub setBank(kode As String)

    End Sub

    Private Sub setSales(kode As String)

    End Sub

    Private Sub setRek(kode As String)

    End Sub

    Private Sub textToDgv()

        countDK()
    End Sub

    Private Sub dgvToText()

        countDK()
    End Sub

    Private Sub countDK()

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
        If MessageBox.Show("Tutup Form?", "Kas", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
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
    Private Sub in_debet_Enter(sender As Object, e As EventArgs) Handles in_kredit.Enter, in_debet.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_debet_Leave(sender As Object, e As EventArgs) Handles in_kredit.Leave, in_debet.Leave
        numericLostFocus(sender)
    End Sub

    '------------- cb prevent input
    Private Sub cb_bank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cb_jenis.KeyPress
        e.Handled = True
    End Sub

    '------------- load
    Private Sub fr_kas_detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        in_bank.Focus()
    End Sub

    '------------- save
    Private Sub bt_simpanperkiraan_Click(sender As Object, e As EventArgs) Handles bt_simpanperkiraan.Click

    End Sub

    '------------ input
    Private Sub in_bank_KeyDown(sender As Object, e As KeyEventArgs) Handles in_bank.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_bank_list.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(cb_jenis, e)
        End If
    End Sub

    Private Sub in_bank_Leave(sender As Object, e As EventArgs) Handles in_bank.Leave
        in_bank.Text = Trim(in_bank.Text)
        If in_bank.Text <> Nothing Then
            setBank(in_bank.Text)
        Else
            in_bank_n.Clear()
        End If
    End Sub

    Private Sub bt_bank_list_Click(sender As Object, e As EventArgs) Handles bt_bank_list.Click
        Using search As New fr_search_dialog
            With search
                If Trim(in_bank.Text) <> Nothing Then
                    .returnkode = Trim(in_bank.Text)
                    .in_cari.Text = Trim(in_bank.Text)
                End If
                .query = ""
                .paramquery = ""
                .type = ""
                '.ShowDialog()
                in_bank.Text = .returnkode
            End With
        End Using
        setBank(in_bank.Text)
        cb_jenis.Focus()
    End Sub

    Private Sub cb_jenis_KeyDown(sender As Object, e As KeyEventArgs) Handles cb_jenis.KeyDown
        keyshortenter(in_bg, e)
    End Sub

    Private Sub in_bg_KeyDown(sender As Object, e As KeyEventArgs) Handles in_bg.KeyDown
        keyshortenter(in_sales, e)
    End Sub

    Private Sub in_sales_KeyDown(sender As Object, e As KeyEventArgs) Handles in_sales.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_sales_list.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(in_rek, e)
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
                .query = "SELECT salesman_nama as nama, salesman_kode as kode FROM data_salesman_master"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "sales"
                If Trim(in_sales.Text) <> Nothing Then
                    .returnkode = Trim(in_sales.Text)
                    .in_cari.Text = Trim(in_sales.Text)
                End If
                .ShowDialog()
                in_sales.Text = .returnkode
                setSales(in_sales.Text)
            End With
        End Using
        in_rek.Focus()
    End Sub

    '------------- input kas
    Private Sub in_rek_KeyDown(sender As Object, e As KeyEventArgs) Handles in_rek.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_rek_list.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(in_debet, e)
        End If
    End Sub

    Private Sub in_rek_Leave(sender As Object, e As EventArgs) Handles in_rek.Leave
        in_rek.Text = Trim(in_rek.Text)
        If in_rek.Text <> Nothing Then
            setRek(in_rek.Text)
        Else
            in_rek_n.Clear()
        End If
    End Sub

    Private Sub bt_rek_list_Click(sender As Object, e As EventArgs) Handles bt_rek_list.Click
        in_rek.Text = Trim(in_rek.Text)
        Using search As New fr_search_dialog
            With search
                .query = ""
                .paramquery = ""
                .type = ""
                If in_rek.Text <> Nothing Then
                    .returnkode = in_rek.Text
                    .in_cari.Text = in_rek.Text
                End If
                .ShowDialog()
                in_rek.Text = .returnkode
                setRek(in_rek.Text)
            End With
        End Using
        in_debet.Focus()
    End Sub

    Private Sub in_debet_KeyDown(sender As Object, e As KeyEventArgs) Handles in_debet.KeyDown
        keyshortenter(in_kredit, e)
    End Sub

    Private Sub in_kredit_KeyDown(sender As Object, e As KeyEventArgs) Handles in_kredit.KeyDown
        keyshortenter(in_ket, e)
    End Sub

    Private Sub in_ket_KeyDown(sender As Object, e As KeyEventArgs) Handles in_ket.KeyDown
        keyshortenter(bt_tbkas, e)
    End Sub

    Private Sub bt_tbkas_Click(sender As Object, e As EventArgs) Handles bt_tbkas.Click
        textToDgv()
    End Sub

    Private Sub dgv_kas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_kas.CellDoubleClick
        If e.RowIndex >= 0 Then
            rowindex = e.RowIndex
            If bt_simpanperkiraan.Text = "Simpan" Then
                dgvToText()
            End If
        End If
    End Sub
End Class