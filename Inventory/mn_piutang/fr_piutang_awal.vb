Public Class fr_piutang_awal
    Private fak_date As Date = Today

    Public Sub loadData(kode As String)
        Dim q As String = "SELECT piutang_faktur, faktur_tanggal_trans as piutang_tgl, faktur_netto-faktur_bayar as piutang_awal, " _
                          & "faktur_customer as piutang_custo, customer_nama as piutang_custo_n, faktur_sales as piutang_sales, " _
                          & "salesman_nama as piutang_sales_n, faktur_term FROM data_piutang_awal " _
                          & "LEFT JOIN data_penjualan_faktur ON piutang_faktur=faktur_kode AND faktur_status=1 " _
                          & "LEFT JOIN data_customer_master ON faktur_customer=customer_kode " _
                          & "LEFT JOIN data_salesman_master ON faktur_sales=salesman_kode " _
                          & "WHERE piutang_faktur='{0}'"
        op_con()
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            in_faktur.Text = rd.Item("piutang_faktur")
            fak_date = rd.Item("piutang_tgl")
            in_custo.Text = rd.Item("piutang_custo")
            in_custo_n.Text = rd.Item("piutang_custo_n")
            in_sales.Text = rd.Item("piutang_sales")
            in_sales_n.Text = rd.Item("piutang_sales_n")
            in_term.Value = rd.Item("faktur_term")
            in_piutangawal.Text = commaThousand(rd.Item("piutang_awal"))
        End If
        rd.Close()
        in_tgl.Text = fak_date.ToLongDateString
        in_tgl_term.Text = fak_date.AddDays(in_term.Value).ToLongDateString

        loadDgv(kode)
    End Sub

    Private Sub loadDgv(kode As String)
        Dim dt As New DataTable

        dt = getDataTablefromDB("getDataPiutangTrans('" & selectperiode.id & "','" & kode & "')")

        With dgv_hutang
            .AutoGenerateColumns = False
            .DataSource = dt
            .Columns("bayar").DefaultCellStyle = dgvstyle_currency
            .Columns("piutang").DefaultCellStyle = dgvstyle_currency
        End With
        countTotal()
    End Sub

    Private Sub countTotal()
        Dim _bayar As Double = 0
        Dim _hutang As Double = 0
        If dgv_hutang.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgv_hutang.Rows
                _bayar += row.Cells("bayar").Value
                _hutang += row.Cells("piutang").Value
            Next
        End If
        in_total.Text = commaThousand(_bayar)
        in_sisa.Text = commaThousand(_hutang - _bayar)
        If _hutang - _bayar <= 0 Then
            in_tgllunas.Text = CDate(dgv_hutang.Rows(dgv_hutang.Rows.Count - 1).Cells(1).Value).ToLongDateString
        End If
    End Sub

    Private Sub doBayar()
        Dim x As New fr_piutang_bayar
        With x

            .Show()
        End With
        Me.Close()
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
        numericLostFocus(sender, "N0")
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

    Private Sub bt_bayar_Click(sender As Object, e As EventArgs) Handles bt_bayar.Click
        If MessageBox.Show("Tambah Pembayaran?", "Piutang Awal", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            doBayar()
        End If
    End Sub
End Class