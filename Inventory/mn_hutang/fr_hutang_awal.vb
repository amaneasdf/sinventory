﻿Public Class fr_hutang_awal
    Private fak_date As Date = Today

    Public Sub loadData(kode As String)
        Dim q As String = "SELECT hutang_faktur, hutang_tgl, hutang_tgl_jt, hutang_supplier, supplier_nama, " _
                          & "DATEDIFF(hutang_tgl_jt,hutang_tgl) faktur_term, hutang_awal, " _
                          & "IFNULL(ppn.ref_text,'ERROR') bayar_kat " _
                          & "FROM data_hutang_awal " _
                          & "LEFT JOIN data_supplier_master ON supplier_kode=hutang_supplier " _
                          & "LEFT JOIN ref_jenis ppn ON hutang_pajak=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans2' " _
                          & "WHERE hutang_faktur='{0}'"
        op_con()
        'readcommd("SELECT * FROM selectHutangAwal WHERE hutang_faktur='" & kode & "'")
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            in_faktur.Text = rd.Item("hutang_faktur")
            in_kat.Text = rd.Item("bayar_kat")
            fak_date = rd.Item("hutang_tgl")
            in_tgl_term.Text = CDate(rd.Item("hutang_tgl_jt")).ToLongDateString
            in_supplier.Text = rd.Item("hutang_supplier")
            in_supplier_n.Text = rd.Item("supplier_nama")
            in_term.Text = rd.Item("faktur_term")
            in_hutang_awal.Text = commaThousand(rd.Item("hutang_awal"))
        End If
        rd.Close()
        in_tgl.Text = fak_date.ToLongDateString
        loadDgv(kode)

        If selectperiode.closed = True Then
            bt_bayar.Enabled = False
        End If
    End Sub

    Private Sub loadDgv(kode As String)
        Dim dt As New DataTable

        dt = getDataTablefromDB("getDataHutangTrans('" & selectperiode.id & "','" & kode & "')")

        On Error Resume Next
        With dgv_hutang
            .AutoGenerateColumns = False
            .DataSource = dt
            .Columns("bayar").DefaultCellStyle = dgvstyle_currency
            .Columns("hutang").DefaultCellStyle = dgvstyle_currency
        End With
        countTotal()

        If removeCommaThousand(in_sisa.Text) = 0 Then
            bt_bayar.Enabled = False
        End If
    End Sub

    Private Sub countTotal()
        Dim _bayar As Double = 0
        Dim _hutang As Double = 0
        If dgv_hutang.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgv_hutang.Rows
                _bayar += row.Cells("bayar").Value
                _hutang += row.Cells("hutang").Value
            Next
        End If
        in_total.Text = commaThousand(_bayar)
        in_sisa.Text = commaThousand(_hutang - _bayar)
        If _hutang - _bayar <= 0 Then
            in_tgllunas.Text = CDate(dgv_hutang.Rows(dgv_hutang.Rows.Count - 1).Cells(1).Value).ToLongDateString
        End If
    End Sub

    Private Sub doBayar()
        Dim x As New fr_hutang_bayar
        Dim titipan As String = "0"

        op_con()
        readcommd("SELECT getSisaTitipan('hutang','" & selectperiode.id & "','" & in_supplier.Text & "')")
        If rd.HasRows Then
            titipan = commaThousand(rd.Item(0))
        End If
        rd.Close()

        With x
            .doLoadNew()
            .cb_pajak.SelectedValue = IIf(in_kat.Text = "A", 0, 1)
            .in_supplier.Text = in_supplier.Text
            .in_supplier_n.Text = in_supplier_n.Text
            .in_saldotitipan.Text = titipan

            .in_faktur.Text = in_faktur.Text
            .in_tgl_jtfaktur.Text = in_tgl_term.Text
            ._totalhutang = removeCommaThousand(in_hutang_awal.Text)
            .in_sisafaktur.Text = in_sisa.Text

            .Owner = main
        End With
        Me.Close()
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bt_batalreturbeli.Click
        'If MessageBox.Show("Tutup Form?", "Hutang Awal", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        Me.Close()
        'End If
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'e.Cancel = True
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

    '---------------------- LOAD FORM
    Private Sub fr_hutang_awal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If in_faktur.Text <> Nothing Then
            loadData(in_faktur.Text)
        End If
    End Sub

    Private Sub bt_bayar_Click(sender As Object, e As EventArgs) Handles bt_bayar.Click
        If MessageBox.Show("Tambah Pembayaran?", "Hutang Awal", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            doBayar()
        End If
    End Sub
End Class