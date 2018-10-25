Public Class fr_hutang_awal
    Private fak_date As Date = Today

    Public Sub loadData(kode As String)
        Dim q As String = "SELECT hutang_faktur,faktur_tanggal_trans, faktur_supplier, supplier_nama, faktur_term, faktur_netto " _
                          & "FROM data_hutang_awal LEFT JOIN data_pembelian_faktur ON hutang_faktur=faktur_kode AND faktur_status=1 " _
                          & "LEFT JOIN data_supplier_master ON supplier_kode=faktur_supplier " _
                          & "WHERE hutang_faktur='{0}'"
        op_con()
        'readcommd("SELECT * FROM selectHutangAwal WHERE hutang_faktur='" & kode & "'")
        readcommd(String.Format(q, kode))
        If rd.HasRows Then
            in_faktur.Text = rd.Item("hutang_faktur")
            fak_date = rd.Item("faktur_tanggal_trans")
            in_supplier.Text = rd.Item("faktur_supplier")
            in_supplier_n.Text = rd.Item("supplier_nama")
            in_term.Value = rd.Item("faktur_term")
            in_hutang_awal.Text = commaThousand(rd.Item("faktur_netto"))
        End If
        rd.Close()
        in_tgl.Text = fak_date.ToLongDateString
        in_tgl_term.Text = fak_date.AddDays(in_term.Value).ToString("dd/MM/yyyy")
        loadDgv(kode)
    End Sub

    Private Sub loadDgv(kode As String)
        Dim dt As New DataTable

        dt = getDataTablefromDB("SELECT ket AS 'Ket', faktur_tanggal_trans AS 'Tanggal', " _
                                & "bayar AS 'Bayar/Retur', hutang_awal AS  'Hutang', ref AS 'Referensi' FROM selecthutangtransaksi " _
                                & "LEFT JOIN data_supplier_master ON faktur_supplier=supplier_kode " _
                                & "WHERE hutang_faktur='" & kode & "' ORDER BY hutang_awal DESC, faktur_tanggal_trans")

        With dgv_hutang
            .DataSource = dt
            .Columns(2).DefaultCellStyle = dgvstyle_currency
            .Columns(3).DefaultCellStyle = dgvstyle_currency
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
                _bayar += row.Cells(2).Value
                _hutang += row.Cells(3).Value
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
            .do_load()

            .in_supplier.Text = in_supplier.Text
            .in_supplier_n.Text = in_supplier_n.Text
            .in_saldotitipan.Text = titipan

            .in_faktur.Text = in_faktur.Text
            .in_tgl_jtfaktur.Text = in_tgl_term.Text
            ._totalhutang = removeCommaThousand(in_hutang_awal.Text)
            .in_sisafaktur.Text = in_sisa.Text

            .Show(main)
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

    '--------------- NUMERIC 
    Private Sub in_term_Enter(sender As Object, e As EventArgs) Handles in_term.Enter
        numericGotFocus(sender)
    End Sub

    Private Sub in_term_Leave(sender As Object, e As EventArgs) Handles in_term.Leave
        numericLostFocus(sender, "N0")
    End Sub

    '---------------------- LOAD FORM
    Private Sub fr_hutang_awal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If in_faktur.Text <> Nothing Then
            loadData(in_faktur.Text)
        End If
    End Sub

    Private Sub in_term_ValueChanged(sender As Object, e As EventArgs) Handles in_term.ValueChanged
        in_tgl_term.Text = fak_date.AddDays(in_term.Value).ToLongDateString
    End Sub

    Private Sub bt_bayar_Click(sender As Object, e As EventArgs) Handles bt_bayar.Click
        If MessageBox.Show("Tambah Pembayaran?", "Hutang Awal", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            doBayar()
        End If
    End Sub
End Class