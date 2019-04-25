Public Class fr_piutang_awal
    Private fak_date As Date = Today

    Public Sub loadData(kode As String)
        Dim q As String = "SELECT piutang_faktur, piutang_tgl, piutang_awal, IFNULL(ppn.ref_text,'ERROR') bayar_kat, " _
                          & "piutang_custo, customer_nama as piutang_custo_n, piutang_sales, salesman_nama as piutang_sales_n," _
                          & "DATEDIFF(piutang_jt,piutang_tgl) faktur_term " _
                          & "FROM data_piutang_awal " _
                          & "LEFT JOIN data_customer_master ON piutang_custo=customer_kode " _
                          & "LEFT JOIN data_salesman_master ON piutang_sales=salesman_kode " _
                          & "LEFT JOIN ref_jenis ppn ON piutang_pajak=ppn.ref_kode AND ppn.ref_status=1 AND ppn.ref_type='ppn_trans2' " _
                          & "WHERE piutang_faktur='{0}'"
        op_con()
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            in_faktur.Text = rd.Item("piutang_faktur")
            fak_date = rd.Item("piutang_tgl")
            in_kat.Text = rd.Item("bayar_kat")
            in_custo.Text = rd.Item("piutang_custo")
            in_custo_n.Text = rd.Item("piutang_custo_n")
            in_sales.Text = rd.Item("piutang_sales")
            in_sales_n.Text = rd.Item("piutang_sales_n")
            in_term.Text = rd.Item("faktur_term")
            in_piutangawal.Text = commaThousand(rd.Item("piutang_awal"))
        End If
        rd.Close()
        in_tgl.Text = fak_date.ToLongDateString
        in_tgl_term.Text = fak_date.AddDays(in_term.Text).ToString("dd/MM/yyyy")

        loadDgv(kode)

        If selectperiode.closed = True Then
            bt_bayar.Enabled = False
        End If
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
        Dim titipan As String = "0"

        op_con()
        readcommd("SELECT getSisaTitipan('piutang','" & selectperiode.id & "','" & in_custo.Text & "')")
        If rd.HasRows Then
            titipan = commaThousand(rd.Item(0))
        End If
        rd.Close()

        With x
            .doLoadNew()
            .cb_pajak.SelectedValue = IIf(in_kat.Text = "A", 0, 1)
            .in_sales.Text = in_sales.Text
            .in_sales_n.Text = in_sales_n.Text
            .in_saldotitipan.Text = titipan
            .in_custo.Text = in_custo.Text
            .in_custo_n.Text = in_custo_n.Text

            .in_faktur.Text = in_faktur.Text
            .in_sisafaktur.Text = in_sisa.Text
            ._totalhutang = removeCommaThousand(in_piutangawal.Text)
            .in_tgl_jtfaktur.Text = in_tgl_term.Text
            .Owner = main
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
        'If MessageBox.Show("Tutup Form?", "Piutang Awal", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        '    Me.Close()
        'End If
    End Sub

    Private Sub fr_kas_detail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

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
    Private Sub in_term_Enter(sender As Object, e As EventArgs)
        numericGotFocus(sender)
    End Sub

    Private Sub in_term_Leave(sender As Object, e As EventArgs)
        numericLostFocus(sender, "N0")
    End Sub

    '---------------load
    Private Sub fr_piutang_awal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If in_faktur.Text <> Nothing Then
            loadData(in_faktur.Text)
        End If
    End Sub

    Private Sub bt_bayar_Click(sender As Object, e As EventArgs) Handles bt_bayar.Click
        If MessageBox.Show("Tambah Pembayaran?", "Piutang Awal", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            doBayar()
        End If
    End Sub
End Class