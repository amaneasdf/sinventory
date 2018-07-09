﻿Public Class fr_stok_awal
    Private Sub getGudang(kode As String)
        op_con()
        readcommd("SELECT gudang_kode, gudang_nama FROM data_barang_gudang WHERE gudang_kode='" & kode & "'")
        If rd.HasRows Then
            in_gudang.Text = rd.Item("gudang_kode")
            in_gudang.Text = rd.Item("gudang_nama")
        End If
        rd.Close()
    End Sub

    Private Sub getBarang(kode As String)
        op_con()
        readcommd("SELECT barang_kode, barang_nama FROM data_barang_master WHERE barang_kode='" & kode & "'")
        If rd.HasRows Then
            in_barang.Text = rd.Item("barang_kode")
            in_barang_n.Text = rd.Item("barang_nama")
        End If
        rd.Close()
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalbarang.Click
        Me.Close()
    End Sub

    Private Sub bt_cl_Click(sender As Object, e As EventArgs) Handles bt_cl.Click
        bt_batalbarang.PerformClick()
    End Sub

    Private Sub bt_cl_MouseEnter(sender As Object, e As EventArgs) Handles bt_cl.MouseEnter
        lbl_close.Visible = True
    End Sub

    Private Sub bt_cl_MouseLeave(sender As Object, e As EventArgs) Handles bt_cl.MouseLeave
        lbl_close.Visible = False
    End Sub

    '----------------- menu
    Private Sub mn_save_Click(sender As Object, e As EventArgs) Handles mn_save.Click
        bt_simpanbarang.PerformClick()
    End Sub

    Private Sub mn_cancelorder_Click(sender As Object, e As EventArgs) Handles mn_deact.Click

    End Sub

    Private Sub mn_del_Click(sender As Object, e As EventArgs) Handles mn_del.Click

    End Sub

    '---------------- numeric
    Private Sub in_stok_awal_Enter(sender As Object, e As EventArgs) Handles in_stok_awal.Enter, in_hpp.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_stok_awal_Leave(sender As Object, e As EventArgs) Handles in_stok_awal.Leave, in_hpp.Leave
        numericLostFocus(sender)
    End Sub

    '---------------- load
    Private Sub fr_stok_awal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'input
    Private Sub in_gudang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_gudang.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_gudang_list.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(in_barang, e)
        End If
    End Sub

    Private Sub in_gudang_Leave(sender As Object, e As EventArgs) Handles in_gudang.Leave
        If Trim(in_gudang.Text) <> Nothing Then
            getGudang(Trim(in_gudang.Text))
        End If
    End Sub

    Private Sub bt_gudang_list_Click(sender As Object, e As EventArgs) Handles bt_gudang_list.Click
        in_gudang.Text = Trim(in_gudang.Text)
        Using search As New fr_search_dialog
            With search
                If in_gudang.Text <> Nothing Then
                    .returnkode = in_gudang.Text
                    .in_cari.Text = in_gudang.Text
                End If
                .query = "SELECT gudang_kode as kode, gudang_nama as nama FROM data_barang_gudang"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "gudang"
                .ShowDialog()
                in_gudang.Text = .returnkode
                in_gudang.Focus()
            End With
        End Using
        in_barang.Focus()
    End Sub

    Private Sub in_barang_KeyDown(sender As Object, e As KeyEventArgs) Handles in_barang.KeyDown
        If e.KeyCode = Keys.F1 Then
            bt_barang_list.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            keyshortenter(in_stok_awal, e)
        End If
    End Sub

    Private Sub in_barang_Leave(sender As Object, e As EventArgs) Handles in_barang.Leave
        If Trim(in_barang.Text) <> Nothing Then
            getBarang(Trim(in_barang.Text))
        End If
    End Sub

    Private Sub in_gudang_TextChanged(sender As Object, e As EventArgs) Handles in_gudang.TextChanged
        If Trim(in_gudang.Text) = Nothing Then in_barang_n.Text = ""
    End Sub

    Private Sub bt_barang_list_Click(sender As Object, e As EventArgs) Handles bt_barang_list.Click
        in_barang.Text = Trim(in_barang.Text)
        Using search As New fr_search_dialog
            With search
                If in_barang.Text <> Nothing Then
                    .returnkode = in_barang.Text
                    .in_cari.Text = in_barang.Text
                End If
                .returnkode = in_barang.Text
                .query = "SELECT barang_nama as nama, barang_kode as kode, barang_harga_beli as hargabeli, barang_harga_jual as hargajual FROM data_barang_master"
                .paramquery = "nama LIKE'%{0}%' OR kode LIKE '%{0}%'"
                .type = "barang"
                .ShowDialog()
                in_barang.Text = .returnkode
                in_barang.Focus()
            End With
        End Using
        in_stok_awal.Focus()
    End Sub

    Private Sub in_barang_TextChanged(sender As Object, e As EventArgs) Handles in_barang.TextChanged
        If Trim(in_barang.Text) = Nothing Then in_barang_n.Text = ""
    End Sub

    Private Sub in_stok_awal_KeyDown(sender As Object, e As KeyEventArgs) Handles in_stok_awal.KeyDown
        keyshortenter(in_hpp, e)
    End Sub

    Private Sub in_hpp_KeyDown(sender As Object, e As KeyEventArgs) Handles in_hpp.KeyDown
        keyshortenter(bt_simpanbarang, e)
    End Sub

    '------------------- save
    Private Sub bt_simpanbarang_Click(sender As Object, e As EventArgs) Handles bt_simpanbarang.Click
        Dim dataCol As String()

        op_con()

        If bt_simpanbarang.Text = "Simpan" Then
            'If checkdata("data_barang_stok", "", "") = True Then
            '    Exit Sub
            'End If
        End If
    End Sub
End Class