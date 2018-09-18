﻿Public Class fr_piutang_awal
    Private fak_date As Date = Today

    Public Sub loadData(kode As String)
        op_con()
        readcommd("SELECT * FROM selectPiutangAwal WHERE piutang_faktur='" & kode & "'")
        If rd.HasRows Then
            in_faktur.Text = rd.Item("piutang_faktur")
            fak_date = rd.Item("piutang_tgl")
            in_custo.Text = rd.Item("piutang_custo")
            in_custo_n.Text = rd.Item("piutang_custo_n")
            in_sales.Text = rd.Item("piutang_sales")
            in_sales_n.Text = rd.Item("piutang_sales_n")
            in_term.Value = rd.Item("piutang_term")
            in_piutangawal.Text = commaThousand(rd.Item("piutang_awal"))
        End If
        rd.Close()
        in_tgl.Text = fak_date.ToLongDateString
        in_tgl_term.Text = fak_date.AddDays(in_term.Value).ToLongDateString
    End Sub

    '------------drag form
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown, lbl_title.MouseDown, Panel2.MouseDown
        startdrag(Me, e)
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove, lbl_title.MouseMove, Panel2.MouseMove
        dragging(Me)
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp, lbl_title.MouseUp, Panel2.MouseUp
        stopdrag(Me)
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick, lbl_title.DoubleClick, Panel2.DoubleClick
        CenterToScreen()
    End Sub

    '-------------close
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalreturbeli.Click
        Me.Close()
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Tutup Form?", "Kas", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalreturbeli.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '--------------- NUMERIC 
    Private Sub in_term_Enter(sender As Object, e As EventArgs) Handles in_term.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_term_Leave(sender As Object, e As EventArgs) Handles in_term.Leave
        numericLostFocus(sender)
    End Sub

    '---------------load
    Private Sub fr_piutang_awal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If in_faktur.Text <> Nothing Then
            loadData(in_faktur.Text)
        End If
    End Sub

    Private Sub in_term_ValueChanged(sender As Object, e As EventArgs) Handles in_term.ValueChanged
        in_tgl_term.Text = fak_date.AddDays(in_term.Value).ToLongDateString
    End Sub
End Class